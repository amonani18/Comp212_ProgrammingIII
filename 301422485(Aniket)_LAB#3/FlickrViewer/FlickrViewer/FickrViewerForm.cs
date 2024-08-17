using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FlickrViewer
{
    public partial class FickrViewerForm : Form
    {
        private const string KEY = "d5ecb1f13cb3f3c2490cbbf53826299a";
        private static HttpClient flickrClient = new HttpClient();
        Task<string> flickrTask = null;

        public FickrViewerForm()
        {
            InitializeComponent();
        }

        private async void searchButton_Click(object sender, EventArgs e)
        {
            if (flickrTask?.Status != TaskStatus.RanToCompletion)
            {
                var result = MessageBox.Show(
                   "Cancel the current Flickr search?",
                   "Are you sure?", MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    return;
                }
                else
                {
                    flickrClient.CancelPendingRequests();
                }
            }

            var flickrURL = "https://api.flickr.com/services/rest/?method=" +
               $"flickr.photos.search&api_key={KEY}&" +
               $"tags={inputTextBox.Text.Replace(" ", ",")}" +
               "&tag_mode=all&per_page=500&privacy_filter=1";

            imagesListBox.DataSource = null;
            imagesListBox.Items.Clear();
            pictureBox.Image = null;
            imagesListBox.Items.Add("Loading...");

            flickrTask = flickrClient.GetStringAsync(flickrURL);
            XDocument flickrXML = XDocument.Parse(await flickrTask);

            var flickrPhotos =
               from photo in flickrXML.Descendants("photo")
               let id = photo.Attribute("id").Value
               let title = photo.Attribute("title").Value
               let secret = photo.Attribute("secret").Value
               let server = photo.Attribute("server").Value
               let farm = photo.Attribute("farm").Value
               select new FlickrResult
               {
                   Title = title,
                   URL = $"https://farm{farm}.staticflickr.com/" +
                     $"{server}/{id}_{secret}.jpg"
               };

            imagesListBox.Items.Clear();

            if (flickrPhotos.Any())
            {
                imagesListBox.DataSource = flickrPhotos.ToList();
                imagesListBox.DisplayMember = "Title";
            }
            else
            {
                imagesListBox.Items.Add("No matches");
            }
        }

        private void imagesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (imagesListBox.SelectedItem != null)
            {
                var selectedImageUrl = ((FlickrResult)imagesListBox.SelectedItem).URL;

                Task.Run(async () =>
                {
                    try
                    {
                        byte[] imageBytes = await DownloadImageAsync(selectedImageUrl);

                        Parallel.Invoke(
                           () => DisplayImage(imageBytes),
                           () => GenerateThumbnail(imageBytes, "thumbnail.png")
                        );
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                });
            }
        }

        private void DisplayImage(byte[] imageBytes)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<byte[]>(DisplayImage), imageBytes);
            }
            else
            {
                using (var memoryStream = new MemoryStream(imageBytes))
                {
                    pictureBox.Image = Image.FromStream(memoryStream);
                }
            }
        }

        private async Task<byte[]> DownloadImageAsync(string imageUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                return await client.GetByteArrayAsync(imageUrl);
            }
        }

        public void GenerateThumbnail(byte[] imageBytes, string thumbnailFileName)
        {
            try
            {
                int imageHeight = 100;
                int imageWidth = 100;

                using (MemoryStream memoryStream = new MemoryStream(imageBytes))
                {
                    using (Image fullSizeImg = Image.FromStream(memoryStream))
                    {
                        Image.GetThumbnailImageAbort dummyCallBack = new Image.GetThumbnailImageAbort(ThumbnailCallback);
                        using (Image thumbNailImage = fullSizeImg.GetThumbnailImage(imageWidth, imageHeight, dummyCallBack, IntPtr.Zero))
                        {
                            string tempPath = Path.Combine(Path.GetTempPath(), thumbnailFileName);
                            thumbNailImage.Save(tempPath, ImageFormat.Jpeg);
                        }
                    }
                }
            }
            catch (ExternalException ex)
            {
            }
            catch (Exception ex)
            {
            }
        }

        public bool ThumbnailCallback()
        {
            return false;
        }
    }
}

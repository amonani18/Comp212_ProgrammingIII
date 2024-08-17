using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Linear_Search
{
    public partial class MainWindow : Window
    {
        private int[] intArray;
        private double[] doubleArray;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void GenerateIntArray(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            intArray = new int[10];
            for (int i = 0; i < intArray.Length; i++)
            {
                intArray[i] = random.Next(100); // Generate random integers between 0 and 99
            }
            displayBox.ItemsSource = intArray;
        }

        private void GenerateDoubleArray(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            doubleArray = new double[10];
            for (int i = 0; i < doubleArray.Length; i++)
            {
                doubleArray[i] = random.NextDouble() * 100; // Generate random doubles between 0.0 and 99.9
            }
            displayBox.ItemsSource = doubleArray;
        }

        private void SearchArray(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = -1;
                if (displayBox.ItemsSource == intArray)
                {
                    index = SearchHelper.Search(intArray, int.Parse(searchBox.Text));
                }
                else if (displayBox.ItemsSource == doubleArray)
                {
                    index = SearchHelper.Search(doubleArray, double.Parse(searchBox.Text));
                }

                IntSearchResult.Text = index != -1 ? $"Found at index {index}" : "Not found";
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number.");
            }
            catch (OverflowException)
            {
                MessageBox.Show("Number too large or too small.");
            }
        }


        private void CopyMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (displayBox.SelectedItem != null)
            {
                Clipboard.SetText(displayBox.SelectedItem.ToString());
            }
        }

    }
}
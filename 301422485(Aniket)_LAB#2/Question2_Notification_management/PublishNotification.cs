using System;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class PublishNotification : Form
    {
        public string NotificationMessage { get; private set; }

        public PublishNotification()
        {
            InitializeComponent();
            button1.Text = "Publish";
            button2.Text = "Exit";

            button1.Click += PublishButton_Click;
            button2.Click += ExitButton_Click;
        }

        private void PublishButton_Click(object sender, EventArgs e)
        {
            NotificationMessage = textBox1.Text;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

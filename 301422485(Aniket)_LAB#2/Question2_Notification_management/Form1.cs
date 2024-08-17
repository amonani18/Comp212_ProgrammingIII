using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class Form1 : Form
    {
        private Dictionary<string, string> subscribers = new Dictionary<string, string>();
        public event NotificationHandler OnNotification;

        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false; // Disable Publish Notification button initially
            button1.Text = "Manage Subscription";
            button2.Text = "Publish Notification";
            button3.Text = "Exit";

            button1.Click += ManageSubscriptionButton_Click;
            button2.Click += PublishNotificationButton_Click;
            button3.Click += ExitButton_Click;

            OnNotification += NotifySubscribers;
        }

        private void ManageSubscriptionButton_Click(object sender, EventArgs e)
        {
            SubscriptionForm subscriptionForm = new SubscriptionForm(subscribers);
            subscriptionForm.ShowDialog();
            button2.Enabled = subscribers.Count > 0;
        }

        private void PublishNotificationButton_Click(object sender, EventArgs e)
        {
            PublishNotification notificationForm = new PublishNotification();
            if (notificationForm.ShowDialog() == DialogResult.OK)
            {
                OnNotification?.Invoke(notificationForm.NotificationMessage);
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NotifySubscribers(string message)
        {
            foreach (var key in subscribers.Keys)
            {
                // Here you would add logic to send notifications to the subscribers
                // e.g., send email or SMS
                Console.WriteLine($"Notification sent to {key} via {subscribers[key]}: {message}");
            }
        }
    }

    public delegate void NotificationHandler(string message);
}

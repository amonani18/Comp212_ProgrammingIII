using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class SubscriptionForm : Form
    {
        private Dictionary<string, string> subscribers;

        public SubscriptionForm(Dictionary<string, string> subscribers)
        {
            InitializeComponent();
            this.subscribers = subscribers;
            this.SubscribeButton.Text = "Subscribe";
            this.UnsubscribeButton.Text = "Unsubscribe";
            this.CancelButton.Text = "Cancel";
            this.SubscribeButton.Click += SubscribeButton_Click;
            this.UnsubscribeButton.Click += UnsubscribeButton_Click;
            this.CancelButton.Click += CancelButton_Click;
        }

        private void SubscribeButton_Click(object sender, EventArgs e)
        {
            string email = EmailTextBox.Text.Trim();
            string phone = PhoneTextBox.Text.Trim();

            if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Please enter an email or phone number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!string.IsNullOrEmpty(email) && !IsValidEmail(email))
            {
                MessageBox.Show("Invalid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!string.IsNullOrEmpty(phone) && !IsValidPhoneNumber(phone))
            {
                MessageBox.Show("Invalid phone number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!subscribers.ContainsKey(email) && !subscribers.ContainsKey(phone))
            {
                if (!string.IsNullOrEmpty(email))
                {
                    subscribers[email] = "Email";
                }

                if (!string.IsNullOrEmpty(phone))
                {
                    subscribers[phone] = "SMS";
                }

                MessageBox.Show("Subscription added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("This email or phone number is already subscribed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UnsubscribeButton_Click(object sender, EventArgs e)
        {
            string email = EmailTextBox.Text.Trim();
            string phone = PhoneTextBox.Text.Trim();

            if (subscribers.ContainsKey(email))
            {
                subscribers.Remove(email);
                MessageBox.Show("Subscription removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (subscribers.ContainsKey(phone))
            {
                subscribers.Remove(phone);
                MessageBox.Show("Subscription removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("This email or phone number is not subscribed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidPhoneNumber(string phone)
        {
            // Regex for phone numbers that are 10 digits long
            return Regex.IsMatch(phone, @"^\d{10}$");
        }
    }
}

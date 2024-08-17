using System;
using System.Linq;
using System.Windows.Forms;

namespace AniketMonani_COMP212_Sec001_Test02
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnDisplayAll_Click(object sender, EventArgs e)
        {
            using (var context = new BaseballEntities())
            {
                dataGridView1.DataSource = context.Players.ToList();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFirstName.Text) && string.IsNullOrEmpty(txtPlayerID.Text))
            {
                MessageBox.Show("Please enter a First Name or Player ID to search.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var context = new BaseballEntities())
            {
                var query = context.Players.AsQueryable();

                // Search by First Name
                if (!string.IsNullOrEmpty(txtFirstName.Text))
                {
                    txtPlayerID.Clear();  // Clear Player ID if searching by name
                    query = query.Where(p => p.FirstName.Contains(txtFirstName.Text));
                }

                // Search by Player ID
                if (!string.IsNullOrEmpty(txtPlayerID.Text))
                {
                    txtFirstName.Clear();  // Clear First Name if searching by Player ID
                    if (int.TryParse(txtPlayerID.Text, out int playerId))
                    {
                        query = query.Where(p => p.PlayerID == playerId);
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid Player ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Execute the query and bind the results to the DataGridView
                var result = query.ToList();

                if (result.Any())
                {
                    dataGridView1.DataSource = result;
                }
                else
                {
                    MessageBox.Show("No matching records found. Please check your input and try again.", "No Data Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = null;
                }
            }
        }



        private void btnDisplayBattingAverage_Click(object sender, EventArgs e)
        {
            using (var context = new BaseballEntities())
            {
                var average = context.Players.Average(p => p.BattingAverage);
                lblBattingAverage.Text = $"Batting average of all the players\nBatting Average = {average:F3}";
            }
        }


        private void btnHighestBattingScore_Click(object sender, EventArgs e)
        {
            using (var context = new BaseballEntities())
            {
                var topPlayer = context.Players.OrderByDescending(p => p.BattingAverage).FirstOrDefault();
                if (topPlayer != null)
                {
                    lblHighestScore.Text = $"Player with Highest Batting Average is:\nPlayer Name: {topPlayer.FirstName} {topPlayer.LastName}\nBatting Average = {topPlayer.BattingAverage:F3}";
                }
            }
        }


        private void btnAllPlayersBattingAverage_Click(object sender, EventArgs e)
        {
            using (var context = new BaseballEntities())
            {
                var players = context.Players.ToList();
                listBox1.Items.Clear();
                listBox1.Items.Add("List of all Players and Batting Average");
                foreach (var player in players)
                {
                    listBox1.Items.Add($"Player Name: {player.FirstName} {player.LastName}");
                    listBox1.Items.Add($"Batting Average: {player.BattingAverage:F3}");
                    listBox1.Items.Add(""); // Add an empty line for spacing between players
                }
            }
        }


        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtFirstName.Clear();
            txtPlayerID.Clear();
            lblBattingAverage.Text = "";
            lblHighestScore.Text = "";
            listBox1.Items.Clear();
            dataGridView1.DataSource = null;
        }
        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFirstName.Text))
            {
                txtPlayerID.Clear();
            }
        }

        private void txtPlayerID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPlayerID.Text))
            {
                txtFirstName.Clear();
            }
        }




    }
}

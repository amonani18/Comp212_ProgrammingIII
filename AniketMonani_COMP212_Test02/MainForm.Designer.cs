using System;

namespace AniketMonani_COMP212_Sec001_Test02
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtPlayerID = new System.Windows.Forms.TextBox();
            this.btnDisplayAll = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.btnDisplayBattingAverage = new System.Windows.Forms.Button();
            this.btnHighestBattingScore = new System.Windows.Forms.Button();
            this.btnAllPlayersBattingAverage = new System.Windows.Forms.Button();
            this.lblBattingAverage = new System.Windows.Forms.Label();
            this.lblHighestScore = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(10, 10);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(448, 235);
            this.dataGridView1.TabIndex = 0;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(173, 301);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(120, 22);
            this.txtFirstName.TabIndex = 1;
            this.txtFirstName.TextChanged += new System.EventHandler(this.txtFirstName_TextChanged);
            // 
            // txtPlayerID
            // 
            this.txtPlayerID.Location = new System.Drawing.Point(173, 357);
            this.txtPlayerID.Name = "txtPlayerID";
            this.txtPlayerID.Size = new System.Drawing.Size(120, 22);
            this.txtPlayerID.TabIndex = 2;
            this.txtPlayerID.TextChanged += new System.EventHandler(this.txtPlayerID_TextChanged);
            // 
            // btnDisplayAll
            // 
            this.btnDisplayAll.Location = new System.Drawing.Point(328, 297);
            this.btnDisplayAll.Name = "btnDisplayAll";
            this.btnDisplayAll.Size = new System.Drawing.Size(100, 23);
            this.btnDisplayAll.TabIndex = 3;
            this.btnDisplayAll.Text = "Display ALL";
            this.btnDisplayAll.UseVisualStyleBackColor = true;
            this.btnDisplayAll.Click += new System.EventHandler(this.btnDisplayAll_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(328, 357);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.Location = new System.Drawing.Point(486, 326);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(127, 54);
            this.btnClearSearch.TabIndex = 5;
            this.btnClearSearch.Text = "Clear Search";
            this.btnClearSearch.UseVisualStyleBackColor = true;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            // 
            // btnDisplayBattingAverage
            // 
            this.btnDisplayBattingAverage.Location = new System.Drawing.Point(486, 97);
            this.btnDisplayBattingAverage.Name = "btnDisplayBattingAverage";
            this.btnDisplayBattingAverage.Size = new System.Drawing.Size(150, 27);
            this.btnDisplayBattingAverage.TabIndex = 6;
            this.btnDisplayBattingAverage.Text = "Display Batting Average";
            this.btnDisplayBattingAverage.UseVisualStyleBackColor = true;
            this.btnDisplayBattingAverage.Click += new System.EventHandler(this.btnDisplayBattingAverage_Click);
            // 
            // btnHighestBattingScore
            // 
            this.btnHighestBattingScore.Location = new System.Drawing.Point(486, 212);
            this.btnHighestBattingScore.Name = "btnHighestBattingScore";
            this.btnHighestBattingScore.Size = new System.Drawing.Size(150, 33);
            this.btnHighestBattingScore.TabIndex = 7;
            this.btnHighestBattingScore.Text = "Highest Batting Score";
            this.btnHighestBattingScore.UseVisualStyleBackColor = true;
            this.btnHighestBattingScore.Click += new System.EventHandler(this.btnHighestBattingScore_Click);
            // 
            // btnAllPlayersBattingAverage
            // 
            this.btnAllPlayersBattingAverage.Location = new System.Drawing.Point(742, 354);
            this.btnAllPlayersBattingAverage.Name = "btnAllPlayersBattingAverage";
            this.btnAllPlayersBattingAverage.Size = new System.Drawing.Size(150, 23);
            this.btnAllPlayersBattingAverage.TabIndex = 8;
            this.btnAllPlayersBattingAverage.Text = "All Players Batting Average";
            this.btnAllPlayersBattingAverage.UseVisualStyleBackColor = true;
            this.btnAllPlayersBattingAverage.Click += new System.EventHandler(this.btnAllPlayersBattingAverage_Click);
            // 
            // lblBattingAverage
            // 
            this.lblBattingAverage.Location = new System.Drawing.Point(483, 29);
            this.lblBattingAverage.Name = "lblBattingAverage";
            this.lblBattingAverage.Size = new System.Drawing.Size(200, 50);
            this.lblBattingAverage.TabIndex = 15;
            // 
            // lblHighestScore
            // 
            this.lblHighestScore.Location = new System.Drawing.Point(483, 150);
            this.lblHighestScore.Name = "lblHighestScore";
            this.lblHighestScore.Size = new System.Drawing.Size(200, 50);
            this.lblHighestScore.TabIndex = 14;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(707, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(250, 276);
            this.listBox1.TabIndex = 11;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 304);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Search By First Name:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 357);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Search By Player ID:";
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(969, 519);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.lblHighestScore);
            this.Controls.Add(this.lblBattingAverage);
            this.Controls.Add(this.btnAllPlayersBattingAverage);
            this.Controls.Add(this.btnHighestBattingScore);
            this.Controls.Add(this.btnDisplayBattingAverage);
            this.Controls.Add(this.btnClearSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnDisplayAll);
            this.Controls.Add(this.txtPlayerID);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MainForm";
            this.Text = "Display Players";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtPlayerID;
        private System.Windows.Forms.Button btnDisplayAll;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.Button btnDisplayBattingAverage;
        private System.Windows.Forms.Button btnHighestBattingScore;
        private System.Windows.Forms.Button btnAllPlayersBattingAverage;
        private System.Windows.Forms.Label lblBattingAverage;
        private System.Windows.Forms.Label lblHighestScore;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

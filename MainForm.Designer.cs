namespace BMS_Tickets
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.StartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.LoginButton = new System.Windows.Forms.Button();
            this.EndDatePicker = new System.Windows.Forms.DateTimePicker();
            this.WelcomeLabel = new System.Windows.Forms.Label();
            this.DateGroupBox = new System.Windows.Forms.GroupBox();
            this.DateSelectButton = new System.Windows.Forms.Button();
            this.EndDateLabel = new System.Windows.Forms.Label();
            this.StartDateLabel = new System.Windows.Forms.Label();
            this.FldrBrowse = new System.Windows.Forms.FolderBrowserDialog();
            this.DirectoryChoiceGroupBox = new System.Windows.Forms.GroupBox();
            this.ChooseButton = new System.Windows.Forms.Button();
            this.DirectoryChoiceTextbox = new System.Windows.Forms.TextBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.LogGroupBox = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.DateGroupBox.SuspendLayout();
            this.DirectoryChoiceGroupBox.SuspendLayout();
            this.LogGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartDatePicker
            // 
            this.StartDatePicker.Location = new System.Drawing.Point(181, 69);
            this.StartDatePicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StartDatePicker.Name = "StartDatePicker";
            this.StartDatePicker.Size = new System.Drawing.Size(500, 38);
            this.StartDatePicker.TabIndex = 0;
            this.StartDatePicker.Value = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            this.StartDatePicker.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(21, 79);
            this.LoginButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(704, 57);
            this.LoginButton.TabIndex = 1;
            this.LoginButton.Text = "Authenticate";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // EndDatePicker
            // 
            this.EndDatePicker.Location = new System.Drawing.Point(181, 143);
            this.EndDatePicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EndDatePicker.Name = "EndDatePicker";
            this.EndDatePicker.Size = new System.Drawing.Size(500, 38);
            this.EndDatePicker.TabIndex = 4;
            this.EndDatePicker.Value = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            // 
            // WelcomeLabel
            // 
            this.WelcomeLabel.AutoSize = true;
            this.WelcomeLabel.Location = new System.Drawing.Point(16, 14);
            this.WelcomeLabel.Name = "WelcomeLabel";
            this.WelcomeLabel.Size = new System.Drawing.Size(719, 32);
            this.WelcomeLabel.TabIndex = 5;
            this.WelcomeLabel.Text = "Welcome! Please authenticate before trying to continue!";
            // 
            // DateGroupBox
            // 
            this.DateGroupBox.Controls.Add(this.DateSelectButton);
            this.DateGroupBox.Controls.Add(this.EndDateLabel);
            this.DateGroupBox.Controls.Add(this.StartDateLabel);
            this.DateGroupBox.Controls.Add(this.EndDatePicker);
            this.DateGroupBox.Controls.Add(this.StartDatePicker);
            this.DateGroupBox.Location = new System.Drawing.Point(21, 172);
            this.DateGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DateGroupBox.Name = "DateGroupBox";
            this.DateGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DateGroupBox.Size = new System.Drawing.Size(723, 284);
            this.DateGroupBox.TabIndex = 6;
            this.DateGroupBox.TabStop = false;
            this.DateGroupBox.Text = "Select a date range:";
            // 
            // DateSelectButton
            // 
            this.DateSelectButton.Location = new System.Drawing.Point(0, 205);
            this.DateSelectButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DateSelectButton.Name = "DateSelectButton";
            this.DateSelectButton.Size = new System.Drawing.Size(704, 57);
            this.DateSelectButton.TabIndex = 7;
            this.DateSelectButton.Text = "Select Dates";
            this.DateSelectButton.UseVisualStyleBackColor = true;
            this.DateSelectButton.Click += new System.EventHandler(this.DateSelectButton_Click);
            // 
            // EndDateLabel
            // 
            this.EndDateLabel.AutoSize = true;
            this.EndDateLabel.Location = new System.Drawing.Point(75, 148);
            this.EndDateLabel.Name = "EndDateLabel";
            this.EndDateLabel.Size = new System.Drawing.Size(73, 32);
            this.EndDateLabel.TabIndex = 6;
            this.EndDateLabel.Text = "End:";
            // 
            // StartDateLabel
            // 
            this.StartDateLabel.AutoSize = true;
            this.StartDateLabel.Location = new System.Drawing.Point(75, 72);
            this.StartDateLabel.Name = "StartDateLabel";
            this.StartDateLabel.Size = new System.Drawing.Size(82, 32);
            this.StartDateLabel.TabIndex = 5;
            this.StartDateLabel.Text = "Start:";
            // 
            // FldrBrowse
            // 
            this.FldrBrowse.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // DirectoryChoiceGroupBox
            // 
            this.DirectoryChoiceGroupBox.Controls.Add(this.ChooseButton);
            this.DirectoryChoiceGroupBox.Controls.Add(this.DirectoryChoiceTextbox);
            this.DirectoryChoiceGroupBox.Location = new System.Drawing.Point(18, 491);
            this.DirectoryChoiceGroupBox.Name = "DirectoryChoiceGroupBox";
            this.DirectoryChoiceGroupBox.Size = new System.Drawing.Size(725, 143);
            this.DirectoryChoiceGroupBox.TabIndex = 7;
            this.DirectoryChoiceGroupBox.TabStop = false;
            this.DirectoryChoiceGroupBox.Text = "Select a folder:";
            // 
            // ChooseButton
            // 
            this.ChooseButton.Location = new System.Drawing.Point(527, 47);
            this.ChooseButton.Name = "ChooseButton";
            this.ChooseButton.Size = new System.Drawing.Size(179, 57);
            this.ChooseButton.TabIndex = 1;
            this.ChooseButton.Text = "Choose...";
            this.ChooseButton.UseVisualStyleBackColor = true;
            this.ChooseButton.Click += new System.EventHandler(this.ChooseButton_Click);
            // 
            // DirectoryChoiceTextbox
            // 
            this.DirectoryChoiceTextbox.Location = new System.Drawing.Point(24, 58);
            this.DirectoryChoiceTextbox.Name = "DirectoryChoiceTextbox";
            this.DirectoryChoiceTextbox.Size = new System.Drawing.Size(487, 38);
            this.DirectoryChoiceTextbox.TabIndex = 0;
            this.DirectoryChoiceTextbox.Text = "C:\\";
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(22, 663);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(703, 57);
            this.StartButton.TabIndex = 8;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // LogGroupBox
            // 
            this.LogGroupBox.Controls.Add(this.listBox1);
            this.LogGroupBox.Location = new System.Drawing.Point(22, 761);
            this.LogGroupBox.Name = "LogGroupBox";
            this.LogGroupBox.Size = new System.Drawing.Size(721, 317);
            this.LogGroupBox.TabIndex = 9;
            this.LogGroupBox.TabStop = false;
            this.LogGroupBox.Text = "Logs:";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 31;
            this.listBox1.Location = new System.Drawing.Point(20, 55);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(682, 221);
            this.listBox1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 1124);
            this.Controls.Add(this.LogGroupBox);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.DirectoryChoiceGroupBox);
            this.Controls.Add(this.DateGroupBox);
            this.Controls.Add(this.WelcomeLabel);
            this.Controls.Add(this.LoginButton);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "BMS Dashboard Backend";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DateGroupBox.ResumeLayout(false);
            this.DateGroupBox.PerformLayout();
            this.DirectoryChoiceGroupBox.ResumeLayout(false);
            this.DirectoryChoiceGroupBox.PerformLayout();
            this.LogGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker StartDatePicker;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.DateTimePicker EndDatePicker;
        private System.Windows.Forms.Label WelcomeLabel;
        private System.Windows.Forms.GroupBox DateGroupBox;
        private System.Windows.Forms.Label StartDateLabel;
        private System.Windows.Forms.Button DateSelectButton;
        private System.Windows.Forms.Label EndDateLabel;
        private System.Windows.Forms.FolderBrowserDialog FldrBrowse;
        private System.Windows.Forms.GroupBox DirectoryChoiceGroupBox;
        private System.Windows.Forms.Button ChooseButton;
        private System.Windows.Forms.TextBox DirectoryChoiceTextbox;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.GroupBox LogGroupBox;
        private System.Windows.Forms.ListBox listBox1;
    }
}
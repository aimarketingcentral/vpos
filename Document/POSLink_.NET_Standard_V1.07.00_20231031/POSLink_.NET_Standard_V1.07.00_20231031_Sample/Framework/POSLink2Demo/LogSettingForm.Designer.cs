namespace POSLink2Demo
{
    partial class LogSettingForm
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
            this.SetButton = new System.Windows.Forms.Button();
            this.LogLevelComboBox = new System.Windows.Forms.ComboBox();
            this.LogSwitchComboBox = new System.Windows.Forms.ComboBox();
            this.BrowserButton = new System.Windows.Forms.Button();
            this.LogFilePathTextBox = new System.Windows.Forms.TextBox();
            this.LogLevelLabel = new System.Windows.Forms.Label();
            this.LogFilePathLabel = new System.Windows.Forms.Label();
            this.LogSwitchLabel = new System.Windows.Forms.Label();
            this.LogDaysTextBox = new System.Windows.Forms.TextBox();
            this.LogDaysLabel = new System.Windows.Forms.Label();
            this.LogFileNameTextBox = new System.Windows.Forms.TextBox();
            this.LogFileNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SetButton
            // 
            this.SetButton.Location = new System.Drawing.Point(394, 234);
            this.SetButton.Name = "SetButton";
            this.SetButton.Size = new System.Drawing.Size(75, 22);
            this.SetButton.TabIndex = 16;
            this.SetButton.Text = "Set";
            this.SetButton.UseVisualStyleBackColor = true;
            this.SetButton.Click += new System.EventHandler(this.SetButton_Click);
            // 
            // LogLevelComboBox
            // 
            this.LogLevelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LogLevelComboBox.FormattingEnabled = true;
            this.LogLevelComboBox.Items.AddRange(new object[] {
            "ERROR",
            "DEBUG"});
            this.LogLevelComboBox.Location = new System.Drawing.Point(235, 208);
            this.LogLevelComboBox.Name = "LogLevelComboBox";
            this.LogLevelComboBox.Size = new System.Drawing.Size(234, 20);
            this.LogLevelComboBox.TabIndex = 14;
            // 
            // LogSwitchComboBox
            // 
            this.LogSwitchComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LogSwitchComboBox.FormattingEnabled = true;
            this.LogSwitchComboBox.Items.AddRange(new object[] {
            "Off",
            "On"});
            this.LogSwitchComboBox.Location = new System.Drawing.Point(235, 182);
            this.LogSwitchComboBox.Name = "LogSwitchComboBox";
            this.LogSwitchComboBox.Size = new System.Drawing.Size(234, 20);
            this.LogSwitchComboBox.TabIndex = 15;
            // 
            // BrowserButton
            // 
            this.BrowserButton.Location = new System.Drawing.Point(395, 126);
            this.BrowserButton.Name = "BrowserButton";
            this.BrowserButton.Size = new System.Drawing.Size(75, 23);
            this.BrowserButton.TabIndex = 13;
            this.BrowserButton.Text = "Browse";
            this.BrowserButton.UseVisualStyleBackColor = true;
            this.BrowserButton.Click += new System.EventHandler(this.BrowserButton_Click);
            // 
            // LogFilePathTextBox
            // 
            this.LogFilePathTextBox.Location = new System.Drawing.Point(235, 127);
            this.LogFilePathTextBox.Name = "LogFilePathTextBox";
            this.LogFilePathTextBox.Size = new System.Drawing.Size(156, 21);
            this.LogFilePathTextBox.TabIndex = 10;
            // 
            // LogLevelLabel
            // 
            this.LogLevelLabel.AutoSize = true;
            this.LogLevelLabel.Location = new System.Drawing.Point(170, 211);
            this.LogLevelLabel.Name = "LogLevelLabel";
            this.LogLevelLabel.Size = new System.Drawing.Size(59, 12);
            this.LogLevelLabel.TabIndex = 5;
            this.LogLevelLabel.Text = "Log Level";
            // 
            // LogFilePathLabel
            // 
            this.LogFilePathLabel.AutoSize = true;
            this.LogFilePathLabel.Location = new System.Drawing.Point(146, 130);
            this.LogFilePathLabel.Name = "LogFilePathLabel";
            this.LogFilePathLabel.Size = new System.Drawing.Size(83, 12);
            this.LogFilePathLabel.TabIndex = 6;
            this.LogFilePathLabel.Text = "Log File Path";
            // 
            // LogSwitchLabel
            // 
            this.LogSwitchLabel.AutoSize = true;
            this.LogSwitchLabel.Location = new System.Drawing.Point(164, 185);
            this.LogSwitchLabel.Name = "LogSwitchLabel";
            this.LogSwitchLabel.Size = new System.Drawing.Size(65, 12);
            this.LogSwitchLabel.TabIndex = 7;
            this.LogSwitchLabel.Text = "Log Switch";
            // 
            // LogDaysTextBox
            // 
            this.LogDaysTextBox.Location = new System.Drawing.Point(235, 155);
            this.LogDaysTextBox.Name = "LogDaysTextBox";
            this.LogDaysTextBox.Size = new System.Drawing.Size(234, 21);
            this.LogDaysTextBox.TabIndex = 11;
            this.LogDaysTextBox.Text = "30";
            // 
            // LogDaysLabel
            // 
            this.LogDaysLabel.AutoSize = true;
            this.LogDaysLabel.Location = new System.Drawing.Point(176, 158);
            this.LogDaysLabel.Name = "LogDaysLabel";
            this.LogDaysLabel.Size = new System.Drawing.Size(53, 12);
            this.LogDaysLabel.TabIndex = 8;
            this.LogDaysLabel.Text = "Log Days";
            // 
            // LogFileNameTextBox
            // 
            this.LogFileNameTextBox.Location = new System.Drawing.Point(235, 100);
            this.LogFileNameTextBox.Name = "LogFileNameTextBox";
            this.LogFileNameTextBox.Size = new System.Drawing.Size(234, 21);
            this.LogFileNameTextBox.TabIndex = 12;
            this.LogFileNameTextBox.Text = "POSLog";
            // 
            // LogFileNameLabel
            // 
            this.LogFileNameLabel.AutoSize = true;
            this.LogFileNameLabel.Location = new System.Drawing.Point(146, 103);
            this.LogFileNameLabel.Name = "LogFileNameLabel";
            this.LogFileNameLabel.Size = new System.Drawing.Size(83, 12);
            this.LogFileNameLabel.TabIndex = 9;
            this.LogFileNameLabel.Text = "Log File Name";
            // 
            // LogSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 361);
            this.Controls.Add(this.SetButton);
            this.Controls.Add(this.LogLevelComboBox);
            this.Controls.Add(this.LogSwitchComboBox);
            this.Controls.Add(this.BrowserButton);
            this.Controls.Add(this.LogFilePathTextBox);
            this.Controls.Add(this.LogLevelLabel);
            this.Controls.Add(this.LogFilePathLabel);
            this.Controls.Add(this.LogSwitchLabel);
            this.Controls.Add(this.LogDaysTextBox);
            this.Controls.Add(this.LogDaysLabel);
            this.Controls.Add(this.LogFileNameTextBox);
            this.Controls.Add(this.LogFileNameLabel);
            this.Name = "LogSettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Set LogSetting";
            this.Load += new System.EventHandler(this.LogSettingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SetButton;
        private System.Windows.Forms.ComboBox LogLevelComboBox;
        private System.Windows.Forms.ComboBox LogSwitchComboBox;
        private System.Windows.Forms.Button BrowserButton;
        private System.Windows.Forms.TextBox LogFilePathTextBox;
        private System.Windows.Forms.Label LogLevelLabel;
        private System.Windows.Forms.Label LogFilePathLabel;
        private System.Windows.Forms.Label LogSwitchLabel;
        private System.Windows.Forms.TextBox LogDaysTextBox;
        private System.Windows.Forms.Label LogDaysLabel;
        private System.Windows.Forms.TextBox LogFileNameTextBox;
        private System.Windows.Forms.Label LogFileNameLabel;
    }
}
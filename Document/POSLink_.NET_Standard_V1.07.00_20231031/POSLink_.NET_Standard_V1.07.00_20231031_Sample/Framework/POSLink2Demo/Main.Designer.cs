namespace POSLink2Demo
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.label1 = new System.Windows.Forms.Label();
            this.CommunicationTypeLabel = new System.Windows.Forms.Label();
            this.CommunicationTypeComboBox = new System.Windows.Forms.ComboBox();
            this.IpLabel = new System.Windows.Forms.Label();
            this.IpTextBox = new System.Windows.Forms.TextBox();
            this.PortLabel = new System.Windows.Forms.Label();
            this.PortTextBox = new System.Windows.Forms.TextBox();
            this.TomeoutLabel = new System.Windows.Forms.Label();
            this.TimeoutTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SerialPortLabel = new System.Windows.Forms.Label();
            this.SerialPortTextBox = new System.Windows.Forms.TextBox();
            this.BaudRateLabel = new System.Windows.Forms.Label();
            this.BaudRateTextBox = new System.Windows.Forms.TextBox();
            this.SetLogSettingButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(87, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "POSLink2 Demo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CommunicationTypeLabel
            // 
            this.CommunicationTypeLabel.AutoSize = true;
            this.CommunicationTypeLabel.Location = new System.Drawing.Point(91, 90);
            this.CommunicationTypeLabel.Name = "CommunicationTypeLabel";
            this.CommunicationTypeLabel.Size = new System.Drawing.Size(59, 12);
            this.CommunicationTypeLabel.TabIndex = 1;
            this.CommunicationTypeLabel.Text = "Comm Type";
            // 
            // CommunicationTypeComboBox
            // 
            this.CommunicationTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CommunicationTypeComboBox.FormattingEnabled = true;
            this.CommunicationTypeComboBox.Items.AddRange(new object[] {
            "HTTP",
            "HTTPS",
            "SSL",
            "TCP",
            "UART"});
            this.CommunicationTypeComboBox.Location = new System.Drawing.Point(156, 87);
            this.CommunicationTypeComboBox.Name = "CommunicationTypeComboBox";
            this.CommunicationTypeComboBox.Size = new System.Drawing.Size(157, 20);
            this.CommunicationTypeComboBox.TabIndex = 2;
            // 
            // IpLabel
            // 
            this.IpLabel.AutoSize = true;
            this.IpLabel.Location = new System.Drawing.Point(133, 116);
            this.IpLabel.Name = "IpLabel";
            this.IpLabel.Size = new System.Drawing.Size(17, 12);
            this.IpLabel.TabIndex = 3;
            this.IpLabel.Text = "IP";
            // 
            // IpTextBox
            // 
            this.IpTextBox.Location = new System.Drawing.Point(156, 113);
            this.IpTextBox.Name = "IpTextBox";
            this.IpTextBox.Size = new System.Drawing.Size(157, 21);
            this.IpTextBox.TabIndex = 4;
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Location = new System.Drawing.Point(121, 143);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(29, 12);
            this.PortLabel.TabIndex = 3;
            this.PortLabel.Text = "Port";
            // 
            // PortTextBox
            // 
            this.PortTextBox.Location = new System.Drawing.Point(156, 140);
            this.PortTextBox.Name = "PortTextBox";
            this.PortTextBox.Size = new System.Drawing.Size(157, 21);
            this.PortTextBox.TabIndex = 4;
            // 
            // TomeoutLabel
            // 
            this.TomeoutLabel.AutoSize = true;
            this.TomeoutLabel.Location = new System.Drawing.Point(103, 224);
            this.TomeoutLabel.Name = "TomeoutLabel";
            this.TomeoutLabel.Size = new System.Drawing.Size(47, 12);
            this.TomeoutLabel.TabIndex = 3;
            this.TomeoutLabel.Text = "Timeout";
            // 
            // TimeoutTextBox
            // 
            this.TimeoutTextBox.Location = new System.Drawing.Point(156, 221);
            this.TimeoutTextBox.Name = "TimeoutTextBox";
            this.TimeoutTextBox.Size = new System.Drawing.Size(157, 21);
            this.TimeoutTextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(319, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "ms";
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(93, 276);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(110, 22);
            this.OkButton.TabIndex = 6;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(226, 276);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(110, 22);
            this.CancelButton.TabIndex = 6;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SerialPortLabel
            // 
            this.SerialPortLabel.AutoSize = true;
            this.SerialPortLabel.Location = new System.Drawing.Point(79, 170);
            this.SerialPortLabel.Name = "SerialPortLabel";
            this.SerialPortLabel.Size = new System.Drawing.Size(71, 12);
            this.SerialPortLabel.TabIndex = 3;
            this.SerialPortLabel.Text = "Serial Port";
            // 
            // SerialPortTextBox
            // 
            this.SerialPortTextBox.Location = new System.Drawing.Point(156, 167);
            this.SerialPortTextBox.Name = "SerialPortTextBox";
            this.SerialPortTextBox.Size = new System.Drawing.Size(157, 21);
            this.SerialPortTextBox.TabIndex = 4;
            // 
            // BaudRateLabel
            // 
            this.BaudRateLabel.AutoSize = true;
            this.BaudRateLabel.Location = new System.Drawing.Point(91, 197);
            this.BaudRateLabel.Name = "BaudRateLabel";
            this.BaudRateLabel.Size = new System.Drawing.Size(59, 12);
            this.BaudRateLabel.TabIndex = 3;
            this.BaudRateLabel.Text = "Baud Rate";
            // 
            // BaudRateTextBox
            // 
            this.BaudRateTextBox.Location = new System.Drawing.Point(156, 194);
            this.BaudRateTextBox.Name = "BaudRateTextBox";
            this.BaudRateTextBox.Size = new System.Drawing.Size(157, 21);
            this.BaudRateTextBox.TabIndex = 4;
            // 
            // SetLogSettingButton
            // 
            this.SetLogSettingButton.Location = new System.Drawing.Point(156, 248);
            this.SetLogSettingButton.Name = "SetLogSettingButton";
            this.SetLogSettingButton.Size = new System.Drawing.Size(157, 22);
            this.SetLogSettingButton.TabIndex = 6;
            this.SetLogSettingButton.Text = "Set LogSetting";
            this.SetLogSettingButton.UseVisualStyleBackColor = true;
            this.SetLogSettingButton.Click += new System.EventHandler(this.SetLogSettingButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 324);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SetLogSettingButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TimeoutTextBox);
            this.Controls.Add(this.TomeoutLabel);
            this.Controls.Add(this.BaudRateTextBox);
            this.Controls.Add(this.BaudRateLabel);
            this.Controls.Add(this.PortTextBox);
            this.Controls.Add(this.SerialPortTextBox);
            this.Controls.Add(this.PortLabel);
            this.Controls.Add(this.SerialPortLabel);
            this.Controls.Add(this.IpTextBox);
            this.Controls.Add(this.IpLabel);
            this.Controls.Add(this.CommunicationTypeComboBox);
            this.Controls.Add(this.CommunicationTypeLabel);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "POSLink2Demo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label CommunicationTypeLabel;
        private System.Windows.Forms.ComboBox CommunicationTypeComboBox;
        private System.Windows.Forms.Label IpLabel;
        private System.Windows.Forms.TextBox IpTextBox;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.TextBox PortTextBox;
        private System.Windows.Forms.Label TomeoutLabel;
        private System.Windows.Forms.TextBox TimeoutTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label SerialPortLabel;
        private System.Windows.Forms.TextBox SerialPortTextBox;
        private System.Windows.Forms.Label BaudRateLabel;
        private System.Windows.Forms.TextBox BaudRateTextBox;
        private System.Windows.Forms.Button SetLogSettingButton;
    }
}
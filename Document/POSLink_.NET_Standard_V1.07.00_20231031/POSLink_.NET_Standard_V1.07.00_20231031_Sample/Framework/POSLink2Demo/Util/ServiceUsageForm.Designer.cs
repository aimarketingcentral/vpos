namespace POSLink2Demo
{
    partial class ServiceUsageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServiceUsageForm));
            this.AddButton = new System.Windows.Forms.Button();
            this.ServiceStateLabel = new System.Windows.Forms.Label();
            this.ServiceUsageIDLabel = new System.Windows.Forms.Label();
            this.ServiceStateComboBox = new System.Windows.Forms.ComboBox();
            this.ServiceUsageIDTextBox = new System.Windows.Forms.TextBox();
            this.ServiceTitleTextBox = new System.Windows.Forms.TextBox();
            this.ServiceTitleLabel = new System.Windows.Forms.Label();
            this.ServiceDescribeTextBox = new System.Windows.Forms.TextBox();
            this.ServiceDescribeLabel = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(161, 109);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(113, 21);
            this.AddButton.TabIndex = 340;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // ServiceStateLabel
            // 
            this.ServiceStateLabel.Location = new System.Drawing.Point(0, 27);
            this.ServiceStateLabel.Name = "ServiceStateLabel";
            this.ServiceStateLabel.Size = new System.Drawing.Size(113, 22);
            this.ServiceStateLabel.TabIndex = 333;
            this.ServiceStateLabel.Text = "Service State";
            this.ServiceStateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ServiceUsageIDLabel
            // 
            this.ServiceUsageIDLabel.Location = new System.Drawing.Point(0, 2);
            this.ServiceUsageIDLabel.Name = "ServiceUsageIDLabel";
            this.ServiceUsageIDLabel.Size = new System.Drawing.Size(113, 22);
            this.ServiceUsageIDLabel.TabIndex = 331;
            this.ServiceUsageIDLabel.Text = "Service Usage ID";
            this.ServiceUsageIDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ServiceStateComboBox
            // 
            this.ServiceStateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ServiceStateComboBox.FormattingEnabled = true;
            this.ServiceStateComboBox.Items.AddRange(new object[] {
            "Unspecified",
            "Success",
            "Invalid format",
            "Invalid value"});
            this.ServiceStateComboBox.Location = new System.Drawing.Point(115, 29);
            this.ServiceStateComboBox.Name = "ServiceStateComboBox";
            this.ServiceStateComboBox.Size = new System.Drawing.Size(272, 20);
            this.ServiceStateComboBox.TabIndex = 334;
            // 
            // ServiceUsageIDTextBox
            // 
            this.ServiceUsageIDTextBox.Location = new System.Drawing.Point(115, 2);
            this.ServiceUsageIDTextBox.Name = "ServiceUsageIDTextBox";
            this.ServiceUsageIDTextBox.Size = new System.Drawing.Size(272, 21);
            this.ServiceUsageIDTextBox.TabIndex = 332;
            // 
            // ServiceTitleTextBox
            // 
            this.ServiceTitleTextBox.Location = new System.Drawing.Point(115, 55);
            this.ServiceTitleTextBox.Name = "ServiceTitleTextBox";
            this.ServiceTitleTextBox.Size = new System.Drawing.Size(272, 21);
            this.ServiceTitleTextBox.TabIndex = 332;
            // 
            // ServiceTitleLabel
            // 
            this.ServiceTitleLabel.Location = new System.Drawing.Point(0, 55);
            this.ServiceTitleLabel.Name = "ServiceTitleLabel";
            this.ServiceTitleLabel.Size = new System.Drawing.Size(113, 22);
            this.ServiceTitleLabel.TabIndex = 331;
            this.ServiceTitleLabel.Text = "Service Title";
            this.ServiceTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ServiceDescribeTextBox
            // 
            this.ServiceDescribeTextBox.Location = new System.Drawing.Point(115, 82);
            this.ServiceDescribeTextBox.Name = "ServiceDescribeTextBox";
            this.ServiceDescribeTextBox.Size = new System.Drawing.Size(272, 21);
            this.ServiceDescribeTextBox.TabIndex = 332;
            // 
            // ServiceDescribeLabel
            // 
            this.ServiceDescribeLabel.Location = new System.Drawing.Point(0, 82);
            this.ServiceDescribeLabel.Name = "ServiceDescribeLabel";
            this.ServiceDescribeLabel.Size = new System.Drawing.Size(113, 22);
            this.ServiceDescribeLabel.TabIndex = 331;
            this.ServiceDescribeLabel.Text = "Service Describe";
            this.ServiceDescribeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(280, 109);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(107, 21);
            this.CancelButton.TabIndex = 340;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ServiceUsageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 137);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.ServiceStateLabel);
            this.Controls.Add(this.ServiceDescribeLabel);
            this.Controls.Add(this.ServiceTitleLabel);
            this.Controls.Add(this.ServiceUsageIDLabel);
            this.Controls.Add(this.ServiceStateComboBox);
            this.Controls.Add(this.ServiceDescribeTextBox);
            this.Controls.Add(this.ServiceTitleTextBox);
            this.Controls.Add(this.ServiceUsageIDTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ServiceUsageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ServiceUsage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Label ServiceStateLabel;
        private System.Windows.Forms.Label ServiceUsageIDLabel;
        private System.Windows.Forms.ComboBox ServiceStateComboBox;
        private System.Windows.Forms.TextBox ServiceUsageIDTextBox;
        private System.Windows.Forms.TextBox ServiceTitleTextBox;
        private System.Windows.Forms.Label ServiceTitleLabel;
        private System.Windows.Forms.TextBox ServiceDescribeTextBox;
        private System.Windows.Forms.Label ServiceDescribeLabel;
        private System.Windows.Forms.Button CancelButton;
    }
}
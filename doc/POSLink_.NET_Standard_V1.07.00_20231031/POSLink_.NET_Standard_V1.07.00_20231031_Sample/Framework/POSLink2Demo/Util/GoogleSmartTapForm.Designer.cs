namespace POSLink2Demo
{
    partial class GoogleSmartTapForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GoogleSmartTapForm));
            this.CancelButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.CvmCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.CvmLabel = new System.Windows.Forms.Label();
            this.CheckoutCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.CheckoutLabel = new System.Windows.Forms.Label();
            this.UiCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.UiLabel = new System.Windows.Forms.Label();
            this.SystemCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.SystemLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(433, 185);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 19;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(352, 185);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 18;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CvmCheckedListBox
            // 
            this.CvmCheckedListBox.CheckOnClick = true;
            this.CvmCheckedListBox.FormattingEnabled = true;
            this.CvmCheckedListBox.Items.AddRange(new object[] {
            "Online PIN",
            "CD PIN",
            "Signature",
            "No CVM",
            "Device-generated code",
            "SP-generated code",
            "ID capture",
            "Bio-metric"});
            this.CvmCheckedListBox.Location = new System.Drawing.Point(389, 25);
            this.CvmCheckedListBox.Name = "CvmCheckedListBox";
            this.CvmCheckedListBox.Size = new System.Drawing.Size(120, 148);
            this.CvmCheckedListBox.TabIndex = 17;
            // 
            // CvmLabel
            // 
            this.CvmLabel.AutoSize = true;
            this.CvmLabel.Location = new System.Drawing.Point(437, 6);
            this.CvmLabel.Name = "CvmLabel";
            this.CvmLabel.Size = new System.Drawing.Size(23, 12);
            this.CvmLabel.TabIndex = 16;
            this.CvmLabel.Text = "CVM";
            // 
            // CheckoutCheckedListBox
            // 
            this.CheckoutCheckedListBox.CheckOnClick = true;
            this.CheckoutCheckedListBox.FormattingEnabled = true;
            this.CheckoutCheckedListBox.Items.AddRange(new object[] {
            "Support payment",
            "Support digital receipt",
            "Support service issuance",
            "Support OTA POSData"});
            this.CheckoutCheckedListBox.Location = new System.Drawing.Point(261, 25);
            this.CheckoutCheckedListBox.Name = "CheckoutCheckedListBox";
            this.CheckoutCheckedListBox.Size = new System.Drawing.Size(120, 148);
            this.CheckoutCheckedListBox.TabIndex = 15;
            // 
            // CheckoutLabel
            // 
            this.CheckoutLabel.AutoSize = true;
            this.CheckoutLabel.Location = new System.Drawing.Point(293, 6);
            this.CheckoutLabel.Name = "CheckoutLabel";
            this.CheckoutLabel.Size = new System.Drawing.Size(53, 12);
            this.CheckoutLabel.TabIndex = 14;
            this.CheckoutLabel.Text = "Checkout";
            // 
            // UiCheckedListBox
            // 
            this.UiCheckedListBox.CheckOnClick = true;
            this.UiCheckedListBox.FormattingEnabled = true;
            this.UiCheckedListBox.Items.AddRange(new object[] {
            "Printer",
            "Printer Graphics",
            "Display",
            "Images",
            "Audio",
            "Animation",
            "Video"});
            this.UiCheckedListBox.Location = new System.Drawing.Point(135, 25);
            this.UiCheckedListBox.Name = "UiCheckedListBox";
            this.UiCheckedListBox.Size = new System.Drawing.Size(120, 148);
            this.UiCheckedListBox.TabIndex = 13;
            // 
            // UiLabel
            // 
            this.UiLabel.AutoSize = true;
            this.UiLabel.Location = new System.Drawing.Point(188, 6);
            this.UiLabel.Name = "UiLabel";
            this.UiLabel.Size = new System.Drawing.Size(17, 12);
            this.UiLabel.TabIndex = 12;
            this.UiLabel.Text = "UI";
            // 
            // SystemCheckedListBox
            // 
            this.SystemCheckedListBox.CheckOnClick = true;
            this.SystemCheckedListBox.FormattingEnabled = true;
            this.SystemCheckedListBox.Items.AddRange(new object[] {
            "Stand-alone",
            "Semi-integrated",
            "Unattended",
            "Online",
            "Offline",
            "MMP",
            "zlib support"});
            this.SystemCheckedListBox.Location = new System.Drawing.Point(9, 25);
            this.SystemCheckedListBox.Name = "SystemCheckedListBox";
            this.SystemCheckedListBox.Size = new System.Drawing.Size(120, 148);
            this.SystemCheckedListBox.TabIndex = 11;
            // 
            // SystemLabel
            // 
            this.SystemLabel.AutoSize = true;
            this.SystemLabel.Location = new System.Drawing.Point(47, 6);
            this.SystemLabel.Name = "SystemLabel";
            this.SystemLabel.Size = new System.Drawing.Size(41, 12);
            this.SystemLabel.TabIndex = 10;
            this.SystemLabel.Text = "System";
            // 
            // GoogleSmartTapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 220);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.CvmCheckedListBox);
            this.Controls.Add(this.CvmLabel);
            this.Controls.Add(this.CheckoutCheckedListBox);
            this.Controls.Add(this.CheckoutLabel);
            this.Controls.Add(this.UiCheckedListBox);
            this.Controls.Add(this.UiLabel);
            this.Controls.Add(this.SystemCheckedListBox);
            this.Controls.Add(this.SystemLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GoogleSmartTapForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GoogleSmartTap";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.CheckedListBox CvmCheckedListBox;
        private System.Windows.Forms.Label CvmLabel;
        private System.Windows.Forms.CheckedListBox CheckoutCheckedListBox;
        private System.Windows.Forms.Label CheckoutLabel;
        private System.Windows.Forms.CheckedListBox UiCheckedListBox;
        private System.Windows.Forms.Label UiLabel;
        private System.Windows.Forms.CheckedListBox SystemCheckedListBox;
        private System.Windows.Forms.Label SystemLabel;
    }
}
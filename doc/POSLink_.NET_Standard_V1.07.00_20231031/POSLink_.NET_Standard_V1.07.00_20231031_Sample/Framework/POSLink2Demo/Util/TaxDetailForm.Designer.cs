namespace POSLink2Demo
{
    partial class TaxDetailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaxDetailForm));
            this.TaxTypeLabel = new System.Windows.Forms.Label();
            this.TaxAmountLabel = new System.Windows.Forms.Label();
            this.TaxAmountTextBox = new System.Windows.Forms.TextBox();
            this.TaxRateLabel = new System.Windows.Forms.Label();
            this.TaxRateTextBox = new System.Windows.Forms.TextBox();
            this.MerchantTaxIdLabel = new System.Windows.Forms.Label();
            this.MerchantTaxIdTextBox = new System.Windows.Forms.TextBox();
            this.CustomerTaxIdLabel = new System.Windows.Forms.Label();
            this.CustomerTaxIdTextBox = new System.Windows.Forms.TextBox();
            this.ValueAddedTaxInvoiceNumberLabel = new System.Windows.Forms.Label();
            this.ValueAddedTaxInvoiceNumberTextBox = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.TaxTypeComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // TaxTypeLabel
            // 
            this.TaxTypeLabel.AutoSize = true;
            this.TaxTypeLabel.Location = new System.Drawing.Point(48, 9);
            this.TaxTypeLabel.Name = "TaxTypeLabel";
            this.TaxTypeLabel.Size = new System.Drawing.Size(47, 12);
            this.TaxTypeLabel.TabIndex = 0;
            this.TaxTypeLabel.Text = "TaxType";
            // 
            // TaxAmountLabel
            // 
            this.TaxAmountLabel.AutoSize = true;
            this.TaxAmountLabel.Location = new System.Drawing.Point(36, 36);
            this.TaxAmountLabel.Name = "TaxAmountLabel";
            this.TaxAmountLabel.Size = new System.Drawing.Size(59, 12);
            this.TaxAmountLabel.TabIndex = 0;
            this.TaxAmountLabel.Text = "TaxAmount";
            // 
            // TaxAmountTextBox
            // 
            this.TaxAmountTextBox.Location = new System.Drawing.Point(101, 33);
            this.TaxAmountTextBox.Name = "TaxAmountTextBox";
            this.TaxAmountTextBox.Size = new System.Drawing.Size(208, 21);
            this.TaxAmountTextBox.TabIndex = 1;
            // 
            // TaxRateLabel
            // 
            this.TaxRateLabel.AutoSize = true;
            this.TaxRateLabel.Location = new System.Drawing.Point(48, 63);
            this.TaxRateLabel.Name = "TaxRateLabel";
            this.TaxRateLabel.Size = new System.Drawing.Size(47, 12);
            this.TaxRateLabel.TabIndex = 0;
            this.TaxRateLabel.Text = "TaxRate";
            // 
            // TaxRateTextBox
            // 
            this.TaxRateTextBox.Location = new System.Drawing.Point(101, 60);
            this.TaxRateTextBox.Name = "TaxRateTextBox";
            this.TaxRateTextBox.Size = new System.Drawing.Size(208, 21);
            this.TaxRateTextBox.TabIndex = 1;
            // 
            // MerchantTaxIdLabel
            // 
            this.MerchantTaxIdLabel.AutoSize = true;
            this.MerchantTaxIdLabel.Location = new System.Drawing.Point(12, 90);
            this.MerchantTaxIdLabel.Name = "MerchantTaxIdLabel";
            this.MerchantTaxIdLabel.Size = new System.Drawing.Size(83, 12);
            this.MerchantTaxIdLabel.TabIndex = 0;
            this.MerchantTaxIdLabel.Text = "MerchantTaxId";
            // 
            // MerchantTaxIdTextBox
            // 
            this.MerchantTaxIdTextBox.Location = new System.Drawing.Point(101, 87);
            this.MerchantTaxIdTextBox.Name = "MerchantTaxIdTextBox";
            this.MerchantTaxIdTextBox.Size = new System.Drawing.Size(208, 21);
            this.MerchantTaxIdTextBox.TabIndex = 1;
            // 
            // CustomerTaxIdLabel
            // 
            this.CustomerTaxIdLabel.AutoSize = true;
            this.CustomerTaxIdLabel.Location = new System.Drawing.Point(12, 117);
            this.CustomerTaxIdLabel.Name = "CustomerTaxIdLabel";
            this.CustomerTaxIdLabel.Size = new System.Drawing.Size(83, 12);
            this.CustomerTaxIdLabel.TabIndex = 0;
            this.CustomerTaxIdLabel.Text = "CustomerTaxId";
            // 
            // CustomerTaxIdTextBox
            // 
            this.CustomerTaxIdTextBox.Location = new System.Drawing.Point(101, 114);
            this.CustomerTaxIdTextBox.Name = "CustomerTaxIdTextBox";
            this.CustomerTaxIdTextBox.Size = new System.Drawing.Size(208, 21);
            this.CustomerTaxIdTextBox.TabIndex = 1;
            // 
            // ValueAddedTaxInvoiceNumberLabel
            // 
            this.ValueAddedTaxInvoiceNumberLabel.AutoSize = true;
            this.ValueAddedTaxInvoiceNumberLabel.Location = new System.Drawing.Point(11, 144);
            this.ValueAddedTaxInvoiceNumberLabel.Name = "ValueAddedTaxInvoiceNumberLabel";
            this.ValueAddedTaxInvoiceNumberLabel.Size = new System.Drawing.Size(161, 12);
            this.ValueAddedTaxInvoiceNumberLabel.TabIndex = 0;
            this.ValueAddedTaxInvoiceNumberLabel.Text = "ValueAddedTaxInvoiceNumber";
            // 
            // ValueAddedTaxInvoiceNumberTextBox
            // 
            this.ValueAddedTaxInvoiceNumberTextBox.Location = new System.Drawing.Point(178, 141);
            this.ValueAddedTaxInvoiceNumberTextBox.Name = "ValueAddedTaxInvoiceNumberTextBox";
            this.ValueAddedTaxInvoiceNumberTextBox.Size = new System.Drawing.Size(131, 21);
            this.ValueAddedTaxInvoiceNumberTextBox.TabIndex = 1;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(101, 174);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(103, 23);
            this.AddButton.TabIndex = 2;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(206, 174);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(103, 23);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // TaxTypeComboBox
            // 
            this.TaxTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TaxTypeComboBox.FormattingEnabled = true;
            this.TaxTypeComboBox.Items.AddRange(new object[] {
            "Unknown",
            "Federal/National Sales Tax (total and sub)",
            "State Sales Tax",
            "City Sales Tax",
            "Local Sales Tax / Local Tax/Sales Tax(see note)",
            "Municipal Sales Tax",
            "Duty Tax",
            "Value Added Tax (VAT) / Alternate Tax",
            "Goods and Services Tax (GST)",
            "Provincial Sales Tax (PST)",
            "Room Tax",
            "Occupancy Tax",
            "Energy Tax"});
            this.TaxTypeComboBox.Location = new System.Drawing.Point(101, 6);
            this.TaxTypeComboBox.Name = "TaxTypeComboBox";
            this.TaxTypeComboBox.Size = new System.Drawing.Size(208, 20);
            this.TaxTypeComboBox.TabIndex = 3;
            // 
            // TaxDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 210);
            this.Controls.Add(this.TaxTypeComboBox);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.ValueAddedTaxInvoiceNumberTextBox);
            this.Controls.Add(this.ValueAddedTaxInvoiceNumberLabel);
            this.Controls.Add(this.CustomerTaxIdTextBox);
            this.Controls.Add(this.CustomerTaxIdLabel);
            this.Controls.Add(this.MerchantTaxIdTextBox);
            this.Controls.Add(this.MerchantTaxIdLabel);
            this.Controls.Add(this.TaxRateTextBox);
            this.Controls.Add(this.TaxRateLabel);
            this.Controls.Add(this.TaxAmountTextBox);
            this.Controls.Add(this.TaxAmountLabel);
            this.Controls.Add(this.TaxTypeLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TaxDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TaxDetail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TaxTypeLabel;
        private System.Windows.Forms.Label TaxAmountLabel;
        private System.Windows.Forms.TextBox TaxAmountTextBox;
        private System.Windows.Forms.Label TaxRateLabel;
        private System.Windows.Forms.TextBox TaxRateTextBox;
        private System.Windows.Forms.Label MerchantTaxIdLabel;
        private System.Windows.Forms.TextBox MerchantTaxIdTextBox;
        private System.Windows.Forms.Label CustomerTaxIdLabel;
        private System.Windows.Forms.TextBox CustomerTaxIdTextBox;
        private System.Windows.Forms.Label ValueAddedTaxInvoiceNumberLabel;
        private System.Windows.Forms.TextBox ValueAddedTaxInvoiceNumberTextBox;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.ComboBox TaxTypeComboBox;
    }
}
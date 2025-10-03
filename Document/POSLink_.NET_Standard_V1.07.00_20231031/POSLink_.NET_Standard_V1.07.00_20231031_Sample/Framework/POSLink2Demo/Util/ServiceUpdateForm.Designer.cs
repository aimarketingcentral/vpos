namespace POSLink2Demo
{
    partial class ServiceUpdateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServiceUpdateForm));
            this.UpdateIDTextBox = new System.Windows.Forms.TextBox();
            this.UpdateIDLabel = new System.Windows.Forms.Label();
            this.UpdateOperationLabel = new System.Windows.Forms.Label();
            this.UpdateOperationComboBox = new System.Windows.Forms.ComboBox();
            this.UpdatePayloadTextBox = new System.Windows.Forms.TextBox();
            this.UpdatePayloadLabel = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UpdateIDTextBox
            // 
            this.UpdateIDTextBox.Location = new System.Drawing.Point(115, 3);
            this.UpdateIDTextBox.Name = "UpdateIDTextBox";
            this.UpdateIDTextBox.Size = new System.Drawing.Size(272, 21);
            this.UpdateIDTextBox.TabIndex = 341;
            // 
            // UpdateIDLabel
            // 
            this.UpdateIDLabel.Location = new System.Drawing.Point(0, 2);
            this.UpdateIDLabel.Name = "UpdateIDLabel";
            this.UpdateIDLabel.Size = new System.Drawing.Size(113, 21);
            this.UpdateIDLabel.TabIndex = 340;
            this.UpdateIDLabel.Text = "Update ID";
            this.UpdateIDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UpdateOperationLabel
            // 
            this.UpdateOperationLabel.Location = new System.Drawing.Point(0, 29);
            this.UpdateOperationLabel.Name = "UpdateOperationLabel";
            this.UpdateOperationLabel.Size = new System.Drawing.Size(113, 21);
            this.UpdateOperationLabel.TabIndex = 336;
            this.UpdateOperationLabel.Text = "Update Operation";
            this.UpdateOperationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UpdateOperationComboBox
            // 
            this.UpdateOperationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UpdateOperationComboBox.FormattingEnabled = true;
            this.UpdateOperationComboBox.Items.AddRange(new object[] {
            "No operation",
            "Remove service object",
            "Set balance",
            "Add balance",
            "Subtract balance",
            "Free"});
            this.UpdateOperationComboBox.Location = new System.Drawing.Point(115, 30);
            this.UpdateOperationComboBox.Name = "UpdateOperationComboBox";
            this.UpdateOperationComboBox.Size = new System.Drawing.Size(272, 20);
            this.UpdateOperationComboBox.TabIndex = 337;
            // 
            // UpdatePayloadTextBox
            // 
            this.UpdatePayloadTextBox.Location = new System.Drawing.Point(115, 56);
            this.UpdatePayloadTextBox.Name = "UpdatePayloadTextBox";
            this.UpdatePayloadTextBox.Size = new System.Drawing.Size(272, 21);
            this.UpdatePayloadTextBox.TabIndex = 339;
            // 
            // UpdatePayloadLabel
            // 
            this.UpdatePayloadLabel.Location = new System.Drawing.Point(0, 55);
            this.UpdatePayloadLabel.Name = "UpdatePayloadLabel";
            this.UpdatePayloadLabel.Size = new System.Drawing.Size(113, 21);
            this.UpdatePayloadLabel.TabIndex = 338;
            this.UpdatePayloadLabel.Text = "Update Payload";
            this.UpdatePayloadLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(271, 83);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(116, 20);
            this.CancelButton.TabIndex = 342;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(146, 83);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(119, 20);
            this.AddButton.TabIndex = 343;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // ServiceUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 111);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.UpdateIDTextBox);
            this.Controls.Add(this.UpdateIDLabel);
            this.Controls.Add(this.UpdateOperationLabel);
            this.Controls.Add(this.UpdateOperationComboBox);
            this.Controls.Add(this.UpdatePayloadTextBox);
            this.Controls.Add(this.UpdatePayloadLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ServiceUpdateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ServiceUpdate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UpdateIDTextBox;
        private System.Windows.Forms.Label UpdateIDLabel;
        private System.Windows.Forms.Label UpdateOperationLabel;
        private System.Windows.Forms.ComboBox UpdateOperationComboBox;
        private System.Windows.Forms.TextBox UpdatePayloadTextBox;
        private System.Windows.Forms.Label UpdatePayloadLabel;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button AddButton;
    }
}
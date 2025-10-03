namespace POSLink2Demo
{
    partial class EwicUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.RetMessageListBox = new System.Windows.Forms.ListBox();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.UpcQtyTextBox = new System.Windows.Forms.TextBox();
            this.UpcQtyLabel = new System.Windows.Forms.Label();
            this.UpcPriceTextBox = new System.Windows.Forms.TextBox();
            this.UpcPriceLabel = new System.Windows.Forms.Label();
            this.UpcPluDataTextBox = new System.Windows.Forms.TextBox();
            this.UpcPluDataLabel = new System.Windows.Forms.Label();
            this.UpcPluIndTextBox = new System.Windows.Forms.TextBox();
            this.UpcPluIndLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RetMessageListBox
            // 
            this.RetMessageListBox.FormattingEnabled = true;
            this.RetMessageListBox.ItemHeight = 12;
            this.RetMessageListBox.Location = new System.Drawing.Point(5, 108);
            this.RetMessageListBox.Name = "RetMessageListBox";
            this.RetMessageListBox.ScrollAlwaysVisible = true;
            this.RetMessageListBox.Size = new System.Drawing.Size(305, 136);
            this.RetMessageListBox.TabIndex = 17;
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(235, 249);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveButton.TabIndex = 15;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(154, 249);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 16;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // UpcQtyTextBox
            // 
            this.UpcQtyTextBox.Location = new System.Drawing.Point(103, 81);
            this.UpcQtyTextBox.Name = "UpcQtyTextBox";
            this.UpcQtyTextBox.Size = new System.Drawing.Size(206, 21);
            this.UpcQtyTextBox.TabIndex = 11;
            // 
            // UpcQtyLabel
            // 
            this.UpcQtyLabel.AutoSize = true;
            this.UpcQtyLabel.Location = new System.Drawing.Point(50, 84);
            this.UpcQtyLabel.Name = "UpcQtyLabel";
            this.UpcQtyLabel.Size = new System.Drawing.Size(47, 12);
            this.UpcQtyLabel.TabIndex = 6;
            this.UpcQtyLabel.Text = "UPC Qty";
            // 
            // UpcPriceTextBox
            // 
            this.UpcPriceTextBox.Location = new System.Drawing.Point(103, 54);
            this.UpcPriceTextBox.Name = "UpcPriceTextBox";
            this.UpcPriceTextBox.Size = new System.Drawing.Size(206, 21);
            this.UpcPriceTextBox.TabIndex = 12;
            // 
            // UpcPriceLabel
            // 
            this.UpcPriceLabel.AutoSize = true;
            this.UpcPriceLabel.Location = new System.Drawing.Point(38, 57);
            this.UpcPriceLabel.Name = "UpcPriceLabel";
            this.UpcPriceLabel.Size = new System.Drawing.Size(59, 12);
            this.UpcPriceLabel.TabIndex = 7;
            this.UpcPriceLabel.Text = "UPC Price";
            // 
            // UpcPluDataTextBox
            // 
            this.UpcPluDataTextBox.Location = new System.Drawing.Point(103, 27);
            this.UpcPluDataTextBox.Name = "UpcPluDataTextBox";
            this.UpcPluDataTextBox.Size = new System.Drawing.Size(206, 21);
            this.UpcPluDataTextBox.TabIndex = 13;
            // 
            // UpcPluDataLabel
            // 
            this.UpcPluDataLabel.AutoSize = true;
            this.UpcPluDataLabel.Location = new System.Drawing.Point(20, 30);
            this.UpcPluDataLabel.Name = "UpcPluDataLabel";
            this.UpcPluDataLabel.Size = new System.Drawing.Size(77, 12);
            this.UpcPluDataLabel.TabIndex = 8;
            this.UpcPluDataLabel.Text = "UPC PLU Data";
            // 
            // UpcPluIndTextBox
            // 
            this.UpcPluIndTextBox.Location = new System.Drawing.Point(103, 0);
            this.UpcPluIndTextBox.Name = "UpcPluIndTextBox";
            this.UpcPluIndTextBox.Size = new System.Drawing.Size(206, 21);
            this.UpcPluIndTextBox.TabIndex = 14;
            // 
            // UpcPluIndLabel
            // 
            this.UpcPluIndLabel.AutoSize = true;
            this.UpcPluIndLabel.Location = new System.Drawing.Point(26, 3);
            this.UpcPluIndLabel.Name = "UpcPluIndLabel";
            this.UpcPluIndLabel.Size = new System.Drawing.Size(71, 12);
            this.UpcPluIndLabel.TabIndex = 9;
            this.UpcPluIndLabel.Text = "UPC PLU Ind";
            // 
            // EwicUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RetMessageListBox);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.UpcQtyTextBox);
            this.Controls.Add(this.UpcQtyLabel);
            this.Controls.Add(this.UpcPriceTextBox);
            this.Controls.Add(this.UpcPriceLabel);
            this.Controls.Add(this.UpcPluDataTextBox);
            this.Controls.Add(this.UpcPluDataLabel);
            this.Controls.Add(this.UpcPluIndTextBox);
            this.Controls.Add(this.UpcPluIndLabel);
            this.Name = "EwicUserControl";
            this.Size = new System.Drawing.Size(310, 299);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox RetMessageListBox;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.TextBox UpcQtyTextBox;
        private System.Windows.Forms.Label UpcQtyLabel;
        private System.Windows.Forms.TextBox UpcPriceTextBox;
        private System.Windows.Forms.Label UpcPriceLabel;
        private System.Windows.Forms.TextBox UpcPluDataTextBox;
        private System.Windows.Forms.Label UpcPluDataLabel;
        private System.Windows.Forms.TextBox UpcPluIndTextBox;
        private System.Windows.Forms.Label UpcPluIndLabel;
    }
}

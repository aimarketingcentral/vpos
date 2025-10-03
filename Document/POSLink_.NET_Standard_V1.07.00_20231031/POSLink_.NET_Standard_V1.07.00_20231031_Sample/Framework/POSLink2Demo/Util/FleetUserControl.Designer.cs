namespace POSLink2Demo
{
    partial class FleetUserControl
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
            this.ProductCodeLabel = new System.Windows.Forms.Label();
            this.ProductCodeTextBox = new System.Windows.Forms.TextBox();
            this.ProductAmountLabel = new System.Windows.Forms.Label();
            this.ProductAmountTextBox = new System.Windows.Forms.TextBox();
            this.UnitPriceLabel = new System.Windows.Forms.Label();
            this.UnitPriceTextBox = new System.Windows.Forms.TextBox();
            this.QuantityLabel = new System.Windows.Forms.Label();
            this.QuantityTextBox = new System.Windows.Forms.TextBox();
            this.UnitOfMeasureLabel = new System.Windows.Forms.Label();
            this.UnitOfMeasureTextBox = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.RetMessageListBox = new System.Windows.Forms.ListBox();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ProductCodeLabel
            // 
            this.ProductCodeLabel.AutoSize = true;
            this.ProductCodeLabel.Location = new System.Drawing.Point(21, 3);
            this.ProductCodeLabel.Name = "ProductCodeLabel";
            this.ProductCodeLabel.Size = new System.Drawing.Size(77, 12);
            this.ProductCodeLabel.TabIndex = 0;
            this.ProductCodeLabel.Text = "Product Code";
            // 
            // ProductCodeTextBox
            // 
            this.ProductCodeTextBox.Location = new System.Drawing.Point(104, 0);
            this.ProductCodeTextBox.Name = "ProductCodeTextBox";
            this.ProductCodeTextBox.Size = new System.Drawing.Size(206, 21);
            this.ProductCodeTextBox.TabIndex = 1;
            // 
            // ProductAmountLabel
            // 
            this.ProductAmountLabel.AutoSize = true;
            this.ProductAmountLabel.Location = new System.Drawing.Point(9, 30);
            this.ProductAmountLabel.Name = "ProductAmountLabel";
            this.ProductAmountLabel.Size = new System.Drawing.Size(89, 12);
            this.ProductAmountLabel.TabIndex = 0;
            this.ProductAmountLabel.Text = "Product Amount";
            // 
            // ProductAmountTextBox
            // 
            this.ProductAmountTextBox.Location = new System.Drawing.Point(104, 27);
            this.ProductAmountTextBox.Name = "ProductAmountTextBox";
            this.ProductAmountTextBox.Size = new System.Drawing.Size(206, 21);
            this.ProductAmountTextBox.TabIndex = 1;
            // 
            // UnitPriceLabel
            // 
            this.UnitPriceLabel.AutoSize = true;
            this.UnitPriceLabel.Location = new System.Drawing.Point(33, 57);
            this.UnitPriceLabel.Name = "UnitPriceLabel";
            this.UnitPriceLabel.Size = new System.Drawing.Size(65, 12);
            this.UnitPriceLabel.TabIndex = 0;
            this.UnitPriceLabel.Text = "Unit Price";
            // 
            // UnitPriceTextBox
            // 
            this.UnitPriceTextBox.Location = new System.Drawing.Point(104, 54);
            this.UnitPriceTextBox.Name = "UnitPriceTextBox";
            this.UnitPriceTextBox.Size = new System.Drawing.Size(206, 21);
            this.UnitPriceTextBox.TabIndex = 1;
            // 
            // QuantityLabel
            // 
            this.QuantityLabel.AutoSize = true;
            this.QuantityLabel.Location = new System.Drawing.Point(45, 84);
            this.QuantityLabel.Name = "QuantityLabel";
            this.QuantityLabel.Size = new System.Drawing.Size(53, 12);
            this.QuantityLabel.TabIndex = 0;
            this.QuantityLabel.Text = "Quantity";
            // 
            // QuantityTextBox
            // 
            this.QuantityTextBox.Location = new System.Drawing.Point(104, 81);
            this.QuantityTextBox.Name = "QuantityTextBox";
            this.QuantityTextBox.Size = new System.Drawing.Size(206, 21);
            this.QuantityTextBox.TabIndex = 1;
            // 
            // UnitOfMeasureLabel
            // 
            this.UnitOfMeasureLabel.AutoSize = true;
            this.UnitOfMeasureLabel.Location = new System.Drawing.Point(3, 111);
            this.UnitOfMeasureLabel.Name = "UnitOfMeasureLabel";
            this.UnitOfMeasureLabel.Size = new System.Drawing.Size(95, 12);
            this.UnitOfMeasureLabel.TabIndex = 0;
            this.UnitOfMeasureLabel.Text = "Unit Of Measure";
            // 
            // UnitOfMeasureTextBox
            // 
            this.UnitOfMeasureTextBox.Location = new System.Drawing.Point(104, 108);
            this.UnitOfMeasureTextBox.Name = "UnitOfMeasureTextBox";
            this.UnitOfMeasureTextBox.Size = new System.Drawing.Size(206, 21);
            this.UnitOfMeasureTextBox.TabIndex = 1;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(154, 276);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 3;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // RetMessageListBox
            // 
            this.RetMessageListBox.FormattingEnabled = true;
            this.RetMessageListBox.ItemHeight = 12;
            this.RetMessageListBox.Location = new System.Drawing.Point(5, 135);
            this.RetMessageListBox.Name = "RetMessageListBox";
            this.RetMessageListBox.ScrollAlwaysVisible = true;
            this.RetMessageListBox.Size = new System.Drawing.Size(305, 136);
            this.RetMessageListBox.TabIndex = 4;
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(235, 276);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveButton.TabIndex = 3;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // FleetUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RetMessageListBox);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.UnitOfMeasureTextBox);
            this.Controls.Add(this.UnitOfMeasureLabel);
            this.Controls.Add(this.QuantityTextBox);
            this.Controls.Add(this.QuantityLabel);
            this.Controls.Add(this.UnitPriceTextBox);
            this.Controls.Add(this.UnitPriceLabel);
            this.Controls.Add(this.ProductAmountTextBox);
            this.Controls.Add(this.ProductAmountLabel);
            this.Controls.Add(this.ProductCodeTextBox);
            this.Controls.Add(this.ProductCodeLabel);
            this.Name = "FleetUserControl";
            this.Size = new System.Drawing.Size(310, 299);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ProductCodeLabel;
        private System.Windows.Forms.TextBox ProductCodeTextBox;
        private System.Windows.Forms.Label ProductAmountLabel;
        private System.Windows.Forms.TextBox ProductAmountTextBox;
        private System.Windows.Forms.Label UnitPriceLabel;
        private System.Windows.Forms.TextBox UnitPriceTextBox;
        private System.Windows.Forms.Label QuantityLabel;
        private System.Windows.Forms.TextBox QuantityTextBox;
        private System.Windows.Forms.Label UnitOfMeasureLabel;
        private System.Windows.Forms.TextBox UnitOfMeasureTextBox;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.ListBox RetMessageListBox;
        private System.Windows.Forms.Button RemoveButton;
    }
}

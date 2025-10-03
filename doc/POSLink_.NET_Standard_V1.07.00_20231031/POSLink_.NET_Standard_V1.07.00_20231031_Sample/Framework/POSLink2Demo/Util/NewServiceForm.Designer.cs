namespace POSLink2Demo
{
    partial class NewServiceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewServiceForm));
            this.NewTypeLabel = new System.Windows.Forms.Label();
            this.NewTypeComboBox = new System.Windows.Forms.ComboBox();
            this.NewURITextBox = new System.Windows.Forms.TextBox();
            this.NewURILabel = new System.Windows.Forms.Label();
            this.NewTitleLabel = new System.Windows.Forms.Label();
            this.NewTitleTextBox = new System.Windows.Forms.TextBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NewTypeLabel
            // 
            this.NewTypeLabel.Location = new System.Drawing.Point(0, 2);
            this.NewTypeLabel.Name = "NewTypeLabel";
            this.NewTypeLabel.Size = new System.Drawing.Size(113, 21);
            this.NewTypeLabel.TabIndex = 340;
            this.NewTypeLabel.Text = "New Type";
            this.NewTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NewTypeComboBox
            // 
            this.NewTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NewTypeComboBox.FormattingEnabled = true;
            this.NewTypeComboBox.Items.AddRange(new object[] {
            "Unspecified",
            "Valuable",
            "Receipt",
            "Survey",
            "Goods",
            "Signup"});
            this.NewTypeComboBox.Location = new System.Drawing.Point(115, 3);
            this.NewTypeComboBox.Name = "NewTypeComboBox";
            this.NewTypeComboBox.Size = new System.Drawing.Size(272, 20);
            this.NewTypeComboBox.TabIndex = 341;
            // 
            // NewURITextBox
            // 
            this.NewURITextBox.Location = new System.Drawing.Point(115, 56);
            this.NewURITextBox.Name = "NewURITextBox";
            this.NewURITextBox.Size = new System.Drawing.Size(272, 21);
            this.NewURITextBox.TabIndex = 345;
            // 
            // NewURILabel
            // 
            this.NewURILabel.Location = new System.Drawing.Point(0, 56);
            this.NewURILabel.Name = "NewURILabel";
            this.NewURILabel.Size = new System.Drawing.Size(113, 21);
            this.NewURILabel.TabIndex = 344;
            this.NewURILabel.Text = "New URI";
            this.NewURILabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NewTitleLabel
            // 
            this.NewTitleLabel.Location = new System.Drawing.Point(0, 29);
            this.NewTitleLabel.Name = "NewTitleLabel";
            this.NewTitleLabel.Size = new System.Drawing.Size(113, 21);
            this.NewTitleLabel.TabIndex = 342;
            this.NewTitleLabel.Text = "New Title";
            this.NewTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NewTitleTextBox
            // 
            this.NewTitleTextBox.Location = new System.Drawing.Point(115, 29);
            this.NewTitleTextBox.Name = "NewTitleTextBox";
            this.NewTitleTextBox.Size = new System.Drawing.Size(272, 21);
            this.NewTitleTextBox.TabIndex = 343;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(265, 83);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(122, 20);
            this.CancelButton.TabIndex = 346;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(141, 83);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(118, 20);
            this.AddButton.TabIndex = 347;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // NewServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 113);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.NewTypeLabel);
            this.Controls.Add(this.NewTypeComboBox);
            this.Controls.Add(this.NewURITextBox);
            this.Controls.Add(this.NewURILabel);
            this.Controls.Add(this.NewTitleLabel);
            this.Controls.Add(this.NewTitleTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "NewServiceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewService";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NewTypeLabel;
        private System.Windows.Forms.ComboBox NewTypeComboBox;
        private System.Windows.Forms.TextBox NewURITextBox;
        private System.Windows.Forms.Label NewURILabel;
        private System.Windows.Forms.Label NewTitleLabel;
        private System.Windows.Forms.TextBox NewTitleTextBox;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button AddButton;
    }
}
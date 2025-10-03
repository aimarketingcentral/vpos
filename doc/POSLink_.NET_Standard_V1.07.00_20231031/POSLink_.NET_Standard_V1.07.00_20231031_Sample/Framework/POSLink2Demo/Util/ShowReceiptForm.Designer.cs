namespace POSLink2Demo
{
    partial class ShowReceiptForm
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
            this.Save = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.RichTextBox_Print = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(42, 541);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 6;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(180, 541);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 5;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // RichTextBox_Print
            // 
            this.RichTextBox_Print.Font = new System.Drawing.Font("SimSun", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RichTextBox_Print.Location = new System.Drawing.Point(3, 2);
            this.RichTextBox_Print.Name = "RichTextBox_Print";
            this.RichTextBox_Print.Size = new System.Drawing.Size(279, 533);
            this.RichTextBox_Print.TabIndex = 4;
            this.RichTextBox_Print.Text = "";
            // 
            // ShowReceiptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 576);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.RichTextBox_Print);
            this.Name = "ShowReceiptForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Show Receipt";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button CloseButton;
        public System.Windows.Forms.RichTextBox RichTextBox_Print;
    }
}
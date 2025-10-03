namespace POSLink2Demo
{
    partial class ShowSignatureDataForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowSignatureDataForm));
            this.SianatureDataTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // SianatureDataTextBox
            // 
            this.SianatureDataTextBox.Location = new System.Drawing.Point(3, 4);
            this.SianatureDataTextBox.Multiline = true;
            this.SianatureDataTextBox.Name = "SianatureDataTextBox";
            this.SianatureDataTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.SianatureDataTextBox.Size = new System.Drawing.Size(358, 284);
            this.SianatureDataTextBox.TabIndex = 0;
            // 
            // ShowSignatureDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 298);
            this.Controls.Add(this.SianatureDataTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ShowSignatureDataForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShowSignatureData";
            this.Load += new System.EventHandler(this.ShowSignatureDataForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SianatureDataTextBox;
    }
}
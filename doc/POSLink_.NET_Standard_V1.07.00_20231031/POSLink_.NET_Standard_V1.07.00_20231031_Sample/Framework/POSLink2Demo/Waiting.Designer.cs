namespace POSLink2Demo
{
    partial class Waiting
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
            this.CancelButton = new System.Windows.Forms.Button();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.ReportStatusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(344, 254);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(113, 43);
            this.CancelButton.TabIndex = 0;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("SimSun", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TitleLabel.Location = new System.Drawing.Point(312, 157);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(178, 29);
            this.TitleLabel.TabIndex = 1;
            this.TitleLabel.Text = "Please wait";
            // 
            // ReportStatusLabel
            // 
            this.ReportStatusLabel.Font = new System.Drawing.Font("SimSun", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ReportStatusLabel.Location = new System.Drawing.Point(3, 206);
            this.ReportStatusLabel.Name = "ReportStatusLabel";
            this.ReportStatusLabel.Size = new System.Drawing.Size(794, 29);
            this.ReportStatusLabel.TabIndex = 1;
            this.ReportStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Waiting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ReportStatusLabel);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.CancelButton);
            this.Name = "Waiting";
            this.Size = new System.Drawing.Size(800, 463);
            this.Load += new System.EventHandler(this.Waiting_Load);
            this.VisibleChanged += new System.EventHandler(this.Waiting_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label ReportStatusLabel;
    }
}

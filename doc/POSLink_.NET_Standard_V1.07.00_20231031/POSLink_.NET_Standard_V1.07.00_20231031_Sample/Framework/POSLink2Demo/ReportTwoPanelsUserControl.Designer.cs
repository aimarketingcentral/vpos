namespace POSLink2Demo
{
    partial class ReportTwoPanelsUserControl
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
            this.ValuePanel = new System.Windows.Forms.Panel();
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // ValuePanel
            // 
            this.ValuePanel.AutoScroll = true;
            this.ValuePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ValuePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ValuePanel.Location = new System.Drawing.Point(100, 0);
            this.ValuePanel.Name = "ValuePanel";
            this.ValuePanel.Size = new System.Drawing.Size(296, 432);
            this.ValuePanel.TabIndex = 3;
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ButtonPanel.Location = new System.Drawing.Point(0, 0);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(100, 432);
            this.ButtonPanel.TabIndex = 4;
            // 
            // ReportTwoPanelsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ValuePanel);
            this.Controls.Add(this.ButtonPanel);
            this.Name = "ReportTwoPanelsUserControl";
            this.Size = new System.Drawing.Size(399, 432);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ValuePanel;
        private System.Windows.Forms.Panel ButtonPanel;
    }
}

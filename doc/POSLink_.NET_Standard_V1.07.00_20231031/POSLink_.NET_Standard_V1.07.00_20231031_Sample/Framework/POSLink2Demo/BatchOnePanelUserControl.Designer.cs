namespace POSLink2Demo
{
    partial class BatchOnePanelUserControl
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
            this.SuspendLayout();
            // 
            // ValuePanel
            // 
            this.ValuePanel.AutoScroll = true;
            this.ValuePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ValuePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ValuePanel.Location = new System.Drawing.Point(0, 0);
            this.ValuePanel.Name = "ValuePanel";
            this.ValuePanel.Size = new System.Drawing.Size(398, 432);
            this.ValuePanel.TabIndex = 1;
            // 
            // BatchOnePanelUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ValuePanel);
            this.Name = "BatchOnePanelUserControl";
            this.Size = new System.Drawing.Size(399, 432);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ValuePanel;
    }
}

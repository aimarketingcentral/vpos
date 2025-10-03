namespace POSLink2Demo
{
    partial class MultipleCommandsUserControl
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
            this.DoMultipleCommands = new System.Windows.Forms.Button();
            this.RequestListBox = new System.Windows.Forms.ListBox();
            this.ResponseListBox = new System.Windows.Forms.ListBox();
            this.ClearButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ResponseLabel = new System.Windows.Forms.Label();
            this.RequestLabel = new System.Windows.Forms.Label();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DoMultipleCommands
            // 
            this.DoMultipleCommands.Location = new System.Drawing.Point(5, 7);
            this.DoMultipleCommands.Name = "DoMultipleCommands";
            this.DoMultipleCommands.Size = new System.Drawing.Size(140, 23);
            this.DoMultipleCommands.TabIndex = 2;
            this.DoMultipleCommands.Text = "Do Multiple Commands";
            this.DoMultipleCommands.UseVisualStyleBackColor = true;
            this.DoMultipleCommands.Click += new System.EventHandler(this.DoMultipleCommands_Click);
            // 
            // RequestListBox
            // 
            this.RequestListBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.RequestListBox.FormattingEnabled = true;
            this.RequestListBox.ItemHeight = 12;
            this.RequestListBox.Location = new System.Drawing.Point(0, 54);
            this.RequestListBox.Name = "RequestListBox";
            this.RequestListBox.Size = new System.Drawing.Size(399, 409);
            this.RequestListBox.TabIndex = 3;
            // 
            // ResponseListBox
            // 
            this.ResponseListBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.ResponseListBox.FormattingEnabled = true;
            this.ResponseListBox.ItemHeight = 12;
            this.ResponseListBox.Location = new System.Drawing.Point(399, 54);
            this.ResponseListBox.Name = "ResponseListBox";
            this.ResponseListBox.Size = new System.Drawing.Size(399, 409);
            this.ResponseListBox.TabIndex = 3;
            this.ResponseListBox.DoubleClick += new System.EventHandler(this.ResponseListBox_DoubleClick);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(151, 7);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(140, 23);
            this.ClearButton.TabIndex = 2;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.DoMultipleCommands);
            this.panel1.Controls.Add(this.RemoveButton);
            this.panel1.Controls.Add(this.ClearButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 54);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ResponseLabel);
            this.panel2.Controls.Add(this.RequestLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 21);
            this.panel2.TabIndex = 3;
            // 
            // ResponseLabel
            // 
            this.ResponseLabel.AutoSize = true;
            this.ResponseLabel.Location = new System.Drawing.Point(410, 6);
            this.ResponseLabel.Name = "ResponseLabel";
            this.ResponseLabel.Size = new System.Drawing.Size(53, 12);
            this.ResponseLabel.TabIndex = 0;
            this.ResponseLabel.Text = "Response";
            // 
            // RequestLabel
            // 
            this.RequestLabel.AutoSize = true;
            this.RequestLabel.Location = new System.Drawing.Point(10, 6);
            this.RequestLabel.Name = "RequestLabel";
            this.RequestLabel.Size = new System.Drawing.Size(47, 12);
            this.RequestLabel.TabIndex = 0;
            this.RequestLabel.Text = "Request";
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(297, 7);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(140, 23);
            this.RemoveButton.TabIndex = 2;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // MultipleCommandsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ResponseListBox);
            this.Controls.Add(this.RequestListBox);
            this.Controls.Add(this.panel1);
            this.Name = "MultipleCommandsUserControl";
            this.Size = new System.Drawing.Size(800, 463);
            this.Load += new System.EventHandler(this.MultipleCommandsUserControl_Load);
            this.VisibleChanged += new System.EventHandler(this.MultipleCommandsUserControl_VisibleChanged);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button DoMultipleCommands;
        private System.Windows.Forms.ListBox RequestListBox;
        private System.Windows.Forms.ListBox ResponseListBox;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label ResponseLabel;
        private System.Windows.Forms.Label RequestLabel;
        private System.Windows.Forms.Button RemoveButton;
    }
}

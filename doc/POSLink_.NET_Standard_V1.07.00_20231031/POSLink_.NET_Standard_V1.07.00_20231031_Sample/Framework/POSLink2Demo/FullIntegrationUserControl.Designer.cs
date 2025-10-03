namespace POSLink2Demo
{
    partial class FullIntegrationUserControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.StartButton = new System.Windows.Forms.Button();
            this.CommandComboBox = new System.Windows.Forms.ComboBox();
            this.CommandLabel = new System.Windows.Forms.Label();
            this.AddToMultipleCommandsButton = new System.Windows.Forms.Button();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ResponseLabel = new System.Windows.Forms.Label();
            this.RequestLabel = new System.Windows.Forms.Label();
            this.TopPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 409);
            this.panel1.TabIndex = 23;
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(299, 6);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 20);
            this.StartButton.TabIndex = 22;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // CommandComboBox
            // 
            this.CommandComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CommandComboBox.FormattingEnabled = true;
            this.CommandComboBox.Location = new System.Drawing.Point(56, 6);
            this.CommandComboBox.Name = "CommandComboBox";
            this.CommandComboBox.Size = new System.Drawing.Size(237, 20);
            this.CommandComboBox.TabIndex = 21;
            this.CommandComboBox.SelectedIndexChanged += new System.EventHandler(this.CommandComboBox_SelectedIndexChanged);
            // 
            // CommandLabel
            // 
            this.CommandLabel.AutoSize = true;
            this.CommandLabel.Location = new System.Drawing.Point(3, 9);
            this.CommandLabel.Name = "CommandLabel";
            this.CommandLabel.Size = new System.Drawing.Size(47, 12);
            this.CommandLabel.TabIndex = 20;
            this.CommandLabel.Text = "Command";
            // 
            // AddToMultipleCommandsButton
            // 
            this.AddToMultipleCommandsButton.Location = new System.Drawing.Point(380, 6);
            this.AddToMultipleCommandsButton.Name = "AddToMultipleCommandsButton";
            this.AddToMultipleCommandsButton.Size = new System.Drawing.Size(155, 20);
            this.AddToMultipleCommandsButton.TabIndex = 25;
            this.AddToMultipleCommandsButton.Text = "Add To MultipleCommands";
            this.AddToMultipleCommandsButton.UseVisualStyleBackColor = true;
            this.AddToMultipleCommandsButton.Click += new System.EventHandler(this.AddToMultipleCommandsButton_Click);
            // 
            // TopPanel
            // 
            this.TopPanel.Controls.Add(this.panel3);
            this.TopPanel.Controls.Add(this.AddToMultipleCommandsButton);
            this.TopPanel.Controls.Add(this.CommandLabel);
            this.TopPanel.Controls.Add(this.CommandComboBox);
            this.TopPanel.Controls.Add(this.StartButton);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(800, 54);
            this.TopPanel.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ResponseLabel);
            this.panel3.Controls.Add(this.RequestLabel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 33);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 21);
            this.panel3.TabIndex = 26;
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
            // FullIntegrationUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TopPanel);
            this.Name = "FullIntegrationUserControl";
            this.Size = new System.Drawing.Size(800, 463);
            this.Load += new System.EventHandler(this.FullIntegrationUserControl_Load);
            this.VisibleChanged += new System.EventHandler(this.FullIntegrationUserControl_VisibleChanged);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.ComboBox CommandComboBox;
        private System.Windows.Forms.Label CommandLabel;
        private System.Windows.Forms.Button AddToMultipleCommandsButton;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label ResponseLabel;
        private System.Windows.Forms.Label RequestLabel;
    }
}

namespace POSLink2Demo
{
    partial class TransactionUserControl
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
            this.components = new System.ComponentModel.Container();
            this.TenderTypeLabel = new System.Windows.Forms.Label();
            this.TenderTypeComboBox = new System.Windows.Forms.ComboBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.AddToMultipleCommandsButton = new System.Windows.Forms.Button();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ResponseLabel = new System.Windows.Forms.Label();
            this.RequestLabel = new System.Windows.Forms.Label();
            this.CenterPanel = new System.Windows.Forms.Panel();
            this.ResponsePanel = new System.Windows.Forms.Panel();
            this.ButtonPanel2 = new System.Windows.Forms.Panel();
            this.RequestPanel = new System.Windows.Forms.Panel();
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.TopPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.CenterPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TenderTypeLabel
            // 
            this.TenderTypeLabel.AutoSize = true;
            this.TenderTypeLabel.Location = new System.Drawing.Point(3, 10);
            this.TenderTypeLabel.Name = "TenderTypeLabel";
            this.TenderTypeLabel.Size = new System.Drawing.Size(71, 12);
            this.TenderTypeLabel.TabIndex = 1;
            this.TenderTypeLabel.Text = "Tender Type";
            // 
            // TenderTypeComboBox
            // 
            this.TenderTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TenderTypeComboBox.FormattingEnabled = true;
            this.TenderTypeComboBox.Location = new System.Drawing.Point(80, 7);
            this.TenderTypeComboBox.Name = "TenderTypeComboBox";
            this.TenderTypeComboBox.Size = new System.Drawing.Size(237, 20);
            this.TenderTypeComboBox.TabIndex = 2;
            this.TenderTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.TenderTypeComboBox_SelectedIndexChanged);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(325, 7);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 20);
            this.StartButton.TabIndex = 3;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // AddToMultipleCommandsButton
            // 
            this.AddToMultipleCommandsButton.Location = new System.Drawing.Point(406, 7);
            this.AddToMultipleCommandsButton.Name = "AddToMultipleCommandsButton";
            this.AddToMultipleCommandsButton.Size = new System.Drawing.Size(155, 20);
            this.AddToMultipleCommandsButton.TabIndex = 3;
            this.AddToMultipleCommandsButton.Text = "Add To MultipleCommands";
            this.AddToMultipleCommandsButton.UseVisualStyleBackColor = true;
            this.AddToMultipleCommandsButton.Click += new System.EventHandler(this.AddToMultipleCommandsButton_Click);
            // 
            // TopPanel
            // 
            this.TopPanel.Controls.Add(this.TenderTypeLabel);
            this.TopPanel.Controls.Add(this.AddToMultipleCommandsButton);
            this.TopPanel.Controls.Add(this.TenderTypeComboBox);
            this.TopPanel.Controls.Add(this.StartButton);
            this.TopPanel.Controls.Add(this.panel1);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(800, 54);
            this.TopPanel.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ResponseLabel);
            this.panel1.Controls.Add(this.RequestLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 21);
            this.panel1.TabIndex = 0;
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
            // CenterPanel
            // 
            this.CenterPanel.Controls.Add(this.ResponsePanel);
            this.CenterPanel.Controls.Add(this.ButtonPanel2);
            this.CenterPanel.Controls.Add(this.RequestPanel);
            this.CenterPanel.Controls.Add(this.ButtonPanel);
            this.CenterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CenterPanel.Location = new System.Drawing.Point(0, 54);
            this.CenterPanel.Name = "CenterPanel";
            this.CenterPanel.Size = new System.Drawing.Size(800, 409);
            this.CenterPanel.TabIndex = 5;
            // 
            // ResponsePanel
            // 
            this.ResponsePanel.AutoScroll = true;
            this.ResponsePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ResponsePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ResponsePanel.Location = new System.Drawing.Point(496, 0);
            this.ResponsePanel.Name = "ResponsePanel";
            this.ResponsePanel.Size = new System.Drawing.Size(293, 409);
            this.ResponsePanel.TabIndex = 4;
            // 
            // ButtonPanel2
            // 
            this.ButtonPanel2.AutoScroll = true;
            this.ButtonPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ButtonPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.ButtonPanel2.Location = new System.Drawing.Point(396, 0);
            this.ButtonPanel2.Name = "ButtonPanel2";
            this.ButtonPanel2.Size = new System.Drawing.Size(100, 409);
            this.ButtonPanel2.TabIndex = 3;
            // 
            // RequestPanel
            // 
            this.RequestPanel.AutoScroll = true;
            this.RequestPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RequestPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.RequestPanel.Location = new System.Drawing.Point(100, 0);
            this.RequestPanel.Name = "RequestPanel";
            this.RequestPanel.Size = new System.Drawing.Size(296, 409);
            this.RequestPanel.TabIndex = 2;
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.AutoScroll = true;
            this.ButtonPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ButtonPanel.Location = new System.Drawing.Point(0, 0);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(100, 409);
            this.ButtonPanel.TabIndex = 1;
            // 
            // TransactionUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CenterPanel);
            this.Controls.Add(this.TopPanel);
            this.Name = "TransactionUserControl";
            this.Size = new System.Drawing.Size(800, 463);
            this.Load += new System.EventHandler(this.TransactionUserControl_Load);
            this.VisibleChanged += new System.EventHandler(this.TransactionUserControl_VisibleChanged);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.CenterPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label TenderTypeLabel;
        private System.Windows.Forms.ComboBox TenderTypeComboBox;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button AddToMultipleCommandsButton;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Panel CenterPanel;
        private System.Windows.Forms.Panel ButtonPanel2;
        private System.Windows.Forms.Panel ResponsePanel;
        private System.Windows.Forms.Panel RequestPanel;
        private System.Windows.Forms.Panel ButtonPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label ResponseLabel;
        private System.Windows.Forms.Label RequestLabel;
    }
}

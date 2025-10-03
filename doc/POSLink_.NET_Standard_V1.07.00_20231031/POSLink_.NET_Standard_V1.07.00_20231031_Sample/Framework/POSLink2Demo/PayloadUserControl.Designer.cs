namespace POSLink2Demo
{
    partial class PayloadUserControl
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.ResponseLabel = new System.Windows.Forms.Label();
            this.RequestLabel = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CenterPanel = new System.Windows.Forms.Panel();
            this.ResponseValuePanel = new System.Windows.Forms.Panel();
            this.PayloadRspTextBox = new System.Windows.Forms.TextBox();
            this.PayloadRspLabel = new System.Windows.Forms.Label();
            this.ResponseMessageTextBox = new System.Windows.Forms.TextBox();
            this.ResponseMessageLabel = new System.Windows.Forms.Label();
            this.ResponseCodeTextBox = new System.Windows.Forms.TextBox();
            this.ResponseCodeLabel = new System.Windows.Forms.Label();
            this.RequestValuePanel = new System.Windows.Forms.Panel();
            this.PayloadReqTextBox = new System.Windows.Forms.TextBox();
            this.PayloadReqLabel = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.CenterPanel.SuspendLayout();
            this.ResponseValuePanel.SuspendLayout();
            this.RequestValuePanel.SuspendLayout();
            this.SuspendLayout();
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
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(5, 7);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(140, 23);
            this.StartButton.TabIndex = 2;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.StartButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 54);
            this.panel1.TabIndex = 7;
            // 
            // CenterPanel
            // 
            this.CenterPanel.Controls.Add(this.ResponseValuePanel);
            this.CenterPanel.Controls.Add(this.RequestValuePanel);
            this.CenterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CenterPanel.Location = new System.Drawing.Point(0, 54);
            this.CenterPanel.Name = "CenterPanel";
            this.CenterPanel.Size = new System.Drawing.Size(800, 409);
            this.CenterPanel.TabIndex = 10;
            // 
            // ResponseValuePanel
            // 
            this.ResponseValuePanel.AutoScroll = true;
            this.ResponseValuePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ResponseValuePanel.Controls.Add(this.PayloadRspTextBox);
            this.ResponseValuePanel.Controls.Add(this.PayloadRspLabel);
            this.ResponseValuePanel.Controls.Add(this.ResponseMessageTextBox);
            this.ResponseValuePanel.Controls.Add(this.ResponseMessageLabel);
            this.ResponseValuePanel.Controls.Add(this.ResponseCodeTextBox);
            this.ResponseValuePanel.Controls.Add(this.ResponseCodeLabel);
            this.ResponseValuePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ResponseValuePanel.Location = new System.Drawing.Point(398, 0);
            this.ResponseValuePanel.Name = "ResponseValuePanel";
            this.ResponseValuePanel.Size = new System.Drawing.Size(398, 409);
            this.ResponseValuePanel.TabIndex = 11;
            // 
            // PayloadRspTextBox
            // 
            this.PayloadRspTextBox.Location = new System.Drawing.Point(118, 59);
            this.PayloadRspTextBox.Multiline = true;
            this.PayloadRspTextBox.Name = "PayloadRspTextBox";
            this.PayloadRspTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PayloadRspTextBox.Size = new System.Drawing.Size(275, 237);
            this.PayloadRspTextBox.TabIndex = 1;
            // 
            // PayloadRspLabel
            // 
            this.PayloadRspLabel.AutoSize = true;
            this.PayloadRspLabel.Location = new System.Drawing.Point(65, 62);
            this.PayloadRspLabel.Name = "PayloadRspLabel";
            this.PayloadRspLabel.Size = new System.Drawing.Size(47, 12);
            this.PayloadRspLabel.TabIndex = 0;
            this.PayloadRspLabel.Text = "Payload";
            // 
            // ResponseMessageTextBox
            // 
            this.ResponseMessageTextBox.Location = new System.Drawing.Point(118, 32);
            this.ResponseMessageTextBox.Name = "ResponseMessageTextBox";
            this.ResponseMessageTextBox.Size = new System.Drawing.Size(275, 21);
            this.ResponseMessageTextBox.TabIndex = 1;
            // 
            // ResponseMessageLabel
            // 
            this.ResponseMessageLabel.AutoSize = true;
            this.ResponseMessageLabel.Location = new System.Drawing.Point(11, 35);
            this.ResponseMessageLabel.Name = "ResponseMessageLabel";
            this.ResponseMessageLabel.Size = new System.Drawing.Size(101, 12);
            this.ResponseMessageLabel.TabIndex = 0;
            this.ResponseMessageLabel.Text = "Response Message";
            // 
            // ResponseCodeTextBox
            // 
            this.ResponseCodeTextBox.Location = new System.Drawing.Point(118, 5);
            this.ResponseCodeTextBox.Name = "ResponseCodeTextBox";
            this.ResponseCodeTextBox.Size = new System.Drawing.Size(275, 21);
            this.ResponseCodeTextBox.TabIndex = 1;
            // 
            // ResponseCodeLabel
            // 
            this.ResponseCodeLabel.AutoSize = true;
            this.ResponseCodeLabel.Location = new System.Drawing.Point(29, 8);
            this.ResponseCodeLabel.Name = "ResponseCodeLabel";
            this.ResponseCodeLabel.Size = new System.Drawing.Size(83, 12);
            this.ResponseCodeLabel.TabIndex = 0;
            this.ResponseCodeLabel.Text = "Response Code";
            // 
            // RequestValuePanel
            // 
            this.RequestValuePanel.AutoScroll = true;
            this.RequestValuePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RequestValuePanel.Controls.Add(this.PayloadReqTextBox);
            this.RequestValuePanel.Controls.Add(this.PayloadReqLabel);
            this.RequestValuePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.RequestValuePanel.Location = new System.Drawing.Point(0, 0);
            this.RequestValuePanel.Name = "RequestValuePanel";
            this.RequestValuePanel.Size = new System.Drawing.Size(398, 409);
            this.RequestValuePanel.TabIndex = 10;
            // 
            // PayloadReqTextBox
            // 
            this.PayloadReqTextBox.Location = new System.Drawing.Point(62, 5);
            this.PayloadReqTextBox.Multiline = true;
            this.PayloadReqTextBox.Name = "PayloadReqTextBox";
            this.PayloadReqTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PayloadReqTextBox.Size = new System.Drawing.Size(329, 189);
            this.PayloadReqTextBox.TabIndex = 1;
            // 
            // PayloadReqLabel
            // 
            this.PayloadReqLabel.AutoSize = true;
            this.PayloadReqLabel.Location = new System.Drawing.Point(9, 8);
            this.PayloadReqLabel.Name = "PayloadReqLabel";
            this.PayloadReqLabel.Size = new System.Drawing.Size(47, 12);
            this.PayloadReqLabel.TabIndex = 0;
            this.PayloadReqLabel.Text = "Payload";
            // 
            // PayloadUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CenterPanel);
            this.Controls.Add(this.panel1);
            this.Name = "PayloadUserControl";
            this.Size = new System.Drawing.Size(800, 463);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.CenterPanel.ResumeLayout(false);
            this.ResponseValuePanel.ResumeLayout(false);
            this.ResponseValuePanel.PerformLayout();
            this.RequestValuePanel.ResumeLayout(false);
            this.RequestValuePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label ResponseLabel;
        private System.Windows.Forms.Label RequestLabel;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel CenterPanel;
        private System.Windows.Forms.Panel ResponseValuePanel;
        private System.Windows.Forms.TextBox PayloadRspTextBox;
        private System.Windows.Forms.Label PayloadRspLabel;
        private System.Windows.Forms.TextBox ResponseMessageTextBox;
        private System.Windows.Forms.Label ResponseMessageLabel;
        private System.Windows.Forms.TextBox ResponseCodeTextBox;
        private System.Windows.Forms.Label ResponseCodeLabel;
        private System.Windows.Forms.Panel RequestValuePanel;
        private System.Windows.Forms.TextBox PayloadReqTextBox;
        private System.Windows.Forms.Label PayloadReqLabel;
    }
}

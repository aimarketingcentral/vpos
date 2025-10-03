/*		
 * ===========================================================================================
 * = COPYRIGHT		                  	
 *          PAX Computer Technology (Shenzhen) Co., Ltd. PROPRIETARY INFORMATION	
 *   This software is supplied under the terms of a license agreement or nondisclosure 	
 *   agreement with PAX Computer Technology (Shenzhen) Co., Ltd. and may not be copied or 
 *   disclosed except in accordance with the terms in that agreement.   		
 *     Copyright (C) 2023 PAX Computer Technology (Shenzhen) Co., Ltd. All rights reserved.
 * ===========================================================================================
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSLink2Demo
{
    public partial class ButtonTextBoxUserControl : UserControl
    {
        private string _buttonName;
        public string ButtonName
        {
            get { return _buttonName; }
            set { _buttonName = value; }
        }

        private ButtonClickEventCommandName? _commandName;
        public ButtonClickEventCommandName? CommandName
        {
            get { return _commandName; }
            set { _commandName = value; }
        }

        private string _name;

        public ButtonTextBoxUserControl()
        {
            InitializeComponent();
            _commandName = null;
            _buttonName = "";
            _name = "";
        }

        public void CreateButtonTextBox(int width, string name, string text, float proportion)
        {
            if (width > 390)
            {
                width = 390;
            }
            if (proportion > 0.5)
            {
                proportion = 0.5f;
            }
            if (proportion < 0.3)
            {
                proportion = 0.3f;
            }
            int buttonWidth = (int)(width * proportion - 4);
            int textBoxWidth = (int)(width * (1.0f - proportion));
            this.Width = width;
            this.Height = 22;

            _name = name;
            button1.Width = buttonWidth;
            button1.Text = name;
            button1.Location = new Point(2, 0);
            textBox1.Width = textBoxWidth;
            textBox1.Name = name + "TextBox";
            textBox1.Location = new Point(buttonWidth + 2, 0);
            textBox1.Text = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(_commandName == ButtonClickEventCommandName.GoogleSmartTapReq)
            {
                GoogleSmartTapForm googleSmartTapForm = new GoogleSmartTapForm();
                googleSmartTapForm.ShowDialog();
                if(googleSmartTapForm.DialogResult == DialogResult.OK)
                {
                    textBox1.Text = googleSmartTapForm.GoogleVasCapData;
                    googleSmartTapForm.Close();
                    googleSmartTapForm.Dispose();
                }
            }
            else if(_commandName == ButtonClickEventCommandName.VasPushDataReq)
            {
                GoogleSmartTapPushServiceForm googleSmartTapPushServiceForm = new GoogleSmartTapPushServiceForm(_name);
                googleSmartTapPushServiceForm.Text = _name;
                googleSmartTapPushServiceForm.ShowDialog();
                if(googleSmartTapPushServiceForm.DialogResult == DialogResult.OK)
                {
                    textBox1.Text = googleSmartTapPushServiceForm.GoogleSmartTapPushServiceData;
                }
                googleSmartTapPushServiceForm.Dispose();
            }
            else
            {
                ShowResponseForm showResponseForm = new ShowResponseForm();
                showResponseForm.CommandName = _commandName;
                showResponseForm.ButtonName = _buttonName;
                showResponseForm.Text = _name;
                showResponseForm.ShowDialog();
                if(showResponseForm.DialogResult != DialogResult.OK)
                {
                    showResponseForm.Dispose();
                }
            }

        }

        public void SetTextBoxValue(string text)
        {
            textBox1.Text = text;
        }

        public string GetTextBoxValue()
        {
            return textBox1.Text;
        }
    }
}

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
    public partial class LabelTextBoxUserControl : UserControl
    {
        public LabelTextBoxUserControl()
        {
            InitializeComponent();
        }

        public void CreateLabelTextBox(int width, string name, string text, float proportion)
        {
            label1.AutoSize = false;
            if(width>390)
            {
                width = 390;
            }
            int labelWidth = (int)(width * proportion - 4);
            int textBoxWidth = (int)(width * (1.0f - proportion));
            this.Width = width;
            this.Height = 22;

            label1.Width = labelWidth;
            label1.TextAlign = ContentAlignment.MiddleRight;
            toolTip1.SetToolTip(label1, text);
            if(text.Length>18)
            {
                text = text.Substring(0, 15) + "...";
            }
            label1.Text = text;

            textBox1.Width = textBoxWidth;
            textBox1.Location = new Point(labelWidth + 2, 0);
            textBox1.Name = name + "TextBox";
        }

        public void SetTextBoxHeight(int height)
        {
            this.Height = height;
            textBox1.Multiline = true;
            textBox1.Height = height;
            textBox1.ScrollBars = ScrollBars.Both;
        }

        public void SetTextBoxWidth(int width)
        {
            this.Width = this.Width - (textBox1.Width - width);
            textBox1.Width = width;
        }

        public void SetTextBoxValue(string text)
        {
            textBox1.Text = text;
        }

        public string GetTextBoxValue()
        {
            return textBox1.Text;
        }

        public Label GetLabelData()
        {
            return label1;
        }
    }
}

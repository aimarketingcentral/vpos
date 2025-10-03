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
    public partial class LabelComboBoxUserControl : UserControl
    {
        public LabelComboBoxUserControl()
        {
            InitializeComponent();
        }

        public void CreateLabelComboBox(int width, string name, string text, string[] itemsArray, float proportion)
        {
            label1.AutoSize = false;
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
            int labelWidth = (int)(width * proportion - 4);
            int comboBoxWidth = (int)(width * (1.0f - proportion));
            this.Width = width;
            this.Height = 22;

            label1.Width = labelWidth;
            label1.Location = new Point(0, 0);
            label1.TextAlign = ContentAlignment.MiddleRight;
            toolTip1.SetToolTip(label1, text);
            if (text.Length > 18)
            {
                text = text.Substring(0, 15) + "...";
            }
            label1.Text = text;

            comboBox1.Width = comboBoxWidth;
            comboBox1.Location = new Point(labelWidth + 2, 0);
            comboBox1.Name = name + "ComboBox";
            comboBox1.Items.AddRange(itemsArray);
            comboBox1.SelectedIndex = 0;
        }

        public void SetComboBoxIndex(int index)
        {
            comboBox1.SelectedIndex = index;
        }

        public int GetComboBoxIndex()
        {
            return comboBox1.SelectedIndex;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

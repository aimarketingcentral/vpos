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
    public partial class SwitchUserControl : UserControl
    {
        public string Text
        {
            get { return this.label1.Text; }
            set { this.label1.Text = value; }
        }
        private bool _buttonSwitch;
        public bool ButtonSwitch { get; set; }
        public int LabelWidth
        {
            get { return this.label1.Width; }
            set { this.label1.Width = value; this.button1.Location = new Point(this.label1.Width + 2, 0); }
        }
        public int ButtonWidth
        {
            get { return this.button1.Width; }
            set { this.button1.Width = value; }
        }
        public SwitchUserControl()
        {
            InitializeComponent();
            ButtonSwitch = false;
            button1.Text = "Disable";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(ButtonSwitch)
            {
                ButtonSwitch = false;
                button1.Text = "Disable";
            }
            else
            {
                ButtonSwitch = true;
                button1.Text = "Enable";
            }
        }

        private void SwitchUserControl_Load(object sender, EventArgs e)
        {
            if (ButtonSwitch)
            {
                button1.Text = "Enable";
            }
            else
            {
                button1.Text = "Disable";
            }
        }
    }
}

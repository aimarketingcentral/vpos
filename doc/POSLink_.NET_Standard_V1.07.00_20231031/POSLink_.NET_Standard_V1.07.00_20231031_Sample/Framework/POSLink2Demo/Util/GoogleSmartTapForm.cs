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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSLink2Demo
{
    public partial class GoogleSmartTapForm : Form
    {
        private string _googleVasCapData;
        public string GoogleVasCapData
        {
            get { return _googleVasCapData; }
            set { _googleVasCapData = value; }
        }

        public GoogleSmartTapForm()
        {
            InitializeComponent();
            _googleVasCapData = "";
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            string buffer = "";
            buffer += Parse2CLB(SystemCheckedListBox);
            buffer += Parse2CLB(UiCheckedListBox);
            buffer += Parse2CLB(CheckoutCheckedListBox);
            buffer += Parse2CLB(CvmCheckedListBox);
            _googleVasCapData = buffer;
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }

        private string Parse2CLB(CheckedListBox CLB)
        {
            string[] strArray = new string[8];
            string ret = "";
            CheckedListBox CpyCLB = CLB;
            for (int i = 0; i < 8; i++)
            {
                strArray[i] = "0";
            }
            for (int i = 0; i < CpyCLB.Items.Count; i++)
            {
                if (CpyCLB.GetItemChecked(i))
                {
                    strArray[i] = "1";
                }
            }
            for (int i = 0; i < 8; i++)
            {
                ret += strArray[i];
            }
            return ret;
        }
    }
}

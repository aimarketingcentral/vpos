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
    public partial class ShowSignatureDataForm : Form
    {
        private string _signatureData;
        public string SignatureData
        {
            set { _signatureData = value; }
        }

        public ShowSignatureDataForm()
        {
            InitializeComponent();
        }

        private void ShowSignatureDataForm_Load(object sender, EventArgs e)
        {
            SianatureDataTextBox.Text = _signatureData;
        }
    }
}

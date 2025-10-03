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
    public partial class FsaUserControl : UserControl
    {
        public POSLink2.Util.FsaData FsaData { get; set; }
        public FsaUserControl()
        {
            InitializeComponent();
            FsaData = new POSLink2.Util.FsaData();
            this.Load += new EventHandler(FsaLoad);
        }

        private void LostFocusOfText(object sender, EventArgs e)
        {
            FsaData.HealthCareAmount = HealthCareAmountTextBox.Text;
            FsaData.RxAmount = RxAmountTextBox.Text;
            FsaData.VisionAmount = VisionAmountTextBox.Text;
            FsaData.DentalAmount = DentalAmountTextBox.Text;
            FsaData.ClinicalAmount = ClinicalAmountTextBox.Text;
            FsaData.CopayAmount = CopayAmountTextBox.Text;
            FsaData.TransitAmount = TransitAmountTextBox.Text;
            FsaData.OverTheCounterAmount = OverTheCounterAmountTextBox.Text;
        }

        private void FsaLoad(object sender, EventArgs e)
        {
            foreach(Control textBox in this.Controls)
            {
                textBox.LostFocus += new EventHandler(LostFocusOfText);
            }
        }
    }
}

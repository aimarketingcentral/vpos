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
    public partial class Waiting : UserControl
    {
        private bool _isCancel;

        public bool IsCancel
        {
            get { return _isCancel; }
            set { _isCancel = value; }
        }

        public bool IsCancelAvaliable { get; set; }

        public Waiting()
        {
            InitializeComponent();
            _isCancel = false;
            IsCancelAvaliable = false;
        }

        public void SetReportStatus(string msg)
        {
            ReportStatusLabel.Text = msg;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _isCancel = true;
        }

        private void Waiting_Load(object sender, EventArgs e)
        {
            _isCancel = false;
            if (IsCancelAvaliable)
            {
                CancelButton.Visible = true;
            }
            else
            {
                CancelButton.Visible = false;
            }
        }

        private void Waiting_VisibleChanged(object sender, EventArgs e)
        {
            _isCancel = false;
        }
    }
}

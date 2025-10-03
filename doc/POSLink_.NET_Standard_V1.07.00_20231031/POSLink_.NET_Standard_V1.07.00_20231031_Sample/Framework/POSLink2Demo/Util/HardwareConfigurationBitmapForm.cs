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
    public partial class HardwareConfigurationBitmapForm : Form
    {
        public POSLink2.Util.HardwareConfigurationBitmap HardwareConfigurationBitmap { get; set; }
        public HardwareConfigurationBitmapForm()
        {
            InitializeComponent();
            HardwareConfigurationBitmap = new POSLink2.Util.HardwareConfigurationBitmap();
        }

        private void HardwareConfigurationBitmapForm_Load(object sender, EventArgs e)
        {
            if(HardwareConfigurationBitmap == null)
            {
                return;
            }

            MagstripeTextBox.Text = HardwareConfigurationBitmap.Magstripe;
            EmvChipTextBox.Text = HardwareConfigurationBitmap.EmvChip;
            EmvContactlessTextBox.Text = HardwareConfigurationBitmap.EmvContactless;
            CameraFrontTextBox.Text = HardwareConfigurationBitmap.CameraFront;
            LaserScannerTextBox.Text = HardwareConfigurationBitmap.LaserScanner;
            CameraRearTextBox.Text = HardwareConfigurationBitmap.CameraRear;
            PrinterTextBox.Text = HardwareConfigurationBitmap.Printer;
            TouchscreenTextBox.Text = HardwareConfigurationBitmap.Touchscreen;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            HardwareConfigurationBitmap = new POSLink2.Util.HardwareConfigurationBitmap();
            this.Dispose();
        }
    }
}

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
    public partial class PassThruDataForm : Form
    {
        public enum PassThruTypeEnum
        {
            Fleet,
            Fsa,
            Ewic
        }
        public PassThruTypeEnum PassThruType { get; set; }
        public POSLink2.Util.FleetData[] FleetDatas { get; set; }
        public POSLink2.Util.FsaData FsaData { get; set; }
        public POSLink2.Util.EwicData[] EwicDatas { get; set; }
        private FleetUserControl _fleetUserControl = new FleetUserControl();
        private FsaUserControl _fsaUserControl = new FsaUserControl();
        private EwicUserControl _ewicUserControl = new EwicUserControl();
        private Tools _tools = new Tools();
        public PassThruDataForm()
        {
            InitializeComponent();
            PassThruTypeComboBox.SelectedIndex = 0;
        }

        private void PassThruTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _fleetUserControl.Hide();
            _fsaUserControl.Hide();
            _ewicUserControl.Hide();
            if (PassThruTypeComboBox.SelectedIndex == 0)
            {
                _fleetUserControl.Show();
                PassThruType = PassThruTypeEnum.Fleet;
            }
            else if(PassThruTypeComboBox.SelectedIndex == 1)
            {
                _fsaUserControl.Show();
                PassThruType = PassThruTypeEnum.Fsa;
            }
            else if(PassThruTypeComboBox.SelectedIndex == 2)
            {
                _ewicUserControl.Show();
                PassThruType = PassThruTypeEnum.Ewic;
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if(PassThruTypeComboBox.SelectedIndex == 0)
            {
                if(_fleetUserControl.FleetDataList != null && _fleetUserControl.FleetDataList.Count >0)
                {
                    FleetDatas = _fleetUserControl.FleetDataList.ToArray();
                }
            }
            else if(PassThruTypeComboBox.SelectedIndex == 1)
            {
                if (_fsaUserControl.FsaData != null)
                {
                    FsaData = _fsaUserControl.FsaData;
                }
            }
            else if(PassThruTypeComboBox.SelectedIndex == 2)
            {
                EwicDatas = _ewicUserControl.EwicDataList.ToArray();
            }
            this.DialogResult = DialogResult.OK;
        }

        private void PassThruDataForm_Load(object sender, EventArgs e)
        {
            panel1.Controls.Add(_fleetUserControl);
            panel1.Controls.Add(_fsaUserControl);
            panel1.Controls.Add(_ewicUserControl);
            PassThruTypeComboBox_SelectedIndexChanged(sender, e);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}

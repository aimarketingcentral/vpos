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
    public partial class CustomMacInfoForm : Form
    {
        public string[] CustomMacInfoArray
        {
            get { return _customMacInfoList.ToArray(); }
            set { if(value != null) _customMacInfoList = value.ToList<string>(); }
        }
        private List<string> _customMacInfoList;
        public CustomMacInfoForm()
        {
            InitializeComponent();
            _customMacInfoList = new List<string>();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if(CustomMacInfoTextBox.Text == "")
            {
                MessageBox.Show("Custom MAC information is empty!", "Warning");
                return;
            }
            _customMacInfoList.Add(CustomMacInfoTextBox.Text);
            CustomMacInfoList.Items.Add(CustomMacInfoTextBox.Text);
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if(CustomMacInfoList.SelectedIndex < 0)
            {
                MessageBox.Show("Please select an item!", "Warning");
                return;
            }
            _customMacInfoList.RemoveAt(CustomMacInfoList.SelectedIndex);
            CustomMacInfoList.Items.RemoveAt(CustomMacInfoList.SelectedIndex);
        }

        private void CustomDataForm_Load(object sender, EventArgs e)
        {
            CustomMacInfoList.Items.Clear();
            if(_customMacInfoList.Count>0)
            {
                CustomMacInfoList.Items.AddRange(_customMacInfoList.ToArray());
            }
        }
    }
}

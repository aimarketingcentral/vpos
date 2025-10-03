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
    public partial class CustomDataForm : Form
    {
        public string[] CustomDataArray
        {
            get { return _customDataList.ToArray(); }
            set { if(value != null)_customDataList = value.ToList<string>(); }
        }
        private List<string> _customDataList;
        public CustomDataForm()
        {
            InitializeComponent();
            _customDataList = new List<string>();
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
            if(CustomDataTextBox.Text == "")
            {
                MessageBox.Show("Custom data is empty!", "Warning");
                return;
            }
            _customDataList.Add(CustomDataTextBox.Text);
            CustomDataList.Items.Add(CustomDataTextBox.Text);
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if(CustomDataList.SelectedIndex < 0)
            {
                MessageBox.Show("Please select an item!", "Warning");
                return;
            }
            _customDataList.RemoveAt(CustomDataList.SelectedIndex);
            CustomDataList.Items.RemoveAt(CustomDataList.SelectedIndex);
        }

        private void CustomDataForm_Load(object sender, EventArgs e)
        {
            CustomDataList.Items.Clear();
            if(_customDataList.Count>0)
            {
                CustomDataList.Items.AddRange(_customDataList.ToArray());
            }
        }
    }
}

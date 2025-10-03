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
    public partial class ServiceUsageForm : Form
    {
        private POSLink2.Manage.ServiceUsage _serviceUsage;
        public POSLink2.Manage.ServiceUsage ServiceUsage
        {
            get { return _serviceUsage; }
        }

        private string _displayData;
        public string DisplayData
        {
            get { return _displayData; }
        }

        public ServiceUsageForm()
        {
            InitializeComponent();
            ServiceStateComboBox.SelectedIndex = 0;
            _displayData = "";
            _serviceUsage = new POSLink2.Manage.ServiceUsage();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            _serviceUsage = new POSLink2.Manage.ServiceUsage();
            _serviceUsage.UsageId = ServiceUsageIDTextBox.Text;
            _serviceUsage.State = ServiceStateComboBox.SelectedIndex.ToString();
            _serviceUsage.Title = ServiceTitleTextBox.Text;
            _serviceUsage.Describe = ServiceDescribeTextBox.Text;
            _displayData = "";
            _displayData += _serviceUsage.UsageId + "<RS>";
            _displayData += _serviceUsage.State + "<RS>";
            _displayData += _serviceUsage.Title + "<RS>";
            _displayData += _serviceUsage.Describe;
            _displayData = RemoveUslessSeparator(_displayData, "<RS>");
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }

        private string RemoveUslessSeparator(string message, string separator)
        {
            string des = message;
            while (true)
            {
                if (des.Length < separator.Length)
                {
                    break;
                }
                if (des.LastIndexOf(separator) == des.Length - separator.Length)
                {
                    des = des.Substring(0, des.Length - separator.Length);
                }
                else
                {
                    break;
                }
            }
            return des;
        }
    }
}

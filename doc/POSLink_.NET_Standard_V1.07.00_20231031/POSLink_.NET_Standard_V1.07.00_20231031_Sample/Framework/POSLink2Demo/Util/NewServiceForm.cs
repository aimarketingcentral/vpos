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
    public partial class NewServiceForm : Form
    {
        private POSLink2.Manage.NewService _newService;
        public POSLink2.Manage.NewService NewService
        {
            get { return _newService; }
        }

        private string _displayData;
        public string DisplayData
        {
            get { return _displayData; }
        }

        public NewServiceForm()
        {
            InitializeComponent();
            NewTypeComboBox.SelectedIndex = 0;
            _displayData = "";
            _newService = new POSLink2.Manage.NewService();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            _newService = new POSLink2.Manage.NewService();
            _newService.Type = NewTypeComboBox.SelectedIndex.ToString();
            _newService.Title = NewTitleTextBox.Text;
            _newService.Url = NewURITextBox.Text;

            _displayData = "";
            _displayData += _newService.Type + "<RS>";
            _displayData += _newService.Title + "<RS>";
            _displayData += _newService.Url;
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

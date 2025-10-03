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
    public partial class GoogleSmartTapPushServiceForm : Form
    {
        private string _buttonName;

        private string _googleSmartTapPushServiceData;
        public string GoogleSmartTapPushServiceData
        {
            get { return _googleSmartTapPushServiceData; }
        }

        private ManageData _manageData;
        private List<POSLink2.Manage.ServiceUsage> _serviceUsageList;
        private List<POSLink2.Manage.ServiceUpdate> _serviceUpdateList;
        private List<POSLink2.Manage.NewService> _newServiceList;

        private GoogleSmartTapPushServiceForm()
        {

        }

        public GoogleSmartTapPushServiceForm(string buttonName)
        {
            InitializeComponent();
            _buttonName = buttonName;
            _googleSmartTapPushServiceData = "";
            _manageData = ManageData.GetManageData();
            _serviceUsageList = new List<POSLink2.Manage.ServiceUsage>(0);
            _serviceUpdateList = new List<POSLink2.Manage.ServiceUpdate>(0);
            _newServiceList = new List<POSLink2.Manage.NewService>(0);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if(_buttonName == "ServiceUsage")
            {
                ServiceUsageForm serviceUsageForm = new ServiceUsageForm();
                serviceUsageForm.ShowDialog();
                if(serviceUsageForm.DialogResult == DialogResult.OK)
                {
                    listBox1.Items.Add(serviceUsageForm.DisplayData);
                    _serviceUsageList.Add(serviceUsageForm.ServiceUsage);
                }
                serviceUsageForm.Dispose();
            }
            else if(_buttonName == "ServiceUpdate")
            {
                ServiceUpdateForm serviceUpdateForm = new ServiceUpdateForm();
                serviceUpdateForm.ShowDialog();
                if(serviceUpdateForm.DialogResult == DialogResult.OK)
                {
                    listBox1.Items.Add(serviceUpdateForm.DisplayData);
                    _serviceUpdateList.Add(serviceUpdateForm.ServiceUpdate);
                }
                serviceUpdateForm.Dispose();
            }
            else if(_buttonName == "NewService")
            {
                NewServiceForm newServiceForm = new NewServiceForm();
                newServiceForm.ShowDialog();
                if(newServiceForm.DialogResult == DialogResult.OK)
                {
                    listBox1.Items.Add(newServiceForm.DisplayData);
                    _newServiceList.Add(newServiceForm.NewService);
                }
                newServiceForm.Dispose();
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index < 0)
            {
                return;
            }

            listBox1.Items.RemoveAt(index);
            if (_buttonName == "ServiceUsage")
            {
                _serviceUsageList.RemoveAt(index);
            }
            else if (_buttonName == "ServiceUpdate")
            {
                _serviceUpdateList.RemoveAt(index);
            }
            else if (_buttonName == "NewService")
            {
                _newServiceList.RemoveAt(index);
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (_buttonName == "ServiceUsage")
            {
                _manageData.ServiceUsageReqData = new POSLink2.Manage.ServiceUsage[_serviceUsageList.Count];
                for (int i=0;i< _serviceUsageList.Count;i++)
                {
                    _manageData.ServiceUsageReqData[i] = _serviceUsageList[i];
                    if(i != 0)
                    {
                        _googleSmartTapPushServiceData += "<GS>";
                    }
                    _googleSmartTapPushServiceData += listBox1.Items[i];
                }
            }
            else if (_buttonName == "ServiceUpdate")
            {
                _manageData.ServiceUpdateReqData = new POSLink2.Manage.ServiceUpdate[_serviceUpdateList.Count];
                for(int i=0;i<_serviceUpdateList.Count;i++)
                {
                    _manageData.ServiceUpdateReqData[i] = _serviceUpdateList[i];
                    if(i != 0)
                    {
                        _googleSmartTapPushServiceData += "<GS>";
                    }
                    _googleSmartTapPushServiceData += listBox1.Items[i];
                }
            }
            else if (_buttonName == "NewService")
            {
                _manageData.NewServiceReqData = new POSLink2.Manage.NewService[_newServiceList.Count];
                for(int i=0;i<_newServiceList.Count;i++)
                {
                    _manageData.NewServiceReqData[i] = _newServiceList[i];
                    if(i != 0)
                    {
                        _googleSmartTapPushServiceData += "<GS>";
                    }
                    _googleSmartTapPushServiceData += listBox1.Items[i];
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }

        private void GoogleSmartTapPushServiceForm_Load(object sender, EventArgs e)
        {
            if (_buttonName == "ServiceUsage")
            {
                if (_manageData.ServiceUsageReqData != null)
                {
                    for(int i=0;i<_manageData.ServiceUsageReqData.Length;i++)
                    {
                        _serviceUsageList.Add(_manageData.ServiceUsageReqData[i]);
                        string temp = "";
                        temp += _serviceUsageList[i].UsageId + "<RS>";
                        temp += _serviceUsageList[i].State + "<RS>";
                        temp += _serviceUsageList[i].Title + "<RS>";
                        temp += _serviceUsageList[i].Describe;
                        temp = RemoveUslessSeparator(temp, "<RS>");
                        listBox1.Items.Add(temp);
                    }
                }
            }
            else if (_buttonName == "ServiceUpdate")
            {
                if(_manageData.ServiceUpdateReqData != null)
                {
                    for(int i = 0; i<_manageData.ServiceUpdateReqData.Length;i++)
                    {
                        _serviceUpdateList.Add(_manageData.ServiceUpdateReqData[i]);
                        string temp = "";
                        temp += _serviceUpdateList[i].UpdateId + "<RS>";
                        temp += _serviceUpdateList[i].UpdateOperation + "<RS>";
                        temp += _serviceUpdateList[i].UpdatePayload;
                        temp = RemoveUslessSeparator(temp, "<RS>");
                        listBox1.Items.Add(temp);
                    }
                }
            }
            else if (_buttonName == "NewService")
            {
                if(_manageData.NewServiceReqData != null)
                {
                    for(int i=0;i<_manageData.NewServiceReqData.Length;i++)
                    {
                        _newServiceList.Add(_manageData.NewServiceReqData[i]);
                        string temp = "";
                        temp += _newServiceList[i].Type + "<RS>";
                        temp += _newServiceList[i].Title + "<RS>";
                        temp += _newServiceList[i].Url;
                        temp = RemoveUslessSeparator(temp, "<RS>");
                        listBox1.Items.Add(temp);
                    }
                }
            }
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

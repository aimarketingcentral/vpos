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
    public partial class ShowResponseForm : Form
    {
        private string _buttonName;
        public string ButtonName
        {
            get { return _buttonName; }
            set { _buttonName = value; }
        }

        private ButtonClickEventCommandName? _commandName;
        public ButtonClickEventCommandName? CommandName
        {
            get { return _commandName; }
            set { _commandName = value; }
        }

        private ReportData _reportData;

        public ShowResponseForm()
        {
            InitializeComponent();
            _commandName = null;
            _buttonName = "";
            _reportData = ReportData.GetReportData();
        }

        private void ShowResponseForm_Load(object sender, EventArgs e)
        {
            switch(_commandName)
            {
                case ButtonClickEventCommandName.LocalTotalReportRsp:
                    if(_buttonName == "Credit")
                    {
                        LabelTextBoxUserControl[] labelAndTextBoxs = CreateLabelAndTextBoxs(ReportCommon.CreditTotalDataNames, 394, new Point(0, 2), _reportData.CreditTotalDataRspData);
                        panel1.Controls.AddRange(labelAndTextBoxs);
                    }
                    else if (_buttonName == "Debit")
                    {
                        LabelTextBoxUserControl[] labelAndTextBoxs = CreateLabelAndTextBoxs(ReportCommon.DebitTotalDataNames, 394, new Point(0, 2), _reportData.DebitTotalDataRspData);
                        panel1.Controls.AddRange(labelAndTextBoxs);
                    }
                    else if (_buttonName == "Ebt")
                    {
                        LabelTextBoxUserControl[] labelAndTextBoxs = CreateLabelAndTextBoxs(ReportCommon.EbtTotalDataNames, 394, new Point(0, 2), _reportData.EbtTotalDataRspData);
                        panel1.Controls.AddRange(labelAndTextBoxs);
                    }
                    else if (_buttonName == "Gift")
                    {
                        LabelTextBoxUserControl[] labelAndTextBoxs = CreateLabelAndTextBoxs(ReportCommon.GiftTotalDataNames, 394, new Point(0, 2), _reportData.GiftTotalDataRspData);
                        panel1.Controls.AddRange(labelAndTextBoxs);
                    }
                    else if (_buttonName == "Loyalty")
                    {
                        LabelTextBoxUserControl[] labelAndTextBoxs = CreateLabelAndTextBoxs(ReportCommon.LoyaltyTotalDataNames, 394, new Point(0, 2), _reportData.LoyaltyTotalDataRspData);
                        panel1.Controls.AddRange(labelAndTextBoxs);
                    }
                    else if (_buttonName == "Cash")
                    {
                        LabelTextBoxUserControl[] labelAndTextBoxs = CreateLabelAndTextBoxs(ReportCommon.CashTotalDataNames, 394, new Point(0, 2), _reportData.CashTotalDataRspData);
                        panel1.Controls.AddRange(labelAndTextBoxs);
                    }
                    else if (_buttonName == "Check")
                    {
                        LabelTextBoxUserControl[] labelAndTextBoxs = CreateLabelAndTextBoxs(ReportCommon.CheckTotalDataNames, 394, new Point(0, 2), _reportData.CheckTotalDataRspData);
                        panel1.Controls.AddRange(labelAndTextBoxs);
                    }
                    break;
                case ButtonClickEventCommandName.HistoryReportRsp:
                    if(_buttonName == "TotalCount")
                    {
                        LabelTextBoxUserControl[] labelAndTextBoxs = CreateLabelAndTextBoxs(ReportCommon.HistoryReportTotalCountNames, 394, new Point(0, 2), _reportData.HistoryReportTotalCountRspData);
                        panel1.Controls.AddRange(labelAndTextBoxs);
                    }
                    else if(_buttonName == "TotalAmount")
                    {
                        LabelTextBoxUserControl[] labelAndTextBoxs = CreateLabelAndTextBoxs(ReportCommon.HistoryReportTotalAmountNames, 394, new Point(0, 2), _reportData.HistoryReportTotalAmountRspData);
                        panel1.Controls.AddRange(labelAndTextBoxs);
                    }
                    break;
                case ButtonClickEventCommandName.SAFSummaryReportRsp:
                    if (_buttonName == "TotalCount")
                    {
                        LabelTextBoxUserControl[] labelAndTextBoxs = CreateLabelAndTextBoxs(ReportCommon.SafReportTotalCountNames, 394, new Point(0, 2), _reportData.SafReportTotalCountRspData);
                        panel1.Controls.AddRange(labelAndTextBoxs);
                    }
                    else if (_buttonName == "TotalAmount")
                    {
                        LabelTextBoxUserControl[] labelAndTextBoxs = CreateLabelAndTextBoxs(ReportCommon.SafReportTotalAmountNames, 394, new Point(0, 2), _reportData.SafReportTotalAmountRspData);
                        panel1.Controls.AddRange(labelAndTextBoxs);
                    }
                    break;
                default:
                    break;
            }
        }

        private LabelTextBoxUserControl[] CreateLabelAndTextBoxs(string[,] nameAndText, int width, Point point, string[] value)
        {
            LabelTextBoxUserControl[] temp = new LabelTextBoxUserControl[nameAndText.Length / 2];
            for (int i = 0; i < nameAndText.Length / 2; i++)
            {
                temp[i] = new LabelTextBoxUserControl();
                temp[i].Name = nameAndText[i, 0] + "UserControl";
                temp[i].CreateLabelTextBox(width, nameAndText[i, 0], nameAndText[i, 1], 0.3f);
                temp[i].SetTextBoxValue(value[i]);
                temp[i].Location = point;
                point.Y += temp[i].Height;
            }
            return temp;
        }
    }
}

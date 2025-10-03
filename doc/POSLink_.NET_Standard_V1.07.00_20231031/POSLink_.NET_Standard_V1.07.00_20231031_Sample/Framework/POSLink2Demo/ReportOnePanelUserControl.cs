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
    public partial class ReportOnePanelUserControl : UserControl
    {
        private ReportCommandName _commandName;
        public ReportCommandName CommandName
        {
            get { return _commandName; }
            set { _commandName = value; }
        }

        private ReportData _reportData;
        private Tools _tools = new Tools();
        public ReportOnePanelUserControl()
        {
            InitializeComponent();
            _reportData = ReportData.GetReportData();
        }

        public void ShowPanel(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ValuePanel);
            LabelTextBoxUserControl[] labelAndTextBoxs;
            LabelComboBoxUserControl[] labelAndComboBox;
            ButtonTextBoxUserControl[] buttonTextBoxUserControl;
            switch (_commandName)
            {
                case ReportCommandName.LocalTotalReportReq:
                    labelAndComboBox = new LabelComboBoxUserControl[2];
                    labelAndComboBox[0] = CreateLabelAndComboBox(ReportCommon.LocalTotalReportReqNormalComboBox[0, 0], ReportCommon.LocalTotalReportReqNormalComboBox[0, 1], 394, new Point(0, 2), Global.GetEdcTypeKey(), _reportData.EdcTypeIndex);
                    labelAndComboBox[1] = CreateLabelAndComboBox(ReportCommon.LocalTotalReportReqNormalComboBox[1, 0], ReportCommon.LocalTotalReportReqNormalComboBox[1, 1], 394, new Point(0, 2 + 22), Global.GetCardTypeKey(), _reportData.CardTypeIndex);
                    ValuePanel.Controls.AddRange(labelAndComboBox);
                    break;
                case ReportCommandName.LocalFailedReportReq:
                    break;
                case ReportCommandName.HostReportReq:
                    break;
                case ReportCommandName.HostReportRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(ReportCommon.HostReportRspNormal, 394, new Point(0, 2), _reportData.HostReportRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);

                    string lineMessage = "";
                    if(_reportData.LineMessageRspData != null)
                    {
                        for(int i=0;i<_reportData.LineMessageRspData.Length;i++)
                        {
                            if(i != 0)
                            {
                                lineMessage += "\r\n";
                            }
                            lineMessage += _reportData.LineMessageRspData[i];
                        }
                    }
                    LabelTextBoxUserControl lineMessageUserControl = new LabelTextBoxUserControl();
                    lineMessageUserControl.Name = "LineMessageUserControl";
                    lineMessageUserControl.CreateLabelTextBox(394, "LineMessageRsp", "Line Message", 0.3f);
                    lineMessageUserControl.Height = 67;
                    lineMessageUserControl.SetTextBoxHeight(66);
                    lineMessageUserControl.SetTextBoxValue(lineMessage);
                    lineMessageUserControl.Location = new Point(0, ReportCommon.HostReportRspNormal.Length / 2 * 22 + 2);
                    ValuePanel.Controls.Add(lineMessageUserControl);
                    break;
                case ReportCommandName.HistoryReportReq:
                    break;
                case ReportCommandName.HistoryReportRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(ReportCommon.HistoryReportRspNormal, 394, new Point(0, 2), _reportData.HistoryReportRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);

                    buttonTextBoxUserControl = CreateButtonTextBox(ReportCommon.HistoryReportRspNormalButtonTextBox, 394, new Point(0, ReportCommon.HistoryReportRspNormal.Length / 2 * 22 + 2), _reportData.HistoryReportRspNormalButtonTextBoxData, ButtonClickEventCommandName.HistoryReportRsp);
                    for(int i=0;i<_reportData.HistoryReportRspTextData.Length;i++)
                    {
                        buttonTextBoxUserControl[i].SetTextBoxValue(_reportData.HistoryReportRspTextData[i]);
                    }
                    ValuePanel.Controls.AddRange(buttonTextBoxUserControl);
                    break;
                case ReportCommandName.SAFSummaryReportReq:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(ReportCommon.SafSummaryReportReqNormal, 394, new Point(0, 2), _reportData.SafSummaryReportReqNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case ReportCommandName.SAFSummaryReportRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(ReportCommon.SafSummaryReportRspNormal, 394, new Point(0, 2), _reportData.SafSummaryReportRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);

                    buttonTextBoxUserControl = CreateButtonTextBox(ReportCommon.SafSummaryRspNormalButtonTextBox, 394, new Point(0, ReportCommon.SafSummaryReportRspNormal.Length / 2 * 22 + 2), _reportData.SafSummaryReportRspNormalData, ButtonClickEventCommandName.SAFSummaryReportRsp);
                    for (int i = 0; i < _reportData.SafReportRspTextData.Length; i++)
                    {
                        buttonTextBoxUserControl[i].SetTextBoxValue(_reportData.SafReportRspTextData[i]);
                    }
                    ValuePanel.Controls.AddRange(buttonTextBoxUserControl);
                    break;
                case ReportCommandName.HostDetailReportReq:
                    labelAndComboBox = new LabelComboBoxUserControl[3];
                    labelAndComboBox[0] = CreateLabelAndComboBox(ReportCommon.HostDetailReportReqNormalComboBox[0, 0], ReportCommon.HostDetailReportReqNormalComboBox[0, 1], 394, new Point(0, 2), Global.GetEdcTypeKey(), _reportData.EdcTypeIndex);
                    labelAndComboBox[1] = CreateLabelAndComboBox(ReportCommon.HostDetailReportReqNormalComboBox[1, 0], ReportCommon.HostDetailReportReqNormalComboBox[1, 1], 394, new Point(0, labelAndComboBox[0].Location.Y + labelAndComboBox[0].Height), Global.GetTransTypeKey(), _reportData.TransTypeIndex);
                    labelAndComboBox[2] = CreateLabelAndComboBox(ReportCommon.HostDetailReportReqNormalComboBox[2, 0], ReportCommon.HostDetailReportReqNormalComboBox[2, 1], 394, new Point(0, labelAndComboBox[1].Location.Y + labelAndComboBox[1].Height), Global.GetCardTypeKey(), _reportData.CardTypeIndex);
                    ValuePanel.Controls.AddRange(labelAndComboBox);

                    labelAndTextBoxs = CreateLabelAndTextBoxs(ReportCommon.HostDetailReportReqNormal, 394, new Point(0, labelAndComboBox[2].Location.Y + labelAndComboBox[2].Height), _reportData.HostDetailReportReqNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
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
                temp[i].Leave += new EventHandler(LoseOfFocusTextBoxUserControl);
                point.Y += temp[i].Height;
            }
            return temp;
        }

        private LabelComboBoxUserControl CreateLabelAndComboBox(string name, string text, int width, Point point, string[] items, int index)
        {
            LabelComboBoxUserControl temp = new LabelComboBoxUserControl();
            temp = new LabelComboBoxUserControl();
            temp.Name = name + "UserControl";
            temp.CreateLabelComboBox(width, name, text, items, 0.3f);
            temp.SetComboBoxIndex(index);
            temp.Location = point;
            temp.Leave += new EventHandler(LoseOfFocusComboBoxUserControl);
            return temp;
        }

        private ButtonTextBoxUserControl[] CreateButtonTextBox(string[] name, int width, Point point, string[] value, ButtonClickEventCommandName commandName)
        {
            ButtonTextBoxUserControl[] temp = new ButtonTextBoxUserControl[name.Length];
            for (int i = 0; i < name.Length; i++)
            {
                temp[i] = new ButtonTextBoxUserControl();
                temp[i].CreateButtonTextBox(width, name[i], _reportData.TotalDataRspData[i], 0.3f);
                temp[i].Location = point;
                temp[i].SetTextBoxValue(value[i]);
                temp[i].CommandName = commandName;
                temp[i].ButtonName = name[i];
                point.Y += temp[i].Height;
            }
            return temp;
        }

        private void LoseOfFocusTextBoxUserControl(object sender, EventArgs e)
        {
            LabelTextBoxUserControl userControl = (LabelTextBoxUserControl)sender;
            switch (_commandName)
            {
                case ReportCommandName.SAFSummaryReportReq:
                    for(int i=0;i<ReportCommon.SafSummaryReportReqNormal.Length/2;i++)
                    {
                        if(userControl.Name == ReportCommon.SafSummaryReportReqNormal[i,0] + "UserControl")
                        {
                            _reportData.SafSummaryReportReqNormalData[i] = userControl.GetTextBoxValue();
                        }
                    }
                    break;
                case ReportCommandName.HostDetailReportReq:
                    for (int i = 0; i < ReportCommon.HostDetailReportReqNormal.Length / 2; i++)
                    {
                        if (userControl.Name == ReportCommon.HostDetailReportReqNormal[i, 0] + "UserControl")
                        {
                            _reportData.HostDetailReportReqNormalData[i] = userControl.GetTextBoxValue();
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void LoseOfFocusComboBoxUserControl(object sender, EventArgs e)
        {
            LabelComboBoxUserControl userControl = (LabelComboBoxUserControl)sender;
            switch (_commandName)
            {
                case ReportCommandName.LocalTotalReportReq:
                    if (userControl.Name == ReportCommon.LocalTotalReportReqNormalComboBox[0, 0] + "UserControl")
                    {
                        _reportData.EdcTypeIndex = userControl.GetComboBoxIndex();
                    }
                    else if (userControl.Name == ReportCommon.LocalTotalReportReqNormalComboBox[1, 0] + "UserControl")
                    {
                        _reportData.CardTypeIndex = userControl.GetComboBoxIndex();
                    }
                    break;
                case ReportCommandName.HostDetailReportReq:
                    if (userControl.Name == ReportCommon.HostDetailReportReqNormalComboBox[0, 0] + "UserControl")
                    {
                        _reportData.EdcTypeIndex = userControl.GetComboBoxIndex();
                    }
                    else if (userControl.Name == ReportCommon.HostDetailReportReqNormalComboBox[1, 0] + "UserControl")
                    {
                        _reportData.TransTypeIndex = userControl.GetComboBoxIndex();
                    }
                    else if (userControl.Name == ReportCommon.HostDetailReportReqNormalComboBox[2, 0] + "UserControl")
                    {
                        _reportData.CardTypeIndex = userControl.GetComboBoxIndex();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}

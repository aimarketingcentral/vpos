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
    public partial class FullIntegrationOnePanelUserControl : UserControl
    {
        private FullIntegrationCommandName _commandName;
        public FullIntegrationCommandName CommandName
        {
            get { return _commandName; }
            set { _commandName = value; }
        }

        private FullIntegrationData _fullIntegrationData;
        private Tools _tools = new Tools();
        public FullIntegrationOnePanelUserControl()
        {
            InitializeComponent();
            _fullIntegrationData = FullIntegrationData.GetFullIntegrationData();
        }

        public void ShowPanel(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ValuePanel);
            LabelTextBoxUserControl[] labelAndTextBoxs;
            LabelComboBoxUserControl[] labelAndComboBox;
            Label unitOfTimeout;
            switch (_commandName)
            {
                case FullIntegrationCommandName.GetPinBlockReq:
                    labelAndComboBox = new LabelComboBoxUserControl[2];
                    labelAndComboBox[0] = CreateLabelAndComboBox(FullIntegrationCommon.GetPinBlockReqNormalComboBox[0, 0], FullIntegrationCommon.GetPinBlockReqNormalComboBox[0, 1], 394, new Point(0, 2), Global.GetEdcTypeKey(), _fullIntegrationData.EdcTypeIndex);
                    labelAndComboBox[1] = CreateLabelAndComboBox(FullIntegrationCommon.GetPinBlockReqNormalComboBox[1, 0], FullIntegrationCommon.GetPinBlockReqNormalComboBox[1, 1], 394, new Point(0, 22 + 2), Global.GetTransTypeKey(), _fullIntegrationData.TransTypeIndex);
                    ValuePanel.Controls.AddRange(labelAndComboBox);

                    labelAndTextBoxs = CreateLabelAndTextBoxs(FullIntegrationCommon.GetPinBlockReqNormal, 394, new Point(0, 46), _fullIntegrationData.GetPinBlockReqNormalData);
                    labelAndTextBoxs[7].CreateLabelTextBox(350, "Timeout", "Timeout", 0.335f);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    unitOfTimeout = new Label();
                    unitOfTimeout.AutoSize = true;
                    unitOfTimeout.Text = "100ms";
                    unitOfTimeout.Location = new Point(350, 22 * 9 + 2);
                    ValuePanel.Controls.Add(unitOfTimeout);
                    break;
                case FullIntegrationCommandName.GetPinBlockRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(FullIntegrationCommon.GetPinBlockRspNormal, 394, new Point(0, 2), _fullIntegrationData.GetPinBlockRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case FullIntegrationCommandName.AuthorizeCardRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(FullIntegrationCommon.AuthorizeCardRspNormal, 394, new Point(0, 2), _fullIntegrationData.AuthorizeCardRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case FullIntegrationCommandName.CompleteOnlineEmvReq:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(FullIntegrationCommon.CompleteOnlineEmvReqNormal, 394, new Point(0, 2), _fullIntegrationData.CompleteOnlineEmvReqNormal);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case FullIntegrationCommandName.CompleteOnlineEmvRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(FullIntegrationCommon.CompleteOnlineEmvRspNormal, 394, new Point(0, 2), _fullIntegrationData.CompleteOnlineEmvRspNormal);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case FullIntegrationCommandName.GetEmvTlvDataReq:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(FullIntegrationCommon.GetEmvTlvDataReqNormal, 394, new Point(0, 2), _fullIntegrationData.GetEmvTlvDataReqNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case FullIntegrationCommandName.GetEmvTlvDataRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(FullIntegrationCommon.GetEmvTlvDataRspNormal, 394, new Point(0, 2), _fullIntegrationData.GetEmvTlvDataRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case FullIntegrationCommandName.SetEmvTlvDataReq:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(FullIntegrationCommon.SetEmvTlvDataReqNormal, 394, new Point(0, 2), _fullIntegrationData.SetEmvTlvDataReqNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case FullIntegrationCommandName.SetEmvTlvDataRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(FullIntegrationCommon.SetEmvTlvDataRspNormal, 394, new Point(0, 2), _fullIntegrationData.SetEmvTlvDataRspNormalData);
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
                float proportion = 0.3f;
                if (width < 300)
                {
                    proportion = 0.4f;
                }
                temp[i].CreateLabelTextBox(width, nameAndText[i, 0], nameAndText[i, 1], proportion);
                temp[i].SetTextBoxValue(value[i]);
                temp[i].Location = point;
                temp[i].Leave += new EventHandler(LoseOfFocusTextBoxUserControl);
                point.Y += 22;
            }
            return temp;
        }

        private void LoseOfFocusTextBoxUserControl(object sender, EventArgs e)
        {
            LabelTextBoxUserControl userControl = (LabelTextBoxUserControl)sender;
            switch (_commandName)
            {
                case FullIntegrationCommandName.GetPinBlockReq:
                    for (int i = 0; i < FullIntegrationCommon.GetPinBlockReqNormal.Length / 2; i++)
                    {
                        if (userControl.Name == FullIntegrationCommon.GetPinBlockReqNormal[i, 0] + "UserControl")
                        {
                            _fullIntegrationData.GetPinBlockReqNormalData[i] = userControl.GetTextBoxValue();
                        }
                    }
                    break;
                case FullIntegrationCommandName.CompleteOnlineEmvReq:
                    for (int i = 0; i < FullIntegrationCommon.CompleteOnlineEmvReqNormal.Length / 2; i++)
                    {
                        if (userControl.Name == FullIntegrationCommon.CompleteOnlineEmvReqNormal[i, 0] + "UserControl")
                        {
                            _fullIntegrationData.CompleteOnlineEmvReqNormal[i] = userControl.GetTextBoxValue();
                        }
                    }
                    break;
                case FullIntegrationCommandName.GetEmvTlvDataReq:
                    for (int i = 0; i < FullIntegrationCommon.GetEmvTlvDataReqNormal.Length / 2; i++)
                    {
                        if (userControl.Name == FullIntegrationCommon.GetEmvTlvDataReqNormal[i, 0] + "UserControl")
                        {
                            _fullIntegrationData.GetEmvTlvDataReqNormalData[i] = userControl.GetTextBoxValue();
                        }
                    }
                    break;
                case FullIntegrationCommandName.SetEmvTlvDataReq:
                    for (int i = 0; i < FullIntegrationCommon.SetEmvTlvDataReqNormal.Length / 2; i++)
                    {
                        if (userControl.Name == FullIntegrationCommon.SetEmvTlvDataReqNormal[i, 0] + "UserControl")
                        {
                            _fullIntegrationData.SetEmvTlvDataReqNormalData[i] = userControl.GetTextBoxValue();
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private LabelComboBoxUserControl CreateLabelAndComboBox(string name, string text, int width, Point point, string[] items, int index)
        {
            LabelComboBoxUserControl temp = new LabelComboBoxUserControl();
            temp = new LabelComboBoxUserControl();
            temp.Name = name + "UserControl";
            float proportion = 0.3f;
            if (width < 300)
            {
                proportion = 0.4f;
            }
            temp.CreateLabelComboBox(width, name, text, items, proportion);
            temp.SetComboBoxIndex(index);
            temp.Location = point;
            temp.Leave += new EventHandler(LoseOfFocusComboBoxUserControl);
            return temp;
        }

        private void LoseOfFocusComboBoxUserControl(object sender, EventArgs e)
        {
            LabelComboBoxUserControl userControl = (LabelComboBoxUserControl)sender;
            switch (_commandName)
            {
                case FullIntegrationCommandName.InputAccountWithEmvReq:
                case FullIntegrationCommandName.GetPinBlockReq:
                    if (userControl.Name == "EdcTypeUserControl")
                    {
                        _fullIntegrationData.EdcTypeIndex = userControl.GetComboBoxIndex();
                    }
                    else if (userControl.Name == "TransactionTypeUserControl")
                    {
                        _fullIntegrationData.TransTypeIndex = userControl.GetComboBoxIndex();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}

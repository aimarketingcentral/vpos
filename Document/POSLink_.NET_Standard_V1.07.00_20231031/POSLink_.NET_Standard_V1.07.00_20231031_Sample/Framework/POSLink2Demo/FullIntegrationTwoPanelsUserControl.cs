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
    public partial class FullIntegrationTwoPanelsUserControl : UserControl
    {
        private FullIntegrationCommandName _commandName;
        public FullIntegrationCommandName CommandName
        {
            get { return _commandName; }
            set { _commandName = value; }
        }

        private FullIntegrationData _fullIntegrationData;
        private Tools _tools = new Tools();
        public FullIntegrationTwoPanelsUserControl()
        {
            InitializeComponent();
            _fullIntegrationData = FullIntegrationData.GetFullIntegrationData();
        }

        Button[] _buttonArray;
        public void ShowButton(object sender, EventArgs e)
        {
            int buttonCount;
            _tools.DisposeSubControls(ButtonPanel);
            _tools.DisposeSubControls(ValuePanel);
            int locationHeight = 0;
            switch (_commandName)
            {
                case FullIntegrationCommandName.AuthorizeCardReq:
                    buttonCount = FullIntegrationCommon.AuthorizeCardReqButtonNames.Length;
                    _buttonArray = new Button[buttonCount];
                    for (int i = 0; i < buttonCount; i++)
                    {
                        bool isHeightNotEnough = false;
                        if (i == 2)
                        {
                            isHeightNotEnough = true;
                        }
                        _buttonArray[i] = Tools.CreateButton(FullIntegrationCommon.AuthorizeCardReqButtonNames[i], new Point(0, locationHeight), isHeightNotEnough);
                        locationHeight += _buttonArray[i].Height - 1;
                    }
                    _buttonArray[0].Click += new EventHandler(NormalReqClick);
                    _buttonArray[1].Click += new EventHandler(AmountInfoReqClick);
                    _buttonArray[2].Click += new EventHandler(TerminalConfigurationReqClick);
                    NormalReqClick(sender, e);
                    break;
                case FullIntegrationCommandName.InputAccountWithEmvReq:
                    buttonCount = FullIntegrationCommon.InputAccountWithEmvReqButtonNames.Length;
                    _buttonArray = new Button[buttonCount];
                    for (int i = 0; i < buttonCount; i++)
                    {
                        bool isHeightNotEnough = false;
                        if (i == 2 || i == 3||i == 4)
                        {
                            isHeightNotEnough = true;
                        }
                        _buttonArray[i] = Tools.CreateButton(FullIntegrationCommon.InputAccountWithEmvReqButtonNames[i], new Point(0, locationHeight), isHeightNotEnough);
                        locationHeight += _buttonArray[i].Height - 1;
                    }
                    _buttonArray[0].Click += new EventHandler(NormalReqClick);
                    _buttonArray[1].Click += new EventHandler(AmountInfoReqClick);
                    _buttonArray[2].Click += new EventHandler(AdditionalPromptsReqClick);
                    _buttonArray[3].Click += new EventHandler(TerminalConfigurationReqClick);
                    _buttonArray[4].Click += new EventHandler(CustomMacInfoReqClick);
                    NormalReqClick(sender, e);
                    break;
                case FullIntegrationCommandName.InputAccountWithEmvRsp:
                    buttonCount = FullIntegrationCommon.InputAccountWithEmvRspButtonNames.Length;
                    _buttonArray = new Button[buttonCount];
                    for (int i = 0; i < buttonCount; i++)
                    {
                        bool isHeightNotEnough = false;
                        if (i == 1)
                        {
                            isHeightNotEnough = true;
                        }
                        _buttonArray[i] = Tools.CreateButton(FullIntegrationCommon.InputAccountWithEmvRspButtonNames[i], new Point(0, locationHeight), isHeightNotEnough);
                        locationHeight += _buttonArray[i].Height - 1;
                    }
                    _buttonArray[0].Click += new EventHandler(NormalRspClick);
                    _buttonArray[1].Click += new EventHandler(AdditionalAccountRspClick);
                    _buttonArray[2].Click += new EventHandler(VasInfoRspClick);
                    _buttonArray[3].Click += new EventHandler(CustomMacDataRspClick);
                    NormalRspClick(sender, e);
                    break;
                default:
                    break;
            }
            ButtonPanel.Controls.AddRange(_buttonArray);
        }

        //Reqeust----------------------------------------------------------------------------------------
        private void NormalReqClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ValuePanel);
            LabelTextBoxUserControl[] labelAndTextBoxs;
            LabelComboBoxUserControl[] labelAndComboBox;
            Label unitOfTimeout;
            LabelTextBoxUserControl[] amountInfoInNormal;
            switch (_commandName)
            {
                case FullIntegrationCommandName.AuthorizeCardReq:
                    amountInfoInNormal = new LabelTextBoxUserControl[2];
                    amountInfoInNormal[0] = new LabelTextBoxUserControl();
                    amountInfoInNormal[0].Name = FullIntegrationCommon.AmountInfoReq[0, 0] + "UserControl";
                    amountInfoInNormal[0].CreateLabelTextBox(294, FullIntegrationCommon.AmountInfoReq[0,0], FullIntegrationCommon.AmountInfoReq[0, 1], 0.4f);
                    amountInfoInNormal[0].SetTextBoxValue(_fullIntegrationData.AmountInfoReqData[0]);
                    amountInfoInNormal[0].Location = new Point(0, 2);
                    amountInfoInNormal[0].Leave += new EventHandler(LoseOfFocusTextBoxUserControl);
                    amountInfoInNormal[1] = new LabelTextBoxUserControl();
                    amountInfoInNormal[1].Name = FullIntegrationCommon.AmountInfoReq[2, 0] + "UserControl";
                    amountInfoInNormal[1].CreateLabelTextBox(294, FullIntegrationCommon.AmountInfoReq[2, 0], FullIntegrationCommon.AmountInfoReq[2, 1], 0.4f);
                    amountInfoInNormal[1].SetTextBoxValue(_fullIntegrationData.AmountInfoReqData[2]);
                    amountInfoInNormal[1].Location = new Point(0, 22+2);
                    amountInfoInNormal[1].Leave += new EventHandler(LoseOfFocusTextBoxUserControl);
                    ValuePanel.Controls.AddRange(amountInfoInNormal);

                    labelAndTextBoxs = CreateLabelAndTextBoxs(FullIntegrationCommon.AuthorizeCardReqNormal, 294, new Point(0, 22*2+2), _fullIntegrationData.AuthorizeCardReqNormalData);
                    labelAndTextBoxs[8].CreateLabelTextBox(250, "Timeout", "Timeout", 0.47f);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    unitOfTimeout = new Label();
                    unitOfTimeout.AutoSize = true;
                    unitOfTimeout.Text = "100ms";
                    unitOfTimeout.Location = new Point(250, 10 * 22 + 2);
                    ValuePanel.Controls.Add(unitOfTimeout);
                    break;
                case FullIntegrationCommandName.InputAccountWithEmvReq:
                    int width = 294;
                    labelAndComboBox = new LabelComboBoxUserControl[3];
                    labelAndComboBox[0] = CreateLabelAndComboBox(FullIntegrationCommon.InputAccountWithEmvReqNormalComboBox[0, 0], FullIntegrationCommon.InputAccountWithEmvReqNormalComboBox[0, 1], width, new Point(0, 2), Global.GetEdcTypeKey(), _fullIntegrationData.EdcTypeIndex);
                    labelAndComboBox[1] = CreateLabelAndComboBox(FullIntegrationCommon.InputAccountWithEmvReqNormalComboBox[1, 0], FullIntegrationCommon.InputAccountWithEmvReqNormalComboBox[1, 1], width, new Point(0, 2 + 22), Global.GetTransTypeKey(), _fullIntegrationData.TransTypeIndex);
                    ValuePanel.Controls.AddRange(labelAndComboBox);

                    amountInfoInNormal = new LabelTextBoxUserControl[2];
                    amountInfoInNormal[0] = new LabelTextBoxUserControl();
                    amountInfoInNormal[0].Name = FullIntegrationCommon.AmountInfoReq[0, 0] + "UserControl";
                    amountInfoInNormal[0].CreateLabelTextBox(width, FullIntegrationCommon.AmountInfoReq[0, 0], FullIntegrationCommon.AmountInfoReq[0, 1], 0.45f);
                    amountInfoInNormal[0].SetTextBoxValue(_fullIntegrationData.AmountInfoReqData[0]);
                    amountInfoInNormal[0].Location = new Point(0, 2*22+2);
                    amountInfoInNormal[0].Leave += new EventHandler(LoseOfFocusTextBoxUserControl);
                    amountInfoInNormal[1] = new LabelTextBoxUserControl();
                    amountInfoInNormal[1].Name = FullIntegrationCommon.AmountInfoReq[2, 0] + "UserControl";
                    amountInfoInNormal[1].CreateLabelTextBox(width, FullIntegrationCommon.AmountInfoReq[2, 0], FullIntegrationCommon.AmountInfoReq[2, 1], 0.45f);
                    amountInfoInNormal[1].SetTextBoxValue(_fullIntegrationData.AmountInfoReqData[2]);
                    amountInfoInNormal[1].Location = new Point(0, 3 * 22 + 2);
                    amountInfoInNormal[1].Leave += new EventHandler(LoseOfFocusTextBoxUserControl);
                    ValuePanel.Controls.AddRange(amountInfoInNormal);

                    labelAndTextBoxs = CreateLabelAndTextBoxs(FullIntegrationCommon.InputAccountWithEmvReqNormal, width, new Point(0, 4 * 22 + 2), _fullIntegrationData.InputAccountWithEmvReqNormal);
                    labelAndTextBoxs[15].CreateLabelTextBox(width-44, "Timeout", "Timeout", 0.53f);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    unitOfTimeout = new Label();
                    unitOfTimeout.AutoSize = true;
                    unitOfTimeout.Text = "100ms";
                    unitOfTimeout.Location = new Point(width-44, 19 * 22 + 2);
                    ValuePanel.Controls.Add(unitOfTimeout);

                    Button setCustomDataButton = new Button();
                    setCustomDataButton.Text = "Set Custom Data";
                    setCustomDataButton.Width = labelAndTextBoxs[labelAndTextBoxs.Length - 1].Width;
                    setCustomDataButton.Location = new Point(labelAndTextBoxs[labelAndTextBoxs.Length - 1].Location.X, labelAndTextBoxs[labelAndTextBoxs.Length - 1].Location.Y + labelAndTextBoxs[labelAndTextBoxs.Length - 1].Height);
                    setCustomDataButton.Click +=new EventHandler(SetCustomDataClick);
                    ValuePanel.Controls.Add(setCustomDataButton);

                    break;
                default:
                    break;
            }
        }

        private void AmountInfoReqClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ValuePanel);
            LabelTextBoxUserControl[] labelAndTextBoxs = CreateLabelAndTextBoxs(FullIntegrationCommon.AmountInfoReq, 294, new Point(0, 2), _fullIntegrationData.AmountInfoReqData);
            ValuePanel.Controls.AddRange(labelAndTextBoxs);
        }

        private void AdditionalPromptsReqClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ValuePanel);
            LabelTextBoxUserControl[] labelAndTextBoxs = CreateLabelAndTextBoxs(FullIntegrationCommon.AdditionalPromptsReq, 294, new Point(0, 2), _fullIntegrationData.AdditionalPromptsReqData);
            ValuePanel.Controls.AddRange(labelAndTextBoxs);
        }

        private void TerminalConfigurationReqClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ValuePanel);
            LabelTextBoxUserControl[] labelAndTextBoxs = CreateLabelAndTextBoxs(FullIntegrationCommon.TerminalConfigurationReq, 294, new Point(0, 2), _fullIntegrationData.TerminalConfigurationReqData);
            ValuePanel.Controls.AddRange(labelAndTextBoxs);
        }

        private void CustomMacInfoReqClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ValuePanel);
            LabelTextBoxUserControl[] labelAndTextBoxs = CreateLabelAndTextBoxs(FullIntegrationCommon.CustomMacInfoReq, 294, new Point(0, 2), _fullIntegrationData.CustomMacInfoReqData);
            ValuePanel.Controls.AddRange(labelAndTextBoxs);

            Button setCustomDataButton = new Button();
            setCustomDataButton.Text = "Set Custom MAC Information";
            setCustomDataButton.Width = labelAndTextBoxs[labelAndTextBoxs.Length - 1].Width;
            setCustomDataButton.Location = new Point(labelAndTextBoxs[labelAndTextBoxs.Length - 1].Location.X, labelAndTextBoxs[labelAndTextBoxs.Length - 1].Location.Y + labelAndTextBoxs[labelAndTextBoxs.Length - 1].Height);
            setCustomDataButton.Click += new EventHandler(SetCustomMacDataClick);
            ValuePanel.Controls.Add(setCustomDataButton);
        }

        //Response-----------------------------------------------------------------------------------------------
        private void NormalRspClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ValuePanel);
            LabelTextBoxUserControl[] labelAndTextBoxs;
            switch (_commandName)
            {
                case FullIntegrationCommandName.InputAccountWithEmvRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(FullIntegrationCommon.InputAccountWithEmvRspNormal, 294, new Point(0, 2), _fullIntegrationData.InputAccountWithEmvRspNormal);
                    labelAndTextBoxs[labelAndTextBoxs.Length - 1].SetTextBoxHeight(60);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                default:
                    break;
            }
        }

        private void AdditionalAccountRspClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ValuePanel);
            LabelTextBoxUserControl[] labelAndTextBoxs = CreateLabelAndTextBoxs(FullIntegrationCommon.AdditionalAccountRsp, 294, new Point(0, 2), _fullIntegrationData.AdditionalAccountRspData);
            ValuePanel.Controls.AddRange(labelAndTextBoxs);
        }

        private void VasInfoRspClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ValuePanel);
            LabelTextBoxUserControl[] labelAndTextBoxs = CreateLabelAndTextBoxs(FullIntegrationCommon.VasInfoRsp, 294, new Point(0, 2), _fullIntegrationData.VasInfoRspData);
            ValuePanel.Controls.AddRange(labelAndTextBoxs);
        }

        private void CustomMacDataRspClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ValuePanel);
            LabelTextBoxUserControl[] labelAndTextBoxs = CreateLabelAndTextBoxs(FullIntegrationCommon.CustomMacDataRsp, 294, new Point(0, 2), _fullIntegrationData.CustomMacDataRspData);
            ValuePanel.Controls.AddRange(labelAndTextBoxs);
        }

        //Create Controls------------------------------------------------------------------------------------------
        private Button CreateButton(string text, Point point, bool isHeightNotEnough)
        {
            Button button = new Button();
            button.Width = 98;
            button.Location = point;
            button.Text = text;
            if (isHeightNotEnough)
            {
                button.Height = (int)(button.Height * 1.8);
            }
            return button;
        }

        private LabelTextBoxUserControl[] CreateLabelAndTextBoxs(string[,] nameAndText, int width, Point point, string[] value)
        {
            LabelTextBoxUserControl[] temp = new LabelTextBoxUserControl[nameAndText.Length / 2];
            for (int i = 0; i < nameAndText.Length / 2; i++)
            {
                temp[i] = new LabelTextBoxUserControl();
                temp[i].Name = nameAndText[i, 0] + "UserControl";
                float proporation = 0.4f;
                if(_commandName == FullIntegrationCommandName.InputAccountWithEmvReq || _commandName == FullIntegrationCommandName.InputAccountWithEmvRsp)
                {
                    proporation = 0.45f;
                }
                temp[i].CreateLabelTextBox(width, nameAndText[i, 0], nameAndText[i, 1], proporation);
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
            float proporation = 0.4f;
            if (_commandName == FullIntegrationCommandName.InputAccountWithEmvReq)
            {
                proporation = 0.45f;
            }
            temp.CreateLabelComboBox(width, name, text, items, proporation);
            temp.SetComboBoxIndex(index);
            temp.Location = point;
            temp.Leave += new EventHandler(LoseOfFocusComboBoxUserControl);
            return temp;
        }

        private void LoseOfFocusTextBoxUserControl(object sender, EventArgs e)
        {
            LabelTextBoxUserControl userControl = (LabelTextBoxUserControl)sender;
            switch (_commandName)
            {
                case FullIntegrationCommandName.AuthorizeCardReq:
                    for(int i=0;i<FullIntegrationCommon.AuthorizeCardReqNormal.Length/2;i++)
                    {
                        if(userControl.Name == FullIntegrationCommon.AuthorizeCardReqNormal[i,0] + "UserControl")
                        {
                            _fullIntegrationData.AuthorizeCardReqNormalData[i] = userControl.GetTextBoxValue();
                        }
                    }
                    for (int i = 0; i < FullIntegrationCommon.AmountInfoReq.Length / 2; i++)
                    {
                        if (userControl.Name == FullIntegrationCommon.AmountInfoReq[i, 0] + "UserControl")
                        {
                            _fullIntegrationData.AmountInfoReqData[i] = userControl.GetTextBoxValue();
                        }
                    }
                    for (int i = 0; i < FullIntegrationCommon.TerminalConfigurationReq.Length / 2; i++)
                    {
                        if (userControl.Name == FullIntegrationCommon.TerminalConfigurationReq[i, 0] + "UserControl")
                        {
                            _fullIntegrationData.TerminalConfigurationReqData[i] = userControl.GetTextBoxValue();
                        }
                    }
                    break;
                case FullIntegrationCommandName.InputAccountWithEmvReq:
                    for (int i = 0; i < FullIntegrationCommon.InputAccountWithEmvReqNormal.Length / 2; i++)
                    {
                        if (userControl.Name == FullIntegrationCommon.InputAccountWithEmvReqNormal[i, 0] + "UserControl")
                        {
                            _fullIntegrationData.InputAccountWithEmvReqNormal[i] = userControl.GetTextBoxValue();
                        }
                    }
                    for (int i = 0; i < FullIntegrationCommon.AmountInfoReq.Length / 2; i++)
                    {
                        if (userControl.Name == FullIntegrationCommon.AmountInfoReq[i, 0] + "UserControl")
                        {
                            _fullIntegrationData.AmountInfoReqData[i] = userControl.GetTextBoxValue();
                        }
                    }
                    for (int i = 0; i < FullIntegrationCommon.AdditionalPromptsReq.Length / 2; i++)
                    {
                        if (userControl.Name == FullIntegrationCommon.AdditionalPromptsReq[i, 0] + "UserControl")
                        {
                            _fullIntegrationData.AdditionalPromptsReqData[i] = userControl.GetTextBoxValue();
                        }
                    }
                    for (int i = 0; i < FullIntegrationCommon.TerminalConfigurationReq.Length / 2; i++)
                    {
                        if (userControl.Name == FullIntegrationCommon.TerminalConfigurationReq[i, 0] + "UserControl")
                        {
                            _fullIntegrationData.TerminalConfigurationReqData[i] = userControl.GetTextBoxValue();
                        }
                    }
                    for (int i = 0; i < FullIntegrationCommon.CustomMacInfoReq.Length / 2; i++)
                    {
                        if (userControl.Name == FullIntegrationCommon.CustomMacInfoReq[i, 0] + "UserControl")
                        {
                            _fullIntegrationData.CustomMacInfoReqData[i] = userControl.GetTextBoxValue();
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
                case FullIntegrationCommandName.InputAccountWithEmvReq:
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

        private void SetCustomDataClick(object sender, EventArgs e)
        {
            FullIntegrationData fullIntegrationData = FullIntegrationData.GetFullIntegrationData();
            CustomDataForm customDataForm = new CustomDataForm();
            customDataForm.CustomDataArray = fullIntegrationData.CustomDataArray;
            if(customDataForm.ShowDialog() == DialogResult.OK)
            {
                fullIntegrationData.CustomDataArray = customDataForm.CustomDataArray;
            }
            customDataForm.Dispose();
        }

        private void SetCustomMacDataClick(object sender, EventArgs e)
        {
            FullIntegrationData fullIntegrationData = FullIntegrationData.GetFullIntegrationData();
            CustomMacInfoForm customMacInfoForm = new CustomMacInfoForm();
            customMacInfoForm.CustomMacInfoArray = fullIntegrationData.CustomMacDataArray;
            if (customMacInfoForm.ShowDialog() == DialogResult.OK)
            {
                fullIntegrationData.CustomMacDataArray = customMacInfoForm.CustomMacInfoArray;
            }
            customMacInfoForm.Dispose();
        }
    }
}

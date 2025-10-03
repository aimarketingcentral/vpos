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
    public partial class ManageTwoPanelsUserControl : UserControl
    {
        private enum Module
        {
            Normal,
            MultiMerchant
        }

        private ManageCommandName _commandName;
        public ManageCommandName CommandName
        {
            get { return _commandName; }
            set { _commandName = value; }
        }

        private Module _moduleSelect;

        private ManageData _manageData;
        private Tools _tools = new Tools();
        public ManageTwoPanelsUserControl()
        {
            InitializeComponent();
            _manageData = ManageData.GetManageData();
        }

        Button[] _buttonArray;
        public void ShowButton(object sender, EventArgs e)
        {
            ButtonPanel.SuspendLayout();
            ValuePanel.SuspendLayout();
            int buttonCount;
            _tools.DisposeSubControls(ButtonPanel);
            _tools.DisposeSubControls(ValuePanel);
            int locationHeight = 0;
            int exHeight = 0;
            switch (_commandName)
            {
                case ManageCommandName.GetVariableReq:
                    buttonCount = ManageCommon.GetVariableReqButtonNames.Length;
                    _buttonArray = new Button[buttonCount];
                    for (int i = 0; i < buttonCount; i++)
                    {
                        bool isHeightNotEnough = false;
                        _buttonArray[i] = Tools.CreateButton(ManageCommon.GetVariableReqButtonNames[i], new Point(0, locationHeight), isHeightNotEnough);
                        locationHeight += _buttonArray[i].Height - 1;
                    }
                    _buttonArray[0].Click += new EventHandler(NormalRequestClick);
                    _buttonArray[1].Click += new EventHandler(MultiMerchantReqClick);
                    NormalRequestClick(sender, e);
                    break;
                case ManageCommandName.GetVariableRsp:
                    buttonCount = ManageCommon.GetVariableRspButtonNames.Length;
                    _buttonArray = new Button[buttonCount];
                    for (int i = 0; i < buttonCount; i++)
                    {
                        bool isHeightNotEnough = false;
                        _buttonArray[i] = Tools.CreateButton(ManageCommon.GetVariableRspButtonNames[i], new Point(0, locationHeight), isHeightNotEnough);
                        locationHeight += _buttonArray[i].Height - 1;
                    }
                    _buttonArray[0].Click += new EventHandler(NormalResponseClick);
                    _buttonArray[1].Click += new EventHandler(MultiMerchantRspClick);
                    NormalResponseClick(sender, e);
                    break;
                case ManageCommandName.SetVariableReq:
                    buttonCount = ManageCommon.SetVariableReqButtonNames.Length;
                    _buttonArray = new Button[buttonCount];
                    for (int i = 0; i < buttonCount; i++)
                    {
                        bool isHeightNotEnough = false;
                        _buttonArray[i] = Tools.CreateButton(ManageCommon.SetVariableReqButtonNames[i], new Point(0, locationHeight), isHeightNotEnough);
                        locationHeight += _buttonArray[i].Height - 1;
                    }
                    _buttonArray[0].Click += new EventHandler(NormalRequestClick);
                    _buttonArray[1].Click += new EventHandler(MultiMerchantReqClick);
                    NormalRequestClick(sender, e);
                    break;
                case ManageCommandName.SetVariableRsp:
                    buttonCount = ManageCommon.SetVariableRspButtonNames.Length;
                    _buttonArray = new Button[buttonCount];
                    for (int i = 0; i < buttonCount; i++)
                    {
                        bool isHeightNotEnough = false;
                        _buttonArray[i] = Tools.CreateButton(ManageCommon.SetVariableRspButtonNames[i], new Point(0, locationHeight), isHeightNotEnough);
                        locationHeight += _buttonArray[i].Height - 1;
                    }
                    _buttonArray[0].Click += new EventHandler(NormalResponseClick);
                    _buttonArray[1].Click += new EventHandler(MultiMerchantRspClick);
                    NormalResponseClick(sender, e);
                    break;
                default:
                    break;
            }
            ButtonPanel.Controls.AddRange(_buttonArray);
            ButtonPanel.ResumeLayout();
            ValuePanel.ResumeLayout();
        }

        //Request---------------------------------------------------------------------------------------------------
        private void NormalRequestClick(object sender, EventArgs e)
        {
            _moduleSelect = Module.Normal;
            _tools.DisposeSubControls(ValuePanel);
            LabelTextBoxUserControl[] labelAndTextBoxs;
            LabelComboBoxUserControl[] labelComboBoxUserControl;
            switch (_commandName)
            {
                case ManageCommandName.GetVariableReq:
                    labelComboBoxUserControl = new LabelComboBoxUserControl[1];
                    labelComboBoxUserControl[0] = CreateLabelAndComboBox(ManageCommon.GetVariableReqNormalComboBox[0, 0], ManageCommon.GetVariableReqNormalComboBox[0, 1], 294, new Point(0, 2), Global.GetEdcTypeKey(), _manageData.EdcTypeIndex);
                    ValuePanel.Controls.AddRange(labelComboBoxUserControl);

                    labelAndTextBoxs = CreateLabelAndTextBoxs(ManageCommon.GetVariableReqNormal, 294, new Point(0, 24), _manageData.GetVariableReqNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case ManageCommandName.SetVariableReq:
                    labelComboBoxUserControl = new LabelComboBoxUserControl[1];
                    labelComboBoxUserControl[0] = CreateLabelAndComboBox(ManageCommon.SetVariableReqNormalComboBox[0, 0], ManageCommon.SetVariableReqNormalComboBox[0, 1], 294, new Point(0, 2), Global.GetEdcTypeKey(), _manageData.EdcTypeIndex);
                    ValuePanel.Controls.AddRange(labelComboBoxUserControl);

                    labelAndTextBoxs = CreateLabelAndTextBoxs(ManageCommon.SetVariableReqNormal, 294, new Point(0, 24), _manageData.SetVariableReqNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                default:
                    break;
            }
        }

        private void MultiMerchantReqClick(object sender, EventArgs e)
        {
            _moduleSelect = Module.MultiMerchant;
            _tools.DisposeSubControls(ValuePanel);
            LabelTextBoxUserControl[] labelAndTextBoxs = CreateLabelAndTextBoxs(ManageCommon.MultiMerchantNames, 294, new Point(0, 2), _manageData.MultiMerchantReqData);
            ValuePanel.Controls.AddRange(labelAndTextBoxs);
        }
        //Response-------------------------------------------------------------------------------------------------
        private void NormalResponseClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ValuePanel);
            LabelTextBoxUserControl[] labelAndTextBoxs;
            switch (_commandName)
            {
                case ManageCommandName.GetVariableRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(ManageCommon.GetVariableRspNormal, 294, new Point(0, 2), _manageData.GetVariableRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case ManageCommandName.SetVariableRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(ManageCommon.SetVariableRspNormal, 294, new Point(0, 2), _manageData.SetVariableRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                default:
                    break;
            }
        }

        private void MultiMerchantRspClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ValuePanel);
            LabelTextBoxUserControl[] labelAndTextBoxs = CreateLabelAndTextBoxs(ManageCommon.MultiMerchantNames, 294, new Point(0, 2), _manageData.MultiMerchantRspData);
            ValuePanel.Controls.AddRange(labelAndTextBoxs);
        }

        //Create Controls------------------------------------------------------------------------------------------
        private LabelTextBoxUserControl[] CreateLabelAndTextBoxs(string[,] nameAndText, int width, Point point, string[] value)
        {
            LabelTextBoxUserControl[] temp = new LabelTextBoxUserControl[nameAndText.Length / 2];
            for (int i = 0; i < nameAndText.Length / 2; i++)
            {
                temp[i] = new LabelTextBoxUserControl();
                temp[i].Name = nameAndText[i, 0] + "UserControl";
                temp[i].CreateLabelTextBox(width, nameAndText[i, 0], nameAndText[i, 1], 0.4f);
                temp[i].SetTextBoxValue(value[i]);
                temp[i].Location = point;
                temp[i].Leave += new EventHandler(LoseOfFocusTextBoxUserControl);
                point.Y += 22;
            }
            return temp;
        }

        private LabelComboBoxUserControl CreateLabelAndComboBox(string name, string text, int width, Point point, string[] items, int index)
        {
            LabelComboBoxUserControl temp = new LabelComboBoxUserControl();
            temp = new LabelComboBoxUserControl();
            temp.Name = name + "UserControl";
            temp.CreateLabelComboBox(width, name, text, items, 0.4f);
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
                case ManageCommandName.GetVariableReq:
                    if(_moduleSelect == Module.Normal)
                    {
                        for(int i=0;i<ManageCommon.GetVariableReqNormal.Length/2;i++)
                        {
                            if(userControl.Name == ManageCommon.GetVariableReqNormal[i,0]+ "UserControl")
                            {
                                _manageData.GetVariableReqNormalData[i] = userControl.GetTextBoxValue();
                            }
                        }
                    }
                    else if(_moduleSelect == Module.MultiMerchant)
                    {
                        for(int i=0;i<ManageCommon.MultiMerchantNames.Length/2;i++)
                        {
                            if(userControl.Name == ManageCommon.MultiMerchantNames[i,0] + "UserControl")
                            {
                                _manageData.MultiMerchantReqData[i] = userControl.GetTextBoxValue();
                            }
                        }
                    }
                    break;
                case ManageCommandName.SetVariableReq:
                    if (_moduleSelect == Module.Normal)
                    {
                        for (int i = 0; i < ManageCommon.SetVariableReqNormal.Length / 2; i++)
                        {
                            if (userControl.Name == ManageCommon.SetVariableReqNormal[i, 0] + "UserControl")
                            {
                                _manageData.SetVariableReqNormalData[i] = userControl.GetTextBoxValue();
                            }
                        }
                    }
                    else if (_moduleSelect == Module.MultiMerchant)
                    {
                        for (int i = 0; i < ManageCommon.MultiMerchantNames.Length / 2; i++)
                        {
                            if (userControl.Name == ManageCommon.MultiMerchantNames[i, 0] + "UserControl")
                            {
                                _manageData.MultiMerchantReqData[i] = userControl.GetTextBoxValue();
                            }
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
            switch(userControl.Name)
            {
                case "EdcTypeUserControl":
                    _manageData.EdcTypeIndex = userControl.GetComboBoxIndex();
                    break;
                default:
                    break;
            }
        }
    }
}

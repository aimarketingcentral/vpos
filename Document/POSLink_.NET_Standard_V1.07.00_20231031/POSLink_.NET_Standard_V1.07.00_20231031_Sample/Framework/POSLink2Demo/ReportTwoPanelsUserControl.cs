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
    public partial class ReportTwoPanelsUserControl : UserControl
    {
        private enum Module
        {
            Normal,
            MultiMerchant
        }

        private ReportCommandName _commandName;
        public ReportCommandName CommandName
        {
            get { return _commandName; }
            set { _commandName = value; }
        }

        private Module _moduleSelect;
        private ReportData _reportData;
        private Tools _tools = new Tools();
        public ReportTwoPanelsUserControl()
        {
            InitializeComponent();
            _reportData = ReportData.GetReportData();
            _moduleSelect = Module.Normal;
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
                case ReportCommandName.LocalTotalReportRsp:
                    buttonCount = ReportCommon.LocalTotalReportRspButtonNames.Length;
                    _buttonArray = new Button[buttonCount];
                    for (int i = 0; i < buttonCount; i++)
                    {
                        bool isHeightNotEnough = false;
                        _buttonArray[i] = Tools.CreateButton(ReportCommon.LocalTotalReportRspButtonNames[i], new Point(0, locationHeight), isHeightNotEnough);
                        locationHeight += _buttonArray[i].Height - 1;
                    }
                    _buttonArray[0].Click += new EventHandler(NormalRspClick);
                    _buttonArray[1].Click += new EventHandler(TotalDataRspClick);
                    NormalRspClick(sender, e);
                    break;
                case ReportCommandName.LocalDetailReportReq:
                    buttonCount = ReportCommon.LocalDetailReportReqButtonNames.Length;
                    _buttonArray = new Button[buttonCount];
                    for (int i = 0; i < buttonCount; i++)
                    {
                        bool isHeightNotEnough = false;
                        _buttonArray[i] = Tools.CreateButton(ReportCommon.LocalDetailReportReqButtonNames[i], new Point(0, locationHeight), isHeightNotEnough);
                        locationHeight += _buttonArray[i].Height - 1;
                    }
                    _buttonArray[0].Click += new EventHandler(NormalReqClick);
                    _buttonArray[1].Click += new EventHandler(MultiMerchantReqClick);
                    NormalReqClick(sender, e);
                    break;
                case ReportCommandName.LocalDetailReportRsp:
                    buttonCount = ReportCommon.LocalDetailReportRspButtonNames.Length;
                    _buttonArray = new Button[buttonCount];
                    for (int i = 0; i < buttonCount; i++)
                    {
                        bool isHeightNotEnough = false;
                        _buttonArray[i] = Tools.CreateButton(ReportCommon.LocalDetailReportRspButtonNames[i], new Point(0, locationHeight), isHeightNotEnough);
                        locationHeight += _buttonArray[i].Height - 1;
                    }
                    _buttonArray[0].Click += new EventHandler(NormalRspClick);
                    _buttonArray[1].Click += new EventHandler(HostInfoRspClick);
                    _buttonArray[2].Click += new EventHandler(AmountInfoRspClick);
                    _buttonArray[3].Click += new EventHandler(AccountInfoRspClick);
                    _buttonArray[4].Click += new EventHandler(TraceInfoRspClick);
                    _buttonArray[5].Click += new EventHandler(CashierInfoRspClick);
                    _buttonArray[6].Click += new EventHandler(CommercialInfoRspClick);
                    _buttonArray[7].Click += new EventHandler(CheckInfoRspClick);
                    _buttonArray[8].Click += new EventHandler(TorInfoRspClick);
                    _buttonArray[9].Click += new EventHandler(RestaurantRspClick);
                    _buttonArray[10].Click += new EventHandler(TransInfoRspClick);
                    _buttonArray[11].Click += new EventHandler(CardInfoRspClick);
                    _buttonArray[12].Click += new EventHandler(MultiMerchantRspClick);
                    _buttonArray[13].Click += new EventHandler(EmvTagRspClick);
                    _buttonArray[14].Click += new EventHandler(FleetCardRspClick);
                    NormalRspClick(sender, e);
                    break;
                case ReportCommandName.LocalFailedReportRsp:
                    buttonCount = ReportCommon.LocalFailedReportRspButtonNames.Length;
                    _buttonArray = new Button[buttonCount];
                    for (int i = 0; i < buttonCount; i++)
                    {
                        bool isHeightNotEnough = false;
                        _buttonArray[i] = Tools.CreateButton(ReportCommon.LocalFailedReportRspButtonNames[i], new Point(0, locationHeight), isHeightNotEnough);
                        locationHeight += _buttonArray[i].Height - 1;
                    }
                    _buttonArray[0].Click += new EventHandler(NormalRspClick);
                    _buttonArray[1].Click += new EventHandler(HostInfoRspClick);
                    _buttonArray[2].Click += new EventHandler(AmountInfoRspClick);
                    _buttonArray[3].Click += new EventHandler(AccountInfoRspClick);
                    _buttonArray[4].Click += new EventHandler(TraceInfoRspClick);
                    NormalRspClick(sender, e);
                    break;
                case ReportCommandName.HostDetailReportRsp:
                    buttonCount = ReportCommon.HostDetailReportRspButtonNames.Length;
                    _buttonArray = new Button[buttonCount];
                    for (int i = 0; i < buttonCount; i++)
                    {
                        bool isHeightNotEnough = false;
                        _buttonArray[i] = Tools.CreateButton(ReportCommon.HostDetailReportRspButtonNames[i], new Point(0, locationHeight), isHeightNotEnough);
                        locationHeight += _buttonArray[i].Height - 1;
                    }
                    _buttonArray[0].Click += new EventHandler(NormalRspClick);
                    _buttonArray[1].Click += new EventHandler(HostInfoRspClick);
                    _buttonArray[2].Click += new EventHandler(AmountInfoRspClick);
                    _buttonArray[3].Click += new EventHandler(AccountInfoRspClick);
                    _buttonArray[4].Click += new EventHandler(TraceInfoRspClick);
                    _buttonArray[5].Click += new EventHandler(CashierInfoRspClick);
                    _buttonArray[6].Click += new EventHandler(CommercialInfoRspClick);
                    _buttonArray[7].Click += new EventHandler(CheckInfoRspClick);
                    _buttonArray[8].Click += new EventHandler(TorInfoRspClick);
                    _buttonArray[9].Click += new EventHandler(AvsInfoRspClick);
                    _buttonArray[10].Click += new EventHandler(MotoECommerceRspClick);
                    NormalRspClick(sender, e);
                    break;
                default:
                    break;
            }
            if(_buttonArray != null)
            {
                ButtonPanel.Controls.AddRange(_buttonArray);
            }
        }

        //Reqeust----------------------------------------------------------------------------------------
        private void NormalReqClick(object sender, EventArgs e)
        {
            _moduleSelect = Module.Normal;
            _tools.DisposeSubControls(ValuePanel);
            LabelTextBoxUserControl[] labelAndTextBoxs;
            LabelComboBoxUserControl[] labelAndComboBox;
            switch (_commandName)
            {
                case ReportCommandName.LocalDetailReportReq:
                    labelAndComboBox = new LabelComboBoxUserControl[3];
                    labelAndComboBox[0] = CreateLabelAndComboBox(ReportCommon.LocalDetailReportReqNormalComboBox[0, 0], ReportCommon.LocalDetailReportReqNormalComboBox[0, 1], 294, new Point(0, 2), Global.GetEdcTypeKey(), _reportData.EdcTypeIndex);
                    labelAndComboBox[1] = CreateLabelAndComboBox(ReportCommon.LocalDetailReportReqNormalComboBox[1, 0], ReportCommon.LocalDetailReportReqNormalComboBox[1, 1], 294, new Point(0, 2 + 22), Global.GetTransTypeKey(), _reportData.TransTypeIndex);
                    labelAndComboBox[2] = CreateLabelAndComboBox(ReportCommon.LocalDetailReportReqNormalComboBox[2, 0], ReportCommon.LocalDetailReportReqNormalComboBox[2, 1], 294, new Point(0, 2 + 22 * 2), Global.GetCardTypeKey(), _reportData.CardTypeIndex);
                    ValuePanel.Controls.AddRange(labelAndComboBox);
                    labelAndTextBoxs = CreateLabelAndTextBoxs(ReportCommon.LocalDetailReportReqNormal, 294, new Point(0, 68), _reportData.LocalDetailReportReqNormalData);
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
            LabelTextBoxUserControl[] labelAndTextBoxs = CreateLabelAndTextBoxs(ReportCommon.MultiMerchantNames, 294, new Point(0, 2), _reportData.MultiMerchantReqData);
            ValuePanel.Controls.AddRange(labelAndTextBoxs);
        }

        //Response---------------------------------------------------------------------------------------
        private void NormalRspClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ValuePanel);
            LabelTextBoxUserControl[] labelAndTextBoxs;
            switch (_commandName)
            {
                case ReportCommandName.LocalTotalReportRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(ReportCommon.LocalTotalReportRspNormal, 294, new Point(0, 2), _reportData.LocalTotalReportRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case ReportCommandName.LocalDetailReportRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(ReportCommon.LocalDetailReportRspNormal, 294, new Point(0, 2), _reportData.LocalDetailReportRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    Button addlRspDataButton = CreateButton("AddlRspData", new Point(2, 22 * ReportCommon.LocalDetailReportRspNormal.Length/2 + 2), false);
                    addlRspDataButton.Width = ValuePanel.Width-4;
                    addlRspDataButton.Click += new EventHandler(AddlRspDataClick);
                    ValuePanel.Controls.Add(addlRspDataButton);
                    break;
                case ReportCommandName.LocalFailedReportRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(ReportCommon.LocalFailedReportRspNormal, 294, new Point(0, 2), _reportData.LocalFailedReportRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case ReportCommandName.HostDetailReportRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(ReportCommon.HostDetailReportRspNormal, 294, new Point(0, 2), _reportData.HostDetailReportRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                default:
                    break;
            }
        }

        private void HostInfoRspClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ValuePanel);
            LabelTextBoxUserControl[] labelAndTextBoxs = CreateLabelAndTextBoxs(ReportCommon.HostInfoRsp, 294, new Point(0, 2), _reportData.HostInfoRspData);
            ValuePanel.Controls.AddRange(labelAndTextBoxs);
        }

        private void AmountInfoRspClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ValuePanel);
            LabelTextBoxUserControl[] labelAndTextBoxs = CreateLabelAndTextBoxs(ReportCommon.AmountInfoRsp, 294, new Point(0, 2), _reportData.AmountInfoRspData);
            ValuePanel.Controls.AddRange(labelAndTextBoxs);
        }

        private void AccountInfoRspClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ValuePanel);
            LabelTextBoxUserControl[] labelAndTextBoxs = CreateLabelAndTextBoxs(ReportCommon.AccountInfoRsp, 294, new Point(0, 2), _reportData.AccountInfoRspData);
            ValuePanel.Controls.AddRange(labelAndTextBoxs);
        }

        private void TraceInfoRspClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ValuePanel);
            LabelTextBoxUserControl[] labelAndTextBoxs = CreateLabelAndTextBoxs(ReportCommon.TraceInfoRsp, 294, new Point(0, 2), _reportData.TraceInfoRspData);
            ValuePanel.Controls.AddRange(labelAndTextBoxs);
        }

        private void CashierInfoRspClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ValuePanel);
            LabelTextBoxUserControl[] labelAndTextBoxs = CreateLabelAndTextBoxs(ReportCommon.CashierInfoRsp, 294, new Point(0, 2), _reportData.CashierInfoRspData);
            ValuePanel.Controls.AddRange(labelAndTextBoxs);
        }

        private void CommercialInfoRspClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ValuePanel);
            LabelTextBoxUserControl[] labelAndTextBoxs = CreateLabelAndTextBoxs(ReportCommon.CommercialInfoRsp, 294, new Point(0, 2), _reportData.CommercialInfoRspData);
            ValuePanel.Controls.AddRange(labelAndTextBoxs);
        }

        private void CheckInfoRspClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ValuePanel);
            LabelTextBoxUserControl[] labelAndTextBoxs = CreateLabelAndTextBoxs(ReportCommon.CheckInfoRsp, 294, new Point(0, 2), _reportData.CheckInfoRspData);
            ValuePanel.Controls.AddRange(labelAndTextBoxs);
        }

        private void TorInfoRspClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ValuePanel);
            LabelTextBoxUserControl[] labelAndTextBoxs = CreateLabelAndTextBoxs(ReportCommon.TorInfoRsp, 294, new Point(0, 2), _reportData.TorInfoRspData);
            ValuePanel.Controls.AddRange(labelAndTextBoxs);
        }

        private void AvsInfoRspClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ValuePanel);
            LabelTextBoxUserControl[] labelAndTextBoxs = CreateLabelAndTextBoxs(ReportCommon.AvsInfoRsp, 294, new Point(0, 2), _reportData.AvsInfoRspData);
            ValuePanel.Controls.AddRange(labelAndTextBoxs);
        }

        private void MotoECommerceRspClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ValuePanel);
            LabelTextBoxUserControl[] labelAndTextBoxs = CreateLabelAndTextBoxs(ReportCommon.MotoECommerceInfoRsp, 294, new Point(0, 2), _reportData.MotoECommerceInfoRspData);
            ValuePanel.Controls.AddRange(labelAndTextBoxs);
        }

        private void TotalDataRspClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ValuePanel);
            ButtonTextBoxUserControl[] buttonTextBoxUserControl = new ButtonTextBoxUserControl[Global.EdcType.Length / 2 - 1];
            for(int i=0;i< Global.EdcType.Length / 2 - 1;i++)
            {
                buttonTextBoxUserControl[i] = new ButtonTextBoxUserControl();
                buttonTextBoxUserControl[i].CreateButtonTextBox(294, (string)Global.EdcType[i+1, 0], _reportData.TotalDataRspData[i], 0.4f);
                buttonTextBoxUserControl[i].Location = new Point(0, 2 + 22 * i);
                buttonTextBoxUserControl[i].CommandName = ButtonClickEventCommandName.LocalTotalReportRsp;
                buttonTextBoxUserControl[i].ButtonName = (string)Global.EdcType[i + 1, 0];
                buttonTextBoxUserControl[i].SetTextBoxValue(_reportData.TotalDataRspTextData[i]);
            }
            ValuePanel.Controls.AddRange(buttonTextBoxUserControl);
        }

        private void MultiMerchantRspClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ValuePanel);
            LabelTextBoxUserControl[] labelAndTextBoxs = CreateLabelAndTextBoxs(ReportCommon.MultiMerchantNames, 294, new Point(0, 2), _reportData.MultiMerchantRspData);
            ValuePanel.Controls.AddRange(labelAndTextBoxs);
        }

        private void RestaurantRspClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ValuePanel);
            LabelTextBoxUserControl[] labelAndTextBoxs = CreateLabelAndTextBoxs(ReportCommon.RestaurantNames, 294, new Point(0, 2), _reportData.RestaurantRspData);
            ValuePanel.Controls.AddRange(labelAndTextBoxs);
        }

        private void TransInfoRspClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ValuePanel);
            LabelTextBoxUserControl[] labelAndTextBoxs = CreateLabelAndTextBoxs(ReportCommon.ReportTransInfoNames, 294, new Point(0, 2), _reportData.TransInfoRspData);
            ValuePanel.Controls.AddRange(labelAndTextBoxs);
        }

        private void CardInfoRspClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ValuePanel);
            LabelTextBoxUserControl[] labelAndTextBoxs = CreateLabelAndTextBoxs(ReportCommon.CardInfoNames, 294, new Point(0, 2), _reportData.CardInfoRspData);
            ValuePanel.Controls.AddRange(labelAndTextBoxs);
        }

        private void EmvTagRspClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ValuePanel);
            LabelTextBoxUserControl[] labelAndTextBoxs = CreateLabelAndTextBoxs(ReportCommon.ReportEmvTagNames, 294, new Point(0, 2), _reportData.EmvTagRspData);
            ValuePanel.Controls.AddRange(labelAndTextBoxs);
        }

        private void FleetCardRspClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ValuePanel);
            LabelTextBoxUserControl[] labelAndTextBoxs = CreateLabelAndTextBoxs(ReportCommon.FleetCardNames, 294, new Point(0, 2), _reportData.FleetCardRspData);
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
                temp[i].CreateLabelTextBox(width, nameAndText[i, 0], nameAndText[i, 1], 0.4f);
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
                case ReportCommandName.LocalDetailReportReq:
                    if(_moduleSelect == Module.Normal)
                    {
                        for(int i=0;i<ReportCommon.LocalDetailReportReqNormal.Length/2;i++)
                        {
                            if(userControl.Name == ReportCommon.LocalDetailReportReqNormal[i,0]+ "UserControl")
                            {
                                _reportData.LocalDetailReportReqNormalData[i] = userControl.GetTextBoxValue();
                            }
                        }
                    }
                    else if(_moduleSelect == Module.MultiMerchant)
                    {
                        for (int i = 0; i < ReportCommon.MultiMerchantNames.Length / 2; i++)
                        {
                            if (userControl.Name == ReportCommon.MultiMerchantNames[i, 0] + "UserControl")
                            {
                                _reportData.MultiMerchantReqData[i] = userControl.GetTextBoxValue();
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
            switch (_commandName)
            {
                case ReportCommandName.LocalDetailReportReq:
                    if(userControl.Name == "EdcTypeUserControl")
                    {
                        _reportData.EdcTypeIndex = userControl.GetComboBoxIndex();
                    }
                    else if(userControl.Name == "TransactionTypeUserControl")
                    {
                        _reportData.TransTypeIndex = userControl.GetComboBoxIndex();
                    }
                    else if(userControl.Name == "CardTypeUserControl")
                    {
                        _reportData.CardTypeIndex = userControl.GetComboBoxIndex();
                    }
                    break;
                default:
                    break;
            }
        }

        //Show window
        private void AddlRspDataClick(object sender, EventArgs e)
        {
            AddlRspDataForm addlRspDataForm = new AddlRspDataForm();
            addlRspDataForm.SetAddlRspData(_reportData.AddlRspDataResponse);
            addlRspDataForm.Show();
        }
    }
}

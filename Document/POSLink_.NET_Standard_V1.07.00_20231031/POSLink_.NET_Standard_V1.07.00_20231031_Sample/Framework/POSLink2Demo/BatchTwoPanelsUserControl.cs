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
    public partial class BatchTwoPanelsUserControl : UserControl
    {
        private enum Module
        {
            Normal,
            MultiMerchant
        }

        private BatchCommandName _commandName;
        public BatchCommandName CommandName
        {
            get { return _commandName; }
            set { _commandName = value; }
        }

        private Module _moduleSelect;

        private BatchData _batchData;
        private Tools _tools = new Tools();
        public BatchTwoPanelsUserControl()
        {
            InitializeComponent();
            _batchData = BatchData.GetBatchData();
            _moduleSelect = Module.Normal;
        }

        Button[] _buttonArray;
        public void ShowButton(object sender, EventArgs e)
        {
            int buttonCount;
            _tools.DisposeSubControls(ButtonPanel);
            _tools.DisposeSubControls(ValuePanel);
            int locationHeight = 0;
            int exHeight = 0;
            _tools.DisposeSubControls(ValuePanel);
            switch (_commandName)
            {
                case BatchCommandName.BatchCloseReq:
                    buttonCount = BatchCommon.BatchCloseReqButtonNames.Length;
                    _buttonArray = new Button[buttonCount];
                    for (int i = 0; i < buttonCount; i++)
                    {
                        bool isHeightNotEnough = false;
                        _buttonArray[i] = Tools.CreateButton(BatchCommon.BatchCloseReqButtonNames[i], new Point(0, locationHeight), isHeightNotEnough);
                        locationHeight += _buttonArray[i].Height - 1;
                    }
                    _buttonArray[0].Click += new EventHandler(NormalRequestClick);
                    _buttonArray[1].Click += new EventHandler(MultiMerchantReqClick);
                    NormalRequestClick(sender, e);
                    break;
                case BatchCommandName.BatchCloseRsp:
                    buttonCount = BatchCommon.BatchCloseRspButtonNames.Length;
                    _buttonArray = new Button[buttonCount];
                    for (int i = 0; i < buttonCount; i++)
                    {
                        bool isHeightNotEnough = false;
                        _buttonArray[i] = Tools.CreateButton(BatchCommon.BatchCloseRspButtonNames[i], new Point(0, locationHeight), isHeightNotEnough);
                        locationHeight += _buttonArray[i].Height - 1;
                    }
                    _buttonArray[0].Click += new EventHandler(NormalResponseClick);
                    _buttonArray[1].Click += new EventHandler(HostInfoRspClick);
                    _buttonArray[2].Click += new EventHandler(TorInfoRspClick);
                    _buttonArray[3].Click += new EventHandler(MultiMerchantRspClick);
                    NormalResponseClick(sender, e);
                    break;
                case BatchCommandName.ForceBatchCloseRsp:
                    buttonCount = BatchCommon.ForceBatchCloseRspButtonNames.Length;
                    _buttonArray = new Button[buttonCount];
                    for (int i = 0; i < buttonCount; i++)
                    {
                        bool isHeightNotEnough = false;
                        _buttonArray[i] = Tools.CreateButton(BatchCommon.ForceBatchCloseRspButtonNames[i], new Point(0, locationHeight), isHeightNotEnough);
                        locationHeight += _buttonArray[i].Height - 1;
                    }
                    _buttonArray[0].Click += new EventHandler(NormalResponseClick);
                    _buttonArray[1].Click += new EventHandler(HostInfoRspClick);
                    _buttonArray[2].Click += new EventHandler(TorInfoRspClick);
                    NormalResponseClick(sender, e);
                    break;
                case BatchCommandName.BatchClearRsp:
                    buttonCount = BatchCommon.BatchClearRspButtonNames.Length;
                    _buttonArray = new Button[buttonCount];
                    for (int i = 0; i < buttonCount; i++)
                    {
                        bool isHeightNotEnough = false;
                        _buttonArray[i] = Tools.CreateButton(BatchCommon.BatchClearRspButtonNames[i], new Point(0, locationHeight), isHeightNotEnough);
                        locationHeight += _buttonArray[i].Height - 1;
                    }
                    _buttonArray[0].Click += new EventHandler(NormalResponseClick);
                    _buttonArray[1].Click += new EventHandler(TorInfoRspClick);
                    NormalResponseClick(sender, e);
                    break;
                case BatchCommandName.PurgeBatchRsp:
                    buttonCount = BatchCommon.PurgeBatchRspButtonNames.Length;
                    _buttonArray = new Button[buttonCount];
                    for (int i = 0; i < buttonCount; i++)
                    {
                        bool isHeightNotEnough = false;
                        _buttonArray[i] = Tools.CreateButton(BatchCommon.PurgeBatchRspButtonNames[i], new Point(0, locationHeight), isHeightNotEnough);
                        locationHeight += _buttonArray[i].Height - 1;
                    }
                    _buttonArray[0].Click += new EventHandler(NormalResponseClick);
                    _buttonArray[1].Click += new EventHandler(HostInfoRspClick);
                    _buttonArray[2].Click += new EventHandler(TorInfoRspClick);
                    NormalResponseClick(sender, e);
                    break;
                case BatchCommandName.SAFUploadRsp:
                    buttonCount = BatchCommon.SafUploadRspButtonNames.Length;
                    _buttonArray = new Button[buttonCount];
                    for (int i = 0; i < buttonCount; i++)
                    {
                        bool isHeightNotEnough = false;
                        _buttonArray[i] = Tools.CreateButton(BatchCommon.SafUploadRspButtonNames[i], new Point(0, locationHeight), isHeightNotEnough);
                        locationHeight += _buttonArray[i].Height - 1;
                    }
                    _buttonArray[0].Click += new EventHandler(NormalResponseClick);
                    _buttonArray[1].Click += new EventHandler(TorInfoRspClick);
                    NormalResponseClick(sender, e);
                    break;
                case BatchCommandName.DeleteSAFFileRsp:
                    buttonCount = BatchCommon.DeleteSafFileRspButtonNames.Length;
                    _buttonArray = new Button[buttonCount];
                    for (int i = 0; i < buttonCount; i++)
                    {
                        bool isHeightNotEnough = false;
                        _buttonArray[i] = Tools.CreateButton(BatchCommon.DeleteSafFileRspButtonNames[i], new Point(0, locationHeight), isHeightNotEnough);
                        locationHeight += _buttonArray[i].Height - 1;
                    }
                    _buttonArray[0].Click += new EventHandler(NormalResponseClick);
                    _buttonArray[1].Click += new EventHandler(TorInfoRspClick);
                    NormalResponseClick(sender, e);
                    break;
                case BatchCommandName.DeleteTransactionRsp:
                    buttonCount = BatchCommon.DeleteTransRspButtonNames.Length;
                    _buttonArray = new Button[buttonCount];
                    for (int i = 0; i < buttonCount; i++)
                    {
                        bool isHeightNotEnough = false;
                        _buttonArray[i] = Tools.CreateButton(BatchCommon.DeleteTransRspButtonNames[i], new Point(0, locationHeight), isHeightNotEnough);
                        locationHeight += _buttonArray[i].Height - 1;
                    }
                    _buttonArray[0].Click += new EventHandler(NormalResponseClick);
                    _buttonArray[1].Click += new EventHandler(TorInfoRspClick);
                    NormalResponseClick(sender, e);
                    break;
                default:
                    break;
            }
            ButtonPanel.Controls.AddRange(_buttonArray);
        }

        //Request------------------------------------------------------------------------------------------------
        private void NormalRequestClick(object sender, EventArgs e)
        {
            _moduleSelect = Module.Normal;
            _tools.DisposeSubControls(ValuePanel);
            switch (_commandName)
            {
                case BatchCommandName.BatchCloseReq:
                    LabelTextBoxUserControl[] labelAndTextBoxs = CreateLabelAndTextBoxs(BatchCommon.BatchCloseReqNormal, 294, new Point(0, 2), _batchData.BatchCloseReqNormalData);
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
            LabelTextBoxUserControl[] labelAndTextBoxs = CreateLabelAndTextBoxs(BatchCommon.MultiMerchantNames, 294, new Point(0, 2), _batchData.MultiMerchantReqData);
            ValuePanel.Controls.AddRange(labelAndTextBoxs);
        }

        //Response---------------------------------------------------------------------------------------------
        private void NormalResponseClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ValuePanel);
            LabelTextBoxUserControl[] labelAndTextBoxs;
            switch (_commandName)
            {
                case BatchCommandName.BatchCloseRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(BatchCommon.BatchCloseRspNormal, 294, new Point(0, 2), _batchData.BatchCloseRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case BatchCommandName.ForceBatchCloseRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(BatchCommon.ForceBatchCloseRspNormal, 294, new Point(0, 2), _batchData.ForceBatchCloseRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case BatchCommandName.BatchClearRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(BatchCommon.BatchClearRspNormal, 294, new Point(0, 2), _batchData.BatchClearRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case BatchCommandName.PurgeBatchRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(BatchCommon.PurgeBatchRspNormal, 294, new Point(0, 2), _batchData.PurgeBatchRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case BatchCommandName.SAFUploadRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(BatchCommon.SafUploadRspNormal, 294, new Point(0, 2), _batchData.SafUploadRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case BatchCommandName.DeleteSAFFileRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(BatchCommon.DeleteSafFileRspNormal, 294, new Point(0, 2), _batchData.DeleteSafFileRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case BatchCommandName.DeleteTransactionRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(BatchCommon.DeleteTransRspNormal, 294, new Point(0, 2), _batchData.DeleteTransRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                default:
                    break;
            }
        }

        private void HostInfoRspClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ValuePanel);
            LabelTextBoxUserControl[] labelAndTextBoxs = CreateLabelAndTextBoxs(BatchCommon.HostInfoRsp, 294, new Point(0, 2), _batchData.HostInfoRspData);
            ValuePanel.Controls.AddRange(labelAndTextBoxs);
        }

        private void TorInfoRspClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ValuePanel);
            LabelTextBoxUserControl[] labelAndTextBoxs = CreateLabelAndTextBoxs(BatchCommon.TorInfoRsp, 294, new Point(0, 2), _batchData.TorInfoRspData);
            ValuePanel.Controls.AddRange(labelAndTextBoxs);
        }

        private void MultiMerchantRspClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ValuePanel);
            LabelTextBoxUserControl[] labelAndTextBoxs = CreateLabelAndTextBoxs(BatchCommon.MultiMerchantNames, 294, new Point(0, 2), _batchData.MultiMerchantRspData);
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
            for(int i=0;i< nameAndText.Length / 2;i++)
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

        private void LoseOfFocusTextBoxUserControl(object sender, EventArgs e)
        {
            LabelTextBoxUserControl userControl = (LabelTextBoxUserControl)sender;
            switch (_commandName)
            {
                case BatchCommandName.BatchCloseReq:
                    SetBatchCloseReqData(userControl);
                    break;
                default:
                    break;
            }
        }

        private void SetBatchCloseReqData(LabelTextBoxUserControl userControl)
        {
            switch(_moduleSelect)
            {
                case Module.Normal:
                    for (int i = 0; i < BatchCommon.BatchCloseReqNormal.Length / 2; i++)
                    {
                        if (userControl.Name == BatchCommon.BatchCloseReqNormal[i, 0] + "UserControl")
                        {
                            _batchData.BatchCloseReqNormalData[i] = userControl.GetTextBoxValue();
                            break;
                        }
                    }
                    break;
                case Module.MultiMerchant:
                    for (int i = 0; i < BatchCommon.MultiMerchantNames.Length / 2; i++)
                    {
                        if (userControl.Name == BatchCommon.MultiMerchantNames[i, 0] + "UserControl")
                        {
                            _batchData.MultiMerchantReqData[i] = userControl.GetTextBoxValue();
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}

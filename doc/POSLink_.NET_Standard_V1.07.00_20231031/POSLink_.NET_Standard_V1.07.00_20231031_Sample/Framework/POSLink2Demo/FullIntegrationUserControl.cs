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
    public partial class FullIntegrationUserControl : UserControl
    {
        private FullIntegrationData _fullIntegrationData;
        private Waiting _waiting;
        private bool _isCancelListening;
        private TerminalData _terminalData;
        private POSLink2.Terminal _terminal;
        private Tools _tools = new Tools();
        public POSLink2.Terminal Terminal
        {
            get { return _terminal; }
            set { _terminal = value; }
        }

        private int _comboBoxIndex;
        public int ComboBoxIndex
        {
            get { return _comboBoxIndex; }
            set { _comboBoxIndex = value; }
        }

        public FullIntegrationUserControl()
        {
            InitializeComponent();
            CommandComboBox.Items.AddRange(FullIntegrationCommon.CommandNames);
            _comboBoxIndex = 0;
            CommandComboBox.SelectedIndex = 0;
            _fullIntegrationData = FullIntegrationData.GetFullIntegrationData();
            _waiting = new Waiting();
            _waiting.Dock = DockStyle.Left;
            _isCancelListening = false;
        }

        private void CommandComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _comboBoxIndex = CommandComboBox.SelectedIndex;
            _tools.DisposeSubControls(panel1);
            if (CommandComboBox.SelectedIndex == (int)FullIntegrationCommandName.GetPinBlockReq / 2)//Get PIN Block
            {
                FullIntegrationOnePanelUserControl getPinBlockReqUserControl = new FullIntegrationOnePanelUserControl();
                getPinBlockReqUserControl.CommandName = FullIntegrationCommandName.GetPinBlockReq;
                getPinBlockReqUserControl.Dock = DockStyle.Left;
                getPinBlockReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(getPinBlockReqUserControl);

                FullIntegrationOnePanelUserControl getPinBlockRspUserControl = new FullIntegrationOnePanelUserControl();
                getPinBlockRspUserControl.CommandName = FullIntegrationCommandName.GetPinBlockRsp;
                getPinBlockRspUserControl.Dock = DockStyle.Left;
                getPinBlockRspUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(getPinBlockRspUserControl);

                getPinBlockReqUserControl.SendToBack();
            }
            else if (CommandComboBox.SelectedIndex == (int)FullIntegrationCommandName.AuthorizeCardReq / 2)//Autherize Card
            {
                FullIntegrationTwoPanelsUserControl authorizeCardReqUserControl = new FullIntegrationTwoPanelsUserControl();
                authorizeCardReqUserControl.CommandName = FullIntegrationCommandName.AuthorizeCardReq;
                authorizeCardReqUserControl.Dock = DockStyle.Left;
                authorizeCardReqUserControl.ShowButton(sender, e);
                panel1.Controls.Add(authorizeCardReqUserControl);

                FullIntegrationOnePanelUserControl authorizeCardRspUserControl = new FullIntegrationOnePanelUserControl();
                authorizeCardRspUserControl.CommandName = FullIntegrationCommandName.AuthorizeCardRsp;
                authorizeCardRspUserControl.Dock = DockStyle.Left;
                authorizeCardRspUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(authorizeCardRspUserControl);

                authorizeCardReqUserControl.SendToBack();
            }
            else if (CommandComboBox.SelectedIndex == (int)FullIntegrationCommandName.CompleteOnlineEmvReq / 2)//Complete Online Emv
            {
                FullIntegrationOnePanelUserControl completeOnlineEmvReqUserControl = new FullIntegrationOnePanelUserControl();
                completeOnlineEmvReqUserControl.CommandName = FullIntegrationCommandName.CompleteOnlineEmvReq;
                completeOnlineEmvReqUserControl.Dock = DockStyle.Left;
                completeOnlineEmvReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(completeOnlineEmvReqUserControl);

                FullIntegrationOnePanelUserControl completeOnlineEmvRspUserControl = new FullIntegrationOnePanelUserControl();
                completeOnlineEmvRspUserControl.CommandName = FullIntegrationCommandName.CompleteOnlineEmvRsp;
                completeOnlineEmvRspUserControl.Dock = DockStyle.Left;
                completeOnlineEmvRspUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(completeOnlineEmvRspUserControl);

                completeOnlineEmvReqUserControl.SendToBack();
            }
            else if (CommandComboBox.SelectedIndex == (int)FullIntegrationCommandName.GetEmvTlvDataReq / 2)//Get EMV TLV Data
            {
                FullIntegrationOnePanelUserControl getEmvTlvDataReqUserControl = new FullIntegrationOnePanelUserControl();
                getEmvTlvDataReqUserControl.CommandName = FullIntegrationCommandName.GetEmvTlvDataReq;
                getEmvTlvDataReqUserControl.Dock = DockStyle.Left;
                getEmvTlvDataReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(getEmvTlvDataReqUserControl);

                FullIntegrationOnePanelUserControl getEmvTlvDataRspUserControl = new FullIntegrationOnePanelUserControl();
                getEmvTlvDataRspUserControl.CommandName = FullIntegrationCommandName.GetEmvTlvDataRsp;
                getEmvTlvDataRspUserControl.Dock = DockStyle.Left;
                getEmvTlvDataRspUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(getEmvTlvDataRspUserControl);

                getEmvTlvDataReqUserControl.SendToBack();
            }
            else if (CommandComboBox.SelectedIndex == (int)FullIntegrationCommandName.SetEmvTlvDataReq / 2)//Set EMV TLV Data
            {
                FullIntegrationOnePanelUserControl setEmvTlvDataReqUserControl = new FullIntegrationOnePanelUserControl();
                setEmvTlvDataReqUserControl.CommandName = FullIntegrationCommandName.SetEmvTlvDataReq;
                setEmvTlvDataReqUserControl.Dock = DockStyle.Left;
                setEmvTlvDataReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(setEmvTlvDataReqUserControl);

                FullIntegrationOnePanelUserControl setEmvTlvDataRspUserControl = new FullIntegrationOnePanelUserControl();
                setEmvTlvDataRspUserControl.CommandName = FullIntegrationCommandName.SetEmvTlvDataRsp;
                setEmvTlvDataRspUserControl.Dock = DockStyle.Left;
                setEmvTlvDataRspUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(setEmvTlvDataRspUserControl);

                setEmvTlvDataReqUserControl.SendToBack();
            }
            else if (CommandComboBox.SelectedIndex == (int)FullIntegrationCommandName.InputAccountWithEmvReq / 2)//Input Account With Emv
            {
                FullIntegrationTwoPanelsUserControl InputAccountWithEmvReqUserControl = new FullIntegrationTwoPanelsUserControl();
                InputAccountWithEmvReqUserControl.CommandName = FullIntegrationCommandName.InputAccountWithEmvReq;
                InputAccountWithEmvReqUserControl.Dock = DockStyle.Left;
                InputAccountWithEmvReqUserControl.ShowButton(sender, e);
                panel1.Controls.Add(InputAccountWithEmvReqUserControl);

                FullIntegrationTwoPanelsUserControl InputAccountWithEmvRspUserControl = new FullIntegrationTwoPanelsUserControl();
                InputAccountWithEmvRspUserControl.CommandName = FullIntegrationCommandName.InputAccountWithEmvRsp;
                InputAccountWithEmvRspUserControl.Dock = DockStyle.Left;
                InputAccountWithEmvRspUserControl.ShowButton(sender, e);
                panel1.Controls.Add(InputAccountWithEmvRspUserControl);

                InputAccountWithEmvReqUserControl.SendToBack();
            }
        }

        private void RunFullIntegration(int tenderType, object sender, EventArgs e)
        {
            Task task = new Task(() =>
            {
                POSLink2.ExecutionResult executionResult = new POSLink2.ExecutionResult();

                switch (tenderType)
                {
                    case (int)FullIntegrationCommandName.GetPinBlockReq / 2://Get PIN Block
                        POSLink2.FullIntegration.GetPinBlockReq getPinBlockReq = SetGetPinBlockReq();
                        POSLink2.FullIntegration.GetPinBlockRsp getPinBlockRsp = null;
                        executionResult = _terminal.FullIntegration.GetPinBlock(getPinBlockReq, out getPinBlockRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(getPinBlockRsp);
                        }
                        break;
                    case (int)FullIntegrationCommandName.AuthorizeCardReq / 2://Auth Card
                        POSLink2.FullIntegration.AuthorizeCardReq authorizeCardReq = SetAuthorizeCardReq();
                        POSLink2.FullIntegration.AuthorizeCardRsp authorizeCardRsp = null;
                        executionResult = _terminal.FullIntegration.AuthorizeCard(authorizeCardReq, out authorizeCardRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(authorizeCardRsp);
                        }
                        break;
                    case (int)FullIntegrationCommandName.CompleteOnlineEmvReq / 2://Complete online EMV
                        POSLink2.FullIntegration.CompleteOnlineEmvReq completeOnlineEmvReq = SetCompleteOnlineEmvReq();
                        POSLink2.FullIntegration.CompleteOnlineEmvRsp completeOnlineEmvRsp = null;
                        executionResult = _terminal.FullIntegration.CompleteOnlineEmv(completeOnlineEmvReq, out completeOnlineEmvRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(completeOnlineEmvRsp);
                        }
                        break;
                    case (int)FullIntegrationCommandName.GetEmvTlvDataReq / 2://Get EMV TLV Data
                        POSLink2.FullIntegration.GetEmvTlvDataReq getEmvTlvDataReq = SetGetEmvTlvDataReq();
                        POSLink2.FullIntegration.GetEmvTlvDataRsp getEmvTlvDataRsp = null;
                        executionResult = _terminal.FullIntegration.GetEmvTlvData(getEmvTlvDataReq, out getEmvTlvDataRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(getEmvTlvDataRsp);
                        }
                        break;
                    case (int)FullIntegrationCommandName.SetEmvTlvDataReq / 2://Set EMV TLV Data
                        POSLink2.FullIntegration.SetEmvTlvDataReq setEmvTlvDataReq = SetSetEmvTlvDataReq();
                        POSLink2.FullIntegration.SetEmvTlvDataRsp setEmvTlvDataRsp = null;
                        executionResult = _terminal.FullIntegration.SetEmvTlvData(setEmvTlvDataReq, out setEmvTlvDataRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(setEmvTlvDataRsp);
                        }
                        break;
                    case (int)FullIntegrationCommandName.InputAccountWithEmvReq / 2://Input account with EMV
                        POSLink2.FullIntegration.InputAccountWithEmvReq inputAccountWithEmvReq = SetInputAccountWithEmvReq();
                        POSLink2.FullIntegration.InputAccountWithEmvRsp inputAccountWithEmvRsp = null;
                        executionResult = _terminal.FullIntegration.InputAccountWithEmv(inputAccountWithEmvReq, out inputAccountWithEmvRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(inputAccountWithEmvRsp);
                        }
                        break;
                    default:
                        break;
                }
                Global.IsTransactionProcessing = false;
                MethodInvoker methodInvoker = new MethodInvoker(() =>
                {
                    CommandComboBox_SelectedIndexChanged(sender, e);
                    StartButton.Enabled = true;
                    if (_waiting != null)
                    {
                        _waiting.Hide();
                    }

                    if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.RecvAckTimeout)
                    {
                        MessageBox.Show("Receive ack timeout!", "ERROR");
                    }
                    else if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.RecvDataTimeout)
                    {
                        MessageBox.Show("Receive data timeout!", "ERROR");
                    }
                    else if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.ConnectError)
                    {
                        MessageBox.Show("Connect error!", "ERROR");
                    }
                    else if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.SendDataError)
                    {
                        MessageBox.Show("Send data error!", "ERROR");
                    }
                    else if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.RecvAckError)
                    {
                        MessageBox.Show("Receive ack error!", "ERROR");
                    }
                    else if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.RecvDataError)
                    {
                        MessageBox.Show("Receive data error!", "ERROR");
                    }
                    else if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.ExceptionalHttpStatusCode)
                    {
                        MessageBox.Show("Exceptional http status code!", "ERROR");
                    }
                    else if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.LrcError)
                    {
                        MessageBox.Show("Lrc error!", "ERROR");
                    }
                    else if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.PackRequestError)
                    {
                        MessageBox.Show("Pack request error!", "ERROR");
                    }
                    _isCancelListening = false;
                });
                BeginInvoke(methodInvoker);
            });
            task.Start();
        }

        private void RunListener()
        {
            Task task = new Task(() =>
            {
                while (true)
                {
                    if (!_isCancelListening)
                    {
                        break;
                    }

                    if (_waiting.IsCancel)
                    {
                        _terminal.Cancel();
                        MethodInvoker methodInvoker1 = new MethodInvoker(() => {
                            _waiting.IsCancel = false;
                            _isCancelListening = false;
                        });
                        BeginInvoke(methodInvoker1);
                        break;
                    }
                }
            });
            task.Start();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (Global.IsTransactionProcessing)
            {
                MessageBox.Show("A transaction is processing.", "Warning");
                return;
            }
            Global.IsTransactionProcessing = true;
            StartButton.Enabled = false;
            _fullIntegrationData.ResponseClear();
            _waiting.Location = new Point(0, 0);
            _waiting.IsCancelAvaliable = true;
            this.Controls.Add(_waiting);
            _waiting.BringToFront();
            _waiting.Show();

            int tenderType = CommandComboBox.SelectedIndex;
            RunFullIntegration(tenderType, sender, e);
            _isCancelListening = true;
            RunListener();
        }

        private POSLink2.FullIntegration.GetPinBlockReq SetGetPinBlockReq()
        {
            POSLink2.FullIntegration.GetPinBlockReq request = new POSLink2.FullIntegration.GetPinBlockReq();
            request.EdcType = (POSLink2.Const.EdcType)Global.EdcType[_fullIntegrationData.EdcTypeIndex, 1];
            request.TransactionType = (POSLink2.Const.TransType)Global.TransType[_fullIntegrationData.TransTypeIndex, 1];
            request.AccountNumber = _fullIntegrationData.GetPinBlockReqNormalData[0];
            request.EncryptionType = _fullIntegrationData.GetPinBlockReqNormalData[1];
            request.KeySlot = _fullIntegrationData.GetPinBlockReqNormalData[2];
            request.PinMinLength = _fullIntegrationData.GetPinBlockReqNormalData[3];
            request.PinMaxLength = _fullIntegrationData.GetPinBlockReqNormalData[4];
            request.NullPinFlag = _fullIntegrationData.GetPinBlockReqNormalData[5];
            request.PinAlgorithm = _fullIntegrationData.GetPinBlockReqNormalData[6];
            request.Timeout = _fullIntegrationData.GetPinBlockReqNormalData[7];
            request.Title = _fullIntegrationData.GetPinBlockReqNormalData[8];
            request.PinpadType = _fullIntegrationData.GetPinBlockReqNormalData[9];
            request.KsnFlag = _fullIntegrationData.GetPinBlockReqNormalData[10];
            return request;
        }

        private POSLink2.FullIntegration.AuthorizeCardReq SetAuthorizeCardReq()
        {
            POSLink2.FullIntegration.AuthorizeCardReq request = new POSLink2.FullIntegration.AuthorizeCardReq();
            request.MerchantDecision = _fullIntegrationData.AuthorizeCardReqNormalData[0];
            request.PinEncryptionType = _fullIntegrationData.AuthorizeCardReqNormalData[1];
            request.PinKeySlot = _fullIntegrationData.AuthorizeCardReqNormalData[2];
            request.PinMinLength = _fullIntegrationData.AuthorizeCardReqNormalData[3];
            request.PinMaxLength = _fullIntegrationData.AuthorizeCardReqNormalData[4];
            request.PinBypass = _fullIntegrationData.AuthorizeCardReqNormalData[5];
            request.PinAlgorithm = _fullIntegrationData.AuthorizeCardReqNormalData[6];
            request.TagList = _fullIntegrationData.AuthorizeCardReqNormalData[7];
            request.Timeout = _fullIntegrationData.AuthorizeCardReqNormalData[8];
            request.ContinuousScreen = _fullIntegrationData.AuthorizeCardReqNormalData[9];
            request.PinpadType = _fullIntegrationData.AuthorizeCardReqNormalData[10];
            request.KsnFlag = _fullIntegrationData.AuthorizeCardReqNormalData[11];
            request.AmountInformation = SetAmountReq();
            request.TerminalConfiguration = SetTerminalConfiguration();
            return request;
        }

        private POSLink2.FullIntegration.CompleteOnlineEmvReq SetCompleteOnlineEmvReq()
        {
            POSLink2.FullIntegration.CompleteOnlineEmvReq request = new POSLink2.FullIntegration.CompleteOnlineEmvReq();
            request.OnlineAuthorizationResult = _fullIntegrationData.CompleteOnlineEmvReqNormal[0];
            request.ResponseCode = _fullIntegrationData.CompleteOnlineEmvReqNormal[1];
            request.AuthorizationCode = _fullIntegrationData.CompleteOnlineEmvReqNormal[2];
            request.IssuerAuthenticationData = _fullIntegrationData.CompleteOnlineEmvReqNormal[3];
            request.IssuerScript1 = _fullIntegrationData.CompleteOnlineEmvReqNormal[4];
            request.IssuerScript2 = _fullIntegrationData.CompleteOnlineEmvReqNormal[5];
            request.TagList = _fullIntegrationData.CompleteOnlineEmvReqNormal[6];
            request.ContinuousScreen = _fullIntegrationData.CompleteOnlineEmvReqNormal[7];
            return request;
        }

        private POSLink2.FullIntegration.GetEmvTlvDataReq SetGetEmvTlvDataReq()
        {
            POSLink2.FullIntegration.GetEmvTlvDataReq request = new POSLink2.FullIntegration.GetEmvTlvDataReq();
            request.TlvType = _fullIntegrationData.GetEmvTlvDataReqNormalData[0];
            request.TagList = _fullIntegrationData.GetEmvTlvDataReqNormalData[1];
            return request;
        }

        private POSLink2.FullIntegration.SetEmvTlvDataReq SetSetEmvTlvDataReq()
        {
            POSLink2.FullIntegration.SetEmvTlvDataReq request = new POSLink2.FullIntegration.SetEmvTlvDataReq();
            request.TlvType = _fullIntegrationData.SetEmvTlvDataReqNormalData[0];
            request.EmvTlvData = _fullIntegrationData.SetEmvTlvDataReqNormalData[1];
            return request;
        }

        private POSLink2.FullIntegration.InputAccountWithEmvReq SetInputAccountWithEmvReq()
        {
            POSLink2.FullIntegration.InputAccountWithEmvReq request = new POSLink2.FullIntegration.InputAccountWithEmvReq();
            request.EdcType = (POSLink2.Const.EdcType)Global.EdcType[_fullIntegrationData.EdcTypeIndex, 1];
            request.TransactionType = (POSLink2.Const.TransType)Global.TransType[_fullIntegrationData.TransTypeIndex, 1];
            request.MagneticSwipeEntryFlag = _fullIntegrationData.InputAccountWithEmvReqNormal[0];
            request.ManualEntryFlag = _fullIntegrationData.InputAccountWithEmvReqNormal[1];
            request.ContactlessEntryFlag = _fullIntegrationData.InputAccountWithEmvReqNormal[2];
            request.ContactEMVEntryFlag = _fullIntegrationData.InputAccountWithEmvReqNormal[3];
            request.FallbackSwipeEntryFlag = _fullIntegrationData.InputAccountWithEmvReqNormal[4];
            request.LaserScannerFlag = _fullIntegrationData.InputAccountWithEmvReqNormal[5];
            request.FrontCameraFlag = _fullIntegrationData.InputAccountWithEmvReqNormal[6];
            request.RearCameraFlag = _fullIntegrationData.InputAccountWithEmvReqNormal[7];
            request.EncryptionFlag = _fullIntegrationData.InputAccountWithEmvReqNormal[8];
            request.KeySlot = _fullIntegrationData.InputAccountWithEmvReqNormal[9];
            request.PaddingChar = _fullIntegrationData.InputAccountWithEmvReqNormal[10];
            request.TrackDataSentinel = _fullIntegrationData.InputAccountWithEmvReqNormal[11];
            request.MinAccountLength = _fullIntegrationData.InputAccountWithEmvReqNormal[12];
            request.MaxAccountLength = _fullIntegrationData.InputAccountWithEmvReqNormal[13];
            request.TagList = _fullIntegrationData.InputAccountWithEmvReqNormal[14];
            request.Timeout = _fullIntegrationData.InputAccountWithEmvReqNormal[15];
            request.ContinuousScreen = _fullIntegrationData.InputAccountWithEmvReqNormal[16];
            request.FallbackInsertEntryFlag = _fullIntegrationData.InputAccountWithEmvReqNormal[17];
            request.KsnFlag = _fullIntegrationData.InputAccountWithEmvReqNormal[18];
            request.FallbackToManualEntryFlag = _fullIntegrationData.InputAccountWithEmvReqNormal[19];
            request.AmountInformation = SetAmountReq();
            request.AdditionalPrompts = SetAdditionalPrompts();
            request.TerminalConfiguration = SetTerminalConfiguration();
            request.CustomData = _fullIntegrationData.CustomDataArray;
            request.CustomMacInformation = SetCustomMacInfoReq();
            return request;
        }

        private POSLink2.Util.AmountReq SetAmountReq()
        {
            POSLink2.Util.AmountReq request = new POSLink2.Util.AmountReq();
            request.TransactionAmount = _fullIntegrationData.AmountInfoReqData[0];
            request.TipAmount = _fullIntegrationData.AmountInfoReqData[1];
            request.CashBackAmount = _fullIntegrationData.AmountInfoReqData[2];
            request.MerchantFee = _fullIntegrationData.AmountInfoReqData[3];
            request.TaxAmount = _fullIntegrationData.AmountInfoReqData[4];
            request.FuelAmount = _fullIntegrationData.AmountInfoReqData[5];
            request.ServiceFee = _fullIntegrationData.AmountInfoReqData[6];
            return request;
        }

        private POSLink2.Util.TerminalConfiguration SetTerminalConfiguration()
        {
            POSLink2.Util.TerminalConfiguration request = new POSLink2.Util.TerminalConfiguration();
            request.EmvKernelConfigurationSelection = _fullIntegrationData.TerminalConfigurationReqData[0];
            request.TransactionDate = _fullIntegrationData.TerminalConfigurationReqData[1];
            request.TransactionTime = _fullIntegrationData.TerminalConfigurationReqData[2];
            request.CurrencyCode = _fullIntegrationData.TerminalConfigurationReqData[3];
            request.CurrencyExponent = _fullIntegrationData.TerminalConfigurationReqData[4];
            request.MerchantCategoryCode = _fullIntegrationData.TerminalConfigurationReqData[5];
            request.TransactionSequenceNumber = _fullIntegrationData.TerminalConfigurationReqData[6];
            return request;
        }

        private POSLink2.Util.CustomMacInfoReq SetCustomMacInfoReq()
        {
            POSLink2.Util.CustomMacInfoReq request = new POSLink2.Util.CustomMacInfoReq();
            request.KeyType = _fullIntegrationData.CustomMacInfoReqData[0];
            request.WorkMode = _fullIntegrationData.CustomMacInfoReqData[1];
            request.KeySlot = _fullIntegrationData.CustomMacInfoReqData[2];
            request.Data = _fullIntegrationData.CustomMacDataArray;
            return request;
        }

        private POSLink2.FullIntegration.AdditionalPrompts SetAdditionalPrompts()
        {
            POSLink2.FullIntegration.AdditionalPrompts request = new POSLink2.FullIntegration.AdditionalPrompts();
            request.ExpiryDatePrompt = _fullIntegrationData.AdditionalPromptsReqData[0];
            request.CvvPrompt = _fullIntegrationData.AdditionalPromptsReqData[1];
            request.ZipCodePrompt = _fullIntegrationData.AdditionalPromptsReqData[2];
            return request;
        }

        public static void GetResponse(POSLink2.FullIntegration.GetPinBlockRsp response)
        {
            FullIntegrationData fullIntegrationData = FullIntegrationData.GetFullIntegrationData();
            //Normal
            fullIntegrationData.GetPinBlockRspNormalData[0] = response.ResponseCode;
            fullIntegrationData.GetPinBlockRspNormalData[1] = response.ResponseMessage;
            fullIntegrationData.GetPinBlockRspNormalData[2] = response.PinBlock;
            fullIntegrationData.GetPinBlockRspNormalData[3] = response.Ksn;
            fullIntegrationData.GetPinBlockRspNormalData[4] = response.PinpadType;
        }

        public static void GetResponse(POSLink2.FullIntegration.AuthorizeCardRsp response)
        {
            FullIntegrationData fullIntegrationData = FullIntegrationData.GetFullIntegrationData();
            //Normal
            fullIntegrationData.AuthorizeCardRspNormalData[0] = response.ResponseCode;
            fullIntegrationData.AuthorizeCardRspNormalData[1] = response.ResponseMessage;
            fullIntegrationData.AuthorizeCardRspNormalData[2] = response.AuthorizationResult;
            fullIntegrationData.AuthorizeCardRspNormalData[3] = response.SignatureFlag;
            fullIntegrationData.AuthorizeCardRspNormalData[4] = response.PinBypassStatus;
            fullIntegrationData.AuthorizeCardRspNormalData[5] = response.PinBlock;
            fullIntegrationData.AuthorizeCardRspNormalData[6] = response.Ksn;
            fullIntegrationData.AuthorizeCardRspNormalData[7] = response.EmvTlvData;
            fullIntegrationData.AuthorizeCardRspNormalData[8] = response.Cvm;
            fullIntegrationData.AuthorizeCardRspNormalData[9] = response.PinpadType;
        }

        public static void GetResponse(POSLink2.FullIntegration.CompleteOnlineEmvRsp response)
        {
            FullIntegrationData fullIntegrationData = FullIntegrationData.GetFullIntegrationData();
            //Normal
            fullIntegrationData.CompleteOnlineEmvRspNormal[0] = response.ResponseCode;
            fullIntegrationData.CompleteOnlineEmvRspNormal[1] = response.ResponseMessage;
            fullIntegrationData.CompleteOnlineEmvRspNormal[2] = response.AuthorizationResult;
            fullIntegrationData.CompleteOnlineEmvRspNormal[3] = response.EmvTlvData;
            fullIntegrationData.CompleteOnlineEmvRspNormal[4] = response.IssuerScriptResults;
        }

        public static void GetResponse(POSLink2.FullIntegration.GetEmvTlvDataRsp response)
        {
            FullIntegrationData fullIntegrationData = FullIntegrationData.GetFullIntegrationData();
            fullIntegrationData.GetEmvTlvDataRspNormalData[0] = response.ResponseCode;
            fullIntegrationData.GetEmvTlvDataRspNormalData[1] = response.ResponseMessage;
            fullIntegrationData.GetEmvTlvDataRspNormalData[2] = response.EmvTlvData;
        }

        public static void GetResponse(POSLink2.FullIntegration.SetEmvTlvDataRsp response)
        {
            FullIntegrationData fullIntegrationData = FullIntegrationData.GetFullIntegrationData();
            //Normal
            fullIntegrationData.SetEmvTlvDataRspNormalData[0] = response.ResponseCode;
            fullIntegrationData.SetEmvTlvDataRspNormalData[1] = response.ResponseMessage;
            fullIntegrationData.SetEmvTlvDataRspNormalData[2] = response.TagList;
        }

        public static void GetResponse(POSLink2.FullIntegration.InputAccountWithEmvRsp response)
        {
            FullIntegrationData fullIntegrationData = FullIntegrationData.GetFullIntegrationData();
            //Normal
            fullIntegrationData.InputAccountWithEmvRspNormal[0] = response.ResponseCode;
            fullIntegrationData.InputAccountWithEmvRspNormal[1] = response.ResponseMessage;
            fullIntegrationData.InputAccountWithEmvRspNormal[2] = response.EntryMode;
            fullIntegrationData.InputAccountWithEmvRspNormal[3] = response.Track1Data;
            fullIntegrationData.InputAccountWithEmvRspNormal[4] = response.Track2Data;
            fullIntegrationData.InputAccountWithEmvRspNormal[5] = response.Track3Data;
            fullIntegrationData.InputAccountWithEmvRspNormal[6] = response.Pan;
            fullIntegrationData.InputAccountWithEmvRspNormal[7] = response.MaskedPAN;
            fullIntegrationData.InputAccountWithEmvRspNormal[8] = response.BarcodeType;
            fullIntegrationData.InputAccountWithEmvRspNormal[9] = response.BarcodeData;
            fullIntegrationData.InputAccountWithEmvRspNormal[10] = response.Ksn;
            fullIntegrationData.InputAccountWithEmvRspNormal[11] = response.Etb;
            fullIntegrationData.InputAccountWithEmvRspNormal[12] = response.ContactlessTransactionPath;
            fullIntegrationData.InputAccountWithEmvRspNormal[13] = response.AuthorizationResult;
            fullIntegrationData.InputAccountWithEmvRspNormal[14] = response.SignatureFlag;
            fullIntegrationData.InputAccountWithEmvRspNormal[15] = response.OnlinePINFlag;
            fullIntegrationData.InputAccountWithEmvRspNormal[16] = response.EmvTlvData;
            fullIntegrationData.InputAccountWithEmvRspNormal[17] = response.EncryptedEmvTlvData;
            fullIntegrationData.InputAccountWithEmvRspNormal[18] = response.EncryptedSensitiveTlvData;
            fullIntegrationData.InputAccountWithEmvRspNormal[19] = response.CardHolder;
            fullIntegrationData.InputAccountWithEmvRspNormal[20] = response.Cvm;
            fullIntegrationData.InputAccountWithEmvRspNormal[21] = response.TxnResult;
            fullIntegrationData.InputAccountWithEmvRspNormal[22] = response.TxnPath;
            fullIntegrationData.InputAccountWithEmvRspNormal[23] = response.PinpadType;
            fullIntegrationData.InputAccountWithEmvRspNormal[24] = response.LuhnValidationResult;
            if(response.CustomEncryptedData != null && response.CustomEncryptedData.Length>0)
            {
                fullIntegrationData.InputAccountWithEmvRspNormal[25] = string.Join("\r\n", response.CustomEncryptedData);
            }
            else
            {
                fullIntegrationData.InputAccountWithEmvRspNormal[25] = "";
            }
            //Addition Account
            if (response.AdditionalAccountInformation != null)
            {
                fullIntegrationData.AdditionalAccountRspData[0] = response.AdditionalAccountInformation.ExpiryDate;
                fullIntegrationData.AdditionalAccountRspData[1] = response.AdditionalAccountInformation.CardHolderName;
                fullIntegrationData.AdditionalAccountRspData[2] = response.AdditionalAccountInformation.ServiceCode;
                fullIntegrationData.AdditionalAccountRspData[3] = response.AdditionalAccountInformation.CvvCode;
                fullIntegrationData.AdditionalAccountRspData[4] = response.AdditionalAccountInformation.ZipCode;
            }
            //VAS
            if(response.VasInformation != null)
            {
                fullIntegrationData.VasInfoRspData[0] = response.VasInformation.VasCode;
                fullIntegrationData.VasInfoRspData[1] = response.VasInformation.VasData;
                fullIntegrationData.VasInfoRspData[2] = response.VasInformation.NdefData;
            }
            //Custom Mac Data
            if (response.CustomMacData != null)
            {
                if (response.CustomMacData.Data == null || response.CustomMacData.Data.Length <= 0)
                {
                    fullIntegrationData.CustomMacDataRspData[0] = "";
                }
                else
                {
                    fullIntegrationData.CustomMacDataRspData[0] = string.Join("|", response.CustomMacData.Data);
                }
                fullIntegrationData.CustomMacDataRspData[1] = response.CustomMacData.Ksn;
            }
        }

        private void AddToMultipleCommandsButton_Click(object sender, EventArgs e)
        {
            _terminalData = TerminalData.GetTerminalData();
            MultipleCommandsModule multipleCommandsModule = new MultipleCommandsModule();
            switch (CommandComboBox.SelectedIndex)
            {
                case (int)FullIntegrationCommandName.GetPinBlockReq / 2://Get PIN Block
                    POSLink2.FullIntegration.GetPinBlockReq getPinBlockReq = SetGetPinBlockReq();
                    multipleCommandsModule.CommandName = CommandName.GetPinBlock;
                    multipleCommandsModule.CommandReqObject = getPinBlockReq;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)FullIntegrationCommandName.AuthorizeCardReq / 2://Auth Card
                    POSLink2.FullIntegration.AuthorizeCardReq authorizeCardReq = SetAuthorizeCardReq();
                    multipleCommandsModule.CommandName = CommandName.AuthorizeCard;
                    multipleCommandsModule.CommandReqObject = authorizeCardReq;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)FullIntegrationCommandName.CompleteOnlineEmvReq / 2://Complete online EMV
                    POSLink2.FullIntegration.CompleteOnlineEmvReq completeOnlineEmvReq = SetCompleteOnlineEmvReq();
                    multipleCommandsModule.CommandName = CommandName.CompleteOnlineEmv;
                    multipleCommandsModule.CommandReqObject = completeOnlineEmvReq;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)FullIntegrationCommandName.GetEmvTlvDataReq / 2://Get EMV TLV Data
                    POSLink2.FullIntegration.GetEmvTlvDataReq getEmvTlvDataReq = SetGetEmvTlvDataReq();
                    multipleCommandsModule.CommandName = CommandName.GetEmvTlvData;
                    multipleCommandsModule.CommandReqObject = getEmvTlvDataReq;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)FullIntegrationCommandName.SetEmvTlvDataReq / 2://Set EMV TLV Data
                    POSLink2.FullIntegration.SetEmvTlvDataReq setEmvTlvDataReq = SetSetEmvTlvDataReq();
                    multipleCommandsModule.CommandName = CommandName.SetEmvTlvData;
                    multipleCommandsModule.CommandReqObject = setEmvTlvDataReq;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)FullIntegrationCommandName.InputAccountWithEmvReq / 2://Input account with EMV
                    POSLink2.FullIntegration.InputAccountWithEmvReq inputAccountWithEmvReq = SetInputAccountWithEmvReq();
                    multipleCommandsModule.CommandName = CommandName.InputAccountWithEmv;
                    multipleCommandsModule.CommandReqObject = inputAccountWithEmvReq;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                default:
                    break;
            }
        }

        private void FullIntegrationUserControl_Load(object sender, EventArgs e)
        {
        }

        private void FullIntegrationUserControl_VisibleChanged(object sender, EventArgs e)
        {
            CommandComboBox.SelectedIndex = _comboBoxIndex;
            CommandComboBox_SelectedIndexChanged(sender,e);
        }
    }
}

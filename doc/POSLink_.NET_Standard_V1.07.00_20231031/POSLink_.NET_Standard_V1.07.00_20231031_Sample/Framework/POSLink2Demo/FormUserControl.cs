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
    public partial class FormUserControl : UserControl
    {
        private FormData _formData;
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

        public FormUserControl()
        {
            InitializeComponent();
            CommandComboBox.Items.AddRange(FormCommon.CommandNames);
            _comboBoxIndex = 0;
            CommandComboBox.SelectedIndex = 0;
            _formData = FormData.GetFormData();
            _waiting = new Waiting();
            _waiting.Dock = DockStyle.Left;
            _isCancelListening = false;
        }

        private void RunForm(int tenderType, object sender, EventArgs e)
        {
            Task task = new Task(() =>
            {
                POSLink2.ExecutionResult executionResult = new POSLink2.ExecutionResult();

                switch (tenderType)
                {
                    case (int)FormCommandName.ShowDialogReq / 2://Show Dialog
                        POSLink2.Form.ShowDialogReq showDialogReq = SetShowDialogReq();
                        POSLink2.Form.ShowDialogRsp showDialogRsp = null;
                        executionResult = _terminal.Form.ShowDialog(showDialogReq, out showDialogRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(showDialogRsp);
                        }
                        break;
                    case (int)FormCommandName.ShowMessageReq / 2://Show Message
                        POSLink2.Form.ShowMessageReq showMessageReq = SetShowMessageReq();
                        POSLink2.Form.ShowMessageRsp showMessageRsp = null;
                        executionResult = _terminal.Form.ShowMessage(showMessageReq, out showMessageRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(showMessageRsp);
                        }
                        break;
                    case (int)FormCommandName.ClearMessageReq / 2://Clear Message
                        POSLink2.Form.ClearMessageRsp clearMessageRsp = null;
                        executionResult = _terminal.Form.ClearMessage(out clearMessageRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(clearMessageRsp);
                        }
                        break;
                    case (int)FormCommandName.ShowMessageCenterReq / 2://Show Message Center
                        POSLink2.Form.ShowMessageCenterReq showMessageCenterReq = SetShowMessageCenterReq();
                        POSLink2.Form.ShowMessageCenterRsp showMessageCenterRsp = null;
                        executionResult = _terminal.Form.ShowMessageCenter(showMessageCenterReq, out showMessageCenterRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(showMessageCenterRsp);
                        }
                        break;
                    case (int)FormCommandName.InputTextReq / 2://Input Text
                        POSLink2.Form.InputTextReq inputTextReq = SetInputTextReq();
                        POSLink2.Form.InputTextRsp inputTextRsp = null;
                        executionResult = _terminal.Form.InputText(inputTextReq, out inputTextRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(inputTextRsp);
                        }
                        break;
                    case (int)FormCommandName.RemoveCardReq / 2://Remove Card
                        POSLink2.Form.RemoveCardReq removeCardReq = SetRemoveCardReq();
                        POSLink2.Form.RemoveCardRsp removeCardRsp = null;
                        executionResult = _terminal.Form.RemoveCard(removeCardReq, out removeCardRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(removeCardRsp);
                        }
                        break;
                    case (int)FormCommandName.ShowTextBoxReq / 2://Show TextBox
                        POSLink2.Form.ShowTextBoxReq showTextBoxReq = SetShowTextBoxReq();
                        POSLink2.Form.ShowTextBoxRsp showTextBoxRsp = null;
                        executionResult = _terminal.Form.ShowTextBox(showTextBoxReq, out showTextBoxRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(showTextBoxRsp);
                        }
                        break;
                    case (int)FormCommandName.ShowItemReq / 2://Show Item
                        POSLink2.Form.ShowItemReq showItemReq = SetShowItemReq();
                        POSLink2.Form.ShowItemRsp showItemRsp = null;
                        executionResult = _terminal.Form.ShowItem(showItemReq, out showItemRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(showItemRsp);
                        }
                        break;
                    case (int)FormCommandName.ShowDialogFormReq / 2://Show Dialog Form
                        POSLink2.Form.ShowDialogFormReq showDialogFormReq = SetShowDialogFormReq();
                        POSLink2.Form.ShowDialogFormRsp showDialogFormRsp = null;
                        executionResult = _terminal.Form.ShowDialogForm(showDialogFormReq, out showDialogFormRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(showDialogFormRsp);
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
                        MessageBox.Show("Receive ack timeout!","ERROR");
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
                int reportStatus = -1;
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
            _formData.ResponseClear();
            _waiting.Location = new Point(0, 0);
            _waiting.IsCancelAvaliable = true;
            this.Controls.Add(_waiting);
            _waiting.BringToFront();
            _waiting.Show();

            int tenderType = CommandComboBox.SelectedIndex;
            RunForm(tenderType, sender, e);
            _isCancelListening = true;
            RunListener();
        }

        private void CommandComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _comboBoxIndex = CommandComboBox.SelectedIndex;
            _tools.DisposeSubControls(panel1);
            if (CommandComboBox.SelectedIndex == 0)//Show Dialog
            {
                FormOnePanelUserControl showDialogReqUserControl = new FormOnePanelUserControl();
                showDialogReqUserControl.CommandName = FormCommandName.ShowDialogReq;
                showDialogReqUserControl.Dock = DockStyle.Left;
                showDialogReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(showDialogReqUserControl);

                FormOnePanelUserControl showDialogRspUserControl = new FormOnePanelUserControl();
                showDialogRspUserControl.CommandName = FormCommandName.ShowDialogRsp;
                showDialogRspUserControl.Dock = DockStyle.Left;
                showDialogRspUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(showDialogRspUserControl);

                showDialogReqUserControl.SendToBack();
            }
            else if (CommandComboBox.SelectedIndex == 1)//Show Message
            {
                FormOnePanelUserControl showMessageReqUserControl = new FormOnePanelUserControl();
                showMessageReqUserControl.CommandName = FormCommandName.ShowMessageReq;
                showMessageReqUserControl.Dock = DockStyle.Left;
                showMessageReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(showMessageReqUserControl);

                FormOnePanelUserControl showMessageRspUserControl = new FormOnePanelUserControl();
                showMessageRspUserControl.CommandName = FormCommandName.ShowMessageRsp;
                showMessageRspUserControl.Dock = DockStyle.Left;
                showMessageRspUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(showMessageRspUserControl);

                showMessageReqUserControl.SendToBack();
            }
            else if (CommandComboBox.SelectedIndex == 2)//Clear Message
            {
                FormOnePanelUserControl clearMessageReqUserControl = new FormOnePanelUserControl();
                clearMessageReqUserControl.CommandName = FormCommandName.ClearMessageReq;
                clearMessageReqUserControl.Dock = DockStyle.Left;
                clearMessageReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(clearMessageReqUserControl);

                FormOnePanelUserControl clearMessageRspUserControl = new FormOnePanelUserControl();
                clearMessageRspUserControl.CommandName = FormCommandName.ClearMessageRsp;
                clearMessageRspUserControl.Dock = DockStyle.Left;
                clearMessageRspUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(clearMessageRspUserControl);

                clearMessageReqUserControl.SendToBack();
            }
            else if (CommandComboBox.SelectedIndex == 3)//Show Message Center
            {
                FormOnePanelUserControl showMessageCenterReqUserControl = new FormOnePanelUserControl();
                showMessageCenterReqUserControl.CommandName = FormCommandName.ShowMessageCenterReq;
                showMessageCenterReqUserControl.Dock = DockStyle.Left;
                showMessageCenterReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(showMessageCenterReqUserControl);

                FormOnePanelUserControl showMessageCenterRspUserControl = new FormOnePanelUserControl();
                showMessageCenterRspUserControl.CommandName = FormCommandName.ShowMessageCenterRsp;
                showMessageCenterRspUserControl.Dock = DockStyle.Left;
                showMessageCenterRspUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(showMessageCenterRspUserControl);

                showMessageCenterReqUserControl.SendToBack();
            }
            else if (CommandComboBox.SelectedIndex == 4)//Input Text
            {
                FormOnePanelUserControl inputTextCenterReqUserControl = new FormOnePanelUserControl();
                inputTextCenterReqUserControl.CommandName = FormCommandName.InputTextReq;
                inputTextCenterReqUserControl.Dock = DockStyle.Left;
                inputTextCenterReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(inputTextCenterReqUserControl);

                FormOnePanelUserControl inputTextCenterRspUserControl = new FormOnePanelUserControl();
                inputTextCenterRspUserControl.CommandName = FormCommandName.InputTextRsp;
                inputTextCenterRspUserControl.Dock = DockStyle.Left;
                inputTextCenterRspUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(inputTextCenterRspUserControl);

                inputTextCenterReqUserControl.SendToBack();
            }
            else if (CommandComboBox.SelectedIndex == 5)//Remove Card
            {
                FormOnePanelUserControl removeCardReqUserControl = new FormOnePanelUserControl();
                removeCardReqUserControl.CommandName = FormCommandName.RemoveCardReq;
                removeCardReqUserControl.Dock = DockStyle.Left;
                removeCardReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(removeCardReqUserControl);

                FormOnePanelUserControl removeCardRspUserControl = new FormOnePanelUserControl();
                removeCardRspUserControl.CommandName = FormCommandName.RemoveCardRsp;
                removeCardRspUserControl.Dock = DockStyle.Left;
                removeCardRspUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(removeCardRspUserControl);

                removeCardReqUserControl.SendToBack();
            }
            else if (CommandComboBox.SelectedIndex == 6)//Show TextBox
            {
                FormOnePanelUserControl showTextBoxReqUserControl = new FormOnePanelUserControl();
                showTextBoxReqUserControl.CommandName = FormCommandName.ShowTextBoxReq;
                showTextBoxReqUserControl.Dock = DockStyle.Left;
                showTextBoxReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(showTextBoxReqUserControl);

                FormOnePanelUserControl showTextBoxRspUserControl = new FormOnePanelUserControl();
                showTextBoxRspUserControl.CommandName = FormCommandName.ShowTextBoxRsp;
                showTextBoxRspUserControl.Dock = DockStyle.Left;
                showTextBoxRspUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(showTextBoxRspUserControl);

                showTextBoxReqUserControl.SendToBack();
            }
            else if (CommandComboBox.SelectedIndex == 7)//Show Item
            {
                FormOnePanelUserControl showItemBoxReqUserControl = new FormOnePanelUserControl();
                showItemBoxReqUserControl.CommandName = FormCommandName.ShowItemReq;
                showItemBoxReqUserControl.Dock = DockStyle.Left;
                showItemBoxReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(showItemBoxReqUserControl);

                FormOnePanelUserControl showItemBoxRspUserControl = new FormOnePanelUserControl();
                showItemBoxRspUserControl.CommandName = FormCommandName.ShowItemRsp;
                showItemBoxRspUserControl.Dock = DockStyle.Left;
                showItemBoxRspUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(showItemBoxRspUserControl);

                showItemBoxReqUserControl.SendToBack();
            }
            else if (CommandComboBox.SelectedIndex == 8)//Show Dialog Form
            {
                FormOnePanelUserControl showDialogFormReqUserControl = new FormOnePanelUserControl();
                showDialogFormReqUserControl.CommandName = FormCommandName.ShowDialogFormReq;
                showDialogFormReqUserControl.Dock = DockStyle.Left;
                showDialogFormReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(showDialogFormReqUserControl);

                FormOnePanelUserControl showDialogFormRspUserControl = new FormOnePanelUserControl();
                showDialogFormRspUserControl.CommandName = FormCommandName.ShowDialogFormRsp;
                showDialogFormRspUserControl.Dock = DockStyle.Left;
                showDialogFormRspUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(showDialogFormRspUserControl);

                showDialogFormReqUserControl.SendToBack();
            }
        }

        private POSLink2.Form.ShowDialogReq SetShowDialogReq()
        {
            POSLink2.Form.ShowDialogReq request = new POSLink2.Form.ShowDialogReq();
            request.Title = _formData.ShowDialogReqNormalData[0];
            request.ButtonName1 = _formData.ShowDialogReqNormalData[1];
            request.ButtonName2 = _formData.ShowDialogReqNormalData[2];
            request.ButtonName3 = _formData.ShowDialogReqNormalData[3];
            request.ButtonName4 = _formData.ShowDialogReqNormalData[4];
            request.Timeout = _formData.ShowDialogReqNormalData[5];
            request.ContinuousScreen = _formData.ShowDialogReqNormalData[6];
            return request;
        }

        private POSLink2.Form.ShowMessageReq SetShowMessageReq()
        {
            POSLink2.Form.ShowMessageReq request = new POSLink2.Form.ShowMessageReq();
            request.Title = _formData.ShowMessageReqNormalData[0];
            request.DisplayMessage1 = _formData.ShowMessageReqNormalData[1];
            request.DisplayMessage2 = _formData.ShowMessageReqNormalData[2];
            request.TopDown = _formData.ShowMessageReqNormalData[3];
            request.TaxLine = _formData.ShowMessageReqNormalData[4];
            request.TotalLine = _formData.ShowMessageReqNormalData[5];
            request.ImageName = _formData.ShowMessageReqNormalData[6];
            request.ImageDescription = _formData.ShowMessageReqNormalData[7];
            request.LineItemAction = _formData.ShowMessageReqNormalData[8];
            request.ItemIndex = _formData.ShowMessageReqNormalData[9];
            return request;
        }

        private POSLink2.Form.ShowMessageCenterReq SetShowMessageCenterReq()
        {
            POSLink2.Form.ShowMessageCenterReq request = new POSLink2.Form.ShowMessageCenterReq();
            request.Title = _formData.ShowMessageCenterReqNormalData[0];
            request.Message1 = _formData.ShowMessageCenterReqNormalData[1];
            request.Message2 = _formData.ShowMessageCenterReqNormalData[2];
            request.Timeout = _formData.ShowMessageCenterReqNormalData[3];
            request.PinpadType = _formData.ShowMessageCenterReqNormalData[4];
            request.IconName = _formData.ShowMessageCenterReqNormalData[5];
            return request;
        }

        private POSLink2.Form.InputTextReq SetInputTextReq()
        {
            POSLink2.Form.InputTextReq request = new POSLink2.Form.InputTextReq();
            request.Title = _formData.InputTextReqNormalData[0];
            request.InputType = _formData.InputTextReqNormalData[1];
            request.MinLength = _formData.InputTextReqNormalData[2];
            request.MaxLength = _formData.InputTextReqNormalData[3];
            request.DefaultValue = _formData.InputTextReqNormalData[4];
            request.Timeout = _formData.InputTextReqNormalData[5];
            request.ContinuousScreen = _formData.InputTextReqNormalData[6];
            return request;
        }

        private POSLink2.Form.RemoveCardReq SetRemoveCardReq()
        {
            POSLink2.Form.RemoveCardReq request = new POSLink2.Form.RemoveCardReq();
            request.Message1 = _formData.RemoveCardReqNormalData[0];
            request.Message2 = _formData.RemoveCardReqNormalData[1];
            request.ContinuousScreen = _formData.RemoveCardReqNormalData[2];
            request.PinpadType = _formData.RemoveCardReqNormalData[3];
            return request;
        }

        private POSLink2.Form.ShowTextBoxReq SetShowTextBoxReq()
        {
            POSLink2.Form.ShowTextBoxReq request = new POSLink2.Form.ShowTextBoxReq();
            request.Title = _formData.ShowTextBoxReqNormalDara[0];
            request.Text = _formData.ShowTextBoxReqNormalDara[1];
            request.ButtonName1 = _formData.ShowTextBoxReqNormalDara[2];
            request.ButtonColor1 = _formData.ShowTextBoxReqNormalDara[3];
            request.ButtonName2 = _formData.ShowTextBoxReqNormalDara[4];
            request.ButtonColor2 = _formData.ShowTextBoxReqNormalDara[5];
            request.ButtonName3 = _formData.ShowTextBoxReqNormalDara[6];
            request.ButtonColor3 = _formData.ShowTextBoxReqNormalDara[7];
            request.Timeout = _formData.ShowTextBoxReqNormalDara[8];
            request.ButtonKey1 = _formData.ShowTextBoxReqNormalDara[9];
            request.ButtonKey2 = _formData.ShowTextBoxReqNormalDara[10];
            request.ButtonKey3 = _formData.ShowTextBoxReqNormalDara[11];
            request.EnableHardKeyOnly = _formData.ShowTextBoxReqNormalDara[12];
            request.HardKeyList = _formData.ShowTextBoxReqNormalDara[13];
            request.SignatureBox = _formData.ShowTextBoxReqNormalDara[14];
            request.ContinuousScreen = _formData.ShowTextBoxReqNormalDara[15];
            request.BarcodeType = _formData.ShowTextBoxReqNormalDara[16];
            request.BarcodeData = _formData.ShowTextBoxReqNormalDara[17];
            request.InputTextTitle = _formData.ShowTextBoxReqNormalDara[18];
            request.InputText = _formData.ShowTextBoxReqNormalDara[19];
            request.InputType = _formData.ShowTextBoxReqNormalDara[20];
            request.MinLength = _formData.ShowTextBoxReqNormalDara[21];
            request.MaxLength = _formData.ShowTextBoxReqNormalDara[22];
            return request;
        }

        private POSLink2.Form.ShowItemReq SetShowItemReq()
        {
            POSLink2.Form.ShowItemReq request = new POSLink2.Form.ShowItemReq();
            request.Title = _formData.ShowItemReqNormalData[0];
            request.Topdown = _formData.ShowItemReqNormalData[1];
            request.TaxLine = _formData.ShowItemReqNormalData[2];
            request.TotalLine = _formData.ShowItemReqNormalData[3];
            if(_formData.ItemDetailData == null || _formData.ItemDetailData.Length == 0)
            {
                request.ItemDetail = _formData.ShowItemReqNormalData[4];
            }
            else
            {
                request.SetItemDetail(_formData.ItemDetailData);
            }
            request.LineItemAction = _formData.ShowItemReqNormalData[5];
            request.ItemIndex = _formData.ShowItemReqNormalData[6];
            return request;
        }

        private POSLink2.Form.ShowDialogFormReq SetShowDialogFormReq()
        {
            POSLink2.Form.ShowDialogFormReq request = new POSLink2.Form.ShowDialogFormReq();
            request.Title = _formData.ShowDialogFormReqNormalData[0];
            request.Label1 = _formData.ShowDialogFormReqNormalData[1];
            request.Label1Property = _formData.ShowDialogFormReqNormalData[2];
            request.Label2 = _formData.ShowDialogFormReqNormalData[3];
            request.Label2Property = _formData.ShowDialogFormReqNormalData[4];
            request.Label3 = _formData.ShowDialogFormReqNormalData[5];
            request.Label3Property = _formData.ShowDialogFormReqNormalData[6];
            request.Label4 = _formData.ShowDialogFormReqNormalData[7];
            request.Label4Property = _formData.ShowDialogFormReqNormalData[8];
            request.ButtonType = _formData.ShowDialogFormReqNormalData[9];
            request.Timeout = _formData.ShowDialogFormReqNormalData[10];
            request.ContinuousScreen = _formData.ShowDialogFormReqNormalData[11];
            return request;
        }

        public static void GetResponse(POSLink2.Form.ShowDialogRsp response)
        {
            FormData formData = FormData.GetFormData();
            formData.ShowDialogRspNormalData[0] = response.ResponseCode;
            formData.ShowDialogRspNormalData[1] = response.ResponseMessage;
            formData.ShowDialogRspNormalData[2] = response.ButtonNumber;
        }

        public static void GetResponse(POSLink2.Form.ShowMessageRsp response)
        {
            FormData formData = FormData.GetFormData();
            formData.ShowMessageRspNormalData[0] = response.ResponseCode;
            formData.ShowMessageRspNormalData[1] = response.ResponseMessage;
        }

        public static void GetResponse(POSLink2.Form.ClearMessageRsp response)
        {
            FormData formData = FormData.GetFormData();
            formData.ClearMessageRspNormalData[0] = response.ResponseCode;
            formData.ClearMessageRspNormalData[1] = response.ResponseMessage;
        }

        public static void GetResponse(POSLink2.Form.ShowMessageCenterRsp response)
        {
            FormData formData = FormData.GetFormData();
            formData.ShowMessageCenterRspNormalData[0] = response.ResponseCode;
            formData.ShowMessageCenterRspNormalData[1] = response.ResponseMessage;
            formData.ShowMessageCenterRspNormalData[2] = response.PinpadType;
        }

        public static void GetResponse(POSLink2.Form.InputTextRsp response)
        {
            FormData formData = FormData.GetFormData();
            formData.InputTextRspNormalData[0] = response.ResponseCode;
            formData.InputTextRspNormalData[1] = response.ResponseMessage;
            formData.InputTextRspNormalData[2] = response.Text;
        }

        public static void GetResponse(POSLink2.Form.RemoveCardRsp response)
        {
            FormData formData = FormData.GetFormData();
            formData.RemoveCardRspNormalData[0] = response.ResponseCode;
            formData.RemoveCardRspNormalData[1] = response.ResponseMessage;
            formData.RemoveCardRspNormalData[2] = response.PinpadType;
        }

        public static void GetResponse(POSLink2.Form.ShowTextBoxRsp response)
        {
            FormData formData = FormData.GetFormData();
            formData.ShowTextBoxRspNormalDara[0] = response.ResponseCode;
            formData.ShowTextBoxRspNormalDara[1] = response.ResponseMessage;
            formData.ShowTextBoxRspNormalDara[2] = response.ButtonNumber;
            formData.ShowTextBoxRspNormalDara[3] = response.SignStatus;
            formData.ShowTextBoxRspNormalDara[4] = response.SignatureData;
            formData.ShowTextBoxRspNormalDara[5] = response.Text;
        }

        public static void GetResponse(POSLink2.Form.ShowItemRsp response)
        {
            FormData formData = FormData.GetFormData();
            formData.ShowItemRspNormalData[0] = response.ResponseCode;
            formData.ShowItemRspNormalData[1] = response.ResponseMessage;
        }

        public static void GetResponse(POSLink2.Form.ShowDialogFormRsp response)
        {
            FormData formData = FormData.GetFormData();
            formData.ShowDialogFormRspNormalData[0] = response.ResponseCode;
            formData.ShowDialogFormRspNormalData[1] = response.ResponseMessage;
            formData.ShowDialogFormRspNormalData[2] = response.LabelSelected;
        }

        private void AddToMultipleCommandsButton_Click(object sender, EventArgs e)
        {
            _terminalData = TerminalData.GetTerminalData();
            MultipleCommandsModule multipleCommandsModule = new MultipleCommandsModule();
            switch (CommandComboBox.SelectedIndex)
            {
                case (int)FormCommandName.ShowDialogReq / 2://Show Dialog
                    POSLink2.Form.ShowDialogReq showDialogReq = SetShowDialogReq();
                    multipleCommandsModule.CommandName = CommandName.ShowDialog;
                    multipleCommandsModule.CommandReqObject = showDialogReq;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)FormCommandName.ShowMessageReq / 2://Show Message
                    POSLink2.Form.ShowMessageReq showMessageReq = SetShowMessageReq();
                    multipleCommandsModule.CommandName = CommandName.ShowMessage;
                    multipleCommandsModule.CommandReqObject = showMessageReq;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)FormCommandName.ClearMessageReq / 2://Clear Message
                    multipleCommandsModule.CommandName = CommandName.ClearMessage;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)FormCommandName.ShowMessageCenterReq / 2://Show Message Center
                    POSLink2.Form.ShowMessageCenterReq showMessageCenterReq = SetShowMessageCenterReq();
                    multipleCommandsModule.CommandName = CommandName.ShowMessageCenter;
                    multipleCommandsModule.CommandReqObject = showMessageCenterReq;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)FormCommandName.InputTextReq / 2://Input Text
                    POSLink2.Form.InputTextReq inputTextReq = SetInputTextReq();
                    multipleCommandsModule.CommandName = CommandName.InputText;
                    multipleCommandsModule.CommandReqObject = inputTextReq;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)FormCommandName.RemoveCardReq / 2://Remove Card
                    POSLink2.Form.RemoveCardReq removeCardReq = SetRemoveCardReq();
                    multipleCommandsModule.CommandName = CommandName.RemoveCard;
                    multipleCommandsModule.CommandReqObject = removeCardReq;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)FormCommandName.ShowTextBoxReq / 2://Show TextBox
                    POSLink2.Form.ShowTextBoxReq showTextBoxReq = SetShowTextBoxReq();
                    multipleCommandsModule.CommandName = CommandName.ShowTextBox;
                    multipleCommandsModule.CommandReqObject = showTextBoxReq;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)FormCommandName.ShowItemReq / 2://Show Item
                    POSLink2.Form.ShowItemReq showItemReq = SetShowItemReq();
                    multipleCommandsModule.CommandName = CommandName.ShowItem;
                    multipleCommandsModule.CommandReqObject = showItemReq;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)FormCommandName.ShowDialogFormReq / 2://Show Dialog Form
                    POSLink2.Form.ShowDialogFormReq showDialogFormReq = SetShowDialogFormReq();
                    multipleCommandsModule.CommandName = CommandName.ShowDialogForm;
                    multipleCommandsModule.CommandReqObject = showDialogFormReq;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                default:
                    break;
            }
        }

        private void FormUserControl_Load(object sender, EventArgs e)
        {
        }

        private void FormUserControl_VisibleChanged(object sender, EventArgs e)
        {
            CommandComboBox.SelectedIndex = _comboBoxIndex;
            CommandComboBox_SelectedIndexChanged(sender, e);
        }
    }
}

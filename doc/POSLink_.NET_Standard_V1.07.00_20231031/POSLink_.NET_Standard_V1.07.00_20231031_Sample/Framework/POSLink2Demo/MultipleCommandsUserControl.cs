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
    public partial class MultipleCommandsUserControl : UserControl
    {
        private POSLink2.Terminal _terminal;
        public POSLink2.Terminal Terminal
        {
            get { return _terminal; }
            set { _terminal = value; }
        }

        private Waiting _waiting;
        private TerminalData _terminalData;
        private TransactionData _transactionData;
        private BatchData _batchData;
        private ReportData _reportData;
        private ManageData _manageData;
        private FormData _formData;
        private DeviceData _deviceData;
        private FullIntegrationData _fullIntegrationData;
        private PedData _pandData;
        public MultipleCommandsUserControl()
        {
            InitializeComponent();
            _waiting = new Waiting();
            _waiting.Dock = DockStyle.Left;
            _terminalData = TerminalData.GetTerminalData();
            _transactionData = TransactionData.GetTransactionData();
            _batchData = BatchData.GetBatchData();
            _reportData = ReportData.GetReportData();
            _manageData = ManageData.GetManageData();
            _formData = FormData.GetFormData();
            _deviceData = DeviceData.GetDeviceData();
            _fullIntegrationData = FullIntegrationData.GetFullIntegrationData();
            _pandData = PedData.GetPedData();
        }

        private void RunMultipleCommands()
        {
            Task task = new Task(()=>{
                _terminal.BeginMultiCmdMode();
                for (int i = 0; i < _terminalData.MultipleCommands.Count; i++)
                {
                    switch (_terminalData.MultipleCommands[i].CommandName)
                    {
                        //Transaction
                        case CommandName.DoCredit:
                            POSLink2.Transaction.DoCreditRsp doCreditRsp = null;
                            _terminal.Transaction.DoCredit((POSLink2.Transaction.DoCreditReq)_terminalData.MultipleCommands[i].CommandReqObject, out doCreditRsp);
                            break;
                        case CommandName.DoDebit:
                            POSLink2.Transaction.DoDebitRsp doDebitRsp = null;
                            _terminal.Transaction.DoDebit((POSLink2.Transaction.DoDebitReq)_terminalData.MultipleCommands[i].CommandReqObject, out doDebitRsp);
                            break;
                        case CommandName.DoEBT:
                            POSLink2.Transaction.DoEbtRsp doEbtRsp = null;
                            _terminal.Transaction.DoEbt((POSLink2.Transaction.DoEbtReq)_terminalData.MultipleCommands[i].CommandReqObject, out doEbtRsp);
                            break;
                        case CommandName.DoGift:
                            POSLink2.Transaction.DoGiftRsp doGiftRsp = null;
                            _terminal.Transaction.DoGift((POSLink2.Transaction.DoGiftReq)_terminalData.MultipleCommands[i].CommandReqObject, out doGiftRsp);
                            break;
                        case CommandName.DoLoyalty:
                            POSLink2.Transaction.DoLoyaltyRsp doLoyaltyRsp = null;
                            _terminal.Transaction.DoLoyalty((POSLink2.Transaction.DoLoyaltyReq)_terminalData.MultipleCommands[i].CommandReqObject, out doLoyaltyRsp);
                            break;
                        case CommandName.DoCash:
                            POSLink2.Transaction.DoCashRsp doCashRsp = null;
                            _terminal.Transaction.DoCash((POSLink2.Transaction.DoCashReq)_terminalData.MultipleCommands[i].CommandReqObject, out doCashRsp);
                            break;
                        case CommandName.DoCheck:
                            POSLink2.Transaction.DoCheckRsp doCheckRsp = null;
                            _terminal.Transaction.DoCheck((POSLink2.Transaction.DoCheckReq)_terminalData.MultipleCommands[i].CommandReqObject, out doCheckRsp);
                            break;

                        //Batch
                        case CommandName.BatchClose:
                            POSLink2.Batch.BatchCloseRsp batchCloseRsp = null;
                            _terminal.Batch.BatchClose((POSLink2.Batch.BatchCloseReq)_terminalData.MultipleCommands[i].CommandReqObject, out batchCloseRsp);
                            break;
                        case CommandName.ForceBatchClose:
                            POSLink2.Batch.ForceBatchCloseRsp forceBatchCloseRsp = null;
                            _terminal.Batch.ForceBatchClose((POSLink2.Batch.ForceBatchCloseReq)_terminalData.MultipleCommands[i].CommandReqObject, out forceBatchCloseRsp);
                            break;
                        case CommandName.BatchClear:
                            POSLink2.Batch.BatchClearRsp batchClearRsp = null;
                            _terminal.Batch.BatchClear((POSLink2.Batch.BatchClearReq)_terminalData.MultipleCommands[i].CommandReqObject, out batchClearRsp);
                            break;
                        case CommandName.PurgeBatch:
                            POSLink2.Batch.PurgeBatchRsp purgeBatchRsp = null;
                            _terminal.Batch.PurgeBatch((POSLink2.Batch.PurgeBatchReq)_terminalData.MultipleCommands[i].CommandReqObject, out purgeBatchRsp);
                            break;
                        case CommandName.SAFUpload:
                            POSLink2.Batch.SafUploadRsp safUploadRsp = null;
                            _terminal.Batch.SafUpload((POSLink2.Batch.SafUploadReq)_terminalData.MultipleCommands[i].CommandReqObject, out safUploadRsp);
                            break;
                        case CommandName.DeleteSAFFile:
                            POSLink2.Batch.DeleteSafFileRsp deleteSafFileRsp = null;
                            _terminal.Batch.DeleteSafFile((POSLink2.Batch.DeleteSafFileReq)_terminalData.MultipleCommands[i].CommandReqObject, out deleteSafFileRsp);
                            break;
                        case CommandName.DeleteTransaction:
                            POSLink2.Batch.DeleteTransactionRsp deleteTransactionRsp = null;
                            _terminal.Batch.DeleteTransaction((POSLink2.Batch.DeleteTransactionReq)_terminalData.MultipleCommands[i].CommandReqObject, out deleteTransactionRsp);
                            break;

                        //Report
                        case CommandName.LocalTotalReport:
                            POSLink2.Report.LocalTotalReportRsp localTotalReportRsp = null;
                            _terminal.Report.LocalTotalReport((POSLink2.Report.LocalTotalReportReq)_terminalData.MultipleCommands[i].CommandReqObject, out localTotalReportRsp);
                            break;
                        case CommandName.LocalDetailReport:
                            POSLink2.Report.LocalDetailReportRsp localDetailReportRsp = null;
                            _terminal.Report.LocalDetailReport((POSLink2.Report.LocalDetailReportReq)_terminalData.MultipleCommands[i].CommandReqObject, out localDetailReportRsp);
                            break;
                        case CommandName.LocalFailedReport:
                            POSLink2.Report.LocalFailedReportRsp localFailedReportRsp = null;
                            _terminal.Report.LocalFailedReport(out localFailedReportRsp);
                            break;
                        case CommandName.HostReport:
                            POSLink2.Report.HostReportRsp hostReportRsp = null;
                            _terminal.Report.HostReport(out hostReportRsp);
                            break;
                        case CommandName.HistoryReport:
                            POSLink2.Report.HistoryReportRsp historyReportRsp = null;
                            _terminal.Report.HistoryReport(out historyReportRsp);
                            break;
                        case CommandName.SAFSummaryReport:
                            POSLink2.Report.SafSummaryReportRsp safSummaryReportRsp = null;
                            _terminal.Report.SafSummaryReport((POSLink2.Report.SafSummaryReportReq)_terminalData.MultipleCommands[i].CommandReqObject, out safSummaryReportRsp);
                            break;
                        case CommandName.HostDetailReport:
                            POSLink2.Report.HostDetailReportRsp hostDetailReportRsp = null;
                            _terminal.Report.HostDetailReport((POSLink2.Report.HostDetailReportReq)_terminalData.MultipleCommands[i].CommandReqObject, out hostDetailReportRsp);
                            break;

                        //Manage
                        case CommandName.Init:
                            POSLink2.Manage.InitRsp initRsp = null;
                            _terminal.Manage.Init(out initRsp);
                            break;
                        case CommandName.GetVariable:
                            POSLink2.Manage.GetVariableRsp getVariableRsp = null;
                            _terminal.Manage.GetVariable((POSLink2.Manage.GetVariableReq)_terminalData.MultipleCommands[i].CommandReqObject, out getVariableRsp);
                            break;
                        case CommandName.SetVariable:
                            POSLink2.Manage.SetVariableRsp setVariableRsp = null;
                            _terminal.Manage.SetVariable((POSLink2.Manage.SetVariableReq)_terminalData.MultipleCommands[i].CommandReqObject, out setVariableRsp);
                            break;
                        case CommandName.GetSignature:
                            POSLink2.Manage.GetSignatureRsp getSignatureRsp = null;
                            _terminal.Manage.GetSignature(out getSignatureRsp);
                            break;
                        case CommandName.Reset:
                            POSLink2.Manage.ResetRsp resetRsp = null;
                            _terminal.Manage.Reset(out resetRsp);
                            break;
                        case CommandName.DoSignature:
                            POSLink2.Manage.DoSignatureRsp doSignatureRsp = null;
                            _terminal.Manage.DoSignature((POSLink2.Manage.DoSignatureReq)_terminalData.MultipleCommands[i].CommandReqObject, out doSignatureRsp);
                            break;
                        case CommandName.DeleteImage:
                            POSLink2.Manage.DeleteImageRsp deleteImageRsp = null;
                            _terminal.Manage.DeleteImage((POSLink2.Manage.DeleteImageReq)_terminalData.MultipleCommands[i].CommandReqObject, out deleteImageRsp);
                            break;
                        case CommandName.Reboot:
                            POSLink2.Manage.RebootRsp rebootRsp = null;
                            _terminal.Manage.Reboot(out rebootRsp);
                            break;
                        case CommandName.InputAccount:
                            POSLink2.Manage.InputAccountRsp inputAccountRsp = null;
                            _terminal.Manage.InputAccount((POSLink2.Manage.InputAccountReq)_terminalData.MultipleCommands[i].CommandReqObject, out inputAccountRsp);
                            break;
                        case CommandName.ResetMsr:
                            POSLink2.Manage.ResetMsrRsp resetMsrRsp = null;
                            _terminal.Manage.ResetMsr(out resetMsrRsp);
                            break;
                        case CommandName.CheckFile:
                            POSLink2.Manage.CheckFileRsp checkFileRsp = null;
                            _terminal.Manage.CheckFile((POSLink2.Manage.CheckFileReq)_terminalData.MultipleCommands[i].CommandReqObject, out checkFileRsp);
                            break;
                        case CommandName.SetSafParameters:
                            POSLink2.Manage.SetSafParametersRsp setSafParametersRsp = null;
                            _terminal.Manage.SetSafParameters((POSLink2.Manage.SetSafParametersReq)_terminalData.MultipleCommands[i].CommandReqObject, out setSafParametersRsp);
                            break;
                        case CommandName.Reprint:
                            POSLink2.Manage.ReprintRsp reprintRsp = null;
                            _terminal.Manage.Reprint((POSLink2.Manage.ReprintReq)_terminalData.MultipleCommands[i].CommandReqObject, out reprintRsp);
                            break;
                        case CommandName.TokenAdministrative:
                            POSLink2.Manage.TokenAdministrativeRsp tokenAdministrativeRsp = null;
                            _terminal.Manage.TokenAdministrative((POSLink2.Manage.TokenAdministrativeReq)_terminalData.MultipleCommands[i].CommandReqObject, out tokenAdministrativeRsp);
                            break;
                        case CommandName.VasSetMerchantParameters:
                            POSLink2.Manage.VasSetMerchantParametersRsp vasSetMerchantParametersRsp = null;
                            _terminal.Manage.VasSetMerchantParameters((POSLink2.Manage.VasSetMerchantParametersReq)_terminalData.MultipleCommands[i].CommandReqObject, out vasSetMerchantParametersRsp);
                            break;
                        case CommandName.VasPushData:
                            POSLink2.Manage.VasPushDataRsp vasPushDataRsp = null;
                            _terminal.Manage.VasPushData((POSLink2.Manage.VasPushDataReq)_terminalData.MultipleCommands[i].CommandReqObject, out vasPushDataRsp);
                            break;
                        case CommandName.GetSafParameters:
                            POSLink2.Manage.GetSafParametersRsp getSafParametersRsp = null;
                            _terminal.Manage.GetSafParameters(out getSafParametersRsp);
                            break;

                        //Form
                        case CommandName.ShowDialog:
                            POSLink2.Form.ShowDialogRsp showDialogRsp = null;
                            _terminal.Form.ShowDialog((POSLink2.Form.ShowDialogReq)_terminalData.MultipleCommands[i].CommandReqObject, out showDialogRsp);
                            break;
                        case CommandName.ShowMessage:
                            POSLink2.Form.ShowMessageRsp showMessageRsp = null;
                            _terminal.Form.ShowMessage((POSLink2.Form.ShowMessageReq)_terminalData.MultipleCommands[i].CommandReqObject, out showMessageRsp);
                            break;
                        case CommandName.ClearMessage:
                            POSLink2.Form.ClearMessageRsp clearMessageRsp = null;
                            _terminal.Form.ClearMessage(out clearMessageRsp);
                            break;
                        case CommandName.ShowMessageCenter:
                            POSLink2.Form.ShowMessageCenterRsp showMessageCenterRsp = null;
                            _terminal.Form.ShowMessageCenter((POSLink2.Form.ShowMessageCenterReq)_terminalData.MultipleCommands[i].CommandReqObject, out showMessageCenterRsp);
                            break;
                        case CommandName.InputText:
                            POSLink2.Form.InputTextRsp inputTextRsp = null;
                            _terminal.Form.InputText((POSLink2.Form.InputTextReq)_terminalData.MultipleCommands[i].CommandReqObject, out inputTextRsp);
                            break;
                        case CommandName.RemoveCard:
                            POSLink2.Form.RemoveCardRsp removeCardRsp = null;
                            _terminal.Form.RemoveCard((POSLink2.Form.RemoveCardReq)_terminalData.MultipleCommands[i].CommandReqObject, out removeCardRsp);
                            break;
                        case CommandName.ShowTextBox:
                            POSLink2.Form.ShowTextBoxRsp showTextBoxRsp = null;
                            _terminal.Form.ShowTextBox((POSLink2.Form.ShowTextBoxReq)_terminalData.MultipleCommands[i].CommandReqObject, out showTextBoxRsp);
                            break;
                        case CommandName.ShowItem:
                            POSLink2.Form.ShowItemRsp showItemRsp = null;
                            _terminal.Form.ShowItem((POSLink2.Form.ShowItemReq)_terminalData.MultipleCommands[i].CommandReqObject, out showItemRsp);
                            break;
                        case CommandName.ShowDialogForm:
                            POSLink2.Form.ShowDialogFormRsp showDialogFormRsp = null;
                            _terminal.Form.ShowDialogForm((POSLink2.Form.ShowDialogFormReq)_terminalData.MultipleCommands[i].CommandReqObject, out showDialogFormRsp);
                            break;

                        //Device
                        case CommandName.Printer:
                            POSLink2.Device.PrinterRsp printerRsp = null;
                            _terminal.Device.Printer.Print((POSLink2.Device.PrinterReq)_terminalData.MultipleCommands[i].CommandReqObject, out printerRsp);
                            break;
                        case CommandName.CardInsertDetection:
                            POSLink2.Device.CardInsertDetectionRsp cardInsertDetectionRsp = null;
                            _terminal.Device.Card.CardInsertDetection(out cardInsertDetectionRsp);
                            break;
                        case CommandName.CameraScan:
                            POSLink2.Device.CameraScanRsp cameraScanRsp = null;
                            _terminal.Device.Camera.CameraScan((POSLink2.Device.CameraScanReq)_terminalData.MultipleCommands[i].CommandReqObject, out cameraScanRsp);
                            break;
                        case CommandName.MifareCard:
                            POSLink2.Device.MifareCardRsp mifareCardRsp = null;
                            _terminal.Device.MifareCard.Operate((POSLink2.Device.MifareCardReq)_terminalData.MultipleCommands[i].CommandReqObject, out mifareCardRsp);
                            break;

                        //Full Integration
                        case CommandName.GetPinBlock:
                            POSLink2.FullIntegration.GetPinBlockRsp getPinBlockRsp = null;
                            _terminal.FullIntegration.GetPinBlock((POSLink2.FullIntegration.GetPinBlockReq)_terminalData.MultipleCommands[i].CommandReqObject, out getPinBlockRsp);
                            break;
                        case CommandName.AuthorizeCard:
                            POSLink2.FullIntegration.AuthorizeCardRsp authorizeCardRsp = null;
                            _terminal.FullIntegration.AuthorizeCard((POSLink2.FullIntegration.AuthorizeCardReq)_terminalData.MultipleCommands[i].CommandReqObject, out authorizeCardRsp);
                            break;
                        case CommandName.CompleteOnlineEmv:
                            POSLink2.FullIntegration.CompleteOnlineEmvRsp completeOnlineEmvRsp = null;
                            _terminal.FullIntegration.CompleteOnlineEmv((POSLink2.FullIntegration.CompleteOnlineEmvReq)_terminalData.MultipleCommands[i].CommandReqObject, out completeOnlineEmvRsp);
                            break;
                        case CommandName.GetEmvTlvData:
                            POSLink2.FullIntegration.GetEmvTlvDataRsp getEmvTlvDataRsp = null;
                            _terminal.FullIntegration.GetEmvTlvData((POSLink2.FullIntegration.GetEmvTlvDataReq)_terminalData.MultipleCommands[i].CommandReqObject, out getEmvTlvDataRsp);
                            break;
                        case CommandName.SetEmvTlvData:
                            POSLink2.FullIntegration.SetEmvTlvDataRsp setEmvTlvDataRsp = null;
                            _terminal.FullIntegration.SetEmvTlvData((POSLink2.FullIntegration.SetEmvTlvDataReq)_terminalData.MultipleCommands[i].CommandReqObject, out setEmvTlvDataRsp);
                            break;
                        case CommandName.InputAccountWithEmv:
                            POSLink2.FullIntegration.InputAccountWithEmvRsp inputAccountWithEmvRsp = null;
                            _terminal.FullIntegration.InputAccountWithEmv((POSLink2.FullIntegration.InputAccountWithEmvReq)_terminalData.MultipleCommands[i].CommandReqObject, out inputAccountWithEmvRsp);
                            break;

                        //Ped
                        case CommandName.SessionKeyInjection:
                            POSLink2.Ped.SessionKeyInjectionRsp sessionKeyInjectionRsp = null;
                            _terminal.Ped.SessionKeyInjection((POSLink2.Ped.SessionKeyInjectionReq)_terminalData.MultipleCommands[i].CommandReqObject, out sessionKeyInjectionRsp);
                            break;
                        case CommandName.MacCalculation:
                            POSLink2.Ped.MacCalculationRsp macCalculationRsp = null;
                            _terminal.Ped.MacCalculation((POSLink2.Ped.MacCalculationReq)_terminalData.MultipleCommands[i].CommandReqObject, out macCalculationRsp);
                            break;
                        case CommandName.GetPedInfo:
                            POSLink2.Ped.GetPedInfoRsp getPedInfoRsp = null;
                            _terminal.Ped.GetPedInfo((POSLink2.Ped.GetPedInfoReq)_terminalData.MultipleCommands[i].CommandReqObject, out getPedInfoRsp);
                            break;
                        case CommandName.IncreaseKsn:
                            POSLink2.Ped.IncreaseKsnRsp increaseKsnRsp = null;
                            _terminal.Ped.IncreaseKsn((POSLink2.Ped.IncreaseKsnReq)_terminalData.MultipleCommands[i].CommandReqObject, out increaseKsnRsp);
                            break;
                        default:
                            break;
                    }
                }
                POSLink2.MultiCmdResponse multiCMDResponse = null;
                POSLink2.ExecutionResult executionResult = _terminal.EndMultiCmdMode(out multiCMDResponse);
                if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                {
                    GetMultipleCommandsRsp(multiCMDResponse);
                }
                Global.IsTransactionProcessing = false;
                MethodInvoker methodInvoker = new MethodInvoker(() =>
                {
                    if(!string.IsNullOrEmpty(multiCMDResponse.ResponseCode))
                    {
                        MessageBox.Show(multiCMDResponse.ResponseCode + "\r\n" + multiCMDResponse.ResponseMessage, "Result");
                    }
                    SetMultipleCommandsRspData(multiCMDResponse);
                    DoMultipleCommands.Enabled = true;
                    ClearButton.Enabled = true;
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
                });
                BeginInvoke(methodInvoker);
            });
            task.Start();
        }

        private void DoMultipleCommands_Click(object sender, EventArgs e)
        {
            if (Global.IsTransactionProcessing)
            {
                MessageBox.Show("A transaction is processing.", "Warning");
                return;
            }
            if (_terminalData.MultipleCommands == null || _terminalData.MultipleCommands.Count == 0)
            {
                MessageBox.Show("No Multiple Commands items.","Warning");
                return;
            }
            Global.IsTransactionProcessing = true;
            DoMultipleCommands.Enabled = false;
            ClearButton.Enabled = false;
            ResponseListBox.Items.Clear();
            _terminalData.ResponseClear();
            _waiting.Location = new Point(0, 0);
            _waiting.IsCancelAvaliable = false;
            this.Controls.Add(_waiting);
            _waiting.BringToFront();
            _waiting.Show();

            RunMultipleCommands();
        }

        private void GetMultipleCommandsRsp(POSLink2.MultiCmdResponse response)
        {
            if (response == null || response.Object == null)
            {
                return;
            }

            for (int i=0; i<response.Object.Length; i++)
            {
                _terminalData.MultipleCommands[i].CommandRspObject = response.Object[i];
            }
        }

        private void SetMultipleCommandsRspData(POSLink2.MultiCmdResponse response)
        {
            if (response == null || response.Object == null|| response.Object.Length == 0)
            {
                return;
            }

            for (int i=0; i< response.Object.Length; i++)
            {
                ResponseListBox.Items.Add(Global.CommandName[(int)_terminalData.MultipleCommands[i].CommandName]);
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            RequestListBox.Items.Clear();
            ResponseListBox.Items.Clear();
            _terminalData.MultipleCommands = new List<MultipleCommandsModule>();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if(RequestListBox.SelectedIndex < 0)
            {
                MessageBox.Show("Please select an item.", "Warning");
                return;
            }
            _terminalData.MultipleCommands.RemoveAt(RequestListBox.SelectedIndex);
            RequestListBox.Items.RemoveAt(RequestListBox.SelectedIndex);
        }

        private void MultipleCommandsUserControl_Load(object sender, EventArgs e)
        {

        }

        public delegate void DelegateEvent(object sender, EventArgs e, int index);
        public event DelegateEvent ResponseListBoxDoubleClick;

        private void ResponseListBox_DoubleClick(object sender, EventArgs e)
        {
            if (ResponseListBox.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a response item.", "Warning");
                return;
            }

            if(_terminalData.MultipleCommands[ResponseListBox.SelectedIndex] != null)
            {
                switch(_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandName)
                {
                    //Transaction
                    case CommandName.DoCredit:
                        POSLink2.Transaction.DoCreditRsp doCreditRsp = (POSLink2.Transaction.DoCreditRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        TransactionUserControl.GetResponse(doCreditRsp);
                        break;
                    case CommandName.DoDebit:
                        POSLink2.Transaction.DoDebitRsp doDebitRsp = (POSLink2.Transaction.DoDebitRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        TransactionUserControl.GetResponse(doDebitRsp);
                        break;
                    case CommandName.DoEBT:
                        POSLink2.Transaction.DoEbtRsp doEbtRsp = (POSLink2.Transaction.DoEbtRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        TransactionUserControl.GetResponse(doEbtRsp);
                        break;
                    case CommandName.DoGift:
                        POSLink2.Transaction.DoGiftRsp doGiftRsp = (POSLink2.Transaction.DoGiftRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        TransactionUserControl.GetResponse(doGiftRsp);
                        break;
                    case CommandName.DoLoyalty:
                        POSLink2.Transaction.DoLoyaltyRsp doLoyaltyRsp = (POSLink2.Transaction.DoLoyaltyRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        TransactionUserControl.GetResponse(doLoyaltyRsp);
                        break;
                    case CommandName.DoCash:
                        POSLink2.Transaction.DoCashRsp doCashRsp = (POSLink2.Transaction.DoCashRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        TransactionUserControl.GetResponse(doCashRsp);
                        break;
                    case CommandName.DoCheck:
                        POSLink2.Transaction.DoCheckRsp doCheckRsp = (POSLink2.Transaction.DoCheckRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        TransactionUserControl.GetResponse(doCheckRsp);
                        break;

                    //Batch
                    case CommandName.BatchClose:
                        POSLink2.Batch.BatchCloseRsp batchCloseRsp = (POSLink2.Batch.BatchCloseRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        BatchUserControl.GetResponse(batchCloseRsp);
                        break;
                    case CommandName.ForceBatchClose:
                        POSLink2.Batch.ForceBatchCloseRsp forceBatchCloseRsp = (POSLink2.Batch.ForceBatchCloseRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        BatchUserControl.GetResponse(forceBatchCloseRsp);
                        break;
                    case CommandName.BatchClear:
                        POSLink2.Batch.BatchClearRsp batchClearRsp = (POSLink2.Batch.BatchClearRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        BatchUserControl.GetResponse(batchClearRsp);
                        break;
                    case CommandName.PurgeBatch:
                        POSLink2.Batch.PurgeBatchRsp purgeBatchRsp = (POSLink2.Batch.PurgeBatchRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        BatchUserControl.GetResponse(purgeBatchRsp);
                        break;
                    case CommandName.SAFUpload:
                        POSLink2.Batch.SafUploadRsp safUploadRsp = (POSLink2.Batch.SafUploadRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        BatchUserControl.GetResponse(safUploadRsp);
                        break;
                    case CommandName.DeleteSAFFile:
                        POSLink2.Batch.DeleteSafFileRsp deleteSafFileRsp = (POSLink2.Batch.DeleteSafFileRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        BatchUserControl.GetResponse(deleteSafFileRsp);
                        break;
                    case CommandName.DeleteTransaction:
                        POSLink2.Batch.DeleteTransactionRsp deleteTransactionRsp = (POSLink2.Batch.DeleteTransactionRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        BatchUserControl.GetResponse(deleteTransactionRsp);
                        break;

                    //Report
                    case CommandName.LocalTotalReport:
                        POSLink2.Report.LocalTotalReportRsp localTotalReportRsp = (POSLink2.Report.LocalTotalReportRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        ReportUserControl.GetResponse(localTotalReportRsp);
                        break;
                    case CommandName.LocalDetailReport:
                        POSLink2.Report.LocalDetailReportRsp localDetailReportRsp = (POSLink2.Report.LocalDetailReportRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        ReportUserControl.GetResponse(localDetailReportRsp);
                        break;
                    case CommandName.LocalFailedReport:
                        POSLink2.Report.LocalFailedReportRsp localFailedReportRsp = (POSLink2.Report.LocalFailedReportRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        ReportUserControl.GetResponse(localFailedReportRsp);
                        break;
                    case CommandName.HostReport:
                        POSLink2.Report.HostReportRsp hostReportRsp = (POSLink2.Report.HostReportRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        ReportUserControl.GetResponse(hostReportRsp);
                        break;
                    case CommandName.HistoryReport:
                        POSLink2.Report.HistoryReportRsp historyReportRsp = (POSLink2.Report.HistoryReportRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        ReportUserControl.GetResponse(historyReportRsp);
                        break;
                    case CommandName.SAFSummaryReport:
                        POSLink2.Report.SafSummaryReportRsp safSummaryReportRsp = (POSLink2.Report.SafSummaryReportRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        ReportUserControl.GetResponse(safSummaryReportRsp);
                        break;
                    case CommandName.HostDetailReport:
                        POSLink2.Report.HostDetailReportRsp hostDetailReportRsp = (POSLink2.Report.HostDetailReportRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        ReportUserControl.GetResponse(hostDetailReportRsp);
                        break;

                    //Manage
                    case CommandName.Init:
                        POSLink2.Manage.InitRsp initRsp = (POSLink2.Manage.InitRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        ManageUserControl.GetResponse(initRsp);
                        break;
                    case CommandName.GetVariable:
                        POSLink2.Manage.GetVariableRsp getVariableRsp = (POSLink2.Manage.GetVariableRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        ManageUserControl.GetResponse(getVariableRsp);
                        break;
                    case CommandName.SetVariable:
                        POSLink2.Manage.SetVariableRsp setVariableRsp = (POSLink2.Manage.SetVariableRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        ManageUserControl.GetResponse(setVariableRsp);
                        break;
                    case CommandName.GetSignature:
                        POSLink2.Manage.GetSignatureRsp getSignatureRsp = (POSLink2.Manage.GetSignatureRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        ManageUserControl.GetResponse(getSignatureRsp);
                        break;
                    case CommandName.Reset:
                        POSLink2.Manage.ResetRsp resetRsp = (POSLink2.Manage.ResetRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        ManageUserControl.GetResponse(resetRsp);
                        break;
                    case CommandName.DoSignature:
                        POSLink2.Manage.DoSignatureRsp doSignatureRsp = (POSLink2.Manage.DoSignatureRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        ManageUserControl.GetResponse(doSignatureRsp);
                        break;
                    case CommandName.DeleteImage:
                        POSLink2.Manage.DeleteImageRsp deleteImageRsp = (POSLink2.Manage.DeleteImageRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        ManageUserControl.GetResponse(deleteImageRsp);
                        break;
                    case CommandName.Reboot:
                        POSLink2.Manage.RebootRsp rebootRsp = (POSLink2.Manage.RebootRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        ManageUserControl.GetResponse(rebootRsp);
                        break;
                    case CommandName.InputAccount:
                        POSLink2.Manage.InputAccountRsp inputAccountRsp = (POSLink2.Manage.InputAccountRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        ManageUserControl.GetResponse(inputAccountRsp);
                        break;
                    case CommandName.ResetMsr:
                        POSLink2.Manage.ResetMsrRsp resetMsrRsp = (POSLink2.Manage.ResetMsrRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        ManageUserControl.GetResponse(resetMsrRsp);
                        break;
                    case CommandName.CheckFile:
                        POSLink2.Manage.CheckFileRsp checkFileRsp = (POSLink2.Manage.CheckFileRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        ManageUserControl.GetResponse(checkFileRsp);
                        break;
                    case CommandName.SetSafParameters:
                        POSLink2.Manage.SetSafParametersRsp setSafParametersRsp = (POSLink2.Manage.SetSafParametersRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        ManageUserControl.GetResponse(setSafParametersRsp);
                        break;
                    case CommandName.Reprint:
                        POSLink2.Manage.ReprintRsp reprintRsp = (POSLink2.Manage.ReprintRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        ManageUserControl.GetResponse(reprintRsp);
                        break;
                    case CommandName.TokenAdministrative:
                        POSLink2.Manage.TokenAdministrativeRsp tokenAdministrativeRsp = (POSLink2.Manage.TokenAdministrativeRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        ManageUserControl.GetResponse(tokenAdministrativeRsp);
                        break;
                    case CommandName.VasSetMerchantParameters:
                        POSLink2.Manage.VasSetMerchantParametersRsp vasSetMerchantParametersRsp = (POSLink2.Manage.VasSetMerchantParametersRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        ManageUserControl.GetResponse(vasSetMerchantParametersRsp);
                        break;
                    case CommandName.VasPushData:
                        POSLink2.Manage.VasPushDataRsp vasPushDataRsp = (POSLink2.Manage.VasPushDataRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        ManageUserControl.GetResponse(vasPushDataRsp);
                        break;
                    case CommandName.GetSafParameters:
                        POSLink2.Manage.GetSafParametersRsp getSafParametersRsp = (POSLink2.Manage.GetSafParametersRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        ManageUserControl.GetResponse(getSafParametersRsp);
                        break;

                    //Form
                    case CommandName.ShowDialog:
                        POSLink2.Form.ShowDialogRsp showDialogRsp = (POSLink2.Form.ShowDialogRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        FormUserControl.GetResponse(showDialogRsp);
                        break;
                    case CommandName.ShowMessage:
                        POSLink2.Form.ShowMessageRsp showMessageRsp = (POSLink2.Form.ShowMessageRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        FormUserControl.GetResponse(showMessageRsp);
                        break;
                    case CommandName.ClearMessage:
                        POSLink2.Form.ClearMessageRsp clearMessageRsp = (POSLink2.Form.ClearMessageRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        FormUserControl.GetResponse(clearMessageRsp);
                        break;
                    case CommandName.ShowMessageCenter:
                        POSLink2.Form.ShowMessageCenterRsp showMessageCenterRsp = (POSLink2.Form.ShowMessageCenterRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        FormUserControl.GetResponse(showMessageCenterRsp);
                        break;
                    case CommandName.InputText:
                        POSLink2.Form.InputTextRsp inputTextRsp = (POSLink2.Form.InputTextRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        FormUserControl.GetResponse(inputTextRsp);
                        break;
                    case CommandName.RemoveCard:
                        POSLink2.Form.RemoveCardRsp removeCardRsp = (POSLink2.Form.RemoveCardRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        FormUserControl.GetResponse(removeCardRsp);
                        break;
                    case CommandName.ShowTextBox:
                        POSLink2.Form.ShowTextBoxRsp showTextBoxRsp = (POSLink2.Form.ShowTextBoxRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        FormUserControl.GetResponse(showTextBoxRsp);
                        break;
                    case CommandName.ShowItem:
                        POSLink2.Form.ShowItemRsp showItemRsp = (POSLink2.Form.ShowItemRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        FormUserControl.GetResponse(showItemRsp);
                        break;
                    case CommandName.ShowDialogForm:
                        POSLink2.Form.ShowDialogFormRsp showDialogFormRsp = (POSLink2.Form.ShowDialogFormRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        FormUserControl.GetResponse(showDialogFormRsp);
                        break;

                    //Device
                    case CommandName.Printer:
                        POSLink2.Device.PrinterRsp printerRsp = (POSLink2.Device.PrinterRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        DeviceUserControl.GetResponse(printerRsp);
                        break;
                    case CommandName.CardInsertDetection:
                        POSLink2.Device.CardInsertDetectionRsp cardInsertDetectionRsp = (POSLink2.Device.CardInsertDetectionRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        DeviceUserControl.GetResponse(cardInsertDetectionRsp);
                        break;
                    case CommandName.CameraScan:
                        POSLink2.Device.CameraScanRsp cameraScanRsp = (POSLink2.Device.CameraScanRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        DeviceUserControl.GetResponse(cameraScanRsp);
                        break;
                    case CommandName.MifareCard:
                        POSLink2.Device.MifareCardRsp mifareCardRsp = (POSLink2.Device.MifareCardRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        DeviceUserControl.GetResponse(mifareCardRsp);
                        break;

                    //Full Integration
                    case CommandName.GetPinBlock:
                        POSLink2.FullIntegration.GetPinBlockRsp getPinBlockRsp = (POSLink2.FullIntegration.GetPinBlockRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        FullIntegrationUserControl.GetResponse(getPinBlockRsp);
                        break;
                    case CommandName.AuthorizeCard:
                        POSLink2.FullIntegration.AuthorizeCardRsp authorizeCardRsp = (POSLink2.FullIntegration.AuthorizeCardRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        FullIntegrationUserControl.GetResponse(authorizeCardRsp);
                        break;
                    case CommandName.CompleteOnlineEmv:
                        POSLink2.FullIntegration.CompleteOnlineEmvRsp completeOnlineEmvRsp = (POSLink2.FullIntegration.CompleteOnlineEmvRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        FullIntegrationUserControl.GetResponse(completeOnlineEmvRsp);
                        break;
                    case CommandName.GetEmvTlvData:
                        POSLink2.FullIntegration.GetEmvTlvDataRsp getEmvTlvDataRsp = (POSLink2.FullIntegration.GetEmvTlvDataRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        FullIntegrationUserControl.GetResponse(getEmvTlvDataRsp);
                        break;
                    case CommandName.SetEmvTlvData:
                        POSLink2.FullIntegration.SetEmvTlvDataRsp setEmvTlvDataRsp = (POSLink2.FullIntegration.SetEmvTlvDataRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        FullIntegrationUserControl.GetResponse(setEmvTlvDataRsp);
                        break;
                    case CommandName.InputAccountWithEmv:
                        POSLink2.FullIntegration.InputAccountWithEmvRsp inputAccountWithEmvRsp = (POSLink2.FullIntegration.InputAccountWithEmvRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        FullIntegrationUserControl.GetResponse(inputAccountWithEmvRsp);
                        break;

                    //Ped
                    case CommandName.SessionKeyInjection:
                        POSLink2.Ped.SessionKeyInjectionRsp sessionKeyInjectionRsp = (POSLink2.Ped.SessionKeyInjectionRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        PedUserControl.GetResponse(sessionKeyInjectionRsp);
                        break;
                    case CommandName.MacCalculation:
                        POSLink2.Ped.MacCalculationRsp macCalculationRsp = (POSLink2.Ped.MacCalculationRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        PedUserControl.GetResponse(macCalculationRsp);
                        break;
                    case CommandName.GetPedInfo:
                        POSLink2.Ped.GetPedInfoRsp getPedInfoRsp = (POSLink2.Ped.GetPedInfoRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        PedUserControl.GetResponse(getPedInfoRsp);
                        break;
                    case CommandName.IncreaseKsn:
                        POSLink2.Ped.IncreaseKsnRsp increaseKsnRsp = (POSLink2.Ped.IncreaseKsnRsp)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandRspObject;
                        PedUserControl.GetResponse(increaseKsnRsp);
                        break;
                    default:
                        break;
                }

                int index = (int)_terminalData.MultipleCommands[ResponseListBox.SelectedIndex].CommandName;
                ResponseListBoxDoubleClick(this, e, index);
            }
            else
            {
                MessageBox.Show("Response Data not exist.", "Warning");
            }
        }

        private void MultipleCommandsUserControl_VisibleChanged(object sender, EventArgs e)
        {
            RequestListBox.Items.Clear();
            if (_terminalData.MultipleCommands == null || _terminalData.MultipleCommands.Count == 0)
            {
                return;
            }

            for (int i = 0; i < _terminalData.MultipleCommands.Count; i++)
            {
                RequestListBox.Items.Add(Global.CommandName[(int)_terminalData.MultipleCommands[i].CommandName]);
            }
        }

    }
}

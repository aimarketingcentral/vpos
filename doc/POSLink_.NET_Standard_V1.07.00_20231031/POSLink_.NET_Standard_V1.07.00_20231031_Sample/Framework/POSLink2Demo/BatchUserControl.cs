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
    public partial class BatchUserControl : UserControl
    {
        private BatchData _batchData;
        private Waiting _waiting;
        private TerminalData _terminalData;
        private POSLink2.Terminal _terminal;
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

        public BatchUserControl()
        {
            InitializeComponent();
            _comboBoxIndex = 0;
            CommandComboBox.SelectedIndex = 0;
            _batchData = BatchData.GetBatchData();
            _waiting = new Waiting();
            _waiting.Dock = DockStyle.Left;
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
            _batchData.ResponseClear();
            _waiting.Location = new Point(0, 0);
            _waiting.IsCancelAvaliable = false;
            this.Controls.Add(_waiting);
            _waiting.BringToFront();
            _waiting.Show();

            int tenderType = CommandComboBox.SelectedIndex;
            RunBatch(tenderType, sender, e);
        }

        private void RunBatch(int tenderType, object sender, EventArgs e)
        {
            Task task = new Task(() =>
            {
                POSLink2.ExecutionResult executionResult = new POSLink2.ExecutionResult();

                switch(tenderType)
                {
                    case (int)BatchCommandName.BatchCloseReq/2://BatchClose
                        POSLink2.Batch.BatchCloseReq batchCloseReq = SetBatchCloseReq();
                        POSLink2.Batch.BatchCloseRsp batchCloseRsp  = null;
                        executionResult = _terminal.Batch.BatchClose(batchCloseReq, out batchCloseRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(batchCloseRsp);
                        }
                        break;
                    case (int)BatchCommandName.ForceBatchCloseReq / 2://ForceBatchClose
                        POSLink2.Batch.ForceBatchCloseReq forceBatchCloseReq = SetForceBatchCloseReq();
                        POSLink2.Batch.ForceBatchCloseRsp forceBatchCloseRsp = null;
                        executionResult = _terminal.Batch.ForceBatchClose(forceBatchCloseReq, out forceBatchCloseRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(forceBatchCloseRsp);
                        }
                        break;
                    case (int)BatchCommandName.BatchClearReq / 2://BatchClear
                        POSLink2.Batch.BatchClearReq batchClearReq = SetBatchClearReq();
                        POSLink2.Batch.BatchClearRsp batchClearRsp = null;
                        executionResult = _terminal.Batch.BatchClear(batchClearReq, out batchClearRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(batchClearRsp);
                        }
                        break;
                    case (int)BatchCommandName.PurgeBatchReq / 2://PurgeBatch
                        POSLink2.Batch.PurgeBatchReq purgeBatchReq = SetPurgeBatchReq();
                        POSLink2.Batch.PurgeBatchRsp purgeBatchRsp = null;
                        executionResult = _terminal.Batch.PurgeBatch(purgeBatchReq, out purgeBatchRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(purgeBatchRsp);
                        }
                        break;
                    case (int)BatchCommandName.SAFUploadReq / 2://SAFUpload
                        POSLink2.Batch.SafUploadReq safUploadReq = SetSafUploadReq();
                        POSLink2.Batch.SafUploadRsp safUploadRsp = null;
                        executionResult = _terminal.Batch.SafUpload(safUploadReq, out safUploadRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(safUploadRsp);
                        }
                        break;
                    case (int)BatchCommandName.DeleteSAFFileReq / 2://DeleteSAFFile
                        POSLink2.Batch.DeleteSafFileReq deleteSAFFileReq = SetDeleteSafFileReq();
                        POSLink2.Batch.DeleteSafFileRsp deleteSafFileRsp = null;
                        executionResult = _terminal.Batch.DeleteSafFile(deleteSAFFileReq, out deleteSafFileRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(deleteSafFileRsp);
                        }
                        break;
                    case (int)BatchCommandName.DeleteTransactionReq / 2://DeleteTransaction
                        POSLink2.Batch.DeleteTransactionReq deleteTransactionReq = SetDeleteTransactionReq();
                        POSLink2.Batch.DeleteTransactionRsp deleteTransactionRsp = null;
                        executionResult = _terminal.Batch.DeleteTransaction(deleteTransactionReq, out deleteTransactionRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(deleteTransactionRsp);
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
                });
                BeginInvoke(methodInvoker);
            });
            task.Start();
        }

        private void CommandComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _comboBoxIndex = CommandComboBox.SelectedIndex;
            Tools tools = new Tools();
            tools.DisposeSubControls(panel1);
            if (CommandComboBox.SelectedIndex == 0)
            {
                BatchTwoPanelsUserControl batchCloseReqUserControl = new BatchTwoPanelsUserControl();
                batchCloseReqUserControl.CommandName = BatchCommandName.BatchCloseReq;
                batchCloseReqUserControl.Dock = DockStyle.Left;
                batchCloseReqUserControl.ShowButton(sender,e);
                panel1.Controls.Add(batchCloseReqUserControl);

                BatchTwoPanelsUserControl batchCloseRspUserControl = new BatchTwoPanelsUserControl();
                batchCloseRspUserControl.CommandName = BatchCommandName.BatchCloseRsp;
                batchCloseRspUserControl.Dock = DockStyle.Left;
                batchCloseRspUserControl.ShowButton(sender, e);
                panel1.Controls.Add(batchCloseRspUserControl);

                batchCloseReqUserControl.SendToBack();
            }
            else if(CommandComboBox.SelectedIndex == 1)
            {
                BatchOnePanelUserControl forceBatchCloseReqUserControl = new BatchOnePanelUserControl();
                forceBatchCloseReqUserControl.CommandName = BatchCommandName.ForceBatchCloseReq;
                forceBatchCloseReqUserControl.Dock = DockStyle.Left;
                forceBatchCloseReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(forceBatchCloseReqUserControl);

                BatchTwoPanelsUserControl forceBatchCloseRspUserControl = new BatchTwoPanelsUserControl();
                forceBatchCloseRspUserControl.CommandName = BatchCommandName.ForceBatchCloseRsp;
                forceBatchCloseRspUserControl.Dock = DockStyle.Left;
                forceBatchCloseRspUserControl.ShowButton(sender, e);
                panel1.Controls.Add(forceBatchCloseRspUserControl);

                forceBatchCloseReqUserControl.SendToBack();
            }
            else if(CommandComboBox.SelectedIndex == 2)
            {
                BatchOnePanelUserControl batchClearReqUserControl = new BatchOnePanelUserControl();
                batchClearReqUserControl.CommandName = BatchCommandName.BatchClearReq;
                batchClearReqUserControl.Dock = DockStyle.Left;
                batchClearReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(batchClearReqUserControl);

                BatchTwoPanelsUserControl batchClearRspUserControl = new BatchTwoPanelsUserControl();
                batchClearRspUserControl.CommandName = BatchCommandName.BatchClearRsp;
                batchClearRspUserControl.Dock = DockStyle.Left;
                batchClearRspUserControl.ShowButton(sender, e);
                panel1.Controls.Add(batchClearRspUserControl);

                batchClearReqUserControl.SendToBack();
            }
            else if(CommandComboBox.SelectedIndex == 3)
            {
                BatchOnePanelUserControl purgeBatchReqUserControl = new BatchOnePanelUserControl();
                purgeBatchReqUserControl.CommandName = BatchCommandName.PurgeBatchReq;
                purgeBatchReqUserControl.Dock = DockStyle.Left;
                purgeBatchReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(purgeBatchReqUserControl);

                BatchTwoPanelsUserControl purgeBatchRspUserControl = new BatchTwoPanelsUserControl();
                purgeBatchRspUserControl.CommandName = BatchCommandName.PurgeBatchRsp;
                purgeBatchRspUserControl.Dock = DockStyle.Left;
                purgeBatchRspUserControl.ShowButton(sender, e);
                panel1.Controls.Add(purgeBatchRspUserControl);

                purgeBatchReqUserControl.SendToBack();
            }
            else if(CommandComboBox.SelectedIndex == 4)
            {
                BatchOnePanelUserControl safUploadReqUserControl = new BatchOnePanelUserControl();
                safUploadReqUserControl.CommandName = BatchCommandName.SAFUploadReq;
                safUploadReqUserControl.Dock = DockStyle.Left;
                safUploadReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(safUploadReqUserControl);

                BatchTwoPanelsUserControl safUploadRspUserControl = new BatchTwoPanelsUserControl();
                safUploadRspUserControl.CommandName = BatchCommandName.SAFUploadRsp;
                safUploadRspUserControl.Dock = DockStyle.Left;
                safUploadRspUserControl.ShowButton(sender, e);
                panel1.Controls.Add(safUploadRspUserControl);

                safUploadReqUserControl.SendToBack();
            }
            else if(CommandComboBox.SelectedIndex == 5)
            {
                BatchOnePanelUserControl deleteSafFileReqUserControl = new BatchOnePanelUserControl();
                deleteSafFileReqUserControl.CommandName = BatchCommandName.DeleteSAFFileReq;
                deleteSafFileReqUserControl.Dock = DockStyle.Left;
                deleteSafFileReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(deleteSafFileReqUserControl);

                BatchTwoPanelsUserControl deleteSafFileRspUserControl = new BatchTwoPanelsUserControl();
                deleteSafFileRspUserControl.CommandName = BatchCommandName.DeleteSAFFileRsp;
                deleteSafFileRspUserControl.Dock = DockStyle.Left;
                deleteSafFileRspUserControl.ShowButton(sender, e);
                panel1.Controls.Add(deleteSafFileRspUserControl);

                deleteSafFileReqUserControl.SendToBack();
            }
            else if(CommandComboBox.SelectedIndex == 6)
            {
                BatchOnePanelUserControl deleteTransReqUserControl = new BatchOnePanelUserControl();
                deleteTransReqUserControl.CommandName = BatchCommandName.DeleteTransactionReq;
                deleteTransReqUserControl.Dock = DockStyle.Left;
                deleteTransReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(deleteTransReqUserControl);

                BatchTwoPanelsUserControl deleteTransRspUserControl = new BatchTwoPanelsUserControl();
                deleteTransRspUserControl.CommandName = BatchCommandName.DeleteTransactionRsp;
                deleteTransRspUserControl.Dock = DockStyle.Left;
                deleteTransRspUserControl.ShowButton(sender, e);
                panel1.Controls.Add(deleteTransRspUserControl);

                deleteTransReqUserControl.SendToBack();
            }
        }

        private void BatchUserControl_Load(object sender, EventArgs e)
        {

        }

        private POSLink2.Batch.BatchCloseReq SetBatchCloseReq()
        {
            POSLink2.Batch.BatchCloseReq request = new POSLink2.Batch.BatchCloseReq();
            request.TimeStamp = _batchData.BatchCloseReqNormalData[0];
            request.MultiMerchant.Id = _batchData.MultiMerchantReqData[0];
            request.MultiMerchant.Name = _batchData.MultiMerchantReqData[1];
            return request;
        }

        private POSLink2.Batch.ForceBatchCloseReq SetForceBatchCloseReq()
        {
            POSLink2.Batch.ForceBatchCloseReq request = new POSLink2.Batch.ForceBatchCloseReq();
            request.TimeStamp = _batchData.ForceBatchCloseReqNormalData[0];
            return request;
        }

        private POSLink2.Batch.BatchClearReq SetBatchClearReq()
        {
            POSLink2.Batch.BatchClearReq request = new POSLink2.Batch.BatchClearReq();
            request.EdcType = (POSLink2.Const.EdcType)Global.EdcType[_batchData.EdcTypeIndex, 1];
            return request;
        }

        private POSLink2.Batch.PurgeBatchReq SetPurgeBatchReq()
        {
            POSLink2.Batch.PurgeBatchReq request = new POSLink2.Batch.PurgeBatchReq();
            request.TimeStamp = _batchData.PurgeBatchReqNormalData[0];
            return request;
        }

        private POSLink2.Batch.SafUploadReq SetSafUploadReq()
        {
            POSLink2.Batch.SafUploadReq request = new POSLink2.Batch.SafUploadReq();
            request.SafIndicator = _batchData.SafUploadReqNormalData[0];
            return request;
        }

        private POSLink2.Batch.DeleteSafFileReq SetDeleteSafFileReq()
        {
            POSLink2.Batch.DeleteSafFileReq request = new POSLink2.Batch.DeleteSafFileReq();
            request.SafIndicator = _batchData.DeleteSafFileReqNormalData[0];
            return request;
        }

        private POSLink2.Batch.DeleteTransactionReq SetDeleteTransactionReq()
        {
            POSLink2.Batch.DeleteTransactionReq request = new POSLink2.Batch.DeleteTransactionReq();
            request.EdcType = (POSLink2.Const.EdcType)Global.EdcType[_batchData.EdcTypeIndex, 1];
            request.TransactionType = (POSLink2.Const.TransType)Global.TransType[_batchData.TransTypeIndex, 1];
            if (_batchData.CardTypeIndex != 0)
            {
                request.CardType = (POSLink2.Const.CardType)Global.CardType[_batchData.CardTypeIndex, 1];
            }
            request.RecordNumber = _batchData.DeleteTransReqNormalData[0];
            request.OrigRefNum = _batchData.DeleteTransReqNormalData[1];
            request.AuthCode = _batchData.DeleteTransReqNormalData[2];
            request.EcrRefNum = _batchData.DeleteTransReqNormalData[3];
            return request;
        }

        public static void GetResponse(POSLink2.Batch.BatchCloseRsp response)
        {
            BatchData batchData = BatchData.GetBatchData();
            //Normal
            batchData.BatchCloseRspNormalData[0] = response.ResponseCode;
            batchData.BatchCloseRspNormalData[1] = response.ResponseMessage;
            batchData.BatchCloseRspNormalData[2] = response.TotalCount;
            batchData.BatchCloseRspNormalData[3] = response.TotalAmount;
            batchData.BatchCloseRspNormalData[4] = response.TimeStamp;
            batchData.BatchCloseRspNormalData[5] = response.Tid;
            batchData.BatchCloseRspNormalData[6] = response.Mid;
            batchData.BatchCloseRspNormalData[7] = response.FailedTransNO;
            batchData.BatchCloseRspNormalData[8] = response.FailedCount;
            batchData.BatchCloseRspNormalData[9] = response.SafFailedCount;
            batchData.BatchCloseRspNormalData[10] = response.SafFailedTotal;
            //Host Info
            batchData.HostInfoRspData[0] = response.HostInformation.HostResponseCode;
            batchData.HostInfoRspData[1] = response.HostInformation.HostResponseMessage;
            batchData.HostInfoRspData[2] = response.HostInformation.AuthCode;
            batchData.HostInfoRspData[3] = response.HostInformation.HostRefNum;
            batchData.HostInfoRspData[4] = response.HostInformation.TraceNumber;
            batchData.HostInfoRspData[5] = response.HostInformation.BatchNumber;
            batchData.HostInfoRspData[6] = response.HostInformation.TransactionIdentifier;
            batchData.HostInfoRspData[7] = response.HostInformation.GatewayTransactionID;
            //Tor Info
            batchData.TorInfoRspData[0] = response.TorInformation.RecordType;
            batchData.TorInfoRspData[1] = response.TorInformation.ReversalTimeStamp;
            batchData.TorInfoRspData[2] = response.TorInformation.HostResponseCode;
            batchData.TorInfoRspData[3] = response.TorInformation.HostResponseMessage;
            batchData.TorInfoRspData[4] = response.TorInformation.HostRefNum;
            batchData.TorInfoRspData[5] = response.TorInformation.GatewayTransactionID;
            batchData.TorInfoRspData[6] = response.TorInformation.OrigAmount;
            batchData.TorInfoRspData[7] = response.TorInformation.MaskedPan;
            batchData.TorInfoRspData[8] = response.TorInformation.BatchNo;
            batchData.TorInfoRspData[9] = response.TorInformation.ReversalAuthCode;
            batchData.TorInfoRspData[10] = Tools.ParseTransType(response.TorInformation.OrigTransType);
            batchData.TorInfoRspData[11] = response.TorInformation.OrigTransDateTime;
            batchData.TorInfoRspData[12] = response.TorInformation.OrigTransAuthCode;
            //MultiMerchant
            batchData.MultiMerchantRspData[0] = response.MultiMerchant.Id;
            batchData.MultiMerchantRspData[1] = response.MultiMerchant.Name;
        }

        public static void GetResponse(POSLink2.Batch.ForceBatchCloseRsp response)
        {
            BatchData batchData = BatchData.GetBatchData();
            //Normal
            batchData.ForceBatchCloseRspNormalData[0] = response.ResponseCode;
            batchData.ForceBatchCloseRspNormalData[1] = response.ResponseMessage;
            batchData.ForceBatchCloseRspNormalData[2] = response.LineNumber;
            batchData.ForceBatchCloseRspNormalData[3] = response.LinesMessage;
            batchData.ForceBatchCloseRspNormalData[4] = response.TimeStamp;
            batchData.ForceBatchCloseRspNormalData[5] = response.Tid;
            batchData.ForceBatchCloseRspNormalData[6] = response.Mid;
            batchData.ForceBatchCloseRspNormalData[7] = response.FailedTransNO;
            batchData.ForceBatchCloseRspNormalData[8] = response.FailedCount;
            batchData.ForceBatchCloseRspNormalData[9] = response.SafFailedCount;
            batchData.ForceBatchCloseRspNormalData[10] = response.SafFailedTotal;
            //Host Info
            batchData.HostInfoRspData[0] = response.HostInformation.HostResponseCode;
            batchData.HostInfoRspData[1] = response.HostInformation.HostResponseMessage;
            batchData.HostInfoRspData[2] = response.HostInformation.AuthCode;
            batchData.HostInfoRspData[3] = response.HostInformation.HostRefNum;
            batchData.HostInfoRspData[4] = response.HostInformation.TraceNumber;
            batchData.HostInfoRspData[5] = response.HostInformation.BatchNumber;
            batchData.HostInfoRspData[6] = response.HostInformation.TransactionIdentifier;
            batchData.HostInfoRspData[7] = response.HostInformation.GatewayTransactionID;
            //Tor Info
            batchData.TorInfoRspData[0] = response.TorInformation.RecordType;
            batchData.TorInfoRspData[1] = response.TorInformation.ReversalTimeStamp;
            batchData.TorInfoRspData[2] = response.TorInformation.HostResponseCode;
            batchData.TorInfoRspData[3] = response.TorInformation.HostResponseMessage;
            batchData.TorInfoRspData[4] = response.TorInformation.HostRefNum;
            batchData.TorInfoRspData[5] = response.TorInformation.GatewayTransactionID;
            batchData.TorInfoRspData[6] = response.TorInformation.OrigAmount;
            batchData.TorInfoRspData[7] = response.TorInformation.MaskedPan;
            batchData.TorInfoRspData[8] = response.TorInformation.BatchNo;
            batchData.TorInfoRspData[9] = response.TorInformation.ReversalAuthCode;
            batchData.TorInfoRspData[10] = Tools.ParseTransType(response.TorInformation.OrigTransType);
            batchData.TorInfoRspData[11] = response.TorInformation.OrigTransDateTime;
            batchData.TorInfoRspData[12] = response.TorInformation.OrigTransAuthCode;
        }

        public static void GetResponse(POSLink2.Batch.BatchClearRsp response)
        {
            BatchData batchData = BatchData.GetBatchData();
            //Normal
            batchData.BatchClearRspNormalData[0] = response.ResponseCode;
            batchData.BatchClearRspNormalData[1] = response.ResponseMessage;
            //Tor Info
            batchData.TorInfoRspData[0] = response.TorInformation.RecordType;
            batchData.TorInfoRspData[1] = response.TorInformation.ReversalTimeStamp;
            batchData.TorInfoRspData[2] = response.TorInformation.HostResponseCode;
            batchData.TorInfoRspData[3] = response.TorInformation.HostResponseMessage;
            batchData.TorInfoRspData[4] = response.TorInformation.HostRefNum;
            batchData.TorInfoRspData[5] = response.TorInformation.GatewayTransactionID;
            batchData.TorInfoRspData[6] = response.TorInformation.OrigAmount;
            batchData.TorInfoRspData[7] = response.TorInformation.MaskedPan;
            batchData.TorInfoRspData[8] = response.TorInformation.BatchNo;
            batchData.TorInfoRspData[9] = response.TorInformation.ReversalAuthCode;
            batchData.TorInfoRspData[10] = Tools.ParseTransType(response.TorInformation.OrigTransType);
            batchData.TorInfoRspData[11] = response.TorInformation.OrigTransDateTime;
            batchData.TorInfoRspData[12] = response.TorInformation.OrigTransAuthCode;
        }

        public static void GetResponse(POSLink2.Batch.PurgeBatchRsp response)
        {
            BatchData batchData = BatchData.GetBatchData();
            //Normal
            batchData.PurgeBatchRspNormalData[0] = response.ResponseCode;
            batchData.PurgeBatchRspNormalData[1] = response.ResponseMessage;
            batchData.PurgeBatchRspNormalData[2] = response.LineNumber;
            batchData.PurgeBatchRspNormalData[3] = response.LinesMessage;
            batchData.PurgeBatchRspNormalData[4] = response.TimeStamp;
            batchData.PurgeBatchRspNormalData[5] = response.Tid;
            batchData.PurgeBatchRspNormalData[6] = response.Mid;
            //Host Info
            batchData.HostInfoRspData[0] = response.HostInformation.HostResponseCode;
            batchData.HostInfoRspData[1] = response.HostInformation.HostResponseMessage;
            batchData.HostInfoRspData[2] = response.HostInformation.AuthCode;
            batchData.HostInfoRspData[3] = response.HostInformation.HostRefNum;
            batchData.HostInfoRspData[4] = response.HostInformation.TraceNumber;
            batchData.HostInfoRspData[5] = response.HostInformation.BatchNumber;
            batchData.HostInfoRspData[6] = response.HostInformation.TransactionIdentifier;
            batchData.HostInfoRspData[7] = response.HostInformation.GatewayTransactionID;
            //Tor Info
            batchData.TorInfoRspData[0] = response.TorInformation.RecordType;
            batchData.TorInfoRspData[1] = response.TorInformation.ReversalTimeStamp;
            batchData.TorInfoRspData[2] = response.TorInformation.HostResponseCode;
            batchData.TorInfoRspData[3] = response.TorInformation.HostResponseMessage;
            batchData.TorInfoRspData[4] = response.TorInformation.HostRefNum;
            batchData.TorInfoRspData[5] = response.TorInformation.GatewayTransactionID;
            batchData.TorInfoRspData[6] = response.TorInformation.OrigAmount;
            batchData.TorInfoRspData[7] = response.TorInformation.MaskedPan;
            batchData.TorInfoRspData[8] = response.TorInformation.BatchNo;
            batchData.TorInfoRspData[9] = response.TorInformation.ReversalAuthCode;
            batchData.TorInfoRspData[10] = Tools.ParseTransType(response.TorInformation.OrigTransType);
            batchData.TorInfoRspData[11] = response.TorInformation.OrigTransDateTime;
            batchData.TorInfoRspData[12] = response.TorInformation.OrigTransAuthCode;
        }

        public static void GetResponse(POSLink2.Batch.SafUploadRsp response)
        {
            BatchData batchData = BatchData.GetBatchData();
            //Normal
            batchData.SafUploadRspNormalData[0] = response.ResponseCode;
            batchData.SafUploadRspNormalData[1] = response.ResponseMessage;
            batchData.SafUploadRspNormalData[2] = response.SafTotalCount;
            batchData.SafUploadRspNormalData[3] = response.SafTotalAmount;
            batchData.SafUploadRspNormalData[4] = response.TimeStamp;
            batchData.SafUploadRspNormalData[5] = response.SafUploadedCount;
            batchData.SafUploadRspNormalData[6] = response.SafUploadedAmount;
            batchData.SafUploadRspNormalData[7] = response.SafFailedCount;
            batchData.SafUploadRspNormalData[8] = response.SafFailedTotal;
            //Tor Info
            batchData.TorInfoRspData[0] = response.TorInformation.RecordType;
            batchData.TorInfoRspData[1] = response.TorInformation.ReversalTimeStamp;
            batchData.TorInfoRspData[2] = response.TorInformation.HostResponseCode;
            batchData.TorInfoRspData[3] = response.TorInformation.HostResponseMessage;
            batchData.TorInfoRspData[4] = response.TorInformation.HostRefNum;
            batchData.TorInfoRspData[5] = response.TorInformation.GatewayTransactionID;
            batchData.TorInfoRspData[6] = response.TorInformation.OrigAmount;
            batchData.TorInfoRspData[7] = response.TorInformation.MaskedPan;
            batchData.TorInfoRspData[8] = response.TorInformation.BatchNo;
            batchData.TorInfoRspData[9] = response.TorInformation.ReversalAuthCode;
            batchData.TorInfoRspData[10] = Tools.ParseTransType(response.TorInformation.OrigTransType);
            batchData.TorInfoRspData[11] = response.TorInformation.OrigTransDateTime;
            batchData.TorInfoRspData[12] = response.TorInformation.OrigTransAuthCode;
        }

        public static void GetResponse(POSLink2.Batch.DeleteSafFileRsp response)
        {
            BatchData batchData = BatchData.GetBatchData();
            //Normal
            batchData.DeleteSafFileRspNormalData[0] = response.ResponseCode;
            batchData.DeleteSafFileRspNormalData[1] = response.ResponseMessage;
            batchData.DeleteSafFileRspNormalData[2] = response.SafDeletedCount;
            //Tor Info
            batchData.TorInfoRspData[0] = response.TorInformation.RecordType;
            batchData.TorInfoRspData[1] = response.TorInformation.ReversalTimeStamp;
            batchData.TorInfoRspData[2] = response.TorInformation.HostResponseCode;
            batchData.TorInfoRspData[3] = response.TorInformation.HostResponseMessage;
            batchData.TorInfoRspData[4] = response.TorInformation.HostRefNum;
            batchData.TorInfoRspData[5] = response.TorInformation.GatewayTransactionID;
            batchData.TorInfoRspData[6] = response.TorInformation.OrigAmount;
            batchData.TorInfoRspData[7] = response.TorInformation.MaskedPan;
            batchData.TorInfoRspData[8] = response.TorInformation.BatchNo;
            batchData.TorInfoRspData[9] = response.TorInformation.ReversalAuthCode;
            batchData.TorInfoRspData[10] = Tools.ParseTransType(response.TorInformation.OrigTransType);
            batchData.TorInfoRspData[11] = response.TorInformation.OrigTransDateTime;
            batchData.TorInfoRspData[12] = response.TorInformation.OrigTransAuthCode;
        }

        public static void GetResponse(POSLink2.Batch.DeleteTransactionRsp response)
        {
            BatchData batchData = BatchData.GetBatchData();
            //Normal
            batchData.DeleteTransRspNormalData[0] = response.ResponseCode;
            batchData.DeleteTransRspNormalData[1] = response.ResponseMessage;
            //Tor Info
            batchData.TorInfoRspData[0] = response.TorInformation.RecordType;
            batchData.TorInfoRspData[1] = response.TorInformation.ReversalTimeStamp;
            batchData.TorInfoRspData[2] = response.TorInformation.HostResponseCode;
            batchData.TorInfoRspData[3] = response.TorInformation.HostResponseMessage;
            batchData.TorInfoRspData[4] = response.TorInformation.HostRefNum;
            batchData.TorInfoRspData[5] = response.TorInformation.GatewayTransactionID;
            batchData.TorInfoRspData[6] = response.TorInformation.OrigAmount;
            batchData.TorInfoRspData[7] = response.TorInformation.MaskedPan;
            batchData.TorInfoRspData[8] = response.TorInformation.BatchNo;
            batchData.TorInfoRspData[9] = response.TorInformation.ReversalAuthCode;
            batchData.TorInfoRspData[10] = Tools.ParseTransType(response.TorInformation.OrigTransType);
            batchData.TorInfoRspData[11] = response.TorInformation.OrigTransDateTime;
            batchData.TorInfoRspData[12] = response.TorInformation.OrigTransAuthCode;
        }

        private void AddToMultipleCommandsButton_Click(object sender, EventArgs e)
        {
            _terminalData = TerminalData.GetTerminalData();
            MultipleCommandsModule multipleCommandsModule = new MultipleCommandsModule();
            switch (CommandComboBox.SelectedIndex)
            {
                case (int)BatchCommandName.BatchCloseReq / 2://BatchClose
                    POSLink2.Batch.BatchCloseReq batchCloseReq = SetBatchCloseReq();
                    multipleCommandsModule.CommandName = CommandName.BatchClose;
                    multipleCommandsModule.CommandReqObject = batchCloseReq;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)BatchCommandName.ForceBatchCloseReq / 2://ForceBatchClose
                    POSLink2.Batch.ForceBatchCloseReq forceBatchCloseReq = SetForceBatchCloseReq();
                    multipleCommandsModule.CommandName = CommandName.ForceBatchClose;
                    multipleCommandsModule.CommandReqObject = forceBatchCloseReq;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)BatchCommandName.BatchClearReq / 2://BatchClear
                    POSLink2.Batch.BatchClearReq batchClearReq = SetBatchClearReq();
                    multipleCommandsModule.CommandName = CommandName.BatchClear;
                    multipleCommandsModule.CommandReqObject = batchClearReq;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)BatchCommandName.PurgeBatchReq / 2://PurgeBatch
                    POSLink2.Batch.PurgeBatchReq purgeBatchReq = SetPurgeBatchReq();
                    multipleCommandsModule.CommandName = CommandName.PurgeBatch;
                    multipleCommandsModule.CommandReqObject = purgeBatchReq;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)BatchCommandName.SAFUploadReq / 2://SAFUpload
                    POSLink2.Batch.SafUploadReq safUploadReq = SetSafUploadReq();
                    multipleCommandsModule.CommandName = CommandName.SAFUpload;
                    multipleCommandsModule.CommandReqObject = safUploadReq;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)BatchCommandName.DeleteSAFFileReq / 2://DeleteSAFFile
                    POSLink2.Batch.DeleteSafFileReq deleteSAFFileReq = SetDeleteSafFileReq();
                    multipleCommandsModule.CommandName = CommandName.DeleteSAFFile;
                    multipleCommandsModule.CommandReqObject = deleteSAFFileReq;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)BatchCommandName.DeleteTransactionReq / 2://DeleteTransaction
                    POSLink2.Batch.DeleteTransactionReq deleteTransactionReq = SetDeleteTransactionReq();
                    multipleCommandsModule.CommandName = CommandName.DeleteTransaction;
                    multipleCommandsModule.CommandReqObject = deleteTransactionReq;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                default:
                    break;
            }
        }

        private void BatchUserControl_VisibleChanged(object sender, EventArgs e)
        {
            CommandComboBox.SelectedIndex = _comboBoxIndex;
            CommandComboBox_SelectedIndexChanged(sender, e);
        }
    }
}

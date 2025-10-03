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
    public partial class ReportUserControl : UserControl
    {
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

        private ReportData _reportData;
        private Tools _tools = new Tools();
        public ReportUserControl()
        {
            InitializeComponent();
            _comboBoxIndex = 0;
            CommandComboBox.SelectedIndex = 0;
            _reportData = ReportData.GetReportData();
            _waiting = new Waiting();
            _waiting.Dock = DockStyle.Left;
        }

        private void CommandComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _comboBoxIndex = CommandComboBox.SelectedIndex;
            _tools.DisposeSubControls(panel1);
            if (CommandComboBox.SelectedIndex == (int)ReportCommandName.LocalTotalReportReq/2)//LocalTotalReport
            {
                ReportOnePanelUserControl localTotalReportReqUserControl = new ReportOnePanelUserControl();
                localTotalReportReqUserControl.CommandName = ReportCommandName.LocalTotalReportReq;
                localTotalReportReqUserControl.Dock = DockStyle.Left;
                localTotalReportReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(localTotalReportReqUserControl);

                ReportTwoPanelsUserControl localTotalReportRspUserControl = new ReportTwoPanelsUserControl();
                localTotalReportRspUserControl.CommandName = ReportCommandName.LocalTotalReportRsp;
                localTotalReportRspUserControl.Dock = DockStyle.Left;
                localTotalReportRspUserControl.ShowButton(sender, e);
                panel1.Controls.Add(localTotalReportRspUserControl);

                localTotalReportReqUserControl.SendToBack();
            }
            else if(CommandComboBox.SelectedIndex == (int)ReportCommandName.LocalDetailReportReq / 2)//Local Detail Report
            {
                ReportTwoPanelsUserControl localDeltailReportReqUserControl = new ReportTwoPanelsUserControl();
                localDeltailReportReqUserControl.CommandName = ReportCommandName.LocalDetailReportReq;
                localDeltailReportReqUserControl.Dock = DockStyle.Left;
                localDeltailReportReqUserControl.ShowButton(sender, e);
                panel1.Controls.Add(localDeltailReportReqUserControl);

                ReportTwoPanelsUserControl localDetailReportRspUserControl = new ReportTwoPanelsUserControl();
                localDetailReportRspUserControl.CommandName = ReportCommandName.LocalDetailReportRsp;
                localDetailReportRspUserControl.Dock = DockStyle.Left;
                localDetailReportRspUserControl.ShowButton(sender, e);
                panel1.Controls.Add(localDetailReportRspUserControl);

                localDeltailReportReqUserControl.SendToBack();
            }
            else if(CommandComboBox.SelectedIndex == (int)ReportCommandName.LocalFailedReportReq / 2)//Local Failed Report
            {
                ReportOnePanelUserControl localFailedReportReqUserControl = new ReportOnePanelUserControl();
                localFailedReportReqUserControl.CommandName = ReportCommandName.LocalFailedReportReq;
                localFailedReportReqUserControl.Dock = DockStyle.Left;
                localFailedReportReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(localFailedReportReqUserControl);

                ReportTwoPanelsUserControl localFailedReportRspUserControl = new ReportTwoPanelsUserControl();
                localFailedReportRspUserControl.CommandName = ReportCommandName.LocalFailedReportRsp;
                localFailedReportRspUserControl.Dock = DockStyle.Left;
                localFailedReportRspUserControl.ShowButton(sender, e);
                panel1.Controls.Add(localFailedReportRspUserControl);

                localFailedReportReqUserControl.SendToBack();
            }
            else if(CommandComboBox.SelectedIndex == (int)ReportCommandName.HostReportReq / 2)//Host Report
            {
                ReportOnePanelUserControl hostReportReqUserControl = new ReportOnePanelUserControl();
                hostReportReqUserControl.CommandName = ReportCommandName.HostReportReq;
                hostReportReqUserControl.Dock = DockStyle.Left;
                hostReportReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(hostReportReqUserControl);

                ReportOnePanelUserControl hostReportRspUserControl = new ReportOnePanelUserControl();
                hostReportRspUserControl.CommandName = ReportCommandName.HostReportRsp;
                hostReportRspUserControl.Dock = DockStyle.Left;
                hostReportRspUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(hostReportRspUserControl);

                hostReportReqUserControl.SendToBack();
            }
            else if(CommandComboBox.SelectedIndex == (int)ReportCommandName.HistoryReportReq / 2)//History Report
            {
                ReportOnePanelUserControl historyReportReqUserControl = new ReportOnePanelUserControl();
                historyReportReqUserControl.CommandName = ReportCommandName.HistoryReportReq;
                historyReportReqUserControl.Dock = DockStyle.Left;
                historyReportReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(historyReportReqUserControl);

                ReportOnePanelUserControl historyReportRspUserControl = new ReportOnePanelUserControl();
                historyReportRspUserControl.CommandName = ReportCommandName.HistoryReportRsp;
                historyReportRspUserControl.Dock = DockStyle.Left;
                historyReportRspUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(historyReportRspUserControl);

                historyReportReqUserControl.SendToBack();
            }
            else if(CommandComboBox.SelectedIndex == (int)ReportCommandName.SAFSummaryReportReq / 2)//Saf Summary Report
            {
                ReportOnePanelUserControl safSummaryReportReqUserControl = new ReportOnePanelUserControl();
                safSummaryReportReqUserControl.CommandName = ReportCommandName.SAFSummaryReportReq;
                safSummaryReportReqUserControl.Dock = DockStyle.Left;
                safSummaryReportReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(safSummaryReportReqUserControl);

                ReportOnePanelUserControl safSummaryReportRspUserControl = new ReportOnePanelUserControl();
                safSummaryReportRspUserControl.CommandName = ReportCommandName.SAFSummaryReportRsp;
                safSummaryReportRspUserControl.Dock = DockStyle.Left;
                safSummaryReportRspUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(safSummaryReportRspUserControl);

                safSummaryReportReqUserControl.SendToBack();
            }
            else if (CommandComboBox.SelectedIndex == (int)ReportCommandName.HostDetailReportReq / 2)//Host Detail Report
            {
                ReportOnePanelUserControl hostDeltailReportReqUserControl = new ReportOnePanelUserControl();
                hostDeltailReportReqUserControl.CommandName = ReportCommandName.HostDetailReportReq;
                hostDeltailReportReqUserControl.Dock = DockStyle.Left;
                hostDeltailReportReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(hostDeltailReportReqUserControl);

                ReportTwoPanelsUserControl hostDetailReportRspUserControl = new ReportTwoPanelsUserControl();
                hostDetailReportRspUserControl.CommandName = ReportCommandName.HostDetailReportRsp;
                hostDetailReportRspUserControl.Dock = DockStyle.Left;
                hostDetailReportRspUserControl.ShowButton(sender, e);
                panel1.Controls.Add(hostDetailReportRspUserControl);

                hostDeltailReportReqUserControl.SendToBack();
            }
        }

        private void RunReport(int tenderType, object sender, EventArgs e)
        {
            Task task = new Task(() =>
            {
                POSLink2.ExecutionResult executionResult = new POSLink2.ExecutionResult();

                switch (tenderType)
                {
                    case (int)ReportCommandName.LocalTotalReportReq / 2://Local Total Report
                        POSLink2.Report.LocalTotalReportReq localTotalReportReq = SetLocalTotalReportReq();
                        POSLink2.Report.LocalTotalReportRsp localTotalReportRsp = null;
                        executionResult = _terminal.Report.LocalTotalReport(localTotalReportReq, out localTotalReportRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(localTotalReportRsp);
                        }
                        break;
                    case (int)ReportCommandName.LocalDetailReportReq / 2://Local Detail Report
                        POSLink2.Report.LocalDetailReportReq localDetailReportReq = SetLocalDetailReportReq();
                        POSLink2.Report.LocalDetailReportRsp localDetailReportRsp = null;
                        executionResult = _terminal.Report.LocalDetailReport(localDetailReportReq, out localDetailReportRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(localDetailReportRsp);
                        }
                        break;
                    case (int)ReportCommandName.LocalFailedReportReq / 2://Local Failed Report
                        POSLink2.Report.LocalFailedReportRsp localFailedReportRsp = null;
                        executionResult = _terminal.Report.LocalFailedReport(out localFailedReportRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(localFailedReportRsp);
                        }
                        break;
                    case (int)ReportCommandName.HostReportReq / 2://Host Report
                        POSLink2.Report.HostReportRsp hostReportRsp = null;
                        executionResult = _terminal.Report.HostReport(out hostReportRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(hostReportRsp);
                        }
                        break;
                    case (int)ReportCommandName.HistoryReportReq / 2://History Report
                        POSLink2.Report.HistoryReportRsp historyReportRsp = null;
                        executionResult = _terminal.Report.HistoryReport(out historyReportRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(historyReportRsp);
                        }
                        break;
                    case (int)ReportCommandName.SAFSummaryReportReq / 2://Saf Summary Report
                        POSLink2.Report.SafSummaryReportReq safSummaryReportReq = SetSafSummaryReportReq();
                        POSLink2.Report.SafSummaryReportRsp safSummaryReportRsp = null;
                        executionResult = _terminal.Report.SafSummaryReport(safSummaryReportReq, out safSummaryReportRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(safSummaryReportRsp);
                        }
                        break;
                    case (int)ReportCommandName.HostDetailReportReq / 2://Saf Summary Report
                        POSLink2.Report.HostDetailReportReq hostDetailReportReq = SetHostDetailReportReq();
                        POSLink2.Report.HostDetailReportRsp hostDetailReportRsp = null;
                        executionResult = _terminal.Report.HostDetailReport(hostDetailReportReq, out hostDetailReportRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(hostDetailReportRsp);
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
                });
                BeginInvoke(methodInvoker);
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
            _reportData.ResponseClear();
            _waiting.Location = new Point(0, 0);
            _waiting.IsCancelAvaliable = false;
            this.Controls.Add(_waiting);
            _waiting.BringToFront();
            _waiting.Show();

            int tenderType = CommandComboBox.SelectedIndex;
            RunReport(tenderType, sender, e);
        }

        private void ReportUserControl_Load(object sender, EventArgs e)
        {

        }

        private POSLink2.Report.LocalTotalReportReq SetLocalTotalReportReq()
        {
            POSLink2.Report.LocalTotalReportReq request = new POSLink2.Report.LocalTotalReportReq();
            request.EdcType = (POSLink2.Const.EdcType)Global.EdcType[_reportData.EdcTypeIndex, 1];
            if (_reportData.CardTypeIndex != 0)
            {
                request.CardType = (POSLink2.Const.CardType)Global.CardType[_reportData.CardTypeIndex, 1];
            }
            return request;
        }

        private POSLink2.Report.LocalDetailReportReq SetLocalDetailReportReq()
        {
            POSLink2.Report.LocalDetailReportReq request = new POSLink2.Report.LocalDetailReportReq();
            request.EdcType = (POSLink2.Const.EdcType)Global.EdcType[_reportData.EdcTypeIndex, 1];
            request.TransactionType = (POSLink2.Const.TransType)Global.TransType[_reportData.TransTypeIndex, 1];
            if (_reportData.CardTypeIndex != 0)
            {
                request.CardType = (POSLink2.Const.CardType)Global.CardType[_reportData.CardTypeIndex, 1];
            }
            request.RecordNumber = _reportData.LocalDetailReportReqNormalData[0];
            request.OrigRefNum = _reportData.LocalDetailReportReqNormalData[1];
            request.AuthCode = _reportData.LocalDetailReportReqNormalData[2];
            request.EcrRefNum = _reportData.LocalDetailReportReqNormalData[3];
            request.GlobalUid = _reportData.LocalDetailReportReqNormalData[4];
            request.LastTransaction = _reportData.LocalDetailReportReqNormalData[5];
            request.TransactionResultType = _reportData.LocalDetailReportReqNormalData[6];
            request.MultiMerchant = SetMultiMerchant();
            return request;
        }

        private POSLink2.Report.SafSummaryReportReq SetSafSummaryReportReq()
        {
            POSLink2.Report.SafSummaryReportReq reqeust = new POSLink2.Report.SafSummaryReportReq();
            reqeust.SafIndicator = _reportData.SafSummaryReportReqNormalData[0];
            return reqeust;
        }

        private POSLink2.Report.HostDetailReportReq SetHostDetailReportReq()
        {
            POSLink2.Report.HostDetailReportReq request = new POSLink2.Report.HostDetailReportReq();
            request.EdcType = (POSLink2.Const.EdcType)Global.EdcType[_reportData.EdcTypeIndex, 1];
            request.TransactionType = (POSLink2.Const.TransType)Global.TransType[_reportData.TransTypeIndex, 1];
            if (_reportData.CardTypeIndex != 0)
            {
                request.CardType = (POSLink2.Const.CardType)Global.CardType[_reportData.CardTypeIndex, 1];
            }
            request.AuthCode = _reportData.HostDetailReportReqNormalData[0];
            request.EcrTransId = _reportData.HostDetailReportReqNormalData[1];
            request.HRef = _reportData.HostDetailReportReqNormalData[2];
            return request;
        }

        private POSLink2.Util.MultiMerchant SetMultiMerchant()
        {
            POSLink2.Util.MultiMerchant request = new POSLink2.Util.MultiMerchant();
            request.Id = _reportData.MultiMerchantReqData[0];
            request.Name = _reportData.MultiMerchantReqData[1];
            return request;
        }

        public static void GetHostInformation(POSLink2.Util.HostRsp response)
        {
            if (response != null)
            {
                ReportData reportData = ReportData.GetReportData();
                reportData.HostInfoRspData[0] = response.HostResponseCode;
                reportData.HostInfoRspData[1] = response.HostResponseMessage;
                reportData.HostInfoRspData[2] = response.AuthCode;
                reportData.HostInfoRspData[3] = response.HostRefNum;
                reportData.HostInfoRspData[4] = response.TraceNumber;
                reportData.HostInfoRspData[5] = response.BatchNumber;
                reportData.HostInfoRspData[6] = response.TransactionIdentifier;
                reportData.HostInfoRspData[7] = response.GatewayTransactionID;
                reportData.HostInfoRspData[8] = response.HostDetailedMessage;
                reportData.HostInfoRspData[9] = response.TransactionIntegrityClass;
                reportData.HostInfoRspData[10] = response.RetrievalRefNum;
                reportData.HostInfoRspData[11] = response.IssuerResponseCode;
                reportData.HostInfoRspData[12] = response.PaymentAccountRefId;
            }
        }

        public static void GetAmountInformation(POSLink2.Util.AmountRsp response)
        {
            if (response != null)
            {
                ReportData reportData = ReportData.GetReportData();
                reportData.AmountInfoRspData[0] = response.ApproveAmount;
                reportData.AmountInfoRspData[1] = response.AmountDue;
                reportData.AmountInfoRspData[2] = response.TipAmount;
                reportData.AmountInfoRspData[3] = response.CashBackAmount;
                reportData.AmountInfoRspData[4] = response.MerchantFee;
                reportData.AmountInfoRspData[5] = response.TaxAmount;
                reportData.AmountInfoRspData[6] = response.Balance1;
                reportData.AmountInfoRspData[7] = response.Balance2;
                reportData.AmountInfoRspData[8] = response.ServiceFee;
                reportData.AmountInfoRspData[9] = response.TransactionRemainingAmount;
                reportData.AmountInfoRspData[10] = response.ApprovedTipAmount;
                reportData.AmountInfoRspData[11] = response.ApprovedCashBackAmount;
                reportData.AmountInfoRspData[12] = response.ApprovedMerchantFee;
                reportData.AmountInfoRspData[13] = response.ApprovedTaxAmount;
            }
        }

        public static void GetAccountInformation(POSLink2.Util.AccountRsp response)
        {
            if (response != null)
            {
                ReportData reportData = ReportData.GetReportData();
                reportData.AccountInfoRspData[0] = response.Account;
                reportData.AccountInfoRspData[1] = response.EntryMode;
                reportData.AccountInfoRspData[2] = response.ExpireDate;
                reportData.AccountInfoRspData[3] = response.EbtType;
                reportData.AccountInfoRspData[4] = response.VoucherNumber;
                reportData.AccountInfoRspData[5] = response.NewAccountNo;
                reportData.AccountInfoRspData[6] = response.CardType;
                reportData.AccountInfoRspData[7] = response.CardHolder;
                reportData.AccountInfoRspData[8] = response.CvdApprovalCode;
                reportData.AccountInfoRspData[9] = response.CvdMessage;
                reportData.AccountInfoRspData[10] = response.CardPresentIndicator;
                reportData.AccountInfoRspData[11] = response.GiftCardType;
                reportData.AccountInfoRspData[12] = response.DebitAccountType;
                reportData.AccountInfoRspData[13] = response.HostAccount;
                reportData.AccountInfoRspData[14] = response.HostCardType;
                reportData.AccountInfoRspData[15] = response.Track1Data;
                reportData.AccountInfoRspData[16] = response.Track2Data;
                reportData.AccountInfoRspData[17] = response.Track3Data;
            }
        }

        public static void GetTraceInformation(POSLink2.Util.TraceRsp response)
        {
            if (response != null)
            {
                ReportData reportData = ReportData.GetReportData();
                reportData.TraceInfoRspData[0] = response.RefNum;
                reportData.TraceInfoRspData[1] = response.EcrRefNum;
                reportData.TraceInfoRspData[2] = response.TimeStamp;
                reportData.TraceInfoRspData[3] = response.InvoiceNumber;
                reportData.TraceInfoRspData[4] = response.PaymentService2000;
                reportData.TraceInfoRspData[5] = response.AuthorizationResponse;
                reportData.TraceInfoRspData[6] = response.EcrTransID;
                reportData.TraceInfoRspData[7] = response.HostTimeStamp;
            }
        }

        public static void GetCashierInformation(POSLink2.Util.CashierRsp response)
        {
            if (response != null)
            {
                ReportData reportData = ReportData.GetReportData();
                reportData.CashierInfoRspData[0] = response.ClerkID;
                reportData.CashierInfoRspData[1] = response.ShiftID;
            }
        }

        public static void GetCommercialInformation(POSLink2.Util.CommercialRsp response)
        {
            if (response != null)
            {
                ReportData reportData = ReportData.GetReportData();
                reportData.CommercialInfoRspData[0] = response.PoNumber;
                reportData.CommercialInfoRspData[1] = response.CustomerCode;
                reportData.CommercialInfoRspData[2] = response.TaxExempt;
                reportData.CommercialInfoRspData[3] = response.TaxExemptID;
                reportData.CommercialInfoRspData[4] = response.MerchantTaxID;
                reportData.CommercialInfoRspData[5] = response.DestinationZipCode;
                reportData.CommercialInfoRspData[6] = response.ProductDescription;
            }
        }

        public static void GetCheckInformation(POSLink2.Util.CheckRsp response)
        {
            if (response != null)
            {
                ReportData reportData = ReportData.GetReportData();
                reportData.CheckInfoRspData[0] = response.SaleType;
                reportData.CheckInfoRspData[1] = response.RoutingNumber;
                reportData.CheckInfoRspData[2] = response.AccountNumber;
                reportData.CheckInfoRspData[3] = response.CheckNumber;
                reportData.CheckInfoRspData[4] = response.CheckType;
                reportData.CheckInfoRspData[5] = response.IdType;
                reportData.CheckInfoRspData[6] = response.IdValue;
                reportData.CheckInfoRspData[7] = response.Birth;
                reportData.CheckInfoRspData[8] = response.PhoneNumber;
                reportData.CheckInfoRspData[9] = response.ZipCode;
            }
        }

        public static void GetTorInformation(POSLink2.Util.TorRsp response)
        {
            if (response != null)
            {
                ReportData reportData = ReportData.GetReportData();
                reportData.TorInfoRspData[0] = response.RecordType;
                reportData.TorInfoRspData[1] = response.ReversalTimeStamp;
                reportData.TorInfoRspData[2] = response.HostResponseCode;
                reportData.TorInfoRspData[3] = response.HostResponseMessage;
                reportData.TorInfoRspData[4] = response.HostRefNum;
                reportData.TorInfoRspData[5] = response.GatewayTransactionID;
                reportData.TorInfoRspData[6] = response.OrigAmount;
                reportData.TorInfoRspData[7] = response.MaskedPan;
                reportData.TorInfoRspData[8] = response.BatchNo;
                reportData.TorInfoRspData[9] = response.ReversalAuthCode;
                reportData.TorInfoRspData[10] = Tools.ParseTransType(response.OrigTransType);
                reportData.TorInfoRspData[11] = response.OrigTransDateTime;
                reportData.TorInfoRspData[12] = response.OrigTransAuthCode;
            }
        }

        public static void GetRestaurant(POSLink2.Util.Restaurant response)
        {
            if (response != null)
            {
                ReportData reportData = ReportData.GetReportData();
                reportData.RestaurantRspData[0] = response.TableNumber;
                reportData.RestaurantRspData[1] = response.GuestNumber;
                reportData.RestaurantRspData[2] = response.TicketNumber;
            }
        }

        public static void GetReportTransInfo(POSLink2.Util.ReportTransInfo response)
        {
            if (response != null)
            {
                ReportData reportData = ReportData.GetReportData();
                reportData.TransInfoRspData[0] = response.DiscountAmount;
                reportData.TransInfoRspData[1] = response.ChargedAmount;
                reportData.TransInfoRspData[2] = response.SignatureStatus;
                reportData.TransInfoRspData[3] = response.Fps;
                reportData.TransInfoRspData[4] = response.FpsSignature;
                reportData.TransInfoRspData[5] = response.FpsReceipt;
                reportData.TransInfoRspData[6] = response.Token;
                reportData.TransInfoRspData[7] = response.HRef;
                reportData.TransInfoRspData[8] = response.Sn;
                reportData.TransInfoRspData[9] = response.SettlementDate;
                reportData.TransInfoRspData[10] = response.HostEchoData;
                reportData.TransInfoRspData[11] = response.PinStatusNum;
                reportData.TransInfoRspData[12] = response.ValidationCode;
                reportData.TransInfoRspData[13] = response.UserLanguageStatus;
                reportData.TransInfoRspData[14] = response.GlobalUid;
                reportData.AddlRspDataResponse = response.AddlRspDataInfo;
            }
        }

        public static void GetCardInfo(POSLink2.Util.CardInfo response)
        {
            if (response != null)
            {
                ReportData reportData = ReportData.GetReportData();
                reportData.CardInfoRspData[0] = response.CardBin;
                reportData.CardInfoRspData[1] = response.NewCardBin;
                reportData.CardInfoRspData[2] = response.ProgramType;
                reportData.CardInfoRspData[3] = response.HostProgramType;
            }
        }

        public static void GetMultiMerchant(POSLink2.Util.MultiMerchant response)
        {
            if (response != null)
            {
                ReportData reportData = ReportData.GetReportData();
                reportData.MultiMerchantRspData[0] = response.Id;
                reportData.MultiMerchantRspData[1] = response.Name;
            }
        }

        public static void GetReportEmvTag(POSLink2.Util.ReportEmvTag response)
        {
            if (response != null)
            {
                ReportData reportData = ReportData.GetReportData();
                reportData.EmvTagRspData[0] = response.Tc;
                reportData.EmvTagRspData[1] = response.Tvr;
                reportData.EmvTagRspData[2] = response.Aid;
                reportData.EmvTagRspData[3] = response.Tsi;
                reportData.EmvTagRspData[4] = response.Atc;
                reportData.EmvTagRspData[5] = response.AppLabel;
                reportData.EmvTagRspData[6] = response.AppPreferName;
                reportData.EmvTagRspData[7] = response.Iad;
                reportData.EmvTagRspData[8] = response.Arc;
                reportData.EmvTagRspData[9] = response.Cid;
                reportData.EmvTagRspData[10] = response.Cvm;
                reportData.EmvTagRspData[11] = response.Arqc;
                reportData.EmvTagRspData[12] = response.PanSequenceNumber;
            }
        }

        public static void GetFleetCard(POSLink2.Util.FleetCard response)
        {
            if (response != null)
            {
                ReportData reportData = ReportData.GetReportData();
                reportData.FleetCardRspData[0] = response.Odometer;
                reportData.FleetCardRspData[1] = response.VehicleNumber;
                reportData.FleetCardRspData[2] = response.JobNumber;
                reportData.FleetCardRspData[3] = response.DriverId;
                reportData.FleetCardRspData[4] = response.EmployeeNumber;
                reportData.FleetCardRspData[5] = response.LicenseNumber;
                reportData.FleetCardRspData[6] = response.JobId;
                reportData.FleetCardRspData[7] = response.DepartmentNumber;
                reportData.FleetCardRspData[8] = response.CustomerData;
                reportData.FleetCardRspData[9] = response.UserId;
                reportData.FleetCardRspData[10] = response.VehicleId;
                reportData.FleetCardRspData[11] = response.FleetPromptCode;
            }
        }

        public static void GetResponse( POSLink2.Report.LocalTotalReportRsp response)
        {
            ReportData reportData = ReportData.GetReportData();
            //Normal
            reportData.LocalTotalReportRspNormalData[0] = response.ResponseCode;
            reportData.LocalTotalReportRspNormalData[1] = response.ResponseMessage;
            reportData.LocalTotalReportRspNormalData[2] = Tools.ParseEdcType(response.EdcType);
            //Totals
            if(response.Totals != null)
            {
                if(response.Totals.CreditTotals != null)
                {
                    reportData.CreditTotalDataRspData[0] = response.Totals.CreditTotals.SaleCount;
                    reportData.CreditTotalDataRspData[1] = response.Totals.CreditTotals.SaleAmount;
                    reportData.CreditTotalDataRspData[2] = response.Totals.CreditTotals.ForcedCount;
                    reportData.CreditTotalDataRspData[3] = response.Totals.CreditTotals.ForcedAmount;
                    reportData.CreditTotalDataRspData[4] = response.Totals.CreditTotals.ReturnCount;
                    reportData.CreditTotalDataRspData[5] = response.Totals.CreditTotals.ReturnAmount;
                    reportData.CreditTotalDataRspData[6] = response.Totals.CreditTotals.AuthCount;
                    reportData.CreditTotalDataRspData[7] = response.Totals.CreditTotals.AuthAmount;
                    reportData.CreditTotalDataRspData[8] = response.Totals.CreditTotals.PostauthCount;
                    reportData.CreditTotalDataRspData[9] = response.Totals.CreditTotals.PostauthAmount;

                    string temp = string.Join("=", reportData.CreditTotalDataRspData);
                    reportData.TotalDataRspTextData[0] = RemoveUslessSeparator(temp, "=");
                }
                if(response.Totals.DebitTotals != null)
                {
                    reportData.DebitTotalDataRspData[0] = response.Totals.DebitTotals.SaleCount;
                    reportData.DebitTotalDataRspData[1] = response.Totals.DebitTotals.SaleAmount;
                    reportData.DebitTotalDataRspData[2] = response.Totals.DebitTotals.ReturnCount;
                    reportData.DebitTotalDataRspData[3] = response.Totals.DebitTotals.ReturnAmount;
                    reportData.DebitTotalDataRspData[4] = response.Totals.DebitTotals.AuthCount;
                    reportData.DebitTotalDataRspData[5] = response.Totals.DebitTotals.AuthAmount;
                    reportData.DebitTotalDataRspData[6] = response.Totals.DebitTotals.PostauthCount;
                    reportData.DebitTotalDataRspData[7] = response.Totals.DebitTotals.PostauthAmount;

                    string temp = string.Join("=", reportData.DebitTotalDataRspData);
                    reportData.TotalDataRspTextData[1] = RemoveUslessSeparator(temp, "=");
                }
                if(response.Totals.EbtTotals != null)
                {
                    reportData.EbtTotalDataRspData[0] = response.Totals.EbtTotals.SaleCount;
                    reportData.EbtTotalDataRspData[1] = response.Totals.EbtTotals.SaleAmount;
                    reportData.EbtTotalDataRspData[2] = response.Totals.EbtTotals.ReturnCount;
                    reportData.EbtTotalDataRspData[3] = response.Totals.EbtTotals.ReturnAmount;
                    reportData.EbtTotalDataRspData[4] = response.Totals.EbtTotals.WithdrawalCount;
                    reportData.EbtTotalDataRspData[5] = response.Totals.EbtTotals.WithdrawalAmount;
                    reportData.EbtTotalDataRspData[6] = response.Totals.EbtTotals.AuthCount;
                    reportData.EbtTotalDataRspData[7] = response.Totals.EbtTotals.AuthAmount;
                    reportData.EbtTotalDataRspData[8] = response.Totals.EbtTotals.PostauthCount;
                    reportData.EbtTotalDataRspData[9] = response.Totals.EbtTotals.PostauthAmount;

                    string temp = string.Join("=", reportData.EbtTotalDataRspData);
                    reportData.TotalDataRspTextData[2] = RemoveUslessSeparator(temp, "=");
                }
                if(response.Totals.GiftTotals != null)
                {
                    reportData.GiftTotalDataRspData[0] = response.Totals.GiftTotals.SaleCount;
                    reportData.GiftTotalDataRspData[1] = response.Totals.GiftTotals.SaleAmount;
                    reportData.GiftTotalDataRspData[2] = response.Totals.GiftTotals.AuthCount;
                    reportData.GiftTotalDataRspData[3] = response.Totals.GiftTotals.AuthAmount;
                    reportData.GiftTotalDataRspData[4] = response.Totals.GiftTotals.PostauthCount;
                    reportData.GiftTotalDataRspData[5] = response.Totals.GiftTotals.PostauthAmount;
                    reportData.GiftTotalDataRspData[6] = response.Totals.GiftTotals.ActivateCount;
                    reportData.GiftTotalDataRspData[7] = response.Totals.GiftTotals.ActivateAmount;
                    reportData.GiftTotalDataRspData[8] = response.Totals.GiftTotals.IssueCount;
                    reportData.GiftTotalDataRspData[9] = response.Totals.GiftTotals.IssueAmount;
                    reportData.GiftTotalDataRspData[10] = response.Totals.GiftTotals.AddCount;
                    reportData.GiftTotalDataRspData[11] = response.Totals.GiftTotals.AddAmount;
                    reportData.GiftTotalDataRspData[12] = response.Totals.GiftTotals.ReturnCount;
                    reportData.GiftTotalDataRspData[13] = response.Totals.GiftTotals.ReturnAmount;
                    reportData.GiftTotalDataRspData[14] = response.Totals.GiftTotals.ForcedCount;
                    reportData.GiftTotalDataRspData[15] = response.Totals.GiftTotals.ForcedAmount;
                    reportData.GiftTotalDataRspData[16] = response.Totals.GiftTotals.CashoutCount;
                    reportData.GiftTotalDataRspData[17] = response.Totals.GiftTotals.CashoutAmount;
                    reportData.GiftTotalDataRspData[18] = response.Totals.GiftTotals.DeactivateCount;
                    reportData.GiftTotalDataRspData[19] = response.Totals.GiftTotals.DeactivateAmount;
                    reportData.GiftTotalDataRspData[20] = response.Totals.GiftTotals.AdjustCount;
                    reportData.GiftTotalDataRspData[21] = response.Totals.GiftTotals.AdjustAmount;

                    string temp = string.Join("=", reportData.GiftTotalDataRspData);
                    reportData.TotalDataRspTextData[3] = RemoveUslessSeparator(temp, "=");
                }
                if(response.Totals.LoyaltyTotals != null)
                {
                    reportData.LoyaltyTotalDataRspData[0] = response.Totals.LoyaltyTotals.RedeemCount;
                    reportData.LoyaltyTotalDataRspData[1] = response.Totals.LoyaltyTotals.RedeemAmount;
                    reportData.LoyaltyTotalDataRspData[2] = response.Totals.LoyaltyTotals.IssueCount;
                    reportData.LoyaltyTotalDataRspData[3] = response.Totals.LoyaltyTotals.IssueAmount;
                    reportData.LoyaltyTotalDataRspData[4] = response.Totals.LoyaltyTotals.AddCount;
                    reportData.LoyaltyTotalDataRspData[5] = response.Totals.LoyaltyTotals.AddAmount;
                    reportData.LoyaltyTotalDataRspData[6] = response.Totals.LoyaltyTotals.ReturnCount;
                    reportData.LoyaltyTotalDataRspData[7] = response.Totals.LoyaltyTotals.ReturnAmount;
                    reportData.LoyaltyTotalDataRspData[8] = response.Totals.LoyaltyTotals.ForcedCount;
                    reportData.LoyaltyTotalDataRspData[9] = response.Totals.LoyaltyTotals.ForcedAmount;
                    reportData.LoyaltyTotalDataRspData[10] = response.Totals.LoyaltyTotals.ActivateCount;
                    reportData.LoyaltyTotalDataRspData[11] = response.Totals.LoyaltyTotals.ActivateAmount;
                    reportData.LoyaltyTotalDataRspData[12] = response.Totals.LoyaltyTotals.DeactivateCount;
                    reportData.LoyaltyTotalDataRspData[13] = response.Totals.LoyaltyTotals.DeactivateAmount;

                    string temp = string.Join("=", reportData.LoyaltyTotalDataRspData);
                    reportData.TotalDataRspTextData[4] = RemoveUslessSeparator(temp, "=");
                }
                if(response.Totals.CashTotals != null)
                {
                    reportData.CashTotalDataRspData[0] = response.Totals.CashTotals.SaleCount;
                    reportData.CashTotalDataRspData[1] = response.Totals.CashTotals.SaleAmount;
                    reportData.CashTotalDataRspData[2] = response.Totals.CashTotals.ReturnCount;
                    reportData.CashTotalDataRspData[3] = response.Totals.CashTotals.ReturnAmount;

                    string temp = string.Join("=", reportData.CashTotalDataRspData);
                    reportData.TotalDataRspTextData[5] = RemoveUslessSeparator(temp, "=");
                }
                if(response.Totals.CheckTotals != null)
                {
                    reportData.CheckTotalDataRspData[0] = response.Totals.CheckTotals.SaleCount;
                    reportData.CheckTotalDataRspData[1] = response.Totals.CheckTotals.SaleAmount;
                    reportData.CheckTotalDataRspData[2] = response.Totals.CheckTotals.AdjustCount;
                    reportData.CheckTotalDataRspData[3] = response.Totals.CheckTotals.AdjustAmount;

                    string temp = string.Join("=", reportData.CheckTotalDataRspData);
                    reportData.TotalDataRspTextData[6] = RemoveUslessSeparator(temp, "=");
                }
            }
        }

        public static void GetResponse(POSLink2.Report.LocalDetailReportRsp response)
        {
            ReportData reportData = ReportData.GetReportData();
            reportData.LocalDetailReportRspNormalData[0] = response.ResponseCode;
            reportData.LocalDetailReportRspNormalData[1] = response.ResponseMessage;
            reportData.LocalDetailReportRspNormalData[2] = response.TotalRecord;
            reportData.LocalDetailReportRspNormalData[3] = response.RecordNumber;
            reportData.LocalDetailReportRspNormalData[4] = Tools.ParseEdcType(response.EdcType);
            reportData.LocalDetailReportRspNormalData[5] = Tools.ParseTransType(response.TransactionType);
            reportData.LocalDetailReportRspNormalData[6] = Tools.ParseTransType(response.OriginalTransactionType);
            GetHostInformation(response.HostInformation);
            GetAmountInformation(response.AmountInformation);
            GetAccountInformation(response.AccountInformation);
            GetTraceInformation(response.TraceInformation);
            GetCashierInformation(response.CashierInformation);
            GetCommercialInformation(response.CommercialInformation);
            GetCheckInformation(response.CheckInformation);
            GetTorInformation(response.TorInformation);
            GetRestaurant(response.Restaurant);
            GetReportTransInfo(response.ReportTransInfo);
            GetCardInfo(response.CardInfo);
            GetMultiMerchant(response.MultiMerchant);
            GetReportEmvTag(response.ReportEmvTag);
            GetFleetCard(response.FleetCard);
        }

        public static void GetResponse(POSLink2.Report.LocalFailedReportRsp response)
        {
            ReportData reportData = ReportData.GetReportData();
            reportData.LocalFailedReportRspNormalData[0] = response.ResponseCode;
            reportData.LocalFailedReportRspNormalData[1] = response.ResponseMessage;
            reportData.LocalFailedReportRspNormalData[2] = Tools.ParseEdcType(response.EdcType);
            reportData.LocalFailedReportRspNormalData[3] = Tools.ParseTransType(response.TransactionType);
            GetHostInformation(response.HostInformation);
            GetAmountInformation(response.AmountInformation);
            GetAccountInformation(response.AccountInformation);
            GetTraceInformation(response.TraceInformation);
        }

        public static void GetResponse(POSLink2.Report.HostReportRsp response)
        {
            ReportData reportData = ReportData.GetReportData();
            //Normal
            reportData.HostReportRspNormalData[0] = response.ResponseCode;
            reportData.HostReportRspNormalData[1] = response.ResponseMessage;
            reportData.HostReportRspNormalData[3] = response.ReportType;
            reportData.HostReportRspNormalData[4] = response.TimeStamp;
            reportData.LineMessageRspData = response.LinesMessage;
        }

        public static void GetResponse(POSLink2.Report.HistoryReportRsp response)
        {
            ReportData reportData = ReportData.GetReportData();
            //Normal
            reportData.HistoryReportRspNormalData[0] = response.ResponseCode;
            reportData.HistoryReportRspNormalData[1] = response.ResponseMessage;
            reportData.HistoryReportRspNormalData[2] = response.TimeStamp;
            reportData.HistoryReportRspNormalData[3] = response.BatchNumber;
            //TotalCount
            if(response.EdcTotalCount != null)
            {
                reportData.HistoryReportTotalCountRspData[0] = response.EdcTotalCount.CreditCount;
                reportData.HistoryReportTotalCountRspData[1] = response.EdcTotalCount.DebitCount;
                reportData.HistoryReportTotalCountRspData[2] = response.EdcTotalCount.EbtCount;
                reportData.HistoryReportTotalCountRspData[3] = response.EdcTotalCount.GfitCount;
                reportData.HistoryReportTotalCountRspData[4] = response.EdcTotalCount.LoyaltyCount;
                reportData.HistoryReportTotalCountRspData[5] = response.EdcTotalCount.CashCount;
                reportData.HistoryReportTotalCountRspData[6] = response.EdcTotalCount.CheckCount;

                string temp = string.Join("=", reportData.HistoryReportTotalCountRspData);
                reportData.HistoryReportRspTextData[0] = RemoveUslessSeparator(temp, "=");
            }
            if(response.EdcTotalAmount != null)
            {
                reportData.HistoryReportTotalAmountRspData[0] = response.EdcTotalAmount.CreditAmount;
                reportData.HistoryReportTotalAmountRspData[1] = response.EdcTotalAmount.DebitAmount;
                reportData.HistoryReportTotalAmountRspData[2] = response.EdcTotalAmount.EbtAmount;
                reportData.HistoryReportTotalAmountRspData[3] = response.EdcTotalAmount.GfitAmount;
                reportData.HistoryReportTotalAmountRspData[4] = response.EdcTotalAmount.LoyaltyAmount;
                reportData.HistoryReportTotalAmountRspData[5] = response.EdcTotalAmount.CashAmount;
                reportData.HistoryReportTotalAmountRspData[6] = response.EdcTotalAmount.CheckAmount;

                string temp = string.Join("=", reportData.HistoryReportTotalAmountRspData);
                reportData.HistoryReportRspTextData[1] = RemoveUslessSeparator(temp, "=");
            }
        }

        public static void GetResponse(POSLink2.Report.SafSummaryReportRsp response)
        {
            ReportData reportData = ReportData.GetReportData();
            //Normal
            reportData.SafSummaryReportRspNormalData[0] = response.ResponseCode;
            reportData.SafSummaryReportRspNormalData[1] = response.ResponseMessage;
            //count
            if(response.CardTotalCount != null)
            {
                reportData.SafReportTotalCountRspData[0] = response.CardTotalCount.VisaCount;
                reportData.SafReportTotalCountRspData[1] = response.CardTotalCount.MasterCardCount;
                reportData.SafReportTotalCountRspData[2] = response.CardTotalCount.AmexCount;
                reportData.SafReportTotalCountRspData[3] = response.CardTotalCount.DinersCount;
                reportData.SafReportTotalCountRspData[4] = response.CardTotalCount.DiscoverCount;
                reportData.SafReportTotalCountRspData[5] = response.CardTotalCount.JcbCount;
                reportData.SafReportTotalCountRspData[6] = response.CardTotalCount.EnRouteCount;
                reportData.SafReportTotalCountRspData[7] = response.CardTotalCount.ExtendedCount;
                reportData.SafReportTotalCountRspData[8] = response.CardTotalCount.VisaFleetCount;
                reportData.SafReportTotalCountRspData[9] = response.CardTotalCount.MasterCardFleetCount;
                reportData.SafReportTotalCountRspData[10] = response.CardTotalCount.FleetOneCount;
                reportData.SafReportTotalCountRspData[11] = response.CardTotalCount.FleetwideCount;
                reportData.SafReportTotalCountRspData[12] = response.CardTotalCount.FulemanCount;
                reportData.SafReportTotalCountRspData[13] = response.CardTotalCount.GascardCount;
                reportData.SafReportTotalCountRspData[14] = response.CardTotalCount.VoyagerCount;
                reportData.SafReportTotalCountRspData[15] = response.CardTotalCount.WrightExpressCount;
                reportData.SafReportTotalCountRspData[16] = response.CardTotalCount.InteracCount;
                reportData.SafReportTotalCountRspData[17] = response.CardTotalCount.CupCount;
                reportData.SafReportTotalCountRspData[18] = response.CardTotalCount.MaestroCount;
                reportData.SafReportTotalCountRspData[19] = response.CardTotalCount.SinclairCount;

                string temp = string.Join("=", reportData.SafReportTotalCountRspData);
                reportData.SafReportRspTextData[0] = RemoveUslessSeparator(temp, "=");
            }
            if (response.CardTotalAmount != null)
            {
                reportData.SafReportTotalAmountRspData[0] = response.CardTotalAmount.VisaAmount;
                reportData.SafReportTotalAmountRspData[1] = response.CardTotalAmount.MasterCardAmount;
                reportData.SafReportTotalAmountRspData[2] = response.CardTotalAmount.AmexAmount;
                reportData.SafReportTotalAmountRspData[3] = response.CardTotalAmount.DinersAmount;
                reportData.SafReportTotalAmountRspData[4] = response.CardTotalAmount.DiscoverAmount;
                reportData.SafReportTotalAmountRspData[5] = response.CardTotalAmount.JcbAmount;
                reportData.SafReportTotalAmountRspData[6] = response.CardTotalAmount.EnRouteAmount;
                reportData.SafReportTotalAmountRspData[7] = response.CardTotalAmount.ExtendedAmount;
                reportData.SafReportTotalAmountRspData[8] = response.CardTotalAmount.VisaFleetAmount;
                reportData.SafReportTotalAmountRspData[9] = response.CardTotalAmount.MasterCardFleetAmount;
                reportData.SafReportTotalAmountRspData[10] = response.CardTotalAmount.FleetOneAmount;
                reportData.SafReportTotalAmountRspData[11] = response.CardTotalAmount.FleetwideAmount;
                reportData.SafReportTotalAmountRspData[12] = response.CardTotalAmount.FulemanAmount;
                reportData.SafReportTotalAmountRspData[13] = response.CardTotalAmount.GascardAmount;
                reportData.SafReportTotalAmountRspData[14] = response.CardTotalAmount.VoyagerAmount;
                reportData.SafReportTotalAmountRspData[15] = response.CardTotalAmount.WrightExpressAmount;
                reportData.SafReportTotalAmountRspData[16] = response.CardTotalAmount.InteracAmount;
                reportData.SafReportTotalAmountRspData[17] = response.CardTotalAmount.CupAmount;
                reportData.SafReportTotalAmountRspData[18] = response.CardTotalAmount.MaestroAmount;
                reportData.SafReportTotalAmountRspData[19] = response.CardTotalAmount.SinclairAmount;

                string temp = string.Join("=", reportData.SafReportTotalAmountRspData);
                reportData.SafReportRspTextData[1] = RemoveUslessSeparator(temp, "=");
            }
        }

        public static void GetResponse(POSLink2.Report.HostDetailReportRsp response)
        {
            ReportData reportData = ReportData.GetReportData();
            //Normal
            reportData.HostDetailReportRspNormalData[0] = response.ResponseCode;
            reportData.HostDetailReportRspNormalData[1] = response.ResponseMessage;
            reportData.HostDetailReportRspNormalData[2] = Tools.ParseEdcType(response.EdcType);
            reportData.HostDetailReportRspNormalData[3] = Tools.ParseTransType(response.TransactionType);
            reportData.HostDetailReportRspNormalData[4] = Tools.ParseTransType(response.OriginalTransactionType);
            //HostInfo
            GetHostInformation(response.HostInformation);
            //Amount
            GetAmountInformation(response.AmountInformation);
            //Account
            GetAccountInformation(response.AccountInformation);
            //Trace
            GetTraceInformation(response.TraceInformation);
            //Cashier 
            GetCashierInformation(response.CashierInformation);
            //Commercial
            GetCommercialInformation(response.CommercialInformation);
            //Check
            GetCheckInformation(response.CheckInformation);
            //TOR
            GetTorInformation(response.TorInformation);
            //AVS
            if (response.AvsInformation != null)
            {
                reportData.AvsInfoRspData[0] = response.AvsInformation.AvsApprovalCode;
                reportData.AvsInfoRspData[1] = response.AvsInformation.AvsMessage;
                reportData.AvsInfoRspData[2] = response.AvsInformation.ZipCode;
                reportData.AvsInfoRspData[3] = response.AvsInformation.Address1;
                reportData.AvsInfoRspData[4] = response.AvsInformation.Address2;
            }
            if(response.MotoECommerceInformation != null)
            {
                reportData.MotoECommerceInfoRspData[0] = response.MotoECommerceInformation.Mode;
                reportData.MotoECommerceInfoRspData[1] = response.MotoECommerceInformation.TransactionType;
                reportData.MotoECommerceInfoRspData[2] = response.MotoECommerceInformation.SecureType;
                reportData.MotoECommerceInfoRspData[3] = response.MotoECommerceInformation.OrderNumber;
                reportData.MotoECommerceInfoRspData[4] = response.MotoECommerceInformation.Installments;
                reportData.MotoECommerceInfoRspData[5] = response.MotoECommerceInformation.CurrentInstallment;
            }
        }

        private static string RemoveUslessSeparator(string message, string separator)
        {
            string des = message;
            while (true)
            {
                if (des.Length < separator.Length)
                {
                    break;
                }
                if (des.LastIndexOf(separator) == des.Length - separator.Length)
                {
                    des = des.Substring(0, des.Length - separator.Length);
                }
                else
                {
                    break;
                }
            }
            return des;
        }

        private void AddToMultipleCommandsButton_Click(object sender, EventArgs e)
        {
            _terminalData = TerminalData.GetTerminalData();
            MultipleCommandsModule multipleCommandsModule = new MultipleCommandsModule();
            switch (CommandComboBox.SelectedIndex)
            {
                case (int)ReportCommandName.LocalTotalReportReq / 2://Local Total Report
                    POSLink2.Report.LocalTotalReportReq localTotalReportReq = SetLocalTotalReportReq();
                    multipleCommandsModule.CommandName = CommandName.LocalTotalReport;
                    multipleCommandsModule.CommandReqObject = localTotalReportReq;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)ReportCommandName.LocalDetailReportReq / 2://Local Detail Report
                    POSLink2.Report.LocalDetailReportReq localDetailReportReq = SetLocalDetailReportReq();
                    multipleCommandsModule.CommandName = CommandName.LocalDetailReport;
                    multipleCommandsModule.CommandReqObject = localDetailReportReq;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)ReportCommandName.LocalFailedReportReq / 2://Local Failed Report
                    multipleCommandsModule.CommandName = CommandName.LocalFailedReport;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)ReportCommandName.HostReportReq / 2://Host Report
                    multipleCommandsModule.CommandName = CommandName.HostReport;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)ReportCommandName.HistoryReportReq / 2://History Report
                    multipleCommandsModule.CommandName = CommandName.HistoryReport;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)ReportCommandName.SAFSummaryReportReq / 2://Saf Summary Report
                    POSLink2.Report.SafSummaryReportReq safSummaryReportReq = SetSafSummaryReportReq();
                    multipleCommandsModule.CommandName = CommandName.SAFSummaryReport;
                    multipleCommandsModule.CommandReqObject = safSummaryReportReq;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)ReportCommandName.HostDetailReportReq / 2://Saf Summary Report
                    POSLink2.Report.HostDetailReportReq hostDetailReportReq = SetHostDetailReportReq();
                    multipleCommandsModule.CommandName = CommandName.HostDetailReport;
                    multipleCommandsModule.CommandReqObject = hostDetailReportReq;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                default:
                    break;
            }
        }

        private void ReportUserControl_VisibleChanged(object sender, EventArgs e)
        {
            CommandComboBox.SelectedIndex = _comboBoxIndex;
            CommandComboBox_SelectedIndexChanged(sender, e);
        }
    }
}

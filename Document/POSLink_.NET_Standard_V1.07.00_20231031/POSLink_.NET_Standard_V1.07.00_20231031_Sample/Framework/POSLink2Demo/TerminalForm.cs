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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSLink2Demo
{
    public partial class TerminalForm : Form
    {
        private POSLink2.Terminal _terminal;
        private Main _main;
        private TransactionUserControl _transactionUserControl;
        private ManageUserControl _manageUserControl;
        private FormUserControl _formUserControl;
        private DeviceUserControl _deviceUserControl;
        private FullIntegrationUserControl _fullIntegrationUserControl;
        private BatchUserControl _batchUserControl;
        private ReportUserControl _reportUserControl;
        private MultipleCommandsUserControl _multipleCommandsUserControl;
        private PedUserControl _pedUserControl;
        private PayloadUserControl _payloadUserControl;
        public TerminalForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); 
            SetStyle(ControlStyles.DoubleBuffer, true); 
            _main = new Main();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;////用双缓冲绘制窗口的所有子控件
                return cp;
            }
        }

        public POSLink2.Terminal Terminal
        {
            get {return _terminal; }
            set { _terminal = value; }
        }

        public Main MainSample
        {
            get { return _main; }
            set { _main = value; }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            if(Global.IsTransactionProcessing)
            {
                MessageBox.Show("A transaction is processing.", "Warning");
                return;
            }
            POSLink2.POSLink2 poslink = POSLink2.POSLink2.GetPOSLink2();
            poslink.RemoveTerminal(_terminal);
            _main.Show();
            this.Hide();
        }

        private void TerminalForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void TerminalForm_Load(object sender, EventArgs e)
        {
            _transactionUserControl = new TransactionUserControl();
            _manageUserControl = new ManageUserControl();
            _formUserControl = new FormUserControl();
            _deviceUserControl = new DeviceUserControl();
            _fullIntegrationUserControl = new FullIntegrationUserControl();
            _batchUserControl = new BatchUserControl();
            _reportUserControl = new ReportUserControl();
            _multipleCommandsUserControl = new MultipleCommandsUserControl();
            _pedUserControl = new PedUserControl();
            _payloadUserControl = new PayloadUserControl();

            _transactionUserControl.Visible = false;
            _manageUserControl.Visible = false;
            _formUserControl.Visible = false;
            _deviceUserControl.Visible = false;
            _fullIntegrationUserControl.Visible = false;
            _batchUserControl.Visible = false;
            _reportUserControl.Visible = false;
            _multipleCommandsUserControl.Visible = false;
            _pedUserControl.Visible = false;
            _payloadUserControl.Visible = false;

            _transactionUserControl.Dock = DockStyle.Left;
            _manageUserControl.Dock = DockStyle.Left;
            _formUserControl.Dock = DockStyle.Left;
            _deviceUserControl.Dock = DockStyle.Left;
            _fullIntegrationUserControl.Dock = DockStyle.Left;
            _batchUserControl.Dock = DockStyle.Left;
            _reportUserControl.Dock = DockStyle.Left;
            _multipleCommandsUserControl.Dock = DockStyle.Left;
            _pedUserControl.Dock = DockStyle.Left;
            _payloadUserControl.Dock = DockStyle.Left;

            panel2.Controls.Add(_transactionUserControl);
            panel2.Controls.Add(_manageUserControl);
            panel2.Controls.Add(_formUserControl);
            panel2.Controls.Add(_deviceUserControl);
            panel2.Controls.Add(_fullIntegrationUserControl);
            panel2.Controls.Add(_batchUserControl);
            panel2.Controls.Add(_reportUserControl);
            panel2.Controls.Add(_multipleCommandsUserControl);
            panel2.Controls.Add(_pedUserControl);
            panel2.Controls.Add(_payloadUserControl);

            _transactionUserControl.Location = new Point(0, 0);
            _manageUserControl.Location = new Point(0, 0);
            _formUserControl.Location = new Point(0, 0);
            _deviceUserControl.Location = new Point(0, 0);
            _fullIntegrationUserControl.Location = new Point(0, 0);
            _batchUserControl.Location = new Point(0, 0);
            _reportUserControl.Location = new Point(0, 0);
            _multipleCommandsUserControl.Location = new Point(0, 0);
            _pedUserControl.Location = new Point(0, 0);
            _payloadUserControl.Location = new Point(0, 0);

            _multipleCommandsUserControl.ResponseListBoxDoubleClick += new MultipleCommandsUserControl.DelegateEvent(MultipleCommandsShowResponse);

            _transactionUserControl.Terminal = _terminal;
            _transactionUserControl.Visible = true;
        }

        private void TransactionButton_Click(object sender, EventArgs e)
        {
            if(_transactionUserControl.Visible == false)
            {
                HideAllUserControls();
                _transactionUserControl.Terminal = _terminal;
                _transactionUserControl.Visible = true;
            }
        }

        private void BatchButton_Click(object sender, EventArgs e)
        {
            if (_batchUserControl.Visible == false)
            {
                HideAllUserControls();
                _batchUserControl.Terminal = _terminal;
                _batchUserControl.Visible = true;
            }
        }

        private void ReportButton_Click(object sender, EventArgs e)
        {
            if (_reportUserControl.Visible == false)
            {
                HideAllUserControls();
                _reportUserControl.Terminal = _terminal;
                _reportUserControl.Visible = true;
            }
        }

        private void ManageButton_Click(object sender, EventArgs e)
        {
            if (_manageUserControl.Visible == false)
            {
                HideAllUserControls();
                _manageUserControl.Terminal = _terminal;
                _manageUserControl.Visible = true;
            }
        }

        private void FormButton_Click(object sender, EventArgs e)
        {
            if (_formUserControl.Visible == false)
            {
                HideAllUserControls();
                _formUserControl.Terminal = _terminal;
                _formUserControl.Visible = true;
            }
        }

        private void DeviceButton_Click(object sender, EventArgs e)
        {
            if (_deviceUserControl.Visible == false)
            {
                HideAllUserControls();
                _deviceUserControl.Terminal = _terminal;
                _deviceUserControl.Visible = true;
            }
        }

        private void FullIntegrationButton_Click(object sender, EventArgs e)
        {
            if (_fullIntegrationUserControl.Visible == false)
            {
                HideAllUserControls();
                _fullIntegrationUserControl.Terminal = _terminal;
                _fullIntegrationUserControl.Visible = true;
            }
        }

        private void PayloadButton_Click(object sender, EventArgs e)
        {
            if (_payloadUserControl.Visible == false)
            {
                HideAllUserControls();
                _payloadUserControl.Terminal = _terminal;
                _payloadUserControl.Visible = true;
            }
        }

        private void MultipleCommandsButton_Click(object sender, EventArgs e)
        {
            if (_multipleCommandsUserControl.Visible == false)
            {
                HideAllUserControls();
                _multipleCommandsUserControl.Terminal = _terminal;
                _multipleCommandsUserControl.Visible = true;
            }
        }

        private void PedButton_Click(object sender, EventArgs e)
        {
            if (_pedUserControl.Visible == false)
            {
                HideAllUserControls();
                _pedUserControl.Terminal = _terminal;
                _pedUserControl.Visible = true;
            }
        }

        private void HideAllUserControls()
        {
            _transactionUserControl.Visible = false;
            _manageUserControl.Visible = false;
            _formUserControl.Visible = false;
            _deviceUserControl.Visible = false;
            _fullIntegrationUserControl.Visible = false;
            _batchUserControl.Visible = false;
            _reportUserControl.Visible = false;
            _multipleCommandsUserControl.Visible = false;
            _pedUserControl.Visible = false;
            _payloadUserControl.Visible = false;
        }

        private void MultipleCommandsShowResponse(object sender, EventArgs e, int index)
        {
            if(index >= (int)CommandName.DoCredit && index <= (int)CommandName.DoCheck)//Transaction
            {
                switch(index)
                {
                    case (int)CommandName.DoCredit:
                        _transactionUserControl.ComboBoxIndex = (int)TransactionCommandName.DoCredit;
                        break;
                    case (int)CommandName.DoDebit:
                        _transactionUserControl.ComboBoxIndex = (int)TransactionCommandName.DoDebit;
                        break;
                    case (int)CommandName.DoEBT:
                        _transactionUserControl.ComboBoxIndex = (int)TransactionCommandName.DoEBT;
                        break;
                    case (int)CommandName.DoGift:
                        _transactionUserControl.ComboBoxIndex = (int)TransactionCommandName.DoGift;
                        break;
                    case (int)CommandName.DoLoyalty:
                        _transactionUserControl.ComboBoxIndex = (int)TransactionCommandName.DoLoyalty;
                        break;
                    case (int)CommandName.DoCash:
                        _transactionUserControl.ComboBoxIndex = (int)TransactionCommandName.DoCash;
                        break;
                    case (int)CommandName.DoCheck:
                        _transactionUserControl.ComboBoxIndex = (int)TransactionCommandName.DoCheck;
                        break;
                    default:
                        break;
                }
                TransactionButton_Click(null, null);
            }
            else if(index >= (int)CommandName.BatchClose && index <= (int)CommandName.DeleteTransaction)//Batch
            {
                switch(index)
                {
                    case (int)CommandName.BatchClose:
                        _batchUserControl.ComboBoxIndex = (int)BatchCommandName.BatchCloseReq / 2;
                        break;
                    case (int)CommandName.ForceBatchClose:
                        _batchUserControl.ComboBoxIndex = (int)BatchCommandName.ForceBatchCloseReq / 2;
                        break;
                    case (int)CommandName.BatchClear:
                        _batchUserControl.ComboBoxIndex = (int)BatchCommandName.BatchClearReq / 2;
                        break;
                    case (int)CommandName.PurgeBatch:
                        _batchUserControl.ComboBoxIndex = (int)BatchCommandName.PurgeBatchReq / 2;
                        break;
                    case (int)CommandName.SAFUpload:
                        _batchUserControl.ComboBoxIndex = (int)BatchCommandName.SAFUploadReq / 2;
                        break;
                    case (int)CommandName.DeleteSAFFile:
                        _batchUserControl.ComboBoxIndex = (int)BatchCommandName.DeleteSAFFileReq / 2;
                        break;
                    case (int)CommandName.DeleteTransaction:
                        _batchUserControl.ComboBoxIndex = (int)BatchCommandName.DeleteTransactionReq / 2;
                        break;
                    default:
                        break;
                }
                BatchButton_Click(null, null);
            }
            else if (index >= (int)CommandName.LocalTotalReport && index <= (int)CommandName.SAFSummaryReport)//Report
            {
                switch(index)
                {
                    case (int)CommandName.LocalTotalReport:
                        _reportUserControl.ComboBoxIndex = (int)ReportCommandName.LocalTotalReportReq / 2;
                        break;
                    case (int)CommandName.LocalDetailReport:
                        _reportUserControl.ComboBoxIndex = (int)ReportCommandName.LocalDetailReportReq / 2;
                        break;
                    case (int)CommandName.LocalFailedReport:
                        _reportUserControl.ComboBoxIndex = (int)ReportCommandName.LocalFailedReportReq / 2;
                        break;
                    case (int)CommandName.HostReport:
                        _reportUserControl.ComboBoxIndex = (int)ReportCommandName.HostReportReq / 2;
                        break;
                    case (int)CommandName.HistoryReport:
                        _reportUserControl.ComboBoxIndex = (int)ReportCommandName.HistoryReportReq / 2;
                        break;
                    case (int)CommandName.SAFSummaryReport:
                        _reportUserControl.ComboBoxIndex = (int)ReportCommandName.SAFSummaryReportReq / 2;
                        break;
                    default:
                        break;
                }
                ReportButton_Click(null, null);
            }
            else if (index >= (int)CommandName.Init && index <= (int)CommandName.GetSafParameters)//Manage
            {
                switch(index)
                {
                    case (int)CommandName.Init:
                        _manageUserControl.ComboBoxIndex = (int)ManageCommandName.InitReq / 2;
                        break;
                    case (int)CommandName.GetVariable:
                        _manageUserControl.ComboBoxIndex = (int)ManageCommandName.GetVariableReq / 2;
                        break;
                    case (int)CommandName.SetVariable:
                        _manageUserControl.ComboBoxIndex = (int)ManageCommandName.SetVariableReq / 2;
                        break;
                    case (int)CommandName.GetSignature:
                        _manageUserControl.ComboBoxIndex = (int)ManageCommandName.GetSignatureReq / 2;
                        break;
                    case (int)CommandName.Reset:
                        _manageUserControl.ComboBoxIndex = (int)ManageCommandName.ResetReq / 2;
                        break;
                    case (int)CommandName.DoSignature:
                        _manageUserControl.ComboBoxIndex = (int)ManageCommandName.DoSignatureReq / 2;
                        break;
                    case (int)CommandName.DeleteImage:
                        _manageUserControl.ComboBoxIndex = (int)ManageCommandName.DeleteImageReq / 2;
                        break;
                    case (int)CommandName.Reboot:
                        _manageUserControl.ComboBoxIndex = (int)ManageCommandName.RebootReq / 2;
                        break;
                    case (int)CommandName.InputAccount:
                        _manageUserControl.ComboBoxIndex = (int)ManageCommandName.InputAccountReq / 2;
                        break;
                    case (int)CommandName.ResetMsr:
                        _manageUserControl.ComboBoxIndex = (int)ManageCommandName.ResetMsrReq / 2;
                        break;
                    case (int)CommandName.CheckFile:
                        _manageUserControl.ComboBoxIndex = (int)ManageCommandName.CheckFileReq / 2;
                        break;
                    case (int)CommandName.SetSafParameters:
                        _manageUserControl.ComboBoxIndex = (int)ManageCommandName.SetSafParametersReq / 2;
                        break;
                    case (int)CommandName.Reprint:
                        _manageUserControl.ComboBoxIndex = (int)ManageCommandName.ReprintReq / 2;
                        break;
                    case (int)CommandName.TokenAdministrative:
                        _manageUserControl.ComboBoxIndex = (int)ManageCommandName.TokenAdministrativeReq / 2;
                        break;
                    case (int)CommandName.VasSetMerchantParameters:
                        _manageUserControl.ComboBoxIndex = (int)ManageCommandName.VasSetMerchantParametersReq / 2;
                        break;
                    case (int)CommandName.VasPushData:
                        _manageUserControl.ComboBoxIndex = (int)ManageCommandName.VasPushDataReq / 2;
                        break;
                    case (int)CommandName.GetSafParameters:
                        _manageUserControl.ComboBoxIndex = (int)ManageCommandName.GetSafParametersReq / 2;
                        break;
                    default:
                        break;
                }
                ManageButton_Click(sender, e);
            }
            else if (index >= (int)CommandName.ShowDialog && index <= (int)CommandName.ShowDialogForm)//Form
            {
                switch(index)
                {
                    case (int)CommandName.ShowDialog:
                        _formUserControl.ComboBoxIndex = (int)FormCommandName.ShowDialogReq / 2;
                        break;
                    case (int)CommandName.ShowMessage:
                        _formUserControl.ComboBoxIndex = (int)FormCommandName.ShowMessageReq / 2;
                        break;
                    case (int)CommandName.ClearMessage:
                        _formUserControl.ComboBoxIndex = (int)FormCommandName.ClearMessageReq / 2;
                        break;
                    case (int)CommandName.ShowMessageCenter:
                        _formUserControl.ComboBoxIndex = (int)FormCommandName.ShowMessageCenterReq / 2;
                        break;
                    case (int)CommandName.InputText:
                        _formUserControl.ComboBoxIndex = (int)FormCommandName.InputTextReq / 2;
                        break;
                    case (int)CommandName.RemoveCard:
                        _formUserControl.ComboBoxIndex = (int)FormCommandName.RemoveCardReq / 2;
                        break;
                    case (int)CommandName.ShowTextBox:
                        _formUserControl.ComboBoxIndex = (int)FormCommandName.ShowTextBoxReq / 2;
                        break;
                    case (int)CommandName.ShowItem:
                        _formUserControl.ComboBoxIndex = (int)FormCommandName.ShowItemReq / 2;
                        break;
                    case (int)CommandName.ShowDialogForm:
                        _formUserControl.ComboBoxIndex = (int)FormCommandName.ShowDialogFormReq / 2;
                        break;
                    default:
                        break;
                }
                FormButton_Click(null, null);
            }
            else if (index >= (int)CommandName.Printer && index <= (int)CommandName.MifareCard)//Device
            {
                switch(index)
                {
                    case (int)CommandName.Printer:
                        _deviceUserControl.ComboBoxIndex = (int)DeviceCommandName.PrinterReq / 2;
                        break;
                    case (int)CommandName.CardInsertDetection:
                        _deviceUserControl.ComboBoxIndex = (int)DeviceCommandName.CardInsertDetectionReq / 2;
                        break;
                    case (int)CommandName.CameraScan:
                        _deviceUserControl.ComboBoxIndex = (int)DeviceCommandName.CameraScanReq / 2;
                        break;
                    case (int)CommandName.MifareCard:
                        _deviceUserControl.ComboBoxIndex = (int)DeviceCommandName.MifareCardReq / 2;
                        break;
                    default:
                        break;
                }
                DeviceButton_Click(null, null);
            }
            else if (index >= (int)CommandName.AuthorizeCard && index <= (int)CommandName.InputAccountWithEmv)//FullIntegration
            {
                switch(index)
                {
                    case (int)CommandName.GetPinBlock:
                        _fullIntegrationUserControl.ComboBoxIndex = (int)FullIntegrationCommandName.GetPinBlockReq / 2;
                        break;
                    case (int)CommandName.AuthorizeCard:
                        _fullIntegrationUserControl.ComboBoxIndex = (int)FullIntegrationCommandName.AuthorizeCardReq / 2;
                        break;
                    case (int)CommandName.CompleteOnlineEmv:
                        _fullIntegrationUserControl.ComboBoxIndex = (int)FullIntegrationCommandName.CompleteOnlineEmvReq / 2;
                        break;
                    case (int)CommandName.GetEmvTlvData:
                        _fullIntegrationUserControl.ComboBoxIndex = (int)FullIntegrationCommandName.GetEmvTlvDataReq / 2;
                        break;
                    case (int)CommandName.SetEmvTlvData:
                        _fullIntegrationUserControl.ComboBoxIndex = (int)FullIntegrationCommandName.SetEmvTlvDataReq / 2;
                        break;
                    case (int)CommandName.InputAccountWithEmv:
                        _fullIntegrationUserControl.ComboBoxIndex = (int)FullIntegrationCommandName.InputAccountWithEmvReq / 2;
                        break;
                    default:
                        break;
                }
                FullIntegrationButton_Click(null, null);
            }
            else if (index >= (int)CommandName.SessionKeyInjection && index <= (int)CommandName.IncreaseKsn)//Ped
            {
                switch(index)
                {
                    case (int)CommandName.SessionKeyInjection:
                        _pedUserControl.ComboBoxIndex = (int)PedCommandName.SessionKeyInjectionReq / 2;
                        break;
                    case (int)CommandName.MacCalculation:
                        _pedUserControl.ComboBoxIndex = (int)PedCommandName.MacCalculationReq / 2;
                        break;
                    case (int)CommandName.GetPedInfo:
                        _pedUserControl.ComboBoxIndex = (int)PedCommandName.GetPedInfoReq / 2;
                        break;
                    case (int)CommandName.IncreaseKsn:
                        _pedUserControl.ComboBoxIndex = (int)PedCommandName.IncreaseKsnReq / 2;
                        break;
                    default:
                        break;
                }
                PedButton_Click(null, null);
            }
        }
    }
}

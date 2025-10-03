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
    public partial class ManageUserControl : UserControl
    {
        private ManageData _manageData;
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

        public ManageUserControl()
        {
            InitializeComponent();
            _comboBoxIndex = 0;
            CommandComboBox.Items.AddRange(ManageCommon.CommandNames);
            CommandComboBox.SelectedIndex = 0;
            _manageData = ManageData.GetManageData();
            _waiting = new Waiting();
            _waiting.Dock = DockStyle.Left;
            _isCancelListening = false;
        }

        private void RunManage(int tenderType, object sender, EventArgs e)
        {
            Task task = new Task(() =>
            {
                POSLink2.ExecutionResult executionResult = new POSLink2.ExecutionResult();

                switch (tenderType)
                {
                    case (int)ManageCommandName.InitReq/2://Init
                        POSLink2.Manage.InitRsp initRsp = null;
                        executionResult = _terminal.Manage.Init(out initRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(initRsp);
                        }
                        break;
                    case (int)ManageCommandName.GetVariableReq / 2://Get Var
                        POSLink2.Manage.GetVariableReq getVariableReq = SetGetVariableReq();
                        POSLink2.Manage.GetVariableRsp getVariableRsp = null;
                        executionResult = _terminal.Manage.GetVariable(getVariableReq, out getVariableRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(getVariableRsp);
                        }
                        break;
                    case (int)ManageCommandName.SetVariableReq / 2://Set Variable
                        POSLink2.Manage.SetVariableReq setVariableReq = SetSetVariableReq();
                        POSLink2.Manage.SetVariableRsp setVariableRsp = null;
                        executionResult = _terminal.Manage.SetVariable(setVariableReq, out setVariableRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(setVariableRsp);
                        }
                        break;
                    case (int)ManageCommandName.GetSignatureReq / 2://Get Signature
                        POSLink2.Manage.GetSignatureRsp getSignatureRsp = null;
                        executionResult = _terminal.Manage.GetSignature(out getSignatureRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(getSignatureRsp);
                        }
                        break;
                    case (int)ManageCommandName.ResetReq / 2://Reset
                        POSLink2.Manage.ResetRsp resetRsp = null;
                        executionResult = _terminal.Manage.Reset(out resetRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(resetRsp);
                        }
                        break;
                    case (int)ManageCommandName.UpdateResourceFileReq / 2://Update Resource File
                        POSLink2.Manage.UpdateResourceFileReq updateResourceFileReq = SetUpdateResourceFileReq();
                        POSLink2.Manage.UpdateResourceFileRsp updateResourceFileRsp = null;
                        executionResult = _terminal.Manage.UpdateResourceFile(updateResourceFileReq, out updateResourceFileRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(updateResourceFileRsp);
                        }
                        break;
                    case (int)ManageCommandName.DoSignatureReq / 2://DoSignature
                        POSLink2.Manage.DoSignatureReq doSignatureReq = SetDoSignatureReq();
                        POSLink2.Manage.DoSignatureRsp doSignatureRsp = null;
                        executionResult = _terminal.Manage.DoSignature(doSignatureReq, out doSignatureRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(doSignatureRsp);
                        }
                        break;
                    case (int)ManageCommandName.DeleteImageReq / 2:// Delete Image
                        POSLink2.Manage.DeleteImageReq deleteImageReq = SetDeleteImageReq();
                        POSLink2.Manage.DeleteImageRsp deleteImageRsp = null;
                        executionResult = _terminal.Manage.DeleteImage(deleteImageReq, out deleteImageRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(deleteImageRsp);
                        }
                        break;
                    case (int)ManageCommandName.RebootReq / 2:// Reboot
                        POSLink2.Manage.RebootRsp rebootRsp = null;
                        executionResult = _terminal.Manage.Reboot(out rebootRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(rebootRsp);
                        }
                        break;
                    case (int)ManageCommandName.InputAccountReq / 2://Input Account
                        POSLink2.Manage.InputAccountReq inputAccountReq = SetInputAccountReq();
                        POSLink2.Manage.InputAccountRsp inputAccountRsp = null;
                        executionResult = _terminal.Manage.InputAccount(inputAccountReq, out inputAccountRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(inputAccountRsp);
                        }
                        break;
                    case (int)ManageCommandName.ResetMsrReq / 2://Reset MSR
                        POSLink2.Manage.ResetMsrRsp resetMsrRsp = null;
                        executionResult = _terminal.Manage.ResetMsr(out resetMsrRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(resetMsrRsp);
                        }
                        break;
                    case (int)ManageCommandName.CheckFileReq / 2://Check File
                        POSLink2.Manage.CheckFileReq checkFileReq = SetCheckFileReq();
                        POSLink2.Manage.CheckFileRsp checkFileRsp = null;
                        executionResult = _terminal.Manage.CheckFile(checkFileReq, out checkFileRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(checkFileRsp);
                        }
                        break;
                    case (int)ManageCommandName.SetSafParametersReq / 2://Set SAF Parameters
                        POSLink2.Manage.SetSafParametersReq setSafParametersReq = SetSetSafParametersReq();
                        POSLink2.Manage.SetSafParametersRsp setSafParametersRsp = null;
                        executionResult = _terminal.Manage.SetSafParameters(setSafParametersReq, out setSafParametersRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(setSafParametersRsp);
                        }
                        break;
                    case (int)ManageCommandName.ReprintReq / 2://Reprint
                        POSLink2.Manage.ReprintReq reprintReq = SetReprintReq();
                        POSLink2.Manage.ReprintRsp reprintRsp = null;
                        executionResult = _terminal.Manage.Reprint(reprintReq, out reprintRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(reprintRsp);
                        }
                        break;
                    case (int)ManageCommandName.TokenAdministrativeReq / 2://Token Administrative
                        POSLink2.Manage.TokenAdministrativeReq tokenAdministrativeReq = SetTokenAdministrativeReq();
                        POSLink2.Manage.TokenAdministrativeRsp tokenAdministrativeRsp = null;
                        executionResult = _terminal.Manage.TokenAdministrative(tokenAdministrativeReq, out tokenAdministrativeRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(tokenAdministrativeRsp);
                        }
                        break;
                    case (int)ManageCommandName.VasSetMerchantParametersReq / 2://VAS Set Merchant Parameters
                        POSLink2.Manage.VasSetMerchantParametersReq vasSetMerchantParametersReq = SetVasSetMerchantParametersReq();
                        POSLink2.Manage.VasSetMerchantParametersRsp vasSetMerchantParametersRsp = null;
                        executionResult = _terminal.Manage.VasSetMerchantParameters(vasSetMerchantParametersReq, out vasSetMerchantParametersRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(vasSetMerchantParametersRsp);
                        }
                        break;
                    case (int)ManageCommandName.VasPushDataReq / 2://VAS Push Data
                        POSLink2.Manage.VasPushDataReq vasPushDataReq = SetVasPushDataReq();
                        POSLink2.Manage.VasPushDataRsp vasPushDataRsp = null;
                        executionResult = _terminal.Manage.VasPushData(vasPushDataReq, out vasPushDataRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(vasPushDataRsp);
                        }
                        break;
                    case (int)ManageCommandName.GetSafParametersReq / 2://Get SAF Parameters
                        POSLink2.Manage.GetSafParametersRsp getSafParametersRsp = null;
                        executionResult = _terminal.Manage.GetSafParameters(out getSafParametersRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(getSafParametersRsp);
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
                    else if(executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.PackRequestError)
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
            _manageData.ResponseClear();
            _waiting.Location = new Point(0, 0);
            _waiting.IsCancelAvaliable = true;
            this.Controls.Add(_waiting);
            _waiting.BringToFront();
            _waiting.Show();

            int tenderType = CommandComboBox.SelectedIndex;
            RunManage(tenderType, sender, e);
            _isCancelListening = true;
            RunListener();
        }

        private void CommandComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(panel1);
            _comboBoxIndex = CommandComboBox.SelectedIndex;
            if (CommandComboBox.SelectedIndex == (int)ManageCommandName.InitReq/2)//Init
            {
                ManageOnePanelUserControl initReqUserControl = new ManageOnePanelUserControl();
                initReqUserControl.CommandName = ManageCommandName.InitReq;
                initReqUserControl.Dock = DockStyle.Left;
                

                ManageOnePanelUserControl initRspUserControl = new ManageOnePanelUserControl();
                initRspUserControl.CommandName = ManageCommandName.InitRsp;
                initRspUserControl.Dock = DockStyle.Left;
                

                panel1.Controls.Add(initReqUserControl);
                panel1.Controls.Add(initRspUserControl);
                initReqUserControl.SendToBack();
                initReqUserControl.ShowPanel(sender, e);
                initRspUserControl.ShowPanel(sender, e);
            }
            else if(CommandComboBox.SelectedIndex == (int)ManageCommandName.GetVariableReq/2)//Get Var
            {
                ManageTwoPanelsUserControl getVariableReqUserControl = new ManageTwoPanelsUserControl();
                getVariableReqUserControl.CommandName = ManageCommandName.GetVariableReq;
                getVariableReqUserControl.Dock = DockStyle.Left;
                getVariableReqUserControl.ShowButton(sender, e);
                panel1.Controls.Add(getVariableReqUserControl);

                ManageTwoPanelsUserControl getVariableRspUserControl = new ManageTwoPanelsUserControl();
                getVariableRspUserControl.CommandName = ManageCommandName.GetVariableRsp;
                getVariableRspUserControl.Dock = DockStyle.Left;
                getVariableRspUserControl.ShowButton(sender, e);
                panel1.Controls.Add(getVariableRspUserControl);

                getVariableReqUserControl.SendToBack();
            }
            else if(CommandComboBox.SelectedIndex == (int)ManageCommandName.SetVariableReq / 2)//Set Variable
            {
                ManageTwoPanelsUserControl setVariableReqUserControl = new ManageTwoPanelsUserControl();
                setVariableReqUserControl.CommandName = ManageCommandName.SetVariableReq;
                setVariableReqUserControl.Dock = DockStyle.Left;
                setVariableReqUserControl.ShowButton(sender, e);
                panel1.Controls.Add(setVariableReqUserControl);

                ManageTwoPanelsUserControl setVariableRspUserControl = new ManageTwoPanelsUserControl();
                setVariableRspUserControl.CommandName = ManageCommandName.SetVariableRsp;
                setVariableRspUserControl.Dock = DockStyle.Left;
                setVariableRspUserControl.ShowButton(sender, e);
                panel1.Controls.Add(setVariableRspUserControl);

                setVariableReqUserControl.SendToBack();
            }
            else if(CommandComboBox.SelectedIndex == (int)ManageCommandName.GetSignatureReq / 2)//Get Signature
            {
                ManageOnePanelUserControl getSignatureReqUserControl = new ManageOnePanelUserControl();
                getSignatureReqUserControl.CommandName = ManageCommandName.GetSignatureReq;
                getSignatureReqUserControl.Dock = DockStyle.Left;
                getSignatureReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(getSignatureReqUserControl);

                ManageOnePanelUserControl getSignatureRspUserControl = new ManageOnePanelUserControl();
                getSignatureRspUserControl.CommandName = ManageCommandName.GetSignatureRsp;
                getSignatureRspUserControl.Dock = DockStyle.Left;
                getSignatureRspUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(getSignatureRspUserControl);

                getSignatureReqUserControl.SendToBack();
            }
            else if(CommandComboBox.SelectedIndex == (int)ManageCommandName.ResetReq / 2)//Reset
            {
                ManageOnePanelUserControl ResetReqUserControl = new ManageOnePanelUserControl();
                ResetReqUserControl.CommandName = ManageCommandName.ResetReq;
                ResetReqUserControl.Dock = DockStyle.Left;
                ResetReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(ResetReqUserControl);

                ManageOnePanelUserControl ResetRspUserControl = new ManageOnePanelUserControl();
                ResetRspUserControl.CommandName = ManageCommandName.ResetRsp;
                ResetRspUserControl.Dock = DockStyle.Left;
                ResetRspUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(ResetRspUserControl);

                ResetReqUserControl.SendToBack();
            }
            else if(CommandComboBox.SelectedIndex == (int)ManageCommandName.UpdateResourceFileReq / 2)//Update Resource File
            {
                ManageOnePanelUserControl updateResourceFileReqUserControl = new ManageOnePanelUserControl();
                updateResourceFileReqUserControl.CommandName = ManageCommandName.UpdateResourceFileReq;
                updateResourceFileReqUserControl.Dock = DockStyle.Left;
                updateResourceFileReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(updateResourceFileReqUserControl);

                ManageOnePanelUserControl updateResourceFileRspUserControl = new ManageOnePanelUserControl();
                updateResourceFileRspUserControl.CommandName = ManageCommandName.UpdateResourceFileRsp;
                updateResourceFileRspUserControl.Dock = DockStyle.Left;
                updateResourceFileRspUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(updateResourceFileRspUserControl);

                updateResourceFileReqUserControl.SendToBack();
            }
            else if(CommandComboBox.SelectedIndex == (int)ManageCommandName.DoSignatureReq / 2)//DoSignature
            {
                ManageOnePanelUserControl doSignatureReqUserControl = new ManageOnePanelUserControl();
                doSignatureReqUserControl.CommandName = ManageCommandName.DoSignatureReq;
                doSignatureReqUserControl.Dock = DockStyle.Left;
                doSignatureReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(doSignatureReqUserControl);

                ManageOnePanelUserControl doSignatureRspUserControl = new ManageOnePanelUserControl();
                doSignatureRspUserControl.CommandName = ManageCommandName.DoSignatureRsp;
                doSignatureRspUserControl.Dock = DockStyle.Left;
                doSignatureRspUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(doSignatureRspUserControl);

                doSignatureReqUserControl.SendToBack();
            }
            else if(CommandComboBox.SelectedIndex == (int)ManageCommandName.DeleteImageReq / 2)// Delete Image
            {
                ManageOnePanelUserControl deleteImageReqUserControl = new ManageOnePanelUserControl();
                deleteImageReqUserControl.CommandName = ManageCommandName.DeleteImageReq;
                deleteImageReqUserControl.Dock = DockStyle.Left;
                deleteImageReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(deleteImageReqUserControl);

                ManageOnePanelUserControl deleteImageRspUserControl = new ManageOnePanelUserControl();
                deleteImageRspUserControl.CommandName = ManageCommandName.DeleteImageRsp;
                deleteImageRspUserControl.Dock = DockStyle.Left;
                deleteImageRspUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(deleteImageRspUserControl);

                deleteImageReqUserControl.SendToBack();
            }
            else if (CommandComboBox.SelectedIndex == (int)ManageCommandName.RebootReq / 2)// Reboot
            {
                ManageOnePanelUserControl rebootReqUserControl = new ManageOnePanelUserControl();
                rebootReqUserControl.CommandName = ManageCommandName.RebootReq;
                rebootReqUserControl.Dock = DockStyle.Left;
                rebootReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(rebootReqUserControl);

                ManageOnePanelUserControl rebootRspUserControl = new ManageOnePanelUserControl();
                rebootRspUserControl.CommandName = ManageCommandName.RebootRsp;
                rebootRspUserControl.Dock = DockStyle.Left;
                rebootRspUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(rebootRspUserControl);

                rebootReqUserControl.SendToBack();
            }
            else if(CommandComboBox.SelectedIndex == (int)ManageCommandName.InputAccountReq / 2)//Input Account
            {
                ManageOnePanelUserControl inputAccountReqUserControl = new ManageOnePanelUserControl();
                inputAccountReqUserControl.CommandName = ManageCommandName.InputAccountReq;
                inputAccountReqUserControl.Dock = DockStyle.Left;
                inputAccountReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(inputAccountReqUserControl);

                ManageOnePanelUserControl inputAccountRspUserControl = new ManageOnePanelUserControl();
                inputAccountRspUserControl.CommandName = ManageCommandName.InputAccountRsp;
                inputAccountRspUserControl.Dock = DockStyle.Left;
                inputAccountRspUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(inputAccountRspUserControl);

                inputAccountReqUserControl.SendToBack();
            }
            else if(CommandComboBox.SelectedIndex == (int)ManageCommandName.ResetMsrReq / 2)//Reset MSR
            {
                ManageOnePanelUserControl resetMsrReqUserControl = new ManageOnePanelUserControl();
                resetMsrReqUserControl.CommandName = ManageCommandName.ResetMsrReq;
                resetMsrReqUserControl.Dock = DockStyle.Left;
                resetMsrReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(resetMsrReqUserControl);

                ManageOnePanelUserControl resetMsrRspUserControl = new ManageOnePanelUserControl();
                resetMsrRspUserControl.CommandName = ManageCommandName.ResetMsrRsp;
                resetMsrRspUserControl.Dock = DockStyle.Left;
                resetMsrRspUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(resetMsrRspUserControl);

                resetMsrReqUserControl.SendToBack();
            }
            else if(CommandComboBox.SelectedIndex == (int)ManageCommandName.CheckFileReq / 2)//Check File
            {
                ManageOnePanelUserControl checkFileReqUserControl = new ManageOnePanelUserControl();
                checkFileReqUserControl.CommandName = ManageCommandName.CheckFileReq;
                checkFileReqUserControl.Dock = DockStyle.Left;
                checkFileReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(checkFileReqUserControl);

                ManageOnePanelUserControl checkFileRspUserControl = new ManageOnePanelUserControl();
                checkFileRspUserControl.CommandName = ManageCommandName.CheckFileRsp;
                checkFileRspUserControl.Dock = DockStyle.Left;
                checkFileRspUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(checkFileRspUserControl);

                checkFileReqUserControl.SendToBack();
            }
            else if(CommandComboBox.SelectedIndex == (int)ManageCommandName.SetSafParametersReq / 2)//Set SAF Parameters
            {
                ManageOnePanelUserControl setSafParametersReqUserControl = new ManageOnePanelUserControl();
                setSafParametersReqUserControl.CommandName = ManageCommandName.SetSafParametersReq;
                setSafParametersReqUserControl.Dock = DockStyle.Left;
                setSafParametersReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(setSafParametersReqUserControl);

                ManageOnePanelUserControl setSafParametersRspUserControl = new ManageOnePanelUserControl();
                setSafParametersRspUserControl.CommandName = ManageCommandName.SetSafParametersRsp;
                setSafParametersRspUserControl.Dock = DockStyle.Left;
                setSafParametersRspUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(setSafParametersRspUserControl);

                setSafParametersReqUserControl.SendToBack();
            }
            else if(CommandComboBox.SelectedIndex == (int)ManageCommandName.ReprintReq / 2)//Reprint
            {
                ManageOnePanelUserControl reprintReqUserControl = new ManageOnePanelUserControl();
                reprintReqUserControl.CommandName = ManageCommandName.ReprintReq;
                reprintReqUserControl.Dock = DockStyle.Left;
                reprintReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(reprintReqUserControl);

                ManageOnePanelUserControl reprintRspUserControl = new ManageOnePanelUserControl();
                reprintRspUserControl.CommandName = ManageCommandName.ReprintRsp;
                reprintRspUserControl.Dock = DockStyle.Left;
                reprintRspUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(reprintRspUserControl);

                reprintReqUserControl.SendToBack();
            }
            else if(CommandComboBox.SelectedIndex == (int)ManageCommandName.TokenAdministrativeReq / 2)//Token Administrative
            {
                ManageOnePanelUserControl tokenAdministrativeReqUserControl = new ManageOnePanelUserControl();
                tokenAdministrativeReqUserControl.CommandName = ManageCommandName.TokenAdministrativeReq;
                tokenAdministrativeReqUserControl.Dock = DockStyle.Left;
                tokenAdministrativeReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(tokenAdministrativeReqUserControl);

                ManageOnePanelUserControl tokenAdministrativeRspUserControl = new ManageOnePanelUserControl();
                tokenAdministrativeRspUserControl.CommandName = ManageCommandName.TokenAdministrativeRsp;
                tokenAdministrativeRspUserControl.Dock = DockStyle.Left;
                tokenAdministrativeRspUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(tokenAdministrativeRspUserControl);

                tokenAdministrativeReqUserControl.SendToBack();
            }
            else if(CommandComboBox.SelectedIndex == (int)ManageCommandName.VasSetMerchantParametersReq / 2)//VAS Set Merchant Parameters
            {
                ManageOnePanelUserControl vasSetMerchantParametersReqUserControl = new ManageOnePanelUserControl();
                vasSetMerchantParametersReqUserControl.CommandName = ManageCommandName.VasSetMerchantParametersReq;
                vasSetMerchantParametersReqUserControl.Dock = DockStyle.Left;
                vasSetMerchantParametersReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(vasSetMerchantParametersReqUserControl);

                ManageOnePanelUserControl vasSetMerchantParametersRspUserControl = new ManageOnePanelUserControl();
                vasSetMerchantParametersRspUserControl.CommandName = ManageCommandName.VasSetMerchantParametersRsp;
                vasSetMerchantParametersRspUserControl.Dock = DockStyle.Left;
                vasSetMerchantParametersRspUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(vasSetMerchantParametersRspUserControl);

                vasSetMerchantParametersReqUserControl.SendToBack();
            }
            else if(CommandComboBox.SelectedIndex == (int)ManageCommandName.VasPushDataReq / 2)//VAS Push Data
            {
                ManageOnePanelUserControl vasPushDataReqUserControl = new ManageOnePanelUserControl();
                vasPushDataReqUserControl.CommandName = ManageCommandName.VasPushDataReq;
                vasPushDataReqUserControl.Dock = DockStyle.Left;
                vasPushDataReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(vasPushDataReqUserControl);

                ManageOnePanelUserControl vasPushDataRspUserControl = new ManageOnePanelUserControl();
                vasPushDataRspUserControl.CommandName = ManageCommandName.VasPushDataRsp;
                vasPushDataRspUserControl.Dock = DockStyle.Left;
                vasPushDataRspUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(vasPushDataRspUserControl);

                vasPushDataReqUserControl.SendToBack();
            }
            else if(CommandComboBox.SelectedIndex == (int)ManageCommandName.GetSafParametersReq / 2)//Get SAF Parameters
            {
                ManageOnePanelUserControl getSafParametersReqUserControl = new ManageOnePanelUserControl();
                getSafParametersReqUserControl.CommandName = ManageCommandName.GetSafParametersReq;
                getSafParametersReqUserControl.Dock = DockStyle.Left;
                getSafParametersReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(getSafParametersReqUserControl);

                ManageOnePanelUserControl getSafParametersRspUserControl = new ManageOnePanelUserControl();
                getSafParametersRspUserControl.CommandName = ManageCommandName.GetSafParametersRsp;
                getSafParametersRspUserControl.Dock = DockStyle.Left;
                getSafParametersRspUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(getSafParametersRspUserControl);

                getSafParametersReqUserControl.SendToBack();
            }
        }

        private POSLink2.Manage.GetVariableReq SetGetVariableReq()
        {
            POSLink2.Manage.GetVariableReq request = new POSLink2.Manage.GetVariableReq();
            request.EdcType = (POSLink2.Const.EdcType)Global.EdcType[_manageData.EdcTypeIndex, 1];
            request.VariableName1 = _manageData.GetVariableReqNormalData[0];
            request.VariableName2 = _manageData.GetVariableReqNormalData[1];
            request.VariableName3 = _manageData.GetVariableReqNormalData[2];
            request.VariableName4 = _manageData.GetVariableReqNormalData[3];
            request.VariableName5 = _manageData.GetVariableReqNormalData[4];

            POSLink2.Util.MultiMerchant multiMerchant = new POSLink2.Util.MultiMerchant();
            multiMerchant.Id = _manageData.MultiMerchantReqData[0];
            multiMerchant.Name = _manageData.MultiMerchantReqData[1];
            request.MultiMerchant = multiMerchant;
            return request;
        }

        private POSLink2.Manage.SetVariableReq SetSetVariableReq()
        {
            POSLink2.Manage.SetVariableReq request = new POSLink2.Manage.SetVariableReq();
            request.EdcType = (POSLink2.Const.EdcType)Global.EdcType[_manageData.EdcTypeIndex, 1];
            request.VariableName1 = _manageData.SetVariableReqNormalData[0];
            request.VariableValue1 = _manageData.SetVariableReqNormalData[1];
            request.VariableName2 = _manageData.SetVariableReqNormalData[2];
            request.VariableValue2 = _manageData.SetVariableReqNormalData[3];
            request.VariableName3 = _manageData.SetVariableReqNormalData[4];
            request.VariableValue3 = _manageData.SetVariableReqNormalData[5];
            request.VariableName4 = _manageData.SetVariableReqNormalData[6];
            request.VariableValue4 = _manageData.SetVariableReqNormalData[7];
            request.VariableName5 = _manageData.SetVariableReqNormalData[8];
            request.VariableValue5 = _manageData.SetVariableReqNormalData[9];

            POSLink2.Util.MultiMerchant multiMerchant2 = new POSLink2.Util.MultiMerchant();
            multiMerchant2.Id = _manageData.MultiMerchantReqData[0];
            multiMerchant2.Name = _manageData.MultiMerchantReqData[1];
            request.MultiMerchant = multiMerchant2;
            return request;
        }

        private POSLink2.Manage.UpdateResourceFileReq SetUpdateResourceFileReq()
        {
            POSLink2.Manage.UpdateResourceFileReq request = new POSLink2.Manage.UpdateResourceFileReq();
            request.FileType = (POSLink2.Const.FileType)Global.FileType[_manageData.FileTypeIndex, 1];
            request.FileUrl = _manageData.UpdateResourceFileReqNormalData[0];
            request.TargetDevice = _manageData.UpdateResourceFileReqNormalData[1];
            return request;
        }

        private POSLink2.Manage.DeleteImageReq SetDeleteImageReq()
        {
            POSLink2.Manage.DeleteImageReq request = new POSLink2.Manage.DeleteImageReq();
            request.ImageName = _manageData.DeleteImageReqNormalData[0];
            return request;
        }

        private POSLink2.Manage.DoSignatureReq SetDoSignatureReq()
        {
            POSLink2.Manage.DoSignatureReq request = new POSLink2.Manage.DoSignatureReq();
            request.EdcType = (POSLink2.Const.EdcType)Global.EdcType[_manageData.EdcTypeIndex, 1];
            request.UploadFlag = _manageData.DoSignatureReqNormalData[0];
            request.HRefNum = _manageData.DoSignatureReqNormalData[1];
            request.Timeout = _manageData.DoSignatureReqNormalData[2];
            request.ContinuousScreen = _manageData.DoSignatureReqNormalData[3];
            return request;
        }

        private POSLink2.Manage.InputAccountReq SetInputAccountReq()
        {
            POSLink2.Manage.InputAccountReq request = new POSLink2.Manage.InputAccountReq();
            request.EdcType = (POSLink2.Const.EdcType)Global.EdcType[_manageData.EdcTypeIndex, 1];
            request.TransactionType = (POSLink2.Const.TransType)Global.TransType[_manageData.TransactionTypeIndex, 1];
            request.MagneticSwipeEntryFlag = _manageData.InputAccountReqNormalData[0];
            request.ManualEntryFlag = _manageData.InputAccountReqNormalData[1];
            request.ContactlessEntryFlag = _manageData.InputAccountReqNormalData[2];
            request.ScannerEntryFlag = _manageData.InputAccountReqNormalData[3];
            request.ExpiryDatePrompt = _manageData.InputAccountReqNormalData[4];
            request.Timeout = _manageData.InputAccountReqNormalData[5];
            request.EncryptionFlag = _manageData.InputAccountReqNormalData[6];
            request.KeySlot = _manageData.InputAccountReqNormalData[7];
            request.MinAccountLength = _manageData.InputAccountReqNormalData[8];
            request.MaxAccountLength = _manageData.InputAccountReqNormalData[9];
            request.ContinuousScreen = _manageData.InputAccountReqNormalData[10];
            return request;
        }

        private POSLink2.Manage.CheckFileReq SetCheckFileReq()
        {
            POSLink2.Manage.CheckFileReq request = new POSLink2.Manage.CheckFileReq();
            request.FileName = _manageData.CheckFileReqNormalData[0];
            return request;
        }

        private POSLink2.Manage.SetSafParametersReq SetSetSafParametersReq()
        {
            POSLink2.Manage.SetSafParametersReq request = new POSLink2.Manage.SetSafParametersReq();
            request.SafMode = _manageData.SetSafParametersReqNormalData[0];
            request.StartDateTime = _manageData.SetSafParametersReqNormalData[1];
            request.EndDateTime = _manageData.SetSafParametersReqNormalData[2];
            request.DurationInDays = _manageData.SetSafParametersReqNormalData[3];
            request.MaxNumber = _manageData.SetSafParametersReqNormalData[4];
            request.TotalCeilingAmount = _manageData.SetSafParametersReqNormalData[5];
            request.CeilingAmountPerCardType = _manageData.SetSafParametersReqNormalData[6];
            request.HaloPerCardType = _manageData.SetSafParametersReqNormalData[7];
            request.UploadMode = _manageData.SetSafParametersReqNormalData[8];
            request.AutoUploadIntervalTime = _manageData.SetSafParametersReqNormalData[9];
            request.DeleteSAFConfirmation = _manageData.SetSafParametersReqNormalData[10];
            return request;
        }

        private POSLink2.Manage.ReprintReq SetReprintReq()
        {
            POSLink2.Manage.ReprintReq request = new POSLink2.Manage.ReprintReq();
            request.EdcType = (POSLink2.Const.EdcType)Global.EdcType[_manageData.EdcTypeIndex, 1];
            request.PrintLastReceipt = _manageData.ReprintReqNormalData[0];
            request.OrigRefNum = _manageData.ReprintReqNormalData[1];
            request.AuthCode = _manageData.ReprintReqNormalData[2];
            request.EcrRefNum = _manageData.ReprintReqNormalData[3];
            return request;
        }

        private POSLink2.Manage.TokenAdministrativeReq SetTokenAdministrativeReq()
        {
            POSLink2.Manage.TokenAdministrativeReq request = new POSLink2.Manage.TokenAdministrativeReq();
            request.EdcType = (POSLink2.Const.EdcType)Global.EdcType[_manageData.EdcTypeIndex, 1];
            request.TokenCommand = _manageData.TokenAdministrativeReqNormalData[0];
            request.Token = _manageData.TokenAdministrativeReqNormalData[1];
            request.TokenSN = _manageData.TokenAdministrativeReqNormalData[2];
            request.ExpiryDate = _manageData.TokenAdministrativeReqNormalData[3];
            return request;
        }

        private POSLink2.Manage.VasSetMerchantParametersReq SetVasSetMerchantParametersReq()
        {
            POSLink2.Manage.VasSetMerchantParametersReq request = new POSLink2.Manage.VasSetMerchantParametersReq();
            request.VasProgram = (_manageData.VasProgramIndex + 1).ToString();
            request.VasMode = _manageData.VasModeIndex.ToString();
            if (request.VasProgram == "1")
            {
                POSLink2.Manage.ApplePayVas applePayVas = new POSLink2.Manage.ApplePayVas();
                applePayVas.MerchantId = _manageData.ApplePayVasReqNormalData[0];
                applePayVas.UrlMode = _manageData.ApplePayVasReqNormalData[1];
                applePayVas.Url = _manageData.ApplePayVasReqNormalData[2];
                request.VasSpecificData = applePayVas;
            }
            else if (request.VasProgram == "2")
            {
                POSLink2.Manage.GoogleSmartTap googleSmartTap = new POSLink2.Manage.GoogleSmartTap();
                googleSmartTap.Security = _manageData.SecurityIndex.ToString();
                googleSmartTap.GoogleSmartTapCap = _manageData.GoogleSmartTapReqNormalButtonTextBoxData[0];
                googleSmartTap.CollectId = _manageData.GoogleSmartTapReqNormalData[0];
                googleSmartTap.StoreLocalId = _manageData.GoogleSmartTapReqNormalData[1];
                googleSmartTap.TerminalId = _manageData.GoogleSmartTapReqNormalData[2];
                googleSmartTap.MerchantName = _manageData.GoogleSmartTapReqNormalData[3];
                googleSmartTap.MerchantCategory = _manageData.GoogleSmartTapReqNormalData[4];
                googleSmartTap.EndTap = _manageData.GoogleSmartTapReqNormalData[5];
                googleSmartTap.OseToPpse = _manageData.GoogleSmartTapReqNormalData[6];
                googleSmartTap.ServiceType = ParseServiceType(_manageData.ServiceTypeItemListData);
                request.VasSpecificData = googleSmartTap;
            }
            return request;
        }

        private POSLink2.Manage.VasPushDataReq SetVasPushDataReq()
        {
            POSLink2.Manage.VasPushDataReq request = new POSLink2.Manage.VasPushDataReq();
            request.VasMode = _manageData.VasModeIndex.ToString();
            POSLink2.Manage.GoogleSmartTapPushService googleSmartTapPushService = new POSLink2.Manage.GoogleSmartTapPushService();
            googleSmartTapPushService.Security = _manageData.SecurityIndex.ToString();
            googleSmartTapPushService.CollectId = _manageData.VasPushDataReqNormalData[0];
            googleSmartTapPushService.EndTap = _manageData.VasPushDataReqNormalData[1];
            googleSmartTapPushService.GoogleSmartTapCap = _manageData.VasPushDataReqNormalButtonTextBoxData[0];
            googleSmartTapPushService.ServiceUsage = _manageData.ServiceUsageReqData;
            googleSmartTapPushService.ServiceUpdate = _manageData.ServiceUpdateReqData;
            googleSmartTapPushService.NewService = _manageData.NewServiceReqData;
            request.GoogleSmartTapPushService = googleSmartTapPushService;
            return request;
        }

        public static void GetResponse(POSLink2.Manage.InitRsp response)
        {
            ManageData manageData = ManageData.GetManageData();
            //Normal
            manageData.InitRspNormalData[0] = response.ResponseCode;
            manageData.InitRspNormalData[1] = response.ResponseMessage;
            manageData.InitRspNormalData[2] = response.Sn;
            manageData.InitRspNormalData[3] = response.ModelName;
            manageData.InitRspNormalData[4] = response.OsVersion;
            manageData.InitRspNormalData[5] = response.MacAddress;
            manageData.InitRspNormalData[6] = response.LinesPerScreen;
            manageData.InitRspNormalData[7] = response.CharsPerLine;
            manageData.InitRspNormalData[8] = response.AppName;
            manageData.InitRspNormalData[9] = response.AppVersion;
            manageData.InitRspNormalData[10] = response.WifiMac;
            manageData.InitRspNormalData[11] = response.Touchscreen;
            manageData.HardwareConfigurationBitmap = response.HardwareConfigurationBitmap;
        }

        public static void GetResponse(POSLink2.Manage.GetVariableRsp response)
        {
            ManageData manageData = ManageData.GetManageData();
            //Normal
            manageData.GetVariableRspNormalData[0] = response.ResponseCode;
            manageData.GetVariableRspNormalData[1] = response.ResponseMessage;
            manageData.GetVariableRspNormalData[2] = response.VariableValue1;
            manageData.GetVariableRspNormalData[3] = response.VariableValue2;
            manageData.GetVariableRspNormalData[4] = response.VariableValue3;
            manageData.GetVariableRspNormalData[5] = response.VariableValue4;
            manageData.GetVariableRspNormalData[6] = response.VariableValue5;
            //MultiMerchant
            manageData.MultiMerchantRspData[0] = response.MultiMerchant.Id;
            manageData.MultiMerchantRspData[1] = response.MultiMerchant.Name;
        }

        public static void GetResponse(POSLink2.Manage.SetVariableRsp response)
        {
            ManageData manageData = ManageData.GetManageData();
            //Normal
            manageData.SetVariableRspNormalData[0] = response.ResponseCode;
            manageData.SetVariableRspNormalData[1] = response.ResponseMessage;
            //MultiMerchant
            manageData.MultiMerchantRspData[0] = response.MultiMerchant.Id;
            manageData.MultiMerchantRspData[1] = response.MultiMerchant.Name;
        }

        public static void GetResponse(POSLink2.Manage.GetSignatureRsp response)
        {
            ManageData manageData = ManageData.GetManageData();
            //Normal
            manageData.GetSignatureRspNormalData[0] = response.ResponseCode;
            manageData.GetSignatureRspNormalData[1] = response.ResponseMessage;
            manageData.GetSignatureRspNormalData[2] = response.SignatureData;
            manageData.SignatureData = response.SignatureData;
        }

        public static void GetResponse(POSLink2.Manage.ResetRsp response)
        {
            ManageData manageData = ManageData.GetManageData();
            //Normal
            manageData.ResetRspNormalData[0] = response.ResponseCode;
            manageData.ResetRspNormalData[1] = response.ResponseMessage;
        }

        public static void GetResponse(POSLink2.Manage.UpdateResourceFileRsp response)
        {
            ManageData manageData = ManageData.GetManageData();
            //Normal
            manageData.UpdateResourceFileRspNormalData[0] = response.ResponseCode;
            manageData.UpdateResourceFileRspNormalData[1] = response.ResponseMessage;
        }

        public static void GetResponse(POSLink2.Manage.DoSignatureRsp response)
        {
            ManageData manageData = ManageData.GetManageData();
            //Normal
            manageData.DoSignatureRspNormalData[0] = response.ResponseCode;
            manageData.DoSignatureRspNormalData[1] = response.ResponseMessage;
        }

        public static void GetResponse(POSLink2.Manage.DeleteImageRsp response)
        {
            ManageData manageData = ManageData.GetManageData();
            //Normal
            manageData.DeleteImageRspNormalData[0] = response.ResponseCode;
            manageData.DeleteImageRspNormalData[1] = response.ResponseMessage;
        }

        public static void GetResponse(POSLink2.Manage.RebootRsp response)
        {
            ManageData manageData = ManageData.GetManageData();
            //Normal
            manageData.RebootRspNormalData[0] = response.ResponseCode;
            manageData.RebootRspNormalData[1] = response.ResponseMessage;
        }

        public static void GetResponse(POSLink2.Manage.InputAccountRsp response)
        {
            ManageData manageData = ManageData.GetManageData();
            //Normal
            manageData.InputAccountRspNormalData[0] = response.ResponseCode;
            manageData.InputAccountRspNormalData[1] = response.ResponseMessage;
            manageData.InputAccountRspNormalData[2] = response.EntryMode;
            manageData.InputAccountRspNormalData[3] = response.Track1Data;
            manageData.InputAccountRspNormalData[4] = response.Track2Data;
            manageData.InputAccountRspNormalData[5] = response.Track3Data;
            manageData.InputAccountRspNormalData[6] = response.Pan;
            manageData.InputAccountRspNormalData[7] = response.ExpiryDate;
            manageData.InputAccountRspNormalData[8] = response.QrCode;
            manageData.InputAccountRspNormalData[9] = response.Ksn;
            manageData.InputAccountRspNormalData[10] = response.CardHolder;
        }

        public static void GetResponse(POSLink2.Manage.ResetMsrRsp response)
        {
            ManageData manageData = ManageData.GetManageData();
            //Normal
            manageData.ResetMsrRspNormalData[0] = response.ResponseCode;
            manageData.ResetMsrRspNormalData[1] = response.ResponseMessage;
        }

        public static void GetResponse(POSLink2.Manage.CheckFileRsp response)
        {
            ManageData manageData = ManageData.GetManageData();
            //Normal
            manageData.CheckFileRspNormalData[0] = response.ResponseCode;
            manageData.CheckFileRspNormalData[1] = response.ResponseMessage;
            manageData.CheckFileRspNormalData[2] = response.CheckSum;
        }

        public static void GetResponse(POSLink2.Manage.SetSafParametersRsp response)
        {
            ManageData manageData = ManageData.GetManageData();
            //Normal
            manageData.SetSafParametersRspNormalData[0] = response.ResponseCode;
            manageData.SetSafParametersRspNormalData[1] = response.ResponseMessage;
        }

        public static void GetResponse(POSLink2.Manage.ReprintRsp response)
        {
            ManageData manageData = ManageData.GetManageData();
            //Normal
            manageData.ReprintRspNormalData[0] = response.ResponseCode;
            manageData.ReprintRspNormalData[1] = response.ResponseMessage;
        }

        public static void GetResponse(POSLink2.Manage.TokenAdministrativeRsp response)
        {
            ManageData manageData = ManageData.GetManageData();
            //Normal
            manageData.TokenAdministrativeRspNormalData[0] = response.ResponseCode;
            manageData.TokenAdministrativeRspNormalData[1] = response.ResponseMessage;
            manageData.TokenAdministrativeRspNormalData[2] = response.Token;
            manageData.TokenAdministrativeRspNormalData[3] = response.TokenSN;
            manageData.TokenAdministrativeRspNormalData[4] = response.MaskedPAN;
            manageData.TokenAdministrativeRspNormalData[5] = response.ExpiryDate;
        }

        public static void GetResponse(POSLink2.Manage.VasSetMerchantParametersRsp response)
        {
            ManageData manageData = ManageData.GetManageData();
            //Normal
            manageData.VasSetMerchantParametersRspNormalData[0] = response.ResponseCode;
            manageData.VasSetMerchantParametersRspNormalData[1] = response.ResponseMessage;
        }

        public static void GetResponse(POSLink2.Manage.VasPushDataRsp response)
        {
            ManageData manageData = ManageData.GetManageData();
            //Normal
            manageData.VasPushDataRspNormalData[0] = response.ResponseCode;
            manageData.VasPushDataRspNormalData[1] = response.ResponseMessage;
        }

        public static void GetResponse(POSLink2.Manage.GetSafParametersRsp response)
        {
            ManageData manageData = ManageData.GetManageData();
            //Normal
            manageData.GetSafParametersRspNormalData[0] = response.ResponseCode;
            manageData.GetSafParametersRspNormalData[1] = response.ResponseMessage;
            manageData.GetSafParametersRspNormalData[2] = response.SafMode;
            manageData.GetSafParametersRspNormalData[3] = response.StartDateTime;
            manageData.GetSafParametersRspNormalData[4] = response.EndDateTime;
            manageData.GetSafParametersRspNormalData[5] = response.DurationInDays;
            manageData.GetSafParametersRspNormalData[6] = response.MaxNumber;
            manageData.GetSafParametersRspNormalData[7] = response.TotalCeilingAmount;
            manageData.GetSafParametersRspNormalData[8] = response.CeilingAmountPerCardType;
            manageData.GetSafParametersRspNormalData[9] = response.HaloPerCardType;
            manageData.GetSafParametersRspNormalData[10] = response.UploadMode;
            manageData.GetSafParametersRspNormalData[11] = response.AutoUploadIntervalTime;
            manageData.GetSafParametersRspNormalData[12] = response.DeleteSAFConfirmation;
        }

        private string ParseServiceType(bool[] serviceType)
        {
            byte[] byteServiceType = new byte[16];
            for(int i=0;i<16;i++)
            {
                byteServiceType[i] = (byte)'0';
            }
            for(int i=0;i<serviceType.Length;i++)
            {
                if(serviceType[i])
                {
                    byteServiceType[i] = (byte)'1';
                }
            }
            return Encoding.ASCII.GetString(byteServiceType);
        }

        private void AddToMultipleCommandsButton_Click(object sender, EventArgs e)
        {
            _terminalData = TerminalData.GetTerminalData();
            MultipleCommandsModule multipleCommandsModule = new MultipleCommandsModule();
            switch (CommandComboBox.SelectedIndex)
            {
                case (int)ManageCommandName.InitReq / 2://Init
                    multipleCommandsModule.CommandName = CommandName.Init;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)ManageCommandName.GetVariableReq / 2://Get Var
                    POSLink2.Manage.GetVariableReq getVariableReq = SetGetVariableReq();
                    multipleCommandsModule.CommandName = CommandName.GetVariable;
                    multipleCommandsModule.CommandReqObject = getVariableReq;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)ManageCommandName.SetVariableReq / 2://Set Variable
                    POSLink2.Manage.SetVariableReq setVariableReq = SetSetVariableReq();
                    multipleCommandsModule.CommandName = CommandName.SetVariable;
                    multipleCommandsModule.CommandReqObject = setVariableReq;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)ManageCommandName.GetSignatureReq / 2://Get Signature
                    multipleCommandsModule.CommandName = CommandName.GetSignature;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)ManageCommandName.ResetReq / 2://Reset
                    multipleCommandsModule.CommandName = CommandName.Reset;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)ManageCommandName.DoSignatureReq / 2://DoSignature
                    POSLink2.Manage.DoSignatureReq doSignatureReq = SetDoSignatureReq();
                    multipleCommandsModule.CommandName = CommandName.DoSignature;
                    multipleCommandsModule.CommandReqObject = doSignatureReq;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)ManageCommandName.DeleteImageReq / 2:// Delete Image
                    POSLink2.Manage.DeleteImageReq deleteImageReq = SetDeleteImageReq();
                    multipleCommandsModule.CommandName = CommandName.DeleteImage;
                    multipleCommandsModule.CommandReqObject = deleteImageReq;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)ManageCommandName.RebootReq / 2:// Reboot
                    multipleCommandsModule.CommandName = CommandName.Reboot;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)ManageCommandName.InputAccountReq / 2://Input Account
                    POSLink2.Manage.InputAccountReq inputAccountReq = SetInputAccountReq();
                    multipleCommandsModule.CommandName = CommandName.InputAccount;
                    multipleCommandsModule.CommandReqObject = inputAccountReq;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)ManageCommandName.ResetMsrReq / 2://Reset MSR
                    multipleCommandsModule.CommandName = CommandName.ResetMsr;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)ManageCommandName.CheckFileReq / 2://Check File
                    POSLink2.Manage.CheckFileReq checkFileReq = SetCheckFileReq();
                    multipleCommandsModule.CommandName = CommandName.CheckFile;
                    multipleCommandsModule.CommandReqObject = checkFileReq;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)ManageCommandName.SetSafParametersReq / 2://Set SAF Parameters
                    POSLink2.Manage.SetSafParametersReq setSafParametersReq = SetSetSafParametersReq();
                    multipleCommandsModule.CommandName = CommandName.SetSafParameters;
                    multipleCommandsModule.CommandReqObject = setSafParametersReq;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)ManageCommandName.ReprintReq / 2://Reprint
                    POSLink2.Manage.ReprintReq reprintReq = SetReprintReq();
                    multipleCommandsModule.CommandName = CommandName.Reprint;
                    multipleCommandsModule.CommandReqObject = reprintReq;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)ManageCommandName.TokenAdministrativeReq / 2://Token Administrative
                    POSLink2.Manage.TokenAdministrativeReq tokenAdministrativeReq = SetTokenAdministrativeReq();
                    multipleCommandsModule.CommandName = CommandName.TokenAdministrative;
                    multipleCommandsModule.CommandReqObject = tokenAdministrativeReq;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)ManageCommandName.VasSetMerchantParametersReq / 2://VAS Set Merchant Parameters
                    POSLink2.Manage.VasSetMerchantParametersReq vasSetMerchantParametersReq = SetVasSetMerchantParametersReq();
                    multipleCommandsModule.CommandName = CommandName.VasSetMerchantParameters;
                    multipleCommandsModule.CommandReqObject = vasSetMerchantParametersReq;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)ManageCommandName.VasPushDataReq / 2://VAS Push Data
                    POSLink2.Manage.VasPushDataReq vasPushDataReq = SetVasPushDataReq();
                    multipleCommandsModule.CommandName = CommandName.VasPushData;
                    multipleCommandsModule.CommandReqObject = vasPushDataReq;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)ManageCommandName.GetSafParametersReq / 2://Get SAF Parameters
                    multipleCommandsModule.CommandName = CommandName.GetSafParameters;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                default:
                    break;
            }
        }

        private void ManageUserControl_Load(object sender, EventArgs e)
        {

        }

        private void ManageUserControl_VisibleChanged(object sender, EventArgs e)
        {
            CommandComboBox.SelectedIndex = _comboBoxIndex;
            CommandComboBox_SelectedIndexChanged(sender, e);
        }
    }
}

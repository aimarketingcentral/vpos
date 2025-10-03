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
    public partial class PedUserControl : UserControl
    {
        private PedData _pedData;
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

        public PedUserControl()
        {
            InitializeComponent();
            CommandComboBox.Items.AddRange(PedCommon.CommandNames);
            CommandComboBox.SelectedIndex = 0;
            _comboBoxIndex = 0;
            _pedData = PedData.GetPedData();
            _waiting = new Waiting();
            _waiting.Dock = DockStyle.Left;
            _isCancelListening = false;
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
            _pedData.ResponseClear();
            _waiting.Location = new Point(0, 0);
            _waiting.IsCancelAvaliable = true;
            this.Controls.Add(_waiting);
            _waiting.BringToFront();
            _waiting.Show();

            int tenderType = CommandComboBox.SelectedIndex;
            RunPed(tenderType, sender, e);
            _isCancelListening = true;
            RunListener();
        }

        private void AddToMultipleCommandsButton_Click(object sender, EventArgs e)
        {
            _terminalData = TerminalData.GetTerminalData();
            MultipleCommandsModule multipleCommandsModule = new MultipleCommandsModule();
            switch (CommandComboBox.SelectedIndex)
            {
                case (int)PedCommandName.SessionKeyInjectionReq / 2:
                    POSLink2.Ped.SessionKeyInjectionReq sessionKeyInjectionReq = SetSessionKeyInjectionReq();
                    multipleCommandsModule.CommandName = CommandName.SessionKeyInjection;
                    multipleCommandsModule.CommandReqObject = sessionKeyInjectionReq;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)PedCommandName.MacCalculationReq / 2:
                    POSLink2.Ped.MacCalculationReq macCalculationReq = SetMacCalculationReq();
                    multipleCommandsModule.CommandName = CommandName.MacCalculation;
                    multipleCommandsModule.CommandReqObject = macCalculationReq;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)PedCommandName.GetPedInfoReq / 2:
                    POSLink2.Ped.GetPedInfoReq getPedInfoReq = SetGetPedInfoReq();
                    multipleCommandsModule.CommandName = CommandName.GetPedInfo;
                    multipleCommandsModule.CommandReqObject = getPedInfoReq;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)PedCommandName.IncreaseKsnReq / 2:
                    POSLink2.Ped.IncreaseKsnReq increaseKsnReq = SetIncreaseKsnReq();
                    multipleCommandsModule.CommandName = CommandName.IncreaseKsn;
                    multipleCommandsModule.CommandReqObject = increaseKsnReq;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                default:
                    break;
            }
        }

        private void CommandComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _comboBoxIndex = CommandComboBox.SelectedIndex;
            _tools.DisposeSubControls(panel1);
            if (CommandComboBox.SelectedIndex == 0)//Session Key Injection
            {
                PedOnePanelUserControl sessionKeyInjectionReqUserControl = new PedOnePanelUserControl();
                sessionKeyInjectionReqUserControl.CommandName = PedCommandName.SessionKeyInjectionReq;
                sessionKeyInjectionReqUserControl.Dock = DockStyle.Left;
                sessionKeyInjectionReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(sessionKeyInjectionReqUserControl);

                PedOnePanelUserControl sessionKeyInjectionRspUserControl = new PedOnePanelUserControl();
                sessionKeyInjectionRspUserControl.CommandName = PedCommandName.SessionKeyInjectionRsp;
                sessionKeyInjectionRspUserControl.Dock = DockStyle.Left;
                sessionKeyInjectionRspUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(sessionKeyInjectionRspUserControl);

                sessionKeyInjectionReqUserControl.SendToBack();
            }
            else if (CommandComboBox.SelectedIndex == 1)//Mac Calculation
            {
                PedOnePanelUserControl macCalculationReqUserControl = new PedOnePanelUserControl();
                macCalculationReqUserControl.CommandName = PedCommandName.MacCalculationReq;
                macCalculationReqUserControl.Dock = DockStyle.Left;
                macCalculationReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(macCalculationReqUserControl);

                PedOnePanelUserControl macCalculationRspUserControl = new PedOnePanelUserControl();
                macCalculationRspUserControl.CommandName = PedCommandName.MacCalculationRsp;
                macCalculationRspUserControl.Dock = DockStyle.Left;
                macCalculationRspUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(macCalculationRspUserControl);

                macCalculationReqUserControl.SendToBack();
            }
            else if (CommandComboBox.SelectedIndex == 2)//Get Ped Info
            {
                PedOnePanelUserControl getPedInfoReqUserControl = new PedOnePanelUserControl();
                getPedInfoReqUserControl.CommandName = PedCommandName.GetPedInfoReq;
                getPedInfoReqUserControl.Dock = DockStyle.Left;
                getPedInfoReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(getPedInfoReqUserControl);

                PedOnePanelUserControl getPedInfoRspUserControl = new PedOnePanelUserControl();
                getPedInfoRspUserControl.CommandName = PedCommandName.GetPedInfoRsp;
                getPedInfoRspUserControl.Dock = DockStyle.Left;
                getPedInfoRspUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(getPedInfoRspUserControl);

                getPedInfoReqUserControl.SendToBack();
            }
            else if (CommandComboBox.SelectedIndex == 3)//Increase Ksn
            {
                PedOnePanelUserControl increaseKsnReqUserControl = new PedOnePanelUserControl();
                increaseKsnReqUserControl.CommandName = PedCommandName.IncreaseKsnReq;
                increaseKsnReqUserControl.Dock = DockStyle.Left;
                increaseKsnReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(increaseKsnReqUserControl);

                PedOnePanelUserControl increaseKsnRspUserControl = new PedOnePanelUserControl();
                increaseKsnRspUserControl.CommandName = PedCommandName.IncreaseKsnRsp;
                increaseKsnRspUserControl.Dock = DockStyle.Left;
                increaseKsnRspUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(increaseKsnRspUserControl);

                increaseKsnReqUserControl.SendToBack();
            }
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

        private void RunPed(int tenderType, object sender, EventArgs e)
        {
            Task task = new Task(() =>
            {
                POSLink2.ExecutionResult executionResult = new POSLink2.ExecutionResult();

                switch (tenderType)
                {
                    case (int)PedCommandName.SessionKeyInjectionReq / 2:
                        POSLink2.Ped.SessionKeyInjectionReq sessionKeyInjectionReq = SetSessionKeyInjectionReq();
                        POSLink2.Ped.SessionKeyInjectionRsp sessionKeyInjectionRsp = null;
                        executionResult = _terminal.Ped.SessionKeyInjection(sessionKeyInjectionReq, out sessionKeyInjectionRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(sessionKeyInjectionRsp);
                        }
                        break;
                    case (int)PedCommandName.MacCalculationReq / 2:
                        POSLink2.Ped.MacCalculationReq macCalculationReq = SetMacCalculationReq();
                        POSLink2.Ped.MacCalculationRsp macCalculationRsp = null;
                        executionResult = _terminal.Ped.MacCalculation(macCalculationReq, out macCalculationRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(macCalculationRsp);
                        }
                        break;
                    case (int)PedCommandName.GetPedInfoReq / 2:
                        POSLink2.Ped.GetPedInfoReq getPedInfoReq = SetGetPedInfoReq();
                        POSLink2.Ped.GetPedInfoRsp getPedInfoRsp = null;
                        executionResult = _terminal.Ped.GetPedInfo(getPedInfoReq, out getPedInfoRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(getPedInfoRsp);
                        }
                        break;
                    case (int)PedCommandName.IncreaseKsnReq / 2:
                        POSLink2.Ped.IncreaseKsnReq increaseKsnReq = SetIncreaseKsnReq();
                        POSLink2.Ped.IncreaseKsnRsp increaseKsnRsp = null;
                        executionResult = _terminal.Ped.IncreaseKsn(increaseKsnReq, out increaseKsnRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(increaseKsnRsp);
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

        private POSLink2.Ped.SessionKeyInjectionReq SetSessionKeyInjectionReq()
        {
            POSLink2.Ped.SessionKeyInjectionReq request = new POSLink2.Ped.SessionKeyInjectionReq();
            request.SourceKeyType = _pedData.SessionKeyInjectionReqNormalData[0];
            request.SourceKeyIndex = _pedData.SessionKeyInjectionReqNormalData[1];
            request.DestinationKeyType = _pedData.SessionKeyInjectionReqNormalData[2];
            request.DestinationKeyIndex = _pedData.SessionKeyInjectionReqNormalData[3];
            request.DestinationKeyValue = _pedData.SessionKeyInjectionReqNormalData[4];
            request.CheckMode = _pedData.SessionKeyInjectionReqNormalData[5];
            request.CheckBuffer = _pedData.SessionKeyInjectionReqNormalData[6];
            return request;
        }

        private POSLink2.Ped.MacCalculationReq SetMacCalculationReq()
        {
            POSLink2.Ped.MacCalculationReq request = new POSLink2.Ped.MacCalculationReq();
            request.InputData = _pedData.MacCalculationReqNormalData[0];
            request.EncryptionBitmap = _pedData.MacCalculationReqNormalData[1];
            request.MacKeySlot = _pedData.MacCalculationReqNormalData[2];
            request.MacWorkMode = _pedData.MacCalculationReqNormalData[3];
            request.EncryptionKeySlot = _pedData.MacCalculationReqNormalData[4];
            request.PaddingChar = _pedData.MacCalculationReqNormalData[5];
            request.MacKeyType = _pedData.MacCalculationReqNormalData[6];
            request.KsnFlag = _pedData.MacCalculationReqNormalData[7];
            return request;
        }

        private POSLink2.Ped.GetPedInfoReq SetGetPedInfoReq()
        {
            POSLink2.Ped.GetPedInfoReq request = new POSLink2.Ped.GetPedInfoReq();
            request.KeyType = _pedData.GetPedInfoReqNormalData[0];
            request.KeySlot = _pedData.GetPedInfoReqNormalData[1];
            return request;
        }

        private POSLink2.Ped.IncreaseKsnReq SetIncreaseKsnReq()
        {
            POSLink2.Ped.IncreaseKsnReq request = new POSLink2.Ped.IncreaseKsnReq();
            request.KeyType = _pedData.IncreaseKsnReqNormalData[0];
            request.KeySlot = _pedData.IncreaseKsnReqNormalData[1];
            return request;
        }

        public static void GetResponse(POSLink2.Ped.SessionKeyInjectionRsp response)
        {
            PedData pedData = PedData.GetPedData();
            //Normal
            pedData.SessionKeyInjectionRspNormalData[0] = response.ResponseCode;
            pedData.SessionKeyInjectionRspNormalData[1] = response.ResponseMessage;
        }

        public static void GetResponse(POSLink2.Ped.MacCalculationRsp response)
        {
            PedData pedData = PedData.GetPedData();
            //Normal
            pedData.MacCalculationRspNormalData[0] = response.ResponseCode;
            pedData.MacCalculationRspNormalData[1] = response.ResponseMessage;
            pedData.MacCalculationRspNormalData[2] = response.ResultData;
            pedData.MacCalculationRspNormalData[3] = response.Ksn;
        }

        public static void GetResponse(POSLink2.Ped.GetPedInfoRsp response)
        {
            PedData pedData = PedData.GetPedData();
            //Normal
            pedData.GetPedInfoRspNormalData[0] = response.ResponseCode;
            pedData.GetPedInfoRspNormalData[1] = response.ResponseMessage;
            pedData.GetPedInfoRspNormalData[2] = response.MasterAvailableKeySlotCount;
            pedData.GetPedInfoRspNormalData[3] = response.MessionAvailableKeySlotCount;
            pedData.GetPedInfoRspNormalData[4] = response.DukptAvailableKeySlotCount;
            pedData.GetPedInfoRspNormalData[5] = response.AesDukptAvailableKeySlotCount;
            if(response.Tmk != null)
            {
                for(int i=0;i< response.Tmk.Length;i++)
                {
                    string temp = response.Tmk[i].KeySlot + "," + response.Tmk[i].Kcv;
                    pedData.GetPedInfoRspNormalData[6] += temp;
                    if(i != response.Tmk.Length-1)
                    {
                        pedData.GetPedInfoRspNormalData[6] += "\r\n";
                    }
                }
            }
            if (response.Tpk != null)
            {
                for (int i = 0; i < response.Tpk.Length; i++)
                {
                    string temp = response.Tpk[i].KeySlot + "," + response.Tpk[i].Kcv;
                    pedData.GetPedInfoRspNormalData[7] += temp;
                    if (i != response.Tpk.Length - 1)
                    {
                        pedData.GetPedInfoRspNormalData[7] += "\r\n";
                    }
                }
            }
            if (response.Tak != null)
            {
                for (int i = 0; i < response.Tak.Length; i++)
                {
                    string temp = response.Tak[i].KeySlot + "," + response.Tak[i].Kcv;
                    pedData.GetPedInfoRspNormalData[8] += temp;
                    if (i != response.Tak.Length - 1)
                    {
                        pedData.GetPedInfoRspNormalData[8] += "\r\n";
                    }
                }
            }
            if (response.Tdk != null)
            {
                for (int i = 0; i < response.Tdk.Length; i++)
                {
                    string temp = response.Tdk[i].KeySlot + "," + response.Tdk[i].Kcv;
                    pedData.GetPedInfoRspNormalData[9] += temp;
                    if (i != response.Tdk.Length - 1)
                    {
                        pedData.GetPedInfoRspNormalData[9] += "\r\n";
                    }
                }
            }
            if (response.DukptKey != null)
            {
                for (int i = 0; i < response.DukptKey.Length; i++)
                {
                    string temp = response.DukptKey[i].KeySlot + "," + response.DukptKey[i].Ksn + "," + response.DukptKey[i].Kcv;
                    pedData.GetPedInfoRspNormalData[10] += temp;
                    if (i != response.DukptKey.Length - 1)
                    {
                        pedData.GetPedInfoRspNormalData[10] += "\r\n";
                    }
                }
            }
            if (response.AesDukptKey != null)
            {
                for (int i = 0; i < response.AesDukptKey.Length; i++)
                {
                    string temp = response.AesDukptKey[i].KeySlot + "," + response.AesDukptKey[i].Ksn + "," + response.AesDukptKey[i].Kcv;
                    pedData.GetPedInfoRspNormalData[11] += temp;
                    if (i != response.AesDukptKey.Length - 1)
                    {
                        pedData.GetPedInfoRspNormalData[11] += "\r\n";
                    }
                }
            }
        }

        public static void GetResponse(POSLink2.Ped.IncreaseKsnRsp response)
        {
            PedData pedData = PedData.GetPedData();
            //Normal
            pedData.IncreaseKsnRspNormalData[0] = response.ResponseCode;
            pedData.IncreaseKsnRspNormalData[1] = response.ResponseMessage;
            pedData.IncreaseKsnRspNormalData[2] = response.Ksn;
        }

        private void PedUserControl_VisibleChanged(object sender, EventArgs e)
        {
            CommandComboBox.SelectedIndex = _comboBoxIndex;
            CommandComboBox_SelectedIndexChanged(sender, e);
        }
    }
}

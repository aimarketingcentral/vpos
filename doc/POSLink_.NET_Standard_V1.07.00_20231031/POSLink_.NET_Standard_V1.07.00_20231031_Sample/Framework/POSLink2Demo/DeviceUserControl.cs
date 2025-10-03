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
    public partial class DeviceUserControl : UserControl
    {
        private DeviceData _deviceData;
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

        public DeviceUserControl()
        {
            InitializeComponent();
            CommandComboBox.Items.AddRange(DeviceCommon.CommandNames);
            _comboBoxIndex = 0;
            CommandComboBox.SelectedIndex = 0;
            _deviceData = DeviceData.GetDeviceData();
            _waiting = new Waiting();
            _waiting.Dock = DockStyle.Left;
            _isCancelListening = false;
        }

        private void CommandComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _comboBoxIndex = CommandComboBox.SelectedIndex;
            _tools.DisposeSubControls(panel1);
            if (CommandComboBox.SelectedIndex == 0)//Printer
            {
                DeviceOnePanelUserControl PrinterReqUserControl = new DeviceOnePanelUserControl();
                PrinterReqUserControl.CommandName =DeviceCommandName.PrinterReq;
                PrinterReqUserControl.Dock = DockStyle.Left;
                PrinterReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(PrinterReqUserControl);

                DeviceOnePanelUserControl PrinterRspUserControl = new DeviceOnePanelUserControl();
                PrinterRspUserControl.CommandName = DeviceCommandName.PrinterRsp;
                PrinterRspUserControl.Dock = DockStyle.Left;
                PrinterRspUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(PrinterRspUserControl);

                PrinterReqUserControl.SendToBack();
            }
            else if(CommandComboBox.SelectedIndex == 1)//Card Insert Detection
            {
                DeviceOnePanelUserControl CardInsertDetectionReqUserControl = new DeviceOnePanelUserControl();
                CardInsertDetectionReqUserControl.CommandName = DeviceCommandName.CardInsertDetectionReq;
                CardInsertDetectionReqUserControl.Dock = DockStyle.Left;
                CardInsertDetectionReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(CardInsertDetectionReqUserControl);

                DeviceOnePanelUserControl CardInsertDetectionRspUserControl = new DeviceOnePanelUserControl();
                CardInsertDetectionRspUserControl.CommandName = DeviceCommandName.CardInsertDetectionRsp;
                CardInsertDetectionRspUserControl.Dock = DockStyle.Left;
                CardInsertDetectionRspUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(CardInsertDetectionRspUserControl);

                CardInsertDetectionReqUserControl.SendToBack();
            }
            else if (CommandComboBox.SelectedIndex == 2)//Camera Scan
            {
                DeviceOnePanelUserControl CameraScanReqUserControl = new DeviceOnePanelUserControl();
                CameraScanReqUserControl.CommandName = DeviceCommandName.CameraScanReq;
                CameraScanReqUserControl.Dock = DockStyle.Left;
                CameraScanReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(CameraScanReqUserControl);

                DeviceOnePanelUserControl CameraScanRspUserControl = new DeviceOnePanelUserControl();
                CameraScanRspUserControl.CommandName = DeviceCommandName.CameraScanRsp;
                CameraScanRspUserControl.Dock = DockStyle.Left;
                CameraScanRspUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(CameraScanRspUserControl);

                CameraScanReqUserControl.SendToBack();
            }
            else if (CommandComboBox.SelectedIndex == 3)//Mifare Card
            {
                DeviceOnePanelUserControl MifareCardReqUserControl = new DeviceOnePanelUserControl();
                MifareCardReqUserControl.CommandName = DeviceCommandName.MifareCardReq;
                MifareCardReqUserControl.Dock = DockStyle.Left;
                MifareCardReqUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(MifareCardReqUserControl);

                DeviceOnePanelUserControl MifareCardRspUserControl = new DeviceOnePanelUserControl();
                MifareCardRspUserControl.CommandName = DeviceCommandName.MifareCardRsp;
                MifareCardRspUserControl.Dock = DockStyle.Left;
                MifareCardRspUserControl.ShowPanel(sender, e);
                panel1.Controls.Add(MifareCardRspUserControl);

                MifareCardReqUserControl.SendToBack();
            }
        }

        private void RunDevice(int commandType, object sender, EventArgs e)
        {
            Task task = new Task(() =>
            {
                POSLink2.ExecutionResult executionResult = new POSLink2.ExecutionResult();

                switch (commandType)
                {
                    case (int)DeviceCommandName.PrinterReq / 2://Printer
                        POSLink2.Device.PrinterReq printerReq = SetPrinterReq();
                        POSLink2.Device.PrinterRsp printerRsp = null;
                        executionResult = _terminal.Device.Printer.Print(printerReq, out printerRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(printerRsp);
                        }
                        break;
                    case (int)DeviceCommandName.CardInsertDetectionReq / 2://Card Insert Detection
                        POSLink2.Device.CardInsertDetectionRsp cardInsertDetectionRsp = null;
                        executionResult = _terminal.Device.Card.CardInsertDetection(out cardInsertDetectionRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(cardInsertDetectionRsp);
                        }
                        break;
                    case (int)DeviceCommandName.CameraScanReq / 2://Carema Scan
                        POSLink2.Device.CameraScanReq cameraScanReq = SetCameraScanReq();
                        POSLink2.Device.CameraScanRsp cameraScanRsp = null;
                        executionResult = _terminal.Device.Camera.CameraScan(cameraScanReq, out cameraScanRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(cameraScanRsp);
                        }
                        break;
                    case (int)DeviceCommandName.MifareCardReq / 2://Mifare Card
                        POSLink2.Device.MifareCardReq mifareCardReq = SetMifareCardReq();
                        POSLink2.Device.MifareCardRsp mifareCardRsp = null;
                        executionResult = _terminal.Device.MifareCard.Operate(mifareCardReq, out mifareCardRsp);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(mifareCardRsp);
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
            _deviceData.ResponseClear();
            _waiting.Location = new Point(0, 0);
            _waiting.IsCancelAvaliable = true;
            this.Controls.Add(_waiting);
            _waiting.BringToFront();
            _waiting.Show();

            int commandType = CommandComboBox.SelectedIndex;
            RunDevice(commandType, sender, e);
            _isCancelListening = true;
            RunListener();
        }

        private POSLink2.Device.PrinterReq SetPrinterReq()
        {
            POSLink2.Device.PrinterReq request = new POSLink2.Device.PrinterReq();
            request.PrintCopy = _deviceData.PrinterReqNormalData[0];
            request.PrintData = _deviceData.PrinterReqNormalData[1];
            return request;
        }

        private POSLink2.Device.CameraScanReq SetCameraScanReq()
        {
            POSLink2.Device.CameraScanReq request = new POSLink2.Device.CameraScanReq();
            request.Reader = _deviceData.CameraScanReqNormalData[0];
            request.Timeout = _deviceData.CameraScanReqNormalData[1];
            return request;
        }

        private POSLink2.Device.MifareCardReq SetMifareCardReq()
        {
            POSLink2.Device.MifareCardReq request = new POSLink2.Device.MifareCardReq();
            request.M1Command = _deviceData.MifareCardReqNormalData[0];
            request.BlockNo = _deviceData.MifareCardReqNormalData[1];
            request.Password = _deviceData.MifareCardReqNormalData[2];
            request.PasswordType = _deviceData.MifareCardReqNormalData[3];
            request.BlockValue = _deviceData.MifareCardReqNormalData[4];
            request.UpdateBlockNo = _deviceData.MifareCardReqNormalData[5];
            request.Timeout = _deviceData.MifareCardReqNormalData[6];
            return request;
        }

        public static void GetResponse(POSLink2.Device.PrinterRsp response)
        {
            DeviceData deviceData = DeviceData.GetDeviceData();
            deviceData.PrinterRspNormalData[0] = response.ResponseCode;
            deviceData.PrinterRspNormalData[1] = response.ResponseMessage;
        }

        public static void GetResponse(POSLink2.Device.CardInsertDetectionRsp response)
        {
            DeviceData deviceData = DeviceData.GetDeviceData();
            deviceData.CardInsertDetectionRspNormalData[0] = response.ResponseCode;
            deviceData.CardInsertDetectionRspNormalData[1] = response.ResponseMessage;
            deviceData.CardInsertDetectionRspNormalData[2] = response.CardInsertStatus;
        }

        public static void GetResponse(POSLink2.Device.CameraScanRsp response)
        {
            DeviceData deviceData = DeviceData.GetDeviceData();
            deviceData.CameraScanRspNormalData[0] = response.ResponseCode;
            deviceData.CameraScanRspNormalData[1] = response.ResponseMessage;
            deviceData.CameraScanRspNormalData[2] = response.BarcodeData;
            deviceData.CameraScanRspNormalData[3] = response.BarcodeType;
        }

        public static void GetResponse(POSLink2.Device.MifareCardRsp response)
        {
            DeviceData deviceData = DeviceData.GetDeviceData();
            deviceData.MifareCardRspNormalData[0] = response.ResponseCode;
            deviceData.MifareCardRspNormalData[1] = response.ResponseMessage;
            deviceData.MifareCardRspNormalData[2] = response.BlockValue;
        }

        private void AddToMultipleCommandsButton_Click(object sender, EventArgs e)
        {
            _terminalData = TerminalData.GetTerminalData();
            MultipleCommandsModule multipleCommandsModule = new MultipleCommandsModule();
            switch (CommandComboBox.SelectedIndex)
            {
                case (int)DeviceCommandName.PrinterReq / 2://Printer
                    POSLink2.Device.PrinterReq printerReq = SetPrinterReq();
                    multipleCommandsModule.CommandName = CommandName.Printer;
                    multipleCommandsModule.CommandReqObject = printerReq;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)DeviceCommandName.CardInsertDetectionReq / 2://Card Insert Detection
                    multipleCommandsModule.CommandName = CommandName.CardInsertDetection;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)DeviceCommandName.CameraScanReq / 2://Camera Scan
                    POSLink2.Device.CameraScanReq cameraScanReq = SetCameraScanReq();
                    multipleCommandsModule.CommandName = CommandName.CameraScan;
                    multipleCommandsModule.CommandReqObject = cameraScanReq;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)DeviceCommandName.MifareCardReq / 2://Mifare Card
                    POSLink2.Device.MifareCardReq mifareCardReq = SetMifareCardReq();
                    multipleCommandsModule.CommandName = CommandName.MifareCard;
                    multipleCommandsModule.CommandReqObject = mifareCardReq;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                default:
                    break;
            }
        }

        private void DeviceUserControl_Load(object sender, EventArgs e)
        {

        }

        private void DeviceUserControl_VisibleChanged(object sender, EventArgs e)
        {
            CommandComboBox.SelectedIndex = _comboBoxIndex;
            CommandComboBox_SelectedIndexChanged(sender, e);
        }
    }
}

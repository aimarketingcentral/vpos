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
    public partial class DeviceOnePanelUserControl : UserControl
    {
        private DeviceCommandName _commandName;
        public DeviceCommandName CommandName
        {
            get { return _commandName; }
            set { _commandName = value; }
        }

        private DeviceData _deviceData;
        private Tools _tools = new Tools();
        public DeviceOnePanelUserControl()
        {
            InitializeComponent();
            _deviceData = DeviceData.GetDeviceData();
        }

        public void ShowPanel(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ValuePanel);
            LabelTextBoxUserControl[] labelAndTextBoxs;
            LabelComboBoxUserControl[] labelAndComboBox;
            Label unitOfTimeout;
            switch (_commandName)
            {
                case DeviceCommandName.PrinterReq:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(DeviceCommon.PrinterReqNormal, 394, new Point(0, 2), _deviceData.PrinterReqNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case DeviceCommandName.PrinterRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(DeviceCommon.PrinterRspNormal, 394, new Point(0, 2), _deviceData.PrinterRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case DeviceCommandName.CardInsertDetectionReq:
                    break;
                case DeviceCommandName.CardInsertDetectionRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(DeviceCommon.CardInsertDetectionRspNormal, 394, new Point(0, 2), _deviceData.CardInsertDetectionRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case DeviceCommandName.CameraScanReq:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(DeviceCommon.CameraScanReqNormal, 394, new Point(0, 2), _deviceData.CameraScanReqNormalData);
                    labelAndTextBoxs[1].CreateLabelTextBox(350, "Timeout", "Timeout", 0.335f);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    unitOfTimeout = new Label();
                    unitOfTimeout.AutoSize = true;
                    unitOfTimeout.Text = "100ms";
                    unitOfTimeout.Location = new Point(350, 22 + 2);
                    ValuePanel.Controls.Add(unitOfTimeout);
                    break;
                case DeviceCommandName.CameraScanRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(DeviceCommon.CameraScanRspNormal, 394, new Point(0, 2), _deviceData.CameraScanRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case DeviceCommandName.MifareCardReq:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(DeviceCommon.MifareCardReqNormal, 394, new Point(0, 2), _deviceData.MifareCardReqNormalData);
                    labelAndTextBoxs[6].CreateLabelTextBox(350, "Timeout", "Timeout", 0.335f);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    unitOfTimeout = new Label();
                    unitOfTimeout.AutoSize = true;
                    unitOfTimeout.Text = "100ms";
                    unitOfTimeout.Location = new Point(350, 6 * 22 + 2);
                    ValuePanel.Controls.Add(unitOfTimeout);
                    break;
                case DeviceCommandName.MifareCardRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(DeviceCommon.MifareCardRspNormal, 394, new Point(0, 2), _deviceData.MifareCardRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                default:
                    break;
            }
        }

        private LabelTextBoxUserControl[] CreateLabelAndTextBoxs(string[,] nameAndText, int width, Point point, string[] value)
        {
            LabelTextBoxUserControl[] temp = new LabelTextBoxUserControl[nameAndText.Length / 2];
            for (int i = 0; i < nameAndText.Length / 2; i++)
            {
                temp[i] = new LabelTextBoxUserControl();
                temp[i].Name = nameAndText[i, 0] + "UserControl";
                float proportion = 0.3f;
                if (width < 300)
                {
                    proportion = 0.4f;
                }
                temp[i].CreateLabelTextBox(width, nameAndText[i, 0], nameAndText[i, 1], proportion);
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
                case DeviceCommandName.PrinterReq:
                    for (int i = 0; i < DeviceCommon.PrinterReqNormal.Length / 2; i++)
                    {
                        if (userControl.Name == DeviceCommon.PrinterReqNormal[i, 0] + "UserControl")
                        {
                            _deviceData.PrinterReqNormalData[i] = userControl.GetTextBoxValue();
                        }
                    }
                    break;
                case DeviceCommandName.CameraScanReq:
                    for (int i = 0; i < DeviceCommon.CameraScanReqNormal.Length / 2; i++)
                    {
                        if (userControl.Name == DeviceCommon.CameraScanReqNormal[i, 0] + "UserControl")
                        {
                            _deviceData.CameraScanReqNormalData[i] = userControl.GetTextBoxValue();
                        }
                    }
                    break;
                case DeviceCommandName.MifareCardReq:
                    for (int i = 0; i < DeviceCommon.MifareCardReqNormal.Length / 2; i++)
                    {
                        if (userControl.Name == DeviceCommon.MifareCardReqNormal[i, 0] + "UserControl")
                        {
                            _deviceData.MifareCardReqNormalData[i] = userControl.GetTextBoxValue();
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}

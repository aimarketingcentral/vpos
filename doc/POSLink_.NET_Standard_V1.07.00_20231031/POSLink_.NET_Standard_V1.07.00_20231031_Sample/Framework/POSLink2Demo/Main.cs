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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            CommunicationTypeComboBox.SelectedIndex = 3;
            IpTextBox.Text = "127.0.0.1";
            PortTextBox.Text = "10009";
            TimeoutTextBox.Text = "-1";
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            CommSettingProperties commSettingProperties = new CommSettingProperties();
            if (String.IsNullOrEmpty(CommunicationTypeComboBox.Text))
            {
                MessageBox.Show("Communication Type not set!", "Warning");
                return;
            }
            commSettingProperties.CommSetting = CommunicationTypeComboBox.Text;

            if(CommunicationTypeComboBox.Text == "UART")
            {
                if(String.IsNullOrEmpty(SerialPortTextBox.Text))
                {
                    MessageBox.Show("Serial port not set!", "Warning");
                    return;
                }
                commSettingProperties.SerialPort = SerialPortTextBox.Text;

                if (String.IsNullOrEmpty(BaudRateTextBox.Text))
                {
                    MessageBox.Show("Baud rate is not set!", "Warning");
                    return;
                }

                try
                {
                    commSettingProperties.BaudRate = Int32.Parse(BaudRateTextBox.Text);
                    if (commSettingProperties.BaudRate < 0)
                    {
                        MessageBox.Show("Baud rate is not a positive integer!", "Warning");
                        return;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Baud rate is not a positive integer!", "Warning");
                    return;
                }
            }
            else
            {
                if (String.IsNullOrEmpty(IpTextBox.Text))
                {
                    MessageBox.Show("Ip not set!", "Warning");
                    return;
                }
                commSettingProperties.Ip = IpTextBox.Text;

                if (String.IsNullOrEmpty(PortTextBox.Text))
                {
                    MessageBox.Show("Port not set!", "Warning");
                    return;
                }

                try
                {
                    commSettingProperties.Port = Int32.Parse(PortTextBox.Text);
                    if (commSettingProperties.Port < 0)
                    {
                        MessageBox.Show("Port is not a positive integer!", "Warning");
                        return;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Port is not a positive integer!", "Warning");
                    return;
                }
            }

            if (String.IsNullOrEmpty(TimeoutTextBox.Text))
            {
                MessageBox.Show("Timeout not set!", "Warning");
                return;
            }
            try
            {
                commSettingProperties.Timeout = Int32.Parse(TimeoutTextBox.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Timeout is not a integer!", "Warning");
                return;
            }

            POSLink2.Terminal terminal = null;
            POSLink2.POSLink2 poslink = POSLink2.POSLink2.GetPOSLink2();
            if (commSettingProperties.CommSetting == "TCP")
            {
                POSLink2.CommSetting.TcpSetting commSetting = new POSLink2.CommSetting.TcpSetting();
                commSetting.Ip = commSettingProperties.Ip;
                commSetting.Port = commSettingProperties.Port;
                commSetting.Timeout = commSettingProperties.Timeout;
                terminal = poslink.GetTerminal(commSetting);
            }
            else if (commSettingProperties.CommSetting == "SSL")
            {
                POSLink2.CommSetting.SslSetting commSetting = new POSLink2.CommSetting.SslSetting();
                commSetting.Ip = commSettingProperties.Ip;
                commSetting.Port = commSettingProperties.Port;
                commSetting.Timeout = commSettingProperties.Timeout;
                terminal = poslink.GetTerminal(commSetting);
            }
            else if (commSettingProperties.CommSetting == "HTTP")
            {
                POSLink2.CommSetting.HttpSetting commSetting = new POSLink2.CommSetting.HttpSetting();
                commSetting.Ip = commSettingProperties.Ip;
                commSetting.Port = commSettingProperties.Port;
                commSetting.Timeout = commSettingProperties.Timeout;
                terminal = poslink.GetTerminal(commSetting);
            }
            else if (commSettingProperties.CommSetting == "HTTPS")
            {
                POSLink2.CommSetting.HttpsSetting commSetting = new POSLink2.CommSetting.HttpsSetting();
                commSetting.Ip = commSettingProperties.Ip;
                commSetting.Port = commSettingProperties.Port;
                commSetting.Timeout = commSettingProperties.Timeout;
                terminal = poslink.GetTerminal(commSetting);
            }
            else if(commSettingProperties.CommSetting == "UART")
            {
                SerialPortData serialPortData = new SerialPortData();
                serialPortData.SerialPortName = commSettingProperties.SerialPort;
                serialPortData.BaudRate = commSettingProperties.BaudRate;
                Uart uart = new Uart();
                uart.SetCommProperties(serialPortData);
                POSLink2.CommSetting.CustomerCommSetting commSetting = uart;
                commSetting.Timeout = commSettingProperties.Timeout;
                terminal = poslink.GetTerminal(commSetting);
            }
            else
            {
                MessageBox.Show("Unknown Communication Type.", "Warning");
                return;
            }

            if(terminal == null)
            {
                MessageBox.Show("Create terminal failed!", "Warning");
                return;
            }

            TerminalForm terminalForm = new TerminalForm();
            terminalForm.Terminal = terminal;
            terminalForm.MainSample = this;
            terminalForm.Show();
            this.Hide();
        }

        private void Main_Load(object sender, EventArgs e)
        {
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            Application.Exit();
        }

        private void SetLogSettingButton_Click(object sender, EventArgs e)
        {
            POSLink2.POSLink2 poslink = POSLink2.POSLink2.GetPOSLink2();
            LogSettingForm logSettingForm = new LogSettingForm();
            logSettingForm.LogSetting = poslink.GetLogSetting();
            DialogResult ret = logSettingForm.ShowDialog();
            if(ret == DialogResult.OK)
            {
                poslink.SetLogSetting(logSettingForm.LogSetting);
            }
            logSettingForm.Hide();
            logSettingForm.Dispose();
        }
    }
}

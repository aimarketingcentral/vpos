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
using System.IO.Ports;
using System.Threading;

namespace POSLinkUart
{
    public class UartSetting : POSLinkCore.CommunicationSetting.CustomerCommunicationSetting
    {
        SerialPort _serialPort = null;
        public string SerialPortName { get; set; }
        public int BaudRate { get; set; }

        public UartSetting()
        {
            SerialPortName = "";
            BaudRate = -1;
            _serialPort = new SerialPort();
        }

        public override bool IsSameCommunication(POSLinkCore.CommunicationSetting.CustomerCommunicationSetting setting)
        {
            if (setting.GetType() == typeof(UartSetting))
            {
                UartSetting tempUart = setting as UartSetting;
                if (tempUart.SerialPortName == this.SerialPortName)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsCommSettingLegal()
        {
            this.SerialPortName = this.SerialPortName.Trim();
            if (!this.SerialPortName.StartsWith("com") && !this.SerialPortName.StartsWith("COM"))
            {
                return false;
            }
            if (this.SerialPortName.Length <= 3)
            {
                return false;
            }
            this.SerialPortName = this.SerialPortName.Remove(0, 3);
            int port;
            try
            {
                port = Int32.Parse(this.SerialPortName, System.Globalization.NumberStyles.Integer);
            }
            catch (Exception)
            {
                return false;
            }

            if (port < 0)
            {
                return false;
            }
            this.SerialPortName = "com" + port;
            return true;
        }

        private void SetCommProperties()
        {
            _serialPort = new SerialPort();
            _serialPort.PortName = SerialPortName;
            _serialPort.BaudRate = BaudRate;
            _serialPort.Parity = Parity.None;
            _serialPort.DataBits = 8;
            _serialPort.StopBits = StopBits.One;
            _serialPort.ReadTimeout = 500;
        }

        public override void Open()
        {
            if (!_serialPort.IsOpen)
            {
                SetCommProperties();
                _serialPort.Open();
                _serialPort.ReadExisting();
            }
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            _serialPort.Write(buffer, offset, count);
        }

        public override int Read(ref byte[] buffer, int offset, int count)
        {
            int ret;
            try
            {
                ret = _serialPort.Read(buffer, offset, count);
            }
            catch (TimeoutException)
            {
                ret = 0;
            }
            catch (Exception)
            {
                ret = -1;
            }
            return ret;
        }

        public override void Close()
        {
            _serialPort.Close();
            _serialPort.Dispose();
            Thread.Sleep(50);//Ensure that the serial port is closed.
        }
    }
}

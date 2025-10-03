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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;

namespace POSLink2Demo
{
    public class Uart:POSLink2.CommSetting.CustomerCommSetting
    {
        SerialPort _serialPort = null;
        private string SerialPort { get; set; }
        private int BaudRate { get; set; }

        public Uart()
        {
            SerialPort = "";
            BaudRate = -1;
        }

        public void SetCommProperties(object commProperties)
        {
            if(commProperties.GetType() == typeof(SerialPortData))
            {
                SerialPortData serialPortData = (SerialPortData)commProperties;
                this.SerialPort = serialPortData.SerialPortName;
                this.BaudRate = serialPortData.BaudRate;
                _serialPort = new SerialPort();
                _serialPort.PortName = serialPortData.SerialPortName;
                _serialPort.BaudRate = serialPortData.BaudRate;
            }
            else
            {
                return;
            }
            _serialPort.Parity = Parity.None;
            _serialPort.DataBits = 8;
            _serialPort.StopBits = StopBits.One;
            _serialPort.ReadTimeout = 500;
        }

        public override bool IsSameCommunication(POSLink2.CommSetting.CustomerCommSetting setting)
        {
            if(setting.GetType() == typeof(Uart))
            {
                Uart tempUart = (Uart)setting;
                if (tempUart.SerialPort == this.SerialPort)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsCommSettingLegal()
        {
            this.SerialPort = this.SerialPort.Trim();
            if (!this.SerialPort.StartsWith("com") && !this.SerialPort.StartsWith("COM"))
            {
                return false;
            }
            if(this.SerialPort.Length<=3)
            {
                return false;
            }
            this.SerialPort = this.SerialPort.Remove(0, 3);
            int port;
            try
            {
                port = Int32.Parse(this.SerialPort, System.Globalization.NumberStyles.Integer);
            }
            catch (Exception)
            {
                return false;
            }

            if (port < 0)
            {
                return false;
            }
            this.SerialPort = "com" + port;
            return true;
        }

        public override void Open()
        {
            if(!_serialPort.IsOpen)
            {
                _serialPort.Open();
                _serialPort.ReadExisting();
            }
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            _serialPort.Write(buffer, offset, count);
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int ret;
            try
            {
                ret = _serialPort.Read(buffer, offset, count);
            }
            catch(TimeoutException)
            {
                ret = 0;
            }
            catch(Exception)
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

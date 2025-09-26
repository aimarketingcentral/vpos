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

using Android.Content;
using Android.OS;
using Com.Pax.GL.Commhelper;
using Com.Pax.GL.Commhelper.Exception;
using Com.Pax.GL.Commhelper.Impl;
using Com.Pax.Serialport.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Google.Crypto.Tink.Proto;

namespace POSLinkMauiDemo.Platforms.Android
{
    public class UartSetting: POSLinkCore.CommunicationSetting.CustomerCommunicationSetting
    {
        private ICommSerialPort _serialPort;
        private PaxGLComm _glComm;
        private static object _uartLock = new object();

        public string SerialPortName { get; set; }
        public string BaudRate { get; set; }

        public UartSetting(Context context)
        {
            _glComm = PaxGLComm.GetInstance(context);
            _serialPort = null;
        }

        public override void Open()
        {
            lock (_uartLock)
            {
                try
                {
                    if(_serialPort== null)
                    {
                        _serialPort = _glComm.CreateSerialPort(SerialPortName, BaudRate + ",8,n,1");
                    }
                    if(_serialPort.ConnectStatus == IComm.EConnectStatus.Disconnected)
                    {
                        _serialPort.Connect();
                    }
                }
                catch (CommException e)
                {
                    e.PrintStackTrace();
                }
            }
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            try
            {
                _serialPort.Send(buffer);
            }
            catch (CommException e)
            {
                e.PrintStackTrace();
            }
        }

        public override int Read(ref byte[] buffer, int offset, int count)
        {
            int ret;
            try
            {
                _serialPort.RecvTimeout= 500;
                buffer = _serialPort.Recv(count);
                ret = buffer.Length;
            }
            catch (CommException)
            {
                ret = -1;
            }
            return ret;
        }

        public override void Close()
        {
            if (_serialPort != null)
            {
                lock(_uartLock)
                {
                    try
                    {
                        _serialPort.Disconnect();
                    }
                    catch (CommException e)
                    {
                        e.PrintStackTrace();
                    }
                    _serialPort = null;
                }
            }
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
    }
}

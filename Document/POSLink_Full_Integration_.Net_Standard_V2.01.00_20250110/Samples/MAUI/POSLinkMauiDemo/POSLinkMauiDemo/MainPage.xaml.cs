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

using POSLinkAdmin.Manage;

namespace POSLinkMauiDemo;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        ipStackLayout.IsVisible = true;
        portStackLayout.IsVisible = true;
        timeoutStackLayout.IsVisible = true;
        serialPortStackLayout.IsVisible = false;
        baudrateStackLayout.IsVisible = false;
        resCodeEntry.Text = "";
        resMsgEntry.Text = "";
    }

    private void CommSettingChanged(object sender, EventArgs e)
    {
        if (commSettingEntry.Text.Trim().ToUpper() == "TCP")
        {
            ipStackLayout.IsVisible = true;
            portStackLayout.IsVisible = true;
            timeoutStackLayout.IsVisible = true;
            serialPortStackLayout.IsVisible = false;
            baudrateStackLayout.IsVisible = false;
            resCodeEntry.Text = "";
            resMsgEntry.Text = "";
        }
        else if (commSettingEntry.Text.Trim().ToUpper() == "SSL")
        {
            ipStackLayout.IsVisible = true;
            portStackLayout.IsVisible = true;
            timeoutStackLayout.IsVisible = true;
            serialPortStackLayout.IsVisible = false;
            baudrateStackLayout.IsVisible = false;
            resCodeEntry.Text = "";
            resMsgEntry.Text = "";
        }
        else if (commSettingEntry.Text.Trim().ToUpper() == "AIDL")
        {
            ipStackLayout.IsVisible = false;
            portStackLayout.IsVisible = false;
            serialPortStackLayout.IsVisible = false;
            baudrateStackLayout.IsVisible = false;
            timeoutStackLayout.IsVisible = false;
            resCodeEntry.Text = "";
            resMsgEntry.Text = "";
        }
        else if (commSettingEntry.Text.Trim().ToUpper() == "UART")
        {
            serialPortStackLayout.IsVisible = true;
            baudrateStackLayout.IsVisible = true;
            timeoutStackLayout.IsVisible = true;
            ipStackLayout.IsVisible = false;
            portStackLayout.IsVisible = false;
            resCodeEntry.Text = "";
            resMsgEntry.Text = "";
        }
        else
        {
            ipStackLayout.IsVisible = false;
            portStackLayout.IsVisible = false;
            serialPortStackLayout.IsVisible = false;
            baudrateStackLayout.IsVisible = false;
            timeoutStackLayout.IsVisible = false;
        }
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        SemanticScreenReader.Announce(CounterBtn.Text);
        resCodeEntry.Text = "";
        resMsgEntry.Text = "";

        POSLinkCore.LogSetting logSetting = new POSLinkCore.LogSetting();
#if ANDROID
        PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.StorageWrite>();
        if (status == PermissionStatus.Denied)
        {
            status = await Permissions.RequestAsync<Permissions.StorageWrite>();
        }

        logSetting.FilePath = Android.OS.Environment.ExternalStorageDirectory.Path;
#endif
        POSLinkCore.CommunicationSetting.CommunicationSetting commSetting = null;
        string commSettingName = commSettingEntry.Text.Trim();
        if (commSettingName.ToUpper() == "TCP")
        {
            POSLinkCore.CommunicationSetting.TcpSetting tcpSetting = new POSLinkCore.CommunicationSetting.TcpSetting();
            tcpSetting.Ip = ipEntry.Text;
            int port;
            bool isPortNum = Int32.TryParse(portEntry.Text, out port);
            if (isPortNum)
            {
                tcpSetting.Port = port;
            }
            int timeout;
            bool isTimeoutNum = Int32.TryParse(timeoutEntry.Text, out timeout);
            if (isTimeoutNum)
            {
                tcpSetting.Timeout = timeout;
            }
            commSetting = tcpSetting;
        }
        else if (commSettingName.ToUpper() == "SSL")
        {
            POSLinkCore.CommunicationSetting.SslSetting sslSetting = new POSLinkCore.CommunicationSetting.SslSetting();
            sslSetting.Ip = ipEntry.Text;
            int port;
            bool isPortNum = Int32.TryParse(portEntry.Text, out port);
            if (isPortNum)
            {
                sslSetting.Port = port;
            }
            int timeout;
            bool isTimeoutNum = Int32.TryParse(timeoutEntry.Text, out timeout);
            if (isTimeoutNum)
            {
                sslSetting.Timeout = timeout;
            }
            commSetting = sslSetting;
        }
        else if (commSettingName.ToUpper() == "AIDL")
        {
#if ANDROID
            if(!MainActivity.CreateAidl())
            {
                resMsgEntry.Text = "AIDL failed.";
                return;
            }

            commSetting = MainActivity.AidlCommunication;
#else
            resMsgEntry.Text = "Not support.";
            return;
#endif
        }
        else if (commSettingName.ToUpper() == "UART")
        {
#if ANDROID
            MainActivity.CreateUart();
            MainActivity.UartSetting.SerialPortName = serialPortEntry.Text;
            MainActivity.UartSetting.BaudRate = baudrateEntry.Text;
            int timeout;
            bool isTimeoutNum = Int32.TryParse(timeoutEntry.Text, out timeout);
            if (isTimeoutNum)
            {
                MainActivity.UartSetting.Timeout = timeout;
            }
            commSetting = MainActivity.UartSetting;
#else
            resMsgEntry.Text = "Not support.";
            return;
#endif
        }
        else
        {
            resMsgEntry.Text = "Not support.";
            return;
        }

            Thread thread1 = new Thread(() =>
            {
                try
                {
                    POSLinkFullIntegration.POSLinkFull poslinkFull = POSLinkFullIntegration.POSLinkFull.GetPOSLinkFull();
                    POSLinkFullIntegration.Terminal terminal = poslinkFull.GetTerminal(commSetting);
                    poslinkFull.SetLogSetting(logSetting);

                    POSLinkAdmin.Manage.InitResponse initResponse = null;

                    POSLinkAdmin.ExecutionResult result = terminal?.Manage.Init(out initResponse);
                    if (result?.GetErrorCode() == POSLinkAdmin.ExecutionResult.Code.Ok)
                    {
                        Application.Current.Dispatcher.Dispatch(() =>
                        {
                            resCodeEntry.Text = initResponse.ResponseCode;
                            resMsgEntry.Text = initResponse.ResponseMessage;
                        });
                    }
                    else
                    {
                        Application.Current.Dispatcher.Dispatch(() =>
                        {
                            resMsgEntry.Text = result?.GetErrorCode().ToString();
                        });
                    }
                }
                catch(Exception ex)
                {
                    Console.Write("Exception: {0}", ex);
                }
            });
            thread1.Start();

    }
}


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
#pragma once
#include "POSLinkPluginSet.h"
#include "Tools.h"
#include <thread>

namespace POSLinkSet {

    POSLinkPluginSet::POSLinkPluginSet(){}

    std::optional<FlutterError> POSLinkPluginSet::SetTCPSetting(const TCPSetting& setting)
    {
        std::optional<FlutterError> ret;

        BSTR ip = setting.ip()?Tool::Tools::ParseStringToBSTR(*setting.ip()):SysAllocString(L"");
        int port = setting.port()?std::atoi((*setting.port()).c_str()):-1;
        int timeout = setting.timeout()?(int)*setting.timeout():-1;

        CoInitialize(NULL);
        CLSID clsidTcpSetting;
        CLSIDFromProgID(OLESTR("POSLinkCore.CommunicationSetting.TcpSetting"), &clsidTcpSetting);
        CComPtr<_TcpSetting> tcpSetting = NULL;
        tcpSetting.CoCreateInstance(clsidTcpSetting);
        tcpSetting->put_Ip(ip);
        tcpSetting->put_Port(port);
        tcpSetting->put_Timeout(timeout);
        g_commSetting.CommSetting = NULL;
        tcpSetting.QueryInterface(&g_commSetting.CommSetting);

        return ret;
    }

    std::optional<FlutterError> POSLinkPluginSet::SetAIDLSetting()
    {
        std::optional<FlutterError> ret;
        return ret;
    }

    std::optional<FlutterError> POSLinkPluginSet::SetHttpSetting(const HttpSetting& setting)
    {
        std::optional<FlutterError> ret;

        BSTR ip = setting.ip()?Tool::Tools::ParseStringToBSTR(*setting.ip()):SysAllocString(L"");
        int port = setting.port()?std::atoi((*setting.port()).c_str()):-1;
        int timeout = setting.timeout()?(int)*setting.timeout():-1;

        CoInitialize(NULL);
        CLSID clsidHttpSetting;
        CLSIDFromProgID(OLESTR("POSLinkCore.CommunicationSetting.HttpSetting"), &clsidHttpSetting);
        CComPtr<_HttpSetting> httpSetting = NULL;
        httpSetting.CoCreateInstance(clsidHttpSetting);
        httpSetting->put_Ip(ip);
        httpSetting->put_Port(port);
        httpSetting->put_Timeout(timeout);
        g_commSetting.CommSetting = NULL;
        httpSetting.QueryInterface(&g_commSetting.CommSetting);

        return ret;
    }
    
    std::optional<FlutterError> POSLinkPluginSet::SetHttpsSetting(const HttpsSetting& setting)
    {
        std::optional<FlutterError> ret;

        BSTR ip = setting.ip()?Tool::Tools::ParseStringToBSTR(*setting.ip()):SysAllocString(L"");
        int port = setting.port()?std::atoi((*setting.port()).c_str()):-1;
        int timeout = setting.timeout()?(int)*setting.timeout():-1;

        CoInitialize(NULL);
        CLSID clsidHttpsSetting;
        CLSIDFromProgID(OLESTR("POSLinkCore.CommunicationSetting.HttpsSetting"), &clsidHttpsSetting);
        CComPtr<_HttpsSetting> httpsSetting = NULL;
        httpsSetting.CoCreateInstance(clsidHttpsSetting);
        httpsSetting->put_Ip(ip);
        httpsSetting->put_Port(port);
        httpsSetting->put_Timeout(timeout);
        g_commSetting.CommSetting = NULL;
        httpsSetting.QueryInterface(&g_commSetting.CommSetting);

        return ret;
    }

    std::optional<FlutterError> POSLinkPluginSet::SetSslSetting(const SslSetting& setting)
    {
        std::optional<FlutterError> ret;

        BSTR ip = setting.ip()?Tool::Tools::ParseStringToBSTR(*setting.ip()):SysAllocString(L"");
        int port = setting.port()?std::atoi((*setting.port()).c_str()):-1;
        int timeout = setting.timeout()?(int)*setting.timeout():-1;

        CoInitialize(NULL);
        CLSID clsidSslSetting;
        CLSIDFromProgID(OLESTR("POSLinkCore.CommunicationSetting.SslSetting"), &clsidSslSetting);
        CComPtr<_SslSetting> sslSetting = NULL;
        sslSetting.CoCreateInstance(clsidSslSetting);
        sslSetting->put_Ip(ip);
        sslSetting->put_Port(port);
        sslSetting->put_Timeout(timeout);
        g_commSetting.CommSetting = NULL;
        sslSetting.QueryInterface(&g_commSetting.CommSetting);

        return ret;
    }

    std::optional<FlutterError> POSLinkPluginSet::SetUsbSetting(const UsbSetting& setting)
    {
        std::optional<FlutterError> ret;
        return ret;
    }

    std::optional<FlutterError> POSLinkPluginSet::SetUartSetting(const UartSetting& setting)
    {
        std::optional<FlutterError> ret;

        BSTR serialPort = setting.serial_port()?Tool::Tools::ParseStringToBSTR(*setting.serial_port()):SysAllocString(L"");
        int baudRate = setting.baud_rate()?std::atoi((*setting.baud_rate()).c_str()):-1;
        int timeout = setting.timeout()?(int)*setting.timeout():-1;

        CoInitialize(NULL);
        CLSID clsidUartSetting;
        CLSIDFromProgID(OLESTR("POSLinkUart.UartSetting"), &clsidUartSetting);
        CComPtr<_UartSetting> uartSetting = NULL;
        uartSetting.CoCreateInstance(clsidUartSetting);
        uartSetting->put_SerialPortName(serialPort);
        uartSetting->put_BaudRate(baudRate);
        uartSetting->put_Timeout(timeout);
        g_commSetting.CommSetting = NULL;
        uartSetting.QueryInterface(&g_commSetting.CommSetting);

        return ret;
    }

    ErrorOr<flutter::EncodableList> POSLinkPluginSet::GetUartDevices()
    {
        flutter::EncodableList a;
        ErrorOr<flutter::EncodableList> ret(a);
        return ret;
    }

    std::optional<FlutterError> POSLinkPluginSet::SetBTSetting(const BTSetting& setting)
    {
        std::optional<FlutterError> ret;
        return ret;
    }
    
    void POSLinkPluginSet::Handshake(std::function<void(ErrorOr<bool> reply)> result)
    {
        std::thread t1([result]{
            bool ret = false;
            if(g_commSetting.CommSetting != NULL)
            {
                g_commSetting.GlobalTerminal = NULL;
                g_commSetting.POSLinkFullIntegration->GetTerminal(g_commSetting.CommSetting, &g_commSetting.GlobalTerminal);
            }
            if(g_commSetting.GlobalTerminal != NULL)
            {
                ret = true;
            }
            if(!ret)
            {
                MessageBoxW(nullptr, L"Handshake failed or communication setting error!", L"Warning", MB_OK);
            }
            ErrorOr<bool> reply(ret);
            result(reply);
        });
        t1.detach();
    }

    std::optional<FlutterError> POSLinkPluginSet::Remove()
    {
        std::optional<FlutterError> ret;
        if(g_commSetting.POSLinkFullIntegration != NULL && g_commSetting.GlobalTerminal != NULL)
        {
            g_commSetting.POSLinkFullIntegration->RemoveTerminal(g_commSetting.GlobalTerminal);
        }
        return ret;
    }

    std::optional<FlutterError> POSLinkPluginSet::Cancel()
    {
        std::optional<FlutterError> ret;
        std::thread t1([]{
            if(g_commSetting.GlobalTerminal != NULL)
            {
                g_commSetting.GlobalTerminal->Cancel();
            }
        });
        t1.detach();
        return ret;
    }
}
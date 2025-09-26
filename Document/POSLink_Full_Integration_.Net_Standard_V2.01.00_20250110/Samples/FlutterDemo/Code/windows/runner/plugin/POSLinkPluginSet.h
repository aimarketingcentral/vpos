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
#include <tchar.h>
#include <windows.h>
#include <iostream>
#include <atlbase.h> 
#include <atlstr.h> 
#include "..\poslinkcore.tlh"
#include "..\poslinkuart.tlh"
#include "..\poslinkadmin.tlh"
#include "..\poslinkfullintegration.tlh"
#include "..\pigeon\POSLinkSet.h"
#include "..\poslink_single.h"

namespace POSLinkSet {

    class POSLinkPluginSet: public POSLinkSetApi
    {
        public:
            POSLinkPluginSet();
            std::optional<FlutterError> SetAIDLSetting();
            std::optional<FlutterError> SetTCPSetting(const TCPSetting& setting);
            std::optional<FlutterError> SetHttpSetting(const HttpSetting& setting);
            std::optional<FlutterError> SetHttpsSetting(const HttpsSetting& setting);
            std::optional<FlutterError> SetSslSetting(const SslSetting& setting);
            std::optional<FlutterError> SetUsbSetting(const UsbSetting& setting);
            std::optional<FlutterError> SetUartSetting(const UartSetting& setting);
            ErrorOr<flutter::EncodableList> GetUartDevices();
            std::optional<FlutterError> SetBTSetting(const BTSetting& setting);
            void Handshake(std::function<void(ErrorOr<bool> reply)> result);
            std::optional<FlutterError> Cancel();
            std::optional<FlutterError> Remove();
    };
}
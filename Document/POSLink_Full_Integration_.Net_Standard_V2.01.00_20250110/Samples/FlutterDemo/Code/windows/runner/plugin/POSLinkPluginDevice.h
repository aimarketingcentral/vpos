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
#include <map>
#include "..\poslinkcore.tlh"
#include "..\poslinkadmin.tlh"
#include "..\poslinkadmin.tlh"
#include "..\pigeon\POSLinkDevice.h"
#include "..\poslink_single.h"
#include "Tools.h"
#include "POSLinkDevice\PluginCameraScanRequest.h"
#include "POSLinkDevice\PluginCardInsertDetectionRequest.h"
#include "POSLinkDevice\PluginMifareCardRequest.h"
#include "POSLinkDevice\PluginPrinterRequest.h"
#include "POSLinkDevice\PluginCameraScanResponse.h"
#include "POSLinkDevice\PluginCardInsertDetectionResponse.h"
#include "POSLinkDevice\PluginMifareCardResponse.h"
#include "POSLinkDevice\PluginPrinterResponse.h"

namespace POSLinkDevice {

    class POSLinkPluginDevice: public POSLinkDeviceApi
    {
        public:
            POSLinkPluginDevice();
            void CameraScan(const DeviceCameraScanRequest& req, std::function<void(ErrorOr<DeviceCameraScanResponse> reply)> result);
            void CardInsertDetection(const DeviceCardInsertDetectionRequest& req, std::function<void(ErrorOr<DeviceCardInsertDetectionResponse> reply)> result);
            void MifareCard(const DeviceMifareCardRequest& req, std::function<void(ErrorOr<DeviceMifareCardResponse> reply)> result);
            void Printer(const DevicePrinterRequest& req, std::function<void(ErrorOr<DevicePrinterResponse> reply)> result);
    };
}

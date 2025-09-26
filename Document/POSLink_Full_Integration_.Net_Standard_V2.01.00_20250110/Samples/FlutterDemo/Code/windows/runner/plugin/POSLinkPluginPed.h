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
#include "..\pigeon\POSLinkPed.h"
#include "..\poslink_single.h"
#include "Tools.h"
#include "POSLinkPed\PluginGetPedInformationRequest.h"
#include "POSLinkPed\PluginIncreaseKsnRequest.h"
#include "POSLinkPed\PluginMacCalculationRequest.h"
#include "POSLinkPed\PluginSessionKeyInjectionRequest.h"
#include "POSLinkPed\PluginGetPedInformationResponse.h"
#include "POSLinkPed\PluginIncreaseKsnResponse.h"
#include "POSLinkPed\PluginMacCalculationResponse.h"
#include "POSLinkPed\PluginSessionKeyInjectionResponse.h"

namespace POSLinkPed {

    class POSLinkPluginPed: public POSLinkPedApi
    {
        public:
            POSLinkPluginPed();
            void GetPedInformation(const PedGetPedInformationRequest& req, std::function<void(ErrorOr<PedGetPedInformationResponse> reply)> result);
            void IncreaseKsn(const PedIncreaseKsnRequest& req, std::function<void(ErrorOr<PedIncreaseKsnResponse> reply)> result);
            void MacCalculation(const PedMacCalculationRequest& req, std::function<void(ErrorOr<PedMacCalculationResponse> reply)> result);
            void SessionKeyInjection(const PedSessionKeyInjectionRequest& req, std::function<void(ErrorOr<PedSessionKeyInjectionResponse> reply)> result);
    };
}

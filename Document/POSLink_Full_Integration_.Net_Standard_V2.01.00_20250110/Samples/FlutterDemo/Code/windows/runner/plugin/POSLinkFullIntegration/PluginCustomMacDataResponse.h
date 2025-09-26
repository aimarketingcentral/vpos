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
#include "..\..\poslinkcore.tlh"
#include "..\..\poslinkadmin.tlh"
#include "..\..\poslinkfullintegration.tlh"
#include "..\..\pigeon\POSLinkFullIntegration.h"
#include "..\Tools.h"

namespace POSLinkFullIntegration{
    class PluginCustomMacDataResponse
    {
    public:
        PluginCustomMacDataResponse();
        _CustomMacDataResponse* set(const std::optional<FullIntegrationCustomMacDataResponse>& req);
        const FullIntegrationCustomMacDataResponse* get(_CustomMacDataResponse* rsp);
    private:
        CComPtr<_CustomMacDataResponse> request;
        std::optional<FullIntegrationCustomMacDataResponse> response;
    };
}
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
#include "PluginAdditionalAccountResponse.h"
#include "PluginVasResponse.h"
#include "PluginCustomMacDataResponse.h"

namespace POSLinkFullIntegration{
    class PluginInputAccountWithEmvResponse
    {
    public:
        PluginInputAccountWithEmvResponse();
        _InputAccountWithEmvResponse* set(const std::optional<FullIntegrationInputAccountWithEmvResponse>& req);
        const FullIntegrationInputAccountWithEmvResponse* get(_InputAccountWithEmvResponse* rsp);
    private:
        CComPtr<_InputAccountWithEmvResponse> request;
        std::optional<FullIntegrationInputAccountWithEmvResponse> response;
    };
}
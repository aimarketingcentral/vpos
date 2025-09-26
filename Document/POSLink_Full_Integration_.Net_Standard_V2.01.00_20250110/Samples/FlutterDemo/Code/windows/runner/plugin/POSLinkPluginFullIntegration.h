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
#include "..\poslinkfullintegration.tlh"
#include "..\pigeon\POSLinkFullIntegration.h"
#include "..\poslink_single.h"
#include "Tools.h"
#include "POSLinkFullIntegration\PluginAuthorizeCardRequest.h"
#include "POSLinkFullIntegration\PluginCompleteOnlineEmvRequest.h"
#include "POSLinkFullIntegration\PluginGetEmvTlvDataRequest.h"
#include "POSLinkFullIntegration\PluginGetPinBlockRequest.h"
#include "POSLinkFullIntegration\PluginInputAccountWithEmvRequest.h"
#include "POSLinkFullIntegration\PluginSetEmvTlvDataRequest.h"
#include "POSLinkFullIntegration\PluginAuthorizeCardResponse.h"
#include "POSLinkFullIntegration\PluginCompleteOnlineEmvResponse.h"
#include "POSLinkFullIntegration\PluginGetEmvTlvDataResponse.h"
#include "POSLinkFullIntegration\PluginGetPinBlockResponse.h"
#include "POSLinkFullIntegration\PluginInputAccountWithEmvResponse.h"
#include "POSLinkFullIntegration\PluginSetEmvTlvDataResponse.h"

namespace POSLinkFullIntegration {

    class POSLinkPluginFullIntegration: public POSLinkFullIntegrationApi
    {
        public:
            POSLinkPluginFullIntegration();
            void AuthorizeCard(const FullIntegrationAuthorizeCardRequest& req, std::function<void(ErrorOr<FullIntegrationAuthorizeCardResponse> reply)> result);
            void CompleteOnlineEmv(const FullIntegrationCompleteOnlineEmvRequest& req, std::function<void(ErrorOr<FullIntegrationCompleteOnlineEmvResponse> reply)> result);
            void GetEmvTlvData(const FullIntegrationGetEmvTlvDataRequest& req, std::function<void(ErrorOr<FullIntegrationGetEmvTlvDataResponse> reply)> result);
            void GetPinBlock(const FullIntegrationGetPinBlockRequest& req, std::function<void(ErrorOr<FullIntegrationGetPinBlockResponse> reply)> result);
            void InputAccountWithEmv(const FullIntegrationInputAccountWithEmvRequest& req, std::function<void(ErrorOr<FullIntegrationInputAccountWithEmvResponse> reply)> result);
            void SetEmvTlvData(const FullIntegrationSetEmvTlvDataRequest& req, std::function<void(ErrorOr<FullIntegrationSetEmvTlvDataResponse> reply)> result);
    };
}

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
#include "..\poslinkcore.tlh"
#include "..\poslinkadmin.tlh"
#include "..\poslinkfullintegration.tlh"
#include "..\pigeon\POSLinkMultiCommand.h"
#include "..\poslink_single.h"
#include "Tools.h"
#include "POSLinkPluginDevice.h"
#include "POSLinkPluginForm.h"
#include "POSLinkPluginManage.h"
#include "POSLinkPluginPayload.h"
#include "POSLinkPluginPed.h"
#include "POSLinkPluginFullIntegration.h"
namespace POSLinkMultiCommand{
    class POSLinkPluginMultiCommand: public POSLinkMultiCommandApi
    {
        public:
            POSLinkPluginMultiCommand();
            std::optional<FlutterError> StartMultiCommand();
            std::optional<FlutterError> CancelMultiCommand();
            void CompleteMultiCommand(std::function<void(ErrorOr<Response> reply)> result);
    };
}

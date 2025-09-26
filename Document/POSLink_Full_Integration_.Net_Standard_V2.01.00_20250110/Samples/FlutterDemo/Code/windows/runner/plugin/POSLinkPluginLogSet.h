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
#include "..\pigeon\POSLinkLogSet.h"
#include "..\poslinkcore.tlh"
#include "..\poslinkadmin.tlh"
#include "..\poslinkfullintegration.tlh"
#include "..\poslink_single.h"
#include "Tools.h"
namespace POSLinkLogSet{

    class POSLinkPluginLogSet:public POSLinkLogSetApi
    {
        public:
            POSLinkPluginLogSet();
            std::optional<FlutterError> SetLogSetting(const LogSetting& log_setting);
            void Upload(std::function<void(ErrorOr<UploadResult> reply)> result);
            void GetIosLogList(std::function<void(ErrorOr<flutter::EncodableList> reply)> result);
    };
}
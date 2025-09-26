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
#undef _HAS_EXCEPTIONS
#include "PluginCardInsertDetectionRequest.h"

namespace POSLinkDevice{
    PluginCardInsertDetectionRequest::PluginCardInsertDetectionRequest(){}

    _CardInsertDetectionRequest* PluginCardInsertDetectionRequest::set(const std::optional<DeviceCardInsertDetectionRequest>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidCardInsertDetectionRequest;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Device.CardInsertDetectionRequest"),&clsidCardInsertDetectionRequest);
        request = NULL;
        request.CoCreateInstance(clsidCardInsertDetectionRequest);

        return request;
    }

    const DeviceCardInsertDetectionRequest* PluginCardInsertDetectionRequest::get(_CardInsertDetectionRequest* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = DeviceCardInsertDetectionRequest();

        return &(*response);
    }
}
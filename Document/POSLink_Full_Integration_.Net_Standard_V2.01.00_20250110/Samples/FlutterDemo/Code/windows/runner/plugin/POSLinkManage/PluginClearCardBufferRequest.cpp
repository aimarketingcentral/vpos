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
#include "PluginClearCardBufferRequest.h"

namespace POSLinkManage{
    PluginClearCardBufferRequest::PluginClearCardBufferRequest(){}

    _ClearCardBufferRequest* PluginClearCardBufferRequest::set(const std::optional<ManageClearCardBufferRequest>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidClearCardBufferRequest;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Manage.ClearCardBufferRequest"),&clsidClearCardBufferRequest);
        request = NULL;
        request.CoCreateInstance(clsidClearCardBufferRequest);

        return request;
    }

    const ManageClearCardBufferRequest* PluginClearCardBufferRequest::get(_ClearCardBufferRequest* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = ManageClearCardBufferRequest();

        return &(*response);
    }
}
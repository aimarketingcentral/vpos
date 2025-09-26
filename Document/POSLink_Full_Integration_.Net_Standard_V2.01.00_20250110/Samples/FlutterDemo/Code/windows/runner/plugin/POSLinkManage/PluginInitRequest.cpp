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
#include "PluginInitRequest.h"

namespace POSLinkManage{
    PluginInitRequest::PluginInitRequest(){}

    _InitRequest* PluginInitRequest::set(const std::optional<ManageInitRequest>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidInitRequest;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Manage.InitRequest"),&clsidInitRequest);
        request = NULL;
        request.CoCreateInstance(clsidInitRequest);

        return request;
    }

    const ManageInitRequest* PluginInitRequest::get(_InitRequest* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = ManageInitRequest();

        return &(*response);
    }
}
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
#include "PluginRebootRequest.h"

namespace POSLinkManage{
    PluginRebootRequest::PluginRebootRequest(){}

    _RebootRequest* PluginRebootRequest::set(const std::optional<ManageRebootRequest>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidRebootRequest;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Manage.RebootRequest"),&clsidRebootRequest);
        request = NULL;
        request.CoCreateInstance(clsidRebootRequest);

        return request;
    }

    const ManageRebootRequest* PluginRebootRequest::get(_RebootRequest* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = ManageRebootRequest();

        return &(*response);
    }
}
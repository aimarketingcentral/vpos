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
#include "PluginGetSignatureRequest.h"

namespace POSLinkManage{
    PluginGetSignatureRequest::PluginGetSignatureRequest(){}

    _GetSignatureRequest* PluginGetSignatureRequest::set(const std::optional<ManageGetSignatureRequest>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidGetSignatureRequest;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Manage.GetSignatureRequest"),&clsidGetSignatureRequest);
        request = NULL;
        request.CoCreateInstance(clsidGetSignatureRequest);

        return request;
    }

    const ManageGetSignatureRequest* PluginGetSignatureRequest::get(_GetSignatureRequest* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = ManageGetSignatureRequest();

        return &(*response);
    }
}
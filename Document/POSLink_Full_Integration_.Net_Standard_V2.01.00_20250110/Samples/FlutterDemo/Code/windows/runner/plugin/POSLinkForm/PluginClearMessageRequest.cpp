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
#include "PluginClearMessageRequest.h"

namespace POSLinkForm{
    PluginClearMessageRequest::PluginClearMessageRequest(){}

    _ClearMessageRequest* PluginClearMessageRequest::set(const std::optional<FormClearMessageRequest>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidClearMessageRequest;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Form.ClearMessageRequest"),&clsidClearMessageRequest);
        request = NULL;
        request.CoCreateInstance(clsidClearMessageRequest);

        return request;
    }

    const FormClearMessageRequest* PluginClearMessageRequest::get(_ClearMessageRequest* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = FormClearMessageRequest();

        return &(*response);
    }
}
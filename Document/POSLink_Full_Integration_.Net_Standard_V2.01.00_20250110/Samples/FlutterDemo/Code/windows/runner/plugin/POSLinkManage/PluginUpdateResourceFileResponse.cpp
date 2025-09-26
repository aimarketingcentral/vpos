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
#include "PluginUpdateResourceFileResponse.h"

namespace POSLinkManage{
    PluginUpdateResourceFileResponse::PluginUpdateResourceFileResponse(){}

    _UpdateResourceFileResponse* PluginUpdateResourceFileResponse::set(const std::optional<ManageUpdateResourceFileResponse>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidUpdateResourceFileResponse;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Manage.UpdateResourceFileResponse"),&clsidUpdateResourceFileResponse);
        request = NULL;
        request.CoCreateInstance(clsidUpdateResourceFileResponse);

        return request;
    }

    const ManageUpdateResourceFileResponse* PluginUpdateResourceFileResponse::get(_UpdateResourceFileResponse* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = ManageUpdateResourceFileResponse();

        BSTR responseCode;
        rsp->get_ResponseCode(&responseCode);
        response->set_response_code(Tool::Tools::ParseBSTRToString(responseCode));

        BSTR responseMessage;
        rsp->get_ResponseMessage(&responseMessage);
        response->set_response_message(Tool::Tools::ParseBSTRToString(responseMessage));

        return &(*response);
    }
}
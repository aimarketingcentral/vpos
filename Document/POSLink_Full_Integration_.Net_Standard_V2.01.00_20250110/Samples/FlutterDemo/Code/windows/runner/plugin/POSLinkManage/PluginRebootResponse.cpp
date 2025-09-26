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
#include "PluginRebootResponse.h"

namespace POSLinkManage{
    PluginRebootResponse::PluginRebootResponse(){}

    _RebootResponse* PluginRebootResponse::set(const std::optional<ManageRebootResponse>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidRebootResponse;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Manage.RebootResponse"),&clsidRebootResponse);
        request = NULL;
        request.CoCreateInstance(clsidRebootResponse);

        return request;
    }

    const ManageRebootResponse* PluginRebootResponse::get(_RebootResponse* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = ManageRebootResponse();

        BSTR responseCode;
        rsp->get_ResponseCode(&responseCode);
        response->set_response_code(Tool::Tools::ParseBSTRToString(responseCode));

        BSTR responseMessage;
        rsp->get_ResponseMessage(&responseMessage);
        response->set_response_message(Tool::Tools::ParseBSTRToString(responseMessage));

        return &(*response);
    }
}
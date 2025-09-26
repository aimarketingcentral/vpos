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
#include "PluginSessionKeyInjectionResponse.h"

namespace POSLinkPed{
    PluginSessionKeyInjectionResponse::PluginSessionKeyInjectionResponse(){}

    _SessionKeyInjectionResponse* PluginSessionKeyInjectionResponse::set(const std::optional<PedSessionKeyInjectionResponse>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidSessionKeyInjectionResponse;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Ped.SessionKeyInjectionResponse"),&clsidSessionKeyInjectionResponse);
        request = NULL;
        request.CoCreateInstance(clsidSessionKeyInjectionResponse);

        return request;
    }

    const PedSessionKeyInjectionResponse* PluginSessionKeyInjectionResponse::get(_SessionKeyInjectionResponse* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = PedSessionKeyInjectionResponse();

        BSTR responseCode;
        rsp->get_ResponseCode(&responseCode);
        response->set_response_code(Tool::Tools::ParseBSTRToString(responseCode));

        BSTR responseMessage;
        rsp->get_ResponseMessage(&responseMessage);
        response->set_response_message(Tool::Tools::ParseBSTRToString(responseMessage));

        return &(*response);
    }
}
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
#include "PluginSetApplePayVasParametersResponse.h"

namespace POSLinkManage{
    PluginSetApplePayVasParametersResponse::PluginSetApplePayVasParametersResponse(){}

    _SetApplePayVasParametersResponse* PluginSetApplePayVasParametersResponse::set(const std::optional<ManageSetApplePayVasParametersResponse>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidSetApplePayVasParametersResponse;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Manage.SetApplePayVasParametersResponse"),&clsidSetApplePayVasParametersResponse);
        request = NULL;
        request.CoCreateInstance(clsidSetApplePayVasParametersResponse);

        return request;
    }

    const ManageSetApplePayVasParametersResponse* PluginSetApplePayVasParametersResponse::get(_SetApplePayVasParametersResponse* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = ManageSetApplePayVasParametersResponse();

        BSTR responseCode;
        rsp->get_ResponseCode(&responseCode);
        response->set_response_code(Tool::Tools::ParseBSTRToString(responseCode));

        BSTR responseMessage;
        rsp->get_ResponseMessage(&responseMessage);
        response->set_response_message(Tool::Tools::ParseBSTRToString(responseMessage));

        return &(*response);
    }
}
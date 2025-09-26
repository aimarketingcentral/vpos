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
#include "PluginShowItemResponse.h"

namespace POSLinkForm{
    PluginShowItemResponse::PluginShowItemResponse(){}

    _ShowItemResponse* PluginShowItemResponse::set(const std::optional<FormShowItemResponse>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidShowItemResponse;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Form.ShowItemResponse"),&clsidShowItemResponse);
        request = NULL;
        request.CoCreateInstance(clsidShowItemResponse);

        return request;
    }

    const FormShowItemResponse* PluginShowItemResponse::get(_ShowItemResponse* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = FormShowItemResponse();

        BSTR responseCode;
        rsp->get_ResponseCode(&responseCode);
        response->set_response_code(Tool::Tools::ParseBSTRToString(responseCode));

        BSTR responseMessage;
        rsp->get_ResponseMessage(&responseMessage);
        response->set_response_message(Tool::Tools::ParseBSTRToString(responseMessage));

        return &(*response);
    }
}
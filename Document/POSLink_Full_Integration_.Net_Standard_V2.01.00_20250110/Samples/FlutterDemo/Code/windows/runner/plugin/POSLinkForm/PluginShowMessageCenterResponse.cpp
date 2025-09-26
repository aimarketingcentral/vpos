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
#include "PluginShowMessageCenterResponse.h"

namespace POSLinkForm{
    PluginShowMessageCenterResponse::PluginShowMessageCenterResponse(){}

    _ShowMessageCenterResponse* PluginShowMessageCenterResponse::set(const std::optional<FormShowMessageCenterResponse>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidShowMessageCenterResponse;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Form.ShowMessageCenterResponse"),&clsidShowMessageCenterResponse);
        request = NULL;
        request.CoCreateInstance(clsidShowMessageCenterResponse);

        request->put_PinpadType((PinpadType)*req->pinpad_type());

        return request;
    }

    const FormShowMessageCenterResponse* PluginShowMessageCenterResponse::get(_ShowMessageCenterResponse* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = FormShowMessageCenterResponse();

        BSTR responseCode;
        rsp->get_ResponseCode(&responseCode);
        response->set_response_code(Tool::Tools::ParseBSTRToString(responseCode));

        BSTR responseMessage;
        rsp->get_ResponseMessage(&responseMessage);
        response->set_response_message(Tool::Tools::ParseBSTRToString(responseMessage));

        PinpadType pinpadType;
        rsp->get_PinpadType(&pinpadType);
        response->set_pinpad_type((FormPinpadType)pinpadType);

        return &(*response);
    }
}
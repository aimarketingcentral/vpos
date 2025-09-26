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
#include "PluginInputTextResponse.h"

namespace POSLinkForm{
    PluginInputTextResponse::PluginInputTextResponse(){}

    _InputTextResponse* PluginInputTextResponse::set(const std::optional<FormInputTextResponse>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidInputTextResponse;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Form.InputTextResponse"),&clsidInputTextResponse);
        request = NULL;
        request.CoCreateInstance(clsidInputTextResponse);

        request->put_Text(req->text()?Tool::Tools::ParseStringToBSTR(*req->text()):SysAllocString(L""));

        return request;
    }

    const FormInputTextResponse* PluginInputTextResponse::get(_InputTextResponse* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = FormInputTextResponse();

        BSTR responseCode;
        rsp->get_ResponseCode(&responseCode);
        response->set_response_code(Tool::Tools::ParseBSTRToString(responseCode));

        BSTR responseMessage;
        rsp->get_ResponseMessage(&responseMessage);
        response->set_response_message(Tool::Tools::ParseBSTRToString(responseMessage));

        BSTR text;
        rsp->get_Text(&text);
        response->set_text(Tool::Tools::ParseBSTRToString(text));

        return &(*response);
    }
}
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
#include "PluginShowDialogResponse.h"

namespace POSLinkForm{
    PluginShowDialogResponse::PluginShowDialogResponse(){}

    _ShowDialogResponse* PluginShowDialogResponse::set(const std::optional<FormShowDialogResponse>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidShowDialogResponse;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Form.ShowDialogResponse"),&clsidShowDialogResponse);
        request = NULL;
        request.CoCreateInstance(clsidShowDialogResponse);

        request->put_ButtonNumber(req->button_number()?Tool::Tools::ParseStringToBSTR(*req->button_number()):SysAllocString(L""));

        return request;
    }

    const FormShowDialogResponse* PluginShowDialogResponse::get(_ShowDialogResponse* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = FormShowDialogResponse();

        BSTR responseCode;
        rsp->get_ResponseCode(&responseCode);
        response->set_response_code(Tool::Tools::ParseBSTRToString(responseCode));

        BSTR responseMessage;
        rsp->get_ResponseMessage(&responseMessage);
        response->set_response_message(Tool::Tools::ParseBSTRToString(responseMessage));

        BSTR buttonNumber;
        rsp->get_ButtonNumber(&buttonNumber);
        response->set_button_number(Tool::Tools::ParseBSTRToString(buttonNumber));

        return &(*response);
    }
}
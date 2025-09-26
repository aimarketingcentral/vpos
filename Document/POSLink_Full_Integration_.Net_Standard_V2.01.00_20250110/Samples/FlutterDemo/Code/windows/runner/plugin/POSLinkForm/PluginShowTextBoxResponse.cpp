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
#include "PluginShowTextBoxResponse.h"

namespace POSLinkForm{
    PluginShowTextBoxResponse::PluginShowTextBoxResponse(){}

    _ShowTextBoxResponse* PluginShowTextBoxResponse::set(const std::optional<FormShowTextBoxResponse>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidShowTextBoxResponse;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Form.ShowTextBoxResponse"),&clsidShowTextBoxResponse);
        request = NULL;
        request.CoCreateInstance(clsidShowTextBoxResponse);

        request->put_ButtonNumber(req->button_number()?Tool::Tools::ParseStringToBSTR(*req->button_number()):SysAllocString(L""));

        request->put_SignStatus((SignatureStatus)*req->sign_status());

        request->put_SignatureData(req->signature_data()?Tool::Tools::ParseStringToBSTR(*req->signature_data()):SysAllocString(L""));

        request->put_Text(req->text()?Tool::Tools::ParseStringToBSTR(*req->text()):SysAllocString(L""));

        return request;
    }

    const FormShowTextBoxResponse* PluginShowTextBoxResponse::get(_ShowTextBoxResponse* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = FormShowTextBoxResponse();

        BSTR responseCode;
        rsp->get_ResponseCode(&responseCode);
        response->set_response_code(Tool::Tools::ParseBSTRToString(responseCode));

        BSTR responseMessage;
        rsp->get_ResponseMessage(&responseMessage);
        response->set_response_message(Tool::Tools::ParseBSTRToString(responseMessage));

        BSTR buttonNumber;
        rsp->get_ButtonNumber(&buttonNumber);
        response->set_button_number(Tool::Tools::ParseBSTRToString(buttonNumber));

        SignatureStatus signStatus;
        rsp->get_SignStatus(&signStatus);
        response->set_sign_status((FormSignatureStatus)signStatus);

        BSTR signatureData;
        rsp->get_SignatureData(&signatureData);
        response->set_signature_data(Tool::Tools::ParseBSTRToString(signatureData));

        BSTR text;
        rsp->get_Text(&text);
        response->set_text(Tool::Tools::ParseBSTRToString(text));

        return &(*response);
    }
}
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
#include "PluginShowDialogFormResponse.h"

namespace POSLinkForm{
    PluginShowDialogFormResponse::PluginShowDialogFormResponse(){}

    _ShowDialogFormResponse* PluginShowDialogFormResponse::set(const std::optional<FormShowDialogFormResponse>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidShowDialogFormResponse;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Form.ShowDialogFormResponse"),&clsidShowDialogFormResponse);
        request = NULL;
        request.CoCreateInstance(clsidShowDialogFormResponse);

        request->put_LabelSelected(req->label_selected()?Tool::Tools::ParseStringToBSTR(*req->label_selected()):SysAllocString(L""));

        return request;
    }

    const FormShowDialogFormResponse* PluginShowDialogFormResponse::get(_ShowDialogFormResponse* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = FormShowDialogFormResponse();

        BSTR responseCode;
        rsp->get_ResponseCode(&responseCode);
        response->set_response_code(Tool::Tools::ParseBSTRToString(responseCode));

        BSTR responseMessage;
        rsp->get_ResponseMessage(&responseMessage);
        response->set_response_message(Tool::Tools::ParseBSTRToString(responseMessage));

        BSTR labelSelected;
        rsp->get_LabelSelected(&labelSelected);
        response->set_label_selected(Tool::Tools::ParseBSTRToString(labelSelected));

        return &(*response);
    }
}
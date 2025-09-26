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
#include "PluginGetSignatureResponse.h"

namespace POSLinkManage{
    PluginGetSignatureResponse::PluginGetSignatureResponse(){}

    _GetSignatureResponse* PluginGetSignatureResponse::set(const std::optional<ManageGetSignatureResponse>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidGetSignatureResponse;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Manage.GetSignatureResponse"),&clsidGetSignatureResponse);
        request = NULL;
        request.CoCreateInstance(clsidGetSignatureResponse);

        request->put_SignatureData(req->signature_data()?Tool::Tools::ParseStringToBSTR(*req->signature_data()):SysAllocString(L""));

        return request;
    }

    const ManageGetSignatureResponse* PluginGetSignatureResponse::get(_GetSignatureResponse* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = ManageGetSignatureResponse();

        BSTR responseCode;
        rsp->get_ResponseCode(&responseCode);
        response->set_response_code(Tool::Tools::ParseBSTRToString(responseCode));

        BSTR responseMessage;
        rsp->get_ResponseMessage(&responseMessage);
        response->set_response_message(Tool::Tools::ParseBSTRToString(responseMessage));

        BSTR signatureData;
        rsp->get_SignatureData(&signatureData);
        response->set_signature_data(Tool::Tools::ParseBSTRToString(signatureData));

        return &(*response);
    }
}
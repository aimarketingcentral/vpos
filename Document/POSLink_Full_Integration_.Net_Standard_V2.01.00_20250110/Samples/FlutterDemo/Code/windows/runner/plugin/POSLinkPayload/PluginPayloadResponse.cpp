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
#include "PluginPayloadResponse.h"

namespace POSLinkPayload{
    PluginPayloadResponse::PluginPayloadResponse(){}

    _PayloadResponse* PluginPayloadResponse::set(const std::optional<PayloadPayloadResponse>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidPayloadResponse;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Payload.PayloadResponse"),&clsidPayloadResponse);
        request = NULL;
        request.CoCreateInstance(clsidPayloadResponse);

        request->put_Payload(req->payload()?Tool::Tools::ParseStringToBSTR(*req->payload()):SysAllocString(L""));

        return request;
    }

    const PayloadPayloadResponse* PluginPayloadResponse::get(_PayloadResponse* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = PayloadPayloadResponse();

        BSTR responseCode;
        rsp->get_ResponseCode(&responseCode);
        response->set_response_code(Tool::Tools::ParseBSTRToString(responseCode));

        BSTR responseMessage;
        rsp->get_ResponseMessage(&responseMessage);
        response->set_response_message(Tool::Tools::ParseBSTRToString(responseMessage));

        BSTR payload;
        rsp->get_Payload(&payload);
        response->set_payload(Tool::Tools::ParseBSTRToString(payload));

        return &(*response);
    }
}
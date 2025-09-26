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
#include "PluginPayloadRequest.h"

namespace POSLinkPayload{
    PluginPayloadRequest::PluginPayloadRequest(){}

    _PayloadRequest* PluginPayloadRequest::set(const std::optional<PayloadPayloadRequest>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidPayloadRequest;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Payload.PayloadRequest"),&clsidPayloadRequest);
        request = NULL;
        request.CoCreateInstance(clsidPayloadRequest);

        request->put_Payload(req->payload()?Tool::Tools::ParseStringToBSTR(*req->payload()):SysAllocString(L""));

        return request;
    }

    const PayloadPayloadRequest* PluginPayloadRequest::get(_PayloadRequest* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = PayloadPayloadRequest();

        BSTR payload;
        rsp->get_Payload(&payload);
        response->set_payload(Tool::Tools::ParseBSTRToString(payload));

        return &(*response);
    }
}
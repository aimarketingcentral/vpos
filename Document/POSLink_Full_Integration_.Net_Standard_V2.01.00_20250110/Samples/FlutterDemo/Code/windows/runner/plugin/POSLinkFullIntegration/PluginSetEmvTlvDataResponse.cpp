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
#include "PluginSetEmvTlvDataResponse.h"

namespace POSLinkFullIntegration{
    PluginSetEmvTlvDataResponse::PluginSetEmvTlvDataResponse(){}

    _SetEmvTlvDataResponse* PluginSetEmvTlvDataResponse::set(const std::optional<FullIntegrationSetEmvTlvDataResponse>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidSetEmvTlvDataResponse;
        CLSIDFromProgID(OLESTR("POSLinkFullIntegration.FullIntegration.SetEmvTlvDataResponse"),&clsidSetEmvTlvDataResponse);
        request = NULL;
        request.CoCreateInstance(clsidSetEmvTlvDataResponse);

        request->put_TagList(req->tag_list()?Tool::Tools::ParseStringToBSTR(*req->tag_list()):SysAllocString(L""));

        return request;
    }

    const FullIntegrationSetEmvTlvDataResponse* PluginSetEmvTlvDataResponse::get(_SetEmvTlvDataResponse* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = FullIntegrationSetEmvTlvDataResponse();

        BSTR responseCode;
        rsp->get_ResponseCode(&responseCode);
        response->set_response_code(Tool::Tools::ParseBSTRToString(responseCode));

        BSTR responseMessage;
        rsp->get_ResponseMessage(&responseMessage);
        response->set_response_message(Tool::Tools::ParseBSTRToString(responseMessage));

        BSTR tagList;
        rsp->get_TagList(&tagList);
        response->set_tag_list(Tool::Tools::ParseBSTRToString(tagList));

        return &(*response);
    }
}
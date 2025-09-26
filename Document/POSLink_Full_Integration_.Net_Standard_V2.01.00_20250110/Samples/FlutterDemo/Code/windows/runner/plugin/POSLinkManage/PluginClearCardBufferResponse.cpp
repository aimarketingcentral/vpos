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
#include "PluginClearCardBufferResponse.h"

namespace POSLinkManage{
    PluginClearCardBufferResponse::PluginClearCardBufferResponse(){}

    _ClearCardBufferResponse* PluginClearCardBufferResponse::set(const std::optional<ManageClearCardBufferResponse>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidClearCardBufferResponse;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Manage.ClearCardBufferResponse"),&clsidClearCardBufferResponse);
        request = NULL;
        request.CoCreateInstance(clsidClearCardBufferResponse);

        return request;
    }

    const ManageClearCardBufferResponse* PluginClearCardBufferResponse::get(_ClearCardBufferResponse* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = ManageClearCardBufferResponse();

        BSTR responseCode;
        rsp->get_ResponseCode(&responseCode);
        response->set_response_code(Tool::Tools::ParseBSTRToString(responseCode));

        BSTR responseMessage;
        rsp->get_ResponseMessage(&responseMessage);
        response->set_response_message(Tool::Tools::ParseBSTRToString(responseMessage));

        return &(*response);
    }
}
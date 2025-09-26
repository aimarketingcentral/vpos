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
#include "PluginDeleteImageResponse.h"

namespace POSLinkManage{
    PluginDeleteImageResponse::PluginDeleteImageResponse(){}

    _DeleteImageResponse* PluginDeleteImageResponse::set(const std::optional<ManageDeleteImageResponse>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidDeleteImageResponse;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Manage.DeleteImageResponse"),&clsidDeleteImageResponse);
        request = NULL;
        request.CoCreateInstance(clsidDeleteImageResponse);

        return request;
    }

    const ManageDeleteImageResponse* PluginDeleteImageResponse::get(_DeleteImageResponse* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = ManageDeleteImageResponse();

        BSTR responseCode;
        rsp->get_ResponseCode(&responseCode);
        response->set_response_code(Tool::Tools::ParseBSTRToString(responseCode));

        BSTR responseMessage;
        rsp->get_ResponseMessage(&responseMessage);
        response->set_response_message(Tool::Tools::ParseBSTRToString(responseMessage));

        return &(*response);
    }
}
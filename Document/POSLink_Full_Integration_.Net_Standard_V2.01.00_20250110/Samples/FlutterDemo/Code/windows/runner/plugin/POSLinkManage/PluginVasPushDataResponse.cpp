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
#include "PluginVasPushDataResponse.h"

namespace POSLinkManage{
    PluginVasPushDataResponse::PluginVasPushDataResponse(){}

    _VasPushDataResponse* PluginVasPushDataResponse::set(const std::optional<ManageVasPushDataResponse>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidVasPushDataResponse;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Manage.VasPushDataResponse"),&clsidVasPushDataResponse);
        request = NULL;
        request.CoCreateInstance(clsidVasPushDataResponse);

        return request;
    }

    const ManageVasPushDataResponse* PluginVasPushDataResponse::get(_VasPushDataResponse* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = ManageVasPushDataResponse();

        BSTR responseCode;
        rsp->get_ResponseCode(&responseCode);
        response->set_response_code(Tool::Tools::ParseBSTRToString(responseCode));

        BSTR responseMessage;
        rsp->get_ResponseMessage(&responseMessage);
        response->set_response_message(Tool::Tools::ParseBSTRToString(responseMessage));

        return &(*response);
    }
}
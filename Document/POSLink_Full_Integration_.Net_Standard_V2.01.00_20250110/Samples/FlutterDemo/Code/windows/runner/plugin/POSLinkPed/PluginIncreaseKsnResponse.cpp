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
#include "PluginIncreaseKsnResponse.h"

namespace POSLinkPed{
    PluginIncreaseKsnResponse::PluginIncreaseKsnResponse(){}

    _IncreaseKsnResponse* PluginIncreaseKsnResponse::set(const std::optional<PedIncreaseKsnResponse>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidIncreaseKsnResponse;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Ped.IncreaseKsnResponse"),&clsidIncreaseKsnResponse);
        request = NULL;
        request.CoCreateInstance(clsidIncreaseKsnResponse);

        request->put_Ksn(req->ksn()?Tool::Tools::ParseStringToBSTR(*req->ksn()):SysAllocString(L""));

        return request;
    }

    const PedIncreaseKsnResponse* PluginIncreaseKsnResponse::get(_IncreaseKsnResponse* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = PedIncreaseKsnResponse();

        BSTR responseCode;
        rsp->get_ResponseCode(&responseCode);
        response->set_response_code(Tool::Tools::ParseBSTRToString(responseCode));

        BSTR responseMessage;
        rsp->get_ResponseMessage(&responseMessage);
        response->set_response_message(Tool::Tools::ParseBSTRToString(responseMessage));

        BSTR ksn;
        rsp->get_Ksn(&ksn);
        response->set_ksn(Tool::Tools::ParseBSTRToString(ksn));

        return &(*response);
    }
}
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
#include "PluginCheckFileResponse.h"

namespace POSLinkManage{
    PluginCheckFileResponse::PluginCheckFileResponse(){}

    _CheckFileResponse* PluginCheckFileResponse::set(const std::optional<ManageCheckFileResponse>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidCheckFileResponse;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Manage.CheckFileResponse"),&clsidCheckFileResponse);
        request = NULL;
        request.CoCreateInstance(clsidCheckFileResponse);

        request->put_CheckSum(req->check_sum()?Tool::Tools::ParseStringToBSTR(*req->check_sum()):SysAllocString(L""));

        return request;
    }

    const ManageCheckFileResponse* PluginCheckFileResponse::get(_CheckFileResponse* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = ManageCheckFileResponse();

        BSTR responseCode;
        rsp->get_ResponseCode(&responseCode);
        response->set_response_code(Tool::Tools::ParseBSTRToString(responseCode));

        BSTR responseMessage;
        rsp->get_ResponseMessage(&responseMessage);
        response->set_response_message(Tool::Tools::ParseBSTRToString(responseMessage));

        BSTR checkSum;
        rsp->get_CheckSum(&checkSum);
        response->set_check_sum(Tool::Tools::ParseBSTRToString(checkSum));

        return &(*response);
    }
}
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
#include "PluginMacCalculationResponse.h"

namespace POSLinkPed{
    PluginMacCalculationResponse::PluginMacCalculationResponse(){}

    _MacCalculationResponse* PluginMacCalculationResponse::set(const std::optional<PedMacCalculationResponse>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidMacCalculationResponse;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Ped.MacCalculationResponse"),&clsidMacCalculationResponse);
        request = NULL;
        request.CoCreateInstance(clsidMacCalculationResponse);

        request->put_ResultData(req->result_data()?Tool::Tools::ParseStringToBSTR(*req->result_data()):SysAllocString(L""));

        request->put_Ksn(req->ksn()?Tool::Tools::ParseStringToBSTR(*req->ksn()):SysAllocString(L""));

        return request;
    }

    const PedMacCalculationResponse* PluginMacCalculationResponse::get(_MacCalculationResponse* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = PedMacCalculationResponse();

        BSTR responseCode;
        rsp->get_ResponseCode(&responseCode);
        response->set_response_code(Tool::Tools::ParseBSTRToString(responseCode));

        BSTR responseMessage;
        rsp->get_ResponseMessage(&responseMessage);
        response->set_response_message(Tool::Tools::ParseBSTRToString(responseMessage));

        BSTR resultData;
        rsp->get_ResultData(&resultData);
        response->set_result_data(Tool::Tools::ParseBSTRToString(resultData));

        BSTR ksn;
        rsp->get_Ksn(&ksn);
        response->set_ksn(Tool::Tools::ParseBSTRToString(ksn));

        return &(*response);
    }
}
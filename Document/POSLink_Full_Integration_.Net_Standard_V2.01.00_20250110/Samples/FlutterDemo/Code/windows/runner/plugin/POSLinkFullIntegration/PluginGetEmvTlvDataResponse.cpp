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
#include "PluginGetEmvTlvDataResponse.h"

namespace POSLinkFullIntegration{
    PluginGetEmvTlvDataResponse::PluginGetEmvTlvDataResponse(){}

    _GetEmvTlvDataResponse* PluginGetEmvTlvDataResponse::set(const std::optional<FullIntegrationGetEmvTlvDataResponse>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidGetEmvTlvDataResponse;
        CLSIDFromProgID(OLESTR("POSLinkFullIntegration.FullIntegration.GetEmvTlvDataResponse"),&clsidGetEmvTlvDataResponse);
        request = NULL;
        request.CoCreateInstance(clsidGetEmvTlvDataResponse);

        request->put_EmvTlvData(req->emv_tlv_data()?Tool::Tools::ParseStringToBSTR(*req->emv_tlv_data()):SysAllocString(L""));

        return request;
    }

    const FullIntegrationGetEmvTlvDataResponse* PluginGetEmvTlvDataResponse::get(_GetEmvTlvDataResponse* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = FullIntegrationGetEmvTlvDataResponse();

        BSTR responseCode;
        rsp->get_ResponseCode(&responseCode);
        response->set_response_code(Tool::Tools::ParseBSTRToString(responseCode));

        BSTR responseMessage;
        rsp->get_ResponseMessage(&responseMessage);
        response->set_response_message(Tool::Tools::ParseBSTRToString(responseMessage));

        BSTR emvTlvData;
        rsp->get_EmvTlvData(&emvTlvData);
        response->set_emv_tlv_data(Tool::Tools::ParseBSTRToString(emvTlvData));

        return &(*response);
    }
}
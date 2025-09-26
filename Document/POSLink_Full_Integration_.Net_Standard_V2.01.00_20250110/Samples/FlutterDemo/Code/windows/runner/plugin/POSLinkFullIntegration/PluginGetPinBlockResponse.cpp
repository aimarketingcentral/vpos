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
#include "PluginGetPinBlockResponse.h"

namespace POSLinkFullIntegration{
    PluginGetPinBlockResponse::PluginGetPinBlockResponse(){}

    _GetPinBlockResponse* PluginGetPinBlockResponse::set(const std::optional<FullIntegrationGetPinBlockResponse>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidGetPinBlockResponse;
        CLSIDFromProgID(OLESTR("POSLinkFullIntegration.FullIntegration.GetPinBlockResponse"),&clsidGetPinBlockResponse);
        request = NULL;
        request.CoCreateInstance(clsidGetPinBlockResponse);

        request->put_PinBlock(req->pin_block()?Tool::Tools::ParseStringToBSTR(*req->pin_block()):SysAllocString(L""));

        request->put_Ksn(req->ksn()?Tool::Tools::ParseStringToBSTR(*req->ksn()):SysAllocString(L""));

        request->put_PinpadType((PinpadType)*req->pinpad_type());

        return request;
    }

    const FullIntegrationGetPinBlockResponse* PluginGetPinBlockResponse::get(_GetPinBlockResponse* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = FullIntegrationGetPinBlockResponse();

        BSTR responseCode;
        rsp->get_ResponseCode(&responseCode);
        response->set_response_code(Tool::Tools::ParseBSTRToString(responseCode));

        BSTR responseMessage;
        rsp->get_ResponseMessage(&responseMessage);
        response->set_response_message(Tool::Tools::ParseBSTRToString(responseMessage));

        BSTR pinBlock;
        rsp->get_PinBlock(&pinBlock);
        response->set_pin_block(Tool::Tools::ParseBSTRToString(pinBlock));

        BSTR ksn;
        rsp->get_Ksn(&ksn);
        response->set_ksn(Tool::Tools::ParseBSTRToString(ksn));

        PinpadType pinpadType;
        rsp->get_PinpadType(&pinpadType);
        response->set_pinpad_type((FullIntegrationPinpadType)pinpadType);

        return &(*response);
    }
}
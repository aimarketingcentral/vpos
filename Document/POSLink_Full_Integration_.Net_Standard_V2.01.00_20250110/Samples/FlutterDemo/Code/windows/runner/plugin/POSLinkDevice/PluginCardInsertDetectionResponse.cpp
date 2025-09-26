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
#include "PluginCardInsertDetectionResponse.h"

namespace POSLinkDevice{
    PluginCardInsertDetectionResponse::PluginCardInsertDetectionResponse(){}

    _CardInsertDetectionResponse* PluginCardInsertDetectionResponse::set(const std::optional<DeviceCardInsertDetectionResponse>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidCardInsertDetectionResponse;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Device.CardInsertDetectionResponse"),&clsidCardInsertDetectionResponse);
        request = NULL;
        request.CoCreateInstance(clsidCardInsertDetectionResponse);

        request->put_CardInsertStatus((CardInsertStatus)*req->card_insert_status());

        return request;
    }

    const DeviceCardInsertDetectionResponse* PluginCardInsertDetectionResponse::get(_CardInsertDetectionResponse* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = DeviceCardInsertDetectionResponse();

        BSTR responseCode;
        rsp->get_ResponseCode(&responseCode);
        response->set_response_code(Tool::Tools::ParseBSTRToString(responseCode));

        BSTR responseMessage;
        rsp->get_ResponseMessage(&responseMessage);
        response->set_response_message(Tool::Tools::ParseBSTRToString(responseMessage));

        CardInsertStatus cardInsertStatus;
        rsp->get_CardInsertStatus(&cardInsertStatus);
        response->set_card_insert_status((DeviceCardInsertStatus)cardInsertStatus);

        return &(*response);
    }
}
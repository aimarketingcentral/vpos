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
#include "PluginCameraScanResponse.h"

namespace POSLinkDevice{
    PluginCameraScanResponse::PluginCameraScanResponse(){}

    _CameraScanResponse* PluginCameraScanResponse::set(const std::optional<DeviceCameraScanResponse>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidCameraScanResponse;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Device.CameraScanResponse"),&clsidCameraScanResponse);
        request = NULL;
        request.CoCreateInstance(clsidCameraScanResponse);

        request->put_BarcodeData(req->barcode_data()?Tool::Tools::ParseStringToBSTR(*req->barcode_data()):SysAllocString(L""));

        request->put_BarcodeType((BarcodeType)*req->barcode_type());

        return request;
    }

    const DeviceCameraScanResponse* PluginCameraScanResponse::get(_CameraScanResponse* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = DeviceCameraScanResponse();

        BSTR responseCode;
        rsp->get_ResponseCode(&responseCode);
        response->set_response_code(Tool::Tools::ParseBSTRToString(responseCode));

        BSTR responseMessage;
        rsp->get_ResponseMessage(&responseMessage);
        response->set_response_message(Tool::Tools::ParseBSTRToString(responseMessage));

        BSTR barcodeData;
        rsp->get_BarcodeData(&barcodeData);
        response->set_barcode_data(Tool::Tools::ParseBSTRToString(barcodeData));

        BarcodeType barcodeType;
        rsp->get_BarcodeType(&barcodeType);
        response->set_barcode_type((DeviceBarcodeType)barcodeType);

        return &(*response);
    }
}
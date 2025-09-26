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
#include "PluginCameraScanRequest.h"

namespace POSLinkDevice{
    PluginCameraScanRequest::PluginCameraScanRequest(){}

    _CameraScanRequest* PluginCameraScanRequest::set(const std::optional<DeviceCameraScanRequest>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidCameraScanRequest;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Device.CameraScanRequest"),&clsidCameraScanRequest);
        request = NULL;
        request.CoCreateInstance(clsidCameraScanRequest);

        request->put_Reader((ReaderType)*req->reader());

        request->put_Timeout(req->timeout()?Tool::Tools::ParseStringToBSTR(*req->timeout()):SysAllocString(L""));

        return request;
    }

    const DeviceCameraScanRequest* PluginCameraScanRequest::get(_CameraScanRequest* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = DeviceCameraScanRequest();

        ReaderType reader;
        rsp->get_Reader(&reader);
        response->set_reader((DeviceReaderType)reader);

        BSTR timeout;
        rsp->get_Timeout(&timeout);
        response->set_timeout(Tool::Tools::ParseBSTRToString(timeout));

        return &(*response);
    }
}
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
#include "PluginPrinterRequest.h"

namespace POSLinkDevice{
    PluginPrinterRequest::PluginPrinterRequest(){}

    _PrinterRequest* PluginPrinterRequest::set(const std::optional<DevicePrinterRequest>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidPrinterRequest;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Device.PrinterRequest"),&clsidPrinterRequest);
        request = NULL;
        request.CoCreateInstance(clsidPrinterRequest);

        request->put_PrintCopy(req->print_copy()?Tool::Tools::ParseStringToBSTR(*req->print_copy()):SysAllocString(L""));

        request->put_PrintData(req->print_data()?Tool::Tools::ParseStringToBSTR(*req->print_data()):SysAllocString(L""));

        return request;
    }

    const DevicePrinterRequest* PluginPrinterRequest::get(_PrinterRequest* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = DevicePrinterRequest();

        BSTR printCopy;
        rsp->get_PrintCopy(&printCopy);
        response->set_print_copy(Tool::Tools::ParseBSTRToString(printCopy));

        BSTR printData;
        rsp->get_PrintData(&printData);
        response->set_print_data(Tool::Tools::ParseBSTRToString(printData));

        return &(*response);
    }
}
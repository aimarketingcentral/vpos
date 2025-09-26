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
#include "PluginSetEmvTlvDataRequest.h"

namespace POSLinkFullIntegration{
    PluginSetEmvTlvDataRequest::PluginSetEmvTlvDataRequest(){}

    _SetEmvTlvDataRequest* PluginSetEmvTlvDataRequest::set(const std::optional<FullIntegrationSetEmvTlvDataRequest>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidSetEmvTlvDataRequest;
        CLSIDFromProgID(OLESTR("POSLinkFullIntegration.FullIntegration.SetEmvTlvDataRequest"),&clsidSetEmvTlvDataRequest);
        request = NULL;
        request.CoCreateInstance(clsidSetEmvTlvDataRequest);

        request->put_TlvType((TlvType)*req->tlv_type());

        request->put_EmvTlvData(req->emv_tlv_data()?Tool::Tools::ParseStringToBSTR(*req->emv_tlv_data()):SysAllocString(L""));

        return request;
    }

    const FullIntegrationSetEmvTlvDataRequest* PluginSetEmvTlvDataRequest::get(_SetEmvTlvDataRequest* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = FullIntegrationSetEmvTlvDataRequest();

        TlvType tlvType;
        rsp->get_TlvType(&tlvType);
        response->set_tlv_type((FullIntegrationTlvType)tlvType);

        BSTR emvTlvData;
        rsp->get_EmvTlvData(&emvTlvData);
        response->set_emv_tlv_data(Tool::Tools::ParseBSTRToString(emvTlvData));

        return &(*response);
    }
}
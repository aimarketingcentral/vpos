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
#include "PluginGetEmvTlvDataRequest.h"

namespace POSLinkFullIntegration{
    PluginGetEmvTlvDataRequest::PluginGetEmvTlvDataRequest(){}

    _GetEmvTlvDataRequest* PluginGetEmvTlvDataRequest::set(const std::optional<FullIntegrationGetEmvTlvDataRequest>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidGetEmvTlvDataRequest;
        CLSIDFromProgID(OLESTR("POSLinkFullIntegration.FullIntegration.GetEmvTlvDataRequest"),&clsidGetEmvTlvDataRequest);
        request = NULL;
        request.CoCreateInstance(clsidGetEmvTlvDataRequest);

        request->put_TlvType((TlvType)*req->tlv_type());

        request->put_TagList(req->tag_list()?Tool::Tools::ParseStringToBSTR(*req->tag_list()):SysAllocString(L""));

        return request;
    }

    const FullIntegrationGetEmvTlvDataRequest* PluginGetEmvTlvDataRequest::get(_GetEmvTlvDataRequest* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = FullIntegrationGetEmvTlvDataRequest();

        TlvType tlvType;
        rsp->get_TlvType(&tlvType);
        response->set_tlv_type((FullIntegrationTlvType)tlvType);

        BSTR tagList;
        rsp->get_TagList(&tagList);
        response->set_tag_list(Tool::Tools::ParseBSTRToString(tagList));

        return &(*response);
    }
}
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
#include "PluginSessionKeyInjectionRequest.h"

namespace POSLinkPed{
    PluginSessionKeyInjectionRequest::PluginSessionKeyInjectionRequest(){}

    _SessionKeyInjectionRequest* PluginSessionKeyInjectionRequest::set(const std::optional<PedSessionKeyInjectionRequest>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidSessionKeyInjectionRequest;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Ped.SessionKeyInjectionRequest"),&clsidSessionKeyInjectionRequest);
        request = NULL;
        request.CoCreateInstance(clsidSessionKeyInjectionRequest);

        request->put_SourceKeyType(req->source_key_type()?Tool::Tools::ParseStringToBSTR(*req->source_key_type()):SysAllocString(L""));

        request->put_SourceKeyIndex(req->source_key_index()?Tool::Tools::ParseStringToBSTR(*req->source_key_index()):SysAllocString(L""));

        request->put_DestinationKeyType((DestinationKeyType)*req->destination_key_type());

        request->put_DestinationKeyIndex(req->destination_key_index()?Tool::Tools::ParseStringToBSTR(*req->destination_key_index()):SysAllocString(L""));

        request->put_DestinationKeyValue(req->destination_key_value()?Tool::Tools::ParseStringToBSTR(*req->destination_key_value()):SysAllocString(L""));

        request->put_CheckMode((CheckMode)*req->check_mode());

        request->put_CheckBuffer(req->check_buffer()?Tool::Tools::ParseStringToBSTR(*req->check_buffer()):SysAllocString(L""));

        return request;
    }

    const PedSessionKeyInjectionRequest* PluginSessionKeyInjectionRequest::get(_SessionKeyInjectionRequest* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = PedSessionKeyInjectionRequest();

        BSTR sourceKeyType;
        rsp->get_SourceKeyType(&sourceKeyType);
        response->set_source_key_type(Tool::Tools::ParseBSTRToString(sourceKeyType));

        BSTR sourceKeyIndex;
        rsp->get_SourceKeyIndex(&sourceKeyIndex);
        response->set_source_key_index(Tool::Tools::ParseBSTRToString(sourceKeyIndex));

        DestinationKeyType destinationKeyType;
        rsp->get_DestinationKeyType(&destinationKeyType);
        response->set_destination_key_type((PedDestinationKeyType)destinationKeyType);

        BSTR destinationKeyIndex;
        rsp->get_DestinationKeyIndex(&destinationKeyIndex);
        response->set_destination_key_index(Tool::Tools::ParseBSTRToString(destinationKeyIndex));

        BSTR destinationKeyValue;
        rsp->get_DestinationKeyValue(&destinationKeyValue);
        response->set_destination_key_value(Tool::Tools::ParseBSTRToString(destinationKeyValue));

        CheckMode checkMode;
        rsp->get_CheckMode(&checkMode);
        response->set_check_mode((PedCheckMode)checkMode);

        BSTR checkBuffer;
        rsp->get_CheckBuffer(&checkBuffer);
        response->set_check_buffer(Tool::Tools::ParseBSTRToString(checkBuffer));

        return &(*response);
    }
}
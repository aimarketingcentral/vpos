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
#include "PluginIncreaseKsnRequest.h"

namespace POSLinkPed{
    PluginIncreaseKsnRequest::PluginIncreaseKsnRequest(){}

    _IncreaseKsnRequest* PluginIncreaseKsnRequest::set(const std::optional<PedIncreaseKsnRequest>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidIncreaseKsnRequest;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Ped.IncreaseKsnRequest"),&clsidIncreaseKsnRequest);
        request = NULL;
        request.CoCreateInstance(clsidIncreaseKsnRequest);

        request->put_KeyType((KeyType)*req->key_type());

        request->put_KeySlot(req->key_slot()?Tool::Tools::ParseStringToBSTR(*req->key_slot()):SysAllocString(L""));

        return request;
    }

    const PedIncreaseKsnRequest* PluginIncreaseKsnRequest::get(_IncreaseKsnRequest* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = PedIncreaseKsnRequest();

        KeyType keyType;
        rsp->get_KeyType(&keyType);
        response->set_key_type((PedKeyType)keyType);

        BSTR keySlot;
        rsp->get_KeySlot(&keySlot);
        response->set_key_slot(Tool::Tools::ParseBSTRToString(keySlot));

        return &(*response);
    }
}
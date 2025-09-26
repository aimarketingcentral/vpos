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
#include "PluginDukptKeyInformation.h"

namespace POSLinkPed{
    PluginDukptKeyInformation::PluginDukptKeyInformation(){}

    _DukptKeyInformation* PluginDukptKeyInformation::set(const std::optional<PedDukptKeyInformation>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidDukptKeyInformation;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Ped.DukptKeyInformation"),&clsidDukptKeyInformation);
        request = NULL;
        request.CoCreateInstance(clsidDukptKeyInformation);

        request->put_KeySlot(req->key_slot()?Tool::Tools::ParseStringToBSTR(*req->key_slot()):SysAllocString(L""));

        request->put_Ksn(req->ksn()?Tool::Tools::ParseStringToBSTR(*req->ksn()):SysAllocString(L""));

        request->put_Kcv(req->kcv()?Tool::Tools::ParseStringToBSTR(*req->kcv()):SysAllocString(L""));

        return request;
    }

    const PedDukptKeyInformation* PluginDukptKeyInformation::get(_DukptKeyInformation* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = PedDukptKeyInformation();

        BSTR keySlot;
        rsp->get_KeySlot(&keySlot);
        response->set_key_slot(Tool::Tools::ParseBSTRToString(keySlot));

        BSTR ksn;
        rsp->get_Ksn(&ksn);
        response->set_ksn(Tool::Tools::ParseBSTRToString(ksn));

        BSTR kcv;
        rsp->get_Kcv(&kcv);
        response->set_kcv(Tool::Tools::ParseBSTRToString(kcv));

        return &(*response);
    }
}
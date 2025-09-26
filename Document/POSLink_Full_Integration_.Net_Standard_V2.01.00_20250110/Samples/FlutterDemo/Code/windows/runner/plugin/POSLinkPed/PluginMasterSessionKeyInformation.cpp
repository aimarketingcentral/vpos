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
#include "PluginMasterSessionKeyInformation.h"

namespace POSLinkPed{
    PluginMasterSessionKeyInformation::PluginMasterSessionKeyInformation(){}

    _MasterSessionKeyInformation* PluginMasterSessionKeyInformation::set(const std::optional<PedMasterSessionKeyInformation>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidMasterSessionKeyInformation;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Ped.MasterSessionKeyInformation"),&clsidMasterSessionKeyInformation);
        request = NULL;
        request.CoCreateInstance(clsidMasterSessionKeyInformation);

        request->put_KeySlot(req->key_slot()?Tool::Tools::ParseStringToBSTR(*req->key_slot()):SysAllocString(L""));

        request->put_Kcv(req->kcv()?Tool::Tools::ParseStringToBSTR(*req->kcv()):SysAllocString(L""));

        return request;
    }

    const PedMasterSessionKeyInformation* PluginMasterSessionKeyInformation::get(_MasterSessionKeyInformation* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = PedMasterSessionKeyInformation();

        BSTR keySlot;
        rsp->get_KeySlot(&keySlot);
        response->set_key_slot(Tool::Tools::ParseBSTRToString(keySlot));

        BSTR kcv;
        rsp->get_Kcv(&kcv);
        response->set_kcv(Tool::Tools::ParseBSTRToString(kcv));

        return &(*response);
    }
}
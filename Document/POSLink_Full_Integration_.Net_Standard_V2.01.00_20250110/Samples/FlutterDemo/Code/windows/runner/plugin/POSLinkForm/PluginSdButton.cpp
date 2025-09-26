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
#include "PluginSdButton.h"

namespace POSLinkForm{
    PluginSdButton::PluginSdButton(){}

    _SdButton* PluginSdButton::set(const std::optional<FormSdButton>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidSdButton;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Util.SdButton"),&clsidSdButton);
        request = NULL;
        request.CoCreateInstance(clsidSdButton);

        request->put_Name(req->name()?Tool::Tools::ParseStringToBSTR(*req->name()):SysAllocString(L""));

        return request;
    }

    const FormSdButton* PluginSdButton::get(_SdButton* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = FormSdButton();

        BSTR name;
        rsp->get_Name(&name);
        response->set_name(Tool::Tools::ParseBSTRToString(name));

        return &(*response);
    }
}
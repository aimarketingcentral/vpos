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
#include "PluginStbButton.h"

namespace POSLinkForm{
    PluginStbButton::PluginStbButton(){}

    _StbButton* PluginStbButton::set(const std::optional<FormStbButton>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidStbButton;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Util.StbButton"),&clsidStbButton);
        request = NULL;
        request.CoCreateInstance(clsidStbButton);

        request->put_Name(req->name()?Tool::Tools::ParseStringToBSTR(*req->name()):SysAllocString(L""));

        request->put_Color(req->color()?Tool::Tools::ParseStringToBSTR(*req->color()):SysAllocString(L""));

        request->put_HardKey((HardKey)*req->hard_key());

        return request;
    }

    const FormStbButton* PluginStbButton::get(_StbButton* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = FormStbButton();

        BSTR name;
        rsp->get_Name(&name);
        response->set_name(Tool::Tools::ParseBSTRToString(name));

        BSTR color;
        rsp->get_Color(&color);
        response->set_color(Tool::Tools::ParseBSTRToString(color));

        HardKey hardKey;
        rsp->get_HardKey(&hardKey);
        response->set_hard_key((FormHardKey)hardKey);

        return &(*response);
    }
}
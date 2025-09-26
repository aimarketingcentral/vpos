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
#include "PluginNewService.h"

namespace POSLinkManage{
    PluginNewService::PluginNewService(){}

    _NewService* PluginNewService::set(const std::optional<ManageNewService>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidNewService;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Manage.NewService"),&clsidNewService);
        request = NULL;
        request.CoCreateInstance(clsidNewService);

        request->put_Type((NewServiceType)*req->type());

        request->put_Title(req->title()?Tool::Tools::ParseStringToBSTR(*req->title()):SysAllocString(L""));

        request->put_Url(req->url()?Tool::Tools::ParseStringToBSTR(*req->url()):SysAllocString(L""));

        return request;
    }

    const ManageNewService* PluginNewService::get(_NewService* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = ManageNewService();

        NewServiceType type;
        rsp->get_Type(&type);
        response->set_type((ManageNewServiceType)type);

        BSTR title;
        rsp->get_Title(&title);
        response->set_title(Tool::Tools::ParseBSTRToString(title));

        BSTR url;
        rsp->get_Url(&url);
        response->set_url(Tool::Tools::ParseBSTRToString(url));

        return &(*response);
    }
}
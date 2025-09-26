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
#include "PluginServiceUsage.h"

namespace POSLinkManage{
    PluginServiceUsage::PluginServiceUsage(){}

    _ServiceUsage* PluginServiceUsage::set(const std::optional<ManageServiceUsage>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidServiceUsage;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Manage.ServiceUsage"),&clsidServiceUsage);
        request = NULL;
        request.CoCreateInstance(clsidServiceUsage);

        request->put_UsageId(req->usage_id()?Tool::Tools::ParseStringToBSTR(*req->usage_id()):SysAllocString(L""));

        request->put_State((ServiceState)*req->state());

        request->put_Title(req->title()?Tool::Tools::ParseStringToBSTR(*req->title()):SysAllocString(L""));

        request->put_Describe(req->describe()?Tool::Tools::ParseStringToBSTR(*req->describe()):SysAllocString(L""));

        return request;
    }

    const ManageServiceUsage* PluginServiceUsage::get(_ServiceUsage* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = ManageServiceUsage();

        BSTR usageId;
        rsp->get_UsageId(&usageId);
        response->set_usage_id(Tool::Tools::ParseBSTRToString(usageId));

        ServiceState state;
        rsp->get_State(&state);
        response->set_state((ManageServiceState)state);

        BSTR title;
        rsp->get_Title(&title);
        response->set_title(Tool::Tools::ParseBSTRToString(title));

        BSTR describe;
        rsp->get_Describe(&describe);
        response->set_describe(Tool::Tools::ParseBSTRToString(describe));

        return &(*response);
    }
}
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
#include "PluginServiceUpdate.h"

namespace POSLinkManage{
    PluginServiceUpdate::PluginServiceUpdate(){}

    _ServiceUpdate* PluginServiceUpdate::set(const std::optional<ManageServiceUpdate>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidServiceUpdate;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Manage.ServiceUpdate"),&clsidServiceUpdate);
        request = NULL;
        request.CoCreateInstance(clsidServiceUpdate);

        request->put_UpdateId(req->update_id()?Tool::Tools::ParseStringToBSTR(*req->update_id()):SysAllocString(L""));

        request->put_UpdateOperation((UpdateOperation)*req->update_operation());

        request->put_UpdatePayload(req->update_payload()?Tool::Tools::ParseStringToBSTR(*req->update_payload()):SysAllocString(L""));

        return request;
    }

    const ManageServiceUpdate* PluginServiceUpdate::get(_ServiceUpdate* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = ManageServiceUpdate();

        BSTR updateId;
        rsp->get_UpdateId(&updateId);
        response->set_update_id(Tool::Tools::ParseBSTRToString(updateId));

        UpdateOperation updateOperation;
        rsp->get_UpdateOperation(&updateOperation);
        response->set_update_operation((ManageUpdateOperation)updateOperation);

        BSTR updatePayload;
        rsp->get_UpdatePayload(&updatePayload);
        response->set_update_payload(Tool::Tools::ParseBSTRToString(updatePayload));

        return &(*response);
    }
}
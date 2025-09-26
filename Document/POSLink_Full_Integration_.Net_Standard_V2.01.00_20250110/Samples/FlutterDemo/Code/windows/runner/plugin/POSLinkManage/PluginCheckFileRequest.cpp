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
#include "PluginCheckFileRequest.h"

namespace POSLinkManage{
    PluginCheckFileRequest::PluginCheckFileRequest(){}

    _CheckFileRequest* PluginCheckFileRequest::set(const std::optional<ManageCheckFileRequest>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidCheckFileRequest;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Manage.CheckFileRequest"),&clsidCheckFileRequest);
        request = NULL;
        request.CoCreateInstance(clsidCheckFileRequest);

        request->put_FileName(req->file_name()?Tool::Tools::ParseStringToBSTR(*req->file_name()):SysAllocString(L""));

        return request;
    }

    const ManageCheckFileRequest* PluginCheckFileRequest::get(_CheckFileRequest* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = ManageCheckFileRequest();

        BSTR fileName;
        rsp->get_FileName(&fileName);
        response->set_file_name(Tool::Tools::ParseBSTRToString(fileName));

        return &(*response);
    }
}
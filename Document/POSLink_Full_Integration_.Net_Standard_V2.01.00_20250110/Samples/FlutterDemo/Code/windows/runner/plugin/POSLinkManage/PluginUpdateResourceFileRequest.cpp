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
#include "PluginUpdateResourceFileRequest.h"

namespace POSLinkManage{
    PluginUpdateResourceFileRequest::PluginUpdateResourceFileRequest(){}

    _UpdateResourceFileRequest* PluginUpdateResourceFileRequest::set(const std::optional<ManageUpdateResourceFileRequest>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidUpdateResourceFileRequest;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Manage.UpdateResourceFileRequest"),&clsidUpdateResourceFileRequest);
        request = NULL;
        request.CoCreateInstance(clsidUpdateResourceFileRequest);

        request->put_FileUrl(req->file_url()?Tool::Tools::ParseStringToBSTR(*req->file_url()):SysAllocString(L""));

        request->put_FileType((FileType)*req->file_type());

        request->put_TargetDevice((TargetDevice)*req->target_device());

        return request;
    }

    const ManageUpdateResourceFileRequest* PluginUpdateResourceFileRequest::get(_UpdateResourceFileRequest* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = ManageUpdateResourceFileRequest();

        BSTR fileUrl;
        rsp->get_FileUrl(&fileUrl);
        response->set_file_url(Tool::Tools::ParseBSTRToString(fileUrl));

        FileType fileType;
        rsp->get_FileType(&fileType);
        response->set_file_type((ManageFileType)fileType);

        TargetDevice targetDevice;
        rsp->get_TargetDevice(&targetDevice);
        response->set_target_device((ManageTargetDevice)targetDevice);

        return &(*response);
    }
}
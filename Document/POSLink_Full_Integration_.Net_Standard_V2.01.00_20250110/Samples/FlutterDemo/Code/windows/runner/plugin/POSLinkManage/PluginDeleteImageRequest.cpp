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
#include "PluginDeleteImageRequest.h"

namespace POSLinkManage{
    PluginDeleteImageRequest::PluginDeleteImageRequest(){}

    _DeleteImageRequest* PluginDeleteImageRequest::set(const std::optional<ManageDeleteImageRequest>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidDeleteImageRequest;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Manage.DeleteImageRequest"),&clsidDeleteImageRequest);
        request = NULL;
        request.CoCreateInstance(clsidDeleteImageRequest);

        request->put_ImageName(req->image_name()?Tool::Tools::ParseStringToBSTR(*req->image_name()):SysAllocString(L""));

        return request;
    }

    const ManageDeleteImageRequest* PluginDeleteImageRequest::get(_DeleteImageRequest* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = ManageDeleteImageRequest();

        BSTR imageName;
        rsp->get_ImageName(&imageName);
        response->set_image_name(Tool::Tools::ParseBSTRToString(imageName));

        return &(*response);
    }
}
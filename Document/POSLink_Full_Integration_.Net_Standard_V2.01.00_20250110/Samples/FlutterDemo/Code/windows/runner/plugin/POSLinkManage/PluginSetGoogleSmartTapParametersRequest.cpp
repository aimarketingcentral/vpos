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
#include "PluginSetGoogleSmartTapParametersRequest.h"

namespace POSLinkManage{
    PluginSetGoogleSmartTapParametersRequest::PluginSetGoogleSmartTapParametersRequest(){}

    _SetGoogleSmartTapParametersRequest* PluginSetGoogleSmartTapParametersRequest::set(const std::optional<ManageSetGoogleSmartTapParametersRequest>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidSetGoogleSmartTapParametersRequest;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Manage.SetGoogleSmartTapParametersRequest"),&clsidSetGoogleSmartTapParametersRequest);
        request = NULL;
        request.CoCreateInstance(clsidSetGoogleSmartTapParametersRequest);

        request->put_VasMode((VasMode)*req->vas_mode());

        PluginGoogleSmartTap googleSmartTapData;
        request->putref_GoogleSmartTapData(googleSmartTapData.set(req->google_smart_tap_data() ? std::optional<const ManageGoogleSmartTap>(*req->google_smart_tap_data()) : std::nullopt));

        return request;
    }

    const ManageSetGoogleSmartTapParametersRequest* PluginSetGoogleSmartTapParametersRequest::get(_SetGoogleSmartTapParametersRequest* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = ManageSetGoogleSmartTapParametersRequest();

        VasMode vasMode;
        rsp->get_VasMode(&vasMode);
        response->set_vas_mode((ManageVasMode)vasMode);

        CComPtr<_GoogleSmartTap> comGoogleSmartTapData = NULL;
        rsp->get_GoogleSmartTapData(&comGoogleSmartTapData);
        PluginGoogleSmartTap googleSmartTapData;
        response->set_google_smart_tap_data(googleSmartTapData.get(comGoogleSmartTapData)? googleSmartTapData.get(comGoogleSmartTapData): nullptr);

        return &(*response);
    }
}
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
#include "PluginVasPushDataRequest.h"

namespace POSLinkManage{
    PluginVasPushDataRequest::PluginVasPushDataRequest(){}

    _VasPushDataRequest* PluginVasPushDataRequest::set(const std::optional<ManageVasPushDataRequest>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidVasPushDataRequest;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Manage.VasPushDataRequest"),&clsidVasPushDataRequest);
        request = NULL;
        request.CoCreateInstance(clsidVasPushDataRequest);

        request->put_VasMode((VasMode)*req->vas_mode());

        PluginGoogleSmartTapPushService googleSmartTapPushService;
        request->putref_GoogleSmartTapPushService(googleSmartTapPushService.set(req->google_smart_tap_push_service() ? std::optional<const ManageGoogleSmartTapPushService>(*req->google_smart_tap_push_service()) : std::nullopt));

        return request;
    }

    const ManageVasPushDataRequest* PluginVasPushDataRequest::get(_VasPushDataRequest* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = ManageVasPushDataRequest();

        VasMode vasMode;
        rsp->get_VasMode(&vasMode);
        response->set_vas_mode((ManageVasMode)vasMode);

        CComPtr<_GoogleSmartTapPushService> comGoogleSmartTapPushService = NULL;
        rsp->get_GoogleSmartTapPushService(&comGoogleSmartTapPushService);
        PluginGoogleSmartTapPushService googleSmartTapPushService;
        response->set_google_smart_tap_push_service(googleSmartTapPushService.get(comGoogleSmartTapPushService)? googleSmartTapPushService.get(comGoogleSmartTapPushService): nullptr);

        return &(*response);
    }
}
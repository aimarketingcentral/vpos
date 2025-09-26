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
#include "PluginSetApplePayVasParametersRequest.h"

namespace POSLinkManage{
    PluginSetApplePayVasParametersRequest::PluginSetApplePayVasParametersRequest(){}

    _SetApplePayVasParametersRequest* PluginSetApplePayVasParametersRequest::set(const std::optional<ManageSetApplePayVasParametersRequest>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidSetApplePayVasParametersRequest;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Manage.SetApplePayVasParametersRequest"),&clsidSetApplePayVasParametersRequest);
        request = NULL;
        request.CoCreateInstance(clsidSetApplePayVasParametersRequest);

        request->put_VasMode((VasMode)*req->vas_mode());

        PluginApplePayVas applePayVasData;
        request->putref_ApplePayVasData(applePayVasData.set(req->apple_pay_vas_data() ? std::optional<const ManageApplePayVas>(*req->apple_pay_vas_data()) : std::nullopt));

        return request;
    }

    const ManageSetApplePayVasParametersRequest* PluginSetApplePayVasParametersRequest::get(_SetApplePayVasParametersRequest* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = ManageSetApplePayVasParametersRequest();

        VasMode vasMode;
        rsp->get_VasMode(&vasMode);
        response->set_vas_mode((ManageVasMode)vasMode);

        CComPtr<_ApplePayVas> comApplePayVasData = NULL;
        rsp->get_ApplePayVasData(&comApplePayVasData);
        PluginApplePayVas applePayVasData;
        response->set_apple_pay_vas_data(applePayVasData.get(comApplePayVasData)? applePayVasData.get(comApplePayVasData): nullptr);

        return &(*response);
    }
}
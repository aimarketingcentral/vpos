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
#include "PluginSetVariableResponse.h"

namespace POSLinkManage{
    PluginSetVariableResponse::PluginSetVariableResponse(){}

    _SetVariableResponse* PluginSetVariableResponse::set(const std::optional<ManageSetVariableResponse>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidSetVariableResponse;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Manage.SetVariableResponse"),&clsidSetVariableResponse);
        request = NULL;
        request.CoCreateInstance(clsidSetVariableResponse);

        PluginMultiMerchant multiMerchant;
        request->putref_MultiMerchant(multiMerchant.set(req->multi_merchant() ? std::optional<const ManageMultiMerchant>(*req->multi_merchant()) : std::nullopt));

        return request;
    }

    const ManageSetVariableResponse* PluginSetVariableResponse::get(_SetVariableResponse* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = ManageSetVariableResponse();

        BSTR responseCode;
        rsp->get_ResponseCode(&responseCode);
        response->set_response_code(Tool::Tools::ParseBSTRToString(responseCode));

        BSTR responseMessage;
        rsp->get_ResponseMessage(&responseMessage);
        response->set_response_message(Tool::Tools::ParseBSTRToString(responseMessage));

        CComPtr<_MultiMerchant> comMultiMerchant = NULL;
        rsp->get_MultiMerchant(&comMultiMerchant);
        PluginMultiMerchant multiMerchant;
        response->set_multi_merchant(multiMerchant.get(comMultiMerchant)? multiMerchant.get(comMultiMerchant): nullptr);

        return &(*response);
    }
}
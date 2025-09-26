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
#include "PluginCompleteOnlineEmvRequest.h"

namespace POSLinkFullIntegration{
    PluginCompleteOnlineEmvRequest::PluginCompleteOnlineEmvRequest(){}

    _CompleteOnlineEmvRequest* PluginCompleteOnlineEmvRequest::set(const std::optional<FullIntegrationCompleteOnlineEmvRequest>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidCompleteOnlineEmvRequest;
        CLSIDFromProgID(OLESTR("POSLinkFullIntegration.FullIntegration.CompleteOnlineEmvRequest"),&clsidCompleteOnlineEmvRequest);
        request = NULL;
        request.CoCreateInstance(clsidCompleteOnlineEmvRequest);

        request->put_OnlineAuthorizationResult((OnlineAuthorizationResult)*req->online_authorization_result());

        request->put_ResponseCode(req->response_code()?Tool::Tools::ParseStringToBSTR(*req->response_code()):SysAllocString(L""));

        request->put_AuthorizationCode(req->authorization_code()?Tool::Tools::ParseStringToBSTR(*req->authorization_code()):SysAllocString(L""));

        request->put_IssuerAuthenticationData(req->issuer_authentication_data()?Tool::Tools::ParseStringToBSTR(*req->issuer_authentication_data()):SysAllocString(L""));

        request->put_IssuerScript1(req->issuer_script1()?Tool::Tools::ParseStringToBSTR(*req->issuer_script1()):SysAllocString(L""));

        request->put_IssuerScript2(req->issuer_script2()?Tool::Tools::ParseStringToBSTR(*req->issuer_script2()):SysAllocString(L""));

        request->put_TagList(req->tag_list()?Tool::Tools::ParseStringToBSTR(*req->tag_list()):SysAllocString(L""));

        request->put_ContinuousScreen((ContinuousScreen)*req->continuous_screen());

        return request;
    }

    const FullIntegrationCompleteOnlineEmvRequest* PluginCompleteOnlineEmvRequest::get(_CompleteOnlineEmvRequest* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = FullIntegrationCompleteOnlineEmvRequest();

        OnlineAuthorizationResult onlineAuthorizationResult;
        rsp->get_OnlineAuthorizationResult(&onlineAuthorizationResult);
        response->set_online_authorization_result((FullIntegrationOnlineAuthorizationResult)onlineAuthorizationResult);

        BSTR responseCode;
        rsp->get_ResponseCode(&responseCode);
        response->set_response_code(Tool::Tools::ParseBSTRToString(responseCode));

        BSTR authorizationCode;
        rsp->get_AuthorizationCode(&authorizationCode);
        response->set_authorization_code(Tool::Tools::ParseBSTRToString(authorizationCode));

        BSTR issuerAuthenticationData;
        rsp->get_IssuerAuthenticationData(&issuerAuthenticationData);
        response->set_issuer_authentication_data(Tool::Tools::ParseBSTRToString(issuerAuthenticationData));

        BSTR issuerScript1;
        rsp->get_IssuerScript1(&issuerScript1);
        response->set_issuer_script1(Tool::Tools::ParseBSTRToString(issuerScript1));

        BSTR issuerScript2;
        rsp->get_IssuerScript2(&issuerScript2);
        response->set_issuer_script2(Tool::Tools::ParseBSTRToString(issuerScript2));

        BSTR tagList;
        rsp->get_TagList(&tagList);
        response->set_tag_list(Tool::Tools::ParseBSTRToString(tagList));

        ContinuousScreen continuousScreen;
        rsp->get_ContinuousScreen(&continuousScreen);
        response->set_continuous_screen((FullIntegrationContinuousScreen)continuousScreen);

        return &(*response);
    }
}
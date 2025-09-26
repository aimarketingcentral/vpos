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
#include "PluginCompleteOnlineEmvResponse.h"

namespace POSLinkFullIntegration{
    PluginCompleteOnlineEmvResponse::PluginCompleteOnlineEmvResponse(){}

    _CompleteOnlineEmvResponse* PluginCompleteOnlineEmvResponse::set(const std::optional<FullIntegrationCompleteOnlineEmvResponse>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidCompleteOnlineEmvResponse;
        CLSIDFromProgID(OLESTR("POSLinkFullIntegration.FullIntegration.CompleteOnlineEmvResponse"),&clsidCompleteOnlineEmvResponse);
        request = NULL;
        request.CoCreateInstance(clsidCompleteOnlineEmvResponse);

        request->put_AuthorizationResult((SecondGacResult)*req->authorization_result());

        request->put_EmvTlvData(req->emv_tlv_data()?Tool::Tools::ParseStringToBSTR(*req->emv_tlv_data()):SysAllocString(L""));

        request->put_IssuerScriptResults(req->issuer_script_results()?Tool::Tools::ParseStringToBSTR(*req->issuer_script_results()):SysAllocString(L""));

        return request;
    }

    const FullIntegrationCompleteOnlineEmvResponse* PluginCompleteOnlineEmvResponse::get(_CompleteOnlineEmvResponse* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = FullIntegrationCompleteOnlineEmvResponse();

        BSTR responseCode;
        rsp->get_ResponseCode(&responseCode);
        response->set_response_code(Tool::Tools::ParseBSTRToString(responseCode));

        BSTR responseMessage;
        rsp->get_ResponseMessage(&responseMessage);
        response->set_response_message(Tool::Tools::ParseBSTRToString(responseMessage));

        SecondGacResult authorizationResult;
        rsp->get_AuthorizationResult(&authorizationResult);
        response->set_authorization_result((FullIntegrationSecondGacResult)authorizationResult);

        BSTR emvTlvData;
        rsp->get_EmvTlvData(&emvTlvData);
        response->set_emv_tlv_data(Tool::Tools::ParseBSTRToString(emvTlvData));

        BSTR issuerScriptResults;
        rsp->get_IssuerScriptResults(&issuerScriptResults);
        response->set_issuer_script_results(Tool::Tools::ParseBSTRToString(issuerScriptResults));

        return &(*response);
    }
}
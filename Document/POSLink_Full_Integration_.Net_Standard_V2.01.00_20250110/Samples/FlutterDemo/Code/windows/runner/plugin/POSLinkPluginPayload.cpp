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
#include "POSLinkPluginPayload.h"
#include <thread>

namespace POSLinkPayload{

    POSLinkPluginPayload::POSLinkPluginPayload(){}

    void POSLinkPluginPayload::Payload(const PayloadPayloadRequest& req, std::function<void(ErrorOr<PayloadPayloadResponse> reply)> result)
    {
        std::thread t1([req, result]{
            CoInitialize(NULL);
            if(g_multiCommand.IsDoMultiCommand)
            {
                CComPtr<_PayloadRequest> comReq = NULL;
                PluginPayloadRequest pluginPayloadRequest;
                comReq = pluginPayloadRequest.set(req);
                g_multiCommand.AddReq(comReq);
                g_multiCommand.AddRsp("PayloadPayloadResponse", std::move(result));
                return;
            }
            CComPtr<_PayloadRequest> payloadRequest = NULL;
            PluginPayloadRequest request;
            payloadRequest = request.set(req);

            CComPtr<_PayloadResponse> payloadResponse = NULL;

            if(g_commSetting.GlobalTerminal == NULL) return;
            CComPtr<_Payload> payload = NULL;
            g_commSetting.GlobalTerminal->get_Payload(&payload);
            CComPtr<_ExecutionResult> executionResult = NULL;
            payload->DoPayload(payloadRequest, &payloadResponse, &executionResult);
            Code retResponseCode;
            executionResult->GetErrorCode(&retResponseCode);
            PluginPayloadResponse response;
            std::optional<PayloadPayloadResponse> rsp = response.get(payloadResponse)? std::optional<PayloadPayloadResponse>(*response.get(payloadResponse)): std::nullopt;
            if(retResponseCode == Code::Code_Ok && rsp != std::nullopt)
            {
                ErrorOr<PayloadPayloadResponse> reply(*rsp);
                result(reply);
            }
            else
            {
                PayloadPayloadResponse errorRsp;
                errorRsp.set_response_message(Tool::Tools::ParseExecutionResultCodeToString(retResponseCode));
                ErrorOr<PayloadPayloadResponse> reply(errorRsp);
                result(reply);
            }
            CoUninitialize();
        });
        t1.detach();
    }

}

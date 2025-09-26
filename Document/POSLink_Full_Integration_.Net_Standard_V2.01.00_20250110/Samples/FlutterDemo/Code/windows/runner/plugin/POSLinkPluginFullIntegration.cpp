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
#include "POSLinkPluginFullIntegration.h"
#include <thread>

namespace POSLinkFullIntegration{

    POSLinkPluginFullIntegration::POSLinkPluginFullIntegration(){}

    void POSLinkPluginFullIntegration::AuthorizeCard(const FullIntegrationAuthorizeCardRequest& req, std::function<void(ErrorOr<FullIntegrationAuthorizeCardResponse> reply)> result)
    {
        std::thread t1([req, result]{
            CoInitialize(NULL);
            if(g_multiCommand.IsDoMultiCommand)
            {
                CComPtr<_AuthorizeCardRequest> comReq = NULL;
                PluginAuthorizeCardRequest pluginAuthorizeCardRequest;
                comReq = pluginAuthorizeCardRequest.set(req);
                g_multiCommand.AddReq(comReq);
                g_multiCommand.AddRsp("FullIntegrationAuthorizeCardResponse", std::move(result));
                return;
            }
            CComPtr<_AuthorizeCardRequest> authorizeCardRequest = NULL;
            PluginAuthorizeCardRequest request;
            authorizeCardRequest = request.set(req);

            CComPtr<_AuthorizeCardResponse> authorizeCardResponse = NULL;

            if(g_commSetting.GlobalTerminal == NULL) return;
            CComPtr<_FullIntegration> fullIntegration = NULL;
            g_commSetting.GlobalTerminal->get_FullIntegration(&fullIntegration);
            CComPtr<_ExecutionResult> executionResult = NULL;
            fullIntegration->AuthorizeCard(authorizeCardRequest, &authorizeCardResponse, &executionResult);
            Code retResponseCode;
            executionResult->GetErrorCode(&retResponseCode);
            PluginAuthorizeCardResponse response;
            std::optional<FullIntegrationAuthorizeCardResponse> rsp = response.get(authorizeCardResponse)? std::optional<FullIntegrationAuthorizeCardResponse>(*response.get(authorizeCardResponse)): std::nullopt;
            if(retResponseCode == Code::Code_Ok && rsp != std::nullopt)
            {
                ErrorOr<FullIntegrationAuthorizeCardResponse> reply(*rsp);
                result(reply);
            }
            else
            {
                FullIntegrationAuthorizeCardResponse errorRsp;
                errorRsp.set_response_message(Tool::Tools::ParseExecutionResultCodeToString(retResponseCode));
                ErrorOr<FullIntegrationAuthorizeCardResponse> reply(errorRsp);
                result(reply);
            }
            CoUninitialize();
        });
        t1.detach();
    }

    void POSLinkPluginFullIntegration::CompleteOnlineEmv(const FullIntegrationCompleteOnlineEmvRequest& req, std::function<void(ErrorOr<FullIntegrationCompleteOnlineEmvResponse> reply)> result)
    {
        std::thread t1([req, result]{
            CoInitialize(NULL);
            if(g_multiCommand.IsDoMultiCommand)
            {
                CComPtr<_CompleteOnlineEmvRequest> comReq = NULL;
                PluginCompleteOnlineEmvRequest pluginCompleteOnlineEmvRequest;
                comReq = pluginCompleteOnlineEmvRequest.set(req);
                g_multiCommand.AddReq(comReq);
                g_multiCommand.AddRsp("FullIntegrationCompleteOnlineEmvResponse", std::move(result));
                return;
            }
            CComPtr<_CompleteOnlineEmvRequest> completeOnlineEmvRequest = NULL;
            PluginCompleteOnlineEmvRequest request;
            completeOnlineEmvRequest = request.set(req);

            CComPtr<_CompleteOnlineEmvResponse> completeOnlineEmvResponse = NULL;

            if(g_commSetting.GlobalTerminal == NULL) return;
            CComPtr<_FullIntegration> fullIntegration = NULL;
            g_commSetting.GlobalTerminal->get_FullIntegration(&fullIntegration);
            CComPtr<_ExecutionResult> executionResult = NULL;
            fullIntegration->CompleteOnlineEmv(completeOnlineEmvRequest, &completeOnlineEmvResponse, &executionResult);
            Code retResponseCode;
            executionResult->GetErrorCode(&retResponseCode);
            PluginCompleteOnlineEmvResponse response;
            std::optional<FullIntegrationCompleteOnlineEmvResponse> rsp = response.get(completeOnlineEmvResponse)? std::optional<FullIntegrationCompleteOnlineEmvResponse>(*response.get(completeOnlineEmvResponse)): std::nullopt;
            if(retResponseCode == Code::Code_Ok && rsp != std::nullopt)
            {
                ErrorOr<FullIntegrationCompleteOnlineEmvResponse> reply(*rsp);
                result(reply);
            }
            else
            {
                FullIntegrationCompleteOnlineEmvResponse errorRsp;
                errorRsp.set_response_message(Tool::Tools::ParseExecutionResultCodeToString(retResponseCode));
                ErrorOr<FullIntegrationCompleteOnlineEmvResponse> reply(errorRsp);
                result(reply);
            }
            CoUninitialize();
        });
        t1.detach();
    }

    void POSLinkPluginFullIntegration::GetEmvTlvData(const FullIntegrationGetEmvTlvDataRequest& req, std::function<void(ErrorOr<FullIntegrationGetEmvTlvDataResponse> reply)> result)
    {
        std::thread t1([req, result]{
            CoInitialize(NULL);
            if(g_multiCommand.IsDoMultiCommand)
            {
                CComPtr<_GetEmvTlvDataRequest> comReq = NULL;
                PluginGetEmvTlvDataRequest pluginGetEmvTlvDataRequest;
                comReq = pluginGetEmvTlvDataRequest.set(req);
                g_multiCommand.AddReq(comReq);
                g_multiCommand.AddRsp("FullIntegrationGetEmvTlvDataResponse", std::move(result));
                return;
            }
            CComPtr<_GetEmvTlvDataRequest> getEmvTlvDataRequest = NULL;
            PluginGetEmvTlvDataRequest request;
            getEmvTlvDataRequest = request.set(req);

            CComPtr<_GetEmvTlvDataResponse> getEmvTlvDataResponse = NULL;

            if(g_commSetting.GlobalTerminal == NULL) return;
            CComPtr<_FullIntegration> fullIntegration = NULL;
            g_commSetting.GlobalTerminal->get_FullIntegration(&fullIntegration);
            CComPtr<_ExecutionResult> executionResult = NULL;
            fullIntegration->GetEmvTlvData(getEmvTlvDataRequest, &getEmvTlvDataResponse, &executionResult);
            Code retResponseCode;
            executionResult->GetErrorCode(&retResponseCode);
            PluginGetEmvTlvDataResponse response;
            std::optional<FullIntegrationGetEmvTlvDataResponse> rsp = response.get(getEmvTlvDataResponse)? std::optional<FullIntegrationGetEmvTlvDataResponse>(*response.get(getEmvTlvDataResponse)): std::nullopt;
            if(retResponseCode == Code::Code_Ok && rsp != std::nullopt)
            {
                ErrorOr<FullIntegrationGetEmvTlvDataResponse> reply(*rsp);
                result(reply);
            }
            else
            {
                FullIntegrationGetEmvTlvDataResponse errorRsp;
                errorRsp.set_response_message(Tool::Tools::ParseExecutionResultCodeToString(retResponseCode));
                ErrorOr<FullIntegrationGetEmvTlvDataResponse> reply(errorRsp);
                result(reply);
            }
            CoUninitialize();
        });
        t1.detach();
    }

    void POSLinkPluginFullIntegration::GetPinBlock(const FullIntegrationGetPinBlockRequest& req, std::function<void(ErrorOr<FullIntegrationGetPinBlockResponse> reply)> result)
    {
        std::thread t1([req, result]{
            CoInitialize(NULL);
            if(g_multiCommand.IsDoMultiCommand)
            {
                CComPtr<_GetPinBlockRequest> comReq = NULL;
                PluginGetPinBlockRequest pluginGetPinBlockRequest;
                comReq = pluginGetPinBlockRequest.set(req);
                g_multiCommand.AddReq(comReq);
                g_multiCommand.AddRsp("FullIntegrationGetPinBlockResponse", std::move(result));
                return;
            }
            CComPtr<_GetPinBlockRequest> getPinBlockRequest = NULL;
            PluginGetPinBlockRequest request;
            getPinBlockRequest = request.set(req);

            CComPtr<_GetPinBlockResponse> getPinBlockResponse = NULL;

            if(g_commSetting.GlobalTerminal == NULL) return;
            CComPtr<_FullIntegration> fullIntegration = NULL;
            g_commSetting.GlobalTerminal->get_FullIntegration(&fullIntegration);
            CComPtr<_ExecutionResult> executionResult = NULL;
            fullIntegration->GetPinBlock(getPinBlockRequest, &getPinBlockResponse, &executionResult);
            Code retResponseCode;
            executionResult->GetErrorCode(&retResponseCode);
            PluginGetPinBlockResponse response;
            std::optional<FullIntegrationGetPinBlockResponse> rsp = response.get(getPinBlockResponse)? std::optional<FullIntegrationGetPinBlockResponse>(*response.get(getPinBlockResponse)): std::nullopt;
            if(retResponseCode == Code::Code_Ok && rsp != std::nullopt)
            {
                ErrorOr<FullIntegrationGetPinBlockResponse> reply(*rsp);
                result(reply);
            }
            else
            {
                FullIntegrationGetPinBlockResponse errorRsp;
                errorRsp.set_response_message(Tool::Tools::ParseExecutionResultCodeToString(retResponseCode));
                ErrorOr<FullIntegrationGetPinBlockResponse> reply(errorRsp);
                result(reply);
            }
            CoUninitialize();
        });
        t1.detach();
    }

    void POSLinkPluginFullIntegration::InputAccountWithEmv(const FullIntegrationInputAccountWithEmvRequest& req, std::function<void(ErrorOr<FullIntegrationInputAccountWithEmvResponse> reply)> result)
    {
        std::thread t1([req, result]{
            CoInitialize(NULL);
            if(g_multiCommand.IsDoMultiCommand)
            {
                CComPtr<_InputAccountWithEmvRequest> comReq = NULL;
                PluginInputAccountWithEmvRequest pluginInputAccountWithEmvRequest;
                comReq = pluginInputAccountWithEmvRequest.set(req);
                g_multiCommand.AddReq(comReq);
                g_multiCommand.AddRsp("FullIntegrationInputAccountWithEmvResponse", std::move(result));
                return;
            }
            CComPtr<_InputAccountWithEmvRequest> inputAccountWithEmvRequest = NULL;
            PluginInputAccountWithEmvRequest request;
            inputAccountWithEmvRequest = request.set(req);

            CComPtr<_InputAccountWithEmvResponse> inputAccountWithEmvResponse = NULL;

            if(g_commSetting.GlobalTerminal == NULL) return;
            CComPtr<_FullIntegration> fullIntegration = NULL;
            g_commSetting.GlobalTerminal->get_FullIntegration(&fullIntegration);
            CComPtr<_ExecutionResult> executionResult = NULL;
            fullIntegration->InputAccountWithEmv(inputAccountWithEmvRequest, &inputAccountWithEmvResponse, &executionResult);
            Code retResponseCode;
            executionResult->GetErrorCode(&retResponseCode);
            PluginInputAccountWithEmvResponse response;
            std::optional<FullIntegrationInputAccountWithEmvResponse> rsp = response.get(inputAccountWithEmvResponse)? std::optional<FullIntegrationInputAccountWithEmvResponse>(*response.get(inputAccountWithEmvResponse)): std::nullopt;
            if(retResponseCode == Code::Code_Ok && rsp != std::nullopt)
            {
                ErrorOr<FullIntegrationInputAccountWithEmvResponse> reply(*rsp);
                result(reply);
            }
            else
            {
                FullIntegrationInputAccountWithEmvResponse errorRsp;
                errorRsp.set_response_message(Tool::Tools::ParseExecutionResultCodeToString(retResponseCode));
                ErrorOr<FullIntegrationInputAccountWithEmvResponse> reply(errorRsp);
                result(reply);
            }
            CoUninitialize();
        });
        t1.detach();
    }

    void POSLinkPluginFullIntegration::SetEmvTlvData(const FullIntegrationSetEmvTlvDataRequest& req, std::function<void(ErrorOr<FullIntegrationSetEmvTlvDataResponse> reply)> result)
    {
        std::thread t1([req, result]{
            CoInitialize(NULL);
            if(g_multiCommand.IsDoMultiCommand)
            {
                CComPtr<_SetEmvTlvDataRequest> comReq = NULL;
                PluginSetEmvTlvDataRequest pluginSetEmvTlvDataRequest;
                comReq = pluginSetEmvTlvDataRequest.set(req);
                g_multiCommand.AddReq(comReq);
                g_multiCommand.AddRsp("FullIntegrationSetEmvTlvDataResponse", std::move(result));
                return;
            }
            CComPtr<_SetEmvTlvDataRequest> setEmvTlvDataRequest = NULL;
            PluginSetEmvTlvDataRequest request;
            setEmvTlvDataRequest = request.set(req);

            CComPtr<_SetEmvTlvDataResponse> setEmvTlvDataResponse = NULL;

            if(g_commSetting.GlobalTerminal == NULL) return;
            CComPtr<_FullIntegration> fullIntegration = NULL;
            g_commSetting.GlobalTerminal->get_FullIntegration(&fullIntegration);
            CComPtr<_ExecutionResult> executionResult = NULL;
            fullIntegration->SetEmvTlvData(setEmvTlvDataRequest, &setEmvTlvDataResponse, &executionResult);
            Code retResponseCode;
            executionResult->GetErrorCode(&retResponseCode);
            PluginSetEmvTlvDataResponse response;
            std::optional<FullIntegrationSetEmvTlvDataResponse> rsp = response.get(setEmvTlvDataResponse)? std::optional<FullIntegrationSetEmvTlvDataResponse>(*response.get(setEmvTlvDataResponse)): std::nullopt;
            if(retResponseCode == Code::Code_Ok && rsp != std::nullopt)
            {
                ErrorOr<FullIntegrationSetEmvTlvDataResponse> reply(*rsp);
                result(reply);
            }
            else
            {
                FullIntegrationSetEmvTlvDataResponse errorRsp;
                errorRsp.set_response_message(Tool::Tools::ParseExecutionResultCodeToString(retResponseCode));
                ErrorOr<FullIntegrationSetEmvTlvDataResponse> reply(errorRsp);
                result(reply);
            }
            CoUninitialize();
        });
        t1.detach();
    }

}

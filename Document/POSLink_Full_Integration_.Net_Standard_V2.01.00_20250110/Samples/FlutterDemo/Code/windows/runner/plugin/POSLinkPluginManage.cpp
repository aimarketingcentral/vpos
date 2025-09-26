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
#include "POSLinkPluginManage.h"
#include <thread>

namespace POSLinkManage{

    POSLinkPluginManage::POSLinkPluginManage(){}

    void POSLinkPluginManage::CheckFile(const ManageCheckFileRequest& req, std::function<void(ErrorOr<ManageCheckFileResponse> reply)> result)
    {
        std::thread t1([req, result]{
            CoInitialize(NULL);
            if(g_multiCommand.IsDoMultiCommand)
            {
                CComPtr<_CheckFileRequest> comReq = NULL;
                PluginCheckFileRequest pluginCheckFileRequest;
                comReq = pluginCheckFileRequest.set(req);
                g_multiCommand.AddReq(comReq);
                g_multiCommand.AddRsp("ManageCheckFileResponse", std::move(result));
                return;
            }
            CComPtr<_CheckFileRequest> checkFileRequest = NULL;
            PluginCheckFileRequest request;
            checkFileRequest = request.set(req);

            CComPtr<_CheckFileResponse> checkFileResponse = NULL;

            if(g_commSetting.GlobalTerminal == NULL) return;
            CComPtr<_Manage> manage = NULL;
            g_commSetting.GlobalTerminal->get_Manage(&manage);
            CComPtr<_ExecutionResult> executionResult = NULL;
            manage->CheckFile(checkFileRequest, &checkFileResponse, &executionResult);
            Code retResponseCode;
            executionResult->GetErrorCode(&retResponseCode);
            PluginCheckFileResponse response;
            std::optional<ManageCheckFileResponse> rsp = response.get(checkFileResponse)? std::optional<ManageCheckFileResponse>(*response.get(checkFileResponse)): std::nullopt;
            if(retResponseCode == Code::Code_Ok && rsp != std::nullopt)
            {
                ErrorOr<ManageCheckFileResponse> reply(*rsp);
                result(reply);
            }
            else
            {
                ManageCheckFileResponse errorRsp;
                errorRsp.set_response_message(Tool::Tools::ParseExecutionResultCodeToString(retResponseCode));
                ErrorOr<ManageCheckFileResponse> reply(errorRsp);
                result(reply);
            }
            CoUninitialize();
        });
        t1.detach();
    }

    void POSLinkPluginManage::ClearCardBuffer(const ManageClearCardBufferRequest& req, std::function<void(ErrorOr<ManageClearCardBufferResponse> reply)> result)
    {
        std::thread t1([req, result]{
            CoInitialize(NULL);
            if(g_multiCommand.IsDoMultiCommand)
            {
                CComPtr<_ClearCardBufferRequest> comReq = NULL;
                PluginClearCardBufferRequest pluginClearCardBufferRequest;
                comReq = pluginClearCardBufferRequest.set(req);
                g_multiCommand.AddReq(comReq);
                g_multiCommand.AddRsp("ManageClearCardBufferResponse", std::move(result));
                return;
            }
            CComPtr<_ClearCardBufferRequest> clearCardBufferRequest = NULL;
            PluginClearCardBufferRequest request;
            clearCardBufferRequest = request.set(req);

            CComPtr<_ClearCardBufferResponse> clearCardBufferResponse = NULL;

            if(g_commSetting.GlobalTerminal == NULL) return;
            CComPtr<_Manage> manage = NULL;
            g_commSetting.GlobalTerminal->get_Manage(&manage);
            CComPtr<_ExecutionResult> executionResult = NULL;
            manage->ClearCardBuffer(&clearCardBufferResponse, &executionResult);
            Code retResponseCode;
            executionResult->GetErrorCode(&retResponseCode);
            PluginClearCardBufferResponse response;
            std::optional<ManageClearCardBufferResponse> rsp = response.get(clearCardBufferResponse)? std::optional<ManageClearCardBufferResponse>(*response.get(clearCardBufferResponse)): std::nullopt;
            if(retResponseCode == Code::Code_Ok && rsp != std::nullopt)
            {
                ErrorOr<ManageClearCardBufferResponse> reply(*rsp);
                result(reply);
            }
            else
            {
                ManageClearCardBufferResponse errorRsp;
                errorRsp.set_response_message(Tool::Tools::ParseExecutionResultCodeToString(retResponseCode));
                ErrorOr<ManageClearCardBufferResponse> reply(errorRsp);
                result(reply);
            }
            CoUninitialize();
        });
        t1.detach();
    }

    void POSLinkPluginManage::DeleteImage(const ManageDeleteImageRequest& req, std::function<void(ErrorOr<ManageDeleteImageResponse> reply)> result)
    {
        std::thread t1([req, result]{
            CoInitialize(NULL);
            if(g_multiCommand.IsDoMultiCommand)
            {
                CComPtr<_DeleteImageRequest> comReq = NULL;
                PluginDeleteImageRequest pluginDeleteImageRequest;
                comReq = pluginDeleteImageRequest.set(req);
                g_multiCommand.AddReq(comReq);
                g_multiCommand.AddRsp("ManageDeleteImageResponse", std::move(result));
                return;
            }
            CComPtr<_DeleteImageRequest> deleteImageRequest = NULL;
            PluginDeleteImageRequest request;
            deleteImageRequest = request.set(req);

            CComPtr<_DeleteImageResponse> deleteImageResponse = NULL;

            if(g_commSetting.GlobalTerminal == NULL) return;
            CComPtr<_Manage> manage = NULL;
            g_commSetting.GlobalTerminal->get_Manage(&manage);
            CComPtr<_ExecutionResult> executionResult = NULL;
            manage->DeleteImage(deleteImageRequest, &deleteImageResponse, &executionResult);
            Code retResponseCode;
            executionResult->GetErrorCode(&retResponseCode);
            PluginDeleteImageResponse response;
            std::optional<ManageDeleteImageResponse> rsp = response.get(deleteImageResponse)? std::optional<ManageDeleteImageResponse>(*response.get(deleteImageResponse)): std::nullopt;
            if(retResponseCode == Code::Code_Ok && rsp != std::nullopt)
            {
                ErrorOr<ManageDeleteImageResponse> reply(*rsp);
                result(reply);
            }
            else
            {
                ManageDeleteImageResponse errorRsp;
                errorRsp.set_response_message(Tool::Tools::ParseExecutionResultCodeToString(retResponseCode));
                ErrorOr<ManageDeleteImageResponse> reply(errorRsp);
                result(reply);
            }
            CoUninitialize();
        });
        t1.detach();
    }

    void POSLinkPluginManage::DoSignature(const ManageDoSignatureRequest& req, std::function<void(ErrorOr<ManageDoSignatureResponse> reply)> result)
    {
        std::thread t1([req, result]{
            CoInitialize(NULL);
            if(g_multiCommand.IsDoMultiCommand)
            {
                CComPtr<_DoSignatureRequest> comReq = NULL;
                PluginDoSignatureRequest pluginDoSignatureRequest;
                comReq = pluginDoSignatureRequest.set(req);
                g_multiCommand.AddReq(comReq);
                g_multiCommand.AddRsp("ManageDoSignatureResponse", std::move(result));
                return;
            }
            CComPtr<_DoSignatureRequest> doSignatureRequest = NULL;
            PluginDoSignatureRequest request;
            doSignatureRequest = request.set(req);

            CComPtr<_DoSignatureResponse> doSignatureResponse = NULL;

            if(g_commSetting.GlobalTerminal == NULL) return;
            CComPtr<_Manage> manage = NULL;
            g_commSetting.GlobalTerminal->get_Manage(&manage);
            CComPtr<_ExecutionResult> executionResult = NULL;
            manage->DoSignature(doSignatureRequest, &doSignatureResponse, &executionResult);
            Code retResponseCode;
            executionResult->GetErrorCode(&retResponseCode);
            PluginDoSignatureResponse response;
            std::optional<ManageDoSignatureResponse> rsp = response.get(doSignatureResponse)? std::optional<ManageDoSignatureResponse>(*response.get(doSignatureResponse)): std::nullopt;
            if(retResponseCode == Code::Code_Ok && rsp != std::nullopt)
            {
                ErrorOr<ManageDoSignatureResponse> reply(*rsp);
                result(reply);
            }
            else
            {
                ManageDoSignatureResponse errorRsp;
                errorRsp.set_response_message(Tool::Tools::ParseExecutionResultCodeToString(retResponseCode));
                ErrorOr<ManageDoSignatureResponse> reply(errorRsp);
                result(reply);
            }
            CoUninitialize();
        });
        t1.detach();
    }

    void POSLinkPluginManage::GetSignature(const ManageGetSignatureRequest& req, std::function<void(ErrorOr<ManageGetSignatureResponse> reply)> result)
    {
        std::thread t1([req, result]{
            CoInitialize(NULL);
            if(g_multiCommand.IsDoMultiCommand)
            {
                CComPtr<_GetSignatureRequest> comReq = NULL;
                PluginGetSignatureRequest pluginGetSignatureRequest;
                comReq = pluginGetSignatureRequest.set(req);
                g_multiCommand.AddReq(comReq);
                g_multiCommand.AddRsp("ManageGetSignatureResponse", std::move(result));
                return;
            }
            CComPtr<_GetSignatureRequest> getSignatureRequest = NULL;
            PluginGetSignatureRequest request;
            getSignatureRequest = request.set(req);

            CComPtr<_GetSignatureResponse> getSignatureResponse = NULL;

            if(g_commSetting.GlobalTerminal == NULL) return;
            CComPtr<_Manage> manage = NULL;
            g_commSetting.GlobalTerminal->get_Manage(&manage);
            CComPtr<_ExecutionResult> executionResult = NULL;
            manage->GetSignature(&getSignatureResponse, &executionResult);
            Code retResponseCode;
            executionResult->GetErrorCode(&retResponseCode);
            PluginGetSignatureResponse response;
            std::optional<ManageGetSignatureResponse> rsp = response.get(getSignatureResponse)? std::optional<ManageGetSignatureResponse>(*response.get(getSignatureResponse)): std::nullopt;
            if(retResponseCode == Code::Code_Ok && rsp != std::nullopt)
            {
                ErrorOr<ManageGetSignatureResponse> reply(*rsp);
                result(reply);
            }
            else
            {
                ManageGetSignatureResponse errorRsp;
                errorRsp.set_response_message(Tool::Tools::ParseExecutionResultCodeToString(retResponseCode));
                ErrorOr<ManageGetSignatureResponse> reply(errorRsp);
                result(reply);
            }
            CoUninitialize();
        });
        t1.detach();
    }

    void POSLinkPluginManage::GetVariable(const ManageGetVariableRequest& req, std::function<void(ErrorOr<ManageGetVariableResponse> reply)> result)
    {
        std::thread t1([req, result]{
            CoInitialize(NULL);
            if(g_multiCommand.IsDoMultiCommand)
            {
                CComPtr<_GetVariableRequest> comReq = NULL;
                PluginGetVariableRequest pluginGetVariableRequest;
                comReq = pluginGetVariableRequest.set(req);
                g_multiCommand.AddReq(comReq);
                g_multiCommand.AddRsp("ManageGetVariableResponse", std::move(result));
                return;
            }
            CComPtr<_GetVariableRequest> getVariableRequest = NULL;
            PluginGetVariableRequest request;
            getVariableRequest = request.set(req);

            CComPtr<_GetVariableResponse> getVariableResponse = NULL;

            if(g_commSetting.GlobalTerminal == NULL) return;
            CComPtr<_Manage> manage = NULL;
            g_commSetting.GlobalTerminal->get_Manage(&manage);
            CComPtr<_ExecutionResult> executionResult = NULL;
            manage->GetVariable(getVariableRequest, &getVariableResponse, &executionResult);
            Code retResponseCode;
            executionResult->GetErrorCode(&retResponseCode);
            PluginGetVariableResponse response;
            std::optional<ManageGetVariableResponse> rsp = response.get(getVariableResponse)? std::optional<ManageGetVariableResponse>(*response.get(getVariableResponse)): std::nullopt;
            if(retResponseCode == Code::Code_Ok && rsp != std::nullopt)
            {
                ErrorOr<ManageGetVariableResponse> reply(*rsp);
                result(reply);
            }
            else
            {
                ManageGetVariableResponse errorRsp;
                errorRsp.set_response_message(Tool::Tools::ParseExecutionResultCodeToString(retResponseCode));
                ErrorOr<ManageGetVariableResponse> reply(errorRsp);
                result(reply);
            }
            CoUninitialize();
        });
        t1.detach();
    }

    void POSLinkPluginManage::Init(const ManageInitRequest& req, std::function<void(ErrorOr<ManageInitResponse> reply)> result)
    {
        std::thread t1([req, result]{
            CoInitialize(NULL);
            if(g_multiCommand.IsDoMultiCommand)
            {
                CComPtr<_InitRequest> comReq = NULL;
                PluginInitRequest pluginInitRequest;
                comReq = pluginInitRequest.set(req);
                g_multiCommand.AddReq(comReq);
                g_multiCommand.AddRsp("ManageInitResponse", std::move(result));
                return;
            }
            CComPtr<_InitRequest> initRequest = NULL;
            PluginInitRequest request;
            initRequest = request.set(req);

            CComPtr<_InitResponse> initResponse = NULL;

            if(g_commSetting.GlobalTerminal == NULL) return;
            CComPtr<_Manage> manage = NULL;
            g_commSetting.GlobalTerminal->get_Manage(&manage);
            CComPtr<_ExecutionResult> executionResult = NULL;
            manage->Init(&initResponse, &executionResult);
            Code retResponseCode;
            executionResult->GetErrorCode(&retResponseCode);
            PluginInitResponse response;
            std::optional<ManageInitResponse> rsp = response.get(initResponse)? std::optional<ManageInitResponse>(*response.get(initResponse)): std::nullopt;
            if(retResponseCode == Code::Code_Ok && rsp != std::nullopt)
            {
                ErrorOr<ManageInitResponse> reply(*rsp);
                result(reply);
            }
            else
            {
                ManageInitResponse errorRsp;
                errorRsp.set_response_message(Tool::Tools::ParseExecutionResultCodeToString(retResponseCode));
                ErrorOr<ManageInitResponse> reply(errorRsp);
                result(reply);
            }
            CoUninitialize();
        });
        t1.detach();
    }

    void POSLinkPluginManage::Reboot(const ManageRebootRequest& req, std::function<void(ErrorOr<ManageRebootResponse> reply)> result)
    {
        std::thread t1([req, result]{
            CoInitialize(NULL);
            if(g_multiCommand.IsDoMultiCommand)
            {
                CComPtr<_RebootRequest> comReq = NULL;
                PluginRebootRequest pluginRebootRequest;
                comReq = pluginRebootRequest.set(req);
                g_multiCommand.AddReq(comReq);
                g_multiCommand.AddRsp("ManageRebootResponse", std::move(result));
                return;
            }
            CComPtr<_RebootRequest> rebootRequest = NULL;
            PluginRebootRequest request;
            rebootRequest = request.set(req);

            CComPtr<_RebootResponse> rebootResponse = NULL;

            if(g_commSetting.GlobalTerminal == NULL) return;
            CComPtr<_Manage> manage = NULL;
            g_commSetting.GlobalTerminal->get_Manage(&manage);
            CComPtr<_ExecutionResult> executionResult = NULL;
            manage->Reboot(&rebootResponse, &executionResult);
            Code retResponseCode;
            executionResult->GetErrorCode(&retResponseCode);
            PluginRebootResponse response;
            std::optional<ManageRebootResponse> rsp = response.get(rebootResponse)? std::optional<ManageRebootResponse>(*response.get(rebootResponse)): std::nullopt;
            if(retResponseCode == Code::Code_Ok && rsp != std::nullopt)
            {
                ErrorOr<ManageRebootResponse> reply(*rsp);
                result(reply);
            }
            else
            {
                ManageRebootResponse errorRsp;
                errorRsp.set_response_message(Tool::Tools::ParseExecutionResultCodeToString(retResponseCode));
                ErrorOr<ManageRebootResponse> reply(errorRsp);
                result(reply);
            }
            CoUninitialize();
        });
        t1.detach();
    }

    void POSLinkPluginManage::ResetScreen(const ManageResetScreenRequest& req, std::function<void(ErrorOr<ManageResetScreenResponse> reply)> result)
    {
        std::thread t1([req, result]{
            CoInitialize(NULL);
            if(g_multiCommand.IsDoMultiCommand)
            {
                CComPtr<_ResetScreenRequest> comReq = NULL;
                PluginResetScreenRequest pluginResetScreenRequest;
                comReq = pluginResetScreenRequest.set(req);
                g_multiCommand.AddReq(comReq);
                g_multiCommand.AddRsp("ManageResetScreenResponse", std::move(result));
                return;
            }
            CComPtr<_ResetScreenRequest> resetScreenRequest = NULL;
            PluginResetScreenRequest request;
            resetScreenRequest = request.set(req);

            CComPtr<_ResetScreenResponse> resetScreenResponse = NULL;

            if(g_commSetting.GlobalTerminal == NULL) return;
            CComPtr<_Manage> manage = NULL;
            g_commSetting.GlobalTerminal->get_Manage(&manage);
            CComPtr<_ExecutionResult> executionResult = NULL;
            manage->ResetScreen(&resetScreenResponse, &executionResult);
            Code retResponseCode;
            executionResult->GetErrorCode(&retResponseCode);
            PluginResetScreenResponse response;
            std::optional<ManageResetScreenResponse> rsp = response.get(resetScreenResponse)? std::optional<ManageResetScreenResponse>(*response.get(resetScreenResponse)): std::nullopt;
            if(retResponseCode == Code::Code_Ok && rsp != std::nullopt)
            {
                ErrorOr<ManageResetScreenResponse> reply(*rsp);
                result(reply);
            }
            else
            {
                ManageResetScreenResponse errorRsp;
                errorRsp.set_response_message(Tool::Tools::ParseExecutionResultCodeToString(retResponseCode));
                ErrorOr<ManageResetScreenResponse> reply(errorRsp);
                result(reply);
            }
            CoUninitialize();
        });
        t1.detach();
    }

    void POSLinkPluginManage::SetApplePayVasParameters(const ManageSetApplePayVasParametersRequest& req, std::function<void(ErrorOr<ManageSetApplePayVasParametersResponse> reply)> result)
    {
        std::thread t1([req, result]{
            CoInitialize(NULL);
            if(g_multiCommand.IsDoMultiCommand)
            {
                CComPtr<_SetApplePayVasParametersRequest> comReq = NULL;
                PluginSetApplePayVasParametersRequest pluginSetApplePayVasParametersRequest;
                comReq = pluginSetApplePayVasParametersRequest.set(req);
                g_multiCommand.AddReq(comReq);
                g_multiCommand.AddRsp("ManageSetApplePayVasParametersResponse", std::move(result));
                return;
            }
            CComPtr<_SetApplePayVasParametersRequest> setApplePayVasParametersRequest = NULL;
            PluginSetApplePayVasParametersRequest request;
            setApplePayVasParametersRequest = request.set(req);

            CComPtr<_SetApplePayVasParametersResponse> setApplePayVasParametersResponse = NULL;

            if(g_commSetting.GlobalTerminal == NULL) return;
            CComPtr<_Manage> manage = NULL;
            g_commSetting.GlobalTerminal->get_Manage(&manage);
            CComPtr<_ExecutionResult> executionResult = NULL;
            manage->SetApplePayVasParameters(setApplePayVasParametersRequest, &setApplePayVasParametersResponse, &executionResult);
            Code retResponseCode;
            executionResult->GetErrorCode(&retResponseCode);
            PluginSetApplePayVasParametersResponse response;
            std::optional<ManageSetApplePayVasParametersResponse> rsp = response.get(setApplePayVasParametersResponse)? std::optional<ManageSetApplePayVasParametersResponse>(*response.get(setApplePayVasParametersResponse)): std::nullopt;
            if(retResponseCode == Code::Code_Ok && rsp != std::nullopt)
            {
                ErrorOr<ManageSetApplePayVasParametersResponse> reply(*rsp);
                result(reply);
            }
            else
            {
                ManageSetApplePayVasParametersResponse errorRsp;
                errorRsp.set_response_message(Tool::Tools::ParseExecutionResultCodeToString(retResponseCode));
                ErrorOr<ManageSetApplePayVasParametersResponse> reply(errorRsp);
                result(reply);
            }
            CoUninitialize();
        });
        t1.detach();
    }

    void POSLinkPluginManage::SetGoogleSmartTapParameters(const ManageSetGoogleSmartTapParametersRequest& req, std::function<void(ErrorOr<ManageSetGoogleSmartTapParametersResponse> reply)> result)
    {
        std::thread t1([req, result]{
            CoInitialize(NULL);
            if(g_multiCommand.IsDoMultiCommand)
            {
                CComPtr<_SetGoogleSmartTapParametersRequest> comReq = NULL;
                PluginSetGoogleSmartTapParametersRequest pluginSetGoogleSmartTapParametersRequest;
                comReq = pluginSetGoogleSmartTapParametersRequest.set(req);
                g_multiCommand.AddReq(comReq);
                g_multiCommand.AddRsp("ManageSetGoogleSmartTapParametersResponse", std::move(result));
                return;
            }
            CComPtr<_SetGoogleSmartTapParametersRequest> setGoogleSmartTapParametersRequest = NULL;
            PluginSetGoogleSmartTapParametersRequest request;
            setGoogleSmartTapParametersRequest = request.set(req);

            CComPtr<_SetGoogleSmartTapParametersResponse> setGoogleSmartTapParametersResponse = NULL;

            if(g_commSetting.GlobalTerminal == NULL) return;
            CComPtr<_Manage> manage = NULL;
            g_commSetting.GlobalTerminal->get_Manage(&manage);
            CComPtr<_ExecutionResult> executionResult = NULL;
            manage->SetGoogleSmartTapParameters(setGoogleSmartTapParametersRequest, &setGoogleSmartTapParametersResponse, &executionResult);
            Code retResponseCode;
            executionResult->GetErrorCode(&retResponseCode);
            PluginSetGoogleSmartTapParametersResponse response;
            std::optional<ManageSetGoogleSmartTapParametersResponse> rsp = response.get(setGoogleSmartTapParametersResponse)? std::optional<ManageSetGoogleSmartTapParametersResponse>(*response.get(setGoogleSmartTapParametersResponse)): std::nullopt;
            if(retResponseCode == Code::Code_Ok && rsp != std::nullopt)
            {
                ErrorOr<ManageSetGoogleSmartTapParametersResponse> reply(*rsp);
                result(reply);
            }
            else
            {
                ManageSetGoogleSmartTapParametersResponse errorRsp;
                errorRsp.set_response_message(Tool::Tools::ParseExecutionResultCodeToString(retResponseCode));
                ErrorOr<ManageSetGoogleSmartTapParametersResponse> reply(errorRsp);
                result(reply);
            }
            CoUninitialize();
        });
        t1.detach();
    }

    void POSLinkPluginManage::SetVariable(const ManageSetVariableRequest& req, std::function<void(ErrorOr<ManageSetVariableResponse> reply)> result)
    {
        std::thread t1([req, result]{
            CoInitialize(NULL);
            if(g_multiCommand.IsDoMultiCommand)
            {
                CComPtr<_SetVariableRequest> comReq = NULL;
                PluginSetVariableRequest pluginSetVariableRequest;
                comReq = pluginSetVariableRequest.set(req);
                g_multiCommand.AddReq(comReq);
                g_multiCommand.AddRsp("ManageSetVariableResponse", std::move(result));
                return;
            }
            CComPtr<_SetVariableRequest> setVariableRequest = NULL;
            PluginSetVariableRequest request;
            setVariableRequest = request.set(req);

            CComPtr<_SetVariableResponse> setVariableResponse = NULL;

            if(g_commSetting.GlobalTerminal == NULL) return;
            CComPtr<_Manage> manage = NULL;
            g_commSetting.GlobalTerminal->get_Manage(&manage);
            CComPtr<_ExecutionResult> executionResult = NULL;
            manage->SetVariable(setVariableRequest, &setVariableResponse, &executionResult);
            Code retResponseCode;
            executionResult->GetErrorCode(&retResponseCode);
            PluginSetVariableResponse response;
            std::optional<ManageSetVariableResponse> rsp = response.get(setVariableResponse)? std::optional<ManageSetVariableResponse>(*response.get(setVariableResponse)): std::nullopt;
            if(retResponseCode == Code::Code_Ok && rsp != std::nullopt)
            {
                ErrorOr<ManageSetVariableResponse> reply(*rsp);
                result(reply);
            }
            else
            {
                ManageSetVariableResponse errorRsp;
                errorRsp.set_response_message(Tool::Tools::ParseExecutionResultCodeToString(retResponseCode));
                ErrorOr<ManageSetVariableResponse> reply(errorRsp);
                result(reply);
            }
            CoUninitialize();
        });
        t1.detach();
    }

    void POSLinkPluginManage::UpdateResourceFile(const ManageUpdateResourceFileRequest& req, std::function<void(ErrorOr<ManageUpdateResourceFileResponse> reply)> result)
    {
        std::thread t1([req, result]{
            CoInitialize(NULL);
            if(g_multiCommand.IsDoMultiCommand)
            {
                CComPtr<_UpdateResourceFileRequest> comReq = NULL;
                PluginUpdateResourceFileRequest pluginUpdateResourceFileRequest;
                comReq = pluginUpdateResourceFileRequest.set(req);
                g_multiCommand.AddReq(comReq);
                g_multiCommand.AddRsp("ManageUpdateResourceFileResponse", std::move(result));
                return;
            }
            CComPtr<_UpdateResourceFileRequest> updateResourceFileRequest = NULL;
            PluginUpdateResourceFileRequest request;
            updateResourceFileRequest = request.set(req);

            CComPtr<_UpdateResourceFileResponse> updateResourceFileResponse = NULL;

            if(g_commSetting.GlobalTerminal == NULL) return;
            CComPtr<_Manage> manage = NULL;
            g_commSetting.GlobalTerminal->get_Manage(&manage);
            CComPtr<_ExecutionResult> executionResult = NULL;
            manage->UpdateResourceFile(updateResourceFileRequest, &updateResourceFileResponse, &executionResult);
            Code retResponseCode;
            executionResult->GetErrorCode(&retResponseCode);
            PluginUpdateResourceFileResponse response;
            std::optional<ManageUpdateResourceFileResponse> rsp = response.get(updateResourceFileResponse)? std::optional<ManageUpdateResourceFileResponse>(*response.get(updateResourceFileResponse)): std::nullopt;
            if(retResponseCode == Code::Code_Ok && rsp != std::nullopt)
            {
                ErrorOr<ManageUpdateResourceFileResponse> reply(*rsp);
                result(reply);
            }
            else
            {
                ManageUpdateResourceFileResponse errorRsp;
                errorRsp.set_response_message(Tool::Tools::ParseExecutionResultCodeToString(retResponseCode));
                ErrorOr<ManageUpdateResourceFileResponse> reply(errorRsp);
                result(reply);
            }
            CoUninitialize();
        });
        t1.detach();
    }

    void POSLinkPluginManage::VasPushData(const ManageVasPushDataRequest& req, std::function<void(ErrorOr<ManageVasPushDataResponse> reply)> result)
    {
        std::thread t1([req, result]{
            CoInitialize(NULL);
            if(g_multiCommand.IsDoMultiCommand)
            {
                CComPtr<_VasPushDataRequest> comReq = NULL;
                PluginVasPushDataRequest pluginVasPushDataRequest;
                comReq = pluginVasPushDataRequest.set(req);
                g_multiCommand.AddReq(comReq);
                g_multiCommand.AddRsp("ManageVasPushDataResponse", std::move(result));
                return;
            }
            CComPtr<_VasPushDataRequest> vasPushDataRequest = NULL;
            PluginVasPushDataRequest request;
            vasPushDataRequest = request.set(req);

            CComPtr<_VasPushDataResponse> vasPushDataResponse = NULL;

            if(g_commSetting.GlobalTerminal == NULL) return;
            CComPtr<_Manage> manage = NULL;
            g_commSetting.GlobalTerminal->get_Manage(&manage);
            CComPtr<_ExecutionResult> executionResult = NULL;
            manage->VasPushData(vasPushDataRequest, &vasPushDataResponse, &executionResult);
            Code retResponseCode;
            executionResult->GetErrorCode(&retResponseCode);
            PluginVasPushDataResponse response;
            std::optional<ManageVasPushDataResponse> rsp = response.get(vasPushDataResponse)? std::optional<ManageVasPushDataResponse>(*response.get(vasPushDataResponse)): std::nullopt;
            if(retResponseCode == Code::Code_Ok && rsp != std::nullopt)
            {
                ErrorOr<ManageVasPushDataResponse> reply(*rsp);
                result(reply);
            }
            else
            {
                ManageVasPushDataResponse errorRsp;
                errorRsp.set_response_message(Tool::Tools::ParseExecutionResultCodeToString(retResponseCode));
                ErrorOr<ManageVasPushDataResponse> reply(errorRsp);
                result(reply);
            }
            CoUninitialize();
        });
        t1.detach();
    }

}

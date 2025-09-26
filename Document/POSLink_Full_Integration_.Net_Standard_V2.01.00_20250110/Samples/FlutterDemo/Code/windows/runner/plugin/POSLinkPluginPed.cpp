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
#include "POSLinkPluginPed.h"
#include <thread>

namespace POSLinkPed{

    POSLinkPluginPed::POSLinkPluginPed(){}

    void POSLinkPluginPed::GetPedInformation(const PedGetPedInformationRequest& req, std::function<void(ErrorOr<PedGetPedInformationResponse> reply)> result)
    {
        std::thread t1([req, result]{
            CoInitialize(NULL);
            if(g_multiCommand.IsDoMultiCommand)
            {
                CComPtr<_GetPedInformationRequest> comReq = NULL;
                PluginGetPedInformationRequest pluginGetPedInformationRequest;
                comReq = pluginGetPedInformationRequest.set(req);
                g_multiCommand.AddReq(comReq);
                g_multiCommand.AddRsp("PedGetPedInformationResponse", std::move(result));
                return;
            }
            CComPtr<_GetPedInformationRequest> getPedInformationRequest = NULL;
            PluginGetPedInformationRequest request;
            getPedInformationRequest = request.set(req);

            CComPtr<_GetPedInformationResponse> getPedInformationResponse = NULL;

            if(g_commSetting.GlobalTerminal == NULL) return;
            CComPtr<_Ped> ped = NULL;
            g_commSetting.GlobalTerminal->get_Ped(&ped);
            CComPtr<_ExecutionResult> executionResult = NULL;
            ped->GetPedInformation(getPedInformationRequest, &getPedInformationResponse, &executionResult);
            Code retResponseCode;
            executionResult->GetErrorCode(&retResponseCode);
            PluginGetPedInformationResponse response;
            std::optional<PedGetPedInformationResponse> rsp = response.get(getPedInformationResponse)? std::optional<PedGetPedInformationResponse>(*response.get(getPedInformationResponse)): std::nullopt;
            if(retResponseCode == Code::Code_Ok && rsp != std::nullopt)
            {
                ErrorOr<PedGetPedInformationResponse> reply(*rsp);
                result(reply);
            }
            else
            {
                PedGetPedInformationResponse errorRsp;
                errorRsp.set_response_message(Tool::Tools::ParseExecutionResultCodeToString(retResponseCode));
                ErrorOr<PedGetPedInformationResponse> reply(errorRsp);
                result(reply);
            }
            CoUninitialize();
        });
        t1.detach();
    }

    void POSLinkPluginPed::IncreaseKsn(const PedIncreaseKsnRequest& req, std::function<void(ErrorOr<PedIncreaseKsnResponse> reply)> result)
    {
        std::thread t1([req, result]{
            CoInitialize(NULL);
            if(g_multiCommand.IsDoMultiCommand)
            {
                CComPtr<_IncreaseKsnRequest> comReq = NULL;
                PluginIncreaseKsnRequest pluginIncreaseKsnRequest;
                comReq = pluginIncreaseKsnRequest.set(req);
                g_multiCommand.AddReq(comReq);
                g_multiCommand.AddRsp("PedIncreaseKsnResponse", std::move(result));
                return;
            }
            CComPtr<_IncreaseKsnRequest> increaseKsnRequest = NULL;
            PluginIncreaseKsnRequest request;
            increaseKsnRequest = request.set(req);

            CComPtr<_IncreaseKsnResponse> increaseKsnResponse = NULL;

            if(g_commSetting.GlobalTerminal == NULL) return;
            CComPtr<_Ped> ped = NULL;
            g_commSetting.GlobalTerminal->get_Ped(&ped);
            CComPtr<_ExecutionResult> executionResult = NULL;
            ped->IncreaseKsn(increaseKsnRequest, &increaseKsnResponse, &executionResult);
            Code retResponseCode;
            executionResult->GetErrorCode(&retResponseCode);
            PluginIncreaseKsnResponse response;
            std::optional<PedIncreaseKsnResponse> rsp = response.get(increaseKsnResponse)? std::optional<PedIncreaseKsnResponse>(*response.get(increaseKsnResponse)): std::nullopt;
            if(retResponseCode == Code::Code_Ok && rsp != std::nullopt)
            {
                ErrorOr<PedIncreaseKsnResponse> reply(*rsp);
                result(reply);
            }
            else
            {
                PedIncreaseKsnResponse errorRsp;
                errorRsp.set_response_message(Tool::Tools::ParseExecutionResultCodeToString(retResponseCode));
                ErrorOr<PedIncreaseKsnResponse> reply(errorRsp);
                result(reply);
            }
            CoUninitialize();
        });
        t1.detach();
    }

    void POSLinkPluginPed::MacCalculation(const PedMacCalculationRequest& req, std::function<void(ErrorOr<PedMacCalculationResponse> reply)> result)
    {
        std::thread t1([req, result]{
            CoInitialize(NULL);
            if(g_multiCommand.IsDoMultiCommand)
            {
                CComPtr<_MacCalculationRequest> comReq = NULL;
                PluginMacCalculationRequest pluginMacCalculationRequest;
                comReq = pluginMacCalculationRequest.set(req);
                g_multiCommand.AddReq(comReq);
                g_multiCommand.AddRsp("PedMacCalculationResponse", std::move(result));
                return;
            }
            CComPtr<_MacCalculationRequest> macCalculationRequest = NULL;
            PluginMacCalculationRequest request;
            macCalculationRequest = request.set(req);

            CComPtr<_MacCalculationResponse> macCalculationResponse = NULL;

            if(g_commSetting.GlobalTerminal == NULL) return;
            CComPtr<_Ped> ped = NULL;
            g_commSetting.GlobalTerminal->get_Ped(&ped);
            CComPtr<_ExecutionResult> executionResult = NULL;
            ped->MacCalculation(macCalculationRequest, &macCalculationResponse, &executionResult);
            Code retResponseCode;
            executionResult->GetErrorCode(&retResponseCode);
            PluginMacCalculationResponse response;
            std::optional<PedMacCalculationResponse> rsp = response.get(macCalculationResponse)? std::optional<PedMacCalculationResponse>(*response.get(macCalculationResponse)): std::nullopt;
            if(retResponseCode == Code::Code_Ok && rsp != std::nullopt)
            {
                ErrorOr<PedMacCalculationResponse> reply(*rsp);
                result(reply);
            }
            else
            {
                PedMacCalculationResponse errorRsp;
                errorRsp.set_response_message(Tool::Tools::ParseExecutionResultCodeToString(retResponseCode));
                ErrorOr<PedMacCalculationResponse> reply(errorRsp);
                result(reply);
            }
            CoUninitialize();
        });
        t1.detach();
    }

    void POSLinkPluginPed::SessionKeyInjection(const PedSessionKeyInjectionRequest& req, std::function<void(ErrorOr<PedSessionKeyInjectionResponse> reply)> result)
    {
        std::thread t1([req, result]{
            CoInitialize(NULL);
            if(g_multiCommand.IsDoMultiCommand)
            {
                CComPtr<_SessionKeyInjectionRequest> comReq = NULL;
                PluginSessionKeyInjectionRequest pluginSessionKeyInjectionRequest;
                comReq = pluginSessionKeyInjectionRequest.set(req);
                g_multiCommand.AddReq(comReq);
                g_multiCommand.AddRsp("PedSessionKeyInjectionResponse", std::move(result));
                return;
            }
            CComPtr<_SessionKeyInjectionRequest> sessionKeyInjectionRequest = NULL;
            PluginSessionKeyInjectionRequest request;
            sessionKeyInjectionRequest = request.set(req);

            CComPtr<_SessionKeyInjectionResponse> sessionKeyInjectionResponse = NULL;

            if(g_commSetting.GlobalTerminal == NULL) return;
            CComPtr<_Ped> ped = NULL;
            g_commSetting.GlobalTerminal->get_Ped(&ped);
            CComPtr<_ExecutionResult> executionResult = NULL;
            ped->SessionKeyInjection(sessionKeyInjectionRequest, &sessionKeyInjectionResponse, &executionResult);
            Code retResponseCode;
            executionResult->GetErrorCode(&retResponseCode);
            PluginSessionKeyInjectionResponse response;
            std::optional<PedSessionKeyInjectionResponse> rsp = response.get(sessionKeyInjectionResponse)? std::optional<PedSessionKeyInjectionResponse>(*response.get(sessionKeyInjectionResponse)): std::nullopt;
            if(retResponseCode == Code::Code_Ok && rsp != std::nullopt)
            {
                ErrorOr<PedSessionKeyInjectionResponse> reply(*rsp);
                result(reply);
            }
            else
            {
                PedSessionKeyInjectionResponse errorRsp;
                errorRsp.set_response_message(Tool::Tools::ParseExecutionResultCodeToString(retResponseCode));
                ErrorOr<PedSessionKeyInjectionResponse> reply(errorRsp);
                result(reply);
            }
            CoUninitialize();
        });
        t1.detach();
    }

}

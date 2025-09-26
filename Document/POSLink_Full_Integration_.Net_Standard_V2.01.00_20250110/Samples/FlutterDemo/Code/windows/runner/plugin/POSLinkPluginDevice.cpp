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
#include "POSLinkPluginDevice.h"
#include <thread>

namespace POSLinkDevice{

    POSLinkPluginDevice::POSLinkPluginDevice(){}

    void POSLinkPluginDevice::CameraScan(const DeviceCameraScanRequest& req, std::function<void(ErrorOr<DeviceCameraScanResponse> reply)> result)
    {
        std::thread t1([req, result]{
            CoInitialize(NULL);
            if(g_multiCommand.IsDoMultiCommand)
            {
                CComPtr<_CameraScanRequest> comReq = NULL;
                PluginCameraScanRequest pluginCameraScanRequest;
                comReq = pluginCameraScanRequest.set(req);
                g_multiCommand.AddReq(comReq);
                g_multiCommand.AddRsp("DeviceCameraScanResponse", std::move(result));
                return;
            }
            CComPtr<_CameraScanRequest> cameraScanRequest = NULL;
            PluginCameraScanRequest request;
            cameraScanRequest = request.set(req);

            CComPtr<_CameraScanResponse> cameraScanResponse = NULL;

            if(g_commSetting.GlobalTerminal == NULL) return;
            CComPtr<_Device> device = NULL;
            g_commSetting.GlobalTerminal->get_Device(&device);
            CComPtr<_Camera> camera = NULL;
            device->get_Camera(&camera);
            CComPtr<_ExecutionResult> executionResult = NULL;
            camera->CameraScan(cameraScanRequest, &cameraScanResponse, &executionResult);
            Code retResponseCode;
            executionResult->GetErrorCode(&retResponseCode);
            PluginCameraScanResponse response;
            std::optional<DeviceCameraScanResponse> rsp = response.get(cameraScanResponse)? std::optional<DeviceCameraScanResponse>(*response.get(cameraScanResponse)): std::nullopt;
            if(retResponseCode == Code::Code_Ok && rsp != std::nullopt)
            {
                ErrorOr<DeviceCameraScanResponse> reply(*rsp);
                result(reply);
            }
            else
            {
                DeviceCameraScanResponse errorRsp;
                errorRsp.set_response_message(Tool::Tools::ParseExecutionResultCodeToString(retResponseCode));
                ErrorOr<DeviceCameraScanResponse> reply(errorRsp);
                result(reply);
            }
            CoUninitialize();
        });
        t1.detach();
    }

    void POSLinkPluginDevice::CardInsertDetection(const DeviceCardInsertDetectionRequest& req, std::function<void(ErrorOr<DeviceCardInsertDetectionResponse> reply)> result)
    {
        std::thread t1([req, result]{
            CoInitialize(NULL);
            if(g_multiCommand.IsDoMultiCommand)
            {
                CComPtr<_CardInsertDetectionRequest> comReq = NULL;
                PluginCardInsertDetectionRequest pluginCardInsertDetectionRequest;
                comReq = pluginCardInsertDetectionRequest.set(req);
                g_multiCommand.AddReq(comReq);
                g_multiCommand.AddRsp("DeviceCardInsertDetectionResponse", std::move(result));
                return;
            }
            CComPtr<_CardInsertDetectionRequest> cardInsertDetectionRequest = NULL;
            PluginCardInsertDetectionRequest request;
            cardInsertDetectionRequest = request.set(req);

            CComPtr<_CardInsertDetectionResponse> cardInsertDetectionResponse = NULL;

            if(g_commSetting.GlobalTerminal == NULL) return;
            CComPtr<_Device> device = NULL;
            g_commSetting.GlobalTerminal->get_Device(&device);
            CComPtr<_Card> card = NULL;
            device->get_Card(&card);
            CComPtr<_ExecutionResult> executionResult = NULL;
            card->CardInsertDetection(&cardInsertDetectionResponse, &executionResult);
            Code retResponseCode;
            executionResult->GetErrorCode(&retResponseCode);
            PluginCardInsertDetectionResponse response;
            std::optional<DeviceCardInsertDetectionResponse> rsp = response.get(cardInsertDetectionResponse)? std::optional<DeviceCardInsertDetectionResponse>(*response.get(cardInsertDetectionResponse)): std::nullopt;
            if(retResponseCode == Code::Code_Ok && rsp != std::nullopt)
            {
                ErrorOr<DeviceCardInsertDetectionResponse> reply(*rsp);
                result(reply);
            }
            else
            {
                DeviceCardInsertDetectionResponse errorRsp;
                errorRsp.set_response_message(Tool::Tools::ParseExecutionResultCodeToString(retResponseCode));
                ErrorOr<DeviceCardInsertDetectionResponse> reply(errorRsp);
                result(reply);
            }
            CoUninitialize();
        });
        t1.detach();
    }

    void POSLinkPluginDevice::MifareCard(const DeviceMifareCardRequest& req, std::function<void(ErrorOr<DeviceMifareCardResponse> reply)> result)
    {
        std::thread t1([req, result]{
            CoInitialize(NULL);
            if(g_multiCommand.IsDoMultiCommand)
            {
                CComPtr<_MifareCardRequest> comReq = NULL;
                PluginMifareCardRequest pluginMifareCardRequest;
                comReq = pluginMifareCardRequest.set(req);
                g_multiCommand.AddReq(comReq);
                g_multiCommand.AddRsp("DeviceMifareCardResponse", std::move(result));
                return;
            }
            CComPtr<_MifareCardRequest> mifareCardRequest = NULL;
            PluginMifareCardRequest request;
            mifareCardRequest = request.set(req);

            CComPtr<_MifareCardResponse> mifareCardResponse = NULL;

            if(g_commSetting.GlobalTerminal == NULL) return;
            CComPtr<_Device> device = NULL;
            g_commSetting.GlobalTerminal->get_Device(&device);
            CComPtr<_MifareCard> mifareCard = NULL;
            device->get_MifareCard(&mifareCard);
            CComPtr<_ExecutionResult> executionResult = NULL;
            mifareCard->Operate(mifareCardRequest, &mifareCardResponse, &executionResult);
            Code retResponseCode;
            executionResult->GetErrorCode(&retResponseCode);
            PluginMifareCardResponse response;
            std::optional<DeviceMifareCardResponse> rsp = response.get(mifareCardResponse)? std::optional<DeviceMifareCardResponse>(*response.get(mifareCardResponse)): std::nullopt;
            if(retResponseCode == Code::Code_Ok && rsp != std::nullopt)
            {
                ErrorOr<DeviceMifareCardResponse> reply(*rsp);
                result(reply);
            }
            else
            {
                DeviceMifareCardResponse errorRsp;
                errorRsp.set_response_message(Tool::Tools::ParseExecutionResultCodeToString(retResponseCode));
                ErrorOr<DeviceMifareCardResponse> reply(errorRsp);
                result(reply);
            }
            CoUninitialize();
        });
        t1.detach();
    }

    void POSLinkPluginDevice::Printer(const DevicePrinterRequest& req, std::function<void(ErrorOr<DevicePrinterResponse> reply)> result)
    {
        std::thread t1([req, result]{
            CoInitialize(NULL);
            if(g_multiCommand.IsDoMultiCommand)
            {
                CComPtr<_PrinterRequest> comReq = NULL;
                PluginPrinterRequest pluginPrinterRequest;
                comReq = pluginPrinterRequest.set(req);
                g_multiCommand.AddReq(comReq);
                g_multiCommand.AddRsp("DevicePrinterResponse", std::move(result));
                return;
            }
            CComPtr<_PrinterRequest> printerRequest = NULL;
            PluginPrinterRequest request;
            printerRequest = request.set(req);

            CComPtr<_PrinterResponse> printerResponse = NULL;

            if(g_commSetting.GlobalTerminal == NULL) return;
            CComPtr<_Device> device = NULL;
            g_commSetting.GlobalTerminal->get_Device(&device);
            CComPtr<_Printer> printer = NULL;
            device->get_Printer(&printer);
            CComPtr<_ExecutionResult> executionResult = NULL;
            printer->Print(printerRequest, &printerResponse, &executionResult);
            Code retResponseCode;
            executionResult->GetErrorCode(&retResponseCode);
            PluginPrinterResponse response;
            std::optional<DevicePrinterResponse> rsp = response.get(printerResponse)? std::optional<DevicePrinterResponse>(*response.get(printerResponse)): std::nullopt;
            if(retResponseCode == Code::Code_Ok && rsp != std::nullopt)
            {
                ErrorOr<DevicePrinterResponse> reply(*rsp);
                result(reply);
            }
            else
            {
                DevicePrinterResponse errorRsp;
                errorRsp.set_response_message(Tool::Tools::ParseExecutionResultCodeToString(retResponseCode));
                ErrorOr<DevicePrinterResponse> reply(errorRsp);
                result(reply);
            }
            CoUninitialize();
        });
        t1.detach();
    }

}

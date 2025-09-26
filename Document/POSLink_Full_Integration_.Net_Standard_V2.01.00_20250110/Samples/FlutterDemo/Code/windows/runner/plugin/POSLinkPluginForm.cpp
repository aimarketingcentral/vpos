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
#include "POSLinkPluginForm.h"
#include <thread>

namespace POSLinkForm{

    POSLinkPluginForm::POSLinkPluginForm(){}

    void POSLinkPluginForm::ClearMessage(const FormClearMessageRequest& req, std::function<void(ErrorOr<FormClearMessageResponse> reply)> result)
    {
        std::thread t1([req, result]{
            CoInitialize(NULL);
            if(g_multiCommand.IsDoMultiCommand)
            {
                CComPtr<_ClearMessageRequest> comReq = NULL;
                PluginClearMessageRequest pluginClearMessageRequest;
                comReq = pluginClearMessageRequest.set(req);
                g_multiCommand.AddReq(comReq);
                g_multiCommand.AddRsp("FormClearMessageResponse", std::move(result));
                return;
            }
            CComPtr<_ClearMessageRequest> clearMessageRequest = NULL;
            PluginClearMessageRequest request;
            clearMessageRequest = request.set(req);

            CComPtr<_ClearMessageResponse> clearMessageResponse = NULL;

            if(g_commSetting.GlobalTerminal == NULL) return;
            CComPtr<_Form> form = NULL;
            g_commSetting.GlobalTerminal->get_Form(&form);
            CComPtr<_ExecutionResult> executionResult = NULL;
            form->ClearMessage(&clearMessageResponse, &executionResult);
            Code retResponseCode;
            executionResult->GetErrorCode(&retResponseCode);
            PluginClearMessageResponse response;
            std::optional<FormClearMessageResponse> rsp = response.get(clearMessageResponse)? std::optional<FormClearMessageResponse>(*response.get(clearMessageResponse)): std::nullopt;
            if(retResponseCode == Code::Code_Ok && rsp != std::nullopt)
            {
                ErrorOr<FormClearMessageResponse> reply(*rsp);
                result(reply);
            }
            else
            {
                FormClearMessageResponse errorRsp;
                errorRsp.set_response_message(Tool::Tools::ParseExecutionResultCodeToString(retResponseCode));
                ErrorOr<FormClearMessageResponse> reply(errorRsp);
                result(reply);
            }
            CoUninitialize();
        });
        t1.detach();
    }

    void POSLinkPluginForm::InputText(const FormInputTextRequest& req, std::function<void(ErrorOr<FormInputTextResponse> reply)> result)
    {
        std::thread t1([req, result]{
            CoInitialize(NULL);
            if(g_multiCommand.IsDoMultiCommand)
            {
                CComPtr<_InputTextRequest> comReq = NULL;
                PluginInputTextRequest pluginInputTextRequest;
                comReq = pluginInputTextRequest.set(req);
                g_multiCommand.AddReq(comReq);
                g_multiCommand.AddRsp("FormInputTextResponse", std::move(result));
                return;
            }
            CComPtr<_InputTextRequest> inputTextRequest = NULL;
            PluginInputTextRequest request;
            inputTextRequest = request.set(req);

            CComPtr<_InputTextResponse> inputTextResponse = NULL;

            if(g_commSetting.GlobalTerminal == NULL) return;
            CComPtr<_Form> form = NULL;
            g_commSetting.GlobalTerminal->get_Form(&form);
            CComPtr<_ExecutionResult> executionResult = NULL;
            form->InputText(inputTextRequest, &inputTextResponse, &executionResult);
            Code retResponseCode;
            executionResult->GetErrorCode(&retResponseCode);
            PluginInputTextResponse response;
            std::optional<FormInputTextResponse> rsp = response.get(inputTextResponse)? std::optional<FormInputTextResponse>(*response.get(inputTextResponse)): std::nullopt;
            if(retResponseCode == Code::Code_Ok && rsp != std::nullopt)
            {
                ErrorOr<FormInputTextResponse> reply(*rsp);
                result(reply);
            }
            else
            {
                FormInputTextResponse errorRsp;
                errorRsp.set_response_message(Tool::Tools::ParseExecutionResultCodeToString(retResponseCode));
                ErrorOr<FormInputTextResponse> reply(errorRsp);
                result(reply);
            }
            CoUninitialize();
        });
        t1.detach();
    }

    void POSLinkPluginForm::RemoveCard(const FormRemoveCardRequest& req, std::function<void(ErrorOr<FormRemoveCardResponse> reply)> result)
    {
        std::thread t1([req, result]{
            CoInitialize(NULL);
            if(g_multiCommand.IsDoMultiCommand)
            {
                CComPtr<_RemoveCardRequest> comReq = NULL;
                PluginRemoveCardRequest pluginRemoveCardRequest;
                comReq = pluginRemoveCardRequest.set(req);
                g_multiCommand.AddReq(comReq);
                g_multiCommand.AddRsp("FormRemoveCardResponse", std::move(result));
                return;
            }
            CComPtr<_RemoveCardRequest> removeCardRequest = NULL;
            PluginRemoveCardRequest request;
            removeCardRequest = request.set(req);

            CComPtr<_RemoveCardResponse> removeCardResponse = NULL;

            if(g_commSetting.GlobalTerminal == NULL) return;
            CComPtr<_Form> form = NULL;
            g_commSetting.GlobalTerminal->get_Form(&form);
            CComPtr<_ExecutionResult> executionResult = NULL;
            form->RemoveCard(removeCardRequest, &removeCardResponse, &executionResult);
            Code retResponseCode;
            executionResult->GetErrorCode(&retResponseCode);
            PluginRemoveCardResponse response;
            std::optional<FormRemoveCardResponse> rsp = response.get(removeCardResponse)? std::optional<FormRemoveCardResponse>(*response.get(removeCardResponse)): std::nullopt;
            if(retResponseCode == Code::Code_Ok && rsp != std::nullopt)
            {
                ErrorOr<FormRemoveCardResponse> reply(*rsp);
                result(reply);
            }
            else
            {
                FormRemoveCardResponse errorRsp;
                errorRsp.set_response_message(Tool::Tools::ParseExecutionResultCodeToString(retResponseCode));
                ErrorOr<FormRemoveCardResponse> reply(errorRsp);
                result(reply);
            }
            CoUninitialize();
        });
        t1.detach();
    }

    void POSLinkPluginForm::ShowDialogForm(const FormShowDialogFormRequest& req, std::function<void(ErrorOr<FormShowDialogFormResponse> reply)> result)
    {
        std::thread t1([req, result]{
            CoInitialize(NULL);
            if(g_multiCommand.IsDoMultiCommand)
            {
                CComPtr<_ShowDialogFormRequest> comReq = NULL;
                PluginShowDialogFormRequest pluginShowDialogFormRequest;
                comReq = pluginShowDialogFormRequest.set(req);
                g_multiCommand.AddReq(comReq);
                g_multiCommand.AddRsp("FormShowDialogFormResponse", std::move(result));
                return;
            }
            CComPtr<_ShowDialogFormRequest> showDialogFormRequest = NULL;
            PluginShowDialogFormRequest request;
            showDialogFormRequest = request.set(req);

            CComPtr<_ShowDialogFormResponse> showDialogFormResponse = NULL;

            if(g_commSetting.GlobalTerminal == NULL) return;
            CComPtr<_Form> form = NULL;
            g_commSetting.GlobalTerminal->get_Form(&form);
            CComPtr<_ExecutionResult> executionResult = NULL;
            form->ShowDialogForm(showDialogFormRequest, &showDialogFormResponse, &executionResult);
            Code retResponseCode;
            executionResult->GetErrorCode(&retResponseCode);
            PluginShowDialogFormResponse response;
            std::optional<FormShowDialogFormResponse> rsp = response.get(showDialogFormResponse)? std::optional<FormShowDialogFormResponse>(*response.get(showDialogFormResponse)): std::nullopt;
            if(retResponseCode == Code::Code_Ok && rsp != std::nullopt)
            {
                ErrorOr<FormShowDialogFormResponse> reply(*rsp);
                result(reply);
            }
            else
            {
                FormShowDialogFormResponse errorRsp;
                errorRsp.set_response_message(Tool::Tools::ParseExecutionResultCodeToString(retResponseCode));
                ErrorOr<FormShowDialogFormResponse> reply(errorRsp);
                result(reply);
            }
            CoUninitialize();
        });
        t1.detach();
    }

    void POSLinkPluginForm::ShowDialog(const FormShowDialogRequest& req, std::function<void(ErrorOr<FormShowDialogResponse> reply)> result)
    {
        std::thread t1([req, result]{
            CoInitialize(NULL);
            if(g_multiCommand.IsDoMultiCommand)
            {
                CComPtr<_ShowDialogRequest> comReq = NULL;
                PluginShowDialogRequest pluginShowDialogRequest;
                comReq = pluginShowDialogRequest.set(req);
                g_multiCommand.AddReq(comReq);
                g_multiCommand.AddRsp("FormShowDialogResponse", std::move(result));
                return;
            }
            CComPtr<_ShowDialogRequest> showDialogRequest = NULL;
            PluginShowDialogRequest request;
            showDialogRequest = request.set(req);

            CComPtr<_ShowDialogResponse> showDialogResponse = NULL;

            if(g_commSetting.GlobalTerminal == NULL) return;
            CComPtr<_Form> form = NULL;
            g_commSetting.GlobalTerminal->get_Form(&form);
            CComPtr<_ExecutionResult> executionResult = NULL;
            form->ShowDialog(showDialogRequest, &showDialogResponse, &executionResult);
            Code retResponseCode;
            executionResult->GetErrorCode(&retResponseCode);
            PluginShowDialogResponse response;
            std::optional<FormShowDialogResponse> rsp = response.get(showDialogResponse)? std::optional<FormShowDialogResponse>(*response.get(showDialogResponse)): std::nullopt;
            if(retResponseCode == Code::Code_Ok && rsp != std::nullopt)
            {
                ErrorOr<FormShowDialogResponse> reply(*rsp);
                result(reply);
            }
            else
            {
                FormShowDialogResponse errorRsp;
                errorRsp.set_response_message(Tool::Tools::ParseExecutionResultCodeToString(retResponseCode));
                ErrorOr<FormShowDialogResponse> reply(errorRsp);
                result(reply);
            }
            CoUninitialize();
        });
        t1.detach();
    }

    void POSLinkPluginForm::ShowItem(const FormShowItemRequest& req, std::function<void(ErrorOr<FormShowItemResponse> reply)> result)
    {
        std::thread t1([req, result]{
            CoInitialize(NULL);
            if(g_multiCommand.IsDoMultiCommand)
            {
                CComPtr<_ShowItemRequest> comReq = NULL;
                PluginShowItemRequest pluginShowItemRequest;
                comReq = pluginShowItemRequest.set(req);
                g_multiCommand.AddReq(comReq);
                g_multiCommand.AddRsp("FormShowItemResponse", std::move(result));
                return;
            }
            CComPtr<_ShowItemRequest> showItemRequest = NULL;
            PluginShowItemRequest request;
            showItemRequest = request.set(req);

            CComPtr<_ShowItemResponse> showItemResponse = NULL;

            if(g_commSetting.GlobalTerminal == NULL) return;
            CComPtr<_Form> form = NULL;
            g_commSetting.GlobalTerminal->get_Form(&form);
            CComPtr<_ExecutionResult> executionResult = NULL;
            form->ShowItem(showItemRequest, &showItemResponse, &executionResult);
            Code retResponseCode;
            executionResult->GetErrorCode(&retResponseCode);
            PluginShowItemResponse response;
            std::optional<FormShowItemResponse> rsp = response.get(showItemResponse)? std::optional<FormShowItemResponse>(*response.get(showItemResponse)): std::nullopt;
            if(retResponseCode == Code::Code_Ok && rsp != std::nullopt)
            {
                ErrorOr<FormShowItemResponse> reply(*rsp);
                result(reply);
            }
            else
            {
                FormShowItemResponse errorRsp;
                errorRsp.set_response_message(Tool::Tools::ParseExecutionResultCodeToString(retResponseCode));
                ErrorOr<FormShowItemResponse> reply(errorRsp);
                result(reply);
            }
            CoUninitialize();
        });
        t1.detach();
    }

    void POSLinkPluginForm::ShowMessageCenter(const FormShowMessageCenterRequest& req, std::function<void(ErrorOr<FormShowMessageCenterResponse> reply)> result)
    {
        std::thread t1([req, result]{
            CoInitialize(NULL);
            if(g_multiCommand.IsDoMultiCommand)
            {
                CComPtr<_ShowMessageCenterRequest> comReq = NULL;
                PluginShowMessageCenterRequest pluginShowMessageCenterRequest;
                comReq = pluginShowMessageCenterRequest.set(req);
                g_multiCommand.AddReq(comReq);
                g_multiCommand.AddRsp("FormShowMessageCenterResponse", std::move(result));
                return;
            }
            CComPtr<_ShowMessageCenterRequest> showMessageCenterRequest = NULL;
            PluginShowMessageCenterRequest request;
            showMessageCenterRequest = request.set(req);

            CComPtr<_ShowMessageCenterResponse> showMessageCenterResponse = NULL;

            if(g_commSetting.GlobalTerminal == NULL) return;
            CComPtr<_Form> form = NULL;
            g_commSetting.GlobalTerminal->get_Form(&form);
            CComPtr<_ExecutionResult> executionResult = NULL;
            form->ShowMessageCenter(showMessageCenterRequest, &showMessageCenterResponse, &executionResult);
            Code retResponseCode;
            executionResult->GetErrorCode(&retResponseCode);
            PluginShowMessageCenterResponse response;
            std::optional<FormShowMessageCenterResponse> rsp = response.get(showMessageCenterResponse)? std::optional<FormShowMessageCenterResponse>(*response.get(showMessageCenterResponse)): std::nullopt;
            if(retResponseCode == Code::Code_Ok && rsp != std::nullopt)
            {
                ErrorOr<FormShowMessageCenterResponse> reply(*rsp);
                result(reply);
            }
            else
            {
                FormShowMessageCenterResponse errorRsp;
                errorRsp.set_response_message(Tool::Tools::ParseExecutionResultCodeToString(retResponseCode));
                ErrorOr<FormShowMessageCenterResponse> reply(errorRsp);
                result(reply);
            }
            CoUninitialize();
        });
        t1.detach();
    }

    void POSLinkPluginForm::ShowMessage(const FormShowMessageRequest& req, std::function<void(ErrorOr<FormShowMessageResponse> reply)> result)
    {
        std::thread t1([req, result]{
            CoInitialize(NULL);
            if(g_multiCommand.IsDoMultiCommand)
            {
                CComPtr<_ShowMessageRequest> comReq = NULL;
                PluginShowMessageRequest pluginShowMessageRequest;
                comReq = pluginShowMessageRequest.set(req);
                g_multiCommand.AddReq(comReq);
                g_multiCommand.AddRsp("FormShowMessageResponse", std::move(result));
                return;
            }
            CComPtr<_ShowMessageRequest> showMessageRequest = NULL;
            PluginShowMessageRequest request;
            showMessageRequest = request.set(req);

            CComPtr<_ShowMessageResponse> showMessageResponse = NULL;

            if(g_commSetting.GlobalTerminal == NULL) return;
            CComPtr<_Form> form = NULL;
            g_commSetting.GlobalTerminal->get_Form(&form);
            CComPtr<_ExecutionResult> executionResult = NULL;
            form->ShowMessage(showMessageRequest, &showMessageResponse, &executionResult);
            Code retResponseCode;
            executionResult->GetErrorCode(&retResponseCode);
            PluginShowMessageResponse response;
            std::optional<FormShowMessageResponse> rsp = response.get(showMessageResponse)? std::optional<FormShowMessageResponse>(*response.get(showMessageResponse)): std::nullopt;
            if(retResponseCode == Code::Code_Ok && rsp != std::nullopt)
            {
                ErrorOr<FormShowMessageResponse> reply(*rsp);
                result(reply);
            }
            else
            {
                FormShowMessageResponse errorRsp;
                errorRsp.set_response_message(Tool::Tools::ParseExecutionResultCodeToString(retResponseCode));
                ErrorOr<FormShowMessageResponse> reply(errorRsp);
                result(reply);
            }
            CoUninitialize();
        });
        t1.detach();
    }

    void POSLinkPluginForm::ShowTextBox(const FormShowTextBoxRequest& req, std::function<void(ErrorOr<FormShowTextBoxResponse> reply)> result)
    {
        std::thread t1([req, result]{
            CoInitialize(NULL);
            if(g_multiCommand.IsDoMultiCommand)
            {
                CComPtr<_ShowTextBoxRequest> comReq = NULL;
                PluginShowTextBoxRequest pluginShowTextBoxRequest;
                comReq = pluginShowTextBoxRequest.set(req);
                g_multiCommand.AddReq(comReq);
                g_multiCommand.AddRsp("FormShowTextBoxResponse", std::move(result));
                return;
            }
            CComPtr<_ShowTextBoxRequest> showTextBoxRequest = NULL;
            PluginShowTextBoxRequest request;
            showTextBoxRequest = request.set(req);

            CComPtr<_ShowTextBoxResponse> showTextBoxResponse = NULL;

            if(g_commSetting.GlobalTerminal == NULL) return;
            CComPtr<_Form> form = NULL;
            g_commSetting.GlobalTerminal->get_Form(&form);
            CComPtr<_ExecutionResult> executionResult = NULL;
            form->ShowTextBox(showTextBoxRequest, &showTextBoxResponse, &executionResult);
            Code retResponseCode;
            executionResult->GetErrorCode(&retResponseCode);
            PluginShowTextBoxResponse response;
            std::optional<FormShowTextBoxResponse> rsp = response.get(showTextBoxResponse)? std::optional<FormShowTextBoxResponse>(*response.get(showTextBoxResponse)): std::nullopt;
            if(retResponseCode == Code::Code_Ok && rsp != std::nullopt)
            {
                ErrorOr<FormShowTextBoxResponse> reply(*rsp);
                result(reply);
            }
            else
            {
                FormShowTextBoxResponse errorRsp;
                errorRsp.set_response_message(Tool::Tools::ParseExecutionResultCodeToString(retResponseCode));
                ErrorOr<FormShowTextBoxResponse> reply(errorRsp);
                result(reply);
            }
            CoUninitialize();
        });
        t1.detach();
    }

}

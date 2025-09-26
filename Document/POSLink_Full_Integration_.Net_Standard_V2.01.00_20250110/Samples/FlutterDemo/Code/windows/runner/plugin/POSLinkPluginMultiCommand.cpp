#pragma once
#undef _HAS_EXCEPTIONS
#include "POSLinkPluginMultiCommand.h"

namespace POSLinkMultiCommand{
    POSLinkPluginMultiCommand::POSLinkPluginMultiCommand(){};

    std::optional<FlutterError> POSLinkPluginMultiCommand::StartMultiCommand()
    {
        std::optional<FlutterError> ret;
        g_multiCommand.IsDoMultiCommand = true;
        return ret;
    }

    std::optional<FlutterError> POSLinkPluginMultiCommand::CancelMultiCommand()
    {
        std::optional<FlutterError> ret;
        g_multiCommand.IsDoMultiCommand = false;
        g_multiCommand.ClearReq();
        g_multiCommand.ClearRsp();
        return ret;
    }

    void POSLinkPluginMultiCommand::CompleteMultiCommand(std::function<void(ErrorOr<Response> reply)> result)
    {
        CoInitialize(NULL);
        if(!g_multiCommand.IsDoMultiCommand)
        {
            return;
        }
        if(g_commSetting.GlobalTerminal == NULL) return;
        SAFEARRAY *psaReq = g_multiCommand.GetPsa();
        CComPtr<_MultipleCommandsResponse> comMultiCommandRsp = NULL;
        CComPtr<_ExecutionResult> executionResult = NULL;
        g_commSetting.GlobalTerminal->MultipleCommands(psaReq, &comMultiCommandRsp, &executionResult);
        Code retResponseCode;
        executionResult->GetErrorCode(&retResponseCode);
        if(retResponseCode == Code::Code_Ok)
        {
            SAFEARRAY *psa;
            comMultiCommandRsp->get_Responses(&psa);
            CComPtr<_Response>* bstrData;
            SafeArrayAccessData(psa, (void**)&bstrData);
            std::vector<std::any>::iterator iResult = g_multiCommand.Results.begin();
            std::vector<std::string>::iterator iFlag = g_multiCommand.ResultFlag.begin();
            for(int i=0;i<(int)psa->rgsabound->cElements;i++)
            {
                if(*iFlag == "DeviceCameraScanResponse")
                {
                    POSLinkDevice::PluginCameraScanResponse pluginRsp;
                    CComPtr<_CameraScanResponse> comRsp = NULL;
                    bstrData[i]->QueryInterface(&comRsp);
                    if(pluginRsp.get(comRsp))
                    {
                        POSLinkDevice::DeviceCameraScanResponse retRsp = *pluginRsp.get(comRsp);
                        if ((*iResult).type() == typeid(std::function<void(POSLinkDevice::ErrorOr<POSLinkDevice::DeviceCameraScanResponse>)>))
                        {
                            std::function<void(POSLinkDevice::ErrorOr<POSLinkDevice::DeviceCameraScanResponse>)> tmpFunction = std::any_cast<std::function<void(POSLinkDevice::ErrorOr<POSLinkDevice::DeviceCameraScanResponse>)>>((*iResult));
                            POSLinkDevice::ErrorOr<POSLinkDevice::DeviceCameraScanResponse> tmpReply(retRsp);
                            tmpFunction(tmpReply);
                        }
                    }
                }
                else if(*iFlag == "DeviceCardInsertDetectionResponse")
                {
                    POSLinkDevice::PluginCardInsertDetectionResponse pluginRsp;
                    CComPtr<_CardInsertDetectionResponse> comRsp = NULL;
                    bstrData[i]->QueryInterface(&comRsp);
                    if(pluginRsp.get(comRsp))
                    {
                        POSLinkDevice::DeviceCardInsertDetectionResponse retRsp = *pluginRsp.get(comRsp);
                        if ((*iResult).type() == typeid(std::function<void(POSLinkDevice::ErrorOr<POSLinkDevice::DeviceCardInsertDetectionResponse>)>))
                        {
                            std::function<void(POSLinkDevice::ErrorOr<POSLinkDevice::DeviceCardInsertDetectionResponse>)> tmpFunction = std::any_cast<std::function<void(POSLinkDevice::ErrorOr<POSLinkDevice::DeviceCardInsertDetectionResponse>)>>((*iResult));
                            POSLinkDevice::ErrorOr<POSLinkDevice::DeviceCardInsertDetectionResponse> tmpReply(retRsp);
                            tmpFunction(tmpReply);
                        }
                    }
                }
                else if(*iFlag == "DeviceMifareCardResponse")
                {
                    POSLinkDevice::PluginMifareCardResponse pluginRsp;
                    CComPtr<_MifareCardResponse> comRsp = NULL;
                    bstrData[i]->QueryInterface(&comRsp);
                    if(pluginRsp.get(comRsp))
                    {
                        POSLinkDevice::DeviceMifareCardResponse retRsp = *pluginRsp.get(comRsp);
                        if ((*iResult).type() == typeid(std::function<void(POSLinkDevice::ErrorOr<POSLinkDevice::DeviceMifareCardResponse>)>))
                        {
                            std::function<void(POSLinkDevice::ErrorOr<POSLinkDevice::DeviceMifareCardResponse>)> tmpFunction = std::any_cast<std::function<void(POSLinkDevice::ErrorOr<POSLinkDevice::DeviceMifareCardResponse>)>>((*iResult));
                            POSLinkDevice::ErrorOr<POSLinkDevice::DeviceMifareCardResponse> tmpReply(retRsp);
                            tmpFunction(tmpReply);
                        }
                    }
                }
                else if(*iFlag == "DevicePrinterResponse")
                {
                    POSLinkDevice::PluginPrinterResponse pluginRsp;
                    CComPtr<_PrinterResponse> comRsp = NULL;
                    bstrData[i]->QueryInterface(&comRsp);
                    if(pluginRsp.get(comRsp))
                    {
                        POSLinkDevice::DevicePrinterResponse retRsp = *pluginRsp.get(comRsp);
                        if ((*iResult).type() == typeid(std::function<void(POSLinkDevice::ErrorOr<POSLinkDevice::DevicePrinterResponse>)>))
                        {
                            std::function<void(POSLinkDevice::ErrorOr<POSLinkDevice::DevicePrinterResponse>)> tmpFunction = std::any_cast<std::function<void(POSLinkDevice::ErrorOr<POSLinkDevice::DevicePrinterResponse>)>>((*iResult));
                            POSLinkDevice::ErrorOr<POSLinkDevice::DevicePrinterResponse> tmpReply(retRsp);
                            tmpFunction(tmpReply);
                        }
                    }
                }
                if(*iFlag == "FormClearMessageResponse")
                {
                    POSLinkForm::PluginClearMessageResponse pluginRsp;
                    CComPtr<_ClearMessageResponse> comRsp = NULL;
                    bstrData[i]->QueryInterface(&comRsp);
                    if(pluginRsp.get(comRsp))
                    {
                        POSLinkForm::FormClearMessageResponse retRsp = *pluginRsp.get(comRsp);
                        if ((*iResult).type() == typeid(std::function<void(POSLinkForm::ErrorOr<POSLinkForm::FormClearMessageResponse>)>))
                        {
                            std::function<void(POSLinkForm::ErrorOr<POSLinkForm::FormClearMessageResponse>)> tmpFunction = std::any_cast<std::function<void(POSLinkForm::ErrorOr<POSLinkForm::FormClearMessageResponse>)>>((*iResult));
                            POSLinkForm::ErrorOr<POSLinkForm::FormClearMessageResponse> tmpReply(retRsp);
                            tmpFunction(tmpReply);
                        }
                    }
                }
                else if(*iFlag == "FormInputTextResponse")
                {
                    POSLinkForm::PluginInputTextResponse pluginRsp;
                    CComPtr<_InputTextResponse> comRsp = NULL;
                    bstrData[i]->QueryInterface(&comRsp);
                    if(pluginRsp.get(comRsp))
                    {
                        POSLinkForm::FormInputTextResponse retRsp = *pluginRsp.get(comRsp);
                        if ((*iResult).type() == typeid(std::function<void(POSLinkForm::ErrorOr<POSLinkForm::FormInputTextResponse>)>))
                        {
                            std::function<void(POSLinkForm::ErrorOr<POSLinkForm::FormInputTextResponse>)> tmpFunction = std::any_cast<std::function<void(POSLinkForm::ErrorOr<POSLinkForm::FormInputTextResponse>)>>((*iResult));
                            POSLinkForm::ErrorOr<POSLinkForm::FormInputTextResponse> tmpReply(retRsp);
                            tmpFunction(tmpReply);
                        }
                    }
                }
                else if(*iFlag == "FormRemoveCardResponse")
                {
                    POSLinkForm::PluginRemoveCardResponse pluginRsp;
                    CComPtr<_RemoveCardResponse> comRsp = NULL;
                    bstrData[i]->QueryInterface(&comRsp);
                    if(pluginRsp.get(comRsp))
                    {
                        POSLinkForm::FormRemoveCardResponse retRsp = *pluginRsp.get(comRsp);
                        if ((*iResult).type() == typeid(std::function<void(POSLinkForm::ErrorOr<POSLinkForm::FormRemoveCardResponse>)>))
                        {
                            std::function<void(POSLinkForm::ErrorOr<POSLinkForm::FormRemoveCardResponse>)> tmpFunction = std::any_cast<std::function<void(POSLinkForm::ErrorOr<POSLinkForm::FormRemoveCardResponse>)>>((*iResult));
                            POSLinkForm::ErrorOr<POSLinkForm::FormRemoveCardResponse> tmpReply(retRsp);
                            tmpFunction(tmpReply);
                        }
                    }
                }
                else if(*iFlag == "FormShowDialogFormResponse")
                {
                    POSLinkForm::PluginShowDialogFormResponse pluginRsp;
                    CComPtr<_ShowDialogFormResponse> comRsp = NULL;
                    bstrData[i]->QueryInterface(&comRsp);
                    if(pluginRsp.get(comRsp))
                    {
                        POSLinkForm::FormShowDialogFormResponse retRsp = *pluginRsp.get(comRsp);
                        if ((*iResult).type() == typeid(std::function<void(POSLinkForm::ErrorOr<POSLinkForm::FormShowDialogFormResponse>)>))
                        {
                            std::function<void(POSLinkForm::ErrorOr<POSLinkForm::FormShowDialogFormResponse>)> tmpFunction = std::any_cast<std::function<void(POSLinkForm::ErrorOr<POSLinkForm::FormShowDialogFormResponse>)>>((*iResult));
                            POSLinkForm::ErrorOr<POSLinkForm::FormShowDialogFormResponse> tmpReply(retRsp);
                            tmpFunction(tmpReply);
                        }
                    }
                }
                else if(*iFlag == "FormShowDialogResponse")
                {
                    POSLinkForm::PluginShowDialogResponse pluginRsp;
                    CComPtr<_ShowDialogResponse> comRsp = NULL;
                    bstrData[i]->QueryInterface(&comRsp);
                    if(pluginRsp.get(comRsp))
                    {
                        POSLinkForm::FormShowDialogResponse retRsp = *pluginRsp.get(comRsp);
                        if ((*iResult).type() == typeid(std::function<void(POSLinkForm::ErrorOr<POSLinkForm::FormShowDialogResponse>)>))
                        {
                            std::function<void(POSLinkForm::ErrorOr<POSLinkForm::FormShowDialogResponse>)> tmpFunction = std::any_cast<std::function<void(POSLinkForm::ErrorOr<POSLinkForm::FormShowDialogResponse>)>>((*iResult));
                            POSLinkForm::ErrorOr<POSLinkForm::FormShowDialogResponse> tmpReply(retRsp);
                            tmpFunction(tmpReply);
                        }
                    }
                }
                else if(*iFlag == "FormShowItemResponse")
                {
                    POSLinkForm::PluginShowItemResponse pluginRsp;
                    CComPtr<_ShowItemResponse> comRsp = NULL;
                    bstrData[i]->QueryInterface(&comRsp);
                    if(pluginRsp.get(comRsp))
                    {
                        POSLinkForm::FormShowItemResponse retRsp = *pluginRsp.get(comRsp);
                        if ((*iResult).type() == typeid(std::function<void(POSLinkForm::ErrorOr<POSLinkForm::FormShowItemResponse>)>))
                        {
                            std::function<void(POSLinkForm::ErrorOr<POSLinkForm::FormShowItemResponse>)> tmpFunction = std::any_cast<std::function<void(POSLinkForm::ErrorOr<POSLinkForm::FormShowItemResponse>)>>((*iResult));
                            POSLinkForm::ErrorOr<POSLinkForm::FormShowItemResponse> tmpReply(retRsp);
                            tmpFunction(tmpReply);
                        }
                    }
                }
                else if(*iFlag == "FormShowMessageCenterResponse")
                {
                    POSLinkForm::PluginShowMessageCenterResponse pluginRsp;
                    CComPtr<_ShowMessageCenterResponse> comRsp = NULL;
                    bstrData[i]->QueryInterface(&comRsp);
                    if(pluginRsp.get(comRsp))
                    {
                        POSLinkForm::FormShowMessageCenterResponse retRsp = *pluginRsp.get(comRsp);
                        if ((*iResult).type() == typeid(std::function<void(POSLinkForm::ErrorOr<POSLinkForm::FormShowMessageCenterResponse>)>))
                        {
                            std::function<void(POSLinkForm::ErrorOr<POSLinkForm::FormShowMessageCenterResponse>)> tmpFunction = std::any_cast<std::function<void(POSLinkForm::ErrorOr<POSLinkForm::FormShowMessageCenterResponse>)>>((*iResult));
                            POSLinkForm::ErrorOr<POSLinkForm::FormShowMessageCenterResponse> tmpReply(retRsp);
                            tmpFunction(tmpReply);
                        }
                    }
                }
                else if(*iFlag == "FormShowMessageResponse")
                {
                    POSLinkForm::PluginShowMessageResponse pluginRsp;
                    CComPtr<_ShowMessageResponse> comRsp = NULL;
                    bstrData[i]->QueryInterface(&comRsp);
                    if(pluginRsp.get(comRsp))
                    {
                        POSLinkForm::FormShowMessageResponse retRsp = *pluginRsp.get(comRsp);
                        if ((*iResult).type() == typeid(std::function<void(POSLinkForm::ErrorOr<POSLinkForm::FormShowMessageResponse>)>))
                        {
                            std::function<void(POSLinkForm::ErrorOr<POSLinkForm::FormShowMessageResponse>)> tmpFunction = std::any_cast<std::function<void(POSLinkForm::ErrorOr<POSLinkForm::FormShowMessageResponse>)>>((*iResult));
                            POSLinkForm::ErrorOr<POSLinkForm::FormShowMessageResponse> tmpReply(retRsp);
                            tmpFunction(tmpReply);
                        }
                    }
                }
                else if(*iFlag == "FormShowTextBoxResponse")
                {
                    POSLinkForm::PluginShowTextBoxResponse pluginRsp;
                    CComPtr<_ShowTextBoxResponse> comRsp = NULL;
                    bstrData[i]->QueryInterface(&comRsp);
                    if(pluginRsp.get(comRsp))
                    {
                        POSLinkForm::FormShowTextBoxResponse retRsp = *pluginRsp.get(comRsp);
                        if ((*iResult).type() == typeid(std::function<void(POSLinkForm::ErrorOr<POSLinkForm::FormShowTextBoxResponse>)>))
                        {
                            std::function<void(POSLinkForm::ErrorOr<POSLinkForm::FormShowTextBoxResponse>)> tmpFunction = std::any_cast<std::function<void(POSLinkForm::ErrorOr<POSLinkForm::FormShowTextBoxResponse>)>>((*iResult));
                            POSLinkForm::ErrorOr<POSLinkForm::FormShowTextBoxResponse> tmpReply(retRsp);
                            tmpFunction(tmpReply);
                        }
                    }
                }
                if(*iFlag == "ManageCheckFileResponse")
                {
                    POSLinkManage::PluginCheckFileResponse pluginRsp;
                    CComPtr<_CheckFileResponse> comRsp = NULL;
                    bstrData[i]->QueryInterface(&comRsp);
                    if(pluginRsp.get(comRsp))
                    {
                        POSLinkManage::ManageCheckFileResponse retRsp = *pluginRsp.get(comRsp);
                        if ((*iResult).type() == typeid(std::function<void(POSLinkManage::ErrorOr<POSLinkManage::ManageCheckFileResponse>)>))
                        {
                            std::function<void(POSLinkManage::ErrorOr<POSLinkManage::ManageCheckFileResponse>)> tmpFunction = std::any_cast<std::function<void(POSLinkManage::ErrorOr<POSLinkManage::ManageCheckFileResponse>)>>((*iResult));
                            POSLinkManage::ErrorOr<POSLinkManage::ManageCheckFileResponse> tmpReply(retRsp);
                            tmpFunction(tmpReply);
                        }
                    }
                }
                else if(*iFlag == "ManageClearCardBufferResponse")
                {
                    POSLinkManage::PluginClearCardBufferResponse pluginRsp;
                    CComPtr<_ClearCardBufferResponse> comRsp = NULL;
                    bstrData[i]->QueryInterface(&comRsp);
                    if(pluginRsp.get(comRsp))
                    {
                        POSLinkManage::ManageClearCardBufferResponse retRsp = *pluginRsp.get(comRsp);
                        if ((*iResult).type() == typeid(std::function<void(POSLinkManage::ErrorOr<POSLinkManage::ManageClearCardBufferResponse>)>))
                        {
                            std::function<void(POSLinkManage::ErrorOr<POSLinkManage::ManageClearCardBufferResponse>)> tmpFunction = std::any_cast<std::function<void(POSLinkManage::ErrorOr<POSLinkManage::ManageClearCardBufferResponse>)>>((*iResult));
                            POSLinkManage::ErrorOr<POSLinkManage::ManageClearCardBufferResponse> tmpReply(retRsp);
                            tmpFunction(tmpReply);
                        }
                    }
                }
                else if(*iFlag == "ManageDeleteImageResponse")
                {
                    POSLinkManage::PluginDeleteImageResponse pluginRsp;
                    CComPtr<_DeleteImageResponse> comRsp = NULL;
                    bstrData[i]->QueryInterface(&comRsp);
                    if(pluginRsp.get(comRsp))
                    {
                        POSLinkManage::ManageDeleteImageResponse retRsp = *pluginRsp.get(comRsp);
                        if ((*iResult).type() == typeid(std::function<void(POSLinkManage::ErrorOr<POSLinkManage::ManageDeleteImageResponse>)>))
                        {
                            std::function<void(POSLinkManage::ErrorOr<POSLinkManage::ManageDeleteImageResponse>)> tmpFunction = std::any_cast<std::function<void(POSLinkManage::ErrorOr<POSLinkManage::ManageDeleteImageResponse>)>>((*iResult));
                            POSLinkManage::ErrorOr<POSLinkManage::ManageDeleteImageResponse> tmpReply(retRsp);
                            tmpFunction(tmpReply);
                        }
                    }
                }
                else if(*iFlag == "ManageDoSignatureResponse")
                {
                    POSLinkManage::PluginDoSignatureResponse pluginRsp;
                    CComPtr<_DoSignatureResponse> comRsp = NULL;
                    bstrData[i]->QueryInterface(&comRsp);
                    if(pluginRsp.get(comRsp))
                    {
                        POSLinkManage::ManageDoSignatureResponse retRsp = *pluginRsp.get(comRsp);
                        if ((*iResult).type() == typeid(std::function<void(POSLinkManage::ErrorOr<POSLinkManage::ManageDoSignatureResponse>)>))
                        {
                            std::function<void(POSLinkManage::ErrorOr<POSLinkManage::ManageDoSignatureResponse>)> tmpFunction = std::any_cast<std::function<void(POSLinkManage::ErrorOr<POSLinkManage::ManageDoSignatureResponse>)>>((*iResult));
                            POSLinkManage::ErrorOr<POSLinkManage::ManageDoSignatureResponse> tmpReply(retRsp);
                            tmpFunction(tmpReply);
                        }
                    }
                }
                else if(*iFlag == "ManageGetSignatureResponse")
                {
                    POSLinkManage::PluginGetSignatureResponse pluginRsp;
                    CComPtr<_GetSignatureResponse> comRsp = NULL;
                    bstrData[i]->QueryInterface(&comRsp);
                    if(pluginRsp.get(comRsp))
                    {
                        POSLinkManage::ManageGetSignatureResponse retRsp = *pluginRsp.get(comRsp);
                        if ((*iResult).type() == typeid(std::function<void(POSLinkManage::ErrorOr<POSLinkManage::ManageGetSignatureResponse>)>))
                        {
                            std::function<void(POSLinkManage::ErrorOr<POSLinkManage::ManageGetSignatureResponse>)> tmpFunction = std::any_cast<std::function<void(POSLinkManage::ErrorOr<POSLinkManage::ManageGetSignatureResponse>)>>((*iResult));
                            POSLinkManage::ErrorOr<POSLinkManage::ManageGetSignatureResponse> tmpReply(retRsp);
                            tmpFunction(tmpReply);
                        }
                    }
                }
                else if(*iFlag == "ManageGetVariableResponse")
                {
                    POSLinkManage::PluginGetVariableResponse pluginRsp;
                    CComPtr<_GetVariableResponse> comRsp = NULL;
                    bstrData[i]->QueryInterface(&comRsp);
                    if(pluginRsp.get(comRsp))
                    {
                        POSLinkManage::ManageGetVariableResponse retRsp = *pluginRsp.get(comRsp);
                        if ((*iResult).type() == typeid(std::function<void(POSLinkManage::ErrorOr<POSLinkManage::ManageGetVariableResponse>)>))
                        {
                            std::function<void(POSLinkManage::ErrorOr<POSLinkManage::ManageGetVariableResponse>)> tmpFunction = std::any_cast<std::function<void(POSLinkManage::ErrorOr<POSLinkManage::ManageGetVariableResponse>)>>((*iResult));
                            POSLinkManage::ErrorOr<POSLinkManage::ManageGetVariableResponse> tmpReply(retRsp);
                            tmpFunction(tmpReply);
                        }
                    }
                }
                else if(*iFlag == "ManageInitResponse")
                {
                    POSLinkManage::PluginInitResponse pluginRsp;
                    CComPtr<_InitResponse> comRsp = NULL;
                    bstrData[i]->QueryInterface(&comRsp);
                    if(pluginRsp.get(comRsp))
                    {
                        POSLinkManage::ManageInitResponse retRsp = *pluginRsp.get(comRsp);
                        if ((*iResult).type() == typeid(std::function<void(POSLinkManage::ErrorOr<POSLinkManage::ManageInitResponse>)>))
                        {
                            std::function<void(POSLinkManage::ErrorOr<POSLinkManage::ManageInitResponse>)> tmpFunction = std::any_cast<std::function<void(POSLinkManage::ErrorOr<POSLinkManage::ManageInitResponse>)>>((*iResult));
                            POSLinkManage::ErrorOr<POSLinkManage::ManageInitResponse> tmpReply(retRsp);
                            tmpFunction(tmpReply);
                        }
                    }
                }
                else if(*iFlag == "ManageRebootResponse")
                {
                    POSLinkManage::PluginRebootResponse pluginRsp;
                    CComPtr<_RebootResponse> comRsp = NULL;
                    bstrData[i]->QueryInterface(&comRsp);
                    if(pluginRsp.get(comRsp))
                    {
                        POSLinkManage::ManageRebootResponse retRsp = *pluginRsp.get(comRsp);
                        if ((*iResult).type() == typeid(std::function<void(POSLinkManage::ErrorOr<POSLinkManage::ManageRebootResponse>)>))
                        {
                            std::function<void(POSLinkManage::ErrorOr<POSLinkManage::ManageRebootResponse>)> tmpFunction = std::any_cast<std::function<void(POSLinkManage::ErrorOr<POSLinkManage::ManageRebootResponse>)>>((*iResult));
                            POSLinkManage::ErrorOr<POSLinkManage::ManageRebootResponse> tmpReply(retRsp);
                            tmpFunction(tmpReply);
                        }
                    }
                }
                else if(*iFlag == "ManageResetScreenResponse")
                {
                    POSLinkManage::PluginResetScreenResponse pluginRsp;
                    CComPtr<_ResetScreenResponse> comRsp = NULL;
                    bstrData[i]->QueryInterface(&comRsp);
                    if(pluginRsp.get(comRsp))
                    {
                        POSLinkManage::ManageResetScreenResponse retRsp = *pluginRsp.get(comRsp);
                        if ((*iResult).type() == typeid(std::function<void(POSLinkManage::ErrorOr<POSLinkManage::ManageResetScreenResponse>)>))
                        {
                            std::function<void(POSLinkManage::ErrorOr<POSLinkManage::ManageResetScreenResponse>)> tmpFunction = std::any_cast<std::function<void(POSLinkManage::ErrorOr<POSLinkManage::ManageResetScreenResponse>)>>((*iResult));
                            POSLinkManage::ErrorOr<POSLinkManage::ManageResetScreenResponse> tmpReply(retRsp);
                            tmpFunction(tmpReply);
                        }
                    }
                }
                else if(*iFlag == "ManageSetApplePayVasParametersResponse")
                {
                    POSLinkManage::PluginSetApplePayVasParametersResponse pluginRsp;
                    CComPtr<_SetApplePayVasParametersResponse> comRsp = NULL;
                    bstrData[i]->QueryInterface(&comRsp);
                    if(pluginRsp.get(comRsp))
                    {
                        POSLinkManage::ManageSetApplePayVasParametersResponse retRsp = *pluginRsp.get(comRsp);
                        if ((*iResult).type() == typeid(std::function<void(POSLinkManage::ErrorOr<POSLinkManage::ManageSetApplePayVasParametersResponse>)>))
                        {
                            std::function<void(POSLinkManage::ErrorOr<POSLinkManage::ManageSetApplePayVasParametersResponse>)> tmpFunction = std::any_cast<std::function<void(POSLinkManage::ErrorOr<POSLinkManage::ManageSetApplePayVasParametersResponse>)>>((*iResult));
                            POSLinkManage::ErrorOr<POSLinkManage::ManageSetApplePayVasParametersResponse> tmpReply(retRsp);
                            tmpFunction(tmpReply);
                        }
                    }
                }
                else if(*iFlag == "ManageSetGoogleSmartTapParametersResponse")
                {
                    POSLinkManage::PluginSetGoogleSmartTapParametersResponse pluginRsp;
                    CComPtr<_SetGoogleSmartTapParametersResponse> comRsp = NULL;
                    bstrData[i]->QueryInterface(&comRsp);
                    if(pluginRsp.get(comRsp))
                    {
                        POSLinkManage::ManageSetGoogleSmartTapParametersResponse retRsp = *pluginRsp.get(comRsp);
                        if ((*iResult).type() == typeid(std::function<void(POSLinkManage::ErrorOr<POSLinkManage::ManageSetGoogleSmartTapParametersResponse>)>))
                        {
                            std::function<void(POSLinkManage::ErrorOr<POSLinkManage::ManageSetGoogleSmartTapParametersResponse>)> tmpFunction = std::any_cast<std::function<void(POSLinkManage::ErrorOr<POSLinkManage::ManageSetGoogleSmartTapParametersResponse>)>>((*iResult));
                            POSLinkManage::ErrorOr<POSLinkManage::ManageSetGoogleSmartTapParametersResponse> tmpReply(retRsp);
                            tmpFunction(tmpReply);
                        }
                    }
                }
                else if(*iFlag == "ManageSetVariableResponse")
                {
                    POSLinkManage::PluginSetVariableResponse pluginRsp;
                    CComPtr<_SetVariableResponse> comRsp = NULL;
                    bstrData[i]->QueryInterface(&comRsp);
                    if(pluginRsp.get(comRsp))
                    {
                        POSLinkManage::ManageSetVariableResponse retRsp = *pluginRsp.get(comRsp);
                        if ((*iResult).type() == typeid(std::function<void(POSLinkManage::ErrorOr<POSLinkManage::ManageSetVariableResponse>)>))
                        {
                            std::function<void(POSLinkManage::ErrorOr<POSLinkManage::ManageSetVariableResponse>)> tmpFunction = std::any_cast<std::function<void(POSLinkManage::ErrorOr<POSLinkManage::ManageSetVariableResponse>)>>((*iResult));
                            POSLinkManage::ErrorOr<POSLinkManage::ManageSetVariableResponse> tmpReply(retRsp);
                            tmpFunction(tmpReply);
                        }
                    }
                }
                else if(*iFlag == "ManageUpdateResourceFileResponse")
                {
                    POSLinkManage::PluginUpdateResourceFileResponse pluginRsp;
                    CComPtr<_UpdateResourceFileResponse> comRsp = NULL;
                    bstrData[i]->QueryInterface(&comRsp);
                    if(pluginRsp.get(comRsp))
                    {
                        POSLinkManage::ManageUpdateResourceFileResponse retRsp = *pluginRsp.get(comRsp);
                        if ((*iResult).type() == typeid(std::function<void(POSLinkManage::ErrorOr<POSLinkManage::ManageUpdateResourceFileResponse>)>))
                        {
                            std::function<void(POSLinkManage::ErrorOr<POSLinkManage::ManageUpdateResourceFileResponse>)> tmpFunction = std::any_cast<std::function<void(POSLinkManage::ErrorOr<POSLinkManage::ManageUpdateResourceFileResponse>)>>((*iResult));
                            POSLinkManage::ErrorOr<POSLinkManage::ManageUpdateResourceFileResponse> tmpReply(retRsp);
                            tmpFunction(tmpReply);
                        }
                    }
                }
                else if(*iFlag == "ManageVasPushDataResponse")
                {
                    POSLinkManage::PluginVasPushDataResponse pluginRsp;
                    CComPtr<_VasPushDataResponse> comRsp = NULL;
                    bstrData[i]->QueryInterface(&comRsp);
                    if(pluginRsp.get(comRsp))
                    {
                        POSLinkManage::ManageVasPushDataResponse retRsp = *pluginRsp.get(comRsp);
                        if ((*iResult).type() == typeid(std::function<void(POSLinkManage::ErrorOr<POSLinkManage::ManageVasPushDataResponse>)>))
                        {
                            std::function<void(POSLinkManage::ErrorOr<POSLinkManage::ManageVasPushDataResponse>)> tmpFunction = std::any_cast<std::function<void(POSLinkManage::ErrorOr<POSLinkManage::ManageVasPushDataResponse>)>>((*iResult));
                            POSLinkManage::ErrorOr<POSLinkManage::ManageVasPushDataResponse> tmpReply(retRsp);
                            tmpFunction(tmpReply);
                        }
                    }
                }
                if(*iFlag == "PayloadPayloadResponse")
                {
                    POSLinkPayload::PluginPayloadResponse pluginRsp;
                    CComPtr<_PayloadResponse> comRsp = NULL;
                    bstrData[i]->QueryInterface(&comRsp);
                    if(pluginRsp.get(comRsp))
                    {
                        POSLinkPayload::PayloadPayloadResponse retRsp = *pluginRsp.get(comRsp);
                        if ((*iResult).type() == typeid(std::function<void(POSLinkPayload::ErrorOr<POSLinkPayload::PayloadPayloadResponse>)>))
                        {
                            std::function<void(POSLinkPayload::ErrorOr<POSLinkPayload::PayloadPayloadResponse>)> tmpFunction = std::any_cast<std::function<void(POSLinkPayload::ErrorOr<POSLinkPayload::PayloadPayloadResponse>)>>((*iResult));
                            POSLinkPayload::ErrorOr<POSLinkPayload::PayloadPayloadResponse> tmpReply(retRsp);
                            tmpFunction(tmpReply);
                        }
                    }
                }
                if(*iFlag == "PedGetPedInformationResponse")
                {
                    POSLinkPed::PluginGetPedInformationResponse pluginRsp;
                    CComPtr<_GetPedInformationResponse> comRsp = NULL;
                    bstrData[i]->QueryInterface(&comRsp);
                    if(pluginRsp.get(comRsp))
                    {
                        POSLinkPed::PedGetPedInformationResponse retRsp = *pluginRsp.get(comRsp);
                        if ((*iResult).type() == typeid(std::function<void(POSLinkPed::ErrorOr<POSLinkPed::PedGetPedInformationResponse>)>))
                        {
                            std::function<void(POSLinkPed::ErrorOr<POSLinkPed::PedGetPedInformationResponse>)> tmpFunction = std::any_cast<std::function<void(POSLinkPed::ErrorOr<POSLinkPed::PedGetPedInformationResponse>)>>((*iResult));
                            POSLinkPed::ErrorOr<POSLinkPed::PedGetPedInformationResponse> tmpReply(retRsp);
                            tmpFunction(tmpReply);
                        }
                    }
                }
                else if(*iFlag == "PedIncreaseKsnResponse")
                {
                    POSLinkPed::PluginIncreaseKsnResponse pluginRsp;
                    CComPtr<_IncreaseKsnResponse> comRsp = NULL;
                    bstrData[i]->QueryInterface(&comRsp);
                    if(pluginRsp.get(comRsp))
                    {
                        POSLinkPed::PedIncreaseKsnResponse retRsp = *pluginRsp.get(comRsp);
                        if ((*iResult).type() == typeid(std::function<void(POSLinkPed::ErrorOr<POSLinkPed::PedIncreaseKsnResponse>)>))
                        {
                            std::function<void(POSLinkPed::ErrorOr<POSLinkPed::PedIncreaseKsnResponse>)> tmpFunction = std::any_cast<std::function<void(POSLinkPed::ErrorOr<POSLinkPed::PedIncreaseKsnResponse>)>>((*iResult));
                            POSLinkPed::ErrorOr<POSLinkPed::PedIncreaseKsnResponse> tmpReply(retRsp);
                            tmpFunction(tmpReply);
                        }
                    }
                }
                else if(*iFlag == "PedMacCalculationResponse")
                {
                    POSLinkPed::PluginMacCalculationResponse pluginRsp;
                    CComPtr<_MacCalculationResponse> comRsp = NULL;
                    bstrData[i]->QueryInterface(&comRsp);
                    if(pluginRsp.get(comRsp))
                    {
                        POSLinkPed::PedMacCalculationResponse retRsp = *pluginRsp.get(comRsp);
                        if ((*iResult).type() == typeid(std::function<void(POSLinkPed::ErrorOr<POSLinkPed::PedMacCalculationResponse>)>))
                        {
                            std::function<void(POSLinkPed::ErrorOr<POSLinkPed::PedMacCalculationResponse>)> tmpFunction = std::any_cast<std::function<void(POSLinkPed::ErrorOr<POSLinkPed::PedMacCalculationResponse>)>>((*iResult));
                            POSLinkPed::ErrorOr<POSLinkPed::PedMacCalculationResponse> tmpReply(retRsp);
                            tmpFunction(tmpReply);
                        }
                    }
                }
                else if(*iFlag == "PedSessionKeyInjectionResponse")
                {
                    POSLinkPed::PluginSessionKeyInjectionResponse pluginRsp;
                    CComPtr<_SessionKeyInjectionResponse> comRsp = NULL;
                    bstrData[i]->QueryInterface(&comRsp);
                    if(pluginRsp.get(comRsp))
                    {
                        POSLinkPed::PedSessionKeyInjectionResponse retRsp = *pluginRsp.get(comRsp);
                        if ((*iResult).type() == typeid(std::function<void(POSLinkPed::ErrorOr<POSLinkPed::PedSessionKeyInjectionResponse>)>))
                        {
                            std::function<void(POSLinkPed::ErrorOr<POSLinkPed::PedSessionKeyInjectionResponse>)> tmpFunction = std::any_cast<std::function<void(POSLinkPed::ErrorOr<POSLinkPed::PedSessionKeyInjectionResponse>)>>((*iResult));
                            POSLinkPed::ErrorOr<POSLinkPed::PedSessionKeyInjectionResponse> tmpReply(retRsp);
                            tmpFunction(tmpReply);
                        }
                    }
                }
                if(*iFlag == "FullIntegrationAuthorizeCardResponse")
                {
                    POSLinkFullIntegration::PluginAuthorizeCardResponse pluginRsp;
                    CComPtr<_AuthorizeCardResponse> comRsp = NULL;
                    bstrData[i]->QueryInterface(&comRsp);
                    if(pluginRsp.get(comRsp))
                    {
                        POSLinkFullIntegration::FullIntegrationAuthorizeCardResponse retRsp = *pluginRsp.get(comRsp);
                        if ((*iResult).type() == typeid(std::function<void(POSLinkFullIntegration::ErrorOr<POSLinkFullIntegration::FullIntegrationAuthorizeCardResponse>)>))
                        {
                            std::function<void(POSLinkFullIntegration::ErrorOr<POSLinkFullIntegration::FullIntegrationAuthorizeCardResponse>)> tmpFunction = std::any_cast<std::function<void(POSLinkFullIntegration::ErrorOr<POSLinkFullIntegration::FullIntegrationAuthorizeCardResponse>)>>((*iResult));
                            POSLinkFullIntegration::ErrorOr<POSLinkFullIntegration::FullIntegrationAuthorizeCardResponse> tmpReply(retRsp);
                            tmpFunction(tmpReply);
                        }
                    }
                }
                else if(*iFlag == "FullIntegrationCompleteOnlineEmvResponse")
                {
                    POSLinkFullIntegration::PluginCompleteOnlineEmvResponse pluginRsp;
                    CComPtr<_CompleteOnlineEmvResponse> comRsp = NULL;
                    bstrData[i]->QueryInterface(&comRsp);
                    if(pluginRsp.get(comRsp))
                    {
                        POSLinkFullIntegration::FullIntegrationCompleteOnlineEmvResponse retRsp = *pluginRsp.get(comRsp);
                        if ((*iResult).type() == typeid(std::function<void(POSLinkFullIntegration::ErrorOr<POSLinkFullIntegration::FullIntegrationCompleteOnlineEmvResponse>)>))
                        {
                            std::function<void(POSLinkFullIntegration::ErrorOr<POSLinkFullIntegration::FullIntegrationCompleteOnlineEmvResponse>)> tmpFunction = std::any_cast<std::function<void(POSLinkFullIntegration::ErrorOr<POSLinkFullIntegration::FullIntegrationCompleteOnlineEmvResponse>)>>((*iResult));
                            POSLinkFullIntegration::ErrorOr<POSLinkFullIntegration::FullIntegrationCompleteOnlineEmvResponse> tmpReply(retRsp);
                            tmpFunction(tmpReply);
                        }
                    }
                }
                else if(*iFlag == "FullIntegrationGetEmvTlvDataResponse")
                {
                    POSLinkFullIntegration::PluginGetEmvTlvDataResponse pluginRsp;
                    CComPtr<_GetEmvTlvDataResponse> comRsp = NULL;
                    bstrData[i]->QueryInterface(&comRsp);
                    if(pluginRsp.get(comRsp))
                    {
                        POSLinkFullIntegration::FullIntegrationGetEmvTlvDataResponse retRsp = *pluginRsp.get(comRsp);
                        if ((*iResult).type() == typeid(std::function<void(POSLinkFullIntegration::ErrorOr<POSLinkFullIntegration::FullIntegrationGetEmvTlvDataResponse>)>))
                        {
                            std::function<void(POSLinkFullIntegration::ErrorOr<POSLinkFullIntegration::FullIntegrationGetEmvTlvDataResponse>)> tmpFunction = std::any_cast<std::function<void(POSLinkFullIntegration::ErrorOr<POSLinkFullIntegration::FullIntegrationGetEmvTlvDataResponse>)>>((*iResult));
                            POSLinkFullIntegration::ErrorOr<POSLinkFullIntegration::FullIntegrationGetEmvTlvDataResponse> tmpReply(retRsp);
                            tmpFunction(tmpReply);
                        }
                    }
                }
                else if(*iFlag == "FullIntegrationGetPinBlockResponse")
                {
                    POSLinkFullIntegration::PluginGetPinBlockResponse pluginRsp;
                    CComPtr<_GetPinBlockResponse> comRsp = NULL;
                    bstrData[i]->QueryInterface(&comRsp);
                    if(pluginRsp.get(comRsp))
                    {
                        POSLinkFullIntegration::FullIntegrationGetPinBlockResponse retRsp = *pluginRsp.get(comRsp);
                        if ((*iResult).type() == typeid(std::function<void(POSLinkFullIntegration::ErrorOr<POSLinkFullIntegration::FullIntegrationGetPinBlockResponse>)>))
                        {
                            std::function<void(POSLinkFullIntegration::ErrorOr<POSLinkFullIntegration::FullIntegrationGetPinBlockResponse>)> tmpFunction = std::any_cast<std::function<void(POSLinkFullIntegration::ErrorOr<POSLinkFullIntegration::FullIntegrationGetPinBlockResponse>)>>((*iResult));
                            POSLinkFullIntegration::ErrorOr<POSLinkFullIntegration::FullIntegrationGetPinBlockResponse> tmpReply(retRsp);
                            tmpFunction(tmpReply);
                        }
                    }
                }
                else if(*iFlag == "FullIntegrationInputAccountWithEmvResponse")
                {
                    POSLinkFullIntegration::PluginInputAccountWithEmvResponse pluginRsp;
                    CComPtr<_InputAccountWithEmvResponse> comRsp = NULL;
                    bstrData[i]->QueryInterface(&comRsp);
                    if(pluginRsp.get(comRsp))
                    {
                        POSLinkFullIntegration::FullIntegrationInputAccountWithEmvResponse retRsp = *pluginRsp.get(comRsp);
                        if ((*iResult).type() == typeid(std::function<void(POSLinkFullIntegration::ErrorOr<POSLinkFullIntegration::FullIntegrationInputAccountWithEmvResponse>)>))
                        {
                            std::function<void(POSLinkFullIntegration::ErrorOr<POSLinkFullIntegration::FullIntegrationInputAccountWithEmvResponse>)> tmpFunction = std::any_cast<std::function<void(POSLinkFullIntegration::ErrorOr<POSLinkFullIntegration::FullIntegrationInputAccountWithEmvResponse>)>>((*iResult));
                            POSLinkFullIntegration::ErrorOr<POSLinkFullIntegration::FullIntegrationInputAccountWithEmvResponse> tmpReply(retRsp);
                            tmpFunction(tmpReply);
                        }
                    }
                }
                else if(*iFlag == "FullIntegrationSetEmvTlvDataResponse")
                {
                    POSLinkFullIntegration::PluginSetEmvTlvDataResponse pluginRsp;
                    CComPtr<_SetEmvTlvDataResponse> comRsp = NULL;
                    bstrData[i]->QueryInterface(&comRsp);
                    if(pluginRsp.get(comRsp))
                    {
                        POSLinkFullIntegration::FullIntegrationSetEmvTlvDataResponse retRsp = *pluginRsp.get(comRsp);
                        if ((*iResult).type() == typeid(std::function<void(POSLinkFullIntegration::ErrorOr<POSLinkFullIntegration::FullIntegrationSetEmvTlvDataResponse>)>))
                        {
                            std::function<void(POSLinkFullIntegration::ErrorOr<POSLinkFullIntegration::FullIntegrationSetEmvTlvDataResponse>)> tmpFunction = std::any_cast<std::function<void(POSLinkFullIntegration::ErrorOr<POSLinkFullIntegration::FullIntegrationSetEmvTlvDataResponse>)>>((*iResult));
                            POSLinkFullIntegration::ErrorOr<POSLinkFullIntegration::FullIntegrationSetEmvTlvDataResponse> tmpReply(retRsp);
                            tmpFunction(tmpReply);
                        }
                    }
                }
                iResult++;
                iFlag++;
            }
            
            Response rsp;
            BSTR bstrResponseCode;
            comMultiCommandRsp->get_ResponseCode(&bstrResponseCode);
            rsp.set_response_code(Tool::Tools::ParseBSTRToString(bstrResponseCode));
            BSTR bstrResponseMessage;
            comMultiCommandRsp->get_ResponseMessage(&bstrResponseMessage);
            rsp.set_response_message(Tool::Tools::ParseBSTRToString(bstrResponseMessage));
            ErrorOr<Response> reply(rsp);
            result(reply);
        }
    }
}

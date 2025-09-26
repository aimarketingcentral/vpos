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
#include "PluginInputAccountWithEmvRequest.h"

namespace POSLinkFullIntegration{
    PluginInputAccountWithEmvRequest::PluginInputAccountWithEmvRequest(){}

    _InputAccountWithEmvRequest* PluginInputAccountWithEmvRequest::set(const std::optional<FullIntegrationInputAccountWithEmvRequest>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidInputAccountWithEmvRequest;
        CLSIDFromProgID(OLESTR("POSLinkFullIntegration.FullIntegration.InputAccountWithEmvRequest"),&clsidInputAccountWithEmvRequest);
        request = NULL;
        request.CoCreateInstance(clsidInputAccountWithEmvRequest);

        request->put_EdcType((EdcType)*req->edc_type());

        request->put_TransactionType((TransactionType)*req->transaction_type());

        PluginAmountRequest amountInformation;
        request->putref_AmountInformation(amountInformation.set(req->amount_information() ? std::optional<const FullIntegrationAmountRequest>(*req->amount_information()) : std::nullopt));

        request->put_MagneticSwipePinpadEnableFlag((PinpadEnableFlag)*req->magnetic_swipe_pinpad_enable_flag());

        request->put_MagneticSwipePinpadTypeFlag((PinpadTypeFlag)*req->magnetic_swipe_pinpad_type_flag());

        request->put_ManualPinpadEnableFlag((PinpadEnableFlag)*req->manual_pinpad_enable_flag());

        request->put_ContactlessPinpadEnableFlag((PinpadEnableFlag)*req->contactless_pinpad_enable_flag());

        request->put_ContactlessPinpadTypeFlag((PinpadTypeFlag)*req->contactless_pinpad_type_flag());

        request->put_ContactEmvPinpadEnableFlag((PinpadEnableFlag)*req->contact_emv_pinpad_enable_flag());

        request->put_ContactEmvPinpadTypeFlag((PinpadTypeFlag)*req->contact_emv_pinpad_type_flag());

        request->put_FallbackSwipePinpadEnableFlag((PinpadEnableFlag)*req->fallback_swipe_pinpad_enable_flag());

        request->put_LaserScannerFlag((LaserScannerFlag)*req->laser_scanner_flag());

        request->put_FrontCameraFlag((FrontCameraFlag)*req->front_camera_flag());

        request->put_RearCameraFlag((RearCameraFlag)*req->rear_camera_flag());

        PluginAdditionalPrompts additionalPrompts;
        request->putref_AdditionalPrompts(additionalPrompts.set(req->additional_prompts() ? std::optional<const FullIntegrationAdditionalPrompts>(*req->additional_prompts()) : std::nullopt));

        request->put_EncryptionFlag((DataEncryptionFlag)*req->encryption_flag());

        request->put_KeySlot(req->key_slot()?Tool::Tools::ParseStringToBSTR(*req->key_slot()):SysAllocString(L""));

        request->put_PaddingChar(req->padding_char()?Tool::Tools::ParseStringToBSTR(*req->padding_char()):SysAllocString(L""));

        request->put_TrackDataSentinel((TrackDataSentinel)*req->track_data_sentinel());

        request->put_MinAccountLength(req->min_account_length()?Tool::Tools::ParseStringToBSTR(*req->min_account_length()):SysAllocString(L""));

        request->put_MaxAccountLength(req->max_account_length()?Tool::Tools::ParseStringToBSTR(*req->max_account_length()):SysAllocString(L""));

        PluginTerminalConfiguration terminalConfiguration;
        request->putref_TerminalConfiguration(terminalConfiguration.set(req->terminal_configuration() ? std::optional<const FullIntegrationTerminalConfiguration>(*req->terminal_configuration()) : std::nullopt));

        request->put_TagList(req->tag_list()?Tool::Tools::ParseStringToBSTR(*req->tag_list()):SysAllocString(L""));

        request->put_Timeout(req->timeout()?Tool::Tools::ParseStringToBSTR(*req->timeout()):SysAllocString(L""));

        request->put_StatusReportFlag((StatusReportFlag)*req->status_report_flag());

        request->put_ContinuousScreen((ContinuousScreen)*req->continuous_screen());

        request->put_FallbackInsertPinpadEnableFlag((PinpadEnableFlag)*req->fallback_insert_pinpad_enable_flag());

        request->put_KsnFlag((KsnFlag)*req->ksn_flag());

        if(req->custom_data())
        {
            flutter::EncodableList tmpEnList = *req->custom_data();
            SAFEARRAY *psa;
            SAFEARRAYBOUND rgsabound[1];
            rgsabound[0].cElements = (ULONG)(tmpEnList.size());
            rgsabound[0].lLbound = 0;
            psa = SafeArrayCreate(VT_BSTR, 1, rgsabound);
            long i=0;
            for(flutter::EncodableList::iterator i_data = tmpEnList.begin(); i_data != tmpEnList.end(); i_data++)
            {
                flutter::EncodableValue tmpEnValue = *i_data;
                std::string tmpCustomData = std::get<std::string>(tmpEnValue);
                BSTR comCustomData = Tool::Tools::ParseStringToBSTR(tmpCustomData);
                SafeArrayPutElement(psa, &i, comCustomData);
                i++;
            }
            request->put_CustomData(psa);
            SafeArrayUnaccessData(psa);
        }

        request->put_FallbackToManualPinpadEnableFlag((PinpadEnableFlag)*req->fallback_to_manual_pinpad_enable_flag());

        PluginCustomMacInformationRequest customMacInformation;
        request->putref_CustomMacInformation(customMacInformation.set(req->custom_mac_information() ? std::optional<const FullIntegrationCustomMacInformationRequest>(*req->custom_mac_information()) : std::nullopt));

        return request;
    }

    const FullIntegrationInputAccountWithEmvRequest* PluginInputAccountWithEmvRequest::get(_InputAccountWithEmvRequest* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = FullIntegrationInputAccountWithEmvRequest();

        EdcType edcType;
        rsp->get_EdcType(&edcType);
        response->set_edc_type((FullIntegrationEdcType)edcType);

        TransactionType transactionType;
        rsp->get_TransactionType(&transactionType);
        response->set_transaction_type((FullIntegrationTransactionType)transactionType);

        CComPtr<_AmountRequest> comAmountInformation = NULL;
        rsp->get_AmountInformation(&comAmountInformation);
        PluginAmountRequest amountInformation;
        response->set_amount_information(amountInformation.get(comAmountInformation)? amountInformation.get(comAmountInformation): nullptr);

        PinpadEnableFlag magneticSwipePinpadEnableFlag;
        rsp->get_MagneticSwipePinpadEnableFlag(&magneticSwipePinpadEnableFlag);
        response->set_magnetic_swipe_pinpad_enable_flag((FullIntegrationPinpadEnableFlag)magneticSwipePinpadEnableFlag);

        PinpadTypeFlag magneticSwipePinpadTypeFlag;
        rsp->get_MagneticSwipePinpadTypeFlag(&magneticSwipePinpadTypeFlag);
        response->set_magnetic_swipe_pinpad_type_flag((FullIntegrationPinpadTypeFlag)magneticSwipePinpadTypeFlag);

        PinpadEnableFlag manualPinpadEnableFlag;
        rsp->get_ManualPinpadEnableFlag(&manualPinpadEnableFlag);
        response->set_manual_pinpad_enable_flag((FullIntegrationPinpadEnableFlag)manualPinpadEnableFlag);

        PinpadEnableFlag contactlessPinpadEnableFlag;
        rsp->get_ContactlessPinpadEnableFlag(&contactlessPinpadEnableFlag);
        response->set_contactless_pinpad_enable_flag((FullIntegrationPinpadEnableFlag)contactlessPinpadEnableFlag);

        PinpadTypeFlag contactlessPinpadTypeFlag;
        rsp->get_ContactlessPinpadTypeFlag(&contactlessPinpadTypeFlag);
        response->set_contactless_pinpad_type_flag((FullIntegrationPinpadTypeFlag)contactlessPinpadTypeFlag);

        PinpadEnableFlag contactEmvPinpadEnableFlag;
        rsp->get_ContactEmvPinpadEnableFlag(&contactEmvPinpadEnableFlag);
        response->set_contact_emv_pinpad_enable_flag((FullIntegrationPinpadEnableFlag)contactEmvPinpadEnableFlag);

        PinpadTypeFlag contactEmvPinpadTypeFlag;
        rsp->get_ContactEmvPinpadTypeFlag(&contactEmvPinpadTypeFlag);
        response->set_contact_emv_pinpad_type_flag((FullIntegrationPinpadTypeFlag)contactEmvPinpadTypeFlag);

        PinpadEnableFlag fallbackSwipePinpadEnableFlag;
        rsp->get_FallbackSwipePinpadEnableFlag(&fallbackSwipePinpadEnableFlag);
        response->set_fallback_swipe_pinpad_enable_flag((FullIntegrationPinpadEnableFlag)fallbackSwipePinpadEnableFlag);

        LaserScannerFlag laserScannerFlag;
        rsp->get_LaserScannerFlag(&laserScannerFlag);
        response->set_laser_scanner_flag((FullIntegrationLaserScannerFlag)laserScannerFlag);

        FrontCameraFlag frontCameraFlag;
        rsp->get_FrontCameraFlag(&frontCameraFlag);
        response->set_front_camera_flag((FullIntegrationFrontCameraFlag)frontCameraFlag);

        RearCameraFlag rearCameraFlag;
        rsp->get_RearCameraFlag(&rearCameraFlag);
        response->set_rear_camera_flag((FullIntegrationRearCameraFlag)rearCameraFlag);

        CComPtr<_AdditionalPrompts> comAdditionalPrompts = NULL;
        rsp->get_AdditionalPrompts(&comAdditionalPrompts);
        PluginAdditionalPrompts additionalPrompts;
        response->set_additional_prompts(additionalPrompts.get(comAdditionalPrompts)? additionalPrompts.get(comAdditionalPrompts): nullptr);

        DataEncryptionFlag encryptionFlag;
        rsp->get_EncryptionFlag(&encryptionFlag);
        response->set_encryption_flag((FullIntegrationDataEncryptionFlag)encryptionFlag);

        BSTR keySlot;
        rsp->get_KeySlot(&keySlot);
        response->set_key_slot(Tool::Tools::ParseBSTRToString(keySlot));

        BSTR paddingChar;
        rsp->get_PaddingChar(&paddingChar);
        response->set_padding_char(Tool::Tools::ParseBSTRToString(paddingChar));

        TrackDataSentinel trackDataSentinel;
        rsp->get_TrackDataSentinel(&trackDataSentinel);
        response->set_track_data_sentinel((FullIntegrationTrackDataSentinel)trackDataSentinel);

        BSTR minAccountLength;
        rsp->get_MinAccountLength(&minAccountLength);
        response->set_min_account_length(Tool::Tools::ParseBSTRToString(minAccountLength));

        BSTR maxAccountLength;
        rsp->get_MaxAccountLength(&maxAccountLength);
        response->set_max_account_length(Tool::Tools::ParseBSTRToString(maxAccountLength));

        CComPtr<_TerminalConfiguration> comTerminalConfiguration = NULL;
        rsp->get_TerminalConfiguration(&comTerminalConfiguration);
        PluginTerminalConfiguration terminalConfiguration;
        response->set_terminal_configuration(terminalConfiguration.get(comTerminalConfiguration)? terminalConfiguration.get(comTerminalConfiguration): nullptr);

        BSTR tagList;
        rsp->get_TagList(&tagList);
        response->set_tag_list(Tool::Tools::ParseBSTRToString(tagList));

        BSTR timeout;
        rsp->get_Timeout(&timeout);
        response->set_timeout(Tool::Tools::ParseBSTRToString(timeout));

        StatusReportFlag statusReportFlag;
        rsp->get_StatusReportFlag(&statusReportFlag);
        response->set_status_report_flag((FullIntegrationStatusReportFlag)statusReportFlag);

        ContinuousScreen continuousScreen;
        rsp->get_ContinuousScreen(&continuousScreen);
        response->set_continuous_screen((FullIntegrationContinuousScreen)continuousScreen);

        PinpadEnableFlag fallbackInsertPinpadEnableFlag;
        rsp->get_FallbackInsertPinpadEnableFlag(&fallbackInsertPinpadEnableFlag);
        response->set_fallback_insert_pinpad_enable_flag((FullIntegrationPinpadEnableFlag)fallbackInsertPinpadEnableFlag);

        KsnFlag ksnFlag;
        rsp->get_KsnFlag(&ksnFlag);
        response->set_ksn_flag((FullIntegrationKsnFlag)ksnFlag);

        SAFEARRAY* psaCustomData = NULL;
        rsp->get_CustomData(&psaCustomData);
        if(psaCustomData)
        {
            BSTR* bstrData;
            SafeArrayAccessData(psaCustomData, (void**)&bstrData);
            flutter::EncodableList listCustomData;
            for(ULONG i = 0; i < psaCustomData->rgsabound->cElements; i++)
            {
                if(bstrData[i])
                {
                    std::string tmp = Tool::Tools::ParseBSTRToString(bstrData[i]);
                    flutter::EncodableValue tmpValue(tmp);
                    listCustomData.push_back(tmpValue);
                }
            }
            response->set_custom_data(listCustomData);
            SafeArrayUnaccessData(psaCustomData);
        }

        PinpadEnableFlag fallbackToManualPinpadEnableFlag;
        rsp->get_FallbackToManualPinpadEnableFlag(&fallbackToManualPinpadEnableFlag);
        response->set_fallback_to_manual_pinpad_enable_flag((FullIntegrationPinpadEnableFlag)fallbackToManualPinpadEnableFlag);

        CComPtr<_CustomMacInformationRequest> comCustomMacInformation = NULL;
        rsp->get_CustomMacInformation(&comCustomMacInformation);
        PluginCustomMacInformationRequest customMacInformation;
        response->set_custom_mac_information(customMacInformation.get(comCustomMacInformation)? customMacInformation.get(comCustomMacInformation): nullptr);

        return &(*response);
    }
}
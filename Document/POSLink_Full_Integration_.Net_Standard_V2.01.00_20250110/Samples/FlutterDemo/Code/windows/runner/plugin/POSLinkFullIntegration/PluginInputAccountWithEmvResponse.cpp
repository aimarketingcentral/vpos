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
#include "PluginInputAccountWithEmvResponse.h"

namespace POSLinkFullIntegration{
    PluginInputAccountWithEmvResponse::PluginInputAccountWithEmvResponse(){}

    _InputAccountWithEmvResponse* PluginInputAccountWithEmvResponse::set(const std::optional<FullIntegrationInputAccountWithEmvResponse>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidInputAccountWithEmvResponse;
        CLSIDFromProgID(OLESTR("POSLinkFullIntegration.FullIntegration.InputAccountWithEmvResponse"),&clsidInputAccountWithEmvResponse);
        request = NULL;
        request.CoCreateInstance(clsidInputAccountWithEmvResponse);

        request->put_EntryMode((EntryMode)*req->entry_mode());

        request->put_Track1Data(req->track1_data()?Tool::Tools::ParseStringToBSTR(*req->track1_data()):SysAllocString(L""));

        request->put_Track2Data(req->track2_data()?Tool::Tools::ParseStringToBSTR(*req->track2_data()):SysAllocString(L""));

        request->put_Track3Data(req->track3_data()?Tool::Tools::ParseStringToBSTR(*req->track3_data()):SysAllocString(L""));

        request->put_Pan(req->pan()?Tool::Tools::ParseStringToBSTR(*req->pan()):SysAllocString(L""));

        request->put_MaskedPan(req->masked_pan()?Tool::Tools::ParseStringToBSTR(*req->masked_pan()):SysAllocString(L""));

        request->put_BarcodeType((BarcodeType)*req->barcode_type());

        request->put_BarcodeData(req->barcode_data()?Tool::Tools::ParseStringToBSTR(*req->barcode_data()):SysAllocString(L""));

        request->put_Ksn(req->ksn()?Tool::Tools::ParseStringToBSTR(*req->ksn()):SysAllocString(L""));

        request->put_Etb(req->etb()?Tool::Tools::ParseStringToBSTR(*req->etb()):SysAllocString(L""));

        request->put_ContactlessTransactionPath((ContactlessTransactionPath)*req->contactless_transaction_path());

        request->put_AuthorizationResult((FirstGacResult)*req->authorization_result());

        request->put_SignatureFlag((SignatureFlag)*req->signature_flag());

        request->put_OnlinePinFlag((OnlinePinFlag)*req->online_pin_flag());

        request->put_EmvTlvData(req->emv_tlv_data()?Tool::Tools::ParseStringToBSTR(*req->emv_tlv_data()):SysAllocString(L""));

        request->put_EncryptedEmvTlvData(req->encrypted_emv_tlv_data()?Tool::Tools::ParseStringToBSTR(*req->encrypted_emv_tlv_data()):SysAllocString(L""));

        request->put_EncryptedSensitiveTlvData(req->encrypted_sensitive_tlv_data()?Tool::Tools::ParseStringToBSTR(*req->encrypted_sensitive_tlv_data()):SysAllocString(L""));

        PluginAdditionalAccountResponse additionalAccountInformation;
        request->putref_AdditionalAccountInformation(additionalAccountInformation.set(req->additional_account_information() ? std::optional<const FullIntegrationAdditionalAccountResponse>(*req->additional_account_information()) : std::nullopt));

        request->put_Cvm((CardholderVerificationMethod)*req->cvm());

        PluginVasResponse vasInformation;
        request->putref_VasInformation(vasInformation.set(req->vas_information() ? std::optional<const FullIntegrationVasResponse>(*req->vas_information()) : std::nullopt));

        request->put_PinpadType((PinpadType)*req->pinpad_type());

        request->put_LuhnValidationResult((LuhnValidationResult)*req->luhn_validation_result());

        if(req->custom_encrypted_data())
        {
            flutter::EncodableList tmpEnList = *req->custom_encrypted_data();
            SAFEARRAY *psa;
            SAFEARRAYBOUND rgsabound[1];
            rgsabound[0].cElements = (ULONG)(tmpEnList.size());
            rgsabound[0].lLbound = 0;
            psa = SafeArrayCreate(VT_BSTR, 1, rgsabound);
            long i=0;
            for(flutter::EncodableList::iterator i_data = tmpEnList.begin(); i_data != tmpEnList.end(); i_data++)
            {
                flutter::EncodableValue tmpEnValue = *i_data;
                std::string tmpCustomEncryptedData = std::get<std::string>(tmpEnValue);
                BSTR comCustomEncryptedData = Tool::Tools::ParseStringToBSTR(tmpCustomEncryptedData);
                SafeArrayPutElement(psa, &i, comCustomEncryptedData);
                i++;
            }
            request->put_CustomEncryptedData(psa);
            SafeArrayUnaccessData(psa);
        }

        PluginCustomMacDataResponse customMacData;
        request->putref_CustomMacData(customMacData.set(req->custom_mac_data() ? std::optional<const FullIntegrationCustomMacDataResponse>(*req->custom_mac_data()) : std::nullopt));

        return request;
    }

    const FullIntegrationInputAccountWithEmvResponse* PluginInputAccountWithEmvResponse::get(_InputAccountWithEmvResponse* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = FullIntegrationInputAccountWithEmvResponse();

        BSTR responseCode;
        rsp->get_ResponseCode(&responseCode);
        response->set_response_code(Tool::Tools::ParseBSTRToString(responseCode));

        BSTR responseMessage;
        rsp->get_ResponseMessage(&responseMessage);
        response->set_response_message(Tool::Tools::ParseBSTRToString(responseMessage));

        EntryMode entryMode;
        rsp->get_EntryMode(&entryMode);
        response->set_entry_mode((FullIntegrationEntryMode)entryMode);

        BSTR track1Data;
        rsp->get_Track1Data(&track1Data);
        response->set_track1_data(Tool::Tools::ParseBSTRToString(track1Data));

        BSTR track2Data;
        rsp->get_Track2Data(&track2Data);
        response->set_track2_data(Tool::Tools::ParseBSTRToString(track2Data));

        BSTR track3Data;
        rsp->get_Track3Data(&track3Data);
        response->set_track3_data(Tool::Tools::ParseBSTRToString(track3Data));

        BSTR pan;
        rsp->get_Pan(&pan);
        response->set_pan(Tool::Tools::ParseBSTRToString(pan));

        BSTR maskedPan;
        rsp->get_MaskedPan(&maskedPan);
        response->set_masked_pan(Tool::Tools::ParseBSTRToString(maskedPan));

        BarcodeType barcodeType;
        rsp->get_BarcodeType(&barcodeType);
        response->set_barcode_type((FullIntegrationBarcodeType)barcodeType);

        BSTR barcodeData;
        rsp->get_BarcodeData(&barcodeData);
        response->set_barcode_data(Tool::Tools::ParseBSTRToString(barcodeData));

        BSTR ksn;
        rsp->get_Ksn(&ksn);
        response->set_ksn(Tool::Tools::ParseBSTRToString(ksn));

        BSTR etb;
        rsp->get_Etb(&etb);
        response->set_etb(Tool::Tools::ParseBSTRToString(etb));

        ContactlessTransactionPath contactlessTransactionPath;
        rsp->get_ContactlessTransactionPath(&contactlessTransactionPath);
        response->set_contactless_transaction_path((FullIntegrationContactlessTransactionPath)contactlessTransactionPath);

        FirstGacResult authorizationResult;
        rsp->get_AuthorizationResult(&authorizationResult);
        response->set_authorization_result((FullIntegrationFirstGacResult)authorizationResult);

        SignatureFlag signatureFlag;
        rsp->get_SignatureFlag(&signatureFlag);
        response->set_signature_flag((FullIntegrationSignatureFlag)signatureFlag);

        OnlinePinFlag onlinePinFlag;
        rsp->get_OnlinePinFlag(&onlinePinFlag);
        response->set_online_pin_flag((FullIntegrationOnlinePinFlag)onlinePinFlag);

        BSTR emvTlvData;
        rsp->get_EmvTlvData(&emvTlvData);
        response->set_emv_tlv_data(Tool::Tools::ParseBSTRToString(emvTlvData));

        BSTR encryptedEmvTlvData;
        rsp->get_EncryptedEmvTlvData(&encryptedEmvTlvData);
        response->set_encrypted_emv_tlv_data(Tool::Tools::ParseBSTRToString(encryptedEmvTlvData));

        BSTR encryptedSensitiveTlvData;
        rsp->get_EncryptedSensitiveTlvData(&encryptedSensitiveTlvData);
        response->set_encrypted_sensitive_tlv_data(Tool::Tools::ParseBSTRToString(encryptedSensitiveTlvData));

        CComPtr<_AdditionalAccountResponse> comAdditionalAccountInformation = NULL;
        rsp->get_AdditionalAccountInformation(&comAdditionalAccountInformation);
        PluginAdditionalAccountResponse additionalAccountInformation;
        response->set_additional_account_information(additionalAccountInformation.get(comAdditionalAccountInformation)? additionalAccountInformation.get(comAdditionalAccountInformation): nullptr);

        CardholderVerificationMethod cvm;
        rsp->get_Cvm(&cvm);
        response->set_cvm((FullIntegrationCardholderVerificationMethod)cvm);

        CComPtr<_VasResponse> comVasInformation = NULL;
        rsp->get_VasInformation(&comVasInformation);
        PluginVasResponse vasInformation;
        response->set_vas_information(vasInformation.get(comVasInformation)? vasInformation.get(comVasInformation): nullptr);

        PinpadType pinpadType;
        rsp->get_PinpadType(&pinpadType);
        response->set_pinpad_type((FullIntegrationPinpadType)pinpadType);

        LuhnValidationResult luhnValidationResult;
        rsp->get_LuhnValidationResult(&luhnValidationResult);
        response->set_luhn_validation_result((FullIntegrationLuhnValidationResult)luhnValidationResult);

        SAFEARRAY* psaCustomEncryptedData = NULL;
        rsp->get_CustomEncryptedData(&psaCustomEncryptedData);
        if(psaCustomEncryptedData)
        {
            BSTR* bstrData;
            SafeArrayAccessData(psaCustomEncryptedData, (void**)&bstrData);
            flutter::EncodableList listCustomEncryptedData;
            for(ULONG i = 0; i < psaCustomEncryptedData->rgsabound->cElements; i++)
            {
                if(bstrData[i])
                {
                    std::string tmp = Tool::Tools::ParseBSTRToString(bstrData[i]);
                    flutter::EncodableValue tmpValue(tmp);
                    listCustomEncryptedData.push_back(tmpValue);
                }
            }
            response->set_custom_encrypted_data(listCustomEncryptedData);
            SafeArrayUnaccessData(psaCustomEncryptedData);
        }

        CComPtr<_CustomMacDataResponse> comCustomMacData = NULL;
        rsp->get_CustomMacData(&comCustomMacData);
        PluginCustomMacDataResponse customMacData;
        response->set_custom_mac_data(customMacData.get(comCustomMacData)? customMacData.get(comCustomMacData): nullptr);

        return &(*response);
    }
}
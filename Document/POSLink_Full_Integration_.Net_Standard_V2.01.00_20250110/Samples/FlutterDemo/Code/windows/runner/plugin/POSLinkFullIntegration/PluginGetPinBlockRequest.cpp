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
#include "PluginGetPinBlockRequest.h"

namespace POSLinkFullIntegration{
    PluginGetPinBlockRequest::PluginGetPinBlockRequest(){}

    _GetPinBlockRequest* PluginGetPinBlockRequest::set(const std::optional<FullIntegrationGetPinBlockRequest>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidGetPinBlockRequest;
        CLSIDFromProgID(OLESTR("POSLinkFullIntegration.FullIntegration.GetPinBlockRequest"),&clsidGetPinBlockRequest);
        request = NULL;
        request.CoCreateInstance(clsidGetPinBlockRequest);

        request->put_AccountNumber(req->account_number()?Tool::Tools::ParseStringToBSTR(*req->account_number()):SysAllocString(L""));

        request->put_EncryptionType((EncryptionType)*req->encryption_type());

        request->put_KeySlot(req->key_slot()?Tool::Tools::ParseStringToBSTR(*req->key_slot()):SysAllocString(L""));

        request->put_PinMinLength(req->pin_min_length()?Tool::Tools::ParseStringToBSTR(*req->pin_min_length()):SysAllocString(L""));

        request->put_PinMaxLength(req->pin_max_length()?Tool::Tools::ParseStringToBSTR(*req->pin_max_length()):SysAllocString(L""));

        request->put_AllowOnlinePinBypass((AllowOnlinePinBypass)*req->allow_online_pin_bypass());

        request->put_PinAlgorithm((PinAlgorithm)*req->pin_algorithm());

        request->put_Timeout(req->timeout()?Tool::Tools::ParseStringToBSTR(*req->timeout()):SysAllocString(L""));

        request->put_EdcType((EdcType)*req->edc_type());

        request->put_TransactionType((TransactionType)*req->transaction_type());

        request->put_Title(req->title()?Tool::Tools::ParseStringToBSTR(*req->title()):SysAllocString(L""));

        request->put_PinpadType((PinpadType)*req->pinpad_type());

        request->put_KsnFlag((KsnFlag)*req->ksn_flag());

        return request;
    }

    const FullIntegrationGetPinBlockRequest* PluginGetPinBlockRequest::get(_GetPinBlockRequest* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = FullIntegrationGetPinBlockRequest();

        BSTR accountNumber;
        rsp->get_AccountNumber(&accountNumber);
        response->set_account_number(Tool::Tools::ParseBSTRToString(accountNumber));

        EncryptionType encryptionType;
        rsp->get_EncryptionType(&encryptionType);
        response->set_encryption_type((FullIntegrationEncryptionType)encryptionType);

        BSTR keySlot;
        rsp->get_KeySlot(&keySlot);
        response->set_key_slot(Tool::Tools::ParseBSTRToString(keySlot));

        BSTR pinMinLength;
        rsp->get_PinMinLength(&pinMinLength);
        response->set_pin_min_length(Tool::Tools::ParseBSTRToString(pinMinLength));

        BSTR pinMaxLength;
        rsp->get_PinMaxLength(&pinMaxLength);
        response->set_pin_max_length(Tool::Tools::ParseBSTRToString(pinMaxLength));

        AllowOnlinePinBypass allowOnlinePinBypass;
        rsp->get_AllowOnlinePinBypass(&allowOnlinePinBypass);
        response->set_allow_online_pin_bypass((FullIntegrationAllowOnlinePinBypass)allowOnlinePinBypass);

        PinAlgorithm pinAlgorithm;
        rsp->get_PinAlgorithm(&pinAlgorithm);
        response->set_pin_algorithm((FullIntegrationPinAlgorithm)pinAlgorithm);

        BSTR timeout;
        rsp->get_Timeout(&timeout);
        response->set_timeout(Tool::Tools::ParseBSTRToString(timeout));

        EdcType edcType;
        rsp->get_EdcType(&edcType);
        response->set_edc_type((FullIntegrationEdcType)edcType);

        TransactionType transactionType;
        rsp->get_TransactionType(&transactionType);
        response->set_transaction_type((FullIntegrationTransactionType)transactionType);

        BSTR title;
        rsp->get_Title(&title);
        response->set_title(Tool::Tools::ParseBSTRToString(title));

        PinpadType pinpadType;
        rsp->get_PinpadType(&pinpadType);
        response->set_pinpad_type((FullIntegrationPinpadType)pinpadType);

        KsnFlag ksnFlag;
        rsp->get_KsnFlag(&ksnFlag);
        response->set_ksn_flag((FullIntegrationKsnFlag)ksnFlag);

        return &(*response);
    }
}
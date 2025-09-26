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
#include "PluginAuthorizeCardRequest.h"

namespace POSLinkFullIntegration{
    PluginAuthorizeCardRequest::PluginAuthorizeCardRequest(){}

    _AuthorizeCardRequest* PluginAuthorizeCardRequest::set(const std::optional<FullIntegrationAuthorizeCardRequest>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidAuthorizeCardRequest;
        CLSIDFromProgID(OLESTR("POSLinkFullIntegration.FullIntegration.AuthorizeCardRequest"),&clsidAuthorizeCardRequest);
        request = NULL;
        request.CoCreateInstance(clsidAuthorizeCardRequest);

        PluginAmountRequest amountInformation;
        request->putref_AmountInformation(amountInformation.set(req->amount_information() ? std::optional<const FullIntegrationAmountRequest>(*req->amount_information()) : std::nullopt));

        request->put_MerchantDecision((MerchantDecision)*req->merchant_decision());

        request->put_PinEncryptionType((EncryptionType)*req->pin_encryption_type());

        request->put_PinKeySlot(req->pin_key_slot()?Tool::Tools::ParseStringToBSTR(*req->pin_key_slot()):SysAllocString(L""));

        request->put_PinMinLength(req->pin_min_length()?Tool::Tools::ParseStringToBSTR(*req->pin_min_length()):SysAllocString(L""));

        request->put_PinMaxLength(req->pin_max_length()?Tool::Tools::ParseStringToBSTR(*req->pin_max_length()):SysAllocString(L""));

        request->put_PinBypass((PinBypass)*req->pin_bypass());

        request->put_PinAlgorithm((PinAlgorithm)*req->pin_algorithm());

        PluginTerminalConfiguration terminalConfiguration;
        request->putref_TerminalConfiguration(terminalConfiguration.set(req->terminal_configuration() ? std::optional<const FullIntegrationTerminalConfiguration>(*req->terminal_configuration()) : std::nullopt));

        request->put_TagList(req->tag_list()?Tool::Tools::ParseStringToBSTR(*req->tag_list()):SysAllocString(L""));

        request->put_Timeout(req->timeout()?Tool::Tools::ParseStringToBSTR(*req->timeout()):SysAllocString(L""));

        request->put_ContinuousScreen((ContinuousScreen)*req->continuous_screen());

        request->put_PinpadType((PinpadType)*req->pinpad_type());

        request->put_KsnFlag((KsnFlag)*req->ksn_flag());

        request->put_Title(req->title()?Tool::Tools::ParseStringToBSTR(*req->title()):SysAllocString(L""));

        return request;
    }

    const FullIntegrationAuthorizeCardRequest* PluginAuthorizeCardRequest::get(_AuthorizeCardRequest* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = FullIntegrationAuthorizeCardRequest();

        CComPtr<_AmountRequest> comAmountInformation = NULL;
        rsp->get_AmountInformation(&comAmountInformation);
        PluginAmountRequest amountInformation;
        response->set_amount_information(amountInformation.get(comAmountInformation)? amountInformation.get(comAmountInformation): nullptr);

        MerchantDecision merchantDecision;
        rsp->get_MerchantDecision(&merchantDecision);
        response->set_merchant_decision((FullIntegrationMerchantDecision)merchantDecision);

        EncryptionType pinEncryptionType;
        rsp->get_PinEncryptionType(&pinEncryptionType);
        response->set_pin_encryption_type((FullIntegrationEncryptionType)pinEncryptionType);

        BSTR pinKeySlot;
        rsp->get_PinKeySlot(&pinKeySlot);
        response->set_pin_key_slot(Tool::Tools::ParseBSTRToString(pinKeySlot));

        BSTR pinMinLength;
        rsp->get_PinMinLength(&pinMinLength);
        response->set_pin_min_length(Tool::Tools::ParseBSTRToString(pinMinLength));

        BSTR pinMaxLength;
        rsp->get_PinMaxLength(&pinMaxLength);
        response->set_pin_max_length(Tool::Tools::ParseBSTRToString(pinMaxLength));

        PinBypass pinBypass;
        rsp->get_PinBypass(&pinBypass);
        response->set_pin_bypass((FullIntegrationPinBypass)pinBypass);

        PinAlgorithm pinAlgorithm;
        rsp->get_PinAlgorithm(&pinAlgorithm);
        response->set_pin_algorithm((FullIntegrationPinAlgorithm)pinAlgorithm);

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

        ContinuousScreen continuousScreen;
        rsp->get_ContinuousScreen(&continuousScreen);
        response->set_continuous_screen((FullIntegrationContinuousScreen)continuousScreen);

        PinpadType pinpadType;
        rsp->get_PinpadType(&pinpadType);
        response->set_pinpad_type((FullIntegrationPinpadType)pinpadType);

        KsnFlag ksnFlag;
        rsp->get_KsnFlag(&ksnFlag);
        response->set_ksn_flag((FullIntegrationKsnFlag)ksnFlag);

        BSTR title;
        rsp->get_Title(&title);
        response->set_title(Tool::Tools::ParseBSTRToString(title));

        return &(*response);
    }
}
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
#include "PluginAuthorizeCardResponse.h"

namespace POSLinkFullIntegration{
    PluginAuthorizeCardResponse::PluginAuthorizeCardResponse(){}

    _AuthorizeCardResponse* PluginAuthorizeCardResponse::set(const std::optional<FullIntegrationAuthorizeCardResponse>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidAuthorizeCardResponse;
        CLSIDFromProgID(OLESTR("POSLinkFullIntegration.FullIntegration.AuthorizeCardResponse"),&clsidAuthorizeCardResponse);
        request = NULL;
        request.CoCreateInstance(clsidAuthorizeCardResponse);

        request->put_AuthorizationResult((FirstGacResult)*req->authorization_result());

        request->put_SignatureFlag((SignatureFlag)*req->signature_flag());

        request->put_PinBypassStatus((PinBypassStatus)*req->pin_bypass_status());

        request->put_PinBlock(req->pin_block()?Tool::Tools::ParseStringToBSTR(*req->pin_block()):SysAllocString(L""));

        request->put_Ksn(req->ksn()?Tool::Tools::ParseStringToBSTR(*req->ksn()):SysAllocString(L""));

        request->put_EmvTlvData(req->emv_tlv_data()?Tool::Tools::ParseStringToBSTR(*req->emv_tlv_data()):SysAllocString(L""));

        request->put_Cvm((CardholderVerificationMethod)*req->cvm());

        request->put_PinpadType((PinpadType)*req->pinpad_type());

        return request;
    }

    const FullIntegrationAuthorizeCardResponse* PluginAuthorizeCardResponse::get(_AuthorizeCardResponse* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = FullIntegrationAuthorizeCardResponse();

        BSTR responseCode;
        rsp->get_ResponseCode(&responseCode);
        response->set_response_code(Tool::Tools::ParseBSTRToString(responseCode));

        BSTR responseMessage;
        rsp->get_ResponseMessage(&responseMessage);
        response->set_response_message(Tool::Tools::ParseBSTRToString(responseMessage));

        FirstGacResult authorizationResult;
        rsp->get_AuthorizationResult(&authorizationResult);
        response->set_authorization_result((FullIntegrationFirstGacResult)authorizationResult);

        SignatureFlag signatureFlag;
        rsp->get_SignatureFlag(&signatureFlag);
        response->set_signature_flag((FullIntegrationSignatureFlag)signatureFlag);

        PinBypassStatus pinBypassStatus;
        rsp->get_PinBypassStatus(&pinBypassStatus);
        response->set_pin_bypass_status((FullIntegrationPinBypassStatus)pinBypassStatus);

        BSTR pinBlock;
        rsp->get_PinBlock(&pinBlock);
        response->set_pin_block(Tool::Tools::ParseBSTRToString(pinBlock));

        BSTR ksn;
        rsp->get_Ksn(&ksn);
        response->set_ksn(Tool::Tools::ParseBSTRToString(ksn));

        BSTR emvTlvData;
        rsp->get_EmvTlvData(&emvTlvData);
        response->set_emv_tlv_data(Tool::Tools::ParseBSTRToString(emvTlvData));

        CardholderVerificationMethod cvm;
        rsp->get_Cvm(&cvm);
        response->set_cvm((FullIntegrationCardholderVerificationMethod)cvm);

        PinpadType pinpadType;
        rsp->get_PinpadType(&pinpadType);
        response->set_pinpad_type((FullIntegrationPinpadType)pinpadType);

        return &(*response);
    }
}
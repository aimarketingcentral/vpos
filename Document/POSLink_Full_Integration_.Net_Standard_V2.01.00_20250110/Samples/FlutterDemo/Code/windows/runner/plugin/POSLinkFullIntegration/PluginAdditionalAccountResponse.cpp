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
#include "PluginAdditionalAccountResponse.h"

namespace POSLinkFullIntegration{
    PluginAdditionalAccountResponse::PluginAdditionalAccountResponse(){}

    _AdditionalAccountResponse* PluginAdditionalAccountResponse::set(const std::optional<FullIntegrationAdditionalAccountResponse>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidAdditionalAccountResponse;
        CLSIDFromProgID(OLESTR("POSLinkFullIntegration.Util.AdditionalAccountResponse"),&clsidAdditionalAccountResponse);
        request = NULL;
        request.CoCreateInstance(clsidAdditionalAccountResponse);

        request->put_ExpiryDate(req->expiry_date()?Tool::Tools::ParseStringToBSTR(*req->expiry_date()):SysAllocString(L""));

        request->put_CardHolderName(req->card_holder_name()?Tool::Tools::ParseStringToBSTR(*req->card_holder_name()):SysAllocString(L""));

        request->put_ServiceCode(req->service_code()?Tool::Tools::ParseStringToBSTR(*req->service_code()):SysAllocString(L""));

        request->put_CvvCode(req->cvv_code()?Tool::Tools::ParseStringToBSTR(*req->cvv_code()):SysAllocString(L""));

        request->put_ZipCode(req->zip_code()?Tool::Tools::ParseStringToBSTR(*req->zip_code()):SysAllocString(L""));

        return request;
    }

    const FullIntegrationAdditionalAccountResponse* PluginAdditionalAccountResponse::get(_AdditionalAccountResponse* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = FullIntegrationAdditionalAccountResponse();

        BSTR expiryDate;
        rsp->get_ExpiryDate(&expiryDate);
        response->set_expiry_date(Tool::Tools::ParseBSTRToString(expiryDate));

        BSTR cardHolderName;
        rsp->get_CardHolderName(&cardHolderName);
        response->set_card_holder_name(Tool::Tools::ParseBSTRToString(cardHolderName));

        BSTR serviceCode;
        rsp->get_ServiceCode(&serviceCode);
        response->set_service_code(Tool::Tools::ParseBSTRToString(serviceCode));

        BSTR cvvCode;
        rsp->get_CvvCode(&cvvCode);
        response->set_cvv_code(Tool::Tools::ParseBSTRToString(cvvCode));

        BSTR zipCode;
        rsp->get_ZipCode(&zipCode);
        response->set_zip_code(Tool::Tools::ParseBSTRToString(zipCode));

        return &(*response);
    }
}
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
#include "PluginAmountRequest.h"

namespace POSLinkFullIntegration{
    PluginAmountRequest::PluginAmountRequest(){}

    _AmountRequest* PluginAmountRequest::set(const std::optional<FullIntegrationAmountRequest>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidAmountRequest;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Util.AmountRequest"),&clsidAmountRequest);
        request = NULL;
        request.CoCreateInstance(clsidAmountRequest);

        request->put_TransactionAmount(req->transaction_amount()?Tool::Tools::ParseStringToBSTR(*req->transaction_amount()):SysAllocString(L""));

        request->put_TipAmount(req->tip_amount()?Tool::Tools::ParseStringToBSTR(*req->tip_amount()):SysAllocString(L""));

        request->put_CashBackAmount(req->cash_back_amount()?Tool::Tools::ParseStringToBSTR(*req->cash_back_amount()):SysAllocString(L""));

        request->put_MerchantFee(req->merchant_fee()?Tool::Tools::ParseStringToBSTR(*req->merchant_fee()):SysAllocString(L""));

        request->put_TaxAmount(req->tax_amount()?Tool::Tools::ParseStringToBSTR(*req->tax_amount()):SysAllocString(L""));

        request->put_FuelAmount(req->fuel_amount()?Tool::Tools::ParseStringToBSTR(*req->fuel_amount()):SysAllocString(L""));

        request->put_ServiceFee(req->service_fee()?Tool::Tools::ParseStringToBSTR(*req->service_fee()):SysAllocString(L""));

        request->put_OriginalAmount(req->original_amount()?Tool::Tools::ParseStringToBSTR(*req->original_amount()):SysAllocString(L""));

        return request;
    }

    const FullIntegrationAmountRequest* PluginAmountRequest::get(_AmountRequest* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = FullIntegrationAmountRequest();

        BSTR transactionAmount;
        rsp->get_TransactionAmount(&transactionAmount);
        response->set_transaction_amount(Tool::Tools::ParseBSTRToString(transactionAmount));

        BSTR tipAmount;
        rsp->get_TipAmount(&tipAmount);
        response->set_tip_amount(Tool::Tools::ParseBSTRToString(tipAmount));

        BSTR cashBackAmount;
        rsp->get_CashBackAmount(&cashBackAmount);
        response->set_cash_back_amount(Tool::Tools::ParseBSTRToString(cashBackAmount));

        BSTR merchantFee;
        rsp->get_MerchantFee(&merchantFee);
        response->set_merchant_fee(Tool::Tools::ParseBSTRToString(merchantFee));

        BSTR taxAmount;
        rsp->get_TaxAmount(&taxAmount);
        response->set_tax_amount(Tool::Tools::ParseBSTRToString(taxAmount));

        BSTR fuelAmount;
        rsp->get_FuelAmount(&fuelAmount);
        response->set_fuel_amount(Tool::Tools::ParseBSTRToString(fuelAmount));

        BSTR serviceFee;
        rsp->get_ServiceFee(&serviceFee);
        response->set_service_fee(Tool::Tools::ParseBSTRToString(serviceFee));

        BSTR originalAmount;
        rsp->get_OriginalAmount(&originalAmount);
        response->set_original_amount(Tool::Tools::ParseBSTRToString(originalAmount));

        return &(*response);
    }
}
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
#include "PluginTerminalConfiguration.h"

namespace POSLinkFullIntegration{
    PluginTerminalConfiguration::PluginTerminalConfiguration(){}

    _TerminalConfiguration* PluginTerminalConfiguration::set(const std::optional<FullIntegrationTerminalConfiguration>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidTerminalConfiguration;
        CLSIDFromProgID(OLESTR("POSLinkFullIntegration.Util.TerminalConfiguration"),&clsidTerminalConfiguration);
        request = NULL;
        request.CoCreateInstance(clsidTerminalConfiguration);

        request->put_EmvKernelConfigurationSelection(req->emv_kernel_configuration_selection()?Tool::Tools::ParseStringToBSTR(*req->emv_kernel_configuration_selection()):SysAllocString(L""));

        request->put_TransactionDate(req->transaction_date()?Tool::Tools::ParseStringToBSTR(*req->transaction_date()):SysAllocString(L""));

        request->put_TransactionTime(req->transaction_time()?Tool::Tools::ParseStringToBSTR(*req->transaction_time()):SysAllocString(L""));

        request->put_CurrencyCode(req->currency_code()?Tool::Tools::ParseStringToBSTR(*req->currency_code()):SysAllocString(L""));

        request->put_CurrencyExponent(req->currency_exponent()?Tool::Tools::ParseStringToBSTR(*req->currency_exponent()):SysAllocString(L""));

        request->put_MerchantCategoryCode(req->merchant_category_code()?Tool::Tools::ParseStringToBSTR(*req->merchant_category_code()):SysAllocString(L""));

        request->put_TransactionSequenceNumber(req->transaction_sequence_number()?Tool::Tools::ParseStringToBSTR(*req->transaction_sequence_number()):SysAllocString(L""));

        request->put_TransactionCvmLimit(req->transaction_cvm_limit()?Tool::Tools::ParseStringToBSTR(*req->transaction_cvm_limit()):SysAllocString(L""));

        return request;
    }

    const FullIntegrationTerminalConfiguration* PluginTerminalConfiguration::get(_TerminalConfiguration* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = FullIntegrationTerminalConfiguration();

        BSTR emvKernelConfigurationSelection;
        rsp->get_EmvKernelConfigurationSelection(&emvKernelConfigurationSelection);
        response->set_emv_kernel_configuration_selection(Tool::Tools::ParseBSTRToString(emvKernelConfigurationSelection));

        BSTR transactionDate;
        rsp->get_TransactionDate(&transactionDate);
        response->set_transaction_date(Tool::Tools::ParseBSTRToString(transactionDate));

        BSTR transactionTime;
        rsp->get_TransactionTime(&transactionTime);
        response->set_transaction_time(Tool::Tools::ParseBSTRToString(transactionTime));

        BSTR currencyCode;
        rsp->get_CurrencyCode(&currencyCode);
        response->set_currency_code(Tool::Tools::ParseBSTRToString(currencyCode));

        BSTR currencyExponent;
        rsp->get_CurrencyExponent(&currencyExponent);
        response->set_currency_exponent(Tool::Tools::ParseBSTRToString(currencyExponent));

        BSTR merchantCategoryCode;
        rsp->get_MerchantCategoryCode(&merchantCategoryCode);
        response->set_merchant_category_code(Tool::Tools::ParseBSTRToString(merchantCategoryCode));

        BSTR transactionSequenceNumber;
        rsp->get_TransactionSequenceNumber(&transactionSequenceNumber);
        response->set_transaction_sequence_number(Tool::Tools::ParseBSTRToString(transactionSequenceNumber));

        BSTR transactionCvmLimit;
        rsp->get_TransactionCvmLimit(&transactionCvmLimit);
        response->set_transaction_cvm_limit(Tool::Tools::ParseBSTRToString(transactionCvmLimit));

        return &(*response);
    }
}
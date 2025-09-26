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
#include "PluginGetVariableResponse.h"

namespace POSLinkManage{
    PluginGetVariableResponse::PluginGetVariableResponse(){}

    _GetVariableResponse* PluginGetVariableResponse::set(const std::optional<ManageGetVariableResponse>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidGetVariableResponse;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Manage.GetVariableResponse"),&clsidGetVariableResponse);
        request = NULL;
        request.CoCreateInstance(clsidGetVariableResponse);

        request->put_VariableValue1(req->variable_value1()?Tool::Tools::ParseStringToBSTR(*req->variable_value1()):SysAllocString(L""));

        request->put_VariableValue2(req->variable_value2()?Tool::Tools::ParseStringToBSTR(*req->variable_value2()):SysAllocString(L""));

        request->put_VariableValue3(req->variable_value3()?Tool::Tools::ParseStringToBSTR(*req->variable_value3()):SysAllocString(L""));

        request->put_VariableValue4(req->variable_value4()?Tool::Tools::ParseStringToBSTR(*req->variable_value4()):SysAllocString(L""));

        request->put_VariableValue5(req->variable_value5()?Tool::Tools::ParseStringToBSTR(*req->variable_value5()):SysAllocString(L""));

        PluginMultiMerchant multiMerchant;
        request->putref_MultiMerchant(multiMerchant.set(req->multi_merchant() ? std::optional<const ManageMultiMerchant>(*req->multi_merchant()) : std::nullopt));

        return request;
    }

    const ManageGetVariableResponse* PluginGetVariableResponse::get(_GetVariableResponse* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = ManageGetVariableResponse();

        BSTR responseCode;
        rsp->get_ResponseCode(&responseCode);
        response->set_response_code(Tool::Tools::ParseBSTRToString(responseCode));

        BSTR responseMessage;
        rsp->get_ResponseMessage(&responseMessage);
        response->set_response_message(Tool::Tools::ParseBSTRToString(responseMessage));

        BSTR variableValue1;
        rsp->get_VariableValue1(&variableValue1);
        response->set_variable_value1(Tool::Tools::ParseBSTRToString(variableValue1));

        BSTR variableValue2;
        rsp->get_VariableValue2(&variableValue2);
        response->set_variable_value2(Tool::Tools::ParseBSTRToString(variableValue2));

        BSTR variableValue3;
        rsp->get_VariableValue3(&variableValue3);
        response->set_variable_value3(Tool::Tools::ParseBSTRToString(variableValue3));

        BSTR variableValue4;
        rsp->get_VariableValue4(&variableValue4);
        response->set_variable_value4(Tool::Tools::ParseBSTRToString(variableValue4));

        BSTR variableValue5;
        rsp->get_VariableValue5(&variableValue5);
        response->set_variable_value5(Tool::Tools::ParseBSTRToString(variableValue5));

        CComPtr<_MultiMerchant> comMultiMerchant = NULL;
        rsp->get_MultiMerchant(&comMultiMerchant);
        PluginMultiMerchant multiMerchant;
        response->set_multi_merchant(multiMerchant.get(comMultiMerchant)? multiMerchant.get(comMultiMerchant): nullptr);

        return &(*response);
    }
}
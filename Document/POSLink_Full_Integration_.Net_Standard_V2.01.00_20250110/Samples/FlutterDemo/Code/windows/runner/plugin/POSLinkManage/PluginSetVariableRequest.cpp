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
#include "PluginSetVariableRequest.h"

namespace POSLinkManage{
    PluginSetVariableRequest::PluginSetVariableRequest(){}

    _SetVariableRequest* PluginSetVariableRequest::set(const std::optional<ManageSetVariableRequest>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidSetVariableRequest;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Manage.SetVariableRequest"),&clsidSetVariableRequest);
        request = NULL;
        request.CoCreateInstance(clsidSetVariableRequest);

        request->put_EdcType((EdcType)*req->edc_type());

        request->put_VariableName1(req->variable_name1()?Tool::Tools::ParseStringToBSTR(*req->variable_name1()):SysAllocString(L""));

        request->put_VariableValue1(req->variable_value1()?Tool::Tools::ParseStringToBSTR(*req->variable_value1()):SysAllocString(L""));

        request->put_VariableName2(req->variable_name2()?Tool::Tools::ParseStringToBSTR(*req->variable_name2()):SysAllocString(L""));

        request->put_VariableValue2(req->variable_value2()?Tool::Tools::ParseStringToBSTR(*req->variable_value2()):SysAllocString(L""));

        request->put_VariableName3(req->variable_name3()?Tool::Tools::ParseStringToBSTR(*req->variable_name3()):SysAllocString(L""));

        request->put_VariableValue3(req->variable_value3()?Tool::Tools::ParseStringToBSTR(*req->variable_value3()):SysAllocString(L""));

        request->put_VariableName4(req->variable_name4()?Tool::Tools::ParseStringToBSTR(*req->variable_name4()):SysAllocString(L""));

        request->put_VariableValue4(req->variable_value4()?Tool::Tools::ParseStringToBSTR(*req->variable_value4()):SysAllocString(L""));

        request->put_VariableName5(req->variable_name5()?Tool::Tools::ParseStringToBSTR(*req->variable_name5()):SysAllocString(L""));

        request->put_VariableValue5(req->variable_value5()?Tool::Tools::ParseStringToBSTR(*req->variable_value5()):SysAllocString(L""));

        PluginMultiMerchant multiMerchant;
        request->putref_MultiMerchant(multiMerchant.set(req->multi_merchant() ? std::optional<const ManageMultiMerchant>(*req->multi_merchant()) : std::nullopt));

        return request;
    }

    const ManageSetVariableRequest* PluginSetVariableRequest::get(_SetVariableRequest* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = ManageSetVariableRequest();

        EdcType edcType;
        rsp->get_EdcType(&edcType);
        response->set_edc_type((ManageEdcType)edcType);

        BSTR variableName1;
        rsp->get_VariableName1(&variableName1);
        response->set_variable_name1(Tool::Tools::ParseBSTRToString(variableName1));

        BSTR variableValue1;
        rsp->get_VariableValue1(&variableValue1);
        response->set_variable_value1(Tool::Tools::ParseBSTRToString(variableValue1));

        BSTR variableName2;
        rsp->get_VariableName2(&variableName2);
        response->set_variable_name2(Tool::Tools::ParseBSTRToString(variableName2));

        BSTR variableValue2;
        rsp->get_VariableValue2(&variableValue2);
        response->set_variable_value2(Tool::Tools::ParseBSTRToString(variableValue2));

        BSTR variableName3;
        rsp->get_VariableName3(&variableName3);
        response->set_variable_name3(Tool::Tools::ParseBSTRToString(variableName3));

        BSTR variableValue3;
        rsp->get_VariableValue3(&variableValue3);
        response->set_variable_value3(Tool::Tools::ParseBSTRToString(variableValue3));

        BSTR variableName4;
        rsp->get_VariableName4(&variableName4);
        response->set_variable_name4(Tool::Tools::ParseBSTRToString(variableName4));

        BSTR variableValue4;
        rsp->get_VariableValue4(&variableValue4);
        response->set_variable_value4(Tool::Tools::ParseBSTRToString(variableValue4));

        BSTR variableName5;
        rsp->get_VariableName5(&variableName5);
        response->set_variable_name5(Tool::Tools::ParseBSTRToString(variableName5));

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
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
#include "PluginInputTextRequest.h"

namespace POSLinkForm{
    PluginInputTextRequest::PluginInputTextRequest(){}

    _InputTextRequest* PluginInputTextRequest::set(const std::optional<FormInputTextRequest>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidInputTextRequest;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Form.InputTextRequest"),&clsidInputTextRequest);
        request = NULL;
        request.CoCreateInstance(clsidInputTextRequest);

        request->put_Title((InputTextPrompt)*req->title());

        request->put_InputType((InputType)*req->input_type());

        request->put_MinLength(req->min_length()?Tool::Tools::ParseStringToBSTR(*req->min_length()):SysAllocString(L""));

        request->put_MaxLength(req->max_length()?Tool::Tools::ParseStringToBSTR(*req->max_length()):SysAllocString(L""));

        request->put_DefaultValue(req->default_value()?Tool::Tools::ParseStringToBSTR(*req->default_value()):SysAllocString(L""));

        request->put_Timeout(req->timeout()?Tool::Tools::ParseStringToBSTR(*req->timeout()):SysAllocString(L""));

        request->put_ContinuousScreen((ContinuousScreen)*req->continuous_screen());

        return request;
    }

    const FormInputTextRequest* PluginInputTextRequest::get(_InputTextRequest* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = FormInputTextRequest();

        InputTextPrompt title;
        rsp->get_Title(&title);
        response->set_title((FormInputTextPrompt)title);

        InputType inputType;
        rsp->get_InputType(&inputType);
        response->set_input_type((FormInputType)inputType);

        BSTR minLength;
        rsp->get_MinLength(&minLength);
        response->set_min_length(Tool::Tools::ParseBSTRToString(minLength));

        BSTR maxLength;
        rsp->get_MaxLength(&maxLength);
        response->set_max_length(Tool::Tools::ParseBSTRToString(maxLength));

        BSTR defaultValue;
        rsp->get_DefaultValue(&defaultValue);
        response->set_default_value(Tool::Tools::ParseBSTRToString(defaultValue));

        BSTR timeout;
        rsp->get_Timeout(&timeout);
        response->set_timeout(Tool::Tools::ParseBSTRToString(timeout));

        ContinuousScreen continuousScreen;
        rsp->get_ContinuousScreen(&continuousScreen);
        response->set_continuous_screen((FormContinuousScreen)continuousScreen);

        return &(*response);
    }
}
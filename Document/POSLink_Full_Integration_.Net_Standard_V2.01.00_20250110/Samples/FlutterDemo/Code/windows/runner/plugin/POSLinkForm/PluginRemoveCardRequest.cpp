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
#include "PluginRemoveCardRequest.h"

namespace POSLinkForm{
    PluginRemoveCardRequest::PluginRemoveCardRequest(){}

    _RemoveCardRequest* PluginRemoveCardRequest::set(const std::optional<FormRemoveCardRequest>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidRemoveCardRequest;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Form.RemoveCardRequest"),&clsidRemoveCardRequest);
        request = NULL;
        request.CoCreateInstance(clsidRemoveCardRequest);

        request->put_Message1(req->message1()?Tool::Tools::ParseStringToBSTR(*req->message1()):SysAllocString(L""));

        request->put_Message2(req->message2()?Tool::Tools::ParseStringToBSTR(*req->message2()):SysAllocString(L""));

        request->put_ContinuousScreen((ContinuousScreen)*req->continuous_screen());

        request->put_PinpadType((PinpadType)*req->pinpad_type());

        request->put_Icon(req->icon()?Tool::Tools::ParseStringToBSTR(*req->icon()):SysAllocString(L""));

        return request;
    }

    const FormRemoveCardRequest* PluginRemoveCardRequest::get(_RemoveCardRequest* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = FormRemoveCardRequest();

        BSTR message1;
        rsp->get_Message1(&message1);
        response->set_message1(Tool::Tools::ParseBSTRToString(message1));

        BSTR message2;
        rsp->get_Message2(&message2);
        response->set_message2(Tool::Tools::ParseBSTRToString(message2));

        ContinuousScreen continuousScreen;
        rsp->get_ContinuousScreen(&continuousScreen);
        response->set_continuous_screen((FormContinuousScreen)continuousScreen);

        PinpadType pinpadType;
        rsp->get_PinpadType(&pinpadType);
        response->set_pinpad_type((FormPinpadType)pinpadType);

        BSTR icon;
        rsp->get_Icon(&icon);
        response->set_icon(Tool::Tools::ParseBSTRToString(icon));

        return &(*response);
    }
}
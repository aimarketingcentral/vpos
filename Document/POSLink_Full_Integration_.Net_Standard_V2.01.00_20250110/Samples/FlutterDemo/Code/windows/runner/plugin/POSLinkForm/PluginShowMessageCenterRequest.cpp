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
#include "PluginShowMessageCenterRequest.h"

namespace POSLinkForm{
    PluginShowMessageCenterRequest::PluginShowMessageCenterRequest(){}

    _ShowMessageCenterRequest* PluginShowMessageCenterRequest::set(const std::optional<FormShowMessageCenterRequest>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidShowMessageCenterRequest;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Form.ShowMessageCenterRequest"),&clsidShowMessageCenterRequest);
        request = NULL;
        request.CoCreateInstance(clsidShowMessageCenterRequest);

        request->put_Title(req->title()?Tool::Tools::ParseStringToBSTR(*req->title()):SysAllocString(L""));

        request->put_Message1(req->message1()?Tool::Tools::ParseStringToBSTR(*req->message1()):SysAllocString(L""));

        request->put_Message2(req->message2()?Tool::Tools::ParseStringToBSTR(*req->message2()):SysAllocString(L""));

        request->put_Timeout(req->timeout()?Tool::Tools::ParseStringToBSTR(*req->timeout()):SysAllocString(L""));

        request->put_PinpadType((PinpadType)*req->pinpad_type());

        request->put_IconName(req->icon_name()?Tool::Tools::ParseStringToBSTR(*req->icon_name()):SysAllocString(L""));

        return request;
    }

    const FormShowMessageCenterRequest* PluginShowMessageCenterRequest::get(_ShowMessageCenterRequest* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = FormShowMessageCenterRequest();

        BSTR title;
        rsp->get_Title(&title);
        response->set_title(Tool::Tools::ParseBSTRToString(title));

        BSTR message1;
        rsp->get_Message1(&message1);
        response->set_message1(Tool::Tools::ParseBSTRToString(message1));

        BSTR message2;
        rsp->get_Message2(&message2);
        response->set_message2(Tool::Tools::ParseBSTRToString(message2));

        BSTR timeout;
        rsp->get_Timeout(&timeout);
        response->set_timeout(Tool::Tools::ParseBSTRToString(timeout));

        PinpadType pinpadType;
        rsp->get_PinpadType(&pinpadType);
        response->set_pinpad_type((FormPinpadType)pinpadType);

        BSTR iconName;
        rsp->get_IconName(&iconName);
        response->set_icon_name(Tool::Tools::ParseBSTRToString(iconName));

        return &(*response);
    }
}
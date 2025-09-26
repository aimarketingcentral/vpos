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
#include "PluginShowDialogRequest.h"

namespace POSLinkForm{
    PluginShowDialogRequest::PluginShowDialogRequest(){}

    _ShowDialogRequest* PluginShowDialogRequest::set(const std::optional<FormShowDialogRequest>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidShowDialogRequest;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Form.ShowDialogRequest"),&clsidShowDialogRequest);
        request = NULL;
        request.CoCreateInstance(clsidShowDialogRequest);

        request->put_Title(req->title()?Tool::Tools::ParseStringToBSTR(*req->title()):SysAllocString(L""));

        PluginSdButton button1;
        request->putref_Button1(button1.set(req->button1() ? std::optional<const FormSdButton>(*req->button1()) : std::nullopt));

        PluginSdButton button2;
        request->putref_Button2(button2.set(req->button2() ? std::optional<const FormSdButton>(*req->button2()) : std::nullopt));

        PluginSdButton button3;
        request->putref_Button3(button3.set(req->button3() ? std::optional<const FormSdButton>(*req->button3()) : std::nullopt));

        PluginSdButton button4;
        request->putref_Button4(button4.set(req->button4() ? std::optional<const FormSdButton>(*req->button4()) : std::nullopt));

        request->put_Timeout(req->timeout()?Tool::Tools::ParseStringToBSTR(*req->timeout()):SysAllocString(L""));

        request->put_ContinuousScreen((ContinuousScreen)*req->continuous_screen());

        return request;
    }

    const FormShowDialogRequest* PluginShowDialogRequest::get(_ShowDialogRequest* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = FormShowDialogRequest();

        BSTR title;
        rsp->get_Title(&title);
        response->set_title(Tool::Tools::ParseBSTRToString(title));

        CComPtr<_SdButton> comButton1 = NULL;
        rsp->get_Button1(&comButton1);
        PluginSdButton button1;
        response->set_button1(button1.get(comButton1)? button1.get(comButton1): nullptr);

        CComPtr<_SdButton> comButton2 = NULL;
        rsp->get_Button2(&comButton2);
        PluginSdButton button2;
        response->set_button2(button2.get(comButton2)? button2.get(comButton2): nullptr);

        CComPtr<_SdButton> comButton3 = NULL;
        rsp->get_Button3(&comButton3);
        PluginSdButton button3;
        response->set_button3(button3.get(comButton3)? button3.get(comButton3): nullptr);

        CComPtr<_SdButton> comButton4 = NULL;
        rsp->get_Button4(&comButton4);
        PluginSdButton button4;
        response->set_button4(button4.get(comButton4)? button4.get(comButton4): nullptr);

        BSTR timeout;
        rsp->get_Timeout(&timeout);
        response->set_timeout(Tool::Tools::ParseBSTRToString(timeout));

        ContinuousScreen continuousScreen;
        rsp->get_ContinuousScreen(&continuousScreen);
        response->set_continuous_screen((FormContinuousScreen)continuousScreen);

        return &(*response);
    }
}
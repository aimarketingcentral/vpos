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
#include "PluginShowDialogFormRequest.h"

namespace POSLinkForm{
    PluginShowDialogFormRequest::PluginShowDialogFormRequest(){}

    _ShowDialogFormRequest* PluginShowDialogFormRequest::set(const std::optional<FormShowDialogFormRequest>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidShowDialogFormRequest;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Form.ShowDialogFormRequest"),&clsidShowDialogFormRequest);
        request = NULL;
        request.CoCreateInstance(clsidShowDialogFormRequest);

        request->put_Title(req->title()?Tool::Tools::ParseStringToBSTR(*req->title()):SysAllocString(L""));

        request->put_Label1(req->label1()?Tool::Tools::ParseStringToBSTR(*req->label1()):SysAllocString(L""));

        request->put_Label1Property((LabelProperty)*req->label1_property());

        request->put_Label2(req->label2()?Tool::Tools::ParseStringToBSTR(*req->label2()):SysAllocString(L""));

        request->put_Label2Property((LabelProperty)*req->label2_property());

        request->put_Label3(req->label3()?Tool::Tools::ParseStringToBSTR(*req->label3()):SysAllocString(L""));

        request->put_Label3Property((LabelProperty)*req->label3_property());

        request->put_Label4(req->label4()?Tool::Tools::ParseStringToBSTR(*req->label4()):SysAllocString(L""));

        request->put_Label4Property((LabelProperty)*req->label4_property());

        request->put_ButtonType((ButtonType)*req->button_type());

        request->put_Timeout(req->timeout()?Tool::Tools::ParseStringToBSTR(*req->timeout()):SysAllocString(L""));

        request->put_ContinuousScreen((ContinuousScreen)*req->continuous_screen());

        return request;
    }

    const FormShowDialogFormRequest* PluginShowDialogFormRequest::get(_ShowDialogFormRequest* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = FormShowDialogFormRequest();

        BSTR title;
        rsp->get_Title(&title);
        response->set_title(Tool::Tools::ParseBSTRToString(title));

        BSTR label1;
        rsp->get_Label1(&label1);
        response->set_label1(Tool::Tools::ParseBSTRToString(label1));

        LabelProperty label1Property;
        rsp->get_Label1Property(&label1Property);
        response->set_label1_property((FormLabelProperty)label1Property);

        BSTR label2;
        rsp->get_Label2(&label2);
        response->set_label2(Tool::Tools::ParseBSTRToString(label2));

        LabelProperty label2Property;
        rsp->get_Label2Property(&label2Property);
        response->set_label2_property((FormLabelProperty)label2Property);

        BSTR label3;
        rsp->get_Label3(&label3);
        response->set_label3(Tool::Tools::ParseBSTRToString(label3));

        LabelProperty label3Property;
        rsp->get_Label3Property(&label3Property);
        response->set_label3_property((FormLabelProperty)label3Property);

        BSTR label4;
        rsp->get_Label4(&label4);
        response->set_label4(Tool::Tools::ParseBSTRToString(label4));

        LabelProperty label4Property;
        rsp->get_Label4Property(&label4Property);
        response->set_label4_property((FormLabelProperty)label4Property);

        ButtonType buttonType;
        rsp->get_ButtonType(&buttonType);
        response->set_button_type((FormButtonType)buttonType);

        BSTR timeout;
        rsp->get_Timeout(&timeout);
        response->set_timeout(Tool::Tools::ParseBSTRToString(timeout));

        ContinuousScreen continuousScreen;
        rsp->get_ContinuousScreen(&continuousScreen);
        response->set_continuous_screen((FormContinuousScreen)continuousScreen);

        return &(*response);
    }
}
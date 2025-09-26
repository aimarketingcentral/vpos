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
#include "PluginShowTextBoxRequest.h"

namespace POSLinkForm{
    PluginShowTextBoxRequest::PluginShowTextBoxRequest(){}

    _ShowTextBoxRequest* PluginShowTextBoxRequest::set(const std::optional<FormShowTextBoxRequest>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidShowTextBoxRequest;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Form.ShowTextBoxRequest"),&clsidShowTextBoxRequest);
        request = NULL;
        request.CoCreateInstance(clsidShowTextBoxRequest);

        request->put_Title(req->title()?Tool::Tools::ParseStringToBSTR(*req->title()):SysAllocString(L""));

        request->put_Text(req->text()?Tool::Tools::ParseStringToBSTR(*req->text()):SysAllocString(L""));

        PluginStbButton button1;
        request->putref_Button1(button1.set(req->button1() ? std::optional<const FormStbButton>(*req->button1()) : std::nullopt));

        PluginStbButton button2;
        request->putref_Button2(button2.set(req->button2() ? std::optional<const FormStbButton>(*req->button2()) : std::nullopt));

        PluginStbButton button3;
        request->putref_Button3(button3.set(req->button3() ? std::optional<const FormStbButton>(*req->button3()) : std::nullopt));

        request->put_Timeout(req->timeout()?Tool::Tools::ParseStringToBSTR(*req->timeout()):SysAllocString(L""));

        request->put_EnableKeyType((EnableKeyType)*req->enable_key_type());

        //HardKeyList: It is not support for Array now

        request->put_SignatureBox((SignatureBoxType)*req->signature_box());

        request->put_ContinuousScreen((ContinuousScreen)*req->continuous_screen());

        request->put_BarcodeName((BarcodeName)*req->barcode_name());

        request->put_BarcodeData(req->barcode_data()?Tool::Tools::ParseStringToBSTR(*req->barcode_data()):SysAllocString(L""));

        request->put_InputTextTitle(req->input_text_title()?Tool::Tools::ParseStringToBSTR(*req->input_text_title()):SysAllocString(L""));

        request->put_InputText((InputTextType)*req->input_text());

        request->put_InputType((InputType)*req->input_type());

        request->put_MinLength(req->min_length()?Tool::Tools::ParseStringToBSTR(*req->min_length()):SysAllocString(L""));

        request->put_MaxLength(req->max_length()?Tool::Tools::ParseStringToBSTR(*req->max_length()):SysAllocString(L""));

        return request;
    }

    const FormShowTextBoxRequest* PluginShowTextBoxRequest::get(_ShowTextBoxRequest* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = FormShowTextBoxRequest();

        BSTR title;
        rsp->get_Title(&title);
        response->set_title(Tool::Tools::ParseBSTRToString(title));

        BSTR text;
        rsp->get_Text(&text);
        response->set_text(Tool::Tools::ParseBSTRToString(text));

        CComPtr<_StbButton> comButton1 = NULL;
        rsp->get_Button1(&comButton1);
        PluginStbButton button1;
        response->set_button1(button1.get(comButton1)? button1.get(comButton1): nullptr);

        CComPtr<_StbButton> comButton2 = NULL;
        rsp->get_Button2(&comButton2);
        PluginStbButton button2;
        response->set_button2(button2.get(comButton2)? button2.get(comButton2): nullptr);

        CComPtr<_StbButton> comButton3 = NULL;
        rsp->get_Button3(&comButton3);
        PluginStbButton button3;
        response->set_button3(button3.get(comButton3)? button3.get(comButton3): nullptr);

        BSTR timeout;
        rsp->get_Timeout(&timeout);
        response->set_timeout(Tool::Tools::ParseBSTRToString(timeout));

        EnableKeyType enableKeyType;
        rsp->get_EnableKeyType(&enableKeyType);
        response->set_enable_key_type((FormEnableKeyType)enableKeyType);

        //HardKeyList: It is not support for Array now

        SignatureBoxType signatureBox;
        rsp->get_SignatureBox(&signatureBox);
        response->set_signature_box((FormSignatureBoxType)signatureBox);

        ContinuousScreen continuousScreen;
        rsp->get_ContinuousScreen(&continuousScreen);
        response->set_continuous_screen((FormContinuousScreen)continuousScreen);

        BarcodeName barcodeName;
        rsp->get_BarcodeName(&barcodeName);
        response->set_barcode_name((FormBarcodeName)barcodeName);

        BSTR barcodeData;
        rsp->get_BarcodeData(&barcodeData);
        response->set_barcode_data(Tool::Tools::ParseBSTRToString(barcodeData));

        BSTR inputTextTitle;
        rsp->get_InputTextTitle(&inputTextTitle);
        response->set_input_text_title(Tool::Tools::ParseBSTRToString(inputTextTitle));

        InputTextType inputText;
        rsp->get_InputText(&inputText);
        response->set_input_text((FormInputTextType)inputText);

        InputType inputType;
        rsp->get_InputType(&inputType);
        response->set_input_type((FormInputType)inputType);

        BSTR minLength;
        rsp->get_MinLength(&minLength);
        response->set_min_length(Tool::Tools::ParseBSTRToString(minLength));

        BSTR maxLength;
        rsp->get_MaxLength(&maxLength);
        response->set_max_length(Tool::Tools::ParseBSTRToString(maxLength));

        return &(*response);
    }
}
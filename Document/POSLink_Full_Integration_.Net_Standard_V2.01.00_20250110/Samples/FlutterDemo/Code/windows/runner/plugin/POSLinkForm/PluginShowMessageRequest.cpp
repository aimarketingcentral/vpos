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
#include "PluginShowMessageRequest.h"

namespace POSLinkForm{
    PluginShowMessageRequest::PluginShowMessageRequest(){}

    _ShowMessageRequest* PluginShowMessageRequest::set(const std::optional<FormShowMessageRequest>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidShowMessageRequest;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Form.ShowMessageRequest"),&clsidShowMessageRequest);
        request = NULL;
        request.CoCreateInstance(clsidShowMessageRequest);

        request->put_DisplayMessage1(req->display_message1()?Tool::Tools::ParseStringToBSTR(*req->display_message1()):SysAllocString(L""));

        request->put_Title(req->title()?Tool::Tools::ParseStringToBSTR(*req->title()):SysAllocString(L""));

        request->put_DisplayMessage2(req->display_message2()?Tool::Tools::ParseStringToBSTR(*req->display_message2()):SysAllocString(L""));

        request->put_TextPushedMode((TextPushedMode)*req->text_pushed_mode());

        request->put_TaxLine(req->tax_line()?Tool::Tools::ParseStringToBSTR(*req->tax_line()):SysAllocString(L""));

        request->put_TotalLine(req->total_line()?Tool::Tools::ParseStringToBSTR(*req->total_line()):SysAllocString(L""));

        request->put_ImageName(req->image_name()?Tool::Tools::ParseStringToBSTR(*req->image_name()):SysAllocString(L""));

        request->put_ImageDescription(req->image_description()?Tool::Tools::ParseStringToBSTR(*req->image_description()):SysAllocString(L""));

        request->put_LineItemAction((LineItemAction)*req->line_item_action());

        if(req->item_indices())
        {
            flutter::EncodableList tmpEnList = *req->item_indices();
            SAFEARRAY *psa;
            SAFEARRAYBOUND rgsabound[1];
            rgsabound[0].cElements = (ULONG)(tmpEnList.size());
            rgsabound[0].lLbound = 0;
            psa = SafeArrayCreate(VT_BSTR, 1, rgsabound);
            long i=0;
            for(flutter::EncodableList::iterator i_data = tmpEnList.begin(); i_data != tmpEnList.end(); i_data++)
            {
                flutter::EncodableValue tmpEnValue = *i_data;
                std::string tmpItemIndices = std::get<std::string>(tmpEnValue);
                BSTR comItemIndices = Tool::Tools::ParseStringToBSTR(tmpItemIndices);
                SafeArrayPutElement(psa, &i, comItemIndices);
                i++;
            }
            request->put_ItemIndices(psa);
            SafeArrayUnaccessData(psa);
        }

        return request;
    }

    const FormShowMessageRequest* PluginShowMessageRequest::get(_ShowMessageRequest* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = FormShowMessageRequest();

        BSTR displayMessage1;
        rsp->get_DisplayMessage1(&displayMessage1);
        response->set_display_message1(Tool::Tools::ParseBSTRToString(displayMessage1));

        BSTR title;
        rsp->get_Title(&title);
        response->set_title(Tool::Tools::ParseBSTRToString(title));

        BSTR displayMessage2;
        rsp->get_DisplayMessage2(&displayMessage2);
        response->set_display_message2(Tool::Tools::ParseBSTRToString(displayMessage2));

        TextPushedMode textPushedMode;
        rsp->get_TextPushedMode(&textPushedMode);
        response->set_text_pushed_mode((FormTextPushedMode)textPushedMode);

        BSTR taxLine;
        rsp->get_TaxLine(&taxLine);
        response->set_tax_line(Tool::Tools::ParseBSTRToString(taxLine));

        BSTR totalLine;
        rsp->get_TotalLine(&totalLine);
        response->set_total_line(Tool::Tools::ParseBSTRToString(totalLine));

        BSTR imageName;
        rsp->get_ImageName(&imageName);
        response->set_image_name(Tool::Tools::ParseBSTRToString(imageName));

        BSTR imageDescription;
        rsp->get_ImageDescription(&imageDescription);
        response->set_image_description(Tool::Tools::ParseBSTRToString(imageDescription));

        LineItemAction lineItemAction;
        rsp->get_LineItemAction(&lineItemAction);
        response->set_line_item_action((FormLineItemAction)lineItemAction);

        SAFEARRAY* psaItemIndices = NULL;
        rsp->get_ItemIndices(&psaItemIndices);
        if(psaItemIndices)
        {
            BSTR* bstrData;
            SafeArrayAccessData(psaItemIndices, (void**)&bstrData);
            flutter::EncodableList listItemIndices;
            for(ULONG i = 0; i < psaItemIndices->rgsabound->cElements; i++)
            {
                if(bstrData[i])
                {
                    std::string tmp = Tool::Tools::ParseBSTRToString(bstrData[i]);
                    flutter::EncodableValue tmpValue(tmp);
                    listItemIndices.push_back(tmpValue);
                }
            }
            response->set_item_indices(listItemIndices);
            SafeArrayUnaccessData(psaItemIndices);
        }

        return &(*response);
    }
}
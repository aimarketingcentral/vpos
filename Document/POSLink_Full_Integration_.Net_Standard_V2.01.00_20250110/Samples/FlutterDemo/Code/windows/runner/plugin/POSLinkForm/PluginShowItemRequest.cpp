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
#include "PluginShowItemRequest.h"

namespace POSLinkForm{
    PluginShowItemRequest::PluginShowItemRequest(){}

    _ShowItemRequest* PluginShowItemRequest::set(const std::optional<FormShowItemRequest>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidShowItemRequest;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Form.ShowItemRequest"),&clsidShowItemRequest);
        request = NULL;
        request.CoCreateInstance(clsidShowItemRequest);

        request->put_Title(req->title()?Tool::Tools::ParseStringToBSTR(*req->title()):SysAllocString(L""));

        request->put_TextPushedMode((TextPushedMode)*req->text_pushed_mode());

        request->put_TaxLine(req->tax_line()?Tool::Tools::ParseStringToBSTR(*req->tax_line()):SysAllocString(L""));

        request->put_TotalLine(req->total_line()?Tool::Tools::ParseStringToBSTR(*req->total_line()):SysAllocString(L""));

        if(req->item_details())
        {
            flutter::EncodableList tmpEnList = *req->item_details();
            SAFEARRAY *psa;
            SAFEARRAYBOUND rgsabound[1];
            rgsabound[0].cElements = (ULONG)(tmpEnList.size());
            rgsabound[0].lLbound = 0;
            psa = SafeArrayCreate(VT_UNKNOWN, 1, rgsabound);
            long i=0;
            for(flutter::EncodableList::iterator i_data = tmpEnList.begin(); i_data != tmpEnList.end(); i_data++)
            {
                flutter::EncodableValue tmpEnValue = *i_data;
                std::any& tmpCustomValue = std::get<flutter::CustomEncodableValue>(tmpEnValue);
                FormItemDetail formItemDetail = std::any_cast<FormItemDetail>(tmpCustomValue);
                CComPtr<_ItemDetail> comItemDetail = NULL;
                PluginItemDetail pluginItemDetail;
                comItemDetail = pluginItemDetail.set(formItemDetail);
                SafeArrayPutElement(psa, &i, comItemDetail);
                i++;
            }
            request->put_ItemDetails(psa);
            SafeArrayUnaccessData(psa);
        }

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

    const FormShowItemRequest* PluginShowItemRequest::get(_ShowItemRequest* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = FormShowItemRequest();

        BSTR title;
        rsp->get_Title(&title);
        response->set_title(Tool::Tools::ParseBSTRToString(title));

        TextPushedMode textPushedMode;
        rsp->get_TextPushedMode(&textPushedMode);
        response->set_text_pushed_mode((FormTextPushedMode)textPushedMode);

        BSTR taxLine;
        rsp->get_TaxLine(&taxLine);
        response->set_tax_line(Tool::Tools::ParseBSTRToString(taxLine));

        BSTR totalLine;
        rsp->get_TotalLine(&totalLine);
        response->set_total_line(Tool::Tools::ParseBSTRToString(totalLine));

        SAFEARRAY* psaItemDetails = NULL;
        rsp->get_ItemDetails(&psaItemDetails);
        if(psaItemDetails)
        {
            CComPtr<_ItemDetail>* bstrData;
            SafeArrayAccessData(psaItemDetails, (void**)&bstrData);
            PluginItemDetail pluginItemDetail;
            flutter::EncodableList listItemDetails;
            for(ULONG i = 0; i < psaItemDetails->rgsabound->cElements; i++)
            {
                if(pluginItemDetail.get(bstrData[i]))
                {
                    FormItemDetail tmp = *pluginItemDetail.get(bstrData[i]);
                    flutter::CustomEncodableValue CustomValue(tmp);
                    flutter::EncodableValue tmpValue(CustomValue);
                    listItemDetails.push_back(tmpValue);
                }
            }
            response->set_item_details(listItemDetails);
            SafeArrayUnaccessData(psaItemDetails);
        }

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
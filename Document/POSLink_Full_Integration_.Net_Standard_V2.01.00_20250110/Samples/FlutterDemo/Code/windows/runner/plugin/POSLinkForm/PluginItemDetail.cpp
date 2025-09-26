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
#include "PluginItemDetail.h"

namespace POSLinkForm{
    PluginItemDetail::PluginItemDetail(){}

    _ItemDetail* PluginItemDetail::set(const std::optional<FormItemDetail>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidItemDetail;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Util.ItemDetail"),&clsidItemDetail);
        request = NULL;
        request.CoCreateInstance(clsidItemDetail);

        request->put_ProductName(req->product_name()?Tool::Tools::ParseStringToBSTR(*req->product_name()):SysAllocString(L""));

        request->put_PluCode(req->plu_code()?Tool::Tools::ParseStringToBSTR(*req->plu_code()):SysAllocString(L""));

        request->put_Price(req->price()?Tool::Tools::ParseStringToBSTR(*req->price()):SysAllocString(L""));

        request->put_Unit((ItemDetailUnit)*req->unit());

        request->put_UnitPrice(req->unit_price()?Tool::Tools::ParseStringToBSTR(*req->unit_price()):SysAllocString(L""));

        request->put_Tax(req->tax()?Tool::Tools::ParseStringToBSTR(*req->tax()):SysAllocString(L""));

        request->put_Quantity(req->quantity()?Tool::Tools::ParseStringToBSTR(*req->quantity()):SysAllocString(L""));

        request->put_ProductImageName(req->product_image_name()?Tool::Tools::ParseStringToBSTR(*req->product_image_name()):SysAllocString(L""));

        request->put_ProductImageDescription(req->product_image_description()?Tool::Tools::ParseStringToBSTR(*req->product_image_description()):SysAllocString(L""));

        return request;
    }

    const FormItemDetail* PluginItemDetail::get(_ItemDetail* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = FormItemDetail();

        BSTR productName;
        rsp->get_ProductName(&productName);
        response->set_product_name(Tool::Tools::ParseBSTRToString(productName));

        BSTR pluCode;
        rsp->get_PluCode(&pluCode);
        response->set_plu_code(Tool::Tools::ParseBSTRToString(pluCode));

        BSTR price;
        rsp->get_Price(&price);
        response->set_price(Tool::Tools::ParseBSTRToString(price));

        ItemDetailUnit unit;
        rsp->get_Unit(&unit);
        response->set_unit((FormItemDetailUnit)unit);

        BSTR unitPrice;
        rsp->get_UnitPrice(&unitPrice);
        response->set_unit_price(Tool::Tools::ParseBSTRToString(unitPrice));

        BSTR tax;
        rsp->get_Tax(&tax);
        response->set_tax(Tool::Tools::ParseBSTRToString(tax));

        BSTR quantity;
        rsp->get_Quantity(&quantity);
        response->set_quantity(Tool::Tools::ParseBSTRToString(quantity));

        BSTR productImageName;
        rsp->get_ProductImageName(&productImageName);
        response->set_product_image_name(Tool::Tools::ParseBSTRToString(productImageName));

        BSTR productImageDescription;
        rsp->get_ProductImageDescription(&productImageDescription);
        response->set_product_image_description(Tool::Tools::ParseBSTRToString(productImageDescription));

        return &(*response);
    }
}
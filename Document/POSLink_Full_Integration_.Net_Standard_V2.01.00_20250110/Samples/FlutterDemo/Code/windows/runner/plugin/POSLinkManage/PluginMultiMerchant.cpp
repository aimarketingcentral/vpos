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
#include "PluginMultiMerchant.h"

namespace POSLinkManage{
    PluginMultiMerchant::PluginMultiMerchant(){}

    _MultiMerchant* PluginMultiMerchant::set(const std::optional<ManageMultiMerchant>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidMultiMerchant;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Util.MultiMerchant"),&clsidMultiMerchant);
        request = NULL;
        request.CoCreateInstance(clsidMultiMerchant);

        request->put_MultiMerchantId(req->multi_merchant_id()?Tool::Tools::ParseStringToBSTR(*req->multi_merchant_id()):SysAllocString(L""));

        request->put_MultiMerchantName(req->multi_merchant_name()?Tool::Tools::ParseStringToBSTR(*req->multi_merchant_name()):SysAllocString(L""));

        return request;
    }

    const ManageMultiMerchant* PluginMultiMerchant::get(_MultiMerchant* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = ManageMultiMerchant();

        BSTR multiMerchantId;
        rsp->get_MultiMerchantId(&multiMerchantId);
        response->set_multi_merchant_id(Tool::Tools::ParseBSTRToString(multiMerchantId));

        BSTR multiMerchantName;
        rsp->get_MultiMerchantName(&multiMerchantName);
        response->set_multi_merchant_name(Tool::Tools::ParseBSTRToString(multiMerchantName));

        return &(*response);
    }
}
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
#include "PluginApplePayVas.h"

namespace POSLinkManage{
    PluginApplePayVas::PluginApplePayVas(){}

    _ApplePayVas* PluginApplePayVas::set(const std::optional<ManageApplePayVas>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidApplePayVas;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Manage.ApplePayVas"),&clsidApplePayVas);
        request = NULL;
        request.CoCreateInstance(clsidApplePayVas);

        request->put_MerchantId(req->merchant_id()?Tool::Tools::ParseStringToBSTR(*req->merchant_id()):SysAllocString(L""));

        request->put_UrlMode((UrlMode)*req->url_mode());

        request->put_Url(req->url()?Tool::Tools::ParseStringToBSTR(*req->url()):SysAllocString(L""));

        if(req->key_file_mapping())
        {
            flutter::EncodableList tmpEnList = *req->key_file_mapping();
            SAFEARRAY *psa;
            SAFEARRAYBOUND rgsabound[1];
            rgsabound[0].cElements = (ULONG)(tmpEnList.size());
            rgsabound[0].lLbound = 0;
            psa = SafeArrayCreate(VT_BSTR, 1, rgsabound);
            long i=0;
            for(flutter::EncodableList::iterator i_data = tmpEnList.begin(); i_data != tmpEnList.end(); i_data++)
            {
                flutter::EncodableValue tmpEnValue = *i_data;
                std::string tmpKeyFileMapping = std::get<std::string>(tmpEnValue);
                BSTR comKeyFileMapping = Tool::Tools::ParseStringToBSTR(tmpKeyFileMapping);
                SafeArrayPutElement(psa, &i, comKeyFileMapping);
                i++;
            }
            request->put_KeyFileMapping(psa);
            SafeArrayUnaccessData(psa);
        }

        return request;
    }

    const ManageApplePayVas* PluginApplePayVas::get(_ApplePayVas* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = ManageApplePayVas();

        BSTR merchantId;
        rsp->get_MerchantId(&merchantId);
        response->set_merchant_id(Tool::Tools::ParseBSTRToString(merchantId));

        UrlMode urlMode;
        rsp->get_UrlMode(&urlMode);
        response->set_url_mode((ManageUrlMode)urlMode);

        BSTR url;
        rsp->get_Url(&url);
        response->set_url(Tool::Tools::ParseBSTRToString(url));

        SAFEARRAY* psaKeyFileMapping = NULL;
        rsp->get_KeyFileMapping(&psaKeyFileMapping);
        if(psaKeyFileMapping)
        {
            BSTR* bstrData;
            SafeArrayAccessData(psaKeyFileMapping, (void**)&bstrData);
            flutter::EncodableList listKeyFileMapping;
            for(ULONG i = 0; i < psaKeyFileMapping->rgsabound->cElements; i++)
            {
                if(bstrData[i])
                {
                    std::string tmp = Tool::Tools::ParseBSTRToString(bstrData[i]);
                    flutter::EncodableValue tmpValue(tmp);
                    listKeyFileMapping.push_back(tmpValue);
                }
            }
            response->set_key_file_mapping(listKeyFileMapping);
            SafeArrayUnaccessData(psaKeyFileMapping);
        }

        return &(*response);
    }
}
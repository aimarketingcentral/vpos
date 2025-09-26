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
#include "PluginVasResponse.h"

namespace POSLinkFullIntegration{
    PluginVasResponse::PluginVasResponse(){}

    _VasResponse* PluginVasResponse::set(const std::optional<FullIntegrationVasResponse>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidVasResponse;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Util.VasResponse"),&clsidVasResponse);
        request = NULL;
        request.CoCreateInstance(clsidVasResponse);

        request->put_VasCode((VasResponseCode)*req->vas_code());

        if(req->vas_data())
        {
            flutter::EncodableList tmpEnList = *req->vas_data();
            SAFEARRAY *psa;
            SAFEARRAYBOUND rgsabound[1];
            rgsabound[0].cElements = (ULONG)(tmpEnList.size());
            rgsabound[0].lLbound = 0;
            psa = SafeArrayCreate(VT_BSTR, 1, rgsabound);
            long i=0;
            for(flutter::EncodableList::iterator i_data = tmpEnList.begin(); i_data != tmpEnList.end(); i_data++)
            {
                flutter::EncodableValue tmpEnValue = *i_data;
                std::string tmpVasData = std::get<std::string>(tmpEnValue);
                BSTR comVasData = Tool::Tools::ParseStringToBSTR(tmpVasData);
                SafeArrayPutElement(psa, &i, comVasData);
                i++;
            }
            request->put_VasData(psa);
            SafeArrayUnaccessData(psa);
        }

        request->put_NdefData(req->ndef_data()?Tool::Tools::ParseStringToBSTR(*req->ndef_data()):SysAllocString(L""));

        return request;
    }

    const FullIntegrationVasResponse* PluginVasResponse::get(_VasResponse* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = FullIntegrationVasResponse();

        VasResponseCode vasCode;
        rsp->get_VasCode(&vasCode);
        response->set_vas_code((FullIntegrationVasResponseCode)vasCode);

        SAFEARRAY* psaVasData = NULL;
        rsp->get_VasData(&psaVasData);
        if(psaVasData)
        {
            BSTR* bstrData;
            SafeArrayAccessData(psaVasData, (void**)&bstrData);
            flutter::EncodableList listVasData;
            for(ULONG i = 0; i < psaVasData->rgsabound->cElements; i++)
            {
                if(bstrData[i])
                {
                    std::string tmp = Tool::Tools::ParseBSTRToString(bstrData[i]);
                    flutter::EncodableValue tmpValue(tmp);
                    listVasData.push_back(tmpValue);
                }
            }
            response->set_vas_data(listVasData);
            SafeArrayUnaccessData(psaVasData);
        }

        BSTR ndefData;
        rsp->get_NdefData(&ndefData);
        response->set_ndef_data(Tool::Tools::ParseBSTRToString(ndefData));

        return &(*response);
    }
}
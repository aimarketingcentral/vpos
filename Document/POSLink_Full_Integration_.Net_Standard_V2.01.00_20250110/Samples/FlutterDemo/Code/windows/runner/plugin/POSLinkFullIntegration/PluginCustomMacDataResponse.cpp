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
#include "PluginCustomMacDataResponse.h"

namespace POSLinkFullIntegration{
    PluginCustomMacDataResponse::PluginCustomMacDataResponse(){}

    _CustomMacDataResponse* PluginCustomMacDataResponse::set(const std::optional<FullIntegrationCustomMacDataResponse>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidCustomMacDataResponse;
        CLSIDFromProgID(OLESTR("POSLinkFullIntegration.Util.CustomMacDataResponse"),&clsidCustomMacDataResponse);
        request = NULL;
        request.CoCreateInstance(clsidCustomMacDataResponse);

        if(req->data())
        {
            flutter::EncodableList tmpEnList = *req->data();
            SAFEARRAY *psa;
            SAFEARRAYBOUND rgsabound[1];
            rgsabound[0].cElements = (ULONG)(tmpEnList.size());
            rgsabound[0].lLbound = 0;
            psa = SafeArrayCreate(VT_BSTR, 1, rgsabound);
            long i=0;
            for(flutter::EncodableList::iterator i_data = tmpEnList.begin(); i_data != tmpEnList.end(); i_data++)
            {
                flutter::EncodableValue tmpEnValue = *i_data;
                std::string tmpData = std::get<std::string>(tmpEnValue);
                BSTR comData = Tool::Tools::ParseStringToBSTR(tmpData);
                SafeArrayPutElement(psa, &i, comData);
                i++;
            }
            request->put_Data(psa);
            SafeArrayUnaccessData(psa);
        }

        request->put_Ksn(req->ksn()?Tool::Tools::ParseStringToBSTR(*req->ksn()):SysAllocString(L""));

        return request;
    }

    const FullIntegrationCustomMacDataResponse* PluginCustomMacDataResponse::get(_CustomMacDataResponse* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = FullIntegrationCustomMacDataResponse();

        SAFEARRAY* psaData = NULL;
        rsp->get_Data(&psaData);
        if(psaData)
        {
            BSTR* bstrData;
            SafeArrayAccessData(psaData, (void**)&bstrData);
            flutter::EncodableList listData;
            for(ULONG i = 0; i < psaData->rgsabound->cElements; i++)
            {
                if(bstrData[i])
                {
                    std::string tmp = Tool::Tools::ParseBSTRToString(bstrData[i]);
                    flutter::EncodableValue tmpValue(tmp);
                    listData.push_back(tmpValue);
                }
            }
            response->set_data(listData);
            SafeArrayUnaccessData(psaData);
        }

        BSTR ksn;
        rsp->get_Ksn(&ksn);
        response->set_ksn(Tool::Tools::ParseBSTRToString(ksn));

        return &(*response);
    }
}
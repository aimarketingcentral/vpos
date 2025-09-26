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
#include "PluginCustomMacInformationRequest.h"

namespace POSLinkFullIntegration{
    PluginCustomMacInformationRequest::PluginCustomMacInformationRequest(){}

    _CustomMacInformationRequest* PluginCustomMacInformationRequest::set(const std::optional<FullIntegrationCustomMacInformationRequest>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidCustomMacInformationRequest;
        CLSIDFromProgID(OLESTR("POSLinkFullIntegration.Util.CustomMacInformationRequest"),&clsidCustomMacInformationRequest);
        request = NULL;
        request.CoCreateInstance(clsidCustomMacInformationRequest);

        request->put_KeyType((MacKeyType)*req->key_type());

        request->put_WorkMode((MacWorkMode)*req->work_mode());

        request->put_KeySlot(req->key_slot()?Tool::Tools::ParseStringToBSTR(*req->key_slot()):SysAllocString(L""));

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

        return request;
    }

    const FullIntegrationCustomMacInformationRequest* PluginCustomMacInformationRequest::get(_CustomMacInformationRequest* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = FullIntegrationCustomMacInformationRequest();

        MacKeyType keyType;
        rsp->get_KeyType(&keyType);
        response->set_key_type((FullIntegrationMacKeyType)keyType);

        MacWorkMode workMode;
        rsp->get_WorkMode(&workMode);
        response->set_work_mode((FullIntegrationMacWorkMode)workMode);

        BSTR keySlot;
        rsp->get_KeySlot(&keySlot);
        response->set_key_slot(Tool::Tools::ParseBSTRToString(keySlot));

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

        return &(*response);
    }
}
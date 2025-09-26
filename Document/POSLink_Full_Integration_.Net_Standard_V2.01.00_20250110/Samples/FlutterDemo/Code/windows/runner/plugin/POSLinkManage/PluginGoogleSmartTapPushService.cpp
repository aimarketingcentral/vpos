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
#include "PluginGoogleSmartTapPushService.h"

namespace POSLinkManage{
    PluginGoogleSmartTapPushService::PluginGoogleSmartTapPushService(){}

    _GoogleSmartTapPushService* PluginGoogleSmartTapPushService::set(const std::optional<ManageGoogleSmartTapPushService>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidGoogleSmartTapPushService;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Manage.GoogleSmartTapPushService"),&clsidGoogleSmartTapPushService);
        request = NULL;
        request.CoCreateInstance(clsidGoogleSmartTapPushService);

        request->put_Security((Security)*req->security());

        PluginGoogleSmartTapCapBitmap googleSmartTapCap;
        request->putref_GoogleSmartTapCap(googleSmartTapCap.set(req->google_smart_tap_cap() ? std::optional<const ManageGoogleSmartTapCapBitmap>(*req->google_smart_tap_cap()) : std::nullopt));

        request->put_CollectId(req->collect_id()?Tool::Tools::ParseStringToBSTR(*req->collect_id()):SysAllocString(L""));

        if(req->google_service_usage())
        {
            flutter::EncodableList tmpEnList = *req->google_service_usage();
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
                ManageServiceUsage manageServiceUsage = std::any_cast<ManageServiceUsage>(tmpCustomValue);
                CComPtr<_ServiceUsage> comServiceUsage = NULL;
                PluginServiceUsage pluginServiceUsage;
                comServiceUsage = pluginServiceUsage.set(manageServiceUsage);
                SafeArrayPutElement(psa, &i, comServiceUsage);
                i++;
            }
            request->put_GoogleServiceUsage(psa);
            SafeArrayUnaccessData(psa);
        }

        if(req->google_service_update())
        {
            flutter::EncodableList tmpEnList = *req->google_service_update();
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
                ManageServiceUpdate manageServiceUpdate = std::any_cast<ManageServiceUpdate>(tmpCustomValue);
                CComPtr<_ServiceUpdate> comServiceUpdate = NULL;
                PluginServiceUpdate pluginServiceUpdate;
                comServiceUpdate = pluginServiceUpdate.set(manageServiceUpdate);
                SafeArrayPutElement(psa, &i, comServiceUpdate);
                i++;
            }
            request->put_GoogleServiceUpdate(psa);
            SafeArrayUnaccessData(psa);
        }

        if(req->google_new_service())
        {
            flutter::EncodableList tmpEnList = *req->google_new_service();
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
                ManageNewService manageNewService = std::any_cast<ManageNewService>(tmpCustomValue);
                CComPtr<_NewService> comNewService = NULL;
                PluginNewService pluginNewService;
                comNewService = pluginNewService.set(manageNewService);
                SafeArrayPutElement(psa, &i, comNewService);
                i++;
            }
            request->put_GoogleNewService(psa);
            SafeArrayUnaccessData(psa);
        }

        request->put_EndTap((EndTap)*req->end_tap());

        return request;
    }

    const ManageGoogleSmartTapPushService* PluginGoogleSmartTapPushService::get(_GoogleSmartTapPushService* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = ManageGoogleSmartTapPushService();

        Security security;
        rsp->get_Security(&security);
        response->set_security((ManageSecurity)security);

        CComPtr<_GoogleSmartTapCapBitmap> comGoogleSmartTapCap = NULL;
        rsp->get_GoogleSmartTapCap(&comGoogleSmartTapCap);
        PluginGoogleSmartTapCapBitmap googleSmartTapCap;
        response->set_google_smart_tap_cap(googleSmartTapCap.get(comGoogleSmartTapCap)? googleSmartTapCap.get(comGoogleSmartTapCap): nullptr);

        BSTR collectId;
        rsp->get_CollectId(&collectId);
        response->set_collect_id(Tool::Tools::ParseBSTRToString(collectId));

        SAFEARRAY* psaGoogleServiceUsage = NULL;
        rsp->get_GoogleServiceUsage(&psaGoogleServiceUsage);
        if(psaGoogleServiceUsage)
        {
            CComPtr<_ServiceUsage>* bstrData;
            SafeArrayAccessData(psaGoogleServiceUsage, (void**)&bstrData);
            PluginServiceUsage pluginServiceUsage;
            flutter::EncodableList listGoogleServiceUsage;
            for(ULONG i = 0; i < psaGoogleServiceUsage->rgsabound->cElements; i++)
            {
                if(pluginServiceUsage.get(bstrData[i]))
                {
                    ManageServiceUsage tmp = *pluginServiceUsage.get(bstrData[i]);
                    flutter::CustomEncodableValue CustomValue(tmp);
                    flutter::EncodableValue tmpValue(CustomValue);
                    listGoogleServiceUsage.push_back(tmpValue);
                }
            }
            response->set_google_service_usage(listGoogleServiceUsage);
            SafeArrayUnaccessData(psaGoogleServiceUsage);
        }

        SAFEARRAY* psaGoogleServiceUpdate = NULL;
        rsp->get_GoogleServiceUpdate(&psaGoogleServiceUpdate);
        if(psaGoogleServiceUpdate)
        {
            CComPtr<_ServiceUpdate>* bstrData;
            SafeArrayAccessData(psaGoogleServiceUpdate, (void**)&bstrData);
            PluginServiceUpdate pluginServiceUpdate;
            flutter::EncodableList listGoogleServiceUpdate;
            for(ULONG i = 0; i < psaGoogleServiceUpdate->rgsabound->cElements; i++)
            {
                if(pluginServiceUpdate.get(bstrData[i]))
                {
                    ManageServiceUpdate tmp = *pluginServiceUpdate.get(bstrData[i]);
                    flutter::CustomEncodableValue CustomValue(tmp);
                    flutter::EncodableValue tmpValue(CustomValue);
                    listGoogleServiceUpdate.push_back(tmpValue);
                }
            }
            response->set_google_service_update(listGoogleServiceUpdate);
            SafeArrayUnaccessData(psaGoogleServiceUpdate);
        }

        SAFEARRAY* psaGoogleNewService = NULL;
        rsp->get_GoogleNewService(&psaGoogleNewService);
        if(psaGoogleNewService)
        {
            CComPtr<_NewService>* bstrData;
            SafeArrayAccessData(psaGoogleNewService, (void**)&bstrData);
            PluginNewService pluginNewService;
            flutter::EncodableList listGoogleNewService;
            for(ULONG i = 0; i < psaGoogleNewService->rgsabound->cElements; i++)
            {
                if(pluginNewService.get(bstrData[i]))
                {
                    ManageNewService tmp = *pluginNewService.get(bstrData[i]);
                    flutter::CustomEncodableValue CustomValue(tmp);
                    flutter::EncodableValue tmpValue(CustomValue);
                    listGoogleNewService.push_back(tmpValue);
                }
            }
            response->set_google_new_service(listGoogleNewService);
            SafeArrayUnaccessData(psaGoogleNewService);
        }

        EndTap endTap;
        rsp->get_EndTap(&endTap);
        response->set_end_tap((ManageEndTap)endTap);

        return &(*response);
    }
}
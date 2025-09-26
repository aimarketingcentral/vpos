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
#include "PluginGetPedInformationResponse.h"

namespace POSLinkPed{
    PluginGetPedInformationResponse::PluginGetPedInformationResponse(){}

    _GetPedInformationResponse* PluginGetPedInformationResponse::set(const std::optional<PedGetPedInformationResponse>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidGetPedInformationResponse;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Ped.GetPedInformationResponse"),&clsidGetPedInformationResponse);
        request = NULL;
        request.CoCreateInstance(clsidGetPedInformationResponse);

        request->put_MasterAvailableKeySlotCount(req->master_available_key_slot_count()?Tool::Tools::ParseStringToBSTR(*req->master_available_key_slot_count()):SysAllocString(L""));

        request->put_SessionAvailableKeySlotCount(req->session_available_key_slot_count()?Tool::Tools::ParseStringToBSTR(*req->session_available_key_slot_count()):SysAllocString(L""));

        request->put_DukptAvailableKeySlotCount(req->dukpt_available_key_slot_count()?Tool::Tools::ParseStringToBSTR(*req->dukpt_available_key_slot_count()):SysAllocString(L""));

        request->put_AesDukptAvailableKeySlotCount(req->aes_dukpt_available_key_slot_count()?Tool::Tools::ParseStringToBSTR(*req->aes_dukpt_available_key_slot_count()):SysAllocString(L""));

        if(req->tmk())
        {
            flutter::EncodableList tmpEnList = *req->tmk();
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
                PedMasterSessionKeyInformation pedMasterSessionKeyInformation = std::any_cast<PedMasterSessionKeyInformation>(tmpCustomValue);
                CComPtr<_MasterSessionKeyInformation> comMasterSessionKeyInformation = NULL;
                PluginMasterSessionKeyInformation pluginMasterSessionKeyInformation;
                comMasterSessionKeyInformation = pluginMasterSessionKeyInformation.set(pedMasterSessionKeyInformation);
                SafeArrayPutElement(psa, &i, comMasterSessionKeyInformation);
                i++;
            }
            request->put_Tmk(psa);
            SafeArrayUnaccessData(psa);
        }

        if(req->tpk())
        {
            flutter::EncodableList tmpEnList = *req->tpk();
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
                PedMasterSessionKeyInformation pedMasterSessionKeyInformation = std::any_cast<PedMasterSessionKeyInformation>(tmpCustomValue);
                CComPtr<_MasterSessionKeyInformation> comMasterSessionKeyInformation = NULL;
                PluginMasterSessionKeyInformation pluginMasterSessionKeyInformation;
                comMasterSessionKeyInformation = pluginMasterSessionKeyInformation.set(pedMasterSessionKeyInformation);
                SafeArrayPutElement(psa, &i, comMasterSessionKeyInformation);
                i++;
            }
            request->put_Tpk(psa);
            SafeArrayUnaccessData(psa);
        }

        if(req->tak())
        {
            flutter::EncodableList tmpEnList = *req->tak();
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
                PedMasterSessionKeyInformation pedMasterSessionKeyInformation = std::any_cast<PedMasterSessionKeyInformation>(tmpCustomValue);
                CComPtr<_MasterSessionKeyInformation> comMasterSessionKeyInformation = NULL;
                PluginMasterSessionKeyInformation pluginMasterSessionKeyInformation;
                comMasterSessionKeyInformation = pluginMasterSessionKeyInformation.set(pedMasterSessionKeyInformation);
                SafeArrayPutElement(psa, &i, comMasterSessionKeyInformation);
                i++;
            }
            request->put_Tak(psa);
            SafeArrayUnaccessData(psa);
        }

        if(req->tdk())
        {
            flutter::EncodableList tmpEnList = *req->tdk();
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
                PedMasterSessionKeyInformation pedMasterSessionKeyInformation = std::any_cast<PedMasterSessionKeyInformation>(tmpCustomValue);
                CComPtr<_MasterSessionKeyInformation> comMasterSessionKeyInformation = NULL;
                PluginMasterSessionKeyInformation pluginMasterSessionKeyInformation;
                comMasterSessionKeyInformation = pluginMasterSessionKeyInformation.set(pedMasterSessionKeyInformation);
                SafeArrayPutElement(psa, &i, comMasterSessionKeyInformation);
                i++;
            }
            request->put_Tdk(psa);
            SafeArrayUnaccessData(psa);
        }

        if(req->dukpt_key())
        {
            flutter::EncodableList tmpEnList = *req->dukpt_key();
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
                PedDukptKeyInformation pedDukptKeyInformation = std::any_cast<PedDukptKeyInformation>(tmpCustomValue);
                CComPtr<_DukptKeyInformation> comDukptKeyInformation = NULL;
                PluginDukptKeyInformation pluginDukptKeyInformation;
                comDukptKeyInformation = pluginDukptKeyInformation.set(pedDukptKeyInformation);
                SafeArrayPutElement(psa, &i, comDukptKeyInformation);
                i++;
            }
            request->put_DukptKey(psa);
            SafeArrayUnaccessData(psa);
        }

        if(req->aes_dukpt_key())
        {
            flutter::EncodableList tmpEnList = *req->aes_dukpt_key();
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
                PedDukptKeyInformation pedDukptKeyInformation = std::any_cast<PedDukptKeyInformation>(tmpCustomValue);
                CComPtr<_DukptKeyInformation> comDukptKeyInformation = NULL;
                PluginDukptKeyInformation pluginDukptKeyInformation;
                comDukptKeyInformation = pluginDukptKeyInformation.set(pedDukptKeyInformation);
                SafeArrayPutElement(psa, &i, comDukptKeyInformation);
                i++;
            }
            request->put_AesDukptKey(psa);
            SafeArrayUnaccessData(psa);
        }

        return request;
    }

    const PedGetPedInformationResponse* PluginGetPedInformationResponse::get(_GetPedInformationResponse* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = PedGetPedInformationResponse();

        BSTR responseCode;
        rsp->get_ResponseCode(&responseCode);
        response->set_response_code(Tool::Tools::ParseBSTRToString(responseCode));

        BSTR responseMessage;
        rsp->get_ResponseMessage(&responseMessage);
        response->set_response_message(Tool::Tools::ParseBSTRToString(responseMessage));

        BSTR masterAvailableKeySlotCount;
        rsp->get_MasterAvailableKeySlotCount(&masterAvailableKeySlotCount);
        response->set_master_available_key_slot_count(Tool::Tools::ParseBSTRToString(masterAvailableKeySlotCount));

        BSTR sessionAvailableKeySlotCount;
        rsp->get_SessionAvailableKeySlotCount(&sessionAvailableKeySlotCount);
        response->set_session_available_key_slot_count(Tool::Tools::ParseBSTRToString(sessionAvailableKeySlotCount));

        BSTR dukptAvailableKeySlotCount;
        rsp->get_DukptAvailableKeySlotCount(&dukptAvailableKeySlotCount);
        response->set_dukpt_available_key_slot_count(Tool::Tools::ParseBSTRToString(dukptAvailableKeySlotCount));

        BSTR aesDukptAvailableKeySlotCount;
        rsp->get_AesDukptAvailableKeySlotCount(&aesDukptAvailableKeySlotCount);
        response->set_aes_dukpt_available_key_slot_count(Tool::Tools::ParseBSTRToString(aesDukptAvailableKeySlotCount));

        SAFEARRAY* psaTmk = NULL;
        rsp->get_Tmk(&psaTmk);
        if(psaTmk)
        {
            CComPtr<_MasterSessionKeyInformation>* bstrData;
            SafeArrayAccessData(psaTmk, (void**)&bstrData);
            PluginMasterSessionKeyInformation pluginMasterSessionKeyInformation;
            flutter::EncodableList listTmk;
            for(ULONG i = 0; i < psaTmk->rgsabound->cElements; i++)
            {
                if(pluginMasterSessionKeyInformation.get(bstrData[i]))
                {
                    PedMasterSessionKeyInformation tmp = *pluginMasterSessionKeyInformation.get(bstrData[i]);
                    flutter::CustomEncodableValue CustomValue(tmp);
                    flutter::EncodableValue tmpValue(CustomValue);
                    listTmk.push_back(tmpValue);
                }
            }
            response->set_tmk(listTmk);
            SafeArrayUnaccessData(psaTmk);
        }

        SAFEARRAY* psaTpk = NULL;
        rsp->get_Tpk(&psaTpk);
        if(psaTpk)
        {
            CComPtr<_MasterSessionKeyInformation>* bstrData;
            SafeArrayAccessData(psaTpk, (void**)&bstrData);
            PluginMasterSessionKeyInformation pluginMasterSessionKeyInformation;
            flutter::EncodableList listTpk;
            for(ULONG i = 0; i < psaTpk->rgsabound->cElements; i++)
            {
                if(pluginMasterSessionKeyInformation.get(bstrData[i]))
                {
                    PedMasterSessionKeyInformation tmp = *pluginMasterSessionKeyInformation.get(bstrData[i]);
                    flutter::CustomEncodableValue CustomValue(tmp);
                    flutter::EncodableValue tmpValue(CustomValue);
                    listTpk.push_back(tmpValue);
                }
            }
            response->set_tpk(listTpk);
            SafeArrayUnaccessData(psaTpk);
        }

        SAFEARRAY* psaTak = NULL;
        rsp->get_Tak(&psaTak);
        if(psaTak)
        {
            CComPtr<_MasterSessionKeyInformation>* bstrData;
            SafeArrayAccessData(psaTak, (void**)&bstrData);
            PluginMasterSessionKeyInformation pluginMasterSessionKeyInformation;
            flutter::EncodableList listTak;
            for(ULONG i = 0; i < psaTak->rgsabound->cElements; i++)
            {
                if(pluginMasterSessionKeyInformation.get(bstrData[i]))
                {
                    PedMasterSessionKeyInformation tmp = *pluginMasterSessionKeyInformation.get(bstrData[i]);
                    flutter::CustomEncodableValue CustomValue(tmp);
                    flutter::EncodableValue tmpValue(CustomValue);
                    listTak.push_back(tmpValue);
                }
            }
            response->set_tak(listTak);
            SafeArrayUnaccessData(psaTak);
        }

        SAFEARRAY* psaTdk = NULL;
        rsp->get_Tdk(&psaTdk);
        if(psaTdk)
        {
            CComPtr<_MasterSessionKeyInformation>* bstrData;
            SafeArrayAccessData(psaTdk, (void**)&bstrData);
            PluginMasterSessionKeyInformation pluginMasterSessionKeyInformation;
            flutter::EncodableList listTdk;
            for(ULONG i = 0; i < psaTdk->rgsabound->cElements; i++)
            {
                if(pluginMasterSessionKeyInformation.get(bstrData[i]))
                {
                    PedMasterSessionKeyInformation tmp = *pluginMasterSessionKeyInformation.get(bstrData[i]);
                    flutter::CustomEncodableValue CustomValue(tmp);
                    flutter::EncodableValue tmpValue(CustomValue);
                    listTdk.push_back(tmpValue);
                }
            }
            response->set_tdk(listTdk);
            SafeArrayUnaccessData(psaTdk);
        }

        SAFEARRAY* psaDukptKey = NULL;
        rsp->get_DukptKey(&psaDukptKey);
        if(psaDukptKey)
        {
            CComPtr<_DukptKeyInformation>* bstrData;
            SafeArrayAccessData(psaDukptKey, (void**)&bstrData);
            PluginDukptKeyInformation pluginDukptKeyInformation;
            flutter::EncodableList listDukptKey;
            for(ULONG i = 0; i < psaDukptKey->rgsabound->cElements; i++)
            {
                if(pluginDukptKeyInformation.get(bstrData[i]))
                {
                    PedDukptKeyInformation tmp = *pluginDukptKeyInformation.get(bstrData[i]);
                    flutter::CustomEncodableValue CustomValue(tmp);
                    flutter::EncodableValue tmpValue(CustomValue);
                    listDukptKey.push_back(tmpValue);
                }
            }
            response->set_dukpt_key(listDukptKey);
            SafeArrayUnaccessData(psaDukptKey);
        }

        SAFEARRAY* psaAesDukptKey = NULL;
        rsp->get_AesDukptKey(&psaAesDukptKey);
        if(psaAesDukptKey)
        {
            CComPtr<_DukptKeyInformation>* bstrData;
            SafeArrayAccessData(psaAesDukptKey, (void**)&bstrData);
            PluginDukptKeyInformation pluginDukptKeyInformation;
            flutter::EncodableList listAesDukptKey;
            for(ULONG i = 0; i < psaAesDukptKey->rgsabound->cElements; i++)
            {
                if(pluginDukptKeyInformation.get(bstrData[i]))
                {
                    PedDukptKeyInformation tmp = *pluginDukptKeyInformation.get(bstrData[i]);
                    flutter::CustomEncodableValue CustomValue(tmp);
                    flutter::EncodableValue tmpValue(CustomValue);
                    listAesDukptKey.push_back(tmpValue);
                }
            }
            response->set_aes_dukpt_key(listAesDukptKey);
            SafeArrayUnaccessData(psaAesDukptKey);
        }

        return &(*response);
    }
}
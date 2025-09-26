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
#include "PluginGoogleSmartTap.h"

namespace POSLinkManage{
    PluginGoogleSmartTap::PluginGoogleSmartTap(){}

    _GoogleSmartTap* PluginGoogleSmartTap::set(const std::optional<ManageGoogleSmartTap>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidGoogleSmartTap;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Manage.GoogleSmartTap"),&clsidGoogleSmartTap);
        request = NULL;
        request.CoCreateInstance(clsidGoogleSmartTap);

        PluginGoogleSmartTapCapBitmap googleSmartTapCap;
        request->putref_GoogleSmartTapCap(googleSmartTapCap.set(req->google_smart_tap_cap() ? std::optional<const ManageGoogleSmartTapCapBitmap>(*req->google_smart_tap_cap()) : std::nullopt));

        request->put_CollectId(req->collect_id()?Tool::Tools::ParseStringToBSTR(*req->collect_id()):SysAllocString(L""));

        request->put_StoreLocalId(req->store_local_id()?Tool::Tools::ParseStringToBSTR(*req->store_local_id()):SysAllocString(L""));

        request->put_TerminalId(req->terminal_id()?Tool::Tools::ParseStringToBSTR(*req->terminal_id()):SysAllocString(L""));

        request->put_MerchantName(req->merchant_name()?Tool::Tools::ParseStringToBSTR(*req->merchant_name()):SysAllocString(L""));

        request->put_MerchantCategory(req->merchant_category()?Tool::Tools::ParseStringToBSTR(*req->merchant_category()):SysAllocString(L""));

        PluginGoogleServiceTypeBitmap serviceType;
        request->putref_ServiceType(serviceType.set(req->service_type() ? std::optional<const ManageGoogleServiceTypeBitmap>(*req->service_type()) : std::nullopt));

        request->put_Security((Security)*req->security());

        request->put_EndTap((EndTap)*req->end_tap());

        request->put_OseToPpse((OseToPpse)*req->ose_to_ppse());

        return request;
    }

    const ManageGoogleSmartTap* PluginGoogleSmartTap::get(_GoogleSmartTap* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = ManageGoogleSmartTap();

        CComPtr<_GoogleSmartTapCapBitmap> comGoogleSmartTapCap = NULL;
        rsp->get_GoogleSmartTapCap(&comGoogleSmartTapCap);
        PluginGoogleSmartTapCapBitmap googleSmartTapCap;
        response->set_google_smart_tap_cap(googleSmartTapCap.get(comGoogleSmartTapCap)? googleSmartTapCap.get(comGoogleSmartTapCap): nullptr);

        BSTR collectId;
        rsp->get_CollectId(&collectId);
        response->set_collect_id(Tool::Tools::ParseBSTRToString(collectId));

        BSTR storeLocalId;
        rsp->get_StoreLocalId(&storeLocalId);
        response->set_store_local_id(Tool::Tools::ParseBSTRToString(storeLocalId));

        BSTR terminalId;
        rsp->get_TerminalId(&terminalId);
        response->set_terminal_id(Tool::Tools::ParseBSTRToString(terminalId));

        BSTR merchantName;
        rsp->get_MerchantName(&merchantName);
        response->set_merchant_name(Tool::Tools::ParseBSTRToString(merchantName));

        BSTR merchantCategory;
        rsp->get_MerchantCategory(&merchantCategory);
        response->set_merchant_category(Tool::Tools::ParseBSTRToString(merchantCategory));

        CComPtr<_GoogleServiceTypeBitmap> comServiceType = NULL;
        rsp->get_ServiceType(&comServiceType);
        PluginGoogleServiceTypeBitmap serviceType;
        response->set_service_type(serviceType.get(comServiceType)? serviceType.get(comServiceType): nullptr);

        Security security;
        rsp->get_Security(&security);
        response->set_security((ManageSecurity)security);

        EndTap endTap;
        rsp->get_EndTap(&endTap);
        response->set_end_tap((ManageEndTap)endTap);

        OseToPpse oseToPpse;
        rsp->get_OseToPpse(&oseToPpse);
        response->set_ose_to_ppse((ManageOseToPpse)oseToPpse);

        return &(*response);
    }
}
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
#include "PluginInitResponse.h"

namespace POSLinkManage{
    PluginInitResponse::PluginInitResponse(){}

    _InitResponse* PluginInitResponse::set(const std::optional<ManageInitResponse>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidInitResponse;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Manage.InitResponse"),&clsidInitResponse);
        request = NULL;
        request.CoCreateInstance(clsidInitResponse);

        request->put_Sn(req->sn()?Tool::Tools::ParseStringToBSTR(*req->sn()):SysAllocString(L""));

        request->put_ModelName(req->model_name()?Tool::Tools::ParseStringToBSTR(*req->model_name()):SysAllocString(L""));

        request->put_OsVersion(req->os_version()?Tool::Tools::ParseStringToBSTR(*req->os_version()):SysAllocString(L""));

        request->put_MacAddress(req->mac_address()?Tool::Tools::ParseStringToBSTR(*req->mac_address()):SysAllocString(L""));

        request->put_LinesPerScreen(req->lines_per_screen()?Tool::Tools::ParseStringToBSTR(*req->lines_per_screen()):SysAllocString(L""));

        request->put_CharsPerLine(req->chars_per_line()?Tool::Tools::ParseStringToBSTR(*req->chars_per_line()):SysAllocString(L""));

        request->put_AppName(req->app_name()?Tool::Tools::ParseStringToBSTR(*req->app_name()):SysAllocString(L""));

        request->put_AppVersion(req->app_version()?Tool::Tools::ParseStringToBSTR(*req->app_version()):SysAllocString(L""));

        request->put_WifiMac(req->wifi_mac()?Tool::Tools::ParseStringToBSTR(*req->wifi_mac()):SysAllocString(L""));

        request->put_Touchscreen((TouchscreenStatus)*req->touchscreen());

        PluginHardwareConfigurationBitmap hardwareConfigurationBitmap;
        request->putref_HardwareConfigurationBitmap(hardwareConfigurationBitmap.set(req->hardware_configuration_bitmap() ? std::optional<const ManageHardwareConfigurationBitmap>(*req->hardware_configuration_bitmap()) : std::nullopt));

        request->put_AppActivated((AppActivated)*req->app_activated());

        request->put_LicenseExpiry(req->license_expiry()?Tool::Tools::ParseStringToBSTR(*req->license_expiry()):SysAllocString(L""));

        request->put_ProtocolFlag((ProtocolFlag)*req->protocol_flag());

        return request;
    }

    const ManageInitResponse* PluginInitResponse::get(_InitResponse* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = ManageInitResponse();

        BSTR responseCode;
        rsp->get_ResponseCode(&responseCode);
        response->set_response_code(Tool::Tools::ParseBSTRToString(responseCode));

        BSTR responseMessage;
        rsp->get_ResponseMessage(&responseMessage);
        response->set_response_message(Tool::Tools::ParseBSTRToString(responseMessage));

        BSTR sn;
        rsp->get_Sn(&sn);
        response->set_sn(Tool::Tools::ParseBSTRToString(sn));

        BSTR modelName;
        rsp->get_ModelName(&modelName);
        response->set_model_name(Tool::Tools::ParseBSTRToString(modelName));

        BSTR osVersion;
        rsp->get_OsVersion(&osVersion);
        response->set_os_version(Tool::Tools::ParseBSTRToString(osVersion));

        BSTR macAddress;
        rsp->get_MacAddress(&macAddress);
        response->set_mac_address(Tool::Tools::ParseBSTRToString(macAddress));

        BSTR linesPerScreen;
        rsp->get_LinesPerScreen(&linesPerScreen);
        response->set_lines_per_screen(Tool::Tools::ParseBSTRToString(linesPerScreen));

        BSTR charsPerLine;
        rsp->get_CharsPerLine(&charsPerLine);
        response->set_chars_per_line(Tool::Tools::ParseBSTRToString(charsPerLine));

        BSTR appName;
        rsp->get_AppName(&appName);
        response->set_app_name(Tool::Tools::ParseBSTRToString(appName));

        BSTR appVersion;
        rsp->get_AppVersion(&appVersion);
        response->set_app_version(Tool::Tools::ParseBSTRToString(appVersion));

        BSTR wifiMac;
        rsp->get_WifiMac(&wifiMac);
        response->set_wifi_mac(Tool::Tools::ParseBSTRToString(wifiMac));

        TouchscreenStatus touchscreen;
        rsp->get_Touchscreen(&touchscreen);
        response->set_touchscreen((ManageTouchscreenStatus)touchscreen);

        CComPtr<_HardwareConfigurationBitmap> comHardwareConfigurationBitmap = NULL;
        rsp->get_HardwareConfigurationBitmap(&comHardwareConfigurationBitmap);
        PluginHardwareConfigurationBitmap hardwareConfigurationBitmap;
        response->set_hardware_configuration_bitmap(hardwareConfigurationBitmap.get(comHardwareConfigurationBitmap)? hardwareConfigurationBitmap.get(comHardwareConfigurationBitmap): nullptr);

        AppActivated appActivated;
        rsp->get_AppActivated(&appActivated);
        response->set_app_activated((ManageAppActivated)appActivated);

        BSTR licenseExpiry;
        rsp->get_LicenseExpiry(&licenseExpiry);
        response->set_license_expiry(Tool::Tools::ParseBSTRToString(licenseExpiry));

        ProtocolFlag protocolFlag;
        rsp->get_ProtocolFlag(&protocolFlag);
        response->set_protocol_flag((ManageProtocolFlag)protocolFlag);

        return &(*response);
    }
}
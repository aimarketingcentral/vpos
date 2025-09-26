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
#include "PluginHardwareConfigurationBitmap.h"

namespace POSLinkManage{
    PluginHardwareConfigurationBitmap::PluginHardwareConfigurationBitmap(){}

    _HardwareConfigurationBitmap* PluginHardwareConfigurationBitmap::set(const std::optional<ManageHardwareConfigurationBitmap>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidHardwareConfigurationBitmap;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Util.HardwareConfigurationBitmap"),&clsidHardwareConfigurationBitmap);
        request = NULL;
        request.CoCreateInstance(clsidHardwareConfigurationBitmap);

        request->put_Magstripe(*req->magstripe());

        request->put_EmvChip(*req->emv_chip());

        request->put_EmvContactless(*req->emv_contactless());

        request->put_CameraFront(*req->camera_front());

        request->put_LaserScanner(*req->laser_scanner());

        request->put_CameraRear(*req->camera_rear());

        request->put_Printer(*req->printer());

        request->put_Touchscreen(*req->touchscreen());

        return request;
    }

    const ManageHardwareConfigurationBitmap* PluginHardwareConfigurationBitmap::get(_HardwareConfigurationBitmap* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = ManageHardwareConfigurationBitmap();

        VARIANT_BOOL magstripe;
        rsp->get_Magstripe(&magstripe);
        response->set_magstripe(magstripe);

        VARIANT_BOOL emvChip;
        rsp->get_EmvChip(&emvChip);
        response->set_emv_chip(emvChip);

        VARIANT_BOOL emvContactless;
        rsp->get_EmvContactless(&emvContactless);
        response->set_emv_contactless(emvContactless);

        VARIANT_BOOL cameraFront;
        rsp->get_CameraFront(&cameraFront);
        response->set_camera_front(cameraFront);

        VARIANT_BOOL laserScanner;
        rsp->get_LaserScanner(&laserScanner);
        response->set_laser_scanner(laserScanner);

        VARIANT_BOOL cameraRear;
        rsp->get_CameraRear(&cameraRear);
        response->set_camera_rear(cameraRear);

        VARIANT_BOOL printer;
        rsp->get_Printer(&printer);
        response->set_printer(printer);

        VARIANT_BOOL touchscreen;
        rsp->get_Touchscreen(&touchscreen);
        response->set_touchscreen(touchscreen);

        return &(*response);
    }
}
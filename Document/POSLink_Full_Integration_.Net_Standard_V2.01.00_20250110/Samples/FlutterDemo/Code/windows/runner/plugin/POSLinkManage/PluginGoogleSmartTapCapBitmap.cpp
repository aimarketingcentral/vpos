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
#include "PluginGoogleSmartTapCapBitmap.h"

namespace POSLinkManage{
    PluginGoogleSmartTapCapBitmap::PluginGoogleSmartTapCapBitmap(){}

    _GoogleSmartTapCapBitmap* PluginGoogleSmartTapCapBitmap::set(const std::optional<ManageGoogleSmartTapCapBitmap>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidGoogleSmartTapCapBitmap;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Manage.GoogleSmartTapCapBitmap"),&clsidGoogleSmartTapCapBitmap);
        request = NULL;
        request.CoCreateInstance(clsidGoogleSmartTapCapBitmap);

        request->put_StandAlone(*req->stand_alone());

        request->put_SemiIntegrated(*req->semi_integrated());

        request->put_Unattended(*req->unattended());

        request->put_Online(*req->online());

        request->put_Offline(*req->offline());

        request->put_Mmp(*req->mmp());

        request->put_ZlibSupport(*req->zlib_support());

        request->put_Printer(*req->printer());

        request->put_PrinterGraphics(*req->printer_graphics());

        request->put_Display(*req->display());

        request->put_Images(*req->images());

        request->put_Audio(*req->audio());

        request->put_Animation(*req->animation());

        request->put_Video(*req->video());

        request->put_SupportPayment(*req->support_payment());

        request->put_SupportDigitalReceipt(*req->support_digital_receipt());

        request->put_SupportServiceIssuance(*req->support_service_issuance());

        request->put_SupportOtaPosData(*req->support_ota_pos_data());

        request->put_OnlinePin(*req->online_pin());

        request->put_CdPin(*req->cd_pin());

        request->put_signature(*req->signature());

        request->put_NoCvm(*req->no_cvm());

        request->put_DeviceGeneratedCode(*req->device_generated_code());

        request->put_SpGeneratedCode(*req->sp_generated_code());

        request->put_IdCapture(*req->id_capture());

        request->put_BioMetric(*req->bio_metric());

        return request;
    }

    const ManageGoogleSmartTapCapBitmap* PluginGoogleSmartTapCapBitmap::get(_GoogleSmartTapCapBitmap* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = ManageGoogleSmartTapCapBitmap();

        VARIANT_BOOL standAlone;
        rsp->get_StandAlone(&standAlone);
        response->set_stand_alone(standAlone);

        VARIANT_BOOL semiIntegrated;
        rsp->get_SemiIntegrated(&semiIntegrated);
        response->set_semi_integrated(semiIntegrated);

        VARIANT_BOOL unattended;
        rsp->get_Unattended(&unattended);
        response->set_unattended(unattended);

        VARIANT_BOOL online;
        rsp->get_Online(&online);
        response->set_online(online);

        VARIANT_BOOL offline;
        rsp->get_Offline(&offline);
        response->set_offline(offline);

        VARIANT_BOOL mmp;
        rsp->get_Mmp(&mmp);
        response->set_mmp(mmp);

        VARIANT_BOOL zlibSupport;
        rsp->get_ZlibSupport(&zlibSupport);
        response->set_zlib_support(zlibSupport);

        VARIANT_BOOL printer;
        rsp->get_Printer(&printer);
        response->set_printer(printer);

        VARIANT_BOOL printerGraphics;
        rsp->get_PrinterGraphics(&printerGraphics);
        response->set_printer_graphics(printerGraphics);

        VARIANT_BOOL display;
        rsp->get_Display(&display);
        response->set_display(display);

        VARIANT_BOOL images;
        rsp->get_Images(&images);
        response->set_images(images);

        VARIANT_BOOL audio;
        rsp->get_Audio(&audio);
        response->set_audio(audio);

        VARIANT_BOOL animation;
        rsp->get_Animation(&animation);
        response->set_animation(animation);

        VARIANT_BOOL video;
        rsp->get_Video(&video);
        response->set_video(video);

        VARIANT_BOOL supportPayment;
        rsp->get_SupportPayment(&supportPayment);
        response->set_support_payment(supportPayment);

        VARIANT_BOOL supportDigitalReceipt;
        rsp->get_SupportDigitalReceipt(&supportDigitalReceipt);
        response->set_support_digital_receipt(supportDigitalReceipt);

        VARIANT_BOOL supportServiceIssuance;
        rsp->get_SupportServiceIssuance(&supportServiceIssuance);
        response->set_support_service_issuance(supportServiceIssuance);

        VARIANT_BOOL supportOtaPosData;
        rsp->get_SupportOtaPosData(&supportOtaPosData);
        response->set_support_ota_pos_data(supportOtaPosData);

        VARIANT_BOOL onlinePin;
        rsp->get_OnlinePin(&onlinePin);
        response->set_online_pin(onlinePin);

        VARIANT_BOOL cdPin;
        rsp->get_CdPin(&cdPin);
        response->set_cd_pin(cdPin);

        VARIANT_BOOL signature;
        rsp->get_signature(&signature);
        response->set_signature(signature);

        VARIANT_BOOL noCvm;
        rsp->get_NoCvm(&noCvm);
        response->set_no_cvm(noCvm);

        VARIANT_BOOL deviceGeneratedCode;
        rsp->get_DeviceGeneratedCode(&deviceGeneratedCode);
        response->set_device_generated_code(deviceGeneratedCode);

        VARIANT_BOOL spGeneratedCode;
        rsp->get_SpGeneratedCode(&spGeneratedCode);
        response->set_sp_generated_code(spGeneratedCode);

        VARIANT_BOOL idCapture;
        rsp->get_IdCapture(&idCapture);
        response->set_id_capture(idCapture);

        VARIANT_BOOL bioMetric;
        rsp->get_BioMetric(&bioMetric);
        response->set_bio_metric(bioMetric);

        return &(*response);
    }
}
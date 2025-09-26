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
#include "PluginMacCalculationRequest.h"

namespace POSLinkPed{
    PluginMacCalculationRequest::PluginMacCalculationRequest(){}

    _MacCalculationRequest* PluginMacCalculationRequest::set(const std::optional<PedMacCalculationRequest>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidMacCalculationRequest;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Ped.MacCalculationRequest"),&clsidMacCalculationRequest);
        request = NULL;
        request.CoCreateInstance(clsidMacCalculationRequest);

        request->put_InputData(req->input_data()?Tool::Tools::ParseStringToBSTR(*req->input_data()):SysAllocString(L""));

        request->put_EncryptionBitmap(req->encryption_bitmap()?Tool::Tools::ParseStringToBSTR(*req->encryption_bitmap()):SysAllocString(L""));

        request->put_MacKeySlot(req->mac_key_slot()?Tool::Tools::ParseStringToBSTR(*req->mac_key_slot()):SysAllocString(L""));

        request->put_MacWorkMode((MacWorkMode)*req->mac_work_mode());

        request->put_EncryptionKeySlot(req->encryption_key_slot()?Tool::Tools::ParseStringToBSTR(*req->encryption_key_slot()):SysAllocString(L""));

        request->put_PaddingChar(req->padding_char()?Tool::Tools::ParseStringToBSTR(*req->padding_char()):SysAllocString(L""));

        request->put_MacKeyType((MacCalculationKeyType)*req->mac_key_type());

        request->put_KsnFlag((KsnFlag)*req->ksn_flag());

        return request;
    }

    const PedMacCalculationRequest* PluginMacCalculationRequest::get(_MacCalculationRequest* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = PedMacCalculationRequest();

        BSTR inputData;
        rsp->get_InputData(&inputData);
        response->set_input_data(Tool::Tools::ParseBSTRToString(inputData));

        BSTR encryptionBitmap;
        rsp->get_EncryptionBitmap(&encryptionBitmap);
        response->set_encryption_bitmap(Tool::Tools::ParseBSTRToString(encryptionBitmap));

        BSTR macKeySlot;
        rsp->get_MacKeySlot(&macKeySlot);
        response->set_mac_key_slot(Tool::Tools::ParseBSTRToString(macKeySlot));

        MacWorkMode macWorkMode;
        rsp->get_MacWorkMode(&macWorkMode);
        response->set_mac_work_mode((PedMacWorkMode)macWorkMode);

        BSTR encryptionKeySlot;
        rsp->get_EncryptionKeySlot(&encryptionKeySlot);
        response->set_encryption_key_slot(Tool::Tools::ParseBSTRToString(encryptionKeySlot));

        BSTR paddingChar;
        rsp->get_PaddingChar(&paddingChar);
        response->set_padding_char(Tool::Tools::ParseBSTRToString(paddingChar));

        MacCalculationKeyType macKeyType;
        rsp->get_MacKeyType(&macKeyType);
        response->set_mac_key_type((PedMacCalculationKeyType)macKeyType);

        KsnFlag ksnFlag;
        rsp->get_KsnFlag(&ksnFlag);
        response->set_ksn_flag((PedKsnFlag)ksnFlag);

        return &(*response);
    }
}
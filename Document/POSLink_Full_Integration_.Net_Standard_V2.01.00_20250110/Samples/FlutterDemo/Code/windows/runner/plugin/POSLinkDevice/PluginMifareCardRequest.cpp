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
#include "PluginMifareCardRequest.h"

namespace POSLinkDevice{
    PluginMifareCardRequest::PluginMifareCardRequest(){}

    _MifareCardRequest* PluginMifareCardRequest::set(const std::optional<DeviceMifareCardRequest>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidMifareCardRequest;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Device.MifareCardRequest"),&clsidMifareCardRequest);
        request = NULL;
        request.CoCreateInstance(clsidMifareCardRequest);

        request->put_M1Command((M1CommandType)*req->m1_command());

        request->put_BlockNumber(req->block_number()?Tool::Tools::ParseStringToBSTR(*req->block_number()):SysAllocString(L""));

        request->put_Password(req->password()?Tool::Tools::ParseStringToBSTR(*req->password()):SysAllocString(L""));

        request->put_PasswordType((PasswordType)*req->password_type());

        request->put_BlockValue(req->block_value()?Tool::Tools::ParseStringToBSTR(*req->block_value()):SysAllocString(L""));

        request->put_UpdateBlockNumber(req->update_block_number()?Tool::Tools::ParseStringToBSTR(*req->update_block_number()):SysAllocString(L""));

        request->put_Timeout(req->timeout()?Tool::Tools::ParseStringToBSTR(*req->timeout()):SysAllocString(L""));

        return request;
    }

    const DeviceMifareCardRequest* PluginMifareCardRequest::get(_MifareCardRequest* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = DeviceMifareCardRequest();

        M1CommandType m1Command;
        rsp->get_M1Command(&m1Command);
        response->set_m1_command((DeviceM1CommandType)m1Command);

        BSTR blockNumber;
        rsp->get_BlockNumber(&blockNumber);
        response->set_block_number(Tool::Tools::ParseBSTRToString(blockNumber));

        BSTR password;
        rsp->get_Password(&password);
        response->set_password(Tool::Tools::ParseBSTRToString(password));

        PasswordType passwordType;
        rsp->get_PasswordType(&passwordType);
        response->set_password_type((DevicePasswordType)passwordType);

        BSTR blockValue;
        rsp->get_BlockValue(&blockValue);
        response->set_block_value(Tool::Tools::ParseBSTRToString(blockValue));

        BSTR updateBlockNumber;
        rsp->get_UpdateBlockNumber(&updateBlockNumber);
        response->set_update_block_number(Tool::Tools::ParseBSTRToString(updateBlockNumber));

        BSTR timeout;
        rsp->get_Timeout(&timeout);
        response->set_timeout(Tool::Tools::ParseBSTRToString(timeout));

        return &(*response);
    }
}
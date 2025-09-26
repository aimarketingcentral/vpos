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
#include "PluginDoSignatureRequest.h"

namespace POSLinkManage{
    PluginDoSignatureRequest::PluginDoSignatureRequest(){}

    _DoSignatureRequest* PluginDoSignatureRequest::set(const std::optional<ManageDoSignatureRequest>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidDoSignatureRequest;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Manage.DoSignatureRequest"),&clsidDoSignatureRequest);
        request = NULL;
        request.CoCreateInstance(clsidDoSignatureRequest);

        request->put_UploadFlag((UploadFlag)*req->upload_flag());

        request->put_HostReferenceNumber(req->host_reference_number()?Tool::Tools::ParseStringToBSTR(*req->host_reference_number()):SysAllocString(L""));

        request->put_EdcType((EdcType)*req->edc_type());

        request->put_Timeout(req->timeout()?Tool::Tools::ParseStringToBSTR(*req->timeout()):SysAllocString(L""));

        request->put_ContinuousScreen((ContinuousScreen)*req->continuous_screen());

        return request;
    }

    const ManageDoSignatureRequest* PluginDoSignatureRequest::get(_DoSignatureRequest* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = ManageDoSignatureRequest();

        UploadFlag uploadFlag;
        rsp->get_UploadFlag(&uploadFlag);
        response->set_upload_flag((ManageUploadFlag)uploadFlag);

        BSTR hostReferenceNumber;
        rsp->get_HostReferenceNumber(&hostReferenceNumber);
        response->set_host_reference_number(Tool::Tools::ParseBSTRToString(hostReferenceNumber));

        EdcType edcType;
        rsp->get_EdcType(&edcType);
        response->set_edc_type((ManageEdcType)edcType);

        BSTR timeout;
        rsp->get_Timeout(&timeout);
        response->set_timeout(Tool::Tools::ParseBSTRToString(timeout));

        ContinuousScreen continuousScreen;
        rsp->get_ContinuousScreen(&continuousScreen);
        response->set_continuous_screen((ManageContinuousScreen)continuousScreen);

        return &(*response);
    }
}
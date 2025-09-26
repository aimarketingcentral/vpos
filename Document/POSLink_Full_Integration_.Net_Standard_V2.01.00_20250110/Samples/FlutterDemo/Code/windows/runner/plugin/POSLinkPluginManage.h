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
#include <tchar.h>
#include <windows.h>
#include <iostream>
#include <atlbase.h>
#include <atlstr.h>
#include <map>
#include "..\poslinkcore.tlh"
#include "..\poslinkadmin.tlh"
#include "..\poslinkadmin.tlh"
#include "..\pigeon\POSLinkManage.h"
#include "..\poslink_single.h"
#include "Tools.h"
#include "POSLinkManage\PluginCheckFileRequest.h"
#include "POSLinkManage\PluginClearCardBufferRequest.h"
#include "POSLinkManage\PluginDeleteImageRequest.h"
#include "POSLinkManage\PluginDoSignatureRequest.h"
#include "POSLinkManage\PluginGetSignatureRequest.h"
#include "POSLinkManage\PluginGetVariableRequest.h"
#include "POSLinkManage\PluginInitRequest.h"
#include "POSLinkManage\PluginRebootRequest.h"
#include "POSLinkManage\PluginResetScreenRequest.h"
#include "POSLinkManage\PluginSetApplePayVasParametersRequest.h"
#include "POSLinkManage\PluginSetGoogleSmartTapParametersRequest.h"
#include "POSLinkManage\PluginSetVariableRequest.h"
#include "POSLinkManage\PluginUpdateResourceFileRequest.h"
#include "POSLinkManage\PluginVasPushDataRequest.h"
#include "POSLinkManage\PluginCheckFileResponse.h"
#include "POSLinkManage\PluginClearCardBufferResponse.h"
#include "POSLinkManage\PluginDeleteImageResponse.h"
#include "POSLinkManage\PluginDoSignatureResponse.h"
#include "POSLinkManage\PluginGetSignatureResponse.h"
#include "POSLinkManage\PluginGetVariableResponse.h"
#include "POSLinkManage\PluginInitResponse.h"
#include "POSLinkManage\PluginRebootResponse.h"
#include "POSLinkManage\PluginResetScreenResponse.h"
#include "POSLinkManage\PluginSetApplePayVasParametersResponse.h"
#include "POSLinkManage\PluginSetGoogleSmartTapParametersResponse.h"
#include "POSLinkManage\PluginSetVariableResponse.h"
#include "POSLinkManage\PluginUpdateResourceFileResponse.h"
#include "POSLinkManage\PluginVasPushDataResponse.h"

namespace POSLinkManage {

    class POSLinkPluginManage: public POSLinkManageApi
    {
        public:
            POSLinkPluginManage();
            void CheckFile(const ManageCheckFileRequest& req, std::function<void(ErrorOr<ManageCheckFileResponse> reply)> result);
            void ClearCardBuffer(const ManageClearCardBufferRequest& req, std::function<void(ErrorOr<ManageClearCardBufferResponse> reply)> result);
            void DeleteImage(const ManageDeleteImageRequest& req, std::function<void(ErrorOr<ManageDeleteImageResponse> reply)> result);
            void DoSignature(const ManageDoSignatureRequest& req, std::function<void(ErrorOr<ManageDoSignatureResponse> reply)> result);
            void GetSignature(const ManageGetSignatureRequest& req, std::function<void(ErrorOr<ManageGetSignatureResponse> reply)> result);
            void GetVariable(const ManageGetVariableRequest& req, std::function<void(ErrorOr<ManageGetVariableResponse> reply)> result);
            void Init(const ManageInitRequest& req, std::function<void(ErrorOr<ManageInitResponse> reply)> result);
            void Reboot(const ManageRebootRequest& req, std::function<void(ErrorOr<ManageRebootResponse> reply)> result);
            void ResetScreen(const ManageResetScreenRequest& req, std::function<void(ErrorOr<ManageResetScreenResponse> reply)> result);
            void SetApplePayVasParameters(const ManageSetApplePayVasParametersRequest& req, std::function<void(ErrorOr<ManageSetApplePayVasParametersResponse> reply)> result);
            void SetGoogleSmartTapParameters(const ManageSetGoogleSmartTapParametersRequest& req, std::function<void(ErrorOr<ManageSetGoogleSmartTapParametersResponse> reply)> result);
            void SetVariable(const ManageSetVariableRequest& req, std::function<void(ErrorOr<ManageSetVariableResponse> reply)> result);
            void UpdateResourceFile(const ManageUpdateResourceFileRequest& req, std::function<void(ErrorOr<ManageUpdateResourceFileResponse> reply)> result);
            void VasPushData(const ManageVasPushDataRequest& req, std::function<void(ErrorOr<ManageVasPushDataResponse> reply)> result);
    };
}

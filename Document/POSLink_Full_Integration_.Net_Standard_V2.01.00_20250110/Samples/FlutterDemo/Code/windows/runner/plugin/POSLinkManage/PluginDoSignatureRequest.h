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
#include "..\..\poslinkcore.tlh"
#include "..\..\poslinkadmin.tlh"
#include "..\..\poslinkadmin.tlh"
#include "..\..\pigeon\POSLinkManage.h"
#include "..\Tools.h"

namespace POSLinkManage{
    class PluginDoSignatureRequest
    {
    public:
        PluginDoSignatureRequest();
        _DoSignatureRequest* set(const std::optional<ManageDoSignatureRequest>& req);
        const ManageDoSignatureRequest* get(_DoSignatureRequest* rsp);
    private:
        CComPtr<_DoSignatureRequest> request;
        std::optional<ManageDoSignatureRequest> response;
    };
}
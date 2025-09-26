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
#include "poslink_single.h"

GlobalCommSetting::GlobalCommSetting()
{
    CoInitialize(NULL);
    CLSID clsidPoslinkFull;
    CLSIDFromProgID(OLESTR("POSLinkFullIntegration.POSLinkFull"), &clsidPoslinkFull);
    POSLinkFullIntegration.CoCreateInstance(clsidPoslinkFull);
}

GlobalCommSetting g_commSetting;

GlobalMultiCommand::GlobalMultiCommand()
{
    _multiCommandPsa = NULL;
    SAFEARRAYBOUND rgsabound[1];
    rgsabound[0].cElements = (ULONG)(_maxLen);
    rgsabound[0].lLbound = 0;
    _multiCommandPsa = SafeArrayCreate(VT_UNKNOWN, 1, rgsabound);
    SafeArrayUnaccessData(_multiCommandPsa);
    _multiCommandLen = 0;
}

SAFEARRAY* GlobalMultiCommand::GetPsa()
{
    return _multiCommandPsa;
}

void GlobalMultiCommand::AddReq(void *pv)
{
    if(_multiCommandLen < _maxLen)
    {
        SafeArrayPutElement(_multiCommandPsa, &_multiCommandLen, pv);
        SafeArrayUnaccessData(_multiCommandPsa);

        _multiCommandLen++;
    }
}

void GlobalMultiCommand::ClearReq()
{
    _multiCommandPsa = NULL;
    SAFEARRAYBOUND rgsabound[1];
    rgsabound[0].cElements = (ULONG)(_maxLen);
    rgsabound[0].lLbound = 0;
    _multiCommandPsa = SafeArrayCreate(VT_UNKNOWN, 1, rgsabound);
    SafeArrayUnaccessData(_multiCommandPsa);
    _multiCommandLen = 0;
}

void GlobalMultiCommand::ClearRsp()
{
    ResultFlag.clear();
    Results.clear();
}

void GlobalMultiCommand::AddRsp(std::string sType, std::any result)
{
    ResultFlag.push_back(sType);
    Results.push_back(result);
}

GlobalMultiCommand g_multiCommand;

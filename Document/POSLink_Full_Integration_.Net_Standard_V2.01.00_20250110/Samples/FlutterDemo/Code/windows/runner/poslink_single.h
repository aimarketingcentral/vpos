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

#include <flutter/basic_message_channel.h>
#include <flutter/binary_messenger.h>
#include <flutter/encodable_value.h>
#include <flutter/standard_message_codec.h>
#include <tchar.h>
#include <windows.h>
#include <iostream>
#include <atlbase.h> 
#include <atlstr.h> 
#include <optional>
#include <functional>
#include "poslinkcore.tlh"
#include "poslinkuart.tlh"
#include "poslinkadmin.tlh"
#include "poslinkfullintegration.tlh"

class GlobalCommSetting
{
public:
	GlobalCommSetting();
	CComPtr<_CommunicationSetting> CommSetting = NULL;
	CComPtr<_POSLinkFull> POSLinkFullIntegration = NULL;
	CComPtr<_Terminal> GlobalTerminal = NULL;
};
extern GlobalCommSetting g_commSetting;

class GlobalMultiCommand
{
public:
	GlobalMultiCommand();
	bool IsDoMultiCommand = false;
	std::vector<std::string> ResultFlag;
	SAFEARRAY* GetPsa();
	std::vector<std::any> Results;
	void AddReq(void *pv);
	void AddRsp(std::string sType, std::any result);
	void ClearReq();
	void ClearRsp();
private:
	SAFEARRAY* _multiCommandPsa = NULL;
	LONG _maxLen = 15;
	LONG _multiCommandLen = 0;
};
extern GlobalMultiCommand g_multiCommand;
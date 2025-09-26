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
#include <flutter/encodable_value.h>
#include <flutter/basic_message_channel.h>
#include <flutter/binary_messenger.h>
#include <flutter/standard_message_codec.h>

#include <tchar.h>
#include <windows.h>
#include <iostream>
#include <atlbase.h> 
#include <atlstr.h> 
#include <comutil.h>

#include "..\poslinkcore.tlh"
#include "..\poslinkuart.tlh"
#include "..\poslinkadmin.tlh"
#include "..\poslinkfullintegration.tlh"

namespace Tool{
    class Tools
    {
    public:
        static BSTR ParseStringToBSTR(const std::string& message);
        static std::string ParseBSTRToString(BSTR message);
        static std::string ParseExecutionResultCodeToString(Code code);
        static HardKey ParseStringToHardKey(const std::string& item);
    };
}
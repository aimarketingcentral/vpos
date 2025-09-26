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
#include "Tools.h"

namespace Tool{
    BSTR Tools::ParseStringToBSTR(const std::string& message)
    {
        int utf8Length = MultiByteToWideChar(CP_UTF8, 0, message.c_str(), -1, NULL, 0);
        wchar_t *utf16Buffer = new wchar_t[utf8Length];
        MultiByteToWideChar(CP_UTF8, 0, message.c_str(), -1, utf16Buffer, utf8Length);

        // Convert UTF-16 encoded char array to BSTR
        BSTR bstr = SysAllocString(utf16Buffer);
        delete[] utf16Buffer;

        return bstr;
    }

    std::string Tools::ParseBSTRToString(BSTR message)
    {
        if(message != NULL)
        {
            return _com_util::ConvertBSTRToString(message);
        }
        else
        {
            return "";
        }
    }

    std::string Tools::ParseExecutionResultCodeToString(Code code)
    {
        std::string ret = "";
        switch(code)
        {
            case Code::Code_UnknownError:
                ret = "Unknown Error";
                break;
            case Code::Code_Ok:
                ret = "OK";
                break;
            case Code::Code_RecvAckTimeout:
                ret = "Receive ACK Timeout";
                break;
            case Code::Code_RecvDataTimeout:
                ret = "Receive Data Timeout";
                break;
            case Code::Code_ConnectError:
                ret = "Connect Error";
                break;
            case Code::Code_SendDataError:
                ret = "Send Data Error";
                break;
            case Code::Code_RecvAckError:
                ret = "Receive ACK Error";
                break;
            case Code::Code_RecvDataError:
                ret = "Receive Data Error";
                break;
            case Code::Code_ExceptionalHttpStatusCode:
                ret = "Exceptional Http Status Code";
                break;
            case Code::Code_LrcError:
                ret = "LRC Error";
                break;
            case Code::Code_PackRequestError:
                ret = "Pack Request Error";
                break;
        }

        return ret;
    }

    HardKey Tools::ParseStringToHardKey(const std::string& item)
    {
        if(item == "KEY0")
        {
            return HardKey_Key0;
        }
        else if(item == "KEY1")
        {
            return HardKey_Key1;
        }
        else if(item == "KEY2")
        {
            return HardKey_Key2;
        }
        else if(item == "KEY3")
        {
            return HardKey_Key3;
        }
        else if(item == "KEY4")
        {
            return HardKey_Key4;
        }
        else if(item == "KEY5")
        {
            return HardKey_Key5;
        }
        else if(item == "KEY6")
        {
            return HardKey_Key6;
        }
        else if(item == "KEY7")
        {
            return HardKey_Key7;
        }
        else if(item == "KEY8")
        {
            return HardKey_Key8;
        }
        else if(item == "KEY9")
        {
            return HardKey_Key9;
        }
        else if(item == "KEYCLEAR")
        {
            return HardKey_Clear;
        }
        else if(item == "KEYCANCEL")
        {
            return HardKey_Cancel;
        }
        else if(item == "KEYENTER")
        {
            return HardKey_Ok;
        }

        return HardKey_NotSet;
    }
}
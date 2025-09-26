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
#include "POSLinkPluginGetReportStatus.h"
#include <thread>

namespace POSLinkGetReportStatus{
    POSLinkPluginGetReportStatus::POSLinkPluginGetReportStatus(){}

    void POSLinkPluginGetReportStatus::GetReportStatus(std::function<void(ErrorOr<int64_t> reply)> result)
    {
        std::thread t1(POSLinkPluginGetReportStatus::RunReportStatus);
        t1.detach();
    }

    int POSLinkPluginGetReportStatus::MessageBoxTimeout(HWND hWnd, const WCHAR* sText, const WCHAR* sCaption, UINT uType, DWORD dwMillisecond)
    {
        typedef int(__stdcall* MSGWBOXAPI)(IN HWND hWnd, IN LPCWSTR lpText, IN LPCWSTR lpCaption, IN UINT uType, IN WORD wLanguageId, IN DWORD dwMillisecond);
        int iResult;
        HMODULE hUser32 = LoadLibraryW(L"user32.dll");
        if(hUser32)
        {
            auto MessageBoxTimeoutW = (MSGWBOXAPI)GetProcAddress(hUser32, "MessageBoxTimeoutW");
            iResult = MessageBoxTimeoutW(hWnd, sText, sCaption, uType, 0, dwMillisecond);
            FreeLibrary(hUser32);
        }
        else
        {
            iResult = MessageBoxW(hWnd, sText, sCaption, uType);
        }
        return iResult;
    }

    void POSLinkPluginGetReportStatus::RunReportStatus()
    {
        long iReportStatus;
        if(g_commSetting.GlobalTerminal != NULL)
        {
            g_commSetting.GlobalTerminal->GetReportStatus(&iReportStatus);
            if(iReportStatus > -1)
            {
                LPCWSTR lpReportStatus = L"";
                switch(iReportStatus)
                {
                    case 0:
                        lpReportStatus = L"Ready for card input.";
                        break;
                    case 1:
                        lpReportStatus = L"Ready for PIN entry.";
                        break;
                    case 2:
                        lpReportStatus = L"Ready for signature.";
                        break;
                    case 3:
                        lpReportStatus = L"Ready for online processing.";
                        break;
                    case 4:
                        lpReportStatus = L"Ready for second card input.";
                        break;
                    case 5:
                        lpReportStatus = L"Ready for signature retry by pressing CLEAR key.";
                        break;
                    case 6:
                        lpReportStatus = L"Ready for PIN retry by inputting wrong offline PIN for EMV.";
                        break;
                    case 9000000:
                        lpReportStatus = L"Ready for card input.";
                        break;
                    case 9000001:
                        lpReportStatus = L"Ready for PIN entry.";
                        break;
                    case 9000002:
                        lpReportStatus = L"Ready for Signature.";
                        break;
                    case 9000003:
                        lpReportStatus = L"Ready for online processing.";
                        break;
                    case 9000004:
                        lpReportStatus = L"Ready for second card input.";
                        break;
                    case 9000005:
                        lpReportStatus = L"Ready for signature retry by pressing CLEAR key.";
                        break;
                    case 9000006:
                        lpReportStatus = L"Ready for PIN retry by inputting wrong offline PIN for EMV.";
                        break;
                    case 9000007:
                        lpReportStatus = L"Please see phone.";
                        break;
                    case 9000008:
                        lpReportStatus = L"Please try another card.";
                        break;
                    case 9000009:
                        lpReportStatus = L"Please present one card only.";
                        break;
                    case 9000010:
                        lpReportStatus = L"Fallback swipe.";
                        break;
                    case 9020002:
                        lpReportStatus = L"Ready for entering cashback.";
                        break;
                    case 9040003:
                        lpReportStatus = L"Remove card.";
                        break;
                    case 9040010:
                        lpReportStatus = L"Re-insert card.";
                        break;
                }
                MessageBoxTimeout(nullptr, lpReportStatus, L"Report Status", MB_OK, 1500);
            }
        }
    }
}
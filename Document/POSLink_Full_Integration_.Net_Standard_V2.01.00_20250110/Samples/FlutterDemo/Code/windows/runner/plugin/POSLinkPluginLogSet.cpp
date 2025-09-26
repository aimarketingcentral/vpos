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
#include "POSLinkPluginLogSet.h"
#include <thread>

namespace POSLinkLogSet {
    POSLinkPluginLogSet::POSLinkPluginLogSet(){}

    std::optional<FlutterError> POSLinkPluginLogSet::SetLogSetting(const LogSetting& log_setting)
    {
        std::optional<FlutterError> ret;
        if(g_commSetting.POSLinkFullIntegration != NULL)
        {
            CoInitialize(NULL);
            CLSID clsidLogSetting;
            CLSIDFromProgID(OLESTR("POSLinkCore.LogSetting"), &clsidLogSetting);
            CComPtr<_LogSetting> comLogSetting = NULL;
            comLogSetting.CoCreateInstance(clsidLogSetting);
            if(log_setting.file_path())
            {
                comLogSetting->put_FilePath(Tool::Tools::ParseStringToBSTR(*log_setting.file_path()));
            }
            if(log_setting.file_name())
            {
                comLogSetting->put_FileName(Tool::Tools::ParseStringToBSTR(*log_setting.file_name()));
            }
            if(log_setting.days())
            {
                comLogSetting->put_Days((long)(*log_setting.days()));
            }
            if(log_setting.level())
            {
                comLogSetting->put_Level((CoLogLevel)(*log_setting.level()));
            }
            if(log_setting.enable())
            {
                comLogSetting->put_Enabled((VARIANT_BOOL)(*log_setting.enable()));
            }
            g_commSetting.POSLinkFullIntegration->SetLogSetting(comLogSetting);
        }

        return ret;
    }

    void POSLinkPluginLogSet::Upload(std::function<void(ErrorOr<UploadResult> reply)> result)
    {
        std::thread t1([result]{
            if(g_commSetting.GlobalTerminal == NULL)
            {
                return;
            }
            SAFEARRAY* psa = NULL;
            CComPtr<_UploadResult> comUploadResult = NULL;
            g_commSetting.GlobalTerminal->UploadLog(psa, &comUploadResult);
            UploadResult uploadResult;
            if(comUploadResult != NULL)
            {
                VARIANT_BOOL isSuccessful;
                comUploadResult->get_IsSuccessful(&isSuccessful);
                uploadResult.set_is_successful(isSuccessful);

                BSTR sn;
                comUploadResult->get_Sn(&sn);
                uploadResult.set_sn(Tool::Tools::ParseBSTRToString(sn));

                POSLinkErrorCode poslinkCode;
                comUploadResult->get_POSLinkUploadErrorCode(&poslinkCode);
                std::string_view strPOSLinkErrorCode = "";
                if(poslinkCode == POSLinkErrorCode_Ok)
                {
                    strPOSLinkErrorCode = "OK";
                }
                else if(poslinkCode == POSLinkErrorCode_SftpConnectError)
                {
                    strPOSLinkErrorCode = "SFTP connect error";
                }
                else if(poslinkCode == POSLinkErrorCode_UploadDataError)
                {
                    strPOSLinkErrorCode = "Upload data error";
                }
                else if(poslinkCode == POSLinkErrorCode_NoDataToUpload)
                {
                    strPOSLinkErrorCode = "No data to upload";
                }
                else if(poslinkCode == POSLinkErrorCode_SftpParameterNotReceived)
                {
                    strPOSLinkErrorCode = "SFTP parameter not received";
                }
                uploadResult.set_pos_link_upload_error_code(strPOSLinkErrorCode);

                TerminalErrorCode terminalCode;
                comUploadResult->get_TerminalUploadErrorCode(&terminalCode);
                std::string_view strTerminalErrorCode = "";
                if(terminalCode == TerminalErrorCode_Ok)
                {
                    strTerminalErrorCode = "OK";
                }
                else if(terminalCode == TerminalErrorCode_CommunicationError)
                {
                    strTerminalErrorCode = "Communication error";
                }
                else if(terminalCode == TerminalErrorCode_Abort)
                {
                    strTerminalErrorCode = "Abort";
                }
                else if(terminalCode == TerminalErrorCode_ConnectError)
                {
                    strTerminalErrorCode = "Connect error";
                }
                else if(terminalCode == TerminalErrorCode_UnknownError)
                {
                    strTerminalErrorCode = "Unknown error";
                }
                else if(terminalCode == TerminalErrorCode_SftpCommunicationError)
                {
                    strTerminalErrorCode = "SFTP Communication Error";
                }
                else if(terminalCode == TerminalErrorCode_NoDataToUpload)
                {
                    strTerminalErrorCode = "No data to upload";
                }
                uploadResult.set_terminal_upload_error_code(strTerminalErrorCode);
            }
            ErrorOr<UploadResult> reply(uploadResult);
            result(reply);
        });
        t1.detach();
    }

    void POSLinkPluginLogSet::GetIosLogList(std::function<void(ErrorOr<flutter::EncodableList> reply)> result)
    {

    }
}
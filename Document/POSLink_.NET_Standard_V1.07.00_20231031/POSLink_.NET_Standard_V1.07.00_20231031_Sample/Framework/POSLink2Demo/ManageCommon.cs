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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSLink2Demo
{
    public static class ManageCommon
    {
        public static readonly string[] CommandNames = new string[]
        {
            "Init",
            "Get Variable",
            "Set Variable",
            "Get Signature",
            "Reset",
            "Update Resource File",
            "Do Signature",
            "Delete Image",
            "Reboot",
            "Input Account",
            "Reset MSR",
            "Check File",
            "Set SAF Parameters",
            "Reprint",
            "Token Administrative",
            "VAS Set Merchant Parameters",
            "VAS Push Data",
            "Get SAF Parameters"
        };

        //Request----------------------------------------------------
        public static readonly string[] GetVariableReqButtonNames = new string[]
        {
            "Normal",
            "Multi Merchant"
        };

        public static readonly string[,] GetVariableReqNormalComboBox = new string[,]
        {
            {"EdcType", "EDC Type"}
        };

        public static readonly string[,] GetVariableReqNormal = new string[,]
        {
            {"VariableName1", "Variable Name 1"},
            {"VariableName2", "Variable Name 2"},
            {"VariableName3", "Variable Name 3"},
            {"VariableName4", "Variable Name 4"},
            {"VariableName5", "Variable Name 5"}
        };

        public static readonly string[] SetVariableReqButtonNames = new string[]
        {
            "Normal",
            "Multi Merchant"
        };

        public static readonly string[,] SetVariableReqNormalComboBox = new string[,]
        {
            {"EdcType", "EDC Type"}
        };

        public static readonly string[,] SetVariableReqNormal = new string[,]
        {
            {"VariableName1", "Variable Name 1"},
            {"VariableValue1", "Variable Value 1"},
            {"VariableName2", "Variable Name 2"},
            {"VariableValue2", "Variable Value 2"},
            {"VariableName3", "Variable Name 3"},
            {"VariableValue3", "Variable Value 3"},
            {"VariableName4", "Variable Name 4"},
            {"VariableValue4", "Variable Value 4"},
            {"VariableName5", "Variable Name 5"},
            {"VariableValue5", "Variable Value 5"}
        };

        public static readonly string[,] UpdateResourceFileReqComboBox = new string[,]
        {
            {"FileType", "File Type"}
        };

        public static readonly string[,] UpdateResourceFileReqNormal = new string[,]
        {
            { "FileFullPath", "File Full Path"},
            { "TargetDevice", "Target Device"}
        };

        public static readonly string[,] DoSignatureReqNormalComboBox = new string[,]
        {
            {"EdcType", "EDC Type"}
        };

        public static readonly string[,] DoSignatureReqNormal = new string[,]
        {
            { "UploadFlag", "Upload Flag"},
            { "HRefNum", "Host Ref Number"},
            { "Timeout", "Timeout"},
            { "ContinuousScreen", "Continuous Screen"}
        };

        public static readonly string[,] DeleteImageReqNormal = new string[,]
        {
            {"ImageName", "Image Name"}
        };

        public static readonly string[,] InputAccountReqNormalComboBox = new string[,]
        {
            {"EdcType", "EDC Type"},
            {"TransactionType", "Transaction Type" }
        };

        public static readonly string[,] InputAccountReqNormal = new string[,]
        {
            { "MagneticSwipeEntryFlag", "Magnetic Swipe Entry Flag"},
            { "ManualEntryFlag", "Manual Entry Flag"},
            { "ContactlessEntryFlag", "Contactless Entry Flag"},
            { "ScannerEntryFlag", "Scanner Entry Flag"},
            { "ExpiryDatePrompt", "Expiry Date Prompt"},
            { "Timeout", "Timeout"},
            { "EncryptionFlag", "Encryption Flag"},
            { "KeySlot", "Key Slot"},
            { "MinAccountLength", "Min Account Length"},
            { "MaxAccountLength", "Max Account Length"},
            { "ContinuousScreen", "Continuous Screen"}
        };

        public static readonly string[,] CheckFileReqNormal = new string[,]
        {
            { "FileName", "File Name"}
        };

        public static readonly string[,] SetSafParametersReqNormal = new string[,]
        {
            { "SafMode", "SAF Mode"},
            { "StartDateTime", "Start Date Time"},
            { "EndDateTime", "End Date Time"},
            { "DurationInDays", "Duration In Days"},
            { "MaxNumber", "Max Number"},
            { "TotalCeilingAmount", "Total Ceiling Amount"},
            { "CeilingAmountPerCardType", "Ceiling Amount Per Card Type"},
            { "HaloPerCardType", "HALO Per Card Type"},
            { "UploadMode", "Upload Mode"},
            { "AutoUploadIntervalTime", "Auto Upload Interval Time"},
            { "DeleteSafConfirmation", "Delete SAF Confirmation"}
        };

        public static readonly string[,] ReprintReqNormalComboBox = new string[,]
        {
            {"EdcType", "EDC Type"}
        };

        public static readonly string[,] ReprintReqNormal = new string[,]
        {
            {"PrintLastReceipt", "Print Last Receipt"},
            {"OrigRefNum", "Orig Ref Num"},
            {"AuthCode", "Auth Code"},
            {"EcrRefNum", "ECR Ref Num"}
        };

        public static readonly string[,] TokenAdministrativeReqNormalComboBox = new string[,]
        {
            {"EdcType", "EDC Type"}
        };

        public static readonly string[,] TokenAdministrativeReqNormal = new string[,]
        {
            { "TokenCommand", "Token Command"},
            { "Token", "Token"},
            { "TokenSN", "Token SN"},
            { "ExpiryDate", "Expiry Date"}
        };

        public static readonly string[,] VasProgramItemsName = new string[,]
        {
            { "Apple Pay VAS", "Apple Pay VAS"},
            { "Google Smart Tap", "Apple Pay VAS"}
        };

        public static readonly string[,] ApplePayVasReqNormalComboBox = new string[,]
        {
            { "VasMode", "VAS Mode" }
        };

        public static readonly string[,] VasModeItemsName = new string[,]
        {
            { "Vas Only", "Vas Only"},
            { "Vas And Payment", "Vas And Payment"},
            { "Vas Or Payment", "Vas Or Payment"},
            { "Payment Only", "Payment Only"}
        };

        public static readonly string[,] ApplePayVasReqNormal = new string[,]
        {
            {"MerchantID", "Merchant ID"},
            {"UrlMode", "URL Mode"},
            {"Url", "URL"}
        };

        public static readonly string[,] GoogleSmartTapReqNormalComboBox = new string[,]
        {
            { "VasMode", "VAS Mode" },
            { "Security", "Security" }
        };

        public static readonly string[,] SecurityItemsName = new string[,]
        {
            { "Normal", "Normal"},
            { "Securely", "Securely"},
            { "Pre Signature", "Pre Signature"},
            { "Need not a right auth", "Need not a right auth"}
        };

        public static readonly string[] GoogleSmartTapReqNormalButtonTextBox = new string[]
        {
            "SmartTapCAP"
        };

        public static readonly string[,] GoogleSmartTapReqNormal = new string[,]
        {
            {"CollectID", "Collect ID"},
            {"StoreLocalID", "Store Local ID"},
            {"TerminalID", "Terminal ID"},
            {"MerchantName", "Merchant Name"},
            {"MerchantCategory", "Merchant Category"},
            {"EndTap", "End Tap"},
            {"OSETOPPSE", "OSE TO PPSE"}
        };

        public static readonly string[] ServiceTypeItemList = new string[]
        {
            "All services",
            "All services except PPSE",
            "PPSE",
            "Loyalty",
            "Offer",
            "Gift Card 1",
            "Private Label Card",
            "Cloud Based Wallet",
            "Mobile Marketing Platform",
            "Wallet Customer"
        };

        public static readonly string[,] VasPushDataReqNormalComboBox = new string[,]
        {
            { "VasMode", "VAS Mode" },
            { "Security", "Security" }
        };

        public static readonly string[,] VasPushDataReqNormal = new string[,]
        {
            {"CollectID", "Collect ID"},
            {"EndTap", "End Tap"}
        };

        public static readonly string[] VasPushDataReqNormalButtonTextBox = new string[]
        {
            "SmartTapCAP",
            "ServiceUsage",
            "ServiceUpdate",
            "NewService"
        };

        //Response--------------------------------------------------
        public static readonly string[,] InitRspNormal = new string[,]
        {
            { "ResponseCode", "Response Code" },
            { "ResponseMessage", "Response Message" },
            { "Sn", "SN" },
            { "ModelName", "Model Name" },
            { "OsVersion", "OS Version" },
            { "MacAddress", "MAC Address" },
            { "LinesPerScreen", "Lines Per Screen" },
            { "CharsPerLine", "Chars Per Line" },
            { "AppName", "App Name" },
            { "AppVersion", "App Version" },
            { "WifiMac", "Wifi MAC" },
            { "Touchscreen", "Touchscreen" },
        };

        public static readonly string[] GetVariableRspButtonNames = new string[]
        {
            "Normal",
            "Multi Merchant"
        };

        public static readonly string[,] GetVariableRspNormal = new string[,]
        {
            { "ResponseCode", "Response Code" },
            { "ResponseMessage", "Response Message" },
            {"VariableValue1", "Variable Value 1"},
            {"VariableValue2", "Variable Value 2"},
            {"VariableValue3", "Variable Value 3"},
            {"VariableValue4", "Variable Value 4"},
            {"VariableValue5", "Variable Value 5"}
        };

        public static readonly string[] SetVariableRspButtonNames = new string[]
        {
            "Normal",
            "Multi Merchant"
        };

        public static readonly string[,] SetVariableRspNormal = new string[,]
        {
            { "ResponseCode", "Response Code" },
            { "ResponseMessage", "Response Message" }
        };

        public static readonly string[,] GetSignatureRspNormal = new string[,]
        {
            { "ResponseCode", "Response Code" },
            { "ResponseMessage", "Response Message" },
            { "SignatureData", "Signature Data"}
        };

        public static readonly string[,] ResetRspNormal = new string[,]
        {
            { "ResponseCode", "Response Code" },
            { "ResponseMessage", "Response Message" }
        };

        public static readonly string[,] UpdateResourceFileRspNormal = new string[,]
        {
            { "ResponseCode", "Response Code" },
            { "ResponseMessage", "Response Message" }
        };

        public static readonly string[,] DoSignatureRspNormal = new string[,]
        {
            { "ResponseCode", "Response Code" },
            { "ResponseMessage", "Response Message" }
        };

        public static readonly string[,] DeleteImageRspNormal = new string[,]
        {
            { "ResponseCode", "Response Code" },
            { "ResponseMessage", "Response Message" }
        };

        public static readonly string[,] RebootRspNormal = new string[,]
        {
            { "ResponseCode", "Response Code" },
            { "ResponseMessage", "Response Message" }
        };

        public static readonly string[,] InputAccountRspNormal = new string[,]
        {
            { "ResponseCode", "Response Code" },
            { "ResponseMessage", "Response Message" },
            { "EntryMode", "Entry Mode" },
            { "Track1Data", "Track1 Data" },
            { "Track2Data", "Track2 Data" },
            { "Track3Data", "Track3 Data" },
            { "Pan", "PAN" },
            { "ExpiryDate", "Expiry Date" },
            { "QrCode", "QR Code" },
            { "Ksn", "KSN" },
            { "CardHolder", "Card Holder" },
        };

        public static readonly string[,] ResetMsrRspNormal = new string[,]
        {
            { "ResponseCode", "Response Code" },
            { "ResponseMessage", "Response Message" }
        };

        public static readonly string[,] CheckFileRspNormal = new string[,]
        {
            { "ResponseCode", "Response Code" },
            { "ResponseMessage", "Response Message" },
            { "CheckSum", "Check Sum" }
        };

        public static readonly string[,] SetSafParametersRspNormal = new string[,]
        {
            { "ResponseCode", "Response Code" },
            { "ResponseMessage", "Response Message" }
        };

        public static readonly string[,] ReprintRspNormal = new string[,]
        {
            { "ResponseCode", "Response Code" },
            { "ResponseMessage", "Response Message" }
        };

        public static readonly string[,] TokenAdministrativeRspNormal = new string[,]
        {
            { "ResponseCode", "Response Code" },
            { "ResponseMessage", "Response Message" },
            { "Token", "Token" },
            { "TokenSN", "Token SN" },
            { "MaskedPAN", "Masked PAN" },
            { "ExpiryDate", "Expiry Date" }
        };

        public static readonly string[,] VasSetMerchantParametersRspNormal = new string[,]
        {
            { "ResponseCode", "Response Code" },
            { "ResponseMessage", "Response Message" }
        };

        public static readonly string[,] VasPushDataRspNormal = new string[,]
        {
            { "ResponseCode", "Response Code" },
            { "ResponseMessage", "Response Message" }
        };

        public static readonly string[,] GetSafParametersRspNormal = new string[,]
{
            { "ResponseCode", "Response Code" },
            { "ResponseMessage", "Response Message" },
            { "SafMode", "SAF Mode" },
            { "StartDateTime", "Start Date Time" },
            { "EndDateTime", "End Date Time" },
            { "DurationInDays", "Duration In Days" },
            { "MaxNumber", "Max Number" },
            { "TotalCeilingAmount", "Total Ceiling Amount" },
            { "CeilingAmountPerCardType", "Ceiling Amount Per Card Type" },
            { "HaloPerCardType", "HALO Per Card Type" },
            { "UploadMode", "Upload Mode" },
            { "AutoUploadIntervalTime", "Auto Upload Interval Time" },
            { "DeleteSAFConfirmation", "Delete SAF Confirmation" }
};

        //Additional Information----------------------------
        public static readonly string[,] MultiMerchantNames = new string[,]
        {
            { "MultiMerchantId", "Multi Merchant ID" },
            { "MultiMerchantName", "Multi Merchant Name" }
        };
    }
}

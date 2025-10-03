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
    public static class FullIntegrationCommon
    {
        public static readonly string[] CommandNames = new string[]
        {
            "Get PIN Block",
            "Authorize Card",
            "Complete Online EMV",
            "Get EMV TLV Data",
            "Set EMV TLV Data",
            "Input Account with EMV"
        };
        //Request------------------------------------------------------------
        public static readonly string[,] GetPinBlockReqNormalComboBox = new string[,]
        {
            {"EdcType", "EDC Type"},
            {"TransactionType", "Transaction Type" }
        };

        public static readonly string[,] GetPinBlockReqNormal = new string[,]
        {
            { "AccountNumber", "Account Number"},
            { "EncryptionType", "Encryption Type"},
            { "KeySlot", "Key Slot"},
            { "PinMinLength", "PIN Min Length"},
            { "PinMaxLength", "PIN Max Length"},
            { "NullPinFlag", "Null PIN Flag"},
            { "PinAlgorithm", "PIN Algorithm"},
            { "Timeout", "Timeout"},
            { "Title", "Title"},
            { "PinpadType", "Pinpad Type"},
            { "KsnFlag", "KSN Flag" }
        };

        public static readonly string[] AuthorizeCardReqButtonNames = new string[]
        {
            "Normal",
            "Amount",
            "Terminal Configuration"
        };

        public static readonly string[,] AuthorizeCardReqNormal = new string[,]
        {
            {"MerchantDecision", "Merchant Decision"},
            {"PinEncryptionType", "PIN Encryption Type"},
            {"PinKeySlot", "PIN Key Slot"},
            {"PinMinLength", "PIN Min Length"},
            {"PinMaxLength", "PIN Max Length"},
            {"PinBypass", "PIN Bypass"},
            {"PinAlgorithm", "PIN Algorithm"},
            {"TagList", "Tag List"},
            {"Timeout", "Timeout"},
            {"ContinuousScreen", "Continuous Screen"},
            {"PinpadType", "Pinpad Type"},
            { "KsnFlag", "KSN Flag" }
        };

        public static readonly string[,] CompleteOnlineEmvReqNormal = new string[,]
        {
            {"OnlineAuthorizationResult", "Online Authorization Result"},
            {"ResponseCode", "Response Code"},
            {"AuthorizationCode", "Authorization Code"},
            {"IssuerAuthenticationData", "Issuer Authentication Data"},
            {"IssuerScript1", "Issuer Script 1"},
            {"IssuerScript2", "Issuer Script 2"},
            {"TagList", "Tag List"},
            {"ContinuousScreen", "Continuous Screen"}
        };

        public static readonly string[,] GetEmvTlvDataReqNormal = new string[,]
        {
            { "TlvType", "TLV Type"},
            { "TagList", "Tag List"}
        };

        public static readonly string[,] SetEmvTlvDataReqNormal = new string[,]
        {
            { "TlvType", "TLV Type"},
            { "EmvTlvData", "EMV TLV Data"}
        };

        public static readonly string[] InputAccountWithEmvReqButtonNames = new string[]
        {
            "Normal",
            "Amount",
            "Additional Prompts",
            "Terminal Configuration",
            "Custom MAC Information"
        };

        public static readonly string[,] InputAccountWithEmvReqNormalComboBox = new string[,]
        {
            {"EdcType", "EDC Type"},
            {"TransactionType", "TransactionType"}
        };

        public static readonly string[,] InputAccountWithEmvReqNormal = new string[,]
        {
            {"MagneticSwipeEntryFlag", "Magnetic Swipe Entry Flag"},
            {"ManualEntryFlag", "Manual Entry Flag"},
            {"ContactlessEntryFlag", "Contactless Entry Flag"},
            {"ContactEMVEntryFlag", "Contact EMV Entry Flag"},
            {"FallbackSwipeEntryFlag", "Fallback Swipe Entry Flag"},
            {"LaserScannerFlag", "Laser Scanner Flag"},
            {"FrontCameraFlag", "Front Camera Flag"},
            {"RearCameraFlag", "Rear Camera Flag"},
            {"EncryptionFlag", "Encryption Flag"},
            {"KeySlot", "Key Slot"},
            {"PaddingChar", "Padding Char"},
            {"TrackDataSentinel", "Track Data Sentinel"},
            {"MinAccountLength", "Min Account Length"},
            {"MaxAccountLength", "Max Account Length"},
            {"TagList", "Tag List"},
            {"Timeout", "Timeout"},
            {"ContinuousScreen", "Continuous Screen"},
            {"FallbackInsertEntryFlag", "Fallback Insert Entry Flag"},
            { "KsnFlag", "KSN Flag" },
            { "FallbackToManualEntryFlag", "Fallback To Manual Entry Flag" }
        };

        public static readonly string[,] AmountInfoReq = new string[,]
        {
            {"TransactionAmount", "Transaction Amount"},
            {"TipAmount", "Tip Amount"},
            {"CashBackAmount", "Cash Back Amount"},
            {"MerchantFee", "Merchant Fee"},
            {"TaxAmount", "Tax Amount"},
            {"FuelAmount", "Fuel Amount"},
            {"ServiceFee", "Service Fee"}
        };

        public static readonly string[,] AdditionalPromptsReq = new string[,]
        {
            {"ExpiryDatePrompt", "Expiry Date Prompt"},
            {"CvvPrompt", "CVV Prompt"},
            {"ZipCodePrompt", "Zip Code Prompt"}
        };

        public static readonly string[,] TerminalConfigurationReq = new string[,]
        {
            {"EMVKernelConfigurationSelection", "EMV Kernel Configuration Selection"},
            {"TransactionDate", "Transaction Date"},
            {"TransactionTime", "Transaction Time"},
            {"CurrencyCode", "Currency Code"},
            {"CurrencyExponent", "Currency Exponent"},
            {"MerchantCategoryCode", "Merchant Category Code"},
            {"TransactionSequenceNumber", "Transaction Sequence Number"}
        };

        public static readonly string[,] CustomMacInfoReq = new string[,]
        {
            {"KeyType", "Key Type"},
            {"WorkMode", "Work Mode"},
            {"KeySlot", "Key Slot"}
        };

        //Response------------------------------------------------------------
        public static readonly string[,] GetPinBlockRspNormal = new string[,]
        {
            { "ResponseCode", "Response Code" },
            { "ResponseMessage", "Response Message" },
            { "PinBlock", "PIN Block" },
            { "Ksn", "KSN" },
            {"PinpadType", "Pinpad Type"}
        };

        public static readonly string[,] AuthorizeCardRspNormal = new string[,]
        {
            {"ResponseCode", "Response Code"},
            {"ResponseMessage", "Response Message"},
            {"AuthorizationResult", "Authorization Result"},
            {"SignatureFlag", "Signature Flag"},
            {"PinBypassStatus", "PIN Bypass Status"},
            {"PinBlock", "PIN Block"},
            {"Ksn", "KSN"},
            {"EmvTlvData", "EMV TLV Data"},
            {"Cvm", "CVM"},
            {"PinpadType", "Pinpad Type"}
        };

        public static readonly string[,] CompleteOnlineEmvRspNormal = new string[,]
        {
            {"ResponseCode", "Response Code"},
            {"ResponseMessage", "Response Message"},
            {"AuthorizationResult", "Authorization Result"},
            {"EmvTlvData", "EMV TLV Data"},
            {"IssuerScriptResults", "Issuer Script Results"}
        };

        public static readonly string[,] GetEmvTlvDataRspNormal = new string[,]
        {
            { "ResponseCode", "Response Code" },
            { "ResponseMessage", "Response Message" },
            { "EmvTlvData", "EMV TLV Data" }
        };

        public static readonly string[,] SetEmvTlvDataRspNormal = new string[,]
        {
            { "ResponseCode", "Response Code" },
            { "ResponseMessage", "Response Message" },
            { "TagList", "Tag List" }
        };

        public static readonly string[] InputAccountWithEmvRspButtonNames = new string[]
        {
            "Normal",
            "Additional Account",
            "VAS",
            "Custom MAC Data"
        };

        public static readonly string[,] InputAccountWithEmvRspNormal = new string[,]
        {            
            {"ResponseCode", "Response Code"},
            {"ResponseMessage", "Response Message"},
            {"EntryMode", "Entry Mode"},
            {"Track1Data", "Track 1 Data"},
            {"Track2Data", "Track 2 Data"},
            {"Track3Data", "Track 3 Data"},
            {"Pan", "PAN"},
            {"MaskedPAN", "Masked PAN"},
            {"BarcodeType", "Barcode Type"},
            {"BarcodeData", "Barcode Data"},
            {"Ksn", "KSN"},
            {"Etb", "ETB"},
            {"ContactlessTransactionPath", "Contactless Transaction Path"},
            {"AuthorizationResult", "Authorization Result"},
            {"SignatureFlag", "Signature Flag"},
            {"OnlinePINFlag", "Online PIN Flag"},
            {"EmvTlvData", "EMV TLV Data"},
            {"EncryptedEmvTlvData", "Encrypted EMV TLV Data"},
            {"EncryptedSensitiveTlvData", "Encrypted Sensitive TLV Data"},
            {"CardHolder", "Card Holder"},
            {"Cvm", "CVM"},
            {"TxnResult", "TXN Result"},
            {"TxnPath", "TXN Path"},
            {"PinpadType", "Pinpad Type"},
            {"LuhnValidationResult", "Luhn Validation Result"},
            {"CustomEncryptedData", "Custom Encrypted Data"}
        };

        public static readonly string[,] AdditionalAccountRsp = new string[,]
        {
            {"ExpiryDate", "Expiry Date"},
            {"CardHolderName", "Card Holder Name"},
            {"ServiceCode", "Service Code"},
            {"CvvCode", "CVV Code"},
            {"ZipCode", "Zip Code"}
        };

        public static readonly string[,] VasInfoRsp = new string[,]
        {
            {"VasCode", "VAS Code"},
            {"VasData", "VAS Data"},
            {"NdefData", "NDEF Data"}
        };

        public static readonly string[,] CustomMacDataRsp = new string[,]
        {
            {"Data", "Data"},
            {"Ksn", "KSN"}
        };
    }
}

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
    public static class PedCommon
    {
        public static readonly string[] CommandNames = new string[]
        {
            "Session Key Injection",
            "MAC Calculation",
            "Get PED Information",
            "Increase KSN"
        };

        //Request-----------------------------------------------
        public static readonly string[,] SessionKeyInjectionReqNormal = new string[,]
        {
            {"SourceKeyType", "Source Key Type"},
            {"SourceKeyIndex", "Source Key Index"},
            {"DestinationKeyType", "Destination Key Type"},
            {"DestinationKeyIndex", "Destination Key Index"},
            {"DestinationKeyValue", "Destination Key Value"},
            {"CheckMode", "Check Mode"},
            {"CheckBuffer", "Check Buffer"}
        };

        public static readonly string[,] MacCalculationReqNormal = new string[,]
        {
            {"InputData", "Input Data"},
            {"EncryptionBitmap", "Encryption Bitmap"},
            {"MacKeySlot", "MAC Key Slot"},
            {"MacWorkMode", "MAC Work Mode"},
            {"EncryptionKeySlot", "Encryption Key Slot"},
            {"PaddingChar", "Padding Char"},
            {"MacKeyType", "MAC Key Type"},
            {"KsnFlag", "KSN Flag"}
        };

        public static readonly string[,] GetPedInfoReqNormal = new string[,]
        {
            {"KeyType", "Key Type"},
            {"KeySlot", "Key Slot"}
        };

        public static readonly string[,] IncreaseKsnReqNormal = new string[,]
        {
            {"KeyType", "Key Type"},
            {"KeySlot", "Key Slot"}
        };

        //Response--------------------------------------------
        public static readonly string[,] SessionKeyInjectionRspNormal = new string[,]
        {
            { "ResponseCode", "Response Code" },
            { "ResponseMessage", "Response Message" }
        };

        public static readonly string[,] MacCalculationRspNormal = new string[,]
        {
            { "ResponseCode", "Response Code" },
            { "ResponseMessage", "Response Message" },
            { "ResultData", "Result Data" },
            { "Ksn", "KSN" }
        };

        public static readonly string[,] GetPedInfoRspNormal = new string[,]
        {
            { "ResponseCode", "Response Code" },
            { "ResponseMessage", "Response Message" },
            { "MasterAvailableKeySlotCount", "Master Available Key Slot Count" },
            { "MessionAvailableKeySlotCount", "Mession Available Key Slot Count" },
            { "DukptAvailableKeySlotCount", "DUKPT Available Key Slot Count" },
            { "AesDukptAvailableKeySlotCount", "AES DUKPT Available Key Slot Count" },
            { "Tmk", "TMK" },
            { "Tpk", "TPK" },
            { "Tak", "TAK" },
            { "Tdk", "TDK" },
            { "DukptKey", "DUKPT Key" },
            { "AesDukptKey", "AES DUKPT Key" }
        };

        public static readonly string[,] IncreaseKsnRspNormal = new string[,]
        {
            { "ResponseCode", "Response Code" },
            { "ResponseMessage", "Response Message" },
            { "Ksn", "KSN" }
        };
    }
}

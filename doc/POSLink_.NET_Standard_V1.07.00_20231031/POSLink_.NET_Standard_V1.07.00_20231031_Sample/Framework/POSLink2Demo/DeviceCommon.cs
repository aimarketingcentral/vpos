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
    public static class DeviceCommon
    {
        public static readonly string[] CommandNames = new string[]
        {
            "Printer",
            "Card Insert Detection",
            "Camera Scan",
            "MIFARE Card"
        };

        //Request----------------------------------------------------------
        public static readonly string[,] PrinterReqNormal = new string[,]
        {
            {"PrintCopy", "Print Copy"},
            {"PrintData", "Print Data"}
        };

        public static readonly string[,] CameraScanReqNormal = new string[,]
        {
            {"Reader", "Reader"},
            {"Timeout", "Timeout"}
        };

        public static readonly string[,] MifareCardReqNormal = new string[,]
        {
            {"M1Command", "M1 Command"},
            {"BlockNo", "Block Number"},
            {"Password", "Password"},
            {"PasswordType", "Password Type"},
            {"BlockValue", "Block Value"},
            {"UpdateBlockNo", "Update Block Number"},
            {"Timeout", "Timeout"}
        };

        //Response--------------------------------------------------------
        public static readonly string[,] PrinterRspNormal = new string[,]
        {
            {"ResponseCode", "Response Code"},
            {"ResponseMessage", "Response Message"}
        };

        public static readonly string[,] CardInsertDetectionRspNormal = new string[,]
        {
            {"ResponseCode", "Response Code"},
            {"ResponseMessage", "Response Message"},
            {"CardInsertStatus", "Card Insert Status"}
        };

        public static readonly string[,] CameraScanRspNormal = new string[,]
        {
            {"ResponseCode", "Response Code"},
            {"ResponseMessage", "Response Message"},
            {"BarcodeData", "Barcode Data"},
            {"BarcodeType", "Barcode Type"}
        };

        public static readonly string[,] MifareCardRspNormal = new string[,]
        {
            {"ResponseCode", "Response Code"},
            {"ResponseMessage", "Response Message"},
            {"BlockValue", "Block Value"}
        };
    }
}

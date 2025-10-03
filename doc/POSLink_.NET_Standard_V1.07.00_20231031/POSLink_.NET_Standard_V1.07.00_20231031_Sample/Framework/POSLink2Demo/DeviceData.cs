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
    public class DeviceData
    {
        //Request-------------------------------------------------------------------
        public string[] PrinterReqNormalData { get; set; }
        public string[] CameraScanReqNormalData { get; set; }
        public string[] MifareCardReqNormalData { get; set; }
        //Response-------------------------------------------------------------------
        public string[] PrinterRspNormalData { get; set; }
        public string[] CardInsertDetectionRspNormalData { get; set; }
        public string[] CameraScanRspNormalData { get; set; }
        public string[] MifareCardRspNormalData { get; set; }

        private static DeviceData _deviceData;
        private DeviceData()
        {
            RequestClear();
            ResponseClear();
        }
        public static DeviceData GetDeviceData()
        {
            if(_deviceData == null)
            {
                _deviceData = new DeviceData();
            }
            return _deviceData;
        }

        public void RequestClear()
        {
            PrinterReqNormalData = new string[DeviceCommon.PrinterReqNormal.Length / 2];
            CameraScanReqNormalData = new string[DeviceCommon.CameraScanReqNormal.Length / 2];
            MifareCardReqNormalData = new string[DeviceCommon.MifareCardReqNormal.Length / 2];
        }

        public void ResponseClear()
        {
            PrinterRspNormalData = new string[DeviceCommon.PrinterRspNormal.Length / 2];
            CardInsertDetectionRspNormalData = new string[DeviceCommon.CardInsertDetectionRspNormal.Length / 2];
            CameraScanRspNormalData = new string[DeviceCommon.CameraScanRspNormal.Length / 2];
            MifareCardRspNormalData = new string[DeviceCommon.MifareCardRspNormal.Length / 2];
        }
    }
}

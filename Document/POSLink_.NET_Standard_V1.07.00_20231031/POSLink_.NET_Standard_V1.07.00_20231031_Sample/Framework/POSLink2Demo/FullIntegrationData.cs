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
    public class FullIntegrationData
    {
        //Request-----------------------------------------------------------------------
        public int EdcTypeIndex { get; set; }
        public int TransTypeIndex { get; set; }
        public string[] GetPinBlockReqNormalData { get; set; }
        public string[] AuthorizeCardReqNormalData { get; set; }
        public string[] CompleteOnlineEmvReqNormal { get; set; }
        public string[] GetEmvTlvDataReqNormalData { get; set; }
        public string[] SetEmvTlvDataReqNormalData { get; set; }
        public string[] InputAccountWithEmvReqNormal { get; set; }
        public string[] AmountInfoReqData { get; set; }
        public string[] AdditionalPromptsReqData { get; set; }
        public string[] TerminalConfigurationReqData { get; set; }
        public string[] CustomDataArray { get; set; }
        public string[] CustomMacInfoReqData { get; set; }
        public string[] CustomMacDataArray { get; set; }
        //Response---------------------------------------------------------------------
        public string[] GetPinBlockRspNormalData { get; set; }
        public string[] AuthorizeCardRspNormalData { get; set; }
        public string[] CompleteOnlineEmvRspNormal { get; set; }
        public string[] GetEmvTlvDataRspNormalData { get; set; }
        public string[] SetEmvTlvDataRspNormalData { get; set; }
        public string[] InputAccountWithEmvRspNormal { get; set; }
        public string[] AdditionalAccountRspData { get; set; }
        public string[] VasInfoRspData { get; set; }
        public string[] CustomMacDataRspData { get; set; }

        private static FullIntegrationData _fullIntegrationData;
        private FullIntegrationData()
        {
            RequestClear();
            ResponseClear();
        }
        public static FullIntegrationData GetFullIntegrationData()
        {
            if(_fullIntegrationData == null)
            {
                _fullIntegrationData = new FullIntegrationData();
            }
            return _fullIntegrationData;
        }

        public void RequestClear()
        {
            EdcTypeIndex = 0;
            TransTypeIndex = 0;
            GetPinBlockReqNormalData = new string[FullIntegrationCommon.GetPinBlockReqNormal.Length / 2];
            AuthorizeCardReqNormalData = new string[FullIntegrationCommon.AuthorizeCardReqNormal.Length / 2];
            CompleteOnlineEmvReqNormal = new string[FullIntegrationCommon.CompleteOnlineEmvReqNormal.Length / 2];
            GetEmvTlvDataReqNormalData = new string[FullIntegrationCommon.GetEmvTlvDataReqNormal.Length / 2];
            SetEmvTlvDataReqNormalData = new string[FullIntegrationCommon.SetEmvTlvDataReqNormal.Length / 2];
            InputAccountWithEmvReqNormal = new string[FullIntegrationCommon.InputAccountWithEmvReqNormal.Length / 2];
            AmountInfoReqData = new string[FullIntegrationCommon.AmountInfoReq.Length / 2];
            AdditionalPromptsReqData = new string[FullIntegrationCommon.AdditionalPromptsReq.Length / 2];
            TerminalConfigurationReqData = new string[FullIntegrationCommon.TerminalConfigurationReq.Length / 2];
            CustomDataArray = null;
            CustomMacInfoReqData = new string[FullIntegrationCommon.CustomMacInfoReq.Length / 2];
            CustomMacDataArray = null;
        }

        public void ResponseClear()
        {
            GetPinBlockRspNormalData = new string[FullIntegrationCommon.GetPinBlockRspNormal.Length / 2];
            AuthorizeCardRspNormalData = new string[FullIntegrationCommon.AuthorizeCardRspNormal.Length / 2];
            CompleteOnlineEmvRspNormal = new string[FullIntegrationCommon.CompleteOnlineEmvRspNormal.Length / 2];
            GetEmvTlvDataRspNormalData = new string[FullIntegrationCommon.GetEmvTlvDataRspNormal.Length / 2];
            SetEmvTlvDataRspNormalData = new string[FullIntegrationCommon.SetEmvTlvDataRspNormal.Length / 2];
            InputAccountWithEmvRspNormal = new string[FullIntegrationCommon.InputAccountWithEmvRspNormal.Length / 2];
            AdditionalAccountRspData = new string[FullIntegrationCommon.AdditionalAccountRsp.Length / 2];
            VasInfoRspData = new string[FullIntegrationCommon.VasInfoRsp.Length / 2];
            CustomMacDataRspData = new string[FullIntegrationCommon.CustomMacDataRsp.Length / 2];
        }
    }
}

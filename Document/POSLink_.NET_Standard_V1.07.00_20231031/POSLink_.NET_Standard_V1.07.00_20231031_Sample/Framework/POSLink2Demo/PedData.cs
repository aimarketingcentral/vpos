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
    public class PedData
    {
        //Request----------------------------------------------------
        public string[] SessionKeyInjectionReqNormalData { get; set; }
        public string[] MacCalculationReqNormalData { get; set; }
        public string[] GetPedInfoReqNormalData { get; set; }
        public string[] IncreaseKsnReqNormalData { get; set; }
        //Response--------------------------------------------------
        public string[] SessionKeyInjectionRspNormalData { get; set; }
        public string[] MacCalculationRspNormalData { get; set; }
        public string[] GetPedInfoRspNormalData { get; set; }
        public string[] IncreaseKsnRspNormalData { get; set; }

        private static PedData _pedData;
        private PedData()
        {
            RequestClear();
            ResponseClear();
        }
        public static PedData GetPedData()
        {
            if (_pedData == null)
            {
                _pedData = new PedData();
            }
            return _pedData;
        }

        public void RequestClear()
        {
            SessionKeyInjectionReqNormalData = new string[PedCommon.SessionKeyInjectionReqNormal.Length / 2];
            MacCalculationReqNormalData = new string[PedCommon.MacCalculationReqNormal.Length / 2];
            GetPedInfoReqNormalData = new string[PedCommon.GetPedInfoReqNormal.Length / 2];
            IncreaseKsnReqNormalData = new string[PedCommon.IncreaseKsnReqNormal.Length / 2];
        }

        public void ResponseClear()
        {
            SessionKeyInjectionRspNormalData = new string[PedCommon.SessionKeyInjectionRspNormal.Length / 2];
            MacCalculationRspNormalData = new string[PedCommon.MacCalculationRspNormal.Length / 2];
            GetPedInfoRspNormalData = new string[PedCommon.GetPedInfoRspNormal.Length / 2];
            IncreaseKsnRspNormalData = new string[PedCommon.IncreaseKsnRspNormal.Length / 2];
        }
    }
}

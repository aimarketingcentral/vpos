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
    public class ReportData
    {
        //Reqeust------------------------------
        public int EdcTypeIndex { get; set; }
        public int TransTypeIndex { get; set; }
        public int CardTypeIndex { get; set; }
        public string[] LocalDetailReportReqNormalData { get; set; }
        public string[] MultiMerchantReqData { get; set; }
        public string[] SafSummaryReportReqNormalData { get; set; }
        public string[] HostDetailReportReqNormalData { get; set; }
        //Response-----------------------------
        public string[] LocalTotalReportRspNormalData { get; set; }
        public string[] LocalDetailReportRspNormalData { get; set; }
        public string[] LocalFailedReportRspNormalData { get; set; }
        public string[] HostReportRspNormalData { get; set; }
        public string[] HistoryReportRspNormalData { get; set; }
        public string[] HistoryReportRspNormalButtonTextBoxData { get; set; }
        public string[] SafSummaryReportRspNormalData { get; set; }
        public string[] SafSummaryReportRspNormalButtonTextBoxData { get; set; }
        public string[] HostDetailReportRspNormalData { get; set; }
        public string[] HostInfoRspData { get; set; }
        public string[] AmountInfoRspData { get; set; }
        public string[] AccountInfoRspData { get; set; }
        public string[] TraceInfoRspData { get; set; }
        public string[] CashierInfoRspData { get; set; }
        public string[] CommercialInfoRspData { get; set; }
        public string[] CheckInfoRspData { get; set; }
        public string[] TorInfoRspData { get; set; }
        public string[] TotalDataRspData { get; set; }
        public string[] RestaurantRspData { get; set; }
        public string[] TransInfoRspData { get; set; }
        public string[] CardInfoRspData { get; set; }
        public string[] MultiMerchantRspData { get; set; }
        public string[] EmvTagRspData { get; set; }
        public string[] FleetCardRspData { get; set; }
        public POSLink2.Util.AddlRspData AddlRspDataResponse { get; set; }
        public string[] LineMessageRspData { get; set; }
        public string[] CreditTotalDataRspData { get; set; }
        public string[] DebitTotalDataRspData { get; set; }
        public string[] EbtTotalDataRspData { get; set; }
        public string[] GiftTotalDataRspData { get; set; }
        public string[] LoyaltyTotalDataRspData { get; set; }
        public string[] CashTotalDataRspData { get; set; }
        public string[] CheckTotalDataRspData { get; set; }
        public string[] TotalDataRspTextData { get; set; }
        public string[] HistoryReportTotalCountRspData { get; set; }
        public string[] HistoryReportTotalAmountRspData { get; set; }
        public string[] HistoryReportRspTextData { get; set; }
        public string[] SafReportTotalCountRspData { get; set; }
        public string[] SafReportTotalAmountRspData { get; set; }
        public string[] SafReportRspTextData { get; set; }
        public string[] AvsInfoRspData { get; set; }
        public string[] MotoECommerceInfoRspData { get; set; }

        private static ReportData _reportData;
        private ReportData()
        {
            RequestClear();
            ResponseClear();
        }
        public static ReportData GetReportData()
        {
            if(_reportData == null)
            {
                _reportData = new ReportData();
            }
            return _reportData;
        }

        public void RequestClear()
        {
            EdcTypeIndex = 0;
            TransTypeIndex = 0;
            CardTypeIndex = 0;
            LocalDetailReportReqNormalData = new string[ReportCommon.LocalDetailReportReqNormal.Length / 2];
            MultiMerchantReqData = new string[ReportCommon.MultiMerchantNames.Length / 2];
            SafSummaryReportReqNormalData = new string[ReportCommon.SafSummaryReportReqNormal.Length / 2];
            HostDetailReportReqNormalData = new string[ReportCommon.HostDetailReportReqNormal.Length / 2];
        }

        public void ResponseClear()
        {
            LocalTotalReportRspNormalData = new string[ReportCommon.LocalTotalReportRspNormal.Length / 2];
            LocalDetailReportRspNormalData = new string[ReportCommon.LocalDetailReportRspNormal.Length / 2];
            LocalFailedReportRspNormalData = new string[ReportCommon.LocalFailedReportRspNormal.Length / 2];
            HostReportRspNormalData = new string[ReportCommon.HostReportRspNormal.Length / 2];
            HistoryReportRspNormalData = new string[ReportCommon.HistoryReportRspNormal.Length / 2];
            HistoryReportRspNormalButtonTextBoxData = new string[ReportCommon.HistoryReportRspNormalButtonTextBox.Length];
            SafSummaryReportRspNormalData = new string[ReportCommon.SafSummaryReportRspNormal.Length / 2];
            SafSummaryReportRspNormalButtonTextBoxData = new string[ReportCommon.SafSummaryRspNormalButtonTextBox.Length];
            HostDetailReportRspNormalData = new string[ReportCommon.HostDetailReportRspNormal.Length / 2];
            HostInfoRspData = new string[ReportCommon.HostInfoRsp.Length / 2];
            AmountInfoRspData = new string[ReportCommon.AmountInfoRsp.Length / 2];
            AccountInfoRspData = new string[ReportCommon.AccountInfoRsp.Length / 2];
            TraceInfoRspData = new string[ReportCommon.TraceInfoRsp.Length / 2];
            CashierInfoRspData = new string[ReportCommon.CashierInfoRsp.Length / 2];
            CommercialInfoRspData = new string[ReportCommon.CommercialInfoRsp.Length / 2];
            CheckInfoRspData = new string[ReportCommon.CheckInfoRsp.Length / 2];
            TorInfoRspData = new string[ReportCommon.TorInfoRsp.Length / 2];
            TotalDataRspData = new string[Global.EdcType.Length / 2 - 1];
            RestaurantRspData = new string[ReportCommon.RestaurantNames.Length / 2];
            TransInfoRspData = new string[ReportCommon.ReportTransInfoNames.Length / 2];
            CardInfoRspData = new string[ReportCommon.CardInfoNames.Length / 2];
            MultiMerchantRspData = new string[ReportCommon.MultiMerchantNames.Length / 2];
            EmvTagRspData = new string[ReportCommon.ReportEmvTagNames.Length / 2];
            FleetCardRspData = new string[ReportCommon.FleetCardNames.Length / 2];
            AddlRspDataResponse = new POSLink2.Util.AddlRspData();
            LineMessageRspData = null;
            CreditTotalDataRspData = new string[ReportCommon.CreditTotalDataNames.Length / 2];
            DebitTotalDataRspData = new string[ReportCommon.DebitTotalDataNames.Length / 2];
            EbtTotalDataRspData = new string[ReportCommon.EbtTotalDataNames.Length / 2];
            GiftTotalDataRspData = new string[ReportCommon.GiftTotalDataNames.Length / 2];
            LoyaltyTotalDataRspData = new string[ReportCommon.LoyaltyTotalDataNames.Length / 2];
            CashTotalDataRspData = new string[ReportCommon.CashTotalDataNames.Length / 2];
            CheckTotalDataRspData = new string[ReportCommon.CheckTotalDataNames.Length / 2];
            TotalDataRspTextData = new string[Global.EdcType.Length / 2];
            HistoryReportTotalCountRspData = new string[ReportCommon.HistoryReportTotalCountNames.Length / 2];
            HistoryReportTotalAmountRspData = new string[ReportCommon.HistoryReportTotalAmountNames.Length / 2];
            HistoryReportRspTextData = new string[ReportCommon.HistoryReportRspNormalButtonTextBox.Length];
            SafReportTotalCountRspData = new string[ReportCommon.SafReportTotalCountNames.Length / 2];
            SafReportTotalAmountRspData = new string[ReportCommon.SafReportTotalAmountNames.Length / 2];
            SafReportRspTextData = new string[ReportCommon.SafSummaryRspNormalButtonTextBox.Length];
            AvsInfoRspData = new string[ReportCommon.AvsInfoRsp.Length / 2];
            MotoECommerceInfoRspData = new string[ReportCommon.MotoECommerceInfoRsp.Length / 2];
        }
    }
}

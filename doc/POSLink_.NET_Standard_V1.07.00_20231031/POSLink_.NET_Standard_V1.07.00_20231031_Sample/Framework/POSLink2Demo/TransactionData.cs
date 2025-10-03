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
    public class TransactionData
    {
        //Request
        public string[] AmountRequestInfoData { get; set; }
        public string[] AccountRequestInfoData { get; set; }
        public string[] CheckRequestInfoData { get; set; }
        public string[] TraceRequestInfoData { get; set; }
        public string[] AvsRequestInfoData { get; set; }
        public string[] CashierRequestInfoData { get; set; }
        public string[] CommercialRequestInfoData { get; set; }
        public string[] MotoECommerceRequestInfoData { get; set; }
        public string[] RestaurantRequestData { get; set; }
        public string[] HostGatewayRequestData { get; set; }
        public string[] TransactionBehaviorRequestData { get; set; }
        public string[] OriginalRequestData { get; set; }
        public int[] OriginalRequestComboBoxIndex { get; set; }
        public string[] MultiMerchantRequestData { get; set; }
        public string[] FleetCardRequestData { get; set; }
        public int TransactionTypeRequest { get; set; }
        public string PosEchoDataRequest { get; set; }
        public string ContinuousScreenRequest { get; set; }
        public POSLink2.Util.TaxDetail[] TaxDetailData { get; set; }
        public string TaxDetailTextData { get; set; }
        public POSLink2.Util.LineItemDetail[] LineItemDetailData { get; set; }
        public string LineItemDetailTextData { get; set; }
        public string[] LodgingInfoRequestData { get; set; }
        public string[] AutoRentalInfoRequestData { get; set; }
        public string[] HostCredentialInfoRequestData { get; set; }
        public POSLink2.Util.RoomRate[] RoomRates { get; set; }
        public POSLink2.Util.LodgingItem[] LodgingItems { get; set; }
        public POSLink2.Util.FleetData[] FleetDatas { get; set; }
        public POSLink2.Util.FsaData FsaData { get; set; }
        public POSLink2.Util.EwicData[] EwicDatas { get; set; }
        public int VehicleClassIdRequest { get; set; }
        public POSLink2.Util.ExtraChargeItem[] ExtraChargeItems { get; set; }
        public POSLink2.Util.TransactionPromptBitmap TransactionPromptBitmap { get; set; }

        //Response
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string TransactionTypeResponse { get; set; }
        public string[] HostResponseInfoData { get; set; }
        public string[] AmountResponseInfoData { get; set; }
        public string[] AccountResponseInfoData { get; set; }
        public string[] CheckResponseInfoData { get; set; }
        public string[] TraceResponseInfoData { get; set; }
        public string[] AvsResponseInfoData { get; set; }
        public string[] CommercialResponseInfoData { get; set; }
        public string[] MotoECommerceResponseInfoData { get; set; }
        public string[] VasResponseInfoData { get; set; }
        public string[] TorResponseInfoData { get; set; }
        public string[] RestaurantResponseData { get; set; }
        public string[] CardInfoResponseData { get; set; }
        public string[] PaymentTransInfoResponseData { get; set; }
        public POSLink2.Util.AddlRspData AddlRspDataResponse { get; set; }
        public string[] PaymentEmvTagResponseData { get; set; }
        public string[] MultiMerchantResponseData { get; set; }
        public string[] FleetCardResponseData { get; set; }
        public string[] HostCredentialResponseNormalData { get; set; }
        public string PayloadDataResponse { get; set; }

        private static TransactionData _transactionData = null;
        private TransactionData()
        {
            RequestClear();
            ResponseClear();
        }

        public static TransactionData GetTransactionData()
        {
            if(_transactionData == null)
            {
                _transactionData = new TransactionData();
            }
            return _transactionData;
        }

        public void RequestClear()
        {
            AmountRequestInfoData = new string[TransactionCommon.AmountRequestNames.Length/2];
            AccountRequestInfoData = new string[TransactionCommon.AccountRequestNames.Length/2];
            CheckRequestInfoData = new string[TransactionCommon.CheckRequestNames.Length/2];
            TraceRequestInfoData = new string[TransactionCommon.TraceRequestNames.Length/2];
            AvsRequestInfoData = new string[TransactionCommon.AvsRequestNames.Length/2];
            CashierRequestInfoData = new string[TransactionCommon.CashierRequestNames.Length/2];
            CommercialRequestInfoData = new string[TransactionCommon.CommercialRequestNames.Length/2];
            MotoECommerceRequestInfoData = new string[TransactionCommon.MotoECommerceRequestNames.Length/2];
            RestaurantRequestData = new string[TransactionCommon.RestaurantNames.Length/2];
            HostGatewayRequestData = new string[TransactionCommon.HostGatewayNames.Length/2];
            TransactionBehaviorRequestData = new string[TransactionCommon.TransactionBehaviorNames.Length/2];
            OriginalRequestData = new string[TransactionCommon.OriginalNames.Length/2];
            OriginalRequestComboBoxIndex = new int[TransactionCommon.OriginalLabelAndComboBoxNames.Length / 2];
            MultiMerchantRequestData = new string[TransactionCommon.MultiMerchantNames.Length/2];
            FleetCardRequestData = new string[TransactionCommon.FleetCardNames.Length/2];
            TransactionTypeRequest = 0;
            PosEchoDataRequest = "";
            ContinuousScreenRequest = "";
            TaxDetailData = null;
            TaxDetailTextData = "";
            LineItemDetailData = null;
            LineItemDetailTextData = "";
            LodgingInfoRequestData = new string[TransactionCommon.LodgingInfoRequestNames.Length / 2];
            AutoRentalInfoRequestData = new string[TransactionCommon.AutoRentalInfoRequestNames.Length / 2];
            HostCredentialInfoRequestData = new string[TransactionCommon.HostCredentialInfoRequestNames.Length / 2];
            RoomRates = null;
            LodgingItems = null;
            FleetDatas = null;
            FsaData = null;
            EwicDatas = null;
            VehicleClassIdRequest = 0;
            ExtraChargeItems = null;
            TransactionPromptBitmap = null;
        }

        public void ResponseClear()
        {
            ResponseCode = "";
            ResponseMessage = "";
            TransactionTypeResponse = "";
            HostResponseInfoData = new string[TransactionCommon.HostResponseNames.Length/2];
            AmountResponseInfoData = new string[TransactionCommon.AmountResponseNames.Length/2];
            AccountResponseInfoData = new string[TransactionCommon.AccountResponseNames.Length/2];
            CheckResponseInfoData = new string[TransactionCommon.CheckResponseNames.Length/2];
            TraceResponseInfoData = new string[TransactionCommon.TraceResponseNames.Length/2];
            AvsResponseInfoData = new string[TransactionCommon.AvsResponseNames.Length/2];
            CommercialResponseInfoData = new string[TransactionCommon.CommercialResponseNames.Length/2];
            MotoECommerceResponseInfoData = new string[TransactionCommon.MotoECommerceResponseNames.Length/2];
            VasResponseInfoData = new string[TransactionCommon.VasResponseNames.Length/2];
            TorResponseInfoData = new string[TransactionCommon.TorResponseNames.Length/2];
            RestaurantResponseData = new string[TransactionCommon.RestaurantNames.Length/2];
            CardInfoResponseData = new string[TransactionCommon.CardInfoNames.Length/2];
            PaymentTransInfoResponseData = new string[TransactionCommon.PaymentTransInfoNames.Length/2];
            POSLink2.Util.AddlRspData AddlRspDataResponse = new POSLink2.Util.AddlRspData();
            PaymentEmvTagResponseData = new string[TransactionCommon.PaymentEmvTagNames.Length/2];
            MultiMerchantResponseData = new string[TransactionCommon.MultiMerchantNames.Length/2];
            FleetCardResponseData = new string[TransactionCommon.FleetCardNames.Length/2];
            HostCredentialResponseNormalData = new string[TransactionCommon.HostCredentialResponseNames.Length / 2];
            PayloadDataResponse = "";
        }
    }
}

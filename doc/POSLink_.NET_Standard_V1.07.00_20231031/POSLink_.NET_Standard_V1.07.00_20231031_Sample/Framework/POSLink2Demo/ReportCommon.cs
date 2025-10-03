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
    public static class ReportCommon
    {
        //Request-------------------------------------------------
        public static readonly string[] LocalDetailReportReqButtonNames = new string[]
        {
            "Normal",
            "Multi Merchant"
        };

        public static readonly string[,] LocalTotalReportReqNormalComboBox = new string[,]
        {
            {"EdcType", "EDC Type"},
            {"CardType", "Card Type"}
        };

        public static readonly string[,] LocalDetailReportReqNormalComboBox = new string[,]
        {
            {"EdcType", "EDC Type" },
            {"TransactionType", "Transaction Type" },
            {"CardType", "Card Type" }
        };

        public static readonly string[,] LocalDetailReportReqNormal = new string[,]
        {
            {"RecordNumber", "Record Number"},
            {"OrigRefNum", "Orig Ref Num"},
            {"AuthCode", "Auth Code"},
            {"EcrRefNum", "ECR Ref Num"},
            {"GlobalUid", "Global UID"},
            {"LastTransaction", "Last Transaction"},
            {"TransactionResultType", "Transaction Result Type"}
        };

        public static readonly string[,] SafSummaryReportReqNormal = new string[,]
        {
            {"SafIndicator", "SAF Indicator"}
        };

        public static readonly string[,] HostDetailReportReqNormalComboBox = new string[,]
        {
            {"EdcType", "EDC Type" },
            {"TransactionType", "Transaction Type" },
            {"CardType", "Card Type" }
        };

        public static readonly string[,] HostDetailReportReqNormal = new string[,]
        {
            {"AuthCode", "Auth Code"},
            {"EcrTransId", "ECR Transaction ID"},
            {"HRef", "HRef"}
        };
        //Response----------------------------------------------
        public static readonly string[] LocalTotalReportRspButtonNames = new string[]
        {
            "Normal",
            "Totals"
        };

        public static readonly string[] LocalDetailReportRspButtonNames = new string[]
        {
            "Normal",
            "Host",
            "Amount",
            "Account",
            "Trace",
            "Cashier",
            "Commercial",
            "Check",
            "TOR",
            "Restaurant",
            "Transaction",
            "Card",
            "Multi Merchant",
            "EMV Tag",
            "Fleet Card"
        };

        public static readonly string[] LocalFailedReportRspButtonNames = new string[]
        {
            "Normal",
            "Host",
            "Amount",
            "Account",
            "Trace"
        };

        public static readonly string[] HostDetailReportRspButtonNames = new string[]
        {
            "Normal",
            "Host",
            "Amount",
            "Account",
            "Trace",
            "Cashier",
            "Commercial",
            "Check",
            "TOR",
            "AVS",
            "MOTO/E Commerce"
        };

        public static readonly string[,] LocalTotalReportRspNormal = new string[,]
        {
            { "ResponseCode", "Response Code" },
            { "ResponseMessage", "Response Message" },
            { "EdcType", "EDC Type" }
        };

        public static readonly string[,] LocalDetailReportRspNormal = new string[,]
        {
            { "ResponseCode", "Response Code" },
            { "ResponseMessage", "Response Message" },
            { "TotalRecord", "Total Record" },
            { "RecordNumber", "Record Number" },
            { "EdcType", "EDC Type" },
            { "TransactionType", "Trans Type" },
            { "OriginalTransactionType", "Original Trans Type" }
        };

        public static readonly string[,] LocalFailedReportRspNormal = new string[,]
        {
            { "ResponseCode", "Response Code" },
            { "ResponseMessage", "Response Message" },
            { "EdcType", "EDC Type" },
            {"TransactionType", "Transaction Type" }
        };

        public static readonly string[,] HostReportRspNormal = new string[,]
        {
            { "ResponseCode", "Response Code" },
            { "ResponseMessage", "Response Message" },
            { "LineNumber", "Line Number" },
            { "ReportType", "Report Type" },
            { "TimeStamp", "Time Stamp" }
        };

        public static readonly string[,] HistoryReportRspNormal = new string[,]
        {
            { "ResponseCode", "Response Code" },
            { "ResponseMessage", "Response Message" },
            { "TimeStamp", "Time Stamp" },
            { "BatchNumber", "Batch Number" }
        };

        public static readonly string[] HistoryReportRspNormalButtonTextBox = new string[]
        {
            "TotalCount",
            "TotalAmount"
        };

        public static readonly string[,] SafSummaryReportRspNormal = new string[,]
        {
            { "ResponseCode", "Response Code" },
            { "ResponseMessage", "Response Message" }
        };

        public static readonly string[] SafSummaryRspNormalButtonTextBox = new string[]
        {
            "TotalCount",
            "TotalAmount"
        };

        public static readonly string[,] HostDetailReportRspNormal = new string[,]
        {
            { "ResponseCode", "Response Code" },
            { "ResponseMessage", "Response Message" },
            { "EdcType", "EDC Type" },
            { "TransactionType", "Trans Type" },
            { "OriginalTransactionType", "Original Trans Type" }
        };

        //Show Response Used
        public static readonly string[,] CreditTotalDataNames = new string[,]
        {
            {"SaleCount", "Sale Count"},
            {"SaleAmount", "Sale Amount"},
            {"ForcedCount", "Forced Count"},
            {"ForcedAmount", "Forced Amount"},
            {"ReturnCount", "Return Count"},
            {"ReturnAmount", "Return Amount"},
            {"AuthCount", "Auth Count"},
            {"AuthAmount", "Auth Amount"},
            {"PostauthCount", "Postauth Count"},
            {"PostauthAmount", "Postauth Amount"}
        };

        public static readonly string[,] DebitTotalDataNames = new string[,]
        {
            {"SaleCount", "Sale Count"},
            {"SaleAmount", "Sale Amount"},
            {"ReturnCount", "Return Count"},
            {"ReturnAmount", "Return Amount"},
            {"AuthCount", "Auth Count"},
            {"AuthAmount", "Auth Amount"},
            {"PostauthCount", "Postauth Count"},
            {"PostauthAmount", "Postauth Amount"}
        };

        public static readonly string[,] EbtTotalDataNames = new string[,]
        {
            {"SaleCount", "Sale Count"},
            {"SaleAmount", "Sale Amount"},
            {"ReturnCount", "Return Count"},
            {"ReturnAmount", "Return Amount"},
            {"WithdrawalCount", "Withdrawal Count"},
            {"WithdrawalAmount", "Withdrawal Amount"},
            {"AuthCount", "Auth Count"},
            {"AuthAmount", "Auth Amount"},
            {"PostauthCount", "Postauth Count"},
            {"PostauthAmount", "Postauth Amount"}
        };

        public static readonly string[,] GiftTotalDataNames = new string[,]
        {
            {"SaleCount", "Sale Count"},
            {"SaleAmount", "Sale Amount"},
            {"AuthCount", "Auth Count"},
            {"AuthAmount", "Auth Amount"},
            {"PostauthCount", "Postauth Count"},
            {"PostauthAmount", "Postauth Amount"},
            {"ActivateCount", "Activate Count"},
            {"ActivateAmount", "Activate Amount"},
            {"IssueCount", "Issue Count"},
            {"IssueAmount", "Issue Amount"},
            {"AddCount", "Add Count"},
            {"AddAmount", "Add Amount"},
            {"ReturnCount", "Return Count"},
            {"ReturnAmount", "Return Amount"},
            {"ForcedCount", "Forced Count"},
            {"ForcedAmount", "Forced Amount"},
            {"CashoutCount", "Cashout Count"},
            {"CashoutAmount", "Cashout Amount"},
            {"DeactivateCount", "Deactivate Count"},
            {"DeactivateAmount", "Deactivate Amount"},
            {"AdjustCount", "Adjust Count"},
            {"AdjustAmount", "Adjust Amount"}
        };

        public static readonly string[,] LoyaltyTotalDataNames = new string[,]
        {
            {"RedeemCount", "Redeem Count"},
            {"RedeemAmount", "Redeem Amount"},
            {"IssueCount", "Issue Count"},
            {"IssueAmount", "Issue Amount"},
            {"AddCount", "Add Count"},
            {"AddAmount", "Add Amount"},
            {"ReturnCount", "Return Count"},
            {"ReturnAmount", "Return Amount"},
            {"ForcedCount", "Forced Count"},
            {"ForcedAmount", "Forced Amount"},
            {"ActivateCount", "Activate Count"},
            {"ActivateAmount", "Activate Amount"},
            {"DeactivateCount", "Deactivate Count"},
            {"DeactivateAmount", "Deactivate Amount"}
        };

        public static readonly string[,] CashTotalDataNames = new string[,]
        {
            {"SaleCount", "Sale Count"},
            {"SaleAmount", "Sale Amount"},
            {"ReturnCount", "Return Count"},
            {"ReturnAmount", "Return Amount"}
        };

        public static readonly string[,] CheckTotalDataNames = new string[,]
        {
            {"SaleCount", "Sale Count"},
            {"SaleAmount", "Sale Amount"},
            {"AdjustCount", "Adjust Count"},
            {"AdjustAmount", "Adjust Amount"}
        };

        public static readonly string[,] HistoryReportTotalCountNames = new string[,]
        {
            {"CreditCount", "Credit Count"},
            {"DebitCount", "Debit Count"},
            {"EbtCount", "EBT Count"},
            {"GfitCount", "Gift Count"},
            {"LoyaltyCount", "Loyalty Count"},
            {"CashCount", "Cash Count"},
            {"CheckCount", "Check Count"}
        };

        public static readonly string[,] HistoryReportTotalAmountNames = new string[,]
        {
            {"CreditAmount", "Credit Amount"},
            {"DebitAmount", "Debit Amount"},
            {"EbtAmount", "EBT Amount"},
            {"GfitAmount", "Gift Amount"},
            {"LoyaltyAmount", "Loyalty Amount"},
            {"CashAmount", "Cash Amount"},
            {"CheckAmount", "Check Amount"}
        };

        public static readonly string[,] SafReportTotalCountNames = new string[,]
        {
            {"VisaCount", "Visa Count"},
            {"MasterCardCount", "Master Card Count"},
            {"AmexCount", "Amex Count"},
            {"DinersCount", "Diners Count"},
            {"DiscoverCount", "Discover Count"},
            {"JCBCount", "JCB Count"},
            {"enRouteCount", "enRoute Count"},
            {"ExtendedCount", "Extended Count"},
            {"VisaFleetCount", "Visa Fleet Count"},
            {"MasterCardFleetCount", "Master Card Fleet Count"},
            {"FleetOneCount", "Fleet One Count"},
            {"FleetwideCount", "Fleetwide Count"},
            {"FulemanCount", "Fuleman Count"},
            {"GascardCount", "Gascard Count"},
            {"VoyagerCount", "Voyager Count"},
            {"WrightExpressCount", "Wright Express Count"},
            {"InteracCount", "Interac Count"},
            {"CupCount", "CUP Count"},
            {"MaestroCount", "Maestro Count"},
            {"SinclairCount", "Sinclair Count"}
        };

        public static readonly string[,] SafReportTotalAmountNames = new string[,]
        {
            {"VisaAmount", "Visa Amount"},
            {"MasterCardAmount", "Master Card Amount"},
            {"AmexAmount", "Amex Amount"},
            {"DinersAmount", "Diners Amount"},
            {"DiscoverAmount", "Discover Amount"},
            {"JCBAmount", "JCB Amount"},
            {"enRouteAmount", "enRoute Amount"},
            {"ExtendedAmount", "Extended Amount"},
            {"VisaFleetAmount", "Visa Fleet Amount"},
            {"MasterCardFleetAmount", "Master Card Fleet Amount"},
            {"FleetOneAmount", "Fleet One Amount"},
            {"FleetwideAmount", "Fleetwide Amount"},
            {"FulemanAmount", "Fuleman Amount"},
            {"GascardAmount", "Gascard Amount"},
            {"VoyagerAmount", "Voyager Amount"},
            {"WrightExpressAmount", "Wright Express Amount"},
            {"InteracAmount", "Interac Amount"},
            {"CupAmount", "CUP Amount"},
            {"MaestroAmount", "Maestro Amount"},
            {"SinclairAmount", "Sinclair Amount"}
        };

        public static readonly string[,] HostInfoRsp = new string[,]
        {
            { "HostResponseCode", "Host Response Code" },
            { "HostResponseMessage", "Host Response Message" },
            { "AuthCode", "Auth Code" },
            { "HostRefNum", "Host Ref Num" },
            { "TraceNumber", "Trace Number" },
            { "BatchNumber", "Batch Number" },
            { "TransactionIdentifier", "Transaction Identifier" },
            { "GatewayTransactionID", "Gateway Transaction ID" },
            { "HostDetailedMessage", "Host Detailed Message" },
            { "TransactionIntegrityClass", "Transaction Integrity Class" },
            { "RetrievalReferenceNumber", "Retrieval Reference Number" },
            { "IssuerResponseCode", "Issuer Response Code" },
            { "PaymentAccountRefId", "Payment Account Reference ID" }
        };

        public static readonly string[,] TorInfoRsp = new string[,]
        {
            { "RecordType", "Record Type" },
            { "ReversalTimeStamp", "Reversal Time Stamp" },
            { "HostResponseCode", "Host Response Code" },
            { "HostResponseMessage", "Host Response Message" },
            { "HostRefNum", "Host Reference Number" },
            { "GatewayTransactionID", "Gateway Transaction ID" },
            { "OrigAmount", "Orig Amount" },
            { "MaskedPan", "Masked PAN" },
            { "BatchNo", "Batch Number" },
            { "ReversalAuthCode", "Reversal Auth Code" },
            { "OrigTransType", "Orig Trans Type" },
            { "OrigTransDateTime", "Orig Trans Date Time" },
            { "OrigTransAuthCode", "Orig Trans Auth Code" },
        };

        public static readonly string[,] AmountInfoRsp = new string[,]
        {
            { "ApproveAmount", "Approve Amount" },
            { "AmountDue", "Amount Due" },
            { "TipAmount", "Tip Amount" },
            { "CashBackAmount", "Cash Back Amount" },
            { "MerchantFee", "Merchant Fee" },
            { "TaxAmount", "Tax Amount" },
            { "Balance1", "Balance1" },
            { "Balance2", "Balance2" },
            { "ServiceFee", "Service Fee" },
            { "TransactionRemainingAmount", "Transaction Remaining Amount" },
            { "ApprovedTipAmount", "Approved Tip Amount" },
            { "ApprovedCashBackAmount", "Approved Cash Back Amount" },
            { "ApprovedMerchantFee", "Approved Merchant Fee" },
            { "ApprovedTaxAmount", "Approved Tax Amount" }
        };

        public static readonly string[,] AccountInfoRsp = new string[,]
        {
            { "Account", "Account" },
            { "EntryMode", "Entry Mode" },
            { "ExpireDate", "Expire Date" },
            { "EbtType", "EbtType" },
            { "VoucherNumber", "Voucher Number" },
            { "NewAccountNo", "New Account Number" },
            { "CardType", "Card Type" },
            { "CardHolder", "Card Holder" },
            { "CvdApprovalCode", "CVD Approval Code" },
            { "CvdMessage", "CVD Message" },
            { "CardPresentIndicator", "Card Present Indicator" },
            { "GiftCardType", "Gift Card Type" },
            { "DebitAccountType", "Debit Account Type" },
            { "DebitAccountType", "Debit Account Type" },
            { "HostAccount", "Host Account" },
            { "HostCardType", "Host Card Type" },
            { "Track1Data", "Track1 Data" },
            { "Track2Data", "Track2 Data" },
            { "Track3Data", "Track3 Data" }
        };

        public static readonly string[,] TraceInfoRsp = new string[,]
        {
            { "OrigRefNum", "Orig Ref Num" },
            { "EcrRefNum", "ECR Reference Number" },
            { "TimeStamp", "Time Stamp" },
            { "InvoiceNumber", "Invoice Number" },
            { "PaymentService2000", "Payment Service 2000" },
            { "AuthorizationResponse", "Authorization Response" },
            { "EcrTransId", "ECR Trans ID" },
            { "HostTimeStamp", "Host Time Stamp" }
        };

        public static readonly string[,] CashierInfoRsp = new string[,]
        {
            { "ClerkID", "Clerk ID" },
            { "ShiftID", "Shift ID" }
        };

        public static readonly string[,] CommercialInfoRsp = new string[,]
        {
            { "PoNumber", "PO Number" },
            { "CustomerCode", "Customer Code" },
            { "TaxExempt", "Tax Exempt" },
            { "TaxExemptID", "Tax Exempt ID" },
            { "MerchantTaxID", "Merchant Tax ID" },
            { "DestinationZipCode", "Destination Zip Code" },
            { "ProductDescription", "Product Description" }
        };

        public static readonly string[,] CheckInfoRsp = new string[,]
        {
            { "SaleType", "Sale Type" },
            { "RoutingNumber", "Routing Number" },
            { "AccountNumber", "Account Number" },
            { "CheckNumber", "Check Number" },
            { "CheckType", "Check Type" },
            { "IdType", "ID Type" },
            { "IdValue", "ID Value" },
            { "Birth", "Birth" },
            { "PhoneNumber", "Phone Number" },
            { "ZipCode", "Zip Code" }
        };

        public static readonly string[,] AvsInfoRsp = new string[,]
        {
            { "AvsApprovalCode", "AVS Approval Code" },
            { "AvsMessage", "AVS Message" },
            { "ZipCode", "Zip Code" },
            { "Address1", "Address1" },
            { "Address2", "Address2" }
        };

        public static readonly string[,] MotoECommerceInfoRsp = new string[,]
        {
            { "Mode", "Mode" },
            { "TransactionType", "Transaction Type" },
            { "SecureType", "Secure Type" },
            { "OrderNumber", "Order Number" },
            { "Installments", "Installments" },
            { "CurrentInstallment", "Current Installment" }
        };

        //Additional info---------------------------------------
        public static readonly string[,] RestaurantNames = new string[,]
        {
            { "TableNumber", "Table Number" },
            { "GuestNumber", "Guest Number" },
            { "TicketNumber", "Ticket Number" }
        };

        public static readonly string[,] ReportTransInfoNames = new string[,]
        {
            { "DiscountAmount", "Discount Amount" },
            { "ChargedAmount", "Charged Amount" },
            { "SignatureStatus", "Signature Status" },
            { "Fps", "FPS" },
            { "FpsSignature","FPS Signature" },
            { "FpsReceipt", "FPS Receipt" },
            { "Token", "Token" },
            { "HRef", "HRef" },
            { "SN", "SN" },
            { "SettlementDate", "Settlement Date" },
            { "HostEchoData", "Host Echo Data" },
            { "PinStatusNum", "PIN Status Number" },
            { "ValidationCode", "Validation Code" },
            { "UserLanguageStatus", "User Language Status" },
            { "GlobalUid", "Global UID" }
            //"AddlRspData", this is a class not string.
        };

        public static readonly string[,] CardInfoNames = new string[,]
        {
            { "CardBin", "Card BIN" },
            { "NewCardBin", "New Card BIN" },
            { "ProgramType", "Program Type" },
            { "HostProgramType", "Host Program Type" }
        };

        public static readonly string[,] MultiMerchantNames = new string[,]
        {
            { "MultiMerchantId", "Multi Merchant ID" },
            { "MultiMerchantName", "Multi Merchant Name" }
        };

        public static readonly string[,] ReportEmvTagNames = new string[,]
        {
            { "Tc", "TC" },
            { "Tvr", "TVR" },
            { "Aid", "AID" },
            { "Tsi", "TSI" },
            { "Atc", "ATC" },
            { "AppLabel", "AppLabel" },
            { "AppPreferName", "App Prefer Name" },
            { "Iad", "IAD" },
            { "Arc", "ARC" },
            { "Cid", "CID" },
            { "Cvm", "CVM" },
            { "Arqc", "ARQC" },
            { "PanSequenceNumber", "PAN Sequence Number" }
        };

        public static readonly string[,] FleetCardNames = new string[,]
        {
            { "Odometer", "Odometer" },
            { "VehicleNumber", "Vehicle Number" },
            { "JobNumber", "Job Number" },
            { "DriverId", "Driver ID" },
            { "EmployeeNumber", "Employee Number" },
            { "LicenseNumber", "License Number" },
            { "JobId", "Job ID" },
            { "DepartmentNumber", "Department Number" },
            { "CustomerData", "Customer Data" },
            { "UserId", "User ID" },
            { "VehicleId", "Vehicle ID" },
            { "FleetPromptCode", "Fleet Prompt Code" }
        };
    }
}

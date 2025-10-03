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
    public static class TransactionCommon
    {
        public static readonly string[] CommandNames = new string[]
        {
            "Do Credit",
            "Do Debit",
            "Do EBT",
            "Do Gift",
            "Do Loyalty",
            "Do Cash",
            "Do Check"
        };
        //Request----------------------------------------------------------------------------------------------
        public static readonly string[] DoCreditRequestButtonNames = new string[]
        {
            "Normal",
            "Amount",
            "Account",
            "Trace",
            "AVS",
            "Cashier",
            "Commercial",
            "MOTO/E Commerce",
            "Restaurant",
            "Host Gateway",
            "Transaction Behavior",
            "Original",
            "Multi Merchant",
            "Fleet Card",
            "Lodging",
            "Auto Rental",
            "HostCredential"
        };

        public static readonly string[] DoDebitRequestButtonNames = new string[]
        {
            "Normal",
            "Amount",
            "Account",
            "Trace",
            "Cashier",
            "Restaurant",
            "Host Gateway",
            "Transaction Behavior",
            "Original",
            "Multi Merchant",
            "Fleet Card",
            "Lodging",
            "HostCredential"
        };

        public static readonly string[] DoEbtRequestButtonNames = new string[]
        {
            "Normal",
            "Amount",
            "Account",
            "Trace",
            "Cashier",
            "Restaurant",
            "Host Gateway",
            "Transaction Behavior",
            "Original",
            "Multi Merchant",
            "Fleet Card",
            "HostCredential"
        };

        public static readonly string[] DoCashRequestButtonNames = new string[]
        {
            "Normal",
            "Amount",
            "Trace",
            "Cashier",
            "Restaurant",
            "Host Gateway",
            "Transaction Behavior",
            "Original",
            "Multi Merchant",
            "Fleet Card",
            "HostCredential"
        };

        public static readonly string[] DoCheckRequestButtonNames = new string[]
        {
            "Normal",
            "Amount",
            "Check",
            "Trace",
            "Cashier",
            "Restaurant",
            "Host Gateway",
            "Transaction Behavior",
            "Original",
            "Multi Merchant",
            "Fleet Card",
            "HostCredential"
        };

        public static readonly string[,] NormalRequestNames = new string[,]
        {
            { "TransactionAmount", "Transaction Amount"},
            { "CashBackAmount", "Cash Back Amount" },
            { "EcrRefNum", "ECR Ref Num" },
            { "PosEchoData", "POS Echo Data" },
            { "ContinuousScreen", "Continuous Screen" }
        };

        public static readonly string[,] AmountRequestNames = new string[,]
        {
            { "TransactionAmount", "Transaction Amount" },
            { "TipAmount", "Tip Amount" },
            { "CashBackAmount", "Cash Back Amount" },
            { "MerchantFee", "Merchant Fee" },
            { "TaxAmount", "Tax Amount" },
            { "FuelAmount", "Fuel Amount" },
            { "ServiceFee", "Service Fee" }
        };

        public static readonly string[,] AccountRequestNames = new string[,]
        {
            { "Account", "Account" },
            { "CardExpireDate", "Card Expire Date" },
            { "CvvCode", "CVV Code" },
            { "EbtType", "EBT Type" },
            { "VoucherNumber", "Voucher Number" },
            { "FirstName", "First Name" },
            { "LastName", "Last Name" },
            { "CountryCode", "Country Code" },
            { "StateCode", "State Code" },
            { "CityName", "City Name" },
            { "EmailAddress", "Email Address" },
            { "GiftCardType", "Gift Card Type" },
            { "CvvBypassReason", "CVV Bypass Reason" },
            { "GiftTenderType", "Gift Tender Type" }
        };

        public static readonly string[,] CheckRequestNames = new string[,]
        {
            { "SaleType", "Sale Type" },
            { "RoutingNumber", "Routing Number" },
            { "Account", "Account" },
            { "Number", "Number" },
            { "Type", "Type" },
            { "IdType", "ID Type" },
            { "IdValue", "ID Value" },
            { "Birth", "Birth" },
            { "PhoneNumber", "Phone Number" },
            { "ZipCode", "Zip Code" }
        };

        public static readonly string[,] TraceRequestNames = new string[,]
        {
            { "EcrRefNum", "ECR Ref Number" },
            { "InvoiceNumber", "Invoice Number" },
            { "AuthCode", "Auth Code" },
            { "OrigRefNum", "Orig Ref Number" },
            { "TimeStamp", "Time Stamp" },
            { "EcrTransID", "ECR Trans ID" },
            { "OrigECRRefNum", "Orig ECR Ref Number" },
            { "OrigTraceNum", "Orig Trace Number" },
            { "OrigTransactionIdentifier", "Orig Transaction Identifier" }
        };

        public static readonly string[,] AvsRequestNames = new string[,]
        {
            { "ZipCode", "Zip Code" },
            { "Address", "Address" },
            { "Address2", "Address2" }
        };

        public static readonly string[,] CashierRequestNames = new string[,]
        {
            { "ClerkID", "Clerk ID" },
            { "ShiftID", "Shift ID" }
        };

        public static readonly string[,] CommercialRequestNames = new string[,]
        {
            { "PoNumber", "PO Number" },
            { "CustomerCode", "Customer Code" },
            { "TaxExempt", "Tax Exempt" },
            { "TaxExemptId", "Tax Exempt ID" },
            { "MerchantTaxId", "Merchant Tax ID" },
            { "DestinationZipCode", "Destination Zip Code" },
            { "ProductDescription", "Product Description" },
            { "ShipFromZipCode", "Ship From Zip Code" },
            { "DestinationCountryCode", "Destination Country Code" },
            { "SummaryCommodityCode", "Summary Commodity Code" },
            { "DiscountAmount", "Discount Amount" },
            { "FreightAmount", "Freight Amount" },
            { "DutyAmount", "Duty Amount" },
            { "OrderDate", "Order Date" },
            //"TaxDetails",
            //"LineItemDetails"
        };

        public static readonly string[,] MotoECommerceRequestNames = new string[,]
        {
            { "Mode", "Mode" },
            { "TransactionType", "Transaction Type" },
            { "SecureType", "Secure Type" },
            { "OrderNumber", "Order Number" },
            { "Installments", "Installments" },
            { "CurrentInstallment", "Current Installment" }
        };

        public static readonly string[,] LodgingInfoRequestNames = new string[,]
        {
            { "RoomNumber", "Room Number" },
            { "FolioNumber", "Folio Number" },
            { "ChargeType", "Charge Type" },
            { "NoShowFlag", "No Show Flag" },
            { "CheckInDate", "Check In Date" },
            { "CheckOutDate", "Check Out Date" },
            { "SpecialProgramCode", "Special Program Code" },
            { "DepartureAdjustedAmount", "Departure Adjusted Amount" }
        };

        public static readonly string[,] AutoRentalInfoRequestNames = new string[,]
        {
            { "AgreementNumber", "Agreement Number" },
            { "DailyRate", "Daily Rate" },
            { "RentalDuration", "Rental Duration" },
            { "InsuranceAmount", "Insurance Amount" },
            { "AllocatedMiles", "Allocated Miles" },
            { "MileRate", "Mile Rate" },
            { "Name", "Name" },
            { "DriverLicenseNumber", "Driver License Number" },
            { "RentalProgramType", "Rental Program Type" },
            { "PickupLocationName", "Pickup Location Name" },
            { "PickupCity", "Pickup City" },
            { "PickupState", "Pickup State" },
            { "PickupCountryCode", "Pickup Country Code" },
            { "PickupDatetime", "Pickup Datetime" },
            { "ReturnLocation", "Return Location" },
            { "ReturnCity", "Return City" },
            { "ReturnState", "Return State" },
            { "ReturnCountryCode", "Return Country Code" },
            { "ReturnDatetime", "Return Datetime" },
            { "TotalMiles", "Total Miles" },
            { "CustomerTaxID", "Customer Tax ID" },
            { "ExtraChargesAmount", "Extra Charges Amount" },
        };

        public static readonly string[,] HostCredentialInfoRequestNames = new string[,]
        {
            { "Mid", "MID" },
            { "ServiceUser", "Service User" },
            { "ServicePassword", "Service Password" }
        };

        //Response----------------------------------------------------------------------------------------------------------
        public static readonly string[] DoCreditResponseButtonNames = new string[]
        {
            "Normal",
            "Host",
            "Amount",
            "Account",
            "Trace",
            "AVS",
            "Commercial",
            "MOTO/E Commerce",
            "VAS",
            "TOR",
            "Restaurant",
            "Card",
            "Transaction",
            "EMV Tag",
            "Multi Merchant",
            "Fleet Card",
            "HostCredential"
        };

        public static readonly string[] DoDebitResponseButtonNames = new string[]
        {
            "Normal",
            "Host",
            "Amount",
            "Account",
            "Trace",
            "VAS",
            "TOR",
            "Restaurant",
            "Card",
            "Transaction",
            "EMV Tag",
            "Multi Merchant",
            "Fleet Card",
            "HostCredential"
        };

        public static readonly string[] DoCashResponseButtonNames = new string[]
        {
            "Normal",
            "Host",
            "Amount",
            "Trace",
            "VAS",
            "TOR",
            "Restaurant",
            "Card",
            "Transaction",
            "EMV Tag",
            "Multi Merchant",
            "Fleet Card",
            "HostCredential"
        };

        public static readonly string[] DoCheckResponseButtonNames = new string[]
        {
            "Normal",
            "Host",
            "Amount",
            "Check",
            "Trace",
            "VAS",
            "TOR",
            "Restaurant",
            "Card",
            "Transaction",
            "EMV Tag",
            "Multi Merchant",
            "Fleet Card",
            "HostCredential"
        };

        public static readonly string[,] NormalResponseNames = new string[,]
        {
            { "ResponseCode", "Response Code" },
            { "ResponseMessage", "Response Message" },
            { "TransactionType", "Transaction Type" }
        };

        public static readonly string[,] DoCreditNormalResponseNames = new string[,]
        {
            { "ResponseCode", "Response Code" },
            { "ResponseMessage", "Response Message" },
            { "TransactionType", "Transaction Type" },
            { "PayloadData", "Payload Data" }
        };

        public static readonly string[,] HostResponseNames = new string[,]
        {
            { "HostResponseCode", "Host Response Code" },
            { "HostResponseMessage", "Host Response Message" },
            { "AuthCode", "Auth Code" },
            { "HostRefNum", "Host Ref Num" },
            { "TraceNumber", "Trace Number" },
            { "BatchNumber", "Batch Number" },
            { "TransactionIdentifier","Transaction Identifier" },
            { "GatewayTransactionID", "Gateway Transaction ID" },
            { "HostDetailedMessage", "Host Detailed Message" },
            { "TransactionIntegrityClass", "Transaction Integrity Class" },
            { "RetrievalReferenceNumber", "Retrieval Reference Number" },
            { "IssuerResponseCode", "Issuer Response Code" },
            { "PaymentAccountRefId", "Payment Account Reference ID" }
        };

        public static readonly string[,] AmountResponseNames = new string[,]
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

        public static readonly string[,] AccountResponseNames = new string[,]
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
            { "HostAccount", "Host Account" },
            { "HostCardType", "Host Card Type" },
            { "Track1Data", "Track1 Data" },
            { "Track2Data", "Track2 Data" },
            { "Track3Data", "Track3 Data" }
        };

        public static readonly string[,] CheckResponseNames = new string[,]
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

        public static readonly string[,] TraceResponseNames = new string[,]
        {
            { "RefNum", "Ref Num" },
            { "EcrRefNum", "ECR Ref Num" },
            { "TimeStamp", "Time Stamp" },
            { "InvoiceNumber", "Invoice Number" },
            { "PaymentService2000", "Payment Service 2000" },
            { "AuthorizationResponse", "Authorization Response" },
            { "EcrTransId", "ECR Trans ID" },
            { "HostTimeStamp", "Host Time Stamp" }
        };

        public static readonly string[,] AvsResponseNames = new string[,]
        {
            { "AvsApprovalCode", "AVS Approval Code" },
            { "AvsMessage", "AVS Message" },
            { "ZipCode", "Zip Code" },
            { "Address1", "Address1" },
            { "Address2", "Address2" }
        };

        public static readonly string[,] CommercialResponseNames = new string[,]
        {
            { "PoNumber", "PO Number" },
            { "CustomerCode", "Customer Code" },
            { "TaxExempt", "Tax Exempt" },
            { "TaxExemptID", "Tax Exempt ID" },
            { "MerchantTaxID", "Merchant Tax ID" },
            { "DestinationZipCode", "Destination Zip Code" },
            { "ProductDescription", "Product Description" }
        };

        public static readonly string[,] MotoECommerceResponseNames = new string[,]
        {
            { "Mode", "Mode" },
            { "TransactionType", "Transaction Type" },
            { "SecureType", "Secure Type" },
            { "OrderNumber", "Order Number" },
            { "Installments", "Installments" },
            { "CurrentInstallment", "Current Installment" }
        };

        public static readonly string[,] VasResponseNames = new string[,]
        {
            { "VasCode", "VAS Code" },
            { "VasData", "VAS Data" },
            { "NdefData", "NDEF Data" }
        };

        public static readonly string[,] TorResponseNames = new string[,]
        {
            { "RecordType", "Record Type" },
            { "ReversalTimeStamp", "Reversal Time Stamp" },
            { "HostResponseCode", "Host Response Code" },
            { "HostResponseMessage", "Host Response Message" },
            { "HostRefNum", "Host Ref Num" },
            { "GatewayTransactionID", "Gateway Transaction ID" },
            { "OrigAmount", "Orig Amount" },
            { "MaskedPan", "Masked PAN" },
            { "BatchNo", "Batch Number" },
            { "ReversalAuthCode", "Reversal Auth Code" },
            { "OrigTransType", "Orig Trans Type" },
            { "OrigTransDateTime", "Orig Trans Date Time" },
            { "OrigTransAuthCode", "Orig Trans Auth Code" }
        };

        public static readonly string[,] HostCredentialResponseNames = new string[,]
        {
            { "HostTid", "Host TID" }
        };

        //ExtData-----------------------------------------------------------------------------------------
        public static readonly string[,] RestaurantNames = new string[,]
        {
            { "TableNumber", "Table Number" },
            { "GuestNumber", "Guest Number" },
            { "TicketNumber", "Ticket Number" }
        };

        public static readonly string[,] HostGatewayNames = new string[,]
        {
            { "HRef", "HRef" },
            { "GatewayId", "Gateway ID" },
            { "TokenRequestFlag", "Token Request Flag" },
            { "Token", "Token" },
            { "CardType", "Card Type" },
            { "PassThruData", "Pass Thru Data" },
            { "ReturnReason", "Return Reason" },
            { "StationId", "Station ID" },
            { "GlobalUid", "Global UID" },
            { "CustomizeData1", "Customize Data 1" },
            { "CustomizeData2", "Customize Data 2" },
            { "CustomizeData3", "Customize Data 3" },
            { "EwicDiscountAmount", "eWIC Discount Amount" },
            { "TokenSerialNum", "Token Serial Number" }
        };

        public static readonly string[,] TransactionBehaviorNames = new string[,]
        {
            { "SignatureCaptureFlag", "Signature Capture Flag" },
            { "TipRequestFlag", "Tip Request Flag" },
            { "SignatureUploadFlag", "Signature Upload Flag" },
            { "StatusReportFlag", "Status Report Flag" },
            { "AcceptedCardType", "Accepted Card Type" },
            { "ProgramPromptsFlag", "Program Prompts Flag" },
            { "SignatureAcquireFlag", "Signature Acquire Flag" },
            { "EntryMode", "Entry Mode" },
            { "ReceiptPrintFlag", "Receipt Print Flag" },
            { "CardPresentMode", "Card Present Mode" },
            { "DebitNetwork", "Debit Network" },
            { "UserLanguage", "User Language" },
            { "AddlRspDataFlag", "Addl Rsp Data Flag" },
            { "ForceCC", "Force CC" },
            { "ForceFsa", "Force FSA" },
            { "ForceDuplicate", "Force Duplicate" }, 
            { "AccessibilityPinPad", "Accessibility Pin Pad" },
            { "CofIndicator", "CoF Indicator"},
            { "CofInitiator", "CoF Initiator"},
            { "GiftCardIndicator", "Gift Card Indicator"}
        };

        public static readonly string[,] OriginalNames = new string[,]
        {
            { "TransDate", "Trans Date" },
            { "Pan", "PAN" },
            { "ExpiryDate", "Expiry Date" },
            { "TransTime", "Trans Time" },
            { "SettlementDate", "Settlement Date" },
            { "Amount", "Amount" },
            { "BatchNumber", "Batch Number" },
            { "PaymentService2000", "Payment Service 2000" },
            { "AuthorizationResponse", "Authorization Response" }
        };

        public static readonly string[,] OriginalLabelAndComboBoxNames = new string[,]
        {
            { "TransType", "Trans Type" }
        };

        public static readonly string[,] MultiMerchantNames = new string[,]
        {
            { "MultiMerchantId", "Multi Merchant ID" },
            { "MultiMerchantName", "Multi Merchant Name" }
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

        public static readonly string[,] CardInfoNames = new string[,]
        {
            { "CardBin", "Card BIN" },
            { "NewCardBin", "New Card BIN" },
            { "ProgramType", "Program Type" },
            { "HostProgramType", "Host Program Type" }
        };

        public static readonly string[,] PaymentTransInfoNames = new string[,]
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
            { "GlobalUid", "Global UID" },
            { "OrigTip", "Orig Tip" },
            { "EdcType", "EDC Type" },
            { "PrintLine1", "PrintLine1" },
            { "PrintLine2", "PrintLine2" },
            { "PrintLine3", "PrintLine3" },
            { "PrintLine4", "PrintLine4" },
            { "PrintLine5", "PrintLine5" },
            { "EwicBenefitExpd", "eWIC Benefit Expd" },
            { "EwicBalance", "eWIC Balance" },
            { "EwicDetail", "eWIC Detail" },
            { "ReverseAmount", "Reverse Amount" },
            { "ReversalStatus", "Reversal Status" },
            { "TokenSerialNum", "Token Serial Number" },
            //"AddlRspData", this is a class not string.
            { "SignatureData", "Signature Data" },
        };

        public static readonly string[,] PaymentEmvTagNames = new string[,]
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
            { "Ac", "AC" },
            { "Aip", "AIP" },
            { "Avn", "AVN" },
            { "IssuerAuthData", "Issuer Auth Data" },
            { "Cdol2", "CDOL2" },
            { "Hred", "HRED" },
            { "TacDefault", "TAC Default" },
            { "TacDenial", "TAC Denial" },
            { "TacOnline", "TAC Online" },
            { "IacDefault", "IAC Default" },
            { "IacDenial", "IAC Denial" },
            { "IacOnline", "IAC Online" },
            { "Auc", "AUC" },
            { "PanSequenceNumber", "PAN Sequence Number" }
        };
    }
}

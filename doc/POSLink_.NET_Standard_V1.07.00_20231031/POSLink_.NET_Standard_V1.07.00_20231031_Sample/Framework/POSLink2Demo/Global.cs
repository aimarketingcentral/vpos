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
using System.Drawing;
using System.Windows.Forms;

namespace POSLink2Demo
{
    public enum TransactionCommandName
    {
        DoCredit = 0,
        DoDebit,
        DoEBT,
        DoGift,
        DoLoyalty,
        DoCash,
        DoCheck
    }

    public enum BatchCommandName
    {
        BatchCloseReq = 0,
        BatchCloseRsp,
        ForceBatchCloseReq,
        ForceBatchCloseRsp,
        BatchClearReq,
        BatchClearRsp,
        PurgeBatchReq,
        PurgeBatchRsp,
        SAFUploadReq,
        SAFUploadRsp,
        DeleteSAFFileReq,
        DeleteSAFFileRsp,
        DeleteTransactionReq,
        DeleteTransactionRsp,
    }

    public enum ReportCommandName
    {
        LocalTotalReportReq = 0,
        LocalTotalReportRsp,
        LocalDetailReportReq,
        LocalDetailReportRsp,
        LocalFailedReportReq,
        LocalFailedReportRsp,
        HostReportReq,
        HostReportRsp,
        HistoryReportReq,
        HistoryReportRsp,
        SAFSummaryReportReq,
        SAFSummaryReportRsp,
        HostDetailReportReq,
        HostDetailReportRsp
    }

    public enum ManageCommandName
    {
        InitReq = 0,
        InitRsp,
        GetVariableReq,
        GetVariableRsp,
        SetVariableReq,
        SetVariableRsp,
        GetSignatureReq,
        GetSignatureRsp,
        ResetReq,
        ResetRsp,
        UpdateResourceFileReq,
        UpdateResourceFileRsp,
        DoSignatureReq,
        DoSignatureRsp,
        DeleteImageReq,
        DeleteImageRsp,
        RebootReq,
        RebootRsp,
        InputAccountReq,
        InputAccountRsp,
        ResetMsrReq,
        ResetMsrRsp,
        CheckFileReq,
        CheckFileRsp,
        SetSafParametersReq,
        SetSafParametersRsp,
        ReprintReq,
        ReprintRsp,
        TokenAdministrativeReq,
        TokenAdministrativeRsp,
        VasSetMerchantParametersReq,
        VasSetMerchantParametersRsp,
        VasPushDataReq,
        VasPushDataRsp,
        GetSafParametersReq,
        GetSafParametersRsp
    }

    public enum FormCommandName
    {
        ShowDialogReq = 0,
        ShowDialogRsp,
        ShowMessageReq,
        ShowMessageRsp,
        ClearMessageReq,
        ClearMessageRsp,
        ShowMessageCenterReq,
        ShowMessageCenterRsp,
        InputTextReq,
        InputTextRsp,
        RemoveCardReq,
        RemoveCardRsp,
        ShowTextBoxReq,
        ShowTextBoxRsp,
        ShowItemReq,
        ShowItemRsp,
        ShowDialogFormReq,
        ShowDialogFormRsp,
    }

    public enum DeviceCommandName
    {
        PrinterReq = 0,
        PrinterRsp,
        CardInsertDetectionReq,
        CardInsertDetectionRsp,
        CameraScanReq,
        CameraScanRsp,
        MifareCardReq,
        MifareCardRsp
    }

    public enum FullIntegrationCommandName
    {
        GetPinBlockReq = 0,
        GetPinBlockRsp,
        AuthorizeCardReq,
        AuthorizeCardRsp,
        CompleteOnlineEmvReq,
        CompleteOnlineEmvRsp,
        GetEmvTlvDataReq,
        GetEmvTlvDataRsp,
        SetEmvTlvDataReq,
        SetEmvTlvDataRsp,
        InputAccountWithEmvReq,
        InputAccountWithEmvRsp
    }

    public enum PedCommandName
    {
        SessionKeyInjectionReq = 0,
        SessionKeyInjectionRsp,
        MacCalculationReq,
        MacCalculationRsp,
        GetPedInfoReq,
        GetPedInfoRsp,
        IncreaseKsnReq,
        IncreaseKsnRsp
    }

    public enum CommandName
    {
        DoCredit = 0,
        DoDebit,
        DoEBT,
        DoGift,
        DoLoyalty,
        DoCash,
        DoCheck,
        BatchClose,
        ForceBatchClose,
        BatchClear,
        PurgeBatch,
        SAFUpload,
        DeleteSAFFile,
        DeleteTransaction,
        LocalTotalReport,
        LocalDetailReport,
        LocalFailedReport,
        HostReport,
        HistoryReport,
        SAFSummaryReport,
        HostDetailReport,
        Init,
        GetVariable,
        SetVariable,
        GetSignature,
        Reset,
        UpdateResourceFile,//Can not add to Multiple Commands.
        DoSignature,
        DeleteImage,
        Reboot,
        GetPinBlock,
        InputAccount,
        ResetMsr,
        CheckFile,
        GetEmvTlvData,
        SetEmvTlvData,
        SetSafParameters,
        Reprint,
        TokenAdministrative,
        VasSetMerchantParameters,
        VasPushData,
        GetSafParameters,
        ShowDialog,
        ShowMessage,
        ClearMessage,
        ShowMessageCenter,
        InputText,
        RemoveCard,
        ShowTextBox,
        ShowItem,
        ShowDialogForm,
        Printer,
        CardInsertDetection,
        CameraScan,
        MifareCard,
        AuthorizeCard,
        CompleteOnlineEmv,
        InputAccountWithEmv,
        SessionKeyInjection,
        MacCalculation,
        GetPedInfo,
        IncreaseKsn
    }

    public enum ButtonClickEventCommandName
    {
        LocalTotalReportRsp = 0,
        HistoryReportRsp,
        SAFSummaryReportRsp,
        GoogleSmartTapReq,
        VasPushDataReq
    }

    public static class Global
    {
        public static bool IsTransactionProcessing = false;
        public static ReceiptSetting ReceiptSetting { get; set; }

        public static readonly object[,] EdcType = new object[,]
        {
            { "All" , POSLink2.Const.EdcType.All},
            { "Credit", POSLink2.Const.EdcType.Credit },
            { "Debit", POSLink2.Const.EdcType.Debit},
            { "Ebt", POSLink2.Const.EdcType.Ebt},
            { "Gift", POSLink2.Const.EdcType.Gift},
            { "Loyalty", POSLink2.Const.EdcType.Loyalty},
            { "Cash", POSLink2.Const.EdcType.Cash},
            { "Check", POSLink2.Const.EdcType.Check}
        };

        public static string[] GetEdcTypeKey()
        {
            return ParseToStringArray(EdcType);
        }

        public static readonly object[,] TransType = new object[,]
        {
            { "UnKnown" ,  POSLink2.Const.TransType.UnKnown},
            { "Sale" ,  POSLink2.Const.TransType.Sale},
            { "Return" ,  POSLink2.Const.TransType.Return},
            { "Auth" ,  POSLink2.Const.TransType.Auth},
            { "PostAuth" ,  POSLink2.Const.TransType.PostAuth},
            { "ForceAuth" ,  POSLink2.Const.TransType.ForceAuth},
            { "Adjust" ,  POSLink2.Const.TransType.Adjust},
            { "Withdrawal" ,  POSLink2.Const.TransType.Withdrawal},
            { "Activate" ,  POSLink2.Const.TransType.Activate},
            { "Issue" ,  POSLink2.Const.TransType.Issue},
            { "Reload" ,  POSLink2.Const.TransType.Reload},
            { "CashOut" ,  POSLink2.Const.TransType.CashOut},
            { "Deactivate" ,  POSLink2.Const.TransType.Deactivate},
            { "Replace" ,  POSLink2.Const.TransType.Replace},
            { "Merge" ,  POSLink2.Const.TransType.Merge},
            { "ReportLost" ,  POSLink2.Const.TransType.ReportLost},
            { "Void" ,  POSLink2.Const.TransType.Void},
            { "VoidSale" ,  POSLink2.Const.TransType.VoidSale},
            { "VoidReturn" ,  POSLink2.Const.TransType.VoidReturn},
            { "VoidAuth" ,  POSLink2.Const.TransType.VoidAuth},
            { "VoidPostAuth" ,  POSLink2.Const.TransType.VoidPostAuth},
            { "VoidForceAuth" ,  POSLink2.Const.TransType.VoidForceAuth},
            { "VoidWithdrawal" ,  POSLink2.Const.TransType.VoidWithdrawal},
            { "Inquiry" ,  POSLink2.Const.TransType.Inquiry},
            { "Verify" ,  POSLink2.Const.TransType.Verify},
            { "Reactivate" ,  POSLink2.Const.TransType.Reactivate},
            { "ForcedIssue" ,  POSLink2.Const.TransType.ForcedIssue},
            { "ForcedAdd" ,  POSLink2.Const.TransType.ForcedAdd},
            { "Unload" ,  POSLink2.Const.TransType.Unload},
            { "Renew" ,  POSLink2.Const.TransType.Renew},
            { "GetConvertDetail" ,  POSLink2.Const.TransType.GetConvertDetail},
            { "Convert" ,  POSLink2.Const.TransType.Convert},
            { "Tokenize" ,  POSLink2.Const.TransType.Tokenize},
            { "IncrementalAuth" ,  POSLink2.Const.TransType.IncrementalAuth},
            { "BalanceWithLock" ,  POSLink2.Const.TransType.BalanceWithLock},
            { "RedemptionWithLock" ,  POSLink2.Const.TransType.RedemptionWithLock},
            { "Rewards" ,  POSLink2.Const.TransType.Rewards},
            { "Reenter" ,  POSLink2.Const.TransType.Reenter},
            { "TransactionAdjustment" ,  POSLink2.Const.TransType.TransactionAdjustment},
            { "Transfer" ,  POSLink2.Const.TransType.Transfer},
            { "Finalize" ,  POSLink2.Const.TransType.Finalize},
            { "Deposit" ,  POSLink2.Const.TransType.Deposit},
            { "AccountPayment" ,  POSLink2.Const.TransType.AccountPayment},
            { "Reversal" ,  POSLink2.Const.TransType.Reversal},
        };

        public static string[] GetTransTypeKey()
        {
            return ParseToStringArray(TransType);
        }

        public static readonly object[,] OrigTransType = new object[,]
        {
            { "", POSLink2.Const.TransType.Empty },
            { "UnKnown" ,  POSLink2.Const.TransType.UnKnown},
            { "Sale" ,  POSLink2.Const.TransType.Sale},
            { "Return" ,  POSLink2.Const.TransType.Return},
            { "Auth" ,  POSLink2.Const.TransType.Auth},
            { "PostAuth" ,  POSLink2.Const.TransType.PostAuth},
            { "ForceAuth" ,  POSLink2.Const.TransType.ForceAuth},
            { "Adjust" ,  POSLink2.Const.TransType.Adjust},
            { "Withdrawal" ,  POSLink2.Const.TransType.Withdrawal},
            { "Activate" ,  POSLink2.Const.TransType.Activate},
            { "Issue" ,  POSLink2.Const.TransType.Issue},
            { "Reload" ,  POSLink2.Const.TransType.Reload},
            { "CashOut" ,  POSLink2.Const.TransType.CashOut},
            { "Deactivate" ,  POSLink2.Const.TransType.Deactivate},
            { "Replace" ,  POSLink2.Const.TransType.Replace},
            { "Merge" ,  POSLink2.Const.TransType.Merge},
            { "ReportLost" ,  POSLink2.Const.TransType.ReportLost},
            { "Void" ,  POSLink2.Const.TransType.Void},
            { "VoidSale" ,  POSLink2.Const.TransType.VoidSale},
            { "VoidReturn" ,  POSLink2.Const.TransType.VoidReturn},
            { "VoidAuth" ,  POSLink2.Const.TransType.VoidAuth},
            { "VoidPostAuth" ,  POSLink2.Const.TransType.VoidPostAuth},
            { "VoidForceAuth" ,  POSLink2.Const.TransType.VoidForceAuth},
            { "VoidWithdrawal" ,  POSLink2.Const.TransType.VoidWithdrawal},
            { "Inquiry" ,  POSLink2.Const.TransType.Inquiry},
            { "Verify" ,  POSLink2.Const.TransType.Verify},
            { "Reactivate" ,  POSLink2.Const.TransType.Reactivate},
            { "ForcedIssue" ,  POSLink2.Const.TransType.ForcedIssue},
            { "ForcedAdd" ,  POSLink2.Const.TransType.ForcedAdd},
            { "Unload" ,  POSLink2.Const.TransType.Unload},
            { "Renew" ,  POSLink2.Const.TransType.Renew},
            { "GetConvertDetail" ,  POSLink2.Const.TransType.GetConvertDetail},
            { "Convert" ,  POSLink2.Const.TransType.Convert},
            { "Tokenize" ,  POSLink2.Const.TransType.Tokenize},
            { "IncrementalAuth" ,  POSLink2.Const.TransType.IncrementalAuth},
            { "BalanceWithLock" ,  POSLink2.Const.TransType.BalanceWithLock},
            { "RedemptionWithLock" ,  POSLink2.Const.TransType.RedemptionWithLock},
            { "Rewards" ,  POSLink2.Const.TransType.Rewards},
            { "Reenter" ,  POSLink2.Const.TransType.Reenter},
            { "TransactionAdjustment" ,  POSLink2.Const.TransType.TransactionAdjustment},
            { "Transfer" ,  POSLink2.Const.TransType.Transfer},
            { "Finalize" ,  POSLink2.Const.TransType.Finalize},          
            { "Deposit" ,  POSLink2.Const.TransType.Deposit},
            { "AccountPayment" ,  POSLink2.Const.TransType.AccountPayment},
            { "Reversal" ,  POSLink2.Const.TransType.Reversal},
        };

        public static string[] GetOrigTransTypeKey()
        {
            return ParseToStringArray(OrigTransType);
        }

        public static readonly object[,] CardType = new object[,]
        {
            { "--Please Select--", POSLink2.Const.CardType.Empty },
            { "Visa", POSLink2.Const.CardType.Visa },
            { "MasterCard", POSLink2.Const.CardType.MasterCard },
            { "AMEX", POSLink2.Const.CardType.Amex },
            { "Discover", POSLink2.Const.CardType.Discover },
            { "DinerClub", POSLink2.Const.CardType.DinerClub },
            { "enRoute", POSLink2.Const.CardType.EnRoute },
            { "JCB", POSLink2.Const.CardType.Jcb },
            { "RevolutionCard", POSLink2.Const.CardType.RevolutionCard },
            { "VisaFleet", POSLink2.Const.CardType.VisaFleet },
            { "MasterCardFleet", POSLink2.Const.CardType.MasterCardFleet },
            { "FleetOne", POSLink2.Const.CardType.FleetOne },
            { "Fleetwide", POSLink2.Const.CardType.Fleetwide },
            { "Fuelman", POSLink2.Const.CardType.Fuelman },
            { "Gascard", POSLink2.Const.CardType.Gascard },
            { "Voyager", POSLink2.Const.CardType.Voyager },
            { "WrightExpress", POSLink2.Const.CardType.WrightExpress },
            { "Interac", POSLink2.Const.CardType.Interac },
            { "CUP", POSLink2.Const.CardType.Cup },
            { "Maestro", POSLink2.Const.CardType.Maestro },
            { "Sinclair", POSLink2.Const.CardType.Sinclair },
            { "Other", POSLink2.Const.CardType.Other },
        };

        public static string[] GetCardTypeKey()
        {
            return ParseToStringArray(CardType);
        }

        public static readonly object[,] FileType = new object[,]
        {
            {"Resource file", POSLink2.Const.FileType.ResourceFile},
            {"Offline RKI key file", POSLink2.Const.FileType.OfflineRkiKeyFile},
            {"Installation package file", POSLink2.Const.FileType.InstallationPackageFile}
        };

        public static string[] GetFileTypeKey()
        {
            return ParseToStringArray(FileType);
        }

        public static readonly object[,] VehicleClassId = new object[,]
        {
            {"", POSLink2.Const.VehicleClassId.Empty},
            {"Mini", POSLink2.Const.VehicleClassId.Mini},
            {"Subcompact", POSLink2.Const.VehicleClassId.Subcompact},
            {"Economy", POSLink2.Const.VehicleClassId.Economy},
            {"Compact", POSLink2.Const.VehicleClassId.Compact},
            {"Midsize", POSLink2.Const.VehicleClassId.Midsize},
            {"Intermediate", POSLink2.Const.VehicleClassId.Intermediate},
            {"Standard", POSLink2.Const.VehicleClassId.Standard},
            {"Full size", POSLink2.Const.VehicleClassId.FullSize},
            {"Luxury", POSLink2.Const.VehicleClassId.Luxury},
            {"Premium", POSLink2.Const.VehicleClassId.Premium},
            {"Minivan", POSLink2.Const.VehicleClassId.Minivan},
            {"12-Passenger van", POSLink2.Const.VehicleClassId.TwelvePassengerVan},
            {"Moving van", POSLink2.Const.VehicleClassId.MovingVan},
            {"15-Passing van", POSLink2.Const.VehicleClassId.FifteenPassingVan},
            {"Cargo van", POSLink2.Const.VehicleClassId.CargoVan},
            {"12-foot truck", POSLink2.Const.VehicleClassId.TwelveFootTruck},
            {"20-foot truck", POSLink2.Const.VehicleClassId.TwentyFootTruck},
            {"24-foot truck", POSLink2.Const.VehicleClassId.TwentyFourFootTruck},
            {"26-foot truck", POSLink2.Const.VehicleClassId.TwentySixFootTruck},
            {"Moped", POSLink2.Const.VehicleClassId.Moped},
            {"Stretch", POSLink2.Const.VehicleClassId.Stretch},
            {"Regular", POSLink2.Const.VehicleClassId.Regular},
            {"Unique", POSLink2.Const.VehicleClassId.Unique},
            {"Exotic", POSLink2.Const.VehicleClassId.Exotic},
            {"Small/medium truck", POSLink2.Const.VehicleClassId.SmallOrMediumTruck},
            {"Large truck", POSLink2.Const.VehicleClassId.LargeTruck},
            {"Small SUV", POSLink2.Const.VehicleClassId.SmallSuv},
            {"Medium SUV", POSLink2.Const.VehicleClassId.MediumSuv},
            {"Large SUV", POSLink2.Const.VehicleClassId.LargeSuv},
            {"Exotic SUV", POSLink2.Const.VehicleClassId.ExoticSuv},
            {"Four wheel drive", POSLink2.Const.VehicleClassId.FourWheelDrive},
            {"Special", POSLink2.Const.VehicleClassId.Special},
            {"Miscellaneous", POSLink2.Const.VehicleClassId.Miscellaneous}
        };

        public static string[] GetVehicleClassIdKey()
        {
            return ParseToStringArray(VehicleClassId);
        }

        public static readonly string[] CommandName = new string[]
        {
            "Do Credit",
            "Do Debit",
            "Do EBT",
            "Do Gift",
            "Do Loyalty",
            "Do Cash",
            "Do Check",
            "Batch Close",
            "Force Batch Close",
            "Batch Clear",
            "Purge Batch",
            "SAF Upload",
            "Delete SAF File",
            "Delete Transaction",
            "Local Total Report",
            "Local Detail Report",
            "Local Failed Report",
            "Host Report",
            "History Report",
            "SAF Summary Report",
            "Host Detail Report",
            "Init",
            "Get Variable",
            "Set Variable",
            "Get Signature",
            "Reset",
            "Update Resource File",//Can not add to Multiple Commands.
            "Do Signature",
            "Delete Image",
            "Reboot",
            "Get PIN Block",
            "Input Account",
            "Reset MSR",
            "Check File",
            "Get EMV TLV Data",
            "Set EMV TLV Data",
            "Set SAF Parameters",
            "Reprint",
            "Token Administrative",
            "VAS Set Merchant Parameters",
            "VAS Push Data",
            "Get SAF Parameters",
            "Show Dialog",
            "Show Message",
            "Clear Message",
            "Show Message Center",
            "Input Text",
            "Remove Card",
            "Show Text Box",
            "Show Item",
            "Show Dialog Form",
            "Printer",
            "Card Insert Detection",
            "Camera Scan",
            "Mifare Card",
            "Authorize Card",
            "Complete Online EMV",
            "Input Account With EMV",
            "Session Key Injection",
            "MAC Calculation",
            "Get PED Info",
            "Increase KSN"
        };

        private static string[] ParseToStringArray(object[,] items)
        {
            string[] itemsArray = new string[items.Length / 2];
            for (int i = 0; i < items.Length / 2; i++)
            {
                itemsArray[i] = (string)items[i, 0];
            }
            return itemsArray;
        }
    }

    public class ReceiptSetting
    {
        public string TidName { get; set;}
        public string MidName { get; set;}
        public string TidValue { get; set;}
        public string MidValue { get; set;}
        public string CurrencySign { get; set;}
        public string ReceiptHeader1 { get; set;}
        public string ReceiptHeader2 { get; set;}
        public string ReceiptHeader3 { get; set;}
        public string ReceiptHeader4 { get; set;}
        public string ReceiptHeader5 { get; set;}
        public string ReceiptStyle { get; set;}
        public string ReceiptTrailer1 { get; set;}
        public string ReceiptTrailer2 { get; set;}
        public string ReceiptTrailer3 { get; set;}
        public string ReceiptTrailer4 { get; set;}
        public string ReceiptTrailer5 { get; set;}
        public int SurchargeMode { get; set; }
        public string SurchargeRateOrFee { get; set; }
    }
}

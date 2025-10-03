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
    public static class FormCommon
    {
        public static readonly string[] CommandNames = new string[]
        {
            "Show Dialog",
            "Show Message",
            "Clear Message",
            "Show Message Center",
            "Input Text",
            "Remove Card",
            "Show TextBox",
            "Show Item",
            "Show Dialog Form"
        };

        //Request-------------------------------------------------------
        public static readonly string[,] ShowDialogReqNormal = new string[,]
        {
            {"Title", "Title"},
            {"ButtonName1", "Button Name 1"},
            {"ButtonName2", "Button Name 2"},
            {"ButtonName3", "Button Name 3"},
            {"ButtonName4", "Button Name 4"},
            {"Timeout", "Timeout"},
            {"ContinuousScreen", "Continuous Screen"}
        };

        public static readonly string[,] ShowMessageReqNormal = new string[,]
        {
            {"Title", "Title"},
            {"DisplayMessage1", "Display Message 1"},
            {"DisplayMessage2", "Display Message 2"},
            {"TopDown", "Top Down"},
            {"TaxLine", "Tax Line"},
            {"TotalLine", "Total Line"},
            {"ImageName", "Image Name"},
            {"ImageDescription", "Image Description"},
            {"LineItemAction", "Line Item Action"},
            {"ItemIndex", "Item Index"}
        };

        public static readonly string[,] ShowMessageCenterReqNormal = new string[,]
        {
            {"Title", "Title"},
            {"Message1", "Message 1"},
            {"Message2", "Message 2"},
            {"Timeout", "Timeout"},
            {"PinpadType", "Pinpad Type"},
            {"IconName", "Icon Name"}
        };

        public static readonly string[,] InputTextReqNormal = new string[,]
        {
            {"Title", "Title"},
            {"InputType", "Input Type"},
            {"MinLength", "Min Length"},
            {"MaxLength", "Max Length"},
            {"DefaultValue", "Default Value"},
            {"Timeout", "Timeout"},
            {"ContinuousScreen", "Continuous Screen"}
        };

        public static readonly string[,] RemoveCardReqNormal = new string[,]
        {
            {"Message1", "Message 1"},
            {"Message2", "Message 2"},
            {"ContinuousScreen", "Continuous Screen"},
            {"PinpadType", "Pinpad Type"}
        };

        public static readonly string[,] ShowTextBoxReqNormal = new string[,]
        {
            {"Title", "Title"},
            {"Text", "Text"},
            {"ButtonName1", "Button Name 1"},
            {"ButtonColor1", "Button Color 1"},
            {"ButtonName2", "Button Name 2"},
            {"ButtonColor2", "Button Color 2"},
            {"ButtonName3", "Button Name 3"},
            {"ButtonColor3", "Button Color 3"},
            {"Timeout", "Timeout"},
            {"ButtonKey1", "Button Key 1"},
            {"ButtonKey2", "Button Key 2"},
            {"ButtonKey3", "Button Key 3"},
            {"EnableHardKeyOnly", "Enable Hard Key Only"},
            {"HardKeyList", "Hard Key List"},
            {"SignatureBox", "Signature Box"},
            {"ContinuousScreen", "Continuous Screen"},
            {"BarcodeType", "Barcode Type"},
            {"BarcodeData", "Barcode Data"},
            {"InputTextTitle", "Input Text Title"},
            {"InputText", "Input Text"},
            {"InputType", "Input Type"},
            {"MinLength", "Min Length"},
            {"MaxLength", "Max Length"}
        };

        public static readonly string[,] ShowItemReqNormal = new string[,]
        {
            {"Title", "Title"},
            {"TopDown", "Top Down"},
            {"TaxLine", "Tax Line"},
            {"TotalLine", "Total Line"},
            {"ItemDetail", "Item Detail"},
            {"LineItemAction", "Line Item Action"},
            {"ItemIndex", "Item Index"}
        };

        public static readonly string[,] ShowDialogFormReqNormal = new string[,]
        {
            {"Title", "Title"},
            {"Label1", "Label 1"},
            {"Label1Property", "Label 1 Property"},
            {"Label2", "Label 2"},
            {"Label2Property", "Label 2 Property"},
            {"Label3", "Label 3"},
            {"Label3Property", "Label 3 Property"},
            {"Label4", "Label 4"},
            {"Label4Property", "Label 4 Property"},
            {"ButtonType", "Button Type"},
            {"Timeout", "Timeout"},
            {"ContinuousScreen", "Continuous Screen"}
        };

        //Response-----------------------------------------------------
        public static readonly string[,] ShowDialogRspNormal = new string[,]
        {
            {"ResponseCode", "Response Code"},
            {"ResponseMessage", "Response Message"},
            {"ButtonNumber", "Button Number"}
        };

        public static readonly string[,] ShowMessageRspNormal = new string[,]
        {
            {"ResponseCode", "Response Code"},
            {"ResponseMessage", "Response Message"}
        };

        public static readonly string[,] ClearMessageRspNormal = new string[,]
        {
            {"ResponseCode", "Response Code"},
            {"ResponseMessage", "Response Message"}
        };

        public static readonly string[,] ShowMessageCenterRspNormal = new string[,]
        {
            {"ResponseCode", "Response Code"},
            {"ResponseMessage", "Response Message"},
            {"PinpadType", "Pinpad Type"}
        };

        public static readonly string[,] InputTextRspNormal = new string[,]
        {
            {"ResponseCode", "Response Code"},
            {"ResponseMessage", "Response Message"},
            {"Text", "Text"}
        };

        public static readonly string[,] RemoveCardRspNormal = new string[,]
        {
            {"ResponseCode", "Response Code"},
            {"ResponseMessage", "Response Message"},
            {"PinpadType", "Pinpad Type"}
        };

        public static readonly string[,] ShowTextBoxRspNormal = new string[,]
        {
            {"ResponseCode", "Response Code"},
            {"ResponseMessage", "Response Message"},
            {"ButtonNumber", "Button Number"},
            {"SignStatus", "Signature Status"},
            {"SignatureData", "Signature Data"},
            {"Text", "Text"}
        };

        public static readonly string[,] ShowItemRspNormal = new string[,]
        {
            {"ResponseCode", "Response Code"},
            {"ResponseMessage", "Response Message"}
        };

        public static readonly string[,] ShowDialogFormRspNormal = new string[,]
        {
            {"ResponseCode", "Response Code"},
            {"ResponseMessage", "Response Message"},
            {"LabelSelected", "Label Selected"}
        };
    }
}

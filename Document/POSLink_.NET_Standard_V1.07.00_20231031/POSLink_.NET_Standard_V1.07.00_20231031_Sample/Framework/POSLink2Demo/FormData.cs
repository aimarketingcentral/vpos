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
    public class FormData
    {
        //Request-------------------------------------------------------------------
        public string[] ShowDialogReqNormalData { get; set; }
        public string[] ShowMessageReqNormalData { get; set; }
        public string[] ShowMessageCenterReqNormalData { get; set; }
        public string[] InputTextReqNormalData { get; set; }
        public string[] RemoveCardReqNormalData { get; set; }
        public string[] ShowTextBoxReqNormalDara { get; set; }
        public string[] ShowItemReqNormalData { get; set; }
        public string[] ShowDialogFormReqNormalData { get; set; }
        public POSLink2.Util.ItemDetail[] ItemDetailData { get; set; }
        //Response-----------------------------------------------------------------
        public string[] ShowDialogRspNormalData { get; set; }
        public string[] ShowMessageRspNormalData { get; set; }
        public string[] ClearMessageRspNormalData { get; set; }
        public string[] ShowMessageCenterRspNormalData { get; set; }
        public string[] InputTextRspNormalData { get; set; }
        public string[] RemoveCardRspNormalData { get; set; }
        public string[] ShowTextBoxRspNormalDara { get; set; }
        public string[] ShowItemRspNormalData { get; set; }
        public string[] ShowDialogFormRspNormalData { get; set; }

        private static FormData _formData;
        private FormData()
        {
            RequestClear();
            ResponseClear();
        }
        public static FormData GetFormData()
        {
            if(_formData == null)
            {
                _formData = new FormData();
            }
            return _formData;
        }

        public void RequestClear()
        {
            ShowDialogReqNormalData = new string[FormCommon.ShowDialogReqNormal.Length / 2];
            ShowMessageReqNormalData = new string[FormCommon.ShowMessageReqNormal.Length / 2];
            ShowMessageCenterReqNormalData = new string[FormCommon.ShowMessageCenterReqNormal.Length / 2];
            InputTextReqNormalData = new string[FormCommon.InputTextReqNormal.Length / 2];
            RemoveCardReqNormalData = new string[FormCommon.RemoveCardReqNormal.Length / 2];
            ShowTextBoxReqNormalDara = new string[FormCommon.ShowTextBoxReqNormal.Length / 2];
            ShowItemReqNormalData = new string[FormCommon.ShowItemReqNormal.Length / 2];
            ShowDialogFormReqNormalData = new string[FormCommon.ShowDialogFormReqNormal.Length / 2];
            ItemDetailData = null;
        }

        public void ResponseClear()
        {
            ShowDialogRspNormalData = new string[FormCommon.ShowDialogRspNormal.Length / 2];
            ShowMessageRspNormalData = new string[FormCommon.ShowMessageRspNormal.Length / 2];
            ClearMessageRspNormalData = new string[FormCommon.ClearMessageRspNormal.Length / 2];
            ShowMessageCenterRspNormalData = new string[FormCommon.ShowMessageCenterRspNormal.Length / 2];
            InputTextRspNormalData = new string[FormCommon.InputTextRspNormal.Length / 2];
            RemoveCardRspNormalData = new string[FormCommon.RemoveCardRspNormal.Length / 2];
            ShowTextBoxRspNormalDara = new string[FormCommon.ShowTextBoxRspNormal.Length / 2];
            ShowItemRspNormalData = new string[FormCommon.ShowItemRspNormal.Length / 2];
            ShowDialogFormRspNormalData = new string[FormCommon.ShowDialogFormRspNormal.Length / 2];
        }
    }
}

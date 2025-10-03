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
    public class ManageData
    {
        //Request----------------------------------------
        public int EdcTypeIndex { get; set; }
        public int TransactionTypeIndex { get; set; }
        public int VasProgramIndex { get; set; }
        public int VasModeIndex { get; set; }
        public int SecurityIndex { get; set; }
        public int FileTypeIndex { get; set; }
        public string[] GetVariableReqNormalData { get; set; }
        public string[] SetVariableReqNormalData { get; set; }
        public string[] GetSignatureReqNormalData { get; set; }
        public string[] UpdateResourceFileReqNormalData { get; set; }
        public string[] DoSignatureReqNormalData { get; set; }
        public string[] DeleteImageReqNormalData { get; set; }
        public string[] InputAccountReqNormalData { get; set; }
        public string[] CheckFileReqNormalData { get; set; }
        public string[] SetSafParametersReqNormalData { get; set; }
        public string[] ReprintReqNormalData { get; set; }
        public string[] TokenAdministrativeReqNormalData { get; set; }
        public string[] ApplePayVasReqNormalData { get; set; }
        public string[] GoogleSmartTapReqNormalButtonTextBoxData { get; set; }
        public string[] GoogleSmartTapReqNormalData { get; set; }
        public string[] VasPushDataReqNormalButtonTextBoxData { get; set; }
        public string[] VasPushDataReqNormalData { get; set; }
        public POSLink2.Manage.ServiceUsage[] ServiceUsageReqData { get; set; }
        public POSLink2.Manage.ServiceUpdate[] ServiceUpdateReqData { get; set; }
        public POSLink2.Manage.NewService[] NewServiceReqData { get; set; }
        public bool[] ServiceTypeItemListData { get; set; }
        public string[] MultiMerchantReqData { get; set; }
        //Response----------------------------------------
        public string[] InitRspNormalData { get; set; }
        public string[] GetVariableRspNormalData { get; set; }
        public string[] SetVariableRspNormalData { get; set; }
        public string[] GetSignatureRspNormalData { get; set; }
        public string GetSignatureFileData { get; set; }
        public string[] ResetRspNormalData { get; set; }
        public string[] UpdateResourceFileRspNormalData { get; set; }
        public string[] DoSignatureRspNormalData { get; set; }
        public string[] DeleteImageRspNormalData { get; set; }
        public string[] RebootRspNormalData { get; set; }
        public string[] InputAccountRspNormalData { get; set; }
        public string[] ResetMsrRspNormalData { get; set; }
        public string[] CheckFileRspNormalData { get; set; }
        public string[] SetSafParametersRspNormalData { get; set; }
        public string[] ReprintRspNormalData { get; set; }
        public string[] TokenAdministrativeRspNormalData { get; set; }
        public string[] GetSafParametersRspNormalData { get; set; }
        public string[] VasSetMerchantParametersRspNormalData { get; set; }
        public string[] VasPushDataRspNormalData { get; set; }
        public string[] MultiMerchantRspData { get; set; }
        public string SignatureData { get; set; }
        public POSLink2.Util.HardwareConfigurationBitmap HardwareConfigurationBitmap { get; set; }

        private static ManageData _manageData;
        private ManageData()
        {
            RequestClear();
            ResponseClear();
        }
        public static ManageData GetManageData()
        {
            if(_manageData == null)
            {
                _manageData = new ManageData();
            }
            return _manageData;
        }

        public void RequestClear()
        {
            EdcTypeIndex = 0;
            TransactionTypeIndex = 0;
            VasProgramIndex = 0;
            VasModeIndex = 0;
            SecurityIndex = 0;
            FileTypeIndex = 0;
            GetVariableReqNormalData = new string[ManageCommon.GetVariableReqNormal.Length / 2];
            SetVariableReqNormalData = new string[ManageCommon.SetVariableReqNormal.Length / 2];
            UpdateResourceFileReqNormalData = new string[ManageCommon.UpdateResourceFileReqNormal.Length / 2];
            DoSignatureReqNormalData = new string[ManageCommon.DoSignatureReqNormal.Length / 2];
            DeleteImageReqNormalData = new string[ManageCommon.DeleteImageReqNormal.Length / 2];
            InputAccountReqNormalData = new string[ManageCommon.InputAccountReqNormal.Length / 2];
            CheckFileReqNormalData = new string[ManageCommon.CheckFileReqNormal.Length / 2];
            SetSafParametersReqNormalData = new string[ManageCommon.SetSafParametersReqNormal.Length / 2];
            ReprintReqNormalData = new string[ManageCommon.ReprintReqNormal.Length / 2];
            TokenAdministrativeReqNormalData = new string[ManageCommon.TokenAdministrativeReqNormal.Length / 2];
            ApplePayVasReqNormalData = new string[ManageCommon.ApplePayVasReqNormal.Length / 2];
            GoogleSmartTapReqNormalButtonTextBoxData = new string[ManageCommon.GoogleSmartTapReqNormalButtonTextBox.Length];
            GoogleSmartTapReqNormalData = new string[ManageCommon.GoogleSmartTapReqNormal.Length / 2];
            VasPushDataReqNormalButtonTextBoxData = new string[ManageCommon.VasPushDataReqNormalButtonTextBox.Length];
            VasPushDataReqNormalData = new string[ManageCommon.VasPushDataReqNormal.Length / 2];
            ServiceUsageReqData = null;
            ServiceUpdateReqData = null;
            NewServiceReqData = null;
            ServiceTypeItemListData = new bool[ManageCommon.ServiceTypeItemList.Length];
            MultiMerchantReqData = new string[ManageCommon.MultiMerchantNames.Length / 2];
        }

        public void ResponseClear()
        {
            InitRspNormalData = new string[ManageCommon.InitRspNormal.Length / 2];
            GetVariableRspNormalData = new string[ManageCommon.GetVariableRspNormal.Length / 2];
            SetVariableRspNormalData = new string[ManageCommon.SetVariableRspNormal.Length / 2];
            GetSignatureRspNormalData = new string[ManageCommon.GetSignatureRspNormal.Length / 2];
            GetSignatureFileData = "";
            ResetRspNormalData = new string[ManageCommon.ResetRspNormal.Length / 2];
            UpdateResourceFileRspNormalData = new string[ManageCommon.UpdateResourceFileRspNormal.Length / 2];
            DoSignatureRspNormalData = new string[ManageCommon.DoSignatureRspNormal.Length / 2];
            DeleteImageRspNormalData = new string[ManageCommon.DeleteImageRspNormal.Length / 2];
            RebootRspNormalData = new string[ManageCommon.RebootRspNormal.Length / 2];
            InputAccountRspNormalData = new string[ManageCommon.InputAccountRspNormal.Length / 2];
            ResetMsrRspNormalData = new string[ManageCommon.ResetMsrRspNormal.Length / 2];
            CheckFileRspNormalData = new string[ManageCommon.CheckFileRspNormal.Length / 2];
            SetSafParametersRspNormalData = new string[ManageCommon.SetSafParametersRspNormal.Length / 2];
            ReprintRspNormalData = new string[ManageCommon.ReprintRspNormal.Length / 2];
            TokenAdministrativeRspNormalData = new string[ManageCommon.TokenAdministrativeRspNormal.Length / 2];
            GetSafParametersRspNormalData = new string[ManageCommon.GetSafParametersRspNormal.Length / 2];
            VasSetMerchantParametersRspNormalData = new string[ManageCommon.VasSetMerchantParametersRspNormal.Length / 2];
            VasPushDataRspNormalData = new string[ManageCommon.VasPushDataRspNormal.Length / 2];
            MultiMerchantRspData = new string[ManageCommon.MultiMerchantNames.Length / 2];
            SignatureData = "";
            HardwareConfigurationBitmap = null;
        }
    }
}

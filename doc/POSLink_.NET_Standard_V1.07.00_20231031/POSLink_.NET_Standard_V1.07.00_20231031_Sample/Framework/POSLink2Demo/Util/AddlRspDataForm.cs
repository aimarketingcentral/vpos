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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSLink2Demo
{
    public partial class AddlRspDataForm : Form
    {
        private POSLink2.Util.AddlRspData _addlRspData;

        public AddlRspDataForm()
        {
            InitializeComponent();
        }

        public void SetAddlRspData(POSLink2.Util.AddlRspData addlRspData)
        {
            _addlRspData = addlRspData;
        }

        private void AddlRspDataForm_Load(object sender, EventArgs e)
        {
            if(_addlRspData != null)
            {
                AciTextBox.Text = _addlRspData.Aci;
                TransIdTextBox.Text = _addlRspData.TransId;
                CardLevelResultTextBox.Text = _addlRspData.CardLevelResult;
                SourceReasonCodeTextBox.Text = _addlRspData.SourceReasonCode;
                BankNetDataTextBox.Text = _addlRspData.BankNetData;
                PosEntryModeChgTextBox.Text = _addlRspData.PosEntryModeChg;
                TranEditErrCodeTextBox.Text = _addlRspData.TranEditErrCode;
                DiscProcCodeTextBox.Text = _addlRspData.DiscProcCode;
                DiscPosEntryTextBox.Text = _addlRspData.DiscPosEntry;
                DiscRespCodeTextBox.Text = _addlRspData.DiscRespCode;
                PosDataTextBox.Text = _addlRspData.PosData;
                DiscTransQualifierTextBox.Text = _addlRspData.DiscTransQualifier;
                DiscNridTextBox.Text = _addlRspData.DiscNrid;
                TrnmsnDateTimeTextBox.Text = _addlRspData.TrnmsnDateTime;
                OrigStanTextBox.Text = _addlRspData.OrigStan;
                CvvErrorCodeTextBox.Text = _addlRspData.CvvErrorCode;
                XCodeRespTextBox.Text = _addlRspData.XCodeResp;
                AuthorizingNetworkIdTextBox.Text = _addlRspData.AuthorizingNetworkId;
                TermEntryCapabltTextBox.Text = _addlRspData.TermEntryCapablt;
                PosEntryModeTextBox.Text = _addlRspData.PosEntryMode;
                ServCodeTextBox.Text = _addlRspData.ServCode;
                SpendQIndTextBox.Text = _addlRspData.SpendQInd;
                WltIdTextBox.Text = _addlRspData.WltId;
                LocalDateTimeTextBox.Text = _addlRspData.LocalDateTime;
                EmvTagsTextBox.Text = _addlRspData.EmvTags;
            }

        }
    }
}

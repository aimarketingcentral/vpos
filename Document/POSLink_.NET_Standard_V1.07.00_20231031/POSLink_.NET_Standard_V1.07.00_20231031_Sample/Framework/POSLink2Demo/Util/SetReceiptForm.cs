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
    public partial class SetReceiptForm : Form
    {
        public ReceiptSetting ReceiptSetting { get; set; }
        public SetReceiptForm()
        {
            InitializeComponent();
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            ReceiptSetting = new ReceiptSetting();
            ReceiptSetting.MidName = TextBox_MidName.Text;
            ReceiptSetting.MidValue = TextBox_MidValue.Text;
            ReceiptSetting.TidName = TextBox_TidName.Text;
            ReceiptSetting.TidValue = TextBox_TidValue.Text;
            ReceiptSetting.CurrencySign = TextBox_CurrencySign.Text;
            ReceiptSetting.ReceiptHeader1 = TextBox_ReceiptHeader1.Text;
            ReceiptSetting.ReceiptHeader2 = TextBox_ReceiptHeader2.Text;
            ReceiptSetting.ReceiptHeader3 = TextBox_ReceiptHeader3.Text;
            ReceiptSetting.ReceiptHeader4 = TextBox_ReceiptHeader4.Text;
            ReceiptSetting.ReceiptHeader5 = TextBox_ReceiptHeader5.Text;
            ReceiptSetting.ReceiptStyle = Combo_ReceiptStyle.Text;
            ReceiptSetting.ReceiptTrailer1 = TextBox_ReceiptTrailer1.Text;
            ReceiptSetting.ReceiptTrailer2 = TextBox_ReceiptTrailer2.Text;
            ReceiptSetting.ReceiptTrailer3 = TextBox_ReceiptTrailer3.Text;
            ReceiptSetting.ReceiptTrailer4 = TextBox_ReceiptTrailer4.Text;
            ReceiptSetting.ReceiptTrailer5 = TextBox_ReceiptTrailer5.Text;
            ReceiptSetting.SurchargeMode = Combo_SurchargeMode.SelectedIndex;
            ReceiptSetting.SurchargeRateOrFee = TextBox_SurchargeRateOrFee.Text;
            DialogResult = DialogResult.OK;
            Hide();
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Hide();
        }

        private void SetReceiptForm_Load(object sender, EventArgs e)
        {
            if(ReceiptSetting == null)
            {
                ReceiptSetting = new ReceiptSetting();
            }
            TextBox_MidName.Text = ReceiptSetting.MidName;
            TextBox_MidValue.Text = ReceiptSetting.MidValue;
            TextBox_TidName.Text = ReceiptSetting.TidName;
            TextBox_TidValue.Text = ReceiptSetting.TidValue;
            if(string.IsNullOrEmpty(ReceiptSetting.CurrencySign))
            {
                TextBox_CurrencySign.Text = "USD $";
            }
            else
            {
                TextBox_CurrencySign.Text = ReceiptSetting.CurrencySign;
            }
            TextBox_ReceiptHeader1.Text = ReceiptSetting.ReceiptHeader1;
            TextBox_ReceiptHeader2.Text = ReceiptSetting.ReceiptHeader2;
            TextBox_ReceiptHeader3.Text = ReceiptSetting.ReceiptHeader3;
            TextBox_ReceiptHeader4.Text = ReceiptSetting.ReceiptHeader4;
            TextBox_ReceiptHeader5.Text = ReceiptSetting.ReceiptHeader5;
            if(string.IsNullOrEmpty(ReceiptSetting.ReceiptStyle))
            {
                Combo_ReceiptStyle.SelectedIndex = 0;
            }
            else
            {
                Combo_ReceiptStyle.Text = ReceiptSetting.ReceiptStyle;
            }
            TextBox_ReceiptTrailer1.Text = ReceiptSetting.ReceiptTrailer1;
            TextBox_ReceiptTrailer2.Text = ReceiptSetting.ReceiptTrailer2;
            TextBox_ReceiptTrailer3.Text = ReceiptSetting.ReceiptTrailer3;
            TextBox_ReceiptTrailer4.Text = ReceiptSetting.ReceiptTrailer4;
            TextBox_ReceiptTrailer5.Text = ReceiptSetting.ReceiptTrailer5;
            if(ReceiptSetting.SurchargeMode<0)
            {
                Combo_SurchargeMode.SelectedIndex = 0;
            }
            else
            {
                Combo_SurchargeMode.SelectedIndex = ReceiptSetting.SurchargeMode;
            }
            TextBox_SurchargeRateOrFee.Text = ReceiptSetting.SurchargeRateOrFee;
        }
    }
}

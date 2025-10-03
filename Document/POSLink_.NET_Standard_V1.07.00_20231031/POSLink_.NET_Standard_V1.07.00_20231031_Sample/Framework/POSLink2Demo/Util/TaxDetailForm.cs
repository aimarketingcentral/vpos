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
    public partial class TaxDetailForm : Form
    {
        private POSLink2.Util.TaxDetail _taxDetail;

        public POSLink2.Util.TaxDetail GetTaxDetail()
        {
            return _taxDetail;
        }

        public TaxDetailForm()
        {
            InitializeComponent();
            TaxTypeComboBox.SelectedIndex = 0;
            _taxDetail = new POSLink2.Util.TaxDetail();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            _taxDetail = new POSLink2.Util.TaxDetail();
            _taxDetail.TaxType = TaxTypeComboBox.SelectedIndex.ToString("D2");
            _taxDetail.TaxAmount = TaxAmountTextBox.Text;
            _taxDetail.TaxRate = TaxRateTextBox.Text;
            _taxDetail.MerchantTaxId = MerchantTaxIdTextBox.Text;
            _taxDetail.CustomerTaxId = CustomerTaxIdTextBox.Text;
            _taxDetail.ValueAddedTaxInvoiceNumber = ValueAddedTaxInvoiceNumberTextBox.Text;

            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }
    }
}

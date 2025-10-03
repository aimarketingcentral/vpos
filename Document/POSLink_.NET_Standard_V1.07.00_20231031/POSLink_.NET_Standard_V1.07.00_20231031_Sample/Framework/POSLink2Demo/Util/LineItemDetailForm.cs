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
    public partial class LineItemDetailForm : Form
    {
        private POSLink2.Util.LineItemDetail _lineItemDetail;
        public POSLink2.Util.LineItemDetail LineItemDetail
        {
            get { return _lineItemDetail; }
        }

        private POSLink2.Util.TaxDetail[] _taxDetails;

        public LineItemDetailForm()
        {
            InitializeComponent();
            _lineItemDetail = new POSLink2.Util.LineItemDetail();
            _taxDetails = null;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            _lineItemDetail.ItemSequenceNumber = ItemSequenceNumberTextBox.Text;
            _lineItemDetail.ProductCode = ProductCodeTextBox.Text;
            _lineItemDetail.ItemCommodityCode = ItemCommodityCodeTextBox.Text;
            _lineItemDetail.ItemDescription = ItemDescriptionTextBox.Text;
            _lineItemDetail.ItemQuantity = ItemQuantityTextBox.Text;
            _lineItemDetail.ItemMeasurementUnit = ItemMeasurementUnitTextBox.Text;
            _lineItemDetail.ItemUnitPrice = ItemUnitPriceTextBox.Text;
            _lineItemDetail.ItemDiscountAmount = ItemDiscountAmountTextBox.Text;
            _lineItemDetail.ItemDiscountRate = ItemDiscountRateTextBox.Text;
            _lineItemDetail.LineItemTotal = LineItemTotalTextBox.Text;
            _lineItemDetail.TaxDetails = _taxDetails;
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }

        private void TaxDetailsButton_Click(object sender, EventArgs e)
        {
            TaxDetailListForm taxDetailListForm = new TaxDetailListForm();
            taxDetailListForm.TaxDetailArray = _taxDetails;
            taxDetailListForm.TaxDetailString = TaxDetailsTextBox.Text;
            taxDetailListForm.ShowDialog();
            if (taxDetailListForm.DialogResult == DialogResult.OK)
            {
                _taxDetails = taxDetailListForm.TaxDetailArray;
                TaxDetailsTextBox.Text = taxDetailListForm.TaxDetailString;
            }
        }

    }
}

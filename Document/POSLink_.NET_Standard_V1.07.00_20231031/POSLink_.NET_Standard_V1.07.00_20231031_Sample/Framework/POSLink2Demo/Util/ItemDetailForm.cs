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
    public partial class ItemDetailForm : Form
    {
        public List<POSLink2.Util.ItemDetail> ItemDetails { get; set; }
        public ItemDetailForm()
        {
            InitializeComponent();
            ItemDetails = new List<POSLink2.Util.ItemDetail>();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            POSLink2.Util.ItemDetail itemDetail = new POSLink2.Util.ItemDetail();
            itemDetail.ProductName = ProductNameTextBox.Text;
            itemDetail.PluCode = PluCodeTextBox.Text;
            itemDetail.Price = PriceTextBox.Text;
            itemDetail.Unit = UnitTextBox.Text;
            itemDetail.UnitPrice = UnitPriceTextBox.Text;
            itemDetail.Tax = TaxTextBox.Text;
            itemDetail.Quantity = QuantityTextBox.Text;
            itemDetail.ProductImageName = ProductImageNameTextBox.Text;
            itemDetail.ProductImageDescription = ProductImageDescriptionTextBox.Text;
            ItemDetails.Add(itemDetail);

            string message = itemDetail.Pack();
            listBox1.Items.Add(message);
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Please select item!", "Warning");
                return;
            }

            ItemDetails.RemoveAt(listBox1.SelectedIndex);
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            ItemDetails.Clear();
            listBox1.Items.Clear();
            this.DialogResult = DialogResult.Cancel;
        }
    }
}

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
    public partial class ExtraChargeItemsForm : Form
    {
        public POSLink2.Util.ExtraChargeItem[] ExtraChargeItems { get; set; }
        private List<POSLink2.Util.ExtraChargeItem> _extraChargeItemList;
        public ExtraChargeItemsForm()
        {
            InitializeComponent();
            _extraChargeItemList = new List<POSLink2.Util.ExtraChargeItem>();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            POSLink2.Util.ExtraChargeItem extraChargeItem = new POSLink2.Util.ExtraChargeItem();
            extraChargeItem.ItemType = ItemTypeTextBox.Text;
            extraChargeItem.ExtraChargeAmount = ExtraChargeAmountTextBox.Text;
            _extraChargeItemList.Add(extraChargeItem);

            string[] items = new string[2];
            items[0] = extraChargeItem.ItemType;
            items[1] = extraChargeItem.ExtraChargeAmount;
            string temp = string.Join(",", items);
            listBox1.Items.Add(temp);
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0 || listBox1.SelectedIndex > _extraChargeItemList.Count)
            {
                MessageBox.Show("Please select item.", "Warning");
                return;
            }
            _extraChargeItemList.RemoveAt(listBox1.SelectedIndex);
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            ExtraChargeItems = _extraChargeItemList.ToArray();
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }

        private void ExtraChargeItemsForm_Load(object sender, EventArgs e)
        {
            _extraChargeItemList = new List<POSLink2.Util.ExtraChargeItem>();
            listBox1.Items.Clear();
            if (ExtraChargeItems != null && ExtraChargeItems.Length != 0)
            {
                _extraChargeItemList.AddRange(ExtraChargeItems);
                for (int i = 0; i < _extraChargeItemList.Count; i++)
                {
                    string[] items = new string[2];
                    items[0] = _extraChargeItemList[i].ItemType;
                    items[1] = _extraChargeItemList[i].ExtraChargeAmount;
                    string temp = string.Join(",", items);
                    listBox1.Items.Add(temp);
                }
            }
        }
    }
}

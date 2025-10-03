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
    public partial class LodgingItemsForm : Form
    {
        public POSLink2.Util.LodgingItem[] LodgingItems { get; set; }
        private List<POSLink2.Util.LodgingItem> _lodgingItemList;
        public LodgingItemsForm()
        {
            InitializeComponent();
            _lodgingItemList = new List<POSLink2.Util.LodgingItem>();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            POSLink2.Util.LodgingItem lodgingItem = new POSLink2.Util.LodgingItem();
            lodgingItem.ItemType = ItemTypeTextBox.Text;
            lodgingItem.ItemAmount = ItemAmountTextBox.Text;
            lodgingItem.ItemCode = ItemCodeTextBox.Text;
            _lodgingItemList.Add(lodgingItem);

            string[] items = new string[3];
            items[0] = lodgingItem.ItemType;
            items[1] = lodgingItem.ItemAmount;
            items[2] = lodgingItem.ItemCode;
            string temp = string.Join(",", items);
            listBox1.Items.Add(temp);
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0 || listBox1.SelectedIndex > _lodgingItemList.Count)
            {
                MessageBox.Show("Please select item.", "Warning");
                return;
            }
            _lodgingItemList.RemoveAt(listBox1.SelectedIndex);
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            LodgingItems = _lodgingItemList.ToArray();
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }

        private void LodgingItemsForm_Load(object sender, EventArgs e)
        {
            _lodgingItemList = new List<POSLink2.Util.LodgingItem>();
            listBox1.Items.Clear();
            if (LodgingItems != null && LodgingItems.Length != 0)
            {
                _lodgingItemList.AddRange(LodgingItems);
                for (int i = 0; i < _lodgingItemList.Count; i++)
                {
                    string[] items = new string[3];
                    items[0] = _lodgingItemList[i].ItemType;
                    items[1] = _lodgingItemList[i].ItemAmount;
                    items[2] = _lodgingItemList[i].ItemCode;
                    string temp = string.Join(",", items);
                    listBox1.Items.Add(temp);
                }
            }
        }
    }
}

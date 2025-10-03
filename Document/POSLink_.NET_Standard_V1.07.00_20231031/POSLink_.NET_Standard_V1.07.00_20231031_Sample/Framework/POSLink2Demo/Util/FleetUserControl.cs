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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSLink2Demo
{
    public partial class FleetUserControl : UserControl
    {
        public List<POSLink2.Util.FleetData> FleetDataList { get; set; }
        public FleetUserControl()
        {
            InitializeComponent();
            FleetDataList = new List<POSLink2.Util.FleetData>(0);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            POSLink2.Util.FleetData fleetData = new POSLink2.Util.FleetData();
            fleetData.ProductCode = ProductCodeTextBox.Text;
            fleetData.ProductAmount = ProductAmountTextBox.Text;
            fleetData.UnitPrice = UnitPriceTextBox.Text;
            fleetData.Quantity = QuantityTextBox.Text;
            fleetData.UnitOfMeasure = UnitOfMeasureTextBox.Text;
            FleetDataList.Add(fleetData);

            string[] tempArray = new string[5];
            tempArray[0] = fleetData.ProductCode;
            tempArray[1] = fleetData.ProductAmount;
            tempArray[2] = fleetData.UnitPrice;
            tempArray[3] = fleetData.Quantity;
            tempArray[4] = fleetData.UnitOfMeasure;
            string item = string.Join(",", tempArray);
            RetMessageListBox.Items.Add(item);
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if(RetMessageListBox.SelectedIndex < 0)
            {
                MessageBox.Show("Please select item.","Warning");
            }

            FleetDataList.RemoveAt(RetMessageListBox.SelectedIndex);
            RetMessageListBox.Items.RemoveAt(RetMessageListBox.SelectedIndex);
        }
    }
}

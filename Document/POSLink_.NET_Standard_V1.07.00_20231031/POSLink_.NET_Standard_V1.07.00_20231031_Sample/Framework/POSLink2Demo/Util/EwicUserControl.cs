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
    public partial class EwicUserControl : UserControl
    {
        public List<POSLink2.Util.EwicData> EwicDataList { get; set; }
        public EwicUserControl()
        {
            InitializeComponent();
            EwicDataList = new List<POSLink2.Util.EwicData>(0);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            POSLink2.Util.EwicData ewicData = new POSLink2.Util.EwicData();
            ewicData.UpcPluInd = UpcPluIndTextBox.Text;
            ewicData.UpcPluData = UpcPluDataTextBox.Text;
            ewicData.UpcPrice = UpcPriceTextBox.Text;
            ewicData.UpcQty = UpcQtyTextBox.Text;
            EwicDataList.Add(ewicData);

            string[] tempArray = new string[4];
            tempArray[0] = ewicData.UpcPluInd;
            tempArray[1] = ewicData.UpcPluData;
            tempArray[2] = ewicData.UpcPrice;
            tempArray[3] = ewicData.UpcQty;
            string item = string.Join(",", tempArray);
            RetMessageListBox.Items.Add(item);
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (RetMessageListBox.SelectedIndex < 0)
            {
                MessageBox.Show("Please select item.", "Warning");
            }

            EwicDataList.RemoveAt(RetMessageListBox.SelectedIndex);
            RetMessageListBox.Items.RemoveAt(RetMessageListBox.SelectedIndex);
        }
    }
}

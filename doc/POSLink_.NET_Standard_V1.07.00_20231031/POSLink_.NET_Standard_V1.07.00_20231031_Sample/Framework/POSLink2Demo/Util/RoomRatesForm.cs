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
    public partial class RoomRatesForm : Form
    {
        public POSLink2.Util.RoomRate[] RoomRates { get; set; }
        private List<POSLink2.Util.RoomRate> _roomRateList;
        public RoomRatesForm()
        {
            InitializeComponent();
            _roomRateList = new List<POSLink2.Util.RoomRate>();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            POSLink2.Util.RoomRate roomRate = new POSLink2.Util.RoomRate();
            roomRate.StayDuration = StayDurationTextBox.Text;
            roomRate.RoomRateAmount = RoomRateAmountTextBox.Text;
            roomRate.RoomRateTax = RoomRateTaxTextBox.Text;
            _roomRateList.Add(roomRate);

            string[] items = new string[3];
            items[0] = roomRate.StayDuration;
            items[1] = roomRate.RoomRateAmount;
            items[2] = roomRate.RoomRateTax;
            string temp = string.Join(",", items);
            listBox1.Items.Add(temp);
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0 || listBox1.SelectedIndex > _roomRateList.Count)
            {
                MessageBox.Show("Please select item.", "Warning");
                return;
            }
            _roomRateList.RemoveAt(listBox1.SelectedIndex);
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            RoomRates = _roomRateList.ToArray();
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }

        private void RoomRatesForm_Load(object sender, EventArgs e)
        {
            _roomRateList = new List<POSLink2.Util.RoomRate>();
            listBox1.Items.Clear();
            if (RoomRates != null && RoomRates.Length != 0)
            {
                _roomRateList.AddRange(RoomRates);
                for (int i = 0; i < _roomRateList.Count; i++)
                {
                    string[] items = new string[3];
                    items[0] = _roomRateList[i].StayDuration;
                    items[1] = _roomRateList[i].RoomRateAmount;
                    items[2] = _roomRateList[i].RoomRateTax;
                    string temp = string.Join(",", items);
                    listBox1.Items.Add(temp);
                }
            }
        }
    }
}

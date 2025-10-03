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
    public partial class LineItemDetailListForm : Form
    {
        private List<POSLink2.Util.LineItemDetail> _lineItemDetailList;
        private POSLink2.Util.LineItemDetail[] _lineItemDetailArray;
        public POSLink2.Util.LineItemDetail[] LineItemDetailArray
        {
            get { return _lineItemDetailArray; }
            set { _lineItemDetailArray = value; }
        }

        private string _lineItemDetailString;
        public string LineItemDetailString
        {
            get { return _lineItemDetailString; }
            set { _lineItemDetailString = value; }
        }

        public LineItemDetailListForm()
        {
            InitializeComponent();
            _lineItemDetailArray = null;
            _lineItemDetailList = new List<POSLink2.Util.LineItemDetail>();
            _lineItemDetailString = "";
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            LineItemDetailForm lineItemDetailFrom = new LineItemDetailForm();
            lineItemDetailFrom.ShowDialog();
            if(lineItemDetailFrom.DialogResult == DialogResult.OK)
            {
                _lineItemDetailList.Add(lineItemDetailFrom.LineItemDetail);
                string temp = "";
                temp += lineItemDetailFrom.LineItemDetail.ItemSequenceNumber;
                temp += "[1e]";
                temp += lineItemDetailFrom.LineItemDetail.ProductCode;
                temp += "[1e]";
                temp += lineItemDetailFrom.LineItemDetail.ItemCommodityCode;
                temp += "[1e]";
                temp += lineItemDetailFrom.LineItemDetail.ItemDescription;
                temp += "[1e]";
                temp += lineItemDetailFrom.LineItemDetail.ItemQuantity;
                temp += "[1e]";
                temp += lineItemDetailFrom.LineItemDetail.ItemMeasurementUnit;
                temp += "[1e]";
                temp += lineItemDetailFrom.LineItemDetail.ItemUnitPrice;
                temp += "[1e]";
                temp += lineItemDetailFrom.LineItemDetail.ItemDiscountAmount;
                temp += "[1e]";
                temp += lineItemDetailFrom.LineItemDetail.ItemDiscountRate;
                temp += "[1e]";
                if(lineItemDetailFrom.LineItemDetail.TaxDetails != null)
                {
                    for (int i=0;i< lineItemDetailFrom.LineItemDetail.TaxDetails.Length;i++)
                    {
                        if(i != 0)
                        {
                            temp += "|";
                        }
                        temp += lineItemDetailFrom.LineItemDetail.TaxDetails[i].TaxType;
                        temp += ",";
                        temp += lineItemDetailFrom.LineItemDetail.TaxDetails[i].TaxAmount;
                        temp += ",";
                        temp += lineItemDetailFrom.LineItemDetail.TaxDetails[i].TaxRate;
                        temp += ",";
                        temp += lineItemDetailFrom.LineItemDetail.TaxDetails[i].MerchantTaxId;
                        temp += ",";
                        temp += lineItemDetailFrom.LineItemDetail.TaxDetails[i].CustomerTaxId;
                        temp += ",";
                        temp += lineItemDetailFrom.LineItemDetail.TaxDetails[i].ValueAddedTaxInvoiceNumber;
                        temp = deleteUnuseString(temp, ",");
                    }
                    temp = deleteUnuseString(temp, "|");
                }
                temp += lineItemDetailFrom.LineItemDetail.LineItemTotal;
                temp = deleteUnuseString(temp, "[1e]");
                LineItemDetailListBox.Items.Add(temp);
            }
            lineItemDetailFrom.Close();
            lineItemDetailFrom.Dispose();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if(LineItemDetailListBox.SelectedIndex <0 )
            {
                return;
            }

            _lineItemDetailList.RemoveAt(LineItemDetailListBox.SelectedIndex);
            LineItemDetailListBox.Items.RemoveAt(LineItemDetailListBox.SelectedIndex);
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if(_lineItemDetailList == null)
            {
                return;
            }

            _lineItemDetailArray = new POSLink2.Util.LineItemDetail[_lineItemDetailList.Count];
            for (int i=0; i<_lineItemDetailList.Count; i++)
            {
                _lineItemDetailArray[i] = _lineItemDetailList[i];
            }

            _lineItemDetailString = "";
            for(int i=0; i< LineItemDetailListBox.Items.Count; i++)
            {
                if(i != 0)
                {
                    _lineItemDetailString += "[1d]";
                }
                _lineItemDetailString += LineItemDetailListBox.Items[i];
            }
            _lineItemDetailString = deleteUnuseString(_lineItemDetailString, "[1d]");
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }

        private string deleteUnuseString(string sourceString, string separator)
        {
            int sepLen = separator.Length;
            for (int i = sourceString.Length - sepLen; i >= 0; i = i-sepLen)
            {
                if (sourceString.Substring(i, sepLen) != separator)
                {
                    break;
                }
                sourceString = sourceString.Substring(0, sourceString.Length - sepLen);
            }

            return sourceString;
        }

        private void LineItemDetailListForm_Load(object sender, EventArgs e)
        {
            string[] sep = new string[] { "[1d]" };
            string[] lineItemDetailArray = _lineItemDetailString.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            if(lineItemDetailArray != null)
            {
                LineItemDetailListBox.Items.AddRange(lineItemDetailArray);
            }

            if(_lineItemDetailArray != null)
            {
                for(int i=0; i<_lineItemDetailArray.Length; i++)
                {
                    _lineItemDetailList.Add(_lineItemDetailArray[i]);
                }
            }

        }
    }
}

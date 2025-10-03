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
    public partial class TaxDetailListForm : Form
    {
        private List<POSLink2.Util.TaxDetail> _taxDetailList;
        private POSLink2.Util.TaxDetail[] _taxDetailArray;
        public POSLink2.Util.TaxDetail[] TaxDetailArray
        {
            get { return _taxDetailArray; }
            set { _taxDetailArray = value; }
        }

        private string _taxDetailString;
        public string TaxDetailString
        {
            get { return _taxDetailString; }
            set { _taxDetailString = value; }
        }

        public TaxDetailListForm()
        {
            InitializeComponent();
            _taxDetailArray = null;
            _taxDetailList = new List<POSLink2.Util.TaxDetail>();
            _taxDetailString = "";
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            TaxDetailForm taxDetailForm = new TaxDetailForm();
            taxDetailForm.ShowDialog();
            if (taxDetailForm.DialogResult == DialogResult.OK)
            {
                POSLink2.Util.TaxDetail taxDetail = taxDetailForm.GetTaxDetail();
                if (taxDetail != null)
                {
                    string temp = "";
                    temp += taxDetail.TaxType;
                    temp += ",";
                    temp += taxDetail.TaxAmount;
                    temp += ",";
                    temp += taxDetail.TaxRate;
                    temp += ",";
                    temp += taxDetail.MerchantTaxId;
                    temp += ",";
                    temp += taxDetail.CustomerTaxId;
                    temp += ",";
                    temp += taxDetail.ValueAddedTaxInvoiceNumber;
                    temp = deleteUnuseString(temp, ",");
                    TaxDetailListBox.Items.Add(temp);
                }
                _taxDetailList.Add(taxDetail);
                taxDetailForm.Close();
                taxDetailForm.Dispose();
            }
            else if (taxDetailForm.DialogResult == DialogResult.Cancel)
            {
                taxDetailForm.Close();
                taxDetailForm.Dispose();
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (TaxDetailListBox.SelectedIndex < 0)
            {
                return;
            }

            _taxDetailList.RemoveAt(TaxDetailListBox.SelectedIndex);
            TaxDetailListBox.Items.RemoveAt(TaxDetailListBox.SelectedIndex);
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if(TaxDetailListBox.Items.Count<0)
            {
                return;
            }

            _taxDetailString = "";
            _taxDetailArray = new POSLink2.Util.TaxDetail[TaxDetailListBox.Items.Count];
            for (int i=0;i<TaxDetailListBox.Items.Count;i++)
            {
                if(i!=0)
                {
                    _taxDetailString += "|";
                }
                _taxDetailArray[i] = _taxDetailList[i];
                _taxDetailString += TaxDetailListBox.Items[i];
            }
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }

        private void TaxDetailListForm_Load(object sender, EventArgs e)
        {
            if(_taxDetailArray == null)
            {
                return;
            }

            foreach(POSLink2.Util.TaxDetail taxDetailTemp in _taxDetailArray)
            {
                _taxDetailList.Add(taxDetailTemp);
                string temp = "";
                temp += taxDetailTemp.TaxType;
                temp += ",";
                temp += taxDetailTemp.TaxAmount;
                temp += ",";
                temp += taxDetailTemp.TaxRate;
                temp += ",";
                temp += taxDetailTemp.MerchantTaxId;
                temp += ",";
                temp += taxDetailTemp.CustomerTaxId;
                temp += ",";
                temp += taxDetailTemp.ValueAddedTaxInvoiceNumber;
                temp = deleteUnuseString(temp, ",");
                TaxDetailListBox.Items.Add(temp);
            }
        }

        private string deleteUnuseString(string sourceString, string separator)
        {
            int sepLen = separator.Length;
            for (int i = sourceString.Length - sepLen; i >= 0; i = i - sepLen)
            {
                if (sourceString.Substring(i, sepLen) != separator)
                {
                    break;
                }
                sourceString = sourceString.Substring(0, sourceString.Length - sepLen);
            }

            return sourceString;
        }
    }
}

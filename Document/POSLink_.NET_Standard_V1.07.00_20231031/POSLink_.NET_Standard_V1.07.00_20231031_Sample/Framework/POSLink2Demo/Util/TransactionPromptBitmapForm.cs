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
    public partial class TransactionPromptBitmapForm : Form
    {
        public string[] Names = new string[] 
        {
            "Confirm Total Amount",
            "Confirm Surcharge Amount",
            "Confirm Void Transaction",
            "AVS Address",
            "AVS Zip",
            "Tax",
            "CVV",
            "Cashback",
            "Clerk / Server Id",
            "Order Num / PO Num",
            "Invoice Num",
            "Debit Account",
            "Gift CVD/PIN",
            "Gift Tender Type",
            "Gift Sale mode",
            "Shift ID",
            "Table Num",
            "Guest Num",
            "Expd Prompt"
        };

        private SwitchUserControl[] _switchUserControls;

        public POSLink2.Util.TransactionPromptBitmap TransactionPromptBitmap { get; set; }
        public TransactionPromptBitmapForm()
        {
            InitializeComponent();
            _switchUserControls = new SwitchUserControl[Names.Length];
            TransactionPromptBitmap = new POSLink2.Util.TransactionPromptBitmap();
            for (int i = 0; i < _switchUserControls.Length; i++)
            {
                _switchUserControls[i] = new SwitchUserControl();
                _switchUserControls[i].Text = Names[i];
                _switchUserControls[i].Location = new Point(0, _switchUserControls[i].Height * i + 2);
                _switchUserControls[i].LabelWidth = 150;
                _switchUserControls[i].Width = 170 + _switchUserControls[i].ButtonWidth;
            }
        }

        private void TransactionPromptBitmapForm_Load(object sender, EventArgs e)
        {
            int index = 0;
            if (TransactionPromptBitmap != null)
            {
                _switchUserControls[index++].ButtonSwitch = TransactionPromptBitmap.ConfirmTotalAmount;
                _switchUserControls[index++].ButtonSwitch = TransactionPromptBitmap.ConfirmSurchargeAmount;
                _switchUserControls[index++].ButtonSwitch = TransactionPromptBitmap.ConfirmVoidTransaction;
                _switchUserControls[index++].ButtonSwitch = TransactionPromptBitmap.AvsAddress;
                _switchUserControls[index++].ButtonSwitch = TransactionPromptBitmap.AvsZip;
                _switchUserControls[index++].ButtonSwitch = TransactionPromptBitmap.Tax;
                _switchUserControls[index++].ButtonSwitch = TransactionPromptBitmap.Cvv;
                _switchUserControls[index++].ButtonSwitch = TransactionPromptBitmap.Cashback;
                _switchUserControls[index++].ButtonSwitch = TransactionPromptBitmap.ClerkOrServerId;
                _switchUserControls[index++].ButtonSwitch = TransactionPromptBitmap.OrderNumOrPoNum;
                _switchUserControls[index++].ButtonSwitch = TransactionPromptBitmap.InvoiceNum;
                _switchUserControls[index++].ButtonSwitch = TransactionPromptBitmap.DebitAccount;
                _switchUserControls[index++].ButtonSwitch = TransactionPromptBitmap.GiftCvdOrPin;
                _switchUserControls[index++].ButtonSwitch = TransactionPromptBitmap.GiftTenderType;
                _switchUserControls[index++].ButtonSwitch = TransactionPromptBitmap.GiftSaleMode;
                _switchUserControls[index++].ButtonSwitch = TransactionPromptBitmap.ShiftId;
                _switchUserControls[index++].ButtonSwitch = TransactionPromptBitmap.TableNum;
                _switchUserControls[index++].ButtonSwitch = TransactionPromptBitmap.GuestNum;
                _switchUserControls[index++].ButtonSwitch = TransactionPromptBitmap.ExpdPrompt;
            }
            panel1.Controls.AddRange(_switchUserControls);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            int index = 0;
            TransactionPromptBitmap = new POSLink2.Util.TransactionPromptBitmap();
            TransactionPromptBitmap.ConfirmTotalAmount = _switchUserControls[index++].ButtonSwitch;
            TransactionPromptBitmap.ConfirmSurchargeAmount = _switchUserControls[index++].ButtonSwitch;
            TransactionPromptBitmap.ConfirmVoidTransaction = _switchUserControls[index++].ButtonSwitch;
            TransactionPromptBitmap.AvsAddress = _switchUserControls[index++].ButtonSwitch;
            TransactionPromptBitmap.AvsZip = _switchUserControls[index++].ButtonSwitch;
            TransactionPromptBitmap.Tax = _switchUserControls[index++].ButtonSwitch;
            TransactionPromptBitmap.Cvv = _switchUserControls[index++].ButtonSwitch;
            TransactionPromptBitmap.Cashback = _switchUserControls[index++].ButtonSwitch;
            TransactionPromptBitmap.ClerkOrServerId = _switchUserControls[index++].ButtonSwitch;
            TransactionPromptBitmap.OrderNumOrPoNum = _switchUserControls[index++].ButtonSwitch;
            TransactionPromptBitmap.InvoiceNum = _switchUserControls[index++].ButtonSwitch;
            TransactionPromptBitmap.DebitAccount = _switchUserControls[index++].ButtonSwitch;
            TransactionPromptBitmap.GiftCvdOrPin = _switchUserControls[index++].ButtonSwitch;
            TransactionPromptBitmap.GiftTenderType = _switchUserControls[index++].ButtonSwitch;
            TransactionPromptBitmap.GiftSaleMode = _switchUserControls[index++].ButtonSwitch;
            TransactionPromptBitmap.ShiftId = _switchUserControls[index++].ButtonSwitch;
            TransactionPromptBitmap.TableNum = _switchUserControls[index++].ButtonSwitch;
            TransactionPromptBitmap.GuestNum = _switchUserControls[index++].ButtonSwitch;
            TransactionPromptBitmap.ExpdPrompt = _switchUserControls[index++].ButtonSwitch;
            this.DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}

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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using POSLink2.Const;
using POSLink2;
using POSLink2Demo.Properties;
using System.Xml;
using POSLink2.Device;

namespace POSLink2Demo
{
    public partial class TransactionUserControl : UserControl
    {
        private enum RequestModuleNameEnum
        {
            Normal = 0,
            Amount,
            Account,
            Check,
            Trace,
            Avs,
            Cashier,
            Commercial,
            MotoECommerce,
            Restaurant,
            HostGateway,
            TransactionBehavior,
            Original,
            MultiMerchant,
            FleetCard,
            LodgingInformation,
            AutoRental,
            HostCredential
        }

        private enum ResponseModuleNameEnum
        {
            Normal = 0,
            Host,
            Amount,
            Account,
            Check,
            Trace,
            Avs,
            Commercial,
            MotoECommerce,
            Vas,
            Tor,
            Restaurant,
            HostGateway,
            CardInfo,
            TransInfo,
            EmvTag,
            MultiMerchant,
            FleetCard
        }

        private POSLink2.Terminal _terminal;
        private Waiting _waiting;
        private bool _isCancelListening = false;
        private TerminalData _terminalData;
        private Tools _tools = new Tools();
        private ReceiptSetting _receiptSetting;

        private POSLink2.Util.AmountReq _amountInfo;
        private POSLink2.Util.AccountReq _accountInfo;
        private POSLink2.Util.CheckReq _checkInfo;
        private POSLink2.Util.TraceReq _traceInfo;
        private POSLink2.Util.AvsReq _avsInfo;
        private POSLink2.Util.CashierReq _cashierInfo;
        private POSLink2.Util.CommercialReq _commercialInfo;
        private POSLink2.Util.MotoECommerceReq _motoECommerce;
        private POSLink2.Util.Restaurant _restaurant;
        private POSLink2.Util.HostGateway _hostGateway;
        private POSLink2.Util.TransactionBehavior _transactionBehavior;
        private POSLink2.Util.Original _original;
        private POSLink2.Util.MultiMerchant _multiMerchant;
        private POSLink2.Util.FleetCard _fleetCard;
        private POSLink2.Util.Lodging _lodging;
        private POSLink2.Util.AutoRental _autoRental;
        private POSLink2.Util.HostCredential _hostCredential;
        private RequestModuleNameEnum _requestModuleNameEnum;

        public POSLink2.Terminal Terminal
        {
            set{ _terminal = value; }
        }

        private int _comboBoxIndex;
        public int ComboBoxIndex
        {
            get { return _comboBoxIndex; }
            set { _comboBoxIndex = value; }
        }

        public TransactionUserControl()
        {
            InitializeComponent();
            _amountInfo = new POSLink2.Util.AmountReq();
            _accountInfo = new POSLink2.Util.AccountReq();
            _checkInfo = new POSLink2.Util.CheckReq();
            _traceInfo = new POSLink2.Util.TraceReq();
            _avsInfo = new POSLink2.Util.AvsReq();
            _cashierInfo = new POSLink2.Util.CashierReq();
            _commercialInfo = new POSLink2.Util.CommercialReq();
            _motoECommerce = new POSLink2.Util.MotoECommerceReq();
            _restaurant = new POSLink2.Util.Restaurant();
            _hostGateway = new POSLink2.Util.HostGateway();
            _transactionBehavior = new POSLink2.Util.TransactionBehavior();
            _original = new POSLink2.Util.Original();
            _multiMerchant = new POSLink2.Util.MultiMerchant();
            _fleetCard = new POSLink2.Util.FleetCard();
            _lodging = new POSLink2.Util.Lodging();
            _autoRental = new POSLink2.Util.AutoRental();
            _hostCredential = new POSLink2.Util.HostCredential();
            _requestModuleNameEnum = RequestModuleNameEnum.Normal;
            _transactionData = TransactionData.GetTransactionData();
            _waiting = new Waiting();
            _waiting.Dock = DockStyle.Left;
            _isCancelListening = false;
            TenderTypeComboBox.Items.AddRange(TransactionCommon.CommandNames);
            _comboBoxIndex = 0;
            TenderTypeComboBox.SelectedIndex = 0;
        }

        private void TransactionUserControl_Load(object sender, EventArgs e)
        {
            TenderTypeComboBox.SelectedIndex = 0;
            NormalRequestClick(sender, e);
            NormalResponseClick(sender, e);
        }

        private void TenderTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _comboBoxIndex = TenderTypeComboBox.SelectedIndex;
            ShowRequestButtons(sender, e);
            ShowResponseButtons(sender, e);
        }

        Button[] _requestButtonArray;
        private void ShowRequestButtons(object sender, EventArgs e)
        {
            int buttonCount;
            _tools.DisposeSubControls(ButtonPanel);
            _tools.DisposeSubControls(RequestPanel);
            int locationHeight = 0;
            NormalRequestClick(sender, e);
            NormalResponseClick(sender, e);
            int index = 0;
            switch (TenderTypeComboBox.SelectedIndex)
            {
                case (int)TransactionCommandName.DoCredit://DoCredit
                    buttonCount = TransactionCommon.DoCreditRequestButtonNames.Length;
                    _requestButtonArray = new Button[buttonCount];
                    for (int i = 0; i < buttonCount; i++)
                    {
                        bool isHeightNotEnough = false;
                        if (i == 7 ||i == 10)
                        {
                            isHeightNotEnough = true;
                        }
                        _requestButtonArray[i] = Tools.CreateButton(TransactionCommon.DoCreditRequestButtonNames[i], new Point(0, locationHeight), isHeightNotEnough);
                        locationHeight += _requestButtonArray[i].Height -1;
                    }
                    _requestButtonArray[index++].Click += new EventHandler(NormalRequestClick);
                    _requestButtonArray[index++].Click += new EventHandler(AmountRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(AccountRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(TraceRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(AvsRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(CashierRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(CommercalRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(MotoECommerceRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(RestaurantRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(HostGatewayRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(TransactionBehaviorRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(OriginalRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(MultiMerchantRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(FleetCardRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(LodgingInfoRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(AutoRentalRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(HostCredentialRequestInfoClick);
                    break;
                case (int)TransactionCommandName.DoDebit://DoDebit
                    buttonCount = TransactionCommon.DoDebitRequestButtonNames.Length;
                    _requestButtonArray = new Button[buttonCount];
                    for (int i = 0; i < buttonCount; i++)
                    {
                        bool isHeightNotEnough = false;
                        if (i == 7)
                        {
                            isHeightNotEnough = true;
                        }
                        _requestButtonArray[i] = Tools.CreateButton(TransactionCommon.DoDebitRequestButtonNames[i], new Point(0, locationHeight), isHeightNotEnough);
                        locationHeight += _requestButtonArray[i].Height - 1;
                    }
                    _requestButtonArray[index++].Click += new EventHandler(NormalRequestClick);
                    _requestButtonArray[index++].Click += new EventHandler(AmountRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(AccountRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(TraceRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(CashierRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(RestaurantRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(HostGatewayRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(TransactionBehaviorRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(OriginalRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(MultiMerchantRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(FleetCardRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(LodgingInfoRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(HostCredentialRequestInfoClick);
                    break;
                case (int)TransactionCommandName.DoEBT://DoEBT
                case (int)TransactionCommandName.DoGift://DoGift
                case (int)TransactionCommandName.DoLoyalty://DoLoyalty
                    buttonCount = TransactionCommon.DoEbtRequestButtonNames.Length;
                    _requestButtonArray = new Button[buttonCount];
                    for (int i = 0; i < buttonCount; i++)
                    {
                        bool isHeightNotEnough = false;
                        if (i == 7)
                        {
                            isHeightNotEnough = true;
                        }
                        _requestButtonArray[i] = Tools.CreateButton(TransactionCommon.DoEbtRequestButtonNames[i], new Point(0, locationHeight), isHeightNotEnough);
                        locationHeight += _requestButtonArray[i].Height-1;
                    }
                    _requestButtonArray[index++].Click += new EventHandler(NormalRequestClick);
                    _requestButtonArray[index++].Click += new EventHandler(AmountRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(AccountRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(TraceRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(CashierRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(RestaurantRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(HostGatewayRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(TransactionBehaviorRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(OriginalRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(MultiMerchantRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(FleetCardRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(HostCredentialRequestInfoClick);
                    break;
                case (int)TransactionCommandName.DoCash://DoCash
                    buttonCount = TransactionCommon.DoCashRequestButtonNames.Length;
                    _requestButtonArray = new Button[buttonCount];
                    for (int i = 0; i < buttonCount; i++)
                    {
                        bool isHeightNotEnough = false;
                        if (i == 6)
                        {
                            isHeightNotEnough = true;
                        }
                        _requestButtonArray[i] = Tools.CreateButton(TransactionCommon.DoCashRequestButtonNames[i], new Point(0, locationHeight), isHeightNotEnough);
                        locationHeight += _requestButtonArray[i].Height - 1;
                    }
                    _requestButtonArray[index++].Click += new EventHandler(NormalRequestClick);
                    _requestButtonArray[index++].Click += new EventHandler(AmountRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(TraceRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(CashierRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(RestaurantRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(HostGatewayRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(TransactionBehaviorRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(OriginalRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(MultiMerchantRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(FleetCardRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(HostCredentialRequestInfoClick);
                    break;
                case (int)TransactionCommandName.DoCheck://DoCheck
                    buttonCount = TransactionCommon.DoCheckRequestButtonNames.Length;
                    _requestButtonArray = new Button[buttonCount];
                    for (int i = 0; i < buttonCount; i++)
                    {
                        bool isHeightNotEnough = false;
                        if (i == 7)
                        {
                            isHeightNotEnough = true;
                        }
                        _requestButtonArray[i] = Tools.CreateButton(TransactionCommon.DoCheckRequestButtonNames[i], new Point(0, locationHeight), isHeightNotEnough);
                        locationHeight += _requestButtonArray[i].Height - 1;
                    }
                    _requestButtonArray[index++].Click += new EventHandler(NormalRequestClick);
                    _requestButtonArray[index++].Click += new EventHandler(AmountRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(CheckRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(TraceRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(CashierRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(RestaurantRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(HostGatewayRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(TransactionBehaviorRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(OriginalRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(MultiMerchantRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(FleetCardRequestInfoClick);
                    _requestButtonArray[index++].Click += new EventHandler(HostCredentialRequestInfoClick);
                    break;
                default:
                    break;
            }
            ButtonPanel.Controls.AddRange(_requestButtonArray);
        }

        Button[] _responseButtonArray;
        private void ShowResponseButtons(object sender, EventArgs e)
        {
            int buttonCount;
            _tools.DisposeSubControls(ButtonPanel2);
            _tools.DisposeSubControls(ResponsePanel);
            int locationHeight = 0;
            NormalRequestClick(sender, e);
            NormalResponseClick(sender, e);
            int index = 0;
            switch (TenderTypeComboBox.SelectedIndex)
            {
                case (int)TransactionCommandName.DoCredit://DoCredit
                    buttonCount = TransactionCommon.DoCreditResponseButtonNames.Length;
                    _responseButtonArray = new Button[buttonCount];
                    for (int i = 0; i < buttonCount; i++)
                    {
                        bool isHeightNotEnough = false;
                        if (i == 7)
                        {
                            isHeightNotEnough = true;
                        }
                        _responseButtonArray[i] = Tools.CreateButton(TransactionCommon.DoCreditResponseButtonNames[i], new Point(0, locationHeight), isHeightNotEnough);
                        locationHeight += _responseButtonArray[i].Height - 1;
                    }
                    _responseButtonArray[index++].Click += new EventHandler(NormalResponseClick);
                    _responseButtonArray[index++].Click += new EventHandler(HostResponseInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(AmountResponseInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(AccountResponseInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(TraceResponseInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(AvsResponseInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(CommercialResponseInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(MotoECommerceResponseInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(VasResponseInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(TorResponseInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(RestaurantResponseInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(CardInfoResponseInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(PaymentTransInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(PaymentEmvTagInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(MultiMerchantResponseInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(FleetCardResponseInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(HostCredentialResponseInfoClick);
                    break;
                case (int)TransactionCommandName.DoDebit://DoDebit
                case (int)TransactionCommandName.DoEBT://DoEBT
                case (int)TransactionCommandName.DoGift://DoGift
                case (int)TransactionCommandName.DoLoyalty://DoLoyalty
                    buttonCount = TransactionCommon.DoDebitResponseButtonNames.Length;
                    _responseButtonArray = new Button[buttonCount];
                    for (int i = 0; i < buttonCount; i++)
                    {
                        bool isHeightNotEnough = false;
                        _responseButtonArray[i] = Tools.CreateButton(TransactionCommon.DoDebitResponseButtonNames[i], new Point(0, locationHeight), isHeightNotEnough);
                        locationHeight += _responseButtonArray[i].Height - 1;
                    }
                    _responseButtonArray[index++].Click += new EventHandler(NormalResponseClick);
                    _responseButtonArray[index++].Click += new EventHandler(HostResponseInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(AmountResponseInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(AccountResponseInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(TraceResponseInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(VasResponseInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(TorResponseInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(RestaurantResponseInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(CardInfoResponseInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(PaymentTransInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(PaymentEmvTagInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(MultiMerchantResponseInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(FleetCardResponseInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(HostCredentialResponseInfoClick);
                    break;
                case (int)TransactionCommandName.DoCash://DoCash
                    buttonCount = TransactionCommon.DoCashResponseButtonNames.Length;
                    _responseButtonArray = new Button[buttonCount];
                    for (int i = 0; i < buttonCount; i++)
                    {
                        bool isHeightNotEnough = false;
                        _responseButtonArray[i] = Tools.CreateButton(TransactionCommon.DoCashResponseButtonNames[i], new Point(0, locationHeight), isHeightNotEnough);
                        locationHeight += _responseButtonArray[i].Height - 1;
                    }
                    _responseButtonArray[index++].Click += new EventHandler(NormalResponseClick);
                    _responseButtonArray[index++].Click += new EventHandler(HostResponseInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(AmountResponseInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(TraceResponseInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(VasResponseInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(TorResponseInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(RestaurantResponseInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(CardInfoResponseInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(PaymentTransInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(PaymentEmvTagInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(MultiMerchantResponseInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(FleetCardResponseInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(HostCredentialResponseInfoClick);
                    break;
                case (int)TransactionCommandName.DoCheck://DoCheck
                    buttonCount = TransactionCommon.DoCheckResponseButtonNames.Length;
                    _responseButtonArray = new Button[buttonCount];
                    for (int i = 0; i < buttonCount; i++)
                    {
                        bool isHeightNotEnough = false;
                        _responseButtonArray[i] = Tools.CreateButton(TransactionCommon.DoCheckResponseButtonNames[i], new Point(0, locationHeight), isHeightNotEnough);
                        locationHeight += _responseButtonArray[i].Height - 1;
                    }
                    _responseButtonArray[index++].Click += new EventHandler(NormalResponseClick);
                    _responseButtonArray[index++].Click += new EventHandler(HostResponseInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(AmountResponseInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(CheckResponseInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(TraceResponseInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(VasResponseInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(TorResponseInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(RestaurantResponseInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(CardInfoResponseInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(PaymentTransInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(PaymentEmvTagInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(MultiMerchantResponseInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(FleetCardResponseInfoClick);
                    _responseButtonArray[index++].Click += new EventHandler(HostCredentialResponseInfoClick);
                    break;
                default:
                    break;
            }
            ButtonPanel2.Controls.AddRange(_responseButtonArray);
        }

        private TransactionData _transactionData = null;

        //Request-----------------------------------------------------------------------------------------------------------
        private void NormalRequestClick(object sender, EventArgs e)
        {
            _requestModuleNameEnum = RequestModuleNameEnum.Normal;
            _tools.DisposeSubControls(RequestPanel);
            Label transTypeLabel = CreateLabel("TransType", new Point(0, 2));
            RequestPanel.Controls.Add(transTypeLabel);
            string[] transTypeStrings = new string[Global.TransType.Length/2];
            for (int i=0; i< Global.TransType.Length/2; i++)
            {
                transTypeStrings[i] = (string)Global.TransType[i, 0];
            }
            ComboBox transTypeComboBox = CreateComboBox("TransTypeComboBox", new Point(122, 2), transTypeStrings);
            transTypeComboBox.SelectedIndex = _transactionData.TransactionTypeRequest;
            RequestPanel.Controls.Add(transTypeComboBox);

            int count = TransactionCommon.NormalRequestNames.Length / 2;
            string[] normaolData = new string[count];
            TransactionData transactionData = TransactionData.GetTransactionData();
            normaolData[0] = transactionData.AmountRequestInfoData[0];//TransactionAmount
            normaolData[1] = transactionData.AmountRequestInfoData[2];//CashBackAmount
            normaolData[2] = transactionData.TraceRequestInfoData[0];//ReferenceNumber
            normaolData[3] = transactionData.PosEchoDataRequest;//PosEchoData
            normaolData[4] = transactionData.ContinuousScreenRequest;//ContinuousScreen
            CreateRequestLabelsAndTextBoxs(count, 24, TransactionCommon.NormalRequestNames, normaolData, ref RequestPanel);
        }

        private void AmountRequestInfoClick(object sender, EventArgs e)
        {
            _requestModuleNameEnum = RequestModuleNameEnum.Amount;
            _tools.DisposeSubControls(RequestPanel);
            int count = TransactionCommon.AmountRequestNames.Length/2;
            CreateRequestLabelsAndTextBoxs(count, 2, TransactionCommon.AmountRequestNames, _transactionData.AmountRequestInfoData, ref RequestPanel);
        }

        private void AccountRequestInfoClick(object sender, EventArgs e)
        {
            _requestModuleNameEnum = RequestModuleNameEnum.Account;
            _tools.DisposeSubControls(RequestPanel);
            int count = TransactionCommon.AccountRequestNames.Length/2;
            CreateRequestLabelsAndTextBoxs(count, 2, TransactionCommon.AccountRequestNames, _transactionData.AccountRequestInfoData, ref RequestPanel);
        }

        private void CheckRequestInfoClick(object sender, EventArgs e)
        {
            _requestModuleNameEnum = RequestModuleNameEnum.Check;
            _tools.DisposeSubControls(RequestPanel);
            int count = TransactionCommon.CheckRequestNames.Length/2;
            CreateRequestLabelsAndTextBoxs(count, 2, TransactionCommon.CheckRequestNames, _transactionData.CheckRequestInfoData, ref RequestPanel);
        }

        private void TraceRequestInfoClick(object sender, EventArgs e)
        {
            _requestModuleNameEnum = RequestModuleNameEnum.Trace;
            _tools.DisposeSubControls(RequestPanel);
            int count = TransactionCommon.TraceRequestNames.Length/2;
            CreateRequestLabelsAndTextBoxs(count, 2, TransactionCommon.TraceRequestNames, _transactionData.TraceRequestInfoData, ref RequestPanel);
        }

        private void AvsRequestInfoClick(object sender, EventArgs e)
        {
            _requestModuleNameEnum = RequestModuleNameEnum.Avs;
            _tools.DisposeSubControls(RequestPanel);
            int count = TransactionCommon.AvsRequestNames.Length/2;
            CreateRequestLabelsAndTextBoxs(count, 2, TransactionCommon.AvsRequestNames, _transactionData.AvsRequestInfoData, ref RequestPanel);
        }

        private void CashierRequestInfoClick(object sender, EventArgs e)
        {
            _requestModuleNameEnum = RequestModuleNameEnum.Cashier;
            _tools.DisposeSubControls(RequestPanel);
            int count = TransactionCommon.CashierRequestNames.Length/2;
            CreateRequestLabelsAndTextBoxs(count, 2, TransactionCommon.CashierRequestNames, _transactionData.CashierRequestInfoData, ref RequestPanel);
        }

        private void CommercalRequestInfoClick(object sender, EventArgs e)
        {
            _requestModuleNameEnum = RequestModuleNameEnum.Commercial;
            _tools.DisposeSubControls(RequestPanel);
            int count = TransactionCommon.CommercialRequestNames.Length/2;
            CreateRequestLabelsAndTextBoxs(count, 2, TransactionCommon.CommercialRequestNames, _transactionData.CommercialRequestInfoData, ref RequestPanel);

            Button taxDetailButton = Tools.CreateButton("TaxDetail", new Point(5, 22 * TransactionCommon.CommercialRequestNames.Length/2 + 2), false);
            taxDetailButton.Width = 112;
            taxDetailButton.Click += new EventHandler(ShowTextDetailListForm);
            RequestPanel.Controls.Add(taxDetailButton);
            TextBox taxDetailTextBox = CreateTextBox("TaxDetailsReq", _transactionData.TaxDetailTextData, new Point(122, 22 * TransactionCommon.CommercialRequestNames.Length/2 + 2));
            RequestPanel.Controls.Add(taxDetailTextBox);

            Button lineItemDetailButton = Tools.CreateButton("LineItemDetail", new Point(5, 22 * (TransactionCommon.CommercialRequestNames.Length/2+ 1) + 2), false);
            lineItemDetailButton.Width = 112;
            lineItemDetailButton.Click += new EventHandler(ShowLineItemDetailListForm);
            RequestPanel.Controls.Add(lineItemDetailButton);
            TextBox lineItemDetailTextBox = CreateTextBox("LineItemDetailsReq", _transactionData.LineItemDetailTextData, new Point(122, 22 * (TransactionCommon.CommercialRequestNames.Length/2+ 1) + 2));
            lineItemDetailTextBox.Multiline = true;
            lineItemDetailTextBox.Height = 60;
            lineItemDetailTextBox.ScrollBars = ScrollBars.Vertical;
            RequestPanel.Controls.Add(lineItemDetailTextBox);
        }

        private void MotoECommerceRequestInfoClick(object sender, EventArgs e)
        {
            _requestModuleNameEnum = RequestModuleNameEnum.MotoECommerce;
            _tools.DisposeSubControls(RequestPanel);
            int count = TransactionCommon.MotoECommerceRequestNames.Length/2;
            CreateRequestLabelsAndTextBoxs(count, 2, TransactionCommon.MotoECommerceRequestNames, _transactionData.MotoECommerceRequestInfoData, ref RequestPanel);
        }

        private void RestaurantRequestInfoClick(object sender, EventArgs e)
        {
            _requestModuleNameEnum = RequestModuleNameEnum.Restaurant;
            _tools.DisposeSubControls(RequestPanel);
            int count = TransactionCommon.RestaurantNames.Length/2;
            CreateRequestLabelsAndTextBoxs(count, 2, TransactionCommon.RestaurantNames, _transactionData.RestaurantRequestData, ref RequestPanel);
        }

        private void HostGatewayRequestInfoClick(object sender, EventArgs e)
        {
            _requestModuleNameEnum = RequestModuleNameEnum.HostGateway;
            _tools.DisposeSubControls(RequestPanel);
            int count = TransactionCommon.HostGatewayNames.Length/2;
            CreateRequestLabelsAndTextBoxs(count, 2, TransactionCommon.HostGatewayNames, _transactionData.HostGatewayRequestData, ref RequestPanel);

            TextBox tempText = (TextBox)RequestPanel.Controls.Find("PassThruDataReqTextBox", true)[0];
            tempText.Width = 100;
            Button passThruDataButton = new Button();
            passThruDataButton.Location = new Point(tempText.Location.X + 100, tempText.Location.Y-1);
            passThruDataButton.Width = 65;
            passThruDataButton.Text = "Set";
            passThruDataButton.Click += new EventHandler(ShowSetPassThruDataForm);
            RequestPanel.Controls.Add(passThruDataButton);
        }

        private void TransactionBehaviorRequestInfoClick(object sender, EventArgs e)
        {
            _requestModuleNameEnum = RequestModuleNameEnum.TransactionBehavior;
            _tools.DisposeSubControls(RequestPanel);
            int count = TransactionCommon.TransactionBehaviorNames.Length/2;
            CreateRequestLabelsAndTextBoxs(count, 2, TransactionCommon.TransactionBehaviorNames, _transactionData.TransactionBehaviorRequestData, ref RequestPanel);

            Button transactionPromptBitmapButton = new Button();
            transactionPromptBitmapButton.Location = new Point(122, 22 * count + 2);
            transactionPromptBitmapButton.Width = 165;
            transactionPromptBitmapButton.Text = "Transaction Prompt Bitmap";
            transactionPromptBitmapButton.Click += new EventHandler(TransactionPromptBitmapButtonClick);
            RequestPanel.Controls.Add(transactionPromptBitmapButton);
        }

        private void OriginalRequestInfoClick(object sender, EventArgs e)
        {
            _requestModuleNameEnum = RequestModuleNameEnum.Original;
            _tools.DisposeSubControls(RequestPanel);
            
            Label transTypeLabel = CreateLabel("TransType", new Point(0, 2));
            RequestPanel.Controls.Add(transTypeLabel);
            string[] transTypeStrings = new string[Global.OrigTransType.Length / 2];
            for (int i = 0; i < Global.OrigTransType.Length / 2; i++)
            {
                transTypeStrings[i] = (string)Global.OrigTransType[i, 0];
            }
            ComboBox transTypeComboBox = CreateComboBox("TransTypeComboBox", new Point(122, 2), transTypeStrings);
            transTypeComboBox.SelectedIndex = _transactionData.OriginalRequestComboBoxIndex[0];
            RequestPanel.Controls.Add(transTypeComboBox);

            int count = TransactionCommon.OriginalNames.Length / 2;
            CreateRequestLabelsAndTextBoxs(count, transTypeLabel.Location.Y + transTypeLabel.Height -2, TransactionCommon.OriginalNames, _transactionData.OriginalRequestData, ref RequestPanel);
        }

        private void MultiMerchantRequestInfoClick(object sender, EventArgs e)
        {
            _requestModuleNameEnum = RequestModuleNameEnum.MultiMerchant;
            _tools.DisposeSubControls(RequestPanel);
            int count = TransactionCommon.MultiMerchantNames.Length/2;
            CreateRequestLabelsAndTextBoxs(count, 2, TransactionCommon.MultiMerchantNames, _transactionData.MultiMerchantRequestData, ref RequestPanel);
        }

        private void FleetCardRequestInfoClick(object sender, EventArgs e)
        {
            _requestModuleNameEnum = RequestModuleNameEnum.FleetCard;
            _tools.DisposeSubControls(RequestPanel);
            int count = TransactionCommon.FleetCardNames.Length/2;
            CreateRequestLabelsAndTextBoxs(count, 2, TransactionCommon.FleetCardNames, _transactionData.FleetCardRequestData, ref RequestPanel);
        }

        private void LodgingInfoRequestInfoClick(object sender, EventArgs e)
        {
            _requestModuleNameEnum = RequestModuleNameEnum.LodgingInformation;
            _tools.DisposeSubControls(RequestPanel);
            int count = TransactionCommon.LodgingInfoRequestNames.Length / 2;
            CreateRequestLabelsAndTextBoxs(count, 2, TransactionCommon.LodgingInfoRequestNames, _transactionData.LodgingInfoRequestData, ref RequestPanel);

            Button roomRatesButton = new Button();
            roomRatesButton.Location = new Point(122, 22 * count + 2);
            roomRatesButton.Width = 165;
            roomRatesButton.Text = "Room Rates";
            roomRatesButton.Click +=new EventHandler(RoomRatesClick);
            RequestPanel.Controls.Add(roomRatesButton);

            Button lodgingItemsButton = new Button();
            lodgingItemsButton.Location = new Point(122, 22 * (count+1) + 2);
            lodgingItemsButton.Width = 165;
            lodgingItemsButton.Text = "Lodging Items";
            lodgingItemsButton.Click += new EventHandler(LodgingItemsClick);
            RequestPanel.Controls.Add(lodgingItemsButton);
        }

        private void AutoRentalRequestInfoClick(object sender, EventArgs e)
        {
            _requestModuleNameEnum = RequestModuleNameEnum.AutoRental;
            _tools.DisposeSubControls(RequestPanel);
            int count = TransactionCommon.AutoRentalInfoRequestNames.Length / 2;
            CreateRequestLabelsAndTextBoxs(count, 2, TransactionCommon.AutoRentalInfoRequestNames, _transactionData.AutoRentalInfoRequestData, ref RequestPanel);

            Label vehicleClassIdLabel = CreateLabel("VehicleClassId", new Point(2, 22 * count + 2));
            RequestPanel.Controls.Add(vehicleClassIdLabel);
            string[] vehicleClassIdStrings = new string[Global.VehicleClassId.Length / 2];
            for (int i = 0; i < Global.VehicleClassId.Length / 2; i++)
            {
                vehicleClassIdStrings[i] = (string)Global.VehicleClassId[i, 0];
            }
            ComboBox vehicleClassIdComboBox = CreateComboBox("VehicleClassIdComboBox", new Point(122, 22 * count + 2), vehicleClassIdStrings);
            vehicleClassIdComboBox.SelectedIndex = _transactionData.VehicleClassIdRequest;
            RequestPanel.Controls.Add(vehicleClassIdComboBox);

            Button extraChargeItemsButton = new Button();
            extraChargeItemsButton.Location = new Point(122, 22 * (count + 1) + 2);
            extraChargeItemsButton.Width = 165;
            extraChargeItemsButton.Text = "Extra Charge Items";
            extraChargeItemsButton.Click += new EventHandler(ExtraChargeItemsButtonsClick);
            RequestPanel.Controls.Add(extraChargeItemsButton);
        }

        private void HostCredentialRequestInfoClick(object sender, EventArgs e)
        {
            _requestModuleNameEnum = RequestModuleNameEnum.HostCredential;
            _tools.DisposeSubControls(RequestPanel);
            int count = TransactionCommon.HostCredentialInfoRequestNames.Length / 2;
            CreateRequestLabelsAndTextBoxs(count, 2, TransactionCommon.HostCredentialInfoRequestNames, _transactionData.HostCredentialInfoRequestData, ref RequestPanel);
        }

        private void RoomRatesClick(object sender, EventArgs e)
        {
            RoomRatesForm roomRatesForm = new RoomRatesForm();
            roomRatesForm.RoomRates = TransactionData.GetTransactionData().RoomRates;
            DialogResult ret = roomRatesForm.ShowDialog();
            if(ret == DialogResult.OK)
            {
                TransactionData.GetTransactionData().RoomRates = roomRatesForm.RoomRates;
            }
            roomRatesForm.Dispose();
        }

        private void LodgingItemsClick(object sender, EventArgs e)
        {
            LodgingItemsForm lodgingItemsForm = new LodgingItemsForm();
            lodgingItemsForm.LodgingItems = TransactionData.GetTransactionData().LodgingItems;
            DialogResult ret = lodgingItemsForm.ShowDialog();
            if (ret == DialogResult.OK)
            {
                TransactionData.GetTransactionData().LodgingItems = lodgingItemsForm.LodgingItems;
            }
            lodgingItemsForm.Dispose();
        }

        private void ExtraChargeItemsButtonsClick(object sender, EventArgs e)
        {
            ExtraChargeItemsForm extraChargeItemsForm = new ExtraChargeItemsForm();
            extraChargeItemsForm.ExtraChargeItems = TransactionData.GetTransactionData().ExtraChargeItems;
            DialogResult ret = extraChargeItemsForm.ShowDialog();
            if (ret == DialogResult.OK)
            {
                TransactionData.GetTransactionData().ExtraChargeItems = extraChargeItemsForm.ExtraChargeItems;
            }
            extraChargeItemsForm.Dispose();
        }

        private void TransactionPromptBitmapButtonClick(object sender, EventArgs e)
        {
            TransactionPromptBitmapForm form = new TransactionPromptBitmapForm();
            form.TransactionPromptBitmap = TransactionData.GetTransactionData().TransactionPromptBitmap;
            DialogResult ret = form.ShowDialog();
            if (ret == DialogResult.OK)
            {
                TransactionData.GetTransactionData().TransactionPromptBitmap = form.TransactionPromptBitmap;
            }
            form.Dispose();
        }

        //Response-----------------------------------------------------------------------------------------------------------
        private void NormalResponseClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ResponsePanel);
            int boxCount = 0;
            if (TenderTypeComboBox.SelectedIndex == (int)TransactionCommandName.DoCredit)
            {
                int count = TransactionCommon.DoCreditNormalResponseNames.Length / 2;
                string[] normalData = new string[TransactionCommon.DoCreditNormalResponseNames.Length / 2];
                normalData[0] = _transactionData.ResponseCode;
                normalData[1] = _transactionData.ResponseMessage;
                normalData[2] = _transactionData.TransactionTypeResponse;
                normalData[3] = _transactionData.PayloadDataResponse;
                CreateRequestLabelsAndTextBoxs(count, 2, TransactionCommon.DoCreditNormalResponseNames, normalData, ref ResponsePanel);
                boxCount = 4;
            }
            else
            {
                int count = TransactionCommon.NormalResponseNames.Length/2;
                string[] normalData = new string[TransactionCommon.NormalResponseNames.Length/2];
                normalData[0] = _transactionData.ResponseCode;
                normalData[1] = _transactionData.ResponseMessage;
                normalData[2] = _transactionData.TransactionTypeResponse;
                CreateRequestLabelsAndTextBoxs(count, 2, TransactionCommon.NormalResponseNames, normalData, ref ResponsePanel);
                boxCount = 3;
            }

            Button SetReceiptButton = Tools.CreateButton("SetReceipt", new Point(122, 22 * boxCount + 2), false);
            SetReceiptButton.Width = 165;
            SetReceiptButton.Click += new EventHandler(SetReceiptClick);
            ResponsePanel.Controls.Add(SetReceiptButton);

            Button ShowReceiptButton = Tools.CreateButton("ShowReceipt", new Point(122, 22 * (boxCount+1) + 2), false);
            ShowReceiptButton.Width = 165;
            ShowReceiptButton.Click += new EventHandler(ShowReceiptClick);
            ResponsePanel.Controls.Add(ShowReceiptButton);
        }

        private void HostResponseInfoClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ResponsePanel);
            int count = TransactionCommon.HostResponseNames.Length/2;
            CreateRequestLabelsAndTextBoxs(count, 2, TransactionCommon.HostResponseNames, _transactionData.HostResponseInfoData, ref ResponsePanel);
        }

        private void AmountResponseInfoClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ResponsePanel);
            int count = TransactionCommon.AmountResponseNames.Length/2;
            CreateRequestLabelsAndTextBoxs(count, 2, TransactionCommon.AmountResponseNames, _transactionData.AmountResponseInfoData, ref ResponsePanel);
        }

        private void AccountResponseInfoClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ResponsePanel);
            int count = TransactionCommon.AccountResponseNames.Length/2;
            CreateRequestLabelsAndTextBoxs(count, 2, TransactionCommon.AccountResponseNames, _transactionData.AccountResponseInfoData, ref ResponsePanel);
        }

        private void CheckResponseInfoClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ResponsePanel);
            int count = TransactionCommon.CheckResponseNames.Length/2;
            CreateRequestLabelsAndTextBoxs(count, 2, TransactionCommon.CheckResponseNames, _transactionData.CheckResponseInfoData, ref ResponsePanel);
        }

        private void TraceResponseInfoClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ResponsePanel);
            int count = TransactionCommon.TraceResponseNames.Length/2;
            CreateRequestLabelsAndTextBoxs(count, 2, TransactionCommon.TraceResponseNames, _transactionData.TraceResponseInfoData, ref ResponsePanel);
        }

        private void AvsResponseInfoClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ResponsePanel);
            int count = TransactionCommon.AvsResponseNames.Length/2;
            CreateRequestLabelsAndTextBoxs(count, 2, TransactionCommon.AvsResponseNames, _transactionData.AvsResponseInfoData, ref ResponsePanel);
        }

        private void CommercialResponseInfoClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ResponsePanel);
            int count = TransactionCommon.CommercialResponseNames.Length/2;
            CreateRequestLabelsAndTextBoxs(count, 2, TransactionCommon.CommercialResponseNames, _transactionData.CommercialResponseInfoData, ref ResponsePanel);
        }

        private void MotoECommerceResponseInfoClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ResponsePanel);
            int count = TransactionCommon.MotoECommerceResponseNames.Length/2;
            CreateRequestLabelsAndTextBoxs(count, 2, TransactionCommon.MotoECommerceResponseNames, _transactionData.MotoECommerceResponseInfoData, ref ResponsePanel);
        }

        private void VasResponseInfoClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ResponsePanel);
            int count = TransactionCommon.VasResponseNames.Length/2;
            CreateRequestLabelsAndTextBoxs(count, 2, TransactionCommon.VasResponseNames, _transactionData.VasResponseInfoData, ref ResponsePanel);
        }

        private void TorResponseInfoClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ResponsePanel);
            int count = TransactionCommon.TorResponseNames.Length/2;
            CreateRequestLabelsAndTextBoxs(count, 2, TransactionCommon.TorResponseNames, _transactionData.TorResponseInfoData, ref ResponsePanel);
        }

        private void CardInfoResponseInfoClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ResponsePanel);
            int count = TransactionCommon.CardInfoNames.Length/2;
            CreateRequestLabelsAndTextBoxs(count, 2, TransactionCommon.CardInfoNames, _transactionData.CardInfoResponseData, ref ResponsePanel);
        }

        private void RestaurantResponseInfoClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ResponsePanel);
            int count = TransactionCommon.RestaurantNames.Length/2;
            CreateRequestLabelsAndTextBoxs(count, 2, TransactionCommon.RestaurantNames, _transactionData.RestaurantResponseData, ref ResponsePanel);
        }

        private void PaymentTransInfoClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ResponsePanel);
            int count = TransactionCommon.PaymentTransInfoNames.Length/2;
            CreateRequestLabelsAndTextBoxs(count, 2, TransactionCommon.PaymentTransInfoNames, _transactionData.PaymentTransInfoResponseData, ref ResponsePanel);

            Button addlRspDataButton = Tools.CreateButton("AddlRspData", new Point(122, 22 * TransactionCommon.PaymentTransInfoNames.Length/2 + 2), false);
            addlRspDataButton.Width = 165;
            addlRspDataButton.Click += new EventHandler(AddlRspDataClick);
            ResponsePanel.Controls.Add(addlRspDataButton);
        }

        private void PaymentEmvTagInfoClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ResponsePanel);
            int count = TransactionCommon.PaymentEmvTagNames.Length/2 ;
            CreateRequestLabelsAndTextBoxs(count, 2, TransactionCommon.PaymentEmvTagNames, _transactionData.PaymentEmvTagResponseData, ref ResponsePanel);
        }

        private void MultiMerchantResponseInfoClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ResponsePanel);
            int count = TransactionCommon.MultiMerchantNames.Length/2;
            CreateRequestLabelsAndTextBoxs(count, 2, TransactionCommon.MultiMerchantNames, _transactionData.MultiMerchantResponseData, ref ResponsePanel);
        }

        private void FleetCardResponseInfoClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ResponsePanel);
            int count = TransactionCommon.FleetCardNames.Length/2;
            CreateRequestLabelsAndTextBoxs(count, 2, TransactionCommon.FleetCardNames, _transactionData.FleetCardResponseData, ref ResponsePanel);
        }

        private void HostCredentialResponseInfoClick(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ResponsePanel);
            int count = TransactionCommon.HostCredentialResponseNames.Length/2;
            CreateRequestLabelsAndTextBoxs(count, 2, TransactionCommon.HostCredentialResponseNames, _transactionData.HostCredentialResponseNormalData, ref ResponsePanel);
        }

        private void AddlRspDataClick(object sender, EventArgs e)
        {
            AddlRspDataForm addlRspDataForm = new AddlRspDataForm();
            addlRspDataForm.SetAddlRspData(_transactionData.AddlRspDataResponse);
            addlRspDataForm.Show();
        }

        private void SetReceiptClick(object sender, EventArgs e)
        {
            SetReceiptForm setReceiptForm = new SetReceiptForm();
            setReceiptForm.ReceiptSetting = _receiptSetting;
            if(setReceiptForm.ShowDialog() == DialogResult.OK)
            {
                _receiptSetting = setReceiptForm.ReceiptSetting;
            }
        }

        private void ShowReceiptClick(object sender, EventArgs e)
        {
            ShowReceiptForm receipt = new ShowReceiptForm();

            TransactionData transactionData = TransactionData.GetTransactionData();
            string content;
            string temp;
            string right;
            string left;
            string receiptStype;
            int len;
            int tip = 0;
            int cashback = 0;
            int mechantFee = 0;
            int baseAmt = 0;
            int authAmt = 0;
            int i, count;
            int pinBypassFlag = 0;
            string cardPresent;

            if (string.IsNullOrEmpty(transactionData.ResponseCode))
            {
                MessageBox.Show("No Receipt!!");
                return;
            }

            if (transactionData.ResponseCode != "000000" && transactionData.ResponseCode != "000100" &&
                 transactionData.ResponseCode != "100003")
            {
                MessageBox.Show("No Receipt!!");
                return;
            }

            string bogusAccountNumber = "";
            if(!string.IsNullOrEmpty(transactionData.AccountResponseInfoData[0]) && transactionData.AccountResponseInfoData[0].Length>=4)
            {
                bogusAccountNumber = transactionData.AccountResponseInfoData[0];
            }
            else if(!string.IsNullOrEmpty(transactionData.CheckResponseInfoData[2]) && transactionData.CheckResponseInfoData[2].Length >=4)
            {
                bogusAccountNumber = transactionData.CheckResponseInfoData[2];
            }

            if (transactionData.ResponseCode == "100003" && bogusAccountNumber == "")
            {
                MessageBox.Show("No Receipt!!");
                return;
            }

            if(_receiptSetting == null)
            {
                MessageBox.Show("No Receipt!!");
                return;
            }

            receiptStype = _receiptSetting.ReceiptStyle;
            if (receiptStype == "Global Style")
            {
                count = 2;
            }
            else
            {
                count = 1;
            }

            content = "";
            for (i = 0; i < count; i++)
            {
                content += paddingCenter("*******************************");

                temp = _receiptSetting.ReceiptHeader1;
                if (temp != "")
                {
                    content += paddingCenter(temp);
                }

                temp = _receiptSetting.ReceiptHeader2;
                if (temp != "")
                {
                    content += paddingCenter(temp);
                }

                temp = _receiptSetting.ReceiptHeader3;
                if (temp != "")
                {
                    content += paddingCenter(temp);
                }

                temp = _receiptSetting.ReceiptHeader4;
                if (temp != "")
                {
                    content += paddingCenter(temp);
                }

                temp = _receiptSetting.ReceiptHeader5;
                if (temp != "")
                {
                    content += paddingCenter(temp);
                }

                temp = _receiptSetting.MidValue;
                if (temp != "")
                {
                    left = _receiptSetting.MidName;
                    if (left == "")
                    {
                        left = "MID:";
                    }

                    content += paddingline(left, temp);
                }

                temp = _receiptSetting.TidValue;
                if (temp != "")
                {
                    left = _receiptSetting.TidName;
                    if (left == "")
                    {
                        left = "TID:";
                    }

                    content += paddingline(left, temp);
                }

                //time stamp
                temp = transactionData.TraceResponseInfoData[2];
                if (!string.IsNullOrEmpty(temp))
                {
                    left = temp.Substring(4, 2) + "/" + temp.Substring(6, 2) + "/" + temp.Substring(0, 4);
                    right = temp.Substring(8, 2) + ":" + temp.Substring(10, 2) + ":" + temp.Substring(12, 2);

                    content += paddingline(left, right);
                }
                else
                {
                    temp = DateTime.Now.ToString("yyyyMMddHHmmss");
                    left = temp.Substring(4, 2) + "/" + temp.Substring(6, 2) + "/" + temp.Substring(0, 4);
                    right = temp.Substring(8, 2) + ":" + temp.Substring(10, 2) + ":" + temp.Substring(12, 2);

                    content += paddingline(left, right);
                }

                // edcType + transType
                content += "\n";

                string edcType = "";
                string transType = "";

                switch(TenderTypeComboBox.SelectedIndex)
                {
                    case (int)TransactionCommandName.DoCredit:
                        edcType = "CREDIT";
                        break;
                    case (int)TransactionCommandName.DoDebit:
                        edcType = "DEBIT";
                        break;
                    case (int)TransactionCommandName.DoEBT:
                        edcType = "EBT";
                        break;
                    case (int)TransactionCommandName.DoGift:
                        edcType = "GIFT";
                        break;
                    case (int)TransactionCommandName.DoLoyalty:
                        edcType = "LOYALTY";
                        break;
                    case (int)TransactionCommandName.DoCash:
                        edcType = "CASH";
                        break;
                    case (int)TransactionCommandName.DoCheck:
                        edcType = "CHECK";
                        break;
                }

                transType = Global.TransType[transactionData.TransactionTypeRequest, 0] as string;

                left = edcType + " " + transType + ":";
                content += paddingline(left, "");

                if (edcType == "EBT")
                {
                    left = "";
                    temp = transactionData.AccountResponseInfoData[3];
                    if (temp.Equals("C"))
                    {
                        left = "Cash Benefits";
                    }
                    else if (temp.Equals("F"))
                    {
                        left = "Food Stamp";
                    }
                    else if (temp.Equals("V"))
                    {
                        left = "Food Stamp Voucher";
                    }
                    else if (temp.Equals("E"))
                    {
                        left = "eWIC";
                    }
                    else if (temp.Equals("W"))
                    {
                        left = "eWIC Voucher";
                    }
                    content += paddingline(left, "");
                }
                content += "\n";

                //transaction number;
                right = transactionData.TraceResponseInfoData[0];
                if (!string.IsNullOrEmpty(right))
                {
                    left = "Transaction #:";
                    content += paddingline(left, right);
                }

                //card Type:
                if (!string.IsNullOrEmpty(transactionData.AccountResponseInfoData[6]))
                {
                    left = "Card Type:";
                    right = transactionData.AccountResponseInfoData[6];

                    content += paddingline(left, right);
                }

                //account type
                if (!string.IsNullOrEmpty(transactionData.AccountResponseInfoData[12]))
                {
                    left = "Account Type:";
                    right = parseAccountType(transactionData.AccountResponseInfoData[12]);

                    content += paddingline(left, right);
                }

                //account type
                left = "Account:";
                right = bogusAccountNumber;

                content += paddingline(left, right);

                //entry mode
                left = "Entry:";
                temp = transactionData.AccountResponseInfoData[1];

                if(!string.IsNullOrEmpty(temp))
                {
                    if (temp == "0")
                    {
                        cardPresent = transactionData.AccountResponseInfoData[10];
                        if (cardPresent == "1")
                        {
                            right = "Keyed CNP";

                        }
                        else
                        {
                            right = "Keyed CP";
                        }
                    }
                    else if (temp == "1")
                    {
                        right = "Swiped MSD";
                    }
                    else if (temp == "2")
                    {
                        if (transactionData.PaymentEmvTagResponseData[0] != "")
                        {
                            right = "Contactless Chip";
                        }
                        else
                        {
                            right = "Contactless MSD";
                        }
                    }
                    else if (temp == "3")
                    {
                        right = "Scanner";
                    }
                    else if (temp == "4")
                    {
                        right = "Contact Chip";
                    }
                    else if (temp == "5")
                    {
                        //right = "Chip Fall Back Swipe";
                        right = "FALLBACK-Swiped";
                    } 
                    content += paddingline(left, right);
                }

                if (transactionData.ResponseCode == "000000")
                {

                    right = transactionData.AmountResponseInfoData[2];
                    if (!string.IsNullOrEmpty(right) && right != "0")
                    {
                        tip = Convert.ToInt32(right);
                    }

                    right = transactionData.AmountResponseInfoData[3];
                    if (!string.IsNullOrEmpty(right) && right != "0")
                    {
                        cashback = Convert.ToInt32(right);
                    }

                    right = transactionData.AmountResponseInfoData[4];
                    if (!string.IsNullOrEmpty(right) && right != "0")
                    {
                        mechantFee = Convert.ToInt32(right);
                    }

                    authAmt = Convert.ToInt32(transactionData.AmountResponseInfoData[0]);
                    baseAmt = authAmt - tip - cashback - mechantFee;
                    if (baseAmt < authAmt)
                    {
                        left = "Amount:";
                        right = commaAmount(Convert.ToString(baseAmt));
                        content += paddingline(left, right);

                        if (tip > 0)
                        {
                            left = "Tip Amt:";
                            right = commaAmount(Convert.ToString(tip));
                            content += paddingline(left, right);
                        }

                        if (cashback > 0)
                        {
                            left = "CashBack:";
                            right = commaAmount(Convert.ToString(cashback));
                            content += paddingline(left, right);
                        }

                        if (mechantFee > 0)
                        {
                            if (edcType == "CREDIT")
                            {
                                left = "Surchage Fee:";
                            }
                            else
                            {
                                left = "Merchant Fee:";
                            }

                            right = commaAmount(Convert.ToString(mechantFee));
                            content += paddingline(left, right);

                        }
                    }

                    //tax amount
                    right = transactionData.AmountResponseInfoData[5];
                    if (!string.IsNullOrEmpty(right) && right != "0")
                    {
                        left = "Tax Amt:";
                        right = commaAmount(right);
                        content += paddingline(left, right);
                    }


                    //amount
                    temp = transactionData.AmountResponseInfoData[0];
                    if (!string.IsNullOrEmpty(temp))
                    {
                        if (baseAmt > 0)
                        {
                            if (receiptStype == "Global Style")
                            {
                                left = "Amount:";
                            }
                            else
                            {
                                left = "Total:";
                            }
                        }
                        else
                        {
                            left = "Amount:";
                        }

                        len = temp.Length;
                        if (len >= 3)
                        {
                            right = getCurrencySign() + temp.Substring(0, len - 2) + "." + temp.Substring(len - 2, 2);
                        }
                        else if (len == 2)
                        {
                            right = getCurrencySign() + "0." + temp;
                        }
                        else if (len == 1)
                        {
                            right = getCurrencySign() + "0.0" + temp;
                        }

                        content += paddingline(left, right);
                        content += "\n";
                    }

                    //Balance 
                    right = transactionData.AmountResponseInfoData[6];
                    if (!string.IsNullOrEmpty(right) && right != "0")
                    {
                        if (edcType == "EBT")
                        {
                            left = "Cash Benefit Balance:";
                            right = commaAmount(right);
                            content += paddingline(left, right);
                        }
                        else
                        {
                            left = "Balance:";
                            right = commaAmount(right);
                            content += paddingline(left, right);
                        }
                    }

                    //extra balance 
                    right = transactionData.AmountResponseInfoData[7];
                    if (!string.IsNullOrEmpty(right) && right != "0")
                    {
                        if (edcType == "EBT")
                        {
                            left = "Food Stamp Balance:";
                            right = commaAmount(right);
                            content += paddingline(left, right);
                        }
                        else
                        {
                            left = "Balance:";
                            right = commaAmount(right);
                            content += paddingline(left, right);
                        }
                    }

                    //order number
                    right = transactionData.MotoECommerceResponseInfoData[3];
                    if (!string.IsNullOrEmpty(right))
                    {
                        left = "Order Number";
                        content += paddingline(left, right);
                    }

                    //ref
                    right = transactionData.HostResponseInfoData[3];
                    if (!string.IsNullOrEmpty(right))
                    {
                        left = "Ref. Number:";
                        content += paddingline(left, right);
                    }

                    //varcode
                    right = transactionData.PaymentTransInfoResponseData[12];
                    if (!string.IsNullOrEmpty(right))
                    {
                        left = "ValCode:";
                        content += paddingline(left, right);
                    }

                    //batch
                    right = transactionData.HostResponseInfoData[5];
                    if (!string.IsNullOrEmpty(right))
                    {
                        left = "Batch No:";
                        content += paddingline(left, right);
                    }

                    //auth code
                    right = transactionData.HostResponseInfoData[2];
                    if (!string.IsNullOrEmpty(right))
                    {
                        left = "Auth Code:";

                        content += paddingline(left, right);
                    }

                    right = transactionData.AccountResponseInfoData[4];
                    if (!string.IsNullOrEmpty(right))
                    {
                        left = "Voucher Num:";
                        content += paddingline(left, right);
                    }

                    //response
                    right = transactionData.HostResponseInfoData[1];
                    if (!string.IsNullOrEmpty(right))
                    {
                        left = "Response:";

                        content += paddingline(left, right);
                        content += "\n";
                    }

                    //transaction id
                    right = transactionData.PaymentTransInfoResponseData[7];
                    if (!string.IsNullOrEmpty(right))
                    {
                        left = "Transaction ID:";

                        content += paddingline(left, right);
                        content += "\n";
                    }

                    if (receiptStype == "Global Style")
                    {
                        left = "Description:";
                        right = "________________";
                        content += paddingline(left, right);
                        content += "\n";
                    }

                    if (transactionData.ResponseMessage == "APPROVED OFFLINE")
                    {
                        right = "Pending";
                        left = "Mode:";
                        content += paddingline(left, right);
                    }
                    else if (!string.IsNullOrEmpty(transactionData.TraceResponseInfoData[0]))
                    {
                        int transactionNumber;
                        Int32.TryParse(transactionData.TraceResponseInfoData[0], out transactionNumber);
                        if (transactionNumber > 5000 && transactionNumber <= 9000)
                        {
                            right = "Pending";
                            left = "Mode:";
                            content += paddingline(left, right);
                        }
                    }
                    else if (!string.IsNullOrEmpty(transactionData.PaymentTransInfoResponseData[3]) && transactionData.PaymentTransInfoResponseData[3] == "1")
                    {
                        right = "Pending";
                        left = "Mode:";
                        content += paddingline(left, right);
                    }
                    else if(!string.IsNullOrEmpty(transactionData.PaymentEmvTagResponseData[8]))
                    {
                        right = transactionData.PaymentEmvTagResponseData[8];
                        left = "Mode:";
                        if (!string.IsNullOrEmpty(transactionData.HostResponseInfoData[2]))
                        {
                            right = "Issuer";
                        }
                        else if (right == "Y1" || right == "Y3" || right == "Z1" || right == "Z3")
                        {
                            right = "Card";
                        }
                        else
                        {
                            right = "Issuer";
                        }
                        content += paddingline(left, right);
                    }

                    //TC
                    right = transactionData.PaymentEmvTagResponseData[0];
                    if (!string.IsNullOrEmpty(right))
                    {
                        left = "TC:";
                        content += paddingline(left, right);
                    }

                    //TVR
                    right = transactionData.PaymentEmvTagResponseData[1];
                    if (!string.IsNullOrEmpty(right))
                    {
                        left = "TVR:";
                        content += paddingline(left, right);

                        byte[] tvr = DspToHex(right);
                        int a = tvr[2] & 0x08;

                        if (a != 0)
                        {
                            pinBypassFlag = 1;
                        }
                    }

                    //AID
                    right = transactionData.PaymentEmvTagResponseData[2];
                    if (!string.IsNullOrEmpty(right))
                    {
                        left = "AID:";
                        content += paddingline(left, right);
                    }

                    //TSI
                    right = transactionData.PaymentEmvTagResponseData[3];
                    if (!string.IsNullOrEmpty(right))
                    {
                        left = "TSI:";
                        content += paddingline(left, right);
                    }

                    //TSI
                    right = transactionData.PaymentEmvTagResponseData[4];
                    if (!string.IsNullOrEmpty(right))
                    {
                        left = "ATC:";
                        content += paddingline(left, right);
                    }

                    //APPLIB
                    right = transactionData.PaymentEmvTagResponseData[5];
                    if (!string.IsNullOrEmpty(right))
                    {
                        left = "APPLAB:";
                        content += paddingline(left, right);
                    }

                    //APPPN
                    right = transactionData.PaymentEmvTagResponseData[6];
                    if (!string.IsNullOrEmpty(right))
                    {
                        left = "APPPN:";
                        content += paddingline(left, right);
                    }

                    //IAD
                    right = transactionData.PaymentEmvTagResponseData[7];
                    if (!string.IsNullOrEmpty(right))
                    {
                        left = "IAD:";
                        content += paddingline(left, right);
                    }

                    //ARC
                    right = transactionData.PaymentEmvTagResponseData[8];
                    if (!string.IsNullOrEmpty(right))
                    {
                        left = "ARC:";
                        content += paddingline(left, right);
                    }

                    //CID
                    right = transactionData.PaymentEmvTagResponseData[9];
                    if (!string.IsNullOrEmpty(right))
                    {
                        left = "CID:";
                        content += paddingline(left, right);
                    }

                    content += "\n";

                    //Add Surcharge Rate or Surcharge Fee
                    if(_receiptSetting.SurchargeMode != 0)
                    {
                        if (_receiptSetting.SurchargeMode == 1)
                        {
                            content += "We impose a surcharge of " + _receiptSetting.SurchargeRateOrFee + "%\n";
                            content += " on the transaction amount on \n";
                            content += "credit card products, which is \n";
                            content += "not greater than our cost of \n";
                            content += "acceptance.\n";
                        }
                        else if (_receiptSetting.SurchargeMode == 2)
                        {
                            string surchargeFee = _receiptSetting.SurchargeRateOrFee.Insert(_receiptSetting.SurchargeRateOrFee.Length-2, ".");
                            if(surchargeFee.Length<=6)
                            {
                                content += "We impose a surcharge of $" + surchargeFee + "\n";
                                content += " on the transaction amount on \n";
                                content += "credit card products, which is \n";
                                content += "not greater than our cost of \n";
                                content += "acceptance.\n";
                            }
                            else
                            {
                                content += "We impose a surcharge of " + "\n";
                                content += "$"+ surchargeFee + " on the transaction \n";
                                content += "amount on credit card products, \n";
                                content += "which is not greater than our \n";
                                content += "cost of acceptance.\n";
                            }
                        }
                    }

                    content += "\n";

                    temp = transactionData.PaymentEmvTagResponseData[10];
                    if (i == 0)
                    {
                        if (!string.IsNullOrEmpty(temp))
                        {
                            if (temp == "1" || temp == "2" || temp == "3" || temp == "4" || temp == "5")
                            {
                                content += paddingCenter("PIN Verified");
                                content += "\n";
                            }
                            else if (pinBypassFlag == 1)
                            {
                                content += paddingCenter("PIN ByPassed");
                                content += "\n";
                            }

                            if (temp == "3" || temp == "5" || temp == "6")
                            {
                                content += "   I AGREE TO PAY ABOVE TOTAL \n";
                                content += "AMOUNT ACCORDING TO CARD ISSUER\n";
                                content += " AGREEMENT (MERCHANT AGREEMENT\n";
                                content += "     IF CREDIT VOUCHER)\n";
                                content += "\n";
                                content += "X..............................\n";
                                content += "            SIGNATURE          \n";
                                content += "\n";
                            }
                            else if (pinBypassFlag == 1)
                            {
                                content += "\n";
                                content += "X..............................\n";
                                content += "            SIGNATURE          \n";
                                content += "\n";
                            }
                        }
                        else
                        {
                            if (edcType == "CREDIT")
                            {
                                content += "   I AGREE TO PAY ABOVE TOTAL \n";
                                content += "AMOUNT ACCORDING TO CARD ISSUER\n";
                                content += " AGREEMENT (MERCHANT AGREEMENT\n";
                                content += "     IF CREDIT VOUCHER)\n";
                            }
                            content += "\n";
                            content += "X..............................\n";
                            content += "            SIGNATURE          \n";
                            content += "\n";
                        }
                    }
                    else
                    {
                        if (receiptStype == "Global Style")
                        {
                            content += paddingCenter("Retain this copy  for statement");
                            content += paddingCenter("validatation");
                        }
                    }
                }
                else if (transactionData.ResponseCode != "000000")
                {

                    if (!string.IsNullOrEmpty(transactionData.AmountRequestInfoData[0]))
                    {
                        if (receiptStype == "Global Style")
                        {
                            left = "Amount:";
                        }
                        else
                        {
                            left = "Total:";
                        }

                        len = transactionData.AmountRequestInfoData[0].Length;
                        if (len >= 3)
                        {
                            right = getCurrencySign() + transactionData.AmountRequestInfoData[0].Substring(0, len - 2) + "." + transactionData.AmountRequestInfoData[0].Substring(len - 2, 2);
                        }
                        else if (len == 2)
                        {
                            right = getCurrencySign() + "0." + transactionData.AmountRequestInfoData[0];
                        }
                        else if (len == 1)
                        {
                            right = getCurrencySign() + "0.0" + transactionData.AmountRequestInfoData[0];
                        }

                        content += paddingline(left, right);
                        content += "\n";
                    }

                    if (transactionData.ResponseMessage == "APPROVED OFFLINE")
                    {
                        right = "Pending";
                        left = "Mode:";
                        content += paddingline(left, right);
                    }
                    else if (!string.IsNullOrEmpty(transactionData.TraceResponseInfoData[0]))
                    {
                        int transactionNumber;
                        Int32.TryParse(transactionData.TraceResponseInfoData[0], out transactionNumber);
                        if (transactionNumber > 5000 && transactionNumber <= 9000)
                        {
                            right = "Pending";
                            left = "Mode:";
                            content += paddingline(left, right);
                        }
                    }
                    else if (!string.IsNullOrEmpty(transactionData.PaymentTransInfoResponseData[3]) && transactionData.PaymentTransInfoResponseData[3] == "1")
                    {
                        right = "Pending";
                        left = "Mode:";
                        content += paddingline(left, right);
                    }
                    else if(!string.IsNullOrEmpty(transactionData.PaymentEmvTagResponseData[8]))
                    {
                        right = transactionData.PaymentEmvTagResponseData[8];
                        left = "Mode:";
                        if (right == "Y1" || right == "Y3" || right == "Z1" || right == "Z3")
                        {
                            right = "Card";
                        }
                        else
                        {
                            right = "Issuer";
                        }
                        content += paddingline(left, right);
                    }

                    //TC
                    right = transactionData.PaymentEmvTagResponseData[0];
                    if (!string.IsNullOrEmpty(right))
                    {
                        left = "TC:";
                        content += paddingline(left, right);
                    }

                    //TVR
                    right = transactionData.PaymentEmvTagResponseData[1];
                    if (!string.IsNullOrEmpty(right))
                    {
                        left = "TVR:";
                        content += paddingline(left, right);

                        byte[] tvr = DspToHex(right);
                        int a = tvr[2] & 0x08;

                        if (a != 0)
                        {
                            pinBypassFlag = 1;
                        }
                    }

                    //AID
                    right = transactionData.PaymentEmvTagResponseData[2];
                    if (!string.IsNullOrEmpty(right))
                    {
                        left = "AID:";
                        content += paddingline(left, right);
                    }

                    //TSI
                    right = transactionData.PaymentEmvTagResponseData[3];
                    if (!string.IsNullOrEmpty(right))
                    {
                        left = "TSI:";
                        content += paddingline(left, right);
                    }

                    //TSI
                    right = transactionData.PaymentEmvTagResponseData[4];
                    if (!string.IsNullOrEmpty(right))
                    {
                        left = "ATC:";
                        content += paddingline(left, right);
                    }

                    //APPLIB
                    right = transactionData.PaymentEmvTagResponseData[5];
                    if (!string.IsNullOrEmpty(right))
                    {
                        left = "APPLAB:";
                        content += paddingline(left, right);
                    }

                    //APPPN
                    right = transactionData.PaymentEmvTagResponseData[6];
                    if (!string.IsNullOrEmpty(right))
                    {
                        left = "APPPN:";
                        content += paddingline(left, right);
                    }

                    //IAD
                    right = transactionData.PaymentEmvTagResponseData[7];
                    if (!string.IsNullOrEmpty(right))
                    {
                        left = "IAD:";
                        content += paddingline(left, right);
                    }

                    //ARC
                    right = transactionData.PaymentEmvTagResponseData[8];
                    if (!string.IsNullOrEmpty(right))
                    {
                        left = "ARC:";
                        content += paddingline(left, right);
                    }

                    //CID
                    right = transactionData.PaymentEmvTagResponseData[9];
                    if (!string.IsNullOrEmpty(right))
                    {
                        left = "CID:";
                        content += paddingline(left, right);
                    }

                    //AC
                    right = transactionData.PaymentEmvTagResponseData[12];
                    if (!string.IsNullOrEmpty(right))
                    {
                        left = "AC";
                        content += paddingline(left, right);
                    }

                    //AIP
                    right = transactionData.PaymentEmvTagResponseData[13];
                    if (!string.IsNullOrEmpty(right))
                    {
                        left = "AIP";
                        content += paddingline(left, right);
                    }

                    //AVN
                    right = transactionData.PaymentEmvTagResponseData[14];
                    if (!string.IsNullOrEmpty(right))
                    {
                        left = "AVN";
                        content += paddingline(left, right);
                    }

                    //IAUTHD
                    right = transactionData.PaymentEmvTagResponseData[15];
                    if (!string.IsNullOrEmpty(right))
                    {
                        left = "IAUTHD";
                        content += paddingline(left, right);
                    }

                    //CDOL2
                    right = transactionData.PaymentEmvTagResponseData[16];
                    if (!string.IsNullOrEmpty(right))
                    {
                        left = "CDOL2";
                        content += paddingline(left, right);
                    }

                    //HERD
                    right = transactionData.PaymentEmvTagResponseData[17];
                    if (!string.IsNullOrEmpty(right))
                    {
                        left = "HRED";
                        content += paddingline(left, right);
                    }

                    content += "\n";
                    content += "///////////////////////////////\n";
                    right = transactionData.HostResponseInfoData[1];
                    if (!string.IsNullOrEmpty(right))
                    {
                        content += paddingCenter(right);
                        //content += "\n";
                    }
                    else
                    {
                        right = transactionData.ResponseMessage;
                        content += paddingCenter(right);
                    }
                    content += "///////////////////////////////\n";
                }

                temp = _receiptSetting.ReceiptTrailer1;
                if (!string.IsNullOrEmpty(temp))
                {
                    content += paddingCenter(temp);
                }

                temp = _receiptSetting.ReceiptTrailer2;
                if (!string.IsNullOrEmpty(temp))
                {
                    content += paddingCenter(temp);
                }

                temp = _receiptSetting.ReceiptTrailer3;
                if (!string.IsNullOrEmpty(temp))
                {
                    content += paddingCenter(temp);
                }

                temp = _receiptSetting.ReceiptTrailer4;
                if (!string.IsNullOrEmpty(temp))
                {
                    content += paddingCenter(temp);
                }

                temp = _receiptSetting.ReceiptTrailer5;
                if (!string.IsNullOrEmpty(temp))
                {
                    content += paddingCenter(temp);
                }

                if (i == 0)
                {
                    content += "\n";
                    content += paddingCenter("MERCHANT COPY");
                    content += "\n\n";
                }
                else
                {

                    content += "\n";
                    content += paddingCenter("CUSTOMER COPY");
                    content += "\n\n";
                }
            }

            receipt.RichTextBox_Print.Text = content;
            receipt.ShowDialog();
        }

        private string paddingCenter(string msg)
        {
            string line;
            int len;
            line = "";
            if (msg.Length <= 32)
            {
                len = 32 - msg.Length;
                line = line.PadLeft(len / 2);
                line += msg;
                line += "\n";
            }
            else if (msg.Length > 32 && msg.Length <= 64)
            {
                len = 0;
                line = line.PadLeft(len / 2);
                line += msg.Substring(0, 32);
                msg = msg.Substring(32, msg.Length - 32);
                line += "\n";

                len = 32 - msg.Length;
                line = line.PadLeft(len / 2);
                line += msg;
                line += "\n";
            }
            else
            {
                len = 0;
                line = line.PadLeft(len / 2);
                line += msg.Substring(0, 32);
                msg = msg.Substring(32, msg.Length - 32);
                line += "\n";

                len = 0;
                line = line.PadLeft(len / 2);
                line += msg.Substring(0, 32);
                msg = msg.Substring(32, msg.Length - 32);
                line += "\n";
            }


            return line;
        }

        private string paddingline(string left, string right)
        {
            string line;
            int len;

            line = "";

            if (left.Length + right.Length > 32)
            {
                line += left;
                line += "\n";
                if (right.Length >= 32)
                {
                    line += right.Substring(0, 32);
                    line += "\n";
                    line += right.Substring(32);
                    //  len = 0;
                }
                else
                {
                    len = 32 - right.Length;
                    line = line.PadRight(len);
                    line += right;
                }

                line += "\n";
            }
            else
            {
                len = 32 - right.Length;

                line += left;
                line = line.PadRight(len);
                line += right;
                line += "\n";
            }
            return line;
        }

        private string parseAccountType(string accountTypeCode)
        {
            string tmp = "";
            if (accountTypeCode == "C")
            {
                tmp = "Checking";
            }
            else if (accountTypeCode == "S")
            {
                tmp = "Saving";
            }
            else if (accountTypeCode == "D")
            {
                tmp = "Default";
            }
            return tmp;
        }

        private string commaAmount(string amount)
        {
            int len;
            string temp = "0";
            len = amount.Length;
            if (len >= 3)
            {
                temp = amount.Substring(0, len - 2) + "." + amount.Substring(len - 2, 2);
            }
            else if (len == 2)
            {
                temp = "0." + amount;
            }
            else if (len == 1)
            {
                temp = "0.0" + amount;
            }

            return getCurrencySign() + temp;
        }

        private string getCurrencySign()
        {
            if (String.IsNullOrEmpty(_receiptSetting.CurrencySign))
            {
                return "USD $";
            }
            else
            {
                return _receiptSetting.CurrencySign;
            }
        }

        private byte[] DspToHex(string buf)
        {
            if (buf.Length % 2 != 0)
            {
                buf += " ";
            }
            byte[] returnBytes = new byte[buf.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
            {
                returnBytes[i] = Convert.ToByte(buf.Substring(i * 2, 2), 16);
            }
            return returnBytes;
        }

        //Module--------------------------------------------------------------------------------------------------------
        private void CreateRequestLabelsAndTextBoxs(int count, int startHeight, string[,] names, string[] texts, ref Panel panel)
        {
            Label[] labelArray = new Label[count];
            TextBox[] textBoxArray = new TextBox[count];
            if(panel == RequestPanel)
            {
                for (int i = 0; i < count; i++)
                {
                    labelArray[i] = CreateLabel(names[i,1], new Point(0, 22 * i + startHeight));
                    textBoxArray[i] = CreateTextBox(names[i,0]+"Req", texts[i], new Point(122, 22 * i + startHeight));
                }
            }
            else if(panel == ResponsePanel)
            {
                for (int i = 0; i < count; i++)
                {
                    labelArray[i] = CreateLabel(names[i,1], new Point(0, 22 * i + startHeight));
                    textBoxArray[i] = CreateTextBox(names[i,0] + "Rsp", texts[i], new Point(122, 22 * i + startHeight));
                }
            }

            panel.Controls.AddRange(labelArray);
            panel.Controls.AddRange(textBoxArray);
        }

        private Label CreateLabel(string text, Point point)
        {
            Label label = new Label();
            label.AutoSize = false;
            label.Width = 120;
            label.TextAlign = ContentAlignment.MiddleRight;
            toolTip1.SetToolTip(label, text);// Move the mouse over the top to display the full contents.
            if (text.Length>18)
            {
                text = text.Substring(0, 15)+"...";
            }
            label.Text = text;
            label.Location = point;
            return label;
        }

        private TextBox CreateTextBox(string name, string text, Point point)
        {
            TextBox textBox = new TextBox();
            textBox.Width = 165;
            textBox.Name = name + "TextBox";
            textBox.Location = point;
            textBox.Text = text;
            textBox.LostFocus += new EventHandler(LoseOfFocusTextBox);
            return textBox;
        }

        private ComboBox CreateComboBox(string name, Point point, string[] items)
        {
            ComboBox comboBox = new ComboBox();
            comboBox.Width = 165;
            comboBox.Name = name + "ComboBox";
            comboBox.Location = point;
            comboBox.Items.AddRange(items);
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.Text = items[0];
            comboBox.LostFocus += new EventHandler(LoseOfFocusComboBox);
            return comboBox;
        }

        private void RunTransaction(int tenderType, object sender, EventArgs e)
        {
            Task task = new Task(() =>
            {
                POSLink2.ExecutionResult executionResult = new POSLink2.ExecutionResult();

                switch (tenderType)
                {
                    case (int)TransactionCommandName.DoCredit://DoCredit
                        POSLink2.Transaction.DoCreditReq doCreditRequest = SetCreditRequest();
                        POSLink2.Transaction.DoCreditRsp doCreditResponse = new POSLink2.Transaction.DoCreditRsp();
                        executionResult =  _terminal.Transaction.DoCredit(doCreditRequest, out doCreditResponse);
                        if(executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(doCreditResponse);
                        }
                        break;
                    case (int)TransactionCommandName.DoDebit://DoDebit
                        POSLink2.Transaction.DoDebitReq doDebitRequest = SetDebitRequest();
                        POSLink2.Transaction.DoDebitRsp doDebitResponse = new POSLink2.Transaction.DoDebitRsp();
                        executionResult = _terminal.Transaction.DoDebit(doDebitRequest, out doDebitResponse);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(doDebitResponse);
                        }
                        break;
                    case (int)TransactionCommandName.DoEBT://DoEBT
                        POSLink2.Transaction.DoEbtReq doEbtRequest = SetEbtRequest();
                        POSLink2.Transaction.DoEbtRsp doEbtResponse = new POSLink2.Transaction.DoEbtRsp();
                        executionResult = _terminal.Transaction.DoEbt(doEbtRequest, out doEbtResponse);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(doEbtResponse);
                        }
                        break;
                    case (int)TransactionCommandName.DoGift://DoGift
                        POSLink2.Transaction.DoGiftReq doGiftRequest = SetGiftRequest();
                        POSLink2.Transaction.DoGiftRsp doGiftResponse = new POSLink2.Transaction.DoGiftRsp();
                        executionResult = _terminal.Transaction.DoGift(doGiftRequest, out doGiftResponse);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(doGiftResponse);
                        }
                        break;
                    case (int)TransactionCommandName.DoLoyalty://DoLoyalty
                        POSLink2.Transaction.DoLoyaltyReq doLoyaltyRequest  = SetLoyaltyRequest();
                        POSLink2.Transaction.DoLoyaltyRsp doLoyaltyResponse = new POSLink2.Transaction.DoLoyaltyRsp();
                        executionResult = _terminal.Transaction.DoLoyalty(doLoyaltyRequest, out doLoyaltyResponse);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(doLoyaltyResponse);
                        }
                        break;
                    case (int)TransactionCommandName.DoCash://DoCash
                        POSLink2.Transaction.DoCashReq doCashRequest = SetCashRequest();
                        POSLink2.Transaction.DoCashRsp doCashResponse = new POSLink2.Transaction.DoCashRsp();
                        executionResult = _terminal.Transaction.DoCash(doCashRequest, out doCashResponse);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(doCashResponse);
                        }
                        break;
                    case (int)TransactionCommandName.DoCheck://DoCheck
                        POSLink2.Transaction.DoCheckReq doCheckRequest = SetCheckRequest();
                        POSLink2.Transaction.DoCheckRsp doCheckResponse = new POSLink2.Transaction.DoCheckRsp();
                        executionResult = _terminal.Transaction.DoCheck(doCheckRequest, out doCheckResponse);
                        if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.Ok)
                        {
                            GetResponse(doCheckResponse);
                        }
                        break;
                    default:
                        break;
                }
                Global.IsTransactionProcessing = false;
                MethodInvoker methodInvoker = new MethodInvoker(() =>
                {
                    ShowResponseButtons(sender, e);
                    StartButton.Enabled = true;
                    if (_waiting != null)
                    {
                        _waiting.Hide();
                    }

                    if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.RecvAckTimeout)
                    {
                        MessageBox.Show("Receive ack timeout!","ERROR");
                    }
                    else if(executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.RecvDataTimeout)
                    {
                        MessageBox.Show("Receive data timeout!", "ERROR");
                    }
                    else if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.ConnectError)
                    {
                        MessageBox.Show("Connect error!", "ERROR");
                    }
                    else if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.SendDataError)
                    {
                        MessageBox.Show("Send data error!", "ERROR");
                    }
                    else if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.RecvAckError)
                    {
                        MessageBox.Show("Receive ack error!", "ERROR");
                    }
                    else if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.RecvDataError)
                    {
                        MessageBox.Show("Receive data error!", "ERROR");
                    }
                    else if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.ExceptionalHttpStatusCode)
                    {
                        MessageBox.Show("Exceptional http status code!", "ERROR");
                    }
                    else if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.LrcError)
                    {
                        MessageBox.Show("Lrc error!", "ERROR");
                    }
                    else if (executionResult.GetErrorCode() == POSLink2.ExecutionResult.Code.PackRequestError)
                    {
                        MessageBox.Show("Pack request error!", "ERROR");
                    }
                    _isCancelListening = false;
                });
                BeginInvoke(methodInvoker);

            });
            task.Start();
        }

        private void RunListener()
        {
            Task task = new Task(()=>
            {
                int reportStatus = -1;
                while (true)
                {
                    if(!_isCancelListening)
                    {
                        break;
                    }

                    if (_waiting.IsCancel)
                    {
                        _terminal.Cancel();
                        MethodInvoker methodInvoker1 = new MethodInvoker(() => {
                            _waiting.IsCancel = false;
                            _isCancelListening = false;
                        });
                        BeginInvoke(methodInvoker1);
                        break;
                    }

                    reportStatus = _terminal.GetReportStatus();

                    MethodInvoker methodInvoker2;
                    if (reportStatus == 0)
                    {
                        int a = 0;
                        methodInvoker2 = new MethodInvoker(()=> {
                            _waiting.SetReportStatus("Ready for swipe card/input account.");
                        });
                        BeginInvoke(methodInvoker2);
                    }
                    else if(reportStatus == 1)
                    {
                        methodInvoker2 = new MethodInvoker(() => {
                            _waiting.SetReportStatus("Ready for PIN entry.");
                        });
                        BeginInvoke(methodInvoker2);
                    }
                    else if (reportStatus == 2)
                    {
                        methodInvoker2 = new MethodInvoker(() => {
                            _waiting.SetReportStatus("Ready for Signature.");
                        });
                        BeginInvoke(methodInvoker2);
                    }
                    else if (reportStatus == 3)
                    {
                        methodInvoker2 = new MethodInvoker(() => {
                            _waiting.SetReportStatus("Ready for Online Processing.");
                        });
                        BeginInvoke(methodInvoker2);
                    }
                    else if (reportStatus == 4)
                    {
                        methodInvoker2 = new MethodInvoker(() => {
                            _waiting.SetReportStatus("Ready for second card input.");
                        });
                        BeginInvoke(methodInvoker2);
                    }
                    else if (reportStatus == 5)
                    {
                        methodInvoker2 = new MethodInvoker(() => {
                            _waiting.SetReportStatus("Signature retry.");
                        });
                        BeginInvoke(methodInvoker2);
                    }
                    else if (reportStatus == 6)
                    {
                        methodInvoker2 = new MethodInvoker(() => {
                            _waiting.SetReportStatus("PIN retry.");
                        });
                        BeginInvoke(methodInvoker2);
                    }
                    else if (reportStatus == 9020002)
                    {
                        methodInvoker2 = new MethodInvoker(() => {
                            _waiting.SetReportStatus("Please enter cash back.");
                        });
                        BeginInvoke(methodInvoker2);
                    }
                }
            });
            task.Start();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if(Global.IsTransactionProcessing)
            {
                MessageBox.Show("A transaction is processing.", "Warning");
                return;
            }
            Global.IsTransactionProcessing = true;
            StartButton.Enabled = false;
            _transactionData.ResponseClear();
            _waiting.SetReportStatus("");
            _waiting.IsCancelAvaliable = true;
            _waiting.Location = new Point(0, 0);
            CenterPanel.Controls.Add(_waiting);
            _waiting.Show();
            
            int tenderType = TenderTypeComboBox.SelectedIndex;
            RunTransaction(tenderType, sender, e);
            _isCancelListening = true;
            RunListener();
        }

        public static void GetHostInformation(POSLink2.Util.HostRsp response)
        {
            if (response != null)
            {
                TransactionData transactionData = TransactionData.GetTransactionData();
                transactionData.HostResponseInfoData[0] = response.HostResponseCode;
                transactionData.HostResponseInfoData[1] = response.HostResponseMessage;
                transactionData.HostResponseInfoData[2] = response.AuthCode;
                transactionData.HostResponseInfoData[3] = response.HostRefNum;
                transactionData.HostResponseInfoData[4] = response.TraceNumber;
                transactionData.HostResponseInfoData[5] = response.BatchNumber;
                transactionData.HostResponseInfoData[6] = response.TransactionIdentifier;
                transactionData.HostResponseInfoData[7] = response.GatewayTransactionID;
                transactionData.HostResponseInfoData[8] = response.HostDetailedMessage;
                transactionData.HostResponseInfoData[9] = response.TransactionIntegrityClass;
                transactionData.HostResponseInfoData[10] = response.RetrievalRefNum;
                transactionData.HostResponseInfoData[11] = response.IssuerResponseCode;
                transactionData.HostResponseInfoData[12] = response.PaymentAccountRefId;
            }
        }

        public static void GetAmountInformation(POSLink2.Util.AmountRsp response)
        {
            if (response != null)
            {
                TransactionData transactionData = TransactionData.GetTransactionData();
                transactionData.AmountResponseInfoData[0] = response.ApproveAmount;
                transactionData.AmountResponseInfoData[1] = response.AmountDue;
                transactionData.AmountResponseInfoData[2] = response.TipAmount;
                transactionData.AmountResponseInfoData[3] = response.CashBackAmount;
                transactionData.AmountResponseInfoData[4] = response.MerchantFee;
                transactionData.AmountResponseInfoData[5] = response.TaxAmount;
                transactionData.AmountResponseInfoData[6] = response.Balance1;
                transactionData.AmountResponseInfoData[7] = response.Balance2;
                transactionData.AmountResponseInfoData[8] = response.ServiceFee;
                transactionData.AmountResponseInfoData[9] = response.TransactionRemainingAmount;
                transactionData.AmountResponseInfoData[10] = response.ApprovedTipAmount;
                transactionData.AmountResponseInfoData[11] = response.ApprovedCashBackAmount;
                transactionData.AmountResponseInfoData[12] = response.ApprovedMerchantFee;
                transactionData.AmountResponseInfoData[13] = response.ApprovedTaxAmount;
            }
        }

        public static void GetAccountInformation(POSLink2.Util.AccountRsp response)
        {
            if (response != null)
            {
                TransactionData transactionData = TransactionData.GetTransactionData();
                transactionData.AccountResponseInfoData[0] = response.Account;
                transactionData.AccountResponseInfoData[1] = response.EntryMode;
                transactionData.AccountResponseInfoData[2] = response.ExpireDate;
                transactionData.AccountResponseInfoData[3] = response.EbtType;
                transactionData.AccountResponseInfoData[4] = response.VoucherNumber;
                transactionData.AccountResponseInfoData[5] = response.NewAccountNo;
                transactionData.AccountResponseInfoData[6] = response.CardType;
                transactionData.AccountResponseInfoData[7] = response.CardHolder;
                transactionData.AccountResponseInfoData[8] = response.CvdApprovalCode;
                transactionData.AccountResponseInfoData[9] = response.CvdMessage;
                transactionData.AccountResponseInfoData[10] = response.CardPresentIndicator;
                transactionData.AccountResponseInfoData[11] = response.GiftCardType;
                transactionData.AccountResponseInfoData[12] = response.DebitAccountType;
                transactionData.AccountResponseInfoData[13] = response.HostAccount;
                transactionData.AccountResponseInfoData[14] = response.HostCardType;
                transactionData.AccountResponseInfoData[15] = response.Track1Data;
                transactionData.AccountResponseInfoData[16] = response.Track2Data;
                transactionData.AccountResponseInfoData[17] = response.Track3Data;
            }
        }

        public static void GetTraceInformation(POSLink2.Util.TraceRsp response)
        {
            if (response != null)
            {
                TransactionData transactionData = TransactionData.GetTransactionData();
                transactionData.TraceResponseInfoData[0] = response.RefNum;
                transactionData.TraceResponseInfoData[1] = response.EcrRefNum;
                transactionData.TraceResponseInfoData[2] = response.TimeStamp;
                transactionData.TraceResponseInfoData[3] = response.InvoiceNumber;
                transactionData.TraceResponseInfoData[4] = response.PaymentService2000;
                transactionData.TraceResponseInfoData[5] = response.AuthorizationResponse;
                transactionData.TraceResponseInfoData[6] = response.EcrTransID;
                transactionData.TraceResponseInfoData[7] = response.HostTimeStamp;
            }
        }

        public static void GetAvsInformation(POSLink2.Util.AvsRsp response)
        {
            if (response != null)
            {
                TransactionData transactionData = TransactionData.GetTransactionData();
                transactionData.AvsResponseInfoData[0] = response.AvsApprovalCode;
                transactionData.AvsResponseInfoData[1] = response.AvsMessage;
                transactionData.AvsResponseInfoData[2] = response.ZipCode;
                transactionData.AvsResponseInfoData[3] = response.Address1;
                transactionData.AvsResponseInfoData[4] = response.Address2;
            }
        }

        public static void GetCommercialInformation(POSLink2.Util.CommercialRsp response)
        {
            if (response != null)
            {
                TransactionData transactionData = TransactionData.GetTransactionData();
                transactionData.CommercialResponseInfoData[0] = response.PoNumber;
                transactionData.CommercialResponseInfoData[1] = response.CustomerCode;
                transactionData.CommercialResponseInfoData[2] = response.TaxExempt;
                transactionData.CommercialResponseInfoData[3] = response.TaxExemptID;
                transactionData.CommercialResponseInfoData[4] = response.MerchantTaxID;
                transactionData.CommercialResponseInfoData[5] = response.DestinationZipCode;
                transactionData.CommercialResponseInfoData[6] = response.ProductDescription;
            }
        }

        public static void GetMotoECommerceInformation(POSLink2.Util.MotoECommerceRsp response)
        {
            if (response != null)
            {
                TransactionData transactionData = TransactionData.GetTransactionData();
                transactionData.MotoECommerceResponseInfoData[0] = response.Mode;
                transactionData.MotoECommerceResponseInfoData[1] = response.TransactionType;
                transactionData.MotoECommerceResponseInfoData[2] = response.SecureType;
                transactionData.MotoECommerceResponseInfoData[3] = response.OrderNumber;
                transactionData.MotoECommerceResponseInfoData[4] = response.Installments;
                transactionData.MotoECommerceResponseInfoData[5] = response.CurrentInstallment;
            }
        }

        public static void GetVasInformation(POSLink2.Util.VasRsp response)
        {
            if (response != null)
            {
                TransactionData transactionData = TransactionData.GetTransactionData();
                transactionData.VasResponseInfoData[0] = response.VasCode;
                transactionData.VasResponseInfoData[1] = response.VasData;
                transactionData.VasResponseInfoData[2] = response.NdefData;
            }
        }

        public static void GetTorInformation(POSLink2.Util.TorRsp response)
        {
            if (response != null)
            {
                TransactionData transactionData = TransactionData.GetTransactionData();
                transactionData.TorResponseInfoData[0] = response.RecordType;
                transactionData.TorResponseInfoData[1] = response.ReversalTimeStamp;
                transactionData.TorResponseInfoData[2] = response.HostResponseCode;
                transactionData.TorResponseInfoData[3] = response.HostResponseMessage;
                transactionData.TorResponseInfoData[4] = response.HostRefNum;
                transactionData.TorResponseInfoData[5] = response.GatewayTransactionID;
                transactionData.TorResponseInfoData[6] = response.OrigAmount;
                transactionData.TorResponseInfoData[7] = response.MaskedPan;
                transactionData.TorResponseInfoData[8] = response.BatchNo;
                transactionData.TorResponseInfoData[9] = response.ReversalAuthCode;
                transactionData.TorResponseInfoData[10] = Tools.ParseTransType(response.OrigTransType);
                transactionData.TorResponseInfoData[11] = response.OrigTransDateTime;
                transactionData.TorResponseInfoData[12] = response.OrigTransAuthCode;
            }
        }

        public static void GetRestaurant(POSLink2.Util.Restaurant response)
        {
            if (response != null)
            {
                TransactionData transactionData = TransactionData.GetTransactionData();
                transactionData.RestaurantResponseData[0] = response.TableNumber;
                transactionData.RestaurantResponseData[1] = response.GuestNumber;
                transactionData.RestaurantResponseData[2] = response.TicketNumber;
            }
        }

        public static void GetCardInfo(POSLink2.Util.CardInfo response)
        {
            if (response != null)
            {
                TransactionData transactionData = TransactionData.GetTransactionData();
                transactionData.CardInfoResponseData[0] = response.CardBin;
                transactionData.CardInfoResponseData[1] = response.NewCardBin;
                transactionData.CardInfoResponseData[2] = response.ProgramType;
                transactionData.CardInfoResponseData[3] = response.HostProgramType;
            }
        }

        public static void GetPaymentTransInfo(POSLink2.Util.PaymentTransInfo response)
        {
            if (response != null)
            {
                TransactionData transactionData = TransactionData.GetTransactionData();
                transactionData.PaymentTransInfoResponseData[0] = response.DiscountAmount;
                transactionData.PaymentTransInfoResponseData[1] = response.ChargedAmount;
                transactionData.PaymentTransInfoResponseData[2] = response.SignatureStatus;
                transactionData.PaymentTransInfoResponseData[3] = response.Fps;
                transactionData.PaymentTransInfoResponseData[4] = response.FpsSignature;
                transactionData.PaymentTransInfoResponseData[5] = response.FpsReceipt;
                transactionData.PaymentTransInfoResponseData[6] = response.Token;
                transactionData.PaymentTransInfoResponseData[7] = response.HRef;
                transactionData.PaymentTransInfoResponseData[8] = response.Sn;
                transactionData.PaymentTransInfoResponseData[9] = response.SettlementDate;
                transactionData.PaymentTransInfoResponseData[10] = response.HostEchoData;
                transactionData.PaymentTransInfoResponseData[11] = response.PinStatusNum;
                transactionData.PaymentTransInfoResponseData[12] = response.ValidationCode;
                transactionData.PaymentTransInfoResponseData[13] = response.UserLanguageStatus;
                transactionData.PaymentTransInfoResponseData[14] = response.GlobalUid;
                transactionData.PaymentTransInfoResponseData[15] = response.OrigTip;
                transactionData.PaymentTransInfoResponseData[16] = response.EdcType;
                transactionData.PaymentTransInfoResponseData[17] = response.PrintLine1;
                transactionData.PaymentTransInfoResponseData[18] = response.PrintLine2;
                transactionData.PaymentTransInfoResponseData[19] = response.PrintLine3;
                transactionData.PaymentTransInfoResponseData[20] = response.PrintLine4;
                transactionData.PaymentTransInfoResponseData[21] = response.PrintLine5;
                transactionData.PaymentTransInfoResponseData[22] = response.EwicBenefitExpd;
                transactionData.PaymentTransInfoResponseData[23] = response.EwicBalance;
                transactionData.PaymentTransInfoResponseData[24] = response.EwicDetail;
                transactionData.PaymentTransInfoResponseData[25] = response.ReverseAmount;
                transactionData.PaymentTransInfoResponseData[26] = response.ReversalStatus;
                transactionData.PaymentTransInfoResponseData[27] = response.TokenSerialNum;
                transactionData.PaymentTransInfoResponseData[28] = response.SignatureData;
                transactionData.AddlRspDataResponse = response.AddlRspDataInfo;
            }
        }

        public static void GetPaymentEmvTag(POSLink2.Util.PaymentEmvTag response)
        {
            if (response != null)
            {
                TransactionData transactionData = TransactionData.GetTransactionData();
                transactionData.PaymentEmvTagResponseData[0] = response.Tc;
                transactionData.PaymentEmvTagResponseData[1] = response.Tvr;
                transactionData.PaymentEmvTagResponseData[2] = response.Aid;
                transactionData.PaymentEmvTagResponseData[3] = response.Tsi;
                transactionData.PaymentEmvTagResponseData[4] = response.Atc;
                transactionData.PaymentEmvTagResponseData[5] = response.AppLabel;
                transactionData.PaymentEmvTagResponseData[6] = response.AppPreferName;
                transactionData.PaymentEmvTagResponseData[7] = response.Iad;
                transactionData.PaymentEmvTagResponseData[8] = response.Arc;
                transactionData.PaymentEmvTagResponseData[9] = response.Cid;
                transactionData.PaymentEmvTagResponseData[10] = response.Cvm;
                transactionData.PaymentEmvTagResponseData[11] = response.Arqc;
                transactionData.PaymentEmvTagResponseData[12] = response.Ac;
                transactionData.PaymentEmvTagResponseData[13] = response.Aip;
                transactionData.PaymentEmvTagResponseData[14] = response.Avn;
                transactionData.PaymentEmvTagResponseData[15] = response.IssuerAuthData;
                transactionData.PaymentEmvTagResponseData[16] = response.Cdol2;
                transactionData.PaymentEmvTagResponseData[17] = response.Hred;
                transactionData.PaymentEmvTagResponseData[18] = response.TacDefault;
                transactionData.PaymentEmvTagResponseData[19] = response.TacDenial;
                transactionData.PaymentEmvTagResponseData[20] = response.TacOnline;
                transactionData.PaymentEmvTagResponseData[21] = response.IacDefault;
                transactionData.PaymentEmvTagResponseData[22] = response.IacDenial;
                transactionData.PaymentEmvTagResponseData[23] = response.IacOnline;
                transactionData.PaymentEmvTagResponseData[24] = response.Auc;
                transactionData.PaymentEmvTagResponseData[25] = response.PanSequenceNumber;
            }
        }

        public static void GetMultiMerchant(POSLink2.Util.MultiMerchant response)
        {
            if (response != null)
            {
                TransactionData transactionData = TransactionData.GetTransactionData();
                transactionData.MultiMerchantResponseData[0] = response.Id;
                transactionData.MultiMerchantResponseData[1] = response.Name;
            }
        }

        public static void GetFleetCard(POSLink2.Util.FleetCard response)
        {
            if (response != null)
            {
                TransactionData transactionData = TransactionData.GetTransactionData();
                transactionData.FleetCardResponseData[0] = response.Odometer;
                transactionData.FleetCardResponseData[1] = response.VehicleNumber;
                transactionData.FleetCardResponseData[2] = response.JobNumber;
                transactionData.FleetCardResponseData[3] = response.DriverId;
                transactionData.FleetCardResponseData[4] = response.EmployeeNumber;
                transactionData.FleetCardResponseData[5] = response.LicenseNumber;
                transactionData.FleetCardResponseData[6] = response.JobId;
                transactionData.FleetCardResponseData[7] = response.DepartmentNumber;
                transactionData.FleetCardResponseData[8] = response.CustomerData;
                transactionData.FleetCardResponseData[9] = response.UserId;
                transactionData.FleetCardResponseData[10] = response.VehicleId;
                transactionData.FleetCardResponseData[11] = response.FleetPromptCode;
            }
        }

        public static void GetHostCredentialInformation(POSLink2.Util.HostCredentialRsp response)
        {
            if (response != null)
            {
                TransactionData transactionData = TransactionData.GetTransactionData();
                transactionData.HostCredentialResponseNormalData[0] = response.HostTid;
            }
        }

        public static void GetCheckInformation(POSLink2.Util.CheckRsp response)
        {
            if (response != null)
            {
                TransactionData transactionData = TransactionData.GetTransactionData();
                transactionData.CheckResponseInfoData[0] = response.SaleType;
                transactionData.CheckResponseInfoData[1] = response.RoutingNumber;
                transactionData.CheckResponseInfoData[2] = response.AccountNumber;
                transactionData.CheckResponseInfoData[3] = response.CheckNumber;
                transactionData.CheckResponseInfoData[4] = response.CheckType;
                transactionData.CheckResponseInfoData[5] = response.IdType;
                transactionData.CheckResponseInfoData[6] = response.IdValue;
                transactionData.CheckResponseInfoData[7] = response.Birth;
                transactionData.CheckResponseInfoData[8] = response.PhoneNumber;
                transactionData.CheckResponseInfoData[9] = response.ZipCode;
            }
        }

        public static void GetResponse(POSLink2.Transaction.DoCreditRsp response)
        {
            TransactionData transactionData = TransactionData.GetTransactionData();
            transactionData.ResponseCode = response.ResponseCode;
            transactionData.ResponseMessage = response.ResponseMessage;
            transactionData.TransactionTypeResponse = Tools.ParseTransType(response.TransactionType);
            transactionData.PayloadDataResponse = response.PayloadData;
            GetHostInformation(response.HostInformation);
            GetAmountInformation(response.AmountInformation);
            GetAccountInformation(response.AccountInformation);
            GetTraceInformation(response.TraceInformation);
            GetAvsInformation(response.AvsInformation);
            GetCommercialInformation(response.CommercialInformation);
            GetMotoECommerceInformation(response.MotoECommerceInformation);
            GetVasInformation(response.VasInformation);
            GetTorInformation(response.TorInformation);
            GetRestaurant(response.Restaurant);
            GetCardInfo(response.CardInfo);
            GetPaymentTransInfo(response.PaymentTransInfo);
            GetPaymentEmvTag(response.PaymentEmvTag);
            GetMultiMerchant(response.MultiMerchant);
            GetFleetCard(response.FleetCard);
            GetHostCredentialInformation(response.HostCredentialInformation);
        }

        public static void GetResponse(POSLink2.Transaction.DoDebitRsp response)
        {
            TransactionData transactionData = TransactionData.GetTransactionData();
            transactionData.ResponseCode = response.ResponseCode;
            transactionData.ResponseMessage = response.ResponseMessage;
            transactionData.TransactionTypeResponse = Tools.ParseTransType(response.TransactionType);
            GetHostInformation(response.HostInformation);
            GetAmountInformation(response.AmountInformation);
            GetAccountInformation(response.AccountInformation);
            GetTraceInformation(response.TraceInformation);
            GetVasInformation(response.VasInformation);
            GetTorInformation(response.TorInformation);
            GetRestaurant(response.Restaurant);
            GetCardInfo(response.CardInfo);
            GetPaymentTransInfo(response.PaymentTransInfo);
            GetPaymentEmvTag(response.PaymentEmvTag);
            GetMultiMerchant(response.MultiMerchant);
            GetFleetCard(response.FleetCard);
            GetHostCredentialInformation(response.HostCredentialInformation);
        }

        public static void GetResponse(POSLink2.Transaction.DoEbtRsp response)
        {
            TransactionData transactionData = TransactionData.GetTransactionData();
            transactionData.ResponseCode = response.ResponseCode;
            transactionData.ResponseMessage = response.ResponseMessage;
            transactionData.TransactionTypeResponse = Tools.ParseTransType(response.TransactionType);
            GetHostInformation(response.HostInformation);
            GetAmountInformation(response.AmountInformation);
            GetAccountInformation(response.AccountInformation);
            GetTraceInformation(response.TraceInformation);
            GetVasInformation(response.VasInformation);
            GetTorInformation(response.TorInformation);
            GetRestaurant(response.Restaurant);
            GetCardInfo(response.CardInfo);
            GetPaymentTransInfo(response.PaymentTransInfo);
            GetPaymentEmvTag(response.PaymentEmvTag);
            GetMultiMerchant(response.MultiMerchant);
            GetFleetCard(response.FleetCard);
            GetHostCredentialInformation(response.HostCredentialInformation);
        }

        public static void GetResponse(POSLink2.Transaction.DoGiftRsp response)
        {
            TransactionData transactionData = TransactionData.GetTransactionData();
            transactionData.ResponseCode = response.ResponseCode;
            transactionData.ResponseMessage = response.ResponseMessage;
            transactionData.TransactionTypeResponse = Tools.ParseTransType(response.TransactionType);
            GetHostInformation(response.HostInformation);
            GetAmountInformation(response.AmountInformation);
            GetAccountInformation(response.AccountInformation);
            GetTraceInformation(response.TraceInformation);
            GetVasInformation(response.VasInformation);
            GetTorInformation(response.TorInformation);
            GetRestaurant(response.Restaurant);
            GetCardInfo(response.CardInfo);
            GetPaymentTransInfo(response.PaymentTransInfo);
            GetPaymentEmvTag(response.PaymentEmvTag);
            GetMultiMerchant(response.MultiMerchant);
            GetFleetCard(response.FleetCard);
            GetHostCredentialInformation(response.HostCredentialInformation);
        }

        public static void GetResponse(POSLink2.Transaction.DoLoyaltyRsp response)
        {
            TransactionData transactionData = TransactionData.GetTransactionData();
            transactionData.ResponseCode = response.ResponseCode;
            transactionData.ResponseMessage = response.ResponseMessage;
            transactionData.TransactionTypeResponse = Tools.ParseTransType(response.TransactionType);
            GetHostInformation(response.HostInformation);
            GetAmountInformation(response.AmountInformation);
            GetAccountInformation(response.AccountInformation);
            GetTraceInformation(response.TraceInformation);
            GetVasInformation(response.VasInformation);
            GetTorInformation(response.TorInformation);
            GetRestaurant(response.Restaurant);
            GetCardInfo(response.CardInfo);
            GetPaymentTransInfo(response.PaymentTransInfo);
            GetPaymentEmvTag(response.PaymentEmvTag);
            GetMultiMerchant(response.MultiMerchant);
            GetFleetCard(response.FleetCard);
            GetHostCredentialInformation(response.HostCredentialInformation);
        }

        public static void GetResponse(POSLink2.Transaction.DoCashRsp response)
        {
            TransactionData transactionData = TransactionData.GetTransactionData();
            transactionData.ResponseCode = response.ResponseCode;
            transactionData.ResponseMessage = response.ResponseMessage;
            transactionData.TransactionTypeResponse = Tools.ParseTransType(response.TransactionType);
            GetHostInformation(response.HostInformation);
            GetAmountInformation(response.AmountInformation);
            GetTraceInformation(response.TraceInformation);
            GetVasInformation(response.VasInformation);
            GetTorInformation(response.TorInformation);
            GetRestaurant(response.Restaurant);
            GetCardInfo(response.CardInfo);
            GetPaymentTransInfo(response.PaymentTransInfo);
            GetPaymentEmvTag(response.PaymentEmvTag);
            GetMultiMerchant(response.MultiMerchant);
            GetFleetCard(response.FleetCard);
            GetHostCredentialInformation(response.HostCredentialInformation);
        }

        public static void GetResponse(POSLink2.Transaction.DoCheckRsp response)
        {
            TransactionData transactionData = TransactionData.GetTransactionData();
            transactionData.ResponseCode = response.ResponseCode;
            transactionData.ResponseMessage = response.ResponseMessage;
            transactionData.TransactionTypeResponse = Tools.ParseTransType(response.TransactionType);
            GetHostInformation(response.HostInformation);
            GetAmountInformation(response.AmountInformation);
            GetCheckInformation(response.CheckInformation);
            GetTraceInformation(response.TraceInformation);
            GetVasInformation(response.VasInformation);
            GetTorInformation(response.TorInformation);
            GetRestaurant(response.Restaurant);
            GetCardInfo(response.CardInfo);
            GetPaymentTransInfo(response.PaymentTransInfo);
            GetPaymentEmvTag(response.PaymentEmvTag);
            GetMultiMerchant(response.MultiMerchant);
            GetFleetCard(response.FleetCard);
            GetHostCredentialInformation(response.HostCredentialInformation);
        }

        private void LoseOfFocusComboBox(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            switch(_requestModuleNameEnum)
            {
                case RequestModuleNameEnum.Normal:
                    SetReqNormalData(comboBox);
                    break;
                case RequestModuleNameEnum.Original:
                    SetOrignalData(comboBox);
                    break;
                case RequestModuleNameEnum.AutoRental:
                    SetReqAutoRentalInfoData(comboBox);
                    break;
                default:
                    break;
            }
        }

        private void LoseOfFocusTextBox(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            switch(_requestModuleNameEnum)
            {
                case RequestModuleNameEnum.Normal:
                    SetReqNormalData(textBox);
                    break;
                case RequestModuleNameEnum.Amount:
                    SetReqAmountData(textBox);
                    break;
                case RequestModuleNameEnum.Account:
                    SetReqAccountData(textBox);
                    break;
                case RequestModuleNameEnum.Check:
                    SetReqCheckData(textBox);
                    break;
                case RequestModuleNameEnum.Trace:
                    SetReqTraceData(textBox);
                    break;
                case RequestModuleNameEnum.Avs:
                    SetReqAvsData(textBox);
                    break;
                case RequestModuleNameEnum.Cashier:
                    SetReqCashierData(textBox);
                    break;
                case RequestModuleNameEnum.Commercial:
                    SetReqCommercialData(textBox);
                    break;
                case RequestModuleNameEnum.MotoECommerce:
                    SetReqMotoECommerceData(textBox);
                    break;
                case RequestModuleNameEnum.Restaurant:
                    SetReqRestaurantData(textBox);
                    break;
                case RequestModuleNameEnum.HostGateway:
                    SetReqHostGatewayData(textBox);
                    break;
                case RequestModuleNameEnum.TransactionBehavior:
                    SetReqTransactionBehaviorData(textBox);
                    break;
                case RequestModuleNameEnum.Original:
                    SetReqOriginalData(textBox);
                    break;
                case RequestModuleNameEnum.MultiMerchant:
                    SetReqMultiMerchantData(textBox);
                    break;
                case RequestModuleNameEnum.FleetCard:
                    SetReqFleetCardData(textBox);
                    break;
                case RequestModuleNameEnum.LodgingInformation:
                    SetLodgingInfomationData(textBox);
                    break;
                case RequestModuleNameEnum.AutoRental:
                    SetAutoRentalInfomationData(textBox);
                    break;
                case RequestModuleNameEnum.HostCredential:
                    SetHostCredentialInfomationData(textBox);
                    break;
                default:
                    break;
            }
        }

        private void SetReqNormalData(TextBox textBox)
        {
            for (int i = 0; i < TransactionCommon.NormalRequestNames.Length/2; i++)
            {
                if (textBox.Name == TransactionCommon.NormalRequestNames[i,0] + "ReqTextBox")
                {
                    switch(i)
                    {
                        case 0:
                            _transactionData.AmountRequestInfoData[0] = textBox.Text;
                            break;
                        case 1:
                            _transactionData.AmountRequestInfoData[2] = textBox.Text;
                            break;
                        case 2:
                            _transactionData.TraceRequestInfoData[0] = textBox.Text;
                            break;
                        case 3:
                            _transactionData.PosEchoDataRequest = textBox.Text;
                            break;
                        case 4:
                            _transactionData.ContinuousScreenRequest = textBox.Text;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void SetReqNormalData(ComboBox comboBox)
        {
            _transactionData.TransactionTypeRequest = comboBox.SelectedIndex;
        }

        private void SetReqAutoRentalInfoData(ComboBox comboBox)
        {
            _transactionData.VehicleClassIdRequest = comboBox.SelectedIndex;
        }

        private void SetOrignalData(ComboBox comboBox)
        {
            _transactionData.OriginalRequestComboBoxIndex[0] = comboBox.SelectedIndex;
        }

        private void SetReqAmountData(TextBox textBox)
        {
            for (int i = 0; i < TransactionCommon.AmountRequestNames.Length/2; i++)
            {
                if (textBox.Name == TransactionCommon.AmountRequestNames[i,0] + "ReqTextBox")
                {
                    _transactionData.AmountRequestInfoData[i] = textBox.Text;
                    break;
                }
            }
        }

        private void SetReqAccountData(TextBox textBox)
        {
            for (int i = 0; i < TransactionCommon.AccountRequestNames.Length/2; i++)
            {
                if (textBox.Name == TransactionCommon.AccountRequestNames[i,0] + "ReqTextBox")
                {
                    _transactionData.AccountRequestInfoData[i] = textBox.Text;
                    break;
                }
            }
        }

        private void SetReqCheckData(TextBox textBox)
        {
            for (int i = 0; i < TransactionCommon.CheckRequestNames.Length/2; i++)
            {
                if (textBox.Name == TransactionCommon.CheckRequestNames[i,0] + "ReqTextBox")
                {
                    _transactionData.CheckRequestInfoData[i] = textBox.Text;
                    break;
                }
            }
        }

        private void SetReqTraceData(TextBox textBox)
        {
            for (int i = 0; i < TransactionCommon.TraceRequestNames.Length/2; i++)
            {
                if (textBox.Name == TransactionCommon.TraceRequestNames[i,0] + "ReqTextBox")
                {
                    _transactionData.TraceRequestInfoData[i] = textBox.Text;
                    break;
                }
            }
        }

        private void SetReqAvsData(TextBox textBox)
        {
            for (int i = 0; i < TransactionCommon.AvsRequestNames.Length/2; i++)
            {
                if (textBox.Name == TransactionCommon.AvsRequestNames[i,0] + "ReqTextBox")
                {
                    _transactionData.AvsRequestInfoData[i] = textBox.Text;
                    break;
                }
            }
        }

        private void SetReqCashierData(TextBox textBox)
        {
            for (int i = 0; i < TransactionCommon.CashierRequestNames.Length/2; i++)
            {
                if (textBox.Name == TransactionCommon.CashierRequestNames[i,0] + "ReqTextBox")
                {
                    _transactionData.CashierRequestInfoData[i] = textBox.Text;
                    break;
                }
            }
        }

        private void SetReqCommercialData(TextBox textBox)
        {
            for (int i = 0; i < TransactionCommon.CommercialRequestNames.Length/2; i++)
            {
                if (textBox.Name == TransactionCommon.CommercialRequestNames[i,0] + "ReqTextBox")
                {
                    _transactionData.CommercialRequestInfoData[i] = textBox.Text;
                    break;
                }
            }
            _transactionData.TaxDetailData = _commercialInfo.TaxDetails;
            TextBox taxDetailTextBox = (TextBox)RequestPanel.Controls.Find("TaxDetailsReqTextBox", false)[0];
            _transactionData.TaxDetailTextData = taxDetailTextBox.Text;

            _transactionData.LineItemDetailData = _commercialInfo.LineItemDetails;
            TextBox lineItemDetailTextBox = (TextBox)RequestPanel.Controls.Find("LineItemDetailsReqTextBox", false)[0];
            _transactionData.LineItemDetailTextData = lineItemDetailTextBox.Text;
        }

        private void SetReqMotoECommerceData(TextBox textBox)
        {
            for (int i = 0; i < TransactionCommon.MotoECommerceRequestNames.Length/2; i++)
            {
                if (textBox.Name == TransactionCommon.MotoECommerceRequestNames[i,0] + "ReqTextBox")
                {
                    _transactionData.MotoECommerceRequestInfoData[i] = textBox.Text;
                    break;
                }
            }
        }

        private void SetReqRestaurantData(TextBox textBox)
        {
            for (int i = 0; i < TransactionCommon.RestaurantNames.Length/2; i++)
            {
                if (textBox.Name == TransactionCommon.RestaurantNames[i,0] + "ReqTextBox")
                {
                    _transactionData.RestaurantRequestData[i] = textBox.Text;
                    break;
                }
            }
        }

        private void SetReqHostGatewayData(TextBox textBox)
        {
            for (int i = 0; i < TransactionCommon.HostGatewayNames.Length/2; i++)
            {
                if (textBox.Name == TransactionCommon.HostGatewayNames[i,0] + "ReqTextBox")
                {
                    _transactionData.HostGatewayRequestData[i] = textBox.Text;
                    break;
                }
            }
        }

        private void SetReqTransactionBehaviorData(TextBox textBox)
        {
            for (int i = 0; i < TransactionCommon.TransactionBehaviorNames.Length/2; i++)
            {
                if (textBox.Name == TransactionCommon.TransactionBehaviorNames[i,0] + "ReqTextBox")
                {
                    _transactionData.TransactionBehaviorRequestData[i] = textBox.Text;
                    break;
                }
            }
        }

        private void SetReqOriginalData(TextBox textBox)
        {
            for (int i = 0; i < TransactionCommon.OriginalNames.Length/2; i++)
            {
                if (textBox.Name == TransactionCommon.OriginalNames[i,0] + "ReqTextBox")
                {
                    _transactionData.OriginalRequestData[i] = textBox.Text;
                    break;
                }
            }
        }

        private void SetReqMultiMerchantData(TextBox textBox)
        {
            for (int i = 0; i < TransactionCommon.MultiMerchantNames.Length/2; i++)
            {
                if (textBox.Name == TransactionCommon.MultiMerchantNames[i,0] + "ReqTextBox")
                {
                    _transactionData.MultiMerchantRequestData[i] = textBox.Text;
                    break;
                }
            }
        }

        private void SetReqFleetCardData(TextBox textBox)
        {
            for (int i = 0; i < TransactionCommon.FleetCardNames.Length/2; i++)
            {
                if (textBox.Name == TransactionCommon.FleetCardNames[i,0] + "ReqTextBox")
                {
                    _transactionData.FleetCardRequestData[i] = textBox.Text;
                    break;
                }
            }
        }

        private void SetLodgingInfomationData(TextBox textBox)
        {
            for (int i = 0; i < TransactionCommon.LodgingInfoRequestNames.Length / 2; i++)
            {
                if (textBox.Name == TransactionCommon.LodgingInfoRequestNames[i, 0] + "ReqTextBox")
                {
                    _transactionData.LodgingInfoRequestData[i] = textBox.Text;
                    break;
                }
            }
        }

        private void SetAutoRentalInfomationData(TextBox textBox)
        {
            for (int i = 0; i < TransactionCommon.AutoRentalInfoRequestNames.Length / 2; i++)
            {
                if (textBox.Name == TransactionCommon.AutoRentalInfoRequestNames[i, 0] + "ReqTextBox")
                {
                    _transactionData.AutoRentalInfoRequestData[i] = textBox.Text;
                    break;
                }
            }
        }

        private void SetHostCredentialInfomationData(TextBox textBox)
        {
            for (int i = 0; i < TransactionCommon.HostCredentialInfoRequestNames.Length / 2; i++)
            {
                if (textBox.Name == TransactionCommon.HostCredentialInfoRequestNames[i, 0] + "ReqTextBox")
                {
                    _transactionData.HostCredentialInfoRequestData[i] = textBox.Text;
                    break;
                }
            }
        }

        private void ShowTextDetailListForm(object sender, EventArgs e)
        {
            TaxDetailListForm taxDetailListForm = new TaxDetailListForm();
            taxDetailListForm.TaxDetailArray = _transactionData.TaxDetailData;
            taxDetailListForm.TaxDetailString = _transactionData.TaxDetailTextData;
            taxDetailListForm.ShowDialog();
            if(taxDetailListForm.DialogResult ==DialogResult.OK)
            {
                _transactionData.TaxDetailData = taxDetailListForm.TaxDetailArray;
                TextBox taxDetailTextBox = (TextBox)RequestPanel.Controls.Find("TaxDetailsReqTextBox", false)[0];
                taxDetailTextBox.Text = taxDetailListForm.TaxDetailString;
                _transactionData.TaxDetailTextData = taxDetailListForm.TaxDetailString;
            }
        }

        private void ShowLineItemDetailListForm(object sender, EventArgs e)
        {
            LineItemDetailListForm lineItemDetailForm = new LineItemDetailListForm();
            lineItemDetailForm.LineItemDetailArray = _transactionData.LineItemDetailData;
            lineItemDetailForm.LineItemDetailString = _transactionData.LineItemDetailTextData;
            lineItemDetailForm.ShowDialog();
            if(lineItemDetailForm.DialogResult == DialogResult.OK)
            {
                _transactionData.LineItemDetailData = lineItemDetailForm.LineItemDetailArray;
                TextBox lineItemDetailTextBox = (TextBox)RequestPanel.Controls.Find("LineItemDetailsReqTextBox", false)[0];
                lineItemDetailTextBox.Text = lineItemDetailForm.LineItemDetailString;
                _transactionData.LineItemDetailTextData = lineItemDetailForm.LineItemDetailString;
            }
        }

        private void ShowSetPassThruDataForm(object sender,EventArgs e)
        {
            PassThruDataForm passThruDataForm = new PassThruDataForm();
            DialogResult ret = passThruDataForm.ShowDialog();
            if(ret == DialogResult.OK)
            {
                if(passThruDataForm.PassThruType == PassThruDataForm.PassThruTypeEnum.Fleet)
                {
                    _transactionData.FleetDatas = passThruDataForm.FleetDatas;
                    _hostGateway.SetPassThruData(_transactionData.FleetDatas);
                }
                else if(passThruDataForm.PassThruType == PassThruDataForm.PassThruTypeEnum.Fsa)
                {
                    _transactionData.FsaData = passThruDataForm.FsaData;
                    _hostGateway.SetPassThruData(_transactionData.FsaData);
                }
                else if(passThruDataForm.PassThruType == PassThruDataForm.PassThruTypeEnum.Ewic)
                {
                    _transactionData.EwicDatas = passThruDataForm.EwicDatas;
                    _hostGateway.SetPassThruData(_transactionData.EwicDatas);
                }
                _transactionData.HostGatewayRequestData[5] = _hostGateway.PassThruData;
                TextBox passThruDataTextBox = (TextBox)RequestPanel.Controls.Find("PassThruDataReqTextBox", false)[0];
                passThruDataTextBox.Text = _hostGateway.PassThruData;
            }
            passThruDataForm.Dispose();
        }

        private void AddToMultipleCommandsButton_Click(object sender, EventArgs e)
        {
            _terminalData = TerminalData.GetTerminalData();
            MultipleCommandsModule multipleCommandsModule = new MultipleCommandsModule();
            switch (TenderTypeComboBox.SelectedIndex)
            {
                case (int)TransactionCommandName.DoCredit://DoCredit
                    POSLink2.Transaction.DoCreditReq doCreditRequest = SetCreditRequest();
                    multipleCommandsModule.CommandName = CommandName.DoCredit;
                    multipleCommandsModule.CommandReqObject = doCreditRequest;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)TransactionCommandName.DoDebit://DoDebit
                    POSLink2.Transaction.DoDebitReq doDebitRequest = SetDebitRequest();
                    multipleCommandsModule.CommandName = CommandName.DoDebit;
                    multipleCommandsModule.CommandReqObject = doDebitRequest;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)TransactionCommandName.DoEBT://DoEBT
                    POSLink2.Transaction.DoEbtReq doEbtRequest = SetEbtRequest();
                    multipleCommandsModule.CommandName = CommandName.DoEBT;
                    multipleCommandsModule.CommandReqObject = doEbtRequest;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)TransactionCommandName.DoGift://DoGift
                    POSLink2.Transaction.DoGiftReq doGiftRequest = SetGiftRequest();
                    multipleCommandsModule.CommandName = CommandName.DoGift;
                    multipleCommandsModule.CommandReqObject = doGiftRequest;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)TransactionCommandName.DoLoyalty://DoLoyalty
                    POSLink2.Transaction.DoLoyaltyReq doLoyaltyRequest = SetLoyaltyRequest();
                    multipleCommandsModule.CommandName = CommandName.DoLoyalty;
                    multipleCommandsModule.CommandReqObject = doLoyaltyRequest;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)TransactionCommandName.DoCash://DoCash
                    POSLink2.Transaction.DoCashReq doCashRequest = SetCashRequest();
                    multipleCommandsModule.CommandName = CommandName.DoCash;
                    multipleCommandsModule.CommandReqObject = doCashRequest;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                case (int)TransactionCommandName.DoCheck://DoCheck
                    POSLink2.Transaction.DoCheckReq doCheckRequest = SetCheckRequest();
                    multipleCommandsModule.CommandName = CommandName.DoCheck;
                    multipleCommandsModule.CommandReqObject = doCheckRequest;
                    _terminalData.MultipleCommands.Add(multipleCommandsModule);
                    break;
                default:
                    break;
            }
        }

        private POSLink2.Transaction.DoCreditReq SetCreditRequest()
        {
            POSLink2.Transaction.DoCreditReq request = new POSLink2.Transaction.DoCreditReq();
            request.TransactionType = (POSLink2.Const.TransType)Global.TransType[_transactionData.TransactionTypeRequest, 1];
            request.AmountInformation = GetAmountReq();
            request.AccountInformation = GetAccountReq();
            request.TraceInformation = GetTraceReq();
            request.AvsInformation = GetAvsReq();
            request.CashierInformation = GetCashierReq();
            request.CommercialInformation = GetCommercialReq();
            request.MotoECommerceInformation = GetMotoECommerceReq();
            request.Restaurant = GetRestaurantReq();
            request.HostGateway = GetHostGatewayReq();
            request.TransactionBehavior = GetTransactionBehaviorReq();
            request.Original = GetOriginalReq();
            request.MultiMerchant = GetMultiMerchantReq();
            request.FleetCard = GetFleetCardReq();
            request.Lodging = GetLodgingInfoReq();
            request.AutoRental = GetAutoRentalInfoReq();
            request.HostCredential = GetHostCredentialInfoReq();
            request.PosEchoData = _transactionData.PosEchoDataRequest;
            request.ContinuousScreen = _transactionData.ContinuousScreenRequest;
            return request;
        }

        private POSLink2.Transaction.DoDebitReq SetDebitRequest()
        {
            POSLink2.Transaction.DoDebitReq request = new POSLink2.Transaction.DoDebitReq();
            request.TransactionType = (POSLink2.Const.TransType)Global.TransType[_transactionData.TransactionTypeRequest, 1];
            request.AmountInformation = GetAmountReq();
            request.AccountInformation = GetAccountReq();
            request.TraceInformation = GetTraceReq();
            request.CashierInformation = GetCashierReq();
            request.Restaurant = GetRestaurantReq();
            request.HostGateway = GetHostGatewayReq();
            request.TransactionBehavior = GetTransactionBehaviorReq();
            request.Original = GetOriginalReq();
            request.MultiMerchant = GetMultiMerchantReq();
            request.FleetCard = GetFleetCardReq();
            request.Lodging = GetLodgingInfoReq();
            request.PosEchoData = _transactionData.PosEchoDataRequest;
            request.ContinuousScreen = _transactionData.ContinuousScreenRequest;
            request.HostCredential = GetHostCredentialInfoReq();
            return request;
        }

        private POSLink2.Transaction.DoEbtReq SetEbtRequest()
        {
            POSLink2.Transaction.DoEbtReq request = new POSLink2.Transaction.DoEbtReq();
            request.TransactionType = (POSLink2.Const.TransType)Global.TransType[_transactionData.TransactionTypeRequest, 1];
            request.AmountInformation = GetAmountReq();
            request.AccountInformation = GetAccountReq();
            request.TraceInformation = GetTraceReq();
            request.CashierInformation = GetCashierReq();
            request.Restaurant = GetRestaurantReq();
            request.HostGateway = GetHostGatewayReq();
            request.TransactionBehavior = GetTransactionBehaviorReq();
            request.Original = GetOriginalReq();
            request.MultiMerchant = GetMultiMerchantReq();
            request.FleetCard = GetFleetCardReq();
            request.PosEchoData = _transactionData.PosEchoDataRequest;
            request.ContinuousScreen = _transactionData.ContinuousScreenRequest;
            request.HostCredential = GetHostCredentialInfoReq();
            return request;
        }

        private POSLink2.Transaction.DoGiftReq SetGiftRequest()
        {
            POSLink2.Transaction.DoGiftReq request = new POSLink2.Transaction.DoGiftReq();
            request.TransactionType = (POSLink2.Const.TransType)Global.TransType[_transactionData.TransactionTypeRequest, 1];
            request.AmountInformation = GetAmountReq();
            request.AccountInformation = GetAccountReq();
            request.TraceInformation = GetTraceReq();
            request.CashierInformation = GetCashierReq();
            request.Restaurant = GetRestaurantReq();
            request.HostGateway = GetHostGatewayReq();
            request.TransactionBehavior = GetTransactionBehaviorReq();
            request.Original = GetOriginalReq();
            request.MultiMerchant = GetMultiMerchantReq();
            request.FleetCard = GetFleetCardReq();
            request.PosEchoData = _transactionData.PosEchoDataRequest;
            request.ContinuousScreen = _transactionData.ContinuousScreenRequest;
            request.HostCredential = GetHostCredentialInfoReq();
            return request;
        }

        private POSLink2.Transaction.DoLoyaltyReq SetLoyaltyRequest()
        {
            POSLink2.Transaction.DoLoyaltyReq request = new POSLink2.Transaction.DoLoyaltyReq();
            request.TransactionType = (POSLink2.Const.TransType)Global.TransType[_transactionData.TransactionTypeRequest, 1];
            request.AmountInformation = GetAmountReq();
            request.AccountInformation = GetAccountReq();
            request.TraceInformation = GetTraceReq();
            request.CashierInformation = GetCashierReq();
            request.Restaurant = GetRestaurantReq();
            request.HostGateway = GetHostGatewayReq();
            request.TransactionBehavior = GetTransactionBehaviorReq();
            request.Original = GetOriginalReq();
            request.MultiMerchant = GetMultiMerchantReq();
            request.FleetCard = GetFleetCardReq();
            request.PosEchoData = _transactionData.PosEchoDataRequest;
            request.ContinuousScreen = _transactionData.ContinuousScreenRequest;
            request.HostCredential = GetHostCredentialInfoReq();
            return request;
        }

        private POSLink2.Transaction.DoCashReq SetCashRequest()
        {
            POSLink2.Transaction.DoCashReq request = new POSLink2.Transaction.DoCashReq();
            request.TransactionType = (POSLink2.Const.TransType)Global.TransType[_transactionData.TransactionTypeRequest, 1];
            request.AmountInformation = GetAmountReq();
            request.TraceInformation = GetTraceReq();
            request.CashierInformation = GetCashierReq();
            request.Restaurant = GetRestaurantReq();
            request.HostGateway = GetHostGatewayReq();
            request.TransactionBehavior = GetTransactionBehaviorReq();
            request.Original = GetOriginalReq();
            request.MultiMerchant = GetMultiMerchantReq();
            request.FleetCard = GetFleetCardReq();
            request.PosEchoData = _transactionData.PosEchoDataRequest;
            request.ContinuousScreen = _transactionData.ContinuousScreenRequest;
            request.HostCredential = GetHostCredentialInfoReq();
            return request;
        }

        private POSLink2.Transaction.DoCheckReq SetCheckRequest()
        {
            POSLink2.Transaction.DoCheckReq request = new POSLink2.Transaction.DoCheckReq();
            request.TransactionType = (POSLink2.Const.TransType)Global.TransType[_transactionData.TransactionTypeRequest, 1];
            request.AmountInformation = GetAmountReq();
            request.CheckInformation = GetCheckReq();
            request.TraceInformation = GetTraceReq();
            request.CashierInformation = GetCashierReq();
            request.Restaurant = GetRestaurantReq();
            request.HostGateway = GetHostGatewayReq();
            request.TransactionBehavior = GetTransactionBehaviorReq();
            request.Original = GetOriginalReq();
            request.MultiMerchant = GetMultiMerchantReq();
            request.FleetCard = GetFleetCardReq();
            request.PosEchoData = _transactionData.PosEchoDataRequest;
            request.ContinuousScreen = _transactionData.ContinuousScreenRequest;
            request.HostCredential = GetHostCredentialInfoReq();
            return request;
        }

        private POSLink2.Util.AmountReq GetAmountReq()
        {
            POSLink2.Util.AmountReq req = new POSLink2.Util.AmountReq();
            req.TransactionAmount = _transactionData.AmountRequestInfoData[0];
            req.TipAmount = _transactionData.AmountRequestInfoData[1];
            req.CashBackAmount = _transactionData.AmountRequestInfoData[2];
            req.MerchantFee = _transactionData.AmountRequestInfoData[3];
            req.TaxAmount = _transactionData.AmountRequestInfoData[4];
            req.FuelAmount = _transactionData.AmountRequestInfoData[5];
            req.ServiceFee = _transactionData.AmountRequestInfoData[6];
            return req;
        }

        private POSLink2.Util.AccountReq GetAccountReq()
        {
            POSLink2.Util.AccountReq req = new POSLink2.Util.AccountReq();
            req.Account = _transactionData.AccountRequestInfoData[0];
            req.CardExpireDate = _transactionData.AccountRequestInfoData[1];
            req.CvvCode = _transactionData.AccountRequestInfoData[2];
            req.EbtType = _transactionData.AccountRequestInfoData[3];
            req.VoucherNumber = _transactionData.AccountRequestInfoData[4];
            req.FirstName = _transactionData.AccountRequestInfoData[5];
            req.LastName = _transactionData.AccountRequestInfoData[6];
            req.CountryCode = _transactionData.AccountRequestInfoData[7];
            req.StateCode = _transactionData.AccountRequestInfoData[8];
            req.CityName = _transactionData.AccountRequestInfoData[9];
            req.EmailAddress = _transactionData.AccountRequestInfoData[10];
            req.GiftCardType = _transactionData.AccountRequestInfoData[11];
            req.CvvBypassReason = _transactionData.AccountRequestInfoData[12];
            req.GiftTenderType = _transactionData.AccountRequestInfoData[13];
            return req;
        }

        private POSLink2.Util.CheckReq GetCheckReq()
        {
            POSLink2.Util.CheckReq req = new POSLink2.Util.CheckReq();
            req.SaleType = _transactionData.CheckRequestInfoData[0];
            req.RoutingNumber = _transactionData.CheckRequestInfoData[1];
            req.Account = _transactionData.CheckRequestInfoData[2];
            req.Number = _transactionData.CheckRequestInfoData[3];
            req.Type = _transactionData.CheckRequestInfoData[4];
            req.IdType = _transactionData.CheckRequestInfoData[5];
            req.IdValue = _transactionData.CheckRequestInfoData[6];
            req.Birth = _transactionData.CheckRequestInfoData[7];
            req.PhoneNumber = _transactionData.CheckRequestInfoData[8];
            req.ZipCode = _transactionData.CheckRequestInfoData[9];
            return req;
        }

        private POSLink2.Util.TraceReq GetTraceReq()
        {
            POSLink2.Util.TraceReq req = new POSLink2.Util.TraceReq();
            req.EcrRefNum = _transactionData.TraceRequestInfoData[0];
            req.InvoiceNumber = _transactionData.TraceRequestInfoData[1];
            req.AuthCode = _transactionData.TraceRequestInfoData[2];
            req.OrigRefNum = _transactionData.TraceRequestInfoData[3];
            req.TimeStamp = _transactionData.TraceRequestInfoData[4];
            req.EcrTransID = _transactionData.TraceRequestInfoData[5];
            req.OrigEcrRefNum = _transactionData.TraceRequestInfoData[6];
            req.OrigTraceNum = _transactionData.TraceRequestInfoData[7];
            req.OrigTransactionIdentifier = _transactionData.TraceRequestInfoData[8];
            return req;
        }

        private POSLink2.Util.AvsReq GetAvsReq()
        {
            POSLink2.Util.AvsReq req = new POSLink2.Util.AvsReq();
            req.ZipCode = _transactionData.AvsRequestInfoData[0];
            req.Address = _transactionData.AvsRequestInfoData[1];
            req.Address2 = _transactionData.AvsRequestInfoData[2];
            return req;
        }

        private POSLink2.Util.CashierReq GetCashierReq()
        {
            POSLink2.Util.CashierReq req = new POSLink2.Util.CashierReq();
            req.ClerkID = _transactionData.CashierRequestInfoData[0];
            req.ShiftID = _transactionData.CashierRequestInfoData[1];
            return req;
        }

        private POSLink2.Util.CommercialReq GetCommercialReq()
        {
            POSLink2.Util.CommercialReq req = new POSLink2.Util.CommercialReq();
            req.PoNumber = _transactionData.CommercialRequestInfoData[0];
            req.CustomerCode = _transactionData.CommercialRequestInfoData[1];
            req.TaxExempt = _transactionData.CommercialRequestInfoData[2];
            req.TaxExemptId = _transactionData.CommercialRequestInfoData[3];
            req.MerchantTaxId = _transactionData.CommercialRequestInfoData[4];
            req.DestinationZipCode = _transactionData.CommercialRequestInfoData[5];
            req.ProductDescription = _transactionData.CommercialRequestInfoData[6];
            req.ShipFromZipCode = _transactionData.CommercialRequestInfoData[7];
            req.DestinationCountryCode = _transactionData.CommercialRequestInfoData[8];
            req.SummaryCommodityCode = _transactionData.CommercialRequestInfoData[9];
            req.DiscountAmount = _transactionData.CommercialRequestInfoData[10];
            req.FreightAmount = _transactionData.CommercialRequestInfoData[11];
            req.DutyAmount = _transactionData.CommercialRequestInfoData[12];
            req.OrderDate = _transactionData.CommercialRequestInfoData[13];
            req.TaxDetails = _transactionData.TaxDetailData;
            req.LineItemDetails = _transactionData.LineItemDetailData;
            return req;
        }

        private POSLink2.Util.MotoECommerceReq GetMotoECommerceReq()
        {
            POSLink2.Util.MotoECommerceReq req = new POSLink2.Util.MotoECommerceReq();
            req.Mode = _transactionData.MotoECommerceRequestInfoData[0];
            req.TransactionType = _transactionData.MotoECommerceRequestInfoData[1];
            req.SecureType = _transactionData.MotoECommerceRequestInfoData[2];
            req.OrderNumber = _transactionData.MotoECommerceRequestInfoData[3];
            req.Installments = _transactionData.MotoECommerceRequestInfoData[4];
            req.CurrentInstallment = _transactionData.MotoECommerceRequestInfoData[5];
            return req;
        }

        private POSLink2.Util.Restaurant GetRestaurantReq()
        {
            POSLink2.Util.Restaurant req = new POSLink2.Util.Restaurant();
            req.TableNumber = _transactionData.RestaurantRequestData[0];
            req.GuestNumber = _transactionData.RestaurantRequestData[1];
            req.TicketNumber = _transactionData.RestaurantRequestData[2];
            return req;
        }

        private POSLink2.Util.HostGateway GetHostGatewayReq()
        {
            POSLink2.Util.HostGateway req = new POSLink2.Util.HostGateway();
            req.HRef = _transactionData.HostGatewayRequestData[0];
            req.GatewayId = _transactionData.HostGatewayRequestData[1];
            req.TokenRequestFlag = _transactionData.HostGatewayRequestData[2];
            req.Token = _transactionData.HostGatewayRequestData[3];
            req.CardType = _transactionData.HostGatewayRequestData[4];
            req.PassThruData = _transactionData.HostGatewayRequestData[5];
            req.ReturnReason = _transactionData.HostGatewayRequestData[6];
            req.StationId = _transactionData.HostGatewayRequestData[7];
            req.GlobalUid = _transactionData.HostGatewayRequestData[8];
            req.CustomizeData1 = _transactionData.HostGatewayRequestData[9];
            req.CustomizeData2 = _transactionData.HostGatewayRequestData[10];
            req.CustomizeData3 = _transactionData.HostGatewayRequestData[11];
            req.EwicDiscountAmount = _transactionData.HostGatewayRequestData[12];
            req.TokenSerialNum = _transactionData.HostGatewayRequestData[13];
            return req;
        }

        private POSLink2.Util.TransactionBehavior GetTransactionBehaviorReq()
        {
            POSLink2.Util.TransactionBehavior req = new POSLink2.Util.TransactionBehavior();
            req.SignatureCaptureFlag = _transactionData.TransactionBehaviorRequestData[0];
            req.TipRequestFlag = _transactionData.TransactionBehaviorRequestData[1];
            req.SignatureUploadFlag = _transactionData.TransactionBehaviorRequestData[2];
            req.StatusReportFlag = _transactionData.TransactionBehaviorRequestData[3];
            req.AcceptedCardType = _transactionData.TransactionBehaviorRequestData[4];
            req.ProgramPromptsFlag = _transactionData.TransactionBehaviorRequestData[5];
            req.SignatureAcquireFlag = _transactionData.TransactionBehaviorRequestData[6];
            req.EntryMode = _transactionData.TransactionBehaviorRequestData[7];
            req.ReceiptPrintFlag = _transactionData.TransactionBehaviorRequestData[8];
            req.CardPresentMode = _transactionData.TransactionBehaviorRequestData[9];
            req.DebitNetwork = _transactionData.TransactionBehaviorRequestData[10];
            req.UserLanguage = _transactionData.TransactionBehaviorRequestData[11];
            req.AddlRspDataFlag = _transactionData.TransactionBehaviorRequestData[12];
            req.ForceCC = _transactionData.TransactionBehaviorRequestData[13];
            req.ForceFsa = _transactionData.TransactionBehaviorRequestData[14];
            req.ForceDuplicate = _transactionData.TransactionBehaviorRequestData[15];
            req.AccessibilityPinPad = _transactionData.TransactionBehaviorRequestData[16];
            req.CofIndicator = _transactionData.TransactionBehaviorRequestData[17];
            req.CofInitiator = _transactionData.TransactionBehaviorRequestData[18];
            req.GiftCardIndicator = _transactionData.TransactionBehaviorRequestData[19];
            req.TransactionPromptBitmap = _transactionData.TransactionPromptBitmap;
            return req;
        }

        private POSLink2.Util.Original GetOriginalReq()
        {
            POSLink2.Util.Original req = new POSLink2.Util.Original();
            req.TransDate = _transactionData.OriginalRequestData[0];
            req.Pan = _transactionData.OriginalRequestData[1];
            req.ExpiryDate = _transactionData.OriginalRequestData[2];
            req.TransTime = _transactionData.OriginalRequestData[3];
            req.SettlementDate = _transactionData.OriginalRequestData[4];
            req.Amount = _transactionData.OriginalRequestData[5];
            req.BatchNumber = _transactionData.OriginalRequestData[6];
            req.PaymentService2000 = _transactionData.OriginalRequestData[7];
            req.AuthorizationResponse = _transactionData.OriginalRequestData[8];
            if((POSLink2.Const.TransType)Global.OrigTransType[_transactionData.OriginalRequestComboBoxIndex[0], 1] != POSLink2.Const.TransType.Empty)
            {
                req.TransactionType = (POSLink2.Const.TransType)Global.OrigTransType[_transactionData.OriginalRequestComboBoxIndex[0], 1];
            }
            return req;
        }

        private POSLink2.Util.MultiMerchant GetMultiMerchantReq()
        {
            POSLink2.Util.MultiMerchant req = new POSLink2.Util.MultiMerchant();
            req.Id = _transactionData.MultiMerchantRequestData[0];
            req.Name = _transactionData.MultiMerchantRequestData[1];
            return req;
        }

        private POSLink2.Util.FleetCard GetFleetCardReq()
        {
            POSLink2.Util.FleetCard req = new POSLink2.Util.FleetCard();
            req.Odometer = _transactionData.FleetCardRequestData[0];
            req.VehicleNumber = _transactionData.FleetCardRequestData[1];
            req.JobNumber = _transactionData.FleetCardRequestData[2];
            req.DriverId = _transactionData.FleetCardRequestData[3];
            req.EmployeeNumber = _transactionData.FleetCardRequestData[4];
            req.LicenseNumber = _transactionData.FleetCardRequestData[5];
            req.JobId = _transactionData.FleetCardRequestData[6];
            req.DepartmentNumber = _transactionData.FleetCardRequestData[7];
            req.CustomerData = _transactionData.FleetCardRequestData[8];
            req.UserId = _transactionData.FleetCardRequestData[9];
            req.VehicleId = _transactionData.FleetCardRequestData[10];
            req.FleetPromptCode = _transactionData.FleetCardRequestData[11];
            return req;
        }

        private POSLink2.Util.Lodging GetLodgingInfoReq()
        {
            POSLink2.Util.Lodging req = new POSLink2.Util.Lodging();
            req.RoomNumber = _transactionData.LodgingInfoRequestData[0];
            req.FolioNumber = _transactionData.LodgingInfoRequestData[1];
            req.ChargeType = _transactionData.LodgingInfoRequestData[2];
            req.NoShowFlag = _transactionData.LodgingInfoRequestData[3];
            req.CheckInDate = _transactionData.LodgingInfoRequestData[4];
            req.CheckOutDate = _transactionData.LodgingInfoRequestData[5];
            req.SpecialProgramCode = _transactionData.LodgingInfoRequestData[6];
            req.DepartureAdjustedAmount = _transactionData.LodgingInfoRequestData[7];
            req.RoomRates = _transactionData.RoomRates;
            req.LodgingItems = _transactionData.LodgingItems;
            return req;
        }

        private POSLink2.Util.AutoRental GetAutoRentalInfoReq()
        {
            POSLink2.Util.AutoRental req = new POSLink2.Util.AutoRental();
            int i = 0;
            req.AgreementNumber = _transactionData.AutoRentalInfoRequestData[i++];
            req.DailyRate = _transactionData.AutoRentalInfoRequestData[i++];
            req.RentalDuration = _transactionData.AutoRentalInfoRequestData[i++];
            req.InsuranceAmount = _transactionData.AutoRentalInfoRequestData[i++];
            req.AllocatedMiles = _transactionData.AutoRentalInfoRequestData[i++];
            req.MileRate = _transactionData.AutoRentalInfoRequestData[i++];
            req.Name = _transactionData.AutoRentalInfoRequestData[i++];
            req.DriverLicenseNumber = _transactionData.AutoRentalInfoRequestData[i++];
            req.RentalProgramType = _transactionData.AutoRentalInfoRequestData[i++];
            req.PickupLocationName = _transactionData.AutoRentalInfoRequestData[i++];
            req.PickupCity = _transactionData.AutoRentalInfoRequestData[i++];
            req.PickupState = _transactionData.AutoRentalInfoRequestData[i++];
            req.PickupCountryCode = _transactionData.AutoRentalInfoRequestData[i++];
            req.PickupDatetime = _transactionData.AutoRentalInfoRequestData[i++];
            req.ReturnLocation = _transactionData.AutoRentalInfoRequestData[i++];
            req.ReturnCity = _transactionData.AutoRentalInfoRequestData[i++];
            req.ReturnState = _transactionData.AutoRentalInfoRequestData[i++];
            req.ReturnCountryCode = _transactionData.AutoRentalInfoRequestData[i++];
            req.ReturnDatetime = _transactionData.AutoRentalInfoRequestData[i++];
            req.TotalMiles = _transactionData.AutoRentalInfoRequestData[i++];
            req.CustomerTaxID = _transactionData.AutoRentalInfoRequestData[i++];
            req.ExtraChargesAmount = _transactionData.AutoRentalInfoRequestData[i++];
            if(_transactionData.VehicleClassIdRequest<0 || _transactionData.VehicleClassIdRequest> Global.VehicleClassId.Length-1)
            {
                req.VehicleClassId = POSLink2.Const.VehicleClassId.Empty;
            }
            else
            {
                req.VehicleClassId = (POSLink2.Const.VehicleClassId)Global.VehicleClassId[_transactionData.VehicleClassIdRequest, 1];
            }
            req.ExtraChargeItems = _transactionData.ExtraChargeItems;

            return req;
        }

        private POSLink2.Util.HostCredential GetHostCredentialInfoReq()
        {
            POSLink2.Util.HostCredential req = new POSLink2.Util.HostCredential();
            int i = 0;
            req.Mid = _transactionData.HostCredentialInfoRequestData[i++];
            req.ServiceUser = _transactionData.HostCredentialInfoRequestData[i++];
            req.ServicePassword = _transactionData.HostCredentialInfoRequestData[i++];

            return req;
        }

        private void TransactionUserControl_VisibleChanged(object sender, EventArgs e)
        {
            TenderTypeComboBox.SelectedIndex = _comboBoxIndex;
            TenderTypeComboBox_SelectedIndexChanged(sender, e);
        }
    }
}

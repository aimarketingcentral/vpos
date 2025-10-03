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
using System.IO;
using POSLink2.Const;

namespace POSLink2Demo
{
    public partial class ManageOnePanelUserControl : UserControl
    {
        private ManageCommandName _commandName;
        public ManageCommandName CommandName
        {
            get { return _commandName; }
            set { _commandName = value; }
        }

        private ManageData _manageData;
        private Tools _tools = new Tools();
        public ManageOnePanelUserControl()
        {
            InitializeComponent();
            _manageData = ManageData.GetManageData();
            _vasPanel = new Panel();
        }

        Panel _vasPanel;
        public void ShowPanel(object sender, EventArgs e)
        {
            LabelTextBoxUserControl[] labelAndTextBoxs;
            LabelComboBoxUserControl[] labelAndComboBox;
            Label unitOfTimeout;
            _tools.DisposeSubControls(ValuePanel);
            switch (_commandName)
            {
                case ManageCommandName.InitReq:
                    break;
                case ManageCommandName.InitRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(ManageCommon.InitRspNormal, 394, new Point(0, 2), _manageData.InitRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);

                    Button getHardwareConfigurationBitmap = new Button();
                    getHardwareConfigurationBitmap.Text = "Show Hardware Configuration Bitmap";
                    getHardwareConfigurationBitmap.Width = labelAndTextBoxs[labelAndTextBoxs.Length - 1].Width;
                    getHardwareConfigurationBitmap.Location = new Point(labelAndTextBoxs[labelAndTextBoxs.Length - 1].Location.X, labelAndTextBoxs[labelAndTextBoxs.Length - 1].Location.Y + labelAndTextBoxs[labelAndTextBoxs.Length - 1].Height);
                    getHardwareConfigurationBitmap.Click += new EventHandler(GetHardwareConfigurationBitmap);
                    ValuePanel.Controls.Add(getHardwareConfigurationBitmap);
                    break;
                case ManageCommandName.GetSignatureReq:
                    break;
                case ManageCommandName.GetSignatureRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(ManageCommon.GetSignatureRspNormal, 394, new Point(0, 2), _manageData.GetSignatureRspNormalData);
                    labelAndTextBoxs[2].SetTextBoxHeight(80);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);

                    Button saveSigButton = new Button();
                    saveSigButton.Location = new Point(labelAndTextBoxs[2].Location.X, labelAndTextBoxs[2].Location.Y + labelAndTextBoxs[2].Font.Height + labelAndTextBoxs[2].Margin.Top + 10);
                    saveSigButton.Width = labelAndTextBoxs[2].GetLabelData().Width + 2;
                    saveSigButton.Text = "Save Bmp";
                    saveSigButton.Click += new EventHandler(SaveSigButtonClick);
                    ValuePanel.Controls.Add(saveSigButton);
                    saveSigButton.BringToFront();

                    break;
                case ManageCommandName.ResetReq:
                    break;
                case ManageCommandName.ResetRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(ManageCommon.ResetRspNormal, 394, new Point(0, 2), _manageData.ResetRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case ManageCommandName.UpdateResourceFileReq:
                    labelAndComboBox = new LabelComboBoxUserControl[1];
                    labelAndComboBox[0] = CreateLabelAndComboBox(ManageCommon.UpdateResourceFileReqComboBox[0, 0], ManageCommon.UpdateResourceFileReqComboBox[0, 1], 394, new Point(0, 2), Global.GetFileTypeKey(), _manageData.FileTypeIndex);
                    ValuePanel.Controls.AddRange(labelAndComboBox);
                    labelAndTextBoxs = CreateLabelAndTextBoxs(ManageCommon.UpdateResourceFileReqNormal, 294, new Point(0, 2 + 22), _manageData.UpdateResourceFileReqNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);

                    Button broswer2 = new Button();
                    broswer2.Width = 94;
                    broswer2.Location = new Point(294, 1 + 22);
                    broswer2.Text = "Browse";
                    broswer2.Click += new EventHandler(FilePickButtonClick);
                    ValuePanel.Controls.Add(broswer2);
                    break;
                case ManageCommandName.UpdateResourceFileRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(ManageCommon.UpdateResourceFileRspNormal, 394, new Point(0, 2), _manageData.UpdateResourceFileRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case ManageCommandName.DoSignatureReq:
                    labelAndComboBox = new LabelComboBoxUserControl[1];
                    labelAndComboBox[0] = CreateLabelAndComboBox(ManageCommon.DoSignatureReqNormalComboBox[0, 0], ManageCommon.DoSignatureReqNormalComboBox[0, 1], 394, new Point(0, 2), Global.GetEdcTypeKey(), _manageData.EdcTypeIndex);
                    ValuePanel.Controls.AddRange(labelAndComboBox);

                    labelAndTextBoxs = CreateLabelAndTextBoxs(ManageCommon.DoSignatureReqNormal, 394, new Point(0, 24), _manageData.DoSignatureReqNormalData);
                    labelAndTextBoxs[2].CreateLabelTextBox(350, "Timeout", "Timeout", 0.335f);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    unitOfTimeout = new Label();
                    unitOfTimeout.AutoSize = true;
                    unitOfTimeout.Text = "100ms";
                    unitOfTimeout.Location = new Point(350, 3*22+2);
                    ValuePanel.Controls.Add(unitOfTimeout);
                    break;
                case ManageCommandName.DoSignatureRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(ManageCommon.DoSignatureRspNormal, 394, new Point(0, 2), _manageData.DoSignatureRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case ManageCommandName.DeleteImageReq:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(ManageCommon.DeleteImageReqNormal, 394, new Point(0, 2), _manageData.DeleteImageReqNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case ManageCommandName.DeleteImageRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(ManageCommon.DeleteImageRspNormal, 394, new Point(0, 2), _manageData.DeleteImageRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case ManageCommandName.RebootReq:
                    break;
                case ManageCommandName.RebootRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(ManageCommon.RebootRspNormal, 394, new Point(0, 2), _manageData.RebootRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case ManageCommandName.InputAccountReq:
                    labelAndComboBox = new LabelComboBoxUserControl[2];
                    labelAndComboBox[0] = CreateLabelAndComboBox(ManageCommon.InputAccountReqNormalComboBox[0, 0], ManageCommon.InputAccountReqNormalComboBox[0, 1], 394, new Point(0, 2), Global.GetEdcTypeKey(), _manageData.EdcTypeIndex);
                    labelAndComboBox[1] = CreateLabelAndComboBox(ManageCommon.InputAccountReqNormalComboBox[1, 0], ManageCommon.InputAccountReqNormalComboBox[1, 1], 394, new Point(0, 22 + 2), Global.GetTransTypeKey(), _manageData.TransactionTypeIndex);
                    ValuePanel.Controls.AddRange(labelAndComboBox);

                    labelAndTextBoxs = CreateLabelAndTextBoxs(ManageCommon.InputAccountReqNormal, 394, new Point(0, 46), _manageData.InputAccountReqNormalData);
                    labelAndTextBoxs[5].CreateLabelTextBox(350, "Timeout", "Timeout", 0.335f);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    unitOfTimeout = new Label();
                    unitOfTimeout.AutoSize = true;
                    unitOfTimeout.Text = "100ms";
                    unitOfTimeout.Location = new Point(350, 22 * 7 + 2);
                    ValuePanel.Controls.Add(unitOfTimeout);
                    break;
                case ManageCommandName.InputAccountRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(ManageCommon.InputAccountRspNormal, 394, new Point(0, 2), _manageData.InputAccountRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case ManageCommandName.ResetMsrReq:
                    break;
                case ManageCommandName.ResetMsrRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(ManageCommon.ResetMsrRspNormal, 394, new Point(0, 2), _manageData.ResetMsrRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case ManageCommandName.CheckFileReq:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(ManageCommon.CheckFileReqNormal, 394, new Point(0, 2), _manageData.CheckFileReqNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case ManageCommandName.CheckFileRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(ManageCommon.CheckFileRspNormal, 394, new Point(0, 2), _manageData.CheckFileRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case ManageCommandName.SetSafParametersReq:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(ManageCommon.SetSafParametersReqNormal, 394, new Point(0, 2), _manageData.SetSafParametersReqNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case ManageCommandName.SetSafParametersRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(ManageCommon.SetSafParametersRspNormal, 394, new Point(0, 2), _manageData.SetSafParametersRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case ManageCommandName.ReprintReq:
                    labelAndComboBox = new LabelComboBoxUserControl[2];
                    labelAndComboBox[0] = CreateLabelAndComboBox(ManageCommon.ReprintReqNormalComboBox[0, 0], ManageCommon.ReprintReqNormalComboBox[0, 1], 394, new Point(0, 2), Global.GetEdcTypeKey(), _manageData.EdcTypeIndex);
                    ValuePanel.Controls.AddRange(labelAndComboBox);

                    labelAndTextBoxs = CreateLabelAndTextBoxs(ManageCommon.ReprintReqNormal, 394, new Point(0, 22+2), _manageData.ReprintReqNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case ManageCommandName.ReprintRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(ManageCommon.ReprintRspNormal, 394, new Point(0, 2), _manageData.ReprintRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case ManageCommandName.TokenAdministrativeReq:
                    labelAndComboBox = new LabelComboBoxUserControl[1];
                    labelAndComboBox[0] = CreateLabelAndComboBox(ManageCommon.TokenAdministrativeReqNormalComboBox[0, 0], ManageCommon.TokenAdministrativeReqNormalComboBox[0, 1], 394, new Point(0, 2), Global.GetEdcTypeKey(), _manageData.EdcTypeIndex);
                    ValuePanel.Controls.AddRange(labelAndComboBox);

                    labelAndTextBoxs = CreateLabelAndTextBoxs(ManageCommon.TokenAdministrativeReqNormal, 394, new Point(0, 24), _manageData.TokenAdministrativeReqNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case ManageCommandName.TokenAdministrativeRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(ManageCommon.TokenAdministrativeRspNormal, 394, new Point(0, 2), _manageData.TokenAdministrativeRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case ManageCommandName.VasSetMerchantParametersReq:
                    _vasPanel.Location = new Point(0, 2 + 22);
                    _vasPanel.Width = 396;
                    _vasPanel.Height = 400;
                    ValuePanel.Controls.Add(_vasPanel);

                    Label vasProgramLabel = new Label();
                    vasProgramLabel.AutoSize = false;
                    vasProgramLabel.Text = "VAS Program";
                    vasProgramLabel.Width = 113;
                    vasProgramLabel.Height = 22;
                    vasProgramLabel.TextAlign = ContentAlignment.MiddleRight;
                    vasProgramLabel.Location = new Point(0, 2);
                    ValuePanel.Controls.Add(vasProgramLabel);

                    ComboBox vasProgramComboBox = new ComboBox();
                    vasProgramComboBox.Name = "VasProgramComboBox";
                    vasProgramComboBox.Width = 272;
                    vasProgramComboBox.Location = new Point(113 + 2, 2);
                    string[] itemsArray = new string[ManageCommon.VasProgramItemsName.Length / 2];
                    for (int i = 0; i < ManageCommon.VasProgramItemsName.Length / 2; i++)
                    {
                        itemsArray[i] = (string)ManageCommon.VasProgramItemsName[i, 0];
                    }
                    vasProgramComboBox.Items.AddRange(itemsArray);
                    vasProgramComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                    vasProgramComboBox.SelectedIndexChanged += new EventHandler(VasProgramSelectedIndexChanged);
                    vasProgramComboBox.Leave += new EventHandler(LoseOfFocusComboBox);
                    ValuePanel.Controls.Add(vasProgramComboBox);
                    vasProgramComboBox.SelectedIndex = _manageData.VasProgramIndex;
                    break;
                case ManageCommandName.VasSetMerchantParametersRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(ManageCommon.VasSetMerchantParametersRspNormal, 394, new Point(0, 2), _manageData.VasSetMerchantParametersRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case ManageCommandName.VasPushDataReq:
                    labelAndComboBox = new LabelComboBoxUserControl[2];
                    labelAndComboBox[0] = CreateLabelAndComboBox(ManageCommon.VasPushDataReqNormalComboBox[0, 0], ManageCommon.VasPushDataReqNormalComboBox[0, 1], 394, new Point(0, 2), ParseToStringArray(ManageCommon.VasModeItemsName), _manageData.VasModeIndex);
                    labelAndComboBox[1] = CreateLabelAndComboBox(ManageCommon.VasPushDataReqNormalComboBox[1, 0], ManageCommon.VasPushDataReqNormalComboBox[1, 1], 394, new Point(0, 22+2), ParseToStringArray(ManageCommon.SecurityItemsName), _manageData.SecurityIndex);
                    ValuePanel.Controls.AddRange(labelAndComboBox);

                    labelAndTextBoxs = CreateLabelAndTextBoxs(ManageCommon.VasPushDataReqNormal, 394, new Point(0, 2+22*2), _manageData.VasPushDataReqNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);

                    ButtonTextBoxUserControl[] buttonTextBoxUserControl = new ButtonTextBoxUserControl[ManageCommon.VasPushDataReqNormalButtonTextBox.Length];
                    for (int i = 0; i < ManageCommon.VasPushDataReqNormalButtonTextBox.Length; i++)
                    {
                        buttonTextBoxUserControl[i] = new ButtonTextBoxUserControl();
                        buttonTextBoxUserControl[i].Name = ManageCommon.VasPushDataReqNormalButtonTextBox[i] + "UserControl";
                        buttonTextBoxUserControl[i].CreateButtonTextBox(394, ManageCommon.VasPushDataReqNormalButtonTextBox[i], _manageData.VasPushDataReqNormalButtonTextBoxData[i], 0.3f);
                        buttonTextBoxUserControl[i].Location = new Point(0, 90 + 22 * i);
                        buttonTextBoxUserControl[i].CommandName = ButtonClickEventCommandName.VasPushDataReq;
                        buttonTextBoxUserControl[i].ButtonName = ManageCommon.VasPushDataReqNormalButtonTextBox[i];
                        buttonTextBoxUserControl[i].SetTextBoxValue(_manageData.VasPushDataReqNormalButtonTextBoxData[i]);
                        buttonTextBoxUserControl[i].Leave += new EventHandler(LoseOfFocusButtonTextBox);
                    }
                    buttonTextBoxUserControl[0].CommandName = ButtonClickEventCommandName.GoogleSmartTapReq;
                    ValuePanel.Controls.AddRange(buttonTextBoxUserControl);
                    break;
                case ManageCommandName.VasPushDataRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(ManageCommon.VasPushDataRspNormal, 394, new Point(0, 2), _manageData.VasPushDataRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case ManageCommandName.GetSafParametersReq:
                    break;
                case ManageCommandName.GetSafParametersRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(ManageCommon.GetSafParametersRspNormal, 394, new Point(0, 2), _manageData.GetSafParametersRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                default:
                    break;
            }
        }

        private void VasProgramSelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            LabelTextBoxUserControl[] labelAndTextBoxs;
            LabelComboBoxUserControl[] labelAndComboBox;
            ButtonTextBoxUserControl[] buttonTextBox;
            switch (comboBox.SelectedIndex)
            {
                case 0:
                    _tools.DisposeSubControls(_vasPanel);
                    labelAndComboBox = new LabelComboBoxUserControl[1];
                    labelAndComboBox[0] = CreateLabelAndComboBox(ManageCommon.ApplePayVasReqNormalComboBox[0, 0], ManageCommon.ApplePayVasReqNormalComboBox[0, 1], 394, new Point(0, 0), ParseToStringArray(ManageCommon.VasModeItemsName), _manageData.VasModeIndex);
                    _vasPanel.Controls.AddRange(labelAndComboBox);

                    labelAndTextBoxs = CreateLabelAndTextBoxs(ManageCommon.ApplePayVasReqNormal, 394, new Point(0, 22), _manageData.ApplePayVasReqNormalData);
                    _vasPanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case 1:
                    _tools.DisposeSubControls(_vasPanel);
                    labelAndComboBox = new LabelComboBoxUserControl[2];
                    labelAndComboBox[0] = CreateLabelAndComboBox(ManageCommon.GoogleSmartTapReqNormalComboBox[0, 0], ManageCommon.GoogleSmartTapReqNormalComboBox[0, 1], 394, new Point(0, 0), ParseToStringArray(ManageCommon.VasModeItemsName), _manageData.VasModeIndex);
                    labelAndComboBox[1] = CreateLabelAndComboBox(ManageCommon.GoogleSmartTapReqNormalComboBox[1, 0], ManageCommon.GoogleSmartTapReqNormalComboBox[1, 1], 394, new Point(0, 22), ParseToStringArray(ManageCommon.SecurityItemsName), _manageData.SecurityIndex);
                    _vasPanel.Controls.AddRange(labelAndComboBox);

                    buttonTextBox = new ButtonTextBoxUserControl[1];
                    buttonTextBox[0] = new ButtonTextBoxUserControl();
                    buttonTextBox[0].Name = ManageCommon.GoogleSmartTapReqNormalButtonTextBox[0] + "UserControl";
                    buttonTextBox[0].CreateButtonTextBox(394, ManageCommon.GoogleSmartTapReqNormalButtonTextBox[0], _manageData.GoogleSmartTapReqNormalButtonTextBoxData[0], 0.3f);
                    buttonTextBox[0].CommandName = ButtonClickEventCommandName.GoogleSmartTapReq;
                    buttonTextBox[0].Location = new Point(0, 44);
                    buttonTextBox[0].Leave += new EventHandler(LoseOfFocusButtonTextBox);
                    _vasPanel.Controls.AddRange(buttonTextBox);

                    labelAndTextBoxs = CreateLabelAndTextBoxs(ManageCommon.GoogleSmartTapReqNormal, 394, new Point(0, 66), _manageData.GoogleSmartTapReqNormalData);
                    _vasPanel.Controls.AddRange(labelAndTextBoxs);

                    Label serviceTypeLabel = new Label();
                    serviceTypeLabel.AutoSize = false;
                    serviceTypeLabel.Text = "Service Type";
                    serviceTypeLabel.Width = 113;
                    serviceTypeLabel.Height = 22;
                    serviceTypeLabel.TextAlign = ContentAlignment.MiddleRight;
                    serviceTypeLabel.Location = new Point(0, 66+ ManageCommon.GoogleSmartTapReqNormal.Length/2*22);
                    _vasPanel.Controls.Add(serviceTypeLabel);

                    CheckedListBox serviceTypeCheckedListBox = new CheckedListBox();
                    serviceTypeCheckedListBox.Name = "ServiceTypeCheckedListBox";
                    serviceTypeCheckedListBox.Location = new Point(115, 66 + ManageCommon.GoogleSmartTapReqNormal.Length / 2 * 22);
                    serviceTypeCheckedListBox.Width = 272;
                    serviceTypeCheckedListBox.Items.AddRange(ManageCommon.ServiceTypeItemList);
                    serviceTypeCheckedListBox.Leave += new EventHandler(LoseOfFocusCheckListBox);
                    for (int i = 0; i < serviceTypeCheckedListBox.Items.Count; i++)
                    {
                        serviceTypeCheckedListBox.SetItemChecked(i, _manageData.ServiceTypeItemListData[i]);
                    }
                    _vasPanel.Controls.Add(serviceTypeCheckedListBox);
                    break;
                default:
                    break;
            }
        }

        private LabelTextBoxUserControl[] CreateLabelAndTextBoxs(string[,] nameAndText, int width, Point point, string[] value)
        {
            LabelTextBoxUserControl[] temp = new LabelTextBoxUserControl[nameAndText.Length / 2];
            for (int i = 0; i < nameAndText.Length / 2; i++)
            {
                temp[i] = new LabelTextBoxUserControl();
                temp[i].Name = nameAndText[i, 0] + "UserControl";
                float proportion = 0.3f;
                if(width <300)
                {
                    proportion = 0.4f;
                }
                temp[i].CreateLabelTextBox(width, nameAndText[i, 0], nameAndText[i, 1], proportion);
                temp[i].SetTextBoxValue(value[i]);
                temp[i].Location = point;
                temp[i].Leave += new EventHandler(LoseOfFocusTextBoxUserControl);
                point.Y += 22;
            }
            return temp;
        }

        private LabelComboBoxUserControl CreateLabelAndComboBox(string name, string text, int width, Point point, string[] items, int index)
        {
            LabelComboBoxUserControl temp = new LabelComboBoxUserControl();
            temp = new LabelComboBoxUserControl();
            temp.Name = name + "UserControl";
            float proportion = 0.3f;
            if (width < 300)
            {
                proportion = 0.4f;
            }
            temp.CreateLabelComboBox(width, name, text, items, proportion);
            temp.SetComboBoxIndex(index);
            temp.Location = point;
            temp.Leave += new EventHandler(LoseOfFocusComboBoxUserControl);
            return temp;
        }

        private void LoseOfFocusTextBoxUserControl(object sender, EventArgs e)
        {
            LabelTextBoxUserControl userControl = (LabelTextBoxUserControl)sender;
            switch (_commandName)
            {
                case ManageCommandName.UpdateResourceFileReq:
                    for (int i = 0; i < ManageCommon.UpdateResourceFileReqNormal.Length / 2; i++)
                    {
                        if (userControl.Name == ManageCommon.UpdateResourceFileReqNormal[i, 0] + "UserControl")
                        {
                            _manageData.UpdateResourceFileReqNormalData[i] = userControl.GetTextBoxValue();
                        }
                    }
                    break;
                case ManageCommandName.DoSignatureReq:
                    for (int i = 0; i < ManageCommon.DoSignatureReqNormal.Length / 2; i++)
                    {
                        if (userControl.Name == ManageCommon.DoSignatureReqNormal[i, 0] + "UserControl")
                        {
                            _manageData.DoSignatureReqNormalData[i] = userControl.GetTextBoxValue();
                        }
                    }
                    break;
                case ManageCommandName.DeleteImageReq:
                    for (int i = 0; i < ManageCommon.DeleteImageReqNormal.Length / 2; i++)
                    {
                        if (userControl.Name == ManageCommon.DeleteImageReqNormal[i, 0] + "UserControl")
                        {
                            _manageData.DeleteImageReqNormalData[i] = userControl.GetTextBoxValue();
                        }
                    }
                    break;
                case ManageCommandName.InputAccountReq:
                    for (int i = 0; i < ManageCommon.InputAccountReqNormal.Length / 2; i++)
                    {
                        if (userControl.Name == ManageCommon.InputAccountReqNormal[i, 0] + "UserControl")
                        {
                            _manageData.InputAccountReqNormalData[i] = userControl.GetTextBoxValue();
                        }
                    }
                    break;
                case ManageCommandName.CheckFileReq:
                    for (int i = 0; i < ManageCommon.CheckFileReqNormal.Length / 2; i++)
                    {
                        if (userControl.Name == ManageCommon.CheckFileReqNormal[i, 0] + "UserControl")
                        {
                            _manageData.CheckFileReqNormalData[i] = userControl.GetTextBoxValue();
                        }
                    }
                    break;
                case ManageCommandName.SetSafParametersReq:
                    for (int i = 0; i < ManageCommon.SetSafParametersReqNormal.Length / 2; i++)
                    {
                        if (userControl.Name == ManageCommon.SetSafParametersReqNormal[i, 0] + "UserControl")
                        {
                            _manageData.SetSafParametersReqNormalData[i] = userControl.GetTextBoxValue();
                        }
                    }
                    break;
                case ManageCommandName.ReprintReq:
                    for (int i = 0; i < ManageCommon.ReprintReqNormal.Length / 2; i++)
                    {
                        if (userControl.Name == ManageCommon.ReprintReqNormal[i, 0] + "UserControl")
                        {
                            _manageData.ReprintReqNormalData[i] = userControl.GetTextBoxValue();
                        }
                    }
                    break;
                case ManageCommandName.TokenAdministrativeReq:
                    for (int i = 0; i < ManageCommon.TokenAdministrativeReqNormal.Length / 2; i++)
                    {
                        if (userControl.Name == ManageCommon.TokenAdministrativeReqNormal[i, 0] + "UserControl")
                        {
                            _manageData.TokenAdministrativeReqNormalData[i] = userControl.GetTextBoxValue();
                        }
                    }
                    break;
                case ManageCommandName.VasSetMerchantParametersReq:
                    for (int i = 0; i < ManageCommon.ApplePayVasReqNormal.Length / 2; i++)
                    {
                        if (userControl.Name == ManageCommon.ApplePayVasReqNormal[i, 0] + "UserControl")
                        {
                            _manageData.ApplePayVasReqNormalData[i] = userControl.GetTextBoxValue();
                        }
                    }
                    for (int i = 0; i < ManageCommon.GoogleSmartTapReqNormal.Length / 2; i++)
                    {
                        if (userControl.Name == ManageCommon.GoogleSmartTapReqNormal[i, 0] + "UserControl")
                        {
                            _manageData.GoogleSmartTapReqNormalData[i] = userControl.GetTextBoxValue();
                        }
                    }
                    break;
                case ManageCommandName.VasPushDataReq:
                    for (int i = 0; i < ManageCommon.VasPushDataReqNormal.Length / 2; i++)
                    {
                        if (userControl.Name == ManageCommon.VasPushDataReqNormal[i, 0] + "UserControl")
                        {
                            _manageData.VasPushDataReqNormalData[i] = userControl.GetTextBoxValue();
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void LoseOfFocusComboBoxUserControl(object sender, EventArgs e)
        {
            LabelComboBoxUserControl userControl = (LabelComboBoxUserControl)sender;
            switch (userControl.Name)
            {
                case "EdcTypeUserControl":
                    _manageData.EdcTypeIndex = userControl.GetComboBoxIndex();
                    break;
                case "TransactionTypeUserControl":
                    _manageData.TransactionTypeIndex = userControl.GetComboBoxIndex();
                    break;
                case "VasModeUserControl":
                    _manageData.VasModeIndex = userControl.GetComboBoxIndex();
                    break;
                 case "SecurityUserControl":
                    _manageData.SecurityIndex = userControl.GetComboBoxIndex();
                    break;
                case "FileTypeUserControl":
                    _manageData.FileTypeIndex = userControl.GetComboBoxIndex();
                    break;
                default:
                    break;
            }
        }

        private void LoseOfFocusComboBox(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            switch (comboBox.Name)
            {
                case "VasProgramComboBox":
                    _manageData.VasProgramIndex = comboBox.SelectedIndex;
                    break;
                default:
                    break;
            }
        }

        private void LoseOfFocusButtonTextBox(object sender, EventArgs e)
        {
            ButtonTextBoxUserControl userControl = (ButtonTextBoxUserControl)sender;
            switch(_commandName)
            {
                case ManageCommandName.VasSetMerchantParametersReq:
                    for (int i = 0; i < ManageCommon.GoogleSmartTapReqNormalButtonTextBox.Length; i++)
                    {
                        if (userControl.Name == ManageCommon.GoogleSmartTapReqNormalButtonTextBox[i] + "UserControl")
                        {
                            _manageData.GoogleSmartTapReqNormalButtonTextBoxData[i] = userControl.GetTextBoxValue();
                        }
                    }
                    break;
                case ManageCommandName.VasPushDataReq:
                    for (int i = 0; i < ManageCommon.VasPushDataReqNormalButtonTextBox.Length; i++)
                    {
                        if (userControl.Name == ManageCommon.VasPushDataReqNormalButtonTextBox[i] + "UserControl")
                        {
                            _manageData.VasPushDataReqNormalButtonTextBoxData[i] = userControl.GetTextBoxValue();
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void LoseOfFocusCheckListBox(object sender, EventArgs e)
        {
            CheckedListBox checkedListBox = (CheckedListBox)sender;
            switch(checkedListBox.Name)
            {
                case "ServiceTypeCheckedListBox":
                    for(int i=0;i<checkedListBox.Items.Count;i++)
                    {
                        _manageData.ServiceTypeItemListData[i] = checkedListBox.GetItemChecked(i);
                    }
                    break;
                default:
                    break;
            }
        }

        private void BroswerButtonClick(object sender, EventArgs e)
        {
            FolderBrowserDialog folderPath = new FolderBrowserDialog();
            if (folderPath.ShowDialog() == DialogResult.OK)
            {
                _manageData.GetSignatureReqNormalData[0] = folderPath.SelectedPath;
                ShowPanel(sender, e);
            }
        }

        private void DetailButtonClick(object sender, EventArgs e)
        {
            ShowSignatureDataForm showSignatureDataForm = new ShowSignatureDataForm();
            showSignatureDataForm.SignatureData = _manageData.SignatureData;
            showSignatureDataForm.Show();
        }

        private void FilePickButtonClick(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Zip(*zip*)|*.zip*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if(_commandName == ManageCommandName.UpdateResourceFileReq)
                {
                    _manageData.UpdateResourceFileReqNormalData[0] = fileDialog.FileName;
                }
                ShowPanel(sender, e);
            }
        }

        private void SaveSigButtonClick(object sender, EventArgs e)
        {
            if(_manageData.GetSignatureRspNormalData[2] == null)
            {
                MessageBox.Show("Is no data to save.", "Warning");
                return;
            }
            SaveFileDialog filePathDialog = new SaveFileDialog();
            filePathDialog.Filter = "Bmp(*bmp*)|*.bmp*";
            filePathDialog.RestoreDirectory = true;
            if (filePathDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = filePathDialog.FileName.ToString();
                try
                {
                    byte[] fileDataArray = POSLink2.POSLinkTools.ConvertSigToBmp(_manageData.GetSignatureRspNormalData[2]);
                    FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    fileStream.Write(fileDataArray, 0, fileDataArray.Length);
                    if(fileDataArray.Length != 0)
                    {
                        MessageBox.Show("Save successfully!", "Message");
                    }
                    fileStream.Close();
                    fileStream.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR");
                }
            }
        }

        private void GetHardwareConfigurationBitmap(object sender, EventArgs e)
        {
            ManageData manageData = ManageData.GetManageData();
            HardwareConfigurationBitmapForm hardwareConfigurationBitmapForm = new HardwareConfigurationBitmapForm();
            hardwareConfigurationBitmapForm.HardwareConfigurationBitmap = manageData.HardwareConfigurationBitmap;
            hardwareConfigurationBitmapForm.Show();
        }

        private static string[] ParseToStringArray(object[,] items)
        {
            string[] itemsArray = new string[items.Length / 2];
            for (int i = 0; i < items.Length / 2; i++)
            {
                itemsArray[i] = (string)items[i, 0];
            }
            return itemsArray;
        }
    }
}

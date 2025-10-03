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
    public partial class FormOnePanelUserControl : UserControl
    {
        private FormCommandName _commandName;
        public FormCommandName CommandName
        {
            get { return _commandName; }
            set { _commandName = value; }
        }

        private FormData _formData;
        private Tools _tools = new Tools();
        public FormOnePanelUserControl()
        {
            InitializeComponent();
            _formData = FormData.GetFormData();
        }

        public void ShowPanel(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ValuePanel);
            LabelTextBoxUserControl[] labelAndTextBoxs;
            Label unitOfTimeout;
            switch (_commandName)
            {
                case FormCommandName.ShowDialogReq:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(FormCommon.ShowDialogReqNormal, 394, new Point(0, 2), _formData.ShowDialogReqNormalData);
                    labelAndTextBoxs[5].CreateLabelTextBox(350, "Timeout", "Timeout", 0.335f);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    unitOfTimeout = new Label();
                    unitOfTimeout.AutoSize = true;
                    unitOfTimeout.Text = "100ms";
                    unitOfTimeout.Location = new Point(350, 5*22+2);
                    ValuePanel.Controls.Add(unitOfTimeout);
                    break;
                case FormCommandName.ShowDialogRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(FormCommon.ShowDialogRspNormal, 394, new Point(0, 2), _formData.ShowDialogRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case FormCommandName.ShowMessageReq:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(FormCommon.ShowMessageReqNormal, 394, new Point(0, 2), _formData.ShowMessageReqNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case FormCommandName.ShowMessageRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(FormCommon.ShowMessageRspNormal, 394, new Point(0, 2), _formData.ShowMessageRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case FormCommandName.ClearMessageReq:
                    break;
                case FormCommandName.ClearMessageRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(FormCommon.ClearMessageRspNormal, 394, new Point(0, 2), _formData.ClearMessageRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case FormCommandName.ShowMessageCenterReq:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(FormCommon.ShowMessageCenterReqNormal, 394, new Point(0, 2), _formData.ShowMessageCenterReqNormalData);
                    labelAndTextBoxs[3].CreateLabelTextBox(350, "Timeout", "Timeout", 0.335f);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    unitOfTimeout = new Label();
                    unitOfTimeout.AutoSize = true;
                    unitOfTimeout.Text = "100ms";
                    unitOfTimeout.Location = new Point(350, 3 * 22 + 2);
                    ValuePanel.Controls.Add(unitOfTimeout);
                    break;
                case FormCommandName.ShowMessageCenterRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(FormCommon.ShowMessageCenterRspNormal, 394, new Point(0, 2), _formData.ShowMessageCenterRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case FormCommandName.InputTextReq:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(FormCommon.InputTextReqNormal, 394, new Point(0, 2), _formData.InputTextReqNormalData);
                    labelAndTextBoxs[5].CreateLabelTextBox(350, "Timeout", "Timeout", 0.335f);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    unitOfTimeout = new Label();
                    unitOfTimeout.AutoSize = true;
                    unitOfTimeout.Text = "100ms";
                    unitOfTimeout.Location = new Point(350, 5 * 22 + 2);
                    ValuePanel.Controls.Add(unitOfTimeout);
                    break;
                case FormCommandName.InputTextRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(FormCommon.InputTextRspNormal, 394, new Point(0, 2), _formData.InputTextRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case FormCommandName.RemoveCardReq:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(FormCommon.RemoveCardReqNormal, 394, new Point(0, 2), _formData.RemoveCardReqNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case FormCommandName.RemoveCardRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(FormCommon.RemoveCardRspNormal, 394, new Point(0, 2), _formData.RemoveCardRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case FormCommandName.ShowTextBoxReq:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(FormCommon.ShowTextBoxReqNormal, 394, new Point(0, 2), _formData.ShowTextBoxReqNormalDara);
                    labelAndTextBoxs[8].CreateLabelTextBox(350, "Timeout", "Timeout", 0.335f);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    unitOfTimeout = new Label();
                    unitOfTimeout.AutoSize = true;
                    unitOfTimeout.Text = "100ms";
                    unitOfTimeout.Location = new Point(350, 8 * 22 + 2);
                    ValuePanel.Controls.Add(unitOfTimeout);
                    break;
                case FormCommandName.ShowTextBoxRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(FormCommon.ShowTextBoxRspNormal, 394, new Point(0, 2), _formData.ShowTextBoxRspNormalDara);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case FormCommandName.ShowItemReq:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(FormCommon.ShowItemReqNormal, 394, new Point(0, 2), _formData.ShowItemReqNormalData);
                    Button itemDetailButton = new Button();
                    itemDetailButton.Text = "Set";
                    itemDetailButton.Width = 100;
                    itemDetailButton.Location = new Point(labelAndTextBoxs[4].Width - 102, labelAndTextBoxs[4].Location.Y-1);
                    itemDetailButton.Click += new EventHandler(SetItemDetailButtonClick);
                    ValuePanel.Controls.Add(itemDetailButton);
                    labelAndTextBoxs[4].SetTextBoxWidth(170);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case FormCommandName.ShowItemRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(FormCommon.ShowItemRspNormal, 394, new Point(0, 2), _formData.ShowItemRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case FormCommandName.ShowDialogFormReq:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(FormCommon.ShowDialogFormReqNormal, 394, new Point(0, 2), _formData.ShowDialogFormReqNormalData);
                    labelAndTextBoxs[10].CreateLabelTextBox(350, "Timeout", "Timeout", 0.335f);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    unitOfTimeout = new Label();
                    unitOfTimeout.AutoSize = true;
                    unitOfTimeout.Text = "100ms";
                    unitOfTimeout.Location = new Point(350, 10 * 22 + 2);
                    ValuePanel.Controls.Add(unitOfTimeout);
                    break;
                case FormCommandName.ShowDialogFormRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(FormCommon.ShowDialogFormRspNormal, 394, new Point(0, 2), _formData.ShowDialogFormRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
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
                if (width < 300)
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

        private void SetItemDetailButtonClick(object sender, EventArgs e)
        {
            ItemDetailForm itemDetailForm = new ItemDetailForm();
            DialogResult ret = itemDetailForm.ShowDialog();
            if(ret == DialogResult.OK)
            {
                string message = "";
                if (itemDetailForm.ItemDetails != null && itemDetailForm.ItemDetails.Count > 0)
                {
                    for(int i=0;i< itemDetailForm.ItemDetails.Count;i++)
                    {
                        if(i != 0)
                        {
                            message += "|";
                        }
                        message += itemDetailForm.ItemDetails[i].Pack();
                    }
                    _formData.ItemDetailData = itemDetailForm.ItemDetails.ToArray();
                }
                else
                {
                    _formData.ItemDetailData = null;
                }
                LabelTextBoxUserControl temp = (LabelTextBoxUserControl)this.Controls.Find("ItemDetailUserControl", true)[0];
                if (temp != null)
                {
                    temp.SetTextBoxValue(message);
                    _formData.ShowItemReqNormalData[4] = message;
                }
            }
            itemDetailForm.Hide();
        }

        private void LoseOfFocusTextBoxUserControl(object sender, EventArgs e)
        {
            LabelTextBoxUserControl userControl = (LabelTextBoxUserControl)sender;
            switch (_commandName)
            {
                case FormCommandName.ShowDialogReq:
                    for (int i = 0; i < FormCommon.ShowDialogReqNormal.Length / 2; i++)
                    {
                        if (userControl.Name == FormCommon.ShowDialogReqNormal[i, 0] + "UserControl")
                        {
                            _formData.ShowDialogReqNormalData[i] = userControl.GetTextBoxValue();
                        }
                    }
                    break;
                case FormCommandName.ShowMessageReq:
                    for (int i = 0; i < FormCommon.ShowMessageReqNormal.Length / 2; i++)
                    {
                        if (userControl.Name == FormCommon.ShowMessageReqNormal[i, 0] + "UserControl")
                        {
                            _formData.ShowMessageReqNormalData[i] = userControl.GetTextBoxValue();
                        }
                    }
                    break;
                case FormCommandName.ShowMessageCenterReq:
                    for (int i = 0; i < FormCommon.ShowMessageCenterReqNormal.Length / 2; i++)
                    {
                        if (userControl.Name == FormCommon.ShowMessageCenterReqNormal[i, 0] + "UserControl")
                        {
                            _formData.ShowMessageCenterReqNormalData[i] = userControl.GetTextBoxValue();
                        }
                    }
                    break;
                case FormCommandName.InputTextReq:
                    for (int i = 0; i < FormCommon.InputTextReqNormal.Length / 2; i++)
                    {
                        if (userControl.Name == FormCommon.InputTextReqNormal[i, 0] + "UserControl")
                        {
                            _formData.InputTextReqNormalData[i] = userControl.GetTextBoxValue();
                        }
                    }
                    break;
                case FormCommandName.RemoveCardReq:
                    for (int i = 0; i < FormCommon.RemoveCardReqNormal.Length / 2; i++)
                    {
                        if (userControl.Name == FormCommon.RemoveCardReqNormal[i, 0] + "UserControl")
                        {
                            _formData.RemoveCardReqNormalData[i] = userControl.GetTextBoxValue();
                        }
                    }
                    break;
                case FormCommandName.ShowTextBoxReq:
                    for (int i = 0; i < FormCommon.ShowTextBoxReqNormal.Length / 2; i++)
                    {
                        if (userControl.Name == FormCommon.ShowTextBoxReqNormal[i, 0] + "UserControl")
                        {
                            _formData.ShowTextBoxReqNormalDara[i] = userControl.GetTextBoxValue();
                        }
                    }
                    break;
                case FormCommandName.ShowItemReq:
                    for (int i = 0; i < FormCommon.ShowItemReqNormal.Length / 2; i++)
                    {
                        if (userControl.Name == FormCommon.ShowItemReqNormal[i, 0] + "UserControl")
                        {
                            _formData.ShowItemReqNormalData[i] = userControl.GetTextBoxValue();
                        }
                    }
                    break;
                case FormCommandName.ShowDialogFormReq:
                    for (int i = 0; i < FormCommon.ShowDialogFormReqNormal.Length / 2; i++)
                    {
                        if (userControl.Name == FormCommon.ShowDialogFormReqNormal[i, 0] + "UserControl")
                        {
                            _formData.ShowDialogFormReqNormalData[i] = userControl.GetTextBoxValue();
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}

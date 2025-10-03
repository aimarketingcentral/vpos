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
    public partial class BatchOnePanelUserControl : UserControl
    {
        private BatchCommandName _commandName;
        public BatchCommandName CommandName
        {
            get { return _commandName; }
            set { _commandName = value; }
        }

        private BatchData _batchData;
        private Tools _tools = new Tools();
        public BatchOnePanelUserControl()
        {
            InitializeComponent();
            _batchData = BatchData.GetBatchData();
        }

        public void ShowPanel(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ValuePanel);
            LabelTextBoxUserControl[] labelAndTextBoxs;
            LabelComboBoxUserControl[] labelAndComboBox;
            switch (_commandName)
            {
                case BatchCommandName.ForceBatchCloseReq:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(BatchCommon.ForceBatchCloseReqNormal, 394, new Point(0, 2), _batchData.ForceBatchCloseReqNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case BatchCommandName.BatchClearReq:
                    labelAndComboBox = new LabelComboBoxUserControl[1];
                    labelAndComboBox[0] = CreateLabelAndComboBox(BatchCommon.BatchClearReqNormal[0,0], BatchCommon.BatchClearReqNormal[0, 1], 394, new Point(0, 2), Global.GetEdcTypeKey(), _batchData.EdcTypeIndex);
                    ValuePanel.Controls.AddRange(labelAndComboBox);
                    break;
                case BatchCommandName.PurgeBatchReq:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(BatchCommon.PurgeBatchReqNormal, 394, new Point(0, 2), _batchData.PurgeBatchReqNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case BatchCommandName.SAFUploadReq:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(BatchCommon.SafUploadReqNormal, 394, new Point(0, 2), _batchData.SafUploadReqNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case BatchCommandName.DeleteSAFFileReq:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(BatchCommon.DeleteSafFileReqNormal, 394, new Point(0, 2), _batchData.DeleteSafFileReqNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case BatchCommandName.DeleteTransactionReq:
                    labelAndComboBox = new LabelComboBoxUserControl[3];
                    labelAndComboBox[0] = CreateLabelAndComboBox(BatchCommon.DeleteTransReqNormalComboBox[0,0], BatchCommon.DeleteTransReqNormalComboBox[0, 1], 394, new Point(0, 2), Global.GetEdcTypeKey(), _batchData.EdcTypeIndex);
                    labelAndComboBox[1] = CreateLabelAndComboBox(BatchCommon.DeleteTransReqNormalComboBox[1,0], BatchCommon.DeleteTransReqNormalComboBox[1, 1], 394, new Point(0, 2 + 22), Global.GetTransTypeKey(), _batchData.TransTypeIndex);
                    labelAndComboBox[2] = CreateLabelAndComboBox(BatchCommon.DeleteTransReqNormalComboBox[2,0], BatchCommon.DeleteTransReqNormalComboBox[2, 1], 394, new Point(0, 2 + 22 * 2), Global.GetCardTypeKey(), _batchData.CardTypeIndex);
                    ValuePanel.Controls.AddRange(labelAndComboBox);
                    labelAndTextBoxs = CreateLabelAndTextBoxs(BatchCommon.DeleteTransReqNormal, 394, new Point(0, 68), _batchData.DeleteTransReqNormalData);
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
                temp[i].CreateLabelTextBox(width, nameAndText[i, 0], nameAndText[i, 1], 0.3f);
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
            temp.CreateLabelComboBox(width, name, text, items, 0.3f);
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
                case BatchCommandName.ForceBatchCloseReq:
                    SetForceBatchCloseReqData(userControl);
                    break;
                case BatchCommandName.PurgeBatchReq:
                    SetPurgeBatchReqData(userControl);
                    break;
                case BatchCommandName.SAFUploadReq:
                    SetSAFUploadReqData(userControl);
                    break;
                case BatchCommandName.DeleteSAFFileReq:
                    SetDeleteSAFFileReqData(userControl);
                    break;
                case BatchCommandName.DeleteTransactionReq:
                    SetDeleteTransactionReqData(userControl);
                    break;
                default:
                    break;
            }
        }

        private void LoseOfFocusComboBoxUserControl(object sender, EventArgs e)
        {
            LabelComboBoxUserControl userControl = (LabelComboBoxUserControl)sender;
            switch (_commandName)
            {
                case BatchCommandName.BatchClearReq:
                    _batchData.EdcTypeIndex = userControl.GetComboBoxIndex();
                    break;
                case BatchCommandName.DeleteTransactionReq:
                    if(userControl.Name == BatchCommon.DeleteTransReqNormalComboBox[0,0] + "UserControl")
                    {
                        _batchData.EdcTypeIndex = userControl.GetComboBoxIndex();
                    }
                    else if(userControl.Name == BatchCommon.DeleteTransReqNormalComboBox[1, 0] + "UserControl")
                    {
                        _batchData.TransTypeIndex = userControl.GetComboBoxIndex();
                    }
                    else if (userControl.Name == BatchCommon.DeleteTransReqNormalComboBox[2, 0] + "UserControl")
                    {
                        _batchData.CardTypeIndex = userControl.GetComboBoxIndex();
                    }
                    break;
                default:
                    break;
            }
        }

        private void SetForceBatchCloseReqData(LabelTextBoxUserControl userControl)
        {
            for (int i = 0; i < BatchCommon.ForceBatchCloseReqNormal.Length/2; i++)
            {
                if (userControl.Name == BatchCommon.ForceBatchCloseReqNormal[i, 0] + "UserControl")
                {
                    _batchData.ForceBatchCloseReqNormalData[i] = userControl.GetTextBoxValue();
                    break;
                }
            }
        }

        private void SetPurgeBatchReqData(LabelTextBoxUserControl userControl)
        {
            for (int i = 0; i < BatchCommon.PurgeBatchReqNormal.Length / 2; i++)
            {
                if (userControl.Name == BatchCommon.PurgeBatchReqNormal[i, 0] + "UserControl")
                {
                    _batchData.PurgeBatchReqNormalData[i] = userControl.GetTextBoxValue();
                    break;
                }
            }
        }

        private void SetSAFUploadReqData(LabelTextBoxUserControl userControl)
        {
            for (int i = 0; i < BatchCommon.SafUploadReqNormal.Length / 2; i++)
            {
                if (userControl.Name == BatchCommon.SafUploadReqNormal[i, 0] + "UserControl")
                {
                    _batchData.SafUploadReqNormalData[i] = userControl.GetTextBoxValue();
                    break;
                }
            }
        }

        private void SetDeleteSAFFileReqData(LabelTextBoxUserControl userControl)
        {
            for (int i = 0; i < BatchCommon.DeleteSafFileReqNormal.Length / 2; i++)
            {
                if (userControl.Name == BatchCommon.DeleteSafFileReqNormal[i, 0] + "UserControl")
                {
                    _batchData.DeleteSafFileReqNormalData[i] = userControl.GetTextBoxValue();
                    break;
                }
            }
        }

        private void SetDeleteTransactionReqData(LabelTextBoxUserControl userControl)
        {
            for (int i = 0; i < BatchCommon.DeleteTransReqNormal.Length / 2; i++)
            {
                if (userControl.Name == BatchCommon.DeleteTransReqNormal[i, 0] + "UserControl")
                {
                    _batchData.DeleteTransReqNormalData[i] = userControl.GetTextBoxValue();
                    break;
                }
            }
        }
    }
}

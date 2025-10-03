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
    public partial class PedOnePanelUserControl : UserControl
    {
        private PedCommandName _commandName;
        public PedCommandName CommandName
        {
            get { return _commandName; }
            set { _commandName = value; }
        }

        private PedData _pedData;
        private Tools _tools = new Tools();
        public PedOnePanelUserControl()
        {
            InitializeComponent();
            _pedData = PedData.GetPedData();
        }

        public void ShowPanel(object sender, EventArgs e)
        {
            _tools.DisposeSubControls(ValuePanel);
            LabelTextBoxUserControl[] labelAndTextBoxs;
            switch (_commandName)
            {
                case PedCommandName.SessionKeyInjectionReq:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(PedCommon.SessionKeyInjectionReqNormal, 394, new Point(0, 2), _pedData.SessionKeyInjectionReqNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case PedCommandName.SessionKeyInjectionRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(PedCommon.SessionKeyInjectionRspNormal, 394, new Point(0, 2), _pedData.SessionKeyInjectionRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case PedCommandName.MacCalculationReq:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(PedCommon.MacCalculationReqNormal, 394, new Point(0, 2), _pedData.MacCalculationReqNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case PedCommandName.MacCalculationRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(PedCommon.MacCalculationRspNormal, 394, new Point(0, 2), _pedData.MacCalculationRspNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case PedCommandName.GetPedInfoReq:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(PedCommon.GetPedInfoReqNormal, 394, new Point(0, 2), _pedData.GetPedInfoReqNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case PedCommandName.GetPedInfoRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(PedCommon.GetPedInfoRspNormal, 394, new Point(0, 2), _pedData.GetPedInfoRspNormalData);
                    for(int i=6;i<12;i++)
                    {
                        labelAndTextBoxs[i].SetTextBoxHeight(60);
                        labelAndTextBoxs[i].Location = new Point(0, labelAndTextBoxs[6].Location.Y + (i-6) * 62);
                    }
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case PedCommandName.IncreaseKsnReq:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(PedCommon.IncreaseKsnReqNormal, 394, new Point(0, 2), _pedData.IncreaseKsnReqNormalData);
                    ValuePanel.Controls.AddRange(labelAndTextBoxs);
                    break;
                case PedCommandName.IncreaseKsnRsp:
                    labelAndTextBoxs = CreateLabelAndTextBoxs(PedCommon.IncreaseKsnRspNormal, 394, new Point(0, 2), _pedData.IncreaseKsnRspNormalData);
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

        private void LoseOfFocusTextBoxUserControl(object sender, EventArgs e)
        {
            LabelTextBoxUserControl userControl = (LabelTextBoxUserControl)sender;
            switch (_commandName)
            {
                case PedCommandName.SessionKeyInjectionReq:
                    for (int i = 0; i < PedCommon.SessionKeyInjectionReqNormal.Length / 2; i++)
                    {
                        if (userControl.Name == PedCommon.SessionKeyInjectionReqNormal[i, 0] + "UserControl")
                        {
                            _pedData.SessionKeyInjectionReqNormalData[i] = userControl.GetTextBoxValue();
                        }
                    }
                    break;
                case PedCommandName.MacCalculationReq:
                    for (int i = 0; i < PedCommon.MacCalculationReqNormal.Length / 2; i++)
                    {
                        if (userControl.Name == PedCommon.MacCalculationReqNormal[i, 0] + "UserControl")
                        {
                            _pedData.MacCalculationReqNormalData[i] = userControl.GetTextBoxValue();
                        }
                    }
                    break;
                case PedCommandName.GetPedInfoReq:
                    for (int i = 0; i < PedCommon.GetPedInfoReqNormal.Length / 2; i++)
                    {
                        if (userControl.Name == PedCommon.GetPedInfoReqNormal[i, 0] + "UserControl")
                        {
                            _pedData.GetPedInfoReqNormalData[i] = userControl.GetTextBoxValue();
                        }
                    }
                    break;
                case PedCommandName.IncreaseKsnReq:
                    for (int i = 0; i < PedCommon.IncreaseKsnReqNormal.Length / 2; i++)
                    {
                        if (userControl.Name == PedCommon.IncreaseKsnReqNormal[i, 0] + "UserControl")
                        {
                            _pedData.IncreaseKsnReqNormalData[i] = userControl.GetTextBoxValue();
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}

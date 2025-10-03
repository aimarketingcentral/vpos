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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace POSLink2Demo
{
    class Tools
    {
        private Queue<Control> _query;
        public Tools()
        {
            _query = new Queue<Control>();
        }

        private void DS(Control control)
        {
            for (int i = 0; i < control.Controls.Count; i++)
            {
                if (control.Controls[i].HasChildren)
                {
                    DS(control.Controls[i]);
                }
                _query.Enqueue(control.Controls[i]);
            }
        }

        public void DisposeSubControls(Control control)
        {
            DS(control);
            while (_query.Count != 0)
            {
                _query.Dequeue().Dispose();
            }
        }

        public static string ParseTransType(POSLink2.Const.TransType transType)
        {
            string ret = "";
            for(int i=0;i<Global.TransType.Length/2;i++)
            {
                if(transType == (POSLink2.Const.TransType)Global.TransType[i, 1])
                {
                    ret = (string)Global.TransType[i, 0];
                }
            }
            return ret;
        }

        public static POSLink2.Const.TransType ParseTransType(string transType)
        {
            POSLink2.Const.TransType ret = POSLink2.Const.TransType.Empty;
            for (int i = 0; i < Global.TransType.Length / 2; i++)
            {
                if (transType == (string)Global.TransType[i, 0])
                {
                    ret = (POSLink2.Const.TransType)Global.TransType[i, 1];
                }
            }
            return ret;
        }

        public static string ParseEdcType(POSLink2.Const.EdcType edcType)
        {
            string ret = "";
            for (int i = 0; i < Global.EdcType.Length / 2; i++)
            {
                if (edcType == (POSLink2.Const.EdcType)Global.EdcType[i, 1])
                {
                    ret = (string)Global.EdcType[i, 0];
                }
            }
            return ret;
        }

        public static POSLink2.Const.EdcType ParseEdcType(string edcType)
        {
            POSLink2.Const.EdcType ret = POSLink2.Const.EdcType.Empty;
            for (int i = 0; i < Global.EdcType.Length / 2; i++)
            {
                if (edcType == (string)Global.EdcType[i, 0])
                {
                    ret = (POSLink2.Const.EdcType)Global.EdcType[i, 1];
                }
            }
            return ret;
        }

        public static Button CreateButton(string text, Point point, bool isHeightNotEnough)
        {
            Button button = new Button();
            button.Width = 98;
            button.Location = point;
            button.Text = text;
            Size height = button.CreateGraphics().MeasureString(button.Text, button.Font).ToSize();
            if (isHeightNotEnough)
            {
                button.Height = height.Height * 2 + button.Margin.Top * 2 + 2;
            }
            return button;
        }
    }
}

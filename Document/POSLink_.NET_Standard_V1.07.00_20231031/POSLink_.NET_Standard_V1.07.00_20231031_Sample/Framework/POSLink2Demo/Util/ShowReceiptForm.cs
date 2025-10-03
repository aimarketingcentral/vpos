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
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSLink2Demo
{
    public partial class ShowReceiptForm : Form
    {
        public ShowReceiptForm()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            String path;
            path = System.Windows.Forms.Application.StartupPath;

            String outfile = "";
            int typeIndex = 1;
            SaveFileDialog dlg = new SaveFileDialog();
            string filter = "BMP(*.BMP)|*.BMP|ICO(*.ICO)|*.ICO|JPG(*.JPG)|*.JPG|PNG(*.PNG)|*.PNG";
            dlg.Filter = filter;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                outfile = dlg.FileName;
                typeIndex = dlg.FilterIndex;

            }
            else
            {
                return;
            }

            string text = this.RichTextBox_Print.Text;

            Bitmap bmp = TextToBitmap(text, this.RichTextBox_Print.Font, Rectangle.Empty, this.RichTextBox_Print.ForeColor, this.RichTextBox_Print.BackColor);

            if (typeIndex == 1)
            {
                bmp.Save(outfile, ImageFormat.Bmp);
            }
            else if (typeIndex == 2)
            {
                bmp.Save(outfile, ImageFormat.Icon);
            }
            else if (typeIndex == 3)
            {
                bmp.Save(outfile, ImageFormat.Jpeg);
            }
            else if (typeIndex == 4)
            {
                bmp.Save(outfile, ImageFormat.Png);
            }

            this.Close();
        }

        private Bitmap TextToBitmap(string text, Font font, Rectangle rect, Color fontcolor, Color backColor)
        {
            Graphics g;
            Bitmap bmp;
            StringFormat format = new StringFormat(StringFormatFlags.NoClip);
            if (rect == Rectangle.Empty)
            {
                bmp = new Bitmap(1, 1);
                g = Graphics.FromImage(bmp);

                SizeF sizef = g.MeasureString(text, font, PointF.Empty, format);

                int width = (int)(sizef.Width + 1);
                int height = (int)(sizef.Height + 1);
                rect = new Rectangle(0, 0, width, height);
                bmp.Dispose();

                bmp = new Bitmap(width, height);
            }
            else
            {
                bmp = new Bitmap(rect.Width, rect.Height);
            }

            g = Graphics.FromImage(bmp);

            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            g.FillRectangle(new SolidBrush(backColor), rect);
            g.DrawString(text, font, Brushes.Black, rect, format);
            return bmp;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

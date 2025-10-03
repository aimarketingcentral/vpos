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
    public partial class LogSettingForm : Form
    {
        public POSLink2.LogSetting LogSetting { get; set; }
        public LogSettingForm()
        {
            InitializeComponent();
            LogSwitchComboBox.SelectedIndex = 1;
            LogLevelComboBox.SelectedIndex = 1;
            LogSetting = new POSLink2.LogSetting();
        }

        private void SetButton_Click(object sender, EventArgs e)
        {
            POSLink2.LogSetting logSetting = new POSLink2.LogSetting();
            logSetting.FileName = LogFileNameTextBox.Text;
            logSetting.FilePath = LogFilePathTextBox.Text;

            try
            {
                int days = Int32.Parse(LogDaysTextBox.Text);
                if (days < 0)
                {
                    MessageBox.Show("LogDays must be a positive integer!", "Warning");
                    return;
                }
                logSetting.Days = days;
            }
            catch (Exception)
            {
                MessageBox.Show("LogDays must be a positive integer!", "Warning");
                return;
            }

            if (LogSwitchComboBox.Text == "Off")
            {
                logSetting.Enabled = false;
            }
            else
            {
                logSetting.Enabled = true;
            }

            logSetting.Level = LogLevelComboBox.Text == "ERROR" ? POSLink2.LogSetting.LogLevel.Error : POSLink2.LogSetting.LogLevel.Debug;
            LogSetting = logSetting;
            this.DialogResult = DialogResult.OK;
        }

        private void LogSettingForm_Load(object sender, EventArgs e)
        {
            LogFileNameTextBox.Text = LogSetting.FileName;
            LogFilePathTextBox.Text = LogSetting.FilePath;
            LogDaysTextBox.Text = LogSetting.Days.ToString();
            LogSwitchComboBox.Text = LogSetting.Enabled ? "On" : "Off";
            LogLevelComboBox.Text = LogSetting.Level == POSLink2.LogSetting.LogLevel.Error ? "ERROR" : "DEBUG";
        }

        private void BrowserButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderPath = new FolderBrowserDialog();
            if (folderPath.ShowDialog() == DialogResult.OK)
            {
                LogFilePathTextBox.Text = folderPath.SelectedPath;
            }
        }
    }
}

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

namespace POSLinkFullIntegrationDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void InitButton_Click(object sender, EventArgs e)
        {
            string ip = IpTextBox.Text;
            int port;
            bool isPortANumber = Int32.TryParse(PortTextBox.Text, out port);
            if(!isPortANumber)
            {
                MessageBox.Show("Port is not a number.");
                return;
            }
            int timeout;
            bool isTimeoutANumber = Int32.TryParse(TimeoutTextBox.Text, out timeout);
            if (!isTimeoutANumber)
            {
                MessageBox.Show("Timeout is not a number.");
                return;
            }

            POSLinkCore.CommunicationSetting.TcpSetting tcpSetting = new POSLinkCore.CommunicationSetting.TcpSetting();
            tcpSetting.Ip = ip;
            tcpSetting.Port = port;
            tcpSetting.Timeout = timeout;

            POSLinkFullIntegration.POSLinkFull poslinkFull = POSLinkFullIntegration.POSLinkFull.GetPOSLinkFull();
            POSLinkFullIntegration.Terminal terminal = poslinkFull.GetTerminal(tcpSetting);
            if(terminal == null)
            {
                MessageBox.Show("Get terminal failed, please check poslink log.");
                return;
            }

            POSLinkAdmin.Manage.InitResponse response;
            POSLinkAdmin.ExecutionResult result = terminal.Manage.Init(out response);
            if(result.GetErrorCode() == POSLinkAdmin.ExecutionResult.Code.Ok)
            {
                MessageBox.Show("Response code: " + response.ResponseCode + "\r\nResponse Message: " + response.ResponseMessage);
            }
            else
            {
                MessageBox.Show("Error: " + result.GetErrorCode());
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }
    }
}

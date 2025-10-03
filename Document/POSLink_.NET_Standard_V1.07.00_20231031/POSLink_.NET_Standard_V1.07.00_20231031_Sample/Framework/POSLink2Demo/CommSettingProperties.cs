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

namespace POSLink2Demo
{
    class CommSettingProperties
    {
        public string CommSetting { get; set; }

        public string Ip { get; set; }

        public int Port { get; set; }

        public string SerialPort { get; set; }

        public int BaudRate { get; set; }

        public int Timeout { get; set; }

        public CommSettingProperties()
        {

        }
    }
}

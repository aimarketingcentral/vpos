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
    public class TerminalData
    {
        public List<MultipleCommandsModule> MultipleCommands { get; set; }

        private static TerminalData _terminalData;
        private TerminalData()
        {
            MultipleCommands = new List<MultipleCommandsModule>();
        }

        public static TerminalData GetTerminalData()
        {
            if(_terminalData == null)
            {
                _terminalData = new TerminalData();
            }
            return _terminalData;
        }

        public void Clear()
        {
            MultipleCommands = new List<MultipleCommandsModule>();
        }

        public void ResponseClear()
        {
            for(int i=0;i< MultipleCommands.Count;i++)
            {
                MultipleCommands[i].CommandRspObject = null;
            }
        }
    }
}

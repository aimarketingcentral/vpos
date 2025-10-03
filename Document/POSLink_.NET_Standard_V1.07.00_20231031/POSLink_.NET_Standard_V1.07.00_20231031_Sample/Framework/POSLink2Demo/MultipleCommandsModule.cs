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
    public class MultipleCommandsModule
    {
        private CommandName _commandName;
        public CommandName CommandName
        {
            get { return _commandName; }
            set { _commandName = value; }
        }

        private object _commandReqObject;
        public object CommandReqObject
        {
            get { return _commandReqObject; }
            set { _commandReqObject = value; }
        }

        private object _commandRspObject;
        public object CommandRspObject
        {
            get { return _commandRspObject; }
            set { _commandRspObject = value; }
        }

        public MultipleCommandsModule()
        {
            _commandReqObject = null;
            _commandRspObject = null;
        }
    }
}

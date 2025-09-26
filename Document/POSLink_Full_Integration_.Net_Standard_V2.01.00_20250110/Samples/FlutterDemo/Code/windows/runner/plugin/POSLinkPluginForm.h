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
#pragma once
#include <tchar.h>
#include <windows.h>
#include <iostream>
#include <atlbase.h>
#include <atlstr.h>
#include <map>
#include "..\poslinkcore.tlh"
#include "..\poslinkadmin.tlh"
#include "..\poslinkadmin.tlh"
#include "..\pigeon\POSLinkForm.h"
#include "..\poslink_single.h"
#include "Tools.h"
#include "POSLinkForm\PluginClearMessageRequest.h"
#include "POSLinkForm\PluginInputTextRequest.h"
#include "POSLinkForm\PluginRemoveCardRequest.h"
#include "POSLinkForm\PluginShowDialogFormRequest.h"
#include "POSLinkForm\PluginShowDialogRequest.h"
#include "POSLinkForm\PluginShowItemRequest.h"
#include "POSLinkForm\PluginShowMessageCenterRequest.h"
#include "POSLinkForm\PluginShowMessageRequest.h"
#include "POSLinkForm\PluginShowTextBoxRequest.h"
#include "POSLinkForm\PluginClearMessageResponse.h"
#include "POSLinkForm\PluginInputTextResponse.h"
#include "POSLinkForm\PluginRemoveCardResponse.h"
#include "POSLinkForm\PluginShowDialogFormResponse.h"
#include "POSLinkForm\PluginShowDialogResponse.h"
#include "POSLinkForm\PluginShowItemResponse.h"
#include "POSLinkForm\PluginShowMessageCenterResponse.h"
#include "POSLinkForm\PluginShowMessageResponse.h"
#include "POSLinkForm\PluginShowTextBoxResponse.h"

namespace POSLinkForm {

    class POSLinkPluginForm: public POSLinkFormApi
    {
        public:
            POSLinkPluginForm();
            void ClearMessage(const FormClearMessageRequest& req, std::function<void(ErrorOr<FormClearMessageResponse> reply)> result);
            void InputText(const FormInputTextRequest& req, std::function<void(ErrorOr<FormInputTextResponse> reply)> result);
            void RemoveCard(const FormRemoveCardRequest& req, std::function<void(ErrorOr<FormRemoveCardResponse> reply)> result);
            void ShowDialogForm(const FormShowDialogFormRequest& req, std::function<void(ErrorOr<FormShowDialogFormResponse> reply)> result);
            void ShowDialog(const FormShowDialogRequest& req, std::function<void(ErrorOr<FormShowDialogResponse> reply)> result);
            void ShowItem(const FormShowItemRequest& req, std::function<void(ErrorOr<FormShowItemResponse> reply)> result);
            void ShowMessageCenter(const FormShowMessageCenterRequest& req, std::function<void(ErrorOr<FormShowMessageCenterResponse> reply)> result);
            void ShowMessage(const FormShowMessageRequest& req, std::function<void(ErrorOr<FormShowMessageResponse> reply)> result);
            void ShowTextBox(const FormShowTextBoxRequest& req, std::function<void(ErrorOr<FormShowTextBoxResponse> reply)> result);
    };
}

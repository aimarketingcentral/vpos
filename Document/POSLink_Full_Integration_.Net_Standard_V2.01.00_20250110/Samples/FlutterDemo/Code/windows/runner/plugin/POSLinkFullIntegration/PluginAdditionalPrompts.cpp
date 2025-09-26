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
#undef _HAS_EXCEPTIONS
#include "PluginAdditionalPrompts.h"

namespace POSLinkFullIntegration{
    PluginAdditionalPrompts::PluginAdditionalPrompts(){}

    _AdditionalPrompts* PluginAdditionalPrompts::set(const std::optional<FullIntegrationAdditionalPrompts>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidAdditionalPrompts;
        CLSIDFromProgID(OLESTR("POSLinkFullIntegration.FullIntegration.AdditionalPrompts"),&clsidAdditionalPrompts);
        request = NULL;
        request.CoCreateInstance(clsidAdditionalPrompts);

        request->put_ExpiryDatePrompt((Prompt)*req->expiry_date_prompt());

        request->put_CvvPrompt((Prompt)*req->cvv_prompt());

        request->put_ZipCodePrompt((Prompt)*req->zip_code_prompt());

        return request;
    }

    const FullIntegrationAdditionalPrompts* PluginAdditionalPrompts::get(_AdditionalPrompts* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = FullIntegrationAdditionalPrompts();

        Prompt expiryDatePrompt;
        rsp->get_ExpiryDatePrompt(&expiryDatePrompt);
        response->set_expiry_date_prompt((FullIntegrationPrompt)expiryDatePrompt);

        Prompt cvvPrompt;
        rsp->get_CvvPrompt(&cvvPrompt);
        response->set_cvv_prompt((FullIntegrationPrompt)cvvPrompt);

        Prompt zipCodePrompt;
        rsp->get_ZipCodePrompt(&zipCodePrompt);
        response->set_zip_code_prompt((FullIntegrationPrompt)zipCodePrompt);

        return &(*response);
    }
}
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
#include "PluginGoogleServiceTypeBitmap.h"

namespace POSLinkManage{
    PluginGoogleServiceTypeBitmap::PluginGoogleServiceTypeBitmap(){}

    _GoogleServiceTypeBitmap* PluginGoogleServiceTypeBitmap::set(const std::optional<ManageGoogleServiceTypeBitmap>& req)
    {
        if(!req.has_value())
        {
            return NULL;
        }
        CLSID clsidGoogleServiceTypeBitmap;
        CLSIDFromProgID(OLESTR("POSLinkAdmin.Manage.GoogleServiceTypeBitmap"),&clsidGoogleServiceTypeBitmap);
        request = NULL;
        request.CoCreateInstance(clsidGoogleServiceTypeBitmap);

        request->put_AllServices(*req->all_services());

        request->put_AllServicesExceptPpse(*req->all_services_except_ppse());

        request->put_Ppse(*req->ppse());

        request->put_Loyalty(*req->loyalty());

        request->put_Offer(*req->offer());

        request->put_GiftCard1(*req->gift_card1());

        request->put_PrivateLabelCard(*req->private_label_card());

        request->put_CloudBasedWallet(*req->cloud_based_wallet());

        request->put_MobileMarketingPlatform(*req->mobile_marketing_platform());

        request->put_WalletCustomer(*req->wallet_customer());

        return request;
    }

    const ManageGoogleServiceTypeBitmap* PluginGoogleServiceTypeBitmap::get(_GoogleServiceTypeBitmap* rsp)
    {
        if(rsp == NULL)
        {
            return nullptr;
        }
        response = ManageGoogleServiceTypeBitmap();

        VARIANT_BOOL allServices;
        rsp->get_AllServices(&allServices);
        response->set_all_services(allServices);

        VARIANT_BOOL allServicesExceptPpse;
        rsp->get_AllServicesExceptPpse(&allServicesExceptPpse);
        response->set_all_services_except_ppse(allServicesExceptPpse);

        VARIANT_BOOL ppse;
        rsp->get_Ppse(&ppse);
        response->set_ppse(ppse);

        VARIANT_BOOL loyalty;
        rsp->get_Loyalty(&loyalty);
        response->set_loyalty(loyalty);

        VARIANT_BOOL offer;
        rsp->get_Offer(&offer);
        response->set_offer(offer);

        VARIANT_BOOL giftCard1;
        rsp->get_GiftCard1(&giftCard1);
        response->set_gift_card1(giftCard1);

        VARIANT_BOOL privateLabelCard;
        rsp->get_PrivateLabelCard(&privateLabelCard);
        response->set_private_label_card(privateLabelCard);

        VARIANT_BOOL cloudBasedWallet;
        rsp->get_CloudBasedWallet(&cloudBasedWallet);
        response->set_cloud_based_wallet(cloudBasedWallet);

        VARIANT_BOOL mobileMarketingPlatform;
        rsp->get_MobileMarketingPlatform(&mobileMarketingPlatform);
        response->set_mobile_marketing_platform(mobileMarketingPlatform);

        VARIANT_BOOL walletCustomer;
        rsp->get_WalletCustomer(&walletCustomer);
        response->set_wallet_customer(walletCustomer);

        return &(*response);
    }
}
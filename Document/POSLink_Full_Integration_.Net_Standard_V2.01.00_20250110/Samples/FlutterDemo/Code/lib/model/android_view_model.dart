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

import 'package:flutter/material.dart';

import '../auto_pigeon/poslink_android.dart';
import 'comm_setting_view_model.dart';

class AndroidViewModel extends ChangeNotifier {
  String request = "[02]A00[1c]1.59[03]M";
  String response = "";

  Future sendRawCommand(CommSettingViewModel commSettingViewModel) async {
    await commSettingViewModel.setSetting();

    bool handshakeSuccess = await commSettingViewModel.handshake();
    if(!handshakeSuccess) {
      response = "Init Error";
    }
    response = "";
    notifyListeners();
    RawResponse? rawResponse = await POSLinkAndroidApi().sendRawCommand(request);
    if(rawResponse != null) {
      if(rawResponse.isSuccess ?? false) {
        response = rawResponse.response ?? "";
      }  else {
        response = rawResponse.message ?? "Error Response";
      }
    } else {
      response = "No Response";
    }
    notifyListeners();
  }
}

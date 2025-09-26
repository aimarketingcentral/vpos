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
import 'package:poslink2/auto_data_source/auto_data_source_common.dart';
import 'package:poslink2/auto_data_source/auto_payload_request_data_source.dart';
import 'package:poslink2/auto_data_source/auto_payload_response_data_source.dart';
import 'package:poslink2/auto_pigeon/poslink_sdk_payload.dart';
import 'package:poslink2/model/response_db.dart';
import 'comm_setting_view_model.dart';
import 'multicommand_view_model.dart';

class PayloadViewModel extends ChangeNotifier {
  Future startPayload(CommSettingViewModel commSettingViewModel,
      ResponseDataBase responseDataBase, List<Map> dataSource,
      {bool isMutiCommand = false,
      MutiCommandViewModel? mutiCommandViewModel}) async {
    POSLinkPayloadApi PayloadApi = POSLinkPayloadApi();

    /// setting
    await commSettingViewModel.setSetting();

    bool handshakeSuccess = await commSettingViewModel.handshake();
    if (!handshakeSuccess) {
      throw HandshakeException();
    }

    /// command
    Map cmdData = dataSource.first;
    switch (cmdData[kValue]) {
      case PayloadCommand.PayloadRequest:
        PayloadPayloadRequest req =
            PayloadReqData.formPayloadRequest(dataSource);
        PayloadPayloadResponse rsp = await PayloadApi.payload(req);
        if (isMutiCommand == false) {
          PayloadRspData.parseRspPayloadPayloadResponse(
              rsp, responseDataBase.payloadData);
        } else {
          if (mutiCommandViewModel!.isDoingMutiCommand == true) {
            List<Map> data = PayloadRspData.payloadData();
            PayloadRspData.parseRspPayloadPayloadResponse(rsp, data);
            mutiCommandViewModel.addRsp('Payload', 'PayloadRsp', data);
          }
        }
        break;
      default:
        throw Exception('undefined function');
      //break;
    }
  }
}

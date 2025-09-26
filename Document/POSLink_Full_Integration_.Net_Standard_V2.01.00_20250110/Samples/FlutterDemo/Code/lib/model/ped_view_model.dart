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
import 'package:poslink2/auto_data_source/auto_ped_request_data_source.dart';
import 'package:poslink2/auto_data_source/auto_ped_response_data_source.dart';
import 'package:poslink2/auto_pigeon/poslink_sdk_ped.dart';
import 'package:poslink2/model/response_db.dart';
import 'comm_setting_view_model.dart';
import 'multicommand_view_model.dart';

class PedViewModel extends ChangeNotifier {
  Future startPed(CommSettingViewModel commSettingViewModel,
      ResponseDataBase responseDataBase, List<Map> dataSource,
      {bool isMutiCommand = false,
      MutiCommandViewModel? mutiCommandViewModel}) async {
    POSLinkPedApi PedApi = POSLinkPedApi();

    if (isMutiCommand == false) {
      /// setting
      await commSettingViewModel.setSetting();

      bool handshakeSuccess = await commSettingViewModel.handshake();
      if (!handshakeSuccess) {
        throw HandshakeException();
      }
    }

    /// command
    Map cmdData = dataSource.first;
    switch (cmdData[kValue]) {
      case PedCommand.SessionKeyInjectionRequest:
        PedSessionKeyInjectionRequest req =
            PedReqData.formSessionKeyInjectionRequest(dataSource);
        PedSessionKeyInjectionResponse rsp =
            await PedApi.sessionKeyInjection(req);
        if (isMutiCommand == false) {
          PedRspData.parseRspPedSessionKeyInjectionResponse(
              rsp, responseDataBase.pedData);
        } else {
          if (mutiCommandViewModel!.isDoingMutiCommand == true) {
            List<Map> data = PedRspData.sessionKeyInjectionData();
            PedRspData.parseRspPedSessionKeyInjectionResponse(rsp, data);
            mutiCommandViewModel.addRsp('Ped', 'SessionKeyInjectionRsp', data);
          }
        }
        break;
      case PedCommand.IncreaseKsnRequest:
        PedIncreaseKsnRequest req =
            PedReqData.formIncreaseKsnRequest(dataSource);
        PedIncreaseKsnResponse rsp = await PedApi.increaseKsn(req);
        if (isMutiCommand == false) {
          PedRspData.parseRspPedIncreaseKsnResponse(
              rsp, responseDataBase.pedData);
        } else {
          if (mutiCommandViewModel!.isDoingMutiCommand == true) {
            List<Map> data = PedRspData.increaseKsnData();
            PedRspData.parseRspPedIncreaseKsnResponse(rsp, data);
            mutiCommandViewModel.addRsp('Ped', 'IncreaseKsnRsp', data);
          }
        }
        break;
      case PedCommand.GetPedInformationRequest:
        PedGetPedInformationRequest req =
            PedReqData.formGetPedInformationRequest(dataSource);
        PedGetPedInformationResponse rsp = await PedApi.getPedInformation(req);
        if (isMutiCommand == false) {
          PedRspData.parseRspPedGetPedInformationResponse(
              rsp, responseDataBase.pedData);
        } else {
          if (mutiCommandViewModel!.isDoingMutiCommand == true) {
            List<Map> data = PedRspData.getPedInformationData();
            PedRspData.parseRspPedGetPedInformationResponse(rsp, data);
            mutiCommandViewModel.addRsp('Ped', 'GetPedInformationRsp', data);
          }
        }
        break;
      case PedCommand.MacCalculationRequest:
        PedMacCalculationRequest req =
            PedReqData.formMacCalculationRequest(dataSource);
        PedMacCalculationResponse rsp = await PedApi.macCalculation(req);
        if (isMutiCommand == false) {
          PedRspData.parseRspPedMacCalculationResponse(
              rsp, responseDataBase.pedData);
        } else {
          if (mutiCommandViewModel!.isDoingMutiCommand == true) {
            List<Map> data = PedRspData.macCalculationData();
            PedRspData.parseRspPedMacCalculationResponse(rsp, data);
            mutiCommandViewModel.addRsp('Ped', 'MacCalculationRsp', data);
          }
        }
        break;
      default:
        throw Exception('undefined function');
      //break;
    }
  }
}

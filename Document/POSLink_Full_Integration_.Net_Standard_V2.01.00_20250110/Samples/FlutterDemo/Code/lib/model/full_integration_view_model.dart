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
import 'package:poslink2/auto_data_source/auto_fullintegration_request_data_source.dart';
import 'package:poslink2/auto_pigeon/poslink_sdk_fullintegration.dart';
import 'package:poslink2/model/multicommand_view_model.dart';
import 'package:poslink2/model/response_db.dart';

import '../auto_data_source/auto_fullintegration_response_data_source.dart';
import 'comm_setting_view_model.dart';

class FullIntegrationViewModel extends ChangeNotifier {
  Future start(CommSettingViewModel commSettingViewModel,
      ResponseDataBase responseDataBase, List<Map> dataSource,
      {bool isMutiCommand = false,
      MutiCommandViewModel? mutiCommandViewModel}) async {
    POSLinkFullIntegrationApi fullIntegrationApi = POSLinkFullIntegrationApi();

    /// setting
    if (isMutiCommand == false) {
      await commSettingViewModel.setSetting();
      bool handshakeSuccess = await commSettingViewModel.handshake();
      if (!handshakeSuccess) {
        throw HandshakeException();
      }
    }

    /// command
    Map cmdData = dataSource.first;
    switch (cmdData[kValue]) {
      case FullIntegrationCommand.AuthorizeCardRequest:
        FullIntegrationAuthorizeCardRequest req =
            FullIntegrationReqData.formAuthorizeCardRequest(dataSource);
        FullIntegrationAuthorizeCardResponse rsp =
            await fullIntegrationApi.authorizeCard(req);
        if (isMutiCommand == false) {
          FullIntegrationRspData.parseRspFullIntegrationAuthorizeCardResponse(
              rsp, responseDataBase.fullIntegrationData);
        } else {
          if (mutiCommandViewModel!.isDoingMutiCommand == true) {
            List<Map> data = FullIntegrationRspData.authorizeCardData();
            FullIntegrationRspData.parseRspFullIntegrationAuthorizeCardResponse(
                rsp, data);
            mutiCommandViewModel.addRsp(
                'FullIntegration', 'AuthorizeCardRsp', data);
          }
        }

        break;
      case FullIntegrationCommand.InputAccountWithEmvRequest:
        FullIntegrationInputAccountWithEmvRequest req =
            FullIntegrationReqData.formInputAccountWithEmvRequest(dataSource);
        FullIntegrationInputAccountWithEmvResponse rsp =
            await fullIntegrationApi.inputAccountWithEmv(req);

        if (isMutiCommand == false) {
          FullIntegrationRspData
              .parseRspFullIntegrationInputAccountWithEmvResponse(
                  rsp, responseDataBase.fullIntegrationData);
        } else {
          if (mutiCommandViewModel!.isDoingMutiCommand == true) {
            List<Map> data = FullIntegrationRspData.inputAccountWithEmvData();
            FullIntegrationRspData
                .parseRspFullIntegrationInputAccountWithEmvResponse(rsp, data);
            mutiCommandViewModel.addRsp(
                'FullIntegration', 'InputAccountWithEmvRsp', data);
          }
        }
        break;
      case FullIntegrationCommand.CompleteOnlineEmvRequest:
        FullIntegrationCompleteOnlineEmvRequest req =
            FullIntegrationReqData.formCompleteOnlineEmvRequest(dataSource);
        FullIntegrationCompleteOnlineEmvResponse rsp =
            await fullIntegrationApi.completeOnlineEmv(req);

        if (isMutiCommand == false) {
          FullIntegrationRspData
              .parseRspFullIntegrationCompleteOnlineEmvResponse(
                  rsp, responseDataBase.fullIntegrationData);
        } else {
          if (mutiCommandViewModel!.isDoingMutiCommand == true) {
            List<Map> data = FullIntegrationRspData.completeOnlineEmvData();
            FullIntegrationRspData
                .parseRspFullIntegrationCompleteOnlineEmvResponse(rsp, data);
            mutiCommandViewModel.addRsp(
                'FullIntegration', 'CompleteOnlineEmvRsp', data);
          }
        }
        break;
      case FullIntegrationCommand.GetEmvTlvDataRequest:
        FullIntegrationGetEmvTlvDataRequest req =
            FullIntegrationReqData.formGetEmvTlvDataRequest(dataSource);
        FullIntegrationGetEmvTlvDataResponse rsp =
            await fullIntegrationApi.getEmvTlvData(req);

        if (isMutiCommand == false) {
          FullIntegrationRspData.parseRspFullIntegrationGetEmvTlvDataResponse(
              rsp, responseDataBase.fullIntegrationData);
        } else {
          if (mutiCommandViewModel!.isDoingMutiCommand == true) {
            List<Map> data = FullIntegrationRspData.getEmvTlvDataData();
            FullIntegrationRspData.parseRspFullIntegrationGetEmvTlvDataResponse(
                rsp, data);
            mutiCommandViewModel.addRsp(
                'FullIntegration', 'GetEmvTlvDataRsp', data);
          }
        }
        break;
      case FullIntegrationCommand.GetPinBlockRequest:
        FullIntegrationGetPinBlockRequest req =
            FullIntegrationReqData.formGetPinBlockRequest(dataSource);
        FullIntegrationGetPinBlockResponse rsp =
            await fullIntegrationApi.getPinBlock(req);

        if (isMutiCommand == false) {
          FullIntegrationRspData.parseRspFullIntegrationGetPinBlockResponse(
              rsp, responseDataBase.fullIntegrationData);
        } else {
          if (mutiCommandViewModel!.isDoingMutiCommand == true) {
            List<Map> data = FullIntegrationRspData.getPinBlockData();
            FullIntegrationRspData.parseRspFullIntegrationGetPinBlockResponse(
                rsp, data);
            mutiCommandViewModel.addRsp(
                'FullIntegration', 'GetPinBlockRsp', data);
          }
        }
        break;
      case FullIntegrationCommand.SetEmvTlvDataRequest:
        FullIntegrationSetEmvTlvDataRequest req =
            FullIntegrationReqData.formSetEmvTlvDataRequest(dataSource);
        FullIntegrationSetEmvTlvDataResponse rsp =
            await fullIntegrationApi.setEmvTlvData(req);

        if (isMutiCommand == false) {
          FullIntegrationRspData.parseRspFullIntegrationSetEmvTlvDataResponse(
              rsp, responseDataBase.fullIntegrationData);
        } else {
          if (mutiCommandViewModel!.isDoingMutiCommand == true) {
            List<Map> data = FullIntegrationRspData.setEmvTlvDataData();
            FullIntegrationRspData.parseRspFullIntegrationSetEmvTlvDataResponse(
                rsp, data);
            mutiCommandViewModel.addRsp(
                'FullIntegration', 'SetEmvTlvDataRsp', data);
          }
        }
        break;
      default:
        throw Exception('undefined function');
      //break;
    }
  }
}

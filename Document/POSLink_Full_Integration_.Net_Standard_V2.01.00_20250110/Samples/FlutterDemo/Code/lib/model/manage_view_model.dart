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
import 'package:poslink2/auto_data_source/auto_manage_request_data_source.dart';
import 'package:poslink2/auto_data_source/auto_manage_response_data_source.dart';
import 'package:poslink2/auto_pigeon/poslink_sdk_manage.dart';
import 'package:poslink2/log/dart_log.dart';
import 'package:poslink2/model/response_db.dart';
import 'comm_setting_view_model.dart';
import 'multicommand_view_model.dart';

class ManageViewModel extends ChangeNotifier {
  Future startManage(CommSettingViewModel commSettingViewModel,
      ResponseDataBase responseDataBase, List<Map> dataSource,
      {bool isMutiCommand = false,
      MutiCommandViewModel? mutiCommandViewModel}) async {
    POSLinkManageApi ManageApi = POSLinkManageApi();

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
      case ManageCommand.DeleteImageRequest:
        ManageDeleteImageRequest req =
            ManageReqData.formDeleteImageRequest(dataSource);
        ManageDeleteImageResponse rsp = await ManageApi.deleteImage(req);

        if (isMutiCommand == false) {
          ManageRspData.parseRspManageDeleteImageResponse(
              rsp, responseDataBase.manageData);
        } else {
          if (mutiCommandViewModel!.isDoingMutiCommand == true) {
            List<Map> data = ManageRspData.deleteImageData();
            ManageRspData.parseRspManageDeleteImageResponse(rsp, data);
            mutiCommandViewModel.addRsp('Manage', 'DeleteImageRsp', data);
          }
        }
        break;
      case ManageCommand.ClearCardBufferRequest:
        ManageClearCardBufferRequest req =
            ManageReqData.formClearCardBufferRequest(dataSource);
        ManageClearCardBufferResponse rsp = await ManageApi.clearCardBuffer(req);

        if (isMutiCommand == false) {
          ManageRspData.parseRspManageClearCardBufferResponse(
              rsp, responseDataBase.manageData);
        } else {
          if (mutiCommandViewModel!.isDoingMutiCommand == true) {
            List<Map> data = ManageRspData.clearCardBufferData();
            ManageRspData.parseRspManageClearCardBufferResponse(rsp, data);
            mutiCommandViewModel.addRsp('Manage', 'ResetMsrRsp', data);
          }
        }
        break;
      case ManageCommand.DoSignatureRequest:
        ManageDoSignatureRequest req =
            ManageReqData.formDoSignatureRequest(dataSource);
        ManageDoSignatureResponse rsp = await ManageApi.doSignature(req);

        if (isMutiCommand == false) {
          ManageRspData.parseRspManageDoSignatureResponse(
              rsp, responseDataBase.manageData);
        } else {
          if (mutiCommandViewModel!.isDoingMutiCommand == true) {
            List<Map> data = ManageRspData.doSignatureData();
            ManageRspData.parseRspManageDoSignatureResponse(rsp, data);
            mutiCommandViewModel.addRsp('Manage', 'DoSignatureRsp', data);
          }
        }
        break;
      case ManageCommand.RebootRequest:
        ManageRebootRequest req = ManageReqData.formRebootRequest(dataSource);
        ManageRebootResponse rsp = await ManageApi.reboot(req);

        if (isMutiCommand == false) {
          ManageRspData.parseRspManageRebootResponse(
              rsp, responseDataBase.manageData);
        } else {
          if (mutiCommandViewModel!.isDoingMutiCommand == true) {
            List<Map> data = ManageRspData.rebootData();
            ManageRspData.parseRspManageRebootResponse(rsp, data);
            mutiCommandViewModel.addRsp('Manage', 'RebootRsp', data);
          }
        }
        break;
      case ManageCommand.InitRequest:
        ManageInitRequest req = ManageReqData.formInitRequest(dataSource);
        ManageInitResponse rsp = await ManageApi.init(req);

        if (isMutiCommand == false) {
          ManageRspData.parseRspManageInitResponse(
              rsp, responseDataBase.manageData);
          Log.v('message = ${responseDataBase.manageData}');
          responseDataBase.notifyListeners();
        } else {
          if (mutiCommandViewModel!.isDoingMutiCommand == true) {
            List<Map> data = ManageRspData.initData();
            ManageRspData.parseRspManageInitResponse(rsp, data);
            mutiCommandViewModel.addRsp('Manage', 'InitRsp', data);
          }
        }
        break;
      case ManageCommand.CheckFileRequest:
        ManageCheckFileRequest req =
            ManageReqData.formCheckFileRequest(dataSource);
        ManageCheckFileResponse rsp = await ManageApi.checkFile(req);

        if (isMutiCommand == false) {
          ManageRspData.parseRspManageCheckFileResponse(
              rsp, responseDataBase.manageData);
        } else {
          if (mutiCommandViewModel!.isDoingMutiCommand == true) {
            List<Map> data = ManageRspData.checkFileData();
            ManageRspData.parseRspManageCheckFileResponse(rsp, data);
            mutiCommandViewModel.addRsp('Manage', 'CheckFileRsp', data);
          }
        }
        break;
      case ManageCommand.VasPushDataRequest:
        ManageVasPushDataRequest req =
            ManageReqData.formVasPushDataRequest(dataSource);
        ManageVasPushDataResponse rsp = await ManageApi.vasPushData(req);

        if (isMutiCommand == false) {
          ManageRspData.parseRspManageVasPushDataResponse(
              rsp, responseDataBase.manageData);
        } else {
          if (mutiCommandViewModel!.isDoingMutiCommand == true) {
            List<Map> data = ManageRspData.vasPushDataData();
            ManageRspData.parseRspManageVasPushDataResponse(rsp, data);
            mutiCommandViewModel.addRsp('Manage', 'VasPushDataRsp', data);
          }
        }
        break;
      case ManageCommand.SetApplePayVasParametersRequest:
        ManageSetApplePayVasParametersRequest req =
            ManageReqData.formSetApplePayVasParametersRequest(dataSource);
        ManageSetApplePayVasParametersResponse rsp =
            await ManageApi.setApplePayVasParameters(req);

        if (isMutiCommand == false) {
          ManageRspData.parseRspManageSetApplePayVasParametersResponse(
              rsp, responseDataBase.manageData);
        } else {
          if (mutiCommandViewModel!.isDoingMutiCommand == true) {
            List<Map> data = ManageRspData.setApplePayVasParametersData();
            ManageRspData.parseRspManageSetApplePayVasParametersResponse(
                rsp, data);
            mutiCommandViewModel.addRsp(
                'Manage', 'VasSetMerchantParametersRsp', data);
          }
        }
        break;
      case ManageCommand.SetGoogleSmartTapParametersRequest:
        ManageSetGoogleSmartTapParametersRequest req =
            ManageReqData.formSetGoogleSmartTapParametersRequest(dataSource);
        ManageSetGoogleSmartTapParametersResponse rsp =
            await ManageApi.setGoogleSmartTapParameters(req);

        if (isMutiCommand == false) {
          ManageRspData.parseRspManageSetGoogleSmartTapParametersResponse(
              rsp, responseDataBase.manageData);
        } else {
          if (mutiCommandViewModel!.isDoingMutiCommand == true) {
            List<Map> data = ManageRspData.setGoogleSmartTapParametersData();
            ManageRspData.parseRspManageSetGoogleSmartTapParametersResponse(
                rsp, data);
            mutiCommandViewModel.addRsp('Manage', 'VasSetMerchantParametersRsp', data);
          }
        }
        break;
      case ManageCommand.ResetScreenRequest:
        ManageResetScreenRequest req = ManageReqData.formResetScreenRequest(dataSource);
        ManageResetScreenResponse rsp = await ManageApi.resetScreen(req);

        if (isMutiCommand == false) {
          ManageRspData.parseRspManageResetScreenResponse(
              rsp, responseDataBase.manageData);
        } else {
          if (mutiCommandViewModel!.isDoingMutiCommand == true) {
            List<Map> data = ManageRspData.resetScreenData();
            ManageRspData.parseRspManageResetScreenResponse(rsp, data);
            mutiCommandViewModel.addRsp('Manage', 'ResetScreenRsp', data);
          }
        }
        break;
      case ManageCommand.GetSignatureRequest:
        ManageGetSignatureRequest req =
            ManageReqData.formGetSignatureRequest(dataSource);
        ManageGetSignatureResponse rsp = await ManageApi.getSignature(req);

        if (isMutiCommand == false) {
          ManageRspData.parseRspManageGetSignatureResponse(
              rsp, responseDataBase.manageData);
        } else {
          if (mutiCommandViewModel!.isDoingMutiCommand == true) {
            List<Map> data = ManageRspData.getSignatureData();
            ManageRspData.parseRspManageGetSignatureResponse(rsp, data);
            mutiCommandViewModel.addRsp('Manage', 'GetSignatureRsp', data);
          }
        }
        break;
      case ManageCommand.UpdateResourceFileRequest:
        ManageUpdateResourceFileRequest req =
            ManageReqData.formUpdateResourceFileRequest(dataSource);
        ManageUpdateResourceFileResponse rsp =
            await ManageApi.updateResourceFile(req);

        if (isMutiCommand == false) {
          ManageRspData.parseRspManageUpdateResourceFileResponse(
              rsp, responseDataBase.manageData);
        } else {
          if (mutiCommandViewModel!.isDoingMutiCommand == true) {
            List<Map> data = ManageRspData.updateResourceFileData();
            ManageRspData.parseRspManageUpdateResourceFileResponse(rsp, data);
            mutiCommandViewModel.addRsp(
                'Manage', 'UpdateResourceFileRsp', data);
          }
        }
        break;
      case ManageCommand.SetVariableRequest:
        ManageSetVariableRequest req =
            ManageReqData.formSetVariableRequest(dataSource);
        ManageSetVariableResponse rsp = await ManageApi.setVariable(req);

        if (isMutiCommand == false) {
          ManageRspData.parseRspManageSetVariableResponse(
              rsp, responseDataBase.manageData);
        } else {
          if (mutiCommandViewModel!.isDoingMutiCommand == true) {
            List<Map> data = ManageRspData.setVariableData();
            ManageRspData.parseRspManageSetVariableResponse(rsp, data);
            mutiCommandViewModel.addRsp('Manage', 'SetVariableRsp', data);
          }
        }
        break;
      case ManageCommand.GetVariableRequest:
        ManageGetVariableRequest req =
            ManageReqData.formGetVariableRequest(dataSource);
        ManageGetVariableResponse rsp = await ManageApi.getVariable(req);

        if (isMutiCommand == false) {
          ManageRspData.parseRspManageGetVariableResponse(
              rsp, responseDataBase.manageData);
        } else {
          if (mutiCommandViewModel!.isDoingMutiCommand == true) {
            List<Map> data = ManageRspData.getVariableData();
            ManageRspData.parseRspManageGetVariableResponse(rsp, data);
            mutiCommandViewModel.addRsp('Manage', 'GetVariableRsp', data);
          }
        }
        break;

      default:
        throw Exception('undefined function');
      //break;
    }
  }
}

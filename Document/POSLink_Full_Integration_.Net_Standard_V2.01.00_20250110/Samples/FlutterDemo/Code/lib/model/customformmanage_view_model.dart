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
import 'package:poslink2/auto_data_source/auto_customformmanage_request_data_source.dart';
import 'package:poslink2/auto_data_source/auto_customformmanage_response_data_source.dart';
import 'package:poslink2/auto_data_source/auto_data_source_common.dart';
import 'package:poslink2/auto_pigeon/poslink_sdk_customformmanage.dart';
import 'package:poslink2/model/response_db.dart';
import 'comm_setting_view_model.dart';
import 'multicommand_view_model.dart';

class CustomFormManageModel extends ChangeNotifier {
  Future startDevice(CommSettingViewModel commSettingViewModel,
      ResponseDataBase responseDataBase, List<Map> dataSource,
      {bool isMutiCommand = false,
      MutiCommandViewModel? mutiCommandViewModel}) async {
    POSLinkCustomFormManageApi customFormManageApi =
        POSLinkCustomFormManageApi();

    /// setting
    await commSettingViewModel.setSetting();

    bool handshakeSuccess = await commSettingViewModel.handshake();
    if (!handshakeSuccess) {
      throw HandshakeException();
    }

    /// command
    Map cmdData = dataSource.first;
    switch (cmdData[kValue]) {
      case CustomFormManageCommand.SetVarListRequest:
        CustomFormManageSetVarListRequest req =
            CustomFormManageReqData.formSetVarListRequest(dataSource);
        CustomFormManageSetVarListResponse rsp =
            await customFormManageApi.setVarList(req);
        if (isMutiCommand == false) {
          CustomFormManageRspData.parseRspCustomFormManageSetVarListResponse(
              rsp, responseDataBase.customformmanageData);
        } else {
          if (mutiCommandViewModel!.isDoingMutiCommand == true) {
            List<Map> data = CustomFormManageRspData.setVarListData();
            CustomFormManageRspData.parseRspCustomFormManageSetVarListResponse(
                rsp, data);
            mutiCommandViewModel.addRsp(
                'CustomFormManage', 'SetVarListRsp', data);
          }
        }
        break;
      case CustomFormManageCommand.GetVarListRequest:
        CustomFormManageGetVarListRequest req =
            CustomFormManageReqData.formGetVarListRequest(dataSource);
        CustomFormManageGetVarListResponse rsp =
            await customFormManageApi.getVarList(req);
        if (isMutiCommand == false) {
          CustomFormManageRspData.parseRspCustomFormManageGetVarListResponse(
              rsp, responseDataBase.customformmanageData);
        } else {
          if (mutiCommandViewModel!.isDoingMutiCommand == true) {
            List<Map> data = CustomFormManageRspData.getVarListData();
            CustomFormManageRspData.parseRspCustomFormManageGetVarListResponse(
                rsp, data);
            mutiCommandViewModel.addRsp(
                'CustomFormManage', 'GetVarListRsp', data);
          }
        }
        break;
      case CustomFormManageCommand.GetFormListRequest:
        CustomFormManageGetFormListRequest req =
            CustomFormManageReqData.formGetFormListRequest(dataSource);
        CustomFormManageGetFormListResponse rsp =
            await customFormManageApi.getFormList(req);
        if (isMutiCommand == false) {
          CustomFormManageRspData.parseRspCustomFormManageGetFormListResponse(
              rsp, responseDataBase.customformmanageData);
        } else {
          if (mutiCommandViewModel!.isDoingMutiCommand == true) {
            List<Map> data = CustomFormManageRspData.getFormListData();
            CustomFormManageRspData.parseRspCustomFormManageGetFormListResponse(
                rsp, data);
            mutiCommandViewModel.addRsp(
                'CustomFormManage', 'GetFormListRsp', data);
          }
        }
        break;
      case CustomFormManageCommand.RunFormRequest:
        CustomFormManageRunFormRequest req =
            CustomFormManageReqData.formRunFormRequest(dataSource);
        CustomFormManageRunFormResponse rsp =
            await customFormManageApi.runForm(req);
        if (isMutiCommand == false) {
          CustomFormManageRspData.parseRspCustomFormManageRunFormResponse(
              rsp, responseDataBase.customformmanageData);
        } else {
          if (mutiCommandViewModel!.isDoingMutiCommand == true) {
            List<Map> data = CustomFormManageRspData.runFormData();
            CustomFormManageRspData.parseRspCustomFormManageRunFormResponse(
                rsp, data);
            mutiCommandViewModel.addRsp('CustomFormManage', 'RunFormRsp', data);
          }
        }
        break;
      default:
        throw Exception('undefined function');
      //break;
    }
  }
}

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
import 'package:poslink2/auto_data_source/auto_form_request_data_source.dart';
import 'package:poslink2/auto_data_source/auto_form_response_data_source.dart';
import 'package:poslink2/auto_pigeon/poslink_sdk_form.dart';
import 'package:poslink2/model/response_db.dart';
import 'comm_setting_view_model.dart';
import 'multicommand_view_model.dart';

class FormViewModel extends ChangeNotifier {
  Future startForm(CommSettingViewModel commSettingViewModel,
      ResponseDataBase responseDataBase, List<Map> dataSource,
      {bool isMutiCommand = false,
      MutiCommandViewModel? mutiCommandViewModel}) async {
    POSLinkFormApi FormApi = POSLinkFormApi();

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
      case FormCommand.ShowDialogRequest:
        FormShowDialogRequest req =
            FormReqData.formShowDialogRequest(dataSource);
        FormShowDialogResponse rsp = await FormApi.showDialog(req);

        if (isMutiCommand == false) {
          FormRspData.parseRspFormShowDialogResponse(
              rsp, responseDataBase.formData);
        } else {
          if (mutiCommandViewModel!.isDoingMutiCommand == true) {
            List<Map> data = FormRspData.showDialogData();
            FormRspData.parseRspFormShowDialogResponse(rsp, data);
            mutiCommandViewModel.addRsp('Form', 'ShowDialogRsp', data);
          }
        }
        break;
      case FormCommand.ShowDialogFormRequest:
        FormShowDialogFormRequest req =
            FormReqData.formShowDialogFormRequest(dataSource);
        FormShowDialogFormResponse rsp = await FormApi.showDialogForm(req);

        if (isMutiCommand == false) {
          FormRspData.parseRspFormShowDialogFormResponse(
              rsp, responseDataBase.formData);
        } else {
          if (mutiCommandViewModel!.isDoingMutiCommand == true) {
            List<Map> data = FormRspData.showDialogFormData();
            FormRspData.parseRspFormShowDialogFormResponse(rsp, data);
            mutiCommandViewModel.addRsp('Form', 'ShowDialogFormRsp', data);
          }
        }
        break;
      case FormCommand.ShowTextBoxRequest:
        FormShowTextBoxRequest req =
            FormReqData.formShowTextBoxRequest(dataSource);
        FormShowTextBoxResponse rsp = await FormApi.showTextBox(req);

        if (isMutiCommand == false) {
          FormRspData.parseRspFormShowTextBoxResponse(
              rsp, responseDataBase.formData);
        } else {
          if (mutiCommandViewModel!.isDoingMutiCommand == true) {
            List<Map> data = FormRspData.showTextBoxData();
            FormRspData.parseRspFormShowTextBoxResponse(rsp, data);
            mutiCommandViewModel.addRsp('Form', 'ShowTextBoxRsp', data);
          }
        }
        break;
      case FormCommand.ShowMessageCenterRequest:
        FormShowMessageCenterRequest req =
            FormReqData.formShowMessageCenterRequest(dataSource);
        FormShowMessageCenterResponse rsp =
            await FormApi.showMessageCenter(req);

        if (isMutiCommand == false) {
          FormRspData.parseRspFormShowMessageCenterResponse(
              rsp, responseDataBase.formData);
        } else {
          if (mutiCommandViewModel!.isDoingMutiCommand == true) {
            List<Map> data = FormRspData.showMessageCenterData();
            FormRspData.parseRspFormShowMessageCenterResponse(rsp, data);
            mutiCommandViewModel.addRsp('Form', 'ShowMessageCenterRsp', data);
          }
        }
        break;
      case FormCommand.ShowItemRequest:
        FormShowItemRequest req = FormReqData.formShowItemRequest(dataSource);
        FormShowItemResponse rsp = await FormApi.showItem(req);

        if (isMutiCommand == false) {
          FormRspData.parseRspFormShowItemResponse(
              rsp, responseDataBase.formData);
        } else {
          if (mutiCommandViewModel!.isDoingMutiCommand == true) {
            List<Map> data = FormRspData.showItemData();
            FormRspData.parseRspFormShowItemResponse(rsp, data);
            mutiCommandViewModel.addRsp('Form', 'ShowItemRsp', data);
          }
        }
        break;
      case FormCommand.ClearMessageRequest:
        FormClearMessageRequest req =
            FormReqData.formClearMessageRequest(dataSource);
        FormClearMessageResponse rsp = await FormApi.clearMessage(req);

        if (isMutiCommand == false) {
          FormRspData.parseRspFormClearMessageResponse(
              rsp, responseDataBase.formData);
        } else {
          if (mutiCommandViewModel!.isDoingMutiCommand == true) {
            List<Map> data = FormRspData.clearMessageData();
            FormRspData.parseRspFormClearMessageResponse(rsp, data);
            mutiCommandViewModel.addRsp('Form', 'ClearMessageRsp', data);
          }
        }
        break;
      case FormCommand.RemoveCardRequest:
        FormRemoveCardRequest req =
            FormReqData.formRemoveCardRequest(dataSource);
        FormRemoveCardResponse rsp = await FormApi.removeCard(req);

        if (isMutiCommand == false) {
          FormRspData.parseRspFormRemoveCardResponse(
              rsp, responseDataBase.formData);
        } else {
          if (mutiCommandViewModel!.isDoingMutiCommand == true) {
            List<Map> data = FormRspData.removeCardData();
            FormRspData.parseRspFormRemoveCardResponse(rsp, data);
            mutiCommandViewModel.addRsp('Form', 'RemoveCardRsp', data);
          }
        }
        break;
      case FormCommand.InputTextRequest:
        FormInputTextRequest req = FormReqData.formInputTextRequest(dataSource);
        FormInputTextResponse rsp = await FormApi.inputText(req);

        if (isMutiCommand == false) {
          FormRspData.parseRspFormInputTextResponse(
              rsp, responseDataBase.formData);
        } else {
          if (mutiCommandViewModel!.isDoingMutiCommand == true) {
            List<Map> data = FormRspData.inputTextData();
            FormRspData.parseRspFormInputTextResponse(rsp, data);
            mutiCommandViewModel.addRsp('Form', 'InputTextRsp', data);
          }
        }
        break;
      case FormCommand.ShowMessageRequest:
        FormShowMessageRequest req =
            FormReqData.formShowMessageRequest(dataSource);
        FormShowMessageResponse rsp = await FormApi.showMessage(req);

        if (isMutiCommand == false) {
          FormRspData.parseRspFormShowMessageResponse(
              rsp, responseDataBase.formData);
        } else {
          if (mutiCommandViewModel!.isDoingMutiCommand == true) {
            List<Map> data = FormRspData.showMessageData();
            FormRspData.parseRspFormShowMessageResponse(rsp, data);
            mutiCommandViewModel.addRsp('Form', 'ShowMessageRsp', data);
          }
        }
        break;
      default:
        throw Exception('undefined function');
      //break;
    }
  }
}

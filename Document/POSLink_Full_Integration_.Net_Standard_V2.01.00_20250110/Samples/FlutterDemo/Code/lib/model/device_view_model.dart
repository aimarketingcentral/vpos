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
import 'package:poslink2/auto_data_source/auto_device_request_data_source.dart';
import 'package:poslink2/auto_data_source/auto_device_response_data_source.dart';
import 'package:poslink2/auto_pigeon/poslink_sdk_device.dart';
import 'package:poslink2/model/response_db.dart';
import 'comm_setting_view_model.dart';
import 'multicommand_view_model.dart';

class DeviceViewModel extends ChangeNotifier {
  Future startDevice(CommSettingViewModel commSettingViewModel,
      ResponseDataBase responseDataBase, List<Map> dataSource,
      {bool isMutiCommand = false,
      MutiCommandViewModel? mutiCommandViewModel}) async {
    POSLinkDeviceApi DeviceApi = POSLinkDeviceApi();

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
      case DeviceCommand.PrinterRequest:
        DevicePrinterRequest req = DeviceReqData.formPrinterRequest(dataSource);
        DevicePrinterResponse rsp = await DeviceApi.printer(req);

        if (isMutiCommand == false) {
          DeviceRspData.parseRspDevicePrinterResponse(
              rsp, responseDataBase.deviceData);
        } else {
          if (mutiCommandViewModel!.isDoingMutiCommand == true) {
            List<Map> data = DeviceRspData.printerData();
            DeviceRspData.parseRspDevicePrinterResponse(rsp, data);
            mutiCommandViewModel.addRsp('Device', 'PrinterRsp', data);
          }
        }
        break;
      case DeviceCommand.MifareCardRequest:
        DeviceMifareCardRequest req =
            DeviceReqData.formMifareCardRequest(dataSource);
        DeviceMifareCardResponse rsp = await DeviceApi.mifareCard(req);

        if (isMutiCommand == false) {
          DeviceRspData.parseRspDeviceMifareCardResponse(
              rsp, responseDataBase.deviceData);
        } else {
          if (mutiCommandViewModel!.isDoingMutiCommand == true) {
            List<Map> data = DeviceRspData.mifareCardData();
            DeviceRspData.parseRspDeviceMifareCardResponse(rsp, data);
            mutiCommandViewModel.addRsp('Device', 'MifareCardRsp', data);
          }
        }
        break;
      case DeviceCommand.CameraScanRequest:
        DeviceCameraScanRequest req =
            DeviceReqData.formCameraScanRequest(dataSource);
        DeviceCameraScanResponse rsp = await DeviceApi.cameraScan(req);

        if (isMutiCommand == false) {
          DeviceRspData.parseRspDeviceCameraScanResponse(
              rsp, responseDataBase.deviceData);
        } else {
          if (mutiCommandViewModel!.isDoingMutiCommand == true) {
            List<Map> data = DeviceRspData.cameraScanData();
            DeviceRspData.parseRspDeviceCameraScanResponse(rsp, data);
            mutiCommandViewModel.addRsp('Device', 'CameraScanRsp', data);
          }
        }
        break;
      case DeviceCommand.CardInsertDetectionRequest:
        DeviceCardInsertDetectionRequest req =
            DeviceReqData.formCardInsertDetectionRequest(dataSource);
        DeviceCardInsertDetectionResponse rsp =
            await DeviceApi.cardInsertDetection(req);

        if (isMutiCommand == false) {
          DeviceRspData.parseRspDeviceCardInsertDetectionResponse(
              rsp, responseDataBase.deviceData);
        } else {
          if (mutiCommandViewModel!.isDoingMutiCommand == true) {
            List<Map> data = DeviceRspData.cardInsertDetectionData();
            DeviceRspData.parseRspDeviceCardInsertDetectionResponse(rsp, data);
            mutiCommandViewModel.addRsp(
                'Device', 'CardInsertDetectionRsp', data);
          }
        }
        break;
      default:
        throw Exception('undefined function');
      //break;
    }
  }
}

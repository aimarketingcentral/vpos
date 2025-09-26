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

import 'package:flutter/cupertino.dart';
import 'package:poslink2/auto_data_source/auto_customformmanage_request_data_source.dart';
import 'package:poslink2/auto_data_source/auto_device_request_data_source.dart';
import 'package:poslink2/auto_data_source/auto_fullintegration_request_data_source.dart';
import 'package:poslink2/auto_data_source/auto_manage_request_data_source.dart';
import 'package:poslink2/model/base_view_model.dart';
import '../auto_data_source/auto_data_source_common.dart';
import '../auto_data_source/auto_form_request_data_source.dart';
import '../auto_data_source/auto_payload_request_data_source.dart';
import '../auto_data_source/auto_ped_request_data_source.dart';
import '../log/dart_log.dart';

class RequestDataBase extends ChangeNotifier {
  BaseViewModel? _baseViewModel;

  set setReqBaseViewModel(model) {
    _baseViewModel = model;
  }

  get getReqBaseViewModel {
    return _baseViewModel;
  }

  //  保存所有的数据
  Map<String, List<Map>> _mapFullIntegration = {};
  Map<String, List<Map>> _mapManage = {};
  Map<String, List<Map>> _mapCustomformmanage = {};
  Map<String, List<Map>> _mapDevice = {};
  Map<String, List<Map>> _mapForm = {};
  Map<String, List<Map>> _mapPayload = {};
  Map<String, List<Map>> _mapPed = {};

  // 保存当前的命令
  String? _strCurrentCommandFullIntegration;
  String? _strCurrentCommandManage;
  String? _strCurrentCommandCustomformmanage;
  String? _strCurrentCommandDevice;
  String? _strCurrentCommandForm;
  String? _strCurrentCommandPayload;
  String? _strCurrentCommandPed;

  set setStrCurrentCommandFullIntegration(value) {
    _strCurrentCommandFullIntegration = value;
  }

  get strCurrentCommandFullIntegration {
    if (_strCurrentCommandFullIntegration == null) {
      _strCurrentCommandFullIntegration = FullIntegrationReqData.initSourceData()[0][kValue].toString();
    }
    return _strCurrentCommandFullIntegration;
  }

  set setStrCurrentCommandManage(value) {
    _strCurrentCommandManage = value;
  }

  get strCurrentCommandManage {
    if (_strCurrentCommandManage == null) {
      _strCurrentCommandManage = ManageReqData.initSourceData()[0][kValue].toString();
    }
    return _strCurrentCommandManage;
  }

  set setStrCurrentCommandCustomformmanage(value) {
    _strCurrentCommandCustomformmanage = value;
  }

  get strCurrentCommandCustomformmanage {
    if (_strCurrentCommandCustomformmanage == null) {
      _strCurrentCommandCustomformmanage = CustomFormManageReqData.initSourceData()[0][kValue].toString();
    }
    return _strCurrentCommandCustomformmanage;
  }

  set setStrCurrentCommandDevice(value) {
    _strCurrentCommandDevice = value;
  }

  get strCurrentCommandDevice {
    if (_strCurrentCommandDevice == null) {
      _strCurrentCommandDevice = DeviceReqData.initSourceData()[0][kValue].toString();
    }
    return _strCurrentCommandDevice;
  }

  set setStrCurrentCommandForm(value) {
    _strCurrentCommandForm = value;
  }

  get strCurrentCommandForm {
    if (_strCurrentCommandForm == null) {
      _strCurrentCommandForm = FormReqData.initSourceData()[0][kValue].toString();
    }
    return _strCurrentCommandForm;
  }

  set setStrCurrentCommandPayload(value) {
    _strCurrentCommandPayload = value;
  }

  get strCurrentCommandPayload {
    if (_strCurrentCommandPayload == null) {
      _strCurrentCommandPayload = PayloadReqData.initSourceData()[0][kValue].toString();
    }
    return _strCurrentCommandPayload;
  }

  set setStrCurrentCommandPed(value) {
    _strCurrentCommandPed = value;
  }

  get strCurrentCommandPed {
    if (_strCurrentCommandPed == null) {
      _strCurrentCommandPed = PedReqData.initSourceData()[0][kValue].toString();
    }
    return _strCurrentCommandPed;
  }

  // 保存所有的数据
  void saveFullIntegrationData(key, value) {
    _mapFullIntegration[key] = value;
  }

  List<Map>? readFullIntegrationData(key) {
    return _mapFullIntegration[key];
  }

  void saveManageData(key, value) {
    _mapManage[key] = value;
  }

  List<Map>? readManageData(key) {
    return _mapManage[key];
  }

  void saveCustomformmanageData(key, value) {
    _mapCustomformmanage[key] = value;
  }

  List<Map>? readCustomformmanageData(key) {
    return _mapCustomformmanage[key];
  }

  void saveDeviceData(key, value) {
    _mapDevice[key] = value;
  }

  List<Map>? readDeviceData(key) {
    return _mapDevice[key];
  }

  void saveFormData(key, value) {
    _mapForm[key] = value;
  }

  List<Map>? readFormData(key) {
    return _mapForm[key];
  }

  void savePayloadData(key, value) {
    _mapPayload[key] = value;
  }

  List<Map>? readPayloadData(key) {
    return _mapPayload[key];
  }

  void savePedData(key, value) {
    _mapPed[key] = value;
  }

  List<Map>? readPedData(key) {
    return _mapPed[key];
  }
}

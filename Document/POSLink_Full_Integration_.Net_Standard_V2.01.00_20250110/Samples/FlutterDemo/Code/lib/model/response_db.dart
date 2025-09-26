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
import 'package:poslink2/auto_data_source/auto_customformmanage_response_data_source.dart';
import 'package:poslink2/auto_data_source/auto_fullintegration_response_data_source.dart';
import 'package:poslink2/auto_data_source/auto_manage_response_data_source.dart';
import 'package:poslink2/res/size_fit.dart';
import '../auto_data_source/auto_device_response_data_source.dart';
import '../auto_data_source/auto_form_response_data_source.dart';
import '../auto_data_source/auto_payload_response_data_source.dart';
import '../auto_data_source/auto_ped_response_data_source.dart';
import 'base_view_model.dart';

class ResponseDataBase extends ChangeNotifier {
  BaseViewModel _fullModel = BaseViewModel();
  BaseViewModel _manageModel = BaseViewModel();
  BaseViewModel _formModel = BaseViewModel();
  BaseViewModel _deviceModel = BaseViewModel();
  BaseViewModel _pedModel = BaseViewModel();
  BaseViewModel _multiCommadModel = BaseViewModel();


  set setFullBaseViewModel(model) {
    _fullModel = model;
  }
  set setManageBaseViewModel(model) {
    _manageModel = model;
  }
  set setFormBaseViewModel(model) {
    _formModel = model;
  }
  set setDeviceBaseViewModel(model) {
    _deviceModel = model;
  }
  set setPedBaseViewModel(model) {
    _pedModel = model;
  }
  set setMultiCommandBaseViewModel(model) {
    _multiCommadModel = model;
  }


  refresh(List<Map> list, Command command) {
    // if (TTSizeFit.aspectRatio < 1) {
    //   return;
    // }
    if (TTSizeFit.isPortrait) {
      return;
    }
    if (command ==Command.FULLINTEGRATION) {
      _fullModel.setDataSource = list;
    } else if (command ==Command.MANAGE) {
      _manageModel.setDataSource = list;
    } else if (command ==Command.FORM) {
      _formModel.setDataSource = list;
    } else if (command ==Command.DEVICE) {
      _deviceModel.setDataSource = list;
    } else if (command ==Command.PED) {
      _pedModel.setDataSource = list;
    } else if (command ==Command.MUTICOMMAND) {
      _multiCommadModel.setDataSource = list;
    }
  }


  List<Map>? _fullIntegrationData;
  set setFullIntegrationData(value) {
    _fullIntegrationData = value;
  }

  /// 保存着当前transaction界面的表单数据，实时更新
  get fullIntegrationData {
    if (_fullIntegrationData == null) {
      _fullIntegrationData = FullIntegrationRspData.initSourceData();
    }
    return _fullIntegrationData;
  }

  List<Map>? _manageData;
  set setManageData(value) {
    _manageData = value;
  }

  /// 保存着当前Manage界面的表单数据，实时更新
  get manageData {
    if (_manageData == null) {
      _manageData = ManageRspData.initSourceData();
    }
    return _manageData;
  }

  List<Map>? _customformmanageData;
  set setCustomformmanageData(value) {
    _customformmanageData = value;
  }

  /// 保存着当前Batch界面的表单数据，实时更新
  get customformmanageData {
    if (_customformmanageData == null) {
      _customformmanageData = CustomFormManageRspData.initSourceData();
    }
    return _customformmanageData;
  }

  List<Map>? _deviceData;
  set setDeviceData(value) {
    _deviceData = value;
  }

  /// 保存着当前界面的表单数据，实时更新
  get deviceData {
    if (_deviceData == null) {
      _deviceData = DeviceRspData.initSourceData();
    }
    return _deviceData;
  }

  List<Map>? _formData;
  set setFormData(value) {
    _formData = value;
  }

  /// 保存着当前界面的表单数据，实时更新
  get formData {
    if (_formData == null) {
      _formData = FormRspData.initSourceData();
    }
    return _formData;
  }

  List<Map>? _payloadData;
  set setPayloadData(value) {
    _payloadData = value;
  }

  /// 保存着当前界面的表单数据，实时更新
  get payloadData {
    if (_payloadData == null) {
      _payloadData = PayloadRspData.initSourceData();
    }
    return _payloadData;
  }

  List<Map>? _pedData;
  set setPedData(value) {
    _pedData = value;
  }

  /// 保存着当前界面的表单数据，实时更新
  get pedData {
    if (_pedData == null) {
      _pedData = PedRspData.initSourceData();
    }
    return _pedData;
  }
}

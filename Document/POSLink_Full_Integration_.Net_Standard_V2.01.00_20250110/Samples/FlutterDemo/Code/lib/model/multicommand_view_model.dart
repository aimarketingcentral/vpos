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
import 'dart:async';

import 'package:flutter/cupertino.dart';
import 'package:fluttertoast/fluttertoast.dart';
import 'package:poslink2/auto_pigeon/poslink_sdk_multi_command.dart';
import 'package:poslink2/log/dart_log.dart';

import '../auto_data_source/auto_data_source_common.dart';
import 'comm_setting_view_model.dart';

class MutiCommandViewModel extends ChangeNotifier {
  List<Map> _mutiCommands = [];
  List<Map> _mutiCommandsRsps = [];

  int _tabBarViewIndex = 0;
  get tabBarViewIndex {
    return _tabBarViewIndex;
  }

  set setTabBarViewIndex(value) {
    _tabBarViewIndex = value;
    notifyListeners();
  }

  Response _mutiRsp = Response();
  get mutiRsp {
    return _mutiRsp;
  }

  set setMutiRsp(value) {
    _mutiRsp = value;
    notifyListeners();
  }

  bool _isDoingMutiCommand = false;
  get isDoingMutiCommand {
    return _isDoingMutiCommand;
  }

  set setIsDoingMutiCommand(value) {
    _isDoingMutiCommand = value;
    notifyListeners();
  }

  /// cache requests
  get mutiCommands {
    if (_mutiCommands == null) {
      _mutiCommands = [];
    }
    return _mutiCommands;
  }

  addCommand(dynamic) {
    if (_mutiCommands == null) {
      _mutiCommands = [];
    }
    _mutiCommands.add(dynamic);
    notifyListeners();
  }

  /// cache responses
  get mutiCommandsRsps {
    if (_mutiCommandsRsps == null) {
      _mutiCommandsRsps = [];
    }
    return _mutiCommandsRsps;
  }

  addRsp(String name, String rspName, List<Map> data) {
    if (_mutiCommandsRsps == null) {
      _mutiCommandsRsps = [];
    }
    Map map = {};
    map[kName] = name;
    map[kValue] = rspName;
    String menuId = '';
    if (name == 'FullIntegration') {
      // menuId = CommSettingViewModel.TAB_FULL_INTEGRATION;
      menuId = "FULL_INTEGRATION";
    } else if (name == 'CustomFormManage') {
      // menuId = CommSettingViewModel.TAB_CUSTOM_FORM_MANAGE;
      menuId = "CUSTOM_FORM_MANAGE";
    } else if (name == 'Device') {
      // menuId = CommSettingViewModel.TAB_DEVICE;
      menuId = "CUSTOM_DEVICE";
    } else if (name == 'Form') {
      // menuId = CommSettingViewModel.TAB_FORM;
      menuId = "FORM";
    } else if (name == 'Manage') {
      // menuId = CommSettingViewModel.TAB_MANAGE;
      menuId = "MANAGE";
    } else if (name == 'Payload') {
      // menuId = CommSettingViewModel.TAB_PAYLOAD;
      menuId = "PAYLOAD";
    } else if (name == 'Ped') {
      // menuId = CommSettingViewModel.TAB_PED;
      menuId = "PED";
    } else {
      throw Exception('need add new name');
    }
    map[kMenuID] = menuId;
    map[kData] = data;
    _mutiCommandsRsps.add(map);
    notifyListeners();
  }

  /// cache muticommands status
  bool _prepareMutiCommand = false;
  get prepareMutiCommand {
    return _prepareMutiCommand;
  }

  changePrepareMutiCommandStatus(bool value) {
    _prepareMutiCommand = value;
    if (value == true) {
      _clear();
    } else {
      notifyListeners();
    }
    // notifyListeners();
  }

  clearRequest() {
    _clear();
    // notifyListeners();
  }

  /// clear
  _clear() {
    _mutiCommands = [];
    _mutiCommandsRsps = [];
    _mutiRsp = Response();
    notifyListeners();
  }

  Future startMutiCommand(CommSettingViewModel commSettingViewModel) async {
    /// status
    setTabBarViewIndex = 0;
    changePrepareMutiCommandStatus(true);

    /// send
    await commSettingViewModel.setSetting();
    POSLinkMultiCommandApi multiCommandApi = POSLinkMultiCommandApi();
    multiCommandApi.startMultiCommand();
  }

  Future cancelMutiCommand(CommSettingViewModel commSettingViewModel) async {
    /// send
    await commSettingViewModel.setSetting();
    POSLinkMultiCommandApi multiCommandApi = POSLinkMultiCommandApi();
    multiCommandApi.cancelMultiCommand();
  }

  Future completeMutiCommand(CommSettingViewModel commSettingViewModel) async {
    /// status
    setIsDoingMutiCommand = true;

    try {
      /// send
      await commSettingViewModel.setSetting();
      bool handshakeSuccess = await commSettingViewModel.handshake();
      if(!handshakeSuccess) {
        throw HandshakeException();
      }
      POSLinkMultiCommandApi multiCommandApi = POSLinkMultiCommandApi();
      Response response = await multiCommandApi.completeMultiCommand();
      print('等待返回');
      if (isDoingMutiCommand == true) {
        setMutiRsp = response;
        setIsDoingMutiCommand = false;
        setTabBarViewIndex = 1;
        changePrepareMutiCommandStatus(false);
        cancelMutiCommand(commSettingViewModel);
      }
    }on HandshakeException {
      Fluttertoast.showToast(
        msg:
        "Can't detect the target device. Please set Communication Setting, then click refresh button.",
        toastLength: Toast.LENGTH_LONG,
      );
    } catch (e, stackTrace) {
      print(e);
      print(stackTrace);
      setIsDoingMutiCommand = false;
    }
    if (isDoingMutiCommand == true) {
      setIsDoingMutiCommand = false;
    }
  }
}

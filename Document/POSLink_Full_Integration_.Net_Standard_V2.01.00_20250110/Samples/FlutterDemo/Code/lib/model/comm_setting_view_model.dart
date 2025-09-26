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
import 'package:poslink2/auto_pigeon/poslink_android.dart';
import 'package:poslink2/auto_pigeon/poslink_sdk_set.dart';
import 'package:shared_preferences/shared_preferences.dart';
import 'dart:io';

enum CommSettingType {
  AIDL,
  TCP,
  HTTP,
  HTTPS,
  SSL,
  USB,
  UART,
  BT,
}

enum CurrentTabEnum {
  TAB_FULL_INTEGRATION,
  TAB_MANAGE,
  TAB_FORM,
  TAB_DEVICE,
  TAB_PED,
  TAB_MULTI_COMMAND,
  // TAB_PAYLOAD,
  // TAB_CUSTOM_FORM_MANAGE,
  TAB_LOG_SETTING,
  TAB_COMM_SETTING,
  TAB_SEND_COMMAND,
}

extension CurrentTabEnumValue on CurrentTabEnum {
  String get stringValue {
    switch (this) {
      case CurrentTabEnum.TAB_FULL_INTEGRATION:
        return 'FULL_INTEGRATION';
      case CurrentTabEnum.TAB_MANAGE:
        return 'MANAGE';
      case CurrentTabEnum.TAB_FORM:
        return 'FORM';
      case CurrentTabEnum.TAB_DEVICE:
        return 'CUSTOM_DEVICE';
      case CurrentTabEnum.TAB_PED:
        return 'PED';
      case CurrentTabEnum.TAB_MULTI_COMMAND:
        return 'MULTI_COMMAND';
      case CurrentTabEnum.TAB_SEND_COMMAND:
        return 'SEND_COMMAND';
      case CurrentTabEnum.TAB_LOG_SETTING:
        return 'LOG_SETTING';
      case CurrentTabEnum.TAB_COMM_SETTING:
        return 'COMM_SETTING';
    }
  }

  String get homeItemTitle {
    switch (this) {
      case CurrentTabEnum.TAB_FULL_INTEGRATION:
        return 'FullIntegration';
      case CurrentTabEnum.TAB_MANAGE:
        return 'Manage';
      case CurrentTabEnum.TAB_FORM:
        return 'Form';
      case CurrentTabEnum.TAB_DEVICE:
        return 'Device';
      case CurrentTabEnum.TAB_PED:
        return 'PED';
      case CurrentTabEnum.TAB_MULTI_COMMAND:
        return 'MultiCommand';
      case CurrentTabEnum.TAB_SEND_COMMAND:
        return 'Send Cmd';
      case CurrentTabEnum.TAB_LOG_SETTING:
        return 'Log Setting';
      case CurrentTabEnum.TAB_COMM_SETTING:
        return 'Setting';
    }
  }
}

class HandshakeException {}

class CommSettingViewModel extends ChangeNotifier {
  static const KEY_TYPE = "TYPE";
  static const KEY_TIMEOUT = "TIMEOUT";
  static const KEY_ENABLE_JSON = "ENABLE_JSON";
  static const KEY_IP = "IP";
  static const KEY_PORT = "PORT";
  static const KEY_CHANNEL = "CHANNEL";
  static const KEY_SERIAL_PORT = "SERIAL_PORT";
  static const KEY_BAUDRATE = "BAUDRATE";
  static const KEY_MAC_ADDR = "MAC_ADDR";
  static const KEY_DEVICE_NAME = "DEVICE_NAME";

  // static const String TAB_FULL_INTEGRATION = "FULL_INTEGRATION";
  // static const String TAB_LOG_SETTING = "LOG_SETTING";
  // static const String TAB_COMM_SETTING = "COMM_SETTING";
  // static const String TAB_MULTI_COMMAND = "MULTI_COMMAND";
  // static const String TAB_FORM = "FORM";
  // static const String TAB_MANAGE = "MANAGE";
  // static const String TAB_PED = "PED";
  // static const String TAB_PAYLOAD = "PAYLOAD";
  // static const String TAB_CUSTOM_FORM_MANAGE = "CUSTOM_FORM_MANAGE";
  // static const String TAB_DEVICE = "CUSTOM_DEVICE";

  CommSettingType _type =
      Platform.isAndroid ? CommSettingType.AIDL : CommSettingType.TCP;
  int _timeout = 60000;
  bool _enableJson = false;
  String? _ip;
  String? _port = "10009";
  String? _channel;
  String? _serialPort;
  List<String?> uartDevices = [];
  String? _baudRate = "9600";
  String? _macAddr;
  String? _deviceName;

  // String _currentTab = TAB_FULL_INTEGRATION;
  CurrentTabEnum _currentTab = CurrentTabEnum.TAB_FULL_INTEGRATION;

  CommSettingViewModel() {
    getLocalData();
  }

  CommSettingType get type {
    return _type;
  }

  set type(CommSettingType type) {
    _type = type;
    notifyListeners();

    if (_type == CommSettingType.UART) {
      getUARTDevices().then((value) => notifyListeners());
    } else if (_type == CommSettingType.USB) {
      setUSBSetting(); // request usb permission first.
    }
  }

  int get timeout => _timeout;

  set timeout(int value) {
    _timeout = value;
  }

  bool get enableJson => _enableJson;

  set enableJson(bool value) {
    _enableJson = value;
  }

  String? get port => _port;

  set port(String? value) {
    _port = value;
  }

  String? get ip => _ip;

  set ip(String? value) {
    _ip = value;
  }

  String? get channel => _channel;

  set channel(String? value) {
    _channel = value;
  }

  String? get serialPort => _serialPort;

  set serialPort(String? value) {
    _serialPort = value;
  }

  String? get baudRate => _baudRate;

  set baudRate(String? value) {
    _baudRate = value;
  }

  String? get macAddr => _macAddr;

  set macAddr(String? value) {
    _macAddr = value;
  }

  // String get currentTab => _currentTab;
  //
  // set currentTab(String value) {
  //   _currentTab = value;
  //   notifyListeners();
  // }
  CurrentTabEnum get currentTab => _currentTab;

  set currentTab(CurrentTabEnum value) {
    _currentTab = value;
    notifyListeners();
  }

  String? get deviceName => _deviceName;

  set deviceName(String? value) {
    _deviceName = value;
  }

  save() async {
    SharedPreferences pref = await SharedPreferences.getInstance();
    pref.setInt(KEY_TYPE, _type.index);
    pref.setInt(KEY_TIMEOUT, _timeout);
    pref.setBool(KEY_ENABLE_JSON, _enableJson);
    pref.setString(KEY_IP, _ip ?? "");
    pref.setString(KEY_PORT, _port ?? "");
    pref.setString(KEY_CHANNEL, _channel ?? "");
    pref.setString(KEY_SERIAL_PORT, _serialPort ?? "");
    pref.setString(KEY_BAUDRATE, _baudRate ?? "");
    pref.setString(KEY_MAC_ADDR, _macAddr ?? "");
    pref.setString(KEY_DEVICE_NAME, _deviceName ?? "");

    await setSetting();
  }

  requestUSBPermissionIfNeed() async {
    await POSLinkAndroidApi()
        .requestUSBPermissionIfNeed(UsbDevice()
      ..deviceName = _deviceName);
  }

    Future<bool> refresh() async {
    await POSLinkSetApi().remove();
    return await handshake();
  }

  Future<bool> handshake() async {
    return await POSLinkSetApi().handshake();
  }

  getLocalData() async {
    SharedPreferences pref = await SharedPreferences.getInstance();
    _type = Platform.isAndroid
        ? CommSettingType.values[pref.getInt(KEY_TYPE) ?? 0]
        : CommSettingType.values[pref.getInt(KEY_TYPE) ?? 1];
    _timeout = pref.getInt(KEY_TIMEOUT) ?? 60000;
    _enableJson = pref.getBool(KEY_ENABLE_JSON) ?? false;
    _ip = pref.getString(KEY_IP);
    _port = pref.getString(KEY_PORT) ?? "10009";
    _channel = pref.getString(KEY_CHANNEL);
    _serialPort = pref.getString(KEY_SERIAL_PORT);
    _baudRate = pref.getString(KEY_BAUDRATE) ?? "9600";
    _deviceName = pref.getString(KEY_DEVICE_NAME);
    if (_type == CommSettingType.UART) {
      await getUARTDevices();
    }
    _macAddr = pref.getString(KEY_MAC_ADDR);
    notifyListeners();
  }

  Future setAIDLSetting() async {
    await POSLinkSetApi().setAIDLSetting();
  }

  Future setTCPSetting() async {
    await POSLinkSetApi().setTCPSetting(TCPSetting()
      ..timeout = _timeout
      ..ip = _ip
      ..port = _port);
  }

  Future setHTTPSetting() async {
    await POSLinkSetApi().setHttpSetting(HttpSetting()
      ..timeout = _timeout
      ..ip = _ip
      ..port = _port);
  }

  Future setHTTPSSetting() async {
    await POSLinkSetApi().setHttpsSetting(HttpsSetting()
      ..timeout = _timeout
      ..ip = _ip
      ..port = _port);
  }

  Future setSSLSetting() async {
    await POSLinkSetApi().setSslSetting(SslSetting()
      ..timeout = _timeout
      ..ip = _ip
      ..port = _port);
  }

  Future setUSBSetting() async {
    await POSLinkSetApi().setUsbSetting(UsbSetting()
      ..timeout = _timeout
      ..channel = _channel
      ..deviceName = _deviceName);
  }

  Future setUARTSetting() async {
    await POSLinkSetApi().setUartSetting(UartSetting()
      ..timeout = _timeout
      ..serialPort = _serialPort
      ..baudRate = _baudRate);
  }

  Future getUARTDevices() async {
    uartDevices = await POSLinkSetApi().getUartDevices();
  }

  Future setBTSetting() async {
    await POSLinkSetApi().setBTSetting(BTSetting()
      ..timeout = _timeout
      ..macAddr = _macAddr);
  }

  Future cancel() async {
    await POSLinkSetApi().cancel();
  }

  Future setSetting() async {
    await getLocalData();
    switch (_type) {
      case CommSettingType.TCP:
        await setTCPSetting();
        break;
      case CommSettingType.AIDL:
        await setAIDLSetting();
        break;
      case CommSettingType.HTTP:
        await setHTTPSetting();
        break;
      case CommSettingType.HTTPS:
        await setHTTPSSetting();
        break;
      case CommSettingType.SSL:
        await setSSLSetting();
        break;
      case CommSettingType.USB:
        await setUSBSetting();
        break;
      case CommSettingType.UART:
        await setUARTSetting();
        break;
      case CommSettingType.BT:
        await setBTSetting();
        break;
      default:
        break;
    }
  }
}

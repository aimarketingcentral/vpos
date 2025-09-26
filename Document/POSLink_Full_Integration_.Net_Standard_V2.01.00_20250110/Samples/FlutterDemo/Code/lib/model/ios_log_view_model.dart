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
import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:poslink2/auto_pigeon/poslink_ios_native_file.dart';
import 'dart:io';
import '../auto_pigeon/poslink_sdk_log_set.dart';

class IOSLogViewModel extends ChangeNotifier {
  List<String?>? _data = [];
  String? _logString = '';

  get data {
    return _data;
  }

  get log {
    return _logString;
  }

  clearLog() {
    _logString = '';
  }

  Future load() async {
    _data = await POSLinkIOSFileApi().getIosLogList();
    notifyListeners();
  }

  Future read(String path) async {
    File file = File(path);
    _logString = await file.readAsString();
    notifyListeners();
  }
}

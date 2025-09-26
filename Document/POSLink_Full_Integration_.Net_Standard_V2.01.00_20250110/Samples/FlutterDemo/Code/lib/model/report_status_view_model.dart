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

import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:fluttertoast/fluttertoast.dart';
import 'package:poslink2/auto_pigeon/poslink_sdk_report_status.dart';
import 'package:poslink2/log/dart_log.dart';

class ReportStatusViewModel extends ChangeNotifier {
  bool? stop;

  startPolling() {
    Timer.periodic(Duration(milliseconds: 100), (timer) async {
      if (stop == true) {
        timer.cancel();
      } else {
        try {
          String value = await _start();
          Fluttertoast.showToast(msg: value);
        } on PlatformException {
          //do not print error message when don't need to apply this function.
        } catch (e) {
          print(e);
        }
      }
    });
  }

  Future<String> _start() async {
    POSLinkGetReportStatusApi api = POSLinkGetReportStatusApi();
    int value = await api.getReportStatus();
    return value.toString();
  }
}

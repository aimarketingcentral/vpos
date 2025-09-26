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

import 'package:flutter/services.dart';

class POSLinkMethodChannel {
  static final POSLinkMethodChannel _instance =
      POSLinkMethodChannel._internal();
  static const MethodChannel _channel =
      const MethodChannel('com.pax.poslink2.method');

  POSLinkMethodChannel._internal();

  factory POSLinkMethodChannel() {
    return _instance;
  }

  Future invokeMethod(String method, [Map<String, dynamic>? params]) async {
    await _channel.invokeMethod(method, params);
  }
}

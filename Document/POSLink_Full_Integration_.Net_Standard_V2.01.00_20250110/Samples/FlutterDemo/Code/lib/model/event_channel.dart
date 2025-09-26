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

import 'package:flutter/services.dart';

typedef EventListener(String event, Map<String, dynamic> paramsMap);

class POSLinkEventChannel {
  static final POSLinkEventChannel _instance = POSLinkEventChannel._internal();
  List<EventListener> _listenerList = [];

  POSLinkEventChannel._internal() {
    EventChannel eventChannel = EventChannel("com.pax.poslink2.event");
    eventChannel.receiveBroadcastStream().listen((event) {
      Map<String, dynamic> jsonMap = jsonDecode(event);
      if(jsonMap['event'] != null) {
        _listenerList.forEach((listener) {
          listener(jsonMap['event'], jsonMap);
        });
      }
    });
  }

  factory POSLinkEventChannel() {
    return _instance;
  }

  void addListener(EventListener listener) {
    _listenerList.add(listener);
  }

  void removeListener(EventListener listener) {
    _listenerList.remove(listener);
  }

  void clearListener() {
    _listenerList.clear();
  }
}

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

import '../../model/event_channel.dart';
import '../../model/method_channel.dart';
import '../../res/colors.dart';

class EnterPinPage extends StatefulWidget {
  @override
  State<StatefulWidget> createState() => _EnterPinPageState();
}

class _EnterPinPageState extends State<EnterPinPage> {
  late Function(String event, Map<String, dynamic> paramsMap) listener;

  String text = "";

  @override
  void initState() {
    listener = (event, paramsMap) {
      switch (event) {
        case "ADD_PIN":
          setState(() {
            text = text + "*";
          });
          break;
        case "CLEAR_PIN":
          setState(() {
            text = "";
          });
          break;
        case "FINISH_ENTER_PIN":
        case "FINISH":
          Navigator.of(context).pop();
          break;
      }
    };
    POSLinkEventChannel().addListener(listener);
    super.initState();
  }

  @override
  void dispose() {
    POSLinkEventChannel().removeListener(listener);
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return WillPopScope(
      onWillPop: () async {
        await POSLinkMethodChannel().invokeMethod("CANCEL");
        return true;
      },
      child: Scaffold(
        appBar: AppBar(
          backgroundColor: kMainColor,
          elevation: 0,
          title: Text("Enter PIN"),
        ),
        body: Column(
          children: [
            SizedBox(
              height: 50,
            ),
            Padding(
              padding: const EdgeInsets.symmetric(
                horizontal: 20,
              ),
              child: Container(
                alignment: Alignment.centerLeft,
                height: 50,
                padding: const EdgeInsets.all(8),
                decoration: BoxDecoration(
                  border: Border.all(
                    color: Colors.grey,
                  ),
                ),
                child: Text(text),
              ),
            ),
          ],
        ),
      ),
    );
  }
}

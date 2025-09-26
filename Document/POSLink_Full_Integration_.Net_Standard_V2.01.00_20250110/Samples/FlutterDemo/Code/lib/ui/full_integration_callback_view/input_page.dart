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
import 'package:flutter/services.dart';
import 'package:poslink2/model/event_channel.dart';
import 'package:poslink2/res/colors.dart';

import '../../model/method_channel.dart';

class InputPage extends StatefulWidget {
  final bool outInput;
  final bool skip;
  final String title;
  final String hint;
  final int maxInputLength;
  final Function(String content)? onConfirm;

  InputPage({
    this.outInput = false,
    this.skip = false,
    this.title = "",
    this.hint = "",
    this.maxInputLength = 0,
    this.onConfirm,
  });

  @override
  State<StatefulWidget> createState() => _InputPageState();
}

class _InputPageState extends State<InputPage> {
  late Function(String event, Map<String, dynamic> paramsMap) listener;

  String text = "";
  bool confirmEnable = false;

  @override
  void initState() {
    listener = (event, paramsMap) {
      switch (event) {
        case "FINISH_INPUT":
        case "FINISH":
          Navigator.of(context).pop();
          break;
        case "CONFIRM":
          setState(() {
            confirmEnable = paramsMap["enable"];
          });
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
    List<TextInputFormatter> formatterList = [
      FilteringTextInputFormatter.digitsOnly
    ];
    if (widget.maxInputLength > 0) {
      formatterList
          .add(LengthLimitingTextInputFormatter(widget.maxInputLength));
    }

    return WillPopScope(
      onWillPop: () async {
        await POSLinkMethodChannel().invokeMethod("CANCEL");
        return true;
      },
      child: Scaffold(
        appBar: AppBar(
          backgroundColor: kMainColor,
          elevation: 0,
          title: Text(widget.title),
        ),
        body: Column(
          children: [
            Container(
              height: 50,
              alignment: Alignment.center,
              child: widget.outInput
                  ? null
                  : Padding(
                      padding: const EdgeInsets.all(8.0),
                      child: TextField(
                        onChanged: (content) {
                          setState(() {
                            text = content;
                          });
                        },
                        keyboardType: TextInputType.number,
                        inputFormatters: formatterList,
                        decoration: InputDecoration(hintText: widget.hint),
                      ),
                    ),
            ),
            MaterialButton(
              onPressed: widget.skip || confirmEnable || text.isNotEmpty
                  ? () {
                      if (widget.onConfirm != null) {
                        widget.onConfirm!(text);
                      }
                    }
                  : null,
              color: kMainColor,
              disabledColor: Colors.grey,
              textColor: Colors.white,
              disabledTextColor: Colors.white,
              child: Text("Confirm"),
            )
          ],
        ),
      ),
    );
  }
}

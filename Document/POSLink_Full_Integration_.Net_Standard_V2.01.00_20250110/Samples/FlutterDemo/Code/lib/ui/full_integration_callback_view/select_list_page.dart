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
import '../../res/colors.dart';

class SelectListPage extends StatefulWidget {
  final List<String> list;
  final Function(String content)? onSelect;

  SelectListPage({
    this.list = const [],
    this.onSelect,
  });

  @override
  State<StatefulWidget> createState() => _SelectListPageState();
}

class _SelectListPageState extends State<SelectListPage> {
  late Function(String event, Map<String, dynamic> paramsMap) listener;

  int groupValue = -1;

  @override
  void initState() {
    listener = (event, paramsMap) {
      switch (event) {
        case "FINISH_SELECT":
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
    return Scaffold(
      appBar: AppBar(
        backgroundColor: kMainColor,
        elevation: 0,
        title: Text("Select EMV App"),
        actions: [
          IconButton(
            icon: Icon(Icons.done),
            onPressed: groupValue == -1
                ? null
                : () {
                    if (widget.onSelect != null) {
                      widget.onSelect!(widget.list[groupValue]);
                    }
                  },
          ),
        ],
      ),
      body: ListView.builder(
        itemCount: widget.list.length,
        itemBuilder: (context, index) {
          return Row(
            children: [
              Radio(
                value: index,
                groupValue: groupValue,
                onChanged: (int? index) {
                  setState(() {
                    groupValue = index ?? -1;
                  });
                },
              ),
              Text(widget.list[index]),
            ],
          );
        },
      ),
    );
  }
}

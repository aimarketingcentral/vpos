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
import 'package:poslink2/widget/stack_button.dart';
import 'dart:io';
import '../res/colors.dart';
import '../res/dimension.dart';

class StringListItemAddDialog extends Dialog {
  const StringListItemAddDialog({
    this.refresh,
    this.labelText = 'Please input',
    this.title = '',
    @required this.data,
  });
  final Function? refresh;
  final String labelText;
  final String? title;
  final Map<String, dynamic>? data;

  @override
  Widget build(BuildContext context) {
    List<Widget> barItems = [];

    if (Platform.isAndroid) {
      barItems.add(IconButton(
        onPressed: () {
          Navigator.of(context).pop('0');
        },
        icon: Icon(Icons.close),
      ));
    } else {
      barItems.add(StackButton(
        iconData: Icons.close,
        labelText: 'admcancel',
        click: () {
          Navigator.of(context).pop('0');
        },
      ));
    }
    barItems.add(Expanded(
      child: Center(
        child: Stack(
          alignment: Alignment.center,
          children: [
            Container(
              width: MediaQuery.of(context).size.width / 3.0,
              color: Colors.transparent,
              child: Stack(
                alignment: Alignment.center,
                children: [
                  Text("Add"),
                  Row(
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: [
                      GestureDetector(
                        onTap: () {
                          FocusScopeNode focusScopeNode = FocusScope.of(context);
                          if (!focusScopeNode.hasPrimaryFocus && focusScopeNode.focusedChild != null) {
                            FocusManager.instance.primaryFocus?.unfocus();
                          }
                        },
                        child: Text(
                          'kbdown',
                          style: TextStyle(fontSize: 13, color: Colors.transparent),
                        ),
                      ),
                      SizedBox(
                        width: 20,
                      ),
                    ],
                  )
                ],
              ),
            ),
          ],
        ),
      ),
    ));

    barItems.add(StackButton(
      click: () {
        if (this.refresh != null) {
          this.refresh!();
        }
        Navigator.of(context).pop();
      },
      labelText: 'admconfirm',
      iconData: Icons.check,
      iconColor: kMainColor,
    ));

    return Material(
      type: MaterialType.transparency,
      child: Center(
        child: Container(
          color: Colors.white,
          width: MediaQuery.of(context).size.width,
          height: 120,
          child: Column(
            children: [
              Row(children: barItems),
              Divider(
                height: 0,
              ),
              Expanded(
                child: Padding(
                  padding: EdgeInsets.symmetric(horizontal: kHorizontalPadding),
                  child: TextField(
                    onChanged: (value) {
                      data!['data'] = value;
                    },
                    decoration: InputDecoration(
                      labelText: title,
                    ),
                  ),
                ),
              )
            ],
          ),
        ),
      ),
    );
  }
}

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

import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:fluttertoast/fluttertoast.dart';
import 'package:poslink2/widget/string_list_page.dart';
import 'package:flutter/services.dart';
import '../res/colors.dart';
import '../res/dimension.dart';
import 'dart:io';

import 'model_list_page.dart';

class StringListItem extends StatelessWidget {
  const StringListItem({
    Key? key,
    this.level = 0,
    this.labelText = '',
    this.callback,
    this.dataList = const [],
    this.type = 1, //1 request , 2 response
  }) : super(key: key);

  final int level;
  final String labelText;
  final Function? callback;
  final List<String> dataList;
  final int type;

  String _appendData(List<String> list) {
    String string = '';
    for (int i = 0; i < list.length; i++) {
      string = string + list[i];
      if (i < list.length - 1) {
        string = string + ',' + '\n';
      }
    }
    return string;
  }

  @override
  Widget build(BuildContext context) {
    if (type == 1) {
      return Platform.isWindows
          ? Container(
              height: kCellHeight + 10,
              child: Padding(
                padding: EdgeInsets.only(
                  left: level * kHorizontalPadding,
                  right: kHorizontalPadding,
                  top: kTextFVPadding,
                  bottom: kTextFVPadding,
                ),
                child: Row(
                  children: [
                    GestureDetector(
                      onTap: () async {
                        await Navigator.of(context).push(
                          MaterialPageRoute(
                            builder: (context) => StringListPage(
                              title: labelText,
                              stringList: dataList,
                              callback: (List<String> value) {
                                if (callback != null) {
                                  callback!(value);
                                }
                              },
                            ),
                          ),
                        );
                      },
                      child: Text(
                        labelText,
                        style: kMainLabelStyle,
                      ),
                    ),
                    Expanded(child: SizedBox()),
                    GestureDetector(
                      onTap: () async {
                        await Navigator.of(context).push(
                          MaterialPageRoute(
                            builder: (context) => StringListPage(
                              title: labelText,
                              stringList: dataList,
                              callback: (List<String> value) {
                                if (callback != null) {
                                  callback!(value);
                                }
                              },
                            ),
                          ),
                        );
                      },
                      child: Container(
                        color: Colors.transparent,
                        width: 200,
                        child: Row(
                          children: [
                            Center(
                              child: Text(
                                dataList.isEmpty ? "item count: 0" : "item count: ${dataList.length}",
                              ),
                            ),
                            Expanded(child: SizedBox()),
                            Icon(Icons.arrow_forward_ios),
                          ],
                        ),
                      ),
                    ),
                  ],
                ),
              ),
            )
          : InkWell(
              onTap: () async {
                await Navigator.of(context).push(
                  MaterialPageRoute(
                    builder: (context) => StringListPage(
                      title: labelText,
                      stringList: dataList,
                      callback: (List<String> value) {
                        if (callback != null) {
                          callback!(value);
                        }
                      },
                    ),
                  ),
                );
              },
              child: Container(
                height: kCellHeight,
                child: Padding(
                  padding: EdgeInsets.only(
                    left: level * kHorizontalPadding,
                    right: kHorizontalPadding,
                    top: kTextFVPadding,
                    bottom: kTextFVPadding,
                  ),
                  child: Row(
                    children: [
                      Text(
                        labelText,
                        style: kMainLabelStyle,
                      ),
                      Expanded(
                        child: Center(
                          child: Text(
                            dataList.isEmpty ? "item count: 0" : "item count: ${dataList.length}",
                          ),
                        ),
                      ),
                      Icon(Icons.arrow_forward_ios),
                    ],
                  ),
                ),
              ),
            );
      return Container(
        height: kCellHeight,
        child: Padding(
          padding: EdgeInsets.only(
            left: level * kHorizontalPadding,
            right: kHorizontalPadding,
            top: kTextFVPadding,
            bottom: kTextFVPadding,
          ),
          child: Row(
            children: [
              GestureDetector(
                onTap: () async {
                  await Navigator.of(context).push(
                    MaterialPageRoute(
                      builder: (context) => StringListPage(
                        title: labelText,
                        stringList: dataList,
                        callback: (List<String> value) {
                          if (callback != null) {
                            callback!(value);
                          }
                        },
                      ),
                    ),
                  );
                },
                child: Text(
                  labelText,
                  style: kMainLabelStyle,
                ),
              ),
              Expanded(child: SizedBox()),
              GestureDetector(
                onTap: () async {
                  await Navigator.of(context).push(
                    MaterialPageRoute(
                      builder: (context) => StringListPage(
                        title: labelText,
                        stringList: dataList,
                        callback: (List<String> value) {
                          if (callback != null) {
                            callback!(value);
                          }
                        },
                      ),
                    ),
                  );
                },
                child: Container(
                  color: Colors.transparent,
                  width: 200,
                  child: Row(
                    children: [
                      Center(
                        child: Text(
                          dataList.isEmpty ? "item count: 0" : "item count: ${dataList.length}",
                        ),
                      ),
                      Expanded(child: SizedBox()),
                      Icon(Icons.arrow_forward_ios),
                    ],
                  ),
                ),
              ),
            ],
          ),
        ),
      );
    }
    return Platform.isWindows
        ? Container(
            height: 30.0 * dataList.length,
            child: Padding(
              padding: EdgeInsets.only(
                left: level * kHorizontalPadding,
                right: kHorizontalPadding,
                top: kTextFVPadding,
                bottom: kTextFVPadding,
              ),
              child: TextField(
                maxLines: dataList.length,
                controller: TextEditingController(text: _appendData(dataList)),
                style: kMainUserInputStyle,
                textInputAction: TextInputAction.done,
                enabled: true,
                readOnly: true,
                decoration: InputDecoration(
                  label: Text(
                    '${labelText}:',
                    style: kMainLabelStyle,
                  ),
                  enabledBorder: UnderlineInputBorder(
                    borderSide: BorderSide(
                      color: kDividerColor,
                      width: kDividerWidth,
                    ),
                  ),
                ),
              ),
            ),
          )
        : Container(
            height: 30.0 * dataList.length,
            color: Colors.transparent,
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Padding(
                  padding: EdgeInsets.only(top: 15, left: level * kHorizontalPadding),
                  child: Text(
                    '${labelText}:',
                    style: kMainLabelStyle,
                  ),
                ),
                Padding(
                  padding: EdgeInsets.only(left: level * kHorizontalPadding, right: kHorizontalPadding),
                  child: GestureDetector(
                    onLongPress: () {
                      Clipboard.setData(ClipboardData(text: _appendData(dataList)));
                      Fluttertoast.showToast(msg: "Copy to clipboard successful");
                    },
                    child: Text(
                      _appendData(dataList),
                      style: kMainUserInputStyle,
                    ),
                  ),
                )
              ],
            ),
          );
  }
}

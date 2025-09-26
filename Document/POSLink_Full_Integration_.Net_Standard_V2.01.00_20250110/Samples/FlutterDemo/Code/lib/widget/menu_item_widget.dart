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
import 'package:poslink2/auto_data_source/auto_data_source_common.dart';
import 'package:poslink2/res/colors.dart';
import 'package:poslink2/widget/show_menu_widget.dart';
import '../res/dimension.dart';
import 'dart:io';

class MenuItemView extends StatefulWidget {
  const MenuItemView({
    Key? key,
    this.height = kCellHeight,
    @required this.title,
    @required this.selectedCallback,
    @required this.list,
    @required this.initValue,
    @required this.menuBtnKeyString,
    @required this.level,
    @required this.type,
  }) : super(key: key);

  final String? menuBtnKeyString;
  final dynamic initValue;
  final double height;
  final String? title;
  final List<dynamic>? list;
  final Function? selectedCallback;
  final int? level;
  final int? type; // 1 request 2 response
  @override
  _MenuItemViewState createState() => _MenuItemViewState();
}

class _MenuItemViewState extends State<MenuItemView> {
  String? _selectedEnumTitle;
  @override
  void initState() {
    super.initState();
    _selectedEnumTitle = _getShowMenuString(widget.initValue!.toString());
  }

  String? _getShowMenuString(String string) {
    if (string.contains('.')) {
      List list = string.split('.');
      return list[1];
    }
    return string;
  }

  void showAlertDialog(String text) {
    showDialog<Null>(
        context: context,
        barrierDismissible: false,
        builder: (BuildContext context) {
          return new AlertDialog(
            title: new Text(
              text,
              style: kMainLabelStyle,
            ),
            content: new SingleChildScrollView(
              child: new ListBody(
                children: <Widget>[],
              ),
            ),
            actions: <Widget>[
              new TextButton(
                child: new Text(
                  'OK',
                  style: TextStyle(color: kMainColor),
                ),
                onPressed: () {
                  Navigator.of(context).pop();
                },
              ),
            ],
          );
        });
  }

  clickAction() {
    List<dynamic> tempList = [];
    for (int i = 0; i < widget.list!.length; i++) {
      Map<String, dynamic> tempMap = widget.list![i];
      tempList.add(tempMap[kData]);
    }
    showDialog(
        context: context,
        builder: (BuildContext context) {
          return ShowMenuWidget(
            data: tempList,
            title: widget.title,
            refresh: (dynamic value) {
              String? str = _getShowMenuString(value.toString());
              // if (widget.menuBtnKeyString == "Manage_Request_VasSetMerchantParametersReq-vasProgram_menubtn") {
              //   ManualManageVasPushData.vasSelectedName = str!;
              // }
              setState(() {
                _selectedEnumTitle = str;
              });
              widget.selectedCallback!(value);
            },
          );
        });
  }

  @override
  Widget build(BuildContext context) {
    if (widget.type! == 1) {
      return Platform.isWindows
          ? Container(
              width: MediaQuery.of(context).size.width,
              height: widget.height,
              child: Padding(
                padding: EdgeInsets.only(left: widget.level! * kHorizontalPadding, right: kHorizontalPadding),
                child: Row(
                  children: [
                    GestureDetector(
                      onTap: clickAction,
                      child: Text(
                        widget.title!,
                        style: kMainLabelStyle,
                      ),
                    ),
                    Container(
                      height: widget.height,
                      width: 30,
                    ),
                    Expanded(
                      child: GestureDetector(
                        onTap: clickAction,
                        child: Container(
                          color: Colors.transparent,
                          child: Row(
                            children: [
                              Expanded(
                                child: Container(
                                  alignment: Alignment.centerRight,
                                  padding: EdgeInsets.only(left: 10, right: 0),
                                  child: Text(
                                    _selectedEnumTitle!,
                                    overflow: TextOverflow.ellipsis,
                                    style: kMainUserInputStyle,
                                  ),
                                ),
                              ),
                              Icon(Icons.arrow_drop_down),
                            ],
                          ),
                        ),
                      ),
                    ),
                  ],
                ),
              ),
            )
          : InkWell(
              onTap: clickAction,
              child: Container(
                width: MediaQuery.of(context).size.width,
                height: widget.height,
                child: Padding(
                  padding: EdgeInsets.only(left: widget.level! * kHorizontalPadding, right: kHorizontalPadding),
                  child: Row(
                    children: [
                      Text(
                        widget.title!,
                        style: kMainLabelStyle,
                      ),
                      Expanded(
                        child: Container(
                          alignment: Alignment.centerRight,
                          padding: EdgeInsets.only(left: 10, right: 0),
                          child: Text(
                            _selectedEnumTitle!,
                            overflow: TextOverflow.ellipsis,
                            style: kMainUserInputStyle,
                          ),
                        ),
                      ),
                      Icon(Icons.arrow_drop_down),
                    ],
                  ),
                ),
              ),
            );
    }
    return Container(
      width: MediaQuery.of(context).size.width,
      height: widget.height,
      child: Padding(
        padding: EdgeInsets.only(left: widget.level! * kHorizontalPadding, right: kHorizontalPadding),
        child: Row(
          children: [
            Text(
              widget.title! + ':',
              style: kMainLabelStyle,
            ),
            Expanded(
              child: Container(
                  alignment: Alignment.centerRight,
                  padding: EdgeInsets.only(left: 10, right: 0),
                  child: InkWell(
                    onTap: () {
                      showAlertDialog(_getShowMenuString(widget.initValue.toString())!);
                    },
                    child: Text(
                      _getShowMenuString(widget.initValue.toString())!,
                      overflow: TextOverflow.ellipsis,
                      style: kMainUserInputStyle,
                    ),
                  )),
            )
          ],
        ),
      ),
    );
  }
}

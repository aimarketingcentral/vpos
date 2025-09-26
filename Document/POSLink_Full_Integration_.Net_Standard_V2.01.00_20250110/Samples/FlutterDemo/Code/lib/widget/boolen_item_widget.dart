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
import 'package:poslink2/res/colors.dart';
import 'package:poslink2/res/dimension.dart';
import 'dart:io';

import 'package:poslink2/widget/show_menu_widget.dart';

class BoolenItem extends StatefulWidget {
  const BoolenItem({
    Key? key,
    this.selectedCallback,
    this.value = false,
    this.type = 1,
    this.level = 0,
    this.title = '',
  }) : super(key: key);
  final bool value;
  final int type; // 1 request 2 response
  final int level;
  final String title;
  final Function? selectedCallback;
  @override
  _BoolenItemState createState() => _BoolenItemState();
}

class _BoolenItemState extends State<BoolenItem> {
  bool _selectValue = false;

  @override
  void initState() {
    // TODO: implement initState
    _selectValue = widget.value;
    super.initState();
  }

  clickAction() {
    List<dynamic> tempList = ['ON', 'OFF'];
    showDialog(
        context: context,
        builder: (BuildContext context) {
          return ShowMenuWidget(
            data: tempList,
            title: widget.title,
            refresh: (dynamic value) {
              setState(() {
                _selectValue = value == 'ON' ? true : false;
              });
              widget.selectedCallback!(_selectValue);
            },
          );
        });
  }

  @override
  Widget build(BuildContext context) {
    if (widget.type == 1) {
      return Platform.isWindows
          ? Container(
              width: MediaQuery.of(context).size.width,
              height: kCellHeight,
              child: Padding(
                padding: EdgeInsets.only(left: widget.level * kHorizontalPadding, right: kHorizontalPadding),
                child: Row(
                  children: [
                    GestureDetector(
                      onTap: clickAction,
                      child: Text(
                        widget.title,
                        style: kMainLabelStyle,
                      ),
                    ),
                    Container(
                      height: kCellHeight,
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
                                    _selectValue == true ? 'ON' : 'OFF',
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
                height: kCellHeight,
                child: Padding(
                  padding: EdgeInsets.only(left: widget.level * kHorizontalPadding, right: kHorizontalPadding),
                  child: Row(
                    children: [
                      Text(
                        widget.title,
                        style: kMainLabelStyle,
                      ),
                      Expanded(
                        child: Container(
                          alignment: Alignment.centerRight,
                          padding: EdgeInsets.only(left: 10, right: 0),
                          child: Text(
                            _selectValue == true ? 'ON' : 'OFF',
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
      /*
      return InkWell(
        onTap: () {

        },
        child: Container(
          height: kCellHeight,
          child: Padding(
            padding: EdgeInsets.only(left: widget.level * kHorizontalPadding, right: kHorizontalPadding),
            child: Row(
              children: [
                Text(
                  widget.title,
                  style: kMainLabelStyle,
                ),
                Spacer(),
                Text(
                  _selectValue == true ? 'ON' : 'OFF',
                  style: kMainUserInputStyle,
                ),
                Icon(Icons.arrow_drop_down),
              ],
            ),
          ),
        ),
      );*/
    }
    return Container(
      height: kCellHeight,
      child: Padding(
        padding: EdgeInsets.only(left: widget.level * kHorizontalPadding, right: kHorizontalPadding),
        child: Row(
          children: [
            Text(
              widget.title,
              style: kMainLabelStyle,
            ),
            Spacer(),
            Text(
              widget.value == true ? 'ON' : 'OFF',
              style: kMainUserInputStyle,
            )
          ],
        ),
      ),
    );
  }
}

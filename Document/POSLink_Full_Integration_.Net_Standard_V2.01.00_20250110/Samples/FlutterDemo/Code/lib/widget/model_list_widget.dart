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
import 'package:poslink2/res/colors.dart';
import 'package:poslink2/res/dimension.dart';
import 'package:poslink2/widget/model_list_page.dart';
import 'dart:io';

class ModelListItem extends StatefulWidget {
  const ModelListItem({
    Key? key,
    required this.propertys,
    this.level = 1,
    required this.labelText,
    this.enable = true,
    this.className = '',
    this.callback,
    this.itemList = const [],
  }) : super(key: key);
  final List<Map<String, dynamic>> propertys;
  final int level;
  final String labelText;
  final bool enable;
  final String className;
  final Function? callback;
  final List<List<Map<String, dynamic>>>? itemList;
  @override
  _ModelListItemState createState() => _ModelListItemState();
}

class _ModelListItemState extends State<ModelListItem> {
  @override
  Widget build(BuildContext context) {
    return Platform.isWindows
        ? Container(
            height: kCellHeight + 10,
            child: Padding(
              padding: EdgeInsets.only(
                left: widget.level * kHorizontalPadding,
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
                          builder: (context) => ModelListPageView(
                            needAddAction: widget.enable,
                            title: widget.labelText,
                            propertys: widget.propertys,
                            className: widget.labelText,
                            itemList: widget.itemList ?? [],
                            callback: (List<List<Map<String, dynamic>>> value) {
                              if (widget.callback != null) {
                                widget.callback!(value);
                              }
                            },
                          ),
                        ),
                      );
                    },
                    child: Text(
                      widget.labelText,
                      style: kMainLabelStyle,
                    ),
                  ),
                  Expanded(child: SizedBox()),
                  GestureDetector(
                    onTap: () async {
                      await Navigator.of(context).push(
                        MaterialPageRoute(
                          builder: (context) => ModelListPageView(
                            needAddAction: widget.enable,
                            title: widget.labelText,
                            propertys: widget.propertys,
                            className: widget.labelText,
                            itemList: widget.itemList ?? [],
                            callback: (List<List<Map<String, dynamic>>> value) {
                              if (widget.callback != null) {
                                widget.callback!(value);
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
                              widget.itemList == null ? "item count: 0" : "item count: ${widget.itemList!.length}",
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
                  builder: (context) => ModelListPageView(
                    needAddAction: widget.enable,
                    title: widget.labelText,
                    propertys: widget.propertys,
                    className: widget.labelText,
                    itemList: widget.itemList ?? [],
                    callback: (List<List<Map<String, dynamic>>> value) {
                      if (widget.callback != null) {
                        widget.callback!(value);
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
                  left: widget.level * kHorizontalPadding,
                  right: kHorizontalPadding,
                  top: kTextFVPadding,
                  bottom: kTextFVPadding,
                ),
                child: Row(
                  children: [
                    Text(
                      widget.labelText,
                      style: kMainLabelStyle,
                    ),
                    Expanded(
                      child: Center(
                        child: Text(
                          widget.itemList == null ? "item count: 0" : "item count: ${widget.itemList!.length}",
                        ),
                      ),
                    ),
                    Icon(Icons.arrow_forward_ios),
                  ],
                ),
              ),
            ),
          );
  }
}

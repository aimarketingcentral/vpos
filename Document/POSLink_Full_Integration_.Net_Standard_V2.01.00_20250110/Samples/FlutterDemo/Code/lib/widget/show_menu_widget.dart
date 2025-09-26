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
import 'dart:io';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:poslink2/log/dart_log.dart';
import 'package:poslink2/res/colors.dart';
import 'package:poslink2/res/dimension.dart';

import '../res/size_fit.dart';

class ShowMenuWidget extends StatefulWidget {
  const ShowMenuWidget({
    Key? key,
    @required this.data,
    this.title = '',
    this.refresh,
  }) : super(key: key);

  final List<dynamic>? data;
  final String? title;
  final Function? refresh;

  @override
  State<ShowMenuWidget> createState() => _ShowMenuWidgetState();
}

class _ShowMenuWidgetState extends State<ShowMenuWidget> {
  int _scrollClickLCount = 0;
  ScrollController _scrollController = ScrollController(initialScrollOffset: 0.0, keepScrollOffset: true);

  Widget _menuItem(int index, BuildContext context) {
    dynamic value = widget.data![index];
    return InkWell(
      onTap: () {
        if (widget.refresh != null) {
          widget.refresh!(value);
        }
        Navigator.of(context).pop();
      },
      child: Container(
        color: index % 2 == 0 ? Colors.black12 : Colors.black26,
        height: 40.0,
        child: Center(
          child: Text(
            _getShowMenuString(value.toString()),
          ),
        ),
      ),
    );
  }

  String _getShowMenuString(String string) {
    if (string.contains('.')) {
      List list = string.split('.');
      return list[1];
    }
    return string;
  }

  @override
  Widget build(BuildContext context) {
    return Material(
      type: MaterialType.transparency,
      child: Center(
        child: Container(
          height: _getHeight() + 50,
          // width: 300,
          constraints: BoxConstraints(
            maxWidth: 340,
          ),
          color: Colors.white,
          child: Column(
            children: [
              Container(
                color: kMainColor,
                height: 50.0,
                child: Row(
                  children: [
                    Expanded(
                      flex: 1,
                      child: Container(
                        color: Colors.transparent,
                        child: Text(
                          'admconfirm',
                          style: TextStyle(fontSize: 7, color: Colors.transparent),
                        ),
                      ),
                    ),
                    Expanded(
                      flex: 6,
                      child: Center(
                        child: GestureDetector(
                          child: Text(
                            widget.title ?? '',
                            style: TextStyle(fontWeight: FontWeight.w700, fontSize: 17, color: Colors.white),
                          ),
                        ),
                      ),
                    ),
                    Expanded(
                      flex: 1,
                      child: GestureDetector(
                        onTap: () {
                          if (_scrollClickLCount >= 1) {
                            _scrollController.animateTo(_scrollController.offset + 480, duration: Duration(milliseconds: 1000), curve: Curves.ease);
                            _scrollClickLCount = 0;
                          } else {
                            _scrollClickLCount += 1;
                          }
                        },
                        child: Container(
                          color: Colors.transparent,
                          height: 50,
                          child: Center(
                            child: Text(
                              'scroll-l-u',
                              style: TextStyle(fontWeight: FontWeight.w700, fontSize: 8, color: Colors.transparent),
                            ),
                          ),
                        ),
                      ),
                    )
                  ],
                ),
              ),
              Expanded(
                child: SizedBox(
                  child: ListView.builder(
                    controller: _scrollController,
                    itemCount: widget.data!.length,
                    itemBuilder: (context, index) {
                      return _menuItem(index, context);
                    },
                  ),
                ),
              )
            ],
          ),
        ),
      ),
    );
  }

  double _getHeight() {
    double height = widget.data!.length * 40.0;
    double max = MediaQuery.of(context).size.height - 300;
    if (height >= max) {
      height = max;
    }
    return height;
  }
}

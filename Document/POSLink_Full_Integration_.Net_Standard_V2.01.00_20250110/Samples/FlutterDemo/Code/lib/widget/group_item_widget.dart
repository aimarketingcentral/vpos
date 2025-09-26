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

import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';
import 'package:poslink2/auto_data_source/auto_data_source_common.dart';
import 'package:poslink2/log/dart_log.dart';
import 'package:poslink2/res/colors.dart';
import 'package:poslink2/res/dimension.dart';
import 'dart:io';

class GroupItem extends StatefulWidget {
  const GroupItem({
    Key? key,
    @required this.open,
    @required this.groupName,
    @required this.level,
    @required this.groupInfoCallback,
    this.type,
    this.bitmapSign,
    this.refreshBitmapSwitch,
  }) : super(key: key);

  final bool? open;
  final String? groupName;
  final Function? groupInfoCallback;
  final int? type; // 1 request 2 response
  final bool? bitmapSign;
  final int? level;
  final Function? refreshBitmapSwitch;
  @override
  _GroupItemState createState() => _GroupItemState();
}

class _GroupItemState extends State<GroupItem> {
  bool? _bitmapSign;
  late double _reqLeftPadding;
  late double _rightPadding;
  @override
  void initState() {
    _bitmapSign = widget.bitmapSign;
    _reqLeftPadding = _getPadding();
    _rightPadding = _getPadding();

    super.initState();
  }

  double _getPadding() {
    if (_bitmapSign == null) {
      return widget.level! * kArrowLeadingHorizontalPadding;
    } else {
      if (_bitmapSign == true) {
        return widget.level! * kArrowLeadingHorizontalPadding;
      }
      return widget.level! * kHorizontalPadding;
    }
  }

  Icon _arrowIcon() {
    return Icon(widget.open == true ? Icons.arrow_drop_down : Icons.arrow_right);
  }

  Text _title() {
    return Text(
      widget.groupName!,
      style: kMainLabelStyle,
    );
  }

  Widget _switch(bool open) {
    return Stack(
      alignment: Alignment.center,
      children: [
        Switch(
          value: _bitmapSign!,
          onChanged: (value) {
            // if (_bitmapSign != null) {
            //   setState(() {
            //     _bitmapSign = !_bitmapSign!;
            //     _reqLeftPadding = _getPadding();
            //     _rightPadding = _getPadding();
            //   });
            // }
            // if (widget.refreshBitmapSwitch != null) {
            //   widget.refreshBitmapSwitch!(value);
            // }
          },
        ),
        GestureDetector(
          onTap: () {
            setState(() {
              _bitmapSign = !_bitmapSign!;
              _reqLeftPadding = _getPadding();
              _rightPadding = _getPadding();
            });
            if (widget.refreshBitmapSwitch != null) {
              widget.refreshBitmapSwitch!(_bitmapSign);
            }
          },
          child: Container(
            height: 30,
            width: 50,
            color: Colors.transparent,
            child: Text(
              'sw' + widget.groupName!.substring(0, 3),
              style: TextStyle(color: Colors.transparent),
            ),
          ),
        ),
      ],
    );
    // return Switch(
    //   value: open,
    //   onChanged: (value) {
    //     if (_bitmapSign != null) {
    //       setState(() {
    //         _bitmapSign = !_bitmapSign!;
    //         _reqLeftPadding = _getPadding();
    //         _rightPadding = _getPadding();
    //       });
    //     }
    //     if (widget.refreshBitmapSwitch != null) {
    //       widget.refreshBitmapSwitch!(value);
    //     }
    //   },
    // );
  }

  @override
  Widget build(BuildContext context) {
    if (widget.type == 1) {
      List<Widget> reqWidgetList = [];
      if (_bitmapSign == null) {
        reqWidgetList.add(_arrowIcon());
        reqWidgetList.add(_title());
      } else {
        if (_bitmapSign == true) {
          reqWidgetList.add(_arrowIcon());
          reqWidgetList.add(_title());
          reqWidgetList.add(Spacer());
          reqWidgetList.add(_switch(true));
        } else {
          reqWidgetList.add(_title());
          reqWidgetList.add(Spacer());
          reqWidgetList.add(_switch(false));
        }
      }

      return Container(
        height: kCellHeight,
        child: Padding(
          padding: EdgeInsets.only(left: _reqLeftPadding, right: kHorizontalPadding),
          child: InkWell(
            onTap: () {
              if (widget.bitmapSign == null) {
                widget.groupInfoCallback!();
              }
            },
            child: Row(
              children: reqWidgetList,
            ),
          ),
        ),
      );
    }

    List<Widget> rspWidgetList = [];
    if (_bitmapSign == null) {
      rspWidgetList.add(_arrowIcon());
      rspWidgetList.add(_title());
    } else {
      if (_bitmapSign == true) {
        rspWidgetList.add(_arrowIcon());
        rspWidgetList.add(_title());
      } else {
        rspWidgetList.add(_title());
      }
    }

    return Container(
      height: kCellHeight,
      child: Padding(
        padding: EdgeInsets.only(left: _rightPadding, right: kHorizontalPadding),
        child: InkWell(
          onTap: () {
            widget.groupInfoCallback!();
          },
          child: Row(
            children: rspWidgetList,
          ),
        ),
      ),
    );
  }
}

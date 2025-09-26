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
import 'package:flutter/services.dart';
import 'package:fluttertoast/fluttertoast.dart';
import 'package:poslink2/res/dimension.dart';
import 'dart:io';
import '../generated/l10n.dart';
import '../res/colors.dart';

class ModelListItemAddTextView extends StatefulWidget {
  const ModelListItemAddTextView({
    Key? key,
    this.title = '',
    this.text = '',
    this.show = true,
    this.canEdit = true,
    this.callback,
    this.level = 0,
  }) : super(key: key);

  final Function? callback;
  final String? text;
  final String? title;
  final bool show;
  final bool canEdit;
  final int level;
  @override
  _ModelListItemAddTextViewState createState() => _ModelListItemAddTextViewState();
}

class _ModelListItemAddTextViewState extends State<ModelListItemAddTextView> {
  late TextEditingController _textEditingController;
  @override
  void initState() {
    _textEditingController = TextEditingController(text: widget.text!);
    _textEditingController.selection = TextSelection.fromPosition(TextPosition(offset: widget.text!.length));
    super.initState();
  }

  _buildResponseWidget() {
    return Platform.isWindows
        ? Container(
            height: kCellHeight,
            child: Padding(
              padding: EdgeInsets.only(
                left: widget.level! * kHorizontalPadding,
                right: kHorizontalPadding,
                top: kTextFVPadding,
                bottom: kDividerWidth,
              ),
              child: TextField(
                controller: TextEditingController(text: widget.text!),
                style: kMainUserInputStyle,
                textInputAction: TextInputAction.done,
                enabled: true,
                readOnly: true,
                decoration: InputDecoration(
                  label: Text(
                    '${widget.title!}:',
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
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Padding(
                  padding: EdgeInsets.only(top: 10, left: widget.level! * kHorizontalPadding),
                  child: Text(
                    '${widget.title!}:',
                    style: kMainLabelStyle,
                  ),
                ),
                Padding(
                  padding: EdgeInsets.only(left: widget.level! * kHorizontalPadding, right: kHorizontalPadding, bottom: 10),
                  child: InkWell(
                    onLongPress: () {
                      Clipboard.setData(ClipboardData(text: widget.text ?? ""));
                      // Toast.show("Copy to clipboard successful", duration: Toast.lengthShort, gravity: Toast.bottom);
                      Fluttertoast.showToast(msg: S.of(context).CopiedSuccessfully);
                    },
                    child: Text(
                      widget.text ?? "",
                      style: kMainUserInputStyle,
                    ),
                  ),
                )
              ],
            ),
          );
  }

  _buildShowWidget() {
    return widget.canEdit
        ? Container(
            child: Padding(
              padding: EdgeInsets.only(left: kHorizontalPadding, bottom: 10),
              child: TextField(
                controller: _textEditingController,
                enabled: true,
                readOnly: false,
                onChanged: (value) {
                  widget.callback!(value);
                },
                decoration: InputDecoration(
                  label: Text(
                    widget.title!,
                    style: kMainLabelStyle,
                  ),
                ),
              ),
            ),
          )
        : _buildResponseWidget();
  }

  @override
  Widget build(BuildContext context) {
    return widget.show ? _buildShowWidget() : Container();
  }
}

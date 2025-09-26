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

import 'package:contextmenu/contextmenu.dart';
import 'package:file_picker/file_picker.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:fluttertoast/fluttertoast.dart';
import 'package:poslink2/res/colors.dart';
import 'package:poslink2/res/dimension.dart';
import '../generated/l10n.dart';
import 'ios_selected_zip_widget.dart';

class InputItem extends StatefulWidget {
  const InputItem({
    @required this.level,
    @required this.labelText,
    @required this.initValue,
    @required this.updateInput,
    @required this.enable,
    this.suffixButtonTitle,
    this.attribute = 2,
    this.color,
    this.unit,
    Key? key,
  }) : super(key: key);
  final int? level;
  final String? labelText;
  final String? initValue;
  final Function? updateInput;
  final bool? enable;
  final Color? color;
  final int? attribute; // 1 number, 2 ans
  final String? suffixButtonTitle;
  final String? unit; // 单位，比如timeout字段是有单位的

  @override
  _InputItemState createState() => _InputItemState();
}

class _InputItemState extends State<InputItem> {
  late String _text;
  late TextEditingController _textEditingController;
  int _offset = 0;

  @override
  void initState() {
    _textEditingController = _refreshTextEditController(widget.initValue);
    super.initState();
  }

  TextEditingController _refreshTextEditController(String? initValue) {
    _text = initValue == null ? '' : initValue;
    TextEditingController c = TextEditingController(
      text: _text,
    );

    if (initValue != null && initValue.length > 0) {
      _offset = initValue.length;
    }
    // print('${widget.labelText}偏移量-----${_offset}');
    if (widget.enable == 1) {
      c.selection = TextSelection.fromPosition(TextPosition(offset: _offset, affinity: TextAffinity.downstream));
    }
    return c;
  }

  @override
  Widget build(BuildContext context) {
    if (widget.enable == true) {
      List<Widget> list = [
        Expanded(
          child: TextField(
            controller: _textEditingController,
            style: kMainUserInputStyle,
            textInputAction: TextInputAction.done,
            enabled: widget.enable!,
            keyboardType: widget.attribute == 1 ? TextInputType.number : TextInputType.text,
            inputFormatters: widget.attribute == 1
                ? [
                    FilteringTextInputFormatter.digitsOnly,
                    // FilteringTextInputFormatter.allow(RegExp("[0-9.]")),
                    // FilteringTextInputFormatter.allow(RegExp("[a-zA-Z]")),
                  ]
                : null,
            decoration: InputDecoration(
                label: Text(
                  widget.labelText!,
                  style: kMainLabelStyle,
                ),
                enabledBorder: UnderlineInputBorder(
                  borderSide: BorderSide(
                    color: kDividerColor,
                    width: kDividerWidth,
                  ),
                ),
                suffix: widget.unit!.isNotEmpty ? Text(widget.unit!) : null),
            onChanged: (value) {
              print('on changed ${value}');
              widget.updateInput!(value);
            },
          ),
        )
      ];
      if (widget.suffixButtonTitle != null) {
        list.add(SizedBox(
          height: 40,
          width: 80,
          child: CupertinoButton(
            padding: EdgeInsets.zero,
            color: kMainColor,
            onPressed: () async {
              if (Platform.isIOS == true) {
                showDialog(
                    context: context,
                    builder: (BuildContext context) {
                      return Material(
                        type: MaterialType.transparency,
                        child: Center(
                          child: Container(
                            height: 80,
                            width: 300,
                            color: Colors.white,
                            child: ListView.builder(
                              reverse: Platform.isWindows ? false : true,
                              itemCount: 2,
                              itemBuilder: (context, index) {
                                return InkWell(
                                  onTap: () async {
                                    if (index == 0) {
                                      await Navigator.of(context).push(
                                        MaterialPageRoute(
                                          builder: (context) => SelectIOSZipView(
                                            selectedCallBack: (value) {
                                              _textEditingController.text = value;
                                              widget.updateInput!(value);
                                            },
                                          ),
                                        ),
                                      );
                                    } else {
                                      FilePickerResult? result = await FilePicker.platform.pickFiles();
                                      if (result != null) {
                                        String? path = result.files.single.path;
                                        if (path != null && (path.endsWith('.zip') || path.endsWith('.png'))) {
                                          _textEditingController.text = path;
                                          widget.updateInput!(path);
                                        } else {
                                          Fluttertoast.showToast(msg: 'The selected file is not supported');
                                        }
                                      }
                                    }
                                    Navigator.pop(context);
                                  },
                                  child: Container(
                                    color: index % 2 == 0 ? Colors.black12 : Colors.black26,
                                    height: 40.0,
                                    child: Padding(
                                      padding: EdgeInsets.only(left: kHorizontalPadding, top: 11),
                                      child: Column(
                                        children: [
                                          Expanded(
                                            child: Text(index == 0 ? 'Select from sandbox' : 'Select from document'),
                                          )
                                        ],
                                      ),
                                    ),
                                  ),
                                );
                              },
                            ),
                          ),
                        ),
                      );
                    });
              } else {
                FilePickerResult? result = await FilePicker.platform.pickFiles();
                if (result != null) {
                  String? path = result.files.single.path;
                  if (path != null) {
                    _textEditingController.text = path;
                    widget.updateInput!(path);
                  }
                }
              }
            },
            child: Text(
              widget.suffixButtonTitle!,
              style: TextStyle(
                fontSize: 14,
                color: Colors.white,
              ),
            ),
          ),
        ));
      }
      return Container(
        height: kCellHeight,
        child: Padding(
          padding: EdgeInsets.only(
            left: widget.level! * kHorizontalPadding,
            right: kHorizontalPadding,
            top: kTextFVPadding,
            bottom: kTextFVPadding,
          ),
          child: Row(
            children: list,
          ),
        ),
      );
    } else {
      if (Platform.isWindows == true) {
        return Container(
          height: kCellHeight,
          child: Padding(
            padding: EdgeInsets.only(
              left: widget.level! * kHorizontalPadding,
              right: kHorizontalPadding,
              top: kTextFVPadding,
              bottom: kTextFVPadding,
            ),
            child: TextField(
              controller: TextEditingController(text: widget.initValue!),
              style: kMainUserInputStyle,
              textInputAction: TextInputAction.done,
              enabled: true,
              readOnly: true,
              decoration: InputDecoration(
                label: Text(
                  '${widget.labelText!}:',
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
        );
      } else {
        return _buildPhonePlatformResponseText();
      }
    }
  }

  _buildPhonePlatformResponseText() {
    return Container(
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Padding(
            padding: EdgeInsets.only(top: 25, left: widget.level! * kHorizontalPadding),
            child: Text(
              '${widget.labelText!}:',
              style: kMainLabelStyle,
            ),
          ),
          Padding(
            padding: EdgeInsets.only(left: widget.level! * kHorizontalPadding, right: kHorizontalPadding),
            child: InkWell(
              onLongPress: () {
                Clipboard.setData(ClipboardData(text: widget.initValue ?? ""));
                // Toast.show("Copy to clipboard successful", duration: Toast.lengthShort, gravity: Toast.bottom);
                Fluttertoast.showToast(msg: S.of(context).CopiedSuccessfully);
              },
              child: Text(
                widget.initValue ?? "",
                style: kMainUserInputStyle,
              ),
            ),
          )
        ],
      ),
    );
  }
}

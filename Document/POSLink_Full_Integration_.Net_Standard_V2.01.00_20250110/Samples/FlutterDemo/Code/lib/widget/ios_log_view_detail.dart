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
import 'package:flutter/gestures.dart';
import 'package:flutter/material.dart';
import 'package:poslink2/model/ios_log_view_model.dart';
import 'package:poslink2/res/dimension.dart';
import 'package:provider/provider.dart';

import '../res/colors.dart';

class IOSLogView extends StatefulWidget {
  const IOSLogView({
    Key? key,
    this.title = 'Detail',
    this.path = '',
  }) : super(key: key);
  final String? title;
  final String? path;
  @override
  _IOSLogViewState createState() => _IOSLogViewState();
}

class _IOSLogViewState extends State<IOSLogView> {
  late IOSLogViewModel viewModel;

  @override
  void initState() {
    viewModel = context.read<IOSLogViewModel>();
    if (widget.path!.length > 0) {
      viewModel.read(widget.path!);
    }

    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: kMainColor,
        elevation: 0,
        title: Text(widget.title!),
        leading: InkWell(
          onTap: () {
            viewModel.clearLog();
            Navigator.of(context).pop();
          },
          child: Icon(
            Icons.arrow_back,
          ),
        ),
      ),
      body: Consumer<IOSLogViewModel>(
        builder: (context, model, child) {
          return Padding(
            padding: EdgeInsets.only(left: kHorizontalPadding, right: kHorizontalPadding, top: 10),
            child: SelectableText(model.log),
          );
        },
      ),
    );
  }
}

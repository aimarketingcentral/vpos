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
import 'package:flutter/services.dart';
import 'package:fluttertoast/fluttertoast.dart';
import 'package:poslink2/model/android_view_model.dart';
import 'package:poslink2/res/colors.dart';
import 'package:provider/provider.dart';

import '../../res/dimension.dart';

class SendCommandView extends StatefulWidget {
  @override
  State<StatefulWidget> createState() => _SendCommandViewState();
}

class _SendCommandViewState extends State<SendCommandView> {
  late AndroidViewModel _viewModel;
  late TextEditingController _requestController;

  @override
  void initState() {
    _viewModel = context.read<AndroidViewModel>();
    _requestController = TextEditingController(text: _viewModel.request);
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Padding(
            padding: const EdgeInsets.only(
                left: kHorizontalPadding,
                right: kHorizontalPadding,
                top: kHorizontalPadding),
            child: Text(
              "Request:",
              style: kMainLabelStyle,
            ),
          ),
          Padding(
            padding: const EdgeInsets.only(
                left: kHorizontalPadding,
                right: kHorizontalPadding,
                bottom: kHorizontalPadding),
            child: TextField(
              controller: _requestController,
              style: kMainUserInputStyle,
              textInputAction: TextInputAction.done,
              decoration: InputDecoration(
                enabledBorder: UnderlineInputBorder(
                  borderSide: BorderSide(
                    color: kDividerColor,
                    width: kDividerWidth,
                  ),
                ),
              ),
              onChanged: (value) {
                _viewModel.request = value;
              },
            ),
          ),
          Row(
            children: [
              SizedBox(
                width: 5,
              ),
              Flexible(
                child: MaterialButton(
                  color: kMainColor,
                  child: Text(
                    "STX",
                    style: TextStyle(color: Colors.white),
                  ),
                  onPressed: () {
                    _viewModel.request = _viewModel.request + "[02]";
                    _requestController.text = _viewModel.request;
                    _requestController.selection =
                        TextSelection.fromPosition(TextPosition(
                      offset: _viewModel.request.length,
                    ));
                  },
                ),
              ),
              SizedBox(
                width: 5,
              ),
              Flexible(
                child: MaterialButton(
                  color: kMainColor,
                  child: Text(
                    "ETX",
                    style: TextStyle(color: Colors.white),
                  ),
                  onPressed: () {
                    _viewModel.request = _viewModel.request + "[03]";
                    _requestController.text = _viewModel.request;
                    _requestController.selection =
                        TextSelection.fromPosition(TextPosition(
                          offset: _viewModel.request.length,
                        ));
                  },
                ),
              ),
              SizedBox(
                width: 5,
              ),
              Flexible(
                child: MaterialButton(
                  color: kMainColor,
                  child: Text(
                    "FS",
                    style: TextStyle(color: Colors.white),
                  ),
                  onPressed: () {
                    _viewModel.request = _viewModel.request + "[1c]";
                    _requestController.text = _viewModel.request;
                    _requestController.selection =
                        TextSelection.fromPosition(TextPosition(
                          offset: _viewModel.request.length,
                        ));
                  },
                ),
              ),
              SizedBox(
                width: 5,
              ),
              Flexible(
                child: MaterialButton(
                  color: kMainColor,
                  child: Text(
                    "US",
                    style: TextStyle(color: Colors.white),
                  ),
                  onPressed: () {
                    _viewModel.request = _viewModel.request + "[1f]";
                    _requestController.text = _viewModel.request;
                    _requestController.selection =
                        TextSelection.fromPosition(TextPosition(
                          offset: _viewModel.request.length,
                        ));
                  },
                ),
              ),
              SizedBox(
                width: 5,
              ),
              Flexible(
                child: MaterialButton(
                  color: kMainColor,
                  child: Text(
                    "GS",
                    style: TextStyle(color: Colors.white),
                  ),
                  onPressed: () {
                    _viewModel.request = _viewModel.request + "[1d]";
                    _requestController.text = _viewModel.request;
                    _requestController.selection =
                        TextSelection.fromPosition(TextPosition(
                          offset: _viewModel.request.length,
                        ));
                  },
                ),
              ),
              SizedBox(
                width: 5,
              ),
            ],
          ),
          Padding(
            padding: const EdgeInsets.all(kHorizontalPadding),
            child: Text(
              'Note: Instead of inputting a specific value, you can use [00]-[ff] to substitute any character. For instance, use [02] to represent STX and [41] to represent A.',
            ),
          ),
          Container(
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Padding(
                  padding: const EdgeInsets.all(kHorizontalPadding),
                  child: Text(
                    'Response:',
                    style: kMainLabelStyle,
                  ),
                ),
                Padding(
                  padding: EdgeInsets.only(
                      left: kHorizontalPadding, right: kHorizontalPadding),
                  child: Consumer<AndroidViewModel>(
                      builder: (context, androidVM, child) {
                    return InkWell(
                      onLongPress: () {
                        Clipboard.setData(
                            ClipboardData(text: androidVM.response));
                        Fluttertoast.showToast(
                            msg: 'Copy to clipboard successful');
                      },
                      child: Text(
                        androidVM.response,
                        style: kMainUserInputStyle,
                      ),
                    );
                  }),
                )
              ],
            ),
          ),
        ],
      ),
    );
  }
}

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

import 'package:file_picker/file_picker.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:poslink2/auto_pigeon/poslink_sdk_log_set.dart';
import 'package:poslink2/model/comm_setting_view_model.dart';
import 'package:poslink2/model/log_setting_view_model.dart';
import 'package:poslink2/res/colors.dart';
import 'package:poslink2/widget/ios_log_view.dart';
import 'package:provider/provider.dart';

class LogSettingView extends StatefulWidget {
  @override
  State<StatefulWidget> createState() => _LogSettingViewState();
}

class _LogSettingViewState extends State<LogSettingView> {
  List<String> levelList = [
    "ERROR",
    "DEBUG",
  ];

  late CommSettingViewModel _commSettingViewModel;
  @override
  void initState() {
    super.initState();
    _commSettingViewModel = context.read<CommSettingViewModel>();
  }

  @override
  Widget build(BuildContext context) {
    return Consumer<LogSettingViewModel>(
      builder: (context, viewModel, child) {
        List<Widget> list = [];
        list.add(Row(
          children: [
            Text(
              "Enable",
              style: TextStyle(
                fontWeight: FontWeight.bold,
              ),
            ),
            Spacer(),
            Switch(
                value: viewModel.enable,
                onChanged: (bool newValue) {
                  setState(() {
                    viewModel.enable = newValue;
                  });
                })
          ],
        ));
        list.add(PopupMenuButton(
          tooltip: "",
          itemBuilder: (context) {
            return [
              PopupMenuItem(
                value: LogLevel.ERROR,
                child: Text(levelList[0]),
              ),
              PopupMenuItem(
                value: LogLevel.DEBUG,
                child: Text(levelList[1]),
              ),
            ];
          },
          onSelected: (LogLevel level) {
            viewModel.level = level;
          },
          offset: Offset(1, 30),
          child: Padding(
            padding: const EdgeInsets.symmetric(vertical: 10),
            child: Row(
              children: [
                Text(
                  "Log Level",
                  style: TextStyle(
                    fontWeight: FontWeight.bold,
                  ),
                ),
                Spacer(),
                Text(levelList[viewModel.level.index]),
                Icon(Icons.arrow_drop_down),
              ],
            ),
          ),
        ));
        list.add(TextField(
          controller: TextEditingController(text: viewModel.days.toString()),
          inputFormatters: [
            FilteringTextInputFormatter.digitsOnly,
          ],
          keyboardType: TextInputType.number,
          maxLines: null,
          textInputAction: TextInputAction.done,
          decoration: InputDecoration(
            labelText: "Log Days",
          ),
          onChanged: (String value) {
            viewModel.days = int.parse(value);
          },
          onSubmitted: (String value) {
            viewModel.days = int.parse(value);
          },
        ));
        if (!Platform.isIOS) {
          list.add(TextField(
            controller: TextEditingController(text: viewModel.fileName),
            maxLines: null,
            textInputAction: TextInputAction.done,
            decoration: InputDecoration(
              labelText: "Log File Name",
            ),
            onChanged: (String value) {
              viewModel.fileName = value;
            },
            onSubmitted: (String value) {
              viewModel.fileName = value;
            },
          ));
        }
        if (!Platform.isIOS) {
          TextEditingController pathController =
              TextEditingController(text: viewModel.filePath);
          List<Widget> pathWidgetList = [
            Expanded(
              child: TextField(
                controller: pathController,
                maxLines: null,
                textInputAction: TextInputAction.done,
                decoration: InputDecoration(
                  labelText: "Log File Path",
                ),
                onChanged: (String value) {
                  viewModel.filePath = value;
                },
                onSubmitted: (String value) {
                  viewModel.filePath = value;
                },
              ),
            )
          ];
          if (Platform.isAndroid || Platform.isWindows) {
            pathWidgetList.add(SizedBox(
              height: 40,
              width: 80,
              child: CupertinoButton(
                padding: EdgeInsets.zero,
                color: kMainColor,
                onPressed: () async {
                  FocusScope.of(context).requestFocus();
                  String? path = await FilePicker.platform.getDirectoryPath();
                  if (path != null) {
                    pathController.text = path;
                    pathController.selection = TextSelection.fromPosition(
                        TextPosition(offset: path.length));
                    viewModel.filePath = path;
                  }
                },
                child: Text(
                  "Select",
                  style: TextStyle(
                    fontSize: 14,
                    color: Colors.white,
                  ),
                ),
              ),
            ));
          }
          list.add(Row(
            children: pathWidgetList,
          ));
          if (Platform.isAndroid) {
            list.add(Container(
              height: 50,
              child: Center(
                child: Text(
                  "Empty means default path. The default path is your app default external directory.",
                  style: TextStyle(color: Colors.orange),
                ),
              ),
            ));
          }
          list.add(SizedBox(
            height: 10,
          ));
          list.add(
            Row(
              children: [
                Container(
                  color: kMainColor,
                  child: viewModel.uploading
                      ? Padding(
                          padding: const EdgeInsets.all(8.0),
                          child: CircularProgressIndicator(
                            color: Colors.white,
                          ),
                        )
                      : MaterialButton(
                          child: Text(
                            "Upload Log",
                            style: TextStyle(color: Colors.white),
                          ),
                          onPressed: () async {
                            if (Platform.isWindows) {
                              await _commSettingViewModel.setSetting();
                              bool handshakeSuccess =
                                  await _commSettingViewModel.handshake();
                              if (!handshakeSuccess) {
                                throw HandshakeException();
                              }
                            }
                            UploadResult result = await viewModel.upload();
                            showDialog(
                              context: context,
                              builder: (BuildContext context) {
                                return AlertDialog(
                                  content: Text(
                                    "isSuccessful:" +
                                        (result.isSuccessful?.toString() ??
                                            "") +
                                        ", sn:" +
                                        (result.sn?.toString() ?? "") +
                                        ", terminalUploadErrorCode:" +
                                        (result.terminalUploadErrorCode
                                                ?.toString() ??
                                            "") +
                                        ", posLinkUploadErrorCode:" +
                                        (result.posLinkUploadErrorCode
                                                ?.toString() ??
                                            ""),
                                  ),
                                  actions: [
                                    ElevatedButton(
                                      onPressed: () {
                                        Navigator.of(context).pop();
                                      },
                                      child: Text("Confirm"),
                                    )
                                  ],
                                );
                              },
                            );
                          },
                        ),
                ),
              ],
            ),
          );
        } else {
          list.add(SizedBox(height: 20));
          list.add(Container(
            color: kMainColor,
            child: MaterialButton(
              child: Text(
                "View logs",
                style: TextStyle(color: Colors.white),
              ),
              onPressed: () async {
                await Navigator.of(context).push(
                  MaterialPageRoute(
                    builder: (context) => LogDetailIOS(),
                  ),
                );
              },
            ),
          ));
        }

        return SafeArea(
          child: ListView(
            padding: EdgeInsets.symmetric(horizontal: 20),
            children: list,
          ),
        );
      },
    );
  }
}

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
import 'package:fluttertoast/fluttertoast.dart';
import 'package:poslink2/model/comm_setting_view_model.dart';
import 'package:poslink2/model/log_setting_view_model.dart';
import 'package:poslink2/res/dimension.dart';
import 'package:poslink2/widget/ios_log_view_detail.dart';
import 'package:provider/provider.dart';
import '../auto_pigeon/poslink_sdk_log_set.dart';
import '../model/ios_log_view_model.dart';
import '../res/colors.dart';
import 'dart:io';
import 'package:path_provider/path_provider.dart';

class LogDetailIOS extends StatefulWidget {
  const LogDetailIOS({Key? key}) : super(key: key);

  @override
  _LogDetailIOSState createState() => _LogDetailIOSState();
}

class _LogDetailIOSState extends State<LogDetailIOS> {
  late IOSLogViewModel viewModel;
  @override
  void initState() {
    viewModel = context.read<IOSLogViewModel>();
    viewModel.load();
    super.initState();
  }

  ///创建文件

  @override
  Widget build(BuildContext context) {
    return Consumer<CommSettingViewModel>(
      builder: (context, settingModel, child){
        return Scaffold(
          appBar: AppBar(
            backgroundColor: kMainColor,
            elevation: 0,
            title: Text('Logs'),
            leading: InkWell(
              onTap: () {
                Navigator.of(context).pop();
              },
              child: Icon(
                Icons.arrow_back,
              ),
            ),
            actions: [
              Consumer<LogSettingViewModel>(
                  builder: (context, logSettingModel, child) {
                    return logSettingModel.uploading ? Center (
                      child: Container(
                        margin: EdgeInsets.symmetric(horizontal: 10),
                        height: 20,
                        width: 20,
                        child: CircularProgressIndicator(
                          color: Colors.white,
                        ),
                      ),
                    ) : IconButton(
                      onPressed: () async {
                        logSettingModel.updateUploading(true);
                        try {
                          // handshake
                          await settingModel.setSetting();
                          bool handshakeSuccess = await settingModel.handshake();
                          if (!handshakeSuccess) {
                            throw HandshakeException();
                          }
                          // upload
                          UploadResult result = await logSettingModel.upload();

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
                        } on HandshakeException {
                          logSettingModel.updateUploading(false);
                          Fluttertoast.showToast(
                            msg:
                            "Can’t detect the target device. Please set Comm Setting, then click refresh button.",
                            toastLength: Toast.LENGTH_LONG,
                          );
                        }
                      },
                      icon: Icon(Icons.upload),
                    );
                  }
              )
            ],
          ),
          body: Consumer<IOSLogViewModel>(
            builder: (context, model, child) {
              return ListView.builder(
                itemCount: model.data!.length,
                itemBuilder: (BuildContext context, int index) {
                  String path = model.data![index];
                  print("----------" + path);
                  List arr = path.split('/');
                  String last = arr.last;
                  List arr2 = path.split('/Caches/');
                  String showPath = arr2.last;

                  return InkWell(
                    onTap: () async {
                      await Navigator.of(context).push(
                        MaterialPageRoute(
                          builder: (context) => IOSLogView(
                            title: last,
                            path: path,
                          ),
                        ),
                      );
                    },
                    child: Container(
                      height: 60,
                      child: Row(
                        children: [
                          Expanded(
                            child: Padding(
                              padding: EdgeInsets.only(left: kHorizontalPadding),
                              child: Text(showPath),
                            ),
                          ),
                          Padding(
                            padding: EdgeInsets.only(right: kHorizontalPadding),
                            child: Icon(Icons.arrow_forward_ios),
                          ),
                        ],
                      ),
                    ),
                  );
                },
              );
            },
          ),
        );
      },
    );
  }
}

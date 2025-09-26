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
import 'package:poslink2/model/base_view_model.dart';
import 'package:poslink2/model/request_db.dart';
import 'package:poslink2/model/response_db.dart';
import 'package:provider/provider.dart';

import 'base_widget.dart';

class BaseMutiCommandView extends StatelessWidget {
  const BaseMutiCommandView({
    Key? key,
    this.type = 1,
    required this.command,
    this.initData,
    this.isOtherCmdType = false,
    this.refresh,
  }) : super(key: key);
  final List<Map>? initData;
  final int? type; // 1 request 2 response
  final Command command;
  final bool? isOtherCmdType;
  final Function? refresh;

  @override
  Widget build(BuildContext context) {
    RequestDataBase requestDataBase = context.read<RequestDataBase>();
    ResponseDataBase responseDataBase = context.read<ResponseDataBase>();
    return ChangeNotifierProvider(
      create: (context) {
        BaseViewModel? model;
        model = BaseViewModel();
        if (command == Command.FULLINTEGRATION) {
          if (this.type == 1) {
            model.type = 1;
            model.initData(
              initData == null ? requestDataBase.readFullIntegrationData(requestDataBase.strCurrentCommandFullIntegration)! : initData,
              Command.FULLINTEGRATION,
            );
          } else {
            model.type = 2;
            model.initData(
              initData == null ? responseDataBase.fullIntegrationData : initData,
              Command.FULLINTEGRATION,
            );
          }
        } else if (command == Command.MANAGE) {
          if (this.type == 1) {
            model.type = 1;
            model.initData(
              initData == null ? requestDataBase.readManageData(requestDataBase.strCurrentCommandManage)! : initData,
              Command.MANAGE,
            );
          } else {
            model.type = 2;
            model.initData(
              initData == null ? responseDataBase.manageData : initData,
              Command.MANAGE,
            );
          }
        } else if (command == Command.DEVICE) {
          if (this.type == 1) {
            model.type = 1;
            model.initData(
              initData == null ? requestDataBase.readDeviceData(requestDataBase.strCurrentCommandDevice)! : initData,
              Command.DEVICE,
            );
          } else {
            model.type = 2;
            model.initData(
              initData == null ? responseDataBase.deviceData : initData,
              Command.DEVICE,
            );
          }
        } else if (command == Command.FORM) {
          if (this.type == 1) {
            model.type = 1;
            model.initData(
              initData == null ? requestDataBase.readFormData(requestDataBase.strCurrentCommandForm)! : initData,
              Command.FORM,
            );
          } else {
            model.type = 2;
            model.initData(
              initData == null ? responseDataBase.formData : initData,
              Command.FORM,
            );
          }
        } else if (command == Command.PAYLOAD) {
          if (this.type == 1) {
            model.type = 1;
            model.initData(
              initData == null ? requestDataBase.readPayloadData(requestDataBase.strCurrentCommandPayload)! : initData,
              Command.PAYLOAD,
            );
          } else {
            model.type = 2;
            model.initData(
              initData == null ? responseDataBase.payloadData : initData,
              Command.PAYLOAD,
            );
          }
        } else if (command == Command.PED) {
          if (this.type == 1) {
            model.type = 1;
            model.initData(
              initData == null ? requestDataBase.readPedData(requestDataBase.strCurrentCommandPed)! : initData,
              Command.PED,
            );
          } else {
            model.type = 2;
            model.initData(
              initData == null ? responseDataBase.pedData : initData,
              Command.PED,
            );
          }
        } else if (command == Command.CUSTOMFORMMANAGE) {
          if (this.type == 1) {
            model.type = 1;
            model.initData(
              initData == null ? requestDataBase.readCustomformmanageData(requestDataBase.strCurrentCommandCustomformmanage)! : initData,
              Command.CUSTOMFORMMANAGE,
            );
          } else {
            model.type = 2;
            model.initData(
              initData == null ? responseDataBase.customformmanageData : initData,
              Command.CUSTOMFORMMANAGE,
            );
          }
        }

        return model;
      },
      child: BaseRequestWidget(
        type: this.type,
        isOtherCmdType: this.isOtherCmdType,
        refresh: this.refresh,
      ),
    );
  }
}

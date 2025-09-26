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
import 'package:poslink2/auto_data_source/auto_data_source_common.dart';
import 'package:poslink2/auto_data_source/auto_device_request_data_source.dart';
import 'package:poslink2/auto_data_source/auto_form_request_data_source.dart';
import 'package:poslink2/auto_data_source/auto_fullintegration_request_data_source.dart';
import 'package:poslink2/auto_data_source/auto_manage_request_data_source.dart';
import 'package:poslink2/auto_data_source/auto_payload_request_data_source.dart';
import 'package:poslink2/auto_data_source/auto_ped_request_data_source.dart';
import 'package:poslink2/log/dart_log.dart';
import 'package:poslink2/model/base_view_model.dart';
import 'package:poslink2/model/comm_setting_view_model.dart';
import 'package:poslink2/model/multicommand_view_model.dart';
import 'package:poslink2/model/request_db.dart';
import 'package:poslink2/model/response_db.dart';
import 'package:poslink2/widget/base_muticommand_view.dart';
import 'package:poslink2/widget/base_widget.dart';
import 'package:provider/provider.dart';

import '../model/customformmanage_view_model.dart';
import '../model/device_view_model.dart';
import '../model/form_view_model.dart';
import '../model/full_integration_view_model.dart';
import '../model/manage_view_model.dart';
import '../model/payload_view_model.dart';
import '../model/ped_view_model.dart';
import '../res/colors.dart';

class AddMutiCommandView extends StatefulWidget {
  const AddMutiCommandView({
    Key? key,
    required this.editType,
    required this.tab,
    this.initData,
    required this.type,
    this.title,
  }) : super(key: key);

  final List<Map>? initData;
  final String tab;
  final int? editType; // 1 add and submit; 2 only check, can not edit and submit
  final int? type; // 1 request ; 2 response
  final String? title;
  @override
  _AddMutiCommandViewState createState() => _AddMutiCommandViewState();
}

class _AddMutiCommandViewState extends State<AddMutiCommandView> {
  List<Widget> actionList = [];
  late MutiCommandViewModel mutiCommandViewModel;
  late FullIntegrationViewModel fullIntegrationViewModel;
  late FormViewModel formViewModel;
  late ManageViewModel manageViewModel;
  late PedViewModel pedViewModel;
  late PayloadViewModel payloadViewModel;
  late CustomFormManageModel customFormManageModel;
  late DeviceViewModel deviceViewModel;
  late RequestDataBase requestDataBase;
  late ResponseDataBase responseDataBase;
  late CommSettingViewModel commSettingViewModel;

  List<Map>? _showData;

  String? _getShowMenuString(String string) {
    if (string.contains('.')) {
      List list = string.split('.');
      return list[1];
    }
    return string;
  }

  @override
  void initState() {
    mutiCommandViewModel = context.read<MutiCommandViewModel>();
    fullIntegrationViewModel = context.read<FullIntegrationViewModel>();
    formViewModel = context.read<FormViewModel>();
    manageViewModel = context.read<ManageViewModel>();
    pedViewModel = context.read<PedViewModel>();
    payloadViewModel = context.read<PayloadViewModel>();
    customFormManageModel = context.read<CustomFormManageModel>();
    deviceViewModel = context.read<DeviceViewModel>();
    responseDataBase = context.read<ResponseDataBase>();
    commSettingViewModel = context.read<CommSettingViewModel>();

    if (widget.type == 1 && widget.editType == 1) {
      if (widget.tab == CurrentTabEnum.TAB_FULL_INTEGRATION.stringValue) {
        _showData = _copyData(FullIntegrationReqData.initSourceData());
      } else if (widget.tab == CurrentTabEnum.TAB_MANAGE.stringValue) {
        _showData = _copyData(ManageReqData.initSourceData());
      } else if (widget.tab == CurrentTabEnum.TAB_DEVICE.stringValue) {
        _showData = _copyData(DeviceReqData.initSourceData());
      }
      // else if (widget.tab == CurrentTabEnum.TAB_PAYLOAD) {
      //   _showData = _copyData(PayloadReqData.initSourceData());
      // }
      else if (widget.tab == CurrentTabEnum.TAB_PED.stringValue) {
        _showData = _copyData(PedReqData.initSourceData());
      } else if (widget.tab == CurrentTabEnum.TAB_FORM.stringValue) {
        _showData = _copyData(FormReqData.initSourceData());
      }
    } else {
      _showData = widget.initData;
    }

    if (widget.type == 1 && widget.editType == 1) {
      actionList.add(
        IconButton(
          onPressed: () {
            setState(() {
              Fluttertoast.showToast(msg: 'success');
              Navigator.pop(context);
            });
            try {
              if (widget.tab == CurrentTabEnum.TAB_FULL_INTEGRATION.stringValue) {
                Map commandElement = _showData![0];
                FullIntegrationCommand command = commandElement[kValue];
                String? reqName = _getShowMenuString(command.toString());
                Map map = {};
                map[kName] = 'FullIntegration';
                map[kValue] = reqName ?? '';
                map[kData] = _showData!;
                map[kMenuID] = CurrentTabEnum.TAB_FULL_INTEGRATION.stringValue;
                mutiCommandViewModel.addCommand(map);
                fullIntegrationViewModel.start(commSettingViewModel, responseDataBase, _showData!, isMutiCommand: true, mutiCommandViewModel: mutiCommandViewModel);
              } else if (widget.tab == CurrentTabEnum.TAB_MANAGE.stringValue) {
                Map commandElement = _showData![0];
                ManageCommand command = commandElement[kValue];
                String? reqName = _getShowMenuString(command.toString());
                Map map = {};
                map[kName] = 'Manage';
                map[kValue] = reqName ?? '';
                map[kData] = _showData!;
                map[kMenuID] = CurrentTabEnum.TAB_MANAGE.stringValue;
                mutiCommandViewModel.addCommand(map);
                manageViewModel.startManage(commSettingViewModel, responseDataBase, _showData!, isMutiCommand: true, mutiCommandViewModel: mutiCommandViewModel);
              } else if (widget.tab == CurrentTabEnum.TAB_DEVICE.stringValue) {
                Map commandElement = _showData![0];
                DeviceCommand command = commandElement[kValue];
                String? reqName = _getShowMenuString(command.toString());
                Map map = {};
                map[kName] = 'Device';
                map[kValue] = reqName ?? '';
                map[kData] = _showData!;
                map[kMenuID] = CurrentTabEnum.TAB_DEVICE.stringValue;
                mutiCommandViewModel.addCommand(map);
                deviceViewModel.startDevice(commSettingViewModel, responseDataBase, _showData!, isMutiCommand: true, mutiCommandViewModel: mutiCommandViewModel);
              }
              // else if (widget.tab == CurrentTabEnum.TAB_PAYLOAD) {
              //   Map commandElement = _showData![0];
              //   PayloadCommand command = commandElement[kValue];
              //   String? reqName = _getShowMenuString(command.toString());
              //   Map map = {};
              //   map[kName] = 'Payload';
              //   map[kValue] = reqName ?? '';
              //   map[kData] = _showData!;
              //   map[kMenuID] = CurrentTabEnum.TAB_PAYLOAD;
              //   mutiCommandViewModel.addCommand(map);
              //   payloadViewModel.startPayload(commSettingViewModel, responseDataBase, _showData!, isMutiCommand: true, mutiCommandViewModel: mutiCommandViewModel);
              // }
              else if (widget.tab == CurrentTabEnum.TAB_PED.stringValue) {
                Map commandElement = _showData![0];
                PedCommand command = commandElement[kValue];
                String? reqName = _getShowMenuString(command.toString());
                Map map = {};
                map[kName] = 'PED';
                map[kValue] = reqName ?? '';
                map[kData] = _showData!;
                map[kMenuID] = CurrentTabEnum.TAB_PED.stringValue;
                mutiCommandViewModel.addCommand(map);
                pedViewModel.startPed(commSettingViewModel, responseDataBase, _showData!, isMutiCommand: true, mutiCommandViewModel: mutiCommandViewModel);
              } else if (widget.tab == CurrentTabEnum.TAB_FORM.stringValue) {
                Map commandElement = _showData![0];
                FormCommand command = commandElement[kValue];
                String? reqName = _getShowMenuString(command.toString());
                Map map = {};
                map[kName] = 'Form';
                map[kValue] = reqName ?? '';
                map[kData] = _showData!;
                map[kMenuID] = CurrentTabEnum.TAB_FORM.stringValue;
                mutiCommandViewModel.addCommand(map);
                formViewModel.startForm(commSettingViewModel, responseDataBase, _showData!, isMutiCommand: true, mutiCommandViewModel: mutiCommandViewModel);
              }
            } catch (e, stackTrace) {
              print(e);
              print(stackTrace);
              showMsg(e.toString());
            }
            setState(() {});
          },
          icon: Icon(Icons.check),
        ),
      );
    }

    super.initState();
  }

  List<Map> _copyData(List<Map> list) {
    List<Map> copyList = [];
    for (var item in list) {
      copyList.add(Map.from(item));
    }
    return copyList;
  }

  Widget _getBody() {
    /// request
    if (widget.type == 1) {
      if (widget.editType == 1) {
        if (widget.tab == CurrentTabEnum.TAB_FULL_INTEGRATION.stringValue) {
          return BaseMutiCommandView(
            type: widget.type,
            command: Command.FULLINTEGRATION,
            initData: _showData,
            isOtherCmdType: true,
            refresh: (value) {
              setState(() {
                _showData = value;
              });
            },
          );
        } else if (widget.tab == CurrentTabEnum.TAB_MANAGE.stringValue) {
          return BaseMutiCommandView(
            type: widget.type,
            command: Command.MANAGE,
            initData: _showData,
            isOtherCmdType: true,
            refresh: (value) {
              setState(() {
                _showData = value;
              });
            },
          );
        } else if (widget.tab == CurrentTabEnum.TAB_DEVICE.stringValue) {
          return BaseMutiCommandView(
            type: widget.type,
            command: Command.DEVICE,
            initData: _showData,
            isOtherCmdType: true,
            refresh: (value) {
              setState(() {
                _showData = value;
              });
            },
          );
        }
        // else if (widget.tab == CurrentTabEnum.TAB_PAYLOAD) {
        //   return BaseView(
        //     type: widget.type,
        //     command: Command.PAYLOAD,
        //     initData: _showData,
        //     isOtherCmdType: true,
        //     refresh: (value) {
        //       setState(() {
        //         _showData = value;
        //       });
        //     },
        //   );
        // }
        else if (widget.tab == CurrentTabEnum.TAB_PED.stringValue) {
          return BaseMutiCommandView(
            type: widget.type,
            command: Command.PED,
            initData: _showData,
            isOtherCmdType: true,
            refresh: (value) {
              setState(() {
                _showData = value;
              });
            },
          );
        } else if (widget.tab == CurrentTabEnum.TAB_FORM.stringValue) {
          return BaseMutiCommandView(
            type: widget.type,
            command: Command.FORM,
            initData: _showData,
            isOtherCmdType: true,
            refresh: (value) {
              setState(() {
                _showData = value;
              });
            },
          );
        } else {
          return Center(child: Text('null'));
        }
      } else {
        if (widget.tab == CurrentTabEnum.TAB_FULL_INTEGRATION.stringValue) {
          return BaseMutiCommandView(type: widget.type, command: Command.FULLINTEGRATION, initData: widget.initData);
        } else if (widget.tab == CurrentTabEnum.TAB_MANAGE.stringValue) {
          return BaseMutiCommandView(type: widget.type, command: Command.MANAGE, initData: widget.initData);
        } else if (widget.tab == CurrentTabEnum.TAB_DEVICE.stringValue) {
          return BaseMutiCommandView(type: widget.type, command: Command.DEVICE, initData: widget.initData);
        }
        // else if (widget.tab == CurrentTabEnum.TAB_PAYLOAD) {
        //   return BaseView(type: widget.type, command: Command.PAYLOAD, initData: widget.initData);
        // }
        else if (widget.tab == CurrentTabEnum.TAB_PED.stringValue) {
          return BaseMutiCommandView(type: widget.type, command: Command.PED, initData: widget.initData);
        } else if (widget.tab == CurrentTabEnum.TAB_FORM.stringValue) {
          return BaseMutiCommandView(type: widget.type, command: Command.FORM, initData: widget.initData);
        } else {
          return Center(child: Text('null'));
        }
      }
    } else {
      if (widget.tab == CurrentTabEnum.TAB_FULL_INTEGRATION.stringValue) {
        return BaseMutiCommandView(type: widget.type, command: Command.FULLINTEGRATION, initData: widget.initData);
      } else if (widget.tab == CurrentTabEnum.TAB_MANAGE.stringValue) {
        return BaseMutiCommandView(type: widget.type, command: Command.MANAGE, initData: widget.initData);
      } else if (widget.tab == CurrentTabEnum.TAB_DEVICE.stringValue) {
        return BaseMutiCommandView(type: widget.type, command: Command.DEVICE, initData: widget.initData);
      }
      // else if (widget.tab == CurrentTabEnum.TAB_PAYLOAD) {
      //   return BaseView(type: widget.type, command: Command.PAYLOAD, initData: widget.initData);
      // }
      else if (widget.tab == CurrentTabEnum.TAB_PED.stringValue) {
        return BaseMutiCommandView(type: widget.type, command: Command.PED, initData: widget.initData);
      } else if (widget.tab == CurrentTabEnum.TAB_FORM.stringValue) {
        return BaseMutiCommandView(type: widget.type, command: Command.FORM, initData: widget.initData);
      } else {
        return Center(child: Text('null'));
      }
    }
  }

  String _getTitle() {
    if (widget.tab == CurrentTabEnum.TAB_FULL_INTEGRATION.stringValue) {
      return 'Add FullIntegration';
    } else if (widget.tab == CurrentTabEnum.TAB_MANAGE.stringValue) {
      return 'Add Manage';
    } else if (widget.tab == CurrentTabEnum.TAB_DEVICE.stringValue) {
      return 'Add Device';
    }
    // else if (widget.tab == CurrentTabEnum.TAB_PAYLOAD) {
    //   return 'Add Payload';
    // }
    else if (widget.tab == CurrentTabEnum.TAB_PED.stringValue) {
      return 'Add Ped';
    } else if (widget.tab == CurrentTabEnum.TAB_FORM.stringValue) {
      return 'Add Form';
    } else {
      return widget.tab.toString();
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: kMainColor,
        elevation: 0,
        title: Text(widget.title ?? _getTitle()),
        actions: actionList,
      ),
      body: _getBody(),
    );
  }

  void showMsg(String string) {}
}

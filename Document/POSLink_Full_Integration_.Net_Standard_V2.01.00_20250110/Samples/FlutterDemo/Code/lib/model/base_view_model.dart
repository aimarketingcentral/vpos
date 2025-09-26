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
import 'package:poslink2/auto_data_source/auto_customformmanage_request_data_source.dart';
import 'package:poslink2/auto_data_source/auto_customformmanage_response_data_source.dart';
import 'package:poslink2/auto_data_source/auto_data_source_common.dart';
import 'package:poslink2/auto_data_source/auto_fullintegration_request_data_source.dart';
import 'package:poslink2/auto_data_source/auto_fullintegration_response_data_source.dart';
import 'package:poslink2/auto_data_source/auto_manage_request_data_source.dart';
import 'package:poslink2/auto_data_source/auto_manage_response_data_source.dart';
import 'package:poslink2/log/dart_log.dart';
import 'package:poslink2/model/request_db.dart';
import 'package:poslink2/model/response_db.dart';
import 'package:provider/src/provider.dart';

import '../auto_data_source/auto_device_request_data_source.dart';
import '../auto_data_source/auto_device_response_data_source.dart';
import '../auto_data_source/auto_form_request_data_source.dart';
import '../auto_data_source/auto_form_response_data_source.dart';
import '../auto_data_source/auto_payload_request_data_source.dart';
import '../auto_data_source/auto_payload_response_data_source.dart';
import '../auto_data_source/auto_ped_request_data_source.dart';
import '../auto_data_source/auto_ped_response_data_source.dart';

enum Command {
  MANAGE,
  DEVICE,
  FORM,
  PAYLOAD,
  PED,
  FULLINTEGRATION,
  CUSTOMFORMMANAGE,
  MUTICOMMAND,
}

class BaseViewModel extends ChangeNotifier {
  Command _command = Command.FULLINTEGRATION;

  /// 1 request 2 response
  int? type;
  List<Map>? _dataSource;
  List<Map>? _showSource;

  void initData(List<Map>? list, Command command) {
    if (_dataSource == null) {
      _dataSource = list;
      _command = command;
      _updateShowList();
    }
  }

  set setDataSource(List<Map>? value) {
    _dataSource = value;
    _updateShowList();
  }

  get copyDataSource {
    List<Map> temp = copyWithList(_dataSource!);
    return temp;
  }

  refresh() {
    notifyListeners();
  }

  void refreshWhenBitmapSwitchClicked(int selectLevel, String id) {
    refreshShow(selectLevel, id, 2);
  }

  void refreshWhenGroupClicked(int selectLevel, String id) {
    refreshShow(selectLevel, id, 1);
  }

  void refreshShow(int selectLevel, String id, int type) {
    Log.v('刷新');
    bool thisGroupSatus = false;
    List<Map<String, dynamic>> subGroupStatus = [];
    for (int i = 0; i < _dataSource!.length; i++) {
      Map map = _dataSource![i];
      if (map[kType] == DataItemType.Group && map[kID] == id) {
        map[kGroupArrowOpen] = !map[kGroupArrowOpen];
        thisGroupSatus = map[kGroupArrowOpen];
      }

      if (map[kLevel] == 1) {
        map[kShow] = true;
      } else {
        String currentId = map[kID];
        if (currentId.contains(id) && map[kLevel] >= selectLevel + 1) {
          if (thisGroupSatus == false) {
            map[kShow] = thisGroupSatus;
          } else {
            if (map[kType] == DataItemType.Group) {
              map[kShow] = true;
              subGroupStatus.add({'id': map[kID], 'status': map[kGroupArrowOpen] == true ? '1' : '0'}); // 把状态记录下来
            } else {
              String thisID = map[kID];
              String thisName = map[kName];
              String prefixID = thisID.substring(0, thisID.length - thisName.length - 1);
              bool subGroupStatu = true;
              for (int j = 0; j < subGroupStatus.length; j++) {
                Map element = subGroupStatus[j];
                if (element['id'] == prefixID) {
                  // map是从属于某个子Group,应该遵从子Group的状态
                  subGroupStatu = element['status'] == '1' ? true : false;
                  break;
                }
              }
              map[kShow] = subGroupStatu;
            }
          }
        }
      }
    }
    _updateShowList();
  }

  // needUpdateReqDataBase is for multi-command
  void updateValue(String saveKey, String id, dynamic value, RequestDataBase requestDataBase, bool needUpdateReqDataBase) {
    if (value.runtimeType == ManageCommand) return;
    if (value.runtimeType == FormCommand) return;
    if (value.runtimeType == DeviceCommand) return;
    if (value.runtimeType == PayloadCommand) return;
    if (value.runtimeType == PedCommand) return;
    if (value.runtimeType == FullIntegrationCommand) return;
    if (value.runtimeType == CustomFormManageCommand) return;

    /// update _dataSource
    // for (int i = 0; i < _dataSource!.length; i++) {
    //   Map element = _dataSource![i];
    //   if (element[kID] == id) {
    //     element[kValue] = value;
    //     break;
    //   }
    // }
    _updateShowList();
    if (needUpdateReqDataBase == true) {
      if (_command == Command.FULLINTEGRATION) {
        requestDataBase.saveFullIntegrationData(saveKey, _dataSource);
      } else if (_command == Command.MANAGE) {
        requestDataBase.saveManageData(saveKey, _dataSource);
      } else if (_command == Command.CUSTOMFORMMANAGE) {
        requestDataBase.saveCustomformmanageData(saveKey, _dataSource);
      } else if (_command == Command.DEVICE) {
        requestDataBase.saveDeviceData(saveKey, _dataSource);
      } else if (_command == Command.FORM) {
        requestDataBase.saveFormData(saveKey, _dataSource);
      } else if (_command == Command.PAYLOAD) {
        requestDataBase.savePayloadData(saveKey, _dataSource);
      } else if (_command == Command.PED) {
        requestDataBase.savePedData(saveKey, _dataSource);
      }
    }
  }

  List<Map> copyWithList(List<Map> list) {
    List<Map> copyList = [];
    for (var item in list) {
      copyList.add(Map.from(item));
      /* mutable copy
      if (item is Map) {
        copyList.add(Map.from(item));
      } else if (item is List) {
        copyList.add(copyWithList(item));
      } else {
        copyList.add(item);
      }
      */
    }
    return copyList;
  }

  // needUpdateReqDataBase=true表示不是在Muti-command状态
  void checkCmd(BuildContext context, String id, dynamic value, String saveKey, bool needUpdateReqDataBase) {
    RequestDataBase requestDataBase = context.read<RequestDataBase>();
    ResponseDataBase responseDataBase = context.read<ResponseDataBase>();

    switch (value.runtimeType) {
      case FullIntegrationCommand:

        /// 判断是否已经有数据
        List<Map>? currentCommandData = requestDataBase.readFullIntegrationData(requestDataBase.strCurrentCommandFullIntegration);
        List<Map>? requestList;
        if (currentCommandData == null) {
          requestList = FullIntegrationReqData.queryDataByString(value.toString())!;
        } else {
          requestList = currentCommandData;
        }

        /// multi-command状态
        if (needUpdateReqDataBase == false) {
          Map cmdMap = requestList[0];
          cmdMap[kValue] = value;
        }

        /// 非multi-command状态 需要更新响应数据
        _dataSource = requestList;
        if (needUpdateReqDataBase == true) {
          /// 请求
          Map firstMap = _dataSource!.first;
          firstMap[kValue] = value;
          requestDataBase.saveFullIntegrationData(saveKey, requestList);

          /// 响应
          List<Map> rspList = FullIntegrationRspData.queryDataByString(value.toString())!;
          responseDataBase.setFullIntegrationData = rspList;
          responseDataBase.refresh(rspList, Command.FULLINTEGRATION);
        }

        break;

      case ManageCommand:

        /// 获取数据源
        List<Map>? requestList;
        List<Map>? currentCommandData = requestDataBase.readManageData(requestDataBase.strCurrentCommandManage);
        if (currentCommandData == null) {
          requestList = ManageReqData.queryDataByString(value.toString())!;
        } else {
          requestList = currentCommandData;
        }

        /// multi-command状态
        if (needUpdateReqDataBase == false) {
          Map cmdMap = requestList[0];
          cmdMap[kValue] = value;
        }

        /// 非multi-command状态 需要更新响应数据
        _dataSource = requestList;
        if (needUpdateReqDataBase == true) {
          Map firstMap = _dataSource!.first;
          firstMap[kValue] = value;
          requestDataBase.saveManageData(saveKey, requestList);

          /// response
          List<Map> rspList = ManageRspData.queryDataByString(value.toString())!;
          responseDataBase.setManageData = rspList;
          responseDataBase.refresh(rspList, Command.MANAGE);
        }

        break;

      case CustomFormManageCommand:

        /// 获取数据源
        List<Map>? requestList;
        List<Map>? currentCommandData = requestDataBase.readFormData(requestDataBase.strCurrentCommandForm);
        if (currentCommandData == null) {
          requestList = CustomFormManageReqData.queryDataByString(value.toString())!;
        } else {
          requestList = currentCommandData;
        }

        /// multi-command状态
        if (needUpdateReqDataBase == false) {
          Map cmdMap = requestList[0];
          cmdMap[kValue] = value;
        }

        /// 非multi-command状态 需要更新响应数据
        _dataSource = requestList;
        if (needUpdateReqDataBase == true) {
          Map firstMap = _dataSource!.first;
          firstMap[kValue] = value;
          requestDataBase.saveCustomformmanageData(saveKey, requestList);

          /// response
          List<Map> rspList = CustomFormManageRspData.queryDataByString(value.toString())!;
          responseDataBase.setCustomformmanageData = rspList;
          responseDataBase.refresh(rspList, Command.CUSTOMFORMMANAGE);
        }

        break;

      case DeviceCommand:

        /// 获取数据源
        List<Map>? requestList;
        List<Map>? currentCommandData = requestDataBase.readDeviceData(requestDataBase.strCurrentCommandDevice);
        if (currentCommandData == null) {
          requestList = DeviceReqData.queryDataByString(value.toString())!;
        } else {
          requestList = currentCommandData;
        }

        /// multi-command状态
        if (needUpdateReqDataBase == false) {
          Map cmdMap = requestList[0];
          cmdMap[kValue] = value;
        }

        /// 非multi-command状态 需要更新响应数据
        _dataSource = requestList;
        if (needUpdateReqDataBase == true) {
          Map firstMap = _dataSource!.first;
          firstMap[kValue] = value;
          requestDataBase.saveDeviceData(saveKey, requestList);

          /// response
          List<Map> rspList = DeviceRspData.queryDataByString(value.toString())!;
          responseDataBase.setDeviceData = rspList;
          responseDataBase.refresh(rspList, Command.DEVICE);
        }

        break;
      case FormCommand:

        /// 获取数据源
        List<Map>? requestList;
        List<Map>? currentCommandData = requestDataBase.readFormData(requestDataBase.strCurrentCommandForm);
        if (currentCommandData == null) {
          requestList = FormReqData.queryDataByString(value.toString())!;
        } else {
          requestList = currentCommandData;
        }

        /// multi-command状态
        if (needUpdateReqDataBase == false) {
          Map cmdMap = requestList[0];
          cmdMap[kValue] = value;
        }

        /// 非multi-command状态 需要更新响应数据
        _dataSource = requestList;
        if (needUpdateReqDataBase == true) {
          Map firstMap = _dataSource!.first;
          firstMap[kValue] = value;
          requestDataBase.saveFormData(saveKey, requestList);

          /// response
          List<Map> rspList = FormRspData.queryDataByString(value.toString())!;
          responseDataBase.setFormData = rspList;
          responseDataBase.refresh(rspList, Command.FORM);
        }

        break;

      case PayloadCommand:

        /// 获取数据源
        List<Map>? requestList;
        List<Map>? currentCommandData = requestDataBase.readPayloadData(requestDataBase.strCurrentCommandPayload);
        if (currentCommandData == null) {
          requestList = PayloadReqData.queryDataByString(value.toString())!;
        } else {
          requestList = currentCommandData;
        }

        /// multi-command状态
        if (needUpdateReqDataBase == false) {
          Map cmdMap = requestList[0];
          cmdMap[kValue] = value;
        }

        /// 非multi-command状态 需要更新响应数据
        _dataSource = requestList;
        if (needUpdateReqDataBase == true) {
          Map firstMap = _dataSource!.first;
          firstMap[kValue] = value;
          requestDataBase.savePayloadData(saveKey, requestList);

          /// response
          List<Map> rspList = PayloadRspData.queryDataByString(value.toString())!;
          responseDataBase.setPayloadData = rspList;
          responseDataBase.refresh(rspList, Command.PAYLOAD);
        }

        break;
      case PedCommand:

        /// 获取数据源
        List<Map>? requestList;
        List<Map>? currentCommandData = requestDataBase.readPedData(requestDataBase.strCurrentCommandPed);
        if (currentCommandData == null) {
          requestList = PedReqData.queryDataByString(value.toString())!;
        } else {
          requestList = currentCommandData;
        }

        /// multi-command状态
        if (needUpdateReqDataBase == false) {
          Map cmdMap = requestList[0];
          cmdMap[kValue] = value;
        }

        /// 非multi-command状态 需要更新响应数据
        _dataSource = requestList;
        if (needUpdateReqDataBase == true) {
          Map firstMap = _dataSource!.first;
          firstMap[kValue] = value;
          requestDataBase.savePedData(saveKey, requestList);

          /// response
          List<Map> rspList = PedRspData.queryDataByString(value.toString())!;
          responseDataBase.setPedData = rspList;
          responseDataBase.refresh(rspList, Command.PED);
        }
        break;
      default:
        break;
    }
    _updateShowList();
  }

  get showList {
    return _showSource;
  }

  get dataSource {
    return _dataSource;
  }

  void notifiy() {
    notifyListeners();
  }

  void _updateShowList() {
    List<Map> list = [];
    _dataSource!.forEach((element) {
      if (element[kShow] == true) {
        list.add(element);
      }
    });
    _showSource = list;
    notifyListeners();
  }

  @override
  void dispose() {
    super.dispose();
  }
}

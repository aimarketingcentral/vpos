/*
 * ============================================================================
 * = COPYRIGHT
 *          PAX Computer Technology(Shenzhen) Co., Ltd. PROPRIETARY INFORMATION
 *   This software is supplied under the terms of a license agreement or nondisclosure
 *   agreement with PAX Computer Technology(Shenzhen) Co., Ltd. and may not be copied or
 *   disclosed except in accordance with the terms in that agreement.
 *     Copyright (C) 2023 PAX Computer Technology(Shenzhen) Co., Ltd. All rights reserved.
 * ============================================================================
 */

import 'auto_data_source_common.dart';
import 'package:poslink2/auto_pigeon/poslink_sdk_customformmanage.dart';
import 'package:poslink2/auto_data_source/auto_query.dart';
class CustomFormManageReqData {
  static List<Map> initSourceData() {
    return CustomFormManageReqData.getFormListData();
  }
  static List<Map> getFormListData() {
      return [
              {
                kEnable: true,
                kLevel: 1,
                kName: 'CustomFormManageCommand',
                kID: 'CustomFormManageCommand',
                kMenuID: 'CustomFormManageCommand_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: CustomFormManageCommand.GetFormListRequest,
                kData: [
                  {
                    kData: CustomFormManageCommand.GetFormListRequest,
                    kID: 'CustomFormManageCommand_GetFormListRequest',
                  },
                  {
                    kData: CustomFormManageCommand.GetVarListRequest,
                    kID: 'CustomFormManageCommand_GetVarListRequest',
                  },
                  {
                    kData: CustomFormManageCommand.SetVarListRequest,
                    kID: 'CustomFormManageCommand_SetVarListRequest',
                  },
                  {
                    kData: CustomFormManageCommand.RunFormRequest,
                    kID: 'CustomFormManageCommand_RunFormRequest',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'formType',
                kID: 'CustomFormManage_Request_GetFormListRequest-formType',
                kMenuID: 'CustomFormManage_Request_GetFormListRequest-formType_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: CustomFormManageFormType.NotSet,
                kData: [
                  {
                    kData: CustomFormManageFormType.NotSet,
                    kID: 'CustomFormManage_Request_GetFormListRequest-formType_NotSet',
                  },
                  {
                    kData: CustomFormManageFormType.External,
                    kID: 'CustomFormManage_Request_GetFormListRequest-formType_External',
                  },
                  {
                    kData: CustomFormManageFormType.Internal,
                    kID: 'CustomFormManage_Request_GetFormListRequest-formType_Internal',
                  },
                ],
              },
           ];
  }

  static CustomFormManageGetFormListRequest formGetFormListRequest(List<Map> list) {
    List<Map> queryList = [];
    queryList.addAll(list);
    CustomFormManageGetFormListRequest req = CustomFormManageGetFormListRequest();
    req.formType = RequestListModelQuery.query('CustomFormManage_Request_GetFormListRequest-formType',queryList);
    return req;
  }

  static List<Map> getVarListData() {
      return [
              {
                kEnable: true,
                kLevel: 1,
                kName: 'CustomFormManageCommand',
                kID: 'CustomFormManageCommand',
                kMenuID: 'CustomFormManageCommand_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: CustomFormManageCommand.GetFormListRequest,
                kData: [
                  {
                    kData: CustomFormManageCommand.GetFormListRequest,
                    kID: 'CustomFormManageCommand_GetFormListRequest',
                  },
                  {
                    kData: CustomFormManageCommand.GetVarListRequest,
                    kID: 'CustomFormManageCommand_GetVarListRequest',
                  },
                  {
                    kData: CustomFormManageCommand.SetVarListRequest,
                    kID: 'CustomFormManageCommand_SetVarListRequest',
                  },
                  {
                    kData: CustomFormManageCommand.RunFormRequest,
                    kID: 'CustomFormManageCommand_RunFormRequest',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'varNameList',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'CustomFormManage_Request_GetVarListRequest-varNameList',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

  static CustomFormManageGetVarListRequest formGetVarListRequest(List<Map> list) {
    List<Map> queryList = [];
    queryList.addAll(list);
    CustomFormManageGetVarListRequest req = CustomFormManageGetVarListRequest();
    req.varNameList = RequestListModelQuery.query('CustomFormManage_Request_GetVarListRequest-varNameList',queryList);
    return req;
  }

  static List<Map> setVarListData() {
      return [
              {
                kEnable: true,
                kLevel: 1,
                kName: 'CustomFormManageCommand',
                kID: 'CustomFormManageCommand',
                kMenuID: 'CustomFormManageCommand_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: CustomFormManageCommand.GetFormListRequest,
                kData: [
                  {
                    kData: CustomFormManageCommand.GetFormListRequest,
                    kID: 'CustomFormManageCommand_GetFormListRequest',
                  },
                  {
                    kData: CustomFormManageCommand.GetVarListRequest,
                    kID: 'CustomFormManageCommand_GetVarListRequest',
                  },
                  {
                    kData: CustomFormManageCommand.SetVarListRequest,
                    kID: 'CustomFormManageCommand_SetVarListRequest',
                  },
                  {
                    kData: CustomFormManageCommand.RunFormRequest,
                    kID: 'CustomFormManageCommand_RunFormRequest',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'varList',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'CustomFormManage_Request_SetVarListRequest-varList',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

  static CustomFormManageSetVarListRequest formSetVarListRequest(List<Map> list) {
    List<Map> queryList = [];
    queryList.addAll(list);
    CustomFormManageSetVarListRequest req = CustomFormManageSetVarListRequest();
    req.varList = RequestListModelQuery.query('CustomFormManage_Request_SetVarListRequest-varList',queryList);
    return req;
  }

  static List<Map> runFormData() {
      return [
              {
                kEnable: true,
                kLevel: 1,
                kName: 'CustomFormManageCommand',
                kID: 'CustomFormManageCommand',
                kMenuID: 'CustomFormManageCommand_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: CustomFormManageCommand.GetFormListRequest,
                kData: [
                  {
                    kData: CustomFormManageCommand.GetFormListRequest,
                    kID: 'CustomFormManageCommand_GetFormListRequest',
                  },
                  {
                    kData: CustomFormManageCommand.GetVarListRequest,
                    kID: 'CustomFormManageCommand_GetVarListRequest',
                  },
                  {
                    kData: CustomFormManageCommand.SetVarListRequest,
                    kID: 'CustomFormManageCommand_SetVarListRequest',
                  },
                  {
                    kData: CustomFormManageCommand.RunFormRequest,
                    kID: 'CustomFormManageCommand_RunFormRequest',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'formName',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'CustomFormManage_Request_RunFormRequest-formName',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'timeout',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '0.1s',
                kID: 'CustomFormManage_Request_RunFormRequest-timeout',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'continuousScreen',
                kID: 'CustomFormManage_Request_RunFormRequest-continuousScreen',
                kMenuID: 'CustomFormManage_Request_RunFormRequest-continuousScreen_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: CustomFormManageContinuousScreen.NotSet,
                kData: [
                  {
                    kData: CustomFormManageContinuousScreen.NotSet,
                    kID: 'CustomFormManage_Request_RunFormRequest-continuousScreen_NotSet',
                  },
                  {
                    kData: CustomFormManageContinuousScreen.Default,
                    kID: 'CustomFormManage_Request_RunFormRequest-continuousScreen_Default',
                  },
                  {
                    kData: CustomFormManageContinuousScreen.NotGoToIdleScreen,
                    kID: 'CustomFormManage_Request_RunFormRequest-continuousScreen_NotGoToIdleScreen',
                  },
                ],
              },
           ];
  }

  static CustomFormManageRunFormRequest formRunFormRequest(List<Map> list) {
    List<Map> queryList = [];
    queryList.addAll(list);
    CustomFormManageRunFormRequest req = CustomFormManageRunFormRequest();
    req.formName = RequestListModelQuery.query('CustomFormManage_Request_RunFormRequest-formName',queryList);
    req.timeout = RequestListModelQuery.query('CustomFormManage_Request_RunFormRequest-timeout',queryList);
    req.continuousScreen = RequestListModelQuery.query('CustomFormManage_Request_RunFormRequest-continuousScreen',queryList);
    return req;
  }

  static List<Map>? queryDataByString(String string) {
    List tempList = string.split('.');
    if (tempList.length < 2) { return null; }
    String tempStr = tempList[1];
    List<Map> list;
    switch (tempStr) {
      case 'GetFormListRequest':
        list = CustomFormManageReqData.getFormListData();
        break;
      case 'GetVarListRequest':
        list = CustomFormManageReqData.getVarListData();
        break;
      case 'SetVarListRequest':
        list = CustomFormManageReqData.setVarListData();
        break;
      case 'RunFormRequest':
        list = CustomFormManageReqData.runFormData();
        break;
      default:
        list = [];
        break;
    }
    return list;
  }

}

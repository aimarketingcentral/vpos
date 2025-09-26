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
class CustomFormManageRspData {
  static List<Map> initSourceData() {
    return CustomFormManageRspData.getFormListData();
  }
  static List<Map> setVarListData() {
      return [
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseCode',
                kValue: ' ',
                kID: 'CustomFormManage_Response_SetVarListResponse-responseCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseMessage',
                kValue: ' ',
                kID: 'CustomFormManage_Response_SetVarListResponse-responseMessage',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

   static void parseRspCustomFormManageSetVarListResponse(CustomFormManageSetVarListResponse rsp, List<Map> rspDataSource) {
      rspDataSource.forEach((element) {
          DataItemType itemType = element[kType];
          String id = element[kID];
          switch (itemType) {
              case DataItemType.CellInput:
                element[kValue] = CustomFormManageRspData._parseCustomFormManageSetVarListResponse(id, rsp);
                break;
              case DataItemType.Group:
                if (element[kBitmapEnable] != null) {
                    element[kBitmapEnable] = true;
                    element[kGroupArrowOpen] = true;
                }
                break;
              case DataItemType.ModelList:
                List<dynamic> map = CustomFormManageRspData._parseCustomFormManageSetVarListResponse(id, rsp) ?? [];
                element[kData] = ResponseListModelQuery.query(id, map);
                break;
              case DataItemType.Menu:
                element[kValue] = CustomFormManageRspData._parseCustomFormManageSetVarListResponse(id, rsp);
                break;
              case DataItemType.StringList:
                List<String> tempData = [];
                List<String?> resData = CustomFormManageRspData._parseCustomFormManageSetVarListResponse(id, rsp) ?? [];
                for (int i = 0; i < resData.length; i++) {
                  String str = resData[i]!;
                  tempData.add(str);
                }
                element[kData] = tempData;
                break;
            case DataItemType.Boolen:
                element[kValue] = CustomFormManageRspData._parseCustomFormManageSetVarListResponse(id, rsp);
                element[kShow] = true;
                break;
              default:
                break;
           }
        });
  }


   static dynamic _parseCustomFormManageSetVarListResponse(String id, CustomFormManageSetVarListResponse rsp) {
      dynamic result;
      switch (id) {
         case 'CustomFormManage_Response_SetVarListResponse-responseCode':
             result = rsp.responseCode;
             break;
         case 'CustomFormManage_Response_SetVarListResponse-responseMessage':
             result = rsp.responseMessage;
             break;
         default:
             break;
     }
     return result;
 }

  static List<Map> runFormData() {
      return [
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseCode',
                kValue: ' ',
                kID: 'CustomFormManage_Response_RunFormResponse-responseCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseMessage',
                kValue: ' ',
                kID: 'CustomFormManage_Response_RunFormResponse-responseMessage',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'runFormResult',
                kValue: ' ',
                kID: 'CustomFormManage_Response_RunFormResponse-runFormResult',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

   static void parseRspCustomFormManageRunFormResponse(CustomFormManageRunFormResponse rsp, List<Map> rspDataSource) {
      rspDataSource.forEach((element) {
          DataItemType itemType = element[kType];
          String id = element[kID];
          switch (itemType) {
              case DataItemType.CellInput:
                element[kValue] = CustomFormManageRspData._parseCustomFormManageRunFormResponse(id, rsp);
                break;
              case DataItemType.Group:
                if (element[kBitmapEnable] != null) {
                    element[kBitmapEnable] = true;
                    element[kGroupArrowOpen] = true;
                }
                break;
              case DataItemType.ModelList:
                List<dynamic> map = CustomFormManageRspData._parseCustomFormManageRunFormResponse(id, rsp) ?? [];
                element[kData] = ResponseListModelQuery.query(id, map);
                break;
              case DataItemType.Menu:
                element[kValue] = CustomFormManageRspData._parseCustomFormManageRunFormResponse(id, rsp);
                break;
              case DataItemType.StringList:
                List<String> tempData = [];
                List<String?> resData = CustomFormManageRspData._parseCustomFormManageRunFormResponse(id, rsp) ?? [];
                for (int i = 0; i < resData.length; i++) {
                  String str = resData[i]!;
                  tempData.add(str);
                }
                element[kData] = tempData;
                break;
            case DataItemType.Boolen:
                element[kValue] = CustomFormManageRspData._parseCustomFormManageRunFormResponse(id, rsp);
                element[kShow] = true;
                break;
              default:
                break;
           }
        });
  }


   static dynamic _parseCustomFormManageRunFormResponse(String id, CustomFormManageRunFormResponse rsp) {
      dynamic result;
      switch (id) {
         case 'CustomFormManage_Response_RunFormResponse-responseCode':
             result = rsp.responseCode;
             break;
         case 'CustomFormManage_Response_RunFormResponse-responseMessage':
             result = rsp.responseMessage;
             break;
         case 'CustomFormManage_Response_RunFormResponse-runFormResult':
             result = rsp.runFormResult;
             break;
         default:
             break;
     }
     return result;
 }

  static List<Map> getFormListData() {
      return [
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseCode',
                kValue: ' ',
                kID: 'CustomFormManage_Response_GetFormListResponse-responseCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseMessage',
                kValue: ' ',
                kID: 'CustomFormManage_Response_GetFormListResponse-responseMessage',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'formList',
                kValue: ' ',
                kID: 'CustomFormManage_Response_GetFormListResponse-formList',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

   static void parseRspCustomFormManageGetFormListResponse(CustomFormManageGetFormListResponse rsp, List<Map> rspDataSource) {
      rspDataSource.forEach((element) {
          DataItemType itemType = element[kType];
          String id = element[kID];
          switch (itemType) {
              case DataItemType.CellInput:
                element[kValue] = CustomFormManageRspData._parseCustomFormManageGetFormListResponse(id, rsp);
                break;
              case DataItemType.Group:
                if (element[kBitmapEnable] != null) {
                    element[kBitmapEnable] = true;
                    element[kGroupArrowOpen] = true;
                }
                break;
              case DataItemType.ModelList:
                List<dynamic> map = CustomFormManageRspData._parseCustomFormManageGetFormListResponse(id, rsp) ?? [];
                element[kData] = ResponseListModelQuery.query(id, map);
                break;
              case DataItemType.Menu:
                element[kValue] = CustomFormManageRspData._parseCustomFormManageGetFormListResponse(id, rsp);
                break;
              case DataItemType.StringList:
                List<String> tempData = [];
                List<String?> resData = CustomFormManageRspData._parseCustomFormManageGetFormListResponse(id, rsp) ?? [];
                for (int i = 0; i < resData.length; i++) {
                  String str = resData[i]!;
                  tempData.add(str);
                }
                element[kData] = tempData;
                break;
            case DataItemType.Boolen:
                element[kValue] = CustomFormManageRspData._parseCustomFormManageGetFormListResponse(id, rsp);
                element[kShow] = true;
                break;
              default:
                break;
           }
        });
  }


   static dynamic _parseCustomFormManageGetFormListResponse(String id, CustomFormManageGetFormListResponse rsp) {
      dynamic result;
      switch (id) {
         case 'CustomFormManage_Response_GetFormListResponse-responseCode':
             result = rsp.responseCode;
             break;
         case 'CustomFormManage_Response_GetFormListResponse-responseMessage':
             result = rsp.responseMessage;
             break;
         case 'CustomFormManage_Response_GetFormListResponse-formList':
             result = rsp.formList;
             break;
         default:
             break;
     }
     return result;
 }

  static List<Map> getVarListData() {
      return [
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseCode',
                kValue: ' ',
                kID: 'CustomFormManage_Response_GetVarListResponse-responseCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseMessage',
                kValue: ' ',
                kID: 'CustomFormManage_Response_GetVarListResponse-responseMessage',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'varList',
                kValue: ' ',
                kID: 'CustomFormManage_Response_GetVarListResponse-varList',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

   static void parseRspCustomFormManageGetVarListResponse(CustomFormManageGetVarListResponse rsp, List<Map> rspDataSource) {
      rspDataSource.forEach((element) {
          DataItemType itemType = element[kType];
          String id = element[kID];
          switch (itemType) {
              case DataItemType.CellInput:
                element[kValue] = CustomFormManageRspData._parseCustomFormManageGetVarListResponse(id, rsp);
                break;
              case DataItemType.Group:
                if (element[kBitmapEnable] != null) {
                    element[kBitmapEnable] = true;
                    element[kGroupArrowOpen] = true;
                }
                break;
              case DataItemType.ModelList:
                List<dynamic> map = CustomFormManageRspData._parseCustomFormManageGetVarListResponse(id, rsp) ?? [];
                element[kData] = ResponseListModelQuery.query(id, map);
                break;
              case DataItemType.Menu:
                element[kValue] = CustomFormManageRspData._parseCustomFormManageGetVarListResponse(id, rsp);
                break;
              case DataItemType.StringList:
                List<String> tempData = [];
                List<String?> resData = CustomFormManageRspData._parseCustomFormManageGetVarListResponse(id, rsp) ?? [];
                for (int i = 0; i < resData.length; i++) {
                  String str = resData[i]!;
                  tempData.add(str);
                }
                element[kData] = tempData;
                break;
            case DataItemType.Boolen:
                element[kValue] = CustomFormManageRspData._parseCustomFormManageGetVarListResponse(id, rsp);
                element[kShow] = true;
                break;
              default:
                break;
           }
        });
  }


   static dynamic _parseCustomFormManageGetVarListResponse(String id, CustomFormManageGetVarListResponse rsp) {
      dynamic result;
      switch (id) {
         case 'CustomFormManage_Response_GetVarListResponse-responseCode':
             result = rsp.responseCode;
             break;
         case 'CustomFormManage_Response_GetVarListResponse-responseMessage':
             result = rsp.responseMessage;
             break;
         case 'CustomFormManage_Response_GetVarListResponse-varList':
             result = rsp.varList;
             break;
         default:
             break;
     }
     return result;
 }

  static List<Map>? queryDataByString(String string) {
    List tempList = string.split('.');
    if (tempList.length < 2) { return null; }
    String tempStr = tempList[1];
    List<Map> list;
    switch (tempStr) {
      case 'GetFormListRequest':
        list = CustomFormManageRspData.getFormListData();
        break;
      case 'GetVarListRequest':
        list = CustomFormManageRspData.getVarListData();
        break;
      case 'SetVarListRequest':
        list = CustomFormManageRspData.setVarListData();
        break;
      case 'RunFormRequest':
        list = CustomFormManageRspData.runFormData();
        break;
      default:
        list = [];
        break;
    }
    return list;
  }

}

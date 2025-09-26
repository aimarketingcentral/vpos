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
import 'package:poslink2/auto_pigeon/poslink_sdk_ped.dart';
import 'package:poslink2/auto_data_source/auto_query.dart';
class PedRspData {
  static List<Map> initSourceData() {
    return PedRspData.getPedInformationData();
  }
  static List<Map> increaseKsnData() {
      return [
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseCode',
                kValue: ' ',
                kID: 'Ped_Response_IncreaseKsnResponse-responseCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseMessage',
                kValue: ' ',
                kID: 'Ped_Response_IncreaseKsnResponse-responseMessage',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'ksn',
                kValue: ' ',
                kID: 'Ped_Response_IncreaseKsnResponse-ksn',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

   static void parseRspPedIncreaseKsnResponse(PedIncreaseKsnResponse rsp, List<Map> rspDataSource) {
      rspDataSource.forEach((element) {
          DataItemType itemType = element[kType];
          String id = element[kID];
          switch (itemType) {
              case DataItemType.CellInput:
                element[kValue] = PedRspData._parsePedIncreaseKsnResponse(id, rsp);
                break;
              case DataItemType.Group:
                if (element[kBitmapEnable] != null) {
                    element[kBitmapEnable] = true;
                    element[kGroupArrowOpen] = true;
                }
                break;
              case DataItemType.ModelList:
                List<dynamic> map = PedRspData._parsePedIncreaseKsnResponse(id, rsp) ?? [];
                element[kData] = ResponseListModelQuery.query(id, map);
                break;
              case DataItemType.Menu:
                element[kValue] = PedRspData._parsePedIncreaseKsnResponse(id, rsp);
                break;
              case DataItemType.StringList:
                List<String> tempData = [];
                List<String?> resData = PedRspData._parsePedIncreaseKsnResponse(id, rsp) ?? [];
                for (int i = 0; i < resData.length; i++) {
                  String str = resData[i]!;
                  tempData.add(str);
                }
                element[kData] = tempData;
                break;
            case DataItemType.Boolen:
                element[kValue] = PedRspData._parsePedIncreaseKsnResponse(id, rsp);
                element[kShow] = true;
                break;
              default:
                break;
           }
        });
  }


   static dynamic _parsePedIncreaseKsnResponse(String id, PedIncreaseKsnResponse rsp) {
      dynamic result;
      switch (id) {
         case 'Ped_Response_IncreaseKsnResponse-responseCode':
             result = rsp.responseCode;
             break;
         case 'Ped_Response_IncreaseKsnResponse-responseMessage':
             result = rsp.responseMessage;
             break;
         case 'Ped_Response_IncreaseKsnResponse-ksn':
             result = rsp.ksn;
             break;
         default:
             break;
     }
     return result;
 }

  static List<Map> sessionKeyInjectionData() {
      return [
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseCode',
                kValue: ' ',
                kID: 'Ped_Response_SessionKeyInjectionResponse-responseCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseMessage',
                kValue: ' ',
                kID: 'Ped_Response_SessionKeyInjectionResponse-responseMessage',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

   static void parseRspPedSessionKeyInjectionResponse(PedSessionKeyInjectionResponse rsp, List<Map> rspDataSource) {
      rspDataSource.forEach((element) {
          DataItemType itemType = element[kType];
          String id = element[kID];
          switch (itemType) {
              case DataItemType.CellInput:
                element[kValue] = PedRspData._parsePedSessionKeyInjectionResponse(id, rsp);
                break;
              case DataItemType.Group:
                if (element[kBitmapEnable] != null) {
                    element[kBitmapEnable] = true;
                    element[kGroupArrowOpen] = true;
                }
                break;
              case DataItemType.ModelList:
                List<dynamic> map = PedRspData._parsePedSessionKeyInjectionResponse(id, rsp) ?? [];
                element[kData] = ResponseListModelQuery.query(id, map);
                break;
              case DataItemType.Menu:
                element[kValue] = PedRspData._parsePedSessionKeyInjectionResponse(id, rsp);
                break;
              case DataItemType.StringList:
                List<String> tempData = [];
                List<String?> resData = PedRspData._parsePedSessionKeyInjectionResponse(id, rsp) ?? [];
                for (int i = 0; i < resData.length; i++) {
                  String str = resData[i]!;
                  tempData.add(str);
                }
                element[kData] = tempData;
                break;
            case DataItemType.Boolen:
                element[kValue] = PedRspData._parsePedSessionKeyInjectionResponse(id, rsp);
                element[kShow] = true;
                break;
              default:
                break;
           }
        });
  }


   static dynamic _parsePedSessionKeyInjectionResponse(String id, PedSessionKeyInjectionResponse rsp) {
      dynamic result;
      switch (id) {
         case 'Ped_Response_SessionKeyInjectionResponse-responseCode':
             result = rsp.responseCode;
             break;
         case 'Ped_Response_SessionKeyInjectionResponse-responseMessage':
             result = rsp.responseMessage;
             break;
         default:
             break;
     }
     return result;
 }

  static List<Map> macCalculationData() {
      return [
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseCode',
                kValue: ' ',
                kID: 'Ped_Response_MacCalculationResponse-responseCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseMessage',
                kValue: ' ',
                kID: 'Ped_Response_MacCalculationResponse-responseMessage',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'resultData',
                kValue: ' ',
                kID: 'Ped_Response_MacCalculationResponse-resultData',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'ksn',
                kValue: ' ',
                kID: 'Ped_Response_MacCalculationResponse-ksn',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

   static void parseRspPedMacCalculationResponse(PedMacCalculationResponse rsp, List<Map> rspDataSource) {
      rspDataSource.forEach((element) {
          DataItemType itemType = element[kType];
          String id = element[kID];
          switch (itemType) {
              case DataItemType.CellInput:
                element[kValue] = PedRspData._parsePedMacCalculationResponse(id, rsp);
                break;
              case DataItemType.Group:
                if (element[kBitmapEnable] != null) {
                    element[kBitmapEnable] = true;
                    element[kGroupArrowOpen] = true;
                }
                break;
              case DataItemType.ModelList:
                List<dynamic> map = PedRspData._parsePedMacCalculationResponse(id, rsp) ?? [];
                element[kData] = ResponseListModelQuery.query(id, map);
                break;
              case DataItemType.Menu:
                element[kValue] = PedRspData._parsePedMacCalculationResponse(id, rsp);
                break;
              case DataItemType.StringList:
                List<String> tempData = [];
                List<String?> resData = PedRspData._parsePedMacCalculationResponse(id, rsp) ?? [];
                for (int i = 0; i < resData.length; i++) {
                  String str = resData[i]!;
                  tempData.add(str);
                }
                element[kData] = tempData;
                break;
            case DataItemType.Boolen:
                element[kValue] = PedRspData._parsePedMacCalculationResponse(id, rsp);
                element[kShow] = true;
                break;
              default:
                break;
           }
        });
  }


   static dynamic _parsePedMacCalculationResponse(String id, PedMacCalculationResponse rsp) {
      dynamic result;
      switch (id) {
         case 'Ped_Response_MacCalculationResponse-responseCode':
             result = rsp.responseCode;
             break;
         case 'Ped_Response_MacCalculationResponse-responseMessage':
             result = rsp.responseMessage;
             break;
         case 'Ped_Response_MacCalculationResponse-resultData':
             result = rsp.resultData;
             break;
         case 'Ped_Response_MacCalculationResponse-ksn':
             result = rsp.ksn;
             break;
         default:
             break;
     }
     return result;
 }

  static List<Map> getPedInformationData() {
      return [
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseCode',
                kValue: ' ',
                kID: 'Ped_Response_GetPedInformationResponse-responseCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseMessage',
                kValue: ' ',
                kID: 'Ped_Response_GetPedInformationResponse-responseMessage',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'masterAvailableKeySlotCount',
                kValue: ' ',
                kID: 'Ped_Response_GetPedInformationResponse-masterAvailableKeySlotCount',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'sessionAvailableKeySlotCount',
                kValue: ' ',
                kID: 'Ped_Response_GetPedInformationResponse-sessionAvailableKeySlotCount',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'dukptAvailableKeySlotCount',
                kValue: ' ',
                kID: 'Ped_Response_GetPedInformationResponse-dukptAvailableKeySlotCount',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'aesDukptAvailableKeySlotCount',
                kValue: ' ',
                kID: 'Ped_Response_GetPedInformationResponse-aesDukptAvailableKeySlotCount',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kID: 'Ped_Response_GetPedInformationResponse-tmk',
                kType: DataItemType.ModelList,
                kClass: 'MasterSessionKeyInformation',
                kShow: true,
                kName: 'tmk',
                kValue: [
                  {
                    kType: DataItemType.CellInput,
                    kID: 'Ped_Response_GetPedInformationResponse-tmk_keySlot',
                    kName: 'keySlot',
                  },
                  {
                    kType: DataItemType.CellInput,
                    kID: 'Ped_Response_GetPedInformationResponse-tmk_kcv',
                    kName: 'kcv',
                  },
                ],
              },
              {
                kEnable: false,
                kLevel: 1,
                kID: 'Ped_Response_GetPedInformationResponse-tpk',
                kType: DataItemType.ModelList,
                kClass: 'MasterSessionKeyInformation',
                kShow: true,
                kName: 'tpk',
                kValue: [
                  {
                    kType: DataItemType.CellInput,
                    kID: 'Ped_Response_GetPedInformationResponse-tpk_keySlot',
                    kName: 'keySlot',
                  },
                  {
                    kType: DataItemType.CellInput,
                    kID: 'Ped_Response_GetPedInformationResponse-tpk_kcv',
                    kName: 'kcv',
                  },
                ],
              },
              {
                kEnable: false,
                kLevel: 1,
                kID: 'Ped_Response_GetPedInformationResponse-tak',
                kType: DataItemType.ModelList,
                kClass: 'MasterSessionKeyInformation',
                kShow: true,
                kName: 'tak',
                kValue: [
                  {
                    kType: DataItemType.CellInput,
                    kID: 'Ped_Response_GetPedInformationResponse-tak_keySlot',
                    kName: 'keySlot',
                  },
                  {
                    kType: DataItemType.CellInput,
                    kID: 'Ped_Response_GetPedInformationResponse-tak_kcv',
                    kName: 'kcv',
                  },
                ],
              },
              {
                kEnable: false,
                kLevel: 1,
                kID: 'Ped_Response_GetPedInformationResponse-tdk',
                kType: DataItemType.ModelList,
                kClass: 'MasterSessionKeyInformation',
                kShow: true,
                kName: 'tdk',
                kValue: [
                  {
                    kType: DataItemType.CellInput,
                    kID: 'Ped_Response_GetPedInformationResponse-tdk_keySlot',
                    kName: 'keySlot',
                  },
                  {
                    kType: DataItemType.CellInput,
                    kID: 'Ped_Response_GetPedInformationResponse-tdk_kcv',
                    kName: 'kcv',
                  },
                ],
              },
              {
                kEnable: false,
                kLevel: 1,
                kID: 'Ped_Response_GetPedInformationResponse-dukptKey',
                kType: DataItemType.ModelList,
                kClass: 'DukptKeyInformation',
                kShow: true,
                kName: 'dukptKey',
                kValue: [
                  {
                    kType: DataItemType.CellInput,
                    kID: 'Ped_Response_GetPedInformationResponse-dukptKey_keySlot',
                    kName: 'keySlot',
                  },
                  {
                    kType: DataItemType.CellInput,
                    kID: 'Ped_Response_GetPedInformationResponse-dukptKey_ksn',
                    kName: 'ksn',
                  },
                  {
                    kType: DataItemType.CellInput,
                    kID: 'Ped_Response_GetPedInformationResponse-dukptKey_kcv',
                    kName: 'kcv',
                  },
                ],
              },
              {
                kEnable: false,
                kLevel: 1,
                kID: 'Ped_Response_GetPedInformationResponse-aesDukptKey',
                kType: DataItemType.ModelList,
                kClass: 'DukptKeyInformation',
                kShow: true,
                kName: 'aesDukptKey',
                kValue: [
                  {
                    kType: DataItemType.CellInput,
                    kID: 'Ped_Response_GetPedInformationResponse-aesDukptKey_keySlot',
                    kName: 'keySlot',
                  },
                  {
                    kType: DataItemType.CellInput,
                    kID: 'Ped_Response_GetPedInformationResponse-aesDukptKey_ksn',
                    kName: 'ksn',
                  },
                  {
                    kType: DataItemType.CellInput,
                    kID: 'Ped_Response_GetPedInformationResponse-aesDukptKey_kcv',
                    kName: 'kcv',
                  },
                ],
              },
           ];
  }

   static void parseRspPedGetPedInformationResponse(PedGetPedInformationResponse rsp, List<Map> rspDataSource) {
      rspDataSource.forEach((element) {
          DataItemType itemType = element[kType];
          String id = element[kID];
          switch (itemType) {
              case DataItemType.CellInput:
                element[kValue] = PedRspData._parsePedGetPedInformationResponse(id, rsp);
                break;
              case DataItemType.Group:
                if (element[kBitmapEnable] != null) {
                    element[kBitmapEnable] = true;
                    element[kGroupArrowOpen] = true;
                }
                break;
              case DataItemType.ModelList:
                List<dynamic> map = PedRspData._parsePedGetPedInformationResponse(id, rsp) ?? [];
                element[kData] = ResponseListModelQuery.query(id, map);
                break;
              case DataItemType.Menu:
                element[kValue] = PedRspData._parsePedGetPedInformationResponse(id, rsp);
                break;
              case DataItemType.StringList:
                List<String> tempData = [];
                List<String?> resData = PedRspData._parsePedGetPedInformationResponse(id, rsp) ?? [];
                for (int i = 0; i < resData.length; i++) {
                  String str = resData[i]!;
                  tempData.add(str);
                }
                element[kData] = tempData;
                break;
            case DataItemType.Boolen:
                element[kValue] = PedRspData._parsePedGetPedInformationResponse(id, rsp);
                element[kShow] = true;
                break;
              default:
                break;
           }
        });
  }


   static dynamic _parsePedGetPedInformationResponse(String id, PedGetPedInformationResponse rsp) {
      dynamic result;
      switch (id) {
         case 'Ped_Response_GetPedInformationResponse-responseCode':
             result = rsp.responseCode;
             break;
         case 'Ped_Response_GetPedInformationResponse-responseMessage':
             result = rsp.responseMessage;
             break;
         case 'Ped_Response_GetPedInformationResponse-masterAvailableKeySlotCount':
             result = rsp.masterAvailableKeySlotCount;
             break;
         case 'Ped_Response_GetPedInformationResponse-sessionAvailableKeySlotCount':
             result = rsp.sessionAvailableKeySlotCount;
             break;
         case 'Ped_Response_GetPedInformationResponse-dukptAvailableKeySlotCount':
             result = rsp.dukptAvailableKeySlotCount;
             break;
         case 'Ped_Response_GetPedInformationResponse-aesDukptAvailableKeySlotCount':
             result = rsp.aesDukptAvailableKeySlotCount;
             break;
         case 'Ped_Response_GetPedInformationResponse-tmk':
             result = rsp.tmk;
             break;
         case 'Ped_Response_GetPedInformationResponse-tpk':
             result = rsp.tpk;
             break;
         case 'Ped_Response_GetPedInformationResponse-tak':
             result = rsp.tak;
             break;
         case 'Ped_Response_GetPedInformationResponse-tdk':
             result = rsp.tdk;
             break;
         case 'Ped_Response_GetPedInformationResponse-dukptKey':
             result = rsp.dukptKey;
             break;
         case 'Ped_Response_GetPedInformationResponse-aesDukptKey':
             result = rsp.aesDukptKey;
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
      case 'GetPedInformationRequest':
        list = PedRspData.getPedInformationData();
        break;
      case 'IncreaseKsnRequest':
        list = PedRspData.increaseKsnData();
        break;
      case 'SessionKeyInjectionRequest':
        list = PedRspData.sessionKeyInjectionData();
        break;
      case 'MacCalculationRequest':
        list = PedRspData.macCalculationData();
        break;
      default:
        list = [];
        break;
    }
    return list;
  }

}

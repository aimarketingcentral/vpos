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
import 'package:poslink2/auto_pigeon/poslink_sdk_device.dart';
import 'package:poslink2/auto_data_source/auto_query.dart';
class DeviceRspData {
  static List<Map> initSourceData() {
    return DeviceRspData.mifareCardData();
  }
  static List<Map> printerData() {
      return [
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseCode',
                kValue: ' ',
                kID: 'Device_Response_PrinterResponse-responseCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseMessage',
                kValue: ' ',
                kID: 'Device_Response_PrinterResponse-responseMessage',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

   static void parseRspDevicePrinterResponse(DevicePrinterResponse rsp, List<Map> rspDataSource) {
      rspDataSource.forEach((element) {
          DataItemType itemType = element[kType];
          String id = element[kID];
          switch (itemType) {
              case DataItemType.CellInput:
                element[kValue] = DeviceRspData._parseDevicePrinterResponse(id, rsp);
                break;
              case DataItemType.Group:
                if (element[kBitmapEnable] != null) {
                    element[kBitmapEnable] = true;
                    element[kGroupArrowOpen] = true;
                }
                break;
              case DataItemType.ModelList:
                List<dynamic> map = DeviceRspData._parseDevicePrinterResponse(id, rsp) ?? [];
                element[kData] = ResponseListModelQuery.query(id, map);
                break;
              case DataItemType.Menu:
                element[kValue] = DeviceRspData._parseDevicePrinterResponse(id, rsp);
                break;
              case DataItemType.StringList:
                List<String> tempData = [];
                List<String?> resData = DeviceRspData._parseDevicePrinterResponse(id, rsp) ?? [];
                for (int i = 0; i < resData.length; i++) {
                  String str = resData[i]!;
                  tempData.add(str);
                }
                element[kData] = tempData;
                break;
            case DataItemType.Boolen:
                element[kValue] = DeviceRspData._parseDevicePrinterResponse(id, rsp);
                element[kShow] = true;
                break;
              default:
                break;
           }
        });
  }


   static dynamic _parseDevicePrinterResponse(String id, DevicePrinterResponse rsp) {
      dynamic result;
      switch (id) {
         case 'Device_Response_PrinterResponse-responseCode':
             result = rsp.responseCode;
             break;
         case 'Device_Response_PrinterResponse-responseMessage':
             result = rsp.responseMessage;
             break;
         default:
             break;
     }
     return result;
 }

  static List<Map> mifareCardData() {
      return [
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseCode',
                kValue: ' ',
                kID: 'Device_Response_MifareCardResponse-responseCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseMessage',
                kValue: ' ',
                kID: 'Device_Response_MifareCardResponse-responseMessage',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'blockValue',
                kValue: ' ',
                kID: 'Device_Response_MifareCardResponse-blockValue',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

   static void parseRspDeviceMifareCardResponse(DeviceMifareCardResponse rsp, List<Map> rspDataSource) {
      rspDataSource.forEach((element) {
          DataItemType itemType = element[kType];
          String id = element[kID];
          switch (itemType) {
              case DataItemType.CellInput:
                element[kValue] = DeviceRspData._parseDeviceMifareCardResponse(id, rsp);
                break;
              case DataItemType.Group:
                if (element[kBitmapEnable] != null) {
                    element[kBitmapEnable] = true;
                    element[kGroupArrowOpen] = true;
                }
                break;
              case DataItemType.ModelList:
                List<dynamic> map = DeviceRspData._parseDeviceMifareCardResponse(id, rsp) ?? [];
                element[kData] = ResponseListModelQuery.query(id, map);
                break;
              case DataItemType.Menu:
                element[kValue] = DeviceRspData._parseDeviceMifareCardResponse(id, rsp);
                break;
              case DataItemType.StringList:
                List<String> tempData = [];
                List<String?> resData = DeviceRspData._parseDeviceMifareCardResponse(id, rsp) ?? [];
                for (int i = 0; i < resData.length; i++) {
                  String str = resData[i]!;
                  tempData.add(str);
                }
                element[kData] = tempData;
                break;
            case DataItemType.Boolen:
                element[kValue] = DeviceRspData._parseDeviceMifareCardResponse(id, rsp);
                element[kShow] = true;
                break;
              default:
                break;
           }
        });
  }


   static dynamic _parseDeviceMifareCardResponse(String id, DeviceMifareCardResponse rsp) {
      dynamic result;
      switch (id) {
         case 'Device_Response_MifareCardResponse-responseCode':
             result = rsp.responseCode;
             break;
         case 'Device_Response_MifareCardResponse-responseMessage':
             result = rsp.responseMessage;
             break;
         case 'Device_Response_MifareCardResponse-blockValue':
             result = rsp.blockValue;
             break;
         default:
             break;
     }
     return result;
 }

  static List<Map> cardInsertDetectionData() {
      return [
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseCode',
                kValue: ' ',
                kID: 'Device_Response_CardInsertDetectionResponse-responseCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseMessage',
                kValue: ' ',
                kID: 'Device_Response_CardInsertDetectionResponse-responseMessage',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'cardInsertStatus',
                kID: 'Device_Response_CardInsertDetectionResponse-cardInsertStatus',
                kMenuID: 'Device_Response_CardInsertDetectionResponse-cardInsertStatus_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: DeviceCardInsertStatus.NotSet,
                kData: [
                  {
                    kData: DeviceCardInsertStatus.NotSet,
                    kID: 'Device_Response_CardInsertDetectionResponse-cardInsertStatus_NotSet',
                  },
                  {
                    kData: DeviceCardInsertStatus.NoCardInserted,
                    kID: 'Device_Response_CardInsertDetectionResponse-cardInsertStatus_NoCardInserted',
                  },
                  {
                    kData: DeviceCardInsertStatus.EmvCardInserted,
                    kID: 'Device_Response_CardInsertDetectionResponse-cardInsertStatus_EmvCardInserted',
                  },
                  {
                    kData: DeviceCardInsertStatus.CardInserted,
                    kID: 'Device_Response_CardInsertDetectionResponse-cardInsertStatus_CardInserted',
                  },
                ],
              },
           ];
  }

   static void parseRspDeviceCardInsertDetectionResponse(DeviceCardInsertDetectionResponse rsp, List<Map> rspDataSource) {
      rspDataSource.forEach((element) {
          DataItemType itemType = element[kType];
          String id = element[kID];
          switch (itemType) {
              case DataItemType.CellInput:
                element[kValue] = DeviceRspData._parseDeviceCardInsertDetectionResponse(id, rsp);
                break;
              case DataItemType.Group:
                if (element[kBitmapEnable] != null) {
                    element[kBitmapEnable] = true;
                    element[kGroupArrowOpen] = true;
                }
                break;
              case DataItemType.ModelList:
                List<dynamic> map = DeviceRspData._parseDeviceCardInsertDetectionResponse(id, rsp) ?? [];
                element[kData] = ResponseListModelQuery.query(id, map);
                break;
              case DataItemType.Menu:
                element[kValue] = DeviceRspData._parseDeviceCardInsertDetectionResponse(id, rsp);
                break;
              case DataItemType.StringList:
                List<String> tempData = [];
                List<String?> resData = DeviceRspData._parseDeviceCardInsertDetectionResponse(id, rsp) ?? [];
                for (int i = 0; i < resData.length; i++) {
                  String str = resData[i]!;
                  tempData.add(str);
                }
                element[kData] = tempData;
                break;
            case DataItemType.Boolen:
                element[kValue] = DeviceRspData._parseDeviceCardInsertDetectionResponse(id, rsp);
                element[kShow] = true;
                break;
              default:
                break;
           }
        });
  }


   static dynamic _parseDeviceCardInsertDetectionResponse(String id, DeviceCardInsertDetectionResponse rsp) {
      dynamic result;
      switch (id) {
         case 'Device_Response_CardInsertDetectionResponse-responseCode':
             result = rsp.responseCode;
             break;
         case 'Device_Response_CardInsertDetectionResponse-responseMessage':
             result = rsp.responseMessage;
             break;
         case 'Device_Response_CardInsertDetectionResponse-cardInsertStatus':
             result = rsp.cardInsertStatus;
             break;
         default:
             break;
     }
     return result;
 }

  static List<Map> cameraScanData() {
      return [
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseCode',
                kValue: ' ',
                kID: 'Device_Response_CameraScanResponse-responseCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseMessage',
                kValue: ' ',
                kID: 'Device_Response_CameraScanResponse-responseMessage',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'barcodeData',
                kValue: ' ',
                kID: 'Device_Response_CameraScanResponse-barcodeData',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'barcodeType',
                kID: 'Device_Response_CameraScanResponse-barcodeType',
                kMenuID: 'Device_Response_CameraScanResponse-barcodeType_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: DeviceBarcodeType.NotSet,
                kData: [
                  {
                    kData: DeviceBarcodeType.NotSet,
                    kID: 'Device_Response_CameraScanResponse-barcodeType_NotSet',
                  },
                  {
                    kData: DeviceBarcodeType.QrCode,
                    kID: 'Device_Response_CameraScanResponse-barcodeType_QrCode',
                  },
                  {
                    kData: DeviceBarcodeType.TwoDimensionalBarcode,
                    kID: 'Device_Response_CameraScanResponse-barcodeType_TwoDimensionalBarcode',
                  },
                  {
                    kData: DeviceBarcodeType.ThreeDimensionalBarcode,
                    kID: 'Device_Response_CameraScanResponse-barcodeType_ThreeDimensionalBarcode',
                  },
                ],
              },
           ];
  }

   static void parseRspDeviceCameraScanResponse(DeviceCameraScanResponse rsp, List<Map> rspDataSource) {
      rspDataSource.forEach((element) {
          DataItemType itemType = element[kType];
          String id = element[kID];
          switch (itemType) {
              case DataItemType.CellInput:
                element[kValue] = DeviceRspData._parseDeviceCameraScanResponse(id, rsp);
                break;
              case DataItemType.Group:
                if (element[kBitmapEnable] != null) {
                    element[kBitmapEnable] = true;
                    element[kGroupArrowOpen] = true;
                }
                break;
              case DataItemType.ModelList:
                List<dynamic> map = DeviceRspData._parseDeviceCameraScanResponse(id, rsp) ?? [];
                element[kData] = ResponseListModelQuery.query(id, map);
                break;
              case DataItemType.Menu:
                element[kValue] = DeviceRspData._parseDeviceCameraScanResponse(id, rsp);
                break;
              case DataItemType.StringList:
                List<String> tempData = [];
                List<String?> resData = DeviceRspData._parseDeviceCameraScanResponse(id, rsp) ?? [];
                for (int i = 0; i < resData.length; i++) {
                  String str = resData[i]!;
                  tempData.add(str);
                }
                element[kData] = tempData;
                break;
            case DataItemType.Boolen:
                element[kValue] = DeviceRspData._parseDeviceCameraScanResponse(id, rsp);
                element[kShow] = true;
                break;
              default:
                break;
           }
        });
  }


   static dynamic _parseDeviceCameraScanResponse(String id, DeviceCameraScanResponse rsp) {
      dynamic result;
      switch (id) {
         case 'Device_Response_CameraScanResponse-responseCode':
             result = rsp.responseCode;
             break;
         case 'Device_Response_CameraScanResponse-responseMessage':
             result = rsp.responseMessage;
             break;
         case 'Device_Response_CameraScanResponse-barcodeData':
             result = rsp.barcodeData;
             break;
         case 'Device_Response_CameraScanResponse-barcodeType':
             result = rsp.barcodeType;
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
      case 'MifareCardRequest':
        list = DeviceRspData.mifareCardData();
        break;
      case 'CameraScanRequest':
        list = DeviceRspData.cameraScanData();
        break;
      case 'PrinterRequest':
        list = DeviceRspData.printerData();
        break;
      case 'CardInsertDetectionRequest':
        list = DeviceRspData.cardInsertDetectionData();
        break;
      default:
        list = [];
        break;
    }
    return list;
  }

}

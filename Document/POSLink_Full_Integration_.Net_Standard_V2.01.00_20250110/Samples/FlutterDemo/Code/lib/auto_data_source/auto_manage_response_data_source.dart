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
import 'package:poslink2/auto_pigeon/poslink_sdk_manage.dart';
import 'package:poslink2/auto_data_source/auto_query.dart';
class ManageRspData {
  static List<Map> initSourceData() {
    return ManageRspData.deleteImageData();
  }
  static List<Map> setVariableData() {
      return [
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseCode',
                kValue: ' ',
                kID: 'Manage_Response_SetVariableResponse-responseCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseMessage',
                kValue: ' ',
                kID: 'Manage_Response_SetVariableResponse-responseMessage',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kGroupArrowOpen: true,
                kName: 'multiMerchant',
                kValue: '',
                kID: 'Manage_Response_SetVariableResponse-multiMerchant',
                kType: DataItemType.Group,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 2,
                kName: 'multiMerchantId',
                kValue: ' ',
                kID: 'Manage_Response_SetVariableResponse-multiMerchant_multiMerchantId',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 2,
                kName: 'multiMerchantName',
                kValue: ' ',
                kID: 'Manage_Response_SetVariableResponse-multiMerchant_multiMerchantName',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

   static void parseRspManageSetVariableResponse(ManageSetVariableResponse rsp, List<Map> rspDataSource) {
      rspDataSource.forEach((element) {
          DataItemType itemType = element[kType];
          String id = element[kID];
          switch (itemType) {
              case DataItemType.CellInput:
                element[kValue] = ManageRspData._parseManageSetVariableResponse(id, rsp);
                break;
              case DataItemType.Group:
                if (element[kBitmapEnable] != null) {
                    element[kBitmapEnable] = true;
                    element[kGroupArrowOpen] = true;
                }
                break;
              case DataItemType.ModelList:
                List<dynamic> map = ManageRspData._parseManageSetVariableResponse(id, rsp) ?? [];
                element[kData] = ResponseListModelQuery.query(id, map);
                break;
              case DataItemType.Menu:
                element[kValue] = ManageRspData._parseManageSetVariableResponse(id, rsp);
                break;
              case DataItemType.StringList:
                List<String> tempData = [];
                List<String?> resData = ManageRspData._parseManageSetVariableResponse(id, rsp) ?? [];
                for (int i = 0; i < resData.length; i++) {
                  String str = resData[i]!;
                  tempData.add(str);
                }
                element[kData] = tempData;
                break;
            case DataItemType.Boolen:
                element[kValue] = ManageRspData._parseManageSetVariableResponse(id, rsp);
                element[kShow] = true;
                break;
              default:
                break;
           }
        });
  }


   static dynamic _parseManageSetVariableResponse(String id, ManageSetVariableResponse rsp) {
      dynamic result;
      switch (id) {
         case 'Manage_Response_SetVariableResponse-responseCode':
             result = rsp.responseCode;
             break;
         case 'Manage_Response_SetVariableResponse-responseMessage':
             result = rsp.responseMessage;
             break;
         case 'Manage_Response_SetVariableResponse-multiMerchant':
             result = rsp.multiMerchant;
             break;
         case 'Manage_Response_SetVariableResponse-multiMerchant_multiMerchantId':
             result = rsp.multiMerchant?.multiMerchantId;
             break;
         case 'Manage_Response_SetVariableResponse-multiMerchant_multiMerchantName':
             result = rsp.multiMerchant?.multiMerchantName;
             break;
         default:
             break;
     }
     return result;
 }

  static List<Map> setApplePayVasParametersData() {
      return [
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseCode',
                kValue: ' ',
                kID: 'Manage_Response_SetApplePayVasParametersResponse-responseCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseMessage',
                kValue: ' ',
                kID: 'Manage_Response_SetApplePayVasParametersResponse-responseMessage',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

   static void parseRspManageSetApplePayVasParametersResponse(ManageSetApplePayVasParametersResponse rsp, List<Map> rspDataSource) {
      rspDataSource.forEach((element) {
          DataItemType itemType = element[kType];
          String id = element[kID];
          switch (itemType) {
              case DataItemType.CellInput:
                element[kValue] = ManageRspData._parseManageSetApplePayVasParametersResponse(id, rsp);
                break;
              case DataItemType.Group:
                if (element[kBitmapEnable] != null) {
                    element[kBitmapEnable] = true;
                    element[kGroupArrowOpen] = true;
                }
                break;
              case DataItemType.ModelList:
                List<dynamic> map = ManageRspData._parseManageSetApplePayVasParametersResponse(id, rsp) ?? [];
                element[kData] = ResponseListModelQuery.query(id, map);
                break;
              case DataItemType.Menu:
                element[kValue] = ManageRspData._parseManageSetApplePayVasParametersResponse(id, rsp);
                break;
              case DataItemType.StringList:
                List<String> tempData = [];
                List<String?> resData = ManageRspData._parseManageSetApplePayVasParametersResponse(id, rsp) ?? [];
                for (int i = 0; i < resData.length; i++) {
                  String str = resData[i]!;
                  tempData.add(str);
                }
                element[kData] = tempData;
                break;
            case DataItemType.Boolen:
                element[kValue] = ManageRspData._parseManageSetApplePayVasParametersResponse(id, rsp);
                element[kShow] = true;
                break;
              default:
                break;
           }
        });
  }


   static dynamic _parseManageSetApplePayVasParametersResponse(String id, ManageSetApplePayVasParametersResponse rsp) {
      dynamic result;
      switch (id) {
         case 'Manage_Response_SetApplePayVasParametersResponse-responseCode':
             result = rsp.responseCode;
             break;
         case 'Manage_Response_SetApplePayVasParametersResponse-responseMessage':
             result = rsp.responseMessage;
             break;
         default:
             break;
     }
     return result;
 }

  static List<Map> updateResourceFileData() {
      return [
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseCode',
                kValue: ' ',
                kID: 'Manage_Response_UpdateResourceFileResponse-responseCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseMessage',
                kValue: ' ',
                kID: 'Manage_Response_UpdateResourceFileResponse-responseMessage',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

   static void parseRspManageUpdateResourceFileResponse(ManageUpdateResourceFileResponse rsp, List<Map> rspDataSource) {
      rspDataSource.forEach((element) {
          DataItemType itemType = element[kType];
          String id = element[kID];
          switch (itemType) {
              case DataItemType.CellInput:
                element[kValue] = ManageRspData._parseManageUpdateResourceFileResponse(id, rsp);
                break;
              case DataItemType.Group:
                if (element[kBitmapEnable] != null) {
                    element[kBitmapEnable] = true;
                    element[kGroupArrowOpen] = true;
                }
                break;
              case DataItemType.ModelList:
                List<dynamic> map = ManageRspData._parseManageUpdateResourceFileResponse(id, rsp) ?? [];
                element[kData] = ResponseListModelQuery.query(id, map);
                break;
              case DataItemType.Menu:
                element[kValue] = ManageRspData._parseManageUpdateResourceFileResponse(id, rsp);
                break;
              case DataItemType.StringList:
                List<String> tempData = [];
                List<String?> resData = ManageRspData._parseManageUpdateResourceFileResponse(id, rsp) ?? [];
                for (int i = 0; i < resData.length; i++) {
                  String str = resData[i]!;
                  tempData.add(str);
                }
                element[kData] = tempData;
                break;
            case DataItemType.Boolen:
                element[kValue] = ManageRspData._parseManageUpdateResourceFileResponse(id, rsp);
                element[kShow] = true;
                break;
              default:
                break;
           }
        });
  }


   static dynamic _parseManageUpdateResourceFileResponse(String id, ManageUpdateResourceFileResponse rsp) {
      dynamic result;
      switch (id) {
         case 'Manage_Response_UpdateResourceFileResponse-responseCode':
             result = rsp.responseCode;
             break;
         case 'Manage_Response_UpdateResourceFileResponse-responseMessage':
             result = rsp.responseMessage;
             break;
         default:
             break;
     }
     return result;
 }

  static List<Map> getSignatureData() {
      return [
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseCode',
                kValue: ' ',
                kID: 'Manage_Response_GetSignatureResponse-responseCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseMessage',
                kValue: ' ',
                kID: 'Manage_Response_GetSignatureResponse-responseMessage',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'signatureData',
                kValue: ' ',
                kID: 'Manage_Response_GetSignatureResponse-signatureData',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

   static void parseRspManageGetSignatureResponse(ManageGetSignatureResponse rsp, List<Map> rspDataSource) {
      rspDataSource.forEach((element) {
          DataItemType itemType = element[kType];
          String id = element[kID];
          switch (itemType) {
              case DataItemType.CellInput:
                element[kValue] = ManageRspData._parseManageGetSignatureResponse(id, rsp);
                break;
              case DataItemType.Group:
                if (element[kBitmapEnable] != null) {
                    element[kBitmapEnable] = true;
                    element[kGroupArrowOpen] = true;
                }
                break;
              case DataItemType.ModelList:
                List<dynamic> map = ManageRspData._parseManageGetSignatureResponse(id, rsp) ?? [];
                element[kData] = ResponseListModelQuery.query(id, map);
                break;
              case DataItemType.Menu:
                element[kValue] = ManageRspData._parseManageGetSignatureResponse(id, rsp);
                break;
              case DataItemType.StringList:
                List<String> tempData = [];
                List<String?> resData = ManageRspData._parseManageGetSignatureResponse(id, rsp) ?? [];
                for (int i = 0; i < resData.length; i++) {
                  String str = resData[i]!;
                  tempData.add(str);
                }
                element[kData] = tempData;
                break;
            case DataItemType.Boolen:
                element[kValue] = ManageRspData._parseManageGetSignatureResponse(id, rsp);
                element[kShow] = true;
                break;
              default:
                break;
           }
        });
  }


   static dynamic _parseManageGetSignatureResponse(String id, ManageGetSignatureResponse rsp) {
      dynamic result;
      switch (id) {
         case 'Manage_Response_GetSignatureResponse-responseCode':
             result = rsp.responseCode;
             break;
         case 'Manage_Response_GetSignatureResponse-responseMessage':
             result = rsp.responseMessage;
             break;
         case 'Manage_Response_GetSignatureResponse-signatureData':
             result = rsp.signatureData;
             break;
         default:
             break;
     }
     return result;
 }

  static List<Map> initData() {
      return [
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseCode',
                kValue: ' ',
                kID: 'Manage_Response_InitResponse-responseCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseMessage',
                kValue: ' ',
                kID: 'Manage_Response_InitResponse-responseMessage',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'sn',
                kValue: ' ',
                kID: 'Manage_Response_InitResponse-sn',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'modelName',
                kValue: ' ',
                kID: 'Manage_Response_InitResponse-modelName',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'osVersion',
                kValue: ' ',
                kID: 'Manage_Response_InitResponse-osVersion',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'macAddress',
                kValue: ' ',
                kID: 'Manage_Response_InitResponse-macAddress',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'linesPerScreen',
                kValue: ' ',
                kID: 'Manage_Response_InitResponse-linesPerScreen',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'charsPerLine',
                kValue: ' ',
                kID: 'Manage_Response_InitResponse-charsPerLine',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'appName',
                kValue: ' ',
                kID: 'Manage_Response_InitResponse-appName',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'appVersion',
                kValue: ' ',
                kID: 'Manage_Response_InitResponse-appVersion',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'wifiMac',
                kValue: ' ',
                kID: 'Manage_Response_InitResponse-wifiMac',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'touchscreen',
                kID: 'Manage_Response_InitResponse-touchscreen',
                kMenuID: 'Manage_Response_InitResponse-touchscreen_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: ManageTouchscreenStatus.NotSet,
                kData: [
                  {
                    kData: ManageTouchscreenStatus.NotSet,
                    kID: 'Manage_Response_InitResponse-touchscreen_NotSet',
                  },
                  {
                    kData: ManageTouchscreenStatus.Use,
                    kID: 'Manage_Response_InitResponse-touchscreen_Use',
                  },
                  {
                    kData: ManageTouchscreenStatus.NotUse,
                    kID: 'Manage_Response_InitResponse-touchscreen_NotUse',
                  },
                ],
              },
              {
                kEnable: false,
                kLevel: 1,
                kBitmapEnable: false,
                kGroupArrowOpen: false,
                kName: 'hardwareConfigurationBitmap',
                kValue: '',
                kID: 'Manage_Response_InitResponse-hardwareConfigurationBitmap',
                kType: DataItemType.Group,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 2,
                kName: 'magstripe',
                kValue: false,
                kID: 'Manage_Response_InitResponse-hardwareConfigurationBitmap_magstripe',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: false,
                kLevel: 2,
                kName: 'emvChip',
                kValue: false,
                kID: 'Manage_Response_InitResponse-hardwareConfigurationBitmap_emvChip',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: false,
                kLevel: 2,
                kName: 'emvContactless',
                kValue: false,
                kID: 'Manage_Response_InitResponse-hardwareConfigurationBitmap_emvContactless',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: false,
                kLevel: 2,
                kName: 'cameraFront',
                kValue: false,
                kID: 'Manage_Response_InitResponse-hardwareConfigurationBitmap_cameraFront',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: false,
                kLevel: 2,
                kName: 'laserScanner',
                kValue: false,
                kID: 'Manage_Response_InitResponse-hardwareConfigurationBitmap_laserScanner',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: false,
                kLevel: 2,
                kName: 'cameraRear',
                kValue: false,
                kID: 'Manage_Response_InitResponse-hardwareConfigurationBitmap_cameraRear',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: false,
                kLevel: 2,
                kName: 'printer',
                kValue: false,
                kID: 'Manage_Response_InitResponse-hardwareConfigurationBitmap_printer',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: false,
                kLevel: 2,
                kName: 'touchscreen',
                kValue: false,
                kID: 'Manage_Response_InitResponse-hardwareConfigurationBitmap_touchscreen',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'appActivated',
                kID: 'Manage_Response_InitResponse-appActivated',
                kMenuID: 'Manage_Response_InitResponse-appActivated_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: ManageAppActivated.NotSet,
                kData: [
                  {
                    kData: ManageAppActivated.NotSet,
                    kID: 'Manage_Response_InitResponse-appActivated_NotSet',
                  },
                  {
                    kData: ManageAppActivated.Activated,
                    kID: 'Manage_Response_InitResponse-appActivated_Activated',
                  },
                  {
                    kData: ManageAppActivated.NotActivated,
                    kID: 'Manage_Response_InitResponse-appActivated_NotActivated',
                  },
                ],
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'licenseExpiry',
                kValue: ' ',
                kID: 'Manage_Response_InitResponse-licenseExpiry',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'protocolFlag',
                kID: 'Manage_Response_InitResponse-protocolFlag',
                kMenuID: 'Manage_Response_InitResponse-protocolFlag_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: ManageProtocolFlag.NotSet,
                kData: [
                  {
                    kData: ManageProtocolFlag.NotSet,
                    kID: 'Manage_Response_InitResponse-protocolFlag_NotSet',
                  },
                  {
                    kData: ManageProtocolFlag.Visa1,
                    kID: 'Manage_Response_InitResponse-protocolFlag_Visa1',
                  },
                  {
                    kData: ManageProtocolFlag.Json,
                    kID: 'Manage_Response_InitResponse-protocolFlag_Json',
                  },
                ],
              },
           ];
  }

   static void parseRspManageInitResponse(ManageInitResponse rsp, List<Map> rspDataSource) {
      rspDataSource.forEach((element) {
          DataItemType itemType = element[kType];
          String id = element[kID];
          switch (itemType) {
              case DataItemType.CellInput:
                element[kValue] = ManageRspData._parseManageInitResponse(id, rsp);
                break;
              case DataItemType.Group:
                if (element[kBitmapEnable] != null) {
                    element[kBitmapEnable] = true;
                    element[kGroupArrowOpen] = true;
                }
                break;
              case DataItemType.ModelList:
                List<dynamic> map = ManageRspData._parseManageInitResponse(id, rsp) ?? [];
                element[kData] = ResponseListModelQuery.query(id, map);
                break;
              case DataItemType.Menu:
                element[kValue] = ManageRspData._parseManageInitResponse(id, rsp);
                break;
              case DataItemType.StringList:
                List<String> tempData = [];
                List<String?> resData = ManageRspData._parseManageInitResponse(id, rsp) ?? [];
                for (int i = 0; i < resData.length; i++) {
                  String str = resData[i]!;
                  tempData.add(str);
                }
                element[kData] = tempData;
                break;
            case DataItemType.Boolen:
                element[kValue] = ManageRspData._parseManageInitResponse(id, rsp);
                element[kShow] = true;
                break;
              default:
                break;
           }
        });
  }


   static dynamic _parseManageInitResponse(String id, ManageInitResponse rsp) {
      dynamic result;
      switch (id) {
         case 'Manage_Response_InitResponse-responseCode':
             result = rsp.responseCode;
             break;
         case 'Manage_Response_InitResponse-responseMessage':
             result = rsp.responseMessage;
             break;
         case 'Manage_Response_InitResponse-sn':
             result = rsp.sn;
             break;
         case 'Manage_Response_InitResponse-modelName':
             result = rsp.modelName;
             break;
         case 'Manage_Response_InitResponse-osVersion':
             result = rsp.osVersion;
             break;
         case 'Manage_Response_InitResponse-macAddress':
             result = rsp.macAddress;
             break;
         case 'Manage_Response_InitResponse-linesPerScreen':
             result = rsp.linesPerScreen;
             break;
         case 'Manage_Response_InitResponse-charsPerLine':
             result = rsp.charsPerLine;
             break;
         case 'Manage_Response_InitResponse-appName':
             result = rsp.appName;
             break;
         case 'Manage_Response_InitResponse-appVersion':
             result = rsp.appVersion;
             break;
         case 'Manage_Response_InitResponse-wifiMac':
             result = rsp.wifiMac;
             break;
         case 'Manage_Response_InitResponse-touchscreen':
             result = rsp.touchscreen;
             break;
         case 'Manage_Response_InitResponse-hardwareConfigurationBitmap':
             result = rsp.hardwareConfigurationBitmap;
             break;
         case 'Manage_Response_InitResponse-hardwareConfigurationBitmap_magstripe':
             result = rsp.hardwareConfigurationBitmap?.magstripe;
             break;
         case 'Manage_Response_InitResponse-hardwareConfigurationBitmap_emvChip':
             result = rsp.hardwareConfigurationBitmap?.emvChip;
             break;
         case 'Manage_Response_InitResponse-hardwareConfigurationBitmap_emvContactless':
             result = rsp.hardwareConfigurationBitmap?.emvContactless;
             break;
         case 'Manage_Response_InitResponse-hardwareConfigurationBitmap_cameraFront':
             result = rsp.hardwareConfigurationBitmap?.cameraFront;
             break;
         case 'Manage_Response_InitResponse-hardwareConfigurationBitmap_laserScanner':
             result = rsp.hardwareConfigurationBitmap?.laserScanner;
             break;
         case 'Manage_Response_InitResponse-hardwareConfigurationBitmap_cameraRear':
             result = rsp.hardwareConfigurationBitmap?.cameraRear;
             break;
         case 'Manage_Response_InitResponse-hardwareConfigurationBitmap_printer':
             result = rsp.hardwareConfigurationBitmap?.printer;
             break;
         case 'Manage_Response_InitResponse-hardwareConfigurationBitmap_touchscreen':
             result = rsp.hardwareConfigurationBitmap?.touchscreen;
             break;
         case 'Manage_Response_InitResponse-appActivated':
             result = rsp.appActivated;
             break;
         case 'Manage_Response_InitResponse-licenseExpiry':
             result = rsp.licenseExpiry;
             break;
         case 'Manage_Response_InitResponse-protocolFlag':
             result = rsp.protocolFlag;
             break;
         default:
             break;
     }
     return result;
 }

  static List<Map> checkFileData() {
      return [
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseCode',
                kValue: ' ',
                kID: 'Manage_Response_CheckFileResponse-responseCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseMessage',
                kValue: ' ',
                kID: 'Manage_Response_CheckFileResponse-responseMessage',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'checkSum',
                kValue: ' ',
                kID: 'Manage_Response_CheckFileResponse-checkSum',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

   static void parseRspManageCheckFileResponse(ManageCheckFileResponse rsp, List<Map> rspDataSource) {
      rspDataSource.forEach((element) {
          DataItemType itemType = element[kType];
          String id = element[kID];
          switch (itemType) {
              case DataItemType.CellInput:
                element[kValue] = ManageRspData._parseManageCheckFileResponse(id, rsp);
                break;
              case DataItemType.Group:
                if (element[kBitmapEnable] != null) {
                    element[kBitmapEnable] = true;
                    element[kGroupArrowOpen] = true;
                }
                break;
              case DataItemType.ModelList:
                List<dynamic> map = ManageRspData._parseManageCheckFileResponse(id, rsp) ?? [];
                element[kData] = ResponseListModelQuery.query(id, map);
                break;
              case DataItemType.Menu:
                element[kValue] = ManageRspData._parseManageCheckFileResponse(id, rsp);
                break;
              case DataItemType.StringList:
                List<String> tempData = [];
                List<String?> resData = ManageRspData._parseManageCheckFileResponse(id, rsp) ?? [];
                for (int i = 0; i < resData.length; i++) {
                  String str = resData[i]!;
                  tempData.add(str);
                }
                element[kData] = tempData;
                break;
            case DataItemType.Boolen:
                element[kValue] = ManageRspData._parseManageCheckFileResponse(id, rsp);
                element[kShow] = true;
                break;
              default:
                break;
           }
        });
  }


   static dynamic _parseManageCheckFileResponse(String id, ManageCheckFileResponse rsp) {
      dynamic result;
      switch (id) {
         case 'Manage_Response_CheckFileResponse-responseCode':
             result = rsp.responseCode;
             break;
         case 'Manage_Response_CheckFileResponse-responseMessage':
             result = rsp.responseMessage;
             break;
         case 'Manage_Response_CheckFileResponse-checkSum':
             result = rsp.checkSum;
             break;
         default:
             break;
     }
     return result;
 }

  static List<Map> clearCardBufferData() {
      return [
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseCode',
                kValue: ' ',
                kID: 'Manage_Response_ClearCardBufferResponse-responseCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseMessage',
                kValue: ' ',
                kID: 'Manage_Response_ClearCardBufferResponse-responseMessage',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

   static void parseRspManageClearCardBufferResponse(ManageClearCardBufferResponse rsp, List<Map> rspDataSource) {
      rspDataSource.forEach((element) {
          DataItemType itemType = element[kType];
          String id = element[kID];
          switch (itemType) {
              case DataItemType.CellInput:
                element[kValue] = ManageRspData._parseManageClearCardBufferResponse(id, rsp);
                break;
              case DataItemType.Group:
                if (element[kBitmapEnable] != null) {
                    element[kBitmapEnable] = true;
                    element[kGroupArrowOpen] = true;
                }
                break;
              case DataItemType.ModelList:
                List<dynamic> map = ManageRspData._parseManageClearCardBufferResponse(id, rsp) ?? [];
                element[kData] = ResponseListModelQuery.query(id, map);
                break;
              case DataItemType.Menu:
                element[kValue] = ManageRspData._parseManageClearCardBufferResponse(id, rsp);
                break;
              case DataItemType.StringList:
                List<String> tempData = [];
                List<String?> resData = ManageRspData._parseManageClearCardBufferResponse(id, rsp) ?? [];
                for (int i = 0; i < resData.length; i++) {
                  String str = resData[i]!;
                  tempData.add(str);
                }
                element[kData] = tempData;
                break;
            case DataItemType.Boolen:
                element[kValue] = ManageRspData._parseManageClearCardBufferResponse(id, rsp);
                element[kShow] = true;
                break;
              default:
                break;
           }
        });
  }


   static dynamic _parseManageClearCardBufferResponse(String id, ManageClearCardBufferResponse rsp) {
      dynamic result;
      switch (id) {
         case 'Manage_Response_ClearCardBufferResponse-responseCode':
             result = rsp.responseCode;
             break;
         case 'Manage_Response_ClearCardBufferResponse-responseMessage':
             result = rsp.responseMessage;
             break;
         default:
             break;
     }
     return result;
 }

  static List<Map> doSignatureData() {
      return [
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseCode',
                kValue: ' ',
                kID: 'Manage_Response_DoSignatureResponse-responseCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseMessage',
                kValue: ' ',
                kID: 'Manage_Response_DoSignatureResponse-responseMessage',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

   static void parseRspManageDoSignatureResponse(ManageDoSignatureResponse rsp, List<Map> rspDataSource) {
      rspDataSource.forEach((element) {
          DataItemType itemType = element[kType];
          String id = element[kID];
          switch (itemType) {
              case DataItemType.CellInput:
                element[kValue] = ManageRspData._parseManageDoSignatureResponse(id, rsp);
                break;
              case DataItemType.Group:
                if (element[kBitmapEnable] != null) {
                    element[kBitmapEnable] = true;
                    element[kGroupArrowOpen] = true;
                }
                break;
              case DataItemType.ModelList:
                List<dynamic> map = ManageRspData._parseManageDoSignatureResponse(id, rsp) ?? [];
                element[kData] = ResponseListModelQuery.query(id, map);
                break;
              case DataItemType.Menu:
                element[kValue] = ManageRspData._parseManageDoSignatureResponse(id, rsp);
                break;
              case DataItemType.StringList:
                List<String> tempData = [];
                List<String?> resData = ManageRspData._parseManageDoSignatureResponse(id, rsp) ?? [];
                for (int i = 0; i < resData.length; i++) {
                  String str = resData[i]!;
                  tempData.add(str);
                }
                element[kData] = tempData;
                break;
            case DataItemType.Boolen:
                element[kValue] = ManageRspData._parseManageDoSignatureResponse(id, rsp);
                element[kShow] = true;
                break;
              default:
                break;
           }
        });
  }


   static dynamic _parseManageDoSignatureResponse(String id, ManageDoSignatureResponse rsp) {
      dynamic result;
      switch (id) {
         case 'Manage_Response_DoSignatureResponse-responseCode':
             result = rsp.responseCode;
             break;
         case 'Manage_Response_DoSignatureResponse-responseMessage':
             result = rsp.responseMessage;
             break;
         default:
             break;
     }
     return result;
 }

  static List<Map> vasPushDataData() {
      return [
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseCode',
                kValue: ' ',
                kID: 'Manage_Response_VasPushDataResponse-responseCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseMessage',
                kValue: ' ',
                kID: 'Manage_Response_VasPushDataResponse-responseMessage',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

   static void parseRspManageVasPushDataResponse(ManageVasPushDataResponse rsp, List<Map> rspDataSource) {
      rspDataSource.forEach((element) {
          DataItemType itemType = element[kType];
          String id = element[kID];
          switch (itemType) {
              case DataItemType.CellInput:
                element[kValue] = ManageRspData._parseManageVasPushDataResponse(id, rsp);
                break;
              case DataItemType.Group:
                if (element[kBitmapEnable] != null) {
                    element[kBitmapEnable] = true;
                    element[kGroupArrowOpen] = true;
                }
                break;
              case DataItemType.ModelList:
                List<dynamic> map = ManageRspData._parseManageVasPushDataResponse(id, rsp) ?? [];
                element[kData] = ResponseListModelQuery.query(id, map);
                break;
              case DataItemType.Menu:
                element[kValue] = ManageRspData._parseManageVasPushDataResponse(id, rsp);
                break;
              case DataItemType.StringList:
                List<String> tempData = [];
                List<String?> resData = ManageRspData._parseManageVasPushDataResponse(id, rsp) ?? [];
                for (int i = 0; i < resData.length; i++) {
                  String str = resData[i]!;
                  tempData.add(str);
                }
                element[kData] = tempData;
                break;
            case DataItemType.Boolen:
                element[kValue] = ManageRspData._parseManageVasPushDataResponse(id, rsp);
                element[kShow] = true;
                break;
              default:
                break;
           }
        });
  }


   static dynamic _parseManageVasPushDataResponse(String id, ManageVasPushDataResponse rsp) {
      dynamic result;
      switch (id) {
         case 'Manage_Response_VasPushDataResponse-responseCode':
             result = rsp.responseCode;
             break;
         case 'Manage_Response_VasPushDataResponse-responseMessage':
             result = rsp.responseMessage;
             break;
         default:
             break;
     }
     return result;
 }

  static List<Map> resetScreenData() {
      return [
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseCode',
                kValue: ' ',
                kID: 'Manage_Response_ResetScreenResponse-responseCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseMessage',
                kValue: ' ',
                kID: 'Manage_Response_ResetScreenResponse-responseMessage',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

   static void parseRspManageResetScreenResponse(ManageResetScreenResponse rsp, List<Map> rspDataSource) {
      rspDataSource.forEach((element) {
          DataItemType itemType = element[kType];
          String id = element[kID];
          switch (itemType) {
              case DataItemType.CellInput:
                element[kValue] = ManageRspData._parseManageResetScreenResponse(id, rsp);
                break;
              case DataItemType.Group:
                if (element[kBitmapEnable] != null) {
                    element[kBitmapEnable] = true;
                    element[kGroupArrowOpen] = true;
                }
                break;
              case DataItemType.ModelList:
                List<dynamic> map = ManageRspData._parseManageResetScreenResponse(id, rsp) ?? [];
                element[kData] = ResponseListModelQuery.query(id, map);
                break;
              case DataItemType.Menu:
                element[kValue] = ManageRspData._parseManageResetScreenResponse(id, rsp);
                break;
              case DataItemType.StringList:
                List<String> tempData = [];
                List<String?> resData = ManageRspData._parseManageResetScreenResponse(id, rsp) ?? [];
                for (int i = 0; i < resData.length; i++) {
                  String str = resData[i]!;
                  tempData.add(str);
                }
                element[kData] = tempData;
                break;
            case DataItemType.Boolen:
                element[kValue] = ManageRspData._parseManageResetScreenResponse(id, rsp);
                element[kShow] = true;
                break;
              default:
                break;
           }
        });
  }


   static dynamic _parseManageResetScreenResponse(String id, ManageResetScreenResponse rsp) {
      dynamic result;
      switch (id) {
         case 'Manage_Response_ResetScreenResponse-responseCode':
             result = rsp.responseCode;
             break;
         case 'Manage_Response_ResetScreenResponse-responseMessage':
             result = rsp.responseMessage;
             break;
         default:
             break;
     }
     return result;
 }

  static List<Map> deleteImageData() {
      return [
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseCode',
                kValue: ' ',
                kID: 'Manage_Response_DeleteImageResponse-responseCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseMessage',
                kValue: ' ',
                kID: 'Manage_Response_DeleteImageResponse-responseMessage',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

   static void parseRspManageDeleteImageResponse(ManageDeleteImageResponse rsp, List<Map> rspDataSource) {
      rspDataSource.forEach((element) {
          DataItemType itemType = element[kType];
          String id = element[kID];
          switch (itemType) {
              case DataItemType.CellInput:
                element[kValue] = ManageRspData._parseManageDeleteImageResponse(id, rsp);
                break;
              case DataItemType.Group:
                if (element[kBitmapEnable] != null) {
                    element[kBitmapEnable] = true;
                    element[kGroupArrowOpen] = true;
                }
                break;
              case DataItemType.ModelList:
                List<dynamic> map = ManageRspData._parseManageDeleteImageResponse(id, rsp) ?? [];
                element[kData] = ResponseListModelQuery.query(id, map);
                break;
              case DataItemType.Menu:
                element[kValue] = ManageRspData._parseManageDeleteImageResponse(id, rsp);
                break;
              case DataItemType.StringList:
                List<String> tempData = [];
                List<String?> resData = ManageRspData._parseManageDeleteImageResponse(id, rsp) ?? [];
                for (int i = 0; i < resData.length; i++) {
                  String str = resData[i]!;
                  tempData.add(str);
                }
                element[kData] = tempData;
                break;
            case DataItemType.Boolen:
                element[kValue] = ManageRspData._parseManageDeleteImageResponse(id, rsp);
                element[kShow] = true;
                break;
              default:
                break;
           }
        });
  }


   static dynamic _parseManageDeleteImageResponse(String id, ManageDeleteImageResponse rsp) {
      dynamic result;
      switch (id) {
         case 'Manage_Response_DeleteImageResponse-responseCode':
             result = rsp.responseCode;
             break;
         case 'Manage_Response_DeleteImageResponse-responseMessage':
             result = rsp.responseMessage;
             break;
         default:
             break;
     }
     return result;
 }

  static List<Map> rebootData() {
      return [
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseCode',
                kValue: ' ',
                kID: 'Manage_Response_RebootResponse-responseCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseMessage',
                kValue: ' ',
                kID: 'Manage_Response_RebootResponse-responseMessage',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

   static void parseRspManageRebootResponse(ManageRebootResponse rsp, List<Map> rspDataSource) {
      rspDataSource.forEach((element) {
          DataItemType itemType = element[kType];
          String id = element[kID];
          switch (itemType) {
              case DataItemType.CellInput:
                element[kValue] = ManageRspData._parseManageRebootResponse(id, rsp);
                break;
              case DataItemType.Group:
                if (element[kBitmapEnable] != null) {
                    element[kBitmapEnable] = true;
                    element[kGroupArrowOpen] = true;
                }
                break;
              case DataItemType.ModelList:
                List<dynamic> map = ManageRspData._parseManageRebootResponse(id, rsp) ?? [];
                element[kData] = ResponseListModelQuery.query(id, map);
                break;
              case DataItemType.Menu:
                element[kValue] = ManageRspData._parseManageRebootResponse(id, rsp);
                break;
              case DataItemType.StringList:
                List<String> tempData = [];
                List<String?> resData = ManageRspData._parseManageRebootResponse(id, rsp) ?? [];
                for (int i = 0; i < resData.length; i++) {
                  String str = resData[i]!;
                  tempData.add(str);
                }
                element[kData] = tempData;
                break;
            case DataItemType.Boolen:
                element[kValue] = ManageRspData._parseManageRebootResponse(id, rsp);
                element[kShow] = true;
                break;
              default:
                break;
           }
        });
  }


   static dynamic _parseManageRebootResponse(String id, ManageRebootResponse rsp) {
      dynamic result;
      switch (id) {
         case 'Manage_Response_RebootResponse-responseCode':
             result = rsp.responseCode;
             break;
         case 'Manage_Response_RebootResponse-responseMessage':
             result = rsp.responseMessage;
             break;
         default:
             break;
     }
     return result;
 }

  static List<Map> getVariableData() {
      return [
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseCode',
                kValue: ' ',
                kID: 'Manage_Response_GetVariableResponse-responseCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseMessage',
                kValue: ' ',
                kID: 'Manage_Response_GetVariableResponse-responseMessage',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'variableValue1',
                kValue: ' ',
                kID: 'Manage_Response_GetVariableResponse-variableValue1',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'variableValue2',
                kValue: ' ',
                kID: 'Manage_Response_GetVariableResponse-variableValue2',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'variableValue3',
                kValue: ' ',
                kID: 'Manage_Response_GetVariableResponse-variableValue3',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'variableValue4',
                kValue: ' ',
                kID: 'Manage_Response_GetVariableResponse-variableValue4',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'variableValue5',
                kValue: ' ',
                kID: 'Manage_Response_GetVariableResponse-variableValue5',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kGroupArrowOpen: true,
                kName: 'multiMerchant',
                kValue: '',
                kID: 'Manage_Response_GetVariableResponse-multiMerchant',
                kType: DataItemType.Group,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 2,
                kName: 'multiMerchantId',
                kValue: ' ',
                kID: 'Manage_Response_GetVariableResponse-multiMerchant_multiMerchantId',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 2,
                kName: 'multiMerchantName',
                kValue: ' ',
                kID: 'Manage_Response_GetVariableResponse-multiMerchant_multiMerchantName',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

   static void parseRspManageGetVariableResponse(ManageGetVariableResponse rsp, List<Map> rspDataSource) {
      rspDataSource.forEach((element) {
          DataItemType itemType = element[kType];
          String id = element[kID];
          switch (itemType) {
              case DataItemType.CellInput:
                element[kValue] = ManageRspData._parseManageGetVariableResponse(id, rsp);
                break;
              case DataItemType.Group:
                if (element[kBitmapEnable] != null) {
                    element[kBitmapEnable] = true;
                    element[kGroupArrowOpen] = true;
                }
                break;
              case DataItemType.ModelList:
                List<dynamic> map = ManageRspData._parseManageGetVariableResponse(id, rsp) ?? [];
                element[kData] = ResponseListModelQuery.query(id, map);
                break;
              case DataItemType.Menu:
                element[kValue] = ManageRspData._parseManageGetVariableResponse(id, rsp);
                break;
              case DataItemType.StringList:
                List<String> tempData = [];
                List<String?> resData = ManageRspData._parseManageGetVariableResponse(id, rsp) ?? [];
                for (int i = 0; i < resData.length; i++) {
                  String str = resData[i]!;
                  tempData.add(str);
                }
                element[kData] = tempData;
                break;
            case DataItemType.Boolen:
                element[kValue] = ManageRspData._parseManageGetVariableResponse(id, rsp);
                element[kShow] = true;
                break;
              default:
                break;
           }
        });
  }


   static dynamic _parseManageGetVariableResponse(String id, ManageGetVariableResponse rsp) {
      dynamic result;
      switch (id) {
         case 'Manage_Response_GetVariableResponse-responseCode':
             result = rsp.responseCode;
             break;
         case 'Manage_Response_GetVariableResponse-responseMessage':
             result = rsp.responseMessage;
             break;
         case 'Manage_Response_GetVariableResponse-variableValue1':
             result = rsp.variableValue1;
             break;
         case 'Manage_Response_GetVariableResponse-variableValue2':
             result = rsp.variableValue2;
             break;
         case 'Manage_Response_GetVariableResponse-variableValue3':
             result = rsp.variableValue3;
             break;
         case 'Manage_Response_GetVariableResponse-variableValue4':
             result = rsp.variableValue4;
             break;
         case 'Manage_Response_GetVariableResponse-variableValue5':
             result = rsp.variableValue5;
             break;
         case 'Manage_Response_GetVariableResponse-multiMerchant':
             result = rsp.multiMerchant;
             break;
         case 'Manage_Response_GetVariableResponse-multiMerchant_multiMerchantId':
             result = rsp.multiMerchant?.multiMerchantId;
             break;
         case 'Manage_Response_GetVariableResponse-multiMerchant_multiMerchantName':
             result = rsp.multiMerchant?.multiMerchantName;
             break;
         default:
             break;
     }
     return result;
 }

  static List<Map> setGoogleSmartTapParametersData() {
      return [
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseCode',
                kValue: ' ',
                kID: 'Manage_Response_SetGoogleSmartTapParametersResponse-responseCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseMessage',
                kValue: ' ',
                kID: 'Manage_Response_SetGoogleSmartTapParametersResponse-responseMessage',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

   static void parseRspManageSetGoogleSmartTapParametersResponse(ManageSetGoogleSmartTapParametersResponse rsp, List<Map> rspDataSource) {
      rspDataSource.forEach((element) {
          DataItemType itemType = element[kType];
          String id = element[kID];
          switch (itemType) {
              case DataItemType.CellInput:
                element[kValue] = ManageRspData._parseManageSetGoogleSmartTapParametersResponse(id, rsp);
                break;
              case DataItemType.Group:
                if (element[kBitmapEnable] != null) {
                    element[kBitmapEnable] = true;
                    element[kGroupArrowOpen] = true;
                }
                break;
              case DataItemType.ModelList:
                List<dynamic> map = ManageRspData._parseManageSetGoogleSmartTapParametersResponse(id, rsp) ?? [];
                element[kData] = ResponseListModelQuery.query(id, map);
                break;
              case DataItemType.Menu:
                element[kValue] = ManageRspData._parseManageSetGoogleSmartTapParametersResponse(id, rsp);
                break;
              case DataItemType.StringList:
                List<String> tempData = [];
                List<String?> resData = ManageRspData._parseManageSetGoogleSmartTapParametersResponse(id, rsp) ?? [];
                for (int i = 0; i < resData.length; i++) {
                  String str = resData[i]!;
                  tempData.add(str);
                }
                element[kData] = tempData;
                break;
            case DataItemType.Boolen:
                element[kValue] = ManageRspData._parseManageSetGoogleSmartTapParametersResponse(id, rsp);
                element[kShow] = true;
                break;
              default:
                break;
           }
        });
  }


   static dynamic _parseManageSetGoogleSmartTapParametersResponse(String id, ManageSetGoogleSmartTapParametersResponse rsp) {
      dynamic result;
      switch (id) {
         case 'Manage_Response_SetGoogleSmartTapParametersResponse-responseCode':
             result = rsp.responseCode;
             break;
         case 'Manage_Response_SetGoogleSmartTapParametersResponse-responseMessage':
             result = rsp.responseMessage;
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
      case 'DeleteImageRequest':
        list = ManageRspData.deleteImageData();
        break;
      case 'DoSignatureRequest':
        list = ManageRspData.doSignatureData();
        break;
      case 'VasPushDataRequest':
        list = ManageRspData.vasPushDataData();
        break;
      case 'InitRequest':
        list = ManageRspData.initData();
        break;
      case 'SetGoogleSmartTapParametersRequest':
        list = ManageRspData.setGoogleSmartTapParametersData();
        break;
      case 'CheckFileRequest':
        list = ManageRspData.checkFileData();
        break;
      case 'ClearCardBufferRequest':
        list = ManageRspData.clearCardBufferData();
        break;
      case 'SetApplePayVasParametersRequest':
        list = ManageRspData.setApplePayVasParametersData();
        break;
      case 'GetSignatureRequest':
        list = ManageRspData.getSignatureData();
        break;
      case 'ResetScreenRequest':
        list = ManageRspData.resetScreenData();
        break;
      case 'GetVariableRequest':
        list = ManageRspData.getVariableData();
        break;
      case 'UpdateResourceFileRequest':
        list = ManageRspData.updateResourceFileData();
        break;
      case 'RebootRequest':
        list = ManageRspData.rebootData();
        break;
      case 'SetVariableRequest':
        list = ManageRspData.setVariableData();
        break;
      default:
        list = [];
        break;
    }
    return list;
  }

}

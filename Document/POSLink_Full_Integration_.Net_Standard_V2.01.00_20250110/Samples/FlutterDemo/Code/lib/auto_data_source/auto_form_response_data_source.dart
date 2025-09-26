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
import 'package:poslink2/auto_pigeon/poslink_sdk_form.dart';
import 'package:poslink2/auto_data_source/auto_query.dart';
class FormRspData {
  static List<Map> initSourceData() {
    return FormRspData.showMessageCenterData();
  }
  static List<Map> showTextBoxData() {
      return [
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseCode',
                kValue: ' ',
                kID: 'Form_Response_ShowTextBoxResponse-responseCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseMessage',
                kValue: ' ',
                kID: 'Form_Response_ShowTextBoxResponse-responseMessage',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'buttonNumber',
                kValue: ' ',
                kID: 'Form_Response_ShowTextBoxResponse-buttonNumber',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'signStatus',
                kID: 'Form_Response_ShowTextBoxResponse-signStatus',
                kMenuID: 'Form_Response_ShowTextBoxResponse-signStatus_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FormSignatureStatus.NotSet,
                kData: [
                  {
                    kData: FormSignatureStatus.NotSet,
                    kID: 'Form_Response_ShowTextBoxResponse-signStatus_NotSet',
                  },
                  {
                    kData: FormSignatureStatus.SignatureNotProvided,
                    kID: 'Form_Response_ShowTextBoxResponse-signStatus_SignatureNotProvided',
                  },
                  {
                    kData: FormSignatureStatus.SignatureProvided,
                    kID: 'Form_Response_ShowTextBoxResponse-signStatus_SignatureProvided',
                  },
                ],
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'signatureData',
                kValue: ' ',
                kID: 'Form_Response_ShowTextBoxResponse-signatureData',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'text',
                kValue: ' ',
                kID: 'Form_Response_ShowTextBoxResponse-text',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

   static void parseRspFormShowTextBoxResponse(FormShowTextBoxResponse rsp, List<Map> rspDataSource) {
      rspDataSource.forEach((element) {
          DataItemType itemType = element[kType];
          String id = element[kID];
          switch (itemType) {
              case DataItemType.CellInput:
                element[kValue] = FormRspData._parseFormShowTextBoxResponse(id, rsp);
                break;
              case DataItemType.Group:
                if (element[kBitmapEnable] != null) {
                    element[kBitmapEnable] = true;
                    element[kGroupArrowOpen] = true;
                }
                break;
              case DataItemType.ModelList:
                List<dynamic> map = FormRspData._parseFormShowTextBoxResponse(id, rsp) ?? [];
                element[kData] = ResponseListModelQuery.query(id, map);
                break;
              case DataItemType.Menu:
                element[kValue] = FormRspData._parseFormShowTextBoxResponse(id, rsp);
                break;
              case DataItemType.StringList:
                List<String> tempData = [];
                List<String?> resData = FormRspData._parseFormShowTextBoxResponse(id, rsp) ?? [];
                for (int i = 0; i < resData.length; i++) {
                  String str = resData[i]!;
                  tempData.add(str);
                }
                element[kData] = tempData;
                break;
            case DataItemType.Boolen:
                element[kValue] = FormRspData._parseFormShowTextBoxResponse(id, rsp);
                element[kShow] = true;
                break;
              default:
                break;
           }
        });
  }


   static dynamic _parseFormShowTextBoxResponse(String id, FormShowTextBoxResponse rsp) {
      dynamic result;
      switch (id) {
         case 'Form_Response_ShowTextBoxResponse-responseCode':
             result = rsp.responseCode;
             break;
         case 'Form_Response_ShowTextBoxResponse-responseMessage':
             result = rsp.responseMessage;
             break;
         case 'Form_Response_ShowTextBoxResponse-buttonNumber':
             result = rsp.buttonNumber;
             break;
         case 'Form_Response_ShowTextBoxResponse-signStatus':
             result = rsp.signStatus;
             break;
         case 'Form_Response_ShowTextBoxResponse-signatureData':
             result = rsp.signatureData;
             break;
         case 'Form_Response_ShowTextBoxResponse-text':
             result = rsp.text;
             break;
         default:
             break;
     }
     return result;
 }

  static List<Map> showItemData() {
      return [
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseCode',
                kValue: ' ',
                kID: 'Form_Response_ShowItemResponse-responseCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseMessage',
                kValue: ' ',
                kID: 'Form_Response_ShowItemResponse-responseMessage',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

   static void parseRspFormShowItemResponse(FormShowItemResponse rsp, List<Map> rspDataSource) {
      rspDataSource.forEach((element) {
          DataItemType itemType = element[kType];
          String id = element[kID];
          switch (itemType) {
              case DataItemType.CellInput:
                element[kValue] = FormRspData._parseFormShowItemResponse(id, rsp);
                break;
              case DataItemType.Group:
                if (element[kBitmapEnable] != null) {
                    element[kBitmapEnable] = true;
                    element[kGroupArrowOpen] = true;
                }
                break;
              case DataItemType.ModelList:
                List<dynamic> map = FormRspData._parseFormShowItemResponse(id, rsp) ?? [];
                element[kData] = ResponseListModelQuery.query(id, map);
                break;
              case DataItemType.Menu:
                element[kValue] = FormRspData._parseFormShowItemResponse(id, rsp);
                break;
              case DataItemType.StringList:
                List<String> tempData = [];
                List<String?> resData = FormRspData._parseFormShowItemResponse(id, rsp) ?? [];
                for (int i = 0; i < resData.length; i++) {
                  String str = resData[i]!;
                  tempData.add(str);
                }
                element[kData] = tempData;
                break;
            case DataItemType.Boolen:
                element[kValue] = FormRspData._parseFormShowItemResponse(id, rsp);
                element[kShow] = true;
                break;
              default:
                break;
           }
        });
  }


   static dynamic _parseFormShowItemResponse(String id, FormShowItemResponse rsp) {
      dynamic result;
      switch (id) {
         case 'Form_Response_ShowItemResponse-responseCode':
             result = rsp.responseCode;
             break;
         case 'Form_Response_ShowItemResponse-responseMessage':
             result = rsp.responseMessage;
             break;
         default:
             break;
     }
     return result;
 }

  static List<Map> showMessageData() {
      return [
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseCode',
                kValue: ' ',
                kID: 'Form_Response_ShowMessageResponse-responseCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseMessage',
                kValue: ' ',
                kID: 'Form_Response_ShowMessageResponse-responseMessage',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

   static void parseRspFormShowMessageResponse(FormShowMessageResponse rsp, List<Map> rspDataSource) {
      rspDataSource.forEach((element) {
          DataItemType itemType = element[kType];
          String id = element[kID];
          switch (itemType) {
              case DataItemType.CellInput:
                element[kValue] = FormRspData._parseFormShowMessageResponse(id, rsp);
                break;
              case DataItemType.Group:
                if (element[kBitmapEnable] != null) {
                    element[kBitmapEnable] = true;
                    element[kGroupArrowOpen] = true;
                }
                break;
              case DataItemType.ModelList:
                List<dynamic> map = FormRspData._parseFormShowMessageResponse(id, rsp) ?? [];
                element[kData] = ResponseListModelQuery.query(id, map);
                break;
              case DataItemType.Menu:
                element[kValue] = FormRspData._parseFormShowMessageResponse(id, rsp);
                break;
              case DataItemType.StringList:
                List<String> tempData = [];
                List<String?> resData = FormRspData._parseFormShowMessageResponse(id, rsp) ?? [];
                for (int i = 0; i < resData.length; i++) {
                  String str = resData[i]!;
                  tempData.add(str);
                }
                element[kData] = tempData;
                break;
            case DataItemType.Boolen:
                element[kValue] = FormRspData._parseFormShowMessageResponse(id, rsp);
                element[kShow] = true;
                break;
              default:
                break;
           }
        });
  }


   static dynamic _parseFormShowMessageResponse(String id, FormShowMessageResponse rsp) {
      dynamic result;
      switch (id) {
         case 'Form_Response_ShowMessageResponse-responseCode':
             result = rsp.responseCode;
             break;
         case 'Form_Response_ShowMessageResponse-responseMessage':
             result = rsp.responseMessage;
             break;
         default:
             break;
     }
     return result;
 }

  static List<Map> showDialogData() {
      return [
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseCode',
                kValue: ' ',
                kID: 'Form_Response_ShowDialogResponse-responseCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseMessage',
                kValue: ' ',
                kID: 'Form_Response_ShowDialogResponse-responseMessage',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'buttonNumber',
                kValue: ' ',
                kID: 'Form_Response_ShowDialogResponse-buttonNumber',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

   static void parseRspFormShowDialogResponse(FormShowDialogResponse rsp, List<Map> rspDataSource) {
      rspDataSource.forEach((element) {
          DataItemType itemType = element[kType];
          String id = element[kID];
          switch (itemType) {
              case DataItemType.CellInput:
                element[kValue] = FormRspData._parseFormShowDialogResponse(id, rsp);
                break;
              case DataItemType.Group:
                if (element[kBitmapEnable] != null) {
                    element[kBitmapEnable] = true;
                    element[kGroupArrowOpen] = true;
                }
                break;
              case DataItemType.ModelList:
                List<dynamic> map = FormRspData._parseFormShowDialogResponse(id, rsp) ?? [];
                element[kData] = ResponseListModelQuery.query(id, map);
                break;
              case DataItemType.Menu:
                element[kValue] = FormRspData._parseFormShowDialogResponse(id, rsp);
                break;
              case DataItemType.StringList:
                List<String> tempData = [];
                List<String?> resData = FormRspData._parseFormShowDialogResponse(id, rsp) ?? [];
                for (int i = 0; i < resData.length; i++) {
                  String str = resData[i]!;
                  tempData.add(str);
                }
                element[kData] = tempData;
                break;
            case DataItemType.Boolen:
                element[kValue] = FormRspData._parseFormShowDialogResponse(id, rsp);
                element[kShow] = true;
                break;
              default:
                break;
           }
        });
  }


   static dynamic _parseFormShowDialogResponse(String id, FormShowDialogResponse rsp) {
      dynamic result;
      switch (id) {
         case 'Form_Response_ShowDialogResponse-responseCode':
             result = rsp.responseCode;
             break;
         case 'Form_Response_ShowDialogResponse-responseMessage':
             result = rsp.responseMessage;
             break;
         case 'Form_Response_ShowDialogResponse-buttonNumber':
             result = rsp.buttonNumber;
             break;
         default:
             break;
     }
     return result;
 }

  static List<Map> showDialogFormData() {
      return [
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseCode',
                kValue: ' ',
                kID: 'Form_Response_ShowDialogFormResponse-responseCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseMessage',
                kValue: ' ',
                kID: 'Form_Response_ShowDialogFormResponse-responseMessage',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'labelSelected',
                kValue: ' ',
                kID: 'Form_Response_ShowDialogFormResponse-labelSelected',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

   static void parseRspFormShowDialogFormResponse(FormShowDialogFormResponse rsp, List<Map> rspDataSource) {
      rspDataSource.forEach((element) {
          DataItemType itemType = element[kType];
          String id = element[kID];
          switch (itemType) {
              case DataItemType.CellInput:
                element[kValue] = FormRspData._parseFormShowDialogFormResponse(id, rsp);
                break;
              case DataItemType.Group:
                if (element[kBitmapEnable] != null) {
                    element[kBitmapEnable] = true;
                    element[kGroupArrowOpen] = true;
                }
                break;
              case DataItemType.ModelList:
                List<dynamic> map = FormRspData._parseFormShowDialogFormResponse(id, rsp) ?? [];
                element[kData] = ResponseListModelQuery.query(id, map);
                break;
              case DataItemType.Menu:
                element[kValue] = FormRspData._parseFormShowDialogFormResponse(id, rsp);
                break;
              case DataItemType.StringList:
                List<String> tempData = [];
                List<String?> resData = FormRspData._parseFormShowDialogFormResponse(id, rsp) ?? [];
                for (int i = 0; i < resData.length; i++) {
                  String str = resData[i]!;
                  tempData.add(str);
                }
                element[kData] = tempData;
                break;
            case DataItemType.Boolen:
                element[kValue] = FormRspData._parseFormShowDialogFormResponse(id, rsp);
                element[kShow] = true;
                break;
              default:
                break;
           }
        });
  }


   static dynamic _parseFormShowDialogFormResponse(String id, FormShowDialogFormResponse rsp) {
      dynamic result;
      switch (id) {
         case 'Form_Response_ShowDialogFormResponse-responseCode':
             result = rsp.responseCode;
             break;
         case 'Form_Response_ShowDialogFormResponse-responseMessage':
             result = rsp.responseMessage;
             break;
         case 'Form_Response_ShowDialogFormResponse-labelSelected':
             result = rsp.labelSelected;
             break;
         default:
             break;
     }
     return result;
 }

  static List<Map> removeCardData() {
      return [
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseCode',
                kValue: ' ',
                kID: 'Form_Response_RemoveCardResponse-responseCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseMessage',
                kValue: ' ',
                kID: 'Form_Response_RemoveCardResponse-responseMessage',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'pinpadType',
                kID: 'Form_Response_RemoveCardResponse-pinpadType',
                kMenuID: 'Form_Response_RemoveCardResponse-pinpadType_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FormPinpadType.NotSet,
                kData: [
                  {
                    kData: FormPinpadType.NotSet,
                    kID: 'Form_Response_RemoveCardResponse-pinpadType_NotSet',
                  },
                  {
                    kData: FormPinpadType.InternalPinpad,
                    kID: 'Form_Response_RemoveCardResponse-pinpadType_InternalPinpad',
                  },
                  {
                    kData: FormPinpadType.ExternalPinpad,
                    kID: 'Form_Response_RemoveCardResponse-pinpadType_ExternalPinpad',
                  },
                  {
                    kData: FormPinpadType.RnibPinpad,
                    kID: 'Form_Response_RemoveCardResponse-pinpadType_RnibPinpad',
                  },
                  {
                    kData: FormPinpadType.ExternalPinpadFirst,
                    kID: 'Form_Response_RemoveCardResponse-pinpadType_ExternalPinpadFirst',
                  },
                ],
              },
           ];
  }

   static void parseRspFormRemoveCardResponse(FormRemoveCardResponse rsp, List<Map> rspDataSource) {
      rspDataSource.forEach((element) {
          DataItemType itemType = element[kType];
          String id = element[kID];
          switch (itemType) {
              case DataItemType.CellInput:
                element[kValue] = FormRspData._parseFormRemoveCardResponse(id, rsp);
                break;
              case DataItemType.Group:
                if (element[kBitmapEnable] != null) {
                    element[kBitmapEnable] = true;
                    element[kGroupArrowOpen] = true;
                }
                break;
              case DataItemType.ModelList:
                List<dynamic> map = FormRspData._parseFormRemoveCardResponse(id, rsp) ?? [];
                element[kData] = ResponseListModelQuery.query(id, map);
                break;
              case DataItemType.Menu:
                element[kValue] = FormRspData._parseFormRemoveCardResponse(id, rsp);
                break;
              case DataItemType.StringList:
                List<String> tempData = [];
                List<String?> resData = FormRspData._parseFormRemoveCardResponse(id, rsp) ?? [];
                for (int i = 0; i < resData.length; i++) {
                  String str = resData[i]!;
                  tempData.add(str);
                }
                element[kData] = tempData;
                break;
            case DataItemType.Boolen:
                element[kValue] = FormRspData._parseFormRemoveCardResponse(id, rsp);
                element[kShow] = true;
                break;
              default:
                break;
           }
        });
  }


   static dynamic _parseFormRemoveCardResponse(String id, FormRemoveCardResponse rsp) {
      dynamic result;
      switch (id) {
         case 'Form_Response_RemoveCardResponse-responseCode':
             result = rsp.responseCode;
             break;
         case 'Form_Response_RemoveCardResponse-responseMessage':
             result = rsp.responseMessage;
             break;
         case 'Form_Response_RemoveCardResponse-pinpadType':
             result = rsp.pinpadType;
             break;
         default:
             break;
     }
     return result;
 }

  static List<Map> inputTextData() {
      return [
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseCode',
                kValue: ' ',
                kID: 'Form_Response_InputTextResponse-responseCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseMessage',
                kValue: ' ',
                kID: 'Form_Response_InputTextResponse-responseMessage',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'text',
                kValue: ' ',
                kID: 'Form_Response_InputTextResponse-text',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

   static void parseRspFormInputTextResponse(FormInputTextResponse rsp, List<Map> rspDataSource) {
      rspDataSource.forEach((element) {
          DataItemType itemType = element[kType];
          String id = element[kID];
          switch (itemType) {
              case DataItemType.CellInput:
                element[kValue] = FormRspData._parseFormInputTextResponse(id, rsp);
                break;
              case DataItemType.Group:
                if (element[kBitmapEnable] != null) {
                    element[kBitmapEnable] = true;
                    element[kGroupArrowOpen] = true;
                }
                break;
              case DataItemType.ModelList:
                List<dynamic> map = FormRspData._parseFormInputTextResponse(id, rsp) ?? [];
                element[kData] = ResponseListModelQuery.query(id, map);
                break;
              case DataItemType.Menu:
                element[kValue] = FormRspData._parseFormInputTextResponse(id, rsp);
                break;
              case DataItemType.StringList:
                List<String> tempData = [];
                List<String?> resData = FormRspData._parseFormInputTextResponse(id, rsp) ?? [];
                for (int i = 0; i < resData.length; i++) {
                  String str = resData[i]!;
                  tempData.add(str);
                }
                element[kData] = tempData;
                break;
            case DataItemType.Boolen:
                element[kValue] = FormRspData._parseFormInputTextResponse(id, rsp);
                element[kShow] = true;
                break;
              default:
                break;
           }
        });
  }


   static dynamic _parseFormInputTextResponse(String id, FormInputTextResponse rsp) {
      dynamic result;
      switch (id) {
         case 'Form_Response_InputTextResponse-responseCode':
             result = rsp.responseCode;
             break;
         case 'Form_Response_InputTextResponse-responseMessage':
             result = rsp.responseMessage;
             break;
         case 'Form_Response_InputTextResponse-text':
             result = rsp.text;
             break;
         default:
             break;
     }
     return result;
 }

  static List<Map> clearMessageData() {
      return [
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseCode',
                kValue: ' ',
                kID: 'Form_Response_ClearMessageResponse-responseCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseMessage',
                kValue: ' ',
                kID: 'Form_Response_ClearMessageResponse-responseMessage',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

   static void parseRspFormClearMessageResponse(FormClearMessageResponse rsp, List<Map> rspDataSource) {
      rspDataSource.forEach((element) {
          DataItemType itemType = element[kType];
          String id = element[kID];
          switch (itemType) {
              case DataItemType.CellInput:
                element[kValue] = FormRspData._parseFormClearMessageResponse(id, rsp);
                break;
              case DataItemType.Group:
                if (element[kBitmapEnable] != null) {
                    element[kBitmapEnable] = true;
                    element[kGroupArrowOpen] = true;
                }
                break;
              case DataItemType.ModelList:
                List<dynamic> map = FormRspData._parseFormClearMessageResponse(id, rsp) ?? [];
                element[kData] = ResponseListModelQuery.query(id, map);
                break;
              case DataItemType.Menu:
                element[kValue] = FormRspData._parseFormClearMessageResponse(id, rsp);
                break;
              case DataItemType.StringList:
                List<String> tempData = [];
                List<String?> resData = FormRspData._parseFormClearMessageResponse(id, rsp) ?? [];
                for (int i = 0; i < resData.length; i++) {
                  String str = resData[i]!;
                  tempData.add(str);
                }
                element[kData] = tempData;
                break;
            case DataItemType.Boolen:
                element[kValue] = FormRspData._parseFormClearMessageResponse(id, rsp);
                element[kShow] = true;
                break;
              default:
                break;
           }
        });
  }


   static dynamic _parseFormClearMessageResponse(String id, FormClearMessageResponse rsp) {
      dynamic result;
      switch (id) {
         case 'Form_Response_ClearMessageResponse-responseCode':
             result = rsp.responseCode;
             break;
         case 'Form_Response_ClearMessageResponse-responseMessage':
             result = rsp.responseMessage;
             break;
         default:
             break;
     }
     return result;
 }

  static List<Map> showMessageCenterData() {
      return [
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseCode',
                kValue: ' ',
                kID: 'Form_Response_ShowMessageCenterResponse-responseCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseMessage',
                kValue: ' ',
                kID: 'Form_Response_ShowMessageCenterResponse-responseMessage',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'pinpadType',
                kID: 'Form_Response_ShowMessageCenterResponse-pinpadType',
                kMenuID: 'Form_Response_ShowMessageCenterResponse-pinpadType_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FormPinpadType.NotSet,
                kData: [
                  {
                    kData: FormPinpadType.NotSet,
                    kID: 'Form_Response_ShowMessageCenterResponse-pinpadType_NotSet',
                  },
                  {
                    kData: FormPinpadType.InternalPinpad,
                    kID: 'Form_Response_ShowMessageCenterResponse-pinpadType_InternalPinpad',
                  },
                  {
                    kData: FormPinpadType.ExternalPinpad,
                    kID: 'Form_Response_ShowMessageCenterResponse-pinpadType_ExternalPinpad',
                  },
                  {
                    kData: FormPinpadType.RnibPinpad,
                    kID: 'Form_Response_ShowMessageCenterResponse-pinpadType_RnibPinpad',
                  },
                  {
                    kData: FormPinpadType.ExternalPinpadFirst,
                    kID: 'Form_Response_ShowMessageCenterResponse-pinpadType_ExternalPinpadFirst',
                  },
                ],
              },
           ];
  }

   static void parseRspFormShowMessageCenterResponse(FormShowMessageCenterResponse rsp, List<Map> rspDataSource) {
      rspDataSource.forEach((element) {
          DataItemType itemType = element[kType];
          String id = element[kID];
          switch (itemType) {
              case DataItemType.CellInput:
                element[kValue] = FormRspData._parseFormShowMessageCenterResponse(id, rsp);
                break;
              case DataItemType.Group:
                if (element[kBitmapEnable] != null) {
                    element[kBitmapEnable] = true;
                    element[kGroupArrowOpen] = true;
                }
                break;
              case DataItemType.ModelList:
                List<dynamic> map = FormRspData._parseFormShowMessageCenterResponse(id, rsp) ?? [];
                element[kData] = ResponseListModelQuery.query(id, map);
                break;
              case DataItemType.Menu:
                element[kValue] = FormRspData._parseFormShowMessageCenterResponse(id, rsp);
                break;
              case DataItemType.StringList:
                List<String> tempData = [];
                List<String?> resData = FormRspData._parseFormShowMessageCenterResponse(id, rsp) ?? [];
                for (int i = 0; i < resData.length; i++) {
                  String str = resData[i]!;
                  tempData.add(str);
                }
                element[kData] = tempData;
                break;
            case DataItemType.Boolen:
                element[kValue] = FormRspData._parseFormShowMessageCenterResponse(id, rsp);
                element[kShow] = true;
                break;
              default:
                break;
           }
        });
  }


   static dynamic _parseFormShowMessageCenterResponse(String id, FormShowMessageCenterResponse rsp) {
      dynamic result;
      switch (id) {
         case 'Form_Response_ShowMessageCenterResponse-responseCode':
             result = rsp.responseCode;
             break;
         case 'Form_Response_ShowMessageCenterResponse-responseMessage':
             result = rsp.responseMessage;
             break;
         case 'Form_Response_ShowMessageCenterResponse-pinpadType':
             result = rsp.pinpadType;
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
      case 'ShowMessageCenterRequest':
        list = FormRspData.showMessageCenterData();
        break;
      case 'InputTextRequest':
        list = FormRspData.inputTextData();
        break;
      case 'ClearMessageRequest':
        list = FormRspData.clearMessageData();
        break;
      case 'ShowItemRequest':
        list = FormRspData.showItemData();
        break;
      case 'ShowMessageRequest':
        list = FormRspData.showMessageData();
        break;
      case 'ShowDialogRequest':
        list = FormRspData.showDialogData();
        break;
      case 'ShowTextBoxRequest':
        list = FormRspData.showTextBoxData();
        break;
      case 'ShowDialogFormRequest':
        list = FormRspData.showDialogFormData();
        break;
      case 'RemoveCardRequest':
        list = FormRspData.removeCardData();
        break;
      default:
        list = [];
        break;
    }
    return list;
  }

}

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
import 'package:poslink2/data_source/response_query.dart';
import 'package:poslink2/data_source/request_query.dart';
import 'package:poslink2/auto_pigeon/poslink_sdk_fullintegration.dart';
import 'package:poslink2/auto_pigeon/poslink_sdk_ped.dart';
import 'package:poslink2/auto_pigeon/poslink_sdk_form.dart';
import 'package:poslink2/auto_pigeon/poslink_sdk_payload.dart';
import 'package:poslink2/auto_pigeon/poslink_sdk_customformmanage.dart';
import 'package:poslink2/auto_pigeon/poslink_sdk_manage.dart';
import 'package:poslink2/auto_pigeon/poslink_sdk_device.dart';


class RequestListModelQuery {
  static dynamic query(String id, List<Map> list) {
    if (id == 'Form_Request_ShowTextBoxRequest-hardKeyList') {
      return RequestListEnumShowTextBoxHardKeyListQuery.query(id, list);
    }
   if (id == 'Form_Request_ShowItemRequest-itemDetails') {
     List<List<Map<String, dynamic>>>? dataList;
     for (int i = 0; i < list.length; i++) {
       Map element = list[i];
       if (element[kID] == id) {
         dataList = element[kData];
         break;
       }
     }
     if (dataList == null) {
       return null;
     }
     List<FormItemDetail> resList = [];
     dataList.forEach((List<Map<String, dynamic>> subList) {
       FormItemDetail formItemDetail = FormItemDetail();
       subList.forEach((Map<String, dynamic> jsonObject) {
         String name = jsonObject[kName];
         dynamic subValue = jsonObject[kValue];
           switch (name) {
             case 'productName':
               formItemDetail.productName = subValue;
               break;
             case 'pluCode':
               formItemDetail.pluCode = subValue;
               break;
             case 'price':
               formItemDetail.price = subValue;
               break;
             case 'unit':
               formItemDetail.unit = subValue;
               break;
             case 'unitPrice':
               formItemDetail.unitPrice = subValue;
               break;
             case 'tax':
               formItemDetail.tax = subValue;
               break;
             case 'quantity':
               formItemDetail.quantity = subValue;
               break;
             case 'productImageName':
               formItemDetail.productImageName = subValue;
               break;
             case 'productImageDescription':
               formItemDetail.productImageDescription = subValue;
               break;
           }
       });
       resList.add(formItemDetail);
     });
     return resList;
   }
   if (id == 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleServiceUpdate') {
     List<List<Map<String, dynamic>>>? dataList;
     for (int i = 0; i < list.length; i++) {
       Map element = list[i];
       if (element[kID] == id) {
         dataList = element[kData];
         break;
       }
     }
     if (dataList == null) {
       return null;
     }
     List<ManageServiceUpdate> resList = [];
     dataList.forEach((List<Map<String, dynamic>> subList) {
       ManageServiceUpdate manageServiceUpdate = ManageServiceUpdate();
       subList.forEach((Map<String, dynamic> jsonObject) {
         String name = jsonObject[kName];
         dynamic subValue = jsonObject[kValue];
           switch (name) {
             case 'updateId':
               manageServiceUpdate.updateId = subValue;
               break;
             case 'updateOperation':
               manageServiceUpdate.updateOperation = subValue;
               break;
             case 'updatePayload':
               manageServiceUpdate.updatePayload = subValue;
               break;
           }
       });
       resList.add(manageServiceUpdate);
     });
     return resList;
   }
   if (id == 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleNewService') {
     List<List<Map<String, dynamic>>>? dataList;
     for (int i = 0; i < list.length; i++) {
       Map element = list[i];
       if (element[kID] == id) {
         dataList = element[kData];
         break;
       }
     }
     if (dataList == null) {
       return null;
     }
     List<ManageNewService> resList = [];
     dataList.forEach((List<Map<String, dynamic>> subList) {
       ManageNewService manageNewService = ManageNewService();
       subList.forEach((Map<String, dynamic> jsonObject) {
         String name = jsonObject[kName];
         dynamic subValue = jsonObject[kValue];
           switch (name) {
             case 'type':
               manageNewService.type = subValue;
               break;
             case 'title':
               manageNewService.title = subValue;
               break;
             case 'url':
               manageNewService.url = subValue;
               break;
           }
       });
       resList.add(manageNewService);
     });
     return resList;
   }
   if (id == 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleServiceUsage') {
     List<List<Map<String, dynamic>>>? dataList;
     for (int i = 0; i < list.length; i++) {
       Map element = list[i];
       if (element[kID] == id) {
         dataList = element[kData];
         break;
       }
     }
     if (dataList == null) {
       return null;
     }
     List<ManageServiceUsage> resList = [];
     dataList.forEach((List<Map<String, dynamic>> subList) {
       ManageServiceUsage manageServiceUsage = ManageServiceUsage();
       subList.forEach((Map<String, dynamic> jsonObject) {
         String name = jsonObject[kName];
         dynamic subValue = jsonObject[kValue];
           switch (name) {
             case 'usageId':
               manageServiceUsage.usageId = subValue;
               break;
             case 'state':
               manageServiceUsage.state = subValue;
               break;
             case 'title':
               manageServiceUsage.title = subValue;
               break;
             case 'describe':
               manageServiceUsage.describe = subValue;
               break;
           }
       });
       resList.add(manageServiceUsage);
     });
     return resList;
   }
    dynamic value;
    for (int i = 0; i < list.length; i++) {
      Map element = list[i];
      if (element[kID] == id) {
        value = element[kValue];
        break;
      }
    }
    return value;
  }
}


class ListStringQuery {
  static dynamic query(String id, List<Map> list) {
    for (int i = 0; i < list.length; i++) {
      Map element = list[i];
      if (element[kID] == id) {
        return element[kData];
      }
    }
  }
}




class GroupQuery {
  static bool queryIfNull(String id, List<Map> list) {
    for (int i = 0; i < list.length; i++) {
      Map element = list[i];
      if (element[kID] == id) {
        if (element[kType] == DataItemType.Group && element[kGroupArrowOpen] == false && element[kBitmapEnable] == false) {
          return true;
        }
      }
    }
    return false;
  }
}




class ResponseListModelQuery {
  static List<List<Map<String, dynamic>>>? query(String id, List<dynamic> modelList) {
    if (id == 'Batch_Response_BatchCloseResponse-totalTaxes' || id == 'Batch_Response_BatchCloseResponse-merchantTotals' || id == 'Batch_Response_BatchCloseResponse-merchantTotals_totalTaxes') {
      return ResponseMultipleListModelQuery.query(id, modelList);
    }
    List<List<Map<String, dynamic>>>? res = [];
    for (int i = 0; i < modelList.length; i++) {
      List<Map<String, dynamic>> subList = [];
     if (id == 'Ped_Response_GetPedInformationResponse-tdk') {
       PedMasterSessionKeyInformation pedMasterSessionKeyInformation = modelList[i];
       /// keySlot
       Map<String, dynamic> keySlot = {};
       keySlot[kID] = id + '-' + 'keySlot';
       keySlot[kValue] = pedMasterSessionKeyInformation.keySlot;
       keySlot[kType] = DataItemType.CellInput;
       keySlot[kEnable] = false;
       keySlot[kLevel] = 1;
       keySlot[kName] = 'keySlot';
       keySlot[kShow] = true;
       subList.add(keySlot);
       /// kcv
       Map<String, dynamic> kcv = {};
       kcv[kID] = id + '-' + 'kcv';
       kcv[kValue] = pedMasterSessionKeyInformation.kcv;
       kcv[kType] = DataItemType.CellInput;
       kcv[kEnable] = false;
       kcv[kLevel] = 1;
       kcv[kName] = 'kcv';
       kcv[kShow] = true;
       subList.add(kcv);
      }
     if (id == 'Ped_Response_GetPedInformationResponse-dukptKey') {
       PedDukptKeyInformation pedDukptKeyInformation = modelList[i];
       /// keySlot
       Map<String, dynamic> keySlot = {};
       keySlot[kID] = id + '-' + 'keySlot';
       keySlot[kValue] = pedDukptKeyInformation.keySlot;
       keySlot[kType] = DataItemType.CellInput;
       keySlot[kEnable] = false;
       keySlot[kLevel] = 1;
       keySlot[kName] = 'keySlot';
       keySlot[kShow] = true;
       subList.add(keySlot);
       /// ksn
       Map<String, dynamic> ksn = {};
       ksn[kID] = id + '-' + 'ksn';
       ksn[kValue] = pedDukptKeyInformation.ksn;
       ksn[kType] = DataItemType.CellInput;
       ksn[kEnable] = false;
       ksn[kLevel] = 1;
       ksn[kName] = 'ksn';
       ksn[kShow] = true;
       subList.add(ksn);
       /// kcv
       Map<String, dynamic> kcv = {};
       kcv[kID] = id + '-' + 'kcv';
       kcv[kValue] = pedDukptKeyInformation.kcv;
       kcv[kType] = DataItemType.CellInput;
       kcv[kEnable] = false;
       kcv[kLevel] = 1;
       kcv[kName] = 'kcv';
       kcv[kShow] = true;
       subList.add(kcv);
      }
     if (id == 'Ped_Response_GetPedInformationResponse-aesDukptKey') {
       PedDukptKeyInformation pedDukptKeyInformation = modelList[i];
       /// keySlot
       Map<String, dynamic> keySlot = {};
       keySlot[kID] = id + '-' + 'keySlot';
       keySlot[kValue] = pedDukptKeyInformation.keySlot;
       keySlot[kType] = DataItemType.CellInput;
       keySlot[kEnable] = false;
       keySlot[kLevel] = 1;
       keySlot[kName] = 'keySlot';
       keySlot[kShow] = true;
       subList.add(keySlot);
       /// ksn
       Map<String, dynamic> ksn = {};
       ksn[kID] = id + '-' + 'ksn';
       ksn[kValue] = pedDukptKeyInformation.ksn;
       ksn[kType] = DataItemType.CellInput;
       ksn[kEnable] = false;
       ksn[kLevel] = 1;
       ksn[kName] = 'ksn';
       ksn[kShow] = true;
       subList.add(ksn);
       /// kcv
       Map<String, dynamic> kcv = {};
       kcv[kID] = id + '-' + 'kcv';
       kcv[kValue] = pedDukptKeyInformation.kcv;
       kcv[kType] = DataItemType.CellInput;
       kcv[kEnable] = false;
       kcv[kLevel] = 1;
       kcv[kName] = 'kcv';
       kcv[kShow] = true;
       subList.add(kcv);
      }
     if (id == 'Ped_Response_GetPedInformationResponse-tak') {
       PedMasterSessionKeyInformation pedMasterSessionKeyInformation = modelList[i];
       /// keySlot
       Map<String, dynamic> keySlot = {};
       keySlot[kID] = id + '-' + 'keySlot';
       keySlot[kValue] = pedMasterSessionKeyInformation.keySlot;
       keySlot[kType] = DataItemType.CellInput;
       keySlot[kEnable] = false;
       keySlot[kLevel] = 1;
       keySlot[kName] = 'keySlot';
       keySlot[kShow] = true;
       subList.add(keySlot);
       /// kcv
       Map<String, dynamic> kcv = {};
       kcv[kID] = id + '-' + 'kcv';
       kcv[kValue] = pedMasterSessionKeyInformation.kcv;
       kcv[kType] = DataItemType.CellInput;
       kcv[kEnable] = false;
       kcv[kLevel] = 1;
       kcv[kName] = 'kcv';
       kcv[kShow] = true;
       subList.add(kcv);
      }
     if (id == 'Ped_Response_GetPedInformationResponse-tmk') {
       PedMasterSessionKeyInformation pedMasterSessionKeyInformation = modelList[i];
       /// keySlot
       Map<String, dynamic> keySlot = {};
       keySlot[kID] = id + '-' + 'keySlot';
       keySlot[kValue] = pedMasterSessionKeyInformation.keySlot;
       keySlot[kType] = DataItemType.CellInput;
       keySlot[kEnable] = false;
       keySlot[kLevel] = 1;
       keySlot[kName] = 'keySlot';
       keySlot[kShow] = true;
       subList.add(keySlot);
       /// kcv
       Map<String, dynamic> kcv = {};
       kcv[kID] = id + '-' + 'kcv';
       kcv[kValue] = pedMasterSessionKeyInformation.kcv;
       kcv[kType] = DataItemType.CellInput;
       kcv[kEnable] = false;
       kcv[kLevel] = 1;
       kcv[kName] = 'kcv';
       kcv[kShow] = true;
       subList.add(kcv);
      }
     if (id == 'Ped_Response_GetPedInformationResponse-tpk') {
       PedMasterSessionKeyInformation pedMasterSessionKeyInformation = modelList[i];
       /// keySlot
       Map<String, dynamic> keySlot = {};
       keySlot[kID] = id + '-' + 'keySlot';
       keySlot[kValue] = pedMasterSessionKeyInformation.keySlot;
       keySlot[kType] = DataItemType.CellInput;
       keySlot[kEnable] = false;
       keySlot[kLevel] = 1;
       keySlot[kName] = 'keySlot';
       keySlot[kShow] = true;
       subList.add(keySlot);
       /// kcv
       Map<String, dynamic> kcv = {};
       kcv[kID] = id + '-' + 'kcv';
       kcv[kValue] = pedMasterSessionKeyInformation.kcv;
       kcv[kType] = DataItemType.CellInput;
       kcv[kEnable] = false;
       kcv[kLevel] = 1;
       kcv[kName] = 'kcv';
       kcv[kShow] = true;
       subList.add(kcv);
      }
      res.add(subList);
    }
    return res;
  }
}

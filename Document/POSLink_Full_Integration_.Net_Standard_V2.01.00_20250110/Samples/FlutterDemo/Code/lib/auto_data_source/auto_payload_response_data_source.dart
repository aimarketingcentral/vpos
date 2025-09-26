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
import 'package:poslink2/auto_pigeon/poslink_sdk_payload.dart';
import 'package:poslink2/auto_data_source/auto_query.dart';
class PayloadRspData {
  static List<Map> initSourceData() {
    return PayloadRspData.payloadData();
  }
  static List<Map> payloadData() {
      return [
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseCode',
                kValue: ' ',
                kID: 'Payload_Response_PayloadResponse-responseCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseMessage',
                kValue: ' ',
                kID: 'Payload_Response_PayloadResponse-responseMessage',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'payload',
                kValue: ' ',
                kID: 'Payload_Response_PayloadResponse-payload',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

   static void parseRspPayloadPayloadResponse(PayloadPayloadResponse rsp, List<Map> rspDataSource) {
      rspDataSource.forEach((element) {
          DataItemType itemType = element[kType];
          String id = element[kID];
          switch (itemType) {
              case DataItemType.CellInput:
                element[kValue] = PayloadRspData._parsePayloadPayloadResponse(id, rsp);
                break;
              case DataItemType.Group:
                if (element[kBitmapEnable] != null) {
                    element[kBitmapEnable] = true;
                    element[kGroupArrowOpen] = true;
                }
                break;
              case DataItemType.ModelList:
                List<dynamic> map = PayloadRspData._parsePayloadPayloadResponse(id, rsp) ?? [];
                element[kData] = ResponseListModelQuery.query(id, map);
                break;
              case DataItemType.Menu:
                element[kValue] = PayloadRspData._parsePayloadPayloadResponse(id, rsp);
                break;
              case DataItemType.StringList:
                List<String> tempData = [];
                List<String?> resData = PayloadRspData._parsePayloadPayloadResponse(id, rsp) ?? [];
                for (int i = 0; i < resData.length; i++) {
                  String str = resData[i]!;
                  tempData.add(str);
                }
                element[kData] = tempData;
                break;
            case DataItemType.Boolen:
                element[kValue] = PayloadRspData._parsePayloadPayloadResponse(id, rsp);
                element[kShow] = true;
                break;
              default:
                break;
           }
        });
  }


   static dynamic _parsePayloadPayloadResponse(String id, PayloadPayloadResponse rsp) {
      dynamic result;
      switch (id) {
         case 'Payload_Response_PayloadResponse-responseCode':
             result = rsp.responseCode;
             break;
         case 'Payload_Response_PayloadResponse-responseMessage':
             result = rsp.responseMessage;
             break;
         case 'Payload_Response_PayloadResponse-payload':
             result = rsp.payload;
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
      case 'PayloadRequest':
        list = PayloadRspData.payloadData();
        break;
      default:
        list = [];
        break;
    }
    return list;
  }

}

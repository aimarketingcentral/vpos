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
class PayloadReqData {
  static List<Map> initSourceData() {
    return PayloadReqData.payloadData();
  }
  static List<Map> payloadData() {
      return [
              {
                kEnable: true,
                kLevel: 1,
                kName: 'PayloadCommand',
                kID: 'PayloadCommand',
                kMenuID: 'PayloadCommand_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: PayloadCommand.PayloadRequest,
                kData: [
                  {
                    kData: PayloadCommand.PayloadRequest,
                    kID: 'PayloadCommand_PayloadRequest',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'payload',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Payload_Request_PayloadRequest-payload',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

  static PayloadPayloadRequest formPayloadRequest(List<Map> list) {
    List<Map> queryList = [];
    queryList.addAll(list);
    PayloadPayloadRequest req = PayloadPayloadRequest();
    req.payload = RequestListModelQuery.query('Payload_Request_PayloadRequest-payload',queryList);
    return req;
  }

  static List<Map>? queryDataByString(String string) {
    List tempList = string.split('.');
    if (tempList.length < 2) { return null; }
    String tempStr = tempList[1];
    List<Map> list;
    switch (tempStr) {
      case 'PayloadRequest':
        list = PayloadReqData.payloadData();
        break;
      default:
        list = [];
        break;
    }
    return list;
  }

}

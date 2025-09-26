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
import '../auto_data_source/auto_data_source_common.dart';
import '../auto_pigeon/poslink_sdk_form.dart';

class RequestListEnumShowTextBoxHardKeyListQuery {
  static dynamic query(String id, List<Map> list) {
    if (id == 'Form_Request_ShowTextBoxRequest-hardKeyList') {}
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
    List<String?> resList = [];
    dataList.forEach((List<Map<String, dynamic>> subList) {
      String? stringValue;
      subList.forEach((Map<String, dynamic> jsonObject) {
        FormHardKey subValue = jsonObject[kValue];
        switch (subValue) {
          case FormHardKey.NotSet:
            stringValue = '';
            break;
          case FormHardKey.Key0:
            stringValue = 'KEY0';
            break;
          case FormHardKey.Key1:
            stringValue = 'KEY1';
            break;
          case FormHardKey.Key2:
            stringValue = 'KEY2';
            break;
          case FormHardKey.Key3:
            stringValue = 'KEY3';
            break;
          case FormHardKey.Key4:
            stringValue = 'KEY4';
            break;
          case FormHardKey.Key5:
            stringValue = 'KEY5';
            break;
          case FormHardKey.Key6:
            stringValue = 'KEY6';
            break;
          case FormHardKey.Key7:
            stringValue = 'KEY7';
            break;
          case FormHardKey.Key8:
            stringValue = 'KEY8';
            break;
          case FormHardKey.Key9:
            stringValue = 'KEY9';
            break;
          case FormHardKey.Clear:
            stringValue = 'KEYCLEAR';
            break;
          case FormHardKey.Cancel:
            stringValue = 'KEYCANCEL';
            break;
          case FormHardKey.Ok:
            stringValue = 'KEYENTER';
            break;
        }
      });
      resList.add(stringValue);
    });
    return resList;
  }
}

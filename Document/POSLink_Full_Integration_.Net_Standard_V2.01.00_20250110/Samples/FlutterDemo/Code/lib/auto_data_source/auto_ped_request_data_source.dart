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
class PedReqData {
  static List<Map> initSourceData() {
    return PedReqData.getPedInformationData();
  }
  static List<Map> getPedInformationData() {
      return [
              {
                kEnable: true,
                kLevel: 1,
                kName: 'PedCommand',
                kID: 'PedCommand',
                kMenuID: 'PedCommand_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: PedCommand.GetPedInformationRequest,
                kData: [
                  {
                    kData: PedCommand.GetPedInformationRequest,
                    kID: 'PedCommand_GetPedInformationRequest',
                  },
                  {
                    kData: PedCommand.IncreaseKsnRequest,
                    kID: 'PedCommand_IncreaseKsnRequest',
                  },
                  {
                    kData: PedCommand.SessionKeyInjectionRequest,
                    kID: 'PedCommand_SessionKeyInjectionRequest',
                  },
                  {
                    kData: PedCommand.MacCalculationRequest,
                    kID: 'PedCommand_MacCalculationRequest',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'keyType',
                kID: 'Ped_Request_GetPedInformationRequest-keyType',
                kMenuID: 'Ped_Request_GetPedInformationRequest-keyType_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: PedKeyType.NotSet,
                kData: [
                  {
                    kData: PedKeyType.NotSet,
                    kID: 'Ped_Request_GetPedInformationRequest-keyType_NotSet',
                  },
                  {
                    kData: PedKeyType.MasterKey,
                    kID: 'Ped_Request_GetPedInformationRequest-keyType_MasterKey',
                  },
                  {
                    kData: PedKeyType.SessionKey,
                    kID: 'Ped_Request_GetPedInformationRequest-keyType_SessionKey',
                  },
                  {
                    kData: PedKeyType.DesDukptKey,
                    kID: 'Ped_Request_GetPedInformationRequest-keyType_DesDukptKey',
                  },
                  {
                    kData: PedKeyType.AesDukptKey,
                    kID: 'Ped_Request_GetPedInformationRequest-keyType_AesDukptKey',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'keySlot',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Ped_Request_GetPedInformationRequest-keySlot',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

  static PedGetPedInformationRequest formGetPedInformationRequest(List<Map> list) {
    List<Map> queryList = [];
    queryList.addAll(list);
    PedGetPedInformationRequest req = PedGetPedInformationRequest();
    req.keyType = RequestListModelQuery.query('Ped_Request_GetPedInformationRequest-keyType',queryList);
    req.keySlot = RequestListModelQuery.query('Ped_Request_GetPedInformationRequest-keySlot',queryList);
    return req;
  }

  static List<Map> increaseKsnData() {
      return [
              {
                kEnable: true,
                kLevel: 1,
                kName: 'PedCommand',
                kID: 'PedCommand',
                kMenuID: 'PedCommand_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: PedCommand.GetPedInformationRequest,
                kData: [
                  {
                    kData: PedCommand.GetPedInformationRequest,
                    kID: 'PedCommand_GetPedInformationRequest',
                  },
                  {
                    kData: PedCommand.IncreaseKsnRequest,
                    kID: 'PedCommand_IncreaseKsnRequest',
                  },
                  {
                    kData: PedCommand.SessionKeyInjectionRequest,
                    kID: 'PedCommand_SessionKeyInjectionRequest',
                  },
                  {
                    kData: PedCommand.MacCalculationRequest,
                    kID: 'PedCommand_MacCalculationRequest',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'keyType',
                kID: 'Ped_Request_IncreaseKsnRequest-keyType',
                kMenuID: 'Ped_Request_IncreaseKsnRequest-keyType_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: PedKeyType.NotSet,
                kData: [
                  {
                    kData: PedKeyType.NotSet,
                    kID: 'Ped_Request_IncreaseKsnRequest-keyType_NotSet',
                  },
                  {
                    kData: PedKeyType.MasterKey,
                    kID: 'Ped_Request_IncreaseKsnRequest-keyType_MasterKey',
                  },
                  {
                    kData: PedKeyType.SessionKey,
                    kID: 'Ped_Request_IncreaseKsnRequest-keyType_SessionKey',
                  },
                  {
                    kData: PedKeyType.DesDukptKey,
                    kID: 'Ped_Request_IncreaseKsnRequest-keyType_DesDukptKey',
                  },
                  {
                    kData: PedKeyType.AesDukptKey,
                    kID: 'Ped_Request_IncreaseKsnRequest-keyType_AesDukptKey',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'keySlot',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'Ped_Request_IncreaseKsnRequest-keySlot',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

  static PedIncreaseKsnRequest formIncreaseKsnRequest(List<Map> list) {
    List<Map> queryList = [];
    queryList.addAll(list);
    PedIncreaseKsnRequest req = PedIncreaseKsnRequest();
    req.keyType = RequestListModelQuery.query('Ped_Request_IncreaseKsnRequest-keyType',queryList);
    req.keySlot = RequestListModelQuery.query('Ped_Request_IncreaseKsnRequest-keySlot',queryList);
    return req;
  }

  static List<Map> sessionKeyInjectionData() {
      return [
              {
                kEnable: true,
                kLevel: 1,
                kName: 'PedCommand',
                kID: 'PedCommand',
                kMenuID: 'PedCommand_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: PedCommand.GetPedInformationRequest,
                kData: [
                  {
                    kData: PedCommand.GetPedInformationRequest,
                    kID: 'PedCommand_GetPedInformationRequest',
                  },
                  {
                    kData: PedCommand.IncreaseKsnRequest,
                    kID: 'PedCommand_IncreaseKsnRequest',
                  },
                  {
                    kData: PedCommand.SessionKeyInjectionRequest,
                    kID: 'PedCommand_SessionKeyInjectionRequest',
                  },
                  {
                    kData: PedCommand.MacCalculationRequest,
                    kID: 'PedCommand_MacCalculationRequest',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'sourceKeyType',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'Ped_Request_SessionKeyInjectionRequest-sourceKeyType',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'sourceKeyIndex',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'Ped_Request_SessionKeyInjectionRequest-sourceKeyIndex',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'destinationKeyType',
                kID: 'Ped_Request_SessionKeyInjectionRequest-destinationKeyType',
                kMenuID: 'Ped_Request_SessionKeyInjectionRequest-destinationKeyType_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: PedDestinationKeyType.NotSet,
                kData: [
                  {
                    kData: PedDestinationKeyType.NotSet,
                    kID: 'Ped_Request_SessionKeyInjectionRequest-destinationKeyType_NotSet',
                  },
                  {
                    kData: PedDestinationKeyType.Tpk,
                    kID: 'Ped_Request_SessionKeyInjectionRequest-destinationKeyType_Tpk',
                  },
                  {
                    kData: PedDestinationKeyType.Tak,
                    kID: 'Ped_Request_SessionKeyInjectionRequest-destinationKeyType_Tak',
                  },
                  {
                    kData: PedDestinationKeyType.Tdk,
                    kID: 'Ped_Request_SessionKeyInjectionRequest-destinationKeyType_Tdk',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'destinationKeyIndex',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'Ped_Request_SessionKeyInjectionRequest-destinationKeyIndex',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'destinationKeyValue',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Ped_Request_SessionKeyInjectionRequest-destinationKeyValue',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'checkMode',
                kID: 'Ped_Request_SessionKeyInjectionRequest-checkMode',
                kMenuID: 'Ped_Request_SessionKeyInjectionRequest-checkMode_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: PedCheckMode.NotSet,
                kData: [
                  {
                    kData: PedCheckMode.NotSet,
                    kID: 'Ped_Request_SessionKeyInjectionRequest-checkMode_NotSet',
                  },
                  {
                    kData: PedCheckMode.NoKcvCheck,
                    kID: 'Ped_Request_SessionKeyInjectionRequest-checkMode_NoKcvCheck',
                  },
                  {
                    kData: PedCheckMode.DesOrTdesEncryptionAndCheckKcv,
                    kID: 'Ped_Request_SessionKeyInjectionRequest-checkMode_DesOrTdesEncryptionAndCheckKcv',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'checkBuffer',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Ped_Request_SessionKeyInjectionRequest-checkBuffer',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

  static PedSessionKeyInjectionRequest formSessionKeyInjectionRequest(List<Map> list) {
    List<Map> queryList = [];
    queryList.addAll(list);
    PedSessionKeyInjectionRequest req = PedSessionKeyInjectionRequest();
    req.sourceKeyType = RequestListModelQuery.query('Ped_Request_SessionKeyInjectionRequest-sourceKeyType',queryList);
    req.sourceKeyIndex = RequestListModelQuery.query('Ped_Request_SessionKeyInjectionRequest-sourceKeyIndex',queryList);
    req.destinationKeyType = RequestListModelQuery.query('Ped_Request_SessionKeyInjectionRequest-destinationKeyType',queryList);
    req.destinationKeyIndex = RequestListModelQuery.query('Ped_Request_SessionKeyInjectionRequest-destinationKeyIndex',queryList);
    req.destinationKeyValue = RequestListModelQuery.query('Ped_Request_SessionKeyInjectionRequest-destinationKeyValue',queryList);
    req.checkMode = RequestListModelQuery.query('Ped_Request_SessionKeyInjectionRequest-checkMode',queryList);
    req.checkBuffer = RequestListModelQuery.query('Ped_Request_SessionKeyInjectionRequest-checkBuffer',queryList);
    return req;
  }

  static List<Map> macCalculationData() {
      return [
              {
                kEnable: true,
                kLevel: 1,
                kName: 'PedCommand',
                kID: 'PedCommand',
                kMenuID: 'PedCommand_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: PedCommand.GetPedInformationRequest,
                kData: [
                  {
                    kData: PedCommand.GetPedInformationRequest,
                    kID: 'PedCommand_GetPedInformationRequest',
                  },
                  {
                    kData: PedCommand.IncreaseKsnRequest,
                    kID: 'PedCommand_IncreaseKsnRequest',
                  },
                  {
                    kData: PedCommand.SessionKeyInjectionRequest,
                    kID: 'PedCommand_SessionKeyInjectionRequest',
                  },
                  {
                    kData: PedCommand.MacCalculationRequest,
                    kID: 'PedCommand_MacCalculationRequest',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'inputData',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Ped_Request_MacCalculationRequest-inputData',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'encryptionBitmap',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Ped_Request_MacCalculationRequest-encryptionBitmap',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'macKeySlot',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'Ped_Request_MacCalculationRequest-macKeySlot',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'macWorkMode',
                kID: 'Ped_Request_MacCalculationRequest-macWorkMode',
                kMenuID: 'Ped_Request_MacCalculationRequest-macWorkMode_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: PedMacWorkMode.NotSet,
                kData: [
                  {
                    kData: PedMacWorkMode.NotSet,
                    kID: 'Ped_Request_MacCalculationRequest-macWorkMode_NotSet',
                  },
                  {
                    kData: PedMacWorkMode.AnsiX99,
                    kID: 'Ped_Request_MacCalculationRequest-macWorkMode_AnsiX99',
                  },
                  {
                    kData: PedMacWorkMode.HypercomFastMode,
                    kID: 'Ped_Request_MacCalculationRequest-macWorkMode_HypercomFastMode',
                  },
                  {
                    kData: PedMacWorkMode.AnsiX919,
                    kID: 'Ped_Request_MacCalculationRequest-macWorkMode_AnsiX919',
                  },
                  {
                    kData: PedMacWorkMode.Sha1,
                    kID: 'Ped_Request_MacCalculationRequest-macWorkMode_Sha1',
                  },
                  {
                    kData: PedMacWorkMode.Sha256,
                    kID: 'Ped_Request_MacCalculationRequest-macWorkMode_Sha256',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'encryptionKeySlot',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'Ped_Request_MacCalculationRequest-encryptionKeySlot',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'paddingChar',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Ped_Request_MacCalculationRequest-paddingChar',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'macKeyType',
                kID: 'Ped_Request_MacCalculationRequest-macKeyType',
                kMenuID: 'Ped_Request_MacCalculationRequest-macKeyType_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: PedMacCalculationKeyType.NotSet,
                kData: [
                  {
                    kData: PedMacCalculationKeyType.NotSet,
                    kID: 'Ped_Request_MacCalculationRequest-macKeyType_NotSet',
                  },
                  {
                    kData: PedMacCalculationKeyType.Tak,
                    kID: 'Ped_Request_MacCalculationRequest-macKeyType_Tak',
                  },
                  {
                    kData: PedMacCalculationKeyType.DesDukptKey,
                    kID: 'Ped_Request_MacCalculationRequest-macKeyType_DesDukptKey',
                  },
                  {
                    kData: PedMacCalculationKeyType.AesDukptKey,
                    kID: 'Ped_Request_MacCalculationRequest-macKeyType_AesDukptKey',
                  },
                  {
                    kData: PedMacCalculationKeyType.Aes192DukptKey,
                    kID: 'Ped_Request_MacCalculationRequest-macKeyType_Aes192DukptKey',
                  },
                  {
                    kData: PedMacCalculationKeyType.Aes256DukptKey,
                    kID: 'Ped_Request_MacCalculationRequest-macKeyType_Aes256DukptKey',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'ksnFlag',
                kID: 'Ped_Request_MacCalculationRequest-ksnFlag',
                kMenuID: 'Ped_Request_MacCalculationRequest-ksnFlag_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: PedKsnFlag.NotSet,
                kData: [
                  {
                    kData: PedKsnFlag.NotSet,
                    kID: 'Ped_Request_MacCalculationRequest-ksnFlag_NotSet',
                  },
                  {
                    kData: PedKsnFlag.NotIncrease,
                    kID: 'Ped_Request_MacCalculationRequest-ksnFlag_NotIncrease',
                  },
                  {
                    kData: PedKsnFlag.Increase,
                    kID: 'Ped_Request_MacCalculationRequest-ksnFlag_Increase',
                  },
                ],
              },
           ];
  }

  static PedMacCalculationRequest formMacCalculationRequest(List<Map> list) {
    List<Map> queryList = [];
    queryList.addAll(list);
    PedMacCalculationRequest req = PedMacCalculationRequest();
    req.inputData = RequestListModelQuery.query('Ped_Request_MacCalculationRequest-inputData',queryList);
    req.encryptionBitmap = RequestListModelQuery.query('Ped_Request_MacCalculationRequest-encryptionBitmap',queryList);
    req.macKeySlot = RequestListModelQuery.query('Ped_Request_MacCalculationRequest-macKeySlot',queryList);
    req.macWorkMode = RequestListModelQuery.query('Ped_Request_MacCalculationRequest-macWorkMode',queryList);
    req.encryptionKeySlot = RequestListModelQuery.query('Ped_Request_MacCalculationRequest-encryptionKeySlot',queryList);
    req.paddingChar = RequestListModelQuery.query('Ped_Request_MacCalculationRequest-paddingChar',queryList);
    req.macKeyType = RequestListModelQuery.query('Ped_Request_MacCalculationRequest-macKeyType',queryList);
    req.ksnFlag = RequestListModelQuery.query('Ped_Request_MacCalculationRequest-ksnFlag',queryList);
    return req;
  }

  static List<Map>? queryDataByString(String string) {
    List tempList = string.split('.');
    if (tempList.length < 2) { return null; }
    String tempStr = tempList[1];
    List<Map> list;
    switch (tempStr) {
      case 'GetPedInformationRequest':
        list = PedReqData.getPedInformationData();
        break;
      case 'IncreaseKsnRequest':
        list = PedReqData.increaseKsnData();
        break;
      case 'SessionKeyInjectionRequest':
        list = PedReqData.sessionKeyInjectionData();
        break;
      case 'MacCalculationRequest':
        list = PedReqData.macCalculationData();
        break;
      default:
        list = [];
        break;
    }
    return list;
  }

}

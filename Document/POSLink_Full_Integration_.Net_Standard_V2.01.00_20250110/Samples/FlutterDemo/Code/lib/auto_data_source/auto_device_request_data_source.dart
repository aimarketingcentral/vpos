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
class DeviceReqData {
  static List<Map> initSourceData() {
    return DeviceReqData.mifareCardData();
  }
  static List<Map> mifareCardData() {
      return [
              {
                kEnable: true,
                kLevel: 1,
                kName: 'DeviceCommand',
                kID: 'DeviceCommand',
                kMenuID: 'DeviceCommand_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: DeviceCommand.MifareCardRequest,
                kData: [
                  {
                    kData: DeviceCommand.MifareCardRequest,
                    kID: 'DeviceCommand_MifareCardRequest',
                  },
                  {
                    kData: DeviceCommand.CameraScanRequest,
                    kID: 'DeviceCommand_CameraScanRequest',
                  },
                  {
                    kData: DeviceCommand.PrinterRequest,
                    kID: 'DeviceCommand_PrinterRequest',
                  },
                  {
                    kData: DeviceCommand.CardInsertDetectionRequest,
                    kID: 'DeviceCommand_CardInsertDetectionRequest',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'm1Command',
                kID: 'Device_Request_MifareCardRequest-m1Command',
                kMenuID: 'Device_Request_MifareCardRequest-m1Command_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: DeviceM1CommandType.NotSet,
                kData: [
                  {
                    kData: DeviceM1CommandType.NotSet,
                    kID: 'Device_Request_MifareCardRequest-m1Command_NotSet',
                  },
                  {
                    kData: DeviceM1CommandType.Read,
                    kID: 'Device_Request_MifareCardRequest-m1Command_Read',
                  },
                  {
                    kData: DeviceM1CommandType.Write,
                    kID: 'Device_Request_MifareCardRequest-m1Command_Write',
                  },
                  {
                    kData: DeviceM1CommandType.OperateWithIncreaseValue,
                    kID: 'Device_Request_MifareCardRequest-m1Command_OperateWithIncreaseValue',
                  },
                  {
                    kData: DeviceM1CommandType.OperateWithDecreaseValue,
                    kID: 'Device_Request_MifareCardRequest-m1Command_OperateWithDecreaseValue',
                  },
                  {
                    kData: DeviceM1CommandType.OperateWithBackupValue,
                    kID: 'Device_Request_MifareCardRequest-m1Command_OperateWithBackupValue',
                  },
                  {
                    kData: DeviceM1CommandType.ReadTheSerialNumber,
                    kID: 'Device_Request_MifareCardRequest-m1Command_ReadTheSerialNumber',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'blockNumber',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'Device_Request_MifareCardRequest-blockNumber',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'password',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Device_Request_MifareCardRequest-password',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'passwordType',
                kID: 'Device_Request_MifareCardRequest-passwordType',
                kMenuID: 'Device_Request_MifareCardRequest-passwordType_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: DevicePasswordType.NotSet,
                kData: [
                  {
                    kData: DevicePasswordType.NotSet,
                    kID: 'Device_Request_MifareCardRequest-passwordType_NotSet',
                  },
                  {
                    kData: DevicePasswordType.AType,
                    kID: 'Device_Request_MifareCardRequest-passwordType_AType',
                  },
                  {
                    kData: DevicePasswordType.BType,
                    kID: 'Device_Request_MifareCardRequest-passwordType_BType',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'blockValue',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Device_Request_MifareCardRequest-blockValue',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'updateBlockNumber',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'Device_Request_MifareCardRequest-updateBlockNumber',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'timeout',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '0.1s',
                kID: 'Device_Request_MifareCardRequest-timeout',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

  static DeviceMifareCardRequest formMifareCardRequest(List<Map> list) {
    List<Map> queryList = [];
    queryList.addAll(list);
    DeviceMifareCardRequest req = DeviceMifareCardRequest();
    req.m1Command = RequestListModelQuery.query('Device_Request_MifareCardRequest-m1Command',queryList);
    req.blockNumber = RequestListModelQuery.query('Device_Request_MifareCardRequest-blockNumber',queryList);
    req.password = RequestListModelQuery.query('Device_Request_MifareCardRequest-password',queryList);
    req.passwordType = RequestListModelQuery.query('Device_Request_MifareCardRequest-passwordType',queryList);
    req.blockValue = RequestListModelQuery.query('Device_Request_MifareCardRequest-blockValue',queryList);
    req.updateBlockNumber = RequestListModelQuery.query('Device_Request_MifareCardRequest-updateBlockNumber',queryList);
    req.timeout = RequestListModelQuery.query('Device_Request_MifareCardRequest-timeout',queryList);
    return req;
  }

  static List<Map> cameraScanData() {
      return [
              {
                kEnable: true,
                kLevel: 1,
                kName: 'DeviceCommand',
                kID: 'DeviceCommand',
                kMenuID: 'DeviceCommand_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: DeviceCommand.MifareCardRequest,
                kData: [
                  {
                    kData: DeviceCommand.MifareCardRequest,
                    kID: 'DeviceCommand_MifareCardRequest',
                  },
                  {
                    kData: DeviceCommand.CameraScanRequest,
                    kID: 'DeviceCommand_CameraScanRequest',
                  },
                  {
                    kData: DeviceCommand.PrinterRequest,
                    kID: 'DeviceCommand_PrinterRequest',
                  },
                  {
                    kData: DeviceCommand.CardInsertDetectionRequest,
                    kID: 'DeviceCommand_CardInsertDetectionRequest',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'reader',
                kID: 'Device_Request_CameraScanRequest-reader',
                kMenuID: 'Device_Request_CameraScanRequest-reader_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: DeviceReaderType.NotSet,
                kData: [
                  {
                    kData: DeviceReaderType.NotSet,
                    kID: 'Device_Request_CameraScanRequest-reader_NotSet',
                  },
                  {
                    kData: DeviceReaderType.RearCamera,
                    kID: 'Device_Request_CameraScanRequest-reader_RearCamera',
                  },
                  {
                    kData: DeviceReaderType.FrontCamera,
                    kID: 'Device_Request_CameraScanRequest-reader_FrontCamera',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'timeout',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '0.1s',
                kID: 'Device_Request_CameraScanRequest-timeout',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

  static DeviceCameraScanRequest formCameraScanRequest(List<Map> list) {
    List<Map> queryList = [];
    queryList.addAll(list);
    DeviceCameraScanRequest req = DeviceCameraScanRequest();
    req.reader = RequestListModelQuery.query('Device_Request_CameraScanRequest-reader',queryList);
    req.timeout = RequestListModelQuery.query('Device_Request_CameraScanRequest-timeout',queryList);
    return req;
  }

  static List<Map> printerData() {
      return [
              {
                kEnable: true,
                kLevel: 1,
                kName: 'DeviceCommand',
                kID: 'DeviceCommand',
                kMenuID: 'DeviceCommand_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: DeviceCommand.MifareCardRequest,
                kData: [
                  {
                    kData: DeviceCommand.MifareCardRequest,
                    kID: 'DeviceCommand_MifareCardRequest',
                  },
                  {
                    kData: DeviceCommand.CameraScanRequest,
                    kID: 'DeviceCommand_CameraScanRequest',
                  },
                  {
                    kData: DeviceCommand.PrinterRequest,
                    kID: 'DeviceCommand_PrinterRequest',
                  },
                  {
                    kData: DeviceCommand.CardInsertDetectionRequest,
                    kID: 'DeviceCommand_CardInsertDetectionRequest',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'printCopy',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'Device_Request_PrinterRequest-printCopy',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'printData',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Device_Request_PrinterRequest-printData',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

  static DevicePrinterRequest formPrinterRequest(List<Map> list) {
    List<Map> queryList = [];
    queryList.addAll(list);
    DevicePrinterRequest req = DevicePrinterRequest();
    req.printCopy = RequestListModelQuery.query('Device_Request_PrinterRequest-printCopy',queryList);
    req.printData = RequestListModelQuery.query('Device_Request_PrinterRequest-printData',queryList);
    return req;
  }

  static List<Map> cardInsertDetectionData() {
      return [
              {
                kEnable: true,
                kLevel: 1,
                kName: 'DeviceCommand',
                kID: 'DeviceCommand',
                kMenuID: 'DeviceCommand_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: DeviceCommand.MifareCardRequest,
                kData: [
                  {
                    kData: DeviceCommand.MifareCardRequest,
                    kID: 'DeviceCommand_MifareCardRequest',
                  },
                  {
                    kData: DeviceCommand.CameraScanRequest,
                    kID: 'DeviceCommand_CameraScanRequest',
                  },
                  {
                    kData: DeviceCommand.PrinterRequest,
                    kID: 'DeviceCommand_PrinterRequest',
                  },
                  {
                    kData: DeviceCommand.CardInsertDetectionRequest,
                    kID: 'DeviceCommand_CardInsertDetectionRequest',
                  },
                ],
              },
           ];
  }

  static DeviceCardInsertDetectionRequest formCardInsertDetectionRequest(List<Map> list) {
    List<Map> queryList = [];
    queryList.addAll(list);
    DeviceCardInsertDetectionRequest req = DeviceCardInsertDetectionRequest();
    req.classID = RequestListModelQuery.query('Device_Request_CardInsertDetectionRequest-classID',queryList);
    return req;
  }

  static List<Map>? queryDataByString(String string) {
    List tempList = string.split('.');
    if (tempList.length < 2) { return null; }
    String tempStr = tempList[1];
    List<Map> list;
    switch (tempStr) {
      case 'MifareCardRequest':
        list = DeviceReqData.mifareCardData();
        break;
      case 'CameraScanRequest':
        list = DeviceReqData.cameraScanData();
        break;
      case 'PrinterRequest':
        list = DeviceReqData.printerData();
        break;
      case 'CardInsertDetectionRequest':
        list = DeviceReqData.cardInsertDetectionData();
        break;
      default:
        list = [];
        break;
    }
    return list;
  }

}

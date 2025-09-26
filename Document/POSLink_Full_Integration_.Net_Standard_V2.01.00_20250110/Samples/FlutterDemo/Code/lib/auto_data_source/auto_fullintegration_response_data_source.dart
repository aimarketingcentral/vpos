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
import 'package:poslink2/auto_pigeon/poslink_sdk_fullintegration.dart';
import 'package:poslink2/auto_data_source/auto_query.dart';
class FullIntegrationRspData {
  static List<Map> initSourceData() {
    return FullIntegrationRspData.getEmvTlvDataData();
  }
  static List<Map> getEmvTlvDataData() {
      return [
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseCode',
                kValue: ' ',
                kID: 'FullIntegration_Response_GetEmvTlvDataResponse-responseCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseMessage',
                kValue: ' ',
                kID: 'FullIntegration_Response_GetEmvTlvDataResponse-responseMessage',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'emvTlvData',
                kValue: ' ',
                kID: 'FullIntegration_Response_GetEmvTlvDataResponse-emvTlvData',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

   static void parseRspFullIntegrationGetEmvTlvDataResponse(FullIntegrationGetEmvTlvDataResponse rsp, List<Map> rspDataSource) {
      rspDataSource.forEach((element) {
          DataItemType itemType = element[kType];
          String id = element[kID];
          switch (itemType) {
              case DataItemType.CellInput:
                element[kValue] = FullIntegrationRspData._parseFullIntegrationGetEmvTlvDataResponse(id, rsp);
                break;
              case DataItemType.Group:
                if (element[kBitmapEnable] != null) {
                    element[kBitmapEnable] = true;
                    element[kGroupArrowOpen] = true;
                }
                break;
              case DataItemType.ModelList:
                List<dynamic> map = FullIntegrationRspData._parseFullIntegrationGetEmvTlvDataResponse(id, rsp) ?? [];
                element[kData] = ResponseListModelQuery.query(id, map);
                break;
              case DataItemType.Menu:
                element[kValue] = FullIntegrationRspData._parseFullIntegrationGetEmvTlvDataResponse(id, rsp);
                break;
              case DataItemType.StringList:
                List<String> tempData = [];
                List<String?> resData = FullIntegrationRspData._parseFullIntegrationGetEmvTlvDataResponse(id, rsp) ?? [];
                for (int i = 0; i < resData.length; i++) {
                  String str = resData[i]!;
                  tempData.add(str);
                }
                element[kData] = tempData;
                break;
            case DataItemType.Boolen:
                element[kValue] = FullIntegrationRspData._parseFullIntegrationGetEmvTlvDataResponse(id, rsp);
                element[kShow] = true;
                break;
              default:
                break;
           }
        });
  }


   static dynamic _parseFullIntegrationGetEmvTlvDataResponse(String id, FullIntegrationGetEmvTlvDataResponse rsp) {
      dynamic result;
      switch (id) {
         case 'FullIntegration_Response_GetEmvTlvDataResponse-responseCode':
             result = rsp.responseCode;
             break;
         case 'FullIntegration_Response_GetEmvTlvDataResponse-responseMessage':
             result = rsp.responseMessage;
             break;
         case 'FullIntegration_Response_GetEmvTlvDataResponse-emvTlvData':
             result = rsp.emvTlvData;
             break;
         default:
             break;
     }
     return result;
 }

  static List<Map> inputAccountWithEmvData() {
      return [
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseCode',
                kValue: ' ',
                kID: 'FullIntegration_Response_InputAccountWithEmvResponse-responseCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseMessage',
                kValue: ' ',
                kID: 'FullIntegration_Response_InputAccountWithEmvResponse-responseMessage',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'entryMode',
                kID: 'FullIntegration_Response_InputAccountWithEmvResponse-entryMode',
                kMenuID: 'FullIntegration_Response_InputAccountWithEmvResponse-entryMode_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationEntryMode.NotSet,
                kData: [
                  {
                    kData: FullIntegrationEntryMode.NotSet,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-entryMode_NotSet',
                  },
                  {
                    kData: FullIntegrationEntryMode.Manual,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-entryMode_Manual',
                  },
                  {
                    kData: FullIntegrationEntryMode.Swipe,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-entryMode_Swipe',
                  },
                  {
                    kData: FullIntegrationEntryMode.Contactless,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-entryMode_Contactless',
                  },
                  {
                    kData: FullIntegrationEntryMode.LaserScanner,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-entryMode_LaserScanner',
                  },
                  {
                    kData: FullIntegrationEntryMode.Chip,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-entryMode_Chip',
                  },
                  {
                    kData: FullIntegrationEntryMode.ChipFallBackSwipe,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-entryMode_ChipFallBackSwipe',
                  },
                  {
                    kData: FullIntegrationEntryMode.FrontCamera,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-entryMode_FrontCamera',
                  },
                  {
                    kData: FullIntegrationEntryMode.RearCamera,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-entryMode_RearCamera',
                  },
                ],
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'track1Data',
                kValue: ' ',
                kID: 'FullIntegration_Response_InputAccountWithEmvResponse-track1Data',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'track2Data',
                kValue: ' ',
                kID: 'FullIntegration_Response_InputAccountWithEmvResponse-track2Data',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'track3Data',
                kValue: ' ',
                kID: 'FullIntegration_Response_InputAccountWithEmvResponse-track3Data',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'pan',
                kValue: ' ',
                kID: 'FullIntegration_Response_InputAccountWithEmvResponse-pan',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'maskedPan',
                kValue: ' ',
                kID: 'FullIntegration_Response_InputAccountWithEmvResponse-maskedPan',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'barcodeType',
                kID: 'FullIntegration_Response_InputAccountWithEmvResponse-barcodeType',
                kMenuID: 'FullIntegration_Response_InputAccountWithEmvResponse-barcodeType_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationBarcodeType.NotSet,
                kData: [
                  {
                    kData: FullIntegrationBarcodeType.NotSet,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-barcodeType_NotSet',
                  },
                  {
                    kData: FullIntegrationBarcodeType.QrCode,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-barcodeType_QrCode',
                  },
                  {
                    kData: FullIntegrationBarcodeType.TwoDimensionalBarcode,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-barcodeType_TwoDimensionalBarcode',
                  },
                  {
                    kData: FullIntegrationBarcodeType.ThreeDimensionalBarcode,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-barcodeType_ThreeDimensionalBarcode',
                  },
                ],
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'barcodeData',
                kValue: ' ',
                kID: 'FullIntegration_Response_InputAccountWithEmvResponse-barcodeData',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'ksn',
                kValue: ' ',
                kID: 'FullIntegration_Response_InputAccountWithEmvResponse-ksn',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'etb',
                kValue: ' ',
                kID: 'FullIntegration_Response_InputAccountWithEmvResponse-etb',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'contactlessTransactionPath',
                kID: 'FullIntegration_Response_InputAccountWithEmvResponse-contactlessTransactionPath',
                kMenuID: 'FullIntegration_Response_InputAccountWithEmvResponse-contactlessTransactionPath_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationContactlessTransactionPath.NotSet,
                kData: [
                  {
                    kData: FullIntegrationContactlessTransactionPath.NotSet,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-contactlessTransactionPath_NotSet',
                  },
                  {
                    kData: FullIntegrationContactlessTransactionPath.PaypassMsd,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-contactlessTransactionPath_PaypassMsd',
                  },
                  {
                    kData: FullIntegrationContactlessTransactionPath.PaypassMchip,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-contactlessTransactionPath_PaypassMchip',
                  },
                  {
                    kData: FullIntegrationContactlessTransactionPath.PaywaveMsd,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-contactlessTransactionPath_PaywaveMsd',
                  },
                  {
                    kData: FullIntegrationContactlessTransactionPath.PaywaveQvsdc,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-contactlessTransactionPath_PaywaveQvsdc',
                  },
                  {
                    kData: FullIntegrationContactlessTransactionPath.PaywaveContact,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-contactlessTransactionPath_PaywaveContact',
                  },
                  {
                    kData: FullIntegrationContactlessTransactionPath.PaywaveWave2,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-contactlessTransactionPath_PaywaveWave2',
                  },
                  {
                    kData: FullIntegrationContactlessTransactionPath.PaywaveMsdCvn17,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-contactlessTransactionPath_PaywaveMsdCvn17',
                  },
                  {
                    kData: FullIntegrationContactlessTransactionPath.PaywaveMsdLegacy,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-contactlessTransactionPath_PaywaveMsdLegacy',
                  },
                  {
                    kData: FullIntegrationContactlessTransactionPath.PaywaveVsdc,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-contactlessTransactionPath_PaywaveVsdc',
                  },
                  {
                    kData: FullIntegrationContactlessTransactionPath.DpasMsd,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-contactlessTransactionPath_DpasMsd',
                  },
                  {
                    kData: FullIntegrationContactlessTransactionPath.DpasEmv,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-contactlessTransactionPath_DpasEmv',
                  },
                  {
                    kData: FullIntegrationContactlessTransactionPath.DpasZip,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-contactlessTransactionPath_DpasZip',
                  },
                  {
                    kData: FullIntegrationContactlessTransactionPath.ExpressPayMsd,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-contactlessTransactionPath_ExpressPayMsd',
                  },
                  {
                    kData: FullIntegrationContactlessTransactionPath.ExpressPayEmv,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-contactlessTransactionPath_ExpressPayEmv',
                  },
                  {
                    kData: FullIntegrationContactlessTransactionPath.JcbMsd,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-contactlessTransactionPath_JcbMsd',
                  },
                  {
                    kData: FullIntegrationContactlessTransactionPath.JcbEmv,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-contactlessTransactionPath_JcbEmv',
                  },
                  {
                    kData: FullIntegrationContactlessTransactionPath.JcbLegacy,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-contactlessTransactionPath_JcbLegacy',
                  },
                  {
                    kData: FullIntegrationContactlessTransactionPath.JcbWave2,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-contactlessTransactionPath_JcbWave2',
                  },
                  {
                    kData: FullIntegrationContactlessTransactionPath.QPbocQvsdc,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-contactlessTransactionPath_QPbocQvsdc',
                  },
                  {
                    kData: FullIntegrationContactlessTransactionPath.QPbocVsdc,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-contactlessTransactionPath_QPbocVsdc',
                  },
                  {
                    kData: FullIntegrationContactlessTransactionPath.FlashEmv,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-contactlessTransactionPath_FlashEmv',
                  },
                ],
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'authorizationResult',
                kID: 'FullIntegration_Response_InputAccountWithEmvResponse-authorizationResult',
                kMenuID: 'FullIntegration_Response_InputAccountWithEmvResponse-authorizationResult_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationFirstGacResult.NotSet,
                kData: [
                  {
                    kData: FullIntegrationFirstGacResult.NotSet,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-authorizationResult_NotSet',
                  },
                  {
                    kData: FullIntegrationFirstGacResult.TransactionOfflineApproved,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-authorizationResult_TransactionOfflineApproved',
                  },
                  {
                    kData: FullIntegrationFirstGacResult.TransactionOfflineDeclined,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-authorizationResult_TransactionOfflineDeclined',
                  },
                  {
                    kData: FullIntegrationFirstGacResult.TransactionOnlineAuthorizationNeeded,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-authorizationResult_TransactionOnlineAuthorizationNeeded',
                  },
                ],
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'signatureFlag',
                kID: 'FullIntegration_Response_InputAccountWithEmvResponse-signatureFlag',
                kMenuID: 'FullIntegration_Response_InputAccountWithEmvResponse-signatureFlag_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationSignatureFlag.NotSet,
                kData: [
                  {
                    kData: FullIntegrationSignatureFlag.NotSet,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-signatureFlag_NotSet',
                  },
                  {
                    kData: FullIntegrationSignatureFlag.NotNeeded,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-signatureFlag_NotNeeded',
                  },
                  {
                    kData: FullIntegrationSignatureFlag.Needed,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-signatureFlag_Needed',
                  },
                ],
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'onlinePinFlag',
                kID: 'FullIntegration_Response_InputAccountWithEmvResponse-onlinePinFlag',
                kMenuID: 'FullIntegration_Response_InputAccountWithEmvResponse-onlinePinFlag_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationOnlinePinFlag.NotSet,
                kData: [
                  {
                    kData: FullIntegrationOnlinePinFlag.NotSet,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-onlinePinFlag_NotSet',
                  },
                  {
                    kData: FullIntegrationOnlinePinFlag.NotNeeded,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-onlinePinFlag_NotNeeded',
                  },
                  {
                    kData: FullIntegrationOnlinePinFlag.Needed,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-onlinePinFlag_Needed',
                  },
                ],
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'emvTlvData',
                kValue: ' ',
                kID: 'FullIntegration_Response_InputAccountWithEmvResponse-emvTlvData',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'encryptedEmvTlvData',
                kValue: ' ',
                kID: 'FullIntegration_Response_InputAccountWithEmvResponse-encryptedEmvTlvData',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'encryptedSensitiveTlvData',
                kValue: ' ',
                kID: 'FullIntegration_Response_InputAccountWithEmvResponse-encryptedSensitiveTlvData',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kGroupArrowOpen: true,
                kName: 'additionalAccountInformation',
                kValue: '',
                kID: 'FullIntegration_Response_InputAccountWithEmvResponse-additionalAccountInformation',
                kType: DataItemType.Group,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 2,
                kName: 'expiryDate',
                kValue: ' ',
                kID: 'FullIntegration_Response_InputAccountWithEmvResponse-additionalAccountInformation_expiryDate',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 2,
                kName: 'cardHolderName',
                kValue: ' ',
                kID: 'FullIntegration_Response_InputAccountWithEmvResponse-additionalAccountInformation_cardHolderName',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 2,
                kName: 'serviceCode',
                kValue: ' ',
                kID: 'FullIntegration_Response_InputAccountWithEmvResponse-additionalAccountInformation_serviceCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 2,
                kName: 'cvvCode',
                kValue: ' ',
                kID: 'FullIntegration_Response_InputAccountWithEmvResponse-additionalAccountInformation_cvvCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 2,
                kName: 'zipCode',
                kValue: ' ',
                kID: 'FullIntegration_Response_InputAccountWithEmvResponse-additionalAccountInformation_zipCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'cvm',
                kID: 'FullIntegration_Response_InputAccountWithEmvResponse-cvm',
                kMenuID: 'FullIntegration_Response_InputAccountWithEmvResponse-cvm_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationCardholderVerificationMethod.NotSet,
                kData: [
                  {
                    kData: FullIntegrationCardholderVerificationMethod.NotSet,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-cvm_NotSet',
                  },
                  {
                    kData: FullIntegrationCardholderVerificationMethod.FailCvmProcessing,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-cvm_FailCvmProcessing',
                  },
                  {
                    kData: FullIntegrationCardholderVerificationMethod.PlaintextOfflinePinVerification,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-cvm_PlaintextOfflinePinVerification',
                  },
                  {
                    kData: FullIntegrationCardholderVerificationMethod.OnlinePin,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-cvm_OnlinePin',
                  },
                  {
                    kData: FullIntegrationCardholderVerificationMethod.PlaintextOfflinePinAndSignature,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-cvm_PlaintextOfflinePinAndSignature',
                  },
                  {
                    kData: FullIntegrationCardholderVerificationMethod.EncipheredOfflinePinVerification,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-cvm_EncipheredOfflinePinVerification',
                  },
                  {
                    kData: FullIntegrationCardholderVerificationMethod.EncipheredOfflinePinVerificationAndSignature,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-cvm_EncipheredOfflinePinVerificationAndSignature',
                  },
                  {
                    kData: FullIntegrationCardholderVerificationMethod.Signature,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-cvm_Signature',
                  },
                  {
                    kData: FullIntegrationCardholderVerificationMethod.NoCvmRequired,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-cvm_NoCvmRequired',
                  },
                  {
                    kData: FullIntegrationCardholderVerificationMethod.OnDeviceCvm,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-cvm_OnDeviceCvm',
                  },
                ],
              },
              {
                kEnable: false,
                kLevel: 1,
                kGroupArrowOpen: true,
                kName: 'vasInformation',
                kValue: '',
                kID: 'FullIntegration_Response_InputAccountWithEmvResponse-vasInformation',
                kType: DataItemType.Group,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 2,
                kName: 'vasCode',
                kID: 'FullIntegration_Response_InputAccountWithEmvResponse-vasInformation_vasCode',
                kMenuID: 'FullIntegration_Response_InputAccountWithEmvResponse-vasInformation_vasCode_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationVasResponseCode.NotSet,
                kData: [
                  {
                    kData: FullIntegrationVasResponseCode.NotSet,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-vasInformation_vasCode_NotSet',
                  },
                  {
                    kData: FullIntegrationVasResponseCode.VasOk,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-vasInformation_vasCode_VasOk',
                  },
                  {
                    kData: FullIntegrationVasResponseCode.VasOseError,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-vasInformation_vasCode_VasOseError',
                  },
                  {
                    kData: FullIntegrationVasResponseCode.VasGetDataCommandError,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-vasInformation_vasCode_VasGetDataCommandError',
                  },
                  {
                    kData: FullIntegrationVasResponseCode.VasIssueNeedToStartPayment,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-vasInformation_vasCode_VasIssueNeedToStartPayment',
                  },
                  {
                    kData: FullIntegrationVasResponseCode.AppVersionTooLow,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-vasInformation_vasCode_AppVersionTooLow',
                  },
                  {
                    kData: FullIntegrationVasResponseCode.SkipProtocolInVasMode,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-vasInformation_vasCode_SkipProtocolInVasMode',
                  },
                  {
                    kData: FullIntegrationVasResponseCode.SkipProtocolAndNoDataForthcomingInDualMode,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-vasInformation_vasCode_SkipProtocolAndNoDataForthcomingInDualMode',
                  },
                  {
                    kData: FullIntegrationVasResponseCode.SkipProtocolAndNoDataForthcomingInSingleMode,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-vasInformation_vasCode_SkipProtocolAndNoDataForthcomingInSingleMode',
                  },
                  {
                    kData: FullIntegrationVasResponseCode.VasDataNotFound,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-vasInformation_vasCode_VasDataNotFound',
                  },
                  {
                    kData: FullIntegrationVasResponseCode.VasDataNotActive,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-vasInformation_vasCode_VasDataNotActive',
                  },
                  {
                    kData: FullIntegrationVasResponseCode.UserInterventionRequiredOnMobileDevice,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-vasInformation_vasCode_UserInterventionRequiredOnMobileDevice',
                  },
                  {
                    kData: FullIntegrationVasResponseCode.TheMerchantIdIsNull,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-vasInformation_vasCode_TheMerchantIdIsNull',
                  },
                  {
                    kData: FullIntegrationVasResponseCode.VasGetKeyError,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-vasInformation_vasCode_VasGetKeyError',
                  },
                  {
                    kData: FullIntegrationVasResponseCode.VasDataDecryptionError,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-vasInformation_vasCode_VasDataDecryptionError',
                  },
                  {
                    kData: FullIntegrationVasResponseCode.UnknownError,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-vasInformation_vasCode_UnknownError',
                  },
                ],
              },
              {
                kEnable: false,
                kLevel: 2,
                kName: 'vasData',
                kValue: ' ',
                kID: 'FullIntegration_Response_InputAccountWithEmvResponse-vasInformation_vasData',
                kType: DataItemType.StringList,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 2,
                kName: 'ndefData',
                kValue: ' ',
                kID: 'FullIntegration_Response_InputAccountWithEmvResponse-vasInformation_ndefData',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'pinpadType',
                kID: 'FullIntegration_Response_InputAccountWithEmvResponse-pinpadType',
                kMenuID: 'FullIntegration_Response_InputAccountWithEmvResponse-pinpadType_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationPinpadType.NotSet,
                kData: [
                  {
                    kData: FullIntegrationPinpadType.NotSet,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-pinpadType_NotSet',
                  },
                  {
                    kData: FullIntegrationPinpadType.InternalPinpad,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-pinpadType_InternalPinpad',
                  },
                  {
                    kData: FullIntegrationPinpadType.ExternalPinpad,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-pinpadType_ExternalPinpad',
                  },
                  {
                    kData: FullIntegrationPinpadType.RnibPinpad,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-pinpadType_RnibPinpad',
                  },
                  {
                    kData: FullIntegrationPinpadType.ExternalPinpadFirst,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-pinpadType_ExternalPinpadFirst',
                  },
                ],
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'luhnValidationResult',
                kID: 'FullIntegration_Response_InputAccountWithEmvResponse-luhnValidationResult',
                kMenuID: 'FullIntegration_Response_InputAccountWithEmvResponse-luhnValidationResult_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationLuhnValidationResult.NotSet,
                kData: [
                  {
                    kData: FullIntegrationLuhnValidationResult.NotSet,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-luhnValidationResult_NotSet',
                  },
                  {
                    kData: FullIntegrationLuhnValidationResult.NotPerformed,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-luhnValidationResult_NotPerformed',
                  },
                  {
                    kData: FullIntegrationLuhnValidationResult.Passed,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-luhnValidationResult_Passed',
                  },
                  {
                    kData: FullIntegrationLuhnValidationResult.Failed,
                    kID: 'FullIntegration_Response_InputAccountWithEmvResponse-luhnValidationResult_Failed',
                  },
                ],
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'customEncryptedData',
                kValue: ' ',
                kID: 'FullIntegration_Response_InputAccountWithEmvResponse-customEncryptedData',
                kType: DataItemType.StringList,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kGroupArrowOpen: true,
                kName: 'customMacData',
                kValue: '',
                kID: 'FullIntegration_Response_InputAccountWithEmvResponse-customMacData',
                kType: DataItemType.Group,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 2,
                kName: 'data',
                kValue: ' ',
                kID: 'FullIntegration_Response_InputAccountWithEmvResponse-customMacData_data',
                kType: DataItemType.StringList,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 2,
                kName: 'ksn',
                kValue: ' ',
                kID: 'FullIntegration_Response_InputAccountWithEmvResponse-customMacData_ksn',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

   static void parseRspFullIntegrationInputAccountWithEmvResponse(FullIntegrationInputAccountWithEmvResponse rsp, List<Map> rspDataSource) {
      rspDataSource.forEach((element) {
          DataItemType itemType = element[kType];
          String id = element[kID];
          switch (itemType) {
              case DataItemType.CellInput:
                element[kValue] = FullIntegrationRspData._parseFullIntegrationInputAccountWithEmvResponse(id, rsp);
                break;
              case DataItemType.Group:
                if (element[kBitmapEnable] != null) {
                    element[kBitmapEnable] = true;
                    element[kGroupArrowOpen] = true;
                }
                break;
              case DataItemType.ModelList:
                List<dynamic> map = FullIntegrationRspData._parseFullIntegrationInputAccountWithEmvResponse(id, rsp) ?? [];
                element[kData] = ResponseListModelQuery.query(id, map);
                break;
              case DataItemType.Menu:
                element[kValue] = FullIntegrationRspData._parseFullIntegrationInputAccountWithEmvResponse(id, rsp);
                break;
              case DataItemType.StringList:
                List<String> tempData = [];
                List<String?> resData = FullIntegrationRspData._parseFullIntegrationInputAccountWithEmvResponse(id, rsp) ?? [];
                for (int i = 0; i < resData.length; i++) {
                  String str = resData[i]!;
                  tempData.add(str);
                }
                element[kData] = tempData;
                break;
            case DataItemType.Boolen:
                element[kValue] = FullIntegrationRspData._parseFullIntegrationInputAccountWithEmvResponse(id, rsp);
                element[kShow] = true;
                break;
              default:
                break;
           }
        });
  }


   static dynamic _parseFullIntegrationInputAccountWithEmvResponse(String id, FullIntegrationInputAccountWithEmvResponse rsp) {
      dynamic result;
      switch (id) {
         case 'FullIntegration_Response_InputAccountWithEmvResponse-responseCode':
             result = rsp.responseCode;
             break;
         case 'FullIntegration_Response_InputAccountWithEmvResponse-responseMessage':
             result = rsp.responseMessage;
             break;
         case 'FullIntegration_Response_InputAccountWithEmvResponse-entryMode':
             result = rsp.entryMode;
             break;
         case 'FullIntegration_Response_InputAccountWithEmvResponse-track1Data':
             result = rsp.track1Data;
             break;
         case 'FullIntegration_Response_InputAccountWithEmvResponse-track2Data':
             result = rsp.track2Data;
             break;
         case 'FullIntegration_Response_InputAccountWithEmvResponse-track3Data':
             result = rsp.track3Data;
             break;
         case 'FullIntegration_Response_InputAccountWithEmvResponse-pan':
             result = rsp.pan;
             break;
         case 'FullIntegration_Response_InputAccountWithEmvResponse-maskedPan':
             result = rsp.maskedPan;
             break;
         case 'FullIntegration_Response_InputAccountWithEmvResponse-barcodeType':
             result = rsp.barcodeType;
             break;
         case 'FullIntegration_Response_InputAccountWithEmvResponse-barcodeData':
             result = rsp.barcodeData;
             break;
         case 'FullIntegration_Response_InputAccountWithEmvResponse-ksn':
             result = rsp.ksn;
             break;
         case 'FullIntegration_Response_InputAccountWithEmvResponse-etb':
             result = rsp.etb;
             break;
         case 'FullIntegration_Response_InputAccountWithEmvResponse-contactlessTransactionPath':
             result = rsp.contactlessTransactionPath;
             break;
         case 'FullIntegration_Response_InputAccountWithEmvResponse-authorizationResult':
             result = rsp.authorizationResult;
             break;
         case 'FullIntegration_Response_InputAccountWithEmvResponse-signatureFlag':
             result = rsp.signatureFlag;
             break;
         case 'FullIntegration_Response_InputAccountWithEmvResponse-onlinePinFlag':
             result = rsp.onlinePinFlag;
             break;
         case 'FullIntegration_Response_InputAccountWithEmvResponse-emvTlvData':
             result = rsp.emvTlvData;
             break;
         case 'FullIntegration_Response_InputAccountWithEmvResponse-encryptedEmvTlvData':
             result = rsp.encryptedEmvTlvData;
             break;
         case 'FullIntegration_Response_InputAccountWithEmvResponse-encryptedSensitiveTlvData':
             result = rsp.encryptedSensitiveTlvData;
             break;
         case 'FullIntegration_Response_InputAccountWithEmvResponse-additionalAccountInformation':
             result = rsp.additionalAccountInformation;
             break;
         case 'FullIntegration_Response_InputAccountWithEmvResponse-additionalAccountInformation_expiryDate':
             result = rsp.additionalAccountInformation?.expiryDate;
             break;
         case 'FullIntegration_Response_InputAccountWithEmvResponse-additionalAccountInformation_cardHolderName':
             result = rsp.additionalAccountInformation?.cardHolderName;
             break;
         case 'FullIntegration_Response_InputAccountWithEmvResponse-additionalAccountInformation_serviceCode':
             result = rsp.additionalAccountInformation?.serviceCode;
             break;
         case 'FullIntegration_Response_InputAccountWithEmvResponse-additionalAccountInformation_cvvCode':
             result = rsp.additionalAccountInformation?.cvvCode;
             break;
         case 'FullIntegration_Response_InputAccountWithEmvResponse-additionalAccountInformation_zipCode':
             result = rsp.additionalAccountInformation?.zipCode;
             break;
         case 'FullIntegration_Response_InputAccountWithEmvResponse-cvm':
             result = rsp.cvm;
             break;
         case 'FullIntegration_Response_InputAccountWithEmvResponse-vasInformation':
             result = rsp.vasInformation;
             break;
         case 'FullIntegration_Response_InputAccountWithEmvResponse-vasInformation_vasCode':
             result = rsp.vasInformation?.vasCode;
             break;
         case 'FullIntegration_Response_InputAccountWithEmvResponse-vasInformation_vasData':
             result = rsp.vasInformation?.vasData;
             break;
         case 'FullIntegration_Response_InputAccountWithEmvResponse-vasInformation_ndefData':
             result = rsp.vasInformation?.ndefData;
             break;
         case 'FullIntegration_Response_InputAccountWithEmvResponse-pinpadType':
             result = rsp.pinpadType;
             break;
         case 'FullIntegration_Response_InputAccountWithEmvResponse-luhnValidationResult':
             result = rsp.luhnValidationResult;
             break;
         case 'FullIntegration_Response_InputAccountWithEmvResponse-customEncryptedData':
             result = rsp.customEncryptedData;
             break;
         case 'FullIntegration_Response_InputAccountWithEmvResponse-customMacData':
             result = rsp.customMacData;
             break;
         case 'FullIntegration_Response_InputAccountWithEmvResponse-customMacData_data':
             result = rsp.customMacData?.data;
             break;
         case 'FullIntegration_Response_InputAccountWithEmvResponse-customMacData_ksn':
             result = rsp.customMacData?.ksn;
             break;
         default:
             break;
     }
     return result;
 }

  static List<Map> getPinBlockData() {
      return [
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseCode',
                kValue: ' ',
                kID: 'FullIntegration_Response_GetPinBlockResponse-responseCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseMessage',
                kValue: ' ',
                kID: 'FullIntegration_Response_GetPinBlockResponse-responseMessage',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'pinBlock',
                kValue: ' ',
                kID: 'FullIntegration_Response_GetPinBlockResponse-pinBlock',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'ksn',
                kValue: ' ',
                kID: 'FullIntegration_Response_GetPinBlockResponse-ksn',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'pinpadType',
                kID: 'FullIntegration_Response_GetPinBlockResponse-pinpadType',
                kMenuID: 'FullIntegration_Response_GetPinBlockResponse-pinpadType_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationPinpadType.NotSet,
                kData: [
                  {
                    kData: FullIntegrationPinpadType.NotSet,
                    kID: 'FullIntegration_Response_GetPinBlockResponse-pinpadType_NotSet',
                  },
                  {
                    kData: FullIntegrationPinpadType.InternalPinpad,
                    kID: 'FullIntegration_Response_GetPinBlockResponse-pinpadType_InternalPinpad',
                  },
                  {
                    kData: FullIntegrationPinpadType.ExternalPinpad,
                    kID: 'FullIntegration_Response_GetPinBlockResponse-pinpadType_ExternalPinpad',
                  },
                  {
                    kData: FullIntegrationPinpadType.RnibPinpad,
                    kID: 'FullIntegration_Response_GetPinBlockResponse-pinpadType_RnibPinpad',
                  },
                  {
                    kData: FullIntegrationPinpadType.ExternalPinpadFirst,
                    kID: 'FullIntegration_Response_GetPinBlockResponse-pinpadType_ExternalPinpadFirst',
                  },
                ],
              },
           ];
  }

   static void parseRspFullIntegrationGetPinBlockResponse(FullIntegrationGetPinBlockResponse rsp, List<Map> rspDataSource) {
      rspDataSource.forEach((element) {
          DataItemType itemType = element[kType];
          String id = element[kID];
          switch (itemType) {
              case DataItemType.CellInput:
                element[kValue] = FullIntegrationRspData._parseFullIntegrationGetPinBlockResponse(id, rsp);
                break;
              case DataItemType.Group:
                if (element[kBitmapEnable] != null) {
                    element[kBitmapEnable] = true;
                    element[kGroupArrowOpen] = true;
                }
                break;
              case DataItemType.ModelList:
                List<dynamic> map = FullIntegrationRspData._parseFullIntegrationGetPinBlockResponse(id, rsp) ?? [];
                element[kData] = ResponseListModelQuery.query(id, map);
                break;
              case DataItemType.Menu:
                element[kValue] = FullIntegrationRspData._parseFullIntegrationGetPinBlockResponse(id, rsp);
                break;
              case DataItemType.StringList:
                List<String> tempData = [];
                List<String?> resData = FullIntegrationRspData._parseFullIntegrationGetPinBlockResponse(id, rsp) ?? [];
                for (int i = 0; i < resData.length; i++) {
                  String str = resData[i]!;
                  tempData.add(str);
                }
                element[kData] = tempData;
                break;
            case DataItemType.Boolen:
                element[kValue] = FullIntegrationRspData._parseFullIntegrationGetPinBlockResponse(id, rsp);
                element[kShow] = true;
                break;
              default:
                break;
           }
        });
  }


   static dynamic _parseFullIntegrationGetPinBlockResponse(String id, FullIntegrationGetPinBlockResponse rsp) {
      dynamic result;
      switch (id) {
         case 'FullIntegration_Response_GetPinBlockResponse-responseCode':
             result = rsp.responseCode;
             break;
         case 'FullIntegration_Response_GetPinBlockResponse-responseMessage':
             result = rsp.responseMessage;
             break;
         case 'FullIntegration_Response_GetPinBlockResponse-pinBlock':
             result = rsp.pinBlock;
             break;
         case 'FullIntegration_Response_GetPinBlockResponse-ksn':
             result = rsp.ksn;
             break;
         case 'FullIntegration_Response_GetPinBlockResponse-pinpadType':
             result = rsp.pinpadType;
             break;
         default:
             break;
     }
     return result;
 }

  static List<Map> setEmvTlvDataData() {
      return [
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseCode',
                kValue: ' ',
                kID: 'FullIntegration_Response_SetEmvTlvDataResponse-responseCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseMessage',
                kValue: ' ',
                kID: 'FullIntegration_Response_SetEmvTlvDataResponse-responseMessage',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'tagList',
                kValue: ' ',
                kID: 'FullIntegration_Response_SetEmvTlvDataResponse-tagList',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

   static void parseRspFullIntegrationSetEmvTlvDataResponse(FullIntegrationSetEmvTlvDataResponse rsp, List<Map> rspDataSource) {
      rspDataSource.forEach((element) {
          DataItemType itemType = element[kType];
          String id = element[kID];
          switch (itemType) {
              case DataItemType.CellInput:
                element[kValue] = FullIntegrationRspData._parseFullIntegrationSetEmvTlvDataResponse(id, rsp);
                break;
              case DataItemType.Group:
                if (element[kBitmapEnable] != null) {
                    element[kBitmapEnable] = true;
                    element[kGroupArrowOpen] = true;
                }
                break;
              case DataItemType.ModelList:
                List<dynamic> map = FullIntegrationRspData._parseFullIntegrationSetEmvTlvDataResponse(id, rsp) ?? [];
                element[kData] = ResponseListModelQuery.query(id, map);
                break;
              case DataItemType.Menu:
                element[kValue] = FullIntegrationRspData._parseFullIntegrationSetEmvTlvDataResponse(id, rsp);
                break;
              case DataItemType.StringList:
                List<String> tempData = [];
                List<String?> resData = FullIntegrationRspData._parseFullIntegrationSetEmvTlvDataResponse(id, rsp) ?? [];
                for (int i = 0; i < resData.length; i++) {
                  String str = resData[i]!;
                  tempData.add(str);
                }
                element[kData] = tempData;
                break;
            case DataItemType.Boolen:
                element[kValue] = FullIntegrationRspData._parseFullIntegrationSetEmvTlvDataResponse(id, rsp);
                element[kShow] = true;
                break;
              default:
                break;
           }
        });
  }


   static dynamic _parseFullIntegrationSetEmvTlvDataResponse(String id, FullIntegrationSetEmvTlvDataResponse rsp) {
      dynamic result;
      switch (id) {
         case 'FullIntegration_Response_SetEmvTlvDataResponse-responseCode':
             result = rsp.responseCode;
             break;
         case 'FullIntegration_Response_SetEmvTlvDataResponse-responseMessage':
             result = rsp.responseMessage;
             break;
         case 'FullIntegration_Response_SetEmvTlvDataResponse-tagList':
             result = rsp.tagList;
             break;
         default:
             break;
     }
     return result;
 }

  static List<Map> completeOnlineEmvData() {
      return [
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseCode',
                kValue: ' ',
                kID: 'FullIntegration_Response_CompleteOnlineEmvResponse-responseCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseMessage',
                kValue: ' ',
                kID: 'FullIntegration_Response_CompleteOnlineEmvResponse-responseMessage',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'authorizationResult',
                kID: 'FullIntegration_Response_CompleteOnlineEmvResponse-authorizationResult',
                kMenuID: 'FullIntegration_Response_CompleteOnlineEmvResponse-authorizationResult_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationSecondGacResult.NotSet,
                kData: [
                  {
                    kData: FullIntegrationSecondGacResult.NotSet,
                    kID: 'FullIntegration_Response_CompleteOnlineEmvResponse-authorizationResult_NotSet',
                  },
                  {
                    kData: FullIntegrationSecondGacResult.TransactionApproved,
                    kID: 'FullIntegration_Response_CompleteOnlineEmvResponse-authorizationResult_TransactionApproved',
                  },
                  {
                    kData: FullIntegrationSecondGacResult.TransactionDeclined,
                    kID: 'FullIntegration_Response_CompleteOnlineEmvResponse-authorizationResult_TransactionDeclined',
                  },
                  {
                    kData: FullIntegrationSecondGacResult.PartialEmvApprove,
                    kID: 'FullIntegration_Response_CompleteOnlineEmvResponse-authorizationResult_PartialEmvApprove',
                  },
                  {
                    kData: FullIntegrationSecondGacResult.PartialEmvDecline,
                    kID: 'FullIntegration_Response_CompleteOnlineEmvResponse-authorizationResult_PartialEmvDecline',
                  },
                ],
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'emvTlvData',
                kValue: ' ',
                kID: 'FullIntegration_Response_CompleteOnlineEmvResponse-emvTlvData',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'issuerScriptResults',
                kValue: ' ',
                kID: 'FullIntegration_Response_CompleteOnlineEmvResponse-issuerScriptResults',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

   static void parseRspFullIntegrationCompleteOnlineEmvResponse(FullIntegrationCompleteOnlineEmvResponse rsp, List<Map> rspDataSource) {
      rspDataSource.forEach((element) {
          DataItemType itemType = element[kType];
          String id = element[kID];
          switch (itemType) {
              case DataItemType.CellInput:
                element[kValue] = FullIntegrationRspData._parseFullIntegrationCompleteOnlineEmvResponse(id, rsp);
                break;
              case DataItemType.Group:
                if (element[kBitmapEnable] != null) {
                    element[kBitmapEnable] = true;
                    element[kGroupArrowOpen] = true;
                }
                break;
              case DataItemType.ModelList:
                List<dynamic> map = FullIntegrationRspData._parseFullIntegrationCompleteOnlineEmvResponse(id, rsp) ?? [];
                element[kData] = ResponseListModelQuery.query(id, map);
                break;
              case DataItemType.Menu:
                element[kValue] = FullIntegrationRspData._parseFullIntegrationCompleteOnlineEmvResponse(id, rsp);
                break;
              case DataItemType.StringList:
                List<String> tempData = [];
                List<String?> resData = FullIntegrationRspData._parseFullIntegrationCompleteOnlineEmvResponse(id, rsp) ?? [];
                for (int i = 0; i < resData.length; i++) {
                  String str = resData[i]!;
                  tempData.add(str);
                }
                element[kData] = tempData;
                break;
            case DataItemType.Boolen:
                element[kValue] = FullIntegrationRspData._parseFullIntegrationCompleteOnlineEmvResponse(id, rsp);
                element[kShow] = true;
                break;
              default:
                break;
           }
        });
  }


   static dynamic _parseFullIntegrationCompleteOnlineEmvResponse(String id, FullIntegrationCompleteOnlineEmvResponse rsp) {
      dynamic result;
      switch (id) {
         case 'FullIntegration_Response_CompleteOnlineEmvResponse-responseCode':
             result = rsp.responseCode;
             break;
         case 'FullIntegration_Response_CompleteOnlineEmvResponse-responseMessage':
             result = rsp.responseMessage;
             break;
         case 'FullIntegration_Response_CompleteOnlineEmvResponse-authorizationResult':
             result = rsp.authorizationResult;
             break;
         case 'FullIntegration_Response_CompleteOnlineEmvResponse-emvTlvData':
             result = rsp.emvTlvData;
             break;
         case 'FullIntegration_Response_CompleteOnlineEmvResponse-issuerScriptResults':
             result = rsp.issuerScriptResults;
             break;
         default:
             break;
     }
     return result;
 }

  static List<Map> authorizeCardData() {
      return [
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseCode',
                kValue: ' ',
                kID: 'FullIntegration_Response_AuthorizeCardResponse-responseCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'responseMessage',
                kValue: ' ',
                kID: 'FullIntegration_Response_AuthorizeCardResponse-responseMessage',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'authorizationResult',
                kID: 'FullIntegration_Response_AuthorizeCardResponse-authorizationResult',
                kMenuID: 'FullIntegration_Response_AuthorizeCardResponse-authorizationResult_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationFirstGacResult.NotSet,
                kData: [
                  {
                    kData: FullIntegrationFirstGacResult.NotSet,
                    kID: 'FullIntegration_Response_AuthorizeCardResponse-authorizationResult_NotSet',
                  },
                  {
                    kData: FullIntegrationFirstGacResult.TransactionOfflineApproved,
                    kID: 'FullIntegration_Response_AuthorizeCardResponse-authorizationResult_TransactionOfflineApproved',
                  },
                  {
                    kData: FullIntegrationFirstGacResult.TransactionOfflineDeclined,
                    kID: 'FullIntegration_Response_AuthorizeCardResponse-authorizationResult_TransactionOfflineDeclined',
                  },
                  {
                    kData: FullIntegrationFirstGacResult.TransactionOnlineAuthorizationNeeded,
                    kID: 'FullIntegration_Response_AuthorizeCardResponse-authorizationResult_TransactionOnlineAuthorizationNeeded',
                  },
                ],
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'signatureFlag',
                kID: 'FullIntegration_Response_AuthorizeCardResponse-signatureFlag',
                kMenuID: 'FullIntegration_Response_AuthorizeCardResponse-signatureFlag_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationSignatureFlag.NotSet,
                kData: [
                  {
                    kData: FullIntegrationSignatureFlag.NotSet,
                    kID: 'FullIntegration_Response_AuthorizeCardResponse-signatureFlag_NotSet',
                  },
                  {
                    kData: FullIntegrationSignatureFlag.NotNeeded,
                    kID: 'FullIntegration_Response_AuthorizeCardResponse-signatureFlag_NotNeeded',
                  },
                  {
                    kData: FullIntegrationSignatureFlag.Needed,
                    kID: 'FullIntegration_Response_AuthorizeCardResponse-signatureFlag_Needed',
                  },
                ],
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'pinBypassStatus',
                kID: 'FullIntegration_Response_AuthorizeCardResponse-pinBypassStatus',
                kMenuID: 'FullIntegration_Response_AuthorizeCardResponse-pinBypassStatus_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationPinBypassStatus.NotSet,
                kData: [
                  {
                    kData: FullIntegrationPinBypassStatus.NotSet,
                    kID: 'FullIntegration_Response_AuthorizeCardResponse-pinBypassStatus_NotSet',
                  },
                  {
                    kData: FullIntegrationPinBypassStatus.NotBypassed,
                    kID: 'FullIntegration_Response_AuthorizeCardResponse-pinBypassStatus_NotBypassed',
                  },
                  {
                    kData: FullIntegrationPinBypassStatus.Bypassed,
                    kID: 'FullIntegration_Response_AuthorizeCardResponse-pinBypassStatus_Bypassed',
                  },
                ],
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'pinBlock',
                kValue: ' ',
                kID: 'FullIntegration_Response_AuthorizeCardResponse-pinBlock',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'ksn',
                kValue: ' ',
                kID: 'FullIntegration_Response_AuthorizeCardResponse-ksn',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'emvTlvData',
                kValue: ' ',
                kID: 'FullIntegration_Response_AuthorizeCardResponse-emvTlvData',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'cvm',
                kID: 'FullIntegration_Response_AuthorizeCardResponse-cvm',
                kMenuID: 'FullIntegration_Response_AuthorizeCardResponse-cvm_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationCardholderVerificationMethod.NotSet,
                kData: [
                  {
                    kData: FullIntegrationCardholderVerificationMethod.NotSet,
                    kID: 'FullIntegration_Response_AuthorizeCardResponse-cvm_NotSet',
                  },
                  {
                    kData: FullIntegrationCardholderVerificationMethod.FailCvmProcessing,
                    kID: 'FullIntegration_Response_AuthorizeCardResponse-cvm_FailCvmProcessing',
                  },
                  {
                    kData: FullIntegrationCardholderVerificationMethod.PlaintextOfflinePinVerification,
                    kID: 'FullIntegration_Response_AuthorizeCardResponse-cvm_PlaintextOfflinePinVerification',
                  },
                  {
                    kData: FullIntegrationCardholderVerificationMethod.OnlinePin,
                    kID: 'FullIntegration_Response_AuthorizeCardResponse-cvm_OnlinePin',
                  },
                  {
                    kData: FullIntegrationCardholderVerificationMethod.PlaintextOfflinePinAndSignature,
                    kID: 'FullIntegration_Response_AuthorizeCardResponse-cvm_PlaintextOfflinePinAndSignature',
                  },
                  {
                    kData: FullIntegrationCardholderVerificationMethod.EncipheredOfflinePinVerification,
                    kID: 'FullIntegration_Response_AuthorizeCardResponse-cvm_EncipheredOfflinePinVerification',
                  },
                  {
                    kData: FullIntegrationCardholderVerificationMethod.EncipheredOfflinePinVerificationAndSignature,
                    kID: 'FullIntegration_Response_AuthorizeCardResponse-cvm_EncipheredOfflinePinVerificationAndSignature',
                  },
                  {
                    kData: FullIntegrationCardholderVerificationMethod.Signature,
                    kID: 'FullIntegration_Response_AuthorizeCardResponse-cvm_Signature',
                  },
                  {
                    kData: FullIntegrationCardholderVerificationMethod.NoCvmRequired,
                    kID: 'FullIntegration_Response_AuthorizeCardResponse-cvm_NoCvmRequired',
                  },
                  {
                    kData: FullIntegrationCardholderVerificationMethod.OnDeviceCvm,
                    kID: 'FullIntegration_Response_AuthorizeCardResponse-cvm_OnDeviceCvm',
                  },
                ],
              },
              {
                kEnable: false,
                kLevel: 1,
                kName: 'pinpadType',
                kID: 'FullIntegration_Response_AuthorizeCardResponse-pinpadType',
                kMenuID: 'FullIntegration_Response_AuthorizeCardResponse-pinpadType_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationPinpadType.NotSet,
                kData: [
                  {
                    kData: FullIntegrationPinpadType.NotSet,
                    kID: 'FullIntegration_Response_AuthorizeCardResponse-pinpadType_NotSet',
                  },
                  {
                    kData: FullIntegrationPinpadType.InternalPinpad,
                    kID: 'FullIntegration_Response_AuthorizeCardResponse-pinpadType_InternalPinpad',
                  },
                  {
                    kData: FullIntegrationPinpadType.ExternalPinpad,
                    kID: 'FullIntegration_Response_AuthorizeCardResponse-pinpadType_ExternalPinpad',
                  },
                  {
                    kData: FullIntegrationPinpadType.RnibPinpad,
                    kID: 'FullIntegration_Response_AuthorizeCardResponse-pinpadType_RnibPinpad',
                  },
                  {
                    kData: FullIntegrationPinpadType.ExternalPinpadFirst,
                    kID: 'FullIntegration_Response_AuthorizeCardResponse-pinpadType_ExternalPinpadFirst',
                  },
                ],
              },
           ];
  }

   static void parseRspFullIntegrationAuthorizeCardResponse(FullIntegrationAuthorizeCardResponse rsp, List<Map> rspDataSource) {
      rspDataSource.forEach((element) {
          DataItemType itemType = element[kType];
          String id = element[kID];
          switch (itemType) {
              case DataItemType.CellInput:
                element[kValue] = FullIntegrationRspData._parseFullIntegrationAuthorizeCardResponse(id, rsp);
                break;
              case DataItemType.Group:
                if (element[kBitmapEnable] != null) {
                    element[kBitmapEnable] = true;
                    element[kGroupArrowOpen] = true;
                }
                break;
              case DataItemType.ModelList:
                List<dynamic> map = FullIntegrationRspData._parseFullIntegrationAuthorizeCardResponse(id, rsp) ?? [];
                element[kData] = ResponseListModelQuery.query(id, map);
                break;
              case DataItemType.Menu:
                element[kValue] = FullIntegrationRspData._parseFullIntegrationAuthorizeCardResponse(id, rsp);
                break;
              case DataItemType.StringList:
                List<String> tempData = [];
                List<String?> resData = FullIntegrationRspData._parseFullIntegrationAuthorizeCardResponse(id, rsp) ?? [];
                for (int i = 0; i < resData.length; i++) {
                  String str = resData[i]!;
                  tempData.add(str);
                }
                element[kData] = tempData;
                break;
            case DataItemType.Boolen:
                element[kValue] = FullIntegrationRspData._parseFullIntegrationAuthorizeCardResponse(id, rsp);
                element[kShow] = true;
                break;
              default:
                break;
           }
        });
  }


   static dynamic _parseFullIntegrationAuthorizeCardResponse(String id, FullIntegrationAuthorizeCardResponse rsp) {
      dynamic result;
      switch (id) {
         case 'FullIntegration_Response_AuthorizeCardResponse-responseCode':
             result = rsp.responseCode;
             break;
         case 'FullIntegration_Response_AuthorizeCardResponse-responseMessage':
             result = rsp.responseMessage;
             break;
         case 'FullIntegration_Response_AuthorizeCardResponse-authorizationResult':
             result = rsp.authorizationResult;
             break;
         case 'FullIntegration_Response_AuthorizeCardResponse-signatureFlag':
             result = rsp.signatureFlag;
             break;
         case 'FullIntegration_Response_AuthorizeCardResponse-pinBypassStatus':
             result = rsp.pinBypassStatus;
             break;
         case 'FullIntegration_Response_AuthorizeCardResponse-pinBlock':
             result = rsp.pinBlock;
             break;
         case 'FullIntegration_Response_AuthorizeCardResponse-ksn':
             result = rsp.ksn;
             break;
         case 'FullIntegration_Response_AuthorizeCardResponse-emvTlvData':
             result = rsp.emvTlvData;
             break;
         case 'FullIntegration_Response_AuthorizeCardResponse-cvm':
             result = rsp.cvm;
             break;
         case 'FullIntegration_Response_AuthorizeCardResponse-pinpadType':
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
      case 'GetEmvTlvDataRequest':
        list = FullIntegrationRspData.getEmvTlvDataData();
        break;
      case 'InputAccountWithEmvRequest':
        list = FullIntegrationRspData.inputAccountWithEmvData();
        break;
      case 'CompleteOnlineEmvRequest':
        list = FullIntegrationRspData.completeOnlineEmvData();
        break;
      case 'AuthorizeCardRequest':
        list = FullIntegrationRspData.authorizeCardData();
        break;
      case 'GetPinBlockRequest':
        list = FullIntegrationRspData.getPinBlockData();
        break;
      case 'SetEmvTlvDataRequest':
        list = FullIntegrationRspData.setEmvTlvDataData();
        break;
      default:
        list = [];
        break;
    }
    return list;
  }

}

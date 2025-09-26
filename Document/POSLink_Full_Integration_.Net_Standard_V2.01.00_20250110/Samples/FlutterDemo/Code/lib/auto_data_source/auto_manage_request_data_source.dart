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
class ManageReqData {
  static List<Map> initSourceData() {
    return ManageReqData.deleteImageData();
  }
  static List<Map> deleteImageData() {
      return [
              {
                kEnable: true,
                kLevel: 1,
                kName: 'ManageCommand',
                kID: 'ManageCommand',
                kMenuID: 'ManageCommand_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: ManageCommand.DeleteImageRequest,
                kData: [
                  {
                    kData: ManageCommand.DeleteImageRequest,
                    kID: 'ManageCommand_DeleteImageRequest',
                  },
                  {
                    kData: ManageCommand.DoSignatureRequest,
                    kID: 'ManageCommand_DoSignatureRequest',
                  },
                  {
                    kData: ManageCommand.VasPushDataRequest,
                    kID: 'ManageCommand_VasPushDataRequest',
                  },
                  {
                    kData: ManageCommand.InitRequest,
                    kID: 'ManageCommand_InitRequest',
                  },
                  {
                    kData: ManageCommand.SetGoogleSmartTapParametersRequest,
                    kID: 'ManageCommand_SetGoogleSmartTapParametersRequest',
                  },
                  {
                    kData: ManageCommand.CheckFileRequest,
                    kID: 'ManageCommand_CheckFileRequest',
                  },
                  {
                    kData: ManageCommand.ClearCardBufferRequest,
                    kID: 'ManageCommand_ClearCardBufferRequest',
                  },
                  {
                    kData: ManageCommand.SetApplePayVasParametersRequest,
                    kID: 'ManageCommand_SetApplePayVasParametersRequest',
                  },
                  {
                    kData: ManageCommand.GetSignatureRequest,
                    kID: 'ManageCommand_GetSignatureRequest',
                  },
                  {
                    kData: ManageCommand.ResetScreenRequest,
                    kID: 'ManageCommand_ResetScreenRequest',
                  },
                  {
                    kData: ManageCommand.GetVariableRequest,
                    kID: 'ManageCommand_GetVariableRequest',
                  },
                  {
                    kData: ManageCommand.UpdateResourceFileRequest,
                    kID: 'ManageCommand_UpdateResourceFileRequest',
                  },
                  {
                    kData: ManageCommand.RebootRequest,
                    kID: 'ManageCommand_RebootRequest',
                  },
                  {
                    kData: ManageCommand.SetVariableRequest,
                    kID: 'ManageCommand_SetVariableRequest',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'imageName',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Manage_Request_DeleteImageRequest-imageName',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

  static ManageDeleteImageRequest formDeleteImageRequest(List<Map> list) {
    List<Map> queryList = [];
    queryList.addAll(list);
    ManageDeleteImageRequest req = ManageDeleteImageRequest();
    req.imageName = RequestListModelQuery.query('Manage_Request_DeleteImageRequest-imageName',queryList);
    return req;
  }

  static List<Map> doSignatureData() {
      return [
              {
                kEnable: true,
                kLevel: 1,
                kName: 'ManageCommand',
                kID: 'ManageCommand',
                kMenuID: 'ManageCommand_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: ManageCommand.DeleteImageRequest,
                kData: [
                  {
                    kData: ManageCommand.DeleteImageRequest,
                    kID: 'ManageCommand_DeleteImageRequest',
                  },
                  {
                    kData: ManageCommand.DoSignatureRequest,
                    kID: 'ManageCommand_DoSignatureRequest',
                  },
                  {
                    kData: ManageCommand.VasPushDataRequest,
                    kID: 'ManageCommand_VasPushDataRequest',
                  },
                  {
                    kData: ManageCommand.InitRequest,
                    kID: 'ManageCommand_InitRequest',
                  },
                  {
                    kData: ManageCommand.SetGoogleSmartTapParametersRequest,
                    kID: 'ManageCommand_SetGoogleSmartTapParametersRequest',
                  },
                  {
                    kData: ManageCommand.CheckFileRequest,
                    kID: 'ManageCommand_CheckFileRequest',
                  },
                  {
                    kData: ManageCommand.ClearCardBufferRequest,
                    kID: 'ManageCommand_ClearCardBufferRequest',
                  },
                  {
                    kData: ManageCommand.SetApplePayVasParametersRequest,
                    kID: 'ManageCommand_SetApplePayVasParametersRequest',
                  },
                  {
                    kData: ManageCommand.GetSignatureRequest,
                    kID: 'ManageCommand_GetSignatureRequest',
                  },
                  {
                    kData: ManageCommand.ResetScreenRequest,
                    kID: 'ManageCommand_ResetScreenRequest',
                  },
                  {
                    kData: ManageCommand.GetVariableRequest,
                    kID: 'ManageCommand_GetVariableRequest',
                  },
                  {
                    kData: ManageCommand.UpdateResourceFileRequest,
                    kID: 'ManageCommand_UpdateResourceFileRequest',
                  },
                  {
                    kData: ManageCommand.RebootRequest,
                    kID: 'ManageCommand_RebootRequest',
                  },
                  {
                    kData: ManageCommand.SetVariableRequest,
                    kID: 'ManageCommand_SetVariableRequest',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'uploadFlag',
                kID: 'Manage_Request_DoSignatureRequest-uploadFlag',
                kMenuID: 'Manage_Request_DoSignatureRequest-uploadFlag_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: ManageUploadFlag.NotUploadToHost,
                kData: [
                  {
                    kData: ManageUploadFlag.NotUploadToHost,
                    kID: 'Manage_Request_DoSignatureRequest-uploadFlag_NotUploadToHost',
                  },
                  {
                    kData: ManageUploadFlag.UploadToHost,
                    kID: 'Manage_Request_DoSignatureRequest-uploadFlag_UploadToHost',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'hostReferenceNumber',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Manage_Request_DoSignatureRequest-hostReferenceNumber',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'edcType',
                kID: 'Manage_Request_DoSignatureRequest-edcType',
                kMenuID: 'Manage_Request_DoSignatureRequest-edcType_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: ManageEdcType.NotSet,
                kData: [
                  {
                    kData: ManageEdcType.NotSet,
                    kID: 'Manage_Request_DoSignatureRequest-edcType_NotSet',
                  },
                  {
                    kData: ManageEdcType.All,
                    kID: 'Manage_Request_DoSignatureRequest-edcType_All',
                  },
                  {
                    kData: ManageEdcType.Credit,
                    kID: 'Manage_Request_DoSignatureRequest-edcType_Credit',
                  },
                  {
                    kData: ManageEdcType.Debit,
                    kID: 'Manage_Request_DoSignatureRequest-edcType_Debit',
                  },
                  {
                    kData: ManageEdcType.Ebt,
                    kID: 'Manage_Request_DoSignatureRequest-edcType_Ebt',
                  },
                  {
                    kData: ManageEdcType.Gift,
                    kID: 'Manage_Request_DoSignatureRequest-edcType_Gift',
                  },
                  {
                    kData: ManageEdcType.Loyalty,
                    kID: 'Manage_Request_DoSignatureRequest-edcType_Loyalty',
                  },
                  {
                    kData: ManageEdcType.Cash,
                    kID: 'Manage_Request_DoSignatureRequest-edcType_Cash',
                  },
                  {
                    kData: ManageEdcType.QrPayment,
                    kID: 'Manage_Request_DoSignatureRequest-edcType_QrPayment',
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
                kID: 'Manage_Request_DoSignatureRequest-timeout',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'continuousScreen',
                kID: 'Manage_Request_DoSignatureRequest-continuousScreen',
                kMenuID: 'Manage_Request_DoSignatureRequest-continuousScreen_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: ManageContinuousScreen.NotSet,
                kData: [
                  {
                    kData: ManageContinuousScreen.NotSet,
                    kID: 'Manage_Request_DoSignatureRequest-continuousScreen_NotSet',
                  },
                  {
                    kData: ManageContinuousScreen.Default,
                    kID: 'Manage_Request_DoSignatureRequest-continuousScreen_Default',
                  },
                  {
                    kData: ManageContinuousScreen.NotGoToIdleScreen,
                    kID: 'Manage_Request_DoSignatureRequest-continuousScreen_NotGoToIdleScreen',
                  },
                ],
              },
           ];
  }

  static ManageDoSignatureRequest formDoSignatureRequest(List<Map> list) {
    List<Map> queryList = [];
    queryList.addAll(list);
    ManageDoSignatureRequest req = ManageDoSignatureRequest();
    req.uploadFlag = RequestListModelQuery.query('Manage_Request_DoSignatureRequest-uploadFlag',queryList);
    req.hostReferenceNumber = RequestListModelQuery.query('Manage_Request_DoSignatureRequest-hostReferenceNumber',queryList);
    req.edcType = RequestListModelQuery.query('Manage_Request_DoSignatureRequest-edcType',queryList);
    req.timeout = RequestListModelQuery.query('Manage_Request_DoSignatureRequest-timeout',queryList);
    req.continuousScreen = RequestListModelQuery.query('Manage_Request_DoSignatureRequest-continuousScreen',queryList);
    return req;
  }

  static List<Map> vasPushDataData() {
      return [
              {
                kEnable: true,
                kLevel: 1,
                kName: 'ManageCommand',
                kID: 'ManageCommand',
                kMenuID: 'ManageCommand_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: ManageCommand.DeleteImageRequest,
                kData: [
                  {
                    kData: ManageCommand.DeleteImageRequest,
                    kID: 'ManageCommand_DeleteImageRequest',
                  },
                  {
                    kData: ManageCommand.DoSignatureRequest,
                    kID: 'ManageCommand_DoSignatureRequest',
                  },
                  {
                    kData: ManageCommand.VasPushDataRequest,
                    kID: 'ManageCommand_VasPushDataRequest',
                  },
                  {
                    kData: ManageCommand.InitRequest,
                    kID: 'ManageCommand_InitRequest',
                  },
                  {
                    kData: ManageCommand.SetGoogleSmartTapParametersRequest,
                    kID: 'ManageCommand_SetGoogleSmartTapParametersRequest',
                  },
                  {
                    kData: ManageCommand.CheckFileRequest,
                    kID: 'ManageCommand_CheckFileRequest',
                  },
                  {
                    kData: ManageCommand.ClearCardBufferRequest,
                    kID: 'ManageCommand_ClearCardBufferRequest',
                  },
                  {
                    kData: ManageCommand.SetApplePayVasParametersRequest,
                    kID: 'ManageCommand_SetApplePayVasParametersRequest',
                  },
                  {
                    kData: ManageCommand.GetSignatureRequest,
                    kID: 'ManageCommand_GetSignatureRequest',
                  },
                  {
                    kData: ManageCommand.ResetScreenRequest,
                    kID: 'ManageCommand_ResetScreenRequest',
                  },
                  {
                    kData: ManageCommand.GetVariableRequest,
                    kID: 'ManageCommand_GetVariableRequest',
                  },
                  {
                    kData: ManageCommand.UpdateResourceFileRequest,
                    kID: 'ManageCommand_UpdateResourceFileRequest',
                  },
                  {
                    kData: ManageCommand.RebootRequest,
                    kID: 'ManageCommand_RebootRequest',
                  },
                  {
                    kData: ManageCommand.SetVariableRequest,
                    kID: 'ManageCommand_SetVariableRequest',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'vasMode',
                kID: 'Manage_Request_VasPushDataRequest-vasMode',
                kMenuID: 'Manage_Request_VasPushDataRequest-vasMode_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: ManageVasMode.VasOnly,
                kData: [
                  {
                    kData: ManageVasMode.NotSet,
                    kID: 'Manage_Request_VasPushDataRequest-vasMode_NotSet',
                  },
                  {
                    kData: ManageVasMode.VasOnly,
                    kID: 'Manage_Request_VasPushDataRequest-vasMode_VasOnly',
                  },
                  {
                    kData: ManageVasMode.VasAndPayment,
                    kID: 'Manage_Request_VasPushDataRequest-vasMode_VasAndPayment',
                  },
                  {
                    kData: ManageVasMode.VasOrPayment,
                    kID: 'Manage_Request_VasPushDataRequest-vasMode_VasOrPayment',
                  },
                  {
                    kData: ManageVasMode.PaymentOnly,
                    kID: 'Manage_Request_VasPushDataRequest-vasMode_PaymentOnly',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kGroupArrowOpen: true,
                kName: 'googleSmartTapPushService',
                kValue: '',
                kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService',
                kType: DataItemType.Group,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'security',
                kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_security',
                kMenuID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_security_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: ManageSecurity.Normal,
                kData: [
                  {
                    kData: ManageSecurity.NotSet,
                    kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_security_NotSet',
                  },
                  {
                    kData: ManageSecurity.Normal,
                    kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_security_Normal',
                  },
                  {
                    kData: ManageSecurity.Securely,
                    kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_security_Securely',
                  },
                  {
                    kData: ManageSecurity.PreSignature,
                    kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_security_PreSignature',
                  },
                  {
                    kData: ManageSecurity.NeedNotARightAuth,
                    kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_security_NeedNotARightAuth',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 2,
                kBitmapEnable: false,
                kGroupArrowOpen: false,
                kName: 'googleSmartTapCap',
                kValue: '',
                kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap',
                kType: DataItemType.Group,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'standAlone',
                kValue: false,
                kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_standAlone',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'semiIntegrated',
                kValue: false,
                kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_semiIntegrated',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'unattended',
                kValue: false,
                kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_unattended',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'online',
                kValue: false,
                kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_online',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'offline',
                kValue: false,
                kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_offline',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'mmp',
                kValue: false,
                kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_mmp',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'zlibSupport',
                kValue: false,
                kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_zlibSupport',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'printer',
                kValue: false,
                kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_printer',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'printerGraphics',
                kValue: false,
                kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_printerGraphics',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'display',
                kValue: false,
                kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_display',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'images',
                kValue: false,
                kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_images',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'audio',
                kValue: false,
                kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_audio',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'animation',
                kValue: false,
                kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_animation',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'video',
                kValue: false,
                kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_video',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'supportPayment',
                kValue: false,
                kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_supportPayment',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'supportDigitalReceipt',
                kValue: false,
                kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_supportDigitalReceipt',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'supportServiceIssuance',
                kValue: false,
                kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_supportServiceIssuance',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'supportOtaPosData',
                kValue: false,
                kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_supportOtaPosData',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'onlinePin',
                kValue: false,
                kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_onlinePin',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'cdPin',
                kValue: false,
                kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_cdPin',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'signature',
                kValue: false,
                kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_signature',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'noCvm',
                kValue: false,
                kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_noCvm',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'deviceGeneratedCode',
                kValue: false,
                kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_deviceGeneratedCode',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'spGeneratedCode',
                kValue: false,
                kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_spGeneratedCode',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'idCapture',
                kValue: false,
                kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_idCapture',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'bioMetric',
                kValue: false,
                kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_bioMetric',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'collectId',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_collectId',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleServiceUsage',
                kType: DataItemType.ModelList,
                kClass: 'ServiceUsage',
                kShow: true,
                kName: 'googleServiceUsage',
                kValue: [
                  {
                    kType: DataItemType.CellInput,
                    kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleServiceUsage_usageId',
                    kName: 'usageId',
                  },
                  {
                    kType: DataItemType.Menu,
                    kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleServiceUsage_state',
                    kName: 'state',
                    kShow: true,
                    kLevel: 1,
                    kValue: ManageServiceState.NotSet,
                    kData: [
                      {
                         kData: ManageServiceState.NotSet,
                         kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleServiceUsage_state_NotSet',
                      },
                      {
                         kData: ManageServiceState.Unspecified,
                         kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleServiceUsage_state_Unspecified',
                      },
                      {
                         kData: ManageServiceState.Success,
                         kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleServiceUsage_state_Success',
                      },
                      {
                         kData: ManageServiceState.InvalidFormat,
                         kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleServiceUsage_state_InvalidFormat',
                      },
                      {
                         kData: ManageServiceState.InvalidValue,
                         kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleServiceUsage_state_InvalidValue',
                      },
                    ],
                  },
                  {
                    kType: DataItemType.CellInput,
                    kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleServiceUsage_title',
                    kName: 'title',
                  },
                  {
                    kType: DataItemType.CellInput,
                    kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleServiceUsage_describe',
                    kName: 'describe',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 2,
                kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleServiceUpdate',
                kType: DataItemType.ModelList,
                kClass: 'ServiceUpdate',
                kShow: true,
                kName: 'googleServiceUpdate',
                kValue: [
                  {
                    kType: DataItemType.CellInput,
                    kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleServiceUpdate_updateId',
                    kName: 'updateId',
                  },
                  {
                    kType: DataItemType.Menu,
                    kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleServiceUpdate_updateOperation',
                    kName: 'updateOperation',
                    kShow: true,
                    kLevel: 1,
                    kValue: ManageUpdateOperation.NotSet,
                    kData: [
                      {
                         kData: ManageUpdateOperation.NotSet,
                         kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleServiceUpdate_updateOperation_NotSet',
                      },
                      {
                         kData: ManageUpdateOperation.NoOperation,
                         kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleServiceUpdate_updateOperation_NoOperation',
                      },
                      {
                         kData: ManageUpdateOperation.RemoveServiceObject,
                         kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleServiceUpdate_updateOperation_RemoveServiceObject',
                      },
                      {
                         kData: ManageUpdateOperation.SetBalance,
                         kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleServiceUpdate_updateOperation_SetBalance',
                      },
                      {
                         kData: ManageUpdateOperation.AddBalance,
                         kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleServiceUpdate_updateOperation_AddBalance',
                      },
                      {
                         kData: ManageUpdateOperation.SubtractBalance,
                         kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleServiceUpdate_updateOperation_SubtractBalance',
                      },
                      {
                         kData: ManageUpdateOperation.Free,
                         kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleServiceUpdate_updateOperation_Free',
                      },
                    ],
                  },
                  {
                    kType: DataItemType.CellInput,
                    kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleServiceUpdate_updatePayload',
                    kName: 'updatePayload',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 2,
                kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleNewService',
                kType: DataItemType.ModelList,
                kClass: 'NewService',
                kShow: true,
                kName: 'googleNewService',
                kValue: [
                  {
                    kType: DataItemType.Menu,
                    kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleNewService_type',
                    kName: 'type',
                    kShow: true,
                    kLevel: 1,
                    kValue: ManageNewServiceType.NotSet,
                    kData: [
                      {
                         kData: ManageNewServiceType.NotSet,
                         kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleNewService_type_NotSet',
                      },
                      {
                         kData: ManageNewServiceType.Unspecified,
                         kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleNewService_type_Unspecified',
                      },
                      {
                         kData: ManageNewServiceType.Valuable,
                         kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleNewService_type_Valuable',
                      },
                      {
                         kData: ManageNewServiceType.Receipt,
                         kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleNewService_type_Receipt',
                      },
                      {
                         kData: ManageNewServiceType.Survey,
                         kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleNewService_type_Survey',
                      },
                      {
                         kData: ManageNewServiceType.Goods,
                         kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleNewService_type_Goods',
                      },
                      {
                         kData: ManageNewServiceType.Signup,
                         kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleNewService_type_Signup',
                      },
                    ],
                  },
                  {
                    kType: DataItemType.CellInput,
                    kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleNewService_title',
                    kName: 'title',
                  },
                  {
                    kType: DataItemType.CellInput,
                    kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleNewService_url',
                    kName: 'url',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'endTap',
                kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_endTap',
                kMenuID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_endTap_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: ManageEndTap.NormalFlow,
                kData: [
                  {
                    kData: ManageEndTap.NotSet,
                    kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_endTap_NotSet',
                  },
                  {
                    kData: ManageEndTap.NormalFlow,
                    kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_endTap_NormalFlow',
                  },
                  {
                    kData: ManageEndTap.StopTapSession,
                    kID: 'Manage_Request_VasPushDataRequest-googleSmartTapPushService_endTap_StopTapSession',
                  },
                ],
              },
           ];
  }

  static ManageVasPushDataRequest formVasPushDataRequest(List<Map> list) {
    List<Map> queryList = [];
    queryList.addAll(list);
    ManageVasPushDataRequest req = ManageVasPushDataRequest();
    req.vasMode = RequestListModelQuery.query('Manage_Request_VasPushDataRequest-vasMode',queryList);
    req.googleSmartTapPushService = ManageGoogleSmartTapPushService();
    req.googleSmartTapPushService!.security = RequestListModelQuery.query('Manage_Request_VasPushDataRequest-googleSmartTapPushService_security',queryList);
    bool ifNullGoogleSmartTapPushServiceGoogleSmartTapCap = GroupQuery.queryIfNull('Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap', list);    req.googleSmartTapPushService!.googleSmartTapCap = ManageGoogleSmartTapCapBitmap();
    req.googleSmartTapPushService!.googleSmartTapCap!.standAlone = RequestListModelQuery.query('Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_standAlone',queryList);
    req.googleSmartTapPushService!.googleSmartTapCap!.semiIntegrated = RequestListModelQuery.query('Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_semiIntegrated',queryList);
    req.googleSmartTapPushService!.googleSmartTapCap!.unattended = RequestListModelQuery.query('Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_unattended',queryList);
    req.googleSmartTapPushService!.googleSmartTapCap!.online = RequestListModelQuery.query('Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_online',queryList);
    req.googleSmartTapPushService!.googleSmartTapCap!.offline = RequestListModelQuery.query('Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_offline',queryList);
    req.googleSmartTapPushService!.googleSmartTapCap!.mmp = RequestListModelQuery.query('Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_mmp',queryList);
    req.googleSmartTapPushService!.googleSmartTapCap!.zlibSupport = RequestListModelQuery.query('Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_zlibSupport',queryList);
    req.googleSmartTapPushService!.googleSmartTapCap!.printer = RequestListModelQuery.query('Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_printer',queryList);
    req.googleSmartTapPushService!.googleSmartTapCap!.printerGraphics = RequestListModelQuery.query('Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_printerGraphics',queryList);
    req.googleSmartTapPushService!.googleSmartTapCap!.display = RequestListModelQuery.query('Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_display',queryList);
    req.googleSmartTapPushService!.googleSmartTapCap!.images = RequestListModelQuery.query('Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_images',queryList);
    req.googleSmartTapPushService!.googleSmartTapCap!.audio = RequestListModelQuery.query('Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_audio',queryList);
    req.googleSmartTapPushService!.googleSmartTapCap!.animation = RequestListModelQuery.query('Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_animation',queryList);
    req.googleSmartTapPushService!.googleSmartTapCap!.video = RequestListModelQuery.query('Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_video',queryList);
    req.googleSmartTapPushService!.googleSmartTapCap!.supportPayment = RequestListModelQuery.query('Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_supportPayment',queryList);
    req.googleSmartTapPushService!.googleSmartTapCap!.supportDigitalReceipt = RequestListModelQuery.query('Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_supportDigitalReceipt',queryList);
    req.googleSmartTapPushService!.googleSmartTapCap!.supportServiceIssuance = RequestListModelQuery.query('Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_supportServiceIssuance',queryList);
    req.googleSmartTapPushService!.googleSmartTapCap!.supportOtaPosData = RequestListModelQuery.query('Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_supportOtaPosData',queryList);
    req.googleSmartTapPushService!.googleSmartTapCap!.onlinePin = RequestListModelQuery.query('Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_onlinePin',queryList);
    req.googleSmartTapPushService!.googleSmartTapCap!.cdPin = RequestListModelQuery.query('Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_cdPin',queryList);
    req.googleSmartTapPushService!.googleSmartTapCap!.signature = RequestListModelQuery.query('Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_signature',queryList);
    req.googleSmartTapPushService!.googleSmartTapCap!.noCvm = RequestListModelQuery.query('Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_noCvm',queryList);
    req.googleSmartTapPushService!.googleSmartTapCap!.deviceGeneratedCode = RequestListModelQuery.query('Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_deviceGeneratedCode',queryList);
    req.googleSmartTapPushService!.googleSmartTapCap!.spGeneratedCode = RequestListModelQuery.query('Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_spGeneratedCode',queryList);
    req.googleSmartTapPushService!.googleSmartTapCap!.idCapture = RequestListModelQuery.query('Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_idCapture',queryList);
    req.googleSmartTapPushService!.googleSmartTapCap!.bioMetric = RequestListModelQuery.query('Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleSmartTapCap_bioMetric',queryList);
    if (ifNullGoogleSmartTapPushServiceGoogleSmartTapCap == true) {
      req.googleSmartTapPushService!.googleSmartTapCap = null;
    }
    req.googleSmartTapPushService!.collectId = RequestListModelQuery.query('Manage_Request_VasPushDataRequest-googleSmartTapPushService_collectId',queryList);
    req.googleSmartTapPushService!.googleServiceUsage = RequestListModelQuery.query('Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleServiceUsage',queryList);
    req.googleSmartTapPushService!.googleServiceUpdate = RequestListModelQuery.query('Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleServiceUpdate',queryList);
    req.googleSmartTapPushService!.googleNewService = RequestListModelQuery.query('Manage_Request_VasPushDataRequest-googleSmartTapPushService_googleNewService',queryList);
    req.googleSmartTapPushService!.endTap = RequestListModelQuery.query('Manage_Request_VasPushDataRequest-googleSmartTapPushService_endTap',queryList);
    return req;
  }

  static List<Map> initData() {
      return [
              {
                kEnable: true,
                kLevel: 1,
                kName: 'ManageCommand',
                kID: 'ManageCommand',
                kMenuID: 'ManageCommand_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: ManageCommand.DeleteImageRequest,
                kData: [
                  {
                    kData: ManageCommand.DeleteImageRequest,
                    kID: 'ManageCommand_DeleteImageRequest',
                  },
                  {
                    kData: ManageCommand.DoSignatureRequest,
                    kID: 'ManageCommand_DoSignatureRequest',
                  },
                  {
                    kData: ManageCommand.VasPushDataRequest,
                    kID: 'ManageCommand_VasPushDataRequest',
                  },
                  {
                    kData: ManageCommand.InitRequest,
                    kID: 'ManageCommand_InitRequest',
                  },
                  {
                    kData: ManageCommand.SetGoogleSmartTapParametersRequest,
                    kID: 'ManageCommand_SetGoogleSmartTapParametersRequest',
                  },
                  {
                    kData: ManageCommand.CheckFileRequest,
                    kID: 'ManageCommand_CheckFileRequest',
                  },
                  {
                    kData: ManageCommand.ClearCardBufferRequest,
                    kID: 'ManageCommand_ClearCardBufferRequest',
                  },
                  {
                    kData: ManageCommand.SetApplePayVasParametersRequest,
                    kID: 'ManageCommand_SetApplePayVasParametersRequest',
                  },
                  {
                    kData: ManageCommand.GetSignatureRequest,
                    kID: 'ManageCommand_GetSignatureRequest',
                  },
                  {
                    kData: ManageCommand.ResetScreenRequest,
                    kID: 'ManageCommand_ResetScreenRequest',
                  },
                  {
                    kData: ManageCommand.GetVariableRequest,
                    kID: 'ManageCommand_GetVariableRequest',
                  },
                  {
                    kData: ManageCommand.UpdateResourceFileRequest,
                    kID: 'ManageCommand_UpdateResourceFileRequest',
                  },
                  {
                    kData: ManageCommand.RebootRequest,
                    kID: 'ManageCommand_RebootRequest',
                  },
                  {
                    kData: ManageCommand.SetVariableRequest,
                    kID: 'ManageCommand_SetVariableRequest',
                  },
                ],
              },
           ];
  }

  static ManageInitRequest formInitRequest(List<Map> list) {
    List<Map> queryList = [];
    queryList.addAll(list);
    ManageInitRequest req = ManageInitRequest();
    req.classID = RequestListModelQuery.query('Manage_Request_InitRequest-classID',queryList);
    return req;
  }

  static List<Map> setGoogleSmartTapParametersData() {
      return [
              {
                kEnable: true,
                kLevel: 1,
                kName: 'ManageCommand',
                kID: 'ManageCommand',
                kMenuID: 'ManageCommand_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: ManageCommand.DeleteImageRequest,
                kData: [
                  {
                    kData: ManageCommand.DeleteImageRequest,
                    kID: 'ManageCommand_DeleteImageRequest',
                  },
                  {
                    kData: ManageCommand.DoSignatureRequest,
                    kID: 'ManageCommand_DoSignatureRequest',
                  },
                  {
                    kData: ManageCommand.VasPushDataRequest,
                    kID: 'ManageCommand_VasPushDataRequest',
                  },
                  {
                    kData: ManageCommand.InitRequest,
                    kID: 'ManageCommand_InitRequest',
                  },
                  {
                    kData: ManageCommand.SetGoogleSmartTapParametersRequest,
                    kID: 'ManageCommand_SetGoogleSmartTapParametersRequest',
                  },
                  {
                    kData: ManageCommand.CheckFileRequest,
                    kID: 'ManageCommand_CheckFileRequest',
                  },
                  {
                    kData: ManageCommand.ClearCardBufferRequest,
                    kID: 'ManageCommand_ClearCardBufferRequest',
                  },
                  {
                    kData: ManageCommand.SetApplePayVasParametersRequest,
                    kID: 'ManageCommand_SetApplePayVasParametersRequest',
                  },
                  {
                    kData: ManageCommand.GetSignatureRequest,
                    kID: 'ManageCommand_GetSignatureRequest',
                  },
                  {
                    kData: ManageCommand.ResetScreenRequest,
                    kID: 'ManageCommand_ResetScreenRequest',
                  },
                  {
                    kData: ManageCommand.GetVariableRequest,
                    kID: 'ManageCommand_GetVariableRequest',
                  },
                  {
                    kData: ManageCommand.UpdateResourceFileRequest,
                    kID: 'ManageCommand_UpdateResourceFileRequest',
                  },
                  {
                    kData: ManageCommand.RebootRequest,
                    kID: 'ManageCommand_RebootRequest',
                  },
                  {
                    kData: ManageCommand.SetVariableRequest,
                    kID: 'ManageCommand_SetVariableRequest',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'vasMode',
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-vasMode',
                kMenuID: 'Manage_Request_SetGoogleSmartTapParametersRequest-vasMode_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: ManageVasMode.VasOnly,
                kData: [
                  {
                    kData: ManageVasMode.NotSet,
                    kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-vasMode_NotSet',
                  },
                  {
                    kData: ManageVasMode.VasOnly,
                    kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-vasMode_VasOnly',
                  },
                  {
                    kData: ManageVasMode.VasAndPayment,
                    kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-vasMode_VasAndPayment',
                  },
                  {
                    kData: ManageVasMode.VasOrPayment,
                    kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-vasMode_VasOrPayment',
                  },
                  {
                    kData: ManageVasMode.PaymentOnly,
                    kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-vasMode_PaymentOnly',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kGroupArrowOpen: true,
                kName: 'googleSmartTapData',
                kValue: '',
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData',
                kType: DataItemType.Group,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kBitmapEnable: false,
                kGroupArrowOpen: false,
                kName: 'googleSmartTapCap',
                kValue: '',
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap',
                kType: DataItemType.Group,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'standAlone',
                kValue: false,
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_standAlone',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'semiIntegrated',
                kValue: false,
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_semiIntegrated',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'unattended',
                kValue: false,
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_unattended',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'online',
                kValue: false,
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_online',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'offline',
                kValue: false,
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_offline',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'mmp',
                kValue: false,
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_mmp',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'zlibSupport',
                kValue: false,
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_zlibSupport',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'printer',
                kValue: false,
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_printer',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'printerGraphics',
                kValue: false,
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_printerGraphics',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'display',
                kValue: false,
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_display',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'images',
                kValue: false,
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_images',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'audio',
                kValue: false,
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_audio',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'animation',
                kValue: false,
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_animation',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'video',
                kValue: false,
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_video',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'supportPayment',
                kValue: false,
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_supportPayment',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'supportDigitalReceipt',
                kValue: false,
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_supportDigitalReceipt',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'supportServiceIssuance',
                kValue: false,
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_supportServiceIssuance',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'supportOtaPosData',
                kValue: false,
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_supportOtaPosData',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'onlinePin',
                kValue: false,
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_onlinePin',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'cdPin',
                kValue: false,
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_cdPin',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'signature',
                kValue: false,
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_signature',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'noCvm',
                kValue: false,
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_noCvm',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'deviceGeneratedCode',
                kValue: false,
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_deviceGeneratedCode',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'spGeneratedCode',
                kValue: false,
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_spGeneratedCode',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'idCapture',
                kValue: false,
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_idCapture',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'bioMetric',
                kValue: false,
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_bioMetric',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'collectId',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_collectId',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'storeLocalId',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_storeLocalId',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'terminalId',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_terminalId',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'merchantName',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_merchantName',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'merchantCategory',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_merchantCategory',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kBitmapEnable: false,
                kGroupArrowOpen: false,
                kName: 'serviceType',
                kValue: '',
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_serviceType',
                kType: DataItemType.Group,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'allServices',
                kValue: false,
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_serviceType_allServices',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'allServicesExceptPpse',
                kValue: false,
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_serviceType_allServicesExceptPpse',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'ppse',
                kValue: false,
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_serviceType_ppse',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'loyalty',
                kValue: false,
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_serviceType_loyalty',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'offer',
                kValue: false,
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_serviceType_offer',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'giftCard1',
                kValue: false,
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_serviceType_giftCard1',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'privateLabelCard',
                kValue: false,
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_serviceType_privateLabelCard',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'cloudBasedWallet',
                kValue: false,
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_serviceType_cloudBasedWallet',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'mobileMarketingPlatform',
                kValue: false,
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_serviceType_mobileMarketingPlatform',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 3,
                kName: 'walletCustomer',
                kValue: false,
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_serviceType_walletCustomer',
                kType: DataItemType.Boolen,
                kShow: false,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'security',
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_security',
                kMenuID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_security_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: ManageSecurity.Normal,
                kData: [
                  {
                    kData: ManageSecurity.NotSet,
                    kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_security_NotSet',
                  },
                  {
                    kData: ManageSecurity.Normal,
                    kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_security_Normal',
                  },
                  {
                    kData: ManageSecurity.Securely,
                    kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_security_Securely',
                  },
                  {
                    kData: ManageSecurity.PreSignature,
                    kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_security_PreSignature',
                  },
                  {
                    kData: ManageSecurity.NeedNotARightAuth,
                    kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_security_NeedNotARightAuth',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'endTap',
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_endTap',
                kMenuID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_endTap_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: ManageEndTap.NormalFlow,
                kData: [
                  {
                    kData: ManageEndTap.NotSet,
                    kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_endTap_NotSet',
                  },
                  {
                    kData: ManageEndTap.NormalFlow,
                    kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_endTap_NormalFlow',
                  },
                  {
                    kData: ManageEndTap.StopTapSession,
                    kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_endTap_StopTapSession',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'oseToPpse',
                kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_oseToPpse',
                kMenuID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_oseToPpse_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: ManageOseToPpse.NormalFlow,
                kData: [
                  {
                    kData: ManageOseToPpse.NotSet,
                    kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_oseToPpse_NotSet',
                  },
                  {
                    kData: ManageOseToPpse.NormalFlow,
                    kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_oseToPpse_NormalFlow',
                  },
                  {
                    kData: ManageOseToPpse.StopVasAndDoPaymentDirectly,
                    kID: 'Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_oseToPpse_StopVasAndDoPaymentDirectly',
                  },
                ],
              },
           ];
  }

  static ManageSetGoogleSmartTapParametersRequest formSetGoogleSmartTapParametersRequest(List<Map> list) {
    List<Map> queryList = [];
    queryList.addAll(list);
    ManageSetGoogleSmartTapParametersRequest req = ManageSetGoogleSmartTapParametersRequest();
    req.vasMode = RequestListModelQuery.query('Manage_Request_SetGoogleSmartTapParametersRequest-vasMode',queryList);
    req.googleSmartTapData = ManageGoogleSmartTap();
    bool ifNullGoogleSmartTapDataGoogleSmartTapCap = GroupQuery.queryIfNull('Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap', list);    req.googleSmartTapData!.googleSmartTapCap = ManageGoogleSmartTapCapBitmap();
    req.googleSmartTapData!.googleSmartTapCap!.standAlone = RequestListModelQuery.query('Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_standAlone',queryList);
    req.googleSmartTapData!.googleSmartTapCap!.semiIntegrated = RequestListModelQuery.query('Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_semiIntegrated',queryList);
    req.googleSmartTapData!.googleSmartTapCap!.unattended = RequestListModelQuery.query('Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_unattended',queryList);
    req.googleSmartTapData!.googleSmartTapCap!.online = RequestListModelQuery.query('Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_online',queryList);
    req.googleSmartTapData!.googleSmartTapCap!.offline = RequestListModelQuery.query('Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_offline',queryList);
    req.googleSmartTapData!.googleSmartTapCap!.mmp = RequestListModelQuery.query('Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_mmp',queryList);
    req.googleSmartTapData!.googleSmartTapCap!.zlibSupport = RequestListModelQuery.query('Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_zlibSupport',queryList);
    req.googleSmartTapData!.googleSmartTapCap!.printer = RequestListModelQuery.query('Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_printer',queryList);
    req.googleSmartTapData!.googleSmartTapCap!.printerGraphics = RequestListModelQuery.query('Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_printerGraphics',queryList);
    req.googleSmartTapData!.googleSmartTapCap!.display = RequestListModelQuery.query('Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_display',queryList);
    req.googleSmartTapData!.googleSmartTapCap!.images = RequestListModelQuery.query('Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_images',queryList);
    req.googleSmartTapData!.googleSmartTapCap!.audio = RequestListModelQuery.query('Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_audio',queryList);
    req.googleSmartTapData!.googleSmartTapCap!.animation = RequestListModelQuery.query('Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_animation',queryList);
    req.googleSmartTapData!.googleSmartTapCap!.video = RequestListModelQuery.query('Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_video',queryList);
    req.googleSmartTapData!.googleSmartTapCap!.supportPayment = RequestListModelQuery.query('Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_supportPayment',queryList);
    req.googleSmartTapData!.googleSmartTapCap!.supportDigitalReceipt = RequestListModelQuery.query('Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_supportDigitalReceipt',queryList);
    req.googleSmartTapData!.googleSmartTapCap!.supportServiceIssuance = RequestListModelQuery.query('Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_supportServiceIssuance',queryList);
    req.googleSmartTapData!.googleSmartTapCap!.supportOtaPosData = RequestListModelQuery.query('Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_supportOtaPosData',queryList);
    req.googleSmartTapData!.googleSmartTapCap!.onlinePin = RequestListModelQuery.query('Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_onlinePin',queryList);
    req.googleSmartTapData!.googleSmartTapCap!.cdPin = RequestListModelQuery.query('Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_cdPin',queryList);
    req.googleSmartTapData!.googleSmartTapCap!.signature = RequestListModelQuery.query('Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_signature',queryList);
    req.googleSmartTapData!.googleSmartTapCap!.noCvm = RequestListModelQuery.query('Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_noCvm',queryList);
    req.googleSmartTapData!.googleSmartTapCap!.deviceGeneratedCode = RequestListModelQuery.query('Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_deviceGeneratedCode',queryList);
    req.googleSmartTapData!.googleSmartTapCap!.spGeneratedCode = RequestListModelQuery.query('Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_spGeneratedCode',queryList);
    req.googleSmartTapData!.googleSmartTapCap!.idCapture = RequestListModelQuery.query('Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_idCapture',queryList);
    req.googleSmartTapData!.googleSmartTapCap!.bioMetric = RequestListModelQuery.query('Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_googleSmartTapCap_bioMetric',queryList);
    if (ifNullGoogleSmartTapDataGoogleSmartTapCap == true) {
      req.googleSmartTapData!.googleSmartTapCap = null;
    }
    req.googleSmartTapData!.collectId = RequestListModelQuery.query('Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_collectId',queryList);
    req.googleSmartTapData!.storeLocalId = RequestListModelQuery.query('Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_storeLocalId',queryList);
    req.googleSmartTapData!.terminalId = RequestListModelQuery.query('Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_terminalId',queryList);
    req.googleSmartTapData!.merchantName = RequestListModelQuery.query('Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_merchantName',queryList);
    req.googleSmartTapData!.merchantCategory = RequestListModelQuery.query('Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_merchantCategory',queryList);
    bool ifNullGoogleSmartTapDataServiceType = GroupQuery.queryIfNull('Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_serviceType', list);    req.googleSmartTapData!.serviceType = ManageGoogleServiceTypeBitmap();
    req.googleSmartTapData!.serviceType!.allServices = RequestListModelQuery.query('Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_serviceType_allServices',queryList);
    req.googleSmartTapData!.serviceType!.allServicesExceptPpse = RequestListModelQuery.query('Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_serviceType_allServicesExceptPpse',queryList);
    req.googleSmartTapData!.serviceType!.ppse = RequestListModelQuery.query('Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_serviceType_ppse',queryList);
    req.googleSmartTapData!.serviceType!.loyalty = RequestListModelQuery.query('Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_serviceType_loyalty',queryList);
    req.googleSmartTapData!.serviceType!.offer = RequestListModelQuery.query('Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_serviceType_offer',queryList);
    req.googleSmartTapData!.serviceType!.giftCard1 = RequestListModelQuery.query('Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_serviceType_giftCard1',queryList);
    req.googleSmartTapData!.serviceType!.privateLabelCard = RequestListModelQuery.query('Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_serviceType_privateLabelCard',queryList);
    req.googleSmartTapData!.serviceType!.cloudBasedWallet = RequestListModelQuery.query('Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_serviceType_cloudBasedWallet',queryList);
    req.googleSmartTapData!.serviceType!.mobileMarketingPlatform = RequestListModelQuery.query('Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_serviceType_mobileMarketingPlatform',queryList);
    req.googleSmartTapData!.serviceType!.walletCustomer = RequestListModelQuery.query('Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_serviceType_walletCustomer',queryList);
    if (ifNullGoogleSmartTapDataServiceType == true) {
      req.googleSmartTapData!.serviceType = null;
    }
    req.googleSmartTapData!.security = RequestListModelQuery.query('Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_security',queryList);
    req.googleSmartTapData!.endTap = RequestListModelQuery.query('Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_endTap',queryList);
    req.googleSmartTapData!.oseToPpse = RequestListModelQuery.query('Manage_Request_SetGoogleSmartTapParametersRequest-googleSmartTapData_oseToPpse',queryList);
    return req;
  }

  static List<Map> checkFileData() {
      return [
              {
                kEnable: true,
                kLevel: 1,
                kName: 'ManageCommand',
                kID: 'ManageCommand',
                kMenuID: 'ManageCommand_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: ManageCommand.DeleteImageRequest,
                kData: [
                  {
                    kData: ManageCommand.DeleteImageRequest,
                    kID: 'ManageCommand_DeleteImageRequest',
                  },
                  {
                    kData: ManageCommand.DoSignatureRequest,
                    kID: 'ManageCommand_DoSignatureRequest',
                  },
                  {
                    kData: ManageCommand.VasPushDataRequest,
                    kID: 'ManageCommand_VasPushDataRequest',
                  },
                  {
                    kData: ManageCommand.InitRequest,
                    kID: 'ManageCommand_InitRequest',
                  },
                  {
                    kData: ManageCommand.SetGoogleSmartTapParametersRequest,
                    kID: 'ManageCommand_SetGoogleSmartTapParametersRequest',
                  },
                  {
                    kData: ManageCommand.CheckFileRequest,
                    kID: 'ManageCommand_CheckFileRequest',
                  },
                  {
                    kData: ManageCommand.ClearCardBufferRequest,
                    kID: 'ManageCommand_ClearCardBufferRequest',
                  },
                  {
                    kData: ManageCommand.SetApplePayVasParametersRequest,
                    kID: 'ManageCommand_SetApplePayVasParametersRequest',
                  },
                  {
                    kData: ManageCommand.GetSignatureRequest,
                    kID: 'ManageCommand_GetSignatureRequest',
                  },
                  {
                    kData: ManageCommand.ResetScreenRequest,
                    kID: 'ManageCommand_ResetScreenRequest',
                  },
                  {
                    kData: ManageCommand.GetVariableRequest,
                    kID: 'ManageCommand_GetVariableRequest',
                  },
                  {
                    kData: ManageCommand.UpdateResourceFileRequest,
                    kID: 'ManageCommand_UpdateResourceFileRequest',
                  },
                  {
                    kData: ManageCommand.RebootRequest,
                    kID: 'ManageCommand_RebootRequest',
                  },
                  {
                    kData: ManageCommand.SetVariableRequest,
                    kID: 'ManageCommand_SetVariableRequest',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'fileName',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Manage_Request_CheckFileRequest-fileName',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

  static ManageCheckFileRequest formCheckFileRequest(List<Map> list) {
    List<Map> queryList = [];
    queryList.addAll(list);
    ManageCheckFileRequest req = ManageCheckFileRequest();
    req.fileName = RequestListModelQuery.query('Manage_Request_CheckFileRequest-fileName',queryList);
    return req;
  }

  static List<Map> clearCardBufferData() {
      return [
              {
                kEnable: true,
                kLevel: 1,
                kName: 'ManageCommand',
                kID: 'ManageCommand',
                kMenuID: 'ManageCommand_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: ManageCommand.DeleteImageRequest,
                kData: [
                  {
                    kData: ManageCommand.DeleteImageRequest,
                    kID: 'ManageCommand_DeleteImageRequest',
                  },
                  {
                    kData: ManageCommand.DoSignatureRequest,
                    kID: 'ManageCommand_DoSignatureRequest',
                  },
                  {
                    kData: ManageCommand.VasPushDataRequest,
                    kID: 'ManageCommand_VasPushDataRequest',
                  },
                  {
                    kData: ManageCommand.InitRequest,
                    kID: 'ManageCommand_InitRequest',
                  },
                  {
                    kData: ManageCommand.SetGoogleSmartTapParametersRequest,
                    kID: 'ManageCommand_SetGoogleSmartTapParametersRequest',
                  },
                  {
                    kData: ManageCommand.CheckFileRequest,
                    kID: 'ManageCommand_CheckFileRequest',
                  },
                  {
                    kData: ManageCommand.ClearCardBufferRequest,
                    kID: 'ManageCommand_ClearCardBufferRequest',
                  },
                  {
                    kData: ManageCommand.SetApplePayVasParametersRequest,
                    kID: 'ManageCommand_SetApplePayVasParametersRequest',
                  },
                  {
                    kData: ManageCommand.GetSignatureRequest,
                    kID: 'ManageCommand_GetSignatureRequest',
                  },
                  {
                    kData: ManageCommand.ResetScreenRequest,
                    kID: 'ManageCommand_ResetScreenRequest',
                  },
                  {
                    kData: ManageCommand.GetVariableRequest,
                    kID: 'ManageCommand_GetVariableRequest',
                  },
                  {
                    kData: ManageCommand.UpdateResourceFileRequest,
                    kID: 'ManageCommand_UpdateResourceFileRequest',
                  },
                  {
                    kData: ManageCommand.RebootRequest,
                    kID: 'ManageCommand_RebootRequest',
                  },
                  {
                    kData: ManageCommand.SetVariableRequest,
                    kID: 'ManageCommand_SetVariableRequest',
                  },
                ],
              },
           ];
  }

  static ManageClearCardBufferRequest formClearCardBufferRequest(List<Map> list) {
    List<Map> queryList = [];
    queryList.addAll(list);
    ManageClearCardBufferRequest req = ManageClearCardBufferRequest();
    req.classID = RequestListModelQuery.query('Manage_Request_ClearCardBufferRequest-classID',queryList);
    return req;
  }

  static List<Map> setApplePayVasParametersData() {
      return [
              {
                kEnable: true,
                kLevel: 1,
                kName: 'ManageCommand',
                kID: 'ManageCommand',
                kMenuID: 'ManageCommand_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: ManageCommand.DeleteImageRequest,
                kData: [
                  {
                    kData: ManageCommand.DeleteImageRequest,
                    kID: 'ManageCommand_DeleteImageRequest',
                  },
                  {
                    kData: ManageCommand.DoSignatureRequest,
                    kID: 'ManageCommand_DoSignatureRequest',
                  },
                  {
                    kData: ManageCommand.VasPushDataRequest,
                    kID: 'ManageCommand_VasPushDataRequest',
                  },
                  {
                    kData: ManageCommand.InitRequest,
                    kID: 'ManageCommand_InitRequest',
                  },
                  {
                    kData: ManageCommand.SetGoogleSmartTapParametersRequest,
                    kID: 'ManageCommand_SetGoogleSmartTapParametersRequest',
                  },
                  {
                    kData: ManageCommand.CheckFileRequest,
                    kID: 'ManageCommand_CheckFileRequest',
                  },
                  {
                    kData: ManageCommand.ClearCardBufferRequest,
                    kID: 'ManageCommand_ClearCardBufferRequest',
                  },
                  {
                    kData: ManageCommand.SetApplePayVasParametersRequest,
                    kID: 'ManageCommand_SetApplePayVasParametersRequest',
                  },
                  {
                    kData: ManageCommand.GetSignatureRequest,
                    kID: 'ManageCommand_GetSignatureRequest',
                  },
                  {
                    kData: ManageCommand.ResetScreenRequest,
                    kID: 'ManageCommand_ResetScreenRequest',
                  },
                  {
                    kData: ManageCommand.GetVariableRequest,
                    kID: 'ManageCommand_GetVariableRequest',
                  },
                  {
                    kData: ManageCommand.UpdateResourceFileRequest,
                    kID: 'ManageCommand_UpdateResourceFileRequest',
                  },
                  {
                    kData: ManageCommand.RebootRequest,
                    kID: 'ManageCommand_RebootRequest',
                  },
                  {
                    kData: ManageCommand.SetVariableRequest,
                    kID: 'ManageCommand_SetVariableRequest',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'vasMode',
                kID: 'Manage_Request_SetApplePayVasParametersRequest-vasMode',
                kMenuID: 'Manage_Request_SetApplePayVasParametersRequest-vasMode_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: ManageVasMode.VasOnly,
                kData: [
                  {
                    kData: ManageVasMode.NotSet,
                    kID: 'Manage_Request_SetApplePayVasParametersRequest-vasMode_NotSet',
                  },
                  {
                    kData: ManageVasMode.VasOnly,
                    kID: 'Manage_Request_SetApplePayVasParametersRequest-vasMode_VasOnly',
                  },
                  {
                    kData: ManageVasMode.VasAndPayment,
                    kID: 'Manage_Request_SetApplePayVasParametersRequest-vasMode_VasAndPayment',
                  },
                  {
                    kData: ManageVasMode.VasOrPayment,
                    kID: 'Manage_Request_SetApplePayVasParametersRequest-vasMode_VasOrPayment',
                  },
                  {
                    kData: ManageVasMode.PaymentOnly,
                    kID: 'Manage_Request_SetApplePayVasParametersRequest-vasMode_PaymentOnly',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kGroupArrowOpen: true,
                kName: 'applePayVasData',
                kValue: '',
                kID: 'Manage_Request_SetApplePayVasParametersRequest-applePayVasData',
                kType: DataItemType.Group,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'merchantId',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Manage_Request_SetApplePayVasParametersRequest-applePayVasData_merchantId',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'urlMode',
                kID: 'Manage_Request_SetApplePayVasParametersRequest-applePayVasData_urlMode',
                kMenuID: 'Manage_Request_SetApplePayVasParametersRequest-applePayVasData_urlMode_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: ManageUrlMode.NotSet,
                kData: [
                  {
                    kData: ManageUrlMode.NotSet,
                    kID: 'Manage_Request_SetApplePayVasParametersRequest-applePayVasData_urlMode_NotSet',
                  },
                  {
                    kData: ManageUrlMode.FullVasMode,
                    kID: 'Manage_Request_SetApplePayVasParametersRequest-applePayVasData_urlMode_FullVasMode',
                  },
                  {
                    kData: ManageUrlMode.UrlMode,
                    kID: 'Manage_Request_SetApplePayVasParametersRequest-applePayVasData_urlMode_UrlMode',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'url',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Manage_Request_SetApplePayVasParametersRequest-applePayVasData_url',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'keyFileMapping',
                kValue: ' ',
                kID: 'Manage_Request_SetApplePayVasParametersRequest-applePayVasData_keyFileMapping',
                kType: DataItemType.StringList,
                kShow: true,
              },
           ];
  }

  static ManageSetApplePayVasParametersRequest formSetApplePayVasParametersRequest(List<Map> list) {
    List<Map> queryList = [];
    queryList.addAll(list);
    ManageSetApplePayVasParametersRequest req = ManageSetApplePayVasParametersRequest();
    req.vasMode = RequestListModelQuery.query('Manage_Request_SetApplePayVasParametersRequest-vasMode',queryList);
    req.applePayVasData = ManageApplePayVas();
    req.applePayVasData!.merchantId = RequestListModelQuery.query('Manage_Request_SetApplePayVasParametersRequest-applePayVasData_merchantId',queryList);
    req.applePayVasData!.urlMode = RequestListModelQuery.query('Manage_Request_SetApplePayVasParametersRequest-applePayVasData_urlMode',queryList);
    req.applePayVasData!.url = RequestListModelQuery.query('Manage_Request_SetApplePayVasParametersRequest-applePayVasData_url',queryList);
    req.applePayVasData!.keyFileMapping = ListStringQuery.query('Manage_Request_SetApplePayVasParametersRequest-applePayVasData_keyFileMapping',queryList);
    return req;
  }

  static List<Map> getSignatureData() {
      return [
              {
                kEnable: true,
                kLevel: 1,
                kName: 'ManageCommand',
                kID: 'ManageCommand',
                kMenuID: 'ManageCommand_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: ManageCommand.DeleteImageRequest,
                kData: [
                  {
                    kData: ManageCommand.DeleteImageRequest,
                    kID: 'ManageCommand_DeleteImageRequest',
                  },
                  {
                    kData: ManageCommand.DoSignatureRequest,
                    kID: 'ManageCommand_DoSignatureRequest',
                  },
                  {
                    kData: ManageCommand.VasPushDataRequest,
                    kID: 'ManageCommand_VasPushDataRequest',
                  },
                  {
                    kData: ManageCommand.InitRequest,
                    kID: 'ManageCommand_InitRequest',
                  },
                  {
                    kData: ManageCommand.SetGoogleSmartTapParametersRequest,
                    kID: 'ManageCommand_SetGoogleSmartTapParametersRequest',
                  },
                  {
                    kData: ManageCommand.CheckFileRequest,
                    kID: 'ManageCommand_CheckFileRequest',
                  },
                  {
                    kData: ManageCommand.ClearCardBufferRequest,
                    kID: 'ManageCommand_ClearCardBufferRequest',
                  },
                  {
                    kData: ManageCommand.SetApplePayVasParametersRequest,
                    kID: 'ManageCommand_SetApplePayVasParametersRequest',
                  },
                  {
                    kData: ManageCommand.GetSignatureRequest,
                    kID: 'ManageCommand_GetSignatureRequest',
                  },
                  {
                    kData: ManageCommand.ResetScreenRequest,
                    kID: 'ManageCommand_ResetScreenRequest',
                  },
                  {
                    kData: ManageCommand.GetVariableRequest,
                    kID: 'ManageCommand_GetVariableRequest',
                  },
                  {
                    kData: ManageCommand.UpdateResourceFileRequest,
                    kID: 'ManageCommand_UpdateResourceFileRequest',
                  },
                  {
                    kData: ManageCommand.RebootRequest,
                    kID: 'ManageCommand_RebootRequest',
                  },
                  {
                    kData: ManageCommand.SetVariableRequest,
                    kID: 'ManageCommand_SetVariableRequest',
                  },
                ],
              },
           ];
  }

  static ManageGetSignatureRequest formGetSignatureRequest(List<Map> list) {
    List<Map> queryList = [];
    queryList.addAll(list);
    ManageGetSignatureRequest req = ManageGetSignatureRequest();
    req.classID = RequestListModelQuery.query('Manage_Request_GetSignatureRequest-classID',queryList);
    return req;
  }

  static List<Map> resetScreenData() {
      return [
              {
                kEnable: true,
                kLevel: 1,
                kName: 'ManageCommand',
                kID: 'ManageCommand',
                kMenuID: 'ManageCommand_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: ManageCommand.DeleteImageRequest,
                kData: [
                  {
                    kData: ManageCommand.DeleteImageRequest,
                    kID: 'ManageCommand_DeleteImageRequest',
                  },
                  {
                    kData: ManageCommand.DoSignatureRequest,
                    kID: 'ManageCommand_DoSignatureRequest',
                  },
                  {
                    kData: ManageCommand.VasPushDataRequest,
                    kID: 'ManageCommand_VasPushDataRequest',
                  },
                  {
                    kData: ManageCommand.InitRequest,
                    kID: 'ManageCommand_InitRequest',
                  },
                  {
                    kData: ManageCommand.SetGoogleSmartTapParametersRequest,
                    kID: 'ManageCommand_SetGoogleSmartTapParametersRequest',
                  },
                  {
                    kData: ManageCommand.CheckFileRequest,
                    kID: 'ManageCommand_CheckFileRequest',
                  },
                  {
                    kData: ManageCommand.ClearCardBufferRequest,
                    kID: 'ManageCommand_ClearCardBufferRequest',
                  },
                  {
                    kData: ManageCommand.SetApplePayVasParametersRequest,
                    kID: 'ManageCommand_SetApplePayVasParametersRequest',
                  },
                  {
                    kData: ManageCommand.GetSignatureRequest,
                    kID: 'ManageCommand_GetSignatureRequest',
                  },
                  {
                    kData: ManageCommand.ResetScreenRequest,
                    kID: 'ManageCommand_ResetScreenRequest',
                  },
                  {
                    kData: ManageCommand.GetVariableRequest,
                    kID: 'ManageCommand_GetVariableRequest',
                  },
                  {
                    kData: ManageCommand.UpdateResourceFileRequest,
                    kID: 'ManageCommand_UpdateResourceFileRequest',
                  },
                  {
                    kData: ManageCommand.RebootRequest,
                    kID: 'ManageCommand_RebootRequest',
                  },
                  {
                    kData: ManageCommand.SetVariableRequest,
                    kID: 'ManageCommand_SetVariableRequest',
                  },
                ],
              },
           ];
  }

  static ManageResetScreenRequest formResetScreenRequest(List<Map> list) {
    List<Map> queryList = [];
    queryList.addAll(list);
    ManageResetScreenRequest req = ManageResetScreenRequest();
    req.classID = RequestListModelQuery.query('Manage_Request_ResetScreenRequest-classID',queryList);
    return req;
  }

  static List<Map> getVariableData() {
      return [
              {
                kEnable: true,
                kLevel: 1,
                kName: 'ManageCommand',
                kID: 'ManageCommand',
                kMenuID: 'ManageCommand_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: ManageCommand.DeleteImageRequest,
                kData: [
                  {
                    kData: ManageCommand.DeleteImageRequest,
                    kID: 'ManageCommand_DeleteImageRequest',
                  },
                  {
                    kData: ManageCommand.DoSignatureRequest,
                    kID: 'ManageCommand_DoSignatureRequest',
                  },
                  {
                    kData: ManageCommand.VasPushDataRequest,
                    kID: 'ManageCommand_VasPushDataRequest',
                  },
                  {
                    kData: ManageCommand.InitRequest,
                    kID: 'ManageCommand_InitRequest',
                  },
                  {
                    kData: ManageCommand.SetGoogleSmartTapParametersRequest,
                    kID: 'ManageCommand_SetGoogleSmartTapParametersRequest',
                  },
                  {
                    kData: ManageCommand.CheckFileRequest,
                    kID: 'ManageCommand_CheckFileRequest',
                  },
                  {
                    kData: ManageCommand.ClearCardBufferRequest,
                    kID: 'ManageCommand_ClearCardBufferRequest',
                  },
                  {
                    kData: ManageCommand.SetApplePayVasParametersRequest,
                    kID: 'ManageCommand_SetApplePayVasParametersRequest',
                  },
                  {
                    kData: ManageCommand.GetSignatureRequest,
                    kID: 'ManageCommand_GetSignatureRequest',
                  },
                  {
                    kData: ManageCommand.ResetScreenRequest,
                    kID: 'ManageCommand_ResetScreenRequest',
                  },
                  {
                    kData: ManageCommand.GetVariableRequest,
                    kID: 'ManageCommand_GetVariableRequest',
                  },
                  {
                    kData: ManageCommand.UpdateResourceFileRequest,
                    kID: 'ManageCommand_UpdateResourceFileRequest',
                  },
                  {
                    kData: ManageCommand.RebootRequest,
                    kID: 'ManageCommand_RebootRequest',
                  },
                  {
                    kData: ManageCommand.SetVariableRequest,
                    kID: 'ManageCommand_SetVariableRequest',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'edcType',
                kID: 'Manage_Request_GetVariableRequest-edcType',
                kMenuID: 'Manage_Request_GetVariableRequest-edcType_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: ManageEdcType.NotSet,
                kData: [
                  {
                    kData: ManageEdcType.NotSet,
                    kID: 'Manage_Request_GetVariableRequest-edcType_NotSet',
                  },
                  {
                    kData: ManageEdcType.All,
                    kID: 'Manage_Request_GetVariableRequest-edcType_All',
                  },
                  {
                    kData: ManageEdcType.Credit,
                    kID: 'Manage_Request_GetVariableRequest-edcType_Credit',
                  },
                  {
                    kData: ManageEdcType.Debit,
                    kID: 'Manage_Request_GetVariableRequest-edcType_Debit',
                  },
                  {
                    kData: ManageEdcType.Ebt,
                    kID: 'Manage_Request_GetVariableRequest-edcType_Ebt',
                  },
                  {
                    kData: ManageEdcType.Gift,
                    kID: 'Manage_Request_GetVariableRequest-edcType_Gift',
                  },
                  {
                    kData: ManageEdcType.Loyalty,
                    kID: 'Manage_Request_GetVariableRequest-edcType_Loyalty',
                  },
                  {
                    kData: ManageEdcType.Cash,
                    kID: 'Manage_Request_GetVariableRequest-edcType_Cash',
                  },
                  {
                    kData: ManageEdcType.QrPayment,
                    kID: 'Manage_Request_GetVariableRequest-edcType_QrPayment',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'variableName1',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Manage_Request_GetVariableRequest-variableName1',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'variableName2',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Manage_Request_GetVariableRequest-variableName2',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'variableName3',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Manage_Request_GetVariableRequest-variableName3',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'variableName4',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Manage_Request_GetVariableRequest-variableName4',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'variableName5',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Manage_Request_GetVariableRequest-variableName5',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kGroupArrowOpen: true,
                kName: 'multiMerchant',
                kValue: '',
                kID: 'Manage_Request_GetVariableRequest-multiMerchant',
                kType: DataItemType.Group,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'multiMerchantId',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'Manage_Request_GetVariableRequest-multiMerchant_multiMerchantId',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'multiMerchantName',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Manage_Request_GetVariableRequest-multiMerchant_multiMerchantName',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

  static ManageGetVariableRequest formGetVariableRequest(List<Map> list) {
    List<Map> queryList = [];
    queryList.addAll(list);
    ManageGetVariableRequest req = ManageGetVariableRequest();
    req.edcType = RequestListModelQuery.query('Manage_Request_GetVariableRequest-edcType',queryList);
    req.variableName1 = RequestListModelQuery.query('Manage_Request_GetVariableRequest-variableName1',queryList);
    req.variableName2 = RequestListModelQuery.query('Manage_Request_GetVariableRequest-variableName2',queryList);
    req.variableName3 = RequestListModelQuery.query('Manage_Request_GetVariableRequest-variableName3',queryList);
    req.variableName4 = RequestListModelQuery.query('Manage_Request_GetVariableRequest-variableName4',queryList);
    req.variableName5 = RequestListModelQuery.query('Manage_Request_GetVariableRequest-variableName5',queryList);
    req.multiMerchant = ManageMultiMerchant();
    req.multiMerchant!.multiMerchantId = RequestListModelQuery.query('Manage_Request_GetVariableRequest-multiMerchant_multiMerchantId',queryList);
    req.multiMerchant!.multiMerchantName = RequestListModelQuery.query('Manage_Request_GetVariableRequest-multiMerchant_multiMerchantName',queryList);
    return req;
  }

  static List<Map> updateResourceFileData() {
      return [
              {
                kEnable: true,
                kLevel: 1,
                kName: 'ManageCommand',
                kID: 'ManageCommand',
                kMenuID: 'ManageCommand_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: ManageCommand.DeleteImageRequest,
                kData: [
                  {
                    kData: ManageCommand.DeleteImageRequest,
                    kID: 'ManageCommand_DeleteImageRequest',
                  },
                  {
                    kData: ManageCommand.DoSignatureRequest,
                    kID: 'ManageCommand_DoSignatureRequest',
                  },
                  {
                    kData: ManageCommand.VasPushDataRequest,
                    kID: 'ManageCommand_VasPushDataRequest',
                  },
                  {
                    kData: ManageCommand.InitRequest,
                    kID: 'ManageCommand_InitRequest',
                  },
                  {
                    kData: ManageCommand.SetGoogleSmartTapParametersRequest,
                    kID: 'ManageCommand_SetGoogleSmartTapParametersRequest',
                  },
                  {
                    kData: ManageCommand.CheckFileRequest,
                    kID: 'ManageCommand_CheckFileRequest',
                  },
                  {
                    kData: ManageCommand.ClearCardBufferRequest,
                    kID: 'ManageCommand_ClearCardBufferRequest',
                  },
                  {
                    kData: ManageCommand.SetApplePayVasParametersRequest,
                    kID: 'ManageCommand_SetApplePayVasParametersRequest',
                  },
                  {
                    kData: ManageCommand.GetSignatureRequest,
                    kID: 'ManageCommand_GetSignatureRequest',
                  },
                  {
                    kData: ManageCommand.ResetScreenRequest,
                    kID: 'ManageCommand_ResetScreenRequest',
                  },
                  {
                    kData: ManageCommand.GetVariableRequest,
                    kID: 'ManageCommand_GetVariableRequest',
                  },
                  {
                    kData: ManageCommand.UpdateResourceFileRequest,
                    kID: 'ManageCommand_UpdateResourceFileRequest',
                  },
                  {
                    kData: ManageCommand.RebootRequest,
                    kID: 'ManageCommand_RebootRequest',
                  },
                  {
                    kData: ManageCommand.SetVariableRequest,
                    kID: 'ManageCommand_SetVariableRequest',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kTextFieldButtonName: 'Select',
                kName: 'fileUrl',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Manage_Request_UpdateResourceFileRequest-fileUrl',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'fileType',
                kID: 'Manage_Request_UpdateResourceFileRequest-fileType',
                kMenuID: 'Manage_Request_UpdateResourceFileRequest-fileType_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: ManageFileType.ResourceFile,
                kData: [
                  {
                    kData: ManageFileType.NotSet,
                    kID: 'Manage_Request_UpdateResourceFileRequest-fileType_NotSet',
                  },
                  {
                    kData: ManageFileType.ResourceFile,
                    kID: 'Manage_Request_UpdateResourceFileRequest-fileType_ResourceFile',
                  },
                  {
                    kData: ManageFileType.OfflineRkiKeyFile,
                    kID: 'Manage_Request_UpdateResourceFileRequest-fileType_OfflineRkiKeyFile',
                  },
                  {
                    kData: ManageFileType.InstallationPackageFile,
                    kID: 'Manage_Request_UpdateResourceFileRequest-fileType_InstallationPackageFile',
                  },
                  {
                    kData: ManageFileType.licenseFile,
                    kID: 'Manage_Request_UpdateResourceFileRequest-fileType_licenseFile',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'targetDevice',
                kID: 'Manage_Request_UpdateResourceFileRequest-targetDevice',
                kMenuID: 'Manage_Request_UpdateResourceFileRequest-targetDevice_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: ManageTargetDevice.NotSet,
                kData: [
                  {
                    kData: ManageTargetDevice.NotSet,
                    kID: 'Manage_Request_UpdateResourceFileRequest-targetDevice_NotSet',
                  },
                  {
                    kData: ManageTargetDevice.Terminal,
                    kID: 'Manage_Request_UpdateResourceFileRequest-targetDevice_Terminal',
                  },
                  {
                    kData: ManageTargetDevice.ExternalPinpad,
                    kID: 'Manage_Request_UpdateResourceFileRequest-targetDevice_ExternalPinpad',
                  },
                ],
              },
           ];
  }

  static ManageUpdateResourceFileRequest formUpdateResourceFileRequest(List<Map> list) {
    List<Map> queryList = [];
    queryList.addAll(list);
    ManageUpdateResourceFileRequest req = ManageUpdateResourceFileRequest();
    req.fileUrl = RequestListModelQuery.query('Manage_Request_UpdateResourceFileRequest-fileUrl',queryList);
    req.fileType = RequestListModelQuery.query('Manage_Request_UpdateResourceFileRequest-fileType',queryList);
    req.targetDevice = RequestListModelQuery.query('Manage_Request_UpdateResourceFileRequest-targetDevice',queryList);
    return req;
  }

  static List<Map> rebootData() {
      return [
              {
                kEnable: true,
                kLevel: 1,
                kName: 'ManageCommand',
                kID: 'ManageCommand',
                kMenuID: 'ManageCommand_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: ManageCommand.DeleteImageRequest,
                kData: [
                  {
                    kData: ManageCommand.DeleteImageRequest,
                    kID: 'ManageCommand_DeleteImageRequest',
                  },
                  {
                    kData: ManageCommand.DoSignatureRequest,
                    kID: 'ManageCommand_DoSignatureRequest',
                  },
                  {
                    kData: ManageCommand.VasPushDataRequest,
                    kID: 'ManageCommand_VasPushDataRequest',
                  },
                  {
                    kData: ManageCommand.InitRequest,
                    kID: 'ManageCommand_InitRequest',
                  },
                  {
                    kData: ManageCommand.SetGoogleSmartTapParametersRequest,
                    kID: 'ManageCommand_SetGoogleSmartTapParametersRequest',
                  },
                  {
                    kData: ManageCommand.CheckFileRequest,
                    kID: 'ManageCommand_CheckFileRequest',
                  },
                  {
                    kData: ManageCommand.ClearCardBufferRequest,
                    kID: 'ManageCommand_ClearCardBufferRequest',
                  },
                  {
                    kData: ManageCommand.SetApplePayVasParametersRequest,
                    kID: 'ManageCommand_SetApplePayVasParametersRequest',
                  },
                  {
                    kData: ManageCommand.GetSignatureRequest,
                    kID: 'ManageCommand_GetSignatureRequest',
                  },
                  {
                    kData: ManageCommand.ResetScreenRequest,
                    kID: 'ManageCommand_ResetScreenRequest',
                  },
                  {
                    kData: ManageCommand.GetVariableRequest,
                    kID: 'ManageCommand_GetVariableRequest',
                  },
                  {
                    kData: ManageCommand.UpdateResourceFileRequest,
                    kID: 'ManageCommand_UpdateResourceFileRequest',
                  },
                  {
                    kData: ManageCommand.RebootRequest,
                    kID: 'ManageCommand_RebootRequest',
                  },
                  {
                    kData: ManageCommand.SetVariableRequest,
                    kID: 'ManageCommand_SetVariableRequest',
                  },
                ],
              },
           ];
  }

  static ManageRebootRequest formRebootRequest(List<Map> list) {
    List<Map> queryList = [];
    queryList.addAll(list);
    ManageRebootRequest req = ManageRebootRequest();
    req.classID = RequestListModelQuery.query('Manage_Request_RebootRequest-classID',queryList);
    return req;
  }

  static List<Map> setVariableData() {
      return [
              {
                kEnable: true,
                kLevel: 1,
                kName: 'ManageCommand',
                kID: 'ManageCommand',
                kMenuID: 'ManageCommand_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: ManageCommand.DeleteImageRequest,
                kData: [
                  {
                    kData: ManageCommand.DeleteImageRequest,
                    kID: 'ManageCommand_DeleteImageRequest',
                  },
                  {
                    kData: ManageCommand.DoSignatureRequest,
                    kID: 'ManageCommand_DoSignatureRequest',
                  },
                  {
                    kData: ManageCommand.VasPushDataRequest,
                    kID: 'ManageCommand_VasPushDataRequest',
                  },
                  {
                    kData: ManageCommand.InitRequest,
                    kID: 'ManageCommand_InitRequest',
                  },
                  {
                    kData: ManageCommand.SetGoogleSmartTapParametersRequest,
                    kID: 'ManageCommand_SetGoogleSmartTapParametersRequest',
                  },
                  {
                    kData: ManageCommand.CheckFileRequest,
                    kID: 'ManageCommand_CheckFileRequest',
                  },
                  {
                    kData: ManageCommand.ClearCardBufferRequest,
                    kID: 'ManageCommand_ClearCardBufferRequest',
                  },
                  {
                    kData: ManageCommand.SetApplePayVasParametersRequest,
                    kID: 'ManageCommand_SetApplePayVasParametersRequest',
                  },
                  {
                    kData: ManageCommand.GetSignatureRequest,
                    kID: 'ManageCommand_GetSignatureRequest',
                  },
                  {
                    kData: ManageCommand.ResetScreenRequest,
                    kID: 'ManageCommand_ResetScreenRequest',
                  },
                  {
                    kData: ManageCommand.GetVariableRequest,
                    kID: 'ManageCommand_GetVariableRequest',
                  },
                  {
                    kData: ManageCommand.UpdateResourceFileRequest,
                    kID: 'ManageCommand_UpdateResourceFileRequest',
                  },
                  {
                    kData: ManageCommand.RebootRequest,
                    kID: 'ManageCommand_RebootRequest',
                  },
                  {
                    kData: ManageCommand.SetVariableRequest,
                    kID: 'ManageCommand_SetVariableRequest',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'edcType',
                kID: 'Manage_Request_SetVariableRequest-edcType',
                kMenuID: 'Manage_Request_SetVariableRequest-edcType_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: ManageEdcType.NotSet,
                kData: [
                  {
                    kData: ManageEdcType.NotSet,
                    kID: 'Manage_Request_SetVariableRequest-edcType_NotSet',
                  },
                  {
                    kData: ManageEdcType.All,
                    kID: 'Manage_Request_SetVariableRequest-edcType_All',
                  },
                  {
                    kData: ManageEdcType.Credit,
                    kID: 'Manage_Request_SetVariableRequest-edcType_Credit',
                  },
                  {
                    kData: ManageEdcType.Debit,
                    kID: 'Manage_Request_SetVariableRequest-edcType_Debit',
                  },
                  {
                    kData: ManageEdcType.Ebt,
                    kID: 'Manage_Request_SetVariableRequest-edcType_Ebt',
                  },
                  {
                    kData: ManageEdcType.Gift,
                    kID: 'Manage_Request_SetVariableRequest-edcType_Gift',
                  },
                  {
                    kData: ManageEdcType.Loyalty,
                    kID: 'Manage_Request_SetVariableRequest-edcType_Loyalty',
                  },
                  {
                    kData: ManageEdcType.Cash,
                    kID: 'Manage_Request_SetVariableRequest-edcType_Cash',
                  },
                  {
                    kData: ManageEdcType.QrPayment,
                    kID: 'Manage_Request_SetVariableRequest-edcType_QrPayment',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'variableName1',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Manage_Request_SetVariableRequest-variableName1',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'variableValue1',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Manage_Request_SetVariableRequest-variableValue1',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'variableName2',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Manage_Request_SetVariableRequest-variableName2',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'variableValue2',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Manage_Request_SetVariableRequest-variableValue2',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'variableName3',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Manage_Request_SetVariableRequest-variableName3',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'variableValue3',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Manage_Request_SetVariableRequest-variableValue3',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'variableName4',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Manage_Request_SetVariableRequest-variableName4',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'variableValue4',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Manage_Request_SetVariableRequest-variableValue4',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'variableName5',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Manage_Request_SetVariableRequest-variableName5',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'variableValue5',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Manage_Request_SetVariableRequest-variableValue5',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kGroupArrowOpen: true,
                kName: 'multiMerchant',
                kValue: '',
                kID: 'Manage_Request_SetVariableRequest-multiMerchant',
                kType: DataItemType.Group,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'multiMerchantId',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'Manage_Request_SetVariableRequest-multiMerchant_multiMerchantId',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'multiMerchantName',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Manage_Request_SetVariableRequest-multiMerchant_multiMerchantName',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

  static ManageSetVariableRequest formSetVariableRequest(List<Map> list) {
    List<Map> queryList = [];
    queryList.addAll(list);
    ManageSetVariableRequest req = ManageSetVariableRequest();
    req.edcType = RequestListModelQuery.query('Manage_Request_SetVariableRequest-edcType',queryList);
    req.variableName1 = RequestListModelQuery.query('Manage_Request_SetVariableRequest-variableName1',queryList);
    req.variableValue1 = RequestListModelQuery.query('Manage_Request_SetVariableRequest-variableValue1',queryList);
    req.variableName2 = RequestListModelQuery.query('Manage_Request_SetVariableRequest-variableName2',queryList);
    req.variableValue2 = RequestListModelQuery.query('Manage_Request_SetVariableRequest-variableValue2',queryList);
    req.variableName3 = RequestListModelQuery.query('Manage_Request_SetVariableRequest-variableName3',queryList);
    req.variableValue3 = RequestListModelQuery.query('Manage_Request_SetVariableRequest-variableValue3',queryList);
    req.variableName4 = RequestListModelQuery.query('Manage_Request_SetVariableRequest-variableName4',queryList);
    req.variableValue4 = RequestListModelQuery.query('Manage_Request_SetVariableRequest-variableValue4',queryList);
    req.variableName5 = RequestListModelQuery.query('Manage_Request_SetVariableRequest-variableName5',queryList);
    req.variableValue5 = RequestListModelQuery.query('Manage_Request_SetVariableRequest-variableValue5',queryList);
    req.multiMerchant = ManageMultiMerchant();
    req.multiMerchant!.multiMerchantId = RequestListModelQuery.query('Manage_Request_SetVariableRequest-multiMerchant_multiMerchantId',queryList);
    req.multiMerchant!.multiMerchantName = RequestListModelQuery.query('Manage_Request_SetVariableRequest-multiMerchant_multiMerchantName',queryList);
    return req;
  }

  static List<Map>? queryDataByString(String string) {
    List tempList = string.split('.');
    if (tempList.length < 2) { return null; }
    String tempStr = tempList[1];
    List<Map> list;
    switch (tempStr) {
      case 'DeleteImageRequest':
        list = ManageReqData.deleteImageData();
        break;
      case 'DoSignatureRequest':
        list = ManageReqData.doSignatureData();
        break;
      case 'VasPushDataRequest':
        list = ManageReqData.vasPushDataData();
        break;
      case 'InitRequest':
        list = ManageReqData.initData();
        break;
      case 'SetGoogleSmartTapParametersRequest':
        list = ManageReqData.setGoogleSmartTapParametersData();
        break;
      case 'CheckFileRequest':
        list = ManageReqData.checkFileData();
        break;
      case 'ClearCardBufferRequest':
        list = ManageReqData.clearCardBufferData();
        break;
      case 'SetApplePayVasParametersRequest':
        list = ManageReqData.setApplePayVasParametersData();
        break;
      case 'GetSignatureRequest':
        list = ManageReqData.getSignatureData();
        break;
      case 'ResetScreenRequest':
        list = ManageReqData.resetScreenData();
        break;
      case 'GetVariableRequest':
        list = ManageReqData.getVariableData();
        break;
      case 'UpdateResourceFileRequest':
        list = ManageReqData.updateResourceFileData();
        break;
      case 'RebootRequest':
        list = ManageReqData.rebootData();
        break;
      case 'SetVariableRequest':
        list = ManageReqData.setVariableData();
        break;
      default:
        list = [];
        break;
    }
    return list;
  }

}

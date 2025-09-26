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
class FullIntegrationReqData {
  static List<Map> initSourceData() {
    return FullIntegrationReqData.getEmvTlvDataData();
  }
  static List<Map> getEmvTlvDataData() {
      return [
              {
                kEnable: true,
                kLevel: 1,
                kName: 'FullIntegrationCommand',
                kID: 'FullIntegrationCommand',
                kMenuID: 'FullIntegrationCommand_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationCommand.GetEmvTlvDataRequest,
                kData: [
                  {
                    kData: FullIntegrationCommand.GetEmvTlvDataRequest,
                    kID: 'FullIntegrationCommand_GetEmvTlvDataRequest',
                  },
                  {
                    kData: FullIntegrationCommand.InputAccountWithEmvRequest,
                    kID: 'FullIntegrationCommand_InputAccountWithEmvRequest',
                  },
                  {
                    kData: FullIntegrationCommand.CompleteOnlineEmvRequest,
                    kID: 'FullIntegrationCommand_CompleteOnlineEmvRequest',
                  },
                  {
                    kData: FullIntegrationCommand.AuthorizeCardRequest,
                    kID: 'FullIntegrationCommand_AuthorizeCardRequest',
                  },
                  {
                    kData: FullIntegrationCommand.GetPinBlockRequest,
                    kID: 'FullIntegrationCommand_GetPinBlockRequest',
                  },
                  {
                    kData: FullIntegrationCommand.SetEmvTlvDataRequest,
                    kID: 'FullIntegrationCommand_SetEmvTlvDataRequest',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'tlvType',
                kID: 'FullIntegration_Request_GetEmvTlvDataRequest-tlvType',
                kMenuID: 'FullIntegration_Request_GetEmvTlvDataRequest-tlvType_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationTlvType.NotSet,
                kData: [
                  {
                    kData: FullIntegrationTlvType.NotSet,
                    kID: 'FullIntegration_Request_GetEmvTlvDataRequest-tlvType_NotSet',
                  },
                  {
                    kData: FullIntegrationTlvType.EmvContact,
                    kID: 'FullIntegration_Request_GetEmvTlvDataRequest-tlvType_EmvContact',
                  },
                  {
                    kData: FullIntegrationTlvType.EmvContactless,
                    kID: 'FullIntegration_Request_GetEmvTlvDataRequest-tlvType_EmvContactless',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'tagList',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'FullIntegration_Request_GetEmvTlvDataRequest-tagList',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

  static FullIntegrationGetEmvTlvDataRequest formGetEmvTlvDataRequest(List<Map> list) {
    List<Map> queryList = [];
    queryList.addAll(list);
    FullIntegrationGetEmvTlvDataRequest req = FullIntegrationGetEmvTlvDataRequest();
    req.tlvType = RequestListModelQuery.query('FullIntegration_Request_GetEmvTlvDataRequest-tlvType',queryList);
    req.tagList = RequestListModelQuery.query('FullIntegration_Request_GetEmvTlvDataRequest-tagList',queryList);
    return req;
  }

  static List<Map> inputAccountWithEmvData() {
      return [
              {
                kEnable: true,
                kLevel: 1,
                kName: 'FullIntegrationCommand',
                kID: 'FullIntegrationCommand',
                kMenuID: 'FullIntegrationCommand_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationCommand.GetEmvTlvDataRequest,
                kData: [
                  {
                    kData: FullIntegrationCommand.GetEmvTlvDataRequest,
                    kID: 'FullIntegrationCommand_GetEmvTlvDataRequest',
                  },
                  {
                    kData: FullIntegrationCommand.InputAccountWithEmvRequest,
                    kID: 'FullIntegrationCommand_InputAccountWithEmvRequest',
                  },
                  {
                    kData: FullIntegrationCommand.CompleteOnlineEmvRequest,
                    kID: 'FullIntegrationCommand_CompleteOnlineEmvRequest',
                  },
                  {
                    kData: FullIntegrationCommand.AuthorizeCardRequest,
                    kID: 'FullIntegrationCommand_AuthorizeCardRequest',
                  },
                  {
                    kData: FullIntegrationCommand.GetPinBlockRequest,
                    kID: 'FullIntegrationCommand_GetPinBlockRequest',
                  },
                  {
                    kData: FullIntegrationCommand.SetEmvTlvDataRequest,
                    kID: 'FullIntegrationCommand_SetEmvTlvDataRequest',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'edcType',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-edcType',
                kMenuID: 'FullIntegration_Request_InputAccountWithEmvRequest-edcType_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationEdcType.Credit,
                kData: [
                  {
                    kData: FullIntegrationEdcType.NotSet,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-edcType_NotSet',
                  },
                  {
                    kData: FullIntegrationEdcType.All,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-edcType_All',
                  },
                  {
                    kData: FullIntegrationEdcType.Credit,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-edcType_Credit',
                  },
                  {
                    kData: FullIntegrationEdcType.Debit,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-edcType_Debit',
                  },
                  {
                    kData: FullIntegrationEdcType.Ebt,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-edcType_Ebt',
                  },
                  {
                    kData: FullIntegrationEdcType.Gift,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-edcType_Gift',
                  },
                  {
                    kData: FullIntegrationEdcType.Loyalty,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-edcType_Loyalty',
                  },
                  {
                    kData: FullIntegrationEdcType.Cash,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-edcType_Cash',
                  },
                  {
                    kData: FullIntegrationEdcType.QrPayment,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-edcType_QrPayment',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'transactionType',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-transactionType',
                kMenuID: 'FullIntegration_Request_InputAccountWithEmvRequest-transactionType_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationTransactionType.Sale,
                kData: [
                  {
                    kData: FullIntegrationTransactionType.NotSet,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-transactionType_NotSet',
                  },
                  {
                    kData: FullIntegrationTransactionType.Unknown,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-transactionType_Unknown',
                  },
                  {
                    kData: FullIntegrationTransactionType.Sale,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-transactionType_Sale',
                  },
                  {
                    kData: FullIntegrationTransactionType.Return,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-transactionType_Return',
                  },
                  {
                    kData: FullIntegrationTransactionType.Authorization,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-transactionType_Authorization',
                  },
                  {
                    kData: FullIntegrationTransactionType.PostAuthorization,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-transactionType_PostAuthorization',
                  },
                  {
                    kData: FullIntegrationTransactionType.ForceAuthorization,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-transactionType_ForceAuthorization',
                  },
                  {
                    kData: FullIntegrationTransactionType.Adjust,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-transactionType_Adjust',
                  },
                  {
                    kData: FullIntegrationTransactionType.Withdrawal,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-transactionType_Withdrawal',
                  },
                  {
                    kData: FullIntegrationTransactionType.Activate,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-transactionType_Activate',
                  },
                  {
                    kData: FullIntegrationTransactionType.Issue,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-transactionType_Issue',
                  },
                  {
                    kData: FullIntegrationTransactionType.Reload,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-transactionType_Reload',
                  },
                  {
                    kData: FullIntegrationTransactionType.Cashout,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-transactionType_Cashout',
                  },
                  {
                    kData: FullIntegrationTransactionType.Deactivate,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-transactionType_Deactivate',
                  },
                  {
                    kData: FullIntegrationTransactionType.Replace,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-transactionType_Replace',
                  },
                  {
                    kData: FullIntegrationTransactionType.Merge,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-transactionType_Merge',
                  },
                  {
                    kData: FullIntegrationTransactionType.ReportLost,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-transactionType_ReportLost',
                  },
                  {
                    kData: FullIntegrationTransactionType.Void,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-transactionType_Void',
                  },
                  {
                    kData: FullIntegrationTransactionType.VoidSale,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-transactionType_VoidSale',
                  },
                  {
                    kData: FullIntegrationTransactionType.VoidReturn,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-transactionType_VoidReturn',
                  },
                  {
                    kData: FullIntegrationTransactionType.VoidAuthorization,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-transactionType_VoidAuthorization',
                  },
                  {
                    kData: FullIntegrationTransactionType.VoidPostAuthorization,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-transactionType_VoidPostAuthorization',
                  },
                  {
                    kData: FullIntegrationTransactionType.VoidForceAuthorization,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-transactionType_VoidForceAuthorization',
                  },
                  {
                    kData: FullIntegrationTransactionType.VoidWithdrawal,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-transactionType_VoidWithdrawal',
                  },
                  {
                    kData: FullIntegrationTransactionType.Inquiry,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-transactionType_Inquiry',
                  },
                  {
                    kData: FullIntegrationTransactionType.Verify,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-transactionType_Verify',
                  },
                  {
                    kData: FullIntegrationTransactionType.Reactivate,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-transactionType_Reactivate',
                  },
                  {
                    kData: FullIntegrationTransactionType.ForcedIssue,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-transactionType_ForcedIssue',
                  },
                  {
                    kData: FullIntegrationTransactionType.ForcedAdd,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-transactionType_ForcedAdd',
                  },
                  {
                    kData: FullIntegrationTransactionType.Unload,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-transactionType_Unload',
                  },
                  {
                    kData: FullIntegrationTransactionType.Renew,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-transactionType_Renew',
                  },
                  {
                    kData: FullIntegrationTransactionType.GetConvertDetail,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-transactionType_GetConvertDetail',
                  },
                  {
                    kData: FullIntegrationTransactionType.Convert,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-transactionType_Convert',
                  },
                  {
                    kData: FullIntegrationTransactionType.Tokenize,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-transactionType_Tokenize',
                  },
                  {
                    kData: FullIntegrationTransactionType.IncrementalAuthorization,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-transactionType_IncrementalAuthorization',
                  },
                  {
                    kData: FullIntegrationTransactionType.BalanceWithLock,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-transactionType_BalanceWithLock',
                  },
                  {
                    kData: FullIntegrationTransactionType.RedemptionWithUnlock,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-transactionType_RedemptionWithUnlock',
                  },
                  {
                    kData: FullIntegrationTransactionType.Rewards,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-transactionType_Rewards',
                  },
                  {
                    kData: FullIntegrationTransactionType.Reenter,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-transactionType_Reenter',
                  },
                  {
                    kData: FullIntegrationTransactionType.TransactionAdjustment,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-transactionType_TransactionAdjustment',
                  },
                  {
                    kData: FullIntegrationTransactionType.Transfer,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-transactionType_Transfer',
                  },
                  {
                    kData: FullIntegrationTransactionType.Finalize,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-transactionType_Finalize',
                  },
                  {
                    kData: FullIntegrationTransactionType.Deposit,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-transactionType_Deposit',
                  },
                  {
                    kData: FullIntegrationTransactionType.AccountPayment,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-transactionType_AccountPayment',
                  },
                  {
                    kData: FullIntegrationTransactionType.Reversal,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-transactionType_Reversal',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kGroupArrowOpen: true,
                kName: 'amountInformation',
                kValue: '',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-amountInformation',
                kType: DataItemType.Group,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'transactionAmount',
                kValue: '100',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-amountInformation_transactionAmount',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'tipAmount',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-amountInformation_tipAmount',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'cashBackAmount',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-amountInformation_cashBackAmount',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'merchantFee',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-amountInformation_merchantFee',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'taxAmount',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-amountInformation_taxAmount',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'fuelAmount',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-amountInformation_fuelAmount',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'serviceFee',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-amountInformation_serviceFee',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'originalAmount',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-amountInformation_originalAmount',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'magneticSwipePinpadEnableFlag',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-magneticSwipePinpadEnableFlag',
                kMenuID: 'FullIntegration_Request_InputAccountWithEmvRequest-magneticSwipePinpadEnableFlag_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationPinpadEnableFlag.Allowed,
                kData: [
                  {
                    kData: FullIntegrationPinpadEnableFlag.NotSet,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-magneticSwipePinpadEnableFlag_NotSet',
                  },
                  {
                    kData: FullIntegrationPinpadEnableFlag.NotAllowed,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-magneticSwipePinpadEnableFlag_NotAllowed',
                  },
                  {
                    kData: FullIntegrationPinpadEnableFlag.Allowed,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-magneticSwipePinpadEnableFlag_Allowed',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'magneticSwipePinpadTypeFlag',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-magneticSwipePinpadTypeFlag',
                kMenuID: 'FullIntegration_Request_InputAccountWithEmvRequest-magneticSwipePinpadTypeFlag_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationPinpadTypeFlag.InternalPinpad,
                kData: [
                  {
                    kData: FullIntegrationPinpadTypeFlag.NotSet,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-magneticSwipePinpadTypeFlag_NotSet',
                  },
                  {
                    kData: FullIntegrationPinpadTypeFlag.InternalPinpad,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-magneticSwipePinpadTypeFlag_InternalPinpad',
                  },
                  {
                    kData: FullIntegrationPinpadTypeFlag.ExternalPinpad,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-magneticSwipePinpadTypeFlag_ExternalPinpad',
                  },
                  {
                    kData: FullIntegrationPinpadTypeFlag.ExternalPinpadFirst,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-magneticSwipePinpadTypeFlag_ExternalPinpadFirst',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'manualPinpadEnableFlag',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-manualPinpadEnableFlag',
                kMenuID: 'FullIntegration_Request_InputAccountWithEmvRequest-manualPinpadEnableFlag_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationPinpadEnableFlag.NotSet,
                kData: [
                  {
                    kData: FullIntegrationPinpadEnableFlag.NotSet,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-manualPinpadEnableFlag_NotSet',
                  },
                  {
                    kData: FullIntegrationPinpadEnableFlag.NotAllowed,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-manualPinpadEnableFlag_NotAllowed',
                  },
                  {
                    kData: FullIntegrationPinpadEnableFlag.Allowed,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-manualPinpadEnableFlag_Allowed',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'contactlessPinpadEnableFlag',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-contactlessPinpadEnableFlag',
                kMenuID: 'FullIntegration_Request_InputAccountWithEmvRequest-contactlessPinpadEnableFlag_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationPinpadEnableFlag.Allowed,
                kData: [
                  {
                    kData: FullIntegrationPinpadEnableFlag.NotSet,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-contactlessPinpadEnableFlag_NotSet',
                  },
                  {
                    kData: FullIntegrationPinpadEnableFlag.NotAllowed,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-contactlessPinpadEnableFlag_NotAllowed',
                  },
                  {
                    kData: FullIntegrationPinpadEnableFlag.Allowed,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-contactlessPinpadEnableFlag_Allowed',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'contactlessPinpadTypeFlag',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-contactlessPinpadTypeFlag',
                kMenuID: 'FullIntegration_Request_InputAccountWithEmvRequest-contactlessPinpadTypeFlag_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationPinpadTypeFlag.InternalPinpad,
                kData: [
                  {
                    kData: FullIntegrationPinpadTypeFlag.NotSet,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-contactlessPinpadTypeFlag_NotSet',
                  },
                  {
                    kData: FullIntegrationPinpadTypeFlag.InternalPinpad,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-contactlessPinpadTypeFlag_InternalPinpad',
                  },
                  {
                    kData: FullIntegrationPinpadTypeFlag.ExternalPinpad,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-contactlessPinpadTypeFlag_ExternalPinpad',
                  },
                  {
                    kData: FullIntegrationPinpadTypeFlag.ExternalPinpadFirst,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-contactlessPinpadTypeFlag_ExternalPinpadFirst',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'contactEmvPinpadEnableFlag',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-contactEmvPinpadEnableFlag',
                kMenuID: 'FullIntegration_Request_InputAccountWithEmvRequest-contactEmvPinpadEnableFlag_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationPinpadEnableFlag.Allowed,
                kData: [
                  {
                    kData: FullIntegrationPinpadEnableFlag.NotSet,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-contactEmvPinpadEnableFlag_NotSet',
                  },
                  {
                    kData: FullIntegrationPinpadEnableFlag.NotAllowed,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-contactEmvPinpadEnableFlag_NotAllowed',
                  },
                  {
                    kData: FullIntegrationPinpadEnableFlag.Allowed,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-contactEmvPinpadEnableFlag_Allowed',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'contactEmvPinpadTypeFlag',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-contactEmvPinpadTypeFlag',
                kMenuID: 'FullIntegration_Request_InputAccountWithEmvRequest-contactEmvPinpadTypeFlag_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationPinpadTypeFlag.InternalPinpad,
                kData: [
                  {
                    kData: FullIntegrationPinpadTypeFlag.NotSet,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-contactEmvPinpadTypeFlag_NotSet',
                  },
                  {
                    kData: FullIntegrationPinpadTypeFlag.InternalPinpad,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-contactEmvPinpadTypeFlag_InternalPinpad',
                  },
                  {
                    kData: FullIntegrationPinpadTypeFlag.ExternalPinpad,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-contactEmvPinpadTypeFlag_ExternalPinpad',
                  },
                  {
                    kData: FullIntegrationPinpadTypeFlag.ExternalPinpadFirst,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-contactEmvPinpadTypeFlag_ExternalPinpadFirst',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'fallbackSwipePinpadEnableFlag',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-fallbackSwipePinpadEnableFlag',
                kMenuID: 'FullIntegration_Request_InputAccountWithEmvRequest-fallbackSwipePinpadEnableFlag_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationPinpadEnableFlag.NotSet,
                kData: [
                  {
                    kData: FullIntegrationPinpadEnableFlag.NotSet,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-fallbackSwipePinpadEnableFlag_NotSet',
                  },
                  {
                    kData: FullIntegrationPinpadEnableFlag.NotAllowed,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-fallbackSwipePinpadEnableFlag_NotAllowed',
                  },
                  {
                    kData: FullIntegrationPinpadEnableFlag.Allowed,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-fallbackSwipePinpadEnableFlag_Allowed',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'laserScannerFlag',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-laserScannerFlag',
                kMenuID: 'FullIntegration_Request_InputAccountWithEmvRequest-laserScannerFlag_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationLaserScannerFlag.NotSet,
                kData: [
                  {
                    kData: FullIntegrationLaserScannerFlag.NotSet,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-laserScannerFlag_NotSet',
                  },
                  {
                    kData: FullIntegrationLaserScannerFlag.NotAllowed,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-laserScannerFlag_NotAllowed',
                  },
                  {
                    kData: FullIntegrationLaserScannerFlag.Allowed,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-laserScannerFlag_Allowed',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'frontCameraFlag',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-frontCameraFlag',
                kMenuID: 'FullIntegration_Request_InputAccountWithEmvRequest-frontCameraFlag_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationFrontCameraFlag.NotSet,
                kData: [
                  {
                    kData: FullIntegrationFrontCameraFlag.NotSet,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-frontCameraFlag_NotSet',
                  },
                  {
                    kData: FullIntegrationFrontCameraFlag.NotAllowed,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-frontCameraFlag_NotAllowed',
                  },
                  {
                    kData: FullIntegrationFrontCameraFlag.Allowed,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-frontCameraFlag_Allowed',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'rearCameraFlag',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-rearCameraFlag',
                kMenuID: 'FullIntegration_Request_InputAccountWithEmvRequest-rearCameraFlag_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationRearCameraFlag.NotSet,
                kData: [
                  {
                    kData: FullIntegrationRearCameraFlag.NotSet,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-rearCameraFlag_NotSet',
                  },
                  {
                    kData: FullIntegrationRearCameraFlag.NotAllowed,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-rearCameraFlag_NotAllowed',
                  },
                  {
                    kData: FullIntegrationRearCameraFlag.Allowed,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-rearCameraFlag_Allowed',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kGroupArrowOpen: true,
                kName: 'additionalPrompts',
                kValue: '',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-additionalPrompts',
                kType: DataItemType.Group,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'expiryDatePrompt',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-additionalPrompts_expiryDatePrompt',
                kMenuID: 'FullIntegration_Request_InputAccountWithEmvRequest-additionalPrompts_expiryDatePrompt_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationPrompt.NotSet,
                kData: [
                  {
                    kData: FullIntegrationPrompt.NotSet,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-additionalPrompts_expiryDatePrompt_NotSet',
                  },
                  {
                    kData: FullIntegrationPrompt.NoPrompt,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-additionalPrompts_expiryDatePrompt_NoPrompt',
                  },
                  {
                    kData: FullIntegrationPrompt.NeedPrompt,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-additionalPrompts_expiryDatePrompt_NeedPrompt',
                  },
                  {
                    kData: FullIntegrationPrompt.PromptBypassNotAllowed,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-additionalPrompts_expiryDatePrompt_PromptBypassNotAllowed',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'cvvPrompt',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-additionalPrompts_cvvPrompt',
                kMenuID: 'FullIntegration_Request_InputAccountWithEmvRequest-additionalPrompts_cvvPrompt_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationPrompt.NotSet,
                kData: [
                  {
                    kData: FullIntegrationPrompt.NotSet,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-additionalPrompts_cvvPrompt_NotSet',
                  },
                  {
                    kData: FullIntegrationPrompt.NoPrompt,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-additionalPrompts_cvvPrompt_NoPrompt',
                  },
                  {
                    kData: FullIntegrationPrompt.NeedPrompt,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-additionalPrompts_cvvPrompt_NeedPrompt',
                  },
                  {
                    kData: FullIntegrationPrompt.PromptBypassNotAllowed,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-additionalPrompts_cvvPrompt_PromptBypassNotAllowed',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'zipCodePrompt',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-additionalPrompts_zipCodePrompt',
                kMenuID: 'FullIntegration_Request_InputAccountWithEmvRequest-additionalPrompts_zipCodePrompt_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationPrompt.NotSet,
                kData: [
                  {
                    kData: FullIntegrationPrompt.NotSet,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-additionalPrompts_zipCodePrompt_NotSet',
                  },
                  {
                    kData: FullIntegrationPrompt.NoPrompt,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-additionalPrompts_zipCodePrompt_NoPrompt',
                  },
                  {
                    kData: FullIntegrationPrompt.NeedPrompt,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-additionalPrompts_zipCodePrompt_NeedPrompt',
                  },
                  {
                    kData: FullIntegrationPrompt.PromptBypassNotAllowed,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-additionalPrompts_zipCodePrompt_PromptBypassNotAllowed',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'encryptionFlag',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-encryptionFlag',
                kMenuID: 'FullIntegration_Request_InputAccountWithEmvRequest-encryptionFlag_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationDataEncryptionFlag.NotSet,
                kData: [
                  {
                    kData: FullIntegrationDataEncryptionFlag.NotSet,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-encryptionFlag_NotSet',
                  },
                  {
                    kData: FullIntegrationDataEncryptionFlag.NotEncrypted,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-encryptionFlag_NotEncrypted',
                  },
                  {
                    kData: FullIntegrationDataEncryptionFlag.DukptTripleDesKeyWithCbcMode,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-encryptionFlag_DukptTripleDesKeyWithCbcMode',
                  },
                  {
                    kData: FullIntegrationDataEncryptionFlag.DukptTripleDesKeyWithEcbMode,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-encryptionFlag_DukptTripleDesKeyWithEcbMode',
                  },
                  {
                    kData: FullIntegrationDataEncryptionFlag.DesOrTdesMethod,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-encryptionFlag_DesOrTdesMethod',
                  },
                  {
                    kData: FullIntegrationDataEncryptionFlag.VoltageE2ee,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-encryptionFlag_VoltageE2ee',
                  },
                  {
                    kData: FullIntegrationDataEncryptionFlag.AesCbcDukpt,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-encryptionFlag_AesCbcDukpt',
                  },
                  {
                    kData: FullIntegrationDataEncryptionFlag.AesEcbDukpt,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-encryptionFlag_AesEcbDukpt',
                  },
                  {
                    kData: FullIntegrationDataEncryptionFlag.Aes192CbcDukpt,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-encryptionFlag_Aes192CbcDukpt',
                  },
                  {
                    kData: FullIntegrationDataEncryptionFlag.Aes192EcbDukpt,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-encryptionFlag_Aes192EcbDukpt',
                  },
                  {
                    kData: FullIntegrationDataEncryptionFlag.Aes256CbcDukpt,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-encryptionFlag_Aes256CbcDukpt',
                  },
                  {
                    kData: FullIntegrationDataEncryptionFlag.Aes256EcbDukpt,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-encryptionFlag_Aes256EcbDukpt',
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
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-keySlot',
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
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-paddingChar',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'trackDataSentinel',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-trackDataSentinel',
                kMenuID: 'FullIntegration_Request_InputAccountWithEmvRequest-trackDataSentinel_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationTrackDataSentinel.NotSet,
                kData: [
                  {
                    kData: FullIntegrationTrackDataSentinel.NotSet,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-trackDataSentinel_NotSet',
                  },
                  {
                    kData: FullIntegrationTrackDataSentinel.ExcludeStartEnd,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-trackDataSentinel_ExcludeStartEnd',
                  },
                  {
                    kData: FullIntegrationTrackDataSentinel.IncludeStartEnd,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-trackDataSentinel_IncludeStartEnd',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'minAccountLength',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-minAccountLength',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'maxAccountLength',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-maxAccountLength',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kGroupArrowOpen: true,
                kName: 'terminalConfiguration',
                kValue: '',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-terminalConfiguration',
                kType: DataItemType.Group,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'emvKernelConfigurationSelection',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-terminalConfiguration_emvKernelConfigurationSelection',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'transactionDate',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-terminalConfiguration_transactionDate',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'transactionTime',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-terminalConfiguration_transactionTime',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'currencyCode',
                kValue: '840',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-terminalConfiguration_currencyCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'currencyExponent',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-terminalConfiguration_currencyExponent',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'merchantCategoryCode',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-terminalConfiguration_merchantCategoryCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'transactionSequenceNumber',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-terminalConfiguration_transactionSequenceNumber',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'transactionCvmLimit',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-terminalConfiguration_transactionCvmLimit',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'tagList',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-tagList',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'timeout',
                kValue: '300',
                kTextAttribute: 1,
                kUnit: '0.1s',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-timeout',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'statusReportFlag',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-statusReportFlag',
                kMenuID: 'FullIntegration_Request_InputAccountWithEmvRequest-statusReportFlag_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationStatusReportFlag.NotSet,
                kData: [
                  {
                    kData: FullIntegrationStatusReportFlag.NotSet,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-statusReportFlag_NotSet',
                  },
                  {
                    kData: FullIntegrationStatusReportFlag.NotToReport,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-statusReportFlag_NotToReport',
                  },
                  {
                    kData: FullIntegrationStatusReportFlag.ToReport,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-statusReportFlag_ToReport',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'continuousScreen',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-continuousScreen',
                kMenuID: 'FullIntegration_Request_InputAccountWithEmvRequest-continuousScreen_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationContinuousScreen.NotSet,
                kData: [
                  {
                    kData: FullIntegrationContinuousScreen.NotSet,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-continuousScreen_NotSet',
                  },
                  {
                    kData: FullIntegrationContinuousScreen.Default,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-continuousScreen_Default',
                  },
                  {
                    kData: FullIntegrationContinuousScreen.NotGoToIdleScreen,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-continuousScreen_NotGoToIdleScreen',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'fallbackInsertPinpadEnableFlag',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-fallbackInsertPinpadEnableFlag',
                kMenuID: 'FullIntegration_Request_InputAccountWithEmvRequest-fallbackInsertPinpadEnableFlag_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationPinpadEnableFlag.NotSet,
                kData: [
                  {
                    kData: FullIntegrationPinpadEnableFlag.NotSet,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-fallbackInsertPinpadEnableFlag_NotSet',
                  },
                  {
                    kData: FullIntegrationPinpadEnableFlag.NotAllowed,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-fallbackInsertPinpadEnableFlag_NotAllowed',
                  },
                  {
                    kData: FullIntegrationPinpadEnableFlag.Allowed,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-fallbackInsertPinpadEnableFlag_Allowed',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'ksnFlag',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-ksnFlag',
                kMenuID: 'FullIntegration_Request_InputAccountWithEmvRequest-ksnFlag_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationKsnFlag.NotSet,
                kData: [
                  {
                    kData: FullIntegrationKsnFlag.NotSet,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-ksnFlag_NotSet',
                  },
                  {
                    kData: FullIntegrationKsnFlag.NotIncrease,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-ksnFlag_NotIncrease',
                  },
                  {
                    kData: FullIntegrationKsnFlag.Increase,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-ksnFlag_Increase',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'customData',
                kValue: ' ',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-customData',
                kType: DataItemType.StringList,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'fallbackToManualPinpadEnableFlag',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-fallbackToManualPinpadEnableFlag',
                kMenuID: 'FullIntegration_Request_InputAccountWithEmvRequest-fallbackToManualPinpadEnableFlag_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationPinpadEnableFlag.NotSet,
                kData: [
                  {
                    kData: FullIntegrationPinpadEnableFlag.NotSet,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-fallbackToManualPinpadEnableFlag_NotSet',
                  },
                  {
                    kData: FullIntegrationPinpadEnableFlag.NotAllowed,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-fallbackToManualPinpadEnableFlag_NotAllowed',
                  },
                  {
                    kData: FullIntegrationPinpadEnableFlag.Allowed,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-fallbackToManualPinpadEnableFlag_Allowed',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kGroupArrowOpen: true,
                kName: 'customMacInformation',
                kValue: '',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-customMacInformation',
                kType: DataItemType.Group,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'keyType',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-customMacInformation_keyType',
                kMenuID: 'FullIntegration_Request_InputAccountWithEmvRequest-customMacInformation_keyType_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationMacKeyType.NotSet,
                kData: [
                  {
                    kData: FullIntegrationMacKeyType.NotSet,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-customMacInformation_keyType_NotSet',
                  },
                  {
                    kData: FullIntegrationMacKeyType.Tak,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-customMacInformation_keyType_Tak',
                  },
                  {
                    kData: FullIntegrationMacKeyType.DesDukptKey,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-customMacInformation_keyType_DesDukptKey',
                  },
                  {
                    kData: FullIntegrationMacKeyType.AesDukptKey,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-customMacInformation_keyType_AesDukptKey',
                  },
                  {
                    kData: FullIntegrationMacKeyType.Hmac,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-customMacInformation_keyType_Hmac',
                  },
                  {
                    kData: FullIntegrationMacKeyType.Aes192DukptKey,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-customMacInformation_keyType_Aes192DukptKey',
                  },
                  {
                    kData: FullIntegrationMacKeyType.Aes256DukptKey,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-customMacInformation_keyType_Aes256DukptKey',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'workMode',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-customMacInformation_workMode',
                kMenuID: 'FullIntegration_Request_InputAccountWithEmvRequest-customMacInformation_workMode_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationMacWorkMode.NotSet,
                kData: [
                  {
                    kData: FullIntegrationMacWorkMode.NotSet,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-customMacInformation_workMode_NotSet',
                  },
                  {
                    kData: FullIntegrationMacWorkMode.AnsiX99,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-customMacInformation_workMode_AnsiX99',
                  },
                  {
                    kData: FullIntegrationMacWorkMode.HypercomFastMode,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-customMacInformation_workMode_HypercomFastMode',
                  },
                  {
                    kData: FullIntegrationMacWorkMode.AnsiX919,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-customMacInformation_workMode_AnsiX919',
                  },
                  {
                    kData: FullIntegrationMacWorkMode.Sha1,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-customMacInformation_workMode_Sha1',
                  },
                  {
                    kData: FullIntegrationMacWorkMode.Sha256,
                    kID: 'FullIntegration_Request_InputAccountWithEmvRequest-customMacInformation_workMode_Sha256',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'keySlot',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-customMacInformation_keySlot',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'data',
                kValue: ' ',
                kID: 'FullIntegration_Request_InputAccountWithEmvRequest-customMacInformation_data',
                kType: DataItemType.StringList,
                kShow: true,
              },
           ];
  }

  static FullIntegrationInputAccountWithEmvRequest formInputAccountWithEmvRequest(List<Map> list) {
    List<Map> queryList = [];
    queryList.addAll(list);
    FullIntegrationInputAccountWithEmvRequest req = FullIntegrationInputAccountWithEmvRequest();
    req.edcType = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-edcType',queryList);
    req.transactionType = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-transactionType',queryList);
    req.amountInformation = FullIntegrationAmountRequest();
    req.amountInformation!.transactionAmount = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-amountInformation_transactionAmount',queryList);
    req.amountInformation!.tipAmount = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-amountInformation_tipAmount',queryList);
    req.amountInformation!.cashBackAmount = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-amountInformation_cashBackAmount',queryList);
    req.amountInformation!.merchantFee = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-amountInformation_merchantFee',queryList);
    req.amountInformation!.taxAmount = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-amountInformation_taxAmount',queryList);
    req.amountInformation!.fuelAmount = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-amountInformation_fuelAmount',queryList);
    req.amountInformation!.serviceFee = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-amountInformation_serviceFee',queryList);
    req.amountInformation!.originalAmount = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-amountInformation_originalAmount',queryList);
    req.magneticSwipePinpadEnableFlag = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-magneticSwipePinpadEnableFlag',queryList);
    req.magneticSwipePinpadTypeFlag = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-magneticSwipePinpadTypeFlag',queryList);
    req.manualPinpadEnableFlag = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-manualPinpadEnableFlag',queryList);
    req.contactlessPinpadEnableFlag = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-contactlessPinpadEnableFlag',queryList);
    req.contactlessPinpadTypeFlag = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-contactlessPinpadTypeFlag',queryList);
    req.contactEmvPinpadEnableFlag = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-contactEmvPinpadEnableFlag',queryList);
    req.contactEmvPinpadTypeFlag = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-contactEmvPinpadTypeFlag',queryList);
    req.fallbackSwipePinpadEnableFlag = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-fallbackSwipePinpadEnableFlag',queryList);
    req.laserScannerFlag = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-laserScannerFlag',queryList);
    req.frontCameraFlag = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-frontCameraFlag',queryList);
    req.rearCameraFlag = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-rearCameraFlag',queryList);
    req.additionalPrompts = FullIntegrationAdditionalPrompts();
    req.additionalPrompts!.expiryDatePrompt = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-additionalPrompts_expiryDatePrompt',queryList);
    req.additionalPrompts!.cvvPrompt = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-additionalPrompts_cvvPrompt',queryList);
    req.additionalPrompts!.zipCodePrompt = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-additionalPrompts_zipCodePrompt',queryList);
    req.encryptionFlag = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-encryptionFlag',queryList);
    req.keySlot = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-keySlot',queryList);
    req.paddingChar = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-paddingChar',queryList);
    req.trackDataSentinel = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-trackDataSentinel',queryList);
    req.minAccountLength = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-minAccountLength',queryList);
    req.maxAccountLength = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-maxAccountLength',queryList);
    req.terminalConfiguration = FullIntegrationTerminalConfiguration();
    req.terminalConfiguration!.emvKernelConfigurationSelection = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-terminalConfiguration_emvKernelConfigurationSelection',queryList);
    req.terminalConfiguration!.transactionDate = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-terminalConfiguration_transactionDate',queryList);
    req.terminalConfiguration!.transactionTime = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-terminalConfiguration_transactionTime',queryList);
    req.terminalConfiguration!.currencyCode = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-terminalConfiguration_currencyCode',queryList);
    req.terminalConfiguration!.currencyExponent = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-terminalConfiguration_currencyExponent',queryList);
    req.terminalConfiguration!.merchantCategoryCode = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-terminalConfiguration_merchantCategoryCode',queryList);
    req.terminalConfiguration!.transactionSequenceNumber = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-terminalConfiguration_transactionSequenceNumber',queryList);
    req.terminalConfiguration!.transactionCvmLimit = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-terminalConfiguration_transactionCvmLimit',queryList);
    req.tagList = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-tagList',queryList);
    req.timeout = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-timeout',queryList);
    req.statusReportFlag = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-statusReportFlag',queryList);
    req.continuousScreen = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-continuousScreen',queryList);
    req.fallbackInsertPinpadEnableFlag = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-fallbackInsertPinpadEnableFlag',queryList);
    req.ksnFlag = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-ksnFlag',queryList);
    req.customData = ListStringQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-customData',queryList);
    req.fallbackToManualPinpadEnableFlag = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-fallbackToManualPinpadEnableFlag',queryList);
    req.customMacInformation = FullIntegrationCustomMacInformationRequest();
    req.customMacInformation!.keyType = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-customMacInformation_keyType',queryList);
    req.customMacInformation!.workMode = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-customMacInformation_workMode',queryList);
    req.customMacInformation!.keySlot = RequestListModelQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-customMacInformation_keySlot',queryList);
    req.customMacInformation!.data = ListStringQuery.query('FullIntegration_Request_InputAccountWithEmvRequest-customMacInformation_data',queryList);
    return req;
  }

  static List<Map> completeOnlineEmvData() {
      return [
              {
                kEnable: true,
                kLevel: 1,
                kName: 'FullIntegrationCommand',
                kID: 'FullIntegrationCommand',
                kMenuID: 'FullIntegrationCommand_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationCommand.GetEmvTlvDataRequest,
                kData: [
                  {
                    kData: FullIntegrationCommand.GetEmvTlvDataRequest,
                    kID: 'FullIntegrationCommand_GetEmvTlvDataRequest',
                  },
                  {
                    kData: FullIntegrationCommand.InputAccountWithEmvRequest,
                    kID: 'FullIntegrationCommand_InputAccountWithEmvRequest',
                  },
                  {
                    kData: FullIntegrationCommand.CompleteOnlineEmvRequest,
                    kID: 'FullIntegrationCommand_CompleteOnlineEmvRequest',
                  },
                  {
                    kData: FullIntegrationCommand.AuthorizeCardRequest,
                    kID: 'FullIntegrationCommand_AuthorizeCardRequest',
                  },
                  {
                    kData: FullIntegrationCommand.GetPinBlockRequest,
                    kID: 'FullIntegrationCommand_GetPinBlockRequest',
                  },
                  {
                    kData: FullIntegrationCommand.SetEmvTlvDataRequest,
                    kID: 'FullIntegrationCommand_SetEmvTlvDataRequest',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'onlineAuthorizationResult',
                kID: 'FullIntegration_Request_CompleteOnlineEmvRequest-onlineAuthorizationResult',
                kMenuID: 'FullIntegration_Request_CompleteOnlineEmvRequest-onlineAuthorizationResult_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationOnlineAuthorizationResult.NotSet,
                kData: [
                  {
                    kData: FullIntegrationOnlineAuthorizationResult.NotSet,
                    kID: 'FullIntegration_Request_CompleteOnlineEmvRequest-onlineAuthorizationResult_NotSet',
                  },
                  {
                    kData: FullIntegrationOnlineAuthorizationResult.TransactionApprovedOnline,
                    kID: 'FullIntegration_Request_CompleteOnlineEmvRequest-onlineAuthorizationResult_TransactionApprovedOnline',
                  },
                  {
                    kData: FullIntegrationOnlineAuthorizationResult.TransactionDeclinedOnline,
                    kID: 'FullIntegration_Request_CompleteOnlineEmvRequest-onlineAuthorizationResult_TransactionDeclinedOnline',
                  },
                  {
                    kData: FullIntegrationOnlineAuthorizationResult.ConnectHostFailed,
                    kID: 'FullIntegration_Request_CompleteOnlineEmvRequest-onlineAuthorizationResult_ConnectHostFailed',
                  },
                  {
                    kData: FullIntegrationOnlineAuthorizationResult.RequestPartialEmv,
                    kID: 'FullIntegration_Request_CompleteOnlineEmvRequest-onlineAuthorizationResult_RequestPartialEmv',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'responseCode',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'FullIntegration_Request_CompleteOnlineEmvRequest-responseCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'authorizationCode',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'FullIntegration_Request_CompleteOnlineEmvRequest-authorizationCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'issuerAuthenticationData',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'FullIntegration_Request_CompleteOnlineEmvRequest-issuerAuthenticationData',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'issuerScript1',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'FullIntegration_Request_CompleteOnlineEmvRequest-issuerScript1',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'issuerScript2',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'FullIntegration_Request_CompleteOnlineEmvRequest-issuerScript2',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'tagList',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'FullIntegration_Request_CompleteOnlineEmvRequest-tagList',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'continuousScreen',
                kID: 'FullIntegration_Request_CompleteOnlineEmvRequest-continuousScreen',
                kMenuID: 'FullIntegration_Request_CompleteOnlineEmvRequest-continuousScreen_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationContinuousScreen.NotSet,
                kData: [
                  {
                    kData: FullIntegrationContinuousScreen.NotSet,
                    kID: 'FullIntegration_Request_CompleteOnlineEmvRequest-continuousScreen_NotSet',
                  },
                  {
                    kData: FullIntegrationContinuousScreen.Default,
                    kID: 'FullIntegration_Request_CompleteOnlineEmvRequest-continuousScreen_Default',
                  },
                  {
                    kData: FullIntegrationContinuousScreen.NotGoToIdleScreen,
                    kID: 'FullIntegration_Request_CompleteOnlineEmvRequest-continuousScreen_NotGoToIdleScreen',
                  },
                ],
              },
           ];
  }

  static FullIntegrationCompleteOnlineEmvRequest formCompleteOnlineEmvRequest(List<Map> list) {
    List<Map> queryList = [];
    queryList.addAll(list);
    FullIntegrationCompleteOnlineEmvRequest req = FullIntegrationCompleteOnlineEmvRequest();
    req.onlineAuthorizationResult = RequestListModelQuery.query('FullIntegration_Request_CompleteOnlineEmvRequest-onlineAuthorizationResult',queryList);
    req.responseCode = RequestListModelQuery.query('FullIntegration_Request_CompleteOnlineEmvRequest-responseCode',queryList);
    req.authorizationCode = RequestListModelQuery.query('FullIntegration_Request_CompleteOnlineEmvRequest-authorizationCode',queryList);
    req.issuerAuthenticationData = RequestListModelQuery.query('FullIntegration_Request_CompleteOnlineEmvRequest-issuerAuthenticationData',queryList);
    req.issuerScript1 = RequestListModelQuery.query('FullIntegration_Request_CompleteOnlineEmvRequest-issuerScript1',queryList);
    req.issuerScript2 = RequestListModelQuery.query('FullIntegration_Request_CompleteOnlineEmvRequest-issuerScript2',queryList);
    req.tagList = RequestListModelQuery.query('FullIntegration_Request_CompleteOnlineEmvRequest-tagList',queryList);
    req.continuousScreen = RequestListModelQuery.query('FullIntegration_Request_CompleteOnlineEmvRequest-continuousScreen',queryList);
    return req;
  }

  static List<Map> authorizeCardData() {
      return [
              {
                kEnable: true,
                kLevel: 1,
                kName: 'FullIntegrationCommand',
                kID: 'FullIntegrationCommand',
                kMenuID: 'FullIntegrationCommand_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationCommand.GetEmvTlvDataRequest,
                kData: [
                  {
                    kData: FullIntegrationCommand.GetEmvTlvDataRequest,
                    kID: 'FullIntegrationCommand_GetEmvTlvDataRequest',
                  },
                  {
                    kData: FullIntegrationCommand.InputAccountWithEmvRequest,
                    kID: 'FullIntegrationCommand_InputAccountWithEmvRequest',
                  },
                  {
                    kData: FullIntegrationCommand.CompleteOnlineEmvRequest,
                    kID: 'FullIntegrationCommand_CompleteOnlineEmvRequest',
                  },
                  {
                    kData: FullIntegrationCommand.AuthorizeCardRequest,
                    kID: 'FullIntegrationCommand_AuthorizeCardRequest',
                  },
                  {
                    kData: FullIntegrationCommand.GetPinBlockRequest,
                    kID: 'FullIntegrationCommand_GetPinBlockRequest',
                  },
                  {
                    kData: FullIntegrationCommand.SetEmvTlvDataRequest,
                    kID: 'FullIntegrationCommand_SetEmvTlvDataRequest',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kGroupArrowOpen: true,
                kName: 'amountInformation',
                kValue: '',
                kID: 'FullIntegration_Request_AuthorizeCardRequest-amountInformation',
                kType: DataItemType.Group,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'transactionAmount',
                kValue: '100',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'FullIntegration_Request_AuthorizeCardRequest-amountInformation_transactionAmount',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'tipAmount',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'FullIntegration_Request_AuthorizeCardRequest-amountInformation_tipAmount',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'cashBackAmount',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'FullIntegration_Request_AuthorizeCardRequest-amountInformation_cashBackAmount',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'merchantFee',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'FullIntegration_Request_AuthorizeCardRequest-amountInformation_merchantFee',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'taxAmount',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'FullIntegration_Request_AuthorizeCardRequest-amountInformation_taxAmount',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'fuelAmount',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'FullIntegration_Request_AuthorizeCardRequest-amountInformation_fuelAmount',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'serviceFee',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'FullIntegration_Request_AuthorizeCardRequest-amountInformation_serviceFee',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'originalAmount',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'FullIntegration_Request_AuthorizeCardRequest-amountInformation_originalAmount',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'merchantDecision',
                kID: 'FullIntegration_Request_AuthorizeCardRequest-merchantDecision',
                kMenuID: 'FullIntegration_Request_AuthorizeCardRequest-merchantDecision_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationMerchantDecision.NotSet,
                kData: [
                  {
                    kData: FullIntegrationMerchantDecision.NotSet,
                    kID: 'FullIntegration_Request_AuthorizeCardRequest-merchantDecision_NotSet',
                  },
                  {
                    kData: FullIntegrationMerchantDecision.NoMerchantDecision,
                    kID: 'FullIntegration_Request_AuthorizeCardRequest-merchantDecision_NoMerchantDecision',
                  },
                  {
                    kData: FullIntegrationMerchantDecision.ForceOnline,
                    kID: 'FullIntegration_Request_AuthorizeCardRequest-merchantDecision_ForceOnline',
                  },
                  {
                    kData: FullIntegrationMerchantDecision.ForceDecline,
                    kID: 'FullIntegration_Request_AuthorizeCardRequest-merchantDecision_ForceDecline',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'pinEncryptionType',
                kID: 'FullIntegration_Request_AuthorizeCardRequest-pinEncryptionType',
                kMenuID: 'FullIntegration_Request_AuthorizeCardRequest-pinEncryptionType_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationEncryptionType.DesDukpt,
                kData: [
                  {
                    kData: FullIntegrationEncryptionType.NotSet,
                    kID: 'FullIntegration_Request_AuthorizeCardRequest-pinEncryptionType_NotSet',
                  },
                  {
                    kData: FullIntegrationEncryptionType.DesDukpt,
                    kID: 'FullIntegration_Request_AuthorizeCardRequest-pinEncryptionType_DesDukpt',
                  },
                  {
                    kData: FullIntegrationEncryptionType.MasterSession,
                    kID: 'FullIntegration_Request_AuthorizeCardRequest-pinEncryptionType_MasterSession',
                  },
                  {
                    kData: FullIntegrationEncryptionType.AesDukpt,
                    kID: 'FullIntegration_Request_AuthorizeCardRequest-pinEncryptionType_AesDukpt',
                  },
                  {
                    kData: FullIntegrationEncryptionType.Aes192Dukpt,
                    kID: 'FullIntegration_Request_AuthorizeCardRequest-pinEncryptionType_Aes192Dukpt',
                  },
                  {
                    kData: FullIntegrationEncryptionType.Aes256Dukpt,
                    kID: 'FullIntegration_Request_AuthorizeCardRequest-pinEncryptionType_Aes256Dukpt',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'pinKeySlot',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'FullIntegration_Request_AuthorizeCardRequest-pinKeySlot',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'pinMinLength',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'FullIntegration_Request_AuthorizeCardRequest-pinMinLength',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'pinMaxLength',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'FullIntegration_Request_AuthorizeCardRequest-pinMaxLength',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'pinBypass',
                kID: 'FullIntegration_Request_AuthorizeCardRequest-pinBypass',
                kMenuID: 'FullIntegration_Request_AuthorizeCardRequest-pinBypass_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationPinBypass.NotSet,
                kData: [
                  {
                    kData: FullIntegrationPinBypass.NotSet,
                    kID: 'FullIntegration_Request_AuthorizeCardRequest-pinBypass_NotSet',
                  },
                  {
                    kData: FullIntegrationPinBypass.NotAllowPinBypass,
                    kID: 'FullIntegration_Request_AuthorizeCardRequest-pinBypass_NotAllowPinBypass',
                  },
                  {
                    kData: FullIntegrationPinBypass.BypassOfflinePinAutomatically,
                    kID: 'FullIntegration_Request_AuthorizeCardRequest-pinBypass_BypassOfflinePinAutomatically',
                  },
                  {
                    kData: FullIntegrationPinBypass.BypassOnlinePinAutomatically,
                    kID: 'FullIntegration_Request_AuthorizeCardRequest-pinBypass_BypassOnlinePinAutomatically',
                  },
                  {
                    kData: FullIntegrationPinBypass.BothOfflineAndOnlineAutomatically,
                    kID: 'FullIntegration_Request_AuthorizeCardRequest-pinBypass_BothOfflineAndOnlineAutomatically',
                  },
                  {
                    kData: FullIntegrationPinBypass.AllowUserToBypass,
                    kID: 'FullIntegration_Request_AuthorizeCardRequest-pinBypass_AllowUserToBypass',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'pinAlgorithm',
                kID: 'FullIntegration_Request_AuthorizeCardRequest-pinAlgorithm',
                kMenuID: 'FullIntegration_Request_AuthorizeCardRequest-pinAlgorithm_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationPinAlgorithm.NotSet,
                kData: [
                  {
                    kData: FullIntegrationPinAlgorithm.NotSet,
                    kID: 'FullIntegration_Request_AuthorizeCardRequest-pinAlgorithm_NotSet',
                  },
                  {
                    kData: FullIntegrationPinAlgorithm.Iso9564_0,
                    kID: 'FullIntegration_Request_AuthorizeCardRequest-pinAlgorithm_Iso9564_0',
                  },
                  {
                    kData: FullIntegrationPinAlgorithm.Iso9564_1,
                    kID: 'FullIntegration_Request_AuthorizeCardRequest-pinAlgorithm_Iso9564_1',
                  },
                  {
                    kData: FullIntegrationPinAlgorithm.Iso9564_3,
                    kID: 'FullIntegration_Request_AuthorizeCardRequest-pinAlgorithm_Iso9564_3',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kGroupArrowOpen: true,
                kName: 'terminalConfiguration',
                kValue: '',
                kID: 'FullIntegration_Request_AuthorizeCardRequest-terminalConfiguration',
                kType: DataItemType.Group,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'emvKernelConfigurationSelection',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'FullIntegration_Request_AuthorizeCardRequest-terminalConfiguration_emvKernelConfigurationSelection',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'transactionDate',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'FullIntegration_Request_AuthorizeCardRequest-terminalConfiguration_transactionDate',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'transactionTime',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'FullIntegration_Request_AuthorizeCardRequest-terminalConfiguration_transactionTime',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'currencyCode',
                kValue: '840',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'FullIntegration_Request_AuthorizeCardRequest-terminalConfiguration_currencyCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'currencyExponent',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'FullIntegration_Request_AuthorizeCardRequest-terminalConfiguration_currencyExponent',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'merchantCategoryCode',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'FullIntegration_Request_AuthorizeCardRequest-terminalConfiguration_merchantCategoryCode',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'transactionSequenceNumber',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'FullIntegration_Request_AuthorizeCardRequest-terminalConfiguration_transactionSequenceNumber',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'transactionCvmLimit',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'FullIntegration_Request_AuthorizeCardRequest-terminalConfiguration_transactionCvmLimit',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'tagList',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'FullIntegration_Request_AuthorizeCardRequest-tagList',
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
                kID: 'FullIntegration_Request_AuthorizeCardRequest-timeout',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'continuousScreen',
                kID: 'FullIntegration_Request_AuthorizeCardRequest-continuousScreen',
                kMenuID: 'FullIntegration_Request_AuthorizeCardRequest-continuousScreen_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationContinuousScreen.NotSet,
                kData: [
                  {
                    kData: FullIntegrationContinuousScreen.NotSet,
                    kID: 'FullIntegration_Request_AuthorizeCardRequest-continuousScreen_NotSet',
                  },
                  {
                    kData: FullIntegrationContinuousScreen.Default,
                    kID: 'FullIntegration_Request_AuthorizeCardRequest-continuousScreen_Default',
                  },
                  {
                    kData: FullIntegrationContinuousScreen.NotGoToIdleScreen,
                    kID: 'FullIntegration_Request_AuthorizeCardRequest-continuousScreen_NotGoToIdleScreen',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'pinpadType',
                kID: 'FullIntegration_Request_AuthorizeCardRequest-pinpadType',
                kMenuID: 'FullIntegration_Request_AuthorizeCardRequest-pinpadType_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationPinpadType.NotSet,
                kData: [
                  {
                    kData: FullIntegrationPinpadType.NotSet,
                    kID: 'FullIntegration_Request_AuthorizeCardRequest-pinpadType_NotSet',
                  },
                  {
                    kData: FullIntegrationPinpadType.InternalPinpad,
                    kID: 'FullIntegration_Request_AuthorizeCardRequest-pinpadType_InternalPinpad',
                  },
                  {
                    kData: FullIntegrationPinpadType.ExternalPinpad,
                    kID: 'FullIntegration_Request_AuthorizeCardRequest-pinpadType_ExternalPinpad',
                  },
                  {
                    kData: FullIntegrationPinpadType.RnibPinpad,
                    kID: 'FullIntegration_Request_AuthorizeCardRequest-pinpadType_RnibPinpad',
                  },
                  {
                    kData: FullIntegrationPinpadType.ExternalPinpadFirst,
                    kID: 'FullIntegration_Request_AuthorizeCardRequest-pinpadType_ExternalPinpadFirst',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'ksnFlag',
                kID: 'FullIntegration_Request_AuthorizeCardRequest-ksnFlag',
                kMenuID: 'FullIntegration_Request_AuthorizeCardRequest-ksnFlag_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationKsnFlag.NotSet,
                kData: [
                  {
                    kData: FullIntegrationKsnFlag.NotSet,
                    kID: 'FullIntegration_Request_AuthorizeCardRequest-ksnFlag_NotSet',
                  },
                  {
                    kData: FullIntegrationKsnFlag.NotIncrease,
                    kID: 'FullIntegration_Request_AuthorizeCardRequest-ksnFlag_NotIncrease',
                  },
                  {
                    kData: FullIntegrationKsnFlag.Increase,
                    kID: 'FullIntegration_Request_AuthorizeCardRequest-ksnFlag_Increase',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'title',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'FullIntegration_Request_AuthorizeCardRequest-title',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

  static FullIntegrationAuthorizeCardRequest formAuthorizeCardRequest(List<Map> list) {
    List<Map> queryList = [];
    queryList.addAll(list);
    FullIntegrationAuthorizeCardRequest req = FullIntegrationAuthorizeCardRequest();
    req.amountInformation = FullIntegrationAmountRequest();
    req.amountInformation!.transactionAmount = RequestListModelQuery.query('FullIntegration_Request_AuthorizeCardRequest-amountInformation_transactionAmount',queryList);
    req.amountInformation!.tipAmount = RequestListModelQuery.query('FullIntegration_Request_AuthorizeCardRequest-amountInformation_tipAmount',queryList);
    req.amountInformation!.cashBackAmount = RequestListModelQuery.query('FullIntegration_Request_AuthorizeCardRequest-amountInformation_cashBackAmount',queryList);
    req.amountInformation!.merchantFee = RequestListModelQuery.query('FullIntegration_Request_AuthorizeCardRequest-amountInformation_merchantFee',queryList);
    req.amountInformation!.taxAmount = RequestListModelQuery.query('FullIntegration_Request_AuthorizeCardRequest-amountInformation_taxAmount',queryList);
    req.amountInformation!.fuelAmount = RequestListModelQuery.query('FullIntegration_Request_AuthorizeCardRequest-amountInformation_fuelAmount',queryList);
    req.amountInformation!.serviceFee = RequestListModelQuery.query('FullIntegration_Request_AuthorizeCardRequest-amountInformation_serviceFee',queryList);
    req.amountInformation!.originalAmount = RequestListModelQuery.query('FullIntegration_Request_AuthorizeCardRequest-amountInformation_originalAmount',queryList);
    req.merchantDecision = RequestListModelQuery.query('FullIntegration_Request_AuthorizeCardRequest-merchantDecision',queryList);
    req.pinEncryptionType = RequestListModelQuery.query('FullIntegration_Request_AuthorizeCardRequest-pinEncryptionType',queryList);
    req.pinKeySlot = RequestListModelQuery.query('FullIntegration_Request_AuthorizeCardRequest-pinKeySlot',queryList);
    req.pinMinLength = RequestListModelQuery.query('FullIntegration_Request_AuthorizeCardRequest-pinMinLength',queryList);
    req.pinMaxLength = RequestListModelQuery.query('FullIntegration_Request_AuthorizeCardRequest-pinMaxLength',queryList);
    req.pinBypass = RequestListModelQuery.query('FullIntegration_Request_AuthorizeCardRequest-pinBypass',queryList);
    req.pinAlgorithm = RequestListModelQuery.query('FullIntegration_Request_AuthorizeCardRequest-pinAlgorithm',queryList);
    req.terminalConfiguration = FullIntegrationTerminalConfiguration();
    req.terminalConfiguration!.emvKernelConfigurationSelection = RequestListModelQuery.query('FullIntegration_Request_AuthorizeCardRequest-terminalConfiguration_emvKernelConfigurationSelection',queryList);
    req.terminalConfiguration!.transactionDate = RequestListModelQuery.query('FullIntegration_Request_AuthorizeCardRequest-terminalConfiguration_transactionDate',queryList);
    req.terminalConfiguration!.transactionTime = RequestListModelQuery.query('FullIntegration_Request_AuthorizeCardRequest-terminalConfiguration_transactionTime',queryList);
    req.terminalConfiguration!.currencyCode = RequestListModelQuery.query('FullIntegration_Request_AuthorizeCardRequest-terminalConfiguration_currencyCode',queryList);
    req.terminalConfiguration!.currencyExponent = RequestListModelQuery.query('FullIntegration_Request_AuthorizeCardRequest-terminalConfiguration_currencyExponent',queryList);
    req.terminalConfiguration!.merchantCategoryCode = RequestListModelQuery.query('FullIntegration_Request_AuthorizeCardRequest-terminalConfiguration_merchantCategoryCode',queryList);
    req.terminalConfiguration!.transactionSequenceNumber = RequestListModelQuery.query('FullIntegration_Request_AuthorizeCardRequest-terminalConfiguration_transactionSequenceNumber',queryList);
    req.terminalConfiguration!.transactionCvmLimit = RequestListModelQuery.query('FullIntegration_Request_AuthorizeCardRequest-terminalConfiguration_transactionCvmLimit',queryList);
    req.tagList = RequestListModelQuery.query('FullIntegration_Request_AuthorizeCardRequest-tagList',queryList);
    req.timeout = RequestListModelQuery.query('FullIntegration_Request_AuthorizeCardRequest-timeout',queryList);
    req.continuousScreen = RequestListModelQuery.query('FullIntegration_Request_AuthorizeCardRequest-continuousScreen',queryList);
    req.pinpadType = RequestListModelQuery.query('FullIntegration_Request_AuthorizeCardRequest-pinpadType',queryList);
    req.ksnFlag = RequestListModelQuery.query('FullIntegration_Request_AuthorizeCardRequest-ksnFlag',queryList);
    req.title = RequestListModelQuery.query('FullIntegration_Request_AuthorizeCardRequest-title',queryList);
    return req;
  }

  static List<Map> getPinBlockData() {
      return [
              {
                kEnable: true,
                kLevel: 1,
                kName: 'FullIntegrationCommand',
                kID: 'FullIntegrationCommand',
                kMenuID: 'FullIntegrationCommand_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationCommand.GetEmvTlvDataRequest,
                kData: [
                  {
                    kData: FullIntegrationCommand.GetEmvTlvDataRequest,
                    kID: 'FullIntegrationCommand_GetEmvTlvDataRequest',
                  },
                  {
                    kData: FullIntegrationCommand.InputAccountWithEmvRequest,
                    kID: 'FullIntegrationCommand_InputAccountWithEmvRequest',
                  },
                  {
                    kData: FullIntegrationCommand.CompleteOnlineEmvRequest,
                    kID: 'FullIntegrationCommand_CompleteOnlineEmvRequest',
                  },
                  {
                    kData: FullIntegrationCommand.AuthorizeCardRequest,
                    kID: 'FullIntegrationCommand_AuthorizeCardRequest',
                  },
                  {
                    kData: FullIntegrationCommand.GetPinBlockRequest,
                    kID: 'FullIntegrationCommand_GetPinBlockRequest',
                  },
                  {
                    kData: FullIntegrationCommand.SetEmvTlvDataRequest,
                    kID: 'FullIntegrationCommand_SetEmvTlvDataRequest',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'accountNumber',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'FullIntegration_Request_GetPinBlockRequest-accountNumber',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'encryptionType',
                kID: 'FullIntegration_Request_GetPinBlockRequest-encryptionType',
                kMenuID: 'FullIntegration_Request_GetPinBlockRequest-encryptionType_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationEncryptionType.DesDukpt,
                kData: [
                  {
                    kData: FullIntegrationEncryptionType.NotSet,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-encryptionType_NotSet',
                  },
                  {
                    kData: FullIntegrationEncryptionType.DesDukpt,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-encryptionType_DesDukpt',
                  },
                  {
                    kData: FullIntegrationEncryptionType.MasterSession,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-encryptionType_MasterSession',
                  },
                  {
                    kData: FullIntegrationEncryptionType.AesDukpt,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-encryptionType_AesDukpt',
                  },
                  {
                    kData: FullIntegrationEncryptionType.Aes192Dukpt,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-encryptionType_Aes192Dukpt',
                  },
                  {
                    kData: FullIntegrationEncryptionType.Aes256Dukpt,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-encryptionType_Aes256Dukpt',
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
                kID: 'FullIntegration_Request_GetPinBlockRequest-keySlot',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'pinMinLength',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'FullIntegration_Request_GetPinBlockRequest-pinMinLength',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'pinMaxLength',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'FullIntegration_Request_GetPinBlockRequest-pinMaxLength',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'allowOnlinePinBypass',
                kID: 'FullIntegration_Request_GetPinBlockRequest-allowOnlinePinBypass',
                kMenuID: 'FullIntegration_Request_GetPinBlockRequest-allowOnlinePinBypass_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationAllowOnlinePinBypass.NotSet,
                kData: [
                  {
                    kData: FullIntegrationAllowOnlinePinBypass.NotSet,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-allowOnlinePinBypass_NotSet',
                  },
                  {
                    kData: FullIntegrationAllowOnlinePinBypass.Yes,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-allowOnlinePinBypass_Yes',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'pinAlgorithm',
                kID: 'FullIntegration_Request_GetPinBlockRequest-pinAlgorithm',
                kMenuID: 'FullIntegration_Request_GetPinBlockRequest-pinAlgorithm_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationPinAlgorithm.NotSet,
                kData: [
                  {
                    kData: FullIntegrationPinAlgorithm.NotSet,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-pinAlgorithm_NotSet',
                  },
                  {
                    kData: FullIntegrationPinAlgorithm.Iso9564_0,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-pinAlgorithm_Iso9564_0',
                  },
                  {
                    kData: FullIntegrationPinAlgorithm.Iso9564_1,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-pinAlgorithm_Iso9564_1',
                  },
                  {
                    kData: FullIntegrationPinAlgorithm.Iso9564_3,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-pinAlgorithm_Iso9564_3',
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
                kID: 'FullIntegration_Request_GetPinBlockRequest-timeout',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'edcType',
                kID: 'FullIntegration_Request_GetPinBlockRequest-edcType',
                kMenuID: 'FullIntegration_Request_GetPinBlockRequest-edcType_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationEdcType.NotSet,
                kData: [
                  {
                    kData: FullIntegrationEdcType.NotSet,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-edcType_NotSet',
                  },
                  {
                    kData: FullIntegrationEdcType.All,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-edcType_All',
                  },
                  {
                    kData: FullIntegrationEdcType.Credit,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-edcType_Credit',
                  },
                  {
                    kData: FullIntegrationEdcType.Debit,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-edcType_Debit',
                  },
                  {
                    kData: FullIntegrationEdcType.Ebt,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-edcType_Ebt',
                  },
                  {
                    kData: FullIntegrationEdcType.Gift,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-edcType_Gift',
                  },
                  {
                    kData: FullIntegrationEdcType.Loyalty,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-edcType_Loyalty',
                  },
                  {
                    kData: FullIntegrationEdcType.Cash,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-edcType_Cash',
                  },
                  {
                    kData: FullIntegrationEdcType.QrPayment,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-edcType_QrPayment',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'transactionType',
                kID: 'FullIntegration_Request_GetPinBlockRequest-transactionType',
                kMenuID: 'FullIntegration_Request_GetPinBlockRequest-transactionType_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationTransactionType.NotSet,
                kData: [
                  {
                    kData: FullIntegrationTransactionType.NotSet,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-transactionType_NotSet',
                  },
                  {
                    kData: FullIntegrationTransactionType.Unknown,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-transactionType_Unknown',
                  },
                  {
                    kData: FullIntegrationTransactionType.Sale,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-transactionType_Sale',
                  },
                  {
                    kData: FullIntegrationTransactionType.Return,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-transactionType_Return',
                  },
                  {
                    kData: FullIntegrationTransactionType.Authorization,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-transactionType_Authorization',
                  },
                  {
                    kData: FullIntegrationTransactionType.PostAuthorization,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-transactionType_PostAuthorization',
                  },
                  {
                    kData: FullIntegrationTransactionType.ForceAuthorization,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-transactionType_ForceAuthorization',
                  },
                  {
                    kData: FullIntegrationTransactionType.Adjust,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-transactionType_Adjust',
                  },
                  {
                    kData: FullIntegrationTransactionType.Withdrawal,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-transactionType_Withdrawal',
                  },
                  {
                    kData: FullIntegrationTransactionType.Activate,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-transactionType_Activate',
                  },
                  {
                    kData: FullIntegrationTransactionType.Issue,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-transactionType_Issue',
                  },
                  {
                    kData: FullIntegrationTransactionType.Reload,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-transactionType_Reload',
                  },
                  {
                    kData: FullIntegrationTransactionType.Cashout,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-transactionType_Cashout',
                  },
                  {
                    kData: FullIntegrationTransactionType.Deactivate,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-transactionType_Deactivate',
                  },
                  {
                    kData: FullIntegrationTransactionType.Replace,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-transactionType_Replace',
                  },
                  {
                    kData: FullIntegrationTransactionType.Merge,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-transactionType_Merge',
                  },
                  {
                    kData: FullIntegrationTransactionType.ReportLost,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-transactionType_ReportLost',
                  },
                  {
                    kData: FullIntegrationTransactionType.Void,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-transactionType_Void',
                  },
                  {
                    kData: FullIntegrationTransactionType.VoidSale,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-transactionType_VoidSale',
                  },
                  {
                    kData: FullIntegrationTransactionType.VoidReturn,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-transactionType_VoidReturn',
                  },
                  {
                    kData: FullIntegrationTransactionType.VoidAuthorization,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-transactionType_VoidAuthorization',
                  },
                  {
                    kData: FullIntegrationTransactionType.VoidPostAuthorization,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-transactionType_VoidPostAuthorization',
                  },
                  {
                    kData: FullIntegrationTransactionType.VoidForceAuthorization,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-transactionType_VoidForceAuthorization',
                  },
                  {
                    kData: FullIntegrationTransactionType.VoidWithdrawal,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-transactionType_VoidWithdrawal',
                  },
                  {
                    kData: FullIntegrationTransactionType.Inquiry,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-transactionType_Inquiry',
                  },
                  {
                    kData: FullIntegrationTransactionType.Verify,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-transactionType_Verify',
                  },
                  {
                    kData: FullIntegrationTransactionType.Reactivate,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-transactionType_Reactivate',
                  },
                  {
                    kData: FullIntegrationTransactionType.ForcedIssue,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-transactionType_ForcedIssue',
                  },
                  {
                    kData: FullIntegrationTransactionType.ForcedAdd,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-transactionType_ForcedAdd',
                  },
                  {
                    kData: FullIntegrationTransactionType.Unload,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-transactionType_Unload',
                  },
                  {
                    kData: FullIntegrationTransactionType.Renew,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-transactionType_Renew',
                  },
                  {
                    kData: FullIntegrationTransactionType.GetConvertDetail,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-transactionType_GetConvertDetail',
                  },
                  {
                    kData: FullIntegrationTransactionType.Convert,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-transactionType_Convert',
                  },
                  {
                    kData: FullIntegrationTransactionType.Tokenize,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-transactionType_Tokenize',
                  },
                  {
                    kData: FullIntegrationTransactionType.IncrementalAuthorization,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-transactionType_IncrementalAuthorization',
                  },
                  {
                    kData: FullIntegrationTransactionType.BalanceWithLock,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-transactionType_BalanceWithLock',
                  },
                  {
                    kData: FullIntegrationTransactionType.RedemptionWithUnlock,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-transactionType_RedemptionWithUnlock',
                  },
                  {
                    kData: FullIntegrationTransactionType.Rewards,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-transactionType_Rewards',
                  },
                  {
                    kData: FullIntegrationTransactionType.Reenter,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-transactionType_Reenter',
                  },
                  {
                    kData: FullIntegrationTransactionType.TransactionAdjustment,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-transactionType_TransactionAdjustment',
                  },
                  {
                    kData: FullIntegrationTransactionType.Transfer,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-transactionType_Transfer',
                  },
                  {
                    kData: FullIntegrationTransactionType.Finalize,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-transactionType_Finalize',
                  },
                  {
                    kData: FullIntegrationTransactionType.Deposit,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-transactionType_Deposit',
                  },
                  {
                    kData: FullIntegrationTransactionType.AccountPayment,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-transactionType_AccountPayment',
                  },
                  {
                    kData: FullIntegrationTransactionType.Reversal,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-transactionType_Reversal',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'title',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'FullIntegration_Request_GetPinBlockRequest-title',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'pinpadType',
                kID: 'FullIntegration_Request_GetPinBlockRequest-pinpadType',
                kMenuID: 'FullIntegration_Request_GetPinBlockRequest-pinpadType_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationPinpadType.NotSet,
                kData: [
                  {
                    kData: FullIntegrationPinpadType.NotSet,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-pinpadType_NotSet',
                  },
                  {
                    kData: FullIntegrationPinpadType.InternalPinpad,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-pinpadType_InternalPinpad',
                  },
                  {
                    kData: FullIntegrationPinpadType.ExternalPinpad,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-pinpadType_ExternalPinpad',
                  },
                  {
                    kData: FullIntegrationPinpadType.RnibPinpad,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-pinpadType_RnibPinpad',
                  },
                  {
                    kData: FullIntegrationPinpadType.ExternalPinpadFirst,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-pinpadType_ExternalPinpadFirst',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'ksnFlag',
                kID: 'FullIntegration_Request_GetPinBlockRequest-ksnFlag',
                kMenuID: 'FullIntegration_Request_GetPinBlockRequest-ksnFlag_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationKsnFlag.NotSet,
                kData: [
                  {
                    kData: FullIntegrationKsnFlag.NotSet,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-ksnFlag_NotSet',
                  },
                  {
                    kData: FullIntegrationKsnFlag.NotIncrease,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-ksnFlag_NotIncrease',
                  },
                  {
                    kData: FullIntegrationKsnFlag.Increase,
                    kID: 'FullIntegration_Request_GetPinBlockRequest-ksnFlag_Increase',
                  },
                ],
              },
           ];
  }

  static FullIntegrationGetPinBlockRequest formGetPinBlockRequest(List<Map> list) {
    List<Map> queryList = [];
    queryList.addAll(list);
    FullIntegrationGetPinBlockRequest req = FullIntegrationGetPinBlockRequest();
    req.accountNumber = RequestListModelQuery.query('FullIntegration_Request_GetPinBlockRequest-accountNumber',queryList);
    req.encryptionType = RequestListModelQuery.query('FullIntegration_Request_GetPinBlockRequest-encryptionType',queryList);
    req.keySlot = RequestListModelQuery.query('FullIntegration_Request_GetPinBlockRequest-keySlot',queryList);
    req.pinMinLength = RequestListModelQuery.query('FullIntegration_Request_GetPinBlockRequest-pinMinLength',queryList);
    req.pinMaxLength = RequestListModelQuery.query('FullIntegration_Request_GetPinBlockRequest-pinMaxLength',queryList);
    req.allowOnlinePinBypass = RequestListModelQuery.query('FullIntegration_Request_GetPinBlockRequest-allowOnlinePinBypass',queryList);
    req.pinAlgorithm = RequestListModelQuery.query('FullIntegration_Request_GetPinBlockRequest-pinAlgorithm',queryList);
    req.timeout = RequestListModelQuery.query('FullIntegration_Request_GetPinBlockRequest-timeout',queryList);
    req.edcType = RequestListModelQuery.query('FullIntegration_Request_GetPinBlockRequest-edcType',queryList);
    req.transactionType = RequestListModelQuery.query('FullIntegration_Request_GetPinBlockRequest-transactionType',queryList);
    req.title = RequestListModelQuery.query('FullIntegration_Request_GetPinBlockRequest-title',queryList);
    req.pinpadType = RequestListModelQuery.query('FullIntegration_Request_GetPinBlockRequest-pinpadType',queryList);
    req.ksnFlag = RequestListModelQuery.query('FullIntegration_Request_GetPinBlockRequest-ksnFlag',queryList);
    return req;
  }

  static List<Map> setEmvTlvDataData() {
      return [
              {
                kEnable: true,
                kLevel: 1,
                kName: 'FullIntegrationCommand',
                kID: 'FullIntegrationCommand',
                kMenuID: 'FullIntegrationCommand_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationCommand.GetEmvTlvDataRequest,
                kData: [
                  {
                    kData: FullIntegrationCommand.GetEmvTlvDataRequest,
                    kID: 'FullIntegrationCommand_GetEmvTlvDataRequest',
                  },
                  {
                    kData: FullIntegrationCommand.InputAccountWithEmvRequest,
                    kID: 'FullIntegrationCommand_InputAccountWithEmvRequest',
                  },
                  {
                    kData: FullIntegrationCommand.CompleteOnlineEmvRequest,
                    kID: 'FullIntegrationCommand_CompleteOnlineEmvRequest',
                  },
                  {
                    kData: FullIntegrationCommand.AuthorizeCardRequest,
                    kID: 'FullIntegrationCommand_AuthorizeCardRequest',
                  },
                  {
                    kData: FullIntegrationCommand.GetPinBlockRequest,
                    kID: 'FullIntegrationCommand_GetPinBlockRequest',
                  },
                  {
                    kData: FullIntegrationCommand.SetEmvTlvDataRequest,
                    kID: 'FullIntegrationCommand_SetEmvTlvDataRequest',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'tlvType',
                kID: 'FullIntegration_Request_SetEmvTlvDataRequest-tlvType',
                kMenuID: 'FullIntegration_Request_SetEmvTlvDataRequest-tlvType_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FullIntegrationTlvType.NotSet,
                kData: [
                  {
                    kData: FullIntegrationTlvType.NotSet,
                    kID: 'FullIntegration_Request_SetEmvTlvDataRequest-tlvType_NotSet',
                  },
                  {
                    kData: FullIntegrationTlvType.EmvContact,
                    kID: 'FullIntegration_Request_SetEmvTlvDataRequest-tlvType_EmvContact',
                  },
                  {
                    kData: FullIntegrationTlvType.EmvContactless,
                    kID: 'FullIntegration_Request_SetEmvTlvDataRequest-tlvType_EmvContactless',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'emvTlvData',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'FullIntegration_Request_SetEmvTlvDataRequest-emvTlvData',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

  static FullIntegrationSetEmvTlvDataRequest formSetEmvTlvDataRequest(List<Map> list) {
    List<Map> queryList = [];
    queryList.addAll(list);
    FullIntegrationSetEmvTlvDataRequest req = FullIntegrationSetEmvTlvDataRequest();
    req.tlvType = RequestListModelQuery.query('FullIntegration_Request_SetEmvTlvDataRequest-tlvType',queryList);
    req.emvTlvData = RequestListModelQuery.query('FullIntegration_Request_SetEmvTlvDataRequest-emvTlvData',queryList);
    return req;
  }

  static List<Map>? queryDataByString(String string) {
    List tempList = string.split('.');
    if (tempList.length < 2) { return null; }
    String tempStr = tempList[1];
    List<Map> list;
    switch (tempStr) {
      case 'GetEmvTlvDataRequest':
        list = FullIntegrationReqData.getEmvTlvDataData();
        break;
      case 'InputAccountWithEmvRequest':
        list = FullIntegrationReqData.inputAccountWithEmvData();
        break;
      case 'CompleteOnlineEmvRequest':
        list = FullIntegrationReqData.completeOnlineEmvData();
        break;
      case 'AuthorizeCardRequest':
        list = FullIntegrationReqData.authorizeCardData();
        break;
      case 'GetPinBlockRequest':
        list = FullIntegrationReqData.getPinBlockData();
        break;
      case 'SetEmvTlvDataRequest':
        list = FullIntegrationReqData.setEmvTlvDataData();
        break;
      default:
        list = [];
        break;
    }
    return list;
  }

}

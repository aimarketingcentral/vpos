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
class FormReqData {
  static List<Map> initSourceData() {
    return FormReqData.showMessageCenterData();
  }
  static List<Map> showMessageCenterData() {
      return [
              {
                kEnable: true,
                kLevel: 1,
                kName: 'FormCommand',
                kID: 'FormCommand',
                kMenuID: 'FormCommand_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FormCommand.ShowMessageCenterRequest,
                kData: [
                  {
                    kData: FormCommand.ShowMessageCenterRequest,
                    kID: 'FormCommand_ShowMessageCenterRequest',
                  },
                  {
                    kData: FormCommand.InputTextRequest,
                    kID: 'FormCommand_InputTextRequest',
                  },
                  {
                    kData: FormCommand.ClearMessageRequest,
                    kID: 'FormCommand_ClearMessageRequest',
                  },
                  {
                    kData: FormCommand.ShowItemRequest,
                    kID: 'FormCommand_ShowItemRequest',
                  },
                  {
                    kData: FormCommand.ShowMessageRequest,
                    kID: 'FormCommand_ShowMessageRequest',
                  },
                  {
                    kData: FormCommand.ShowDialogRequest,
                    kID: 'FormCommand_ShowDialogRequest',
                  },
                  {
                    kData: FormCommand.ShowTextBoxRequest,
                    kID: 'FormCommand_ShowTextBoxRequest',
                  },
                  {
                    kData: FormCommand.ShowDialogFormRequest,
                    kID: 'FormCommand_ShowDialogFormRequest',
                  },
                  {
                    kData: FormCommand.RemoveCardRequest,
                    kID: 'FormCommand_RemoveCardRequest',
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
                kID: 'Form_Request_ShowMessageCenterRequest-title',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'message1',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Form_Request_ShowMessageCenterRequest-message1',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'message2',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Form_Request_ShowMessageCenterRequest-message2',
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
                kID: 'Form_Request_ShowMessageCenterRequest-timeout',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'pinpadType',
                kID: 'Form_Request_ShowMessageCenterRequest-pinpadType',
                kMenuID: 'Form_Request_ShowMessageCenterRequest-pinpadType_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FormPinpadType.NotSet,
                kData: [
                  {
                    kData: FormPinpadType.NotSet,
                    kID: 'Form_Request_ShowMessageCenterRequest-pinpadType_NotSet',
                  },
                  {
                    kData: FormPinpadType.InternalPinpad,
                    kID: 'Form_Request_ShowMessageCenterRequest-pinpadType_InternalPinpad',
                  },
                  {
                    kData: FormPinpadType.ExternalPinpad,
                    kID: 'Form_Request_ShowMessageCenterRequest-pinpadType_ExternalPinpad',
                  },
                  {
                    kData: FormPinpadType.RnibPinpad,
                    kID: 'Form_Request_ShowMessageCenterRequest-pinpadType_RnibPinpad',
                  },
                  {
                    kData: FormPinpadType.ExternalPinpadFirst,
                    kID: 'Form_Request_ShowMessageCenterRequest-pinpadType_ExternalPinpadFirst',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'iconName',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Form_Request_ShowMessageCenterRequest-iconName',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

  static FormShowMessageCenterRequest formShowMessageCenterRequest(List<Map> list) {
    List<Map> queryList = [];
    queryList.addAll(list);
    FormShowMessageCenterRequest req = FormShowMessageCenterRequest();
    req.title = RequestListModelQuery.query('Form_Request_ShowMessageCenterRequest-title',queryList);
    req.message1 = RequestListModelQuery.query('Form_Request_ShowMessageCenterRequest-message1',queryList);
    req.message2 = RequestListModelQuery.query('Form_Request_ShowMessageCenterRequest-message2',queryList);
    req.timeout = RequestListModelQuery.query('Form_Request_ShowMessageCenterRequest-timeout',queryList);
    req.pinpadType = RequestListModelQuery.query('Form_Request_ShowMessageCenterRequest-pinpadType',queryList);
    req.iconName = RequestListModelQuery.query('Form_Request_ShowMessageCenterRequest-iconName',queryList);
    return req;
  }

  static List<Map> inputTextData() {
      return [
              {
                kEnable: true,
                kLevel: 1,
                kName: 'FormCommand',
                kID: 'FormCommand',
                kMenuID: 'FormCommand_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FormCommand.ShowMessageCenterRequest,
                kData: [
                  {
                    kData: FormCommand.ShowMessageCenterRequest,
                    kID: 'FormCommand_ShowMessageCenterRequest',
                  },
                  {
                    kData: FormCommand.InputTextRequest,
                    kID: 'FormCommand_InputTextRequest',
                  },
                  {
                    kData: FormCommand.ClearMessageRequest,
                    kID: 'FormCommand_ClearMessageRequest',
                  },
                  {
                    kData: FormCommand.ShowItemRequest,
                    kID: 'FormCommand_ShowItemRequest',
                  },
                  {
                    kData: FormCommand.ShowMessageRequest,
                    kID: 'FormCommand_ShowMessageRequest',
                  },
                  {
                    kData: FormCommand.ShowDialogRequest,
                    kID: 'FormCommand_ShowDialogRequest',
                  },
                  {
                    kData: FormCommand.ShowTextBoxRequest,
                    kID: 'FormCommand_ShowTextBoxRequest',
                  },
                  {
                    kData: FormCommand.ShowDialogFormRequest,
                    kID: 'FormCommand_ShowDialogFormRequest',
                  },
                  {
                    kData: FormCommand.RemoveCardRequest,
                    kID: 'FormCommand_RemoveCardRequest',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'title',
                kID: 'Form_Request_InputTextRequest-title',
                kMenuID: 'Form_Request_InputTextRequest-title_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FormInputTextPrompt.NotSet,
                kData: [
                  {
                    kData: FormInputTextPrompt.NotSet,
                    kID: 'Form_Request_InputTextRequest-title_NotSet',
                  },
                  {
                    kData: FormInputTextPrompt.EnterAmount,
                    kID: 'Form_Request_InputTextRequest-title_EnterAmount',
                  },
                  {
                    kData: FormInputTextPrompt.EnterPoints,
                    kID: 'Form_Request_InputTextRequest-title_EnterPoints',
                  },
                  {
                    kData: FormInputTextPrompt.EnterTableNumber,
                    kID: 'Form_Request_InputTextRequest-title_EnterTableNumber',
                  },
                  {
                    kData: FormInputTextPrompt.EnterTheNumberOfGuests,
                    kID: 'Form_Request_InputTextRequest-title_EnterTheNumberOfGuests',
                  },
                  {
                    kData: FormInputTextPrompt.EnterOrderNumber,
                    kID: 'Form_Request_InputTextRequest-title_EnterOrderNumber',
                  },
                  {
                    kData: FormInputTextPrompt.EnterTicketNumber,
                    kID: 'Form_Request_InputTextRequest-title_EnterTicketNumber',
                  },
                  {
                    kData: FormInputTextPrompt.EnterVoucherNumber,
                    kID: 'Form_Request_InputTextRequest-title_EnterVoucherNumber',
                  },
                  {
                    kData: FormInputTextPrompt.EnterAuthCode,
                    kID: 'Form_Request_InputTextRequest-title_EnterAuthCode',
                  },
                  {
                    kData: FormInputTextPrompt.EnterTip,
                    kID: 'Form_Request_InputTextRequest-title_EnterTip',
                  },
                  {
                    kData: FormInputTextPrompt.EnterCashBack,
                    kID: 'Form_Request_InputTextRequest-title_EnterCashBack',
                  },
                  {
                    kData: FormInputTextPrompt.EnterMerchantFee,
                    kID: 'Form_Request_InputTextRequest-title_EnterMerchantFee',
                  },
                  {
                    kData: FormInputTextPrompt.EnterSurchargeFee,
                    kID: 'Form_Request_InputTextRequest-title_EnterSurchargeFee',
                  },
                  {
                    kData: FormInputTextPrompt.EnterYourAddress,
                    kID: 'Form_Request_InputTextRequest-title_EnterYourAddress',
                  },
                  {
                    kData: FormInputTextPrompt.EnterYourZipCode,
                    kID: 'Form_Request_InputTextRequest-title_EnterYourZipCode',
                  },
                  {
                    kData: FormInputTextPrompt.EnterCustomerCode,
                    kID: 'Form_Request_InputTextRequest-title_EnterCustomerCode',
                  },
                  {
                    kData: FormInputTextPrompt.EnterPoNumber,
                    kID: 'Form_Request_InputTextRequest-title_EnterPoNumber',
                  },
                  {
                    kData: FormInputTextPrompt.EnterDestinationZip,
                    kID: 'Form_Request_InputTextRequest-title_EnterDestinationZip',
                  },
                  {
                    kData: FormInputTextPrompt.EnterProductDescription,
                    kID: 'Form_Request_InputTextRequest-title_EnterProductDescription',
                  },
                  {
                    kData: FormInputTextPrompt.EnterMerchantTaxId,
                    kID: 'Form_Request_InputTextRequest-title_EnterMerchantTaxId',
                  },
                  {
                    kData: FormInputTextPrompt.EnterTaxAmount,
                    kID: 'Form_Request_InputTextRequest-title_EnterTaxAmount',
                  },
                  {
                    kData: FormInputTextPrompt.EnterTaxExemptId,
                    kID: 'Form_Request_InputTextRequest-title_EnterTaxExemptId',
                  },
                  {
                    kData: FormInputTextPrompt.EnterReferenceNumber,
                    kID: 'Form_Request_InputTextRequest-title_EnterReferenceNumber',
                  },
                  {
                    kData: FormInputTextPrompt.EnterPhoneNumber,
                    kID: 'Form_Request_InputTextRequest-title_EnterPhoneNumber',
                  },
                  {
                    kData: FormInputTextPrompt.EnterSocialSecurity,
                    kID: 'Form_Request_InputTextRequest-title_EnterSocialSecurity',
                  },
                  {
                    kData: FormInputTextPrompt.EnterUserName,
                    kID: 'Form_Request_InputTextRequest-title_EnterUserName',
                  },
                  {
                    kData: FormInputTextPrompt.EnterCustomerServicePhone,
                    kID: 'Form_Request_InputTextRequest-title_EnterCustomerServicePhone',
                  },
                  {
                    kData: FormInputTextPrompt.EnterOriginalTransactionDate,
                    kID: 'Form_Request_InputTextRequest-title_EnterOriginalTransactionDate',
                  },
                  {
                    kData: FormInputTextPrompt.EnterOriginalTransactionTime,
                    kID: 'Form_Request_InputTextRequest-title_EnterOriginalTransactionTime',
                  },
                  {
                    kData: FormInputTextPrompt.EnterDate,
                    kID: 'Form_Request_InputTextRequest-title_EnterDate',
                  },
                  {
                    kData: FormInputTextPrompt.EnterTime,
                    kID: 'Form_Request_InputTextRequest-title_EnterTime',
                  },
                  {
                    kData: FormInputTextPrompt.EnterPassword,
                    kID: 'Form_Request_InputTextRequest-title_EnterPassword',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'inputType',
                kID: 'Form_Request_InputTextRequest-inputType',
                kMenuID: 'Form_Request_InputTextRequest-inputType_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FormInputType.NotSet,
                kData: [
                  {
                    kData: FormInputType.NotSet,
                    kID: 'Form_Request_InputTextRequest-inputType_NotSet',
                  },
                  {
                    kData: FormInputType.AlphaNumeric,
                    kID: 'Form_Request_InputTextRequest-inputType_AlphaNumeric',
                  },
                  {
                    kData: FormInputType.Numeric,
                    kID: 'Form_Request_InputTextRequest-inputType_Numeric',
                  },
                  {
                    kData: FormInputType.Date,
                    kID: 'Form_Request_InputTextRequest-inputType_Date',
                  },
                  {
                    kData: FormInputType.Time,
                    kID: 'Form_Request_InputTextRequest-inputType_Time',
                  },
                  {
                    kData: FormInputType.Currency,
                    kID: 'Form_Request_InputTextRequest-inputType_Currency',
                  },
                  {
                    kData: FormInputType.Password,
                    kID: 'Form_Request_InputTextRequest-inputType_Password',
                  },
                  {
                    kData: FormInputType.PhoneNumber,
                    kID: 'Form_Request_InputTextRequest-inputType_PhoneNumber',
                  },
                  {
                    kData: FormInputType.SocialSecurity,
                    kID: 'Form_Request_InputTextRequest-inputType_SocialSecurity',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'minLength',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'Form_Request_InputTextRequest-minLength',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'maxLength',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'Form_Request_InputTextRequest-maxLength',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'defaultValue',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Form_Request_InputTextRequest-defaultValue',
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
                kID: 'Form_Request_InputTextRequest-timeout',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'continuousScreen',
                kID: 'Form_Request_InputTextRequest-continuousScreen',
                kMenuID: 'Form_Request_InputTextRequest-continuousScreen_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FormContinuousScreen.NotSet,
                kData: [
                  {
                    kData: FormContinuousScreen.NotSet,
                    kID: 'Form_Request_InputTextRequest-continuousScreen_NotSet',
                  },
                  {
                    kData: FormContinuousScreen.Default,
                    kID: 'Form_Request_InputTextRequest-continuousScreen_Default',
                  },
                  {
                    kData: FormContinuousScreen.NotGoToIdleScreen,
                    kID: 'Form_Request_InputTextRequest-continuousScreen_NotGoToIdleScreen',
                  },
                ],
              },
           ];
  }

  static FormInputTextRequest formInputTextRequest(List<Map> list) {
    List<Map> queryList = [];
    queryList.addAll(list);
    FormInputTextRequest req = FormInputTextRequest();
    req.title = RequestListModelQuery.query('Form_Request_InputTextRequest-title',queryList);
    req.inputType = RequestListModelQuery.query('Form_Request_InputTextRequest-inputType',queryList);
    req.minLength = RequestListModelQuery.query('Form_Request_InputTextRequest-minLength',queryList);
    req.maxLength = RequestListModelQuery.query('Form_Request_InputTextRequest-maxLength',queryList);
    req.defaultValue = RequestListModelQuery.query('Form_Request_InputTextRequest-defaultValue',queryList);
    req.timeout = RequestListModelQuery.query('Form_Request_InputTextRequest-timeout',queryList);
    req.continuousScreen = RequestListModelQuery.query('Form_Request_InputTextRequest-continuousScreen',queryList);
    return req;
  }

  static List<Map> clearMessageData() {
      return [
              {
                kEnable: true,
                kLevel: 1,
                kName: 'FormCommand',
                kID: 'FormCommand',
                kMenuID: 'FormCommand_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FormCommand.ShowMessageCenterRequest,
                kData: [
                  {
                    kData: FormCommand.ShowMessageCenterRequest,
                    kID: 'FormCommand_ShowMessageCenterRequest',
                  },
                  {
                    kData: FormCommand.InputTextRequest,
                    kID: 'FormCommand_InputTextRequest',
                  },
                  {
                    kData: FormCommand.ClearMessageRequest,
                    kID: 'FormCommand_ClearMessageRequest',
                  },
                  {
                    kData: FormCommand.ShowItemRequest,
                    kID: 'FormCommand_ShowItemRequest',
                  },
                  {
                    kData: FormCommand.ShowMessageRequest,
                    kID: 'FormCommand_ShowMessageRequest',
                  },
                  {
                    kData: FormCommand.ShowDialogRequest,
                    kID: 'FormCommand_ShowDialogRequest',
                  },
                  {
                    kData: FormCommand.ShowTextBoxRequest,
                    kID: 'FormCommand_ShowTextBoxRequest',
                  },
                  {
                    kData: FormCommand.ShowDialogFormRequest,
                    kID: 'FormCommand_ShowDialogFormRequest',
                  },
                  {
                    kData: FormCommand.RemoveCardRequest,
                    kID: 'FormCommand_RemoveCardRequest',
                  },
                ],
              },
           ];
  }

  static FormClearMessageRequest formClearMessageRequest(List<Map> list) {
    List<Map> queryList = [];
    queryList.addAll(list);
    FormClearMessageRequest req = FormClearMessageRequest();
    req.classID = RequestListModelQuery.query('Form_Request_ClearMessageRequest-classID',queryList);
    return req;
  }

  static List<Map> showItemData() {
      return [
              {
                kEnable: true,
                kLevel: 1,
                kName: 'FormCommand',
                kID: 'FormCommand',
                kMenuID: 'FormCommand_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FormCommand.ShowMessageCenterRequest,
                kData: [
                  {
                    kData: FormCommand.ShowMessageCenterRequest,
                    kID: 'FormCommand_ShowMessageCenterRequest',
                  },
                  {
                    kData: FormCommand.InputTextRequest,
                    kID: 'FormCommand_InputTextRequest',
                  },
                  {
                    kData: FormCommand.ClearMessageRequest,
                    kID: 'FormCommand_ClearMessageRequest',
                  },
                  {
                    kData: FormCommand.ShowItemRequest,
                    kID: 'FormCommand_ShowItemRequest',
                  },
                  {
                    kData: FormCommand.ShowMessageRequest,
                    kID: 'FormCommand_ShowMessageRequest',
                  },
                  {
                    kData: FormCommand.ShowDialogRequest,
                    kID: 'FormCommand_ShowDialogRequest',
                  },
                  {
                    kData: FormCommand.ShowTextBoxRequest,
                    kID: 'FormCommand_ShowTextBoxRequest',
                  },
                  {
                    kData: FormCommand.ShowDialogFormRequest,
                    kID: 'FormCommand_ShowDialogFormRequest',
                  },
                  {
                    kData: FormCommand.RemoveCardRequest,
                    kID: 'FormCommand_RemoveCardRequest',
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
                kID: 'Form_Request_ShowItemRequest-title',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'textPushedMode',
                kID: 'Form_Request_ShowItemRequest-textPushedMode',
                kMenuID: 'Form_Request_ShowItemRequest-textPushedMode_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FormTextPushedMode.NotSet,
                kData: [
                  {
                    kData: FormTextPushedMode.NotSet,
                    kID: 'Form_Request_ShowItemRequest-textPushedMode_NotSet',
                  },
                  {
                    kData: FormTextPushedMode.Topdown,
                    kID: 'Form_Request_ShowItemRequest-textPushedMode_Topdown',
                  },
                  {
                    kData: FormTextPushedMode.BottomUp,
                    kID: 'Form_Request_ShowItemRequest-textPushedMode_BottomUp',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'taxLine',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Form_Request_ShowItemRequest-taxLine',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'totalLine',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Form_Request_ShowItemRequest-totalLine',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kID: 'Form_Request_ShowItemRequest-itemDetails',
                kType: DataItemType.ModelList,
                kClass: 'ItemDetail',
                kShow: true,
                kName: 'itemDetails',
                kValue: [
                  {
                    kType: DataItemType.CellInput,
                    kID: 'Form_Request_ShowItemRequest-itemDetails_productName',
                    kName: 'productName',
                  },
                  {
                    kType: DataItemType.CellInput,
                    kID: 'Form_Request_ShowItemRequest-itemDetails_pluCode',
                    kName: 'pluCode',
                  },
                  {
                    kType: DataItemType.CellInput,
                    kID: 'Form_Request_ShowItemRequest-itemDetails_price',
                    kName: 'price',
                  },
                  {
                    kType: DataItemType.Menu,
                    kID: 'Form_Request_ShowItemRequest-itemDetails_unit',
                    kName: 'unit',
                    kShow: true,
                    kLevel: 1,
                    kValue: FormItemDetailUnit.NotSet,
                    kData: [
                      {
                         kData: FormItemDetailUnit.NotSet,
                         kID: 'Form_Request_ShowItemRequest-itemDetails_unit_NotSet',
                      },
                      {
                         kData: FormItemDetailUnit.PerItem,
                         kID: 'Form_Request_ShowItemRequest-itemDetails_unit_PerItem',
                      },
                      {
                         kData: FormItemDetailUnit.PerPound,
                         kID: 'Form_Request_ShowItemRequest-itemDetails_unit_PerPound',
                      },
                      {
                         kData: FormItemDetailUnit.PerFoot,
                         kID: 'Form_Request_ShowItemRequest-itemDetails_unit_PerFoot',
                      },
                    ],
                  },
                  {
                    kType: DataItemType.CellInput,
                    kID: 'Form_Request_ShowItemRequest-itemDetails_unitPrice',
                    kName: 'unitPrice',
                  },
                  {
                    kType: DataItemType.CellInput,
                    kID: 'Form_Request_ShowItemRequest-itemDetails_tax',
                    kName: 'tax',
                  },
                  {
                    kType: DataItemType.CellInput,
                    kID: 'Form_Request_ShowItemRequest-itemDetails_quantity',
                    kName: 'quantity',
                  },
                  {
                    kType: DataItemType.CellInput,
                    kID: 'Form_Request_ShowItemRequest-itemDetails_productImageName',
                    kName: 'productImageName',
                  },
                  {
                    kType: DataItemType.CellInput,
                    kID: 'Form_Request_ShowItemRequest-itemDetails_productImageDescription',
                    kName: 'productImageDescription',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'lineItemAction',
                kID: 'Form_Request_ShowItemRequest-lineItemAction',
                kMenuID: 'Form_Request_ShowItemRequest-lineItemAction_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FormLineItemAction.NotSet,
                kData: [
                  {
                    kData: FormLineItemAction.NotSet,
                    kID: 'Form_Request_ShowItemRequest-lineItemAction_NotSet',
                  },
                  {
                    kData: FormLineItemAction.Add,
                    kID: 'Form_Request_ShowItemRequest-lineItemAction_Add',
                  },
                  {
                    kData: FormLineItemAction.Update,
                    kID: 'Form_Request_ShowItemRequest-lineItemAction_Update',
                  },
                  {
                    kData: FormLineItemAction.Delete,
                    kID: 'Form_Request_ShowItemRequest-lineItemAction_Delete',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'itemIndices',
                kValue: ' ',
                kID: 'Form_Request_ShowItemRequest-itemIndices',
                kType: DataItemType.StringList,
                kShow: true,
              },
           ];
  }

  static FormShowItemRequest formShowItemRequest(List<Map> list) {
    List<Map> queryList = [];
    queryList.addAll(list);
    FormShowItemRequest req = FormShowItemRequest();
    req.title = RequestListModelQuery.query('Form_Request_ShowItemRequest-title',queryList);
    req.textPushedMode = RequestListModelQuery.query('Form_Request_ShowItemRequest-textPushedMode',queryList);
    req.taxLine = RequestListModelQuery.query('Form_Request_ShowItemRequest-taxLine',queryList);
    req.totalLine = RequestListModelQuery.query('Form_Request_ShowItemRequest-totalLine',queryList);
    req.itemDetails = RequestListModelQuery.query('Form_Request_ShowItemRequest-itemDetails',queryList);
    req.lineItemAction = RequestListModelQuery.query('Form_Request_ShowItemRequest-lineItemAction',queryList);
    req.itemIndices = ListStringQuery.query('Form_Request_ShowItemRequest-itemIndices',queryList);
    return req;
  }

  static List<Map> showMessageData() {
      return [
              {
                kEnable: true,
                kLevel: 1,
                kName: 'FormCommand',
                kID: 'FormCommand',
                kMenuID: 'FormCommand_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FormCommand.ShowMessageCenterRequest,
                kData: [
                  {
                    kData: FormCommand.ShowMessageCenterRequest,
                    kID: 'FormCommand_ShowMessageCenterRequest',
                  },
                  {
                    kData: FormCommand.InputTextRequest,
                    kID: 'FormCommand_InputTextRequest',
                  },
                  {
                    kData: FormCommand.ClearMessageRequest,
                    kID: 'FormCommand_ClearMessageRequest',
                  },
                  {
                    kData: FormCommand.ShowItemRequest,
                    kID: 'FormCommand_ShowItemRequest',
                  },
                  {
                    kData: FormCommand.ShowMessageRequest,
                    kID: 'FormCommand_ShowMessageRequest',
                  },
                  {
                    kData: FormCommand.ShowDialogRequest,
                    kID: 'FormCommand_ShowDialogRequest',
                  },
                  {
                    kData: FormCommand.ShowTextBoxRequest,
                    kID: 'FormCommand_ShowTextBoxRequest',
                  },
                  {
                    kData: FormCommand.ShowDialogFormRequest,
                    kID: 'FormCommand_ShowDialogFormRequest',
                  },
                  {
                    kData: FormCommand.RemoveCardRequest,
                    kID: 'FormCommand_RemoveCardRequest',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'displayMessage1',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Form_Request_ShowMessageRequest-displayMessage1',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'title',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Form_Request_ShowMessageRequest-title',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'displayMessage2',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Form_Request_ShowMessageRequest-displayMessage2',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'textPushedMode',
                kID: 'Form_Request_ShowMessageRequest-textPushedMode',
                kMenuID: 'Form_Request_ShowMessageRequest-textPushedMode_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FormTextPushedMode.NotSet,
                kData: [
                  {
                    kData: FormTextPushedMode.NotSet,
                    kID: 'Form_Request_ShowMessageRequest-textPushedMode_NotSet',
                  },
                  {
                    kData: FormTextPushedMode.Topdown,
                    kID: 'Form_Request_ShowMessageRequest-textPushedMode_Topdown',
                  },
                  {
                    kData: FormTextPushedMode.BottomUp,
                    kID: 'Form_Request_ShowMessageRequest-textPushedMode_BottomUp',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'taxLine',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Form_Request_ShowMessageRequest-taxLine',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'totalLine',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Form_Request_ShowMessageRequest-totalLine',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'imageName',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Form_Request_ShowMessageRequest-imageName',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'imageDescription',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Form_Request_ShowMessageRequest-imageDescription',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'lineItemAction',
                kID: 'Form_Request_ShowMessageRequest-lineItemAction',
                kMenuID: 'Form_Request_ShowMessageRequest-lineItemAction_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FormLineItemAction.NotSet,
                kData: [
                  {
                    kData: FormLineItemAction.NotSet,
                    kID: 'Form_Request_ShowMessageRequest-lineItemAction_NotSet',
                  },
                  {
                    kData: FormLineItemAction.Add,
                    kID: 'Form_Request_ShowMessageRequest-lineItemAction_Add',
                  },
                  {
                    kData: FormLineItemAction.Update,
                    kID: 'Form_Request_ShowMessageRequest-lineItemAction_Update',
                  },
                  {
                    kData: FormLineItemAction.Delete,
                    kID: 'Form_Request_ShowMessageRequest-lineItemAction_Delete',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'itemIndices',
                kValue: ' ',
                kID: 'Form_Request_ShowMessageRequest-itemIndices',
                kType: DataItemType.StringList,
                kShow: true,
              },
           ];
  }

  static FormShowMessageRequest formShowMessageRequest(List<Map> list) {
    List<Map> queryList = [];
    queryList.addAll(list);
    FormShowMessageRequest req = FormShowMessageRequest();
    req.displayMessage1 = RequestListModelQuery.query('Form_Request_ShowMessageRequest-displayMessage1',queryList);
    req.title = RequestListModelQuery.query('Form_Request_ShowMessageRequest-title',queryList);
    req.displayMessage2 = RequestListModelQuery.query('Form_Request_ShowMessageRequest-displayMessage2',queryList);
    req.textPushedMode = RequestListModelQuery.query('Form_Request_ShowMessageRequest-textPushedMode',queryList);
    req.taxLine = RequestListModelQuery.query('Form_Request_ShowMessageRequest-taxLine',queryList);
    req.totalLine = RequestListModelQuery.query('Form_Request_ShowMessageRequest-totalLine',queryList);
    req.imageName = RequestListModelQuery.query('Form_Request_ShowMessageRequest-imageName',queryList);
    req.imageDescription = RequestListModelQuery.query('Form_Request_ShowMessageRequest-imageDescription',queryList);
    req.lineItemAction = RequestListModelQuery.query('Form_Request_ShowMessageRequest-lineItemAction',queryList);
    req.itemIndices = ListStringQuery.query('Form_Request_ShowMessageRequest-itemIndices',queryList);
    return req;
  }

  static List<Map> showDialogData() {
      return [
              {
                kEnable: true,
                kLevel: 1,
                kName: 'FormCommand',
                kID: 'FormCommand',
                kMenuID: 'FormCommand_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FormCommand.ShowMessageCenterRequest,
                kData: [
                  {
                    kData: FormCommand.ShowMessageCenterRequest,
                    kID: 'FormCommand_ShowMessageCenterRequest',
                  },
                  {
                    kData: FormCommand.InputTextRequest,
                    kID: 'FormCommand_InputTextRequest',
                  },
                  {
                    kData: FormCommand.ClearMessageRequest,
                    kID: 'FormCommand_ClearMessageRequest',
                  },
                  {
                    kData: FormCommand.ShowItemRequest,
                    kID: 'FormCommand_ShowItemRequest',
                  },
                  {
                    kData: FormCommand.ShowMessageRequest,
                    kID: 'FormCommand_ShowMessageRequest',
                  },
                  {
                    kData: FormCommand.ShowDialogRequest,
                    kID: 'FormCommand_ShowDialogRequest',
                  },
                  {
                    kData: FormCommand.ShowTextBoxRequest,
                    kID: 'FormCommand_ShowTextBoxRequest',
                  },
                  {
                    kData: FormCommand.ShowDialogFormRequest,
                    kID: 'FormCommand_ShowDialogFormRequest',
                  },
                  {
                    kData: FormCommand.RemoveCardRequest,
                    kID: 'FormCommand_RemoveCardRequest',
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
                kID: 'Form_Request_ShowDialogRequest-title',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kGroupArrowOpen: true,
                kName: 'button1',
                kValue: '',
                kID: 'Form_Request_ShowDialogRequest-button1',
                kType: DataItemType.Group,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'name',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Form_Request_ShowDialogRequest-button1_name',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kGroupArrowOpen: true,
                kName: 'button2',
                kValue: '',
                kID: 'Form_Request_ShowDialogRequest-button2',
                kType: DataItemType.Group,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'name',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Form_Request_ShowDialogRequest-button2_name',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kGroupArrowOpen: true,
                kName: 'button3',
                kValue: '',
                kID: 'Form_Request_ShowDialogRequest-button3',
                kType: DataItemType.Group,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'name',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Form_Request_ShowDialogRequest-button3_name',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kGroupArrowOpen: true,
                kName: 'button4',
                kValue: '',
                kID: 'Form_Request_ShowDialogRequest-button4',
                kType: DataItemType.Group,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'name',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Form_Request_ShowDialogRequest-button4_name',
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
                kID: 'Form_Request_ShowDialogRequest-timeout',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'continuousScreen',
                kID: 'Form_Request_ShowDialogRequest-continuousScreen',
                kMenuID: 'Form_Request_ShowDialogRequest-continuousScreen_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FormContinuousScreen.NotSet,
                kData: [
                  {
                    kData: FormContinuousScreen.NotSet,
                    kID: 'Form_Request_ShowDialogRequest-continuousScreen_NotSet',
                  },
                  {
                    kData: FormContinuousScreen.Default,
                    kID: 'Form_Request_ShowDialogRequest-continuousScreen_Default',
                  },
                  {
                    kData: FormContinuousScreen.NotGoToIdleScreen,
                    kID: 'Form_Request_ShowDialogRequest-continuousScreen_NotGoToIdleScreen',
                  },
                ],
              },
           ];
  }

  static FormShowDialogRequest formShowDialogRequest(List<Map> list) {
    List<Map> queryList = [];
    queryList.addAll(list);
    FormShowDialogRequest req = FormShowDialogRequest();
    req.title = RequestListModelQuery.query('Form_Request_ShowDialogRequest-title',queryList);
    req.button1 = FormSdButton();
    req.button1!.name = RequestListModelQuery.query('Form_Request_ShowDialogRequest-button1_name',queryList);
    req.button2 = FormSdButton();
    req.button2!.name = RequestListModelQuery.query('Form_Request_ShowDialogRequest-button2_name',queryList);
    req.button3 = FormSdButton();
    req.button3!.name = RequestListModelQuery.query('Form_Request_ShowDialogRequest-button3_name',queryList);
    req.button4 = FormSdButton();
    req.button4!.name = RequestListModelQuery.query('Form_Request_ShowDialogRequest-button4_name',queryList);
    req.timeout = RequestListModelQuery.query('Form_Request_ShowDialogRequest-timeout',queryList);
    req.continuousScreen = RequestListModelQuery.query('Form_Request_ShowDialogRequest-continuousScreen',queryList);
    return req;
  }

  static List<Map> showTextBoxData() {
      return [
              {
                kEnable: true,
                kLevel: 1,
                kName: 'FormCommand',
                kID: 'FormCommand',
                kMenuID: 'FormCommand_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FormCommand.ShowMessageCenterRequest,
                kData: [
                  {
                    kData: FormCommand.ShowMessageCenterRequest,
                    kID: 'FormCommand_ShowMessageCenterRequest',
                  },
                  {
                    kData: FormCommand.InputTextRequest,
                    kID: 'FormCommand_InputTextRequest',
                  },
                  {
                    kData: FormCommand.ClearMessageRequest,
                    kID: 'FormCommand_ClearMessageRequest',
                  },
                  {
                    kData: FormCommand.ShowItemRequest,
                    kID: 'FormCommand_ShowItemRequest',
                  },
                  {
                    kData: FormCommand.ShowMessageRequest,
                    kID: 'FormCommand_ShowMessageRequest',
                  },
                  {
                    kData: FormCommand.ShowDialogRequest,
                    kID: 'FormCommand_ShowDialogRequest',
                  },
                  {
                    kData: FormCommand.ShowTextBoxRequest,
                    kID: 'FormCommand_ShowTextBoxRequest',
                  },
                  {
                    kData: FormCommand.ShowDialogFormRequest,
                    kID: 'FormCommand_ShowDialogFormRequest',
                  },
                  {
                    kData: FormCommand.RemoveCardRequest,
                    kID: 'FormCommand_RemoveCardRequest',
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
                kID: 'Form_Request_ShowTextBoxRequest-title',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'text',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Form_Request_ShowTextBoxRequest-text',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kGroupArrowOpen: true,
                kName: 'button1',
                kValue: '',
                kID: 'Form_Request_ShowTextBoxRequest-button1',
                kType: DataItemType.Group,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'name',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Form_Request_ShowTextBoxRequest-button1_name',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'color',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Form_Request_ShowTextBoxRequest-button1_color',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'hardKey',
                kID: 'Form_Request_ShowTextBoxRequest-button1_hardKey',
                kMenuID: 'Form_Request_ShowTextBoxRequest-button1_hardKey_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FormHardKey.NotSet,
                kData: [
                  {
                    kData: FormHardKey.NotSet,
                    kID: 'Form_Request_ShowTextBoxRequest-button1_hardKey_NotSet',
                  },
                  {
                    kData: FormHardKey.Key0,
                    kID: 'Form_Request_ShowTextBoxRequest-button1_hardKey_Key0',
                  },
                  {
                    kData: FormHardKey.Key1,
                    kID: 'Form_Request_ShowTextBoxRequest-button1_hardKey_Key1',
                  },
                  {
                    kData: FormHardKey.Key2,
                    kID: 'Form_Request_ShowTextBoxRequest-button1_hardKey_Key2',
                  },
                  {
                    kData: FormHardKey.Key3,
                    kID: 'Form_Request_ShowTextBoxRequest-button1_hardKey_Key3',
                  },
                  {
                    kData: FormHardKey.Key4,
                    kID: 'Form_Request_ShowTextBoxRequest-button1_hardKey_Key4',
                  },
                  {
                    kData: FormHardKey.Key5,
                    kID: 'Form_Request_ShowTextBoxRequest-button1_hardKey_Key5',
                  },
                  {
                    kData: FormHardKey.Key6,
                    kID: 'Form_Request_ShowTextBoxRequest-button1_hardKey_Key6',
                  },
                  {
                    kData: FormHardKey.Key7,
                    kID: 'Form_Request_ShowTextBoxRequest-button1_hardKey_Key7',
                  },
                  {
                    kData: FormHardKey.Key8,
                    kID: 'Form_Request_ShowTextBoxRequest-button1_hardKey_Key8',
                  },
                  {
                    kData: FormHardKey.Key9,
                    kID: 'Form_Request_ShowTextBoxRequest-button1_hardKey_Key9',
                  },
                  {
                    kData: FormHardKey.Clear,
                    kID: 'Form_Request_ShowTextBoxRequest-button1_hardKey_Clear',
                  },
                  {
                    kData: FormHardKey.Cancel,
                    kID: 'Form_Request_ShowTextBoxRequest-button1_hardKey_Cancel',
                  },
                  {
                    kData: FormHardKey.Ok,
                    kID: 'Form_Request_ShowTextBoxRequest-button1_hardKey_Ok',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kGroupArrowOpen: true,
                kName: 'button2',
                kValue: '',
                kID: 'Form_Request_ShowTextBoxRequest-button2',
                kType: DataItemType.Group,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'name',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Form_Request_ShowTextBoxRequest-button2_name',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'color',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Form_Request_ShowTextBoxRequest-button2_color',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'hardKey',
                kID: 'Form_Request_ShowTextBoxRequest-button2_hardKey',
                kMenuID: 'Form_Request_ShowTextBoxRequest-button2_hardKey_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FormHardKey.NotSet,
                kData: [
                  {
                    kData: FormHardKey.NotSet,
                    kID: 'Form_Request_ShowTextBoxRequest-button2_hardKey_NotSet',
                  },
                  {
                    kData: FormHardKey.Key0,
                    kID: 'Form_Request_ShowTextBoxRequest-button2_hardKey_Key0',
                  },
                  {
                    kData: FormHardKey.Key1,
                    kID: 'Form_Request_ShowTextBoxRequest-button2_hardKey_Key1',
                  },
                  {
                    kData: FormHardKey.Key2,
                    kID: 'Form_Request_ShowTextBoxRequest-button2_hardKey_Key2',
                  },
                  {
                    kData: FormHardKey.Key3,
                    kID: 'Form_Request_ShowTextBoxRequest-button2_hardKey_Key3',
                  },
                  {
                    kData: FormHardKey.Key4,
                    kID: 'Form_Request_ShowTextBoxRequest-button2_hardKey_Key4',
                  },
                  {
                    kData: FormHardKey.Key5,
                    kID: 'Form_Request_ShowTextBoxRequest-button2_hardKey_Key5',
                  },
                  {
                    kData: FormHardKey.Key6,
                    kID: 'Form_Request_ShowTextBoxRequest-button2_hardKey_Key6',
                  },
                  {
                    kData: FormHardKey.Key7,
                    kID: 'Form_Request_ShowTextBoxRequest-button2_hardKey_Key7',
                  },
                  {
                    kData: FormHardKey.Key8,
                    kID: 'Form_Request_ShowTextBoxRequest-button2_hardKey_Key8',
                  },
                  {
                    kData: FormHardKey.Key9,
                    kID: 'Form_Request_ShowTextBoxRequest-button2_hardKey_Key9',
                  },
                  {
                    kData: FormHardKey.Clear,
                    kID: 'Form_Request_ShowTextBoxRequest-button2_hardKey_Clear',
                  },
                  {
                    kData: FormHardKey.Cancel,
                    kID: 'Form_Request_ShowTextBoxRequest-button2_hardKey_Cancel',
                  },
                  {
                    kData: FormHardKey.Ok,
                    kID: 'Form_Request_ShowTextBoxRequest-button2_hardKey_Ok',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kGroupArrowOpen: true,
                kName: 'button3',
                kValue: '',
                kID: 'Form_Request_ShowTextBoxRequest-button3',
                kType: DataItemType.Group,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'name',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Form_Request_ShowTextBoxRequest-button3_name',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'color',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Form_Request_ShowTextBoxRequest-button3_color',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 2,
                kName: 'hardKey',
                kID: 'Form_Request_ShowTextBoxRequest-button3_hardKey',
                kMenuID: 'Form_Request_ShowTextBoxRequest-button3_hardKey_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FormHardKey.NotSet,
                kData: [
                  {
                    kData: FormHardKey.NotSet,
                    kID: 'Form_Request_ShowTextBoxRequest-button3_hardKey_NotSet',
                  },
                  {
                    kData: FormHardKey.Key0,
                    kID: 'Form_Request_ShowTextBoxRequest-button3_hardKey_Key0',
                  },
                  {
                    kData: FormHardKey.Key1,
                    kID: 'Form_Request_ShowTextBoxRequest-button3_hardKey_Key1',
                  },
                  {
                    kData: FormHardKey.Key2,
                    kID: 'Form_Request_ShowTextBoxRequest-button3_hardKey_Key2',
                  },
                  {
                    kData: FormHardKey.Key3,
                    kID: 'Form_Request_ShowTextBoxRequest-button3_hardKey_Key3',
                  },
                  {
                    kData: FormHardKey.Key4,
                    kID: 'Form_Request_ShowTextBoxRequest-button3_hardKey_Key4',
                  },
                  {
                    kData: FormHardKey.Key5,
                    kID: 'Form_Request_ShowTextBoxRequest-button3_hardKey_Key5',
                  },
                  {
                    kData: FormHardKey.Key6,
                    kID: 'Form_Request_ShowTextBoxRequest-button3_hardKey_Key6',
                  },
                  {
                    kData: FormHardKey.Key7,
                    kID: 'Form_Request_ShowTextBoxRequest-button3_hardKey_Key7',
                  },
                  {
                    kData: FormHardKey.Key8,
                    kID: 'Form_Request_ShowTextBoxRequest-button3_hardKey_Key8',
                  },
                  {
                    kData: FormHardKey.Key9,
                    kID: 'Form_Request_ShowTextBoxRequest-button3_hardKey_Key9',
                  },
                  {
                    kData: FormHardKey.Clear,
                    kID: 'Form_Request_ShowTextBoxRequest-button3_hardKey_Clear',
                  },
                  {
                    kData: FormHardKey.Cancel,
                    kID: 'Form_Request_ShowTextBoxRequest-button3_hardKey_Cancel',
                  },
                  {
                    kData: FormHardKey.Ok,
                    kID: 'Form_Request_ShowTextBoxRequest-button3_hardKey_Ok',
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
                kID: 'Form_Request_ShowTextBoxRequest-timeout',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'enableKeyType',
                kID: 'Form_Request_ShowTextBoxRequest-enableKeyType',
                kMenuID: 'Form_Request_ShowTextBoxRequest-enableKeyType_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FormEnableKeyType.NotSet,
                kData: [
                  {
                    kData: FormEnableKeyType.NotSet,
                    kID: 'Form_Request_ShowTextBoxRequest-enableKeyType_NotSet',
                  },
                  {
                    kData: FormEnableKeyType.EnableVirtualButtonAndHardKeys,
                    kID: 'Form_Request_ShowTextBoxRequest-enableKeyType_EnableVirtualButtonAndHardKeys',
                  },
                  {
                    kData: FormEnableKeyType.EnableHardKeyOnly,
                    kID: 'Form_Request_ShowTextBoxRequest-enableKeyType_EnableHardKeyOnly',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kID: 'Form_Request_ShowTextBoxRequest-hardKeyList',
                kType: DataItemType.ModelList,
                kClass: 'HardKey',
                kShow: true,
                kName: 'hardKeyList',
                kValue: [
                  {
                    kType: DataItemType.Menu,
                    kID: 'Form_Request_ShowTextBoxRequest-hardKeyList',
                    kName: 'hardKeyList',
                    kShow: true,
                    kLevel: 1,
                    kValue: FormHardKey.NotSet,
                    kData: [
                      {
                         kData: FormHardKey.NotSet,
                         kID: 'Form_Request_ShowTextBoxRequest-hardKeyList_NotSet',
                      },
                      {
                         kData: FormHardKey.Key0,
                         kID: 'Form_Request_ShowTextBoxRequest-hardKeyList_Key0',
                      },
                      {
                         kData: FormHardKey.Key1,
                         kID: 'Form_Request_ShowTextBoxRequest-hardKeyList_Key1',
                      },
                      {
                         kData: FormHardKey.Key2,
                         kID: 'Form_Request_ShowTextBoxRequest-hardKeyList_Key2',
                      },
                      {
                         kData: FormHardKey.Key3,
                         kID: 'Form_Request_ShowTextBoxRequest-hardKeyList_Key3',
                      },
                      {
                         kData: FormHardKey.Key4,
                         kID: 'Form_Request_ShowTextBoxRequest-hardKeyList_Key4',
                      },
                      {
                         kData: FormHardKey.Key5,
                         kID: 'Form_Request_ShowTextBoxRequest-hardKeyList_Key5',
                      },
                      {
                         kData: FormHardKey.Key6,
                         kID: 'Form_Request_ShowTextBoxRequest-hardKeyList_Key6',
                      },
                      {
                         kData: FormHardKey.Key7,
                         kID: 'Form_Request_ShowTextBoxRequest-hardKeyList_Key7',
                      },
                      {
                         kData: FormHardKey.Key8,
                         kID: 'Form_Request_ShowTextBoxRequest-hardKeyList_Key8',
                      },
                      {
                         kData: FormHardKey.Key9,
                         kID: 'Form_Request_ShowTextBoxRequest-hardKeyList_Key9',
                      },
                      {
                         kData: FormHardKey.Clear,
                         kID: 'Form_Request_ShowTextBoxRequest-hardKeyList_Clear',
                      },
                      {
                         kData: FormHardKey.Cancel,
                         kID: 'Form_Request_ShowTextBoxRequest-hardKeyList_Cancel',
                      },
                      {
                         kData: FormHardKey.Ok,
                         kID: 'Form_Request_ShowTextBoxRequest-hardKeyList_Ok',
                      },
                    ],
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'signatureBox',
                kID: 'Form_Request_ShowTextBoxRequest-signatureBox',
                kMenuID: 'Form_Request_ShowTextBoxRequest-signatureBox_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FormSignatureBoxType.NotSet,
                kData: [
                  {
                    kData: FormSignatureBoxType.NotSet,
                    kID: 'Form_Request_ShowTextBoxRequest-signatureBox_NotSet',
                  },
                  {
                    kData: FormSignatureBoxType.NoSignatureBox,
                    kID: 'Form_Request_ShowTextBoxRequest-signatureBox_NoSignatureBox',
                  },
                  {
                    kData: FormSignatureBoxType.TerminalPreference,
                    kID: 'Form_Request_ShowTextBoxRequest-signatureBox_TerminalPreference',
                  },
                  {
                    kData: FormSignatureBoxType.HorizontalDisplay,
                    kID: 'Form_Request_ShowTextBoxRequest-signatureBox_HorizontalDisplay',
                  },
                  {
                    kData: FormSignatureBoxType.VerticalDisplay,
                    kID: 'Form_Request_ShowTextBoxRequest-signatureBox_VerticalDisplay',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'continuousScreen',
                kID: 'Form_Request_ShowTextBoxRequest-continuousScreen',
                kMenuID: 'Form_Request_ShowTextBoxRequest-continuousScreen_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FormContinuousScreen.NotSet,
                kData: [
                  {
                    kData: FormContinuousScreen.NotSet,
                    kID: 'Form_Request_ShowTextBoxRequest-continuousScreen_NotSet',
                  },
                  {
                    kData: FormContinuousScreen.Default,
                    kID: 'Form_Request_ShowTextBoxRequest-continuousScreen_Default',
                  },
                  {
                    kData: FormContinuousScreen.NotGoToIdleScreen,
                    kID: 'Form_Request_ShowTextBoxRequest-continuousScreen_NotGoToIdleScreen',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'barcodeName',
                kID: 'Form_Request_ShowTextBoxRequest-barcodeName',
                kMenuID: 'Form_Request_ShowTextBoxRequest-barcodeName_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FormBarcodeName.NotSet,
                kData: [
                  {
                    kData: FormBarcodeName.NotSet,
                    kID: 'Form_Request_ShowTextBoxRequest-barcodeName_NotSet',
                  },
                  {
                    kData: FormBarcodeName.Code39,
                    kID: 'Form_Request_ShowTextBoxRequest-barcodeName_Code39',
                  },
                  {
                    kData: FormBarcodeName.Code128,
                    kID: 'Form_Request_ShowTextBoxRequest-barcodeName_Code128',
                  },
                  {
                    kData: FormBarcodeName.Ean13,
                    kID: 'Form_Request_ShowTextBoxRequest-barcodeName_Ean13',
                  },
                  {
                    kData: FormBarcodeName.Ean128,
                    kID: 'Form_Request_ShowTextBoxRequest-barcodeName_Ean128',
                  },
                  {
                    kData: FormBarcodeName.Pdf417,
                    kID: 'Form_Request_ShowTextBoxRequest-barcodeName_Pdf417',
                  },
                  {
                    kData: FormBarcodeName.GridMatrix,
                    kID: 'Form_Request_ShowTextBoxRequest-barcodeName_GridMatrix',
                  },
                  {
                    kData: FormBarcodeName.QrCode,
                    kID: 'Form_Request_ShowTextBoxRequest-barcodeName_QrCode',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'barcodeData',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Form_Request_ShowTextBoxRequest-barcodeData',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'inputTextTitle',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Form_Request_ShowTextBoxRequest-inputTextTitle',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'inputText',
                kID: 'Form_Request_ShowTextBoxRequest-inputText',
                kMenuID: 'Form_Request_ShowTextBoxRequest-inputText_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FormInputTextType.NotSet,
                kData: [
                  {
                    kData: FormInputTextType.NotSet,
                    kID: 'Form_Request_ShowTextBoxRequest-inputText_NotSet',
                  },
                  {
                    kData: FormInputTextType.NoInputText,
                    kID: 'Form_Request_ShowTextBoxRequest-inputText_NoInputText',
                  },
                  {
                    kData: FormInputTextType.ShowInputText,
                    kID: 'Form_Request_ShowTextBoxRequest-inputText_ShowInputText',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'inputType',
                kID: 'Form_Request_ShowTextBoxRequest-inputType',
                kMenuID: 'Form_Request_ShowTextBoxRequest-inputType_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FormInputType.NotSet,
                kData: [
                  {
                    kData: FormInputType.NotSet,
                    kID: 'Form_Request_ShowTextBoxRequest-inputType_NotSet',
                  },
                  {
                    kData: FormInputType.AlphaNumeric,
                    kID: 'Form_Request_ShowTextBoxRequest-inputType_AlphaNumeric',
                  },
                  {
                    kData: FormInputType.Numeric,
                    kID: 'Form_Request_ShowTextBoxRequest-inputType_Numeric',
                  },
                  {
                    kData: FormInputType.Date,
                    kID: 'Form_Request_ShowTextBoxRequest-inputType_Date',
                  },
                  {
                    kData: FormInputType.Time,
                    kID: 'Form_Request_ShowTextBoxRequest-inputType_Time',
                  },
                  {
                    kData: FormInputType.Currency,
                    kID: 'Form_Request_ShowTextBoxRequest-inputType_Currency',
                  },
                  {
                    kData: FormInputType.Password,
                    kID: 'Form_Request_ShowTextBoxRequest-inputType_Password',
                  },
                  {
                    kData: FormInputType.PhoneNumber,
                    kID: 'Form_Request_ShowTextBoxRequest-inputType_PhoneNumber',
                  },
                  {
                    kData: FormInputType.SocialSecurity,
                    kID: 'Form_Request_ShowTextBoxRequest-inputType_SocialSecurity',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'minLength',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'Form_Request_ShowTextBoxRequest-minLength',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'maxLength',
                kValue: '',
                kTextAttribute: 1,
                kUnit: '',
                kID: 'Form_Request_ShowTextBoxRequest-maxLength',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

  static FormShowTextBoxRequest formShowTextBoxRequest(List<Map> list) {
    List<Map> queryList = [];
    queryList.addAll(list);
    FormShowTextBoxRequest req = FormShowTextBoxRequest();
    req.title = RequestListModelQuery.query('Form_Request_ShowTextBoxRequest-title',queryList);
    req.text = RequestListModelQuery.query('Form_Request_ShowTextBoxRequest-text',queryList);
    req.button1 = FormStbButton();
    req.button1!.name = RequestListModelQuery.query('Form_Request_ShowTextBoxRequest-button1_name',queryList);
    req.button1!.color = RequestListModelQuery.query('Form_Request_ShowTextBoxRequest-button1_color',queryList);
    req.button1!.hardKey = RequestListModelQuery.query('Form_Request_ShowTextBoxRequest-button1_hardKey',queryList);
    req.button2 = FormStbButton();
    req.button2!.name = RequestListModelQuery.query('Form_Request_ShowTextBoxRequest-button2_name',queryList);
    req.button2!.color = RequestListModelQuery.query('Form_Request_ShowTextBoxRequest-button2_color',queryList);
    req.button2!.hardKey = RequestListModelQuery.query('Form_Request_ShowTextBoxRequest-button2_hardKey',queryList);
    req.button3 = FormStbButton();
    req.button3!.name = RequestListModelQuery.query('Form_Request_ShowTextBoxRequest-button3_name',queryList);
    req.button3!.color = RequestListModelQuery.query('Form_Request_ShowTextBoxRequest-button3_color',queryList);
    req.button3!.hardKey = RequestListModelQuery.query('Form_Request_ShowTextBoxRequest-button3_hardKey',queryList);
    req.timeout = RequestListModelQuery.query('Form_Request_ShowTextBoxRequest-timeout',queryList);
    req.enableKeyType = RequestListModelQuery.query('Form_Request_ShowTextBoxRequest-enableKeyType',queryList);
    req.hardKeyList = RequestListModelQuery.query('Form_Request_ShowTextBoxRequest-hardKeyList',queryList);
    req.signatureBox = RequestListModelQuery.query('Form_Request_ShowTextBoxRequest-signatureBox',queryList);
    req.continuousScreen = RequestListModelQuery.query('Form_Request_ShowTextBoxRequest-continuousScreen',queryList);
    req.barcodeName = RequestListModelQuery.query('Form_Request_ShowTextBoxRequest-barcodeName',queryList);
    req.barcodeData = RequestListModelQuery.query('Form_Request_ShowTextBoxRequest-barcodeData',queryList);
    req.inputTextTitle = RequestListModelQuery.query('Form_Request_ShowTextBoxRequest-inputTextTitle',queryList);
    req.inputText = RequestListModelQuery.query('Form_Request_ShowTextBoxRequest-inputText',queryList);
    req.inputType = RequestListModelQuery.query('Form_Request_ShowTextBoxRequest-inputType',queryList);
    req.minLength = RequestListModelQuery.query('Form_Request_ShowTextBoxRequest-minLength',queryList);
    req.maxLength = RequestListModelQuery.query('Form_Request_ShowTextBoxRequest-maxLength',queryList);
    return req;
  }

  static List<Map> showDialogFormData() {
      return [
              {
                kEnable: true,
                kLevel: 1,
                kName: 'FormCommand',
                kID: 'FormCommand',
                kMenuID: 'FormCommand_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FormCommand.ShowMessageCenterRequest,
                kData: [
                  {
                    kData: FormCommand.ShowMessageCenterRequest,
                    kID: 'FormCommand_ShowMessageCenterRequest',
                  },
                  {
                    kData: FormCommand.InputTextRequest,
                    kID: 'FormCommand_InputTextRequest',
                  },
                  {
                    kData: FormCommand.ClearMessageRequest,
                    kID: 'FormCommand_ClearMessageRequest',
                  },
                  {
                    kData: FormCommand.ShowItemRequest,
                    kID: 'FormCommand_ShowItemRequest',
                  },
                  {
                    kData: FormCommand.ShowMessageRequest,
                    kID: 'FormCommand_ShowMessageRequest',
                  },
                  {
                    kData: FormCommand.ShowDialogRequest,
                    kID: 'FormCommand_ShowDialogRequest',
                  },
                  {
                    kData: FormCommand.ShowTextBoxRequest,
                    kID: 'FormCommand_ShowTextBoxRequest',
                  },
                  {
                    kData: FormCommand.ShowDialogFormRequest,
                    kID: 'FormCommand_ShowDialogFormRequest',
                  },
                  {
                    kData: FormCommand.RemoveCardRequest,
                    kID: 'FormCommand_RemoveCardRequest',
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
                kID: 'Form_Request_ShowDialogFormRequest-title',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'label1',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Form_Request_ShowDialogFormRequest-label1',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'label1Property',
                kID: 'Form_Request_ShowDialogFormRequest-label1Property',
                kMenuID: 'Form_Request_ShowDialogFormRequest-label1Property_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FormLabelProperty.NotSet,
                kData: [
                  {
                    kData: FormLabelProperty.NotSet,
                    kID: 'Form_Request_ShowDialogFormRequest-label1Property_NotSet',
                  },
                  {
                    kData: FormLabelProperty.Unchecked,
                    kID: 'Form_Request_ShowDialogFormRequest-label1Property_Unchecked',
                  },
                  {
                    kData: FormLabelProperty.Checked,
                    kID: 'Form_Request_ShowDialogFormRequest-label1Property_Checked',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'label2',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Form_Request_ShowDialogFormRequest-label2',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'label2Property',
                kID: 'Form_Request_ShowDialogFormRequest-label2Property',
                kMenuID: 'Form_Request_ShowDialogFormRequest-label2Property_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FormLabelProperty.NotSet,
                kData: [
                  {
                    kData: FormLabelProperty.NotSet,
                    kID: 'Form_Request_ShowDialogFormRequest-label2Property_NotSet',
                  },
                  {
                    kData: FormLabelProperty.Unchecked,
                    kID: 'Form_Request_ShowDialogFormRequest-label2Property_Unchecked',
                  },
                  {
                    kData: FormLabelProperty.Checked,
                    kID: 'Form_Request_ShowDialogFormRequest-label2Property_Checked',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'label3',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Form_Request_ShowDialogFormRequest-label3',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'label3Property',
                kID: 'Form_Request_ShowDialogFormRequest-label3Property',
                kMenuID: 'Form_Request_ShowDialogFormRequest-label3Property_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FormLabelProperty.NotSet,
                kData: [
                  {
                    kData: FormLabelProperty.NotSet,
                    kID: 'Form_Request_ShowDialogFormRequest-label3Property_NotSet',
                  },
                  {
                    kData: FormLabelProperty.Unchecked,
                    kID: 'Form_Request_ShowDialogFormRequest-label3Property_Unchecked',
                  },
                  {
                    kData: FormLabelProperty.Checked,
                    kID: 'Form_Request_ShowDialogFormRequest-label3Property_Checked',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'label4',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Form_Request_ShowDialogFormRequest-label4',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'label4Property',
                kID: 'Form_Request_ShowDialogFormRequest-label4Property',
                kMenuID: 'Form_Request_ShowDialogFormRequest-label4Property_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FormLabelProperty.NotSet,
                kData: [
                  {
                    kData: FormLabelProperty.NotSet,
                    kID: 'Form_Request_ShowDialogFormRequest-label4Property_NotSet',
                  },
                  {
                    kData: FormLabelProperty.Unchecked,
                    kID: 'Form_Request_ShowDialogFormRequest-label4Property_Unchecked',
                  },
                  {
                    kData: FormLabelProperty.Checked,
                    kID: 'Form_Request_ShowDialogFormRequest-label4Property_Checked',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'buttonType',
                kID: 'Form_Request_ShowDialogFormRequest-buttonType',
                kMenuID: 'Form_Request_ShowDialogFormRequest-buttonType_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FormButtonType.NotSet,
                kData: [
                  {
                    kData: FormButtonType.NotSet,
                    kID: 'Form_Request_ShowDialogFormRequest-buttonType_NotSet',
                  },
                  {
                    kData: FormButtonType.RadioButton,
                    kID: 'Form_Request_ShowDialogFormRequest-buttonType_RadioButton',
                  },
                  {
                    kData: FormButtonType.CheckBox,
                    kID: 'Form_Request_ShowDialogFormRequest-buttonType_CheckBox',
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
                kID: 'Form_Request_ShowDialogFormRequest-timeout',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'continuousScreen',
                kID: 'Form_Request_ShowDialogFormRequest-continuousScreen',
                kMenuID: 'Form_Request_ShowDialogFormRequest-continuousScreen_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FormContinuousScreen.NotSet,
                kData: [
                  {
                    kData: FormContinuousScreen.NotSet,
                    kID: 'Form_Request_ShowDialogFormRequest-continuousScreen_NotSet',
                  },
                  {
                    kData: FormContinuousScreen.Default,
                    kID: 'Form_Request_ShowDialogFormRequest-continuousScreen_Default',
                  },
                  {
                    kData: FormContinuousScreen.NotGoToIdleScreen,
                    kID: 'Form_Request_ShowDialogFormRequest-continuousScreen_NotGoToIdleScreen',
                  },
                ],
              },
           ];
  }

  static FormShowDialogFormRequest formShowDialogFormRequest(List<Map> list) {
    List<Map> queryList = [];
    queryList.addAll(list);
    FormShowDialogFormRequest req = FormShowDialogFormRequest();
    req.title = RequestListModelQuery.query('Form_Request_ShowDialogFormRequest-title',queryList);
    req.label1 = RequestListModelQuery.query('Form_Request_ShowDialogFormRequest-label1',queryList);
    req.label1Property = RequestListModelQuery.query('Form_Request_ShowDialogFormRequest-label1Property',queryList);
    req.label2 = RequestListModelQuery.query('Form_Request_ShowDialogFormRequest-label2',queryList);
    req.label2Property = RequestListModelQuery.query('Form_Request_ShowDialogFormRequest-label2Property',queryList);
    req.label3 = RequestListModelQuery.query('Form_Request_ShowDialogFormRequest-label3',queryList);
    req.label3Property = RequestListModelQuery.query('Form_Request_ShowDialogFormRequest-label3Property',queryList);
    req.label4 = RequestListModelQuery.query('Form_Request_ShowDialogFormRequest-label4',queryList);
    req.label4Property = RequestListModelQuery.query('Form_Request_ShowDialogFormRequest-label4Property',queryList);
    req.buttonType = RequestListModelQuery.query('Form_Request_ShowDialogFormRequest-buttonType',queryList);
    req.timeout = RequestListModelQuery.query('Form_Request_ShowDialogFormRequest-timeout',queryList);
    req.continuousScreen = RequestListModelQuery.query('Form_Request_ShowDialogFormRequest-continuousScreen',queryList);
    return req;
  }

  static List<Map> removeCardData() {
      return [
              {
                kEnable: true,
                kLevel: 1,
                kName: 'FormCommand',
                kID: 'FormCommand',
                kMenuID: 'FormCommand_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FormCommand.ShowMessageCenterRequest,
                kData: [
                  {
                    kData: FormCommand.ShowMessageCenterRequest,
                    kID: 'FormCommand_ShowMessageCenterRequest',
                  },
                  {
                    kData: FormCommand.InputTextRequest,
                    kID: 'FormCommand_InputTextRequest',
                  },
                  {
                    kData: FormCommand.ClearMessageRequest,
                    kID: 'FormCommand_ClearMessageRequest',
                  },
                  {
                    kData: FormCommand.ShowItemRequest,
                    kID: 'FormCommand_ShowItemRequest',
                  },
                  {
                    kData: FormCommand.ShowMessageRequest,
                    kID: 'FormCommand_ShowMessageRequest',
                  },
                  {
                    kData: FormCommand.ShowDialogRequest,
                    kID: 'FormCommand_ShowDialogRequest',
                  },
                  {
                    kData: FormCommand.ShowTextBoxRequest,
                    kID: 'FormCommand_ShowTextBoxRequest',
                  },
                  {
                    kData: FormCommand.ShowDialogFormRequest,
                    kID: 'FormCommand_ShowDialogFormRequest',
                  },
                  {
                    kData: FormCommand.RemoveCardRequest,
                    kID: 'FormCommand_RemoveCardRequest',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'message1',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Form_Request_RemoveCardRequest-message1',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'message2',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Form_Request_RemoveCardRequest-message2',
                kType: DataItemType.CellInput,
                kShow: true,
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'continuousScreen',
                kID: 'Form_Request_RemoveCardRequest-continuousScreen',
                kMenuID: 'Form_Request_RemoveCardRequest-continuousScreen_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FormContinuousScreen.NotSet,
                kData: [
                  {
                    kData: FormContinuousScreen.NotSet,
                    kID: 'Form_Request_RemoveCardRequest-continuousScreen_NotSet',
                  },
                  {
                    kData: FormContinuousScreen.Default,
                    kID: 'Form_Request_RemoveCardRequest-continuousScreen_Default',
                  },
                  {
                    kData: FormContinuousScreen.NotGoToIdleScreen,
                    kID: 'Form_Request_RemoveCardRequest-continuousScreen_NotGoToIdleScreen',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'pinpadType',
                kID: 'Form_Request_RemoveCardRequest-pinpadType',
                kMenuID: 'Form_Request_RemoveCardRequest-pinpadType_menubtn',
                kType: DataItemType.Menu,
                kShow: true,
                kValue: FormPinpadType.NotSet,
                kData: [
                  {
                    kData: FormPinpadType.NotSet,
                    kID: 'Form_Request_RemoveCardRequest-pinpadType_NotSet',
                  },
                  {
                    kData: FormPinpadType.InternalPinpad,
                    kID: 'Form_Request_RemoveCardRequest-pinpadType_InternalPinpad',
                  },
                  {
                    kData: FormPinpadType.ExternalPinpad,
                    kID: 'Form_Request_RemoveCardRequest-pinpadType_ExternalPinpad',
                  },
                  {
                    kData: FormPinpadType.RnibPinpad,
                    kID: 'Form_Request_RemoveCardRequest-pinpadType_RnibPinpad',
                  },
                  {
                    kData: FormPinpadType.ExternalPinpadFirst,
                    kID: 'Form_Request_RemoveCardRequest-pinpadType_ExternalPinpadFirst',
                  },
                ],
              },
              {
                kEnable: true,
                kLevel: 1,
                kName: 'icon',
                kValue: '',
                kTextAttribute: 2,
                kUnit: '',
                kID: 'Form_Request_RemoveCardRequest-icon',
                kType: DataItemType.CellInput,
                kShow: true,
              },
           ];
  }

  static FormRemoveCardRequest formRemoveCardRequest(List<Map> list) {
    List<Map> queryList = [];
    queryList.addAll(list);
    FormRemoveCardRequest req = FormRemoveCardRequest();
    req.message1 = RequestListModelQuery.query('Form_Request_RemoveCardRequest-message1',queryList);
    req.message2 = RequestListModelQuery.query('Form_Request_RemoveCardRequest-message2',queryList);
    req.continuousScreen = RequestListModelQuery.query('Form_Request_RemoveCardRequest-continuousScreen',queryList);
    req.pinpadType = RequestListModelQuery.query('Form_Request_RemoveCardRequest-pinpadType',queryList);
    req.icon = RequestListModelQuery.query('Form_Request_RemoveCardRequest-icon',queryList);
    return req;
  }

  static List<Map>? queryDataByString(String string) {
    List tempList = string.split('.');
    if (tempList.length < 2) { return null; }
    String tempStr = tempList[1];
    List<Map> list;
    switch (tempStr) {
      case 'ShowMessageCenterRequest':
        list = FormReqData.showMessageCenterData();
        break;
      case 'InputTextRequest':
        list = FormReqData.inputTextData();
        break;
      case 'ClearMessageRequest':
        list = FormReqData.clearMessageData();
        break;
      case 'ShowItemRequest':
        list = FormReqData.showItemData();
        break;
      case 'ShowMessageRequest':
        list = FormReqData.showMessageData();
        break;
      case 'ShowDialogRequest':
        list = FormReqData.showDialogData();
        break;
      case 'ShowTextBoxRequest':
        list = FormReqData.showTextBoxData();
        break;
      case 'ShowDialogFormRequest':
        list = FormReqData.showDialogFormData();
        break;
      case 'RemoveCardRequest':
        list = FormReqData.removeCardData();
        break;
      default:
        list = [];
        break;
    }
    return list;
  }

}

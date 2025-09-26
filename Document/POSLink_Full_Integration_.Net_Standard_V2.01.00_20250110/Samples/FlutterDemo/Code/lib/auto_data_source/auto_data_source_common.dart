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

enum DataItemType { Menu, Group, CellInput, ModelList, StringList, Boolen}
const kName = 'name';
const kData = 'data';
const kType = 'type';
const kLevel = 'level';
const kShow = 'kShow';
const kValue = 'kValue';
const kID = 'kID';
const kEnable = 'kEnable';
const kMenuID = 'kMenuID';
const kClass = 'kClass';
const kGroupArrowOpen = 'kGroupArrowOpen';
const kBitmapEnable = 'kBitmapEnable';
const kTextAttribute = 'kTextAttribute';
const kTextFieldButtonName = 'kTextFieldButtonName';
const kUnit = 'kUnit';


enum FullIntegrationCommand {
    GetEmvTlvDataRequest,
    InputAccountWithEmvRequest,
    CompleteOnlineEmvRequest,
    AuthorizeCardRequest,
    GetPinBlockRequest,
    SetEmvTlvDataRequest,
}


enum PedCommand {
    GetPedInformationRequest,
    IncreaseKsnRequest,
    SessionKeyInjectionRequest,
    MacCalculationRequest,
}


enum FormCommand {
    ShowMessageCenterRequest,
    InputTextRequest,
    ClearMessageRequest,
    ShowItemRequest,
    ShowMessageRequest,
    ShowDialogRequest,
    ShowTextBoxRequest,
    ShowDialogFormRequest,
    RemoveCardRequest,
}


enum PayloadCommand {
    PayloadRequest,
}


enum CustomFormManageCommand {
    GetFormListRequest,
    GetVarListRequest,
    SetVarListRequest,
    RunFormRequest,
}


enum ManageCommand {
    DeleteImageRequest,
    DoSignatureRequest,
    VasPushDataRequest,
    InitRequest,
    SetGoogleSmartTapParametersRequest,
    CheckFileRequest,
    ClearCardBufferRequest,
    SetApplePayVasParametersRequest,
    GetSignatureRequest,
    ResetScreenRequest,
    GetVariableRequest,
    UpdateResourceFileRequest,
    RebootRequest,
    SetVariableRequest,
}


enum DeviceCommand {
    MifareCardRequest,
    CameraScanRequest,
    PrinterRequest,
    CardInsertDetectionRequest,
}

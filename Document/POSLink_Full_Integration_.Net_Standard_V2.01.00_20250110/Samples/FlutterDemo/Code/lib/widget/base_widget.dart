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

import 'package:flutter/material.dart';
import 'package:poslink2/auto_data_source/auto_data_source_common.dart';
import 'package:poslink2/auto_data_source/auto_fullintegration_request_data_source.dart';
import 'package:poslink2/auto_data_source/auto_manage_request_data_source.dart';
import 'package:poslink2/auto_data_source/auto_payload_request_data_source.dart';
import 'package:poslink2/auto_pigeon/poslink_sdk_fullintegration.dart';
import 'package:poslink2/model/base_view_model.dart';
import 'package:poslink2/model/multicommand_view_model.dart';
import 'package:poslink2/model/request_db.dart';
import 'package:poslink2/model/response_db.dart';
import 'package:poslink2/widget/boolen_item_widget.dart';
import 'package:poslink2/widget/group_item_widget.dart';
import 'package:poslink2/widget/input_item_widget.dart';
import 'package:poslink2/widget/model_list_widget.dart';
import 'package:poslink2/widget/string_list_widget.dart';
import 'package:provider/provider.dart';
import 'package:poslink2/widget/menu_item_widget.dart';

import '../auto_data_source/auto_device_request_data_source.dart';
import '../auto_data_source/auto_form_request_data_source.dart';
import '../auto_data_source/auto_ped_request_data_source.dart';
import '../res/colors.dart';
import '../res/dimension.dart';

class BaseView extends StatefulWidget {
  const BaseView({
    Key? key,
    this.type = 1,
    required this.command,
    this.initData,
    this.isOtherCmdType = false,
    this.refresh,
    this.backgroudColor = Colors.white,
  }) : super(key: key);
  final List<Map>? initData;
  final int? type; // 1 request 2 response
  final Command command;
  final bool? isOtherCmdType;
  final Color? backgroudColor;
  final Function? refresh;

  @override
  State<BaseView> createState() => BaseViewState();
}

class BaseViewState extends State<BaseView> {
  GlobalKey<_BaseRequestWidgetState> _key = GlobalKey();

  scroll() {
    _key.currentState!.scroll();
  }

  forceRefresh() {
    _key.currentState!.forceRefresh();
  }

  scrollDown() {
    _key.currentState!.scrollDown();
  }

  scrollToTop() {
    _key.currentState!.scrollToTop();
  }

  @override
  Widget build(BuildContext context) {
    RequestDataBase requestDataBase = context.read<RequestDataBase>();
    ResponseDataBase responseDataBase = context.read<ResponseDataBase>();
    return ChangeNotifierProvider(
      create: (context) {
        BaseViewModel? model;
        model = BaseViewModel();
        if (widget.command == Command.FULLINTEGRATION) {
          if (widget.type == 1) {
            model.type = 1;
            List<Map>? currentData = requestDataBase.readFullIntegrationData(requestDataBase.strCurrentCommandFullIntegration);
            if (currentData == null) {
              currentData = FullIntegrationReqData.initSourceData();
            }
            model.initData(
              widget.initData == null ? currentData : widget.initData,
              Command.FULLINTEGRATION,
            );
          } else {
            model.type = 2;
            model.initData(
              widget.initData == null ? responseDataBase.fullIntegrationData : widget.initData,
              Command.FULLINTEGRATION,
            );
            responseDataBase.setFullBaseViewModel = model;
          }
        } else if (widget.command == Command.MANAGE) {
          if (widget.type == 1) {
            model.type = 1;
            List<Map>? currentData = requestDataBase.readManageData(requestDataBase.strCurrentCommandManage);
            if (currentData == null) {
              currentData = ManageReqData.initSourceData();
            }
            model.initData(
              widget.initData == null ? currentData : widget.initData,
              Command.MANAGE,
            );
          } else {
            model.type = 2;
            model.initData(
              widget.initData == null ? responseDataBase.manageData : widget.initData,
              Command.MANAGE,
            );
            responseDataBase.setManageBaseViewModel = model;
          }
        } else if (widget.command == Command.DEVICE) {
          if (widget.type == 1) {
            model.type = 1;
            List<Map>? currentData = requestDataBase.readDeviceData(requestDataBase.strCurrentCommandDevice);
            if (currentData == null) {
              currentData = DeviceReqData.initSourceData();
            }
            model.initData(
              widget.initData == null ? currentData : widget.initData,
              Command.DEVICE,
            );
          } else {
            model.type = 2;
            model.initData(
              widget.initData == null ? responseDataBase.deviceData : widget.initData,
              Command.DEVICE,
            );
            responseDataBase.setDeviceBaseViewModel = model;
          }
        } else if (widget.command == Command.FORM) {
          if (widget.type == 1) {
            model.type = 1;
            List<Map>? currentData = requestDataBase.readFormData(requestDataBase.strCurrentCommandForm);
            if (currentData == null) {
              currentData = FormReqData.initSourceData();
            }
            model.initData(
              widget.initData == null ? currentData : widget.initData,
              Command.FORM,
            );
          } else {
            model.type = 2;
            model.initData(
              widget.initData == null ? responseDataBase.formData : widget.initData,
              Command.FORM,
            );
            responseDataBase.setFormBaseViewModel = model;
          }
        } else if (widget.command == Command.PAYLOAD) {
          if (widget.type == 1) {
            model.type = 1;
            List<Map>? currentData = requestDataBase.readPayloadData(requestDataBase.strCurrentCommandPayload);
            if (currentData == null) {
              currentData = PayloadReqData.initSourceData();
            }
            model.initData(
              widget.initData == null ? currentData : widget.initData,
              Command.PAYLOAD,
            );
          } else {
            model.type = 2;
            model.initData(
              widget.initData == null ? responseDataBase.payloadData : widget.initData,
              Command.PAYLOAD,
            );
          }
        } else if (widget.command == Command.PED) {
          if (widget.type == 1) {
            model.type = 1;
            List<Map>? currentData = requestDataBase.readPedData(requestDataBase.strCurrentCommandPed);
            if (currentData == null) {
              currentData = PedReqData.initSourceData();
            }
            model.initData(
              widget.initData == null ? currentData : widget.initData,
              Command.PED,
            );
          } else {
            model.type = 2;
            model.initData(
              widget.initData == null ? responseDataBase.pedData : widget.initData,
              Command.PED,
            );
            responseDataBase.setPedBaseViewModel = model;
          }
        } else if (widget.command == Command.CUSTOMFORMMANAGE) {
          if (widget.type == 1) {
            model.type = 1;
            List<Map>? currentData = requestDataBase.readCustomformmanageData(requestDataBase.strCurrentCommandCustomformmanage);
            if (currentData == null) {
              currentData = FormReqData.initSourceData();
            }
            model.initData(
              widget.initData == null ? currentData : widget.initData,
              Command.CUSTOMFORMMANAGE,
            );
          } else {
            model.type = 2;
            model.initData(
              widget.initData == null ? responseDataBase.customformmanageData : widget.initData,
              Command.CUSTOMFORMMANAGE,
            );
            responseDataBase.setCustomformmanageData = model;
          }
        }

        return model;
      },
      child: BaseRequestWidget(
        type: widget.type,
        isOtherCmdType: widget.isOtherCmdType,
        refresh: widget.refresh,
        color: widget.backgroudColor,
        key: _key,
        command: widget.command,
      ),
    );
  }
}

class BaseRequestWidget extends StatefulWidget {
  BaseRequestWidget({
    @required this.type,
    @required this.command,
    this.isOtherCmdType = false,
    this.refresh,
    this.color,
    Key? key,
  }) : super(key: key);

  final int? type; // 1 request 2 response
  final bool? isOtherCmdType;
  final Function? refresh;
  final Color? color;
  final Command? command;
  @override
  _BaseRequestWidgetState createState() => _BaseRequestWidgetState();
}

class _BaseRequestWidgetState extends State<BaseRequestWidget> {
  RequestDataBase? _requestDataBase;
  MutiCommandViewModel? _mutiCommandViewModel;
  BaseViewModel? baseViewModel;
  ScrollController _scrollController = ScrollController();
  @override
  void initState() {
    if (widget.type! == 1) {
      _requestDataBase = context.read<RequestDataBase>();
      _mutiCommandViewModel = context.read<MutiCommandViewModel>();
    }
    baseViewModel = context.read<BaseViewModel>();
    if (widget.isOtherCmdType == true) {
      baseViewModel!.addListener(_listenBaseViewModel);
    }
    super.initState();
  }

  _listenBaseViewModel() {
    if (widget.refresh != null) {
      List<Map> copyDataSource = baseViewModel!.copyDataSource;
      widget.refresh!(copyDataSource);
    }
  }

  scroll() {
    _scrollController.animateTo(_scrollController.offset + ScrollHeight.getScrollHeight(context), duration: Duration(milliseconds: 1000), curve: Curves.ease);
  }

  forceRefresh() {}

  scrollDown() {
    // double scrollHeight = MediaQuery.of(context).size.height - 240;
    _scrollController.animateTo(_scrollController.offset - ScrollHeight.getScrollHeight(context), duration: Duration(milliseconds: 1000), curve: Curves.ease);
  }

  scrollToTop() {
    print('scrollToTop');
    _scrollController.animateTo(0.0, duration: Duration(milliseconds: 1000), curve: Curves.ease);
  }

  @override
  void dispose() {
    // TODO: implement dispose
    if (widget.isOtherCmdType == true) {
      baseViewModel!.removeListener(_listenBaseViewModel);
    }
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Consumer<BaseViewModel>(
      builder: (context, model, child) {
        // Log.v('null screen showlist : ${model.showList}');
        // print('展示数据 : ${model.showList}-----${model.type}');
        if (model.type == 1) {
          return _getNormalView(model);
        } else {
          // get responseCode
          String responseCode = '';
          String responseMessage = '';
          for (int i = 0; i < model.showList.length; i++) {
            String elementName = model.showList[i][kName];
            if (elementName == 'responseCode' && (model.showList[i][kValue] != null)) {
              responseCode = model.showList[i][kValue];
            }
            if (elementName == 'responseMessage' && (model.showList[i][kValue] != null)) {
              responseMessage = model.showList[i][kValue];
              break;
            }
          }
          if (responseCode == 'ERROR') {
            return Container(
              color: Colors.white,
              padding: EdgeInsets.symmetric(horizontal: 20),
              child: Column(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  TextField(
                    textAlign: TextAlign.center,
                    readOnly: true,
                    controller: TextEditingController(text: responseCode),
                    style: kMainUserInputStyle,
                    decoration: InputDecoration(
                      enabledBorder: UnderlineInputBorder(
                        borderSide: BorderSide(
                          color: kDividerColor,
                          width: 0.5,
                        ),
                      ),
                    ),
                  ),
                  TextField(
                    textAlign: TextAlign.center,
                    readOnly: true,
                    controller: TextEditingController(text: responseMessage),
                    style: kMainUserInputStyle,
                    decoration: InputDecoration(
                      enabledBorder: UnderlineInputBorder(
                        borderSide: BorderSide(
                          color: kDividerColor,
                          width: 0.5,
                        ),
                      ),
                    ),
                  ),
                ],
              ),
            );
          } else {
            return _getNormalView(model);
          }
        }
      },
    );
  }

  Widget _getNormalView(BaseViewModel model) {
    return Container(
      color: widget.color,
      child: ListView.builder(
        controller: _scrollController,
        itemCount: model.showList!.length,
        itemBuilder: (BuildContext context, int index) {
          Map map = model.showList![index];

          /// show
          DataItemType requestItemType = map[kType];

          /// enum cell
          if (requestItemType == DataItemType.Menu) {
            return MenuItemView(
              menuBtnKeyString: map[kMenuID],
              key: Key(map[kID]),
              list: map[kData],
              title: map[kName],
              type: widget.type!,
              selectedCallback: (dynamic value) {
                map[kValue] = value;

                if (widget.command == Command.FULLINTEGRATION) {
                  _requestDataBase!.setStrCurrentCommandFullIntegration = value.toString();
                  model.updateValue(
                      _requestDataBase!.strCurrentCommandFullIntegration!, map[kID], value, _requestDataBase!, !_mutiCommandViewModel!.prepareMutiCommand); // update value ; not contain command type
                  model.checkCmd(context, map[kID], value, _requestDataBase!.strCurrentCommandFullIntegration!, !_mutiCommandViewModel!.prepareMutiCommand); // update command type ; only command type
                } else if (widget.command == Command.MANAGE) {
                  _requestDataBase!.setStrCurrentCommandManage = value.toString();
                  model.updateValue(
                      _requestDataBase!.strCurrentCommandManage!, map[kID], value, _requestDataBase!, !_mutiCommandViewModel!.prepareMutiCommand); // update value ; not contain command type
                  model.checkCmd(context, map[kID], value, _requestDataBase!.strCurrentCommandManage!, !_mutiCommandViewModel!.prepareMutiCommand); // update command type ; only command type
                } else if (widget.command == Command.CUSTOMFORMMANAGE) {
                  _requestDataBase!.setStrCurrentCommandCustomformmanage = value.toString();
                  model.updateValue(
                      _requestDataBase!.strCurrentCommandCustomformmanage!, map[kID], value, _requestDataBase!, !_mutiCommandViewModel!.prepareMutiCommand); // update value ; not contain command type
                  model.checkCmd(context, map[kID], value, _requestDataBase!.strCurrentCommandCustomformmanage!, !_mutiCommandViewModel!.prepareMutiCommand); // update command type ; only command type
                } else if (widget.command == Command.DEVICE) {
                  _requestDataBase!.setStrCurrentCommandDevice = value.toString();
                  model.updateValue(
                      _requestDataBase!.strCurrentCommandDevice!, map[kID], value, _requestDataBase!, !_mutiCommandViewModel!.prepareMutiCommand); // update value ; not contain command type
                  model.checkCmd(context, map[kID], value, _requestDataBase!.strCurrentCommandDevice!, !_mutiCommandViewModel!.prepareMutiCommand); // update command type ; only command type
                } else if (widget.command == Command.PAYLOAD) {
                  _requestDataBase!.setStrCurrentCommandPayload = value.toString();
                  model.updateValue(
                      _requestDataBase!.strCurrentCommandPayload!, map[kID], value, _requestDataBase!, !_mutiCommandViewModel!.prepareMutiCommand); // update value ; not contain command type
                  model.checkCmd(context, map[kID], value, _requestDataBase!.strCurrentCommandPayload!, !_mutiCommandViewModel!.prepareMutiCommand); // update command type ; only command type
                } else if (widget.command == Command.PED) {
                  _requestDataBase!.setStrCurrentCommandPed = value.toString();
                  model.updateValue(_requestDataBase!.strCurrentCommandPed!, map[kID], value, _requestDataBase!, !_mutiCommandViewModel!.prepareMutiCommand); // update value ; not contain command type
                  model.checkCmd(context, map[kID], value, _requestDataBase!.strCurrentCommandPed!, !_mutiCommandViewModel!.prepareMutiCommand); // update command type ; only command type
                } else if (widget.command == Command.FORM) {
                  _requestDataBase!.setStrCurrentCommandForm = value.toString();
                  model.updateValue(
                      _requestDataBase!.strCurrentCommandForm!, map[kID], value, _requestDataBase!, !_mutiCommandViewModel!.prepareMutiCommand); // update value ; not contain command type
                  model.checkCmd(context, map[kID], value, _requestDataBase!.strCurrentCommandForm!, !_mutiCommandViewModel!.prepareMutiCommand); // update command type ; only command type
                } else {
                  map[kValue] = value;
                  model.checkCmd(context, map[kID], value, "", !_mutiCommandViewModel!.prepareMutiCommand); // update command type ; only command type
                }
              },
              initValue: map[kValue] ?? '',
              level: map[kLevel],
            );
          }

          /// group cell
          else if (requestItemType == DataItemType.Group) {
            return GroupItem(
              key: Key(map[kID]),
              open: map[kGroupArrowOpen],
              groupName: map[kName],
              level: map[kLevel],
              type: widget.type!,
              bitmapSign: map[kBitmapEnable],
              groupInfoCallback: () {
                model.refreshWhenGroupClicked(map[kLevel], map[kID]);
              },
              refreshBitmapSwitch: (bool value) {
                map[kBitmapEnable] = value;
                map[kGroupArrowOpen] = !value;
                model.refreshWhenBitmapSwitchClicked(map[kLevel], map[kID]);
              },
            );
          }

          /// model list
          else if (requestItemType == DataItemType.ModelList) {
            return ModelListItem(
              key: Key(map[kID]),
              propertys: map[kValue],
              level: map[kLevel],
              labelText: map[kName],
              enable: widget.type! == 1 ? true : false,
              className: map[kClass],
              itemList: map[kData],
              callback: (value) {
                setState(() {
                  map[kData] = value;
                });
              },
            );
          }

          /// string list
          else if (requestItemType == DataItemType.StringList) {
            return StringListItem(
              type: widget.type!,
              level: map[kLevel],
              labelText: map[kName],
              dataList: map[kData] ?? const [],
              callback: (value) {
                setState(() {
                  map[kData] = value;
                });
              },
            );
          } else if (requestItemType == DataItemType.Boolen) {
            return BoolenItem(
              level: map[kLevel],
              type: widget.type!,
              value: map[kValue] ?? false,
              title: map[kName],
              selectedCallback: (value) {
                setState(() {
                  map[kValue] = value;
                });
              },
            );
          }

          /// input cell
          else {
            return InputItem(
              key: Key(map[kID]),
              level: map[kLevel],
              labelText: map[kName],
              initValue: map[kValue] ?? '',
              attribute: map[kTextAttribute] ?? 2, // 2 ans,1 number
              suffixButtonTitle: map[kTextFieldButtonName] ?? null,
              enable: map[kEnable],
              unit: map[kUnit],
              updateInput: (String value) {
                map[kValue] = value;
                //
                if (widget.command == Command.FULLINTEGRATION) {
                  model.updateValue(_requestDataBase!.strCurrentCommandFullIntegration!, map[kID], value, _requestDataBase!, !_mutiCommandViewModel!.prepareMutiCommand);
                } else if (widget.command == Command.MANAGE) {
                  model.updateValue(_requestDataBase!.strCurrentCommandManage!, map[kID], value, _requestDataBase!, !_mutiCommandViewModel!.prepareMutiCommand);
                } else if (widget.command == Command.CUSTOMFORMMANAGE) {
                  model.updateValue(_requestDataBase!.strCurrentCommandCustomformmanage!, map[kID], value, _requestDataBase!, !_mutiCommandViewModel!.prepareMutiCommand);
                } else if (widget.command == Command.DEVICE) {
                  model.updateValue(_requestDataBase!.strCurrentCommandDevice!, map[kID], value, _requestDataBase!, !_mutiCommandViewModel!.prepareMutiCommand);
                } else if (widget.command == Command.PAYLOAD) {
                  model.updateValue(_requestDataBase!.strCurrentCommandPayload!, map[kID], value, _requestDataBase!, !_mutiCommandViewModel!.prepareMutiCommand);
                } else if (widget.command == Command.PED) {
                  model.updateValue(_requestDataBase!.strCurrentCommandPed!, map[kID], value, _requestDataBase!, !_mutiCommandViewModel!.prepareMutiCommand);
                } else if (widget.command == Command.FORM) {
                  model.updateValue(_requestDataBase!.strCurrentCommandForm!, map[kID], value, _requestDataBase!, !_mutiCommandViewModel!.prepareMutiCommand);
                } else {
                  model.updateValue('', map[kID], value, _requestDataBase!, !_mutiCommandViewModel!.prepareMutiCommand);
                }
              },
            );
          }
        },
      ),
    );
  }
}

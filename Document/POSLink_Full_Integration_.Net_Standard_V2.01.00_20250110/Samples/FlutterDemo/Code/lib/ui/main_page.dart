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

import 'dart:ffi';
import 'dart:io';

import 'package:flutter/material.dart';
import 'package:fluttertoast/fluttertoast.dart';
import 'package:poslink2/generated/l10n.dart';
import 'package:poslink2/model/comm_setting_view_model.dart';
import 'package:poslink2/model/customformmanage_view_model.dart';
import 'package:poslink2/model/device_view_model.dart';
import 'package:poslink2/model/event_channel.dart';
import 'package:poslink2/model/form_view_model.dart';
import 'package:poslink2/model/full_integration_view_model.dart';
import 'package:poslink2/model/manage_view_model.dart';
import 'package:poslink2/model/multicommand_view_model.dart';
import 'package:poslink2/model/payload_view_model.dart';
import 'package:poslink2/model/ped_view_model.dart';
import 'package:poslink2/model/report_status_view_model.dart';
import 'package:poslink2/model/request_db.dart';
import 'package:poslink2/model/response_db.dart';
import 'package:poslink2/res/colors.dart';
import 'package:poslink2/res/size_fit.dart';
import 'package:poslink2/ui/full_integration_callback_view/enter_pin_page.dart';
import 'package:poslink2/ui/full_integration_callback_view/input_page.dart';
import 'package:poslink2/ui/full_integration_callback_view/search_card_page.dart';
import 'package:poslink2/ui/full_integration_callback_view/select_list_page.dart';
import 'package:poslink2/ui/main_menu.dart';
import 'package:poslink2/widget/add_muticommand_view.dart';
import 'package:poslink2/widget/stack_button.dart';
import 'package:provider/provider.dart';
import 'package:provider/src/provider.dart';

import '../auto_data_source/auto_data_source_common.dart';
import '../model/android_view_model.dart';
import '../model/base_view_model.dart';
import '../model/log_setting_view_model.dart';
import '../model/main_page_view_model.dart';
import '../model/method_channel.dart';
import 'initialize_item.dart';

class MainPage extends StatefulWidget {
  @override
  State<StatefulWidget> createState() => _MainPageState();
}

class _MainPageState extends State<MainPage> {
  bool loading = false;
  bool showStop = false;
  bool _showDrawer = true;
  bool _showBottomBar = true;
  int _clearSign = 1;

  late Function(String event, Map<String, dynamic> paramsMap) listener;

  late LogSettingViewModel logSettingViewModel;
  late FullIntegrationViewModel fullIntegrationViewModel;
  late MutiCommandViewModel mutiCommandViewModel;
  late FormViewModel formViewModel;
  late ManageViewModel manageViewModel;
  late PedViewModel pedViewModel;
  late PayloadViewModel payloadViewModel;
  late CustomFormManageModel customFormManageModel;
  late DeviceViewModel deviceViewModel;
  late RequestDataBase requestDataBase;
  late ResponseDataBase responseDataBase;
  late CommSettingViewModel commSettingViewModel;
  late ReportStatusViewModel reportStatusViewModel;
  late MainPageViewModel mainPageViewModel;

  bool processingDialogShowing = false;
  bool warningDialogShowing = false;

  int _clickScrollLUSign = 0;
  int _clickScrollRUSign = 0;
  double _scrollFontSize = 8;
  // int _clearSign = 1;
  Color _scrollTextColor = Colors.transparent;

  @override
  void initState() {
    if (Platform.isAndroid == false) {
      LogSettingViewModel().save();
    }
    mainPageViewModel = context.read<MainPageViewModel>();
    fullIntegrationViewModel = context.read<FullIntegrationViewModel>();
    logSettingViewModel = context.read<LogSettingViewModel>();
    requestDataBase = context.read<RequestDataBase>();
    responseDataBase = context.read<ResponseDataBase>();
    mutiCommandViewModel = context.read<MutiCommandViewModel>();
    formViewModel = context.read<FormViewModel>();
    manageViewModel = context.read<ManageViewModel>();
    pedViewModel = context.read<PedViewModel>();
    payloadViewModel = context.read<PayloadViewModel>();
    customFormManageModel = context.read<CustomFormManageModel>();
    deviceViewModel = context.read<DeviceViewModel>();
    commSettingViewModel = context.read<CommSettingViewModel>();
    reportStatusViewModel = context.read<ReportStatusViewModel>();

    mutiCommandViewModel.addListener(() {
      setState(() {
        _showDrawer = !mutiCommandViewModel.prepareMutiCommand;
        _showBottomBar = !mutiCommandViewModel.prepareMutiCommand;
      });
    });

    listener = (event, paramsMap) {
      switch (event) {
        case "INPUT_ACCOUNT":
          bool swipe = paramsMap["supportSwipe"] ?? false;
          bool insert = paramsMap["supportInsert"] ?? false;
          bool tap = paramsMap["supportTap"] ?? false;
          bool keyin = paramsMap["supportKeyIn"] ?? false;
          bool outInput = paramsMap["supportInputArea"] ?? false;
          double amount;
          if (paramsMap["amount"] is int) {
            int value = paramsMap["amount"];
            amount = value.toDouble();
          } else {
            amount = paramsMap["amount"] ?? 0;
          }
          Navigator.of(context).push(
            MaterialPageRoute(
              builder: (context) => SearchCardPage(
                amount: amount,
                swipe: swipe,
                insert: insert,
                tap: tap,
                keyin: keyin,
                outInput: outInput,
              ),
            ),
          );
          break;
        case "PROCESSING":
          String code = paramsMap["code"] ?? "";
          String msg = paramsMap["msg"] ?? "";
          if (processingDialogShowing) {
            if (Navigator.of(context).canPop()) {
              Navigator.of(context).pop();
            }
            processingDialogShowing = false;
          }
          showDialog(
            context: context,
            barrierDismissible: false,
            builder: (context) => WillPopScope(
              onWillPop: () async {
                return false;
              },
              child: AlertDialog(
                title: Text("Processing"),
                content: Text(code + ", " + msg),
              ),
            ),
          );
          processingDialogShowing = true;
          break;
        case "FINISH_PROCESSING":
          if (processingDialogShowing) {
            if (Navigator.of(context).canPop()) {
              Navigator.of(context).pop();
            }
            processingDialogShowing = false;
          }
          break;
        case "WARNING":
          if (warningDialogShowing) {
            if (Navigator.of(context).canPop()) {
              Navigator.of(context).pop();
            }
            warningDialogShowing = false;
          }
          showDialog(
            context: context,
            barrierDismissible: false,
            builder: (context) => WillPopScope(
              onWillPop: () async {
                return false;
              },
              child: AlertDialog(
                title: Text("Remove Card"),
                content: Text("Please remove card"),
              ),
            ),
          );
          warningDialogShowing = true;
          break;
        case "FINISH_WARNING":
          if (warningDialogShowing) {
            if (Navigator.of(context).canPop()) {
              Navigator.of(context).pop();
            }
            warningDialogShowing = false;
          }
          break;
        case "INPUT":
          String action = paramsMap["action"];
          String title = "";
          String hint = "";
          Function(String content)? onConfirm;
          switch (action) {
            case "enterExpiryDate":
              title = "Expiry Date";
              hint = "MMYY";
              break;
            case "enterZip":
              title = "ZIP";
              hint = "length 0, 5, 6 or 9";
              break;
            case "enterCVV":
              title = "CVV";
              hint = "length 0, 3 or 4";
              break;
          }
          onConfirm = (content) {
            POSLinkMethodChannel().invokeMethod("INPUT", {"action": action, "content": content});
          };
          bool outInput = paramsMap["supportInputArea"] ?? false;
          bool skip = paramsMap["skip"] ?? false;
          int maxInputLength = paramsMap["maxInputLength"] ?? 0;
          Navigator.of(context).push(
            MaterialPageRoute(
              builder: (context) => InputPage(
                outInput: outInput,
                skip: skip,
                title: title,
                hint: hint,
                maxInputLength: maxInputLength,
                onConfirm: onConfirm,
              ),
            ),
          );
          break;
        case "SELECT":
          List<dynamic> list = paramsMap["list"];
          List<String> strList = [];
          list.forEach((element) {
            if (element is String) {
              strList.add(element);
            }
          });
          Navigator.of(context).push(
            MaterialPageRoute(
              builder: (context) => SelectListPage(
                list: strList,
                onSelect: (content) {
                  POSLinkMethodChannel().invokeMethod("SELECT", {"content": content});
                },
              ),
            ),
          );
          break;
        case "ENTER_PIN":
          Navigator.of(context).push(
            MaterialPageRoute(
              builder: (context) => EnterPinPage(),
            ),
          );
          break;
      }
    };
    POSLinkEventChannel().addListener(listener);
    super.initState();
  }

  @override
  void dispose() {
    POSLinkEventChannel().removeListener(listener);
    super.dispose();
  }

  void showMsg(String text) {
    showDialog(
        context: context,
        builder: (context) {
          return AlertDialog(
            content: Text(text),
            actions: [
              TextButton(
                onPressed: () {
                  Navigator.of(context).pop();
                },
                child: Text(S.of(context).confirm),
              )
            ],
          );
        });
  }

  void showAlertDialog() {
    showDialog<Null>(
        context: context,
        barrierDismissible: false,
        builder: (BuildContext context) {
          return new AlertDialog(
            title: new Text(
              'Opening the editing state will clear the current Multi Command data. Are you sure you want to open it?',
              style: kMainLabelStyle,
            ),
            //可滑动
            content: new SingleChildScrollView(
              child: new ListBody(
                children: <Widget>[],
              ),
            ),
            actions: <Widget>[
              new TextButton(
                child: new Text(
                  'YES',
                  style: TextStyle(color: Colors.red),
                ),
                onPressed: () {
                  mutiCommandViewModel.startMutiCommand(commSettingViewModel);
                  Navigator.of(context).pop();
                },
              ),
              new TextButton(
                child: new Text('NO'),
                onPressed: () {
                  Navigator.of(context).pop();
                },
              ),
            ],
          );
        });
  }

  // 获取tabbar顶部
  List<Widget> getListWidget(CommSettingViewModel viewModel) {
    /// stop start button
    List<Widget> actionList = [];

    if (viewModel.currentTab == CurrentTabEnum.TAB_LOG_SETTING) {
      actionList.add(IconButton(
        onPressed: () async {
          FocusScope.of(context).requestFocus(FocusNode());
          await logSettingViewModel.save();
          Fluttertoast.showToast(msg: "Saved");
        },
        icon: Icon(Icons.done),
      ));
    } else if (viewModel.currentTab == CurrentTabEnum.TAB_COMM_SETTING) {
      if (loading) {
        actionList.add(Center(
          child: Container(
            margin: EdgeInsets.symmetric(horizontal: 10),
            height: 20,
            width: 20,
            child: CircularProgressIndicator(
              color: Colors.white,
            ),
          ),
        ));
      } else {
        actionList.add(IconButton(
          onPressed: () async {
            FocusScope.of(context).requestFocus(FocusNode());
            if (commSettingViewModel.timeout == 0) {
              Fluttertoast.showToast(msg: "Timeout invalid");
              return;
            }
            setState(() {
              loading = true;
            });
            await commSettingViewModel.save();
            bool refreshSuccess = await commSettingViewModel.refresh();
            setState(() {
              loading = false;
            });
            Fluttertoast.showToast(
              msg: refreshSuccess ? "Detect the target device succeeded." : "Can not detect the target device.",
              toastLength: Toast.LENGTH_SHORT,
            );
          },
          icon: Icon(Icons.refresh),
        ));

        actionList.add(IconButton(
          onPressed: () async {
            FocusScope.of(context).requestFocus(FocusNode());
            if (commSettingViewModel.timeout == 0) {
              Fluttertoast.showToast(msg: "Timeout invalid");
              return;
            }
            setState(() {
              loading = true;
            });
            await commSettingViewModel.save();
            bool handshakeSuccess = await commSettingViewModel.handshake();
            setState(() {
              loading = false;
            });
            Fluttertoast.showToast(msg: handshakeSuccess ? "Saved" : "Can not detect the target device.");
          },
          icon: Icon(Icons.done),
        ));
      }
    } else if (viewModel.currentTab == CurrentTabEnum.TAB_SEND_COMMAND) {
      if (loading) {
        /// tcp stop action
        if (showStop) {
          actionList.add(IconButton(
            onPressed: () async {
              Fluttertoast.showToast(msg: "Attempting to abort");
              await viewModel.cancel();
            },
            icon: Icon(Icons.stop),
          ));
        }
        actionList.add(Center(
          child: Container(
            margin: EdgeInsets.symmetric(horizontal: 10),
            height: 20,
            width: 20,
            child: CircularProgressIndicator(
              color: Colors.white,
            ),
          ),
        ));
      } else {
        actionList.add(IconButton(
          onPressed: () async {
            setState(() {
              FocusScope.of(context).requestFocus(FocusNode());
              loading = true;
              _showDrawer = false;
            });
            try {
              AndroidViewModel androidViewModel = context.read<AndroidViewModel>();
              await androidViewModel.sendRawCommand(commSettingViewModel);
            } catch (e, stackTrace) {
              print(e);
              print(stackTrace);
              showMsg(e.toString());
            }
            setState(() {
              loading = false;
              showStop = false;
              _showDrawer = true;
            });
          },
          icon: Icon(Icons.play_arrow),
        ));
      }
    } else {
      if (loading) {
        /// tcp stop action
        if (showStop) {
          actionList.add(Consumer<MainPageViewModel>(
            builder: (context, mainPageVM, child) {
              return (mainPageVM.tabBarIsAtRequest == true || !TTSizeFit.isPortrait)
                  ? IconButton(
                      onPressed: () async {
                        Fluttertoast.showToast(msg: "Attempting to abort");
                        await viewModel.cancel();
                      },
                      icon: Icon(Icons.stop),
                    )
                  : Text('');
            },
          ));
        }
        actionList.add(Consumer<MainPageViewModel>(
          builder: (context, mainPageVM, child) {
            return (mainPageVM.tabBarIsAtRequest == true || !TTSizeFit.isPortrait)
                ? Center(
                    child: Container(
                      margin: EdgeInsets.symmetric(horizontal: 10),
                      height: 20,
                      width: 20,
                      child: CircularProgressIndicator(
                        color: Colors.white,
                      ),
                    ),
                  )
                : Text('');
          },
        ));
      } else if (viewModel.currentTab == CurrentTabEnum.TAB_MULTI_COMMAND) {
        actionList.add(Consumer<MutiCommandViewModel>(
          builder: (context, mutiCommandViewModel, child) {
            return mutiCommandViewModel.isDoingMutiCommand == false
                ? Switch(
                    activeColor: Colors.white,
                    value: mutiCommandViewModel.prepareMutiCommand,
                    onChanged: (value) {
                      if (value == true) {
                        if (mutiCommandViewModel.mutiCommands.length > 0 || mutiCommandViewModel.mutiCommandsRsps.length > 0) {
                          showAlertDialog();
                        } else {
                          mutiCommandViewModel.startMutiCommand(commSettingViewModel);
                        }
                      } else {
                        if (mutiCommandViewModel.prepareMutiCommand == true) {
                          mutiCommandViewModel.changePrepareMutiCommandStatus(false);
                        }
                        // if (mutiCommandViewModel.isDoingMutiCommand == true) {
                        mutiCommandViewModel.cancelMutiCommand(commSettingViewModel);
                        // }
                      }
                    },
                  )
                : IconButton(
                    onPressed: () async {
                      Fluttertoast.showToast(msg: "Attempting to abort");
                      await commSettingViewModel.cancel();
                      // mutiCommandViewModel.cancelMutiCommand(commSettingViewModel);
                    },
                    icon: Icon(
                      Icons.stop,
                      size: 30,
                    ),
                  );
          },
        ));

        actionList.add(
          Consumer<MutiCommandViewModel>(
            builder: (context, mutiCommandViewModel, child) {
              return mutiCommandViewModel.prepareMutiCommand == false
                  ? Text('')
                  : mutiCommandViewModel.isDoingMutiCommand == false
                      ? Padding(
                          padding: EdgeInsets.only(right: 15, left: 15),
                          child: PopupMenuButton(
                            tooltip: "Add request",
                            child: Icon(
                              Icons.add,
                              color: Colors.white,
                            ),
                            onSelected: (CurrentTabEnum value) async {
                              await Navigator.of(context).push(
                                MaterialPageRoute(
                                  builder: (context) => AddMutiCommandView(
                                    tab: value.stringValue,
                                    type: 1,
                                    editType: 1,
                                  ),
                                ),
                              );
                            },
                            offset: Offset(1, 60),
                            itemBuilder: (context) {
                              return [
                                PopupMenuItem(
                                  value: CurrentTabEnum.TAB_FULL_INTEGRATION,
                                  child: Text('FullIntegration'),
                                ),
                                PopupMenuItem(
                                  value: CurrentTabEnum.TAB_MANAGE,
                                  child: Text('Manage'),
                                ),
                                PopupMenuItem(
                                  value: CurrentTabEnum.TAB_FORM,
                                  child: Text('Form'),
                                ),
                                PopupMenuItem(
                                  value: CurrentTabEnum.TAB_DEVICE,
                                  child: Text('Device'),
                                ),
                                // PopupMenuItem(
                                //   value: CommSettingViewModel.TAB_PAYLOAD,
                                //   child: Text('Payload'),
                                // ),
                                PopupMenuItem(
                                  value: CurrentTabEnum.TAB_PED,
                                  child: Text('PED'),
                                ),
                                // PopupMenuItem(
                                //   value: CommSettingViewModel.TAB_CUSTOM_FORM_MANAGE,
                                //   child: Text('CustomFormManage'),
                                // ),
                              ];
                            },
                          ),
                        )
                      : Padding(
                          padding: EdgeInsets.only(right: 10, left: 10),
                          child: Center(
                            child: Container(
                              margin: EdgeInsets.symmetric(horizontal: 10),
                              height: 20,
                              width: 20,
                              child: CircularProgressIndicator(
                                color: Colors.white,
                              ),
                            ),
                          ),
                        );
            },
          ),
        );
      } else {
        actionList.add(Consumer<MainPageViewModel>(
          builder: (context, mainPageVM, child) {
            return (mainPageVM.tabBarIsAtRequest == true || !TTSizeFit.isPortrait)
                ? Platform.isWindows
                    ? StackButton(
                        labelText: 'start',
                        iconData: Icons.play_arrow,
                        click: () async {
                          await startAction(viewModel);
                        },
                      )
                    : IconButton(
                        onPressed: () async {
                          await startAction(viewModel);
                        },
                        icon: Icon(Icons.play_arrow))
                : Text('');
          },
        ));
      }
    }
    return actionList;
  }

  List<Map> _getErrorRspList(dynamic value) {
    List<Map> rspDataSource = value;
    for (int i = 0; i < rspDataSource.length; i++) {
      String elementName = rspDataSource[i][kName];
      if (elementName == 'responseCode') {
        rspDataSource[i][kValue] = 'ERROR';
      }
      if (elementName == 'responseMessage') {
        rspDataSource[i][kValue] = 'Can’t detect the target device. Please set Comm Setting, then click refresh button.';
        break;
      }
    }
    return rspDataSource;
  }

  startAction(CommSettingViewModel viewModel) async {
    setState(() {
      FocusScope.of(context).requestFocus(FocusNode());
      loading = true;
      _showDrawer = false;
    });
    reportStatusViewModel.stop = false;
    reportStatusViewModel.startPolling();
    try {
      /// setting
      await viewModel.setSetting();

      bool handshakeSuccess = await viewModel.handshake();
      if (!handshakeSuccess) {
        /// 防止握手失败页面无响应
        if (viewModel.currentTab == CurrentTabEnum.TAB_FULL_INTEGRATION) {
          List<Map> errRspList = _getErrorRspList(responseDataBase.fullIntegrationData);
          responseDataBase.setFullIntegrationData = errRspList;
          responseDataBase.refresh(errRspList, Command.FULLINTEGRATION);
          fullIntegrationKey.currentState?.updateTab(1);
        } else if (viewModel.currentTab == CurrentTabEnum.TAB_MANAGE) {
          List<Map> errRspList = _getErrorRspList(responseDataBase.manageData);
          responseDataBase.setManageData = errRspList;
          responseDataBase.refresh(errRspList, Command.MANAGE);
          manageKey.currentState?.updateTab(1);
        } else if (viewModel.currentTab == CurrentTabEnum.TAB_FORM) {
          List<Map> errRspList = _getErrorRspList(responseDataBase.formData);
          responseDataBase.setFormData = errRspList;
          responseDataBase.refresh(errRspList, Command.FORM);
          formKey.currentState?.updateTab(1);
        } else if (viewModel.currentTab == CurrentTabEnum.TAB_DEVICE) {
          List<Map> errRspList = _getErrorRspList(responseDataBase.deviceData);
          responseDataBase.setDeviceData = errRspList;
          responseDataBase.refresh(errRspList, Command.DEVICE);
          deviceKey.currentState?.updateTab(1);
        } else if (viewModel.currentTab == CurrentTabEnum.TAB_PED) {
          List<Map> errRspList = _getErrorRspList(responseDataBase.pedData);
          responseDataBase.setPedData = errRspList;
          responseDataBase.refresh(errRspList, Command.PED);
          pedKey.currentState?.updateTab(1);
        }
        throw HandshakeException();
      }

      setState(() {
        showStop = true;
      });

      if (viewModel.currentTab == CurrentTabEnum.TAB_FULL_INTEGRATION) {
        await fullIntegrationViewModel.start(viewModel, responseDataBase, requestDataBase.readFullIntegrationData(requestDataBase.strCurrentCommandFullIntegration)!);
        fullIntegrationKey.currentState?.updateTab(1);
        reportStatusViewModel.stop = true;
      } else if (viewModel.currentTab == CurrentTabEnum.TAB_MANAGE) {
        await manageViewModel.startManage(viewModel, responseDataBase, requestDataBase.readManageData(requestDataBase.strCurrentCommandManage)!);
        manageKey.currentState!.updateTab(1);
        reportStatusViewModel.stop = true;
      } else if (viewModel.currentTab == CurrentTabEnum.TAB_DEVICE) {
        await deviceViewModel.startDevice(viewModel, responseDataBase, requestDataBase.readDeviceData(requestDataBase.strCurrentCommandDevice)!);
        deviceKey.currentState!.updateTab(1);
        reportStatusViewModel.stop = true;
      }
      // else if (viewModel.currentTab ==
      //     CurrentTabEnum.TAB_PAYLOAD) {
      //   await payloadViewModel.startPayload(
      //       viewModel,
      //       responseDataBase,
      //       requestDataBase.payloadData!);
      //   _payloadKey.currentState!.updateTab(1);
      //   reportStatusViewModel.stop = true;
      // }
      else if (viewModel.currentTab == CurrentTabEnum.TAB_PED) {
        await pedViewModel.startPed(viewModel, responseDataBase, requestDataBase.readPedData(requestDataBase.strCurrentCommandPed)!);
        pedKey.currentState!.updateTab(1);
        reportStatusViewModel.stop = true;
      } else if (viewModel.currentTab == CurrentTabEnum.TAB_FORM) {
        await formViewModel.startForm(viewModel, responseDataBase, requestDataBase.readFormData(requestDataBase.strCurrentCommandForm)!);
        formKey.currentState!.updateTab(1);
        reportStatusViewModel.stop = true;
      }
    } on HandshakeException {
      Fluttertoast.showToast(
        msg: "Can't detect the target device. Please set Communication Setting, then click refresh button.",
        toastLength: Toast.LENGTH_LONG,
      );
    } catch (e, stackTrace) {
      print(e);
      print(stackTrace);
      showMsg(e.toString());
      reportStatusViewModel.stop = true;
    }
    setState(() {
      loading = false;
      showStop = false;
      _showDrawer = true;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Consumer<CommSettingViewModel>(
      builder: (context, viewModel, child) {
        if (Platform.isAndroid) {
          return _getView(viewModel, TTSizeFit.aspectRatio < 1);
        } else {
          return OrientationBuilder(builder: (BuildContext context, Orientation orientation) {
            print('mainpage---$orientation');
            return _getView(viewModel, orientation == Orientation.portrait);
          });
        }
      },
    );
  }

  _clickScrollToRequestTop() {
    _notifyScroll(5);
  }

  _clickScrollToResponseTop() {
    _notifyScroll(6);
  }

  _clickScrollLU() {
    if (_clickScrollLUSign >= 1) {
      _notifyScroll(1);
      _clickScrollLUSign = 0;
    } else {
      _clickScrollLUSign += 1;
    }
  }

  _clickScrollRU() {
    if (_clickScrollRUSign >= 1) {
      _notifyScroll(3);
      _clickScrollRUSign = 0;
    } else {
      _clickScrollRUSign += 1;
    }
  }

  _notifyScroll(int type) {
    if (commSettingViewModel.currentTab == CurrentTabEnum.TAB_FULL_INTEGRATION) {
      switch (type) {
        case 1:
          fullIntegrationKey.currentState?.scrollUpRequest();
          break;
        case 3:
          fullIntegrationKey.currentState?.scrollUpResponse();
          break;
        case 5:
          fullIntegrationKey.currentState?.scrollToTopRequest();
          break;
        case 6:
          fullIntegrationKey.currentState?.scrollToTopResponse();
          break;
      }
    } else if (commSettingViewModel.currentTab == CurrentTabEnum.TAB_MANAGE) {
      switch (type) {
        case 1:
          manageKey.currentState?.scrollUpRequest();
          break;
        case 3:
          manageKey.currentState?.scrollUpResponse();
          break;
        case 5:
          manageKey.currentState?.scrollToTopRequest();
          break;
        case 6:
          manageKey.currentState?.scrollToTopResponse();
          break;
      }
    } else if (commSettingViewModel.currentTab == CurrentTabEnum.TAB_FORM) {
      switch (type) {
        case 1:
          formKey.currentState?.scrollUpRequest();
          break;
        case 3:
          formKey.currentState?.scrollUpResponse();
          break;
        case 5:
          formKey.currentState?.scrollToTopRequest();
          break;
        case 6:
          formKey.currentState?.scrollToTopResponse();
          break;
      }
    } else if (commSettingViewModel.currentTab == CurrentTabEnum.TAB_DEVICE) {
      switch (type) {
        case 1:
          deviceKey.currentState?.scrollUpRequest();
          break;
        case 3:
          deviceKey.currentState?.scrollUpResponse();
          break;
        case 5:
          deviceKey.currentState?.scrollToTopRequest();
          break;
        case 6:
          deviceKey.currentState?.scrollToTopResponse();
          break;
      }
    } else if (commSettingViewModel.currentTab == CurrentTabEnum.TAB_PED) {
      switch (type) {
        case 1:
          pedKey.currentState?.scrollUpRequest();
          break;
        case 3:
          pedKey.currentState?.scrollUpResponse();
          break;
        case 5:
          pedKey.currentState?.scrollToTopRequest();
          break;
        case 6:
          pedKey.currentState?.scrollToTopResponse();
          break;
      }
    }
  }

  _appBarTitle(CommSettingViewModel viewModel) {
    return Container(
      color: Colors.transparent,
      width: 140,
      child: Stack(
        alignment: Alignment.center,
        children: [
          Center(
            child: Text(viewModel.currentTab.homeItemTitle),
          ),
          Container(
            child: Row(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                Column(
                  children: [
                    GestureDetector(
                      onTap: () {
                        if (Platform.isWindows) {
                          _clickScrollLU();
                        } else {
                          if (mainPageViewModel.tabBarIsAtRequest) {
                            _clickScrollLU();
                          }
                        }
                      },
                      child: Text(
                        'scroll-l-u',
                        style: TextStyle(fontSize: _scrollFontSize, color: _scrollTextColor),
                      ),
                    ),
                    GestureDetector(
                      onTap: () {
                        if (_clearSign >= 7) {
                          _clearSign = 1;
                          // transactionKey.currentState!.refresh();
                        } else {
                          _clearSign += 1;
                        }
                      },
                      child: Text(
                        'cl-rq-rs',
                        style: TextStyle(fontSize: _scrollFontSize, color: _scrollTextColor),
                      ),
                    ),
                    GestureDetector(
                      onTap: () {
                        if (Platform.isWindows) {
                          _clickScrollToRequestTop();
                        } else {
                          if (mainPageViewModel.tabBarIsAtRequest) {
                            _clickScrollToRequestTop();
                          }
                        }
                      },
                      child: Text(
                        'scrtopl',
                        style: TextStyle(fontSize: _scrollFontSize, color: _scrollTextColor),
                      ),
                    ),
                  ],
                ),
                SizedBox(width: 5),
                Column(
                  children: [
                    GestureDetector(
                      onTap: () {
                        FocusScopeNode focusScopeNode = FocusScope.of(context);
                        if (!focusScopeNode.hasPrimaryFocus && focusScopeNode.focusedChild != null) {
                          FocusManager.instance.primaryFocus?.unfocus();
                        }
                      },
                      child: Text(
                        'kbdown',
                        style: TextStyle(fontSize: _scrollFontSize, color: _scrollTextColor),
                      ),
                    ),
                  ],
                ),
                SizedBox(width: 5),
                Column(
                  children: [
                    GestureDetector(
                      onTap: () {
                        if (Platform.isWindows) {
                          _clickScrollRU();
                        } else {
                          if (!mainPageViewModel.tabBarIsAtRequest) {
                            _clickScrollRU();
                          }
                        }
                      },
                      child: Text(
                        'scroll-r-u',
                        style: TextStyle(fontSize: _scrollFontSize, color: _scrollTextColor),
                      ),
                    ),
                    GestureDetector(
                      onTap: () {
                        if (Platform.isWindows) {
                          _clickScrollToResponseTop();
                        } else {
                          if (!mainPageViewModel.tabBarIsAtRequest) {
                            _clickScrollToResponseTop();
                          }
                        }
                      },
                      child: Text(
                        'scrtopr',
                        style: TextStyle(fontSize: _scrollFontSize, color: _scrollTextColor),
                      ),
                    ),
                  ],
                ),
              ],
            ),
          )
        ],
      ),
    );
  }

  Widget _getView(CommSettingViewModel viewModel, bool portrait) {
    if (portrait) {
      TTSizeFit.isPortrait = true;
      return Scaffold(
        appBar: AppBar(
          automaticallyImplyLeading: _showDrawer,
          backgroundColor: kMainColor,
          elevation: 0,
          title: _appBarTitle(viewModel),
          actions: getListWidget(viewModel),
        ),
        drawer: MainMenu(),
        drawerEnableOpenDragGesture: _showDrawer,
        body: IgnorePointer(
          ignoring: loading,
          child: getPortraitHomeItem(viewModel),
        ),
      );
    } else {
      // 横屏
      TTSizeFit.isPortrait = false;
      if (!Platform.isAndroid) HomeItems.removeWhere((element) => element.label == 'Send Cmd');
      return Scaffold(
        appBar: AppBar(
          backgroundColor: kMainColor,
          elevation: 0,
          title: _appBarTitle(viewModel),
          actions: getListWidget(viewModel),
        ),
        body: IgnorePointer(
          ignoring: loading,
          child: IndexedStack(
            index: viewModel.currentTab.index,
            children: HomePages,
          ),
        ),
        bottomNavigationBar: Offstage(
          offstage: !_showBottomBar, // 隐藏底部
          child: BottomNavigationBar(
            selectedItemColor: Colors.black,
            unselectedItemColor: Colors.black,
            type: BottomNavigationBarType.fixed,
            currentIndex: viewModel.currentTab.index,
            items: HomeItems,
            onTap: (index) {
              if (!_showDrawer) {
                // 拒绝点击
                return;
              }
              if (viewModel.currentTab != CurrentTabEnum.values[index]) {
                mainPageViewModel.changeStatus(true);
              }
              viewModel.currentTab = CurrentTabEnum.values[index];
            },
          ),
        ),
      );
    }
  }
}

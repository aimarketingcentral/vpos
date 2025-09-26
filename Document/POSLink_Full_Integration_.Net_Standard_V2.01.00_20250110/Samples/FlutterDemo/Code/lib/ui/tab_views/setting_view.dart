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

import 'dart:async';
import 'dart:io';

import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:fluttertoast/fluttertoast.dart';
import 'package:poslink2/auto_pigeon/poslink_android.dart';
import 'package:poslink2/generated/l10n.dart';
import 'package:poslink2/model/comm_setting_view_model.dart';
import 'package:poslink2/widget/bluetooth_dialog_widget.dart';
import 'package:provider/provider.dart';

import '../../auto_pigeon/poslink_sdk_bt_search.dart';
import '../../res/colors.dart';
import '../../widget/usb_dialog_widget.dart';

class SettingView extends StatefulWidget {
  @override
  State<StatefulWidget> createState() => _SettingViewState();
}

class _SettingViewState extends State<SettingView> {
  late List<String> typeList;

  bool _scan = false;
  List<BTDevice?> btList = [];

  List<String> baudrateList = ["9600", "115200"];

  FocusNode _macAddrFocusNode = FocusNode();
  bool _macAddrFocus = false;

  FocusNode _usbDevFocusNode = FocusNode();
  bool _usbDevFocus = false;

  late TextEditingController _timeoutController;
  late TextEditingController _ipController;
  late TextEditingController _portController;
  late TextEditingController _serialPortController;
  late TextEditingController _macAddrController;

  @override
  void initState() {
    if (Platform.isIOS) {
      typeList = ["TCP", "SSL", "HTTP", "HTTPS", "BT"];
    } else if (Platform.isWindows) {
      typeList = ["TCP", "SSL", "HTTP", "HTTPS", "UART"];
    } else {
      typeList = ["AIDL", "TCP", "HTTP", "HTTPS", "SSL", "USB", "UART", "BT"];
    }

    _macAddrFocusNode.addListener(() {
      _macAddrFocus = _macAddrFocusNode.hasFocus;
    });

    _usbDevFocusNode.addListener(() {
      _usbDevFocus = _usbDevFocusNode.hasFocus;
    });

    CommSettingViewModel viewModel = context.read<CommSettingViewModel>();

    _timeoutController = TextEditingController(
        text: viewModel.timeout == 0 ? "" : viewModel.timeout.toString());

    _ipController = TextEditingController(text: viewModel.ip ?? "");
    _portController = TextEditingController(text: viewModel.port ?? "");
    _serialPortController =
        TextEditingController(text: viewModel.serialPort ?? "");
    _macAddrController = TextEditingController.fromValue(
      TextEditingValue(
        text: viewModel.macAddr ?? "",
      ),
    );
    super.initState();
  }

  String _getShowMenuString(String string) {
    if (string.contains('.')) {
      List list = string.split('.');
      return list[1];
    }
    return string;
  }

  @override
  Widget build(BuildContext context) {
    List<PopupMenuItem<CommSettingType>> popItem = [];
    if (Platform.isIOS) {
      popItem.add(
        PopupMenuItem(
          value: CommSettingType.TCP,
          child: Text(typeList[0]),
        ),
      );
      popItem.add(
        PopupMenuItem(
          value: CommSettingType.SSL,
          child: Text(typeList[1]),
        ),
      );
      popItem.add(
        PopupMenuItem(
          value: CommSettingType.HTTP,
          child: Text(typeList[2]),
        ),
      );
      popItem.add(
        PopupMenuItem(
          value: CommSettingType.HTTPS,
          child: Text(typeList[3]),
        ),
      );
      popItem.add(
        PopupMenuItem(
          value: CommSettingType.BT,
          child: Text(typeList[4]),
        ),
      );
    } else if (Platform.isWindows) {
      popItem.add(
        PopupMenuItem(
          value: CommSettingType.TCP,
          child: Text(typeList[0]),
        ),
      );
      popItem.add(
        PopupMenuItem(
          value: CommSettingType.SSL,
          child: Text(typeList[1]),
        ),
      );
      popItem.add(
        PopupMenuItem(
          value: CommSettingType.HTTP,
          child: Text(typeList[2]),
        ),
      );
      popItem.add(
        PopupMenuItem(
          value: CommSettingType.HTTPS,
          child: Text(typeList[3]),
        ),
      );
      popItem.add(
        PopupMenuItem(
          value: CommSettingType.UART,
          child: Text(typeList[4]),
        ),
      );
    } else {
      popItem.add(
        PopupMenuItem(
          value: CommSettingType.AIDL,
          child: Text(typeList[0]),
        ),
      );
      popItem.add(
        PopupMenuItem(
          value: CommSettingType.TCP,
          child: Text(typeList[1]),
        ),
      );
      popItem.add(
        PopupMenuItem(
          value: CommSettingType.HTTP,
          child: Text(typeList[2]),
        ),
      );
      popItem.add(
        PopupMenuItem(
          value: CommSettingType.HTTPS,
          child: Text(typeList[3]),
        ),
      );
      popItem.add(
        PopupMenuItem(
          value: CommSettingType.SSL,
          child: Text(typeList[4]),
        ),
      );
      popItem.add(
        PopupMenuItem(
          value: CommSettingType.USB,
          child: Text(typeList[5]),
        ),
      );
      popItem.add(
        PopupMenuItem(
          value: CommSettingType.UART,
          child: Text(typeList[6]),
        ),
      );
      popItem.add(
        PopupMenuItem(
          value: CommSettingType.BT,
          child: Text(typeList[7]),
        ),
      );
    }
    return Consumer<CommSettingViewModel>(
      builder: (context, viewModel, child) {
        List<Widget> list = [
          PopupMenuButton(
            tooltip: "",
            itemBuilder: (context) {
              return popItem;
            },
            onSelected: (CommSettingType type) {
              viewModel.type = type;
            },
            offset: Offset(1, 30),
            child: Padding(
              padding: const EdgeInsets.symmetric(vertical: 10),
              child: Row(
                children: [
                  Text(
                    "Communication Type",
                    style: TextStyle(
                      fontWeight: FontWeight.bold,
                    ),
                  ),
                  Spacer(),
                  Text(_getShowMenuString(viewModel.type.toString())),
                  Icon(Icons.arrow_drop_down),
                ],
              ),
            ),
          ),
        ];

        if (viewModel.type != CommSettingType.AIDL) {
          list.add(TextField(
            controller: _timeoutController,
            inputFormatters: [
              FilteringTextInputFormatter.allow(RegExp("[0-9-]")),
            ],
            keyboardType: TextInputType.numberWithOptions(signed: true),
            maxLines: null,
            maxLength: 9,
            textInputAction: TextInputAction.done,
            decoration: InputDecoration(
              labelText: S.of(context).timeout,
            ),
            onChanged: (String value) {
              if (value.isNotEmpty) {
                viewModel.timeout = int.parse(value);
              } else {
                viewModel.timeout = 0;
              }
            },
            onSubmitted: (String value) {
              if (value.isNotEmpty) {
                viewModel.timeout = int.parse(value);
              } else {
                viewModel.timeout = 0;
              }
            },
          ));
        }

        if (viewModel.type == CommSettingType.USB) {
          if (Platform.isAndroid) {
            list.add(
              TextField(
                focusNode: _usbDevFocusNode,
                controller: TextEditingController.fromValue(
                  TextEditingValue(
                    text: viewModel.deviceName ?? "",
                  ),
                ),
                keyboardType: TextInputType.text,
                maxLines: null,
                textInputAction: TextInputAction.done,
                decoration: InputDecoration(
                  labelText: S.of(context).device,
                  suffix: Platform.isAndroid
                      ? SizedBox(
                          height: 40,
                          width: 80,
                          child: CupertinoButton(
                            padding: EdgeInsets.zero,
                            color: kMainColor,
                            onPressed: () async {
                              if (!_usbDevFocus) {
                                FocusScope.of(context)
                                    .requestFocus(_usbDevFocusNode);
                                return;
                              }
                              String? deviceName = await showDialog(
                                  context: context,
                                  builder: (context) {
                                    return AlertDialog(
                                      title: Text(
                                          S.of(context).selectADeviceToConnect),
                                      content: USBDialog(),
                                      actions: [
                                        TextButton(
                                          onPressed: () {
                                            Navigator.of(context).pop();
                                          },
                                          child: Text(S.of(context).close),
                                        ),
                                      ],
                                    );
                                  });
                              if (deviceName != null) {
                                setState(() {
                                  viewModel.deviceName = deviceName;
                                });
                                await viewModel.requestUSBPermissionIfNeed();
                              }
                            },
                            child: Text(
                              S.of(context).search,
                              style: TextStyle(
                                fontSize: 14,
                                color: Colors.white,
                              ),
                            ),
                          ),
                        )
                      : null,
                ),
                onChanged: (String value) {
                  viewModel.deviceName = value;
                },
                onSubmitted: (String value) {
                  viewModel.deviceName = value;
                },
              ),
            );
          }
        }

        if (viewModel.type == CommSettingType.TCP ||
            viewModel.type == CommSettingType.HTTP ||
            viewModel.type == CommSettingType.HTTPS ||
            viewModel.type == CommSettingType.SSL) {
          list.add(TextField(
            controller: _ipController,
            keyboardType: TextInputType.text,
            maxLines: null,
            textInputAction: TextInputAction.done,
            decoration: InputDecoration(
              labelText: S.of(context).ip,
            ),
            onChanged: (String value) {
              viewModel.ip = value;
            },
            onSubmitted: (String value) {
              viewModel.ip = value;
            },
          ));
          list.add(TextField(
            controller: _portController,
            inputFormatters: [
              FilteringTextInputFormatter.digitsOnly,
            ],
            keyboardType: TextInputType.number,
            maxLines: null,
            textInputAction: TextInputAction.done,
            decoration: InputDecoration(
              labelText: S.of(context).port,
            ),
            onChanged: (String value) {
              viewModel.port = value;
            },
            onSubmitted: (String value) {
              viewModel.port = value;
            },
          ));
        }

        if (viewModel.type == CommSettingType.UART) {
          list.add(viewModel.uartDevices.isNotEmpty
              ? PopupMenuButton(
                  tooltip: "",
                  itemBuilder: (context) {
                    List<PopupMenuItem> menuItemList = [];
                    for (String? name in viewModel.uartDevices) {
                      if (name != null) {
                        menuItemList.add(PopupMenuItem(
                          value: name,
                          child: Text(name),
                        ));
                      }
                    }
                    return menuItemList;
                  },
                  onSelected: (dynamic value) {
                    if (value is String) {
                      setState(() {
                        viewModel.serialPort = value;
                      });
                    }
                  },
                  offset: Offset(1, 30),
                  child: Padding(
                    padding: const EdgeInsets.symmetric(vertical: 10),
                    child: Row(
                      children: [
                        Text(
                          S.of(context).serialPort,
                          style: TextStyle(
                            fontWeight: FontWeight.bold,
                          ),
                        ),
                        Spacer(),
                        Text(viewModel.serialPort ?? ""),
                        Icon(Icons.arrow_drop_down),
                      ],
                    ),
                  ),
                )
              : TextField(
                  controller: _serialPortController,
                  keyboardType: TextInputType.text,
                  maxLines: null,
                  textInputAction: TextInputAction.done,
                  decoration: InputDecoration(
                    labelText: S.of(context).serialPort,
                  ),
                  onChanged: (String value) {
                    viewModel.serialPort = value;
                  },
                  onSubmitted: (String value) {
                    viewModel.serialPort = value;
                  },
                ));

          list.add(PopupMenuButton(
            tooltip: "",
            itemBuilder: (context) {
              return [
                PopupMenuItem(
                  value: baudrateList[0],
                  child: Text(baudrateList[0]),
                ),
                PopupMenuItem(
                  value: baudrateList[1],
                  child: Text(baudrateList[1]),
                ),
              ];
            },
            onSelected: (String baudrate) {
              setState(() {
                viewModel.baudRate = baudrate;
              });
            },
            offset: Offset(1, 30),
            child: Padding(
              padding: const EdgeInsets.symmetric(vertical: 10),
              child: Row(
                children: [
                  Text(
                    "Baudrate",
                    style: TextStyle(
                      fontWeight: FontWeight.bold,
                    ),
                  ),
                  Spacer(),
                  Text(viewModel.baudRate ?? ""),
                  Icon(Icons.arrow_drop_down),
                ],
              ),
            ),
          ));
        }

        // E48242BF-FB84-D6F4-228D-1803CC7C48D8
        if (viewModel.type == CommSettingType.BT) {
          // ios bt
          if (Platform.isIOS) {
            list.add(TextField(
              controller: TextEditingController.fromValue(
                TextEditingValue(
                  text: viewModel.macAddr ?? "",
                  selection: TextSelection.fromPosition(
                    TextPosition(
                      affinity: TextAffinity.downstream,
                      offset: (viewModel.macAddr ?? "").length,
                    ),
                  ),
                ),
              ),
              keyboardType: TextInputType.text,
              maxLines: null,
              textInputAction: TextInputAction.done,
              decoration: InputDecoration(
                hintText: 'Such as : E48242BF-FB84-D6F4-228D-1803CC7C48D8',
                labelText: 'UUID',
              ),
              onChanged: (String value) {
                viewModel.macAddr = value;
              },
              onSubmitted: (String value) {
                viewModel.macAddr = value;
              },
            ));

            list.add(Container(
              height: 60,
              child: Row(
                children: [
                  SizedBox(
                    height: 40,
                    width: 80,
                    child: CupertinoButton(
                      padding: EdgeInsets.zero,
                      color: kMainColor,
                      onPressed: () async {
                        if (_scan == false) {
                          _scan = true;
                          setState(() {
                            btList.clear();
                          });
                          Timer.periodic(Duration(milliseconds: 1000),
                              (timer) async {
                            if (_scan == false) {
                              timer.cancel();
                            } else {
                              POSLinkBTSearchApi api = POSLinkBTSearchApi();
                              BTDevice? data = await api.search();
                              bool isAdd = true;
                              for (var element in btList) {
                                if (element?.address == data.address) {
                                  isAdd = false;
                                  break;
                                }
                              }
                              setState(() {
                                if (isAdd) btList.add(data);
                              });
                            }
                          });
                        }
                      },
                      child: Text(
                        'Scan',
                        style: TextStyle(
                          fontSize: 14,
                          color: Colors.white,
                        ),
                      ),
                    ),
                  ),
                  SizedBox(
                    width: 100,
                  ),
                  SizedBox(
                    height: 40,
                    width: 80,
                    child: CupertinoButton(
                      padding: EdgeInsets.zero,
                      color: kMainColor,
                      onPressed: () async {
                        _scan = false;
                        POSLinkBTSearchApi api = POSLinkBTSearchApi();
                        await api.stop();
                      },
                      child: Text(
                        'Stop',
                        style: TextStyle(
                          fontSize: 14,
                          color: Colors.white,
                        ),
                      ),
                    ),
                  ),
                  SizedBox(
                    width: 100,
                  ),
                  Expanded(
                    child: Text('Long press to copy'),
                  )
                ],
              ),
            ));

            list.add(
              Container(
                color: kMainColor,
                height: 320,
                child: ListView.builder(
                  itemCount: btList.length,
                  itemBuilder: (BuildContext context, int index) {
                    // BTDevice nuDevice = BTDevice();
                    // nuDevice.name = '';
                    // nuDevice.address = '';
                    // BTDevice device =
                    //     btList[index] == null ? nuDevice : btList[index]!;

                    BTDevice device = btList[index]!;

                    return GestureDetector(
                      onLongPress: () {
                        setState(() {
                          viewModel.macAddr = device.address;
                        });
                        Clipboard.setData(
                            ClipboardData(text: device.address ?? ""));
                        Fluttertoast.showToast(
                            msg: "Copy to clipboard successful");
                      },
                      child: Container(
                        height: 40,
                        child: Padding(
                          padding: EdgeInsets.only(left: 10),
                          child: Text('${device.name} : ${device.address}'),
                        ),
                      ),
                    );
                  },
                ),
              ),
            );
          } else {
            list.add(
              TextField(
                focusNode: _macAddrFocusNode,
                controller: _macAddrController,
                keyboardType: TextInputType.text,
                maxLines: null,
                textInputAction: TextInputAction.done,
                decoration: InputDecoration(
                  labelText: S.of(context).macAddr,
                  suffix: Platform.isAndroid
                      ? SizedBox(
                          height: 40,
                          width: 80,
                          child: CupertinoButton(
                            padding: EdgeInsets.zero,
                            color: kMainColor,
                            onPressed: () async {
                              if (!_macAddrFocus) {
                                FocusScope.of(context)
                                    .requestFocus(_macAddrFocusNode);
                                return;
                              }
                              bool enable = await POSLinkAndroidApi()
                                  .checkBluetoothEnable();
                              if (enable) {
                                String? mac = await showDialog(
                                    context: context,
                                    builder: (context) {
                                      return AlertDialog(
                                        title: Text(S
                                            .of(context)
                                            .selectADeviceToConnect),
                                        content: BluetoothDialog(),
                                        actions: [
                                          TextButton(
                                            onPressed: () {
                                              Navigator.of(context).pop();
                                            },
                                            child: Text(S.of(context).close),
                                          ),
                                        ],
                                      );
                                    });
                                if (mac != null) {
                                  setState(() {
                                    viewModel.macAddr = mac;
                                  });
                                }
                              } else {
                                Fluttertoast.showToast(
                                    msg: S.of(context).bluetoothDisabled);
                              }
                            },
                            child: Text(
                              S.of(context).search,
                              style: TextStyle(
                                fontSize: 14,
                                color: Colors.white,
                              ),
                            ),
                          ),
                        )
                      : null,
                ),
                onChanged: (String value) {
                  viewModel.macAddr = value;
                },
                onSubmitted: (String value) {
                  viewModel.macAddr = value;
                },
              ),
            );
          }
        }

        return SafeArea(
          child: ListView(
            padding: EdgeInsets.symmetric(horizontal: 20),
            children: list,
          ),
        );
      },
    );
  }
}

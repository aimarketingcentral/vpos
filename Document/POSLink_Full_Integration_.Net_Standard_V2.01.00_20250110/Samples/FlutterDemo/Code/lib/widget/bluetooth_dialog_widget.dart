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

import 'package:flutter/material.dart';
import 'package:poslink2/res/colors.dart';

import '../auto_pigeon/poslink_android.dart';

class BluetoothDialog extends StatefulWidget {
  BluetoothDialog();

  @override
  State<StatefulWidget> createState() => _BluetoothDialogState();
}

class _BluetoothDialogState extends State<BluetoothDialog> {
  late Timer _timer;
  List<BluetoothDevice> _deviceList = [];

  @override
  void initState() {
    POSLinkAndroidApi().startSearchBluetooth();
    _timer = Timer.periodic(Duration(seconds: 1), (timer) async {
      List<BluetoothDevice?> list =
      await POSLinkAndroidApi().getBluetoothDeviceList();
      setState(() {
        _deviceList.clear();
        list.forEach((device) {
          if (device != null) {
            _deviceList.add(device);
          }
        });
      });
    });
    super.initState();
  }

  @override
  void dispose() {
    POSLinkAndroidApi().stopSearchBluetooth();
    _timer.cancel();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Container(
      height: MediaQuery.of(context).size.height,
      width: MediaQuery.of(context).size.width,
      child: ListView.separated(
        itemBuilder: (context, index) {
          BluetoothDevice device = _deviceList[index];
          return InkWell(
            child: Column(
              children: [
                Text(
                  device.name ?? "Unknown name",
                  style: TextStyle(fontSize: 14, color: kMainColor),
                ),
                Text(
                  device.mac ?? "",
                  style: TextStyle(fontSize: 12, color: Colors.black),
                ),
              ],
            ),
            onTap: () {
              Navigator.of(context).pop(device.mac);
            },
          );
        },
        itemCount: _deviceList.length,
        separatorBuilder: (context, index) {
          return Divider(
            height: 1,
          );
        },
      ),
    );
  }
}

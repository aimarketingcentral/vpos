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

class USBDialog extends StatefulWidget {
  USBDialog();

  @override
  State<StatefulWidget> createState() => _USBDialogState();
}

class _USBDialogState extends State<USBDialog> {
  late Timer _timer;
  List<UsbDevice> _deviceList = [];

  @override
  void initState() {
    _timer = Timer.periodic(Duration(seconds: 1), (timer) async {
      List<UsbDevice?> list = await POSLinkAndroidApi().getUSBDeviceList();
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
          UsbDevice device = _deviceList[index];
          return InkWell(
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Text(
                  device.deviceName ?? "Unknown name",
                  style: TextStyle(fontSize: 14, color: Colors.black),
                ),
                Row(
                  children: [
                    Expanded(
                      child: Text(
                        device.manufacturerName ?? " ",
                        style: TextStyle(fontSize: 12, color: kMainColor),
                      ),
                    ),
                    Expanded(
                      child: Text(
                        device.productName ?? " ",
                        style: TextStyle(fontSize: 12, color: kMainColor),
                      ),
                    ),
                  ],
                ),
              ],
            ),
            onTap: () {
              Navigator.of(context).pop(device.deviceName);
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

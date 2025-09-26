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

import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

class StackButton extends StatelessWidget {
  const StackButton({
    this.labelText,
    this.click,
    this.iconData,
    this.iconColor,
    Key? key,
  }) : super(key: key);

  final String? labelText;
  final Function? click;
  final IconData? iconData;
  final Color? iconColor;

  @override
  Widget build(BuildContext context) {
    if (iconData == null) {
      return GestureDetector(
        onTap: () async {
          if (click != null) {
            click!();
          }
        },
        child: Container(
          color: Colors.transparent,
          width: 50,
          height: 50,
          child: Center(
            child: Text(labelText ?? '', style: TextStyle(color: Colors.transparent)),
          ),
        ),
      );
    }
    return Stack(
      alignment: Alignment.center,
      children: [
        Icon(
          iconData,
          color: iconColor,
        ),
        GestureDetector(
          onTap: () async {
            if (click != null) {
              click!();
            }
          },
          child: Container(
            color: Colors.transparent,
            width: 50,
            height: 50,
            child: Center(
              child: Text(labelText ?? '', style: TextStyle(color: Colors.transparent)),
            ),
          ),
        ),
      ],
    );
  }
}

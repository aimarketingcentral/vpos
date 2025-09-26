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
import 'dart:io';

/// 定义一些通用的距离
/// 水平方向 距离屏幕
const double kHorizontalPadding = 15;

/// 单元格高度
const double kCellHeight = 50;

/// Icon开头时候
const double kArrowLeadingHorizontalPadding = 6;

/// 输入框y
const double kTextFVPadding = 0.1;

const double kDividerWidth = 0.5;

class ScrollHeight {
  static double getScrollHeight(BuildContext context) {
    return MediaQuery.of(context).size.height - 300;
  }
}

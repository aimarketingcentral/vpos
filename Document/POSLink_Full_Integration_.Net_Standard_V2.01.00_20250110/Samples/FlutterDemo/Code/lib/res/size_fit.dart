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

import 'dart:io';
import 'dart:ui';

import 'package:flutter/material.dart';

class TTSizeFit {
  // 基本信息
  static late double physicalWidth;
  static late double physicalHeight;
  static late double dpr;
  static late double statusHeight;
  static late bool isPortrait;

  static double screenWidth = physicalWidth / dpr;
  static double screenHeight = physicalHeight / dpr;

  static double rpx = screenWidth / 750;
  static double px = screenWidth / 750 * 2;

  static double aspectRatio = physicalWidth / physicalHeight;

  static Future<void> ensureScreenSize([
    FlutterView? window,
    Duration duration = const Duration(milliseconds: 10),
  ]) async {
    final binding = WidgetsFlutterBinding.ensureInitialized();
    // window ??= WidgetsBinding.instance.platformDispatcher.implicitView;
    window ??= WidgetsBinding.instance.window;

    if (window.physicalGeometry.isEmpty == true) {
      return Future.delayed(duration, () async {
        binding.deferFirstFrame();
        await ensureScreenSize(window, duration);
        return binding.allowFirstFrame();
      });
    }
  }

  static void initialize(BuildContext context, {double standardSizeWidth = 750}) {
    // // 手机物理分辨率
    // physicalHeight =  View.of(context).physicalSize.height;
    // physicalWidth = View.of(context).physicalSize.width;
    // // 获取dpr(像素比)
    // dpr = View.of(context).devicePixelRatio;
    // // 状态栏高度
    // statusHeight = View.of(context).padding.top / dpr;
    // 手机物理分辨率
    physicalHeight = window.physicalSize.height;
    physicalWidth = window.physicalSize.width;
    // 获取dpr(像素比)
    dpr = window.devicePixelRatio;
    // 状态栏高度
    statusHeight = window.padding.top / dpr;
    print('Pixel ratio：$dpr');

    // 获取宽高比
    aspectRatio = physicalWidth / physicalHeight;
    print('Aspect ratio：$aspectRatio');

    // 宽度和高度
    screenWidth = physicalWidth / dpr;
    screenHeight = physicalHeight / dpr;

    // 计算rpx\px大小
    rpx = screenWidth / standardSizeWidth;
    px = screenWidth / standardSizeWidth * 2;
  }

  static double setRpx(double size) {
    return rpx * size;
  }

  static double setPx(double size) {
    return px * size;
  }
}

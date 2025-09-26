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
import 'package:poslink2/model/comm_setting_view_model.dart';
import 'package:poslink2/res/size_fit.dart';
import 'package:poslink2/ui/tab_views/common_home_view.dart';
import 'package:poslink2/ui/tab_views/log_setting_view.dart';
import 'package:poslink2/ui/tab_views/multicommand_view.dart';
import 'package:poslink2/ui/tab_views/send_command_view.dart';
import 'package:poslink2/ui/tab_views/setting_view.dart';
import '../model/base_view_model.dart';

/// Global key
final GlobalKey<CommonHomeViewState> fullIntegrationKey = GlobalKey();
final GlobalKey<CommonHomeViewState> muticommandKey = GlobalKey();
final GlobalKey<CommonHomeViewState> formKey = GlobalKey();
final GlobalKey<CommonHomeViewState> manageKey = GlobalKey();
final GlobalKey<CommonHomeViewState> pedKey = GlobalKey();
final GlobalKey<CommonHomeViewState> payloadKey = GlobalKey();
final GlobalKey<CommonHomeViewState> customFormManageKey = GlobalKey();
final GlobalKey<CommonHomeViewState> deviceKey = GlobalKey();

// 获取横屏主页面
final List<Widget> HomePages= [
  CommonHomeView(
    key: fullIntegrationKey,
    command: Command.FULLINTEGRATION,
  ),
  CommonHomeView(
    key: manageKey,
    command: Command.MANAGE,
  ),
  CommonHomeView(
    key: formKey,
    command: Command.FORM,
  ),
  CommonHomeView(
    key: deviceKey,
    command: Command.DEVICE,
  ),
  CommonHomeView(
    key: pedKey,
    command: Command.PED,
  ),
  // CommonHomeView(
  //   command: Command.MUTICOMMAND,
  // ),
  // CommonHomeView(
  //   command: Command.PAYLOAD,
  // ),
  // CommonHomeView(
  //   command: Command.CUSTOMFORMMANAGE,
  // ),
  MutiCmdView(
    key: muticommandKey,
  ),
  LogSettingView(),
  SettingView(),
  SendCommandView()
];
// 获取横屏底部bar
final List<BottomNavigationBarItem> HomeItems = [
  BottomNavigationBarItem(
      label: 'FullIntegration',
      // backgroundColor: kMainColor,
      icon: Image(image: AssetImage("assets/images/FullIntegration.png"),width: 20,height: 20,),
      activeIcon: Image(image: AssetImage("assets/images/FullIntegration.png"),width: 20,height: 20,)
  ),
  BottomNavigationBarItem(
    label: "Manage",
    // backgroundColor: kMainColor,
    icon: Image(image: AssetImage("assets/images/Manage.png"),width: 20,height: 20,),
  ),
  BottomNavigationBarItem(
    label: 'Form',
    // backgroundColor: kMainColor,
    icon: Image(image: AssetImage("assets/images/Form.png"),width: 20,height: 20,),
  ),
  BottomNavigationBarItem(
    label: "Device",
    // backgroundColor: kMainColor,
    icon: Image(image: AssetImage("assets/images/Device.png"),width: 20,height: 20,),
  ),
  BottomNavigationBarItem(
    label: 'Ped',
    // backgroundColor: kMainColor,
    icon: Image(image: AssetImage("assets/images/Ped.png"),width: 20,height: 20,),
  ),
  BottomNavigationBarItem(
    label: 'MultiCommand',
    // backgroundColor: kMainColor,
    icon: Image(image: AssetImage("assets/images/MultiCommand.png"),width: 20,height: 20,),
  ),
  // BottomNavigationBarItem(
  //   label: 'Payload',
  //   // backgroundColor: kMainColor,
  //   icon: Image(image: AssetImage("assets/images/Payload.png"),width: 20,height: 20,),
  // ),
  // BottomNavigationBarItem(
  //   label: 'CustomFormManage',
  //   // backgroundColor: kMainColor,
  //   icon: Image(image: AssetImage("assets/images/CustomFormManage.png"),width: 20,height: 20,),
  // ),
  BottomNavigationBarItem(
    label: 'Log Setting',
    // backgroundColor: kMainColor,
    icon: Image(image: AssetImage("assets/images/LogSetting.png"),width: 20,height: 20,),
  ),
  BottomNavigationBarItem(
    label: 'Comm Setting',
    // backgroundColor: kMainColor,
    icon: Image(image: AssetImage("assets/images/Setting.png"),width: 20,height: 20,),
  ),
  BottomNavigationBarItem(
    label: 'Send Cmd',
    // backgroundColor: kMainColor,
    icon: Image(image: AssetImage("assets/images/SendCmd.png"),width: 20,height: 20,),
  )
];

// 获取竖屏主页面
Widget getPortraitHomeItem(CommSettingViewModel viewModel) {
  Widget? child;
  switch (viewModel.currentTab) {
    case CurrentTabEnum.TAB_FULL_INTEGRATION:
      child = CommonHomeView(
        key: fullIntegrationKey,
        command: Command.FULLINTEGRATION,
      );
      break;
    case CurrentTabEnum.TAB_MANAGE:
      child = CommonHomeView(
        key: manageKey,
        command: Command.MANAGE,
      );
      break;
    case CurrentTabEnum.TAB_FORM:
      child = CommonHomeView(
        key: formKey,
        command: Command.FORM,
      );
      break;
    case CurrentTabEnum.TAB_PED:
      child = CommonHomeView(
        key: pedKey,
        command: Command.PED,
      );
      break;
  // case CurrentTabEnum.TAB_PAYLOAD:
  //   title = "Payload";
  //   child = CommonHomeView(key: _payloadKey, command: Command.PAYLOAD,);
  //   break;
  // case CurrentTabEnum.TAB_CUSTOM_FORM_MANAGE:
  //   title = "CustomFormManage";
  //   child = CommonHomeView(key: _customFormManageKey, command: Command.CUSTOMFORMMANAGE,);
  //   break;
    case CurrentTabEnum.TAB_DEVICE:
      child = CommonHomeView(
        key: deviceKey,
        command: Command.DEVICE,
      );
      break;
    case CurrentTabEnum.TAB_MULTI_COMMAND:
      child = MutiCmdView(
        key: muticommandKey,
      );
      break;
    case CurrentTabEnum.TAB_SEND_COMMAND:
      child = SendCommandView();
      break;
    case CurrentTabEnum.TAB_LOG_SETTING:
      child = LogSettingView();
      break;
    case CurrentTabEnum.TAB_COMM_SETTING:
      child = SettingView();
      break;
  }
  return child;
}
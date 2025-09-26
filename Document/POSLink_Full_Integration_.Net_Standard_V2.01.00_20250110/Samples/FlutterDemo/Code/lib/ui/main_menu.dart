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

import 'package:flutter/material.dart';
import 'package:poslink2/model/comm_setting_view_model.dart';
import 'package:provider/provider.dart';

import '../model/main_page_view_model.dart';

class MainMenu extends StatefulWidget {
  const MainMenu({Key? key}) : super(key: key);

  @override
  State<MainMenu> createState() => _MainMenuState();
}

class _MainMenuState extends State<MainMenu> {
  late CommSettingViewModel commSettingViewModel;
  late MainPageViewModel mainPageViewModel;

  @override
  void initState() {
    // TODO: implement initState
    commSettingViewModel = context.read<CommSettingViewModel>();
    mainPageViewModel = context.read<MainPageViewModel>();
  }

  @override
  Widget build(BuildContext context) {
    return Consumer<CommSettingViewModel>(
      builder: (context, viewModel, child) {
        List<ListTile> viewList = [
          ListTile(
            leading: Image(
              image: AssetImage("assets/images/FullIntegration.png"),
              width: 20,
            ),
            title: Text('FullIntegration'),
            onTap: () {
              if (viewModel.currentTab != CurrentTabEnum.TAB_FULL_INTEGRATION) {
                mainPageViewModel.changeStatus(true);
              }
              viewModel.currentTab = CurrentTabEnum.TAB_FULL_INTEGRATION;
              Navigator.of(context).pop();
            },
          ),
          ListTile(
            leading: Image(
              image: AssetImage("assets/images/Manage.png"),
              width: 20,
            ),
            title: Text('Manage'),
            onTap: () {
              if (viewModel.currentTab != CurrentTabEnum.TAB_MANAGE) {
                mainPageViewModel.changeStatus(true);
              }
              viewModel.currentTab = CurrentTabEnum.TAB_MANAGE;
              Navigator.of(context).pop();
            },
          ),
          ListTile(
            leading: Image(
              image: AssetImage("assets/images/Form.png"),
              width: 20,
            ),
            title: Text('Form'),
            onTap: () {
              if (viewModel.currentTab != CurrentTabEnum.TAB_FORM) {
                mainPageViewModel.changeStatus(true);
              }
              viewModel.currentTab = CurrentTabEnum.TAB_FORM;
              Navigator.of(context).pop();
            },
          ),
          ListTile(
            leading: Image(
              image: AssetImage("assets/images/Device.png"),
              width: 20,
            ),
            title: Text('Device'),
            onTap: () {
              if (viewModel.currentTab != CurrentTabEnum.TAB_DEVICE) {
                mainPageViewModel.changeStatus(true);
              }
              viewModel.currentTab = CurrentTabEnum.TAB_DEVICE;
              Navigator.of(context).pop();
            },
          ),
          ListTile(
            leading: Image(
              image: AssetImage("assets/images/Ped.png"),
              width: 20,
            ),
            title: Text('PED'),
            onTap: () {
              if (viewModel.currentTab != CurrentTabEnum.TAB_PED) {
                mainPageViewModel.changeStatus(true);
              }
              viewModel.currentTab = CurrentTabEnum.TAB_PED;
              Navigator.of(context).pop();
            },
          ),
          ListTile(
            leading: Image(
              image: AssetImage("assets/images/MultiCommand.png"),
              width: 20,
            ),
            title: Text('MultiCommand'),
            onTap: () {
              if (viewModel.currentTab != CurrentTabEnum.TAB_MULTI_COMMAND) {
                mainPageViewModel.changeStatus(true);
              }
              viewModel.currentTab = CurrentTabEnum.TAB_MULTI_COMMAND;
              Navigator.of(context).pop();
            },
          ),
          // ListTile(
          //   leading: Image(
          //     image: AssetImage("assets/images/Payload.png"),
          //     width: 20,
          //   ),
          //   title: Text('Payload'),
          //   onTap: () {
          //     if (viewModel.currentTab != CommSettingViewModel.TAB_PAYLOAD) {
          //       mainPageViewModel.changeStatus(true);
          //     }
          //     viewModel.currentTab = CommSettingViewModel.TAB_PAYLOAD;
          //     Navigator.of(context).pop();
          //   },
          // ),
          // ListTile(
          //   leading: Image(
          //     image: AssetImage("assets/images/Ped.png"),
          //     width: 20,
          //   ),
          //   title: Text('CustomFormManage'),
          //   onTap: () {
          //     if (viewModel.currentTab != CommSettingViewModel.TAB_CUSTOM_FORM_MANAGE) {
          //       mainPageViewModel.changeStatus(true);
          //     }
          //     viewModel.currentTab = CommSettingViewModel.TAB_CUSTOM_FORM_MANAGE;
          //     Navigator.of(context).pop();
          //   },
          // ),
          ListTile(
            leading: Image(
              image: AssetImage("assets/images/LogSetting.png"),
              width: 20,
            ),
            title: Text('Log Setting'),
            onTap: () {
              mainPageViewModel.changeStatus(true);
              viewModel.currentTab = CurrentTabEnum.TAB_LOG_SETTING;
              Navigator.of(context).pop();
            },
          ),
          ListTile(
            leading: Image(
              image: AssetImage("assets/images/Setting.png"),
              width: 20,
            ),
            title: Text('Comm Setting'),
            onTap: () {
              mainPageViewModel.changeStatus(true);
              commSettingViewModel.getLocalData();
              viewModel.currentTab = CurrentTabEnum.TAB_COMM_SETTING;
              Navigator.of(context).pop();
            },
          ),
        ];
        if (Platform.isAndroid) {
          viewList.add(ListTile(
            leading: Image(
              image: AssetImage("assets/images/SendCmd.png"),
              width: 20,
            ),
            title: Text('Send Cmd'),
            onTap: () {
              mainPageViewModel.changeStatus(true);
              viewModel.currentTab = CurrentTabEnum.TAB_SEND_COMMAND;
              Navigator.of(context).pop();
            },
          ));
        }

        return Drawer(
          child: ListView(
            children: viewList,
          ),
        );
      },
    );
  }
}

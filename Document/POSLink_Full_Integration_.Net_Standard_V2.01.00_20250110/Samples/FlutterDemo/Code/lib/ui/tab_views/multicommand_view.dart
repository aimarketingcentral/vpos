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

import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:poslink2/model/base_view_model.dart';
import 'package:poslink2/model/multicommand_view_model.dart';
import 'package:poslink2/res/colors.dart';
import 'package:poslink2/res/size_fit.dart';
import 'package:poslink2/widget/muticoammand_widget.dart';
import 'package:provider/provider.dart';
import 'package:provider/provider.dart';
import '../../model/main_page_view_model.dart';

class MutiCmdView extends StatefulWidget {
  const MutiCmdView({Key? key}) : super(key: key);

  @override
  MutiCmdViewState createState() => MutiCmdViewState();
}

class MutiCmdViewState extends State<MutiCmdView>
    with SingleTickerProviderStateMixin {
  late TabController _tabController;
  late MutiCommandViewModel mutiCommandViewModel;
  late MainPageViewModel _mainPageViewModel;
  _listener() {
    setState(() {
      _tabController.index = mutiCommandViewModel.tabBarViewIndex;
    });
  }

  @override
  void initState() {
    mutiCommandViewModel = context.read<MutiCommandViewModel>();
    mutiCommandViewModel.addListener(_listener);
    _tabController = TabController(length: 2, vsync: this);
    _tabController.addListener(() {
      //Log.v(_tabController.index);
    });
    _tabController.index = 0;
    super.initState();
  }

  @override
  void dispose() {
    mutiCommandViewModel.removeListener(_listener);
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    if (TTSizeFit.isPortrait) {
      return DefaultTabController(
        length: 2,
        child: Scaffold(
          appBar: AppBar(
            backgroundColor: kMainColor,
            toolbarHeight: 0,
            elevation: 0,
            bottom: TabBar(
              controller: _tabController,
              indicatorColor: Colors.white,
              tabs: [
                Tab(text: 'Request'),
                Tab(text: 'Response'),
              ],
            ),
          ),
          body: TabBarView(
            controller: _tabController,
            children: [
              MutiCmdListView(
                type: 1,
              ),
              MutiCmdListView(
                type: 2,
              ),
            ],
          ),
        ),
      );
    } else {
      return Scaffold(
        backgroundColor: Colors.white,
        appBar: AppBar(
          backgroundColor: kMainColor,
          toolbarHeight: 0,
          bottom: TabBar(
            controller: _tabController,
            indicator: const BoxDecoration(),
            // indicatorColor: Colors.white,
            tabs: [
              Tab(text: 'Request'),
              Tab(text: 'Response'),
            ],
          ),
        ),
        body: SafeArea(
          child: Row(
            children: [
              Expanded(
                child: MutiCmdListView(
                  type: 1,
                ),
              ),
              Container(
                color: Color.fromRGBO(224, 224, 224, 1),
                width: 20,
              ),
              Expanded(
                child: MutiCmdListView(
                  type: 2,
                ),
              ),
            ],
          ),
        ),
      );
    }
  }
}

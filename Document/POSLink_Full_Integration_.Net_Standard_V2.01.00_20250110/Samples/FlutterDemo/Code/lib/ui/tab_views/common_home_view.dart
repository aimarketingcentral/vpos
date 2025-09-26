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
import 'package:poslink2/main.dart';
import 'package:poslink2/model/base_view_model.dart';
import 'package:poslink2/res/colors.dart';
import 'package:provider/provider.dart';
import '../../model/main_page_view_model.dart';
import '../../res/size_fit.dart';
import '../../widget/base_widget.dart';

class CommonHomeView extends StatefulWidget {
  const CommonHomeView({Key? key, required this.command}) : super(key: key);

  final Command command;

  @override
  State<CommonHomeView> createState() => CommonHomeViewState();
}

class CommonHomeViewState extends State<CommonHomeView> with SingleTickerProviderStateMixin {
  late TabController _tabController;
  late MainPageViewModel _mainPageViewModel;

  GlobalKey<BaseViewState> _baseRequestViewKey = GlobalKey();
  GlobalKey<BaseViewState> _baseResponseViewKey = GlobalKey();

  @override
  void initState() {
    _mainPageViewModel = context.read<MainPageViewModel>();
    _tabController = TabController(length: 2, vsync: this);
    _tabController.addListener(() {
      bool status = _tabController.index == 0 ? true : false;
      _mainPageViewModel.changeStatus(status);
    });
    _tabController.index = 0;
    super.initState();
  }

  updateTab(int index) {
    setState(() {
      _tabController.index = 1;
    });
  }

  scrollUpRequest() {
    _baseRequestViewKey.currentState!.scroll();
  }

  scrollDownRequest() {
    _baseRequestViewKey.currentState!.scrollDown();
  }

  scrollUpResponse() {
    _baseResponseViewKey.currentState!.scroll();
  }

  scrollDownResponse() {
    _baseResponseViewKey.currentState!.scrollDown();
  }

  scrollToTopRequest() {
    _baseRequestViewKey.currentState!.scrollToTop();
  }

  scrollToTopResponse() {
    _baseResponseViewKey.currentState!.scrollToTop();
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
              BaseView(
                type: 1,
                command: widget.command,
                key: _baseRequestViewKey,
              ),
              BaseView(
                type: 2,
                command: widget.command,
                key: _baseResponseViewKey,
              ),
            ],
          ),
        ),
      );
    } else {
      List<Widget> mainModule = [];
      mainModule.add(Expanded(
        child: BaseView(
          type: 1,
          command: widget.command,
          key: _baseRequestViewKey,
        ),
      ));
      if (Platform.isWindows) {
        mainModule.add(
          Column(
            children: [
              Expanded(
                flex: 1,
                child: GestureDetector(
                  onTap: () {
                    _baseRequestViewKey.currentState!.scroll();
                  },
                  child: Container(
                    color: Colors.transparent,
                    width: 20,
                    height: 50,
                    child: Column(
                      children: [
                        Expanded(
                          child: Text('wintstl', style: TextStyle(color: Colors.transparent, fontSize: 5)),
                        ),
                      ],
                    ),
                  ),
                ),
              ),
              Expanded(
                flex: 1,
                child: GestureDetector(
                  onTap: () {
                    _baseResponseViewKey.currentState!.scroll();
                  },
                  child: Container(
                    color: Colors.transparent,
                    width: 20,
                    height: 50,
                    child: Column(
                      children: [
                        Expanded(
                          child: Text('wintstr', style: TextStyle(color: Colors.transparent, fontSize: 5)),
                        ),
                      ],
                    ),
                  ),
                ),
              ),
              Expanded(flex: 8, child: Text(''))
            ],
          ),
        );
      } else {
        mainModule.add(SizedBox(
          width: 20,
        ));
      }
      mainModule.add(Expanded(
        child: BaseView(
          type: 2,
          command: widget.command,
          key: _baseResponseViewKey,
        ),
      ));
      return Scaffold(
        backgroundColor: Color.fromRGBO(224, 224, 224, 1),
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
            children: mainModule,
          ),
        ),
      );
    }
  }
}

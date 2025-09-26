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
import 'package:poslink2/model/base_view_model.dart';
import 'package:poslink2/res/colors.dart';
import 'package:provider/provider.dart';
import '../../widget/base_widget.dart';
import '../../model/main_page_view_model.dart';

class FormView extends StatefulWidget {
  const FormView({Key? key}) : super(key: key);

  @override
  FormViewState createState() => FormViewState();
}

class FormViewState extends State<FormView> with SingleTickerProviderStateMixin {
  late TabController _tabController;
  late MainPageViewModel _mainPageViewModel;
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

  @override
  Widget build(BuildContext context) {
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
              command: Command.FORM,
            ),
            BaseView(
              type: 2,
              command: Command.FORM,
            ),
          ],
        ),
      ),
    );
  }
}

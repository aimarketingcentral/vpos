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
import 'package:poslink2/model/ios_select_zip_view_model.dart';
import 'package:provider/provider.dart';

import '../res/colors.dart';
import '../res/dimension.dart';

class SelectIOSZipView extends StatefulWidget {
  const SelectIOSZipView({Key? key, this.selectedCallBack}) : super(key: key);
  final Function? selectedCallBack;
  @override
  _SelectIOSZipViewState createState() => _SelectIOSZipViewState();
}

class _SelectIOSZipViewState extends State<SelectIOSZipView> {
  late SelectIOSZipViewModel _selectIOSZipViewModel;
  @override
  void initState() {
    _selectIOSZipViewModel = context.read<SelectIOSZipViewModel>();
    _selectIOSZipViewModel.load();
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: kMainColor,
        elevation: 0,
        title: Text('Selected Resource'),
        leading: InkWell(
          onTap: () {
            Navigator.of(context).pop();
          },
          child: Icon(
            Icons.arrow_back,
          ),
        ),
      ),
      body: Consumer<SelectIOSZipViewModel>(
        builder: (context, model, child) {
          return model.data!.length > 0 ? ListView.separated(
            separatorBuilder: (BuildContext context, int index) {
              return Divider();
            },
            itemCount: model.data!.length,
            itemBuilder: (BuildContext context, int index) {
              String path = model.data![index];
              List arr2 = path.split('/Documents/');
              String showPath = arr2.last;

              return InkWell(
                onTap: () async {
                  if (widget.selectedCallBack != null) {
                    widget.selectedCallBack!(path);
                  }
                  Navigator.of(context).pop();
                },
                child: Container(
                  height: 60,
                  child: Row(
                    children: [
                      Expanded(
                        child: Padding(
                          padding: EdgeInsets.only(left: kHorizontalPadding),
                          child: Text(showPath),
                        ),
                      ),
                      Padding(
                        padding: EdgeInsets.only(right: kHorizontalPadding),
                        child: Icon(Icons.arrow_forward_ios),
                      ),
                    ],
                  ),
                ),
              );
            },
          ) : Text("     Please import the resource file in Zip format into the Documents path of the sandbox through iTunes.",style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold, color: Colors.black54));
        },
      ),
    );
  }
}

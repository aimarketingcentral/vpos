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
import 'package:fluttertoast/fluttertoast.dart';
import 'package:poslink2/auto_data_source/auto_data_source_common.dart';
import 'package:poslink2/model/comm_setting_view_model.dart';
import 'package:poslink2/model/multicommand_view_model.dart';
import 'package:poslink2/res/colors.dart';
import 'package:poslink2/res/dimension.dart';
import 'package:poslink2/widget/add_muticommand_view.dart';
import 'package:provider/provider.dart';

class MutiCmdListView extends StatefulWidget {
  const MutiCmdListView({
    Key? key,
    @required this.type,
  }) : super(key: key);
  final int? type; // 1 request ; 2 response
  @override
  _MutiCmdListViewState createState() => _MutiCmdListViewState();
}

class _MutiCmdListViewState extends State<MutiCmdListView> {
  late CommSettingViewModel commSettingViewModel;

  @override
  void initState() {
    commSettingViewModel = context.read<CommSettingViewModel>();
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return Consumer<MutiCommandViewModel>(
      builder: (context, viewModel, child) {
        ///
        ///
        /// request
        if (widget.type == 1) {
          return ListView.separated(
            separatorBuilder: (BuildContext contex, int index) {
              return Divider();
            },
            itemCount: viewModel.mutiCommands.length + 1,
            itemBuilder: (BuildContext context, int index) {
              if (index == viewModel.mutiCommands.length) {
                return index > 0
                    ? viewModel.prepareMutiCommand == true
                        ? TextButton(
                            onPressed: viewModel.isDoingMutiCommand == false
                                ? () {
                                    viewModel.completeMutiCommand(commSettingViewModel);
                                  }
                                : null,
                            // 按钮样式
                            style: ButtonStyle(
                              backgroundColor: viewModel.isDoingMutiCommand == false ? MaterialStateProperty.all(kMainColor) : MaterialStateProperty.all(Colors.grey),
                              overlayColor: MaterialStateProperty.all(Colors.blue[300]),
                              fixedSize: MaterialStateProperty.all(const Size(200, 44)),
                            ),
                            child: const Text(
                              "Submit",
                              style: TextStyle(color: Colors.white, fontSize: 17),
                            ),
                          )
                        : Text('')
                    : Padding(
                        padding: EdgeInsets.only(left: kHorizontalPadding, right: kHorizontalPadding, top: kHorizontalPadding),
                        child: Text(
                          '1. Turn on the switch to enter the multiple mode.\n\n2. Turn off the switch to cancel the multiple mode.\n\n3. After entering multiple mode, normal requests cannot be sent. You need to exit multiple mode to send normal requests.',
                          style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold, color: Colors.black54),
                        ),
                      );
              }
              Map map = viewModel.mutiCommands[index];
              return Container(
                height: 60,
                child: InkWell(
                  onTap: () async {
                    await Navigator.of(context).push(
                      MaterialPageRoute(
                        builder: (context) => AddMutiCommandView(
                          tab: map[kMenuID],
                          type: 2,
                          editType: 2,
                          initData: map[kData],
                          title: '${map[kValue]}',
                        ),
                      ),
                    );
                  },
                  child: Row(
                    children: [
                      Padding(
                        padding: EdgeInsets.only(left: kHorizontalPadding),
                        child: Text(map[kName]),
                      ),
                      Spacer(),
                      Padding(
                        padding: EdgeInsets.only(right: kHorizontalPadding),
                        child: Text(map[kValue]),
                      ),
                      Padding(
                        padding: EdgeInsets.only(right: 5),
                        child: Icon(Icons.arrow_forward_ios),
                      )
                    ],
                  ),
                ),
              );
            },
          );
        }

        ///
        ///
        /// response
        return ListView.separated(
          separatorBuilder: (BuildContext contex, int index) {
            return Divider();
          },
          itemCount: viewModel.mutiCommandsRsps.length + 2,
          itemBuilder: (BuildContext context, int index) {
            if (index == 0) {
              return Consumer<MutiCommandViewModel>(builder: (context, model, child) {
                return Container(
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      Padding(
                        padding: EdgeInsets.only(top: 25, left: kHorizontalPadding),
                        child: Text(
                          'ResponseCode:',
                          style: kMainLabelStyle,
                        ),
                      ),
                      Padding(
                        padding: EdgeInsets.only(left: kHorizontalPadding, right: kHorizontalPadding),
                        child: Text(
                          model.mutiRsp.responseCode ?? '',
                          style: kMainUserInputStyle,
                        ),
                      )
                    ],
                  ),
                );
              });
            } else if (index == 1) {
              return Consumer<MutiCommandViewModel>(builder: (context, model, child) {
                return Container(
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      Padding(
                        padding: EdgeInsets.only(top: 25, left: kHorizontalPadding),
                        child: Text(
                          'ResponseMessage:',
                          style: kMainLabelStyle,
                        ),
                      ),
                      Padding(
                        padding: EdgeInsets.only(left: kHorizontalPadding, right: kHorizontalPadding),
                        child: Text(
                          model.mutiRsp.responseMessage ?? '',
                          style: kMainUserInputStyle,
                        ),
                      )
                    ],
                  ),
                );
              });
            } else {
              Map map = viewModel.mutiCommandsRsps[index - 2];
              return Container(
                height: 60,
                child: InkWell(
                  onTap: () async {
                    await Navigator.of(context).push(
                      MaterialPageRoute(
                        builder: (context) => AddMutiCommandView(
                          tab: map[kMenuID],
                          type: 2,
                          editType: 2,
                          initData: map[kData],
                          title: '${map[kValue]}',
                        ),
                      ),
                    );
                  },
                  child: Row(
                    children: [
                      Padding(
                        padding: EdgeInsets.only(left: kHorizontalPadding),
                        child: Text(map[kName]),
                      ),
                      Spacer(),
                      Padding(
                        padding: EdgeInsets.only(right: kHorizontalPadding),
                        child: Text(map[kValue]),
                      ),
                      Padding(
                        padding: EdgeInsets.only(right: 5),
                        child: Icon(Icons.arrow_forward_ios),
                      )
                    ],
                  ),
                ),
              );
            }
          },
        );
      },
    );
  }
}

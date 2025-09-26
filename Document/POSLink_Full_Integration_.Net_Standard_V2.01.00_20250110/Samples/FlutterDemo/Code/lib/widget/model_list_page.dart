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
import 'package:flutter/services.dart';
import 'package:fluttertoast/fluttertoast.dart';
import 'package:poslink2/auto_data_source/auto_data_source_common.dart';
import 'package:poslink2/res/colors.dart';
import 'package:poslink2/res/dimension.dart';
import 'package:poslink2/widget/group_item_widget.dart';
import 'package:poslink2/widget/model_list_item_add_dialog.dart';
import 'package:poslink2/widget/model_list_widget.dart';
import 'package:poslink2/widget/stack_button.dart';
import 'package:provider/provider.dart';
import 'dart:io';
import '../generated/l10n.dart';
import '../model/model_list_view_model.dart';
import '../widget/display_textfield.dart';

class ModelListPageView extends StatelessWidget {
  const ModelListPageView({
    this.title = '',
    this.className = '',
    required this.propertys,
    this.itemList = const [],
    this.needAddAction = true,
    @required this.callback,
    Key? key,
  }) : super(key: key);

  final bool needAddAction;
  final String className;
  final String title;
  final List<Map<String, dynamic>> propertys;
  final List<List<Map<String, dynamic>>> itemList;
  final Function? callback;

  @override
  Widget build(BuildContext context) {
    return ChangeNotifierProvider(
      create: (context) {
        ModelListViewModel model = ModelListViewModel(dataSource: itemList.isNotEmpty ? itemList : []);
        model.updateShowList();
        return model;
      },
      child: ModelListPages(
        title: title,
        className: className,
        propertys: propertys,
        itemList: itemList,
        callback: callback,
        needAddAction: needAddAction,
      ),
    );
  }
}

class ModelListPages extends StatefulWidget {
  const ModelListPages({
    this.title = '',
    this.className = '',
    required this.propertys,
    this.itemList = const [],
    this.needAddAction = true,
    @required this.callback,
    Key? key,
  }) : super(key: key);

  final bool needAddAction;
  final String className;
  final String title;
  final List<Map<String, dynamic>> propertys;
  final List<List<Map<String, dynamic>>> itemList;
  final Function? callback;

  @override
  State<StatefulWidget> createState() => _ModelListPagesState();
}

class _ModelListPagesState extends State<ModelListPages> {
  int _scrollClickLCount = 0;
  int _scrollClickRCount = 0;
  List<int> closeList = [];
  ScrollController _scrollController = ScrollController();
  @override
  void initState() {
    super.initState();
    ScrollController _scrollController = ScrollController();
  }

  String _getShowMenuString(String string) {
    if (string.contains('.')) {
      List list = string.split('.');
      return list[1];
    }
    return string;
  }

  addAction() async {
    List<Map<String, dynamic>> _tempList = [];
    widget.propertys.forEach((element) {
      Map<String, dynamic> map = {};
      map[kType] = element[kType];
      map[kID] = element[kID];
      map[kName] = element[kName];
      map[kValue] = element[kValue];
      map[kLevel] = element[kLevel];
      map[kData] = element[kData];
      _tempList.add(map);
    });

    String result = await showDialog(
      context: context,
      builder: (context) => ModelListItemAddDialog(
        data: _tempList,
      ),
    );
    if (result == '1') {
      context.read<ModelListViewModel>().addElements(_tempList);
    }
  }

  _clickScrollL() {
    if (_scrollClickLCount >= 1) {
      _scrollController.animateTo(_scrollController.offset + ScrollHeight.getScrollHeight(context), duration: Duration(milliseconds: 1000), curve: Curves.ease);
      _scrollClickLCount = 0;
    } else {
      _scrollClickLCount += 1;
    }
  }

  _clickScrollR() {
    if (_scrollClickRCount >= 1) {
      _scrollController.animateTo(_scrollController.offset + ScrollHeight.getScrollHeight(context), duration: Duration(milliseconds: 1000), curve: Curves.ease);
      _scrollClickRCount = 0;
    } else {
      _scrollClickRCount += 1;
    }
  }

  @override
  Widget build(BuildContext context) {
    List<Widget> appbarButtonsForRequest = [];
    if (widget.needAddAction) {
      appbarButtonsForRequest.add(StackButton(
        labelText: 'scroll-l-u',
        click: _clickScrollL,
      ));
      if (Platform.isAndroid) {
        appbarButtonsForRequest.add(IconButton(
          onPressed: addAction,
          icon: Icon(Icons.add),
        ));
      } else {
        appbarButtonsForRequest.add(StackButton(
          iconData: Icons.add,
          labelText: 'admadd',
          click: addAction,
        ));
      }
    }

    List<Widget> appbarButtonsForResponse = [];
    appbarButtonsForResponse.add(StackButton(
      labelText: 'scroll-r-u',
      click: _clickScrollR,
    ));

    _itemTitle(index) => '${widget.className} -  ${index + 1}';

    return WillPopScope(
      onWillPop: () async {
        widget.callback!(context.read<ModelListViewModel>().dataSource);
        Navigator.pop(context);
        return false;
      },
      child: Scaffold(
        appBar: AppBar(
          backgroundColor: kMainColor,
          elevation: 0,
          title: Text(widget.className),
          leading: StackButton(
            iconData: Icons.arrow_back,
            labelText: 'admback',
            click: () {
              widget.callback!(context.read<ModelListViewModel>().dataSource);
              Navigator.of(context).pop();
            },
          ),
          actions: widget.needAddAction == true ? appbarButtonsForRequest : appbarButtonsForResponse,
        ),
        body: Consumer<ModelListViewModel>(
          builder: (context, model, child) {
            return ListView.builder(
              controller: _scrollController,
              itemCount: context.read<ModelListViewModel>().showList!.length,
              itemBuilder: (BuildContext context, int index) {
                List<Map<String, dynamic>> subList = model.showList![index];
                return widget.needAddAction
                    ? Dismissible(
                        key: UniqueKey(),
                        child: Padding(
                          padding: EdgeInsets.all(kHorizontalPadding),
                          child: ExpansionTile(
                            title: Text(
                              '${widget.className} -  ${index + 1}',
                              style: TextStyle(
                                fontWeight: FontWeight.bold,
                              ),
                            ),
                            initiallyExpanded: !closeList.contains(index),
                            onExpansionChanged: (bool expanded) {
                              expanded ? closeList.remove(index) : closeList.add(index);
                            },
                            children: subList.map((map) {
                              DataItemType requestItemType = map[kType];
                              int level = map[kLevel] ?? 1;
                              if (requestItemType == DataItemType.Group) {
                                return GroupItem(
                                  open: map[kGroupArrowOpen] ?? true,
                                  groupName: map[kName],
                                  level: level,
                                  groupInfoCallback: () {
                                    context.read<ModelListViewModel>().refreshGroupTypeStatus(index, map[kID]);
                                  },
                                );
                              } else if (requestItemType == DataItemType.CellInput) {
                                return widget.needAddAction
                                    ? Column(
                                        crossAxisAlignment: CrossAxisAlignment.start,
                                        children: [
                                          Padding(
                                            padding: const EdgeInsets.symmetric(horizontal: kHorizontalPadding),
                                            child: Text(
                                              map[kName],
                                              style: TextStyle(fontSize: 14, fontWeight: FontWeight.bold),
                                            ),
                                          ),
                                          DisplayTextField(
                                            text: map[kValue] ?? "",
                                          ),
                                        ],
                                      )
                                    : Platform.isWindows
                                        ? Container(
                                            height: kCellHeight,
                                            child: Padding(
                                              padding: EdgeInsets.only(
                                                left: kHorizontalPadding * level,
                                                right: kHorizontalPadding * level,
                                                top: kTextFVPadding,
                                                bottom: kTextFVPadding,
                                              ),
                                              child: TextField(
                                                controller: TextEditingController(text: map[kValue] ?? ''),
                                                style: kMainUserInputStyle,
                                                textInputAction: TextInputAction.done,
                                                enabled: true,
                                                readOnly: true,
                                                decoration: InputDecoration(
                                                  label: Text(
                                                    map[kName] ?? '',
                                                    style: kMainLabelStyle,
                                                  ),
                                                  enabledBorder: UnderlineInputBorder(
                                                    borderSide: BorderSide(
                                                      color: kDividerColor,
                                                      width: kDividerWidth,
                                                    ),
                                                  ),
                                                ),
                                              ),
                                            ),
                                          )
                                        : Container(
                                            color: Colors.transparent,
                                            height: 60,
                                            alignment: Alignment.topLeft,
                                            child: InkWell(
                                              onLongPress: () {
                                                Clipboard.setData(ClipboardData(text: map[kValue] ?? ""));
                                                Fluttertoast.showToast(msg: S.of(context).CopiedSuccessfully);
                                              },
                                              child: Column(
                                                crossAxisAlignment: CrossAxisAlignment.start,
                                                children: [
                                                  Padding(
                                                    padding: EdgeInsets.symmetric(horizontal: kHorizontalPadding * level),
                                                    child: Text(
                                                      '${map[kName]}:',
                                                      style: kMainLabelStyle,
                                                    ),
                                                  ),
                                                  Padding(
                                                    padding: EdgeInsets.symmetric(horizontal: kHorizontalPadding * level),
                                                    child: Text(
                                                      map[kValue] ?? "",
                                                      style: kMainUserInputStyle,
                                                    ),
                                                  )
                                                ],
                                              ),
                                            ),
                                          );
                              } else if (requestItemType == DataItemType.Menu) {
                                return widget.needAddAction
                                    ? Column(
                                        crossAxisAlignment: CrossAxisAlignment.start,
                                        children: [
                                          Padding(
                                            padding: const EdgeInsets.symmetric(horizontal: kHorizontalPadding),
                                            child: Text(
                                              map[kName],
                                              style: TextStyle(fontSize: 14, fontWeight: FontWeight.bold),
                                            ),
                                          ),
                                          DisplayTextField(
                                            text: _getShowMenuString(map[kValue].toString()),
                                          ),
                                        ],
                                      )
                                    : Platform.isWindows
                                        ? InkWell(
                                            onTap: () {
                                              print(
                                                _getShowMenuString(map[kValue].toString()),
                                              );
                                            },
                                            child: Padding(
                                              padding: EdgeInsets.only(
                                                left: kHorizontalPadding * map[kLevel],
                                                right: kHorizontalPadding * level,
                                              ),
                                              child: Container(
                                                color: Colors.transparent,
                                                width: MediaQuery.of(context).size.width,
                                                height: 50,
                                                child: Row(
                                                  children: [
                                                    Text(
                                                      '${map[kName]}',
                                                      style: kMainLabelStyle,
                                                    ),
                                                    Expanded(child: SizedBox()),
                                                    Text(
                                                      _getShowMenuString(map[kValue].toString()),
                                                      overflow: TextOverflow.ellipsis,
                                                      style: kMainUserInputStyle,
                                                    )
                                                  ],
                                                ),
                                              ),
                                            ),
                                          )
                                        : Container(
                                            color: Colors.transparent,
                                            height: 60,
                                            alignment: Alignment.topLeft,
                                            child: InkWell(
                                              onLongPress: () {
                                                Clipboard.setData(
                                                  ClipboardData(
                                                    text: _getShowMenuString(
                                                      map[kValue].toString(),
                                                    ),
                                                  ),
                                                );
                                                Fluttertoast.showToast(msg: S.of(context).CopiedSuccessfully);
                                              },
                                              child: Row(
                                                crossAxisAlignment: CrossAxisAlignment.start,
                                                children: [
                                                  Padding(
                                                    padding: EdgeInsets.symmetric(horizontal: kHorizontalPadding * level),
                                                    child: Text(
                                                      '${map[kName]}',
                                                      style: kMainLabelStyle,
                                                    ),
                                                  ),
                                                  Expanded(child: SizedBox()),
                                                  Padding(
                                                    padding: EdgeInsets.symmetric(horizontal: kHorizontalPadding * level),
                                                    child: Text(
                                                      _getShowMenuString(map[kValue].toString()),
                                                      style: kMainUserInputStyle,
                                                    ),
                                                  )
                                                ],
                                              ),
                                            ),
                                          );
                              } else {
                                return ModelListItem(
                                  key: Key(map[kID]),
                                  propertys: map[kValue] ?? [],
                                  level: map[kLevel] ?? 1,
                                  labelText: map[kName] ?? '',
                                  enable: false,
                                  className: map[kClass] ?? '',
                                  itemList: map[kData] ?? [],
                                  callback: (value) {
                                    setState(() {
                                      map[kData] = value;
                                    });
                                  },
                                );
                              }
                            }).toList(),
                          ),
                        ),
                        confirmDismiss: (DismissDirection direction) async {
                          return widget.needAddAction;
                        },
                        onDismissed: (direction) {
                          setState(() {
                            context.read<ModelListViewModel>().removeElements(index);
                          });
                          ScaffoldMessenger.of(context).showSnackBar(SnackBar(content: Text('${widget.className} -  ${index + 1} dismissed')));
                        },
                        background: widget.needAddAction
                            ? Container(
                                color: Colors.red,
                                child: ListTile(
                                  title: Text(
                                    'Delete',
                                    style: TextStyle(color: Colors.white),
                                  ),
                                ),
                              )
                            : null,
                      )
                    : InkWell(
                        onTap: () async {
                          await showDialog(
                            context: context,
                            builder: (context) => ModelListItemAddDialog(
                              data: subList,
                              canEdit: false,
                              title: _itemTitle(index),
                            ),
                          );
                        },
                        child: Container(
                          height: 80,
                          child: Padding(
                            padding: EdgeInsets.symmetric(horizontal: kHorizontalPadding),
                            child: Row(
                              children: [
                                Text(
                                  _itemTitle(index),
                                  style: kMainLabelStyle,
                                ),
                                Spacer(),
                                Icon(Icons.arrow_forward_ios),
                              ],
                            ),
                          ),
                        ),
                      );
              },
            );
          },
        ),
      ),
    );
  }
}

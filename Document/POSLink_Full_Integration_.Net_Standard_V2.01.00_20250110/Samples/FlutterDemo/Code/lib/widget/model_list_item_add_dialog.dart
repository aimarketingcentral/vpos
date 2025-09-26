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
import 'package:poslink2/auto_data_source/auto_data_source_common.dart';
import 'package:poslink2/log/dart_log.dart';
import 'package:poslink2/res/colors.dart';
import 'package:poslink2/res/dimension.dart';
import 'package:poslink2/widget/model_list_page.dart';
import 'package:poslink2/widget/stack_button.dart';
import '../res/size_fit.dart';
import 'group_item_widget.dart';
import 'menu_item_widget.dart';
import 'model_list_item_add_text_view.dart';
import 'dart:io';

class ModelListItemAddDialogSubView extends StatefulWidget {
  ModelListItemAddDialogSubView({
    Key? key,
    required this.data,
    this.canEdit = true,
    this.refresh,
    this.title = '',
  }) : super(key: key);

  List<Map<String, dynamic>> data;
  final bool canEdit;
  final Function? refresh;
  final String title;
  @override
  _ModelListItemAddDialogSubViewState createState() => _ModelListItemAddDialogSubViewState();
}

class _ModelListItemAddDialogSubViewState extends State<ModelListItemAddDialogSubView> {
  int _scrollClickCount = 0;

  Text _getNumberText(Map<String, dynamic> itemData) {
    return Text('');
  }

  ScrollController _scrollController = ScrollController();

  _clickScrollL() {
    if (_scrollClickCount >= 1) {
      _scrollController.animateTo(_scrollController.offset + ScrollHeight.getScrollHeight(context), duration: Duration(milliseconds: 1000), curve: Curves.ease);
      _scrollClickCount = 0;
    } else {
      _scrollClickCount += 1;
    }
  }

  _clickScrollTop() {
    _scrollController.animateTo(0.0, duration: Duration(milliseconds: 1000), curve: Curves.ease);
  }

  @override
  Widget build(BuildContext context) {
    List<Widget> barItems = [];
    if (widget.canEdit) {
      if (Platform.isAndroid) {
        barItems.add(IconButton(
          onPressed: () {
            Navigator.of(context).pop('0');
          },
          icon: Icon(Icons.close),
        ));
      } else {
        barItems.add(StackButton(
          iconData: Icons.close,
          labelText: 'admcancel',
          click: () {
            Navigator.of(context).pop('0');
          },
        ));
      }
      barItems.add(Expanded(
        child: Center(
          child: Stack(
            alignment: Alignment.center,
            children: [
              Container(
                width: MediaQuery.of(context).size.width / 3.0,
                color: Colors.transparent,
                child: Stack(
                  alignment: Alignment.center,
                  children: [
                    Text("Add"),
                    Row(
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: [
                        GestureDetector(
                          onTap: () {
                            FocusScopeNode focusScopeNode = FocusScope.of(context);
                            if (!focusScopeNode.hasPrimaryFocus && focusScopeNode.focusedChild != null) {
                              FocusManager.instance.primaryFocus?.unfocus();
                            }
                          },
                          child: Text(
                            'kbdown',
                            style: TextStyle(fontSize: 9, color: Colors.transparent),
                          ),
                        ),
                        SizedBox(
                          width: 10,
                        ),
                        GestureDetector(
                          onTap: _clickScrollL,
                          child: Text(
                            'scroll-l-u',
                            style: TextStyle(fontSize: 9, color: Colors.transparent),
                          ),
                        ),
                        SizedBox(
                          width: 10,
                        ),
                        GestureDetector(
                          onTap: _clickScrollTop,
                          child: Text(
                            'scrtopl',
                            style: TextStyle(fontSize: 9, color: Colors.transparent),
                          ),
                        )
                      ],
                    )
                  ],
                ),
              ),
            ],
          ),
        ),
      ));
    } else {
      barItems.add(GestureDetector(
        onTap: _clickScrollL,
        child: Text(
          'scroll-l-u',
          style: TextStyle(fontSize: 9, color: Colors.transparent),
        ),
      ));

      barItems.add(GestureDetector(
        onTap: _clickScrollTop,
        child: Text(
          'scrtopl',
          style: TextStyle(fontSize: 9, color: Colors.transparent),
        ),
      ));

      barItems.add(
        Expanded(
          child: Center(
            child: Text(widget.title),
          ),
        ),
      );
    }

    barItems.add(StackButton(
      click: () {
        if (widget.refresh != null) {
          widget.refresh!();
        }
        Navigator.of(context).pop('1');
      },
      labelText: 'admconfirm',
      iconData: Icons.check,
      iconColor: kMainColor,
    ));

    return Material(
      type: MaterialType.transparency,
      child: Center(
        child: Container(
          color: Colors.white,
          width: MediaQuery.of(context).size.width,
          height: MediaQuery.of(context).size.height - 200,
          child: Column(
            children: [
              Row(children: barItems),
              Divider(
                height: 0,
              ),
              Expanded(
                child: ListView.builder(
                  controller: _scrollController,
                  itemCount: widget.data!.length,
                  itemBuilder: (context, index) {
                    Map<String, dynamic> itemData = widget.data![index];
                    dynamic type = itemData[kType];
                    dynamic name = itemData[kName];
                    dynamic val = itemData[kValue];
                    // Log.v("index==$index,name==$name,value=$val");
                    if (type == DataItemType.CellInput) {
                      return ModelListItemAddTextView(
                        text: val ?? '',
                        title: name ?? '',
                        show: itemData[kShow] ?? true,
                        canEdit: widget.canEdit,
                        level: itemData[kLevel] == null ? 0 : itemData[kLevel],
                        callback: (value) {
                          itemData[kValue] = value;
                        },
                      );
                    } else if (type == DataItemType.ModelList) {
                      return InkWell(
                        onTap: () async {
                          List<List<Map<String, dynamic>>> _currentItemList = [];
                          if (itemData[kData] != null) {
                            _currentItemList.addAll(itemData[kData]);
                          }
                          await Navigator.of(context).push(
                            MaterialPageRoute(
                              builder: (context) => ModelListPageView(
                                title: name,
                                className: name,
                                propertys: val,
                                itemList: _currentItemList,
                                needAddAction: widget.canEdit,
                                callback: (List<List<Map<String, dynamic>>> value) {
                                  itemData[kData] = value;
                                },
                              ),
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
                                  name,
                                  style: kMainLabelStyle,
                                ),
                                Expanded(
                                  child: Center(
                                    child: _getNumberText(itemData),
                                  ),
                                ),
                                Icon(Icons.arrow_forward_ios),
                              ],
                            ),
                          ),
                        ),
                      );
                    } else if (type == DataItemType.Menu) {
                      return MenuItemView(
                        title: itemData[kName],
                        selectedCallback: (value) {
                          itemData[kValue] = value;
                        },
                        list: itemData[kData],
                        initValue: itemData[kValue],
                        menuBtnKeyString: '',
                        level: itemData[kLevel],
                        type: widget.canEdit ? 1 : 2,
                      );
                    } else if (type == DataItemType.Group) {
                      return GroupItem(
                        open: itemData[kGroupArrowOpen] ?? true,
                        groupName: itemData[kName],
                        level: itemData[kLevel],
                        groupInfoCallback: () {
                          setState(() {
                            String id = itemData[kID];
                            if (itemData[kGroupArrowOpen] != null) {
                              bool open = itemData[kGroupArrowOpen];
                              widget.data[index][kGroupArrowOpen] = !open;
                              for (int i = 0; i < widget.data!.length; i++) {
                                Map map = widget.data![i];
                                String currentId = map[kID];
                                if (currentId.contains(id) && map[kLevel] > 1) {
                                  widget.data[i][kShow] = !open;
                                }
                              }
                            } else {
                              widget.data[index][kGroupArrowOpen] = false;
                              for (int i = 0; i < widget.data!.length; i++) {
                                Map map = widget.data![i];
                                String currentId = map[kID];
                                if (currentId.contains(id) && map[kLevel] > 1) {
                                  widget.data[i][kShow] = false;
                                }
                              }
                            }
                          });
                        },
                      );
                    } else {
                      return Container(
                        height: 80,
                        color: Colors.orange,
                        child: Center(child: Text(type == null ? "Name $name has no type" : "Type $type is not implemented")),
                      );
                    }
                  },
                ),
              ),
            ],
          ),
        ),
      ),
    );
    ;
  }
}

class ModelListItemAddDialog extends Dialog {
  const ModelListItemAddDialog({
    required this.data,
    this.canEdit = true,
    this.refresh,
    this.title = '',
  });

  final List<Map<String, dynamic>> data;
  final bool canEdit;
  final Function? refresh;
  final String title;
  @override
  Widget build(BuildContext context) {
    return ModelListItemAddDialogSubView(
      data: this.data,
      canEdit: this.canEdit,
      title: title,
      refresh: () {
        if (this.refresh != null) {
          this.refresh!();
        }
      },
    );
  }
}

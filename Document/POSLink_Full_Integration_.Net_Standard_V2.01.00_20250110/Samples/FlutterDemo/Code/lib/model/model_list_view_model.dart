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
import 'package:poslink2/main.dart';

class ModelListViewModel extends ChangeNotifier {
  ModelListViewModel({this.dataSource});

  List<List<Map<String, dynamic>>>? dataSource;
  List<List<Map<String, dynamic>>>? _showSource;
  get showList => _showSource;

  /// for request page
  addElements(List<Map<String, dynamic>> element) {
    dataSource!.add(element);
    updateShowList();
    notifyListeners();
  }

  /// for request page
  removeElements(int index) {
    dataSource!.removeAt(index);
    updateShowList();
    notifyListeners();
  }

  void updateShowList() {
    List<List<Map<String, dynamic>>> list = [];

    dataSource!.forEach((element) {
      List<Map<String, dynamic>> subList = [];
      element.forEach((item) {
        if (item[kShow] == null) {
          item[kShow] = true;
        }
        if (item[kShow] != null && item[kShow] == true) {
          subList.add(Map.from(item));
        }
      });
      list.add(List.from(subList));
    });
    _showSource = List.from(list);
    notifyListeners();
  }

  refreshGroupTypeStatus(int index, String groupId) {
    List subList = dataSource![index];
    subList.forEach((element) {
      String kid = element[kID];
      if (kid.contains(groupId)) {
        if (element[kType] != DataItemType.Group) {
          if (element[kShow] != null) {
            bool show = element[kShow];
            element[kShow] = !show;
          }
        } else {
          if (element[kGroupArrowOpen] != null) {
            bool open = element[kGroupArrowOpen];
            element[kGroupArrowOpen] = !open;
          }
        }
      }
    });
    updateShowList();
  }
}

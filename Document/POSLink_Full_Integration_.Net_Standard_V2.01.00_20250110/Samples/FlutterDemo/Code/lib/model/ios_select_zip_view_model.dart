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
import 'package:poslink2/auto_pigeon/poslink_ios_native_file.dart';

import '../auto_pigeon/poslink_sdk_log_set.dart';

class SelectIOSZipViewModel extends ChangeNotifier {
  List<String?>? _data = [];
  get data {
    return _data;
  }

  Future load() async {
    _data = await POSLinkIOSFileApi().getZipFilePathsFromDocuments();
    notifyListeners();
  }
}

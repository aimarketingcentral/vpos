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
import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';
import 'package:flutter_localizations/flutter_localizations.dart';
import 'package:poslink2/log/dart_log.dart';
import 'package:poslink2/model/android_view_model.dart';
import 'package:poslink2/model/comm_setting_view_model.dart';
import 'package:poslink2/model/customformmanage_view_model.dart';
import 'package:poslink2/model/device_view_model.dart';
import 'package:poslink2/model/form_view_model.dart';
import 'package:poslink2/model/ios_log_view_model.dart';
import 'package:poslink2/model/ios_select_zip_view_model.dart';
import 'package:poslink2/model/main_page_view_model.dart';
import 'package:poslink2/model/manage_view_model.dart';
import 'package:poslink2/model/multicommand_view_model.dart';
import 'package:poslink2/model/payload_view_model.dart';
import 'package:poslink2/model/ped_view_model.dart';
import 'package:poslink2/model/report_status_view_model.dart';
import 'package:poslink2/model/request_db.dart';
import 'package:poslink2/model/response_db.dart';
import 'package:poslink2/res/size_fit.dart';
import 'package:poslink2/ui/main_page.dart';
import 'package:provider/provider.dart';
import 'generated/l10n.dart';
import 'model/full_integration_view_model.dart';
import 'model/log_setting_view_model.dart';
import 'package:window_manager/window_manager.dart';

Future<void> main() async {
  Log.customize("POSLink2", level: kDebugMode ? LogLevel.ON : LogLevel.OFF, showTrace: Platform.isIOS ? false : true);
  // enableFlutterDriverExtension();
  if (Platform.isWindows) {
    WidgetsFlutterBinding.ensureInitialized();
    await windowManager.ensureInitialized();

    WindowOptions windowOptions = const WindowOptions(
      size: Size(1200, 800),
      minimumSize: Size(400, 300),
      center: true,
      backgroundColor: Colors.transparent,
      skipTaskbar: false,
      titleBarStyle: TitleBarStyle.normal,
      windowButtonVisibility: false,
    );
    windowManager.waitUntilReadyToShow(windowOptions, () async {
      await windowManager.show();
      await windowManager.focus();
    });
  }
  await TTSizeFit.ensureScreenSize();
  runApp(MultiProvider(
    providers: [
      ChangeNotifierProvider(create: (context) => RequestDataBase()),
      ChangeNotifierProvider(create: (context) => ResponseDataBase()),
      ChangeNotifierProvider(create: (context) => CommSettingViewModel()),
      ChangeNotifierProvider(create: (context) => LogSettingViewModel()),
      ChangeNotifierProvider(create: (context) => FullIntegrationViewModel()),
      ChangeNotifierProvider(create: (context) => MutiCommandViewModel()),
      ChangeNotifierProvider(create: (context) => FormViewModel()),
      ChangeNotifierProvider(create: (context) => ManageViewModel()),
      ChangeNotifierProvider(create: (context) => PedViewModel()),
      ChangeNotifierProvider(create: (context) => PayloadViewModel()),
      ChangeNotifierProvider(create: (context) => CustomFormManageModel()),
      ChangeNotifierProvider(create: (context) => DeviceViewModel()),
      ChangeNotifierProvider(create: (context) => IOSLogViewModel()),
      ChangeNotifierProvider(create: (context) => ReportStatusViewModel()),
      ChangeNotifierProvider(create: (context) => MainPageViewModel()),
      ChangeNotifierProvider(create: (context) => SelectIOSZipViewModel()),
      ChangeNotifierProvider(create: (context) => AndroidViewModel()),
    ],
    child: MyApp(),
  ));
}

class MyApp extends StatelessWidget {
  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    TTSizeFit.initialize(context);
    return MaterialApp(
      localizationsDelegates: const [
        // app-specific localization delegate[s] here
        S.delegate,
        GlobalMaterialLocalizations.delegate,
        GlobalWidgetsLocalizations.delegate,
        GlobalCupertinoLocalizations.delegate,
      ],
      supportedLocales: S.delegate.supportedLocales,
      home: MainPage(),
    );
  }
}

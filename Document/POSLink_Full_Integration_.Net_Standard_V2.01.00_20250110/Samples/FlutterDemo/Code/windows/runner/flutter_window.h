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

#ifndef RUNNER_FLUTTER_WINDOW_H_
#define RUNNER_FLUTTER_WINDOW_H_

#include <flutter/dart_project.h>
#include <flutter/flutter_view_controller.h>

#include <memory>

#include "run_loop.h"
#include "win32_window.h"
#include "plugin\POSLinkPluginLogSet.h"
#include "plugin\POSLinkPluginSet.h"
#include "plugin\POSLinkPluginDevice.h"
#include "plugin\POSLinkPluginForm.h"
#include "plugin\POSLinkPluginManage.h"
#include "plugin\POSLinkPluginPayload.h"
#include "plugin\POSLinkPluginPed.h"
#include "plugin\POSLinkPluginFullIntegration.h"
#include "plugin\POSLinkPluginMultiCommand.h"
#include "plugin\POSLinkPluginGetReportStatus.h"

// A window that does nothing but host a Flutter view.
class FlutterWindow : public Win32Window {
 public:
  // Creates a new FlutterWindow driven by the |run_loop|, hosting a
  // Flutter view running |project|.
  explicit FlutterWindow(RunLoop* run_loop,
                         const flutter::DartProject& project);
  virtual ~FlutterWindow();

 protected:
  // Win32Window:
  bool OnCreate() override;
  void OnDestroy() override;
  LRESULT MessageHandler(HWND window, UINT const message, WPARAM const wparam,
                         LPARAM const lparam) noexcept override;

 private:
  // The run loop driving events for this window.
  RunLoop* run_loop_;

  // The project to run.
  flutter::DartProject project_;

  // The Flutter instance hosted by this window.
  std::unique_ptr<flutter::FlutterViewController> flutter_controller_;
};

#endif  // RUNNER_FLUTTER_WINDOW_H_

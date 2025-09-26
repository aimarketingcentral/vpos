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

#include "flutter_window.h"

#include <optional>

#include "flutter/generated_plugin_registrant.h"

FlutterWindow::FlutterWindow(RunLoop* run_loop,
                             const flutter::DartProject& project)
    : run_loop_(run_loop), project_(project) {}

FlutterWindow::~FlutterWindow() {}

bool FlutterWindow::OnCreate() {
  if (!Win32Window::OnCreate()) {
    return false;
  }

  RECT frame = GetClientArea();

  // The size here must match the window dimensions to avoid unnecessary surface
  // creation / destruction in the startup path.
  flutter_controller_ = std::make_unique<flutter::FlutterViewController>(
      frame.right - frame.left, frame.bottom - frame.top, project_);
  // Ensure that basic setup of the controller was successful.
  if (!flutter_controller_->engine() || !flutter_controller_->view()) {
    return false;
  }
  RegisterPlugins(flutter_controller_->engine());

  POSLinkSet::POSLinkSetApi* poslink_plugin_set = new POSLinkSet::POSLinkPluginSet();
  POSLinkSet::POSLinkSetApi::SetUp(flutter_controller_->engine()->messenger(), poslink_plugin_set);
  POSLinkLogSet::POSLinkLogSetApi* poslink_plugin_log_set = new POSLinkLogSet::POSLinkPluginLogSet();
  POSLinkLogSet::POSLinkLogSetApi::SetUp(flutter_controller_->engine()->messenger(), poslink_plugin_log_set);
  POSLinkDevice::POSLinkDeviceApi* poslink_plugin_device = new POSLinkDevice::POSLinkPluginDevice();
  POSLinkDevice::POSLinkDeviceApi::SetUp(flutter_controller_->engine()->messenger(), poslink_plugin_device);
  POSLinkForm::POSLinkFormApi* poslink_plugin_form = new POSLinkForm::POSLinkPluginForm();
  POSLinkForm::POSLinkFormApi::SetUp(flutter_controller_->engine()->messenger(), poslink_plugin_form);
  POSLinkManage::POSLinkManageApi* poslink_plugin_manage = new POSLinkManage::POSLinkPluginManage();
  POSLinkManage::POSLinkManageApi::SetUp(flutter_controller_->engine()->messenger(), poslink_plugin_manage);
  POSLinkPayload::POSLinkPayloadApi* poslink_plugin_payload = new POSLinkPayload::POSLinkPluginPayload();
  POSLinkPayload::POSLinkPayloadApi::SetUp(flutter_controller_->engine()->messenger(), poslink_plugin_payload);
  POSLinkPed::POSLinkPedApi* poslink_plugin_ped = new POSLinkPed::POSLinkPluginPed();
  POSLinkPed::POSLinkPedApi::SetUp(flutter_controller_->engine()->messenger(), poslink_plugin_ped);
  POSLinkFullIntegration::POSLinkFullIntegrationApi* poslink_plugin_fullintegration = new POSLinkFullIntegration::POSLinkPluginFullIntegration();
  POSLinkFullIntegration::POSLinkFullIntegrationApi::SetUp(flutter_controller_->engine()->messenger(), poslink_plugin_fullintegration);
  POSLinkGetReportStatus::POSLinkGetReportStatusApi* poslink_plugin_report_status = new POSLinkGetReportStatus::POSLinkPluginGetReportStatus();
  POSLinkGetReportStatus::POSLinkGetReportStatusApi::SetUp(flutter_controller_->engine()->messenger(), poslink_plugin_report_status);
  POSLinkMultiCommand::POSLinkMultiCommandApi* poslink_plugin_multi_command = new POSLinkMultiCommand::POSLinkPluginMultiCommand();
  POSLinkMultiCommand::POSLinkMultiCommandApi::SetUp(flutter_controller_->engine()->messenger(), poslink_plugin_multi_command);

  run_loop_->RegisterFlutterInstance(flutter_controller_->engine());
  SetChildContent(flutter_controller_->view()->GetNativeWindow());
  return true;
}

void FlutterWindow::OnDestroy() {
  if (flutter_controller_) {
    run_loop_->UnregisterFlutterInstance(flutter_controller_->engine());
    flutter_controller_ = nullptr;
  }

  Win32Window::OnDestroy();
}

LRESULT
FlutterWindow::MessageHandler(HWND hwnd, UINT const message,
                              WPARAM const wparam,
                              LPARAM const lparam) noexcept {
  // Give Flutter, including plugins, an opportunity to handle window messages.
  if (flutter_controller_) {
    std::optional<LRESULT> result =
        flutter_controller_->HandleTopLevelWindowProc(hwnd, message, wparam,
                                                      lparam);
    if (result) {
      return *result;
    }
  }

  switch (message) {
    case WM_FONTCHANGE:
      flutter_controller_->engine()->ReloadSystemFonts();
      break;
  }

  return Win32Window::MessageHandler(hwnd, message, wparam, lparam);
}

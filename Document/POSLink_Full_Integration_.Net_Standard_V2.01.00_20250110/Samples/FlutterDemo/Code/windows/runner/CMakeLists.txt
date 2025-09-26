cmake_minimum_required(VERSION 3.15)
project(runner LANGUAGES CXX)
aux_source_directory(pigeon PIGEON)
aux_source_directory(plugin PLUGIN)
aux_source_directory(plugin/POSLinkDevice POSLINKDEVICE)
aux_source_directory(plugin/POSLinkManage POSLINKMANAGE)
aux_source_directory(plugin/POSLinkForm POSLINKFORM)
aux_source_directory(plugin/POSLinkPayload POSLINKPAYLOAD)
aux_source_directory(plugin/POSLinkPed POSLINKPED)
aux_source_directory(plugin/POSLinkFullIntegration POSLINKFULLINTEGRATION)

add_executable(${BINARY_NAME} WIN32
  "flutter_window.cpp"
  "main.cpp"
  "run_loop.cpp"
  "utils.cpp"
  "win32_window.cpp"
  "${FLUTTER_MANAGED_DIR}/generated_plugin_registrant.cc"
  "Runner.rc"
  "runner.exe.manifest"
  "poslink_single.cpp"
  ${PIGEON}
  ${PLUGIN}
  ${POSLINKDEVICE}
  ${POSLINKFORM}
  ${POSLINKFULLINTEGRATION}
  ${POSLINKMANAGE}
  ${POSLINKPAYLOAD}
  ${POSLINKPED}
            
)
apply_standard_settings(${BINARY_NAME})
target_compile_definitions(${BINARY_NAME} PRIVATE "NOMINMAX")
target_link_libraries(${BINARY_NAME} PRIVATE flutter flutter_wrapper_app)
target_include_directories(${BINARY_NAME} PRIVATE "${CMAKE_SOURCE_DIR}")
add_dependencies(${BINARY_NAME} flutter_assemble)

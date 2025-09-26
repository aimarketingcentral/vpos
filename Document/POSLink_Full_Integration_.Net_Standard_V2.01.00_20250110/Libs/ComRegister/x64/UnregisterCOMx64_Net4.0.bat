@echo off
cd /D %~dp0
echo ------------------UNREGISTER COM for X64 .NetFramework4.0-----------------------
if not exist %SYSTEMROOT%\Microsoft.NET\Framework64\v4.0.30319\regasm.exe goto PathNotExist

:register
%SYSTEMROOT%\Microsoft.NET\Framework64\v4.0.30319\regasm.exe ..\..\POSLinkFullIntegration.dll /u /codebase
%SYSTEMROOT%\Microsoft.NET\Framework64\v4.0.30319\regasm.exe ..\..\POSLinkAdmin.dll /u /codebase
%SYSTEMROOT%\Microsoft.NET\Framework64\v4.0.30319\regasm.exe ..\..\POSLinkUart.dll /u /codebase
%SYSTEMROOT%\Microsoft.NET\Framework64\v4.0.30319\regasm.exe ..\..\POSLinkCore.dll /u /codebase
pause
exit

:PathNotExist
echo Error: Can not find Regasm.exe. Please install .NetFramework4.0.
pause
exit
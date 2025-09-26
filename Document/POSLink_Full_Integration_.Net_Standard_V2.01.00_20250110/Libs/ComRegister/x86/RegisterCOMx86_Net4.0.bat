@echo off
cd /D %~dp0
echo ------------------REGISTER COM for x86 .NetFramework4.0-----------------------
if not exist %SYSTEMROOT%\Microsoft.NET\Framework\v4.0.30319\regasm.exe goto PathNotExist

:register
%SYSTEMROOT%\Microsoft.NET\Framework\v4.0.30319\regasm.exe ..\..\POSLinkCore.dll /codebase
%SYSTEMROOT%\Microsoft.NET\Framework\v4.0.30319\regasm.exe ..\..\POSLinkUart.dll /codebase
%SYSTEMROOT%\Microsoft.NET\Framework\v4.0.30319\regasm.exe ..\..\POSLinkAdmin.dll /codebase
%SYSTEMROOT%\Microsoft.NET\Framework\v4.0.30319\regasm.exe ..\..\POSLinkFullIntegration.dll /codebase

pause
exit

:PathNotExist
echo Error: Can not find Regasm.exe. Please install .NetFramework4.0.
pause
exit

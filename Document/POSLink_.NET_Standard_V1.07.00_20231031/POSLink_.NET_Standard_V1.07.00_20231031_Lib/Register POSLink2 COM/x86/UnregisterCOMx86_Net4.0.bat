@echo off
cd /D %~dp0
echo ------------------UNREGISTER COM for X86 .NetFramework4.0-----------------------
if not exist %SYSTEMROOT%\Microsoft.NET\Framework\v4.0.30319\regasm.exe goto PathNotExist

:register
%SYSTEMROOT%\Microsoft.NET\Framework\v4.0.30319\regasm.exe POSLink2.dll /u /codebase
pause
exit

:PathNotExist
echo Error: Can not find Regasm.exe. Please install .NetFramework4.0.
pause
exit
@echo off
echo --------------------------SIGNATURE--------------------------
PATH C:\Program Files (x86)\Microsoft SDKs\Windows\v7.0A\bin\NETFX 4.0 Tools
SN.exe -R POSLink2.dll MyKey.snk
echo ------------------------TLB EXPORT---------------------------
PATH C:\Program Files (x86)\Microsoft SDKs\Windows\v7.0A\bin\NETFX 4.0 Tools
tlbexp.exe POSLink2.dll /out:POSLink2.tlb
@pause 

exit
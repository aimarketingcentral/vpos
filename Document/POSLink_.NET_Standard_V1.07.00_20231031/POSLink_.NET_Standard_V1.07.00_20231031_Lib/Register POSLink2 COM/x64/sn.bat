@echo off
echo --------------------------SIGNATURE--------------------------
PATH C:\Program Files (x86)\Microsoft SDKs\Windows\v7.0A\Bin\NETFX 4.0 Tools\x64
SN.exe -R POSLink2.dll MyKey.snk
echo ------------------------TLB EXPORT---------------------------
PATH C:\Program Files (x86)\Microsoft SDKs\Windows\v7.0A\Bin\NETFX 4.0 Tools\x64
tlbexp.exe POSLink2.dll /out:POSLink2.tlb
@pause 

exit
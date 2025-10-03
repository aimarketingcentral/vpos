#include <iostream>
#include <tchar.h>
#include<windows.h>
#include <atlbase.h> 

#import "POSLink2.tlb" no_namespace, raw_interfaces_only //It is x64 in this demo.

int Run()
{
	CoInitialize(NULL);
	//set CLSID
	CLSID clsidTcpSetting, clsidPosLink2, clsidTerminal, clsidTransaction, clsidManage, clsidInitRsp, clsidExecutionResult, clsidCommSetting;
	CLSIDFromProgID(OLESTR("POSLink2.CommSetting.TcpSetting"), &clsidTcpSetting);
	CLSIDFromProgID(OLESTR("POSLink2.CommSetting.CommSetting"), &clsidCommSetting);
	CLSIDFromProgID(OLESTR("POSLink2.Transaction"), &clsidTransaction);
	CLSIDFromProgID(OLESTR("POSLink2.Manage"), &clsidManage);
	CLSIDFromProgID(OLESTR("POSLink2.Manage.InitRsp"), &clsidInitRsp);
	CLSIDFromProgID(OLESTR("POSLink2.POSLink2"), &clsidPosLink2);
	CLSIDFromProgID(OLESTR("POSLink2.Terminal"), &clsidTerminal);
	CLSIDFromProgID(OLESTR("POSLink2.ExecutionResult"), &clsidExecutionResult);
	{
		//set Commsetting
		int timeOut = 30000;
		BSTR ip = ::SysAllocString(L"127.0.0.1");
		int port = 10009;

		CComPtr<_TcpSetting> pComTcpSetting;
		HRESULT hr = pComTcpSetting.CoCreateInstance(clsidTcpSetting);		

		pComTcpSetting->put_Ip(ip);
		pComTcpSetting->put_Port(port);
		pComTcpSetting->put_Timeout(timeOut);

		CComPtr<_Terminal> pComTerminal;

		CComPtr<_CommSetting> pCommSetting = NULL;
		pComTcpSetting.QueryInterface(&pCommSetting);

		pComTerminal = NULL;
		CComPtr<_POSLink2> pComPOSLink2;
		pComPOSLink2.CoCreateInstance(clsidPosLink2);
		hr = pComPOSLink2->GetTerminal(pCommSetting, &pComTerminal);

		CComPtr<_Manage> pComManage = NULL;
		pComTerminal->get_Manage(&pComManage);

		CComPtr<_InitRsp> pComInitRsp = NULL;

		CComPtr<_ExecutionResult> pComExecutionResult = NULL;

		pComManage->Init(&pComInitRsp, &pComExecutionResult);

		Code retResponseCode;
		pComExecutionResult->GetErrorCode(&retResponseCode);
		if (retResponseCode == Code::Code_Ok)
		{
			BSTR rspCode = NULL;
			pComInitRsp->get_ResponseCode(&rspCode);
			std::cout << "Response code: " << (_bstr_t)rspCode << std::endl;

			BSTR rspMsg = NULL;
			pComInitRsp->get_ResponseMessage(&rspMsg);
			std::cout << "Response message: " << (_bstr_t)rspMsg << std::endl;
		}
		else
		{
			std::cout << "Error! "<< std::endl;
		}
	}
	CoUninitialize();
	return 0;
}

int main()
{
	std::cout << "Init" << std::endl;
	Run();
	system("pause");
}

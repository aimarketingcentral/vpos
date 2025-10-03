unit POSLink2DemoForm;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, POSLink2_TLB;

type
  TForm1 = class(Vcl.Forms.TForm)  //POSLink_TLB has TForm interface, so change the TForm to Vcl.Forms.TForm.
    Label1: TLabel;
    Label2: TLabel;
    AmountEdit: TEdit;
    Label3: TLabel;
    RefNumEdit: TEdit;
    ExitButton: TButton;
    StartButton: TButton;
    procedure StartButtonClick(Sender: TObject);
    procedure ExitButtonClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  pos1ink:_POSLink2;
  terminal:_Terminal;
  com:_CommSetting;
  tcpSetting:_TcpSetting;
  doCreditReq:_DoCreditReq;
  doCreditRsp:_DoCreditRsp;
  ret:_ExecutionResult;
  retResponseCode:Code;

implementation

{$R *.dfm}

procedure TForm1.ExitButtonClick(Sender: TObject);
begin
  Form1.Close;
end;

procedure TForm1.StartButtonClick(Sender: TObject);
begin
  tcpSetting:= CoTcpSetting.Create();
  tcpSetting.Ip:= '127.0.0.1';
  tcpSetting.Port:=10009;
  tcpSetting.Timeout:=30000;
  tcpSetting.QueryInterface(_CommSetting, com);

  pos1ink:= CoPosLink2_.Create();
  terminal:= pos1ink.GetTerminal(com);

  doCreditReq:= CoDoCreditReq.Create();
  doCreditReq.TransactionType:= TransType_Sale;
  doCreditReq.AmountInformation.TransactionAmount:= AmountEdit.Text;
  doCreditReq.TraceInformation.EcrRefNum:= RefNumEdit.Text;

  doCreditRsp:= CoDoCreditRsp.Create();
  ret:= terminal.Transaction.DoCredit(doCreditReq, &doCreditRsp);
  retResponseCode:=ret.GetErrorCode();
  if (retResponseCode = Code_Ok) then
  begin
       MessageBox(Form1.Handle,PWideChar('ResultCode :'+doCreditRsp.ResponseCode + #13
                  + 'ResultTxt :'+doCreditRsp.ResponseMessage + #13),PWideChar(retResponseCode),MB_OK);
  end
  else
  begin
       MessageBox(Form1.Handle,PWideChar(retResponseCode),'Error Processing Payment',MB_OK);
  end;
end;

end.

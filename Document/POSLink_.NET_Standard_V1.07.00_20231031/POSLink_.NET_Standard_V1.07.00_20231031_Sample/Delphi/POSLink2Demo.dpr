program POSLink2Demo;

uses
  Vcl.Forms,
  POSLink2DemoForm in 'POSLink2DemoForm.pas' {Form1};

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.

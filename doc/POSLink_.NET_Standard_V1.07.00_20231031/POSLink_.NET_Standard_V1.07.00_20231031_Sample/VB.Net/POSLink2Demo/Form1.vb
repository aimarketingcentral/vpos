Public Class Form1
    Private Sub BN_Start_Click(sender As Object, e As EventArgs) Handles BN_Start.Click
        Dim commSetting As POSLink2.CommSetting.TcpSetting = New POSLink2.CommSetting.TcpSetting
        commSetting.Ip = "127.0.0.1"
        commSetting.Port = 10009
        commSetting.Timeout = 10000

        Dim poslink As POSLink2.POSLink2 = POSLink2.POSLink2.GetPOSLink2
        Dim terminal As POSLink2.Terminal = poslink.GetTerminal(commSetting)

        Dim doCreditReq As POSLink2.Transaction.DoCreditReq = New POSLink2.Transaction.DoCreditReq
        doCreditReq.TransactionType = CB_TransactionType.SelectedIndex + 2
        doCreditReq.AmountInformation.TransactionAmount = TB_Amount.Text
        doCreditReq.TraceInformation.EcrRefNum = TB_RefNumber.Text

        Dim doCreditRsp As POSLink2.Transaction.DoCreditRsp = New POSLink2.Transaction.DoCreditRsp
        Dim ret As POSLink2.ExecutionResult = terminal.Transaction.DoCredit(doCreditReq, doCreditRsp)
        Select Case (ret.GetErrorCode)
            Case POSLink2.ExecutionResult.Code.Ok
                Dim retMsg As String = "Response Code: " + doCreditRsp.ResponseCode + vbCrLf + "Response Message: " + doCreditRsp.ResponseMessage
                MessageBox.Show(retMsg)
            Case Else
                MessageBox.Show("Error: " + ret.GetErrorCode.ToString)
        End Select
    End Sub

    Private Sub BN_Cancel_Click(sender As Object, e As EventArgs) Handles BN_Cancel.Click
        Application.Exit()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CB_TransactionType.SelectedIndex = 0
    End Sub
End Class

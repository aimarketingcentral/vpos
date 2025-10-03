<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.LB_TransactionType = New System.Windows.Forms.Label()
        Me.CB_TransactionType = New System.Windows.Forms.ComboBox()
        Me.LB_TenderType = New System.Windows.Forms.Label()
        Me.LB_Amount = New System.Windows.Forms.Label()
        Me.TB_Amount = New System.Windows.Forms.TextBox()
        Me.LB_RefNumber = New System.Windows.Forms.Label()
        Me.TB_RefNumber = New System.Windows.Forms.TextBox()
        Me.BN_Cancel = New System.Windows.Forms.Button()
        Me.BN_Start = New System.Windows.Forms.Button()
        Me.TB_TenderType = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'LB_TransactionType
        '
        Me.LB_TransactionType.AutoSize = True
        Me.LB_TransactionType.Location = New System.Drawing.Point(12, 41)
        Me.LB_TransactionType.Name = "LB_TransactionType"
        Me.LB_TransactionType.Size = New System.Drawing.Size(101, 12)
        Me.LB_TransactionType.TabIndex = 0
        Me.LB_TransactionType.Text = "Transaction Type"
        '
        'CB_TransactionType
        '
        Me.CB_TransactionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_TransactionType.FormattingEnabled = True
        Me.CB_TransactionType.Items.AddRange(New Object() {"Sale", "Return", "Auth", "PostAuth", "ForceAuth", "Adjust", "Withdrawal", "Activate", "Issue", "Reload", "CashOut", "Deactivate", "Replace", "Merge", "ReportLost", "Void", "VoidSale", "VoidReturn", "VoidAuth", "VoidPostAuth", "VoidForceAuth", "VoidWithdrawal", "Inquiry", "Verify", "Reactivate", "ForcedIssue", "ForcedAdd", "Unload", "Renew", "GetConvertDetail", "Convert", "Tokenize", "IncrementalAuth", "BalanceWithLock", "RedemptionWithLock", "Rewards", "Reenter", "TransactionAdjustment", "Transfer", "Finalize"})
        Me.CB_TransactionType.Location = New System.Drawing.Point(119, 38)
        Me.CB_TransactionType.Name = "CB_TransactionType"
        Me.CB_TransactionType.Size = New System.Drawing.Size(237, 20)
        Me.CB_TransactionType.TabIndex = 1
        '
        'LB_TenderType
        '
        Me.LB_TenderType.AutoSize = True
        Me.LB_TenderType.Location = New System.Drawing.Point(42, 15)
        Me.LB_TenderType.Name = "LB_TenderType"
        Me.LB_TenderType.Size = New System.Drawing.Size(71, 12)
        Me.LB_TenderType.TabIndex = 2
        Me.LB_TenderType.Text = "Tender Type"
        '
        'LB_Amount
        '
        Me.LB_Amount.AutoSize = True
        Me.LB_Amount.Location = New System.Drawing.Point(72, 67)
        Me.LB_Amount.Name = "LB_Amount"
        Me.LB_Amount.Size = New System.Drawing.Size(41, 12)
        Me.LB_Amount.TabIndex = 3
        Me.LB_Amount.Text = "Amount"
        '
        'TB_Amount
        '
        Me.TB_Amount.Location = New System.Drawing.Point(119, 64)
        Me.TB_Amount.Name = "TB_Amount"
        Me.TB_Amount.Size = New System.Drawing.Size(237, 21)
        Me.TB_Amount.TabIndex = 4
        '
        'LB_RefNumber
        '
        Me.LB_RefNumber.AutoSize = True
        Me.LB_RefNumber.Location = New System.Drawing.Point(48, 94)
        Me.LB_RefNumber.Name = "LB_RefNumber"
        Me.LB_RefNumber.Size = New System.Drawing.Size(65, 12)
        Me.LB_RefNumber.TabIndex = 3
        Me.LB_RefNumber.Text = "Ref Number"
        '
        'TB_RefNumber
        '
        Me.TB_RefNumber.Location = New System.Drawing.Point(119, 91)
        Me.TB_RefNumber.Name = "TB_RefNumber"
        Me.TB_RefNumber.Size = New System.Drawing.Size(237, 21)
        Me.TB_RefNumber.TabIndex = 4
        '
        'BN_Cancel
        '
        Me.BN_Cancel.Location = New System.Drawing.Point(251, 121)
        Me.BN_Cancel.Name = "BN_Cancel"
        Me.BN_Cancel.Size = New System.Drawing.Size(105, 23)
        Me.BN_Cancel.TabIndex = 5
        Me.BN_Cancel.Text = "Exit"
        Me.BN_Cancel.UseVisualStyleBackColor = True
        '
        'BN_Start
        '
        Me.BN_Start.Location = New System.Drawing.Point(140, 121)
        Me.BN_Start.Name = "BN_Start"
        Me.BN_Start.Size = New System.Drawing.Size(105, 23)
        Me.BN_Start.TabIndex = 5
        Me.BN_Start.Text = "Start"
        Me.BN_Start.UseVisualStyleBackColor = True
        '
        'TB_TenderType
        '
        Me.TB_TenderType.Location = New System.Drawing.Point(119, 12)
        Me.TB_TenderType.Name = "TB_TenderType"
        Me.TB_TenderType.ReadOnly = True
        Me.TB_TenderType.Size = New System.Drawing.Size(237, 21)
        Me.TB_TenderType.TabIndex = 4
        Me.TB_TenderType.Text = "Do Credit"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(368, 156)
        Me.Controls.Add(Me.BN_Start)
        Me.Controls.Add(Me.BN_Cancel)
        Me.Controls.Add(Me.TB_RefNumber)
        Me.Controls.Add(Me.LB_RefNumber)
        Me.Controls.Add(Me.TB_TenderType)
        Me.Controls.Add(Me.TB_Amount)
        Me.Controls.Add(Me.LB_Amount)
        Me.Controls.Add(Me.LB_TenderType)
        Me.Controls.Add(Me.CB_TransactionType)
        Me.Controls.Add(Me.LB_TransactionType)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LB_TransactionType As Label
    Friend WithEvents CB_TransactionType As ComboBox
    Friend WithEvents LB_TenderType As Label
    Friend WithEvents LB_Amount As Label
    Friend WithEvents TB_Amount As TextBox
    Friend WithEvents LB_RefNumber As Label
    Friend WithEvents TB_RefNumber As TextBox
    Friend WithEvents BN_Cancel As Button
    Friend WithEvents BN_Start As Button
    Friend WithEvents TB_TenderType As TextBox
End Class

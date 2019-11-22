

Public Class frmLogin
  Dim cmd As New commands

  Public Sub New()

    ' This call is required by the designer.
    InitializeComponent()

    cmd = New commands
    SQLConnect.txtserver.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_server", "Value", Nothing).ToString
    SQLConnect.txtdb.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_database", "Value", Nothing).ToString
    SQLConnect.txtuser.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_user", "Value", Nothing).ToString
    SQLConnect.txtpass.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Password", "Value", Nothing).ToString
    TiT.PTS.MainForm.Show()
    TiT.PTS.MainForm.Enabled = False
    ' Add any initialization after the InitializeComponent() call.

  End Sub

  Private Sub OK_Click(sender As Object, e As EventArgs) Handles OK.Click
    checklogin()
  End Sub
  Public Sub checklogin()
    If Me.txtUserName.Text <> "" Then
      If Me.txtPassword.Text <> "" Then
        If cmd.VerifyRecord("SELECT [Number] from [Cashier] where Number = '" & Me.txtUserName.Text & "'") = True Then
          If cmd.VerifyRecord("SELECT [Password] from [Cashier] where Number = '" & Me.txtUserName.Text & "' and Password = '" & Me.txtPassword.Text & "'") = True Then
            TiT.PTS.MainForm.txtusername.Text = cmd.getSpecificRecord("SELECT [Name] from [Cashier] where Number = '" & Me.txtUserName.Text & "' and Password = '" & Me.txtPassword.Text & "' ")
            Dim uni As Integer = Integer.Parse(cmd.getSpecificRecord("SELECT [SecurityLevel]  from [Cashier] where Number = '" & Me.txtUserName.Text & "' and Password = '" & Me.txtPassword.Text & "' "))
            Dim uno As Integer = Integer.Parse(cmd.getSpecificRecord("SELECT ID  from [Cashier] where Number = '" & Me.txtUserName.Text & "' and Password = '" & Me.txtPassword.Text & "' ").ToString)
            TiT.PTS.MainForm.txtuser.Text = uno
            Dim batch As Integer = Integer.Parse(cmd.getSpecificRecord("SELECT  0+COALESCE(Max([BatchNumber]),0)  FROM [Batch]  ").ToString)
            Dim Shiftno As Integer = Integer.Parse(cmd.getSpecificRecord("SELECT  0+COALESCE(Max([ShiftNumber]),0)  FROM [OP_ShiftReading] where batch='" & batch & "' ").ToString)
            If uni = "0" Then
              TiT.PTS.MainForm.Text = "Administrator Mode " & "  Username: " & txtUserName.Text & "   Batch:" & batch & "   Shift: " & Shiftno
            Else
              TiT.PTS.MainForm.Text = "Cashier Mode" & "  Username: " & txtUserName.Text & "   Batch:" & batch & "   Shift: " & Shiftno
            End If


            Me.txtUserName.Clear()
            Me.txtPassword.Clear()
            TiT.PTS.MainForm.security = uni
            TiT.PTS.MainForm.batchNumber = batch
            TiT.PTS.MainForm.ShiftNumber = Shiftno
            TiT.PTS.MainForm.Cashierid = uno
            TiT.PTS.MainForm.storeid = 1

            Dim batch1 = cmd.getSpecificRecord("SELECT  0+COALESCE(Max(BatchNumber),0)-1  FROM Batch  ")
            If batch1 > 3 Then


              BalanceReadingBatchAuto.Show()
              BalanceReadingBatchAuto.txtbatch.Text = batch1
              BalanceReadingBatchAuto.btshow.PerformClick()
              BalanceReadingBatchAuto.btbalance.PerformClick()
              BalanceReadingBatchAuto.Close()
            End If


            TiT.PTS.MainForm.Enabled = True
            TiT.PTS.MainForm.Show()
            timesetting()
            TiT.PTS.MainForm.clearrecord()
            Me.Hide()
          Else
            MessageBox.Show("Password error do not exist!")
            Me.txtPassword.Clear()
          End If
        Else
          MessageBox.Show("User do not exist!")

        End If
      Else
        MsgBox("Please enter your Password.", vbCritical, "Required")
        Me.txtPassword.Focus()
      End If
    Else
      MsgBox("Please enter your Username.", vbCritical, "Required")
      Me.txtUserName.Focus()
    End If

  End Sub
  Public Sub timesetting()
    Dim date1 As String = cmd.getSpecificRecord("SELECT 0+COALESCE(Max([OpeningTime]),0)  FROM [batch] ")

    If date1 = "0" Then

      date1 = DateTime.Now

    End If

    TiT.PTS.MainForm.DateTimePicker1.Text = date1

  End Sub
  Private Sub Login_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

    If e.KeyCode = Keys.Enter Then
      OK.PerformClick()
    End If




  End Sub

  Private Sub frmLogin_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged

    Me.Show()
  End Sub

  Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
    Me.Close()
  End Sub
End Class
Public Class CmdptRefershPedding
  Dim cmd As commands

  Public Sub New()


    cmd = New commands

    SQLConnect.txtserver.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_server", "Value", Nothing).ToString
    SQLConnect.txtdb.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_database", "Value", Nothing).ToString
    SQLConnect.txtuser.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_user", "Value", Nothing).ToString
    SQLConnect.txtpass.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Password", "Value", Nothing).ToString


  End Sub
  Public Sub UpdatePT()
    Try
      cmd.Update($"UPDATE PumpTransactions SET      Status = '0' WHERE  Status = '1' ")
    Catch ex As Exception

    End Try

  End Sub
End Class

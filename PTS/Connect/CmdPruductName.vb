Public Class CmdPruductName
  Dim cmd As commands
  Public Sub New()


    cmd = New commands

    SQLConnect.txtserver.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_server", "Value", Nothing).ToString
    SQLConnect.txtdb.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_database", "Value", Nothing).ToString
    SQLConnect.txtuser.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_user", "Value", Nothing).ToString
    SQLConnect.txtpass.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Password", "Value", Nothing).ToString

  End Sub

  Public Function ProductName(Dispenser As Integer, nozzle As Integer) As String
    Try
      Dim _Dispenser As Integer = Dispenser
      Dim _nozzle As Integer = nozzle
      Dim Description As String = cmd.getSpecificRecord($"SELECT Description FROM [OP_PumpSettings] where [pump]='{_Dispenser}' and [Nozzle]='{_nozzle}' ").ToString

      Return Description
    Catch ex As Exception
      Return "None"
    End Try


  End Function
End Class

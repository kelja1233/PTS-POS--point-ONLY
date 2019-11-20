Public Class CmdComandTotalizerUpdateOP
  Dim cmd As commands
  Public Sub New()


    cmd = New commands
    SQLConnect.txtserver.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_server", "Value", Nothing).ToString
    SQLConnect.txtdb.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_database", "Value", Nothing).ToString
    SQLConnect.txtuser.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_user", "Value", Nothing).ToString
    SQLConnect.txtpass.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Password", "Value", Nothing).ToString


  End Sub


  Public Sub UpdateTolizer(Batch As Integer, PumpID As Integer, nozzle As Integer, TotalVolume As Decimal, TotalAmount As Decimal)

    Dim _Batch As Integer = Batch
    Dim _PumpID As Integer = PumpID
    Dim _nozzle As Integer = nozzle
    Dim _TotalVolume As Decimal = TotalVolume
    Dim _TotalAmount As Decimal = TotalAmount

    Dim cmdString As String = ""

    cmdString += "UPDATE OP_ShiftReading SET "
    cmdString += "status=0,"
    cmdString += $"EndReading={_TotalVolume},"
    cmdString += $"EndAReading={_TotalAmount}"
    cmdString += "where "
    cmdString += $"Pump={_PumpID} "
    cmdString += "and "
    cmdString += $"Nozzle={_nozzle}"
    cmdString += "and "
    cmdString += $"batch={_Batch}"

    cmd.Update(cmdString)



  End Sub


End Class

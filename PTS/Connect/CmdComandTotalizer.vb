Public Class CmdComandTotalizer
  Dim cmd As commands

  Public Sub New()


    cmd = New commands
    SQLConnect.txtserver.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_server", "Value", Nothing).ToString
    SQLConnect.txtdb.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_database", "Value", Nothing).ToString
    SQLConnect.txtuser.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_user", "Value", Nothing).ToString
    SQLConnect.txtpass.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Password", "Value", Nothing).ToString


  End Sub
  Public Function transactionPumpShow() As Integer
    cmd.Update("UPDATE PumpTransactions SET      Status = '0' WHERE    Status = '1'")

    Dim counter As Integer = Integer.Parse(cmd.getSpecificRecord("SELECT 0+COALESCE(max([ID]),0) FROM [PumpTransactions] where status=0"))
    Return counter
  End Function

  Public Sub statusupdate()

    Dim cmdString As String = ""
    cmdString += "UPDATE OP_PumpSettings SET status=1 "





    cmd.Update(cmdString)
  End Sub
  Public Function checkstatus() As Integer
    Dim tranNo As Integer = Integer.Parse(cmd.getSpecificRecord("SELECT  0+COALESCE(count([pump]),0)  FROM [OP_PumpSettings] where status=1").ToString)
    Return tranNo
  End Function
  Public Sub UpdateTolizer(PumpID As Integer, nozzle As Integer, TotalVolume As Decimal, TotalAmount As Decimal)


    Dim _PumpID As Integer = PumpID
    Dim _nozzle As Integer = nozzle
    Dim _TotalVolume As Decimal = TotalVolume
    Dim _TotalAmount As Decimal = TotalAmount

    Dim cmdString As String = ""

    cmdString += "UPDATE OP_PumpSettings SET "
    cmdString += "status=0,"
    cmdString += $"Currentreading={_TotalVolume},"
    cmdString += $"CurrentAreading={_TotalAmount}"
    cmdString += "where "
    cmdString += $"Pump={_PumpID} "
    cmdString += "and "
    cmdString += $"nozzle={_nozzle}"

    cmd.Update(cmdString)



  End Sub


End Class

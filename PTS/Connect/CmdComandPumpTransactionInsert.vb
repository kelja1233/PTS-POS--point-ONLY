Public Class CmdComandPumpTransactionInsert
  Dim cmd As commands
  Dim cmdShowPT As New CmdShowPumpTransaction
  Public Sub New()


    cmd = New commands

    SQLConnect.txtserver.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_server", "Value", Nothing).ToString
    SQLConnect.txtdb.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_database", "Value", Nothing).ToString
    SQLConnect.txtuser.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_user", "Value", Nothing).ToString
    SQLConnect.txtpass.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Password", "Value", Nothing).ToString

  End Sub

  Public Sub InsertPumpTransaction(Dispenser As Integer, nozzle As Integer, UnitPrice As Decimal, Amount As Decimal, Volume As Decimal, EndReading As Decimal, EndAReading As Decimal)




    Dim _Dispenser As Integer = Dispenser
    Dim _nozzle As Integer = nozzle
    Dim _grade As Integer = Integer.Parse(cmd.getSpecificRecord($"SELECT 0+COALESCE(Max(ItemLookupCode),0) FROM [OP_PumpSettings] where [pump]='{_Dispenser}' and [Nozzle]='{_nozzle}' "))
    Dim _UnitPrice As Decimal = UnitPrice
    Dim _Amount As Decimal = Amount
    Dim _Volume As Decimal = Volume
    Dim _EndReading As Decimal = EndReading
    Dim _EndAReading As Decimal = EndAReading
    Dim cmdstring As String = ""

    cmdstring += "INSERT INTO [PumpTransactions] "
    cmdstring += "("
    cmdstring += "grade"
    cmdstring += ",nozzle"
    cmdstring += ",Dispenser"
    cmdstring += ",UnitPrice"
    cmdstring += ",Amount"
    cmdstring += ",Volume"
    cmdstring += ",EndReading"
    cmdstring += ",EndAReading"
    cmdstring += ")"
    cmdstring += "values"
    cmdstring += "("
    cmdstring += $"'{_grade}'"          'grade
    cmdstring += $",'{_nozzle}'"          'nozzle
    cmdstring += $",'{_Dispenser}'"          'Dispenser
    cmdstring += $",'{_UnitPrice}'"          'UnitPrice
    cmdstring += $",'{_Amount}'"          'Amount
    cmdstring += $",'{_Volume}'"          'Volume
    cmdstring += $",'{_EndReading}'"          'EndReading
    cmdstring += $",'{_EndAReading}'"          'EndAReading"

    cmdstring += ")"

    If _Volume <> 0 Then
      cmd.AddRecord(cmdstring)
    End If




    cmdShowPT.ShowPT()

  End Sub

End Class

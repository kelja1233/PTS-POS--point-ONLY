Public Class cmdCheckTransaction
  Dim cmd As commands


  Public Sub New()


    cmd = New commands

    SQLConnect.txtserver.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_server", "Value", Nothing).ToString
    SQLConnect.txtdb.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_database", "Value", Nothing).ToString
    SQLConnect.txtuser.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_user", "Value", Nothing).ToString
    SQLConnect.txtpass.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Password", "Value", Nothing).ToString

  End Sub
  Public Function Grade(PtId As Integer) As Integer
    Try
      Dim _PtId As Integer = PtId

      Dim TransNum As Integer = Integer.Parse(cmd.getSpecificRecord($"SELECT  0+COALESCE(Max(Grade),0) FROM [PumpTransactions] where [id]='{_PtId}'").ToString)




      Return TransNum
    Catch ex As Exception
      Return 0
    End Try
  End Function
  Public Function Dispenser(PtId As Integer) As Integer
    Try
      Dim _PtId As Integer = PtId

      Dim TransNum As Integer = Integer.Parse(cmd.getSpecificRecord($"SELECT  0+COALESCE(Max(Dispenser),0) FROM [PumpTransactions] where [id]='{_PtId}'").ToString)




      Return TransNum
    Catch ex As Exception
      Return 0
    End Try
  End Function
  Public Function Amount(PtId As Integer) As Decimal
    Try
      Dim _PtId As Integer = PtId

      Dim TransNum As Decimal = Integer.Parse(cmd.getSpecificRecord($"SELECT  0+COALESCE(Max(Amount),0) FROM [PumpTransactions] where [id]='{_PtId}'").ToString)




      Return TransNum
    Catch ex As Exception
      Return 0
    End Try
  End Function
  Public Function Volume(PtId As Integer) As Decimal
    Try
      Dim _PtId As Integer = PtId

      Dim TransNum As Decimal = Integer.Parse(cmd.getSpecificRecord($"SELECT  0+COALESCE(Max(Volume),0) FROM [PumpTransactions] where [id]='{_PtId}'").ToString)




      Return TransNum
    Catch ex As Exception
      Return 0
    End Try
  End Function
  Public Function CheckTransNum(PtId As Integer) As Integer
    Try
      Dim _PtId As Integer = PtId

      Dim TransNum As Integer = Integer.Parse(cmd.getSpecificRecord($"SELECT  0+COALESCE(Max(TransNum),0) FROM [PumpTransactions] where [id]='{_PtId}'").ToString)



      cmd.Update($"UPDATE PumpTransactions SET      Status = '1' WHERE  [ID] ={_PtId} ")
      Return TransNum
    Catch ex As Exception
      Return 0
    End Try


  End Function
End Class

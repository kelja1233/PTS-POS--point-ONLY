Public Class Split
    Dim cmd As New commands
    Public pumpid As Integer
    Public Grade As Integer
    Public Dispenser As Integer
    Public Amount As Double
  Public Volume As Double
  Private Sub Split_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    SQLConnect.txtserver.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_server", "Value", Nothing).ToString
    SQLConnect.txtdb.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_database", "Value", Nothing).ToString
    SQLConnect.txtuser.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_user", "Value", Nothing).ToString
    SQLConnect.txtpass.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Password", "Value", Nothing).ToString


    TXTQTY1.Text = Volume
        TXTAMT1.Text = Amount

    End Sub




    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub TXTAMT2_TextChanged(sender As Object, e As EventArgs) Handles TXTAMT2.TextChanged
        Try



            TXTAMT3.Text = Double.Parse(TXTAMT1.Text) - Double.Parse(TXTAMT2.Text)

            Dim price As Double = cmd.getSpecificRecord("SELECT  price  FROM [Item]  where ItemLookupCode='" & Grade & "' ")

            TXTQTY2.Text = TXTAMT2.Text / price

            TXTQTY3.Text = Double.Parse(TXTQTY1.Text) - Double.Parse(TXTQTY2.Text)
          
       

        Catch ex As Exception

            TXTAMT2.Text = 0
            TXTAMT3.Text = 0
            TXTQTY2.Text = 0
            TXTQTY3.Text = 0
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim price As Double = cmd.getSpecificRecord("SELECT  price  FROM [Item]  where ItemLookupCode='" & Grade & "' ")
        cmd.AddRecord("INSERT INTO [PumpTransactions]([Grade],[Dispenser],[UnitPrice],[Amount],[Volume],ConsoleTime,TenderTime,TransNum,Status,batch,[Comment])values( '" & Grade & "','" & Dispenser & "','" & price & "','" & TXTAMT2.Text & "','" & TXTQTY2.Text & "',getdate(),getdate(),'0',1,'0','Split')")
        cmd.AddRecord("INSERT INTO [PumpTransactions]([Grade],[Dispenser],[UnitPrice],[Amount],[Volume],ConsoleTime,TenderTime,TransNum,Status,batch,[Comment])values( '" & Grade & "','" & Dispenser & "','" & price & "','" & TXTAMT3.Text & "','" & TXTQTY3.Text & "',getdate(),getdate(),'0',1,'0','Split')")

        cmd.AddRecord("INSERT INTO [PumpTransactionsSplit]([PumpTransactionsID],[Grade],[Dispenser],[Amount],[Volume])values( '" & pumpid & "','" & Grade & "','" & Dispenser & "','" & TXTAMT2.Text & "','" & TXTQTY2.Text & "')")
        cmd.AddRecord("INSERT INTO [PumpTransactionsSplit]([PumpTransactionsID],[Grade],[Dispenser],[Amount],[Volume])values( '" & pumpid & "','" & Grade & "','" & Dispenser & "','" & TXTAMT3.Text & "','" & TXTQTY3.Text & "')")

        cmd.Update("UPDATE PumpTransactions SET   [Amount]=0,[Volume]=0,[Comment]='SplitTOrg'  , Status = '2' WHERE  [ID] ='" & pumpid & "' ")

    TiT.PTS.MainForm.btclear.PerformClick()
    Me.Close()

    End Sub
End Class
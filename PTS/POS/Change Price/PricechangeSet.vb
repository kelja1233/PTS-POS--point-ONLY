Public Class PricechangeSet
    Dim cmd As New commands
    Private Sub btbypass_Click(sender As Object, e As EventArgs) Handles btbypass.Click

  End Sub

    Private Sub PricechangeSet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    SQLConnect.txtserver.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_server", "Value", Nothing).ToString
    SQLConnect.txtdb.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_database", "Value", Nothing).ToString
    SQLConnect.txtuser.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_user", "Value", Nothing).ToString
    SQLConnect.txtpass.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Password", "Value", Nothing).ToString
    rec()
    changeprice()
  End Sub
  Public Sub changeprice()
    For i As Integer = 0 To Me.DataGridView1.RowCount - 1
      Dim Pump As Integer = Integer.Parse(Me.DataGridView1.Rows(i).Cells(0).Value.ToString)
      Dim Nozzle As Integer = Integer.Parse(Me.DataGridView1.Rows(i).Cells(1).Value.ToString)
      Dim Price As Decimal = Decimal.Parse(Me.DataGridView1.Rows(i).Cells(3).Value.ToString)
      TiT.PTS.MainForm.zPriceChange(Pump, Nozzle, Price)

    Next
  End Sub

  Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        rec()
        Dim count = DataGridView1.RowCount
    If count = 0 Then






      Timer1.Stop()

      Me.Close()



    End If



    End Sub

    Public Sub rec()



    cmd.SelectRecord("SELECT        OP_PumpSettings.Pump, OP_PumpSettings.Nozzle, Item.Description, OP_PumpSettings.PumpIDEdit FROM OP_PumpSettings INNER JOIN Item ON OP_PumpSettings.ItemLookupCode = Item.ItemLookupCode AND OP_PumpSettings.ItemID = Item.ID where OP_PumpSettings.status=2 ORDER BY OP_PumpSettings.Inactive", "pump", Me.DataGridView1)



  End Sub
End Class
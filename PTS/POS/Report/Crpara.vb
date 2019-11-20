Public Class Crpara
  Dim cmd As New commands
  Public a As Integer
  Public b As Integer

  Private Sub Crpara_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    cmd = New commands
    SQLConnect.txtserver.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_server", "Value", Nothing).ToString
    SQLConnect.txtdb.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_database", "Value", Nothing).ToString
    SQLConnect.txtuser.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_user", "Value", Nothing).ToString
    SQLConnect.txtpass.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Password", "Value", Nothing).ToString

    Dim batch = cmd.getSpecificRecord("SELECT  0+COALESCE(Max([ReportLinkBatch]),0)  FROM [Configuration]  ")






    cmd.SelectRecord("SELECT CashierReport.BatchNumber, MAX(OP_ShiftReading.ShiftNumber) AS ShiftNumber, Cashier.Number as 'Username', MAX(CashierReport.Sales) + MAX(CashierReport.Discount) AS 'Gross Sales', MAX(CashierReport.Discount) AS 'Total Discount', MAX(CashierReport.Sales)-MAX(CashierReport.Payout) AS 'NET Sales', MAX(CashierReport.Collection) AS Collection, MAX(CashierReport.CashDrop) AS CashDrop,  MAX(CashierReport.Payout) as 'Payout' FROM CashierReport INNER JOIN OP_ShiftReading ON CashierReport.BatchNumber = OP_ShiftReading.batch INNER JOIN Cashier ON CashierReport.CashierID = Cashier.ID WHERE CashierReport.BatchNumber >= '" & batch & "' GROUP BY CashierReport.BatchNumber, Cashier.Number   ORDER BY CashierReport.BatchNumber DESC", "CashierReport", Me.DataGridView1)



  End Sub


  Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
    'If e.RowIndex = -1 Then
    a = Me.DataGridView1.Item(0, Me.DataGridView1.CurrentRow.Index).Value


    Dim cr As New CashierReport
      cr.crPrint(a)

      Me.Close()

    'End If

  End Sub
End Class
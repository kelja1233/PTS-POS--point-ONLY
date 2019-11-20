Public Class PumpBatch
    Dim cmd As New commands
    Private Sub PumpBatch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    SQLConnect.txtserver.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_server", "Value", Nothing).ToString
    SQLConnect.txtdb.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_database", "Value", Nothing).ToString
    SQLConnect.txtuser.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_user", "Value", Nothing).ToString
    SQLConnect.txtpass.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Password", "Value", Nothing).ToString

    cmd.SelectRecord("SELECT Batch.BatchNumber AS 'Batch Number', MIN(Batch.OpeningTime) AS 'Opening Time', MIN(OP_ShiftReading.ShiftNumber) AS 'Shift', Cashier.Number AS 'Username' FROM Batch INNER JOIN OP_ShiftReading ON Batch.BatchNumber = OP_ShiftReading.batch INNER JOIN Cashier ON Batch.CashierID = Cashier.ID GROUP BY Batch.BatchNumber, Cashier.Number ORDER BY 'Batch Number' DESC ", "Customer", DataGridView1)

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
    Dim pr As New PumpReadingReport

    pr.prPrint(DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value)
    'CashDrop.lbcash.Text = cmd.getSpecificRecord("SELECT  0+COALESCE(Max(CashierID),0)  FROM CashierReport where BatchNumber='" & DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value & "'  ")

    Me.Close()
    End Sub

End Class

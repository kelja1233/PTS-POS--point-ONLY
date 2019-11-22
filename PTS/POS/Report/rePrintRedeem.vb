Public Class rePrintRedeem
  Dim cmd As New commands
  Private Sub rePrintRedeem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    SQLConnect.txtserver.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_server", "Value", Nothing).ToString
    SQLConnect.txtdb.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_database", "Value", Nothing).ToString
    SQLConnect.txtuser.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_user", "Value", Nothing).ToString
    SQLConnect.txtpass.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Password", "Value", Nothing).ToString
    Dim cmdstr As String = ""
    cmdstr += "SELECT        TOP (100) Point_RedeemTransaction.ID, Point_RedeemTransaction.RebatesPoint, Point_RedeemTransaction.TransactionNumber, Point_RedeemTransaction.CustomerID, "
    cmdstr += "   Point_RedeemTransaction.Cashier, CONVERT(varchar, Point_RedeemTransaction.Datenow, 0) AS 'Time', Cashier.Name AS [Cashier Name], "
    cmdstr += "   Customer.FirstName + ' ' + Customer.LastName AS [Customer Name], Point_RedeemTransaction.LoyalPoint AS Redeem "
    cmdstr += " FROM            Point_RedeemTransaction INNER JOIN"
    cmdstr += "  Cashier ON Point_RedeemTransaction.Cashier = Cashier.ID INNER JOIN "
    cmdstr += "  Customer ON Point_RedeemTransaction.CustomerID = Customer.ID "
    cmdstr += "  order by Point_RedeemTransaction.ID desc "

    cmd.SelectRecord(cmdstr, "Customer", DataGridView1)


  End Sub
  Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick


    'CashDrop.lbcash.Text = cmd.getSpecificRecord("SELECT  0+COALESCE(Max(CashierID),0)  FROM CashierReport where BatchNumber='" & DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value & "'  ")
    Dim a1 As Integer = Integer.Parse(DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value.ToString)
    Dim a2 As Integer = Integer.Parse(DataGridView1.Item(1, DataGridView1.CurrentRow.Index).Value.ToString)
    Dim a3 As Integer = Integer.Parse(DataGridView1.Item(2, DataGridView1.CurrentRow.Index).Value.ToString)
    Dim a4 As Integer = Integer.Parse(DataGridView1.Item(3, DataGridView1.CurrentRow.Index).Value.ToString)
    Dim a5 As Integer = Integer.Parse(DataGridView1.Item(4, DataGridView1.CurrentRow.Index).Value.ToString)

    Dim rp As New PrintRedeem
    rp.printRecord(True, a1, a2, a3, a4, a5)

    Me.Close()

  End Sub
End Class
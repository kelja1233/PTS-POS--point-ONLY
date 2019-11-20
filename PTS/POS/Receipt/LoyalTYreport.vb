Public Class LoyalTYreportzz

  Public a As Integer
  Public b As Integer
  Private cmd As commands
  Private Sub LoyalTYreport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    cmd = New commands
    SQLConnect.txtserver.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_server", "Value", Nothing).ToString
    SQLConnect.txtdb.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_database", "Value", Nothing).ToString
    SQLConnect.txtuser.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_user", "Value", Nothing).ToString
    SQLConnect.txtpass.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Password", "Value", Nothing).ToString

    cmd.SelectRecord("SELECT [BatchNumber]         ,[OpeningTime]      ,[ClosingTime]    FROM [Batch] order by [BatchNumber] ", "Batch", Me.DataGridView1)
    cmd.SelectRecord("SELECT [BatchNumber]   ,[OpeningTime]      ,[ClosingTime]    FROM [Batch] order by [BatchNumber] ", "Batch", Me.DataGridView2)

  End Sub

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    a = Integer.Parse(Me.DataGridView1.Item(0, Me.DataGridView1.CurrentRow.Index).Value.ToString)
    b = Integer.Parse(Me.DataGridView2.Item(0, Me.DataGridView2.CurrentRow.Index).Value.ToString)
    Dim printlt As New LoyalTYreport
    printlt.crPrint(a, b)

    Me.Close()

  End Sub

End Class
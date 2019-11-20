Public Class ShowInventory
    Dim cmd As New commands
    Private Sub ShowInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    SQLConnect.txtserver.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_server", "Value", Nothing).ToString
    SQLConnect.txtdb.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_database", "Value", Nothing).ToString
    SQLConnect.txtuser.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_user", "Value", Nothing).ToString
    SQLConnect.txtpass.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Password", "Value", Nothing).ToString


    rec()
    End Sub



    Public Sub rec()



    cmd.SelectRecord("SELECT [ItemLookupCode]    ,[Description]  ,[Price] ,[Quantity]    FROM [Item] where categoryid=2", "Item", Me.DataGridView1)



  End Sub





    Private Sub txtaidS_TextChanged(sender As Object, e As EventArgs) Handles txtaidS.TextChanged

    cmd.SelectRecord("SELECT [ItemLookupCode]    ,[Description]  ,[Price] ,[Quantity]  FROM [Item] where categoryid=2  and [ItemLookupCode] LIKE '%" & txtaidS.Text & "%'", "Journal_Item", Me.DataGridView1)


  End Sub

    Private Sub btref_Click(sender As Object, e As EventArgs) Handles btref.Click
        rec()
    End Sub




    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick


        Dim b = cmd.getSpecificRecord("SELECT [Price]  FROM [Item] where [ItemLookupCode]='" & DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value & "' ")
        QTY.txtprice.Text = b

        QTY.ShowDialog()

    End Sub
    Public Sub sel()
        On Error Resume Next

    'sadfas
    Dim a As String = cmd.getSpecificRecord("SELECT [Description]  FROM [Item] where [ItemLookupCode]='" & DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value.ToString & "' ")
    Dim b As Decimal = Decimal.Parse(QTY.txtprice.Text)
    Dim c As Decimal = Decimal.Parse(cmd.getSpecificRecord("SELECT [Cost] FROM [Item] where [ItemLookupCode]='" & DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value.ToString & "' "))





    TiT.PTS.MainForm.DataGridView2.Rows.Add(DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value, a, Double.Parse(QTY.txtqty.Text), b, b * Double.Parse(QTY.txtqty.Text), 0, 0, 0, 0, 0)
    TiT.PTS.MainForm.RefreshRecord()





    Me.Close()
    End Sub

    Private Sub ShowInventory_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Enter Then

            QTY.ShowDialog()

        End If
        If e.KeyCode = Keys.Escape Then

            btc.PerformClick()

        End If
    End Sub
    Private Sub btc_Click(sender As Object, e As EventArgs) Handles btc.Click
        'MAIN.Enabled = True

        'Try
        '    MAIN.DataGridView1.Rows.Remove(MAIN.DataGridView1.CurrentRow)
        'Catch ex As Exception

        'End Try

        Me.Close()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
    cmd.SelectRecord("SELECT [ItemLookupCode]     ,[Description]  ,[Price] ,[Quantity]  FROM [Item] where categoryid=2  and [Description] LIKE '%" & TextBox1.Text & "%'", "Item", Me.DataGridView1)

  End Sub
End Class
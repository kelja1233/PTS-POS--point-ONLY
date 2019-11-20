Public Class ShowCustomer

    Dim cmd As New commands

    Private Sub ShowCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    SQLConnect.txtserver.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_server", "Value", Nothing).ToString
    SQLConnect.txtdb.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_database", "Value", Nothing).ToString
    SQLConnect.txtuser.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_user", "Value", Nothing).ToString
    SQLConnect.txtpass.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Password", "Value", Nothing).ToString
    rec()


    End Sub

    Public Sub rec()


    cmd.SelectRecord("SELECT top 10 [AccountNumber],[Title],[FirstName],[LastName],[Address] ,[Address2],[Company],[AccountBalance],[CreditLimit] FROM [Customer] where CreditLimit<>0 ", "Customer", Me.DataGridView1)


  End Sub


    Private Sub txtfname_TextChanged(sender As Object, e As EventArgs) Handles txtfname.TextChanged
    cmd.SelectRecord("SELECT top 10 [AccountNumber],[Title],[FirstName],[LastName],[Address] ,[Address2],[Company],[AccountBalance],[CreditLimit] FROM [Customer] where CreditLimit<>0  and   FirstName like '" & "%" & Me.txtfname.Text & "%'   ", "Customer", Me.DataGridView1)


  End Sub


    Private Sub txtLastName_TextChanged(sender As Object, e As EventArgs) Handles txtLastName.TextChanged
    cmd.SelectRecord("SELECT top 10 [AccountNumber],[Title],[FirstName],[LastName],[Address] ,[Address2],[Company],[AccountBalance],[CreditLimit] FROM [Customer] where CreditLimit<>0  and   LastName like '" & "%" & Me.txtLastName.Text & "%'", "LastName", Me.DataGridView1)

  End Sub

    Private Sub btrec_Click(sender As Object, e As EventArgs) Handles btrec.Click
        rec()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        sel()
    End Sub
    Public Sub sel()

        On Error Resume Next


    TiT.PTS.MainForm.txtact.Text = DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value.ToString

    TiT.PTS.MainForm.txtname.Text = DataGridView1.Item(3, DataGridView1.CurrentRow.Index).Value.ToString + ", " + DataGridView1.Item(2, DataGridView1.CurrentRow.Index).Value.ToString











    Me.Close()


    End Sub




    Private Sub btc_Click(sender As Object, e As EventArgs) Handles btc.Click

    Me.Close()



    End Sub

    Private Sub ShowCustomer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Enter Then

            sel()

        End If
    End Sub


End Class
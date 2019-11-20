Public Class Adjustment
    Dim cmd As New commands
    Private Sub Adjustment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    SQLConnect.txtserver.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_server", "Value", Nothing).ToString
    SQLConnect.txtdb.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_database", "Value", Nothing).ToString
    SQLConnect.txtuser.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_user", "Value", Nothing).ToString
    SQLConnect.txtpass.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Password", "Value", Nothing).ToString

    cmd.SelectRecord("SELECT [Pump],[PumpCode],[Nozzle],[Description] ,[PriceAdjustment] FROM [OP_PumpSettings]   order by inactive", "Customer", DataGridView1)
        Dim column1 As DataGridViewColumn = Me.DataGridView1.Columns(0)
        Dim column2 As DataGridViewColumn = Me.DataGridView1.Columns(1)
        Dim column3 As DataGridViewColumn = Me.DataGridView1.Columns(2)
        Dim column4 As DataGridViewColumn = Me.DataGridView1.Columns(3)

        column1.Visible = False

        column2.ReadOnly = True
        column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        column3.ReadOnly = True
        column4.Width = 100
        column4.ReadOnly = True

    End Sub

    Private Sub BTSAVE_Click(sender As Object, e As EventArgs) Handles BTSAVE.Click
        Try
            Dim count = DataGridView1.RowCount
            Dim a = 0
            Do

                Dim b1 As Double = DataGridView1.Item(0, a).Value
                Dim b2 As Double = DataGridView1.Item(2, a).Value
                Dim b3 As Double = DataGridView1.Item(4, a).Value


                cmd.Update("UPDATE [OP_PumpSettings]SET   [PriceAdjustment]='" & b3 & "'       where  [Pump]='" & b1 & "' and [Nozzle]='" & b2 & "'  ")



                a = a + 1
            Loop While (a < count)



            MessageBox.Show("PRICE HAS BEEN ADJUST")
            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)

        End Try
    End Sub
End Class
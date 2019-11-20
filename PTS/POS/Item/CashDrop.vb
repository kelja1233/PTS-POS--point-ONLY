Public Class CashDrop
    Dim cmd As New commands
    Public lastdrop = 0
    Private Sub tb1000_TextChanged(sender As Object, e As EventArgs) Handles tb1000.TextChanged
        Try
            lbt1000.Text = tb1000.Text * 1000
            LBtotal.Text = Double.Parse(lbt1000.Text) + Double.Parse(lbt500.Text) + Double.Parse(lbt200.Text) + Double.Parse(lbt100.Text) + Double.Parse(lbt50.Text) + Double.Parse(lbt20.Text) + Double.Parse(lbt10.Text) + Double.Parse(lbt5.Text) + Double.Parse(lbt1.Text) + Double.Parse(lbother.Text)
        Catch ex As Exception
            lbt1000.Text = 0
            LBtotal.Text = 0
        End Try
    End Sub

    Private Sub tb500_TextChanged(sender As Object, e As EventArgs) Handles tb500.TextChanged

        Try
            lbt500.Text = tb500.Text * 500
            LBtotal.Text = Double.Parse(lbt1000.Text) + Double.Parse(lbt500.Text) + Double.Parse(lbt200.Text) + Double.Parse(lbt100.Text) + Double.Parse(lbt50.Text) + Double.Parse(lbt20.Text) + Double.Parse(lbt10.Text) + Double.Parse(lbt5.Text) + Double.Parse(lbt1.Text) + Double.Parse(lbother.Text)
        Catch ex As Exception
            lbt500.Text = 0
            LBtotal.Text = 0
        End Try
    End Sub

    Private Sub tb200_TextChanged(sender As Object, e As EventArgs) Handles tb200.TextChanged
        Try
            lbt200.Text = tb200.Text * 200
            LBtotal.Text = Double.Parse(lbt1000.Text) + Double.Parse(lbt500.Text) + Double.Parse(lbt200.Text) + Double.Parse(lbt100.Text) + Double.Parse(lbt50.Text) + Double.Parse(lbt20.Text) + Double.Parse(lbt10.Text) + Double.Parse(lbt5.Text) + Double.Parse(lbt1.Text) + Double.Parse(lbother.Text)
        Catch ex As Exception
            lbt200.Text = 0
            LBtotal.Text = 0
        End Try
    End Sub

    Private Sub tb100_TextChanged(sender As Object, e As EventArgs) Handles tb100.TextChanged
        Try
            lbt100.Text = tb100.Text * 100
            LBtotal.Text = Double.Parse(lbt1000.Text) + Double.Parse(lbt500.Text) + Double.Parse(lbt200.Text) + Double.Parse(lbt100.Text) + Double.Parse(lbt50.Text) + Double.Parse(lbt20.Text) + Double.Parse(lbt10.Text) + Double.Parse(lbt5.Text) + Double.Parse(lbt1.Text) + Double.Parse(lbother.Text)
        Catch ex As Exception

            lbt100.Text = 0
            LBtotal.Text = 0
        End Try
    End Sub

    Private Sub tb50_TextChanged(sender As Object, e As EventArgs) Handles tb50.TextChanged
        Try
            lbt50.Text = tb50.Text * 50
            LBtotal.Text = Double.Parse(lbt1000.Text) + Double.Parse(lbt500.Text) + Double.Parse(lbt200.Text) + Double.Parse(lbt100.Text) + Double.Parse(lbt50.Text) + Double.Parse(lbt20.Text) + Double.Parse(lbt10.Text) + Double.Parse(lbt5.Text) + Double.Parse(lbt1.Text) + Double.Parse(lbother.Text)
        Catch ex As Exception
            lbt50.Text = 0
            LBtotal.Text = 0
        End Try
    End Sub

    Private Sub tb20_TextChanged(sender As Object, e As EventArgs) Handles tb20.TextChanged
        Try
            lbt20.Text = tb20.Text * 20
            LBtotal.Text = Double.Parse(lbt1000.Text) + Double.Parse(lbt500.Text) + Double.Parse(lbt200.Text) + Double.Parse(lbt100.Text) + Double.Parse(lbt50.Text) + Double.Parse(lbt20.Text) + Double.Parse(lbt10.Text) + Double.Parse(lbt5.Text) + Double.Parse(lbt1.Text) + Double.Parse(lbother.Text)
        Catch ex As Exception
            lbt20.Text = 0
            LBtotal.Text = 0
        End Try
    End Sub

    Private Sub tb10_TextChanged(sender As Object, e As EventArgs) Handles tb10.TextChanged
        Try
            lbt10.Text = tb10.Text * 10
            LBtotal.Text = Double.Parse(lbt1000.Text) + Double.Parse(lbt500.Text) + Double.Parse(lbt200.Text) + Double.Parse(lbt100.Text) + Double.Parse(lbt50.Text) + Double.Parse(lbt20.Text) + Double.Parse(lbt10.Text) + Double.Parse(lbt5.Text) + Double.Parse(lbt1.Text) + Double.Parse(lbother.Text)
        Catch ex As Exception
            lbt10.Text = 0
            LBtotal.Text = 0
        End Try
    End Sub

    Private Sub tb5_TextChanged(sender As Object, e As EventArgs) Handles tb5.TextChanged
        Try
            lbt5.Text = tb5.Text * 5
            LBtotal.Text = Double.Parse(lbt1000.Text) + Double.Parse(lbt500.Text) + Double.Parse(lbt200.Text) + Double.Parse(lbt100.Text) + Double.Parse(lbt50.Text) + Double.Parse(lbt20.Text) + Double.Parse(lbt10.Text) + Double.Parse(lbt5.Text) + Double.Parse(lbt1.Text) + Double.Parse(lbother.Text)
        Catch ex As Exception
            lbt5.Text = 0
            LBtotal.Text = 0
        End Try
    End Sub

    Private Sub tb1_TextChanged(sender As Object, e As EventArgs) Handles tb1.TextChanged
        Try
            lbt1.Text = tb1.Text * 1
            LBtotal.Text = Double.Parse(lbt1000.Text) + Double.Parse(lbt500.Text) + Double.Parse(lbt200.Text) + Double.Parse(lbt100.Text) + Double.Parse(lbt50.Text) + Double.Parse(lbt20.Text) + Double.Parse(lbt10.Text) + Double.Parse(lbt5.Text) + Double.Parse(lbt1.Text) + Double.Parse(lbother.Text)
        Catch ex As Exception
            lbt1.Text = 0
            LBtotal.Text = 0
        End Try
    End Sub

    Private Sub tbother_TextChanged(sender As Object, e As EventArgs) Handles tbother.TextChanged
        If tbother.Text.Contains(".") Then
            Dim First As Integer = tbother.Text.IndexOf("."c)
            Dim Last As Integer = tbother.Text.LastIndexOf("."c)
            If First <> Last Then
                Dim StartPos = tbother.SelectionStart - 1
                tbother.Text = tbother.Text.Remove(tbother.SelectionStart - 1, 1)
                tbother.SelectionStart = StartPos
            End If
        End If




        Try


            lbother.Text = tbother.Text
            LBtotal.Text = Double.Parse(lbt1000.Text) + Double.Parse(lbt500.Text) + Double.Parse(lbt200.Text) + Double.Parse(lbt100.Text) + Double.Parse(lbt50.Text) + Double.Parse(lbt20.Text) + Double.Parse(lbt10.Text) + Double.Parse(lbt5.Text) + Double.Parse(lbt1.Text) + Double.Parse(lbother.Text)
        Catch ex As Exception
            lbother.Text = 0
            LBtotal.Text = 0
        End Try
    End Sub
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbother.KeyPress
        If Char.IsPunctuation(e.KeyChar) And e.KeyChar.ToString <> "." Or Char.IsLetter(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Then 'Allows only numbers, "." and some keys like delete, backspace, enter, etc in Control

            e.Handled = True
        End If


    End Sub

    Private Sub DisallowPaste(sender As Object, e As KeyEventArgs) Handles tbother.KeyDown
        If e.Control AndAlso (e.KeyCode = Keys.V) Then e.SuppressKeyPress = True 'Disallows paste to TextBox. Or allowing only one decimal in textchanged event can fail.
        If (e.KeyCode = Keys.Space) Then e.SuppressKeyPress = True 'Disallows paste to TextBox. Or allowing only one decimal in textchanged event can fail.


    End Sub
    Private Sub CashDrop_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    SQLConnect.txtserver.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_server", "Value", Nothing).ToString
    SQLConnect.txtdb.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_database", "Value", Nothing).ToString
    SQLConnect.txtuser.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_user", "Value", Nothing).ToString
    SQLConnect.txtpass.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Password", "Value", Nothing).ToString





  End Sub

    Private Sub btsave_Click(sender As Object, e As EventArgs) Handles btsave.Click
       

        Dim storeid = cmd.getSpecificRecord("Select [StoreID] FROM [Configuration]")

        cmd.AddRecord("INSERT INTO DropPayout ( [StoreID] ,[Type] ,[BatchNumber]  ,[CashierID] ,[Amount] ,[Comment])values('" & storeid & "','0','" & lbbatch.Text & "','" & lbcash.Text & "','" & LBtotal.Text & "','" & txtcomment.Text & "')")
        Dim maxid = cmd.getSpecificRecord("SELECT  0+COALESCE(Max(ID),0)  FROM DropPayout  ")


        cmd.AddRecord("INSERT INTO DropPayoutEntry ( [DropPayoutID],[pesoOther],[peso1],[peso5],[peso10],[peso20],[peso50],[peso100],[peso200],[peso500],[peso1000])values('" & maxid & "','" & lbother.Text & "','" & lbt1.Text & "','" & lbt5.Text & "','" & lbt10.Text & "','" & lbt20.Text & "','" & lbt50.Text & "','" & lbt100.Text & "','" & lbt200.Text & "','" & lbt500.Text & "','" & lbt1000.Text & "')")



        MessageBox.Show("Added Successfully!")
        cr()
        frmDropPayout.Close()
        frmDropPayout.Show()
        frmDropPayout.yes.PerformClick()
        Me.Close()
    End Sub
    Public Sub cr()

        Dim batch = lbbatch.Text
        Dim PO = cmd.getSpecificRecord("SELECT  0+COALESCE(SUM(TenderEntry.TenderAmount),0) FROM  TenderEntry INNER JOIN [Transaction] ON TenderEntry.TransactionNumber = [Transaction].TransactionNumber AND TenderEntry.BatchNumber = [Transaction].BatchNumber AND TenderEntry.StoreID = [Transaction].StoreID WHERE ([Transaction].BatchNumber = '" & batch & "')  AND (TenderEntry.TenderID =2)")
        Dim Cash = cmd.getSpecificRecord("SELECT  0+COALESCE(SUM(TenderEntry.TenderAmount),0) FROM  TenderEntry INNER JOIN [Transaction] ON TenderEntry.TransactionNumber = [Transaction].TransactionNumber AND TenderEntry.BatchNumber = [Transaction].BatchNumber AND TenderEntry.StoreID = [Transaction].StoreID WHERE ([Transaction].BatchNumber = '" & batch & "')  AND (TenderEntry.TenderID =1)")
        Dim discount = cmd.getSpecificRecord("SELECT  0+COALESCE(SUM([Transaction].Discount),0) FROM  TenderEntry INNER JOIN [Transaction] ON TenderEntry.TransactionNumber = [Transaction].TransactionNumber AND TenderEntry.BatchNumber = [Transaction].BatchNumber AND TenderEntry.StoreID = [Transaction].StoreID WHERE ([Transaction].BatchNumber = '" & batch & "') ")
        ' Dim  = cmd.getSpecificRecord("SELECT    [Total] FROM   [Transaction] where [BatchNumber]='" & batch & "' ")
        Dim CashDrop = cmd.getSpecificRecord("SELECT  0+COALESCE(Sum([Amount]),0)  FROM [DropPayout] where BatchNumber='" & batch & "'   and type=0 ")
        Dim Payout = cmd.getSpecificRecord("SELECT  0+COALESCE(Sum([Amount]),0)  FROM [DropPayout] where BatchNumber='" & batch & "' and type=1 ")
       Dim Total = cmd.getSpecificRecord("SELECT  0+COALESCE(SUM(TenderEntry.TenderAmount),0) FROM  TenderEntry INNER JOIN [Transaction] ON TenderEntry.TransactionNumber = [Transaction].TransactionNumber AND TenderEntry.BatchNumber = [Transaction].BatchNumber AND TenderEntry.StoreID = [Transaction].StoreID WHERE ([Transaction].BatchNumber = '" & batch & "')  ")


        Dim tax = cmd.getSpecificRecord("SELECT  0+COALESCE(SUM([Transaction].SalesTax),0) FROM  TenderEntry INNER JOIN [Transaction] ON TenderEntry.TransactionNumber = [Transaction].TransactionNumber AND TenderEntry.BatchNumber = [Transaction].BatchNumber AND TenderEntry.StoreID = [Transaction].StoreID WHERE ([Transaction].BatchNumber = '" & batch & "')  AND (TenderEntry.TenderID =1)")




        cmd.Update("UPDATE [CashierReport] SET [Discount]='" & discount & "' where [BatchNumber]='" & batch & "'")
        cmd.Update("UPDATE [CashierReport] SET [Total]='" & Total & "' where [BatchNumber]='" & batch & "'")
        cmd.Update("UPDATE [CashierReport] SET [PO]='" & PO & "' where [BatchNumber]='" & batch & "' ")
        cmd.Update("UPDATE [CashierReport] SET [Sales]='" & Cash & "' where [BatchNumber]='" & batch & "'")
        cmd.Update("UPDATE [CashierReport] SET [Payout]='" & Payout & "' where [BatchNumber]='" & batch & "'")
        cmd.Update("UPDATE [CashierReport] SET [CashDrop]='" & CashDrop & "' where [BatchNumber]='" & batch & "'")


        cmd.Update("UPDATE [Batch] SET [Dropped]='" & CashDrop & "' where [BatchNumber]='" & batch & "'")
        cmd.Update("UPDATE [Batch] SET [PaidOut]='" & Payout & "' where [BatchNumber]='" & batch & "'")
        cmd.Update("UPDATE [Batch] SET [Discount]='" & discount & "' where [BatchNumber]='" & batch & "'")
        'cmd.Update("UPDATE [Batch] SET [Total]='" & Total & "' where [BatchNumber]='" & batch & "'")
        cmd.Update("UPDATE [Batch] SET [PaidOnAccount]='" & PO & "' where [BatchNumber]='" & batch & "' ")
        cmd.Update("UPDATE [Batch] SET [Sales]='" & Cash & "' where [BatchNumber]='" & batch & "'")
        cmd.Update("UPDATE [Batch] SET [TAX]='" & tax & "' where [BatchNumber]='" & batch & "'")


    cmd.Update($"execute ABCD_XZ {batch}")



  End Sub

    Private Sub lbbatch_Click(sender As Object, e As EventArgs) Handles lbbatch.Click

    End Sub
End Class
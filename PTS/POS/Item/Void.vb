Public Class Void
    Dim cmd As New commands
    Private Sub Void_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    SQLConnect.txtserver.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_server", "Value", Nothing).ToString
    SQLConnect.txtdb.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_database", "Value", Nothing).ToString
    SQLConnect.txtuser.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_user", "Value", Nothing).ToString
    SQLConnect.txtpass.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Password", "Value", Nothing).ToString





  End Sub
    Public Sub rec()

        Dim batch As Double = cmd.getSpecificRecord("SELECT  0+COALESCE(Max([BatchNumber]),0)  FROM [Batch]  ")
    Try
      cmd.SelectRecord("SELECT  [TransactionNumber],[Time],[CustomerID],[CashierID],[Total],[SalesTax],[Comment],[ReferenceNumber],[Note],[PlateNumber],[OtherTransactionNumber],[Void],[Vatable],[NonVat],[TaxExempt],[Discount]  FROM [Transaction] where void=0   and [BatchNumber] = '" & batch & "'   order by TransactionNumber desc", "Transaction", Me.DataGridView1)
      Dim a = DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value
      cmd.SelectRecord("SELECT [ItemID]      ,[Quantity]  FROM [TransactionEntry]  where [TransactionNumber]='" & a & "'", "TransactionEntry", Me.DataGridView2)


    Catch ex As Exception

    End Try


  End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        rec()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick


        voids()
    End Sub
    Public Sub voids()
        If MessageBox.Show("Do you want to Void?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

            Dim a = DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value
            Dim a1 = DataGridView1.Item(2, DataGridView1.CurrentRow.Index).Value

            Dim tranNo = a


            Dim tender = cmd.getSpecificRecord("SELECT [TenderID]  FROM [TenderEntry] where TransactionNumber='" & a & "' ")

            If tender = 2 Then


                cmd.AddRecord("INSERT INTO DeleteTransaction ([StoreID],[BatchNumber],[TransactionNumber],[Time],[CustomerID],[CashierID],[Total],[SalesTax],[Comment],[ReferenceNumber],[Note],[PlateNumber],[Points],[OtherTransactionNumber],[Void],[CustomText1],[CustomText2],[CustomNumber1],[CustomNumber2],[CustomDate1],[Customdate2],[CPoints],[Status],[Vatable],[NonVat],[TaxExempt],[Discount])  (SELECT  [StoreID],[BatchNumber],[TransactionNumber],[Time],[CustomerID],[CashierID],[Total],[SalesTax],[Comment],[ReferenceNumber],[Note],[PlateNumber],[Points],[OtherTransactionNumber],[Void],[CustomText1],[CustomText2],[CustomNumber1],[CustomNumber2],[CustomDate1],[Customdate2],[CPoints],[Status],[Vatable],[NonVat],[TaxExempt],[Discount]  FROM [Transaction]    WHERE TransactionNumber='" & tranNo & "')")
                cmd.AddRecord("INSERT INTO DeleteTenderEntry ([StoreID],[BatchNumber],[TransactionNumber],[TenderID],[TenderAmount],[TenderChange],[LastUpdated],[Status])  (SELECT  [StoreID],[BatchNumber],[TransactionNumber],[TenderID],[TenderAmount],[TenderChange],[LastUpdated],[Status] fROM [TenderEntry]   WHERE TransactionNumber='" & tranNo & "')")
                cmd.AddRecord("INSERT INTO DeleteTransactionEntry ([StoreID],[ItemID],[TransactionNumber],[Cost],[FullPrice],[Price],[SalesTax],[Quantity],[Taxable],[POSTECPrice],[POSTECID],[EntryType],[Discount]  )  (SELECT  [StoreID],[ItemID],[TransactionNumber],[Cost],[FullPrice],[Price],[SalesTax],[Quantity],[Taxable],[POSTECPrice],[POSTECID],[EntryType],[Discount] FROM [TransactionEntry]   WHERE TransactionNumber='" & tranNo & "')")
                cmd.AddRecord("INSERT INTO DeleteAccountReceivable ([StoreID],[OriginID],[CustomerID],[Date],[OriginalAmount],[TransactionNumber],[Balance],[CurrentAccountBalance],[Status],[OriginalID])  (SELECT  [StoreID],[OriginID],[CustomerID],[Date],[OriginalAmount],[TransactionNumber],[Balance],[CurrentAccountBalance],[Status],[OriginalID]  FROM [AccountReceivable]    WHERE TransactionNumber='" & tranNo & "')")

                Dim total = cmd.getSpecificRecord("SELECT  0+COALESCE(Sum([Total]),0)  FROM [Transaction]  WHERE TransactionNumber='" & tranNo & "'")
                Dim CustomerID = cmd.getSpecificRecord("SELECT  0+COALESCE(max([CashierID]),0)  FROM [Transaction]  WHERE TransactionNumber='" & tranNo & "' ")



                cmd.Update("UPDATE [Customer] SET [AccountBalance]=[AccountBalance]-'" & total & "' where ID='" & CustomerID & "'")

                cmd.Update("UPDATE PumpTransactions SET      Status = '0',TransNum='" & 0 & "'  WHERE    TransNum='" & tranNo & "'")

                cmd.delete("DELETE FROM  [TenderEntry] WHERE TransactionNumber='" & tranNo & "'")
                cmd.delete("DELETE FROM  [Transaction] WHERE TransactionNumber='" & tranNo & "'")
                cmd.delete("DELETE FROM  [TransactionEntry] WHERE TransactionNumber='" & tranNo & "'")
                cmd.delete("DELETE FROM  [AccountReceivable] WHERE TransactionNumber='" & tranNo & "'")
                cmd.delete("DELETE FROM  [TransacationTender] WHERE Transaction_number='" & tranNo & "'")


                itemup()
                rec()


        MessageBox.Show("Transaction has been void")
        Dim cmdShowPT As New CmdShowPumpTransaction
        cmdShowPT.ShowPT()
      Else



                cmd.AddRecord("INSERT INTO DeleteTransaction ([StoreID],[BatchNumber],[TransactionNumber],[Time],[CustomerID],[CashierID],[Total],[SalesTax],[Comment],[ReferenceNumber],[Note],[PlateNumber],[Points],[OtherTransactionNumber],[Void],[CustomText1],[CustomText2],[CustomNumber1],[CustomNumber2],[CustomDate1],[Customdate2],[CPoints],[Status],[Vatable],[NonVat],[TaxExempt],[Discount])  (SELECT  [StoreID],[BatchNumber],[TransactionNumber],[Time],[CustomerID],[CashierID],[Total],[SalesTax],[Comment],[ReferenceNumber],[Note],[PlateNumber],[Points],[OtherTransactionNumber],[Void],[CustomText1],[CustomText2],[CustomNumber1],[CustomNumber2],[CustomDate1],[Customdate2],[CPoints],[Status],[Vatable],[NonVat],[TaxExempt],[Discount]  FROM [Transaction]    WHERE TransactionNumber='" & tranNo & "')")
                cmd.AddRecord("INSERT INTO DeleteTenderEntry ([StoreID],[BatchNumber],[TransactionNumber],[TenderID],[TenderAmount],[TenderChange],[LastUpdated],[Status])  (SELECT  [StoreID],[BatchNumber],[TransactionNumber],[TenderID],[TenderAmount],[TenderChange],[LastUpdated],[Status] FROM [TenderEntry]   WHERE TransactionNumber='" & tranNo & "')")
                cmd.AddRecord("INSERT INTO DeleteTransactionEntry ([StoreID],[ItemID],[TransactionNumber],[Cost],[FullPrice],[Price],[SalesTax],[Quantity],[Taxable],[POSTECPrice],[POSTECID],[EntryType],[Discount]  )  (SELECT  [StoreID],[ItemID],[TransactionNumber],[Cost],[FullPrice],[Price],[SalesTax],[Quantity],[Taxable],[POSTECPrice],[POSTECID],[EntryType],[Discount] FROM [TransactionEntry]   WHERE TransactionNumber='" & tranNo & "')")
                cmd.Update("UPDATE PumpTransactions SET      Status = '0',TransNum='" & 0 & "'  WHERE    TransNum='" & tranNo & "'")

                cmd.delete("DELETE FROM  [TenderEntry] WHERE TransactionNumber='" & tranNo & "'")
                cmd.delete("DELETE FROM  [Transaction] WHERE TransactionNumber='" & tranNo & "'")
                cmd.delete("DELETE FROM  [TransactionEntry] WHERE TransactionNumber='" & tranNo & "'")
                cmd.delete("DELETE FROM  [TransacationTender] WHERE Transaction_number='" & tranNo & "'")

                itemup()
                rec()

                MessageBox.Show("Transaction has been void")

        Dim cmdShowPT As New CmdShowPumpTransaction
        cmdShowPT.ShowPT()


      End If




        End If


        cr()


    End Sub
    Public Sub itemup()


        Dim count = DataGridView2.RowCount
        Dim a = 0


        'do loop execution 


        Do

            Dim a1 = DataGridView2.Item(0, a).Value
            Dim a2 As Double = DataGridView2.Item(1, a).Value



            cmd.Update("UPDATE Item SET [Quantity]=[Quantity]+'" & a2 & "' where [ID]='" & a1 & "'")



            a = a + 1


        Loop While (a < count)







    End Sub
    Public Sub cr()

        Dim tran = cmd.getSpecificRecord("SELECT [BatchNumber]  FROM [Transaction] where TransactionNumber='" & DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value & "' ")



        Dim batch = tran



        Dim optime As DateTime = cmd.getSpecificRecord("SELECT OpeningTime  FROM [Batch]  where BatchNumber='" & batch & "' ")
        Dim PO = cmd.getSpecificRecord("SELECT  0+COALESCE(SUM(TenderEntry.TenderAmount),0) FROM  TenderEntry INNER JOIN [Transaction] ON TenderEntry.TransactionNumber = [Transaction].TransactionNumber AND TenderEntry.BatchNumber = [Transaction].BatchNumber AND TenderEntry.StoreID = [Transaction].StoreID WHERE ([Transaction].BatchNumber = '" & batch & "')  AND (TenderEntry.TenderID =2)")
        Dim Cash = cmd.getSpecificRecord("SELECT  0+COALESCE(SUM(TenderEntry.TenderAmount),0) FROM  TenderEntry INNER JOIN [Transaction] ON TenderEntry.TransactionNumber = [Transaction].TransactionNumber AND TenderEntry.BatchNumber = [Transaction].BatchNumber AND TenderEntry.StoreID = [Transaction].StoreID WHERE ([Transaction].BatchNumber = '" & batch & "')  AND (TenderEntry.TenderID =1)")
        Dim discount = cmd.getSpecificRecord("SELECT  0+COALESCE(SUM([Transaction].Discount),0) FROM  TenderEntry INNER JOIN [Transaction] ON TenderEntry.TransactionNumber = [Transaction].TransactionNumber AND TenderEntry.BatchNumber = [Transaction].BatchNumber AND TenderEntry.StoreID = [Transaction].StoreID WHERE ([Transaction].BatchNumber = '" & batch & "') ")
        ' Dim  = cmd.getSpecificRecord("SELECT    [Total] FROM   [Transaction] where [BatchNumber]='" & batch & "' ")
        Dim CashDrop = cmd.getSpecificRecord("SELECT  0+COALESCE(Sum([Amount]),0)  FROM [DropPayout] where BatchNumber='" & batch & "'   and type=0 ")
        Dim Payout = cmd.getSpecificRecord("SELECT  0+COALESCE(Sum([Amount]),0)  FROM [DropPayout] where BatchNumber='" & batch & "' and type=1 ")
        Dim colect = cmd.getSpecificRecord("SELECT  0+COALESCE(Sum([Amount]),0)  FROM [DropPayout] where BatchNumber='" & batch & "'   and type=3 ")
        Dim Total = cmd.getSpecificRecord("SELECT  0+COALESCE(SUM(TenderEntry.TenderAmount),0) FROM  TenderEntry INNER JOIN [Transaction] ON TenderEntry.TransactionNumber = [Transaction].TransactionNumber AND TenderEntry.BatchNumber = [Transaction].BatchNumber AND TenderEntry.StoreID = [Transaction].StoreID WHERE ([Transaction].BatchNumber = '" & batch & "')  ")


        Dim tax = cmd.getSpecificRecord("SELECT  0+COALESCE(SUM([Transaction].SalesTax),0) FROM  TenderEntry INNER JOIN [Transaction] ON TenderEntry.TransactionNumber = [Transaction].TransactionNumber AND TenderEntry.BatchNumber = [Transaction].BatchNumber AND TenderEntry.StoreID = [Transaction].StoreID WHERE ([Transaction].BatchNumber = '" & batch & "')  AND (TenderEntry.TenderID =1)")



        cmd.Update("UPDATE [CashierReport] SET [Collection]='" & colect & "' where [BatchNumber]='" & batch & "'")
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



End Class
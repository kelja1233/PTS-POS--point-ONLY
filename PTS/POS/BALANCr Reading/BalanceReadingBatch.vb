Public Class BalanceReadingBatch
    Dim cmd As New commands

    Private Sub BalanceReadingBatchLoad(sender As Object, e As EventArgs) Handles MyBase.Load
    SQLConnect.txtserver.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_server", "Value", Nothing).ToString
    SQLConnect.txtdb.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_database", "Value", Nothing).ToString
    SQLConnect.txtuser.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_user", "Value", Nothing).ToString
    SQLConnect.txtpass.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Password", "Value", Nothing).ToString


  End Sub

    Public Sub rec()
        On Error Resume Next


        cmd.SelectRecord("SELECT        OP_PumpSettings.Description, OP_ShiftReading.Pump, OP_ShiftReading.Nozzle, OP_ShiftReading.EndReading, OP_PumpSettings.ItemLookupCode,OP_ShiftReading.EndAReading FROM OP_ShiftReading INNER JOIN OP_PumpSettings ON OP_ShiftReading.Pump = OP_PumpSettings.Pump AND OP_ShiftReading.Nozzle = OP_PumpSettings.Nozzle WHERE   (OP_ShiftReading.batch = '" & txtbatch.Text & "')", "OP_PumpSettings", Me.DataGridView2)
        Dim count = DataGridView2.RowCount
        Dim a = 0


        'do loop execution 


        Do


            Dim batch1 = txtbatch.Text
            Dim batch As DateTime = cmd.getSpecificRecord("SELECT  OpeningTime  FROM Batch where BatchNumber='" & batch1 & "'  ")
            Dim itemlookupcode = DataGridView2.Item(4, a).Value
            Dim a1 = DataGridView2.Item(0, a).Value
            Dim a2 = DataGridView2.Item(1, a).Value
            Dim a3 As Double = DataGridView2.Item(2, a).Value
            Dim id As Double = cmd.getSpecificRecord("SELECT      0+COALESCE(max ([id]),0)  FROM [OP_ShiftReading] where [Pump]='" & a2 & "' and [Nozzle]='" & a3 & "' and batch = '" & txtbatch.Text & "'")
            Dim shiftReading As Double = cmd.getSpecificRecord("SELECT      0+COALESCE(sum ([StartReading]),0)  FROM [OP_ShiftReading] where id ='" & id & "' ")
            Dim shiftAReading As Double = cmd.getSpecificRecord("SELECT      0+COALESCE(sum ([StartAReading]),0)  FROM [OP_ShiftReading] where id ='" & id & "' ")
         
            Dim a4 As Double = DataGridView2.Item(3, a).Value - shiftReading
            Dim a44 As Double = DataGridView2.Item(5, a).Value - shiftAReading

      a4 = Math.Round(a4, 3)

      a44 = Math.Round(a44, 3)
      Dim counter As Double = cmd.getSpecificRecord("SELECT  0+COALESCE(Max(PriceAdjustment),0)  FROM OP_PumpSettings where [Pump]='" & a2 & "' and [Nozzle]='" & a3 & "'  ")

            Dim price As Double = cmd.getSpecificRecord("SELECT  0+COALESCE(Max(Price),0)  FROM Item   where  [ItemLookupCode]='" & itemlookupcode & "'") + counter

            Dim a5 As Double = cmd.getSpecificRecord("SELECT      0+COALESCE(sum ([Volume]),0)  FROM [PumpTransactions] where Batch ='" & batch1 & "' and [Dispenser]='" & a2 & "' and [Grade]='" & itemlookupcode & "' ")
      Dim a55 As Double = cmd.getSpecificRecord("SELECT      0+COALESCE(sum ([Amount]),0)  FROM [PumpTransactions] where Batch ='" & batch1 & "' and [Dispenser]='" & a2 & "' and [Grade]='" & itemlookupcode & "' ")


      a55 = Math.Round(a55, 3)



      a5 = Math.Round(a5, 3)


      Dim a6 As Double = a4 - a5


            Dim a7 As Double = a44 - a55

      a6 = Math.Round(a6, 3)
      a7 = Math.Round(a7, 3)

      Dim itemID = cmd.getSpecificRecord("SELECT     [ItemID]  FROM [OP_PumpSettings] where [Pump]='" & a2 & "' and [Nozzle]='" & a3 & "' ")


            Dim inventory As Double = cmd.getSpecificRecord("SELECT      0+COALESCE(sum ([DipStickHeight]),0)  FROM [ShiftEndingInventory] where ItemID='" & itemID & "' and   [BatchNumber]='" & txtbatch.Text - 1 & "'")
            Dim amounss As Double = cmd.getSpecificRecord("SELECT 0+COALESCE(sum( TransactionEntry.Quantity),0) FROM TenderEntry INNER JOIN TransactionEntry ON TenderEntry.TransactionNumber = TransactionEntry.TransactionNumber where  TenderEntry.BatchNumber = '" & txtbatch.Text & "'  and TransactionEntry.ItemID='" & itemID & "' and TenderEntry.TenderID between 1 and 2")

            Dim DipStickVolume As Double = cmd.getSpecificRecord("SELECT      0+COALESCE(sum ([DipStickVolume]),0)  FROM [ShiftEndingInventory] where ItemID='" & itemID & "' and   [BatchNumber]='" & txtbatch.Text & "'")


            cmd.Update("UPDATE [ShiftEndingInventory] SET [Quantity]='" & inventory & "' ,[DipStickHeight]='" & DipStickVolume + inventory - amounss & "'   where ItemID='" & itemID & "' and   [BatchNumber]='" & txtbatch.Text & "'")




            'cmd.Update("UPDATE [ShiftEndingInventory] SET [Quantity]='" & inventory & "' ,[DipStickHeight]='" & inventory + DipStickVolume - amounss & "'   where ItemID='" & itemID & "' and   [BatchNumber]='" & batch1 & "'")
            'cmd.Update("UPDATE [ShiftEndingInventory] SET [Quantity]='" & inventory + DipStickVolume - amounss & "' where ItemID='" & itemID & "' and [BatchNumber]='" & batch1 + 1 & "'")



            If a7 <= -1 Then
                Me.DataGridView1.Rows.Add(a1, a2, a3, a4, a5, a6, a7)
            ElseIf a7 >= 1 Then
                Me.DataGridView1.Rows.Add(a1, a2, a3, a4, a5, a6, a7)

            End If






            a = a + 1


        Loop While (a < count)


    End Sub



    Private Sub btbalance_Click(sender As Object, e As EventArgs) Handles btbalance.Click
        Try

            cr()







            Dim count = DataGridView1.RowCount
            Dim a = 0


            'do loop execution 


            Do


                Dim a1 = DataGridView1.Item(0, a).Value
                Dim a2 As Double = DataGridView1.Item(1, a).Value
                Dim a3 As Double = DataGridView1.Item(2, a).Value
                Dim a4 As Double = DataGridView1.Item(3, a).Value
                Dim a5 As Double = DataGridView1.Item(4, a).Value
                Dim a6 As Double = DataGridView1.Item(5, a).Value
                Dim a7 As Double = DataGridView1.Item(6, a).Value


                Dim itemlookupcode = cmd.getSpecificRecord("SELECT     [ItemLookupCode]  FROM [OP_PumpSettings] where [Pump]='" & a2 & "' and [Nozzle]='" & a3 & "' ")
                Dim itemID = cmd.getSpecificRecord("SELECT     [ItemID]  FROM [OP_PumpSettings] where [Pump]='" & a2 & "' and [Nozzle]='" & a3 & "' ")
                Dim OpeningTime As DateTime = cmd.getSpecificRecord("SELECT max([OpeningTime]) from  [Batch] where [BatchNumber]='" & txtbatch.Text & "'  ")

                '  Dim price As Double = cmd.getSpecificRecord("SELECT  0+COALESCE(Max(Price),0)  FROM Item   where  [ItemLookupCode]='" & itemlookupcode & "'")
                Dim counter As Double = cmd.getSpecificRecord("SELECT  0+COALESCE(Max(PriceAdjustment),0)  FROM OP_PumpSettings where [Pump]='" & a2 & "' and [Nozzle]='" & a3 & "'  ")


                Dim price As Double = cmd.getSpecificRecord("SELECT        AVG(TransactionEntry.FullPrice) AS Average FROM [Transaction] INNER JOIN TransactionEntry ON [Transaction].TransactionNumber = TransactionEntry.TransactionNumber WHERE        ([Transaction].BatchNumber = '" & txtbatch.Text & "') AND (TransactionEntry.ItemID = '" & itemID & "')  ") + counter

                If a7 <= -1 Then
                    Dim tranNo1 = cmd.getSpecificRecord("SELECT        0 + COALESCE (MAX([Transaction].TranNo), 0)+1 FROM            [Transaction] INNER JOIN TenderEntry ON [Transaction].TransactionNumber = TenderEntry.TransactionNumber WHERE        (TenderEntry.TenderID = 1)")

                    Dim tranNo = cmd.getSpecificRecord("SELECT  0+COALESCE(Max([TransactionNumber]),0)+1  FROM [Transaction]  ")
                    cmd.AddRecord("INSERT INTO [PumpTransactions]([Grade],[Dispenser],[UnitPrice],[Amount],[Volume],ConsoleTime,TenderTime,TransNum,Status,batch)values( '" & itemlookupcode & "','" & a2 & "','" & price & "','" & a7 & "','" & a6 & "','" & OpeningTime.AddMinutes(15) & "','" & OpeningTime.AddMinutes(15) & "','" & tranNo & "',2,'" & txtbatch.Text & "')")
                    Dim storeid = cmd.getSpecificRecord("Select [StoreID] FROM [Configuration]")

                    Dim id = 1

                    Dim tax As Double = a7 - (a7 / 1.12)
                    Dim vat As Double = a7 / 1.12



                    cmd.AddRecord("INSERT INTO [Transaction]([StoreID] ,[BatchNumber]  ,[CustomerID] ,[CashierID] ,[Total] ,[SalesTax] ,[ReferenceNumber] ,[Note] ,[PlateNumber] ,[Vatable],[Discount],TranNo)values( '" & storeid & "','" & txtbatch.Text & "','0','" & id & "','" & a7 & "','" & tax & "','','','','" & vat & "','0', '" & tranNo1 & "')")



                    cmd.AddRecord("INSERT INTO [TenderEntry]([StoreID],[BatchNumber],[TransactionNumber],[TenderID],[TenderAmount],[TenderChange])values( '" & storeid & "', '" & txtbatch.Text & "', '" & tranNo & "', '1','" & a7 & "','0')")



                    cmd.AddRecord("INSERT INTO [TransactionEntry] ([StoreID],[ItemID],[TransactionNumber],[FullPrice],[Price],[SalesTax],[Quantity],[Taxable],[POSTECPrice],[Discount])values('" & storeid & "','" & itemID & "','" & tranNo & "','" & price & "','" & price & "','" & tax & "','" & a6 & "',1,'" & a7 & "','0')     ")
                    cmd.AddRecord("INSERT INTO [TransacationTender] ([Transaction_number],[Store_id],[Batch],[Cashier_id],[Customer_id],[Item_id],[Item_lookupcode],[Category_id],[Quantity],[Price],[Amount],[Total_amount],[Amount_paid],Discount,Total_Discount,[Change],[Tender_id],[TotalPoint],[TotalRebate],[EarnPoint],[EarnRebate],Transno )values( '" & tranNo & "','" & storeid & "','" & txtbatch.Text & "','" & id & "','0','" & itemID & "','" & itemlookupcode & "','1','" & a6 & "','" & price & "','" & a7 & "','" & a7 & "','" & a7 & "','" & a6 & "','" & 0 & "','0',1,0,0,0,0,'" & tranNo1 & "')")
                    Dim inventory As Double = cmd.getSpecificRecord("SELECT      0+COALESCE(sum ([DipStickHeight]),0)  FROM [ShiftEndingInventory] where ItemID='" & itemID & "' and   [BatchNumber]='" & txtbatch.Text - 1 & "'")
                    Dim amounss As Double = cmd.getSpecificRecord("SELECT 0+COALESCE(sum( TransactionEntry.Quantity),0) FROM TenderEntry INNER JOIN TransactionEntry ON TenderEntry.TransactionNumber = TransactionEntry.TransactionNumber where  TenderEntry.BatchNumber = '" & txtbatch.Text & "'  and TransactionEntry.ItemID='" & itemID & "' and TenderEntry.TenderID between 1 and 2")

                    Dim DipStickVolume As Double = cmd.getSpecificRecord("SELECT      0+COALESCE(sum ([DipStickVolume]),0)  FROM [ShiftEndingInventory] where ItemID='" & itemID & "' and   [BatchNumber]='" & txtbatch.Text & "'")


                    cmd.Update("UPDATE [ShiftEndingInventory] SET [Quantity]='" & inventory & "' ,[DipStickHeight]='" & DipStickVolume + inventory - amounss & "'   where ItemID='" & itemID & "' and   [BatchNumber]='" & txtbatch.Text & "'")

                    cr()

                ElseIf a7 >= 1 Then
                    Dim tranNo1 = cmd.getSpecificRecord("SELECT        0 + COALESCE (MAX([Transaction].TranNo), 0)+1 FROM            [Transaction] INNER JOIN TenderEntry ON [Transaction].TransactionNumber = TenderEntry.TransactionNumber WHERE        (TenderEntry.TenderID = 1)")

                    Dim tranNo = cmd.getSpecificRecord("SELECT  0+COALESCE(Max([TransactionNumber]),0)+1  FROM [Transaction]  ")
                    cmd.AddRecord("INSERT INTO [PumpTransactions]([Grade],[Dispenser],[UnitPrice],[Amount],[Volume],ConsoleTime,TenderTime,TransNum,Status,batch)values( '" & itemlookupcode & "','" & a2 & "','" & price & "','" & a7 & "','" & a6 & "','" & OpeningTime.AddMinutes(15) & "','" & OpeningTime.AddMinutes(15) & "','" & tranNo & "',2,'" & txtbatch.Text & "')")
                    Dim storeid = cmd.getSpecificRecord("Select [StoreID] FROM [Configuration]")

                    Dim id = 1

                    Dim tax As Double = a7 - (a7 / 1.12)
                    Dim vat As Double = a7 / 1.12



                    cmd.AddRecord("INSERT INTO [Transaction]([StoreID] ,[BatchNumber]  ,[CustomerID] ,[CashierID] ,[Total] ,[SalesTax] ,[ReferenceNumber] ,[Note] ,[PlateNumber] ,[Vatable],[Discount],TranNo)values( '" & storeid & "','" & txtbatch.Text & "','0','" & id & "','" & a7 & "','" & tax & "','','','','" & vat & "','0', '" & tranNo1 & "')")



                    cmd.AddRecord("INSERT INTO [TenderEntry]([StoreID],[BatchNumber],[TransactionNumber],[TenderID],[TenderAmount],[TenderChange])values( '" & storeid & "', '" & txtbatch.Text & "', '" & tranNo & "', '1','" & a7 & "','0')")



                    cmd.AddRecord("INSERT INTO [TransactionEntry] ([StoreID],[ItemID],[TransactionNumber],[FullPrice],[Price],[SalesTax],[Quantity],[Taxable],[POSTECPrice],[Discount])values('" & storeid & "','" & itemID & "','" & tranNo & "','" & price & "','" & price & "','" & tax & "','" & a6 & "',1,'" & a7 & "','0')     ")
                    cmd.AddRecord("INSERT INTO [TransacationTender] ([Transaction_number],[Store_id],[Batch],[Cashier_id],[Customer_id],[Item_id],[Item_lookupcode],[Category_id],[Quantity],[Price],[Amount],[Total_amount],[Amount_paid],Discount,Total_Discount,[Change],[Tender_id],[TotalPoint],[TotalRebate],[EarnPoint],[EarnRebate],Transno )values( '" & tranNo & "','" & storeid & "','" & txtbatch.Text & "','" & id & "','0','" & itemID & "','" & itemlookupcode & "','1','" & a6 & "','" & price & "','" & a7 & "','" & a7 & "','" & a7 & "','" & a6 & "','" & 0 & "','0',1,0,0,0,0,'" & tranNo1 & "')")
                    Dim inventory As Double = cmd.getSpecificRecord("SELECT      0+COALESCE(sum ([DipStickHeight]),0)  FROM [ShiftEndingInventory] where ItemID='" & itemID & "' and   [BatchNumber]='" & txtbatch.Text - 1 & "'")
                    Dim amounss As Double = cmd.getSpecificRecord("SELECT 0+COALESCE(sum( TransactionEntry.Quantity),0) FROM TenderEntry INNER JOIN TransactionEntry ON TenderEntry.TransactionNumber = TransactionEntry.TransactionNumber where  TenderEntry.BatchNumber = '" & txtbatch.Text & "'  and TransactionEntry.ItemID='" & itemID & "' and TenderEntry.TenderID between 1 and 2")

                    Dim DipStickVolume As Double = cmd.getSpecificRecord("SELECT      0+COALESCE(sum ([DipStickVolume]),0)  FROM [ShiftEndingInventory] where ItemID='" & itemID & "' and   [BatchNumber]='" & txtbatch.Text & "'")


                    cmd.Update("UPDATE [ShiftEndingInventory] SET [Quantity]='" & inventory & "' ,[DipStickHeight]='" & DipStickVolume + inventory - amounss & "'   where ItemID='" & itemID & "' and   [BatchNumber]='" & txtbatch.Text & "'")

                    cr()
                End If

                '      



                a = a + 1


            Loop While (a < count)



            DataGridView1.Rows.Clear()

            rec()




        Catch ex As Exception




        End Try

        cr()
    End Sub

    Private Sub btshow_Click(sender As Object, e As EventArgs) Handles btshow.Click
        DataGridView1.Rows.Clear()

        rec()

    End Sub
    Public Sub cr()



        Dim batch = txtbatch.Text


       Dim PO = cmd.getSpecificRecord("SELECT  0+COALESCE(SUM(TenderEntry.TenderAmount),0) FROM  TenderEntry INNER JOIN [Transaction] ON TenderEntry.TransactionNumber = [Transaction].TransactionNumber AND TenderEntry.BatchNumber = [Transaction].BatchNumber AND TenderEntry.StoreID = [Transaction].StoreID WHERE ([Transaction].BatchNumber = '" & batch & "')  AND (TenderEntry.TenderID =2)")
        Dim Cash = cmd.getSpecificRecord("SELECT  0+COALESCE(SUM(TenderEntry.TenderAmount),0) FROM  TenderEntry INNER JOIN [Transaction] ON TenderEntry.TransactionNumber = [Transaction].TransactionNumber AND TenderEntry.BatchNumber = [Transaction].BatchNumber AND TenderEntry.StoreID = [Transaction].StoreID WHERE ([Transaction].BatchNumber = '" & batch & "')  AND (TenderEntry.TenderID =1)")
        Dim discount = cmd.getSpecificRecord("SELECT  0+COALESCE(SUM([Transaction].Discount),0) FROM  TenderEntry INNER JOIN [Transaction] ON TenderEntry.TransactionNumber = [Transaction].TransactionNumber AND TenderEntry.BatchNumber = [Transaction].BatchNumber AND TenderEntry.StoreID = [Transaction].StoreID WHERE ([Transaction].BatchNumber = '" & batch & "') ")
        ' Dim  = cmd.getSpecificRecord("SELECT    [Total] FROM   [Transaction] where [BatchNumber]='" & batch & "' ")
        Dim CashDrop = cmd.getSpecificRecord("SELECT  0+COALESCE(Sum([Amount]),0)  FROM [DropPayout] where BatchNumber='" & batch & "'   and type=0 ")
        Dim Payout = cmd.getSpecificRecord("SELECT  0+COALESCE(Sum([Amount]),0)  FROM [DropPayout] where BatchNumber='" & batch & "' and type=1 ")
        ' Dim colect = cmd.getSpecificRecord("SELECT     0+COALESCE( sum ([TotalAmount]),0)   FROM [CreditPayment] where date<= '" & optime & "' and [Paytype]=0")
        Dim Total = cmd.getSpecificRecord("SELECT  0+COALESCE(SUM(TenderEntry.TenderAmount),0) FROM  TenderEntry INNER JOIN [Transaction] ON TenderEntry.TransactionNumber = [Transaction].TransactionNumber AND TenderEntry.BatchNumber = [Transaction].BatchNumber AND TenderEntry.StoreID = [Transaction].StoreID WHERE ([Transaction].BatchNumber = '" & batch & "')  ")


        Dim tax = cmd.getSpecificRecord("SELECT  0+COALESCE(SUM([Transaction].SalesTax),0) FROM  TenderEntry INNER JOIN [Transaction] ON TenderEntry.TransactionNumber = [Transaction].TransactionNumber AND TenderEntry.BatchNumber = [Transaction].BatchNumber AND TenderEntry.StoreID = [Transaction].StoreID WHERE ([Transaction].BatchNumber = '" & batch & "')  AND (TenderEntry.TenderID =1)")



        cmd.Update("UPDATE [CashierReport] SET [Collection]='" & 0 & "' where [BatchNumber]='" & batch & "'")
        cmd.Update("UPDATE [CashierReport] SET [Discount]='" & discount & "' where [BatchNumber]='" & batch & "'")
        cmd.Update("UPDATE [CashierReport] SET [Total]='" & Total & "' where [BatchNumber]='" & batch & "'")
        cmd.Update("UPDATE [CashierReport] SET [PO]='" & PO & "' where [BatchNumber]='" & batch & "' ")
        cmd.Update("UPDATE [CashierReport] SET [Sales]='" & Cash & "' where [BatchNumber]='" & batch & "'")
        cmd.Update("UPDATE [CashierReport] SET [Payout]='" & Payout & "' where [BatchNumber]='" & batch & "'")
        cmd.Update("UPDATE [CashierReport] SET [CashDrop]='" & CashDrop & "' where [BatchNumber]='" & batch & "'")
        cmd.Update("UPDATE [CashierReport] SET [Status]='0'  where [BatchNumber]='" & batch & "'")


        cmd.Update("UPDATE [Batch] SET [Dropped]='" & CashDrop & "' where [BatchNumber]='" & batch & "'")
        cmd.Update("UPDATE [Batch] SET [PaidOut]='" & Payout & "' where [BatchNumber]='" & batch & "'")
        cmd.Update("UPDATE [Batch] SET [Discount]='" & discount & "' where [BatchNumber]='" & batch & "'")
        'cmd.Update("UPDATE [Batch] SET [Total]='" & Total & "' where [BatchNumber]='" & batch & "'")
        cmd.Update("UPDATE [Batch] SET [PaidOnAccount]='" & PO & "' where [BatchNumber]='" & batch & "' ")
        cmd.Update("UPDATE [Batch] SET [Sales]='" & Cash & "' where [BatchNumber]='" & batch & "'")
        cmd.Update("UPDATE [Batch] SET [TAX]='" & tax & "' where [BatchNumber]='" & batch & "'")
        cmd.Update("UPDATE [Batch] SET [Status]='0' where [BatchNumber]='" & batch & "'")
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim optime As Double = cmd.getSpecificRecord("SELECT max(BatchNumber)  FROM [Batch]  ") - 1




        Dim count = optime - Double.Parse(TextBox1.Text)
        Dim a = 0


        'do loop execution 


        Do


            btshow.PerformClick()
            btbalance.PerformClick()

            txtbatch.Text = Double.Parse(txtbatch.Text) + 1
            a = a + 1


        Loop While (a < count)

        MessageBox.Show("Balance Reading is done ")

    End Sub
End Class
Public Class BalanceReadingBatchAuto
    Dim cmd As New commands

    Private Sub BalanceReadingBatchAuto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    SQLConnect.txtserver.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_server", "Value", Nothing).ToString
    SQLConnect.txtdb.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_database", "Value", Nothing).ToString
    SQLConnect.txtuser.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_user", "Value", Nothing).ToString
    SQLConnect.txtpass.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Password", "Value", Nothing).ToString


  End Sub

    Public Sub rec()



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

            Dim StartReadingQ As Double = cmd.getSpecificRecord("SELECT      0+COALESCE(sum ([StartReadingQ]),0)  FROM OP_PumpSettings where [Pump]='" & a2 & "' and [Nozzle]='" & a3 & "'  ")
            Dim StartReadingA As Double = cmd.getSpecificRecord("SELECT      0+COALESCE(sum ([StartReadingA]),0)   FROM OP_PumpSettings where [Pump]='" & a2 & "' and [Nozzle]='" & a3 & "'  ")
            Dim a4 As Double = DataGridView2.Item(3, a).Value - shiftReading
            Dim a44 As Double = DataGridView2.Item(5, a).Value - shiftAReading
            If shiftReading > DataGridView2.Item(3, a).Value Then
                Dim ENDA As Double = DataGridView2.Item(3, a).Value + StartReadingQ
                a4 = ENDA - shiftReading
                cmd.Update("UPDATE OP_ShiftReading SET [endReading]='" & ENDA & "'  where [ID]='" & id & "' ")
            End If
            If shiftAReading > DataGridView2.Item(5, a).Value Then
                Dim ENDA As Double = DataGridView2.Item(5, a).Value + StartReadingA
                a44 = ENDA - shiftAReading
                cmd.Update("UPDATE OP_ShiftReading SET [endAReading]='" & ENDA & "'  where [ID]='" & id & "' ")
            End If

      a4 = Math.Round(a4, 3)
      a44 = Math.Round(a44, 3)
      Dim counter As Double = cmd.getSpecificRecord("SELECT  0+COALESCE(Max(PriceAdjustment),0)  FROM OP_PumpSettings where [Pump]='" & a2 & "' and [Nozzle]='" & a3 & "'  ")

            Dim price As Double = cmd.getSpecificRecord("SELECT  0+COALESCE(Max(Price),0)  FROM Item   where  [ItemLookupCode]='" & itemlookupcode & "'") + counter
            Dim a5 As Double = cmd.getSpecificRecord("SELECT      0+COALESCE(sum ([Volume]),0)  FROM [PumpTransactions] where Batch ='" & batch1 & "' and [Dispenser]='" & a2 & "' and [Grade]='" & itemlookupcode & "' ")
            a5 = Math.Round(a5, 3)
            Dim a55 As Double = cmd.getSpecificRecord("SELECT      0+COALESCE(sum ([Amount]),0)  FROM [PumpTransactions] where Batch ='" & batch1 & "' and [Dispenser]='" & a2 & "' and [Grade]='" & itemlookupcode & "' ")

      a55 = Math.Round(a55)
      Dim a6 As Double = a4 - a5


            Dim a7 As Double = a44 - a55



      a7 = Math.Round(a7, 3)
      a6 = Math.Round(a6, 3)

      Dim itemID = cmd.getSpecificRecord("SELECT     [ItemID]  FROM [OP_PumpSettings] where [Pump]='" & a2 & "' and [Nozzle]='" & a3 & "' ")





            Dim inventory As Double = cmd.getSpecificRecord("SELECT      0+COALESCE(sum ([DipStickHeight]),0)  FROM [ShiftEndingInventory] where ItemID='" & itemID & "' and   [BatchNumber]='" & batch1 - 1 & "'")
            Dim DipStickVolume As Double = cmd.getSpecificRecord("SELECT      0+COALESCE(sum ([DipStickVolume]),0)  FROM [ShiftEndingInventory] where ItemID='" & itemID & "' and   [BatchNumber]='" & batch1 - 1 & "'")
            Dim amounss As Double = cmd.getSpecificRecord("SELECT      0+COALESCE( sum(EndReading-[StartReading]-Calibration),0)  FROM [OP_ShiftReading] where Itemlookupcode='" & itemID & "' and   [Batch]='" & batch1 & "'")




            cmd.Update("UPDATE [ShiftEndingInventory] SET [Quantity]='" & inventory & "' ,[DipStickHeight]='" & inventory - amounss & "'   where ItemID='" & itemID & "' and   [BatchNumber]='" & batch1 & "'")
            cmd.Update("UPDATE [ShiftEndingInventory] SET [Quantity]='" & inventory + DipStickVolume - amounss & "' where ItemID='" & itemID & "' and [BatchNumber]='" & batch1 + 1 & "'")



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


        Dim optime As DateTime = cmd.getSpecificRecord("SELECT OpeningTime  FROM [Batch]  where BatchNumber='" & batch & "' ")
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
        Dim cg = cmd.getSpecificRecord("SELECT  0+COALESCE(SUM(TenderEntry.TenderAmount),0) FROM  TenderEntry INNER JOIN [Transaction] ON TenderEntry.TransactionNumber = [Transaction].TransactionNumber AND TenderEntry.BatchNumber = [Transaction].BatchNumber AND TenderEntry.StoreID = [Transaction].StoreID WHERE ([Transaction].BatchNumber = '" & batch & "')  AND (TenderEntry.TenderID =8)")
        cmd.Update("UPDATE [CashierReport] SET [other1]='" & cg & "' where [BatchNumber]='" & batch & "'")


        cmd.Update("UPDATE [Batch] SET [Dropped]='" & CashDrop & "' where [BatchNumber]='" & batch & "'")
        cmd.Update("UPDATE [Batch] SET [PaidOut]='" & Payout & "' where [BatchNumber]='" & batch & "'")
        cmd.Update("UPDATE [Batch] SET [Discount]='" & discount & "' where [BatchNumber]='" & batch & "'")
        'cmd.Update("UPDATE [Batch] SET [Total]='" & Total & "' where [BatchNumber]='" & batch & "'")
        cmd.Update("UPDATE [Batch] SET [PaidOnAccount]='" & PO & "' where [BatchNumber]='" & batch & "' ")
        cmd.Update("UPDATE [Batch] SET [Sales]='" & Cash & "' where [BatchNumber]='" & batch & "'")
        cmd.Update("UPDATE [Batch] SET [TAX]='" & tax & "' where [BatchNumber]='" & batch & "'")
        cmd.Update("UPDATE [Batch] SET [Status]='0' where [BatchNumber]='" & batch & "'")



        'cmd.delete("DELETE FROM  [ABCD_TenderEntry] WHERE  BatchNumber = '" & batch & "' ")
        'cmd.delete("DELETE FROM  [ABCD_Transaction] WHERE  BatchNumber = '" & batch & "' ")
        'cmd.delete("DELETE FROM  [ABCD_TransactionEntry] where TransactionNumber between (SELECT min(TransactionNumber) from [Transaction] where BatchNumber = '" & batch & "'  ) and (SELECT max(TransactionNumber) from [Transaction] where BatchNumber = '" & batch & "' )")
        'cmd.delete("DELETE FROM  [ABCD_CashierReport] WHERE  BatchNumber = '" & batch & "' ")


        cmd.AddRecord("INSERT INTO ABCD_TenderEntry ([ID],[StoreID],[BatchNumber],[TransactionNumber],[TenderID],[TenderAmount],[TenderChange],[LastUpdated],[Status]) (SELECT [ID],[StoreID],[BatchNumber],[TransactionNumber],[TenderID],[TenderAmount],[TenderChange],[LastUpdated],[Status]  FROM  [TenderEntry] WHERE [ID] not in (SELECT [ID] fROM ABCD_TenderEntry) and BatchNumber = '" & batch & "')")
        cmd.AddRecord("INSERT INTO ABCD_Transaction ( [StoreID],[BatchNumber],[TransactionNumber],[Time],[CustomerID],[CashierID],[Total],[SalesTax],[Comment],[ReferenceNumber],[Note],[PlateNumber],[Points],[OtherTransactionNumber],[Void],[CustomText1],[CustomText2],[CustomNumber1],[CustomNumber2],[CustomDate1],[Customdate2],[CPoints],[Status],[Vatable],[NonVat],[TaxExempt],[Discount],[PointStatus],[Istatus],[repstatus],[TranNo]) (SELECT   [StoreID],[BatchNumber],[TransactionNumber],[Time],[CustomerID],[CashierID],[Total],[SalesTax],[Comment],[ReferenceNumber],[Note],[PlateNumber],[Points],[OtherTransactionNumber],[Void],[CustomText1],[CustomText2],[CustomNumber1],[CustomNumber2],[CustomDate1],[Customdate2],[CPoints],[Status],[Vatable],[NonVat],[TaxExempt],[Discount],[PointStatus],[Istatus],[repstatus],[TranNo] fROM  [Transaction]    WHERE  [BatchNumber] = '" & batch & "' and   TransactionNumber not in    (SELECT TransactionNumber  fROM ABCD_Transaction ))")
        cmd.AddRecord("INSERT INTO ABCD_TransactionEntry ([ID],[StoreID],[ItemID],[TransactionNumber],[Cost],[FullPrice],[Price],[SalesTax],[Quantity],[Taxable],[POSTECPrice],[POSTECID],[EntryType],[Discount],[Status]) (SELECT [ID],[StoreID],[ItemID],[TransactionNumber],[Cost],[FullPrice],[Price],[SalesTax],[Quantity],[Taxable],[POSTECPrice],[POSTECID],[EntryType],[Discount],[Status] fROM  [TransactionEntry]    WHERE  [ID] not in    (SELECT [ID]  fROM ABCD_TransactionEntry) and TransactionNumber between (SELECT min(TransactionNumber) from [Transaction] where BatchNumber =  '" & batch & "' ) and (SELECT max(TransactionNumber) from [Transaction] ))")
        cmd.AddRecord("INSERT INTO ABCD_CashierReport ([BatchNumber],[CashierID],[Sales],[OpeningAmount],[Collection],[PO],[CashDrop],[Expenses],[Status],[Discount],[Total],[Payout],[LastDrop]) (SELECT  [BatchNumber],[CashierID],[Sales],[OpeningAmount],[Collection],[PO],[CashDrop],[Expenses],[Status],[Discount],[Total],[Payout],[LastDrop] fROM  CashierReport    WHERE  [BatchNumber] not in    (SELECT [BatchNumber]  fROM ABCD_CashierReport ))")



    End Sub



End Class
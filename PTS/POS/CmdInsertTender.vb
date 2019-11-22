Imports TiT.PTS
Public Class CmdInsertTender
  Dim cmd As commands

  Public Sub New()


    cmd = New commands

    SQLConnect.txtserver.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_server", "Value", Nothing).ToString
    SQLConnect.txtdb.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_database", "Value", Nothing).ToString
    SQLConnect.txtuser.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_user", "Value", Nothing).ToString
    SQLConnect.txtpass.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Password", "Value", Nothing).ToString


  End Sub
  Public Sub updateitem(Pump As Integer, Nozzle As Integer)


    cmd.Update($"UPDATE OP_PumpSettings SET      Status = '0'  WHERE    Pump = '{ Pump }' and Nozzle='{ Nozzle }'")
  End Sub

  Function InsertCashTransaction(tenderid As Integer, Accountnumber As String, StoreID As Integer, BatchNumber As Integer, CashierID As Integer, ReferenceNumber As String, Note As String, PlateNumber As String, changes As String, shiftno As Integer) As Integer
    Dim csp As New ComputationShow

    Dim _tenderid As Integer = tenderid

    Dim cmdStr As String = ""

    cmdStr += "SELECT 0+COALESCE (MAX([Transaction].TranNo), 0)+1 "
    cmdStr += " FROM [Transaction] INNER JOIN TenderEntry ON [Transaction].TransactionNumber = TenderEntry.TransactionNumber "
    cmdStr += $"WHERE        (TenderEntry.TenderID = '{_tenderid}')"



    Dim ORNUMBER As Integer = Integer.Parse(cmd.getSpecificRecord(cmdStr))

    Dim _Accountnumber As String = Accountnumber
    Dim _StoreID As Integer = StoreID
    Dim _BatchNumber As Integer = BatchNumber
    Dim _CustomerID As Integer = Integer.Parse(cmd.getSpecificRecord($"SELECT 0+COALESCE(Max( id),0)  FROM [Customer]  where [AccountNumber]='{ _Accountnumber }' "))
    If _CustomerID = 0 Then
      _CustomerID = 99999
    End If

    Dim _Total As Decimal = csp.TotalAmount - csp.TotalDiscount
    Dim _CashierID As Integer = CashierID

    Dim _SalesTax As Decimal = csp.Tax
    Dim _ReferenceNumber As String = ReferenceNumber
    Dim _Note As String = Note
    Dim _PlateNumber As String = PlateNumber
    Dim _Vatable As Decimal = csp.Vat
    Dim _Discount As Decimal = csp.TotalDiscount
    Dim checker As String = changes
    If checker Is Nothing Then
      checker = "0"
    ElseIf checker = "" Then
      checker = "0"
    End If
    Dim _TenderChange As Decimal = Decimal.Parse(checker)
    cmdStr = ""

    cmdStr += "INSERT INTO [Transaction]("
    cmdStr += "[StoreID],"
    cmdStr += "[BatchNumber],"
    cmdStr += "[CustomerID],"
    cmdStr += "[CashierID],"
    cmdStr += "[Total],"
    cmdStr += "[SalesTax],"
    cmdStr += "[ReferenceNumber],"
    cmdStr += "[Note],"
    cmdStr += "[PlateNumber],"
    cmdStr += "[Vatable],"
    cmdStr += "[Discount]"
    cmdStr += ",TranNo)"
    cmdStr += "values("
    cmdStr += $"'{_StoreID }',"     'StoreID
    cmdStr += $"'{_BatchNumber }',"      'BatchNumber
    cmdStr += $"'{_CustomerID }',"      'CustomerID
    cmdStr += $"'{_CashierID }',"      'CashierID
    cmdStr += $"'{_Total }',"      'Total
    cmdStr += $"'{_SalesTax }',"      'SalesTax
    cmdStr += $"'{_ReferenceNumber }',"      'ReferenceNumber
    cmdStr += $"'{_Note }',"      'Note
    cmdStr += $"'{_PlateNumber }',"      'PlateNumber
    cmdStr += $"'{ _Vatable}',"      'Vatable
    cmdStr += $"'{_Discount }',"      'Discount
    cmdStr += $"'{ORNUMBER }')"      'ORNUMBER



    cmd.AddRecord(cmdStr)
    Dim tranNo As Integer = Integer.Parse(cmd.getSpecificRecord("SELECT  0+COALESCE(Max([TransactionNumber]),0)  FROM [Transaction]  ").ToString)


    cmdStr = ""

    cmdStr += "INSERT INTO [TenderEntry]("
    cmdStr += "[StoreID],"
    cmdStr += "[BatchNumber],"
    cmdStr += "[TransactionNumber],"
    cmdStr += "[TenderID],"
    cmdStr += "[TenderAmount],"
    cmdStr += "[TenderChange])"
    cmdStr += "values( "
    cmdStr += $"'{_StoreID }'," 'StoreID
    cmdStr += $"'{_BatchNumber }'," 'BatchNumber
    cmdStr += $"'{tranNo }'," 'TransactionNumber
    cmdStr += $"'{_tenderid}'," 'TenderID
    cmdStr += $"'{_Total }'," 'TenderAmount
    cmdStr += $"'{_TenderChange }')" 'TenderChange

    cmd.AddRecord(cmdStr)

    cmdStr = ""

    Select Case _tenderid
      Case 1


      Case 2
        Dim AccountBalance As Decimal = Decimal.Parse(cmd.getSpecificRecord($"Select  0+COALESCE(Max([AccountBalance]),0)  FROM [Customer]  where id='{ _CustomerID }'"))
        cmdStr += "INSERT INTO [AccountReceivable]("
        cmdStr += "[StoreID],"
        cmdStr += "[OriginID],"
        cmdStr += "[CustomerID],"
        cmdStr += "[OriginalAmount],"
        cmdStr += "[TransactionNumber],"
        cmdStr += "[Balance],"
        cmdStr += "CurrentAccountBalance)"
        cmdStr += "values("
        cmdStr += $"'{_StoreID }'," 'StoreID
        cmdStr += $"'{_StoreID }'," 'OriginID
        cmdStr += $"'{_CustomerID }'," 'CustomerID
        cmdStr += $"'{_Total }'," 'OriginalAmount
        cmdStr += $"'{tranNo }'," 'TransactionNumber
        cmdStr += $"'{AccountBalance }'," 'Balance
        cmdStr += $"'{AccountBalance }')" 'CurrentAccountBalance


        cmd.AddRecord(cmdStr)

    End Select
    cmdStr = ""




    For i As Integer = 0 To TiT.PTS.MainForm.DataGridView2.RowCount - 1


      ' Me.DataGridView2.Rows.Add(ItemLookUp, Description & "(" & Column1 & ")", Quantity, UnitPrice, Amount, Discount, 0, 0, IDZ, Column1)

      Dim ItemLookUp As String = TiT.PTS.MainForm.DataGridView2.Rows(i).Cells(0).Value.ToString
      Dim Description As String = TiT.PTS.MainForm.DataGridView2.Rows(i).Cells(1).Value.ToString
      Dim Quantity As Decimal = Decimal.Parse(TiT.PTS.MainForm.DataGridView2.Rows(i).Cells(2).Value.ToString)
      Dim UnitPrice As Decimal = Decimal.Parse(TiT.PTS.MainForm.DataGridView2.Rows(i).Cells(3).Value.ToString)
      Dim Amount As Decimal = Decimal.Parse(TiT.PTS.MainForm.DataGridView2.Rows(i).Cells(4).Value.ToString)
      Dim Discount As Decimal = Decimal.Parse(TiT.PTS.MainForm.DataGridView2.Rows(i).Cells(5).Value.ToString)
      Dim IDZ As Integer = Integer.Parse(TiT.PTS.MainForm.DataGridView2.Rows(i).Cells(8).Value.ToString)
      Dim Column1 As Integer = Integer.Parse(TiT.PTS.MainForm.DataGridView2.Rows(i).Cells(9).Value.ToString)
      Dim itmeid = cmd.getSpecificRecord($"SELECT  id  FROM [Item]  where ItemLookupCode='{ ItemLookUp }' ")
      Dim tax As Double = Amount * 0.107143

      cmdStr += "INSERT INTO [TransactionEntry] "
      cmdStr += "([StoreID],"
      cmdStr += "[ItemID],"
      cmdStr += "[TransactionNumber],"
      cmdStr += "[FullPrice],"
      cmdStr += "[Price],"
      cmdStr += "[SalesTax],"
      cmdStr += "[Quantity],"
      cmdStr += "[Taxable],"
      cmdStr += "[POSTECPrice],"
      cmdStr += "[POSTECID]"
      cmdStr += ",[Discount])values("
      cmdStr += $"'{_StoreID }'," 'StoreID
      cmdStr += $"'{itmeid }'," 'ItemID
      cmdStr += $"'{tranNo }'," 'TransactionNumber
      cmdStr += $"'{UnitPrice }'," 'FullPrice
      cmdStr += $"'{UnitPrice }'," 'Price
      cmdStr += $"'{tax }'," 'SalesTax
      cmdStr += $"'{Quantity }'," 'Quantity
      cmdStr += $"'{1 }'," 'Taxable
      cmdStr += $"'{Amount }'," 'POSTECPrice
      cmdStr += $"'{Column1 }'," 'POSTECID
      cmdStr += $"'{Discount }')" 'Discount


      cmd.AddRecord(cmdStr)
      cmdStr = ""
      cmd.Update($"UPDATE Item SET [Quantity]=[Quantity]-{Quantity} where [id]='{itmeid}'")
      cmd.Update($"UPDATE PumpTransactions SET      Status = '2',TransNum='{ tranNo }',Batch='{ _BatchNumber }'   WHERE    ID = '{ IDZ }'")
      Select Case _tenderid
        Case 3
          cmd.Update($"UPDATE PumpTransactions SET      Status = '3',TransNum='{ tranNo }',Batch='{ _BatchNumber }'   WHERE    ID = '{ IDZ }'")


          cmd.Update("UPDATE OP_ShiftReading   SET Calibration = COALESCE(totals.sum_points, 0)  FROM OP_ShiftReading AS u LEFT OUTER  JOIN ( SELECT Batch,Dispenser,Grade, 0+COALESCE(SUM(Volume),0) AS sum_points  FROM PumpTransactions where Volume<>0  and Volume IS NOT NULL  and status=3  GROUP BY  Batch,Dispenser,Grade ) AS totals ON totals.Batch = u.Batch  and totals.Dispenser = u.Pump and totals.Grade = u.Itemlookupcode")

          cmd.Update(" UPDATE OP_ShiftReading  SET ACalibration = COALESCE(totals.sum_points, 0) FROM OP_ShiftReading AS u LEFT OUTER  JOIN ( SELECT Batch,Dispenser,Grade, 0+COALESCE(SUM(amount),0) AS sum_points  FROM PumpTransactions where Volume<>0  and Volume IS NOT NULL  and status=3 GROUP BY  Batch,Dispenser,Grade ) AS totals ON totals.Batch = u.Batch  and totals.Dispenser = u.Pump and totals.Grade = u.Itemlookupcode")


      End Select
    Next
    Dim CRU As New CashierReportUpdate
    CRU.cr(BatchNumber, shiftno, CashierID)

    Return tranNo

  End Function

End Class
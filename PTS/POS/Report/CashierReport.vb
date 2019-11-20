Public Class CashierReport
  Dim cmd As commands
  Public Sub New()
    cmd = New commands
    SQLConnect.txtserver.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_server", "Value", Nothing).ToString
    SQLConnect.txtdb.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_database", "Value", Nothing).ToString
    SQLConnect.txtuser.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_user", "Value", Nothing).ToString
    SQLConnect.txtpass.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Password", "Value", Nothing).ToString

  End Sub
  Public Sub crPrint(batch As Integer)

    Dim batchnumber As Integer = batch
    Dim TextToPrint As String = ""

    Dim cmdstr As String = ""


    Dim StringToPrint As String = ""
    Dim LineLen As Integer = StringToPrint.Length
    Dim spcLen As New String(" "c, Math.Round((40 - LineLen) / 2))
    TextToPrint += spcLen & StringToPrint & Environment.NewLine
    TextToPrint &= "" & Environment.NewLine


    StringToPrint = cmd.getSpecificRecord("SELECT  StoreName FROM   Configuration   ")
    If StringToPrint <> "" Then
      LineLen = StringToPrint.Length
      spcLen = New String(" "c, Math.Round((40 - LineLen) / 2))
      TextToPrint &= spcLen & StringToPrint & Environment.NewLine

    End If

    StringToPrint = cmd.getSpecificRecord("SELECT  StoreAddress1 FROM   Configuration   ")
    If StringToPrint <> "" Then
      LineLen = StringToPrint.Length
      spcLen = New String(" "c, Math.Round((40 - LineLen) / 2))
      TextToPrint &= spcLen & StringToPrint & Environment.NewLine

    End If

    StringToPrint = cmd.getSpecificRecord("SELECT  VATRegistrationNumber FROM   Configuration   ")
    If StringToPrint <> "" Then
      LineLen = StringToPrint.Length
      spcLen = New String(" "c, Math.Round((40 - LineLen) / 2))
      TextToPrint &= spcLen & StringToPrint & Environment.NewLine

    End If



    StringToPrint = cmd.getSpecificRecord("SELECT  Heading FROM   Headfoot   ")
    If StringToPrint <> "" Then
      LineLen = StringToPrint.Length
      spcLen = New String(" "c, Math.Round((40 - LineLen) / 2))
      TextToPrint &= spcLen & StringToPrint & Environment.NewLine

    End If


    StringToPrint = cmd.getSpecificRecord("SELECT  Heading2 FROM   Headfoot   ")
    If StringToPrint <> "" Then
      LineLen = StringToPrint.Length
      spcLen = New String(" "c, Math.Round((40 - LineLen) / 2))
      TextToPrint &= spcLen & StringToPrint & Environment.NewLine

    End If


    StringToPrint = cmd.getSpecificRecord("SELECT  Heading3 FROM   Headfoot   ")
    If StringToPrint <> "" Then
      LineLen = StringToPrint.Length
      spcLen = New String(" "c, Math.Round((40 - LineLen) / 2))
      TextToPrint &= spcLen & StringToPrint & Environment.NewLine

    End If

    StringToPrint = cmd.getSpecificRecord("SELECT  Heading4 FROM   Headfoot   ")
    If StringToPrint <> "" Then
      LineLen = StringToPrint.Length
      spcLen = New String(" "c, Math.Round((40 - LineLen) / 2))
      TextToPrint &= spcLen & StringToPrint & Environment.NewLine

    End If

    TextToPrint &= "" & Environment.NewLine
    TextToPrint &= "" & Environment.NewLine


    StringToPrint = "CASHIER REPORT"
    LineLen = StringToPrint.Length
    spcLen = New String(" "c, Math.Round((40 - LineLen) / 2))
    TextToPrint &= spcLen & StringToPrint & Environment.NewLine
    TextToPrint &= "" & Environment.NewLine








    '"Cash Drawer Details











    Dim minTranNoCash As String = cmd.getSpecificRecord("SELECT       0+COALESCE(min( [Transaction].TranNo),0) FROM           [Transaction] INNER JOIN                         TenderEntry ON[Transaction].TransactionNumber =TenderEntry.TransactionNumber where  TenderEntry.TenderID =1 and [Transaction].[BatchNumber] between '" & batchnumber & "' and '" & batchnumber & "'and [Transaction].TranNo<>0 ")

    Dim minTranNoPO As String = cmd.getSpecificRecord("SELECT       0+COALESCE(min( [Transaction].TranNo),0) FROM           [Transaction] INNER JOIN                         TenderEntry ON[Transaction].TransactionNumber =TenderEntry.TransactionNumber where  TenderEntry.TenderID =2 and [Transaction].[BatchNumber] between '" & batchnumber & "' and '" & batchnumber & "' and [Transaction].TranNo<>0")

    Dim maxPoTranNo As String = cmd.getSpecificRecord("SELECT       0+COALESCE(Max( [Transaction].TranNo),0) FROM           [Transaction] INNER JOIN                         TenderEntry ON[Transaction].TransactionNumber =TenderEntry.TransactionNumber where  TenderEntry.TenderID =2 and [Transaction].[BatchNumber] between '" & batchnumber & "' and '" & batchnumber & "' and [Transaction].TranNo<>0")
    Dim maxTranNoCash As String = cmd.getSpecificRecord("SELECT       0+COALESCE(Max( [Transaction].TranNo),0) FROM           [Transaction] INNER JOIN                         TenderEntry ON[Transaction].TransactionNumber =TenderEntry.TransactionNumber where  TenderEntry.TenderID =1 and [Transaction].[BatchNumber] between '" & batchnumber & "' and '" & batchnumber & "'and [Transaction].TranNo<>0 ")

    Dim CashierID As Integer = Integer.Parse(cmd.getSpecificRecord("SELECT      CashierID FROM   [CashierReport]  where [BatchNumber]='" & batchnumber & "'  "))
    Dim CashierName As String = cmd.getSpecificRecord("SELECT      [Name] FROM   [Cashier]  where [ID]='" & CashierID & "'  ")

    Dim Shiftno = cmd.getSpecificRecord("SELECT  0+COALESCE(Max([ShiftNumber]),0)  FROM [OP_ShiftReading] where batch='" & batchnumber & "' ")


    Dim a1 As String = "Cashier Name:  " & CashierName
    Dim a2 As String = "Batch Number:  " & batchnumber
    Dim a3 As String = "Shift Number:  " & Shiftno

    Dim a4 As String = "Opening Time:  " & cmd.getSpecificRecord("SELECT    [OpeningTime] FROM   [Batch] where [BatchNumber]='" & batchnumber & "'  ")
    Dim a5 As String = "Closing Time:  " & cmd.getSpecificRecord("SELECT   ( case when [ClosingTime] is null then getdate() else  [ClosingTime] end ) FROM   [Batch] where [BatchNumber]='" & batchnumber & "'  ")
    Dim a6 As String = "Transaction Count:  " & cmd.getSpecificRecord("SELECT   Count( [TransactionNumber]) FROM   [Transaction]  where [BatchNumber]='" & batchnumber & "'  ")


    Dim a7 As String = "Cash Transaction No: " & minTranNoCash & " to " & maxTranNoCash
    Dim a8 As String = "PO Transaction No:   " & minTranNoPO & " to " & maxPoTranNo





    Dim a9 As String = "Cash Drawer Details"


    TextToPrint &= "_____________________________________________" & Environment.NewLine
    TextToPrint &= a1 & Environment.NewLine
    TextToPrint &= a2 & "  " & a3 & Environment.NewLine
    TextToPrint &= a4 & Environment.NewLine
    TextToPrint &= a5 & Environment.NewLine
    TextToPrint &= a6 & Environment.NewLine
    TextToPrint &= a7 & Environment.NewLine
    TextToPrint &= a8 & Environment.NewLine
    TextToPrint &= "" & Environment.NewLine
    TextToPrint &= a9 & Environment.NewLine
    TextToPrint &= "_____________________________________________" & Environment.NewLine










    cmdstr = ""


    cmdstr += "SELECT "
    cmdstr += " LEFT( Item.Description,8),"
    cmdstr += "  sum(TransactionEntry.Quantity) as Quantity,"
    cmdstr += "  Sum(TransactionEntry.POSTECPrice) as Amount,"
    cmdstr += " Item.ID "
    cmdstr += " FROM TenderEntry INNER JOIN TransactionEntry ON TenderEntry.TransactionNumber = TransactionEntry.TransactionNumber INNER JOIN Item ON TransactionEntry.ItemID = Item.ID "
    cmdstr += $" WHERE (TenderEntry.BatchNumber = {batchnumber}  and Item.CategoryID=2 and TenderEntry.TenderID<>3 and TenderEntry.TenderID<>0 and TenderEntry.TenderID<>4  ) "
    cmdstr += "  group by Item.Description , Item.ID"

    Dim dt As New DataTable
    dt = cmd.LoaderData(cmdstr)

    cmdstr = ""


    TextToPrint &= "==================FUEL====================" & Environment.NewLine
    '  TextToPrint &= "Description" & Environment.NewLine
    ' TextToPrint &= "Description" & " " & "Price    " & " " & "QTY      " & " " & "Total      "
    TextToPrint &= "Description  " & " " & "QTY      " & " " & "Amount   "
    TextToPrint &= "" & Environment.NewLine




    Dim LITERS As Double = 0
    Dim amount As Double = 0

    If dt.Rows.Count <> 0 Then
      For i As Integer = 0 To dt.Rows.Count - 1

        Dim Description As String = dt.Rows(i).Item(0).ToString
        Dim Quantity As Decimal = Math.Round(Decimal.Parse(dt.Rows(i).Item(1).ToString), 2)
        Dim POSTECPrice As Decimal = Math.Round(Decimal.Parse(dt.Rows(i).Item(2).ToString), 2)
        amount += Math.Round(Decimal.Parse(dt.Rows(i).Item(2).ToString), 2)
        LITERS += Math.Round(Decimal.Parse(dt.Rows(i).Item(1).ToString), 2)

        Dim b1 As Integer
        b1 = 0
        Dim s As String = Description
        For Each c As Char In s
          b1 += 1
        Next
        Dim b11 = 12 - b1


        Dim b2 As Integer
        b2 = 0

        Dim s1 As String = String.Format("{0:N2}", Quantity)
        For Each c As Char In s1
          b2 += 1
        Next
        Dim b22 = 9 - b2



        Dim total As String = " " & Description & Space(b11) & " " & String.Format("{0:N2}", Quantity) & Space(b22) & " " & String.Format("{0:N2}", POSTECPrice)
        TextToPrint &= total & Environment.NewLine

      Next
      Dim h1 As Decimal = Math.Round(Decimal.Parse(cmd.getSpecificRecord("SELECT        0 + COALESCE (SUM(DeleteTransactionEntry.Quantity), 0) FROM   DeleteTransaction INNER JOIN  DeleteTenderEntry ON DeleteTransaction.TransactionNumber = DeleteTenderEntry.TransactionNumber INNER JOIN  DeleteTransactionEntry ON DeleteTransaction.TransactionNumber = DeleteTransactionEntry.TransactionNumber INNER JOIN Item ON DeleteTransactionEntry.ItemID = Item.ID  WHERE        [DeleteTransaction].BatchNumber = '" & batchnumber & "' and Item.CategoryID =1 ")), 2)

      Dim h2 As Decimal = Math.Round(Decimal.Parse(cmd.getSpecificRecord("SELECT        0 + COALESCE (SUM(DeleteTransactionEntry.POSTECPrice), 0) FROM   DeleteTransaction INNER JOIN  DeleteTenderEntry ON DeleteTransaction.TransactionNumber = DeleteTenderEntry.TransactionNumber INNER JOIN  DeleteTransactionEntry ON DeleteTransaction.TransactionNumber = DeleteTransactionEntry.TransactionNumber INNER JOIN Item ON DeleteTransactionEntry.ItemID = Item.ID  WHERE        [DeleteTransaction].BatchNumber = '" & batchnumber & "'  and Item.CategoryID =1 ")), 2)




      Dim LITERSlenght As Integer
      LITERSlenght = 0
      Dim s5 As String = String.Format("{0:N2}", LITERS)
      For Each c As Char In s5
        LITERSlenght += 1
      Next
      Dim LITERSlenghts = 9 - LITERSlenght

      Dim print As String = " " & Space(12) & " " & String.Format("{0:N2}", LITERS) & Space(LITERSlenghts) & " " & String.Format("{0:N2}", amount)


      TextToPrint &= print & Environment.NewLine
    End If
    TextToPrint &= "==========================================" & Environment.NewLine





    cmdstr = ""


    cmdstr += "SELECT "
    cmdstr += " LEFT( Item.Description,8),"
    cmdstr += "  sum(TransactionEntry.Quantity) as Quantity,"
    cmdstr += "  Sum(TransactionEntry.POSTECPrice) as Amount,"
    cmdstr += " Item.ID "
    cmdstr += " FROM TenderEntry INNER JOIN TransactionEntry ON TenderEntry.TransactionNumber = TransactionEntry.TransactionNumber INNER JOIN Item ON TransactionEntry.ItemID = Item.ID "
    cmdstr += $" WHERE (TenderEntry.BatchNumber = {batchnumber}  and Item.CategoryID=1 and TenderEntry.TenderID<>3 and TenderEntry.TenderID<>0 and TenderEntry.TenderID<>4  ) "
    cmdstr += "  group by Item.Description , Item.ID"

    dt = New DataTable
    dt = cmd.LoaderData(cmdstr)

    cmdstr = ""


    TextToPrint &= "================NON-FUEL==================" & Environment.NewLine
    '  TextToPrint &= "Description" & Environment.NewLine
    ' TextToPrint &= "Description" & " " & "Price    " & " " & "QTY      " & " " & "Total      "
    TextToPrint &= "Description  " & " " & "QTY      " & " " & "Amount   "
    TextToPrint &= "" & Environment.NewLine




    LITERS = 0
    amount = 0

    If dt.Rows.Count <> 0 Then
      For i As Integer = 0 To dt.Rows.Count - 1

        Dim Description As String = dt.Rows(i).Item(0).ToString
        Dim Quantity As Decimal = Math.Round(Decimal.Parse(dt.Rows(i).Item(1).ToString), 2)
        Dim POSTECPrice As Decimal = Math.Round(Decimal.Parse(dt.Rows(i).Item(2).ToString), 2)
        amount += Math.Round(Decimal.Parse(dt.Rows(i).Item(2).ToString), 2)
        LITERS += Math.Round(Decimal.Parse(dt.Rows(i).Item(1).ToString), 2)

        Dim b1 As Integer
        b1 = 0
        Dim s As String = Description
        For Each c As Char In s
          b1 += 1
        Next
        Dim b11 = 12 - b1


        Dim b2 As Integer
        b2 = 0

        Dim s1 As String = String.Format("{0:N2}", Quantity)
        For Each c As Char In s1
          b2 += 1
        Next
        Dim b22 = 9 - b2



        Dim total As String = " " & Description & Space(b11) & " " & String.Format("{0:N2}", Quantity) & Space(b22) & " " & String.Format("{0:N2}", POSTECPrice)
        TextToPrint &= total & Environment.NewLine

      Next
      Dim h1 As Decimal = Math.Round(Decimal.Parse(cmd.getSpecificRecord("SELECT        0 + COALESCE (SUM(DeleteTransactionEntry.Quantity), 0) FROM   DeleteTransaction INNER JOIN  DeleteTenderEntry ON DeleteTransaction.TransactionNumber = DeleteTenderEntry.TransactionNumber INNER JOIN  DeleteTransactionEntry ON DeleteTransaction.TransactionNumber = DeleteTransactionEntry.TransactionNumber INNER JOIN Item ON DeleteTransactionEntry.ItemID = Item.ID  WHERE        [DeleteTransaction].BatchNumber = '" & batchnumber & "' and Item.CategoryID =1 ")), 2)

      Dim h2 As Decimal = Math.Round(Decimal.Parse(cmd.getSpecificRecord("SELECT        0 + COALESCE (SUM(DeleteTransactionEntry.POSTECPrice), 0) FROM   DeleteTransaction INNER JOIN  DeleteTenderEntry ON DeleteTransaction.TransactionNumber = DeleteTenderEntry.TransactionNumber INNER JOIN  DeleteTransactionEntry ON DeleteTransaction.TransactionNumber = DeleteTransactionEntry.TransactionNumber INNER JOIN Item ON DeleteTransactionEntry.ItemID = Item.ID  WHERE        [DeleteTransaction].BatchNumber = '" & batchnumber & "'  and Item.CategoryID =1 ")), 2)




      Dim LITERSlenght As Integer
      LITERSlenght = 0
      Dim s5 As String = String.Format("{0:N2}", LITERS)
      For Each c As Char In s5
        LITERSlenght += 1
      Next
      Dim LITERSlenghts = 9 - LITERSlenght

      Dim print As String = " " & Space(12) & " " & String.Format("{0:N2}", LITERS) & Space(LITERSlenghts) & " " & String.Format("{0:N2}", amount)


      TextToPrint &= print & Environment.NewLine
    End If
    TextToPrint &= "==========================================" & Environment.NewLine














    Dim a11c As Decimal = Decimal.Parse(cmd.getSpecificRecord("SELECT        0 + COALESCE (SUM(TransactionEntry.POSTECPrice), 0) FROM [Transaction] INNER JOIN TenderEntry ON [Transaction].TransactionNumber = TenderEntry.TransactionNumber INNER JOIN TransactionEntry ON [Transaction].TransactionNumber = TransactionEntry.TransactionNumber WHERE        [Transaction].BatchNumber = '" & batchnumber & "'  and TenderEntry.TenderID=1   "))
    Dim a22c As Decimal = Decimal.Parse(cmd.getSpecificRecord("SELECT        0 + COALESCE (SUM(TransactionEntry.POSTECPrice), 0) FROM [Transaction] INNER JOIN TenderEntry ON [Transaction].TransactionNumber = TenderEntry.TransactionNumber INNER JOIN TransactionEntry ON [Transaction].TransactionNumber = TransactionEntry.TransactionNumber WHERE        [Transaction].BatchNumber = '" & batchnumber & "'  and TenderEntry.TenderID=2   "))
    Dim N2 As Decimal = Decimal.Parse(cmd.getSpecificRecord("SELECT        0 + COALESCE (SUM(TransactionEntry.Quantity), 0) FROM [Transaction] INNER JOIN TenderEntry ON [Transaction].TransactionNumber = TenderEntry.TransactionNumber INNER JOIN TransactionEntry ON [Transaction].TransactionNumber = TransactionEntry.TransactionNumber WHERE        [Transaction].BatchNumber = '" & batchnumber & "'  and TenderEntry.TenderID=1   "))
    Dim N3 As Decimal = Decimal.Parse(cmd.getSpecificRecord("SELECT        0 + COALESCE (SUM(TransactionEntry.Quantity), 0) FROM [Transaction] INNER JOIN TenderEntry ON [Transaction].TransactionNumber = TenderEntry.TransactionNumber INNER JOIN TransactionEntry ON [Transaction].TransactionNumber = TransactionEntry.TransactionNumber WHERE        [Transaction].BatchNumber = '" & batchnumber & "'  and TenderEntry.TenderID=2   "))
    Dim N4 As Decimal = Decimal.Parse(cmd.getSpecificRecord("SELECT        0 + COALESCE (SUM(TransactionEntry.Quantity), 0) FROM [Transaction] INNER JOIN TenderEntry ON [Transaction].TransactionNumber = TenderEntry.TransactionNumber INNER JOIN TransactionEntry ON [Transaction].TransactionNumber = TransactionEntry.TransactionNumber WHERE        [Transaction].BatchNumber = '" & batchnumber & "'  and TenderEntry.TenderID=5   "))
    Dim N44 As Decimal = Decimal.Parse(cmd.getSpecificRecord("SELECT        0 + COALESCE (SUM(TransactionEntry.Quantity), 0) FROM [Transaction] INNER JOIN TenderEntry ON [Transaction].TransactionNumber = TenderEntry.TransactionNumber INNER JOIN TransactionEntry ON [Transaction].TransactionNumber = TransactionEntry.TransactionNumber WHERE        [Transaction].BatchNumber = '" & batchnumber & "'  and TenderEntry.TenderID=8   "))

    'Dim a33 As decimal = cmd.getSpecificRecord("SELECT    [TaxExempt] FROM   [Transaction]  where [TransactionNumber]='" & TransactionNo & "'  "))
    '  Dim a44 As decimal = cmd.getSpecificRecord("SELECT  0+COALESCE( sum( [Discount]),0) FROM   [Transaction]  where [BatchNumber]='" & batch & "'  "))

    Dim a55 As Decimal = Decimal.Parse(cmd.getSpecificRecord("SELECT      max( [CashDrop]) FROM   [CashierReport]  where [BatchNumber]='" & batchnumber & "'  "))
    'Dim a66 As decimal = cmd.getSpecificRecord("SELECT      max( [Collection]) FROM   [CashierReport]  where [BatchNumber]='" & batch & "'  ")
    Dim a77 As Decimal = Decimal.Parse(cmd.getSpecificRecord("SELECT      max( [CashDrop]) FROM   [CashierReport]  where [BatchNumber]='" & batchnumber & "'  "))
    Dim a99 As Decimal = Decimal.Parse(cmd.getSpecificRecord("SELECT      max( [Payout]) FROM   [CashierReport]  where [BatchNumber]='" & batchnumber & "'  "))

    Dim a44 As Decimal = Decimal.Parse(cmd.getSpecificRecord("SELECT        0 + COALESCE (SUM([TransactionEntry].Discount), 0) FROM [Transaction] INNER JOIN TenderEntry ON [Transaction].TransactionNumber = TenderEntry.TransactionNumber INNER JOIN TransactionEntry ON [Transaction].TransactionNumber = TransactionEntry.TransactionNumber WHERE        [Transaction].BatchNumber = '" & batchnumber & "'  "))
    Dim f44 As Decimal = Decimal.Parse(cmd.getSpecificRecord("SELECT        0 + COALESCE (SUM([TransactionEntry].Discount), 0) FROM [Transaction] INNER JOIN TenderEntry ON [Transaction].TransactionNumber = TenderEntry.TransactionNumber INNER JOIN TransactionEntry ON [Transaction].TransactionNumber = TransactionEntry.TransactionNumber WHERE        [Transaction].BatchNumber = '" & batchnumber & "' and TenderEntry.TenderID=1  "))
    Dim g44 As Decimal = Decimal.Parse(cmd.getSpecificRecord("SELECT        0 + COALESCE (SUM([TransactionEntry].Discount), 0) FROM [Transaction] INNER JOIN TenderEntry ON [Transaction].TransactionNumber = TenderEntry.TransactionNumber INNER JOIN TransactionEntry ON [Transaction].TransactionNumber = TransactionEntry.TransactionNumber WHERE        [Transaction].BatchNumber = '" & batchnumber & "' and TenderEntry.TenderID=2 "))



    Dim aA11 As Decimal = Decimal.Parse(cmd.getSpecificRecord("SELECT        0 + COALESCE (SUM(TransactionEntry.POSTECPrice), 0) FROM [Transaction] INNER JOIN TenderEntry ON [Transaction].TransactionNumber = TenderEntry.TransactionNumber INNER JOIN TransactionEntry ON [Transaction].TransactionNumber = TransactionEntry.TransactionNumber WHERE        [Transaction].BatchNumber = '" & batchnumber & "'  and TenderEntry.TenderID=5   "))
    Dim CC44 As Decimal = Decimal.Parse(cmd.getSpecificRecord("SELECT        0 + COALESCE (SUM([TransactionEntry].Discount), 0) FROM [Transaction] INNER JOIN TenderEntry ON [Transaction].TransactionNumber = TenderEntry.TransactionNumber INNER JOIN TransactionEntry ON [Transaction].TransactionNumber = TransactionEntry.TransactionNumber WHERE        [Transaction].BatchNumber = '" & batchnumber & "' and TenderEntry.TenderID=5  "))

    Dim aA111 As Decimal = Decimal.Parse(cmd.getSpecificRecord("SELECT        0 + COALESCE (SUM(TransactionEntry.POSTECPrice), 0) FROM [Transaction] INNER JOIN TenderEntry ON [Transaction].TransactionNumber = TenderEntry.TransactionNumber INNER JOIN TransactionEntry ON [Transaction].TransactionNumber = TransactionEntry.TransactionNumber WHERE        [Transaction].BatchNumber = '" & batchnumber & "'  and TenderEntry.TenderID=8   "))
    Dim CC444 As Decimal = Decimal.Parse(cmd.getSpecificRecord("SELECT        0 + COALESCE (SUM([TransactionEntry].Discount), 0) FROM [Transaction] INNER JOIN TenderEntry ON [Transaction].TransactionNumber = TenderEntry.TransactionNumber INNER JOIN TransactionEntry ON [Transaction].TransactionNumber = TransactionEntry.TransactionNumber WHERE        [Transaction].BatchNumber = '" & batchnumber & "' and TenderEntry.TenderID=8  "))


    Dim bb1 As Decimal = Decimal.Parse(cmd.getSpecificRecord("SELECT        0 + COALESCE (SUM(DeleteTransactionEntry.POSTECPrice), 0) FROM [DeleteTransaction] INNER JOIN DeleteTenderEntry ON [DeleteTransaction].TransactionNumber = DeleteTenderEntry.TransactionNumber INNER JOIN DeleteTransactionEntry ON [DeleteTransaction].TransactionNumber = DeleteTransactionEntry.TransactionNumber WHERE        [DeleteTransaction].BatchNumber = '" & batchnumber & "'  and DeleteTenderEntry.TenderID=1 "))
    Dim bb2 As Decimal = Decimal.Parse(cmd.getSpecificRecord("SELECT        0 + COALESCE (SUM(DeleteTransactionEntry.POSTECPrice), 0) FROM [DeleteTransaction] INNER JOIN DeleteTenderEntry ON [DeleteTransaction].TransactionNumber = DeleteTenderEntry.TransactionNumber INNER JOIN DeleteTransactionEntry ON [DeleteTransaction].TransactionNumber = DeleteTransactionEntry.TransactionNumber WHERE        [DeleteTransaction].BatchNumber = '" & batchnumber & "'  and DeleteTenderEntry.TenderID=2 "))
    Dim netsales As Decimal = Decimal.Parse(cmd.getSpecificRecord("SELECT      Sum( [total]) FROM   [CashierReport]  where [BatchNumber]<='" & batchnumber & "'  "))

    Dim bbt As Decimal = bb1 + bb2



    a11c = Math.Round(a11c, 2)
    a55 = Math.Round(a55, 2)







    Dim a10 As String = "Gross Sales:             " & String.Format("{0:N2}", a11c + bbt + a22c + aA11 + aA111)
    Dim a11 As String = "Less: Discount:          " & String.Format("{0:N2}", a44 + CC44 + CC444)
    Dim a12 As String = "      Return:            " & String.Format("{0:N2}", bbt)
    Dim a13 As String = "Net Sales:               " & String.Format("{0:N2}", a11c + a22c - a44)
    Dim a14 As String = " Cash Sale:         (AMT)" & String.Format("{0:N2}", a11c - f44)
    Dim a15 As String = "                    (QTY)" & String.Format("{0:N3}", N2)
    Dim a16 As String = " Credit Sales:           " & String.Format("{0:N2}", a22c - g44)
    Dim a17 As String = "                    (QTY)" & String.Format("{0:N3}", N3)
    Dim a18 As String = " Credit Card Sales: (AMT)" & String.Format("{0:N2}", aA11 - CC44)
    Dim a19 As String = "                    (QTY)" & String.Format("{0:N3}", N4)
    Dim a20 As String = "  Gift Certificate: (AMT)" & String.Format("{0:N2}", aA111 - CC444)
    Dim a21 As String = "                    (QTY)" & String.Format("{0:N3}", N44)
    Dim a22 As String = "Less: Pay-out :          " & String.Format("{0:N2}", a99)
    Dim a23 As String = "       Safe Drop:        " & String.Format("{0:N2}", a77)
    Dim a24 As String = "           Total:        " & String.Format("{0:N2}", a99 + a77)
    Dim a25 As String = "SHORT/OVER:              " & String.Format("{0:N2}", (a55 - (a11c - f44)) + a99)

    Dim a26 As String = " Z-READING:" & String.Format("{0:N2}", netsales)

    Dim hh As Double = a11c + a22c - a44

    Dim a27 As String = "Cash Drawer Details"
    Dim a28 As String = "Total Vatable Sales:     " & String.Format("{0:N2}", Math.Round(hh / 1.12, 2))
    Dim a29 As String = "Total Non-Vatable Sales: 0.00"
    Dim a30 As String = "Vat Exempts:             0.00"
    Dim a31 As String = "Total Tax:               " & String.Format("{0:N2}", Math.Round(hh - (hh / 1.12), 2))






    TextToPrint &= a10 & Environment.NewLine
    TextToPrint &= a11 & Environment.NewLine
    TextToPrint &= a12 & Environment.NewLine
    TextToPrint &= a13 & Environment.NewLine
    TextToPrint &= a14 & Environment.NewLine
    TextToPrint &= a15 & Environment.NewLine
    TextToPrint &= a16 & Environment.NewLine
    TextToPrint &= a17 & Environment.NewLine
    'TextToPrint &= a18 & Environment.NewLine
    'TextToPrint &= a19 & Environment.NewLine
    'TextToPrint &= a20 & Environment.NewLine
    'TextToPrint &= a21 & Environment.NewLine
    TextToPrint &= "" & Environment.NewLine
    TextToPrint &= a22 & Environment.NewLine
    TextToPrint &= a23 & Environment.NewLine
    TextToPrint &= a24 & Environment.NewLine
    TextToPrint &= "" & Environment.NewLine
    TextToPrint &= a25 & Environment.NewLine
    'TextToPrint &= "" & Environment.NewLine

    'TextToPrint &= a26 & Environment.NewLine

    TextToPrint &= "" & Environment.NewLine



    TextToPrint &= "_____________________________________________" & Environment.NewLine
    'TextToPrint &= a27 & Environment.NewLine
    'TextToPrint &= a28 & Environment.NewLine
    'TextToPrint &= a29 & Environment.NewLine
    'TextToPrint &= a30 & Environment.NewLine
    Dim mprinter As New myPrinter
    mprinter.print(TextToPrint)



  End Sub

End Class

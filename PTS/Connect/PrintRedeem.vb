Public Class PrintRedeem
  Dim cmd As commands
  Dim TextToPrint As String = ""
  Public Sub New()
    cmd = New commands
    SQLConnect.txtserver.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_server", "Value", Nothing).ToString
    SQLConnect.txtdb.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_database", "Value", Nothing).ToString
    SQLConnect.txtuser.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_user", "Value", Nothing).ToString
    SQLConnect.txtpass.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Password", "Value", Nothing).ToString

  End Sub
  Public Sub Header(TransactionID As Integer, customerid As Integer, cashierid As Integer, rePrint As Boolean)

    Dim _TransactionID As Integer = TransactionID
    Dim _customerid As Integer = customerid
    Dim _cashierid As Integer = cashierid
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

    TextToPrint &= "" & Environment.NewLine
    StringToPrint = "PETRA GAS LOYALTY CARD"
    LineLen = StringToPrint.Length
    spcLen = New String(" "c, Math.Round((40 - LineLen) / 2))
    TextToPrint &= spcLen & StringToPrint & Environment.NewLine



    StringToPrint = "REDEMPTION"
    LineLen = StringToPrint.Length
    spcLen = New String(" "c, Math.Round((40 - LineLen) / 2))
    TextToPrint &= spcLen & StringToPrint & Environment.NewLine
    TextToPrint &= "" & Environment.NewLine

    If rePrint = True Then
      StringToPrint = "Re-print"
      LineLen = StringToPrint.Length
      spcLen = New String(" "c, Math.Round((40 - LineLen) / 2))
      TextToPrint &= spcLen & StringToPrint & Environment.NewLine
      TextToPrint &= "" & Environment.NewLine
    End If



    Dim a1 As String = "Transaction No:  " & TransactionID
    Dim a2 As String = "DATE TIME:       " & cmd.getSpecificRecord($"SELECT   CONVERT(varchar,[Datenow],0) FROM   [Point_RedeemTransaction]  where [ID]='{ TransactionID}'  ").ToString

    Dim customerName As String = "Customer:      " & cmd.getSpecificRecord($"SELECT        Customer.LastName +','+Customer.FirstName FROM    Customer   WHERE       id ='{ _customerid}'  ")

    Dim a3 As String = "Cashier:         " & cmd.getSpecificRecord("SELECT [Name] FROM   [Cashier]  where [ID]='" & _cashierid & "'  ")



    TextToPrint &= "" & Environment.NewLine

    TextToPrint &= a1 & Environment.NewLine
    TextToPrint &= a2 & Environment.NewLine
    TextToPrint &= a3 & Environment.NewLine
    TextToPrint &= customerName & Environment.NewLine
    TextToPrint &= "" & Environment.NewLine

  End Sub


  Public Function ItemsToBePrinted(itemid As Integer, t1 As Integer, t2 As Integer, CUstomerid As Integer) As Decimal




    Dim cmdstr As String = ""
    cmdstr += "SELECT        CONVERT(varchar, [Transaction].Time, 0) , TransactionEntry.Quantity "
    cmdstr += "FROM            TransactionEntry INNER JOIN "
    cmdstr += "[Transaction] ON TransactionEntry.TransactionNumber = [Transaction].TransactionNumber INNER JOIN "
    cmdstr += "  Item ON TransactionEntry.ItemID = Item.ID "
    cmdstr += "  where   TransactionEntry.TransactionNumber  in(SELECT TransactionNumber from Point_RedeemTransaction )   and"
    cmdstr += $"  TransactionEntry.TransactionNumber between { t1} and {t2} and [Transaction].customerid={ CUstomerid }  and itemid={itemid} "
    Dim product As String = cmd.getSpecificRecord($"Select  Description FROM item where id={ itemid }").ToString




    Dim dt As New DataTable
    dt = cmd.LoaderData(cmdstr)
    If dt.Rows.Count <> 0 Then
      Dim totalP As Decimal
      TextToPrint &= "==========================================" & Environment.NewLine
      TextToPrint &= product & Environment.NewLine
      TextToPrint &= "==========================================" & Environment.NewLine
      For i As Integer = 0 To dt.Rows.Count - 1
        Dim LF As String = dt.Rows(i).Item(0).ToString
        Dim Point As Decimal = Decimal.Parse(dt.Rows(i).Item(1).ToString)
        totalP += Point
        Dim b1 As Integer
        b1 = 0
        Dim s As String = LF
        For Each c As Char In s
          b1 += 1
        Next
        Dim b11 = 20 - b1

        Dim total As String = " " & LF & Space(b11) & "    " & String.Format("{0:N2}", Point)
        TextToPrint &= total & Environment.NewLine

      Next
      TextToPrint &= "==========================================" & Environment.NewLine
      TextToPrint &= "SUB TOTAL: " + String.Format("{0:N2}", totalP) & Environment.NewLine
      TextToPrint &= "==========================================" & Environment.NewLine
      Return totalP
    Else
      Return 0
    End If



  End Function




  Public Sub printRecord(rePrint As Boolean, RedeemTransactionID As Integer, TransactionNo1 As Integer, TransactionNo2 As Integer, Customerid As Integer, CashierID As Integer)
    Dim _RedeemTransactionID As Integer = RedeemTransactionID
    Dim _TransactionNo1 As Integer = TransactionNo1
    Dim _TransactionNo2 As Integer = TransactionNo2
    Dim _Customerid As Integer = Customerid
    Dim _CashierID As Integer = CashierID

    Header(_RedeemTransactionID, _Customerid, _CashierID, rePrint)
    Dim a1 As Decimal = ItemsToBePrinted(1, _TransactionNo1, _TransactionNo2, _Customerid)
    Dim a2 As Decimal = ItemsToBePrinted(2, _TransactionNo1, _TransactionNo2, _Customerid)
    Dim a3 As Decimal = ItemsToBePrinted(3, _TransactionNo1, _TransactionNo2, _Customerid)
    Dim a4 As Decimal = ItemsToBePrinted(4, _TransactionNo1, _TransactionNo2, _Customerid)

    Dim TOTALPOINT As Decimal = a1 + a2 + a3 + a4
    TextToPrint &= Environment.NewLine

    TextToPrint &= "GRAND TOTAL: " + String.Format("{0:N2}", TOTALPOINT) & Environment.NewLine


    Dim printz As New myPrinter
    printz.print(TextToPrint)
  End Sub
End Class

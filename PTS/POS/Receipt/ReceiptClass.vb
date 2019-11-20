Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class ReceiptClass
  Public receiptItemlist As DataTable
  Dim cmd As commands
  Public Sub New()
    cmd = New commands
    SQLConnect.txtserver.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_server", "Value", Nothing).ToString
    SQLConnect.txtdb.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_database", "Value", Nothing).ToString
    SQLConnect.txtuser.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_user", "Value", Nothing).ToString
    SQLConnect.txtpass.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Password", "Value", Nothing).ToString

  End Sub
  Public Sub GetReceiptDetails(Duplicate As Boolean, Tenderid As Integer, TransactionNumber As Integer)


    Dim TextToPrint As String = ""

    Dim cmdstr As String = "SELECT          LEFT( Item.Description,18), TransactionEntry.Price, TransactionEntry.Quantity, TransactionEntry.POSTECPrice, Item.ItemLookupCode,[TransactionEntry].[Discount],[TransactionEntry].POSTECID FROM            TransactionEntry INNER JOIN  Item ON TransactionEntry.ItemID = Item.ID  WHERE        (TransactionEntry.TransactionNumber ='" & TransactionNumber & "')"

    'cmdstr += "SELECT"
    'cmdstr += "LEFT( Item.Description,18),"
    'cmdstr += "[TransactionEntry].Price, "
    'cmdstr += "[TransactionEntry].Quantity,"
    'cmdstr += "[TransactionEntry].POSTECPrice,"
    'cmdstr += "Item.ItemLookupCode,"
    'cmdstr += "[TransactionEntry].[Discount],"
    'cmdstr += "[TransactionEntry].POSTECID "
    'cmdstr += " FROM"
    'cmdstr += " TransactionEntry INNER JOIN  Item ON TransactionEntry.ItemID = Item.ID"
    'cmdstr += "  WHERE  "
    'cmdstr += "     (TransactionEntry.TransactionNumber ='" & TransactionNumber & "')"


    '                          



    Dim dt As New DataTable
    dt = LoaderData(cmdstr)
    cmdstr = ""











    'Header


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

    If Duplicate = True Then
      StringToPrint = "DUPLICATE"
      LineLen = StringToPrint.Length
      spcLen = New String(" "c, Math.Round((40 - LineLen) / 2))
      TextToPrint &= spcLen & StringToPrint & Environment.NewLine
      TextToPrint &= "" & Environment.NewLine
      TextToPrint &= "" & Environment.NewLine
    End If

    Dim Ornumber As String
    Dim literal As String = cmd.getSpecificRecord("SELECT 0+COALESCE(Max( [Transaction].TranNo),0)+ 100000000 FROM  [Transaction] INNER JOIN  TenderEntry ON[Transaction].TransactionNumber =TenderEntry.TransactionNumber where  TenderEntry.TenderID ='" & Tenderid & "' and [Transaction].TransactionNumber='" & TransactionNumber & "' ")
    Dim substring As String = literal.Substring(1, 8)
    Dim CustomerID As Integer = Integer.Parse(cmd.getSpecificRecord("SELECT        0+COALESCE(Max(  Customer.ID ),0)FROM    [Transaction] INNER JOIN Customer ON [Transaction].CustomerID = Customer.ID  WHERE        [Transaction].TransactionNumber ='" & TransactionNumber & "'  "))

    Dim datetime As String = "DATE TIME:     " & cmd.getSpecificRecord("SELECT  Time FROM   [Transaction]  where [TransactionNumber]='" & TransactionNumber & "'  ")
    Dim cashier As String = "Cashier:       " & cmd.getSpecificRecord("SELECT        Cashier.Name FROM    Cashier INNER JOIN [Transaction] ON Cashier.ID = [Transaction].CashierID WHERE        [Transaction].TransactionNumber = '" & TransactionNumber & "'  ")
    Dim PlateNumber As String = "Plate Number:  " & cmd.getSpecificRecord("SELECT PlateNumber  FROM    [Transaction]  WHERE       TransactionNumber ='" & TransactionNumber & "'  ")
    Dim customerName As String = ""
    Dim z1 As String = cmd.getSpecificRecord("SELECT Note  FROM    [Transaction]  WHERE       TransactionNumber ='" & TransactionNumber & "'  ")

    If z1 = "" Then

      If CustomerID <> 0 Then
        customerName = "Customer:      " & cmd.getSpecificRecord("SELECT        Customer.LastName +','+Customer.FirstName FROM    [Transaction] INNER JOIN Customer ON [Transaction].CustomerID = Customer.ID  WHERE        [Transaction].TransactionNumber ='" & TransactionNumber & "'  ")
      Else
        customerName = "Customer:      " & "Walk-in"
      End If
    Else
      customerName = "Customer:      " & z1
    End If





    Select Case Tenderid
      Case 1
        StringToPrint = "CASH"
        LineLen = StringToPrint.Length
        spcLen = New String(" "c, Math.Round((40 - LineLen) / 2))
        TextToPrint &= spcLen & StringToPrint & Environment.NewLine
        Ornumber = "Transaction #:" & substring
        TextToPrint &= Ornumber & Environment.NewLine
        TextToPrint &= datetime & Environment.NewLine
        TextToPrint &= cashier & Environment.NewLine
        TextToPrint &= PlateNumber & Environment.NewLine
        TextToPrint &= customerName & Environment.NewLine




      Case 2

        StringToPrint = "CREDIT"
        LineLen = StringToPrint.Length
        spcLen = New String(" "c, Math.Round((40 - LineLen) / 2))
        TextToPrint &= spcLen & StringToPrint & Environment.NewLine
        Ornumber = "Transaction #:" & substring
        customerName = "Driver      :  " & cmd.getSpecificRecord("SELECT note  FROM    [Transaction]  WHERE       TransactionNumber ='" & TransactionNumber & "'  ")

        TextToPrint &= Ornumber & Environment.NewLine
        TextToPrint &= datetime & Environment.NewLine
        TextToPrint &= cashier & Environment.NewLine
        TextToPrint &= PlateNumber & Environment.NewLine
        TextToPrint &= customerName & Environment.NewLine




      Case 3
        Ornumber = "Transaction #:" & substring
        StringToPrint = "Calibration"
        LineLen = StringToPrint.Length
        spcLen = New String(" "c, Math.Round((40 - LineLen) / 2))
        TextToPrint &= spcLen & StringToPrint & Environment.NewLine
        customerName = "Comment:      " & z1
        TextToPrint &= Ornumber & Environment.NewLine
        TextToPrint &= datetime & Environment.NewLine
        TextToPrint &= cashier & Environment.NewLine
        TextToPrint &= PlateNumber & Environment.NewLine
        TextToPrint &= customerName & Environment.NewLine

    End Select
















    'Item

    TextToPrint &= "Description             " & "Amount      "
    TextToPrint &= "" & Environment.NewLine
    TextToPrint &= "===========================" & "===========" & Environment.NewLine



    For i As Integer = 0 To dt.Rows.Count - 1

      Dim Description As String = dt.Rows(i).Item(0).ToString
      Dim Price As Decimal = Decimal.Parse(dt.Rows(i).Item(1).ToString)
      Dim Quantity As Decimal = Decimal.Parse(dt.Rows(i).Item(2).ToString)
      Dim POSTECPrice As Decimal = Decimal.Parse(dt.Rows(i).Item(3).ToString)
      Dim ItemLookupCode As String = dt.Rows(i).Item(4).ToString
      Dim Discount As Decimal = Decimal.Parse(dt.Rows(i).Item(5).ToString)
      Dim POSTECID As Integer = Integer.Parse(dt.Rows(i).Item(6).ToString)

      Dim Description1 As String = Description

      If POSTECID <> 0 Then
        Description1 = $"({POSTECID})" + Description1
      End If

      Dim Description11 As Integer
      Description11 = 0
      Dim s As String = Description1
      For Each c As Char In s
        Description11 += 1
      Next
      Dim a111 = 24 - Description11


      Dim Quantity1 As Integer
      Quantity1 = 0

      Dim s2 As String = String.Format("{0:N3}", Quantity)
      For Each c As Char In s2
        Quantity1 += 1
      Next
      Dim a333 = 8 - Quantity1



      Dim Money As String = String.Format("{0:N2}", (POSTECPrice - Discount))

      Dim str1 As String = Description1 & Space(a111) & Money
      Dim str2 As String = Quantity & "L" & Space(a333) & "@ Php" & String.Format("{0:N2}", Price)


      Dim aaa As String
      If Discount = 0 Then
        TextToPrint &= str1 & Environment.NewLine
        TextToPrint &= str2 & Environment.NewLine
      Else
        If Discount <= -0.001 Then
          aaa = " P(" & Discount * -1 & ")"
        Else
          aaa = " D(" & Discount & ")"
        End If
        Dim str3 As String = "T(" & POSTECPrice & ")" & aaa
        TextToPrint &= str1 & Environment.NewLine
        TextToPrint &= str2 & Environment.NewLine
        TextToPrint &= str3 & Environment.NewLine

      End If

    Next
    TextToPrint &= "===========================" & "===========" & Environment.NewLine

    Dim a66 As Double = Decimal.Parse(cmd.getSpecificRecord("SELECT    0+COALESCE(( [Total]),0) FROM   [Transaction] where [TransactionNumber]='" & TransactionNumber & "'  ").ToString)
    a66 = Math.Round(a66, 2)
    Dim total As String = "           " & "        Total" & " " & String.Format("{0:N2}", a66)

    TextToPrint &= total & Environment.NewLine
    TextToPrint &= "" & Environment.NewLine

    Dim a11 As Double = Decimal.Parse(cmd.getSpecificRecord("SELECT   0+COALESCE(  [Vatable],0) FROM   [Transaction] where [TransactionNumber]='" & TransactionNumber & "'  ").ToString)
    Dim a22 As Double = Decimal.Parse(cmd.getSpecificRecord("SELECT    0+COALESCE( [NonVat] ,0) FROM   [Transaction] where [TransactionNumber]='" & TransactionNumber & "'  ").ToString)
    Dim a33 As Double = Decimal.Parse(cmd.getSpecificRecord("SELECT  0+COALESCE(   [TaxExempt],0) FROM   [Transaction]  where [TransactionNumber]='" & TransactionNumber & "'  ").ToString)
    Dim a44 As Double = Decimal.Parse(cmd.getSpecificRecord("SELECT     0+COALESCE([SalesTax],0) FROM   [Transaction]  where [TransactionNumber]='" & TransactionNumber & "'  ").ToString)
    Dim a55 As Double = Decimal.Parse(cmd.getSpecificRecord("SELECT   0+COALESCE(  [Discount] ,0) FROM   [Transaction] where [TransactionNumber]='" & TransactionNumber & "'  ").ToString)

    Dim a77 As Double = Decimal.Parse(cmd.getSpecificRecord("SELECT    0+COALESCE( [TenderChange],0) FROM   [TenderEntry] where [TransactionNumber]='" & TransactionNumber & "'  ").ToString)
    Dim a88 As Double = Decimal.Parse(cmd.getSpecificRecord("SELECT    0+COALESCE( [TenderAmount],0) FROM   [TenderEntry] where [TransactionNumber]='" & TransactionNumber & "'  ").ToString)

    Dim tpoint As Double = Decimal.Parse(cmd.getSpecificRecord("SELECT   0+COALESCE(  [CustomNumber1],0) FROM   [Transaction] where [TransactionNumber]='" & TransactionNumber & "'  "))
    Dim point As Double = Decimal.Parse(cmd.getSpecificRecord("SELECT 0+COALESCE(max([LoyalPoint]) ,0)       FROM [Point_Transaction]  where  [TransactionNumber] ='" & TransactionNumber & "'  ").ToString)

    tpoint = Math.Round(tpoint, 2)
    point = Math.Round(point, 2)












    a11 = Math.Round(a11, 2)
    a22 = Math.Round(a22, 2)
    a33 = Math.Round(a33, 2)
    a44 = Math.Round(a44, 2)
    a55 = Math.Round(a55, 2)
    a77 = Math.Round(a77, 2)
    a88 = Math.Round(a88, 2)




    Dim pointzzzz As Integer = Integer.Parse(cmd.getSpecificRecord("SELECT   0+COALESCE([PointStatus],0) FROM [Transaction]  where [TransactionNumber]= '" & TransactionNumber & "'"))




    Dim a1 As String = "      VATable Sales:  " & String.Format("{0:N2}", a11)
    Dim a2 As String = "   Zero-Rated Sales:  " & String.Format("{0:N2}", a22)
    Dim a3 As String = "   VAT Exempt Sales:  " & String.Format("{0:N2}", a33)
    Dim a4 As String = "         VAT Amount:  " & String.Format("{0:N2}", a44)


    Dim a5 As String = "           Discount:  " & String.Format("{0:N2}", a55)
    If a55 <= -0.001 Then
      a5 = "               PLUS:  " & String.Format("{0:N2}", a55 * -1)
    Else
      a5 = "           Discount:  " & String.Format("{0:N2}", a55)
    End If


    Dim a6 As String = "     Tendered Total:  " & String.Format("{0:N2}", a66)
    Dim a7 As String = "      Cash Tendered:  " & String.Format("{0:N2}", a77 + a88)
    Dim a8 As String = "         Change Due:  " & String.Format("{0:N2}", a77)

    Dim ab1 As String = " Earn Loyalty Point:  " & String.Format("{0:N2}", point)

    Dim ab3 As String = "Total Loyalty Point:  " & String.Format("{0:N2}", tpoint)








    Select Case Tenderid
      Case 1

        'TextToPrint &= a1 & Environment.NewLine
        'TextToPrint &= a2 & Environment.NewLine
        'TextToPrint &= a3 & Environment.NewLine
        'TextToPrint &= a4 & Environment.NewLine
        TextToPrint &= a5 & Environment.NewLine
        TextToPrint &= a6 & Environment.NewLine
        TextToPrint &= "" & Environment.NewLine
        TextToPrint &= a7 & Environment.NewLine
        TextToPrint &= a8 & Environment.NewLine
        TextToPrint &= "" & Environment.NewLine
        If pointzzzz = 1 Then
          TextToPrint &= ab1 & Environment.NewLine

          TextToPrint &= ab3 & Environment.NewLine
        End If




        TextToPrint &= "" & Environment.NewLine
        StringToPrint = "Thank You"
        LineLen = StringToPrint.Length
        spcLen = New String(" "c, Math.Round((40 - LineLen) / 2))
        TextToPrint &= spcLen & StringToPrint & Environment.NewLine


        TextToPrint &= "" & Environment.NewLine
        StringToPrint = cmd.getSpecificRecord("SELECT  StoreName FROM   Configuration   ")
        LineLen = StringToPrint.Length
        spcLen = New String(" "c, Math.Round((40 - LineLen) / 2))
        TextToPrint &= spcLen & StringToPrint & Environment.NewLine





      Case 2
        TextToPrint &= a1 & Environment.NewLine
        TextToPrint &= a2 & Environment.NewLine
        TextToPrint &= a3 & Environment.NewLine
        TextToPrint &= a4 & Environment.NewLine
        TextToPrint &= a5 & Environment.NewLine
        TextToPrint &= a6 & Environment.NewLine
        TextToPrint &= "" & Environment.NewLine
        If pointzzzz = 1 Then
          TextToPrint &= ab1 & Environment.NewLine

          TextToPrint &= ab3 & Environment.NewLine
        End If

        TextToPrint &= "" & Environment.NewLine
        StringToPrint = "Thank You"
        LineLen = StringToPrint.Length
        spcLen = New String(" "c, Math.Round((40 - LineLen) / 2))
        TextToPrint &= spcLen & StringToPrint & Environment.NewLine


        TextToPrint &= "" & Environment.NewLine
        StringToPrint = cmd.getSpecificRecord("SELECT  StoreName FROM   Configuration   ")
        LineLen = StringToPrint.Length
        spcLen = New String(" "c, Math.Round((40 - LineLen) / 2))
        TextToPrint &= spcLen & StringToPrint & Environment.NewLine







        Dim name As String = cmd.getSpecificRecord("SELECT        Customer.LastName +','+Customer.FirstName FROM    [Transaction] INNER JOIN Customer ON [Transaction].CustomerID = Customer.ID  WHERE        [Transaction].TransactionNumber ='" & TransactionNumber & "'  ")


        StringToPrint = name
        LineLen = StringToPrint.Length
        spcLen = New String(" "c, Math.Round((40 - LineLen) / 2))
        TextToPrint &= spcLen & StringToPrint & Environment.NewLine


        TextToPrint &= "" & Environment.NewLine
        TextToPrint &= "" & Environment.NewLine

        TextToPrint &= "x________________________________________" & Environment.NewLine
        TextToPrint &= "SIGNATURE OVER PRINTED NAME" & Environment.NewLine
        'TextToPrint &= "I AGREE TO PAY ABOVE TOTAL AMOUNT" & Environment.NewLine
        'TextToPrint &= "ACCORDING TO CARD ISSUER AGREEMENT" & Environment.NewLine
        TextToPrint &= "" & Environment.NewLine




    End Select



    Dim mprinter As New myPrinter
    mprinter.print(TextToPrint)


  End Sub



  Private Function LoaderData(ByVal strSql As String) As DataTable
    Dim cnn As SqlConnection
    Dim dad As SqlDataAdapter

    Dim dtb As New DataTable



    Dim server = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_server", "Value", Nothing).ToString
    Dim database = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_database", "Value", Nothing).ToString
    Dim User = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_user", "Value", Nothing).ToString
    Dim Password = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Password", "Value", Nothing).ToString




    cnn = New SqlConnection("Data Source='" & server & "';Initial Catalog='" & database & "';Persist Security Info=True;User ID='" & User & "';Password='" & Password & "'")
      Try
      cnn.Open()
      dad = New SqlDataAdapter(strSql, cnn)
      dad.Fill(dtb)
      cnn.Close()
      dad.Dispose()
    Catch ex As Exception
      cnn.Close()
      MsgBox(ex.Message)
    End Try
    Return dtb
  End Function





End Class

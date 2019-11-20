Imports System
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Windows.Forms


Public Class frmprint2
    Dim batch = 0
    Public TransactionNo = 0
    Dim cmd As New commands
    Dim TextToPrint As String = ""

    Private Sub frmprint1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    PrintDocument1.PrinterSettings.PrinterName = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Printerset", "Value", Nothing).ToString
    SQLConnect.txtserver.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_server", "Value", Nothing).ToString
    SQLConnect.txtdb.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_database", "Value", Nothing).ToString
    SQLConnect.txtuser.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_user", "Value", Nothing).ToString
    SQLConnect.txtpass.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Password", "Value", Nothing).ToString
    rec()
    End Sub



    Public Sub rec()


        '  cmd.SelectRecord("SELECT         LEFT( Item.Description,11), Item.Price, TransactionEntry.Quantity, Item.Price * TransactionEntry.Quantity AS Total FROM            TransactionEntry INNER JOIN  Item ON TransactionEntry.ItemID = Item.ID WHERE        (TransactionEntry.TransactionNumber ='" & TransactionNo & "')", "TransactionEntry", Me.DataGridView1)
        ' cmd.SelectRecord("SELECT          LEFT( Item.Description,8), Item.Price, TransactionEntry.Quantity, TransactionEntry.POSTECPrice, Item.ItemLookupCode FROM            TransactionEntry INNER JOIN  Item ON TransactionEntry.ItemID = Item.ID  WHERE        (TransactionEntry.TransactionNumber ='" & TransactionNo & "')", "TransactionEntry", Me.DataGridView1)



    End Sub

    Public Sub PrintHeader()
        On Error Resume Next
        TextToPrint = ""
        'send Business Name
        Dim StringToPrint As String = "  "
        Dim LineLen As Integer = StringToPrint.Length
        Dim spcLen9 As New String(" "c, Math.Round((40 - LineLen) / 2)) 'This line is used to center text in the middle of the receipt
        TextToPrint &= spcLen9 & StringToPrint & Environment.NewLine
        TextToPrint &= "" & Environment.NewLine
        'send Business Name


        StringToPrint = cmd.getSpecificRecord("SELECT  StoreName FROM   Configuration   ")
        LineLen = StringToPrint.Length
        Dim spcLen1 As New String(" "c, Math.Round((40 - LineLen) / 2)) 'This line is used to center text in the middle of the receipt
        TextToPrint &= spcLen1 & StringToPrint & Environment.NewLine

        'send address name
        StringToPrint = cmd.getSpecificRecord("SELECT  StoreAddress1 FROM   Configuration   ")
        LineLen = StringToPrint.Length
        Dim spcLen2 As New String(" "c, Math.Round((40 - LineLen) / 2))
        TextToPrint &= spcLen2 & StringToPrint & Environment.NewLine


        '' send phone number
        'StringToPrint = cmd.getSpecificRecord("SELECT  VATRegistrationNumber FROM   Configuration   ")
        'LineLen = StringToPrint.Length
        'Dim spcLen4 As New String(" "c, Math.Round((40 - LineLen) / 2))
        'TextToPrint &= spcLen4 & StringToPrint & Environment.NewLine



        'StringToPrint = cmd.getSpecificRecord("SELECT  Heading FROM   Headfoot   ")
        'LineLen = StringToPrint.Length
        'Dim spcLen5 As New String(" "c, Math.Round((40 - LineLen) / 2))
        'TextToPrint &= spcLen5 & StringToPrint & Environment.NewLine

        'StringToPrint = cmd.getSpecificRecord("SELECT  Heading2 FROM   Headfoot   ")
        'LineLen = StringToPrint.Length
        'Dim spcLen6 As New String(" "c, Math.Round((40 - LineLen) / 2))
        'TextToPrint &= spcLen6 & StringToPrint & Environment.NewLine


        'StringToPrint = cmd.getSpecificRecord("SELECT  Heading3 FROM   Headfoot   ")
        'LineLen = StringToPrint.Length
        'Dim spcLen7 As New String(" "c, Math.Round((40 - LineLen) / 2))
        'TextToPrint &= spcLen7 & StringToPrint & Environment.NewLine
        'TextToPrint &= "" & Environment.NewLine
        'TextToPrint &= "" & Environment.NewLine


        'StringToPrint = "DUPLICATE"
        'LineLen = StringToPrint.Length
        'Dim spcLen8 As New String(" "c, Math.Round((40 - LineLen) / 2))
        'TextToPrint &= spcLen8 & StringToPrint & Environment.NewLine


        ' Dim a16 = cmd.getSpecificRecord("SELECT[TenderID]  FROM [TenderEntry]  where [TransactionNumber]= '" & TransactionNo & "'")


        StringToPrint = "PERDIDO POINT"

        LineLen = StringToPrint.Length
        Dim spcLen4c As New String(" "c, Math.Round((40 - LineLen) / 2))
        TextToPrint &= spcLen4c & StringToPrint & Environment.NewLine



        'Dim a1 As String = "Transaction No:  " & cmd.getSpecificRecord("SELECT       0+COALESCE(Max( [ID]),0) FROM  [Point_RedeemTransaction] ")
        'Dim a2 As String = "DATE TIME:       " & cmd.getSpecificRecord("SELECT  [Datenow] FROM   [Point_Transaction]  where [ID]='" & TransactionNo & "'  ")
        'Dim a3 As String = "Cashier:         " & cmd.getSpecificRecord("SELECT [Name] FROM   [Cashier]  where [ID]='" & MAIN.txtuser.Text & "'  ")
        Dim a4 As String = "Customer:        " & frmRedeem.txtname.Text


        TextToPrint &= a4 & Environment.NewLine
        TextToPrint &= "" & Environment.NewLine



    End Sub
    Public Sub ItemsToBePrinted()

        'On Error Resume Next


        'TextToPrint &= "==========================================" & Environment.NewLine
        'TextToPrint &= "Description" & Environment.NewLine
        'TextToPrint &= "Description" & " " & "Price    " & " " & "QTY      " & " " & "Total      "
        'TextToPrint &= "Description  " & " " & "Price    " & " " & "QTY      " & " " & "Total      "
        'TextToPrint &= "" & Environment.NewLine

        'Dim count = DataGridView1.RowCount
        'Dim a = 0


        'do loop execution 


        '    Do

        '        Dim a1 = DataGridView1.Item(0, a).Value
        '        Dim a2 As Double = Math.Round(DataGridView1.Item(1, a).Value, 2)
        '        Dim a3 As Double = Math.Round(DataGridView1.Item(2, a).Value, 2)
        '        Dim a4 As Double = Math.Round(DataGridView1.Item(3, a).Value, 2)
        '        Dim a5 = DataGridView1.Item(4, a).Value


        '        Dim a6 = cmd.getSpecificRecord("SELECT       [Dispenser] FROM [PumpTransactions] where [Grade]='" & a5 & "' and [TransNum]='" & TransactionNo & "'")
        '        Dim a7 = "(" & a6 & ")" & a1


        '        Dim a11 As Integer
        '        a11 = 0
        '        Dim s As String = a7
        '        For Each c As Char In s
        '            a11 += 1
        '        Next
        '        Dim a111 = 12 - a11


        '        Dim a22 As Integer
        '        a22 = 0

        '        Dim s1 As String = a2
        '        For Each c As Char In s1
        '            a22 += 1
        '        Next
        '        Dim a222 = 9 - a22


        '        Dim a33 As Integer
        '        a33 = 0

        '        Dim s2 As String = a3
        '        For Each c As Char In s2
        '            a33 += 1
        '        Next
        '        Dim a333 = 9 - a33


        '        Dim a44 As Integer
        '        a44 = 0

        '        Dim s3 As String = a4
        '        For Each c As Char In s3
        '            a44 += 1
        '        Next
        '        Dim a444 = 9 - a44

        '        Dim total As String = " " & a7 & Space(a111) & " " & a2 & Space(a222) & " " & a3 & Space(a333) & " " & a4 & Space(a444)
        '        TextToPrint &= total & Environment.NewLine



        '        a = a + 1


        '    Loop While (a < count)
        '    TextToPrint &= "==========================================" & Environment.NewLine
        '    Dim StrExport As String = ""
        '    For Each C As DataGridViewColumn In DataGridView1.Columns
        '        StrExport &= "" & C.HeaderText & ","
        '    Next
        '    StrExport = StrExport.Substring(0, StrExport.Length - 1)
        '    StrExport &= Environment.NewLine

        '    For Each R As DataGridViewRow In DataGridView1.Rows
        '        For Each C As DataGridViewCell In R.Cells
        '        If Not C.Value Is Nothing Then
        '            StrExport &= "" & C.Value.ToString & ","
        '        Else
        '            StrExport &= "" & "" & ","
        '        End If
        '    Next



        '    StrExport = StrExport.Substring(0, StrExport.Length - 1)
        '    StrExport &= Environment.NewLine

        'Next
        'TextToPrint &= StrExport & Environment.NewLine
    End Sub
    Public Sub printFooter()



        'Dim a66 As Double = cmd.getSpecificRecord("SELECT    0+COALESCE( [Total],0) FROM   [Transaction] where [TransactionNumber]='" & TransactionNo & "'  ")

        'a66 = Math.Round(a66, 2)


        'Dim total As String = "               " & "             Total" & " " & String.Format("{0:N2}", a66)

        'TextToPrint &= total & Environment.NewLine
        'TextToPrint &= "" & Environment.NewLine
        'Dim a11 As Double = cmd.getSpecificRecord("SELECT   0+COALESCE(  [Vatable],0) FROM   [Transaction] where [TransactionNumber]='" & TransactionNo & "'  ")
        'Dim a22 As Double = cmd.getSpecificRecord("SELECT    0+COALESCE( [NonVat] ,0) FROM   [Transaction] where [TransactionNumber]='" & TransactionNo & "'  ")
        'Dim a33 As Double = cmd.getSpecificRecord("SELECT  0+COALESCE(   [TaxExempt],0) FROM   [Transaction]  where [TransactionNumber]='" & TransactionNo & "'  ")
        'Dim a44 As Double = cmd.getSpecificRecord("SELECT     0+COALESCE([SalesTax],0) FROM   [Transaction]  where [TransactionNumber]='" & TransactionNo & "'  ")
        'Dim a55 As Double = cmd.getSpecificRecord("SELECT   0+COALESCE(  [Discount] ,0) FROM   [Transaction] where [TransactionNumber]='" & TransactionNo & "'  ")

        'Dim a77 As Double = cmd.getSpecificRecord("SELECT    0+COALESCE( [TenderChange],0) FROM   [TenderEntry] where [TransactionNumber]='" & TransactionNo & "'  ")
        'Dim a88 As Double = cmd.getSpecificRecord("SELECT    0+COALESCE( [TenderAmount],0) FROM   [TenderEntry] where [TransactionNumber]='" & TransactionNo & "'  ")



        On Error Resume Next


        Dim tpoint As Double = cmd.getSpecificRecord("SELECT        0+COALESCE( Customer.CustomNumber1,0) FROM    [Transaction] INNER JOIN Customer ON [Transaction].CustomerID = Customer.ID  WHERE        [Transaction].TransactionNumber ='" & TransactionNo & "'  ")
        Dim trebate As Double = cmd.getSpecificRecord("SELECT       0+COALESCE(  Customer.CustomNumber2,0) FROM    [Transaction] INNER JOIN Customer ON [Transaction].CustomerID = Customer.ID  WHERE        [Transaction].TransactionNumber ='" & TransactionNo & "'  ")



        Dim point As Double = cmd.getSpecificRecord("SELECT  0+COALESCE([LoyalPoint] ,0)         FROM [Point_Transaction]  where  [TransactionNumber] ='" & TransactionNo & "'  ")
        Dim rebate As Double = cmd.getSpecificRecord("SELECT  0+COALESCE([RebatesPoint] ,0)     FROM [Point_Transaction]  where  [TransactionNumber] ='" & TransactionNo & "'  ")

        tpoint = Math.Round(tpoint, 2)
        trebate = Math.Round(trebate, 2)

        point = Math.Round(point, 2)
        rebate = Math.Round(rebate, 2)











        'a11 = Math.Round(a11, 2)

        'a22 = Math.Round(a22, 2)

        'a33 = Math.Round(a33, 2)

        'a44 = Math.Round(a44, 2)

        'a55 = Math.Round(a55, 2)


        'a77 = Math.Round(a77, 2)
        'a88 = Math.Round(a88, 2)


        'Dim codez = cmd.getSpecificRecord("Select  0+COALESCE(Max(ID),0) FROM Point_Setting where code='" & frmRedeem.txtcode.Text & "'")
        'Dim pointa = cmd.getSpecificRecord("SELECT [customnumber1] FROM [Customer]  where ID='" & codez & "'")




        'Dim a1 As String = "Redeemed Item:  " & 1 & " " & frmRedeem.ComboBox1.Text
        ''Dim a2 As String = "   Zero-Rated Sales:  " & String.Format("{0:N2}", a22)
        ''Dim a3 As String = "   VAT Exempt Sales:  " & String.Format("{0:N2}", a33)
        ''Dim a4 As String = "         VAT Amount:  " & String.Format("{0:N2}", a44)
        ''Dim a5 As String = "           Discount:  " & String.Format("{0:N2}", a55)

        ''Dim a6 As String = "              Total:  " & String.Format("{0:N2}", a66.)
        ''Dim a7 As String = "      Cash Tendered:  " & String.Format("{0:N2}", a77 + a88)
        ''Dim a8 As String = "         Change Due:  " & String.Format("{0:N2}", a77)

        'Dim ab1 As String = "Redeemed Loyalty Point/s:  " & String.Format("{0:N2}", Double.Parse(frmRedeem.txtpointR.Text))
        '' Dim ab2 As String = "  Earn Rebate Point:  " & String.Format("{0:N2}", rebate)
        Dim ab3 As String = "Total Loyalty Point:  " & String.Format("{0:N2}", Double.Parse(frmRedeem.lbpoint.Text))
        ' Dim ab4 As String = " Total Rebate Point:  " & String.Format("{0:N2}", trebate)



        'TextToPrint &= a1 & Environment.NewLine

        ''TextToPrint &= a2 & Environment.NewLine
        ''TextToPrint &= a3 & Environment.NewLine
        ''TextToPrint &= a4 & Environment.NewLine
        ''TextToPrint &= a5 & Environment.NewLine
        ''TextToPrint &= a6 & Environment.NewLine
        ''TextToPrint &= "" & Environment.NewLine
        ''TextToPrint &= a7 & Environment.NewLine
        ''TextToPrint &= a8 & Environment.NewLine
        ''TextToPrint &= "" & Environment.NewLine
        'TextToPrint &= ab1 & Environment.NewLine
        'TextToPrint &= ab2 & Environment.NewLine

        TextToPrint &= ab3 & Environment.NewLine
        'TextToPrint &= ab4 & Environment.NewLine
        'TextToPrint &= "" & Environment.NewLine
        'TextToPrint &= "" & Environment.NewLine
        'On Error Resume Next
        'Dim StringToPrint As String = "Thank You"
        'Dim LineLen As Integer = StringToPrint.Length
        'Dim spcLen1 As New String(" "c, Math.Round((40 - LineLen) / 2))
        'TextToPrint &= spcLen1 & StringToPrint & Environment.NewLine
        'TextToPrint &= "" & Environment.NewLine





        'StringToPrint = cmd.getSpecificRecord("SELECT  StoreName FROM   Configuration   ")
        'LineLen = StringToPrint.Length
        'Dim spcLen2 As New String(" "c, Math.Round((40 - LineLen) / 2))
        'TextToPrint &= spcLen2 & StringToPrint & Environment.NewLine
        'TextToPrint &= "" & Environment.NewLine




        'StringToPrint = "THIS RECEIPTS SHALL BE VALID FOR"
        'LineLen = StringToPrint.Length
        'Dim spcLen3 As New String(" "c, Math.Round((40 - LineLen) / 2))
        'TextToPrint &= spcLen3 & StringToPrint & Environment.NewLine



        'StringToPrint = "FIVE (5) YEARS FROM THE DATE"
        'LineLen = StringToPrint.Length
        'Dim spcLen4 As New String(" "c, Math.Round((40 - LineLen) / 2))
        'TextToPrint &= spcLen4 & StringToPrint & Environment.NewLine



        'StringToPrint = "OF THE PERMIT USE."
        'LineLen = StringToPrint.Length
        'Dim spcLen5 As New String(" "c, Math.Round((40 - LineLen) / 2))
        'TextToPrint &= spcLen5 & StringToPrint & Environment.NewLine


        'StringToPrint = cmd.getSpecificRecord("SELECT  footer FROM   Headfoot   ")
        'LineLen = StringToPrint.Length
        'Dim spcLen6 As New String(" "c, Math.Round((40 - LineLen) / 2))
        'TextToPrint &= spcLen6 & StringToPrint & Environment.NewLine
        'TextToPrint &= "" & Environment.NewLine
        'TextToPrint &= "" & Environment.NewLine

        'StringToPrint = "NAME: _______________________"
        'LineLen = StringToPrint.Length
        'Dim spcLen7 As New String(" "c, Math.Round((40 - LineLen) / 2))
        'TextToPrint &= spcLen7 & StringToPrint & Environment.NewLine


        'StringToPrint = "ADRESS: _____________________"
        'LineLen = StringToPrint.Length
        'Dim spcLen8 As New String(" "c, Math.Round((40 - LineLen) / 2))
        'TextToPrint &= spcLen8 & StringToPrint & Environment.NewLine


        'StringToPrint = "TIN: ________________________"
        'LineLen = StringToPrint.Length
        'Dim spcLen9 As New String(" "c, Math.Round((40 - LineLen) / 2))
        'TextToPrint &= spcLen9 & StringToPrint & Environment.NewLine



        'StringToPrint = "SIGNATURE: _________________"
        'LineLen = StringToPrint.Length
        'Dim spcLen10 As New String(" "c, Math.Round((40 - LineLen) / 2))
        'TextToPrint &= spcLen10 & StringToPrint & Environment.NewLine
        'TextToPrint &= "" & Environment.NewLine
        'TextToPrint &= "" & Environment.NewLine



        'StringToPrint = cmd.getSpecificRecord("SELECT  footer2 FROM   Headfoot   ")
        'LineLen = StringToPrint.Length
        'Dim spcLen11 As New String(" "c, Math.Round((40 - LineLen) / 2))
        'TextToPrint &= spcLen11 & StringToPrint & Environment.NewLine


        'StringToPrint = cmd.getSpecificRecord("SELECT  footer3 FROM   Headfoot   ")
        'LineLen = StringToPrint.Length
        'Dim spcLen12 As New String(" "c, Math.Round((40 - LineLen) / 2))
        'TextToPrint &= spcLen12 & StringToPrint & Environment.NewLine



        'StringToPrint = cmd.getSpecificRecord("SELECT  footer4 FROM   Headfoot   ")
        'LineLen = StringToPrint.Length
        'Dim spcLen13 As New String(" "c, Math.Round((40 - LineLen) / 2))
        'TextToPrint &= spcLen13 & StringToPrint & Environment.NewLine


        '= cmd.getSpecificRecord("SELECT  Heading3 FROM   Headfoot   ")

    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Static currentChar As Integer
        Dim textfont As Font = New Font("Consolas", 9, FontStyle.Bold)

        Dim h, w As Integer
        Dim left, top As Integer
        With PrintDocument1.DefaultPageSettings
            h = 0
            w = 0
            left = 0
            top = 0
        End With


        Dim lines As Integer = CInt(Math.Round(h / 1))
        Dim b As New Rectangle(left, top, w, h)
        Dim format As StringFormat
        format = New StringFormat(StringFormatFlags.LineLimit)
        Dim line, chars As Integer



        e.Graphics.MeasureString(Mid(TextToPrint, currentChar + 1), textfont, New SizeF(w, h), format, chars, line)
        e.Graphics.DrawString(TextToPrint.Substring(currentChar, chars), New Font("Consolas", 9, FontStyle.Regular), Brushes.Black, b, format)



        currentChar = currentChar + chars
        If currentChar < TextToPrint.Length Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
            currentChar = 0
        End If


    End Sub
    Private Sub yes_Click(sender As Object, e As EventArgs) Handles yes.Click
        PrintHeader()

        ItemsToBePrinted()
        printFooter()
        Dim printControl = New Printing.StandardPrintController
        PrintDocument1.PrintController = printControl
        Try
            PrintDocument1.Print()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'If Addpoint.counter = 1 Then
        '    Addpoint.message2()
        'End If
        frmRedeem.recon()

        frmRedeem.Enabled = True
        '  cmd.Update("UPDATE [Transaction] SET      repstatus = '1' WHERE    TransactionNumber = '" & TransactionNo & "'")
        Me.Close()
    End Sub

    Private Sub no_Click(sender As Object, e As EventArgs) Handles no.Click
        'If Addpoint.counter = 1 Then
        '    Addpoint.message2()
        'End If


        frmRedeem.recon()
        frmRedeem.Enabled = True
        Me.Close()
    End Sub
End Class
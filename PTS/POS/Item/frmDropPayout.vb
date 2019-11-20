Imports System
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Windows.Forms
Public Class frmDropPayout
    Public TransactionNo = 0
    Dim cmd As New commands
    Dim TextToPrint As String = ""


    Private Sub frmDropPayout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    PrintDocument1.PrinterSettings.PrinterName = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Printerset", "Value", Nothing).ToString

    SQLConnect.txtserver.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_server", "Value", Nothing).ToString
    SQLConnect.txtdb.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_database", "Value", Nothing).ToString
    SQLConnect.txtuser.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_user", "Value", Nothing).ToString
    SQLConnect.txtpass.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Password", "Value", Nothing).ToString

    ' batch = cmd.getSpecificRecord("SELECT  0+COALESCE(Max([BatchNumber]),0)  FROM [Batch]  ")
    TransactionNo = cmd.getSpecificRecord("SELECT  0+COALESCE(Max(ID),0)  FROM DropPayout  ")

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


        ' send phone number
        StringToPrint = cmd.getSpecificRecord("SELECT  VATRegistrationNumber FROM   Configuration   ")
        LineLen = StringToPrint.Length
        Dim spcLen4 As New String(" "c, Math.Round((40 - LineLen) / 2))
        TextToPrint &= spcLen4 & StringToPrint & Environment.NewLine



        StringToPrint = cmd.getSpecificRecord("SELECT  Heading FROM   Headfoot   ")
        LineLen = StringToPrint.Length
        Dim spcLen5 As New String(" "c, Math.Round((40 - LineLen) / 2))
        TextToPrint &= spcLen5 & StringToPrint & Environment.NewLine

        StringToPrint = cmd.getSpecificRecord("SELECT  Heading2 FROM   Headfoot   ")
        LineLen = StringToPrint.Length
        Dim spcLen6 As New String(" "c, Math.Round((40 - LineLen) / 2))
        TextToPrint &= spcLen6 & StringToPrint & Environment.NewLine


        StringToPrint = cmd.getSpecificRecord("SELECT  Heading3 FROM   Headfoot   ")
        LineLen = StringToPrint.Length
        Dim spcLen7 As New String(" "c, Math.Round((40 - LineLen) / 2))
        TextToPrint &= spcLen7 & StringToPrint & Environment.NewLine
        TextToPrint &= "" & Environment.NewLine
        TextToPrint &= "" & Environment.NewLine


        'StringToPrint = "DUPLICATE"
        'LineLen = StringToPrint.Length
        'Dim spcLen8 As New String(" "c, Math.Round((40 - LineLen) / 2))
        'TextToPrint &= spcLen8 & StringToPrint & Environment.NewLine


        Dim a16 = cmd.getSpecificRecord("SELECT [Type]  FROM [DropPayout]  where [ID]= '" & TransactionNo & "'")

        If a16 = 0 Then
            StringToPrint = "SAFE DROP"
        ElseIf a16 = 3 Then
            StringToPrint = "COLLECTION"
        Else
            StringToPrint = "Payout"
        End If
        LineLen = StringToPrint.Length
        Dim spcLen4c As New String(" "c, Math.Round((40 - LineLen) / 2))
        TextToPrint &= spcLen4c & StringToPrint & Environment.NewLine



        Dim a2 As String = "DATE TIME:       " & cmd.getSpecificRecord("SELECT  LastUpdated FROM   [DropPayout]  where [id]='" & TransactionNo & "'  ")
        Dim a3 As String = "Cashier:         " & cmd.getSpecificRecord("SELECT Cashier.Name FROM Cashier INNER JOIN DropPayout ON Cashier.ID = DropPayout.CashierID WHERE DropPayout.ID  = '" & TransactionNo & "'  ")
        ' Dim a4 As String = "Customer:        " & cmd.getSpecificRecord("SELECT        Customer.FirstName FROM    [Transaction] INNER JOIN Customer ON [Transaction].CustomerID = Customer.ID  WHERE        [Transaction].TransactionNumber ='" & TransactionNo & "'  ")
        Dim b33 As String = "Comment:         " & cmd.getSpecificRecord("SELECT  [Comment] FROM [DropPayout]  where [ID]= '" & TransactionNo & "'")


        TextToPrint &= "" & Environment.NewLine

        '  TextToPrint &= a1 & Environment.NewLine
        TextToPrint &= a2 & Environment.NewLine
        TextToPrint &= a3 & Environment.NewLine
        TextToPrint &= b33 & Environment.NewLine
        '   TextToPrint &= a4 & Environment.NewLine
        TextToPrint &= "" & Environment.NewLine



    End Sub
    Public Sub ItemsToBePrinted()
    End Sub
    Public Sub printFooter()

        Dim a11 As Double = cmd.getSpecificRecord("SELECT   0+COALESCE( peso1000,0) FROM   DropPayoutEntry where [DropPayoutID]='" & TransactionNo & "'  ")
        Dim a22 As Double = cmd.getSpecificRecord("SELECT   0+COALESCE( peso500,0) FROM   DropPayoutEntry where [DropPayoutID]='" & TransactionNo & "'  ")
        Dim a33 As Double = cmd.getSpecificRecord("SELECT   0+COALESCE( peso200,0) FROM   DropPayoutEntry where [DropPayoutID]='" & TransactionNo & "'  ")
        Dim a44 As Double = cmd.getSpecificRecord("SELECT   0+COALESCE( peso100,0) FROM   DropPayoutEntry where [DropPayoutID]='" & TransactionNo & "'  ")
        Dim a55 As Double = cmd.getSpecificRecord("SELECT   0+COALESCE( peso50,0) FROM   DropPayoutEntry where [DropPayoutID]='" & TransactionNo & "'  ")
        Dim a66 As Double = cmd.getSpecificRecord("SELECT   0+COALESCE( peso20,0) FROM   DropPayoutEntry where [DropPayoutID]='" & TransactionNo & "'  ")
        Dim a77 As Double = cmd.getSpecificRecord("SELECT   0+COALESCE( peso10,0) FROM   DropPayoutEntry where [DropPayoutID]='" & TransactionNo & "'  ")
        Dim a88 As Double = cmd.getSpecificRecord("SELECT   0+COALESCE( peso5,0) FROM   DropPayoutEntry where [DropPayoutID]='" & TransactionNo & "'  ")
        Dim a99 As Double = cmd.getSpecificRecord("SELECT   0+COALESCE( peso1,0) FROM   DropPayoutEntry where [DropPayoutID]='" & TransactionNo & "'  ")
        Dim b11 As Double = cmd.getSpecificRecord("SELECT   0+COALESCE( pesoOther,0) FROM   DropPayoutEntry where [DropPayoutID]='" & TransactionNo & "'  ")
        Dim b22 As Double = cmd.getSpecificRecord("SELECT   0+COALESCE( [Amount] ,0) FROM [DropPayout]  where [ID]= '" & TransactionNo & "'")


        Dim a1 As String = "               1000 X " & a11 / 1000 & " = " & a11
        Dim a2 As String = "                500 X " & a22 / 500 & " = " & a22
        Dim a3 As String = "                200 X " & a33 / 200 & " = " & a33
        Dim a4 As String = "                100 X " & a44 / 100 & " = " & a44
        Dim a5 As String = "                 50 X " & a55 / 50 & " = " & a55
        Dim a6 As String = "                 20 X " & a66 / 20 & " = " & a66
        Dim a7 As String = "                 10 X " & a77 / 10 & " = " & a77
        Dim a8 As String = "                  5 X " & a88 / 5 & " = " & a88
        Dim a9 As String = "                  1 X " & a99 / 1 & " = " & a99
        Dim b1 As String = "              Other = " & String.Format("{0:N2}", b11)
        Dim b2 As String = "              Total = " & String.Format("{0:N2}", b22)



        ' Dim a1 As String = "               1000 :  " &  *String.Format("{0:N2}", a11)

        Dim a16 = cmd.getSpecificRecord("SELECT [Type]  FROM [DropPayout]  where [ID]= '" & TransactionNo & "'")

        If a16 = 0 Then
            TextToPrint &= a1 & Environment.NewLine
            TextToPrint &= a2 & Environment.NewLine
            TextToPrint &= a3 & Environment.NewLine
            TextToPrint &= a4 & Environment.NewLine
            TextToPrint &= a5 & Environment.NewLine
            TextToPrint &= a6 & Environment.NewLine
            TextToPrint &= a7 & Environment.NewLine
            TextToPrint &= a8 & Environment.NewLine
            TextToPrint &= a9 & Environment.NewLine
            TextToPrint &= b1 & Environment.NewLine
            TextToPrint &= "" & Environment.NewLine
            TextToPrint &= "" & Environment.NewLine
            TextToPrint &= b2 & Environment.NewLine
            TextToPrint &= "" & Environment.NewLine
            TextToPrint &= "" & Environment.NewLine
            TextToPrint &= "" & Environment.NewLine
        Else

            TextToPrint &= b2 & Environment.NewLine

        End If


        TextToPrint &= "" & Environment.NewLine
        TextToPrint &= "" & Environment.NewLine
        TextToPrint &= "" & Environment.NewLine

        TextToPrint &= "x________________________________________" & Environment.NewLine
        TextToPrint &= "SIGNATURE OVER PRINTED NAME" & Environment.NewLine
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



        'StringToPrint = "OF PERMIT USE."
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
        Dim textfont As Font = New Font("Consolas", 8.55, FontStyle.Bold)

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
        e.Graphics.DrawString(TextToPrint.Substring(currentChar, chars), New Font("Consolas", 8.55, FontStyle.Regular), Brushes.Black, b, format)



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
    TiT.PTS.MainForm.Enabled = True
    '  cmd.Update("UPDATE [Transaction] SET      repstatus = '1' WHERE    TransactionNumber = '" & TransactionNo & "'")
    Me.Close()
    End Sub

    Private Sub no_Click(sender As Object, e As EventArgs) Handles no.Click
    TiT.PTS.MainForm.Enabled = True
    Me.Close()
    End Sub


End Class
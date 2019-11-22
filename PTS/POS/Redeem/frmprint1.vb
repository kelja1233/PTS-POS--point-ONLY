Imports System
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Windows.Forms


Public Class frmprint1
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
    batch = cmd.getSpecificRecord("SELECT  0+COALESCE(Max([BatchNumber]),0)  FROM [Batch]  ")
    TransactionNo = cmd.getSpecificRecord("SELECT  0+COALESCE(Max([id]),0)  FROM [Point_RedeemTransaction] ")

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



    StringToPrint = "PETRA GAS LOYALTY CARD: "

    LineLen = StringToPrint.Length
        Dim spcLen4c As New String(" "c, Math.Round((40 - LineLen) / 2))
        TextToPrint &= spcLen4c & StringToPrint & Environment.NewLine



        Dim a1 As String = "Transaction No:  " & cmd.getSpecificRecord("SELECT       0+COALESCE(Max( [ID]),0) FROM  [Point_RedeemTransaction] ")
    Dim a2 As String = "DATE TIME:       " & cmd.getSpecificRecord("SELECT  [Datenow] FROM   [Point_RedeemTransaction]  where [ID]='" & TransactionNo & "'  ").ToString
    Dim a3 As String = "Cashier:         " & cmd.getSpecificRecord("SELECT [Name] FROM   [Cashier]  where [ID]='" & TiT.PTS.MainForm.Cashierid & "'  ")
    Dim a4 As String = "Customer:        " & frmRedeem.txtname.Text


        TextToPrint &= "" & Environment.NewLine

        TextToPrint &= a1 & Environment.NewLine
        TextToPrint &= a2 & Environment.NewLine
        TextToPrint &= a3 & Environment.NewLine
        TextToPrint &= a4 & Environment.NewLine
        TextToPrint &= "" & Environment.NewLine



    End Sub
  Public Sub ItemsToBePrinted(itemid As Integer)
    Dim maxidredeem = cmd.getSpecificRecord("Select  0+COALESCE(Max(ID),0) FROM Point_RedeemTransaction")

    Dim t1 As Integer = Integer.Parse(cmd.getSpecificRecord($"Select  0+COALESCE(Max(RebatesPoint),0) FROM Point_RedeemTransaction where id={ maxidredeem}"))
    Dim t2 As Integer = Integer.Parse(cmd.getSpecificRecord($"Select  0+COALESCE(Max(TransactionNumber),0) FROM Point_RedeemTransaction where id={ maxidredeem}"))
    Dim c1 As Integer = Integer.Parse(cmd.getSpecificRecord($"Select  0+COALESCE(Max(CustomerID),0) FROM Point_RedeemTransaction where id={ maxidredeem}"))


    Dim cmdstr As String = ""
    cmdstr += "SELECT        CONVERT(varchar, [Transaction].Time, 0) , TransactionEntry.Quantity"
    cmdstr += " FROM            TransactionEntry INNER JOIN "
    cmdstr += " [Transaction] ON TransactionEntry.TransactionNumber = [Transaction].TransactionNumber INNER JOIN "
    cmdstr += " Item ON TransactionEntry.ItemID = Item.ID "
    cmdstr += $" where  TransactionEntry.TransactionNumber between { t1}  and { t2} and [Transaction].CashierID={c1}  and itemid={ itemid } order by  TransactionEntry.TransactionNumber "

    Dim product As String = cmd.getSpecificRecord($"Select  Description FROM item where id={ itemid }").ToString

    TextToPrint &= "==========================================" & Environment.NewLine


    Dim dt As New DataTable
    dt = cmd.LoaderData(cmdstr)
    If dt.Rows.Count <> 0 Then
      TextToPrint &= product & Environment.NewLine
      TextToPrint &= "==========================================" & Environment.NewLine
      For i As Integer = 0 To dt.Rows.Count - 1
        Dim LF As String = dt.Rows(i).Item(0).ToString
        Dim Point As Decimal = Decimal.Parse(dt.Rows(i).Item(1).ToString)
        Dim b1 As Integer
        b1 = 0
        Dim s As String = LF
        For Each c As Char In s
          b1 += 1
        Next
        Dim b11 = 20 - b1

        Dim total As String = " " & LF & Space(b11) & " " & String.Format("{0:N2}", Point)
        TextToPrint &= total & Environment.NewLine

      Next
      TextToPrint &= "==========================================" & Environment.NewLine
    End If



  End Sub


  Public Sub printFooter()


    Dim codez = cmd.getSpecificRecord("Select  0+COALESCE(Max(ID),0) FROM Point_Setting where code='" & frmRedeem.txtcode.Text & "'")
        Dim pointa = cmd.getSpecificRecord("SELECT [customnumber1] FROM [Customer]  where ID='" & codez & "'")




        Dim a1 As String = "Redeemed Amount: " & String.Format("{0:N2}", Double.Parse(frmRedeem.TextBox1.Text)) & " PESO"
        'Dim a2 As String = "   Zero-Rated Sales:  " & String.Format("{0:N2}", a22)
        'Dim a3 As String = "   VAT Exempt Sales:  " & String.Format("{0:N2}", a33)
        'Dim a4 As String = "         VAT Amount:  " & String.Format("{0:N2}", a44)
        'Dim a5 As String = "           Discount:  " & String.Format("{0:N2}", a55)

        'Dim a6 As String = "              Total:  " & String.Format("{0:N2}", a66.)
        'Dim a7 As String = "      Cash Tendered:  " & String.Format("{0:N2}", a77 + a88)
        'Dim a8 As String = "         Change Due:  " & String.Format("{0:N2}", a77)

        Dim ab1 As String = "Redeemed Loyalty Point/s:  " & String.Format("{0:N2}", Double.Parse(frmRedeem.TextBox1.Text))
        ' Dim ab2 As String = "  Earn Rebate Point:  " & String.Format("{0:N2}", rebate)
        Dim ab3 As String = "Total Loyalty Point:  " & String.Format("{0:N2}", Double.Parse(pointa))
        ' Dim ab4 As String = " Total Rebate Point:  " & String.Format("{0:N2}", trebate)



        TextToPrint &= a1 & Environment.NewLine

        'TextToPrint &= a2 & Environment.NewLine
        'TextToPrint &= a3 & Environment.NewLine
        'TextToPrint &= a4 & Environment.NewLine
        'TextToPrint &= a5 & Environment.NewLine
        'TextToPrint &= a6 & Environment.NewLine
        'TextToPrint &= "" & Environment.NewLine
        'TextToPrint &= a7 & Environment.NewLine
        'TextToPrint &= a8 & Environment.NewLine
        'TextToPrint &= "" & Environment.NewLine
        TextToPrint &= ab1 & Environment.NewLine
        'TextToPrint &= ab2 & Environment.NewLine

        TextToPrint &= ab3 & Environment.NewLine
        TextToPrint &= "" & Environment.NewLine
        'TextToPrint &= " upon redemption " & Environment.NewLine
        'TextToPrint &= ab4 & Environment.NewLine
        'TextToPrint &= "" & Environment.NewLine
        'TextToPrint &= "" & Environment.NewLine
        'On Error Resume Next
        Dim StringToPrint As String = "Please exchange this slip immediately"
        Dim LineLen As Integer = StringToPrint.Length
        Dim spcLen1 As New String(" "c, Math.Round((40 - LineLen) / 2))
        TextToPrint &= spcLen1 & StringToPrint & Environment.NewLine
        'TextToPrint &= "" & Environment.NewLine





        StringToPrint = "upon redemption"
        LineLen = StringToPrint.Length
        Dim spcLen2 As New String(" "c, Math.Round((40 - LineLen) / 2))
        TextToPrint &= spcLen2 & StringToPrint & Environment.NewLine
        TextToPrint &= "" & Environment.NewLine



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
    ItemsToBePrinted(1)
    ItemsToBePrinted(2)
    ItemsToBePrinted(3)
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
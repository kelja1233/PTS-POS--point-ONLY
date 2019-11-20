Public Class LoyalTYreport
  Dim cmd As commands
  Public Sub New()
    cmd = New commands
    SQLConnect.txtserver.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_server", "Value", Nothing).ToString
    SQLConnect.txtdb.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_database", "Value", Nothing).ToString
    SQLConnect.txtuser.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_user", "Value", Nothing).ToString
    SQLConnect.txtpass.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Password", "Value", Nothing).ToString

  End Sub
  Public Sub crPrint(batch1 As Integer, batch2 As Integer)
    Dim batchnumber1 As Integer = batch1
    Dim batchnumber2 As Integer = batch2
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
    TextToPrint &= "" & Environment.NewLine

    StringToPrint = "LOYALTY REPORT"
    LineLen = StringToPrint.Length
    spcLen = New String(" "c, Math.Round((40 - LineLen) / 2))
    TextToPrint &= spcLen & StringToPrint & Environment.NewLine
    TextToPrint &= "" & Environment.NewLine

    Dim a1 As String = "BEG DATE:  " & cmd.getSpecificRecord("SELECT    [OpeningTime] FROM   [Batch] where [BatchNumber]='" & batchnumber1 & "'  ")
    Dim a2 As String = "END DATE:  " & cmd.getSpecificRecord("SELECT   ( case when [ClosingTime] is null then getdate() else  [ClosingTime] end ) FROM   [Batch] where [BatchNumber]='" & batchnumber2 & "'  ")

    Dim a3 As String = "TOTAL POINTS: "

    TextToPrint &= Environment.NewLine
    TextToPrint &= a1 & Environment.NewLine
    TextToPrint &= a2 & Environment.NewLine
    TextToPrint &= Environment.NewLine
    TextToPrint &= a3 & Environment.NewLine


    Dim a4 As Decimal = Decimal.Parse(cmd.getSpecificRecord($"SELECT     0+COALESCE(SUM([LoyalPoint]),0) FROM [Point_Transaction] where BatchNo between {batchnumber1} and {batchnumber2} "))

    Dim totalEarn As String = String.Format("{0:N2}", Math.Round(a4, 2))
    TextToPrint &= totalEarn & Environment.NewLine
    TextToPrint &= "==========================================" & Environment.NewLine
    Dim a5 As String = "REDEMPTION"

    TextToPrint &= a5 & Environment.NewLine


    cmdstr += " SELECT Point_RedeemTransaction.CustomerID, SUM(Point_RedeemTransaction.LoyalPoint) "
    cmdstr += " FROM Point_RedeemTransaction INNER JOIN"
    cmdstr += " Customer ON Point_RedeemTransaction.CustomerID = Customer.ID"
    cmdstr += $" WHERE        (Point_RedeemTransaction.BatchNo BETWEEN {batchnumber1} AND {batchnumber2})"
    cmdstr += " GROUP BY Point_RedeemTransaction.CustomerID"

    Dim dt As New DataTable
    dt = cmd.LoaderData(cmdstr)
    If dt.Rows.Count <> 0 Then
      Dim totalredeemz As Decimal = 0
      For i As Integer = 0 To dt.Rows.Count - 1
        Dim customerID As Integer = Integer.Parse(dt.Rows(i).Item(0).ToString)
        Dim lasname As String = cmd.getSpecificRecord($"SELECT LEFT(LastName, 1)  FROM [Customer] where  [ID]={customerID} ")
        Dim Fname As String = cmd.getSpecificRecord($"SELECT LEFT(FirstName, 17)  FROM [Customer] where  [ID]={customerID} ")
        Dim LF As String = Fname + " " + lasname + "."
        Dim Totalredeem As Decimal = Decimal.Parse(dt.Rows(i).Item(1).ToString)
        totalredeemz += Totalredeem
        Dim b1 As Integer
        b1 = 0
        Dim s As String = LF
        For Each c As Char In s
          b1 += 1
        Next
        Dim b11 = 20 - b1



        Dim total As String = " " & LF & Space(b11) & " " & String.Format("{0:N2}", Totalredeem)
        TextToPrint &= total & Environment.NewLine

      Next
      TextToPrint &= "_____________________________________________" & Environment.NewLine
      TextToPrint &= "TOTAL POINT REDEEMED: " & String.Format("{0:N2}", totalredeemz)

    End If

    Dim printz As New myPrinter
    printz.print(TextToPrint)

  End Sub

End Class

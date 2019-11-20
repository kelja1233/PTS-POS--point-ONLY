Public Class PumpReadingReport
  Dim cmd As commands
  Dim TextToPrint As String = ""
  Public Sub New()
    cmd = New commands
    SQLConnect.txtserver.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_server", "Value", Nothing).ToString
    SQLConnect.txtdb.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_database", "Value", Nothing).ToString
    SQLConnect.txtuser.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_user", "Value", Nothing).ToString
    SQLConnect.txtpass.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Password", "Value", Nothing).ToString

  End Sub
  Public Sub Header(batch As Integer)

    Dim batchnumber As Integer = batch


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


    StringToPrint = "PUMP READING REPORT"
    LineLen = StringToPrint.Length
    spcLen = New String(" "c, Math.Round((40 - LineLen) / 2))
    TextToPrint &= spcLen & StringToPrint & Environment.NewLine
    TextToPrint &= "" & Environment.NewLine




    Dim a1 As String = "Batch Number:    " & batchnumber
    Dim Shiftno = cmd.getSpecificRecord("SELECT  0+COALESCE(Max([ShiftNumber]),0)  FROM [OP_ShiftReading] where batch='" & batchnumber & "' ")
    Dim s1 As String = "Shift Number:    " & Shiftno
    Dim a2 As String = "OPENING DATE:   " & cmd.getSpecificRecord("SELECT OpeningTime FROM bATCH where BatchNumber = '" & batchnumber & "'  ")
    Dim a4 As String = "CLOSING DATE:    " & cmd.getSpecificRecord("SELECT  ( case when [ClosingTime] is null then getdate() else  [ClosingTime] end )  FROM bATCH where BatchNumber = '" & batchnumber & "'  ")

    Dim a3 As String = "Cashier:         " & cmd.getSpecificRecord("SELECT Cashier.Name FROM CashierReport INNER JOIN Cashier ON CashierReport.CashierID = Cashier.ID where  CashierReport.BatchNumber = '" & batchnumber & "'  ")

    TextToPrint &= "" & Environment.NewLine

    TextToPrint &= a1 & Environment.NewLine
    TextToPrint &= s1 & Environment.NewLine
    TextToPrint &= a2 & Environment.NewLine

    TextToPrint &= a4 & Environment.NewLine
    TextToPrint &= a3 & Environment.NewLine
    TextToPrint &= "" & Environment.NewLine

  End Sub
  Public Sub ItemsToBePrinted(batch As Integer)
    TextToPrint &= "==========================================" & Environment.NewLine
    TextToPrint &= "==========ELECTRONIC PUMP TOTALS==========" & Environment.NewLine
    TextToPrint &= "     " & "Start Reading " & "End Reading  " & "Fuel Disp." & Environment.NewLine
    TextToPrint &= "==========================================" & Environment.NewLine
    Dim batchnumber As Integer = batch
    Dim cmdstr As String = ""
    Dim dt As New DataTable



    cmdstr += "SELECT "
    cmdstr += "  OP_PumpSettings.PumpCode,"
    cmdstr += " LEFT(OP_PumpSettings.Description, 1) ,"
    cmdstr += " OP_ShiftReading.StartReading,"
    cmdstr += "  OP_ShiftReading.EndReading,"
    cmdstr += "  OP_ShiftReading.Calibration +OP_ShiftReading.Misload + OP_ShiftReading.Transfer,"
    cmdstr += " OP_ShiftReading.EndReading - OP_ShiftReading.StartReading - OP_ShiftReading.Calibration-OP_ShiftReading.Misload- OP_ShiftReading.Transfer," 'LiterSolve
    cmdstr += "  OP_PumpSettings.Description, "
    cmdstr += " (OP_ShiftReading.EndAReading - OP_ShiftReading.StartAReading - OP_ShiftReading.ACalibration-OP_ShiftReading.AMisload- OP_ShiftReading.ATransfer) "
    cmdstr += "  FROM  OP_ShiftReading INNER JOIN OP_PumpSettings ON OP_ShiftReading.Pump = OP_PumpSettings.Pump AND OP_ShiftReading.Nozzle = OP_PumpSettings.Nozzle INNER JOIN Item ON OP_PumpSettings.ItemID = Item.ID "
    cmdstr += "  WHERE        (OP_ShiftReading.batch = '" & batchnumber & "') ORDER BY OP_PumpSettings.Inactive "


    dt = cmd.LoaderData(cmdstr)
    cmdstr = ""
    Dim amount As Decimal = 0
    Dim LITERS As Decimal = 0
    If dt.Rows.Count <> 0 Then
      For i As Integer = 0 To dt.Rows.Count - 1
        Dim a1 As String = dt.Rows(i).Item(0).ToString
        Dim a3 As String = dt.Rows(i).Item(1).ToString
        Dim a4 As Decimal = Math.Round(Decimal.Parse(dt.Rows(i).Item(2).ToString), 3)
        Dim a5 As Decimal = Math.Round(Decimal.Parse(dt.Rows(i).Item(3).ToString), 3)
        Dim a6 As Decimal = Math.Round(Decimal.Parse(dt.Rows(i).Item(4).ToString), 3)
        Dim a7 As Decimal = a5 - a4
        amount += Math.Round(Decimal.Parse(dt.Rows(i).Item(3).ToString), 3)
        LITERS += Math.Round(Decimal.Parse(dt.Rows(i).Item(2).ToString), 3)
        Dim y As String = a1 & a3
        Dim a11 As Integer
        a11 = 0
        Dim s As String = y
        For Each c As Char In s
          a11 += 1
        Next
        Dim a111 = 5 - a11
        Dim a44 As Integer
        a44 = 0
        Dim s1 As String = String.Format("{0:N3}", a4)
        For Each c As Char In s1
          a44 += 1
        Next
        Dim a444 = 13 - a44

        Dim a55 As Integer
        a55 = 0
        Dim s2 As String = String.Format("{0:N3}", a5)
        For Each c As Char In s2
          a55 += 1
        Next
        Dim a555 = 13 - a55
        Dim a66 As Integer
        a66 = 0
        Dim s3 As String = a7
        For Each c As Char In s3
          a66 += 1
        Next
        Dim a666 = 18 - a66


        Dim total As String = y & Space(a111) & String.Format("{0:N3}", a4) & Space(a444) & String.Format("{0:N3}", a5) & Space(a555) & String.Format("{0:N3}", a7)
        TextToPrint &= total & Environment.NewLine
      Next
      Dim all As Decimal = amount - LITERS

      Dim print As String = Space(26) & String.Format("{0:N3}", all)
      TextToPrint &= print & Environment.NewLine



      TextToPrint &= "==========================================" & Environment.NewLine

      baba(batchnumber)
      TextToPrint &= "==========================================" & Environment.NewLine
      SUMMARY(batchnumber)
      TextToPrint &= "==========================================" & Environment.NewLine
      Dim rl As Decimal = Decimal.Parse(cmd.getSpecificRecord("SELECT  0+COALESCE(SUM( OP_ShiftReading.EndReading - OP_ShiftReading.StartReading - OP_ShiftReading.Calibration ),0) FROM  OP_ShiftReading INNER JOIN OP_PumpSettings ON OP_ShiftReading.Pump = OP_PumpSettings.Pump AND OP_ShiftReading.Nozzle = OP_PumpSettings.Nozzle INNER JOIN Item ON OP_PumpSettings.ItemID = Item.ID  WHERE (OP_ShiftReading.batch = '" & batchnumber & "')"))
      Dim rP As Decimal = Decimal.Parse(cmd.getSpecificRecord("SELECT     0+COALESCE(sum( OP_ShiftReading.EndAReading - OP_ShiftReading.StartAReading - OP_ShiftReading.ACalibration) ,0) FROM  OP_ShiftReading INNER JOIN OP_PumpSettings ON OP_ShiftReading.Pump = OP_PumpSettings.Pump AND OP_ShiftReading.Nozzle = OP_PumpSettings.Nozzle INNER JOIN Item ON OP_PumpSettings.ItemID = Item.ID  WHERE (OP_ShiftReading.batch = '" & batchnumber & "')"))
      TextToPrint &= "Total Liters= " & String.Format("{0:N2}", rl) & Environment.NewLine
      TextToPrint &= "Total Amount= " & String.Format("{0:N2}", rP) & Environment.NewLine
      TextToPrint &= "==========================================" & Environment.NewLine



    End If
  End Sub
  Public Sub SUMMARY(batch As Integer)
    TextToPrint &= "=================SUMMARY==================" & Environment.NewLine
    TextToPrint &= "PRODUCT     " & "LITERS SOLD " & "   AMOUNT" & Environment.NewLine
    TextToPrint &= "==========================================" & Environment.NewLine


    Dim batchnumber As Integer = batch
    Dim cmdstr As String = ""
    Dim dt As New DataTable

    'cmdstr += "SELECT  "
    'cmdstr += "  OP_PumpSettings.PumpCode,"
    'cmdstr += "  LEFT(OP_PumpSettings.Description, 1),"
    'cmdstr += "  OP_ShiftReading.StartReading, "
    'cmdstr += "   OP_ShiftReading.EndReading,"
    'cmdstr += "  OP_ShiftReading.Calibration +OP_ShiftReading.Misload + OP_ShiftReading.Transfer,"
    'cmdstr += "  OP_ShiftReading.EndReading - OP_ShiftReading.StartReading - OP_ShiftReading.Calibration-OP_ShiftReading.Misload- OP_ShiftReading.Transfer AS LiterSolve,"
    'cmdstr += "  OP_PumpSettings.Description, "
    'cmdstr += "   (OP_ShiftReading.EndAReading - OP_ShiftReading.StartAReading - OP_ShiftReading.ACalibration-OP_ShiftReading.AMisload- OP_ShiftReading.ATransfer) "
    'cmdstr += "  FROM            OP_ShiftReading INNER JOIN OP_PumpSettings ON OP_ShiftReading.Pump = OP_PumpSettings.Pump AND OP_ShiftReading.Nozzle = OP_PumpSettings.Nozzle INNER JOIN Item ON OP_PumpSettings.ItemID = Item.ID "

    'cmdstr += " WHERE        (OP_ShiftReading.batch = '" & batchnumber & "') ORDER BY OP_PumpSettings.Inactive"


    cmdstr = "SELECT OP_PumpSettings.Description, SUM(OP_ShiftReading.StartReading) AS Expr1, SUM(OP_ShiftReading.EndReading) AS Expr2, SUM(OP_ShiftReading.Calibration) AS Expr3, SUM(OP_ShiftReading.EndReading - OP_ShiftReading.StartReading - OP_ShiftReading.Calibration) AS LiterSolve, SUM(OP_ShiftReading.EndAReading - OP_ShiftReading.StartAReading - OP_ShiftReading.ACalibration) AS Amount FROM OP_ShiftReading INNER JOIN OP_PumpSettings ON OP_ShiftReading.Pump = OP_PumpSettings.Pump AND OP_ShiftReading.Nozzle = OP_PumpSettings.Nozzle INNER JOIN Item ON OP_PumpSettings.ItemID = Item.ID WHERE (OP_ShiftReading.batch = '" & batchnumber & "') GROUP BY OP_PumpSettings.Description, Item.Price,OP_PumpSettings.PriceAdjustment"

    dt = cmd.LoaderData(cmdstr)
    cmdstr = ""

    Dim amount As Decimal = 0
    Dim LITERS As Decimal = 0
    If dt.Rows.Count <> 0 Then


      For i As Integer = 0 To dt.Rows.Count - 1

        Dim a1 As String = dt.Rows(i).Item(0).ToString

        Dim a3 As Decimal = Math.Round(Decimal.Parse(dt.Rows(i).Item(1).ToString), 3)
        Dim a4 As Decimal = Math.Round(Decimal.Parse(dt.Rows(i).Item(2).ToString), 3)
        Dim a5 As Decimal = Math.Round(Decimal.Parse(dt.Rows(i).Item(3).ToString), 3)
        Dim a6 As Decimal = Math.Round(Decimal.Parse(dt.Rows(i).Item(4).ToString), 3)
        Dim a7 As Decimal = Math.Round(Decimal.Parse(dt.Rows(i).Item(5).ToString), 3)
        amount += Math.Round(Decimal.Parse(dt.Rows(i).Item(5).ToString), 3)
        LITERS += Math.Round(Decimal.Parse(dt.Rows(i).Item(4).ToString), 3)
        Dim a11 As Integer
        a11 = 0
        Dim s As String = a1
        For Each c As Char In s
          a11 += 1
        Next
        Dim a111 = 12 - a11


        Dim a44 As Integer
        a44 = 0
        Dim s1 As String = String.Format("{0:N3}", a6)
        For Each c As Char In s1
          a44 += 1
        Next
        Dim a444 = 10 - a44






        Dim total As String = a1 & Space(a111) & String.Format("{0:N3}", a6) & Space(a444) & " P " & String.Format("{0:N3}", a7)
        TextToPrint &= total & Environment.NewLine




      Next

    End If
    Dim print As String = Space(12) & String.Format("{0:N3}", LITERS) & Space(3) & " P " & String.Format("{0:N3}", amount)
    TextToPrint &= print & Environment.NewLine
  End Sub
  Public Sub baba(batch As Integer)

    TextToPrint &= "==========ELECTRONIC PUMP TOTALS==========" & Environment.NewLine
    TextToPrint &= "     " & "OTHERS   " & "LITERS SOLD " & " AMOUNT" & Environment.NewLine
    TextToPrint &= "==========================================" & Environment.NewLine


    Dim batchnumber As Integer = batch
    Dim cmdstr As String = ""
    Dim dt As New DataTable



    cmdstr += "SELECT "
    cmdstr += "  OP_PumpSettings.PumpCode,"
    cmdstr += " LEFT(OP_PumpSettings.Description, 1) ,"
    cmdstr += " OP_ShiftReading.StartReading,"
    cmdstr += "  OP_ShiftReading.EndReading,"
    cmdstr += "  OP_ShiftReading.Calibration +OP_ShiftReading.Misload + OP_ShiftReading.Transfer,"
    cmdstr += " OP_ShiftReading.EndReading - OP_ShiftReading.StartReading - OP_ShiftReading.Calibration-OP_ShiftReading.Misload- OP_ShiftReading.Transfer," 'LiterSolve
    cmdstr += "  OP_PumpSettings.Description, "
    cmdstr += " (OP_ShiftReading.EndAReading - OP_ShiftReading.StartAReading - OP_ShiftReading.ACalibration-OP_ShiftReading.AMisload- OP_ShiftReading.ATransfer) "
    cmdstr += "  FROM  OP_ShiftReading INNER JOIN OP_PumpSettings ON OP_ShiftReading.Pump = OP_PumpSettings.Pump AND OP_ShiftReading.Nozzle = OP_PumpSettings.Nozzle INNER JOIN Item ON OP_PumpSettings.ItemID = Item.ID "
    cmdstr += "  WHERE        (OP_ShiftReading.batch = '" & batchnumber & "') ORDER BY OP_PumpSettings.Inactive "


    dt = cmd.LoaderData(cmdstr)
    cmdstr = ""
    Dim amount As Decimal = 0
    Dim LITERS As Decimal = 0
    If dt.Rows.Count <> 0 Then
      For i As Integer = 0 To dt.Rows.Count - 1

        Dim a1 = dt.Rows(i).Item(0).ToString

        Dim a3 As String = dt.Rows(i).Item(1).ToString
        Dim a4 As Decimal = Decimal.Parse(dt.Rows(i).Item(2).ToString)
        Dim a5 As Decimal = Decimal.Parse(dt.Rows(i).Item(3).ToString)
        Dim a6 As Decimal = Decimal.Parse(dt.Rows(i).Item(4).ToString)
        Dim a7 As Decimal = Decimal.Parse(dt.Rows(i).Item(5).ToString)
        Dim a8 As String = dt.Rows(i).Item(6).ToString
        Dim a9 As Decimal = Decimal.Parse(dt.Rows(i).Item(7).ToString)

        Dim y As String = a1 & a3


        Dim a11 As Integer
        a11 = 0
        Dim s As String = y
        For Each c As Char In s
          a11 += 1
        Next
        Dim a111 = 5 - a11









        Dim a44 As Integer
        a44 = 0
        Dim s1 As String = String.Format("{0:N3}", a7)
        For Each c As Char In s1
          a44 += 1
        Next
        Dim a444 = 12 - a44

        Dim a66 As Integer
        a66 = 0
        Dim s3 As String = String.Format("{0:N3}", a6)
        For Each c As Char In s3
          a66 += 1
        Next
        Dim a666 = 9 - a66




        Dim total As String = y & Space(a111) & String.Format("{0:N3}", a6) & Space(a666) & String.Format("{0:N3}", a7) & Space(a444) & "P " & String.Format("{0:N3}", a9)
        TextToPrint &= total & Environment.NewLine



      Next
    End If



  End Sub



  Public Sub prPrint(batch As Integer)
    Header(batch)
    ItemsToBePrinted(batch)
    Dim mprinter As New myPrinter
    mprinter.print(TextToPrint)
  End Sub
End Class

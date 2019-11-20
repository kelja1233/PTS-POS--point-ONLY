Imports System.Data.SqlClient

Public Class ChangeEndShift
  Dim cmd As commands
  Dim TextToPrint As String = ""
  Public Sub New()
    cmd = New commands
    SQLConnect.txtserver.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_server", "Value", Nothing).ToString
    SQLConnect.txtdb.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_database", "Value", Nothing).ToString
    SQLConnect.txtuser.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_user", "Value", Nothing).ToString
    SQLConnect.txtpass.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Password", "Value", Nothing).ToString

  End Sub
  Public Sub ChangeSE(shift As Integer, batch As Integer)
    Dim batchnumber As Integer = batch
    Dim shiftnumber As Integer = shift + 1
    Dim cmdstr As String
    cmdstr = "SELECT  [Pump],[Nozzle],[ItemID],[ItemLookupCode],[Description],[CurrentReading],[Currentareading]  FROM  [OP_PumpSettings] "



    Dim storeid = cmd.getSpecificRecord("Select [StoreID] FROM [Configuration]")
    Dim day As Integer = Integer.Parse(cmd.getSpecificRecord("SELECT  0+COALESCE(Max([DayNumber]),0)  FROM [OP_DayReading] "))
    If shiftnumber = 1 Then
      day = day + 1
    End If
    cmd.Update("UPDATE Batch SET [ClosingTime]=GETDATE() ,Status = '0' where [BatchNumber]='" & batch & "'")
    cmd.AddRecord("INSERT INTO [Batch] (RegisterID,OpeningTime) VALUES (1,GETDATE())")



    Dim dt As New DataTable
    dt = cmd.LoaderData(cmdstr)
    If dt.Rows.Count <> 0 Then
      For i As Integer = 0 To dt.Rows.Count - 1


        Dim a1 As Integer = Integer.Parse(dt.Rows(i).Item(0).ToString)
        Dim a2 As Integer = Integer.Parse(dt.Rows(i).Item(1).ToString)
        Dim a3 As Integer = Integer.Parse(dt.Rows(i).Item(2).ToString)
        Dim a4 As String = dt.Rows(i).Item(3).ToString
        Dim a5 As String = dt.Rows(i).Item(4).ToString
        Dim a6 As Double = Double.Parse(dt.Rows(i).Item(5).ToString)
        Dim a7 As Double = Double.Parse(dt.Rows(i).Item(6).ToString)


        cmd.Update("UPDATE OP_ShiftReading SET Status = '0',Itemlookupcode='" & a4 & "',[EndReading]='" & a6 & "',[EndAReading]='" & a7 & "' where [batch]='" & batch & "' and Pump='" & a1 & "' and [Nozzle]='" & a2 & "' ")
        cmd.AddRecord("INSERT INTO [OP_ShiftReading] (batch,[DayNumber],[ShiftNumber],[Pump],[Nozzle],[StartReading],[StartAReading],Itemlookupcode,[EndReading],[EndAReading]) VALUES ('" & batch + 1 & "','" & day & "','" & shiftnumber & "','" & a1 & "','" & a2 & "','" & a6 & "','" & a7 & "','" & a4 & "',0,0)")



      Next

      cmd.Update("UPDATE ShiftEndingInventory  SET ShiftEndingInventory.status=0,ShiftEndingInventory.DipStickHeight = Item.Quantity FROM Item, ShiftEndingInventory WHERE Item.ID = ShiftEndingInventory.ItemID and ShiftEndingInventory.BatchNumber='" & batch & "' ")
      cmd.AddRecord("INSERT INTO ShiftEndingInventory ([BatchNumber],[ItemID],[Quantity],Price,Cost)  (SELECT  '" & batch + 1 & "',[ID],[Quantity],Price,Cost  FROM [Item]  )")
      cmd.AddRecord("INSERT INTO [CashierReport] (BatchNumber,CashierID) VALUES ('" & batch + 1 & "','0')")
      backup()

    End If
  End Sub

  Public Sub backup()


    Dim server As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_server", "Value", Nothing).ToString
    Dim database As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_database", "Value", Nothing).ToString
    Dim user As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_user", "Value", Nothing).ToString
    Dim Password As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Password", "Value", Nothing).ToString
    Dim pathset As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_pathset", "Value", Nothing).ToString


    Dim sqlConnectionString As String = "Data Source='" & server & "';Initial Catalog='" & database & "';Persist Security Info=True;User ID='" & user & "';Password='" & Password & "'"




    Dim conn As New SqlConnection(sqlConnectionString)
    conn.Open()

    Dim datenow As String = Date.Now.ToString("MM-dd-yyyy-h-mm-ss-tt")

    Dim endFileName1 As String = pathset & "Radar" + datenow + ".RadarBackup"


    Dim cmd As New SqlCommand
    cmd.CommandType = CommandType.Text
    cmd.CommandText = "BACKUP DATABASE " & database & " TO DISK='" & endFileName1 & "'"
    cmd.Connection = conn
    cmd.ExecuteNonQuery()

    conn.Close()


  End Sub


End Class

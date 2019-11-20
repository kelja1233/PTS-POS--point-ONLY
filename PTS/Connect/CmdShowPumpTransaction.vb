Imports TiT
Public Class CmdShowPumpTransaction
  Dim cmd As commands

  Public Sub New()


    cmd = New commands

    SQLConnect.txtserver.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_server", "Value", Nothing).ToString
    SQLConnect.txtdb.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_database", "Value", Nothing).ToString
    SQLConnect.txtuser.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_user", "Value", Nothing).ToString
    SQLConnect.txtpass.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Password", "Value", Nothing).ToString


  End Sub

  Public Sub ShowPT()
    Dim aaa As New DataGridView



    Dim cmdstring As String = ""
    cmdstring += "SELECT "
    cmdstring += " PumpTransactions.ID,"
    cmdstring += " OP_PumpSettings.ItemLookupCode,"
    cmdstring += " OP_PumpSettings.Description,"
    cmdstring += " ROUND(PumpTransactions.Volume, 2) AS Volume,"
    cmdstring += " ROUND(PumpTransactions.UnitPrice, 2)  AS UnitPrice, "
    cmdstring += " ROUND(PumpTransactions.Amount, 2) AS Amount,"
    cmdstring += "  PumpTransactions.Dispenser, "
    cmdstring += " OP_PumpSettings.PumpCode AS [Pump Code] "
    cmdstring += " FROM  PumpTransactions INNER JOIN   OP_PumpSettings ON PumpTransactions.Dispenser = OP_PumpSettings.Pump AND PumpTransactions.Grade = OP_PumpSettings.ItemLookupCode AND  PumpTransactions.nozzle = OP_PumpSettings.Nozzle "
    cmdstring += " WHERE "
    cmdstring += " (PumpTransactions.Status = 0) ORDER BY PumpTransactions.ID "


    cmd.SelectRecord(cmdstring, "PumpTransactions", TiT.PTS.MainForm.DataGridView1)
    'cmd.SelectRecord(cmdstring, "PumpTransactions", aaa)
    'Dim a1 = TiT.PTS.MainForm.DataGridView1.Item(1, 1).Value

    'MessageBox.Show(a1)
    TiT.PTS.MainForm.DataGridView1.Columns(3).DefaultCellStyle.Format = "N2"
    TiT.PTS.MainForm.DataGridView1.Columns(5).DefaultCellStyle.Format = "N2"
    Dim column1 As DataGridViewColumn = TiT.PTS.MainForm.DataGridView1.Columns(0)
    Dim column2 As DataGridViewColumn = TiT.PTS.MainForm.DataGridView1.Columns(1)
    Dim column3 As DataGridViewColumn = TiT.PTS.MainForm.DataGridView1.Columns(2)
    Dim column4 As DataGridViewColumn = TiT.PTS.MainForm.DataGridView1.Columns(3)
    Dim column5 As DataGridViewColumn = TiT.PTS.MainForm.DataGridView1.Columns(4)
    Dim column6 As DataGridViewColumn = TiT.PTS.MainForm.DataGridView1.Columns(5)
    Dim column7 As DataGridViewColumn = TiT.PTS.MainForm.DataGridView1.Columns(6)
    Dim column8 As DataGridViewColumn = TiT.PTS.MainForm.DataGridView1.Columns(7)
    column1.Visible = False

    column2.Visible = False
    column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    column4.Width = 85

    column5.Visible = False
    column6.Width = 85
    column7.Width = 85
    column8.Visible = False
    column8.Width = 85

  End Sub

End Class

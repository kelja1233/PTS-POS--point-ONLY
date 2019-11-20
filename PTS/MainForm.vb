Imports System.Xml
Imports System.ComponentModel
Imports System.Text
Imports System.IO
Imports System.IO.Ports
Imports System.Reflection
Imports System.Threading
Namespace TiT.PTS
	Public Delegate Sub Action()

  Partial Public Class MainForm
    Inherits Form
    Private _ptsConfigDialog As PtsConfigDialog
    Private _dispensingSettingsDialog As PtsDispensingSettingsDialog
    Private _atgMainForm As AtgMainForm
    Private _allTotalsDialog As AllTotalsDialog
    Private _pts As PTS
    Private WithEvents _fuelPointControl1 As FuelPointControl
    Private WithEvents _fuelPointControl2 As FuelPointControl
    Private WithEvents _fuelPointControl3 As FuelPointControl
    Private WithEvents _fuelPointControl4 As FuelPointControl
    Private WithEvents _fuelPointControl5 As FuelPointControl
    Private WithEvents _fuelPointControl6 As FuelPointControl
    Private WithEvents _fuelPointControl7 As FuelPointControl
    Private WithEvents _fuelPointControl8 As FuelPointControl
    Private WithEvents _fuelPointControl9 As FuelPointControl
    Private WithEvents _fuelPointControl10 As FuelPointControl
    Private WithEvents _fuelPointControl11 As FuelPointControl
    Private WithEvents _fuelPointControl12 As FuelPointControl
    Private WithEvents _fuelPointControl13 As FuelPointControl
    Private WithEvents _fuelPointControl14 As FuelPointControl
    Private WithEvents _fuelPointControl15 As FuelPointControl
    Private WithEvents _fuelPointControl16 As FuelPointControl
    Private cmdShowPT As New CmdShowPumpTransaction
    Public batchNumber As Integer = 0
    Public ShiftNumber As Integer = 0
    Public Cashierid As Integer = 0
    Public storeid As Integer = 0
    Public tenderidz As Integer = 0
    Public Sub New()
      InitializeComponent()

      _pts = New PTS()
      _ptsConfigDialog = New PtsConfigDialog()
      _dispensingSettingsDialog = New PtsDispensingSettingsDialog()
      _atgMainForm = New AtgMainForm(_pts, Me)
      _allTotalsDialog = New AllTotalsDialog(_pts)
      _dispensingSettingsDialog.PTS = _pts
      Text = "Kelvin Project K"
      _pts.SelectedAuthorizationType = AuthorizeType.Volume
      _pts.AuthorizationPolling = False
      _pts.UseExtendedCommands = False



      For Each ctrl As Control In tableLayoutPanel.Controls
        If TypeOf ctrl Is FuelPointControl Then
          CType(ctrl, FuelPointControl).PTS = _pts
        End If
      Next ctrl
    End Sub

    Friend Sub LoadConfiguration()
      If Not File.Exists("Config.xml") Then
        Return
      End If

      Dim XmlDoc As New XmlDocument()
      XmlDoc.Load("Config.xml")

      Dim XmlFuelPointConfigNode As XmlNode = XmlDoc.SelectSingleNode(".//FuelPointConfiguration")

      Dim XmlFuelPoint As XmlNode

      For Each FPctrl As Control In tableLayoutPanel.Controls
        If TypeOf FPctrl Is FuelPointControl Then
          XmlFuelPoint = XmlFuelPointConfigNode.SelectSingleNode(".//" & (CType(FPctrl, FuelPointControl)).Name)

          If XmlFuelPoint Is Nothing Then
            Continue For
          End If

          CType(FPctrl, FuelPointControl).FuelPointID = Integer.Parse(XmlFuelPoint.Attributes("FuelPointID").Value)

          CType(FPctrl, FuelPointControl).FuelPoint.NozzlesQuantity = Integer.Parse(XmlFuelPoint.Attributes("FuelPointNozzlesCounts").Value)

          For i As Integer = 1 To PtsConfiguration.NozzleQuantity
            CType(FPctrl, FuelPointControl).FuelPoint.Nozzles(i - 1).PricePerLiter = Integer.Parse(XmlFuelPoint.Attributes("nozzle_price_" & i.ToString()).Value)
          Next i
        End If
      Next FPctrl

      Dim XmlAtgConfigNode As XmlNode = XmlDoc.SelectSingleNode(".//AtgConfiguration")
      Dim XmlAtg As XmlNode

      For Each Actrl As Control In _atgMainForm.tableLayoutPanel.Controls
        If TypeOf Actrl Is AtgControl Then
          XmlAtg = XmlAtgConfigNode.SelectSingleNode(".//" & (CType(Actrl, AtgControl)).Name)

          If XmlAtg Is Nothing Then
            Continue For
          End If

          CType(Actrl, AtgControl).AtgID = Integer.Parse(XmlAtg.Attributes("AtgID").Value)

          CType(Actrl, AtgControl).Atg.MaxTankHeight = Integer.Parse(XmlAtg.Attributes("MaxHeight").Value)
        End If
      Next Actrl
    End Sub

    Friend Sub SaveConfiguration()
      Dim XmlDoc As New XmlDocument()

      Dim XmlConfig As XmlElement = XmlDoc.CreateElement("Configuration")
      XmlDoc.AppendChild(XmlConfig)

      Dim XmlFuelPointConfigNode As XmlElement = XmlDoc.CreateElement("FuelPointConfiguration")
      XmlConfig.AppendChild(XmlFuelPointConfigNode)

      Dim XmlAtgConfigNode As XmlElement = XmlDoc.CreateElement("AtgConfiguration")
      XmlConfig.AppendChild(XmlAtgConfigNode)

      For Each FPctrl As Control In tableLayoutPanel.Controls
        If TypeOf FPctrl Is FuelPointControl Then
          If (CType(FPctrl, FuelPointControl)).FuelPointID Is Nothing Then
            Continue For
          End If

          Dim XmlFuelPoint As XmlNode = XmlDoc.CreateElement((CType(FPctrl, FuelPointControl)).Name)

          Dim xmlAttrID As XmlAttribute = XmlDoc.CreateAttribute("FuelPointID")
          xmlAttrID.Value = (CType(FPctrl, FuelPointControl)).FuelPointID.ToString()
          XmlFuelPoint.Attributes.Append(xmlAttrID)

          Dim xmlAttrNozzlesCounts As XmlAttribute = XmlDoc.CreateAttribute("FuelPointNozzlesCounts")
          xmlAttrNozzlesCounts.Value = (CType(FPctrl, FuelPointControl)).FuelPoint.NozzlesQuantity.ToString()
          XmlFuelPoint.Attributes.Append(xmlAttrNozzlesCounts)

          For i As Integer = 1 To PtsConfiguration.NozzleQuantity
            Dim xmlAttribute As XmlAttribute = XmlDoc.CreateAttribute("nozzle_price_" & i.ToString())
            xmlAttribute.Value = (CType(FPctrl, FuelPointControl)).FuelPoint.Nozzles(i - 1).PricePerLiter.ToString()
            XmlFuelPoint.Attributes.Append(xmlAttribute)
          Next i

          XmlFuelPointConfigNode.AppendChild(XmlFuelPoint)
        End If
      Next FPctrl

      For Each Actrl As Control In _atgMainForm.tableLayoutPanel.Controls
        If TypeOf Actrl Is AtgControl Then
          If (CType(Actrl, AtgControl)).AtgID Is Nothing Then
            Continue For
          End If

          Dim XmlAtg As XmlNode = XmlDoc.CreateElement((CType(Actrl, AtgControl)).Name)

          Dim XmlAttrID As XmlAttribute = XmlDoc.CreateAttribute("AtgID")
          XmlAttrID.Value = (CType(Actrl, AtgControl)).AtgID.ToString()
          XmlAtg.Attributes.Append(XmlAttrID)

          Dim xmlAttribute As XmlAttribute = XmlDoc.CreateAttribute("MaxHeight")
          xmlAttribute.Value = (CType(Actrl, AtgControl)).Atg.MaxTankHeight.ToString()
          XmlAtg.Attributes.Append(xmlAttribute)

          XmlAtgConfigNode.AppendChild(XmlAtg)
        End If
      Next Actrl

      XmlDoc.Save("Config.xml")
    End Sub

    Public Function FuelPointHasUniqueID(ByVal FuelPointID As Integer) As Boolean
      Dim counter As Integer = 0

      For Each ctrl As Control In tableLayoutPanel.Controls
        If TypeOf ctrl Is FuelPointControl Then
          If (CType(ctrl, FuelPointControl)).FuelPointID = FuelPointID Then
            counter += 1
          End If
        End If
      Next ctrl

      If counter = 1 Then
        Return True
      Else
        Return False
      End If
    End Function

    Public Sub DisableAllOtherFPControls(ByVal curFuelPointID? As Integer, ByVal curName As String, ByVal val As Boolean)
      For Each ctrl As Control In tableLayoutPanel.Controls
        If TypeOf ctrl Is FuelPointControl Then
          If (CType(ctrl, FuelPointControl)).FuelPointID = curFuelPointID AndAlso (CType(ctrl, FuelPointControl)).Name <> curName Then
            CType(ctrl, FuelPointControl).IsLocked = val
          End If
        End If
      Next ctrl
    End Sub

    Public Function CheckFPIsLocked(ByVal curFuelPointID? As Integer, ByVal curName As String) As Boolean
      For Each ctrl As Control In tableLayoutPanel.Controls
        If TypeOf ctrl Is FuelPointControl Then
          If (CType(ctrl, FuelPointControl)).FuelPointID = curFuelPointID AndAlso (CType(ctrl, FuelPointControl)).Name <> curName AndAlso (CType(ctrl, FuelPointControl)).IsDispensing Then
            Return True
          End If
        End If
      Next ctrl

      Return False
    End Function

    Protected Overrides Sub OnShown(ByVal e As EventArgs)
      MyBase.OnShown(e)

      Dim portNames As New List(Of String)()
      For Each portName As String In SerialPort.GetPortNames()
        portNames.Add(portName)
      Next portName
      portNames.Reverse()
      portListComboBox.ComboBox.DataSource = portNames
    End Sub

    Protected Overrides Sub OnClosing(ByVal e As CancelEventArgs)
      MyBase.OnClosing(e)

      Dim counter As Integer = 0

      For Each ctrl As Control In tableLayoutPanel.Controls
        If TypeOf ctrl Is FuelPointControl Then
          If (CType(ctrl, FuelPointControl)).IsDispensing Then
            counter += 1
          End If
        End If
      Next ctrl

      If counter > 0 Then
        If MessageBox.Show("You are closing application with working fuel dispensers." & vbLf & "Do you want to stop all dispensers?", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = DialogResult.OK Then
          For Each ctrl As Control In tableLayoutPanel.Controls
            If TypeOf ctrl Is FuelPointControl Then
              If (CType(ctrl, FuelPointControl)).IsDispensing Then
                CType(ctrl, FuelPointControl).Stop()
                CType(ctrl, FuelPointControl).Dispose()
              End If
            End If
          Next ctrl

          Environment.Exit(0)
        Else
          e.Cancel = True
          Return
        End If
      End If

      Environment.Exit(0)
    End Sub

    Private Sub settingsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      For Each ctrl As Control In TableLayoutPanel.Controls
        If TypeOf ctrl Is FuelPointControl Then
          If (CType(ctrl, FuelPointControl)).IsLocked OrElse (CType(ctrl, FuelPointControl)).IsDispensing Then
            MessageBox.Show("For configuration of PTS controller please stop all FuelPoints", "PTS controller configuration", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
          End If
        End If
      Next ctrl

      _ptsConfigDialog.PTS = _pts
      _ptsConfigDialog.ShowDialog()

      If _ptsConfigDialog.DialogResult = DialogResult.Cancel Then
        For Each ctrl As Control In TableLayoutPanel.Controls
          If TypeOf ctrl Is FuelPointControl Then
            CType(ctrl, FuelPointControl).refreshUI()
          End If
        Next ctrl
      End If
    End Sub

    Private Sub StartQuery()
      For Each ctrl As Control In TableLayoutPanel.Controls
        If TypeOf ctrl Is FuelPointControl Then
          If (CType(ctrl, FuelPointControl)).FuelPoint IsNot Nothing Then
            CType(ctrl, FuelPointControl).FuelPoint.IsActive = True
          End If
        End If
      Next ctrl

      For Each ctrl As Control In _atgMainForm.tableLayoutPanel.Controls
        If TypeOf ctrl Is AtgControl Then
          If (CType(ctrl, AtgControl)).Atg IsNot Nothing Then
            CType(ctrl, AtgControl).Atg.IsActive = True
          End If
        End If
      Next ctrl
    End Sub

    Private Sub portConnectionButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles portConnectionButton.Click
      If Not _pts.IsOpen Then
        Try
          _pts.PortName = portListComboBox.SelectedItem.ToString()
          _pts.Open()
          LoadConfiguration()
          'StartQuery();

          For Each ctrl As Control In TableLayoutPanel.Controls
            If TypeOf ctrl Is FuelPointControl Then
              CType(ctrl, FuelPointControl).Start()
            End If
          Next ctrl

          For Each ctrl As Control In _atgMainForm.tableLayoutPanel.Controls
            If TypeOf ctrl Is AtgControl Then
              CType(ctrl, AtgControl).Start()
            End If
          Next ctrl

          VisualizeOpenConnection(True)
        Catch ex As InvalidOperationException
          MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

          If _pts.IsOpen Then
            _pts.Close()
          End If
          VisualizeOpenConnection(False)

          Return
        Catch ex As UnauthorizedAccessException
          MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

          If _pts.IsOpen Then
            _pts.Close()
          End If
          VisualizeOpenConnection(False)

          Return
        Catch ex As TimeoutException
          MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

          If _pts.IsOpen Then
            _pts.Close()
          End If
          VisualizeOpenConnection(False)

          Return
        Catch ex As Exception
          MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

          If _pts.IsOpen Then
            _pts.Close()
          End If
          VisualizeOpenConnection(False)

          Return
        End Try
      Else
        Dim counter As Integer = 0

        For Each ctrl As Control In TableLayoutPanel.Controls
          If TypeOf ctrl Is FuelPointControl Then
            If (CType(ctrl, FuelPointControl)).IsDispensing Then
              counter += 1
            End If
          End If
        Next ctrl

        If counter > 0 Then
          MessageBox.Show("You can not close COM port while fuel dispensers are working. First stop all fuel dispensers.", "Close COM port", MessageBoxButtons.OK, MessageBoxIcon.Warning)

          portConnectionButton.Checked = True
          Return
        End If

        For Each ctrl As Control In TableLayoutPanel.Controls
          If TypeOf ctrl Is FuelPointControl Then
            CType(ctrl, FuelPointControl).IsLocked = False
          End If
        Next ctrl

        _pts.Close()
        VisualizeOpenConnection(False)
      End If
    End Sub

    Private Sub VisualizeOpenConnection(ByVal state As Boolean)
      'Comment this configuration
      'settingsToolStripMenuItem.Enabled = state
      'dispensingSettingsToolStripMenuItem.Enabled = state
      'portListComboBox.Enabled = Not state
      'portConnectionButton.Checked = state
      'aTGMeasurementDataToolStripMenuItem.Enabled = state
      '_atgMainForm.optionsToolStripMenuItem.Enabled = state
      'btstart.Enabled = state
      'tsStopAllPumps.Enabled = state
    End Sub

    Private Sub exitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      Me.Close()
    End Sub

    Private Sub aboutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      CType(New AboutBox(), AboutBox).ShowDialog()
    End Sub

    Private Sub dispensingSettingsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      For Each ctrl As Control In TableLayoutPanel.Controls
        If TypeOf ctrl Is FuelPointControl Then
          If (CType(ctrl, FuelPointControl)).IsDispensing OrElse (CType(ctrl, FuelPointControl)).IsLocked Then
            MessageBox.Show("For configuration of dispensing settings please stop all FuelPoints", "Dispensing configuration", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
          End If
        End If
      Next ctrl

      If _dispensingSettingsDialog.ShowDialog() = DialogResult.OK Then
        For Each ctrl As Control In TableLayoutPanel.Controls
          If TypeOf ctrl Is FuelPointControl Then
            CType(ctrl, FuelPointControl).SetDigits()
          End If
        Next ctrl
      End If
    End Sub

    Private Sub aTGMeasurementDataToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      _atgMainForm.Show()
    End Sub

    Private Sub totalCountersToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      _allTotalsDialog.ShowDialog()
    End Sub

    Private Sub tsStopAllPumps_Click(ByVal sender As Object, ByVal e As EventArgs)
      For Each ctrl As Control In TableLayoutPanel.Controls
        If TypeOf ctrl Is FuelPointControl Then
          If (CType(ctrl, FuelPointControl)).IsDispensing Then
            CType(ctrl, FuelPointControl).Stop()
          End If
        End If
      Next ctrl
    End Sub



    Private Sub Button6_Click(sender As Object, e As EventArgs)


      If _fuelPointControl1.lbID.Text = "-" Then
        _fuelPointControl1.Hide()
      End If

      If _fuelPointControl2.lbID.Text = "-" Then
        _fuelPointControl2.Hide()
      End If

      If _fuelPointControl3.lbID.Text = "-" Then
        _fuelPointControl3.Hide()
      End If

      If _fuelPointControl4.lbID.Text = "-" Then
        _fuelPointControl4.Hide()
      End If

      If _fuelPointControl5.lbID.Text = "-" Then
        _fuelPointControl5.Hide()
      End If

      If _fuelPointControl6.lbID.Text = "-" Then
        _fuelPointControl6.Hide()
      End If

      If _fuelPointControl7.lbID.Text = "-" Then
        _fuelPointControl7.Hide()
      End If

      If _fuelPointControl8.lbID.Text = "-" Then
        _fuelPointControl8.Hide()
      End If

      If _fuelPointControl9.lbID.Text = "-" Then
        _fuelPointControl9.Hide()
      End If

      If _fuelPointControl10.lbID.Text = "-" Then
        _fuelPointControl10.Hide()
      End If

      If _fuelPointControl11.lbID.Text = "-" Then
        _fuelPointControl11.Hide()
      End If

      If _fuelPointControl12.lbID.Text = "-" Then
        _fuelPointControl12.Hide()
      End If

      If _fuelPointControl13.lbID.Text = "-" Then
        _fuelPointControl13.Hide()
      End If

      If _fuelPointControl14.lbID.Text = "-" Then
        _fuelPointControl14.Hide()
      End If

      If _fuelPointControl15.lbID.Text = "-" Then
        _fuelPointControl15.Hide()
      End If

      If _fuelPointControl16.lbID.Text = "-" Then
        _fuelPointControl16.Hide()
      End If


    End Sub

    Private Sub btstart_Click(sender As Object, e As EventArgs) Handles bttotalizer.Click
      If _pts.IsOpen = True Then
        RefreshRecord()
        Dim crc As New CashierReportUpdate
        crc.cr(Me.batchNumber, Me.ShiftNumber, Me.Cashierid)
        _allTotalsDialog.ShowDialog()
      End If



    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs)
      SQLConnect.Show()
    End Sub

    Private Sub MainFormEnable_Load(sender As Object, e As EventArgs) Handles MyBase.EnabledChanged
      Try
        btclear.PerformClick()
        frmLogin.timesetting()

        frmLogin.Show()
        frmLogin.BringToFront()
      Catch ex As Exception

      End Try

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
      cmdShowPT.ShowPT()
    End Sub




    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
      Dim cmdCT As New cmdCheckTransaction
      Invoke(New Action(Sub() cmdShowPT.ShowPT()))




      'cmdstring += " PumpTransactions.ID,"
      'cmdstring += " OP_PumpSettings.ItemLookupCode,"
      'cmdstring += " OP_PumpSettings.Description,"
      'cmdstring += " ROUND(PumpTransactions.Volume, 2) AS Volume,"
      'cmdstring += " ROUND(PumpTransactions.UnitPrice, 2)  AS UnitPrice, "
      'cmdstring += " ROUND(PumpTransactions.Amount, 2) AS Amount,"
      'cmdstring += "  PumpTransactions.Dispenser, "



      If e.RowIndex <> -1 Then
        Dim ItemLookUp As String = DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString
        Dim Description As String = DataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString
        Dim Quantity As Decimal = Decimal.Parse(DataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString)
        Dim UnitPrice As Decimal = Decimal.Parse(DataGridView1.Rows(e.RowIndex).Cells(4).Value.ToString)
        Dim Amount As Decimal = Decimal.Parse(DataGridView1.Rows(e.RowIndex).Cells(5).Value.ToString)
        Dim Discount As Decimal = 0
        Dim pointw As Decimal = 0
        Dim pointx As Decimal = 0
        Dim IDZ As Integer = Integer.Parse(DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString)
        Dim Column1 As Integer = Integer.Parse(DataGridView1.Rows(e.RowIndex).Cells(6).Value.ToString)

        If cmdCT.CheckTransNum(IDZ) = 0 Then




          Me.DataGridView2.Rows.Add(ItemLookUp, Description & "(" & Column1 & ")", Quantity, UnitPrice, Amount, Discount, 0, 0, IDZ, Column1)
        End If

      End If






      Invoke(New Action(Sub() cmdShowPT.ShowPT()))
      RefreshRecord()
    End Sub
    Public Sub RefreshRecord()
      On Error Resume Next
      Dim CSR As New ComputationShow
      txtdis.Text = CType(CSR.TotalDiscount, String)
      TXTVAT.Text = CType(CSR.Vat, String)
      txttax.Text = CType(CSR.Tax, String)
      Dim total As Decimal = CSR.TotalAmount - CSR.TotalDiscount
      txtchange.Text = CType(Double.Parse(txtcash.Text) - total, String)
      txtchangename.Text = "Change"

      If Double.Parse(txtcash.Text) < total Then
        txtchange.Text = CType((Double.Parse(txtcash.Text) - total) * -1, String)
        txtchangename.Text = "Balance"
      ElseIf Double.Parse(txtcash.Text) = 0 Then
        txtchangename.Text = "Change"
      Else
        txtchangename.Text = "Change"
      End If
      Dim ph = System.Globalization.CultureInfo.CreateSpecificCulture("en-PH")
      Dim myString As String = total.ToString("N0")
      txttotaldue.Text = String.Format("{0:0,0.00}", total)
      txttotalTender.Text = String.Format("{0:0,0.00}", total)
      If txtcash.Text = "0" Then
        txtchangename.Text = "Change"
        txtchange.Text = ""
      ElseIf txtcash.Text = "0.00" Then
        txtchangename.Text = "Change"
        txtchange.Text = ""
      ElseIf txtcash.Text = "" Then
        txtchangename.Text = "Change"
        txtchange.Text = ""
      End If


    End Sub

    Private Sub txtcash_TextChanged(sender As Object, e As EventArgs) Handles txtcash.TextChanged


      If txtcash.Text.Contains(".") Then
        Dim First As Integer = txtcash.Text.IndexOf("."c)
        Dim Last As Integer = txtcash.Text.LastIndexOf("."c)
        If First <> Last Then
          Dim StartPos = txtcash.SelectionStart - 1
          txtcash.Text = txtcash.Text.Remove(txtcash.SelectionStart - 1, 1)
          txtcash.SelectionStart = StartPos
        End If
      End If
      RefreshRecord()

      If txtcash.Text = "1995.0808" Then
        MessageBox.Show("Programmer:Kelvin James Arizo     Designer:Rolando Valdez Jr.     Copyright......2017 ")
      End If

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcash.KeyPress
      If Char.IsPunctuation(e.KeyChar) And e.KeyChar.ToString <> "." Or Char.IsLetter(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Then 'Allows only numbers, "." and some keys like delete, backspace, enter, etc in Control

        e.Handled = True
      End If


    End Sub

    Private Sub DisallowPaste(sender As Object, e As KeyEventArgs) Handles txtcash.KeyDown
      If e.Control AndAlso (e.KeyCode = Keys.V) Then e.SuppressKeyPress = True 'Disallows paste to TextBox. Or allowing only one decimal in textchanged event can fail.
      If (e.KeyCode = Keys.Space) Then e.SuppressKeyPress = True 'Disallows paste to TextBox. Or allowing only one decimal in textchanged event can fail.


    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
      DateTimePicker2.Text = DateTime.Now
    End Sub

    Private Sub btclear_Click(sender As Object, e As EventArgs) Handles btclear.Click
      Dim cmdptr As New CmdptRefershPedding

      txtchange.Text = "0.00"
      txttotalTender.Text = "0.00"
      txttotaldue.Text = "0.00"
      txtdis.Text = "0.00"
      TXTVAT.Text = "0.00"
      txttax.Text = "0.00"

      txtact.Clear()
      txtDN.Clear()
      txtcash.Clear()
      txtname.Text = "None"
      cmdptr.UpdatePT()
      DataGridView2.Rows.Clear()
      Invoke(New Action(Sub() cmdShowPT.ShowPT()))

    End Sub


    Private Sub txtname_Click(sender As Object, e As EventArgs) Handles txtname.Click
      ShowCustomer.ShowDialog()
    End Sub

    Private Sub btnonfuel_Click(sender As Object, e As EventArgs) Handles btnonfuel.Click

    End Sub


    Private Sub btcash_Click(sender As Object, e As EventArgs) Handles btcash.Click
      Dim csp As New ComputationShow
      Dim total As Decimal = csp.TotalAmount - csp.TotalDiscount
      Dim discount As Decimal = csp.TotalDiscount

      If total = 0 Then
      Else

        If txtchangename.Text = "Balance" Then


          MessageBox.Show("Make sure you don't have any balance")
        Else
          Dim cmdIt As New CmdInsertTender
          Dim transactionnumber As Integer
          transactionnumber = cmdIt.InsertCashTransaction(1, txtact.Text, storeid, batchNumber, Cashierid, txtact.Text, txtDN.Text, txtPlateNo.Text, txtchange.Text, ShiftNumber)
          Dim ttr As New TenderTyperReceipt
          ttr.printRecord(1, discount, transactionnumber)


          btclear.PerformClick()


        End If
      End If

    End Sub

    Private Sub btpo_Click(sender As Object, e As EventArgs) Handles btpo.Click
      Dim csp As New ComputationShow
      Dim total As Decimal = csp.TotalAmount - csp.TotalDiscount
      Dim discount As Decimal = csp.TotalDiscount
      If txtact.Text = "" Then
        MessageBox.Show("No Customer")
      Else


        If total = 0 Then
        Else

          If txtchangename.Text = "Balance" Then


            MessageBox.Show("Make sure you don't have any balance")
          Else
            Dim cmdIt As New CmdInsertTender
            Dim transactionnumber As Integer
            transactionnumber = cmdIt.InsertCashTransaction(2, txtact.Text, storeid, batchNumber, Cashierid, txtact.Text, txtDN.Text, txtPlateNo.Text, txtchange.Text, ShiftNumber)
            Dim ttr As New TenderTyperReceipt
            ttr.printRecord(2, discount, transactionnumber)


            btclear.PerformClick()


          End If
        End If



      End If
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Sub CShif()

      frmLogin.Show()
      _allTotalsDialog.Close()
      Me.Hide()

      frmLogin.Show()
      frmLogin.BringToFront()
    End Sub

    Public Sub zPriceChange(pumpid As Integer, nozzle As Integer, price As Decimal)
      Dim _price As Decimal = price * 100
      _price = Math.Round(_price, 0)


      _fuelPointControl2.changePrice(nozzle, CInt(_price))
    End Sub

    Private Sub BTCASHpoint_Click(sender As Object, e As EventArgs) Handles BTCASHpoint.Click
      Dim csp As New ComputationShow
      Dim total As Decimal = csp.TotalAmount - csp.TotalDiscount

      If total = 0 Then
      Else

        If txtchangename.Text = "Balance" Then


          MessageBox.Show("Make sure you don't have any balance")
        Else
          Dim cmdIt As New CmdInsertTender

          frmPoint.Close()
          tenderidz = 1
          frmPoint.ShowDialog()
          btclear.PerformClick()


        End If
      End If
    End Sub

    Private Sub BTpoPoint_Click(sender As Object, e As EventArgs) Handles BTpoPoint.Click
      Dim csp As New ComputationShow
      Dim total As Decimal = csp.TotalAmount - csp.TotalDiscount

      If total = 0 Then
      Else

        If txtchangename.Text = "Balance" Then


          MessageBox.Show("Make sure you don't have any balance")
        Else
          Dim cmdIt As New CmdInsertTender

          frmPoint.Close()
          tenderidz = 2
          frmPoint.ShowDialog()
          btclear.PerformClick()


        End If
      End If
    End Sub

    Private Sub btDRAWER_Click(sender As Object, e As EventArgs) Handles btDRAWER.Click
      Dim cd As New classdrawer
      cd.OpenCashdrawer()

    End Sub

    Private Sub btcr_Click(sender As Object, e As EventArgs) Handles btcr.Click
      Crpara.ShowDialog()
    End Sub

    Private Sub btpumpreading_Click(sender As Object, e As EventArgs) Handles btpumpreading.Click
      PumpBatch.ShowDialog()
    End Sub



    Private Sub btchangep_Click(sender As Object, e As EventArgs) Handles btchangep.Click
      If _pts.IsOpen = True Then
        RefreshRecord()
        Dim crc As New CashierReportUpdate
        crc.cr(Me.batchNumber, Me.ShiftNumber, Me.Cashierid)
        Pricechange.ShowDialog()
      End If

    End Sub

    Private Sub btchangeuser_Click(sender As Object, e As EventArgs) Handles btchangeuser.Click
      CShif()
    End Sub

    Private Sub btreedem_Click(sender As Object, e As EventArgs) Handles btreedem.Click
      frmRedeem.ShowDialog()
    End Sub

    Private Sub btsplit_Click(sender As Object, e As EventArgs) Handles btsplit.Click
      Dim count = DataGridView2.RowCount

      If count = 1 Then
        Dim a8 As Integer = Integer.Parse(DataGridView2.Item(8, 0).Value.ToString)
        Dim cct As New cmdCheckTransaction
        Split.pumpid = a8
        Split.Grade = cct.Grade(a8)
        Split.Dispenser = cct.Dispenser(a8)
        Split.Amount = cct.Amount(a8)
        Split.Volume = cct.Amount(a8)





        Split.ShowDialog()


      Else
        MessageBox.Show("Cant Split")
      End If

    End Sub

    Private Sub btcalibration_Click(sender As Object, e As EventArgs) Handles btcalibration.Click
      Dim csp As New ComputationShow
      Dim total As Decimal = csp.TotalAmount - csp.TotalDiscount
      Dim discount As Decimal = csp.TotalDiscount

      If total = 0 Then
      Else

        If txtchangename.Text = "Balance" Then


          MessageBox.Show("Make sure you don't have any balance")
        Else
          Dim cmdIt As New CmdInsertTender
          Dim transactionnumber As Integer
          transactionnumber = cmdIt.InsertCashTransaction(3, txtact.Text, storeid, batchNumber, Cashierid, txtact.Text, txtDN.Text, txtPlateNo.Text, txtchange.Text, ShiftNumber)
          Dim ttr As New TenderTyperReceipt
          ttr.printRecord(1, discount, transactionnumber)


          btclear.PerformClick()


        End If
      End If
    End Sub

    Private Sub btCashdrop_Click(sender As Object, e As EventArgs) Handles btCashdrop.Click
      Dim cd As New classdrawer
      cd.OpenCashdrawer()
      CashDrop.Close()
      CashDrop.lbbatch.Text = batchNumber
      CashDrop.lbcash.Text = Cashierid
      CashDrop.txtcomment.Enabled = True
      CashDrop.ShowDialog()
    End Sub

    Private Sub btlastdrop_Click(sender As Object, e As EventArgs) Handles btlastdrop.Click
      Dim cd As New classdrawer
      cd.OpenCashdrawer()
      Dim cmd As New commands

      SQLConnect.txtserver.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_server", "Value", Nothing).ToString
      SQLConnect.txtdb.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_database", "Value", Nothing).ToString
      SQLConnect.txtuser.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_user", "Value", Nothing).ToString
      SQLConnect.txtpass.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Password", "Value", Nothing).ToString
      CashDrop.Close()
      CashDrop.txtcomment.Text = "LAST DROP"
      CashDrop.txtcomment.Enabled = False

      CashDrop.lbbatch.Text = batchNumber - 1
      CashDrop.lbcash.Text = cmd.getSpecificRecord("SELECT  0+COALESCE(Max(CashierID),0)  FROM CashierReport where BatchNumber='" & batchNumber - 1 & "'  ")

      CashDrop.ShowDialog()

    End Sub

    Private Sub btpayout_Click(sender As Object, e As EventArgs) Handles btpayout.Click
      Dim cd As New classdrawer
      cd.OpenCashdrawer()
      Payout.Close()
      Payout.ShowDialog()
    End Sub

    Private Sub btvoid_Click(sender As Object, e As EventArgs) Handles btvoid.Click
      Try
        Dim cmd As New commands
        Void.Close()
        Void.ShowDialog()

        SQLConnect.txtserver.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_server", "Value", Nothing).ToString
        SQLConnect.txtdb.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_database", "Value", Nothing).ToString
        SQLConnect.txtuser.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_user", "Value", Nothing).ToString
        SQLConnect.txtpass.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Password", "Value", Nothing).ToString

        Dim batch As Integer = batchNumber


        cmd.SelectRecord("SELECT  [TransactionNumber],[Time],[CustomerID],[CashierID],[Total],[SalesTax],[Comment],[ReferenceNumber],[Note],[PlateNumber],[OtherTransactionNumber],[Void],[Vatable],[NonVat],[TaxExempt],[Discount]  FROM [Transaction] where void=0   and [BatchNumber] between '" & batch - 10 & "'  and '" & batch & "' order by TransactionNumber desc", "Transaction", Void.DataGridView1)

      Catch ex As Exception

      End Try

    End Sub

    Private Sub bddiscount_Click(sender As Object, e As EventArgs) Handles bddiscount.Click
      frmDiscount.ShowDialog()
    End Sub
    Private Sub bt1_Click(sender As Object, e As EventArgs) Handles bt1.Click
      Try


        If txtcash.Text = "0" Then
          txtcash.Text = 1

        ElseIf txtcash.Text = "" Then
          txtcash.Text = 1
        Else
          txtcash.Text = txtcash.Text & 1


        End If

      Catch ex As Exception
        txtcash.Text = 0
      End Try
    End Sub

    Private Sub bt2_Click(sender As Object, e As EventArgs) Handles bt2.Click
      Try


        If txtcash.Text = "0" Then
          txtcash.Text = 2

        ElseIf txtcash.Text = "" Then
          txtcash.Text = 2
        Else
          txtcash.Text = txtcash.Text & 2


        End If

      Catch ex As Exception
        txtcash.Text = 0
      End Try
    End Sub

    Private Sub bt3_Click(sender As Object, e As EventArgs) Handles bt3.Click
      Try


        If txtcash.Text = "0" Then
          txtcash.Text = 3

        ElseIf txtcash.Text = "" Then
          txtcash.Text = 3
        Else
          txtcash.Text = txtcash.Text & 3


        End If

      Catch ex As Exception
        txtcash.Text = 0
      End Try
    End Sub

    Private Sub bt6_Click(sender As Object, e As EventArgs) Handles bt6.Click
      Try


        If txtcash.Text = "0" Then
          txtcash.Text = 6

        ElseIf txtcash.Text = "" Then
          txtcash.Text = 6
        Else
          txtcash.Text = txtcash.Text & 6


        End If

      Catch ex As Exception
        txtcash.Text = 0
      End Try
    End Sub

    Private Sub bt5_Click(sender As Object, e As EventArgs) Handles bt5.Click
      Try


        If txtcash.Text = "0" Then
          txtcash.Text = 5

        ElseIf txtcash.Text = "" Then
          txtcash.Text = 5
        Else
          txtcash.Text = txtcash.Text & 5


        End If

      Catch ex As Exception
        txtcash.Text = 0
      End Try
    End Sub

    Private Sub bt4_Click(sender As Object, e As EventArgs) Handles bt4.Click
      Try


        If txtcash.Text = "0" Then
          txtcash.Text = 4

        ElseIf txtcash.Text = "" Then
          txtcash.Text = 4
        Else
          txtcash.Text = txtcash.Text & 4


        End If

      Catch ex As Exception
        txtcash.Text = 0
      End Try
    End Sub

    Private Sub bt9_Click(sender As Object, e As EventArgs) Handles bt9.Click
      Try


        If txtcash.Text = "0" Then
          txtcash.Text = 9

        ElseIf txtcash.Text = "" Then
          txtcash.Text = 9
        Else
          txtcash.Text = txtcash.Text & 9


        End If

      Catch ex As Exception
        txtcash.Text = 0
      End Try
    End Sub

    Private Sub bt8_Click(sender As Object, e As EventArgs) Handles bt8.Click
      Try


        If txtcash.Text = "0" Then
          txtcash.Text = 8

        ElseIf txtcash.Text = "" Then
          txtcash.Text = 8
        Else
          txtcash.Text = txtcash.Text & 8


        End If

      Catch ex As Exception
        txtcash.Text = 0
      End Try
    End Sub

    Private Sub bt7_Click(sender As Object, e As EventArgs) Handles bt7.Click
      Try


        If txtcash.Text = "0" Then
          txtcash.Text = 7

        ElseIf txtcash.Text = "" Then
          txtcash.Text = 7
        Else
          txtcash.Text = txtcash.Text & 7


        End If

      Catch ex As Exception
        txtcash.Text = 0
      End Try
    End Sub

    Private Sub btdot_Click(sender As Object, e As EventArgs) Handles btdot.Click
      Try


        If txtcash.Text = "0" Then
          txtcash.Text = "0."

        ElseIf txtcash.Text = "" Then
          txtcash.Text = "0."
        Else
          txtcash.Text = txtcash.Text & "."


        End If

      Catch ex As Exception
        txtcash.Text = 0
      End Try
    End Sub

    Private Sub bt00_Click(sender As Object, e As EventArgs) Handles bt00.Click
      Try


        If txtcash.Text = "0" Then
          txtcash.Text = "0"

        ElseIf txtcash.Text = "" Then
          txtcash.Text = "0"
        Else
          txtcash.Text = txtcash.Text & "00"


        End If

      Catch ex As Exception
        txtcash.Text = 0
      End Try
    End Sub

    Private Sub bt0_Click(sender As Object, e As EventArgs) Handles bt0.Click
      Try


        If txtcash.Text = "0" Then
          txtcash.Text = "0"

        ElseIf txtcash.Text = "" Then
          txtcash.Text = "0"
        Else
          txtcash.Text = txtcash.Text & "0"


        End If

      Catch ex As Exception
        txtcash.Text = 0
      End Try
    End Sub

    Private Sub bt1000_Click(sender As Object, e As EventArgs) Handles bt1000.Click
      Try


        If txtcash.Text = "0" Then
          txtcash.Text = 1000

        ElseIf txtcash.Text = "" Then
          txtcash.Text = 1000
        Else
          txtcash.Text = Double.Parse(txtcash.Text) + 1000


        End If

      Catch ex As Exception
        txtcash.Text = 0
      End Try
    End Sub

    Private Sub bt500_Click(sender As Object, e As EventArgs) Handles bt500.Click
      Try


        If txtcash.Text = "0" Then
          txtcash.Text = 500

        ElseIf txtcash.Text = "" Then
          txtcash.Text = 500
        Else
          txtcash.Text = Double.Parse(txtcash.Text) + 500


        End If

      Catch ex As Exception
        txtcash.Text = 0
      End Try
    End Sub

    Private Sub bt400_Click(sender As Object, e As EventArgs) Handles bt400.Click
      Try


        If txtcash.Text = "0" Then
          txtcash.Text = 400

        ElseIf txtcash.Text = "" Then
          txtcash.Text = 400
        Else
          txtcash.Text = Double.Parse(txtcash.Text) + 400


        End If

      Catch ex As Exception
        txtcash.Text = 0
      End Try
    End Sub

    Private Sub bt300_Click(sender As Object, e As EventArgs) Handles bt300.Click
      Try


        If txtcash.Text = "0" Then
          txtcash.Text = 300

        ElseIf txtcash.Text = "" Then
          txtcash.Text = 300
        Else
          txtcash.Text = Double.Parse(txtcash.Text) + 300


        End If

      Catch ex As Exception
        txtcash.Text = 0
      End Try
    End Sub

    Private Sub bt200_Click(sender As Object, e As EventArgs) Handles bt200.Click
      Try


        If txtcash.Text = "0" Then
          txtcash.Text = 200

        ElseIf txtcash.Text = "" Then
          txtcash.Text = 200
        Else
          txtcash.Text = Double.Parse(txtcash.Text) + 200


        End If

      Catch ex As Exception
        txtcash.Text = 0
      End Try
    End Sub

    Private Sub bt100_Click(sender As Object, e As EventArgs) Handles bt100.Click
      Try


        If txtcash.Text = "0" Then
          txtcash.Text = 100

        ElseIf txtcash.Text = "" Then
          txtcash.Text = 100
        Else
          txtcash.Text = Double.Parse(txtcash.Text) + 100


        End If

      Catch ex As Exception
        txtcash.Text = 0
      End Try
    End Sub
    Private Sub Main_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
      If e.KeyCode = Keys.Escape Then
        btclear.PerformClick()
      ElseIf e.KeyCode = Keys.Delete Then
        Try
          Dim cmd As commands
          cmd = New commands

          SQLConnect.txtserver.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_server", "Value", Nothing).ToString
          SQLConnect.txtdb.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_database", "Value", Nothing).ToString
          SQLConnect.txtuser.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_user", "Value", Nothing).ToString
          SQLConnect.txtpass.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Password", "Value", Nothing).ToString


          Dim a8 As Integer = Integer.Parse(DataGridView2.Rows(Me.DataGridView2.CurrentRow.Index).Cells(8).Value.ToString)
          Me.DataGridView2.Rows.Remove(Me.DataGridView2.CurrentRow)
          cmd.Update($"UPDATE PumpTransactions SET      Status = '0  WHERE    ID = '{ a8 }'")
        Catch ex As Exception

        End Try
      End If

    End Sub

    Private Sub btLoyaltyReport_Click(sender As Object, e As EventArgs) Handles btLoyaltyReport.Click
      LoyalTYreportzz.ShowDialog()
    End Sub
  End Class

End Namespace

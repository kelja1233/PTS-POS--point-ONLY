Imports System.Xml
Imports System.ComponentModel
Imports System.Text
Imports System.IO
Imports System.IO.Ports
Imports System.Reflection

Namespace TiT.PTS
	Public Delegate Sub Action()

	Partial Public Class MainForm
		Inherits Form
		Private _ptsConfigDialog As PtsConfigDialog
		Private _dispensingSettingsDialog As PtsDispensingSettingsDialog
		Private _atgMainForm As AtgMainForm
		Private _allTotalsDialog As AllTotalsDialog
		Private _pts As PTS

		Private _fuelPointControl1 As FuelPointControl
		Private _fuelPointControl2 As FuelPointControl
		Private _fuelPointControl3 As FuelPointControl
		Private _fuelPointControl4 As FuelPointControl
		Private _fuelPointControl5 As FuelPointControl
		Private _fuelPointControl6 As FuelPointControl
		Private _fuelPointControl7 As FuelPointControl
		Private _fuelPointControl8 As FuelPointControl

		Public Sub New()
			InitializeComponent()

			_pts = New PTS()
			_ptsConfigDialog = New PtsConfigDialog()
			_dispensingSettingsDialog = New PtsDispensingSettingsDialog()
			_atgMainForm = New AtgMainForm(_pts, Me)
			_allTotalsDialog = New AllTotalsDialog(_pts)
			_dispensingSettingsDialog.PTS = _pts
			Text &= System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString()
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

		Private Sub settingsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles settingsToolStripMenuItem.Click
			For Each ctrl As Control In tableLayoutPanel.Controls
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
				For Each ctrl As Control In tableLayoutPanel.Controls
					If TypeOf ctrl Is FuelPointControl Then
						CType(ctrl, FuelPointControl).refreshUI()
					End If
				Next ctrl
			End If
		End Sub

		Private Sub StartQuery()
			For Each ctrl As Control In tableLayoutPanel.Controls
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

					For Each ctrl As Control In tableLayoutPanel.Controls
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

				For Each ctrl As Control In tableLayoutPanel.Controls
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

				For Each ctrl As Control In tableLayoutPanel.Controls
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
			settingsToolStripMenuItem.Enabled = state
			dispensingSettingsToolStripMenuItem.Enabled = state
			portListComboBox.Enabled = Not state
			portConnectionButton.Checked = state
			aTGMeasurementDataToolStripMenuItem.Enabled = state
			_atgMainForm.optionsToolStripMenuItem.Enabled = state
			totalCountersToolStripMenuItem.Enabled = state
			tsStopAllPumps.Enabled = state
		End Sub

		Private Sub exitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles exitToolStripMenuItem.Click
			Me.Close()
		End Sub

		Private Sub aboutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles aboutToolStripMenuItem.Click
			CType(New AboutBox(), AboutBox).ShowDialog()
		End Sub

		Private Sub dispensingSettingsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles dispensingSettingsToolStripMenuItem.Click
			For Each ctrl As Control In tableLayoutPanel.Controls
				If TypeOf ctrl Is FuelPointControl Then
					If (CType(ctrl, FuelPointControl)).IsDispensing OrElse (CType(ctrl, FuelPointControl)).IsLocked Then
						MessageBox.Show("For configuration of dispensing settings please stop all FuelPoints", "Dispensing configuration", MessageBoxButtons.OK, MessageBoxIcon.Warning)
						Return
					End If
				End If
			Next ctrl

			If _dispensingSettingsDialog.ShowDialog() = DialogResult.OK Then
				For Each ctrl As Control In tableLayoutPanel.Controls
					If TypeOf ctrl Is FuelPointControl Then
						CType(ctrl, FuelPointControl).SetDigits()
					End If
				Next ctrl
			End If
		End Sub

		Private Sub aTGMeasurementDataToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles aTGMeasurementDataToolStripMenuItem.Click
			_atgMainForm.Show()
		End Sub

		Private Sub totalCountersToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles totalCountersToolStripMenuItem.Click
			_allTotalsDialog.ShowDialog()
		End Sub

		Private Sub tsStopAllPumps_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tsStopAllPumps.Click
			For Each ctrl As Control In tableLayoutPanel.Controls
				If TypeOf ctrl Is FuelPointControl Then
					If (CType(ctrl, FuelPointControl)).IsDispensing Then
						CType(ctrl, FuelPointControl).Stop()
					End If
				End If
			Next ctrl
		End Sub
	End Class
End Namespace

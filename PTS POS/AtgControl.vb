Imports System.ComponentModel
Imports System.Text

Namespace TiT.PTS
	Partial Public Class AtgControl
		Inherits UserControl
		Private _settingDialog As AtgDisplaySettingDialog
		Private _atg As ATG = Nothing
		Private _pts As PTS = Nothing
		Private _atgId? As Integer = Nothing

		''' <summary>
		''' Create an instance of AtgControl class.
		''' </summary>
		Public Sub New()
			InitializeComponent()
			_settingDialog = New AtgDisplaySettingDialog(Me)
		End Sub

		''' <summary>
		''' Draw a rectangle around a control at creation.
		''' </summary>
		''' <param name="pe"></param>
		Protected Overrides Sub OnPaint(ByVal pe As PaintEventArgs)
			Dim _borderPen As New Pen(Color.Red, 2)

			MyBase.OnPaint(pe)
			Dim g As Graphics = pe.Graphics
			g.DrawRectangle(_borderPen, New Rectangle(0, 0, Width, Height))
		End Sub

		''' <summary>
		''' Gets or sets ID of an ATG, which belongs to current control.
		''' </summary>
		Public Property AtgID() As Integer?
			Get
				Return _atgId
			End Get
			Set(ByVal value? As Integer)
				If value < 1 OrElse value > PtsConfiguration.AtgQuantity Then
					Throw New ArgumentOutOfRangeException()
				End If

				If Atg IsNot Nothing Then
					uninitializeAtg()
				End If

				_atgId = value
				_settingDialog.AtgID = _atgId
				initializeAtg()
				refreshUI()
			End Set
		End Property

		''' <summary>
		''' Gets or sets ATG, which belongs to current control.
		''' </summary>
		Public Property Atg() As ATG
			Get
				Return _atg
			End Get
			Set(ByVal value As ATG)
				_atg = value
			End Set
		End Property

		''' <summary>
		''' Gets or sets PTS, which belongs to current control.
		''' </summary>
		Public Property PTS() As PTS
			Get
				Return _pts
			End Get

			Set(ByVal value As PTS)
				If _pts IsNot Nothing Then
					RemoveHandler _pts.Opened, AddressOf pts_Opened
					RemoveHandler _pts.Closed, AddressOf pts_Closed
				End If

				_pts = value
				_settingDialog.PTS = _pts

				If _pts IsNot Nothing Then
					AddHandler _pts.Opened, AddressOf pts_Opened
					AddHandler _pts.Closed, AddressOf pts_Closed
				End If
			End Set
		End Property

		''' <summary>
		''' Starts querying ATG, which have IsActive property equal to true, updates its visual state.
		''' </summary>
		Public Sub Start()
			If _atg IsNot Nothing Then
				If _atg.ID <> 0 AndAlso _atg.PhysicalAddress <> 0 Then
					_atg.IsActive = True
					refreshUI()
				Else
					_atg.IsActive = False
					refreshUI()
				End If
			End If
			refreshUI()
		End Sub

		''' <summary>
		''' Initializes ATG, which belongs to current control.
		''' </summary>
		Public Sub initializeAtg()
			If _atgId Is Nothing Then
				refreshUI()
				Return
			End If

			_atg = _pts.GetAtgByID(_atgId.Value)
			If _atg Is Nothing Then
				Return
			End If

			If Me.Created = True Then
				_atg.IsActive = True
				AddHandler _atg.DataUpdated, AddressOf atg_DataUpdated
			End If
			refreshUI()
		End Sub

		''' <summary>
		''' Uninitializes ATG, which belongs to current control.
		''' </summary>
		Public Sub uninitializeAtg()
			If Atg Is Nothing Then
				refreshUI()
				Return
			End If

			If Me.Created = True Then
				_atg.IsActive = False
				RemoveHandler _atg.DataUpdated, AddressOf atg_DataUpdated
			End If
			_atg = Nothing
			refreshUI()
		End Sub

		''' <summary>
		''' Updates a visual state of a current control.
		''' </summary>
		Public Sub refreshUI()
			If _atg Is Nothing Then
				atgAddressLabel.Text = "-"
				statusLabel.Text = "NOT ACTIVE"
				panelStatusLabel.BackColor = Color.LightGray
				statusLabel.ForeColor = Color.Black
				DisableAllMeasurementValues()
				lblTankHeightTop.Text = "NOT ACTIVE"
				lblTankHeightTop.Left = (CInt(Fix(100 - lblTankHeightTop.Size.Width))) / 2 + 14
				lblTankHeightTop.ForeColor = Color.LightGray
				lblTankHeight.Text = ""
			Else
				If _atg.PhysicalAddress = 0 OrElse _atg.ChannelID = 0 Then
					atgAddressLabel.Text = "-"
					statusLabel.Text = "NOT ACTIVE"
					panelStatusLabel.BackColor = Color.LightGray
					statusLabel.ForeColor = Color.Black
					DisableAllMeasurementValues()
					lblTankHeightTop.Text = "NOT ACTIVE"
					lblTankHeightTop.ForeColor = Color.LightGray
					lblTankHeight.Text = ""
				Else
					atgAddressLabel.Text = _atg.ID.ToString()
					statusLabel.Text = "ACTIVE"
					panelStatusLabel.BackColor = Color.Lime
					statusLabel.ForeColor = Color.Black
					lblTankHeightTop.Text = "Tank height"
					lblTankHeightTop.Left = (CInt(Fix(100 - lblTankHeightTop.Size.Width))) / 2 + 14
					lblTankHeightTop.ForeColor = Color.Black
					lblTankHeight.Text = _atg.MaxTankHeight.ToString() & " mm"
					lblTankHeight.Left = (CInt(Fix(100 - lblTankHeight.Size.Width))) / 2 + 14
					lblTankHeightTop.ForeColor = Color.Black
					tankControl1.setValue(CDbl(_atg.MaxTankHeight))
				End If
			End If
		End Sub

		''' <summary>
		''' Event occuring at closing of PTS connection.
		''' </summary>
		Private Sub pts_Closed(ByVal sender As Object, ByVal e As EventArgs)
			settingsButton.Enabled = False
			DisableAllMeasurementValues()
			atgAddressLabel.Text = "-"
			statusLabel.Text = "NOT ACTIVE"
			panelStatusLabel.BackColor = Color.LightGray
			statusLabel.ForeColor = Color.Black

			tankControl1.setValue(0)
		End Sub

		''' <summary>
		''' Event occuring at opening of PTS connection.
		''' </summary>
		Private Sub pts_Opened(ByVal sender As Object, ByVal e As EventArgs)
			settingsButton.Enabled = True
			If _atgId < 1 Then
				Return
			End If
			If _atgId Is Nothing Then
				Return
			End If

			Dim atg As ATG = _pts.GetAtgByID(_atgId.Value)

			If Me.Created = True Then
				If atg IsNot Nothing Then
					If atg.ID <> 0 AndAlso atg.PhysicalAddress <> 0 Then
						atg.IsActive = True
						AddHandler atg.DataUpdated, AddressOf atg_DataUpdated
						refreshUI()
					End If
				End If
			End If
		End Sub

		''' <summary>
		''' Updates a visual state of all controls to "NOT ACTIVE".
		''' </summary>
		Private Sub DisableAllMeasurementValues()
			For row As Integer = 1 To 9
				Dim lblValueName As Label = CType(tableLayoutPanel.Controls.Find("lblRow" & row.ToString() & "Col1", False)(0), Label)
				lblValueName.Font = New Font(lblValueName.Font, FontStyle.Regular)
				lblValueName.ForeColor = Color.LightGray

				Dim lblValueData As Label = CType(tableLayoutPanel.Controls.Find("lblRow" & row.ToString() & "Col2", False)(0), Label)
				lblValueData.ForeColor = Color.LightGray
				lblValueData.Text = "-"

				Dim lblValueUnit As Label = CType(tableLayoutPanel.Controls.Find("lblRow" & row.ToString() & "Col3", False)(0), Label)
				lblValueUnit.Font = New Font(lblValueUnit.Font, FontStyle.Regular)
				lblValueUnit.ForeColor = Color.LightGray
			Next row

			tankControl1.setValue(0)
		End Sub

		''' <summary>
		''' Updates data on measurements on the control.
		''' </summary>
		Private Sub DisplayValue(ByVal value As String, ByVal row As Integer)
			Dim lblValueName As Label = CType(tableLayoutPanel.Controls.Find("lblRow" & row.ToString() & "Col1", False)(0), Label)
			lblValueName.Font = New Font(lblValueName.Font, FontStyle.Bold)
			lblValueName.ForeColor = Color.Black

			Dim lblValueData As Label = CType(tableLayoutPanel.Controls.Find("lblRow" & row.ToString() & "Col2", False)(0), Label)
			lblValueData.ForeColor = Color.Black
			lblValueData.Text = value

			Dim lblValueUnit As Label = CType(tableLayoutPanel.Controls.Find("lblRow" & row.ToString() & "Col3", False)(0), Label)
			lblValueUnit.Font = New Font(lblValueUnit.Font, FontStyle.Bold)
			lblValueUnit.ForeColor = Color.Black
		End Sub

		''' <summary>
		''' Hides data on measurements on the control.
		''' </summary>
		Private Sub HideValue(ByVal row As Integer)
			Dim lblValueName As Label = CType(tableLayoutPanel.Controls.Find("lblRow" & row.ToString() & "Col1", False)(0), Label)
			lblValueName.Font = New Font(lblValueName.Font, FontStyle.Regular)
			lblValueName.ForeColor = Color.LightGray

			Dim lblValueData As Label = CType(tableLayoutPanel.Controls.Find("lblRow" & row.ToString() & "Col2", False)(0), Label)
			lblValueData.ForeColor = Color.LightGray
			lblValueData.Text = "-"

			Dim lblValueUnit As Label = CType(tableLayoutPanel.Controls.Find("lblRow" & row.ToString() & "Col3", False)(0), Label)
			lblValueUnit.Font = New Font(lblValueUnit.Font, FontStyle.Regular)
			lblValueUnit.ForeColor = Color.LightGray
		End Sub

		''' <summary>
		''' Event occures when data on measurement of ATG is received from PTS controller.
		''' </summary>
		Private Sub atg_DataUpdated(ByVal sender As Object, ByVal e As EventArgs)
			Dim atg As ATG = CType(sender, ATG)

			If atg IsNot Nothing AndAlso _atgId IsNot Nothing Then
				Invoke(New Action(Sub() refreshData(atg)))
			End If
		End Sub

		''' <summary>
		''' Refreshed data on measurement of ATG displayed on the control.
		''' </summary>
		Private Sub refreshData(ByVal atg As ATG)
			If Me._atg.ID <> atg.ID Then
				Return
			End If

			' Display product height
			If atg.ProductHeightPresent Then
				DisplayValue(atg.ProductHeight.ToString(), 1)
				tankControl1.MaxValue = atg.MaxTankHeight
				tankControl1.setValue(atg.ProductHeight)
			Else
				HideValue(1)
			End If

			' Display product volume
			If atg.ProductVolumePresent Then
				DisplayValue(atg.ProductVolume.ToString(), 2)
			Else
				HideValue(2)
			End If

			' Display product temperature compensated volume
			If atg.ProductTCVolumePresent Then
				DisplayValue(atg.ProductTCVolume.ToString(), 3)
			Else
				HideValue(3)
			End If

			' Display product ullage volume
			If atg.ProductUllagePresent Then
				DisplayValue(atg.ProductUllage.ToString(), 4)
			Else
				HideValue(4)
			End If

			' Display water height
			If atg.WaterHeightPresent Then
				DisplayValue(atg.WaterHeight.ToString(), 5)
			Else
				HideValue(5)
			End If

			' Display water volume
			If atg.WaterVolumePresent Then
				DisplayValue(atg.WaterVolume.ToString(), 6)
			Else
				HideValue(6)
			End If

			' Display temperature
			If atg.TemperaturePresent Then
				DisplayValue(atg.Temperature.ToString(), 7)
			Else
				HideValue(7)
			End If

			' Display product density
			If atg.ProductDensityPresent Then
				DisplayValue(atg.ProductDensity.ToString(), 8)
			Else
				HideValue(8)
			End If

			' Display product mass
			If atg.ProductMassPresent Then
				DisplayValue(atg.ProductMass.ToString(), 9)
			Else
				HideValue(9)
			End If


		End Sub

		''' <summary>
		''' Event occures when settingsButton is clicked.
		''' </summary>
		Private Sub settingsButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles settingsButton.Click
			Dim oldAtgID? As Integer = AtgID
			Dim newAtgID? As Integer = Nothing

			Dim parent As AtgMainForm = TryCast(TopLevelControl, AtgMainForm)

			If _settingDialog.ShowDialog() = DialogResult.OK Then
				newAtgID = _settingDialog.AtgID

				If Not oldAtgID.Equals(newAtgID) Then
					If oldAtgID Is Nothing Then
						'no Atg to disactivate, 
						'activate a new Atg
						AtgID = newAtgID
						If AtgID IsNot Nothing Then
							initializeAtg()
						End If
					Else
						If newAtgID Is Nothing Then
							'disactivate old Atg, 
							'no Atg to activate
							If parent IsNot Nothing AndAlso parent.AtgHasUniqueID(CInt(Fix(oldAtgID))) Then
								AtgID = oldAtgID
								If _atg IsNot Nothing Then
									uninitializeAtg()
								End If
							End If
							AtgID = newAtgID
						Else
							'disactivate old Atg,
							'activate a new Atg
							If parent IsNot Nothing AndAlso parent.AtgHasUniqueID(CInt(Fix(oldAtgID))) Then
								AtgID = oldAtgID
								If _atg IsNot Nothing Then
									uninitializeAtg()
								End If
							End If
							AtgID = newAtgID
							If _atg IsNot Nothing Then
								initializeAtg()
							End If
						End If
					End If
				End If

				If parent.MainForm IsNot Nothing Then
					parent.MainForm.SaveConfiguration()
					parent.MainForm.LoadConfiguration()
				End If
			End If
		End Sub

		''' <summary>
		''' Event occures at loading of the control
		''' </summary>
		Private Sub AtgControl_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			If _atg IsNot Nothing Then
				If _atg.ID <> 0 AndAlso _atg.PhysicalAddress <> 0 Then
					_atg.IsActive = True
					AddHandler _atg.DataUpdated, AddressOf atg_DataUpdated
					refreshUI()
				End If
			End If
		End Sub
	End Class
End Namespace

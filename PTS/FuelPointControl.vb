Imports System.ComponentModel
Imports System.Text
Imports System.Threading

Namespace TiT.PTS
	Partial Public Class FuelPointControl
		Inherits UserControl
		Private _settingDialog As FuelPointSettingDialog
		Private _fuelPoint As FuelPoint = Nothing
		Private _pts As PTS = Nothing
		Private _totalsDialog As TotalsDialog
		Private _updateThread As Thread
		Private _valChanged As Boolean = False
		Private _fpInitialized As Boolean = False
		Private _fuelPointId? As Integer = Nothing
		Private _isDispensing As Boolean = False
		Private _isLocked As Boolean = False
		Private _readyStatusAuthCounter As Integer = 0
		Private _delay As Short = 20
    Private productname1 As String = "Diesel"
    Private productname2 As String = "Unleaded"
    Private productname3 As String = "Premium"
    Private Counterqwe As Integer = 0
    Private cmdPTAdd As New CmdComandPumpTransactionInsert
    Private cmdPN As New CmdPruductName
    Private cmdShowPT As New CmdShowPumpTransaction
    Private Cmdtp As New CmdComandTotalizer
    Public Event OnTransaction()
    Dim count123 As Integer = 0
    Public Sub New()
			InitializeComponent()
			_settingDialog = New FuelPointSettingDialog()
      statusLabel.Text = FuelPointStatus.OFFLINE.ToString()
      lbState.Text = statusLabel.Text
      _totalsDialog = New TotalsDialog()

      comboBoxDispenseMode.DataSource = System.Enum.GetValues(GetType(OrderModes))
      comboBoxDispenseMode.SelectedIndex = 1
    End Sub

		Protected Overrides Sub OnPaint(ByVal pe As PaintEventArgs)
			Dim _borderPen As New Pen(Color.Gold, 2)

			MyBase.OnPaint(pe)
			Dim g As Graphics = pe.Graphics
			g.DrawRectangle(_borderPen, New Rectangle(0, 0, Width, Height))
		End Sub

		Public Property FuelPointID() As Integer?
			Get
				Return _fuelPointId
			End Get
			Set(ByVal value? As Integer)
				If value < 1 OrElse value > PtsConfiguration.FuelPointQuantity Then
					Throw New ArgumentOutOfRangeException()
				End If
				If _fuelPoint IsNot Nothing Then
					uninitializeFuelPoint()
				End If

				_fuelPointId = value
				_settingDialog.FuelPointID = _fuelPointId
				initializeFuelPoint()
				refreshUI()
			End Set
		End Property

		Public ReadOnly Property FuelPoint() As FuelPoint
			Get
				Return _fuelPoint
			End Get
		End Property
    Public Sub changePrice(nozzle As Integer, Price As Integer)

      _fuelPoint.Nozzles(nozzle - 1).PricePerLiter = Price
      _fuelPoint.SetPrices()
      Dim cit As New CmdInsertTender
      cit.updateitem(_fuelPoint.ID, nozzle)
    End Sub
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

		Public Property IsLocked() As Boolean
			Get
				Return _isLocked
			End Get
			Set(ByVal value As Boolean)
				_isLocked = value
			End Set
		End Property

		Public Property IsDispensing() As Boolean
			Get
				Return _isDispensing
			End Get
			Set(ByVal value As Boolean)
				_isDispensing = value
			End Set
		End Property

		Public ReadOnly Property PortIsOpened() As Boolean
			Get
				If _pts Is Nothing Then
					Return False
				End If

				Return _pts.IsOpen
			End Get
		End Property

		Public Sub Start()
			setControlUI(True)
			refreshStatus()

			If _fuelPoint IsNot Nothing Then
				_fuelPoint.IsActive = True
			End If
		End Sub

		Public Sub [Stop]()
			_fuelPoint.Halt()
		End Sub

		Public Sub SetDigits()
			paymentUpDown.DecimalPlaces = CInt(Fix(GlobalVariables.AmountDigits))
			volumeUpDown.DecimalPlaces = CInt(Fix(GlobalVariables.VolumeDigits))
		End Sub

		Private Sub initializeFuelPoint()
			If _fpInitialized OrElse _fuelPointId Is Nothing Then
				refreshUI()
				Return
			End If

			_fuelPoint = _pts.GetFuelPointByID(_fuelPointId.Value)

			If _fuelPoint Is Nothing Then
				Return
			End If

			_totalsDialog.FuelPoint = _fuelPoint
			_totalsDialog.PTS = _pts
			AddHandler _fuelPoint.NozzleChanged, AddressOf fuelPoint_NozzleChanged
			AddHandler _fuelPoint.StatusChanged, AddressOf fuelPoint_StatusChanged
			AddHandler _fuelPoint.TransactionFinished, AddressOf fuelPoint_TransactionFinished
			_fpInitialized = True
			refreshUI()

      productname1 = cmdPN.ProductName(_fuelPointId.Value, 1)
      productname2 = cmdPN.ProductName(_fuelPointId.Value, 2)
      productname3 = cmdPN.ProductName(_fuelPointId.Value, 3)
      If _pts.IsOpen Then
				setControlUI(True)
			End If
		End Sub

		Private Sub fuelPoint_NozzleChanged(ByVal sender As Object, ByVal e As NozzleChangedEventArgs)
			If FuelPoint Is Nothing Then
				Return
			End If

			If FuelPoint.Status = FuelPointStatus.ERROR AndAlso FuelPoint.ActiveNozzle Is Nothing Then
				FuelPoint.Status = FuelPointStatus.READY
			End If

			If FuelPoint.Status = FuelPointStatus.READY AndAlso FuelPoint.ActiveNozzle IsNot Nothing AndAlso nozzleUpDown.Value <> Convert.ToDecimal(FuelPoint.ActiveNozzleID) Then
				FuelPoint.Status = FuelPointStatus.ERROR
			End If

			If FuelPoint.Status = FuelPointStatus.READY AndAlso FuelPoint.ActiveNozzle Is Nothing AndAlso _fuelPoint.OrderMode = OrderModes.Manual AndAlso _pts.AutomaticAuthorize Then
				timerAutomaticAuthorize.Stop()
				If timerAutomaticAuthorize.Enabled = True Then
					RemoveHandler timerAutomaticAuthorize.Tick, AddressOf timerAutomaticAuthorize_Tick
					timerAutomaticAuthorize.Enabled = False
				End If

				Invoke(New Action(Sub() stopButton.PerformClick()))
			End If

			Invoke(New Action(Sub() refreshUI()))
		End Sub

		Private Sub uninitializeFuelPoint()
			If _fuelPoint Is Nothing Then
				refreshUI()
				Return
			End If

			RemoveHandler _fuelPoint.StatusChanged, AddressOf fuelPoint_StatusChanged
			RemoveHandler _fuelPoint.TransactionFinished, AddressOf fuelPoint_TransactionFinished
			_fuelPoint = Nothing
			_fpInitialized = False
			refreshUI()
		End Sub

		Private Sub refreshStatus()
			If _fuelPoint IsNot Nothing Then
				Invoke(New Action(Sub() refreshUI()))
			End If
		End Sub

    Public Sub refreshUI()
      Counterqwe = Counterqwe + 1
      If Counterqwe = 3 Then
        Counterqwe = 0
      End If
      If _fuelPoint Is Nothing Then
        pumpAddressLabel.Text = "-"
        lbID.Text = pumpAddressLabel.Text
        statusLabel.Text = "OFFLINE"
        lbState.Text = statusLabel.Text
        panelStatusLabel.BackColor = Color.LightGray
        statusLabel.ForeColor = Color.Black
        nozzleUpDown.Value = 0
        nozzleUpDown.Enabled = False
        If nozzleUpDown.Value = 0 Then
          LBProduct.Text = "Nozzle is Down"
        ElseIf nozzleUpDown.Value = 1 Then
          LBProduct.Text = $"{productname1}({priceLabel.Text})"
        ElseIf nozzleUpDown.Value = 2 Then
          LBProduct.Text = $"{productname2}({priceLabel.Text})"
        ElseIf nozzleUpDown.Value = 3 Then
          LBProduct.Text = $"{productname3}({priceLabel.Text})"
        End If
        Select Case GlobalVariables.PriceDigits
          Case 0
            priceLabel.Text = "0"
          Case 1
            priceLabel.Text = "0.0"
          Case 2
            priceLabel.Text = "0.00"
          Case 3
            priceLabel.Text = "0.000"
        End Select
        Select Case GlobalVariables.AmountCounterDigits
          Case 0
            txbAmoTotalValue.Text = "0"
          Case 1
            txbAmoTotalValue.Text = "0.0"
          Case 2
            txbAmoTotalValue.Text = "0.00"
          Case 3
            txbAmoTotalValue.Text = "0.000"
        End Select
        Select Case GlobalVariables.VolumeCounterDigits
          Case 2
            txbVolTotalValue.Text = "0.00"
          Case 3
            txbVolTotalValue.Text = "0.000"
        End Select

        pbTotalsRequest.Visible = False
        lblExecutedCommand.Text = ""
        setControlUI(False)
        Return
      Else
        If _fuelPoint.PhysicalAddress = 0 OrElse _fuelPoint.ChannelID = 0 Then
          pumpAddressLabel.Text = "-"
          statusLabel.Text = "OFFLINE"
          lbID.Text = pumpAddressLabel.Text
          lbState.Text = statusLabel.Text
          panelStatusLabel.BackColor = Color.LightGray
          statusLabel.ForeColor = Color.Black
          nozzleUpDown.Value = 0
          nozzleUpDown.Enabled = False
          If nozzleUpDown.Value = 0 Then
            LBProduct.Text = "Nozzle is Down"
          ElseIf nozzleUpDown.Value = 1 Then
            LBProduct.Text = $"{productname1}({priceLabel.Text})"
          ElseIf nozzleUpDown.Value = 2 Then
            LBProduct.Text = $"{productname2}({priceLabel.Text})"
          ElseIf nozzleUpDown.Value = 3 Then
            LBProduct.Text = $"{productname3}({priceLabel.Text})"
          End If
          Select Case GlobalVariables.PriceDigits
            Case 0
              priceLabel.Text = "0"
            Case 1
              priceLabel.Text = "0.0"
            Case 2
              priceLabel.Text = "0.00"
            Case 3
              priceLabel.Text = "0.000"
          End Select
          Select Case GlobalVariables.AmountCounterDigits
            Case 0
              txbAmoTotalValue.Text = "0"
            Case 1
              txbAmoTotalValue.Text = "0.0"
            Case 2
              txbAmoTotalValue.Text = "0.00"
            Case 3
              txbAmoTotalValue.Text = "0.000"
          End Select
          Select Case GlobalVariables.VolumeCounterDigits
            Case 2
              txbVolTotalValue.Text = "0.00"
            Case 3
              txbVolTotalValue.Text = "0.000"
          End Select

          pbTotalsRequest.Visible = False
          lblExecutedCommand.Text = ""
          setControlUI(False)
          Return
        End If

        If Convert.ToInt32(nozzleUpDown.Value) = 0 Then
          'priceLabel.Text = "0.00";
          Select Case GlobalVariables.PriceDigits
            Case 0
              priceLabel.Text = "0"
            Case 1
              priceLabel.Text = "0.0"
            Case 2
              priceLabel.Text = "0.00"
            Case 3
              priceLabel.Text = "0.000"
          End Select
          Select Case GlobalVariables.AmountCounterDigits
            Case 0
              txbAmoTotalValue.Text = "0"
            Case 1
              txbAmoTotalValue.Text = "0.0"
            Case 2
              txbAmoTotalValue.Text = "0.00"
            Case 3
              txbAmoTotalValue.Text = "0.000"
          End Select
          Select Case GlobalVariables.VolumeCounterDigits
            Case 2
              txbVolTotalValue.Text = "0.00"
            Case 3
              txbVolTotalValue.Text = "0.000"
          End Select
        End If

        pumpAddressLabel.Text = _fuelPoint.ID.ToString()
        lbID.Text = pumpAddressLabel.Text
        statusLabel.Text = _fuelPoint.Status.ToString()
        lbState.Text = statusLabel.Text
        setControlUI(True)

        If _fuelPoint.ActiveNozzle IsNot Nothing Then
          If _fuelPoint.Status = FuelPointStatus.ERROR Then
            'do nothing
          ElseIf _fuelPoint.Status = FuelPointStatus.READY AndAlso nozzleUpDown.Value <> Convert.ToDecimal(_fuelPoint.ActiveNozzleID) Then
            _fuelPoint.Status = FuelPointStatus.ERROR
          Else
            nozzleUpDown.Value = Decimal.Parse(_fuelPoint.ActiveNozzleID.ToString())
            nozzleUpDown.Enabled = False

            Select Case GlobalVariables.PriceDigits
              Case 0
                priceLabel.Text = String.Format("{0:F0}", Convert.ToDouble(_fuelPoint.ActiveNozzle.PricePerLiter) / 1)
              Case 1
                priceLabel.Text = String.Format("{0:F1}", Convert.ToDouble(_fuelPoint.ActiveNozzle.PricePerLiter) / 10)
              Case 2
                priceLabel.Text = String.Format("{0:F2}", Convert.ToDouble(_fuelPoint.ActiveNozzle.PricePerLiter) / 100)
              Case 3
                priceLabel.Text = String.Format("{0:F3}", Convert.ToDouble(_fuelPoint.ActiveNozzle.PricePerLiter) / 1000)
            End Select
            Select Case GlobalVariables.AmountCounterDigits
              Case 0
                txbAmoTotalValue.Text = String.Format("{0:F0}", CDbl(_fuelPoint.Nozzles(_fuelPoint.ActiveNozzleID - 1).TotalDispensedAmount) / 1)
              Case 1
                txbAmoTotalValue.Text = String.Format("{0:F1}", CDbl(_fuelPoint.Nozzles(_fuelPoint.ActiveNozzleID - 1).TotalDispensedAmount) / 10)
              Case 2
                txbAmoTotalValue.Text = String.Format("{0:F2}", CDbl(_fuelPoint.Nozzles(_fuelPoint.ActiveNozzleID - 1).TotalDispensedAmount) / 100)
              Case 3
                txbAmoTotalValue.Text = String.Format("{0:F3}", CDbl(_fuelPoint.Nozzles(_fuelPoint.ActiveNozzleID - 1).TotalDispensedAmount) / 1000)
            End Select
            Select Case GlobalVariables.VolumeCounterDigits
              Case 2
                txbVolTotalValue.Text = String.Format("{0:F2}", CDbl(_fuelPoint.Nozzles(_fuelPoint.ActiveNozzleID - 1).TotalDispensedVolume) / 100)
              Case 3
                txbVolTotalValue.Text = String.Format("{0:F3}", CDbl(_fuelPoint.Nozzles(_fuelPoint.ActiveNozzleID - 1).TotalDispensedVolume) / 1000)
            End Select
          End If
        Else
          nozzleUpDown.Enabled = True
          Dim nozzleId As Integer = Convert.ToInt32(nozzleUpDown.Value)

          If nozzleId = 0 Then
            Select Case GlobalVariables.AmountCounterDigits
              Case 0
                txbAmoTotalValue.Text = "0"
              Case 1
                txbAmoTotalValue.Text = "0.0"
              Case 2
                txbAmoTotalValue.Text = "0.00"
              Case 3
                txbAmoTotalValue.Text = "0.000"
            End Select
            Select Case GlobalVariables.VolumeCounterDigits
              Case 2
                txbVolTotalValue.Text = "0.00"
              Case 3
                txbVolTotalValue.Text = "0.000"
            End Select
          Else
            Select Case GlobalVariables.AmountCounterDigits
              Case 0
                txbAmoTotalValue.Text = String.Format("{0:F0}", CDbl(_fuelPoint.Nozzles(nozzleId - 1).TotalDispensedAmount) / 1)
              Case 1
                txbAmoTotalValue.Text = String.Format("{0:F1}", CDbl(_fuelPoint.Nozzles(nozzleId - 1).TotalDispensedAmount) / 10)
              Case 2
                txbAmoTotalValue.Text = String.Format("{0:F2}", CDbl(_fuelPoint.Nozzles(nozzleId - 1).TotalDispensedAmount) / 100)
              Case 3
                txbAmoTotalValue.Text = String.Format("{0:F3}", CDbl(_fuelPoint.Nozzles(nozzleId - 1).TotalDispensedAmount) / 1000)
            End Select
            Select Case GlobalVariables.VolumeCounterDigits
              Case 2
                txbVolTotalValue.Text = String.Format("{0:F2}", CDbl(_fuelPoint.Nozzles(nozzleId - 1).TotalDispensedVolume) / 100)
              Case 3
                txbVolTotalValue.Text = String.Format("{0:F3}", CDbl(_fuelPoint.Nozzles(nozzleId - 1).TotalDispensedVolume) / 1000)
            End Select
          End If
        End If
      End If

      Select Case _fuelPoint.Status

        Case FuelPointStatus.IDLE
          PictureBox1.BackgroundImageLayout = ImageLayout.Center
          Dim img = Image.FromFile("Image\lock.jpg")
          Dim img2 As New Bitmap(img, PictureBox1.Width, PictureBox1.Height)
          PictureBox1.Image = img2
          panelStatusLabel.BackColor = Color.LightBlue
          statusLabel.ForeColor = Color.Blue

          If _fuelPoint.CurrentPendingCommand <> 0 Then
            lblExecutedCommand.Text = "'" & (ChrW(_fuelPoint.CurrentPendingCommand)).ToString() & "' (0x" & _fuelPoint.CurrentPendingCommand.ToString("X") & ")"
            If (ChrW(_fuelPoint.CurrentPendingCommand)).ToString() = "H" Then
              Invoke(New Action(Sub() stopz()))
            End If
          Else
            lblExecutedCommand.Text = ""
          End If


        Case FuelPointStatus.NOZZLE
          PictureBox1.BackgroundImageLayout = ImageLayout.Center
          Dim img = Image.FromFile("Image\2.jpg")
          Dim img2 As New Bitmap(img, PictureBox1.Width, PictureBox1.Height)
          PictureBox1.Image = img2

          panelStatusLabel.BackColor = Color.Lime
          statusLabel.ForeColor = Color.Black

          If _fuelPoint.CurrentPendingCommand <> 0 Then
            lblExecutedCommand.Text = "'" & (ChrW(_fuelPoint.CurrentPendingCommand)).ToString() & "' (0x" & _fuelPoint.CurrentPendingCommand.ToString("X") & ")"
            If (ChrW(_fuelPoint.CurrentPendingCommand)).ToString() = "H" Then
              _stopButton.PerformClick()
            End If
          Else
            lblExecutedCommand.Text = ""
          End If

          'If _fuelPoint.OrderMode = OrderModes.Manual AndAlso _pts.AutomaticAuthorize Then


          If timerAutomaticAuthorize.Enabled = False Then


            'timerAutomaticAuthorize.Interval = 1000
            AddHandler timerAutomaticAuthorize.Tick, AddressOf timerAutomaticAuthorize_Tick
            timerAutomaticAuthorize.Enabled = True
            timerAutomaticAuthorize.Start()
          End If


          'End If
          '

        Case FuelPointStatus.OFFLINE

          PictureBox1.BackgroundImageLayout = ImageLayout.Center
          Dim img = Image.FromFile("Image\99.jpg")
          Dim img2 As New Bitmap(img, PictureBox1.Width, PictureBox1.Height)
          PictureBox1.Image = img2

          panelStatusLabel.BackColor = Color.LightGray
          statusLabel.ForeColor = Color.Black

        Case FuelPointStatus.READY

          PictureBox1.BackgroundImageLayout = ImageLayout.Center
          Dim img = Image.FromFile("Image\0.jpg")
          Dim img2 As New Bitmap(img, PictureBox1.Width, PictureBox1.Height)
          PictureBox1.Image = img2


          panelStatusLabel.BackColor = Color.Yellow
          statusLabel.ForeColor = Color.Red

          If _fuelPoint.CurrentPendingCommand <> 0 Then
            lblExecutedCommand.Text = "'" & (ChrW(_fuelPoint.CurrentPendingCommand)).ToString() & "' (0x" & _fuelPoint.CurrentPendingCommand.ToString("X") & ")"
          Else
            lblExecutedCommand.Text = ""
          End If

          If _pts.AuthorizationPolling Then
            _readyStatusAuthCounter += 1
            If _readyStatusAuthCounter = _delay Then
              ThrowAuthorizationCommand()
              _readyStatusAuthCounter = 0
            End If
          End If


        Case FuelPointStatus.ERROR
          Invoke(New Action(Sub() stopz()))

          PictureBox1.BackgroundImageLayout = ImageLayout.Center
          Dim img = Image.FromFile("Image\99.jpg")
          Dim img2 As New Bitmap(img, PictureBox1.Width, PictureBox1.Height)
          PictureBox1.Image = img2

          panelStatusLabel.BackColor = Color.Red
          statusLabel.ForeColor = Color.White

        Case FuelPointStatus.WORK
          panelStatusLabel.BackColor = Color.Blue
          statusLabel.ForeColor = Color.White

          RemoveHandler volumeUpDown.ValueChanged, AddressOf volumeUpDown_ValueChanged
          RemoveHandler paymentUpDown.ValueChanged, AddressOf paymentUpDown_ValueChanged


          PictureBox1.BackgroundImageLayout = ImageLayout.Center
          Dim img
          If Counterqwe = 0 Then
            img = Image.FromFile("Image\a.jpg")
          ElseIf Counterqwe = 1 Then
            img = Image.FromFile("Image\b.jpg")
          ElseIf Counterqwe = 2 Then
            img = Image.FromFile("Image\c.jpg")
          End If
          Dim img2 As New Bitmap(img, PictureBox1.Width, PictureBox1.Height)
          PictureBox1.Image = img2





          'volumeUpDown.Value = Convert.ToDecimal(fuelPoint.DispensedVolume) / 100;
          Select Case GlobalVariables.VolumeDigits
            Case 2
              volumeUpDown.Value = Convert.ToDecimal(_fuelPoint.DispensedVolume) / 100
            Case 3
              volumeUpDown.Value = Convert.ToDecimal(_fuelPoint.DispensedVolume) / 1000
          End Select

          'paymentUpDown.Value = Convert.ToDecimal(volumeUpDown.Value * fuelPoint.ActiveNozzle.PricePerLiter / 100);
          'paymentUpDown.Value = Convert.ToDecimal(volumeUpDown.Value * fuelPoint.Nozzles[Convert.ToInt32(nozzleUpDown.Value) - 1].PricePerLiter / 100);
          Select Case GlobalVariables.AmountDigits
            Case 0
              paymentUpDown.Value = Convert.ToDecimal(volumeUpDown.Value * _fuelPoint.Nozzles(Convert.ToInt32(nozzleUpDown.Value) - 1).PricePerLiter) / 1
            Case 1
              paymentUpDown.Value = Convert.ToDecimal(volumeUpDown.Value * _fuelPoint.Nozzles(Convert.ToInt32(nozzleUpDown.Value) - 1).PricePerLiter) / 10
            Case 2
              paymentUpDown.Value = Convert.ToDecimal(volumeUpDown.Value * _fuelPoint.Nozzles(Convert.ToInt32(nozzleUpDown.Value) - 1).PricePerLiter) / 100
            Case 3
              paymentUpDown.Value = Convert.ToDecimal(volumeUpDown.Value * _fuelPoint.Nozzles(Convert.ToInt32(nozzleUpDown.Value) - 1).PricePerLiter) / 1000
          End Select
          If nozzleUpDown.Value = 0 Then
            LBProduct.Text = "Nozzle is Down"
          ElseIf nozzleUpDown.Value = 1 Then
            LBProduct.Text = $"{productname1}({priceLabel.Text})"
          ElseIf nozzleUpDown.Value = 2 Then
            LBProduct.Text = $"{productname2}({priceLabel.Text})"
          ElseIf nozzleUpDown.Value = 3 Then
            LBProduct.Text = $"{productname3}({priceLabel.Text})"
          End If
          LbAmount.Text = "P" & paymentUpDown.Value.ToString
          LBLiters.Text = volumeUpDown.Value.ToString & "L"




          AddHandler volumeUpDown.ValueChanged, AddressOf volumeUpDown_ValueChanged
          AddHandler paymentUpDown.ValueChanged, AddressOf paymentUpDown_ValueChanged

          If _fuelPoint.CurrentPendingCommand <> 0 Then
            lblExecutedCommand.Text = "'" & (ChrW(_fuelPoint.CurrentPendingCommand)).ToString() & "' (0x" & _fuelPoint.CurrentPendingCommand.ToString("X") & ")"
          Else
            lblExecutedCommand.Text = ""
          End If



          If _updateThread IsNot Nothing AndAlso _updateThread.IsAlive <> True Then
            _updateThread.Start()
            _isDispensing = True
            setControlUI(False)
          End If

      End Select
    End Sub

    Public Sub setControlUI(ByVal val As Boolean)
      If _isLocked OrElse _fuelPoint Is Nothing Then
        stopButton.Enabled = False
        startButton.Enabled = stopButton.Enabled
        comboBoxDispenseMode.Enabled = False
        volumeUpDown.Enabled = comboBoxDispenseMode.Enabled
        paymentUpDown.Enabled = volumeUpDown.Enabled
        totalsButton.Enabled = paymentUpDown.Enabled
        settingsButton.Enabled = Me.PortIsOpened
        Return
      End If

      If _isDispensing Then
				startButton.Enabled = False
				stopButton.Enabled = True
				settingsButton.Enabled = False
				comboBoxDispenseMode.Enabled = False
				volumeUpDown.Enabled = comboBoxDispenseMode.Enabled
				paymentUpDown.Enabled = volumeUpDown.Enabled
				totalsButton.Enabled = paymentUpDown.Enabled
				Return
			End If

			If _fuelPoint.OrderMode = OrderModes.Preset Then
				paymentUpDown.Enabled = True
				volumeUpDown.Enabled = paymentUpDown.Enabled
				comboBoxDispenseMode.Enabled = val
				totalsButton.Enabled = comboBoxDispenseMode.Enabled
			Else
				paymentUpDown.Enabled = False
				volumeUpDown.Enabled = paymentUpDown.Enabled
				comboBoxDispenseMode.Enabled = val
				totalsButton.Enabled = comboBoxDispenseMode.Enabled
			End If


			settingsButton.Enabled = True
			checkStartButton()
		End Sub

		Private Sub checkStartButton()
			If _isLocked Then
				startButton.Enabled = False
				Return
			End If

			If _fuelPoint Is Nothing Then
				startButton.Enabled = False
				Return
			End If

			If _isDispensing Then
				startButton.Enabled = False
				Return
			End If

			If _fuelPoint.Status = FuelPointStatus.OFFLINE Then
				startButton.Enabled = False
				Return
			End If

			If _fuelPoint.Status = FuelPointStatus.ERROR Then
				startButton.Enabled = False
				stopButton.Enabled = False
				Return
			End If

			If _fuelPoint.Status = FuelPointStatus.READY Then
				startButton.Enabled = True
				stopButton.Enabled = True
				Return
			End If

			If FuelPoint.OrderMode = OrderModes.Preset Then
				'if (fuelPoint.ActiveNozzle == null || fuelPoint.ActiveNozzle.PricePerLiter == 0 || paymentUpDown.Value == 0 || volumeUpDown.Value == 0)
				'if (fuelPoint.ActiveNozzle.PricePerLiter == 0)
				If Convert.ToInt32(nozzleUpDown.Value) = 0 Then
					startButton.Enabled = False
				'else if(fuelPoint.Nozzles[Convert.ToInt32(nozzleUpDown.Value) - 1].PricePerLiter == 0)
				'    startButton.Enabled = false;
				Else
					startButton.Enabled = True
				End If
			Else
				'if (fuelPoint.ActiveNozzle == null || fuelPoint.ActiveNozzle.PricePerLiter == 0)
				'if (fuelPoint.ActiveNozzle.PricePerLiter == 0)
				If Convert.ToInt32(nozzleUpDown.Value) = 0 Then
					startButton.Enabled = False
				'else if (fuelPoint.Nozzles[Convert.ToInt32(nozzleUpDown.Value) - 1].PricePerLiter == 0)
				'    startButton.Enabled = false;
				Else
					startButton.Enabled = True
				End If
			End If

		End Sub

		Private Sub setOrderMode(ByVal val As OrderModes)
			If val = OrderModes.Preset Then
				volumeUpDown.Enabled = True
				paymentUpDown.Enabled = volumeUpDown.Enabled
			Else
				volumeUpDown.Enabled = False
				paymentUpDown.Enabled = volumeUpDown.Enabled
			End If

			checkStartButton()
		End Sub

		Private Sub UpdateTotals(ByVal nozzleId As Integer)
			Invoke(New Action(Sub() pbTotalsRequest.Visible = True))
			_fuelPoint.Nozzles(nozzleId).UpdateTotals()
		End Sub

		Private Sub fuelPoint_TotalsUpdated(ByVal sender As Object, ByVal e As TotalsEventArgs)
			If (e.Address <> _fuelPoint.ID) OrElse (e.NozzleID <> _fuelPoint.ActiveNozzleID) Then
				Invoke(New Action(Sub() pbTotalsRequest.Visible = True))
			Else
				RemoveHandler _fuelPoint.TotalsUpdated, AddressOf fuelPoint_TotalsUpdated
				Invoke(New Action(Sub()
					pbTotalsRequest.Visible = False
					RemoveHandler _fuelPoint.PendingCommandChanged, AddressOf fuelPoint_PendingCommandChanged
					_fuelPoint.TransFinished = False
					Select Case GlobalVariables.AmountCounterDigits
						Case 0
							txbAmoTotalValue.Text = String.Format("{0:F0}", CDbl(_fuelPoint.Nozzles(e.NozzleID - 1).TotalDispensedAmount) / 1)
							Case 1
								txbAmoTotalValue.Text = String.Format("{0:F1}", CDbl(_fuelPoint.Nozzles(e.NozzleID - 1).TotalDispensedAmount) / 10)
								Case 2
									txbAmoTotalValue.Text = String.Format("{0:F2}", CDbl(_fuelPoint.Nozzles(e.NozzleID - 1).TotalDispensedAmount) / 100)
									Case 3
										txbAmoTotalValue.Text = String.Format("{0:F3}", CDbl(_fuelPoint.Nozzles(e.NozzleID - 1).TotalDispensedAmount) / 1000)
					End Select
					Select Case GlobalVariables.VolumeCounterDigits
						Case 2
							txbVolTotalValue.Text = String.Format("{0:F2}", CDbl(_fuelPoint.Nozzles(e.NozzleID - 1).TotalDispensedVolume) / 100)
							Case 3
								txbVolTotalValue.Text = String.Format("{0:F3}", CDbl(_fuelPoint.Nozzles(e.NozzleID - 1).TotalDispensedVolume) / 1000)
					End Select
				End Sub))



        Dim _Dispenser As Integer = Integer.Parse(_fuelPointId.Value.ToString)
        Dim _nozzle As Integer = Integer.Parse(nozzleUpDown.Text)
        Dim _UnitPrice As Decimal = Decimal.Parse(priceLabel.Text)
        Dim _Amount As Decimal = Decimal.Parse(txbAmoTotalValue.Text.ToString)
        Dim _Volume As Decimal = Decimal.Parse(txbVolTotalValue.Text.ToString)



        'Invoke(New Action(Sub() Cmdtp.UpdateTolizer(_Dispenser, _nozzle, _Amount, _Volume)))

        If _fuelPoint.Locked Then
					_fuelPoint.Unlock()
				End If
			End If

			Return
		End Sub

		Private Sub fuelPoint_PendingCommandChanged(ByVal sender As Object, ByVal e As PendingCommandChangedEventArgs)
			If _fuelPoint.TransFinished = True Then
				If e.CurrentPendingCommand = 0 Then
					If _fuelPoint.Locked = True Then
						AddHandler _fuelPoint.TotalsUpdated, AddressOf fuelPoint_TotalsUpdated
						UpdateTotals(_fuelPoint.TransactionNozzleID - 1)
					End If
				End If
			End If

			Return
		End Sub

		Private Sub pts_Closed(ByVal sender As Object, ByVal e As EventArgs)
			uninitializeFuelPoint()
			setControlUI(False)
		End Sub

		Private Sub pts_Opened(ByVal sender As Object, ByVal e As EventArgs)
			If _fuelPointId IsNot Nothing Then
				initializeFuelPoint()
			Else
				Return
			End If

			setControlUI(True)
		End Sub

		Private Sub fuelPoint_StatusChanged(ByVal sender As Object, ByVal e As StatusChangedEventArgs)
			'Invoke(new Action(() =>
			'{
			'    paymentUpDown.Value += 0.001M;
			'    paymentUpDown.Value -= 0.001M;
			'}));
			refreshStatus()
		End Sub

		Private Sub fuelPoint_TransactionFinished(ByVal sender As Object, ByVal e As TransactionEventArgs)
			_isDispensing = False

			If _updateThread IsNot Nothing Then
				_updateThread.Abort()
				'updateThread.Join();
				_updateThread = Nothing

				If _fuelPoint.TransactionNozzleID <> 0 AndAlso _pts.RequestTotalizers = True AndAlso _fuelPoint.Locked Then
					AddHandler _fuelPoint.PendingCommandChanged, AddressOf fuelPoint_PendingCommandChanged
				End If

				If _pts.RequestTotalizers = False Then
					_fuelPoint.TransFinished = False

					If _fuelPoint.Locked Then
						_fuelPoint.Unlock()
					End If
				End If
			End If

			If InvokeRequired Then
				Invoke(New Action(Sub()
					refreshUI()
					setControlUI(True)
					setOrderMode(_fuelPoint.OrderMode)
					stopButton.Enabled = False
				End Sub))
			End If

			If InvokeRequired Then
				'decimal[] dispensedTotals = {Convert.ToDecimal(e.DispensedAmount)/100, Convert.ToDecimal(e.DispensedVolume)/100, Convert.ToDecimal(e.DispensedPrice)/100};
				Dim dispensedTotals() As Decimal = { Convert.ToDecimal(e.DispensedAmount), Convert.ToDecimal(e.DispensedVolume), Convert.ToDecimal(e.DispensedPrice)}
        Invoke(New Action(Sub() DisplayTransaction(dispensedTotals)))

        Dim _Dispenser As Integer = Integer.Parse(_fuelPointId.Value.ToString)
        Dim _nozzle As Integer = Integer.Parse(nozzleUpDown.Text)
        Dim _UnitPrice As Decimal = Decimal.Parse(priceLabel.Text)
        Dim _Amount As Decimal = Decimal.Parse(paymentUpDown.Value.ToString)
        Dim _Volume As Decimal = Decimal.Parse(volumeUpDown.Value.ToString)
        Dim _EndReading As Decimal = Decimal.Parse(txbVolTotalValue.Text)
        Dim _EndAReading As Decimal = Decimal.Parse(txbAmoTotalValue.Text)


        Invoke(New Action(Sub() cmdPTAdd.InsertPumpTransaction(_Dispenser, _nozzle, _UnitPrice, _Amount, _Volume, _EndReading, _EndAReading)))
        'FuelPoint.Status = FuelPointStatus.IDLE


        'Invoke(New Action(Sub() stopz()))
        Invoke(New Action(Sub() cmdShowPT.ShowPT()))

      End If




      Dim parent As MainForm = TryCast(TopLevelControl, MainForm)
			parent.DisableAllOtherFPControls(FuelPointID, Name, False)
		End Sub

		Private Sub DisplayTransaction(ByVal dispensedTotals() As Decimal)
			RemoveHandler volumeUpDown.ValueChanged, AddressOf volumeUpDown_ValueChanged
			RemoveHandler paymentUpDown.ValueChanged, AddressOf paymentUpDown_ValueChanged

			'volumeUpDown.Value = dispensedTotals[1];
			Select Case GlobalVariables.VolumeDigits
				Case 2
					volumeUpDown.Value = dispensedTotals(1) / 100
				Case 3
					volumeUpDown.Value = dispensedTotals(1) / 1000
			End Select

			'paymentUpDown.Value = dispensedTotals[0];
			Select Case GlobalVariables.AmountDigits
				Case 0
					paymentUpDown.Value = dispensedTotals(0) / 1
				Case 1
					paymentUpDown.Value = dispensedTotals(0) / 10
				Case 2
					paymentUpDown.Value = dispensedTotals(0) / 100
				Case 3
					paymentUpDown.Value = dispensedTotals(0) / 1000
			End Select

      'priceLabel.Text = Convert.ToString(dispensedTotals[2]);
      Select Case GlobalVariables.PriceDigits
        Case 0
          priceLabel.Text = Convert.ToString(dispensedTotals(2) / 1)
        Case 1
          priceLabel.Text = Convert.ToString(dispensedTotals(2) / 10)
        Case 2
          priceLabel.Text = Convert.ToString(dispensedTotals(2) / 100)
        Case 3
          priceLabel.Text = Convert.ToString(dispensedTotals(2) / 1000)

      End Select


      LbAmount.Text = "P" & paymentUpDown.Value.ToString
      LBLiters.Text = volumeUpDown.Value.ToString & "L"
      AddHandler volumeUpDown.ValueChanged, AddressOf volumeUpDown_ValueChanged
			AddHandler paymentUpDown.ValueChanged, AddressOf paymentUpDown_ValueChanged
		End Sub

		Private Sub settingsButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles settingsButton.Click
			Dim oldFuelPointID? As Integer = FuelPointID
			Dim newFuelPointID? As Integer = Nothing

			Dim parent As MainForm = TryCast(TopLevelControl, MainForm)

			If _settingDialog.ShowDialog() = DialogResult.OK Then
				newFuelPointID = _settingDialog.FuelPointID

				If Not oldFuelPointID.Equals(newFuelPointID) Then
					If oldFuelPointID Is Nothing Then
						'no fuelPoint to disactivate, 
						'activate a new fuelPoint
						FuelPointID = newFuelPointID
						If _fuelPoint IsNot Nothing Then
							_fuelPoint.IsActive = True
						End If
						_isLocked = parent.CheckFPIsLocked(FuelPointID, Name)
					Else
						If newFuelPointID Is Nothing Then
							'disactivate old fuelPoint, 
							'no fuelPoint to activate
							If parent IsNot Nothing AndAlso parent.FuelPointHasUniqueID(CInt(Fix(oldFuelPointID))) Then
								FuelPointID = oldFuelPointID
								If _fuelPoint IsNot Nothing Then
									_fuelPoint.IsActive = False
								End If
							End If
							FuelPointID = newFuelPointID
							_isLocked = parent.CheckFPIsLocked(FuelPointID, Name)
						Else
							'disactivate old fuelPoint,
							'activate a new fuelPoint
							If parent IsNot Nothing AndAlso parent.FuelPointHasUniqueID(CInt(Fix(oldFuelPointID))) Then
								FuelPointID = oldFuelPointID
								If _fuelPoint IsNot Nothing Then
									_fuelPoint.IsActive = False
								End If
							End If
							FuelPointID = newFuelPointID
							If _fuelPoint IsNot Nothing Then
								_fuelPoint.IsActive = True
							End If
							_isLocked = parent.CheckFPIsLocked(FuelPointID, Name)
						End If
					End If
				End If

				If parent IsNot Nothing Then
					parent.SaveConfiguration()
					parent.LoadConfiguration()
				End If

				paymentUpDown.Value = 0
        volumeUpDown.Value = 0
        LbAmount.Text = "P" & paymentUpDown.Value.ToString
        LBLiters.Text = volumeUpDown.Value.ToString & "L"
        _valChanged = False
			End If
		End Sub

		Private Sub stopButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles stopButton.Click
			If _isDispensing Then
				_isDispensing = False

				If _fuelPoint.Locked Then
					_fuelPoint.Halt()
				End If
			End If

			If FuelPoint.Status = FuelPointStatus.READY OrElse FuelPoint.Status = FuelPointStatus.ERROR Then
				FuelPoint.Status = FuelPointStatus.IDLE

				If _updateThread IsNot Nothing Then
					_updateThread.Abort()
					_updateThread = Nothing

					If _fuelPoint.Locked Then
						_fuelPoint.Unlock()
					End If
				End If
			End If

			setControlUI(True)
			stopButton.Enabled = False
		End Sub
    Public Sub stopz()
      FuelPoint.Status = FuelPointStatus.IDLE

      If _updateThread IsNot Nothing Then
        _updateThread.Abort()
        _updateThread = Nothing

        If _fuelPoint.Locked Then
          _fuelPoint.Unlock()
        End If
      End If
    End Sub
    Private Sub totalsButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles totalsButton.Click
			_totalsDialog.ShowDialog(Me)
		End Sub

		Private Sub startButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles startButton.Click
			'Allow authorize dispenser if active nozzle is null
			'if (fuelPoint.ActiveNozzle.PricePerLiter == 0) return;
			'if (fuelPoint.ActiveNozzle == null || fuelPoint.ActiveNozzle.PricePerLiter == 0) return;
			'if (fuelPoint.ActiveNozzle == null && fuelPoint.Nozzles[Convert.ToInt32(nozzleUpDown.Value) - 1].PricePerLiter == 0) return;

			Dim parent As MainForm = TryCast(TopLevelControl, MainForm)
			parent.DisableAllOtherFPControls(FuelPointID, Name, True)

			If Not _fuelPoint.Locked Then
				_fuelPoint.Lock()
				Thread.Sleep(70)
			End If

			If _fuelPoint.Locked Then
				_updateThread = New Thread(Sub()
					Do
						refreshStatus()
						Thread.Sleep(_pts.UniPumpTimeout)
					Loop
				End Sub)

				ThrowAuthorizationCommand()
				_fuelPoint.Status = FuelPointStatus.READY
				stopButton.Enabled = True
			End If
		End Sub

		Private Sub ThrowAuthorizationCommand()

      If _fuelPoint.ActiveNozzle Is Nothing Then
					If _pts.SelectedAuthorizationType = AuthorizeType.Volume Then
						_fuelPoint.Authorize(AuthorizeType.Volume, _pts.ManualModeAuthorizeValue, Convert.ToByte(nozzleUpDown.Value))
					Else
						_fuelPoint.Authorize(AuthorizeType.Amount, _pts.ManualModeAuthorizeValue, Convert.ToByte(nozzleUpDown.Value))
					End If
				Else
					If _pts.SelectedAuthorizationType = AuthorizeType.Volume Then
						_fuelPoint.Authorize(AuthorizeType.Volume, _pts.ManualModeAuthorizeValue, 0)
					Else
						_fuelPoint.Authorize(AuthorizeType.Amount, _pts.ManualModeAuthorizeValue, 0)
					End If
				End If

    End Sub

		Private Sub paymentUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles paymentUpDown.ValueChanged
			If _fuelPoint Is Nothing OrElse Convert.ToInt32(nozzleUpDown.Value) = 0 Then
				Return
			End If
			If _valChanged Then
				_valChanged = False
				Return
			End If

			_valChanged = True
			If _fuelPoint.Nozzles(Convert.ToInt32(nozzleUpDown.Value) - 1).PricePerLiter = 0 Then
				volumeUpDown.Value = 0
				Return
			End If

			RemoveHandler volumeUpDown.ValueChanged, AddressOf volumeUpDown_ValueChanged

			'volumeUpDown.Value = Math.Round(((paymentUpDown.Value * 100) / Convert.ToDecimal(fuelPoint.Nozzles[Convert.ToInt32(nozzleUpDown.Value) - 1].PricePerLiter)), 2);
			Select Case GlobalVariables.VolumeDigits
				Case 2
					volumeUpDown.Value = Math.Round(((paymentUpDown.Value * 100) / Convert.ToDecimal(_fuelPoint.Nozzles(Convert.ToInt32(nozzleUpDown.Value) - 1).PricePerLiter)), 2)
				Case 3
					volumeUpDown.Value = Math.Round(((paymentUpDown.Value * 1000) / Convert.ToDecimal(_fuelPoint.Nozzles(Convert.ToInt32(nozzleUpDown.Value) - 1).PricePerLiter)), 3)
			End Select
      LbAmount.Text = "P" & paymentUpDown.Value.ToString
      LBLiters.Text = volumeUpDown.Value.ToString & "L"
      AddHandler volumeUpDown.ValueChanged, AddressOf volumeUpDown_ValueChanged

			checkStartButton()
		End Sub

		Private Sub volumeUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles volumeUpDown.ValueChanged
			If _fuelPoint Is Nothing OrElse Convert.ToInt32(nozzleUpDown.Value) = 0 Then
				Return
			End If
			If _valChanged Then
				_valChanged = False
				Return
			End If

			RemoveHandler paymentUpDown.ValueChanged, AddressOf paymentUpDown_ValueChanged

			_valChanged = True
			'paymentUpDown.Value = Math.Round(volumeUpDown.Value * (Convert.ToDecimal(fuelPoint.Nozzles[Convert.ToInt32(nozzleUpDown.Value) - 1].PricePerLiter) / 100), 2);
			Select Case GlobalVariables.AmountDigits
				Case 0
					paymentUpDown.Value = Math.Round(volumeUpDown.Value * (Convert.ToDecimal(_fuelPoint.Nozzles(Convert.ToInt32(nozzleUpDown.Value) - 1).PricePerLiter) / 1), 0)
				Case 1
					paymentUpDown.Value = Math.Round(volumeUpDown.Value * (Convert.ToDecimal(_fuelPoint.Nozzles(Convert.ToInt32(nozzleUpDown.Value) - 1).PricePerLiter) / 10), 1)
				Case 2
					paymentUpDown.Value = Math.Round(volumeUpDown.Value * (Convert.ToDecimal(_fuelPoint.Nozzles(Convert.ToInt32(nozzleUpDown.Value) - 1).PricePerLiter) / 100), 2)
				Case 3
					paymentUpDown.Value = Math.Round(volumeUpDown.Value * (Convert.ToDecimal(_fuelPoint.Nozzles(Convert.ToInt32(nozzleUpDown.Value) - 1).PricePerLiter) / 1000), 3)
			End Select
      LbAmount.Text = "P" & paymentUpDown.Value.ToString
      LBLiters.Text = volumeUpDown.Value.ToString & "L"
      AddHandler paymentUpDown.ValueChanged, AddressOf paymentUpDown_ValueChanged

			checkStartButton()
		End Sub

		Private Sub comboBoxDispenseMode_SelectedValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles comboBoxDispenseMode.SelectedValueChanged
			If _fuelPoint Is Nothing Then
				Return
			End If

			Select Case comboBoxDispenseMode.SelectedIndex
				Case 0
					_fuelPoint.OrderMode = OrderModes.Preset
					setOrderMode(_fuelPoint.OrderMode)
				Case 1
					_fuelPoint.OrderMode = OrderModes.Manual
					setOrderMode(_fuelPoint.OrderMode)
			End Select
		End Sub

		Private Sub FuelPointControl_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

		End Sub

		Private Sub nozzleUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nozzleUpDown.ValueChanged
      If Convert.ToInt32(nozzleUpDown.Value) = 0 Then
        'priceLabel.Text = "0.00";
        Select Case GlobalVariables.PriceDigits
          Case 0
            priceLabel.Text = "0000"
          Case 1
            priceLabel.Text = "000.0"
          Case 2
            priceLabel.Text = "00.00"
          Case 3
            priceLabel.Text = "0.000"
        End Select
      Else
        'priceLabel.Text = string.Format("{0:F2}", Convert.ToDouble(fuelPoint.Nozzles[Convert.ToInt32(nozzleUpDown.Value) - 1].PricePerLiter) / 100);
        Select Case GlobalVariables.PriceDigits
          Case 0
            priceLabel.Text = String.Format("{0:F0}", Convert.ToDouble(_fuelPoint.Nozzles(Convert.ToInt32(nozzleUpDown.Value) - 1).PricePerLiter) / 1)
          Case 1
            priceLabel.Text = String.Format("{0:F1}", Convert.ToDouble(_fuelPoint.Nozzles(Convert.ToInt32(nozzleUpDown.Value) - 1).PricePerLiter) / 10)
          Case 2
            priceLabel.Text = String.Format("{0:F2}", Convert.ToDouble(_fuelPoint.Nozzles(Convert.ToInt32(nozzleUpDown.Value) - 1).PricePerLiter) / 100)
          Case 3
            priceLabel.Text = String.Format("{0:F3}", Convert.ToDouble(_fuelPoint.Nozzles(Convert.ToInt32(nozzleUpDown.Value) - 1).PricePerLiter) / 1000)
        End Select
      End If
      If nozzleUpDown.Value = 0 Then
        LBProduct.Text = "Nozzle is Down"
      ElseIf nozzleUpDown.Value = 1 Then
        LBProduct.Text = $"{productname1}({priceLabel.Text})"
      ElseIf nozzleUpDown.Value = 2 Then
        LBProduct.Text = $"{productname2}({priceLabel.Text})"
      ElseIf nozzleUpDown.Value = 3 Then
        LBProduct.Text = $"{productname3}({priceLabel.Text})"
      End If
    End Sub

		Private Sub timerAutomaticAuthorize_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles timerAutomaticAuthorize.Tick
			timerAutomaticAuthorize.Stop()
			RemoveHandler timerAutomaticAuthorize.Tick, AddressOf timerAutomaticAuthorize_Tick
			timerAutomaticAuthorize.Enabled = False

			If FuelPoint.ActiveNozzle IsNot Nothing Then
				startButton.PerformClick()
			End If
		End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
      If statusLabel.Text = FuelPointStatus.NOZZLE.ToString Then
        _startButton.PerformClick()
      ElseIf statusLabel.Text = FuelPointStatus.WORK.ToString Then
        _stopButton.PerformClick()
      Else
        _startButton.PerformClick()
      End If

    End Sub

    Protected Overrides Sub Finalize()
      MyBase.Finalize()
    End Sub
  End Class
End Namespace

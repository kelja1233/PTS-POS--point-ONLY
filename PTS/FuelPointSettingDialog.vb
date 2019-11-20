Imports System.ComponentModel
Imports System.Text
Imports System.Threading

Namespace TiT.PTS
	Partial Public Class FuelPointSettingDialog
		Inherits Form
		Private _fuelPoint As FuelPoint = Nothing
		Private _pts As PTS = Nothing
		Private _fuelPointId? As Integer

		Public Sub New()
			InitializeComponent()
		End Sub

		Public ReadOnly Property FuelPoint() As FuelPoint
			Get
				Return _fuelPoint
			End Get
		End Property

		Public Property FuelPointID() As Integer?
			Get
				Return _fuelPointId
			End Get
			Set(ByVal value? As Integer)
				_fuelPointId = value

				If value Is Nothing Then
					_fuelPoint = Nothing
					Return
				End If

				_fuelPoint = _pts.GetFuelPointByID(value.Value)
			End Set
		End Property

		Public Property PTS() As PTS
			Get
				Return _pts
			End Get
			Set(ByVal value As PTS)
				_pts = value
			End Set
		End Property

		Protected Overrides Sub OnShown(ByVal e As EventArgs)
			MyBase.OnShown(e)

			If _pts IsNot Nothing Then
				Dim channels As New List(Of Integer)()

				For i As Integer = 0 To PtsConfiguration.FuelPointChannelQuantity
					channels.Add(i)
				Next i

				channelComboBox.DataSource = channels
			End If

			If _fuelPoint IsNot Nothing AndAlso _fuelPoint.Channel IsNot Nothing Then
				channelComboBox.SelectedIndex = _fuelPoint.Channel.ID
			End If

			nozzle1PriceUpDown.DecimalPlaces = CInt(Fix(GlobalVariables.PriceDigits))
			nozzle2PriceUpDown.DecimalPlaces = CInt(Fix(GlobalVariables.PriceDigits))
			nozzle3PriceUpDown.DecimalPlaces = CInt(Fix(GlobalVariables.PriceDigits))
			nozzle4PriceUpDown.DecimalPlaces = CInt(Fix(GlobalVariables.PriceDigits))
			nozzle5PriceUpDown.DecimalPlaces = CInt(Fix(GlobalVariables.PriceDigits))
			nozzle6PriceUpDown.DecimalPlaces = CInt(Fix(GlobalVariables.PriceDigits))

			Select Case GlobalVariables.PriceDigits
				Case 0
					nozzle6PriceUpDown.Increment = CDec(1)
					nozzle5PriceUpDown.Increment = nozzle6PriceUpDown.Increment
					nozzle4PriceUpDown.Increment = nozzle5PriceUpDown.Increment
					nozzle3PriceUpDown.Increment = nozzle4PriceUpDown.Increment
					nozzle2PriceUpDown.Increment = nozzle3PriceUpDown.Increment
					nozzle1PriceUpDown.Increment = nozzle2PriceUpDown.Increment
				Case 1
					nozzle6PriceUpDown.Increment = CDec(0.1)
					nozzle5PriceUpDown.Increment = nozzle6PriceUpDown.Increment
					nozzle4PriceUpDown.Increment = nozzle5PriceUpDown.Increment
					nozzle3PriceUpDown.Increment = nozzle4PriceUpDown.Increment
					nozzle2PriceUpDown.Increment = nozzle3PriceUpDown.Increment
					nozzle1PriceUpDown.Increment = nozzle2PriceUpDown.Increment
				Case 2
					nozzle6PriceUpDown.Increment = CDec(0.01)
					nozzle5PriceUpDown.Increment = nozzle6PriceUpDown.Increment
					nozzle4PriceUpDown.Increment = nozzle5PriceUpDown.Increment
					nozzle3PriceUpDown.Increment = nozzle4PriceUpDown.Increment
					nozzle2PriceUpDown.Increment = nozzle3PriceUpDown.Increment
					nozzle1PriceUpDown.Increment = nozzle2PriceUpDown.Increment
				Case 3
					nozzle6PriceUpDown.Increment = CDec(0.001)
					nozzle5PriceUpDown.Increment = nozzle6PriceUpDown.Increment
					nozzle4PriceUpDown.Increment = nozzle5PriceUpDown.Increment
					nozzle3PriceUpDown.Increment = nozzle4PriceUpDown.Increment
					nozzle2PriceUpDown.Increment = nozzle3PriceUpDown.Increment
					nozzle1PriceUpDown.Increment = nozzle2PriceUpDown.Increment
			End Select
		End Sub

		Private Sub channelListBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles channelComboBox.SelectedIndexChanged
			If channelComboBox.SelectedItem.ToString() = "0" Then
				fpListBox.DataSource = Nothing
				fpListBox.SelectedItem = Nothing
			Else
				_pts.GetFuelPointConfiguration()

				Dim channel As FuelPointChannel = Nothing

				For Each ch As FuelPointChannel In _pts.FuelPointChannels
					If ch.ID = CInt(Fix(channelComboBox.SelectedItem)) Then
						channel = ch
					End If
				Next ch

				If channel Is Nothing Then
					Return
				End If

				fpListBox.DataSource = channel.FuelPoints

				If _fuelPoint IsNot Nothing AndAlso channel.ID = _fuelPoint.ChannelID Then
					fpListBox.SelectedItem = _fuelPoint
				Else
					fpListBox.SelectedItem = Nothing
				End If
			End If
		End Sub

		Private Sub fpListBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles fpListBox.SelectedIndexChanged
			Dim fuelPoint As FuelPoint = CType(fpListBox.SelectedItem, FuelPoint)
			If fuelPoint Is Nothing Then
				_fuelPointId = Nothing
				Return
			End If

			_fuelPointId = fuelPoint.ID
			Select Case GlobalVariables.PriceDigits
				Case 0
					nozzle1PriceUpDown.Value = Convert.ToDecimal(fuelPoint.Nozzles(0).PricePerLiter) / 1
					nozzle2PriceUpDown.Value = Convert.ToDecimal(fuelPoint.Nozzles(1).PricePerLiter) / 1
					nozzle3PriceUpDown.Value = Convert.ToDecimal(fuelPoint.Nozzles(2).PricePerLiter) / 1
					nozzle4PriceUpDown.Value = Convert.ToDecimal(fuelPoint.Nozzles(3).PricePerLiter) / 1
					nozzle5PriceUpDown.Value = Convert.ToDecimal(fuelPoint.Nozzles(4).PricePerLiter) / 1
					nozzle6PriceUpDown.Value = Convert.ToDecimal(fuelPoint.Nozzles(5).PricePerLiter) / 1
				Case 1
					nozzle1PriceUpDown.Value = Convert.ToDecimal(fuelPoint.Nozzles(0).PricePerLiter) / 10
					nozzle2PriceUpDown.Value = Convert.ToDecimal(fuelPoint.Nozzles(1).PricePerLiter) / 10
					nozzle3PriceUpDown.Value = Convert.ToDecimal(fuelPoint.Nozzles(2).PricePerLiter) / 10
					nozzle4PriceUpDown.Value = Convert.ToDecimal(fuelPoint.Nozzles(3).PricePerLiter) / 10
					nozzle5PriceUpDown.Value = Convert.ToDecimal(fuelPoint.Nozzles(4).PricePerLiter) / 10
					nozzle6PriceUpDown.Value = Convert.ToDecimal(fuelPoint.Nozzles(5).PricePerLiter) / 10
				Case 2
					nozzle1PriceUpDown.Value = Convert.ToDecimal(fuelPoint.Nozzles(0).PricePerLiter) / 100
					nozzle2PriceUpDown.Value = Convert.ToDecimal(fuelPoint.Nozzles(1).PricePerLiter) / 100
					nozzle3PriceUpDown.Value = Convert.ToDecimal(fuelPoint.Nozzles(2).PricePerLiter) / 100
					nozzle4PriceUpDown.Value = Convert.ToDecimal(fuelPoint.Nozzles(3).PricePerLiter) / 100
					nozzle5PriceUpDown.Value = Convert.ToDecimal(fuelPoint.Nozzles(4).PricePerLiter) / 100
					nozzle6PriceUpDown.Value = Convert.ToDecimal(fuelPoint.Nozzles(5).PricePerLiter) / 100
				Case 3
					nozzle1PriceUpDown.Value = Convert.ToDecimal(fuelPoint.Nozzles(0).PricePerLiter) / 1000
					nozzle2PriceUpDown.Value = Convert.ToDecimal(fuelPoint.Nozzles(1).PricePerLiter) / 1000
					nozzle3PriceUpDown.Value = Convert.ToDecimal(fuelPoint.Nozzles(2).PricePerLiter) / 1000
					nozzle4PriceUpDown.Value = Convert.ToDecimal(fuelPoint.Nozzles(3).PricePerLiter) / 1000
					nozzle5PriceUpDown.Value = Convert.ToDecimal(fuelPoint.Nozzles(4).PricePerLiter) / 1000
					nozzle6PriceUpDown.Value = Convert.ToDecimal(fuelPoint.Nozzles(5).PricePerLiter) / 1000
            End Select

            If (fuelPoint.NozzlesQuantity <= PtsConfiguration.NozzleQuantity) Then
                udNozzlesQuantity.Value = Convert.ToDecimal(fuelPoint.NozzlesQuantity)
                For Each control As Control In groupBox1.Controls
                    For i As Integer = 1 To PtsConfiguration.NozzleQuantity
                        If (control.Name = "label" + i.ToString() Or control.Name = "nozzle" + i.ToString() + "PriceUpDown") Then
                            If i <= udNozzlesQuantity.Value Then
                                control.Enabled = True
                            Else
                                control.Enabled = False
                            End If
                        End If
                    Next
                Next control
            Else
                udNozzlesQuantity.Value = 1
            End If
        End Sub

		Private Sub okButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOk.Click
			If channelComboBox.SelectedItem.ToString() = "0" Then
				_fuelPointId = Nothing
				Return
			End If

			_fuelPoint = CType(fpListBox.SelectedItem, FuelPoint)

			If _fuelPoint Is Nothing Then
				Return
			End If

			_fuelPoint.IsActive = True

			Select Case GlobalVariables.PriceDigits
				Case 0
					_fuelPoint.Nozzles(0).PricePerLiter = Convert.ToInt32(nozzle1PriceUpDown.Value * 1)
					_fuelPoint.Nozzles(1).PricePerLiter = Convert.ToInt32(nozzle2PriceUpDown.Value * 1)
					_fuelPoint.Nozzles(2).PricePerLiter = Convert.ToInt32(nozzle3PriceUpDown.Value * 1)
					_fuelPoint.Nozzles(3).PricePerLiter = Convert.ToInt32(nozzle4PriceUpDown.Value * 1)
					_fuelPoint.Nozzles(4).PricePerLiter = Convert.ToInt32(nozzle5PriceUpDown.Value * 1)
					_fuelPoint.Nozzles(5).PricePerLiter = Convert.ToInt32(nozzle6PriceUpDown.Value * 1)
				Case 1
					_fuelPoint.Nozzles(0).PricePerLiter = Convert.ToInt32(nozzle1PriceUpDown.Value * 10)
					_fuelPoint.Nozzles(1).PricePerLiter = Convert.ToInt32(nozzle2PriceUpDown.Value * 10)
					_fuelPoint.Nozzles(2).PricePerLiter = Convert.ToInt32(nozzle3PriceUpDown.Value * 10)
					_fuelPoint.Nozzles(3).PricePerLiter = Convert.ToInt32(nozzle4PriceUpDown.Value * 10)
					_fuelPoint.Nozzles(4).PricePerLiter = Convert.ToInt32(nozzle5PriceUpDown.Value * 10)
					_fuelPoint.Nozzles(5).PricePerLiter = Convert.ToInt32(nozzle6PriceUpDown.Value * 10)
				Case 2
					_fuelPoint.Nozzles(0).PricePerLiter = Convert.ToInt32(nozzle1PriceUpDown.Value * 100)
					_fuelPoint.Nozzles(1).PricePerLiter = Convert.ToInt32(nozzle2PriceUpDown.Value * 100)
					_fuelPoint.Nozzles(2).PricePerLiter = Convert.ToInt32(nozzle3PriceUpDown.Value * 100)
					_fuelPoint.Nozzles(3).PricePerLiter = Convert.ToInt32(nozzle4PriceUpDown.Value * 100)
					_fuelPoint.Nozzles(4).PricePerLiter = Convert.ToInt32(nozzle5PriceUpDown.Value * 100)
					_fuelPoint.Nozzles(5).PricePerLiter = Convert.ToInt32(nozzle6PriceUpDown.Value * 100)
				Case 3
					_fuelPoint.Nozzles(0).PricePerLiter = Convert.ToInt32(nozzle1PriceUpDown.Value * 1000)
					_fuelPoint.Nozzles(1).PricePerLiter = Convert.ToInt32(nozzle2PriceUpDown.Value * 1000)
					_fuelPoint.Nozzles(2).PricePerLiter = Convert.ToInt32(nozzle3PriceUpDown.Value * 1000)
					_fuelPoint.Nozzles(3).PricePerLiter = Convert.ToInt32(nozzle4PriceUpDown.Value * 1000)
					_fuelPoint.Nozzles(4).PricePerLiter = Convert.ToInt32(nozzle5PriceUpDown.Value * 1000)
					_fuelPoint.Nozzles(5).PricePerLiter = Convert.ToInt32(nozzle6PriceUpDown.Value * 1000)
            End Select

            _pts.SetFuelPointNozzlesQuantity(_fuelPoint, Convert.ToInt32(udNozzlesQuantity.Value))

		End Sub

		Private Sub btnSetPrices_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSetPrices.Click
			Dim fuelPoint As FuelPoint = CType(fpListBox.SelectedItem, FuelPoint)
			If fuelPoint Is Nothing Then
				_fuelPointId = Nothing
				Return
			End If

			Select Case GlobalVariables.PriceDigits
				Case 0
					fuelPoint.Nozzles(0).PricePerLiter = Convert.ToInt32(nozzle1PriceUpDown.Value * 1)
					fuelPoint.Nozzles(1).PricePerLiter = Convert.ToInt32(nozzle2PriceUpDown.Value * 1)
					fuelPoint.Nozzles(2).PricePerLiter = Convert.ToInt32(nozzle3PriceUpDown.Value * 1)
					fuelPoint.Nozzles(3).PricePerLiter = Convert.ToInt32(nozzle4PriceUpDown.Value * 1)
					fuelPoint.Nozzles(4).PricePerLiter = Convert.ToInt32(nozzle5PriceUpDown.Value * 1)
					fuelPoint.Nozzles(5).PricePerLiter = Convert.ToInt32(nozzle6PriceUpDown.Value * 1)
				Case 1
					fuelPoint.Nozzles(0).PricePerLiter = Convert.ToInt32(nozzle1PriceUpDown.Value * 10)
					fuelPoint.Nozzles(1).PricePerLiter = Convert.ToInt32(nozzle2PriceUpDown.Value * 10)
					fuelPoint.Nozzles(2).PricePerLiter = Convert.ToInt32(nozzle3PriceUpDown.Value * 10)
					fuelPoint.Nozzles(3).PricePerLiter = Convert.ToInt32(nozzle4PriceUpDown.Value * 10)
					fuelPoint.Nozzles(4).PricePerLiter = Convert.ToInt32(nozzle5PriceUpDown.Value * 10)
					fuelPoint.Nozzles(5).PricePerLiter = Convert.ToInt32(nozzle6PriceUpDown.Value * 10)
				Case 2
					fuelPoint.Nozzles(0).PricePerLiter = Convert.ToInt32(nozzle1PriceUpDown.Value * 100)
					fuelPoint.Nozzles(1).PricePerLiter = Convert.ToInt32(nozzle2PriceUpDown.Value * 100)
					fuelPoint.Nozzles(2).PricePerLiter = Convert.ToInt32(nozzle3PriceUpDown.Value * 100)
					fuelPoint.Nozzles(3).PricePerLiter = Convert.ToInt32(nozzle4PriceUpDown.Value * 100)
					fuelPoint.Nozzles(4).PricePerLiter = Convert.ToInt32(nozzle5PriceUpDown.Value * 100)
					fuelPoint.Nozzles(5).PricePerLiter = Convert.ToInt32(nozzle6PriceUpDown.Value * 100)
				Case 3
					fuelPoint.Nozzles(0).PricePerLiter = Convert.ToInt32(nozzle1PriceUpDown.Value * 1000)
					fuelPoint.Nozzles(1).PricePerLiter = Convert.ToInt32(nozzle2PriceUpDown.Value * 1000)
					fuelPoint.Nozzles(2).PricePerLiter = Convert.ToInt32(nozzle3PriceUpDown.Value * 1000)
					fuelPoint.Nozzles(3).PricePerLiter = Convert.ToInt32(nozzle4PriceUpDown.Value * 1000)
					fuelPoint.Nozzles(4).PricePerLiter = Convert.ToInt32(nozzle5PriceUpDown.Value * 1000)
					fuelPoint.Nozzles(5).PricePerLiter = Convert.ToInt32(nozzle6PriceUpDown.Value * 1000)
			End Select

			If Not fuelPoint.Locked Then
				fuelPoint.Lock()
				Thread.Sleep(70)
			End If

			If fuelPoint.Locked Then
				fuelPoint.SetPrices()
				Thread.Sleep(1000)
				fuelPoint.Unlock()
				lblPriceInfo.Text = "Prices set"
			Else
				lblPriceInfo.Text = "Prices not set"
			End If
		End Sub

		Private Sub btnGetPrices_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGetPrices.Click
			btnGetPrices.Enabled = False
			timer1.Interval = 5000
			timer1.Enabled = True
			timer1.Start()
			AddHandler _fuelPoint.PricesGet, AddressOf fuelPoint_PricesGet
			GetPrices()
		End Sub

		Public Sub GetPrices()
			Dim fuelPoint As FuelPoint = CType(fpListBox.SelectedItem, FuelPoint)
			If fuelPoint Is Nothing Then
				_fuelPointId = Nothing
				Return
			End If

			lblPriceInfo.Text = "Requesting prices..."

			If Not fuelPoint.Locked Then
				fuelPoint.Lock()
				Thread.Sleep(70)
			End If

			If fuelPoint.Locked Then
				fuelPoint.GetPrices()
				Thread.Sleep(1000)
				fuelPoint.Unlock()
			Else
				lblPriceInfo.Text = "Prices not got"
			End If
		End Sub

		Private Sub fuelPoint_PricesGet(ByVal sender As Object, ByVal e As PricesEventArgs)
			'FuelPoint fuelPoint = (FuelPoint)fpListBox.SelectedItem;
			If _fuelPoint Is Nothing Then
				_fuelPointId = Nothing
				Return
			End If

			If e.Address <> _fuelPoint.ID Then
				Invoke(New Action(Sub()
					btnGetPrices.Enabled = True
					RemoveHandler _fuelPoint.PricesGet, AddressOf fuelPoint_PricesGet
					lblPriceInfo.Text = "Error receiving prices"
					timer1.Stop()
					timer1.Enabled = False
				End Sub))

				Return
			End If

			Invoke(New Action(Sub()
				btnGetPrices.Enabled = True
				RemoveHandler _fuelPoint.PricesGet, AddressOf fuelPoint_PricesGet
				timer1.Stop()
				timer1.Enabled = False
			End Sub))

			_fuelPointId = _fuelPoint.ID

			Select Case GlobalVariables.PriceDigits
				Case 0
                    Invoke(New Action(Sub()
                                          nozzle1PriceUpDown.Value = Convert.ToDecimal(_fuelPoint.Nozzles(0).PricePerLiter) / 1
                                          nozzle2PriceUpDown.Value = Convert.ToDecimal(_fuelPoint.Nozzles(1).PricePerLiter) / 1
                                          nozzle3PriceUpDown.Value = Convert.ToDecimal(_fuelPoint.Nozzles(2).PricePerLiter) / 1
                                          nozzle4PriceUpDown.Value = Convert.ToDecimal(_fuelPoint.Nozzles(3).PricePerLiter) / 1
                                          nozzle5PriceUpDown.Value = Convert.ToDecimal(_fuelPoint.Nozzles(4).PricePerLiter) / 1
                                          nozzle6PriceUpDown.Value = Convert.ToDecimal(_fuelPoint.Nozzles(5).PricePerLiter) / 1
                                      End Sub))
				Case 1
                    Invoke(New Action(Sub()
                                          nozzle1PriceUpDown.Value = Convert.ToDecimal(_fuelPoint.Nozzles(0).PricePerLiter) / 10
                                          nozzle2PriceUpDown.Value = Convert.ToDecimal(_fuelPoint.Nozzles(1).PricePerLiter) / 10
                                          nozzle3PriceUpDown.Value = Convert.ToDecimal(_fuelPoint.Nozzles(2).PricePerLiter) / 10
                                          nozzle4PriceUpDown.Value = Convert.ToDecimal(_fuelPoint.Nozzles(3).PricePerLiter) / 10
                                          nozzle5PriceUpDown.Value = Convert.ToDecimal(_fuelPoint.Nozzles(4).PricePerLiter) / 10
                                          nozzle6PriceUpDown.Value = Convert.ToDecimal(_fuelPoint.Nozzles(5).PricePerLiter) / 10
                                      End Sub))
				Case 2
                    Invoke(New Action(Sub()
                                          nozzle1PriceUpDown.Value = Convert.ToDecimal(_fuelPoint.Nozzles(0).PricePerLiter) / 100
                                          nozzle2PriceUpDown.Value = Convert.ToDecimal(_fuelPoint.Nozzles(1).PricePerLiter) / 100
                                          nozzle3PriceUpDown.Value = Convert.ToDecimal(_fuelPoint.Nozzles(2).PricePerLiter) / 100
                                          nozzle4PriceUpDown.Value = Convert.ToDecimal(_fuelPoint.Nozzles(3).PricePerLiter) / 100
                                          nozzle5PriceUpDown.Value = Convert.ToDecimal(_fuelPoint.Nozzles(4).PricePerLiter) / 100
                                          nozzle6PriceUpDown.Value = Convert.ToDecimal(_fuelPoint.Nozzles(5).PricePerLiter) / 100
                                      End Sub))
				Case 3
                    Invoke(New Action(Sub()
                                          nozzle1PriceUpDown.Value = Convert.ToDecimal(_fuelPoint.Nozzles(0).PricePerLiter) / 1000
                                          nozzle2PriceUpDown.Value = Convert.ToDecimal(_fuelPoint.Nozzles(1).PricePerLiter) / 1000
                                          nozzle3PriceUpDown.Value = Convert.ToDecimal(_fuelPoint.Nozzles(2).PricePerLiter) / 1000
                                          nozzle4PriceUpDown.Value = Convert.ToDecimal(_fuelPoint.Nozzles(3).PricePerLiter) / 1000
                                          nozzle5PriceUpDown.Value = Convert.ToDecimal(_fuelPoint.Nozzles(4).PricePerLiter) / 1000
                                          nozzle6PriceUpDown.Value = Convert.ToDecimal(_fuelPoint.Nozzles(5).PricePerLiter) / 1000
                                      End Sub))
			End Select

			Invoke(New Action(Sub() lblPriceInfo.Text = "Prices received"))

			If _fuelPoint.Locked Then
				_fuelPoint.Unlock()
			End If
		End Sub

		Private Sub timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles timer1.Tick
			timer1.Enabled = False
			btnGetPrices.Enabled = True
			RemoveHandler _fuelPoint.PricesGet, AddressOf fuelPoint_PricesGet
			lblPriceInfo.Text = "Error receiving prices"
			Return
		End Sub

        Private Sub udNozzlesQuantity_ValueChanged(sender As System.Object, e As System.EventArgs) Handles udNozzlesQuantity.ValueChanged
            For Each control As Control In groupBox1.Controls
                For i As Integer = 1 To PtsConfiguration.NozzleQuantity
                    If (control.Name = "label" + i.ToString() Or control.Name = "nozzle" + i.ToString() + "PriceUpDown") Then
                        If i <= udNozzlesQuantity.Value Then
                            control.Enabled = True
                        Else
                            control.Enabled = False
                        End If
                    End If
                Next
            Next control
        End Sub
    End Class
End Namespace

Imports System.ComponentModel
Imports System.Text
Imports System.Threading

Namespace TiT.PTS
	Partial Public Class TotalsDialog
		Inherits Form
		Private _pts As PTS = Nothing
		Private _fuelPoint As FuelPoint
		Private _nozzleToUpdate As Integer
    Private cmdpt As New CmdComandTotalizer
    Public Sub New()
      InitializeComponent()
      updateLabel.Text = ""
    End Sub

    Private Sub TotalsDialog_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
			updateUI()
            updateLabel.Text = ""
            udNozzlesQuantity.Maximum = _fuelPoint.NozzlesQuantity
		End Sub

		Public Property PTS() As PTS
			Get
				Return _pts
			End Get
			Set(ByVal value As PTS)
				_pts = value
			End Set
		End Property

		Public Property FuelPoint() As FuelPoint
			Get
				Return _fuelPoint
			End Get
			Set(ByVal value As FuelPoint)
				_fuelPoint = value

				If _fuelPoint IsNot Nothing Then
					'fuelPoint.TotalsUpdated += new EventHandler<TotalsEventArgs>(fuelPoint_TotalsUpdated);
					'updateUI();
				End If
			End Set
		End Property

		Private Sub UpdateTotals()
			If _fuelPoint Is Nothing Then
				Return
			End If

            If _fuelPoint.Status = FuelPointStatus.IDLE Or _fuelPoint.Status = FuelPointStatus.NOZZLE Or _fuelPoint.Status = FuelPointStatus.READY Or _fuelPoint.Status = FuelPointStatus.TRANSACTIONCOMPLETED Then
                _nozzleToUpdate = 0
                updateLabel.Text = "Updating totals..."
                pbTotalsRequest.Visible = True
                _fuelPoint.Nozzles(_nozzleToUpdate).UpdateTotals()
            Else
                updateTotalsButton.Enabled = True
                RemoveHandler _fuelPoint.TotalsUpdated, AddressOf fuelPoint_TotalsUpdated
                updateLabel.Text = "Error updating totals"
                pbTotalsRequest.Visible = False
                timer1.Stop()
                timer1.Enabled = False
            End If
            
        End Sub

		Private Sub fuelPoint_TotalsUpdated(ByVal sender As Object, ByVal e As TotalsEventArgs)
			If e.Address <> _fuelPoint.ID Then
				Invoke(New Action(Sub()
					updateUI()
					updateTotalsButton.Enabled = True
					RemoveHandler _fuelPoint.TotalsUpdated, AddressOf fuelPoint_TotalsUpdated
					updateLabel.Text = "Error updating totals"
					pbTotalsRequest.Visible = False
					timer1.Stop()
					timer1.Enabled = False
				End Sub))

				If _fuelPoint.Locked Then
					_fuelPoint.Unlock()
				End If

				Return
			End If

			'Display total counter values
			If _nozzleToUpdate <= udNozzlesQuantity.Value - 1 Then
				Invoke(New Action(Sub() updateUiByNozzleNumber()))

				_nozzleToUpdate += 1
			End If

			'Check if all the nozzles were already requested
			If _nozzleToUpdate < udNozzlesQuantity.Value Then
				Invoke(New Action(Sub()
					timer1.Stop()
					timer1.Interval = _pts.TotalsUpdateTimeout
					timer1.Enabled = True
					timer1.Start()
				End Sub))

				_fuelPoint.Nozzles(_nozzleToUpdate).UpdateTotals()
			Else
				Invoke(New Action(Sub()
					updateTotalsButton.Enabled = True
					updateLabel.Text = "Totals updated"
					pbTotalsRequest.Visible = False
					timer1.Stop()
					timer1.Enabled = False
				End Sub))

				RemoveHandler _fuelPoint.TotalsUpdated, AddressOf fuelPoint_TotalsUpdated

				If _fuelPoint.Locked Then
					_fuelPoint.Unlock()
				End If
			End If
		End Sub

		Private Sub updateUI()
			If _fuelPoint Is Nothing Then
				Return
			End If
      Dim Pumpid As Integer = Integer.Parse(_fuelPoint.ID.ToString)
      Dim tVol As Decimal = 0
      Dim tAmt As Decimal = 0
      For i As Integer = 1 To PtsConfiguration.NozzleQuantity
				'((Label)tableLayoutPanel.Controls.Find("amountLabel" + i.ToString(), false)[0]).Text = fuelPoint.Nozzles[i - 1].TotalDispensedAmount.ToString();
				Select Case GlobalVariables.AmountCounterDigits
					Case 0
            CType(tableLayoutPanel.Controls.Find("amountLabel" & i.ToString(), False)(0), Label).Text = String.Format("{0:F0}", CDbl(_fuelPoint.Nozzles(i - 1).TotalDispensedAmount) / 1)
            tAmt = Decimal.Parse(String.Format("{0:F0}", CDbl(_fuelPoint.Nozzles(i - 1).TotalDispensedAmount) / 1))
          Case 1
            CType(tableLayoutPanel.Controls.Find("amountLabel" & i.ToString(), False)(0), Label).Text = String.Format("{0:F1}", CDbl(_fuelPoint.Nozzles(i - 1).TotalDispensedAmount) / 10)
            tAmt = Decimal.Parse(String.Format("{0:F0}", CDbl(_fuelPoint.Nozzles(i - 1).TotalDispensedAmount) / 10))
          Case 2
            CType(tableLayoutPanel.Controls.Find("amountLabel" & i.ToString(), False)(0), Label).Text = String.Format("{0:F2}", CDbl(_fuelPoint.Nozzles(i - 1).TotalDispensedAmount) / 100)
            tAmt = Decimal.Parse(String.Format("{0:F0}", CDbl(_fuelPoint.Nozzles(i - 1).TotalDispensedAmount) / 100))
          Case 3
            CType(tableLayoutPanel.Controls.Find("amountLabel" & i.ToString(), False)(0), Label).Text = String.Format("{0:F3}", CDbl(_fuelPoint.Nozzles(i - 1).TotalDispensedAmount) / 1000)
            tAmt = Decimal.Parse(String.Format("{0:F0}", CDbl(_fuelPoint.Nozzles(i - 1).TotalDispensedAmount) / 1000))
        End Select

        '((Label)tableLayoutPanel.Controls.Find("volumeLabel" + i.ToString(), false)[0]).Text = fuelPoint.Nozzles[i - 1].TotalDispensedVolume.ToString();
        Select Case GlobalVariables.VolumeCounterDigits
          Case 2
            CType(tableLayoutPanel.Controls.Find("volumeLabel" & i.ToString(), False)(0), Label).Text = String.Format("{0:F2}", CDbl(_fuelPoint.Nozzles(i - 1).TotalDispensedVolume) / 100)
            tVol = Decimal.Parse(String.Format("{0:F2}", CDbl(_fuelPoint.Nozzles(i - 1).TotalDispensedVolume) / 100))
          Case 3
            CType(tableLayoutPanel.Controls.Find("volumeLabel" & i.ToString(), False)(0), Label).Text = String.Format("{0:F3}", CDbl(_fuelPoint.Nozzles(i - 1).TotalDispensedVolume) / 1000)
            tVol = Decimal.Parse(String.Format("{0:F2}", CDbl(_fuelPoint.Nozzles(i - 1).TotalDispensedVolume) / 1000))
        End Select
        cmdpt.UpdateTolizer(Pumpid, i, tVol, tAmt)

      Next i
		End Sub

		Private Sub updateUiByNozzleNumber()
			If _fuelPoint Is Nothing Then
				Return
			End If
      Dim Pumpid As Integer = Integer.Parse(_fuelPoint.ID.ToString)
      Dim tVol As Decimal = 0
      Dim tAmt As Decimal = 0
      '((Label)tableLayoutPanel.Controls.Find("amountLabel" + (nozzleToUpdate + 1).ToString(), false)[0]).Text = fuelPoint.Nozzles[nozzleToUpdate].TotalDispensedAmount.ToString();
      Select Case GlobalVariables.AmountCounterDigits
				Case 0
					CType(tableLayoutPanel.Controls.Find("amountLabel" & (_nozzleToUpdate + 1).ToString(), False)(0), Label).Text = String.Format("{0:F0}", CDbl(_fuelPoint.Nozzles(_nozzleToUpdate).TotalDispensedAmount) / 1)
          tAmt = Decimal.Parse(String.Format("{0:F0}", CDbl(_fuelPoint.Nozzles(_nozzleToUpdate).TotalDispensedAmount) / 1))
        Case 1
          CType(tableLayoutPanel.Controls.Find("amountLabel" & (_nozzleToUpdate + 1).ToString(), False)(0), Label).Text = String.Format("{0:F1}", CDbl(_fuelPoint.Nozzles(_nozzleToUpdate).TotalDispensedAmount) / 10)
          tAmt = Decimal.Parse(String.Format("{0:F0}", CDbl(_fuelPoint.Nozzles(_nozzleToUpdate).TotalDispensedAmount) / 10))
        Case 2
          CType(tableLayoutPanel.Controls.Find("amountLabel" & (_nozzleToUpdate + 1).ToString(), False)(0), Label).Text = String.Format("{0:F2}", CDbl(_fuelPoint.Nozzles(_nozzleToUpdate).TotalDispensedAmount) / 100)
          tAmt = Decimal.Parse(String.Format("{0:F0}", CDbl(_fuelPoint.Nozzles(_nozzleToUpdate).TotalDispensedAmount) / 100))
        Case 3
          CType(tableLayoutPanel.Controls.Find("amountLabel" & (_nozzleToUpdate + 1).ToString(), False)(0), Label).Text = String.Format("{0:F3}", CDbl(_fuelPoint.Nozzles(_nozzleToUpdate).TotalDispensedAmount) / 1000)
          tAmt = Decimal.Parse(String.Format("{0:F0}", CDbl(_fuelPoint.Nozzles(_nozzleToUpdate).TotalDispensedAmount) / 1000))
      End Select

      '((Label)tableLayoutPanel.Controls.Find("volumeLabel" + (nozzleToUpdate + 1).ToString(), false)[0]).Text = fuelPoint.Nozzles[nozzleToUpdate].TotalDispensedVolume.ToString();
      Select Case GlobalVariables.VolumeCounterDigits
        Case 2
          CType(tableLayoutPanel.Controls.Find("volumeLabel" & (_nozzleToUpdate + 1).ToString(), False)(0), Label).Text = String.Format("{0:F2}", CDbl(_fuelPoint.Nozzles(_nozzleToUpdate).TotalDispensedVolume) / 100)
          tVol = Decimal.Parse(String.Format("{0:F2}", CDbl(_fuelPoint.Nozzles(_nozzleToUpdate).TotalDispensedVolume) / 100))
        Case 3
          CType(tableLayoutPanel.Controls.Find("volumeLabel" & (_nozzleToUpdate + 1).ToString(), False)(0), Label).Text = String.Format("{0:F3}", CDbl(_fuelPoint.Nozzles(_nozzleToUpdate).TotalDispensedVolume) / 1000)
          tVol = Decimal.Parse(String.Format("{0:F2}", CDbl(_fuelPoint.Nozzles(_nozzleToUpdate).TotalDispensedVolume) / 1000))
      End Select

      cmdpt.UpdateTolizer(Pumpid, _nozzleToUpdate, tVol, tAmt)
    End Sub

		Private Sub updateTotalsButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles updateTotalsButton.Click
			If Not _fuelPoint.Locked Then
				_fuelPoint.Lock()
				Thread.Sleep(70)
            End If

            If _fuelPoint.Status = FuelPointStatus.IDLE Or _fuelPoint.Status = FuelPointStatus.NOZZLE Or _fuelPoint.Status = FuelPointStatus.READY Or _fuelPoint.Status = FuelPointStatus.TRANSACTIONCOMPLETED Then
                If _fuelPoint.Locked Then
                    updateTotalsButton.Enabled = False
                    timer1.Interval = _pts.TotalsUpdateTimeout
                    timer1.Enabled = True
                    timer1.Start()
                    AddHandler _fuelPoint.TotalsUpdated, AddressOf fuelPoint_TotalsUpdated
                    UpdateTotals()
                Else
                    updateLabel.Text = "Totals not updated"
                    pbTotalsRequest.Visible = False
                End If
            Else
                updateLabel.Text = "Totals not updated"
                pbTotalsRequest.Visible = False
            End If
		End Sub

		Private Sub okButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles okButton.Click
			updateTotalsButton.Enabled = True
			RemoveHandler _fuelPoint.TotalsUpdated, AddressOf fuelPoint_TotalsUpdated
			Me.Close()
		End Sub

		Private Sub timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles timer1.Tick
			timer1.Enabled = False
			updateTotalsButton.Enabled = True
			RemoveHandler _fuelPoint.TotalsUpdated, AddressOf fuelPoint_TotalsUpdated
			updateLabel.Text = "Error updating totals"
			pbTotalsRequest.Visible = False
			Return
		End Sub

		Private Sub TotalsDialog_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

		End Sub
	End Class
End Namespace

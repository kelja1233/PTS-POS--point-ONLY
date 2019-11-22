Imports System.ComponentModel
Imports System.Text
Imports System.Threading

Namespace TiT.PTS
	Partial Public Class AllTotalsDialog
		Inherits Form
		Private _pts As PTS = Nothing
		Private _fpToUpdate As FuelPoint
		Private _fpToUpdateID As Integer
		Private _nzlToUpdate As Integer
    Private _nzlToUpdateTotal As Integer
    Private cmdPt As New CmdComandTotalizer
    Private cmdPtop As New CmdComandTotalizerUpdateOP
    Private batch As Integer = 0
    Public Sub New(ByVal parent As PTS)
			Me.PTS = parent
			InitializeComponent()
			_fpToUpdateID = 0
		End Sub

		Public Property PTS() As PTS
			Get
				Return _pts
			End Get
			Set(ByVal value As PTS)
				_pts = value
			End Set
		End Property

		Private Sub AllTotalsDialog_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
			updateLabel.Text = ""
			DisplayTotals()
		End Sub

		Private Sub UpdateTotals()
			If Not SearchNextFuelPoint() Then
				Return
			End If

			_nzlToUpdate = 0
			_nzlToUpdateTotal = 0
			GetTotalNozzles()

			btnRebuildTable.Enabled = False
			timer1.Interval = _pts.TotalsUpdateTimeout
			timer1.Enabled = True
			timer1.Start()
			AddHandler _fpToUpdate.TotalsUpdated, AddressOf fuelPoint_TotalsUpdated

			updateLabel.Text = "Updating totals of pump " & _fpToUpdateID.ToString() & ", nozzle " & (_nzlToUpdate + 1).ToString() & "..."
			pbTotalsRequest.Visible = True
      _fpToUpdate.Nozzles(_nzlToUpdate).UpdateTotals()
      btChangeShift.Enabled = True
      btEndShift.Enabled = True
    End Sub

		Public Function SearchNextFuelPoint() As Boolean
			For Each fp As FuelPoint In _pts.FuelPoints
                If fp IsNot Nothing AndAlso fp.IsActive AndAlso fp.Status <> FuelPointStatus.OFFLINE AndAlso fp.Status <> FuelPointStatus.WORK AndAlso fp.Status <> FuelPointStatus.ERROR AndAlso _fpToUpdateID < fp.ID Then
                    _fpToUpdate = fp
                    _fpToUpdateID = fp.ID
                    Return True
                End If
			Next fp

			Return False
		End Function

		Private Sub GetTotalNozzles()
			Dim displayNonZeroNozzles As Boolean = If(cbhDisplayNonZeroNozzles.Checked, True, False)
			For Each nzl As Nozzle In _fpToUpdate.Nozzles
				If nzl IsNot Nothing Then
					If displayNonZeroNozzles Then
						If nzl.PricePerLiter = 0 Then
							Continue For
						End If
					End If

                    _nzlToUpdateTotal += 1

                    If (_nzlToUpdateTotal >= _fpToUpdate.NozzlesQuantity) Then
                        Return
                    End If
                End If
            Next nzl
		End Sub

    Private Sub btnRebuildTable_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRebuildTable.Click
      cmdPt.statusupdate()
      _fpToUpdateID = 0
      _nzlToUpdate = 0
      _nzlToUpdateTotal = 0

      UpdateTotals()
    End Sub

    Private Sub fuelPoint_TotalsUpdated(ByVal sender As Object, ByVal e As TotalsEventArgs)
            'If e.Address <> _fpToUpdateID Then
            '    Invoke(New Action(Sub()
            '                          DisplayTotals()
            '                          btnRebuildTable.Enabled = True
            '                          RemoveHandler _fpToUpdate.TotalsUpdated, AddressOf fuelPoint_TotalsUpdated
            '                          updateLabel.Text = "Error updating totals"
            '                          pbTotalsRequest.Visible = False
            '                          timer1.Stop()
            '                          timer1.Enabled = False
            '                      End Sub))

            '    Return
            'End If

			'Check if all the nozzles were already requested
			If _nzlToUpdate < _nzlToUpdateTotal - 1 Then
				_nzlToUpdate += 1

				Invoke(New Action(Sub()
					timer1.Stop()
					timer1.Start()
					updateLabel.Text = "Updating totals of pump " & _fpToUpdateID.ToString() & ", nozzle " & (_nzlToUpdate + 1).ToString() & "..."
				End Sub))

				_fpToUpdate.Nozzles(_nzlToUpdate).UpdateTotals()
			Else
				RemoveHandler _fpToUpdate.TotalsUpdated, AddressOf fuelPoint_TotalsUpdated
				Invoke(New Action(Sub() timer1.Stop()))

				If Not SearchNextFuelPoint() Then
					Invoke(New Action(Sub()
						btnRebuildTable.Enabled = True
						updateLabel.Text = "Totals updated"
						pbTotalsRequest.Visible = False
						timer1.Enabled = False
						DisplayTotals()
					End Sub))
				Else
					_nzlToUpdate = 0
					_nzlToUpdateTotal = 0
					GetTotalNozzles()
					AddHandler _fpToUpdate.TotalsUpdated, AddressOf fuelPoint_TotalsUpdated
					Invoke(New Action(Sub()
						updateLabel.Text = "Updating totals of pump " & _fpToUpdateID.ToString() & ", nozzle " & (_nzlToUpdate + 1).ToString() & "..."
						timer1.Start()
					End Sub))
					_fpToUpdate.Nozzles(_nzlToUpdate).UpdateTotals()
				End If
			End If
		End Sub

		Private Sub DisplayTotals()
			'Clearing of all table before filling it again.
			If tblTotals.RowCount > 1 Then
				Dim i As Integer = 1
				Do While i < tblTotals.RowCount
					tblTotals.Rows.RemoveAt(i)
					i += 1
				Loop
			End If

			tblTotals.RowCount = 0

			Dim rowsCounter As Integer = 0

			Dim displayNonZeroNozzles As Boolean = If(cbhDisplayNonZeroNozzles.Checked, True, False)
			For Each fp As FuelPoint In _pts.FuelPoints
				If fp IsNot Nothing AndAlso fp.IsActive AndAlso fp.Status <> FuelPointStatus.OFFLINE Then ' fp.IsActive
                    Dim fpIdStated As Boolean = False
          Dim nozzlesCounter As Integer = 0
          Dim PumpID As Integer = fp.ID
          Dim PumpNozzle As Integer = 0
          Dim TotalVolume As Decimal = 0
          Dim TotalAmount As Decimal = 0
          For Each nzl As Nozzle In fp.Nozzles

            nozzlesCounter += 1
            If (nozzlesCounter > fp.NozzlesQuantity) Then
              Exit For
            End If

            If nzl IsNot Nothing Then
              If displayNonZeroNozzles Then
                If nzl.PricePerLiter = 0 Then
                  Continue For
                End If
              End If

              tblTotals.Rows.Add(1)

              If Not fpIdStated Then
                tblTotals.Rows(rowsCounter).Cells(0).Value = "Pump " & fp.ID.ToString()
                fpIdStated = True
              End If

              tblTotals.Rows(rowsCounter).Cells(1).Value = nzl.ID.ToString()
              PumpNozzle = nzl.ID
              Select Case GlobalVariables.VolumeCounterDigits
                Case 2
                  tblTotals.Rows(rowsCounter).Cells(2).Value = String.Format("{0:F2}", CDbl(nzl.TotalDispensedVolume) / 100)
                  TotalVolume = Decimal.Parse(String.Format("{0:F2}", CDbl(nzl.TotalDispensedVolume) / 100))
                Case 3
                  tblTotals.Rows(rowsCounter).Cells(2).Value = String.Format("{0:F3}", CDbl(nzl.TotalDispensedVolume) / 1000)
                  TotalVolume = Decimal.Parse(String.Format("{0:F3}", CDbl(nzl.TotalDispensedVolume) / 1000))
              End Select

              Select Case GlobalVariables.AmountCounterDigits
                Case 0
                  tblTotals.Rows(rowsCounter).Cells(3).Value = String.Format("{0:F0}", CDbl(nzl.TotalDispensedAmount) / 1)
                  TotalAmount = Decimal.Parse(String.Format("{0:F0}", CDbl(nzl.TotalDispensedAmount) / 1))
                Case 1
                  tblTotals.Rows(rowsCounter).Cells(3).Value = String.Format("{0:F1}", CDbl(nzl.TotalDispensedAmount) / 10)
                  TotalAmount = Decimal.Parse(String.Format("{0:F0}", CDbl(nzl.TotalDispensedAmount) / 10))
                Case 2
                  tblTotals.Rows(rowsCounter).Cells(3).Value = String.Format("{0:F2}", CDbl(nzl.TotalDispensedAmount) / 100)
                  TotalAmount = Decimal.Parse(String.Format("{0:F0}", CDbl(nzl.TotalDispensedAmount) / 100))
                Case 3
                  tblTotals.Rows(rowsCounter).Cells(3).Value = String.Format("{0:F3}", CDbl(nzl.TotalDispensedAmount) / 1000)
                  TotalAmount = Decimal.Parse(String.Format("{0:F0}", CDbl(nzl.TotalDispensedAmount) / 1000))
              End Select
              cmdPt.UpdateTolizer(PumpID, PumpNozzle, TotalVolume, TotalAmount)
              cmdPtop.UpdateTolizer(batch, PumpID, PumpNozzle, TotalVolume, TotalAmount)
              rowsCounter += 1


            End If
          Next nzl
				End If
			Next fp

			Dim height As Integer = 0
			For Each dr As DataGridViewRow In tblTotals.Rows
				height += dr.Height
			Next dr

      tblTotals.Height = height + tblTotals.ColumnHeadersHeight
		End Sub

    Private Sub AllTotalsDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      btChangeShift.Enabled = False
      btEndShift.Enabled = False
      batch = TiT.PTS.MainForm.batchNumber
    End Sub

    Private Sub btChangeShift_Click(sender As Object, e As EventArgs) Handles btChangeShift.Click
      Dim batch As Integer = TiT.PTS.MainForm.batchNumber
      Dim shift As Integer = TiT.PTS.MainForm.ShiftNumber
      If cmdPt.transactionPumpShow = 0 Then


        If cmdPt.checkstatus = 0 Then
          Dim ccs As New ChangeEndShift

          ccs.ChangeSE(shift, batch)
          MessageBox.Show("Shitf Change Successful ")

          TiT.PTS.MainForm.CShif()


        Else
          MessageBox.Show("Update Not Complete")
        End If
      Else
        MessageBox.Show("PLS Tender Pending Trabscation")
        Dim csp As New CmdShowPumpTransaction
        csp.ShowPT()
        Me.Close()
      End If

    End Sub

    Private Sub btEndShift_Click(sender As Object, e As EventArgs) Handles btEndShift.Click
      Dim batch As Integer = TiT.PTS.MainForm.batchNumber
      Dim shift As Integer = TiT.PTS.MainForm.ShiftNumber
      If cmdPt.transactionPumpShow = 0 Then


        If cmdPt.checkstatus = 0 Then
          Dim ccs As New ChangeEndShift

          ccs.ChangeSE(0, batch)
          MessageBox.Show("End of day Successful ")

          TiT.PTS.MainForm.CShif()
        Else
          MessageBox.Show("Update Not Complete")
        End If
      Else
        MessageBox.Show("PLS Tender Pending Trabscation")
        Dim csp As New CmdShowPumpTransaction
        csp.ShowPT()
        Me.Close()
      End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
      Me.Close
    End Sub
  End Class
End Namespace

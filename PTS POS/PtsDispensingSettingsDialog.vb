Imports System.ComponentModel
Imports System.Text

Namespace TiT.PTS
	Partial Public Class PtsDispensingSettingsDialog
		Inherits Form
		Private _authorizeType As AuthorizeType
		Private _authorizePoll As Boolean
		Private _useExtendedCommands As Boolean
		Private _requestTotalizers As Boolean
		Private _automaticAuthorize As Boolean
		Private _pts As PTS

		Public Sub New()
			InitializeComponent()
		End Sub

		Public Property PTS() As PTS
			Get
				Return _pts
			End Get
			Set(ByVal value As PTS)
				_pts = value
			End Set
		End Property

		Private Sub DispensingSettingsDialog_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			_authorizeType = _pts.SelectedAuthorizationType

			If _authorizeType = AuthorizeType.Volume Then
				radioButtonAuthorizationVolume.Checked = True
			End If

			If _authorizeType = AuthorizeType.Amount Then
				radioButtonAuthorizationAmount.Checked = True
			End If

			If _authorizeType = AuthorizeType.Volume Then
				udManualModeAuthorizeValue.DecimalPlaces = GlobalVariables.VolumeDigits
			End If

			If _authorizeType = AuthorizeType.Amount Then
				udManualModeAuthorizeValue.DecimalPlaces = GlobalVariables.AmountDigits
			End If

			_authorizePoll = _pts.AuthorizationPolling

			If _authorizePoll = True Then
				rdbPollingOn.Checked = True
			Else
				rdbPollingOff.Checked = True
			End If

			_useExtendedCommands = _pts.UseExtendedCommands

			If _useExtendedCommands = True Then
				rdbExtendedCommands.Checked = True
			Else
				rdbGeneralCommands.Checked = True
			End If

			_requestTotalizers = _pts.RequestTotalizers

			If _requestTotalizers = True Then
				radioButtonRequestTotals.Checked = True
			Else
				radioButtonNotRequestTotals.Checked = True
			End If

			_automaticAuthorize = _pts.AutomaticAuthorize

			If _automaticAuthorize = True Then
				radioButtonAutomaticAuthorize.Checked = True
				udManualModeAuthorizeValue.Enabled = True
			Else
				radioButtonManualAuthorize.Checked = True
				udManualModeAuthorizeValue.Enabled = False
			End If

			udVolumeDigits.Value = CDec(GlobalVariables.VolumeDigits)
			udAmountDigits.Value = CDec(GlobalVariables.AmountDigits)
			udPriceDigits.Value = CDec(GlobalVariables.PriceDigits)
			udVolumeCounterDigits.Value = CDec(GlobalVariables.VolumeCounterDigits)
			udAmountCounterDigits.Value = CDec(GlobalVariables.AmountCounterDigits)
		End Sub

		Private Sub radioButtonAuthorizationVolume_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles radioButtonAuthorizationVolume.CheckedChanged
			If radioButtonAuthorizationVolume.Checked Then
				_authorizeType = AuthorizeType.Volume
			Else
				_authorizeType = AuthorizeType.Amount
			End If
		End Sub

		Private Sub radioButtonAuthorizationAmount_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles radioButtonAuthorizationAmount.CheckedChanged
			If radioButtonAuthorizationAmount.Checked Then
				_authorizeType = AuthorizeType.Amount
			Else
				_authorizeType = AuthorizeType.Volume
			End If
		End Sub

		Private Sub rdbPollingOn_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rdbPollingOn.CheckedChanged
			If rdbPollingOn.Checked Then
				_authorizePoll = True
			Else
				_authorizePoll = False
			End If
		End Sub

		Private Sub rdbPollingOff_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rdbPollingOff.CheckedChanged
			If rdbPollingOff.Checked Then
				_authorizePoll = False
			Else
				_authorizePoll = True
			End If
		End Sub

		Private Sub rdbGeneralCommands_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rdbGeneralCommands.CheckedChanged
			If rdbGeneralCommands.Checked Then
				_useExtendedCommands = False
			Else
				_useExtendedCommands = True
			End If
		End Sub

		Private Sub rdbExtendedCommands_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rdbExtendedCommands.CheckedChanged
			If rdbExtendedCommands.Checked Then
				_useExtendedCommands = True
			Else
				_useExtendedCommands = False
			End If
		End Sub

		Private Sub radioButtonRequestTotals_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles radioButtonRequestTotals.CheckedChanged
			If radioButtonRequestTotals.Checked Then
				_requestTotalizers = True
			Else
				_requestTotalizers = False
			End If
		End Sub

		Private Sub radioButtonNotRequestTotals_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles radioButtonNotRequestTotals.CheckedChanged
			If radioButtonNotRequestTotals.Checked Then
				_requestTotalizers = False
			Else
				_requestTotalizers = True
			End If
		End Sub

		Private Sub radioButtonAutomaticAuthorize_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles radioButtonAutomaticAuthorize.CheckedChanged
			If radioButtonAutomaticAuthorize.Checked Then
				_automaticAuthorize = True
				udManualModeAuthorizeValue.Enabled = True
			Else
				_automaticAuthorize = False
				udManualModeAuthorizeValue.Enabled = False
			End If
		End Sub

		Private Sub radioButtonManualAuthorize_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles radioButtonManualAuthorize.CheckedChanged
			If radioButtonManualAuthorize.Checked Then
				_automaticAuthorize = False
				udManualModeAuthorizeValue.Enabled = False
			Else
				_automaticAuthorize = True
				udManualModeAuthorizeValue.Enabled = True
			End If
		End Sub

		Private Sub okButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOk.Click
			_pts.SelectedAuthorizationType = _authorizeType
			_pts.AuthorizationPolling = _authorizePoll
			_pts.UseExtendedCommands = _useExtendedCommands
			_pts.RequestTotalizers = _requestTotalizers
			_pts.AutomaticAuthorize = _automaticAuthorize

			Select Case CInt(Fix(udVolumeDigits.Value))
				Case 2
					_pts.ManualModeAuthorizeValue = CInt(Fix(udManualModeAuthorizeValue.Value)) * 100
				Case 3
					_pts.ManualModeAuthorizeValue = CInt(Fix(udManualModeAuthorizeValue.Value)) * 1000
			End Select

			GlobalVariables.VolumeDigits = CShort(Fix(udVolumeDigits.Value))
			GlobalVariables.AmountDigits = CShort(Fix(udAmountDigits.Value))
			GlobalVariables.PriceDigits = CShort(Fix(udPriceDigits.Value))
			GlobalVariables.VolumeCounterDigits = CShort(Fix(udVolumeCounterDigits.Value))
			GlobalVariables.AmountCounterDigits = CShort(Fix(udAmountCounterDigits.Value))
		End Sub

		Private Sub udAmountDigits_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles udAmountDigits.ValueChanged
			If radioButtonAuthorizationVolume.Checked = True Then
				udManualModeAuthorizeValue.DecimalPlaces = CInt(Fix(udVolumeDigits.Value))
			End If
			If radioButtonAuthorizationAmount.Checked = True Then
				udManualModeAuthorizeValue.DecimalPlaces = CInt(Fix(udAmountDigits.Value))
			End If
		End Sub

		Private Sub udVolumeDigits_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles udVolumeDigits.ValueChanged
			If radioButtonAuthorizationVolume.Checked = True Then
				udManualModeAuthorizeValue.DecimalPlaces = CInt(Fix(udVolumeDigits.Value))
			End If
			If radioButtonAuthorizationAmount.Checked = True Then
				udManualModeAuthorizeValue.DecimalPlaces = CInt(Fix(udAmountDigits.Value))
			End If
		End Sub
	End Class
End Namespace

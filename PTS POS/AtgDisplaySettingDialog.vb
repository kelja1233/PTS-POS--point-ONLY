Imports System.ComponentModel
Imports System.Text

Namespace TiT.PTS

	Partial Public Class AtgDisplaySettingDialog
		Inherits Form
		Private _atg As ATG = Nothing
		Private _pts As PTS = Nothing
		Private _atgId? As Integer = Nothing
		Private _atgControl As AtgControl

		''' <summary>
		''' Create an instance of AtgDisplaySettingDialog class.
		''' </summary>
		Public Sub New(ByVal atgControl As AtgControl)
			InitializeComponent()
			Me._atgControl = atgControl
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

				_atgId = value

				If value Is Nothing Then
					_atg = Nothing
					Return
				End If

				_atg = _pts.GetAtgByID(value.Value)
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
				_pts = value
			End Set
		End Property

		Protected Overrides Sub OnShown(ByVal e As EventArgs)
			MyBase.OnShown(e)

			If _pts IsNot Nothing Then
				Dim atgChannelQuanty As New List(Of Integer)()
				For i As Integer = 0 To PtsConfiguration.AtgChannelQuantity
					atgChannelQuanty.Add(i)
				Next i

				channelComboBox.DataSource = atgChannelQuanty
			End If
			If _atg IsNot Nothing AndAlso _atg.Channel IsNot Nothing Then
				channelComboBox.SelectedIndex = _atg.Channel.ID
			End If

			If _atg IsNot Nothing AndAlso _atg.Channel IsNot Nothing Then
				tankHeightUpDown.Value = Decimal.Parse(_atg.MaxTankHeight.ToString())
			End If
		End Sub

		Private Sub channelListBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles channelComboBox.SelectedIndexChanged
			If channelComboBox.SelectedItem.ToString() = "0" Then
				atgListBox.DataSource = Nothing
				atgListBox.SelectedItem = Nothing
			Else
				_pts.GetAtgConfiguration()

				Dim channel As AtgChannel = Nothing

				For Each chnl As AtgChannel In _pts.AtgChannels
					If chnl.ID = CInt(Fix(channelComboBox.SelectedItem)) Then
						channel = chnl
						Exit For
					End If
				Next chnl

				If channel Is Nothing Then
					Return
				End If
				atgListBox.DataSource = channel.ATGs
				If _atg IsNot Nothing AndAlso channel.ID = _atg.ChannelID Then
					atgListBox.SelectedItem = _atg
				Else
					atgListBox.SelectedItem = Nothing
				End If
			End If
		End Sub

		Private Sub atgListBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles atgListBox.SelectedIndexChanged
			Dim atg As ATG = CType(atgListBox.SelectedItem, ATG)
			If atg Is Nothing Then
				_atgId = Nothing
				Return
			End If

			_atgId = atg.ID
			tankHeightUpDown.Value = Convert.ToDecimal(atg.MaxTankHeight)
		End Sub

		Private Sub okButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOk.Click
			If channelComboBox.SelectedIndex.ToString() = "0" Then
				_atgId = Nothing
				Return
			Else
				_atg = CType(atgListBox.SelectedItem, ATG)

				If _atg Is Nothing Then
					Return
				End If

				_atg.IsActive = True
				_atg.MaxTankHeight = Integer.Parse(tankHeightUpDown.Value.ToString())
			End If
		End Sub
	End Class
End Namespace

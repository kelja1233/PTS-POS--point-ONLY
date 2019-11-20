Imports System.ComponentModel
Imports System.Text

Namespace TiT.PTS
	Partial Public Class TankControl
		Inherits UserControl
		'Critical values in percents
		Private _LowValue As Integer = 10
		Private _CritLowValue As Integer = 5
		Private _HighValue As Integer = 90
		Private _CritHighValue As Integer = 95

		'Range values in units
		Private _maxValue As Double = 0

		'Current value in units
		Private _currValue As Double = 0

		'Current value in percents
		Private _currValuePercent As Integer = 0

		Private _originalHeight As Double = 0
		Private _originalBottom As Integer = 0

		Public Sub New()
			InitializeComponent()
			_originalHeight = Me.picLevel.Height
			_originalBottom = Me.picLevel.Bottom
		End Sub

		'Properties
		Public Property CurrentValue() As Double
			Get
				Return _currValue
			End Get
			Friend Set(ByVal value As Double)
				_currValue = value
			End Set
		End Property

		Public Property MaxValue() As Double
			Get
				Return _maxValue
			End Get
			Set(ByVal value As Double)
				_maxValue = value
			End Set
		End Property

		Public Property LowValue() As Integer
			Get
				Return _LowValue
			End Get
			Set(ByVal value As Integer)
				_LowValue = value
			End Set
		End Property

		Public Property CritLowValue() As Integer
			Get
				Return _CritLowValue
			End Get
			Set(ByVal value As Integer)
				_CritLowValue = value
			End Set
		End Property

		Public Property HighValue() As Integer
			Get
				Return _HighValue
			End Get
			Set(ByVal value As Integer)
				_HighValue = value
			End Set
		End Property

		Public Property CritHighValue() As Integer
			Get
				Return _CritHighValue
			End Get
			Set(ByVal value As Integer)
				_CritHighValue = value
			End Set
		End Property

		Public Sub setValue(ByVal val As Double)
			_currValue = val

			If Int32.TryParse((Math.Ceiling((val / (_maxValue - 0) * 100))).ToString(), _currValuePercent) Then
			  adjustLevel(CInt(Fix(_currValuePercent)), val)

			  labelCurHeight.BackColor = Color.Transparent
			  labelCurHeight.Location = New Point(119, picLevel.Top - 6)
			  labelCurHeight.Text = _currValuePercent.ToString() & "%"
			End If

		End Sub

		Private Sub adjustLevel(ByVal val_percent As Integer, ByVal val_level As Double)
			Try
				picLevel.Height = CInt(Fix(_originalHeight / (_maxValue - 0) * _currValue))
				picLevel.Top = _originalBottom - picLevel.Height

				If val_percent < _HighValue AndAlso val_percent > _LowValue Then
					picLevel.Image = My.Resources.levelBlue
					showAttention(False)
				ElseIf (val_percent <= _LowValue AndAlso val_percent > _CritLowValue) OrElse (val_percent < _CritHighValue AndAlso val_percent >= _HighValue) Then
					picLevel.Image = My.Resources.levelYellow
					showAttention(False)
				ElseIf (val_percent <= _CritLowValue AndAlso val_percent > 0) OrElse (val_percent <= 100 AndAlso val_percent >= _CritHighValue) Then
					picLevel.Image = My.Resources.levelRed
					showAttention(False)
				ElseIf val_percent <= 0 AndAlso val_level < 0 Then
					picLevel.Height = CInt(Fix(_originalHeight / (_maxValue - 0) * 0))
					picLevel.Top = _originalBottom - picLevel.Height

					picLevel.Image = My.Resources.levelRed
					showAttention("UNDERFILLING")
				ElseIf val_level = 0 Then
					picLevel.Height = CInt(Fix(_originalHeight / (_maxValue - 0) * 0))
					picLevel.Top = _originalBottom - picLevel.Height

					picLevel.Image = My.Resources.levelRed
					showAttention(False)
				ElseIf val_percent > 100 Then
					picLevel.Height = CInt(Fix(_originalHeight / (_maxValue - 0) * _maxValue))
					picLevel.Top = _originalBottom - picLevel.Height

					picLevel.Image = My.Resources.levelRed
					showAttention("OVERFILLING")
				End If
			Catch e As Exception
				showAttention(e.Message)
			End Try

		End Sub

		Private Sub showAttention(ByVal message As String)
			lblAttentionMessage.Text = message
			pbAttention.Visible = True
			lblAttention.Visible = True
			lblAttentionMessage.Visible = True
		End Sub

		Private Sub showAttention(ByVal is_ON As Boolean)
			pbAttention.Visible = is_ON
			lblAttention.Visible = is_ON
			lblAttentionMessage.Visible = is_ON
		End Sub
	End Class
End Namespace

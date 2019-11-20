Imports System.Text

Namespace TiT.PTS
	''' <summary>
	''' Provides information about an ATG channel of a PTS controller.
	''' </summary>
	Public Class AtgChannel
		Private _baudRate As ChannelBaudRate
		Private _atgs() As ATG
		Private _protocol As AtgChannelProtocol
		Private _pts As PTS

		''' <summary>
		''' Creates an exemplar of AtgChannel class.
		''' </summary>
		''' <param name="pts">Exemplar of parent PTS class.</param>
		Friend Sub New(ByVal pts As PTS)
			Me._pts = pts
		End Sub

		''' <summary>
		''' Gets or sets baud rate of a channel.
		''' </summary>
		''' <remarks>
		''' To make this setting work it is necessary to call a method 
		''' UpdateAtgConfiguration() of PTS exemplar, to which a channel belongs to.
		''' </remarks>
		Public Property BaudRate() As ChannelBaudRate
			Get
				Return _baudRate
			End Get
			Set(ByVal value As ChannelBaudRate)
				_baudRate = value
			End Set
		End Property

		''' <summary>
		''' Gets an identifier of a channel.
		''' </summary>
		Public Property ID() As Integer

		''' <summary>
		''' Gets or sets a communication protocol of a AtgChannel.
		''' </summary>
		Public Property Protocol() As AtgChannelProtocol
			Get
				Return _protocol
			End Get
			Set(ByVal value As AtgChannelProtocol)
				_protocol = value
			End Set
		End Property

		''' <summary>
		''' Gets an array of objects ATG, which belongs to given AtgChannel.
		''' </summary>
		Public Property ATGs() As ATG()
			Get
				Return _atgs
			End Get
			Friend Set(ByVal value As ATG())
				_atgs = value

				If value Is Nothing Then
					Return
				End If

				For Each atg As ATG In _atgs
					atg.Channel = Me
				Next atg
			End Set
		End Property

		''' <summary>
		''' Gets an a PTS exemplar, to which a channel belongs to.
		''' </summary>
		Public ReadOnly Property PTS() As PTS
			Get
				Return _pts
			End Get
		End Property

		Public Overrides Function ToString() As String
			Return String.Format("Channel{0},Protocol:{1},Baud rate:{2}", ID, Protocol, BaudRate)
		End Function
	End Class
End Namespace

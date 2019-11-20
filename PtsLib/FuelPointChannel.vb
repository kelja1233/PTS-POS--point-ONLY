Imports System.Text
Imports System.Runtime.InteropServices
Imports System.ComponentModel

Namespace TiT.PTS
	''' <summary>
	''' Provides information about a FuelPoint channel of a PTS controller.
	''' </summary>
	'[ComVisible(true)]
	Public Class FuelPointChannel
		Private _baudRate As ChannelBaudRate
		Private _dispensers() As FuelPoint
		Private _protocol As FuelPointChannelProtocol
		Private _pts As PTS

		''' <summary>
		''' Creates an exemplar of FuelPointChannel class.
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
		''' UpdateFuelPointConfiguration() of PTS exemplar, to which a channel belongs to.
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
		''' Gets or sets a communication protocol of a channel.
		''' </summary>
		''' <remarks>
		''' To make this setting work it is necessary to call a method 
		''' UpdateFuelPointConfiguration() of PTS exemplar, to which a channel belongs to.
		''' </remarks>
		Public Property Protocol() As FuelPointChannelProtocol
			Get
				Return _protocol
			End Get
			Set(ByVal value As FuelPointChannelProtocol)
				_protocol = value
			End Set
		End Property

		''' <summary>
		''' Gets an array of objects FuelPoint, which belongs to given channel.
		''' </summary>
		Public Property FuelPoints() As FuelPoint()
			Get
				Return _dispensers
			End Get
			Friend Set(ByVal value As FuelPoint())
				_dispensers = value

				If value Is Nothing Then
					Return
				End If

				For Each dispenser As FuelPoint In _dispensers
					dispenser.Channel = Me
				Next dispenser
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

Imports System.Text
Imports System.ComponentModel
Imports System.IO.Ports
Imports TiT.Unipump
Imports System.Runtime.InteropServices
Imports System.Threading

Namespace TiT.PTS
	''' <summary>
	''' Provides information about a PTS controller configuration.
	''' </summary>
	Public Class PtsConfiguration
		Private _fuelPointChannels() As FuelPointChannel
		Private _fuelDispensers() As FuelPoint
		Private _atgChannels() As AtgChannel
		Private _atgs() As ATG
		Private _pts As PTS

		''' <summary>
		''' Quantity of FuelPoint channels in PTS controller.
		''' </summary>
		Public Const FuelPointChannelQuantity As Integer = 4

		''' <summary>
		''' Maximum quantity of FuelPoints, that can be connected to PTS controller.
		''' </summary>
		Public Const FuelPointQuantity As Integer = 16

		''' <summary>
		''' Maximum value of FuelPoint address.
		''' </summary>
		Public Const FuelPointAddressQuantity As Integer = 99

		''' <summary>
		''' Maximum possible quantity of nozzles in a FuelPoint.
		''' </summary>
		Public Const NozzleQuantity As Integer = 6

		''' <summary>
		''' Quantity of ATG channels in PTS controller.
		''' </summary>
		Public Const AtgChannelQuantity As Integer = 3

		''' <summary>
		''' Maximum quantity of ATGs, that can be connected to PTS controller.
		''' </summary>
		Public Const AtgQuantity As Integer = 16

		''' <summary>
		''' Maximum value of ATG address.
		''' </summary>
		Public Const AtgAddressQuantity As Integer = 99999

		''' <summary>
		''' Communication baud rate for PTS controller.
		''' </summary>
		Public Const PtsBaudRate As Integer = 57600

		''' <summary>
		''' Creates an exemplar of PtsConfiguration class.
		''' </summary>
		''' <param name="pts">Exemplar of parent PTS class.</param>
		Friend Sub New(ByVal pts As PTS)
			Me._fuelPointChannels = New FuelPointChannel(PtsConfiguration.FuelPointChannelQuantity - 1){}
			Me._fuelDispensers = New FuelPoint(PtsConfiguration.FuelPointQuantity - 1){}
			Me._atgChannels = New AtgChannel(PtsConfiguration.AtgChannelQuantity - 1){}
			Me._atgs = New ATG(PtsConfiguration.AtgQuantity - 1){}
			Me._pts = pts

			For i As Integer = 0 To FuelPointChannelQuantity - 1
				_fuelPointChannels(i) = New FuelPointChannel(pts)
			Next i
			For i As Integer = 0 To FuelPointQuantity - 1
				_fuelDispensers(i) = New FuelPoint(pts)
			Next i
			For i As Integer = 0 To AtgChannelQuantity - 1
				_atgChannels(i) = New AtgChannel(pts)
			Next i
			For i As Integer = 0 To AtgQuantity - 1
				_atgs(i) = New ATG(pts)
			Next i
		End Sub

		''' <summary>
		''' Gets an array of objects FuelPointChannel of PTS controller.
		''' </summary>
		''' <remarks>At closed connection returns a value (Nothing в Visual Basic).</remarks>
		Public ReadOnly Property FuelPointChannels() As FuelPointChannel()
			Get
				Return _fuelPointChannels
			End Get
		End Property

		''' <summary>
		''' Gets an array of objects FuelPoint of PTS controller.
		''' </summary>
		''' <remarks>At closed connection returns a value (Nothing в Visual Basic).</remarks>
		Public ReadOnly Property FuelPoints() As FuelPoint()
			Get
				Return _fuelDispensers
			End Get
		End Property

		''' <summary>
		''' Provides initialization of FuelPoints.
		''' </summary>
		''' <param name="settResponse">Response on configuration of dispenser channels, received from a PTS controller.</param>
		Friend Sub FuelPointInit(ByVal settResponse() As Byte)
			Dim index As Integer = 4

			'Read FuelPoint channel settings
			For i As Integer = 0 To PtsConfiguration.FuelPointChannelQuantity - 1
				Me.FuelPointChannels(i).ID = AsciiConversion.AsciiToByte(settResponse(index))
				index += 1
				Me.FuelPointChannels(i).Protocol = CType(AsciiConversion.AsciiToByte(settResponse(index)) * 10 + AsciiConversion.AsciiToByte(settResponse(index + 1)), FuelPointChannelProtocol)
				index += 2
				Me.FuelPointChannels(i).BaudRate = CType(AsciiConversion.AsciiToByte(settResponse(index)), ChannelBaudRate)
				index += 1
			Next i

			'Read FuelPoint settings
			For i As Integer = 0 To PtsConfiguration.FuelPointQuantity - 1
				Me.FuelPoints(i).ID = AsciiConversion.AsciiToInt(settResponse(index), settResponse(index + 1))
				index += 2
				Me.FuelPoints(i).PhysicalAddress = AsciiConversion.AsciiToInt(settResponse(index), settResponse(index + 1))
				index += 2
				Me.FuelPoints(i).ChannelID = AsciiConversion.AsciiToByte(settResponse(index))
				index += 1
			Next i

			'Assign FuelPoints to FuelPointChannels
			For Each fuelPointChannel As FuelPointChannel In FuelPointChannels
				Dim fuelPointsList As New List(Of FuelPoint)()

				For Each fuelPoint As FuelPoint In FuelPoints
					If fuelPointChannel.ID = fuelPoint.ChannelID Then
						fuelPointsList.Add(fuelPoint)
					End If
				Next fuelPoint

				fuelPointChannel.FuelPoints = fuelPointsList.ToArray()
			Next fuelPointChannel
		End Sub

		''' <summary>
		''' Gets an array of objects AtgChannel of PTS controller.
		''' </summary>
		''' <remarks>At closed connection returns a value (Nothing в Visual Basic).</remarks>
		Public ReadOnly Property AtgChannels() As AtgChannel()
			Get
				Return _atgChannels
			End Get
		End Property

		''' <summary>
		''' Gets an array of objects ATG of PTS controller.
		''' </summary>
		''' <remarks>At closed connection returns a value (Nothing в Visual Basic).</remarks>
		Public ReadOnly Property ATGs() As ATG()
			Get
				Return _atgs
			End Get
		End Property

		''' <summary>
		''' Provides initialization of ATG.
		''' </summary>
		''' <param name="settResponse">Response on configuration of ATG channels, received from a PTS controller.</param>
		Friend Sub AtgInit(ByVal settResponse() As Byte)
			Dim index As Integer = 4

			'Read ATG channel settings
			For i As Integer = 0 To PtsConfiguration.AtgChannelQuantity - 1
				Me.AtgChannels(i).ID = AsciiConversion.AsciiToByte(settResponse(index))
				index += 1
				Me.AtgChannels(i).Protocol = CType(AsciiConversion.AsciiToByte(settResponse(index)) * 10 + AsciiConversion.AsciiToByte(settResponse(index + 1)), AtgChannelProtocol)
				index += 2
				Me.AtgChannels(i).BaudRate = CType(AsciiConversion.AsciiToByte(settResponse(index)), ChannelBaudRate)
				index += 1
			Next i

			'Read ATG settings
			For i As Integer = 0 To PtsConfiguration.AtgQuantity - 1
				Me.ATGs(i).ID = AsciiConversion.AsciiToInt(settResponse(index), settResponse(index + 1))
				index += 2
				Me.ATGs(i).PhysicalAddress = AsciiConversion.AsciiToInt(settResponse(index), settResponse(index + 1))
				index += 2
				Me.ATGs(i).ChannelID = AsciiConversion.AsciiToByte(settResponse(index))
				index += 1
			Next i

			'Assign Atgs to AtgChannels
			For Each atgChannel As AtgChannel In AtgChannels
				Dim atgsList As New List(Of ATG)()

				For Each atg As ATG In ATGs
					If atgChannel.ID = atg.ChannelID Then
						atgsList.Add(atg)
					End If
				Next atg

				atgChannel.ATGs = atgsList.ToArray()
			Next atgChannel
		End Sub
	End Class
End Namespace

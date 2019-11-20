Imports System.Text
Imports TiT.PTS
Imports System.IO
Imports System.Collections

Namespace TiT.Unipump
	''' <summary>
	''' Contains methods for formation of messages to PTS controller in format of UniPump communication protocol specification. 
	''' </summary>
	Friend NotInheritable Class UnipumpUtils
		'UniPump protocol command codes
		Public Const uStatusRequest As Byte = &H53
		Public Const uAutorizeRequest As Byte = &H41
		Public Const uHaltRequest As Byte = &H48
		Public Const uCloseTransactionRequest As Byte = &H43
		Public Const uTotalRequest As Byte = &H54
		Public Const uLockRequest As Byte = &H4c
		Public Const uUnlockRequest As Byte = &H55
		Public Const uPricesSetRequest As Byte = &H70
		Public Const uPricesGetRequest As Byte = &H50
		Public Const uVersionRequest As Byte = &H56
		Public Const uPumpConfigSetRequest As Byte = &H51
		Public Const uPumpConfigGetRequest As Byte = &H46
		Public Const uAtgConfigSetRequest As Byte = &H5A
		Public Const uAtgConfigGetRequest As Byte = &H59
		Public Const uAtgMeasureRequest As Byte = &H58
		Public Const uParamSetRequest As Byte = &H57
		Public Const uParamGetRequest As Byte = &H52

		'UniPump protocol response codes
		Public Const uStatusResponse As Byte = &H53
		Public Const uUnlockStatusResponse As Byte = &H55
		Public Const uAmountInfoResponse As Byte = &H41
		Public Const uTransactionInfoResponse As Byte = &H54
		Public Const uTotalInfoResponse As Byte = &H43
		Public Const uPricesResponse As Byte = &H50
		Public Const uVersionResponse As Byte = &H56
		Public Const uPumpConfigResponse As Byte = &H51
		Public Const uAtgConfigResponse As Byte = &H5A
		Public Const uAtgMeasureResponse As Byte = &H58
		Public Const uParamResponse As Byte = &H52

		'UniPump protocol extended message code
		Public Const uExtended As Byte = &H45
		Public Const uExtendedSeparator As Byte = &H3B

		'UniPump protocol escape characters
		Public Const STX As Byte = &H2
		Public Const ETX As Byte = &H3
		Public Const DLE As Byte = &H10
		Private Shared ReadOnly _dle() As Byte = { DLE, DLE }

		''' <summary>
		''' General method for preparation of the packet to be sent to the PTS controller.
		''' </summary>
		''' <param name="deviceId">ID of the device (fuel dispenser, ATG system probe, etc), to which command is addressed.</param>
		''' <param name="data">List of bytes of transferred command.</param>
		Private Sub New()
		End Sub
		Public Shared Function CreateMessage(ByVal deviceId As Integer, ByVal data As List(Of Byte)) As List(Of Byte)
			Dim result As New List(Of Byte)()
			Dim crcDat As New List(Of Byte)()
			Dim index As Integer = 0
			Dim address As Byte

			If data Is Nothing Then
				Throw New NullReferenceException()
			End If
			If deviceId < 0 OrElse deviceId > PtsConfiguration.FuelPointQuantity Then
				Throw New ArgumentOutOfRangeException("deviceId")
			End If

			If deviceId = 0 Then
				address = CByte(deviceId)
			Else
				address = CByte(deviceId + &H30)
			End If

			crcDat.Add(address)
			crcDat.AddRange(data)
			crcDat.AddRange(BitConverter.GetBytes(PtsCRC16.CalculateFast(crcDat.ToArray())))

			'Double DLE characters inside the packet data to avoid confusion with DLE escape characters 
			Do While index >= 0
				index = crcDat.IndexOf(DLE, index)
				If index >= 0 Then
					crcDat.Insert(index, DLE)
					index += 2
				End If
			Loop

			result.Add(DLE)
			result.Add(STX)
			result.AddRange(crcDat)
			result.Add(DLE)
			result.Add(ETX)

			Return result
		End Function

		''' <summary>
		''' General method for formation of data field of command to be sent to PTS controller.
		''' </summary>
		''' <param name="deviceId">ID of the device (fuel dispenser, ATG system probe, etc), to which command is addressed.</param>
		''' <param name="requestCode">Code of the command to be executed.</param>
		''' <param name="data">List of data bytes of the commands.</param>
		Public Shared Function CreateRequestMessage(ByVal deviceId As Integer, ByVal requestCode As Byte, ByVal data As List(Of Byte)) As List(Of Byte)
			Dim rData As New List(Of Byte)()

			rData.Add(requestCode)
			If data IsNot Nothing Then
				rData.AddRange(data)
			End If

			Return CreateMessage(deviceId, rData)
		End Function

		''' <summary>
		''' Method for formation of StatusRequest command.
		''' </summary>
		''' <param name="deviceId">ID of the device (fuel dispenser, ATG system probe, etc), to which command is addressed.</param>
		Public Shared Function CreateStatusRequestMessage(ByVal deviceId As Integer) As List(Of Byte)
			Return CreateRequestMessage(deviceId, uStatusRequest, Nothing)
		End Function

		''' <summary>
		''' Method for formation of ExtendedStatusRequest command.
		''' </summary>
		''' <param name="deviceId">ID of the device (fuel dispenser, ATG system probe, etc), to which command is addressed.</param>
		Public Shared Function CreateExtendedStatusRequestMessage(ByVal deviceId As Integer) As List(Of Byte)
			Dim rData As New List(Of Byte)()

			rData.Add(uStatusRequest)

			Return CreateRequestMessage(deviceId, uExtended, rData)
		End Function

		''' <summary>
		''' Method for formation of AuthorizeRequest command.
		''' </summary>
		''' <param name="deviceId">ID of the device (fuel dispenser, ATG system probe, etc), to which command is addressed.</param>
		''' <param name="nozzleId">ID of nozzle.</param>
		''' <param name="authorizeType">Type of authorization.</param>
		''' <param name="orderAmount">Amount of order (in volume or money amount depending on authorization type).</param>
		''' <param name="pricePerLiter">Price per liter (or other volume unit).</param>
		Public Shared Function CreateAuthorizeRequestMessage(ByVal deviceId As Integer, ByVal nozzleId As Byte, ByVal authorizeType As AuthorizeType, ByVal orderAmount As Integer, ByVal pricePerLiter As Integer) As List(Of Byte)
			Dim rData As New List(Of Byte)()

			rData.Add(AsciiConversion.ByteToAscii(nozzleId))
			rData.Add(CByte(authorizeType))
			rData.AddRange(AsciiConversion.IntToAscii(orderAmount, 8))
			rData.AddRange(AsciiConversion.IntToAscii(pricePerLiter, 4))

			Return CreateRequestMessage(deviceId, uAutorizeRequest, rData)
		End Function

		''' <summary>
		''' Method for formation of ExtendedAuthorizeRequest command.
		''' </summary>
		''' <param name="deviceId">ID of the device (fuel dispenser, ATG system probe, etc), to which command is addressed.</param>
		''' <param name="nozzleId">ID of nozzle.</param>
		''' <param name="autorizeType">Type of authorization.</param>
		''' <param name="orderAmount">Amount of order (in volume or money amount depending on authorization type).</param>
		''' <param name="pricePerLiter">Price per liter (or other volume unit).</param>
		Public Shared Function CreateExtendedAuthorizeRequestMessage(ByVal deviceId As Integer, ByVal nozzleId As Byte, ByVal autorizeType As AuthorizeType, ByVal orderAmount As Integer, ByVal pricePerLiter As Integer) As List(Of Byte)
			Dim rData As New List(Of Byte)()

			rData.Add(uAutorizeRequest)

			If AsciiConversion.ByteToAsciiExt(nozzleId) <> 0 Then
				rData.Add(AsciiConversion.ByteToAsciiExt(nozzleId))
			End If
			rData.Add(uExtendedSeparator)

			rData.Add(CByte(autorizeType))
			rData.Add(uExtendedSeparator)

			If AsciiConversion.IntToAsciiExt(orderAmount) IsNot Nothing Then
				rData.AddRange(AsciiConversion.IntToAsciiExt(orderAmount))
			End If
			rData.Add(uExtendedSeparator)

			If AsciiConversion.IntToAsciiExt(pricePerLiter) IsNot Nothing Then
				rData.AddRange(AsciiConversion.IntToAsciiExt(pricePerLiter))
			End If
			rData.Add(uExtendedSeparator)

			Return CreateRequestMessage(deviceId, uExtended, rData)
		End Function

		''' <summary>
		''' Method for formation of CloseTransactionRequest command.
		''' </summary>
		''' <param name="deviceId">ID of the device (fuel dispenser, ATG system probe, etc), to which command is addressed.</param>
		''' <param name="transactionId">ID of transaction.</param>
		''' <returns></returns>
		Public Shared Function CreateCloseTransactionRequestMessage(ByVal deviceId As Integer, ByVal transactionId As Integer) As List(Of Byte)
			Dim rData As New List(Of Byte)()

			rData.AddRange(AsciiConversion.IntToAscii(transactionId, 2))

			Return CreateRequestMessage(deviceId, uCloseTransactionRequest, rData)
		End Function

		''' <summary>
		''' Method for formation of CreateTotalRequest command.
		''' </summary>
		''' <param name="deviceId">ID of the device (fuel dispenser, ATG system probe, etc), to which command is addressed.</param>
		''' <param name="nozzleId">ID of nozzle.</param>
		Public Shared Function CreateTotalRequestMessage(ByVal deviceId As Integer, ByVal nozzleId As Byte) As List(Of Byte)
			Dim rData As New List(Of Byte)()

			rData.Add(AsciiConversion.ByteToAscii(nozzleId))

			Return CreateRequestMessage(deviceId, uTotalRequest, rData)
		End Function

		''' <summary>
		''' Method for formation of CreateTotalRequest command.
		''' </summary>
		''' <param name="deviceId">ID of the device (fuel dispenser, ATG system probe, etc), to which command is addressed.</param>
		''' <param name="nozzleId">ID of nozzle.</param>
		Public Shared Function CreateExtendedTotalRequestMessage(ByVal deviceId As Integer, ByVal nozzleId As Byte) As List(Of Byte)
			Dim rData As New List(Of Byte)()

			rData.Add(uTotalRequest)
			rData.Add(AsciiConversion.ByteToAscii(nozzleId))

			Return CreateRequestMessage(deviceId, uExtended, rData)
		End Function

		''' <summary>
		''' Method for formation of HaltRequest command.
		''' </summary>
		''' <param name="deviceId">ID of the device (fuel dispenser, ATG system probe, etc), to which command is addressed.</param>
		Public Shared Function CreateHaltRequestMessage(ByVal deviceId As Integer) As List(Of Byte)
			Return CreateRequestMessage(deviceId, uHaltRequest, Nothing)
		End Function

		''' <summary>
		''' Method for formation of LockRequest command.
		''' </summary>
		''' <param name="deviceId">ID of the device (fuel dispenser, ATG system probe, etc), to which command is addressed.</param>
		Public Shared Function CreateLockRequestMessage(ByVal deviceId As Integer) As List(Of Byte)
			Return CreateRequestMessage(deviceId, uLockRequest, Nothing)
		End Function

		''' <summary>
		''' Method for formation of UnlockRequest command.
		''' </summary>
		''' <param name="deviceId">ID of the device (fuel dispenser, ATG system probe, etc), to which command is addressed.</param>
		Public Shared Function CreateUnlockRequestMessage(ByVal deviceId As Integer) As List(Of Byte)
			Return CreateRequestMessage(deviceId, uUnlockRequest, Nothing)
		End Function

		''' <summary>
		''' Method for formation of PricesSetRequest command.
		''' </summary>
		''' <param name="deviceId">ID of the device (fuel dispenser, ATG system probe, etc), to which command is addressed.</param>
		''' <param name="prices">Array of nozzle prices of a fuel point.</param>
		Public Shared Function CreatePricesSetRequestMessage(ByVal deviceId As Integer, ByVal prices() As Integer) As List(Of Byte)
			Dim rData As New List(Of Byte)()

			For Each price As Integer In prices
				rData.AddRange(AsciiConversion.IntToAscii(price, 4))
			Next price

			Return CreateRequestMessage(deviceId, uPricesSetRequest, rData)
		End Function

		''' <summary>
		''' Method for formation of ExtendedPricesSetRequest command.
		''' </summary>
		''' <param name="deviceId">ID of the device (fuel dispenser, ATG system probe, etc), to which command is addressed.</param>
		''' <param name="prices">Array of nozzle prices of a fuel point.</param>
		Public Shared Function CreateExtendedPricesSetRequestMessage(ByVal deviceId As Integer, ByVal prices() As Integer) As List(Of Byte)
			Dim rData As New List(Of Byte)()

			rData.Add(uPricesSetRequest)

			For Each price As Integer In prices
				rData.AddRange(AsciiConversion.IntToAsciiExt(price))
				rData.Add(uExtendedSeparator)
			Next price

			Return CreateRequestMessage(deviceId, uExtended, rData)
		End Function

		''' <summary>
		''' Method for formation of PricesGetRequest command.
		''' </summary>
		''' <param name="deviceId">ID of the device (fuel dispenser, ATG system probe, etc), to which command is addressed.</param>
		Public Shared Function CreatePricesGetRequestMessage(ByVal deviceId As Integer) As List(Of Byte)
			Return CreateRequestMessage(deviceId, uPricesGetRequest, Nothing)
		End Function

		''' <summary>
		''' Method for formation of ParameterGetRequest command.
		''' </summary>
		''' <param name="parameterAddress">Address of the parameter requested.</param>
		''' <param name="parameterNumber">Number of the parameter requested.</param>
		Public Shared Function CreateParameterGetRequestMessage(ByVal parameterAddress As Short, ByVal parameterNumber As Integer) As List(Of Byte)
			Dim rData As New List(Of Byte)()

			rData.AddRange(AsciiConversion.IntToAscii(parameterNumber, 4))

			Return CreateRequestMessage(CInt(Fix(parameterAddress)), uParamGetRequest, rData)
		End Function

		''' <summary>
		''' Method for formation of ParameterSetRequest command.
		''' </summary>
		''' <param name="parameterAddress">Address of the parameter requested.</param>
		''' <param name="parameterNumber">Number of the parameter requested.</param>
		''' <param name="parameterValue">Value of the parameter requested.</param>
		Public Shared Function CreateParameterSetRequestMessage(ByVal parameterAddress As Short, ByVal parameterNumber As Integer, ByVal parameterValue() As Byte) As List(Of Byte)
			Dim rData As New List(Of Byte)()

			rData.AddRange(AsciiConversion.IntToAscii(parameterNumber, 4))
			rData.AddRange(parameterValue)

			Return CreateRequestMessage(CInt(Fix(parameterAddress)), uParamSetRequest, rData)
		End Function

		''' <summary>
		''' Method for formation of VersionRequest command.
		''' </summary>
		Public Shared Function CreateVersionRequestMessage() As List(Of Byte)
			Return CreateRequestMessage(0, uVersionRequest, Nothing)
		End Function

		''' <summary>
		''' Method for formation of PumpConfigGetRequest command.
		''' </summary>
		Public Shared Function CreatePumpConfigGetRequestMessage() As List(Of Byte)
			Return CreateRequestMessage(0, uPumpConfigGetRequest, Nothing)
		End Function

		''' <summary>
		''' Method for formation of PumpConfigSetRequest command.
		''' </summary>
		''' <param name="settings">Configuration of PTS controller TiT.PTS.PtsConfiguration.</param>
		Public Shared Function CreatePumpConfigSetRequestMessage(ByVal settings As PtsConfiguration) As List(Of Byte)
			Dim rData As New List(Of Byte)()

			' FuelPoint channels
			For i As Integer = 0 To PtsConfiguration.FuelPointChannelQuantity - 1
				rData.Add(AsciiConversion.ByteToAscii(CByte(settings.FuelPointChannels(i).ID)))
				rData.AddRange(AsciiConversion.IntToAscii(CInt(Fix(settings.FuelPointChannels(i).Protocol)), 2))
				rData.Add(AsciiConversion.ByteToAscii(CByte(settings.FuelPointChannels(i).BaudRate)))
			Next i

			' FuelPoints
			For i As Integer = 0 To PtsConfiguration.FuelPointQuantity - 1
				rData.AddRange(AsciiConversion.IntToAscii((settings.FuelPoints(i).ID), 2))
				rData.AddRange(AsciiConversion.IntToAscii((settings.FuelPoints(i).PhysicalAddress), 2))
				rData.Add(AsciiConversion.ByteToAscii(CByte(settings.FuelPoints(i).ChannelID)))
			Next i

			Return CreateRequestMessage(0, uPumpConfigSetRequest, rData)
		End Function

		''' <summary>
		''' Method for formation of AtgConfigGetRequest command.
		''' </summary>
		Public Shared Function CreateAtgConfigGetRequestMessage() As List(Of Byte)
			Return CreateRequestMessage(0, uAtgConfigGetRequest, Nothing)
		End Function

		''' <summary>
		''' Method for formation of AtgConfigSetRequest command.
		''' </summary>
		''' <param name="settings">Configuration of PTS controller TiT.PTS.PtsConfiguration.</param>
		Public Shared Function CreateAtgConfigSetRequestMessage(ByVal settings As PtsConfiguration) As List(Of Byte)
			Dim rData As New List(Of Byte)()

			' ATG channels
			For i As Integer = 0 To PtsConfiguration.AtgChannelQuantity - 1
				rData.Add(AsciiConversion.ByteToAscii(CByte(settings.AtgChannels(i).ID)))
				rData.AddRange(AsciiConversion.IntToAscii(CInt(Fix(settings.AtgChannels(i).Protocol)), 2))
				rData.Add(AsciiConversion.ByteToAscii(CByte(settings.AtgChannels(i).BaudRate)))
			Next i

			' ATG
			For i As Integer = 0 To PtsConfiguration.AtgQuantity - 1
				rData.AddRange(AsciiConversion.IntToAscii((settings.ATGs(i).ID), 2))
				rData.AddRange(AsciiConversion.IntToAscii((settings.ATGs(i).PhysicalAddress), 2))
				rData.Add(AsciiConversion.ByteToAscii(CByte(settings.ATGs(i).ChannelID)))
			Next i

			Return CreateRequestMessage(0, uAtgConfigSetRequest, rData)
		End Function

		''' <summary>
		''' Method for formation of AtgDataRequest command.
		''' </summary>
		''' <param name="deviceId">ID of the device (fuel dispenser, ATG system probe, etc), to which command is addressed.</param>
		Public Shared Function CreateAtgDataRequestMessage(ByVal deviceId As Integer) As List(Of Byte)
			Return CreateRequestMessage(deviceId, uAtgMeasureRequest, Nothing)
		End Function

		''' <summary>
		''' Method for checking whether message has format in accordance with UniPump communication protocol specification.
		''' </summary>
		''' <param name="message"></param>
		Public Shared Function IsValidMessage(ByVal message() As Byte) As Boolean
			If message.Length < 8 OrElse message.Length > 255 Then 'Check message length
				Return False
			End If
			If message(0) <> DLE AndAlso message(1) <> STX AndAlso message(message.Length - 1) <> ETX AndAlso message(message.Length - 2) <> DLE Then
				Return False
			End If
			If message(2) = 0 Then 'Check device ID
				Return True
			ElseIf message(2) < &H31 OrElse message(2) > &HFF Then
				Return False
			End If

			Return IsValidCRC(message)
		End Function

		''' <summary>
		''' Method for checking CRC of the message.
		''' </summary>
		''' <param name="message">Message with CRC to be checked.</param>
		Public Shared Function IsValidCRC(ByVal message() As Byte) As Boolean
			Dim body As New List(Of Byte)()
			Dim messageCrc As New List(Of Byte)()
			Dim recalcCrc As New List(Of Byte)()
			Dim messageCrcValue As UShort
			Dim calcCrcValue As UShort

			'Check CRC of the packet: calculated  CRC  on  the  fields (<ADDR>, <DATA>, <CRC>) should be equal to 0
			'Ignore service symbols <DLE> in packet at calculation of CRC
			For i As Integer = 2 To message.Length - 2 - 1
				If message(i) = DLE AndAlso message(i + 1) = DLE AndAlso i <> message.Length - 3 Then
					Continue For
				End If

				body.Add(message(i))
			Next i

			For i As Integer = body.Count - 2 To body.Count - 1
				messageCrc.Add(body(i))
			Next i

			messageCrcValue = BitConverter.ToUInt16(messageCrc.ToArray(), 0)

			For i As Integer = 0 To body.Count - 2 - 1
				recalcCrc.Add(body(i))
			Next i

			calcCrcValue = PtsCRC16.CalculateFast(recalcCrc.ToArray())

			Return messageCrcValue = calcCrcValue
		End Function
	End Class
End Namespace

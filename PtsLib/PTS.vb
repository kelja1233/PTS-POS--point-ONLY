Imports System.Collections
Imports System.Text
Imports System.ComponentModel
Imports System.IO.Ports
Imports TiT.Unipump
Imports System.Runtime.InteropServices
Imports System.Threading

Namespace TiT.PTS
	''' <summary>
	''' Provides instruments for access and control over PTS controller.
	''' </summary>
	Public Class PTS
		Inherits Component
		Private _configuration As PtsConfiguration
		Private _parameter As PtsParameter
		Private _releaseInfo As ReleaseInfo
		Private _port As SerialPort
		Private _refreshThread As Thread
		Private _initializing As Boolean
		Private _selectedAuthorizationType As AuthorizeType
		Private _authorizationPolling As Boolean
		Private _useExtendedCommands As Boolean
		Private _requestTotalizers As Boolean
		Private _uniPumpTimeout As Integer
		Private _responseCode As Byte
		Private _responseExtCode As Byte
		Private _totalsUpdateTimeout As Integer
		Private _maxPacketSize As Integer = 256
		Private _maxResponseTimeout As Integer = 2000
		Private _automaticAuthorize As Boolean
		Private _manualModeAuthorizeValue As Integer

		''' <summary>
		''' Initializes a new exemplar of PTS class.
		''' </summary>
		Public Sub New()
			_port = New SerialPort()
			_port.BaudRate = 57600
			_port.ReadTimeout = 2000
			_uniPumpTimeout = 50
			_configuration = Nothing
			_initializing = False
			_parameter = New PtsParameter()
            _totalsUpdateTimeout = 10000
			_requestTotalizers = True
			_automaticAuthorize = False
			_manualModeAuthorizeValue = 99999900
		End Sub

		''' <summary>
		''' Opens a connection with a PTS controller.
		''' </summary>
		''' <exception cref="T:System.InvalidOperationException">
		''' Specified COM-port is already opened.
		''' </exception>
		''' <exception cref="T:System.ArgumentException">
		''' COM-port name does not start with "COM".
		''' </exception>
		''' <exception cref="T:System.UnauthorizedAccessException">
		''' Access to specified COM-port is denied.
		''' </exception>
		Public Sub Open()
			OnOpening()
			_port.Open()

			Try
				_initializing = True
				OnInitializing()
				InitializeConfig()
				RequestVersion()
				_initializing = False
				OnInitialized()
			Catch e1 As TimeoutException
				_port.Close()
				OnTimeoutExpired()
				Throw
			End Try

			startRefreshThread()
			OnOpened()
		End Sub

		''' <summary>
		''' Closes connection with a PTS controller.
		''' </summary>
		''' <exception cref="T:System.InvalidOperationException">
		''' Specified COM-port is not opened.
		''' </exception>
		Public Sub Close()
			If Not IsOpen Then
				Return
			End If
			OnClosing()
			Monitor.Enter(_port)
			stopRefreshThread()
			_port.Close()

			For Each fp As FuelPoint In _configuration.FuelPoints
				fp.Status = FuelPointStatus.OFFLINE
			Next fp

			_releaseInfo = Nothing
			_configuration = Nothing
			Monitor.Exit(_port)
			OnClosed()
		End Sub

		''' <summary>
		''' Gets a value indicating a status of PTS controller connection - opened or closed.
		''' </summary>
		Public ReadOnly Property IsOpen() As Boolean
			Get
				Return _port.IsOpen
			End Get
		End Property

		''' <summary>
		''' Gets or sets a COM-port name, to which PTS controller is connected.
		''' </summary>
		''' <remarks>A list of valid COM-port names can be received using a static method System.IO.Ports.SerialPort.GetPortNames().</remarks>
		''' <exception cref="System.ArgumentException">Invalid COM-port name.</exception>
		''' <exception cref="System.ArgumentNullException">Property PortName has a null value (Nothing in Visual Basic).</exception>
		''' <exception cref="System.InvalidOperationException">Specified COM-port is already opened.</exception>
		Public Property PortName() As String
			Get
				Return _port.PortName
			End Get
			Set(ByVal value As String)
				_port.PortName = value
			End Set
		End Property

		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			MyBase.Dispose(disposing)
			If _port.IsOpen Then
				_refreshThread.Abort()
				_port.Close()
			End If
		End Sub

		''' <summary>
		''' Gets response code of PTS controller.
		''' </summary>
		Public ReadOnly Property ResponseCode() As Byte
			Get
				Return _responseCode
			End Get
		End Property

		''' <summary>
		''' Gets response code of PTS controller.
		''' </summary>
		Public ReadOnly Property ResponseExtCode() As Byte
			Get
				Return _responseExtCode
			End Get
		End Property

		''' <summary>
		''' Gets or sets duration of expectation of a response from COM-port in milliseconds.
		''' </summary>
		Public Property ResponseTimeout() As Integer
			Get
				Return _port.ReadTimeout
			End Get
			Set(ByVal value As Integer)
				_port.ReadTimeout = value
			End Set
		End Property

		''' <summary>
		''' Gets or sets duration of expectation of a response from a PTS controller in milliseconds.
		''' </summary>
		Public Property UniPumpTimeout() As Integer
			Get
				Return _uniPumpTimeout
			End Get
			Set(ByVal value As Integer)
				_uniPumpTimeout = value
			End Set
		End Property

		''' <summary>
		''' Gets or sets duration of expectation of a total counters from the PTS controller in milliseconds.
		''' </summary>
		Public Property TotalsUpdateTimeout() As Integer
			Get
				Return _totalsUpdateTimeout
			End Get
			Set(ByVal value As Integer)
				_totalsUpdateTimeout = value
			End Set
        End Property

        ''' <summary>
        ''' Sets quantity of nozzle on FuelPoint.
        ''' </summary>
        ''' <param name="fp">FuelPoint</param>
        ''' <param name="number">Quantity of nozzles</param>
        ''' <remarks></remarks>
        Public Sub SetFuelPointNozzlesQuantity(ByVal fp As FuelPoint, ByVal number As Integer)
            fp.NozzlesQuantity = number
        End Sub

        ''' <summary>
        ''' Starts a new thread, which updates statuses of connected FuelPoints.
        ''' </summary>
        Private Sub startRefreshThread()
            Dim loopCounter As Integer = 0
            Dim activeFuelPointsCount As Integer = 0

            'Delay between querying FuelPoints.
            'If only ATG systems are queried - delay 1.5 seconds
            'Query ATG with intervals
            _refreshThread = New Thread(Sub()
                                            Do
                                                activeFuelPointsCount = 0
                                                For Each fuelPoint As FuelPoint In FuelPoints
                                                    If fuelPoint.IsActive AndAlso fuelPoint.ChannelID <> 0 Then
                                                        fuelPoint.GetStatus()
                                                        activeFuelPointsCount += 1
                                                    End If
                                                Next fuelPoint
                                                Thread.Sleep(UniPumpTimeout)
                                                loopCounter -= 1
                                                If loopCounter <= 0 Then
                                                    For Each atg As ATG In ATGs
                                                        If atg.IsActive AndAlso atg.ChannelID <> 0 Then
                                                            atg.GetMeasurementData()
                                                        End If
                                                    Next atg
                                                    If activeFuelPointsCount = 0 Then
                                                        Thread.Sleep(UniPumpTimeout * 30)
                                                        loopCounter = 0
                                                    Else
                                                        loopCounter = 10
                                                        Thread.Sleep(UniPumpTimeout)
                                                    End If
                                                End If
                                            Loop
                                        End Sub)
            _refreshThread.Start()
        End Sub

        ''' <summary>
        ''' Stops operation of a thread, which updates statuses of connected FuelPoints.
        ''' </summary>
        Private Sub stopRefreshThread()
            If _refreshThread Is Nothing Then
                Return
            End If

            _refreshThread.Abort()
            _refreshThread.Join()
            _refreshThread = Nothing
        End Sub

        ''' <summary>
        ''' Gets configuration of PTS controller.
        ''' </summary>
        Public ReadOnly Property Configuration() As PtsConfiguration
            Get
                Return _configuration
            End Get
        End Property

        ''' <summary>
        ''' Gets access to an object PtsParameter, which provides information about a parameter of PTS controller.
        ''' </summary>
        Public ReadOnly Property Parameter() As PtsParameter
            Get
                Return _parameter
            End Get
        End Property

        ''' <summary>
        ''' Gets an array of objects FuelPointChannel for a PTS controller.
        ''' </summary>
        ''' <remarks>At closed connection returns value null (Nothing in Visual Basic).</remarks>
        Public ReadOnly Property FuelPointChannels() As FuelPointChannel()
            Get
                If _configuration Is Nothing Then
                    Return Nothing
                End If

                Return _configuration.FuelPointChannels
            End Get
        End Property

        ''' <summary>
        ''' Gets an array of objects FuelPoint for a PTS controller.
        ''' </summary>
        ''' <remarks>At closed connection returns value null (Nothing in Visual Basic).</remarks>
        Public ReadOnly Property FuelPoints() As FuelPoint()
            Get
                If _configuration Is Nothing Then
                    Return Nothing
                End If

                Return _configuration.FuelPoints
            End Get
        End Property

        ''' <summary>
        ''' Returns FuelPoint by its ID value.
        ''' </summary>
        ''' <param name="fuelPointId">Identifier of a FuelPoint.</param>
        ''' <remarks>
        ''' Value of parameter <paramref name="fuelPointId"/> should be in ranges from 1 to PtsConfiguration.FuelPointCount.
        ''' At closed connection returns value null (Nothing in Visual Basic).
        ''' </remarks>
        ''' <exception cref="T:System.ArgumentOutOfRangeException">
        ''' Value of parameter <paramref name="fuelPointId"/> has invalid value.
        ''' </exception>
        ''' <returns>Object FuelPoint of a requested FuelPoint.</returns>
        Public Function GetFuelPointByID(ByVal fuelPointId As Integer) As FuelPoint
            If fuelPointId < 1 OrElse fuelPointId > PtsConfiguration.FuelPointQuantity Then
                Throw New ArgumentOutOfRangeException("fuelPointIdfuelPointId")
            End If
            If _configuration Is Nothing Then
                Return Nothing
            End If

            For Each fp As FuelPoint In _configuration.FuelPoints
                If fp.ID = fuelPointId Then
                    Return fp
                End If
            Next fp

            Return Nothing
        End Function

        ''' <summary>
        ''' Gets an array of objects AtgChannel for a PTS controller.
        ''' </summary>
        ''' <remarks>At closed connection returns value null (Nothing in Visual Basic).</remarks>
        Public ReadOnly Property AtgChannels() As AtgChannel()
            Get
                If _configuration Is Nothing Then
                    Return Nothing
                End If

                Return _configuration.AtgChannels
            End Get
        End Property

        ''' <summary>
        ''' Gets an array of objects ATG for a PTS controller.
        ''' </summary>
        ''' <remarks>At closed connection returns value null (Nothing in Visual Basic).</remarks>
        Public ReadOnly Property ATGs() As ATG()
            Get
                If _configuration Is Nothing Then
                    Return Nothing
                End If

                Return _configuration.ATGs
            End Get
        End Property

        ''' <summary>
        ''' Returns ATG by its ID value.
        ''' </summary>
        ''' <param name="atgId">Identifier of an ATG.</param>
        ''' <remarks>
        ''' Value of parameter <paramref name="atgId"/> should be in ranges from 1 to PtsConfiguration.AtgCount.
        ''' At closed connection returns value null (Nothing in Visual Basic).
        ''' </remarks>
        ''' <exception cref="System.ArgumentOutOfRangeException">
        ''' Value of parameter <paramref name="atgId"/> has invalid value.
        ''' </exception>
        ''' <returns>Object ATG of a requested ATG.</returns>
        Public Function GetAtgByID(ByVal atgId As Integer) As ATG
            If atgId < 1 OrElse atgId > PtsConfiguration.AtgQuantity Then
                Throw New ArgumentOutOfRangeException("atgId")
            End If
            If _configuration Is Nothing Then
                Return Nothing
            End If

            For Each atg As ATG In _configuration.ATGs
                If atg.ID = atgId Then
                    Return atg
                End If
            Next atg

            Return Nothing
        End Function

        ''' <summary>
        ''' Gets an object ReleaseInfo, which provides information about a firmware version of PTS controller.
        ''' </summary>
        ''' <remarks>At closed connection returns value null (Nothing in Visual Basic).</remarks>
        Public ReadOnly Property ReleaseInfo() As ReleaseInfo
            Get
                Return _releaseInfo
            End Get
        End Property

        ''' <summary>
        ''' Initializes FuelPoint and ATG configuration of PTS controller.
        ''' </summary>
        Friend Sub InitializeConfig()
            _configuration = New PtsConfiguration(Me)
            Dim settResponse() As Byte

            settResponse = RequestFuelPointConfigurationGet()
            _configuration.FuelPointInit(settResponse)

            settResponse = RequestAtgConfigurationGet()
            _configuration.AtgInit(settResponse)
        End Sub

        ''' <summary>
        ''' Gets status of a FuelPoint.
        ''' </summary>
        ''' <param name="deviceId">Identifier of a FuelPoint.</param>
        ''' <remarks>
        ''' Value of parameter <paramref name="deviceId"/> should be in range from 1 to PtsConfiguration.FuelPointQuantity.
        ''' </remarks>
        Friend Sub RequestStatus(ByVal deviceId As Integer)
            If deviceId < 1 OrElse deviceId > PtsConfiguration.FuelPointQuantity Then
                Throw New Exception("Error: value of parameter 'deviceId' should be in range from 1 to " & PtsConfiguration.FuelPointQuantity.ToString())
            End If

            Dim message() As Byte = UnipumpUtils.CreateStatusRequestMessage(deviceId).ToArray()
            sendMessage(deviceId, message)
        End Sub

        ''' <summary>
        ''' Gets extended status of a FuelPoint.
        ''' </summary>
        ''' <param name="deviceId">Identifier of a FuelPoint.</param>
        ''' <remarks>
        ''' Value of parameter <paramref name="deviceId"/> should be in range from 1 to PtsConfiguration.FuelPointQuantity.
        ''' </remarks>
        Public Sub RequestExtendedStatus(ByVal deviceId As Integer)
            If deviceId < 1 OrElse deviceId > PtsConfiguration.FuelPointQuantity Then
                Throw New Exception("Error: value of parameter 'deviceId' should be in range from 1 to " & PtsConfiguration.FuelPointQuantity.ToString())
            End If

            Dim message() As Byte = UnipumpUtils.CreateExtendedStatusRequestMessage(deviceId).ToArray()
            sendMessage(deviceId, message)
        End Sub

        ''' <summary>
        ''' Sets lock on control over a FuelPoint in a multi POS system (several POS systems each with a PTS controller).
        ''' </summary>
        ''' <param name="deviceId">Identifier of a FuelPoint.</param>
        ''' <remarks>
        ''' Value of parameter <paramref name="deviceId"/> should be in ranges from 1 to PtsConfiguration.FuelPointQuantity.
        ''' </remarks>
        Friend Sub RequestLock(ByVal deviceId As Integer)
            If deviceId < 1 OrElse deviceId > PtsConfiguration.FuelPointQuantity Then
                Throw New Exception("Error: value of parameter 'deviceId' should be in range from 1 to " & PtsConfiguration.FuelPointQuantity.ToString())
            End If

            Dim message() As Byte = UnipumpUtils.CreateLockRequestMessage(deviceId).ToArray()
            sendMessage(deviceId, message)
        End Sub

        ''' <summary>
        ''' Sets unlock on control over a FuelPoint in a multi POS system (several POS systems each with a PTS controller).
        ''' </summary>
        ''' <param name="deviceId">Identifier of a FuelPoint.</param>
        ''' <remarks>
        ''' Value of parameter <paramref name="deviceId"/> should be in ranges from 1 to PtsConfiguration.FuelPointQuantity.
        ''' </remarks>
        Friend Sub RequestUnlock(ByVal deviceId As Integer)
            If deviceId < 1 OrElse deviceId > PtsConfiguration.FuelPointQuantity Then
                Throw New Exception("Error: value of parameter 'deviceId' should be in range from 1 to " & PtsConfiguration.FuelPointQuantity.ToString())
            End If

            Dim message() As Byte = UnipumpUtils.CreateUnlockRequestMessage(deviceId).ToArray()
            sendMessage(deviceId, message)
        End Sub

        ''' <summary>
        ''' Sets authorization of a FuelPoint.
        ''' </summary>
        ''' <param name="deviceId">Identifier of a FuelPoint.</param>
        ''' <param name="nozzleId">Identifier of a nozzle.</param>
        ''' <param name="autorizeType">Type of authorization (by volume or by money amount).</param>
        ''' <param name="orderAmount">Amount of authorization (volume or money amount).</param>
        ''' <param name="pricePerLiter">Fuel price per liter.</param>
        ''' <remarks>
        ''' Value of parameter <paramref name="deviceId"/> should be in ranges from 1 to PtsConfiguration.FuelPointQuantity.
        ''' Value of parameter <paramref name="nozzleId"/> should be in ranges from 1 to PtsConfiguration.NozzleQuantity.
        ''' </remarks>
        Friend Sub RequestAuthorize(ByVal deviceId As Integer, ByVal nozzleId As Byte, ByVal autorizeType As AuthorizeType, ByVal orderAmount As Integer, ByVal pricePerLiter As Integer)
            If deviceId < 1 OrElse deviceId > PtsConfiguration.FuelPointQuantity Then
                Throw New Exception("Error: value of parameter 'deviceId' should be in range from 1 to " & PtsConfiguration.FuelPointQuantity.ToString())
            End If
            If nozzleId < 1 OrElse nozzleId > PtsConfiguration.NozzleQuantity Then
                Throw New Exception("Error: value of parameter 'nozzleId' should be in range from 1 to " & PtsConfiguration.NozzleQuantity.ToString())
            End If
            If orderAmount < 0 Then
                Throw New Exception("Error: value of parameter 'orderAmount' should not be negative")
            End If
            If pricePerLiter < 0 Then
                Throw New Exception("Error: value of parameter 'pricePerLiter' should be positive")
            End If

            Dim message() As Byte = UnipumpUtils.CreateAuthorizeRequestMessage(deviceId, nozzleId, autorizeType, orderAmount, pricePerLiter).ToArray()
            sendMessage(deviceId, message)
        End Sub

        ''' <summary>
        ''' Sets extended authorization of a FuelPoint.
        ''' </summary>
        ''' <param name="deviceId">Identifier of a FuelPoint.</param>
        ''' <param name="nozzleId">Identifier of a nozzle.</param>
        ''' <param name="autorizeType">Type of authorization (by volume or by money amount).</param>
        ''' <param name="orderAmount">Amount of authorization (volume or money amount).</param>
        ''' <param name="pricePerLiter">Fuel price per liter.</param>
        ''' <remarks>
        ''' Value of parameter <paramref name="deviceId"/> should be in ranges from 1 to PtsConfiguration.FuelPointQuantity.
        ''' Value of parameter <paramref name="nozzleId"/> should be in ranges from 1 to PtsConfiguration.NozzleQuantity.
        ''' </remarks>
        Public Sub RequestExtendedAuthorize(ByVal deviceId As Integer, ByVal nozzleId As Byte, ByVal autorizeType As AuthorizeType, ByVal orderAmount As Integer, ByVal pricePerLiter As Integer)
            If deviceId < 1 OrElse deviceId > PtsConfiguration.FuelPointQuantity Then
                Throw New Exception("Error: value of parameter 'deviceId' should be in range from 1 to " & PtsConfiguration.FuelPointQuantity.ToString())
            End If
            If nozzleId < 1 OrElse nozzleId > PtsConfiguration.NozzleQuantity Then
                Throw New Exception("Error: value of parameter 'nozzleId' should be in range from 1 to " & PtsConfiguration.NozzleQuantity.ToString())
            End If
            If orderAmount < 0 Then
                Throw New Exception("Error: value of parameter 'orderAmount' should not be negative")
            End If
            If pricePerLiter < 0 Then
                Throw New Exception("Error: value of parameter 'pricePerLiter' should be positive")
            End If

            Dim message() As Byte = UnipumpUtils.CreateExtendedAuthorizeRequestMessage(deviceId, nozzleId, autorizeType, orderAmount, pricePerLiter).ToArray()
            sendMessage(deviceId, message)
        End Sub

        ''' <summary>
        ''' Stops fuel dispensing through a specified FuelPoint.
        ''' </summary>
        ''' <param name="deviceId">Identifier of a FuelPoint.</param>
        ''' <remarks>
        ''' Value of parameter <paramref name="deviceId"/> should be in ranges from 1 to PtsConfiguration.FuelPointQuantity.
        ''' </remarks>
        Friend Sub RequestHalt(ByVal deviceId As Integer)
            If deviceId < 1 OrElse deviceId > PtsConfiguration.FuelPointQuantity Then
                Throw New Exception("Error: value of parameter 'deviceId' should be in range from 1 to " & PtsConfiguration.FuelPointQuantity.ToString())
            End If

            Dim message() As Byte = UnipumpUtils.CreateHaltRequestMessage(deviceId).ToArray()
            sendMessage(deviceId, message)
        End Sub

        ''' <summary>
        ''' Closes a transaction of PTS controller.
        ''' </summary>
        ''' <param name="deviceId">Identifier of a FuelPoint.</param>
        ''' <param name="transactionId">Identifier of a transaction.</param>
        ''' <remarks>
        ''' Value of parameter <paramref name="deviceId"/> should be in ranges from 1 to PtsConfiguration.FuelPointQuantity.
        ''' Value of parameter <paramref name="transactionId"/> should be in ranges from 0 to 99.
        ''' </remarks>
        Friend Sub RequestCloseTransaction(ByVal deviceId As Integer, ByVal transactionId As Integer)
            If deviceId < 1 OrElse deviceId > PtsConfiguration.FuelPointQuantity Then
                Throw New Exception("Error: value of parameter 'deviceId' should be in range from 1 to " & PtsConfiguration.FuelPointQuantity.ToString())
            End If
            If transactionId < 0 OrElse transactionId > 99 Then
                Throw New Exception("Error: value of parameter 'transactionId' should be in range from 0 to 99")
            End If

            Dim message() As Byte = UnipumpUtils.CreateCloseTransactionRequestMessage(deviceId, transactionId).ToArray()
            sendMessage(deviceId, message)
        End Sub

        ''' <summary>
        ''' Gets a value of electronic totalizer of a nozzle of a FuelPoint.
        ''' </summary>
        ''' <param name="deviceId">Identifier of a FuelPoint.</param>
        ''' <param name="nozzleId">Identifier of a nozzle.</param>
        ''' <remarks>
        ''' Value of parameter <paramref name="deviceId"/> should be in ranges from 1 to PtsConfiguration.FuelPointQuantity.
        ''' Value of parameter <paramref name="nozzleId"/> should be in ranges from 1 to PtsConfiguration.NozzleQuantity.
        ''' </remarks>
        Public Sub RequestTotals(ByVal deviceId As Integer, ByVal nozzleId As Byte)
            If deviceId < 1 OrElse deviceId > PtsConfiguration.FuelPointQuantity Then
                Throw New Exception("Error: value of parameter 'deviceId' should be in range from 1 to " & PtsConfiguration.FuelPointQuantity.ToString())
            End If

            If nozzleId < 1 OrElse nozzleId > PtsConfiguration.NozzleQuantity Then
                Throw New Exception("Error: value of parameter 'nozzleId' should be in range from 1 to " & PtsConfiguration.NozzleQuantity.ToString())
            End If

            Dim message() As Byte = UnipumpUtils.CreateTotalRequestMessage(deviceId, nozzleId).ToArray()
            sendMessage(deviceId, message)
        End Sub

        ''' <summary>
        ''' Gets a value of electronic totalizer of a nozzle of a FuelPoint.
        ''' </summary>
        ''' <param name="deviceId">Identifier of a FuelPoint.</param>
        ''' <param name="nozzleId">Identifier of a nozzle.</param>
        ''' <remarks>
        ''' Value of parameter <paramref name="deviceId"/> should be in ranges from 1 to PtsConfiguration.FuelPointQuantity.
        ''' Value of parameter <paramref name="nozzleId"/> should be in ranges from 1 to PtsConfiguration.NozzleQuantity.
        ''' </remarks>
        Public Sub RequestExtendedTotals(ByVal deviceId As Integer, ByVal nozzleId As Byte)
            If deviceId < 1 OrElse deviceId > PtsConfiguration.FuelPointQuantity Then
                Throw New Exception("Error: value of parameter 'deviceId' should be in range from 1 to " & PtsConfiguration.FuelPointQuantity.ToString())
            End If

            If nozzleId < 1 OrElse nozzleId > PtsConfiguration.NozzleQuantity Then
                Throw New Exception("Error: value of parameter 'nozzleId' should be in range from 1 to " & PtsConfiguration.NozzleQuantity.ToString())
            End If

            Dim message() As Byte = UnipumpUtils.CreateExtendedTotalRequestMessage(deviceId, nozzleId).ToArray()
            sendMessage(deviceId, message)
        End Sub

        ''' <summary>
        ''' Gets fuel prices for nozzles of a FuelPoint.
        ''' </summary>
        ''' <param name="deviceId">Identifier of a FuelPoint.</param>
        ''' <remarks>
        ''' Value of parameter <paramref name="deviceId"/> should be in ranges from 1 to PtsConfiguration.FuelPointQuantity.
        ''' </remarks>
        Friend Sub RequestPricesGet(ByVal deviceId As Integer)
            If deviceId < 1 OrElse deviceId > PtsConfiguration.FuelPointQuantity Then
                Throw New Exception("Error: value of parameter 'deviceId' should be in range from 1 to " & PtsConfiguration.FuelPointQuantity.ToString())
            End If

            Dim message() As Byte = UnipumpUtils.CreatePricesGetRequestMessage(deviceId).ToArray()
            sendMessage(deviceId, message)
        End Sub

        ''' <summary>
        ''' Sets fuel prices for nozzles of a FuelPoint.
        ''' </summary>
        ''' <param name="deviceId">Identifier of a FuelPoint.</param>
        ''' <param name="prices">
        ''' Array of fuel prices for nozzles in cents. If length of the array is shorter than 
        ''' required for a total quantity of nozzles in a FuelPoint (prices for not all nozzles 
        ''' are specified) then prices will be set only for the first nozzles, if length of the 
        ''' array is longer than required for a total quantity of nozzles in a FuelPoint - then only 
        ''' first elements of the array will be used as fuel prices for nozzles.  If fuel price for a 
        ''' nozzle equals to zero - price is ignored.
        ''' </param>
        ''' <remarks>
        ''' Value of parameter <paramref name="deviceId"/> should be in ranges from 1 to PtsConfiguration.FuelPointQuantity.
        ''' Value of parameter <paramref name="nozzleId"/> should be in ranges from 1 to PtsConfiguration.NozzleQuantity.
        ''' </remarks>
        Friend Sub RequestPricesSet(ByVal deviceId As Integer, ByVal prices() As Integer)
            If deviceId < 1 OrElse deviceId > PtsConfiguration.FuelPointQuantity Then
                Throw New Exception("Error: value of parameter 'deviceId' should be in range from 1 to " & PtsConfiguration.FuelPointQuantity.ToString())
            End If

            If prices Is Nothing OrElse prices.Length = 0 Then
                Return
            End If

            For Each price As Integer In prices
                If price < 0 OrElse price > 999999999 Then
                    Throw New Exception("Error: value of each price in parameter 'prices' should be in range from 1 to 999999999")
                End If
            Next price

            Dim message() As Byte = UnipumpUtils.CreatePricesSetRequestMessage(deviceId, prices).ToArray()
            sendMessage(deviceId, message)
        End Sub

        ''' <summary>
        ''' Sets extended fuel prices for nozzles of a FuelPoint.
        ''' </summary>
        ''' <param name="deviceId">Identifier of a FuelPoint.</param>
        ''' <param name="prices">
        ''' Array of fuel prices for nozzles in cents. If length of the array is shorter than 
        ''' required for a total quantity of nozzles in a FuelPoint (prices for not all nozzles 
        ''' are specified) then prices will be set only for the first nozzles, if length of the 
        ''' array is longer than required for a total quantity of nozzles in a FuelPoint - then only 
        ''' first elements of the array will be used as fuel prices for nozzles.  If fuel price for a 
        ''' nozzle equals to zero - price is ignored.
        ''' </param>
        ''' <remarks>
        ''' Value of parameter <paramref name="deviceId"/> should be in ranges from 1 to PtsConfiguration.FuelPointQuantity.
        ''' </remarks>
        Public Sub RequestExtendedPricesSet(ByVal deviceId As Integer, ByVal prices() As Integer)
            If deviceId < 1 OrElse deviceId > PtsConfiguration.FuelPointQuantity Then
                Throw New Exception("Error: value of parameter 'deviceId' should be in range from 1 to " & PtsConfiguration.FuelPointQuantity.ToString())
            End If

            If prices Is Nothing OrElse prices.Length = 0 Then
                Return
            End If

            For Each price As Integer In prices
                If price < 0 OrElse price > 999999999 Then
                    Throw New Exception("Error: value of each price in parameter 'prices' should be in range from 1 to 999999999")
                End If
            Next price

            Dim message() As Byte = UnipumpUtils.CreateExtendedPricesSetRequestMessage(deviceId, prices).ToArray()
            sendMessage(deviceId, message)
        End Sub

        ''' <summary>
        ''' Gets data on measurements by ATG probe.
        ''' </summary>
        ''' <param name="deviceId">Identifier of an ATG.</param>
        ''' <remarks>
        ''' Value of parameter <paramref name="deviceId"/> should be in range from 1 to PtsConfiguration.AtgQuantity.
        ''' </remarks>
        Friend Sub RequestAtgMeasurementData(ByVal deviceId As Integer)
            If deviceId < 1 OrElse deviceId > PtsConfiguration.FuelPointQuantity Then
                Throw New Exception("Error: value of parameter 'deviceId' should be in range from 1 to " & PtsConfiguration.AtgQuantity.ToString())
            End If

            Dim message() As Byte = UnipumpUtils.CreateAtgDataRequestMessage(deviceId).ToArray()
            sendMessage(deviceId, message)
        End Sub

        ''' <summary>
        ''' Gets firmware version information from PTS controller.
        ''' </summary>
        Public Sub RequestVersion()
            Dim message() As Byte = UnipumpUtils.CreateVersionRequestMessage().ToArray()
            Dim buffer() As Byte

            Dim year, month, day As Integer
            Dim fuelPointProtocols As New List(Of String)()
            Dim atgProtocols As New List(Of String)()

            Monitor.Enter(_port)
            _port.Write(message, 0, message.Length)
            readResponseMessage(buffer)
            Monitor.Exit(_port)

            _releaseInfo = New ReleaseInfo()
            year = 2000 + AsciiConversion.AsciiToInt(buffer(4), buffer(5))
            month = AsciiConversion.AsciiToInt(buffer(6), buffer(7))
            day = AsciiConversion.AsciiToInt(buffer(8), buffer(9))
            _releaseInfo.ReleaseDate = New Date(year, month, day)
            _releaseInfo.ReleaseNum = CShort(Fix(AsciiConversion.AsciiToInt(buffer(10), buffer(11))))
            _releaseInfo.ReleaseVersion = AsciiConversion.AsciiToInt(buffer(4), buffer(5), buffer(6), buffer(7), buffer(8), buffer(9), buffer(10), buffer(11)).ToString()

            For i As Integer = 12 To 161 Step 2 'previous value was 72 (30 protocols for fuel dispensers)
                Dim protocol As Integer = AsciiConversion.AsciiToInt(buffer(i), buffer(i + 1))

                If protocol = 0 Then
                    Continue For
                End If
                If System.Enum.IsDefined(GetType(FuelPointChannelProtocol), CType(protocol, FuelPointChannelProtocol)) Then
                    fuelPointProtocols.Add((CType(protocol, FuelPointChannelProtocol)).ToString())
                End If
            Next i
            _releaseInfo.SupportedFuelPointProtocols = fuelPointProtocols.ToArray()

            For i As Integer = 162 To 211 Step 2 'previous value was 92 (10 protocols for ATG systems)
                Dim protocol As Integer = AsciiConversion.AsciiToInt(buffer(i), buffer(i + 1))

                If protocol = 0 Then
                    Continue For
                End If
                If System.Enum.IsDefined(GetType(AtgChannelProtocol), CType(protocol, AtgChannelProtocol)) Then
                    atgProtocols.Add((CType(protocol, AtgChannelProtocol)).ToString())
                End If
            Next i
            _releaseInfo.SupportedAtgProtocols = atgProtocols.ToArray()
        End Sub

        ''' <summary>
        ''' Gets a value of PTS controller parameter.
        ''' </summary>
        ''' <param name="parameterAddress">Address of the parameter requested</param>
        ''' <param name="parameterNumber">Number of the parameter requested</param>
        ''' <returns>Value of a parameter.</returns>
        ''' <remarks>
        ''' Value of parameter <paramref name="parameterAddress"/> should be in ranges from 0 to PtsConfiguration.FuelPointQuantity, at this value 0 corresponds to PTS.
        ''' Value of parameter <paramref name="parameterNumber"/> should be in range from 0 to 9999.
        ''' </remarks>
        Public Sub RequestParameterGet(ByVal parameterAddress As Short, ByVal parameterNumber As Integer)
            Dim buffer() As Byte

            If parameterAddress < 0 OrElse parameterAddress > PtsConfiguration.FuelPointQuantity Then
                Throw New Exception("Error: value of parameter 'parameterAddress' should be in range from 0 to " & PtsConfiguration.FuelPointQuantity.ToString())
            End If
            If parameterNumber < 0 OrElse parameterNumber > 9999 Then
                Throw New Exception("Error: value of parameter 'parameterNumber' should be in range from 0 to 9999")
            End If

            Dim message() As Byte = UnipumpUtils.CreateParameterGetRequestMessage(parameterAddress, parameterNumber).ToArray()

            Monitor.Enter(_port)
            _port.Write(message, 0, message.Length)
            readResponseMessage(buffer)
            Monitor.Exit(_port)

            If Not UnipumpUtils.IsValidMessage(buffer) Then
                Throw New Exception("Error: parameter response message has incorrect format")
            End If

            If buffer(3) = UnipumpUtils.uUnlockStatusResponse Then
                Throw New Exception("Error: pump side is switched off and parameters can not be read or written")
            End If

            Dim byteList As New List(Of Byte)()

            _parameter.ParameterAddress = AsciiConversion.AsciiToByte(buffer(2))
            _parameter.ParameterNumber = AsciiConversion.AsciiToInt(buffer(4), buffer(5), buffer(6), buffer(7))

            For i As Integer = 8 To 15
                byteList.Add(buffer(i))
            Next i
            _parameter.ParameterValue = byteList.ToArray()
        End Sub

        ''' <summary>
        ''' Sets a value of PTS controller parameter.
        ''' </summary>
        ''' <param name="parameterAddress">Address of the parameter requested</param>
        ''' <param name="parameterNumber">Number of the parameter requested</param>
        ''' <param name="parameterValue">Value of the parameter requested</param>
        ''' <remarks>
        ''' Value of parameter <paramref name="parameterAddress"/> should be in ranges from 0 to PtsConfiguration.FuelPointQuantity, at this value 0 corresponds to PTS. 
        ''' Value of parameter <paramref name="parameterNumber"/> should be in ranges from 0 to 9999.
        ''' Writing of a parameter to a FuelPoint with identifier 0 will set the parameter for PTS itself.  
        ''' Writing of a parameter with a identifier 0 will cause nulling of all parameters for the specified  FuelPoint
        ''' or PTS itself in case of writing to broadcasting FuelPoint with identifier 0.
        ''' </remarks>
        Public Sub RequestParameterSet(ByVal parameterAddress As Short, ByVal parameterNumber As Integer, ByVal parameterValue() As Byte)
            Dim buffer() As Byte

            If parameterAddress < 0 OrElse parameterAddress > PtsConfiguration.FuelPointQuantity Then
                Throw New Exception("Error: value of parameter 'deviceId' should be in range from 0 to " & PtsConfiguration.FuelPointQuantity.ToString())
            End If
            If parameterNumber < 0 OrElse parameterNumber > 9999 Then
                Throw New Exception("Error: value of parameter 'parameterId' should be in range from 0 to 9999")
            End If
            If parameterValue.Length > 8 Then
                Throw New Exception("Error: value of parameter 'parameterValue' should be in range from 0 to 0xFFFFFFFF")
            End If

            Dim message() As Byte = UnipumpUtils.CreateParameterSetRequestMessage(parameterAddress, parameterNumber, parameterValue).ToArray()
            sendMessage(parameterAddress, message)

            Monitor.Enter(_port)
            _port.Write(message, 0, message.Length)
            readResponseMessage(buffer)
            Monitor.Exit(_port)

            If Not UnipumpUtils.IsValidMessage(buffer) Then
                Throw New Exception("Error: parameter response message has incorrect format")
            End If

            If buffer(3) = UnipumpUtils.uUnlockStatusResponse Then
                Throw New Exception("Error: pump side is switched off and parameters can not be read or written")
            End If

            Dim byteList As New List(Of Byte)()

            _parameter.ParameterAddress = AsciiConversion.AsciiToByte(buffer(2))
            _parameter.ParameterNumber = AsciiConversion.AsciiToInt(buffer(4), buffer(5), buffer(6), buffer(7))

            For i As Integer = 8 To 15
                byteList.Add(buffer(i))
            Next i
            _parameter.ParameterValue = byteList.ToArray()
        End Sub

        ''' <summary>
        ''' Sets configuration of FuelPoint channels to PTS controller.
        ''' </summary>
        Public Function RequestFuelPointConfigurationSet() As Byte()
            Dim message() As Byte = UnipumpUtils.CreatePumpConfigSetRequestMessage(_configuration).ToArray()
            Dim buffer() As Byte

            Monitor.Enter(_port)
            stopRefreshThread()
            _port.Write(message, 0, message.Length)
            readResponseMessage(buffer)
            Monitor.Exit(_port)
            startRefreshThread()

            Return buffer
        End Function

        ''' <summary>
        ''' Gets configuration of FuelPoint channels from PTS controller.
        ''' </summary>
        Friend Function RequestFuelPointConfigurationGet() As Byte()
            Dim message() As Byte = UnipumpUtils.CreatePumpConfigGetRequestMessage().ToArray()
            Dim buffer() As Byte

            Monitor.Enter(_port)
            _port.Write(message, 0, message.Length)
            readResponseMessage(buffer)
            Monitor.Exit(_port)

            _configuration.FuelPointInit(buffer)

            Return buffer
        End Function

        ''' <summary>
        ''' Reads and applies configuration of objects FuelPoint of PTS controller.
        ''' </summary>
        Public Sub GetFuelPointConfiguration()
            Dim settResponse() As Byte = RequestFuelPointConfigurationGet()
            _configuration.FuelPointInit(settResponse)
        End Sub

        ''' <summary>
        ''' Writes and applies configuration of objects FuelPoint of PTS controller.
        ''' </summary>
        Public Sub SetFuelPointConfiguration()
            Dim settResponse() As Byte = RequestFuelPointConfigurationSet()
            _configuration.FuelPointInit(settResponse)
        End Sub

        ''' <summary>
        ''' Sets configuration of ATG probe channels to PTS controller.
        ''' </summary>
        ''' <remarks>
        ''' Value of parameter <paramref name="configuration"/> should be in ranges ... .
        ''' </remarks>
        Public Function RequestAtgConfigurationSet() As Byte()
            Dim message() As Byte = UnipumpUtils.CreateAtgConfigSetRequestMessage(_configuration).ToArray()
            Dim buffer() As Byte

            Monitor.Enter(_port)
            stopRefreshThread()
            _port.Write(message, 0, message.Length)
            readResponseMessage(buffer)
            Monitor.Exit(_port)
            startRefreshThread()

            Return buffer
        End Function

        ''' <summary>
        ''' Gets configuration of ATG probe channels from PTS controller.
        ''' </summary>
        Public Function RequestAtgConfigurationGet() As Byte()
            Dim message() As Byte = UnipumpUtils.CreateAtgConfigGetRequestMessage().ToArray()
            Dim buffer() As Byte

            Monitor.Enter(_port)
            _port.Write(message, 0, message.Length)
            readResponseMessage(buffer)
            Monitor.Exit(_port)

            Return buffer
        End Function

        ''' <summary>
        ''' Reads and applies configuration of objects ATG of PTS controller.
        ''' </summary>
        Public Sub GetAtgConfiguration()
            Dim settResponse() As Byte = RequestAtgConfigurationGet()
            _configuration.AtgInit(settResponse)
        End Sub

        ''' <summary>
        ''' Writes and applies configuration of objects ATG of PTS controller.
        ''' </summary>
        Public Sub SetAtgConfiguration()
            Dim settResponse() As Byte = RequestAtgConfigurationSet()
            _configuration.AtgInit(settResponse)
        End Sub

        ''' <summary>
        ''' Processes a response from a PTS controller.
        ''' </summary>
        Private Sub processResponseMessage(ByVal address As Integer, ByVal buffer() As Byte)
            Dim fuelPoint As New FuelPoint(Me)
            For Each fp As FuelPoint In FuelPoints
                If fp.ID = address Then
                    fuelPoint = fp
                End If
            Next fp

            _responseCode = buffer(3)

            Select Case _responseCode
                Case UnipumpUtils.uStatusResponse 'StatusResponse
                    fuelPoint.ID = AsciiConversion.AsciiToByte(buffer(2))

                    fuelPoint.ActiveNozzleID = AsciiConversion.AsciiToByte(buffer(4))

                    fuelPoint.Locked = True

                    If fuelPoint.Status = FuelPointStatus.READY AndAlso (CType(AsciiConversion.AsciiToByte(buffer(5)), FuelPointStatus) = FuelPointStatus.IDLE OrElse CType(AsciiConversion.AsciiToByte(buffer(5)), FuelPointStatus) = FuelPointStatus.NOZZLE) Then
                        fuelPoint.Status = FuelPointStatus.READY
                    Else
                        fuelPoint.Status = CType(AsciiConversion.AsciiToByte(buffer(5)), FuelPointStatus)
                    End If

                    fuelPoint.CurrentPendingCommand = buffer(6)

                    If fuelPoint.PreviousPendingCommand <> fuelPoint.CurrentPendingCommand Then
                        fuelPoint.OnPendingCommandChanged(New PendingCommandChangedEventArgs(fuelPoint.CurrentPendingCommand, fuelPoint.PreviousPendingCommand))
                        fuelPoint.PreviousPendingCommand = fuelPoint.CurrentPendingCommand
                    End If

                Case UnipumpUtils.uUnlockStatusResponse 'UnlockStatusResponse
                    fuelPoint.ID = AsciiConversion.AsciiToByte(buffer(2))

                    fuelPoint.ActiveNozzleID = AsciiConversion.AsciiToByte(buffer(4))

                    fuelPoint.Locked = False
                    'if (fuelPoint.Status != FuelPointStatus.READY && fuelPoint.Status != FuelPointStatus.ERROR)
                    fuelPoint.Status = CType(AsciiConversion.AsciiToByte(buffer(5)), FuelPointStatus)
                    fuelPoint.CurrentPendingCommand = buffer(6)

                    If fuelPoint.PreviousPendingCommand <> fuelPoint.CurrentPendingCommand Then
                        fuelPoint.PreviousPendingCommand = fuelPoint.CurrentPendingCommand
                    End If

                Case UnipumpUtils.uAmountInfoResponse 'AmountInfoResponse
                    fuelPoint.ID = AsciiConversion.AsciiToByte(buffer(2))
                    fuelPoint.TransactionID = AsciiConversion.AsciiToInt(buffer(4), buffer(5))

                    If AsciiConversion.AsciiToByte(buffer(6)) > 0 Then
                        fuelPoint.ActiveNozzleID = AsciiConversion.AsciiToByte(buffer(6))
                    Else
                        fuelPoint.ActiveNozzleID = 1
                    End If

                    fuelPoint.DispensedVolume = AsciiConversion.AsciiToInt(buffer(7), buffer(8), buffer(9), buffer(10), buffer(11), buffer(12), buffer(13), buffer(14))
                    fuelPoint.DispensedAmount = fuelPoint.DispensedVolume * (CSng(fuelPoint.ActiveNozzle.PricePerLiter) / 100)
                    fuelPoint.Status = FuelPointStatus.WORK

                Case UnipumpUtils.uTransactionInfoResponse 'TransactionInfoResponse
                    fuelPoint.ID = AsciiConversion.AsciiToByte(buffer(2))
                    fuelPoint.TransactionID = AsciiConversion.AsciiToInt(buffer(4), buffer(5))
                    If AsciiConversion.AsciiToByte(buffer(6)) > 0 Then
                        fuelPoint.ActiveNozzleID = AsciiConversion.AsciiToByte(buffer(6))
                        fuelPoint.TransactionNozzleID = AsciiConversion.AsciiToByte(buffer(6))
                    Else
                        fuelPoint.ActiveNozzleID = 1
                        fuelPoint.TransactionNozzleID = 1
                    End If

                    fuelPoint.Nozzles(fuelPoint.ActiveNozzleID - 1).PricePerLiter = Convert.ToInt16(AsciiConversion.AsciiToInt(buffer(15), buffer(16), buffer(17), buffer(18)))
                    fuelPoint.DispensedVolume = AsciiConversion.AsciiToInt(buffer(7), buffer(8), buffer(9), buffer(10), buffer(11), buffer(12), buffer(13), buffer(14))
                    fuelPoint.DispensedAmount = AsciiConversion.AsciiToInt(buffer(19), buffer(20), buffer(21), buffer(22), buffer(23), buffer(24), buffer(25), buffer(26))

                    If fuelPoint.Status <> FuelPointStatus.TRANSACTIONSTOPPED Then
                        fuelPoint.Status = FuelPointStatus.TRANSACTIONCOMPLETED
                    End If
                    fuelPoint.OnTransactionFinished(New TransactionEventArgs(fuelPoint.TransactionID, fuelPoint.ActiveNozzleID, fuelPoint.DispensedAmount, fuelPoint.DispensedVolume, fuelPoint.Nozzles(fuelPoint.ActiveNozzleID - 1).PricePerLiter))

                Case UnipumpUtils.uTotalInfoResponse 'TotalInfoResponse
                    fuelPoint.ID = AsciiConversion.AsciiToByte(buffer(2))
                    Dim nozzleId As Byte

                    If AsciiConversion.AsciiToByte(buffer(6)) > 0 Then
                        nozzleId = AsciiConversion.AsciiToByte(buffer(6))
                    Else
                        nozzleId = 1
                    End If

                    fuelPoint.ActiveNozzleID = nozzleId

                    fuelPoint.TransactionID = AsciiConversion.AsciiToInt(buffer(4), buffer(5))
                    fuelPoint.Nozzles(nozzleId - 1).TotalDispensedAmount = AsciiConversion.AsciiToInt(buffer(7), buffer(8), buffer(9), buffer(10), buffer(11), buffer(12), buffer(13), buffer(14), buffer(15), buffer(16))
                    fuelPoint.Nozzles(nozzleId - 1).TotalDispensedVolume = AsciiConversion.AsciiToInt(buffer(17), buffer(18), buffer(19), buffer(20), buffer(21), buffer(22), buffer(23), buffer(24), buffer(25), buffer(26))

                    OnTotalsUpdated(New TotalsEventArgs(fuelPoint.ID, nozzleId, fuelPoint.Nozzles(nozzleId - 1)))

                Case UnipumpUtils.uPricesResponse 'PricesResponse
                    fuelPoint.ID = AsciiConversion.AsciiToByte(buffer(2))
                    fuelPoint.Nozzles(0).PricePerLiter = AsciiConversion.AsciiToInt(buffer(4), buffer(5), buffer(6), buffer(7))
                    fuelPoint.Nozzles(1).PricePerLiter = AsciiConversion.AsciiToInt(buffer(8), buffer(9), buffer(10), buffer(11))
                    fuelPoint.Nozzles(2).PricePerLiter = AsciiConversion.AsciiToInt(buffer(12), buffer(13), buffer(14), buffer(15))
                    fuelPoint.Nozzles(3).PricePerLiter = AsciiConversion.AsciiToInt(buffer(16), buffer(17), buffer(18), buffer(19))
                    fuelPoint.Nozzles(4).PricePerLiter = AsciiConversion.AsciiToInt(buffer(20), buffer(21), buffer(22), buffer(23))
                    fuelPoint.Nozzles(5).PricePerLiter = AsciiConversion.AsciiToInt(buffer(24), buffer(25), buffer(26), buffer(27))
                    OnPricesGet(New PricesEventArgs(fuelPoint.ID))

                Case UnipumpUtils.uAtgMeasureResponse 'AtgMeasurementDataResponse
                    Dim atg As ATG = GetAtgByID(AsciiConversion.AsciiToByte(buffer(2)))

                    Dim value As Integer

                    ' Measurements of product level
                    If (buffer(4) And &H80) > 0 Then
                        atg.ProductHeightPresent = True
                        value = AsciiConversion.AsciiToInt(buffer(6), buffer(7), buffer(8), buffer(9), buffer(10), buffer(11))
                        atg.ProductHeight = CDbl(value) / 10 ' Normalize to mm
                    Else
                        atg.ProductHeightPresent = False
                        atg.ProductHeight = 0
                    End If

                    ' Measurements of water level
                    If (buffer(4) And &H40) > 0 Then
                        atg.WaterHeightPresent = True

                        value = AsciiConversion.AsciiToInt(buffer(12), buffer(13), buffer(14), buffer(15), buffer(16))
                        atg.WaterHeight = CDbl(value) / 10 ' Normalize to mm
                    Else
                        atg.WaterHeightPresent = False
                        atg.WaterHeight = 0
                    End If

                    ' Measurements of temperature
                    If (buffer(4) And &H20) > 0 Then
                        atg.TemperaturePresent = True

                        value = AsciiConversion.AsciiToInt(buffer(18), buffer(19), buffer(20))
                        atg.Temperature = CDbl(value) / 10 ' Normalize to degree Celcium

                        ' Temperature sign
                        If buffer(17) = &H2D Then
                            atg.Temperature = -atg.Temperature
                        End If
                    Else
                        atg.TemperaturePresent = False
                        atg.Temperature = 0
                    End If

                    ' Measurements of product volume
                    If (buffer(4) And &H10) > 0 Then
                        atg.ProductVolumePresent = True

                        value = AsciiConversion.AsciiToInt(buffer(21), buffer(22), buffer(23), buffer(24), buffer(25), buffer(26))
                        atg.ProductVolume = value \ 1 ' Normalize to l
                    Else
                        atg.ProductVolumePresent = False
                        atg.ProductVolume = 0
                    End If

                    ' Measurements of water volume
                    If (buffer(4) And &H8) > 0 Then
                        atg.WaterVolumePresent = True

                        value = AsciiConversion.AsciiToInt(buffer(27), buffer(28), buffer(29), buffer(30), buffer(31))
                        atg.WaterVolume = value \ 1 ' Normalize to l
                    Else
                        atg.WaterVolumePresent = False
                        atg.WaterVolume = 0
                    End If

                    ' Measurements of product ullage
                    If (buffer(4) And &H4) > 0 Then
                        atg.ProductUllagePresent = True

                        value = AsciiConversion.AsciiToInt(buffer(32), buffer(33), buffer(34), buffer(35), buffer(36), buffer(37))
                        atg.ProductUllage = value \ 1 ' Normalize to l
                    Else
                        atg.ProductUllagePresent = False
                        atg.ProductUllage = 0
                    End If

                    ' Measurements of product temperature compensated volume
                    If (buffer(4) And &H2) > 0 Then
                        atg.ProductTCVolumePresent = True

                        value = AsciiConversion.AsciiToInt(buffer(38), buffer(39), buffer(40), buffer(41), buffer(42), buffer(43))
                        atg.ProductTCVolume = value \ 1 ' Normalize to l
                    Else
                        atg.ProductTCVolumePresent = False
                        atg.ProductTCVolume = 0
                    End If

                    ' Measurements of product density
                    If (buffer(4) And &H1) > 0 Then
                        atg.ProductDensityPresent = True

                        value = AsciiConversion.AsciiToInt(buffer(44), buffer(45), buffer(46), buffer(47))
                        atg.ProductDensity = CDbl(value) / 10 ' Normalize to kg/m3
                    Else
                        atg.ProductDensityPresent = False
                        atg.ProductDensity = 0
                    End If

                    ' Measurements of product mass
                    If (buffer(5) And &H80) > 0 Then
                        atg.ProductMassPresent = True

                        value = AsciiConversion.AsciiToInt(buffer(48), buffer(49), buffer(50), buffer(51), buffer(52), buffer(53), buffer(54))
                        atg.ProductMass = CDbl(value) / 10 ' Normalize to kg
                    Else
                        atg.ProductMassPresent = False
                        atg.ProductMass = 0
                    End If

                    atg.OnDataUpdated()

                Case UnipumpUtils.uExtended 'Extended responses
                    _responseExtCode = buffer(4)

                    Dim dataBytes As New List(Of Byte)()
                    Dim strBuffer As String = String.Empty
                    Dim strData() As String

                    Select Case _responseExtCode
                        Case UnipumpUtils.uTransactionInfoResponse 'ExtendedTransactionInfoResponse
                            fuelPoint.ID = AsciiConversion.AsciiToByte(buffer(2))

                            For i As Integer = 5 To buffer.Length - 4 - 1
                                dataBytes.Add(buffer(i))
                            Next i

                            strData = AsciiConversion.BytesArrayToString(dataBytes.ToArray()).Split(";"c)

                            If strData.Length < 5 Then
                                Throw New Exception("Incorrect data format in uExtendedTransactionInfoResponse")
                            End If

                            For i As Integer = 0 To strData.Length - 1
                                If strData(i) = "" Then
                                    strData(i) = "0"
                                End If
                            Next i

                            fuelPoint.TransactionID = Convert.ToInt32(strData(0))
                            Dim nozzleId As Byte
                            If Convert.ToByte(strData(1)) > 0 Then
                                nozzleId = Convert.ToByte(strData(1))
                            Else
                                nozzleId = 1
                            End If

                            fuelPoint.ActiveNozzleID = nozzleId
                            fuelPoint.TransactionNozzleID = nozzleId

                            fuelPoint.Nozzles(fuelPoint.ActiveNozzleID - 1).PricePerLiter = Convert.ToInt32(strData(3))

                            fuelPoint.DispensedVolume = Convert.ToInt32(strData(2))
                            fuelPoint.DispensedAmount = Convert.ToInt32(strData(4))

                            If fuelPoint.Status <> FuelPointStatus.TRANSACTIONSTOPPED Then
                                fuelPoint.Status = FuelPointStatus.TRANSACTIONCOMPLETED
                            End If
                            fuelPoint.OnTransactionFinished(New TransactionEventArgs(fuelPoint.TransactionID, fuelPoint.ActiveNozzleID, fuelPoint.DispensedAmount, fuelPoint.DispensedVolume, fuelPoint.Nozzles(fuelPoint.ActiveNozzleID - 1).PricePerLiter))

                        Case UnipumpUtils.uTotalInfoResponse 'TotalInfoResponse
                            fuelPoint.ID = AsciiConversion.AsciiToByte(buffer(2))

                            For i As Integer = 5 To buffer.Length - 4 - 1
                                dataBytes.Add(buffer(i))
                            Next i

                            strData = AsciiConversion.BytesArrayToString(dataBytes.ToArray()).Split(";"c)

                            If strData.Length < 4 Then
                                Throw New Exception("Incorrect data format in uExtendedTotalInfoResponse")
                            End If

                            For i As Integer = 0 To strData.Length - 1
                                If strData(i) = "" Then
                                    strData(i) = "0"
                                End If
                            Next i

                            Dim nozzleId As Byte
                            If Convert.ToByte(strData(1)) > 0 Then
                                nozzleId = Convert.ToByte(strData(1))
                            Else
                                nozzleId = 1
                            End If

                            fuelPoint.ActiveNozzleID = nozzleId
                            fuelPoint.TransactionID = Convert.ToInt32(strData(0))
                            fuelPoint.Nozzles(nozzleId - 1).TotalDispensedAmount = Convert.ToInt64(strData(2))
                            fuelPoint.Nozzles(nozzleId - 1).TotalDispensedVolume = Convert.ToInt64(strData(3))

                            OnTotalsUpdated(New TotalsEventArgs(fuelPoint.ID, nozzleId, fuelPoint.Nozzles(nozzleId - 1)))

                        Case UnipumpUtils.uPricesResponse 'ExtendedPricesResponse
                            fuelPoint.ID = AsciiConversion.AsciiToByte(buffer(2))

                            For i As Integer = 5 To buffer.Length - 4 - 1
                                dataBytes.Add(buffer(i))
                            Next i

                            strData = AsciiConversion.BytesArrayToString(dataBytes.ToArray()).Split(";"c)

                            If strData.Length < 6 Then
                                Throw New Exception("Incorrect data format in uExtendedPricesResponse")
                            End If

                            For i As Integer = 0 To strData.Length - 1
                                If strData(i) = "" Then
                                    strData(i) = "0"
                                End If
                            Next i

                            fuelPoint.Nozzles(0).PricePerLiter = Convert.ToInt32(strData(0))
                            fuelPoint.Nozzles(1).PricePerLiter = Convert.ToInt32(strData(1))
                            fuelPoint.Nozzles(2).PricePerLiter = Convert.ToInt32(strData(2))
                            fuelPoint.Nozzles(3).PricePerLiter = Convert.ToInt32(strData(3))
                            fuelPoint.Nozzles(4).PricePerLiter = Convert.ToInt32(strData(4))
                            fuelPoint.Nozzles(5).PricePerLiter = Convert.ToInt32(strData(5))

                            OnPricesGet(New PricesEventArgs(fuelPoint.ID))
                    End Select
            End Select
        End Sub

        ''' <summary>
        ''' Sends a request to a PTS controller and checks validity of a response.
        ''' </summary>
        Private Sub sendMessage(ByVal address As Integer, ByVal message() As Byte)
            Dim buffer() As Byte = Nothing

            Monitor.Enter(_port)
            _port.Write(message, 0, message.Length)
            readResponseMessage(buffer)
            Monitor.Exit(_port)

            If buffer Is Nothing Then
                Return
            End If

            'Check CRC of the received packet
            If Not UnipumpUtils.IsValidMessage(buffer) Then
                OnMessageError(New MessageErrorEventArgs(buffer))
                Return
            End If

            Try
                processResponseMessage(address, buffer)
            Catch e1 As ArgumentOutOfRangeException
                OnMessageError(New MessageErrorEventArgs(buffer))
            End Try
        End Sub

        ''' <summary>
        ''' Receives a response from a PTS controller.
        ''' </summary>
        Private Sub readResponseMessage(<System.Runtime.InteropServices.Out()> ByRef response() As Byte)
            Dim buffer As New List(Of Byte)()
            Dim processedBuffer As New List(Of Byte)()
            Dim currentByte As Byte = 0
            Dim prevByte As Byte = 0
            Dim messageStart As Boolean = False
            response = Nothing
            Dim responseReceived As Boolean = False
            Dim currentTimeSpan As Integer = Date.Now.Millisecond

            Try
                Do While responseReceived = False
                    prevByte = currentByte
                    currentByte = CByte(_port.ReadByte())

                    If prevByte = UnipumpUtils.DLE AndAlso currentByte = UnipumpUtils.STX AndAlso messageStart = False Then
                        buffer.Add(prevByte)
                        messageStart = True
                    End If

                    If messageStart = False Then
                        Continue Do
                    End If

                    buffer.Add(currentByte)

                    If buffer.Capacity > _maxPacketSize Then
                        Throw New Exception("Error: Max receive packet size exceeded")
                    End If

                    If prevByte = UnipumpUtils.DLE AndAlso currentByte = UnipumpUtils.ETX Then
                        responseReceived = True ' End of packet
                    End If

                    ' No response received during maximum response timeout
                    If Date.Now.Millisecond > _maxResponseTimeout + currentTimeSpan Then
                        responseReceived = True ' Finish wait for response
                    End If
                Loop

                'Add first 2 bytes of the received packet
                processedBuffer.Add(buffer(0))
                processedBuffer.Add(buffer(1))

                For i As Integer = 2 To buffer.Count - 3
                    If buffer(i) = UnipumpUtils.DLE And buffer(i + 1) = UnipumpUtils.DLE And i <> buffer.Count - 3 Then
                        i = i + 1
                    End If
                    processedBuffer.Add(buffer(i))
                Next

                'Add last 2 bytes of the received packet
                processedBuffer.Add(buffer(buffer.Count - 2))
                processedBuffer.Add(buffer(buffer.Count - 1))

            Catch e1 As TimeoutException
                If _initializing Then
                    Monitor.Exit(_port)
                    Throw
                End If

                OnTimeoutExpired()
                Return
            End Try

            If processedBuffer.Count > 0 Then
                response = processedBuffer.ToArray()
            End If
        End Sub

        ''' <summary>
        ''' Gets and sets authorization type of a PTS controller over FuelPoints.
        ''' </summary>
        Public Property SelectedAuthorizationType() As AuthorizeType
            Get
                Return _selectedAuthorizationType
            End Get
            Set(ByVal value As AuthorizeType)
                If value = AuthorizeType.Volume OrElse value = AuthorizeType.Amount Then
                    _selectedAuthorizationType = value
                Else
                    Throw New InvalidOperationException("AuthorizeType enumeration out of range")
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets and sets whether polling authorization should be constantly made or once once if pump is in READY state.
        ''' </summary>
        Public Property AuthorizationPolling() As Boolean
            Get
                Return _authorizationPolling
            End Get
            Set(ByVal value As Boolean)
                _authorizationPolling = value
            End Set
        End Property

        ''' <summary>
        ''' Gets and sets whether to use general commands or extended commands
        ''' </summary>
        Public Property UseExtendedCommands() As Boolean
            Get
                Return _useExtendedCommands
            End Get
            Set(ByVal value As Boolean)
                _useExtendedCommands = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether it is necessary to request totalizers after each dispensing performed or not.
        ''' </summary>
        Public Property RequestTotalizers() As Boolean
            Get
                Return _requestTotalizers
            End Get
            Set(ByVal value As Boolean)
                _requestTotalizers = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether it is necessary to automatically authorize a dispenser when nozzle is up in postpayment mode or manually
        ''' </summary>
        Public Property AutomaticAuthorize() As Boolean
            Get
                Return _automaticAuthorize
            End Get
            Set(ByVal value As Boolean)
                _automaticAuthorize = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a value of volume to authorize a dispenser when manual mode is selected
        ''' </summary>
        Public Property ManualModeAuthorizeValue() As Integer
            Get
                Return _manualModeAuthorizeValue
            End Get
            Set(ByVal value As Integer)
                _manualModeAuthorizeValue = value
            End Set
        End Property

        Friend Sub OnMessageError(ByVal e As MessageErrorEventArgs)
        End Sub

        Protected Sub OnOpening()
            RaiseEvent Opening(Me, EventArgs.Empty)
        End Sub

        Protected Sub OnOpened()
            RaiseEvent Opened(Me, EventArgs.Empty)
        End Sub

        Protected Sub OnClosing()
            RaiseEvent Closing(Me, EventArgs.Empty)
        End Sub

        Protected Sub OnClosed()
            RaiseEvent Closed(Me, EventArgs.Empty)
        End Sub

        Protected Sub OnInitializing()
            RaiseEvent Initializing(Me, EventArgs.Empty)
        End Sub

        Protected Sub OnInitialized()
            RaiseEvent Initialized(Me, EventArgs.Empty)
        End Sub

        Friend Sub OnTimeoutExpired()
            RaiseEvent TimeoutExpired(Me, EventArgs.Empty)
        End Sub

        Friend Sub OnTotalsUpdated(ByVal e As TotalsEventArgs)
            Dim fp As New FuelPoint(Me)

            For Each fuelPoint As FuelPoint In FuelPoints
                If fuelPoint.ID = e.Address Then
                    fp = fuelPoint
                End If
            Next fuelPoint

            RaiseEvent TotalsUpdated(Me, e)

            If fp IsNot Nothing Then
                fp.OnTotalsUpdated(e)
            End If
        End Sub

        Friend Sub OnPricesGet(ByVal e As PricesEventArgs)
            Dim fp As New FuelPoint(Me)

            For Each fuelPoint As FuelPoint In FuelPoints
                If fuelPoint.ID = e.Address Then
                    fp = fuelPoint
                End If
            Next fuelPoint

            RaiseEvent PricesGet(Me, e)

            If fp IsNot Nothing Then
                fp.OnPricesGet(e)
            End If
        End Sub

        ''' <summary>
        ''' Event occures before closing a COM-port.
        ''' </summary>
        Public Event Closing As EventHandler

        ''' <summary>
        ''' Event occures after closing a COM-port.
        ''' </summary>
        Public Event Closed As EventHandler

        ''' <summary>
        ''' Event occures before beginning of initialization.
        ''' </summary>
        Public Event Initializing As EventHandler

        ''' <summary>
        ''' Event occures after of initialization.
        ''' </summary>
        Public Event Initialized As EventHandler

        ''' <summary>
        ''' Event occures before opening a COM-port.
        ''' </summary>
        Public Event Opening As EventHandler

        ''' <summary>
        ''' Event occures after opening a COM-port.
        ''' </summary>
        Public Event Opened As EventHandler

        ''' <summary>
        ''' Event occures after calling a method UpdateTotals(), in which data of an electronic totalizer is received.
        ''' </summary>
        Public Event TotalsUpdated As EventHandler(Of TotalsEventArgs)

        ''' <summary>
        ''' Event occures after calling a method UpdatePrices(), in which data of a prices of FuelPoint is received.
        ''' </summary>
        Public Event PricesGet As EventHandler(Of PricesEventArgs)

        ''' <summary>
        ''' Event occures when at request of data from a PTS controller duration of a response 
        ''' exceeds a value set in ResponseTimeout.
        ''' </summary>
        Public Event TimeoutExpired As EventHandler
    End Class

	''' <summary>
	''' Provides information on errors in transmitted messages.
	''' </summary>
	Friend Class MessageErrorEventArgs
		Inherits EventArgs
		Private _message() As Byte
		Private _errorCode As Integer

		Public Sub New(ByVal message() As Byte)
			Me._errorCode = -1
			Me._message = message
		End Sub

		Public Sub New(ByVal errorCode As Integer, ByVal message() As Byte)
			Me._errorCode = errorCode
			Me._message = message
		End Sub

		Public ReadOnly Property ErrorCode() As Integer
			Get
				Return _errorCode
			End Get
		End Property

		Public ReadOnly Property Message() As Byte()
			Get
				Return _message
			End Get
		End Property
	End Class

	''' <summary>
	''' Provides information for an event TotalsUpdated.
	''' </summary>
	'[ComVisible(true)]
	Public Class TotalsEventArgs
		Inherits EventArgs
		Private _address As Integer
		Private _nozzleId As Byte
		Private _nozzle As Nozzle

		''' <summary>
		''' Creates an exemplar of TotalsEventArgs class.
		''' </summary>
		''' <param name="address">Physical address of a FuelPoint.</param>
		''' <param name="nozzleId">Identifier of a nozzle, for which electronic totalizer was updated.</param>
		''' <param name="nozzle">Nozzle, for which electronic totalizer was updated.</param>
		Public Sub New(ByVal address As Integer, ByVal nozzleId As Byte, ByVal nozzle As Nozzle)
			Me._address = address
			Me._nozzleId = nozzleId
			Me._nozzle = nozzle
		End Sub

		''' <summary>
		''' Gets physical address of a FuelPoint.
		''' </summary>
		Public ReadOnly Property Address() As Integer
			Get
				Return _address
			End Get
		End Property

		''' <summary>
		''' Gets identifier of a nozzle, for which electronic totalizer was updated.
		''' </summary>
		Public ReadOnly Property NozzleID() As Byte
			Get
				Return _nozzleId
			End Get
		End Property

		''' <summary>
		''' Gets nozzle, for which electronic totalizer was updated.
		''' </summary>
		Public ReadOnly Property Nozzle() As Nozzle
			Get
				Return _nozzle
			End Get
		End Property
	End Class

	''' <summary>
	''' Provides information for an event PricesUpdated.
	''' </summary>
	'[ComVisible(true)]
	Public Class PricesEventArgs
		Inherits EventArgs
		Private _address As Integer

		''' <summary>
		''' Creates an exemplar of PricesEventArgs class.
		''' </summary>
		''' <param name="address">Physical address of a FuelPoint.</param>
		Public Sub New(ByVal address As Integer)
			Me._address = address
		End Sub

		''' <summary>
		''' Gets physical address of a FuelPoint.
		''' </summary>
		Public ReadOnly Property Address() As Integer
			Get
				Return _address
			End Get
		End Property
	End Class

	''' <summary>
	''' Provides information for an event TransactionFinished.
	''' </summary>
	'[ComVisible(true)]
	Public Class TransactionEventArgs
		Inherits EventArgs
		Private _transactionId As Integer
		Private _nozzle As Byte
		Private _dispensedAmount As Single
		Private _dispensedVolume As Integer
		Private _dispensedPrice As Single

		''' <summary>
		''' Creates an exemplar of TransactionEventArgs class.
		''' </summary>
		''' <param name="transactionId">Identifier of a transaction.</param>
		''' <param name="nozzle">Identifier of a nozzle.</param>
		''' <param name="dispensedAmount">Dispensed amount.</param>
		''' <param name="dispensedVolume">Dispensed volume.</param>
		Public Sub New(ByVal transactionId As Integer, ByVal nozzle As Byte, ByVal dispensedAmount As Single, ByVal dispensedVolume As Integer, ByVal dispensedPrice As Single)
			Me._transactionId = transactionId
			Me._nozzle = nozzle
			Me._dispensedAmount = dispensedAmount
			Me._dispensedVolume = dispensedVolume
			Me._dispensedPrice = dispensedPrice
		End Sub

		''' <summary>
		''' Gets identifier of a transaction.
		''' </summary>
		Public ReadOnly Property TransactionID() As Integer
			Get
				Return _transactionId
			End Get
		End Property

		''' <summary>
		''' Gets identifier of a nozzle.
		''' </summary>
		Public ReadOnly Property Nozzle() As Byte
			Get
				Return _nozzle
			End Get
		End Property

		''' <summary>
		''' Gets dispensed amount.
		''' </summary>
		Public ReadOnly Property DispensedAmount() As Single
			Get
				Return _dispensedAmount
			End Get
		End Property

		''' <summary>
		''' Gets dispensed volume.
		''' </summary>
		Public ReadOnly Property DispensedVolume() As Integer
			Get
				Return _dispensedVolume
			End Get
		End Property

		''' <summary>
		''' Gets dispensed price.
		''' </summary>
		Public ReadOnly Property DispensedPrice() As Single
			Get
				Return _dispensedPrice
			End Get
		End Property
	End Class

	Public Enum OrderModes
    ''' <summary>
    ''' Mode of dispensing with previous setting of order in system
    ''' 
    ''' </summary>
    Preset = 1
    ''' <summary>
    ''' Mode of dispensing with setting of order in dispenser or without setting of order
    ''' </summary>
    Manual = 2
  End Enum
End Namespace

Imports System.Text
Imports System.ComponentModel
Imports System.Runtime.InteropServices

Namespace TiT.PTS
	''' <summary>
	''' Provides control over a FuelPoint connected to a PTS controller.
	''' </summary>
	Public Class FuelPoint
		Private _status As FuelPointStatus
		Private _channel As FuelPointChannel
		Private _pts As PTS
		Private _nozzles() As Nozzle
		Private _activeNozzleId As Byte
		Private _transactionNozzleId As Byte
		Private _channelId As Integer
		Private _physicalAddress As Integer
		Private _transEventRised As Boolean
		Private _isActive As Boolean
		Private _transFinished As Boolean
		Private _currentPendingCommand As Byte
        Private _previousPendingCommand As Byte
        Private _nozzlesQuantity As Integer
		Private _orderMode As OrderModes

		''' <summary>
		''' Creates exemplar of ATG class.
		''' </summary>
		''' <param name="pts">Exemplar of parent PTS class.</param>
		Friend Sub New(ByVal pts As PTS)
			Me.AutocloseTransaction = True
			Me.Locked = False
			Me._nozzles = New Nozzle(PtsConfiguration.NozzleQuantity - 1){}
			Me._pts = pts
			Me._status = FuelPointStatus.OFFLINE
			Me._transEventRised = False
			Me._isActive = False
			Me._transFinished = False
			Me._transactionNozzleId = 0
            Me._orderMode = OrderModes.Preset
            Me._previousPendingCommand = 1

			For i As Integer = 0 To PtsConfiguration.NozzleQuantity - 1
				_nozzles(i) = New Nozzle(Me, CByte(i + 1))
			Next i
		End Sub

		''' <summary>
		''' Gets a currently taken up nozzle. 
		''' </summary>
		''' <remarks>
		''' If there is no taken up nozzle - then returns null (Nothing in Visual Basic).
		''' </remarks>
		Public ReadOnly Property ActiveNozzle() As Nozzle
			Get
				If ActiveNozzleID = 0 Then
					Return Nothing
				End If

				Return _nozzles(ActiveNozzleID - 1)
			End Get
		End Property

		''' <summary>
		''' Gets an identifier of a taken up nozzle. 
		''' </summary>
		''' <remarks>
		''' If there is no taken up nozzle - then returns 0.
		''' </remarks>
		Public Property ActiveNozzleID() As Byte
			Get
				Return _activeNozzleId
			End Get
			Friend Set(ByVal value As Byte)
				Dim prevValue As Byte = _activeNozzleId

				_activeNozzleId = value
				OnNozzleChanged(New NozzleChangedEventArgs(_activeNozzleId, prevValue))
			End Set
		End Property

		''' <summary>
		''' Gets an identifier of a nozzle, through which fuel was dispensed in last ransaction. 
		''' </summary>
		''' <remarks>
		''' If there was no transaction - then returns 0.
		''' </remarks>
		Public Property TransactionNozzleID() As Byte
			Get
				Return _transactionNozzleId
			End Get
			Friend Set(ByVal value As Byte)
				_transactionNozzleId = value
			End Set
		End Property

		''' <summary>
		''' Gets code of command currently executed by PTS controller.
		''' </summary>
		Public Property CurrentPendingCommand() As Byte
			Get
				Return _currentPendingCommand
			End Get
			Friend Set(ByVal value As Byte)
				_currentPendingCommand = value
			End Set
		End Property

		''' <summary>
		''' Gets code of previous command executed by PTS controller.
		''' </summary>
		Public Property PreviousPendingCommand() As Byte
			Get
				Return _previousPendingCommand
			End Get
			Friend Set(ByVal value As Byte)
				_previousPendingCommand = value
			End Set
        End Property

        ''' <summary>
        ''' Gets or sets number on nozzles on FuelPoint.
        ''' </summary>
        Public Property NozzlesQuantity() As Integer
            Get
                Return _nozzlesQuantity
            End Get
            Set(ByVal value As Integer)
                _nozzlesQuantity = value
            End Set
        End Property

		''' <summary>
		''' Gets or sets a value, which points if a FuelPoint is active and it is necessary to query its state.
		''' </summary>
		Public Property IsActive() As Boolean
			Get
				Return _isActive
			End Get
			Set(ByVal value As Boolean)
				_isActive = value
			End Set
		End Property

		''' <summary>
		''' Gets or sets a value, which points that previous transaction has just finished (used in order to request totalizers at once after transaction is finished and closed).
		''' </summary>
		Public Property TransFinished() As Boolean
			Get
				Return _transFinished
			End Get
			Set(ByVal value As Boolean)
				_transFinished = value
			End Set
		End Property

		''' <summary>
		''' Gets or sets a value, which points whether transaction should be closed automatically or it is necessary 
		''' to close transaction manually after it is finished.
		''' </summary>
		Public Property AutocloseTransaction() As Boolean

		''' <summary>
		''' Gets unique identifier of a FuelPoint.
		''' </summary>
		Public Property ID() As Integer

		''' <summary>
		''' Gets or sets physical address of a FuelPoint.
		''' </summary>
		Public Property PhysicalAddress() As Integer
			Get
				Return _physicalAddress
			End Get
			Set(ByVal value As Integer)
				If value < 0 OrElse value > PtsConfiguration.FuelPointAddressQuantity Then
					Throw New ArgumentOutOfRangeException()
				End If

				_physicalAddress = value
			End Set
		End Property

		''' <summary>
		''' Gets or sets an identifier of a channel, to which a FuelPoint is connected.
		''' </summary>
		''' <remarks>
		''' If a FuelPoint is not connected to a channel then a value should be equal to zero.
		''' </remarks>
		Public Property ChannelID() As Integer
			Get
				Return _channelId
			End Get
			Set(ByVal value As Integer)
				If value < 0 OrElse value > PtsConfiguration.FuelPointChannelQuantity Then
					Throw New ArgumentOutOfRangeException()
				End If

				_channelId = value

				If value > 0 Then
					For Each fuelPointChannel As FuelPointChannel In _pts.FuelPointChannels
						If fuelPointChannel.ID = value Then
							_channel = fuelPointChannel
						End If
					Next fuelPointChannel
				End If
			End Set
		End Property

		''' <summary>
		''' Gets an object FuelPointChannel, to which a FuelPoint is connected.
		''' </summary>
		''' <remarks>
		''' If a FuelPoint is not connected to a channel - returns a value null (Nothing in Visual Basic).
		''' </remarks>     
		Public Property Channel() As FuelPointChannel
			Get
				Return _channel
			End Get
			Friend Set(ByVal value As FuelPointChannel)
				_channel = value
				If _channel IsNot Nothing Then
					_channelId = _channel.ID
				Else
					_channel = Nothing
				End If
			End Set
		End Property

		''' <summary>
		''' Gets or sets whether dispensing should be done when preset with previous setting of order in system or in dispenser
		''' </summary>     
		Public Property OrderMode() As OrderModes
			Get
				Return _orderMode
			End Get
			Set(ByVal value As OrderModes)
				_orderMode = value
			End Set
		End Property

		''' <summary>
		''' Gets an amount (in cents) for a current (in a case of an active transaction) or last fuel dispense.
		''' </summary>
		<Browsable(False)>
		Public Property DispensedAmount() As Single

		''' <summary>
		''' Gets a volume (in 10 ml units) for a current (in a case of an active transaction) or last fuel dispense.
		''' </summary>
		<Browsable(False)>
		Public Property DispensedVolume() As Integer

		''' <summary>
		''' Gets a value indicating whether a FuelPoint is locked.
		''' </summary>
		Private privateLocked As Boolean
		Public Property Locked() As Boolean
			Get
				Return privateLocked
			End Get
			Friend Set(ByVal value As Boolean)
				privateLocked = value
			End Set
		End Property

		''' <summary>
		'''  Gets an array of objects Nozzle connected to given a FuelPoint.
		''' </summary>
		Public ReadOnly Property Nozzles() As Nozzle()
			Get
				Return _nozzles
			End Get
		End Property

		''' <summary>
		''' Gets a status of a FuelPoint.
		''' </summary>
		Public Property Status() As FuelPointStatus
			Get
				Return _status
			End Get
			Set(ByVal value As FuelPointStatus)
				Dim prevStatus As FuelPointStatus

				If _status <> value Then
					prevStatus = _status
					_status = value
					OnStatusChanged(New StatusChangedEventArgs(_status, prevStatus))
				End If
			End Set
		End Property

		''' <summary>
		''' Gets or sets an identifier of a current transaction.
		''' </summary>
		Private privateTransactionID As Integer
		Public Property TransactionID() As Integer
			Get
				Return privateTransactionID
			End Get
			Friend Set(ByVal value As Integer)
				privateTransactionID = value
			End Set
		End Property

		''' <summary>
		''' Sends a command on authorization to a FuelPoint for a currently taken up nozzle and opens a transaction.
		''' </summary>
		''' <param name="autorizeType">Type of authorization.</param>
		''' <param name="orderAmount">Amount of order.</param>
		''' <param name="nozzleId">Identifier of authorized nozzle.</param>
		''' <remarks>
		''' In case of authorization is done by amount (AuthorizeType.Amount) <paramref name="orderAmmount"/>
		''' will have value in cents, in case of authorization is done by volume (AuthorizeType.Volume) 
		''' <paramref name="orderAmount"/> will have value in 10 ml units.
		''' Given method will work only when a property Status equals to FuelPointStatus.Nozzle and a FuelPoint is locked by a method Lock() (property Locked equals to true).
		''' After closing of a transaction it is necessary to call a method Unlock().
		''' </remarks>
		Public Sub Authorize(ByVal autorizeType As AuthorizeType, ByVal orderAmount As Integer, ByVal nozzleId As Byte)
			If _pts.UseExtendedCommands = False Then
				If ActiveNozzleID < 1 Then
					_pts.RequestAuthorize(ID, nozzleId, autorizeType, orderAmount, Nozzles(nozzleId - 1).PricePerLiter)
				Else
					_pts.RequestAuthorize(ID, ActiveNozzleID, autorizeType, orderAmount, ActiveNozzle.PricePerLiter)
				End If
			Else
				If ActiveNozzleID < 1 Then
					_pts.RequestExtendedAuthorize(ID, nozzleId, autorizeType, orderAmount, Nozzles(nozzleId - 1).PricePerLiter)
				Else
					_pts.RequestExtendedAuthorize(ID, ActiveNozzleID, autorizeType, orderAmount, ActiveNozzle.PricePerLiter)
				End If
			End If
		End Sub

		''' <summary>
		''' Closes current tranaction.
		''' </summary>
		''' <remarks>
		''' Given method needs to be called in a case if value of property Status 
		''' equals to FuelPointStatus.TransactionCompleted or FuelPointStatus.TransactionStopped.
		''' </remarks>
		Public Sub CloseTransaction()
			_pts.RequestCloseTransaction(ID, TransactionID)
		End Sub

		''' <summary>
		''' Stops dispensing of fuel through a FuelPoint.
		''' </summary>
		''' <remarks>
		''' If AutocloseTransaction equals to true then transaction closes automatically, at this
		''' property Status will be equal to FuelPointStatus.TransactionStopped.
		''' </remarks>
		Public Sub Halt()
			_pts.RequestHalt(ID)
			Status = FuelPointStatus.TRANSACTIONSTOPPED
		End Sub

		''' <summary>
		''' Locks control over a FuelPoint in a multi POS system (each POS system having a PTS controller connected).
		''' </summary>
		''' <remarks>
		''' Given method needs to be called before calling methods Autorize and UpdatePrices.
		''' </remarks>
		Public Sub Lock()
			_pts.RequestLock(ID)
		End Sub

		''' <summary>
		''' Unlocks control over a FuelPoint in a multi POS system (each POS system having a PTS controller connected).
		''' </summary>
		''' <remarks>
		''' Given method needs to be called after calling methods Autorize and UpdatePrices.
		''' </remarks>
		Public Sub Unlock()
			_pts.RequestUnlock(ID)
		End Sub

		''' <summary>
		''' Sets prices on fuel for nozzles in a FuelPoint in accordance with prices set by
		''' properties PricePerLiter of connected objects Nozzle.
		''' </summary>
		''' <remarks>
		''' Before calling a given method it is necessary to call a method Lock, and after it to call a method Unlock. 
		''' Before calling a method Unlock it is necessary to wait for a pause for prices to be updated (duration of a 
		''' pause may vary depending on fuel dispenser, in average up to 3 sec max).
		''' </remarks>
		Public Sub SetPrices()
			Dim prices(PtsConfiguration.NozzleQuantity - 1) As Integer
			For i As Integer = 0 To PtsConfiguration.NozzleQuantity - 1
				prices(i) = Me.Nozzles(i).PricePerLiter
			Next i

			If _pts.UseExtendedCommands = False Then
				_pts.RequestPricesSet(ID, prices)
			Else
				_pts.RequestExtendedPricesSet(ID, prices)
			End If
		End Sub

		''' <summary>
		''' Gets prices on fuel for nozzles in a FuelPoint.
		''' </summary>
		''' <remarks>
		''' Before calling a given method it is necessary to call a method Lock, and after it to call a method Unlock. 
		''' </remarks>
		Public Sub GetPrices()
			_pts.RequestPricesGet(ID)
		End Sub

		''' <summary>
		''' Gets total counters from the FuelPoint.
		''' </summary>
		''' <remarks>
		''' Before calling a given method it is necessary to call a method Lock, and after it to call a method Unlock. 
		''' </remarks>
		''' <param name="nozzleId">Identifier of the nozzle.</param>
		Public Sub GetTotals(ByVal nozzleId As Byte)
			If _pts.UseExtendedCommands = False Then
				_pts.RequestTotals(ID, nozzleId)
			Else
				_pts.RequestExtendedTotals(ID, nozzleId)
			End If
		End Sub

		''' <summary>
		''' Gets status of the FuelPoint.
		''' </summary>
		''' <remarks>
		''' Returns current status of the FuelPoint. 
		''' </remarks>
		Friend Sub GetStatus()
			If _pts.UseExtendedCommands = False Then
				_pts.RequestStatus(ID)
			Else
				_pts.RequestExtendedStatus(ID)
			End If
		End Sub

		Protected Sub OnNozzleChanged(ByVal e As NozzleChangedEventArgs)
			RaiseEvent NozzleChanged(Me, e)
		End Sub

		Protected Sub OnStatusChanged(ByVal e As StatusChangedEventArgs)
			RaiseEvent StatusChanged(Me, e)
		End Sub

		Protected Friend Sub OnPendingCommandChanged(ByVal e As PendingCommandChangedEventArgs)
			RaiseEvent PendingCommandChanged(Me, e)
		End Sub

		Protected Friend Sub OnTotalsUpdated(ByVal e As TotalsEventArgs)
			If e.Address = ID Then
				RaiseEvent TotalsUpdated(Me, e)
			End If
		End Sub

		Protected Friend Sub OnPricesGet(ByVal e As PricesEventArgs)
			If e.Address = ID Then
				RaiseEvent PricesGet(Me, e)
			End If
		End Sub

		Protected Friend Sub OnTransactionFinished(ByVal e As TransactionEventArgs)
			If AutocloseTransaction Then
				CloseTransaction()
			End If

			_transFinished = True

            If TransactionFinishedEvent IsNot Nothing Then
                _transEventRised = True
                RaiseEvent TransactionFinished(Me, e)
            End If
		End Sub

		Public Overrides Function ToString() As String
			Return String.Format("FuelPoint: ID={0}, Address={1}", ID, PhysicalAddress)
		End Function

		''' <summary>
		''' Event occures when another nozzle at FuelPoint is taken up.
		''' </summary>
		Public Event NozzleChanged As EventHandler(Of NozzleChangedEventArgs)

		''' <summary>
		''' Event occures when status of FuelPoint is changed.
		''' </summary>
		Public Event StatusChanged As EventHandler(Of StatusChangedEventArgs)

		''' <summary>
		''' Event occures when status of FuelPoint is changed.
		''' </summary>
		Public Event PendingCommandChanged As EventHandler(Of PendingCommandChangedEventArgs)

		''' <summary>
		''' Event occures when information about an electronic totalizer of one of the nozzles is updated.
		''' </summary>
		Public Event TotalsUpdated As EventHandler(Of TotalsEventArgs)

		''' <summary>
		''' Event occures when information about a price of one of the nozzles is updated.
		''' </summary>
		Public Event PricesGet As EventHandler(Of PricesEventArgs)

		''' <summary>
		''' Event occures every time when a transaction is finished normally or as a result of stoppage using a method Stop().
		''' </summary>
		Public Event TransactionFinished As EventHandler(Of TransactionEventArgs)
	End Class

	Public Class NozzleChangedEventArgs
		Inherits EventArgs
		Private _previousNozzleId As Byte
		Private _currentNozzleId As Byte

		Public Sub New(ByVal currentNozzleId As Byte, ByVal previousNozzleId As Byte)
			Me._currentNozzleId = currentNozzleId
			Me._previousNozzleId = previousNozzleId
		End Sub

		Public ReadOnly Property CurrentNozzleID() As Byte
			Get
				Return _currentNozzleId
			End Get
		End Property

		Public ReadOnly Property PreviousNozzleID() As Byte
			Get
				Return _previousNozzleId
			End Get
		End Property
	End Class

	Public Class StatusChangedEventArgs
		Inherits EventArgs
		Private _previousStatus As FuelPointStatus
		Private _currentStatus As FuelPointStatus

		Public Sub New(ByVal currentStatus As FuelPointStatus, ByVal previousStatus As FuelPointStatus)
			Me._currentStatus = currentStatus
			Me._previousStatus = previousStatus
		End Sub

		Public ReadOnly Property CurrentStatus() As FuelPointStatus
			Get
				Return _currentStatus
			End Get
		End Property

		Public ReadOnly Property PreviousStatus() As FuelPointStatus
			Get
				Return _previousStatus
			End Get
		End Property
	End Class

	Public Class PendingCommandChangedEventArgs
		Inherits EventArgs
		Private _previousPendingCommand As Byte
		Private _currentPendingCommand As Byte

		Public Sub New(ByVal currentPendingCommand As Byte, ByVal previousPendingCommand As Byte)
			Me._currentPendingCommand = currentPendingCommand
			Me._previousPendingCommand = previousPendingCommand
		End Sub

		Public ReadOnly Property CurrentPendingCommand() As Byte
			Get
				Return _currentPendingCommand
			End Get
		End Property

		Public ReadOnly Property PreviousPendingCommand() As Byte
			Get
				Return _previousPendingCommand
			End Get
		End Property
	End Class
End Namespace

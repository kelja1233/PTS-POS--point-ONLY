Imports System.Text

Namespace TiT.PTS
	''' <summary>
	''' Provides data on measurement of an ATG (automatic tank gauge) system.
	''' </summary>
	Public Class ATG
		Private _atgChannel As AtgChannel
		Private _pts As PTS
		Private _channelId As Integer
		Private _physicalAddress As Integer
		Private _isActive As Boolean

		''' <summary>
		''' Creates exemplar of ATG class.
		''' </summary>
		''' <param name="pts">Exemplar of parent PTS class</param>
		Friend Sub New(ByVal pts As PTS)
			Me._pts = pts
			Me._isActive = False

			Me.ProductHeight = 0
			Me.ProductVolume = 0
			Me.WaterHeight = 0
			Me.WaterVolume = 0
			Me.Temperature = 0
			Me.ProductUllage = 0
			Me.ProductTCVolume = 0
			Me.ProductDensity = 0
			Me.ProductMass = 0
			Me.MaxTankHeight = 0

			Me.ProductHeightPresent = False
			Me.ProductVolumePresent = False
			Me.WaterHeightPresent = False
			Me.WaterVolumePresent = False
			Me.TemperaturePresent = False
			Me.ProductUllagePresent = False
			Me.ProductTCVolumePresent = False
			Me.ProductDensityPresent = False
			Me.ProductMassPresent = False
		End Sub

		''' <summary>
		''' Gets unique identifier of an ATG.
		''' </summary>
		Public Property ID() As Integer

		''' <summary>
		''' Gets or sets physical address of an ATG.
		''' </summary>
		Public Property PhysicalAddress() As Integer
			Get
				Return _physicalAddress
			End Get
			Set(ByVal value As Integer)
				If value < 0 OrElse value > PtsConfiguration.AtgAddressQuantity Then
					Throw New ArgumentOutOfRangeException()
				End If

				_physicalAddress = value
			End Set
		End Property

		''' <summary>
		''' Gets or sets an identifier of a channel, to which an ATG is connected.
		''' </summary>
		''' <remarks>
		''' If an ATG is not connected to a channel then a value should be equal to zero.
		''' </remarks>
		Public Property ChannelID() As Integer
			Get
				Return _channelId
			End Get
			Set(ByVal value As Integer)
				If value < 0 OrElse value > PtsConfiguration.AtgChannelQuantity Then
					Throw New ArgumentOutOfRangeException()
				End If

				_channelId = value

				If value > 0 Then
					For Each atgChannel As AtgChannel In _pts.AtgChannels
						If atgChannel.ID = value Then
							_atgChannel = atgChannel
						End If
					Next atgChannel
				End If
			End Set
		End Property

		''' <summary>
		''' Gets an object AtgChannel, to which an ATG is connected.
		''' </summary>
		''' <remarks>
		''' If an ATG is not connected to a channel - returns a value null (Nothing in Visual Basic).
		''' </remarks>     
		Public Property Channel() As AtgChannel
			Get
				Return _atgChannel
			End Get
			Friend Set(ByVal value As AtgChannel)
				_atgChannel = value
				If _atgChannel IsNot Nothing Then
					_channelId = _atgChannel.ID
				Else
					_atgChannel = Nothing
				End If
			End Set
		End Property

		''' <summary>
		''' Requests ATG measurement resuls.
		''' </summary>
		Public Sub GetMeasurementData()
			_pts.RequestAtgMeasurementData(ID)
		End Sub

		''' <summary>
		''' Gets or sets a value, which points if an ATG is active and it is necessary to query its state.
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
		''' Gets a value of product level (in 0.1 millimeters) in tank.   
		''' </summary>     
		''' <remarks>
		''' If ATG system does not return value of products level - returns null (Nothing in Visual Basic).
		''' </remarks>
		Private privateProductHeight As Double
		Public Property ProductHeight() As Double
			Get
				Return privateProductHeight
			End Get
			Friend Set(ByVal value As Double)
				privateProductHeight = value
			End Set
		End Property

		''' <summary>
		''' Gets a boolean value indicating whether an ATG provides measurement of product level.
		''' </summary>
		Private privateProductHeightPresent As Boolean
		Public Property ProductHeightPresent() As Boolean
			Get
				Return privateProductHeightPresent
			End Get
			Friend Set(ByVal value As Boolean)
				privateProductHeightPresent = value
			End Set
		End Property

		''' <summary>
		''' Gets a value of product volume (in liters) in tank.  
		''' </summary>      
		''' <remarks>
		''' If ATG system does not return value of product volume - returns null (Nothing in Visual Basic).
		''' </remarks>
		Private privateProductVolume? As Integer
		Public Property ProductVolume() As Integer?
			Get
				Return privateProductVolume
			End Get
			Friend Set(ByVal value? As Integer)
				privateProductVolume = value
			End Set
		End Property

		''' <summary>
		''' Gets a boolean value indicating whether an ATG provides measurement of product volume.
		''' </summary>
		Private privateProductVolumePresent As Boolean
		Public Property ProductVolumePresent() As Boolean
			Get
				Return privateProductVolumePresent
			End Get
			Friend Set(ByVal value As Boolean)
				privateProductVolumePresent = value
			End Set
		End Property

		''' <summary>
		''' Gets a value of water level (in 0.1 millimeters) in tank.
		''' </summary>
		''' <remarks>
		''' If ATG system does not return value of water level - returns null (Nothing in Visual Basic).
		''' </remarks>
		Private privateWaterHeight As Double
		Public Property WaterHeight() As Double
			Get
				Return privateWaterHeight
			End Get
			Friend Set(ByVal value As Double)
				privateWaterHeight = value
			End Set
		End Property

		''' <summary>
		''' Gets a boolean value indicating whether an ATG provides measurement of water level.
		''' </summary>
		Private privateWaterHeightPresent As Boolean
		Public Property WaterHeightPresent() As Boolean
			Get
				Return privateWaterHeightPresent
			End Get
			Friend Set(ByVal value As Boolean)
				privateWaterHeightPresent = value
			End Set
		End Property

		''' <summary>
		''' Gets a value of water volume (in liters) in tank.
		''' </summary>
		''' <remarks>
		''' If ATG system does not return value of water volume - returns null (Nothing in Visual Basic).
		''' </remarks>
		Private privateWaterVolume? As Integer
		Public Property WaterVolume() As Integer?
			Get
				Return privateWaterVolume
			End Get
			Friend Set(ByVal value? As Integer)
				privateWaterVolume = value
			End Set
		End Property

		''' <summary>
		''' Gets a boolean value indicating whether an ATG provides measurement of water volume.
		''' </summary>
		Private privateWaterVolumePresent As Boolean
		Public Property WaterVolumePresent() As Boolean
			Get
				Return privateWaterVolumePresent
			End Get
			Friend Set(ByVal value As Boolean)
				privateWaterVolumePresent = value
			End Set
		End Property

		''' <summary>
		''' Gets a value of product temperature (in 0.1 degrees Celcium) in tank.
		''' </summary>
		''' <remarks>
		''' If ATG system does not return value of product temperature - returns null (Nothing in Visual Basic).
		''' </remarks>
		Private privateTemperature As Double
		Public Property Temperature() As Double
			Get
				Return privateTemperature
			End Get
			Friend Set(ByVal value As Double)
				privateTemperature = value
			End Set
		End Property

		''' <summary>
		''' Gets a boolean value indicating whether an ATG provides measurement of product temperature.
		''' </summary>
		Private privateTemperaturePresent As Boolean
		Public Property TemperaturePresent() As Boolean
			Get
				Return privateTemperaturePresent
			End Get
			Friend Set(ByVal value As Boolean)
				privateTemperaturePresent = value
			End Set
		End Property

		''' <summary>
		''' Gets a value of product ullage volume (in liters) in tank. 
		''' </summary>
		''' <remarks>
		''' If ATG system does not return value of product ullage volume - returns null (Nothing in Visual Basic).
		''' </remarks>
		Private privateProductUllage? As Integer
		Public Property ProductUllage() As Integer?
			Get
				Return privateProductUllage
			End Get
			Friend Set(ByVal value? As Integer)
				privateProductUllage = value
			End Set
		End Property

		''' <summary>
		''' Gets a boolean value indicating whether an ATG provides measurement of product ullage volume.
		''' </summary>
		Private privateProductUllagePresent As Boolean
		Public Property ProductUllagePresent() As Boolean
			Get
				Return privateProductUllagePresent
			End Get
			Friend Set(ByVal value As Boolean)
				privateProductUllagePresent = value
			End Set
		End Property

		''' <summary>
		''' Gets a value of product temperature compensated volume (in liters) in tank. 
		''' </summary>
		''' <remarks>
		''' If ATG system does not return value of product temperature compensated volume - returns null (Nothing in Visual Basic).
		''' </remarks>
		Private privateProductTCVolume? As Integer
		Public Property ProductTCVolume() As Integer?
			Get
				Return privateProductTCVolume
			End Get
			Friend Set(ByVal value? As Integer)
				privateProductTCVolume = value
			End Set
		End Property

		''' <summary>
		''' Gets a boolean value indicating whether an ATG provides measurement of product temperature compensated volume.
		''' </summary>
		Private privateProductTCVolumePresent As Boolean
		Public Property ProductTCVolumePresent() As Boolean
			Get
				Return privateProductTCVolumePresent
			End Get
			Friend Set(ByVal value As Boolean)
				privateProductTCVolumePresent = value
			End Set
		End Property

		''' <summary>
		''' Gets a value of product density (in 0.1 kilograms devided on cubic meters) in tank. 
		''' </summary>
		''' <remarks>
		''' If ATG system does not return value of product density - returns null (Nothing in Visual Basic).
		''' </remarks>
		Private privateProductDensity As Double
		Public Property ProductDensity() As Double
			Get
				Return privateProductDensity
			End Get
			Friend Set(ByVal value As Double)
				privateProductDensity = value
			End Set
		End Property

		''' <summary>
		''' Gets a boolean value indicating whether an ATG provides measurement of product density.
		''' </summary>
		Private privateProductDensityPresent As Boolean
		Public Property ProductDensityPresent() As Boolean
			Get
				Return privateProductDensityPresent
			End Get
			Friend Set(ByVal value As Boolean)
				privateProductDensityPresent = value
			End Set
		End Property

		''' <summary>
		''' Gets a value of product mass (in 0.1 kilograms) in tank. 
		''' </summary>
		''' <remarks>
		''' If ATG system does not return value of product mass - returns null (Nothing in Visual Basic).
		''' </remarks>
		Private privateProductMass As Double
		Public Property ProductMass() As Double
			Get
				Return privateProductMass
			End Get
			Friend Set(ByVal value As Double)
				privateProductMass = value
			End Set
		End Property

		''' <summary>
		''' Gets a boolean value indicating whether an ATG provides measurement of product mass.
		''' </summary>
		Private privateProductMassPresent As Boolean
		Public Property ProductMassPresent() As Boolean
			Get
				Return privateProductMassPresent
			End Get
			Friend Set(ByVal value As Boolean)
				privateProductMassPresent = value
			End Set
		End Property

		''' <summary>
		''' Maximum tank height (should be equal to ATG probe height).
		''' </summary>
		Public Property MaxTankHeight() As Integer

		Protected Friend Sub OnDataUpdated()
			RaiseEvent DataUpdated(Me, EventArgs.Empty)
		End Sub

		Public Overrides Function ToString() As String
			Return String.Format("ATG: ID={0}, Address={1}", ID, PhysicalAddress)
		End Function

		''' <summary>
		''' Event occures at update of measurements data from ATG.
		''' </summary>
		Public Event DataUpdated As EventHandler
	End Class
End Namespace

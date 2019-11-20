Imports System.Text
Imports System.Runtime.InteropServices

Namespace TiT.PTS
	''' <summary>
	''' Provides information about a nozzle of a FuelPoint.
	''' </summary>
	Public Class Nozzle
		Private _fuelPoint As FuelPoint
		Private _pricePerLiter As Integer
		Private _id As Byte

		''' <summary>
		''' Creates an exemplar of Nozzle class.
		''' </summary>
		''' <param name="fuelPoint">Exemplar of parent FuelPoint class.</param>
		''' <param name="id">Identifier of a nozzle.</param>
		Friend Sub New(ByVal fuelPoint As FuelPoint, ByVal id As Byte)
			Me._fuelPoint = fuelPoint
			Me._id = id
		End Sub

		''' <summary>
		''' Gets an object FuelPoint, to which a nozzle belongs to.
		''' </summary>
		Public ReadOnly Property FuelPoint() As FuelPoint
			Get
				Return _fuelPoint
			End Get
		End Property

		''' <summary>
		''' Gets an identifier of a nozzle.
		''' </summary>
		Public ReadOnly Property ID() As Byte
			Get
				Return _id
			End Get
		End Property

		''' <summary>
		''' Gets or sets price of fuel per liter/galon.
		''' </summary>
		''' <exception cref="T:System.ArgumentOutOfRangeException">
		''' Set value is less than zero.
		''' </exception>
		Public Property PricePerLiter() As Integer
			Get
				Return _pricePerLiter
			End Get
			Set(ByVal value As Integer)
				If value < 0 Then
					Throw New ArgumentOutOfRangeException()
				End If

				_pricePerLiter = value
			End Set
		End Property

		''' <summary>
		''' Gets a value of totally dispensed amount (in cents) of electronic totalizer.
		''' </summary>
		Private privateTotalDispensedAmount As Int64
		Public Property TotalDispensedAmount() As Int64
			Get
				Return privateTotalDispensedAmount
			End Get
			Friend Set(ByVal value As Int64)
				privateTotalDispensedAmount = value
			End Set
		End Property

		''' <summary>
		''' Gets a value of totally dispensed volume (in 10 ml units) of electronic totalizer.
		''' </summary>
		Private privateTotalDispensedVolume As Int64
		Public Property TotalDispensedVolume() As Int64
			Get
				Return privateTotalDispensedVolume
			End Get
			Friend Set(ByVal value As Int64)
				privateTotalDispensedVolume = value
			End Set
		End Property

		''' <summary>
		''' Requests a FuelPoint on values of electronic totalizer.
		''' </summary>
		Public Sub UpdateTotals()
			_fuelPoint.GetTotals(_id)
		End Sub

		Public Overrides Function ToString() As String
			Return String.Format("Nozzle{0}", ID)
		End Function
	End Class
End Namespace

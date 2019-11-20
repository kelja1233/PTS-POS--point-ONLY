Imports System.Text

Namespace TiT.PTS
	''' <summary>
	''' Provides information about a PTS controller parameter.
	''' </summary>
	Public Class PtsParameter
		''' <summary>
		''' Gets a value of parameter address.
		''' </summary>
		Private privateParameterAddress As Short
		Public Property ParameterAddress() As Short
			Get
				Return privateParameterAddress
			End Get
			Friend Set(ByVal value As Short)
				privateParameterAddress = value
			End Set
		End Property

		''' <summary>
		''' Gets a value of parameter number.
		''' </summary>
		Private privateParameterNumber As Integer
		Public Property ParameterNumber() As Integer
			Get
				Return privateParameterNumber
			End Get
			Friend Set(ByVal value As Integer)
				privateParameterNumber = value
			End Set
		End Property

		''' <summary>
		''' Gets a value of parameter.
		''' </summary>
		Private privateParameterValue As Byte()
		Public Property ParameterValue() As Byte()
			Get
				Return privateParameterValue
			End Get
			Friend Set(ByVal value As Byte())
				privateParameterValue = value
			End Set
		End Property
	End Class
End Namespace

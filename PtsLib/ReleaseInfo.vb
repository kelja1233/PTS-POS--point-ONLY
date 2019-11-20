Imports System.Text

Namespace TiT.PTS
	''' <summary>
	''' Provides information about a firmware version of PTS controller.
	''' </summary>
	Public Class ReleaseInfo
		''' <summary>
		''' Gets a firmware version date of PTS controller.
		''' </summary>
		Private privateReleaseDate As Date
		Public Property ReleaseDate() As Date
			Get
				Return privateReleaseDate
			End Get
			Friend Set(ByVal value As Date)
				privateReleaseDate = value
			End Set
		End Property

		''' <summary>
		''' Gets a firmware version number of PTS controller.
		''' </summary>
		Private privateReleaseNum As Short
		Public Property ReleaseNum() As Short
			Get
				Return privateReleaseNum
			End Get
			Friend Set(ByVal value As Short)
				privateReleaseNum = value
			End Set
		End Property

		''' <summary>
		''' Gets a full release firmware version name of PTS controller.
		''' </summary>
		Private privateReleaseVersion As String
		Public Property ReleaseVersion() As String
			Get
				Return privateReleaseVersion
			End Get
			Friend Set(ByVal value As String)
				privateReleaseVersion = value
			End Set
		End Property

		''' <summary>
		''' Gets a list of supported FuelPoint communication protocols by a firmware version of PTS controller.
		''' </summary>
		Private privateSupportedFuelPointProtocols As String()
		Public Property SupportedFuelPointProtocols() As String()
			Get
				Return privateSupportedFuelPointProtocols
			End Get
			Friend Set(ByVal value As String())
				privateSupportedFuelPointProtocols = value
			End Set
		End Property

		''' <summary>
		''' Gets a list of supported ATG communication protocols by a firmware version of PTS controller.
		''' </summary>
		Private privateSupportedAtgProtocols As String()
		Public Property SupportedAtgProtocols() As String()
			Get
				Return privateSupportedAtgProtocols
			End Get
			Friend Set(ByVal value As String())
				privateSupportedAtgProtocols = value
			End Set
		End Property
	End Class
End Namespace

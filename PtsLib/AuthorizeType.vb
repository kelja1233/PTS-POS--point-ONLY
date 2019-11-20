Imports System.Text

Namespace TiT.PTS
	''' <summary>
	''' Specifies a type of authorization for commands Authorize for a FuelPoint.
	''' </summary>
	Public Enum AuthorizeType
		''' <summary>
		''' Authorization by volume.
		''' </summary>
		Volume = &H4C
		''' <summary>
		''' Authorization by money amount.
		''' </summary>
		Amount = &H50
	End Enum
End Namespace

Imports System.Text
Imports TiT.Unipump

Namespace TiT.PTS
	''' <summary>
	''' Provides methods for various data conversions for processing of PTS controller messages.
	''' </summary>
	Public NotInheritable Class AsciiConversion
		''' <summary>
		''' Method for conversion from ascii bytes to byte.
		''' </summary>
		''' <param name="asciiByte">Initial ascii bytes value.</param>
		Private Sub New()
		End Sub
		Public Shared Function AsciiToByte(ByVal asciiByte As Byte) As Byte
			If asciiByte = 0 Then
				Return 0
			End If

			If asciiByte >= &H30 AndAlso asciiByte <= &H39 Then
				asciiByte -= &H30 '0-9
				Return asciiByte
			End If

			If asciiByte >= &H3a AndAlso asciiByte <= &H40 Then
				asciiByte -= &H30 'for devices with addresses 10 - 16
				Return asciiByte
			End If

			If asciiByte >= &H41 AndAlso asciiByte <= &H46 Then
				asciiByte -= &H37 'A-F
				Return asciiByte
			End If

			If asciiByte >= &H61 AndAlso asciiByte <= &H66 Then
				asciiByte -= &H57 'a-f
				Return asciiByte
			End If

			Throw New ArgumentOutOfRangeException()
		End Function

		''' <summary>
		''' Method for conversion from bytes to ascii byte.
		''' </summary>
		''' <param name="ordByte">Initial bytes value.</param>
		Public Shared Function ByteToAscii(ByVal ordByte As Byte) As Byte
			If ordByte > 16 Then
				Throw New ArgumentOutOfRangeException()
			End If
			Return CByte(ordByte Or &H30)
		End Function

		''' <summary>
		''' Method for conversion from bytes to ascii byte.
		''' </summary>
		''' <param name="ordByte">Initial bytes value.</param>
		Public Shared Function ByteToAsciiExt(ByVal ordByte As Byte) As Byte
			If ordByte > 16 Then
				Throw New ArgumentOutOfRangeException()
			End If

			If ordByte = 0 Then
				Return 0
			Else
				Return CByte(ordByte Or &H30)
			End If
		End Function

		''' <summary>
		''' Method for conversion from array of ascii bytes to int.
		''' </summary>
		''' <param name="asciiBytes">Initial array of ascii bytes.</param>
		Public Shared Function AsciiToInt(ParamArray ByVal asciiBytes() As Byte) As Integer
			Dim result As Integer = 0
			Dim bcdByte As Byte

			For i As Integer = 0 To asciiBytes.Length - 1
				bcdByte = asciiBytes(i)
				bcdByte -= &H30
				result = result * 10 + bcdByte
			Next i

			Return result
		End Function

		''' <summary>
		''' Method for conversion from int to array of ascii bytes.
		''' </summary>
		''' <param name="value">Initial int value.</param>
		''' <param name="length">Length of int value.</param>
		Public Shared Function IntToAscii(ByVal value As Integer, ByVal length As Integer) As Byte()
			Dim result As New List(Of Byte)()

			Do While value <> 0
				result.Insert(0, CByte((value Mod 10) Or &H30))
				value \= 10
			Loop

			If length > result.Count Then
				Dim count As Integer = length - result.Count

				For i As Integer = 0 To count - 1
					result.Insert(0, &H30)
				Next i
			End If

			Return result.ToArray()
		End Function

		''' <summary>
		''' Method for conversion from int to array of ascii bytes.
		''' </summary>
		''' <param name="value">Initial int value.</param>
		Public Shared Function IntToAsciiExt(ByVal value As Integer) As Byte()
			Dim result As New List(Of Byte)()

			If value > 0 Then
				Do While value <> 0
					result.Insert(0, CByte((value Mod 10) Or &H30))
					value \= 10
				Loop
			Else
				result.Insert(0, &H30)
			End If

			Return result.ToArray()
		End Function

		''' <summary>
		''' Method for conversion from array of ascii hexidecimal bytes to int.
		''' </summary>
		''' <param name="asciiBytes">Initial array of ascii hexidecimal bytes.</param>
		Public Shared Function HexAsciiToInt(ParamArray ByVal asciiBytes() As Byte) As Integer
			Dim result As Integer = 0
			Dim asciiByte As Byte

			For i As Integer = 0 To asciiBytes.Length - 1
				asciiByte = asciiBytes(i)

				If asciiByte >= &H30 AndAlso asciiByte <= &H39 Then
					asciiByte -= &H30 '0-9
				End If
				If asciiByte >= &H41 AndAlso asciiByte <= &H46 Then
					asciiByte -= &H37 'A-F
				End If
				If asciiByte >= &H61 AndAlso asciiByte <= &H66 Then
					asciiByte -= &H57 'a-f
				End If

				result = result * 16 + asciiByte
			Next i

			Return result
		End Function

		''' <summary>
		''' Method for conversion from array of bytes to string.
		''' </summary>
		''' <param name="bytesArray">Initial array of bytes.</param>
		Public Shared Function BytesArrayToString(ParamArray ByVal bytesArray() As Byte) As String
			Dim result As String = String.Empty

			If bytesArray Is Nothing Then
				Return result
			End If

			For i As Integer = 0 To bytesArray.Length - 1
				If bytesArray(i) >= &H30 AndAlso bytesArray(i) <= &H39 Then
					result &= bytesArray(i) - &H30 '0-9
				End If
				If bytesArray(i) = &H41 OrElse bytesArray(i) = &H61 Then '0xA or 0xa
					result &= "A"c
				End If
				If bytesArray(i) = &H42 OrElse bytesArray(i) = &H62 Then '0xB or 0xb
					result &= "B"c
				End If
				If bytesArray(i) = &H43 OrElse bytesArray(i) = &H63 Then '0xC or 0xc
					result &= "C"c
				End If
				If bytesArray(i) = &H44 OrElse bytesArray(i) = &H64 Then '0xD or 0xd
					result &= "D"c
				End If
				If bytesArray(i) = &H45 OrElse bytesArray(i) = &H65 Then '0xE or 0xe
					result &= "E"c
				End If
				If bytesArray(i) = &H46 OrElse bytesArray(i) = &H66 Then '0xF or 0xf
					result &= "F"c
				End If
				If bytesArray(i) = UnipumpUtils.uExtendedSeparator Then ';
					result &= ";"c
				End If
			Next i

			Return result
		End Function

		''' <summary>
		''' Method for conversion from string to array of bytes.
		''' </summary>
		''' <param name="initString">Initial string value.</param>
		Public Shared Function StringToBytesArray(ByVal initString As String) As Byte()
			Dim result As New List(Of Byte)()
			Dim initCharArray() As Char = initString.ToCharArray()

			For i As Integer = 0 To initCharArray.Length - 1
				result.Add(Convert.ToByte(initCharArray(i)))
			Next i

			Return result.ToArray()
		End Function
	End Class
End Namespace

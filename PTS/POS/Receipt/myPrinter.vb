Imports System.Drawing.Printing

Public Class myPrinter
  Friend TextToBePrinted As String
  Public Sub print(ByVal text As String)
    TextToBePrinted = text
    Dim prn As New Printing.PrintDocument
    Using (prn)
      prn.PrinterSettings.PrinterName = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Printerset", "Value", Nothing).ToString
      AddHandler prn.PrintPage, AddressOf Me.PrintPageHandler
      prn.Print()
      RemoveHandler prn.PrintPage, AddressOf Me.PrintPageHandler
    End Using
  End Sub

  Private Sub PrintPageHandler(ByVal sender As Object, ByVal args As Printing.PrintPageEventArgs)
    ' Dim myFont As New Font("Microsoft San Serif", 10)
    Dim h, w As Integer
    Dim left, top As Integer
    With args.MarginBounds
      h = 0
      w = 0
      left = 0
      top = 0
    End With
    Dim lines As Integer = CInt(Math.Round(h / 1))
    Dim b As New Rectangle(left, top, w, h)
    Dim format As StringFormat
    format = New StringFormat(StringFormatFlags.LineLimit)


    args.Graphics.DrawString(TextToBePrinted, New Font("Consolas", 8.55, FontStyle.Regular), Brushes.Black, b, Format)
  End Sub
End Class
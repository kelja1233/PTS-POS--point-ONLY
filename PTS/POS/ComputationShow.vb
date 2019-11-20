Imports TiT.PTS
Public Class ComputationShow

  Public Function TotalDiscount() As Decimal
    Dim total As Decimal = 0
    Try
      For i As Integer = 0 To TiT.PTS.MainForm.DataGridView2.RowCount - 1

        total += Decimal.Parse(TiT.PTS.MainForm.DataGridView2.Rows(i).Cells(5).Value.ToString)
      Next

      Return total
    Catch ex As Exception
      Return 0
    End Try
  End Function
  Public Function TotalAmount() As Decimal
    Dim total As Decimal = 0
    Try
      For i As Integer = 0 To TiT.PTS.MainForm.DataGridView2.RowCount - 1

        total += Decimal.Parse(TiT.PTS.MainForm.DataGridView2.Rows(i).Cells(4).Value.ToString)
      Next

      Return total
    Catch ex As Exception
      Return 0
    End Try
  End Function
  Public Function Tax() As Decimal
    Dim total As Decimal = 0
    Dim Discount As Decimal = 0
    Dim _Tax As Decimal = 0
    Try
      For i As Integer = 0 To TiT.PTS.MainForm.DataGridView2.RowCount - 1
        Discount += Decimal.Parse(TiT.PTS.MainForm.DataGridView2.Rows(i).Cells(5).Value.ToString)
        total += Decimal.Parse(TiT.PTS.MainForm.DataGridView2.Rows(i).Cells(4).Value.ToString)
      Next
      total = total - Discount
      _Tax = CDec(total - (total / 1.12))
      _Tax = CDec(Convert.ToDouble(_Tax))
      _Tax = Math.Round(_Tax, 2)
      _Tax = _Tax


      Return _Tax
    Catch ex As Exception
      Return 0
    End Try
  End Function
  Public Function Vat() As Decimal
    Dim total As Decimal = 0
    Dim Discount As Decimal = 0
    Dim _Vat As Decimal = 0
    Try
      For i As Integer = 0 To TiT.PTS.MainForm.DataGridView2.RowCount - 1
        Discount += Decimal.Parse(TiT.PTS.MainForm.DataGridView2.Rows(i).Cells(5).Value.ToString)
        total += Decimal.Parse(TiT.PTS.MainForm.DataGridView2.Rows(i).Cells(4).Value.ToString)
      Next
      total = total - Discount

      _Vat = CDec(total / 1.12)
      _Vat = CDec(Convert.ToDouble(_Vat))
      _Vat = Math.Round(_Vat, 2)
      _Vat = _Vat


      Return _Vat
    Catch ex As Exception
      Return 0
    End Try
  End Function



End Class

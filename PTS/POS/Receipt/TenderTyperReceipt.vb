Public Class TenderTyperReceipt

  Public Sub printRecord(tenderid As Integer, Discount As Decimal, tranNo As Integer)


    Dim RC As New ReceiptClass
    Select Case tenderid
      Case 1
        If MessageBox.Show("Do you want to Print?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
          RC.GetReceiptDetails(False, tenderid, tranNo)
          If Discount <> 0 Then
            RC.GetReceiptDetails(True, tenderid, tranNo)
          End If
        End If
      Case 2
        RC.GetReceiptDetails(False, tenderid, tranNo)
        RC.GetReceiptDetails(True, tenderid, tranNo)

      Case Else
        RC.GetReceiptDetails(False, tenderid, tranNo)

    End Select

  End Sub


End Class

Public Class frmPoint
  Private _batchnumber As Integer = 0
  Private _Numbercard As String = ""
  Private _CustomerName As String = ""
  Private _CustomerAct As String = ""
  Private _Totalpoint As Decimal = 0
  Private _geneartedPoint As Decimal = 0
  Private _stroreID As Integer = 0
  Private _cashierid As Integer = 0
  Public tenderId As Integer = 0
  Private Sub frmPoint_Load(sender As Object, e As EventArgs) Handles MyBase.Load

  End Sub


  Function generatePoint() As Decimal

    Dim GtPoint As Decimal = 0

    For i As Integer = 0 To TiT.PTS.MainForm.DataGridView2.RowCount - 1




      Dim ItemLookUp As String = TiT.PTS.MainForm.DataGridView2.Rows(i).Cells(0).Value.ToString
      Dim Quantity As Decimal = Decimal.Parse(TiT.PTS.MainForm.DataGridView2.Rows(i).Cells(2).Value.ToString)
      Dim Amount As Decimal = Decimal.Parse(TiT.PTS.MainForm.DataGridView2.Rows(i).Cells(4).Value.ToString)
      Dim Loayalty As Decimal = 0
      Dim Rebate As Decimal = Decimal.Parse(TiT.PTS.MainForm.DataGridView2.Rows(i).Cells(7).Value.ToString)
      Dim CCC As New ClassCheckCard
      Loayalty = CCC.GeneratedPoint(_Numbercard, ItemLookUp, Quantity, Amount)

      TiT.PTS.MainForm.DataGridView2.Rows(i).Cells(6).Value = Loayalty

      GtPoint += Loayalty

    Next

    Return GtPoint
  End Function

  Private Sub txtcode_TextChanged(sender As Object, e As EventArgs) Handles txtcode.TextChanged
    Dim CCcard As New ClassCheckCard

    Dim _checkCard As Boolean = False

    _checkCard = CCcard.checkcard(txtcode.Text)

    If _checkCard = True Then
      _batchnumber = TiT.PTS.MainForm.batchNumber
      _Numbercard = txtcode.Text
      _CustomerName = CCcard.CustomerName(_Numbercard)
      _CustomerAct = CCcard.CustomerAct(_Numbercard)
      _Totalpoint = CCcard.Totalpoint(_Numbercard)
      _stroreID = TiT.PTS.MainForm.storeid
      _cashierid = TiT.PTS.MainForm.Cashierid
      TiT.PTS.MainForm.txtact.Text = _CustomerAct
      TiT.PTS.MainForm.txtname.Text = _CustomerName

      txtname.Text = _CustomerName
      lblt.Text = _Totalpoint.ToString
      lbpoint.Text = generatePoint.ToString
      _geneartedPoint = generatePoint()
    Else
      _batchnumber = 0
      _Numbercard = txtcode.Text
      _CustomerName = ""
      _CustomerAct = ""
      _Totalpoint = 0
      _stroreID = 0
      TiT.PTS.MainForm.txtact.Text = _CustomerAct
      TiT.PTS.MainForm.txtname.Text = _CustomerName
    End If
  End Sub

  Private Sub btcash_Click(sender As Object, e As EventArgs) Handles btcash.Click
    Dim cmdIt As New CmdInsertTender
    Dim ccc As New ClassCheckCard
    Dim csp As New ComputationShow

    Dim discount As Decimal = csp.TotalDiscount
    tenderId = TiT.PTS.MainForm.tenderidz
    Dim ShiftNumber = TiT.PTS.MainForm.ShiftNumber
    Dim txtchange = TiT.PTS.MainForm.txtchange.Text
    Dim txtPlateNo = TiT.PTS.MainForm.txtPlateNo.Text
    Dim txtDN = TiT.PTS.MainForm.txtDN.Text
    If _geneartedPoint <> 0 Then
      Dim transactionnumber As Integer


      transactionnumber = cmdIt.InsertCashTransaction(tenderId, _CustomerAct, _stroreID, _batchnumber, _cashierid, _CustomerAct, txtDN, txtPlateNo, txtchange, ShiftNumber)
      ccc.dbsaves(_stroreID, _Numbercard, _batchnumber, _cashierid, _CustomerAct, _geneartedPoint)
      Dim sms As New SMSTextClass
      Dim message As String
      Dim CCcard As New ClassCheckCard
      message = "Privilege Card: " & "You have earned " & _geneartedPoint & " point/s. You have " & CCcard.Totalpoint(_Numbercard) & " point/s as of today"

      sms.message(CCcard.Customerid(_Numbercard), message)

      Dim ttr As New TenderTyperReceipt
      ttr.printRecord(tenderId, discount, transactionnumber)
      Me.Close()
    Else
      MessageBox.Show("No point detected")
    End If
  End Sub
End Class
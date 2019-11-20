Public Class ClassCheckCard


  Dim cmd As commands
  Public Sub New()


    cmd = New commands
    SQLConnect.txtserver.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_server", "Value", Nothing).ToString
    SQLConnect.txtdb.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_database", "Value", Nothing).ToString
    SQLConnect.txtuser.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_user", "Value", Nothing).ToString
    SQLConnect.txtpass.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Password", "Value", Nothing).ToString


  End Sub

  Public Function checkcard(cardnumber As String) As Boolean
    Try
      Dim codez As Integer = Integer.Parse(cmd.getSpecificRecord($"Select  0+COALESCE(Max(ID),0) FROM Point_Setting where code='{ cardnumber }'"))
      If codez <> 0 Then
        Return True
      Else
        Return False
      End If

    Catch ex As Exception
      Return False
    End Try
  End Function

  Public Function CustomerName(cardnumber As String) As String
    'Try
    Dim codez As Integer = Integer.Parse(cmd.getSpecificRecord($"Select  0+COALESCE(Max(ID),0) FROM Point_Setting where code='{ cardnumber }'"))
      Dim Fname As String = ""
      Dim Lname As String = ""
      If codez <> 0 Then
      Fname = cmd.getSpecificRecord($"Select FirstName FROM Customer where  id='{codez}'")
      Lname = cmd.getSpecificRecord($"Select lastname FROM Customer where   id='{codez}'")
    Else
        Fname = ""
        Lname = ""
      End If
      Return Fname + " " + Lname
    '  Catch ex As Exception
    '    Return ""
    '  End Try
  End Function
  Public Function Customerid(cardnumber As String) As Integer
    'Try
    Dim codez As Integer = Integer.Parse(cmd.getSpecificRecord($"Select  0+COALESCE(Max(ID),0) FROM Point_Setting where code='{ cardnumber }'"))

    Return codez
    'Catch ex As Exception
    '  Return ""
    'End Try
  End Function
  Public Function CustomerAct(cardnumber As String) As String
    'Try
    Dim codez As Integer = Integer.Parse(cmd.getSpecificRecord($"Select  0+COALESCE(Max(ID),0) FROM Point_Setting where code='{ cardnumber }'"))
      Dim AccountNumber As String = ""

      If codez <> 0 Then
        AccountNumber = cmd.getSpecificRecord($"Select AccountNumber FROM Customer where  id='{ codez }'")

      Else
        AccountNumber = ""

      End If
      Return AccountNumber
    'Catch ex As Exception
    '  Return ""
    'End Try
  End Function


  Public Function Totalpoint(cardnumber As String) As Decimal
    'Try
    Dim codez As Integer = Integer.Parse(cmd.getSpecificRecord($"Select  0+COALESCE(Max(ID),0) FROM Point_Setting where code='{ cardnumber }'"))
      Dim _totalpoint As Decimal = 0

      If codez <> 0 Then
        _totalpoint = Decimal.Parse(cmd.getSpecificRecord($"Select  0+COALESCE( Customer.CustomNumber1,0) FROM Customer where  id='{ codez }'"))

      Else
        _totalpoint = 0

      End If
      Return _totalpoint
    'Catch ex As Exception
    '  Return 0
    'End Try
  End Function
  Public Sub dbsaves(storeid As Integer, Cardnumber As String, batch As Integer, Cashierid As Integer, accountnumber As String, totalpointG As Decimal)

    Dim _storeid = storeid
    Dim Customerid = cmd.getSpecificRecord($"Select ID FROM Point_Setting where code='{Cardnumber}'")

    Dim _batch = batch

    Dim _Cashierid = Cashierid
    Dim _accountnumber = accountnumber

    Dim tranNo = cmd.getSpecificRecord("SELECT  0+COALESCE(Max([TransactionNumber]),0)  FROM [Transaction]  ")
    Dim _totalpointG As Decimal = totalpointG






    cmd.AddRecord($"INSERT INTO Point_Transaction ([Cashier],[StoreID],[BatchNo] ,[CustomerID],[LoyalPoint],[RebatesPoint],[TransactionNumber],[Datenow],[AccountNumber],[Point_Tansfer_Status]) values('{ Cashierid }','{storeid }','{ batch }','{Customerid}','{ _totalpointG}',0,'{tranNo }',getdate(),'{ accountnumber }','0')")

    cmd.Update($"UPDATE Customer SET  [CustomNumber1]=[CustomNumber1]+{  _totalpointG }   where ID='{Customerid}' ")
    Dim totalpoint As Double = Decimal.Parse(cmd.getSpecificRecord($"SELECT  0+COALESCE([CustomNumber1],0) FROM [Customer]  where ID='{Customerid}'"))


    cmd.Update($"UPDATE [Transaction] SET [CustomNumber1]='" & totalpoint & "',[PointStatus]=1  where TransactionNumber='" & tranNo & "' ")



  End Sub
  Public Function GeneratedPoint(cardnumber As String, Itemlookupcode As String, Qty As Decimal, amt As Decimal) As Decimal
    Dim _cardnumber As String = cardnumber
    Dim _Itemlookupcode As String = Itemlookupcode
    Dim _Qty As Decimal = Qty
    Dim _amt As Decimal = amt
    Dim GPC As Decimal = 0
    Dim set1 As Integer = Integer.Parse(cmd.getSpecificRecord($"Select Diesel FROM Point_Setting where code='{_cardnumber }'"))
    Dim set2 As Integer = Integer.Parse(cmd.getSpecificRecord($"Select Premium FROM Point_Setting where code='{_cardnumber }'"))
    Dim set3 As Integer = Integer.Parse(cmd.getSpecificRecord($"Select Unleaded FROM Point_Setting where code='{_cardnumber }'"))
    Dim set4 As Integer = Integer.Parse(cmd.getSpecificRecord($"Select Regular FROM Point_Setting where code='{_cardnumber }'"))

    Dim setCategory1 As Integer = Integer.Parse(cmd.getSpecificRecord($"Select item1 FROM Point_Setting where code='{_cardnumber }'"))
    Dim setCategory2 As Integer = Integer.Parse(cmd.getSpecificRecord($"Select item2 FROM Point_Setting where code='{_cardnumber }'"))
    Dim setCategory3 As Integer = Integer.Parse(cmd.getSpecificRecord($"Select item3 FROM Point_Setting where code='{_cardnumber }'"))
    Dim setCategory4 As Integer = Integer.Parse(cmd.getSpecificRecord($"Select item4 FROM Point_Setting where code='{_cardnumber }'"))


    Dim setCategory5 As Integer = Integer.Parse(cmd.getSpecificRecord($"Select item4 FROM Point_Setting where code='{_cardnumber }'"))
    Dim setCategory6 As Integer = Integer.Parse(cmd.getSpecificRecord($"Select item6 FROM Point_Setting where code='{_cardnumber }'"))
    Dim setCategory7 As Integer = Integer.Parse(cmd.getSpecificRecord($"Select item7 FROM Point_Setting where code='{_cardnumber }'"))
    Dim categoryId As Integer = Integer.Parse(cmd.getSpecificRecord($"Select CategoryID FROM Item where ItemLookupCode='{Itemlookupcode}'"))


    Select Case categoryId
      Case 1
        Select Case _Itemlookupcode
          Case "1"
            If set1 = 1 Then
              GPC = _amt / Decimal.Parse(cmd.getSpecificRecord($"Select Diesel FROM Point_loyalsetting_Quantity where code='{_cardnumber }'"))
            Else
              GPC = _Qty * Decimal.Parse(cmd.getSpecificRecord($"Select Diesel FROM Point_loyalsetting_amount where Code='{_cardnumber }'"))
            End If
          Case "11"
            If set1 = 1 Then
              GPC = _amt / Decimal.Parse(cmd.getSpecificRecord($"Select Diesel FROM Point_loyalsetting_Quantity where code='{_cardnumber }'"))
            Else
              GPC = _Qty * Decimal.
                Parse(cmd.getSpecificRecord($"Select Diesel FROM Point_loyalsetting_amount where Code='{_cardnumber }'"))
            End If
          Case "111"
            If set1 = 1 Then
              GPC = _amt / Decimal.Parse(cmd.getSpecificRecord($"Select Diesel FROM Point_loyalsetting_Quantity where code='{_cardnumber }'"))
            Else
              GPC = _Qty * Decimal.Parse(cmd.getSpecificRecord($"Select Diesel FROM Point_loyalsetting_amount where Code='{_cardnumber }'"))
            End If
          Case "2"
            If set2 = 1 Then
              GPC = _amt / Decimal.Parse(cmd.getSpecificRecord($"Select Premium FROM Point_loyalsetting_Quantity where code='{_cardnumber }'"))
            Else
              GPC = _Qty * Decimal.Parse(cmd.getSpecificRecord($"Select Premium FROM Point_loyalsetting_amount where Code='{_cardnumber }'"))
            End If
          Case "22"
            If set2 = 1 Then
              GPC = _amt / Decimal.Parse(cmd.getSpecificRecord($"Select Premium FROM Point_loyalsetting_Quantity where code='{_cardnumber }'"))
            Else
              GPC = _Qty * Decimal.Parse(cmd.getSpecificRecord($"Select Premium FROM Point_loyalsetting_amount where Code='{_cardnumber }'"))
            End If
          Case "222"
            If set2 = 1 Then
              GPC = _amt / Decimal.Parse(cmd.getSpecificRecord($"Select Premium FROM Point_loyalsetting_Quantity where code='{_cardnumber }'"))
            Else
              GPC = _Qty * Decimal.Parse(cmd.getSpecificRecord($"Select Premium FROM Point_loyalsetting_amount where Code='{_cardnumber }'"))
            End If
          Case "3"
            If set2 = 1 Then
              GPC = _amt / Decimal.Parse(cmd.getSpecificRecord($"Select Unleaded FROM Point_loyalsetting_Quantity where code='{_cardnumber }'"))
            Else
              GPC = _Qty * Decimal.Parse(cmd.getSpecificRecord($"Select Unleaded FROM Point_loyalsetting_amount where Code='{_cardnumber }'"))
            End If
          Case "33"
            If set2 = 1 Then
              GPC = _amt / Decimal.Parse(cmd.getSpecificRecord($"Select Unleaded FROM Point_loyalsetting_Quantity where code='{_cardnumber }'"))
            Else
              GPC = _Qty * Decimal.Parse(cmd.getSpecificRecord($"Select Unleaded FROM Point_loyalsetting_amount where Code='{_cardnumber }'"))
            End If
          Case "333"
            If set2 = 1 Then
              GPC = _amt / Decimal.Parse(cmd.getSpecificRecord($"Select Unleaded FROM Point_loyalsetting_Quantity where code='{_cardnumber }'"))
            Else
              GPC = _Qty * Decimal.Parse(cmd.getSpecificRecord($"Select Unleaded FROM Point_loyalsetting_amount where Code='{_cardnumber }'"))
            End If
          Case Else
            If setCategory1 = 1 Then
              GPC = _amt / Decimal.Parse(cmd.getSpecificRecord($"Select Item1 FROM Point_loyalsetting_Quantity where code='{_cardnumber }'"))
            Else
              GPC = _Qty * Decimal.Parse(cmd.getSpecificRecord($"Select Item1 FROM Point_loyalsetting_amount where Code='{_cardnumber }'"))
            End If
        End Select


      Case 2
        If setCategory2 = 1 Then
          GPC = _amt / Decimal.Parse(cmd.getSpecificRecord($"Select Item2 FROM Point_loyalsetting_Quantity where code='{_cardnumber }'"))
        Else
          GPC = _Qty * Decimal.Parse(cmd.getSpecificRecord($"Select Item2 FROM Point_loyalsetting_amount where Code='{_cardnumber }'"))
        End If
      Case 3
        If setCategory3 = 1 Then
          GPC = _amt / Decimal.Parse(cmd.getSpecificRecord($"Select Item3 FROM Point_loyalsetting_Quantity where code='{_cardnumber }'"))
        Else
          GPC = _Qty * Decimal.Parse(cmd.getSpecificRecord($"Select Item3 FROM Point_loyalsetting_amount where Code='{_cardnumber }'"))
        End If
      Case 4
        If setCategory4 = 1 Then
          GPC = _amt / Decimal.Parse(cmd.getSpecificRecord($"Select Item4 FROM Point_loyalsetting_Quantity where code='{_cardnumber }'"))
        Else
          GPC = _Qty * Decimal.Parse(cmd.getSpecificRecord($"Select Item4 FROM Point_loyalsetting_amount where Code='{_cardnumber }'"))
        End If

      Case 5
        If setCategory5 = 1 Then
          GPC = _amt / Decimal.Parse(cmd.getSpecificRecord($"Select Item5 FROM Point_loyalsetting_Quantity where code='{_cardnumber }'"))
        Else
          GPC = _Qty * Decimal.Parse(cmd.getSpecificRecord($"Select Item5 FROM Point_loyalsetting_amount where Code='{_cardnumber }'"))
        End If

      Case 6
        If setCategory6 = 1 Then
          GPC = _amt / Decimal.Parse(cmd.getSpecificRecord($"Select Item6 FROM Point_loyalsetting_Quantity where code='{_cardnumber }'"))
        Else
          GPC = _Qty * Decimal.Parse(cmd.getSpecificRecord($"Select Item6 FROM Point_loyalsetting_amount where Code='{_cardnumber }'"))
        End If

      Case 7
        If setCategory6 = 1 Then
          GPC = _amt / Decimal.Parse(cmd.getSpecificRecord($"Select Item7 FROM Point_loyalsetting_Quantity where code='{_cardnumber }'"))
        Else
          GPC = _Qty * Decimal.Parse(cmd.getSpecificRecord($"Select Item7 FROM Point_loyalsetting_amount where Code='{_cardnumber }'"))
        End If
    End Select
    GPC = Math.Round(GPC, 3)
    Return GPC


  End Function

End Class

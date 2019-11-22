Imports System.IO.Ports
Imports System.Windows.Forms
Imports System.Management
Imports System.Threading
Public Class frmRedeem
    Dim cmd As New commands
    Dim SerialPort1 As New System.IO.Ports.SerialPort()
    Private Sub frmRedeem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    SQLConnect.txtserver.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_server", "Value", Nothing).ToString
    SQLConnect.txtdb.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_database", "Value", Nothing).ToString
    SQLConnect.txtuser.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_user", "Value", Nothing).ToString
    SQLConnect.txtpass.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Password", "Value", Nothing).ToString
    txtcode.Clear()
    type()
        txtcode.Focus()

    End Sub

    Public Sub type()



        ' cmd.fillCombox(Me.ComboBox1, "SELECT DISTINCT([Description]) FROM [Item] where [CategoryID]=1", "[Item]", "Description")
        cmd.fillCombox(Me.ComboBox1, "SELECT DISTINCT([ItemName]) FROM [ItemRedeem] ", "[Item]", "ItemName")



    End Sub
    Public Sub item()



        ' cmd.fillCombox(Me.ComboBox1, "SELECT DISTINCT([Description]) FROM [Item] where [CategoryID]=1", "[Item]", "Description")
        'Dim c = cmd.getSpecificRecord("SELECT [point] FROM ItemRedeem where [ItemName]='" & ComboBox1.Text & "' ")
        'txtpointR.Text = c



    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        item()
    End Sub


    Private Sub txtcode_TextChanged(sender As Object, e As EventArgs) Handles txtcode.TextChanged
        recon()
    End Sub
    Public Sub recon()
        On Error Resume Next
        If txtcode.Text = "None" Then
            lbpoint.Text = 0

            txtname.Text = "none"
        ElseIf txtcode.Text = "none" Then
            lbpoint.Text = 0

            txtname.Text = "none"
        Else
            Dim codez = cmd.getSpecificRecord("Select  0+COALESCE(Max(ID),0) FROM Point_Setting where code='" & txtcode.Text & "'")


            If codez = 0 Then

                btredeem.Enabled = False
                Button3.Enabled = False

                lbpoint.Text = 0

                txtname.Text = "none"
            Else


                btredeem.Enabled = True
                Button3.Enabled = True


                Dim dateopen As DateTime = cmd.getSpecificRecord("Select DATEADD(year, 1, [LastUpdated]) FROM Customer where  id='" & codez & "'")

                Dim datenow As DateTime
                datenow = DateTime.Now.ToString("MM/dd/yyyy h:mm:ss tt")
                dateopen = dateopen.ToString("MM/dd/yyyy h:mm:ss tt")


                If CDate(dateopen) < CDate(datenow) Then
                    cmd.Update("UPDATE Customer SET  [LastUpdated]=DATEADD(year, 1, [LastUpdated]) ,CustomNumber1=0,CustomNumber2=0 where ID='" & codez & "' ")
                    MessageBox.Show("Account has been expire and renew")
                    Me.Close()

                Else



                End If
                txtname.Text = cmd.getSpecificRecord("Select lastname FROM Customer where  id='" & codez & "'") & ", " & cmd.getSpecificRecord("Select FirstName FROM Customer where  id='" & codez & "'")



                lbpoint.Text = cmd.getSpecificRecord("Select CustomNumber1 FROM Customer where id= '" & codez & "'")






            End If
        End If

    End Sub

    Private Sub btredeem_Click(sender As Object, e As EventArgs) Handles btredeem.Click





        If Double.Parse(TextBox1.Text) > Double.Parse(lbpoint.Text) Then

            MessageBox.Show("You do not have Enough Loyalty Points")

        ElseIf Double.Parse(TextBox1.Text) = 0 Then


            MessageBox.Show("Pls Insert Amount")

        Else


            Dim storeid = cmd.getSpecificRecord("Select [StoreID] FROM [Configuration]")

            Dim BatchNo = cmd.getSpecificRecord("SELECT  0+COALESCE(Max([BatchNumber]),0)  FROM [Batch]  ")

            Dim Cashierid = cmd.getSpecificRecord("SELECT       [CashierID]  FROM [Transaction]  where [TransactionNumber]= (SELECT     max  ([TransactionNumber])  FROM [Transaction]) ")
            Dim codez = cmd.getSpecificRecord("Select  0+COALESCE(Max(ID),0) FROM Point_Setting where code='" & txtcode.Text & "'")
            Dim c = TextBox1.Text



            Dim accountnumber = cmd.getSpecificRecord("SELECT [AccountNumber] FROM [Customer]  where ID='" & codez & "'")

            Dim lbpointr As Double = Double.Parse(TextBox1.Text)
     
            Dim datenow As DateTime
            datenow = Date.Now.ToString("MM/dd/yyyy h:mm:ss tt")

      



            cmd.AddRecord("INSERT INTO Point_RedeemTransaction ([Cashier],[StoreID],[BatchNo] ,[CustomerID],[LoyalPoint],[RebatesPoint],[TransactionNumber],[Datenow],AccountNumber,[Point_Tansfer_Status],itemrid) values('" & Cashierid & "','" & storeid & "','" & BatchNo & "','" & codez & "','" & lbpointr & "','" & 0 & "','0','" & datenow & "','" & accountnumber & "','0','0')")


            cmd.Update("UPDATE Customer SET  [CustomNumber1]=[CustomNumber1]+'" & Double.Parse(TextBox1.Text) * -1 & "'   where ID='" & codez & "' ")

            BUPTender()

            Dim tranNo = cmd.getSpecificRecord("SELECT  0+COALESCE(Max([ID]),0)  FROM [TransacationTender]  ")
            Dim total123 As Double = cmd.getSpecificRecord("SELECT  0+COALESCE(Max([CustomNumber1]),0)  FROM [Customer] where ID='" & codez & "' ")


            cmd.Update("UPDATE TransacationTender SET Item_id=7, [EarnPoint]='" & Double.Parse(TextBox1.Text) * -1 & "', [TotalPoint]='" & total123 & "',[Change]=0 where Transaction_number='" & tranNo & "' ")



            Try

        Dim sms As New SMSTextClass




        Dim message As String
        message = "PETRA GAS LOYALTY CARD: " & "You have redeemed " & TextBox1.Text & " point/s. You have " & total123 & " point/s as of today"

        sms.message(codez, message)

      Catch ex As Exception

      End Try








      frmprint1.Close()
      frmprint1.ShowDialog()




      Button1.PerformClick()
      MessageBox.Show("Item has been Redeemed")
      TextBox1.Text = 0

      txtcode.Focus()



    End If







  End Sub
  Public Sub BUPTender()



    Dim storeid = cmd.getSpecificRecord("Select [StoreID] FROM [Configuration]")

    Dim batch = cmd.getSpecificRecord("SELECT  0+COALESCE(Max([BatchNumber]),0)  FROM [Batch]  ")


    Dim id = TiT.PTS.MainForm.Cashierid
    Dim idcus = cmd.getSpecificRecord("Select  0+COALESCE(Max(ID),0) FROM Point_Setting where code='" & txtcode.Text & "'")




    Dim tranNo1 = cmd.getSpecificRecord("SELECT        0 + COALESCE (MAX([Transaction].TranNo), 0)+1 FROM            [Transaction] INNER JOIN TenderEntry ON [Transaction].TransactionNumber = TenderEntry.TransactionNumber WHERE        (TenderEntry.TenderID = 7)")


    cmd.AddRecord("INSERT INTO [TransacationTender] ([Transaction_number],[Store_id],[Batch],[Cashier_id],[Customer_id],[Item_id],[Item_lookupcode],[Category_id],[Quantity],[Price],[Amount],[Total_amount],[Amount_paid],Discount,Total_Discount,[Change],[Tender_id],[TotalPoint],[TotalRebate],[EarnPoint],[EarnRebate],Transno )values( '" & tranNo1 & "','" & storeid & "','" & batch & "','" & id & "','" & idcus & "','0','0','0','0','0','0','0','0','0','0','0',7,0,0,0,0,'0')")





  End Sub






  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    lbpoint.Text = 0

    txtname.Text = "none"
    txtcode.Clear()
    txtcode.Focus()
    btredeem.Enabled = False
    Button3.Enabled = False
    txtcode.Focus()
  End Sub


  Private Sub btexit_Click(sender As Object, e As EventArgs) Handles btexit.Click
    Me.Close()
  End Sub

  Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    frmprint2.Close()
    frmprint2.ShowDialog()
    txtcode.Focus()
  End Sub

  Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
    If TextBox1.Text.Contains(".") Then
      Dim First As Integer = TextBox1.Text.IndexOf("."c)
      Dim Last As Integer = TextBox1.Text.LastIndexOf("."c)
      If First <> Last Then
        Dim StartPos = TextBox1.SelectionStart - 1
        TextBox1.Text = TextBox1.Text.Remove(TextBox1.SelectionStart - 1, 1)
        TextBox1.SelectionStart = StartPos
      End If
    End If


  End Sub

  Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
    If Char.IsPunctuation(e.KeyChar) And e.KeyChar.ToString <> "." Or Char.IsLetter(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Then 'Allows only numbers, "." and some keys like delete, backspace, enter, etc in Control

      e.Handled = True
    End If


  End Sub

  Private Sub DisallowPaste(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
    If e.Control AndAlso (e.KeyCode = Keys.V) Then e.SuppressKeyPress = True 'Disallows paste to TextBox. Or allowing only one decimal in textchanged event can fail.
    If (e.KeyCode = Keys.Space) Then e.SuppressKeyPress = True 'Disallows paste to TextBox. Or allowing only one decimal in textchanged event can fail.


  End Sub

  Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    TextBox1.Text = lbpoint.Text


    If Double.Parse(TextBox1.Text) > Double.Parse(lbpoint.Text) Then

      MessageBox.Show("You do not have Enough Loyalty Points")

    Else


      Dim storeid = cmd.getSpecificRecord("Select [StoreID] FROM [Configuration]")

      Dim BatchNo = cmd.getSpecificRecord("SELECT  0+COALESCE(Max([BatchNumber]),0)  FROM [Batch]  ")

      Dim Cashierid = cmd.getSpecificRecord("SELECT       [CashierID]  FROM [Transaction]  where [TransactionNumber]= (SELECT     max  ([TransactionNumber])  FROM [Transaction]) ")
      Dim codez = cmd.getSpecificRecord("Select  0+COALESCE(Max(ID),0) FROM Point_Setting where code='" & txtcode.Text & "'")




      Dim accountnumber = cmd.getSpecificRecord("SELECT [AccountNumber] FROM [Customer]  where ID='" & codez & "'")

      Dim lbpointr As Double = Double.Parse(TextBox1.Text)
      Dim datenow As DateTime
      datenow = Date.Now.ToString("MM/dd/yyyy h:mm:ss tt")





      cmd.AddRecord("INSERT INTO Point_RedeemTransaction ([Cashier],[StoreID],[BatchNo] ,[CustomerID],[LoyalPoint],[RebatesPoint],[TransactionNumber],[Datenow],AccountNumber,[Point_Tansfer_Status],itemrid) values('" & Cashierid & "','" & storeid & "','" & BatchNo & "','" & codez & "','" & lbpointr & "','" & 0 & "','0','" & datenow & "','" & accountnumber & "','0','0')")

      Dim maxidredeem As Integer = Integer.Parse(cmd.getSpecificRecord("Select  0+COALESCE(Max(ID),0) FROM Point_RedeemTransaction where  CustomerID='" & codez & "' "))

      cmd.Update("UPDATE Point_Transaction SET  [RebatesPoint]='" & maxidredeem & "'  where RebatesPoint=0 and CustomerID='" & codez & "' ")

      Dim pmaxid As Integer = Integer.Parse(cmd.getSpecificRecord("Select  0+COALESCE(Max(TransactionNumber),0) FROM Point_Transaction where  CustomerID='" & codez & "' and [RebatesPoint]='" & maxidredeem & "'  "))
      Dim pminid As Integer = Integer.Parse(cmd.getSpecificRecord("Select  0+COALESCE(min(TransactionNumber),0) FROM Point_Transaction where  CustomerID='" & codez & "' and [RebatesPoint]='" & maxidredeem & "'  "))



      cmd.Update("UPDATE Point_RedeemTransaction SET  [RebatesPoint]='" & pminid & "' ,TransactionNumber='" & pmaxid & "'  where ID='" & maxidredeem & "' ")

      cmd.Update("UPDATE Customer SET  [CustomNumber1]=0 where ID='" & codez & "' ")

      BUPTender()

      Dim tranNo = cmd.getSpecificRecord("SELECT  0+COALESCE(Max([ID]),0)  FROM [TransacationTender]  ")
      Dim total123 As Double = Integer.Parse(cmd.getSpecificRecord("SELECT  0+COALESCE(Max([CustomNumber1]),0)  FROM [Customer] where ID='" & codez & "' "))




      Dim sms As New SMSTextClass




      Dim message As String
      message = "PETRA GAS LOYALTY CARD: " & "You have redeemed " & TextBox1.Text & " point/s. You have " & total123 & " point/s as of today"

      sms.message(codez, message)



      Dim rp As New PrintRedeem
      rp.printRecord(False, maxidredeem, pminid, pmaxid, codez, TiT.PTS.MainForm.Cashierid)




      Button1.PerformClick()
            MessageBox.Show("Item has been Redeemed")
            TextBox1.Text = 0

            txtcode.Focus()



        End If



    End Sub
End Class

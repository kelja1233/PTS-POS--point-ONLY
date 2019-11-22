Public Class UpdatePoint
  Public Customerid As Integer = 0
  Dim cmd As New commands
  Private Sub UpdatePoint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    SQLConnect.txtserver.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_server", "Value", Nothing).ToString
    SQLConnect.txtdb.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_database", "Value", Nothing).ToString
    SQLConnect.txtuser.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_user", "Value", Nothing).ToString
    SQLConnect.txtpass.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Password", "Value", Nothing).ToString
    lb1.Text = cmd.getSpecificRecord("Select ( case when Description = null then ' ' else Description  end) FROM item where ItemLookupCode=1").ToString
    lb2.Text = cmd.getSpecificRecord("Select ( case when Description = null then ' ' else Description  end) FROM item where ItemLookupCode=2").ToString
    lb3.Text = cmd.getSpecificRecord("Select ( case when Description = null then ' ' else Description  end) FROM item where ItemLookupCode=3").ToString
    lb4.Text = cmd.getSpecificRecord("Select ( case when Description = null then ' ' else Description  end) FROM item where ItemLookupCode=4").ToString
    Tclear()
  End Sub
  Public Sub Tclear()

    Me.txtact.Clear()
    Me.txtfname.Clear()
    Me.txtlastname.Clear()
    Me.txtphone.Clear()
    Me.txttown.Clear()
    Me.txtcn.Clear()
    Me.Customerid = 0



    Me.txta1.Text = 0
    Me.txta2.Text = 0
    Me.txta3.Text = 0
    Me.txta4.Text = 0


  End Sub

  Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    ShowCustomer1.ShowDialog()
  End Sub

  Private Sub btsent_Click(sender As Object, e As EventArgs) Handles btsent.Click
    If Customerid <> 0 Then
      If MessageBox.Show("Do you want to Update this Account ?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
        Dim COUTER As Integer = Integer.Parse(cmd.getSpecificRecord($"Select 0+COALESCE([TotalVisits],0) FROM [Customer] where id='{Customerid}' "))

        If COUTER = 0 Then



          Dim datenow As DateTime = DateTimePicker1.Text
          cmd.Update("UPDATE Point_loyalsetting_Amount SET    [Diesel]='" & txta1.Text & "' ,[Premium]='" & txta2.Text & "' ,[Unleaded]='" & txta3.Text & "' ,[Regular]='" & txta4.Text & "'  where ID='" & Customerid & "' ")
          cmd.Update($"UPDATE Customer SET  TotalVisits=1, FirstName='{txtfname.Text}', LastName='{txtlastname.Text}', PhoneNumber='{txtphone.Text}', Address='{txttown.Text}', CustomDate5='{datenow}'  where  id='{Customerid }'")






          cmd.Update("UPDATE Point_Setting    SET [code]='" & txtcn.Text & "'  where ID='" & Customerid & "' ")

          cmd.Update("UPDATE Point_loyalsetting_Amount SET [code]='" & txtcn.Text & "'  where ID='" & Customerid & "' ")

          cmd.Update("UPDATE Point_loyalsetting_Quantity SET [code]='" & txtcn.Text & "'  where ID='" & Customerid & "' ")

          cmd.Update("UPDATE Point_Rebatesetting_Amount SET [code]='" & txtcn.Text & "' where ID='" & Customerid & "' ")

          cmd.Update("UPDATE Point_Rebatesetting_Quantity SET [code]='" & txtcn.Text & "' where ID='" & Customerid & "' ")
          MessageBox.Show("Card Has Been Updated")
          Tclear()

        Else
          MessageBox.Show("Account can't re-update")

        End If







      End If

    End If


  End Sub

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    Me.Close()
  End Sub

  Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

  End Sub
End Class
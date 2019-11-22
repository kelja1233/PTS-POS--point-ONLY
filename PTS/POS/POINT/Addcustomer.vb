Public Class Addcustomer

    Dim cmd As New commands
    Private Sub Addcustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error Resume Next
    SQLConnect.txtserver.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_server", "Value", Nothing).ToString
    SQLConnect.txtdb.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_database", "Value", Nothing).ToString
    SQLConnect.txtuser.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_user", "Value", Nothing).ToString
    SQLConnect.txtpass.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Password", "Value", Nothing).ToString
    lb1.Text = cmd.getSpecificRecord("Select ( case when Description = null then ' ' else Description  end) FROM item where ItemLookupCode=1").ToString
        lb2.Text = cmd.getSpecificRecord("Select ( case when Description = null then ' ' else Description  end) FROM item where ItemLookupCode=2").ToString
        lb3.Text = cmd.getSpecificRecord("Select ( case when Description = null then ' ' else Description  end) FROM item where ItemLookupCode=3").ToString
        lb4.Text = cmd.getSpecificRecord("Select ( case when Description = null then ' ' else Description  end) FROM item where ItemLookupCode=4").ToString
        Button2.PerformClick()




    End Sub

    Private Sub btsent_Click(sender As Object, e As EventArgs) Handles btsent.Click
        Dim s2 As String = txtcn.Text
        Dim count
        For Each c As Char In s2
            count += 1
        Next

        If count = 10 Then



            Dim storeid = cmd.getSpecificRecord("Select [StoreID] FROM [Configuration]")
            Dim id As Double = cmd.getSpecificRecord("Select   0+COALESCE(max([id]),0)+1 FROM [CustomerRecord]")
            Dim number As Double = cmd.getSpecificRecord("Select   0+COALESCE(max([PhoneNumber]),0) FROM [Store] where id='" & storeid & "'")
            Dim total As Double = id + number

            Dim act As String = txtact.Text


            Dim datenow As DateTime = DateTimePicker1.Text


            Dim counter As Double = cmd.getSpecificRecord("Select   count([code]) FROM [Point_Setting] where code='" & txtcn.Text & "'")


            If counter = 0 Then


                cmd.AddRecord("INSERT INTO [CustomerRecord] ([CPnum],[Firstname],[Lastname],[bday],[cardno],[town],[storeid],act) VALUES ('" & txtphone.Text & "','" & txtfname.Text & "','" & txtlastname.Text & "','" & datenow & "','" & txtcn.Text & "','" & txttown.Text & "','" & storeid & "','" & act & "')")

                cmd.AddRecord("INSERT INTO [Customer] (  AccountNumber, FirstName, LastName, PhoneNumber, Address, CreditLimit, AccountBalance,CustomDate5)values('" & act & "','" & txtfname.Text & "','" & txtlastname.Text & "','" & txtphone.Text & "','" & txttown.Text & "','0','0','" & datenow & "')")
                cmd.AddRecord("INSERT INTO [CustCard] ( [CardNumber],[MainAccountNumber],[FirstName],[LastName],[Address],[PhoneNumber],[BirthDate])values('" & txtcn.Text & "','" & act & "','" & txtfname.Text & "','" & txtlastname.Text & "','" & txttown.Text & "','" & txtphone.Text & "','" & datenow & "')")

                Dim idC As Double = cmd.getSpecificRecord("Select   0+COALESCE(max([id]),0) FROM [Customer]")


                cmd.AddRecord("INSERT INTO [Point_Setting] (Item1,code,id)values(0,'" & txtcn.Text & "','" & idC & "')")
                cmd.AddRecord("INSERT INTO [Point_loyalsetting_Amount] (id, [code],[Diesel],[Premium],[Unleaded],[Regular])values('" & idC & "','" & txtcn.Text & "','" & txta1.Text & "','" & txta2.Text & "','" & txta3.Text & "','" & txta4.Text & "')")
                cmd.AddRecord("INSERT INTO [Point_loyalsetting_Quantity]  (id, [code],[Diesel],[Premium],[Unleaded],[Regular])values('" & idC & "','" & txtcn.Text & "','" & txta1.Text & "','" & txta2.Text & "','" & txta3.Text & "','" & txta4.Text & "')")
                cmd.AddRecord("INSERT INTO [Point_Rebatesetting_Quantity] ( code,id)values('" & txtcn.Text & "','" & idC & "')")

                txtcn.Clear()
                txtfname.Clear()
                txtlastname.Clear()
                txtphone.Clear()
                txttown.Clear()
                txta1.Text = 1
                txta2.Text = 1
                txta3.Text = 1
                txta4.Text = 1
                Button2.PerformClick()
                MessageBox.Show("Customer Has been save")


      Else

                MessageBox.Show("Number is Taken")

            End If




        Else
            MessageBox.Show("Card Number is Invalid")

        End If












    End Sub




    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim counter As Double = 10000000 + cmd.getSpecificRecord("Select   0+COALESCE(max([id]),0)+1  FROM [Customer] ")

        txtact.Text = "PKD" & counter
        txtcn.Clear()
        txtfname.Clear()
        txtlastname.Clear()
        txtphone.Clear()
        txttown.Clear()
        txta1.Text = 1
        txta2.Text = 1
        txta3.Text = 1
        txta4.Text = 1
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim s2 As String = txtcn.Text
        Dim count
        For Each c As Char In s2
            count += 1
        Next

        If count = 10 Then



            Dim storeid = cmd.getSpecificRecord("Select [StoreID] FROM [Configuration]")
            Dim id As Double = cmd.getSpecificRecord("Select   0+COALESCE(max([id]),0)+1 FROM [CustomerRecord]")
            Dim number As Double = cmd.getSpecificRecord("Select   0+COALESCE(max([PhoneNumber]),0) FROM [Store] where id='" & storeid & "'")
            Dim total As Double = id + number

            Dim act As String = txtact.Text


            Dim datenow As DateTime = DateTimePicker1.Text


            Dim counter As Double = cmd.getSpecificRecord("Select   count([code]) FROM [Point_Setting] where code='" & txtcn.Text & "'")


            If counter = 0 Then


                cmd.AddRecord("INSERT INTO [CustomerRecord] ([CPnum],[Firstname],[Lastname],[bday],[cardno],[town],[storeid],act) VALUES ('" & txtcn.Text & "','" & txtcn.Text & "','" & txtcn.Text & "','" & datenow & "','" & txtcn.Text & "','" & txtcn.Text & "','" & storeid & "','" & act & "')")

                cmd.AddRecord("INSERT INTO [Customer] (  AccountNumber, FirstName, LastName, PhoneNumber, Address, CreditLimit, AccountBalance,CustomDate5)values('" & act & "','" & txtcn.Text & "','" & txtcn.Text & "','" & txtcn.Text & "','" & txtcn.Text & "','0','0','" & datenow & "')")
                cmd.AddRecord("INSERT INTO [CustCard] ( [CardNumber],[MainAccountNumber],[FirstName],[LastName],[Address],[PhoneNumber],[BirthDate])values('" & txtcn.Text & "','" & act & "','" & txtcn.Text & "','" & txtcn.Text & "','" & txtcn.Text & "','" & txtcn.Text & "','" & datenow & "')")

                Dim idC As Double = cmd.getSpecificRecord("Select   0+COALESCE(max([id]),0) FROM [Customer]")


                cmd.AddRecord("INSERT INTO [Point_Setting] (Item1,code,id)values(0,'" & txtcn.Text & "','" & idC & "')")
                cmd.AddRecord("INSERT INTO [Point_loyalsetting_Amount] (id, [code],[Diesel],[Premium],[Unleaded],[Regular])values('" & idC & "','" & txtcn.Text & "','" & txta1.Text & "','" & txta2.Text & "','" & txta3.Text & "','" & txta4.Text & "')")
                cmd.AddRecord("INSERT INTO [Point_loyalsetting_Quantity]  (id, [code],[Diesel],[Premium],[Unleaded],[Regular])values('" & idC & "','" & txtcn.Text & "','" & txta1.Text & "','" & txta2.Text & "','" & txta3.Text & "','" & txta4.Text & "')")

                cmd.AddRecord("INSERT INTO [Point_Rebatesetting_Amount] (code, id)values('" & txtcn.Text & "','" & idC & "')")
                cmd.AddRecord("INSERT INTO [Point_Rebatesetting_Quantity] ( code,id)values('" & txtcn.Text & "','" & idC & "')")

                txtcn.Clear()
                txtfname.Clear()
                txtlastname.Clear()
                txtphone.Clear()
                txttown.Clear()
                txta1.Text = 1
                txta2.Text = 1
                txta3.Text = 1
                txta4.Text = 1
                Button2.PerformClick()
                MessageBox.Show("Customer Has been save")


      Else

                MessageBox.Show("Number is Taken")

            End If




        Else
            MessageBox.Show("Card Number is Invalid")

        End If


    End Sub

  Private Sub txta4_TextChanged(sender As Object, e As EventArgs) Handles txta4.TextChanged

  End Sub

  Private Sub lb4_Click(sender As Object, e As EventArgs) Handles lb4.Click

  End Sub

  Private Sub txta3_TextChanged(sender As Object, e As EventArgs) Handles txta3.TextChanged

  End Sub

  Private Sub lb3_Click(sender As Object, e As EventArgs) Handles lb3.Click

  End Sub

  Private Sub txta2_TextChanged(sender As Object, e As EventArgs) Handles txta2.TextChanged

  End Sub

  Private Sub lb2_Click(sender As Object, e As EventArgs) Handles lb2.Click

  End Sub

  Private Sub txta1_TextChanged(sender As Object, e As EventArgs) Handles txta1.TextChanged

  End Sub

  Private Sub lb1_Click(sender As Object, e As EventArgs) Handles lb1.Click

  End Sub

  Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

  End Sub

  Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

  End Sub

  Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

  End Sub

  Private Sub txttown_TextChanged(sender As Object, e As EventArgs) Handles txttown.TextChanged

  End Sub

  Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

  End Sub

  Private Sub txtcn_TextChanged(sender As Object, e As EventArgs) Handles txtcn.TextChanged

  End Sub

  Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

  End Sub

  Private Sub txtlastname_TextChanged(sender As Object, e As EventArgs) Handles txtlastname.TextChanged

  End Sub

  Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

  End Sub

  Private Sub txtfname_TextChanged(sender As Object, e As EventArgs) Handles txtfname.TextChanged

  End Sub

  Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

  End Sub

  Private Sub txtphone_TextChanged(sender As Object, e As EventArgs) Handles txtphone.TextChanged

  End Sub
End Class

Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class SQLConnect
  Public Shared server, database, User, Password, text As String
  Public Shared adap As New SqlDataAdapter
  Public Shared SQLCon As New SqlConnection
  Public Shared SQLCmd As SqlCommand
  Dim cmd As New commands
  Public Shared Sub ConnectToDb()
    Try

      server = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_server", "Value", Nothing).ToString
      database = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_database", "Value", Nothing).ToString
      User = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_user", "Value", Nothing).ToString
      Password = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Password", "Value", Nothing).ToString



      If SQLCon.State = ConnectionState.Open Then SQLCon.Close()
      SQLCon.ConnectionString = "Data Source='" & server & "';Initial Catalog='" & database & "';Persist Security Info=True;User ID='" & User & "';Password='" & Password & "'"
      SQLCon.Open()
      adap = New SqlDataAdapter("Select ID,Fname,Lname,Status from Test", SQLCon)
      text = "Connected to database."
    Catch ex As Exception
      text = "Unable to connect!!!"
    End Try
  End Sub



  Private Sub txtok_Click(sender As Object, e As EventArgs) Handles txtok.Click
    'MAIN.Timer1.Start()

    Application.Restart()


    Me.Hide()
  End Sub

  Private Sub txttest_Click(sender As Object, e As EventArgs) Handles txttest.Click


    My.Computer.Registry.CurrentUser.DeleteSubKey("Kel_server")
    My.Computer.Registry.CurrentUser.CreateSubKey("Kel_server")
    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Kel_server", "Value", Me.txtserver.Text)

    My.Computer.Registry.CurrentUser.DeleteSubKey("Kel_databaser")
    My.Computer.Registry.CurrentUser.CreateSubKey("Kel_databaser")
    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Kel_database", "Value", Me.txtdb.Text)

    My.Computer.Registry.CurrentUser.DeleteSubKey("Kel_user")
    My.Computer.Registry.CurrentUser.CreateSubKey("Kel_user")
    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Kel_user", "Value", Me.txtuser.Text)

    My.Computer.Registry.CurrentUser.DeleteSubKey("Kel_Password")
    My.Computer.Registry.CurrentUser.CreateSubKey("Kel_Password")
    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Kel_Password", "Value", Me.txtpass.Text)


    My.Computer.Registry.CurrentUser.DeleteSubKey("Kel_Printerset")
    My.Computer.Registry.CurrentUser.CreateSubKey("Kel_Printerset")
    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Kel_Printerset", "Value", Me.txtprint.Text)

    My.Computer.Registry.CurrentUser.DeleteSubKey("Kel_com123")
    My.Computer.Registry.CurrentUser.CreateSubKey("Kel_com123")
    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Kel_com123", "Value", Me.txtcom.Text)

    My.Computer.Registry.CurrentUser.DeleteSubKey("Kel_pathset")
    My.Computer.Registry.CurrentUser.CreateSubKey("Kel_pathset")
    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Kel_pathset", "Value", Me.txtpath.Text)


    My.Computer.Registry.CurrentUser.DeleteSubKey("Kel_mode1")
    My.Computer.Registry.CurrentUser.CreateSubKey("Kel_mode1")
    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Kel_mode1", "Value", Me.ComboBox1.Text)

    If CheckBox1.Checked = True Then

      My.Computer.Registry.CurrentUser.DeleteSubKey("checkss")
      My.Computer.Registry.CurrentUser.CreateSubKey("checkss")
      My.Computer.Registry.SetValue("HKEY_CURRENT_USER\checkss", "Value", 1)


    Else
      My.Computer.Registry.CurrentUser.DeleteSubKey("checkss")
      My.Computer.Registry.CurrentUser.CreateSubKey("checkss")
      My.Computer.Registry.SetValue("HKEY_CURRENT_USER\checkss", "Value", 0)


    End If


    txtserver.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_server", "Value", Nothing).ToString
    txtdb.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_database", "Value", Nothing).ToString
    txtuser.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_user", "Value", Nothing).ToString
    txtpass.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Password", "Value", Nothing).ToString
    txtprint.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Printerset", "Value", Nothing).ToString
    txtcom.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_com123", "Value", Nothing).ToString
    Me.txtpath.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_pathset", "Value", Nothing).ToString
    ComboBox1.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\checkss", "Value", Nothing).ToString


    server = Me.txtserver.Text
    database = Me.txtdb.Text
    User = Me.txtuser.Text
    Password = Me.txtpass.Text








    ConnectToDb()








    MessageBox.Show(text)





  End Sub
  Public Shared Sub DisconnectToDb()
    SQLCon.Close()
  End Sub

  Private Sub Connect_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    On Error Resume Next
    'If Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Kel_server") Is Nothing Then
    '    My.Computer.Registry.CurrentUser.CreateSubKey("Kel_server")
    '    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Kel_server", "Value", "DESKTOP-NEA1G8P")
    'End If
    'If Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Kel_database") Is Nothing Then
    '    My.Computer.Registry.CurrentUser.CreateSubKey("Kel_databaser")
    '    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Kel_database", "Value", "SYQUIO")
    'End If
    'If Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Kel_user") Is Nothing Then
    '    My.Computer.Registry.CurrentUser.CreateSubKey("Kel_user")
    '    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Kel_user", "Value", "sa")
    'End If
    'If Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Kel_Password") Is Nothing Then
    '    My.Computer.Registry.CurrentUser.CreateSubKey("Kel_Password")
    '    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Kel_Password", "Value", "Radar")
    'End If
    'If Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Kel_Printerset") Is Nothing Then
    '    My.Computer.Registry.CurrentUser.CreateSubKey("Kel_Printerset")
    '    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Kel_Printerset", "Value", "Microsoft XPS Document Writer")
    'End If
    'If Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Kel_com123") Is Nothing Then
    '    My.Computer.Registry.CurrentUser.CreateSubKey("Kel_com123")
    '    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Kel_com123", "Value", "com12")
    'End If
    'If Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Kel_pathset") Is Nothing Then
    '    My.Computer.Registry.CurrentUser.CreateSubKey("Kel_pathset")
    '    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Kel_pathset", "Value", "D:\")
    'End If
    'If Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Kel_mode1") Is Nothing Then
    '    My.Computer.Registry.CurrentUser.CreateSubKey("Kel_mode1")
    '    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Kel_mode1", "Value", "1")
    'End If
    'If Microsoft.Win32.Registry.LocalMachine.OpenSubKey("checkss") Is Nothing Then
    '    My.Computer.Registry.CurrentUser.CreateSubKey("checkss")
    '    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\checkss", "Value", "NO")
    'End If
    txtserver.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_server", "Value", Nothing).ToString
    txtdb.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_database", "Value", Nothing).ToString
    txtuser.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_user", "Value", Nothing).ToString
    txtpass.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Password", "Value", Nothing).ToString
    txtprint.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Printerset", "Value", Nothing).ToString
    txtcom.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_com123", "Value", Nothing).ToString
    Me.txtpath.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_pathset", "Value", Nothing).ToString
    ComboBox1.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_mode1", "Value", Nothing).ToString
    'MAIN.Timer1.Stop()

    Dim a As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\checkss", "Value", Nothing).ToString
    If a = "1" Then
      CheckBox1.Checked = True

    Else
      CheckBox1.Checked = False
    End If

    server = Me.txtserver.Text
    database = Me.txtdb.Text
    User = Me.txtuser.Text
    Password = Me.txtpass.Text



  End Sub




  Private Sub Login_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

    '    If e.KeyCode = Keys.Enter Then





    '        My.Settings.server = Me.txtserver.Text
    '        My.Settings.database = Me.txtdb.Text
    '        My.Settings.user = Me.txtuser.Text
    '        My.Settings.Password = Me.txtpass.Text
    '        My.Settings.Save()









    '        ConnectToDb()








    '        MessageBox.Show(text)







    '    End If
  End Sub





End Class

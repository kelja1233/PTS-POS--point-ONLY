Imports System.IO.Ports
Imports System.Windows.Forms
Imports System.Management
Imports System.Threading
Public Class SMSTextClass
  Dim SerialPort1 As New System.IO.Ports.SerialPort()
  Dim cmd As commands

  Public Sub New()


    cmd = New commands

    SQLConnect.txtserver.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_server", "Value", Nothing).ToString
    SQLConnect.txtdb.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_database", "Value", Nothing).ToString
    SQLConnect.txtuser.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_user", "Value", Nothing).ToString
    SQLConnect.txtpass.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_Password", "Value", Nothing).ToString


  End Sub
  Public Sub connection()

    SerialPort1.PortName = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Kel_com123", "Value", Nothing).ToString
    SerialPort1.BaudRate = 9600
    SerialPort1.Parity = Parity.None
    SerialPort1.StopBits = StopBits.One
    SerialPort1.DataBits = 8
    SerialPort1.Handshake = Handshake.RequestToSend
    SerialPort1.DtrEnable = True
    SerialPort1.RtsEnable = True
    SerialPort1.NewLine = vbCrLf


  End Sub
  Public Sub message(customerid As Integer, msg As String)
    Try



      Dim contact As String = cmd.getSpecificRecord("Select PhoneNumber FROM Customer where  id='" & customerid & "'").ToString


      SerialPort1.Open()
      If SerialPort1.IsOpen() Then
        SerialPort1.Write("AT" & vbCrLf)
        SerialPort1.Write("AT+CMGF=1" & vbCrLf)
        SerialPort1.Write("AT+CMGS=" & Chr(34) & contact & Chr(34) & vbCrLf)
        SerialPort1.Write(msg & Chr(26))
        SerialPort1.Close()
      Else
        SerialPort1.Close()
      End If
    Catch ex As Exception
      SerialPort1.Close()
    End Try
  End Sub
End Class

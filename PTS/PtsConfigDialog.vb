Imports System.ComponentModel
Imports System.Text
Imports TiT

Namespace TiT.PTS
	Partial Public Class PtsConfigDialog
		Inherits Form
		Private _pts As PTS = Nothing
		Private _parameterAddress As Short
		Private _parameterNumber As Integer
		Private _parameterValue() As Byte

		Public Sub New()
			InitializeComponent()
		End Sub

		Public Property PTS() As PTS
			Get
				Return _pts
			End Get
			Set(ByVal value As PTS)
				_pts = value
			End Set
		End Property

		Private Sub PtsConfiguration_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
			InitConfigTables()
		End Sub

		Private Sub btnClearResponse_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClearResponse.Click
			tbxResponse.Text = ""
		End Sub

		''' <summary>
		''' Method for formation of pump and ATG configuration tables.
		''' </summary>
		Private Sub InitConfigTables()
			'dgvPumpChConfig
			dgvPumpChConfig.Rows.Add(PtsConfiguration.FuelPointChannelQuantity)
			For row As Integer = 0 To PtsConfiguration.FuelPointChannelQuantity - 1
				For column As Integer = 0 To 2
					If column = 0 Then
						dgvPumpChConfig.Rows(row).Cells(column).Value = row + 1
					Else
						dgvPumpChConfig.Rows(row).Cells(column).Value = 0
					End If
				Next column
			Next row

			dgvPumpChConfig.Width = 3 * dgvPumpChConfig.Columns(0).Width
			dgvPumpChConfig.Height = (PtsConfiguration.FuelPointChannelQuantity + 1) * dgvPumpChConfig.Rows(0).Height
			dgvPumpChConfig.ColumnHeadersDefaultCellStyle.Font = New Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold)

			'dgvPumpConfig
			dgvPumpConfig.Rows.Add(PtsConfiguration.FuelPointQuantity)
			For row As Integer = 0 To PtsConfiguration.FuelPointQuantity - 1
				For column As Integer = 0 To 2
					If column = 0 Then
						dgvPumpConfig.Rows(row).Cells(column).Value = row + 1
					Else
						dgvPumpConfig.Rows(row).Cells(column).Value = 0
					End If
				Next column
			Next row

			dgvPumpConfig.Width = 3 * dgvPumpConfig.Columns(0).Width
			dgvPumpConfig.Height = (PtsConfiguration.FuelPointQuantity + 1) * dgvPumpConfig.Rows(0).Height
			dgvPumpConfig.ColumnHeadersDefaultCellStyle.Font = New Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold)

			'dgvAtgChConfig
			dgvAtgChConfig.Rows.Add(PtsConfiguration.AtgChannelQuantity)
			For row As Integer = 0 To PtsConfiguration.AtgChannelQuantity - 1
				For column As Integer = 0 To 2
					If column = 0 Then
						dgvAtgChConfig.Rows(row).Cells(column).Value = row + 1
					Else
						dgvAtgChConfig.Rows(row).Cells(column).Value = 0
					End If
				Next column
			Next row

			dgvAtgChConfig.Width = 3 * dgvAtgChConfig.Columns(0).Width
			dgvAtgChConfig.Height = (PtsConfiguration.AtgChannelQuantity + 1) * dgvAtgChConfig.Rows(0).Height
			dgvAtgChConfig.ColumnHeadersDefaultCellStyle.Font = New Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold)

			'dgvAtgConfig
			dgvAtgConfig.Rows.Add(PtsConfiguration.AtgQuantity)
			For row As Integer = 0 To PtsConfiguration.AtgQuantity - 1
				For column As Integer = 0 To 2
					If column = 0 Then
						dgvAtgConfig.Rows(row).Cells(column).Value = row + 1
					Else
						dgvAtgConfig.Rows(row).Cells(column).Value = 0
					End If
				Next column
			Next row

			dgvAtgConfig.Width = 3 * dgvAtgConfig.Columns(0).Width
			dgvAtgConfig.Height = (PtsConfiguration.AtgQuantity + 1) * dgvAtgConfig.Rows(0).Height
			dgvAtgConfig.ColumnHeadersDefaultCellStyle.Font = New Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold)
		End Sub

		Private Sub btnSetPumpConfig_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSetPumpConfig.Click
			Try
				'Set FuelPoint channel settings
				For i As Integer = 0 To PtsConfiguration.FuelPointChannelQuantity - 1
					_pts.Configuration.FuelPointChannels(i).ID = Convert.ToInt32(dgvPumpChConfig.Rows(i).Cells(0).Value)
					_pts.Configuration.FuelPointChannels(i).Protocol = CType(Convert.ToInt32(dgvPumpChConfig.Rows(i).Cells(1).Value), FuelPointChannelProtocol)
					_pts.Configuration.FuelPointChannels(i).BaudRate = CType(Convert.ToInt32(dgvPumpChConfig.Rows(i).Cells(2).Value), ChannelBaudRate)
				Next i

				'Set FuelPoint settings
				For i As Integer = 0 To PtsConfiguration.FuelPointQuantity - 1
					_pts.Configuration.FuelPoints(i).ID = Convert.ToInt32(dgvPumpConfig.Rows(i).Cells(0).Value)
					_pts.Configuration.FuelPoints(i).ChannelID = Convert.ToInt32(dgvPumpConfig.Rows(i).Cells(1).Value)
					_pts.Configuration.FuelPoints(i).PhysicalAddress = Convert.ToInt32(dgvPumpConfig.Rows(i).Cells(2).Value)
				Next i

				_pts.RequestFuelPointConfigurationSet()

				DisplayPumpConfig()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End Sub

		Private Sub btnGetPumpConfig_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGetPumpConfig.Click
			Try
				_pts.GetFuelPointConfiguration()

				DisplayPumpConfig()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End Sub

		Private Sub DisplayPumpConfig()
			Try
				tbxResponse.Text = ""

				'Read FuelPoint channel settings
				For i As Integer = 0 To PtsConfiguration.FuelPointChannelQuantity - 1
					tbxResponse.Text &= " Pump channel ID = " & _pts.Configuration.FuelPointChannels(i).ID.ToString()
					tbxResponse.Text &= ", pump protocol ID = " & _pts.Configuration.FuelPointChannels(i).Protocol.ToString()
					dgvPumpChConfig.Rows(i).Cells(1).Value = (CInt(Fix(_pts.Configuration.FuelPointChannels(i).Protocol))).ToString()
					tbxResponse.Text &= ", baud rate ID = " & _pts.Configuration.FuelPointChannels(i).BaudRate.ToString() & Environment.NewLine
					dgvPumpChConfig.Rows(i).Cells(2).Value = (CInt(Fix(_pts.Configuration.FuelPointChannels(i).BaudRate))).ToString()
				Next i

				'Read FuelPoint settings
				For i As Integer = 0 To PtsConfiguration.FuelPointQuantity - 1
					tbxResponse.Text &= " Pump log. addr. = " & _pts.Configuration.FuelPoints(i).ID.ToString()
					tbxResponse.Text &= ", pump channel ID = " & _pts.Configuration.FuelPoints(i).ChannelID.ToString()
					dgvPumpConfig.Rows(i).Cells(1).Value = _pts.Configuration.FuelPoints(i).ChannelID.ToString()
					tbxResponse.Text &= ", pump phys. addr. = " & _pts.Configuration.FuelPoints(i).PhysicalAddress.ToString() & Environment.NewLine
					dgvPumpConfig.Rows(i).Cells(2).Value = _pts.Configuration.FuelPoints(i).PhysicalAddress.ToString()
				Next i
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End Sub

		Private Sub btnGetAtgConfig_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGetAtgConfig.Click
			Try
				_pts.RequestAtgConfigurationGet()

				DisplayAtgConfig()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End Sub

		Private Sub btnSetAtgConfig_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSetAtgConfig.Click
			Try
				'Set Atg channel settings
				For i As Integer = 0 To PtsConfiguration.AtgChannelQuantity - 1
					_pts.Configuration.AtgChannels(i).ID = Convert.ToInt32(dgvAtgChConfig.Rows(i).Cells(0).Value)
					_pts.Configuration.AtgChannels(i).Protocol = CType(Convert.ToInt32(dgvAtgChConfig.Rows(i).Cells(1).Value), AtgChannelProtocol)
					_pts.Configuration.AtgChannels(i).BaudRate = CType(Convert.ToInt32(dgvAtgChConfig.Rows(i).Cells(2).Value), ChannelBaudRate)
				Next i

				'Set Atg settings
				For i As Integer = 0 To PtsConfiguration.AtgQuantity - 1
					_pts.Configuration.ATGs(i).ID = Convert.ToInt32(dgvAtgConfig.Rows(i).Cells(0).Value)
					_pts.Configuration.ATGs(i).ChannelID = Convert.ToInt32(dgvAtgConfig.Rows(i).Cells(1).Value)
					_pts.Configuration.ATGs(i).PhysicalAddress = Convert.ToInt32(dgvAtgConfig.Rows(i).Cells(2).Value)
				Next i

				_pts.RequestAtgConfigurationSet()

				DisplayAtgConfig()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End Sub

		Private Sub DisplayAtgConfig()
			Try
				tbxResponse.Text = ""

				'Read ATG channel settings
				For i As Integer = 0 To PtsConfiguration.AtgChannelQuantity - 1
					tbxResponse.Text &= " ATG channel ID = " & _pts.Configuration.AtgChannels(i).ID.ToString()
					tbxResponse.Text &= ", ATG protocol ID = " & _pts.Configuration.AtgChannels(i).Protocol.ToString()
					dgvAtgChConfig.Rows(i).Cells(1).Value = (CInt(Fix(_pts.Configuration.AtgChannels(i).Protocol))).ToString()
					tbxResponse.Text &= ", ATG rate ID = " & _pts.Configuration.AtgChannels(i).BaudRate.ToString() & Environment.NewLine
					dgvAtgChConfig.Rows(i).Cells(2).Value = (CInt(Fix(_pts.Configuration.AtgChannels(i).BaudRate))).ToString()
				Next i

				'Read ATG settings
				For i As Integer = 0 To PtsConfiguration.AtgQuantity - 1
					tbxResponse.Text &= " ATG log. addr. = " & _pts.Configuration.ATGs(i).ID.ToString()
					tbxResponse.Text &= ", ATG channel ID = " & _pts.Configuration.ATGs(i).ChannelID.ToString()
					dgvAtgConfig.Rows(i).Cells(1).Value = _pts.Configuration.ATGs(i).ChannelID.ToString()
					tbxResponse.Text &= ", ATG phys. addr. = " & _pts.Configuration.ATGs(i).PhysicalAddress.ToString() & Environment.NewLine
					dgvAtgConfig.Rows(i).Cells(2).Value = _pts.Configuration.ATGs(i).PhysicalAddress.ToString()
				Next i
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End Sub

		Private Sub btnGetParameter_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGetParameter.Click
			Try
				_parameterAddress = Convert.ToInt16(udParamAddress.Value)
				_parameterNumber = Convert.ToInt32(udParamNumber.Value)
				_pts.RequestParameterGet(_parameterAddress, _parameterNumber)

				DisplayParameter()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End Sub

		Private Sub btnSetParameter_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSetParameter.Click
			Try
				_parameterAddress = Convert.ToInt16(udParamAddress.Value)
				_parameterNumber = Convert.ToInt32(udParamNumber.Value)
				_parameterValue = AsciiConversion.StringToBytesArray(txbParamValue.Text)
				_pts.RequestParameterSet(_parameterAddress, _parameterNumber, _parameterValue)

				DisplayParameter()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End Sub

		Private Sub DisplayParameter()
			Try
				tbxResponse.Text = ""

				tbxResponse.Text &= " Parameter address: " & _pts.Parameter.ParameterAddress.ToString() & Environment.NewLine
				tbxResponse.Text &= " Parameter number: " & _pts.Parameter.ParameterNumber.ToString() & Environment.NewLine
				tbxResponse.Text &= " Parameter value: " & AsciiConversion.BytesArrayToString(_pts.Parameter.ParameterValue)
				udParamAddress.Value = Convert.ToDecimal(_pts.Parameter.ParameterAddress)
				udParamNumber.Value = Convert.ToDecimal(_pts.Parameter.ParameterNumber)
				txbParamValue.Text = AsciiConversion.BytesArrayToString(_pts.Parameter.ParameterValue)
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End Sub

		Private Sub btnGetVersion_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGetVersion.Click
			Try
				_pts.RequestVersion()

				tbxResponse.Text = ""
				tbxResponse.Text &= " Release date: " & _pts.ReleaseInfo.ReleaseDate.ToString() & Environment.NewLine
				tbxResponse.Text &= " Release number: " & _pts.ReleaseInfo.ReleaseNum.ToString() & Environment.NewLine
				tbxResponse.Text &= " Release version: " & _pts.ReleaseInfo.ReleaseVersion & Environment.NewLine
				tbxResponse.Text &= " Supported pump protocols: " & Environment.NewLine

				For i As Integer = 0 To _pts.ReleaseInfo.SupportedFuelPointProtocols.Length - 1
					tbxResponse.Text &= "   " & (i + 1).ToString() & ". " & _pts.ReleaseInfo.SupportedFuelPointProtocols(i).ToString() & Environment.NewLine
				Next i

				tbxResponse.Text &= " Supported ATG protocols: " & Environment.NewLine

				For i As Integer = 0 To _pts.ReleaseInfo.SupportedAtgProtocols.Length - 1
					tbxResponse.Text &= "   " & (i + 1).ToString() & ". " & _pts.ReleaseInfo.SupportedAtgProtocols(i).ToString() & Environment.NewLine
				Next i

			Catch ex As Exception
				MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End Sub
	End Class
End Namespace

Namespace TiT.PTS
	Partial Public Class FuelPointControl
		''' <summary> 
		''' Требуется переменная конструктора.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary> 
		''' Освободить все используемые ресурсы.
		''' </summary>
		''' <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
			If _updateThread IsNot Nothing AndAlso _updateThread.ThreadState = System.Threading.ThreadState.Running Then
				_updateThread.Abort()
			End If
		End Sub

		#Region "Код, автоматически созданный конструктором компонентов"

		''' <summary> 
		''' Обязательный метод для поддержки конструктора - не изменяйте 
		''' содержимое данного метода при помощи редактора кода.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Me.label2 = New Label()
			Me.label3 = New Label()
			Me.statusLabel = New Label()
			Me.pumpAddressLabel = New Label()
			Me.paymentUpDown = New NumericUpDown()
			Me.volumeUpDown = New NumericUpDown()
			Me.label4 = New Label()
			Me.label7 = New Label()
			Me.panelPumpID = New Panel()
			Me.toolTip1 = New ToolTip(Me.components)
			Me.panelStatusLabel = New Panel()
			Me.pbTotalsRequest = New PictureBox()
			Me.label1 = New Label()
			Me.comboBoxDispenseMode = New ComboBox()
			Me.startButton = New Button()
			Me.stopButton = New Button()
			Me.settingsButton = New Button()
			Me.totalsButton = New Button()
			Me.nozzleUpDown = New NumericUpDown()
			Me.lblExecutedCommand = New Label()
			Me.timerAutomaticAuthorize = New Timer(Me.components)
			Me.lblVolTotal = New Label()
			Me.lblAmoTotal = New Label()
			Me.txbVolTotalValue = New TextBox()
			Me.txbAmoTotalValue = New TextBox()
			Me.priceLabel = New TextBox()
			CType(Me.paymentUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.volumeUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.panelPumpID.SuspendLayout()
			Me.panelStatusLabel.SuspendLayout()
			CType(Me.pbTotalsRequest, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.nozzleUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Font = New Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.label2.Location = New Point(5, 69)
			Me.label2.Margin = New Padding(5, 0, 0, 0)
			Me.label2.Name = "label2"
			Me.label2.Size = New Size(62, 17)
			Me.label2.TabIndex = 1
			Me.label2.Text = "Amount"
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Font = New Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.label3.Location = New Point(5, 92)
			Me.label3.Margin = New Padding(5, 0, 0, 0)
			Me.label3.Name = "label3"
			Me.label3.Size = New Size(61, 17)
			Me.label3.TabIndex = 2
			Me.label3.Text = "Volume"
			' 
			' statusLabel
			' 
			Me.statusLabel.Dock = DockStyle.Fill
			Me.statusLabel.Font = New Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			Me.statusLabel.Location = New Point(0, 0)
			Me.statusLabel.Name = "statusLabel"
			Me.statusLabel.Size = New Size(163, 30)
			Me.statusLabel.TabIndex = 5
			Me.statusLabel.Text = "Offline"
			Me.statusLabel.TextAlign = ContentAlignment.MiddleCenter
			' 
			' pumpAddressLabel
			' 
			Me.pumpAddressLabel.BackColor = Color.Transparent
			Me.pumpAddressLabel.Dock = DockStyle.Fill
			Me.pumpAddressLabel.FlatStyle = FlatStyle.Popup
			Me.pumpAddressLabel.Font = New Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.pumpAddressLabel.ForeColor = SystemColors.ActiveCaptionText
			Me.pumpAddressLabel.Location = New Point(0, 0)
			Me.pumpAddressLabel.Name = "pumpAddressLabel"
			Me.pumpAddressLabel.Size = New Size(40, 30)
			Me.pumpAddressLabel.TabIndex = 10
			Me.pumpAddressLabel.Text = "-"
			Me.pumpAddressLabel.TextAlign = ContentAlignment.MiddleCenter
			Me.toolTip1.SetToolTip(Me.pumpAddressLabel, "FuelPointID")
			' 
			' paymentUpDown
			' 
			Me.paymentUpDown.BackColor = Color.White
			Me.paymentUpDown.BorderStyle = BorderStyle.FixedSingle
			Me.paymentUpDown.DecimalPlaces = 2
			Me.paymentUpDown.Enabled = False
			Me.paymentUpDown.Font = New Font("Arial", 8F, FontStyle.Bold, GraphicsUnit.Point, (CByte(0)))
			Me.paymentUpDown.Increment = New Decimal(New Integer() { 1, 0, 0, 131072})
			Me.paymentUpDown.Location = New Point(109, 69)
			Me.paymentUpDown.Margin = New Padding(0)
			Me.paymentUpDown.Maximum = New Decimal(New Integer() { 999999999, 0, 0, 131072})
			Me.paymentUpDown.Name = "paymentUpDown"
			Me.paymentUpDown.Size = New Size(72, 20)
			Me.paymentUpDown.TabIndex = 14
			Me.paymentUpDown.TextAlign = HorizontalAlignment.Right
'			Me.paymentUpDown.ValueChanged += New System.EventHandler(Me.paymentUpDown_ValueChanged)
			' 
			' volumeUpDown
			' 
			Me.volumeUpDown.BackColor = Color.White
			Me.volumeUpDown.BorderStyle = BorderStyle.FixedSingle
			Me.volumeUpDown.DecimalPlaces = 2
			Me.volumeUpDown.Enabled = False
			Me.volumeUpDown.Font = New Font("Arial", 8F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.volumeUpDown.Increment = New Decimal(New Integer() { 1, 0, 0, 131072})
			Me.volumeUpDown.Location = New Point(109, 92)
			Me.volumeUpDown.Margin = New Padding(0)
			Me.volumeUpDown.Maximum = New Decimal(New Integer() { 999999999, 0, 0, 131072})
			Me.volumeUpDown.Name = "volumeUpDown"
			Me.volumeUpDown.Size = New Size(72, 20)
			Me.volumeUpDown.TabIndex = 15
			Me.volumeUpDown.TextAlign = HorizontalAlignment.Right
'			Me.volumeUpDown.ValueChanged += New System.EventHandler(Me.volumeUpDown_ValueChanged)
			' 
			' label4
			' 
			Me.label4.AutoSize = True
			Me.label4.Font = New Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.label4.Location = New Point(5, 136)
			Me.label4.Margin = New Padding(5, 0, 3, 0)
			Me.label4.Name = "label4"
			Me.label4.Size = New Size(57, 17)
			Me.label4.TabIndex = 16
			Me.label4.Text = "Nozzle"
			' 
			' label7
			' 
			Me.label7.AutoSize = True
			Me.label7.Font = New Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.label7.Location = New Point(5, 115)
			Me.label7.Margin = New Padding(5, 0, 3, 0)
			Me.label7.Name = "label7"
			Me.label7.Size = New Size(45, 17)
			Me.label7.TabIndex = 18
			Me.label7.Text = "Price"
			' 
			' panelPumpID
			' 
			Me.panelPumpID.BackColor = SystemColors.GradientActiveCaption
			Me.panelPumpID.Controls.Add(Me.pumpAddressLabel)
			Me.panelPumpID.Location = New Point(-1, -1)
			Me.panelPumpID.Name = "panelPumpID"
			Me.panelPumpID.Size = New Size(40, 30)
			Me.panelPumpID.TabIndex = 20
			' 
			' panelStatusLabel
			' 
			Me.panelStatusLabel.BackColor = Color.LightGray
			Me.panelStatusLabel.Controls.Add(Me.pbTotalsRequest)
			Me.panelStatusLabel.Controls.Add(Me.statusLabel)
			Me.panelStatusLabel.Location = New Point(34, -1)
			Me.panelStatusLabel.Name = "panelStatusLabel"
			Me.panelStatusLabel.Size = New Size(163, 30)
			Me.panelStatusLabel.TabIndex = 21
			' 
			' pbTotalsRequest
			' 
			Me.pbTotalsRequest.Image = My.Resources.ajax_loader
			Me.pbTotalsRequest.InitialImage = My.Resources.totalsRequest
			Me.pbTotalsRequest.Location = New Point(0, 1)
			Me.pbTotalsRequest.Name = "pbTotalsRequest"
			Me.pbTotalsRequest.Size = New Size(20, 20)
			Me.pbTotalsRequest.TabIndex = 7
			Me.pbTotalsRequest.TabStop = False
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Font = New Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.label1.Location = New Point(5, 40)
			Me.label1.Margin = New Padding(5, 0, 0, 0)
			Me.label1.Name = "label1"
			Me.label1.Size = New Size(47, 17)
			Me.label1.TabIndex = 22
			Me.label1.Text = "Mode"
			' 
			' comboBoxDispenseMode
			' 
			Me.comboBoxDispenseMode.DropDownStyle = ComboBoxStyle.DropDownList
			Me.comboBoxDispenseMode.Font = New Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			Me.comboBoxDispenseMode.Location = New Point(65, 40)
			Me.comboBoxDispenseMode.MaxDropDownItems = 2
			Me.comboBoxDispenseMode.Name = "comboBoxDispenseMode"
			Me.comboBoxDispenseMode.Size = New Size(116, 21)
			Me.comboBoxDispenseMode.TabIndex = 23
'			Me.comboBoxDispenseMode.SelectedValueChanged += New System.EventHandler(Me.comboBoxDispenseMode_SelectedValueChanged)
			' 
			' startButton
			' 
			Me.startButton.Enabled = False
			Me.startButton.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.startButton.Location = New Point(5, 201)
			Me.startButton.Margin = New Padding(0)
			Me.startButton.Name = "startButton"
			Me.startButton.Size = New Size(90, 28)
			Me.startButton.TabIndex = 24
			Me.startButton.Text = "Start"
			Me.startButton.UseVisualStyleBackColor = True
'			Me.startButton.Click += New System.EventHandler(Me.startButton_Click)
			' 
			' stopButton
			' 
			Me.stopButton.Enabled = False
			Me.stopButton.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.stopButton.Location = New Point(100, 201)
			Me.stopButton.Margin = New Padding(0)
			Me.stopButton.Name = "stopButton"
			Me.stopButton.Size = New Size(90, 28)
			Me.stopButton.TabIndex = 25
			Me.stopButton.Text = "Stop"
			Me.stopButton.UseVisualStyleBackColor = True
'			Me.stopButton.Click += New System.EventHandler(Me.stopButton_Click)
			' 
			' settingsButton
			' 
			Me.settingsButton.Enabled = False
			Me.settingsButton.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.settingsButton.Location = New Point(99, 232)
			Me.settingsButton.Name = "settingsButton"
			Me.settingsButton.Size = New Size(91, 23)
			Me.settingsButton.TabIndex = 26
			Me.settingsButton.Text = "Settings"
			Me.settingsButton.UseVisualStyleBackColor = True
'			Me.settingsButton.Click += New System.EventHandler(Me.settingsButton_Click)
			' 
			' totalsButton
			' 
			Me.totalsButton.Enabled = False
			Me.totalsButton.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.totalsButton.Location = New Point(4, 232)
			Me.totalsButton.Name = "totalsButton"
			Me.totalsButton.Size = New Size(91, 23)
			Me.totalsButton.TabIndex = 27
			Me.totalsButton.Text = "Totals"
			Me.totalsButton.UseVisualStyleBackColor = True
'			Me.totalsButton.Click += New System.EventHandler(Me.totalsButton_Click)
			' 
			' nozzleUpDown
			' 
			Me.nozzleUpDown.BackColor = Color.White
			Me.nozzleUpDown.BorderStyle = BorderStyle.FixedSingle
			Me.nozzleUpDown.Font = New Font("Arial", 8F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.nozzleUpDown.Location = New Point(145, 136)
			Me.nozzleUpDown.Margin = New Padding(0)
			Me.nozzleUpDown.Maximum = New Decimal(New Integer() { 6, 0, 0, 0})
			Me.nozzleUpDown.Name = "nozzleUpDown"
			Me.nozzleUpDown.ReadOnly = True
			Me.nozzleUpDown.Size = New Size(36, 20)
			Me.nozzleUpDown.TabIndex = 29
			Me.nozzleUpDown.TextAlign = HorizontalAlignment.Center
'			Me.nozzleUpDown.ValueChanged += New System.EventHandler(Me.nozzleUpDown_ValueChanged)
			' 
			' lblExecutedCommand
			' 
			Me.lblExecutedCommand.AutoSize = True
			Me.lblExecutedCommand.Font = New Font("Tahoma", 6.75F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.lblExecutedCommand.Location = New Point(137, 29)
			Me.lblExecutedCommand.Name = "lblExecutedCommand"
			Me.lblExecutedCommand.Size = New Size(0, 11)
			Me.lblExecutedCommand.TabIndex = 30
			' 
			' timerAutomaticAuthorize
			' 
			Me.timerAutomaticAuthorize.Interval = 1000
'			Me.timerAutomaticAuthorize.Tick += New System.EventHandler(Me.timerAutomaticAuthorize_Tick)
			' 
			' lblVolTotal
			' 
			Me.lblVolTotal.AutoSize = True
			Me.lblVolTotal.Font = New Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.lblVolTotal.Location = New Point(5, 159)
			Me.lblVolTotal.Margin = New Padding(5, 0, 3, 0)
			Me.lblVolTotal.Name = "lblVolTotal"
			Me.lblVolTotal.Size = New Size(73, 17)
			Me.lblVolTotal.TabIndex = 31
			Me.lblVolTotal.Text = "Vol. total"
			' 
			' lblAmoTotal
			' 
			Me.lblAmoTotal.AutoSize = True
			Me.lblAmoTotal.Font = New Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.lblAmoTotal.Location = New Point(5, 176)
			Me.lblAmoTotal.Margin = New Padding(5, 0, 3, 0)
			Me.lblAmoTotal.Name = "lblAmoTotal"
			Me.lblAmoTotal.Size = New Size(80, 17)
			Me.lblAmoTotal.TabIndex = 33
			Me.lblAmoTotal.Text = "Mon. total"
			' 
			' txbVolTotalValue
			' 
			Me.txbVolTotalValue.BackColor = Color.LightYellow
			Me.txbVolTotalValue.BorderStyle = BorderStyle.None
			Me.txbVolTotalValue.Font = New Font("Arial", 8F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.txbVolTotalValue.Location = New Point(91, 163)
			Me.txbVolTotalValue.Name = "txbVolTotalValue"
			Me.txbVolTotalValue.ReadOnly = True
			Me.txbVolTotalValue.Size = New Size(90, 13)
			Me.txbVolTotalValue.TabIndex = 35
			Me.txbVolTotalValue.Text = "0"
			Me.txbVolTotalValue.TextAlign = HorizontalAlignment.Right
			' 
			' txbAmoTotalValue
			' 
			Me.txbAmoTotalValue.BackColor = Color.LightYellow
			Me.txbAmoTotalValue.BorderStyle = BorderStyle.None
			Me.txbAmoTotalValue.Font = New Font("Arial", 8F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.txbAmoTotalValue.Location = New Point(91, 178)
			Me.txbAmoTotalValue.Name = "txbAmoTotalValue"
			Me.txbAmoTotalValue.ReadOnly = True
			Me.txbAmoTotalValue.Size = New Size(90, 13)
			Me.txbAmoTotalValue.TabIndex = 36
			Me.txbAmoTotalValue.Text = "0"
			Me.txbAmoTotalValue.TextAlign = HorizontalAlignment.Right
			' 
			' priceLabel
			' 
			Me.priceLabel.BackColor = Color.LightYellow
			Me.priceLabel.BorderStyle = BorderStyle.None
			Me.priceLabel.Font = New Font("Arial", 8F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.priceLabel.Location = New Point(73, 117)
			Me.priceLabel.Name = "priceLabel"
			Me.priceLabel.ReadOnly = True
			Me.priceLabel.Size = New Size(90, 13)
			Me.priceLabel.TabIndex = 37
			Me.priceLabel.Text = "0"
			Me.priceLabel.TextAlign = HorizontalAlignment.Right
			' 
			' FuelPointControl
			' 
			Me.AutoScaleDimensions = New SizeF(6F, 13F)
			Me.AutoScaleMode = AutoScaleMode.Font
			Me.BackColor = Color.LightYellow
			Me.Controls.Add(Me.priceLabel)
			Me.Controls.Add(Me.txbAmoTotalValue)
			Me.Controls.Add(Me.txbVolTotalValue)
			Me.Controls.Add(Me.lblAmoTotal)
			Me.Controls.Add(Me.lblVolTotal)
			Me.Controls.Add(Me.lblExecutedCommand)
			Me.Controls.Add(Me.nozzleUpDown)
			Me.Controls.Add(Me.totalsButton)
			Me.Controls.Add(Me.settingsButton)
			Me.Controls.Add(Me.stopButton)
			Me.Controls.Add(Me.startButton)
			Me.Controls.Add(Me.comboBoxDispenseMode)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.panelStatusLabel)
			Me.Controls.Add(Me.panelPumpID)
			Me.Controls.Add(Me.volumeUpDown)
			Me.Controls.Add(Me.label7)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.paymentUpDown)
			Me.Controls.Add(Me.label2)
			Me.MinimumSize = New Size(180, 210)
			Me.Name = "FuelPointControl"
			Me.Size = New Size(197, 262)
'			Me.Load += New System.EventHandler(Me.FuelPointControl_Load)
			CType(Me.paymentUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.volumeUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.panelPumpID.ResumeLayout(False)
			Me.panelStatusLabel.ResumeLayout(False)
			CType(Me.pbTotalsRequest, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.nozzleUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private label2 As Label
		Private label3 As Label
		Private statusLabel As Label
		Private pumpAddressLabel As Label
		Private WithEvents paymentUpDown As NumericUpDown
		Private WithEvents volumeUpDown As NumericUpDown
		Private label4 As Label
		Private label7 As Label
		Private toolTip1 As ToolTip
		Private panelPumpID As Panel
		Private panelStatusLabel As Panel
		Private label1 As Label
		Private WithEvents comboBoxDispenseMode As ComboBox
		Private WithEvents startButton As Button
		Private WithEvents stopButton As Button
		Private WithEvents settingsButton As Button
		Private WithEvents totalsButton As Button
		Private WithEvents nozzleUpDown As NumericUpDown
		Private pbTotalsRequest As PictureBox
		Private lblExecutedCommand As Label
		Private WithEvents timerAutomaticAuthorize As Timer
		Private lblVolTotal As Label
		Private lblAmoTotal As Label
		Private txbVolTotalValue As TextBox
		Private txbAmoTotalValue As TextBox
		Private priceLabel As TextBox

	End Class
End Namespace

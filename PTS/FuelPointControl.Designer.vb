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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FuelPointControl))
      Me.label2 = New System.Windows.Forms.Label()
      Me.label3 = New System.Windows.Forms.Label()
      Me.statusLabel = New System.Windows.Forms.Label()
      Me.pumpAddressLabel = New System.Windows.Forms.Label()
      Me.paymentUpDown = New System.Windows.Forms.NumericUpDown()
      Me.volumeUpDown = New System.Windows.Forms.NumericUpDown()
      Me.label4 = New System.Windows.Forms.Label()
      Me.label7 = New System.Windows.Forms.Label()
      Me.panelPumpID = New System.Windows.Forms.Panel()
      Me.toolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.panelStatusLabel = New System.Windows.Forms.Panel()
      Me.pbTotalsRequest = New System.Windows.Forms.PictureBox()
      Me.label1 = New System.Windows.Forms.Label()
      Me.comboBoxDispenseMode = New System.Windows.Forms.ComboBox()
      Me.startButton = New System.Windows.Forms.Button()
      Me.stopButton = New System.Windows.Forms.Button()
      Me.settingsButton = New System.Windows.Forms.Button()
      Me.totalsButton = New System.Windows.Forms.Button()
      Me.nozzleUpDown = New System.Windows.Forms.NumericUpDown()
      Me.lblExecutedCommand = New System.Windows.Forms.Label()
      Me.timerAutomaticAuthorize = New System.Windows.Forms.Timer(Me.components)
      Me.lblVolTotal = New System.Windows.Forms.Label()
      Me.lblAmoTotal = New System.Windows.Forms.Label()
      Me.txbVolTotalValue = New System.Windows.Forms.TextBox()
      Me.txbAmoTotalValue = New System.Windows.Forms.TextBox()
      Me.priceLabel = New System.Windows.Forms.TextBox()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.lbID = New System.Windows.Forms.Label()
      Me.Panel2 = New System.Windows.Forms.Panel()
      Me.LbAmount = New System.Windows.Forms.Label()
      Me.LBLiters = New System.Windows.Forms.Label()
      Me.LBProduct = New System.Windows.Forms.Label()
      Me.lbState = New System.Windows.Forms.Label()
      Me.PictureBox1 = New System.Windows.Forms.PictureBox()
      CType(Me.paymentUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.volumeUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.panelPumpID.SuspendLayout()
      Me.panelStatusLabel.SuspendLayout()
      CType(Me.pbTotalsRequest, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.nozzleUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.Panel1.SuspendLayout()
      Me.Panel2.SuspendLayout()
      CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'label2
      '
      Me.label2.AutoSize = True
      Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
      Me.label2.Location = New System.Drawing.Point(5, 69)
      Me.label2.Margin = New System.Windows.Forms.Padding(5, 0, 0, 0)
      Me.label2.Name = "label2"
      Me.label2.Size = New System.Drawing.Size(62, 17)
      Me.label2.TabIndex = 1
      Me.label2.Text = "Amount"
      '
      'label3
      '
      Me.label3.AutoSize = True
      Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
      Me.label3.Location = New System.Drawing.Point(5, 92)
      Me.label3.Margin = New System.Windows.Forms.Padding(5, 0, 0, 0)
      Me.label3.Name = "label3"
      Me.label3.Size = New System.Drawing.Size(61, 17)
      Me.label3.TabIndex = 2
      Me.label3.Text = "Volume"
      '
      'statusLabel
      '
      Me.statusLabel.Dock = System.Windows.Forms.DockStyle.Fill
      Me.statusLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
      Me.statusLabel.Location = New System.Drawing.Point(0, 0)
      Me.statusLabel.Name = "statusLabel"
      Me.statusLabel.Size = New System.Drawing.Size(163, 30)
      Me.statusLabel.TabIndex = 5
      Me.statusLabel.Text = "Offline"
      Me.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'pumpAddressLabel
      '
      Me.pumpAddressLabel.BackColor = System.Drawing.Color.Transparent
      Me.pumpAddressLabel.Dock = System.Windows.Forms.DockStyle.Fill
      Me.pumpAddressLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.pumpAddressLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
      Me.pumpAddressLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
      Me.pumpAddressLabel.Location = New System.Drawing.Point(0, 0)
      Me.pumpAddressLabel.Name = "pumpAddressLabel"
      Me.pumpAddressLabel.Size = New System.Drawing.Size(40, 30)
      Me.pumpAddressLabel.TabIndex = 10
      Me.pumpAddressLabel.Text = "-"
      Me.pumpAddressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.toolTip1.SetToolTip(Me.pumpAddressLabel, "FuelPointID")
      '
      'paymentUpDown
      '
      Me.paymentUpDown.BackColor = System.Drawing.Color.White
      Me.paymentUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.paymentUpDown.DecimalPlaces = 2
      Me.paymentUpDown.Enabled = False
      Me.paymentUpDown.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.paymentUpDown.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
      Me.paymentUpDown.Location = New System.Drawing.Point(109, 69)
      Me.paymentUpDown.Margin = New System.Windows.Forms.Padding(0)
      Me.paymentUpDown.Maximum = New Decimal(New Integer() {999999999, 0, 0, 131072})
      Me.paymentUpDown.Name = "paymentUpDown"
      Me.paymentUpDown.Size = New System.Drawing.Size(72, 20)
      Me.paymentUpDown.TabIndex = 14
      Me.paymentUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'volumeUpDown
      '
      Me.volumeUpDown.BackColor = System.Drawing.Color.White
      Me.volumeUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.volumeUpDown.DecimalPlaces = 2
      Me.volumeUpDown.Enabled = False
      Me.volumeUpDown.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
      Me.volumeUpDown.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
      Me.volumeUpDown.Location = New System.Drawing.Point(109, 92)
      Me.volumeUpDown.Margin = New System.Windows.Forms.Padding(0)
      Me.volumeUpDown.Maximum = New Decimal(New Integer() {999999999, 0, 0, 131072})
      Me.volumeUpDown.Name = "volumeUpDown"
      Me.volumeUpDown.Size = New System.Drawing.Size(72, 20)
      Me.volumeUpDown.TabIndex = 15
      Me.volumeUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'label4
      '
      Me.label4.AutoSize = True
      Me.label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
      Me.label4.Location = New System.Drawing.Point(5, 136)
      Me.label4.Margin = New System.Windows.Forms.Padding(5, 0, 3, 0)
      Me.label4.Name = "label4"
      Me.label4.Size = New System.Drawing.Size(57, 17)
      Me.label4.TabIndex = 16
      Me.label4.Text = "Nozzle"
      '
      'label7
      '
      Me.label7.AutoSize = True
      Me.label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
      Me.label7.Location = New System.Drawing.Point(5, 115)
      Me.label7.Margin = New System.Windows.Forms.Padding(5, 0, 3, 0)
      Me.label7.Name = "label7"
      Me.label7.Size = New System.Drawing.Size(45, 17)
      Me.label7.TabIndex = 18
      Me.label7.Text = "Price"
      '
      'panelPumpID
      '
      Me.panelPumpID.BackColor = System.Drawing.SystemColors.GradientActiveCaption
      Me.panelPumpID.Controls.Add(Me.pumpAddressLabel)
      Me.panelPumpID.Location = New System.Drawing.Point(-1, -1)
      Me.panelPumpID.Name = "panelPumpID"
      Me.panelPumpID.Size = New System.Drawing.Size(40, 30)
      Me.panelPumpID.TabIndex = 20
      '
      'panelStatusLabel
      '
      Me.panelStatusLabel.BackColor = System.Drawing.Color.LightGray
      Me.panelStatusLabel.Controls.Add(Me.pbTotalsRequest)
      Me.panelStatusLabel.Controls.Add(Me.statusLabel)
      Me.panelStatusLabel.Location = New System.Drawing.Point(34, -1)
      Me.panelStatusLabel.Name = "panelStatusLabel"
      Me.panelStatusLabel.Size = New System.Drawing.Size(163, 30)
      Me.panelStatusLabel.TabIndex = 21
      '
      'pbTotalsRequest
      '
      Me.pbTotalsRequest.Image = Global.My.Resources.Resources.ajax_loader
      Me.pbTotalsRequest.InitialImage = Global.My.Resources.Resources.totalsRequest
      Me.pbTotalsRequest.Location = New System.Drawing.Point(0, 1)
      Me.pbTotalsRequest.Name = "pbTotalsRequest"
      Me.pbTotalsRequest.Size = New System.Drawing.Size(20, 20)
      Me.pbTotalsRequest.TabIndex = 7
      Me.pbTotalsRequest.TabStop = False
      '
      'label1
      '
      Me.label1.AutoSize = True
      Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
      Me.label1.Location = New System.Drawing.Point(5, 40)
      Me.label1.Margin = New System.Windows.Forms.Padding(5, 0, 0, 0)
      Me.label1.Name = "label1"
      Me.label1.Size = New System.Drawing.Size(47, 17)
      Me.label1.TabIndex = 22
      Me.label1.Text = "Mode"
      '
      'comboBoxDispenseMode
      '
      Me.comboBoxDispenseMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.comboBoxDispenseMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
      Me.comboBoxDispenseMode.Location = New System.Drawing.Point(65, 40)
      Me.comboBoxDispenseMode.MaxDropDownItems = 2
      Me.comboBoxDispenseMode.Name = "comboBoxDispenseMode"
      Me.comboBoxDispenseMode.Size = New System.Drawing.Size(116, 21)
      Me.comboBoxDispenseMode.TabIndex = 23
      '
      'startButton
      '
      Me.startButton.Enabled = False
      Me.startButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
      Me.startButton.Location = New System.Drawing.Point(5, 201)
      Me.startButton.Margin = New System.Windows.Forms.Padding(0)
      Me.startButton.Name = "startButton"
      Me.startButton.Size = New System.Drawing.Size(90, 28)
      Me.startButton.TabIndex = 24
      Me.startButton.Text = "Start"
      Me.startButton.UseVisualStyleBackColor = True
      '
      'stopButton
      '
      Me.stopButton.Enabled = False
      Me.stopButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
      Me.stopButton.Location = New System.Drawing.Point(100, 201)
      Me.stopButton.Margin = New System.Windows.Forms.Padding(0)
      Me.stopButton.Name = "stopButton"
      Me.stopButton.Size = New System.Drawing.Size(90, 28)
      Me.stopButton.TabIndex = 25
      Me.stopButton.Text = "Stop"
      Me.stopButton.UseVisualStyleBackColor = True
      '
      'settingsButton
      '
      Me.settingsButton.Enabled = False
      Me.settingsButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
      Me.settingsButton.Location = New System.Drawing.Point(99, 232)
      Me.settingsButton.Name = "settingsButton"
      Me.settingsButton.Size = New System.Drawing.Size(91, 23)
      Me.settingsButton.TabIndex = 26
      Me.settingsButton.Text = "Settings"
      Me.settingsButton.UseVisualStyleBackColor = True
      '
      'totalsButton
      '
      Me.totalsButton.Enabled = False
      Me.totalsButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
      Me.totalsButton.Location = New System.Drawing.Point(4, 232)
      Me.totalsButton.Name = "totalsButton"
      Me.totalsButton.Size = New System.Drawing.Size(91, 23)
      Me.totalsButton.TabIndex = 27
      Me.totalsButton.Text = "Totals"
      Me.totalsButton.UseVisualStyleBackColor = True
      '
      'nozzleUpDown
      '
      Me.nozzleUpDown.BackColor = System.Drawing.Color.White
      Me.nozzleUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.nozzleUpDown.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
      Me.nozzleUpDown.Location = New System.Drawing.Point(145, 136)
      Me.nozzleUpDown.Margin = New System.Windows.Forms.Padding(0)
      Me.nozzleUpDown.Maximum = New Decimal(New Integer() {6, 0, 0, 0})
      Me.nozzleUpDown.Name = "nozzleUpDown"
      Me.nozzleUpDown.ReadOnly = True
      Me.nozzleUpDown.Size = New System.Drawing.Size(36, 20)
      Me.nozzleUpDown.TabIndex = 29
      Me.nozzleUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'lblExecutedCommand
      '
      Me.lblExecutedCommand.AutoSize = True
      Me.lblExecutedCommand.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
      Me.lblExecutedCommand.Location = New System.Drawing.Point(137, 29)
      Me.lblExecutedCommand.Name = "lblExecutedCommand"
      Me.lblExecutedCommand.Size = New System.Drawing.Size(0, 11)
      Me.lblExecutedCommand.TabIndex = 30
      '
      'timerAutomaticAuthorize
      '
      Me.timerAutomaticAuthorize.Interval = 1000
      '
      'lblVolTotal
      '
      Me.lblVolTotal.AutoSize = True
      Me.lblVolTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
      Me.lblVolTotal.Location = New System.Drawing.Point(5, 159)
      Me.lblVolTotal.Margin = New System.Windows.Forms.Padding(5, 0, 3, 0)
      Me.lblVolTotal.Name = "lblVolTotal"
      Me.lblVolTotal.Size = New System.Drawing.Size(73, 17)
      Me.lblVolTotal.TabIndex = 31
      Me.lblVolTotal.Text = "Vol. total"
      '
      'lblAmoTotal
      '
      Me.lblAmoTotal.AutoSize = True
      Me.lblAmoTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
      Me.lblAmoTotal.Location = New System.Drawing.Point(5, 176)
      Me.lblAmoTotal.Margin = New System.Windows.Forms.Padding(5, 0, 3, 0)
      Me.lblAmoTotal.Name = "lblAmoTotal"
      Me.lblAmoTotal.Size = New System.Drawing.Size(80, 17)
      Me.lblAmoTotal.TabIndex = 33
      Me.lblAmoTotal.Text = "Mon. total"
      '
      'txbVolTotalValue
      '
      Me.txbVolTotalValue.BackColor = System.Drawing.Color.LightYellow
      Me.txbVolTotalValue.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me.txbVolTotalValue.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
      Me.txbVolTotalValue.Location = New System.Drawing.Point(91, 163)
      Me.txbVolTotalValue.Name = "txbVolTotalValue"
      Me.txbVolTotalValue.ReadOnly = True
      Me.txbVolTotalValue.Size = New System.Drawing.Size(90, 13)
      Me.txbVolTotalValue.TabIndex = 35
      Me.txbVolTotalValue.Text = "0"
      Me.txbVolTotalValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txbAmoTotalValue
      '
      Me.txbAmoTotalValue.BackColor = System.Drawing.Color.LightYellow
      Me.txbAmoTotalValue.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me.txbAmoTotalValue.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
      Me.txbAmoTotalValue.Location = New System.Drawing.Point(91, 178)
      Me.txbAmoTotalValue.Name = "txbAmoTotalValue"
      Me.txbAmoTotalValue.ReadOnly = True
      Me.txbAmoTotalValue.Size = New System.Drawing.Size(90, 13)
      Me.txbAmoTotalValue.TabIndex = 36
      Me.txbAmoTotalValue.Text = "0"
      Me.txbAmoTotalValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'priceLabel
      '
      Me.priceLabel.BackColor = System.Drawing.Color.LightYellow
      Me.priceLabel.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me.priceLabel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
      Me.priceLabel.Location = New System.Drawing.Point(73, 117)
      Me.priceLabel.Name = "priceLabel"
      Me.priceLabel.ReadOnly = True
      Me.priceLabel.Size = New System.Drawing.Size(90, 13)
      Me.priceLabel.TabIndex = 37
      Me.priceLabel.Text = "0"
      Me.priceLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Panel1
      '
      Me.Panel1.Controls.Add(Me.lbID)
      Me.Panel1.Controls.Add(Me.Panel2)
      Me.Panel1.Controls.Add(Me.PictureBox1)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.Panel1.Location = New System.Drawing.Point(0, 0)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(134, 138)
      Me.Panel1.TabIndex = 38
      '
      'lbID
      '
      Me.lbID.BackColor = System.Drawing.Color.White
      Me.lbID.Location = New System.Drawing.Point(0, 0)
      Me.lbID.Name = "lbID"
      Me.lbID.Size = New System.Drawing.Size(28, 20)
      Me.lbID.TabIndex = 5
      Me.lbID.Text = "00"
      Me.lbID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'Panel2
      '
      Me.Panel2.BackColor = System.Drawing.Color.White
      Me.Panel2.Controls.Add(Me.LbAmount)
      Me.Panel2.Controls.Add(Me.LBLiters)
      Me.Panel2.Controls.Add(Me.LBProduct)
      Me.Panel2.Controls.Add(Me.lbState)
      Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
      Me.Panel2.Location = New System.Drawing.Point(0, 66)
      Me.Panel2.Name = "Panel2"
      Me.Panel2.Size = New System.Drawing.Size(134, 72)
      Me.Panel2.TabIndex = 1
      '
      'LbAmount
      '
      Me.LbAmount.Dock = System.Windows.Forms.DockStyle.Top
      Me.LbAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.LbAmount.Location = New System.Drawing.Point(0, 39)
      Me.LbAmount.Name = "LbAmount"
      Me.LbAmount.Size = New System.Drawing.Size(134, 13)
      Me.LbAmount.TabIndex = 4
      Me.LbAmount.Text = "P0.00"
      Me.LbAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'LBLiters
      '
      Me.LBLiters.Dock = System.Windows.Forms.DockStyle.Top
      Me.LBLiters.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.LBLiters.Location = New System.Drawing.Point(0, 26)
      Me.LBLiters.Name = "LBLiters"
      Me.LBLiters.Size = New System.Drawing.Size(134, 13)
      Me.LBLiters.TabIndex = 3
      Me.LBLiters.Text = "0.000L"
      Me.LBLiters.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'LBProduct
      '
      Me.LBProduct.Dock = System.Windows.Forms.DockStyle.Top
      Me.LBProduct.Location = New System.Drawing.Point(0, 13)
      Me.LBProduct.Name = "LBProduct"
      Me.LBProduct.Size = New System.Drawing.Size(134, 13)
      Me.LBProduct.TabIndex = 1
      Me.LBProduct.Text = "UNLEADED(99.99)"
      Me.LBProduct.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lbState
      '
      Me.lbState.Dock = System.Windows.Forms.DockStyle.Top
      Me.lbState.Location = New System.Drawing.Point(0, 0)
      Me.lbState.Name = "lbState"
      Me.lbState.Size = New System.Drawing.Size(134, 13)
      Me.lbState.TabIndex = 0
      Me.lbState.Text = "IDLE"
      Me.lbState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'PictureBox1
      '
      Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
      Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
      Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
      Me.PictureBox1.Name = "PictureBox1"
      Me.PictureBox1.Size = New System.Drawing.Size(134, 66)
      Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
      Me.PictureBox1.TabIndex = 0
      Me.PictureBox1.TabStop = False
      '
      'FuelPointControl
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.LightYellow
      Me.Controls.Add(Me.Panel1)
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
      Me.Name = "FuelPointControl"
      Me.Size = New System.Drawing.Size(134, 138)
      CType(Me.paymentUpDown, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.volumeUpDown, System.ComponentModel.ISupportInitialize).EndInit()
      Me.panelPumpID.ResumeLayout(False)
      Me.panelStatusLabel.ResumeLayout(False)
      CType(Me.pbTotalsRequest, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.nozzleUpDown, System.ComponentModel.ISupportInitialize).EndInit()
      Me.Panel1.ResumeLayout(False)
      Me.Panel2.ResumeLayout(False)
      CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents LbAmount As Label
    Friend WithEvents LBLiters As Label
    Friend WithEvents LBProduct As Label
    Friend WithEvents lbState As Label
    Friend WithEvents lbID As Label
  End Class
End Namespace

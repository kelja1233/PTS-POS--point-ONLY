Namespace TiT.PTS
	Partial Public Class PtsDispensingSettingsDialog
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
		End Sub

		#Region "Код, автоматически созданный конструктором форм Windows"

		''' <summary>
		''' Обязательный метод для поддержки конструктора - не изменяйте
		''' содержимое данного метода при помощи редактора кода.
		''' </summary>
		Private Sub InitializeComponent()
			Me.radioButtonAuthorizationVolume = New RadioButton()
			Me.radioButtonAuthorizationAmount = New RadioButton()
			Me.groupBoxAuthorizationType = New GroupBox()
			Me.btnOk = New Button()
			Me.btnCancel = New Button()
			Me.groupBoxAuthPolling = New GroupBox()
			Me.rdbPollingOff = New RadioButton()
			Me.rdbPollingOn = New RadioButton()
			Me.groupBoxCommands = New GroupBox()
			Me.rdbExtendedCommands = New RadioButton()
			Me.rdbGeneralCommands = New RadioButton()
			Me.groupBox1 = New GroupBox()
			Me.label1 = New Label()
			Me.udManualModeAuthorizeValue = New NumericUpDown()
			Me.radioButtonManualAuthorize = New RadioButton()
			Me.radioButtonAutomaticAuthorize = New RadioButton()
			Me.groupBox2 = New GroupBox()
			Me.radioButtonNotRequestTotals = New RadioButton()
			Me.radioButtonRequestTotals = New RadioButton()
			Me.groupBox3 = New GroupBox()
			Me.label6 = New Label()
			Me.udVolumeCounterDigits = New NumericUpDown()
			Me.label5 = New Label()
			Me.udAmountCounterDigits = New NumericUpDown()
			Me.label4 = New Label()
			Me.udPriceDigits = New NumericUpDown()
			Me.label3 = New Label()
			Me.udVolumeDigits = New NumericUpDown()
			Me.label2 = New Label()
			Me.udAmountDigits = New NumericUpDown()
			Me.groupBoxAuthorizationType.SuspendLayout()
			Me.groupBoxAuthPolling.SuspendLayout()
			Me.groupBoxCommands.SuspendLayout()
			Me.groupBox1.SuspendLayout()
			CType(Me.udManualModeAuthorizeValue, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.groupBox2.SuspendLayout()
			Me.groupBox3.SuspendLayout()
			CType(Me.udVolumeCounterDigits, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.udAmountCounterDigits, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.udPriceDigits, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.udVolumeDigits, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.udAmountDigits, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' radioButtonAuthorizationVolume
			' 
			Me.radioButtonAuthorizationVolume.AutoSize = True
			Me.radioButtonAuthorizationVolume.Checked = True
			Me.radioButtonAuthorizationVolume.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			Me.radioButtonAuthorizationVolume.Location = New Point(7, 19)
			Me.radioButtonAuthorizationVolume.Name = "radioButtonAuthorizationVolume"
			Me.radioButtonAuthorizationVolume.Size = New Size(157, 17)
			Me.radioButtonAuthorizationVolume.TabIndex = 0
			Me.radioButtonAuthorizationVolume.TabStop = True
			Me.radioButtonAuthorizationVolume.Text = "Authorization by fuel volume"
			Me.radioButtonAuthorizationVolume.UseVisualStyleBackColor = True
'			Me.radioButtonAuthorizationVolume.CheckedChanged += New System.EventHandler(Me.radioButtonAuthorizationVolume_CheckedChanged)
			' 
			' radioButtonAuthorizationAmount
			' 
			Me.radioButtonAuthorizationAmount.AutoSize = True
			Me.radioButtonAuthorizationAmount.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			Me.radioButtonAuthorizationAmount.Location = New Point(7, 42)
			Me.radioButtonAuthorizationAmount.Name = "radioButtonAuthorizationAmount"
			Me.radioButtonAuthorizationAmount.Size = New Size(172, 17)
			Me.radioButtonAuthorizationAmount.TabIndex = 1
			Me.radioButtonAuthorizationAmount.Text = "Authorization by money amount"
			Me.radioButtonAuthorizationAmount.UseVisualStyleBackColor = True
'			Me.radioButtonAuthorizationAmount.CheckedChanged += New System.EventHandler(Me.radioButtonAuthorizationAmount_CheckedChanged)
			' 
			' groupBoxAuthorizationType
			' 
			Me.groupBoxAuthorizationType.Controls.Add(Me.radioButtonAuthorizationVolume)
			Me.groupBoxAuthorizationType.Controls.Add(Me.radioButtonAuthorizationAmount)
			Me.groupBoxAuthorizationType.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.groupBoxAuthorizationType.Location = New Point(12, 12)
			Me.groupBoxAuthorizationType.Name = "groupBoxAuthorizationType"
			Me.groupBoxAuthorizationType.Size = New Size(263, 69)
			Me.groupBoxAuthorizationType.TabIndex = 2
			Me.groupBoxAuthorizationType.TabStop = False
			Me.groupBoxAuthorizationType.Text = "Authorization type"
			' 
			' btnOk
			' 
			Me.btnOk.DialogResult = DialogResult.OK
			Me.btnOk.Location = New Point(400, 285)
			Me.btnOk.Name = "btnOk"
			Me.btnOk.Size = New Size(75, 23)
			Me.btnOk.TabIndex = 3
			Me.btnOk.Text = "OK"
			Me.btnOk.UseVisualStyleBackColor = True
'			Me.btnOk.Click += New System.EventHandler(Me.okButton_Click)
			' 
			' btnCancel
			' 
			Me.btnCancel.Anchor = (CType((AnchorStyles.Bottom Or AnchorStyles.Right), AnchorStyles))
			Me.btnCancel.DialogResult = DialogResult.Cancel
			Me.btnCancel.Location = New Point(481, 285)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.Size = New Size(75, 23)
			Me.btnCancel.TabIndex = 4
			Me.btnCancel.Text = "Cancel"
			Me.btnCancel.UseVisualStyleBackColor = True
			' 
			' groupBoxAuthPolling
			' 
			Me.groupBoxAuthPolling.Controls.Add(Me.rdbPollingOff)
			Me.groupBoxAuthPolling.Controls.Add(Me.rdbPollingOn)
			Me.groupBoxAuthPolling.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.groupBoxAuthPolling.Location = New Point(12, 87)
			Me.groupBoxAuthPolling.Name = "groupBoxAuthPolling"
			Me.groupBoxAuthPolling.Size = New Size(263, 69)
			Me.groupBoxAuthPolling.TabIndex = 5
			Me.groupBoxAuthPolling.TabStop = False
			Me.groupBoxAuthPolling.Text = "Authorization polling"
			' 
			' rdbPollingOff
			' 
			Me.rdbPollingOff.AutoSize = True
			Me.rdbPollingOff.Checked = True
			Me.rdbPollingOff.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			Me.rdbPollingOff.Location = New Point(7, 42)
			Me.rdbPollingOff.Name = "rdbPollingOff"
			Me.rdbPollingOff.Size = New Size(221, 17)
			Me.rdbPollingOff.TabIndex = 1
			Me.rdbPollingOff.TabStop = True
			Me.rdbPollingOff.Text = "Do not poll when pump is in READY state"
			Me.rdbPollingOff.UseVisualStyleBackColor = True
'			Me.rdbPollingOff.CheckedChanged += New System.EventHandler(Me.rdbPollingOff_CheckedChanged)
			' 
			' rdbPollingOn
			' 
			Me.rdbPollingOn.AutoSize = True
			Me.rdbPollingOn.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			Me.rdbPollingOn.Location = New Point(7, 19)
			Me.rdbPollingOn.Name = "rdbPollingOn"
			Me.rdbPollingOn.Size = New Size(228, 17)
			Me.rdbPollingOn.TabIndex = 0
			Me.rdbPollingOn.Text = "Keep polling when pump is in READY state"
			Me.rdbPollingOn.UseVisualStyleBackColor = True
'			Me.rdbPollingOn.CheckedChanged += New System.EventHandler(Me.rdbPollingOn_CheckedChanged)
			' 
			' groupBoxCommands
			' 
			Me.groupBoxCommands.Controls.Add(Me.rdbExtendedCommands)
			Me.groupBoxCommands.Controls.Add(Me.rdbGeneralCommands)
			Me.groupBoxCommands.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.groupBoxCommands.Location = New Point(12, 162)
			Me.groupBoxCommands.Name = "groupBoxCommands"
			Me.groupBoxCommands.Size = New Size(263, 69)
			Me.groupBoxCommands.TabIndex = 6
			Me.groupBoxCommands.TabStop = False
			Me.groupBoxCommands.Text = "Extended commands"
			' 
			' rdbExtendedCommands
			' 
			Me.rdbExtendedCommands.AutoSize = True
			Me.rdbExtendedCommands.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			Me.rdbExtendedCommands.Location = New Point(7, 42)
			Me.rdbExtendedCommands.Name = "rdbExtendedCommands"
			Me.rdbExtendedCommands.Size = New Size(145, 17)
			Me.rdbExtendedCommands.TabIndex = 1
			Me.rdbExtendedCommands.Text = "Use extended commands"
			Me.rdbExtendedCommands.UseVisualStyleBackColor = True
'			Me.rdbExtendedCommands.CheckedChanged += New System.EventHandler(Me.rdbExtendedCommands_CheckedChanged)
			' 
			' rdbGeneralCommands
			' 
			Me.rdbGeneralCommands.AutoSize = True
			Me.rdbGeneralCommands.Checked = True
			Me.rdbGeneralCommands.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			Me.rdbGeneralCommands.Location = New Point(7, 19)
			Me.rdbGeneralCommands.Name = "rdbGeneralCommands"
			Me.rdbGeneralCommands.Size = New Size(136, 17)
			Me.rdbGeneralCommands.TabIndex = 0
			Me.rdbGeneralCommands.TabStop = True
			Me.rdbGeneralCommands.Text = "Use general commands"
			Me.rdbGeneralCommands.UseVisualStyleBackColor = True
'			Me.rdbGeneralCommands.CheckedChanged += New System.EventHandler(Me.rdbGeneralCommands_CheckedChanged)
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.label1)
			Me.groupBox1.Controls.Add(Me.udManualModeAuthorizeValue)
			Me.groupBox1.Controls.Add(Me.radioButtonManualAuthorize)
			Me.groupBox1.Controls.Add(Me.radioButtonAutomaticAuthorize)
			Me.groupBox1.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.groupBox1.Location = New Point(287, 12)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New Size(263, 95)
			Me.groupBox1.TabIndex = 7
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Manual mode settings"
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			Me.label1.Location = New Point(99, 71)
			Me.label1.Name = "label1"
			Me.label1.Size = New Size(90, 13)
			Me.label1.TabIndex = 4
			Me.label1.Text = "Dose to authorize"
			' 
			' udManualModeAuthorizeValue
			' 
			Me.udManualModeAuthorizeValue.Location = New Point(6, 69)
			Me.udManualModeAuthorizeValue.Maximum = New Decimal(New Integer() { 999999, 0, 0, 0})
			Me.udManualModeAuthorizeValue.Name = "udManualModeAuthorizeValue"
			Me.udManualModeAuthorizeValue.Size = New Size(87, 20)
			Me.udManualModeAuthorizeValue.TabIndex = 3
			Me.udManualModeAuthorizeValue.TextAlign = HorizontalAlignment.Right
			' 
			' radioButtonManualAuthorize
			' 
			Me.radioButtonManualAuthorize.AutoSize = True
			Me.radioButtonManualAuthorize.Checked = True
			Me.radioButtonManualAuthorize.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			Me.radioButtonManualAuthorize.Location = New Point(6, 42)
			Me.radioButtonManualAuthorize.Name = "radioButtonManualAuthorize"
			Me.radioButtonManualAuthorize.Size = New Size(173, 17)
			Me.radioButtonManualAuthorize.TabIndex = 1
			Me.radioButtonManualAuthorize.TabStop = True
			Me.radioButtonManualAuthorize.Text = "Authorize manually at nozzle up"
			Me.radioButtonManualAuthorize.UseVisualStyleBackColor = True
'			Me.radioButtonManualAuthorize.CheckedChanged += New System.EventHandler(Me.radioButtonManualAuthorize_CheckedChanged)
			' 
			' radioButtonAutomaticAuthorize
			' 
			Me.radioButtonAutomaticAuthorize.AutoSize = True
			Me.radioButtonAutomaticAuthorize.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			Me.radioButtonAutomaticAuthorize.Location = New Point(6, 19)
			Me.radioButtonAutomaticAuthorize.Name = "radioButtonAutomaticAuthorize"
			Me.radioButtonAutomaticAuthorize.Size = New Size(193, 17)
			Me.radioButtonAutomaticAuthorize.TabIndex = 0
			Me.radioButtonAutomaticAuthorize.Text = "Authorize automatically at nozzle up"
			Me.radioButtonAutomaticAuthorize.UseVisualStyleBackColor = True
'			Me.radioButtonAutomaticAuthorize.CheckedChanged += New System.EventHandler(Me.radioButtonAutomaticAuthorize_CheckedChanged)
			' 
			' groupBox2
			' 
			Me.groupBox2.Controls.Add(Me.radioButtonNotRequestTotals)
			Me.groupBox2.Controls.Add(Me.radioButtonRequestTotals)
			Me.groupBox2.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.groupBox2.Location = New Point(12, 237)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New Size(263, 69)
			Me.groupBox2.TabIndex = 8
			Me.groupBox2.TabStop = False
			Me.groupBox2.Text = "Request total counters"
			' 
			' radioButtonNotRequestTotals
			' 
			Me.radioButtonNotRequestTotals.AutoSize = True
			Me.radioButtonNotRequestTotals.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			Me.radioButtonNotRequestTotals.Location = New Point(6, 42)
			Me.radioButtonNotRequestTotals.Name = "radioButtonNotRequestTotals"
			Me.radioButtonNotRequestTotals.Size = New Size(162, 17)
			Me.radioButtonNotRequestTotals.TabIndex = 1
			Me.radioButtonNotRequestTotals.Text = "Do not request total counters"
			Me.radioButtonNotRequestTotals.UseVisualStyleBackColor = True
'			Me.radioButtonNotRequestTotals.CheckedChanged += New System.EventHandler(Me.radioButtonNotRequestTotals_CheckedChanged)
			' 
			' radioButtonRequestTotals
			' 
			Me.radioButtonRequestTotals.AutoSize = True
			Me.radioButtonRequestTotals.Checked = True
			Me.radioButtonRequestTotals.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			Me.radioButtonRequestTotals.Location = New Point(6, 19)
			Me.radioButtonRequestTotals.Name = "radioButtonRequestTotals"
			Me.radioButtonRequestTotals.Size = New Size(132, 17)
			Me.radioButtonRequestTotals.TabIndex = 0
			Me.radioButtonRequestTotals.TabStop = True
			Me.radioButtonRequestTotals.Text = "Request total counters"
			Me.radioButtonRequestTotals.UseVisualStyleBackColor = True
'			Me.radioButtonRequestTotals.CheckedChanged += New System.EventHandler(Me.radioButtonRequestTotals_CheckedChanged)
			' 
			' groupBox3
			' 
			Me.groupBox3.Controls.Add(Me.label6)
			Me.groupBox3.Controls.Add(Me.udVolumeCounterDigits)
			Me.groupBox3.Controls.Add(Me.label5)
			Me.groupBox3.Controls.Add(Me.udAmountCounterDigits)
			Me.groupBox3.Controls.Add(Me.label4)
			Me.groupBox3.Controls.Add(Me.udPriceDigits)
			Me.groupBox3.Controls.Add(Me.label3)
			Me.groupBox3.Controls.Add(Me.udVolumeDigits)
			Me.groupBox3.Controls.Add(Me.label2)
			Me.groupBox3.Controls.Add(Me.udAmountDigits)
			Me.groupBox3.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.groupBox3.Location = New Point(287, 113)
			Me.groupBox3.Name = "groupBox3"
			Me.groupBox3.Size = New Size(263, 152)
			Me.groupBox3.TabIndex = 9
			Me.groupBox3.TabStop = False
			Me.groupBox3.Text = "Quantity of digits"
			' 
			' label6
			' 
			Me.label6.AutoSize = True
			Me.label6.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			Me.label6.Location = New Point(70, 124)
			Me.label6.Name = "label6"
			Me.label6.Size = New Size(109, 13)
			Me.label6.TabIndex = 9
			Me.label6.Text = "Volume total counters"
			Me.label6.TextAlign = ContentAlignment.MiddleRight
			' 
			' udVolumeCounterDigits
			' 
			Me.udVolumeCounterDigits.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.udVolumeCounterDigits.Location = New Point(188, 122)
			Me.udVolumeCounterDigits.Maximum = New Decimal(New Integer() { 3, 0, 0, 0})
			Me.udVolumeCounterDigits.Minimum = New Decimal(New Integer() { 2, 0, 0, 0})
			Me.udVolumeCounterDigits.Name = "udVolumeCounterDigits"
			Me.udVolumeCounterDigits.Size = New Size(69, 20)
			Me.udVolumeCounterDigits.TabIndex = 8
			Me.udVolumeCounterDigits.TextAlign = HorizontalAlignment.Right
			Me.udVolumeCounterDigits.Value = New Decimal(New Integer() { 2, 0, 0, 0})
			' 
			' label5
			' 
			Me.label5.AutoSize = True
			Me.label5.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			Me.label5.Location = New Point(35, 99)
			Me.label5.Name = "label5"
			Me.label5.Size = New Size(144, 13)
			Me.label5.TabIndex = 7
			Me.label5.Text = "Money amount total counters"
			Me.label5.TextAlign = ContentAlignment.MiddleRight
			' 
			' udAmountCounterDigits
			' 
			Me.udAmountCounterDigits.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.udAmountCounterDigits.Location = New Point(188, 97)
			Me.udAmountCounterDigits.Maximum = New Decimal(New Integer() { 3, 0, 0, 0})
			Me.udAmountCounterDigits.Name = "udAmountCounterDigits"
			Me.udAmountCounterDigits.Size = New Size(69, 20)
			Me.udAmountCounterDigits.TabIndex = 6
			Me.udAmountCounterDigits.TextAlign = HorizontalAlignment.Right
			Me.udAmountCounterDigits.Value = New Decimal(New Integer() { 2, 0, 0, 0})
			' 
			' label4
			' 
			Me.label4.AutoSize = True
			Me.label4.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			Me.label4.Location = New Point(148, 73)
			Me.label4.Name = "label4"
			Me.label4.Size = New Size(31, 13)
			Me.label4.TabIndex = 5
			Me.label4.Text = "Price"
			Me.label4.TextAlign = ContentAlignment.MiddleRight
			' 
			' udPriceDigits
			' 
			Me.udPriceDigits.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.udPriceDigits.Location = New Point(188, 71)
			Me.udPriceDigits.Maximum = New Decimal(New Integer() { 3, 0, 0, 0})
			Me.udPriceDigits.Name = "udPriceDigits"
			Me.udPriceDigits.Size = New Size(69, 20)
			Me.udPriceDigits.TabIndex = 4
			Me.udPriceDigits.TextAlign = HorizontalAlignment.Right
			Me.udPriceDigits.Value = New Decimal(New Integer() { 2, 0, 0, 0})
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			Me.label3.Location = New Point(137, 47)
			Me.label3.Name = "label3"
			Me.label3.Size = New Size(42, 13)
			Me.label3.TabIndex = 3
			Me.label3.Text = "Volume"
			Me.label3.TextAlign = ContentAlignment.MiddleRight
			' 
			' udVolumeDigits
			' 
			Me.udVolumeDigits.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.udVolumeDigits.Location = New Point(188, 45)
			Me.udVolumeDigits.Maximum = New Decimal(New Integer() { 3, 0, 0, 0})
			Me.udVolumeDigits.Minimum = New Decimal(New Integer() { 2, 0, 0, 0})
			Me.udVolumeDigits.Name = "udVolumeDigits"
			Me.udVolumeDigits.Size = New Size(69, 20)
			Me.udVolumeDigits.TabIndex = 2
			Me.udVolumeDigits.TextAlign = HorizontalAlignment.Right
			Me.udVolumeDigits.Value = New Decimal(New Integer() { 2, 0, 0, 0})
'			Me.udVolumeDigits.ValueChanged += New System.EventHandler(Me.udVolumeDigits_ValueChanged)
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			Me.label2.Location = New Point(102, 21)
			Me.label2.Name = "label2"
			Me.label2.Size = New Size(77, 13)
			Me.label2.TabIndex = 1
			Me.label2.Text = "Money amount"
			Me.label2.TextAlign = ContentAlignment.MiddleRight
			' 
			' udAmountDigits
			' 
			Me.udAmountDigits.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.udAmountDigits.Location = New Point(188, 19)
			Me.udAmountDigits.Maximum = New Decimal(New Integer() { 3, 0, 0, 0})
			Me.udAmountDigits.Name = "udAmountDigits"
			Me.udAmountDigits.Size = New Size(69, 20)
			Me.udAmountDigits.TabIndex = 0
			Me.udAmountDigits.TextAlign = HorizontalAlignment.Right
			Me.udAmountDigits.Value = New Decimal(New Integer() { 2, 0, 0, 0})
'			Me.udAmountDigits.ValueChanged += New System.EventHandler(Me.udAmountDigits_ValueChanged)
			' 
			' PtsDispensingSettingsDialog
			' 
			Me.AcceptButton = Me.btnOk
			Me.AutoScaleDimensions = New SizeF(6F, 13F)
			Me.AutoScaleMode = AutoScaleMode.Font
			Me.AutoValidate = AutoValidate.EnablePreventFocusChange
			Me.CancelButton = Me.btnCancel
			Me.ClientSize = New Size(568, 314)
			Me.Controls.Add(Me.groupBox3)
			Me.Controls.Add(Me.groupBox2)
			Me.Controls.Add(Me.groupBox1)
			Me.Controls.Add(Me.groupBoxCommands)
			Me.Controls.Add(Me.groupBoxAuthPolling)
			Me.Controls.Add(Me.btnCancel)
			Me.Controls.Add(Me.btnOk)
			Me.Controls.Add(Me.groupBoxAuthorizationType)
			Me.FormBorderStyle = FormBorderStyle.FixedSingle
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "PtsDispensingSettingsDialog"
			Me.StartPosition = FormStartPosition.CenterParent
			Me.Text = "Settings"
'			Me.Load += New System.EventHandler(Me.DispensingSettingsDialog_Load)
			Me.groupBoxAuthorizationType.ResumeLayout(False)
			Me.groupBoxAuthorizationType.PerformLayout()
			Me.groupBoxAuthPolling.ResumeLayout(False)
			Me.groupBoxAuthPolling.PerformLayout()
			Me.groupBoxCommands.ResumeLayout(False)
			Me.groupBoxCommands.PerformLayout()
			Me.groupBox1.ResumeLayout(False)
			Me.groupBox1.PerformLayout()
			CType(Me.udManualModeAuthorizeValue, System.ComponentModel.ISupportInitialize).EndInit()
			Me.groupBox2.ResumeLayout(False)
			Me.groupBox2.PerformLayout()
			Me.groupBox3.ResumeLayout(False)
			Me.groupBox3.PerformLayout()
			CType(Me.udVolumeCounterDigits, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.udAmountCounterDigits, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.udPriceDigits, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.udVolumeDigits, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.udAmountDigits, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private WithEvents radioButtonAuthorizationVolume As RadioButton
		Private WithEvents radioButtonAuthorizationAmount As RadioButton
		Private groupBoxAuthorizationType As GroupBox
		Private WithEvents btnOk As Button
		Private btnCancel As Button
		Private groupBoxAuthPolling As GroupBox
		Private WithEvents rdbPollingOff As RadioButton
		Private WithEvents rdbPollingOn As RadioButton
		Private groupBoxCommands As GroupBox
		Private WithEvents rdbExtendedCommands As RadioButton
		Private WithEvents rdbGeneralCommands As RadioButton
		Private groupBox1 As GroupBox
		Private WithEvents radioButtonManualAuthorize As RadioButton
		Private WithEvents radioButtonAutomaticAuthorize As RadioButton
		Private groupBox2 As GroupBox
		Private WithEvents radioButtonNotRequestTotals As RadioButton
		Private WithEvents radioButtonRequestTotals As RadioButton
		Private label1 As Label
		Private udManualModeAuthorizeValue As NumericUpDown
		Private groupBox3 As GroupBox
		Private label6 As Label
		Private udVolumeCounterDigits As NumericUpDown
		Private label5 As Label
		Private udAmountCounterDigits As NumericUpDown
		Private label4 As Label
		Private udPriceDigits As NumericUpDown
		Private label3 As Label
		Private WithEvents udVolumeDigits As NumericUpDown
		Private label2 As Label
		Private WithEvents udAmountDigits As NumericUpDown
		'private System.Windows.Forms.GroupBox groupBoxDisplayedValues;
		'private System.Windows.Forms.Label labelQuantityVolume;
		'private System.Windows.Forms.NumericUpDown quantityVolumeUpDown;
		'private System.Windows.Forms.Label labelQuantityAmount;
		'private System.Windows.Forms.NumericUpDown quantityAmountUpDown;
	End Class
End Namespace
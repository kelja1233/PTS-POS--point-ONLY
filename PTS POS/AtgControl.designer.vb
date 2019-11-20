Namespace TiT.PTS
	Partial Public Class AtgControl
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

		#Region "Код, автоматически созданный конструктором компонентов"

		''' <summary> 
		''' Обязательный метод для поддержки конструктора - не изменяйте 
		''' содержимое данного метода при помощи редактора кода.
		''' </summary>
		Private Sub InitializeComponent()
			Me.tableLayoutPanel = New TableLayoutPanel()
			Me.lblRow8Col3 = New Label()
			Me.lblRow9Col3 = New Label()
			Me.lblRow6Col3 = New Label()
			Me.lblRow5Col3 = New Label()
			Me.lblRow9Col1 = New Label()
			Me.lblRow4Col1 = New Label()
			Me.lblRow6Col1 = New Label()
			Me.lblRow5Col1 = New Label()
			Me.lblRow4Col3 = New Label()
			Me.lblRow7Col1 = New Label()
			Me.lblRow3Col3 = New Label()
			Me.lblRow2Col3 = New Label()
			Me.lblRow2Col1 = New Label()
			Me.lblRow1Col3 = New Label()
			Me.lblRow1Col1 = New Label()
			Me.lblRow8Col1 = New Label()
			Me.lblRow3Col1 = New Label()
			Me.lblRow7Col3 = New Label()
			Me.lblRow1Col2 = New Label()
			Me.lblRow2Col2 = New Label()
			Me.lblRow3Col2 = New Label()
			Me.lblRow9Col2 = New Label()
			Me.lblRow8Col2 = New Label()
			Me.lblRow7Col2 = New Label()
			Me.lblRow6Col2 = New Label()
			Me.lblRow5Col2 = New Label()
			Me.lblRow4Col2 = New Label()
			Me.panelPumpID = New Panel()
			Me.atgAddressLabel = New Label()
			Me.panelStatusLabel = New Panel()
			Me.statusLabel = New Label()
			Me.settingsButton = New Button()
			Me.lblTankHeightTop = New Label()
			Me.lblTankHeight = New Label()
			Me.tankControl1 = New TiT.PTS.TankControl()
			Me.tableLayoutPanel.SuspendLayout()
			Me.panelPumpID.SuspendLayout()
			Me.panelStatusLabel.SuspendLayout()
			Me.SuspendLayout()
			' 
			' tableLayoutPanel
			' 
			Me.tableLayoutPanel.ColumnCount = 3
			Me.tableLayoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.92593F))
			Me.tableLayoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 30.55556F))
			Me.tableLayoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 18.51852F))
			Me.tableLayoutPanel.Controls.Add(Me.lblRow8Col3, 2, 7)
			Me.tableLayoutPanel.Controls.Add(Me.lblRow9Col3, 2, 8)
			Me.tableLayoutPanel.Controls.Add(Me.lblRow6Col3, 2, 5)
			Me.tableLayoutPanel.Controls.Add(Me.lblRow5Col3, 2, 4)
			Me.tableLayoutPanel.Controls.Add(Me.lblRow9Col1, 0, 8)
			Me.tableLayoutPanel.Controls.Add(Me.lblRow4Col1, 0, 3)
			Me.tableLayoutPanel.Controls.Add(Me.lblRow6Col1, 0, 5)
			Me.tableLayoutPanel.Controls.Add(Me.lblRow5Col1, 0, 4)
			Me.tableLayoutPanel.Controls.Add(Me.lblRow4Col3, 2, 3)
			Me.tableLayoutPanel.Controls.Add(Me.lblRow7Col1, 0, 6)
			Me.tableLayoutPanel.Controls.Add(Me.lblRow3Col3, 2, 2)
			Me.tableLayoutPanel.Controls.Add(Me.lblRow2Col3, 2, 1)
			Me.tableLayoutPanel.Controls.Add(Me.lblRow2Col1, 0, 1)
			Me.tableLayoutPanel.Controls.Add(Me.lblRow1Col3, 2, 0)
			Me.tableLayoutPanel.Controls.Add(Me.lblRow1Col1, 0, 0)
			Me.tableLayoutPanel.Controls.Add(Me.lblRow8Col1, 0, 7)
			Me.tableLayoutPanel.Controls.Add(Me.lblRow3Col1, 0, 2)
			Me.tableLayoutPanel.Controls.Add(Me.lblRow7Col3, 2, 6)
			Me.tableLayoutPanel.Controls.Add(Me.lblRow1Col2, 1, 0)
			Me.tableLayoutPanel.Controls.Add(Me.lblRow2Col2, 1, 1)
			Me.tableLayoutPanel.Controls.Add(Me.lblRow3Col2, 1, 2)
			Me.tableLayoutPanel.Controls.Add(Me.lblRow9Col2, 1, 8)
			Me.tableLayoutPanel.Controls.Add(Me.lblRow8Col2, 1, 7)
			Me.tableLayoutPanel.Controls.Add(Me.lblRow7Col2, 1, 6)
			Me.tableLayoutPanel.Controls.Add(Me.lblRow6Col2, 1, 5)
			Me.tableLayoutPanel.Controls.Add(Me.lblRow5Col2, 1, 4)
			Me.tableLayoutPanel.Controls.Add(Me.lblRow4Col2, 1, 3)
			Me.tableLayoutPanel.Location = New Point(167, 36)
			Me.tableLayoutPanel.Name = "tableLayoutPanel"
			Me.tableLayoutPanel.RowCount = 9
			Me.tableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 10.52635F))
			Me.tableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 10.52635F))
			Me.tableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 15.78921F))
			Me.tableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 10.52635F))
			Me.tableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 10.52635F))
			Me.tableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 10.52635F))
			Me.tableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 10.52635F))
			Me.tableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 10.52635F))
			Me.tableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 10.52635F))
			Me.tableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
			Me.tableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
			Me.tableLayoutPanel.Size = New Size(268, 227)
			Me.tableLayoutPanel.TabIndex = 0
			' 
			' lblRow8Col3
			' 
			Me.lblRow8Col3.AutoSize = True
			Me.lblRow8Col3.Dock = DockStyle.Fill
			Me.lblRow8Col3.ForeColor = Color.LightGray
			Me.lblRow8Col3.Location = New Point(220, 173)
			Me.lblRow8Col3.Name = "lblRow8Col3"
			Me.lblRow8Col3.Size = New Size(45, 23)
			Me.lblRow8Col3.TabIndex = 24
			Me.lblRow8Col3.Text = "kg/m3"
			' 
			' lblRow9Col3
			' 
			Me.lblRow9Col3.AutoSize = True
			Me.lblRow9Col3.Dock = DockStyle.Fill
			Me.lblRow9Col3.ForeColor = Color.LightGray
			Me.lblRow9Col3.Location = New Point(220, 196)
			Me.lblRow9Col3.Name = "lblRow9Col3"
			Me.lblRow9Col3.Size = New Size(45, 31)
			Me.lblRow9Col3.TabIndex = 25
			Me.lblRow9Col3.Text = "kg"
			' 
			' lblRow6Col3
			' 
			Me.lblRow6Col3.AutoSize = True
			Me.lblRow6Col3.Dock = DockStyle.Fill
			Me.lblRow6Col3.ForeColor = Color.LightGray
			Me.lblRow6Col3.Location = New Point(220, 127)
			Me.lblRow6Col3.Name = "lblRow6Col3"
			Me.lblRow6Col3.Size = New Size(45, 23)
			Me.lblRow6Col3.TabIndex = 24
			Me.lblRow6Col3.Text = "l"
			' 
			' lblRow5Col3
			' 
			Me.lblRow5Col3.AutoSize = True
			Me.lblRow5Col3.Dock = DockStyle.Fill
			Me.lblRow5Col3.ForeColor = Color.LightGray
			Me.lblRow5Col3.Location = New Point(220, 104)
			Me.lblRow5Col3.Name = "lblRow5Col3"
			Me.lblRow5Col3.Size = New Size(45, 23)
			Me.lblRow5Col3.TabIndex = 24
			Me.lblRow5Col3.Text = "mm"
			' 
			' lblRow9Col1
			' 
			Me.lblRow9Col1.AutoSize = True
			Me.lblRow9Col1.Dock = DockStyle.Fill
			Me.lblRow9Col1.ForeColor = Color.LightGray
			Me.lblRow9Col1.Location = New Point(3, 196)
			Me.lblRow9Col1.Name = "lblRow9Col1"
			Me.lblRow9Col1.Size = New Size(130, 31)
			Me.lblRow9Col1.TabIndex = 20
			Me.lblRow9Col1.Text = "Product mass:"
			' 
			' lblRow4Col1
			' 
			Me.lblRow4Col1.AutoSize = True
			Me.lblRow4Col1.Dock = DockStyle.Fill
			Me.lblRow4Col1.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			Me.lblRow4Col1.ForeColor = Color.LightGray
			Me.lblRow4Col1.Location = New Point(3, 81)
			Me.lblRow4Col1.Name = "lblRow4Col1"
			Me.lblRow4Col1.Size = New Size(130, 23)
			Me.lblRow4Col1.TabIndex = 17
			Me.lblRow4Col1.Text = "Product ullage:"
			' 
			' lblRow6Col1
			' 
			Me.lblRow6Col1.AutoSize = True
			Me.lblRow6Col1.Dock = DockStyle.Fill
			Me.lblRow6Col1.ForeColor = Color.LightGray
			Me.lblRow6Col1.Location = New Point(3, 127)
			Me.lblRow6Col1.Name = "lblRow6Col1"
			Me.lblRow6Col1.Size = New Size(130, 23)
			Me.lblRow6Col1.TabIndex = 24
			Me.lblRow6Col1.Text = "Water volume:"
			' 
			' lblRow5Col1
			' 
			Me.lblRow5Col1.AutoSize = True
			Me.lblRow5Col1.Dock = DockStyle.Fill
			Me.lblRow5Col1.ForeColor = Color.LightGray
			Me.lblRow5Col1.Location = New Point(3, 104)
			Me.lblRow5Col1.Name = "lblRow5Col1"
			Me.lblRow5Col1.Size = New Size(130, 23)
			Me.lblRow5Col1.TabIndex = 21
			Me.lblRow5Col1.Text = "Water height:"
			' 
			' lblRow4Col3
			' 
			Me.lblRow4Col3.AutoSize = True
			Me.lblRow4Col3.Dock = DockStyle.Fill
			Me.lblRow4Col3.ForeColor = Color.LightGray
			Me.lblRow4Col3.Location = New Point(220, 81)
			Me.lblRow4Col3.Name = "lblRow4Col3"
			Me.lblRow4Col3.Size = New Size(45, 23)
			Me.lblRow4Col3.TabIndex = 11
			Me.lblRow4Col3.Text = "l"
			' 
			' lblRow7Col1
			' 
			Me.lblRow7Col1.AutoSize = True
			Me.lblRow7Col1.Dock = DockStyle.Fill
			Me.lblRow7Col1.ForeColor = Color.LightGray
			Me.lblRow7Col1.Location = New Point(3, 150)
			Me.lblRow7Col1.Name = "lblRow7Col1"
			Me.lblRow7Col1.Size = New Size(130, 23)
			Me.lblRow7Col1.TabIndex = 14
			Me.lblRow7Col1.Text = "Temperature:"
			' 
			' lblRow3Col3
			' 
			Me.lblRow3Col3.AutoSize = True
			Me.lblRow3Col3.Dock = DockStyle.Fill
			Me.lblRow3Col3.ForeColor = Color.LightGray
			Me.lblRow3Col3.Location = New Point(220, 46)
			Me.lblRow3Col3.Name = "lblRow3Col3"
			Me.lblRow3Col3.Size = New Size(45, 35)
			Me.lblRow3Col3.TabIndex = 8
			Me.lblRow3Col3.Text = "l"
			' 
			' lblRow2Col3
			' 
			Me.lblRow2Col3.AutoSize = True
			Me.lblRow2Col3.Dock = DockStyle.Fill
			Me.lblRow2Col3.ForeColor = Color.LightGray
			Me.lblRow2Col3.Location = New Point(220, 23)
			Me.lblRow2Col3.Name = "lblRow2Col3"
			Me.lblRow2Col3.Size = New Size(45, 23)
			Me.lblRow2Col3.TabIndex = 5
			Me.lblRow2Col3.Text = "l"
			' 
			' lblRow2Col1
			' 
			Me.lblRow2Col1.AutoSize = True
			Me.lblRow2Col1.Dock = DockStyle.Fill
			Me.lblRow2Col1.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			Me.lblRow2Col1.ForeColor = Color.LightGray
			Me.lblRow2Col1.Location = New Point(3, 23)
			Me.lblRow2Col1.Name = "lblRow2Col1"
			Me.lblRow2Col1.Size = New Size(130, 23)
			Me.lblRow2Col1.TabIndex = 3
			Me.lblRow2Col1.Text = "Product volume:"
			' 
			' lblRow1Col3
			' 
			Me.lblRow1Col3.AutoSize = True
			Me.lblRow1Col3.Dock = DockStyle.Fill
			Me.lblRow1Col3.ForeColor = Color.LightGray
			Me.lblRow1Col3.Location = New Point(220, 0)
			Me.lblRow1Col3.Name = "lblRow1Col3"
			Me.lblRow1Col3.Size = New Size(45, 23)
			Me.lblRow1Col3.TabIndex = 2
			Me.lblRow1Col3.Text = "mm"
			' 
			' lblRow1Col1
			' 
			Me.lblRow1Col1.AutoSize = True
			Me.lblRow1Col1.Dock = DockStyle.Fill
			Me.lblRow1Col1.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			Me.lblRow1Col1.ForeColor = Color.LightGray
			Me.lblRow1Col1.Location = New Point(3, 0)
			Me.lblRow1Col1.Name = "lblRow1Col1"
			Me.lblRow1Col1.Size = New Size(130, 23)
			Me.lblRow1Col1.TabIndex = 0
			Me.lblRow1Col1.Text = "Product height:"
			' 
			' lblRow8Col1
			' 
			Me.lblRow8Col1.AutoSize = True
			Me.lblRow8Col1.Dock = DockStyle.Fill
			Me.lblRow8Col1.ForeColor = Color.LightGray
			Me.lblRow8Col1.Location = New Point(3, 173)
			Me.lblRow8Col1.Name = "lblRow8Col1"
			Me.lblRow8Col1.Size = New Size(130, 23)
			Me.lblRow8Col1.TabIndex = 19
			Me.lblRow8Col1.Text = "Product density:"
			' 
			' lblRow3Col1
			' 
			Me.lblRow3Col1.AutoSize = True
			Me.lblRow3Col1.Dock = DockStyle.Fill
			Me.lblRow3Col1.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			Me.lblRow3Col1.ForeColor = Color.LightGray
			Me.lblRow3Col1.Location = New Point(3, 46)
			Me.lblRow3Col1.Name = "lblRow3Col1"
			Me.lblRow3Col1.Size = New Size(130, 35)
			Me.lblRow3Col1.TabIndex = 18
			Me.lblRow3Col1.Text = "Product temperature compensated volume:"
			' 
			' lblRow7Col3
			' 
			Me.lblRow7Col3.AutoSize = True
			Me.lblRow7Col3.Dock = DockStyle.Fill
			Me.lblRow7Col3.ForeColor = Color.LightGray
			Me.lblRow7Col3.Location = New Point(220, 150)
			Me.lblRow7Col3.Name = "lblRow7Col3"
			Me.lblRow7Col3.Size = New Size(45, 23)
			Me.lblRow7Col3.TabIndex = 16
			Me.lblRow7Col3.Text = "deg. C"
			' 
			' lblRow1Col2
			' 
			Me.lblRow1Col2.AutoSize = True
			Me.lblRow1Col2.Dock = DockStyle.Right
			Me.lblRow1Col2.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.lblRow1Col2.ForeColor = Color.LightGray
			Me.lblRow1Col2.Location = New Point(203, 0)
			Me.lblRow1Col2.Name = "lblRow1Col2"
			Me.lblRow1Col2.Size = New Size(11, 23)
			Me.lblRow1Col2.TabIndex = 28
			Me.lblRow1Col2.Text = "-"
			' 
			' lblRow2Col2
			' 
			Me.lblRow2Col2.AutoSize = True
			Me.lblRow2Col2.Dock = DockStyle.Right
			Me.lblRow2Col2.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.lblRow2Col2.ForeColor = Color.LightGray
			Me.lblRow2Col2.Location = New Point(203, 23)
			Me.lblRow2Col2.Name = "lblRow2Col2"
			Me.lblRow2Col2.Size = New Size(11, 23)
			Me.lblRow2Col2.TabIndex = 27
			Me.lblRow2Col2.Text = "-"
			' 
			' lblRow3Col2
			' 
			Me.lblRow3Col2.AutoSize = True
			Me.lblRow3Col2.Dock = DockStyle.Right
			Me.lblRow3Col2.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.lblRow3Col2.ForeColor = Color.LightGray
			Me.lblRow3Col2.Location = New Point(203, 46)
			Me.lblRow3Col2.Name = "lblRow3Col2"
			Me.lblRow3Col2.Size = New Size(11, 35)
			Me.lblRow3Col2.TabIndex = 26
			Me.lblRow3Col2.Text = "-"
			' 
			' lblRow9Col2
			' 
			Me.lblRow9Col2.AutoSize = True
			Me.lblRow9Col2.Dock = DockStyle.Right
			Me.lblRow9Col2.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.lblRow9Col2.ForeColor = Color.LightGray
			Me.lblRow9Col2.Location = New Point(203, 196)
			Me.lblRow9Col2.Name = "lblRow9Col2"
			Me.lblRow9Col2.Size = New Size(11, 31)
			Me.lblRow9Col2.TabIndex = 25
			Me.lblRow9Col2.Text = "-"
			' 
			' lblRow8Col2
			' 
			Me.lblRow8Col2.AutoSize = True
			Me.lblRow8Col2.Dock = DockStyle.Right
			Me.lblRow8Col2.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.lblRow8Col2.ForeColor = Color.LightGray
			Me.lblRow8Col2.Location = New Point(203, 173)
			Me.lblRow8Col2.Name = "lblRow8Col2"
			Me.lblRow8Col2.Size = New Size(11, 23)
			Me.lblRow8Col2.TabIndex = 29
			Me.lblRow8Col2.Text = "-"
			' 
			' lblRow7Col2
			' 
			Me.lblRow7Col2.AutoSize = True
			Me.lblRow7Col2.Dock = DockStyle.Right
			Me.lblRow7Col2.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.lblRow7Col2.ForeColor = Color.LightGray
			Me.lblRow7Col2.Location = New Point(203, 150)
			Me.lblRow7Col2.Name = "lblRow7Col2"
			Me.lblRow7Col2.Size = New Size(11, 23)
			Me.lblRow7Col2.TabIndex = 30
			Me.lblRow7Col2.Text = "-"
			' 
			' lblRow6Col2
			' 
			Me.lblRow6Col2.AutoSize = True
			Me.lblRow6Col2.Dock = DockStyle.Right
			Me.lblRow6Col2.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.lblRow6Col2.ForeColor = Color.LightGray
			Me.lblRow6Col2.Location = New Point(203, 127)
			Me.lblRow6Col2.Name = "lblRow6Col2"
			Me.lblRow6Col2.Size = New Size(11, 23)
			Me.lblRow6Col2.TabIndex = 31
			Me.lblRow6Col2.Text = "-"
			' 
			' lblRow5Col2
			' 
			Me.lblRow5Col2.AutoSize = True
			Me.lblRow5Col2.Dock = DockStyle.Right
			Me.lblRow5Col2.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.lblRow5Col2.ForeColor = Color.LightGray
			Me.lblRow5Col2.Location = New Point(203, 104)
			Me.lblRow5Col2.Name = "lblRow5Col2"
			Me.lblRow5Col2.Size = New Size(11, 23)
			Me.lblRow5Col2.TabIndex = 32
			Me.lblRow5Col2.Text = "-"
			' 
			' lblRow4Col2
			' 
			Me.lblRow4Col2.AutoSize = True
			Me.lblRow4Col2.Dock = DockStyle.Right
			Me.lblRow4Col2.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.lblRow4Col2.ForeColor = Color.LightGray
			Me.lblRow4Col2.Location = New Point(203, 81)
			Me.lblRow4Col2.Name = "lblRow4Col2"
			Me.lblRow4Col2.Size = New Size(11, 23)
			Me.lblRow4Col2.TabIndex = 33
			Me.lblRow4Col2.Text = "-"
			' 
			' panelPumpID
			' 
			Me.panelPumpID.BackColor = SystemColors.GradientActiveCaption
			Me.panelPumpID.Controls.Add(Me.atgAddressLabel)
			Me.panelPumpID.Location = New Point(0, 0)
			Me.panelPumpID.Name = "panelPumpID"
			Me.panelPumpID.Size = New Size(40, 30)
			Me.panelPumpID.TabIndex = 21
			' 
			' atgAddressLabel
			' 
			Me.atgAddressLabel.BackColor = Color.Transparent
			Me.atgAddressLabel.Dock = DockStyle.Fill
			Me.atgAddressLabel.FlatStyle = FlatStyle.Popup
			Me.atgAddressLabel.Font = New Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.atgAddressLabel.ForeColor = SystemColors.ActiveCaptionText
			Me.atgAddressLabel.Location = New Point(0, 0)
			Me.atgAddressLabel.Name = "atgAddressLabel"
			Me.atgAddressLabel.Size = New Size(40, 30)
			Me.atgAddressLabel.TabIndex = 10
			Me.atgAddressLabel.Text = "-"
			Me.atgAddressLabel.TextAlign = ContentAlignment.MiddleCenter
			' 
			' panelStatusLabel
			' 
			Me.panelStatusLabel.BackColor = Color.LightGray
			Me.panelStatusLabel.Controls.Add(Me.statusLabel)
			Me.panelStatusLabel.Location = New Point(40, 0)
			Me.panelStatusLabel.Name = "panelStatusLabel"
			Me.panelStatusLabel.Size = New Size(462, 30)
			Me.panelStatusLabel.TabIndex = 22
			' 
			' statusLabel
			' 
			Me.statusLabel.Dock = DockStyle.Fill
			Me.statusLabel.Font = New Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			Me.statusLabel.Location = New Point(0, 0)
			Me.statusLabel.Name = "statusLabel"
			Me.statusLabel.Size = New Size(462, 30)
			Me.statusLabel.TabIndex = 5
			Me.statusLabel.Text = "NOT ACTIVE"
			Me.statusLabel.TextAlign = ContentAlignment.MiddleCenter
			' 
			' settingsButton
			' 
			Me.settingsButton.Enabled = False
			Me.settingsButton.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.settingsButton.Location = New Point(167, 257)
			Me.settingsButton.Margin = New Padding(0)
			Me.settingsButton.Name = "settingsButton"
			Me.settingsButton.Size = New Size(268, 28)
			Me.settingsButton.TabIndex = 23
			Me.settingsButton.Text = "Configure ATG"
			Me.settingsButton.UseVisualStyleBackColor = True
'			Me.settingsButton.Click += New System.EventHandler(Me.settingsButton_Click)
			' 
			' lblTankHeightTop
			' 
			Me.lblTankHeightTop.AutoSize = True
			Me.lblTankHeightTop.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.lblTankHeightTop.Location = New Point(28, 259)
			Me.lblTankHeightTop.Name = "lblTankHeightTop"
			Me.lblTankHeightTop.Size = New Size(75, 13)
			Me.lblTankHeightTop.TabIndex = 25
			Me.lblTankHeightTop.Text = "Tank height"
			Me.lblTankHeightTop.TextAlign = ContentAlignment.MiddleCenter
			' 
			' lblTankHeight
			' 
			Me.lblTankHeight.AutoSize = True
			Me.lblTankHeight.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.lblTankHeight.Location = New Point(52, 275)
			Me.lblTankHeight.Name = "lblTankHeight"
			Me.lblTankHeight.Size = New Size(25, 13)
			Me.lblTankHeight.TabIndex = 26
			Me.lblTankHeight.Text = "mm"
			Me.lblTankHeight.TextAlign = ContentAlignment.MiddleCenter
			' 
			' tankControl1
			' 
			Me.tankControl1.BackColor = Color.MintCream
			Me.tankControl1.BackgroundImageLayout = ImageLayout.Stretch
			Me.tankControl1.CritHighValue = 95
			Me.tankControl1.CritLowValue = 5
			Me.tankControl1.HighValue = 90
			Me.tankControl1.Location = New Point(4, 36)
			Me.tankControl1.LowValue = 10
			Me.tankControl1.MaxValue = 0R
			Me.tankControl1.Name = "tankControl1"
			Me.tankControl1.Size = New Size(173, 227)
			Me.tankControl1.TabIndex = 24
			' 
			' AtgControl
			' 
			Me.AutoScaleDimensions = New SizeF(6F, 13F)
			Me.AutoScaleMode = AutoScaleMode.Font
			Me.BackColor = Color.MintCream
			Me.Controls.Add(Me.lblTankHeight)
			Me.Controls.Add(Me.lblTankHeightTop)
			Me.Controls.Add(Me.settingsButton)
			Me.Controls.Add(Me.tableLayoutPanel)
			Me.Controls.Add(Me.tankControl1)
			Me.Controls.Add(Me.panelStatusLabel)
			Me.Controls.Add(Me.panelPumpID)
			Me.Name = "AtgControl"
			Me.Size = New Size(448, 294)
'			Me.Load += New System.EventHandler(Me.AtgControl_Load)
			Me.tableLayoutPanel.ResumeLayout(False)
			Me.tableLayoutPanel.PerformLayout()
			Me.panelPumpID.ResumeLayout(False)
			Me.panelStatusLabel.ResumeLayout(False)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private tableLayoutPanel As TableLayoutPanel
		Private lblRow4Col3 As Label
		Private lblRow3Col3 As Label
		Private lblRow2Col3 As Label
		Private lblRow1Col3 As Label
		Private lblRow7Col1 As Label
		Private lblRow7Col3 As Label
		Private panelPumpID As Panel
		Private atgAddressLabel As Label
		Private lblRow4Col1 As Label
		Private lblRow2Col1 As Label
		Private lblRow1Col1 As Label
		Private lblRow3Col1 As Label
		Private lblRow8Col1 As Label
		Private panelStatusLabel As Panel
		Private statusLabel As Label
		Private WithEvents settingsButton As Button
		Private lblRow9Col1 As Label
		Private lblRow6Col1 As Label
		Private lblRow5Col1 As Label
		Private lblRow8Col3 As Label
		Private lblRow9Col3 As Label
		Private lblRow6Col3 As Label
		Private lblRow5Col3 As Label
		Private lblRow1Col2 As Label
		Private lblRow2Col2 As Label
		Private lblRow3Col2 As Label
		Private lblRow9Col2 As Label
		Private lblRow8Col2 As Label
		Private lblRow7Col2 As Label
		Private lblRow6Col2 As Label
		Private lblRow5Col2 As Label
		Private lblRow4Col2 As Label
		Private tankControl1 As TankControl
		Private lblTankHeightTop As Label
		Private lblTankHeight As Label
	End Class
End Namespace

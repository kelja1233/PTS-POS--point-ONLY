Namespace TiT.PTS
	Partial Public Class TotalsDialog
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
			Me.components = New System.ComponentModel.Container()
			Me.okButton = New Button()
			Me.tableLayoutPanel = New TableLayoutPanel()
			Me.label5 = New Label()
			Me.amountLabel4 = New Label()
			Me.label13 = New Label()
			Me.volumeLabel3 = New Label()
			Me.amountLabel3 = New Label()
			Me.label10 = New Label()
			Me.volumeLabel2 = New Label()
			Me.amountLabel2 = New Label()
			Me.label7 = New Label()
			Me.volumeLabel1 = New Label()
			Me.amountLabel1 = New Label()
			Me.label4 = New Label()
			Me.label2 = New Label()
			Me.volumeLabel4 = New Label()
			Me.amountLabel5 = New Label()
			Me.amountLabel6 = New Label()
			Me.volumeLabel5 = New Label()
			Me.volumeLabel6 = New Label()
			Me.label3 = New Label()
			Me.label1 = New Label()
			Me.updateTotalsButton = New Button()
			Me.updateLabel = New Label()
			Me.timer1 = New Timer(Me.components)
			Me.udNozzlesQuantity = New NumericUpDown()
			Me.label6 = New Label()
			Me.pbTotalsRequest = New PictureBox()
			Me.tableLayoutPanel.SuspendLayout()
			CType(Me.udNozzlesQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.pbTotalsRequest, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' okButton
			' 
			Me.okButton.Anchor = (CType((AnchorStyles.Bottom Or AnchorStyles.Right), AnchorStyles))
			Me.okButton.DialogResult = DialogResult.OK
			Me.okButton.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.okButton.Location = New Point(205, 234)
			Me.okButton.Name = "okButton"
			Me.okButton.Size = New Size(75, 23)
			Me.okButton.TabIndex = 0
			Me.okButton.Text = "Close"
			Me.okButton.UseVisualStyleBackColor = True
'			Me.okButton.Click += New System.EventHandler(Me.okButton_Click)
			' 
			' tableLayoutPanel
			' 
			Me.tableLayoutPanel.AutoSize = True
			Me.tableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
			Me.tableLayoutPanel.ColumnCount = 3
			Me.tableLayoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.33333F))
			Me.tableLayoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.33334F))
			Me.tableLayoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.33334F))
			Me.tableLayoutPanel.Controls.Add(Me.label5, 0, 6)
			Me.tableLayoutPanel.Controls.Add(Me.amountLabel4, 1, 4)
			Me.tableLayoutPanel.Controls.Add(Me.label13, 0, 4)
			Me.tableLayoutPanel.Controls.Add(Me.volumeLabel3, 2, 3)
			Me.tableLayoutPanel.Controls.Add(Me.amountLabel3, 1, 3)
			Me.tableLayoutPanel.Controls.Add(Me.label10, 0, 3)
			Me.tableLayoutPanel.Controls.Add(Me.volumeLabel2, 2, 2)
			Me.tableLayoutPanel.Controls.Add(Me.amountLabel2, 1, 2)
			Me.tableLayoutPanel.Controls.Add(Me.label7, 0, 2)
			Me.tableLayoutPanel.Controls.Add(Me.volumeLabel1, 2, 1)
			Me.tableLayoutPanel.Controls.Add(Me.amountLabel1, 1, 1)
			Me.tableLayoutPanel.Controls.Add(Me.label4, 0, 1)
			Me.tableLayoutPanel.Controls.Add(Me.label2, 2, 0)
			Me.tableLayoutPanel.Controls.Add(Me.volumeLabel4, 2, 4)
			Me.tableLayoutPanel.Controls.Add(Me.amountLabel5, 1, 5)
			Me.tableLayoutPanel.Controls.Add(Me.amountLabel6, 1, 6)
			Me.tableLayoutPanel.Controls.Add(Me.volumeLabel5, 2, 5)
			Me.tableLayoutPanel.Controls.Add(Me.volumeLabel6, 2, 6)
			Me.tableLayoutPanel.Controls.Add(Me.label3, 0, 5)
			Me.tableLayoutPanel.Controls.Add(Me.label1, 1, 0)
			Me.tableLayoutPanel.Dock = DockStyle.Top
			Me.tableLayoutPanel.Location = New Point(0, 0)
			Me.tableLayoutPanel.Name = "tableLayoutPanel"
			Me.tableLayoutPanel.RowCount = 7
			Me.tableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Absolute, 25F))
			Me.tableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
			Me.tableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
			Me.tableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
			Me.tableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
			Me.tableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
			Me.tableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
			Me.tableLayoutPanel.Size = New Size(292, 165)
			Me.tableLayoutPanel.TabIndex = 1
			' 
			' label5
			' 
			Me.label5.Anchor = AnchorStyles.None
			Me.label5.AutoSize = True
			Me.label5.Font = New Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.label5.Location = New Point(13, 144)
			Me.label5.Name = "label5"
			Me.label5.Size = New Size(71, 17)
			Me.label5.TabIndex = 19
			Me.label5.Text = "Nozzle 6"
			' 
			' amountLabel4
			' 
			Me.amountLabel4.Anchor = AnchorStyles.None
			Me.amountLabel4.AutoSize = True
			Me.amountLabel4.Font = New Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.amountLabel4.Location = New Point(136, 98)
			Me.amountLabel4.Name = "amountLabel4"
			Me.amountLabel4.Size = New Size(17, 17)
			Me.amountLabel4.TabIndex = 13
			Me.amountLabel4.Text = "0"
			' 
			' label13
			' 
			Me.label13.Anchor = AnchorStyles.None
			Me.label13.AutoSize = True
			Me.label13.Font = New Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.label13.Location = New Point(13, 98)
			Me.label13.Name = "label13"
			Me.label13.Size = New Size(71, 17)
			Me.label13.TabIndex = 12
			Me.label13.Text = "Nozzle 4"
			' 
			' volumeLabel3
			' 
			Me.volumeLabel3.Anchor = AnchorStyles.None
			Me.volumeLabel3.AutoSize = True
			Me.volumeLabel3.Font = New Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.volumeLabel3.Location = New Point(234, 75)
			Me.volumeLabel3.Name = "volumeLabel3"
			Me.volumeLabel3.Size = New Size(17, 17)
			Me.volumeLabel3.TabIndex = 11
			Me.volumeLabel3.Text = "0"
			' 
			' amountLabel3
			' 
			Me.amountLabel3.Anchor = AnchorStyles.None
			Me.amountLabel3.AutoSize = True
			Me.amountLabel3.Font = New Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.amountLabel3.Location = New Point(136, 75)
			Me.amountLabel3.Name = "amountLabel3"
			Me.amountLabel3.Size = New Size(17, 17)
			Me.amountLabel3.TabIndex = 10
			Me.amountLabel3.Text = "0"
			' 
			' label10
			' 
			Me.label10.Anchor = AnchorStyles.None
			Me.label10.AutoSize = True
			Me.label10.Font = New Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.label10.Location = New Point(13, 75)
			Me.label10.Name = "label10"
			Me.label10.Size = New Size(71, 17)
			Me.label10.TabIndex = 9
			Me.label10.Text = "Nozzle 3"
			' 
			' volumeLabel2
			' 
			Me.volumeLabel2.Anchor = AnchorStyles.None
			Me.volumeLabel2.AutoSize = True
			Me.volumeLabel2.Font = New Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.volumeLabel2.Location = New Point(234, 52)
			Me.volumeLabel2.Name = "volumeLabel2"
			Me.volumeLabel2.Size = New Size(17, 17)
			Me.volumeLabel2.TabIndex = 8
			Me.volumeLabel2.Text = "0"
			' 
			' amountLabel2
			' 
			Me.amountLabel2.Anchor = AnchorStyles.None
			Me.amountLabel2.AutoSize = True
			Me.amountLabel2.Font = New Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.amountLabel2.Location = New Point(136, 52)
			Me.amountLabel2.Name = "amountLabel2"
			Me.amountLabel2.Size = New Size(17, 17)
			Me.amountLabel2.TabIndex = 7
			Me.amountLabel2.Text = "0"
			' 
			' label7
			' 
			Me.label7.Anchor = AnchorStyles.None
			Me.label7.AutoSize = True
			Me.label7.Font = New Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.label7.Location = New Point(13, 52)
			Me.label7.Name = "label7"
			Me.label7.Size = New Size(71, 17)
			Me.label7.TabIndex = 6
			Me.label7.Text = "Nozzle 2"
			' 
			' volumeLabel1
			' 
			Me.volumeLabel1.Anchor = AnchorStyles.None
			Me.volumeLabel1.AutoSize = True
			Me.volumeLabel1.Font = New Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.volumeLabel1.Location = New Point(234, 29)
			Me.volumeLabel1.Name = "volumeLabel1"
			Me.volumeLabel1.Size = New Size(17, 17)
			Me.volumeLabel1.TabIndex = 5
			Me.volumeLabel1.Text = "0"
			' 
			' amountLabel1
			' 
			Me.amountLabel1.Anchor = AnchorStyles.None
			Me.amountLabel1.AutoSize = True
			Me.amountLabel1.Font = New Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.amountLabel1.Location = New Point(136, 29)
			Me.amountLabel1.Name = "amountLabel1"
			Me.amountLabel1.Size = New Size(17, 17)
			Me.amountLabel1.TabIndex = 4
			Me.amountLabel1.Text = "0"
			' 
			' label4
			' 
			Me.label4.Anchor = AnchorStyles.None
			Me.label4.AutoSize = True
			Me.label4.Font = New Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.label4.Location = New Point(13, 29)
			Me.label4.Name = "label4"
			Me.label4.Size = New Size(71, 17)
			Me.label4.TabIndex = 3
			Me.label4.Text = "Nozzle 1"
			' 
			' label2
			' 
			Me.label2.Anchor = AnchorStyles.None
			Me.label2.AutoSize = True
			Me.label2.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.label2.Location = New Point(208, 3)
			Me.label2.Name = "label2"
			Me.label2.Size = New Size(69, 20)
			Me.label2.TabIndex = 1
			Me.label2.Text = "Volume"
			' 
			' volumeLabel4
			' 
			Me.volumeLabel4.Anchor = AnchorStyles.None
			Me.volumeLabel4.AutoSize = True
			Me.volumeLabel4.Font = New Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.volumeLabel4.Location = New Point(234, 98)
			Me.volumeLabel4.Name = "volumeLabel4"
			Me.volumeLabel4.Size = New Size(17, 17)
			Me.volumeLabel4.TabIndex = 2
			Me.volumeLabel4.Text = "0"
			' 
			' amountLabel5
			' 
			Me.amountLabel5.Anchor = AnchorStyles.None
			Me.amountLabel5.AutoSize = True
			Me.amountLabel5.Font = New Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.amountLabel5.Location = New Point(136, 121)
			Me.amountLabel5.Name = "amountLabel5"
			Me.amountLabel5.Size = New Size(17, 17)
			Me.amountLabel5.TabIndex = 14
			Me.amountLabel5.Text = "0"
			' 
			' amountLabel6
			' 
			Me.amountLabel6.Anchor = AnchorStyles.None
			Me.amountLabel6.AutoSize = True
			Me.amountLabel6.Font = New Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.amountLabel6.Location = New Point(136, 144)
			Me.amountLabel6.Name = "amountLabel6"
			Me.amountLabel6.Size = New Size(17, 17)
			Me.amountLabel6.TabIndex = 15
			Me.amountLabel6.Text = "0"
			' 
			' volumeLabel5
			' 
			Me.volumeLabel5.Anchor = AnchorStyles.None
			Me.volumeLabel5.AutoSize = True
			Me.volumeLabel5.Font = New Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.volumeLabel5.Location = New Point(234, 121)
			Me.volumeLabel5.Name = "volumeLabel5"
			Me.volumeLabel5.Size = New Size(17, 17)
			Me.volumeLabel5.TabIndex = 16
			Me.volumeLabel5.Text = "0"
			' 
			' volumeLabel6
			' 
			Me.volumeLabel6.Anchor = AnchorStyles.None
			Me.volumeLabel6.AutoSize = True
			Me.volumeLabel6.Font = New Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.volumeLabel6.Location = New Point(234, 144)
			Me.volumeLabel6.Name = "volumeLabel6"
			Me.volumeLabel6.Size = New Size(17, 17)
			Me.volumeLabel6.TabIndex = 17
			Me.volumeLabel6.Text = "0"
			' 
			' label3
			' 
			Me.label3.Anchor = AnchorStyles.None
			Me.label3.AutoSize = True
			Me.label3.Font = New Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.label3.Location = New Point(13, 121)
			Me.label3.Name = "label3"
			Me.label3.Size = New Size(71, 17)
			Me.label3.TabIndex = 18
			Me.label3.Text = "Nozzle 5"
			' 
			' label1
			' 
			Me.label1.Anchor = AnchorStyles.None
			Me.label1.AutoSize = True
			Me.label1.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.label1.Location = New Point(109, 3)
			Me.label1.Name = "label1"
			Me.label1.Size = New Size(71, 20)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Amount"
			' 
			' updateTotalsButton
			' 
			Me.updateTotalsButton.Anchor = (CType((AnchorStyles.Bottom Or AnchorStyles.Right), AnchorStyles))
			Me.updateTotalsButton.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.updateTotalsButton.Location = New Point(124, 234)
			Me.updateTotalsButton.Name = "updateTotalsButton"
			Me.updateTotalsButton.Size = New Size(75, 23)
			Me.updateTotalsButton.TabIndex = 2
			Me.updateTotalsButton.Text = "Update"
			Me.updateTotalsButton.UseVisualStyleBackColor = True
'			Me.updateTotalsButton.Click += New System.EventHandler(Me.updateTotalsButton_Click)
			' 
			' updateLabel
			' 
			Me.updateLabel.AutoSize = True
			Me.updateLabel.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.updateLabel.Location = New Point(12, 203)
			Me.updateLabel.Name = "updateLabel"
			Me.updateLabel.Size = New Size(77, 13)
			Me.updateLabel.TabIndex = 3
			Me.updateLabel.Text = "updateLabel"
			' 
			' timer1
			' 
			Me.timer1.Interval = 5000
'			Me.timer1.Tick += New System.EventHandler(Me.timer1_Tick)
			' 
			' udNozzlesQuantity
			' 
			Me.udNozzlesQuantity.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.udNozzlesQuantity.Location = New Point(12, 171)
			Me.udNozzlesQuantity.Maximum = New Decimal(New Integer() { 6, 0, 0, 0})
			Me.udNozzlesQuantity.Minimum = New Decimal(New Integer() { 1, 0, 0, 0})
			Me.udNozzlesQuantity.Name = "udNozzlesQuantity"
			Me.udNozzlesQuantity.Size = New Size(50, 20)
			Me.udNozzlesQuantity.TabIndex = 5
			Me.udNozzlesQuantity.TextAlign = HorizontalAlignment.Center
			Me.udNozzlesQuantity.Value = New Decimal(New Integer() { 1, 0, 0, 0})
			' 
			' label6
			' 
			Me.label6.AutoSize = True
			Me.label6.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.label6.Location = New Point(68, 173)
			Me.label6.Name = "label6"
			Me.label6.Size = New Size(176, 13)
			Me.label6.TabIndex = 6
			Me.label6.Text = "Quantity of nozzles to request"
			' 
			' pbTotalsRequest
			' 
			Me.pbTotalsRequest.Image = My.Resources.ajax_loader
			Me.pbTotalsRequest.InitialImage = My.Resources.totalsRequest
			Me.pbTotalsRequest.Location = New Point(98, 236)
			Me.pbTotalsRequest.Name = "pbTotalsRequest"
			Me.pbTotalsRequest.Size = New Size(20, 20)
			Me.pbTotalsRequest.TabIndex = 8
			Me.pbTotalsRequest.TabStop = False
			Me.pbTotalsRequest.Visible = False
			' 
			' TotalsDialog
			' 
			Me.AcceptButton = Me.okButton
			Me.AutoScaleDimensions = New SizeF(6F, 13F)
			Me.AutoScaleMode = AutoScaleMode.Font
			Me.ClientSize = New Size(292, 269)
			Me.Controls.Add(Me.pbTotalsRequest)
			Me.Controls.Add(Me.label6)
			Me.Controls.Add(Me.udNozzlesQuantity)
			Me.Controls.Add(Me.updateLabel)
			Me.Controls.Add(Me.updateTotalsButton)
			Me.Controls.Add(Me.tableLayoutPanel)
			Me.Controls.Add(Me.okButton)
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "TotalsDialog"
			Me.ShowIcon = False
			Me.ShowInTaskbar = False
			Me.StartPosition = FormStartPosition.CenterParent
			Me.Text = "Volume and money amount total counters"
'			Me.Load += New System.EventHandler(Me.TotalsDialog_Load)
'			Me.Shown += New System.EventHandler(Me.TotalsDialog_Shown)
			Me.tableLayoutPanel.ResumeLayout(False)
			Me.tableLayoutPanel.PerformLayout()
			CType(Me.udNozzlesQuantity, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.pbTotalsRequest, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private WithEvents okButton As Button
		Private tableLayoutPanel As TableLayoutPanel
		Private amountLabel4 As Label
		Private label13 As Label
		Private volumeLabel3 As Label
		Private amountLabel3 As Label
		Private label10 As Label
		Private volumeLabel2 As Label
		Private amountLabel2 As Label
		Private label7 As Label
		Private volumeLabel1 As Label
		Private amountLabel1 As Label
		Private label4 As Label
		Private label1 As Label
		Private label2 As Label
		Private volumeLabel4 As Label
		Private WithEvents updateTotalsButton As Button
		Private updateLabel As Label
		Private WithEvents timer1 As Timer
		Private label5 As Label
		Private amountLabel5 As Label
		Private amountLabel6 As Label
		Private volumeLabel5 As Label
		Private volumeLabel6 As Label
		Private label3 As Label
		Private udNozzlesQuantity As NumericUpDown
		Private label6 As Label
		Private pbTotalsRequest As PictureBox
	End Class
End Namespace
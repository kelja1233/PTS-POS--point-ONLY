Namespace TiT.PTS
	Partial Public Class FuelPointSettingDialog
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
            Me.label1 = New System.Windows.Forms.Label()
            Me.label2 = New System.Windows.Forms.Label()
            Me.label3 = New System.Windows.Forms.Label()
            Me.label4 = New System.Windows.Forms.Label()
            Me.groupBox1 = New System.Windows.Forms.GroupBox()
            Me.lblPriceInfo = New System.Windows.Forms.Label()
            Me.btnGetPrices = New System.Windows.Forms.Button()
            Me.btnSetPrices = New System.Windows.Forms.Button()
            Me.label6 = New System.Windows.Forms.Label()
            Me.label5 = New System.Windows.Forms.Label()
            Me.nozzle6PriceUpDown = New System.Windows.Forms.NumericUpDown()
            Me.nozzle5PriceUpDown = New System.Windows.Forms.NumericUpDown()
            Me.nozzle4PriceUpDown = New System.Windows.Forms.NumericUpDown()
            Me.nozzle3PriceUpDown = New System.Windows.Forms.NumericUpDown()
            Me.nozzle2PriceUpDown = New System.Windows.Forms.NumericUpDown()
            Me.nozzle1PriceUpDown = New System.Windows.Forms.NumericUpDown()
            Me.btnOk = New System.Windows.Forms.Button()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.fpListBox = New System.Windows.Forms.ListBox()
            Me.label51 = New System.Windows.Forms.Label()
            Me.channelComboBox = New System.Windows.Forms.ComboBox()
            Me.label8 = New System.Windows.Forms.Label()
            Me.timer1 = New System.Windows.Forms.Timer(Me.components)
            Me.Label9 = New System.Windows.Forms.Label()
            Me.udNozzlesQuantity = New System.Windows.Forms.NumericUpDown()
            Me.groupBox1.SuspendLayout()
            CType(Me.nozzle6PriceUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.nozzle5PriceUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.nozzle4PriceUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.nozzle3PriceUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.nozzle2PriceUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.nozzle1PriceUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.udNozzlesQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'label1
            '
            Me.label1.AutoSize = True
            Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
            Me.label1.Location = New System.Drawing.Point(28, 25)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(60, 13)
            Me.label1.TabIndex = 4
            Me.label1.Text = "Nozzle 1:"
            '
            'label2
            '
            Me.label2.AutoSize = True
            Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
            Me.label2.Location = New System.Drawing.Point(28, 51)
            Me.label2.Name = "label2"
            Me.label2.Size = New System.Drawing.Size(60, 13)
            Me.label2.TabIndex = 5
            Me.label2.Text = "Nozzle 2:"
            '
            'label3
            '
            Me.label3.AutoSize = True
            Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
            Me.label3.Location = New System.Drawing.Point(28, 77)
            Me.label3.Name = "label3"
            Me.label3.Size = New System.Drawing.Size(60, 13)
            Me.label3.TabIndex = 6
            Me.label3.Text = "Nozzle 3:"
            '
            'label4
            '
            Me.label4.AutoSize = True
            Me.label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
            Me.label4.Location = New System.Drawing.Point(28, 103)
            Me.label4.Name = "label4"
            Me.label4.Size = New System.Drawing.Size(60, 13)
            Me.label4.TabIndex = 7
            Me.label4.Text = "Nozzle 4:"
            '
            'groupBox1
            '
            Me.groupBox1.Controls.Add(Me.Label9)
            Me.groupBox1.Controls.Add(Me.udNozzlesQuantity)
            Me.groupBox1.Controls.Add(Me.lblPriceInfo)
            Me.groupBox1.Controls.Add(Me.btnGetPrices)
            Me.groupBox1.Controls.Add(Me.btnSetPrices)
            Me.groupBox1.Controls.Add(Me.label6)
            Me.groupBox1.Controls.Add(Me.label5)
            Me.groupBox1.Controls.Add(Me.nozzle6PriceUpDown)
            Me.groupBox1.Controls.Add(Me.nozzle5PriceUpDown)
            Me.groupBox1.Controls.Add(Me.nozzle4PriceUpDown)
            Me.groupBox1.Controls.Add(Me.nozzle3PriceUpDown)
            Me.groupBox1.Controls.Add(Me.nozzle2PriceUpDown)
            Me.groupBox1.Controls.Add(Me.nozzle1PriceUpDown)
            Me.groupBox1.Controls.Add(Me.label1)
            Me.groupBox1.Controls.Add(Me.label4)
            Me.groupBox1.Controls.Add(Me.label2)
            Me.groupBox1.Controls.Add(Me.label3)
            Me.groupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
            Me.groupBox1.Location = New System.Drawing.Point(12, 12)
            Me.groupBox1.Name = "groupBox1"
            Me.groupBox1.Size = New System.Drawing.Size(175, 255)
            Me.groupBox1.TabIndex = 8
            Me.groupBox1.TabStop = False
            Me.groupBox1.Text = "Nozzle prices"
            '
            'lblPriceInfo
            '
            Me.lblPriceInfo.AutoSize = True
            Me.lblPriceInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
            Me.lblPriceInfo.Location = New System.Drawing.Point(8, 205)
            Me.lblPriceInfo.Name = "lblPriceInfo"
            Me.lblPriceInfo.Size = New System.Drawing.Size(0, 13)
            Me.lblPriceInfo.TabIndex = 16
            '
            'btnGetPrices
            '
            Me.btnGetPrices.Location = New System.Drawing.Point(90, 225)
            Me.btnGetPrices.Name = "btnGetPrices"
            Me.btnGetPrices.Size = New System.Drawing.Size(74, 24)
            Me.btnGetPrices.TabIndex = 22
            Me.btnGetPrices.Text = "Get prices"
            Me.btnGetPrices.UseVisualStyleBackColor = True
            '
            'btnSetPrices
            '
            Me.btnSetPrices.Location = New System.Drawing.Point(6, 225)
            Me.btnSetPrices.Name = "btnSetPrices"
            Me.btnSetPrices.Size = New System.Drawing.Size(73, 24)
            Me.btnSetPrices.TabIndex = 21
            Me.btnSetPrices.Text = "Set prices"
            Me.btnSetPrices.UseVisualStyleBackColor = True
            '
            'label6
            '
            Me.label6.AutoSize = True
            Me.label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
            Me.label6.Location = New System.Drawing.Point(28, 155)
            Me.label6.Name = "label6"
            Me.label6.Size = New System.Drawing.Size(60, 13)
            Me.label6.TabIndex = 20
            Me.label6.Text = "Nozzle 6:"
            '
            'label5
            '
            Me.label5.AutoSize = True
            Me.label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
            Me.label5.Location = New System.Drawing.Point(28, 129)
            Me.label5.Name = "label5"
            Me.label5.Size = New System.Drawing.Size(60, 13)
            Me.label5.TabIndex = 19
            Me.label5.Text = "Nozzle 5:"
            '
            'nozzle6PriceUpDown
            '
            Me.nozzle6PriceUpDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.nozzle6PriceUpDown.DecimalPlaces = 2
            Me.nozzle6PriceUpDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
            Me.nozzle6PriceUpDown.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
            Me.nozzle6PriceUpDown.Location = New System.Drawing.Point(90, 153)
            Me.nozzle6PriceUpDown.Maximum = New Decimal(New Integer() {99999999, 0, 0, 131072})
            Me.nozzle6PriceUpDown.Name = "nozzle6PriceUpDown"
            Me.nozzle6PriceUpDown.Size = New System.Drawing.Size(75, 20)
            Me.nozzle6PriceUpDown.TabIndex = 18
            Me.nozzle6PriceUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'nozzle5PriceUpDown
            '
            Me.nozzle5PriceUpDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.nozzle5PriceUpDown.DecimalPlaces = 2
            Me.nozzle5PriceUpDown.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
            Me.nozzle5PriceUpDown.Location = New System.Drawing.Point(90, 127)
            Me.nozzle5PriceUpDown.Maximum = New Decimal(New Integer() {99999999, 0, 0, 131072})
            Me.nozzle5PriceUpDown.Name = "nozzle5PriceUpDown"
            Me.nozzle5PriceUpDown.Size = New System.Drawing.Size(75, 20)
            Me.nozzle5PriceUpDown.TabIndex = 17
            Me.nozzle5PriceUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'nozzle4PriceUpDown
            '
            Me.nozzle4PriceUpDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.nozzle4PriceUpDown.DecimalPlaces = 2
            Me.nozzle4PriceUpDown.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
            Me.nozzle4PriceUpDown.Location = New System.Drawing.Point(90, 101)
            Me.nozzle4PriceUpDown.Maximum = New Decimal(New Integer() {99999999, 0, 0, 131072})
            Me.nozzle4PriceUpDown.Name = "nozzle4PriceUpDown"
            Me.nozzle4PriceUpDown.Size = New System.Drawing.Size(75, 20)
            Me.nozzle4PriceUpDown.TabIndex = 11
            Me.nozzle4PriceUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'nozzle3PriceUpDown
            '
            Me.nozzle3PriceUpDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.nozzle3PriceUpDown.DecimalPlaces = 2
            Me.nozzle3PriceUpDown.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
            Me.nozzle3PriceUpDown.Location = New System.Drawing.Point(90, 75)
            Me.nozzle3PriceUpDown.Maximum = New Decimal(New Integer() {99999999, 0, 0, 131072})
            Me.nozzle3PriceUpDown.Name = "nozzle3PriceUpDown"
            Me.nozzle3PriceUpDown.Size = New System.Drawing.Size(75, 20)
            Me.nozzle3PriceUpDown.TabIndex = 10
            Me.nozzle3PriceUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'nozzle2PriceUpDown
            '
            Me.nozzle2PriceUpDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.nozzle2PriceUpDown.DecimalPlaces = 2
            Me.nozzle2PriceUpDown.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
            Me.nozzle2PriceUpDown.Location = New System.Drawing.Point(90, 49)
            Me.nozzle2PriceUpDown.Maximum = New Decimal(New Integer() {99999999, 0, 0, 131072})
            Me.nozzle2PriceUpDown.Name = "nozzle2PriceUpDown"
            Me.nozzle2PriceUpDown.Size = New System.Drawing.Size(75, 20)
            Me.nozzle2PriceUpDown.TabIndex = 9
            Me.nozzle2PriceUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'nozzle1PriceUpDown
            '
            Me.nozzle1PriceUpDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.nozzle1PriceUpDown.DecimalPlaces = 2
            Me.nozzle1PriceUpDown.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
            Me.nozzle1PriceUpDown.Location = New System.Drawing.Point(90, 23)
            Me.nozzle1PriceUpDown.Maximum = New Decimal(New Integer() {99999999, 0, 0, 131072})
            Me.nozzle1PriceUpDown.Name = "nozzle1PriceUpDown"
            Me.nozzle1PriceUpDown.Size = New System.Drawing.Size(75, 20)
            Me.nozzle1PriceUpDown.TabIndex = 8
            Me.nozzle1PriceUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'btnOk
            '
            Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.btnOk.Location = New System.Drawing.Point(201, 247)
            Me.btnOk.Name = "btnOk"
            Me.btnOk.Size = New System.Drawing.Size(75, 23)
            Me.btnOk.TabIndex = 9
            Me.btnOk.Text = "OK"
            Me.btnOk.UseVisualStyleBackColor = True
            '
            'btnCancel
            '
            Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnCancel.Location = New System.Drawing.Point(284, 247)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(75, 23)
            Me.btnCancel.TabIndex = 10
            Me.btnCancel.Text = "Close"
            Me.btnCancel.UseVisualStyleBackColor = True
            '
            'fpListBox
            '
            Me.fpListBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.fpListBox.FormattingEnabled = True
            Me.fpListBox.IntegralHeight = False
            Me.fpListBox.Location = New System.Drawing.Point(204, 63)
            Me.fpListBox.Name = "fpListBox"
            Me.fpListBox.Size = New System.Drawing.Size(155, 132)
            Me.fpListBox.TabIndex = 12
            '
            'label51
            '
            Me.label51.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.label51.AutoSize = True
            Me.label51.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
            Me.label51.Location = New System.Drawing.Point(243, 4)
            Me.label51.Name = "label51"
            Me.label51.Size = New System.Drawing.Size(116, 13)
            Me.label51.TabIndex = 13
            Me.label51.Text = "Fuel point channel:"
            Me.label51.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'channelComboBox
            '
            Me.channelComboBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.channelComboBox.DisplayMember = "ID"
            Me.channelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.channelComboBox.FormattingEnabled = True
            Me.channelComboBox.Location = New System.Drawing.Point(204, 20)
            Me.channelComboBox.Name = "channelComboBox"
            Me.channelComboBox.Size = New System.Drawing.Size(155, 21)
            Me.channelComboBox.TabIndex = 14
            '
            'label8
            '
            Me.label8.AutoSize = True
            Me.label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
            Me.label8.Location = New System.Drawing.Point(286, 47)
            Me.label8.Name = "label8"
            Me.label8.Size = New System.Drawing.Size(73, 13)
            Me.label8.TabIndex = 15
            Me.label8.Text = "Fuel points:"
            '
            'timer1
            '
            Me.timer1.Interval = 5000
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
            Me.Label9.Location = New System.Drawing.Point(50, 182)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(115, 13)
            Me.Label9.TabIndex = 17
            Me.Label9.Text = "Quantity of nozzles"
            '
            'udNozzlesQuantity
            '
            Me.udNozzlesQuantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
            Me.udNozzlesQuantity.Location = New System.Drawing.Point(6, 180)
            Me.udNozzlesQuantity.Maximum = New Decimal(New Integer() {6, 0, 0, 0})
            Me.udNozzlesQuantity.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me.udNozzlesQuantity.Name = "udNozzlesQuantity"
            Me.udNozzlesQuantity.Size = New System.Drawing.Size(38, 20)
            Me.udNozzlesQuantity.TabIndex = 16
            Me.udNozzlesQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            Me.udNozzlesQuantity.Value = New Decimal(New Integer() {1, 0, 0, 0})
            '
            'FuelPointSettingDialog
            '
            Me.AcceptButton = Me.btnOk
            Me.CancelButton = Me.btnCancel
            Me.ClientSize = New System.Drawing.Size(369, 279)
            Me.Controls.Add(Me.label8)
            Me.Controls.Add(Me.channelComboBox)
            Me.Controls.Add(Me.label51)
            Me.Controls.Add(Me.fpListBox)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnOk)
            Me.Controls.Add(Me.groupBox1)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "FuelPointSettingDialog"
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Fuel point settings"
            Me.groupBox1.ResumeLayout(False)
            Me.groupBox1.PerformLayout()
            CType(Me.nozzle6PriceUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.nozzle5PriceUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.nozzle4PriceUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.nozzle3PriceUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.nozzle2PriceUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.nozzle1PriceUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.udNozzlesQuantity, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

#End Region

        Private label1 As Label
        Private label2 As Label
        Private label3 As Label
        Private label4 As Label
        Private groupBox1 As GroupBox
        Private WithEvents btnOk As Button
        Private btnCancel As Button
        Private WithEvents fpListBox As ListBox
        Private label51 As Label
        Private WithEvents channelComboBox As ComboBox
        Private nozzle4PriceUpDown As NumericUpDown
        Private nozzle3PriceUpDown As NumericUpDown
        Private nozzle2PriceUpDown As NumericUpDown
        Private nozzle1PriceUpDown As NumericUpDown
        Private label6 As Label
        Private label5 As Label
		Private nozzle6PriceUpDown As NumericUpDown
		Private nozzle5PriceUpDown As NumericUpDown
		Private label8 As Label
		Private WithEvents btnGetPrices As Button
		Private WithEvents btnSetPrices As Button
		Private lblPriceInfo As Label
        Private WithEvents timer1 As Timer
        Private WithEvents Label9 As System.Windows.Forms.Label
        Private WithEvents udNozzlesQuantity As System.Windows.Forms.NumericUpDown
	End Class
End Namespace
Namespace TiT.PTS
	Partial Public Class AtgDisplaySettingDialog
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
			Me.btnOk = New Button()
			Me.btnCancel = New Button()
			Me.atgListBox = New ListBox()
			Me.label1 = New Label()
			Me.tankHeightUpDown = New NumericUpDown()
			Me.channelComboBox = New ComboBox()
			Me.label5 = New Label()
			CType(Me.tankHeightUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' btnOk
			' 
			Me.btnOk.Anchor = (CType((AnchorStyles.Bottom Or AnchorStyles.Right), AnchorStyles))
			Me.btnOk.DialogResult = DialogResult.OK
			Me.btnOk.Location = New Point(75, 306)
			Me.btnOk.Name = "btnOk"
			Me.btnOk.Size = New Size(75, 23)
			Me.btnOk.TabIndex = 0
			Me.btnOk.Text = "Select"
			Me.btnOk.UseVisualStyleBackColor = True
'			Me.btnOk.Click += New System.EventHandler(Me.okButton_Click)
			' 
			' btnCancel
			' 
			Me.btnCancel.Anchor = (CType((AnchorStyles.Bottom Or AnchorStyles.Right), AnchorStyles))
			Me.btnCancel.DialogResult = DialogResult.Cancel
			Me.btnCancel.Location = New Point(156, 306)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.Size = New Size(75, 23)
			Me.btnCancel.TabIndex = 1
			Me.btnCancel.Text = "Cancel"
			Me.btnCancel.UseVisualStyleBackColor = True
			' 
			' atgListBox
			' 
			Me.atgListBox.Anchor = (CType((((AnchorStyles.Top Or AnchorStyles.Bottom) Or AnchorStyles.Left) Or AnchorStyles.Right), AnchorStyles))
			Me.atgListBox.FormattingEnabled = True
			Me.atgListBox.IntegralHeight = False
			Me.atgListBox.Location = New Point(12, 33)
			Me.atgListBox.MultiColumn = True
			Me.atgListBox.Name = "atgListBox"
			Me.atgListBox.Size = New Size(220, 229)
			Me.atgListBox.TabIndex = 2
'			Me.atgListBox.SelectedIndexChanged += New System.EventHandler(Me.atgListBox_SelectedIndexChanged)
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New Point(93, 272)
			Me.label1.Name = "label1"
			Me.label1.Size = New Size(89, 13)
			Me.label1.TabIndex = 3
			Me.label1.Text = "Tank height (mm)"
			' 
			' tankHeightUpDown
			' 
			Me.tankHeightUpDown.Anchor = (CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles))
			Me.tankHeightUpDown.Location = New Point(12, 268)
			Me.tankHeightUpDown.Maximum = New Decimal(New Integer() { 99999, 0, 0, 0})
			Me.tankHeightUpDown.Name = "tankHeightUpDown"
			Me.tankHeightUpDown.Size = New Size(75, 20)
			Me.tankHeightUpDown.TabIndex = 9
			Me.tankHeightUpDown.TextAlign = HorizontalAlignment.Right
			' 
			' channelComboBox
			' 
			Me.channelComboBox.Anchor = (CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles))
			Me.channelComboBox.DisplayMember = "ID"
			Me.channelComboBox.DropDownStyle = ComboBoxStyle.DropDownList
			Me.channelComboBox.FormattingEnabled = True
			Me.channelComboBox.Location = New Point(88, 6)
			Me.channelComboBox.Name = "channelComboBox"
			Me.channelComboBox.Size = New Size(84, 21)
			Me.channelComboBox.TabIndex = 16
'			Me.channelComboBox.SelectedIndexChanged += New System.EventHandler(Me.channelListBox_SelectedIndexChanged)
			' 
			' label5
			' 
			Me.label5.Anchor = (CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles))
			Me.label5.AutoSize = True
			Me.label5.Location = New Point(9, 9)
			Me.label5.Name = "label5"
			Me.label5.Size = New Size(73, 13)
			Me.label5.TabIndex = 15
			Me.label5.Text = "ATG channel:"
			' 
			' AtgDisplaySettingDialog
			' 
			Me.AcceptButton = Me.btnOk
			Me.AutoScaleDimensions = New SizeF(6F, 13F)
			Me.AutoScaleMode = AutoScaleMode.Font
			Me.CancelButton = Me.btnCancel
			Me.ClientSize = New Size(244, 341)
			Me.Controls.Add(Me.channelComboBox)
			Me.Controls.Add(Me.label5)
			Me.Controls.Add(Me.tankHeightUpDown)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.atgListBox)
			Me.Controls.Add(Me.btnCancel)
			Me.Controls.Add(Me.btnOk)
			Me.FormBorderStyle = FormBorderStyle.FixedSingle
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "AtgDisplaySettingDialog"
			Me.ShowIcon = False
			Me.ShowInTaskbar = False
			Me.StartPosition = FormStartPosition.CenterParent
			Me.Text = "ATG selection"
			CType(Me.tankHeightUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private WithEvents btnOk As Button
		Private btnCancel As Button
		Private WithEvents atgListBox As ListBox
		Private label1 As Label
		Private tankHeightUpDown As NumericUpDown
		Private WithEvents channelComboBox As ComboBox
		Private label5 As Label
	End Class
End Namespace
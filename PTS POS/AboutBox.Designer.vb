Namespace TiT.PTS
	Partial Friend Class AboutBox
		''' <summary>
		''' Требуется переменная конструктора.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Освободить все используемые ресурсы.
		''' </summary>
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
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(AboutBox))
			Me.tableLayoutPanel = New TableLayoutPanel()
			Me.logoPictureBox = New PictureBox()
			Me.labelProductName = New Label()
			Me.labelVersion = New Label()
			Me.labelCopyright = New Label()
			Me.labelCompanyName = New Label()
			Me.textBoxDescription = New TextBox()
			Me.okButton = New Button()
			Me.tableLayoutPanel.SuspendLayout()
			CType(Me.logoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' tableLayoutPanel
			' 
			Me.tableLayoutPanel.ColumnCount = 2
			Me.tableLayoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33F))
			Me.tableLayoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 67F))
			Me.tableLayoutPanel.Controls.Add(Me.logoPictureBox, 0, 0)
			Me.tableLayoutPanel.Controls.Add(Me.labelProductName, 1, 0)
			Me.tableLayoutPanel.Controls.Add(Me.labelVersion, 1, 1)
			Me.tableLayoutPanel.Controls.Add(Me.labelCopyright, 1, 2)
			Me.tableLayoutPanel.Controls.Add(Me.labelCompanyName, 1, 3)
			Me.tableLayoutPanel.Controls.Add(Me.textBoxDescription, 1, 4)
			Me.tableLayoutPanel.Controls.Add(Me.okButton, 1, 5)
			Me.tableLayoutPanel.Dock = DockStyle.Fill
			Me.tableLayoutPanel.Location = New Point(9, 9)
			Me.tableLayoutPanel.Name = "tableLayoutPanel"
			Me.tableLayoutPanel.RowCount = 6
			Me.tableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 10F))
			Me.tableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 10F))
			Me.tableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 10F))
			Me.tableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 10F))
			Me.tableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
			Me.tableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 10F))
			Me.tableLayoutPanel.Size = New Size(417, 265)
			Me.tableLayoutPanel.TabIndex = 0
			' 
			' logoPictureBox
			' 
			Me.logoPictureBox.Dock = DockStyle.Fill
			Me.logoPictureBox.Image = (CType(resources.GetObject("logoPictureBox.Image"), Image))
			Me.logoPictureBox.Location = New Point(3, 3)
			Me.logoPictureBox.Name = "logoPictureBox"
			Me.tableLayoutPanel.SetRowSpan(Me.logoPictureBox, 6)
			Me.logoPictureBox.Size = New Size(131, 259)
			Me.logoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage
			Me.logoPictureBox.TabIndex = 12
			Me.logoPictureBox.TabStop = False
			' 
			' labelProductName
			' 
			Me.labelProductName.Dock = DockStyle.Fill
			Me.labelProductName.Location = New Point(143, 0)
			Me.labelProductName.Margin = New Padding(6, 0, 3, 0)
			Me.labelProductName.MaximumSize = New Size(0, 17)
			Me.labelProductName.Name = "labelProductName"
			Me.labelProductName.Size = New Size(271, 17)
			Me.labelProductName.TabIndex = 19
			Me.labelProductName.Text = "Название продукта"
			Me.labelProductName.TextAlign = ContentAlignment.MiddleLeft
			' 
			' labelVersion
			' 
			Me.labelVersion.Dock = DockStyle.Fill
			Me.labelVersion.Location = New Point(143, 26)
			Me.labelVersion.Margin = New Padding(6, 0, 3, 0)
			Me.labelVersion.MaximumSize = New Size(0, 17)
			Me.labelVersion.Name = "labelVersion"
			Me.labelVersion.Size = New Size(271, 17)
			Me.labelVersion.TabIndex = 0
			Me.labelVersion.Text = "Версия"
			Me.labelVersion.TextAlign = ContentAlignment.MiddleLeft
			' 
			' labelCopyright
			' 
			Me.labelCopyright.Dock = DockStyle.Fill
			Me.labelCopyright.Location = New Point(143, 52)
			Me.labelCopyright.Margin = New Padding(6, 0, 3, 0)
			Me.labelCopyright.MaximumSize = New Size(0, 17)
			Me.labelCopyright.Name = "labelCopyright"
			Me.labelCopyright.Size = New Size(271, 17)
			Me.labelCopyright.TabIndex = 21
			Me.labelCopyright.Text = "Авторские права"
			Me.labelCopyright.TextAlign = ContentAlignment.MiddleLeft
			' 
			' labelCompanyName
			' 
			Me.labelCompanyName.Dock = DockStyle.Fill
			Me.labelCompanyName.Location = New Point(143, 78)
			Me.labelCompanyName.Margin = New Padding(6, 0, 3, 0)
			Me.labelCompanyName.MaximumSize = New Size(0, 17)
			Me.labelCompanyName.Name = "labelCompanyName"
			Me.labelCompanyName.Size = New Size(271, 17)
			Me.labelCompanyName.TabIndex = 22
			Me.labelCompanyName.Text = "Название организации"
			Me.labelCompanyName.TextAlign = ContentAlignment.MiddleLeft
			' 
			' textBoxDescription
			' 
			Me.textBoxDescription.Dock = DockStyle.Fill
			Me.textBoxDescription.Location = New Point(143, 107)
			Me.textBoxDescription.Margin = New Padding(6, 3, 3, 3)
			Me.textBoxDescription.Multiline = True
			Me.textBoxDescription.Name = "textBoxDescription"
			Me.textBoxDescription.ReadOnly = True
			Me.textBoxDescription.ScrollBars = ScrollBars.Both
			Me.textBoxDescription.Size = New Size(271, 126)
			Me.textBoxDescription.TabIndex = 23
			Me.textBoxDescription.TabStop = False
			Me.textBoxDescription.Text = "Описание"
			' 
			' okButton
			' 
			Me.okButton.Anchor = (CType((AnchorStyles.Bottom Or AnchorStyles.Right), AnchorStyles))
			Me.okButton.DialogResult = DialogResult.Cancel
			Me.okButton.Location = New Point(339, 239)
			Me.okButton.Name = "okButton"
			Me.okButton.Size = New Size(75, 23)
			Me.okButton.TabIndex = 24
			Me.okButton.Text = "&ОК"
			' 
			' AboutBox
			' 
			Me.AcceptButton = Me.okButton
			Me.AutoScaleDimensions = New SizeF(6F, 13F)
			Me.AutoScaleMode = AutoScaleMode.Font
			Me.ClientSize = New Size(435, 283)
			Me.Controls.Add(Me.tableLayoutPanel)
			Me.FormBorderStyle = FormBorderStyle.FixedDialog
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "AboutBox"
			Me.Padding = New Padding(9)
			Me.ShowIcon = False
			Me.ShowInTaskbar = False
			Me.StartPosition = FormStartPosition.CenterParent
			Me.Text = "AboutBox"
			Me.tableLayoutPanel.ResumeLayout(False)
			Me.tableLayoutPanel.PerformLayout()
			CType(Me.logoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private tableLayoutPanel As TableLayoutPanel
		Private logoPictureBox As PictureBox
		Private labelProductName As Label
		Private labelVersion As Label
		Private labelCopyright As Label
		Private labelCompanyName As Label
		Private textBoxDescription As TextBox
		Private okButton As Button
	End Class
End Namespace

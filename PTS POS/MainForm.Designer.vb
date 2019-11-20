Namespace TiT.PTS
	Partial Public Class MainForm
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
      Me.statusStrip = New System.Windows.Forms.StatusStrip()
      Me.menuStrip = New System.Windows.Forms.MenuStrip()
      Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.toolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.settingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.dispensingSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.pumpsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.totalCountersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsStopAllPumps = New System.Windows.Forms.ToolStripMenuItem()
      Me.aTGToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.aTGMeasurementDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.helpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.aboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.tableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
      Me._fuelPointControl1 = New TiT.PTS.FuelPointControl()
      Me._fuelPointControl2 = New TiT.PTS.FuelPointControl()
      Me._fuelPointControl3 = New TiT.PTS.FuelPointControl()
      Me._fuelPointControl4 = New TiT.PTS.FuelPointControl()
      Me._fuelPointControl5 = New TiT.PTS.FuelPointControl()
      Me._fuelPointControl6 = New TiT.PTS.FuelPointControl()
      Me._fuelPointControl7 = New TiT.PTS.FuelPointControl()
      Me._fuelPointControl8 = New TiT.PTS.FuelPointControl()
      Me.toolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
      Me.portListComboBox = New System.Windows.Forms.ToolStripComboBox()
      Me.toolStrip = New System.Windows.Forms.ToolStrip()
      Me.portConnectionButton = New System.Windows.Forms.ToolStripButton()
      Me.menuStrip.SuspendLayout()
      Me.tableLayoutPanel.SuspendLayout()
      Me.toolStrip.SuspendLayout()
      Me.SuspendLayout()
      '
      'statusStrip
      '
      Me.statusStrip.Location = New System.Drawing.Point(0, 579)
      Me.statusStrip.Name = "statusStrip"
      Me.statusStrip.Size = New System.Drawing.Size(805, 22)
      Me.statusStrip.TabIndex = 0
      '
      'menuStrip
      '
      Me.menuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem, Me.toolsToolStripMenuItem, Me.pumpsToolStripMenuItem, Me.aTGToolStripMenuItem, Me.helpToolStripMenuItem})
      Me.menuStrip.Location = New System.Drawing.Point(0, 0)
      Me.menuStrip.Name = "menuStrip"
      Me.menuStrip.Size = New System.Drawing.Size(805, 24)
      Me.menuStrip.TabIndex = 1
      '
      'fileToolStripMenuItem
      '
      Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.exitToolStripMenuItem})
      Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
      Me.fileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
      Me.fileToolStripMenuItem.Text = "&File"
      '
      'exitToolStripMenuItem
      '
      Me.exitToolStripMenuItem.Name = "exitToolStripMenuItem"
      Me.exitToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
      Me.exitToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
      Me.exitToolStripMenuItem.Text = "E&xit"
      '
      'toolsToolStripMenuItem
      '
      Me.toolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.settingsToolStripMenuItem, Me.dispensingSettingsToolStripMenuItem})
      Me.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem"
      Me.toolsToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
      Me.toolsToolStripMenuItem.Size = New System.Drawing.Size(93, 20)
      Me.toolsToolStripMenuItem.Text = "Configuration"
      '
      'settingsToolStripMenuItem
      '
      Me.settingsToolStripMenuItem.Enabled = False
      Me.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem"
      Me.settingsToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
      Me.settingsToolStripMenuItem.Size = New System.Drawing.Size(293, 22)
      Me.settingsToolStripMenuItem.Text = "Fuel points &configuration settings"
      '
      'dispensingSettingsToolStripMenuItem
      '
      Me.dispensingSettingsToolStripMenuItem.Enabled = False
      Me.dispensingSettingsToolStripMenuItem.Name = "dispensingSettingsToolStripMenuItem"
      Me.dispensingSettingsToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.U), System.Windows.Forms.Keys)
      Me.dispensingSettingsToolStripMenuItem.Size = New System.Drawing.Size(293, 22)
      Me.dispensingSettingsToolStripMenuItem.Text = "Settings"
      '
      'pumpsToolStripMenuItem
      '
      Me.pumpsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.totalCountersToolStripMenuItem, Me.tsStopAllPumps})
      Me.pumpsToolStripMenuItem.Name = "pumpsToolStripMenuItem"
      Me.pumpsToolStripMenuItem.Size = New System.Drawing.Size(56, 20)
      Me.pumpsToolStripMenuItem.Text = "Pumps"
      '
      'totalCountersToolStripMenuItem
      '
      Me.totalCountersToolStripMenuItem.Enabled = False
      Me.totalCountersToolStripMenuItem.Name = "totalCountersToolStripMenuItem"
      Me.totalCountersToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
      Me.totalCountersToolStripMenuItem.Text = "Total counters"
      '
      'tsStopAllPumps
      '
      Me.tsStopAllPumps.Enabled = False
      Me.tsStopAllPumps.Name = "tsStopAllPumps"
      Me.tsStopAllPumps.Size = New System.Drawing.Size(153, 22)
      Me.tsStopAllPumps.Text = "Stop all pumps"
      '
      'aTGToolStripMenuItem
      '
      Me.aTGToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.aTGMeasurementDataToolStripMenuItem})
      Me.aTGToolStripMenuItem.Name = "aTGToolStripMenuItem"
      Me.aTGToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
      Me.aTGToolStripMenuItem.Text = "ATG"
      '
      'aTGMeasurementDataToolStripMenuItem
      '
      Me.aTGMeasurementDataToolStripMenuItem.Enabled = False
      Me.aTGMeasurementDataToolStripMenuItem.Name = "aTGMeasurementDataToolStripMenuItem"
      Me.aTGMeasurementDataToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
      Me.aTGMeasurementDataToolStripMenuItem.Size = New System.Drawing.Size(238, 22)
      Me.aTGMeasurementDataToolStripMenuItem.Text = "ATG measurement data"
      '
      'helpToolStripMenuItem
      '
      Me.helpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.aboutToolStripMenuItem})
      Me.helpToolStripMenuItem.Name = "helpToolStripMenuItem"
      Me.helpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
      Me.helpToolStripMenuItem.Text = "Help"
      '
      'aboutToolStripMenuItem
      '
      Me.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem"
      Me.aboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1
      Me.aboutToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
      Me.aboutToolStripMenuItem.Text = "&About..."
      '
      'tableLayoutPanel
      '
      Me.tableLayoutPanel.BackColor = System.Drawing.Color.White
      Me.tableLayoutPanel.ColumnCount = 4
      Me.tableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
      Me.tableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
      Me.tableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
      Me.tableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
      Me.tableLayoutPanel.Controls.Add(Me._fuelPointControl1, 0, 0)
      Me.tableLayoutPanel.Controls.Add(Me._fuelPointControl2, 1, 0)
      Me.tableLayoutPanel.Controls.Add(Me._fuelPointControl3, 2, 0)
      Me.tableLayoutPanel.Controls.Add(Me._fuelPointControl4, 3, 0)
      Me.tableLayoutPanel.Controls.Add(Me._fuelPointControl5, 0, 1)
      Me.tableLayoutPanel.Controls.Add(Me._fuelPointControl6, 1, 1)
      Me.tableLayoutPanel.Controls.Add(Me._fuelPointControl7, 2, 1)
      Me.tableLayoutPanel.Controls.Add(Me._fuelPointControl8, 3, 1)
      Me.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
      Me.tableLayoutPanel.Location = New System.Drawing.Point(0, 49)
      Me.tableLayoutPanel.Margin = New System.Windows.Forms.Padding(0)
      Me.tableLayoutPanel.Name = "tableLayoutPanel"
      Me.tableLayoutPanel.RowCount = 2
      Me.tableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
      Me.tableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
      Me.tableLayoutPanel.Size = New System.Drawing.Size(805, 530)
      Me.tableLayoutPanel.TabIndex = 3
      '
      '_fuelPointControl1
      '
      Me._fuelPointControl1.Anchor = System.Windows.Forms.AnchorStyles.None
      Me._fuelPointControl1.BackColor = System.Drawing.Color.LightYellow
      Me._fuelPointControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._fuelPointControl1.FuelPointID = Nothing
      Me._fuelPointControl1.IsDispensing = False
      Me._fuelPointControl1.IsLocked = False
      Me._fuelPointControl1.Location = New System.Drawing.Point(3, 3)
      Me._fuelPointControl1.MinimumSize = New System.Drawing.Size(195, 260)
      Me._fuelPointControl1.Name = "_fuelPointControl1"
      Me._fuelPointControl1.PTS = Nothing
      Me._fuelPointControl1.Size = New System.Drawing.Size(195, 260)
      Me._fuelPointControl1.TabIndex = 0
      '
      '_fuelPointControl2
      '
      Me._fuelPointControl2.Anchor = System.Windows.Forms.AnchorStyles.None
      Me._fuelPointControl2.BackColor = System.Drawing.Color.LightYellow
      Me._fuelPointControl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._fuelPointControl2.FuelPointID = Nothing
      Me._fuelPointControl2.IsDispensing = False
      Me._fuelPointControl2.IsLocked = False
      Me._fuelPointControl2.Location = New System.Drawing.Point(204, 3)
      Me._fuelPointControl2.MinimumSize = New System.Drawing.Size(195, 260)
      Me._fuelPointControl2.Name = "_fuelPointControl2"
      Me._fuelPointControl2.PTS = Nothing
      Me._fuelPointControl2.Size = New System.Drawing.Size(195, 260)
      Me._fuelPointControl2.TabIndex = 1
      '
      '_fuelPointControl3
      '
      Me._fuelPointControl3.Anchor = System.Windows.Forms.AnchorStyles.None
      Me._fuelPointControl3.BackColor = System.Drawing.Color.LightYellow
      Me._fuelPointControl3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._fuelPointControl3.FuelPointID = Nothing
      Me._fuelPointControl3.IsDispensing = False
      Me._fuelPointControl3.IsLocked = False
      Me._fuelPointControl3.Location = New System.Drawing.Point(405, 3)
      Me._fuelPointControl3.MinimumSize = New System.Drawing.Size(195, 260)
      Me._fuelPointControl3.Name = "_fuelPointControl3"
      Me._fuelPointControl3.PTS = Nothing
      Me._fuelPointControl3.Size = New System.Drawing.Size(195, 260)
      Me._fuelPointControl3.TabIndex = 2
      '
      '_fuelPointControl4
      '
      Me._fuelPointControl4.Anchor = System.Windows.Forms.AnchorStyles.None
      Me._fuelPointControl4.BackColor = System.Drawing.Color.LightYellow
      Me._fuelPointControl4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._fuelPointControl4.FuelPointID = Nothing
      Me._fuelPointControl4.IsDispensing = False
      Me._fuelPointControl4.IsLocked = False
      Me._fuelPointControl4.Location = New System.Drawing.Point(606, 3)
      Me._fuelPointControl4.MinimumSize = New System.Drawing.Size(195, 260)
      Me._fuelPointControl4.Name = "_fuelPointControl4"
      Me._fuelPointControl4.PTS = Nothing
      Me._fuelPointControl4.Size = New System.Drawing.Size(195, 260)
      Me._fuelPointControl4.TabIndex = 3
      '
      '_fuelPointControl5
      '
      Me._fuelPointControl5.Anchor = System.Windows.Forms.AnchorStyles.None
      Me._fuelPointControl5.BackColor = System.Drawing.Color.LightYellow
      Me._fuelPointControl5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._fuelPointControl5.FuelPointID = Nothing
      Me._fuelPointControl5.IsDispensing = False
      Me._fuelPointControl5.IsLocked = False
      Me._fuelPointControl5.Location = New System.Drawing.Point(3, 268)
      Me._fuelPointControl5.MinimumSize = New System.Drawing.Size(195, 260)
      Me._fuelPointControl5.Name = "_fuelPointControl5"
      Me._fuelPointControl5.PTS = Nothing
      Me._fuelPointControl5.Size = New System.Drawing.Size(195, 260)
      Me._fuelPointControl5.TabIndex = 4
      '
      '_fuelPointControl6
      '
      Me._fuelPointControl6.Anchor = System.Windows.Forms.AnchorStyles.None
      Me._fuelPointControl6.BackColor = System.Drawing.Color.LightYellow
      Me._fuelPointControl6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._fuelPointControl6.FuelPointID = Nothing
      Me._fuelPointControl6.IsDispensing = False
      Me._fuelPointControl6.IsLocked = False
      Me._fuelPointControl6.Location = New System.Drawing.Point(204, 268)
      Me._fuelPointControl6.MinimumSize = New System.Drawing.Size(195, 260)
      Me._fuelPointControl6.Name = "_fuelPointControl6"
      Me._fuelPointControl6.PTS = Nothing
      Me._fuelPointControl6.Size = New System.Drawing.Size(195, 260)
      Me._fuelPointControl6.TabIndex = 5
      '
      '_fuelPointControl7
      '
      Me._fuelPointControl7.Anchor = System.Windows.Forms.AnchorStyles.None
      Me._fuelPointControl7.BackColor = System.Drawing.Color.LightYellow
      Me._fuelPointControl7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._fuelPointControl7.FuelPointID = Nothing
      Me._fuelPointControl7.IsDispensing = False
      Me._fuelPointControl7.IsLocked = False
      Me._fuelPointControl7.Location = New System.Drawing.Point(405, 268)
      Me._fuelPointControl7.MinimumSize = New System.Drawing.Size(195, 260)
      Me._fuelPointControl7.Name = "_fuelPointControl7"
      Me._fuelPointControl7.PTS = Nothing
      Me._fuelPointControl7.Size = New System.Drawing.Size(195, 260)
      Me._fuelPointControl7.TabIndex = 6
      '
      '_fuelPointControl8
      '
      Me._fuelPointControl8.Anchor = System.Windows.Forms.AnchorStyles.None
      Me._fuelPointControl8.BackColor = System.Drawing.Color.LightYellow
      Me._fuelPointControl8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._fuelPointControl8.FuelPointID = Nothing
      Me._fuelPointControl8.IsDispensing = False
      Me._fuelPointControl8.IsLocked = False
      Me._fuelPointControl8.Location = New System.Drawing.Point(606, 268)
      Me._fuelPointControl8.MinimumSize = New System.Drawing.Size(195, 260)
      Me._fuelPointControl8.Name = "_fuelPointControl8"
      Me._fuelPointControl8.PTS = Nothing
      Me._fuelPointControl8.Size = New System.Drawing.Size(195, 260)
      Me._fuelPointControl8.TabIndex = 7
      '
      'toolStripLabel1
      '
      Me.toolStripLabel1.Name = "toolStripLabel1"
      Me.toolStripLabel1.Size = New System.Drawing.Size(63, 22)
      Me.toolStripLabel1.Text = "COM port:"
      '
      'portListComboBox
      '
      Me.portListComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.portListComboBox.Name = "portListComboBox"
      Me.portListComboBox.Size = New System.Drawing.Size(75, 25)
      '
      'toolStrip
      '
      Me.toolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripLabel1, Me.portListComboBox, Me.portConnectionButton})
      Me.toolStrip.Location = New System.Drawing.Point(0, 24)
      Me.toolStrip.Name = "toolStrip"
      Me.toolStrip.Size = New System.Drawing.Size(805, 25)
      Me.toolStrip.TabIndex = 2
      '
      'portConnectionButton
      '
      Me.portConnectionButton.CheckOnClick = True
      Me.portConnectionButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.portConnectionButton.Image = CType(resources.GetObject("portConnectionButton.Image"), System.Drawing.Image)
      Me.portConnectionButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.portConnectionButton.Name = "portConnectionButton"
      Me.portConnectionButton.Size = New System.Drawing.Size(23, 22)
      '
      'MainForm
      '
      Me.ClientSize = New System.Drawing.Size(805, 601)
      Me.Controls.Add(Me.tableLayoutPanel)
      Me.Controls.Add(Me.toolStrip)
      Me.Controls.Add(Me.statusStrip)
      Me.Controls.Add(Me.menuStrip)
      Me.MainMenuStrip = Me.menuStrip
      Me.MinimumSize = New System.Drawing.Size(813, 630)
      Me.Name = "MainForm"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "PTS controller VB.NET application, version "
      Me.menuStrip.ResumeLayout(False)
      Me.menuStrip.PerformLayout()
      Me.tableLayoutPanel.ResumeLayout(False)
      Me.toolStrip.ResumeLayout(False)
      Me.toolStrip.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

    End Sub

#End Region

    Private statusStrip As StatusStrip
		Private menuStrip As MenuStrip
		Private toolsToolStripMenuItem As ToolStripMenuItem
		Private WithEvents settingsToolStripMenuItem As ToolStripMenuItem
		Private tableLayoutPanel As TableLayoutPanel
		Private toolStripLabel1 As ToolStripLabel
		Private portListComboBox As ToolStripComboBox
		Private WithEvents portConnectionButton As ToolStripButton
		Private toolStrip As ToolStrip
		Private fileToolStripMenuItem As ToolStripMenuItem
		Private WithEvents exitToolStripMenuItem As ToolStripMenuItem
		Private helpToolStripMenuItem As ToolStripMenuItem
		Private WithEvents aboutToolStripMenuItem As ToolStripMenuItem
		Private WithEvents dispensingSettingsToolStripMenuItem As ToolStripMenuItem
		Private aTGToolStripMenuItem As ToolStripMenuItem
		Private WithEvents aTGMeasurementDataToolStripMenuItem As ToolStripMenuItem
		Private pumpsToolStripMenuItem As ToolStripMenuItem
		Private WithEvents totalCountersToolStripMenuItem As ToolStripMenuItem
		Private WithEvents tsStopAllPumps As ToolStripMenuItem
	End Class
End Namespace
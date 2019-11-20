Namespace TiT.PTS
	Partial Public Class PtsConfigDialog
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
			Dim dataGridViewCellStyle49 As New DataGridViewCellStyle()
			Dim dataGridViewCellStyle53 As New DataGridViewCellStyle()
			Dim dataGridViewCellStyle54 As New DataGridViewCellStyle()
			Dim dataGridViewCellStyle50 As New DataGridViewCellStyle()
			Dim dataGridViewCellStyle51 As New DataGridViewCellStyle()
			Dim dataGridViewCellStyle52 As New DataGridViewCellStyle()
			Dim dataGridViewCellStyle55 As New DataGridViewCellStyle()
			Dim dataGridViewCellStyle59 As New DataGridViewCellStyle()
			Dim dataGridViewCellStyle60 As New DataGridViewCellStyle()
			Dim dataGridViewCellStyle56 As New DataGridViewCellStyle()
			Dim dataGridViewCellStyle57 As New DataGridViewCellStyle()
			Dim dataGridViewCellStyle58 As New DataGridViewCellStyle()
			Dim dataGridViewCellStyle61 As New DataGridViewCellStyle()
			Dim dataGridViewCellStyle65 As New DataGridViewCellStyle()
			Dim dataGridViewCellStyle66 As New DataGridViewCellStyle()
			Dim dataGridViewCellStyle62 As New DataGridViewCellStyle()
			Dim dataGridViewCellStyle63 As New DataGridViewCellStyle()
			Dim dataGridViewCellStyle64 As New DataGridViewCellStyle()
			Dim dataGridViewCellStyle67 As New DataGridViewCellStyle()
			Dim dataGridViewCellStyle71 As New DataGridViewCellStyle()
			Dim dataGridViewCellStyle72 As New DataGridViewCellStyle()
			Dim dataGridViewCellStyle68 As New DataGridViewCellStyle()
			Dim dataGridViewCellStyle69 As New DataGridViewCellStyle()
			Dim dataGridViewCellStyle70 As New DataGridViewCellStyle()
			Me.tabControl1 = New TabControl()
			Me.tabPage1 = New TabPage()
			Me.btnSetPumpConfig = New Button()
			Me.btnGetPumpConfig = New Button()
			Me.lblPumpsConfig = New Label()
			Me.dgvPumpConfig = New DataGridView()
			Me.dataGridViewTextBoxColumn1 = New DataGridViewTextBoxColumn()
			Me.dataGridViewTextBoxColumn2 = New DataGridViewTextBoxColumn()
			Me.dataGridViewTextBoxColumn3 = New DataGridViewTextBoxColumn()
			Me.lblPumpsChConfig = New Label()
			Me.dgvPumpChConfig = New DataGridView()
			Me.Column1 = New DataGridViewTextBoxColumn()
			Me.Column2 = New DataGridViewTextBoxColumn()
			Me.Column3 = New DataGridViewTextBoxColumn()
			Me.tabPage2 = New TabPage()
			Me.btnSetAtgConfig = New Button()
			Me.btnGetAtgConfig = New Button()
			Me.lblAtgsConfig = New Label()
			Me.dgvAtgConfig = New DataGridView()
			Me.dataGridViewTextBoxColumn4 = New DataGridViewTextBoxColumn()
			Me.dataGridViewTextBoxColumn5 = New DataGridViewTextBoxColumn()
			Me.dataGridViewTextBoxColumn6 = New DataGridViewTextBoxColumn()
			Me.lblAtgsChConfig = New Label()
			Me.dgvAtgChConfig = New DataGridView()
			Me.dataGridViewTextBoxColumn7 = New DataGridViewTextBoxColumn()
			Me.dataGridViewTextBoxColumn8 = New DataGridViewTextBoxColumn()
			Me.dataGridViewTextBoxColumn9 = New DataGridViewTextBoxColumn()
			Me.tabPage3 = New TabPage()
			Me.lbl17 = New Label()
			Me.lbl18 = New Label()
			Me.txbParamValue = New TextBox()
			Me.udParamNumber = New NumericUpDown()
			Me.udParamAddress = New NumericUpDown()
			Me.lbl16 = New Label()
			Me.btnSetParameter = New Button()
			Me.btnGetParameter = New Button()
			Me.tabPage4 = New TabPage()
			Me.btnGetVersion = New Button()
			Me.gbResponse = New GroupBox()
			Me.btnClearResponse = New Button()
			Me.tbxResponse = New TextBox()
			Me.tabControl1.SuspendLayout()
			Me.tabPage1.SuspendLayout()
			CType(Me.dgvPumpConfig, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.dgvPumpChConfig, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.tabPage2.SuspendLayout()
			CType(Me.dgvAtgConfig, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.dgvAtgChConfig, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.tabPage3.SuspendLayout()
			CType(Me.udParamNumber, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.udParamAddress, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.tabPage4.SuspendLayout()
			Me.gbResponse.SuspendLayout()
			Me.SuspendLayout()
			' 
			' tabControl1
			' 
			Me.tabControl1.Controls.Add(Me.tabPage1)
			Me.tabControl1.Controls.Add(Me.tabPage2)
			Me.tabControl1.Controls.Add(Me.tabPage3)
			Me.tabControl1.Controls.Add(Me.tabPage4)
			Me.tabControl1.Font = New Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.tabControl1.Location = New Point(12, 12)
			Me.tabControl1.Name = "tabControl1"
			Me.tabControl1.SelectedIndex = 0
			Me.tabControl1.Size = New Size(941, 477)
			Me.tabControl1.TabIndex = 0
			' 
			' tabPage1
			' 
			Me.tabPage1.Controls.Add(Me.btnSetPumpConfig)
			Me.tabPage1.Controls.Add(Me.btnGetPumpConfig)
			Me.tabPage1.Controls.Add(Me.lblPumpsConfig)
			Me.tabPage1.Controls.Add(Me.dgvPumpConfig)
			Me.tabPage1.Controls.Add(Me.lblPumpsChConfig)
			Me.tabPage1.Controls.Add(Me.dgvPumpChConfig)
			Me.tabPage1.Font = New Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			Me.tabPage1.Location = New Point(4, 25)
			Me.tabPage1.Name = "tabPage1"
			Me.tabPage1.Padding = New Padding(3)
			Me.tabPage1.Size = New Size(933, 448)
			Me.tabPage1.TabIndex = 0
			Me.tabPage1.Text = "Pumps configuration"
			Me.tabPage1.UseVisualStyleBackColor = True
			' 
			' btnSetPumpConfig
			' 
			Me.btnSetPumpConfig.Location = New Point(16, 375)
			Me.btnSetPumpConfig.Name = "btnSetPumpConfig"
			Me.btnSetPumpConfig.Size = New Size(427, 43)
			Me.btnSetPumpConfig.TabIndex = 12
			Me.btnSetPumpConfig.Text = "SET PUMP CONFIGURATION"
			Me.btnSetPumpConfig.UseVisualStyleBackColor = True
'			Me.btnSetPumpConfig.Click += New System.EventHandler(Me.btnSetPumpConfig_Click)
			' 
			' btnGetPumpConfig
			' 
			Me.btnGetPumpConfig.Location = New Point(16, 326)
			Me.btnGetPumpConfig.Name = "btnGetPumpConfig"
			Me.btnGetPumpConfig.Size = New Size(427, 43)
			Me.btnGetPumpConfig.TabIndex = 11
			Me.btnGetPumpConfig.Text = "GET PUMP CONFIGURATION"
			Me.btnGetPumpConfig.UseVisualStyleBackColor = True
'			Me.btnGetPumpConfig.Click += New System.EventHandler(Me.btnGetPumpConfig_Click)
			' 
			' lblPumpsConfig
			' 
			Me.lblPumpsConfig.AutoSize = True
			Me.lblPumpsConfig.Location = New Point(485, 21)
			Me.lblPumpsConfig.Name = "lblPumpsConfig"
			Me.lblPumpsConfig.Size = New Size(187, 24)
			Me.lblPumpsConfig.TabIndex = 10
			Me.lblPumpsConfig.Text = "Pumps configuration:"
			' 
			' dgvPumpConfig
			' 
			Me.dgvPumpConfig.AllowUserToAddRows = False
			Me.dgvPumpConfig.AllowUserToDeleteRows = False
			Me.dgvPumpConfig.AllowUserToResizeColumns = False
			Me.dgvPumpConfig.AllowUserToResizeRows = False
			dataGridViewCellStyle49.Alignment = DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle49.BackColor = SystemColors.Control
			dataGridViewCellStyle49.Font = New Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			dataGridViewCellStyle49.ForeColor = SystemColors.WindowText
			dataGridViewCellStyle49.Format = "N0"
			dataGridViewCellStyle49.NullValue = Nothing
			dataGridViewCellStyle49.SelectionBackColor = SystemColors.Highlight
			dataGridViewCellStyle49.SelectionForeColor = SystemColors.HighlightText
			dataGridViewCellStyle49.WrapMode = DataGridViewTriState.True
			Me.dgvPumpConfig.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle49
			Me.dgvPumpConfig.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
			Me.dgvPumpConfig.Columns.AddRange(New DataGridViewColumn() { Me.dataGridViewTextBoxColumn1, Me.dataGridViewTextBoxColumn2, Me.dataGridViewTextBoxColumn3})
			dataGridViewCellStyle53.Alignment = DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle53.BackColor = SystemColors.Window
			dataGridViewCellStyle53.Font = New Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			dataGridViewCellStyle53.ForeColor = SystemColors.ControlText
			dataGridViewCellStyle53.Format = "N0"
			dataGridViewCellStyle53.NullValue = Nothing
			dataGridViewCellStyle53.SelectionBackColor = SystemColors.Highlight
			dataGridViewCellStyle53.SelectionForeColor = SystemColors.HighlightText
			dataGridViewCellStyle53.WrapMode = DataGridViewTriState.False
			Me.dgvPumpConfig.DefaultCellStyle = dataGridViewCellStyle53
			Me.dgvPumpConfig.Location = New Point(489, 48)
			Me.dgvPumpConfig.MultiSelect = False
			Me.dgvPumpConfig.Name = "dgvPumpConfig"
			Me.dgvPumpConfig.RowHeadersWidth = 4
			Me.dgvPumpConfig.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle54.Alignment = DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle54.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			dataGridViewCellStyle54.Format = "N0"
			dataGridViewCellStyle54.NullValue = Nothing
			Me.dgvPumpConfig.RowsDefaultCellStyle = dataGridViewCellStyle54
			Me.dgvPumpConfig.ScrollBars = ScrollBars.None
			Me.dgvPumpConfig.Size = New Size(427, 384)
			Me.dgvPumpConfig.TabIndex = 9
			' 
			' dataGridViewTextBoxColumn1
			' 
			dataGridViewCellStyle50.Alignment = DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle50.BackColor = SystemColors.ControlLight
			dataGridViewCellStyle50.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			dataGridViewCellStyle50.Format = "N0"
			dataGridViewCellStyle50.NullValue = Nothing
			dataGridViewCellStyle50.SelectionBackColor = SystemColors.ControlLight
			dataGridViewCellStyle50.SelectionForeColor = Color.Black
			Me.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle50
			Me.dataGridViewTextBoxColumn1.Frozen = True
			Me.dataGridViewTextBoxColumn1.HeaderText = "Pump log. addr."
			Me.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1"
			Me.dataGridViewTextBoxColumn1.ReadOnly = True
			Me.dataGridViewTextBoxColumn1.Resizable = DataGridViewTriState.False
			Me.dataGridViewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.NotSortable
			Me.dataGridViewTextBoxColumn1.ToolTipText = "Pump log. addr."
			Me.dataGridViewTextBoxColumn1.Width = 140
			' 
			' dataGridViewTextBoxColumn2
			' 
			dataGridViewCellStyle51.Alignment = DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle51.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			dataGridViewCellStyle51.Format = "N0"
			dataGridViewCellStyle51.NullValue = Nothing
			Me.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle51
			Me.dataGridViewTextBoxColumn2.HeaderText = "Pump channel ID"
			Me.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2"
			Me.dataGridViewTextBoxColumn2.Resizable = DataGridViewTriState.False
			Me.dataGridViewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.NotSortable
			Me.dataGridViewTextBoxColumn2.ToolTipText = "Pump channel ID"
			Me.dataGridViewTextBoxColumn2.Width = 140
			' 
			' dataGridViewTextBoxColumn3
			' 
			dataGridViewCellStyle52.Alignment = DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle52.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			dataGridViewCellStyle52.Format = "N0"
			dataGridViewCellStyle52.NullValue = Nothing
			Me.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle52
			Me.dataGridViewTextBoxColumn3.HeaderText = "Pump phys. addr."
			Me.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3"
			Me.dataGridViewTextBoxColumn3.Resizable = DataGridViewTriState.False
			Me.dataGridViewTextBoxColumn3.SortMode = DataGridViewColumnSortMode.NotSortable
			Me.dataGridViewTextBoxColumn3.ToolTipText = "Pump phys. addr."
			Me.dataGridViewTextBoxColumn3.Width = 140
			' 
			' lblPumpsChConfig
			' 
			Me.lblPumpsChConfig.AutoSize = True
			Me.lblPumpsChConfig.Location = New Point(12, 21)
			Me.lblPumpsChConfig.Name = "lblPumpsChConfig"
			Me.lblPumpsChConfig.Size = New Size(260, 24)
			Me.lblPumpsChConfig.TabIndex = 8
			Me.lblPumpsChConfig.Text = "Pump channels configuration:"
			' 
			' dgvPumpChConfig
			' 
			Me.dgvPumpChConfig.AllowUserToAddRows = False
			Me.dgvPumpChConfig.AllowUserToDeleteRows = False
			Me.dgvPumpChConfig.AllowUserToResizeColumns = False
			Me.dgvPumpChConfig.AllowUserToResizeRows = False
			dataGridViewCellStyle55.Alignment = DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle55.BackColor = SystemColors.Control
			dataGridViewCellStyle55.Font = New Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			dataGridViewCellStyle55.ForeColor = SystemColors.WindowText
			dataGridViewCellStyle55.Format = "N0"
			dataGridViewCellStyle55.NullValue = Nothing
			dataGridViewCellStyle55.SelectionBackColor = SystemColors.Highlight
			dataGridViewCellStyle55.SelectionForeColor = SystemColors.HighlightText
			dataGridViewCellStyle55.WrapMode = DataGridViewTriState.True
			Me.dgvPumpChConfig.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle55
			Me.dgvPumpChConfig.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
			Me.dgvPumpChConfig.Columns.AddRange(New DataGridViewColumn() { Me.Column1, Me.Column2, Me.Column3})
			dataGridViewCellStyle59.Alignment = DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle59.BackColor = SystemColors.Window
			dataGridViewCellStyle59.Font = New Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			dataGridViewCellStyle59.ForeColor = SystemColors.ControlText
			dataGridViewCellStyle59.Format = "N0"
			dataGridViewCellStyle59.NullValue = Nothing
			dataGridViewCellStyle59.SelectionBackColor = SystemColors.Highlight
			dataGridViewCellStyle59.SelectionForeColor = SystemColors.HighlightText
			dataGridViewCellStyle59.WrapMode = DataGridViewTriState.False
			Me.dgvPumpChConfig.DefaultCellStyle = dataGridViewCellStyle59
			Me.dgvPumpChConfig.Location = New Point(16, 48)
			Me.dgvPumpChConfig.MultiSelect = False
			Me.dgvPumpChConfig.Name = "dgvPumpChConfig"
			Me.dgvPumpChConfig.RowHeadersWidth = 4
			Me.dgvPumpChConfig.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle60.Alignment = DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle60.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			dataGridViewCellStyle60.Format = "N0"
			dataGridViewCellStyle60.NullValue = Nothing
			Me.dgvPumpChConfig.RowsDefaultCellStyle = dataGridViewCellStyle60
			Me.dgvPumpChConfig.ScrollBars = ScrollBars.None
			Me.dgvPumpChConfig.Size = New Size(427, 135)
			Me.dgvPumpChConfig.TabIndex = 7
			' 
			' Column1
			' 
			dataGridViewCellStyle56.Alignment = DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle56.BackColor = SystemColors.ControlLight
			dataGridViewCellStyle56.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			dataGridViewCellStyle56.Format = "N0"
			dataGridViewCellStyle56.NullValue = Nothing
			dataGridViewCellStyle56.SelectionBackColor = SystemColors.ControlLight
			dataGridViewCellStyle56.SelectionForeColor = Color.Black
			Me.Column1.DefaultCellStyle = dataGridViewCellStyle56
			Me.Column1.Frozen = True
			Me.Column1.HeaderText = "Pump channel ID"
			Me.Column1.Name = "Column1"
			Me.Column1.ReadOnly = True
			Me.Column1.Resizable = DataGridViewTriState.False
			Me.Column1.SortMode = DataGridViewColumnSortMode.NotSortable
			Me.Column1.ToolTipText = "Pump channel ID"
			Me.Column1.Width = 140
			' 
			' Column2
			' 
			dataGridViewCellStyle57.Alignment = DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle57.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			dataGridViewCellStyle57.Format = "N0"
			dataGridViewCellStyle57.NullValue = Nothing
			Me.Column2.DefaultCellStyle = dataGridViewCellStyle57
			Me.Column2.HeaderText = "Protocol ID"
			Me.Column2.Name = "Column2"
			Me.Column2.Resizable = DataGridViewTriState.False
			Me.Column2.SortMode = DataGridViewColumnSortMode.NotSortable
			Me.Column2.ToolTipText = "Protocol ID"
			Me.Column2.Width = 140
			' 
			' Column3
			' 
			dataGridViewCellStyle58.Alignment = DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle58.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			dataGridViewCellStyle58.Format = "N0"
			dataGridViewCellStyle58.NullValue = Nothing
			Me.Column3.DefaultCellStyle = dataGridViewCellStyle58
			Me.Column3.HeaderText = "Baud rate ID"
			Me.Column3.Name = "Column3"
			Me.Column3.Resizable = DataGridViewTriState.False
			Me.Column3.SortMode = DataGridViewColumnSortMode.NotSortable
			Me.Column3.ToolTipText = "Baud rate ID"
			Me.Column3.Width = 140
			' 
			' tabPage2
			' 
			Me.tabPage2.Controls.Add(Me.btnSetAtgConfig)
			Me.tabPage2.Controls.Add(Me.btnGetAtgConfig)
			Me.tabPage2.Controls.Add(Me.lblAtgsConfig)
			Me.tabPage2.Controls.Add(Me.dgvAtgConfig)
			Me.tabPage2.Controls.Add(Me.lblAtgsChConfig)
			Me.tabPage2.Controls.Add(Me.dgvAtgChConfig)
			Me.tabPage2.Font = New Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			Me.tabPage2.Location = New Point(4, 25)
			Me.tabPage2.Name = "tabPage2"
			Me.tabPage2.Padding = New Padding(3)
			Me.tabPage2.Size = New Size(933, 448)
			Me.tabPage2.TabIndex = 1
			Me.tabPage2.Text = "ATGs configuration"
			Me.tabPage2.UseVisualStyleBackColor = True
			' 
			' btnSetAtgConfig
			' 
			Me.btnSetAtgConfig.Location = New Point(16, 375)
			Me.btnSetAtgConfig.Name = "btnSetAtgConfig"
			Me.btnSetAtgConfig.Size = New Size(427, 43)
			Me.btnSetAtgConfig.TabIndex = 18
			Me.btnSetAtgConfig.Text = "SET ATG CONFIGURATION"
			Me.btnSetAtgConfig.UseVisualStyleBackColor = True
'			Me.btnSetAtgConfig.Click += New System.EventHandler(Me.btnSetAtgConfig_Click)
			' 
			' btnGetAtgConfig
			' 
			Me.btnGetAtgConfig.Location = New Point(16, 326)
			Me.btnGetAtgConfig.Name = "btnGetAtgConfig"
			Me.btnGetAtgConfig.Size = New Size(427, 43)
			Me.btnGetAtgConfig.TabIndex = 17
			Me.btnGetAtgConfig.Text = "GET ATG CONFIGURATION"
			Me.btnGetAtgConfig.UseVisualStyleBackColor = True
'			Me.btnGetAtgConfig.Click += New System.EventHandler(Me.btnGetAtgConfig_Click)
			' 
			' lblAtgsConfig
			' 
			Me.lblAtgsConfig.AutoSize = True
			Me.lblAtgsConfig.Location = New Point(485, 21)
			Me.lblAtgsConfig.Name = "lblAtgsConfig"
			Me.lblAtgsConfig.Size = New Size(176, 24)
			Me.lblAtgsConfig.TabIndex = 16
			Me.lblAtgsConfig.Text = "ATGs configuration:"
			' 
			' dgvAtgConfig
			' 
			Me.dgvAtgConfig.AllowUserToAddRows = False
			Me.dgvAtgConfig.AllowUserToDeleteRows = False
			Me.dgvAtgConfig.AllowUserToResizeColumns = False
			Me.dgvAtgConfig.AllowUserToResizeRows = False
			dataGridViewCellStyle61.Alignment = DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle61.BackColor = SystemColors.Control
			dataGridViewCellStyle61.Font = New Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			dataGridViewCellStyle61.ForeColor = SystemColors.WindowText
			dataGridViewCellStyle61.Format = "N0"
			dataGridViewCellStyle61.NullValue = Nothing
			dataGridViewCellStyle61.SelectionBackColor = SystemColors.Highlight
			dataGridViewCellStyle61.SelectionForeColor = SystemColors.HighlightText
			dataGridViewCellStyle61.WrapMode = DataGridViewTriState.True
			Me.dgvAtgConfig.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle61
			Me.dgvAtgConfig.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
			Me.dgvAtgConfig.Columns.AddRange(New DataGridViewColumn() { Me.dataGridViewTextBoxColumn4, Me.dataGridViewTextBoxColumn5, Me.dataGridViewTextBoxColumn6})
			dataGridViewCellStyle65.Alignment = DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle65.BackColor = SystemColors.Window
			dataGridViewCellStyle65.Font = New Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			dataGridViewCellStyle65.ForeColor = SystemColors.ControlText
			dataGridViewCellStyle65.Format = "N0"
			dataGridViewCellStyle65.NullValue = Nothing
			dataGridViewCellStyle65.SelectionBackColor = SystemColors.Highlight
			dataGridViewCellStyle65.SelectionForeColor = SystemColors.HighlightText
			dataGridViewCellStyle65.WrapMode = DataGridViewTriState.False
			Me.dgvAtgConfig.DefaultCellStyle = dataGridViewCellStyle65
			Me.dgvAtgConfig.Location = New Point(489, 48)
			Me.dgvAtgConfig.MultiSelect = False
			Me.dgvAtgConfig.Name = "dgvAtgConfig"
			Me.dgvAtgConfig.RowHeadersWidth = 4
			Me.dgvAtgConfig.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle66.Alignment = DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle66.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			dataGridViewCellStyle66.Format = "N0"
			dataGridViewCellStyle66.NullValue = Nothing
			Me.dgvAtgConfig.RowsDefaultCellStyle = dataGridViewCellStyle66
			Me.dgvAtgConfig.ScrollBars = ScrollBars.None
			Me.dgvAtgConfig.Size = New Size(427, 384)
			Me.dgvAtgConfig.TabIndex = 15
			' 
			' dataGridViewTextBoxColumn4
			' 
			dataGridViewCellStyle62.Alignment = DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle62.BackColor = SystemColors.ControlLight
			dataGridViewCellStyle62.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			dataGridViewCellStyle62.Format = "N0"
			dataGridViewCellStyle62.NullValue = Nothing
			dataGridViewCellStyle62.SelectionBackColor = SystemColors.ControlLight
			dataGridViewCellStyle62.SelectionForeColor = Color.Black
			Me.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle62
			Me.dataGridViewTextBoxColumn4.Frozen = True
			Me.dataGridViewTextBoxColumn4.HeaderText = "ATG log. addr."
			Me.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4"
			Me.dataGridViewTextBoxColumn4.ReadOnly = True
			Me.dataGridViewTextBoxColumn4.Resizable = DataGridViewTriState.False
			Me.dataGridViewTextBoxColumn4.SortMode = DataGridViewColumnSortMode.NotSortable
			Me.dataGridViewTextBoxColumn4.ToolTipText = "ATG log. addr."
			Me.dataGridViewTextBoxColumn4.Width = 140
			' 
			' dataGridViewTextBoxColumn5
			' 
			dataGridViewCellStyle63.Alignment = DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle63.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			dataGridViewCellStyle63.Format = "N0"
			dataGridViewCellStyle63.NullValue = Nothing
			Me.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle63
			Me.dataGridViewTextBoxColumn5.HeaderText = "ATG channel ID"
			Me.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5"
			Me.dataGridViewTextBoxColumn5.Resizable = DataGridViewTriState.False
			Me.dataGridViewTextBoxColumn5.SortMode = DataGridViewColumnSortMode.NotSortable
			Me.dataGridViewTextBoxColumn5.ToolTipText = "ATG channel ID"
			Me.dataGridViewTextBoxColumn5.Width = 140
			' 
			' dataGridViewTextBoxColumn6
			' 
			dataGridViewCellStyle64.Alignment = DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle64.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			dataGridViewCellStyle64.Format = "N0"
			dataGridViewCellStyle64.NullValue = Nothing
			Me.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle64
			Me.dataGridViewTextBoxColumn6.HeaderText = "ATG phys. addr."
			Me.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6"
			Me.dataGridViewTextBoxColumn6.Resizable = DataGridViewTriState.False
			Me.dataGridViewTextBoxColumn6.SortMode = DataGridViewColumnSortMode.NotSortable
			Me.dataGridViewTextBoxColumn6.ToolTipText = "ATG phys. addr."
			Me.dataGridViewTextBoxColumn6.Width = 140
			' 
			' lblAtgsChConfig
			' 
			Me.lblAtgsChConfig.AutoSize = True
			Me.lblAtgsChConfig.Location = New Point(12, 21)
			Me.lblAtgsChConfig.Name = "lblAtgsChConfig"
			Me.lblAtgsChConfig.Size = New Size(249, 24)
			Me.lblAtgsChConfig.TabIndex = 14
			Me.lblAtgsChConfig.Text = "ATG channels configuration:"
			' 
			' dgvAtgChConfig
			' 
			Me.dgvAtgChConfig.AllowUserToAddRows = False
			Me.dgvAtgChConfig.AllowUserToDeleteRows = False
			Me.dgvAtgChConfig.AllowUserToResizeColumns = False
			Me.dgvAtgChConfig.AllowUserToResizeRows = False
			dataGridViewCellStyle67.Alignment = DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle67.BackColor = SystemColors.Control
			dataGridViewCellStyle67.Font = New Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			dataGridViewCellStyle67.ForeColor = SystemColors.WindowText
			dataGridViewCellStyle67.Format = "N0"
			dataGridViewCellStyle67.NullValue = Nothing
			dataGridViewCellStyle67.SelectionBackColor = SystemColors.Highlight
			dataGridViewCellStyle67.SelectionForeColor = SystemColors.HighlightText
			dataGridViewCellStyle67.WrapMode = DataGridViewTriState.True
			Me.dgvAtgChConfig.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle67
			Me.dgvAtgChConfig.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
			Me.dgvAtgChConfig.Columns.AddRange(New DataGridViewColumn() { Me.dataGridViewTextBoxColumn7, Me.dataGridViewTextBoxColumn8, Me.dataGridViewTextBoxColumn9})
			dataGridViewCellStyle71.Alignment = DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle71.BackColor = SystemColors.Window
			dataGridViewCellStyle71.Font = New Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			dataGridViewCellStyle71.ForeColor = SystemColors.ControlText
			dataGridViewCellStyle71.Format = "N0"
			dataGridViewCellStyle71.NullValue = Nothing
			dataGridViewCellStyle71.SelectionBackColor = SystemColors.Highlight
			dataGridViewCellStyle71.SelectionForeColor = SystemColors.HighlightText
			dataGridViewCellStyle71.WrapMode = DataGridViewTriState.False
			Me.dgvAtgChConfig.DefaultCellStyle = dataGridViewCellStyle71
			Me.dgvAtgChConfig.Location = New Point(16, 48)
			Me.dgvAtgChConfig.MultiSelect = False
			Me.dgvAtgChConfig.Name = "dgvAtgChConfig"
			Me.dgvAtgChConfig.RowHeadersWidth = 4
			Me.dgvAtgChConfig.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle72.Alignment = DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle72.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			dataGridViewCellStyle72.Format = "N0"
			dataGridViewCellStyle72.NullValue = Nothing
			Me.dgvAtgChConfig.RowsDefaultCellStyle = dataGridViewCellStyle72
			Me.dgvAtgChConfig.ScrollBars = ScrollBars.None
			Me.dgvAtgChConfig.Size = New Size(427, 135)
			Me.dgvAtgChConfig.TabIndex = 13
			' 
			' dataGridViewTextBoxColumn7
			' 
			dataGridViewCellStyle68.Alignment = DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle68.BackColor = SystemColors.ControlLight
			dataGridViewCellStyle68.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			dataGridViewCellStyle68.Format = "N0"
			dataGridViewCellStyle68.NullValue = Nothing
			dataGridViewCellStyle68.SelectionBackColor = SystemColors.ControlLight
			dataGridViewCellStyle68.SelectionForeColor = Color.Black
			Me.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle68
			Me.dataGridViewTextBoxColumn7.Frozen = True
			Me.dataGridViewTextBoxColumn7.HeaderText = "ATG channel ID"
			Me.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7"
			Me.dataGridViewTextBoxColumn7.ReadOnly = True
			Me.dataGridViewTextBoxColumn7.Resizable = DataGridViewTriState.False
			Me.dataGridViewTextBoxColumn7.SortMode = DataGridViewColumnSortMode.NotSortable
			Me.dataGridViewTextBoxColumn7.ToolTipText = "ATG channel ID"
			Me.dataGridViewTextBoxColumn7.Width = 140
			' 
			' dataGridViewTextBoxColumn8
			' 
			dataGridViewCellStyle69.Alignment = DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle69.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			dataGridViewCellStyle69.Format = "N0"
			dataGridViewCellStyle69.NullValue = Nothing
			Me.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle69
			Me.dataGridViewTextBoxColumn8.HeaderText = "Protocol ID"
			Me.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8"
			Me.dataGridViewTextBoxColumn8.Resizable = DataGridViewTriState.False
			Me.dataGridViewTextBoxColumn8.SortMode = DataGridViewColumnSortMode.NotSortable
			Me.dataGridViewTextBoxColumn8.ToolTipText = "Protocol ID"
			Me.dataGridViewTextBoxColumn8.Width = 140
			' 
			' dataGridViewTextBoxColumn9
			' 
			dataGridViewCellStyle70.Alignment = DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle70.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			dataGridViewCellStyle70.Format = "N0"
			dataGridViewCellStyle70.NullValue = Nothing
			Me.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle70
			Me.dataGridViewTextBoxColumn9.HeaderText = "Baud rate ID"
			Me.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9"
			Me.dataGridViewTextBoxColumn9.Resizable = DataGridViewTriState.False
			Me.dataGridViewTextBoxColumn9.SortMode = DataGridViewColumnSortMode.NotSortable
			Me.dataGridViewTextBoxColumn9.ToolTipText = "Baud rate ID"
			Me.dataGridViewTextBoxColumn9.Width = 140
			' 
			' tabPage3
			' 
			Me.tabPage3.Controls.Add(Me.lbl17)
			Me.tabPage3.Controls.Add(Me.lbl18)
			Me.tabPage3.Controls.Add(Me.txbParamValue)
			Me.tabPage3.Controls.Add(Me.udParamNumber)
			Me.tabPage3.Controls.Add(Me.udParamAddress)
			Me.tabPage3.Controls.Add(Me.lbl16)
			Me.tabPage3.Controls.Add(Me.btnSetParameter)
			Me.tabPage3.Controls.Add(Me.btnGetParameter)
			Me.tabPage3.Font = New Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.tabPage3.Location = New Point(4, 25)
			Me.tabPage3.Name = "tabPage3"
			Me.tabPage3.Padding = New Padding(3)
			Me.tabPage3.Size = New Size(933, 448)
			Me.tabPage3.TabIndex = 2
			Me.tabPage3.Text = "Parameters"
			Me.tabPage3.UseVisualStyleBackColor = True
			' 
			' lbl17
			' 
			Me.lbl17.AutoSize = True
			Me.lbl17.Font = New Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.lbl17.ForeColor = SystemColors.ControlDarkDark
			Me.lbl17.Location = New Point(122, 131)
			Me.lbl17.Name = "lbl17"
			Me.lbl17.Size = New Size(183, 24)
			Me.lbl17.TabIndex = 40
			Me.lbl17.Text = "Parameter number"
			Me.lbl17.TextAlign = ContentAlignment.MiddleRight
			' 
			' lbl18
			' 
			Me.lbl18.AutoSize = True
			Me.lbl18.Font = New Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.lbl18.ForeColor = SystemColors.ControlDarkDark
			Me.lbl18.Location = New Point(89, 173)
			Me.lbl18.Name = "lbl18"
			Me.lbl18.Size = New Size(216, 24)
			Me.lbl18.TabIndex = 39
			Me.lbl18.Text = "Parameter value (hex)"
			Me.lbl18.TextAlign = ContentAlignment.MiddleRight
			' 
			' txbParamValue
			' 
			Me.txbParamValue.Location = New Point(332, 170)
			Me.txbParamValue.Name = "txbParamValue"
			Me.txbParamValue.Size = New Size(110, 29)
			Me.txbParamValue.TabIndex = 38
			Me.txbParamValue.Text = "00000001"
			Me.txbParamValue.TextAlign = HorizontalAlignment.Center
			' 
			' udParamNumber
			' 
			Me.udParamNumber.Location = New Point(332, 129)
			Me.udParamNumber.Maximum = New Decimal(New Integer() { 9999, 0, 0, 0})
			Me.udParamNumber.Name = "udParamNumber"
			Me.udParamNumber.Size = New Size(110, 29)
			Me.udParamNumber.TabIndex = 37
			Me.udParamNumber.TextAlign = HorizontalAlignment.Center
			Me.udParamNumber.Value = New Decimal(New Integer() { 1, 0, 0, 0})
			' 
			' udParamAddress
			' 
			Me.udParamAddress.Location = New Point(332, 88)
			Me.udParamAddress.Maximum = New Decimal(New Integer() { 16, 0, 0, 0})
			Me.udParamAddress.Name = "udParamAddress"
			Me.udParamAddress.Size = New Size(110, 29)
			Me.udParamAddress.TabIndex = 36
			Me.udParamAddress.TextAlign = HorizontalAlignment.Center
			Me.udParamAddress.Value = New Decimal(New Integer() { 1, 0, 0, 0})
			' 
			' lbl16
			' 
			Me.lbl16.AutoSize = True
			Me.lbl16.Font = New Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.lbl16.ForeColor = SystemColors.ControlDarkDark
			Me.lbl16.Location = New Point(120, 90)
			Me.lbl16.Name = "lbl16"
			Me.lbl16.Size = New Size(185, 24)
			Me.lbl16.TabIndex = 35
			Me.lbl16.Text = "Parameter address"
			Me.lbl16.TextAlign = ContentAlignment.MiddleRight
			' 
			' btnSetParameter
			' 
			Me.btnSetParameter.Font = New Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			Me.btnSetParameter.Location = New Point(16, 375)
			Me.btnSetParameter.Name = "btnSetParameter"
			Me.btnSetParameter.Size = New Size(427, 43)
			Me.btnSetParameter.TabIndex = 34
			Me.btnSetParameter.Text = "SET PARAMETER"
			Me.btnSetParameter.UseVisualStyleBackColor = True
'			Me.btnSetParameter.Click += New System.EventHandler(Me.btnSetParameter_Click)
			' 
			' btnGetParameter
			' 
			Me.btnGetParameter.Font = New Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			Me.btnGetParameter.Location = New Point(16, 326)
			Me.btnGetParameter.Name = "btnGetParameter"
			Me.btnGetParameter.Size = New Size(427, 43)
			Me.btnGetParameter.TabIndex = 33
			Me.btnGetParameter.Text = "GET PARAMETER"
			Me.btnGetParameter.UseVisualStyleBackColor = True
'			Me.btnGetParameter.Click += New System.EventHandler(Me.btnGetParameter_Click)
			' 
			' tabPage4
			' 
			Me.tabPage4.Controls.Add(Me.btnGetVersion)
			Me.tabPage4.Location = New Point(4, 25)
			Me.tabPage4.Name = "tabPage4"
			Me.tabPage4.Padding = New Padding(3)
			Me.tabPage4.Size = New Size(933, 448)
			Me.tabPage4.TabIndex = 3
			Me.tabPage4.Text = "Version information"
			Me.tabPage4.UseVisualStyleBackColor = True
			' 
			' btnGetVersion
			' 
			Me.btnGetVersion.Font = New Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			Me.btnGetVersion.Location = New Point(16, 72)
			Me.btnGetVersion.Name = "btnGetVersion"
			Me.btnGetVersion.Size = New Size(427, 43)
			Me.btnGetVersion.TabIndex = 34
			Me.btnGetVersion.Text = "GET VERSION"
			Me.btnGetVersion.UseVisualStyleBackColor = True
'			Me.btnGetVersion.Click += New System.EventHandler(Me.btnGetVersion_Click)
			' 
			' gbResponse
			' 
			Me.gbResponse.Controls.Add(Me.btnClearResponse)
			Me.gbResponse.Controls.Add(Me.tbxResponse)
			Me.gbResponse.Font = New Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.gbResponse.Location = New Point(16, 495)
			Me.gbResponse.Name = "gbResponse"
			Me.gbResponse.Size = New Size(937, 145)
			Me.gbResponse.TabIndex = 17
			Me.gbResponse.TabStop = False
			Me.gbResponse.Text = "Response"
			' 
			' btnClearResponse
			' 
			Me.btnClearResponse.Location = New Point(834, 107)
			Me.btnClearResponse.Name = "btnClearResponse"
			Me.btnClearResponse.Size = New Size(97, 32)
			Me.btnClearResponse.TabIndex = 17
			Me.btnClearResponse.Text = "Clear"
			Me.btnClearResponse.UseVisualStyleBackColor = True
'			Me.btnClearResponse.Click += New System.EventHandler(Me.btnClearResponse_Click)
			' 
			' tbxResponse
			' 
			Me.tbxResponse.BackColor = Color.White
			Me.tbxResponse.Font = New Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			Me.tbxResponse.Location = New Point(10, 19)
			Me.tbxResponse.Multiline = True
			Me.tbxResponse.Name = "tbxResponse"
			Me.tbxResponse.ReadOnly = True
			Me.tbxResponse.ScrollBars = ScrollBars.Vertical
			Me.tbxResponse.Size = New Size(813, 120)
			Me.tbxResponse.TabIndex = 16
			' 
			' PtsConfigDialog
			' 
			Me.AutoScaleDimensions = New SizeF(6F, 13F)
			Me.AutoScaleMode = AutoScaleMode.Font
			Me.ClientSize = New Size(964, 649)
			Me.Controls.Add(Me.gbResponse)
			Me.Controls.Add(Me.tabControl1)
			Me.Name = "PtsConfigDialog"
			Me.Text = "PTS configuration"
'			Me.Shown += New System.EventHandler(Me.PtsConfiguration_Shown)
			Me.tabControl1.ResumeLayout(False)
			Me.tabPage1.ResumeLayout(False)
			Me.tabPage1.PerformLayout()
			CType(Me.dgvPumpConfig, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.dgvPumpChConfig, System.ComponentModel.ISupportInitialize).EndInit()
			Me.tabPage2.ResumeLayout(False)
			Me.tabPage2.PerformLayout()
			CType(Me.dgvAtgConfig, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.dgvAtgChConfig, System.ComponentModel.ISupportInitialize).EndInit()
			Me.tabPage3.ResumeLayout(False)
			Me.tabPage3.PerformLayout()
			CType(Me.udParamNumber, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.udParamAddress, System.ComponentModel.ISupportInitialize).EndInit()
			Me.tabPage4.ResumeLayout(False)
			Me.gbResponse.ResumeLayout(False)
			Me.gbResponse.PerformLayout()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private tabControl1 As TabControl
		Private tabPage1 As TabPage
		Private tabPage2 As TabPage
		Private WithEvents btnSetPumpConfig As Button
		Private WithEvents btnGetPumpConfig As Button
		Private lblPumpsConfig As Label
		Private dgvPumpConfig As DataGridView
		Private dataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
		Private dataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
		Private dataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
		Private lblPumpsChConfig As Label
		Private dgvPumpChConfig As DataGridView
		Private Column1 As DataGridViewTextBoxColumn
		Private Column2 As DataGridViewTextBoxColumn
		Private Column3 As DataGridViewTextBoxColumn
		Private WithEvents btnSetAtgConfig As Button
		Private WithEvents btnGetAtgConfig As Button
		Private lblAtgsConfig As Label
		Private dgvAtgConfig As DataGridView
		Private dataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
		Private dataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
		Private dataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
		Private lblAtgsChConfig As Label
		Private dgvAtgChConfig As DataGridView
		Private dataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
		Private dataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
		Private dataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
		Private tabPage3 As TabPage
		Private lbl17 As Label
		Private lbl18 As Label
		Private txbParamValue As TextBox
		Private udParamNumber As NumericUpDown
		Private udParamAddress As NumericUpDown
		Private lbl16 As Label
		Private WithEvents btnSetParameter As Button
		Private WithEvents btnGetParameter As Button
		Private tabPage4 As TabPage
		Private gbResponse As GroupBox
		Private WithEvents btnClearResponse As Button
		Private tbxResponse As TextBox
		Private WithEvents btnGetVersion As Button
	End Class
End Namespace
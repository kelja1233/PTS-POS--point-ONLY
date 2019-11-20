Namespace TiT.PTS
	Partial Public Class AllTotalsDialog
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
			Dim dataGridViewCellStyle5 As New DataGridViewCellStyle()
			Dim dataGridViewCellStyle8 As New DataGridViewCellStyle()
			Dim dataGridViewCellStyle6 As New DataGridViewCellStyle()
			Dim dataGridViewCellStyle7 As New DataGridViewCellStyle()
			Me.btnRebuildTable = New Button()
			Me.cbhDisplayNonZeroNozzles = New CheckBox()
			Me.updateLabel = New Label()
			Me.tblTotals = New DataGridView()
			Me.PumpsColumn = New DataGridViewTextBoxColumn()
			Me.Nozzles = New DataGridViewTextBoxColumn()
			Me.VolumeTotalCounters = New DataGridViewTextBoxColumn()
			Me.AmountTotalCounters = New DataGridViewTextBoxColumn()
			Me.pbTotalsRequest = New PictureBox()
			Me.timer1 = New Timer(Me.components)
			CType(Me.tblTotals, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.pbTotalsRequest, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' btnRebuildTable
			' 
			Me.btnRebuildTable.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.btnRebuildTable.Location = New Point(12, 10)
			Me.btnRebuildTable.Name = "btnRebuildTable"
			Me.btnRebuildTable.Size = New Size(150, 23)
			Me.btnRebuildTable.TabIndex = 1
			Me.btnRebuildTable.Text = "Rebuild table"
			Me.btnRebuildTable.UseVisualStyleBackColor = True
'			Me.btnRebuildTable.Click += New System.EventHandler(Me.btnRebuildTable_Click)
			' 
			' cbhDisplayNonZeroNozzles
			' 
			Me.cbhDisplayNonZeroNozzles.AutoSize = True
			Me.cbhDisplayNonZeroNozzles.Checked = True
			Me.cbhDisplayNonZeroNozzles.CheckState = CheckState.Checked
			Me.cbhDisplayNonZeroNozzles.Location = New Point(168, 14)
			Me.cbhDisplayNonZeroNozzles.Name = "cbhDisplayNonZeroNozzles"
			Me.cbhDisplayNonZeroNozzles.Size = New Size(212, 17)
			Me.cbhDisplayNonZeroNozzles.TabIndex = 2
			Me.cbhDisplayNonZeroNozzles.Text = "Display only nozzles with non zero price"
			Me.cbhDisplayNonZeroNozzles.UseVisualStyleBackColor = True
			' 
			' updateLabel
			' 
			Me.updateLabel.AutoSize = True
			Me.updateLabel.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.updateLabel.Location = New Point(12, 40)
			Me.updateLabel.Name = "updateLabel"
			Me.updateLabel.Size = New Size(77, 13)
			Me.updateLabel.TabIndex = 4
			Me.updateLabel.Text = "updateLabel"
			' 
			' tblTotals
			' 
			Me.tblTotals.AllowUserToAddRows = False
			Me.tblTotals.AllowUserToDeleteRows = False
			Me.tblTotals.AllowUserToResizeColumns = False
			Me.tblTotals.AllowUserToResizeRows = False
			Me.tblTotals.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
			dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle5.BackColor = SystemColors.Control
			dataGridViewCellStyle5.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			dataGridViewCellStyle5.ForeColor = SystemColors.WindowText
			dataGridViewCellStyle5.Padding = New Padding(3)
			dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight
			dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText
			dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True
			Me.tblTotals.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5
			Me.tblTotals.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
			Me.tblTotals.Columns.AddRange(New DataGridViewColumn() { Me.PumpsColumn, Me.Nozzles, Me.VolumeTotalCounters, Me.AmountTotalCounters})
			dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle8.BackColor = SystemColors.Window
			dataGridViewCellStyle8.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			dataGridViewCellStyle8.ForeColor = SystemColors.ControlText
			dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight
			dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText
			dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False
			Me.tblTotals.DefaultCellStyle = dataGridViewCellStyle8
			Me.tblTotals.Location = New Point(12, 69)
			Me.tblTotals.MultiSelect = False
			Me.tblTotals.Name = "tblTotals"
			Me.tblTotals.ReadOnly = True
			Me.tblTotals.RowHeadersVisible = False
			Me.tblTotals.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
			Me.tblTotals.ScrollBars = ScrollBars.None
			Me.tblTotals.SelectionMode = DataGridViewSelectionMode.FullRowSelect
			Me.tblTotals.Size = New Size(504, 123)
			Me.tblTotals.TabIndex = 5
			' 
			' PumpsColumn
			' 
			dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle6.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.PumpsColumn.DefaultCellStyle = dataGridViewCellStyle6
			Me.PumpsColumn.Frozen = True
			Me.PumpsColumn.HeaderText = "Pumps"
			Me.PumpsColumn.Name = "PumpsColumn"
			Me.PumpsColumn.ReadOnly = True
			Me.PumpsColumn.Resizable = DataGridViewTriState.False
			Me.PumpsColumn.SortMode = DataGridViewColumnSortMode.NotSortable
			Me.PumpsColumn.ToolTipText = "Pumps"
			' 
			' Nozzles
			' 
			dataGridViewCellStyle7.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))
			Me.Nozzles.DefaultCellStyle = dataGridViewCellStyle7
			Me.Nozzles.Frozen = True
			Me.Nozzles.HeaderText = "Nozzles"
			Me.Nozzles.Name = "Nozzles"
			Me.Nozzles.ReadOnly = True
			Me.Nozzles.Resizable = DataGridViewTriState.False
			Me.Nozzles.SortMode = DataGridViewColumnSortMode.NotSortable
			Me.Nozzles.ToolTipText = "Nozzles"
			' 
			' VolumeTotalCounters
			' 
			Me.VolumeTotalCounters.Frozen = True
			Me.VolumeTotalCounters.HeaderText = "Volume total counters"
			Me.VolumeTotalCounters.Name = "VolumeTotalCounters"
			Me.VolumeTotalCounters.ReadOnly = True
			Me.VolumeTotalCounters.Resizable = DataGridViewTriState.False
			Me.VolumeTotalCounters.SortMode = DataGridViewColumnSortMode.NotSortable
			Me.VolumeTotalCounters.ToolTipText = "Volume total counters"
			Me.VolumeTotalCounters.Width = 150
			' 
			' AmountTotalCounters
			' 
			Me.AmountTotalCounters.Frozen = True
			Me.AmountTotalCounters.HeaderText = "Amount total counters"
			Me.AmountTotalCounters.Name = "AmountTotalCounters"
			Me.AmountTotalCounters.ReadOnly = True
			Me.AmountTotalCounters.Resizable = DataGridViewTriState.False
			Me.AmountTotalCounters.SortMode = DataGridViewColumnSortMode.NotSortable
			Me.AmountTotalCounters.ToolTipText = "Amount total counters"
			Me.AmountTotalCounters.Width = 150
			' 
			' pbTotalsRequest
			' 
			Me.pbTotalsRequest.Image = My.Resources.ajax_loader
			Me.pbTotalsRequest.InitialImage = My.Resources.totalsRequest
			Me.pbTotalsRequest.Location = New Point(496, 14)
			Me.pbTotalsRequest.Name = "pbTotalsRequest"
			Me.pbTotalsRequest.Size = New Size(20, 20)
			Me.pbTotalsRequest.TabIndex = 8
			Me.pbTotalsRequest.TabStop = False
			Me.pbTotalsRequest.Visible = False
			' 
			' timer1
			' 
			Me.timer1.Interval = 5000
			' 
			' AllTotalsDialog
			' 
			Me.AutoScaleDimensions = New SizeF(6F, 13F)
			Me.AutoScaleMode = AutoScaleMode.Font
			Me.AutoScroll = True
			Me.ClientSize = New Size(540, 447)
			Me.Controls.Add(Me.pbTotalsRequest)
			Me.Controls.Add(Me.tblTotals)
			Me.Controls.Add(Me.updateLabel)
			Me.Controls.Add(Me.cbhDisplayNonZeroNozzles)
			Me.Controls.Add(Me.btnRebuildTable)
			Me.Name = "AllTotalsDialog"
			Me.StartPosition = FormStartPosition.CenterScreen
			Me.Text = "Pumps volume and money amount total counters"
'			Me.Shown += New System.EventHandler(Me.AllTotalsDialog_Shown)
			CType(Me.tblTotals, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.pbTotalsRequest, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private WithEvents btnRebuildTable As Button
		Private cbhDisplayNonZeroNozzles As CheckBox
		Private updateLabel As Label
		Private tblTotals As DataGridView
		Private pbTotalsRequest As PictureBox
		Private PumpsColumn As DataGridViewTextBoxColumn
		Private Nozzles As DataGridViewTextBoxColumn
		Private VolumeTotalCounters As DataGridViewTextBoxColumn
		Private AmountTotalCounters As DataGridViewTextBoxColumn
		Private timer1 As Timer
	End Class
End Namespace
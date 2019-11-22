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
      Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Me.btnRebuildTable = New System.Windows.Forms.Button()
      Me.cbhDisplayNonZeroNozzles = New System.Windows.Forms.CheckBox()
      Me.updateLabel = New System.Windows.Forms.Label()
      Me.tblTotals = New System.Windows.Forms.DataGridView()
      Me.PumpsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Nozzles = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.VolumeTotalCounters = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.AmountTotalCounters = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.pbTotalsRequest = New System.Windows.Forms.PictureBox()
      Me.timer1 = New System.Windows.Forms.Timer(Me.components)
      Me.btChangeShift = New System.Windows.Forms.Button()
      Me.btEndShift = New System.Windows.Forms.Button()
      Me.Button1 = New System.Windows.Forms.Button()
      CType(Me.tblTotals, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.pbTotalsRequest, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'btnRebuildTable
      '
      Me.btnRebuildTable.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
      Me.btnRebuildTable.Location = New System.Drawing.Point(12, 10)
      Me.btnRebuildTable.Name = "btnRebuildTable"
      Me.btnRebuildTable.Size = New System.Drawing.Size(150, 23)
      Me.btnRebuildTable.TabIndex = 1
      Me.btnRebuildTable.Text = "Rebuild table"
      Me.btnRebuildTable.UseVisualStyleBackColor = True
      '
      'cbhDisplayNonZeroNozzles
      '
      Me.cbhDisplayNonZeroNozzles.AutoSize = True
      Me.cbhDisplayNonZeroNozzles.Checked = True
      Me.cbhDisplayNonZeroNozzles.CheckState = System.Windows.Forms.CheckState.Checked
      Me.cbhDisplayNonZeroNozzles.Location = New System.Drawing.Point(168, 14)
      Me.cbhDisplayNonZeroNozzles.Name = "cbhDisplayNonZeroNozzles"
      Me.cbhDisplayNonZeroNozzles.Size = New System.Drawing.Size(212, 17)
      Me.cbhDisplayNonZeroNozzles.TabIndex = 2
      Me.cbhDisplayNonZeroNozzles.Text = "Display only nozzles with non zero price"
      Me.cbhDisplayNonZeroNozzles.UseVisualStyleBackColor = True
      '
      'updateLabel
      '
      Me.updateLabel.AutoSize = True
      Me.updateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
      Me.updateLabel.Location = New System.Drawing.Point(12, 40)
      Me.updateLabel.Name = "updateLabel"
      Me.updateLabel.Size = New System.Drawing.Size(77, 13)
      Me.updateLabel.TabIndex = 4
      Me.updateLabel.Text = "updateLabel"
      '
      'tblTotals
      '
      Me.tblTotals.AllowUserToAddRows = False
      Me.tblTotals.AllowUserToDeleteRows = False
      Me.tblTotals.AllowUserToResizeColumns = False
      Me.tblTotals.AllowUserToResizeRows = False
      Me.tblTotals.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
      DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
      DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle9.Padding = New System.Windows.Forms.Padding(3)
      DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.tblTotals.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
      Me.tblTotals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.tblTotals.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PumpsColumn, Me.Nozzles, Me.VolumeTotalCounters, Me.AmountTotalCounters})
      DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
      DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
      DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
      DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
      Me.tblTotals.DefaultCellStyle = DataGridViewCellStyle12
      Me.tblTotals.Location = New System.Drawing.Point(12, 81)
      Me.tblTotals.MultiSelect = False
      Me.tblTotals.Name = "tblTotals"
      Me.tblTotals.ReadOnly = True
      Me.tblTotals.RowHeadersVisible = False
      Me.tblTotals.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
      Me.tblTotals.ScrollBars = System.Windows.Forms.ScrollBars.None
      Me.tblTotals.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.tblTotals.Size = New System.Drawing.Size(504, 123)
      Me.tblTotals.TabIndex = 5
      '
      'PumpsColumn
      '
      DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
      Me.PumpsColumn.DefaultCellStyle = DataGridViewCellStyle10
      Me.PumpsColumn.Frozen = True
      Me.PumpsColumn.HeaderText = "Pumps"
      Me.PumpsColumn.Name = "PumpsColumn"
      Me.PumpsColumn.ReadOnly = True
      Me.PumpsColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
      Me.PumpsColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
      Me.PumpsColumn.ToolTipText = "Pumps"
      '
      'Nozzles
      '
      DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
      Me.Nozzles.DefaultCellStyle = DataGridViewCellStyle11
      Me.Nozzles.Frozen = True
      Me.Nozzles.HeaderText = "Nozzles"
      Me.Nozzles.Name = "Nozzles"
      Me.Nozzles.ReadOnly = True
      Me.Nozzles.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
      Me.Nozzles.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
      Me.Nozzles.ToolTipText = "Nozzles"
      '
      'VolumeTotalCounters
      '
      Me.VolumeTotalCounters.Frozen = True
      Me.VolumeTotalCounters.HeaderText = "Volume total counters"
      Me.VolumeTotalCounters.Name = "VolumeTotalCounters"
      Me.VolumeTotalCounters.ReadOnly = True
      Me.VolumeTotalCounters.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
      Me.VolumeTotalCounters.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
      Me.VolumeTotalCounters.ToolTipText = "Volume total counters"
      Me.VolumeTotalCounters.Width = 150
      '
      'AmountTotalCounters
      '
      Me.AmountTotalCounters.Frozen = True
      Me.AmountTotalCounters.HeaderText = "Amount total counters"
      Me.AmountTotalCounters.Name = "AmountTotalCounters"
      Me.AmountTotalCounters.ReadOnly = True
      Me.AmountTotalCounters.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
      Me.AmountTotalCounters.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
      Me.AmountTotalCounters.ToolTipText = "Amount total counters"
      Me.AmountTotalCounters.Width = 150
      '
      'pbTotalsRequest
      '
      Me.pbTotalsRequest.Image = Global.My.Resources.Resources.ajax_loader
      Me.pbTotalsRequest.InitialImage = Global.My.Resources.Resources.totalsRequest
      Me.pbTotalsRequest.Location = New System.Drawing.Point(496, 14)
      Me.pbTotalsRequest.Name = "pbTotalsRequest"
      Me.pbTotalsRequest.Size = New System.Drawing.Size(20, 20)
      Me.pbTotalsRequest.TabIndex = 8
      Me.pbTotalsRequest.TabStop = False
      Me.pbTotalsRequest.Visible = False
      '
      'timer1
      '
      Me.timer1.Interval = 5000
      '
      'btChangeShift
      '
      Me.btChangeShift.Enabled = False
      Me.btChangeShift.Location = New System.Drawing.Point(270, 29)
      Me.btChangeShift.Name = "btChangeShift"
      Me.btChangeShift.Size = New System.Drawing.Size(75, 47)
      Me.btChangeShift.TabIndex = 9
      Me.btChangeShift.Text = "Change Shift"
      Me.btChangeShift.UseVisualStyleBackColor = True
      '
      'btEndShift
      '
      Me.btEndShift.Enabled = False
      Me.btEndShift.Location = New System.Drawing.Point(351, 29)
      Me.btEndShift.Name = "btEndShift"
      Me.btEndShift.Size = New System.Drawing.Size(75, 47)
      Me.btEndShift.TabIndex = 10
      Me.btEndShift.Text = "End Shift"
      Me.btEndShift.UseVisualStyleBackColor = True
      '
      'Button1
      '
      Me.Button1.Location = New System.Drawing.Point(432, 28)
      Me.Button1.Name = "Button1"
      Me.Button1.Size = New System.Drawing.Size(75, 47)
      Me.Button1.TabIndex = 11
      Me.Button1.Text = "EXIT"
      Me.Button1.UseVisualStyleBackColor = True
      '
      'AllTotalsDialog
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.AutoScroll = True
      Me.ClientSize = New System.Drawing.Size(540, 447)
      Me.ControlBox = False
      Me.Controls.Add(Me.Button1)
      Me.Controls.Add(Me.btEndShift)
      Me.Controls.Add(Me.btChangeShift)
      Me.Controls.Add(Me.pbTotalsRequest)
      Me.Controls.Add(Me.tblTotals)
      Me.Controls.Add(Me.updateLabel)
      Me.Controls.Add(Me.cbhDisplayNonZeroNozzles)
      Me.Controls.Add(Me.btnRebuildTable)
      Me.Name = "AllTotalsDialog"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Pumps volume and money amount total counters"
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
    Friend WithEvents btChangeShift As Button
    Friend WithEvents btEndShift As Button
    Friend WithEvents Button1 As Button
  End Class
End Namespace
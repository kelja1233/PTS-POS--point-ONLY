<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BalanceReadingBatch
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BalanceReadingBatch))
        Me.Price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Variance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sales = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CurrentReading = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nozzle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Product = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btbalance = New System.Windows.Forms.Button()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.txtbatch = New System.Windows.Forms.TextBox()
        Me.btshow = New System.Windows.Forms.Button()
        Me.DataGridView3 = New System.Windows.Forms.DataGridView()
        Me.DataGridView4 = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lookupcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.V1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.V2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.A2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Price
        '
        Me.Price.HeaderText = "Variance (Amount)"
        Me.Price.Name = "Price"
        Me.Price.ReadOnly = True
        Me.Price.Width = 115
        '
        'Variance
        '
        Me.Variance.HeaderText = "Variance (Volume)"
        Me.Variance.Name = "Variance"
        Me.Variance.ReadOnly = True
        Me.Variance.Width = 116
        '
        'Sales
        '
        Me.Sales.HeaderText = "Sales"
        Me.Sales.Name = "Sales"
        Me.Sales.ReadOnly = True
        Me.Sales.Width = 115
        '
        'CurrentReading
        '
        Me.CurrentReading.HeaderText = "Current Reading"
        Me.CurrentReading.Name = "CurrentReading"
        Me.CurrentReading.ReadOnly = True
        Me.CurrentReading.Width = 115
        '
        'Nozzle
        '
        Me.Nozzle.HeaderText = "Nozzle"
        Me.Nozzle.Name = "Nozzle"
        Me.Nozzle.ReadOnly = True
        Me.Nozzle.Width = 115
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Pump"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 116
        '
        'Product
        '
        Me.Product.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Product.HeaderText = "Product"
        Me.Product.Name = "Product"
        Me.Product.ReadOnly = True
        Me.Product.Width = 115
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.Silver
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Product, Me.DataGridViewTextBoxColumn1, Me.Nozzle, Me.CurrentReading, Me.Sales, Me.Variance, Me.Price})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridView1.GridColor = System.Drawing.Color.White
        Me.DataGridView1.Location = New System.Drawing.Point(14, 10)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridView1.RowHeadersVisible = False
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridView1.Size = New System.Drawing.Size(811, 279)
        Me.DataGridView1.TabIndex = 4
        '
        'btbalance
        '
        Me.btbalance.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btbalance.BackColor = System.Drawing.Color.White
        Me.btbalance.BackgroundImage = CType(resources.GetObject("btbalance.BackgroundImage"), System.Drawing.Image)
        Me.btbalance.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btbalance.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btbalance.FlatAppearance.BorderColor = System.Drawing.Color.Blue
        Me.btbalance.FlatAppearance.BorderSize = 20
        Me.btbalance.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btbalance.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btbalance.ForeColor = System.Drawing.Color.White
        Me.btbalance.Location = New System.Drawing.Point(582, 506)
        Me.btbalance.Name = "btbalance"
        Me.btbalance.Size = New System.Drawing.Size(243, 40)
        Me.btbalance.TabIndex = 3
        Me.btbalance.Text = "BALANCE READING"
        Me.btbalance.UseVisualStyleBackColor = False
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(846, 126)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.Size = New System.Drawing.Size(10, 163)
        Me.DataGridView2.TabIndex = 14
        '
        'txtbatch
        '
        Me.txtbatch.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txtbatch.Location = New System.Drawing.Point(14, 511)
        Me.txtbatch.Name = "txtbatch"
        Me.txtbatch.Size = New System.Drawing.Size(100, 33)
        Me.txtbatch.TabIndex = 1
        Me.txtbatch.Text = "0"
        '
        'btshow
        '
        Me.btshow.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btshow.BackColor = System.Drawing.Color.White
        Me.btshow.BackgroundImage = CType(resources.GetObject("btshow.BackgroundImage"), System.Drawing.Image)
        Me.btshow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btshow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btshow.FlatAppearance.BorderColor = System.Drawing.Color.Blue
        Me.btshow.FlatAppearance.BorderSize = 20
        Me.btshow.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btshow.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btshow.ForeColor = System.Drawing.Color.White
        Me.btshow.Location = New System.Drawing.Point(120, 506)
        Me.btshow.Name = "btshow"
        Me.btshow.Size = New System.Drawing.Size(119, 40)
        Me.btshow.TabIndex = 2
        Me.btshow.Text = "SHOW"
        Me.btshow.UseVisualStyleBackColor = False
        '
        'DataGridView3
        '
        Me.DataGridView3.AllowUserToAddRows = False
        Me.DataGridView3.AllowUserToDeleteRows = False
        Me.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView3.Location = New System.Drawing.Point(865, 181)
        Me.DataGridView3.Name = "DataGridView3"
        Me.DataGridView3.ReadOnly = True
        Me.DataGridView3.Size = New System.Drawing.Size(171, 108)
        Me.DataGridView3.TabIndex = 15
        '
        'DataGridView4
        '
        Me.DataGridView4.AllowUserToAddRows = False
        Me.DataGridView4.AllowUserToDeleteRows = False
        Me.DataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView4.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.lookupcode, Me.V1, Me.V2, Me.Column1, Me.A2, Me.VT, Me.AT})
        Me.DataGridView4.Location = New System.Drawing.Point(12, 318)
        Me.DataGridView4.Name = "DataGridView4"
        Me.DataGridView4.ReadOnly = True
        Me.DataGridView4.RowHeadersVisible = False
        Me.DataGridView4.Size = New System.Drawing.Size(813, 163)
        Me.DataGridView4.TabIndex = 16
        '
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        '
        'lookupcode
        '
        Me.lookupcode.HeaderText = "lookupcode"
        Me.lookupcode.Name = "lookupcode"
        Me.lookupcode.ReadOnly = True
        '
        'V1
        '
        Me.V1.HeaderText = "V1"
        Me.V1.Name = "V1"
        Me.V1.ReadOnly = True
        '
        'V2
        '
        Me.V2.HeaderText = "V2"
        Me.V2.Name = "V2"
        Me.V2.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "A1"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'A2
        '
        Me.A2.HeaderText = "A2"
        Me.A2.Name = "A2"
        Me.A2.ReadOnly = True
        '
        'VT
        '
        Me.VT.HeaderText = "VT"
        Me.VT.Name = "VT"
        Me.VT.ReadOnly = True
        '
        'AT
        '
        Me.AT.HeaderText = "AT"
        Me.AT.Name = "AT"
        Me.AT.ReadOnly = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.Blue
        Me.Button1.FlatAppearance.BorderSize = 20
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(457, 506)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(119, 40)
        Me.Button1.TabIndex = 17
        Me.Button1.Text = "magic"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold)
        Me.TextBox1.Location = New System.Drawing.Point(351, 509)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 33)
        Me.TextBox1.TabIndex = 18
        Me.TextBox1.Text = "0"
        '
        'BalanceReadingBatch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(838, 560)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGridView4)
        Me.Controls.Add(Me.DataGridView3)
        Me.Controls.Add(Me.btshow)
        Me.Controls.Add(Me.txtbatch)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.btbalance)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(854, 599)
        Me.MinimumSize = New System.Drawing.Size(854, 599)
        Me.Name = "BalanceReadingBatch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BALANCE READING BATCH"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Price As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Variance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CurrentReading As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nozzle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Product As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btbalance As System.Windows.Forms.Button
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents txtbatch As System.Windows.Forms.TextBox
    Friend WithEvents btshow As System.Windows.Forms.Button
    Friend WithEvents DataGridView3 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView4 As System.Windows.Forms.DataGridView
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lookupcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents V1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents V2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents A2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ShowCustomer1
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
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ShowCustomer1))
    Me.DataGridView1 = New System.Windows.Forms.DataGridView()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.txtLastName = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.txtfname = New System.Windows.Forms.TextBox()
    Me.btc = New System.Windows.Forms.Button()
    Me.btrec = New System.Windows.Forms.Button()
    CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'DataGridView1
    '
    Me.DataGridView1.AllowUserToAddRows = False
    Me.DataGridView1.AllowUserToDeleteRows = False
    DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
    Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
    DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 11.25!)
    DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
    Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
    DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 11.25!)
    DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
    DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
    Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle3
    Me.DataGridView1.Location = New System.Drawing.Point(12, 83)
    Me.DataGridView1.Name = "DataGridView1"
    Me.DataGridView1.ReadOnly = True
    DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 11.25!)
    DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
    Me.DataGridView1.RowHeadersVisible = False
    Me.DataGridView1.RowHeadersWidth = 30
    DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 11.25!)
    Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle5
    Me.DataGridView1.Size = New System.Drawing.Size(984, 217)
    Me.DataGridView1.TabIndex = 13
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.BackColor = System.Drawing.Color.Transparent
    Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(285, 12)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(84, 21)
    Me.Label2.TabIndex = 17
    Me.Label2.Text = "Last Name"
    '
    'txtLastName
    '
    Me.txtLastName.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtLastName.Location = New System.Drawing.Point(288, 38)
    Me.txtLastName.Name = "txtLastName"
    Me.txtLastName.Size = New System.Drawing.Size(276, 29)
    Me.txtLastName.TabIndex = 12
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.BackColor = System.Drawing.Color.Transparent
    Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(13, 12)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(86, 21)
    Me.Label1.TabIndex = 16
    Me.Label1.Text = "First Name"
    '
    'txtfname
    '
    Me.txtfname.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtfname.Location = New System.Drawing.Point(12, 38)
    Me.txtfname.Name = "txtfname"
    Me.txtfname.Size = New System.Drawing.Size(270, 29)
    Me.txtfname.TabIndex = 11
    '
    'btc
    '
    Me.btc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.btc.BackColor = System.Drawing.Color.White
    Me.btc.BackgroundImage = CType(resources.GetObject("btc.BackgroundImage"), System.Drawing.Image)
    Me.btc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
    Me.btc.Cursor = System.Windows.Forms.Cursors.Hand
    Me.btc.FlatStyle = System.Windows.Forms.FlatStyle.Popup
    Me.btc.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btc.ForeColor = System.Drawing.Color.White
    Me.btc.Location = New System.Drawing.Point(881, 23)
    Me.btc.Name = "btc"
    Me.btc.Size = New System.Drawing.Size(115, 40)
    Me.btc.TabIndex = 15
    Me.btc.Text = "CANCEL"
    Me.btc.UseVisualStyleBackColor = False
    '
    'btrec
    '
    Me.btrec.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.btrec.BackColor = System.Drawing.Color.White
    Me.btrec.BackgroundImage = CType(resources.GetObject("btrec.BackgroundImage"), System.Drawing.Image)
    Me.btrec.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
    Me.btrec.Cursor = System.Windows.Forms.Cursors.Hand
    Me.btrec.FlatStyle = System.Windows.Forms.FlatStyle.Popup
    Me.btrec.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btrec.ForeColor = System.Drawing.Color.White
    Me.btrec.Location = New System.Drawing.Point(760, 23)
    Me.btrec.Name = "btrec"
    Me.btrec.Size = New System.Drawing.Size(115, 40)
    Me.btrec.TabIndex = 14
    Me.btrec.Text = "REFRESH"
    Me.btrec.UseVisualStyleBackColor = False
    '
    'ShowCustomer1
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1008, 380)
    Me.ControlBox = False
    Me.Controls.Add(Me.btc)
    Me.Controls.Add(Me.DataGridView1)
    Me.Controls.Add(Me.btrec)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.txtLastName)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.txtfname)
    Me.MaximumSize = New System.Drawing.Size(1024, 419)
    Me.MinimumSize = New System.Drawing.Size(1024, 419)
    Me.Name = "ShowCustomer1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "CUSTOMER LISTS"
    CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

  Friend WithEvents btc As Button
  Friend WithEvents DataGridView1 As DataGridView
  Friend WithEvents btrec As Button
  Friend WithEvents Label2 As Label
  Friend WithEvents txtLastName As TextBox
  Friend WithEvents Label1 As Label
  Friend WithEvents txtfname As TextBox
End Class

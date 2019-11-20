<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPoint
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPoint))
    Me.Label1 = New System.Windows.Forms.Label()
    Me.txtcode = New System.Windows.Forms.TextBox()
    Me.txtname = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.lblt = New System.Windows.Forms.Label()
    Me.Panel13 = New System.Windows.Forms.Panel()
    Me.lbpoint = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label46 = New System.Windows.Forms.Label()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.btcash = New System.Windows.Forms.Button()
    Me.Panel13.SuspendLayout()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.BackColor = System.Drawing.Color.Transparent
    Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.ForeColor = System.Drawing.Color.Red
    Me.Label1.Location = New System.Drawing.Point(10, 7)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(147, 25)
    Me.Label1.TabIndex = 147
    Me.Label1.Text = "CARD NUMBER"
    '
    'txtcode
    '
    Me.txtcode.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtcode.Location = New System.Drawing.Point(14, 35)
    Me.txtcode.MaxLength = 10
    Me.txtcode.Name = "txtcode"
    Me.txtcode.Size = New System.Drawing.Size(369, 29)
    Me.txtcode.TabIndex = 139
    Me.txtcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    Me.txtcode.UseSystemPasswordChar = True
    '
    'txtname
    '
    Me.txtname.AutoSize = True
    Me.txtname.BackColor = System.Drawing.Color.Transparent
    Me.txtname.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtname.Location = New System.Drawing.Point(12, 90)
    Me.txtname.Name = "txtname"
    Me.txtname.Size = New System.Drawing.Size(61, 25)
    Me.txtname.TabIndex = 146
    Me.txtname.Text = "None"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.BackColor = System.Drawing.Color.Transparent
    Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(12, 67)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(127, 21)
    Me.Label2.TabIndex = 145
    Me.Label2.Text = "Customer Name:"
    '
    'lblt
    '
    Me.lblt.AutoSize = True
    Me.lblt.BackColor = System.Drawing.Color.Transparent
    Me.lblt.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblt.Location = New System.Drawing.Point(140, 109)
    Me.lblt.Name = "lblt"
    Me.lblt.Size = New System.Drawing.Size(29, 32)
    Me.lblt.TabIndex = 144
    Me.lblt.Text = "0"
    '
    'Panel13
    '
    Me.Panel13.BackColor = System.Drawing.Color.White
    Me.Panel13.Controls.Add(Me.lbpoint)
    Me.Panel13.Controls.Add(Me.Label7)
    Me.Panel13.Controls.Add(Me.Label3)
    Me.Panel13.Location = New System.Drawing.Point(14, 144)
    Me.Panel13.Name = "Panel13"
    Me.Panel13.Size = New System.Drawing.Size(369, 69)
    Me.Panel13.TabIndex = 141
    '
    'lbpoint
    '
    Me.lbpoint.AutoSize = True
    Me.lbpoint.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lbpoint.Location = New System.Drawing.Point(6, 25)
    Me.lbpoint.Name = "lbpoint"
    Me.lbpoint.Size = New System.Drawing.Size(37, 39)
    Me.lbpoint.TabIndex = 1
    Me.lbpoint.Text = "0"
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label7.Location = New System.Drawing.Point(308, 44)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(58, 20)
    Me.Label7.TabIndex = 5
    Me.Label7.Text = "Loyalty"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(5, 4)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(118, 25)
    Me.Label3.TabIndex = 0
    Me.Label3.Text = "Total Point/s"
    '
    'Label46
    '
    Me.Label46.AutoSize = True
    Me.Label46.BackColor = System.Drawing.Color.Transparent
    Me.Label46.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label46.Location = New System.Drawing.Point(14, 115)
    Me.Label46.Name = "Label46"
    Me.Label46.Size = New System.Drawing.Size(125, 21)
    Me.Label46.TabIndex = 143
    Me.Label46.Text = "Loyal Total Point:"
    '
    'Button1
    '
    Me.Button1.BackColor = System.Drawing.Color.White
    Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
    Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
    Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
    Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
    Me.Button1.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Button1.ForeColor = System.Drawing.Color.White
    Me.Button1.Location = New System.Drawing.Point(235, 219)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(148, 71)
    Me.Button1.TabIndex = 142
    Me.Button1.Text = "REFRESH"
    Me.Button1.UseVisualStyleBackColor = False
    '
    'btcash
    '
    Me.btcash.BackColor = System.Drawing.Color.White
    Me.btcash.BackgroundImage = CType(resources.GetObject("btcash.BackgroundImage"), System.Drawing.Image)
    Me.btcash.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
    Me.btcash.Cursor = System.Windows.Forms.Cursors.Hand
    Me.btcash.FlatStyle = System.Windows.Forms.FlatStyle.Popup
    Me.btcash.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btcash.ForeColor = System.Drawing.Color.White
    Me.btcash.Location = New System.Drawing.Point(15, 219)
    Me.btcash.Name = "btcash"
    Me.btcash.Size = New System.Drawing.Size(214, 71)
    Me.btcash.TabIndex = 148
    Me.btcash.Text = "Tender"
    Me.btcash.UseVisualStyleBackColor = False
    '
    'frmPoint
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(395, 302)
    Me.Controls.Add(Me.btcash)
    Me.Controls.Add(Me.Button1)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.txtcode)
    Me.Controls.Add(Me.txtname)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.lblt)
    Me.Controls.Add(Me.Panel13)
    Me.Controls.Add(Me.Label46)
    Me.MaximizeBox = False
    Me.MaximumSize = New System.Drawing.Size(411, 341)
    Me.MinimizeBox = False
    Me.MinimumSize = New System.Drawing.Size(411, 341)
    Me.Name = "frmPoint"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Panel13.ResumeLayout(False)
    Me.Panel13.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

  Friend WithEvents Button1 As Button
  Friend WithEvents Label1 As Label
  Friend WithEvents txtcode As TextBox
  Friend WithEvents txtname As Label
  Friend WithEvents Label2 As Label
  Friend WithEvents lblt As Label
  Friend WithEvents Panel13 As Panel
  Friend WithEvents lbpoint As Label
  Friend WithEvents Label7 As Label
  Friend WithEvents Label3 As Label
  Friend WithEvents Label46 As Label
  Friend WithEvents btcash As Button
End Class

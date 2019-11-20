<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SQLConnect
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SQLConnect))
    Me.CheckBox1 = New System.Windows.Forms.CheckBox()
    Me.ComboBox1 = New System.Windows.Forms.ComboBox()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.txtpath = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.txtcom = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.txtprint = New System.Windows.Forms.TextBox()
    Me.txtok = New System.Windows.Forms.Button()
    Me.txttest = New System.Windows.Forms.Button()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.txtpass = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.txtuser = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.txtdb = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.txtserver = New System.Windows.Forms.TextBox()
    Me.SuspendLayout()
    '
    'CheckBox1
    '
    Me.CheckBox1.AutoSize = True
    Me.CheckBox1.Location = New System.Drawing.Point(12, 234)
    Me.CheckBox1.Name = "CheckBox1"
    Me.CheckBox1.Size = New System.Drawing.Size(90, 17)
    Me.CheckBox1.TabIndex = 198
    Me.CheckBox1.Text = "Check Offline"
    Me.CheckBox1.UseVisualStyleBackColor = True
    '
    'ComboBox1
    '
    Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.ComboBox1.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
    Me.ComboBox1.FormattingEnabled = True
    Me.ComboBox1.Items.AddRange(New Object() {"YES", "NO"})
    Me.ComboBox1.Location = New System.Drawing.Point(7, 273)
    Me.ComboBox1.Name = "ComboBox1"
    Me.ComboBox1.Size = New System.Drawing.Size(121, 29)
    Me.ComboBox1.TabIndex = 197
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.BackColor = System.Drawing.Color.Transparent
    Me.Label8.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label8.Location = New System.Drawing.Point(4, 254)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(102, 21)
    Me.Label8.TabIndex = 196
    Me.Label8.Text = "ABCD MODE:"
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.BackColor = System.Drawing.Color.Transparent
    Me.Label7.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label7.Location = New System.Drawing.Point(11, 203)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(40, 21)
    Me.Label7.TabIndex = 195
    Me.Label7.Text = "Path"
    '
    'txtpath
    '
    Me.txtpath.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtpath.Location = New System.Drawing.Point(89, 200)
    Me.txtpath.Name = "txtpath"
    Me.txtpath.Size = New System.Drawing.Size(250, 29)
    Me.txtpath.TabIndex = 194
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.BackColor = System.Drawing.Color.Transparent
    Me.Label6.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label6.Location = New System.Drawing.Point(11, 173)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(46, 21)
    Me.Label6.TabIndex = 193
    Me.Label6.Text = "COM"
    '
    'txtcom
    '
    Me.txtcom.BackColor = System.Drawing.Color.White
    Me.txtcom.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtcom.Location = New System.Drawing.Point(89, 170)
    Me.txtcom.Name = "txtcom"
    Me.txtcom.Size = New System.Drawing.Size(250, 29)
    Me.txtcom.TabIndex = 185
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.BackColor = System.Drawing.Color.Transparent
    Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label5.Location = New System.Drawing.Point(11, 142)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(57, 21)
    Me.Label5.TabIndex = 192
    Me.Label5.Text = "Printer"
    '
    'txtprint
    '
    Me.txtprint.BackColor = System.Drawing.Color.White
    Me.txtprint.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtprint.Location = New System.Drawing.Point(89, 139)
    Me.txtprint.Name = "txtprint"
    Me.txtprint.Size = New System.Drawing.Size(250, 29)
    Me.txtprint.TabIndex = 184
    '
    'txtok
    '
    Me.txtok.BackColor = System.Drawing.Color.White
    Me.txtok.BackgroundImage = CType(resources.GetObject("txtok.BackgroundImage"), System.Drawing.Image)
    Me.txtok.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
    Me.txtok.Cursor = System.Windows.Forms.Cursors.Hand
    Me.txtok.FlatStyle = System.Windows.Forms.FlatStyle.Popup
    Me.txtok.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtok.ForeColor = System.Drawing.Color.White
    Me.txtok.Location = New System.Drawing.Point(165, 263)
    Me.txtok.Name = "txtok"
    Me.txtok.Size = New System.Drawing.Size(90, 40)
    Me.txtok.TabIndex = 186
    Me.txtok.Text = "OK"
    Me.txtok.UseVisualStyleBackColor = False
    '
    'txttest
    '
    Me.txttest.BackColor = System.Drawing.Color.White
    Me.txttest.BackgroundImage = CType(resources.GetObject("txttest.BackgroundImage"), System.Drawing.Image)
    Me.txttest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
    Me.txttest.Cursor = System.Windows.Forms.Cursors.Hand
    Me.txttest.FlatStyle = System.Windows.Forms.FlatStyle.Popup
    Me.txttest.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txttest.ForeColor = System.Drawing.Color.White
    Me.txttest.Location = New System.Drawing.Point(261, 263)
    Me.txttest.Name = "txttest"
    Me.txttest.Size = New System.Drawing.Size(90, 40)
    Me.txttest.TabIndex = 187
    Me.txttest.Text = "TEST"
    Me.txttest.UseVisualStyleBackColor = False
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.BackColor = System.Drawing.Color.Transparent
    Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(11, 110)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(76, 21)
    Me.Label4.TabIndex = 191
    Me.Label4.Text = "Password"
    '
    'txtpass
    '
    Me.txtpass.BackColor = System.Drawing.Color.White
    Me.txtpass.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
    Me.txtpass.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtpass.Location = New System.Drawing.Point(89, 107)
    Me.txtpass.Name = "txtpass"
    Me.txtpass.Size = New System.Drawing.Size(250, 29)
    Me.txtpass.TabIndex = 183
    Me.txtpass.UseSystemPasswordChar = True
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.BackColor = System.Drawing.Color.Transparent
    Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(11, 79)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(42, 21)
    Me.Label3.TabIndex = 190
    Me.Label3.Text = "User"
    '
    'txtuser
    '
    Me.txtuser.BackColor = System.Drawing.Color.White
    Me.txtuser.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
    Me.txtuser.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtuser.Location = New System.Drawing.Point(89, 76)
    Me.txtuser.Name = "txtuser"
    Me.txtuser.Size = New System.Drawing.Size(250, 29)
    Me.txtuser.TabIndex = 182
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.BackColor = System.Drawing.Color.Transparent
    Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(11, 48)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(74, 21)
    Me.Label2.TabIndex = 189
    Me.Label2.Text = "Database"
    '
    'txtdb
    '
    Me.txtdb.BackColor = System.Drawing.Color.White
    Me.txtdb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.txtdb.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtdb.Location = New System.Drawing.Point(89, 45)
    Me.txtdb.Name = "txtdb"
    Me.txtdb.Size = New System.Drawing.Size(250, 29)
    Me.txtdb.TabIndex = 181
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.BackColor = System.Drawing.Color.Transparent
    Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(11, 17)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(55, 21)
    Me.Label1.TabIndex = 188
    Me.Label1.Text = "Server"
    '
    'txtserver
    '
    Me.txtserver.BackColor = System.Drawing.Color.White
    Me.txtserver.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.txtserver.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtserver.Location = New System.Drawing.Point(89, 14)
    Me.txtserver.Name = "txtserver"
    Me.txtserver.Size = New System.Drawing.Size(250, 29)
    Me.txtserver.TabIndex = 180
    '
    'SQLConnect
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(354, 316)
    Me.ControlBox = False
    Me.Controls.Add(Me.CheckBox1)
    Me.Controls.Add(Me.ComboBox1)
    Me.Controls.Add(Me.Label8)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.txtpath)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.txtcom)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.txtprint)
    Me.Controls.Add(Me.txtok)
    Me.Controls.Add(Me.txttest)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.txtpass)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.txtuser)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.txtdb)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.txtserver)
    Me.Cursor = System.Windows.Forms.Cursors.Default
    Me.Name = "SQLConnect"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents txtok As System.Windows.Forms.Button
  Friend WithEvents txttest As System.Windows.Forms.Button
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Public WithEvents txtpath As TextBox
  Public WithEvents txtcom As TextBox
  Public WithEvents txtprint As TextBox
  Public WithEvents txtpass As TextBox
  Public WithEvents txtuser As TextBox
  Public WithEvents txtdb As TextBox
  Public WithEvents txtserver As TextBox
End Class

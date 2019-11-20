<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLogin
  Inherits System.Windows.Forms.Form

  'Form overrides dispose to clean up the component list.
  <System.Diagnostics.DebuggerNonUserCode()>
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
  <System.Diagnostics.DebuggerStepThrough()>
  Private Sub InitializeComponent()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
    Me.Cancel = New System.Windows.Forms.Button()
    Me.OK = New System.Windows.Forms.Button()
    Me.txtPassword = New System.Windows.Forms.TextBox()
    Me.txtUserName = New System.Windows.Forms.TextBox()
    Me.PasswordLabel = New System.Windows.Forms.Label()
    Me.UsernameLabel = New System.Windows.Forms.Label()
    Me.SuspendLayout()
    '
    'Cancel
    '
    Me.Cancel.BackColor = System.Drawing.Color.White
    Me.Cancel.BackgroundImage = CType(resources.GetObject("Cancel.BackgroundImage"), System.Drawing.Image)
    Me.Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
    Me.Cancel.Cursor = System.Windows.Forms.Cursors.Hand
    Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
    Me.Cancel.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Cancel.ForeColor = System.Drawing.Color.White
    Me.Cancel.Location = New System.Drawing.Point(197, 151)
    Me.Cancel.Name = "Cancel"
    Me.Cancel.Size = New System.Drawing.Size(100, 40)
    Me.Cancel.TabIndex = 12
    Me.Cancel.Text = "&CANCEL"
    Me.Cancel.UseVisualStyleBackColor = False
    '
    'OK
    '
    Me.OK.BackColor = System.Drawing.Color.White
    Me.OK.BackgroundImage = CType(resources.GetObject("OK.BackgroundImage"), System.Drawing.Image)
    Me.OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
    Me.OK.Cursor = System.Windows.Forms.Cursors.Hand
    Me.OK.FlatStyle = System.Windows.Forms.FlatStyle.Popup
    Me.OK.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.OK.ForeColor = System.Drawing.Color.White
    Me.OK.Location = New System.Drawing.Point(91, 151)
    Me.OK.Name = "OK"
    Me.OK.Size = New System.Drawing.Size(100, 40)
    Me.OK.TabIndex = 11
    Me.OK.Text = "&OK"
    Me.OK.UseVisualStyleBackColor = False
    '
    'txtPassword
    '
    Me.txtPassword.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtPassword.Location = New System.Drawing.Point(18, 106)
    Me.txtPassword.Name = "txtPassword"
    Me.txtPassword.Size = New System.Drawing.Size(279, 29)
    Me.txtPassword.TabIndex = 10
    Me.txtPassword.UseSystemPasswordChar = True
    '
    'txtUserName
    '
    Me.txtUserName.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtUserName.Location = New System.Drawing.Point(18, 40)
    Me.txtUserName.Name = "txtUserName"
    Me.txtUserName.Size = New System.Drawing.Size(279, 29)
    Me.txtUserName.TabIndex = 9
    '
    'PasswordLabel
    '
    Me.PasswordLabel.BackColor = System.Drawing.Color.Transparent
    Me.PasswordLabel.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.PasswordLabel.Location = New System.Drawing.Point(16, 80)
    Me.PasswordLabel.Name = "PasswordLabel"
    Me.PasswordLabel.Size = New System.Drawing.Size(281, 23)
    Me.PasswordLabel.TabIndex = 14
    Me.PasswordLabel.Text = "&Password"
    Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'UsernameLabel
    '
    Me.UsernameLabel.BackColor = System.Drawing.Color.Transparent
    Me.UsernameLabel.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.UsernameLabel.Location = New System.Drawing.Point(16, 14)
    Me.UsernameLabel.Name = "UsernameLabel"
    Me.UsernameLabel.Size = New System.Drawing.Size(281, 23)
    Me.UsernameLabel.TabIndex = 13
    Me.UsernameLabel.Text = "&User name"
    Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'frmLogin
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(312, 205)
    Me.ControlBox = False
    Me.Controls.Add(Me.Cancel)
    Me.Controls.Add(Me.OK)
    Me.Controls.Add(Me.txtPassword)
    Me.Controls.Add(Me.txtUserName)
    Me.Controls.Add(Me.PasswordLabel)
    Me.Controls.Add(Me.UsernameLabel)
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MaximumSize = New System.Drawing.Size(328, 244)
    Me.MinimumSize = New System.Drawing.Size(328, 244)
    Me.Name = "frmLogin"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "LogIn"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

  Friend WithEvents Cancel As Button
  Friend WithEvents OK As Button
  Friend WithEvents txtPassword As TextBox
  Friend WithEvents txtUserName As TextBox
  Friend WithEvents PasswordLabel As Label
  Friend WithEvents UsernameLabel As Label
End Class

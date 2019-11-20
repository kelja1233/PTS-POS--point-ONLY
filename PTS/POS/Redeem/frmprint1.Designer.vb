<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmprint1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmprint1))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.no = New System.Windows.Forms.Button()
        Me.yes = New System.Windows.Forms.Button()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(55, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(151, 29)
        Me.Label2.TabIndex = 55
        Me.Label2.Text = "this Receipt?"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(225, 29)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "Do you want to Print"
        '
        'no
        '
        Me.no.BackColor = System.Drawing.Color.White
        Me.no.BackgroundImage = CType(resources.GetObject("no.BackgroundImage"), System.Drawing.Image)
        Me.no.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.no.Cursor = System.Windows.Forms.Cursors.Hand
        Me.no.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.no.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.no.ForeColor = System.Drawing.Color.Transparent
        Me.no.Location = New System.Drawing.Point(133, 79)
        Me.no.Name = "no"
        Me.no.Size = New System.Drawing.Size(100, 40)
        Me.no.TabIndex = 53
        Me.no.Text = "NO"
        Me.no.UseVisualStyleBackColor = False
        '
        'yes
        '
        Me.yes.BackColor = System.Drawing.Color.White
        Me.yes.BackgroundImage = CType(resources.GetObject("yes.BackgroundImage"), System.Drawing.Image)
        Me.yes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.yes.Cursor = System.Windows.Forms.Cursors.Hand
        Me.yes.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.yes.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.yes.ForeColor = System.Drawing.Color.Transparent
        Me.yes.Location = New System.Drawing.Point(27, 79)
        Me.yes.Name = "yes"
        Me.yes.Size = New System.Drawing.Size(100, 40)
        Me.yes.TabIndex = 52
        Me.yes.Text = "YES"
        Me.yes.UseVisualStyleBackColor = False
        '
        'PrintDocument1
        '
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(36, 200)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(651, 110)
        Me.DataGridView1.TabIndex = 56
        '
        'frmprint1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(256, 133)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.no)
        Me.Controls.Add(Me.yes)
        Me.Controls.Add(Me.DataGridView1)
        Me.MaximumSize = New System.Drawing.Size(272, 172)
        Me.MinimumSize = New System.Drawing.Size(272, 172)
        Me.Name = "frmprint1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmprint1"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents no As System.Windows.Forms.Button
    Friend WithEvents yes As System.Windows.Forms.Button
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
End Class

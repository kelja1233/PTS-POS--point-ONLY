Namespace TiT.PTS
	Partial Public Class AtgMainForm
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
			Me.statusStrip = New StatusStrip()
			Me.menuStrip = New MenuStrip()
			Me.fileToolStripMenuItem = New ToolStripMenuItem()
			Me.exitToolStripMenuItem = New ToolStripMenuItem()
			Me.toolsToolStripMenuItem = New ToolStripMenuItem()
			Me.optionsToolStripMenuItem = New ToolStripMenuItem()
			Me.tableLayoutPanel = New TableLayoutPanel()
			Me._atgControl4 = New TiT.PTS.AtgControl()
			Me._atgControl3 = New TiT.PTS.AtgControl()
			Me._atgControl2 = New TiT.PTS.AtgControl()
			Me._atgControl1 = New TiT.PTS.AtgControl()
			Me.menuStrip.SuspendLayout()
			Me.tableLayoutPanel.SuspendLayout()
			Me.SuspendLayout()
			' 
			' statusStrip
			' 
			Me.statusStrip.Location = New Point(0, 629)
			Me.statusStrip.Name = "statusStrip"
			Me.statusStrip.Size = New Size(912, 22)
			Me.statusStrip.TabIndex = 0
			Me.statusStrip.Text = "statusStrip1"
			' 
			' menuStrip
			' 
			Me.menuStrip.Items.AddRange(New ToolStripItem() { Me.fileToolStripMenuItem, Me.toolsToolStripMenuItem})
			Me.menuStrip.Location = New Point(0, 0)
			Me.menuStrip.Name = "menuStrip"
			Me.menuStrip.Size = New Size(912, 24)
			Me.menuStrip.TabIndex = 1
			Me.menuStrip.Text = "menuStrip1"
			' 
			' fileToolStripMenuItem
			' 
			Me.fileToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() { Me.exitToolStripMenuItem})
			Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
			Me.fileToolStripMenuItem.Size = New Size(35, 20)
			Me.fileToolStripMenuItem.Text = "&File"
			' 
			' exitToolStripMenuItem
			' 
			Me.exitToolStripMenuItem.Name = "exitToolStripMenuItem"
			Me.exitToolStripMenuItem.ShortcutKeys = (CType((Keys.Control Or Keys.X), Keys))
			Me.exitToolStripMenuItem.Size = New Size(149, 22)
			Me.exitToolStripMenuItem.Text = "&Close"
'			Me.exitToolStripMenuItem.Click += New System.EventHandler(Me.exitToolStripMenuItem_Click)
			' 
			' toolsToolStripMenuItem
			' 
			Me.toolsToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() { Me.optionsToolStripMenuItem})
			Me.toolsToolStripMenuItem.Enabled = False
			Me.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem"
			Me.toolsToolStripMenuItem.Size = New Size(84, 20)
			Me.toolsToolStripMenuItem.Text = "&Configuration"
			Me.toolsToolStripMenuItem.Visible = False
			' 
			' optionsToolStripMenuItem
'             
'            this.optionsToolStripMenuItem.Enabled = false;
'            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
'            this.optionsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
'            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
'            this.optionsToolStripMenuItem.Text = "ATG &configuration settings";
'            this.optionsToolStripMenuItem.Visible = false;
'            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
'             
			' tableLayoutPanel
			' 
			Me.tableLayoutPanel.BackColor = Color.FromArgb((CInt(Fix((CByte(64))))), (CInt(Fix((CByte(64))))), (CInt(Fix((CByte(64))))))
			Me.tableLayoutPanel.ColumnCount = 2
			Me.tableLayoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
			Me.tableLayoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
			Me.tableLayoutPanel.Controls.Add(Me._atgControl4, 1, 1)
			Me.tableLayoutPanel.Controls.Add(Me._atgControl3, 0, 1)
			Me.tableLayoutPanel.Controls.Add(Me._atgControl2, 1, 0)
			Me.tableLayoutPanel.Controls.Add(Me._atgControl1, 0, 0)
			Me.tableLayoutPanel.Dock = DockStyle.Fill
			Me.tableLayoutPanel.Location = New Point(0, 24)
			Me.tableLayoutPanel.Name = "tableLayoutPanel"
			Me.tableLayoutPanel.RowCount = 2
			Me.tableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
			Me.tableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
			Me.tableLayoutPanel.Size = New Size(912, 605)
			Me.tableLayoutPanel.TabIndex = 3
			' 
			' atgControl4
			' 
			Me._atgControl4.Atg = Nothing
			Me._atgControl4.AtgID = Nothing
			Me._atgControl4.BackColor = Color.MintCream
			Me._atgControl4.Location = New Point(459, 305)
			Me._atgControl4.Name = "atgControl4"
			Me._atgControl4.PTS = Nothing
			Me._atgControl4.Size = New Size(448, 293)
			Me._atgControl4.TabIndex = 7
			' 
			' atgControl3
			' 
			Me._atgControl3.Atg = Nothing
			Me._atgControl3.AtgID = Nothing
			Me._atgControl3.BackColor = Color.MintCream
			Me._atgControl3.Location = New Point(3, 305)
			Me._atgControl3.Name = "atgControl3"
			Me._atgControl3.PTS = Nothing
			Me._atgControl3.Size = New Size(448, 293)
			Me._atgControl3.TabIndex = 6
			' 
			' atgControl2
			' 
			Me._atgControl2.Atg = Nothing
			Me._atgControl2.AtgID = Nothing
			Me._atgControl2.BackColor = Color.MintCream
			Me._atgControl2.Location = New Point(459, 3)
			Me._atgControl2.Name = "atgControl2"
			Me._atgControl2.PTS = Nothing
			Me._atgControl2.Size = New Size(448, 293)
			Me._atgControl2.TabIndex = 5
			' 
			' atgControl1
			' 
			Me._atgControl1.Atg = Nothing
			Me._atgControl1.AtgID = Nothing
			Me._atgControl1.BackColor = Color.MintCream
			Me._atgControl1.Location = New Point(3, 3)
			Me._atgControl1.Name = "atgControl1"
			Me._atgControl1.PTS = Nothing
			Me._atgControl1.Size = New Size(448, 294)
			Me._atgControl1.TabIndex = 4
			' 
			' AtgMainForm
			' 
			Me.AutoScaleDimensions = New SizeF(6F, 13F)
			Me.AutoScaleMode = AutoScaleMode.Font
			Me.ClientSize = New Size(912, 651)
			Me.Controls.Add(Me.tableLayoutPanel)
			Me.Controls.Add(Me.statusStrip)
			Me.Controls.Add(Me.menuStrip)
			Me.MainMenuStrip = Me.menuStrip
			Me.MinimumSize = New Size(550, 550)
			Me.Name = "AtgMainForm"
			Me.ShowIcon = False
			Me.Text = "ATG measurements"
'			Me.FormClosing += New System.Windows.Forms.FormClosingEventHandler(Me.AtgMainForm_FormClosing)
			Me.menuStrip.ResumeLayout(False)
			Me.menuStrip.PerformLayout()
			Me.tableLayoutPanel.ResumeLayout(False)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private statusStrip As StatusStrip
		Private menuStrip As MenuStrip
		Private toolsToolStripMenuItem As ToolStripMenuItem
		Public optionsToolStripMenuItem As ToolStripMenuItem
		Public tableLayoutPanel As TableLayoutPanel
		Private fileToolStripMenuItem As ToolStripMenuItem
		Private WithEvents exitToolStripMenuItem As ToolStripMenuItem
	End Class
End Namespace
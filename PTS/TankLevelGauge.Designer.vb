Namespace TiT.PTS
	Partial Public Class TankControl
		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Component Designer generated code"

		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.labelCurHeight = New Label()
			Me.pbAttention = New PictureBox()
			Me.picLevel = New PictureBox()
			Me.pictureBoxBackground = New PictureBox()
			Me.lblAttentionMessage = New Label()
			Me.lblAttention = New Label()
			CType(Me.pbAttention, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.picLevel, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.pictureBoxBackground, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' labelCurHeight
			' 
			Me.labelCurHeight.AutoSize = True
			Me.labelCurHeight.BackColor = Color.Transparent
			Me.labelCurHeight.Font = New Font("Microsoft Sans Serif", 9.25F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.labelCurHeight.Location = New Point(119, 113)
			Me.labelCurHeight.Name = "labelCurHeight"
			Me.labelCurHeight.Size = New Size(0, 16)
			Me.labelCurHeight.TabIndex = 4
			' 
			' pbAttention
			' 
			Me.pbAttention.Image = My.Resources.Attention_new
			Me.pbAttention.Location = New Point(12, 7)
			Me.pbAttention.Name = "pbAttention"
			Me.pbAttention.Size = New Size(30, 30)
			Me.pbAttention.SizeMode = PictureBoxSizeMode.StretchImage
			Me.pbAttention.TabIndex = 5
			Me.pbAttention.TabStop = False
			Me.pbAttention.Visible = False
			' 
			' picLevel
			' 
			Me.picLevel.Anchor = (CType((((AnchorStyles.Top Or AnchorStyles.Bottom) Or AnchorStyles.Left) Or AnchorStyles.Right), AnchorStyles))
			Me.picLevel.BackgroundImageLayout = ImageLayout.Stretch
			Me.picLevel.Image = My.Resources.levelBlue
			Me.picLevel.Location = New Point(14, 43)
			Me.picLevel.Margin = New Padding(0)
			Me.picLevel.Name = "picLevel"
			Me.picLevel.Size = New Size(100, 171)
			Me.picLevel.SizeMode = PictureBoxSizeMode.StretchImage
			Me.picLevel.TabIndex = 0
			Me.picLevel.TabStop = False
			' 
			' pictureBoxBackground
			' 
			Me.pictureBoxBackground.Anchor = (CType((((AnchorStyles.Top Or AnchorStyles.Bottom) Or AnchorStyles.Left) Or AnchorStyles.Right), AnchorStyles))
			Me.pictureBoxBackground.Image = My.Resources.LevelBack
			Me.pictureBoxBackground.Location = New Point(11, 40)
			Me.pictureBoxBackground.Name = "pictureBoxBackground"
			Me.pictureBoxBackground.Size = New Size(106, 177)
			Me.pictureBoxBackground.SizeMode = PictureBoxSizeMode.StretchImage
			Me.pictureBoxBackground.TabIndex = 1
			Me.pictureBoxBackground.TabStop = False
			' 
			' lblAttentionMessage
			' 
			Me.lblAttentionMessage.AutoSize = True
			Me.lblAttentionMessage.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.lblAttentionMessage.Location = New Point(56, 22)
			Me.lblAttentionMessage.Name = "lblAttentionMessage"
			Me.lblAttentionMessage.Size = New Size(0, 13)
			Me.lblAttentionMessage.TabIndex = 6
			Me.lblAttentionMessage.Visible = False
			' 
			' lblAttention
			' 
			Me.lblAttention.AutoSize = True
			Me.lblAttention.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, (CByte(204)))
			Me.lblAttention.Location = New Point(58, 7)
			Me.lblAttention.Name = "lblAttention"
			Me.lblAttention.Size = New Size(102, 13)
			Me.lblAttention.TabIndex = 7
			Me.lblAttention.Text = "ATTENTION ! ! !"
			Me.lblAttention.Visible = False
			' 
			' TankControl
			' 
			Me.AutoScaleDimensions = New SizeF(6F, 13F)
			Me.AutoScaleMode = AutoScaleMode.Font
			Me.BackColor = Color.MintCream
			Me.BackgroundImageLayout = ImageLayout.Stretch
			Me.Controls.Add(Me.lblAttention)
			Me.Controls.Add(Me.lblAttentionMessage)
			Me.Controls.Add(Me.pbAttention)
			Me.Controls.Add(Me.labelCurHeight)
			Me.Controls.Add(Me.picLevel)
			Me.Controls.Add(Me.pictureBoxBackground)
			Me.DoubleBuffered = True
			Me.Name = "TankControl"
			Me.Size = New Size(173, 227)
			CType(Me.pbAttention, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.picLevel, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.pictureBoxBackground, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private picLevel As PictureBox
		Private pictureBoxBackground As PictureBox
		Private labelCurHeight As Label
		Private pbAttention As PictureBox
		Private lblAttentionMessage As Label
		Private lblAttention As Label
	End Class
End Namespace

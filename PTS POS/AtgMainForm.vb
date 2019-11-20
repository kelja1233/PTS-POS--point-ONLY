Imports System.ComponentModel
Imports System.Text
Imports System.IO

Namespace TiT.PTS
	Partial Public Class AtgMainForm
		Inherits Form
		Private _pts As PTS
		Private _mainForm As MainForm

		Private _atgControl1 As AtgControl
		Private _atgControl2 As AtgControl
		Private _atgControl3 As AtgControl
		Private _atgControl4 As AtgControl

		Public Sub New()
			InitializeComponent()
		End Sub

		Public Sub New(ByVal parent As PTS, ByVal mnForm As MainForm)
			InitializeComponent()
			Me.PTS = parent
			Me._mainForm = mnForm

			For Each ctrl As Control In tableLayoutPanel.Controls
				If TypeOf ctrl Is AtgControl Then
					CType(ctrl, AtgControl).PTS = parent
				End If
			Next ctrl
		End Sub

		Public Property PTS() As PTS
			Get
				Return _pts
			End Get
			Set(ByVal value As PTS)
				_pts = value
			End Set
		End Property

		Public ReadOnly Property MainForm() As MainForm
			Get
				Return _mainForm
			End Get
		End Property

		Public Function AtgHasUniqueID(ByVal AtgID As Integer) As Boolean
			Dim counter As Integer = 0

			For Each ctrl As Control In tableLayoutPanel.Controls
				If TypeOf ctrl Is AtgControl Then
					If (CType(ctrl, AtgControl)).AtgID = AtgID Then
						counter += 1
					End If
				End If
			Next ctrl

			If counter = 1 Then
				Return True
			Else
				Return False
			End If
		End Function

		Private Sub exitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles exitToolStripMenuItem.Click
			Me.Close()
		End Sub

		Private Sub AtgMainForm_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
			e.Cancel = True
			Me.Hide()
		End Sub
	End Class
End Namespace

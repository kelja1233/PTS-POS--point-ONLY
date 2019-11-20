Public Class frmDiscount



    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Char.IsPunctuation(e.KeyChar) And e.KeyChar.ToString <> "." Or Char.IsLetter(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Then 'Allows only numbers, "." and some keys like delete, backspace, enter, etc in Control

            e.Handled = True
        End If


    End Sub

    Private Sub DisallowPaste(sender As Object, e As KeyEventArgs)
        If e.Control AndAlso (e.KeyCode = Keys.V) Then e.SuppressKeyPress = True 'Disallows paste to TextBox. Or allowing only one decimal in textchanged event can fail.
        If (e.KeyCode = Keys.Space) Then e.SuppressKeyPress = True 'Disallows paste to TextBox. Or allowing only one decimal in textchanged event can fail.


    End Sub

    Private Sub txtqty_TextChanged(sender As Object, e As EventArgs)
        If txtqty.Text.Contains(".") Then
            Dim First As Integer = txtqty.Text.IndexOf("."c)
            Dim Last As Integer = txtqty.Text.LastIndexOf("."c)
            If First <> Last Then
                Dim StartPos = txtqty.SelectionStart - 1
                txtqty.Text = txtqty.Text.Remove(txtqty.SelectionStart - 1, 1)
                txtqty.SelectionStart = StartPos
            End If
        End If

    End Sub

    Private Sub ShowInventory_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Enter Then

            Button1.PerformClick()

        End If
    End Sub

    Private Sub frmDiscount_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
      TiT.PTS.MainForm.DataGridView2.Item(5, TiT.PTS.MainForm.DataGridView2.CurrentRow.Index).Value = TiT.PTS.MainForm.DataGridView2.Item(2, TiT.PTS.MainForm.DataGridView2.CurrentRow.Index).Value * Double.Parse(txtqty.Text)
      txtqty.Text = 0.5
      Me.Close()
    Catch ex As Exception
      txtqty.Text = 0.5
      MessageBox.Show("No item Detected")
      Me.Close()
    End Try
  End Sub

  Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    Try
      TiT.PTS.MainForm.DataGridView2.Item(5, TiT.PTS.MainForm.DataGridView2.CurrentRow.Index).Value = txtqty.Text
      txtqty.Text = 0.5
            Me.Close()
        Catch ex As Exception
            txtqty.Text = 0.5
            MessageBox.Show("No item Detected")
            Me.Close()
        End Try
    End Sub
End Class
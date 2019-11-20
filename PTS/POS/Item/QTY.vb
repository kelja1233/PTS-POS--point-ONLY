Public Class QTY

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ShowInventory.sel()
        txtqty.Text = 1
        Me.Close()
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtqty.KeyPress
        If Char.IsPunctuation(e.KeyChar) And e.KeyChar.ToString <> "." Or Char.IsLetter(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Then 'Allows only numbers, "." and some keys like delete, backspace, enter, etc in Control

            e.Handled = True
        End If


    End Sub

    Private Sub DisallowPaste(sender As Object, e As KeyEventArgs) Handles txtqty.KeyDown
        If e.Control AndAlso (e.KeyCode = Keys.V) Then e.SuppressKeyPress = True 'Disallows paste to TextBox. Or allowing only one decimal in textchanged event can fail.
        If (e.KeyCode = Keys.Space) Then e.SuppressKeyPress = True 'Disallows paste to TextBox. Or allowing only one decimal in textchanged event can fail.


    End Sub

    Private Sub txtqty_TextChanged(sender As Object, e As EventArgs) Handles txtqty.TextChanged
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

   
End Class
Public Class chagexrate
    Private Sub xrate_Leave(sender As Object, e As EventArgs) Handles xrate.Leave
        If IsNumeric(xrate.Text) Then
        Else
            MessageBox.Show("invalid x-rate", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            xrate.Focus()
        End If
    End Sub

    Private Sub KryptonButton1_Click(sender As Object, e As EventArgs) Handles KryptonButton1.Click

    End Sub
End Class
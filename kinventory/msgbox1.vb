Public Class msgbox1
    Private Sub msgbox1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim r As Integer = Form2.KryptonSplitContainer6.Panel2.Height + 25
        Me.Location = New Point(Screen.PrimaryScreen.Bounds.Width - Me.Width, Screen.PrimaryScreen.Bounds.Height - (Me.Height + r))

    End Sub

    Private Sub KryptonButton30_Click(sender As Object, e As EventArgs) Handles KryptonButton30.Click
        Me.Close()
    End Sub
End Class
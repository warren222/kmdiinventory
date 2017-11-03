Public Class msgbox2
    Private Sub KryptonButton1_Click(sender As Object, e As EventArgs) Handles KryptonButton1.Click
        Me.Close()
    End Sub

    Private Sub KryptonButton30_Click(sender As Object, e As EventArgs) Handles KryptonButton30.Click
        Form2.TabControl1.SelectedIndex = 3
        Form2.issuereference.Text = ""
        Form2.issuereference.Text = Form2.reference.Text
        DEFAULTITEMS.Close()
        Me.Close()
    End Sub

    Private Sub msgbox2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim r As Integer = Form2.KryptonSplitContainer6.Panel2.Height + 25
        Me.Location = New Point(Screen.PrimaryScreen.Bounds.Width - Me.Width, Screen.PrimaryScreen.Bounds.Height - (Me.Height + r))
    End Sub
End Class
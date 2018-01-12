Public Class Form1
    Dim sql As New sql
    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        Form2.Show()
        Form2.MdiParent = Me

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Form9.KryptonLabel2.Text = "Admin" Then
            ManageAccountsToolStripMenuItem.Enabled = True
        Else
            ManageAccountsToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If MessageBox.Show("Exit Sub?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            MessageBox.Show("Cancelled", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            e.Cancel = True
            Exit Sub
        End If
        Form9.Show()
    End Sub

    Private Sub LogOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOutToolStripMenuItem.Click
        If MessageBox.Show("Exit Sub?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            MessageBox.Show("Cancelled", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Me.Close()
        Form9.Show()
    End Sub

    Private Sub ManageAccountsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManageAccountsToolStripMenuItem.Click
        Form10.ShowDialog()
    End Sub

    Private Sub ManageColumnsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManageColumnsToolStripMenuItem.Click
        managecolumns.ShowDialog()
    End Sub
End Class

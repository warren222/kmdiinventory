Imports System.Data.SqlClient
Public Class editaddress
    Dim sql As New sql
    Public sqlcmd As New SqlCommand
    Private Sub editaddress_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub KryptonButton1_Click(sender As Object, e As EventArgs) Handles KryptonButton1.Click
        If MessageBox.Show("click yes to save changes", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            MessageBox.Show("operation cancelled", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        upaddress()
        Form2.KryptonButton12.PerformClick()
        Me.Close()
    End Sub
    Public Sub upaddress()
        Try
            sql.sqlcon.Open()
            Dim ref As String = editreference.reference.Text
            Dim str As String = "update reference_TB set address = '" & address.Text & "' where reference = '" & ref & "'"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub
End Class
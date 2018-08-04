Imports System.Data.SqlClient
Public Class editaddress
    Dim sql As New sql
    Public sqlcmd As New SqlCommand
    Private Sub editaddress_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Form1.Label2.Text = "Guest" Then
            KryptonButton1.Enabled = False
        ElseIf Form1.Label2.Text = "Admin" Or Form1.Label2.Text = "Encoder" Then
            KryptonButton1.Enabled = True
        End If

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
            Dim jo As String = editreference.jo.Text
            Dim str As String = "update reference_TB set address = '" & address.Text & "' where reference = '" & ref & "' and jo = '" & jo & "'"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub
End Class
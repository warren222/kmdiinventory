Imports System.Data.SqlClient
Public Class Form6
    Dim drag As Boolean
    Dim xm As Integer
    Dim ym As Integer
    Dim sql As New sql
    Private Sub cancelorderbtn_Click(sender As Object, e As EventArgs) Handles cancelorderbtn.Click
        If KryptonLabel1.Text = "Edit Trans date" Then
            For i As Integer = 0 To transno.Items.Count - 1
                Dim trno As String = transno.Items(i)
                Dim str As String = "update trans_tb set transdate='" & transdate.Text & "' where transno = '" & trno & "'"
                update(str)
            Next
            Form2.KryptonButton11.PerformClick()
            Button1.PerformClick()
        ElseIf KryptonLabel1.Text = "Edit Due date" Then
            For i As Integer = 0 To transno.Items.Count - 1
                Dim trno As String = transno.Items(i)
                Dim str As String = "update trans_tb set duedate='" & transdate.Text & "' where transno = '" & trno & "'"
                update(str)
            Next
            Form2.KryptonButton11.PerformClick()
            Button1.PerformClick()
        Else
        End If
    End Sub
    Public Sub update(ByVal str As String)
        Try
            Dim sqlcmd As New SqlCommand
            sql.sqlcon.Open()
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Private Sub KryptonButton1_Click(sender As Object, e As EventArgs) Handles KryptonButton1.Click
        Me.Close()
    End Sub

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Form1.Label2.Text = "Guest" Then
            cancelorderbtn.Enabled = False
        ElseIf Form1.Label2.Text = "Admin" Or Form1.Label2.Text = "Encoder" Then
            cancelorderbtn.Enabled = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub KryptonPanel1_MouseDown(sender As Object, e As MouseEventArgs) Handles KryptonPanel1.MouseDown
        drag = True
        xm = Cursor.Position.X - Me.Left
        ym = Cursor.Position.Y - Me.Top
    End Sub

    Private Sub KryptonPanel1_MouseMove(sender As Object, e As MouseEventArgs) Handles KryptonPanel1.MouseMove
        If drag Then
            Me.Left = Cursor.Position.X - xm
            Me.Top = Cursor.Position.Y - ym
        End If
    End Sub

    Private Sub KryptonPanel1_MouseUp(sender As Object, e As MouseEventArgs) Handles KryptonPanel1.MouseUp
        drag = False
    End Sub
End Class
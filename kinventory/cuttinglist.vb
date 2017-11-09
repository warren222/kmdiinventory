Imports System.Data.SqlClient
Public Class cuttinglist
    Dim drag As Boolean
    Dim xm As Integer
    Dim ym As Integer
    Dim sqlcmd As New SqlCommand
    Dim da As New SqlDataAdapter
    Dim sql As New sql
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

    Private Sub cuttinglist_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Form1.Label2.Text = "Guest" Then
            KryptonButton1.Enabled = False
            KryptonButton4.Enabled = False
        ElseIf Form1.Label2.Text = "Admin" Or Form1.Label2.Text = "Encoder" Then
            KryptonButton1.Enabled = True
            KryptonButton4.Enabled = True
        End If
    End Sub

    Private Sub qty_Leave(sender As Object, e As EventArgs) Handles qty.Leave
        If Not IsNumeric(qty.Text) Then
            MessageBox.Show("invalid qty", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            qty.Focus()
        Else

        End If
    End Sub

    Private Sub KryptonButton1_Click(sender As Object, e As EventArgs) Handles KryptonButton1.Click
        If transtype.Text = "Allocation" Then
            newcuttinglist(transno.Text, qty.Text)
        Else
            MessageBox.Show("invalid transaction", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Try
            Dim x As Integer = Form2.transgridview.FirstDisplayedScrollingRowIndex
            Dim y As Integer = Form2.transgridview.FirstDisplayedScrollingColumnIndex
            Form2.KryptonButton11.PerformClick()
            Form2.transgridview.FirstDisplayedScrollingRowIndex = x
            Form2.transgridview.FirstDisplayedScrollingColumnIndex = y
        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try

    End Sub
    Public Sub newcuttinglist(ByVal mytransno As String, ByVal qty As String)
        Try
            sql.sqlcon.Open()
            Dim getremarks As String = "select remarks from trans_tb where transno = '" & mytransno & "'"
            sqlcmd = New SqlCommand(getremarks, sql.sqlcon)
            Dim read As SqlDataReader = sqlcmd.ExecuteReader
            Dim myremarks As String
            While read.Read
                myremarks = Trim(Replace(read(0).ToString, " ", ""))
            End While
            read.Close()
            Dim total As Double = 0
            Dim numbers() As String
            Dim chars As String
            Dim newremarks As String
            numbers = Split(myremarks + "+" + qty, "+")
            For Each number In numbers
                total = total + Val(number)
                chars = chars + "+" + "" & Val(number) & ""
            Next
            newremarks = chars + "=" + "" & total & ""
            newremarks = newremarks.Remove(0, 1)
            updateremarks(mytransno, newremarks)
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
        Form2.KryptonButton11.PerformClick()
    End Sub
    Public Sub updateremarks(ByVal transno As String, ByVal newremarks As String)
        Try
            Dim str As String = "update trans_tb set remarks = '" & newremarks & "' where transno = '" & transno & "'"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Private Sub KryptonButton3_Click(sender As Object, e As EventArgs) Handles KryptonButton3.Click
        If Form2.transgridview.Rows.Count > 0 Then
            Dim counter As Integer = Form2.transgridview.CurrentRow.Index + 1
            Dim nextRow As DataGridViewRow
            If counter = Form2.transgridview.RowCount Then
                nextRow = Form2.transgridview.Rows(0)
            Else
                nextRow = Form2.transgridview.Rows(counter)
            End If
            Form2.transgridview.CurrentCell = nextRow.Cells(0)
            nextRow.Selected = True
        End If
    End Sub

    Private Sub KryptonButton2_Click(sender As Object, e As EventArgs) Handles KryptonButton2.Click
        If Form2.transgridview.Rows.Count > 0 Then
            Dim counter As Integer = Form2.transgridview.CurrentRow.Index - 1
            Dim nextRow As DataGridViewRow
            If counter < Form2.transgridview.Rows(0).Index Then
                nextRow = Form2.transgridview.Rows(Form2.transgridview.Rows.Count - 1)
            Else
                nextRow = Form2.transgridview.Rows(counter)
            End If
            Form2.transgridview.CurrentCell = nextRow.Cells(0)
            nextRow.Selected = True
        End If
    End Sub
    Private Sub KryptonButton4_Click(sender As Object, e As EventArgs) Handles KryptonButton4.Click
        Try
            sql.sqlcon.Open()
            Dim str As String = "update trans_tb set remarks = '" & remarks.Text & "' where transno='" & transno.Text & "'"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            sqlcmd.ExecuteNonQuery()
            MessageBox.Show("Remarks Updated", "", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
        Dim x As Integer = Form2.transgridview.FirstDisplayedScrollingRowIndex
        Dim y As Integer = Form2.transgridview.FirstDisplayedScrollingColumnIndex
        Form2.KryptonButton11.PerformClick()
        Form2.transgridview.FirstDisplayedScrollingRowIndex = x
        Form2.transgridview.FirstDisplayedScrollingColumnIndex = y
        Button1.PerformClick()
    End Sub

    Private Sub transtype_TextChanged(sender As Object, e As EventArgs) Handles transtype.TextChanged
        KryptonLabel4.Text = transtype.Text
    End Sub
End Class
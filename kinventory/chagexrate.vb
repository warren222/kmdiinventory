Imports System.Data.SqlClient
Public Class chagexrate
    Public sqlcmd As New SqlCommand
    Public da As New SqlDataAdapter
    Dim sql As New sql
    Private Sub xrate_Leave(sender As Object, e As EventArgs) Handles xrate.Leave
        If IsNumeric(xrate.Text) Then
        Else
            MessageBox.Show("invalid x-rate", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            xrate.Focus()
        End If
    End Sub

    Private Sub KryptonButton1_Click(sender As Object, e As EventArgs) Handles KryptonButton1.Click
        If MessageBox.Show("Edit X-Rate?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            MessageBox.Show("Operation Cancelled", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        For i As Integer = 0 To transno.Items.Count - 1
            Dim tno As String = transno.Items(i).ToString
            changerate(tno, xrate.Text)
        Next
        MessageBox.Show("X-Rate update!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Form2.KryptonButton11.PerformClick()
        Me.Close()

    End Sub
    Public Sub changerate(ByVal tno As String, ByVal rate As String)
        Try
            sql.sqlcon.Open()
            Dim transtype As String
            Dim xyz As String
            Dim xyzref As String
            Dim str As String = "select transtype,xyz,xyzref from trans_tb where transno = '" & tno & "'"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            Dim read As SqlDataReader = sqlcmd.ExecuteReader
            While read.Read
                transtype = read(0).ToString
                xyz = read(1).ToString
                xyzref = read(2).ToString
            End While
            read.Close()
            If (transtype = "Order" Or transtype = "Receipt") And xyz = "" And xyzref = "" Then
                Try
                    Dim updateorder As String = "update trans_tb set netamount=(unitprice*" & rate & ")*qty,xrate=" & rate & " where transno = '" & tno & "'"
                    sqlcmd = New SqlCommand(updateorder, sql.sqlcon)
                    sqlcmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            ElseIf transtype = "Order" And xyz = "" And Not xyzref = "" Then
                Try
                    Dim updateorder As String = "
update trans_tb set netamount=(unitprice*" & rate & ")*qty,xrate=" & rate & " where transno = '" & tno & "'
update trans_tb set netamount=(unitprice*" & rate & ")*qty,xrate=" & rate & " where xyzref = '" & tno & "'"
                    sqlcmd = New SqlCommand(updateorder, sql.sqlcon)
                    sqlcmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            ElseIf transtype = "Receipt" And Not xyz = "" And Not xyzref = "" Then
                Try
                    Dim updateorder As String = "
update trans_tb set netamount=(unitprice*" & rate & ")*qty,xrate=" & rate & " where transno = '" & tno & "'
update trans_tb set netamount=(unitprice*" & rate & ")*qty,xrate=" & rate & " where xyzref = '" & tno & "'"
                    sqlcmd = New SqlCommand(updateorder, sql.sqlcon)
                    sqlcmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            Else

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub
End Class
Imports System.Data.SqlClient
Public Class Form12
    Dim sql As New sql
    Public da As New SqlDataAdapter
    Public sqlcmd As New SqlCommand
    Private Sub KryptonButton1_Click(sender As Object, e As EventArgs) Handles KryptonButton1.Click

        If MessageBox.Show("Update record?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            MessageBox.Show("Operation Cancelled", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        For i As Integer = 0 To transno.Items.Count - 1
            Dim tno As String = transno.Items(i).ToString
            If KryptonCheckBox8.Checked = True Then
                changerate(tno, xrate.Text)
            End If
            If KryptonCheckBox1.Checked = True Then
                changeunit(tno, unit.Text)
            End If
            If KryptonCheckBox2.Checked = True Then
                changeufactor(tno, ufactor.Text)
            End If
            If KryptonCheckBox3.Checked = True Then
                changedisc(tno, discount.Text)
            End If
        Next
        MessageBox.Show(" update!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Form4.KryptonButton4.PerformClick()
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
                    Dim updateorder As String = "update trans_tb set netamount=((unitprice-((disc*0.01)*unitprice))*" & rate & ")*(qty*ufactor),xrate=" & rate & " where transno = '" & tno & "'"
                    sqlcmd = New SqlCommand(updateorder, sql.sqlcon)
                    sqlcmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            ElseIf transtype = "Order" And xyz = "" And Not xyzref = "" Then
                Try
                    Dim updateorder As String = "
update trans_tb set netamount=((unitprice-((disc*0.01)*unitprice))*" & rate & ")*(qty*ufactor),xrate=" & rate & " where transno = '" & tno & "'
update trans_tb set netamount=((unitprice-((disc*0.01)*unitprice))*" & rate & ")*(qty*ufactor),xrate=" & rate & " where xyzref = '" & tno & "'"
                    sqlcmd = New SqlCommand(updateorder, sql.sqlcon)
                    sqlcmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            ElseIf transtype = "Receipt" And Not xyz = "" And Not xyzref = "" Then
                Try
                    Dim updateorder As String = "
update trans_tb set netamount=((unitprice-((disc*0.01)*unitprice))*" & rate & ")*(qty*ufactor),xrate=" & rate & " where transno = '" & tno & "'
update trans_tb set netamount=((unitprice-((disc*0.01)*unitprice))*" & rate & ")*(qty*ufactor),xrate=" & rate & " where xyzref = '" & tno & "'"
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
    Public Sub changeunit(ByVal tno As String, ByVal unit As String)
        Try
            sql.sqlcon.Open()
            Dim transtype As String
            Dim xyz As String
            Dim xyzref As String
            Dim disc As String
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
                    Dim updateorder As String = "

update trans_tb set netamount=(xrate*(" & unit & "-((disc*0.01)*" & unit & ")))*(qty*ufactor),unitprice=" & unit & " where transno = '" & tno & "'"
                    sqlcmd = New SqlCommand(updateorder, sql.sqlcon)
                    sqlcmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            ElseIf transtype = "Order" And xyz = "" And Not xyzref = "" Then
                Try
                    Dim updateorder As String = "

update trans_tb set netamount=(xrate*(" & unit & "-((disc*0.01)*" & unit & ")))*(qty*ufactor),unitprice=" & unit & " where transno = '" & tno & "'
update trans_tb set netamount=(xrate*(" & unit & "-((disc*0.01)*" & unit & ")))*(qty*ufactor),unitprice=" & unit & " where xyzref = '" & tno & "'"
                    sqlcmd = New SqlCommand(updateorder, sql.sqlcon)
                    sqlcmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            ElseIf transtype = "Receipt" And Not xyz = "" And Not xyzref = "" Then
                Try
                    Dim updateorder As String = "

update trans_tb set netamount=(xrate*(" & unit & "-((disc*0.01)*" & unit & ")))*(qty*ufactor),unitprice=" & unit & " where transno = '" & tno & "'
update trans_tb set netamount=(xrate*(" & unit & "-((disc*0.01)*" & unit & ")))*(qty*ufactor),unitprice=" & unit & " where xyzref = '" & tno & "'"
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
    Public Sub changeufactor(ByVal tno As String, ByVal ufactor As String)
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
                    Dim updateorder As String = "update trans_tb set netamount=(xrate*(unitprice-((disc*0.01)*unitprice))*(qty*" & ufactor & ")),ufactor=" & ufactor & " where transno = '" & tno & "'"
                    sqlcmd = New SqlCommand(updateorder, sql.sqlcon)
                    sqlcmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            ElseIf transtype = "Order" And xyz = "" And Not xyzref = "" Then
                Try
                    Dim updateorder As String = "
update trans_tb set netamount=(xrate*(unitprice-((disc*0.01)*unitprice))*(qty*" & ufactor & ")),ufactor=" & ufactor & " where transno = '" & tno & "'
update trans_tb set netamount=(xrate*(unitprice-((disc*0.01)*unitprice))*(qty*" & ufactor & ")),ufactor=" & ufactor & " where xyzref = '" & tno & "'"
                    sqlcmd = New SqlCommand(updateorder, sql.sqlcon)
                    sqlcmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            ElseIf transtype = "Receipt" And Not xyz = "" And Not xyzref = "" Then
                Try
                    Dim updateorder As String = "
update trans_tb set netamount=(xrate*(unitprice-((disc*0.01)*unitprice))*(qty*" & ufactor & ")),ufactor=" & ufactor & " where transno = '" & tno & "'
update trans_tb set netamount=(xrate*(unitprice-((disc*0.01)*unitprice))*(qty*" & ufactor & ")),ufactor=" & ufactor & " where xyzref = '" & tno & "'"
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
    Public Sub changedisc(ByVal tno As String, ByVal disc As String)
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
                    Dim updateorder As String = "update trans_tb set netamount=(xrate*(unitprice-((" & disc & "*0.01)*unitprice))*(qty*ufactor)),disc=" & disc & " where transno = '" & tno & "'"
                    sqlcmd = New SqlCommand(updateorder, sql.sqlcon)
                    sqlcmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            ElseIf transtype = "Order" And xyz = "" And Not xyzref = "" Then
                Try
                    Dim updateorder As String = "
update trans_tb set netamount=(xrate*(unitprice-((" & disc & "*0.01)*unitprice))*(qty*ufactor)),disc=" & disc & " where transno = '" & tno & "'
update trans_tb set netamount=(xrate*(unitprice-((" & disc & "*0.01)*unitprice))*(qty*ufactor)),disc=" & disc & " where xyzref = '" & tno & "'"
                    sqlcmd = New SqlCommand(updateorder, sql.sqlcon)
                    sqlcmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            ElseIf transtype = "Receipt" And Not xyz = "" And Not xyzref = "" Then
                Try
                    Dim updateorder As String = "
update trans_tb set netamount=(xrate*(unitprice-((" & disc & "*0.01)*unitprice))*(qty*ufactor)),disc=" & disc & " where transno = '" & tno & "'
update trans_tb set netamount=(xrate*(unitprice-((" & disc & "*0.01)*unitprice))*(qty*ufactor)),disc=" & disc & " where xyzref = '" & tno & "'"
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

    Private Sub Form12_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Form1.Label2.Text = "Guest" Then
            KryptonButton1.Enabled = False
        ElseIf Form1.Label2.Text = "Admin" Or Form1.Label2.Text = "Encoder" Then
            KryptonButton1.Enabled = True
        End If

    End Sub

    Private Sub Form12_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        KryptonCheckBox8.Checked = False
        KryptonCheckBox1.Checked = False
        KryptonCheckBox2.Checked = False
        KryptonCheckBox3.Checked = False
    End Sub

    Private Sub ufactor_Leave(sender As Object, e As EventArgs) Handles ufactor.Leave
        If IsNumeric(ufactor.Text) Then
        Else
            MessageBox.Show("invalid ufactor", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ufactor.Focus()
        End If
    End Sub

    Private Sub unit_Leave(sender As Object, e As EventArgs) Handles unit.Leave
        If IsNumeric(unit.Text) Then
        Else
            MessageBox.Show("invalid unit price", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            unit.Focus()
        End If
    End Sub

    Private Sub discount_Leave(sender As Object, e As EventArgs) Handles discount.Leave
        If IsNumeric(discount.Text) Then
        Else
            MessageBox.Show("invalid discount", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            discount.Focus()
        End If
    End Sub

    Private Sub xrate_Leave(sender As Object, e As EventArgs) Handles xrate.Leave
        If IsNumeric(xrate.Text) Then
        Else
            MessageBox.Show("invalid xrate", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            xrate.Focus()
        End If
    End Sub
End Class
Imports System.Data.SqlClient
Public Class adjustment
    Dim sql As New sql
    Dim sqlcmd As New SqlCommand
    Dim x As Integer
    Dim y As Integer
    Dim drag As Boolean
    Private Sub KryptonButton4_Click(sender As Object, e As EventArgs) Handles KryptonButton4.Click
        Dim transtype As String = "+Adjustment"
        inserthistory(transtype)
        additional(transtype)
        getupdateddata()
        locationform.KryptonButton8.PerformClick()
    End Sub
    Public Sub inserthistory(ByVal transtype As String)
        Try
            sql.sqlcon.Open()
            Dim str As String = "
declare @autonum as decimal(10,2)=(select max(id)+1 from lochistory)
insert into lochistory
(ID,
TRANSTYPE,
TRANSDATE,
STOCKNO,
REFERENCE,
LOCATION,
QTY)
values
(@autonum,
'" & transtype & "'," &
"'" & Form2.transdate.Text & "'," &
"'" & stockno.Text & "'," &
"''," &
"'" & setlocation.Text & "'," &
"'" & setqty.Text & "')"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub
    Public Sub additional(ByVal transtype As String)
        Try
            sql.sqlcon.Open()
            Dim str As String
            If transtype = "+Adjustment" Then
                str = "update locationtb set  qty=qty+" & setqty.Text & " where stockno='" & stockno.Text & "' and location='" & setlocation.Text & "'"
            ElseIf transtype = "-Adjustment" Then
                str = "update locationtb set  qty=qty-" & setqty.Text & " where stockno='" & stockno.Text & "' and location='" & setlocation.Text & "'"
            End If
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            sqlcmd.ExecuteNonQuery()
            setqty.Text = 0
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Private Sub KryptonButton5_Click(sender As Object, e As EventArgs) Handles KryptonButton5.Click
        Dim transtype As String = "-Adjustment"
        inserthistory(transtype)
        additional(transtype)
        getupdateddata()
        locationform.KryptonButton8.PerformClick()
    End Sub
    Public Sub getupdateddata()
        Try
            sql.sqlcon.Open()
            Dim str As String = "select location,qty from locationtb where stockno= '" & stockno.Text & "' and location = '" & setlocation.Text & "'"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            Dim read As SqlDataReader = sqlcmd.ExecuteReader
            While read.Read
                setlocation.Text = read(0).ToString
                currentqty.Text = read(1).ToString
            End While
            read.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Private Sub KryptonPanel1_MouseDown(sender As Object, e As MouseEventArgs) Handles KryptonPanel1.MouseDown
        drag = True
        x = Cursor.Position.X - Me.Left
        y = Cursor.Position.Y - Me.Top
    End Sub

    Private Sub KryptonPanel1_MouseMove(sender As Object, e As MouseEventArgs) Handles KryptonPanel1.MouseMove
        If drag = True Then
            Me.Left = Cursor.Position.X - x
            Me.Top = Cursor.Position.Y - y
        End If
    End Sub

    Private Sub KryptonPanel1_MouseUp(sender As Object, e As MouseEventArgs) Handles KryptonPanel1.MouseUp
        drag = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        setqty.Text = 0
        Me.Close()
    End Sub
End Class
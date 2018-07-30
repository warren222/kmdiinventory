Imports System.Data.SqlClient
Public Class transfer
    Dim drag As Boolean
    Dim x As Integer
    Dim y As Integer

    Dim sql As New sql
    Public SQLCMD As New SqlCommand
    Private Sub KryptonButton4_Click(sender As Object, e As EventArgs) Handles KryptonButton4.Click
        If setlocation.Text = location.Text Then
            MessageBox.Show("set new location")
        ElseIf CInt(setqty.Text) > CInt(currentqty.Text) Then
            MessageBox.Show("insufficient quantity")
        Else
            inserthistory()
            transferme()
            getupdateddata()
            locationform.KryptonButton8.PerformClick()
        End If

    End Sub
    Public Sub inserthistory()
        Try
            sql.sqlcon.Open()
            Dim m As Double = setqty.Text
            Dim getrloc As String = "
declare @currentloc as integer = (select qty from locationtb where stockno = '" & stockno.Text & "' and location = '" & location.Text & "')-" & m & "
declare @newloc as integer = (select qty from locationtb where stockno = '" & stockno.Text & "' and location = '" & setlocation.Text & "')+" & m & "

select @currentloc,@newloc
"
            SQLCMD = New SqlCommand(getrloc, sql.sqlcon)
            Dim lb As String
            Dim lv As String
            Dim rd As SqlDataReader = SQLCMD.ExecuteReader
            While rd.Read
                lb = rd(0).ToString
                lv = rd(1).ToString
            End While
            rd.Close()


            Dim physical As String
            Dim l As String = "declare @sd as varchar(50)=(select sum(qty) from locationtb where stockno = '" & stockno.Text & "')
select @sd"
            SQLCMD = New SqlCommand(l, sql.sqlcon)
            Dim read1 As SqlDataReader = SQLCMD.ExecuteReader
            While read1.Read
                physical = read1(0).ToString
            End While
            read1.Close()
            Dim p As Double = physical
            Dim q As Double = setqty.Text


            Dim str As String = "
declare @autonum as decimal(10,2)=(select max(id)+1 from lochistory)
insert into lochistory
(ID,
TRANSTYPE,
TRANSDATE,
STOCKNO,
REFERENCE,
LOCATION,
QTY,
balqty,RBALQTY)
values
(@autonum,
'-Transfer'," &
"'" & Form2.transdate.Text & "'," &
"'" & stockno.Text & "'," &
"'" & setlocation.Text & "'," &
"'" & location.Text & "'," &
"'" & setqty.Text & "','" & p & "','" & lb & "')"
            SQLCMD = New SqlCommand(str, sql.sqlcon)
            SQLCMD.ExecuteNonQuery()

            Dim f As String = "
declare @autonum as decimal(10,2)=(select max(id)+1 from lochistory)
insert into lochistory
(ID,
TRANSTYPE,
TRANSDATE,
STOCKNO,
REFERENCE,
LOCATION,
QTY,
balqty,RBALQTY)
values
(@autonum,
'+Transfer'," &
"'" & Form2.transdate.Text & "'," &
"'" & stockno.Text & "'," &
"'" & location.Text & "'," &
"'" & setlocation.Text & "'," &
"'" & setqty.Text & "','" & p & "','" & lv & "')"
            SQLCMD = New SqlCommand(f, sql.sqlcon)
            SQLCMD.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub
    Public Sub transferme()
        Try
            sql.sqlcon.Open()
            Dim str As String = "
update locationtb set qty=qty-" & setqty.Text & " where stockno = '" & stockno.Text & "' and location='" & location.Text & "'
update locationtb set qty=qty+" & setqty.Text & " where stockno = '" & stockno.Text & "' and location='" & setlocation.Text & "'
"
            SQLCMD = New SqlCommand(str, sql.sqlcon)
            SQLCMD.ExecuteNonQuery()
            setqty.Text = 0
        Catch ex As SqlException
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Public Sub getupdateddata()
        Try
            sql.sqlcon.Open()
            Dim str As String = "select location,qty from locationtb where stockno= '" & stockno.Text & "' and location = '" & location.Text & "'"
            SQLCMD = New SqlCommand(str, sql.sqlcon)
            Dim read As SqlDataReader = SQLCMD.ExecuteReader
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

    Private Sub transfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadlocation()
    End Sub
    Public Sub loadlocation()
        Try
            sql.sqlcon.Open()
            Dim str As String = "select location from locationtb where stockno = '" & stockno.Text & "'"
            SQLCMD = New SqlCommand(str, sql.sqlcon)
            Dim ds As New DataSet
            ds.Clear()
            Dim bs As New BindingSource
            Dim da As New SqlDataAdapter
            da.SelectCommand = SQLCMD
            da.Fill(ds, "locationtb")
            bs.DataSource = ds
            bs.DataMember = "locationtb"
            setlocation.DataSource = bs
            setlocation.DisplayMember = "location"
        Catch ex As SqlException
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        setqty.Text = 0
        Me.Dispose()
    End Sub

    Private Sub KryptonPanel1_MouseDown(sender As Object, e As MouseEventArgs) Handles KryptonPanel1.MouseDown
        drag = True
        x = Cursor.Position.X - Me.Left
        y = Cursor.Position.Y - Me.Top
    End Sub

    Private Sub KryptonPanel1_MouseMove(sender As Object, e As MouseEventArgs) Handles KryptonPanel1.MouseMove
        If drag Then
            Me.Left = Cursor.Position.X - x
            Me.Top = Cursor.Position.Y - y
        End If
    End Sub

    Private Sub KryptonPanel1_MouseUp(sender As Object, e As MouseEventArgs) Handles KryptonPanel1.MouseUp
        drag = False
    End Sub

    Private Sub setqty_Leave(sender As Object, e As EventArgs) Handles setqty.Leave
        If IsNumeric(setqty.Text) Then
        Else
            MessageBox.Show("non numeric value detected")
            setqty.Focus()
        End If
    End Sub
End Class
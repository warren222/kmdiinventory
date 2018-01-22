Imports System.Data.SqlClient
Imports Transitions
Public Class locationform
    Dim sql As New sql
    Public sqlcmd As New SqlCommand
    Public DA As New SqlDataAdapter

    Dim x As Integer
    Dim y As Integer
    Dim drag As Boolean
    Private Sub location_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim l1 As New Transition(New TransitionType_Deceleration(300))
        l1.add(Panel2, "Width", 28)
        l1.add(locationgridview, "Top", 66)
        l1.run()
        locationgridview.Size = New Size(308, 380)
        LOADLOCATIONTB()

    End Sub
    Public Sub loadsummary()
        Try

            Dim ds As New DataSet
            ds.Clear()
            Dim bs As New BindingSource

            Dim str As String = "
select 

LOCATION,sum(qty) AS QTY

from LOCATIONTB group by location 

union all

select 'Total',sum(qty) from locationtb"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            DA.SelectCommand = sqlcmd
            DA.Fill(ds, "locationtb")
            bs.DataSource = ds
            bs.DataMember = "locationtb"
            KryptonDataGridView1.DataSource = bs
            KryptonDataGridView1.Columns("LOCATION").DefaultCellStyle.Font = New Font("Tahoma", 10, FontStyle.Bold)
            KryptonDataGridView1.Columns("QTY").DefaultCellStyle.Font = New Font("Tahoma", 10, FontStyle.Bold)
            KryptonDataGridView1.Columns("QTY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            KryptonDataGridView1.Columns("QTY").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            KryptonDataGridView1.Columns("QTY").DefaultCellStyle.Format = "N2"
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub LOADLOCATIONTB()
        Try
            sql.sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            Dim str As String = "
select * from locationtb where stockno = '" & stockno.Text & "'
union all
select '','','Total',sum(qty) from locationtb where stockno = '" & stockno.Text & "'
"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            DA.SelectCommand = sqlcmd
            DA.Fill(ds, "locationtb")
            bs.DataSource = ds
            bs.DataMember = "locationtb"
            locationgridview.DataSource = bs
            locationgridview.Columns("ID").Visible = False
            locationgridview.Columns("STOCKNO").Visible = False
            locationgridview.Columns("LOCATION").DefaultCellStyle.Font = New Font("Tahoma", 10, FontStyle.Bold)
            locationgridview.Columns("QTY").DefaultCellStyle.Font = New Font("Tahoma", 10, FontStyle.Bold)
            locationgridview.Columns("QTY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            locationgridview.Columns("QTY").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            locationgridview.Columns("QTY").DefaultCellStyle.Format = "N2"
            setlocation.Text = ""
            currentqty.Text = "0"
            loadsetlocation()
            loadsummary()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Private Sub KryptonButton1_Click(sender As Object, e As EventArgs) Handles KryptonButton1.Click
        location.Text = location.Text.Replace("'", "")
        location.Text = location.Text.Replace("""", "")
        qty.Text = qty.Text.Replace("'", "")
        qty.Text = qty.Text.Replace("""", "")
        additem()
        LOADLOCATIONTB()
    End Sub
    Public Sub additem()
        Try
            sql.sqlcon.Open()
            Dim str As String = "
declare @id as integer=(select isnull(max(id),0)+1 from locationtb)
insert into locationtb (ID,STOCKNO,LOCATION,QTY) VALUES  (@id,'" & stockno.Text & "','" & location.Text & "','" & qty.Text & "')"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Private Sub locationgridview_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles locationgridview.CellClick
        If locationgridview.RowCount >= 0 And e.RowIndex >= 0 Then
            id.Text = locationgridview.Item(0, e.RowIndex).Value.ToString
            location.Text = locationgridview.Item(2, e.RowIndex).Value.ToString
            qty.Text = locationgridview.Item(3, e.RowIndex).Value.ToString
        End If

        qty.Text = qty.Text.Replace(",", "")
    End Sub

    Private Sub KryptonButton2_Click(sender As Object, e As EventArgs) Handles KryptonButton2.Click
        updateitem()
        LOADLOCATIONTB()
    End Sub
    Public Sub updateitem()
        Try
            sql.sqlcon.Open()
            Dim str As String = "update locationtb set location = '" & location.Text & "' , qty = '" & qty.Text & "' where id = '" & id.Text & "'"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub
    Private Sub KryptonButton3_Click(sender As Object, e As EventArgs) Handles KryptonButton3.Click
        If MessageBox.Show("click yes to continue", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            MessageBox.Show("operation cancelled", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        deleteitem()
        LOADLOCATIONTB()
    End Sub
    Public Sub deleteitem()
        Try
            sql.sqlcon.Open()
            Dim str As String = "delete from locationtb where id = '" & id.Text & "'"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If balance.Text = "0" Then
            Me.Dispose()
            Me.Close()

        Else
            MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub KryptonPanel1_MouseUp(sender As Object, e As MouseEventArgs) Handles KryptonPanel1.MouseUp
        drag = False
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

    Private Sub setlocation_MouseDown(sender As Object, e As MouseEventArgs) Handles setlocation.MouseDown
        Dim i As Integer = setlocation.SelectedIndex

        If i > setlocation.Items.Count - 1 Then
            setlocation.SelectedIndex = -1
        Else
            setlocation.SelectedIndex = i
        End If
    End Sub
    Public Sub loadsetlocation()
        Try

            Dim ds As New DataSet
            ds.Clear()
            Dim da As New SqlDataAdapter
            Dim bs As New BindingSource

            Dim str As String = "select distinct location from locationtb where stockno='" & stockno.Text & "'"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "locationtb")
            bs.DataSource = ds
            bs.DataMember = "locationtb"
            setlocation.DataSource = bs
            setlocation.DisplayMember = "location"
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub setlocation_TextChanged(sender As Object, e As EventArgs) Handles setlocation.TextChanged
        Try
            sql.sqlcon.Close()
            sql.sqlcon.Open()
            Dim str As String = "select qty from locationtb where stockno = '" & stockno.Text & "' and location = '" & setlocation.Text & "'"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            Dim read As SqlDataReader = sqlcmd.ExecuteReader
            While read.Read
                currentqty.Text = read(0).ToString
            End While
            read.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Private Sub KryptonButton4_Click(sender As Object, e As EventArgs) Handles KryptonButton4.Click
        additional()
        Dim loc As String = setlocation.Text
        setlocation.Text = ""
        LOADLOCATIONTB()
        setlocation.Text = loc
    End Sub
    Public Sub additional()
        Try
            sql.sqlcon.Open()
            Dim str As String = "update locationtb set  qty=qty+" & setqty.Text & " where stockno='" & stockno.Text & "' and location='" & setlocation.Text & "'"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            sqlcmd.ExecuteNonQuery()
            balance.Text = balance.Text - setqty.Text
            setqty.Text = 0

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Private Sub setqty_Leave(sender As Object, e As EventArgs) Handles setqty.Leave
        If IsNumeric(setqty.Text) Then
            Dim x As Integer = balance.Text
            Dim y As Integer = setqty.Text
            If x < y Then
                MessageBox.Show("insufficient balance", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
            End If
        Else
            MessageBox.Show("non numeric data detected, please make sure you type a valid number", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            setqty.Focus()
        End If
    End Sub

    Private Sub KryptonButton5_Click(sender As Object, e As EventArgs) Handles KryptonButton5.Click
        Dim x As Integer = currentqty.Text
        Dim y As Integer = setqty.Text

        If x < y Then
            MessageBox.Show("insufficient stocks", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            subtract()
            Dim loc As String = setlocation.Text
            setlocation.Text = ""
            LOADLOCATIONTB()
            setlocation.Text = loc
        End If


    End Sub
    Public Sub subtract()
        Try
            sql.sqlcon.Open()
            Dim str As String = "update locationtb set  qty=qty-" & setqty.Text & " where stockno='" & stockno.Text & "' and location='" & setlocation.Text & "'"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            sqlcmd.ExecuteNonQuery()
            balance.Text = balance.Text - setqty.Text
            setqty.Text = 0

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Private Sub KryptonButton6_Click(sender As Object, e As EventArgs) Handles KryptonButton6.Click
        Dim l1 As New Transition(New TransitionType_Deceleration(300))
        Dim c1 As New Transition(New TransitionType_Acceleration(300))


        If Panel2.Width = 28 Then
            c1.add(Panel2, "Width", 337)
            c1.add(locationgridview, "Top", 202)
            c1.run()
            locationgridview.Size = New Size(308, 244)
        Else
            l1.add(Panel2, "Width", 28)
            l1.add(locationgridview, "Top", 66)
            l1.run()
            locationgridview.Size = New Size(308, 380)
        End If



    End Sub

    Private Sub qty_Leave(sender As Object, e As EventArgs) Handles qty.Leave
        If IsNumeric(qty.Text) Then
        Else
            MessageBox.Show("non numeric data detected, please make sure you type a valid number", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            qty.Focus()
        End If
    End Sub

    Private Sub KryptonButton7_Click(sender As Object, e As EventArgs) Handles KryptonButton7.Click
        Dim t1 As New Transition(New TransitionType_Acceleration(300))
        If Panel4.Width = 592 Then
            t1.add(Panel4, "Width", 920)
            t1.run()
        Else
            t1.add(Panel4, "Width", 592)
            t1.run()
        End If

    End Sub
End Class
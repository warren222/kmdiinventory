Imports System.Data.SqlClient
Public Class HISTORY
    Dim sql As New sql
    Dim sqlcmd As New SqlCommand

    Dim x As Integer
    Dim y As Integer
    Dim drag As Boolean
    Private Sub KryptonButton1_Click(sender As Object, e As EventArgs) Handles KryptonButton1.Click
        load()
    End Sub
    Public Sub load()
        Try
            sql.sqlcon.Open()
            Dim acol As String = "STOCKNO"
            Dim a As String = stockno.Text
            Dim bcol As String = "LOCATION"
            Dim b As String = location.Text

            If a = "" Then
                a = acol
            Else
                a = "'" & a & "'"
            End If
            If b = "" Then
                b = bcol
            Else
                b = "'" & b & "'"
            End If
            Dim str As String = "

declare @myadd as decimal(10,2)=(select isnull(sum(qty),0) from LOCHISTORY WHERE (TRANSTYPE='Receipt' or TRANSTYPE = 'Return' or TRANSTYPE='+Adjustment' or TRANSTYPE='+Transfer') and (" & acol & "=" & a & " and " & bcol & "=" & b & "))
declare @mysub as decimal(10,2)=(select isnull(sum(qty),0) from LOCHISTORY WHERE (TRANSTYPE = 'Issue' or TRANSTYPE='-Adjustment' or TRANSTYPE = '-Transfer') and (" & acol & "=" & a & " and " & bcol & "=" & b & "))

select ID
      ,TRANSTYPE
      ,TRANSDATE
      ,STOCKNO
,REFERENCE
      ,LOCATION
      ,BALQTY,RBALQTY,QTY from lochistory  where " & acol & "=" & a & " and " & bcol & "=" & b & "
union 
	  select '','','','','','Total',0,0,@myadd-@mysub from LOCHISTORY where " & acol & "=" & a & " and " & bcol & "=" & b & "
      order by id desc

"

            Dim ds As New DataSet
            ds.Clear()
            Dim da As New SqlDataAdapter
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "lochistory")
            Dim bs As New BindingSource
            bs.DataSource = ds
            bs.DataMember = "lochistory"
            transactiongridview.DataSource = bs
            transactiongridview.Columns("ID").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            transactiongridview.Columns("qty").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            transactiongridview.Columns("LOCATION").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            transactiongridview.Columns("stockno").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            transactiongridview.Columns("transdate").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            transactiongridview.Columns("transtype").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            transactiongridview.Columns("qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            transactiongridview.Columns("balqty").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            transactiongridview.Columns("balqty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            transactiongridview.Columns("RBALQTY").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            transactiongridview.Columns("RBALQTY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            transactiongridview.Columns("qty").DefaultCellStyle.Format = "N2"
            transactiongridview.Columns("balqty").DefaultCellStyle.Format = "N2"
            transactiongridview.Columns("RBALQTY").DefaultCellStyle.Format = "N2"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Private Sub HISTORY_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
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
End Class
Imports System.Data.SqlClient
Public Class checklisted
    Dim sql As New sql
    Public sqlcmd As New SqlCommand
    Public da As New SqlDataAdapter

    Dim X As Integer
    Dim Y As Integer
    Dim DRAG As Boolean
    Private Sub KryptonButton3_Click(sender As Object, e As EventArgs) Handles KryptonButton3.Click
        loadchecklisted()
    End Sub
    Public Sub loadchecklisted()
        Try
            sql.sqlcon1.Open()
            Dim ds As New DataSet
            Dim BS As New BindingSource
            ds.Clear()
            Dim STR As String = "SELECT PROJECT_LABEL,CHECKLISTED FROM ADDENDUM_TO_CONTRACT_TB WHERE NOT CHECKLISTED ='' AND CA = ''"
            sqlcmd = New SqlCommand(STR, sql.sqlcon1)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "ADDENDUM_TO_CONTRACT_TB")
            BS.DataSource = ds
            BS.DataMember = "ADDENDUM_TO_CONTRACT_TB"
            CHECKLISTEDgridview.DataSource = BS
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon1.Close()
        End Try
    End Sub

    Private Sub CHECKLISTEDgridview_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles CHECKLISTEDgridview.CellClick
        If CHECKLISTEDgridview.RowCount >= 0 And e.RowIndex >= 0 Then
            projectlabel.Text = CHECKLISTEDgridview.Item(0, e.RowIndex).Value.ToString
        End If
        loadreference(projectlabel.Text)
    End Sub
    Public Sub loadreference(ByVal reference As String)
        Try
            sql.sqlcon.Open()
            Dim ds As New DataSet
            ds.Clear()
            Dim bs As New BindingSource

            Dim str As String = "select a.REFERENCE,
a.STOCKNO,
a.ALLOCATION
from reference_tb as a
inner join
stocks_tb as b
on a.stockno=b.stockno where a.reference like '%" & reference & "%' and a.allocation > 0"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "reference_tb")
            bs.DataSource = ds
            bs.DataMember = "reference_tb"
            allocationGridView.DataSource = bs
            allocationGridView.Columns("STOCKNO").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            allocationGridView.Columns("ALLOCATION").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            allocationGridView.Columns("ALLOCATION").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Private Sub allocationGridView_SelectionChanged(sender As Object, e As EventArgs) Handles allocationGridView.SelectionChanged
        refcombo.Items.Clear()
        refstock.Items.Clear()
        Dim selecteditems As DataGridViewSelectedRowCollection = allocationGridView.SelectedRows
        Dim x As String
        Dim y As String
        For Each selecteditem As DataGridViewRow In selecteditems
            x = selecteditem.Cells("reference").Value.ToString
            y = selecteditem.Cells("stockno").Value.ToString
            refcombo.Items.Add(x)
            refstock.Items.Add(y)
        Next
    End Sub

    Private Sub allocationGridView_MouseDown(sender As Object, e As MouseEventArgs) Handles allocationGridView.MouseDown
        If e.Button = MouseButtons.Right Then
            ContextMenuStrip1.Show(allocationGridView, New Point(e.X, e.Y))
        End If
    End Sub

    Private Sub CancelAllocationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelAllocationToolStripMenuItem.Click
        cancelall.KryptonButton2.Visible = False
        cancelall.header.Text = "checklisted"
        cancelall.ShowDialog()
    End Sub

    Private Sub KryptonButton1_Click(sender As Object, e As EventArgs) Handles KryptonButton1.Click
        allocationGridView.SelectAll()
        cancelall.KryptonButton2.Visible = False
        cancelall.header.Text = "checklisted"
        cancelall.ShowDialog()
    End Sub

    Private Sub checklisted_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        allocationGridView.DataSource = Nothing
    End Sub

    Private Sub checklisted_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadchecklisted()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Panel3_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel3.MouseUp
        DRAG = False
    End Sub

    Private Sub Panel3_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel3.MouseDown
        DRAG = True
        X = Cursor.Position.X - Me.Left
        Y = Cursor.Position.Y - Me.Top
    End Sub

    Private Sub Panel3_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel3.MouseMove
        If DRAG Then
            Me.Left = Cursor.Position.X - X
            Me.Top = Cursor.Position.Y - Y
        End If
    End Sub

End Class
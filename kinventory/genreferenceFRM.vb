Imports System.Data.SqlClient
Public Class genreferenceFRM
    Dim sqlcmd As New SqlCommand
    Dim sql As New sql
    Dim da As New SqlDataAdapter
    Private Sub genreferenceFRM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadreference()
    End Sub
    Public Sub loadreference()
        Try
            sql.sqlcon1.Close()
            sql.sqlcon1.Open()
            Dim ds As New DataSet
            ds.Clear()
            Dim str As String
            If Me.Text = "Input" Then
                str = "select distinct project_label from addendum_to_contract_tb"
            ElseIf Me.Text = "Receipt" Then
                str = "select distinct project_label from addendum_to_contract_tb where project_label in (select reference from heretosave.dbo.reference_tb where STOCKORDER > 0)"
            ElseIf Me.Text = "Issue" Then
                str = "select distinct project_label from addendum_to_contract_tb where project_label in (select reference from heretosave.dbo.trans_tb where transtype = 'Allocation')"
            ElseIf Me.Text = "movealloc" Or Me.Text = "multimove" Or Me.Text = "transman" Or Me.Text = "reference" Or Me.Text = "form5" Then
                str = "select distinct project_label from addendum_to_contract_tb where project_label in (select reference from heretosave.dbo.trans_tb)"
            End If

            sqlcmd = New SqlCommand(str, sql.sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "addendum_to_contract_Tb")
            Dim bs As New BindingSource
            bs.DataSource = ds
            bs.DataMember = "addendum_to_contract_tb"
            reference.DataSource = bs
            reference.DisplayMember = "project_label"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon1.Close()
        End Try
    End Sub

    Private Sub reference_textchange(sender As Object, e As EventArgs) Handles reference.TextChanged
        databaseform()
    End Sub
    Public Sub databaseform()
        Try
            sql.sqlcon1.Close()
            sql.sqlcon1.Open()
            Dim ds As New DataSet
            ds.Clear()
            Dim str As String = "select job_order_no,parentjono,sub_jo,project_label from addendum_to_contract_tb where project_label = '" & reference.Text & "'
                                and not lock = 1 order by job_order_no asc"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "addendum_to_contract_Tb")
            Dim bs As New BindingSource
            bs.DataSource = ds
            bs.DataMember = "addendum_to_contract_tb"
            GridView.DataSource = bs
            With GridView
                .Columns("job_order_no").Visible = False
                .Columns("parentjono").Visible = False
                .Columns("sub_jo").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon1.Close()
        End Try
    End Sub

    Private Sub KryptonButton5_Click(sender As Object, e As EventArgs) Handles KryptonButton5.Click
        databaseform()
    End Sub

    Private Sub GridView_SelectionChanged(sender As Object, e As EventArgs) Handles GridView.SelectionChanged
        Dim selecteditems As DataGridViewSelectedRowCollection = GridView.SelectedRows
        Dim xx As ArrayList = New ArrayList(selecteditems.Count)
        Dim yy As ArrayList = New ArrayList(selecteditems.Count)
        For Each row As DataGridViewRow In selecteditems
            xx.Add(row.Cells("project_label").Value.ToString)
            yy.Add(row.Cells("parentjono").Value.ToString)
        Next
        For i As Integer = 0 To xx.Count - 1
            Dim project As String = xx(i).ToString
            Dim pjo As String = yy(i).ToString
            If Me.Text = "Input" Then
                Form2.reference.Text = project
                Form2.jo.Text = pjo
            ElseIf Me.Text = "Receipt" Then
                Form2.receiptreference.Text = project
                Form2.receiptjo.Text = pjo
            ElseIf Me.Text = "Issue" Then
                Form2.issuereference.Text = project
                Form2.issuejo.Text = pjo
            ElseIf Me.Text = "movealloc" Then
                moveallocation.reference.Text = project
                moveallocation.jo.Text = pjo
            ElseIf Me.Text = "multimove" Then
                multimove.reference.Text = project
                multimove.JO.Text = pjo
            ElseIf Me.Text = "transman" Then
                Form2.transreference.Text = project
                Form2.transjo.Text = pjo
            ElseIf Me.Text = "reference" Then
                Form2.reffromreference.Text = project
                Form2.reffromjo.Text = pjo
            ElseIf Me.Text = "form5" Then
                Form5.newreference.Text = project
                Form5.NEWJO.Text = pjo
            End If
        Next
    End Sub
End Class
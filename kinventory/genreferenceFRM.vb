Imports System.Data.SqlClient
Public Class genreferenceFRM
    Dim sqlcmd As New SqlCommand
    Dim sql As New sql
    Dim da As New SqlDataAdapter
    Private Sub genreferenceFRM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadreference()
        reference.SelectedIndex = -1
        reference.Focus()
    End Sub
    Public Sub loadreference()
        Try
            sql.sqlcon.Close()
            sql.sqlcon.Open()
            Dim ds As New DataSet
            ds.Clear()
            Dim str As String = " select distinct project_label from kmdidata.dbo.addendum_to_contract_tb 

                                union 

                                select distinct reference from reference_tb"

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
            sql.sqlcon.Close()
        End Try
    End Sub

    Private Sub reference_textchange(sender As Object, e As EventArgs) Handles reference.TextChanged

        ' databaseform()
    End Sub
    Public Sub databaseform()
        Try
            sql.sqlcon.Close()
            sql.sqlcon.Open()
            Dim ds As New DataSet
            ds.Clear()
            Dim str As String = "select 
                                 distinct
                                 job_order_no,
                                 parentjono as [original jo],
                                 sub_jo,
                                 project_label,
                                 '0' as label 
                                 from 
                                 kmdidata.dbo.addendum_to_contract_tb 
                                 where 
                                 not lock = 1 and PROJECT_LABEL='" & reference.Text & "' and turn_over = ''

                                 union 

                                 select 
                                 distinct 
                                 jo,
                                 jo,
                                 jo,
                                 reference,
                                 '1' as label 
                                 from 
                                 reference_tb 
                                 where jo=''
                                 and reference= '" & reference.Text & "' order by project_label"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "addendum_to_contract_Tb")
            Dim bs As New BindingSource
            bs.DataSource = ds
            bs.DataMember = "addendum_to_contract_tb"
            GridView.DataSource = bs
            With GridView
                .Columns("job_order_no").Visible = False
                .Columns("label").Visible = False
                .Columns("sub_jo").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With
            For i As Integer = 0 To GridView.RowCount - 1
                If GridView.Rows(i).Cells("label").Value = "1" Then
                    GridView.Rows(i).Cells("project_label").Style.Font = New Font("Tahoma", 9, FontStyle.Bold)
                    GridView.Rows(i).Cells("sub_jo").Style.Font = New Font("Tahoma", 9, FontStyle.Bold)
                End If
            Next

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

    End Sub

    Private Sub GridView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridView.CellDoubleClick
        Me.Close()
    End Sub

    Private Sub genreferenceFRM_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim selecteditems As DataGridViewSelectedRowCollection = GridView.SelectedRows
        Dim xx As ArrayList = New ArrayList(selecteditems.Count)
        Dim yy As ArrayList = New ArrayList(selecteditems.Count)
        For Each row As DataGridViewRow In selecteditems
            xx.Add(row.Cells("project_label").Value.ToString)
            yy.Add(row.Cells("original jo").Value.ToString)
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
            ElseIf Me.Text = "change reference" Then
                changereferenceFRM.reference.Text = project
                changereferenceFRM.jo.Text = pjo
                changereferenceFRM.Button3.PerformClick()
            End If
        Next


        If Me.Text = "Input" Then
            Form2.reference.Text = reference.Text
        ElseIf Me.Text = "transman" Then
            Form2.transreference.Text = reference.Text
        End If
    End Sub

    Private Sub reference_KeyDown(sender As Object, e As KeyEventArgs) Handles reference.KeyDown
        If e.KeyData = Keys.Enter Then
            KryptonButton5.PerformClick()
        End If
    End Sub
End Class
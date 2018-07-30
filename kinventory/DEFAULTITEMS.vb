Imports System.Data.SqlClient
Public Class DEFAULTITEMS
    Dim sql As New sql
    Public sqlcmd As New SqlCommand
    Public da As New SqlDataAdapter
    Private Sub DEFAULTITEMS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, Screen.PrimaryScreen.Bounds.Height - Me.Height)
        loadstock()
    End Sub
    Public Sub loadstock()
        Try
            sql.sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            Dim str As String = "select * from stocks_tb where phasedout = '' order by articleno asc"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            stocksgridview.DataSource = bs

            stocksgridview.Columns("weight").Visible = False
            stocksgridview.Columns("disc").Visible = False
            stocksgridview.Columns("unit").Visible = False
            stocksgridview.Columns("tofoil").Visible = False
            stocksgridview.Columns("UFACTOR").Visible = False
            stocksgridview.Columns("free").Visible = False
            stocksgridview.Columns("MONETARY").Visible = False
            stocksgridview.Columns("UNITPRICE").Visible = False
            stocksgridview.Columns("QTY").Visible = False
            stocksgridview.Columns("Location").Visible = False
            'stocksgridview.Columns("balalloc").Visible = False
            stocksgridview.Columns("ALLOCATION").Visible = False
            stocksgridview.Columns("STOCKORDER").Visible = False
            stocksgridview.Columns("MINIMUM").Visible = False
            stocksgridview.Columns("ISSUE").Visible = False
            stocksgridview.Columns("AVEUSAGE").Visible = False
            stocksgridview.Columns("status").Visible = False
            stocksgridview.Columns("PHASEDOUT").Visible = False
            stocksgridview.Columns("COLORBASED").Visible = False
            stocksgridview.Columns("NEEDTOORDER").Visible = False
            stocksgridview.Columns("FINALNEEDTOORDER").Visible = False
            stocksgridview.Columns("INPUTTED").Visible = False
            stocksgridview.Columns("TOORDER").Visible = False
            TextBox1.DataBindings.Clear()
            TextBox1.DataBindings.Add("text", bs, "stockno")

        Catch ex As SqlException
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Private Sub KryptonButton1_Click(sender As Object, e As EventArgs) Handles KryptonButton1.Click
        Dim phasedout As String = "Yes"
        Dim a As String = supplier.Text
        Dim b As String = costheadsearch.Text
        Dim c As String = typecolorsearch.Text
        Dim d As String = articlenosearch.Text
        Dim f As String = status.Text
        Dim g As String = phasedout
        Dim acol As String = " Supplier"
        Dim bcol As String = " Costhead"
        Dim ccol As String = " typecolor"
        Dim dcol As String = " articleno"
        Dim fcol As String = " status"
        Dim gcol As String = " phasedout"

        If phasedoutsearch.Checked = True Then
            gcol = " phasedout"
        Else
            gcol = " Not phasedout"
        End If

        If a = "" Then
            a = " Supplier"
        Else
            a = "'" & a & "'"
            End If

        If b = "" Then
            b = " Costhead"
        Else
            b = "'" & b & "'"
        End If

        If c = "" Then
            c = " typecolor"
        Else
            c = "'" & c & "'"
        End If

        If d = "" Then
            d = " articleno"
        Else
            d = "'" & d & "%'"
        End If

        If f = "" Then
            f = " status"
        Else
            f = "'" & f & "'"
        End If

        If g = "" Then
            g = "''"
        Else
            g = "'" & g & "'"
        End If

        Dim condition As String
        condition = " where 
" & acol & " = " & a & " and 
" & bcol & " = " & b & " and
" & ccol & " = " & c & " and 
" & dcol & " like " & d & " and
" & fcol & " = " & f & " and
" & gcol & "= " & g & ""
        Dim search As String = "select * from stocks_tb " & condition & ""
        searchstocks(search)
    End Sub
    Public Sub searchstocks(ByVal search As String)
        Try
            sql.sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            sqlcmd = New SqlCommand(search, sql.sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            stocksgridview.DataSource = bs

            stocksgridview.Columns("supplier").Visible = False
            stocksgridview.Columns("COSTHEAD").Visible = False
            stocksgridview.Columns("UFACTOR").Visible = False
            stocksgridview.Columns("TYPECOLOR").Visible = False
            stocksgridview.Columns("MONETARY").Visible = False
            stocksgridview.Columns("UNITPRICE").Visible = False
            stocksgridview.Columns("QTY").Visible = False
            stocksgridview.Columns("Location").Visible = False
            stocksgridview.Columns("HEADER").Visible = False
            stocksgridview.Columns("ALLOCATION").Visible = False
            stocksgridview.Columns("STOCKORDER").Visible = False
            stocksgridview.Columns("MINIMUM").Visible = False
            stocksgridview.Columns("ISSUE").Visible = False
            stocksgridview.Columns("AVEUSAGE").Visible = False
            stocksgridview.Columns("status").Visible = False
            stocksgridview.Columns("PHASEDOUT").Visible = False
            stocksgridview.Columns("COLORBASED").Visible = False
            stocksgridview.Columns("NEEDTOORDER").Visible = False
            stocksgridview.Columns("FINALNEEDTOORDER").Visible = False
            stocksgridview.Columns("INPUTTED").Visible = False
            stocksgridview.Columns("TOORDER").Visible = False

            TextBox1.DataBindings.Clear()
            TextBox1.DataBindings.Add("text", bs, "stockno")
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Private Sub supplier_MouseDown(sender As Object, e As MouseEventArgs) Handles supplier.MouseDown
        Dim phasedout As String
        If phasedoutsearch.Checked = True Then
            phasedout = " phasedout = 'Yes'"
        Else
            phasedout = " not phasedout = 'Yes'"
        End If
        Dim x As Integer = supplier.SelectedIndex
        loadsuppliersearch(phasedout)
        costheadsearch.Text = ""
        typecolorsearch.Text = ""
        articlenosearch.Text = ""
        If x > supplier.Items.Count - 1 Then
            supplier.SelectedIndex = -1
        Else
            supplier.SelectedIndex = x
        End If
    End Sub
    Public Sub loadsuppliersearch(ByVal phasedout As String)
        Try
            sql.sqlcon.Open()
            Dim supplierds As New DataSet
            Dim supplierbindingsource As New BindingSource
            supplierds.Clear()
            Dim str As String = "select distinct supplier from stocks_tb where " & phasedout & ""
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(supplierds, "stocks_tb")
            supplierbindingsource.DataSource = supplierds
            supplierbindingsource.DataMember = "stocks_tb"
            supplier.DataSource = supplierbindingsource
            supplier.DisplayMember = "supplier"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Private Sub costheadsearch_MouseDown(sender As Object, e As MouseEventArgs) Handles costheadsearch.MouseDown
        Dim phasedout As String
        If phasedoutsearch.Checked = True Then
            phasedout = " and phasedout = 'Yes'"
        Else
            phasedout = " and not phasedout = 'Yes'"
        End If
        Dim x As Integer = costheadsearch.SelectedIndex
        Dim ssupplier As String = supplier.Text
        If ssupplier = "" Then
            ssupplier = " supplier"
        Else
            ssupplier = "'" & ssupplier & "'"
        End If
        loadcostheadsearch(ssupplier, phasedout)
        typecolorsearch.Text = ""
        articlenosearch.Text = ""
        If x > costheadsearch.Items.Count - 1 Then
            costheadsearch.SelectedIndex = -1
        Else
            costheadsearch.SelectedIndex = x
        End If
    End Sub
    Public Sub loadcostheadsearch(ByVal supplier As String, ByVal phasedout As String)
        Try
            sql.sqlcon.Open()
            Dim costheadds As New DataSet
            Dim costheadbindingsource As New BindingSource
            costheadds.Clear()
            Dim str As String = "select distinct costhead from stocks_tb where supplier  = " & supplier & " " & phasedout & ""
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(costheadds, "stocks_tb")
            costheadbindingsource.DataSource = costheadds
            costheadbindingsource.DataMember = "stocks_tb"
            costheadsearch.DataSource = costheadbindingsource
            costheadsearch.DisplayMember = "costhead"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Private Sub typecolorsearch_MouseDown(sender As Object, e As MouseEventArgs) Handles typecolorsearch.MouseDown
        Dim phasedout As String
        If phasedoutsearch.Checked = True Then
            phasedout = " and phasedout = 'Yes'"
        Else
            phasedout = " and not phasedout = 'Yes'"
        End If
        Dim x As Integer = typecolorsearch.SelectedIndex
        Dim ssupplier As String = supplier.Text
        Dim scosthead As String = costheadsearch.Text
        If ssupplier = "" Then
            ssupplier = " supplier"
        Else
            ssupplier = "'" & ssupplier & "'"
        End If
        If scosthead = "" Then
            scosthead = " costhead"
        Else
            scosthead = "'" & scosthead & "'"
        End If
        loadtypecolorsearch(ssupplier, scosthead, phasedout)
        articlenosearch.Text = ""
        If x > typecolorsearch.Items.Count - 1 Then
            typecolorsearch.SelectedIndex = -1
        Else
            typecolorsearch.SelectedIndex = x
        End If
    End Sub
    Public Sub loadtypecolorsearch(ByVal supplier As String, ByVal costhead As String, ByVal phasedout As String)
        Try
            sql.sqlcon.Open()
            Dim typecolords As New DataSet
            Dim typecolorbs As New BindingSource
            typecolords.Clear()
            Dim str1 As String = "select distinct typecolor from stocks_tb where supplier = " & supplier & " and costhead=" & costhead & " " & phasedout & ""
            sqlcmd = New SqlCommand(str1, sql.sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(typecolords, "stocks_tb")
            typecolorbs.DataSource = typecolords
            typecolorbs.DataMember = "stocks_tb"
            typecolorsearch.DataSource = typecolorbs
            typecolorsearch.DisplayMember = "typecolor"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Private Sub articlenosearch_MouseDown(sender As Object, e As MouseEventArgs) Handles articlenosearch.MouseDown
        Dim phasedout As String
        If phasedoutsearch.Checked = True Then
            phasedout = " and phasedout = 'Yes'"
        Else
            phasedout = " and not phasedout = 'Yes'"
        End If
        Dim x As Integer = articlenosearch.SelectedIndex
        Dim ssupplier As String = supplier.Text
        Dim scosthead As String = costheadsearch.Text
        Dim stypecolor As String = typecolorsearch.Text

        If ssupplier = "" Then
            ssupplier = " supplier"
        Else
            ssupplier = "'" & ssupplier & "'"
        End If
        If scosthead = "" Then
            scosthead = " costhead"
        Else
            scosthead = "'" & scosthead & "'"
        End If
        If stypecolor = "" Then
            stypecolor = " typecolor"
        Else
            stypecolor = "'" & stypecolor & "'"
        End If
        loadarticlesearch(ssupplier, scosthead, stypecolor, phasedout)

        If x > articlenosearch.Items.Count - 1 Then
            articlenosearch.SelectedIndex = -1
        Else
            articlenosearch.SelectedIndex = x
        End If

    End Sub
    Public Sub loadarticlesearch(ByVal supplier As String, ByVal costhead As String, ByVal typec As String, ByVal phasedout As String)
        Try
            sql.sqlcon.Open()
            Dim articleds As New DataSet
            Dim articlebs As New BindingSource
            articleds.Clear()
            Dim str2 As String = "select distinct articleno from stocks_tb where supplier=" & supplier & " and costhead=" & costhead & " and typecolor=" & typec & "  " & phasedout & ""
            sqlcmd = New SqlCommand(str2, sql.sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(articleds, "stocks_tb")
            articlebs.DataSource = articleds
            articlebs.DataMember = "stocks_tb"
            articlenosearch.DataSource = articlebs
            articlenosearch.DisplayMember = "articleno"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Private Sub KryptonButton15_Click(sender As Object, e As EventArgs) Handles KryptonButton15.Click
        loadstock()
    End Sub

    Private Sub stocksgridview_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles stocksgridview.CellClick
        If stocksgridview.RowCount >= 0 And e.RowIndex >= 0 Then
            Form2.transdescription.Text = stocksgridview.Item(8, e.RowIndex).Value.ToString
            Form2.transphysical.Text = stocksgridview.Item(13, e.RowIndex).Value.ToString
            Form2.transfree.Text = stocksgridview.Item(15, e.RowIndex).Value.ToString
            Form2.transunit.Text = stocksgridview.Item(10, e.RowIndex).Value.ToString
            Form2.transstockno.Text = stocksgridview.Item(0, e.RowIndex).Value.ToString

            sql.movetoinput(Form2.transstockno.Text)
        End If
    End Sub

    Private Sub supplier_KeyDown(sender As Object, e As KeyEventArgs) Handles typecolorsearch.KeyDown, supplier.KeyDown, status.KeyDown, costheadsearch.KeyDown, articlenosearch.KeyDown
        If e.KeyData = Keys.Enter Then
            KryptonButton1.PerformClick()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        sql.movetoinput(TextBox1.Text)
    End Sub
End Class
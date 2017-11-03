Imports System.Data.SqlClient
Public Class PhasedoutForm
    Dim drag As Boolean
    Dim xm As Integer
    Dim ym As Integer
    Dim sql As New sql
    Public sqlcmd As New SqlCommand
    Private Sub KryptonButton2_Click(sender As Object, e As EventArgs) Handles KryptonButton2.Click
        Me.Close()
    End Sub

    Private Sub KryptonButton1_Click(sender As Object, e As EventArgs) Handles KryptonButton1.Click
        If KryptonCheckBox1.Checked = True Then
            For i As Integer = 0 To Form2.stocksStocksno.Items.Count - 1
                Dim y As String = Form2.stocksStocksno.Items(i).ToString
                markphasedout(y)
            Next
        Else
        End If
        If KryptonCheckBox2.Checked = True Then
            For i As Integer = 0 To Form2.stocksStocksno.Items.Count - 1
                Dim stockno As String = Form2.stocksStocksno.Items(i).ToString
                sql.colorbased(colorbased.Text, stockno)
            Next
        Else
        End If
        If KryptonCheckBox3.Checked = True Then
            For i As Integer = 0 To Form2.stocksStocksno.Items.Count - 1
                Dim stockno As String = Form2.stocksStocksno.Items(i).ToString
                sql.toorders(toorder.Text, stockno)
            Next
        Else
        End If
        If KryptonCheckBox4.Checked = True Then
            For i As Integer = 0 To Form2.stocksStocksno.Items.Count - 1
                Dim stockno As String = Form2.stocksStocksno.Items(i).ToString
                sql.tofoils(tofoil.Text, stockno)
            Next
        Else
        End If

        If KryptonCheckBox7.Checked = True Then
            For i As Integer = 0 To Form2.stocksStocksno.Items.Count - 1
                Dim stockno As String = Form2.stocksStocksno.Items(i).ToString
                upsupplier(supplier.Text, stockno)
            Next
        Else
        End If
        If KryptonCheckBox8.Checked = True Then
            For i As Integer = 0 To Form2.stocksStocksno.Items.Count - 1
                Dim stockno As String = Form2.stocksStocksno.Items(i).ToString
                upcosthead(costhead.Text, stockno)
            Next
        Else
        End If
        If KryptonCheckBox6.Checked = True Then
            For i As Integer = 0 To Form2.stocksStocksno.Items.Count - 1
                Dim stockno As String = Form2.stocksStocksno.Items(i).ToString
                uptypecolor(typecolor.Text, stockno)
            Next
        Else
        End If
        If KryptonCheckBox5.Checked = True Then
            For i As Integer = 0 To Form2.stocksStocksno.Items.Count - 1
                Dim stockno As String = Form2.stocksStocksno.Items(i).ToString
                uparticleno(articleno.Text, stockno)
            Next
        Else
        End If
        If KryptonCheckBox9.Checked = True Then
            For i As Integer = 0 To Form2.stocksStocksno.Items.Count - 1
                Dim stockno As String = Form2.stocksStocksno.Items(i).ToString
                upweight(weight.Text, stockno)
            Next
        Else
        End If
        If KryptonCheckBox10.Checked = True Then
            For i As Integer = 0 To Form2.stocksStocksno.Items.Count - 1
                Dim stockno As String = Form2.stocksStocksno.Items(i).ToString
                upxrate(xrate.Text, stockno)
            Next
        Else
        End If
        Form2.KryptonButton1.PerformClick()
        Button1.PerformClick()
    End Sub
    Public Sub upxrate(ByVal myval As String, ByVal stockno As String)
        Try
            sql.sqlcon.Open()
            Dim str As String = "update stocks_tb set xrate='" & myval & "' where stockno='" & stockno & "'"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub
    Public Sub upweight(ByVal myval As String, ByVal stockno As String)
        Try
            sql.sqlcon.Open()
            Dim str As String = "update stocks_tb set weight='" & myval & "' where stockno='" & stockno & "'"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub
    Public Sub uparticleno(ByVal myval As String, ByVal stockno As String)
        Try
            sql.sqlcon.Open()
            Dim str As String = "update stocks_tb set articleno='" & myval & "' where stockno='" & stockno & "'"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub
    Public Sub uptypecolor(ByVal myval As String, ByVal stockno As String)
        Try
            sql.sqlcon.Open()
            Dim str As String = "update stocks_tb set typecolor='" & myval & "' where stockno='" & stockno & "'"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub
    Public Sub upcosthead(ByVal myval As String, ByVal stockno As String)
        Try
            sql.sqlcon.Open()
            Dim str As String = "update stocks_tb set costhead='" & myval & "' where stockno='" & stockno & "'"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub
    Public Sub upsupplier(ByVal myval As String, ByVal stockno As String)
        Try
            sql.sqlcon.Open()
            Dim str As String = "update stocks_tb set supplier='" & myval & "' where stockno='" & stockno & "'"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub
    Public Sub markphasedout(ByVal x As String)
        Try
            Dim sqlcmd As New SqlCommand
            sql.sqlcon.Open()
            Dim str As String = "update stocks_tb set phasedout = '" & phasedout.Text & "' where stockno = '" & x & "'"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Private Sub PhasedoutForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Form1.Label2.Text = "Guest" Or Form1.Label2.Text = "Encoder" Then
            KryptonButton1.Enabled = False
        Else
            KryptonButton1.Enabled = True
        End If
        colorbased.SelectedIndex = -1

        loadsupplier()
        loadcosthead()
        loadtypecolor()
        loadarticleno()
        loadweight()
    End Sub
    Public Sub loadweight()
        Try
            sql.sqlcon.Open()
            Dim ds As New DataSet
            ds.Clear()
            Dim da As New SqlDataAdapter
            Dim str As String = "select distinct weight from stocks_tb "
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            Dim bs As New BindingSource
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            weight.DataSource = bs
            weight.DisplayMember = "weight"
            weight.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub
    Public Sub loadsupplier()
        Try
            sql.sqlcon.Open()
            Dim ds As New DataSet
            ds.Clear()
            Dim da As New SqlDataAdapter
            Dim str As String = "select distinct supplier from stocks_tb "
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            Dim bs As New BindingSource
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            supplier.DataSource = bs
            supplier.DisplayMember = "supplier"
            supplier.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub
    Public Sub loadcosthead()
        Try
            sql.sqlcon.Open()
            Dim ds As New DataSet
            ds.Clear()
            Dim da As New SqlDataAdapter
            Dim str As String = "select distinct costhead from stocks_tb "
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            Dim bs As New BindingSource
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            costhead.DataSource = bs
            costhead.DisplayMember = "costhead"
            costhead.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub
    Public Sub loadtypecolor()
        Try
            sql.sqlcon.Open()
            Dim ds As New DataSet
            ds.Clear()
            Dim da As New SqlDataAdapter
            Dim str As String = "select distinct typecolor from stocks_tb "
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            Dim bs As New BindingSource
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            typecolor.DataSource = bs
            typecolor.DisplayMember = "typecolor"
            typecolor.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub
    Public Sub loadarticleno()
        Try
            sql.sqlcon.Open()
            Dim ds As New DataSet
            ds.Clear()
            Dim da As New SqlDataAdapter
            Dim str As String = "select distinct articleno from stocks_tb "
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            Dim bs As New BindingSource
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            articleno.DataSource = bs
            articleno.DisplayMember = "articleno"
            articleno.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        KryptonCheckBox10.Checked = False
        KryptonCheckBox9.Checked = False
        KryptonCheckBox7.Checked = False
        KryptonCheckBox8.Checked = False
        KryptonCheckBox6.Checked = False
        KryptonCheckBox5.Checked = False
    End Sub

    Private Sub KryptonPanel1_MouseDown(sender As Object, e As MouseEventArgs) Handles KryptonPanel1.MouseDown
        drag = True
        xm = Cursor.Position.X - Me.Left
        ym = Cursor.Position.Y - Me.Top
    End Sub

    Private Sub KryptonPanel1_MouseMove(sender As Object, e As MouseEventArgs) Handles KryptonPanel1.MouseMove
        If drag Then
            Me.Left = Cursor.Position.X - xm
            Me.Top = Cursor.Position.Y - ym
        End If
    End Sub

    Private Sub KryptonPanel1_MouseUp(sender As Object, e As MouseEventArgs) Handles KryptonPanel1.MouseUp
        drag = False
    End Sub

    Private Sub xrate_Leave(sender As Object, e As EventArgs) Handles xrate.Leave
        If IsNumeric(xrate.Text) Then
        Else
            MessageBox.Show("invalid x-rate", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            xrate.Focus()
        End If
    End Sub

    Private Sub xrate_MouseDown(sender As Object, e As MouseEventArgs) Handles xrate.MouseDown
        Dim i As Integer = xrate.SelectedIndex
        loadxrate()
        If i > xrate.Items.Count - 1 Then
            xrate.SelectedIndex = -1
        Else
            xrate.SelectedIndex = i
        End If
    End Sub
    Public Sub loadxrate()
        Try
            sql.sqlcon.Open()
            Dim ds As New DataSet
            ds.Clear()
            Dim da As New SqlDataAdapter
            Dim bs As New BindingSource
            Dim str As String = "select distinct xrate from stocks_tb"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            xrate.DataSource = bs
            xrate.DisplayMember = "xrate"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub
End Class
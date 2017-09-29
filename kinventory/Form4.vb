﻿Imports System.Data.SqlClient
Public Class Form4
    Dim SQL As New sql
    Dim xm As Integer
    Dim ym As Integer
    Dim drag As Boolean
    Private Sub KryptonButton2_Click(sender As Object, e As EventArgs) Handles editbtn.Click
        supplier.Enabled = True
        costhead.Enabled = True
        header.Enabled = True
        colorbased.Enabled = True
        articleno.Enabled = True
        typecolor.Enabled = True
        description.Enabled = True
        min.Enabled = True
        monetary.Enabled = True
        unitprice.Enabled = True
        aveusage.Enabled = True
        location.Enabled = True
        unit.Enabled = True
        editbtn.Visible = False
        savebtn.Visible = True

    End Sub

    Private Sub KryptonButton1_Click(sender As Object, e As EventArgs) Handles KryptonButton1.Click
        Me.Close()
    End Sub

    Private Sub Form4_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        supplier.Enabled = False
        costhead.Enabled = False
        header.Enabled = False
        colorbased.Enabled = False
        articleno.Enabled = False
        typecolor.Enabled = False
        description.Enabled = False
        min.Enabled = False
        monetary.Enabled = False
        unitprice.Enabled = False
        aveusage.Enabled = False
        location.Enabled = False
        unit.Enabled = False
        editbtn.Visible = True
        savebtn.Visible = False
    End Sub

    Private Sub savebtn_Click(sender As Object, e As EventArgs) Handles savebtn.Click
        If MessageBox.Show("save changes?", "confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            MessageBox.Show("operation cancelled", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        remove()
        SQL.updatestocks2(stockno.Text, supplier.Text,
        costhead.Text,
        header.Text,
        colorbased.Text,
        articleno.Text,
        typecolor.Text,
        description.Text,
        min.Text,
        monetary.Text,
        unitprice.Text,
        aveusage.Text,
        location.Text,
        unit.Text)
        Form2.KryptonButton1.PerformClick()
    End Sub
    Public Sub remove()
        supplier.Text = supplier.Text.Replace("'", "")
        supplier.Text = supplier.Text.Replace("""", "")
        costhead.Text = costhead.Text.Replace("'", "")
        costhead.Text = costhead.Text.Replace("""", "")
        header.Text = header.Text.Replace("'", "")
        header.Text = header.Text.Replace("""", "")
        articleno.Text = articleno.Text.Replace("'", "")
        articleno.Text = articleno.Text.Replace("""", "")
        typecolor.Text = typecolor.Text.Replace("'", "")
        typecolor.Text = typecolor.Text.Replace("""", "")
        description.Text = description.Text.Replace("'", "")
        description.Text = description.Text.Replace("""", "")
        min.Text = min.Text.Replace("'", "")
        min.Text = min.Text.Replace("""", "")
        monetary.Text = monetary.Text.Replace("'", "")
        monetary.Text = monetary.Text.Replace("""", "")
        unitprice.Text = unitprice.Text.Replace("'", "")
        unitprice.Text = unitprice.Text.Replace("""", "")
        aveusage.Text = aveusage.Text.Replace("'", "")
        aveusage.Text = aveusage.Text.Replace("""", "")
        location.Text = location.Text.Replace("'", "")
        location.Text = location.Text.Replace("""", "")
        unit.Text = unit.Text.Replace("'", "")
        unit.Text = unit.Text.Replace("""", "")
        supplier.Text = Trim(supplier.Text)
        costhead.Text = Trim(costhead.Text)
        header.Text = Trim(header.Text)
        articleno.Text = Trim(articleno.Text)
        typecolor.Text = Trim(typecolor.Text)
        description.Text = Trim(description.Text)
        min.Text = Trim(min.Text)
        monetary.Text = Trim(monetary.Text)
        unitprice.Text = Trim(unitprice.Text)
        aveusage.Text = Trim(aveusage.Text)
        location.Text = Trim(location.Text)
        unit.Text = Trim(unit.Text)

    End Sub

    Private Sub KryptonButton4_Click(sender As Object, e As EventArgs) Handles KryptonButton4.Click
        reference.Text = reference.Text.Replace("'", "")
        reference.Text = reference.Text.Replace("""", "")
        transaction.Text = transaction.Text.Replace("'", "")
        transaction.Text = transaction.Text.Replace("""", "")
        Dim search As String
        Dim condition As String
        If all.Checked = True And Not reference.Text = "" And Not transaction.Text = "" Then
            search = " where stockno='" & stockno.Text & "' and reference='" & reference.Text & "' and transtype='" & transaction.Text & "'"
            condition = "where stockno='" & stockno.Text & "' and reference='" & reference.Text & "'"
            SQL.searchstockstransaction(search, condition, stockno.Text, transaction.Text, reference.Text)
        ElseIf all.Checked = True And Not reference.Text = "" And transaction.Text = "" Then
            search = " where stockno='" & stockno.Text & "' and reference='" & reference.Text & "'"
            condition = "where stockno='" & stockno.Text & "' and reference='" & reference.Text & "'"
            SQL.searchstockstransaction(search, condition, stockno.Text, transaction.Text, reference.Text)
        ElseIf all.Checked = True And reference.Text = "" And Not transaction.Text = "" Then
            search = " where stockno='" & stockno.Text & "' and transtype='" & transaction.Text & "'"
            condition = "where stockno='" & stockno.Text & "'"
            SQL.searchstockstransaction(search, condition, stockno.Text, transaction.Text, reference.Text)
        ElseIf all.Checked = True And reference.Text = "" And transaction.Text = "" Then
            search = " where stockno='" & stockno.Text & "'"
            condition = " where stockno='" & stockno.Text & "'"
            SQL.searchstockstransaction(search, condition, stockno.Text, transaction.Text, reference.Text)
        End If

        If thisdate.Checked = True And Not reference.Text = "" And Not transaction.Text = "" Then
            search = " where stockno='" & stockno.Text & "' and reference='" & reference.Text & "' and transtype='" & transaction.Text & "' and TRANSDATE ='" & transadate.Text & "'"
            condition = "where stockno='" & stockno.Text & "' and reference='" & reference.Text & "' and TRANSDATE ='" & transadate.Text & "'"
            SQL.searchstockstransaction(search, condition, stockno.Text, transaction.Text, reference.Text)
        ElseIf thisdate.Checked = True And Not reference.Text = "" And transaction.Text = "" Then
            search = " where stockno='" & stockno.Text & "' and reference='" & reference.Text & "' and TRANSDATE ='" & transadate.Text & "'"
            condition = "where stockno='" & stockno.Text & "' and reference='" & reference.Text & "' and TRANSDATE ='" & transadate.Text & "'"
            SQL.searchstockstransaction(search, condition, stockno.Text, transaction.Text, reference.Text)
        ElseIf thisdate.Checked = True And reference.Text = "" And Not transaction.Text = "" Then
            search = " where stockno='" & stockno.Text & "' and transtype='" & transaction.Text & "' and TRANSDATE ='" & transadate.Text & "'"
            condition = "where stockno='" & stockno.Text & "' and TRANSDATE ='" & transadate.Text & "'"
            SQL.searchstockstransaction(search, condition, stockno.Text, transaction.Text, reference.Text)
        ElseIf thisdate.Checked = True And reference.Text = "" And transaction.Text = "" Then
            search = " where stockno='" & stockno.Text & "' and TRANSDATE ='" & transadate.Text & "'"
            condition = " where stockno='" & stockno.Text & "' and TRANSDATE ='" & transadate.Text & "'"
            SQL.searchstockstransaction(search, condition, stockno.Text, transaction.Text, reference.Text)
        End If

        If before.Checked = True And Not reference.Text = "" And Not transaction.Text = "" Then
            search = " where stockno='" & stockno.Text & "' and reference='" & reference.Text & "' and transtype='" & transaction.Text & "' and TRANSDATE < '" & transadate.Text & "'"
            condition = " where stockno='" & stockno.Text & "' and reference='" & reference.Text & "' and TRANSDATE < '" & transadate.Text & "'"
            SQL.searchstockstransaction(search, condition, stockno.Text, transaction.Text, reference.Text)
        ElseIf before.Checked = True And Not reference.Text = "" And transaction.Text = "" Then
            search = " where stockno='" & stockno.Text & "' and reference='" & reference.Text & "' and TRANSDATE < '" & transadate.Text & "'"
            condition = " where stockno='" & stockno.Text & "' and reference='" & reference.Text & "' and TRANSDATE < '" & transadate.Text & "'"
            SQL.searchstockstransaction(search, condition, stockno.Text, transaction.Text, reference.Text)
        ElseIf before.Checked = True And reference.Text = "" And Not transaction.Text = "" Then
            search = " where stockno='" & stockno.Text & "' and transtype='" & transaction.Text & "' and TRANSDATE < '" & transadate.Text & "'"
            condition = "where stockno='" & stockno.Text & "' and TRANSDATE < '" & transadate.Text & "'"
            SQL.searchstockstransaction(search, condition, stockno.Text, transaction.Text, reference.Text)
        ElseIf before.Checked = True And reference.Text = "" And transaction.Text = "" Then
            search = " where stockno='" & stockno.Text & "' and TRANSDATE < '" & transadate.Text & "'"
            condition = "where stockno='" & stockno.Text & "' and TRANSDATE < '" & transadate.Text & "'"
            SQL.searchstockstransaction(search, condition, stockno.Text, transaction.Text, reference.Text)
        End If

        If after.Checked = True And Not reference.Text = "" And Not transaction.Text = "" Then
            search = " where stockno='" & stockno.Text & "' and reference='" & reference.Text & "' and transtype='" & transaction.Text & "' and TRANSDATE > '" & transadate.Text & "'"
            condition = " where stockno='" & stockno.Text & "' and reference='" & reference.Text & "' and TRANSDATE > '" & transadate.Text & "'"
            SQL.searchstockstransaction(search, condition, stockno.Text, transaction.Text, reference.Text)
        ElseIf after.Checked = True And Not reference.Text = "" And transaction.Text = "" Then
            search = " where stockno='" & stockno.Text & "' and reference='" & reference.Text & "' and TRANSDATE > '" & transadate.Text & "'"
            condition = "where stockno='" & stockno.Text & "' and reference='" & reference.Text & "' and TRANSDATE > '" & transadate.Text & "'"
            SQL.searchstockstransaction(search, condition, stockno.Text, transaction.Text, reference.Text)
        ElseIf after.Checked = True And reference.Text = "" And Not transaction.Text = "" Then
            search = " where stockno='" & stockno.Text & "' and transtype='" & transaction.Text & "' and TRANSDATE > '" & transadate.Text & "'"
            condition = " where stockno='" & stockno.Text & "' and TRANSDATE > '" & transadate.Text & "'"
            SQL.searchstockstransaction(search, condition, stockno.Text, transaction.Text, reference.Text)
        ElseIf after.Checked = True And reference.Text = "" And transaction.Text = "" Then
            search = " where stockno='" & stockno.Text & "' and TRANSDATE > '" & transadate.Text & "'"
            condition = " where stockno='" & stockno.Text & "' and TRANSDATE > '" & transadate.Text & "'"
            SQL.searchstockstransaction(search, condition, stockno.Text, transaction.Text, reference.Text)
        End If

        If tomydate.Checked = True And Not reference.Text = "" And Not transaction.Text = "" Then
            search = " where stockno='" & stockno.Text & "' and reference='" & reference.Text & "' and transtype='" & transaction.Text & "' and TRANSDATE between '" & transadate.Text & "' and '" & todate.Text & "'"
            condition = "where stockno='" & stockno.Text & "' and reference='" & reference.Text & "' and TRANSDATE between '" & transadate.Text & "' and '" & todate.Text & "'"
            SQL.searchstockstransaction(search, condition, stockno.Text, transaction.Text, reference.Text)
        ElseIf tomydate.Checked = True And Not reference.Text = "" And transaction.Text = "" Then
            search = " where stockno='" & stockno.Text & "' and reference='" & reference.Text & "' and TRANSDATE between '" & transadate.Text & "' and '" & todate.Text & "'"
            condition = " where stockno='" & stockno.Text & "' and reference='" & reference.Text & "' and TRANSDATE between '" & transadate.Text & "' and '" & todate.Text & "'"
            SQL.searchstockstransaction(search, condition, stockno.Text, transaction.Text, reference.Text)
        ElseIf tomydate.Checked = True And reference.Text = "" And Not transaction.Text = "" Then
            search = " where stockno='" & stockno.Text & "' and transtype='" & transaction.Text & "' and TRANSDATE between '" & transadate.Text & "' and '" & todate.Text & "'"
            condition = "where stockno='" & stockno.Text & "' and TRANSDATE between '" & transadate.Text & "' and '" & todate.Text & "'"
            SQL.searchstockstransaction(search, condition, stockno.Text, transaction.Text, reference.Text)
        ElseIf tomydate.Checked = True And reference.Text = "" And transaction.Text = "" Then
            search = " where stockno='" & stockno.Text & "' and TRANSDATE between '" & transadate.Text & "' and '" & todate.Text & "'"
            condition = "where stockno='" & stockno.Text & "' and TRANSDATE between '" & transadate.Text & "' and '" & todate.Text & "'"
            SQL.searchstockstransaction(search, condition, stockno.Text, transaction.Text, reference.Text)
        End If
        referencegridview.SelectAll()
    End Sub

    Private Sub KryptonButton2_Click_1(sender As Object, e As EventArgs) Handles KryptonButton2.Click
        SQL.srockstransactiontb(stockno.Text)
    End Sub


    Private Sub min_Leave(sender As Object, e As EventArgs) Handles min.Leave
        If IsNumeric(min.Text) Then
        Else
            MessageBox.Show("Minimum quantity must be valid number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            min.Focus()
        End If
    End Sub

    Private Sub unitprice_Leave(sender As Object, e As EventArgs) Handles unitprice.Leave
        If IsNumeric(unitprice.Text) Then
        Else
            MessageBox.Show("Unit price must be valid number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            unitprice.Focus()
        End If
    End Sub

    Private Sub aveusage_Leave(sender As Object, e As EventArgs) Handles aveusage.Leave
        If IsNumeric(aveusage.Text) Then
        Else
            MessageBox.Show("Average usage must be valid number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            aveusage.Focus()
        End If
    End Sub
    Private Sub mytransgridview_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles mytransgridview.CellClick
        If mytransgridview.RowCount >= 0 And e.RowIndex >= 0 Then
            Form5.transno.Text = mytransgridview.Item(0, e.RowIndex).Value.ToString
            Form5.stockno.Text = mytransgridview.Item(1, e.RowIndex).Value.ToString
            Form5.reference.Text = mytransgridview.Item(7, e.RowIndex).Value.ToString
            Form5.XYZ.Text = mytransgridview.Item(10, e.RowIndex).Value.ToString
        End If
    End Sub
    Private Sub reference_KeyDown(sender As Object, e As KeyEventArgs) Handles reference.KeyDown
        If e.KeyData = Keys.Enter Then
            KryptonButton4.PerformClick()
        End If
    End Sub

    Private Sub transaction_KeyDown(sender As Object, e As KeyEventArgs) Handles transaction.KeyDown
        If e.KeyData = Keys.Enter Then
            KryptonButton4.PerformClick()
        End If
    End Sub

    Private Sub mytransgridview_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles mytransgridview.CellDoubleClick
        If mytransgridview.RowCount >= 0 And e.RowIndex >= 0 Then
            Form5.itcame.Text = "A"
            SQL.selecttransrec(Form5.transno.Text)
            SQL.selectreference(Form5.stockno.Text, Form5.reference.Text)
            Form5.ShowDialog()
        End If
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Form1.Label2.Text = "Guest" Or Form1.Label2.Text = "Encoder" Then
            savebtn.Enabled = False
        Else
            savebtn.Enabled = True
        End If
    End Sub

    Private Sub mytransgridview_MouseDown(sender As Object, e As MouseEventArgs) Handles mytransgridview.MouseDown
        If e.Button = MouseButtons.Right Then
            transactionMenuStrip1.Show(mytransgridview, e.X, e.Y)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If Me.Width > 951 Then
            Me.WindowState = FormWindowState.Normal
            Button2.Text = "+"
        Else
            Me.WindowState = FormWindowState.Maximized
            Button2.Text = "-"
        End If
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

    Private Sub Panel2_SizeChanged(sender As Object, e As EventArgs) Handles Panel2.SizeChanged
        KryptonGroup2.Location = New Point((Panel2.Width - KryptonGroup2.Width) / 2, (Panel2.Height - KryptonGroup2.Height) / 2)
    End Sub
    Private Sub referencegridview_SelectionChanged(sender As Object, e As EventArgs) Handles referencegridview.SelectionChanged
        Dim selecteditems As DataGridViewSelectedRowCollection = referencegridview.SelectedRows
        Dim x As String
        ComboBox1.Items.Clear()

        For Each selecteditem As DataGridViewRow In selecteditems
            x = selecteditem.Cells("reference").Value.ToString
            ComboBox1.Items.Add(x)
        Next
    End Sub
End Class
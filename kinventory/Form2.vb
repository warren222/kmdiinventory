﻿Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Public Class Form2
    Dim sql As New sql
    Dim sqlcmd As New SqlCommand
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = Form1.Label2.Text
        toprows.SelectedIndex = 0
        sql.loadstocks()
        sql.loadtransactions(toprows.Text)
        sql.referencetb()
        Timer1.Start()
        myyear.Text = Today.Date.Year
        refsource.SelectedIndex = 1
        If Form1.Label2.Text = "Guest" Then
            'stocks
            KryptonButton2.Enabled = False
            KryptonButton3.Enabled = False
            KryptonButton23.Enabled = False
            'input
            KryptonButton4.Enabled = False
            'receipt
            KryptonButton5.Enabled = False
            'issue
            KryptonButton8.Enabled = False
            'reference
            KryptonButton14.Enabled = False
        ElseIf Form1.Label2.Text = "Admin" Then
            KryptonButton2.Enabled = True
            KryptonButton3.Enabled = True
            KryptonButton23.Enabled = True
            'input
            KryptonButton4.Enabled = True
            'receipt
            KryptonButton5.Enabled = True
            'issue
            KryptonButton8.Enabled = True
            'reference
            KryptonButton14.Enabled = True
        ElseIf Form1.Label2.Text = "Encoder" Then
            KryptonButton2.Enabled = False
            KryptonButton3.Enabled = False
            KryptonButton23.Enabled = False
            'input
            KryptonButton4.Enabled = True
            'receipt
            KryptonButton5.Enabled = True
            'issue
            KryptonButton8.Enabled = True
            'reference
            KryptonButton14.Enabled = True
        End If
    End Sub

    Private Sub stocksgridview_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles stocksgridview.RowPostPaint
        Dim grid As DataGridView = DirectCast(sender, DataGridView)
        e.PaintHeader(DataGridViewPaintParts.Background)
        Dim rowIdx As String = (e.RowIndex + 1).ToString()
        Dim rowFont As New System.Drawing.Font("Microsoft Sans Serif", 8.0!,
            System.Drawing.FontStyle.Regular,
            System.Drawing.GraphicsUnit.Point, CType(0, Byte))

        Dim centerFormat = New StringFormat()
        centerFormat.Alignment = StringAlignment.Far
        centerFormat.LineAlignment = StringAlignment.Near

        Dim headerBounds As Rectangle = New Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height)

        e.Graphics.DrawString(rowIdx, rowFont, SystemBrushes.ControlText, headerBounds, centerFormat)
    End Sub

    Private Sub KryptonButton2_Click(sender As Object, e As EventArgs) Handles KryptonButton2.Click
        stocksgridview.ClearSelection()
        Form3.Text = "New"
        Form3.ShowDialog()
    End Sub

    Private Sub KryptonButton3_Click(sender As Object, e As EventArgs) Handles KryptonButton3.Click
        Form3.Text = "Edit"
        Form3.ShowDialog()
    End Sub

    Private Sub stocksgridview_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles stocksgridview.CellClick
        If stocksgridview.RowCount >= 0 And e.RowIndex >= 0 Then
            Form3.colorbased.SelectedIndex = -1
            Form4.colorbased.SelectedIndex = -1
            stocknoinput.Text = stocksgridview.Item(0, e.RowIndex).Value.ToString
            Form3.stockno.Text = stocksgridview.Item(0, e.RowIndex).Value.ToString
            Form3.supplier.Text = stocksgridview.Item(1, e.RowIndex).Value.ToString
            Form3.costhead.Text = stocksgridview.Item(2, e.RowIndex).Value.ToString
            Form3.ufactor.Text = stocksgridview.Item(3, e.RowIndex).Value.ToString
            Form3.typecolor.Text = stocksgridview.Item(4, e.RowIndex).Value.ToString
            Form3.monetary.Text = stocksgridview.Item(5, e.RowIndex).Value.ToString
            Form3.articleno.Text = stocksgridview.Item(6, e.RowIndex).Value.ToString
            Form3.unitprice.Text = stocksgridview.Item(7, e.RowIndex).Value.ToString
            Form3.description.Text = stocksgridview.Item(8, e.RowIndex).Value.ToString
            Form3.qty.Text = stocksgridview.Item(9, e.RowIndex).Value.ToString
            Form3.unit.Text = stocksgridview.Item(10, e.RowIndex).Value.ToString
            Form3.location.Text = stocksgridview.Item(11, e.RowIndex).Value.ToString
            Form3.header.Text = stocksgridview.Item(12, e.RowIndex).Value.ToString
            Form3.min.Text = stocksgridview.Item(17, e.RowIndex).Value.ToString
            Form3.colorbased.Text = stocksgridview.Item(22, e.RowIndex).Value.ToString

            Form4.stockno.Text = stocksgridview.Item(0, e.RowIndex).Value.ToString
            Form4.supplier.Text = stocksgridview.Item(1, e.RowIndex).Value.ToString
            Form4.costhead.Text = stocksgridview.Item(2, e.RowIndex).Value.ToString
            Form4.typecolor.Text = stocksgridview.Item(4, e.RowIndex).Value.ToString
            Form4.monetary.Text = stocksgridview.Item(5, e.RowIndex).Value.ToString
            Form4.articleno.Text = stocksgridview.Item(6, e.RowIndex).Value.ToString
            Form4.unitprice.Text = stocksgridview.Item(7, e.RowIndex).Value.ToString
            Form4.description.Text = stocksgridview.Item(8, e.RowIndex).Value.ToString
            Form4.unit.Text = stocksgridview.Item(10, e.RowIndex).Value.ToString
            Form4.location.Text = stocksgridview.Item(11, e.RowIndex).Value.ToString
            Form4.header.Text = stocksgridview.Item(12, e.RowIndex).Value.ToString
            Form4.qty.Text = stocksgridview.Item(13, e.RowIndex).Value.ToString
            Form4.allocation.Text = stocksgridview.Item(14, e.RowIndex).Value.ToString
            Form4.free.Text = stocksgridview.Item(15, e.RowIndex).Value.ToString
            Form4.order.Text = stocksgridview.Item(16, e.RowIndex).Value.ToString
            Form4.min.Text = stocksgridview.Item(17, e.RowIndex).Value.ToString
            Form4.colorbased.Text = stocksgridview.Item(22, e.RowIndex).Value.ToString

            description.Text = stocksgridview.Item(8, e.RowIndex).Value.ToString
            location.Text = stocksgridview.Item(11, e.RowIndex).Value.ToString
        End If
    End Sub

    Private Sub stocksgridview_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles stocksgridview.CellDoubleClick
        sql.srockstransactiontb(Form4.stockno.Text)
        Form4.ShowDialog()
    End Sub

    Private Sub DateTimePicker8_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker8.ValueChanged
        duedate.Text = DateTimePicker8.Text
    End Sub

    Private Sub DateTimePicker8_MouseDown(sender As Object, e As MouseEventArgs) Handles DateTimePicker8.MouseDown
        duedate.Text = DateTimePicker8.Text
    End Sub

    Private Sub CheckBox38_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox38.CheckedChanged
        If CheckBox38.Checked = True Then
            DateTimePicker8.Visible = True
            duedate.Text = DateTimePicker8.Text
        ElseIf CheckBox38.Checked = False Then
            DateTimePicker8.Visible = False
        Else
            DateTimePicker8.Value = duedate.Text
        End If
    End Sub

    Private Sub KryptonButton4_Click(sender As Object, e As EventArgs) Handles KryptonButton4.Click
        If transaction.Text = "Allocation" Then
            allocationproccess()
        ElseIf transaction.Text = "Order" Then
            orderprocess()
        ElseIf transaction.Text = "Receipt" Then
            receiptprocess()
        ElseIf transaction.Text = "Return" Then
            returnprocess()
        ElseIf transaction.Text = "Supply" Then
            supplyprocess()
        ElseIf transaction.Text = "Spare" Then
            spareprocess()
        ElseIf transaction.Text = "+Adjustment" Then
            addadjustmentprocess()
        ElseIf transaction.Text = "-Adjustment" Then
            minadjustmentprocess()
        ElseIf transaction.Text = "Issue" Then
            Try
                sql.sqlcon.Open()
                Dim FINDALLOC As String = "Select ALLOCATION FROM REFERENCE_TB WHERE REFERENCE='" & reference.Text & "' AND STOCKNO='" & transstockno.Text & "'"
                sqlcmd = New SqlCommand(FINDALLOC, sql.sqlcon)
                Dim read As SqlDataReader = sqlcmd.ExecuteReader
                If read.HasRows = True Then
                    read.Close()
                    Dim da As New SqlDataAdapter
                    Dim ds As New DataSet
                    ds.Clear()
                    Dim bs As New BindingSource
                    da.SelectCommand = sqlcmd
                    da.Fill(ds, "reference_tb")
                    bs.DataSource = ds
                    bs.DataMember = "reference_tb"
                    currentallocation.DataBindings.Clear()
                    currentallocation.DataBindings.Add("text", bs, "allocation")
                Else
                    read.Close()
                    currentallocation.DataBindings.Clear()
                    currentallocation.Text = "0"
                End If
                sql.sqlcon.Close()
                If currentallocation.Text = "0" Then
                    issueprocess()
                Else
                    If MessageBox.Show("Issue current allocation first!
Current Allocation:  " & currentallocation.Text & "
Go to Issue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
                        Exit Sub
                    End If
                    TabControl1.SelectedIndex = 3
                    issuereference.Text = reference.Text
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
        transaction.Focus()
    End Sub
    Public Sub allocationproccess()
        Dim allocate As Double = transqty.Text
        Dim free As Double = transfree.Text
        If allocate <= 0 Then
            MessageBox.Show("Allocate more than 0 To Continue", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else

            Dim XYZ As String = ""
            Dim XYZREF As String = ""
            sql.newtransaction(transstockno.Text,
                      transaction.Text,
                      transdate.Text,
                      duedate.Text,
                      transqty.Text,
                      reference.Text,
                      account.Text,
                      controlno.Text,
                               XYZ, XYZREF, remarks.Text)
            updatestock(transstockno.Text, reference.Text)
            loadinputgridviews()
            sql.loadstocks()
            sql.loadtransactions(toprows.Text)
            Dim II As Integer = transarticleno.SelectedIndex
            sql.articlenoinput(transcosthead.Text, transtypecolor.Text)
            If II > transarticleno.Items.Count - 1 Then
                transarticleno.SelectedIndex = -1
            Else
                transarticleno.SelectedIndex = II
            End If

        End If
    End Sub
    Public Sub orderprocess()
        Dim myorder As Double = transqty.Text
        If myorder <= 0 Then
        Else

            Dim XYZ As String = ""
            Dim XYZREF As String = ""
            sql.newtransaction(transstockno.Text,
                   transaction.Text,
                   transdate.Text,
                   duedate.Text,
                   transqty.Text,
                   reference.Text,
                   account.Text,
                   controlno.Text, XYZ, XYZREF, remarks.Text)
            updatestock(transstockno.Text, reference.Text)
            loadinputgridviews()
            sql.loadstocks()
            sql.loadtransactions(toprows.Text)
            Dim II As Integer = transarticleno.SelectedIndex
            sql.articlenoinput(transcosthead.Text, transtypecolor.Text)
            If II > transarticleno.Items.Count - 1 Then
                transarticleno.SelectedIndex = -1
            Else
                transarticleno.SelectedIndex = II
            End If

        End If
    End Sub
    Public Sub receiptprocess()
        Dim myreceipt As Double = transqty.Text
        If myreceipt <= 0 Then
        Else

            Dim XYZ As String = ""
            Dim XYZREF As String = ""
            sql.newtransaction(transstockno.Text,
                   transaction.Text,
                   transdate.Text,
                   duedate.Text,
                   transqty.Text,
                   reference.Text,
                   account.Text,
                   controlno.Text, XYZ, XYZREF, remarks.Text)
            updatestock(transstockno.Text, reference.Text)
            loadinputgridviews()
            sql.loadstocks()
            sql.loadtransactions(toprows.Text)
            Dim II As Integer = transarticleno.SelectedIndex
            sql.articlenoinput(transcosthead.Text, transtypecolor.Text)
            If II > transarticleno.Items.Count - 1 Then
                transarticleno.SelectedIndex = -1
            Else
                transarticleno.SelectedIndex = II
            End If
        End If
    End Sub
    Public Sub returnprocess()
        Dim myreturn As Double = transqty.Text
        If myreturn <= 0 Then
        Else
            Dim XYZ As String = ""
            Dim XYZREF As String = ""
            sql.newtransaction(transstockno.Text,
                   transaction.Text,
                   transdate.Text,
                   duedate.Text,
                   transqty.Text,
                   reference.Text,
                   account.Text,
                   controlno.Text, XYZ, XYZREF, remarks.Text)
            updatestock(transstockno.Text, reference.Text)
            loadinputgridviews()
            sql.loadstocks()
            sql.loadtransactions(toprows.Text)
            Dim II As Integer = transarticleno.SelectedIndex
            sql.articlenoinput(transcosthead.Text, transtypecolor.Text)
            If II > transarticleno.Items.Count - 1 Then
                transarticleno.SelectedIndex = -1
            Else
                transarticleno.SelectedIndex = II
            End If
        End If
    End Sub
    Public Sub supplyprocess()
        Dim mysupply As Double = transqty.Text
        If mysupply <= 0 Then
        Else
            Dim XYZ As String = ""
            Dim XYZREF As String = ""
            sql.newtransaction(transstockno.Text,
                   transaction.Text,
                   transdate.Text,
                   duedate.Text,
                   transqty.Text,
                   reference.Text,
                   account.Text,
                   controlno.Text, XYZ, XYZREF, remarks.Text)
            updatestock(transstockno.Text, reference.Text)
            loadinputgridviews()
            sql.loadstocks()
            sql.loadtransactions(toprows.Text)
            Dim II As Integer = transarticleno.SelectedIndex
            sql.articlenoinput(transcosthead.Text, transtypecolor.Text)
            If II > transarticleno.Items.Count - 1 Then
                transarticleno.SelectedIndex = -1
            Else
                transarticleno.SelectedIndex = II
            End If
        End If
    End Sub
    Public Sub spareprocess()
        Dim myspare As Double = transqty.Text
        If myspare <= 0 Then
        Else
            Dim XYZ As String = ""
            Dim XYZREF As String = ""
            sql.newtransaction(transstockno.Text,
                   transaction.Text,
                   transdate.Text,
                   duedate.Text,
                   transqty.Text,
                   reference.Text,
                   account.Text,
                   controlno.Text, XYZ, XYZREF, remarks.Text)
            updatestock(transstockno.Text, reference.Text)
            loadinputgridviews()
            sql.loadstocks()
            sql.loadtransactions(toprows.Text)
            Dim II As Integer = transarticleno.SelectedIndex
            sql.articlenoinput(transcosthead.Text, transtypecolor.Text)
            If II > transarticleno.Items.Count - 1 Then
                transarticleno.SelectedIndex = -1
            Else
                transarticleno.SelectedIndex = II
            End If
        End If
    End Sub
    Public Sub addadjustmentprocess()
        Dim myadjustment As Double = transqty.Text
        If myadjustment <= 0 Then
        Else
            Dim XYZ As String = ""
            Dim XYZREF As String = ""
            sql.newtransaction(transstockno.Text,
                   transaction.Text,
                   transdate.Text,
                   duedate.Text,
                   transqty.Text,
                   reference.Text,
                   account.Text,
                   controlno.Text, XYZ, XYZREF, remarks.Text)
            updatestock(transstockno.Text, reference.Text)
            loadinputgridviews()
            sql.loadstocks()
            sql.loadtransactions(toprows.Text)
            Dim II As Integer = transarticleno.SelectedIndex
            sql.articlenoinput(transcosthead.Text, transtypecolor.Text)
            If II > transarticleno.Items.Count - 1 Then
                transarticleno.SelectedIndex = -1
            Else
                transarticleno.SelectedIndex = II
            End If
        End If
    End Sub
    Public Sub minadjustmentprocess()
        Dim myadjustment As Double = transqty.Text
        If myadjustment <= 0 Then
        Else
            Dim XYZ As String = ""
            Dim XYZREF As String = ""
            sql.newtransaction(transstockno.Text,
                   transaction.Text,
                   transdate.Text,
                   duedate.Text,
                   transqty.Text,
                   reference.Text,
                   account.Text,
                   controlno.Text, XYZ, XYZREF, remarks.Text)
            updatestock(transstockno.Text, reference.Text)
            loadinputgridviews()
            sql.loadstocks()
            sql.loadtransactions(toprows.Text)
            Dim II As Integer = transarticleno.SelectedIndex
            sql.articlenoinput(transcosthead.Text, transtypecolor.Text)
            If II > transarticleno.Items.Count - 1 Then
                transarticleno.SelectedIndex = -1
            Else
                transarticleno.SelectedIndex = II
            End If
        End If
    End Sub
    Public Sub issueprocess()
        Dim issue As Double = transqty.Text
        Dim free As Double = transfree.Text
        Dim physical As Double = transphysical.Text
        If issue <= 0 Then

        Else

            Dim XYZ As String = ""
            Dim XYZREF As String = ""
            sql.newtransaction(transstockno.Text,
                   transaction.Text,
                   transdate.Text,
                   duedate.Text,
                   transqty.Text,
                   reference.Text,
                   account.Text,
                   controlno.Text, XYZ, XYZREF, remarks.Text)
            updatestock(transstockno.Text, reference.Text)
            loadinputgridviews()
            sql.loadstocks()
            sql.loadtransactions(toprows.Text)
            Dim II As Integer = transarticleno.SelectedIndex
            sql.articlenoinput(transcosthead.Text, transtypecolor.Text)
            If II > transarticleno.Items.Count - 1 Then
                transarticleno.SelectedIndex = -1
            Else
                transarticleno.SelectedIndex = II
            End If
        End If
    End Sub
    Public Sub loadinputgridviews()
        Try
            sql.sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            Dim loadinput As String = "Declare @transno As varchar(50) = (select max(transno) from trans_tb) select * from trans_tb where transno = @transno"
            sqlcmd = New SqlCommand(loadinput, sql.sqlcon)
            Dim da As New SqlDataAdapter
            da.SelectCommand = sqlcmd
            da.Fill(ds, "trans_tb")
            bs.DataSource = ds
            bs.DataMember = "trans_tb"
            inputGridView.DataSource = bs
            Dim ds1 As New DataSet
            Dim bs1 As New BindingSource
            ds1.Clear()
            Dim loadstocks As String = "select STOCKNO,TYPECOLOR,ARTICLENO,QTY,PHYSICAL,ALLOCATION,FREE,STOCKORDER,MINIMUM from stocks_tb where STOCKNO = '" & transstockno.Text & "'"
            sqlcmd = New SqlCommand(loadstocks, sql.sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds1, "stocks_tb")
            bs1.DataSource = ds1
            bs1.DataMember = "stocks_tb"
            inputDataGridView1.DataSource = bs1
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub
    Public Sub updatetransaction(ByVal qty As String, ByVal transno As String)
        Try
            sql.sqlcon.Open()
            Dim x As String = "
DECLARE @receipt as varchar(max)=(select transno from trans_tb where xyzref='" & transno & "')
update trans_tb set qty = '" & qty & "',xyzref=@receipt where transno = '" & transno & "'
"
            sqlcmd = New SqlCommand(x, sql.sqlcon)
            sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub
    Public Sub updatestock(ByVal stockno As String, ByVal reference As String)
        Try
            sql.sqlcon.Open()
            Dim str As String = "
                                    declare @allocation as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' AND TRANSTYPE='Allocation')+0
                                    declare @cancelalloc as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' AND TRANSTYPE='CancelAlloc')+0
                                    declare @order as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' AND TRANSTYPE='Order')+0
                                    declare @return as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' AND TRANSTYPE='Return')+0
                                    declare @supply as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' AND TRANSTYPE='Supply')+0
                                    declare @spare as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' AND TRANSTYPE='Spare')+0
                                    declare @addadjustment as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' AND TRANSTYPE='+Adjustment')+0
                                    declare @minadjustment as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' AND TRANSTYPE='-Adjustment')+0
                                    declare @receipt as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' AND TRANSTYPE='Receipt' AND NOT XYZ='Order')+0
                                    declare @issue as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' AND TRANSTYPE='Issue' AND NOT XYZ ='Allocation')+0
                                    declare @receiptorder as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' AND TRANSTYPE='Receipt' AND XYZ='Order')+0
                                    declare @issueallocation as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' AND TRANSTYPE='Issue' AND XYZ ='Allocation')+0
                                    declare @totalreceipt as decimal(10,2)=@receipt+@receiptorder
                                    declare @totalissue as decimal(10,2)=@issue+@issueallocation
            update stocks_tb set 
                                    
                                    physical=(QTY+@totalreceipt+@return+@addadjustment)-(@totalissue+@minadjustment),
                                    allocation = @allocation-(@issueallocation+@cancelalloc),
                                    free=(((QTY+@totalreceipt+@return+@addadjustment)-(@allocation-@cancelalloc)))-(@issue+@minadjustment),
                                    stockorder=@order-@receiptorder,
                                    issue=@totalissue
                                    where stockno='" & stockno & "'"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            sqlcmd.ExecuteNonQuery()


            Dim bny As String = "
                                    declare @allocation as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' AND TRANSTYPE='Allocation')+0
                                    declare @cancelalloc as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' AND TRANSTYPE='CancelAlloc')+0
                                    declare @order as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' AND TRANSTYPE='Order')+0
                                    declare @return as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' AND TRANSTYPE='Return')+0
                                    declare @receipt as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' AND TRANSTYPE='Receipt' AND NOT XYZ='Order')+0
                                    declare @issue as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' AND TRANSTYPE='Issue' AND NOT XYZ ='Allocation')+0
                                    declare @receiptorder as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' AND TRANSTYPE='Receipt' AND XYZ='Order')+0
                                    declare @issueallocation as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' AND TRANSTYPE='Issue' AND XYZ ='Allocation')+0
                                    declare @totalreceipt as decimal(10,2)=@receipt+@receiptorder
                                    declare @totalissue as decimal(10,2)=@issue+@issueallocation
                              
update reference_tb set 

                                    allocation=@allocation-(@issueallocation+@cancelalloc),
                                    stockorder=@order-@receiptorder,
                                    TOTALRECEIPT=@totalreceipt,
                                    totalissue=@totalissue,
                                    totalreturn=@return
                                    where stockno='" & stockno & "' and reference='" & reference & "'"
            sqlcmd = New SqlCommand(bny, sql.sqlcon)
            sqlcmd.ExecuteNonQuery()

            'Dim NEWSTR As String = "
            '                        declare @allocation as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' AND TRANSTYPE='Allocation')+0
            '                        declare @order as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' AND TRANSTYPE='Order')+0
            '                        declare @receipt as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' AND TRANSTYPE='Receipt')+0
            '                        declare @issue as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' AND TRANSTYPE='Issue')+0

            'update reference_tb set 

            '                        allocation=@allocation-@issue,
            '                        stockorder=@order-@receipt,
            '                        TOTALRECEIPT=@receipt,
            '                        totalissue=@issue
            '                        where stockno='" & stockno & "' and reference='" & reference & "'"
            'sqlcmd = New SqlCommand(NEWSTR, sql.sqlcon)
            'sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Private Sub refsource_TextChanged(sender As Object, e As EventArgs) Handles refsource.TextChanged
        sql.loadreference(refsource.Text)
    End Sub

    Private Sub transcosthead_MouseDown(sender As Object, e As MouseEventArgs) Handles transcosthead.MouseDown
        Dim x As Integer = transcosthead.SelectedIndex
        transtypecolor.Text = ""
        transarticleno.Text = ""
        transdescription.Text = ""
        transphysical.Text = 0
        transfree.Text = 0
        currentallocation.Text = 0
        sql.costheadinput()
        If x > transcosthead.Items.Count - 1 Then
            transcosthead.SelectedIndex = -1
        Else
            transcosthead.SelectedIndex = x
        End If
    End Sub

    Private Sub transtypecolor_MouseDown(sender As Object, e As MouseEventArgs) Handles transtypecolor.MouseDown
        transarticleno.Text = ""
        transarticleno.Text = ""
        transdescription.Text = ""
        transphysical.Text = 0
        transfree.Text = 0
        currentallocation.Text = 0

        Dim x As Integer = transtypecolor.SelectedIndex
        If transcosthead.Text = "" Then
            sql.typecolorinput1()
        Else
            sql.typecolorinput(transcosthead.Text)
        End If
        If x > transtypecolor.Items.Count - 1 Then
            transtypecolor.SelectedIndex = -1
        Else
            transtypecolor.SelectedIndex = x
        End If
    End Sub

    Private Sub transarticleno_MouseDown(sender As Object, e As MouseEventArgs) Handles transarticleno.MouseDown
        transdescription.Text = ""
        transphysical.Text = 0
        transfree.Text = 0
        currentallocation.Text = 0
        Dim x As Integer = transarticleno.SelectedIndex

        If transcosthead.Text = "" And transtypecolor.Text = "" Then
            sql.articlenoinput1()
        ElseIf Not transcosthead.Text = "" And transtypecolor.Text = "" Then
            sql.articlenoinput2(transcosthead.Text)
        ElseIf transcosthead.Text = "" And Not transtypecolor.Text = "" Then
            sql.articlenoinput3(transtypecolor.Text)
        Else
            sql.articlenoinput(transcosthead.Text, transtypecolor.Text)
        End If


        If x > transarticleno.Items.Count - 1 Then
            transarticleno.SelectedIndex = -1
        Else
            transarticleno.SelectedIndex = x
        End If
    End Sub

    Private Sub receiptcosthead_MouseDown(sender As Object, e As MouseEventArgs) Handles receiptcosthead.MouseDown
        receipttypecolor.SelectedIndex = -1
        receiptarticleno.SelectedIndex = -1
        Dim i As Integer = receiptcosthead.SelectedIndex
        sql.costheadreceipt()
        If i > receiptcosthead.Items.Count - 1 Then
            receiptcosthead.SelectedIndex = -1
        Else
            receiptcosthead.SelectedIndex = i
        End If
    End Sub

    Private Sub receipttypecolor_MouseDown(sender As Object, e As MouseEventArgs) Handles receipttypecolor.MouseDown
        receiptarticleno.SelectedIndex = -1
        Dim i As Integer = receipttypecolor.SelectedIndex
        If receiptcosthead.Text = "" Then
            sql.typecolorreceipt1()
        Else
            sql.typecolorreceipt(receiptcosthead.Text)
        End If
        If i > receipttypecolor.Items.Count - 1 Then
            receipttypecolor.SelectedIndex = -1
        Else
            receipttypecolor.SelectedIndex = i
        End If
    End Sub

    Private Sub receiptarticleno_MouseDown(sender As Object, e As MouseEventArgs) Handles receiptarticleno.MouseDown
        Dim i As Integer = receiptarticleno.SelectedIndex
        If receiptcosthead.Text = "" And receipttypecolor.Text = "" Then
            sql.articlenoreceipt1()
        ElseIf Not receiptcosthead.Text = "" And receipttypecolor.Text = "" Then
            sql.articlenoreceipt2(receiptcosthead.Text)
        ElseIf receiptcosthead.Text = "" And Not receipttypecolor.Text = "" Then
            sql.articlenoreceipt3(receipttypecolor.Text)
        Else
            sql.articlenoreceipt(receiptcosthead.Text, receipttypecolor.Text)
        End If
        If i > receiptarticleno.Items.Count - 1 Then
            receiptarticleno.SelectedIndex = -1
        Else
            receiptarticleno.SelectedIndex = i
        End If
    End Sub

    Private Sub receiptreference_MouseDown(sender As Object, e As MouseEventArgs) Handles receiptreference.MouseDown
        Dim x As Integer = receiptreference.SelectedIndex
        sql.referencereceipt()
        If x > receiptreference.Items.Count - 1 Then
            receiptreference.SelectedIndex = -1
        Else
            receiptreference.SelectedIndex = x
        End If
    End Sub

    Private Sub KryptonButton6_Click(sender As Object, e As EventArgs) Handles KryptonButton6.Click
        sql.searchreference(receiptreference.Text, receiptstockno.Text)
        sql.selectreceiptreferencerecord1(receiptreference.Text, receiptstockno.Text)
    End Sub

    Private Sub receiptGridView_SelectionChanged(sender As Object, e As EventArgs) Handles receiptGridView.SelectionChanged
        receiptarticleno.SelectedIndex = -1
        receiptcosthead.SelectedIndex = -1
        receipttypecolor.SelectedIndex = -1
        Dim selecteditem As DataGridViewSelectedRowCollection = receiptGridView.SelectedRows
        receiptorder.Text = 0

        For Each selecteditems As DataGridViewRow In selecteditem
            receiptorder.Text = selecteditems.Cells("qty").Value.ToString
            receiptstockno.Text = selecteditems.Cells("stockno").Value.ToString
            receipttransno.Text = selecteditems.Cells("transno").Value.ToString
            sql.selectsubreference(receiptstockno.Text)
        Next
    End Sub

    Private Sub KryptonButton5_Click(sender As Object, e As EventArgs) Handles KryptonButton5.Click
        Dim myreceipt As Double = receiptqty.Text
        Dim order As Double = receiptorder.Text

        If retainbal.Checked = False Then

            If myreceipt <= 0 Then
                MessageBox.Show("receipt more than 0 to continue", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf myreceipt > order Then
                MessageBox.Show("insufficient order", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else

                Dim transaction = "Receipt"
                Dim duedate As String = ""
                Dim account As String = ""
                Dim controlno As String = ""
                Dim XYZ As String = "Order"
                Dim remarks As String = ""
                sql.newtransaction(receiptstockno.Text,
                       transaction,
                       transdate.Text,
                       duedate,
                       receiptqty.Text,
                      receiptreference.Text,
                       account,
                       controlno, XYZ, receipttransno.Text, remarks)
                updatetransaction(receiptqty.Text, receipttransno.Text)
                updatestock(receiptstockno.Text, receiptreference.Text)
                sql.loadstocks()
                sql.loadtransactions(toprows.Text)
                sql.searchreference(receiptreference.Text, receiptstockno.Text)
            End If
        ElseIf retainbal.Checked = True Then
            If myreceipt <= 0 Then
                MessageBox.Show("receipt more than 0 to continue", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf myreceipt > order Then
                MessageBox.Show("insufficient order", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf myreceipt = order Then
                MessageBox.Show("0 balance expected", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                Dim transaction = "Receipt"
                Dim duedate As String = ""
                Dim account As String = ""
                Dim controlno As String = ""
                Dim XYZ As String = "Order"
                Dim remarks As String = ""
                sql.newtransaction(receiptstockno.Text,
                       transaction,
                       transdate.Text,
                       duedate,
                       receiptqty.Text,
                      receiptreference.Text,
                       account,
                       controlno, XYZ, receipttransno.Text, remarks)
                updatetransaction(receiptqty.Text, receipttransno.Text)

                Dim bal = order - myreceipt
                neworderbalance(receipttransno.Text, bal)

                updatestock(receiptstockno.Text, receiptreference.Text)
                sql.loadstocks()
                sql.loadtransactions(toprows.Text)
                sql.searchreference(receiptreference.Text, receiptstockno.Text)
            End If
        End If
    End Sub
    Public Sub neworderbalance(ByVal transno As String, ByVal bal As String)
        Try
            sql.sqlcon.Open()
            Dim str As String = "
insert into trans_tb
  (STOCKNO,
            TRANSTYPE,
            TRANSDATE,
            DUEDATE,
            QTY,
            REFERENCE,
            ACCOUNT,
            CONTROLNO,
            XYZ,
            XYZREF,
            REMARKS,
            INPUTTED)
select
   STOCKNO,
            TRANSTYPE,
            TRANSDATE,
            DUEDATE,
            " & bal & ",
            REFERENCE,
            ACCOUNT,
            CONTROLNO,
            '',
            '',
            REMARKS,
            '" & Form1.Label1.Text & "'
            from trans_tb where transno = " & transno & ""
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Private Sub issuereference_MouseDown(sender As Object, e As MouseEventArgs) Handles issuereference.MouseDown
        Dim x As Integer = issuereference.SelectedIndex
        sql.referenceissue()
        If x > issuereference.Items.Count - 1 Then
            issuereference.SelectedIndex = -1
        Else
            issuereference.SelectedIndex = x
        End If
    End Sub

    Private Sub issuecosthead_MouseDown(sender As Object, e As MouseEventArgs) Handles issuecosthead.MouseDown
        Dim x As Integer = issuecosthead.SelectedIndex
        issuearticleno.SelectedIndex = -1
        issuetypecolor.SelectedIndex = -1
        sql.costheadissue()
        If x > issuecosthead.Items.Count - 1 Then
            issuecosthead.SelectedIndex = -1
        Else
            issuecosthead.SelectedIndex = x
        End If
    End Sub

    Private Sub issuetypecolor_MouseDown(sender As Object, e As MouseEventArgs) Handles issuetypecolor.MouseDown
        Dim x As Integer = issuetypecolor.SelectedIndex
        issuearticleno.SelectedIndex = -1
        If issuecosthead.Text = "" Then
            sql.typecolorissue1()
        Else
            sql.typecolorissue(issuecosthead.Text)
        End If
        If x > issuetypecolor.Items.Count - 1 Then
            issuetypecolor.SelectedIndex = -1
        Else
            issuetypecolor.SelectedIndex = x
        End If
    End Sub

    Private Sub issuearticleno_MouseDown(sender As Object, e As MouseEventArgs) Handles issuearticleno.MouseDown
        Dim x As Integer = issuearticleno.SelectedIndex
        If issuecosthead.Text = "" And issuetypecolor.Text = "" Then
            sql.articlenoissue1()
        ElseIf Not issuecosthead.Text = "" And issuetypecolor.Text = "" Then
            sql.articlenoissue2(issuecosthead.Text)
        ElseIf issuecosthead.Text = "" And Not issuetypecolor.Text = "" Then
            sql.articlenoissue3(issuetypecolor.Text)
        Else
            sql.articlenoissue(issuecosthead.Text, issuetypecolor.Text)
        End If
        If x > issuearticleno.Items.Count - 1 Then
            issuearticleno.SelectedIndex = -1
        Else
            issuearticleno.SelectedIndex = x
        End If

    End Sub

    Private Sub KryptonButton7_Click(sender As Object, e As EventArgs) Handles KryptonButton7.Click
        issuearticleno.SelectedIndex = -1
        issuecosthead.SelectedIndex = -1
        issuetypecolor.SelectedIndex = -1
        sql.searchreferenceissue(issuereference.Text, issuestockno.Text)
        sql.selectissuereferencerecord1(issuereference.Text, issuestockno.Text)
    End Sub

    Private Sub issueDataGridView_SelectionChanged(sender As Object, e As EventArgs) Handles issueDataGridView.SelectionChanged
        Dim selecteditem As DataGridViewSelectedRowCollection = issueDataGridView.SelectedRows
        issueallocation.Text = 0

        For Each selecteditems As DataGridViewRow In selecteditem
            issueallocation.Text = selecteditems.Cells("allocation").Value.ToString
            issuestockno.Text = selecteditems.Cells("stockno").Value.ToString
            sql.selectsubreferenceissue(issuestockno.Text)
        Next
    End Sub

    Private Sub KryptonButton8_Click(sender As Object, e As EventArgs) Handles KryptonButton8.Click
        Dim myissue As Double = issueqty.Text
        Dim allocate As Double = issueallocation.Text
        Dim physical As Double = issuephysical.Text
        If myissue <= 0 Then
            MessageBox.Show("issue more than 0 to continue", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        ElseIf myissue > allocate Then
            MessageBox.Show("insufficient allocation", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else

            Dim duedate As String = ""
            Dim transaction = "Issue"

            Dim XYZ As String = "Allocation"
            Dim xyzref As String = ""
            sql.newtransaction(issuestockno.Text,
                   transaction,
                   transdate.Text,
                   duedate,
                   issueqty.Text,
                 issuereference.Text,
                   issueaccount.Text,
                   issuecontrolno.Text, XYZ, xyzref, issueremarks.Text)
            updatestock(issuestockno.Text, issuereference.Text)
            sql.loadstocks()
            sql.loadtransactions(toprows.Text)
            sql.searchreferenceissue(issuereference.Text, issuestockno.Text)
            issueDataGridView.Visible = True
            KryptonGroup5.Visible = False
            issueqty.Text = 0
        End If
    End Sub

    Private Sub receiptreference_TextChanged(sender As Object, e As EventArgs) Handles receiptreference.TextChanged
        sql.selectreceiptreferencerecord(receiptreference.Text)
    End Sub

    Private Sub issuereference_TextChanged(sender As Object, e As EventArgs) Handles issuereference.TextChanged
        sql.selectissuereferencerecord(issuereference.Text)
    End Sub

    Private Sub KryptonButton9_Click(sender As Object, e As EventArgs) Handles KryptonButton9.Click
        issueDataGridView.Visible = True
        KryptonGroup5.Visible = False
    End Sub

    Private Sub issueDataGridView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles issueDataGridView.CellDoubleClick
        If issueDataGridView.RowCount > 0 And e.RowIndex >= 0 Then
            issueDataGridView.Visible = False
            KryptonGroup5.Visible = True
        End If
    End Sub

    Private Sub issueDataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles issueDataGridView1.SelectionChanged
        Dim selecteditem As DataGridViewSelectedRowCollection = issueDataGridView1.SelectedRows
        issuephysical.Text = 0
        For Each x As DataGridViewRow In selecteditem
            issuephysical.Text = x.Cells("Physical").Value.ToString
        Next
    End Sub

    Private Sub KryptonButton11_Click(sender As Object, e As EventArgs) Handles KryptonButton11.Click
        Dim search As String
        Dim count As String = "select format(count(a.TRANSNO),'n0') from trans_tb as a inner join stocks_tb as b on a.stockno = b.stockno"
        Dim countsearch As String
        Dim top As String = toprows.Text.Replace(",", "")

        Dim selection As String = " top " & top & " a.TRANSNO,
a.STOCKNO,
b.COSTHEAD,
b.TYPECOLOR,
B.ARTICLENO,
B.DESCRIPTION,
a.TRANSTYPE,
a.TRANSDATE,
a.DUEDATE,
a.QTY,
a.REFERENCE,
a.ACCOUNT,
a.CONTROLNO,
a.xyz,
a.REMARKS
 from trans_tb as a inner join stocks_tb as b
on a.stockno = b.stockno"
        If all.Checked = True And Not transreference.Text = "" And Not transtransaction.Text = "" And Not transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.reference='" & transreference.Text & "' and a.transtype='" & transtransaction.Text & "' and b.costhead='" & transactioncosthead.Text & "'"
            countsearch = "" & count & " where a.reference='" & transreference.Text & "' and a.transtype='" & transtransaction.Text & "' and b.costhead='" & transactioncosthead.Text & "'"
            sql.searchtransaction(search, countsearch)
        ElseIf all.Checked = True And Not transreference.Text = "" And transtransaction.Text = "" And transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.reference='" & transreference.Text & "'"
            countsearch = "" & count & "  where a.reference='" & transreference.Text & "'"
            sql.searchtransaction(search, countsearch)
        ElseIf all.Checked = True And transreference.Text = "" And Not transtransaction.Text = "" And transactioncosthead.Text = "" Then
            search = "Select " & selection & " where a.transtype='" & transtransaction.Text & "'"
            countsearch = "" & count & "  where a.transtype='" & transtransaction.Text & "'"
            sql.searchtransaction(search, countsearch)
        ElseIf all.Checked = True And transreference.Text = "" And transtransaction.Text = "" And Not transactioncosthead.Text = "" Then
            search = "select " & selection & " where b.costhead='" & transactioncosthead.Text & "'"
            countsearch = "" & count & "  where b.costhead='" & transactioncosthead.Text & "'"
            sql.searchtransaction(search, countsearch)
        ElseIf all.Checked = True And Not transreference.Text = "" And Not transtransaction.Text = "" And transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.reference='" & transreference.Text & "' and a.transtype='" & transtransaction.Text & "'"
            countsearch = "" & count & "  where a.reference='" & transreference.Text & "' and a.transtype='" & transtransaction.Text & "'"
            sql.searchtransaction(search, countsearch)
        ElseIf all.Checked = True And Not transreference.Text = "" And transtransaction.Text = "" And Not transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.reference='" & transreference.Text & "' and b.costhead='" & transactioncosthead.Text & "'"
            countsearch = "" & count & "  where a.reference='" & transreference.Text & "' and b.costhead='" & transactioncosthead.Text & "'"
            sql.searchtransaction(search, countsearch)
        ElseIf all.Checked = True And transreference.Text = "" And Not transtransaction.Text = "" And Not transactioncosthead.Text = "" Then
            search = "select " & selection & " where  a.transtype='" & transtransaction.Text & "' and b.costhead='" & transactioncosthead.Text & "'"
            countsearch = "" & count & " where  a.transtype='" & transtransaction.Text & "' and b.costhead='" & transactioncosthead.Text & "'"
            sql.searchtransaction(search, countsearch)
        ElseIf all.Checked = True And transreference.Text = "" And transtransaction.Text = "" And transactioncosthead.Text = "" Then
            search = "select " & selection & ""
            countsearch = "" & count & ""
            sql.searchtransaction(search, countsearch)
        End If

        If thisdate.Checked = True And Not transreference.Text = "" And Not transtransaction.Text = "" And Not transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.reference='" & transreference.Text & "' and a.transtype='" & transtransaction.Text & "' and b.costhead='" & transactioncosthead.Text & "' and a.TRANSDATE ='" & transadate.Text & "'"
            countsearch = "" & count & " where a.reference='" & transreference.Text & "' and a.transtype='" & transtransaction.Text & "' and b.costhead='" & transactioncosthead.Text & "' and a.TRANSDATE ='" & transadate.Text & "'"
            sql.searchtransaction(search, countsearch)
        ElseIf thisdate.Checked = True And Not transreference.Text = "" And transtransaction.Text = "" And transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.reference='" & transreference.Text & "' and a.TRANSDATE ='" & transadate.Text & "'"
            countsearch = "" & count & " where a.reference='" & transreference.Text & "' and a.TRANSDATE ='" & transadate.Text & "'"
            sql.searchtransaction(search, countsearch)
        ElseIf thisdate.Checked = True And transreference.Text = "" And Not transtransaction.Text = "" And transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.transtype='" & transtransaction.Text & "' and a.TRANSDATE ='" & transadate.Text & "'"
            countsearch = "" & count & " where a.transtype='" & transtransaction.Text & "' and a.TRANSDATE ='" & transadate.Text & "'"
            sql.searchtransaction(search, countsearch)
        ElseIf thisdate.Checked = True And transreference.Text = "" And transtransaction.Text = "" And Not transactioncosthead.Text = "" Then
            search = "select " & selection & " where b.costhead='" & transactioncosthead.Text & "' and a.TRANSDATE ='" & transadate.Text & "'"
            countsearch = "" & count & " where b.costhead='" & transactioncosthead.Text & "' and a.TRANSDATE ='" & transadate.Text & "'"
            sql.searchtransaction(search, countsearch)
        ElseIf thisdate.Checked = True And Not transreference.Text = "" And Not transtransaction.Text = "" And transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.reference='" & transreference.Text & "' and a.transtype='" & transtransaction.Text & "' and a.TRANSDATE ='" & transadate.Text & "'"
            countsearch = "" & count & " where a.reference='" & transreference.Text & "' and a.transtype='" & transtransaction.Text & "' and a.TRANSDATE ='" & transadate.Text & "'"
            sql.searchtransaction(search, countsearch)
        ElseIf thisdate.Checked = True And Not transreference.Text = "" And transtransaction.Text = "" And Not transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.reference='" & transreference.Text & "' and b.costhead='" & transactioncosthead.Text & "' and a.TRANSDATE ='" & transadate.Text & "'"
            countsearch = "" & count & " where a.reference='" & transreference.Text & "' and b.costhead='" & transactioncosthead.Text & "' and a.TRANSDATE ='" & transadate.Text & "'"
            sql.searchtransaction(search, countsearch)
        ElseIf thisdate.Checked = True And transreference.Text = "" And Not transtransaction.Text = "" And Not transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.transtype='" & transtransaction.Text & "' and b.costhead='" & transactioncosthead.Text & "' and a.TRANSDATE ='" & transadate.Text & "'"
            countsearch = "" & count & " where a.transtype='" & transtransaction.Text & "' and b.costhead='" & transactioncosthead.Text & "' and a.TRANSDATE ='" & transadate.Text & "'"
            sql.searchtransaction(search, countsearch)
        ElseIf thisdate.Checked = True And transreference.Text = "" And transtransaction.Text = "" And transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.TRANSDATE ='" & transadate.Text & "'"
            countsearch = "" & count & " where a.TRANSDATE ='" & transadate.Text & "'"
            sql.searchtransaction(search, countsearch)
        End If

        If before.Checked = True And Not transreference.Text = "" And Not transtransaction.Text = "" And Not transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.reference='" & transreference.Text & "' and a.transtype='" & transtransaction.Text & "' and b.costhead='" & transactioncosthead.Text & "' and a.TRANSDATE < '" & transadate.Text & "'"
            countsearch = "" & count & " where a.reference='" & transreference.Text & "' and a.transtype='" & transtransaction.Text & "' and b.costhead='" & transactioncosthead.Text & "' and a.TRANSDATE < '" & transadate.Text & "'"
            sql.searchtransaction(search, countsearch)
        ElseIf before.Checked = True And Not transreference.Text = "" And transtransaction.Text = "" And transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.reference='" & transreference.Text & "' and a.TRANSDATE < '" & transadate.Text & "'"
            countsearch = "" & count & "  where a.reference='" & transreference.Text & "' and a.TRANSDATE < '" & transadate.Text & "'"
            sql.searchtransaction(search, countsearch)
        ElseIf before.Checked = True And transreference.Text = "" And Not transtransaction.Text = "" And transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.transtype='" & transtransaction.Text & "' and a.TRANSDATE < '" & transadate.Text & "'"
            countsearch = "" & count & "  where a.transtype='" & transtransaction.Text & "' and a.TRANSDATE < '" & transadate.Text & "'"
            sql.searchtransaction(search, countsearch)
        ElseIf before.Checked = True And transreference.Text = "" And transtransaction.Text = "" And Not transactioncosthead.Text = "" Then
            search = "select " & selection & " where b.costhead='" & transactioncosthead.Text & "' and a.TRANSDATE < '" & transadate.Text & "'"
            countsearch = "" & count & "  where b.costhead='" & transactioncosthead.Text & "' and a.TRANSDATE < '" & transadate.Text & "'"
            sql.searchtransaction(search, countsearch)
        ElseIf before.Checked = True And Not transreference.Text = "" And Not transtransaction.Text = "" And transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.reference='" & transreference.Text & "' and a.transtype='" & transtransaction.Text & "' and a.TRANSDATE < '" & transadate.Text & "'"
            countsearch = "" & count & "  where a.reference='" & transreference.Text & "' and a.transtype='" & transtransaction.Text & "' and a.TRANSDATE < '" & transadate.Text & "'"
            sql.searchtransaction(search, countsearch)
        ElseIf before.Checked = True And Not transreference.Text = "" And transtransaction.Text = "" And Not transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.reference='" & transreference.Text & "' and b.costhead='" & transactioncosthead.Text & "' and a.TRANSDATE < '" & transadate.Text & "'"
            countsearch = "" & count & "  where a.reference='" & transreference.Text & "' and b.costhead='" & transactioncosthead.Text & "' and a.TRANSDATE < '" & transadate.Text & "'"
            sql.searchtransaction(search, countsearch)
        ElseIf before.Checked = True And transreference.Text = "" And Not transtransaction.Text = "" And Not transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.transtype='" & transtransaction.Text & "' and b.costhead='" & transactioncosthead.Text & "' and a.TRANSDATE < '" & transadate.Text & "'"
            countsearch = "" & count & "  where a.transtype='" & transtransaction.Text & "' and b.costhead='" & transactioncosthead.Text & "' and a.TRANSDATE < '" & transadate.Text & "'"
            sql.searchtransaction(search, countsearch)
        ElseIf before.Checked = True And transreference.Text = "" And transtransaction.Text = "" And transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.TRANSDATE < '" & transadate.Text & "'"
            countsearch = "" & count & "  where a.TRANSDATE < '" & transadate.Text & "'"
            sql.searchtransaction(search, countsearch)
        End If

        If after.Checked = True And Not transreference.Text = "" And Not transtransaction.Text = "" And Not transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.reference='" & transreference.Text & "' and a.transtype='" & transtransaction.Text & "' and b.costhead='" & transactioncosthead.Text & "' and a.TRANSDATE > '" & transadate.Text & "'"
            countsearch = "" & count & "  where a.reference='" & transreference.Text & "' and a.transtype='" & transtransaction.Text & "' and b.costhead='" & transactioncosthead.Text & "' and a.TRANSDATE > '" & transadate.Text & "'"
            sql.searchtransaction(search, countsearch)
        ElseIf after.Checked = True And Not transreference.Text = "" And transtransaction.Text = "" And transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.reference='" & transreference.Text & "' and a.TRANSDATE > '" & transadate.Text & "'"
            countsearch = "" & count & "  where a.reference='" & transreference.Text & "' and a.TRANSDATE > '" & transadate.Text & "'"
            sql.searchtransaction(search, countsearch)
        ElseIf after.Checked = True And transreference.Text = "" And Not transtransaction.Text = "" And transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.transtype='" & transtransaction.Text & "' and a.TRANSDATE > '" & transadate.Text & "'"
            countsearch = "" & count & "  where a.transtype='" & transtransaction.Text & "' and a.TRANSDATE > '" & transadate.Text & "'"
            sql.searchtransaction(search, countsearch)
        ElseIf after.Checked = True And transreference.Text = "" And transtransaction.Text = "" And Not transactioncosthead.Text = "" Then
            search = "select " & selection & " where b.costhead='" & transactioncosthead.Text & "' and a.TRANSDATE > '" & transadate.Text & "'"
            countsearch = "" & count & "  where b.costhead='" & transactioncosthead.Text & "' and a.TRANSDATE > '" & transadate.Text & "'"
            sql.searchtransaction(search, countsearch)
        ElseIf after.Checked = True And Not transreference.Text = "" And Not transtransaction.Text = "" And transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.reference='" & transreference.Text & "' and a.transtype='" & transtransaction.Text & "' and a.TRANSDATE > '" & transadate.Text & "'"
            countsearch = "" & count & "  where a.reference='" & transreference.Text & "' and a.transtype='" & transtransaction.Text & "' and a.TRANSDATE > '" & transadate.Text & "'"
            sql.searchtransaction(search, countsearch)
        ElseIf after.Checked = True And Not transreference.Text = "" And transtransaction.Text = "" And Not transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.reference='" & transreference.Text & "' and b.costhead='" & transactioncosthead.Text & "' and a.TRANSDATE > '" & transadate.Text & "'"
            countsearch = "" & count & "  where a.reference='" & transreference.Text & "' and b.costhead='" & transactioncosthead.Text & "' and a.TRANSDATE > '" & transadate.Text & "'"
            sql.searchtransaction(search, countsearch)
        ElseIf after.Checked = True And transreference.Text = "" And Not transtransaction.Text = "" And Not transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.transtype='" & transtransaction.Text & "' and b.costhead='" & transactioncosthead.Text & "' and a.TRANSDATE > '" & transadate.Text & "'"
            countsearch = "" & count & " where a.transtype='" & transtransaction.Text & "' and b.costhead='" & transactioncosthead.Text & "' and a.TRANSDATE > '" & transadate.Text & "'"
            sql.searchtransaction(search, countsearch)
        ElseIf after.Checked = True And transreference.Text = "" And transtransaction.Text = "" And transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.TRANSDATE > '" & transadate.Text & "'"
            countsearch = "" & count & "  where a.TRANSDATE > '" & transadate.Text & "'"
            sql.searchtransaction(search, countsearch)
        End If

        If tomydate.Checked = True And Not transreference.Text = "" And Not transtransaction.Text = "" And Not transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.reference='" & transreference.Text & "' and a.transtype='" & transtransaction.Text & "' and b.costhead='" & transactioncosthead.Text & "' and a.TRANSDATE between '" & transadate.Text & "' and '" & todate.Text & "'"
            countsearch = "" & count & "  where a.reference='" & transreference.Text & "' and a.transtype='" & transtransaction.Text & "' and b.costhead='" & transactioncosthead.Text & "' and a.TRANSDATE between '" & transadate.Text & "' and '" & todate.Text & "'"
            sql.searchtransaction(search, countsearch)
        ElseIf tomydate.Checked = True And Not transreference.Text = "" And transtransaction.Text = "" And transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.reference='" & transreference.Text & "' and a.TRANSDATE between '" & transadate.Text & "' and '" & todate.Text & "'"
            countsearch = "" & count & "  where a.reference='" & transreference.Text & "' and a.TRANSDATE between '" & transadate.Text & "' and '" & todate.Text & "'"
            sql.searchtransaction(search, countsearch)
        ElseIf tomydate.Checked = True And transreference.Text = "" And Not transtransaction.Text = "" And transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.transtype='" & transtransaction.Text & "' and a.TRANSDATE between '" & transadate.Text & "' and '" & todate.Text & "'"
            countsearch = "" & count & "  where a.transtype='" & transtransaction.Text & "' and a.TRANSDATE between '" & transadate.Text & "' and '" & todate.Text & "'"
            sql.searchtransaction(search, countsearch)
        ElseIf tomydate.Checked = True And transreference.Text = "" And transtransaction.Text = "" And Not transactioncosthead.Text = "" Then
            search = "select " & selection & " where b.costhead='" & transactioncosthead.Text & "' and a.TRANSDATE between '" & transadate.Text & "' and '" & todate.Text & "'"
            countsearch = "" & count & "  where b.costhead='" & transactioncosthead.Text & "' and a.TRANSDATE between '" & transadate.Text & "' and '" & todate.Text & "'"
            sql.searchtransaction(search, countsearch)
        ElseIf tomydate.Checked = True And Not transreference.Text = "" And Not transtransaction.Text = "" And transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.reference='" & transreference.Text & "' and a.transtype='" & transtransaction.Text & "' and a.TRANSDATE between '" & transadate.Text & "' and '" & todate.Text & "'"
            countsearch = "" & count & "  where a.reference='" & transreference.Text & "' and a.transtype='" & transtransaction.Text & "' and a.TRANSDATE between '" & transadate.Text & "' and '" & todate.Text & "'"
            sql.searchtransaction(search, countsearch)
        ElseIf tomydate.Checked = True And Not transreference.Text = "" And transtransaction.Text = "" And Not transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.reference='" & transreference.Text & "' and b.costhead='" & transactioncosthead.Text & "' and a.TRANSDATE between '" & transadate.Text & "' and '" & todate.Text & "'"
            countsearch = "" & count & "  where a.reference='" & transreference.Text & "' and b.costhead='" & transactioncosthead.Text & "' and a.TRANSDATE between '" & transadate.Text & "' and '" & todate.Text & "'"
            sql.searchtransaction(search, countsearch)
        ElseIf tomydate.Checked = True And transreference.Text = "" And Not transtransaction.Text = "" And Not transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.transtype='" & transtransaction.Text & "' and b.costhead='" & transactioncosthead.Text & "' and a.TRANSDATE between '" & transadate.Text & "' and '" & todate.Text & "'"
            countsearch = "" & count & "  where a.transtype='" & transtransaction.Text & "' and b.costhead='" & transactioncosthead.Text & "' and a.TRANSDATE between '" & transadate.Text & "' and '" & todate.Text & "'"
            sql.searchtransaction(search, countsearch)
        ElseIf tomydate.Checked = True And transreference.Text = "" And transtransaction.Text = "" And transactioncosthead.Text = "" Then
            search = "select " & selection & " where a.TRANSDATE between '" & transadate.Text & "' and '" & todate.Text & "'"
            countsearch = "" & count & "  where a.TRANSDATE between '" & transadate.Text & "' and '" & todate.Text & "'"
            sql.searchtransaction(search, countsearch)
        End If
    End Sub

    Private Sub transgridview_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles transgridview.RowPostPaint
        Dim grid As DataGridView = DirectCast(sender, DataGridView)
        e.PaintHeader(DataGridViewPaintParts.Background)
        Dim rowIdx As String = (e.RowIndex + 1).ToString()
        Dim rowFont As New System.Drawing.Font("Microsoft Sans Serif", 8.0!,
            System.Drawing.FontStyle.Regular,
            System.Drawing.GraphicsUnit.Point, CType(0, Byte))

        Dim centerFormat = New StringFormat()
        centerFormat.Alignment = StringAlignment.Far
        centerFormat.LineAlignment = StringAlignment.Near

        Dim headerBounds As Rectangle = New Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height)

        e.Graphics.DrawString(rowIdx, rowFont, SystemBrushes.ControlText, headerBounds, centerFormat)
    End Sub

    Private Sub KryptonButton10_Click(sender As Object, e As EventArgs) Handles KryptonButton10.Click
        sql.loadtransactions(toprows.Text)
    End Sub

    Private Sub issueaccount_MouseDown(sender As Object, e As MouseEventArgs) Handles issueaccount.MouseDown
        sql.loadaccount()
    End Sub

    Private Sub transgridview_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles transgridview.CellDoubleClick
        If transgridview.RowCount >= 0 And e.RowIndex >= 0 Then
            Form5.itcame.Text = ""
            sql.selecttransrec(Form5.transno.Text)
            sql.selectreference(Form5.stockno.Text, Form5.reference.Text)
            Form5.ShowDialog()
        End If
    End Sub

    Private Sub transgridview_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles transgridview.CellClick
        If transgridview.RowCount >= 0 And e.RowIndex >= 0 Then
            Form5.transno.Text = transgridview.Item(0, e.RowIndex).Value.ToString
            Form5.stockno.Text = transgridview.Item(1, e.RowIndex).Value.ToString
            Form5.reference.Text = transgridview.Item(10, e.RowIndex).Value.ToString
            Form5.XYZ.Text = transgridview.Item(13, e.RowIndex).Value.ToString
            description.Text = transgridview.Item(5, e.RowIndex).Value.ToString

            cuttinglist.transno.Text = transgridview.Item(0, e.RowIndex).Value.ToString
            cuttinglist.remarks.Text = transgridview.Item(14, e.RowIndex).Value.ToString
        End If
    End Sub

    Private Sub transgridview_MouseDown(sender As Object, e As MouseEventArgs) Handles transgridview.MouseDown
        If e.Button = MouseButtons.Right Then
            transactionmenustrip.Show(transgridview, New Point(e.X, e.Y))
        End If
    End Sub

    Private Sub transgridview_SelectionChanged(sender As Object, e As EventArgs) Handles transgridview.SelectionChanged
        Dim selecteditem As DataGridViewSelectedRowCollection = transgridview.SelectedRows
        Form6.transno.Items.Clear()
        For Each item As DataGridViewRow In selecteditem
            Dim x As String = item.Cells("transno").Value.ToString
            Form6.transno.Items.Add(x)
        Next
    End Sub

    Private Sub TransDateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransDateToolStripMenuItem.Click
        Form6.KryptonLabel1.Text = "Edit Trans date"
        Form6.ShowDialog()
    End Sub

    Private Sub DueDateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DueDateToolStripMenuItem.Click
        Form6.KryptonLabel1.Text = "Edit Due date"
        Form6.ShowDialog()
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 1 Or TabControl1.SelectedIndex = 2 Or TabControl1.SelectedIndex = 3 Or TabControl1.SelectedIndex = 5 Then
            description.Clear()
            location.Clear()
        ElseIf TabControl1.SelectedIndex = 0 Then
            description.Visible = True
            location.Visible = True
            KryptonLabel4.Visible = True
            KryptonLabel5.Visible = True
        ElseIf TabControl1.SelectedIndex = 4 Then
            description.Visible = True
            location.Visible = False
            KryptonLabel4.Visible = True
            KryptonLabel5.Visible = False
        End If
        If TabControl1.SelectedIndex = 2 Then
            Dim x As Integer = receiptreference.SelectedIndex
            sql.referencereceipt()
            If x > receiptreference.Items.Count - 1 Then
                receiptreference.SelectedIndex = -1
            Else
                receiptreference.SelectedIndex = x
            End If
        ElseIf TabControl1.SelectedIndex = 3 Then
            Dim x As Integer = issuereference.SelectedIndex
            sql.referenceissue()
            If x > issuereference.Items.Count - 1 Then
                issuereference.SelectedIndex = -1
            Else
                issuereference.SelectedIndex = x
            End If
        End If
    End Sub

    Private Sub transaction_TextChanged(sender As Object, e As EventArgs) Handles transaction.TextChanged
        If transaction.Text = "Issue" Or transaction.Text = "Return" Or transaction.Text = "Spare" Or transaction.Text = "Supply" Or
            transaction.Text = "+Adjustment" Or transaction.Text = "-Adjustment" Then
            KryptonLabel17.Visible = True
            controlno.Visible = True
            KryptonLabel16.Visible = True
            account.Visible = True
            KryptonLabel49.Visible = True
            currentallocation.Visible = True
            KryptonLabel50.Visible = True
            remarks.Visible = True
        Else
            KryptonLabel17.Visible = False
            controlno.Visible = False
            controlno.Text = ""
            KryptonLabel16.Visible = False
            account.Visible = False
            account.Text = ""
            KryptonLabel49.Visible = False
            currentallocation.Visible = False
            currentallocation.Text = 0
            KryptonLabel50.Visible = False
            remarks.Visible = False
            remarks.Text = ""
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        KryptonLabel44.Text = TimeOfDay
    End Sub

    Private Sub referenceDataGridView_SelectionChanged(sender As Object, e As EventArgs) Handles referenceDataGridView.SelectionChanged
        refcombo.Items.Clear()
        refstock.Items.Clear()
        Dim selecteditems As DataGridViewSelectedRowCollection = referenceDataGridView.SelectedRows
        Dim x As String
        Dim y As String
        For Each selecteditem As DataGridViewRow In selecteditems
            x = selecteditem.Cells("reference").Value.ToString
            y = selecteditem.Cells("stockno").Value.ToString
            refcombo.Items.Add(x)
            refstock.Items.Add(y)
        Next

    End Sub

    Private Sub KryptonButton13_Click(sender As Object, e As EventArgs) Handles KryptonButton13.Click
        sql.referencetb()
    End Sub

    Private Sub KryptonButton14_Click(sender As Object, e As EventArgs) Handles KryptonButton14.Click
        If MessageBox.Show("Do you want to delete this record", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            MessageBox.Show("Operation Cancelled", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        For i As Integer = 0 To refcombo.Items.Count - 1
            Dim str As String = refcombo.Items(i).ToString
            Dim stockno As String = refstock.Items(i).ToString
            sql.removefromref(str, stockno)
        Next
        KryptonButton12.PerformClick()
    End Sub

    Private Sub KryptonButton12_Click(sender As Object, e As EventArgs) Handles KryptonButton12.Click
        Dim where As String = ""
        Dim a As String = reffromreference.Text
        Dim b As String = referencecosthead.Text
        Dim c As String = referencetypecolor.Text
        Dim d As String = referencearticleno.Text
        'a
        If Not a = "" And b = "" And c = "" And d = "" Then
            where = "where a.reference='" & a & "'"
        ElseIf Not a = "" And Not b = "" And c = "" And d = "" Then
            where = "where a.reference='" & a & "' and b.costhead='" & b & "'"
        ElseIf Not a = "" And b = "" And Not c = "" And d = "" Then
            where = "where a.reference='" & a & "' and b.typecolor='" & c & "'"
        ElseIf Not a = "" And b = "" And c = "" And Not d = "" Then
            where = "where a.reference='" & a & "' and b.articleno='" & d & "'"
            'b
        ElseIf a = "" And Not b = "" And c = "" And d = "" Then
            where = "where b.costhead='" & b & "'"
        ElseIf a = "" And Not b = "" And Not c = "" And d = "" Then
            where = "where b.costhead='" & b & "' and b.typecolor='" & c & "'"
        ElseIf a = "" And Not b = "" And c = "" And Not d = "" Then
            where = "where b.costhead='" & b & "' and b.articleno='" & d & "'"
            'c
        ElseIf a = "" And b = "" And Not c = "" And d = "" Then
            where = "where b.typecolor='" & c & "'"
        ElseIf a = "" And b = "" And Not c = "" And Not d = "" Then
            where = "where b.typecolor='" & c & "' and b.articleno='" & d & "'"
            'd
        ElseIf a = "" And b = "" And c = "" And Not d = "" Then
            where = "where b.articleno='" & d & "'"
            'triple
        ElseIf Not a = "" And Not b = "" And Not c = "" And d = "" Then
            where = "where a.reference='" & a & "' and b.costhead='" & b & "' and b.typecolor='" & c & "'"
        ElseIf Not a = "" And Not b = "" And c = "" And Not d = "" Then
            where = "where a.reference='" & a & "' and b.costhead='" & b & "' and b.articleno='" & d & "'"
        ElseIf Not a = "" And b = "" And Not c = "" And Not d = "" Then
            where = "where a.reference='" & a & "' and b.typecolor='" & c & "' and b.articleno='" & d & "'"
        ElseIf a = "" And Not b = "" And Not c = "" And Not d = "" Then
            where = "where b.costhead='" & b & "' and b.typecolor='" & c & "' and b.articleno='" & d & "'"
            'quadro
        ElseIf Not a = "" And Not b = "" And Not c = "" And Not d = "" Then
            where = "where a.reference='" & a & "' and b.costhead='" & b & "' and b.typecolor='" & c & "' and b.articleno='" & d & "'"
        ElseIf a = "" And b = "" And c = "" And d = "" Then
            where = ""
        End If
        sql.refsearch(where)
    End Sub

    Private Sub notification_Click(sender As Object, e As EventArgs) Handles notification.Click
        sql.sqlcon.Open()
        sql.notifycritical()
        sql.sqlcon.Close()

        If Not notification.Text = "Notification" Then
            NotiForm.Show()
            NotiForm.MdiParent = Form1
            notification.StateCommon.Content.ShortText.Color1 = Color.Black
            notification.Enabled = False
        Else
            MessageBox.Show("0 Result Found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub stocksgridview_MouseDown(sender As Object, e As MouseEventArgs) Handles stocksgridview.MouseDown
        If stocksgridview.RowCount >= 0 Then
            If e.Button = MouseButtons.Right Then
                PhasedoutForm.ShowDialog()
            End If
        End If
    End Sub

    Private Sub stocksgridview_SelectionChanged(sender As Object, e As EventArgs) Handles stocksgridview.SelectionChanged
        stocksStocksno.Items.Clear()
        Dim x As String = ""
        Dim selecteditems As DataGridViewSelectedRowCollection = stocksgridview.SelectedRows
        For Each selecteditem As DataGridViewRow In selecteditems
            x = selecteditem.Cells("stockno").Value.ToString
            stocksStocksno.Items.Add(x)
        Next
    End Sub

    Private Sub costheadsearch_MouseDown(sender As Object, e As MouseEventArgs) Handles costheadsearch.MouseDown
        Dim x As Integer = costheadsearch.SelectedIndex
        Dim ssupplier As String = supplier.Text
        If ssupplier = "" Then
            ssupplier = " supplier"
        Else
            ssupplier = "'" & ssupplier & "'"
        End If
        sql.loadcostheadsearch(ssupplier)
        typecolorsearch.Text = ""
        articlenosearch.Text = ""
        If x > costheadsearch.Items.Count - 1 Then
            costheadsearch.SelectedIndex = -1
        Else
            costheadsearch.SelectedIndex = x
        End If

    End Sub

    Private Sub typecolorsearch_MouseDown(sender As Object, e As MouseEventArgs) Handles typecolorsearch.MouseDown
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
        sql.loadtypecolorsearch(ssupplier, scosthead)
        articlenosearch.Text = ""
        If x > typecolorsearch.Items.Count - 1 Then
            typecolorsearch.SelectedIndex = -1
        Else
            typecolorsearch.SelectedIndex = x
        End If
    End Sub

    Private Sub articlenosearch_MouseDown(sender As Object, e As MouseEventArgs) Handles articlenosearch.MouseDown
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
        sql.loadarticlesearch(ssupplier, scosthead, stypecolor)

        If x > articlenosearch.Items.Count - 1 Then
            articlenosearch.SelectedIndex = -1
        Else
            articlenosearch.SelectedIndex = x
        End If

    End Sub

    Private Sub KryptonButton1_Click(sender As Object, e As EventArgs) Handles KryptonButton1.Click
        'Dim phasedout As String
        'If phasedoutsearch.Checked = True Then
        '    phasedout = "yes"
        'Else
        '    phasedout = ""
        'End If

        'Dim search As String = ""
        'Dim fields As String = ""
        'If Not costheadsearch.Text = "" And typecolorsearch.Text = "" And articlenosearch.Text = "" And status.Text = "" Then
        '    fields = "costhead ='" & costheadsearch.Text & "' and phasedout = '" & phasedout & "'"
        'ElseIf Not costheadsearch.Text = "" And Not typecolorsearch.Text = "" And articlenosearch.Text = "" And status.Text = "" Then
        '    fields = "costhead ='" & costheadsearch.Text & "' and typecolor='" & typecolorsearch.Text & "' and phasedout = '" & phasedout & "'"
        'ElseIf Not costheadsearch.Text = "" And typecolorsearch.Text = "" And Not articlenosearch.Text = "" And status.Text = "" Then
        '    fields = "costhead ='" & costheadsearch.Text & "' and articleno='" & articlenosearch.Text & "' and phasedout = '" & phasedout & "'"
        'ElseIf Not costheadsearch.Text = "" And typecolorsearch.Text = "" And articlenosearch.Text = "" And Not status.Text = "" Then
        '    fields = "costhead ='" & costheadsearch.Text & "' and articleno='" & status.Text & "' and phasedout = '" & phasedout & "'"
        'ElseIf costheadsearch.Text = "" And Not typecolorsearch.Text = "" And articlenosearch.Text = "" And status.Text = "" Then
        '    fields = "typecolor ='" & typecolorsearch.Text & "' and phasedout = '" & phasedout & "'"
        'ElseIf costheadsearch.Text = "" And Not typecolorsearch.Text = "" And Not articlenosearch.Text = "" And status.Text = "" Then
        '    fields = "typecolor ='" & typecolorsearch.Text & "' and articleno = '" & articlenosearch.Text & "' and phasedout = '" & phasedout & "'"
        'ElseIf costheadsearch.Text = "" And Not typecolorsearch.Text = "" And articlenosearch.Text = "" And Not status.Text = "" Then
        '    fields = "typecolor ='" & typecolorsearch.Text & "' and status = '" & status.Text & "' and phasedout = '" & phasedout & "'"
        'ElseIf costheadsearch.Text = "" And typecolorsearch.Text = "" And Not articlenosearch.Text = "" And status.Text = "" Then
        '    fields = "articleno ='" & articlenosearch.Text & "'  and phasedout = '" & phasedout & "'"
        'ElseIf costheadsearch.Text = "" And typecolorsearch.Text = "" And Not articlenosearch.Text = "" And Not status.Text = "" Then
        '    fields = "articleno ='" & articlenosearch.Text & "' and status = '" & status.Text & "' and phasedout = '" & phasedout & "'"
        'ElseIf costheadsearch.Text = "" And typecolorsearch.Text = "" And articlenosearch.Text = "" And Not status.Text = "" Then
        '    fields = "status = '" & status.Text & "' and phasedout = '" & phasedout & "'"
        'ElseIf Not costheadsearch.Text = "" And Not typecolorsearch.Text = "" And Not articlenosearch.Text = "" And status.Text = "" Then
        '    fields = "costhead = '" & costheadsearch.Text & "' and typecolor='" & typecolorsearch.Text & "' and articleno='" & articlenosearch.Text & "' and phasedout = '" & phasedout & "'"
        'ElseIf Not costheadsearch.Text = "" And typecolorsearch.Text = "" And Not articlenosearch.Text = "" And Not status.Text = "" Then
        '    fields = "costhead = '" & costheadsearch.Text & "' and articleno='" & articlenosearch.Text & "' and status='" & status.Text & "' and phasedout = '" & phasedout & "'"
        'ElseIf Not costheadsearch.Text = "" And Not typecolorsearch.Text = "" And articlenosearch.Text = "" And Not status.Text = "" Then
        '    fields = "costhead = '" & costheadsearch.Text & "' and typecolor='" & typecolorsearch.Text & "' and status='" & status.Text & "' and phasedout = '" & phasedout & "'"
        'ElseIf costheadsearch.Text = "" And Not typecolorsearch.Text = "" And Not articlenosearch.Text = "" And Not status.Text = "" Then
        '    fields = "typecolor='" & typecolorsearch.Text & "' and articleno = '" & articlenosearch.Text & "' and status='" & status.Text & "' and phasedout = '" & phasedout & "'"
        'ElseIf Not costheadsearch.Text = "" And Not typecolorsearch.Text = "" And Not articlenosearch.Text = "" And Not status.Text = "" Then
        '    fields = "costhead = '" & costheadsearch.Text & "' and typecolor='" & typecolorsearch.Text & "' and articleno = '" & articlenosearch.Text & "' and status='" & status.Text & "' and phasedout = '" & phasedout & "'"
        'ElseIf costheadsearch.Text = "" And typecolorsearch.Text = "" And articlenosearch.Text = "" And status.Text = "" Then
        '    fields = " phasedout = '" & phasedout & "'"
        'End If
        'search = "select * from stocks_tb where " & fields & " order by articleno asc"
        'sql.searchstocks(search)

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
            gcol = " not phasedout"
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
            g = " phasedout"
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
        sql.searchstocks(search)

    End Sub

    Private Sub KryptonButton15_Click(sender As Object, e As EventArgs) Handles KryptonButton15.Click
        sql.loadstocks()
    End Sub

    Private Sub account_MouseDown(sender As Object, e As MouseEventArgs) Handles account.MouseDown
        sql.loadaccount()
    End Sub

    Private Sub referencecosthead_MouseDown(sender As Object, e As MouseEventArgs) Handles referencecosthead.MouseDown
        referencetypecolor.Text = ""
        referencearticleno.Text = ""
        findcostheadforref()
    End Sub
    Public Sub findcostheadforref()
        Try
            sql.sqlcon.Open()
            Dim ds As New DataSet
            ds.Clear()
            Dim da As New SqlDataAdapter
            Dim bs As New BindingSource
            Dim str As String = "select distinct costhead from STOCKS_TB where STOCKNO in (select stockno from reference_tb)"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "STOCKS_TB")
            bs.DataSource = ds
            bs.DataMember = "STOCKS_TB"
            referencecosthead.DataSource = bs
            referencecosthead.DisplayMember = "costhead"
            referencecosthead.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Private Sub referencetypecolor_MouseDown(sender As Object, e As MouseEventArgs) Handles referencetypecolor.MouseDown
        referencearticleno.Text = ""
        findtypecolorforref(referencecosthead.Text)
    End Sub
    Public Sub findtypecolorforref(ByVal costhead As String)
        Try
            sql.sqlcon.Open()
            Dim ds As New DataSet
            ds.Clear()
            Dim da As New SqlDataAdapter
            Dim bs As New BindingSource
            Dim str As String = "select distinct typecolor from STOCKS_TB where costhead= '" & costhead & "' and STOCKNO in (select stockno from reference_tb)"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "STOCKS_TB")
            bs.DataSource = ds
            bs.DataMember = "STOCKS_TB"
            referencetypecolor.DataSource = bs
            referencetypecolor.DisplayMember = "typecolor"
            referencetypecolor.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Private Sub referencearticleno_MouseDown(sender As Object, e As MouseEventArgs) Handles referencearticleno.MouseDown
        findarticlenoforref(referencecosthead.Text, referencetypecolor.Text)
    End Sub
    Public Sub findarticlenoforref(ByVal costhead As String, ByVal typecolor As String)
        Try
            sql.sqlcon.Open()
            Dim ds As New DataSet
            ds.Clear()
            Dim da As New SqlDataAdapter
            Dim bs As New BindingSource
            Dim str As String = "select distinct articleno from STOCKS_TB where costhead= '" & costhead & "' and typecolor='" & typecolor & "' and STOCKNO in (select stockno from reference_tb)"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "STOCKS_TB")
            bs.DataSource = ds
            bs.DataMember = "STOCKS_TB"
            referencearticleno.DataSource = bs
            referencearticleno.DisplayMember = "articleno"
            referencearticleno.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Private Sub KryptonButton16_Click(sender As Object, e As EventArgs) Handles KryptonButton16.Click
        sql.alltransaction()
        AllTrans.ShowDialog()
    End Sub

    Private Sub referenceDataGridView_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles referenceDataGridView.RowPostPaint
        Dim grid As DataGridView = DirectCast(sender, DataGridView)
        e.PaintHeader(DataGridViewPaintParts.Background)
        Dim rowIdx As String = (e.RowIndex + 1).ToString()
        Dim rowFont As New System.Drawing.Font("Microsoft Sans Serif", 8.0!,
            System.Drawing.FontStyle.Regular,
            System.Drawing.GraphicsUnit.Point, CType(0, Byte))

        Dim centerFormat = New StringFormat()
        centerFormat.Alignment = StringAlignment.Far
        centerFormat.LineAlignment = StringAlignment.Near

        Dim headerBounds As Rectangle = New Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height)

        e.Graphics.DrawString(rowIdx, rowFont, SystemBrushes.ControlText, headerBounds, centerFormat)
    End Sub

    Private Sub KryptonButton17_Click(sender As Object, e As EventArgs) Handles KryptonButton17.Click
        sql.loadstocks()
        sql.loadtransactions(toprows.Text)
        sql.referencetb()
    End Sub

    Private Sub KryptonButton18_Click(sender As Object, e As EventArgs) Handles KryptonButton18.Click
        sql.loaddummies()
        mydummyDataGridView1.SelectAll()
        If ir.Checked = True And scr.Checked = False Then
            Dim phasedout As String
            Dim toorder As String
            If reportpasedout.Checked = True Then
                phasedout = "yes"
            Else
                phasedout = ""
            End If
            If reporttoorder.Checked = True Then
                toorder = "yes"
            Else
                toorder = ""
            End If

            Dim str As String
            'If reportsupplier.Text = "" And reportstatus.Text = "" Then
            '    str = "select * from stocks_tb where phasedout = '" & phasedout & "' and toorder='" & toorder & "'"
            'ElseIf Not reportsupplier.Text = "" And Not reportstatus.Text = "" Then
            '    str = "select * from stocks_tb where supplier='" & reportsupplier.Text & "' and status= '" & reportstatus.Text & "' and phasedout = '" & phasedout & "'  and toorder='" & toorder & "'"
            'ElseIf reportsupplier.Text = "" And Not reportstatus.Text = "" Then
            '    str = "select * from stocks_tb where status= '" & reportstatus.Text & "' and phasedout = '" & phasedout & "'  and toorder='" & toorder & "'"
            'ElseIf Not reportsupplier.Text = "" And reportstatus.Text = "" Then
            '    str = "select * from stocks_tb where supplier='" & reportsupplier.Text & "' and phasedout = '" & phasedout & "'  and toorder='" & toorder & "'"
            'End If

            Dim a As String = reportsupplier.Text
            Dim b As String = reportheader.Text
            Dim c As String = reportcosthead.Text
            Dim d As String = reporttypecolor.Text
            Dim f As String = reportstatus.Text

            Dim acol As String = "supplier"
            Dim bcol As String = "header"
            Dim ccol As String = "costhead"
            Dim dcol As String = "typecolor"
            Dim fcol As String = "status"

            If a = "" And b = "" And c = "" And d = "" And f = "" Then
                str = "select * from stocks_tb where phasedout = '" & phasedout & "' and toorder='" & toorder & "'"
            ElseIf a = "" And b = "" And c = "" And d = "" And Not f = "" Then
                str = "select * from stocks_tb where " & fcol & "='" & f & "' and phasedout = '" & phasedout & "' and toorder='" & toorder & "'"
            ElseIf a = "" And b = "" And c = "" And Not d = "" And f = "" Then
                str = "select * from stocks_tb where " & dcol & "='" & d & "' and phasedout = '" & phasedout & "' and toorder='" & toorder & "'"
            ElseIf a = "" And b = "" And c = "" And Not d = "" And Not f = "" Then
                str = "select * from stocks_tb where " & dcol & "='" & d & "' and " & fcol & "='" & f & "' and phasedout = '" & phasedout & "' and toorder='" & toorder & "'"
            ElseIf a = "" And b = "" And Not c = "" And d = "" And f = "" Then
                str = "select * from stocks_tb where " & ccol & "='" & c & "' and phasedout = '" & phasedout & "' and toorder='" & toorder & "'"
            ElseIf a = "" And b = "" And Not c = "" And d = "" And Not f = "" Then
                str = "select * from stocks_tb where " & ccol & "='" & c & "' and " & fcol & "='" & f & "' and phasedout = '" & phasedout & "' and toorder='" & toorder & "'"
            ElseIf a = "" And b = "" And Not c = "" And Not d = "" And f = "" Then
                str = "select * from stocks_tb where " & ccol & "='" & c & "' and " & dcol & "='" & d & "' and phasedout = '" & phasedout & "' and toorder='" & toorder & "'"
            ElseIf a = "" And b = "" And Not c = "" And Not d = "" And Not f = "" Then
                str = "select * from stocks_tb where " & ccol & "='" & c & "' and " & dcol & "='" & d & "' and " & fcol & "='" & f & "' and phasedout = '" & phasedout & "' and toorder='" & toorder & "'"
            ElseIf a = "" And Not b = "" And c = "" And d = "" And f = "" Then
                str = "select * from stocks_tb where " & bcol & "='" & b & "' and phasedout = '" & phasedout & "' and toorder='" & toorder & "'"
            ElseIf a = "" And Not b = "" And c = "" And d = "" And Not f = "" Then
                str = "select * from stocks_tb where " & bcol & "='" & b & "' and " & fcol & "='" & f & "' and phasedout = '" & phasedout & "' and toorder='" & toorder & "'"
            ElseIf a = "" And Not b = "" And c = "" And Not d = "" And f = "" Then
                str = "select * from stocks_tb where " & bcol & "='" & b & "' and " & dcol & "='" & d & "' and phasedout = '" & phasedout & "' and toorder='" & toorder & "'"
            ElseIf a = "" And Not b = "" And c = "" And Not d = "" And Not f = "" Then
                str = "select * from stocks_tb where " & bcol & "='" & b & "' and " & dcol & "='" & d & "' and " & fcol & "='" & f & "' and phasedout = '" & phasedout & "' and toorder='" & toorder & "'"
            ElseIf a = "" And Not b = "" And Not c = "" And d = "" And f = "" Then
                str = "select * from stocks_tb where " & bcol & "='" & b & "' and " & ccol & "='" & c & "' and phasedout = '" & phasedout & "' and toorder='" & toorder & "'"
            ElseIf a = "" And Not b = "" And Not c = "" And d = "" And Not f = "" Then
                str = "select * from stocks_tb where " & bcol & "='" & b & "' and " & ccol & "='" & c & "' and " & fcol & "='" & f & "' and phasedout = '" & phasedout & "' and toorder='" & toorder & "'"
            ElseIf a = "" And Not b = "" And Not c = "" And Not d = "" And f = "" Then
                str = "select * from stocks_tb where " & bcol & "='" & b & "' and " & ccol & "='" & c & "' and " & dcol & "='" & d & "' and phasedout = '" & phasedout & "' and toorder='" & toorder & "'"
            ElseIf a = "" And Not b = "" And Not c = "" And Not d = "" And Not f = "" Then
                str = "select * from stocks_tb where " & bcol & "='" & b & "' and " & ccol & "='" & c & "' and " & dcol & "='" & d & "' and " & fcol & "='" & f & "' and phasedout = '" & phasedout & "' and toorder='" & toorder & "'"
            ElseIf Not a = "" And b = "" And c = "" And d = "" And f = "" Then
                str = "select * from stocks_tb where " & acol & "='" & a & "' and phasedout = '" & phasedout & "' and toorder='" & toorder & "'"
            ElseIf Not a = "" And b = "" And c = "" And d = "" And Not f = "" Then
                str = "select * from stocks_tb where " & acol & "='" & a & "' and " & fcol & "='" & f & "' and phasedout = '" & phasedout & "' and toorder='" & toorder & "'"
            ElseIf Not a = "" And b = "" And c = "" And Not d = "" And f = "" Then
                str = "select * from stocks_tb where " & acol & "='" & a & "' and " & dcol & "='" & d & "' and phasedout = '" & phasedout & "' and toorder='" & toorder & "'"
            ElseIf Not a = "" And b = "" And c = "" And Not d = "" And Not f = "" Then
                str = "select * from stocks_tb where " & acol & "='" & a & "' and " & dcol & "='" & d & "' and " & fcol & "='" & f & "' and phasedout = '" & phasedout & "' and toorder='" & toorder & "'"
            ElseIf Not a = "" And b = "" And Not c = "" And d = "" And f = "" Then
                str = "select * from stocks_tb where " & acol & "='" & a & "' and " & ccol & "='" & c & "' and phasedout = '" & phasedout & "' and toorder='" & toorder & "'"
            ElseIf Not a = "" And b = "" And Not c = "" And d = "" And Not f = "" Then
                str = "select * from stocks_tb where " & acol & "='" & a & "' and " & ccol & "='" & c & "' and " & fcol & "='" & f & "' and phasedout = '" & phasedout & "' and toorder='" & toorder & "'"
            ElseIf Not a = "" And b = "" And Not c = "" And Not d = "" And f = "" Then
                str = "select * from stocks_tb where " & acol & "='" & a & "' and " & ccol & "='" & c & "' and " & dcol & "='" & d & "' and phasedout = '" & phasedout & "' and toorder='" & toorder & "'"
            ElseIf Not a = "" And b = "" And Not c = "" And Not d = "" And Not f = "" Then
                str = "select * from stocks_tb where " & acol & "='" & a & "' and " & ccol & "='" & c & "' and " & dcol & "='" & d & "' and " & fcol & "='" & f & "' and phasedout = '" & phasedout & "' and toorder='" & toorder & "'"
            ElseIf Not a = "" And Not b = "" And c = "" And d = "" And f = "" Then
                str = "select * from stocks_tb where " & acol & "='" & a & "' and " & bcol & "='" & b & "' and phasedout = '" & phasedout & "' and toorder='" & toorder & "'"
            ElseIf Not a = "" And Not b = "" And c = "" And d = "" And Not f = "" Then
                str = "select * from stocks_tb where " & acol & "='" & a & "' and " & bcol & "='" & b & "' and " & fcol & "='" & f & "' and phasedout = '" & phasedout & "' and toorder='" & toorder & "'"
            ElseIf Not a = "" And Not b = "" And c = "" And Not d = "" And f = "" Then
                str = "select * from stocks_tb where " & acol & "='" & a & "' and " & bcol & "='" & b & "' and " & dcol & "='" & d & "' and phasedout = '" & phasedout & "' and toorder='" & toorder & "'"
            ElseIf Not a = "" And Not b = "" And c = "" And Not d = "" And Not f = "" Then
                str = "select * from stocks_tb where " & acol & "='" & a & "' and " & bcol & "='" & b & "' and " & dcol & "='" & d & "' and " & fcol & "='" & f & "' and phasedout = '" & phasedout & "' and toorder='" & toorder & "'"
            ElseIf Not a = "" And Not b = "" And Not c = "" And d = "" And f = "" Then
                str = "select * from stocks_tb where " & acol & "='" & a & "' and " & bcol & "='" & b & "' and " & ccol & "='" & c & "' and phasedout = '" & phasedout & "' and toorder='" & toorder & "'"
            ElseIf Not a = "" And Not b = "" And Not c = "" And d = "" And Not f = "" Then
                str = "select * from stocks_tb where " & acol & "='" & a & "' and " & bcol & "='" & b & "' and " & ccol & "='" & c & "' and " & fcol & "='" & f & "' and phasedout = '" & phasedout & "' and toorder='" & toorder & "'"
            ElseIf Not a = "" And Not b = "" And Not c = "" And Not d = "" And f = "" Then
                str = "select * from stocks_tb where " & acol & "='" & a & "' and " & bcol & "='" & b & "' and " & ccol & "='" & c & "' and " & dcol & "='" & d & "' and phasedout = '" & phasedout & "' and toorder='" & toorder & "'"
            ElseIf Not a = "" And Not b = "" And Not c = "" And Not d = "" And Not f = "" Then
                str = "select * from stocks_tb where " & acol & "='" & a & "' and " & bcol & "='" & b & "' and " & ccol & "='" & c & "' and " & dcol & "='" & d & "' and " & fcol & "='" & f & "' and phasedout = '" & phasedout & "' and toorder='" & toorder & "'"
            End If

            sql.reporting(str)
            Form8.ShowDialog()
        ElseIf ir.Checked = False And scr.Checked = True Then
            Dim parReportParam1 As New ReportParameter("buffermonth", Me.mymonth.Text)
            Form7.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {parReportParam1})
            Dim updateneedtoorder As String = "
declare @buffmonth as decimal(10,2) = '" & mymonth.Text & "'
update
a
set a.needtoorder=((((@buffmonth)*(b.CONSUMPTION/12))+(a.allocation+a.minimum))-(a.physical+a.stockorder))
from STOCKS_TB as a
inner join CONSUMPTIONTB as b
on a.stockno=b.stockno where B.MYYEAR = '" & myyear.Text & "'"




            Dim str As String = "select 
a.STOCKNO,
a.SUPPLIER,
a.COSTHEAD,
a.UFACTOR,
a.TYPECOLOR,
a.MONETARY,
a.ARTICLENO,
a.UNITPRICE,
a.DESCRIPTION,
a.QTY,
a.UNIT,
a.LOCATION,
a.HEADER,
a.PHYSICAL,
a.ALLOCATION,
a.FREE,
a.STOCKORDER,
a.MINIMUM,
a.ISSUE,
a.AVEUSAGE,
a.STATUS,
a.PHASEDOUT,
a.COLORBASED,
a.needtoorder,
A.FINALNEEDTOORDER,
b.STOCKNO,
b.CONSUMPTION,
b.MYYEAR
from STOCKS_TB AS a
inner join CONSUMPTIONTB as b
on a.stockno = b.stockno where b.myyear='" & myyear.Text & "'"


            Dim phasedout As String
            If reportpasedout.Checked = True Then
                phasedout = "yes"
            Else
                phasedout = ""
            End If
            Dim toorder As String
            If reporttoorder.Checked = True Then
                toorder = "yes"
            Else
                toorder = ""
            End If

            Dim condition As String
            Dim a As String = reportsupplier.Text
            Dim b As String = reportheader.Text
            Dim c As String = reportcosthead.Text
            Dim d As String = reporttypecolor.Text
            Dim f As String = reportstatus.Text

            Dim acol As String = "a.supplier"
            Dim bcol As String = "a.header"
            Dim ccol As String = "a.costhead"
            Dim dcol As String = "a.typecolor"
            Dim fcol As String = "a.status"



            'If reportsupplier.Text = "" And reportstatus.Text = "" Then
            '    condition = "" & str & " and a.phasedout = '" & phasedout & "' and a.toorder='" & toorder & "' order by a.articleno asc"
            'ElseIf Not reportsupplier.Text = "" And Not reportstatus.Text = "" Then
            '    condition = "" & str & " and a.supplier='" & reportsupplier.Text & "' and a.status= '" & reportstatus.Text & "' and a.phasedout = '" & phasedout & "'  and a.toorder='" & toorder & "' order by a.articleno asc"
            'ElseIf reportsupplier.Text = "" And Not reportstatus.Text = "" Then
            '    condition = "" & str & " and a.status= '" & reportstatus.Text & "' and a.phasedout = '" & phasedout & "'  and a.toorder='" & toorder & "' order by a.articleno asc"
            'ElseIf Not reportsupplier.Text = "" And reportstatus.Text = "" Then
            '    condition = "" & str & " and a.supplier='" & reportsupplier.Text & "' and a.phasedout = '" & phasedout & "'  and a.toorder='" & toorder & "' order by a.articleno asc"
            'End If

            If a = "" And b = "" And c = "" And d = "" And f = "" Then
                condition = "" & str & " and a.phasedout = '" & phasedout & "' and a.toorder='" & toorder & "' order by a.articleno asc"
            ElseIf a = "" And b = "" And c = "" And d = "" And Not f = "" Then
                condition = "" & str & " and " & fcol & "='" & f & "' and a.phasedout = '" & phasedout & "' and a.toorder='" & toorder & "' order by a.articleno asc"
            ElseIf a = "" And b = "" And c = "" And Not d = "" And f = "" Then
                condition = "" & str & " and " & dcol & "='" & d & "' and a.phasedout = '" & phasedout & "' and a.toorder='" & toorder & "' order by a.articleno asc"
            ElseIf a = "" And b = "" And c = "" And Not d = "" And Not f = "" Then
                condition = "" & str & " and " & dcol & "='" & d & "' and " & fcol & "='" & f & "' and a.phasedout = '" & phasedout & "' and a.toorder='" & toorder & "' order by a.articleno asc"
            ElseIf a = "" And b = "" And Not c = "" And d = "" And f = "" Then
                condition = "" & str & " and " & ccol & "='" & c & "' and a.phasedout = '" & phasedout & "' and a.toorder='" & toorder & "' order by a.articleno asc"
            ElseIf a = "" And b = "" And Not c = "" And d = "" And Not f = "" Then
                condition = "" & str & " and " & ccol & "='" & c & "' and " & fcol & "='" & f & "' and a.phasedout = '" & phasedout & "' and a.toorder='" & toorder & "' order by a.articleno asc"
            ElseIf a = "" And b = "" And Not c = "" And Not d = "" And f = "" Then
                condition = "" & str & " and " & ccol & "='" & c & "' and " & dcol & "='" & d & "' and a.phasedout = '" & phasedout & "' and a.toorder='" & toorder & "' order by a.articleno asc"
            ElseIf a = "" And b = "" And Not c = "" And Not d = "" And Not f = "" Then
                condition = "" & str & " and " & ccol & "='" & c & "' and " & dcol & "='" & d & "' and " & fcol & "='" & f & "' and a.phasedout = '" & phasedout & "' and a.toorder='" & toorder & "' order by a.articleno asc"
            ElseIf a = "" And Not b = "" And c = "" And d = "" And f = "" Then
                condition = "" & str & " and " & bcol & "='" & b & "' and a.phasedout = '" & phasedout & "' and a.toorder='" & toorder & "' order by a.articleno asc"
            ElseIf a = "" And Not b = "" And c = "" And d = "" And Not f = "" Then
                condition = "" & str & " and " & bcol & "='" & b & "' and " & fcol & "='" & f & "' and a.phasedout = '" & phasedout & "' and a.toorder='" & toorder & "' order by a.articleno asc"
            ElseIf a = "" And Not b = "" And c = "" And Not d = "" And f = "" Then
                condition = "" & str & " and " & bcol & "='" & b & "' and " & dcol & "='" & d & "' and a.phasedout = '" & phasedout & "' and a.toorder='" & toorder & "' order by a.articleno asc"
            ElseIf a = "" And Not b = "" And c = "" And Not d = "" And Not f = "" Then
                condition = "" & str & " and " & bcol & "='" & b & "' and " & dcol & "='" & d & "' and " & fcol & "='" & f & "' and a.phasedout = '" & phasedout & "' and a.toorder='" & toorder & "' order by a.articleno asc"
            ElseIf a = "" And Not b = "" And Not c = "" And d = "" And f = "" Then
                condition = "" & str & " and " & bcol & "='" & b & "' and " & ccol & "='" & c & "' and a.phasedout = '" & phasedout & "' and a.toorder='" & toorder & "' order by a.articleno asc"
            ElseIf a = "" And Not b = "" And Not c = "" And d = "" And Not f = "" Then
                condition = "" & str & " and " & bcol & "='" & b & "' and " & ccol & "='" & c & "' and " & fcol & "='" & f & "' and a.phasedout = '" & phasedout & "' and a.toorder='" & toorder & "' order by a.articleno asc"
            ElseIf a = "" And Not b = "" And Not c = "" And Not d = "" And f = "" Then
                condition = "" & str & " and " & bcol & "='" & b & "' and " & ccol & "='" & c & "' and " & dcol & "='" & d & "' and a.phasedout = '" & phasedout & "' and a.toorder='" & toorder & "' order by a.articleno asc"
            ElseIf a = "" And Not b = "" And Not c = "" And Not d = "" And Not f = "" Then
                condition = "" & str & " and " & bcol & "='" & b & "' and " & ccol & "='" & c & "' and " & dcol & "='" & d & "' and " & fcol & "='" & f & "' and a.phasedout = '" & phasedout & "' and a.toorder='" & toorder & "' order by a.articleno asc"
            ElseIf Not a = "" And b = "" And c = "" And d = "" And f = "" Then
                condition = "" & str & " and " & acol & "='" & a & "' and a.phasedout = '" & phasedout & "' and a.toorder='" & toorder & "' order by a.articleno asc"
            ElseIf Not a = "" And b = "" And c = "" And d = "" And Not f = "" Then
                condition = "" & str & " and " & acol & "='" & a & "' and " & fcol & "='" & f & "' and a.phasedout = '" & phasedout & "' and a.toorder='" & toorder & "' order by a.articleno asc"
            ElseIf Not a = "" And b = "" And c = "" And Not d = "" And f = "" Then
                condition = "" & str & " and " & acol & "='" & a & "' and " & dcol & "='" & d & "' and a.phasedout = '" & phasedout & "' and a.toorder='" & toorder & "' order by a.articleno asc"
            ElseIf Not a = "" And b = "" And c = "" And Not d = "" And Not f = "" Then
                condition = "" & str & " and " & acol & "='" & a & "' and " & dcol & "='" & d & "' and " & fcol & "='" & f & "' and a.phasedout = '" & phasedout & "' and a.toorder='" & toorder & "' order by a.articleno asc"
            ElseIf Not a = "" And b = "" And Not c = "" And d = "" And f = "" Then
                condition = "" & str & " and " & acol & "='" & a & "' and " & ccol & "='" & c & "' and a.phasedout = '" & phasedout & "' and a.toorder='" & toorder & "' order by a.articleno asc"
            ElseIf Not a = "" And b = "" And Not c = "" And d = "" And Not f = "" Then
                condition = "" & str & " and " & acol & "='" & a & "' and " & ccol & "='" & c & "' and " & fcol & "='" & f & "' and a.phasedout = '" & phasedout & "' and a.toorder='" & toorder & "' order by a.articleno asc"
            ElseIf Not a = "" And b = "" And Not c = "" And Not d = "" And f = "" Then
                condition = "" & str & " and " & acol & "='" & a & "' and " & ccol & "='" & c & "' and " & dcol & "='" & d & "' and a.phasedout = '" & phasedout & "' and a.toorder='" & toorder & "' order by a.articleno asc"
            ElseIf Not a = "" And b = "" And Not c = "" And Not d = "" And Not f = "" Then
                condition = "" & str & " and " & acol & "='" & a & "' and " & ccol & "='" & c & "' and " & dcol & "='" & d & "' and " & fcol & "='" & f & "' and a.phasedout = '" & phasedout & "' and a.toorder='" & toorder & "' order by a.articleno asc"
            ElseIf Not a = "" And Not b = "" And c = "" And d = "" And f = "" Then
                condition = "" & str & " and " & acol & "='" & a & "' and " & bcol & "='" & b & "' and a.phasedout = '" & phasedout & "' and a.toorder='" & toorder & "' order by a.articleno asc"
            ElseIf Not a = "" And Not b = "" And c = "" And d = "" And Not f = "" Then
                condition = "" & str & " and " & acol & "='" & a & "' and " & bcol & "='" & b & "' and " & fcol & "='" & f & "' and a.phasedout = '" & phasedout & "' and a.toorder='" & toorder & "' order by a.articleno asc"
            ElseIf Not a = "" And Not b = "" And c = "" And Not d = "" And f = "" Then
                condition = "" & str & " and " & acol & "='" & a & "' and " & bcol & "='" & b & "' and " & dcol & "='" & d & "' and a.phasedout = '" & phasedout & "' and a.toorder='" & toorder & "' order by a.articleno asc"
            ElseIf Not a = "" And Not b = "" And c = "" And Not d = "" And Not f = "" Then
                condition = "" & str & " and " & acol & "='" & a & "' and " & bcol & "='" & b & "' and " & dcol & "='" & d & "' and " & fcol & "='" & f & "' and a.phasedout = '" & phasedout & "' and a.toorder='" & toorder & "' order by a.articleno asc"
            ElseIf Not a = "" And Not b = "" And Not c = "" And d = "" And f = "" Then
                condition = "" & str & " and " & acol & "='" & a & "' and " & bcol & "='" & b & "' and " & ccol & "='" & c & "' and a.phasedout = '" & phasedout & "' and a.toorder='" & toorder & "' order by a.articleno asc"
            ElseIf Not a = "" And Not b = "" And Not c = "" And d = "" And Not f = "" Then
                condition = "" & str & " and " & acol & "='" & a & "' and " & bcol & "='" & b & "' and " & ccol & "='" & c & "' and " & fcol & "='" & f & "' and a.phasedout = '" & phasedout & "' and a.toorder='" & toorder & "' order by a.articleno asc"
            ElseIf Not a = "" And Not b = "" And Not c = "" And Not d = "" And f = "" Then
                condition = "" & str & " and " & acol & "='" & a & "' and " & bcol & "='" & b & "' and " & ccol & "='" & c & "' and " & dcol & "='" & d & "' and a.phasedout = '" & phasedout & "' and a.toorder='" & toorder & "' order by a.articleno asc"
            ElseIf Not a = "" And Not b = "" And Not c = "" And Not d = "" And Not f = "" Then
                condition = "" & str & " and " & acol & "='" & a & "' and " & bcol & "='" & b & "' and " & ccol & "='" & c & "' and " & dcol & "='" & d & "' and " & fcol & "='" & f & "' and a.phasedout = '" & phasedout & "' and a.toorder='" & toorder & "' order by a.articleno asc"
            End If


            sql.anualreporting(condition, updateneedtoorder)
            Form7.ShowDialog()
        End If
    End Sub



    Private Sub KryptonButton19_Click(sender As Object, e As EventArgs) Handles KryptonButton19.Click
        sql.loaddummies()
        mydummyDataGridView1.SelectAll()
        ProgressBar1.Visible = True
        ProgressBar1.Maximum = mydummycombobox.Items.Count
        ProgressBar1.Value = 0
        For i As Integer = 0 To mydummycombobox.Items.Count - 1
            Dim stockno As String = mydummycombobox.Items(i).ToString
            sql.calculateanualconsumption(stockno, myyear.Text)
            ProgressBar1.Value += 1
        Next
        If ProgressBar1.Value = ProgressBar1.Maximum Then
            MessageBox.Show("Complete", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ProgressBar1.Visible = False
        End If
    End Sub

    Private Sub mydummyDataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles mydummyDataGridView1.SelectionChanged
        Dim selecteditems As DataGridViewSelectedRowCollection = mydummyDataGridView1.SelectedRows
        mydummycombobox.Items.Clear()
        Dim s As String
        For Each selecteditem As DataGridViewRow In selecteditems
            s = selecteditem.Cells("stockno").Value.ToString
            mydummycombobox.Items.Add(s)
        Next
    End Sub

    Public Sub autoupdatestock(ByVal stockno As String)
        Try

            Dim str As String = "
                                    declare @allocation as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' AND TRANSTYPE='Allocation')+0
                                    declare @cancelalloc as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' AND TRANSTYPE='CancelAlloc')+0
                                    declare @order as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' AND TRANSTYPE='Order')+0
                                    declare @return as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' AND TRANSTYPE='Return')+0
                                    declare @supply as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' AND TRANSTYPE='Supply')+0
                                    declare @spare as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' AND TRANSTYPE='Spare')+0
                                    declare @addadjustment as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' AND TRANSTYPE='+Adjustment')+0
                                    declare @minadjustment as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' AND TRANSTYPE='-Adjustment')+0
                                    declare @receipt as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' AND TRANSTYPE='Receipt' AND NOT XYZ='Order')+0
                                    declare @issue as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' AND TRANSTYPE='Issue' AND NOT XYZ ='Allocation')+0
                                    declare @receiptorder as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' AND TRANSTYPE='Receipt' AND XYZ='Order')+0
                                    declare @issueallocation as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' AND TRANSTYPE='Issue' AND XYZ ='Allocation')+0
                                    declare @totalreceipt as decimal(10,2)=@receipt+@receiptorder
                                    declare @totalissue as decimal(10,2)=@issue+@issueallocation
            update stocks_tb set 
                                    
                                    physical=(QTY+@totalreceipt+@return+@addadjustment)-(@totalissue+@minadjustment),
                                    allocation = @allocation-(@issueallocation+@cancelalloc),
                                    free=(((QTY+@totalreceipt+@return+@addadjustment)-(@allocation-@cancelalloc)))-(@issue+@minadjustment),
                                    stockorder=@order-@receiptorder,
                                    issue=@totalissue
                                    where stockno='" & stockno & "'"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            sqlcmd.ExecuteNonQuery()
        Catch ex As SqlException
            If ex.Number = 1205 Then
            Else
                MsgBox(ex.ToString)
            End If
        End Try
    End Sub

    Private Sub KryptonButton20_Click(sender As Object, e As EventArgs) Handles KryptonButton20.Click
        ProgressBar2.Visible = True
        ProgressBar2.Maximum = stocksStocksno.Items.Count
        ProgressBar2.Value = 0
        sql.sqlcon.Open()
        For i As Integer = 0 To stocksStocksno.Items.Count - 1
            Dim stockno As String = stocksStocksno.Items(i).ToString
            autoupdatestock(stockno)
            ProgressBar2.Value += 1
        Next
        sql.sqlcon.Close()
        If ProgressBar2.Value = ProgressBar2.Maximum Then
            MessageBox.Show("Complete", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ProgressBar2.Visible = False
        End If
    End Sub

    'Private Sub KryptonButton21_Click(sender As Object, e As EventArgs) Handles KryptonButton21.Click
    '    sql.goback()
    'End Sub

    'Private Sub KryptonButton22_Click(sender As Object, e As EventArgs) Handles KryptonButton22.Click
    '    sql.gonext()
    'End Sub

    Private Sub costheadsearch_KeyDown(sender As Object, e As KeyEventArgs) Handles costheadsearch.KeyDown
        If e.KeyData = Keys.Enter Then
            KryptonButton1.PerformClick()
        End If
    End Sub

    Private Sub typecolorsearch_KeyDown(sender As Object, e As KeyEventArgs) Handles typecolorsearch.KeyDown
        If e.KeyData = Keys.Enter Then
            KryptonButton1.PerformClick()
        End If
    End Sub

    Private Sub articlenosearch_KeyDown(sender As Object, e As KeyEventArgs) Handles articlenosearch.KeyDown
        If e.KeyData = Keys.Enter Then
            KryptonButton1.PerformClick()
        End If
    End Sub

    Private Sub reportheader_MouseDown(sender As Object, e As MouseEventArgs) Handles reportheader.MouseDown
        Dim i As Integer = reportheader.SelectedIndex
        If reportsupplier.Text = "" Then
            sql.getreportheader1()
        Else
            sql.getreportheader(reportsupplier.Text)
        End If
        If i > reportheader.Items.Count - 1 Then
            reportheader.SelectedIndex = -1
        Else
            reportheader.SelectedIndex = i
        End If
    End Sub

    Private Sub reportcosthead_MouseDown(sender As Object, e As MouseEventArgs) Handles reportcosthead.MouseDown
        Dim i As Integer = reportcosthead.SelectedIndex
        If reportsupplier.Text = "" And reportheader.Text = "" Then
            sql.getreportcosthead1()
        ElseIf Not reportsupplier.Text = "" And reportheader.Text = "" Then
            sql.getreportcosthead2(reportsupplier.Text)
        ElseIf reportsupplier.Text = "" And Not reportheader.Text = "" Then
            sql.getreportcosthead3(reportheader.Text)
        Else
            sql.getreportcosthead(reportsupplier.Text, reportheader.Text)
        End If
        If i > reportcosthead.Items.Count - 1 Then
            reportcosthead.SelectedIndex=-1
        Else
            reportcosthead.SelectedIndex = i
        End If
    End Sub

    Private Sub reporttypecolor_MouseDown(sender As Object, e As MouseEventArgs) Handles reporttypecolor.MouseDown
        Dim I As Integer = reporttypecolor.SelectedIndex
        If reportsupplier.Text = "" And reportheader.Text = "" And reportcosthead.Text = "" Then
            sql.getreporttypecolor1()
        ElseIf Not reportsupplier.Text = "" And reportheader.Text = "" And reportcosthead.Text = "" Then
            sql.getreporttypecolor2(reportsupplier.Text)
        ElseIf reportsupplier.Text = "" And Not reportheader.Text = "" And reportcosthead.Text = "" Then
            sql.getreporttypecolor3(reportheader.Text)
        ElseIf reportsupplier.Text = "" And reportheader.Text = "" And Not reportcosthead.Text = "" Then
            sql.getreporttypecolor4(reportcosthead.Text)
        Else
            sql.getreporttypecolor(reportsupplier.Text, reportheader.Text, reportcosthead.Text)
        End If
        If I > reporttypecolor.Items.Count - 1 Then
            reporttypecolor.SelectedIndex = -1
        Else
            reporttypecolor.SelectedIndex = I
        End If
    End Sub

    Private Sub transtransaction_KeyDown(sender As Object, e As KeyEventArgs) Handles transtransaction.KeyDown
        If e.KeyData = Keys.Enter Then
            KryptonButton11.PerformClick()
        End If
    End Sub

    Private Sub transreference_KeyDown(sender As Object, e As KeyEventArgs) Handles transreference.KeyDown
        If e.KeyData = Keys.Enter Then
            KryptonButton11.PerformClick()
        End If
    End Sub

    Private Sub transactioncosthead_KeyDown(sender As Object, e As KeyEventArgs) Handles transactioncosthead.KeyDown
        If e.KeyData = Keys.Enter Then
            KryptonButton11.PerformClick()
        End If
    End Sub

    Private Sub referenceDataGridView_MouseDown(sender As Object, e As MouseEventArgs) Handles referenceDataGridView.MouseDown
        If e.Button = MouseButtons.Right Then
            'cancelall.ShowDialog()
            referencemenustrip.Show(referenceDataGridView, New Point(e.X, e.Y))
        End If
    End Sub

    Private Sub referenceDataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles referenceDataGridView.CellClick
        If referenceDataGridView.RowCount >= 0 And e.RowIndex >= 0 Then
            editreference.reference.Text = referenceDataGridView.Item(0, e.RowIndex).Value.ToString
            editreference.stockno.Text = referenceDataGridView.Item(1, e.RowIndex).Value.ToString
            editreference.costhead.Text = referenceDataGridView.Item(2, e.RowIndex).Value.ToString
            editreference.typecolor.Text = referenceDataGridView.Item(3, e.RowIndex).Value.ToString
            editreference.articleno.Text = referenceDataGridView.Item(4, e.RowIndex).Value.ToString
            editreference.allocation.Text = referenceDataGridView.Item(6, e.RowIndex).Value.ToString

            description.Text = referenceDataGridView.Item(10, e.RowIndex).Value.ToString
        End If
    End Sub

    Private Sub stocksgridview_KeyDown(sender As Object, e As KeyEventArgs) Handles stocksgridview.KeyDown
        If e.KeyData = Keys.F1 Then
            TabControl1.SelectedIndex = 1
            sql.movetoinput(stocknoinput.Text)
        End If
    End Sub

    Private Sub receiptGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles receiptGridView.CellClick
        If receiptGridView.RowCount >= 0 And e.RowIndex >= 0 Then
            Form5.transno.Text = receiptGridView.Item(0, e.RowIndex).Value.ToString
            Form5.stockno.Text = receiptGridView.Item(1, e.RowIndex).Value.ToString
            Form5.reference.Text = receiptGridView.Item(9, e.RowIndex).Value.ToString
            Form5.XYZ.Text = receiptGridView.Item(12, e.RowIndex).Value.ToString
            description.Text = receiptGridView.Item(13, e.RowIndex).Value.ToString
        End If
    End Sub

    Private Sub receiptGridView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles receiptGridView.CellDoubleClick
        If receiptGridView.RowCount >= 0 And e.RowIndex >= 0 Then
            Form5.itcame.Text = "RECEIPT"
            sql.selecttransrec(Form5.transno.Text)
            sql.selectreference(Form5.stockno.Text, Form5.reference.Text)
            Form5.ShowDialog()
        End If
    End Sub

    Private Sub transqty_KeyDown(sender As Object, e As KeyEventArgs) Handles transqty.KeyDown
        If e.KeyData = Keys.Enter Then
            KryptonButton4.Focus()
        End If

    End Sub

    Private Sub transqty_TextChanged(sender As Object, e As EventArgs) Handles transqty.TextChanged
        transqty.Text = transqty.Text.Replace("
", "")
    End Sub

    Private Sub reffromreference_KeyDown(sender As Object, e As KeyEventArgs) Handles reffromreference.KeyDown
        If e.KeyData = Keys.Enter Then
            KryptonButton12.PerformClick()
        End If
    End Sub

    Private Sub referencecosthead_KeyDown(sender As Object, e As KeyEventArgs) Handles referencecosthead.KeyDown
        If e.KeyData = Keys.Enter Then
            KryptonButton12.PerformClick()
        End If
    End Sub

    Private Sub referencetypecolor_KeyDown(sender As Object, e As KeyEventArgs) Handles referencetypecolor.KeyDown
        If e.KeyData = Keys.Enter Then
            KryptonButton12.PerformClick()
        End If
    End Sub

    Private Sub referencearticleno_KeyDown(sender As Object, e As KeyEventArgs) Handles referencearticleno.KeyDown
        If e.KeyData = Keys.Enter Then
            KryptonButton12.PerformClick()
        End If
    End Sub

    Private Sub receiptqty_TextChanged(sender As Object, e As EventArgs) Handles receiptqty.TextChanged
        receiptqty.Text = receiptqty.Text.Replace("
", "")
    End Sub

    Private Sub receiptqty_KeyDown(sender As Object, e As KeyEventArgs) Handles receiptqty.KeyDown
        If e.KeyData = Keys.Enter Then
            KryptonButton5.Focus()
        End If
    End Sub

    Private Sub CuttingListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CuttingListToolStripMenuItem.Click
        cuttinglist.ShowDialog()
    End Sub

    Private Sub Form2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

    End Sub

    Private Sub KryptonButton23_Click(sender As Object, e As EventArgs) Handles KryptonButton23.Click
        Form3.Text = "Copy"
        Form3.ShowDialog()
    End Sub

    Private Sub referenceDataGridView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles referenceDataGridView.CellDoubleClick
        editreference.ShowDialog()
    End Sub

    Private Sub issueDataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles issueDataGridView.CellClick
        If issueDataGridView.RowCount >= 0 Or e.RowIndex >= 0 Then
            description.Text = issueDataGridView.Item(7, e.RowIndex).Value.ToString
        End If
    End Sub

    Private Sub CancelMultiItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelMultiItemToolStripMenuItem.Click
        cancelall.ShowDialog()
    End Sub

    Private Sub MoveMultiItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MoveMultiItemToolStripMenuItem.Click
        multimove.KryptonLabel6.Text = "Move Allocation"
        multimove.ShowDialog()
    End Sub

    Private Sub MoveOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MoveOrderToolStripMenuItem.Click
        multimove.KryptonLabel6.Text = "Move Order"
        multimove.ShowDialog()
    End Sub

    Private Sub supplier_MouseDown(sender As Object, e As MouseEventArgs) Handles supplier.MouseDown
        Dim x As Integer = supplier.SelectedIndex
        sql.loadsuppliersearch()
        costheadsearch.Text = ""
        typecolorsearch.Text = ""
        articlenosearch.Text = ""
        If x > supplier.Items.Count - 1 Then
            supplier.SelectedIndex = -1
        Else
            supplier.SelectedIndex = x
        End If
    End Sub

    Private Sub supplier_KeyDown(sender As Object, e As KeyEventArgs) Handles supplier.KeyDown
        If e.KeyData = Keys.Enter Then
            KryptonButton1.PerformClick()
        End If
    End Sub

    Private Sub KryptonButton24_Click(sender As Object, e As EventArgs) Handles KryptonButton24.Click
        DEFAULTITEMS.Show()
    End Sub
End Class
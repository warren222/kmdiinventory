Imports System.Data.SqlClient
Public Class cancelall
    Dim xm As Integer
    Dim ym As Integer
    Dim drag As Boolean
    Dim sql As New sql
    Dim sqlcmd As New SqlCommand
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ProgressBar1.Visible = False
        Me.Close()
    End Sub

    Private Sub Panel3_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel3.MouseDown
        drag = True
        xm = Cursor.Position.X - Me.Left
        ym = Cursor.Position.Y - Me.Top
    End Sub

    Private Sub Panel3_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel3.MouseMove
        If drag Then
            Me.Left = Cursor.Position.X - xm
            Me.Top = Cursor.Position.Y - ym
        End If
    End Sub

    Private Sub Panel3_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel3.MouseUp
        drag = False
    End Sub

    Private Sub KryptonButton1_Click(sender As Object, e As EventArgs) Handles KryptonButton1.Click
        If MessageBox.Show("Cancel all allocation?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            MessageBox.Show("Operation Cancelled", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        If header.Text = "Form2" Then
            ProgressBar1.Visible = True
            ProgressBar1.Value = 0
            ProgressBar1.Maximum = Form2.refcombo.Items.Count
            For i As Integer = 0 To Form2.refcombo.Items.Count - 1
                Dim reference As String = Form2.refcombo.Items(i).ToString()
                Dim jo As String = Form2.refjo.Items(i).ToString()
                Dim stockno As String = Form2.refstock.Items(i).ToString()
                updatereference(stockno, reference, jo)
                getqty(stockno, reference, jo)
                loopissue.Text = allalloc.Text

                loadallocationlist(reference, jo, stockno)
                LISTOFALLOCATIONGRIDVIEW.SelectAll()
                KryptonButton25.PerformClick()

                updatereference(stockno, reference, jo)
                cancelalloc(stockno, reference, jo)
                updatereference(stockno, reference, jo)
                autoupdatestock(stockno)
                ProgressBar1.Value = ProgressBar1.Value + 1
            Next
            Form2.KryptonButton12.PerformClick()
            Form2.reffromreference.Focus()
            Button1.PerformClick()
        ElseIf header.Text = "checklisted" Then
            ProgressBar1.Visible = True
            ProgressBar1.Value = 0
            ProgressBar1.Maximum = checklisted.refcombo.Items.Count
            For i As Integer = 0 To checklisted.refcombo.Items.Count - 1
                Dim reference As String = checklisted.refcombo.Items(i).ToString()
                Dim jo As String = checklisted.refjo.Items(i).ToString()
                Dim stockno As String = checklisted.refstock.Items(i).ToString()

                getqty(stockno, reference, jo)
                loopissue.Text = allalloc.Text

                loadallocationlist(reference, jo, stockno)
                LISTOFALLOCATIONGRIDVIEW.SelectAll()
                KryptonButton25.PerformClick()

                updatereference(stockno, reference, jo)
                cancelalloc(stockno, reference, jo)
                updatereference(stockno, reference, jo)
                autoupdatestock(stockno)
                ProgressBar1.Value = ProgressBar1.Value + 1
            Next
            updateca()
            checklisted.KryptonButton3.PerformClick()
            Button1.PerformClick()
        End If

    End Sub
    Public Sub updateca()
        Try
            sql.sqlcon1.Open()
            Dim str As String = "update addendum_to_contract_tb set ca='Cancelled' where project_label = '" & checklisted.projectlabel.Text & "' and NOT CHECKLISTED ='' and ca = ''"
            sqlcmd = New SqlCommand(str, sql.sqlcon1)
            sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon1.Close()
        End Try
    End Sub
    Public Sub loadallocationlist(ByVal a As String, ByVal jo As String, ByVal b As String)
        Try
            sql.sqlcon.Open()
            Dim da As New SqlDataAdapter
            Dim bs As New BindingSource
            Dim ds As New DataSet
            ds.Clear()
            Dim str As String = "select * from trans_tb where reference='" & a & "' and jo ='" & jo & "' and stockno='" & b & "' and transtype='Allocation' order by transdate desc"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "trans_tb")
            bs.DataSource = ds
            bs.DataMember = "trans_tb"
            LISTOFALLOCATIONGRIDVIEW.DataSource = bs
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub
    Public Sub updatereference(ByVal stockno As String, ByVal reference As String, ByVal jo As String)
        Try
            sql.sqlcon.Open()
            Dim bny As String = "
                                    declare @allocation as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' AND jo ='" & jo & "' and TRANSTYPE='Allocation')+0
                                    declare @cancelalloc as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' AND jo ='" & jo & "' AND TRANSTYPE='CancelAlloc')+0
                                    declare @order as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' AND jo ='" & jo & "' AND TRANSTYPE='Order')+0
                                    declare @return as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' AND jo ='" & jo & "' AND TRANSTYPE='Return')+0
                                    declare @receipt as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' AND jo ='" & jo & "' AND TRANSTYPE='Receipt' AND NOT XYZ='Order')+0
                                    declare @issue as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' AND jo ='" & jo & "' AND TRANSTYPE='Issue' AND NOT XYZ ='Allocation')+0
                                    declare @receiptorder as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' AND jo ='" & jo & "' AND TRANSTYPE='Receipt' AND XYZ='Order')+0
                                    declare @issueallocation as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' AND jo ='" & jo & "' AND TRANSTYPE='Issue' AND XYZ ='Allocation')+0
                                    declare @totalreceipt as decimal(10,2)=@receipt+@receiptorder
                                    declare @totalissue as decimal(10,2)=@issue+@issueallocation
update reference_tb set 

                                    allocation=@allocation-(@issueallocation+@cancelalloc),
                                    stockorder=@order-(@receiptorder),
                                    TOTALRECEIPT=@totalreceipt,
                                    totalissue=@totalissue,
                                    totalreturn=@return
                                    where stockno='" & stockno & "' and reference='" & reference & "' AND jo ='" & jo & "'"
            sqlcmd = New SqlCommand(bny, sql.sqlcon)
            sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub
    Public Sub getqty(ByVal stockno As String, ByVal reference As String, ByVal jo As String)
        Try
            sql.sqlcon.Open()
            Dim str = "select  COALESCE(allocation,0) from reference_tb where stockno ='" & stockno & "' and reference = '" & reference & "' and jo = '" & jo & "'"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            Dim a As SqlDataReader = sqlcmd.ExecuteReader
            While a.Read
                allalloc.Text = a(0).ToString
            End While
            a.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub
    Public Sub cancelalloc(ByVal stockno As String, ByVal reference As String, ByVal jo As String)
        Try
            sql.sqlcon.Open()
            Dim newcancelalloc As String = "
  declare @allocation as decimal(10,2)=(select  COALESCE(allocation,0) from reference_tb where stockno ='" & stockno & "' and reference = '" & reference & "' and jo = '" & jo & "')+0
declare @bal as decimal(10,2)=(select physical from stocks_tb where stockno = '" & stockno & "')

declare @id as integer = (select max(transno)+1 from trans_tb)
insert into trans_tb 
     (transno,STOCKNO,
            TRANSTYPE,
            TRANSDATE,
            DUEDATE,
            QTY,
            REFERENCE,jo,
            ACCOUNT,
            CONTROLNO,
            XYZ,
            XYZREF,
            REMARKS,
            balqty,
            INPUTTED)
values (@id,'" & stockno & "'," &
         "'CancelAlloc'," &
         "'" & Form2.transdate.Text & "'," &
         "''," &
         "@allocation," &
         "'" & reference & "'," &
             "'" & jo & "'," &
         "''," &
         "''," &
            "''," &
              "''," &
         "''," &
          "@bal," &
            "'" & Form1.Label1.Text & "')"
            sqlcmd = New SqlCommand(newcancelalloc, sql.sqlcon)
            sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub
    Public Sub autoupdatestock(ByVal stockno As String)
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
                                    stockorder=@order-(@receiptorder),
                                    issue=@totalissue
                                    where stockno='" & stockno & "'"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            sqlcmd.ExecuteNonQuery()
        Catch ex As SqlException
            If ex.Number = 1205 Then
            Else
                MsgBox(ex.ToString)
            End If
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Private Sub KryptonButton2_Click(sender As Object, e As EventArgs) Handles KryptonButton2.Click
        If MessageBox.Show("Cancel all remaining order?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            MessageBox.Show("Operation Cancelled", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        ProgressBar1.Visible = True
        ProgressBar1.Value = 0
        ProgressBar1.Maximum = Form2.refcombo.Items.Count
        For i As Integer = 0 To Form2.refcombo.Items.Count - 1
            Dim reference As String = Form2.refcombo.Items(i).ToString()
            Dim stockno As String = Form2.refstock.Items(i).ToString()
            Dim jo As String = Form2.refjo.Items(i).ToString()
            updatereference(stockno, reference, jo)
            cancelorder(stockno, reference, jo)
            updatereference(stockno, reference, jo)
            autoupdatestock(stockno)
            ProgressBar1.Value = ProgressBar1.Value + 1
        Next
        Form2.KryptonButton12.PerformClick()
        Button1.PerformClick()

    End Sub
    Public Sub cancelorder(ByVal stockno As String, ByVal reference As String, ByVal jo As String)
        Try
            sql.sqlcon.Open()
            Dim str As String = "update trans_tb set qty = 0,xyzref='canceled' where 
                        stockno = '" & stockno & "' and reference = '" & reference & "' and jo ='" & jo & "' and xyzref='' and transtype='Order'"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Private Sub cancelall_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Form1.Label2.Text = "Guest" Then
            KryptonButton2.Enabled = False
            KryptonButton1.Enabled = False
        ElseIf Form1.Label2.Text = "Admin" Or Form1.Label2.Text = "Encoder" Then
            KryptonButton2.Enabled = True
            KryptonButton1.Enabled = True
        End If
    End Sub

    Private Sub LISTOFALLOCATIONGRIDVIEW_SelectionChanged(sender As Object, e As EventArgs) Handles LISTOFALLOCATIONGRIDVIEW.SelectionChanged
        Dim selecteditems As DataGridViewSelectedRowCollection = LISTOFALLOCATIONGRIDVIEW.SelectedRows
        ComboBox1.Items.Clear()
        Dim a As String
        For Each selecteditem As DataGridViewRow In selecteditems
            a = selecteditem.Cells("transno").Value.ToString
            ComboBox1.Items.Add(a)
        Next
    End Sub

    Private Sub KryptonButton25_Click(sender As Object, e As EventArgs) Handles KryptonButton25.Click
        For i As Integer = 0 To ComboBox1.Items.Count - 1
            Dim transno As String
            transno = ComboBox1.Items(i).ToString
            transnooperation(transno)
        Next
    End Sub
    Public Sub transnooperation(ByVal transno As String)
        Try
            sql.sqlcon.Open()
            Dim str As String = "select balqty from trans_tb where transno = '" & transno & "'"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            Dim balqty As String
            Dim read As SqlDataReader = sqlcmd.ExecuteReader
            While read.Read
                balqty = read(0).ToString
                If balqty = "" Then
                    balqty = 0
                End If
            End While
            read.Close()
            Dim x As Double = balqty
            Dim y As Double = loopissue.Text

            If y = 0 Then
            ElseIf x = 0 Then
            Else
                Dim result As Double
                result = x - y
                If result < 0 Then
                    'MsgBox(result)
                    result = result * -1
                    Dim upto0 As String = "update trans_tb set balqty = 0 where transno = '" & transno & "'"
                    sqlcmd = New SqlCommand(upto0, sql.sqlcon)
                    sqlcmd.ExecuteNonQuery()
                Else
                    Dim uptoreault As String = "update trans_tb set balqty = '" & result & "' where transno = '" & transno & "'"
                    sqlcmd = New SqlCommand(uptoreault, sql.sqlcon)
                    sqlcmd.ExecuteNonQuery()
                    'MsgBox(result)
                    result = 0
                End If
                loopissue.Text = result
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Private Sub cancelall_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Form2.reffromreference.Focus()
    End Sub
End Class
Imports Transitions
Imports System.Data.SqlClient
Public Class editreference
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Dim sql As New sql
    Dim sqlcmd As New SqlCommand
    Dim meme As Integer
    Private Sub KryptonPanel1_MouseUp(sender As Object, e As MouseEventArgs) Handles KryptonPanel1.MouseUp
        drag = False
    End Sub

    Private Sub KryptonPanel1_MouseMove(sender As Object, e As MouseEventArgs) Handles KryptonPanel1.MouseMove
        If drag Then
            Me.Top = Cursor.Position.Y - mousey
            Me.Left = Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub KryptonPanel1_MouseDown(sender As Object, e As MouseEventArgs) Handles KryptonPanel1.MouseDown
        drag = True
        mousex = Cursor.Position.X - Me.Left
        mousey = Cursor.Position.Y - Me.Top
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub KryptonPanel2_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    'Private Sub KryptonButton1_MouseHover(sender As Object, e As EventArgs) Handles KryptonButton1.MouseHover
    '    Dim t As New Transition(New TransitionType_Acceleration(400))
    '    t.add(KryptonButton1, "Left", 71)
    '    t.add(KryptonButton1, "Text", "Cancel Allocation")
    '    t.run()
    'End Sub

    'Private Sub KryptonButton1_MouseLeave(sender As Object, e As EventArgs) Handles KryptonButton1.MouseLeave
    '    Dim t As New Transition(New TransitionType_Deceleration(400))
    '    t.add(KryptonButton1, "Left", 0)
    '    t.add(KryptonButton1, "Text", "")
    '    t.run()
    'End Sub

    Private Sub KryptonButton1_Click(sender As Object, e As EventArgs) Handles KryptonButton1.Click
        If allocation.Text = "0" Or allocation.Text = "" Then
            MessageBox.Show("No allocation found", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            If MessageBox.Show("Cancel all allocation?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                MessageBox.Show("Operation Cancelled", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            updatereference(stockno.Text, reference.Text, jo.Text)
            getqty(stockno.Text, reference.Text, jo.Text)
            loopissue.Text = allocation.Text

            loadallocationlist(reference.Text, jo.Text, stockno.Text)
            LISTOFALLOCATIONGRIDVIEW.SelectAll()
            KryptonButton25.PerformClick()

            updatereference(stockno.Text, reference.Text, jo.Text)
            cancelalloc(stockno.Text, reference.Text, jo.Text)
            updatereference(stockno.Text, reference.Text, jo.Text)
            autoupdatestock(stockno.Text)
            Form2.KryptonButton12.PerformClick()
            Button1.PerformClick()
        End If

    End Sub
    Public Sub getqty(ByVal stockno As String, ByVal reference As String, ByVal jo As String)
        Try
            sql.sqlcon.Open()
            Dim str = "select  COALESCE(allocation,0) from reference_tb where stockno ='" & stockno & "' and reference = '" & reference & "' and jo = '" & jo & "'"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            Dim a As SqlDataReader = sqlcmd.ExecuteReader
            While a.Read
                allocation.Text = a(0).ToString
            End While
            a.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub
    Public Sub loadallocationlist(ByVal a As String, ByVal jo As String, ByVal b As String)
        Try
            sql.sqlcon.Open()
            Dim da As New SqlDataAdapter
            Dim bs As New BindingSource
            Dim ds As New DataSet
            ds.Clear()
            Dim str As String = "select * from trans_tb where reference='" & a & "' and jo='" & jo & "' and stockno='" & b & "' and transtype='Allocation' order by transdate desc"
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
    Public Sub updatereference(ByVal stockno As String, ByVal reference As String, ByVal jo As String)
        Try
            sql.sqlcon.Open()
            Dim bny As String = "
                                    declare @allocation as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' and jo='" & jo & "' AND TRANSTYPE='Allocation')+0
                                    declare @cancelalloc as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' and jo='" & jo & "'  AND TRANSTYPE='CancelAlloc')+0
                                    declare @order as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' and jo='" & jo & "'  AND TRANSTYPE='Order')+0
                                    declare @return as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' and jo='" & jo & "'  AND TRANSTYPE='Return')+0
                                    declare @receipt as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' and jo='" & jo & "'  AND TRANSTYPE='Receipt' AND NOT XYZ='Order')+0
                                    declare @issue as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' and jo='" & jo & "'  AND TRANSTYPE='Issue' AND NOT XYZ ='Allocation')+0
                                    declare @receiptorder as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' and jo='" & jo & "'  AND TRANSTYPE='Receipt' AND XYZ='Order')+0
                                    declare @issueallocation as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' and jo='" & jo & "'  AND TRANSTYPE='Issue' AND XYZ ='Allocation')+0
                                    declare @totalreceipt as decimal(10,2)=@receipt+@receiptorder
                                    declare @totalissue as decimal(10,2)=@issue+@issueallocation
update reference_tb set 

                                    allocation=@allocation-(@issueallocation+@cancelalloc),
                                    stockorder=@order-(@receiptorder),
                                    TOTALRECEIPT=@totalreceipt,
                                    totalissue=@totalissue,
                                    totalreturn=@return
                                    where stockno='" & stockno & "' and reference='" & reference & "'  and jo='" & jo & "' "
            sqlcmd = New SqlCommand(bny, sql.sqlcon)
            sqlcmd.ExecuteNonQuery()
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

declare @id as integer =(select max(TRANSNO)+1 from trans_tb)
insert into trans_tb 
     (TRANSNO,STOCKNO,
            TRANSTYPE,
            TRANSDATE,
            DUEDATE,
            QTY,
            REFERENCE,jo,
            ACCOUNT,
            CONTROLNO,
            XYZ,
            XYZREF
            ,REMARKS,
            balqty
            ,INPUTTED) 
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
            MessageBox.Show("All allocation has been cancelled", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Private Sub KryptonButton3_Click(sender As Object, e As EventArgs) Handles KryptonButton3.Click
        If Form2.referenceDataGridView.Rows.Count > 0 Then
            Dim counter As Integer = Form2.referenceDataGridView.CurrentRow.Index + 1
            Dim nextRow As DataGridViewRow
            If counter = Form2.referenceDataGridView.RowCount Then
                nextRow = Form2.referenceDataGridView.Rows(0)
            Else
                nextRow = Form2.referenceDataGridView.Rows(counter)
            End If
            Form2.referenceDataGridView.CurrentCell = nextRow.Cells(0)
            nextRow.Selected = True
        End If
    End Sub

    Private Sub KryptonButton2_Click(sender As Object, e As EventArgs) Handles KryptonButton2.Click
        If Form2.referenceDataGridView.Rows.Count > 0 Then
            Dim counter As Integer = Form2.referenceDataGridView.CurrentRow.Index - 1
            Dim nextRow As DataGridViewRow
            If counter < Form2.referenceDataGridView.Rows(0).Index Then
                nextRow = Form2.referenceDataGridView.Rows(Form2.referenceDataGridView.Rows.Count - 1)
            Else
                nextRow = Form2.referenceDataGridView.Rows(counter)
            End If
            Form2.referenceDataGridView.CurrentCell = nextRow.Cells(0)
            nextRow.Selected = True
        End If
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        'If e.Button = MouseButtons.Right Then
        '    Transition.run(Panel1, "BackColor", Color.FromArgb(33, 148, 224), New TransitionType_Linear(1000))
        '    Transition.run(Panel2, "BackColor", Color.FromArgb(16, 62, 77), New TransitionType_Linear(1000))

        '    reference.Refresh()
        '    stockno.Refresh()
        '    costhead.Refresh()
        '    typecolor.Refresh()
        '    articleno.Refresh()
        '    allocation.Refresh()
        'Else
        '    Transition.run(Panel2, "BackColor", Color.FromArgb(33, 148, 224), New TransitionType_Linear(1000))
        '    Transition.run(Panel1, "BackColor", Color.FromArgb(16, 62, 77), New TransitionType_Linear(1000))
        'End If
        If e.Button = MouseButtons.Right Then
            Dim t As New Transition(New TransitionType_Acceleration(1000))
        If meme = 1 Then
                t.add(Panel1, "BackColor", Color.FromArgb(11, 19, 36))
                KryptonLabel1.StateCommon.ShortText.Color1 = Color.White
                KryptonLabel2.StateCommon.ShortText.Color1 = Color.White
                KryptonLabel3.StateCommon.ShortText.Color1 = Color.White
                KryptonLabel4.StateCommon.ShortText.Color1 = Color.White
                KryptonLabel6.StateCommon.ShortText.Color1 = Color.White
                KryptonLabel7.StateCommon.ShortText.Color1 = Color.White
                meme = 0
                t.run()
            ElseIf meme = 0 Then
            t.add(Panel1, "BackColor", Color.WhiteSmoke)
                meme = 1
                KryptonLabel1.StateCommon.ShortText.Color1 = Color.Black
                KryptonLabel2.StateCommon.ShortText.Color1 = Color.Black
                KryptonLabel3.StateCommon.ShortText.Color1 = Color.Black
                KryptonLabel4.StateCommon.ShortText.Color1 = Color.Black
                KryptonLabel6.StateCommon.ShortText.Color1 = Color.Black
                KryptonLabel7.StateCommon.ShortText.Color1 = Color.Black
                t.run()
            End If


        End If
    End Sub

    Private Sub editreference_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        meme = 0
        If Form1.Label2.Text = "Guest" Then
            KryptonButton1.Enabled = False
            KryptonButton5.Enabled = False
            KryptonButton6.Enabled = False
            KryptonButton7.Enabled = False
        ElseIf Form1.Label2.Text = "Admin" Or Form1.Label2.Text = "Encoder" Then
            KryptonButton1.Enabled = True
            KryptonButton5.Enabled = True
            KryptonButton6.Enabled = True
            KryptonButton7.Enabled = True
        End If
    End Sub

    Private Sub KryptonButton4_Click(sender As Object, e As EventArgs) Handles KryptonButton4.Click
        If reference.Text = "" Or stockno.Text = "" Then
        Else
            updatereference(stockno.Text, reference.Text, jo.Text)
            Form2.KryptonButton12.PerformClick()
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub KryptonButton5_Click(sender As Object, e As EventArgs) Handles KryptonButton5.Click
        moveallocation.KryptonLabel8.Text = "Move Allocation"
        moveallocation.ShowDialog()
    End Sub

    Private Sub KryptonButton7_Click(sender As Object, e As EventArgs) Handles KryptonButton7.Click
        If order.Text = "0" Or order.Text = "" Then
            MessageBox.Show("No order found", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            If MessageBox.Show("Cancel all remaining order?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                MessageBox.Show("Operation Cancelled", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            updatereference(stockno.Text, reference.Text, jo.Text)
            cancelorder(stockno.Text, reference.Text, jo.Text)
            updatereference(stockno.Text, reference.Text, jo.Text)
            autoupdatestock(stockno.Text)
            Form2.KryptonButton12.PerformClick()
            Button1.PerformClick()
        End If
    End Sub
    Public Sub cancelorder(ByVal stockno As String, ByVal reference As String, ByVal jo As String)
        Try
            sql.sqlcon.Open()
            Dim str As String = "update trans_tb set qty = 0,xyzref='canceled' where stockno = '" & stockno & "' and reference = '" & reference & "' and jo='" & jo & "' and xyzref='' and transtype='Order'"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Private Sub KryptonButton6_Click(sender As Object, e As EventArgs) Handles KryptonButton6.Click
        moveallocation.KryptonLabel8.Text = "Move Order"
        moveallocation.ShowDialog()
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

    'Private Sub KryptonButton5_MouseHover(sender As Object, e As EventArgs) Handles KryptonButton5.MouseHover
    '    Dim t As New Transition(New TransitionType_Acceleration(400))
    '    t.add(KryptonButton5, "Left", 503)
    '    t.add(KryptonButton5, "Text", "Move Allocation")
    '    t.run()
    'End Sub

    'Private Sub KryptonButton5_MouseLeave(sender As Object, e As EventArgs) Handles KryptonButton5.MouseLeave
    '    Dim t As New Transition(New TransitionType_Deceleration(400))
    '    t.add(KryptonButton5, "Left", 579)
    '    t.add(KryptonButton5, "Text", "")
    '    t.run()
    'End Sub




    'Private Sub KryptonButton4_MouseHover(sender As Object, e As EventArgs) Handles KryptonButton4.MouseHover
    '    Dim t As New Transition(New TransitionType_Acceleration(400))
    '    t.add(KryptonButton4, "Left", 522)
    '    t.add(KryptonButton4, "Text", "refresh")
    '    t.run()
    'End Sub

    'Private Sub KryptonButton4_MouseLeave(sender As Object, e As EventArgs) Handles KryptonButton4.MouseLeave
    '    Dim t As New Transition(New TransitionType_Deceleration(400))
    '    t.add(KryptonButton4, "Left", 593)
    '    t.add(KryptonButton4, "Text", "")
    '    t.run()
    'End Sub
End Class
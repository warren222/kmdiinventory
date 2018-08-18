Imports System.Data.SqlClient
Imports Transitions
Public Class Form5
    Dim sql As New sql
    Dim sqlcmd As New SqlCommand
    Dim xm As Integer
    Dim ym As Integer
    Dim drag As Boolean

    Public Sub GETBALANCEALLOCISSUE(ByVal stock As String, ByVal ref As String, ByVal jo As String, ByVal xyz As String)
        Try
            sql.sqlcon.Open()
            '  Dim x As String = "     declare @allocation as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stock & "' and reference = '" & ref & "' AND TRANSTYPE='Allocation')+0
            '                          declare @issueallocation as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stock & "' and reference = '" & ref & "' AND TRANSTYPE='Issue' AND XYZ ='Allocation')+0
            '"
            Dim allocationstr As String = "
declare @allocation as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stock & "' and reference = '" & ref & "' and jo = '" & jo & "' AND TRANSTYPE='Allocation')+0
declare @cancelalloc as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stock & "' and reference = '" & ref & "'  and jo = '" & jo & "' AND TRANSTYPE='CancelAlloc')+0
        select @allocation-@cancelalloc from trans_tb where stockno ='" & stock & "' and reference = '" & ref & "' and jo = '" & jo & "'  AND TRANSTYPE='Allocation'"
            sqlcmd = New SqlCommand(allocationstr, sql.sqlcon)
            Dim read As SqlDataReader = sqlcmd.ExecuteReader
            While read.Read
                REFALLOC.Text = read(0).ToString
            End While
            read.Close()

            Dim issuestr As String = "declare @issueallocation as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stock & "' and reference = '" & ref & "' and jo = '" & jo & "'  AND TRANSTYPE='Issue' AND XYZ ='Allocation')+0
        select @issueallocation AS XA from trans_tb where stockno ='" & stock & "' and reference = '" & ref & "' and jo = '" & jo & "'  AND TRANSTYPE='Issue' AND XYZ ='Allocation'"
            sqlcmd = New SqlCommand(issuestr, sql.sqlcon)
            Dim read2 As SqlDataReader = sqlcmd.ExecuteReader
            While read2.Read
                REFISSUE.Text = read2(0).ToString
            End While
            read2.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub



    Private Sub KryptonDateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles KryptonDateTimePicker1.ValueChanged
        duedate.Text = KryptonDateTimePicker1.Text
    End Sub

    Private Sub KryptonDateTimePicker1_MouseDown(sender As Object, e As MouseEventArgs) Handles KryptonDateTimePicker1.MouseDown
        duedate.Text = KryptonDateTimePicker1.Text
    End Sub

    Private Sub DateTimePicker9_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker9.ValueChanged
        transdate.Text = DateTimePicker9.Text
    End Sub

    Private Sub DateTimePicker9_MouseDown(sender As Object, e As MouseEventArgs) Handles DateTimePicker9.MouseDown
        transdate.Text = DateTimePicker9.Text
    End Sub

    Private Sub KryptonCheckButton1_CheckedChanged(sender As Object, e As EventArgs) Handles KryptonCheckButton1.CheckedChanged
        If KryptonCheckButton1.Checked = True Then
            KryptonDateTimePicker1.Visible = True
            duedate.Text = KryptonDateTimePicker1.Text
        ElseIf KryptonCheckButton1.Checked = False Then
            KryptonDateTimePicker1.Visible = False
        Else
            KryptonDateTimePicker1.Value = duedate.Text
        End If
    End Sub

    Private Sub CheckBox39_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox39.CheckedChanged
        If CheckBox39.Checked = True Then
            DateTimePicker9.Visible = True
            transdate.Text = DateTimePicker9.Text
        ElseIf CheckBox39.Checked = False Then
            DateTimePicker9.Visible = False
        Else
            DateTimePicker9.Value = transdate.Text
        End If
    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Form1.Label2.Text = "Admin" Or Form1.Label2.Text = "Encoder" Or Form1.Label2.Text = "Allocation" Then
            KryptonButton1.Enabled = True
        Else
            KryptonButton1.Enabled = False
        End If
        REFALLOC.Text = 0
        REFISSUE.Text = 0
        minadj.Text = 0
        KryptonLabel23.Text = "Minimum Qty"
        Timer1.Start()
    End Sub

    Private Sub KryptonButton2_Click(sender As Object, e As EventArgs) Handles KryptonButton2.Click
        Me.Close()
    End Sub
    Public Sub loadallocationlist(ByVal a As String, ByVal jo As String, ByVal b As String)
        Try
            sql.sqlcon.Open()
            Dim da As New SqlDataAdapter
            Dim bs As New BindingSource
            Dim ds As New DataSet
            ds.Clear()
            Dim str As String = "select * from trans_tb where reference='" & a & "' and jo = '" & jo & "' and stockno='" & b & "' and transtype='Allocation' order by transdate desc"
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
    Private Sub KryptonButton1_Click(sender As Object, e As EventArgs) Handles KryptonButton1.Click
        If Form1.Label2.Text = "Allocation" Then
            If transtype.Text = "Allocation" Then
                one()
            Else
                MsgBox("access denied!")
            End If
        Else
            one()
        End If
    End Sub
    Public Sub one()
        Dim x As Double
        If balanceqty.Text = "" Then
            x = 0
        Else
            x = balanceqty.Text
        End If
        If transtype.Text = "Issue" Then
            Dim maxtransaction As String
            Try
                sql.sqlcon.Open()
                Dim findmax As String = "select max(transno) from trans_tb where 
stockno='" & stockno.Text & "' and 
reference = '" & reference.Text & "' and
JO = '" & JO.Text & "' AND
transtype = 'Issue'"
                sqlcmd = New SqlCommand(findmax, sql.sqlcon)
                Dim read As SqlDataReader = sqlcmd.ExecuteReader
                While read.Read
                    maxtransaction = read(0).ToString
                End While
                read.Close()
            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                sql.sqlcon.Close()
            End Try
            If Not transno.Text = maxtransaction And Not initialqty.Text = qty.Text Then
                MessageBox.Show("unable to update quantity
proceed to latest issue", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            Else

            End If

            Dim orig As Double = initialqty.Text
            Dim newqty As Double = qty.Text
            Dim bal As Double = x

            Dim result As Double = orig - newqty
            Dim justupdate As String
            If result >= 0 Then
                Dim v As Double = bal + result
                justupdate = "update trans_tb set balqty = '" & v & "' where transno = '" & transno.Text & "'"
            Else
                Dim v As Double = bal - (-1 * result)
                justupdate = "update trans_tb set balqty = '" & v & "' where transno = '" & transno.Text & "'"
            End If
            Try
                sql.sqlcon.Open()
                sqlcmd = New SqlCommand(justupdate, sql.sqlcon)
                sqlcmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                sql.sqlcon.Close()
            End Try
        End If
        If transtype.Text = "Allocation" And xyzref.Text = "" Then
            Dim orig As Double = initialqty.Text
            Dim newqty As Double = qty.Text
            Dim bal As Double = x

            Dim result As Double = orig - newqty

            If result >= 0 Then
                'if result is positive compute balance qty
                Dim v As Double = bal - result
                If v >= 0 Then
                    'if bal qty is positive
                    Try
                        sql.sqlcon.Open()
                        Dim justupdate As String = "update trans_tb set balqty = '" & v & "' where transno = '" & transno.Text & "'"
                        sqlcmd = New SqlCommand(justupdate, sql.sqlcon)
                        sqlcmd.ExecuteNonQuery()
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    Finally
                        sql.sqlcon.Close()
                    End Try
                ElseIf v < 0 Then
                    'if bal is negative , update balqty to 0 then loop to another allocation
                    Try
                        sql.sqlcon.Open()
                        Dim justupdate As String = "update trans_tb set balqty = 0 where transno = '" & transno.Text & "'"
                        sqlcmd = New SqlCommand(justupdate, sql.sqlcon)
                        sqlcmd.ExecuteNonQuery()
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    Finally
                        sql.sqlcon.Close()
                    End Try
                    loopissue.Text = v * -1
                    loadallocationlist(reference.Text, JO.Text, stockno.Text)
                    LISTOFALLOCATIONGRIDVIEW.SelectAll()
                    KryptonButton25.PerformClick()

                End If
            ElseIf result < 0 Then
                'if result is negative then update balqty plus result multiply by negative one
                Try
                    sql.sqlcon.Open()
                    Dim justupdate As String = "update trans_tb set balqty = balqty+" & (result * -1) & " where transno = '" & transno.Text & "'"
                    sqlcmd = New SqlCommand(justupdate, sql.sqlcon)
                    sqlcmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                Finally
                    sql.sqlcon.Close()
                End Try
            End If
        End If

        sql.updatetransdates(transno.Text, transdate.Text, duedate.Text, qty.Text, xyzref.Text, ADJUSTMENTREMARKS.Text)

        If KryptonCheckBox1.Checked = True And Not newstockno.Text = "" Then
            updatenewstockno(transno.Text, newstockno.Text)
            findnewreference(newstockno.Text, reference.Text, JO.Text)
            updatestock(newstockno.Text, reference.Text, JO.Text)
        End If
        If KryptonCheckBox2.Checked = True Then
            If newreference.Text = "" Then
                MessageBox.Show("select or input reference to proceed", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                updatenewreference(transno.Text, newreference.Text, NEWJO.Text)
                findnewreference(stockno.Text, newreference.Text, NEWJO.Text)
                updatestock(stockno.Text, newreference.Text, NEWJO.Text)
            End If
        End If
        If KryptonCheckBox1.Checked = True And KryptonCheckBox2.Checked = True Then
            updatestock(newstockno.Text, newreference.Text, NEWJO.Text)
        End If

        updatestock(stockno.Text, reference.Text, JO.Text)
        sql.selecttransrec(transno.Text)

        Form2.KryptonButton11.PerformClick()
        sql.selectreference(stockno.Text, reference.Text, JO.Text)
        KryptonButton3.PerformClick()
        Button1.PerformClick()
        'If itcame.Text = "A" Then
        '    Form4.KryptonButton4.PerformClick()
        'End If
    End Sub
    Public Sub updatenewreference(ByVal transno As String, ByVal reference As String, ByVal jo As String)
        Try
            sql.sqlcon.Open()
            Dim str As String = "update trans_tb set reference = '" & reference & "',jo='" & jo & "' where transno = '" & transno & "'"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub
    Public Sub updatenewstockno(ByVal transno As String, ByVal stockno As String)
        Try
            sql.sqlcon.Open()
            Dim str As String = "
declare @unitprice as decimal(10,2) = (select unitprice from stocks_tb where stockno = '" & stockno & "')
Declare @xrate as decimal(10,2) = (select xrate from stocks_tb where stockno = '" & stockno & "')
declare @ufactor decimal(10,2)= (select ufactor from stocks_tb where stockno = '" & stockno & "')

update trans_tb set 
stockno = '" & stockno & "',
unitprice=@unitprice,
xrate=@xrate,
ufactor=@ufactor,
netamount=(@unitprice*@xrate)*(qty*@ufactor)
where transno = '" & transno & "'"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            sqlcmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub
    Public Sub findnewreference(ByVal stockno As String, ByVal reference As String, ByVal jo As String)
        Try
            sql.sqlcon.Open()
            Dim find As String = "select * from reference_tb where reference='" & reference & "' and jo = '" & jo & "' and stockno='" & stockno & "'"
            sqlcmd = New SqlCommand(find, sql.sqlcon)
            Dim read As SqlDataReader = sqlcmd.ExecuteReader
            If read.HasRows = True Then
                read.Close()
            Else
                read.Close()
                Dim insert As String = "
declare @id as integer = (select max(id)+1 from reference_tb)
insert into reference_tb (id,reference,jo,stockno) values(@id,'" & reference & "','" & jo & "','" & stockno & "')"
                sqlcmd = New SqlCommand(insert, sql.sqlcon)
                sqlcmd.ExecuteNonQuery()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub
    Public Sub updatestock(ByVal stockno As String, ByVal reference As String, ByVal jo As String)
        Try
            sql.sqlcon.Open()
            Dim str As String = "
                                    Declare @allocation as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' AND TRANSTYPE='Allocation')+0
                                    Declare @cancelalloc as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' AND TRANSTYPE='CancelAlloc')+0
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
                                    declare @allocation as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' and jo = '" & jo & "' AND TRANSTYPE='Allocation')+0
                                    declare @cancelalloc as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' and jo = '" & jo & "'  AND TRANSTYPE='CancelAlloc')+0
                                    declare @order as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' and jo = '" & jo & "'  AND TRANSTYPE='Order')+0
                                    declare @return as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' and jo = '" & jo & "'  AND TRANSTYPE='Return')+0
                                    declare @receipt as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' and jo = '" & jo & "'  AND TRANSTYPE='Receipt' AND NOT XYZ='Order')+0
                                    declare @issue as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' and jo = '" & jo & "'  AND TRANSTYPE='Issue' AND NOT XYZ ='Allocation')+0
                                    declare @receiptorder as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' and jo = '" & jo & "'  AND TRANSTYPE='Receipt' AND XYZ='Order')+0
                                    declare @issueallocation as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' and jo = '" & jo & "'  AND TRANSTYPE='Issue' AND XYZ ='Allocation')+0
                                    declare @totalreceipt as decimal(10,2)=@receipt+@receiptorder
                                    declare @totalissue as decimal(10,2)=@issue+@issueallocation
update reference_tb set 

                                    allocation=@allocation-(@issueallocation+@cancelalloc),
                                    stockorder=@order-@receiptorder,
                                    TOTALRECEIPT=@totalreceipt,
                                    totalissue=@totalissue,
                                    totalreturn=@return
                                    where stockno='" & stockno & "' and reference='" & reference & "' and jo = '" & jo & "' "
            sqlcmd = New SqlCommand(bny, sql.sqlcon)
            sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub


    Private Sub transtype_TextChanged(sender As Object, e As EventArgs) Handles transtype.TextChanged
        'If transtype.Text = "Allocation" Then
        '    deallocate.Enabled = True
        '    deallocatebtn.Enabled = True
        '    cancelorder.Enabled = False
        '    cancelorderbtn.Enabled = False
        'ElseIf transtype.Text = "Order" Then
        '    deallocate.Enabled = False
        '    deallocatebtn.Enabled = False
        '    cancelorder.Enabled = True
        'cancelorderbtn.Enabled = True
        'Else
        '    deallocate.Enabled = False
        '    deallocatebtn.Enabled = False
        '    cancelorder.Enabled = False
        '    cancelorderbtn.Enabled = False


        If transtype.Text = "Order" And xyzref.Text = "" Then
            qty.Enabled = True
            turntrue()
        ElseIf transtype.Text = "Order" And Not xyzref.Text = "" Then
            qty.Enabled = False
            turnfalse()
        ElseIf transtype.Text = "Receipt" And xyzref.Text = "" Then
            qty.Enabled = True
            turnfalse()
        ElseIf transtype.Text = "Receipt" And Not xyzref.Text = "" Then
            qty.Enabled = True
            turnfalse()
        ElseIf transtype.Text = "Allocation" And xyzref.Text = "" Then
            qty.Enabled = True
            turntrue()
        ElseIf transtype.Text = "Allocation" And Not xyzref.Text = "" Then
            qty.Enabled = False
            turnfalse()
        ElseIf transtype.Text = "Issue" And xyzref.Text = "" Then
            qty.Enabled = True
            turnfalse()
        ElseIf transtype.Text = "Issue" And Not xyzref.Text = "" Then
            qty.Enabled = True
            turnfalse()
        ElseIf transtype.Text = "Return" And xyzref.Text = "" Then
            qty.Enabled = True
            turntrue()
        ElseIf transtype.Text = "Return" And Not xyzref.Text = "" Then
            qty.Enabled = True
            turntrue()
        ElseIf transtype.Text = "Supply" And xyzref.Text = "" Then
            qty.Enabled = True
            turntrue()
        ElseIf transtype.Text = "Supply" And Not xyzref.Text = "" Then
            qty.Enabled = True
            turntrue()
        ElseIf transtype.Text = "Spare" And xyzref.Text = "" Then
            qty.Enabled = True
            turntrue()
        ElseIf transtype.Text = "Spare" And Not xyzref.Text = "" Then
            qty.Enabled = True
            turntrue()
        ElseIf transtype.Text = "+Adjustment" And xyzref.Text = "" Then
            qty.Enabled = True
            turntrue()
        ElseIf transtype.Text = "+Adjustment" And Not xyzref.Text = "" Then
            qty.Enabled = True
            turntrue()
        ElseIf transtype.Text = "-Adjustment" And xyzref.Text = "" Then
            qty.Enabled = True
            turntrue()
        ElseIf transtype.Text = "-Adjustment" And Not xyzref.Text = "" Then
            qty.Enabled = True
            turntrue()
        Else
            qty.Enabled = False
            turnfalse()
        End If
    End Sub
    Public Sub turntrue()
        newreference.Enabled = True
        NEWJO.Enabled = True
        newcosthead.Enabled = True
        newtypecolor.Enabled = True
        newarticleno.Enabled = True
        KryptonCheckBox1.Enabled = True
        KryptonCheckBox2.Enabled = True
    End Sub
    Public Sub turnfalse()
        NEWJO.Enabled = False
        newreference.Enabled = False
        newcosthead.Enabled = False
        newtypecolor.Enabled = False
        newarticleno.Enabled = False
        KryptonCheckBox1.Enabled = False
        KryptonCheckBox2.Enabled = False
    End Sub
    Private Sub xyzref_TextChanged(sender As Object, e As EventArgs) Handles xyzref.TextChanged
        If transtype.Text = "Order" And xyzref.Text = "" Then
            qty.Enabled = True
        ElseIf transtype.Text = "Order" And Not xyzref.Text = "" Then
            qty.Enabled = False
        ElseIf transtype.Text = "Receipt" And xyzref.Text = "" Then
            qty.Enabled = True
        ElseIf transtype.Text = "Receipt" And Not xyzref.Text = "" Then
            qty.Enabled = True
        ElseIf transtype.Text = "Allocation" And xyzref.Text = "" Then
            qty.Enabled = True
        ElseIf transtype.Text = "Allocation" And Not xyzref.Text = "" Then
            qty.Enabled = False
        ElseIf transtype.Text = "Issue" And xyzref.Text = "" Then
            qty.Enabled = True
        ElseIf transtype.Text = "Issue" And Not xyzref.Text = "" Then
            qty.Enabled = True
        End If
    End Sub

    Private Sub qty_Leave(sender As Object, e As EventArgs) Handles qty.Leave
        If IsNumeric(qty.Text) And transtype.Text = "Allocation" Then
            Dim initial As Double = initialqty.Text
            Dim newqty As Double = qty.Text
            Dim alloc As Double = REFALLOC.Text
            Dim issue As Double = REFISSUE.Text

            Dim cancelled As Double = (alloc - initial)
            Dim minimum As Double = issue - cancelled
            If minimum < 0 Then
                minimum = 0
            End If
            minadj.Text = minimum
            KryptonLabel23.Text = "Minimum Qty"
            Dim allocation = (alloc - initial) + newqty
            If allocation < issue Then

                MessageBox.Show("allocation must be greater tha or equal to issue qty
minimum adjustmment for this transaction is " & minimum & "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                qty.Focus()
            End If
        ElseIf IsNumeric(qty.text) And transtype.text = "Issue" And xyz.text = "Allocation" Then
            Dim initial As Double = initialqty.Text
            Dim newqty As Double = qty.Text
            Dim alloc As Double = REFALLOC.Text
            Dim issue As Double = REFISSUE.Text
            Dim pscal As Double = physical.Text

            Dim cancelled As Double = (issue - initial)
            Dim maximum As Double = alloc - cancelled
            minadj.Text = maximum
            KryptonLabel23.Text = "Maximum Qty"
            Dim iss = cancelled + newqty
            If iss > alloc Then
                Timer1.Stop()
                MessageBox.Show("maximum quantity is " & maximum & "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                qty.Focus()
            End If
        ElseIf IsNumeric(qty.text) And transtype.text = "Issue" And xyz.text = "" Then
            'Dim initial As Double = initialqty.Text
            'Dim newqty As Double = qty.Text
            'Dim pscal As Double = physical.Text

            'Dim cancelled As Double = (pscal - initial)
            'Dim maximum As Double = pscal - cancelled
            'minadj.Text = maximum
            'KryptonLabel23.Text = "Maximum Qty"
            'Dim iss = cancelled + newqty
            'If iss > pscal Then
            '    Timer1.Stop()
            '    MessageBox.Show("maximum quantity is " & maximum & "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    qty.Focus()
            'End If
        ElseIf IsNumeric(qty.Text) Then

        Else

            qty.Focus()
            MessageBox.Show("invalid qty", "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub KryptonButton3_Click(sender As Object, e As EventArgs) Handles KryptonButton3.Click
        GETBALANCEALLOCISSUE(stockno.Text, reference.Text, JO.Text, XYZ.Text)

        If IsNumeric(qty.Text) And transtype.Text = "Allocation" Then
            Dim initial As Double = initialqty.Text
            Dim newqty As Double = qty.Text
            Dim alloc As Double = REFALLOC.Text
            Dim issue As Double = REFISSUE.Text

            Dim cancelled As Double = (alloc - initial)
            Dim minimum As Double = issue - cancelled
            If minimum < 0 Then
                minimum = 0
            End If
            minadj.Text = minimum
            KryptonLabel23.Text = "Minimum Qty"
            Dim allocation = (alloc - initial) + newqty
            If allocation < issue Then
                Timer1.Stop()
                MessageBox.Show("minimum quantity is " & minimum & "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                qty.Focus()
            End If

            If minimum > 0 Then
                turnfalse()
            End If
        ElseIf IsNumeric(qty.Text) And transtype.Text = "Issue" And XYZ.Text = "Allocation" Then
                Dim initial As Double = initialqty.Text
                Dim newqty As Double = qty.Text
                Dim alloc As Double = REFALLOC.Text
                Dim issue As Double = REFISSUE.Text
                Dim pscal As Double = physical.Text

                Dim cancelled As Double = (issue - initial)
                Dim maximum As Double = alloc - cancelled
                minadj.Text = maximum
                KryptonLabel23.Text = "Maximum Qty"
                Dim iss = cancelled + newqty
                If iss > alloc Then
                    Timer1.Stop()
                    MessageBox.Show("maximum quantity is " & maximum & "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    qty.Focus()
                End If
            ElseIf IsNumeric(qty.Text) And transtype.Text = "Issue" And XYZ.Text = "" Then
                'Dim initial As Double = initialqty.Text
                'Dim newqty As Double = qty.Text
                'Dim pscal As Double = physical.Text

                'Dim cancelled As Double = (pscal - initial)
                'Dim maximum As Double = pscal - cancelled
                'minadj.Text = maximum
                'KryptonLabel23.Text = "Maximum Qty"
                'Dim iss = cancelled + newqty
                'If iss > pscal Then
                '    Timer1.Stop()
                '    MessageBox.Show("maximum quantity is " & maximum & "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    qty.Focus()
                'End If
            ElseIf IsNumeric(qty.Text) Then
                Timer1.Stop()
            Else
                Timer1.Stop()
            qty.Focus()
            MessageBox.Show("invalid qty", "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Timer1.Stop()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        KryptonButton3.PerformClick()
    End Sub

    Private Sub stockno_TextChanged(sender As Object, e As EventArgs) Handles stockno.TextChanged
        getphysical(stockno.Text)
    End Sub
    Public Sub getphysical(ByVal stockno As String)
        Try
            sql.sqlcon.Close()
            sql.sqlcon.Open()
            Dim str As String = "select physical from stocks_tb where stockno = '" & stockno & "'"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            Dim read As SqlDataReader = sqlcmd.ExecuteReader
            While read.Read
                Dim x As String = read(0).ToString
                physical.Text = x
            End While
            read.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Private Sub newcosthead_MouseDown(sender As Object, e As MouseEventArgs) Handles newcosthead.MouseDown
        newstockno.Text = ""
        'newtypecolor.SelectedIndex = -1
        'newarticleno.SelectedIndex = -1
        Dim x As Integer = newcosthead.SelectedIndex
        Try
            sql.sqlcon.Open()
            Dim ds As New DataSet
            ds.Clear()
            Dim da As New SqlDataAdapter
            Dim bs As New BindingSource
            Dim str As String = "select distinct costhead from stocks_tb order by costhead asc"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            newcosthead.DataSource = bs
            newcosthead.DisplayMember = "costhead"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
        If x > newcosthead.Items.Count - 1 Then
            newcosthead.SelectedIndex = -1
        Else
            newcosthead.SelectedIndex = x
        End If
    End Sub

    Private Sub newtypecolor_MouseDown(sender As Object, e As MouseEventArgs) Handles newtypecolor.MouseDown
        newstockno.Text = ""
        'newarticleno.SelectedIndex = -1
        Dim x As Integer = newtypecolor.SelectedIndex
        If newcosthead.Text = "" Then
            typecolorgen1()
        Else
            typecolorgen(newcosthead.Text)
        End If
        If x > newtypecolor.Items.Count - 1 Then
            newtypecolor.SelectedIndex = -1
        Else
            newtypecolor.SelectedIndex = x
        End If
    End Sub
    Public Sub typecolorgen(ByVal costhead As String)
        Try
            sql.sqlcon.Open()
            Dim str As String = "select distinct typecolor FROM STOCKS_TB WHERE COSTHEAD = '" & costhead & "' order by typecolor asc"
            Dim ds As New DataSet
            ds.Clear()
            Dim da As New SqlDataAdapter
            Dim bs As New BindingSource
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            newtypecolor.DataSource = bs
            newtypecolor.DisplayMember = "typecolor"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub
    Public Sub typecolorgen1()
        Try
            sql.sqlcon.Open()
            Dim str As String = "select distinct typecolor FROM STOCKS_TB order by typecolor asc"
            Dim ds As New DataSet
            ds.Clear()
            Dim da As New SqlDataAdapter
            Dim bs As New BindingSource
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            newtypecolor.DataSource = bs
            newtypecolor.DisplayMember = "typecolor"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Private Sub newarticleno_MouseDown(sender As Object, e As MouseEventArgs) Handles newarticleno.MouseDown

        Dim i As Integer = newarticleno.SelectedIndex
        If newcosthead.Text = "" And newtypecolor.Text = "" Then
            articlenogen1()
        ElseIf Not newcosthead.Text = "" And newtypecolor.Text = "" Then
            articlenogen2(newcosthead.Text)
        ElseIf newcosthead.Text = "" And Not newtypecolor.Text = "" Then
            articlenogen3(newtypecolor.Text)
        Else
            articlenogen(newcosthead.Text, newtypecolor.Text)
        End If
        If i > newarticleno.Items.Count - 1 Then
            newarticleno.SelectedIndex = -1
        Else
            newarticleno.SelectedIndex = i
        End If
    End Sub
    Public Sub articlenogen(ByVal costhead As String, ByVal typecolor As String)
        Try
            sql.sqlcon.Open()
            Dim str As String = "select articleno,stockno FROM STOCKS_TB where costhead = '" & costhead & "' and typecolor= '" & typecolor & "' order by articleno asc"
            Dim ds As New DataSet
            ds.Clear()
            Dim da As New SqlDataAdapter
            Dim bs As New BindingSource
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            newarticleno.DataSource = bs
            newarticleno.DisplayMember = "articleno"
            newstockno.DataBindings.Clear()
            newstockno.DataBindings.Add("text", bs, "stockno")
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub
    Public Sub articlenogen1()
        Try
            sql.sqlcon.Open()
            Dim str As String = "select distinct articleno,stockno FROM STOCKS_TB order by articleno asc"
            Dim ds As New DataSet
            ds.Clear()
            Dim da As New SqlDataAdapter
            Dim bs As New BindingSource
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            newarticleno.DataSource = bs
            newarticleno.DisplayMember = "articleno"
            newstockno.DataBindings.Clear()
            newstockno.DataBindings.Add("text", bs, "stockno")
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub
    Public Sub articlenogen2(ByVal costhead As String)
        Try
            sql.sqlcon.Open()
            Dim str As String = "select distinct articleno,stockno FROM STOCKS_TB where costhead = '" & costhead & "' order by articleno asc"
            Dim ds As New DataSet
            ds.Clear()
            Dim da As New SqlDataAdapter
            Dim bs As New BindingSource
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            newarticleno.DataSource = bs
            newarticleno.DisplayMember = "articleno"
            newstockno.DataBindings.Clear()
            newstockno.DataBindings.Add("text", bs, "stockno")
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub
    Public Sub articlenogen3(ByVal typecolor As String)
        Try
            sql.sqlcon.Open()
            Dim str As String = "select distinct articleno,stockno FROM STOCKS_TB where typecolor = '" & typecolor & "' order by articleno asc"
            Dim ds As New DataSet
            ds.Clear()
            Dim da As New SqlDataAdapter
            Dim bs As New BindingSource
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            newarticleno.DataSource = bs
            newarticleno.DisplayMember = "articleno"
            newstockno.DataBindings.Clear()
            newstockno.DataBindings.Add("text", bs, "stockno")
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Private Sub newreference_MouseDown(sender As Object, e As MouseEventArgs) Handles newreference.MouseDown
        Dim i As Integer = newreference.SelectedIndex
        Try
            sql.sqlcon.Open()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter
            Dim bs As New BindingSource
            Dim str As String
            str = "select distinct reference from trans_tb order by reference asc"
            ds.Clear()
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "trans_tb")
            bs.DataSource = ds
            bs.DataMember = "trans_tb"
            newreference.DataSource = bs
            newreference.DisplayMember = "reference"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
        If i > newreference.Items.Count - 1 Then
            newreference.SelectedIndex = -1
        Else
            newreference.SelectedIndex = i
        End If
        Form2.genjo("FORM5", newreference.Text, Me.NEWJO, "trans_tb", "jo")
    End Sub

    Private Sub Form5_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        transtype.Text = ""
        KryptonCheckBox1.Checked = False
        newcosthead.SelectedIndex = -1
        newtypecolor.SelectedIndex = -1
        newarticleno.SelectedIndex = -1
        newstockno.Text = ""
        KryptonCheckBox2.Checked = False
        newreference.SelectedIndex = -1
        NEWJO.SelectedIndex = -1
        If itcame.Text = "A" Then
            Dim counter As Integer = Form4.mytransgridview.CurrentRow.Index
            Dim nextRow As DataGridViewRow
            Form4.KryptonButton4.PerformClick()
            Form4.mytransgridview.ClearSelection()
            If Form4.mytransgridview.Rows.Count > 0 Then
                nextRow = Form4.mytransgridview.Rows(counter)
                nextRow.Selected = True
            End If
        ElseIf itcame.Text = "RECEIPT" Then
            sql.selectreceiptreferencerecord(Form2.receiptreference.Text, Form2.receiptjo.Text)
        End If
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
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

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        'If e.Button = MouseButtons.Right Then
        '    Dim t As New Transition(New TransitionType_Acceleration(1000))
        '    t.add(Panel1, "BackColor", Color.White)

        '    t.run()
        'End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

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

    Private Sub newcosthead_Leave(sender As Object, e As EventArgs) Handles newcosthead.Leave
        'newtypecolor.SelectedIndex = -1
        'newarticleno.SelectedIndex = -1


        Try
                sql.sqlcon.Open()
                Dim str As String = "select from stocks_tb where costhead='" & newcosthead.Text & "' and typecolor = '" & newtypecolor.Text & "'"
                sqlcmd = New SqlCommand(str, sql.sqlcon)
                Dim read As SqlDataReader = sqlcmd.ExecuteReader
                If read.HasRows = True Then
                    read.Close()
                Else
                    read.Close()
                    newtypecolor.SelectedIndex = -1
                End If
            Catch ex As Exception
            Finally
                sql.sqlcon.Close()
            End Try


        If Not newarticleno.Text = "" Then
            Try
                sql.sqlcon.Open()
                Dim str As String = "select from stocks_tb where costhead='" & newcosthead.Text & "' and articleno = '" & newarticleno.Text & "'"
                sqlcmd = New SqlCommand(str, sql.sqlcon)
                Dim read As SqlDataReader = sqlcmd.ExecuteReader
                If read.HasRows = True Then
                    read.Close()
                Else
                    read.Close()
                    newarticleno.SelectedIndex = -1
                End If
            Catch ex As Exception
            Finally
                sql.sqlcon.Close()
            End Try
        Else

        End If

    End Sub

    Private Sub newtypecolor_Leave(sender As Object, e As EventArgs) Handles newtypecolor.Leave
        Try
            sql.sqlcon.Open()
            Dim str As String = "select stockno from stocks_tb where costhead= '" & newcosthead.Text & "'
and typecolor = '" & newtypecolor.Text & "' and articleno = '" & newarticleno.Text & "'"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            Dim da As New SqlDataAdapter
            Dim bs As New BindingSource
            Dim ds As New DataSet
            ds.Clear()
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            newstockno.DataBindings.Clear()
            newstockno.DataBindings.Add("text", bs, "stockno")
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Private Sub adjustment_Leave(sender As Object, e As EventArgs) Handles adjustment.Leave
        If IsNumeric(adjustment.Text) Then
        Else
            MsgBox("invalid qty")
            adjustment.Focus()
        End If
    End Sub
    Dim tempbol As Boolean = True
    Public mastr As String
    Private Sub KryptonButton4_Click(sender As Object, e As EventArgs) Handles KryptonButton4.Click
        If tempbol = True Then
            mastr = ADJUSTMENTREMARKS.Text
            tempbol = False
        End If
        qty.Text = Double.Parse(initialqty.Text) + Double.Parse(adjustment.Text)
        workonremarks("+")
        qty.Focus()
    End Sub

    Private Sub KryptonButton5_Click(sender As Object, e As EventArgs) Handles KryptonButton5.Click
        If tempbol = True Then
            mastr = ADJUSTMENTREMARKS.Text
            tempbol = False
        End If
        qty.Text = Double.Parse(initialqty.Text) - Double.Parse(adjustment.Text)
        workonremarks("-")
        qty.Focus()
    End Sub
    Public Sub workonremarks(ByVal tr As String)
        Dim total As Double = 0
        Dim numbers() As String
        Dim chars As String
        Dim newremarks As String
        If tr = "+" Then
            numbers = Split(mastr + "+" + adjustment.Text, "+")
        ElseIf tr = "-" Then
            numbers = Split(mastr + "+" + "" & (Double.Parse(adjustment.Text) * -1) & "", "+")
        End If

        For Each number In numbers
            total = total + Val(number)
            chars = chars + "+" + "" & Val(number) & ""
        Next
        newremarks = chars + "=" + "" & total & ""
        ADJUSTMENTREMARKS.Text = newremarks.Remove(0, 1)
    End Sub
    Private Sub newreference_TextChanged(sender As Object, e As EventArgs) Handles newreference.TextChanged
        Form2.genjo("FORM5", newreference.Text, Me.NEWJO, "trans_tb", "jo")
    End Sub

    Private Sub NEWJO_MouseDown(sender As Object, e As MouseEventArgs) Handles NEWJO.MouseDown
        Form2.genjo("FORM5", newreference.Text, Me.NEWJO, "trans_tb", "jo")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        genreferenceFRM.Text = "form5"
        genreferenceFRM.ShowDialog()
    End Sub
End Class
Imports System.Data.SqlClient
Public Class reallocate
    Dim sql As New sql
    Public sqlcmd As New sqlcommand
    Private Sub cancelorderbtn_Click(sender As Object, e As EventArgs) Handles cancelorderbtn.Click
        If MessageBox.Show("Reallocate cancelled allocations?", "Click Yes To Proceed", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.No Then
            MessageBox.Show("Operation Cancelled", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        For i As Integer = 0 To transno.Items.Count - 1
            Dim t As String = transno.Items(i).ToString
            Dim s As String = stockno.Items(i).ToString
            Dim r As String = reference.Items(i).ToString
            Dim q As String = jo.Items(i).ToString
            reallocate(t)
            updatestock(s, r, q)
        Next
        Me.Close()
        Form2.KryptonButton10.PerformClick()
    End Sub
    Public Sub reallocate(ByVal tno As String)
        Try
            sql.sqlcon.Open()
            Dim str As String = "
declare @id as integer = (select max(transno)+1 from trans_tb)

insert into trans_tb 
     (transno,STOCKNO,
            TRANSTYPE,
            TRANSDATE,
            DUEDATE,
            QTY,
            BALQTY,
            REFERENCE,jo,
            ACCOUNT,
            CONTROLNO,
            XYZ,
            XYZREF,
            REMARKS,
            INPUTTED) 
select
            @id,STOCKNO,
            'Allocation',
            '" & Form2.transdate.Text & "',
            '',
            QTY,
            QTY,
            REFERENCE,jo,
            '',
            '',
            '',
            '',
            '',
            '" & Form1.Label1.Text & "'
 from trans_tb where transno = '" & tno & "' and transtype='CancelAlloc'"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            sqlcmd.ExecuteNonQuery()

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
                                    declare @allocation as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' and jo = '" & jo & "' AND TRANSTYPE='Allocation')+0
                                    declare @cancelalloc as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' and jo = '" & jo & "' AND TRANSTYPE='CancelAlloc')+0
                                    declare @order as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' and jo = '" & jo & "' AND TRANSTYPE='Order')+0
                                    declare @return as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' and jo = '" & jo & "' AND TRANSTYPE='Return')+0
                                    declare @receipt as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' and jo = '" & jo & "' AND TRANSTYPE='Receipt' AND NOT XYZ='Order')+0
                                    declare @issue as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' and jo = '" & jo & "' AND TRANSTYPE='Issue' AND NOT XYZ ='Allocation')+0
                                    declare @receiptorder as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' and jo = '" & jo & "' AND TRANSTYPE='Receipt' AND XYZ='Order')+0
                                    declare @issueallocation as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' and jo = '" & jo & "' AND TRANSTYPE='Issue' AND XYZ ='Allocation')+0
                                    declare @totalreceipt as decimal(10,2)=@receipt+@receiptorder
                                    declare @totalissue as decimal(10,2)=@issue+@issueallocation
                              
update reference_tb set 

                                    allocation=@allocation-(@issueallocation+@cancelalloc),
                                    stockorder=@order-@receiptorder,
                                    TOTALRECEIPT=@totalreceipt,
                                    totalissue=@totalissue,
                                    totalreturn=@return
                                    where stockno='" & stockno & "' and reference='" & reference & "'  and jo = '" & jo & "'"
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

    Private Sub reallocate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Form1.Label2.Text = "Guest" Then
            cancelorderbtn.Enabled = False
        ElseIf Form1.Label2.Text = "Admin" Or Form1.Label2.Text = "Encoder" Then
            cancelorderbtn.Enabled = True
        End If

    End Sub
End Class
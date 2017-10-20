Imports System.Data.SqlClient
Imports Transitions
Public Class multimove
    Dim xm As Integer
    Dim ym As Integer
    Dim drag As Boolean
    Dim sqlcmd As New SqlCommand
    Dim sql As New sql
    Dim meme As Integer
    Private Sub Panel3_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel3.MouseMove
        If drag Then
            Me.Left = Cursor.Position.X - xm
            Me.Top = Cursor.Position.Y - ym
        End If
    End Sub

    Private Sub Panel3_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel3.MouseUp
        drag = False
    End Sub

    Private Sub Panel3_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel3.MouseDown
        drag = True
        xm = Cursor.Position.X - Me.Left
        ym = Cursor.Position.Y - Me.Top
    End Sub

    Private Sub KryptonButton1_Click(sender As Object, e As EventArgs) Handles KryptonButton1.Click
        reference.Text = reference.Text.Replace("'", "`")
        reference.Text = reference.Text.Replace("""", "``")

        If KryptonLabel6.Text = "Move Allocation" Then
            If MessageBox.Show("move all allocation?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                MessageBox.Show("Operation Cancelled", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            ProgressBar1.Value = 0
            ProgressBar1.Visible = True
            ProgressBar1.Maximum = Form2.refcombo.Items.Count
            For i As Integer = 0 To Form2.refcombo.Items.Count - 1
                Dim oldreference As String = Form2.refcombo.Items(i).ToString()
                Dim oldstockno As String = Form2.refstock.Items(i).ToString()
                If KryptonCheckBox1.Checked = True And KryptonCheckBox2.Checked = True Then
                    If newstockno.Text = "" And reference.Text = "" Then
                        MessageBox.Show("invalid stockno and reference", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        mallocation(oldstockno, oldreference)
                    End If
                ElseIf KryptonCheckBox1.Checked = True And KryptonCheckBox2.Checked = False Then
                    If newstockno.Text = "" Then
                        MessageBox.Show("invalid stockno", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        sallocation(oldstockno, oldreference)
                    End If
                ElseIf KryptonCheckBox1.Checked = False And KryptonCheckBox2.Checked = True Then
                    If reference.Text = "" Then
                        MessageBox.Show("invalid reference", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        rallocation(oldstockno, oldreference)
                    End If
                Else
                End If
                ProgressBar1.Value = ProgressBar1.Value + 1
            Next
        ElseIf KryptonLabel6.Text = "Move Order" Then
            If MessageBox.Show("move all order?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                MessageBox.Show("Operation Cancelled", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            ProgressBar1.Value = 0
            ProgressBar1.Visible = True
            ProgressBar1.Maximum = Form2.refcombo.Items.Count
            For i As Integer = 0 To Form2.refcombo.Items.Count - 1
                Dim oldreference As String = Form2.refcombo.Items(i).ToString()
                Dim oldstockno As String = Form2.refstock.Items(i).ToString()
                If KryptonCheckBox1.Checked = True And KryptonCheckBox2.Checked = True Then
                    If newstockno.Text = "" And reference.Text = "" Then
                        MessageBox.Show("invalid stockno and reference", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        morder(oldstockno, oldreference)
                    End If
                ElseIf KryptonCheckBox1.Checked = True And KryptonCheckBox2.Checked = False Then
                    If newstockno.Text = "" Then
                        MessageBox.Show("invalid stockno", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        sorder(oldstockno, oldreference)
                    End If
                ElseIf KryptonCheckBox1.Checked = False And KryptonCheckBox2.Checked = True Then
                    If reference.Text = "" Then
                        MessageBox.Show("invalid reference", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        rorder(oldstockno, oldreference)
                    End If
                Else
                End If
                ProgressBar1.Value = ProgressBar1.Value + 1
            Next
        Else
        End If
        Form2.KryptonButton12.PerformClick()
    End Sub
    Public Sub mallocation(ByVal oldstockno As String, ByVal oldreference As String)

        'update old reference to make sure data is accurate
        updatereference(oldstockno, oldreference)
        'cancel and insert new allocation for new reference
        cancelalloc(oldstockno, oldreference, newstockno.Text, reference.Text)
        'update old reference
        updatereference(oldstockno, oldreference)
        autoupdatestock(oldstockno)
        'update new reference
        updatereference(newstockno.Text, reference.Text)
        autoupdatestock(newstockno.Text)
    End Sub
    Public Sub sallocation(ByVal oldstockno As String, ByVal oldreference As String)

        'update old reference to make sure data is accurate
        updatereference(oldstockno, oldreference)
        'cancel and insert new allocation for new reference
        cancelalloc(oldstockno, oldreference, newstockno.Text, oldreference)
        'update old reference
        updatereference(oldstockno, oldreference)
        autoupdatestock(oldstockno)
        'update new reference
        updatereference(newstockno.Text, oldreference)
        autoupdatestock(newstockno.Text)
    End Sub
    Public Sub rallocation(ByVal oldstockno As String, ByVal oldreference As String)

        'update old reference to make sure data is accurate
        updatereference(oldstockno, oldreference)
        'cancel and insert new allocation for new reference
        cancelalloc(oldstockno, oldreference, oldstockno, reference.Text)
        'update old reference
        updatereference(oldstockno, oldreference)
        autoupdatestock(oldstockno)
        'update new reference
        updatereference(oldstockno, reference.Text)
        autoupdatestock(oldstockno)
    End Sub
    Public Sub morder(ByVal oldstockno As String, ByVal oldreference As String)

        'update old reference to make sure data is accurate
        updatereference(oldstockno, oldreference)
        'cancel and insert new order for new reference
        cancelorder(oldstockno, oldreference, newstockno.Text, reference.Text)
        'update old reference
        updatereference(oldstockno, oldreference)
        autoupdatestock(oldstockno)
        'update new reference
        updatereference(newstockno.Text, reference.Text)
        autoupdatestock(newstockno.Text)

    End Sub
    Public Sub sorder(ByVal oldstockno As String, ByVal oldreference As String)

        'update old reference to make sure data is accurate
        updatereference(oldstockno, oldreference)
        'cancel and insert new order for new reference
        cancelorder(oldstockno, oldreference, newstockno.Text, oldreference)
        'update old reference
        updatereference(oldstockno, oldreference)
        autoupdatestock(oldstockno)
        'update new reference
        updatereference(newstockno.Text, oldreference)
        autoupdatestock(newstockno.Text)

    End Sub
    Public Sub rorder(ByVal oldstockno As String, ByVal oldreference As String)

        'update old reference to make sure data is accurate
        updatereference(oldstockno, oldreference)
        'cancel and insert new order for new reference
        cancelorder(oldstockno, oldreference, oldstockno, reference.Text)
        'update old reference
        updatereference(oldstockno, oldreference)
        autoupdatestock(oldstockno)
        'update new reference
        updatereference(oldstockno, reference.Text)
        autoupdatestock(oldstockno)

    End Sub
    Public Sub cancelorder(ByVal stockno As String, ByVal reference As String, ByVal nstockno As String, ByVal newreference As String)
        Try
            sql.sqlcon.Open()
            Dim newcancelorder As String = "
  declare @order as decimal(10,2)=(select  COALESCE(stockorder,0) from reference_tb where stockno ='" & stockno & "' and reference = '" & reference & "')+0


insert into trans_tb 
     (STOCKNO,
            TRANSTYPE,
            TRANSDATE,
            DUEDATE,
            QTY,
            REFERENCE,
            ACCOUNT,
            CONTROLNO,XYZ,XYZREF,REMARKS,INPUTTED) values ('" & nstockno & "'," &
         "'Order'," &
         "'" & Form2.transdate.Text & "'," &
         "''," &
         "@order," &
         "'" & newreference & "'," &
         "''," &
         "''," &
            "''," &
              "''," &
         "''," &
            "'" & Form1.Label1.Text & "')

update trans_tb set qty = 0,xyzref='canceled' where stockno = '" & stockno & "' and reference = '" & reference & "' and xyzref='' and transtype='Order'"
            sqlcmd = New SqlCommand(newcancelorder, sql.sqlcon)
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
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub
    Public Sub updatereference(ByVal stockno As String, ByVal reference As String)
        Try
            sql.sqlcon.Open()
            Dim find As String = "select * from reference_tb where reference='" & reference & "' and stockno='" & stockno & "'"
            sqlcmd = New SqlCommand(find, sql.sqlcon)
            Dim read As SqlDataReader = sqlcmd.ExecuteReader
            If read.HasRows = True Then
                read.Close()
            Else
                read.Close()
                Dim insert As String = "insert into reference_tb (reference,stockno) values('" & reference & "','" & stockno & "')"
                sqlcmd = New SqlCommand(insert, sql.sqlcon)
                sqlcmd.ExecuteNonQuery()
            End If


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
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub
    Public Sub cancelalloc(ByVal stockno As String, ByVal reference As String, ByVal nstockno As String, ByVal newreference As String)
        Try
            sql.sqlcon.Open()
            Dim newcancelalloc As String = "
  declare @allocation as decimal(10,2)=(select  COALESCE(allocation,0) from reference_tb where stockno ='" & stockno & "' and reference = '" & reference & "')+0


insert into trans_tb 
     (STOCKNO,
            TRANSTYPE,
            TRANSDATE,
            DUEDATE,
            QTY,
  balqty,
            REFERENCE,
            ACCOUNT,
            CONTROLNO,XYZ,XYZREF,REMARKS,INPUTTED) values ('" & nstockno & "'," &
         "'Allocation'," &
         "'" & Form2.transdate.Text & "'," &
         "''," &
         "@allocation," &
            "@allocation," &
         "'" & newreference & "'," &
         "''," &
         "''," &
            "''," &
              "''," &
         "''," &
            "'" & Form1.Label1.Text & "')



insert into trans_tb 
     (STOCKNO,
            TRANSTYPE,
            TRANSDATE,
            DUEDATE,
            QTY,
            REFERENCE,
            ACCOUNT,
            CONTROLNO,XYZ,XYZREF,REMARKS,INPUTTED) values ('" & stockno & "'," &
         "'CancelAlloc'," &
         "'" & Form2.transdate.Text & "'," &
         "''," &
         "@allocation," &
         "'" & reference & "'," &
         "''," &
         "''," &
            "''," &
              "''," &
         "''," &
            "'" & Form1.Label1.Text & "')"
            sqlcmd = New SqlCommand(newcancelalloc, sql.sqlcon)
            sqlcmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ProgressBar1.Visible = False
        KryptonCheckBox1.Checked = False
        KryptonCheckBox1.Checked = False
        Me.Close()
    End Sub

    Private Sub reference_MouseDown(sender As Object, e As MouseEventArgs) Handles reference.MouseDown
        Dim i As Integer = reference.SelectedIndex
        loadreference()

        If i > reference.Items.Count - 1 Then
            reference.SelectedIndex = -1
        Else
            reference.SelectedIndex = i
        End If
    End Sub

    Private Sub newcosthead_MouseDown(sender As Object, e As MouseEventArgs) Handles newcosthead.MouseDown
        newstockno.Text = ""
        newtypecolor.SelectedIndex = -1
        newarticleno.SelectedIndex = -1
        Dim x As Integer = newcosthead.SelectedIndex
        Try
            sql.sqlcon.Open()
            Dim ds As New DataSet
            ds.Clear()
            Dim da As New SqlDataAdapter
            Dim bs As New BindingSource
            Dim str As String = "Select distinct costhead from stocks_tb order by costhead asc"
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
        newarticleno.SelectedIndex = -1
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
    Public Sub loadreference()
        Try
            sql.sqlcon.Open()
            Dim str As String = "select distinct reference from trans_tb order by reference asc"
            Dim ds As New DataSet
            ds.Clear()
            Dim da As New SqlDataAdapter
            Dim bs As New BindingSource
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "trans_tb")
            bs.DataSource = ds
            bs.DataMember = "trans_tb"
            reference.DataSource = bs
            reference.DisplayMember = "reference"
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub
    Public Sub typecolorgen(ByVal costhead As String)
        Try
            sql.sqlcon.Open()
            Dim str As String = "Select distinct typecolor FROM STOCKS_TB WHERE COSTHEAD = '" & costhead & "' order by typecolor asc"
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

    Private Sub multimove_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        meme = 0
        If Form1.Label2.Text = "Guest" Then
            KryptonButton1.Enabled = False
        ElseIf Form1.Label2.Text = "Admin" Or Form1.Label2.Text = "Encoder" Then
            KryptonButton1.Enabled = True
        End If
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        If e.Button = MouseButtons.Right Then
            Dim t As New Transition(New TransitionType_EaseInEaseOut(1000))
            If meme = 1 Then
                t.add(Panel1, "BackColor", Color.FromArgb(11, 19, 36))
                KryptonLabel1.StateCommon.ShortText.Color1 = Color.White
                KryptonLabel2.StateCommon.ShortText.Color1 = Color.White
                KryptonLabel3.StateCommon.ShortText.Color1 = Color.White
                KryptonCheckBox2.StateCommon.ShortText.Color1 = Color.White

                meme = 0
                t.run()
            ElseIf meme = 0 Then
                t.add(Panel1, "BackColor", Color.WhiteSmoke)
                meme = 1
                KryptonLabel1.StateCommon.ShortText.Color1 = Color.Black
                KryptonLabel2.StateCommon.ShortText.Color1 = Color.Black
                KryptonLabel3.StateCommon.ShortText.Color1 = Color.Black
                KryptonCheckBox2.StateCommon.ShortText.Color1 = Color.Black

                t.run()

            End If
        End If
    End Sub
End Class
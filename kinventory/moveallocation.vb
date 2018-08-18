Imports System.Data.SqlClient
Imports Transitions
Public Class moveallocation
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Dim sql As New sql
    Dim sqlcmd As New SqlCommand
    Dim meme As Integer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        newstockno.DataBindings.Clear()
        newstockno.DataBindings.Add("text", Form2.referencebs, "STOCKNO")
        Me.Close()
    End Sub

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

    Private Sub reference_MouseDown(sender As Object, e As MouseEventArgs) Handles reference.MouseDown
        Dim i As Integer = reference.SelectedIndex
        loadreference()

        If i > reference.Items.Count - 1 Then
            reference.SelectedIndex = -1
        Else
            reference.SelectedIndex = i
        End If
        Form2.genjo("moveallocation", Me.reference.Text, Me.jo, "trans_tb", "jo")
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

    Private Sub moveallocation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        meme = 0
        If Form1.Label2.Text = "Guest" Then
            KryptonButton1.Enabled = False
        ElseIf Form1.Label2.Text = "Admin" Or Form1.Label2.Text = "Encoder" Then
            KryptonButton1.Enabled = True
        End If
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
    Public Sub updatereference(ByVal stockno As String, ByVal reference As String, ByVal jo As String)
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
                        declare @id as integer =(select max(id)+1 from reference_tb)
                        insert into reference_tb (id,reference,jo,stockno) values(@id,'" & reference & "','" & jo & "','" & stockno & "')"
                sqlcmd = New SqlCommand(insert, sql.sqlcon)
                sqlcmd.ExecuteNonQuery()
            End If


            Dim bny As String = "
                                    declare @allocation as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' and jo ='" & jo & "' AND TRANSTYPE='Allocation')+0
                                    declare @cancelalloc as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' and jo ='" & jo & "' AND TRANSTYPE='CancelAlloc')+0
                                    declare @order as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' and jo ='" & jo & "' AND TRANSTYPE='Order')+0
                                    declare @return as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' and jo ='" & jo & "' AND TRANSTYPE='Return')+0
                                    declare @receipt as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' and jo ='" & jo & "' AND TRANSTYPE='Receipt' AND NOT XYZ='Order')+0
                                    declare @issue as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' and jo ='" & jo & "' AND TRANSTYPE='Issue' AND NOT XYZ ='Allocation')+0
                                    declare @receiptorder as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' and jo ='" & jo & "' AND TRANSTYPE='Receipt' AND XYZ='Order')+0
                                    declare @issueallocation as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno ='" & stockno & "' and reference = '" & reference & "' and jo ='" & jo & "' AND TRANSTYPE='Issue' AND XYZ ='Allocation')+0
                                    declare @totalreceipt as decimal(10,2)=@receipt+@receiptorder
                                    declare @totalissue as decimal(10,2)=@issue+@issueallocation
                              
update reference_tb set 

                                    allocation=@allocation-(@issueallocation+@cancelalloc),
                                    stockorder=@order-@receiptorder,
                                    TOTALRECEIPT=@totalreceipt,
                                    totalissue=@totalissue,
                                    totalreturn=@return
                                    where stockno='" & stockno & "' and reference='" & reference & "' and jo = '" & jo & "'"
            sqlcmd = New SqlCommand(bny, sql.sqlcon)
            sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub
    Public Sub cancelalloc(ByVal stockno As String, ByVal reference As String, ByVal jo As String, ByVal nstockno As String, ByVal newreference As String, ByVal newjo As String)
        Try
            sql.sqlcon.Open()
            Dim newcancelalloc As String = "
  declare @allocation as decimal(10,2)=(select  COALESCE(allocation,0) from reference_tb where stockno ='" & stockno & "' 
and reference = '" & reference & "' and jo = '" & jo & "')+0

declare @id as integer =(select max(transno)+1 from trans_tb)
insert into trans_tb 
     (transno,STOCKNO,
            TRANSTYPE,
            TRANSDATE,
            DUEDATE,
            QTY,
  balqty,
            REFERENCE,jo,
            ACCOUNT,
            CONTROLNO,XYZ,XYZREF,REMARKS,INPUTTED) values (@id,'" & nstockno & "'," &
         "'Allocation'," &
         "'" & Form2.transdate.Text & "'," &
         "''," &
         "@allocation," &
           "@allocation," &
         "'" & newreference & "'," &
                "'" & newjo & "'," &
         "''," &
         "''," &
            "''," &
              "''," &
         "''," &
            "'" & Form1.Label1.Text & "')

declare @id1 as integer =(select max(transno)+1 from trans_tb)

insert into trans_tb 
     (transno,STOCKNO,
            TRANSTYPE,
            TRANSDATE,
            DUEDATE,
            QTY,
            REFERENCE,jo,
            ACCOUNT,
            CONTROLNO,XYZ,XYZREF,REMARKS,INPUTTED) values (@id1,'" & stockno & "'," &
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
            "'" & Form1.Label1.Text & "')"
            sqlcmd = New SqlCommand(newcancelalloc, sql.sqlcon)
            sqlcmd.ExecuteNonQuery()
            MessageBox.Show("All allocation have been moved", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub
    Public Sub cancelorder(ByVal stockno As String, ByVal reference As String, ByVal jo As String, ByVal nstockno As String, ByVal newreference As String, ByVal newjo As String)
        Try
            sql.sqlcon.Open()
            Dim newcancelorder As String = "
  declare @order as decimal(10,2)=(select  COALESCE(stockorder,0) from reference_tb where stockno ='" & stockno & "' and reference = '" & reference & "' and jo = '" & jo & "')+0

declare @id as integer = (select max(transno)+1 from trans_tb)
insert into trans_tb 
     (transno,STOCKNO,
            TRANSTYPE,
            TRANSDATE,
            DUEDATE,
            QTY,
            REFERENCE,jo
            ACCOUNT,
            CONTROLNO,XYZ,XYZREF,REMARKS,INPUTTED) values (@id,'" & nstockno & "'," &
         "'Order'," &
         "'" & Form2.transdate.Text & "'," &
         "''," &
         "@order," &
         "'" & newreference & "'," &
               "'" & newjo & "'," &
         "''," &
         "''," &
            "''," &
              "''," &
         "''," &
            "'" & Form1.Label1.Text & "')

update trans_tb set qty = 0,xyzref='canceled' where stockno = '" & stockno & "' and reference = '" & reference & "'
            and jo='" & jo & "' and xyzref='' and transtype='Order'"
            sqlcmd = New SqlCommand(newcancelorder, sql.sqlcon)
            sqlcmd.ExecuteNonQuery()
            MessageBox.Show("All order have been moved", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub
    Private Sub KryptonLabel1_Paint(sender As Object, e As PaintEventArgs) Handles KryptonLabel1.Paint

    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs)

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
    Private Sub KryptonButton1_Click(sender As Object, e As EventArgs) Handles KryptonButton1.Click
        reference.Text = reference.Text.Replace("'", "`")
        reference.Text = reference.Text.Replace("""", "``")
        If reference.Text = "" Then
            MessageBox.Show("input reference to proceed", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            If KryptonLabel8.Text = "Move Allocation" Then
                mallocation()
            ElseIf KryptonLabel8.Text = "Move Order" Then
                morder()
            End If
        End If

    End Sub
    Public Sub mallocation()
        If editreference.allocation.Text = "0" Or editreference.allocation.Text = "" Then
            MessageBox.Show("No allocation found", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf reference.Text = "" Or newstockno.Text = "" Then
            MessageBox.Show("Incorrect Destination", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf editreference.stockno.Text = newstockno.Text And editreference.reference.Text = reference.Text Then
            MessageBox.Show("No changes found", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            If MessageBox.Show("move all allocation?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                MessageBox.Show("Operation Cancelled", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            'update old reference to make sure data is accurate
            updatereference(editreference.stockno.Text, editreference.reference.Text, editreference.jo.Text)
            'cancel and insert new allocation for new reference
            cancelalloc(editreference.stockno.Text, editreference.reference.Text, editreference.jo.Text, newstockno.Text, reference.Text, jo.Text)
            'update old reference
            updatereference(editreference.stockno.Text, editreference.reference.Text, editreference.jo.Text)
            autoupdatestock(editreference.stockno.Text)
            'update new reference
            updatereference(newstockno.Text, reference.Text, jo.Text)
            autoupdatestock(newstockno.Text)
            Form2.KryptonButton12.PerformClick()
            Button1.PerformClick()
        End If
    End Sub
    Public Sub morder()
        If editreference.order.Text = "0" Or editreference.order.Text = "" Then
            MessageBox.Show("No order found", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf reference.Text = "" Or newstockno.Text = "" Then
            MessageBox.Show("Incorrect Destination", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf editreference.stockno.Text = newstockno.Text And editreference.reference.Text = reference.Text Then
            MessageBox.Show("No changes found", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            If MessageBox.Show("move all order?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                MessageBox.Show("Operation Cancelled", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            'update old reference to make sure data is accurate
            updatereference(editreference.stockno.Text, editreference.reference.Text, editreference.jo.Text)
            'cancel and insert new order for new reference
            cancelorder(editreference.stockno.Text, editreference.reference.Text, editreference.jo.Text, newstockno.Text, reference.Text, jo.Text)
            'update old reference
            updatereference(editreference.stockno.Text, editreference.reference.Text, editreference.jo.Text)
            autoupdatestock(editreference.stockno.Text)
            'update new reference
            updatereference(newstockno.Text, reference.Text, jo.Text)
            autoupdatestock(newstockno.Text)
            Form2.KryptonButton12.PerformClick()
            Button1.PerformClick()
        End If
    End Sub
    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        If e.Button = MouseButtons.Right Then
            Dim t As New Transition(New TransitionType_Acceleration(1000))
            If meme = 1 Then
                t.add(Panel1, "BackColor", Color.FromArgb(11, 19, 36))
                KryptonLabel1.StateCommon.ShortText.Color1 = Color.White
                KryptonLabel2.StateCommon.ShortText.Color1 = Color.White
                KryptonLabel3.StateCommon.ShortText.Color1 = Color.White
                KryptonLabel4.StateCommon.ShortText.Color1 = Color.White

                meme = 0
                t.run()
            ElseIf meme = 0 Then
                t.add(Panel1, "BackColor", Color.WhiteSmoke)
                meme = 1
                KryptonLabel1.StateCommon.ShortText.Color1 = Color.Black
                KryptonLabel2.StateCommon.ShortText.Color1 = Color.Black
                KryptonLabel3.StateCommon.ShortText.Color1 = Color.Black
                KryptonLabel4.StateCommon.ShortText.Color1 = Color.Black

                t.run()
            End If
        End If

    End Sub

    Private Sub reference_TextChanged(sender As Object, e As EventArgs) Handles reference.TextChanged
        Form2.genjo("moveallocation", Me.reference.Text, Me.jo, "trans_tb", "jo")
    End Sub

    Private Sub jo_MouseDown(sender As Object, e As MouseEventArgs) Handles jo.MouseDown
        Form2.genjo("moveallocation", reference.Text, Me.jo, "trans_tb", "jo")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        genreferenceFRM.Text = "movealloc"
        genreferenceFRM.ShowDialog()
    End Sub


End Class
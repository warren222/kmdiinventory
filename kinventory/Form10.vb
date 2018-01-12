Imports System.Data.SqlClient
Imports Transitions
Public Class Form10
    Dim sql As New sql
    Dim drag As Boolean
    Dim xm As Integer
    Dim ym As Integer
    Dim sqlcmd As New SqlCommand


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Panel3_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel3.MouseDown
        drag = True
        xm = Cursor.Position.X - Me.Left
        ym = Cursor.Position.Y - Me.Top
    End Sub
    Private Sub Panel3_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel3.MouseUp
        drag = False
    End Sub

    Private Sub Panel3_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel3.MouseMove
        If drag Then
            Me.Left = Cursor.Position.X - xm
            Me.Top = Cursor.Position.Y - ym
        End If
    End Sub

    Private Sub Form10_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim T As New Transition(New TransitionType_Deceleration(500))
        'Dim L As New Transition(New TransitionType_Deceleration(500))
        'L.add(fullname, "Left", 21)
        'T.add(fullname, "Top", 42)

        'Transition.runChain(T, L)
        Dim l1 As New Transition(New TransitionType_Deceleration(1000))
        Dim c1 As New Transition(New TransitionType_EaseInEaseOut(500))
        l1.add(fullname, "Left", 21)
        l1.add(nickname, "Left", 21)
        l1.add(username, "Left", 21)
        l1.add(password, "Left", 21)
        l1.add(KryptonGroup1, "Left", 21)
        'c1.add(Panel2, "BackColor", Color.DarkSlateGray)
        l1.run()
        c1.run()
        fullname.Focus()
        loadaccount
    End Sub

    Private Sub KryptonButton5_Click(sender As Object, e As EventArgs) Handles KryptonButton5.Click
        If username.Text = "" Or password.Text = "" Or fullname.Text = "" Or nickname.Text = "" Then
            MsgBox("complete all fields")
        Else
            If KryptonButton5.Text = "Register" Then
                sql.newaccount(username.Text, password.Text, fullname.Text, nickname.Text, acctype.Text)
                loadaccount()
            Else
                sql.updateaccount(id.Text, username.Text, password.Text, fullname.Text, nickname.Text, acctype.Text)
                loadaccount()
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim T As New Transition(New TransitionType_Deceleration(500))
        If Panel5.Width = 1055 Then
            T.add(Panel5, "Width", 373)
            T.add(KryptonButton5, "Text", "Register")
            T.add(KryptonLabel5, "Text", "Sign Up")
            T.add(KryptonSeparator1, "Height", 10)
            T.run()
            fullname.Clear()
            nickname.Clear()
            username.Clear()
            password.Clear()
            acctype.SelectedIndex = -1
        Else
            T.add(Panel5, "Width", 1055)
            T.add(KryptonButton5, "Text", "Save Changes")
            T.add(KryptonLabel5, "Text", "Update Account")
            T.add(KryptonSeparator1, "Height", 398)
            T.run()
        End If

    End Sub
    Public Sub loadaccount()
        Try
            sql.sqlcon.Open()
            Dim str As String = "Select * from account_tb"
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            Dim da As New SqlDataAdapter
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "account_tb")
            bs.DataSource = ds
            bs.datamember = "account_tb"
            accoutgridview.DataSource = bs
            accoutgridview.Columns("password").Visible = False
            accoutgridview.Columns("stockscolumns").Visible = False
            accoutgridview.Columns("transcolumns").Visible = False
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Private Sub accoutgridview_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles accoutgridview.CellClick
        If accoutgridview.RowCount >= 0 And e.RowIndex >= 0 Then
            id.Text = accoutgridview.Item(0, e.RowIndex).Value.ToString
            fullname.Text = accoutgridview.Item(1, e.RowIndex).Value.ToString
            nickname.Text = accoutgridview.Item(2, e.RowIndex).Value.ToString
            username.Text = accoutgridview.Item(3, e.RowIndex).Value.ToString
            password.Text = accoutgridview.Item(4, e.RowIndex).Value.ToString
            acctype.Text = accoutgridview.Item(5, e.RowIndex).Value.ToString
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If MessageBox.Show("are you sure you want to delete this account?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            MessageBox.Show("Operation Cancelled", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        For i As Integer = 0 To selectedid.Items.Count - 1
            Dim x As String = selectedid.Items(i).ToString
            deleteacct(x)
        Next
        loadaccount()
    End Sub

    Private Sub accoutgridview_SelectionChanged(sender As Object, e As EventArgs) Handles accoutgridview.SelectionChanged
        Dim selecteditems As DataGridViewSelectedRowCollection = accoutgridview.SelectedRows
        selectedid.Items.Clear()
        Dim str As String
        For Each selecteditem As DataGridViewRow In selecteditems
            str = selecteditem.Cells("id").Value.ToString
            selectedid.Items.Add(str)
        Next
    End Sub
    Public Sub deleteacct(ByVal id As String)
        Try
            sql.sqlcon.Open()
            Dim str As String = "delete account_tb where id = '" & id & "'"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub
End Class
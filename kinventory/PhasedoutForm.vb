Imports System.Data.SqlClient
Public Class PhasedoutForm
    Dim drag As Boolean
    Dim xm As Integer
    Dim ym As Integer
    Dim sql As New sql
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
        Form2.KryptonButton1.PerformClick()

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
End Class
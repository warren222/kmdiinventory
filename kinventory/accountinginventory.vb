Imports Microsoft.Reporting.WinForms
Imports System.Data.SqlClient
Public Class accountinginventory
    Dim sql As New sql
    Public sqlcmd As New SqlCommand

    Private Sub accountinginventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadmyreport()
        Dim param1 As New ReportParameter("asofdate", Form2.transdate.Text)
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {param1})
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub accountinginventory_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.ReportViewer1.RefreshReport()
    End Sub
    Public Sub loadmyreport()
        Try
            sql.sqlcon.Open()
            Dim ds As New inventoryds
            ds.Clear()
            Dim da As New SqlDataAdapter
            Dim str As String = "select * from stocks_tb where not physical2 < 0"
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds.STOCKS_TB)
            STOCKS_TBBindingSource.DataSource = ds.STOCKS_TB.DefaultView
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub
End Class
Imports Microsoft.Reporting.WinForms
Imports System.Data.SqlClient
Public Class accountinginventory
    Dim sql As New sql
    Public sqlcmd As New SqlCommand

    Private Sub accountinginventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim param1 As New ReportParameter("asofdate", Form2.transdate.Text)
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {param1})
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub accountinginventory_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.ReportViewer1.RefreshReport()
    End Sub

End Class
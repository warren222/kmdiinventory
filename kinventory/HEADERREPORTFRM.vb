Imports Microsoft.Reporting.WinForms
Public Class HEADERREPORTFRM
    Private Sub HEADERREPORTFRM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim param1 As New ReportParameter("mydate", Form2.transdate.Text)
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {param1})
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub HEADERREPORTFRM_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class
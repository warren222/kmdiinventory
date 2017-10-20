Imports Microsoft.Reporting.WinForms
Public Class Form11
    Private Sub Form11_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim s As Date
        Dim d As Date = Form2.tofoilstartdate.Text
        Dim ins As Double = Form2.plusmonths.Text
        s = DateAdd(DateInterval.Month, ins, d)

        Dim param1 As New ReportParameter("dueto", s.ToString("yyyy-MMM-dd"))
        Dim param2 As New ReportParameter("duefrom", d.ToString("yyyy-MMM-dd"))
        Me.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {param1})
        Me.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {param2})
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub Form11_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class
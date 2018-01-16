Imports Microsoft.Reporting.WinForms
Public Class Form13
    Private Sub Form13_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ReportViewer1.ZoomMode = ZoomMode.PageWidth
        ReportViewer1.SetDisplayMode(DisplayMode.printlayout)
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub Form13_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ReportViewer1.RefreshReport()
    End Sub
End Class
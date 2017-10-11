Imports Microsoft.Reporting.WinForms
Public Class Form8
    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim param1 As New ReportParameter("asofdate", Form2.transdate.Text)
        Me.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {param1})
        Me.ReportViewer1.RefreshReport()
        Me.Size = New Size(Screen.PrimaryScreen.Bounds.Right - (Form2.KryptonGroup9.Size.Width + 20), Screen.PrimaryScreen.Bounds.Bottom - 200)
        Me.Location = New Point(Screen.PrimaryScreen.Bounds.Right - Me.Width, 200)
        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth

    End Sub

    Private Sub Form8_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class
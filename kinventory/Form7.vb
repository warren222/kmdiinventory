Imports Microsoft.Reporting.WinForms
Public Class Form7
    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Size = New Size(Screen.PrimaryScreen.Bounds.Right - (Form2.KryptonGroup9.Size.Width + 20), Screen.PrimaryScreen.Bounds.Bottom - 200)
        Me.Location = New Point(Screen.PrimaryScreen.Bounds.Right - Me.Width, 200)
        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth

    End Sub

    Private Sub Form7_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.ReportViewer1.RefreshReport()
    End Sub


End Class
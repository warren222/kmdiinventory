Public Class accountingreport
    Dim sql As New sql
    Private Sub KryptonButton30_Click(sender As Object, e As EventArgs) Handles KryptonButton30.Click
        Dim str As String = "SELECT * FROM STOCKS_TB WHERE NOT PHYSICAL2 < 0 order by articleno asc"
        sql.loadmyreport(str)
        accountinginventory.ShowDialog()
    End Sub

    Private Sub KryptonButton1_Click(sender As Object, e As EventArgs) Handles KryptonButton1.Click
        Dim str As String = "SELECT * FROM STOCKS_TB WHERE NOT PHYSICAL2 < 0 AND NOT PHASEDOUT like '%Yes%' order by articleno asc"
        sql.loadmyreport(str)
        accountinginventory.ShowDialog()
    End Sub

    Private Sub KryptonButton2_Click(sender As Object, e As EventArgs) Handles KryptonButton2.Click
        Dim str As String = "SELECT * FROM STOCKS_TB WHERE NOT PHYSICAL2 < 0 AND PHASEDOUT like '%Yes%' order by articleno asc"
        sql.loadmyreport(str)
        accountinginventory.ShowDialog()
    End Sub

    Private Sub accountingreport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
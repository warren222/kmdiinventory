﻿Public Class accountingreport
    Dim sql As New sql
    Private Sub KryptonButton30_Click(sender As Object, e As EventArgs) Handles KryptonButton30.Click
        Dim str As String = "SELECT * FROM STOCKS_TB WHERE NOT PHYSICAL2 < 0 "
        sql.loadmyreport(str)
        accountinginventory.ShowDialog()
    End Sub

    Private Sub KryptonButton1_Click(sender As Object, e As EventArgs) Handles KryptonButton1.Click
        Dim str As String = "SELECT * FROM STOCKS_TB WHERE NOT PHYSICAL2 < 0 AND NOT PHASEDOUT = 'Yes'"
        sql.loadmyreport(str)
        accountinginventory.ShowDialog()
    End Sub

    Private Sub KryptonButton2_Click(sender As Object, e As EventArgs) Handles KryptonButton2.Click
        Dim str As String = "SELECT * FROM STOCKS_TB WHERE NOT PHYSICAL2 < 0 AND PHASEDOUT = 'Yes'"
        sql.loadmyreport(str)
        accountinginventory.ShowDialog()
    End Sub
End Class
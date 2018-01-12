Public Class Form9
    Dim drag As Boolean
    Dim xm As Integer
    Dim ym As Integer

    Private Sub KryptonButton1_Click(sender As Object, e As EventArgs) Handles KryptonButton1.Click
        Dim sql As New sql
        sql.sqlcon.Close()
        sql.login(user.Text, password.Text)

    End Sub
    Private Sub KryptonButton2_Click(sender As Object, e As EventArgs) Handles KryptonButton2.Click
        Me.Close()
    End Sub

    Private Sub KryptonLinkLabel1_LinkClicked(sender As Object, e As EventArgs)
        Form10.ShowDialog()
    End Sub

    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If localaccess.Checked = True Then
            myaccess.Text = "192.168.1.21,49107"
        Else
            myaccess.Text = "121.58.229.248,49107"
        End If
    End Sub

    Private Sub localaccess_CheckedChanged(sender As Object, e As EventArgs) Handles localaccess.CheckedChanged
        If localaccess.Checked = True Then
            myaccess.Text = "192.168.1.21,49107"
        Else
            myaccess.Text = "121.58.229.248,49107"
        End If
    End Sub

    Private Sub remoteaccess_CheckedChanged(sender As Object, e As EventArgs) Handles remoteaccess.CheckedChanged
        If localaccess.Checked = True Then
            myaccess.Text = "192.168.1.21,49107"
        Else
            myaccess.Text = "121.58.229.248,49107"
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Panel3_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel3.MouseDown
        drag = True
        xm = Cursor.Position.X - Me.Left
        ym = Cursor.Position.Y - Me.Top

    End Sub

    Private Sub Panel3_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel3.MouseMove
        If drag Then
            Me.Left = Cursor.Position.X - xm
            Me.Top = Cursor.Position.Y - ym
        End If
    End Sub

    Private Sub Panel3_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel3.MouseUp
        drag = False
    End Sub

    Private Sub password_KeyDown(sender As Object, e As KeyEventArgs) Handles password.KeyDown
        If e.KeyData = Keys.Enter Then
            KryptonButton1.PerformClick()
        End If
    End Sub
End Class
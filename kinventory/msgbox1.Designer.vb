<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class msgbox1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonButton30 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.Location = New System.Drawing.Point(35, 12)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonLabel3.Size = New System.Drawing.Size(145, 21)
        Me.KryptonLabel3.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel3.TabIndex = 464
        Me.KryptonLabel3.Values.Text = "Transaction Saved !"
        '
        'KryptonButton30
        '
        Me.KryptonButton30.Cursor = System.Windows.Forms.Cursors.Hand
        Me.KryptonButton30.Location = New System.Drawing.Point(72, 39)
        Me.KryptonButton30.Name = "KryptonButton30"
        Me.KryptonButton30.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver
        Me.KryptonButton30.Size = New System.Drawing.Size(71, 27)
        Me.KryptonButton30.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonButton30.StateCommon.Border.Rounding = 0
        Me.KryptonButton30.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Microsoft JhengHei", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonButton30.TabIndex = 463
        Me.KryptonButton30.Values.Text = "Ok"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel1.Location = New System.Drawing.Point(0, 76)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(224, 28)
        Me.Panel1.TabIndex = 465
        '
        'msgbox1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(214, 97)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.KryptonLabel3)
        Me.Controls.Add(Me.KryptonButton30)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "msgbox1"
        Me.ShowIcon = False
        Me.Text = "Information"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonButton30 As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents Panel1 As Panel
End Class

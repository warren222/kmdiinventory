<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class reallocate
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
        Me.transno = New System.Windows.Forms.ComboBox()
        Me.cancelorderbtn = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.stockno = New System.Windows.Forms.ComboBox()
        Me.reference = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.jo = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'transno
        '
        Me.transno.FormattingEnabled = True
        Me.transno.Location = New System.Drawing.Point(12, 159)
        Me.transno.Name = "transno"
        Me.transno.Size = New System.Drawing.Size(263, 21)
        Me.transno.TabIndex = 455
        '
        'cancelorderbtn
        '
        Me.cancelorderbtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cancelorderbtn.Location = New System.Drawing.Point(12, 41)
        Me.cancelorderbtn.Name = "cancelorderbtn"
        Me.cancelorderbtn.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver
        Me.cancelorderbtn.Size = New System.Drawing.Size(194, 27)
        Me.cancelorderbtn.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.cancelorderbtn.StateCommon.Border.Rounding = 0
        Me.cancelorderbtn.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cancelorderbtn.TabIndex = 456
        Me.cancelorderbtn.Values.Text = "ok"
        '
        'stockno
        '
        Me.stockno.FormattingEnabled = True
        Me.stockno.Location = New System.Drawing.Point(12, 186)
        Me.stockno.Name = "stockno"
        Me.stockno.Size = New System.Drawing.Size(263, 21)
        Me.stockno.TabIndex = 457
        '
        'reference
        '
        Me.reference.FormattingEnabled = True
        Me.reference.Location = New System.Drawing.Point(12, 213)
        Me.reference.Name = "reference"
        Me.reference.Size = New System.Drawing.Size(263, 21)
        Me.reference.TabIndex = 458
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(201, 17)
        Me.Label1.TabIndex = 459
        Me.Label1.Text = "ReAlloc Selected Transactions"
        '
        'jo
        '
        Me.jo.FormattingEnabled = True
        Me.jo.Location = New System.Drawing.Point(12, 240)
        Me.jo.Name = "jo"
        Me.jo.Size = New System.Drawing.Size(263, 21)
        Me.jo.TabIndex = 460
        '
        'reallocate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(218, 78)
        Me.Controls.Add(Me.jo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.reference)
        Me.Controls.Add(Me.stockno)
        Me.Controls.Add(Me.cancelorderbtn)
        Me.Controls.Add(Me.transno)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "reallocate"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents transno As ComboBox
    Friend WithEvents cancelorderbtn As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents stockno As ComboBox
    Friend WithEvents reference As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents jo As ComboBox
End Class

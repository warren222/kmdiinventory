<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class changereferenceFRM
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
        Me.Button2 = New System.Windows.Forms.Button()
        Me.KryptonLabel70 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.jo = New System.Windows.Forms.ComboBox()
        Me.KryptonLabel29 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.reference = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(401, 37)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(98, 23)
        Me.Button2.TabIndex = 461
        Me.Button2.Text = "Select"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'KryptonLabel70
        '
        Me.KryptonLabel70.Location = New System.Drawing.Point(16, 269)
        Me.KryptonLabel70.Name = "KryptonLabel70"
        Me.KryptonLabel70.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonLabel70.Size = New System.Drawing.Size(90, 19)
        Me.KryptonLabel70.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel70.TabIndex = 459
        Me.KryptonLabel70.Values.Text = "MOTHER JO"
        '
        'jo
        '
        Me.jo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.jo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.jo.DropDownHeight = 206
        Me.jo.FormattingEnabled = True
        Me.jo.IntegralHeight = False
        Me.jo.Location = New System.Drawing.Point(112, 269)
        Me.jo.Name = "jo"
        Me.jo.Size = New System.Drawing.Size(274, 21)
        Me.jo.TabIndex = 460
        '
        'KryptonLabel29
        '
        Me.KryptonLabel29.Location = New System.Drawing.Point(12, 12)
        Me.KryptonLabel29.Name = "KryptonLabel29"
        Me.KryptonLabel29.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonLabel29.Size = New System.Drawing.Size(73, 19)
        Me.KryptonLabel29.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel29.TabIndex = 457
        Me.KryptonLabel29.Values.Text = "Reference"
        '
        'reference
        '
        Me.reference.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.reference.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.reference.DropDownHeight = 206
        Me.reference.Enabled = False
        Me.reference.FormattingEnabled = True
        Me.reference.IntegralHeight = False
        Me.reference.Location = New System.Drawing.Point(12, 37)
        Me.reference.Name = "reference"
        Me.reference.Size = New System.Drawing.Size(383, 21)
        Me.reference.TabIndex = 458
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(392, 221)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(107, 23)
        Me.Button1.TabIndex = 462
        Me.Button1.Text = "save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(12, 64)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(487, 154)
        Me.TextBox1.TabIndex = 463
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(392, 269)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(107, 23)
        Me.Button3.TabIndex = 464
        Me.Button3.Text = "save"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'changereferenceFRM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(511, 256)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.KryptonLabel70)
        Me.Controls.Add(Me.jo)
        Me.Controls.Add(Me.KryptonLabel29)
        Me.Controls.Add(Me.reference)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "changereferenceFRM"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "change reference"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button2 As Button
    Friend WithEvents KryptonLabel70 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents jo As ComboBox
    Friend WithEvents KryptonLabel29 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents reference As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button3 As Button
End Class

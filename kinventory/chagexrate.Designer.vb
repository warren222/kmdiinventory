﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class chagexrate
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
        Me.KryptonButton1 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.xrate = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.transno = New System.Windows.Forms.ComboBox()
        Me.KryptonCheckBox8 = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.KryptonCheckBox1 = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.unit = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.SuspendLayout()
        '
        'KryptonButton1
        '
        Me.KryptonButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.KryptonButton1.Location = New System.Drawing.Point(115, 146)
        Me.KryptonButton1.Name = "KryptonButton1"
        Me.KryptonButton1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonButton1.Size = New System.Drawing.Size(75, 29)
        Me.KryptonButton1.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.KryptonButton1.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Solid
        Me.KryptonButton1.StateCommon.Back.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias
        Me.KryptonButton1.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.KryptonButton1.StateCommon.Border.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Solid
        Me.KryptonButton1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonButton1.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias
        Me.KryptonButton1.StateCommon.Border.Rounding = 0
        Me.KryptonButton1.StateCommon.Border.Width = 2
        Me.KryptonButton1.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White
        Me.KryptonButton1.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonButton1.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.KryptonButton1.StateNormal.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.KryptonButton1.StateNormal.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Solid
        Me.KryptonButton1.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(135, Byte), Integer))
        Me.KryptonButton1.StatePressed.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Solid
        Me.KryptonButton1.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(135, Byte), Integer))
        Me.KryptonButton1.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(135, Byte), Integer))
        Me.KryptonButton1.StateTracking.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonButton1.TabIndex = 468
        Me.KryptonButton1.Values.Text = "Save"
        '
        'xrate
        '
        Me.xrate.Location = New System.Drawing.Point(20, 45)
        Me.xrate.Multiline = True
        Me.xrate.Name = "xrate"
        Me.xrate.Size = New System.Drawing.Size(170, 29)
        Me.xrate.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.xrate.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.xrate.StateCommon.Border.Rounding = 0
        Me.xrate.StateCommon.Border.Width = 4
        Me.xrate.StateDisabled.Back.Color1 = System.Drawing.Color.White
        Me.xrate.StateDisabled.Content.Color1 = System.Drawing.Color.Black
        Me.xrate.TabIndex = 466
        Me.xrate.Text = "0"
        '
        'transno
        '
        Me.transno.FormattingEnabled = True
        Me.transno.Location = New System.Drawing.Point(20, 191)
        Me.transno.Name = "transno"
        Me.transno.Size = New System.Drawing.Size(263, 21)
        Me.transno.TabIndex = 469
        '
        'KryptonCheckBox8
        '
        Me.KryptonCheckBox8.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.KryptonCheckBox8.Location = New System.Drawing.Point(20, 17)
        Me.KryptonCheckBox8.Name = "KryptonCheckBox8"
        Me.KryptonCheckBox8.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonCheckBox8.Size = New System.Drawing.Size(65, 22)
        Me.KryptonCheckBox8.StateCommon.ShortText.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonCheckBox8.TabIndex = 470
        Me.KryptonCheckBox8.Text = "X-Rate"
        Me.KryptonCheckBox8.Values.Text = "X-Rate"
        '
        'KryptonCheckBox1
        '
        Me.KryptonCheckBox1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.KryptonCheckBox1.Location = New System.Drawing.Point(20, 80)
        Me.KryptonCheckBox1.Name = "KryptonCheckBox1"
        Me.KryptonCheckBox1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonCheckBox1.Size = New System.Drawing.Size(47, 22)
        Me.KryptonCheckBox1.StateCommon.ShortText.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonCheckBox1.TabIndex = 472
        Me.KryptonCheckBox1.Text = "unit"
        Me.KryptonCheckBox1.Values.Text = "unit"
        '
        'unit
        '
        Me.unit.Location = New System.Drawing.Point(20, 108)
        Me.unit.Multiline = True
        Me.unit.Name = "unit"
        Me.unit.Size = New System.Drawing.Size(170, 29)
        Me.unit.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.unit.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.unit.StateCommon.Border.Rounding = 0
        Me.unit.StateCommon.Border.Width = 4
        Me.unit.StateDisabled.Back.Color1 = System.Drawing.Color.White
        Me.unit.StateDisabled.Content.Color1 = System.Drawing.Color.Black
        Me.unit.TabIndex = 471
        Me.unit.Text = "0"
        '
        'chagexrate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(203, 184)
        Me.Controls.Add(Me.KryptonCheckBox1)
        Me.Controls.Add(Me.unit)
        Me.Controls.Add(Me.KryptonCheckBox8)
        Me.Controls.Add(Me.transno)
        Me.Controls.Add(Me.KryptonButton1)
        Me.Controls.Add(Me.xrate)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "chagexrate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents KryptonButton1 As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents xrate As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents transno As ComboBox
    Friend WithEvents KryptonCheckBox8 As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents KryptonCheckBox1 As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents unit As ComponentFactory.Krypton.Toolkit.KryptonTextBox
End Class

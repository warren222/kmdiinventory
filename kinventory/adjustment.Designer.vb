<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class adjustment
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
        Me.currentqty = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel8 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonButton5 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonButton4 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.setqty = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel7 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.setlocation = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.stockno = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.KryptonGroup9 = New ComponentFactory.Krypton.Toolkit.KryptonGroup()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.articleno = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.KryptonGroup9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroup9.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroup9.Panel.SuspendLayout()
        Me.KryptonGroup9.SuspendLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'currentqty
        '
        Me.currentqty.Enabled = False
        Me.currentqty.Location = New System.Drawing.Point(25, 165)
        Me.currentqty.Multiline = True
        Me.currentqty.Name = "currentqty"
        Me.currentqty.Size = New System.Drawing.Size(210, 42)
        Me.currentqty.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.currentqty.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.currentqty.StateCommon.Border.Rounding = 5
        Me.currentqty.StateCommon.Border.Width = 2
        Me.currentqty.StateCommon.Content.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.currentqty.StateDisabled.Back.Color1 = System.Drawing.Color.White
        Me.currentqty.StateDisabled.Content.Color1 = System.Drawing.Color.Black
        Me.currentqty.TabIndex = 482
        Me.currentqty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'KryptonLabel8
        '
        Me.KryptonLabel8.Location = New System.Drawing.Point(25, 138)
        Me.KryptonLabel8.Name = "KryptonLabel8"
        Me.KryptonLabel8.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonLabel8.Size = New System.Drawing.Size(131, 24)
        Me.KryptonLabel8.StateCommon.ShortText.Color1 = System.Drawing.Color.White
        Me.KryptonLabel8.StateCommon.ShortText.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel8.TabIndex = 483
        Me.KryptonLabel8.Values.Text = "Current Quantity"
        '
        'KryptonButton5
        '
        Me.KryptonButton5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.KryptonButton5.Location = New System.Drawing.Point(130, 285)
        Me.KryptonButton5.Name = "KryptonButton5"
        Me.KryptonButton5.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonButton5.Size = New System.Drawing.Size(105, 58)
        Me.KryptonButton5.StateCommon.Back.Color1 = System.Drawing.Color.Navy
        Me.KryptonButton5.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Solid
        Me.KryptonButton5.StateCommon.Back.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias
        Me.KryptonButton5.StateCommon.Border.Color1 = System.Drawing.Color.Navy
        Me.KryptonButton5.StateCommon.Border.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Solid
        Me.KryptonButton5.StateCommon.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonButton5.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias
        Me.KryptonButton5.StateCommon.Border.Rounding = 10
        Me.KryptonButton5.StateCommon.Border.Width = 2
        Me.KryptonButton5.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White
        Me.KryptonButton5.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Segoe UI", 25.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonButton5.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.KryptonButton5.StateDisabled.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.KryptonButton5.StateDisabled.Border.Color1 = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.KryptonButton5.StateDisabled.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonButton5.StateNormal.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Solid
        Me.KryptonButton5.StatePressed.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Solid
        Me.KryptonButton5.StateTracking.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonButton5.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.KryptonButton5.TabIndex = 481
        Me.KryptonButton5.Values.Text = "-"
        '
        'KryptonButton4
        '
        Me.KryptonButton4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.KryptonButton4.Location = New System.Drawing.Point(25, 285)
        Me.KryptonButton4.Name = "KryptonButton4"
        Me.KryptonButton4.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonButton4.Size = New System.Drawing.Size(105, 58)
        Me.KryptonButton4.StateCommon.Back.Color1 = System.Drawing.Color.Navy
        Me.KryptonButton4.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Solid
        Me.KryptonButton4.StateCommon.Back.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias
        Me.KryptonButton4.StateCommon.Border.Color1 = System.Drawing.Color.Navy
        Me.KryptonButton4.StateCommon.Border.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Solid
        Me.KryptonButton4.StateCommon.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonButton4.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias
        Me.KryptonButton4.StateCommon.Border.Rounding = 10
        Me.KryptonButton4.StateCommon.Border.Width = 2
        Me.KryptonButton4.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White
        Me.KryptonButton4.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Segoe UI", 25.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonButton4.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.KryptonButton4.StateDisabled.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.KryptonButton4.StateDisabled.Border.Color1 = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.KryptonButton4.StateDisabled.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonButton4.StateNormal.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Solid
        Me.KryptonButton4.StatePressed.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Solid
        Me.KryptonButton4.StateTracking.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonButton4.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.KryptonButton4.TabIndex = 478
        Me.KryptonButton4.Values.Text = "+"
        '
        'setqty
        '
        Me.setqty.Location = New System.Drawing.Point(25, 243)
        Me.setqty.Multiline = True
        Me.setqty.Name = "setqty"
        Me.setqty.Size = New System.Drawing.Size(210, 42)
        Me.setqty.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.setqty.StateCommon.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.setqty.StateCommon.Border.Rounding = 5
        Me.setqty.StateCommon.Border.Width = 2
        Me.setqty.StateCommon.Content.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.setqty.StateDisabled.Back.Color1 = System.Drawing.Color.White
        Me.setqty.StateDisabled.Content.Color1 = System.Drawing.Color.Black
        Me.setqty.TabIndex = 479
        Me.setqty.Text = "0"
        Me.setqty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'KryptonLabel7
        '
        Me.KryptonLabel7.Location = New System.Drawing.Point(25, 213)
        Me.KryptonLabel7.Name = "KryptonLabel7"
        Me.KryptonLabel7.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonLabel7.Size = New System.Drawing.Size(187, 24)
        Me.KryptonLabel7.StateCommon.ShortText.Color1 = System.Drawing.Color.White
        Me.KryptonLabel7.StateCommon.ShortText.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel7.TabIndex = 480
        Me.KryptonLabel7.Values.Text = "Set Adjustment Quantity"
        '
        'setlocation
        '
        Me.setlocation.Enabled = False
        Me.setlocation.Location = New System.Drawing.Point(25, 85)
        Me.setlocation.Multiline = True
        Me.setlocation.Name = "setlocation"
        Me.setlocation.Size = New System.Drawing.Size(210, 42)
        Me.setlocation.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.setlocation.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.setlocation.StateCommon.Border.Rounding = 5
        Me.setlocation.StateCommon.Border.Width = 2
        Me.setlocation.StateCommon.Content.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.setlocation.StateDisabled.Back.Color1 = System.Drawing.Color.White
        Me.setlocation.StateDisabled.Content.Color1 = System.Drawing.Color.Black
        Me.setlocation.TabIndex = 484
        Me.setlocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(25, 58)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonLabel1.Size = New System.Drawing.Size(72, 24)
        Me.KryptonLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.White
        Me.KryptonLabel1.StateCommon.ShortText.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel1.TabIndex = 485
        Me.KryptonLabel1.Values.Text = "Location"
        '
        'stockno
        '
        Me.stockno.Location = New System.Drawing.Point(58, 140)
        Me.stockno.Name = "stockno"
        Me.stockno.Size = New System.Drawing.Size(100, 20)
        Me.stockno.TabIndex = 486
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.Panel1.Controls.Add(Me.KryptonPanel1)
        Me.Panel1.Controls.Add(Me.KryptonLabel1)
        Me.Panel1.Controls.Add(Me.setlocation)
        Me.Panel1.Controls.Add(Me.KryptonLabel7)
        Me.Panel1.Controls.Add(Me.setqty)
        Me.Panel1.Controls.Add(Me.currentqty)
        Me.Panel1.Controls.Add(Me.KryptonButton4)
        Me.Panel1.Controls.Add(Me.KryptonLabel8)
        Me.Panel1.Controls.Add(Me.KryptonButton5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(259, 364)
        Me.Panel1.TabIndex = 487
        '
        'KryptonGroup9
        '
        Me.KryptonGroup9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonGroup9.Location = New System.Drawing.Point(0, 0)
        Me.KryptonGroup9.Margin = New System.Windows.Forms.Padding(0)
        Me.KryptonGroup9.Name = "KryptonGroup9"
        '
        'KryptonGroup9.Panel
        '
        Me.KryptonGroup9.Panel.Controls.Add(Me.Panel1)
        Me.KryptonGroup9.Panel.Controls.Add(Me.stockno)
        Me.KryptonGroup9.Size = New System.Drawing.Size(267, 372)
        Me.KryptonGroup9.StateCommon.Border.Color1 = System.Drawing.Color.Aqua
        Me.KryptonGroup9.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroup9.StateCommon.Border.Rounding = 0
        Me.KryptonGroup9.StateCommon.Border.Width = 4
        Me.KryptonGroup9.TabIndex = 488
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.articleno)
        Me.KryptonPanel1.Controls.Add(Me.Button1)
        Me.KryptonPanel1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue
        Me.KryptonPanel1.Size = New System.Drawing.Size(259, 38)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.KryptonPanel1.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.KryptonPanel1.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Dashed
        Me.KryptonPanel1.TabIndex = 486
        '
        'articleno
        '
        Me.articleno.AutoSize = False
        Me.articleno.Location = New System.Drawing.Point(3, 1)
        Me.articleno.Name = "articleno"
        Me.articleno.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.articleno.Size = New System.Drawing.Size(109, 38)
        Me.articleno.StateCommon.ShortText.Color1 = System.Drawing.Color.White
        Me.articleno.StateCommon.ShortText.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.articleno.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.articleno.TabIndex = 471
        Me.articleno.Values.Text = "Adjustment"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button1.Location = New System.Drawing.Point(210, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(49, 38)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "x"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'adjustment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Green
        Me.ClientSize = New System.Drawing.Size(267, 372)
        Me.Controls.Add(Me.KryptonGroup9)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "adjustment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "adjustment"
        Me.TransparencyKey = System.Drawing.Color.Green
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.KryptonGroup9.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroup9.Panel.ResumeLayout(False)
        Me.KryptonGroup9.Panel.PerformLayout()
        CType(Me.KryptonGroup9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroup9.ResumeLayout(False)
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents currentqty As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel8 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonButton5 As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonButton4 As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents setqty As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel7 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents setlocation As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents stockno As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents KryptonGroup9 As ComponentFactory.Krypton.Toolkit.KryptonGroup
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents articleno As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents Button1 As Button
End Class

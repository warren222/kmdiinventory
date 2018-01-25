<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cancelall
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.KryptonButton2 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonButton1 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.KryptonLabel6 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonGroup10 = New ComponentFactory.Krypton.Toolkit.KryptonGroup()
        Me.loopissue = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonButton25 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.LISTOFALLOCATIONGRIDVIEW = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.allalloc = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.header = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.KryptonGroup10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroup10.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroup10.Panel.SuspendLayout()
        Me.KryptonGroup10.SuspendLayout()
        CType(Me.LISTOFALLOCATIONGRIDVIEW, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.Panel1.Controls.Add(Me.ProgressBar1)
        Me.Panel1.Controls.Add(Me.KryptonButton2)
        Me.Panel1.Controls.Add(Me.KryptonButton1)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(284, 156)
        Me.Panel1.TabIndex = 0
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(0, 40)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(286, 19)
        Me.ProgressBar1.TabIndex = 456
        Me.ProgressBar1.Visible = False
        '
        'KryptonButton2
        '
        Me.KryptonButton2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.KryptonButton2.Location = New System.Drawing.Point(34, 116)
        Me.KryptonButton2.Name = "KryptonButton2"
        Me.KryptonButton2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonButton2.Size = New System.Drawing.Size(219, 29)
        Me.KryptonButton2.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.KryptonButton2.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Solid
        Me.KryptonButton2.StateCommon.Back.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias
        Me.KryptonButton2.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.KryptonButton2.StateCommon.Border.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Solid
        Me.KryptonButton2.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonButton2.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias
        Me.KryptonButton2.StateCommon.Border.Rounding = 0
        Me.KryptonButton2.StateCommon.Border.Width = 2
        Me.KryptonButton2.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White
        Me.KryptonButton2.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonButton2.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.KryptonButton2.StateNormal.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.KryptonButton2.StateNormal.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Solid
        Me.KryptonButton2.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(135, Byte), Integer))
        Me.KryptonButton2.StatePressed.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Solid
        Me.KryptonButton2.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(135, Byte), Integer))
        Me.KryptonButton2.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(135, Byte), Integer))
        Me.KryptonButton2.StateTracking.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonButton2.TabIndex = 455
        Me.KryptonButton2.Values.Text = "Cancel Order"
        '
        'KryptonButton1
        '
        Me.KryptonButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.KryptonButton1.Location = New System.Drawing.Point(34, 69)
        Me.KryptonButton1.Name = "KryptonButton1"
        Me.KryptonButton1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonButton1.Size = New System.Drawing.Size(219, 29)
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
        Me.KryptonButton1.TabIndex = 454
        Me.KryptonButton1.Values.Text = "Cancel Allocation"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Button1)
        Me.Panel3.Controls.Add(Me.KryptonLabel6)
        Me.Panel3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(284, 39)
        Me.Panel3.TabIndex = 38
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
        Me.Button1.Location = New System.Drawing.Point(235, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(49, 39)
        Me.Button1.TabIndex = 38
        Me.Button1.Text = "x"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'KryptonLabel6
        '
        Me.KryptonLabel6.Location = New System.Drawing.Point(3, 4)
        Me.KryptonLabel6.Name = "KryptonLabel6"
        Me.KryptonLabel6.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonLabel6.Size = New System.Drawing.Size(113, 30)
        Me.KryptonLabel6.StateCommon.ShortText.Color1 = System.Drawing.Color.White
        Me.KryptonLabel6.StateCommon.ShortText.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel6.TabIndex = 40
        Me.KryptonLabel6.Values.Text = "MultiCancel"
        '
        'KryptonGroup10
        '
        Me.KryptonGroup10.Location = New System.Drawing.Point(0, 0)
        Me.KryptonGroup10.Margin = New System.Windows.Forms.Padding(0)
        Me.KryptonGroup10.Name = "KryptonGroup10"
        '
        'KryptonGroup10.Panel
        '
        Me.KryptonGroup10.Panel.Controls.Add(Me.Panel1)
        Me.KryptonGroup10.Size = New System.Drawing.Size(290, 162)
        Me.KryptonGroup10.StateCommon.Border.Color1 = System.Drawing.Color.Aqua
        Me.KryptonGroup10.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroup10.StateCommon.Border.Rounding = 0
        Me.KryptonGroup10.StateCommon.Border.Width = 3
        Me.KryptonGroup10.TabIndex = 459
        '
        'loopissue
        '
        Me.loopissue.Location = New System.Drawing.Point(373, 13)
        Me.loopissue.Multiline = True
        Me.loopissue.Name = "loopissue"
        Me.loopissue.Size = New System.Drawing.Size(78, 23)
        Me.loopissue.TabIndex = 463
        Me.loopissue.Text = "0"
        '
        'KryptonButton25
        '
        Me.KryptonButton25.Location = New System.Drawing.Point(373, 71)
        Me.KryptonButton25.Name = "KryptonButton25"
        Me.KryptonButton25.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver
        Me.KryptonButton25.Size = New System.Drawing.Size(82, 23)
        Me.KryptonButton25.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonButton25.StateCommon.Border.Rounding = 0
        Me.KryptonButton25.TabIndex = 462
        Me.KryptonButton25.Values.Text = "loop"
        '
        'ComboBox1
        '
        Me.ComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBox1.DropDownHeight = 206
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.IntegralHeight = False
        Me.ComboBox1.ItemHeight = 15
        Me.ComboBox1.Location = New System.Drawing.Point(373, 42)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(82, 23)
        Me.ComboBox1.TabIndex = 461
        '
        'LISTOFALLOCATIONGRIDVIEW
        '
        Me.LISTOFALLOCATIONGRIDVIEW.AllowUserToAddRows = False
        Me.LISTOFALLOCATIONGRIDVIEW.AllowUserToDeleteRows = False
        Me.LISTOFALLOCATIONGRIDVIEW.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LISTOFALLOCATIONGRIDVIEW.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.LISTOFALLOCATIONGRIDVIEW.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.LISTOFALLOCATIONGRIDVIEW.ColumnHeadersHeight = 20
        Me.LISTOFALLOCATIONGRIDVIEW.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LISTOFALLOCATIONGRIDVIEW.Location = New System.Drawing.Point(373, 119)
        Me.LISTOFALLOCATIONGRIDVIEW.Name = "LISTOFALLOCATIONGRIDVIEW"
        Me.LISTOFALLOCATIONGRIDVIEW.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver
        Me.LISTOFALLOCATIONGRIDVIEW.ReadOnly = True
        Me.LISTOFALLOCATIONGRIDVIEW.RowHeadersWidth = 25
        Me.LISTOFALLOCATIONGRIDVIEW.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.LISTOFALLOCATIONGRIDVIEW.Size = New System.Drawing.Size(314, 151)
        Me.LISTOFALLOCATIONGRIDVIEW.StateCommon.Background.Color1 = System.Drawing.SystemColors.Control
        Me.LISTOFALLOCATIONGRIDVIEW.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.LISTOFALLOCATIONGRIDVIEW.StateCommon.DataCell.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.LISTOFALLOCATIONGRIDVIEW.StateCommon.DataCell.Border.Width = 0
        Me.LISTOFALLOCATIONGRIDVIEW.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.LISTOFALLOCATIONGRIDVIEW.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(67, Byte), Integer))
        Me.LISTOFALLOCATIONGRIDVIEW.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.LISTOFALLOCATIONGRIDVIEW.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Dashed
        Me.LISTOFALLOCATIONGRIDVIEW.StateCommon.HeaderColumn.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.LISTOFALLOCATIONGRIDVIEW.StateCommon.HeaderColumn.Border.Width = 0
        Me.LISTOFALLOCATIONGRIDVIEW.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.White
        Me.LISTOFALLOCATIONGRIDVIEW.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.LISTOFALLOCATIONGRIDVIEW.StateCommon.HeaderColumn.Content.Hint = ComponentFactory.Krypton.Toolkit.PaletteTextHint.AntiAlias
        Me.LISTOFALLOCATIONGRIDVIEW.TabIndex = 460
        '
        'allalloc
        '
        Me.allalloc.Location = New System.Drawing.Point(457, 13)
        Me.allalloc.Multiline = True
        Me.allalloc.Name = "allalloc"
        Me.allalloc.Size = New System.Drawing.Size(78, 23)
        Me.allalloc.TabIndex = 464
        Me.allalloc.Text = "0"
        '
        'header
        '
        Me.header.Location = New System.Drawing.Point(406, 299)
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(100, 20)
        Me.header.TabIndex = 465
        '
        'cancelall
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Green
        Me.ClientSize = New System.Drawing.Size(294, 167)
        Me.Controls.Add(Me.header)
        Me.Controls.Add(Me.KryptonGroup10)
        Me.Controls.Add(Me.allalloc)
        Me.Controls.Add(Me.loopissue)
        Me.Controls.Add(Me.KryptonButton25)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.LISTOFALLOCATIONGRIDVIEW)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "cancelall"
        Me.Opacity = 0.96R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "cancelall"
        Me.TransparencyKey = System.Drawing.Color.Green
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.KryptonGroup10.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroup10.Panel.ResumeLayout(False)
        CType(Me.KryptonGroup10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroup10.ResumeLayout(False)
        CType(Me.LISTOFALLOCATIONGRIDVIEW, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents KryptonGroup10 As ComponentFactory.Krypton.Toolkit.KryptonGroup
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents KryptonLabel6 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonButton2 As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonButton1 As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents loopissue As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonButton25 As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents LISTOFALLOCATIONGRIDVIEW As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents allalloc As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents header As TextBox
End Class

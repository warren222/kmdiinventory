<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HISTORY
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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.transactiongridview = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.stockno = New System.Windows.Forms.TextBox()
        Me.location = New System.Windows.Forms.TextBox()
        Me.KryptonButton1 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonGroup9 = New ComponentFactory.Krypton.Toolkit.KryptonGroup()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.articleno = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.transactiongridview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroup9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroup9.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroup9.Panel.SuspendLayout()
        Me.KryptonGroup9.SuspendLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'transactiongridview
        '
        Me.transactiongridview.AllowUserToAddRows = False
        Me.transactiongridview.AllowUserToDeleteRows = False
        Me.transactiongridview.AllowUserToOrderColumns = True
        Me.transactiongridview.AllowUserToResizeColumns = False
        Me.transactiongridview.AllowUserToResizeRows = False
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(36, Byte), Integer))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.White
        Me.transactiongridview.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.transactiongridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.transactiongridview.ColumnHeadersHeight = 30
        Me.transactiongridview.Cursor = System.Windows.Forms.Cursors.Hand
        Me.transactiongridview.Location = New System.Drawing.Point(12, 44)
        Me.transactiongridview.Name = "transactiongridview"
        Me.transactiongridview.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver
        Me.transactiongridview.ReadOnly = True
        Me.transactiongridview.RowHeadersVisible = False
        Me.transactiongridview.RowHeadersWidth = 40
        Me.transactiongridview.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.transactiongridview.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White
        Me.transactiongridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.transactiongridview.Size = New System.Drawing.Size(801, 443)
        Me.transactiongridview.StateCommon.Background.Color1 = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.transactiongridview.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.transactiongridview.StateCommon.DataCell.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.transactiongridview.StateCommon.DataCell.Border.Width = 0
        Me.transactiongridview.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.transactiongridview.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.transactiongridview.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.transactiongridview.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Dashed
        Me.transactiongridview.StateCommon.HeaderColumn.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.transactiongridview.StateCommon.HeaderColumn.Border.Width = 0
        Me.transactiongridview.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.White
        Me.transactiongridview.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.transactiongridview.StateCommon.HeaderColumn.Content.Hint = ComponentFactory.Krypton.Toolkit.PaletteTextHint.AntiAlias
        Me.transactiongridview.TabIndex = 462
        '
        'stockno
        '
        Me.stockno.Location = New System.Drawing.Point(52, 152)
        Me.stockno.Name = "stockno"
        Me.stockno.Size = New System.Drawing.Size(241, 20)
        Me.stockno.TabIndex = 463
        '
        'location
        '
        Me.location.Location = New System.Drawing.Point(52, 178)
        Me.location.Name = "location"
        Me.location.Size = New System.Drawing.Size(241, 20)
        Me.location.TabIndex = 464
        '
        'KryptonButton1
        '
        Me.KryptonButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.KryptonButton1.Location = New System.Drawing.Point(12, 493)
        Me.KryptonButton1.Name = "KryptonButton1"
        Me.KryptonButton1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonButton1.Size = New System.Drawing.Size(152, 27)
        Me.KryptonButton1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonButton1.StateCommon.Border.Rounding = 4
        Me.KryptonButton1.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonButton1.TabIndex = 465
        Me.KryptonButton1.Values.Text = "refresh table"
        '
        'KryptonGroup9
        '
        Me.KryptonGroup9.Location = New System.Drawing.Point(9, 9)
        Me.KryptonGroup9.Margin = New System.Windows.Forms.Padding(0)
        Me.KryptonGroup9.Name = "KryptonGroup9"
        '
        'KryptonGroup9.Panel
        '
        Me.KryptonGroup9.Panel.Controls.Add(Me.KryptonPanel1)
        Me.KryptonGroup9.Panel.Controls.Add(Me.transactiongridview)
        Me.KryptonGroup9.Panel.Controls.Add(Me.KryptonButton1)
        Me.KryptonGroup9.Panel.Controls.Add(Me.stockno)
        Me.KryptonGroup9.Panel.Controls.Add(Me.location)
        Me.KryptonGroup9.Size = New System.Drawing.Size(831, 540)
        Me.KryptonGroup9.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.KryptonGroup9.StateCommon.Border.Color1 = System.Drawing.Color.Aqua
        Me.KryptonGroup9.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroup9.StateCommon.Border.Rounding = 0
        Me.KryptonGroup9.StateCommon.Border.Width = 4
        Me.KryptonGroup9.TabIndex = 471
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
        Me.KryptonPanel1.Size = New System.Drawing.Size(823, 38)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.KryptonPanel1.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.KryptonPanel1.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Dashed
        Me.KryptonPanel1.TabIndex = 466
        '
        'articleno
        '
        Me.articleno.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.articleno.AutoSize = False
        Me.articleno.Location = New System.Drawing.Point(335, 0)
        Me.articleno.Name = "articleno"
        Me.articleno.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.articleno.Size = New System.Drawing.Size(152, 38)
        Me.articleno.StateCommon.ShortText.Color1 = System.Drawing.Color.White
        Me.articleno.StateCommon.ShortText.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.articleno.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.articleno.TabIndex = 471
        Me.articleno.Values.Text = "Transaction History"
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
        Me.Button1.Location = New System.Drawing.Point(774, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(49, 38)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "x"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'HISTORY
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Green
        Me.ClientSize = New System.Drawing.Size(848, 559)
        Me.Controls.Add(Me.KryptonGroup9)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "HISTORY"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "HISTORY"
        Me.TransparencyKey = System.Drawing.Color.Green
        CType(Me.transactiongridview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonGroup9.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroup9.Panel.ResumeLayout(False)
        Me.KryptonGroup9.Panel.PerformLayout()
        CType(Me.KryptonGroup9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroup9.ResumeLayout(False)
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents transactiongridview As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents stockno As TextBox
    Friend WithEvents location As TextBox
    Friend WithEvents KryptonButton1 As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonGroup9 As ComponentFactory.Krypton.Toolkit.KryptonGroup
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents articleno As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents Button1 As Button
End Class

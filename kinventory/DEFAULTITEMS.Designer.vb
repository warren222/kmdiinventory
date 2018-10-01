<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DEFAULTITEMS
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.stocksgridview = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.KryptonGroup1 = New ComponentFactory.Krypton.Toolkit.KryptonGroup()
        Me.KryptonLabel60 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.supplier = New System.Windows.Forms.ComboBox()
        Me.KryptonButton15 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.phasedoutsearch = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.KryptonLabel6 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.status = New System.Windows.Forms.ComboBox()
        Me.KryptonButton1 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.articlenosearch = New System.Windows.Forms.ComboBox()
        Me.typecolorsearch = New System.Windows.Forms.ComboBox()
        Me.costheadsearch = New System.Windows.Forms.ComboBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        CType(Me.stocksgridview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroup1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroup1.Panel.SuspendLayout()
        Me.KryptonGroup1.SuspendLayout()
        Me.SuspendLayout()
        '
        'stocksgridview
        '
        Me.stocksgridview.AllowUserToAddRows = False
        Me.stocksgridview.AllowUserToDeleteRows = False
        Me.stocksgridview.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.stocksgridview.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.stocksgridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.stocksgridview.ColumnHeadersHeight = 30
        Me.stocksgridview.Cursor = System.Windows.Forms.Cursors.Hand
        Me.stocksgridview.Location = New System.Drawing.Point(8, 12)
        Me.stocksgridview.MultiSelect = False
        Me.stocksgridview.Name = "stocksgridview"
        Me.stocksgridview.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver
        Me.stocksgridview.ReadOnly = True
        Me.stocksgridview.RowHeadersWidth = 40
        Me.stocksgridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.stocksgridview.Size = New System.Drawing.Size(676, 351)
        Me.stocksgridview.StateCommon.Background.Color1 = System.Drawing.Color.White
        Me.stocksgridview.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.stocksgridview.StateCommon.DataCell.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.stocksgridview.StateCommon.DataCell.Border.Width = 0
        Me.stocksgridview.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.stocksgridview.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.stocksgridview.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.stocksgridview.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Dashed
        Me.stocksgridview.StateCommon.HeaderColumn.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.stocksgridview.StateCommon.HeaderColumn.Border.Width = 0
        Me.stocksgridview.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.White
        Me.stocksgridview.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.stocksgridview.StateCommon.HeaderColumn.Content.Hint = ComponentFactory.Krypton.Toolkit.PaletteTextHint.AntiAlias
        Me.stocksgridview.TabIndex = 1
        '
        'KryptonGroup1
        '
        Me.KryptonGroup1.GroupBorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.TabOneNote
        Me.KryptonGroup1.Location = New System.Drawing.Point(693, 12)
        Me.KryptonGroup1.Name = "KryptonGroup1"
        '
        'KryptonGroup1.Panel
        '
        Me.KryptonGroup1.Panel.Controls.Add(Me.KryptonLabel60)
        Me.KryptonGroup1.Panel.Controls.Add(Me.supplier)
        Me.KryptonGroup1.Panel.Controls.Add(Me.KryptonButton15)
        Me.KryptonGroup1.Panel.Controls.Add(Me.phasedoutsearch)
        Me.KryptonGroup1.Panel.Controls.Add(Me.KryptonLabel6)
        Me.KryptonGroup1.Panel.Controls.Add(Me.status)
        Me.KryptonGroup1.Panel.Controls.Add(Me.KryptonButton1)
        Me.KryptonGroup1.Panel.Controls.Add(Me.KryptonLabel3)
        Me.KryptonGroup1.Panel.Controls.Add(Me.KryptonLabel2)
        Me.KryptonGroup1.Panel.Controls.Add(Me.KryptonLabel1)
        Me.KryptonGroup1.Panel.Controls.Add(Me.articlenosearch)
        Me.KryptonGroup1.Panel.Controls.Add(Me.typecolorsearch)
        Me.KryptonGroup1.Panel.Controls.Add(Me.costheadsearch)
        Me.KryptonGroup1.Size = New System.Drawing.Size(165, 351)
        Me.KryptonGroup1.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control
        Me.KryptonGroup1.TabIndex = 2
        '
        'KryptonLabel60
        '
        Me.KryptonLabel60.Location = New System.Drawing.Point(11, 4)
        Me.KryptonLabel60.Name = "KryptonLabel60"
        Me.KryptonLabel60.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonLabel60.Size = New System.Drawing.Size(60, 19)
        Me.KryptonLabel60.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel60.TabIndex = 12
        Me.KryptonLabel60.Values.Text = "Supplier"
        '
        'supplier
        '
        Me.supplier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.supplier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.supplier.DropDownHeight = 206
        Me.supplier.FormattingEnabled = True
        Me.supplier.IntegralHeight = False
        Me.supplier.Location = New System.Drawing.Point(11, 29)
        Me.supplier.Name = "supplier"
        Me.supplier.Size = New System.Drawing.Size(143, 21)
        Me.supplier.TabIndex = 11
        '
        'KryptonButton15
        '
        Me.KryptonButton15.Location = New System.Drawing.Point(86, 309)
        Me.KryptonButton15.Name = "KryptonButton15"
        Me.KryptonButton15.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver
        Me.KryptonButton15.Size = New System.Drawing.Size(68, 25)
        Me.KryptonButton15.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonButton15.StateCommon.Border.Rounding = 0
        Me.KryptonButton15.TabIndex = 10
        Me.KryptonButton15.Values.Text = "Refresh"
        '
        'phasedoutsearch
        '
        Me.phasedoutsearch.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.phasedoutsearch.Location = New System.Drawing.Point(34, 281)
        Me.phasedoutsearch.Name = "phasedoutsearch"
        Me.phasedoutsearch.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.phasedoutsearch.Size = New System.Drawing.Size(94, 19)
        Me.phasedoutsearch.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.phasedoutsearch.TabIndex = 9
        Me.phasedoutsearch.Text = "Phased-out"
        Me.phasedoutsearch.Values.Text = "Phased-out"
        '
        'KryptonLabel6
        '
        Me.KryptonLabel6.Location = New System.Drawing.Point(11, 224)
        Me.KryptonLabel6.Name = "KryptonLabel6"
        Me.KryptonLabel6.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonLabel6.Size = New System.Drawing.Size(49, 19)
        Me.KryptonLabel6.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel6.TabIndex = 8
        Me.KryptonLabel6.Values.Text = "Status"
        '
        'status
        '
        Me.status.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.status.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.status.FormattingEnabled = True
        Me.status.Items.AddRange(New Object() {"Ok", "Critical"})
        Me.status.Location = New System.Drawing.Point(11, 249)
        Me.status.Name = "status"
        Me.status.Size = New System.Drawing.Size(143, 21)
        Me.status.TabIndex = 3
        '
        'KryptonButton1
        '
        Me.KryptonButton1.Location = New System.Drawing.Point(11, 309)
        Me.KryptonButton1.Name = "KryptonButton1"
        Me.KryptonButton1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver
        Me.KryptonButton1.Size = New System.Drawing.Size(68, 25)
        Me.KryptonButton1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonButton1.StateCommon.Border.Rounding = 0
        Me.KryptonButton1.TabIndex = 4
        Me.KryptonButton1.Values.Text = "Search"
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.Location = New System.Drawing.Point(11, 169)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonLabel3.Size = New System.Drawing.Size(73, 19)
        Me.KryptonLabel3.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel3.TabIndex = 5
        Me.KryptonLabel3.Values.Text = "Article No."
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Location = New System.Drawing.Point(11, 114)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonLabel2.Size = New System.Drawing.Size(76, 19)
        Me.KryptonLabel2.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel2.TabIndex = 4
        Me.KryptonLabel2.Values.Text = "Type/Color"
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(11, 59)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonLabel1.Size = New System.Drawing.Size(68, 19)
        Me.KryptonLabel1.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel1.TabIndex = 3
        Me.KryptonLabel1.Values.Text = "Costhead"
        '
        'articlenosearch
        '
        Me.articlenosearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.articlenosearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.articlenosearch.DropDownHeight = 206
        Me.articlenosearch.FormattingEnabled = True
        Me.articlenosearch.IntegralHeight = False
        Me.articlenosearch.Location = New System.Drawing.Point(11, 194)
        Me.articlenosearch.Name = "articlenosearch"
        Me.articlenosearch.Size = New System.Drawing.Size(143, 21)
        Me.articlenosearch.TabIndex = 2
        '
        'typecolorsearch
        '
        Me.typecolorsearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.typecolorsearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.typecolorsearch.DropDownHeight = 206
        Me.typecolorsearch.FormattingEnabled = True
        Me.typecolorsearch.IntegralHeight = False
        Me.typecolorsearch.Location = New System.Drawing.Point(11, 139)
        Me.typecolorsearch.Name = "typecolorsearch"
        Me.typecolorsearch.Size = New System.Drawing.Size(143, 21)
        Me.typecolorsearch.TabIndex = 1
        '
        'costheadsearch
        '
        Me.costheadsearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.costheadsearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.costheadsearch.DropDownHeight = 206
        Me.costheadsearch.FormattingEnabled = True
        Me.costheadsearch.IntegralHeight = False
        Me.costheadsearch.Location = New System.Drawing.Point(11, 84)
        Me.costheadsearch.Name = "costheadsearch"
        Me.costheadsearch.Size = New System.Drawing.Size(143, 21)
        Me.costheadsearch.TabIndex = 0
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(207, 42)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 3
        '
        'DEFAULTITEMS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(866, 371)
        Me.Controls.Add(Me.stocksgridview)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.KryptonGroup1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "DEFAULTITEMS"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DEFAULTITEMS"
        Me.TopMost = True
        CType(Me.stocksgridview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonGroup1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroup1.Panel.ResumeLayout(False)
        Me.KryptonGroup1.Panel.PerformLayout()
        CType(Me.KryptonGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroup1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents stocksgridview As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents KryptonGroup1 As ComponentFactory.Krypton.Toolkit.KryptonGroup
    Friend WithEvents KryptonLabel60 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents supplier As ComboBox
    Friend WithEvents KryptonButton15 As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents phasedoutsearch As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents KryptonLabel6 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents status As ComboBox
    Friend WithEvents KryptonButton1 As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents articlenosearch As ComboBox
    Friend WithEvents typecolorsearch As ComboBox
    Friend WithEvents costheadsearch As ComboBox
    Friend WithEvents TextBox1 As TextBox
End Class

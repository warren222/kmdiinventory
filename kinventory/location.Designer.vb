<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class locationform
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.KryptonLabel5 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.id = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.stockno = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.location = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.locationgridview = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.KryptonButton1 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonButton2 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonButton3 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.articleno = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.KryptonButton8 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.balance = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel4 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonGroup9 = New ComponentFactory.Krypton.Toolkit.KryptonGroup()
        Me.setlocation = New System.Windows.Forms.ComboBox()
        Me.KryptonLabel6 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonButton4 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.setqty = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel7 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonButton5 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.currentqty = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel8 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.KryptonLabel9 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonButton6 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.KryptonButton7 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.minusr = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.addr = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.updatelocation = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel11 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.REFERENCE = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonDataGridView1 = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.summarylocation = New System.Windows.Forms.TextBox()
        Me.TRANSTYPE = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel10 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AdjustmentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransferToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.locationgridview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.KryptonGroup9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroup9.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroup9.Panel.SuspendLayout()
        Me.KryptonGroup9.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.KryptonDataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonLabel5
        '
        Me.KryptonLabel5.Location = New System.Drawing.Point(39, 241)
        Me.KryptonLabel5.Name = "KryptonLabel5"
        Me.KryptonLabel5.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonLabel5.Size = New System.Drawing.Size(26, 24)
        Me.KryptonLabel5.StateCommon.ShortText.Color1 = System.Drawing.Color.White
        Me.KryptonLabel5.StateCommon.ShortText.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel5.TabIndex = 454
        Me.KryptonLabel5.Values.Text = "ID"
        '
        'id
        '
        Me.id.Enabled = False
        Me.id.Location = New System.Drawing.Point(131, 241)
        Me.id.Multiline = True
        Me.id.Name = "id"
        Me.id.Size = New System.Drawing.Size(150, 29)
        Me.id.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.id.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.id.StateCommon.Border.Rounding = 0
        Me.id.StateCommon.Border.Width = 4
        Me.id.StateDisabled.Back.Color1 = System.Drawing.Color.White
        Me.id.StateDisabled.Content.Color1 = System.Drawing.Color.Black
        Me.id.TabIndex = 453
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(39, 297)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonLabel1.Size = New System.Drawing.Size(72, 24)
        Me.KryptonLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.White
        Me.KryptonLabel1.StateCommon.ShortText.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel1.TabIndex = 456
        Me.KryptonLabel1.Values.Text = "Stock No"
        '
        'stockno
        '
        Me.stockno.Enabled = False
        Me.stockno.Location = New System.Drawing.Point(131, 297)
        Me.stockno.Multiline = True
        Me.stockno.Name = "stockno"
        Me.stockno.Size = New System.Drawing.Size(150, 29)
        Me.stockno.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.stockno.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.stockno.StateCommon.Border.Rounding = 0
        Me.stockno.StateCommon.Border.Width = 4
        Me.stockno.StateDisabled.Back.Color1 = System.Drawing.Color.White
        Me.stockno.StateDisabled.Content.Color1 = System.Drawing.Color.Black
        Me.stockno.TabIndex = 455
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.KryptonLabel2.Location = New System.Drawing.Point(39, 43)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonLabel2.Size = New System.Drawing.Size(72, 24)
        Me.KryptonLabel2.StateCommon.ShortText.Color1 = System.Drawing.Color.White
        Me.KryptonLabel2.StateCommon.ShortText.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel2.TabIndex = 458
        Me.KryptonLabel2.Values.Text = "Location"
        '
        'location
        '
        Me.location.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.location.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.location.Location = New System.Drawing.Point(39, 73)
        Me.location.Multiline = True
        Me.location.Name = "location"
        Me.location.Size = New System.Drawing.Size(264, 36)
        Me.location.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.location.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.location.StateCommon.Border.Rounding = 5
        Me.location.StateCommon.Border.Width = 2
        Me.location.StateCommon.Content.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.location.StateDisabled.Back.Color1 = System.Drawing.Color.White
        Me.location.StateDisabled.Content.Color1 = System.Drawing.Color.Black
        Me.location.TabIndex = 457
        '
        'locationgridview
        '
        Me.locationgridview.AllowUserToAddRows = False
        Me.locationgridview.AllowUserToDeleteRows = False
        Me.locationgridview.AllowUserToOrderColumns = True
        Me.locationgridview.AllowUserToResizeColumns = False
        Me.locationgridview.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(36, Byte), Integer))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        Me.locationgridview.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.locationgridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.locationgridview.ColumnHeadersHeight = 30
        Me.locationgridview.Cursor = System.Windows.Forms.Cursors.Hand
        Me.locationgridview.Location = New System.Drawing.Point(28, 202)
        Me.locationgridview.Name = "locationgridview"
        Me.locationgridview.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver
        Me.locationgridview.ReadOnly = True
        Me.locationgridview.RowHeadersVisible = False
        Me.locationgridview.RowHeadersWidth = 40
        Me.locationgridview.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.locationgridview.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White
        Me.locationgridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.locationgridview.Size = New System.Drawing.Size(308, 244)
        Me.locationgridview.StateCommon.Background.Color1 = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.locationgridview.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.locationgridview.StateCommon.DataCell.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.locationgridview.StateCommon.DataCell.Border.Width = 0
        Me.locationgridview.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.locationgridview.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.locationgridview.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.locationgridview.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Dashed
        Me.locationgridview.StateCommon.HeaderColumn.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.locationgridview.StateCommon.HeaderColumn.Border.Width = 0
        Me.locationgridview.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.White
        Me.locationgridview.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.locationgridview.StateCommon.HeaderColumn.Content.Hint = ComponentFactory.Krypton.Toolkit.PaletteTextHint.AntiAlias
        Me.locationgridview.TabIndex = 461
        '
        'KryptonButton1
        '
        Me.KryptonButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.KryptonButton1.Location = New System.Drawing.Point(45, 8)
        Me.KryptonButton1.Name = "KryptonButton1"
        Me.KryptonButton1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonButton1.Size = New System.Drawing.Size(60, 27)
        Me.KryptonButton1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonButton1.StateCommon.Border.Rounding = 4
        Me.KryptonButton1.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonButton1.TabIndex = 462
        Me.KryptonButton1.Values.Text = "Add"
        '
        'KryptonButton2
        '
        Me.KryptonButton2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.KryptonButton2.Location = New System.Drawing.Point(111, 8)
        Me.KryptonButton2.Name = "KryptonButton2"
        Me.KryptonButton2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonButton2.Size = New System.Drawing.Size(60, 27)
        Me.KryptonButton2.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonButton2.StateCommon.Border.Rounding = 4
        Me.KryptonButton2.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonButton2.TabIndex = 463
        Me.KryptonButton2.Values.Text = "Update"
        '
        'KryptonButton3
        '
        Me.KryptonButton3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.KryptonButton3.Location = New System.Drawing.Point(177, 8)
        Me.KryptonButton3.Name = "KryptonButton3"
        Me.KryptonButton3.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonButton3.Size = New System.Drawing.Size(60, 27)
        Me.KryptonButton3.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonButton3.StateCommon.Border.Rounding = 4
        Me.KryptonButton3.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonButton3.TabIndex = 464
        Me.KryptonButton3.Values.Text = "Delete"
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
        Me.KryptonPanel1.Size = New System.Drawing.Size(592, 38)
        Me.KryptonPanel1.StateCommon.Color1 = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.KryptonPanel1.StateCommon.Color2 = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.KryptonPanel1.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Dashed
        Me.KryptonPanel1.TabIndex = 465
        '
        'articleno
        '
        Me.articleno.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.articleno.AutoSize = False
        Me.articleno.Location = New System.Drawing.Point(2, 4)
        Me.articleno.Name = "articleno"
        Me.articleno.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.articleno.Size = New System.Drawing.Size(346, 38)
        Me.articleno.StateCommon.ShortText.Color1 = System.Drawing.Color.White
        Me.articleno.StateCommon.ShortText.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.articleno.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.articleno.TabIndex = 471
        Me.articleno.Values.Text = "Article #"
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
        Me.Button1.Location = New System.Drawing.Point(543, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(49, 38)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "x"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel1.Controls.Add(Me.KryptonButton8)
        Me.Panel1.Controls.Add(Me.KryptonButton3)
        Me.Panel1.Controls.Add(Me.KryptonButton2)
        Me.Panel1.Controls.Add(Me.KryptonButton1)
        Me.Panel1.Location = New System.Drawing.Point(0, 117)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(313, 41)
        Me.Panel1.TabIndex = 466
        '
        'KryptonButton8
        '
        Me.KryptonButton8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.KryptonButton8.Location = New System.Drawing.Point(243, 8)
        Me.KryptonButton8.Name = "KryptonButton8"
        Me.KryptonButton8.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonButton8.Size = New System.Drawing.Size(60, 27)
        Me.KryptonButton8.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonButton8.StateCommon.Border.Rounding = 4
        Me.KryptonButton8.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonButton8.TabIndex = 465
        Me.KryptonButton8.Values.Text = "Reload"
        '
        'balance
        '
        Me.balance.Enabled = False
        Me.balance.Location = New System.Drawing.Point(19, 38)
        Me.balance.Multiline = True
        Me.balance.Name = "balance"
        Me.balance.Size = New System.Drawing.Size(210, 42)
        Me.balance.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.balance.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.balance.StateCommon.Border.Rounding = 5
        Me.balance.StateCommon.Border.Width = 2
        Me.balance.StateCommon.Content.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.balance.StateDisabled.Back.Color1 = System.Drawing.Color.White
        Me.balance.StateDisabled.Content.Color1 = System.Drawing.Color.Black
        Me.balance.TabIndex = 468
        Me.balance.Text = "0"
        Me.balance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'KryptonLabel4
        '
        Me.KryptonLabel4.Location = New System.Drawing.Point(19, 8)
        Me.KryptonLabel4.Name = "KryptonLabel4"
        Me.KryptonLabel4.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonLabel4.Size = New System.Drawing.Size(201, 24)
        Me.KryptonLabel4.StateCommon.ShortText.Color1 = System.Drawing.Color.White
        Me.KryptonLabel4.StateCommon.ShortText.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel4.TabIndex = 469
        Me.KryptonLabel4.Values.Text = "Quantity From Transaction"
        '
        'KryptonGroup9
        '
        Me.KryptonGroup9.Location = New System.Drawing.Point(19, 113)
        Me.KryptonGroup9.Margin = New System.Windows.Forms.Padding(0)
        Me.KryptonGroup9.Name = "KryptonGroup9"
        '
        'KryptonGroup9.Panel
        '
        Me.KryptonGroup9.Panel.Controls.Add(Me.setlocation)
        Me.KryptonGroup9.Size = New System.Drawing.Size(210, 32)
        Me.KryptonGroup9.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonGroup9.StateCommon.Border.Rounding = 5
        Me.KryptonGroup9.StateCommon.Border.Width = 2
        Me.KryptonGroup9.TabIndex = 470
        '
        'setlocation
        '
        Me.setlocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.setlocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.setlocation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.setlocation.DropDownHeight = 206
        Me.setlocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.setlocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.setlocation.FormattingEnabled = True
        Me.setlocation.IntegralHeight = False
        Me.setlocation.Location = New System.Drawing.Point(0, 0)
        Me.setlocation.Name = "setlocation"
        Me.setlocation.Size = New System.Drawing.Size(202, 24)
        Me.setlocation.TabIndex = 19
        '
        'KryptonLabel6
        '
        Me.KryptonLabel6.Location = New System.Drawing.Point(19, 86)
        Me.KryptonLabel6.Name = "KryptonLabel6"
        Me.KryptonLabel6.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonLabel6.Size = New System.Drawing.Size(99, 24)
        Me.KryptonLabel6.StateCommon.ShortText.Color1 = System.Drawing.Color.White
        Me.KryptonLabel6.StateCommon.ShortText.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel6.TabIndex = 471
        Me.KryptonLabel6.Values.Text = "Set Location"
        '
        'KryptonButton4
        '
        Me.KryptonButton4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.KryptonButton4.Location = New System.Drawing.Point(19, 334)
        Me.KryptonButton4.Name = "KryptonButton4"
        Me.KryptonButton4.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonButton4.Size = New System.Drawing.Size(105, 41)
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
        Me.KryptonButton4.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.KryptonButton4.TabIndex = 472
        Me.KryptonButton4.Values.Text = "+"
        '
        'setqty
        '
        Me.setqty.Location = New System.Drawing.Point(19, 265)
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
        Me.setqty.TabIndex = 473
        Me.setqty.Text = "0"
        Me.setqty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'KryptonLabel7
        '
        Me.KryptonLabel7.Location = New System.Drawing.Point(19, 235)
        Me.KryptonLabel7.Name = "KryptonLabel7"
        Me.KryptonLabel7.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonLabel7.Size = New System.Drawing.Size(187, 24)
        Me.KryptonLabel7.StateCommon.ShortText.Color1 = System.Drawing.Color.White
        Me.KryptonLabel7.StateCommon.ShortText.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel7.TabIndex = 474
        Me.KryptonLabel7.Values.Text = "Set Adjustment Quantity"
        '
        'KryptonButton5
        '
        Me.KryptonButton5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.KryptonButton5.Location = New System.Drawing.Point(124, 334)
        Me.KryptonButton5.Name = "KryptonButton5"
        Me.KryptonButton5.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonButton5.Size = New System.Drawing.Size(105, 41)
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
        Me.KryptonButton5.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.KryptonButton5.TabIndex = 475
        Me.KryptonButton5.Values.Text = "-"
        '
        'currentqty
        '
        Me.currentqty.Enabled = False
        Me.currentqty.Location = New System.Drawing.Point(19, 187)
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
        Me.currentqty.TabIndex = 476
        Me.currentqty.Text = "0"
        Me.currentqty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'KryptonLabel8
        '
        Me.KryptonLabel8.Location = New System.Drawing.Point(19, 160)
        Me.KryptonLabel8.Name = "KryptonLabel8"
        Me.KryptonLabel8.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonLabel8.Size = New System.Drawing.Size(131, 24)
        Me.KryptonLabel8.StateCommon.ShortText.Color1 = System.Drawing.Color.White
        Me.KryptonLabel8.StateCommon.ShortText.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel8.TabIndex = 477
        Me.KryptonLabel8.Values.Text = "Current Quantity"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.Panel2.Controls.Add(Me.KryptonLabel9)
        Me.Panel2.Controls.Add(Me.KryptonButton6)
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Controls.Add(Me.location)
        Me.Panel2.Controls.Add(Me.KryptonLabel2)
        Me.Panel2.Location = New System.Drawing.Point(-1, 44)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(337, 158)
        Me.Panel2.TabIndex = 478
        '
        'KryptonLabel9
        '
        Me.KryptonLabel9.Location = New System.Drawing.Point(29, 6)
        Me.KryptonLabel9.Name = "KryptonLabel9"
        Me.KryptonLabel9.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonLabel9.Size = New System.Drawing.Size(106, 24)
        Me.KryptonLabel9.StateCommon.ShortText.Color1 = System.Drawing.Color.White
        Me.KryptonLabel9.StateCommon.ShortText.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel9.TabIndex = 470
        Me.KryptonLabel9.Values.Text = "Manage Table"
        '
        'KryptonButton6
        '
        Me.KryptonButton6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.KryptonButton6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.KryptonButton6.Location = New System.Drawing.Point(309, 23)
        Me.KryptonButton6.Name = "KryptonButton6"
        Me.KryptonButton6.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver
        Me.KryptonButton6.Size = New System.Drawing.Size(28, 136)
        Me.KryptonButton6.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonButton6.StateCommon.Border.Rounding = 0
        Me.KryptonButton6.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonButton6.TabIndex = 465
        Me.KryptonButton6.Values.Text = ""
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.Panel3.Controls.Add(Me.KryptonButton7)
        Me.Panel3.Controls.Add(Me.KryptonLabel4)
        Me.Panel3.Controls.Add(Me.balance)
        Me.Panel3.Controls.Add(Me.currentqty)
        Me.Panel3.Controls.Add(Me.KryptonGroup9)
        Me.Panel3.Controls.Add(Me.KryptonLabel8)
        Me.Panel3.Controls.Add(Me.KryptonLabel6)
        Me.Panel3.Controls.Add(Me.setqty)
        Me.Panel3.Controls.Add(Me.KryptonLabel7)
        Me.Panel3.Controls.Add(Me.addr)
        Me.Panel3.Controls.Add(Me.minusr)
        Me.Panel3.Controls.Add(Me.KryptonButton4)
        Me.Panel3.Controls.Add(Me.KryptonButton5)
        Me.Panel3.Location = New System.Drawing.Point(346, 38)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(246, 421)
        Me.Panel3.TabIndex = 479
        '
        'KryptonButton7
        '
        Me.KryptonButton7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.KryptonButton7.Location = New System.Drawing.Point(19, 382)
        Me.KryptonButton7.Name = "KryptonButton7"
        Me.KryptonButton7.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonButton7.Size = New System.Drawing.Size(210, 38)
        Me.KryptonButton7.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.KryptonButton7.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Solid
        Me.KryptonButton7.StateCommon.Back.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias
        Me.KryptonButton7.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.KryptonButton7.StateCommon.Border.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Solid
        Me.KryptonButton7.StateCommon.Border.DrawBorders = CType(((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonButton7.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias
        Me.KryptonButton7.StateCommon.Border.Rounding = 10
        Me.KryptonButton7.StateCommon.Border.Width = 2
        Me.KryptonButton7.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White
        Me.KryptonButton7.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonButton7.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.KryptonButton7.StateDisabled.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.KryptonButton7.StateDisabled.Border.Color1 = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.KryptonButton7.StateDisabled.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonButton7.StateNormal.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Solid
        Me.KryptonButton7.StatePressed.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Solid
        Me.KryptonButton7.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.KryptonButton7.TabIndex = 478
        Me.KryptonButton7.Values.Text = "Summary"
        '
        'minusr
        '
        Me.minusr.Enabled = False
        Me.minusr.Location = New System.Drawing.Point(124, 307)
        Me.minusr.Multiline = True
        Me.minusr.Name = "minusr"
        Me.minusr.Size = New System.Drawing.Size(105, 29)
        Me.minusr.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.minusr.StateCommon.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.minusr.StateCommon.Border.Rounding = 5
        Me.minusr.StateCommon.Border.Width = 2
        Me.minusr.StateCommon.Content.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.minusr.StateDisabled.Back.Color1 = System.Drawing.Color.White
        Me.minusr.StateDisabled.Content.Color1 = System.Drawing.Color.Black
        Me.minusr.TabIndex = 479
        Me.minusr.Text = "0"
        Me.minusr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'addr
        '
        Me.addr.Enabled = False
        Me.addr.Location = New System.Drawing.Point(19, 307)
        Me.addr.Multiline = True
        Me.addr.Name = "addr"
        Me.addr.Size = New System.Drawing.Size(105, 29)
        Me.addr.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.addr.StateCommon.Border.DrawBorders = CType((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.addr.StateCommon.Border.Rounding = 5
        Me.addr.StateCommon.Border.Width = 2
        Me.addr.StateCommon.Content.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.addr.StateDisabled.Back.Color1 = System.Drawing.Color.White
        Me.addr.StateDisabled.Content.Color1 = System.Drawing.Color.Black
        Me.addr.TabIndex = 480
        Me.addr.Text = "0"
        Me.addr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.Panel4.Controls.Add(Me.locationgridview)
        Me.Panel4.Controls.Add(Me.updatelocation)
        Me.Panel4.Controls.Add(Me.KryptonLabel11)
        Me.Panel4.Controls.Add(Me.REFERENCE)
        Me.Panel4.Controls.Add(Me.KryptonLabel3)
        Me.Panel4.Controls.Add(Me.KryptonDataGridView1)
        Me.Panel4.Controls.Add(Me.summarylocation)
        Me.Panel4.Controls.Add(Me.TRANSTYPE)
        Me.Panel4.Controls.Add(Me.KryptonLabel10)
        Me.Panel4.Controls.Add(Me.Panel3)
        Me.Panel4.Controls.Add(Me.KryptonPanel1)
        Me.Panel4.Controls.Add(Me.Panel2)
        Me.Panel4.Controls.Add(Me.id)
        Me.Panel4.Controls.Add(Me.KryptonLabel5)
        Me.Panel4.Controls.Add(Me.KryptonLabel1)
        Me.Panel4.Controls.Add(Me.stockno)
        Me.Panel4.Location = New System.Drawing.Point(12, 12)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(592, 459)
        Me.Panel4.TabIndex = 480
        '
        'updatelocation
        '
        Me.updatelocation.Enabled = False
        Me.updatelocation.Location = New System.Drawing.Point(131, 409)
        Me.updatelocation.Multiline = True
        Me.updatelocation.Name = "updatelocation"
        Me.updatelocation.Size = New System.Drawing.Size(150, 29)
        Me.updatelocation.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.updatelocation.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.updatelocation.StateCommon.Border.Rounding = 0
        Me.updatelocation.StateCommon.Border.Width = 4
        Me.updatelocation.StateDisabled.Back.Color1 = System.Drawing.Color.White
        Me.updatelocation.StateDisabled.Content.Color1 = System.Drawing.Color.Black
        Me.updatelocation.TabIndex = 487
        '
        'KryptonLabel11
        '
        Me.KryptonLabel11.Location = New System.Drawing.Point(35, 374)
        Me.KryptonLabel11.Name = "KryptonLabel11"
        Me.KryptonLabel11.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonLabel11.Size = New System.Drawing.Size(88, 24)
        Me.KryptonLabel11.StateCommon.ShortText.Color1 = System.Drawing.Color.White
        Me.KryptonLabel11.StateCommon.ShortText.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel11.TabIndex = 486
        Me.KryptonLabel11.Values.Text = "REFERENCE"
        '
        'REFERENCE
        '
        Me.REFERENCE.Enabled = False
        Me.REFERENCE.Location = New System.Drawing.Point(131, 374)
        Me.REFERENCE.Multiline = True
        Me.REFERENCE.Name = "REFERENCE"
        Me.REFERENCE.Size = New System.Drawing.Size(150, 29)
        Me.REFERENCE.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.REFERENCE.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.REFERENCE.StateCommon.Border.Rounding = 0
        Me.REFERENCE.StateCommon.Border.Width = 4
        Me.REFERENCE.StateDisabled.Back.Color1 = System.Drawing.Color.White
        Me.REFERENCE.StateDisabled.Content.Color1 = System.Drawing.Color.Black
        Me.REFERENCE.TabIndex = 485
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.Location = New System.Drawing.Point(35, 332)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonLabel3.Size = New System.Drawing.Size(90, 24)
        Me.KryptonLabel3.StateCommon.ShortText.Color1 = System.Drawing.Color.White
        Me.KryptonLabel3.StateCommon.ShortText.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel3.TabIndex = 484
        Me.KryptonLabel3.Values.Text = "TRANSTYPE"
        '
        'KryptonDataGridView1
        '
        Me.KryptonDataGridView1.AllowUserToAddRows = False
        Me.KryptonDataGridView1.AllowUserToDeleteRows = False
        Me.KryptonDataGridView1.AllowUserToOrderColumns = True
        Me.KryptonDataGridView1.AllowUserToResizeColumns = False
        Me.KryptonDataGridView1.AllowUserToResizeRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(36, Byte), Integer))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        Me.KryptonDataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.KryptonDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.KryptonDataGridView1.ColumnHeadersHeight = 30
        Me.KryptonDataGridView1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.KryptonDataGridView1.Location = New System.Drawing.Point(599, 76)
        Me.KryptonDataGridView1.Name = "KryptonDataGridView1"
        Me.KryptonDataGridView1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver
        Me.KryptonDataGridView1.ReadOnly = True
        Me.KryptonDataGridView1.RowHeadersVisible = False
        Me.KryptonDataGridView1.RowHeadersWidth = 40
        Me.KryptonDataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.KryptonDataGridView1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White
        Me.KryptonDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.KryptonDataGridView1.Size = New System.Drawing.Size(314, 378)
        Me.KryptonDataGridView1.StateCommon.Background.Color1 = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.KryptonDataGridView1.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.KryptonDataGridView1.StateCommon.DataCell.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonDataGridView1.StateCommon.DataCell.Border.Width = 0
        Me.KryptonDataGridView1.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.KryptonDataGridView1.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.KryptonDataGridView1.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.KryptonDataGridView1.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Dashed
        Me.KryptonDataGridView1.StateCommon.HeaderColumn.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonDataGridView1.StateCommon.HeaderColumn.Border.Width = 0
        Me.KryptonDataGridView1.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.White
        Me.KryptonDataGridView1.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.KryptonDataGridView1.StateCommon.HeaderColumn.Content.Hint = ComponentFactory.Krypton.Toolkit.PaletteTextHint.AntiAlias
        Me.KryptonDataGridView1.TabIndex = 480
        '
        'summarylocation
        '
        Me.summarylocation.Location = New System.Drawing.Point(710, 174)
        Me.summarylocation.Name = "summarylocation"
        Me.summarylocation.Size = New System.Drawing.Size(100, 20)
        Me.summarylocation.TabIndex = 483
        '
        'TRANSTYPE
        '
        Me.TRANSTYPE.Enabled = False
        Me.TRANSTYPE.Location = New System.Drawing.Point(131, 332)
        Me.TRANSTYPE.Multiline = True
        Me.TRANSTYPE.Name = "TRANSTYPE"
        Me.TRANSTYPE.Size = New System.Drawing.Size(150, 29)
        Me.TRANSTYPE.StateCommon.Back.Color1 = System.Drawing.Color.White
        Me.TRANSTYPE.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.TRANSTYPE.StateCommon.Border.Rounding = 0
        Me.TRANSTYPE.StateCommon.Border.Width = 4
        Me.TRANSTYPE.StateDisabled.Back.Color1 = System.Drawing.Color.White
        Me.TRANSTYPE.StateDisabled.Content.Color1 = System.Drawing.Color.Black
        Me.TRANSTYPE.TabIndex = 482
        '
        'KryptonLabel10
        '
        Me.KryptonLabel10.Location = New System.Drawing.Point(598, 46)
        Me.KryptonLabel10.Name = "KryptonLabel10"
        Me.KryptonLabel10.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.KryptonLabel10.Size = New System.Drawing.Size(175, 24)
        Me.KryptonLabel10.StateCommon.ShortText.Color1 = System.Drawing.Color.White
        Me.KryptonLabel10.StateCommon.ShortText.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel10.TabIndex = 481
        Me.KryptonLabel10.Values.Text = "Location Summary Table"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AdjustmentToolStripMenuItem, Me.TransferToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(137, 48)
        '
        'AdjustmentToolStripMenuItem
        '
        Me.AdjustmentToolStripMenuItem.Name = "AdjustmentToolStripMenuItem"
        Me.AdjustmentToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.AdjustmentToolStripMenuItem.Text = "Adjustment"
        '
        'TransferToolStripMenuItem
        '
        Me.TransferToolStripMenuItem.Name = "TransferToolStripMenuItem"
        Me.TransferToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.TransferToolStripMenuItem.Text = "Transfer"
        '
        'locationform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Green
        Me.ClientSize = New System.Drawing.Size(972, 487)
        Me.Controls.Add(Me.Panel4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "locationform"
        Me.Opacity = 0.95R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "location"
        Me.TransparencyKey = System.Drawing.Color.Green
        CType(Me.locationgridview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.KryptonGroup9.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroup9.Panel.ResumeLayout(False)
        CType(Me.KryptonGroup9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroup9.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.KryptonDataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents KryptonLabel5 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents id As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents stockno As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents location As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents locationgridview As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents KryptonButton1 As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonButton2 As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonButton3 As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents balance As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel4 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonGroup9 As ComponentFactory.Krypton.Toolkit.KryptonGroup
    Friend WithEvents setlocation As ComboBox
    Friend WithEvents KryptonLabel6 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonButton4 As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents setqty As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel7 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonButton5 As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents currentqty As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel8 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents KryptonButton6 As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonLabel9 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents articleno As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents KryptonDataGridView1 As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents KryptonButton7 As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonLabel10 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents TRANSTYPE As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents summarylocation As TextBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents AdjustmentToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents KryptonButton8 As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonLabel11 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents REFERENCE As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents TransferToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents updatelocation As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents minusr As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents addr As ComponentFactory.Krypton.Toolkit.KryptonTextBox
End Class

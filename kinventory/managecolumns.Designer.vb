<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class managecolumns
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
        Me.supplier = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.mylocation = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.physical2 = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.Stockno = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.CONSUMPTION = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.NETAMOUNT = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.XRATE = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.WEIGHT = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.TOFOIL = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.TOORDER = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.INPUTTED = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.balalloc = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.COLORBASED = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.phasedout = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.status = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.issue = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.minimum = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.stockorder = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.Free = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.Allocation = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.physical = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.unitprice = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.disc = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.articleno = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.typecolor = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.costhead = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.adjqty = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.tdisc = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.tinputted = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.tnetamount = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.Ufactor = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.controlno = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.account = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.reference = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.qty = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.duedate = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.transno = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.Checker = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.tstockno = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.excess = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.remarks = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.transdate = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.transtype = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.txrate = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.tunitprice = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.Currency = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.tarticleno = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.ttypecolor = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.tcosthead = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.KryptonButton1 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonButton2 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.header = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'supplier
        '
        Me.supplier.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.supplier.Location = New System.Drawing.Point(16, 43)
        Me.supplier.Name = "supplier"
        Me.supplier.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.supplier.Size = New System.Drawing.Size(74, 19)
        Me.supplier.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.supplier.TabIndex = 10
        Me.supplier.Text = "Supplier"
        Me.supplier.Values.Text = "Supplier"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(388, 389)
        Me.TabControl1.TabIndex = 11
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.header)
        Me.TabPage1.Controls.Add(Me.mylocation)
        Me.TabPage1.Controls.Add(Me.physical2)
        Me.TabPage1.Controls.Add(Me.Stockno)
        Me.TabPage1.Controls.Add(Me.CONSUMPTION)
        Me.TabPage1.Controls.Add(Me.NETAMOUNT)
        Me.TabPage1.Controls.Add(Me.XRATE)
        Me.TabPage1.Controls.Add(Me.WEIGHT)
        Me.TabPage1.Controls.Add(Me.TOFOIL)
        Me.TabPage1.Controls.Add(Me.TOORDER)
        Me.TabPage1.Controls.Add(Me.INPUTTED)
        Me.TabPage1.Controls.Add(Me.balalloc)
        Me.TabPage1.Controls.Add(Me.COLORBASED)
        Me.TabPage1.Controls.Add(Me.phasedout)
        Me.TabPage1.Controls.Add(Me.status)
        Me.TabPage1.Controls.Add(Me.issue)
        Me.TabPage1.Controls.Add(Me.minimum)
        Me.TabPage1.Controls.Add(Me.stockorder)
        Me.TabPage1.Controls.Add(Me.Free)
        Me.TabPage1.Controls.Add(Me.Allocation)
        Me.TabPage1.Controls.Add(Me.physical)
        Me.TabPage1.Controls.Add(Me.unitprice)
        Me.TabPage1.Controls.Add(Me.disc)
        Me.TabPage1.Controls.Add(Me.articleno)
        Me.TabPage1.Controls.Add(Me.typecolor)
        Me.TabPage1.Controls.Add(Me.costhead)
        Me.TabPage1.Controls.Add(Me.supplier)
        Me.TabPage1.Location = New System.Drawing.Point(4, 30)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(380, 355)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Stocks Columns"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'mylocation
        '
        Me.mylocation.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.mylocation.Location = New System.Drawing.Point(142, 318)
        Me.mylocation.Name = "mylocation"
        Me.mylocation.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.mylocation.Size = New System.Drawing.Size(98, 19)
        Me.mylocation.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mylocation.TabIndex = 41
        Me.mylocation.Text = "My Location"
        Me.mylocation.Values.Text = "My Location"
        '
        'physical2
        '
        Me.physical2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.physical2.Location = New System.Drawing.Point(142, 193)
        Me.physical2.Name = "physical2"
        Me.physical2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.physical2.Size = New System.Drawing.Size(87, 19)
        Me.physical2.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.physical2.TabIndex = 40
        Me.physical2.Text = "Physical 2"
        Me.physical2.Values.Text = "Physical 2"
        '
        'Stockno
        '
        Me.Stockno.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.Stockno.Location = New System.Drawing.Point(16, 18)
        Me.Stockno.Name = "Stockno"
        Me.Stockno.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.Stockno.Size = New System.Drawing.Size(74, 19)
        Me.Stockno.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Stockno.TabIndex = 39
        Me.Stockno.Text = "Stockno"
        Me.Stockno.Values.Text = "Stockno"
        '
        'CONSUMPTION
        '
        Me.CONSUMPTION.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.CONSUMPTION.Location = New System.Drawing.Point(142, 293)
        Me.CONSUMPTION.Name = "CONSUMPTION"
        Me.CONSUMPTION.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.CONSUMPTION.Size = New System.Drawing.Size(144, 19)
        Me.CONSUMPTION.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CONSUMPTION.TabIndex = 38
        Me.CONSUMPTION.Text = "Anual Consumption"
        Me.CONSUMPTION.Values.Text = "Anual Consumption"
        '
        'NETAMOUNT
        '
        Me.NETAMOUNT.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.NETAMOUNT.Location = New System.Drawing.Point(142, 268)
        Me.NETAMOUNT.Name = "NETAMOUNT"
        Me.NETAMOUNT.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.NETAMOUNT.Size = New System.Drawing.Size(96, 19)
        Me.NETAMOUNT.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NETAMOUNT.TabIndex = 37
        Me.NETAMOUNT.Text = "Net Amount"
        Me.NETAMOUNT.Values.Text = "Net Amount"
        '
        'XRATE
        '
        Me.XRATE.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.XRATE.Location = New System.Drawing.Point(142, 243)
        Me.XRATE.Name = "XRATE"
        Me.XRATE.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.XRATE.Size = New System.Drawing.Size(67, 19)
        Me.XRATE.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XRATE.TabIndex = 36
        Me.XRATE.Text = "X-Rate"
        Me.XRATE.Values.Text = "X-Rate"
        '
        'WEIGHT
        '
        Me.WEIGHT.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.WEIGHT.Location = New System.Drawing.Point(142, 218)
        Me.WEIGHT.Name = "WEIGHT"
        Me.WEIGHT.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.WEIGHT.Size = New System.Drawing.Size(67, 19)
        Me.WEIGHT.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WEIGHT.TabIndex = 35
        Me.WEIGHT.Text = "Weight"
        Me.WEIGHT.Values.Text = "Weight"
        '
        'TOFOIL
        '
        Me.TOFOIL.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.TOFOIL.Location = New System.Drawing.Point(142, 143)
        Me.TOFOIL.Name = "TOFOIL"
        Me.TOFOIL.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.TOFOIL.Size = New System.Drawing.Size(66, 19)
        Me.TOFOIL.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TOFOIL.TabIndex = 34
        Me.TOFOIL.Text = "To Foil"
        Me.TOFOIL.Values.Text = "To Foil"
        '
        'TOORDER
        '
        Me.TOORDER.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.TOORDER.Location = New System.Drawing.Point(142, 118)
        Me.TOORDER.Name = "TOORDER"
        Me.TOORDER.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.TOORDER.Size = New System.Drawing.Size(79, 19)
        Me.TOORDER.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TOORDER.TabIndex = 33
        Me.TOORDER.Text = "To Order"
        Me.TOORDER.Values.Text = "To Order"
        '
        'INPUTTED
        '
        Me.INPUTTED.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.INPUTTED.Location = New System.Drawing.Point(142, 93)
        Me.INPUTTED.Name = "INPUTTED"
        Me.INPUTTED.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.INPUTTED.Size = New System.Drawing.Size(74, 19)
        Me.INPUTTED.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.INPUTTED.TabIndex = 32
        Me.INPUTTED.Text = "Inputted"
        Me.INPUTTED.Values.Text = "Inputted"
        '
        'balalloc
        '
        Me.balalloc.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.balalloc.Location = New System.Drawing.Point(142, 168)
        Me.balalloc.Name = "balalloc"
        Me.balalloc.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.balalloc.Size = New System.Drawing.Size(81, 19)
        Me.balalloc.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.balalloc.TabIndex = 31
        Me.balalloc.Text = "Ball Alloc"
        Me.balalloc.Values.Text = "Ball Alloc"
        '
        'COLORBASED
        '
        Me.COLORBASED.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.COLORBASED.Location = New System.Drawing.Point(142, 68)
        Me.COLORBASED.Name = "COLORBASED"
        Me.COLORBASED.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.COLORBASED.Size = New System.Drawing.Size(99, 19)
        Me.COLORBASED.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.COLORBASED.TabIndex = 30
        Me.COLORBASED.Text = "Based Color"
        Me.COLORBASED.Values.Text = "Based Color"
        '
        'phasedout
        '
        Me.phasedout.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.phasedout.Location = New System.Drawing.Point(142, 43)
        Me.phasedout.Name = "phasedout"
        Me.phasedout.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.phasedout.Size = New System.Drawing.Size(96, 19)
        Me.phasedout.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.phasedout.TabIndex = 29
        Me.phasedout.Text = "Phased Out"
        Me.phasedout.Values.Text = "Phased Out"
        '
        'status
        '
        Me.status.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.status.Location = New System.Drawing.Point(142, 18)
        Me.status.Name = "status"
        Me.status.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.status.Size = New System.Drawing.Size(63, 19)
        Me.status.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.status.TabIndex = 28
        Me.status.Text = "Status"
        Me.status.Values.Text = "Status"
        '
        'issue
        '
        Me.issue.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.issue.Location = New System.Drawing.Point(16, 318)
        Me.issue.Name = "issue"
        Me.issue.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.issue.Size = New System.Drawing.Size(57, 19)
        Me.issue.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.issue.TabIndex = 27
        Me.issue.Text = "Issue"
        Me.issue.Values.Text = "Issue"
        '
        'minimum
        '
        Me.minimum.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.minimum.Location = New System.Drawing.Point(16, 293)
        Me.minimum.Name = "minimum"
        Me.minimum.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.minimum.Size = New System.Drawing.Size(80, 19)
        Me.minimum.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minimum.TabIndex = 26
        Me.minimum.Text = "Minimum"
        Me.minimum.Values.Text = "Minimum"
        '
        'stockorder
        '
        Me.stockorder.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.stockorder.Location = New System.Drawing.Point(16, 268)
        Me.stockorder.Name = "stockorder"
        Me.stockorder.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.stockorder.Size = New System.Drawing.Size(97, 19)
        Me.stockorder.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stockorder.TabIndex = 25
        Me.stockorder.Text = "Stock Order"
        Me.stockorder.Values.Text = "Stock Order"
        '
        'Free
        '
        Me.Free.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.Free.Location = New System.Drawing.Point(16, 243)
        Me.Free.Name = "Free"
        Me.Free.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.Free.Size = New System.Drawing.Size(52, 19)
        Me.Free.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Free.TabIndex = 24
        Me.Free.Text = "Free"
        Me.Free.Values.Text = "Free"
        '
        'Allocation
        '
        Me.Allocation.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.Allocation.Location = New System.Drawing.Point(16, 218)
        Me.Allocation.Name = "Allocation"
        Me.Allocation.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.Allocation.Size = New System.Drawing.Size(84, 19)
        Me.Allocation.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Allocation.TabIndex = 23
        Me.Allocation.Text = "Allocation"
        Me.Allocation.Values.Text = "Allocation"
        '
        'physical
        '
        Me.physical.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.physical.Location = New System.Drawing.Point(16, 193)
        Me.physical.Name = "physical"
        Me.physical.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.physical.Size = New System.Drawing.Size(75, 19)
        Me.physical.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.physical.TabIndex = 22
        Me.physical.Text = "Physical"
        Me.physical.Values.Text = "Physical"
        '
        'unitprice
        '
        Me.unitprice.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.unitprice.Location = New System.Drawing.Point(16, 168)
        Me.unitprice.Name = "unitprice"
        Me.unitprice.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.unitprice.Size = New System.Drawing.Size(83, 19)
        Me.unitprice.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unitprice.TabIndex = 17
        Me.unitprice.Text = "Unit Price"
        Me.unitprice.Values.Text = "Unit Price"
        '
        'disc
        '
        Me.disc.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.disc.Location = New System.Drawing.Point(16, 143)
        Me.disc.Name = "disc"
        Me.disc.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.disc.Size = New System.Drawing.Size(77, 19)
        Me.disc.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.disc.TabIndex = 16
        Me.disc.Text = "Discount"
        Me.disc.Values.Text = "Discount"
        '
        'articleno
        '
        Me.articleno.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.articleno.Location = New System.Drawing.Point(16, 118)
        Me.articleno.Name = "articleno"
        Me.articleno.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.articleno.Size = New System.Drawing.Size(78, 19)
        Me.articleno.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.articleno.TabIndex = 15
        Me.articleno.Text = "Articleno"
        Me.articleno.Values.Text = "Articleno"
        '
        'typecolor
        '
        Me.typecolor.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.typecolor.Location = New System.Drawing.Point(16, 93)
        Me.typecolor.Name = "typecolor"
        Me.typecolor.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.typecolor.Size = New System.Drawing.Size(98, 19)
        Me.typecolor.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.typecolor.TabIndex = 13
        Me.typecolor.Text = "Type / Color"
        Me.typecolor.Values.Text = "Type / Color"
        '
        'costhead
        '
        Me.costhead.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.costhead.Location = New System.Drawing.Point(16, 68)
        Me.costhead.Name = "costhead"
        Me.costhead.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.costhead.Size = New System.Drawing.Size(83, 19)
        Me.costhead.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.costhead.TabIndex = 11
        Me.costhead.Text = "Costhead"
        Me.costhead.Values.Text = "Costhead"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.adjqty)
        Me.TabPage2.Controls.Add(Me.tdisc)
        Me.TabPage2.Controls.Add(Me.tinputted)
        Me.TabPage2.Controls.Add(Me.tnetamount)
        Me.TabPage2.Controls.Add(Me.Ufactor)
        Me.TabPage2.Controls.Add(Me.controlno)
        Me.TabPage2.Controls.Add(Me.account)
        Me.TabPage2.Controls.Add(Me.reference)
        Me.TabPage2.Controls.Add(Me.qty)
        Me.TabPage2.Controls.Add(Me.duedate)
        Me.TabPage2.Controls.Add(Me.transno)
        Me.TabPage2.Controls.Add(Me.Checker)
        Me.TabPage2.Controls.Add(Me.tstockno)
        Me.TabPage2.Controls.Add(Me.excess)
        Me.TabPage2.Controls.Add(Me.remarks)
        Me.TabPage2.Controls.Add(Me.transdate)
        Me.TabPage2.Controls.Add(Me.transtype)
        Me.TabPage2.Controls.Add(Me.txrate)
        Me.TabPage2.Controls.Add(Me.tunitprice)
        Me.TabPage2.Controls.Add(Me.Currency)
        Me.TabPage2.Controls.Add(Me.tarticleno)
        Me.TabPage2.Controls.Add(Me.ttypecolor)
        Me.TabPage2.Controls.Add(Me.tcosthead)
        Me.TabPage2.Location = New System.Drawing.Point(4, 30)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(380, 355)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Trans Columns"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'adjqty
        '
        Me.adjqty.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.adjqty.Location = New System.Drawing.Point(210, 268)
        Me.adjqty.Name = "adjqty"
        Me.adjqty.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.adjqty.Size = New System.Drawing.Size(118, 19)
        Me.adjqty.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.adjqty.TabIndex = 75
        Me.adjqty.Text = "Adjustment Qty"
        Me.adjqty.Values.Text = "Adjustment Qty"
        '
        'tdisc
        '
        Me.tdisc.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.tdisc.Location = New System.Drawing.Point(210, 143)
        Me.tdisc.Name = "tdisc"
        Me.tdisc.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.tdisc.Size = New System.Drawing.Size(77, 19)
        Me.tdisc.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tdisc.TabIndex = 74
        Me.tdisc.Text = "Discount"
        Me.tdisc.Values.Text = "Discount"
        '
        'tinputted
        '
        Me.tinputted.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.tinputted.Location = New System.Drawing.Point(210, 243)
        Me.tinputted.Name = "tinputted"
        Me.tinputted.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.tinputted.Size = New System.Drawing.Size(74, 19)
        Me.tinputted.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tinputted.TabIndex = 73
        Me.tinputted.Text = "Inputted"
        Me.tinputted.Values.Text = "Inputted"
        '
        'tnetamount
        '
        Me.tnetamount.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.tnetamount.Location = New System.Drawing.Point(210, 218)
        Me.tnetamount.Name = "tnetamount"
        Me.tnetamount.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.tnetamount.Size = New System.Drawing.Size(96, 19)
        Me.tnetamount.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tnetamount.TabIndex = 72
        Me.tnetamount.Text = "Net Amount"
        Me.tnetamount.Values.Text = "Net Amount"
        '
        'Ufactor
        '
        Me.Ufactor.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.Ufactor.Location = New System.Drawing.Point(210, 68)
        Me.Ufactor.Name = "Ufactor"
        Me.Ufactor.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.Ufactor.Size = New System.Drawing.Size(77, 19)
        Me.Ufactor.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ufactor.TabIndex = 71
        Me.Ufactor.Text = "U-Factor"
        Me.Ufactor.Values.Text = "U-Factor"
        '
        'controlno
        '
        Me.controlno.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.controlno.Location = New System.Drawing.Point(16, 293)
        Me.controlno.Name = "controlno"
        Me.controlno.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.controlno.Size = New System.Drawing.Size(89, 19)
        Me.controlno.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.controlno.TabIndex = 70
        Me.controlno.Text = "Control No"
        Me.controlno.Values.Text = "Control No"
        '
        'account
        '
        Me.account.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.account.Location = New System.Drawing.Point(16, 268)
        Me.account.Name = "account"
        Me.account.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.account.Size = New System.Drawing.Size(74, 19)
        Me.account.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.account.TabIndex = 69
        Me.account.Text = "Account"
        Me.account.Values.Text = "Account"
        '
        'reference
        '
        Me.reference.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.reference.Location = New System.Drawing.Point(16, 243)
        Me.reference.Name = "reference"
        Me.reference.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.reference.Size = New System.Drawing.Size(87, 19)
        Me.reference.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reference.TabIndex = 68
        Me.reference.Text = "Reference"
        Me.reference.Values.Text = "Reference"
        '
        'qty
        '
        Me.qty.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.qty.Location = New System.Drawing.Point(16, 218)
        Me.qty.Name = "qty"
        Me.qty.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.qty.Size = New System.Drawing.Size(75, 19)
        Me.qty.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.qty.TabIndex = 67
        Me.qty.Text = "Quantity"
        Me.qty.Values.Text = "Quantity"
        '
        'duedate
        '
        Me.duedate.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.duedate.Location = New System.Drawing.Point(16, 193)
        Me.duedate.Name = "duedate"
        Me.duedate.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.duedate.Size = New System.Drawing.Size(82, 19)
        Me.duedate.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.duedate.TabIndex = 66
        Me.duedate.Text = "Due Date"
        Me.duedate.Values.Text = "Due Date"
        '
        'transno
        '
        Me.transno.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.transno.Location = New System.Drawing.Point(16, 18)
        Me.transno.Name = "transno"
        Me.transno.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.transno.Size = New System.Drawing.Size(80, 19)
        Me.transno.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.transno.TabIndex = 64
        Me.transno.Text = "Trans No"
        Me.transno.Values.Text = "Trans No"
        '
        'Checker
        '
        Me.Checker.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.Checker.Location = New System.Drawing.Point(210, 93)
        Me.Checker.Name = "Checker"
        Me.Checker.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.Checker.Size = New System.Drawing.Size(75, 19)
        Me.Checker.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Checker.TabIndex = 53
        Me.Checker.Text = "Checker"
        Me.Checker.Values.Text = "Checker"
        '
        'tstockno
        '
        Me.tstockno.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.tstockno.Location = New System.Drawing.Point(16, 43)
        Me.tstockno.Name = "tstockno"
        Me.tstockno.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.tstockno.Size = New System.Drawing.Size(79, 19)
        Me.tstockno.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstockno.TabIndex = 52
        Me.tstockno.Text = "Stock No"
        Me.tstockno.Values.Text = "Stock No"
        '
        'excess
        '
        Me.excess.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.excess.Location = New System.Drawing.Point(210, 18)
        Me.excess.Name = "excess"
        Me.excess.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.excess.Size = New System.Drawing.Size(68, 19)
        Me.excess.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.excess.TabIndex = 51
        Me.excess.Text = "Excess"
        Me.excess.Values.Text = "Excess"
        '
        'remarks
        '
        Me.remarks.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.remarks.Location = New System.Drawing.Point(210, 43)
        Me.remarks.Name = "remarks"
        Me.remarks.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.remarks.Size = New System.Drawing.Size(79, 19)
        Me.remarks.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.remarks.TabIndex = 50
        Me.remarks.Text = "Remarks"
        Me.remarks.Values.Text = "Remarks"
        '
        'transdate
        '
        Me.transdate.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.transdate.Location = New System.Drawing.Point(16, 168)
        Me.transdate.Name = "transdate"
        Me.transdate.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.transdate.Size = New System.Drawing.Size(92, 19)
        Me.transdate.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.transdate.TabIndex = 49
        Me.transdate.Text = "Trans Date"
        Me.transdate.Values.Text = "Trans Date"
        '
        'transtype
        '
        Me.transtype.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.transtype.Location = New System.Drawing.Point(16, 143)
        Me.transtype.Name = "transtype"
        Me.transtype.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.transtype.Size = New System.Drawing.Size(93, 19)
        Me.transtype.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.transtype.TabIndex = 48
        Me.transtype.Text = "Trans Type"
        Me.transtype.Values.Text = "Trans Type"
        '
        'txrate
        '
        Me.txrate.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.txrate.Location = New System.Drawing.Point(210, 193)
        Me.txrate.Name = "txrate"
        Me.txrate.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.txrate.Size = New System.Drawing.Size(67, 19)
        Me.txrate.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txrate.TabIndex = 47
        Me.txrate.Text = "X-Rate"
        Me.txrate.Values.Text = "X-Rate"
        '
        'tunitprice
        '
        Me.tunitprice.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.tunitprice.Location = New System.Drawing.Point(210, 118)
        Me.tunitprice.Name = "tunitprice"
        Me.tunitprice.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.tunitprice.Size = New System.Drawing.Size(83, 19)
        Me.tunitprice.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tunitprice.TabIndex = 46
        Me.tunitprice.Text = "Unit Price"
        Me.tunitprice.Values.Text = "Unit Price"
        '
        'Currency
        '
        Me.Currency.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.Currency.Location = New System.Drawing.Point(210, 168)
        Me.Currency.Name = "Currency"
        Me.Currency.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.Currency.Size = New System.Drawing.Size(80, 19)
        Me.Currency.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Currency.TabIndex = 45
        Me.Currency.Text = "Currency"
        Me.Currency.Values.Text = "Currency"
        '
        'tarticleno
        '
        Me.tarticleno.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.tarticleno.Location = New System.Drawing.Point(16, 118)
        Me.tarticleno.Name = "tarticleno"
        Me.tarticleno.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.tarticleno.Size = New System.Drawing.Size(78, 19)
        Me.tarticleno.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tarticleno.TabIndex = 44
        Me.tarticleno.Text = "Articleno"
        Me.tarticleno.Values.Text = "Articleno"
        '
        'ttypecolor
        '
        Me.ttypecolor.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.ttypecolor.Location = New System.Drawing.Point(16, 93)
        Me.ttypecolor.Name = "ttypecolor"
        Me.ttypecolor.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.ttypecolor.Size = New System.Drawing.Size(98, 19)
        Me.ttypecolor.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ttypecolor.TabIndex = 43
        Me.ttypecolor.Text = "Type / Color"
        Me.ttypecolor.Values.Text = "Type / Color"
        '
        'tcosthead
        '
        Me.tcosthead.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.tcosthead.Location = New System.Drawing.Point(16, 68)
        Me.tcosthead.Name = "tcosthead"
        Me.tcosthead.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.tcosthead.Size = New System.Drawing.Size(83, 19)
        Me.tcosthead.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tcosthead.TabIndex = 42
        Me.tcosthead.Text = "Costhead"
        Me.tcosthead.Values.Text = "Costhead"
        '
        'KryptonButton1
        '
        Me.KryptonButton1.Location = New System.Drawing.Point(227, 424)
        Me.KryptonButton1.Name = "KryptonButton1"
        Me.KryptonButton1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver
        Me.KryptonButton1.Size = New System.Drawing.Size(68, 25)
        Me.KryptonButton1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonButton1.StateCommon.Border.Rounding = 0
        Me.KryptonButton1.TabIndex = 12
        Me.KryptonButton1.Values.Text = "Apply"
        '
        'KryptonButton2
        '
        Me.KryptonButton2.Location = New System.Drawing.Point(311, 424)
        Me.KryptonButton2.Name = "KryptonButton2"
        Me.KryptonButton2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver
        Me.KryptonButton2.Size = New System.Drawing.Size(68, 25)
        Me.KryptonButton2.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonButton2.StateCommon.Border.Rounding = 0
        Me.KryptonButton2.TabIndex = 13
        Me.KryptonButton2.Values.Text = "Cancel"
        '
        'header
        '
        Me.header.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.header.Location = New System.Drawing.Point(275, 18)
        Me.header.Name = "header"
        Me.header.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.header.Size = New System.Drawing.Size(69, 19)
        Me.header.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.header.TabIndex = 42
        Me.header.Text = "Header"
        Me.header.Values.Text = "Header"
        '
        'managecolumns
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(425, 480)
        Me.Controls.Add(Me.KryptonButton2)
        Me.Controls.Add(Me.KryptonButton1)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "managecolumns"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manage Columns"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents supplier As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents disc As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents articleno As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents typecolor As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents costhead As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents KryptonButton1 As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonButton2 As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents NETAMOUNT As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents XRATE As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents WEIGHT As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents TOFOIL As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents TOORDER As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents INPUTTED As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents balalloc As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents COLORBASED As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents phasedout As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents status As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents issue As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents minimum As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents stockorder As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents Free As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents Allocation As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents physical As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents unitprice As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents Stockno As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents CONSUMPTION As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents physical2 As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents tinputted As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents tnetamount As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents Ufactor As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents controlno As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents account As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents reference As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents qty As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents duedate As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents transno As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents Checker As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents tstockno As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents excess As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents remarks As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents transdate As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents transtype As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents txrate As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents tunitprice As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents Currency As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents tarticleno As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents ttypecolor As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents tcosthead As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents tdisc As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents mylocation As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents adjqty As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents header As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
End Class

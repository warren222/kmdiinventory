﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class accountinginventory
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
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.STOCKS_TBBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.inventoryds = New kinventory.inventoryds()
        CType(Me.STOCKS_TBBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.inventoryds, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.STOCKS_TBBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "kinventory.Report5.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(562, 395)
        Me.ReportViewer1.TabIndex = 0
        '
        'STOCKS_TBBindingSource
        '
        Me.STOCKS_TBBindingSource.DataMember = "STOCKS_TB"
        Me.STOCKS_TBBindingSource.DataSource = Me.inventoryds
        '
        'inventoryds
        '
        Me.inventoryds.DataSetName = "inventoryds"
        Me.inventoryds.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'accountinginventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(562, 395)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "accountinginventory"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.STOCKS_TBBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.inventoryds, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents STOCKS_TBBindingSource As BindingSource
    Friend WithEvents inventoryds As inventoryds
End Class

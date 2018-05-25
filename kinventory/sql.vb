Imports System.IO
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Security.Cryptography
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.ComponentModel

Public Class sql
    Dim datasource As String = Form9.myaccess.Text.ToString
    Dim catalog As String = "FINALTRANS"
    Dim userid As String = "kmdiadmin"
    Dim password As String = "kmdiadmin"
    Public sqlcon As New SqlConnection With {.ConnectionString = "Data Source='" & datasource & "';Network Library=DBMSSOCN;Initial Catalog='" & catalog & "';User ID='" & userid & "';Password='" & password & "';"}
    Public sqlcon1 As New SqlConnection With {.ConnectionString = "Data Source='121.58.229.248,49107';Network Library=DBMSSOCN;Initial Catalog='KMDIDATA';User ID='kmdiadmin';Password='kmdiadmin';"}
    Dim da As New SqlDataAdapter
    Dim sqlcmd As New SqlCommand
    'Dim scrollval As Integer
    'Dim transds As New DataSet
    'Dim transda As New SqlDataAdapter
    Public Sub loadstocks()
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            ds.Clear()
            Dim str As String = "select
a.*,
(select sum(qty) from LOCATIONTB where STOCKNO=a.STOCKNO) as MYLOCATION
 from stocks_tb AS A
order by A.articleno asc"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            Form2.stocksBindingSource.DataSource = Nothing
            Form2.stocksBindingSource.DataSource = ds
            Form2.stocksBindingSource.DataMember = "stocks_tb"
            Form2.stocksgridview.DataSource = Form2.stocksBindingSource

            Form2.stocksgridview.Columns("UFACTOR").Visible = False
            Form2.stocksgridview.Columns("MONETARY").Visible = False
            Form2.stocksgridview.Columns("UNITPRICE").Visible = True
            Form2.stocksgridview.Columns("DESCRIPTION").Visible = False
            Form2.stocksgridview.Columns("UNIT").Visible = False
            Form2.stocksgridview.Columns("LOCATION").Visible = False
            Form2.stocksgridview.Columns("HEADER").Visible = False
            Form2.stocksgridview.Columns("AVEUSAGE").Visible = False
            Form2.stocksgridview.Columns("QTY").Visible = False
            Form2.stocksgridview.Columns("NEEDTOORDER").Visible = False
            Form2.stocksgridview.Columns("FINALNEEDTOORDER").Visible = False

            Form2.stocksgridview.Columns("ALLOCATION").DefaultCellStyle.Format = "N2"
            Form2.stocksgridview.Columns("FREE").DefaultCellStyle.Format = "N2"
            Form2.stocksgridview.Columns("STOCKORDER").DefaultCellStyle.Format = "N2"
            Form2.stocksgridview.Columns("MINIMUM").DefaultCellStyle.Format = "N2"
            Form2.stocksgridview.Columns("ISSUE").DefaultCellStyle.Format = "N2"
            Form2.stocksgridview.Columns("BALALLOC").DefaultCellStyle.Format = "N2"
            Form2.stocksgridview.Columns("WEIGHT").DefaultCellStyle.Format = "N4"
            Form2.stocksgridview.Columns("PHYSICAL").DefaultCellStyle.Format = "N2"
            Form2.stocksgridview.Columns("PHYSICAL2").DefaultCellStyle.Format = "N2"
            Form2.stocksgridview.Columns("UFACTOR").DefaultCellStyle.Format = "N2"
            Form2.stocksgridview.Columns("UNITPRICE").DefaultCellStyle.Format = "N4"
            Form2.stocksgridview.Columns("XRATE").DefaultCellStyle.Format = "N2"
            Form2.stocksgridview.Columns("NETAMOUNT").DefaultCellStyle.Format = "N2"
            Form2.stocksgridview.Columns("CONSUMPTION").DefaultCellStyle.Format = "N2"
            Form2.stocksgridview.Columns("MYLOCATION").DefaultCellStyle.Format = "N2"

            Form2.stocksgridview.Columns("ALLOCATION").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.stocksgridview.Columns("FREE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.stocksgridview.Columns("STOCKORDER").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.stocksgridview.Columns("MINIMUM").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.stocksgridview.Columns("ISSUE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.stocksgridview.Columns("BALALLOC").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.stocksgridview.Columns("WEIGHT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.stocksgridview.Columns("PHYSICAL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.stocksgridview.Columns("PHYSICAL2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.stocksgridview.Columns("UFACTOR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.stocksgridview.Columns("UNITPRICE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.stocksgridview.Columns("XRATE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.stocksgridview.Columns("NETAMOUNT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.stocksgridview.Columns("CONSUMPTION").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.stocksgridview.Columns("MYLOCATION").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            managecols()
            loadsearchbox()
            fillform()
            notifycritical()


            For i As Integer = 0 To Form2.stocksgridview.RowCount - 1 Step +1
                Dim s As String = Trim(Form2.stocksgridview.Rows(i).Cells("PHYSICAL").Value.ToString)
                Dim t As String = Trim(Form2.stocksgridview.Rows(i).Cells("MYLOCATION").Value.ToString)
                If s = t Then
                    Form2.stocksgridview.Rows(i).Cells("MYLOCATION").Style.ForeColor = Color.Black
                Else
                    Form2.stocksgridview.Rows(i).Cells("MYLOCATION").Style.ForeColor = Color.Red
                End If
            Next
        Catch ex As SqlException
            If ex.Number = 1205 Then
            Else
                MsgBox(ex.ToString)
            End If
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub searchstocks(ByVal search As String)
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            sqlcmd = New SqlCommand(search, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.stocksgridview.DataSource = Nothing
            Form2.stocksgridview.DataSource = bs

            Form2.stocksgridview.Columns("UFACTOR").Visible = False
            Form2.stocksgridview.Columns("MONETARY").Visible = False
            Form2.stocksgridview.Columns("UNITPRICE").Visible = True
            Form2.stocksgridview.Columns("DESCRIPTION").Visible = False
            Form2.stocksgridview.Columns("UNIT").Visible = False
            Form2.stocksgridview.Columns("LOCATION").Visible = False
            Form2.stocksgridview.Columns("HEADER").Visible = False
            Form2.stocksgridview.Columns("AVEUSAGE").Visible = False
            Form2.stocksgridview.Columns("QTY").Visible = False
            Form2.stocksgridview.Columns("NEEDTOORDER").Visible = False
            Form2.stocksgridview.Columns("FINALNEEDTOORDER").Visible = False

            Form2.stocksgridview.Columns("ALLOCATION").DefaultCellStyle.Format = "N2"
            Form2.stocksgridview.Columns("FREE").DefaultCellStyle.Format = "N2"
            Form2.stocksgridview.Columns("STOCKORDER").DefaultCellStyle.Format = "N2"
            Form2.stocksgridview.Columns("MINIMUM").DefaultCellStyle.Format = "N2"
            Form2.stocksgridview.Columns("ISSUE").DefaultCellStyle.Format = "N2"
            Form2.stocksgridview.Columns("BALALLOC").DefaultCellStyle.Format = "N2"
            Form2.stocksgridview.Columns("WEIGHT").DefaultCellStyle.Format = "N4"
            Form2.stocksgridview.Columns("PHYSICAL").DefaultCellStyle.Format = "N2"
            Form2.stocksgridview.Columns("PHYSICAL2").DefaultCellStyle.Format = "N2"
            Form2.stocksgridview.Columns("UFACTOR").DefaultCellStyle.Format = "N2"
            Form2.stocksgridview.Columns("UNITPRICE").DefaultCellStyle.Format = "N4"
            Form2.stocksgridview.Columns("XRATE").DefaultCellStyle.Format = "N2"
            Form2.stocksgridview.Columns("NETAMOUNT").DefaultCellStyle.Format = "N2"
            Form2.stocksgridview.Columns("CONSUMPTION").DefaultCellStyle.Format = "N2"
            Form2.stocksgridview.Columns("MYLOCATION").DefaultCellStyle.Format = "N2"

            Form2.stocksgridview.Columns("ALLOCATION").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.stocksgridview.Columns("FREE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.stocksgridview.Columns("STOCKORDER").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.stocksgridview.Columns("MINIMUM").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.stocksgridview.Columns("ISSUE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.stocksgridview.Columns("BALALLOC").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.stocksgridview.Columns("WEIGHT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.stocksgridview.Columns("PHYSICAL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.stocksgridview.Columns("PHYSICAL2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.stocksgridview.Columns("UFACTOR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.stocksgridview.Columns("UNITPRICE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.stocksgridview.Columns("XRATE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.stocksgridview.Columns("NETAMOUNT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.stocksgridview.Columns("CONSUMPTION").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.stocksgridview.Columns("MYLOCATION").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            fillform()
            managecols()

            For i As Integer = 0 To Form2.stocksgridview.RowCount - 1 Step +1
                Dim s As String = Form2.stocksgridview.Rows(i).Cells("PHYSICAL").Value.ToString
                Dim t As String = Form2.stocksgridview.Rows(i).Cells("MYLOCATION").Value.ToString
                If s = t Then
                    Form2.stocksgridview.Rows(i).Cells("MYLOCATION").Style.ForeColor = Color.Black
                Else
                    Form2.stocksgridview.Rows(i).Cells("MYLOCATION").Style.ForeColor = Color.Red
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub notifycritical()
        Try
            Dim str As String = "select count(status) from stocks_tb where status = 'Critical' and phasedout = ''"
            sqlcmd = New SqlCommand(str, sqlcon)
            Dim read As SqlDataReader = sqlcmd.ExecuteReader
            Dim x As String
            While read.Read
                x = read(0).ToString
            End While
            read.Close()

            Dim str1 As String = "select count(physical) from stocks_tb where physical<=0 and phasedout = ''"
            sqlcmd = New SqlCommand(str1, sqlcon)
            Dim read2 As SqlDataReader = sqlcmd.ExecuteReader
            Dim y As String
            While read2.Read
                y = read2(0).ToString
            End While
            read2.Close()

            Dim str3 As String = "select count(duedate) from trans_tb where transtype='Order' and xyzref='' and case when isdate(duedate)=1 then cast(duedate as date) end <=getdate()"
            sqlcmd = New SqlCommand(str3, sqlcon)
            Dim read3 As SqlDataReader = sqlcmd.ExecuteReader
            Dim o As String
            While read3.Read
                o = read3(0).ToString
            End While
            read3.Close()

            If x = "0" Then
                x = 0
            End If
            If y = "0" Then
                y = 0
            End If
            If o = "" Then
                o = 0
            End If
            Dim num1 As Double = x
            Dim num2 As Double = y
            Dim num3 As Double = o
            Dim z As Double = num1 + num2 + num3

            If z = "0" Then
                Form2.notification.Text = "Notification"
                Form2.notification.StateCommon.Content.ShortText.Color1 = Color.Black
            ElseIf z = "1" Then
                Form2.notification.Text = "" & z & " " + "Notification"
                Form2.notification.StateCommon.Content.ShortText.Color1 = Color.Black
            Else
                Form2.notification.Text = "" & z & " " + "Notifications"
                Form2.notification.StateCommon.Content.ShortText.Color1 = Color.Red
            End If

            If num1 = "0" Then
                NotiForm.KryptonButton1.Text = "Critical Status"
                NotiForm.KryptonButton1.StateCommon.Content.ShortText.Color1 = Color.Black
            Else
                NotiForm.KryptonButton1.Text = "" & num1 & " " + "Critical Status"
                NotiForm.KryptonButton1.StateCommon.Content.ShortText.Color1 = Color.Red
            End If
            If num2 = "0" Then
                NotiForm.KryptonButton2.Text = "Out of Stock"
                NotiForm.KryptonButton2.StateCommon.Content.ShortText.Color1 = Color.Black
            Else
                NotiForm.KryptonButton2.Text = "" & num2 & " " + "Out of Stock"
                NotiForm.KryptonButton2.StateCommon.Content.ShortText.Color1 = Color.Red
            End If
            If num3 = "0" Then
                NotiForm.KryptonButton3.Text = "Order Due"
                NotiForm.KryptonButton3.StateCommon.Content.ShortText.Color1 = Color.Black
            Else
                NotiForm.KryptonButton3.Text = "" & num3 & " " + "Order Due"
                NotiForm.KryptonButton3.StateCommon.Content.ShortText.Color1 = Color.Red
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub loadsuppliersearch(ByVal phasedout As String)
        Try
            sqlcon.Open()
            Dim supplierds As New DataSet
            Dim supplierbindingsource As New BindingSource
            supplierds.Clear()
            Dim str As String = "select distinct supplier from stocks_tb where " & phasedout & ""
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(supplierds, "stocks_tb")
            supplierbindingsource.DataSource = supplierds
            supplierbindingsource.DataMember = "stocks_tb"
            Form2.supplier.DataSource = supplierbindingsource
            Form2.supplier.DisplayMember = "supplier"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub loadcostheadsearch(ByVal supplier As String, ByVal phasedout As String)
        Try
            sqlcon.Open()
            Dim costheadds As New DataSet
            Dim costheadbindingsource As New BindingSource
            costheadds.Clear()
            Dim str As String = "select distinct costhead from stocks_tb where supplier  = " & supplier & " " & phasedout & ""
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(costheadds, "stocks_tb")
            costheadbindingsource.DataSource = costheadds
            costheadbindingsource.DataMember = "stocks_tb"
            Form2.costheadsearch.DataSource = costheadbindingsource
            Form2.costheadsearch.DisplayMember = "costhead"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub loadtypecolorsearch(ByVal supplier As String, ByVal costhead As String, ByVal phasedout As String)
        Try
            sqlcon.Open()
            Dim typecolords As New DataSet
            Dim typecolorbs As New BindingSource
            typecolords.Clear()
            Dim str1 As String = "select distinct typecolor from stocks_tb where supplier = " & supplier & " and costhead=" & costhead & " " & phasedout & ""
            sqlcmd = New SqlCommand(str1, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(typecolords, "stocks_tb")
            typecolorbs.DataSource = typecolords
            typecolorbs.DataMember = "stocks_tb"
            Form2.typecolorsearch.DataSource = typecolorbs
            Form2.typecolorsearch.DisplayMember = "typecolor"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub loadarticlesearch(ByVal supplier As String, ByVal costhead As String, ByVal typec As String, ByVal phasedout As String)
        Try
            sqlcon.Open()
            Dim articleds As New DataSet
            Dim articlebs As New BindingSource
            articleds.Clear()
            Dim str2 As String = "select distinct articleno from stocks_tb where supplier=" & supplier & " and costhead=" & costhead & " and typecolor=" & typec & " " & phasedout & ""
            sqlcmd = New SqlCommand(str2, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(articleds, "stocks_tb")
            articlebs.DataSource = articleds
            articlebs.DataMember = "stocks_tb"
            Form2.articlenosearch.DataSource = articlebs
            Form2.articlenosearch.DisplayMember = "articleno"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub

    Public Sub loadsearchbox()
        Try
            Dim costheadds As New DataSet
            Dim costheadbindingsource As New BindingSource
            costheadds.Clear()
            Dim str As String = "select distinct costhead from stocks_tb"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(costheadds, "stocks_tb")
            costheadbindingsource.DataSource = costheadds
            costheadbindingsource.DataMember = "stocks_tb"
            Form3.costhead.DataSource = costheadbindingsource
            Form3.costhead.DisplayMember = "costhead"
            Form3.costhead.SelectedIndex = -1
            Dim typecolords As New DataSet
            Dim typecolorbs As New BindingSource
            typecolords.Clear()
            Dim str1 As String = "select distinct typecolor from stocks_tb"
            sqlcmd = New SqlCommand(str1, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(typecolords, "stocks_tb")
            typecolorbs.DataSource = typecolords
            typecolorbs.DataMember = "stocks_tb"
            Form3.typecolor.DataSource = typecolorbs
            Form3.typecolor.DisplayMember = "typecolor"
            Form3.typecolor.SelectedIndex = -1
            Dim articleds As New DataSet
            Dim articlebs As New BindingSource
            articleds.Clear()
            Dim str2 As String = "select distinct articleno from stocks_tb"
            sqlcmd = New SqlCommand(str2, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(articleds, "stocks_tb")
            articlebs.DataSource = articleds
            articlebs.DataMember = "stocks_tb"
            Form3.articleno.DataSource = articlebs
            Form3.articleno.DisplayMember = "articleno"
            Form3.articleno.SelectedIndex = -1
            Dim colorbasedds As New DataSet
            Dim colorbasedbs As New BindingSource
            colorbasedds.Clear()
            Dim str3 As String = "select distinct stockno from stocks_tb"
            sqlcmd = New SqlCommand(str3, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(colorbasedds, "stocks_tb")
            colorbasedbs.DataSource = colorbasedds
            colorbasedbs.DataMember = "stocks_tb"
            Form3.colorbased.DataSource = colorbasedbs
            Form3.colorbased.DisplayMember = "stockno"
            Form3.colorbased.SelectedIndex = -1
            PhasedoutForm.colorbased.DataSource = colorbasedbs
            PhasedoutForm.colorbased.DisplayMember = "stockno"
            PhasedoutForm.colorbased.SelectedIndex = -1


            Dim supplierds As New DataSet
            Dim supplierbs As New BindingSource
            supplierds.Clear()
            Dim str4 As String = "select distinct supplier from stocks_tb"
            sqlcmd = New SqlCommand(str4, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(supplierds, "stocks_tb")
            supplierbs.DataSource = supplierds
            supplierbs.DataMember = "stocks_tb"
            Form2.reportsupplier.DataSource = supplierbs
            Form2.reportsupplier.DisplayMember = "supplier"
            Form2.reportsupplier.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub fillform()
        Try
            Dim costheadds As New DataSet
            Dim costheadbindingsource As New BindingSource
            costheadds.Clear()
            Dim str As String = "select distinct costhead from stocks_tb"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(costheadds, "stocks_tb")
            costheadbindingsource.DataSource = costheadds
            costheadbindingsource.DataMember = "stocks_tb"
            Form3.costhead.DataSource = costheadbindingsource
            Form3.costhead.DisplayMember = "costhead"
            Form3.costhead.SelectedIndex = -1

            Form4.costhead.DataSource = costheadbindingsource
            Form4.costhead.DisplayMember = "costhead"
            Form4.costhead.SelectedIndex = -1
            Dim typecolords As New DataSet
            Dim typecolorbs As New BindingSource
            typecolords.Clear()
            Dim str1 As String = "select distinct typecolor from stocks_tb"
            sqlcmd = New SqlCommand(str1, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(typecolords, "stocks_tb")
            typecolorbs.DataSource = typecolords
            typecolorbs.DataMember = "stocks_tb"
            Form3.typecolor.DataSource = typecolorbs
            Form3.typecolor.DisplayMember = "typecolor"
            Form3.typecolor.SelectedIndex = -1

            Form4.typecolor.DataSource = typecolorbs
            Form4.typecolor.DisplayMember = "typecolor"
            Form4.typecolor.SelectedIndex = -1
            Dim articleds As New DataSet
            Dim articlebs As New BindingSource
            articleds.Clear()
            Dim str2 As String = "select distinct articleno from stocks_tb"
            sqlcmd = New SqlCommand(str2, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(articleds, "stocks_tb")
            articlebs.DataSource = articleds
            articlebs.DataMember = "stocks_tb"
            Form3.articleno.DataSource = articlebs
            Form3.articleno.DisplayMember = "articleno"
            Form3.articleno.SelectedIndex = -1

            Form4.articleno.DataSource = articlebs
            Form4.articleno.DisplayMember = "articleno"
            Form4.articleno.SelectedIndex = -1
            Dim headerds As New DataSet
            Dim headerbs As New BindingSource
            headerds.Clear()
            Dim str3 As String = "select distinct header from stocks_tb"
            sqlcmd = New SqlCommand(str3, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(headerds, "stocks_tb")
            headerbs.DataSource = headerds
            headerbs.DataMember = "stocks_tb"
            Form3.header.DataSource = headerbs
            Form3.header.DisplayMember = "header"
            Form3.header.SelectedIndex = -1

            Form4.header.DataSource = headerbs
            Form4.header.DisplayMember = "header"
            Form4.header.SelectedIndex = -1
            Dim supplierds As New DataSet
            Dim supplierbs As New BindingSource
            supplierds.Clear()
            Dim str4 As String = "select distinct supplier from stocks_tb"
            sqlcmd = New SqlCommand(str4, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(supplierds, "stocks_tb")
            supplierbs.DataSource = supplierds
            supplierbs.DataMember = "stocks_tb"
            Form3.supplier.DataSource = supplierbs
            Form3.supplier.DisplayMember = "supplier"
            Form3.supplier.SelectedIndex = -1

            Form4.supplier.DataSource = supplierbs
            Form4.supplier.DisplayMember = "supplier"
            Form4.supplier.SelectedIndex = -1

            Dim colorbasedds As New DataSet
            Dim colorbasedbs As New BindingSource
            colorbasedds.Clear()
            Dim str5 As String = "select distinct stockno from stocks_tb"
            sqlcmd = New SqlCommand(str5, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(colorbasedds, "stocks_tb")
            colorbasedbs.DataSource = colorbasedds
            colorbasedbs.DataMember = "stocks_tb"
            Form3.colorbased.DataSource = colorbasedbs
            Form3.colorbased.DisplayMember = "stockno"
            Form3.colorbased.SelectedIndex = -1

            Form4.colorbased.DataSource = colorbasedbs
            Form4.colorbased.DisplayMember = "stockno"
            Form4.colorbased.SelectedIndex = -1

            PhasedoutForm.colorbased.DataSource = colorbasedbs
            PhasedoutForm.colorbased.DisplayMember = "stockno"
            PhasedoutForm.colorbased.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub Newstock(ByVal supplier As String,
                 ByVal costhead As String,
                 ByVal ufactor As String,
                 ByVal typecolor As String,
                 ByVal monetary As String,
                 ByVal articleno As String,
                 ByVal unitprice As String,
                 ByVal description As String,
                 ByVal QTY As String,
                 ByVal unit As String,
                 ByVal location As String,
                 ByVal header As String,
                 ByVal colorbased As String, ByVal xrate As String)
        Try
            sqlcon.Open()
            Dim find As String = "select * from stocks_tb where costhead='" & costhead & "' and typecolor='" & typecolor & "' and articleno='" & articleno & "'"
            sqlcmd = New SqlCommand(find, sqlcon)
            Dim read As SqlDataReader = sqlcmd.ExecuteReader
            If read.HasRows = True Then
                read.Close()
                MessageBox.Show("Stocks already exist!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                read.Close()
                Dim str As String = "insert into stocks_tb (supplier,
costhead,
ufactor,
typecolor,
monetary,
articleno,
unitprice,
description,
QTY,
unit,
location,
header,
physical,
allocation,
free,
stockorder,
minimum,
ISSUE,
colorbased,
xrate,
INPUTTED)values('" & supplier & "'," &
                          "'" & costhead & "'," &
                          "'" & ufactor & "'," &
                          "'" & typecolor & "'," &
                          "'" & monetary & "'," &
                          "'" & articleno & "'," &
                          "'" & unitprice & "'," &
                          "'" & description & "'," &
                          "'" & QTY & "'," &
                          "'" & unit & "'," &
                          "'" & location & "'," &
                          "'" & header & "'," &
                          "'" & QTY & "'," &
                          "'0'," &
                         "'" & QTY & "'," &
                          "'0'," &
                             "'0'," &
                                "'0'," &
                          "'" & colorbased & "'," &
                            "'" & xrate & "'," &
             "'" & Form1.Label1.Text & "')"
                sqlcmd = New SqlCommand(str, sqlcon)
                sqlcmd.ExecuteNonQuery()
                MessageBox.Show("New stocks Added!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub updatestocks(ByVal stockno As String,
               ByVal ufactor As String,
               ByVal monetary As String,
               ByVal unitprice As String,
               ByVal description As String,
               ByVal unit As String,
               ByVal location As String,
               ByVal min As String,
                            ByVal colorbased As String, ByVal xrate As String)
        Try
            sqlcon.Open()
            Dim str As String = "update stocks_tb set 
ufactor='" & ufactor & "',
monetary='" & monetary & "',
unitprice='" & unitprice & "',
description='" & description & "',
unit='" & unit & "',
location='" & location & "',
minimum='" & min & "',
colorbased='" & colorbased & "',
xrate = '" & xrate & "'
where stockno='" & stockno & "'"
            sqlcmd = New SqlCommand(str, sqlcon)
            sqlcmd.ExecuteNonQuery()
            MessageBox.Show("Stocks Updated!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub updatestocks2(ByVal stockno As String,
               ByVal supplier As String,
               ByVal costhead As String,
               ByVal header As String,
                             ByVal colorbased As String,
               ByVal articleno As String,
               ByVal typecolor As String,
               ByVal description As String,
               ByVal min As String,
                             ByVal monetary As String,
                             ByVal unitprice As String,
                             ByVal aveusage As String,
                             ByVal location As String,
                             ByVal unit As String)
        Try
            sqlcon.Open()
            Dim find As String = "Select * from stocks_tb where costhead='" & costhead & "' and typecolor='" & typecolor & "' and articleno = '" & articleno & "' and not stockno = '" & stockno & "'"
            sqlcmd = New SqlCommand(find, sqlcon)
            Dim read As SqlDataReader = sqlcmd.ExecuteReader
            If read.HasRows = True Then
                read.Close()
                MessageBox.Show("Stocks already exist!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                read.Close()
                Dim str As String = "update stocks_tb set 
supplier='" & supplier & "',
costhead='" & costhead & "',
header='" & header & "',
colorbased='" & colorbased & "',
articleno='" & articleno & "',
typecolor='" & typecolor & "',
description='" & description & "',
minimum='" & min & "',
monetary='" & monetary & "',
unitprice = '" & unitprice & "',
aveusage='" & aveusage & "',
location='" & location & "',
UNIT='" & unit & "' where stockno='" & stockno & "'"
                sqlcmd = New SqlCommand(str, sqlcon)
                sqlcmd.ExecuteNonQuery()
                MessageBox.Show("Stocks Updated!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Form4.supplier.Enabled = False
                Form4.costhead.Enabled = False
                Form4.header.Enabled = False
                Form4.colorbased.Enabled = False
                Form4.articleno.Enabled = False
                Form4.typecolor.Enabled = False
                Form4.description.Enabled = False
                Form4.min.Enabled = False
                Form4.monetary.Enabled = False
                Form4.unitprice.Enabled = False
                Form4.aveusage.Enabled = False
                Form4.location.Enabled = False
                Form4.unit.Enabled = False
                Form4.editbtn.Visible = True
                Form4.savebtn.Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub loadtransactions(ByVal top As String)

        Try
            sqlcon.Open()
            Dim ds As New DataSet


            Dim i As Integer
            If Form2.transgridview.SortedColumn Is Nothing Then
                i = 4
            Else
                i = Form2.transgridview.SortedColumn.Index
            End If

            Dim SetSortOrder As ListSortDirection
            Dim GridSortOrder As SortOrder
            GridSortOrder = Form2.transgridview.SortOrder
            If GridSortOrder = Windows.Forms.SortOrder.Ascending Then
                SetSortOrder = ListSortDirection.Ascending
            ElseIf GridSortOrder = Windows.Forms.SortOrder.Descending Then
                SetSortOrder = ListSortDirection.Descending
            ElseIf GridSortOrder = Windows.Forms.SortOrder.None Then
                SetSortOrder = ListSortDirection.Ascending
            Else : GridSortOrder = ListSortDirection.Ascending

            End If



            ds.Clear()
            top = top.Replace(",", "")
            Dim tops As String = "top " & top & " "
            Dim str As String = "select " & tops & " a.TRANSNO,
a.STOCKNO,
b.COSTHEAD,
b.TYPECOLOR,
B.ARTICLENO,
B.DESCRIPTION,
a.TRANSTYPE,
a.TRANSDATE,
case when isdate(a.DUEDATE)=1 then cast(a.duedate as date) end as DUEDATE,
a.QTY,
a.REFERENCE,
a.ACCOUNT,
a.CONTROLNO,
A.XYZ,
A.EXCESS,
a.REMARKS,
A.UFACTOR,
(A.UFACTOR*A.QTY) AS CHECKER,
a.UNITPRICE,
A.DISC,
((a.ufactor * a.qty)*(a.unitprice-((a.disc*0.01)*a.unitprice))) as CURRENCY,
a.XRATE,
A.NETAMOUNT,
A.INPUTTED,
A.ADJUSTMENTQTY
 from trans_tb as a inner join stocks_tb as b
on a.stockno = b.stockno order by a.transdate desc"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "trans_tb")
            Form2.transgridview.DataSource = Nothing
            Form2.transBindingSource.DataSource = ds
            Form2.transBindingSource.DataMember = "trans_tb"
            Form2.transgridview.DataSource = Form2.transBindingSource
            Form2.transgridview.Sort(Form2.transgridview.Columns(i), SetSortOrder)
            Form2.transgridview.Columns("DESCRIPTION").Visible = False

            Form2.transgridview.Columns("xyz").Visible = False
            Form2.transgridview.Columns("TRANSDATE").DefaultCellStyle.Format = "yyyy-MMM-dd"
            Form2.transgridview.Columns("DUEDATE").DefaultCellStyle.Format = "yyyy-MMM-dd"
            Form2.transgridview.Columns("QTY").DefaultCellStyle.Format = "N2"
            Form2.transgridview.Columns("EXCESS").DefaultCellStyle.Format = "N2"
            Form2.transgridview.Columns("UFACTOR").DefaultCellStyle.Format = "N2"
            Form2.transgridview.Columns("UNITPRICE").DefaultCellStyle.Format = "N4"
            Form2.transgridview.Columns("XRATE").DefaultCellStyle.Format = "N2"
            Form2.transgridview.Columns("NETAMOUNT").DefaultCellStyle.Format = "N4"
            Form2.transgridview.Columns("CHECKER").DefaultCellStyle.Format = "N2"
            Form2.transgridview.Columns("CURRENCY").DefaultCellStyle.Format = "N2"
            Form2.transgridview.Columns("DISC").DefaultCellStyle.Format = "N2"
            Form2.transgridview.Columns("QTY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.transgridview.Columns("EXCESS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.transgridview.Columns("UFACTOR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.transgridview.Columns("UNITPRICE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.transgridview.Columns("XRATE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.transgridview.Columns("NETAMOUNT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.transgridview.Columns("CHECKER").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.transgridview.Columns("CURRENCY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.transgridview.Columns("DISC").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            cuttinglist.transno.DataBindings.Clear()
            cuttinglist.remarks.DataBindings.Clear()
            cuttinglist.allocation.DataBindings.Clear()
            cuttinglist.transtype.DataBindings.Clear()
            cuttinglist.transno.DataBindings.Add("text", Form2.transBindingSource, "transno")
            cuttinglist.remarks.DataBindings.Add("text", Form2.transBindingSource, "remarks")
            cuttinglist.allocation.DataBindings.Add("text", Form2.transBindingSource, "qty")
            cuttinglist.transtype.DataBindings.Add("text", Form2.transBindingSource, "TRANSTYPE")

            Dim coutresult As String = "Select FORMAT(count(a.TRANSNO),'N0')
 from trans_tb as a inner join stocks_tb as b
on a.stockno = b.stockno"
            sqlcmd = New SqlCommand(coutresult, sqlcon)
            Dim readerr As SqlDataReader = sqlcmd.ExecuteReader
            While readerr.Read
                Form2.noofresults.Text = readerr(0).ToString() + " results found"
            End While
            readerr.Close()

            Dim referenceds As New DataSet
            referenceds.Clear()
            Dim transbs As New BindingSource
            Dim ref As String = "Select distinct reference from trans_tb"
            sqlcmd = New SqlCommand(ref, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(referenceds, "trans_tb")
            transbs.DataSource = referenceds
            transbs.DataMember = "trans_tb"
            Form2.transreference.DataSource = transbs
            Form2.transreference.DisplayMember = "reference"
            Form2.transreference.SelectedIndex = -1

            Dim costheadds As New DataSet
            Dim costheadbs As New BindingSource
            costheadds.Clear()

            Dim costhead As String = "Select distinct b.costhead from stocks_tb As b inner join trans_tb As a On a.stockno = b.stockno"
            sqlcmd = New SqlCommand(costhead, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(costheadds, "stocks_tb")
            costheadbs.DataSource = costheadds
            costheadbs.DataMember = "stocks_tb"
            Form2.transactioncosthead.DataSource = costheadbs
            Form2.transactioncosthead.DisplayMember = "costhead"
            Form2.transactioncosthead.SelectedIndex = -1

            notifycritical()
            tmanagecols()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    'Public Sub goback()
    '    scrollval = scrollval - 100
    '    If scrollval <= 0 Then
    '        scrollval = 0
    '    End If
    '    transds.Clear()
    '    transda.Fill(transds, scrollval, 100, "trans_tb")
    'End Sub
    'Public Sub gonext()
    '    scrollval = scrollval + 100
    '    Dim int As Integer = transds.Tables("trans_tb").Rows.Count

    '    transds.Clear()
    '    transda.Fill(transds, scrollval, 100, "trans_tb")
    'End Sub
    Public Sub loadreference(ByVal source As String)
        Try
            sqlcon.Open()
            If source = "Trans" Then
                Dim ds As New DataSet
                Dim bs As New BindingSource
                ds.Clear()
                Dim str As String = "Select distinct reference from trans_tb"
                sqlcmd = New SqlCommand(str, sqlcon)
                da.SelectCommand = sqlcmd
                da.Fill(ds, "trans_tb")
                bs.DataSource = ds
                bs.DataMember = "trans_tb"
                Form2.reference.DataSource = bs
                Form2.reference.ValueMember = "reference"
                Form2.reference.DisplayMember = "reference"
                Form2.reference.SelectedIndex = -1
            ElseIf source = "Contracts" Then
                sqlcon.Close()
                wa()
            End If
        Catch ex As SqlException
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub wa()
        Dim sqlcon2 As New SqlConnection With {.ConnectionString = "Data Source='192.168.1.21,49107';Network Library=DBMSSOCN;Initial Catalog='heretosave';User ID='kmdiadmin';Password='kmdiadmin';"}
        Try
            sqlcon2.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            Dim str As String = "Select distinct project_label from addendum_to_contract_tb"
            sqlcmd = New SqlCommand(str, sqlcon2)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "addendum_to_contract_tb")
            bs.DataSource = ds
            bs.DataMember = "addendum_to_contract_tb"
            Form2.reference.DataSource = bs
            Form2.reference.ValueMember = "project_label"
            Form2.reference.DisplayMember = "project_label"
            Form2.reference.SelectedIndex = -1
        Catch ex As SqlException
            MsgBox(ex.Message)
        Finally
            sqlcon2.Close()
        End Try
    End Sub
    Public Sub loadinputsearch()
        'Try
        '    sqlcon.Open()
        '    Dim ds As New DataSet
        '    Dim str As String = "Select * from stocks_tb"
        '    sqlcmd = New SqlCommand(str, sqlcon)
        '    da.SelectCommand = sqlcmd
        '    da.Fill(ds, "stocks_tb")
        '    Form2.loadinputBindingSource.DataSource = ds
        '    Form2.loadinputBindingSource.DataMember = "stocks_tb"
        '    Form2.transcosthead.DataSource = Form2.loadinputBindingSource
        '    Form2.transarticleno.DataSource = Form2.loadinputBindingSource
        '    Form2.transtypecolor.DataSource = Form2.loadinputBindingSource
        '    Form2.transcosthead.DisplayMember = "COSTHEAD"
        '    Form2.transarticleno.DisplayMember = "ARTICLENO"
        '    Form2.transtypecolor.DisplayMember = "TYPECOLOR"
        '    Form2.transdescription.DataBindings.Clear()
        '    Form2.transphysical.DataBindings.Clear()
        '    Form2.transfree.DataBindings.Clear()
        '    Form2.transunit.DataBindings.Clear()
        '    Form2.transstockno.DataBindings.Clear()
        '    Form2.transdescription.DataBindings.Add("TEXT", Form2.loadinputBindingSource, "DESCRIPTION")
        '    Form2.transphysical.DataBindings.Add("TEXT", Form2.loadinputBindingSource, "PHYSICAL")
        '    Form2.transfree.DataBindings.Add("TEXT", Form2.loadinputBindingSource, "FREE")
        '    Form2.transunit.DataBindings.Add("TEXT", Form2.loadinputBindingSource, "UNIT")
        '    Form2.transstockno.DataBindings.Add("TEXT", Form2.loadinputBindingSource, "STOCKNO")
        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'Finally
        '    sqlcon.Close()
        'End Try
    End Sub
    Public Sub costheadinput(ByVal phasedout As String)
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            Dim str As String = "Select distinct costhead from stocks_tb where " & phasedout & ""
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.transcosthead.DataSource = bs
            Form2.transcosthead.DisplayMember = "costhead"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub costheadreceipt()
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            Dim str As String = "Select distinct costhead from stocks_tb order by costhead asc"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.receiptcosthead.DataSource = bs
            Form2.receiptcosthead.DisplayMember = "costhead"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub costheadissue()
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            Dim str As String = "Select distinct costhead from stocks_tb order by costhead asc"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.issuecosthead.DataSource = bs
            Form2.issuecosthead.DisplayMember = "costhead"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub typecolorinput(ByVal costhead As String, ByVal phasedout As String)
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            Dim str As String = "Select distinct typecolor from stocks_tb where costhead = '" & costhead & "' " & phasedout & ""
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.transtypecolor.DataSource = bs
            Form2.transtypecolor.DisplayMember = "typecolor"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub typecolorinput1(ByVal phasedout As String)
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            Dim str As String = "Select distinct typecolor from stocks_tb where " & phasedout & ""
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.transtypecolor.DataSource = bs
            Form2.transtypecolor.DisplayMember = "typecolor"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub typecolorissue(ByVal costhead As String)
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            Dim str As String = "select distinct typecolor from stocks_tb where costhead = '" & costhead & "' order by typecolor asc"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.issuetypecolor.DataSource = bs
            Form2.issuetypecolor.DisplayMember = "typecolor"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub typecolorissue1()
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            Dim str As String = "select distinct typecolor from stocks_tb order by typecolor asc"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.issuetypecolor.DataSource = bs
            Form2.issuetypecolor.DisplayMember = "typecolor"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub typecolorreceipt(ByVal costhead As String)
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            Dim str As String = "select distinct typecolor from stocks_tb where costhead = '" & costhead & "' order by typecolor asc"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.receipttypecolor.DataSource = bs
            Form2.receipttypecolor.DisplayMember = "typecolor"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub typecolorreceipt1()
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            Dim str As String = "select distinct typecolor from stocks_tb order by typecolor asc"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.receipttypecolor.DataSource = bs
            Form2.receipttypecolor.DisplayMember = "typecolor"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub articlenoinput(ByVal costhead As String, ByVal typecolor As String)
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            Dim str As String = "select  articleno,description,physical,free,unit,stockno,unitprice,xrate,ufactor from stocks_tb where costhead = '" & costhead & "' and typecolor='" & typecolor & "'"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.transarticleno.DataSource = bs
            Form2.transarticleno.DisplayMember = "articleno"
            Form2.transdescription.DataBindings.Clear()
            Form2.transphysical.DataBindings.Clear()
            Form2.transfree.DataBindings.Clear()
            Form2.transunit.DataBindings.Clear()
            Form2.transstockno.DataBindings.Clear()
            Form2.unitprice.DataBindings.Clear()
            Form2.xrate.DataBindings.Clear()
            Form2.ufactor.DataBindings.Clear()
            Form2.transdescription.DataBindings.Add("TEXT", bs, "DESCRIPTION")
            Form2.transphysical.DataBindings.Add("TEXT", bs, "PHYSICAL")
            Form2.transfree.DataBindings.Add("TEXT", bs, "FREE")
            Form2.transunit.DataBindings.Add("TEXT", bs, "UNIT")
            Form2.transstockno.DataBindings.Add("TEXT", bs, "STOCKNO")
            Form2.unitprice.DataBindings.Add("TEXT", bs, "unitprice")
            Form2.xrate.DataBindings.Add("TEXT", bs, "xrate")
            Form2.ufactor.DataBindings.Add("TEXT", bs, "ufactor")
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub articlenoinput1(ByVal phasedout As String, ByVal a As String)
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            Dim str As String = "select  articleno,description,physical,free,unit,stockno,unitprice,xrate,ufactor from stocks_tb where " & a & " ='" & phasedout & "'"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.transarticleno.DataSource = bs
            Form2.transarticleno.DisplayMember = "articleno"
            Form2.transdescription.DataBindings.Clear()
            Form2.transphysical.DataBindings.Clear()
            Form2.transfree.DataBindings.Clear()
            Form2.transunit.DataBindings.Clear()
            Form2.transstockno.DataBindings.Clear()
            Form2.unitprice.DataBindings.Clear()
            Form2.xrate.DataBindings.Clear()
            Form2.ufactor.DataBindings.Clear()
            Form2.transdescription.DataBindings.Add("TEXT", bs, "DESCRIPTION")
            Form2.transphysical.DataBindings.Add("TEXT", bs, "PHYSICAL")
            Form2.transfree.DataBindings.Add("TEXT", bs, "FREE")
            Form2.transunit.DataBindings.Add("TEXT", bs, "UNIT")
            Form2.transstockno.DataBindings.Add("TEXT", bs, "STOCKNO")
            Form2.unitprice.DataBindings.Add("TEXT", bs, "unitprice")
            Form2.xrate.DataBindings.Add("TEXT", bs, "xrate")
            Form2.ufactor.DataBindings.Add("TEXT", bs, "ufactor")
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub articlenoinput2(ByVal costhead As String, ByVal phasedout As String, ByVal a As String)
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            Dim str As String = "select  articleno,description,physical,free,unit,stockno,unitprice,xrate,ufactor from stocks_tb where costhead = '" & costhead & "' and  " & a & " ='" & phasedout & "'"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.transarticleno.DataSource = bs
            Form2.transarticleno.DisplayMember = "articleno"
            Form2.transdescription.DataBindings.Clear()
            Form2.transphysical.DataBindings.Clear()
            Form2.transfree.DataBindings.Clear()
            Form2.transunit.DataBindings.Clear()
            Form2.transstockno.DataBindings.Clear()
            Form2.unitprice.DataBindings.Clear()
            Form2.xrate.DataBindings.Clear()
            Form2.ufactor.DataBindings.Clear()
            Form2.transdescription.DataBindings.Add("TEXT", bs, "DESCRIPTION")
            Form2.transphysical.DataBindings.Add("TEXT", bs, "PHYSICAL")
            Form2.transfree.DataBindings.Add("TEXT", bs, "FREE")
            Form2.transunit.DataBindings.Add("TEXT", bs, "UNIT")
            Form2.transstockno.DataBindings.Add("TEXT", bs, "STOCKNO")
            Form2.unitprice.DataBindings.Add("TEXT", bs, "unitprice")
            Form2.xrate.DataBindings.Add("TEXT", bs, "xrate")
            Form2.ufactor.DataBindings.Add("TEXT", bs, "ufactor")
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub articlenoinput3(ByVal typecolor As String, ByVal phasedout As String, ByVal a As String)
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            Dim str As String = "select  articleno,description,physical,free,unit,stockno,unitprice,xrate,ufactor from stocks_tb where typecolor = '" & typecolor & "' and  " & a & " ='" & phasedout & "'"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.transarticleno.DataSource = bs
            Form2.transarticleno.DisplayMember = "articleno"
            Form2.transdescription.DataBindings.Clear()
            Form2.transphysical.DataBindings.Clear()
            Form2.transfree.DataBindings.Clear()
            Form2.transunit.DataBindings.Clear()
            Form2.transstockno.DataBindings.Clear()
            Form2.unitprice.DataBindings.Clear()
            Form2.xrate.DataBindings.Clear()
            Form2.ufactor.DataBindings.Clear()
            Form2.transdescription.DataBindings.Add("TEXT", bs, "DESCRIPTION")
            Form2.transphysical.DataBindings.Add("TEXT", bs, "PHYSICAL")
            Form2.transfree.DataBindings.Add("TEXT", bs, "FREE")
            Form2.transunit.DataBindings.Add("TEXT", bs, "UNIT")
            Form2.transstockno.DataBindings.Add("TEXT", bs, "STOCKNO")
            Form2.unitprice.DataBindings.Add("TEXT", bs, "unitprice")
            Form2.xrate.DataBindings.Add("TEXT", bs, "xrate")
            Form2.ufactor.DataBindings.Add("TEXT", bs, "ufactor")
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub articlenoreceipt(ByVal costhead As String, ByVal typecolor As String)
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            Dim str As String = "select  articleno,description,physical,free,unit,stockno from stocks_tb where costhead = '" & costhead & "' and typecolor='" & typecolor & "' order by articleno asc"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.receiptarticleno.DataSource = bs
            Form2.receiptarticleno.DisplayMember = "articleno"
            Form2.receiptstockno.DataBindings.Clear()
            Form2.receiptstockno.DataBindings.Add("TEXT", bs, "STOCKNO")
            searchreference(Form2.receiptreference.Text, Form2.receiptstockno.Text)
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub articlenoreceipt1()
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            Dim str As String = "select  articleno,description,physical,free,unit,stockno from stocks_tb  order by articleno asc"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.receiptarticleno.DataSource = bs
            Form2.receiptarticleno.DisplayMember = "articleno"
            Form2.receiptstockno.DataBindings.Clear()
            Form2.receiptstockno.DataBindings.Add("TEXT", bs, "STOCKNO")
            searchreference(Form2.receiptreference.Text, Form2.receiptstockno.Text)
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub articlenoreceipt2(ByVal costhead As String)
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            Dim str As String = "select  articleno,description,physical,free,unit,stockno from stocks_tb where costhead = '" & costhead & "'  order by articleno asc"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.receiptarticleno.DataSource = bs
            Form2.receiptarticleno.DisplayMember = "articleno"
            Form2.receiptstockno.DataBindings.Clear()
            Form2.receiptstockno.DataBindings.Add("TEXT", bs, "STOCKNO")
            searchreference(Form2.receiptreference.Text, Form2.receiptstockno.Text)
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub articlenoreceipt3(ByVal articleno As String)
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            Dim str As String = "select  articleno,description,physical,free,unit,stockno from stocks_tb where articleno = '" & articleno & "'  order by articleno asc"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.receiptarticleno.DataSource = bs
            Form2.receiptarticleno.DisplayMember = "articleno"
            Form2.receiptstockno.DataBindings.Clear()
            Form2.receiptstockno.DataBindings.Add("TEXT", bs, "STOCKNO")
            searchreference(Form2.receiptreference.Text, Form2.receiptstockno.Text)
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub articlenoissue(ByVal costhead As String, ByVal typecolor As String)
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            Dim str As String = "select  articleno,description,physical,free,unit,stockno from stocks_tb where costhead = '" & costhead & "' and typecolor='" & typecolor & "' order by articleno asc"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.issuearticleno.DataSource = bs
            Form2.issuearticleno.DisplayMember = "articleno"
            Form2.issuestockno.DataBindings.Clear()
            Form2.issuestockno.DataBindings.Add("TEXT", bs, "STOCKNO")
            searchreferenceissue(Form2.issuereference.Text, Form2.issuestockno.Text)
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub articlenoissue1()
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            Dim str As String = "select  articleno,description,physical,free,unit,stockno from stocks_tb"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.issuearticleno.DataSource = bs
            Form2.issuearticleno.DisplayMember = "articleno"
            Form2.issuestockno.DataBindings.Clear()
            Form2.issuestockno.DataBindings.Add("TEXT", bs, "STOCKNO")
            searchreferenceissue(Form2.issuereference.Text, Form2.issuestockno.Text)
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub articlenoissue2(ByVal costhead As String)
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            Dim str As String = "select  articleno,description,physical,free,unit,stockno from stocks_tb where costhead = '" & costhead & "' order by articleno asc"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.issuearticleno.DataSource = bs
            Form2.issuearticleno.DisplayMember = "articleno"
            Form2.issuestockno.DataBindings.Clear()
            Form2.issuestockno.DataBindings.Add("TEXT", bs, "STOCKNO")
            searchreferenceissue(Form2.issuereference.Text, Form2.issuestockno.Text)
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub articlenoissue3(ByVal typecolor As String)
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            Dim str As String = "select  articleno,description,physical,free,unit,stockno from stocks_tb where typecolor = '" & typecolor & "' order by articleno asc"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.issuearticleno.DataSource = bs
            Form2.issuearticleno.DisplayMember = "articleno"
            Form2.issuestockno.DataBindings.Clear()
            Form2.issuestockno.DataBindings.Add("TEXT", bs, "STOCKNO")
            searchreferenceissue(Form2.issuereference.Text, Form2.issuestockno.Text)
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub referencereceipt()
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            Dim str As String = "select distinct reference from REFERENCE_tb where STOCKORDER > 0 order by reference asc"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "REFERENCE_tb")
            bs.DataSource = ds
            bs.DataMember = "REFERENCE_tb"
            Form2.receiptreference.DataSource = bs
            Form2.receiptreference.DisplayMember = "reference"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub referenceissue()
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            Dim str As String = "select distinct reference from trans_tb where transtype = 'Allocation' order by reference asc"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.issuereference.DataSource = bs
            Form2.issuereference.DisplayMember = "reference"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub newtransaction(ByVal stockno As String,
                          ByVal transtype As String,
                          ByVal transdate As String,
                          ByVal duedate As String,
                          ByVal qty As String,
                          ByVal reference As String,
                          ByVal account As String,
                          ByVal controlno As String,
                              ByVal xyz As String,
                              ByVal XYZREF As String,
                              ByVal remarks As String, ByVal ufactor As String,
                              ByVal unitprice As String, ByVal disc As String,
                              ByVal xrate As String, ByVal netamount As String)
        Try
            sqlcon.Open()
            Dim str As String


            Dim physical As String
            Dim l As String = "declare @sd as varchar(50)=(select physical from stocks_tb where stockno = '" & stockno & "')
select @sd"
            sqlcmd = New SqlCommand(l, sqlcon)
            Dim read1 As SqlDataReader = sqlcmd.ExecuteReader
            While read1.Read
                physical = read1(0).ToString
            End While
            read1.Close()
            Dim p As Double = physical
            Dim q As Double = qty
            Dim newbal As Double
            If transtype = "Issue" Then
                newbal = p - q
            ElseIf transtype = "Order" Then
                newbal = p
            ElseIf transtype = "Receipt" Then
                newbal = p + q
            ElseIf transtype = "Return" Then
                newbal = p + q
            ElseIf transtype = "Supply" Then
                newbal = p
            ElseIf transtype = "Spare" Then
                newbal = p
            ElseIf transtype = "+Adjustment" Then
                newbal = p + q
            ElseIf transtype = "-Adjustment" Then
                newbal = p - q
            End If

            If transtype = "Allocation" Then
                str = "
insert into trans_tb 
            (STOCKNO,
            TRANSTYPE,
            TRANSDATE,
            DUEDATE,
            QTY,
            REFERENCE,
            ACCOUNT,
            CONTROLNO,XYZ,XYZREF,REMARKS,BALQTY,ufactor,unitprice,disc,xrate,netamount,INPUTTED) values ('" & stockno & "'," &
         "'" & transtype & "'," &
         "'" & transdate & "'," &
         "'" & duedate & "'," &
         "'" & qty & "'," &
         "'" & reference & "'," &
         "'" & account & "'," &
         "'" & controlno & "'," &
            "'" & xyz & "'," &
              "'" & XYZREF & "'," &
         "'" & remarks & "'," &
           "'" & qty & "'," &
             "'" & ufactor & "'," &
              "'" & unitprice & "'," &
                  "'" & disc & "'," &
                 "'" & xrate & "'," &
                    "'" & netamount & "'," &
            "'" & Form1.Label1.Text & "')"
            ElseIf transtype = "Order" Or transtype = "Receipt" Then
                str = "
insert into trans_tb 
            (STOCKNO,
            TRANSTYPE,
            TRANSDATE,
            DUEDATE,
            QTY,
            REFERENCE,
            ACCOUNT,
            CONTROLNO,XYZ,XYZREF,REMARKS,BALQTY,ufactor,unitprice,disc,xrate,netamount,INPUTTED) values ('" & stockno & "'," &
         "'" & transtype & "'," &
         "'" & transdate & "'," &
         "'" & duedate & "'," &
         "'" & qty & "'," &
         "'" & reference & "'," &
         "'" & account & "'," &
         "'" & controlno & "'," &
            "'" & xyz & "'," &
              "'" & XYZREF & "'," &
         "'" & remarks & "'," &
           "'" & newbal & "'," &
             "'" & ufactor & "'," &
              "'" & unitprice & "'," &
                   "'" & disc & "'," &
                 "'" & xrate & "'," &
                    "'" & netamount & "'," &
            "'" & Form1.Label1.Text & "')"
            Else
                str = "
insert into trans_tb 
            (STOCKNO,
            TRANSTYPE,
            TRANSDATE,
            DUEDATE,
            QTY,
            REFERENCE,
            ACCOUNT,
            CONTROLNO,XYZ,XYZREF,REMARKS,BALQTY,ufactor,unitprice,disc,xrate,netamount,INPUTTED) values ('" & stockno & "'," &
         "'" & transtype & "'," &
         "'" & transdate & "'," &
         "'" & duedate & "'," &
         "'" & qty & "'," &
         "'" & reference & "'," &
         "'" & account & "'," &
         "'" & controlno & "'," &
            "'" & xyz & "'," &
              "'" & XYZREF & "'," &
         "'" & remarks & "'," &
           "'" & newbal & "'," &
             "'" & ufactor & "'," &
              "'" & unitprice & "'," &
                    "'" & disc & "'," &
                 "'" & xrate & "'," &
                    "'" & netamount & "'," &
            "'" & Form1.Label1.Text & "')"
            End If

            sqlcmd = New SqlCommand(str, sqlcon)
            sqlcmd.ExecuteNonQuery()

            Dim find As String = "select * from reference_tb where reference='" & reference & "' and stockno='" & stockno & "'"
            sqlcmd = New SqlCommand(find, sqlcon)
            Dim read As SqlDataReader = sqlcmd.ExecuteReader
            If read.HasRows = True Then
                read.Close()
            Else
                read.Close()

                Dim address As String
                Try
                    sqlcon1.Open()
                    Dim getadd As String = "select fulladd from addendum_to_contract_tb where project_label = '" & reference & "'"
                    sqlcmd = New SqlCommand(getadd, sqlcon1)
                    Dim sd As SqlDataReader = sqlcmd.ExecuteReader
                    While sd.Read
                        address = sd(0).ToString
                    End While
                    sd.Close()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                Finally
                    sqlcon1.Close()
                End Try

                Dim insert As String = "insert into reference_tb (reference,address,stockno) values('" & reference & "','" & address & "','" & stockno & "')"
                sqlcmd = New SqlCommand(insert, sqlcon)
                sqlcmd.ExecuteNonQuery()

            End If

            msgbox1.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub searchreference(ByVal reference As String, ByVal stockno As String)
        Try
            sqlcon.Close()
            sqlcon.Open()
            Dim ds As New DataSet
            ds.Clear()
            Dim bs As New BindingSource
            Dim str As String = "
select 
a.TRANSNO,
a.STOCKNO,
b.COSTHEAD,
b.TYPECOLOR,
b.ARTICLENO,
a.TRANSTYPE,
a.TRANSDATE,
a.DUEDATE,
a.QTY,
a.REFERENCE,
a.ACCOUNT,
a.CONTROLNO,
a.XYZ,
b.description
from trans_tb as a
inner join stocks_tb as b
on a.stockno = b.stockno 
where a.reference='" & reference & "' and a.transtype = 'Order' AND a.XYZREF=''"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "trans_tb")
            bs.DataSource = ds
            bs.DataMember = "trans_tb"
            Form2.receiptGridView.DataSource = bs
            Form2.receiptGridView.Columns("XYZ").Visible = False
            Form2.receiptGridView.Columns("description").Visible = False

            Dim xds As New DataSet
            Dim xbs As New BindingSource
            xds.Clear()
            Dim xstr As String = "select STOCKNO,TYPECOLOR,ARTICLENO,QTY,PHYSICAL,ALLOCATION,FREE,STOCKORDER,MINIMUM from stocks_tb where stockno='" & stockno & "'"
            sqlcmd = New SqlCommand(xstr, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(xds, "stocks_tb")
            xbs.DataSource = xds
            xbs.DataMember = "stocks_tb"
            Form2.receiptDataGridView1.DataSource = xbs
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub selectsubreference(ByVal stockno As String)
        Try
            sqlcon.Close()
            sqlcon.Open()
            Dim xds As New DataSet
            Dim xbs As New BindingSource
            xds.Clear()
            Dim xstr As String = "select STOCKNO,TYPECOLOR,ARTICLENO,QTY,PHYSICAL,ALLOCATION,FREE,STOCKORDER,MINIMUM from stocks_tb where stockno='" & stockno & "'"
            sqlcmd = New SqlCommand(xstr, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(xds, "stocks_tb")
            xbs.DataSource = xds
            xbs.DataMember = "stocks_tb"
            Form2.receiptDataGridView1.DataSource = xbs
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub selectsubreferenceissue(ByVal stockno As String)
        Try
            sqlcon.Close()
            sqlcon.Open()
            Dim xds As New DataSet
            Dim xbs As New BindingSource
            xds.Clear()
            Dim xstr As String = "select STOCKNO,TYPECOLOR,ARTICLENO,QTY,PHYSICAL,ALLOCATION,FREE,STOCKORDER,MINIMUM from stocks_tb where stockno='" & stockno & "'"
            sqlcmd = New SqlCommand(xstr, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(xds, "stocks_tb")
            xbs.DataSource = xds
            xbs.DataMember = "stocks_tb"
            Form2.issueDataGridView1.DataSource = xbs
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub searchreferenceissue(ByVal reference As String, ByVal stockno As String)
        Try
            sqlcon.Close()
            sqlcon.Open()
            Dim ds As New DataSet
            ds.Clear()
            Dim bs As New BindingSource
            Dim str As String = " select a.REFERENCE,
a.STOCKNO,
b.COSTHEAD,
b.TYPECOLOR,
b.ARTICLENO,
a.ALLOCATION,
a.TOTALISSUE,
b.description
from
reference_tb as a
inner join stocks_tb as b
on b.stockno=a.stockno
 where a.reference='" & reference & "' and a.stockno = '" & stockno & "'"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "reference_tb")
            bs.DataSource = ds
            bs.DataMember = "reference_tb"
            Form2.issueDataGridView.DataSource = Nothing
            Form2.issueDataGridView.DataSource = bs
            Form2.issueDataGridView.Columns("description").Visible = False

            Dim xds As New DataSet
            Dim xbs As New BindingSource
            xds.Clear()
            Dim xstr As String = "select STOCKNO,TYPECOLOR,ARTICLENO,QTY,PHYSICAL,ALLOCATION,FREE,STOCKORDER,MINIMUM from stocks_tb where stockno='" & stockno & "'"
            sqlcmd = New SqlCommand(xstr, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(xds, "stocks_tb")
            xbs.DataSource = xds
            xbs.DataMember = "stocks_tb"
            Form2.issueDataGridView1.DataSource = Nothing
            Form2.issueDataGridView1.DataSource = xbs
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub selectreceiptreferencerecord(ByVal reference As String)
        Try
            sqlcon.Close()
            sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            Dim Str As String = "select a.TRANSNO,
a.STOCKNO,
b.COSTHEAD,
b.TYPECOLOR,
b.ARTICLENO,
a.TRANSTYPE,
a.TRANSDATE,
a.DUEDATE,
a.QTY,
a.REFERENCE,
a.ACCOUNT,
a.CONTROLNO,
a.XYZ,
b.description,
a.UFACTOR,
(a.ufactor*a.qty) as CHECKER,
a.UNITPRICE,
((a.ufactor*a.qty)*A.UNITPRICE) AS CURRENCY,
A.XRATE,
A.NETAMOUNT
 from trans_tb as a
inner join stocks_tb as b on a.stockno = b.stockno
where a.reference='" & reference & "' and a.qty>0 and a.transtype = 'Order' and a.xyzref=''
order by b.articleno asc"
            sqlcmd = New SqlCommand(Str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "trans_tb")
            bs.DataSource = ds
            bs.DataMember = "trans_tb"
            Form2.receiptGridView.DataSource = Nothing
            Form2.receiptGridView.DataSource = bs
            Form2.receiptGridView.Columns("xyz").Visible = False
            Form2.receiptGridView.Columns("description").Visible = False

            Form2.receiptGridView.Columns("UFACTOR").DefaultCellStyle.Format = "N2"
            Form2.receiptGridView.Columns("UNITPRICE").DefaultCellStyle.Format = "N4"
            Form2.receiptGridView.Columns("XRATE").DefaultCellStyle.Format = "N2"
            Form2.receiptGridView.Columns("NETAMOUNT").DefaultCellStyle.Format = "N2"
            Form2.receiptGridView.Columns("CHECKER").DefaultCellStyle.Format = "N2"
            Form2.receiptGridView.Columns("CURRENCY").DefaultCellStyle.Format = "N2"
            Form2.receiptGridView.Columns("QTY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.receiptGridView.Columns("UFACTOR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.receiptGridView.Columns("UNITPRICE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.receiptGridView.Columns("XRATE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.receiptGridView.Columns("NETAMOUNT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.receiptGridView.Columns("CHECKER").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.receiptGridView.Columns("CURRENCY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub selectreceiptreferencerecord1(ByVal reference As String, ByVal stocksno As String)
        Try
            sqlcon.Close()
            sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            Dim Str As String = "select a.TRANSNO,
a.STOCKNO,
b.COSTHEAD,
b.TYPECOLOR,
b.ARTICLENO,
a.TRANSTYPE,
a.TRANSDATE,
a.DUEDATE,
a.QTY,
a.REFERENCE,
a.ACCOUNT,
a.CONTROLNO,
a.XYZ,
b.description,
a.UFACTOR,
(a.ufactor*a.qty) as CHECKER,
a.UNITPRICE,
((a.ufactor*a.qty)*A.UNITPRICE) as CURRENCY,
A.XRATE,
A.NETAMOUNT
 from trans_tb as a
inner join stocks_tb as b on a.stockno = b.stockno
where a.reference='" & reference & "' and a.stockno = '" & stocksno & "' and a.transtype = 'Order' and a.xyzref=''
order by b.articleno asc"
            sqlcmd = New SqlCommand(Str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "trans_tb")
            bs.DataSource = ds
            bs.DataMember = "trans_tb"
            Form2.receiptGridView.DataSource = Nothing
            Form2.receiptGridView.DataSource = bs
            Form2.receiptGridView.Columns("xyz").Visible = False
            Form2.receiptGridView.Columns("description").Visible = False

            Form2.receiptGridView.Columns("UFACTOR").DefaultCellStyle.Format = "N2"
            Form2.receiptGridView.Columns("UNITPRICE").DefaultCellStyle.Format = "N2"
            Form2.receiptGridView.Columns("XRATE").DefaultCellStyle.Format = "N2"
            Form2.receiptGridView.Columns("NETAMOUNT").DefaultCellStyle.Format = "N2"
            Form2.receiptGridView.Columns("CHECKER").DefaultCellStyle.Format = "N2"
            Form2.receiptGridView.Columns("CURRENCY").DefaultCellStyle.Format = "N2"
            Form2.receiptGridView.Columns("QTY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.receiptGridView.Columns("UFACTOR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.receiptGridView.Columns("UNITPRICE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.receiptGridView.Columns("XRATE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.receiptGridView.Columns("NETAMOUNT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.receiptGridView.Columns("CHECKER").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.receiptGridView.Columns("CURRENCY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub

    Public Sub selectissuereferencerecord(ByVal reference As String)
        Try
            sqlcon.Close()
            sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            Dim Str As String = "select a.REFERENCE,
a.STOCKNO,
b.COSTHEAD,
b.TYPECOLOR,
b.ARTICLENO,
a.ALLOCATION,
a.TOTALISSUE,
b.description
from
reference_tb as a
inner join stocks_tb as b
on b.stockno=a.stockno
 where a.reference='" & reference & "' and a.ALLOCATION>0"
            sqlcmd = New SqlCommand(Str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "reference_tb")
            bs.DataSource = ds
            bs.DataMember = "reference_tb"
            Form2.issueDataGridView.DataSource = Nothing
            Form2.issueDataGridView.DataSource = bs
            Form2.issueDataGridView.Columns("description").Visible = False


        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub selectissuereferencerecord1(ByVal reference As String, ByVal stockno As String)
        Try
            sqlcon.Close()
            sqlcon.Open()
            Dim ds As New DataSet
            Dim bs As New BindingSource
            ds.Clear()
            Dim Str As String = "select a.REFERENCE,
a.STOCKNO,
b.COSTHEAD,
b.TYPECOLOR,
b.ARTICLENO,
a.ALLOCATION,
a.TOTALISSUE,
b.description
from
reference_tb as a
inner join stocks_tb as b
on b.stockno=a.stockno
 where a.reference='" & reference & "' and a.stockno = '" & stockno & "'"
            sqlcmd = New SqlCommand(Str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "reference_tb")
            bs.DataSource = ds
            bs.DataMember = "reference_tb"
            Form2.issueDataGridView.DataSource = Nothing
            Form2.issueDataGridView.DataSource = bs
            Form2.issueDataGridView.Columns("description").Visible = False


        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub srockstransactiontb2(ByVal stockno As String)
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter
            ds.Clear()
            Dim bs As New BindingSource
            Dim str As String = "select TRANSNO,
STOCKNO,
TRANSTYPE,
TRANSDATE,
CASE WHEN ISDATE(DUEDATE)=1 THEN CAST(DUEDATE AS DATE) END AS DUEDATE,
QTY,
BALQTY,
REFERENCE,
ACCOUNT,
CONTROLNO,
XYZ,
XYZREF,
EXCESS,
REMARKS,
UFACTOR,
(ufactor * qty) as CHECKER,
UNITPRICE,
((ufactor * qty)*unitprice) as CURRENCY,
XRATE,
NETAMOUNT,
INPUTTED from trans_tb where 
stockno='" & stockno & "' and
not (transtype = 'Allocation' or transtype = 'CancelAlloc' or transtype='Order' or transtype = 'Spare') order by transdate desc"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "trans_tb")
            bs.DataSource = ds
            bs.DataMember = "trans_tb"
            Form4.mytransgridview.DataSource = bs
            Form4.mytransgridview.Columns("TRANSDATE").DefaultCellStyle.Format = "yyyy-MMM-dd"
            Form4.mytransgridview.Columns("DUEDATE").DefaultCellStyle.Format = "yyyy-MMM-dd"
            Form4.mytransgridview.Columns("stockno").Visible = False

            Form4.mytransgridview.Columns("UFACTOR").DefaultCellStyle.Format = "N2"
            Form4.mytransgridview.Columns("UNITPRICE").DefaultCellStyle.Format = "N2"
            Form4.mytransgridview.Columns("XRATE").DefaultCellStyle.Format = "N2"
            Form4.mytransgridview.Columns("NETAMOUNT").DefaultCellStyle.Format = "N2"
            Form4.mytransgridview.Columns("CHECKER").DefaultCellStyle.Format = "N2"
            Form4.mytransgridview.Columns("CURRENCY").DefaultCellStyle.Format = "N2"
            Form4.mytransgridview.Columns("EXCESS").DefaultCellStyle.Format = "N2"
            Form4.mytransgridview.Columns("QTY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form4.mytransgridview.Columns("UFACTOR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form4.mytransgridview.Columns("UNITPRICE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form4.mytransgridview.Columns("XRATE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form4.mytransgridview.Columns("NETAMOUNT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form4.mytransgridview.Columns("CHECKER").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form4.mytransgridview.Columns("CURRENCY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form4.mytransgridview.Columns("EXCESS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            For i As Integer = 0 To Form4.mytransgridview.RowCount - 1 Step +1
                Dim s As String = Form4.mytransgridview.Rows(i).Cells("balqty").Value.ToString
                Dim t As String = Form4.mytransgridview.Rows(i).Cells("transtype").Value.ToString
                If Not s = "0.00" And Not s = "" And t = "Allocation" Then
                    Form4.mytransgridview.Rows(i).Cells("balqty").Style.ForeColor = Color.Red
                End If
            Next
            For i As Integer = 0 To Form4.mytransgridview.RowCount - 1 Step +1
                Dim s As String = Form4.mytransgridview.Rows(i).Cells("xyzref").Value.ToString
                Dim t As String = Form4.mytransgridview.Rows(i).Cells("transtype").Value.ToString
                If Not s = "" And t = "Order" Then
                    Form4.mytransgridview.Rows(i).DefaultCellStyle.BackColor = Color.Pink
                End If
            Next

            Dim all As String
            Dim ada As New SqlDataAdapter
            Dim ads As New DataSet
            ads.Clear()
            Dim abs As New BindingSource
            all = "
                     select Reference,stockorder as StockOrder,allocation as Allocation
                     ,totalreceipt as TotalReceipt,totalissue as TotalIssue,totalreturn as TotalReturn from reference_tb where stockno='" & stockno & "'"
            sqlcmd = New SqlCommand(all, sqlcon)
            ada.SelectCommand = sqlcmd
            ada.Fill(ads, "reference_tb")
            abs.DataSource = ads
            abs.DataMember = "reference_tb"
            Form4.KryptonDataGridView1.DataSource = abs
            Form4.KryptonDataGridView1.Columns("StockOrder").DefaultCellStyle.Format = "N0"
            Form4.KryptonDataGridView1.Columns("Allocation").DefaultCellStyle.Format = "N0"
            Form4.KryptonDataGridView1.Columns("TotalReceipt").DefaultCellStyle.Format = "N0"
            Form4.KryptonDataGridView1.Columns("TotalIssue").DefaultCellStyle.Format = "N0"
            Form4.KryptonDataGridView1.Columns("TotalReturn").DefaultCellStyle.Format = "N0"

            Dim str1 As String = "select distinct reference from trans_tb where stockno='" & stockno & "'"
            Dim ds1 As New DataSet
            Dim da1 As New SqlDataAdapter
            Dim bs1 As New BindingSource
            sqlcmd = New SqlCommand(str1, sqlcon)
            da1.SelectCommand = sqlcmd
            da1.Fill(ds1, "trans_tb")
            bs1.DataSource = ds1
            bs1.DataMember = "trans_tb"
            Form4.referencegridview.DataSource = bs1

            Dim str2 As String = "
                                    declare @allocation as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "' AND TRANSTYPE='Allocation')+0
declare @balqty as decimal(10,2)=(select  COALESCE(sum(balqty),0) from trans_tb where stockno='" & stockno & "' AND TRANSTYPE='Allocation')+0
                                    declare @cancelalloc as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "' AND TRANSTYPE='CancelAlloc')+0
                                    declare @order as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "' AND TRANSTYPE='Order')+0
                                    declare @return as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "' AND TRANSTYPE='Return')+0
                                    declare @supply as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "' AND TRANSTYPE='Supply')+0
                                    declare @spare as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "' AND TRANSTYPE='Spare')+0
                                    declare @addadjustment as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "' AND TRANSTYPE='+Adjustment')+0
                                    declare @minadjustment as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "' AND TRANSTYPE='-Adjustment')+0
                                    declare @receipt as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "' AND TRANSTYPE='Receipt' AND NOT XYZ='Order')+0
                                    declare @issue as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "' AND TRANSTYPE='Issue' AND NOT XYZ ='Allocation')+0
                                    declare @receiptorder as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "' AND TRANSTYPE='Receipt' AND XYZ='Order')+0
                                    declare @issueallocation as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "' AND TRANSTYPE='Issue' AND XYZ ='Allocation')+0
                                    declare @totalreceipt as decimal(10,2)=@receipt+@receiptorder
                                    declare @totalissue as decimal(10,2)=@issue+@issueallocation

declare @QTY as decimal(10,2)=(select qty from stocks_tb where stockno='" & stockno & "')

                                    declare @finalphysical as decimal(10,2)=(@QTY+@totalreceipt+@return+@addadjustment)-(@totalissue+@minadjustment)
                                    declare @finalallocation as decimal(10,2)=@allocation-(@issueallocation+@cancelalloc)
                                    declare @finalfree as decimal(10,2)=(((@QTY+@totalreceipt+@return+@addadjustment)-(@allocation-@cancelalloc)))-(@issue+@minadjustment)
                                    declare @finalorder as decimal(10,2)=@order-@receiptorder
                                    declare @finalissue as decimal(10,2)=@totalissue
                                    declare @finalreceipt as decimal(10,2)=@totalreceipt

select format(@finalphysical,'N0'),FORMAT(@finalallocation,'N0'),
FORMAT(@finalfree,'N0'),FORMAT(@finalorder,'N0'),FORMAT(@finalissue,'N0'),
FORMAT(@finalreceipt,'N0'),FORMAT(@return,'N0'),format(@balqty,'N0')"
            sqlcmd = New SqlCommand(str2, sqlcon)
            Dim read As SqlDataReader = sqlcmd.ExecuteReader

            While read.Read
                Form4.finalphysical.Text = read(0).ToString
                Form4.finalallocation.Text = read(1).ToString
                Form4.finalfree.Text = read(2).ToString
                Form4.finalorder.Text = read(3).ToString
                Form4.finalissue.Text = read(4).ToString
                Form4.finalreceipt.Text = read(5).ToString
                Form4.finalreturn.Text = read(6).ToString
                Form4.balalloc.Text = read(7).ToString
            End While
            read.Close()


            '            Form4.referencegridview.SelectAll()
            '            Dim refere As String
            '            Dim ads As New DataSet
            '            ads.Clear
            '            Dim ada As New SqlDataAdapter
            '            Dim abs As New BindingSource
            '            Form4.KryptonDataGridView1.DataSource = Nothing
            '            For i As Integer = 0 To Form4.ComboBox1.Items.Count - 1
            '                refere = Form4.ComboBox1.Items(i).ToString
            '                Dim all As String

            '                all = "  
            'declare @refe as varchar(max) = '" & refere & "'

            '                                    declare @allocation as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "' and reference =  '" & refere & "' AND TRANSTYPE='Allocation')+0
            '                                    declare @cancelalloc as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "'  and reference =  '" & refere & "' AND TRANSTYPE='CancelAlloc')+0
            '                                    declare @order as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "'  and reference =  '" & refere & "' AND TRANSTYPE='Order')+0
            '                                    declare @return as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "'  and reference =  '" & refere & "' AND TRANSTYPE='Return')+0
            '                                    declare @supply as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "'  and reference =  '" & refere & "' and TRANSTYPE='Supply')+0
            '                                    declare @spare as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "'  and reference =  '" & refere & "' AND TRANSTYPE='Spare')+0
            '                                    declare @addadjustment as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "'  and reference =  '" & refere & "' AND TRANSTYPE='+Adjustment')+0
            '                                    declare @minadjustment as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "'  and reference =  '" & refere & "' AND TRANSTYPE='-Adjustment')+0
            '                                    declare @receipt as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "'  and reference =  '" & refere & "' AND TRANSTYPE='Receipt' AND NOT XYZ='Order')+0
            '                                    declare @issue as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "'  and reference =  '" & refere & "' AND TRANSTYPE='Issue' AND NOT XYZ ='Allocation')+0
            '                                    declare @receiptorder as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "'  and reference =  '" & refere & "' AND TRANSTYPE='Receipt' AND XYZ='Order')+0
            '                                    declare @issueallocation as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "'  and reference =  '" & refere & "' AND TRANSTYPE='Issue' AND XYZ ='Allocation')+0
            '                                    declare @totalreceipt as decimal(10,2)=@receipt+@receiptorder
            '                                    declare @totalissue as decimal(10,2)=@issue+@issueallocation

            'declare @QTY as decimal(10,2)=(select qty from stocks_tb where stockno='" & stockno & "')

            '                                    declare @finalphysical as decimal(10,2)=(@QTY+@totalreceipt+@return+@addadjustment)-(@totalissue+@minadjustment)
            '                                    declare @finalallocation as decimal(10,2)=@allocation-(@issueallocation+@cancelalloc)
            '                                    declare @finalfree as decimal(10,2)=(((@QTY+@totalreceipt+@return+@addadjustment)-(@allocation-@cancelalloc)))-(@issue+@minadjustment)
            '                                    declare @finalorder as decimal(10,2)=@order-@receiptorder
            '                                    declare @finalissue as decimal(10,2)=@totalissue
            '                                    declare @finalreceipt as decimal(10,2)=@totalreceipt

            '                     select @refe as Reference,FORMAT(@finalorder,'N0') as StockOrder,FORMAT(@finalallocation,'N0') as Allocation
            '                     ,format(@finalreceipt,'N0') as TotalReceipt,FORMAT(@finalissue,'N0') as TotalIssue,FORMAT(@return,'N0') as TotalReturn"
            '                sqlcmd = New SqlCommand(all, sqlcon)
            '                    ada.SelectCommand = sqlcmd
            '                ada.Fill(ads, "dummy1")
            '            Next
            '            ada.SelectCommand = sqlcmd
            '            ada.Fill(ads, "dummy1")
            '            abs.DataSource = ads
            '            abs.DataMember = "dummy1"
            '            Form4.KryptonDataGridView1.DataSource = abs
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub srockstransactiontb(ByVal stockno As String)
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter
            ds.Clear()
            Dim bs As New BindingSource
            Dim str As String = "select TRANSNO,
STOCKNO,
TRANSTYPE,
TRANSDATE,
CASE WHEN ISDATE(DUEDATE)=1 THEN CAST(DUEDATE AS DATE) END AS DUEDATE,
QTY,
BALQTY,
REFERENCE,
ACCOUNT,
CONTROLNO,
XYZ,
XYZREF,
EXCESS,
REMARKS,
UFACTOR,
(ufactor * qty) as CHECKER,
UNITPRICE,
((ufactor * qty)*unitprice) as CURRENCY,
XRATE,
NETAMOUNT,
INPUTTED from trans_tb where stockno='" & stockno & "' order by transdate desc"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "trans_tb")
            bs.DataSource = ds
            bs.DataMember = "trans_tb"
            Form4.mytransgridview.DataSource = bs
            Form4.mytransgridview.Columns("TRANSDATE").DefaultCellStyle.Format = "yyyy-MMM-dd"
            Form4.mytransgridview.Columns("DUEDATE").DefaultCellStyle.Format = "yyyy-MMM-dd"
            Form4.mytransgridview.Columns("stockno").Visible = False

            Form4.mytransgridview.Columns("UFACTOR").DefaultCellStyle.Format = "N2"
            Form4.mytransgridview.Columns("UNITPRICE").DefaultCellStyle.Format = "N2"
            Form4.mytransgridview.Columns("XRATE").DefaultCellStyle.Format = "N2"
            Form4.mytransgridview.Columns("NETAMOUNT").DefaultCellStyle.Format = "N2"
            Form4.mytransgridview.Columns("CHECKER").DefaultCellStyle.Format = "N2"
            Form4.mytransgridview.Columns("CURRENCY").DefaultCellStyle.Format = "N2"
            Form4.mytransgridview.Columns("EXCESS").DefaultCellStyle.Format = "N2"
            Form4.mytransgridview.Columns("QTY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form4.mytransgridview.Columns("UFACTOR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form4.mytransgridview.Columns("UNITPRICE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form4.mytransgridview.Columns("XRATE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form4.mytransgridview.Columns("NETAMOUNT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form4.mytransgridview.Columns("CHECKER").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form4.mytransgridview.Columns("CURRENCY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form4.mytransgridview.Columns("EXCESS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            For i As Integer = 0 To Form4.mytransgridview.RowCount - 1 Step +1
                Dim s As String = Form4.mytransgridview.Rows(i).Cells("balqty").Value.ToString
                Dim t As String = Form4.mytransgridview.Rows(i).Cells("transtype").Value.ToString
                If Not s = "0.00" And Not s = "" And t = "Allocation" Then
                    Form4.mytransgridview.Rows(i).Cells("balqty").Style.ForeColor = Color.Red
                End If
            Next
            For i As Integer = 0 To Form4.mytransgridview.RowCount - 1 Step +1
                Dim s As String = Form4.mytransgridview.Rows(i).Cells("xyzref").Value.ToString
                Dim t As String = Form4.mytransgridview.Rows(i).Cells("transtype").Value.ToString
                If Not s = "" And t = "Order" Then
                    Form4.mytransgridview.Rows(i).DefaultCellStyle.BackColor = Color.Pink
                End If
            Next

            Dim all As String
            Dim ada As New SqlDataAdapter
            Dim ads As New DataSet
            ads.Clear()
            Dim abs As New BindingSource
            all = "
                     select Reference,stockorder as StockOrder,allocation as Allocation
                     ,totalreceipt as TotalReceipt,totalissue as TotalIssue,totalreturn as TotalReturn from reference_tb where stockno='" & stockno & "'"
            sqlcmd = New SqlCommand(all, sqlcon)
            ada.SelectCommand = sqlcmd
            ada.Fill(ads, "reference_tb")
            abs.DataSource = ads
            abs.DataMember = "reference_tb"
            Form4.KryptonDataGridView1.DataSource = abs
            Form4.KryptonDataGridView1.Columns("StockOrder").DefaultCellStyle.Format = "N0"
            Form4.KryptonDataGridView1.Columns("Allocation").DefaultCellStyle.Format = "N0"
            Form4.KryptonDataGridView1.Columns("TotalReceipt").DefaultCellStyle.Format = "N0"
            Form4.KryptonDataGridView1.Columns("TotalIssue").DefaultCellStyle.Format = "N0"
            Form4.KryptonDataGridView1.Columns("TotalReturn").DefaultCellStyle.Format = "N0"

            Dim str1 As String = "select distinct reference from trans_tb where stockno='" & stockno & "'"
            Dim ds1 As New DataSet
            Dim da1 As New SqlDataAdapter
            Dim bs1 As New BindingSource
            sqlcmd = New SqlCommand(str1, sqlcon)
            da1.SelectCommand = sqlcmd
            da1.Fill(ds1, "trans_tb")
            bs1.DataSource = ds1
            bs1.DataMember = "trans_tb"
            Form4.referencegridview.DataSource = bs1

            Dim str2 As String = "
                                    declare @allocation as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "' AND TRANSTYPE='Allocation')+0
declare @balqty as decimal(10,2)=(select  COALESCE(sum(balqty),0) from trans_tb where stockno='" & stockno & "' AND TRANSTYPE='Allocation')+0
                                    declare @cancelalloc as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "' AND TRANSTYPE='CancelAlloc')+0
                                    declare @order as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "' AND TRANSTYPE='Order')+0
                                    declare @return as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "' AND TRANSTYPE='Return')+0
                                    declare @supply as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "' AND TRANSTYPE='Supply')+0
                                    declare @spare as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "' AND TRANSTYPE='Spare')+0
                                    declare @addadjustment as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "' AND TRANSTYPE='+Adjustment')+0
                                    declare @minadjustment as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "' AND TRANSTYPE='-Adjustment')+0
                                    declare @receipt as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "' AND TRANSTYPE='Receipt' AND NOT XYZ='Order')+0
                                    declare @issue as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "' AND TRANSTYPE='Issue' AND NOT XYZ ='Allocation')+0
                                    declare @receiptorder as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "' AND TRANSTYPE='Receipt' AND XYZ='Order')+0
                                    declare @issueallocation as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "' AND TRANSTYPE='Issue' AND XYZ ='Allocation')+0
                                    declare @totalreceipt as decimal(10,2)=@receipt+@receiptorder
                                    declare @totalissue as decimal(10,2)=@issue+@issueallocation

declare @QTY as decimal(10,2)=(select qty from stocks_tb where stockno='" & stockno & "')

                                    declare @finalphysical as decimal(10,2)=(@QTY+@totalreceipt+@return+@addadjustment)-(@totalissue+@minadjustment)
                                    declare @finalallocation as decimal(10,2)=@allocation-(@issueallocation+@cancelalloc)
                                    declare @finalfree as decimal(10,2)=(((@QTY+@totalreceipt+@return+@addadjustment)-(@allocation-@cancelalloc)))-(@issue+@minadjustment)
                                    declare @finalorder as decimal(10,2)=@order-@receiptorder
                                    declare @finalissue as decimal(10,2)=@totalissue
                                    declare @finalreceipt as decimal(10,2)=@totalreceipt

select format(@finalphysical,'N0'),FORMAT(@finalallocation,'N0'),
FORMAT(@finalfree,'N0'),FORMAT(@finalorder,'N0'),FORMAT(@finalissue,'N0'),
FORMAT(@finalreceipt,'N0'),FORMAT(@return,'N0'),format(@balqty,'N0')"
            sqlcmd = New SqlCommand(str2, sqlcon)
            Dim read As SqlDataReader = sqlcmd.ExecuteReader

            While read.Read
                Form4.finalphysical.Text = read(0).ToString
                Form4.finalallocation.Text = read(1).ToString
                Form4.finalfree.Text = read(2).ToString
                Form4.finalorder.Text = read(3).ToString
                Form4.finalissue.Text = read(4).ToString
                Form4.finalreceipt.Text = read(5).ToString
                Form4.finalreturn.Text = read(6).ToString
                Form4.balalloc.Text = read(7).ToString
            End While
            read.Close()


            '            Form4.referencegridview.SelectAll()
            '            Dim refere As String
            '            Dim ads As New DataSet
            '            ads.Clear
            '            Dim ada As New SqlDataAdapter
            '            Dim abs As New BindingSource
            '            Form4.KryptonDataGridView1.DataSource = Nothing
            '            For i As Integer = 0 To Form4.ComboBox1.Items.Count - 1
            '                refere = Form4.ComboBox1.Items(i).ToString
            '                Dim all As String

            '                all = "  
            'declare @refe as varchar(max) = '" & refere & "'

            '                                    declare @allocation as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "' and reference =  '" & refere & "' AND TRANSTYPE='Allocation')+0
            '                                    declare @cancelalloc as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "'  and reference =  '" & refere & "' AND TRANSTYPE='CancelAlloc')+0
            '                                    declare @order as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "'  and reference =  '" & refere & "' AND TRANSTYPE='Order')+0
            '                                    declare @return as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "'  and reference =  '" & refere & "' AND TRANSTYPE='Return')+0
            '                                    declare @supply as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "'  and reference =  '" & refere & "' and TRANSTYPE='Supply')+0
            '                                    declare @spare as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "'  and reference =  '" & refere & "' AND TRANSTYPE='Spare')+0
            '                                    declare @addadjustment as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "'  and reference =  '" & refere & "' AND TRANSTYPE='+Adjustment')+0
            '                                    declare @minadjustment as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "'  and reference =  '" & refere & "' AND TRANSTYPE='-Adjustment')+0
            '                                    declare @receipt as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "'  and reference =  '" & refere & "' AND TRANSTYPE='Receipt' AND NOT XYZ='Order')+0
            '                                    declare @issue as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "'  and reference =  '" & refere & "' AND TRANSTYPE='Issue' AND NOT XYZ ='Allocation')+0
            '                                    declare @receiptorder as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "'  and reference =  '" & refere & "' AND TRANSTYPE='Receipt' AND XYZ='Order')+0
            '                                    declare @issueallocation as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb where stockno='" & stockno & "'  and reference =  '" & refere & "' AND TRANSTYPE='Issue' AND XYZ ='Allocation')+0
            '                                    declare @totalreceipt as decimal(10,2)=@receipt+@receiptorder
            '                                    declare @totalissue as decimal(10,2)=@issue+@issueallocation

            'declare @QTY as decimal(10,2)=(select qty from stocks_tb where stockno='" & stockno & "')

            '                                    declare @finalphysical as decimal(10,2)=(@QTY+@totalreceipt+@return+@addadjustment)-(@totalissue+@minadjustment)
            '                                    declare @finalallocation as decimal(10,2)=@allocation-(@issueallocation+@cancelalloc)
            '                                    declare @finalfree as decimal(10,2)=(((@QTY+@totalreceipt+@return+@addadjustment)-(@allocation-@cancelalloc)))-(@issue+@minadjustment)
            '                                    declare @finalorder as decimal(10,2)=@order-@receiptorder
            '                                    declare @finalissue as decimal(10,2)=@totalissue
            '                                    declare @finalreceipt as decimal(10,2)=@totalreceipt

            '                     select @refe as Reference,FORMAT(@finalorder,'N0') as StockOrder,FORMAT(@finalallocation,'N0') as Allocation
            '                     ,format(@finalreceipt,'N0') as TotalReceipt,FORMAT(@finalissue,'N0') as TotalIssue,FORMAT(@return,'N0') as TotalReturn"
            '                sqlcmd = New SqlCommand(all, sqlcon)
            '                    ada.SelectCommand = sqlcmd
            '                ada.Fill(ads, "dummy1")
            '            Next
            '            ada.SelectCommand = sqlcmd
            '            ada.Fill(ads, "dummy1")
            '            abs.DataSource = ads
            '            abs.DataMember = "dummy1"
            '            Form4.KryptonDataGridView1.DataSource = abs
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub

    Public Sub searchstockstransaction(ByVal search As String, ByVal condition As String, ByVal stockno As String, ByVal transaction As String, ByVal reference As String, ByVal datetype As String)
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            ds.Clear()
            Dim da As New SqlDataAdapter
            Dim bs As New BindingSource
            Dim str1 As String

            str1 = "select TRANSNO,
STOCKNO,
TRANSTYPE,
TRANSDATE,
case when isdate(DUEDATE)=1 then cast(duedate as date) end as DUEDATE,
QTY,
BALQTY,
REFERENCE,
ACCOUNT,
CONTROLNO,
XYZ,
XYZREF,
EXCESS,
REMARKS,
UFACTOR,
(ufactor * qty) as CHECKER,
UNITPRICE,
((ufactor * qty)*unitprice) as CURRENCY,
XRATE,
NETAMOUNT,
INPUTTED
 from trans_tb " + "" & search & ""

            sqlcmd = New SqlCommand(str1 + " order by " & datetype & " desc ", sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "trans_tb")
            bs.DataSource = ds
            bs.DataMember = "trans_tb"
            Form4.mytransgridview.DataSource = bs


            Dim dss As New inventoryds
            dss.Clear()
            sqlcmd = New SqlCommand(str1 + " order by " & datetype & " desc ", sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(dss.TRANS_TB)
            Form13.TRANS_TBBindingSource.DataSource = dss.TRANS_TB.DefaultView


            Form4.mytransgridview.Columns("TRANSDATE").DefaultCellStyle.Format = "yyyy-MMM-dd"
            Form4.mytransgridview.Columns("DUEDATE").DefaultCellStyle.Format = "yyyy-MMM-dd"

            Form4.mytransgridview.Columns("UFACTOR").DefaultCellStyle.Format = "N2"
            Form4.mytransgridview.Columns("UNITPRICE").DefaultCellStyle.Format = "N2"
            Form4.mytransgridview.Columns("XRATE").DefaultCellStyle.Format = "N2"
            Form4.mytransgridview.Columns("NETAMOUNT").DefaultCellStyle.Format = "N2"
            Form4.mytransgridview.Columns("CHECKER").DefaultCellStyle.Format = "N2"
            Form4.mytransgridview.Columns("CURRENCY").DefaultCellStyle.Format = "N2"
            Form4.mytransgridview.Columns("EXCESS").DefaultCellStyle.Format = "N2"

            Form4.mytransgridview.Columns("QTY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form4.mytransgridview.Columns("UFACTOR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form4.mytransgridview.Columns("UNITPRICE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form4.mytransgridview.Columns("XRATE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form4.mytransgridview.Columns("NETAMOUNT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form4.mytransgridview.Columns("CHECKER").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form4.mytransgridview.Columns("CURRENCY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form4.mytransgridview.Columns("EXCESS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Form4.mytransgridview.Columns("stockno").Visible = False

            For i As Integer = 0 To Form4.mytransgridview.RowCount - 1 Step +1
                Dim s As String = Form4.mytransgridview.Rows(i).Cells("balqty").Value.ToString
                Dim t As String = Form4.mytransgridview.Rows(i).Cells("transtype").Value.ToString
                If Not s = "0.00" And Not s = "" And t = "Allocation" Then
                    Form4.mytransgridview.Rows(i).Cells("balqty").Style.ForeColor = Color.Red
                End If
            Next
            For i As Integer = 0 To Form4.mytransgridview.RowCount - 1 Step +1
                Dim s As String = Form4.mytransgridview.Rows(i).Cells("xyzref").Value.ToString
                Dim t As String = Form4.mytransgridview.Rows(i).Cells("transtype").Value.ToString
                If Not s = "" And t = "Order" Then
                    Form4.mytransgridview.Rows(i).DefaultCellStyle.BackColor = Color.Pink
                End If
            Next

            Dim str11 As String = "select distinct reference from trans_tb " & search & ""
            Dim ds1 As New DataSet
            Dim da1 As New SqlDataAdapter
            Dim bs1 As New BindingSource
            sqlcmd = New SqlCommand(str11, sqlcon)
            da1.SelectCommand = sqlcmd
            da1.Fill(ds1, "trans_tb")
            bs1.DataSource = ds1
            bs1.DataMember = "trans_tb"
            Form4.referencegridview.DataSource = bs1

            Dim str As String


            If transaction = "Issu33333e" Then
                str = "       declare @issue as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb " & condition & " AND TRANSTYPE='Issue' AND NOT XYZ ='Allocation')+0
                              declare @issueallocation as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb " & condition & " AND TRANSTYPE='Issue' AND XYZ ='Allocation')+0
                              declare @totalissue as decimal(10,2)=@issue+@issueallocation
                     select format(0,'N0'),FORMAT(0,'N0'),FORMAT(0,'N0'),
                     FORMAT(0,'N0'),FORMAT(@totalissue,'N0'),format(0,'N0'),FORMAT(0,'N0'),format(0,'N0')"
            Else
                str = "
                                                declare @allocation as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb " & condition & " AND TRANSTYPE='Allocation')+0
                                                declare @balqty as decimal(10,2)=(select  COALESCE(sum(balqty),0) from trans_tb " & condition & " AND TRANSTYPE='Allocation')+0
                                                declare @cancelalloc as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb " & condition & " AND TRANSTYPE='CancelAlloc')+0
                                                declare @order as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb " & condition & " AND TRANSTYPE='Order')+0
                                                declare @return as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb " & condition & " AND TRANSTYPE='Return')+0
                                                declare @supply as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb " & condition & " AND TRANSTYPE='Supply')+0
                                                declare @spare as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb " & condition & " AND TRANSTYPE='Spare')+0
                                                declare @addadjustment as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb " & condition & " AND TRANSTYPE='+Adjustment')+0
                                                declare @minadjustment as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb " & condition & " AND TRANSTYPE='-Adjustment')+0
                                                declare @receipt as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb " & condition & " AND TRANSTYPE='Receipt' AND NOT XYZ='Order')+0
                                                declare @issue as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb " & condition & " AND TRANSTYPE='Issue' AND NOT XYZ ='Allocation')+0
                                                declare @receiptorder as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb " & condition & " AND TRANSTYPE='Receipt' AND XYZ='Order')+0
                                                declare @issueallocation as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb " & condition & " AND TRANSTYPE='Issue' AND XYZ ='Allocation')+0
                                                declare @totalreceipt as decimal(10,2)=@receipt+@receiptorder
                                                declare @totalissue as decimal(10,2)=@issue+@issueallocation

            declare @QTY as decimal(10,2)=(select qty from stocks_tb where stockno='" & stockno & "')

                                                declare @finalphysical as decimal(10,2)=(@QTY+@totalreceipt+@return+@addadjustment)-(@totalissue+@minadjustment)
                                                declare @finalallocation as decimal(10,2)=@allocation-(@issueallocation+@cancelalloc)
                                                declare @finalfree as decimal(10,2)=(((@QTY+@totalreceipt+@return+@addadjustment)-(@allocation-@cancelalloc)))-(@issue+@minadjustment)
                                                declare @finalorder as decimal(10,2)=@order-@receiptorder
                                                declare @finalissue as decimal(10,2)=@totalissue
                                                declare @finalreceipt as decimal(10,2)=@totalreceipt

                     select format(@finalphysical,'N0'),FORMAT(@finalallocation,'N0'),FORMAT(@finalfree,'N0'),
                     FORMAT(@finalorder,'N0'),FORMAT(@finalissue,'N0'),format(@finalreceipt,'N0'),FORMAT(@return,'N0'),format(@balqty,'N0')"

                'ElseIf transaction = "Order" Then
                '    ElseIf transaction = "Receipt" Then
                '    ElseIf transaction = "Return" Then
                '    ElseIf transaction = "Supply" Then
                '    ElseIf transaction = "Spare" Then
                '    ElseIf transaction = "+Adjustment" Then
                '    ElseIf transaction = "-Adjustment" Then
                '    ElseIf transaction = "CancelAlloc" Then
            End If

            sqlcmd = New SqlCommand(str, sqlcon)
            Dim read As SqlDataReader = sqlcmd.ExecuteReader

            While read.Read
                Form4.finalphysical.Text = read(0).ToString
                Form4.finalallocation.Text = read(1).ToString
                Form4.finalfree.Text = read(2).ToString
                Form4.finalorder.Text = read(3).ToString
                Form4.finalissue.Text = read(4).ToString
                Form4.finalreceipt.Text = read(5).ToString
                Form4.finalreturn.Text = read(6).ToString
                Form4.balalloc.Text = read(7).ToString
                If transaction = "" Then

                ElseIf transaction = "Allocation" Then
                    Form4.finalphysical.Text = 0
                    Form4.finalallocation.Text = read(1).ToString
                    Form4.finalfree.Text = 0
                    Form4.finalorder.Text = 0
                    Form4.finalissue.Text = 0
                    Form4.finalreceipt.Text = 0
                    Form4.finalreturn.Text = 0
                    Form4.balalloc.Text = read(7).ToString
                ElseIf transaction = "Order" Then
                    Form4.finalphysical.Text = 0
                    Form4.finalallocation.Text = 0
                    Form4.finalfree.Text = 0
                    Form4.finalorder.Text = read(3).ToString
                    Form4.finalissue.Text = 0
                    Form4.finalreceipt.Text = 0
                    Form4.finalreturn.Text = 0
                    Form4.balalloc.Text = 0
                ElseIf transaction = "Issue" Then
                    Form4.finalphysical.Text = 0
                    Form4.finalallocation.Text = 0
                    Form4.finalfree.Text = 0
                    Form4.finalorder.Text = 0
                    Form4.finalissue.Text = read(4).ToString
                    Form4.finalreceipt.Text = 0
                    Form4.finalreturn.Text = 0
                    Form4.balalloc.Text = 0
                ElseIf transaction = "Receipt" Then
                    Form4.finalphysical.Text = 0
                    Form4.finalallocation.Text = 0
                    Form4.finalfree.Text = 0
                    Form4.finalorder.Text = 0
                    Form4.finalissue.Text = 0
                    Form4.finalreceipt.Text = read(5).ToString
                    Form4.finalreturn.Text = 0
                    Form4.balalloc.Text = 0
                ElseIf transaction = "Return" Then
                    Form4.finalphysical.Text = 0
                    Form4.finalallocation.Text = 0
                    Form4.finalfree.Text = 0
                    Form4.finalorder.Text = 0
                    Form4.finalissue.Text = 0
                    Form4.finalreceipt.Text = 0
                    Form4.finalreturn.Text = read(6).ToString
                    Form4.balalloc.Text = 0
                End If
            End While
            read.Close()


            Form4.referencegridview.SelectAll()
            Form4.ProgressBar1.Value = 0
            Form4.ProgressBar1.Maximum = Form4.referencegridview.RowCount


            Dim ads As New DataSet
            ads.Clear()
            Dim abs As New BindingSource
            Dim ada As New SqlDataAdapter

            Dim refere As String
            Form4.KryptonDataGridView1.DataSource = Nothing
            Dim all As String
            If transaction = "" Then
                all = "
                     select Reference,stockorder as StockOrder,allocation as Allocation
                     ,totalreceipt as TotalReceipt,totalissue as TotalIssue,totalreturn as TotalReturn from reference_tb where stockno='" & stockno & "'"
                sqlcmd = New SqlCommand(all, sqlcon)
                ada.SelectCommand = sqlcmd
                ada.Fill(ads, "reference_tb")
            Else


                'For i As Integer = 0 To Form4.ComboBox1.Items.Count - 1
                '    refere = Form4.ComboBox1.Items(i).ToString
                '    Form4.ProgressBar1.Value += 1
                '    If Form4.ProgressBar1.Value = Form4.referencegridview.RowCount Then
                '        Form4.ProgressBar1.Value = 0
                '    End If
                'If transaction = "" Then
                '                    all = "  
                'declare @refe as varchar(max) = '" & refere & "'
                'declare @allocation as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb " & condition & " and reference = '" & refere & "' AND TRANSTYPE='Allocation')+0
                '                                                declare @cancelalloc as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb " & condition & " and reference = '" & refere & "' AND TRANSTYPE='CancelAlloc')+0
                '                                                declare @order as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb " & condition & " and reference = '" & refere & "' AND TRANSTYPE='Order')+0
                '                                                declare @return as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb " & condition & " and reference = '" & refere & "' AND TRANSTYPE='Return')+0
                '                                                declare @supply as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb " & condition & " and reference = '" & refere & "' AND TRANSTYPE='Supply')+0
                '                                                declare @spare as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb " & condition & " and reference = '" & refere & "' AND TRANSTYPE='Spare')+0
                '                                                declare @addadjustment as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb " & condition & " and reference = '" & refere & "' AND TRANSTYPE='+Adjustment')+0
                '                                                declare @minadjustment as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb " & condition & " and reference = '" & refere & "' AND TRANSTYPE='-Adjustment')+0
                '                                                declare @receipt as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb " & condition & " and reference = '" & refere & "' AND TRANSTYPE='Receipt' AND NOT XYZ='Order')+0
                '                                                declare @issue as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb " & condition & " and reference = '" & refere & "' AND TRANSTYPE='Issue' AND NOT XYZ ='Allocation')+0
                '                                                declare @receiptorder as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb " & condition & " and reference = '" & refere & "' AND TRANSTYPE='Receipt' AND XYZ='Order')+0
                '                                                declare @issueallocation as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb " & condition & " and reference = '" & refere & "' AND TRANSTYPE='Issue' AND XYZ ='Allocation')+0
                '                                                declare @totalreceipt as decimal(10,2)=@receipt+@receiptorder
                '                                                declare @totalissue as decimal(10,2)=@issue+@issueallocation

                '            declare @QTY as decimal(10,2)=(select qty from stocks_tb where stockno='" & stockno & "')

                '                                                declare @finalphysical as decimal(10,2)=(@QTY+@totalreceipt+@return+@addadjustment)-(@totalissue+@minadjustment)
                '                                                declare @finalallocation as decimal(10,2)=@allocation-(@issueallocation+@cancelalloc)
                '                                                declare @finalfree as decimal(10,2)=(((@QTY+@totalreceipt+@return+@addadjustment)-(@allocation-@cancelalloc)))-(@issue+@minadjustment)
                '                                                declare @finalorder as decimal(10,2)=@order-@receiptorder
                '                                                declare @finalissue as decimal(10,2)=@totalissue
                '                                                declare @finalreceipt as decimal(10,2)=@totalreceipt

                '                     select @refe as Reference,FORMAT(@finalorder,'N0') as StockOrder,FORMAT(@finalallocation,'N0') as Allocation
                '                     ,format(@finalreceipt,'N0') as TotalReceipt,FORMAT(@finalissue,'N0') as TotalIssue,FORMAT(@return,'N0') as TotalReturn

                '                     select Reference,FORMAT(stockorder,'N0') as StockOrder,FORMAT(allocation,'N0') as Allocation
                '                     ,format(totalreceipt,'N0') as TotalReceipt,FORMAT(totalissue,'N0') as TotalIssue,FORMAT(totalreturn,'N0') as TotalReturn from reference_tb"
                '                    sqlcmd = New SqlCommand(all, sqlcon)
                '                    ada.SelectCommand = sqlcmd
                '                    ada.Fill(ads, "reference_tb")


                '                    If transaction = "Issue" Then
                '                        all = "  
                'declare @refe as varchar(max) = '" & refere & "'
                'declare @allocation as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb " & condition & " and reference = '" & refere & "' AND TRANSTYPE='Allocation')+0
                '                                 declare @issue as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb " & condition & " and reference = '" & refere & "' AND TRANSTYPE='Issue' AND NOT XYZ ='Allocation')+0
                '                                 declare @issueallocation as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb " & condition & " and reference = '" & refere & "' AND TRANSTYPE='Issue' AND XYZ ='Allocation')+0
                '                                 declare @totalissue as decimal(10,2)=@issue+@issueallocation

                '                                 select @refe as Reference,0 as StockOrder,0 as Allocation
                '                     ,0 as TotalReceipt,@totalissue as TotalIssue,0 as TotalReturn order by TotalIssue desc"
                '                        sqlcmd = New SqlCommand(all, sqlcon)
                '                        ada.SelectCommand = sqlcmd
                '                        ada.Fill(ads, "dummy1")
                '                    ElseIf transaction = "Receipt" Then
                '                        all = "  
                'declare @refe as varchar(max) = '" & refere & "'
                ' declare @receipt as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb " & condition & " and reference = '" & refere & "' AND TRANSTYPE='Receipt' AND NOT XYZ='Order')+0
                '                                               declare @receiptorder as decimal(10,2)=(select  COALESCE(sum(qty),0) from trans_tb " & condition & " and reference = '" & refere & "' AND TRANSTYPE='Receipt' AND XYZ='Order')+0
                '                                            declare @totalreceipt as decimal(10,2)=@receipt+@receiptorder


                '                     select @refe as Reference,0 as StockOrder,0 as Allocation
                '                     ,@totalreceipt as TotalReceipt,0 as TotalIssue,0 as TotalReturn order by TotalReceipt desc"
                '                        sqlcmd = New SqlCommand(all, sqlcon)
                '                        ada.SelectCommand = sqlcmd
                '                        ada.Fill(ads, "dummy1")
                '                    End If

                '                Next
            End If
            'If transaction = "Issue" Then
            '    abs.DataSource = ads
            '    abs.DataMember = "dummy1"
            '    Form4.KryptonDataGridView1.DataSource = abs
            '    Form4.KryptonDataGridView1.Columns("TotalIssue").DefaultCellStyle.Format = "N0"
            'ElseIf transaction = "Receipt" Then
            '    abs.DataSource = ads
            '    abs.DataMember = "dummy1"
            '    Form4.KryptonDataGridView1.DataSource = abs
            '    Form4.KryptonDataGridView1.Columns("TotalReceipt").DefaultCellStyle.Format = "N0"
            If transaction = "" Then
                abs.DataSource = ads
                abs.DataMember = "reference_tb"
                Form4.KryptonDataGridView1.DataSource = abs
                Form4.KryptonDataGridView1.Columns("StockOrder").DefaultCellStyle.Format = "N0"
                Form4.KryptonDataGridView1.Columns("Allocation").DefaultCellStyle.Format = "N0"
                Form4.KryptonDataGridView1.Columns("TotalReceipt").DefaultCellStyle.Format = "N0"
                Form4.KryptonDataGridView1.Columns("TotalIssue").DefaultCellStyle.Format = "N0"
                Form4.KryptonDataGridView1.Columns("TotalReturn").DefaultCellStyle.Format = "N0"
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub searchtransaction(ByVal search As String, ByVal count As String)
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            Dim i As Integer
            If Form2.transgridview.SortedColumn Is Nothing Then
                i = 4
            Else
                i = Form2.transgridview.SortedColumn.Index
            End If

            Dim SetSortOrder As ListSortDirection
            Dim GridSortOrder As SortOrder
            GridSortOrder = Form2.transgridview.SortOrder
            If GridSortOrder = Windows.Forms.SortOrder.Ascending Then
                SetSortOrder = ListSortDirection.Ascending
            ElseIf GridSortOrder = Windows.Forms.SortOrder.Descending Then
                SetSortOrder = ListSortDirection.Descending
            ElseIf GridSortOrder = Windows.Forms.SortOrder.None Then
                SetSortOrder = ListSortDirection.Ascending
            Else : GridSortOrder = ListSortDirection.Ascending

            End If
            ds.Clear()

            sqlcmd = New SqlCommand(search + " order by a.transdate desc", sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "trans_tb")
            Form2.transgridview.DataSource = Nothing
            Form2.transBindingSource.DataSource = ds
            Form2.transBindingSource.DataMember = "trans_tb"
            Form2.transgridview.DataSource = Form2.transBindingSource

            Form2.transgridview.Sort(Form2.transgridview.Columns(i), SetSortOrder)

            Form2.transgridview.Columns("DESCRIPTION").Visible = False
            Form2.transgridview.Columns("xyz").Visible = False
            Form2.transgridview.Columns("QTY").DefaultCellStyle.Format = "N2"
            Form2.transgridview.Columns("EXCESS").DefaultCellStyle.Format = "N2"
            Form2.transgridview.Columns("UFACTOR").DefaultCellStyle.Format = "N2"
            Form2.transgridview.Columns("UNITPRICE").DefaultCellStyle.Format = "N4"
            Form2.transgridview.Columns("XRATE").DefaultCellStyle.Format = "N2"
            Form2.transgridview.Columns("NETAMOUNT").DefaultCellStyle.Format = "N2"
            Form2.transgridview.Columns("CHECKER").DefaultCellStyle.Format = "N2"
            Form2.transgridview.Columns("CURRENCY").DefaultCellStyle.Format = "N2"
            Form2.transgridview.Columns("DISC").DefaultCellStyle.Format = "N2"
            Form2.transgridview.Columns("QTY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.transgridview.Columns("EXCESS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.transgridview.Columns("UFACTOR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.transgridview.Columns("UNITPRICE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.transgridview.Columns("XRATE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.transgridview.Columns("NETAMOUNT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.transgridview.Columns("CHECKER").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.transgridview.Columns("CURRENCY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form2.transgridview.Columns("DISC").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            cuttinglist.transno.DataBindings.Clear()
            cuttinglist.remarks.DataBindings.Clear()
            cuttinglist.allocation.DataBindings.Clear()
            cuttinglist.transtype.DataBindings.Clear()
            Form2.description.DataBindings.Clear()
            cuttinglist.transno.DataBindings.Add("text", Form2.transBindingSource, "transno")
            cuttinglist.remarks.DataBindings.Add("text", Form2.transBindingSource, "remarks")
            cuttinglist.allocation.DataBindings.Add("text", Form2.transBindingSource, "qty")
            cuttinglist.transtype.DataBindings.Add("text", Form2.transBindingSource, "TRANSTYPE")
            Form2.description.DataBindings.Add("text", Form2.transBindingSource, "DESCRIPTION")


            If Form2.transtransaction.Text = "Receipt" Or Form2.transtransaction.Text = "Order" Then
                sqlcmd = New SqlCommand(count, sqlcon)
                Dim readerr As SqlDataReader = sqlcmd.ExecuteReader
                While readerr.Read
                    Form2.noofresults.Text = readerr(0).ToString() + " results found / Foreign currency : " + readerr(1).ToString
                End While
                readerr.Close()
            End If




            tmanagecols()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub loadaccount()
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter
            ds.Clear()
            Dim bs As New BindingSource
            Dim str As String = "Select distinct account from trans_tb"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "trans_tb")
            bs.DataSource = ds
            bs.DataMember = "trans_tb"
            Form2.issueaccount.DataSource = bs
            Form2.issueaccount.ValueMember = "account"
            Form2.issueaccount.DisplayMember = "account"
            Form2.issueaccount.SelectedIndex = -1

            Form2.account.DataSource = bs
            Form2.account.ValueMember = "account"
            Form2.account.DisplayMember = "account"
            Form2.account.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub selectreference(ByVal stockno As String, ByVal reference As String)
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter
            ds.Clear()
            Dim bs As New BindingSource
            Dim Str As String = "Select reference As [REFERENCE]
      ,stockno as [STOCKNO]
      ,STOCKORDER as [ORDER]
      ,ALLOCATION as [ALLOCATION]
      ,TOTALRECEIPT as [RECEIPT]
      ,TOTALISSUE as [ISSUE],
        TOTALRETURN AS [RETURN] from reference_tb where stockno='" & stockno & "' and reference='" & reference & "'"
            sqlcmd = New SqlCommand(Str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "reference_tb")
            bs.DataSource = ds
            bs.DataMember = "reference_tb"
            Form5.referencegridview.DataSource = bs
            Form5.referencegridview.Columns("stockno").Visible = False
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub updatetransdates(ByVal transno As String, ByVal transdate As String, ByVal duedate As String, ByVal qty As String, ByVal xyzref As String, ByVal adjremarks As String)
        Try
            sqlcon.Open()
            Dim str As String = ""
            'order
            If Form5.transtype.Text = "Order" And Form5.xyzref.Text = "" Then
                str = "update trans_tb set transdate='" & transdate & "',duedate ='" & duedate & "', qty = '" & qty & "',netamount=(xrate*(unitprice-((disc*0.01)*unitprice)))*(" & qty & "*ufactor) where transno = '" & transno & "'"
            ElseIf Form5.transtype.Text = "Order" And Not Form5.xyzref.Text = "" Then
                str = "update trans_tb set transdate='" & transdate & "',duedate ='" & duedate & "' where transno = '" & transno & "'"
                'receipt
            ElseIf Form5.transtype.Text = "Receipt" And Form5.xyzref.Text = "" Then
                str = "update trans_tb set transdate='" & transdate & "',duedate ='" & duedate & "',qty = '" & qty & "',netamount=(xrate*(unitprice-((disc*0.01)*unitprice)))*(" & qty & "*ufactor) where transno = '" & transno & "'"
            ElseIf Form5.transtype.Text = "Receipt" And Not Form5.xyzref.Text = "" Then
                str = "update trans_tb set transdate='" & transdate & "',duedate ='" & duedate & "',qty = '" & qty & "',netamount=(xrate*(unitprice-((disc*0.01)*unitprice)))*(" & qty & "*ufactor) where transno = '" & transno & "'
                       update trans_tb set qty = '" & qty & "',netamount=(xrate*(unitprice-((disc*0.01)*unitprice)))*(" & qty & "*ufactor) where transno = '" & xyzref & "'"
                'allocation
            ElseIf Form5.transtype.Text = "Allocation" And Form5.xyzref.Text = "" Then
                str = "update trans_tb set transdate='" & transdate & "',duedate ='" & duedate & "', qty = '" & qty & "', adjustmentqty='" & adjremarks & "' where transno = '" & transno & "'"
            ElseIf Form5.transtype.Text = "Allocation" And Not Form5.xyzref.Text = "" Then
                str = "update trans_tb set transdate='" & transdate & "',duedate ='" & duedate & "' where transno = '" & transno & "'"
                'issue
            ElseIf Form5.transtype.Text = "Issue" And Form5.xyzref.Text = "" Then
                str = "update trans_tb set transdate='" & transdate & "',duedate ='" & duedate & "', qty = '" & qty & "' where transno = '" & transno & "'"
            ElseIf Form5.transtype.Text = "Issue" And Not Form5.xyzref.Text = "" Then
                str = "update trans_tb set transdate='" & transdate & "',duedate ='" & duedate & "', qty = '" & qty & "' where transno = '" & transno & "'"
                'return
            ElseIf Form5.transtype.Text = "Return" And Form5.xyzref.Text = "" Then
                str = "update trans_tb set transdate='" & transdate & "',duedate ='" & duedate & "', qty = '" & qty & "' where transno = '" & transno & "'"
            ElseIf Form5.transtype.Text = "Return" And Not Form5.xyzref.Text = "" Then
                str = "update trans_tb set transdate='" & transdate & "',duedate ='" & duedate & "', qty = '" & qty & "' where transno = '" & transno & "'"
                'Supply
            ElseIf Form5.transtype.Text = "Supply" And Form5.xyzref.Text = "" Then
                str = "update trans_tb set transdate='" & transdate & "',duedate ='" & duedate & "', qty = '" & qty & "' where transno = '" & transno & "'"
            ElseIf Form5.transtype.Text = "Supply" And Not Form5.xyzref.Text = "" Then
                str = "update trans_tb set transdate='" & transdate & "',duedate ='" & duedate & "', qty = '" & qty & "' where transno = '" & transno & "'"
                'Spare
            ElseIf Form5.transtype.Text = "Spare" And Form5.xyzref.Text = "" Then
                str = "update trans_tb set transdate='" & transdate & "',duedate ='" & duedate & "', qty = '" & qty & "' where transno = '" & transno & "'"
            ElseIf Form5.transtype.Text = "Spare" And Not Form5.xyzref.Text = "" Then
                str = "update trans_tb set transdate='" & transdate & "',duedate ='" & duedate & "', qty = '" & qty & "' where transno = '" & transno & "'"
                '+Adjustment
            ElseIf Form5.transtype.Text = "+Adjustment" And Form5.xyzref.Text = "" Then
                str = "update trans_tb set transdate='" & transdate & "',duedate ='" & duedate & "', qty = '" & qty & "' where transno = '" & transno & "'"
            ElseIf Form5.transtype.Text = "+Adjustment" And Not Form5.xyzref.Text = "" Then
                str = "update trans_tb set transdate='" & transdate & "',duedate ='" & duedate & "', qty = '" & qty & "' where transno = '" & transno & "'"
                '-Adjustment
            ElseIf Form5.transtype.Text = "-Adjustment" And Form5.xyzref.Text = "" Then
                str = "update trans_tb set transdate='" & transdate & "',duedate ='" & duedate & "', qty = '" & qty & "' where transno = '" & transno & "'"
            ElseIf Form5.transtype.Text = "-Adjustment" And Not Form5.xyzref.Text = "" Then
                str = "update trans_tb set transdate='" & transdate & "',duedate ='" & duedate & "', qty = '" & qty & "' where transno = '" & transno & "'"
            End If
            If str = "" Then
                MessageBox.Show("")
            Else
                sqlcmd = New SqlCommand(str, sqlcon)
                sqlcmd.ExecuteNonQuery()
                MessageBox.Show("transaction updated!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Form5.initialqty.Text = Form5.qty.Text
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub


    Public Sub selecttransrec(ByVal transno As String)
        Try
            sqlcon.Open()
            Dim str As String = "select a.TRANSNO,
a.STOCKNO,
b.COSTHEAD,
b.TYPECOLOR,
B.ARTICLENO,
B.DESCRIPTION,
a.TRANSTYPE,
format(a.TRANSDATE,'yyyy-MMM-dd') AS [TRANSDATE],
FORMAT(Case when isdate(a.duedate)=1 then cast(a.DUEDATE as date) end,'yyyy-MMM-dd') as DUEDATE,
a.QTY,
a.REFERENCE,
a.ACCOUNT,
a.CONTROLNO,
a.xyzref,
a.balqty,
a.adjustmentqty
 from trans_tb as a inner join stocks_tb as b
on a.stockno = b.stockno where a.transno='" & transno & "'"
            Dim ds As New DataSet
            ds.Clear()
            Dim da As New SqlDataAdapter

            Dim bs As New BindingSource
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "trans_tb")
            bs.DataSource = ds
            bs.DataMember = "trans_tb"

            Form5.stockno.DataBindings.Clear()
            Form5.costhead.DataBindings.Clear()
            Form5.typecolor.DataBindings.Clear()
            Form5.articleno.DataBindings.Clear()
            Form5.description.DataBindings.Clear()
            Form5.transtype.DataBindings.Clear()
            Form5.transdate.DataBindings.Clear()
            Form5.duedate.DataBindings.Clear()
            Form5.qty.DataBindings.Clear()
            Form5.initialqty.DataBindings.Clear()
            Form5.balanceqty.DataBindings.Clear()
            Form5.reference.DataBindings.Clear()
            Form5.account.DataBindings.Clear()
            Form5.controlno.DataBindings.Clear()
            Form5.xyzref.DataBindings.Clear()
            Form5.ADJUSTMENTREMARKS.DataBindings.Clear()
            Form5.stockno.DataBindings.Add("text", bs, "stockno")
            Form5.costhead.DataBindings.Add("text", bs, "COSTHEAD")
            Form5.typecolor.DataBindings.Add("text", bs, "TYPECOLOR")
            Form5.articleno.DataBindings.Add("text", bs, "ARTICLENO")
            Form5.description.DataBindings.Add("text", bs, "DESCRIPTION")
            Form5.transtype.DataBindings.Add("text", bs, "TRANSTYPE")
            Form5.transdate.DataBindings.Add("text", bs, "TRANSDATE")
            Form5.duedate.DataBindings.Add("text", bs, "DUEDATE")
            Form5.qty.DataBindings.Add("text", bs, "QTY")
            Form5.initialqty.DataBindings.Add("text", bs, "QTY")
            Form5.balanceqty.DataBindings.Add("text", bs, "balqty")
            Form5.reference.DataBindings.Add("text", bs, "REFERENCE")
            Form5.account.DataBindings.Add("text", bs, "ACCOUNT")
            Form5.controlno.DataBindings.Add("text", bs, "CONTROLNO")
            Form5.xyzref.DataBindings.Add("text", bs, "xyzref")
            Form5.ADJUSTMENTREMARKS.DataBindings.Add("text", bs, "adjustmentqty")

            Form5.newcosthead.DataBindings.Clear()
            Form5.newtypecolor.DataBindings.Clear()
            Form5.newarticleno.DataBindings.Clear()
            Form5.newstockno.DataBindings.Clear()
            Form5.newstockno.DataBindings.Add("text", bs, "stockno")
            Form5.newcosthead.DataBindings.Add("text", bs, "COSTHEAD")
            Form5.newtypecolor.DataBindings.Add("text", bs, "TYPECOLOR")
            Form5.newarticleno.DataBindings.Add("text", bs, "ARTICLENO")




        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub referencetb()
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            ds.Clear()

            Dim str As String = "select a.REFERENCE,
a.STOCKNO,
b.COSTHEAD,
b.TYPECOLOR,
b.ARTICLENO,
a.STOCKORDER,
a.ALLOCATION,
a.TOTALRECEIPT,
a.TOTALISSUE,
A.TOTALRETURN,
b.description,
a.ADDRESS
from reference_tb as a
inner join
stocks_tb as b
on a.stockno=b.stockno order by a.reference asc,a.stockorder desc,a.allocation desc"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "reference_tb")
            Form2.referenceDataGridView.DataSource = Nothing
            Form2.referencebs.DataSource = ds
            Form2.referencebs.DataMember = "reference_tb"
            Form2.referenceDataGridView.DataSource = Form2.referencebs
            Form2.referenceDataGridView.Columns("description").Visible = False
            editreference.reference.DataBindings.Clear()
            editreference.stockno.DataBindings.Clear()
            editreference.costhead.DataBindings.Clear()
            editreference.typecolor.DataBindings.Clear()
            editreference.articleno.DataBindings.Clear()
            editreference.allocation.DataBindings.Clear()
            editreference.order.DataBindings.Clear()
            editreference.reference.DataBindings.Add("text", Form2.referencebs, "REFERENCE")
            editreference.stockno.DataBindings.Add("text", Form2.referencebs, "STOCKNO")
            editreference.costhead.DataBindings.Add("text", Form2.referencebs, "COSTHEAD")
            editreference.typecolor.DataBindings.Add("text", Form2.referencebs, "TYPECOLOR")
            editreference.articleno.DataBindings.Add("text", Form2.referencebs, "ARTICLENO")
            editreference.order.DataBindings.Add("text", Form2.referencebs, "STOCKORDER")

            moveallocation.reference.DataBindings.Clear()
            moveallocation.newstockno.DataBindings.Clear()
            moveallocation.newcosthead.DataBindings.Clear()
            moveallocation.newtypecolor.DataBindings.Clear()
            moveallocation.newarticleno.DataBindings.Clear()

            moveallocation.reference.DataBindings.Add("text", Form2.referencebs, "REFERENCE")
            moveallocation.newstockno.DataBindings.Add("text", Form2.referencebs, "STOCKNO")
            moveallocation.newcosthead.DataBindings.Add("text", Form2.referencebs, "COSTHEAD")
            moveallocation.newtypecolor.DataBindings.Add("text", Form2.referencebs, "TYPECOLOR")
            moveallocation.newarticleno.DataBindings.Add("text", Form2.referencebs, "ARTICLENO")

            loadreffromreference()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub loadreffromreference()
        Try
            Dim ds As New DataSet
            ds.Clear()
            Dim str As String = "select distinct reference from reference_tb"
            Dim da As New SqlDataAdapter
            Dim bs As New BindingSource
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "reference_tb")
            bs.DataSource = ds
            bs.DataMember = "reference_tb"
            Form2.reffromreference.DataSource = bs
            Form2.reffromreference.DisplayMember = "reference"
            Form2.reffromreference.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub removefromref(ByVal ref As String, ByVal stockno As String)
        Try
            sqlcon.Open()
            Dim str As String = "delete from reference_tb where reference='" & ref & "' and stockno='" & stockno & "'"
            sqlcmd = New SqlCommand(str, sqlcon)
            sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub refsearch(ByVal where As String)
        Try
            sqlcon.Open()
            Dim ds As New DataSet

            ds.Clear()
            Dim str As String = "select a.REFERENCE,
a.STOCKNO,
b.COSTHEAD,
b.TYPECOLOR,
b.ARTICLENO,
a.STOCKORDER,
a.ALLOCATION,
a.TOTALRECEIPT,
a.TOTALISSUE,
A.TOTALRETURN,
b.description,
a.ADDRESS
from reference_tb as a
inner join
stocks_tb as b
on a.stockno=b.stockno " & where & " order by a.reference asc,a.stockorder desc,a.allocation desc"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "reference_tb")
            Form2.referenceDataGridView.DataSource = Nothing
            Form2.referencebs.DataSource = ds
            Form2.referencebs.DataMember = "reference_tb"
            Form2.referencebs.DataMember = "reference_tb"
            Form2.referenceDataGridView.DataSource = Form2.referencebs
            Form2.referenceDataGridView.Columns("description").Visible = False
            editreference.reference.DataBindings.Clear()
            editreference.stockno.DataBindings.Clear()
            editreference.costhead.DataBindings.Clear()
            editreference.typecolor.DataBindings.Clear()
            editreference.articleno.DataBindings.Clear()
            editreference.allocation.DataBindings.Clear()
            editreference.order.DataBindings.Clear()
            editreference.reference.DataBindings.Add("text", Form2.referencebs, "REFERENCE")
            editreference.stockno.DataBindings.Add("text", Form2.referencebs, "STOCKNO")
            editreference.costhead.DataBindings.Add("text", Form2.referencebs, "COSTHEAD")
            editreference.typecolor.DataBindings.Add("text", Form2.referencebs, "TYPECOLOR")
            editreference.articleno.DataBindings.Add("text", Form2.referencebs, "ARTICLENO")
            editreference.allocation.DataBindings.Add("text", Form2.referencebs, "ALLOCATION")
            editreference.order.DataBindings.Add("text", Form2.referencebs, "STOCKORDER")

            moveallocation.reference.DataBindings.Clear()
            moveallocation.newstockno.DataBindings.Clear()
            moveallocation.newcosthead.DataBindings.Clear()
            moveallocation.newtypecolor.DataBindings.Clear()
            moveallocation.newarticleno.DataBindings.Clear()

            moveallocation.reference.DataBindings.Add("text", Form2.referencebs, "REFERENCE")
            moveallocation.newstockno.DataBindings.Add("text", Form2.referencebs, "STOCKNO")
            moveallocation.newcosthead.DataBindings.Add("text", Form2.referencebs, "COSTHEAD")
            moveallocation.newtypecolor.DataBindings.Add("text", Form2.referencebs, "TYPECOLOR")
            moveallocation.newarticleno.DataBindings.Add("text", Form2.referencebs, "ARTICLENO")
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub alltransaction()
        Try
            sqlcon.Open()
            Dim ds As New inventoryds
            Dim da As New SqlDataAdapter
            ds.Clear()
            Dim str As String = "select a.TRANSNO,
a.STOCKNO,
b.TYPECOLOR,
b.ARTICLENO,
a.TRANSTYPE,
format(a.TRANSDATE,'yyyy-MMM-dd') as TRANSDATE,
a.DUEDATE,
a.QTY,
a.REFERENCE,
a.ACCOUNT,
a.CONTROLNO,
a.XYZ,
a.XYZREF
 from trans_tb as a inner join stocks_tb as b
on a.stockno = b.stockno ORDER BY a.TRANSDATE DESC"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds.TRANS_TB)
            AllTrans.TRANS_TBBindingSource.DataSource = ds.TRANS_TB.DefaultView
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub reporting(ByVal str As String)
        Try
            sqlcon.Open()
            Dim ds As New inventoryds
            ds.Clear()
            Dim da As New SqlDataAdapter
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds.STOCKS_TB)
            Form8.STOCKS_TBBindingSource.DataSource = ds.STOCKS_TB.DefaultView
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub anualreporting(ByVal str As String, ByVal anualreporting As String)
        Try
            sqlcon.Open()
            sqlcmd = New SqlCommand(anualreporting, sqlcon)
            sqlcmd.ExecuteNonQuery()

            Form2.ProgressBar1.Visible = True
            Form2.ProgressBar1.Maximum = Form2.mydummycombobox.Items.Count
            Form2.ProgressBar1.Value = 0
            For i As Integer = 0 To Form2.mydummycombobox.Items.Count - 1
                Dim s As String = Form2.mydummycombobox.Items(i).ToString
                Dim v As String = "
declare @totalneedtoorder as decimal(10,2)=(select sum(needtoorder) from stocks_tb where COLORBASED='" & s & "' and needtoorder > 0)

update stocks_tb set finalneedtoorder = needtoorder+(isnull(@totalneedtoorder,0)) where stockno = '" & s & "'

"
                sqlcmd = New SqlCommand(v, sqlcon)
                sqlcmd.ExecuteNonQuery()
                Form2.ProgressBar1.Value += 1
            Next
            If Form2.ProgressBar1.Value = Form2.ProgressBar1.Maximum Then
                MessageBox.Show("Complete", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Form2.ProgressBar1.Visible = False
            End If


            Dim ds As New inventoryds
            ds.Clear()
            Dim da As New SqlDataAdapter
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds.STOCKS_TB)
            Form7.STOCKS_TBBindingSource.DataSource = ds.STOCKS_TB.DefaultView
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub loaddummies()
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            ds.Clear()
            Dim bs As New BindingSource
            Dim str As String = "select * from stocks_tb"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.mydummyDataGridView1.DataSource = bs
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub calculateanualconsumption(ByVal stockno As String, ByVal myyear As String)
        Try
            sqlcon.Open()
            Dim find As String = "select * from consumptiontb where stockno = '" & stockno & "' and myyear = '" & myyear & "'"
            sqlcmd = New SqlCommand(find, sqlcon)
            Dim read As SqlDataReader = sqlcmd.ExecuteReader
            If read.HasRows = True Then
                read.Close()
                Dim str As String = "
declare @consumption as decimal(10,2)=(select sum(qty) from trans_tb where stockno='" & stockno & "' and transtype='Issue' and year(transdate)='" & myyear & "')
update consumptiontb set consumption=isnull(@consumption,0) where stockno='" & stockno & "' and myyear='" & myyear & "'
UPDATE STOCKS_TB SET consumption=isnull(@consumption,0) where stockno='" & stockno & "'"
                sqlcmd = New SqlCommand(str, sqlcon)
                sqlcmd.ExecuteNonQuery()

            Else
                read.Close()
                Dim str As String = "
declare @consumption as decimal(10,2)=(select sum(qty) from trans_tb where stockno='" & stockno & "' and transtype='Issue' and year(transdate)='" & myyear & "')
insert into consumptiontb
(stockno,consumption,myyear)values('" & stockno & "',isnull(@consumption,0),'" & myyear & "')
UPDATE STOCKS_TB SET consumption=isnull(@consumption,0) where stockno='" & stockno & "'
"
                sqlcmd = New SqlCommand(str, sqlcon)
                sqlcmd.ExecuteNonQuery()

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub

    Public Sub colorbased(ByVal colorb As String, ByVal stockno As String)
        Try
            sqlcon.Open()
            Dim str As String = "update stocks_tb set COLORBASED='" & colorb & "' where stockno = '" & stockno & "'"
            sqlcmd = New SqlCommand(str, sqlcon)
            sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub toorders(ByVal toorder As String, ByVal stockno As String)
        Try
            sqlcon.Open()
            Dim str As String = "update stocks_tb set toorder='" & toorder & "' where stockno = '" & stockno & "'"
            sqlcmd = New SqlCommand(str, sqlcon)
            sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub tofoils(ByVal tofoil As String, ByVal stockno As String)
        Try
            sqlcon.Open()
            Dim str As String = "update stocks_tb set tofoil='" & tofoil & "' where stockno = '" & stockno & "'"
            sqlcmd = New SqlCommand(str, sqlcon)
            sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub

    Public Sub login(ByVal username As String, ByVal password As String)
        Try
            sqlcon.Open()
            Dim da As New SqlDataAdapter
            Dim bs As New BindingSource
            Dim ds As New DataSet
            ds.Clear()
            Dim str As String = "select nickname,ACCTTYPE from account_tb where username COLLATE Latin1_General_CS_AS ='" & username & "' and password COLLATE Latin1_General_CS_AS =  '" & password & "'"
            sqlcmd = New SqlCommand(str, sqlcon)
            Dim read As SqlDataReader = sqlcmd.ExecuteReader
            If read.HasRows = True Then
                read.Close()
                da.SelectCommand = sqlcmd
                da.Fill(ds, "account_tb")
                bs.DataSource = ds
                bs.DataMember = "account_tb"
                Form1.Label1.DataBindings.Clear()
                Form1.Label1.DataBindings.Add("text", bs, "nickname")
                Form1.Label2.DataBindings.Clear()
                Form1.Label2.DataBindings.Add("text", bs, "ACCTTYPE")
                Form9.KryptonLabel2.DataBindings.Clear()
                Form9.KryptonLabel2.DataBindings.Add("text", bs, "ACCTTYPE")
                Dim scolumns As String
                Dim tcolumns As String
                Dim cs As String = "select stockscolumns,transcolumns from account_tb where username COLLATE Latin1_General_CS_AS ='" & username & "' and password COLLATE Latin1_General_CS_AS =  '" & password & "'"
                sqlcmd = New SqlCommand(cs, sqlcon)
                Dim a As SqlDataReader = sqlcmd.ExecuteReader
                While a.Read
                    scolumns = a(0).ToString
                    tcolumns = a(1).ToString
                End While
                a.Close()

                If scolumns.Contains("stockno") Then
                    managecolumns.Stockno.Checked = True
                Else
                    managecolumns.Stockno.Checked = False
                End If
                If scolumns.Contains("supplier") Then
                    managecolumns.supplier.Checked = True
                Else
                    managecolumns.supplier.Checked = False
                End If
                If scolumns.Contains("costhead") Then
                    managecolumns.costhead.Checked = True
                Else
                    managecolumns.costhead.Checked = False
                End If
                If scolumns.Contains("typecolor") Then
                    managecolumns.typecolor.Checked = True
                Else
                    managecolumns.typecolor.Checked = False
                End If
                If scolumns.Contains("articleno") Then
                    managecolumns.articleno.Checked = True
                Else
                    managecolumns.articleno.Checked = False
                End If
                If scolumns.Contains("disc") Then
                    managecolumns.disc.Checked = True
                Else
                    managecolumns.disc.Checked = False
                End If
                If scolumns.Contains("unitprice") Then
                    managecolumns.unitprice.Checked = True
                Else
                    managecolumns.unitprice.Checked = False
                End If
                If scolumns.Contains("physical") Then
                    managecolumns.physical.Checked = True
                Else
                    managecolumns.physical.Checked = False
                End If
                If scolumns.Contains("allocation") Then
                    managecolumns.Allocation.Checked = True
                Else
                    managecolumns.Allocation.Checked = False
                End If
                If scolumns.Contains("free") Then
                    managecolumns.Free.Checked = True
                Else
                    managecolumns.Free.Checked = False
                End If
                If scolumns.Contains("stockorder") Then
                    managecolumns.stockorder.Checked = True
                Else
                    managecolumns.stockorder.Checked = False
                End If
                If scolumns.Contains("minimum") Then
                    managecolumns.minimum.Checked = True
                Else
                    managecolumns.minimum.Checked = False
                End If
                If scolumns.Contains("issue") Then
                    managecolumns.issue.Checked = True
                Else
                    managecolumns.issue.Checked = False
                End If
                If scolumns.Contains("status") Then
                    managecolumns.status.Checked = True
                Else
                    managecolumns.status.Checked = False
                End If
                If scolumns.Contains("phasedout") Then
                    managecolumns.phasedout.Checked = True
                Else
                    managecolumns.phasedout.Checked = False
                End If
                If scolumns.Contains("basedcolor") Then
                    managecolumns.COLORBASED.Checked = True
                Else
                    managecolumns.COLORBASED.Checked = False
                End If
                If scolumns.Contains("inputted") Then
                    managecolumns.INPUTTED.Checked = True
                Else
                    managecolumns.INPUTTED.Checked = False
                End If
                If scolumns.Contains("toorder") Then
                    managecolumns.TOORDER.Checked = True
                Else
                    managecolumns.TOORDER.Checked = False
                End If
                If scolumns.Contains("tofoil") Then
                    managecolumns.TOFOIL.Checked = True
                Else
                    managecolumns.TOFOIL.Checked = False
                End If
                If scolumns.Contains("balalloc") Then
                    managecolumns.balalloc.Checked = True
                Else
                    managecolumns.balalloc.Checked = False
                End If
                If scolumns.Contains("physical2") Then
                    managecolumns.physical2.Checked = True
                Else
                    managecolumns.physical2.Checked = False
                End If
                If scolumns.Contains("weight") Then
                    managecolumns.WEIGHT.Checked = True
                Else
                    managecolumns.WEIGHT.Checked = False
                End If
                If scolumns.Contains("xrate") Then
                    managecolumns.XRATE.Checked = True
                Else
                    managecolumns.XRATE.Checked = False
                End If
                If scolumns.Contains("netamount") Then
                    managecolumns.NETAMOUNT.Checked = True
                Else
                    managecolumns.NETAMOUNT.Checked = False
                End If
                If scolumns.Contains("consumption") Then
                    managecolumns.CONSUMPTION.Checked = True
                Else
                    managecolumns.CONSUMPTION.Checked = False
                End If
                If scolumns.Contains("mylocation") Then
                    managecolumns.mylocation.Checked = True
                Else
                    managecolumns.mylocation.Checked = False
                End If
                If scolumns.Contains("header") Then
                    managecolumns.header.Checked = True
                Else
                    managecolumns.header.Checked = False
                End If


                'transaction
                If tcolumns.Contains("transno") Then
                    managecolumns.transno.Checked = True
                Else
                    managecolumns.transno.Checked = False
                End If
                If tcolumns.Contains("stockno") Then
                    managecolumns.tstockno.Checked = True
                Else
                    managecolumns.tstockno.Checked = False
                End If
                If tcolumns.Contains("costhead") Then
                    managecolumns.tcosthead.Checked = True
                Else
                    managecolumns.tcosthead.Checked = False
                End If
                If tcolumns.Contains("typecolor") Then
                    managecolumns.ttypecolor.Checked = True
                Else
                    managecolumns.ttypecolor.Checked = False
                End If
                If tcolumns.Contains("articleno") Then
                    managecolumns.tarticleno.Checked = True
                Else
                    managecolumns.tarticleno.Checked = False
                End If
                If tcolumns.Contains("transtype") Then
                    managecolumns.transtype.Checked = True
                Else
                    managecolumns.transtype.Checked = False
                End If
                If tcolumns.Contains("transdate") Then
                    managecolumns.transdate.Checked = True
                Else
                    managecolumns.transdate.Checked = False
                End If
                If tcolumns.Contains("duedate") Then
                    managecolumns.duedate.Checked = True
                Else
                    managecolumns.duedate.Checked = False
                End If
                If tcolumns.Contains("qty") Then
                    managecolumns.qty.Checked = True
                Else
                    managecolumns.qty.Checked = False
                End If
                If tcolumns.Contains("reference") Then
                    managecolumns.reference.Checked = True
                Else
                    managecolumns.reference.Checked = False
                End If
                If tcolumns.Contains("account") Then
                    managecolumns.account.Checked = True
                Else
                    managecolumns.account.Checked = False
                End If
                If tcolumns.Contains("controlno") Then
                    managecolumns.controlno.Checked = True
                Else
                    managecolumns.controlno.Checked = False
                End If
                If tcolumns.Contains("excess") Then
                    managecolumns.excess.Checked = True
                Else
                    managecolumns.excess.Checked = False
                End If
                If tcolumns.Contains("remarks") Then
                    managecolumns.remarks.Checked = True
                Else
                    managecolumns.remarks.Checked = False
                End If
                If tcolumns.Contains("ufactor") Then
                    managecolumns.Ufactor.Checked = True
                Else
                    managecolumns.Ufactor.Checked = False
                End If
                If tcolumns.Contains("checker") Then
                    managecolumns.Checker.Checked = True
                Else
                    managecolumns.Checker.Checked = False
                End If
                If tcolumns.Contains("unitprice") Then
                    managecolumns.tunitprice.Checked = True
                Else
                    managecolumns.tunitprice.Checked = False
                End If
                If tcolumns.Contains("Currency") Then
                    managecolumns.Currency.Checked = True
                Else
                    managecolumns.Currency.Checked = False
                End If
                If tcolumns.Contains("xrate") Then
                    managecolumns.txrate.Checked = True
                Else
                    managecolumns.txrate.Checked = False
                End If
                If tcolumns.Contains("netamount") Then
                    managecolumns.tnetamount.Checked = True
                Else
                    managecolumns.tnetamount.Checked = False
                End If
                If tcolumns.Contains("inputted") Then
                    managecolumns.tinputted.Checked = True
                Else
                    managecolumns.tinputted.Checked = False
                End If
                If tcolumns.Contains("disc") Then
                    managecolumns.tdisc.Checked = True
                Else
                    managecolumns.tdisc.Checked = False
                End If
                If tcolumns.Contains("adjustmentqty") Then
                    managecolumns.adjqty.Checked = True
                Else
                    managecolumns.adjqty.Checked = False
                End If

                Form1.Show()
                Form9.Hide()
            Else
                MsgBox("try again!")
                read.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub newaccount(ByVal username As String, ByVal password As String, ByVal fullname As String, ByVal nickname As String, ByVal acctype As String)
        Try
            sqlcon.Open()
            Dim str As String = "select * from account_tb where nickname='" & nickname & "'"
            sqlcmd = New SqlCommand(str, sqlcon)
            Dim read As SqlDataReader = sqlcmd.ExecuteReader
            If read.HasRows = True Then
                read.Close()
                MessageBox.Show("nickname already exist , try another one", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                read.Close()
                Dim insert As String = "insert into account_tb (fullname,nickname,username,password,accttype)values('" & fullname & "','" & nickname & "','" & username & "','" & password & "','" & acctype & "')"
                sqlcmd = New SqlCommand(insert, sqlcon)
                sqlcmd.ExecuteNonQuery()
                MessageBox.Show("Saved", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub updateaccount(ByVal id As String, ByVal username As String, ByVal password As String, ByVal fullname As String, ByVal nickname As String, ByVal acctype As String)
        Try
            sqlcon.Open()
            Dim str As String = "select * from account_tb where nickname='" & nickname & "' and not id = '" & id & "'"
            sqlcmd = New SqlCommand(str, sqlcon)
            Dim read As SqlDataReader = sqlcmd.ExecuteReader
            If read.HasRows = True Then
                read.Close()
                MessageBox.Show("nickname already exist , try another one", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                read.Close()
                Dim insert As String = "update account_tb set fullname='" & fullname & "',
nickname='" & nickname & "',
username='" & username & "',
password='" & password & "',
accttype='" & acctype & "' where id = '" & id & "'"
                sqlcmd = New SqlCommand(insert, sqlcon)
                sqlcmd.ExecuteNonQuery()
                MessageBox.Show("Updated", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub getreportheader(ByVal supplier As String)
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            ds.Clear()
            Dim da As New SqlDataAdapter
            Dim bs As New BindingSource
            Dim str As String = "select distinct header from stocks_tb where supplier = '" & supplier & "' order by header asc"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.reportheader.DataSource = bs
            Form2.reportheader.DisplayMember = "header"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub getreportheader1()
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            ds.Clear()
            Dim da As New SqlDataAdapter
            Dim bs As New BindingSource
            Dim str As String = "select distinct header from stocks_tb order by header asc"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.reportheader.DataSource = bs
            Form2.reportheader.DisplayMember = "header"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub getreportcosthead(ByVal supplier As String, ByVal header As String)
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            ds.Clear()
            Dim da As New SqlDataAdapter
            Dim bs As New BindingSource
            Dim str As String = "select distinct costhead from stocks_tb where supplier='" & supplier & "' and header='" & header & "' order by costhead asc"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.reportcosthead.DataSource = bs
            Form2.reportcosthead.DisplayMember = "costhead"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub getreportcosthead1()
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            ds.Clear()
            Dim da As New SqlDataAdapter
            Dim bs As New BindingSource
            Dim str As String = "select distinct costhead from stocks_tb order by costhead asc"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.reportcosthead.DataSource = bs
            Form2.reportcosthead.DisplayMember = "costhead"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub getreportcosthead2(ByVal supplier As String)
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            ds.Clear()
            Dim da As New SqlDataAdapter
            Dim bs As New BindingSource
            Dim str As String = "select distinct costhead from stocks_tb where supplier='" & supplier & "' order by costhead asc"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.reportcosthead.DataSource = bs
            Form2.reportcosthead.DisplayMember = "costhead"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub getreportcosthead3(ByVal header As String)
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            ds.Clear()
            Dim da As New SqlDataAdapter
            Dim bs As New BindingSource
            Dim str As String = "select distinct costhead from stocks_tb where header='" & header & "' order by costhead asc"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.reportcosthead.DataSource = bs
            Form2.reportcosthead.DisplayMember = "costhead"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub getreporttypecolor(ByVal supplier As String, ByVal header As String, ByVal costhead As String)
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            ds.Clear()
            Dim da As New SqlDataAdapter
            Dim bs As New BindingSource
            Dim str As String = "select distinct typecolor from stocks_tb where supplier='" & supplier & "' and header='" & header & "' and costhead = '" & costhead & "' order by typecolor asc"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.reporttypecolor.DataSource = bs
            Form2.reporttypecolor.DisplayMember = "typecolor"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub getreporttypecolor1()
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            ds.Clear()
            Dim da As New SqlDataAdapter
            Dim bs As New BindingSource
            Dim str As String = "select distinct typecolor from stocks_tb order by typecolor asc"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.reporttypecolor.DataSource = bs
            Form2.reporttypecolor.DisplayMember = "typecolor"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub getreporttypecolor2(ByVal supplier As String)
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            ds.Clear()
            Dim da As New SqlDataAdapter
            Dim bs As New BindingSource
            Dim str As String = "select distinct typecolor from stocks_tb where supplier = '" & supplier & "' order by typecolor asc"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.reporttypecolor.DataSource = bs
            Form2.reporttypecolor.DisplayMember = "typecolor"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub getreporttypecolor3(ByVal header As String)
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            ds.Clear()
            Dim da As New SqlDataAdapter
            Dim bs As New BindingSource
            Dim str As String = "select distinct typecolor from stocks_tb where header = '" & header & "' order by typecolor asc"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.reporttypecolor.DataSource = bs
            Form2.reporttypecolor.DisplayMember = "typecolor"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub getreporttypecolor4(ByVal costhead As String)
        Try
            sqlcon.Open()
            Dim ds As New DataSet
            ds.Clear()
            Dim da As New SqlDataAdapter
            Dim bs As New BindingSource
            Dim str As String = "select distinct typecolor from stocks_tb where costhead = '" & costhead & "' order by typecolor asc"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.reporttypecolor.DataSource = bs
            Form2.reporttypecolor.DisplayMember = "typecolor"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub movetoinput(ByVal stockno As String)
        Try
            sqlcon.Close()
            sqlcon.Open()
            Dim ds As New DataSet
            ds.Clear()
            Dim bs As New BindingSource

            Dim str As String = "select * from stocks_tb where stockno = '" & stockno & "'"
            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds, "stocks_tb")
            bs.DataSource = ds
            bs.DataMember = "stocks_tb"
            Form2.transstockno.DataBindings.Clear()
            Form2.transcosthead.DataBindings.Clear()
            Form2.transtypecolor.DataBindings.Clear()
            Form2.transarticleno.DataBindings.Clear()
            Form2.transdescription.DataBindings.Clear()
            Form2.transphysical.DataBindings.Clear()
            Form2.transfree.DataBindings.Clear()
            Form2.unitprice.DataBindings.Clear()
            Form2.xrate.DataBindings.Clear()
            Form2.ufactor.DataBindings.Clear()
            Form2.disc.DataBindings.Clear()
            Form2.transstockno.DataBindings.Add("text", bs, "stockno")
            Form2.transcosthead.DataBindings.Add("text", bs, "costhead")
            Form2.transtypecolor.DataBindings.Add("text", bs, "typecolor")
            Form2.transarticleno.DataBindings.Add("text", bs, "articleno")
            Form2.transdescription.DataBindings.Add("text", bs, "description")
            Form2.transphysical.DataBindings.Add("text", bs, "physical")
            Form2.transfree.DataBindings.Add("text", bs, "free")
            Form2.unitprice.DataBindings.Add("text", bs, "unitprice")
            Form2.xrate.DataBindings.Add("text", bs, "xrate")
            Form2.ufactor.DataBindings.Add("text", bs, "UFACTOR")
            Form2.disc.DataBindings.Add("text", bs, "DISC")
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub loadmyreport(ByVal str As String)
        Try
            sqlcon.Open()
            Dim ds As New inventoryds
            ds.Clear()
            Dim da As New SqlDataAdapter

            sqlcmd = New SqlCommand(str, sqlcon)
            da.SelectCommand = sqlcmd
            da.Fill(ds.STOCKS_TB)
            accountinginventory.STOCKS_TBBindingSource.DataSource = ds.STOCKS_TB.DefaultView
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Public Sub managecols()
        Try
            'STOCKNO
            If managecolumns.Stockno.Checked = True Then
                Form2.stocksgridview.Columns("STOCKNO").Visible = True
            Else
                Form2.stocksgridview.Columns("STOCKNO").Visible = False
            End If
            If managecolumns.supplier.Checked = True Then
                Form2.stocksgridview.Columns("SUPPLIER").Visible = True
            Else
                Form2.stocksgridview.Columns("SUPPLIER").Visible = False
            End If
            If managecolumns.costhead.Checked = True Then
                Form2.stocksgridview.Columns("COSTHEAD").Visible = True
            Else
                Form2.stocksgridview.Columns("COSTHEAD").Visible = False
            End If
            If managecolumns.typecolor.Checked = True Then
                Form2.stocksgridview.Columns("TYPECOLOR").Visible = True
            Else
                Form2.stocksgridview.Columns("TYPECOLOR").Visible = False
            End If
            If managecolumns.articleno.Checked = True Then
                Form2.stocksgridview.Columns("ARTICLENO").Visible = True
            Else
                Form2.stocksgridview.Columns("ARTICLENO").Visible = False
            End If
            If managecolumns.disc.Checked = True Then
                Form2.stocksgridview.Columns("DISC").Visible = True
            Else
                Form2.stocksgridview.Columns("DISC").Visible = False
            End If
            If managecolumns.unitprice.Checked = True Then
                Form2.stocksgridview.Columns("UNITPRICE").Visible = True
            Else
                Form2.stocksgridview.Columns("UNITPRICE").Visible = False
            End If
            If managecolumns.physical.Checked = True Then
                Form2.stocksgridview.Columns("PHYSICAL").Visible = True
            Else
                Form2.stocksgridview.Columns("PHYSICAL").Visible = False
            End If
            If managecolumns.Allocation.Checked = True Then
                Form2.stocksgridview.Columns("ALLOCATION").Visible = True
            Else
                Form2.stocksgridview.Columns("ALLOCATION").Visible = False
            End If
            If managecolumns.Free.Checked = True Then
                Form2.stocksgridview.Columns("FREE").Visible = True
            Else
                Form2.stocksgridview.Columns("FREE").Visible = False
            End If
            If managecolumns.stockorder.Checked = True Then
                Form2.stocksgridview.Columns("STOCKORDER").Visible = True
            Else
                Form2.stocksgridview.Columns("STOCKORDER").Visible = False
            End If
            If managecolumns.minimum.Checked = True Then
                Form2.stocksgridview.Columns("MINIMUM").Visible = True
            Else
                Form2.stocksgridview.Columns("MINIMUM").Visible = False
            End If
            If managecolumns.issue.Checked = True Then
                Form2.stocksgridview.Columns("ISSUE").Visible = True
            Else
                Form2.stocksgridview.Columns("ISSUE").Visible = False
            End If
            If managecolumns.status.Checked = True Then
                Form2.stocksgridview.Columns("STATUS").Visible = True
            Else
                Form2.stocksgridview.Columns("STATUS").Visible = False
            End If
            If managecolumns.phasedout.Checked = True Then
                Form2.stocksgridview.Columns("PHASEDOUT").Visible = True
            Else
                Form2.stocksgridview.Columns("PHASEDOUT").Visible = False
            End If
            If managecolumns.COLORBASED.Checked = True Then
                Form2.stocksgridview.Columns("COLORBASED").Visible = True
            Else
                Form2.stocksgridview.Columns("COLORBASED").Visible = False
            End If
            If managecolumns.INPUTTED.Checked = True Then
                Form2.stocksgridview.Columns("INPUTTED").Visible = True
            Else
                Form2.stocksgridview.Columns("INPUTTED").Visible = False
            End If
            If managecolumns.TOORDER.Checked = True Then
                Form2.stocksgridview.Columns("TOORDER").Visible = True
            Else
                Form2.stocksgridview.Columns("TOORDER").Visible = False
            End If
            If managecolumns.TOFOIL.Checked = True Then
                Form2.stocksgridview.Columns("TOFOIL").Visible = True
            Else
                Form2.stocksgridview.Columns("TOFOIL").Visible = False
            End If
            If managecolumns.balalloc.Checked = True Then
                Form2.stocksgridview.Columns("BALALLOC").Visible = True
            Else
                Form2.stocksgridview.Columns("BALALLOC").Visible = False
            End If
            If managecolumns.physical2.Checked = True Then
                Form2.stocksgridview.Columns("PHYSICAL2").Visible = True
            Else
                Form2.stocksgridview.Columns("PHYSICAL2").Visible = False
            End If
            If managecolumns.WEIGHT.Checked = True Then
                Form2.stocksgridview.Columns("WEIGHT").Visible = True
            Else
                Form2.stocksgridview.Columns("WEIGHT").Visible = False
            End If
            If managecolumns.XRATE.Checked = True Then
                Form2.stocksgridview.Columns("XRATE").Visible = True
            Else
                Form2.stocksgridview.Columns("XRATE").Visible = False
            End If
            If managecolumns.NETAMOUNT.Checked = True Then
                Form2.stocksgridview.Columns("NETAMOUNT").Visible = True
            Else
                Form2.stocksgridview.Columns("NETAMOUNT").Visible = False
            End If
            If managecolumns.CONSUMPTION.Checked = True Then
                Form2.stocksgridview.Columns("CONSUMPTION").Visible = True
            Else
                Form2.stocksgridview.Columns("CONSUMPTION").Visible = False
            End If
            If managecolumns.mylocation.Checked = True Then
                Form2.stocksgridview.Columns("MYLOCATION").Visible = True
            Else
                Form2.stocksgridview.Columns("MYLOCATION").Visible = False
            End If
            If managecolumns.header.Checked = True Then
                Form2.stocksgridview.Columns("header").Visible = True
            Else
                Form2.stocksgridview.Columns("header").Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub tmanagecols()
        Try


            'transaction

            If managecolumns.transno.Checked = True Then
                Form2.transgridview.Columns("TRANSNO").Visible = True
            Else
                Form2.transgridview.Columns("TRANSNO").Visible = False
            End If
            If managecolumns.tstockno.Checked = True Then
                Form2.transgridview.Columns("STOCKNO").Visible = True
            Else
                Form2.transgridview.Columns("STOCKNO").Visible = False
            End If
            If managecolumns.tcosthead.Checked = True Then
                Form2.transgridview.Columns("COSTHEAD").Visible = True
            Else
                Form2.transgridview.Columns("COSTHEAD").Visible = False
            End If
            If managecolumns.ttypecolor.Checked = True Then
                Form2.transgridview.Columns("typecolor").Visible = True
            Else
                Form2.transgridview.Columns("typecolor").Visible = False
            End If
            If managecolumns.tarticleno.Checked = True Then
                Form2.transgridview.Columns("articleno").Visible = True
                Form2.transgridview.Columns("articleno").Frozen = True
            Else
                Form2.transgridview.Columns("articleno").Visible = False
                Form2.transgridview.Columns("articleno").Frozen = False
            End If
            If managecolumns.transtype.Checked = True Then
                Form2.transgridview.Columns("transtype").Visible = True
            Else
                Form2.transgridview.Columns("transtype").Visible = False
            End If
            If managecolumns.transtype.Checked = True Then
                Form2.transgridview.Columns("transtype").Visible = True
            Else
                Form2.transgridview.Columns("transtype").Visible = False
            End If
            If managecolumns.transdate.Checked = True Then
                Form2.transgridview.Columns("transdate").Visible = True
            Else
                Form2.transgridview.Columns("transdate").Visible = False
            End If
            If managecolumns.duedate.Checked = True Then
                Form2.transgridview.Columns("duedate").Visible = True
            Else
                Form2.transgridview.Columns("duedate").Visible = False
            End If
            If managecolumns.qty.Checked = True Then
                Form2.transgridview.Columns("qty").Visible = True
            Else
                Form2.transgridview.Columns("qty").Visible = False
            End If
            If managecolumns.reference.Checked = True Then
                Form2.transgridview.Columns("reference").Visible = True
            Else
                Form2.transgridview.Columns("reference").Visible = False
            End If
            If managecolumns.account.Checked = True Then
                Form2.transgridview.Columns("account").Visible = True
            Else
                Form2.transgridview.Columns("account").Visible = False
            End If
            If managecolumns.controlno.Checked = True Then
                Form2.transgridview.Columns("controlno").Visible = True
            Else
                Form2.transgridview.Columns("controlno").Visible = False
            End If
            If managecolumns.excess.Checked = True Then
                Form2.transgridview.Columns("excess").Visible = True
            Else
                Form2.transgridview.Columns("excess").Visible = False
            End If
            If managecolumns.remarks.Checked = True Then
                Form2.transgridview.Columns("remarks").Visible = True
            Else
                Form2.transgridview.Columns("remarks").Visible = False
            End If
            If managecolumns.Ufactor.Checked = True Then
                Form2.transgridview.Columns("ufactor").Visible = True
            Else
                Form2.transgridview.Columns("ufactor").Visible = False
            End If
            If managecolumns.Checker.Checked = True Then
                Form2.transgridview.Columns("checker").Visible = True
            Else
                Form2.transgridview.Columns("checker").Visible = False
            End If
            If managecolumns.tunitprice.Checked = True Then
                Form2.transgridview.Columns("unitprice").Visible = True
            Else
                Form2.transgridview.Columns("unitprice").Visible = False
            End If
            If managecolumns.Currency.Checked = True Then
                Form2.transgridview.Columns("Currency").Visible = True
            Else
                Form2.transgridview.Columns("Currency").Visible = False
            End If
            If managecolumns.txrate.Checked = True Then
                Form2.transgridview.Columns("xrate").Visible = True
            Else
                Form2.transgridview.Columns("xrate").Visible = False
            End If
            If managecolumns.tnetamount.Checked = True Then
                Form2.transgridview.Columns("netamount").Visible = True
            Else
                Form2.transgridview.Columns("netamount").Visible = False
            End If
            If managecolumns.tinputted.Checked = True Then
                Form2.transgridview.Columns("inputted").Visible = True
            Else
                Form2.transgridview.Columns("inputted").Visible = False
            End If
            If managecolumns.tdisc.Checked = True Then
                Form2.transgridview.Columns("disc").Visible = True
            Else
                Form2.transgridview.Columns("disc").Visible = False
            End If
            If managecolumns.adjqty.Checked = True Then
                Form2.transgridview.Columns("adjustmentqty").Visible = True
            Else
                Form2.transgridview.Columns("adjustmentqty").Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

End Class
Imports System.Data.SqlClient
Public Class managecolumns
    Dim sql As New sql
    Private Sub KryptonButton1_Click(sender As Object, e As EventArgs) Handles KryptonButton1.Click
        stockcol()
        transcol()
        MsgBox("Saved")
    End Sub
    Public Sub stockcol()
        Dim colmns As String
        Dim stockno1 As String
        If Stockno.Checked = True Then
            stockno1 = "stockno "
        Else
            stockno1 = " "
        End If
        Dim supplier1 As String
        If supplier.Checked = True Then
            supplier1 = "supplier "
        Else
            supplier1 = " "
        End If
        Dim costhead1 As String
        If costhead.Checked = True Then
            costhead1 = "costhead "
        Else
            costhead1 = " "
        End If
        Dim typecolor1 As String
        If typecolor.Checked = True Then
            typecolor1 = "typecolor "
        Else
            typecolor1 = " "
        End If
        Dim articleno1 As String
        If articleno.Checked = True Then
            articleno1 = "articleno "
        Else
            articleno1 = " "
        End If
        Dim discount1 As String
        If disc.Checked = True Then
            discount1 = "disc "
        Else
            discount1 = " "
        End If
        Dim unitprice1 As String
        If unitprice.Checked = True Then
            unitprice1 = "unitprice "
        Else
            unitprice1 = " "
        End If
        Dim physical1 As String
        If physical.Checked = True Then
            physical1 = "physical "
        Else
            physical1 = " "
        End If
        Dim allocation1 As String
        If Allocation.Checked = True Then
            allocation1 = "allocation "
        Else
            allocation1 = " "
        End If
        Dim free1 As String
        If Free.Checked = True Then
            free1 = "free "
        Else
            free1 = " "
        End If
        Dim stockorder1 As String
        If stockorder.Checked = True Then
            stockorder1 = "stockorder "
        Else
            stockorder1 = " "
        End If
        Dim minimum1 As String
        If minimum.Checked = True Then
            minimum1 = "minimum "
        Else
            minimum1 = " "
        End If
        Dim issue1 As String
        If issue.Checked = True Then
            issue1 = "issue "
        Else
            issue1 = " "
        End If
        Dim status1 As String
        If status.Checked = True Then
            status1 = "status "
        Else
            status1 = " "
        End If
        Dim phasedout1 As String
        If phasedout.Checked = True Then
            phasedout1 = "phasedout "
        Else
            phasedout1 = " "
        End If
        Dim basedcolor1 As String
        If COLORBASED.Checked = True Then
            basedcolor1 = "basedcolor "
        Else
            basedcolor1 = " "
        End If
        Dim inputted1 As String
        If INPUTTED.Checked = True Then
            inputted1 = "inputted "
        Else
            inputted1 = " "
        End If
        Dim toorder1 As String
        If TOORDER.Checked = True Then
            toorder1 = "toorder "
        Else
            toorder1 = " "
        End If
        Dim tofoil1 As String
        If TOFOIL.Checked = True Then
            tofoil1 = "tofoil "
        Else
            tofoil1 = " "
        End If
        Dim balalloc1 As String
        If balalloc.Checked = True Then
            balalloc1 = "balalloc "
        Else
            balalloc1 = " "
        End If
        Dim physical21 As String
        If physical2.Checked = True Then
            physical21 = "physical2 "
        Else
            physical21 = " "
        End If
        Dim weight1 As String
        If WEIGHT.Checked = True Then
            weight1 = "weight "
        Else
            weight1 = " "
        End If
        Dim xrate1 As String
        If XRATE.Checked = True Then
            xrate1 = "xrate "
        Else
            xrate1 = " "
        End If
        Dim netamount1 As String
        If NETAMOUNT.Checked = True Then
            netamount1 = "netamount "
        Else
            netamount1 = " "
        End If
        Dim consumption1 As String
        If CONSUMPTION.Checked = True Then
            consumption1 = "consumption "
        Else
            consumption1 = " "
        End If
        Dim mylocation1 As String
        If mylocation.Checked = True Then
            mylocation1 = "mylocation "
        Else
            mylocation1 = " "
        End If
        Dim header1 As String
        If header.Checked = True Then
            header1 = "header "
        Else
            header1 = " "
        End If
        colmns = stockno1 + supplier1 +
            costhead1 + typecolor1 + articleno1 +
            discount1 + unitprice1 + physical1 +
            allocation1 + free1 + stockorder1 +
            minimum1 + issue1 + status1 + phasedout1 +
            basedcolor1 + inputted1 + toorder1 + tofoil1 +
            balalloc1 + physical21 + weight1 + xrate1 +
            netamount1 + consumption1 + mylocation1 + header1
        colmns = Trim(colmns)
        sql.managecols()

        Try
            sql.sqlcon.Open()
            Dim str As String = "update account_tb set stockscolumns='" & colmns & "' where nickname='" & Form1.Label1.Text & "'"
            Dim sqlcmd As New SqlCommand
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            sqlcmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Public Sub transcol()
        Dim colmns As String
        Dim transno1 As String
        If transno.Checked = True Then
            transno1 = "transno "
        Else
            transno1 = " "
        End If
        Dim tstockno1 As String
        If tstockno.Checked = True Then
            tstockno1 = "stockno "
        Else
            tstockno1 = " "
        End If
        Dim costhead1 As String
        If tcosthead.Checked = True Then
            costhead1 = "costhead "
        Else
            costhead1 = " "
        End If
        Dim typecolor1 As String
        If ttypecolor.Checked = True Then
            typecolor1 = "typecolor "
        Else
            typecolor1 = " "
        End If
        Dim articleno1 As String
        If tarticleno.Checked = True Then
            articleno1 = "articleno "
        Else
            articleno1 = " "
        End If
        Dim transtype1 As String
        If transtype.Checked = True Then
            transtype1 = "transtype "
        Else
            transtype1 = " "
        End If
        Dim transdate1 As String
        If transdate.Checked = True Then
            transdate1 = "transdate "
        Else
            transdate1 = " "
        End If
        Dim duedate1 As String
        If duedate.Checked = True Then
            duedate1 = "duedate "
        Else
            duedate1 = " "
        End If
        Dim qty1 As String
        If qty.Checked = True Then
            qty1 = "qty "
        Else
            qty1 = " "
        End If
        Dim reference1 As String
        If reference.Checked = True Then
            reference1 = "reference "
        Else
            reference1 = " "
        End If
        Dim account1 As String
        If account.Checked = True Then
            account1 = "account "
        Else
            account1 = " "
        End If
        Dim controlno1 As String
        If controlno.Checked = True Then
            controlno1 = "controlno "
        Else
            controlno1 = " "
        End If
        Dim excess1 As String
        If excess.Checked = True Then
            excess1 = "excess "
        Else
            excess1 = " "
        End If
        Dim remarks1 As String
        If remarks.Checked = True Then
            remarks1 = "remarks "
        Else
            remarks1 = " "
        End If
        Dim ufactors1 As String
        If Ufactor.Checked = True Then
            ufactors1 = "ufactor "
        Else
            ufactors1 = " "
        End If
        Dim checker1 As String
        If Checker.Checked = True Then
            checker1 = "checker "
        Else
            checker1 = " "
        End If
        Dim unitprice1 As String
        If tunitprice.Checked = True Then
            unitprice1 = "unitprice "
        Else
            unitprice1 = " "
        End If
        Dim Currency1 As String
        If Currency.Checked = True Then
            Currency1 = "Currency "
        Else
            Currency1 = " "
        End If
        Dim txrate1 As String
        If txrate.Checked = True Then
            txrate1 = "xrate "
        Else
            txrate1 = " "
        End If
        Dim netamount1 As String
        If tnetamount.Checked = True Then
            netamount1 = "netamount "
        Else
            netamount1 = " "
        End If
        Dim inputted1 As String
        If tinputted.Checked = True Then
            inputted1 = "inputted "
        Else
            inputted1 = " "
        End If
        Dim disc1 As String
        If tdisc.Checked = True Then
            disc1 = "disc "
        Else
            disc1 = " "
        End If
        Dim adjremarks1 As String
        If adjqty.Checked = True Then
            adjremarks1 = "adjustmentqty "
        Else
            adjremarks1 = " "
        End If
        colmns = transno1 + tstockno1 + costhead1 +
            typecolor1 + articleno1 + transtype1 +
            transdate1 + duedate1 + qty1 + reference1 +
            account1 + controlno1 + excess1 + remarks1 +
            ufactors1 + checker1 + unitprice1 + Currency1 +
            txrate1 + netamount1 + inputted1 + disc1 + adjremarks1
        colmns = Trim(colmns)

        sql.tmanagecols()
        Try
            sql.sqlcon.Open()
            Dim str As String = "update account_tb set transcolumns='" & colmns & "' where nickname='" & Form1.Label1.Text & "'"
            Dim sqlcmd As New SqlCommand
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            sqlcmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Private Sub KryptonButton2_Click(sender As Object, e As EventArgs) Handles KryptonButton2.Click
        closeme()
        Me.Close()
    End Sub
    Public Sub closeme()
        Try
            sql.sqlcon.Open()
            Dim str As String = "select stockscolumns,transcolumns from account_tb where nickname='" & Form1.Label1.Text & "'"
            Dim sqlcmd As New SqlCommand
            sqlcmd = New SqlCommand(str, sql.sqlcon)
            Dim scolumns As String
            Dim tcolumns As String
            Dim read As SqlDataReader = sqlcmd.ExecuteReader
            While read.Read
                scolumns = read(0).ToString
                tcolumns = read(1).ToString
            End While
            read.Close()

            If scolumns.Contains("stockno") Then
                Stockno.Checked = True
            Else
                Stockno.Checked = False
            End If
            If scolumns.Contains("supplier") Then
                supplier.Checked = True
            Else
                supplier.Checked = False
            End If
            If scolumns.Contains("costhead") Then
                costhead.Checked = True
            Else
                costhead.Checked = False
            End If
            If scolumns.Contains("typecolor") Then
                typecolor.Checked = True
            Else
                typecolor.Checked = False
            End If
            If scolumns.Contains("articleno") Then
                articleno.Checked = True
            Else
                articleno.Checked = False
            End If
            If scolumns.Contains("disc") Then
                disc.Checked = True
            Else
                disc.Checked = False
            End If
            If scolumns.Contains("unitprice") Then
                unitprice.Checked = True
            Else
                unitprice.Checked = False
            End If
            If scolumns.Contains("physical") Then
                physical.Checked = True
            Else
                physical.Checked = False
            End If
            If scolumns.Contains("allocation") Then
                Allocation.Checked = True
            Else
                Allocation.Checked = False
            End If
            If scolumns.Contains("free") Then
                Free.Checked = True
            Else
                Free.Checked = False
            End If
            If scolumns.Contains("stockorder") Then
                stockorder.Checked = True
            Else
                stockorder.Checked = False
            End If
            If scolumns.Contains("minimum") Then
                minimum.Checked = True
            Else
                minimum.Checked = False
            End If
            If scolumns.Contains("issue") Then
                issue.Checked = True
            Else
                issue.Checked = False
            End If
            If scolumns.Contains("status") Then
                status.Checked = True
            Else
                status.Checked = False
            End If
            If scolumns.Contains("phasedout") Then
                phasedout.Checked = True
            Else
                phasedout.Checked = False
            End If
            If scolumns.Contains("basedcolor") Then
                COLORBASED.Checked = True
            Else
                COLORBASED.Checked = False
            End If
            If scolumns.Contains("inputted") Then
                INPUTTED.Checked = True
            Else
                INPUTTED.Checked = False
            End If
            If scolumns.Contains("toorder") Then
                TOORDER.Checked = True
            Else
                TOORDER.Checked = False
            End If
            If scolumns.Contains("tofoil") Then
                TOFOIL.Checked = True
            Else
                TOFOIL.Checked = False
            End If
            If scolumns.Contains("balalloc") Then
                balalloc.Checked = True
            Else
                balalloc.Checked = False
            End If
            If scolumns.Contains("physical2") Then
                physical2.Checked = True
            Else
                physical2.Checked = False
            End If
            If scolumns.Contains("weight") Then
                WEIGHT.Checked = True
            Else
                WEIGHT.Checked = False
            End If
            If scolumns.Contains("xrate") Then
                XRATE.Checked = True
            Else
                XRATE.Checked = False
            End If
            If scolumns.Contains("netamount") Then
                NETAMOUNT.Checked = True
            Else
                NETAMOUNT.Checked = False
            End If
            If scolumns.Contains("consumption") Then
                CONSUMPTION.Checked = True
            Else
                CONSUMPTION.Checked = False
            End If
            If scolumns.Contains("mylocation") Then
                mylocation.Checked = True
            Else
                mylocation.Checked = False
            End If
            If scolumns.Contains("header") Then
                header.Checked = True
            Else
                header.Checked = False
            End If


            'transaction
            If tcolumns.Contains("transno") Then
                transno.Checked = True
            Else
                transno.Checked = False
            End If
            If tcolumns.Contains("stockno") Then
                tstockno.Checked = True
            Else
                tstockno.Checked = False
            End If
            If tcolumns.Contains("costhead") Then
                tcosthead.Checked = True
            Else
                tcosthead.Checked = False
            End If
            If tcolumns.Contains("typecolor") Then
                ttypecolor.Checked = True
            Else
                ttypecolor.Checked = False
            End If
            If tcolumns.Contains("articleno") Then
                tarticleno.Checked = True
            Else
                tarticleno.Checked = False
            End If
            If tcolumns.Contains("transtype") Then
                transtype.Checked = True
            Else
                transtype.Checked = False
            End If
            If tcolumns.Contains("transdate") Then
                transdate.Checked = True
            Else
                transdate.Checked = False
            End If
            If tcolumns.Contains("duedate") Then
                duedate.Checked = True
            Else
                duedate.Checked = False
            End If
            If tcolumns.Contains("qty") Then
                qty.Checked = True
            Else
                qty.Checked = False
            End If
            If tcolumns.Contains("reference") Then
                reference.Checked = True
            Else
                reference.Checked = False
            End If
            If tcolumns.Contains("account") Then
                account.Checked = True
            Else
                account.Checked = False
            End If
            If tcolumns.Contains("controlno") Then
                controlno.Checked = True
            Else
                controlno.Checked = False
            End If
            If tcolumns.Contains("excess") Then
                excess.Checked = True
            Else
                excess.Checked = False
            End If
            If tcolumns.Contains("remarks") Then
                remarks.Checked = True
            Else
                remarks.Checked = False
            End If
            If tcolumns.Contains("ufactor") Then
                Ufactor.Checked = True
            Else
                Ufactor.Checked = False
            End If
            If tcolumns.Contains("checker") Then
                Checker.Checked = True
            Else
                Checker.Checked = False
            End If
            If tcolumns.Contains("unitprice") Then
                tunitprice.Checked = True
            Else
                tunitprice.Checked = False
            End If
            If tcolumns.Contains("Currency") Then
                Currency.Checked = True
            Else
                Currency.Checked = False
            End If
            If tcolumns.Contains("xrate") Then
                txrate.Checked = True
            Else
                txrate.Checked = False
            End If
            If tcolumns.Contains("netamount") Then
                tnetamount.Checked = True
            Else
                tnetamount.Checked = False
            End If
            If tcolumns.Contains("inputted") Then
                tinputted.Checked = True
            Else
                tinputted.Checked = False
            End If
            If tcolumns.Contains("disc") Then
                tdisc.Checked = True
            Else
                tdisc.Checked = False
            End If
            If tcolumns.Contains("adjustmentqty") Then
                adjqty.Checked = True
            Else
                adjqty.Checked = False
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sql.sqlcon.Close()
        End Try
    End Sub

    Private Sub managecolumns_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        closeme()
    End Sub

    Private Sub managecolumns_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
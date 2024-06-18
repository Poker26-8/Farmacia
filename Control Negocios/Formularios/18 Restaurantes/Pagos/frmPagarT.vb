Public Class frmPagarT

    Dim focoforma As Integer = 0
    Dim forma As String = ""
    Dim importe As Double = 0

    Dim importev As Double = 0
    Dim propina As Double = 0
    Dim totales As Double = 0
    Dim resta As Double = 0
    Dim restatotal As Double = 0
    Private Sub btnpagar_Click(sender As Object, e As EventArgs) Handles btnpagar.Click
        MsgBox("canciones pa llorar")
    End Sub

    Private Sub frmPagarT_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            grdPagos.Rows.Add("EFECTIVO", "0.00", "0.00", "0.00")
            grdPagos.Rows.Add("VISA", "0.00", "0.00", "0.00")
            grdPagos.Rows.Add("MASTERCARD", "0.00", "0.00", "0.00")
            grdPagos.Rows.Add("AMERICAN EXPRESS", "0.00", "0.00", "0.00")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmPagarT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = ChrW(Keys.A) Then
            btnpagar.PerformClick()
        End If

    End Sub



    Private Sub btnEfectivo_Click(sender As Object, e As EventArgs) Handles btnEfectivo.Click
        focoforma = 1
    End Sub

    Private Sub btnVisa_Click(sender As Object, e As EventArgs) Handles btnVisa.Click
        focoforma = 2
    End Sub

    Private Sub btnMaster_Click(sender As Object, e As EventArgs) Handles btnMaster.Click
        focoforma = 3
    End Sub

    Private Sub btnAmerican_Click(sender As Object, e As EventArgs) Handles btnAmerican.Click
        focoforma = 4
    End Sub

    Private Sub btnPropina_Click(sender As Object, e As EventArgs) Handles btnPropina.Click
        focoforma = 5
    End Sub

    Private Sub grdPagos_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles grdPagos.CellEnter
        Dim elda As Integer = grdPagos.CurrentRow.Index
        Dim celda As DataGridViewCellEventArgs = e


        If focoforma = 1 Then
            forma = grdPagos.Rows(elda).Cells(0).Value.ToString
            importe = grdPagos.Rows(elda).Cells(1).Value.ToString
            If forma = "EFECTIVO" Then
                forma = ""
                importe = 0
            End If
        End If

        If focoforma = 2 Then
            forma = grdPagos.Rows(elda).Cells(0).Value.ToString
            importe = grdPagos.Rows(elda).Cells(1).Value.ToString
            If forma = "VISA" Then
                forma = ""
                importe = 0
            End If
        End If

        If focoforma = 3 Then
            forma = grdPagos.Rows(elda).Cells(0).Value.ToString
            importe = grdPagos.Rows(elda).Cells(1).Value.ToString
            If forma = "MASTERCARD" Then
                forma = ""
                importe = 0
            End If
        End If

        If focoforma = 4 Then
            forma = grdPagos.Rows(elda).Cells(0).Value.ToString
            importe = grdPagos.Rows(elda).Cells(1).Value.ToString
            If forma = "AMERICAN EXPRESS" Then
                forma = ""
                importe = 0
            End If
        End If

        If focoforma = 5 Then

        End If


        Dim importef As Double = 0
        Dim propina As Double = 0
        Dim totalf As Double = 0

        Dim totalimporte As Double = 0
        Dim totaltotal As Double = 0
        Dim totalpropina As Double = 0

        For deku As Integer = 0 To grdPagos.Rows.Count - 1
            If grdPagos.Rows(deku).Cells(1).Value > 0 Then

                If grdPagos.Rows(deku).Cells(0).Value.ToString = "EFECTIVO" Then

                    importef = grdPagos.Rows(deku).Cells(1).Value
                    propina = grdPagos.Rows(deku).Cells(2).Value

                    grdPagos.Rows(deku).Cells(3).Value = importef + propina

                    totalimporte = totalimporte + importef
                    totaltotal = totalimporte + totalf + propina
                    totalpropina = totalpropina + propina


                    lblimporte.Text = "0.00"
                    lblimporte.Text = FormatNumber(totalimporte, 2)
                    lbltotales.Text = "0.00"
                    lbltotales.Text = FormatNumber(totaltotal, 2)
                    lblpropina.Text = "0.00"
                    lblpropina.Text = FormatNumber(totalpropina, 2)
                End If

            End If
        Next


    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        Select Case focoforma
            Case Is = 1

        End Select
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        lblimporte.Text = "0.00"
        lblpropina.Text = "0.00"
        lbltotales.Text = "0.00"
        lblResta.Text = lblSubtotal.Text
    End Sub

    Private Sub lblimporte_TextChanged(sender As Object, e As EventArgs) Handles lblimporte.TextChanged
        resta = IIf(lblSubtotal.Text = "", 0, lblSubtotal.Text)
        totales = IIf(lbltotales.Text = "", 0, lbltotales.Text)

        restatotal = CDbl(resta) - CDbl(totales)
        lblResta.Text = FormatNumber(restatotal, 2)

    End Sub


End Class
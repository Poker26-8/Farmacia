﻿Public Class frmPagarT

    Dim focoforma As Integer = 0
    Dim forma As String = ""
    Dim importe As Double = 0

    Dim importev As Double = 0
    Dim propina As Double = 0
    Dim totales As Double = 0
    Dim resta As Double = 0
    Dim restatotal As Double = 0
    Dim pro As Integer = 0
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
        txtMontos.Focus.Equals(True)
    End Sub

    Private Sub btnVisa_Click(sender As Object, e As EventArgs) Handles btnVisa.Click
        focoforma = 2
        txtMontos.Focus.Equals(True)
    End Sub

    Private Sub btnMaster_Click(sender As Object, e As EventArgs) Handles btnMaster.Click
        focoforma = 3
        txtMontos.Focus.Equals(True)
    End Sub

    Private Sub btnAmerican_Click(sender As Object, e As EventArgs) Handles btnAmerican.Click
        focoforma = 4
        txtMontos.Focus.Equals(True)
    End Sub

    Private Sub btnPropina_Click(sender As Object, e As EventArgs) Handles btnPropina.Click
        pro = 1
        txtMontos.Focus.Equals(True)
    End Sub

    Private Sub grdPagos_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles grdPagos.CellEnter
        'Dim elda As Integer = grdPagos.CurrentRow.Index
        'Dim celda As DataGridViewCellEventArgs = e


        'If focoforma = 1 Then
        '    forma = grdPagos.Rows(elda).Cells(0).Value.ToString
        '    importe = grdPagos.Rows(elda).Cells(1).Value.ToString
        '    If forma = "EFECTIVO" Then
        '        forma = ""
        '        importe = 0
        '    End If
        'End If

        'If focoforma = 2 Then
        '    forma = grdPagos.Rows(elda).Cells(0).Value.ToString
        '    importe = grdPagos.Rows(elda).Cells(1).Value.ToString
        '    If forma = "VISA" Then
        '        forma = ""
        '        importe = 0
        '    End If
        'End If

        'If focoforma = 3 Then
        '    forma = grdPagos.Rows(elda).Cells(0).Value.ToString
        '    importe = grdPagos.Rows(elda).Cells(1).Value.ToString
        '    If forma = "MASTERCARD" Then
        '        forma = ""
        '        importe = 0
        '    End If
        'End If

        'If focoforma = 4 Then
        '    forma = grdPagos.Rows(elda).Cells(0).Value.ToString
        '    importe = grdPagos.Rows(elda).Cells(1).Value.ToString
        '    If forma = "AMERICAN EXPRESS" Then
        '        forma = ""
        '        importe = 0
        '    End If
        'End If

        'If focoforma = 5 Then

        'End If


        'Dim importef As Double = 0
        'Dim propina As Double = 0
        'Dim totalf As Double = 0

        'Dim totalimporte As Double = 0
        'Dim totaltotal As Double = 0
        'Dim totalpropina As Double = 0

        'For deku As Integer = 0 To grdPagos.Rows.Count - 1
        '    If grdPagos.Rows(deku).Cells(1).Value > 0 Then

        '        If grdPagos.Rows(deku).Cells(0).Value.ToString = "EFECTIVO" Then

        '            importef = grdPagos.Rows(deku).Cells(1).Value
        '            propina = grdPagos.Rows(deku).Cells(2).Value

        '            grdPagos.Rows(deku).Cells(3).Value = importef + propina

        '            totalimporte = totalimporte + importef
        '            totaltotal = totalimporte + totalf + propina
        '            totalpropina = totalpropina + propina

        '            lblimporte.Text = "0.00"
        '            lblimporte.Text = FormatNumber(totalimporte, 2)
        '            lblpropina.Text = "0.00"
        '            lblpropina.Text = FormatNumber(totalpropina, 2)
        '            lbltotales.Text = "0.00"
        '            lbltotales.Text = FormatNumber(totaltotal, 2)
        '        End If

        '        If grdPagos.Rows(deku).Cells(0).Value.ToString = "VISA" Then

        '            importef = grdPagos.Rows(deku).Cells(1).Value
        '            propina = grdPagos.Rows(deku).Cells(2).Value

        '            grdPagos.Rows(deku).Cells(3).Value = importef + propina

        '            totalimporte = totalimporte + importef
        '            totaltotal = totalimporte + totalf + propina
        '            totalpropina = totalpropina + propina


        '            lblimporte.Text = "0.00"
        '            lblimporte.Text = FormatNumber(totalimporte, 2)
        '            lblpropina.Text = "0.00"
        '            lblpropina.Text = FormatNumber(totalpropina, 2)
        '            lbltotales.Text = "0.00"
        '            lbltotales.Text = FormatNumber(totaltotal, 2)
        '        End If

        '    End If
        'Next


    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
    End Sub
    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        lblimporte.Text = "0.00"
        lblpropina.Text = "0.00"
        lbltotales.Text = "0.00"
        lblCambio.Text = "0.00"
        lblResta.Text = lblSubtotal.Text
    End Sub

    Private Sub lbltotales_TextChanged(sender As Object, e As EventArgs) Handles lbltotales.TextChanged

        importe = IIf(lblimporte.Text = "", 0, lblimporte.Text)
        propina = IIf(lblpropina.Text = "", 0, lblpropina.Text)
        resta = IIf(lblTotal.Text = "", 0, lblTotal.Text)

        lbltotales.Text = CDbl(importe) + CDbl(propina)
        lblResta.Text = resta - CDbl(lbltotales.Text)
        If lblResta.Text < 0 Then
            lblCambio.Text = -lblResta.Text
            lblResta.Text = "0.00"

        End If
    End Sub

    Public Function ActualizaTotales()

        Dim elda As Integer = grdPagos.CurrentRow.Index
        '  Dim celda As DataGridViewCellEventArgs = e


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
                    lblpropina.Text = "0.00"
                    lblpropina.Text = FormatNumber(totalpropina, 2)
                    lbltotales.Text = "0.00"
                    lbltotales.Text = FormatNumber(totaltotal, 2)
                End If

                If grdPagos.Rows(deku).Cells(0).Value.ToString = "VISA" Then

                    importef = grdPagos.Rows(deku).Cells(1).Value
                    propina = grdPagos.Rows(deku).Cells(2).Value

                    grdPagos.Rows(deku).Cells(3).Value = importef + propina

                    totalimporte = totalimporte + importef
                    totaltotal = totalimporte + totalf + propina
                    totalpropina = totalpropina + propina


                    lblimporte.Text = "0.00"
                    lblimporte.Text = FormatNumber(totalimporte, 2)
                    lblpropina.Text = "0.00"
                    lblpropina.Text = FormatNumber(totalpropina, 2)
                    lbltotales.Text = "0.00"
                    lbltotales.Text = FormatNumber(totaltotal, 2)
                End If

                If grdPagos.Rows(deku).Cells(0).Value.ToString = "MASTERCARD" Then

                    importef = grdPagos.Rows(deku).Cells(1).Value
                    propina = grdPagos.Rows(deku).Cells(2).Value

                    grdPagos.Rows(deku).Cells(3).Value = importef + propina

                    totalimporte = totalimporte + importef
                    totaltotal = totalimporte + totalf + propina
                    totalpropina = totalpropina + propina


                    lblimporte.Text = "0.00"
                    lblimporte.Text = FormatNumber(totalimporte, 2)
                    lblpropina.Text = "0.00"
                    lblpropina.Text = FormatNumber(totalpropina, 2)
                    lbltotales.Text = "0.00"
                    lbltotales.Text = FormatNumber(totaltotal, 2)
                End If

                If grdPagos.Rows(deku).Cells(0).Value.ToString = "AMERICAN EXPRESS" Then

                    importef = grdPagos.Rows(deku).Cells(1).Value
                    propina = grdPagos.Rows(deku).Cells(2).Value

                    grdPagos.Rows(deku).Cells(3).Value = importef + propina

                    totalimporte = totalimporte + importef
                    totaltotal = totalimporte + totalf + propina
                    totalpropina = totalpropina + propina


                    lblimporte.Text = "0.00"
                    lblimporte.Text = FormatNumber(totalimporte, 2)
                    lblpropina.Text = "0.00"
                    lblpropina.Text = FormatNumber(totalpropina, 2)
                    lbltotales.Text = "0.00"
                    lbltotales.Text = FormatNumber(totaltotal, 2)
                End If

            End If
        Next

    End Function
    Private Sub grdPagos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdPagos.CellClick
        ActualizaTotales()
    End Sub

    Private Sub frmPagarT_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        txtMontos.Focus.Equals(True)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BTNacEPTAR.Click

        If txtMontos.Text = "" Then txtMontos.Focus.Equals(True) : Exit Sub

        Select Case focoforma
            Case Is = 1
                For luffy As Integer = 0 To grdPagos.Rows.Count - 1
                    If grdPagos.Rows(luffy).Cells(0).Value = "EFECTIVO" Then

                        If pro = 1 Then
                            grdPagos.Rows(luffy).Cells(2).Value = txtMontos.Text
                        Else
                            grdPagos.Rows(luffy).Cells(1).Value = txtMontos.Text
                        End If

                    End If
                Next
            Case Is = 2
                For luffy As Integer = 0 To grdPagos.Rows.Count - 1
                    If grdPagos.Rows(luffy).Cells(0).Value = "VISA" Then

                        If pro = 1 Then
                            grdPagos.Rows(luffy).Cells(2).Value = txtMontos.Text
                        Else
                            grdPagos.Rows(luffy).Cells(1).Value = txtMontos.Text
                        End If

                    End If
                Next

            Case Is = 3
                For luffy As Integer = 0 To grdPagos.Rows.Count - 1
                    If grdPagos.Rows(luffy).Cells(0).Value = "MASTERCARD" Then
                        If pro = 1 Then
                            grdPagos.Rows(luffy).Cells(2).Value = txtMontos.Text
                        Else
                            grdPagos.Rows(luffy).Cells(1).Value = txtMontos.Text
                        End If

                    End If
                Next

            Case Is = 4
                For luffy As Integer = 0 To grdPagos.Rows.Count - 1
                    If grdPagos.Rows(luffy).Cells(0).Value = "AMERICAN EXPRESS" Then
                        If pro = 1 Then
                            grdPagos.Rows(luffy).Cells(2).Value = txtMontos.Text
                        Else
                            grdPagos.Rows(luffy).Cells(1).Value = txtMontos.Text
                        End If

                    End If
                Next
        End Select
        txtMontos.Text = ""
        pro = 0
        ActualizaTotales()
    End Sub


    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        Select Case focoforma
            Case Is = 1
                txtMontos.Text = txtMontos.Text + btn1.Text
            Case Is = 2
                txtMontos.Text = txtMontos.Text + btn1.Text
            Case Is = 3
                txtMontos.Text = txtMontos.Text + btn1.Text
            Case Is = 4
                txtMontos.Text = txtMontos.Text + btn1.Text
            Case Is = 5
                txtMontos.Text = txtMontos.Text + btn1.Text
        End Select
    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        Select Case focoforma
            Case Is = 1
                txtMontos.Text = txtMontos.Text + btn2.Text
            Case Is = 2
                txtMontos.Text = txtMontos.Text + btn2.Text
            Case Is = 3
                txtMontos.Text = txtMontos.Text + btn2.Text
            Case Is = 4
                txtMontos.Text = txtMontos.Text + btn2.Text
            Case Is = 5
                txtMontos.Text = txtMontos.Text + btn2.Text
        End Select
    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        Select Case focoforma
            Case Is = 1
                txtMontos.Text = txtMontos.Text + btn3.Text
            Case Is = 2
                txtMontos.Text = txtMontos.Text + btn3.Text
            Case Is = 3
                txtMontos.Text = txtMontos.Text + btn3.Text
            Case Is = 4
                txtMontos.Text = txtMontos.Text + btn3.Text
            Case Is = 5
                txtMontos.Text = txtMontos.Text + btn3.Text
        End Select
    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        Select Case focoforma
            Case Is = 1
                txtMontos.Text = txtMontos.Text + btn4.Text
            Case Is = 2
                txtMontos.Text = txtMontos.Text + btn4.Text
            Case Is = 3
                txtMontos.Text = txtMontos.Text + btn4.Text
            Case Is = 4
                txtMontos.Text = txtMontos.Text + btn4.Text
            Case Is = 5
                txtMontos.Text = txtMontos.Text + btn4.Text
        End Select
    End Sub

    Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        Select Case focoforma
            Case Is = 1
                txtMontos.Text = txtMontos.Text + btn5.Text
            Case Is = 2
                txtMontos.Text = txtMontos.Text + btn5.Text
            Case Is = 3
                txtMontos.Text = txtMontos.Text + btn5.Text
            Case Is = 4
                txtMontos.Text = txtMontos.Text + btn5.Text
            Case Is = 5
                txtMontos.Text = txtMontos.Text + btn5.Text
        End Select
    End Sub

    Private Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
        Select Case focoforma
            Case Is = 1
                txtMontos.Text = txtMontos.Text + btn6.Text
            Case Is = 2
                txtMontos.Text = txtMontos.Text + btn6.Text
            Case Is = 3
                txtMontos.Text = txtMontos.Text + btn6.Text
            Case Is = 4
                txtMontos.Text = txtMontos.Text + btn6.Text
            Case Is = 5
                txtMontos.Text = txtMontos.Text + btn6.Text
        End Select
    End Sub

    Private Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
        Select Case focoforma
            Case Is = 1
                txtMontos.Text = txtMontos.Text + btn7.Text
            Case Is = 2
                txtMontos.Text = txtMontos.Text + btn7.Text
            Case Is = 3
                txtMontos.Text = txtMontos.Text + btn7.Text
            Case Is = 4
                txtMontos.Text = txtMontos.Text + btn7.Text
            Case Is = 5
                txtMontos.Text = txtMontos.Text + btn7.Text
        End Select
    End Sub

    Private Sub btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
        Select Case focoforma
            Case Is = 1
                txtMontos.Text = txtMontos.Text + btn8.Text
            Case Is = 2
                txtMontos.Text = txtMontos.Text + btn8.Text
            Case Is = 3
                txtMontos.Text = txtMontos.Text + btn8.Text
            Case Is = 4
                txtMontos.Text = txtMontos.Text + btn8.Text
            Case Is = 5
                txtMontos.Text = txtMontos.Text + btn8.Text
        End Select
    End Sub

    Private Sub btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
        Select Case focoforma
            Case Is = 1
                txtMontos.Text = txtMontos.Text + btn9.Text
            Case Is = 2
                txtMontos.Text = txtMontos.Text + btn9.Text
            Case Is = 3
                txtMontos.Text = txtMontos.Text + btn9.Text
            Case Is = 4
                txtMontos.Text = txtMontos.Text + btn9.Text
            Case Is = 5
                txtMontos.Text = txtMontos.Text + btn9.Text
        End Select
    End Sub

    Private Sub btn0_Click(sender As Object, e As EventArgs) Handles btn0.Click
        Select Case focoforma
            Case Is = 1
                txtMontos.Text = txtMontos.Text + btn0.Text
            Case Is = 2
                txtMontos.Text = txtMontos.Text + btn0.Text
            Case Is = 3
                txtMontos.Text = txtMontos.Text + btn0.Text
            Case Is = 4
                txtMontos.Text = txtMontos.Text + btn0.Text
            Case Is = 5
                txtMontos.Text = txtMontos.Text + btn0.Text
        End Select
    End Sub

    Private Sub btnpunto_Click(sender As Object, e As EventArgs) Handles btnpunto.Click
        Select Case focoforma
            Case Is = 1
                txtMontos.Text = txtMontos.Text + btnpunto.Text
            Case Is = 2
                txtMontos.Text = txtMontos.Text + btnpunto.Text
            Case Is = 3
                txtMontos.Text = txtMontos.Text + btnpunto.Text
            Case Is = 4
                txtMontos.Text = txtMontos.Text + btnpunto.Text
            Case Is = 5
                txtMontos.Text = txtMontos.Text + btnpunto.Text
        End Select
    End Sub

    Private Sub btnQuitar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
        txtMontos.Text = CutCad(txtMontos.Text)
    End Sub

    Public Function CutCad(VAL As String) As String
        If Len(VAL) > 0 Then
            CutCad = Strings.Left(VAL, Len(VAL) - 1)
        Else
            CutCad = ""
        End If
    End Function
End Class
Public Class frmTePreCant
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim totalventa As Double = 0
        Dim totalnuevo As Double = 0
        With frmCorreciones.grdCaptura

            For q As Integer = 0 To frmCorreciones.grdCaptura.Rows.Count - 1
                frmCorreciones.lblTotalVenta.Text = "0.00"

                If frmCorreciones.grdCaptura.Rows(q).Cells(0).Value = frmCorreciones.CodigoProducto Then
                    frmCorreciones.grdCaptura.Rows(q).Cells(1).Value = frmCorreciones.CodigoProducto & vbNewLine & frmCorreciones.descripcionpro
                    frmCorreciones.grdCaptura.Rows(q).Cells(2).Value = FormatNumber(txtrespuesta.Text, 2)
                    frmCorreciones.grdCaptura.Rows(q).Cells(3).Value = frmCorreciones.grdCaptura.Rows(q).Cells(3).Value.ToString
                    totalnuevo = txtrespuesta.Text * frmCorreciones.grdCaptura.Rows(q).Cells(3).Value.ToString
                    frmCorreciones.grdCaptura.Rows(q).Cells(4).Value = FormatNumber(totalnuevo, 2)

                    'banderaproducto = 1
                Else
                    'grdCaptura.Rows(q).Cells(2).Value = FormatNumber(respuesta, 2)
                End If
            Next q

        End With

    End Sub
End Class
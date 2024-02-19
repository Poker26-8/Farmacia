Public Class frmPagarPollos

    Public subtotalmapeo As Double = 0

    Dim vercomanda As String = ""
    Dim vercodigo As String = ""
    Dim verdescripcion As String = ""
    Dim verunidad As String = ""
    Dim vercantidad As Double = 0
    Dim verprecio As Double = 0
    Dim vertotal As Double = 0
    Dim vercomensal As String = ""
    Dim vermesero As String = ""
    Dim verid As Integer = 0

    Dim cantidadp As Double = 0
    Dim CodigoProductoSel As String = ""

    Private Sub frmPagarPollos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TFolioP.Start()

        Try

            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT * FROM Comandas WHERE NMESA='" & lblmesa.Text & "'"
            rd2 = cmd2.ExecuteReader
            Do While rd2.Read
                If rd2.HasRows Then
                    vercomanda = rd2("IDC").ToString
                    vercodigo = rd2("Codigo").ToString
                    verdescripcion = rd2("Nombre").ToString
                    verunidad = rd2("UVenta").ToString
                    vercantidad = rd2("Cantidad").ToString
                    verprecio = rd2("Precio").ToString
                    vertotal = rd2("Total").ToString
                    vercomensal = rd2("Comensal").ToString
                    vermesero = rd2("CUsuario").ToString
                    verid = rd2("Id").ToString
                    grdComandas.Rows.Add(vercomanda, vercodigo, verdescripcion, verunidad, vercantidad, verprecio, vertotal, verid)
                End If
            Loop
            rd2.Close()
            cnn2.Close()


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
        End Try
    End Sub

    Public Sub GuardarVenta()

    End Sub

    Private Sub grdComandas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdComandas.CellClick


        Dim celda As DataGridViewCellEventArgs = e

        If celda.ColumnIndex = 4 Then

            CodigoProductoSel = grdComandas.CurrentRow.Cells(1).Value.ToString
            PCantidad.Visible = True
            txtCantidad.Focus.Equals(True)
        End If

    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        txtCantidad.Text = txtCantidad.Text + btn1.Text
    End Sub

    Private Sub btnIntro_Click(sender As Object, e As EventArgs) Handles btnIntro.Click


        Dim totalnuevo As Double = 0
        Dim totalventa As Double = 0

        For q As Integer = 0 To grdComandas.Rows.Count - 1
            lblsubtotalmapeo.Text = "0.00"
            If grdComandas.Rows(q).Cells(1).Value = CodigoProductoSel Then

                grdComandas.Rows(q).Cells(4).Value = txtCantidad.Text
                totalnuevo = txtCantidad.Text * grdComandas.Rows(q).Cells(5).Value.ToString
                grdComandas.Rows(q).Cells(6).Value = FormatNumber(totalnuevo, 2)

            End If

        Next q

        For luffy As Integer = 0 To grdComandas.Rows.Count - 1
            totalventa = totalventa + grdComandas.Rows(luffy).Cells(6).Value.ToString
            lblsubtotalmapeo.Text = FormatNumber(totalventa, 2)
        Next

        PCantidad.Visible = False
        txtCantidad.Text = ""
    End Sub

    Private Sub btnPagar_Click(sender As Object, e As EventArgs) Handles btnPagar.Click
        Me.Close()
        frmPolleria.Show()
    End Sub

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress

        If AscW(e.KeyChar) = Keys.Enter Then
            btnIntro.PerformClick()
        End If

    End Sub

    Private Sub TFolioP_Tick(sender As Object, e As EventArgs) Handles TFolioP.Tick
        TFolioP.Stop()

        cnntimer.Close() : cnntimer.Open()
        cmdtimer = cnntimer.CreateCommand
        cmdtimer.CommandText = "SELECT MAX(Folio) FROM Ventas"
        rdtimer = cmdtimer.ExecuteReader
        If rdtimer.HasRows Then
            If rdtimer.Read Then
                lblfolio.Text = CDbl(IIf(rdtimer(0).ToString = "", "0", rdtimer(0).ToString)) + 1
            Else
                lblfolio.Text = "1"
            End If
        Else
            lblfolio.Text = "1"
        End If
        rdtimer.Close()
        cnntimer.Close()

        TFolioP.Start()
    End Sub
End Class
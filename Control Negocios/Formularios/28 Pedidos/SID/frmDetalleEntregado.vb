Public Class frmDetalleEntregado
    Public cliente As String = ""
    Dim Mytotal As Double = 0
    Dim MyPrecio As Double = 0
    Public folio As Integer = 0
    Private Sub frmDetalleEntregado_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        frmEntregaPedidos.Enabled = True
    End Sub

    Private Sub frmDetalleEntregado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            lblFolio.Text = frmEntregaPedidos.cboFolio.Text
            If lblFolio.Text = "" Then
                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Select * from pedidosdet where Cantidad>CantidadE"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    DataGridView1.Rows.Add(rd1("NumPed").ToString, rd1("Codigo").ToString, rd1("Nombre").ToString, rd1("Unidad").ToString, rd1("Cantidad").ToString, rd1("CantidadE").ToString, FormatNumber(rd1("Cantidad").ToString, 2) - CDec(FormatNumber(rd1("CantidadE").ToString, 2)), FormatNumber(rd1("Precio").ToString, 2), FormatNumber(CDec(rd1("Cantidad").ToString * rd1("Precio").ToString), 2), rd1("Proveedor").ToString)
                Loop
                rd1.Close()
                cnn1.Close()
            Else
                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Select * from pedidosven where NumPedido='" & lblFolio.Text & "'"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read

                    cnn2.Close()
                    cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "Select * from pedidosvendet where Folio=" & rd1("Folio").ToString & ""
                    rd2 = cmd2.ExecuteReader
                    Do While rd2.Read
                        cnn3.Close()
                        cnn3.Open()
                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText = "Select * from pedidosdet where NumPed='" & lblFolio.Text & "' and Codigo='" & rd2("Codigo").ToString & "'"
                        rd3 = cmd3.ExecuteReader
                        If rd3.Read Then
                            grdCaptura.Rows.Add(rd1("Folio").ToString, rd3("Codigo").ToString, rd3("Nombre").ToString, rd3("Unidad").ToString, rd3("Cantidad").ToString, rd2("Cantidad").ToString, rd1("Cliente").ToString, rd2("Fecha").ToString, FormatNumber(rd2("Precio").ToString, 2), FormatNumber(rd2("Total").ToString, 2))
                        End If
                        rd3.Close()
                        cnn3.Close()
                    Loop
                    rd2.Close()
                    cnn2.Close()
                Loop
                rd1.Close()
                cnn1.Close()

                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Select * from pedidosdet where NumPed='" & lblFolio.Text & "' and Cantidad>CantidadE"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    DataGridView1.Rows.Add(rd1("NumPed").ToString, rd1("Codigo").ToString, rd1("Nombre").ToString, rd1("Unidad").ToString, rd1("Cantidad").ToString, rd1("CantidadE").ToString, FormatNumber(rd1("Cantidad").ToString, 2) - CDec(FormatNumber(rd1("CantidadE").ToString, 2)), FormatNumber(rd1("Precio").ToString, 2), FormatNumber(CDec(rd1("Cantidad").ToString * rd1("Precio").ToString), 2), rd1("Proveedor").ToString)
                Loop
                rd1.Close()
                cnn1.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
            cnn1.Close()
        End Try
    End Sub

    Private Sub grdCaptura_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdCaptura.CellDoubleClick
        Dim celda As DataGridViewCellEventArgs = e
        Dim fila As Integer = grdCaptura.CurrentRow.Index


        If celda.ColumnIndex = 5 Then

            boxcantidad.Visible = True
            txtcantidad.Focus().Equals(True)
            folio = grdCaptura.CurrentRow.Cells(0).Value.ToString
            cliente = grdCaptura.CurrentRow.Cells(6).Value.ToString
            txtcantidad.Tag = grdCaptura.CurrentRow.Cells(5).Value.ToString
            MsgBox(txtcantidad.Tag)
            txtcodigo.Text = grdCaptura.CurrentRow.Cells(1).Value.ToString
            txtcodigo.Tag = fila
            txtnombre.Text = grdCaptura.CurrentRow.Cells(2).Value.ToString
            MyPrecio = grdCaptura.CurrentRow.Cells(8).Value.ToString
            txtcantidad.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtcantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcantidad.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                If txtcantidad.Text = "" Or txtcantidad.Text = "0" Then
                    Exit Sub
                End If
                Mytotal = txtcantidad.Text * MyPrecio
                Dim MySaldo As Double = 0
                cnn2.Close()
                cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText =
                                    "select Saldo from AbonoI where Id=(select MAX(Id) from AbonoI where Cliente='" & cliente & "')"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        MySaldo = CDbl(IIf(rd2(0).ToString = "", 0, rd2(0).ToString))
                    End If
                Else
                    MySaldo = Mytotal
                End If
                rd2.Close()
                cnn2.Close()

                Dim newcantidad As Double = txtcantidad.Text
                Dim oldcantidad As Double = txtcantidad.Tag


                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                If newcantidad > oldcantidad Then
                    cmd1.CommandText = "Update Pedidosven set Subtotal=Subotal+" & Mytotal & ", Totales=Totales+" & Mytotal & ", Resta=Resta+" & Mytotal & " where Folio=" & folio & ""
                ElseIf newcantidad < oldcantidad Then
                    cmd1.CommandText = "Update Pedidosven set Subtotal=Subotal-" & Mytotal & ", Totales=Totales-" & Mytotal & ", Resta=Resta-" & Mytotal & " where Folio=" & folio & ""
                End If
                If cmd1.ExecuteNonQuery Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "Update Pedidosvendet set Cantidad=" & newcantidad & ", Precio=" & MyPrecio & ", Total=" & Mytotal & ", PrecioSIVA=" & MyPrecio & ", TotalSIVA=" & Mytotal & " where Folio=" & folio & ""
                    If cmd1.ExecuteNonQuery Then

                    Else

                    End If
                Else
                    s
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End If
    End Sub
End Class
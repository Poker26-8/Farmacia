Public Class frmAsignaRefaccion

    Public idvehiculo As Integer = 0
    Public placa As String = ""
    Private Sub frmAsignaRefaccion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            Dim codigopro As String = ""
            Dim preciopro As Double = 0

            cnn1.Close() : cnn1.Open()
            cnn2.Close() : cnn2.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM refaccionaria WHERE IdVehiculo=" & idvehiculo & ""
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then

                    codigopro = rd1("CodigoPro").ToString

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT PrecioVentaIVA from Productos WHERE Codigo='" & codigopro & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            preciopro = rd2(0).ToString
                        End If
                    End If
                    rd2.Close()

                    grdRefaccion.Rows.Add(rd1("CodigoPro").ToString,
                                          rd1("Nombre").ToString,
                                          rd1("NumParte").ToString,
                                          rd1("Marca").ToString,
                                          rd1("Medida").ToString,
                                          rd1("Observaciones").ToString,
                                          FormatNumber(preciopro, 2)
)

                End If
            Loop
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            cnn2.Close()
        End Try

    End Sub

    Private Sub grdRefaccion_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdRefaccion.CellDoubleClick
        Dim index As Integer = grdRefaccion.CurrentRow.Index

        Dim codigo As String = grdRefaccion.Rows(index).Cells(0).Value.ToString
        Dim DESCRIPCION As String = grdRefaccion.Rows(index).Cells(1).Value.ToString
        Dim parte As String = grdRefaccion.Rows(index).Cells(2).Value.ToString
        Dim marca As String = grdRefaccion.Rows(index).Cells(3).Value.ToString
        Dim PREECIO As Double = grdRefaccion.Rows(index).Cells(6).Value.ToString

        grdAsignar.Rows.Add(codigo,
                                         DESCRIPCION,
                                         parte,
                                         marca,
                                         PREECIO
)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub grdAsignar_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdAsignar.CellDoubleClick
        Dim index As Integer = grdAsignar.CurrentRow.Index

        grdAsignar.Rows.Remove(grdAsignar.CurrentRow)
    End Sub

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        Try

            If grdAsignar.Rows.Count > 0 Then

                For luffy As Integer = 0 To grdAsignar.Rows.Count - 1


                    Dim codigo As String = grdAsignar.Rows(luffy).Cells(0).Value.ToString
                    Dim nombre As String = grdAsignar.Rows(luffy).Cells(1).Value.ToString
                    Dim parte As String = grdAsignar.Rows(luffy).Cells(2).Value.ToString
                    Dim marca As String = grdAsignar.Rows(luffy).Cells(3).Value.ToString
                    Dim PRECIO As Double = grdAsignar.Rows(luffy).Cells(4).Value.ToString


                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO comandasveh(IdVehiculo,Vehiculo,Placa,Cliente,Codigo,Nombre,NParte,Marca,Precio,Fecha) VALUES(" & idvehiculo & ",'" & cbovehiculo.Text & "','" & placa & "','" & txtCliente.Text & "','" & codigo & "','" & nombre & "','" & parte & "','" & marca & "','" & PRECIO & "','" & Format(Date.Now, "yyyy-MM-dd") & "')"
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()

                Next
                MsgBox("Refacciones agregadas correctamente.", vbInformation + vbOKOnly, titulorefaccionaria)
                grdAsignar.Rows.Clear()
                frmTallerR.TVehiculo.Start()
            Else
                MsgBox("Debes de seleccionar las refacciones", vbInformation + vbOKOnly, titulorefaccionaria)
                Exit Sub
            End If

            frmTallerR.pVehiculos.Controls.Clear()
            Me.Close()


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
        End Try
    End Sub
End Class
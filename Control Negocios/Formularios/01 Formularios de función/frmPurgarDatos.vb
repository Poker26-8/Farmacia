Public Class frmPurgarDatos
    Private Sub btnVentas_Click(sender As Object, e As EventArgs) Handles btnVentas.Click
        Try
            If MsgBox("¿Desea eliminar los registros, al continuar ya no podrán recuperar los datos?", vbInformation + vbYesNo, titulocentral) = vbYes Then

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM ventasdetalle"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then

                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "TRUNCATE TABLE ventasdetalle"
                        cmd2.ExecuteNonQuery()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "DELETE FROM ventas"
                        cmd2.ExecuteNonQuery()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "ALTER TABLE `ventas` AUTO_INCREMENT=1"
                        cmd2.ExecuteNonQuery()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "TRUNCATE TABLE abonoi"
                        cmd2.ExecuteNonQuery()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "TRUNCATE TABLE vtaimpresion"
                        cmd2.ExecuteNonQuery()

                        MsgBox("Ventas y abonos eliminados correctamente", vbInformation + vbOKOnly, titulocentral)
                        cnn2.Close()
                    End If
                End If
                rd1.Close()
                cnn1.Close()

            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnCompras_Click(sender As Object, e As EventArgs) Handles btnCompras.Click
        Try
            If MsgBox("¿Desea eliminar los registros, al continuar ya no podrán recuperar los datos?", vbInformation + vbYesNo) = vbYes Then

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM compras"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then

                        cnn2.Close() : cnn2.Open()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "TRUNCATE TABLE comprasdet"
                        cmd2.ExecuteNonQuery()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "delete from compras"
                        cmd2.ExecuteNonQuery()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "ALTER TABLE `compras` AUTO_INCREMENT=1"
                        cmd2.ExecuteNonQuery()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "TRUNCATE TABLE abonoe"
                        cmd2.ExecuteNonQuery()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "TRUNCATE TABLE auxcompras"
                        cmd2.ExecuteNonQuery()

                        MsgBox("Compras eliminadas correctamente", vbInformation + vbOKOnly, titulocentral)
                        cnn2.Close()
                    End If
                End If
                rd1.Close()
                cnn1.Close()

            End If



        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnProductos_Click(sender As Object, e As EventArgs) Handles btnProductos.Click
        Try
            If MsgBox("¿Desea eliminar los registros, al continuar ya no podrán recuperar los datos?", vbInformation + vbYesNo, titulocentral) = vbYes Then

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM productos"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then

                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "DELETE FROM productos"
                        If cmd2.ExecuteNonQuery() Then
                            MsgBox("Productos eliminados correctamente", vbInformation + vbOKOnly, titulocentral)
                            cnn2.Close()
                        End If


                    End If
                End If
                rd1.Close()
                cnn1.Close()

            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnExistencias_Click(sender As Object, e As EventArgs) Handles btnExistencias.Click
        Try
            If MsgBox("¿Desea actualizar las existencias a 0, al continuar no podrán recuperar los datos?", vbInformation + vbYesNo, titulocentral) = vbYes Then

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM productos"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then

                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "UPDATE Productos SET Existencia='0'"
                        If cmd2.ExecuteNonQuery() Then
                            MsgBox("Existencias actualizadas", vbInformation + vbOKOnly, titulocentral)
                            cnn2.Close()
                        End If

                    End If
                End If
                rd1.Close()
                cnn1.Close()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub
End Class
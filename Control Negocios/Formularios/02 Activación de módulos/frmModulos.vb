Public Class frmModulos

      Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
            frmAct_Sincronizador.Show()
            frmAct_Sincronizador.BringToFront()
      End Sub

      Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
            frmAct_Entregas.Show()
            frmAct_Entregas.txtcontra.Focus().Equals(True)
            frmAct_Entregas.BringToFront()
      End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmAct_Asistencia.Show()
        frmAct_Asistencia.txtcontra.Focus().Equals(True)
        frmAct_Asistencia.BringToFront()
    End Sub

    Private Sub frmModulos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Carga las activaciones realizadas
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Formatos where Facturas='Mod_Asis'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If rd1("NumPart").ToString() = 1 Then
                        Button1.Enabled = False
                    End If
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Formatos where Facturas='Gimnasio'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If rd1("NotasCred").ToString() = 1 Then
                        Button6.Enabled = False
                    End If
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Formatos where Facturas='Mod_Comp'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If rd1("NumPart").ToString() = 1 Then
                        Button3.Enabled = False
                    End If
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Formatos where Facturas='Entregas'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If rd1("NumPart").ToString() = 1 Then
                        Button2.Enabled = False
                    End If
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Formatos where Facturas='Papos'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If rd1("NumPart").ToString() = 1 Then
                        Button7.Enabled = False
                    End If
                End If
            End If
            rd1.Close()


            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Formatos where Facturas='Control_Servicios'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If rd1("NumPart").ToString() = 1 Then
                        btncontrol_servicios.Enabled = False
                    End If
                End If
            End If
            rd1.Close()


            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        frmAct_Zapaterias.Show()
        frmAct_Zapaterias.BringToFront()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        frmAct_Precios.Show()
        frmAct_Precios.BringToFront()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles btnRestaurante.Click
        frmAct_Restaurantes.Show()
        frmAct_Restaurantes.BringToFront()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        frmAct_Escuelas.Show()
        frmAct_Escuelas.BringToFront()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles btnRefaccionaria.Click
        frmAct_Refaccionaria.Show()
        frmAct_Refaccionaria.BringToFront()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles btnTelefonia.Click
        frmAct_Telefonia.Show()
        frmAct_Telefonia.BringToFront()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        frmAct_Gym.Show()
        frmAct_Gym.BringToFront()
        Me.Close()
    End Sub

    Private Sub btncontrol_servicios_Click(sender As Object, e As EventArgs) Handles btncontrol_servicios.Click
        frmAct_Servicios.Show()
        frmAct_Servicios.BringToFront()
        Me.Close()
    End Sub

    Private Sub Button9_Click_1(sender As Object, e As EventArgs) Handles Button9.Click
        frmAct_Nomina.Show()
        frmAct_Nomina.BringToFront()
        Me.Close()
    End Sub

    Private Sub btnProduccion_Click(sender As Object, e As EventArgs) Handles btnProduccion.Click
        frmAct_Produccion.Show()
        frmAct_Produccion.BringToFront()
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        frmAct_Hoteleria.Show()
        frmAct_Hoteleria.BringToFront()
        Me.Close()
    End Sub
End Class
Public Class frmRepPrecios
    Private Sub cbonombre_DropDown(sender As Object, e As EventArgs) Handles cbonombre.DropDown
        Dim mc1 As Date = mCalendar1.SelectionStart.ToShortDateString
        Dim mc2 As Date = mCalendar2.SelectionStart.ToShortDateString

        cbonombre.Items.Clear()
        Try

            Dim fecha1 As Date = Nothing
            Dim fecha2 As Date = Nothing

            fecha1 = mc1
            fecha2 = mc2

            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct Nombre from ModPrecios where Fecha between '" & Format(fecha1, "yyyy-MM-dd 00:0:00") & "' and '" & Format(fecha2, "yyyy-MM-dd 23:59:59") & "' and Nombre<>''"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cbonombre.Items.Add(rd1(0).ToString())
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbonombre_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbonombre.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "Select Codigo from ModPrecios where Nombre='" & cbonombre.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtcodigo.Text = rd1(0).ToString()
                End If
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnreporte_Click(sender As Object, e As EventArgs) Handles btnreporte.Click
        Dim mc1 As String = mCalendar1.SelectionStart.ToShortDateString
        Dim mc2 As String = mCalendar2.SelectionStart.ToShortDateString

        Dim fechainicio As Date = Nothing
        Dim fechafin As Date = Nothing


        fechainicio = mc1
        fechafin = mc2

        grdcaptura.Rows.Clear()

        If cbonombre.Text = "" Then
            'Muestra todos los movimientos dentro del rango de fecha
            Try

                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Codigo,Nombre,Tipo,Anterior,Nuevo,Fecha,Usuario from ModPrecios where Fecha between '" & Format(fechainicio, "yyyy-MM-dd 00:00:00") & "' and '" & Format(fechafin, "yyyy-MM-dd 23:59:59") & "' order by Id"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        Dim codigo As String = rd1("Codigo").ToString()
                        Dim nombre As String = rd1("Nombre").ToString()
                        Dim tipo As String = rd1("Tipo").ToString()
                        Dim ant As Double = rd1("Anterior").ToString()
                        Dim nue As Double = rd1("Nuevo").ToString()
                        Dim fecha As Date = rd1("Fecha").ToString()
                        Dim usuario As String = rd1("Usuario").ToString()

                        grdcaptura.Rows.Add(codigo, nombre, "Precio de " & tipo, FormatNumber(ant, 2), FormatNumber(nue, 2), FormatDateTime(fecha, DateFormat.ShortDate), usuario)
                    End If
                Loop
                rd1.Close() : cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        Else
            'Muestra los movimientos de un producto específico
            Try

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Codigo,Nombre,Tipo,Anterior,Nuevo,Fecha,Usuario FROM modprecios where Fecha >='" & Format(fechainicio, "yyyy-MM-dd 00:00:00") & "' And Fecha<='" & Format(fechafin, "yyyy-MM-dd 23:59:59") & "' AND Nombre='" & cbonombre.Text & "' order by Id"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        Dim codigo As String = rd1("Codigo").ToString()
                        Dim nombre As String = rd1("Nombre").ToString()
                        Dim tipo As String = rd1("Tipo").ToString()
                        Dim ant As Double = rd1("Anterior").ToString()
                        Dim nue As Double = rd1("Nuevo").ToString()
                        Dim fecha As Date = rd1("Fecha").ToString()
                        Dim usuario As String = rd1("Usuario").ToString()


                        grdcaptura.Rows.Add(codigo, nombre, "Precio de " & tipo, FormatNumber(ant, 2), FormatNumber(nue, 2), FormatDateTime(fecha, DateFormat.ShortDate), usuario)
                    End If
                Loop
                rd1.Close() : cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try

        End If
    End Sub

    Private Sub frmRepPrecios_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
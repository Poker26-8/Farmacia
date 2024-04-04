Public Class frmcofepris
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim M1 As Date = mCalendar1.SelectionStart.ToShortDateString
        Dim M2 As Date = mCalendar2.SelectionStart.ToShortDateString

        Try
            cnn1.Close() : cnn1.Open()

            cnn2.Close() : cnn2.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "SELECT VE.Folio, PR.Codigo, PR.Nombre, SUM(VD.Cantidad) as Cantidad, PR.Existencia, VD.Fecha, RA.Receta, RA.Status, RA.me_id FROM (((VentasDetalle VD INNER JOIN Productos PR ON VD.Codigo=PR.Codigo) INNER JOIN Ventas VE ON VD.Folio=VE.Folio) INNER JOIN rep_antib RA ON RA.Folio=VE.Folio) WHERE (VD.Grupo='ANTIBIOTICO' OR VD.Grupo='CONTROLADO') AND FVenta>='" & Format(M1, "yyyy-MM-dd") & "' AND FVenta<='" & Format(M2, "yyyy-MM-dd") & "' GROUP BY VE.Folio, PR.Codigo, PR.Nombre, VD.Cantidad, PR.Existencia, VD.Fecha, RA.Receta, RA.Status, RA.me_id"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    Dim cedula, nombre, direccion As String

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "Select CM.Cedula, CM.Nombre, CM.Domicilio FROM (ctmedicos CM INNER JOIN rep_antib RES ON CM.Id=RES.me_id AND RES.Folio=" & rd1("Folio").ToString() & ")"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            cedula = rd2("Cedula").ToString()
                            nombre = rd2("Nombre").ToString()
                            direccion = rd2("Domicilio").ToString()
                        End If
                    End If
                    rd2.Close()

                    grdcaptura.Rows.Add(rd1("Folio").ToString(), rd1("Codigo").ToString(), rd1("Nombre").ToString(), rd1("Cantidad").ToString(), rd1("Existencia").ToString(), "", FormatDateTime(rd1("Fecha").ToString(), DateFormat.ShortDate), rd1("Receta").ToString(), cedula, nombre, direccion)
                End If
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub
End Class
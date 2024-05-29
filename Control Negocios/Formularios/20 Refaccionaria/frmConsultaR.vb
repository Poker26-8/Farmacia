
Imports System.IO
Imports System.Web.Services

Public Class frmConsultaR
    Private Sub frmConsultaR_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cbovehiculo_DropDown(sender As Object, e As EventArgs) Handles cbovehiculo.DropDown

        Try
            cbovehiculo.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT descripcion FROM vehiculo"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cbovehiculo.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

    End Sub

    Private Sub cboservicio_DropDown(sender As Object, e As EventArgs) Handles cboservicio.DropDown
        Try
            cboservicio.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Servicio FROM refaccionaria WHERE IdVehiculo=" & lblvehiculo.Text & " AND Servicio<>'' ORDER BY Servicio"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboservicio.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboservicio_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboservicio.SelectedValueChanged
        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT IdVehiculo FROM vehiculo WHERE Descripcion='" & cbovehiculo.Text & "'"
        rd1 = cmd1.ExecuteReader
        If rd1.Read Then
            If rd1.HasRows Then
                lblvehiculo.Text = rd1(0).ToString
            End If
        End If
        rd1.Close()
        cnn1.Close()
    End Sub

    Private Sub btnbuscar_Click(sender As Object, e As EventArgs) Handles btnbuscar.Click
        Try
            grdcaptura.Rows.Clear()

            If cbovehiculo.Text = "" Then MsgBox("Seleccione un vehiculo", vbInformation + vbOKOnly, titulorefaccionaria) : cbovehiculo.Focus.Equals(True) : Exit Sub


            cnn1.Close() : cnn1.Open()
            cnn2.Close() : cnn2.Open()
            cmd1 = cnn1.CreateCommand

            If cbovehiculo.Text <> "" Then
                cmd1.CommandText = "SELECT * FROM refaccionaria WHERE IdVehiculo=" & lblvehiculo.Text & ""
            End If

            If cboservicio.Text <> "" Then
                cmd1.CommandText = "SELECT * FROM refaccionaria WHERE Servicio ='" & cboservicio.Text & "' AND IdVehiculo=" & lblvehiculo.Text & ""
            End If

            If cbodatos.Text <> "" Then
                cmd1.CommandText = "SELECT * FROM refaccionaria WHERE IdVehiculo=" & lblvehiculo.Text & " AND Marca='" & cbodatos.Text & "'"
            End If

            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then

                    Dim codigopro As String = rd1("CodigoPro").ToString
                    Dim precio As Double = 0
                    Dim PROVEEDOR As String = ""
                    Dim existencias As Double = 0
                    Dim multiplo As Double = 0
                    Dim vehiculo As String = ""

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT * FROM productos WHERE Codigo='" & codigopro & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.Read Then
                        If rd2.HasRows Then
                            precio = rd2("PrecioVentaIVA").ToString
                            PROVEEDOR = rd2("ProvPri").ToString
                            multiplo = rd2("Multiplo").ToString
                            existencias = CDbl(IIf(rd2("Existencia").ToString = "", "0", rd2("Existencia").ToString)) / multiplo

                        End If
                    End If
                    rd2.Close()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT Descripcion FROM vehiculo WHERE IdVehiculo=" & lblvehiculo.Text & ""
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            vehiculo = rd2(0).ToString
                        End If
                    End If
                    rd2.Close()

                    grdcaptura.Rows.Add(rd1("CodigoPro").ToString,
                                        rd1("NumParte").ToString,
                                        rd1("CodBarra").ToString,
                                        rd1("Nombre").ToString,
                                        vehiculo,
                                        rd1("UVenta").ToString,
                                        precio,
                                        PROVEEDOR,
                                        rd1("Medida").ToString,
                                        rd1("Observaciones").ToString,
                                        rd1("Ubicacion").ToString,
                                        existencias,
                                        rd1("NPiezas").ToString
)

                End If
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub grdcaptura_Click(sender As Object, e As EventArgs) Handles grdcaptura.Click
        Dim index As Integer = grdcaptura.CurrentRow.Index

        Dim CODIGO As String = ""


        CODIGO = grdcaptura.Rows(index).Cells(0).Value.ToString

        If File.Exists(My.Application.Info.DirectoryPath & "\ProductosImg" & baseseleccionada & "\" & CODIGO & ".jpg") Then
            PictureBox1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\ProductosImg" & baseseleccionada & "\" & CODIGO & ".jpg")
        End If
    End Sub

    Private Sub rbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles rbTodos.CheckedChanged
        If (rbTodos.Checked) Then
            grdcaptura.Rows.Clear()
            rbmarca.Checked = False
            cbovehiculo.Text = ""
            cboservicio.Text = ""
            cbodatos.Visible = False

            Try
                Dim vehiculo As Integer = 0
                Dim descirpcion As String = ""

                cnn1.Close() : cnn1.Open()
                cnn2.Close() : cnn2.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM refaccionaria"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then

                        vehiculo = rd1("IdVehiculo").ToString

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT Descripcion FROM vehiculo WHERE IdVehiculo=" & vehiculo & ""
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                descirpcion = rd2(0).ToString
                            End If
                        End If
                        rd2.Close()

                        grdcaptura.Rows.Add(rd1("CodigoPro").ToString,
                                            rd1("NumParte").ToString,
                                            rd1("CodBarra").ToString,
                                            rd1("Nombre").ToString,
                                           descirpcion
)

                    End If
                Loop
                rd1.Close()
                cnn1.Close()
                cnn2.Close()

            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub rbmarca_CheckedChanged(sender As Object, e As EventArgs) Handles rbmarca.CheckedChanged
        If (rbmarca.Checked) Then
            grdcaptura.Rows.Clear()
            rbTodos.Checked = False
            cbovehiculo.Text = ""
            cboservicio.Text = ""
            cbodatos.Visible = True

        End If
    End Sub

    Private Sub cbodatos_DropDown(sender As Object, e As EventArgs) Handles cbodatos.DropDown
        Try

            cbodatos.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand

            If (rbmarca.Checked) Then
                cmd5.CommandText = "SELECT DISTINCT Marca FROM refaccionaria WHERE Marca<>'' ORDER BY Marca"
            rd5 = cmd5.ExecuteReader
                Do While rd5.Read
                    If rd5.HasRows Then
                        cbodatos.Items.Add(rd5(0).ToString)
                    End If
                Loop
                rd5.Close()
                cnn5.Close()
            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub btnlimpiar_Click(sender As Object, e As EventArgs) Handles btnlimpiar.Click
        grdcaptura.Rows.Clear()
        cbovehiculo.Text = ""
        cboservicio.Text = ""
        cbodatos.Text = ""
        rbmarca.Checked = False
        rbTodos.Checked = False
        lblvehiculo.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        frmMenuPrincipal.Show()
    End Sub

    Private Sub cbovehiculo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbovehiculo.SelectedValueChanged
        lblservicio.Visible = True
        cboservicio.Visible = True

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT IdVehiculo FROM vehiculo WHERE Descripcion='" & cbovehiculo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    lblvehiculo.Text = rd1(0).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub
End Class
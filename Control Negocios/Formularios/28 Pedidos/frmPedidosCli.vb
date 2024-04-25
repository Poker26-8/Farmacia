Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class frmPedidosCli

    Dim direcicon As String = ""
    Dim idcliente As Integer = 0

    Private Sub cboCliente_DropDown(sender As Object, e As EventArgs) Handles cboCliente.DropDown
        Try
            cboCliente.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Cliente FROM pedidosven WHERE Cliente<>'' ORDER BY Cliente"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboCliente.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboPedido_DropDown(sender As Object, e As EventArgs) Handles cboPedido.DropDown
        Try
            cboPedido.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand

            If cboCliente.Text = "" Then
                cmd5.CommandText = "SELECT DISTINCT Folio FROM pedidosven WHERE Folio<>'' ORDER BY Folio"
            Else
                cmd5.CommandText = "SELECT DISTINCT Folio FROM pedidosven WHERE Cliente='" & cboCliente.Text & "' ORDER BY Folio"
            End If

            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboPedido.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub rbAsignar_CheckedChanged(sender As Object, e As EventArgs) Handles rbAsignar.CheckedChanged
        If (rbAsignar.Checked) Then

            btnEntrega.Visible = True
            btnreporte.Visible = False
            cboCliente.Text = ""
            cboPedido.Text = ""

            grdCaptura.Rows.Clear()
            grdCaptura.ColumnCount = 0
            grdCaptura.ColumnCount = 9
            With grdCaptura
                With .Columns(0)
                    .HeaderText = "Folio"
                    .Width = 60
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(1)
                    .HeaderText = "Codigo"
                    .Width = 60
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(2)
                    .HeaderText = "Nombre"
                    .Width = 60
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(3)
                    .HeaderText = "Unidad"
                    .Width = 60
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(4)
                    .HeaderText = "Cantidad"
                    .Width = 60
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(5)
                    .HeaderText = "Precio"
                    .Width = 60
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(6)
                    .HeaderText = "Total"
                    .Width = 60
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(7)
                    .HeaderText = "Fecha"
                    .Width = 60
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(8)
                    .HeaderText = "Usuario"
                    .Width = 60
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

            End With
        End If
    End Sub

    Private Sub cboPedido_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboPedido.SelectedValueChanged
        Try
            grdCaptura.Rows.Clear()

            Dim fecha As Date = Nothing
            Dim nfecha As String = ""

            cnn1.Close() : cnn1.Open()
            If cboCliente.Text = "" Then

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM pedidosven WHERE Folio='" & cboPedido.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        cboCliente.Text = rd1("Cliente").ToString
                        direcicon = rd1("Direccion").ToString
                    End If
                End If
                rd1.Close()

            End If

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM pedidosvendet WHERE Folio='" & cboPedido.Text & "'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then

                    fecha = rd1("Fecha").ToString
                    nfecha = Format(fecha, "yyyy-MM-dd HH:mm:ss")
                    grdCaptura.Rows.Add(rd1("Folio").ToString,
                                        rd1("Codigo").ToString,
                                        rd1("Nombre").ToString,
                                        rd1("Unidad").ToString,
                                        rd1("Cantidad").ToString,
                                        rd1("Precio").ToString,
                                        rd1("Total").ToString,
                                        nfecha,
                                        rd1("Usuario").ToString
)

                End If
            Loop


            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub frmPedidosCli_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rbAsignar.Checked = True
    End Sub

    Private Sub rbPendientes_CheckedChanged(sender As Object, e As EventArgs) Handles rbPendientes.CheckedChanged
        If (rbPendientes.Checked) Then
            btnEntrega.Visible = False
            btnreporte.Visible = True
            cboCliente.Text = ""
            cboPedido.Text = ""

            grdCaptura.Rows.Clear()
            grdCaptura.ColumnCount = 0
            grdCaptura.ColumnCount = 13
            With grdCaptura
                With .Columns(0)
                    .HeaderText = "Folio"
                    .Width = 60
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(1)
                    .HeaderText = "Cliente"
                    .Width = 60
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(2)
                    .HeaderText = "Dirección"
                    .Width = 60
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(3)
                    .HeaderText = "Precio"
                    .Width = 60
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(4)
                    .HeaderText = "Cantidad"
                    .Width = 60
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(5)
                    .HeaderText = "Totales"
                    .Width = 60
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(6)
                    .HeaderText = "A Cuenta"
                    .Width = 60
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(7)
                    .HeaderText = "Resta"
                    .Width = 60
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(8)
                    .HeaderText = "Status"
                    .Width = 60
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(9)
                    .HeaderText = "Chofer"
                    .Width = 60
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(10)
                    .HeaderText = "Vehiculo"
                    .Width = 60
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(11)
                    .HeaderText = "Fec Asignación"
                    .Width = 60
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(12)
                    .HeaderText = "Hor Asignación"
                    .Width = 60
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With
        End If
    End Sub

    Private Sub btnreporte_Click(sender As Object, e As EventArgs) Handles btnreporte.Click
        Try
            If (rbPendientes.Checked) Then

                Dim fecha As Date = Nothing
                Dim fecham As String = ""
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM pedidosasignados WHERE Status='ASIGNADO'"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        fecha = rd1("FechaAsignacion").ToString
                        fecham = Format(fecha, "yyyy-MM-dd")

                        grdCaptura.Rows.Add(rd1("Folio").ToString, rd1("Cliente").ToString, rd1("Direccion").ToString, rd1("Precio").ToString, rd1("Cantidad").ToString, rd1("Total").ToString, rd1("ACuenta").ToString, rd1("Resta").ToString, rd1("Status").ToString, rd1("Chofer").ToString, rd1("Vehiculo").ToString, fecham, rd1("HoraAsignacion").ToString)
                    End If
                Loop
                rd1.Close()
                cnn1.Close()

            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnEntrega_Click(sender As Object, e As EventArgs) Handles btnEntrega.Click
        Try
            If cboVehiculo.Text = "" Then MsgBox("Debe seleccionar un vehiculo") : cboVehiculo.Focus.Equals(True) : Exit Sub
            If cboChofer.Text = "" Then MsgBox("") : cboChofer.Focus.Equals(True) : Exit Sub



            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM pedidosasignados WHERE Folio='" & cboPedido.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then



                End If
            Else
                For monkey As Integer = 0 To grdCaptura.Rows.Count - 1

                    Dim folio As Integer = grdCaptura.Rows(monkey).Cells(0).Value.ToString
                    Dim CODIGO As String = grdCaptura.Rows(monkey).Cells(1).Value.ToString
                    Dim nombre As String = grdCaptura.Rows(monkey).Cells(2).Value.ToString
                    Dim cantida As Double = grdCaptura.Rows(monkey).Cells(4).Value.ToString
                    Dim precio As Double = grdCaptura.Rows(monkey).Cells(5).Value.ToString
                    Dim total As Double = grdCaptura.Rows(monkey).Cells(6).Value.ToString

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO pedidosasignados(Folio,IdCliente,Cliente,Direccion,Codigo,Nombre,Cantidad,Precio,Total,FechaAsignacion,HoraAsignacion,Fecha,Chofer,Vehiculo,Status) VALUES(" & folio & "," & idcliente & ",'" & cboCliente.Text & "','" & direcicon & "','" & CODIGO & "','" & nombre & "'," & cantida & "," & precio & "," & total & ",'" & Format(dtpAsignacion.Value, "yyyy-MM-dd") & "','" & Format(dtpinicio.Value, "HH:mm:ss") & "','" & Format(Date.Now, "yyyy/MM/dd HH:mm:ss") & "','" & cboChofer.Text & "','" & cboVehiculo.Text & "','ASIGNADO')"
                    If cmd2.ExecuteNonQuery() Then
                        MsgBox("Pedido asignado correctamente", vbInformation + vbOKOnly, titulocentral)
                    End If
                    cnn2.Close()
                Next
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboVehiculo_DropDown(sender As Object, e As EventArgs) Handles cboVehiculo.DropDown
        Try
            cboVehiculo.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT placa FROM vehiculo WHERE Placa<>'' AND StatusT=1 ORDER BY Placa"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboVehiculo.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboChofer_DropDown(sender As Object, e As EventArgs) Handles cboChofer.DropDown
        Try
            cboChofer.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Alias FROM usuarios WHERE Puesto='CHOFER' ORDER BY Alias"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboChofer.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboCliente_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboCliente.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Id FROM clientes WHERE Nombre='" & cboCliente.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    idcliente = rd1(0).ToString
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
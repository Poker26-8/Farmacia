Imports Microsoft.Office.Interop

Public Class frmRepSalidas

    Private Sub rbPrestamoEmpleado_CheckedChanged(sender As Object, e As EventArgs) Handles rbPrestamoEmpleado.CheckedChanged
        If (rbPrestamoEmpleado.Checked) Then

            rbAnticipoProveedor.Checked = False
            rbAbonoCredito.Checked = False
            rbGastosVenta.Checked = False
            rbGastosAdministracion.Checked = False
            rbGastosOperacion.Checked = False
            rbTodosGastos.Checked = False

            cboDatos.Visible = True
            cbotres.Visible = False

            grdCaptura.Rows.Clear()
            grdCaptura.ColumnCount = 0
            grdCaptura.ColumnCount = 6

            With grdCaptura
                With .Columns(0)
                    .HeaderText = "Folio"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(1)
                    .HeaderText = "Nombre"
                    .Width = 250
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(2)
                    .HeaderText = "Fecha"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(3)
                    .HeaderText = "Importe"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(4)
                    .HeaderText = "Saldo"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(5)
                    .HeaderText = "Observaciones"
                    .Width = 100
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With

        End If
    End Sub

    Private Sub rbAnticipoProveedor_CheckedChanged(sender As Object, e As EventArgs) Handles rbAnticipoProveedor.CheckedChanged
        If (rbAnticipoProveedor.Checked) Then

            rbPrestamoEmpleado.Checked = False
            rbAbonoCredito.Checked = False
            rbGastosVenta.Checked = False
            rbGastosAdministracion.Checked = False
            rbGastosOperacion.Checked = False
            rbTodosGastos.Checked = False
            cboDatos.Visible = True
            cbotres.Visible = False

            grdCaptura.Rows.Clear()
            grdCaptura.ColumnCount = 0
            grdCaptura.ColumnCount = 9
            With grdCaptura
                With .Columns(0)
                    .HeaderText = "Razon Social"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(1)
                    .HeaderText = " Fecha"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(2)
                    .HeaderText = "Efectivo"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(3)
                    .HeaderText = "Banco"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(4)
                    .HeaderText = "Referencia"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With


                With .Columns(5)
                    .HeaderText = "Tarjeta"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(6)
                    .HeaderText = "Transferencias"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(7)
                    .HeaderText = "Otro"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(8)
                    .HeaderText = "Observacion"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With

        End If
    End Sub

    Private Sub rbGastosVenta_CheckedChanged(sender As Object, e As EventArgs) Handles rbGastosVenta.CheckedChanged

        If (rbGastosVenta.Checked) Then

            rbPrestamoEmpleado.Checked = False
            rbAnticipoProveedor.Checked = False
            rbGastosAdministracion.Checked = False
            rbGastosOperacion.Checked = False
            rbTodosGastos.Checked = False
            cboDatos.Visible = False
            cbotres.Visible = True

            grdCaptura.Rows.Clear()
        End If

    End Sub

    Private Sub rbGastosAdministracion_CheckedChanged(sender As Object, e As EventArgs) Handles rbGastosAdministracion.CheckedChanged

        If (rbGastosAdministracion.Checked) Then

            rbPrestamoEmpleado.Checked = False
            rbAnticipoProveedor.Checked = False
            rbGastosVenta.Checked = False
            rbGastosOperacion.Checked = False
            rbTodosGastos.Checked = False

            cboDatos.Visible = False
            cbotres.Visible = True
            grdCaptura.Rows.Clear()

        End If

    End Sub

    Private Sub rbGastosOperacion_CheckedChanged(sender As Object, e As EventArgs) Handles rbGastosOperacion.CheckedChanged

        If (rbGastosOperacion.Checked) Then

            rbPrestamoEmpleado.Checked = False
            rbAnticipoProveedor.Checked = False
            rbGastosVenta.Checked = False
            rbGastosAdministracion.Checked = False

            cboDatos.Visible = False
            cbotres.Visible = True
            grdCaptura.Rows.Clear()

        End If

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

        Try

            grdCaptura.Rows.Clear()

            Dim desde As Date = mcdesde.SelectionStart.ToShortDateString
            Dim hasta As Date = mchasta.SelectionStart.ToShortDateString


            'prestamo a empleados
            If (rbPrestamoEmpleado.Checked) Then

                Dim folio As String = ""
                Dim nombre As String = ""
                Dim Fecha As Date = Nothing
                Dim Importe As Double = 0
                Dim Saldo As Double = 0
                Dim Observaciones As String = ""

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                If cboDatos.Text = "" Then
                    cmd1.CommandText = "SELECT Folio,Nombre,Fecha,Monto,Cargo,Nota FROM Saldosempleados WHERE Fecha between '" & Format(desde, "yyyy/MM/dd") & "' AND '" & Format(hasta, "yyyy/MM/dd") & "'"
                Else
                    cmd1.CommandText = "SELECT Folio,Nombre,Fecha,Monto,Cargo,Nota FROM Saldosempleados WHERE Fecha between '" & Format(desde, "yyyy/MM/dd") & "' AND '" & Format(hasta, "yyyy/MM/dd") & "' AND Nombre='" & cboDatos.Text & "'"
                End If
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then

                        folio = rd1("Folio").ToString
                        nombre = rd1("Nombre").ToString
                        Fecha = rd1("Fecha").ToString
                        Importe = rd1("Monto").ToString
                        Saldo = rd1("Cargo").ToString
                        Observaciones = rd1("Nota").ToString

                        grdCaptura.Rows.Add(folio, nombre, Format(Fecha, "yyyy/MM/dd"), Importe, Saldo, Observaciones)

                    End If
                Loop
                rd1.Close()
                cnn1.Close()

            End If

            'Anticipo a proveedores
            If (rbAnticipoProveedor.Checked) Then

                Dim razonsocial As String = ""
                Dim fecha As Date = Nothing
                Dim efectivo As Double = 0
                Dim banco As String = ""
                Dim referencia As String = ""
                Dim Tarjeta As Double = 0
                Dim Transferencia As Double = 0
                Dim Otro As Double = 0
                Dim observacion As String = ""


                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand

                If cboDatos.Text = "" Then
                    cmd1.CommandText = "SELECT Proveedor,Fecha,Efectivo,Banco,Referencia,Tarjeta,Transfe,Otro,Concepto FROM AbonoE WHERE Fecha between '" & Format(desde, "yyyy/MM/dd") & "' AND '" & Format(hasta, "yyyy/MM/dd") & "'"
                Else
                    cmd1.CommandText = "SELECT Proveedor,Fecha,Efectivo,Banco,Referencia,Tarjeta,Transfe,Otro,Concepto FROM AbonoE WHERE Fecha between '" & Format(desde, "yyyy/MM/dd") & "' AND '" & Format(hasta, "yyyy/MM/dd") & "' AND Proveedor='" & cboDatos.Text & "'"
                End If

                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then

                        razonsocial = rd1("Proveedor").ToString
                        fecha = rd1("Fecha").ToString
                        efectivo = rd1("Efectivo").ToString
                        banco = rd1("Banco").ToString
                        referencia = rd1("Referencia").ToString
                        Tarjeta = rd1("Tarjeta").ToString
                        Transferencia = rd1("Transfe").ToString
                        Otro = rd1("Otro").ToString
                        observacion = rd1("Concepto").ToString

                        grdCaptura.Rows.Add(razonsocial, Format(fecha, "yyyy/MM/dd"), efectivo, banco, referencia, Tarjeta, Transferencia, Otro, observacion)

                    End If
                Loop
                rd1.Close()
                cnn1.Close()

            End If

            'gastos de venta

            If (rbGastosVenta.Checked) Then

                Select Case cbotres.Text

                    Case Is = "Nómina"

                        Dim nombre As String = ""
                        Dim area As String = ""
                        Dim fecha As Date = Nothing
                        Dim horas As String = ""
                        Dim otraspercepciones As Double = 0
                        Dim descuentoprestamo As Double = 0
                        Dim sueldoneto As Double = 0
                        Dim otrosdescuentos As Double = 0
                        Dim egresos As Double = 0

                        cnn1.Close() : cnn1.Open()
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText = "SELECT Nombre,Area,Fecha,Horas,OtrosP,Descuento,SueldoNeto,OtrosD,SueldoNeto FROM Nomina where Area='VENTAS' AND  Fecha between '" & Format(desde, "yyyy/MM/dd") & "' AND '" & Format(hasta, "yyyy/MM/dd") & "'"
                        rd1 = cmd1.ExecuteReader
                        Do While rd1.Read
                            If rd1.HasRows Then

                                nombre = rd1("Nombre").ToString
                                area = rd1("Area").ToString
                                fecha = rd1("Fecha").ToString
                                horas = rd1("Horas").ToString
                                otraspercepciones = rd1("OtrosP").ToString
                                descuentoprestamo = rd1("Descuento").ToString
                                sueldoneto = rd1("SueldoNeto").ToString
                                otrosdescuentos = rd1("OtrosD").ToString
                                egresos = rd1("SueldoNeto").ToString

                                grdCaptura.Rows.Add(nombre, area, Format(fecha, "yyyy/MM/dd"), horas, otraspercepciones, descuentoprestamo, sueldoneto, otrosdescuentos, egresos)
                            End If
                        Loop
                        rd1.Close()
                        cnn1.Close()

                    Case Is = "Otros Gastos"

                        Dim tipo As String = ""
                        Dim concepto As String = ""
                        Dim folio As String = ""
                        Dim fecha As Date = Nothing
                        Dim efectivo As Double = 0
                        Dim Tarjeta As Double = 0
                        Dim transferencia As Double = 0
                        Dim total As Double = 0
                        Dim nota As String = 0
                        Dim usuario As String = ""

                        cnn1.Close() : cnn1.Open()
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText = "SELECT Tipo,Concepto,Folio,Fecha,Efectivo,Tarjeta,Transfe,Total,Nota,Usuario FROM OtrosGastos WHERE Tipo='VENTAS' AND Fecha between '" & Format(desde, "yyyy/MM/dd") & "' AND '" & Format(hasta, "yyyy/MM/dd") & "'"
                        rd1 = cmd1.ExecuteReader
                        Do While rd1.Read
                            If rd1.HasRows Then

                                tipo = rd1("Tipo").ToString
                                concepto = rd1("Concepto").ToString
                                folio = rd1("Folio").ToString
                                fecha = rd1("Fecha").ToString
                                efectivo = rd1("Efectivo").ToString
                                Tarjeta = rd1("Tarjeta").ToString
                                transferencia = rd1("Transfe").ToString
                                total = rd1("Total").ToString
                                nota = rd1("Nota").ToString
                                usuario = rd1("Usuario").ToString

                                grdCaptura.Rows.Add(tipo, concepto, folio, Format(fecha, "yyyy/MM/dd"), efectivo, Tarjeta, transferencia, total, nota, usuario)

                            End If
                        Loop
                        rd1.Close()
                        cnn1.Close()

                End Select

            End If


            If (rbGastosAdministracion.Checked) Then

                Select Case cbotres.Text

                    Case Is = "Nómina"

                        Dim nombre As String = ""
                        Dim area As String = ""
                        Dim fecha As Date = Nothing
                        Dim horas As String = ""
                        Dim otraspercepciones As Double = 0
                        Dim descuentoprestamo As Double = 0
                        Dim sueldoneto As Double = 0
                        Dim otrosdescuentos As Double = 0
                        Dim egresos As Double = 0

                        cnn1.Close() : cnn1.Open()
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText = "SELECT Nombre,Area,Fecha,Horas,OtrosP,Descuento,SueldoNeto,OtrosD,SueldoNeto FROM Nomina WHERE Area='ADMINISTRACIÓN' AND Fecha between '" & Format(desde, "yyyy/MM/dd") & "' AND '" & Format(hasta, "yyyy/MM/dd") & "'"
                        rd1 = cmd1.ExecuteReader
                        Do While rd1.Read
                            If rd1.HasRows Then

                                nombre = rd1("Nombre").ToString
                                area = rd1("Area").ToString
                                fecha = rd1("Fecha").ToString
                                horas = rd1("Horas").ToString
                                otraspercepciones = rd1("OtrosP").ToString
                                descuentoprestamo = rd1("Descuento").ToString
                                sueldoneto = rd1("SueldoNeto").ToString
                                otrosdescuentos = rd1("OtrosD").ToString
                                egresos = rd1("SueldoNeto").ToString

                                grdCaptura.Rows.Add(nombre, area, Format(fecha, "yyyy/MM/dd"), horas, otraspercepciones, descuentoprestamo, sueldoneto, otrosdescuentos, egresos)

                            End If
                        Loop
                        rd1.Close()
                        cnn1.Close()

                    Case Is = "Otros Gastos"

                        Dim tipo As String = ""
                        Dim concepto As String = ""
                        Dim folio As String = ""
                        Dim fecha As Date = Nothing
                        Dim efectivo As Double = 0
                        Dim Tarjeta As Double = 0
                        Dim transferencia As Double = 0
                        Dim total As Double = 0
                        Dim nota As String = 0
                        Dim usuario As String = ""

                        cnn1.Close() : cnn1.Open()
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText = "SELECT Tipo,Concepto,Folio,Fecha,Efectivo,Tarjeta,Transfe,Total,Nota,Usuario FROM OtrosGastos WHERE Tipo='ADMINISTRACION' AND Fecha between '" & Format(desde, "yyyy/MM/dd") & "' AND '" & Format(hasta, "yyyy/MM/dd") & "'"
                        rd1 = cmd1.ExecuteReader
                        Do While rd1.Read
                            If rd1.HasRows Then
                                tipo = rd1("Tipo").ToString
                                concepto = rd1("Concepto").ToString
                                folio = rd1("Folio").ToString
                                fecha = rd1("Fecha").ToString
                                efectivo = rd1("Efectivo").ToString
                                Tarjeta = rd1("Tarjeta").ToString
                                transferencia = rd1("Transfe").ToString
                                total = rd1("Total").ToString
                                nota = rd1("Nota").ToString
                                usuario = rd1("Usuario").ToString

                                grdCaptura.Rows.Add(tipo, concepto, folio, Format(fecha, "yyyy/MM/dd"), efectivo, Tarjeta, transferencia, total, nota, usuario)

                            End If
                        Loop
                        rd1.Close()
                        cnn1.Close()

                End Select

            End If

            If (rbGastosOperacion.Checked) Then

                Select Case cbotres.Text
                    Case Is = "Nómina"
                        Dim nombre As String = ""
                        Dim area As String = ""
                        Dim fecha As Date = Nothing
                        Dim horas As String = ""
                        Dim otraspercepciones As Double = 0
                        Dim descuentoprestamo As Double = 0
                        Dim sueldoneto As Double = 0
                        Dim otrosdescuentos As Double = 0
                        Dim egresos As Double = 0

                        cnn1.Close() : cnn1.Open()
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText = "SELECT Nombre,Area,Fecha,Horas,OtrosP,Descuento,SueldoNeto,OtrosD,SueldoNeto FROM Nominas WHERE Area='OPERACIÓN' AND Fecha between '" & Format(desde, "yyyy/MM/dd") & "' AND '" & Format(hasta, "yyyy/MM/dd") & "'"
                        rd1 = cmd1.ExecuteReader
                        Do While rd1.Read
                            If rd1.HasRows Then

                                nombre = rd1("Nombre").ToString
                                area = rd1("Area").ToString
                                fecha = rd1("Fecha").ToString
                                horas = rd1("Horas").ToString
                                otraspercepciones = rd1("OtrosP").ToString
                                descuentoprestamo = rd1("Descuento").ToString
                                sueldoneto = rd1("SueldoNeto").ToString
                                otrosdescuentos = rd1("OtrosD").ToString
                                egresos = rd1("SueldoNeto").ToString

                                grdCaptura.Rows.Add(nombre, area, Format(fecha, "yyyy/MM/dd"), horas, otraspercepciones, descuentoprestamo, sueldoneto, otrosdescuentos, egresos)
                            End If
                        Loop
                        rd1.Close()
                        cnn1.Close()

                    Case Is = "Otros Gastos"

                        Dim tipo As String = ""
                        Dim concepto As String = ""
                        Dim folio As String = ""
                        Dim fecha As Date = Nothing
                        Dim efectivo As Double = 0
                        Dim Tarjeta As Double = 0
                        Dim transferencia As Double = 0
                        Dim total As Double = 0
                        Dim nota As String = 0
                        Dim usuario As String = ""

                        cnn1.Close() : cnn1.Open()
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText = "SELECT Tipo,Concepto,Folio,Fecha,Efectivo,Tarjeta,Transfe,Total,Nota,Usuario FROM OtrosGastos WHERE Tipo='OPERACION' AND Fecha between '" & Format(desde, "yyyy/MM/dd") & "' AND '" & Format(hasta, "yyyy/MM/dd") & "'"
                        rd1 = cmd1.ExecuteReader
                        Do While rd1.Read
                            If rd1.HasRows Then

                                tipo = rd1("Tipo").ToString
                                concepto = rd1("Concepto").ToString
                                folio = rd1("Folio").ToString
                                fecha = rd1("Fecha").ToString
                                efectivo = rd1("Efectivo").ToString
                                Tarjeta = rd1("Tarjeta").ToString
                                transferencia = rd1("Transfe").ToString
                                total = rd1("Total").ToString
                                nota = rd1("Nota").ToString
                                usuario = rd1("Usuario").ToString

                                grdCaptura.Rows.Add(tipo, concepto, folio, Format(fecha, "yyyy/MM/dd"), efectivo, Tarjeta, transferencia, total, nota, usuario)

                            End If
                        Loop
                        rd1.Close()
                        cnn1.Close()

                End Select
            End If

            If (rbTodosGastos.Checked) Then

                Dim tipo As String = ""
                Dim concepto As String = ""
                Dim folio As String = ""
                Dim fecha As Date = Nothing
                Dim efectivo As Double = 0
                Dim Tarjeta As Double = 0
                Dim transferencia As Double = 0
                Dim total As Double = 0
                Dim nota As String = 0
                Dim usuario As String = ""

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Tipo,Concepto,Folio,Fecha,Efectivo,Tarjeta,Transfe,Total,Nota,Usuario FROM OtrosGastos WHERE Fecha between '" & Format(desde, "yyyy/MM/dd") & "' AND '" & Format(hasta, "yyyy/MM/dd") & "'"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then

                        tipo = rd1("Tipo").ToString
                        concepto = rd1("Concepto").ToString
                        folio = rd1("Folio").ToString
                        fecha = rd1("Fecha").ToString
                        efectivo = rd1("Efectivo").ToString
                        Tarjeta = rd1("Tarjeta").ToString
                        transferencia = rd1("Transfe").ToString
                        total = rd1("Total").ToString
                        nota = rd1("Nota").ToString
                        usuario = rd1("Usuario").ToString

                        grdCaptura.Rows.Add(tipo, concepto, folio, Format(fecha, "yyyy/MM/dd"), efectivo, Tarjeta, transferencia, total, nota, usuario)

                    End If
                Loop
                rd1.Close()
                cnn1.Close()
            End If

            If (optNomina.Checked) Then


                Dim tipo As String = ""
                Dim concepto As String = ""
                Dim folio As String = ""
                Dim fecha As Date = Nothing
                Dim efectivo As Double = 0
                Dim Tarjeta As Double = 0
                Dim transferencia As Double = 0
                Dim total As Double = 0
                Dim nota As String = 0
                Dim usuario As String = ""

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Tipo,Concepto,Folio,Fecha,Efectivo,Tarjeta,Transfe,Total,Nota,Usuario FROM OtrosGastos WHERE Fecha between '" & Format(desde, "yyyy/MM/dd") & "' AND '" & Format(hasta, "yyyy/MM/dd") & "' AND Concepto='NOMINA'"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then

                        tipo = rd1("Tipo").ToString
                        concepto = rd1("Concepto").ToString
                        folio = rd1("Folio").ToString
                        fecha = rd1("Fecha").ToString
                        efectivo = rd1("Efectivo").ToString
                        Tarjeta = rd1("Tarjeta").ToString
                        transferencia = rd1("Transfe").ToString
                        total = rd1("Total").ToString
                        nota = rd1("Nota").ToString
                        usuario = rd1("Usuario").ToString

                        grdCaptura.Rows.Add(tipo, concepto, folio, Format(fecha, "yyyy/MM/dd"), efectivo, Tarjeta, transferencia, total, nota, usuario)

                    End If
                Loop
                rd1.Close()
                cnn1.Close()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub cboDatos_DropDown(sender As Object, e As EventArgs) Handles cboDatos.DropDown

        Try
            cboDatos.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand

            If (rbPrestamoEmpleado.Checked) Then
                cmd5.CommandText = "SELECT DISTINCT Nombre FROM SaldosEmpleados WHERE Nombre<>'' ORDER BY Nombre"
            End If

            If (rbAnticipoProveedor.Checked) Then
                cmd5.CommandText = "SELECT DISTINCT Proveedor FROM AbonoE WHERE Proveedor<>'' ORDER BY Proveedor"
            End If


            If (rbGastosVenta.Checked) Then
                Exit Sub
            End If

            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboDatos.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        If grdCaptura.Rows.Count = 0 Then
            MsgBox("No hay Información para exportar", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            Exit Sub
        End If
        If MsgBox("¿Deseas exportar la información a un archivo de Excel?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            btnNuevo.Enabled = False
            Dim exApp As New Excel.Application
            Dim exBook As Excel.Workbook
            Dim exSheet As Excel.Worksheet

            Try
                exBook = exApp.Workbooks.Add
                exSheet = exBook.Worksheets.Application.ActiveSheet

                exSheet.Columns("A").NumberFormat = "@"
                exSheet.Columns("B").NumberFormat = "@"
                exSheet.Columns("C").NumberFormat = "@"
                exSheet.Columns("D").NumberFormat = "@"

                Dim NCol As Integer = grdCaptura.ColumnCount
                Dim NRow As Integer = grdCaptura.RowCount

                For i As Integer = 1 To NCol
                    exSheet.Cells.Item(1, i) = grdCaptura.Columns(i - 1).HeaderText.ToString
                Next

                For Fila As Integer = 0 To NRow - 1
                    For Col As Integer = 0 To NCol - 1
                        exSheet.Cells.Item(Fila + 2, Col + 1) = grdCaptura.Rows(Fila).Cells(Col).Value
                    Next
                    My.Application.DoEvents()
                Next

                exSheet.Rows.Item(1).Font.Bold = 1
                exSheet.Rows.Item(1).HorizontalAlignment = 3
                exSheet.Columns.AutoFit()

                MsgBox("Datos exportados correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                exApp.Application.Visible = True
                exSheet = Nothing
                exBook = Nothing
                exApp = Nothing
                btnNuevo.Enabled = True

            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub cbotres_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbotres.SelectedValueChanged

        If cbotres.Text = "Nómina" Then

            grdCaptura.Rows.Clear()
            grdCaptura.ColumnCount = 0
            grdCaptura.ColumnCount = 9
            With grdCaptura
                With .Columns(0)
                    .HeaderText = "Nombre"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(1)
                    .HeaderText = "Area"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(2)
                    .HeaderText = "Fecha"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(3)
                    .HeaderText = "Horas"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(4)
                    .HeaderText = "Otras Percepciones"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(5)
                    .HeaderText = "Descuentos"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(6)
                    .HeaderText = "Sueldo Neto"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(7)
                    .HeaderText = "Otros Descuentos"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(8)
                    .HeaderText = "Total Ingresos"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With


        End If

        If cbotres.Text = "Otros Gastos" Then

            grdCaptura.Rows.Clear()
            grdCaptura.ColumnCount = 0
            grdCaptura.ColumnCount = 10
            With grdCaptura

                With .Columns(0)
                    .HeaderText = "Area"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(1)
                    .HeaderText = "Concepto"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(2)
                    .HeaderText = "Folio"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(3)
                    .HeaderText = "Fecha"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(4)
                    .HeaderText = "Efectivo"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(5)
                    .HeaderText = "Tarjeta"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(6)
                    .HeaderText = "Transferencia"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(7)
                    .HeaderText = "Total"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(8)
                    .HeaderText = "Nota"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(9)
                    .HeaderText = "Usuario"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

            End With
        End If

    End Sub

    Private Sub rbTodosGastos_CheckedChanged(sender As Object, e As EventArgs) Handles rbTodosGastos.CheckedChanged

        If (rbTodosGastos.Checked) Then

            rbAnticipoProveedor.Checked = False
            rbAnticipoProveedor.Checked = False
            rbGastosVenta.Checked = False
            rbGastosAdministracion.Checked = False
            rbGastosOperacion.Checked = False

            cboDatos.Visible = False
            cbotres.Visible = False

            grdCaptura.Rows.Clear()
            grdCaptura.ColumnCount = 0
            grdCaptura.ColumnCount = 10

            With grdCaptura
                With .Columns(0)
                    .HeaderText = "Tipo"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(1)
                    .HeaderText = "Concepto"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(2)
                    .HeaderText = "Folio"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(3)
                    .HeaderText = "Fecha"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(4)
                    .HeaderText = "Efectivo"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(5)
                    .HeaderText = "Tarjeta"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(6)
                    .HeaderText = "Transferencia"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(7)
                    .HeaderText = "Total"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(8)
                    .HeaderText = "Nota"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(9)
                    .HeaderText = "Usuario"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

            End With
        End If

    End Sub

    Private Sub optNomina_CheckedChanged(sender As Object, e As EventArgs) Handles optNomina.CheckedChanged
        If (optNomina.Checked) Then

            rbAnticipoProveedor.Checked = False
            rbAnticipoProveedor.Checked = False
            rbGastosVenta.Checked = False
            rbGastosAdministracion.Checked = False
            rbGastosOperacion.Checked = False

            cboDatos.Visible = False
            cbotres.Visible = False

            grdCaptura.Rows.Clear()
            grdCaptura.ColumnCount = 0
            grdCaptura.ColumnCount = 10

            With grdCaptura
                With .Columns(0)
                    .HeaderText = "Tipo"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(1)
                    .HeaderText = "Concepto"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(2)
                    .HeaderText = "Folio"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(3)
                    .HeaderText = "Fecha"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(4)
                    .HeaderText = "Efectivo"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(5)
                    .HeaderText = "Tarjeta"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(6)
                    .HeaderText = "Transferencia"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(7)
                    .HeaderText = "Total"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(8)
                    .HeaderText = "Nota"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(9)
                    .HeaderText = "Usuario"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

            End With
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub frmRepSalidas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
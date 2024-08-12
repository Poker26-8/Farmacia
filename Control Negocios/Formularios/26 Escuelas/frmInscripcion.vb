Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmInscripcion

    Private Sub frmInscripcion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtfecha.Text = FormatDateTime(Date.Now, DateFormat.ShortDate)
        folio_ins()
        matricula()
    End Sub

    Private Sub matricula()
        Try
            cnn3.Close() : cnn3.Open()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText =
                "select MAX(Matricula) from Alumnos"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    txtmatricula.Text = IIf(rd3(0).ToString = "", 0, rd3(0).ToString()) + 1
                End If
            Else
                txtmatricula.Text = "1"
            End If
            rd3.Close()
            cnn3.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn3.Close()
        End Try
    End Sub

    Private Sub folio_ins()
        Try
            cnn2.Close() : cnn2.Open()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select MAX(Id) from Alumnos"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    lblfolio.Text = IIf(rd2(0).ToString = "", 0, rd2(0).ToString()) + 1
                End If
            Else
                lblfolio.Text = "1"
            End If
            rd2.Close()
            cnn2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn2.Close()
        End Try
    End Sub

    Private Sub cbogrupo_DropDown(sender As Object, e As EventArgs) Handles cbogrupo.DropDown
        cbogrupo.Items.Clear()

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Nombre from Grupos order by Nombre"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    cbogrupo.Items.Add(rd1(0).ToString())
                End If
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbogrupo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbogrupo.SelectedValueChanged
        Dim cupo As Integer = 0
        Dim conteo_grupo As Integer = 0

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Inicio,Termino,Cupo from Grupos where Nombre='" & cbogrupo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txthorario.Text = rd1("Inicio").ToString() & " - " & rd1("Termino").ToString()
                    cupo = rd1("Cupo").ToString()
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select COUNT(Id) from Alumnos where Grupo='" & cbogrupo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    conteo_grupo = IIf(rd1(0).ToString() = "", 0, rd1(0).ToString()) + 1
                End If
            End If
            rd1.Close() : cnn1.Close()

            If conteo_grupo >= cupo Then
                MsgBox("No es posible la inscripción ya que el grupo está lleno.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                txthorario.Text = ""
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub txtmatricula_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtmatricula.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Nombre,Telefono,Tutor,Contacto,Calle,N_Int,N_Ext,Colonia,CP,Delegacion,Estado from Alumnos where Matricula=" & txtmatricula.Text & ""
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        txtNombre.Text = rd1("Nombre").ToString()
                        txttelefono.Text = rd1("Telefono").ToString()
                        txttutor.Text = rd1("Tutor").ToString()
                        txtcontacto.Text = rd1("Contacto").ToString()
                        txtcalle.Text = rd1("Calle").ToString()
                        txtnint.Text = rd1("N_Int").ToString()
                        txtnext.Text = rd1("N_Ext").ToString()
                        txtcolonia.Text = rd1("Colonia").ToString()
                        txtcp.Text = rd1("CP").ToString()
                        txtdelegacion.Text = rd1("Delegacion").ToString()
                        txtestado.Text = rd1("Estado").ToString()
                    End If
                End If
                rd1.Close() : cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
            txttelefono.Focus().Equals(True)
        End If
    End Sub

    Private Sub txttelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttelefono.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            dtpNace.Focus().Equals(True)
        End If
    End Sub

    Private Sub txttutor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttutor.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtcontacto.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtcontacto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcontacto.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtcalle.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtcalle_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcalle.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtnext.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtnint_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnint.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtcolonia.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtnext_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnext.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtnint.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtcolonia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcolonia.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtcp.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtcp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcp.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtdelegacion.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtdelegacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtdelegacion.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtestado.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtestado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtestado.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cbogrupo.Focus().Equals(True)
        End If
    End Sub

    Private Sub cbogrupo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbogrupo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            dtpinicio.Focus().Equals(True)
        End If
    End Sub

    Private Sub cbocuota_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbocuota.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            'Baja el registro de la inscripción
            If cbocuota.Text = "" Then
                ComboBox1.Focus().Equals(True)
            Else
                grdcaptura.Rows.Add("0", cbocuota.Text, FormatDateTime(Date.Now, DateFormat.ShortDate), FormatNumber(txtpago.Text, 2))
                RecalculaTotal()
                ComboBox1.Focus().Equals(True)
            End If
        End If
    End Sub

    Public Sub RecalculaTotal()
        Dim total As Double = 0
        For C9 As Integer = 0 To grdcaptura.Rows.Count - 1
            total = total + CDbl(grdcaptura.Rows(C9).Cells(3).Value.ToString())
        Next
        TextBox2.Text = FormatNumber(total, 2)
    End Sub

    Private Sub txtcontraseña_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcontraseña.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtcontraseña.Text <> "" Then
                Try
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Alias from Usuarios where Clave='" & txtcontraseña.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            lblusuario.Text = rd1("Alias").ToString()
                        End If
                    Else
                        MsgBox("Contraseña incorrecta, inténtalo de nuevo.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        rd1.Close() : cnn1.Close()
                        txtcontraseña.SelectAll()
                        Exit Sub
                    End If
                    rd1.Close() : cnn1.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString())
                    cnn1.Close()
                End Try
            End If
            Button1.Focus().Equals(True)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtNombre.Text = "" Then MsgBox("Escribe el nombre del alumno.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtNombre.Focus().Equals(True) : Exit Sub
        If txtmatricula.Text = "" Then MsgBox("Escribe le número de matricula.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtmatricula.Focus().Equals(True) : Exit Sub
        If txttutor.Text = "" Then MsgBox("Escribe el nombre del padre o tutor.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txttutor.Focus().Equals(True) : Exit Sub
        If txtcontacto.Text = "" Then MsgBox("Escribe el contacto del padre o tutor.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtcontacto.Focus().Equals(True) : Exit Sub
        If lblusuario.Text = "" Then MsgBox("Escribe tu contraseña paara continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtcontraseña.Focus().Equals(True) : Exit Sub

        If cbogrupo.Text = "" Then MsgBox("Es necesario seleccionar un grupo para realizar la inscripción.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbogrupo.Focus().Equals(True) : Exit Sub
        If cbocuota.Text = "" Then MsgBox("Es necesario seleccionar una cuota de inscripción para realizar el registro.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbocuota.Focus.Equals(True) : Exit Sub
        If ComboBox1.Text = "" Then MsgBox("Es necesario elegir un curso para realizar la inscripción.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : ComboBox1.Focus().Equals(True) : Exit Sub

        If grdcaptura.Rows.Count = 0 Then MsgBox("Necesitas agregar información para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : ComboBox1.Focus().Equals(True) : Exit Sub

        Dim sSql As String = ""
        Dim MyId As Integer = 0

        If MsgBox("¿Deseas inscribir a este alumno?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Dim id_grupo As Integer = 0
            Dim fecha_inscripcion As String = ""

            Try
                cnn1.Close() : cnn1.Open()

                'Saca Id del grupo
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Id from Grupos where Nombre='" & cbogrupo.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        id_grupo = rd1(0).ToString()
                    End If
                Else
                    MsgBox("El grupo no se encuentra en el catálogo.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    cbogrupo.Focus().Equals(True)
                    rd1.Close() : cnn1.Close()
                    Exit Sub
                End If
                rd1.Close()

                'Valida el numero de matricula y el nombre
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Baja from Alumnos where Nombre='" & txtNombre.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        If rd1("Baja").ToString() <> "" Then
                            If MsgBox("Alumno en estado de baja." & vbNewLine & "¿Deseas reinscribir al alumno?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbCancel Then
                                rd1.Close() : cnn1.Close()
                                Exit Sub
                            End If

                            cnn2.Close() : cnn2.Open()
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText =
                                "update Alumnos set status=1, baja='' where Nombre='" & txtNombre.Text & "'"
                            cmd2.ExecuteNonQuery()
                            cnn2.Close()
                        Else
                            MsgBox("El alumno se encuentra activo en la base de datos. Por lo que no puedes reincribirlo hasta darlo de baja primero.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                            rd1.Close() : cnn1.Close()
                            Exit Sub
                        End If
                    End If
                Else
                    cnn2.Close() : cnn2.Open()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "insert into Alumnos(Nombre,Matricula,Telefono,Tutor,Contacto,Calle,N_Int,N_Ext,Colonia,CP,Delegacion,Estado,Id_Grupo,Grupo,Lunes,Martes,Miercoles,Jueves,Viernes,Sabado,Inscripcion,F_Nacimiento,F_Inicio,Comentario,Curso,Status,Baja) values('" & txtNombre.Text & "'," & txtmatricula.Text & ",'" & txttelefono.Text & "','" & txttutor.Text & "','" & txtcontacto.Text & "','" & txtcalle.Text & "','" & txtnint.Text & "','" & txtnext.Text & "','" & txtcolonia.Text & "','" & txtcp.Text & "','" & txtdelegacion.Text & "','" & txtestado.Text & "'," & id_grupo & ",'" & cbogrupo.Text & "'," & IIf(optlunes.Checked = True, 1, 0) & "," & IIf(optmartes.Checked = True, 1, 0) & "," & IIf(optmiercoles.Checked = True, 1, 0) & "," & IIf(optjueves.Checked = True, 1, 0) & "," & IIf(optviernes.Checked = True, 1, 0) & "," & IIf(optsabado.Checked = True, 1, 0) & ",'" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(dtpNace.Value, "yyyy-MM-dd") & "','" & Format(dtpinicio.Value, "yyyy-MM-dd") & "','" & txtcomentario.Text & "','" & ComboBox1.Text & "',1,'')"
                    If cmd2.ExecuteNonQuery Then
                        MsgBox("Alumno inscrito correctamente. Recuerdo realizar el abono de su pago de inscripción.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        If CheckBox7.Checked = True Then
                            If MsgBox("¿Deseas imprimir el comprobante de inscripción?", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") = vbOK Then
                                'Genera PDF
                                Inserta_Inscripcion()
                                PDF_Inscripcion()
                            End If
                        End If
                    End If
                    cnn2.Close()

                End If
                rd1.Close()

                Do Until MyId <> 0
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Id from Alumnos where Nombre='" & txtNombre.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            MyId = rd1(0).ToString()
                        End If
                    End If
                    rd1.Close()
                Loop

                'cmd1 = cnn1.CreateCommand
                'cmd1.CommandText =
                '    "insert into MovEscuela(Id_Alumno,Nombre,Movimiento,Monto,Fecha,Usuario) values(" & MyId & ",'" & txtNombre.Text & "','Inscripción',0,'" & FormatDateTime(Date.Now, DateFormat.ShortDate) & "','" & lblusuario.Text & "')"
                'cmd1.ExecuteNonQuery()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Id from Clientes where Nombre='" & txtNombre.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                Else
                    cnn2.Close() : cnn2.Open()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                    "insert into Clientes(Nombre,RazonSocial,Tipo,Telefono,Calle,Colonia,CP,Delegacion,Entidad,Pais,NInterior,NExterior) values('" & txtNombre.Text & "','" & txtNombre.Text & "','Lista','" & txttelefono.Text & "','" & txtcalle.Text & "','" & txtcolonia.Text & "','" & txtcp.Text & "','" & txtdelegacion.Text & "','" & txtestado.Text & "','MEXICO','" & txtnint.Text & "','" & txtnext.Text & "')"
                    cmd2.ExecuteNonQuery()

                    cnn2.Close()
                End If
                rd1.Close()
                cnn1.Close()

                'Tiene que realizar los procesos en un ciclo porque tiene que recorrer cada registro del grid e ir afectando los saldos
                '   (Se tiene que revisar cómo se hacen los nuevos movimientos de saldos con la nueva tabla)

                Try
                    cnn2.Close() : cnn2.Open()

                    Dim cliente As String = txtNombre.Text
                    Dim MyIdCliente As Integer = MyId
                    Dim usuario As String = ""

                    For guma As Integer = 0 To grdcaptura.Rows.Count - 1
                        'Extrae los datos para el guardado
                        Dim descripcion As String = grdcaptura.Rows(guma).Cells(1).Value.ToString()
                        Dim monto_pagar As Double = grdcaptura.Rows(guma).Cells(3).Value
                        Dim fecha_pago As Date = grdcaptura.Rows(guma).Cells(2).Value
                        Dim MyFolio As Integer = 0

                        'Inserta en Ventas
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "insert into Ventas(IdCliente,Cliente,Direccion,Subtotal,IVA,Totales,Descuento,Devolucion,ACuenta,Resta,Usuario,FVenta,HVenta,FPago,FCancelado,MontoCance,Status,Comisionista,Facturado,Concepto,N_Traslado,Corte,CorteU,MontoSinDesc,Cargado,FEntrega,Entrega,Comentario,CantidadE,StatusE,FolMonedero,CodFactura,CargadoF,IP,Formato) values(" & MyIdCliente & ",'" & txtNombre.Text & "',''," & monto_pagar & ",0," & monto_pagar & ",0,0,0," & monto_pagar & ",'" & lblusuario.Text & "','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','" & Format(fecha_pago, "yyyy-MM-dd") & "','',0,'RESTA','',0,'',0,0,0,0,0,'',0,'',0,0,'','',0,'" & dameIP2() & "','TICKET')"
                        cmd2.ExecuteNonQuery()

                        Do Until MyFolio <> 0
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText =
                                "select MAX(Folio) from Ventas"
                            rd2 = cmd2.ExecuteReader
                            If rd2.HasRows Then
                                If rd2.Read Then
                                    MyFolio = rd2(0).ToString()
                                End If
                            End If
                            rd2.Close()
                        Loop

                        'Inserta en AbonoI
                        Dim saldo As Double = 0

                        'Procesos de guardado en Abono
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "select Saldo from AbonoI where Id=(select MAX(Id) from AbonoI where Cliente='" & txtNombre.Text & "')"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                saldo = IIf(rd2(0).ToString() = "", 0, rd2(0).ToString()) + monto_pagar
                            End If
                        Else
                            saldo = monto_pagar
                        End If
                        rd2.Close()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "insert into AbonoI(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Banco,Referencia,Usuario,MontoSF,Comentario) values(" & MyFolio & "," & MyId & ",'" & txtNombre.Text & "','NOTA VENTA','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "'," & monto_pagar & ",0," & saldo & ",'','','" & lblusuario.Text & "'," & monto_pagar & ",'')"
                        cmd2.ExecuteNonQuery()

                        'Inserta en VentasDetalle
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "insert into VentasDetalle(Folio,Codigo,Nombre,Unidad,Cantidad,CostoVP,CostoVUE,Precio,Total,PrecioSinIVA,TotalSinIVA,Fecha,Comisionista,Facturado,Depto,Grupo,CostVR,Descto,VDCosteo,TotalIEPS,TasaIEPS,Caducidad,Lote,CantidadE,Promo_Monedero,Unico,Descuento) values(" & MyFolio & ",'XXXX','" & descripcion & "','SERV',1,0,0," & monto_pagar & "," & monto_pagar & "," & monto_pagar & "," & monto_pagar & ",'" & Format(Date.Now, "yyyy-MM-dd") & "','','0','PAGO ESCUELA','PAGO ESCUELA','0',0,0,0,0,'','',0,0,0,0)"
                        cmd2.ExecuteNonQuery()
                    Next
                    cnn2.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString())
                    cnn2.Close()
                End Try

                Button2.PerformClick()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub Inserta_Inscripcion()
        Dim oData As New ToolKitSQL.oledbdata
        Dim sSql As String = ""
        Dim a_cnn As OleDb.OleDbConnection = New OleDb.OleDbConnection
        Dim sinfo As String = ""
        Dim dr As DataRow = Nothing
        Dim dt As New DataTable

        Dim my_folio As Integer = 0
        Dim MyStatus As String = ""
        Dim ACuenta As Double = 0
        Dim Resta As Double = 0
        Dim tel_cliente As String = ""

        With oData
            If .dbOpen(a_cnn, Direcc_Access, sinfo) Then
                .runSp(a_cnn, "delete from Inscripciones", sinfo)
                sinfo = ""

                'Inserta en la tabla de Ventas
                If .runSp(a_cnn, "insert into Inscripciones(Nombre,Grupo,Telefono,Tutor,Contacto,Calle,[NExt],NInt,Colonia,CP,Delegacion,Estado,Lunes,Martes,Miercoles,Jueves,Viernes,Sabado,Comentario,Nacimiento,Cuota,Inicio,Horario) values('" & txtNombre.Text & "','" & cbogrupo.Text & "','" & txttelefono.Text & "','" & txttutor.Text & "','" & txtcontacto.Text & "','" & txtcalle.Text & "','" & txtnext.Text & "','" & txtnint.Text & "','" & txtcolonia.Text & "','" & txtcp.Text & "','" & txtdelegacion.Text & "','" & txtestado.Text & "'," & IIf(optlunes.Checked = True, True, False) & "," & IIf(optmartes.Checked = True, True, False) & "," & IIf(optmiercoles.Checked = True, True, False) & "," & IIf(optjueves.Checked = True, True, False) & "," & IIf(optviernes.Checked = True, True, False) & "," & IIf(optsabado.Checked = True, True, False) & ",'" & txtcomentario.Text & "','" & FormatDateTime(dtpNace.Value, DateFormat.ShortDate) & "'," & CDbl(txtpago.Text) & ",'" & FormatDateTime(dtpinicio.Value, DateFormat.ShortDate) & "','" & txthorario.Text & "')", sinfo) Then
                    sinfo = ""
                Else
                    MsgBox(sinfo)
                End If
                a_cnn.Close()
            End If
        End With
    End Sub

    Private Sub PDF_Inscripcion()
        Dim root_name_recibo As String = ""
        Dim FileOpen As New ProcessStartInfo
        Dim FileNta As New Inscripcion
        Dim strServerName As String = Application.StartupPath
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table

        crea_ruta(My.Application.Info.DirectoryPath & "\ARCHIVOSDL1\INSCRIPCIONES\")
        root_name_recibo = My.Application.Info.DirectoryPath & "\ARCHIVOSDL1\INSCRIPCIONES\" & lblfolio.Text & ".pdf"

        If File.Exists(My.Application.Info.DirectoryPath & "\ARCHIVOSDL1\INSCRIPCIONES\" & lblfolio.Text & ".pdf") Then
            File.Delete(My.Application.Info.DirectoryPath & "\ARCHIVOSDL1\INSCRIPCIONES\" & lblfolio.Text & ".pdf")
        End If

        If varrutabase <> "" Then
            If File.Exists("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\INSCRIPCIONES\" & lblfolio.Text & ".pdf") Then
                File.Delete("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\INSCRIPCIONES\" & lblfolio.Text & ".pdf")
            End If
        End If

        With crConnectionInfo
            .ServerName = My.Application.Info.DirectoryPath & "\DL1.mdb"
            .DatabaseName = My.Application.Info.DirectoryPath & "\DL1.mdb"
            .UserID = ""
            .Password = "jipl22"
        End With

        CrTables = FileNta.Database.Tables
        For Each CrTable In CrTables
            crtableLogoninfo = CrTable.LogOnInfo
            crtableLogoninfo.ConnectionInfo = crConnectionInfo
            CrTable.ApplyLogOnInfo(crtableLogoninfo)
        Next

        'Los totales los va a mandar directos
        FileNta.SetDatabaseLogon("", "jipl22")
        FileNta.DataDefinition.FormulaFields("Usuario").Text = "'" & lblusuario.Text & "'"

        FileNta.Refresh()
        FileNta.Refresh()
        FileNta.Refresh()
        If File.Exists(root_name_recibo) Then
            File.Delete(root_name_recibo)
        End If

        Try
            Dim CrExportOptions As ExportOptions
            Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
            Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()

            CrDiskFileDestinationOptions.DiskFileName = root_name_recibo '"c:\crystalExport.pdf"
            CrExportOptions = FileNta.ExportOptions
            With CrExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.PortableDocFormat
                .DestinationOptions = CrDiskFileDestinationOptions
                .FormatOptions = CrFormatTypeOptions
            End With

            FileNta.Export()
            FileOpen.UseShellExecute = True
            FileOpen.FileName = root_name_recibo

            My.Application.DoEvents()

            If MsgBox("¿Deseas abrir el archivo?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Process.Start(FileOpen)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        FileNta.Close()

        If varrutabase <> "" Then
            System.IO.File.Copy(My.Application.Info.DirectoryPath & "\ARCHIVOSDL1\INSCRIPCIONES\" & lblfolio.Text & ".pdf", "\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\INSCRIPCIONES\" & lblfolio.Text & ".pdf")
        End If
    End Sub

    Private Sub cbocuota_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbocuota.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select PrecioVentaIVA from Productos where Nombre='" & cbocuota.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtpago.Text = FormatNumber(rd1(0).ToString(), 2)
                End If
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbocuota_DropDown(sender As Object, e As EventArgs) Handles cbocuota.DropDown
        cbocuota.Items.Clear()
        Try
            cnn2.Close() : cnn2.Open()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select distinct Nombre from Productos where Grupo='PAGOS' order by Nombre"
            rd2 = cmd2.ExecuteReader
            Do While rd2.Read
                If rd2.HasRows Then
                    cbocuota.Items.Add(rd2(0).ToString())
                End If
            Loop
            rd2.Close() : cnn2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn2.Close()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        txtcontraseña.Text = ""
        lblusuario.Text = ""
        txtfecha.Text = FormatDateTime(Date.Now, DateFormat.ShortDate)
        dtpNace.Value = Now
        dtpinicio.Value = Now
        txtcomentario.Text = ""
        txtNombre.Text = ""
        CheckBox7.Checked = False
        txtmatricula.Text = ""
        txttelefono.Text = ""
        txttutor.Text = ""
        txtcontacto.Text = ""
        txtcalle.Text = ""
        txtnint.Text = ""
        txtnext.Text = ""
        txtcolonia.Text = ""
        txtdelegacion.Text = ""
        txtestado.Text = ""
        txtcp.Text = ""
        cbogrupo.Text = ""
        txthorario.Text = ""
        optlunes.Checked = False
        optmartes.Checked = False
        optmiercoles.Checked = False
        optjueves.Checked = False
        optviernes.Checked = False
        optsabado.Checked = False
        cbocuota.Text = ""
        txtpago.Text = ""
        ComboBox1.Text = ""
        grdcaptura.Rows.Clear()
        TextBox2.Text = "0.00"
        folio_ins()
        matricula()
    End Sub

    Private Sub Label20_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboBox1_DropDown(sender As Object, e As EventArgs) Handles ComboBox1.DropDown
        ComboBox1.Items.Clear()
        grdcaptura.Rows.Clear()

        Call cbocuota_KeyPress(cbocuota, New KeyPressEventArgs(ChrW(Keys.Enter)))

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct Nombre from Kits where Grupo='PAGO ESCUELA'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    ComboBox1.Items.Add(rd1(0).ToString())
                End If
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub ComboBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox1.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                cnn2.Close() : cnn2.Open()

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText =
                    "select Descrip,Fecha,CTotal from Kits where Nombre='" & ComboBox1.Text & "' order by Fecha"
                rd2 = cmd2.ExecuteReader
                Do While rd2.Read
                    If rd2.HasRows Then
                        Dim nombre As String = rd2("Descrip").ToString()
                        Dim fecha As Date = rd2("Fecha").ToString()
                        Dim monto As Double = rd2("CTotal").ToString()

                        grdcaptura.Rows.Add("1", nombre, FormatDateTime(fecha, DateFormat.ShortDate), FormatNumber(monto, 2))
                    End If
                Loop
                rd2.Close() : cnn2.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn2.Close()
            End Try
            RecalculaTotal()
            Button1.Focus().Equals(True)
        End If
    End Sub

    Private Sub dtpNace_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtpNace.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txttutor.Focus().Equals(True)
        End If
    End Sub

    Private Sub dtpinicio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtpinicio.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cbocuota.Focus().Equals(True)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        boxcoment.Visible = True
        txtcomentario.Focus().Equals(True)
    End Sub

    Private Sub txtcomentario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcomentario.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Button4.Focus().Equals(True)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        boxcoment.Visible = False
    End Sub

    Private Sub Label22_DoubleClick(sender As Object, e As EventArgs) Handles Label22.DoubleClick
        Inserta_Inscripcion()
    End Sub

    Private Sub txtNombre_DropDown(sender As Object, e As EventArgs) Handles txtNombre.DropDown
        txtNombre.Items.Clear()
        Try
            cnn2.Close() : cnn2.Open()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select distinct Nombre from Alumnos order by Nombre"
            rd2 = cmd2.ExecuteReader
            Do While rd2.Read
                If rd2.HasRows Then
                    txtNombre.Items.Add(rd2(0).ToString())
                End If
            Loop
            cnn2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn2.Close()
        End Try
    End Sub

    Private Sub txtNombre_SelectedValueChanged(sender As Object, e As EventArgs) Handles txtNombre.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Matricula,Telefono,Tutor,Contacto,Calle,N_Int,N_Ext,Colonia,CP,Delegacion,Estado,Lunes,Martes,Miercoles,Jueves,Viernes,Sabado from Alumnos where Nombre='" & txtNombre.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtmatricula.Text = rd1("Matricula").ToString()
                    txttelefono.Text = rd1("Telefono").ToString()
                    txttutor.Text = rd1("Tutor").ToString()
                    txtcontacto.Text = rd1("Contacto").ToString()
                    txtcalle.Text = rd1("Calle").ToString()
                    txtnint.Text = rd1("N_Int").ToString()
                    txtnext.Text = rd1("N_Ext").ToString()
                    txtcolonia.Text = rd1("Colonia").ToString()
                    txtcp.Text = rd1("CP").ToString()
                    txtdelegacion.Text = rd1("Delegacion").ToString()
                    txtestado.Text = rd1("Estado").ToString()
                    If rd1("Lunes").ToString() = 1 Then optlunes.Checked = True
                    If rd1("Martes").ToString() = 1 Then optmartes.Checked = True
                    If rd1("Miercoles").ToString() = 1 Then optmiercoles.Checked = True
                    If rd1("Jueves").ToString() = 1 Then optjueves.Checked = True
                    If rd1("Viernes").ToString() = 1 Then optviernes.Checked = True
                    If rd1("Sabado").ToString() = 1 Then optsabado.Checked = True
                End If
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txttelefono.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtNombre_KeyPress_1(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                "select Matricula,Telefono,Tutor,Contacto,Calle,N_Int,N_Ext,Colonia,CP,Delegacion,Estado from Alumnos where Nombre='" & txtNombre.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        txtmatricula.Text = rd1("Matricula").ToString()
                        txttelefono.Text = rd1("Telefono").ToString()
                        txttutor.Text = rd1("Tutor").ToString()
                        txtcontacto.Text = rd1("Contacto").ToString()
                        txtcalle.Text = rd1("Calle").ToString()
                        txtnint.Text = rd1("N_Int").ToString()
                        txtnext.Text = rd1("N_Ext").ToString()
                        txtcolonia.Text = rd1("Colonia").ToString()
                        txtcp.Text = rd1("CP").ToString()
                        txtdelegacion.Text = rd1("Delegacion").ToString()
                        txtestado.Text = rd1("Estado").ToString()
                    End If
                End If
                rd1.Close() : cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
            txtmatricula.Focus().Equals(True)
        End If
    End Sub

    Private Sub grdcaptura_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdcaptura.CellDoubleClick
        Dim celda As Integer = grdcaptura.CurrentRow.Index

        If MsgBox("¿Deseas eliminar este concepto de cobro del alumno?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then

            grdcaptura.Rows.Remove(grdcaptura.Rows(celda))
            My.Application.DoEvents()

            RecalculaTotal()
        End If
    End Sub
End Class
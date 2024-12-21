Public Class frmAjusteInv

    Private Sub frmAjusteInv_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        cbodesc.Focus().Equals(True)
    End Sub

    Private Sub cbodesc_DropDown(sender As System.Object, e As System.EventArgs) Handles cbodesc.DropDown
        cbodesc.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct Nombre from Productos where Length(Codigo)<=6 order by Nombre"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cbodesc.Items.Add(
                    rd1(0).ToString
                    )
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbodesc_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbodesc.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then

            Dim query As String = ""

            If cbodesc.Text <> "" Then
                Try
                    cnn1.Close() : cnn1.Open()
                    cmd1 = cnn1.CreateCommand

                    If IsNumeric(cbodesc.Text) Then
                        query = "SELECT Codigo FROM Productos WHERE CodBarra='" & cbodesc.Text & "'"
                    Else
                        query = "SELECT Codigo FROM Productos WHERE Nombre='" & cbodesc.Text & "' or CodBarra='" & cbodesc.Text & "'"
                    End If

                    cmd1.CommandText = query
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            cbocodigo.Text = rd1("Codigo").ToString
                            rd1.Close() : cnn1.Close()
                            Call cbocodigo_KeyPress(cbocodigo, New KeyPressEventArgs(ChrW(Keys.Enter)))

                            txtfisica.Focus().Equals(True)
                            Exit Sub
                        End If
                    Else
                        cbocodigo.Focus().Equals(True)
                    End If
                    rd1.Close() : cnn1.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try
            End If
        End If
    End Sub

    Private Sub cbodesc_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cbodesc.SelectedValueChanged
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Codigo from Productos where Nombre='" & cbodesc.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        cbocodigo.Text = rd1(0).ToString
                    End If
                Else
                    MsgBox("No se encuentra en la base de datos.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    rd1.Close() : cnn1.Close()
                    Exit Sub
                End If
                rd1.Close() : cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try       
    End Sub

    Private Sub cbocodigo_DropDown(sender As Object, e As System.EventArgs) Handles cbocodigo.DropDown
        cbocodigo.Items.Clear()
        If cbocodigo.Text <> "" Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Codigo from Productos where LEFT(Codigo, 6)='" & cbocodigo.Text & "' order by Codigo"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then cbocodigo.Items.Add(
                        rd1(0).ToString
                        )
                Loop
                rd1.Close() : cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If        
    End Sub

    Private Sub cbocodigo_GotFocus(sender As Object, e As System.EventArgs) Handles cbocodigo.GotFocus
        cbocodigo.SelectionStart = 0
        cbocodigo.SelectionLength = Len(cbocodigo.Text)
    End Sub

    Private Sub cbocodigo_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbocodigo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If cbocodigo.Text <> "" Then
                grdcaptura.Rows.Clear()
                grdcaptura.ColumnCount = 4
                With grdcaptura
                    With .Columns(0)
                        .HeaderText = "IdLote"
                        .Width = 80
                        .Visible = False
                    End With
                    With .Columns(1)
                        .HeaderText = "Lote"
                        .Width = 80
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(2)
                        .HeaderText = "Caducidad"
                        .Width = 110
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(3)
                        .HeaderText = "Cantidad"
                        .Width = 80
                        .Resizable = DataGridViewTriState.False
                        .Visible = True
                    End With
                End With

                Dim factor As Double = 0
                Dim operad As Double = 0
                Dim codigo As String = Mid(cbocodigo.Text, 1, 6)

                Try
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Multiplo,UVenta,Nombre from Productos where Codigo='" & cbocodigo.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            factor = IIf(rd1("Multiplo").ToString = "", 0, rd1("Multiplo").ToString)
                            txtunidad.Text = rd1("UVenta").ToString
                            cbodesc.Text = rd1("Nombre").ToString
                        End If
                    End If
                    rd1.Close()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Existencia from Productos where Codigo='" & codigo & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            operad = rd1("Existencia").ToString
                        End If
                    End If
                    rd1.Close()
                    cnn1.Close()

                    If factor > 0 Then
                        txtsistema.Text = operad / factor
                    End If
                    If txtsistema.Text <> "" Then
                        txtsistema.Text = FormatNumber(txtsistema.Text, 2)
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try

                Try
                    Dim id_lote As Integer = 0
                    Dim clotestraidos As Double = 0
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Id,Lote,Caducidad,Cantidad from LoteCaducidad where Codigo='" & cbocodigo.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    Do While rd1.Read
                        If rd1.HasRows Then

                            grdcaptura.Rows.Add(
                                rd1("Id").ToString,
                                rd1("Lote").ToString,
                                Format(CDate(rd1("Caducidad").ToString), "MM-yyyy"),
                                rd1("Cantidad").ToString
                                )
                            clotestraidos = clotestraidos + rd1("Cantidad").ToString
                        End If
                    Loop
                    rd1.Close() : cnn1.Close()
                    txtid.Text = FormatNumber(clotestraidos, 2)
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try
                txtfisica.Focus().Equals(True)
                txtfinal.Text = txtsistema.Text
            End If
        End If
    End Sub

    Private Sub cbocodigo_Click(sender As System.Object, e As System.EventArgs) Handles cbocodigo.Click
        cbocodigo.SelectionStart = 0
        cbocodigo.SelectionLength = Len(cbocodigo.Text)
    End Sub

    Private Sub txtfisica_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtfisica.KeyPress
        If Not IsNumeric(txtfisica.Text) Then txtfisica.Text = ""
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtfisica.Text <> "" Then
                btnGuardar.Focus().Equals(True)
            End If
        End If
    End Sub

    Private Sub txtfisica_LostFocus(sender As Object, e As System.EventArgs) Handles txtfisica.LostFocus
        If txtsistema.Text <> "" Then
            If txtfisica.Text <> "" Then
                If Not IsNumeric(txtfisica.Text) Then txtfisica.Text = "" : Exit Sub
                If Not IsNumeric(txtsistema.Text) Then txtsistema.Text = "" : Exit Sub

                Dim str As String = ""
                Dim diferencia As Double = 0
                str = Mid(txtfisica.Text, 1, 1)
                If str <> "-" Then
                    txtfisica.Text = Trim(Replace(txtfisica.Text, "-", ""))
                End If
                diferencia = CDbl(IIf(txtfisica.Text = "", 0, txtfisica.Text)) - CDbl(IIf(txtsistema.Text = "", 0, txtsistema.Text))
                'diferencia = CDbl(IIf(txtsistema.Text = "", 0, txtsistema.Text)) - CDbl(IIf(txtfisica.Text = "", 0, txtfisica.Text))
                txtdiferencia.Text = diferencia
            End If
        End If
    End Sub

    Private Sub txtcontraseña_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcontraseña.KeyPress
        Dim id_usu As Integer = 0

        If AscW(e.KeyChar) = Keys.Enter Then
            If txtcontraseña.Text <> "" Then
                Try
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Alias,IdEmpleado from Usuarios where Clave='" & txtcontraseña.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            lblusuario.Text = rd1("Alias").ToString
                            id_usu = rd1("IdEmpleado").ToString
                        End If
                    Else
                        MsgBox("Contraseña incorrecta, revisa la información.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        txtcontraseña.SelectAll()
                        rd1.Close() : cnn1.Close()
                        Exit Sub
                    End If
                    rd1.Close()

                    Dim per_ajuste As Boolean = False

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Rep_Aju from Permisos where IdEmpleado=" & id_usu
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            per_ajuste = rd1("Rep_Aju").ToString()
                        End If
                    End If
                    rd1.Close() : cnn1.Close()

                    If Not (per_ajuste) Then
                        MsgBox("No cuentas con permiso para realizar ajuste de inventario.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        lblusuario.Text = ""
                        txtcontraseña.Text = ""
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try
                btnGuardar.Focus().Equals(True)
            End If
        End If
    End Sub

    Private Sub EliminaLoteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EliminaLoteToolStripMenuItem.Click
        Dim idLote As Integer = grdcaptura.CurrentRow.Cells(0).Value.ToString
        If MsgBox("¿Deseas eliminar este registro de lote?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "delete from LoteCaducidad where Id=" & idLote & " and Codigo='" & cbocodigo.Text & "'"
                If cmd1.ExecuteNonQuery Then
                    MsgBox("Registro de lote eliminado correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")                    
                End If

                grdcaptura.Rows.Clear()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Id,Lote,Caducidad,Cantidad from LoteCaducidad where Codigo='" & cbocodigo.Text & "' and Cantidad>0"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        grdcaptura.Rows.Add(
                            rd1("Id").ToString,
                            rd1("Lote").ToString,
                            FormatDateTime(CDate(rd1("Caducidad").ToString), DateFormat.ShortDate),
                            rd1("Cantidad").ToString
                            )
                    End If
                Loop
                rd1.Close() : cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
            txtlote.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtlote_Click(sender As System.Object, e As System.EventArgs) Handles txtlote.Click
        txtlote.SelectionStart = 0
        txtlote.SelectionLength = Len(txtlote.Text)
    End Sub

    Private Sub txtlote_GotFocus(sender As Object, e As System.EventArgs) Handles txtlote.GotFocus
        txtlote.SelectionStart = 0
        txtlote.SelectionLength = Len(txtlote.Text)
    End Sub

    Private Sub btnlimpia_lote_Click(sender As System.Object, e As System.EventArgs) Handles btnlimpia_lote.Click
        txtid.Text = ""
        txtlote.Text = ""
        dtpcaduca.Value = Date.Now
        txtcantidad.Text = ""
        grdcaptura.Rows.Clear()
        txtlote.Focus().Equals(True)
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click


        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT NotasCred FROM formatos WHERE Facturas='TomaContra'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                If rd1(0).ToString = 1 Then

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT Alias,Clave FROM usuarios WHERE IdEmpleado=" & id_usu_log
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            lblusuario.Text = rd2(0).ToString
                            txtcontraseña.Text = rd2(1).ToString
                        End If
                    End If
                    rd2.Close()
                    cnn2.Close()
                Else
                    txtcontraseña.Text = ""
                    lblusuario.Text = ""
                End If
            End If
        Else

        End If
        rd1.Close()
        cnn1.Close()

        cbocodigo.Text = ""
        cbocodigo.Items.Clear()
        cbodesc.Text = ""
        cbodesc.Items.Clear()
        txtunidad.Text = ""
        txtsistema.Text = ""
        txtfisica.Text = ""
        txtdiferencia.Text = ""
        chkmerma.Checked = False
        txtfinal.Text = "0"
        btnlimpia_lote.PerformClick()
    End Sub

    Private Sub grdcaptura_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdcaptura.CellDoubleClick
        Dim t As Integer = grdcaptura.CurrentRow.Index


        txtlote.Text = grdcaptura.Rows(t).Cells(1).Value.ToString
        dtpcaduca.Value = grdcaptura.Rows(t).Cells(2).Value.ToString
        txtcantidad.Text = grdcaptura.Rows(t).Cells(3).Value.ToString

        txtid.Text = CDbl(txtid.Text) - CDbl(grdcaptura.Rows(t).Cells(3).Value.ToString)

        grdcaptura.Rows.Remove(grdcaptura.Rows(t))
        txtlote.Focus().Equals(True)
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click

        If cbocodigo.Text = "" Or cbodesc.Text = "" Or txtunidad.Text = "" Or txtsistema.Text = "" Or txtfisica.Text = "" Or txtdiferencia.Text = "" Then
            MsgBox("Faltan datos del producto para poder guardar el ajuste de inventario.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            cbodesc.Focus().Equals(True)
        End If

        If lblusuario.Text = "" Then
            MsgBox("Escribe tu contraseña para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            txtcontraseña.Focus().Equals(True)
            Exit Sub
        End If

        Try
            Dim idUsu As Integer = 0
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Alias,IdEmpleado from Usuarios where Clave='" & txtcontraseña.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    lblusuario.Text = rd1("Alias").ToString
                    idUsu = rd1("IdEmpleado").ToString
                End If
            Else
                MsgBox("Contraseña incorrecta, revisa la información.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                rd1.Close() : cnn1.Close()
                txtcontraseña.Focus().Equals(True) : Exit Sub
                Exit Sub
            End If
            rd1.Close()

            Dim per_ajuste As Boolean = False

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Rep_Aju from Permisos where IdEmpleado= " & idUsu
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    per_ajuste = rd1("Rep_Aju").ToString
                End If
            End If
            rd1.Close() : cnn1.Close()

            If Not (per_ajuste) Then
                MsgBox("No cuentas con permiso para realizar ajuste de inventario.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

        'Consultar si el producto es caduca----

        Dim caduca As Integer = 0
        Dim tlotes As Double = 0
        Dim fisica As Double = 0
        fisica = txtsistema.Text

        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT Caduca FROM productos WHERE Codigo='" & cbocodigo.Text & "'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                caduca = rd1(0).ToString
                If caduca = 1 Then
                    If grdcaptura.Rows.Count > 0 Then

                        For luffy As Integer = 0 To grdcaptura.Rows.Count - 1
                            Dim canti As Double = grdcaptura.Rows(luffy).Cells(3).Value.ToString
                            tlotes = tlotes + canti
                        Next

                        If tlotes < fisica Then
                            MsgBox("La suma de los lotes es menor a la existencia del producto, verifica la información", vbInformation + vbOKOnly, titulocentral)
                            txtlote.Focus.Equals(True)
                        Else
                            AJUSTAINVENTARIO()
                            MessageAgreagarlotes()

                            'txtfisica.Text = ""
                            'txtdiferencia.Text = ""
                            'cbocodigo_KeyPress(cbocodigo, New KeyPressEventArgs(ControlChars.Cr))
                            txtlote.Focus.Equals(True)
                            txtfinal.Text = txtfisica.Text
                            My.Application.DoEvents()
                        End If

                    Else
                        AJUSTAINVENTARIO()
                        MessageBoxTimer()
                        'txtfisica.Text = ""
                        'txtdiferencia.Text = ""
                        'cbocodigo_KeyPress(cbocodigo, New KeyPressEventArgs(ControlChars.Cr))
                        txtfinal.Text = txtfisica.Text
                        Exit Sub
                    End If
                Else
                    txtfinal.Text = txtfisica.Text
                    AJUSTAINVENTARIO()
                    btnlimpia_lote.PerformClick()
                End If
            End If
        End If
        rd1.Close()
        cnn1.Close()




    End Sub

    Sub MessageAgreagarlotes()

        Dim AckTime As Integer, InfoBox As Object
        InfoBox = CreateObject("WScript.Shell")
        AckTime = 1
        Select Case InfoBox.Popup("Necesitas agregar los lotes y caducidades del producto faltantes", AckTime, titulocentral, 0)
            Case 1, -1

                Exit Sub
        End Select
    End Sub

    Sub MessageBoxTimer()

        Dim AckTime As Integer, InfoBox As Object
        InfoBox = CreateObject("WScript.Shell")
        AckTime = 1
        Select Case InfoBox.Popup("Necesitas agregar los lotes y caducidades del producto", AckTime, titulocentral, 0)
            Case 1, -1

                Exit Sub
        End Select
    End Sub

    Public Sub AJUSTAINVENTARIO()
        If MsgBox("¿Deseas guardar este ajuste de inventario?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Dim MyMCD As Double = 0
            Dim MyMult2 As Double = 0
            Dim MyMulti As Double = 0
            Dim MyExist As Double = 0
            Dim MyPreci As Double = 0
            Dim MyDepto As String = ""
            Dim MyGrupo As String = ""
            Dim MyUnida As String = ""
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select UVenta,MCD,Multiplo,Departamento,Grupo from Productos where Codigo='" & cbocodigo.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        MyUnida = rd1("UVenta").ToString
                        MyMCD = IIf(rd1("MCD").ToString = "", 0, rd1("MCD").ToString)
                        MyMult2 = IIf(rd1("Multiplo").ToString = "", 0, rd1("Multiplo").ToString)
                        MyDepto = rd1("Departamento").ToString
                        MyGrupo = rd1("Grupo").ToString
                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select PrecioVentaIVA from Productos where Codigo='" & Strings.Left(cbocodigo.Text, 6) & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        MyPreci = IIf(rd1("PrecioVentaIVA").ToString = "", 0, rd1("PrecioVentaIVA").ToString)
                    End If
                End If
                rd1.Close()

                If (chkmerma.Checked) Then
                    If CDbl(txtdiferencia.Text) < 0 Then
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "insert into Merma(Codigo,Nombre,Cantidad,Unidad,Fecha,Depto,Grupo,Usuario) values('" & cbocodigo.Text & "','" & cbodesc.Text & "'," & CDbl(txtdiferencia.Text) & ",'" & MyUnida & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & MyDepto & "','" & MyGrupo & "','" & lblusuario.Text & "')"
                        cmd1.ExecuteNonQuery()
                    End If
                End If

                Dim existemmmmmmmcias As Double = 0
                If MyMult2 > 1 And MyMCD = 1 Then
                    existemmmmmmmcias = FormatNumber(CDbl(txtfisica.Text) * MyMult2, 0)
                Else
                    existemmmmmmmcias = CDec(txtfisica.Text) * CDec(MyMult2)
                End If



                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "update Productos set Cargado=0, CargadoInv=0, Existencia=" & existemmmmmmmcias & " where Codigo='" & Strings.Left(cbocodigo.Text, 6) & "'"
                If cmd1.ExecuteNonQuery() Then
                    MsgBox("Inventario actualizado correctamente", vbInformation + vbOKOnly, titulocentral)
                End If

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "insert into Cardex(Codigo,Nombre,Movimiento,Inicial,Cantidad,Final,Precio,Fecha,Usuario,Folio,Tipo,Cedula,Receta,Medico,Domicilio) values('" & cbocodigo.Text & "','" & cbodesc.Text & "','Ajuste de inventario'," & CDbl(txtsistema.Text) & "," & CDbl(txtdiferencia.Text) & "," & CDbl(txtfisica.Text) & "," & MyPreci & ",'" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & lblusuario.Text & "','','','','','','')"
                cmd1.ExecuteNonQuery()
                cnn1.Close()

            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If

    End Sub



    Private Sub txtlote_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtlote.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            dtpcaduca.Focus().Equals(True)
        End If
    End Sub

    Private Sub dtpcaduca_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtpcaduca.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            'If dtpcaduca.Value < Date.Now Then MsgBox("La fecha de caducidad no puede ser menor al día de hoy.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Exit Sub
            txtcantidad.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtcantidad_Click(sender As System.Object, e As System.EventArgs) Handles txtcantidad.Click
        txtcantidad.SelectionStart = 0
        txtcantidad.SelectionLength = Len(txtcantidad.Text)
    End Sub

    Private Sub txtcantidad_GotFocus(sender As Object, e As System.EventArgs) Handles txtcantidad.GotFocus
        txtcantidad.SelectionStart = 0
        txtcantidad.SelectionLength = Len(txtcantidad.Text)
    End Sub

    Private Sub txtcantidad_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcantidad.KeyPress
        If Not IsNumeric(txtcantidad.Text) Then txtcantidad.Text = "" : Exit Sub
        If AscW(e.KeyChar) = Keys.Enter Then

            Dim totproductos As Double = 0
            Dim sumalotes As Double = 0
            Dim existencias As Double = 0

            txtid.Text = CDbl(txtid.Text) + CDbl(txtcantidad.Text)
            sumalotes = txtid.Text
            existencias = txtfinal.Text
            If sumalotes > existencias Then
                MsgBox("La suma de los lotes es mayor a la existencia del producto,verifica la información", vbInformation + vbOKOnly, titulocentral)
                txtid.Text = CDbl(txtid.Text) - CDbl(txtcantidad.Text)
            Else

                Dim fechaxd As String = Format(dtpcaduca.Value, "MM-yyyy")
                'Dim nuvf As String = ""

                ' nuvf = fecha.Replace("-", "")


                Dim fecha As String = Format(dtpcaduca.Value, "dd-MM-yyyy")
                Dim partes() As String = fecha.Split("-"c)

                Dim dia As Integer = Convert.ToInt32(partes(0))
                Dim mes As Integer = Convert.ToInt32(partes(1))
                Dim año As Integer = Convert.ToInt32(partes(2))

                Dim NUVCAD As String = loteforma(mes, año)
                ' MsgBox(NUVCAD)
                'FormatDateTime(CDate(dtpcaduca.Value), DateFormat.ShortDate)
                grdcaptura.Rows.Add(
                               txtid.Text,
                               txtlote.Text,
                               fechaxd,
                               txtcantidad.Text
                               )
            End If

            txtlote.Text = ""
            dtpcaduca.Value = Date.Now
            txtcantidad.Text = "0"
            btnguarda_lote.Focus().Equals(True)

        End If
    End Sub

    Public Function loteforma(ByVal dato As String, ByVal ano As String)

        Dim mes As String = dato
        Dim ultimo As String = ano
        Dim nmes As String = ""
        Dim NUV As String = ""
        Select Case mes
            Case Is = 1
                nmes = "ENERO"
            Case = 2
                nmes = "FEBRERO"
            Case = 3
                nmes = "MARZO"
            Case = 4
                nmes = "ABRIL"
            Case = 5
                nmes = "MAYO"
            Case = 6
                nmes = "JUNIO"
            Case = 7
                nmes = "JULIO"
            Case = 8
                nmes = "AGOSTO"
            Case = 9
                nmes = "SEPTIEMBRE"
            Case = 10
                nmes = "OCTUBRE"
            Case = 11
                nmes = "NOVIEMBRE"
            Case = 12
                nmes = "DICIEMBRE"
        End Select
        NUV = nmes & " " & ultimo
        Return NUV
    End Function
    Private Sub btnguarda_lote_Click(sender As System.Object, e As System.EventArgs) Handles btnguarda_lote.Click
        If lblusuario.Text = "" Then
            MsgBox("Ingresa tu contraseña para continuar", vbInformation + vbOKOnly, "Delsscom Farmacias")
            txtcontraseña.Focus.Equals(True)
            Exit Sub
        End If
        Try
            Dim totallotes As Double = 0
            Dim existencia As Double = 0
            Dim cant_lotes As Double = 0

            Dim existenciasistema As Double = txtfinal.Text
            cnn1.Close() : cnn1.Open()
            cnn2.Close() : cnn2.Open()

            For LUFFY As Integer = 0 To grdcaptura.Rows.Count - 1
                Dim canti As Double = grdcaptura.Rows(LUFFY).Cells(3).Value.ToString

                totallotes = totallotes + canti
            Next

            If totallotes > existenciasistema Then
                MsgBox("La suma de los lotes es mayor a la existencia registrada", vbInformation + vbOKOnly, titulocentral)
                Exit Sub
            ElseIf totallotes < existenciasistema Then
                MsgBox("La suma de los lotes es menor a la existencia registrada", vbInformation + vbOKOnly, titulocentral)
                Exit Sub
            Else

                Dim cantivoy As Double = 0
                For deku As Integer = 0 To grdcaptura.Rows.Count - 1


                    Dim lote As String = grdcaptura.Rows(deku).Cells(1).Value.ToString
                    Dim caducidad As Date = grdcaptura.Rows(deku).Cells(2).Value.ToString
                    Dim cantidadl As Double = grdcaptura.Rows(deku).Cells(3).Value.ToString
                    cantivoy = cantivoy + cantidadl
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT Lote FROM lotecaducidad WHERE Lote='" & lote & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            'Actualiza un lote
                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText =
                                "update LoteCaducidad set Cantidad=" & CDbl(cantidadl) & ", Caducidad='" & Format(caducidad, "yyyy-MM") & "' where Lote='" & lote & "' AND Codigo='" & cbocodigo.Text & "'"
                            cmd1.ExecuteNonQuery()
                        End If
                    Else
                        'Inserta un nuevo lote
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "insert into LoteCaducidad(Codigo,Lote,Caducidad,Cantidad) values('" & cbocodigo.Text & "','" & lote & "','" & Format(caducidad, "yyyy-MM") & "'," & CDbl(cantidadl) & ")"
                        cmd1.ExecuteNonQuery()
                    End If
                    rd2.Close()
                Next
                Dim MyPreci As Double = 0
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select PrecioVentaIVA from Productos where Codigo='" & Strings.Left(cbocodigo.Text, 6) & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        MyPreci = IIf(rd1("PrecioVentaIVA").ToString = "", 0, rd1("PrecioVentaIVA").ToString)
                    End If
                End If
                rd1.Close()
                If txtdiferencia.Text = "" Then
                    txtdiferencia.Text = "0"
                Else
                    txtdiferencia.Text = txtdiferencia.Text
                End If
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "insert into Cardex(Codigo,Nombre,Movimiento,Inicial,Cantidad,Final,Precio,Fecha,Usuario,Folio,Tipo,Cedula,Receta,Medico,Domicilio) values('" & cbocodigo.Text & "','" & cbodesc.Text & "','Ajuste de lotes'," & CDbl(txtsistema.Text) & "," & CDbl(txtdiferencia.Text) & "," & cantivoy & "," & FormatNumber(MyPreci, 2) & ",'" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & lblusuario.Text & "','','','','','','')"
                cmd1.ExecuteNonQuery()


                MsgBox("Datos de los lotes registrados.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                txtcantidad.Text = "0"
                txtlote.Text = ""
                grdcaptura.Rows.Clear()
                btnNuevo.PerformClick()
            End If
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

        'If (GuardaLote()) Then
        '    MsgBox("Operación concluida.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")

        '    Try
        '        cnn1.Close() : cnn1.Open()

        '        cmd1 = cnn1.CreateCommand
        '        cmd1.CommandText =
        '            "select Id,Lote,Caducidad,Cantidad from LoteCaducidad where Codigo='" & cbocodigo.Text & "'"
        '        rd1 = cmd1.ExecuteReader
        '        Do While rd1.Read
        '            If rd1.HasRows Then
        '                If rd1.HasRows Then
        '                    grdcaptura.Rows.Add(
        '                        rd1("Id").ToString,
        '                        rd1("Lote").ToString,
        '                        FormatDateTime(CDate(rd1("Caducidad").ToString), DateFormat.ShortDate),
        '                        rd1("Cantidad").ToString
        '                        )
        '                End If
        '            End If
        '        Loop
        '        rd1.Close() : cnn1.Close()
        '    Catch ex As Exception
        '        MessageBox.Show(ex.ToString)
        '        cnn1.Close()
        '    End Try
        'Else
        '    MsgBox("No se pudo guardar el registro del lote debido a un error.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
        '    Exit Sub
        'End If
    End Sub

    Private Function GuardaLote() As Boolean
        Dim respuesta As Boolean = False
        If cbocodigo.Text = "" Then Return False : Exit Function
        If CDbl(txtcantidad.Text) <= 0 Then MsgBox("Ingresa una cantidad válida para el lote.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Return False : txtcantidad.Focus().Equals(True) : Exit Function

        Dim cantidad_lotes As Double = 0
        For UI As Integer = 0 To grdcaptura.Rows.Count - 1
            cantidad_lotes = cantidad_lotes + CDbl(grdcaptura.Rows(UI).Cells(3).Value.ToString())
        Next

        If (cantidad_lotes + CDbl(txtcantidad.Text)) > CDbl(txtsistema.Text) Then
            MsgBox("No cuentas con existencias suficientes para registrar esta cantidad en el lote.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            txtcantidad.Focus().Equals(True)
            Return False
            Exit Function
        End If

        Try
            Dim idUsu As Integer = 0
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Alias,IdEmpleado from Usuarios where Clave='" & txtcontraseña.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    lblusuario.Text = rd1("Alias").ToString
                    idUsu = rd1("IdEmpleado").ToString
                End If
            Else
                MsgBox("Contraseña incorrecta, revisa la información.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                rd1.Close() : cnn1.Close()
                txtcontraseña.Focus().Equals(True) : Return False
                Exit Function
            End If
            rd1.Close()

            Dim existencia As Double = 0
            Dim cant_lotes As Double = 0

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Existencia from Productos where Codigo='" & cbocodigo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    existencia = rd1("Existencia").ToString
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select SUM(Cantidad) from LoteCaducidad where Codigo='" & cbocodigo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cant_lotes = IIf(rd1(0).ToString = "", 0, rd1(0).ToString)
                End If
            End If
            rd1.Close()

            If txtid.Text = "" Then
                Dim nuevos_lotes As Double = cant_lotes + CDbl(txtcantidad.Text)

                If nuevos_lotes > existencia Then MsgBox("No cuentas con existencia suficientes para registrar esta cantidad en el lote.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Return False : txtcantidad.Focus().Equals(True) : Exit Function

                'Inserta un nuevo lote
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "insert into LoteCaducidad(Codigo,Lote,Caducidad,Cantidad) values('" & cbocodigo.Text & "','" & txtlote.Text & "','" & Format(dtpcaduca.Value, "yyyy-MM-dd") & "'," & CDbl(txtcantidad.Text) & ")"
                If cmd1.ExecuteNonQuery Then
                    respuesta = True
                    MsgBox("Datos de lote registrados.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                End If
            Else
                'Actualiza un lote
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "update LoteCaducidad set Cantidad=" & CDbl(txtcantidad.Text) & ", Caducidad='" & Format(dtpcaduca.Value, "yyyy-MM-dd") & "' where Id=" & txtid.Text
                If cmd1.ExecuteNonQuery Then
                    respuesta = True
                    MsgBox("Datos de lote actualizados.", vbInformation + vbOKOnly, "Delscom Control Negocios Pro")
                End If
            End If
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
        Return respuesta
    End Function

    Private Sub cbodesc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbodesc.SelectedIndexChanged

    End Sub

    Private Sub Label12_DoubleClick(sender As Object, e As EventArgs) Handles Label12.DoubleClick
        Try
            Dim codig As String = ""
            Dim canti As Double = 0

            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Update productos set ProvRes=0"
            cmd1.ExecuteNonQuery()
            cnn1.Close()


            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select Codigo,Cantidad from VentasDEtalle"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                codig = rd1("Codigo").ToString
                canti = rd1("Cantidad").ToString

                cnn2.Close()
                cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "Update Productos set Existencia=Existencia- " & canti & " where Codigo='" & codig & "'"
                cmd2.ExecuteNonQuery()
            Loop
            cnn2.Close()
            rd1.Close()
            cnn1.Close()
            MsgBox("Existencias actualizadas correctamente", vbOKOnly, "Delsscom Control Negocios PRO")
            Label12.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
            cnn1.Close()
        End Try
    End Sub

    Private Sub frmAjusteInv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NotasCred FROM formatos WHERE Facturas='TomaContra'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If rd1(0).ToString = 1 Then
                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT Alias,Clave FROM usuarios WHERE IdEmpleado=" & id_usu_log
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                lblusuario.Text = rd2(0).ToString
                                txtcontraseña.Text = rd2(1).ToString
                            End If
                        End If
                        rd2.Close()
                        cnn2.Close()

                    End If
                End If
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

        dtpcaduca.Format = DateTimePickerFormat.Custom
        dtpcaduca.CustomFormat = "MM/yyyy"
        dtpcaduca.ShowUpDown = True
    End Sub




End Class
Public Class frmAjusteNormal
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        cbocodigo.Text = ""
        cbodesc.Text = ""
        txtsistema.Text = "0"
        txtfisica.Text = ""
        txtdiferencia.Text = ""

    End Sub

    Private Sub txtcontraseña_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcontraseña.KeyPress
        Dim id_usu As Integer = 0

        If AscW(e.KeyChar) = Keys.Enter Then
            If txtcontraseña.Text <> "" Then
                Try
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select * from Usuarios where Clave='" & txtcontraseña.Text & "'"
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
                        "select * from Permisos where IdEmpleado=" & id_usu
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

    Private Sub cbodesc_DropDown(sender As Object, e As EventArgs) Handles cbodesc.DropDown
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

    Private Sub frmAjusteNormal_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        cbodesc.Focus().Equals(True)
    End Sub

    Private Sub cbodesc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbodesc.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If cbodesc.Text <> "" Then
                Try
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select * from Productos where CodBarra='" & cbodesc.Text & "'"
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

    Private Sub cbodesc_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbodesc.SelectedValueChanged
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

    Private Sub cbocodigo_DropDown(sender As Object, e As EventArgs) Handles cbocodigo.DropDown
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

    Private Sub cbocodigo_GotFocus(sender As Object, e As EventArgs) Handles cbocodigo.GotFocus
        cbocodigo.SelectionStart = 0
        cbocodigo.SelectionLength = Len(cbocodigo.Text)
    End Sub

    Private Sub cbocodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbocodigo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If cbocodigo.Text <> "" Then


                Dim factor As Double = 0
                Dim operad As Double = 0
                Dim codigo As String = Mid(cbocodigo.Text, 1, 6)

                Try
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select * from Productos where Codigo='" & cbocodigo.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            factor = IIf(rd1("MCD").ToString = "", 0, rd1("MCD").ToString)
                            txtunidad.Text = rd1("UVenta").ToString
                            cbodesc.Text = rd1("Nombre").ToString
                        End If
                    End If
                    rd1.Close()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select * from Productos where Codigo='" & codigo & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            operad = rd1("Existencia").ToString
                        End If
                    End If
                    rd1.Close()
                    cnn1.Close()

                    If factor > 0 Then
                        txtsistema.Text = operad * factor
                    End If
                    If txtsistema.Text <> "" Then
                        txtsistema.Text = FormatNumber(txtsistema.Text, 2)
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try
                txtfisica.Focus().Equals(True)
            End If
        End If
    End Sub

    Private Sub cbocodigo_Click(sender As Object, e As EventArgs) Handles cbocodigo.Click
        cbocodigo.SelectionStart = 0
        cbocodigo.SelectionLength = Len(cbocodigo.Text)
    End Sub

    Private Sub txtfisica_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtfisica.KeyPress
        If Not IsNumeric(txtfisica.Text) Then txtfisica.Text = ""
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtfisica.Text <> "" Then
                btnGuardar.Focus().Equals(True)
            End If
        End If
    End Sub

    Private Sub txtfisica_LostFocus(sender As Object, e As EventArgs) Handles txtfisica.LostFocus
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
                txtdiferencia.Text = diferencia
            End If
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
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
                "select * from Usuarios where Clave='" & txtcontraseña.Text & "'"
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
                "select * from Permisos where IdEmpleado= " & idUsu
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
                    "select * from Productos where Codigo='" & cbocodigo.Text & "'"
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
                    "select * from Productos where Codigo='" & Strings.Left(cbocodigo.Text, 6) & "'"
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
                existemmmmmmmcias = CDbl(txtfisica.Text) / MyMCD

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "update Productos set Cargado=0, CargadoInv=0, Existencia=" & existemmmmmmmcias & " where Codigo='" & Strings.Left(cbocodigo.Text, 6) & "'"
                cmd1.ExecuteNonQuery()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "insert into Cardex(Codigo,Nombre,Movimiento,Inicial,Cantidad,Final,Precio,Fecha,Usuario,Folio,Tipo,Cedula,Receta,Medico,Domicilio) values('" & cbocodigo.Text & "','" & cbodesc.Text & "','Ajuste de inventario'," & CDbl(txtsistema.Text) & "," & CDbl(txtdiferencia.Text) & "," & CDbl(txtfisica.Text) & "," & MyPreci & ",'" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & lblusuario.Text & "','','','','','','')"
                cmd1.ExecuteNonQuery()
                cnn1.Close()
                btnNuevo.PerformClick()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub
End Class
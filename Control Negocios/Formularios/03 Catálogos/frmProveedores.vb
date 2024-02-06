Imports System.Data.OleDb
Imports System.Runtime.Remoting.Contexts

Public Class frmProveedores

    Private Sub Info_Click(sender As System.Object, e As System.EventArgs) Handles Info.Click
        If Info.Text = "> Más información" Then
            Info.Text = "v Menos información"
            Me.Size = New Size(474, 513)
        Else
            Info.Text = "> Más información"
            Me.Size = New Size(474, 276)
        End If
    End Sub

    Private Sub cboNombre_DropDown(sender As System.Object, e As System.EventArgs) Handles cboNombre.DropDown
        cboNombre.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                 "select distinct NComercial from Proveedores where NComercial<>''"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    cboNombre.Items.Add(rd1(0).ToString)
                End If
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString
                            )
            cnn1.Close()
        End Try
    End Sub

    Private Sub frmProveedores_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        cboNombre.Focus.Equals(True)
    End Sub

    Private Sub frmProveedores_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtId.Text = ""
        cboNombre.Focus.Equals(True)
    End Sub

    Private Sub cboNombre_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboNombre.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                cnn2.Close() : cnn2.Open()

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText =
                     "select * from Proveedores where NComercial='" &
                     cboNombre.Text & "'"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        txtId.Text = rd2("Id").ToString
                        cboRazon.Text = rd2("Compania").ToString
                        txtRFC.Text = rd2("RFC").ToString
                        txtCURP.Text = rd2("CURP").ToString
                        txtCredito.Text = FormatNumber(rd2("Credito").ToString)
                        txtDias.Text = rd2("DiasCred").ToString
                        txtCalle.Text = rd2("Calle").ToString
                        txtColonia.Text = rd2("Colonia").ToString
                        txtCP.Text = rd2("CP").ToString
                        txtDelegacion.Text = rd2("Delegacion").ToString
                        txtEntidad.Text = rd2("Entidad").ToString
                        txtWhats.Text = rd2("Telefono").ToString
                        txtFace.Text = rd2("Facebook").ToString
                        txtCorreo.Text = rd2("Correo").ToString
                    End If
                End If
                rd2.Close() : cnn2.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn2.Close()
            End Try
            cboRazon.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboNombre_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cboNombre.SelectedValueChanged
        Try
            cnn2.Close() : cnn2.Open()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                 "select * from Proveedores where NComercial='" &
                 cboNombre.Text & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    txtId.Text = rd2("Id").ToString
                    cboRazon.Text = rd2("Compania").ToString
                    txtRFC.Text = rd2("RFC").ToString
                    txtCURP.Text = rd2("CURP").ToString
                    txtCredito.Text = FormatNumber(rd2("Credito").ToString)
                    txtDias.Text = rd2("DiasCred").ToString
                    txtCalle.Text = rd2("Calle").ToString
                    txtColonia.Text = rd2("Colonia").ToString
                    txtCP.Text = rd2("CP").ToString
                    txtDelegacion.Text = rd2("Delegacion").ToString
                    txtEntidad.Text = rd2("Entidad").ToString
                    txtWhats.Text = rd2("Telefono").ToString
                    txtFace.Text = rd2("Facebook").ToString
                    txtCorreo.Text = rd2("Correo").ToString
                End If
            End If
            rd2.Close() : cnn2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
        End Try
    End Sub

    Private Sub cboRazon_DropDown(sender As System.Object, e As System.EventArgs) Handles cboRazon.DropDown
        cboRazon.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct Compania from Proveedores where Compania<>''"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    cboRazon.Items.Add(rd1(0).ToString)
                End If
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboRazon_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboRazon.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Proveedores where Compania='" & cboRazon.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        txtId.Text = rd1("Id").ToString
                        cboNombre.Text = rd1("NComercial").ToString
                        txtRFC.Text = rd1("RFC").ToString
                        txtCURP.Text = rd1("CURP").ToString
                        txtCredito.Text = FormatNumber(rd1("Credito").ToString, 2)
                        txtDias.Text = rd1("DiasCred").ToString
                        txtCalle.Text = rd1("Calle").ToString
                        txtColonia.Text = rd1("Colonia").ToString
                        txtCP.Text = rd1("CP").ToString
                        txtDelegacion.Text = rd1("Delegacion").ToString
                        txtEntidad.Text = rd1("Entidad").ToString
                        txtWhats.Text = rd1("Telefono").ToString
                        txtFace.Text = rd1("Facebook").ToString
                        txtCorreo.Text = rd1("Correo").ToString
                    End If
                End If
                rd1.Close() : cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
            txtRFC.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboRazon_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboRazon.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Proveedores where Compania='" & cboRazon.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtId.Text = rd1("Id").ToString
                    cboNombre.Text = rd1("NComercial").ToString
                    txtRFC.Text = IIf(rd1("RFC").ToString = "", "", rd1("RFC").ToString)
                    txtCURP.Text = rd1("CURP").ToString
                    txtCredito.Text = FormatNumber(rd1("Credito").ToString, 2)
                    txtDias.Text = rd1("DiasCred").ToString
                    txtCalle.Text = rd1("Calle").ToString
                    txtColonia.Text = rd1("Colonia").ToString
                    txtCP.Text = rd1("CP").ToString
                    txtDelegacion.Text = rd1("Delegacion").ToString
                    txtEntidad.Text = rd1("Entidad").ToString
                    txtWhats.Text = rd1("Telefono").ToString
                    txtFace.Text = rd1("Facebook").ToString
                    txtCorreo.Text = rd1("Correo").ToString
                End If
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub txtRFC_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtRFC.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtCredito.SelectionStart = 0
            txtCredito.SelectionLength = Len(txtCredito.Text)
            txtCredito.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtCredito_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCredito.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtCredito.Text = FormatNumber(txtCredito.Text, 2)
            txtCURP.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtCURP_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCURP.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtDias.SelectionStart = 0
            txtDias.SelectionLength = Len(txtDias.Text)
            txtDias.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtDias_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDias.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnGuardar.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtCalle_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCalle.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtColonia.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtColonia_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtColonia.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtCP.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtCP_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCP.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtDelegacion.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtDelegacion_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDelegacion.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtEntidad.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtEntidad_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtEntidad.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtWhats.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtWhats_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtWhats.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtFace.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtFace_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtFace.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtCorreo.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtCorreo_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCorreo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnGuardar.Focus.Equals(True)
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        txtId.Text = ""
        cboNombre.Items.Clear()
        cboNombre.Text = ""
        cboRazon.Items.Clear()
        cboRazon.Text = ""
        txtRFC.Text = ""
        txtCURP.Text = ""
        txtCredito.Text = "0.00"
        txtDias.Text = ""
        txtCalle.Text = ""
        txtColonia.Text = ""
        txtCP.Text = ""
        txtDelegacion.Text = ""
        txtEntidad.Text = ""
        txtWhats.Text = ""
        txtFace.Text = ""
        txtCorreo.Text = ""
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        If cboNombre.Text = "" Then MsgBox("Necesitas escribir el nombre comercial del proveedor para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboNombre.Focus().Equals(True) : Exit Sub
        If cboRazon.Text = "" Then MsgBox("Necesitas esribir la razón social del proveedor para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboRazon.Focus().Equals(True) : Exit Sub

        Dim existe As Boolean = False
        Dim sql As String = ""
        Dim credito As Double = txtCredito.Text

        If txtId.Text = "" Then
            existe = False
        Else
            existe = True
        End If

        Try
            If existe Then
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                     "select * from Proveedores where Id=" &
                     txtId.Text
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        sql = "update Proveedores set RFC='" & txtRFC.Text & "', CURP='" & txtCURP.Text & "', Calle='" & txtCalle.Text & "', Colonia='" & txtColonia.Text & "', CP='" & txtCP.Text & "', Delegacion='" & txtDelegacion.Text & "', Entidad='" & txtEntidad.Text & "', Telefono='" & txtWhats.Text & "', Facebook='" & txtFace.Text & "', Correo='" & txtCorreo.Text & "', Credito=" & credito & ", DiasCred=" & txtDias.Text & " where Id=" & txtId.Text
                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = sql
                If cmd1.ExecuteNonQuery Then
                    MsgBox("Datos de proveedor actualizados.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    btnNuevo.PerformClick()
                End If

                cnn1.Close()
            Else
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                     "select * from Proveedores where NComercial='" & cboNombre.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    MsgBox("Ya hay un proveedor registrado bajo ese nombre.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    cboNombre.Focus.Equals(True)
                    rd1.Close()
                    cnn1.Close()
                    Exit Sub
                Else
                    sql = "insert into Proveedores(NComercial,Compania,RFC,CURP,Calle,Colonia,CP,Delegacion,Entidad,Telefono,Facebook,Correo,Saldo,Credito,DiasCred) values('" & cboNombre.Text & "','" & cboRazon.Text & "','" & txtRFC.Text & "','" & txtCURP.Text & "','" & txtCalle.Text & "','" & txtColonia.Text & "','" & txtCP.Text & "','" & txtDelegacion.Text & "','" & txtEntidad.Text & "','" & txtWhats.Text & "','" & txtFace.Text & "','" & txtCorreo.Text & "',0," & credito & "," & IIf(txtDias.Text = "", 0, txtDias.Text) & ")"
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = sql
                If cmd1.ExecuteNonQuery Then
                    MsgBox("Datos de proveedor registrados.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    btnNuevo.PerformClick()
                End If

                cnn1.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        If txtId.Text = "" Then
            MsgBox("Selecciona un proveedor para eliminarlo.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            cboNombre.Focus.Equals(True)
            Exit Sub
        End If

        If MsgBox("¿Deseas eliminar a éste proveedor?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbCancel Then Exit Sub

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "delete from Proveedores where Id=" & txtId.Text
            If cmd1.ExecuteNonQuery Then
                MsgBox("Datos de proveedor eliminados.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                btnNuevo.PerformClick()
            End If
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub frmProveedores_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        cboNombre.Focus().Equals(True)
    End Sub

    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click
        If MsgBox("Estas apunto de importar tu catálogo desde un archivo de Excel, para evitar errores asegúrate de que la hoja de Excel tiene el nombre de 'Hoja1' y cerciórate de que el archivo está guardado y cerrado.", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Excel_Grid_SQL(DataGridView1)
        End If
    End Sub

    Private Sub Excel_Grid_SQL(ByVal tabla As DataGridView)

        Dim con As OleDb.OleDbConnection
        Dim dt As New System.Data.DataTable
        Dim ds As New DataSet
        Dim da As OleDb.OleDbDataAdapter
        Dim cuadro_dialogo As New OpenFileDialog
        Dim ruta As String = ""
        Dim sheet As String = "hoja1"

        With cuadro_dialogo
            .Filter = "Archivos de cálculo(*.xls;*.xlsx)|*.xls;*.xlsx"
            .Title = "Selecciona el archivo a importar"
            .Multiselect = False
            .InitialDirectory = My.Application.Info.DirectoryPath & "\Archivos de importación"
            .ShowDialog()
        End With

        Try
            If cuadro_dialogo.FileName.ToString() <> "" Then
                ruta = cuadro_dialogo.FileName.ToString()
                con = New OleDb.OleDbConnection(
                    "Provider=Microsoft.ACE.OLEDB.12.0;" &
                    " Data Source='" & ruta & "'; " &
                    "Extended Properties='Excel 12.0 Xml;HDR=Yes'")

                da = New OleDb.OleDbDataAdapter("select * from [" & sheet & "$]", con)

                con.Open()
                da.Fill(ds, "MyData")
                dt = ds.Tables("MyData")
                tabla.DataSource = ds
                tabla.DataMember = "MyData"
                con.Close()
            End If

            Dim conteo As Integer = 0

            barsube.Value = 0
            barsube.Maximum = DataGridView1.Rows.Count

            cnn1.Close() : cnn1.Open()

            Dim nombre, compania, rfc, curp, calle, colonia, cp, delegacion, entidad, telefono, facebook, correo As String
            Dim saldo, credito, dias As Double

            Dim contadorconexion As Integer = 0

            For dx As Integer = 0 To DataGridView1.Rows.Count - 1
                contadorconexion += 1

                nombre = NulCad(DataGridView1.Rows(dx).Cells(0).Value.ToString())
                compania = NulCad(DataGridView1.Rows(dx).Cells(1).Value.ToString())
                rfc = NulCad(DataGridView1.Rows(dx).Cells(2).Value.ToString())
                curp = NulCad(DataGridView1.Rows(dx).Cells(3).Value.ToString())
                calle = NulCad(DataGridView1.Rows(dx).Cells(4).Value.ToString())
                colonia = NulCad(DataGridView1.Rows(dx).Cells(5).Value.ToString())
                cp = NulCad(DataGridView1.Rows(dx).Cells(6).Value.ToString())
                delegacion = NulCad(DataGridView1.Rows(dx).Cells(7).Value.ToString())
                entidad = NulCad(DataGridView1.Rows(dx).Cells(8).Value.ToString())
                telefono = NulCad(DataGridView1.Rows(dx).Cells(9).Value.ToString())
                facebook = NulCad(DataGridView1.Rows(dx).Cells(10).Value.ToString())
                correo = NulCad(DataGridView1.Rows(dx).Cells(11).Value.ToString())
                saldo = NulVa(DataGridView1.Rows(dx).Cells(12).Value.ToString())
                credito = NulVa(DataGridView1.Rows(dx).Cells(13).Value.ToString())
                dias = NulVa(DataGridView1.Rows(dx).Cells(14).Value.ToString())


                If contadorconexion > 499 Then
                    cnn1.Close() : cnn1.Open()
                    contadorconexion = 1
                End If

                If (Comprueba(nombre)) Then

                    If cnn1.State = 0 Then cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "INSERT INTO proveedores(NComercial,Compania,RFC,CURP,Calle,Colonia,CP,Delegacion,Entidad,Telefono,Facebook,Correo,Saldo,Credito,DiasCred,Cargado) VALUES('" & nombre & "','" & compania & "','" & rfc & "','" & curp & "','" & calle & "','" & colonia & "','" & cp & "','" & delegacion & "','" & entidad & "','" & telefono & "','" & facebook & "','" & correo & "'," & saldo & "," & credito & "," & dias & ",0)"
                    cmd1.ExecuteNonQuery()

                Else
                    conteo += 1
                    barsube.Value = conteo
                    Continue For
                End If

                conteo += 1
                barsube.Value = conteo
            Next

            cnn1.Close()
            tabla.DataSource = Nothing
            tabla.Dispose()
            DataGridView1.Rows.Clear()
            barsube.Value = 0

            MsgBox(conteo & " proveedores fueron importados correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")


        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try

    End Sub

    Private Function Comprueba(ByVal nombre As String) As Boolean
        Try
            Dim valida As Boolean = True
            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT * FROM proveedores WHERE NComercial='" & nombre & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    MsgBox("Ya cuentas con un proveedor registrado con el nombre " & nombre & ".", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    valida = False
                    Exit Function
                End If
            End If
            rd2.Close()
            cnn2.Close()
            Return valida
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
        End Try
        Return Nothing
    End Function

    Private Function NulCad(ByVal cadena As String) As String
        If IsDBNull(cadena) Then
            NulCad = ""
        Else
            NulCad = Replace(cadena, "'", "") : Replace(cadena, "*", "")
        End If
    End Function

    Private Function NulVa(ByVal cifra As Double) As Double
        If IsDBNull(cifra) Then
            NulVa = 0
        Else
            NulVa = cifra
        End If
    End Function

    Private Sub btnMigrar_Click(sender As Object, e As EventArgs) Handles btnMigrar.Click

        btnMigrar.Enabled = False
        My.Application.DoEvents()
        Dim cnn1 As OleDb.OleDbConnection = New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & My.Application.Info.DirectoryPath & "\BaseExportar\DL1.mdb;;Persist Security Info=True;Jet OLEDB:Database Password=jipl22")
        Dim cmd1 As OleDbCommand = New OleDbCommand
        Dim rd1 As OleDbDataReader
        Dim cuantos As Integer = 0

        Dim nombre As String = ""
        Dim compania As String = ""
        Dim rfc As String = ""
        Dim curp As String = ""
        Dim calle As String = ""
        Dim colonia As String = ""
        Dim cp As String = ""
        Dim delegacion As String = ""
        Dim entidad As String = ""
        Dim telefono As String = ""
        Dim facebook As String = ""
        Dim correo As String = ""
        Dim saldo As Double = 0
        Dim credio As Double = 0
        Dim diascred As Double = 0

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM proveedores WHERE NComercial ORDER By NComercial"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                Do While rd1.Read

                    nombre = rd1("NComercial").ToString
                    compania = rd1("Compañia").ToString
                    rfc = rd1("RFC").ToString
                    curp = rd1("CURP").ToString
                    calle = rd1("Calle").ToString
                    colonia = rd1("Colonia").ToString
                    cp = rd1("CP").ToString
                    delegacion = rd1("Delegacion").ToString
                    entidad = rd1("EntFed").ToString
                    telefono = rd1("Tel1").ToString
                    facebook = rd1("PagWeb").ToString
                    correo = rd1("Email").ToString
                    saldo = rd1("Saldo").ToString
                    credio = rd1("Credito").ToString
                    diascred = rd1("DiasCredito").ToString

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO proveedores(NComercial,Compania,RFC,CURP,Calle,Colonia,CP,Delegacion,Entidad,Telefono,Facebook,Correo,Saldo,Credito,DiasCred,Cargado) VALUES('" & nombre & "','" & compania & "','" & rfc & "','" & curp & "','" & calle & "','" & colonia & "','" & cp & "','" & delegacion & "','" & entidad & "','" & telefono & "','" & facebook & "','" & correo & "'," & saldo & "," & credio & "," & diascred & ",0)"
                    If cmd2.ExecuteNonQuery() Then
                        cuantos = cuantos + 1
                    Else
                        MsgBox("Revisa el nombre " & nombre & " hay un error", vbCritical + vbOKOnly)
                    End If

                Loop
                cnn2.Close()
                MsgBox("Se insertaron " & cuantos & " productos")
                rd1.Close()
                cnn1.Close()
            End If
            My.Application.DoEvents()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

        My.Application.DoEvents()
        btnMigrar.Enabled = True
    End Sub
End Class
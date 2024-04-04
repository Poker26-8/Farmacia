Public Class frmHabitaciones
    Private Sub frmHabitaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cbonumero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbonumero.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then

            cboUbicacion.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboUbicacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboUbicacion.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboTipo.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboTipo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboTipo.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtHoras.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtprecio_KeyPress(sender As Object, e As KeyPressEventArgs) 
        If AscW(e.KeyChar) = Keys.Enter Then
            rtbCaracteristicas.Focus.Equals(True)
        End If
    End Sub

    Private Sub rtbCaracteristicas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rtbCaracteristicas.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            btnGuardar.Focus.Equals(True)
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Try
            If cbonumero.Text = "" Then MsgBox("Debe de asignarle un número o nombre a la habitación", vbInformation + vbOKOnly, titulohotelriaa) : cbonumero.Focus.Equals(True) : Exit Sub

            If cboUbicacion.Text = "" Then MsgBox("Debe de asignar la ubicacion de la habitación", vbInformation + vbOKOnly, titulohotelriaa) : cboUbicacion.Focus.Equals(True) : Exit Sub

            If cboTipo.Text = "" Then MsgBox("Debe de asignar el tipo de habitación", vbInformation + vbOKOnly, titulohotelriaa) : cboTipo.Focus.Equals(True) : Exit Sub

            'If txtprecio.Text = "" Then MsgBox("Debe de asignarle un precio a la habitación", vbInformation + vbOKOnly, titulohotelriaa) : txtprecio.Focus.Equals(True) : Exit Sub

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM habitacion WHERE N_Habitacion='" & cbonumero.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "UPDATE habitacion SET Ubicacion='" & cboUbicacion.Text & "',Tipo='" & cboTipo.Text & "',Caracteristicas='" & rtbCaracteristicas.Text & "',Horas=" & txtHoras.Text & ",PrecioH=" & txtPrecioH.Text & ",PreDia=" & txtPreDia.Text & " WHERE N_Habitacion='" & cbonumero.Text & "'"
                    If cmd2.ExecuteNonQuery() Then
                        MsgBox("Habitación " & cbonumero.Text & " actualizada correctamente", vbInformation + vbOKOnly, titulohotelriaa)
                    End If
                    cnn2.Close()
                    btnLimpiar.PerformClick()
                End If
            Else

                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "INSERT INTO habitacion(N_Habitacion,Ubicacion,Tipo,Estado,Caracteristicas,Tiempo,Horas,PrecioH,PreDia) VALUES('" & cbonumero.Text & "','" & cboUbicacion.Text & "','" & cboTipo.Text & "','Desocupada','" & rtbCaracteristicas.Text & "',1," & txtHoras.Text & "," & txtPrecioH.Text & "," & txtPreDia.Text & ")"
                If cmd2.ExecuteNonQuery() Then
                    MsgBox("Habitacion " & cbonumero.Text & " agregada correctamente", vbInformation + vbOKOnly, titulohotelriaa)
                End If
                cnn2.Close()
                btnLimpiar.PerformClick()
            End If
            rd1.Close()
            cnn1.Close()
            Me.Close()
            frmManejo.primerBoton()
            frmManejo.btnLimpiar.PerformClick()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        cbonumero.Text = ""
        cboUbicacion.Text = ""
        cboTipo.Text = ""
        ' txtprecio.Text = ""
        rtbCaracteristicas.Text = ""
        txtHoras.Text = ""
        txtPrecioH.Text = "0.00"
        txtPreDia.Text = "0.00"
    End Sub

    Private Sub cbonumero_DropDown(sender As Object, e As EventArgs) Handles cbonumero.DropDown
        Try
            cbonumero.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT N_Habitacion FROM habitacion WHERE N_Habitacion<>'' ORDER BY N_Habitacion"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cbonumero.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close() : cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cbonumero_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbonumero.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM habitacion WHERE N_Habitacion='" & cbonumero.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cboUbicacion.Text = rd1("Ubicacion").ToString
                    cboTipo.Text = rd1("Tipo").ToString
                    ' txtprecio.Text = rd1("Precio").ToString
                    rtbCaracteristicas.Text = rd1("Caracteristicas").ToString

                    txtHoras.Text = rd1("Horas").ToString
                    txtPrecioH.Text = rd1("PrecioH").ToString
                    txtPreDia.Text = rd1("PreDia").ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboUbicacion_DropDown(sender As Object, e As EventArgs) Handles cboUbicacion.DropDown
        Try
            cboUbicacion.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Ubicacion FROM habitacion WHERE Ubicacion<>'' ORDER BY Ubicacion"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboUbicacion.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
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

            'Variables para alojar los datos del archivo de excel
            Dim habitacion, ubicacion, tipo, caracteristicas As String

            Dim precio As Double = 0
            Dim conteo As Integer = 0

            barsube.Value = 0
            barsube.Maximum = DataGridView1.Rows.Count

            cnn1.Close() : cnn1.Open()

            Dim contadorconexion As Integer = 0

            For zef As Integer = 0 To DataGridView1.Rows.Count - 1

                contadorconexion += 1

                habitacion = UCase(NulCad(DataGridView1.Rows(zef).Cells(0).Value.ToString()))
                If habitacion = "" Then Exit For
                ubicacion = UCase(DataGridView1.Rows(zef).Cells(1).Value.ToString())
                tipo = UCase(NulCad(DataGridView1.Rows(zef).Cells(2).Value.ToString()))
                precio = NulVa(DataGridView1.Rows(zef).Cells(3).Value.ToString())
                caracteristicas = UCase(DataGridView1.Rows(zef).Cells(4).Value.ToString())


                If contadorconexion > 499 Then
                    cnn1.Close() : cnn1.Open()
                    contadorconexion = 1
                End If

                If (Comprueba(habitacion)) Then
                    If cnn1.State = 0 Then cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into habitacion(N_Habitacion,Ubicacion,Tipo,Estado,Precio,Caracteristicas,Tiempo) values('" & habitacion & "','" & ubicacion & "','" & tipo & "','Desocupada'," & precio & ",'" & caracteristicas & "',1)"
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

            MsgBox(conteo & " productos fueron importados correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Function Comprueba(ByVal habi As String) As Boolean
        Try
            Dim valida As Boolean = True
            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT * FROM habitacion WHERE N_Habitacion='" & habi & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    MsgBox("Ya cuentas con una habitación registrado con este nombre " & habi & ".", vbInformation + vbOKOnly, titulohotelriaa)
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

    Private Sub txtHoras_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtHoras.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(txtHoras.Text) Then
                txtPrecioH.Focus.Equals(True)
            End If
        End If
    End Sub

    Private Sub txtPrecioH_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecioH.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(txtPrecioH.Text) Then
                txtPreDia.Focus.Equals(True)
            End If
        End If
    End Sub

    Private Sub txtPreDia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPreDia.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(txtPreDia.Text) Then
                btnGuardar.Focus.Equals(True)
            End If
        End If
    End Sub
End Class
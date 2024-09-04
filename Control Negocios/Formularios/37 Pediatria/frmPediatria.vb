Imports System.Windows.Forms.DataVisualization.Charting

Public Class frmPediatria
    Private Sub frmPediatria_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cboCliente_DropDown(sender As Object, e As EventArgs) Handles cboCliente.DropDown
        Try
            cboCliente.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nombre FROM clientes WHERE Nombre<>'' ORDER BY Nombre"
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

    Private Sub cboMedico_DropDown(sender As Object, e As EventArgs) Handles cboMedico.DropDown
        Try
            cboMedico.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nombre FROM usuarios WHERE Area='MEDICO' ORDER BY Nombre"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboMedico.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboUrgencia_DropDown(sender As Object, e As EventArgs) Handles cboUrgencia.DropDown
        Try
            cboUrgencia.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Urgencia FROM hisclinica WHERE Urgencia<>'' ORDER BY Urgencia"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboUrgencia.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboCliente.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtPeso.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtPeso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPeso.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(txtPeso.Text) Then
                txtTemperatura.Focus.Equals(True)
            End If
        End If
    End Sub

    Private Sub txtTemperatura_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTemperatura.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(txtTemperatura.Text) Then
                dtpNacimiento.Focus.Equals(True)
            End If
        End If
    End Sub

    Private Sub dtpNacimiento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtpNacimiento.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            dtpAlergia.Focus.Equals(True)
        End If
    End Sub

    Private Sub dtpAlergia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtpAlergia.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtAlergias.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtAlergias_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAlergias.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtMotivo.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtMotivo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMotivo.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtMama.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtMama_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMama.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtTelM.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtTelM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelM.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(txtTelM.Text) Then
                txtPapa.Focus.Equals(True)
            End If
        End If
    End Sub

    Private Sub txtPapa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPapa.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtTelP.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtTelP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelP.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(txtTelP.Text) Then
                txtTutor.Focus.Equals(True)
            End If
        End If
    End Sub

    Private Sub txtTutor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTutor.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtT.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtT.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(txtT.Text) Then
                cboMedico.Focus.Equals(True)
            End If
        End If
    End Sub

    Private Sub cboMedico_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboMedico.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboUrgencia.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboUrgencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboUrgencia.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            btnSave.Focus.Equals(True)
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        cboCliente.Text = ""
        dtpNacimiento.Value = Date.Now
        dtpAlergia.Value = Date.Now
        txtAlergias.Text = ""
        txtMotivo.Text = ""
        txtMama.Text = ""
        txtPapa.Text = ""
        txtTutor.Text = ""
        txtTelM.Text = ""
        txtTelP.Text = ""
        txtT.Text = ""
        cboMedico.Text = ""
        cboUrgencia.Text = ""
        cbxFem.Checked = False
        cbxMas.Checked = False
        txtPeso.Text = ""
        txtTemperatura.Text = ""
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
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
            Dim id, nombre As String

            barsube.Value = 0
            barsube.Maximum = DataGridView1.Rows.Count

            cnn1.Close() : cnn1.Open()
            Dim contadorconexion As Integer = 0

            For Each row As DataGridViewRow In DataGridView1.Rows

                If row.IsNewRow Then Continue For ' Ignorar la última fila nueva

                contadorconexion += 1

                id = NulCad((row).Cells(0).Value.ToString())
                nombre = NulCad((row).Cells(1).Value.ToString())

                If contadorconexion > 499 Then
                    cnn1.Close() : cnn1.Open()
                    contadorconexion = 1
                End If

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "INSERT INTO padecimiento(CKey,Nombre) VALUES('" & id & "','" & nombre & "')"
                cmd1.ExecuteNonQuery()

                conteo += 1
                barsube.Value = conteo
            Next
            cnn1.Close()
            tabla.DataSource = Nothing
            tabla.Dispose()
            DataGridView1.Rows.Clear()
            barsube.Value = 0

            MsgBox(conteo & " padecimeintos fueron importados correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Function NulCad(ByVal cadena As String) As String
        If IsDBNull(cadena) Then
            NulCad = ""
        Else
            NulCad = Replace(cadena, "'", "") : Replace(cadena, "*", "")
        End If
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim EDAD As String = ""
        ' Fecha de nacimiento
        Dim fechaNacimiento As DateTime = dtpNacimiento.Value

        ' Fecha actual
        Dim fechaActual As DateTime = Date.Now

        ' Cálculo de la edad
        Dim edadAños As Integer = fechaActual.Year - fechaNacimiento.Year
        Dim edadMeses As Integer = fechaActual.Month - fechaNacimiento.Month
        Dim edadDias As Integer = fechaActual.Day - fechaNacimiento.Day

        ' Ajuste si la diferencia en meses o días es negativa
        If edadMeses < 0 Then
            edadAños -= 1
            edadMeses += 12
        End If

        If edadDias < 0 Then
            edadMeses -= 1

            ' Obtener el número de días en el mes anterior a la fecha actual
            Dim mesAnterior As Integer = If(fechaActual.Month = 1, 12, fechaActual.Month - 1)
            Dim añoAnterior As Integer = If(mesAnterior = 12, fechaActual.Year - 1, fechaActual.Year)
            Dim díasMesAnterior As Integer = DateTime.DaysInMonth(añoAnterior, mesAnterior)

            edadDias += díasMesAnterior
        End If

        If edadAños > 0 Then
            EDAD = edadAños & " Años"
        ElseIf edadMeses > 0 Then
            EDAD = edadMeses & " Meses"
        ElseIf edadDias > 0 Then
            EDAD = edadDias & " Días"
        End If

        ' Mostrar el resultado
        'MessageBox.Show($"Edad: {edadAños} años, {edadMeses} meses y {edadDias} días")
        ' edadAños & " años," & edadMeses & " meses y " & edadDias & " días"

        Dim guarda As Boolean = False

        '---------------------------------validaciones de cajas vacias------------------------------------

        If cboCliente.Text = "" Then MsgBox("Ingrese el nombre del paciente.", vbInformation + vbOKOnly, titulocentral) : cboCliente.Focus.Equals(True) : Exit Sub

        If txtTutor.Text = "" Then MsgBox("Ingrese el nombre del tutor.", vbInformation + vbOKOnly, titulocentral) : txtTutor.Focus.Equals(True) : Exit Sub

        If cboMedico.Text = "" Then MsgBox("Seleccione un médico", vbInformation + vbOKOnly, titulocentral) : cboMedico.Focus.Equals(True) : Exit Sub

        If cboUrgencia.Text = "" Then MsgBox("Selecciona o ingresa la urgencia de la consulta.", vbInformation + vbOKOnly, titulocentral) : cboUrgencia.Focus.Equals(True) : Exit Sub



        ' ---------------------------------------------variables------------------------------------------
        Dim sex As Integer = 0

        If (cbxFem.Checked) Then
            sex = 0
        End If

        If (cbxMas.Checked) Then
            sex = 1
        End If

        Dim alergias As String = ""
        alergias = txtAlergias.Text.TrimEnd(vbCrLf.ToCharArray)

        Dim motivo As String = ""
        motivo = txtMotivo.Text.TrimEnd(vbCrLf.ToCharArray)

        '-------------------------------------INgreso a las tablas---------------------------------------

        If MsgBox("¿Desea guardar los datos de ésta consulta?", vbOKCancel + vbInformation, "Delsscom Control Consultorios") = vbCancel Then guarda = False : Exit Sub

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Id FROM clientes WHERE Nombre='" & cboCliente.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO hisclinica(Medico,Fecha,Hora,Paciente,Urgencia,Tutor,Sexo,FNacimiento,Edad,Peso,Alergias,Temperatura,MotivoConsulta) VALUES('" & cboMedico.Text & "','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','" & cboCliente.Text & "','" & cboUrgencia.Text & "','" & txtTutor.Text & "'," & sex & ",'" & Format(dtpNacimiento.Value, "yyyy-MM-dd") & "','" & EDAD & "','" & txtPeso.Text & "','" & alergias & "','" & txtTemperatura.Text & "','" & motivo & "')"
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()
                End If
            Else
                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "INSERT INTO Clientes(Nombre,RazonSocial,Tipo,Telefono,Sexo) VALUES('" & cboCliente.Text & "','" & txtTutor.Text & "','Lista','" & txtT.Text & "'," & sex & ")"
                cmd2.ExecuteNonQuery()

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "INSERT INTO hisclinica(Medico,Fecha,Hora,Paciente,Urgencia,Tutor,Sexo,FNacimiento,Edad,Peso,Alergias,Temperatura,MotivoConsulta) VALUES('" & cboMedico.Text & "','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','" & cboCliente.Text & "','" & cboUrgencia.Text & "','" & txtTutor.Text & "'," & sex & ",'" & Format(dtpNacimiento.Value, "yyyy-MM-dd") & "','" & EDAD & "','" & txtPeso.Text & "','" & alergias & "','" & txtTemperatura.Text & "','" & motivo & "')"
                If cmd2.ExecuteNonQuery() Then
                    MsgBox("Cita agregada correctamente", vbInformation + vbOKOnly, titulocentral)
                    btnLimpiar.PerformClick()
                End If
                cnn2.Close()

            End If
            rd1.Close()
            cnn1.Close()

            btnLimpiar.PerformClick()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub
End Class
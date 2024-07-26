Public Class frmVehiculoTa
    Private Sub frmVehiculoTa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Obtener el año actual
        Dim añoActual As Integer = DateTime.Now.Year

        ' Agregar años desde 1900 hasta el año actual al ComboBox
        For i As Integer = añoActual To 1920 Step -1
            cboA.Items.Add(i.ToString())
        Next
    End Sub

    Private Sub cbomarca_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbomarca.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtSubmarca.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtSubmarca_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSubmarca.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cbomodelo.Focus.Equals(True)
        End If
    End Sub

    Private Sub cbomodelo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbomodelo.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboA.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboA_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboA.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboCliente.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboCliente.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtPlacas.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtPlacas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPlacas.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            rtObservaciones.Focus.Equals(True)
        End If
    End Sub

    Private Sub cbomarca_DropDown(sender As Object, e As EventArgs) Handles cbomarca.DropDown
        Try
            cbomarca.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nombre FROM marcas WHERE Nombre<>'' ORDER BY Nombre"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cbomarca.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cbomodelo_DropDown(sender As Object, e As EventArgs) Handles cbomodelo.DropDown
        Try
            cbomodelo.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Modelo FROM vehiculo2 WHERE Marca='" & cbomarca.Text & "' AND Modelo<>'' ORDER BY Modelo"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cbomodelo.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
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

    Private Sub btnlimpiar_Click(sender As Object, e As EventArgs) Handles btnlimpiar.Click
        cbomarca.Text = ""
        txtSubmarca.Text = ""
        cbomodelo.Text = ""
        cboA.Text = ""
        cboCliente.Text = ""
        txtPlacas.Text = ""
        rtObservaciones.Text = ""
        cbomodelo.Focus.Equals(True)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click
        Try
            Dim observaciones As String = ""
            observaciones = rtObservaciones.Text.TrimEnd(vbCrLf.ToCharArray)

            Dim dire(4) As String
            Dim direccion As String = ""

            dire(0) = cbomarca.Text       'Calle
            dire(1) = cbomodelo.Text  'Numero Int
            dire(2) = cboA.Text  'Numero Ext
            dire(3) = txtPlacas.Text

            'Calle
            If Trim(dire(0)) <> "" Then
                direccion = direccion & dire(0) & " "
            End If
            'Numero Int
            If Trim(dire(1)) <> "" Then
                direccion = direccion & dire(1) & " "
            End If
            'Numero Ext
            If Trim(dire(2)) <> "" Then
                direccion = direccion & dire(2) & " "
            End If
            If Trim(dire(3)) <> "" Then
                direccion = direccion & dire(3) & " "
            End If


            If txtPlacas.Text = "" Then MsgBox("Ingrese la placa del vehiculo", vbInformation + vbOKOnly, titulocentral) : txtPlacas.Focus.Equals(True) : Exit Sub

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Placa FROM vehiculo WHERE Placa='" & txtPlacas.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then

                End If
            Else
                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "INSERT INTO vehiculo(Placa,Descripcion,Marca,Submarca,Modelo,Ano,Cliente,StatusT,Observaciones) VALUES('" & txtPlacas.Text & "','" & direccion & "','" & cbomarca.Text & "','" & txtSubmarca.Text & "','" & cbomodelo.Text & "'," & cboA.Text & ",'" & cboCliente.Text & "',1,'" & observaciones & "')"
                If cmd2.ExecuteNonQuery() Then
                    MsgBox("Vehiculo agregado correctamente", vbInformation + vbOKOnly, titulocentral)
                End If
                cnn2.Close()
            End If
            rd1.Close()
            cnn1.Close()
            btnlimpiar.PerformClick()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub rtObservaciones_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rtObservaciones.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnguardar.Focus.Equals(True)
        End If
    End Sub
End Class
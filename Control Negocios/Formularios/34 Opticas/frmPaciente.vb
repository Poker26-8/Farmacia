
Imports System.IO
Public Class frmPaciente
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
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

    Private Sub cboCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboCliente.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboMedico.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtEsfericoD_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEsfericoD.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtCilindroD.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtCilindroD_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCilindroD.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtEjeD.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtEjeD_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEjeD.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtAddD.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtAddD_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAddD.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtDPI.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtDPI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDPI.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtEsfericoI.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtEsfericoI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEsfericoI.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then

            txtCilindroI.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtCilindroI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCilindroI.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtEjeI.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtEjeI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEjeI.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtAddI.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtAddI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAddI.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            rbNotas.Focus.Equals(True)
        End If
    End Sub

    Private Sub rbNotas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rbNotas.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnGuardar.Focus.Equals(True)
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        cboCliente.Text = ""
        txtEsfericoD.Text = ""
        txtCilindroD.Text = ""
        txtEjeD.Text = ""
        txtAddD.Text = ""
        txtEsfericoI.Text = ""
    End Sub

    Private Sub cboMedico_DropDown(sender As Object, e As EventArgs) Handles cboMedico.DropDown
        Try
            cboMedico.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nombre FROM usuarios WHERE Nombre<>'' ORDER BY Nombre"
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

    Private Sub cboMedico_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboMedico.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtEsfericoD.Focus.Equals(True)
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Id FROM optica WHERE Cliente='" & cboCliente.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO optica(Cliente,Medico,EsfD,CilD,EjeD,AddD,EsfI,CilI,EjeI,AddI,DIP,Nota,Fecha,Usuario) VALUES('" & cboCliente.Text & "','" & cboMedico.Text & "','" & txtEsfericoD.Text & "','" & txtCilindroD.Text & "','" & txtEjeD.Text & "','" & txtAddD.Text & "','" & txtEsfericoI.Text & "','" & txtCilindroI.Text & "','" & txtEjeI.Text & "','" & txtAddI.Text & "','" & txtDPI.Text & "','" & rbNotas.Text & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & lblUsuario.Text & "')"
                    If cmd2.ExecuteNonQuery() Then
                        MsgBox("Registrio agregado correctamente", vbInformation + vbOKOnly, titulocentral)
                    End If
                    cnn2.Close()
                End If
            Else
                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "INSERT INTO optica(Cliente,Medico,EsfD,CilD,EjeD,AddD,EsfI,CilI,EjeI,AddI,DIP,Nota,Fecha,Usuario) VALUES('" & cboCliente.Text & "','" & cboMedico.Text & "','" & txtEsfericoD.Text & "','" & txtCilindroD.Text & "','" & txtEjeD.Text & "','" & txtAddD.Text & "','" & txtEsfericoI.Text & "','" & txtCilindroI.Text & "','" & txtEjeI.Text & "','" & txtAddI.Text & "','" & txtDPI.Text & "','" & rbNotas.Text & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & lblUsuario.Text & "')"
                If cmd2.ExecuteNonQuery() Then
                    MsgBox("Registrio agregado correctamente", vbInformation + vbOKOnly, titulocentral)
                End If
                cnn2.Close()
            End If
            rd1.Close()
            cnn1.Close()

            Dim tamticket As Integer = 0
            Dim impresora As String = ""

            impresora = ImpresoraImprimir()
            tamticket = TamImpre()

            If TamImpre() = "80" Then
                POptica80.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                POptica80.Print()
            End If

            If TamImpre() = "58" Then
                pOptica58.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                pOptica58.Print()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub txtContraseña_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContraseña.KeyPress
        Try
            If AscW(e.KeyChar) = Keys.Enter Then
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Alias,Status FROM usuarios WHERE Clave='" & txtContraseña.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        If rd1(1).ToString = 1 Then
                            lblUsuario.Text = rd1(0).ToString
                        Else
                            MsgBox("El usuario esta inactivo", vbInformation + vbOKOnly, titulocentral)
                            txtContraseña.Text = ""
                            lblUsuario.Text = ""
                            txtContraseña.Focus.Equals(True)
                            Exit Sub
                        End If
                    End If
                Else
                    MsgBox("Contraseña incorrecta", vbInformation + vbOKOnly, titulocentral)
                    txtContraseña.Text = ""
                    lblUsuario.Text = ""
                    txtContraseña.Focus.Equals(True)
                    Exit Sub
                End If
                rd1.Close()
                cnn1.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub POptica80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles POptica80.PrintPage
        Try
            Dim tipografia As String = "Lucida Sans Typewriter"
            Dim fuente_r As New Font("Lucida Sans Typewriter", 8, FontStyle.Regular)
            Dim fuente_b As New Font("Lucida Sans Typewriter", 8, FontStyle.Bold)
            Dim fuente_c As New Font("Lucida Sans Typewriter", 10, FontStyle.Regular)
            Dim fuente_p As New Font("Lucida Sans Typewriter", 7, FontStyle.Regular)
            Dim fuente_a As New Font("Lucida Sans Typewriter", 12, FontStyle.Bold)

            Dim derecha As New StringFormat With {.Alignment = StringAlignment.Far}
            Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
            Dim hoja As New Pen(Brushes.Black, 1)
            Dim Y As Double = 0

            Dim Logotipo As Drawing.Image = Nothing
            Dim nLogo As String = DatosRecarga("LogoG")
            Dim tLogo As String = DatosRecarga("TipoLogo")

            If tLogo <> "SIN" Then
                If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
                End If
                If tLogo = "CUAD" Then
                    e.Graphics.DrawImage(Logotipo, 80, 0, 120, 120)
                    Y += 130
                End If
                If tLogo = "RECT" Then
                    e.Graphics.DrawImage(Logotipo, 30, 0, 240, 110)
                    Y += 120
                End If
            Else
                Y = 0
            End If

            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select Cab0,Cab1,Cab2,Cab3,Cab4,Cab5,Cab6 from Ticket"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then

                    'Razón social
                    If rd2("Cab0").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab0").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                        Y += 12.5
                    End If
                    'RFC
                    If rd2("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab1").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                        Y += 12.5
                    End If
                    'Calle  N°.
                    If rd2("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab2").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Colonia
                    If rd2("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab3").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Delegación / Municipio - Entidad
                    If rd2("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab4").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Teléfono
                    If rd2("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab5").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Correo
                    If rd2("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab6").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    Y += 17
                End If
            Else
                Y += 0
            End If
            rd2.Close()
            cnn2.Close()

            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 11
            e.Graphics.DrawString("VISION DE LEJOS", fuente_b, Brushes.Black, 135, Y, sc)
            Y += 11
            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 11

            e.Graphics.DrawString("Cliente: " & cboCliente.Text, fuente_r, Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("Medico: " & cboMedico.Text, fuente_r, Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("O J O  D E  D E R E C H O", fuente_b, Brushes.Black, 135, Y, sc)
            Y += 20
            e.Graphics.DrawString("Esférico: ", fuente_r, Brushes.Black, 1, Y)
            e.Graphics.DrawString(txtEsfericoD.Text, fuente_r, Brushes.Black, 270, Y, derecha)
            Y += 15
            e.Graphics.DrawString("Cilindro: ", fuente_r, Brushes.Black, 1, Y)
            e.Graphics.DrawString(txtCilindroD.Text, fuente_r, Brushes.Black, 270, Y, derecha)
            Y += 15
            e.Graphics.DrawString("Eje: ", fuente_r, Brushes.Black, 1, Y)
            e.Graphics.DrawString(txtEjeD.Text, fuente_r, Brushes.Black, 270, Y, derecha)
            Y += 15
            e.Graphics.DrawString("Adición: ", fuente_r, Brushes.Black, 1, Y)
            e.Graphics.DrawString(txtAddD.Text, fuente_r, Brushes.Black, 270, Y, derecha)
            Y += 15
            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("O J O  D E  I Z Q U I E R D O", fuente_b, Brushes.Black, 135, Y, sc)
            Y += 20
            e.Graphics.DrawString("Esférico: ", fuente_r, Brushes.Black, 1, Y)
            e.Graphics.DrawString(txtEsfericoI.Text, fuente_r, Brushes.Black, 270, Y, derecha)
            Y += 15
            e.Graphics.DrawString("Cilindro: ", fuente_r, Brushes.Black, 1, Y)
            e.Graphics.DrawString(txtCilindroI.Text, fuente_r, Brushes.Black, 270, Y, derecha)
            Y += 15
            e.Graphics.DrawString("Eje: ", fuente_r, Brushes.Black, 1, Y)
            e.Graphics.DrawString(txtEjeI.Text, fuente_r, Brushes.Black, 270, Y, derecha)
            Y += 15
            e.Graphics.DrawString("Adición: ", fuente_r, Brushes.Black, 1, Y)
            e.Graphics.DrawString(txtAddI.Text, fuente_r, Brushes.Black, 270, Y, derecha)
            Y += 15
            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("DIP: " & txtDPI.Text, fuente_r, Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15

            Dim caracteresPorLinea As Integer = 30
            Dim texto As String = rbNotas.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, New Font("Arial", 9, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 13
                inicio += caracteresPorLinea
            End While
            Y += 5

            e.Graphics.DrawString("Lo atendio: " & lblUsuario.Text, fuente_r, Brushes.Black, 5, Y)

            e.HasMorePages = False
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub frmPaciente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
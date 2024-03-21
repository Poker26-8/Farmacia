Public Class frmPromociones
    Private Sub frmPromociones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CargarDatos()

    End Sub

    Public Sub CargarDatos()

        cbPromocion2x1.Checked = False
        ckhLunes.Checked = False
        chkMartes.Checked = False
        chkMiercoles.Checked = False
        chkJueves.Checked = False
        chkViernes.Checked = False
        chkSabado.Checked = False
        chkDomingo.Checked = False

        cbPromocion3.Checked = False
        chkLunes3.Checked = False
        chkMartes3.Checked = False
        chkMiercoles3.Checked = False
        chkJueves3.Checked = False
        chkViernes3.Checked = False
        chkSabado3.Checked = False
        chkDomingo3.Checked = False


        ckhLunes.Enabled = False
        chkMartes.Enabled = False
        chkMiercoles.Enabled = False
        chkJueves.Enabled = False
        chkViernes.Enabled = False
        chkSabado.Enabled = False
        chkDomingo.Enabled = False

        chkLunes3.Enabled = False
        chkMartes3.Enabled = False
        chkMiercoles3.Enabled = False
        chkJueves3.Enabled = False
        chkViernes3.Enabled = False
        chkSabado3.Enabled = False
        chkDomingo3.Enabled = False

        dtpInicioLunes.Text = "00:00:00"
        dtpFinLunes.Text = "23:59:59"
        dtpInicioLunes2.Text = "00:00:00"
        dtpFinLunes2.Text = "23:59:59"
        dtpInicioLunes3.Text = "00:00:00"
        dtpFinLunes3.Text = "23:59:59"
        dtpInicioLunes33.Text = "00:00:00"
        dtpFinLunes33.Text = "23:59:59"

        dtpInicioMartes.Text = "00:00:00"
        dtpFinMartes.Text = "23:59:59"
        dtpInicioMartes2.Text = "00:00:00"
        dtpFinMartes2.Text = "23:59:59"
        dtpInicioMartes3.Text = "00:00:00"
        dtpFinMartes3.Text = "23:59:59"
        dtpInicioMartes33.Text = "00:00:00"
        dtpFinMartes33.Text = "23:59:59"

        dtpInicioMiercoles.Text = "00:00:00"
        dtpFinMiercoles.Text = "23:59:59"
        dtpInicioMiercoles2.Text = "00:00:00"
        dtpFinMiercoles2.Text = "23:59:59"
        dtpInicioMiercoles3.Text = "00:00:00"
        dtpFinMiercoles3.Text = "23:59:59"
        dtpInicioMiercoles33.Text = "00:00:00"
        dtpFinMiercoles33.Text = "23:59:59"

        dtpInicioJueves.Text = "00:00:00"
        dtpFinJueves.Text = "23:59:59"
        dtpInicioJueves2.Text = "00:00:00"
        dtpFinJueves2.Text = "23:59:59"
        dtpInicioJueves3.Text = "00:00:00"
        dtpFinJueves3.Text = "23:59:59"
        dtpInicioJueves33.Text = "00:00:00"
        dtpFinJueves33.Text = "23:59:59"

        dtpInicioViernes.Text = "00:00:00"
        dtpFinViernes.Text = "23:59:59"
        dtpInicioViernes2.Text = "00:00:00"
        dtpFinViernes2.Text = "23:59:59"
        dtpInicioViernes3.Text = "00:00:00"
        dtpFinViernes3.Text = "23:59:59"
        dtpInicioViernes33.Text = "00:00:00"
        dtpFinViernes33.Text = "23:59:59"

        dtpInicioSabado.Text = "00:00:00"
        dtpFinSabado.Text = "23:59:59"
        dtpInicioSabado2.Text = "00:00:00"
        dtpFinSabado2.Text = "23:59:59"
        dtpInicioSabdo3.Text = "00:00:00"
        dtpFinSabado3.Text = "23:59:59"
        dtpInicioSabado33.Text = "00:00:00"
        dtpFinSabado33.Text = "23:59:59"

        dtpInicioDomingo.Text = "00:00:00"
        dtpFinDomingo.Text = "23:59:59"
        dtpInicioDomingo2.Text = "00:00:00"
        dtpFinDomingo2.Text = "23:59:59"
        dtpInicioDomingo3.Text = "00:00:00"
        dtpFinDomingo3.Text = "23:59:59"
        dtpInicioDomingo33.Text = "00:00:00"
        dtpFinDomingo33.Text = "23:59:59"
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        If MessageBox.Show("Desea Cerrar esta Ventana", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
            frmPromociones.ActiveForm.Close()
        End If
    End Sub

    Public Sub Abrir2x1()

        If (cbPromocion2x1.Checked) Then

            ckhLunes.Enabled = True
            chkMartes.Enabled = True
            chkMiercoles.Enabled = True
            chkJueves.Enabled = True
            chkViernes.Enabled = True
            chkSabado.Enabled = True
            chkDomingo.Enabled = True
        Else
            ckhLunes.Enabled = False
            chkMartes.Enabled = False
            chkMiercoles.Enabled = False
            chkJueves.Enabled = False
            chkViernes.Enabled = False
            chkSabado.Enabled = False
            chkDomingo.Enabled = False
        End If


        If (cbPromocion3.Checked) Then

            chkLunes3.Enabled = True
            chkMartes3.Enabled = True
            chkMiercoles3.Enabled = True
            chkJueves3.Enabled = True
            chkViernes3.Enabled = True
            chkSabado3.Enabled = True
            chkDomingo3.Enabled = True
        Else
            chkLunes3.Enabled = False
            chkMartes3.Enabled = False
            chkMiercoles3.Enabled = False
            chkJueves3.Enabled = False
            chkViernes3.Enabled = False
            chkSabado3.Enabled = False
            chkDomingo3.Enabled = False
        End If


    End Sub

    Private Sub cbPromocion2x1_CheckedChanged(sender As Object, e As EventArgs) Handles cbPromocion2x1.CheckedChanged
        Abrir2x1()
    End Sub

    Private Sub cbPromocion3_CheckedChanged(sender As Object, e As EventArgs) Handles cbPromocion3.CheckedChanged
        Abrir2x1()
    End Sub

    Private Sub ckhLunes_CheckedChanged(sender As Object, e As EventArgs) Handles ckhLunes.CheckedChanged
        If (ckhLunes.Checked) Then

            dtpInicioLunes.Enabled = True
            dtpFinLunes.Enabled = True
            dtpInicioLunes2.Enabled = True
            dtpFinLunes2.Enabled = True
        Else
            dtpInicioLunes.Enabled = False
            dtpFinLunes.Enabled = False
            dtpInicioLunes2.Enabled = False
            dtpFinLunes2.Enabled = False
        End If
    End Sub

    Private Sub chkMartes_CheckedChanged(sender As Object, e As EventArgs) Handles chkMartes.CheckedChanged
        If (chkMartes.Checked) Then

            dtpInicioMartes.Enabled = True
            dtpFinMartes.Enabled = True
            dtpInicioMartes2.Enabled = True
            dtpFinMartes2.Enabled = True
        Else
            dtpInicioMartes.Enabled = False
            dtpFinMartes.Enabled = False
            dtpInicioMartes2.Enabled = False
            dtpFinMartes2.Enabled = False

        End If
    End Sub

    Private Sub chkMiercoles_CheckedChanged(sender As Object, e As EventArgs) Handles chkMiercoles.CheckedChanged
        If (chkMiercoles.Checked) Then
            dtpInicioMiercoles.Enabled = True
            dtpFinMiercoles.Enabled = True
            dtpInicioMiercoles2.Enabled = True
            dtpFinMiercoles2.Enabled = True
        Else
            dtpInicioMiercoles.Enabled = False
            dtpFinMiercoles.Enabled = False
            dtpInicioMiercoles2.Enabled = False
            dtpFinMiercoles2.Enabled = False
        End If
    End Sub

    Private Sub chkJueves_CheckedChanged(sender As Object, e As EventArgs) Handles chkJueves.CheckedChanged

        If (chkJueves.Checked) Then
            dtpInicioJueves.Enabled = True
            dtpFinJueves.Enabled = True
            dtpInicioJueves2.Enabled = True
            dtpFinJueves2.Enabled = True
        Else
            dtpInicioJueves.Enabled = False
            dtpFinJueves.Enabled = False
            dtpInicioJueves2.Enabled = False
            dtpFinJueves2.Enabled = False
        End If
    End Sub

    Private Sub chkViernes_CheckedChanged(sender As Object, e As EventArgs) Handles chkViernes.CheckedChanged

        If (chkViernes.Checked) Then
            dtpInicioViernes.Enabled = True
            dtpFinViernes.Enabled = True
            dtpInicioViernes2.Enabled = True
            dtpFinViernes2.Enabled = True
        Else
            dtpInicioViernes.Enabled = False
            dtpFinViernes.Enabled = False
            dtpInicioViernes2.Enabled = False
            dtpFinViernes2.Enabled = False
        End If
    End Sub

    Private Sub chkSabado_CheckedChanged(sender As Object, e As EventArgs) Handles chkSabado.CheckedChanged
        If (chkSabado.Checked) Then
            dtpInicioSabado.Enabled = True
            dtpFinSabado.Enabled = True
            dtpInicioSabado2.Enabled = True
            dtpFinSabado2.Enabled = True
        Else
            dtpInicioSabado.Enabled = False
            dtpFinSabado.Enabled = False
            dtpInicioSabado2.Enabled = False
            dtpFinSabado2.Enabled = False
        End If
    End Sub

    Private Sub chkDomingo_CheckedChanged(sender As Object, e As EventArgs) Handles chkDomingo.CheckedChanged
        If (chkDomingo.Checked) Then
            dtpInicioDomingo.Enabled = True
            dtpFinDomingo.Enabled = True
            dtpInicioDomingo2.Enabled = True
            dtpFinDomingo2.Enabled = True
        Else
            dtpInicioDomingo.Enabled = False
            dtpFinDomingo.Enabled = False
            dtpInicioDomingo2.Enabled = False
            dtpFinDomingo2.Enabled = False
        End If
    End Sub

    Private Sub chkLunes3_CheckedChanged(sender As Object, e As EventArgs) Handles chkLunes3.CheckedChanged
        If (chkLunes3.Checked) Then
            dtpInicioLunes3.Enabled = True
            dtpFinLunes3.Enabled = True
            dtpInicioLunes33.Enabled = True
            dtpFinLunes33.Enabled = True
        Else
            dtpInicioLunes3.Enabled = False
            dtpFinLunes3.Enabled = False
            dtpInicioLunes33.Enabled = False
            dtpFinLunes33.Enabled = False
        End If
    End Sub

    Private Sub chkMartes3_CheckedChanged(sender As Object, e As EventArgs) Handles chkMartes3.CheckedChanged
        If (chkMartes3.Checked) Then
            dtpInicioMartes3.Enabled = True
            dtpFinMartes3.Enabled = True
            dtpInicioMartes33.Enabled = True
            dtpFinMartes33.Enabled = True
        Else
            dtpInicioMartes3.Enabled = False
            dtpFinMartes3.Enabled = False
            dtpInicioMartes33.Enabled = False
            dtpFinMartes33.Enabled = False
        End If
    End Sub

    Private Sub chkMiercoles3_CheckedChanged(sender As Object, e As EventArgs) Handles chkMiercoles3.CheckedChanged
        If (chkMiercoles3.Checked) Then
            dtpInicioMiercoles3.Enabled = True
            dtpFinMiercoles3.Enabled = True
            dtpInicioMiercoles33.Enabled = True
            dtpFinMiercoles33.Enabled = True
        Else
            dtpInicioMiercoles3.Enabled = False
            dtpFinMiercoles3.Enabled = False
            dtpInicioMiercoles33.Enabled = False
            dtpFinMiercoles33.Enabled = False
        End If
    End Sub

    Private Sub chkJueves3_CheckedChanged(sender As Object, e As EventArgs) Handles chkJueves3.CheckedChanged

        If (chkJueves3.Checked) Then
            dtpInicioJueves3.Enabled = True
            dtpFinJueves3.Enabled = True
            dtpInicioJueves33.Enabled = True
            dtpFinJueves33.Enabled = True
        Else
            dtpInicioJueves3.Enabled = False
            dtpFinJueves3.Enabled = False
            dtpInicioJueves33.Enabled = False
            dtpFinJueves33.Enabled = False
        End If
    End Sub

    Private Sub chkViernes3_CheckedChanged(sender As Object, e As EventArgs) Handles chkViernes3.CheckedChanged
        If (chkViernes3.Checked) Then
            dtpInicioViernes3.Enabled = True
            dtpFinViernes3.Enabled = True
            dtpInicioViernes33.Enabled = True
            dtpFinViernes33.Enabled = True
        Else
            dtpInicioViernes3.Enabled = False
            dtpFinViernes3.Enabled = False
            dtpInicioViernes33.Enabled = False
            dtpFinViernes33.Enabled = False
        End If
    End Sub

    Private Sub chkSabado3_CheckedChanged(sender As Object, e As EventArgs) Handles chkSabado3.CheckedChanged

        If (chkSabado3.Checked) Then
            dtpInicioSabdo3.Enabled = True
            dtpFinSabado3.Enabled = True
            dtpInicioSabado33.Enabled = True
            dtpFinSabado33.Enabled = True
        Else
            dtpInicioSabdo3.Enabled = False
            dtpFinSabado3.Enabled = False
            dtpInicioSabado33.Enabled = False
            dtpFinSabado33.Enabled = False
        End If
    End Sub

    Private Sub chkDomingo3_CheckedChanged(sender As Object, e As EventArgs) Handles chkDomingo3.CheckedChanged
        If (chkDomingo3.Checked) Then
            dtpInicioDomingo3.Enabled = True
            dtpFinDomingo3.Enabled = True
            dtpInicioDomingo33.Enabled = True
            dtpFinDomingo33.Enabled = True
        Else
            dtpInicioDomingo3.Enabled = False
            dtpFinDomingo3.Enabled = False
            dtpInicioDomingo33.Enabled = False
            dtpFinDomingo33.Enabled = False
        End If
    End Sub

    Private Sub cboNombre_DropDown(sender As Object, e As EventArgs) Handles cboNombre.DropDown
        cboNombre.Items.Clear()

        Try
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nombre FROM productos WHERE Nombre<>'' AND Grupo<>'INSUMO' ORDER BY Nombre"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboNombre.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboNombre.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboCodigo.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboNombre_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboNombre.SelectedValueChanged
        Try
            Dim lunes As Integer = 0
            Dim martes As Integer = 0
            Dim miercoles As Integer = 0
            Dim jueves As Integer = 0
            Dim viernes As Integer = 0
            Dim sabado As Integer = 0
            Dim domingo As Integer = 0
            Dim promocion2x1 As Integer = 0

            Dim promocion3x2 As Integer = 0
            Dim lunes2 As Integer = 0
            Dim martes2 As Integer = 0
            Dim miercoles2 As Integer = 0
            Dim jueves2 As Integer = 0
            Dim viernes2 As Integer = 0
            Dim sabado2 As Integer = 0
            Dim domingo2 As Integer = 0


            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Codigo,UVenta FROM productos WHERE Nombre='" & cboNombre.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cboCodigo.Text = rd1("Codigo").ToString
                    txtUnidad.Text = rd1("UVenta").ToString

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT * FROM promos WHERE Codigo='" & cboCodigo.Text & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then

                            lunes = rd2("Lunes").ToString
                            martes = rd2("Martes").ToString
                            miercoles = rd2("Miercoles").ToString
                            jueves = rd2("Jueves").ToString
                            viernes = rd2("Viernes").ToString
                            sabado = rd2("Sabado").ToString
                            domingo = rd2("Domingo").ToString

                            promocion2x1 = rd2("Promo2x1").ToString

                            If promocion2x1 = 1 Then
                                cbPromocion2x1.Checked = True
                            End If

                            If lunes = 1 Then
                                dtpInicioLunes.Enabled = True
                                dtpFinLunes.Enabled = True
                                dtpInicioLunes2.Enabled = True
                                dtpFinLunes2.Enabled = True

                                ckhLunes.Checked = True
                                dtpInicioLunes.Text = rd2("HInicioL").ToString
                                dtpFinLunes.Text = rd2("HFinL").ToString
                                dtpInicioLunes2.Text = rd2("HInicioL2").ToString
                                dtpFinLunes2.Text = rd2("HFinL2").ToString

                            End If

                            If martes = 1 Then
                                dtpInicioMartes.Enabled = True
                                dtpFinMartes.Enabled = True
                                dtpInicioMartes2.Enabled = True
                                dtpFinMartes2.Enabled = True

                                chkMartes.Checked = True
                                dtpInicioMartes.Text = rd2("HInicioM").ToString
                                dtpFinMartes.Text = rd2("HFinM").ToString
                                dtpInicioMartes2.Text = rd2("HInicioM2").ToString
                                dtpFinMartes2.Text = rd2("HFinM2").ToString
                            End If

                            If miercoles = 1 Then
                                dtpInicioMiercoles.Enabled = True
                                dtpFinMiercoles.Enabled = True
                                dtpInicioMiercoles2.Enabled = True
                                dtpFinMiercoles2.Enabled = True

                                chkMiercoles.Checked = True
                                dtpInicioMiercoles.Text = rd2("HInicioMi").ToString
                                dtpFinMiercoles.Text = rd2("HFinMi").ToString
                                dtpInicioMiercoles2.Text = rd2("HInicioMi2").ToString
                                dtpFinMiercoles2.Text = rd2("HFinMi2").ToString

                            End If

                            If jueves = 1 Then
                                dtpInicioJueves.Enabled = True
                                dtpFinJueves.Enabled = True
                                dtpInicioJueves2.Enabled = True
                                dtpFinJueves2.Enabled = True

                                chkJueves.Checked = True
                                dtpInicioJueves.Text = rd2("HInicioJ").ToString
                                dtpFinJueves.Text = rd2("HFinJ").ToString
                                dtpInicioJueves2.Text = rd2("HInicioJ2").ToString
                                dtpFinJueves2.Text = rd2("HFinJ2").ToString
                            End If

                            If viernes = 1 Then
                                dtpInicioViernes.Enabled = True
                                dtpFinViernes.Enabled = True
                                dtpInicioViernes2.Enabled = True
                                dtpFinViernes2.Enabled = True

                                chkViernes.Checked = True
                                dtpInicioViernes.Text = rd2("HInicioV").ToString
                                dtpFinViernes.Text = rd2("HFinV").ToString
                                dtpInicioViernes2.Text = rd2("HInicioV2").ToString
                                dtpFinViernes2.Text = rd2("HFinV2").ToString
                            End If

                            If sabado = 1 Then
                                dtpInicioSabado.Enabled = True
                                dtpFinSabado.Enabled = True
                                dtpInicioSabado2.Enabled = True
                                dtpFinSabado2.Enabled = True

                                chkSabado.Checked = True
                                dtpInicioSabado.Text = rd2("HInicioS").ToString
                                dtpFinSabado.Text = rd2("HFinS").ToString
                                dtpInicioSabado2.Text = rd2("HInicioS2").ToString
                                dtpFinSabado2.Text = rd2("HFinS2").ToString
                            End If

                            If domingo = 1 Then
                                dtpInicioDomingo.Enabled = True
                                dtpFinDomingo.Enabled = True
                                dtpInicioDomingo2.Enabled = True
                                dtpFinDomingo2.Enabled = True

                                chkDomingo.Checked = True
                                dtpInicioDomingo.Text = rd2("HInicioD").ToString
                                dtpFinDomingo.Text = rd2("HFinD").ToString
                                dtpInicioDomingo2.Text = rd2("HInicioD2").ToString
                                dtpFinDomingo2.Text = rd2("HFinD2").ToString
                            End If

                            promocion3x2 = rd2("Promo3x2").ToString

                            lunes2 = rd2("Lunes2").ToString
                            martes2 = rd2("Martes2").ToString
                            miercoles2 = rd2("Miercoles2").ToString
                            jueves2 = rd2("Jueves2").ToString
                            viernes2 = rd2("Viernes2").ToString
                            sabado2 = rd2("Sabado2").ToString
                            domingo2 = rd2("Domingo2").ToString

                            If promocion3x2 = 1 Then
                                cbPromocion3.Checked = True
                            End If

                            If lunes2 = 1 Then
                                dtpInicioLunes3.Enabled = True
                                dtpFinLunes3.Enabled = True
                                dtpInicioLunes33.Enabled = True
                                dtpFinLunes33.Enabled = True

                                chkLunes3.Checked = True
                                dtpInicioLunes3.Text = rd2("HinicioL3").ToString
                                dtpFinLunes3.Text = rd2("HFinL3").ToString
                                dtpInicioLunes33.Text = rd2("HInicioL33").ToString
                                dtpFinLunes33.Text = rd2("HFinL33").ToString
                            End If

                            If martes2 = 1 Then
                                dtpInicioMartes3.Enabled = True
                                dtpFinMartes3.Enabled = True
                                dtpInicioMartes33.Enabled = True
                                dtpFinMartes33.Enabled = True

                                chkMartes3.Checked = True
                                dtpInicioMartes3.Text = rd2("HInicioM3").ToString
                                dtpFinMartes3.Text = rd2("HFinM3").ToString
                                dtpInicioMartes33.Text = rd2("HInicioM33").ToString
                                dtpFinMartes33.Text = rd2("HFinM33").ToString
                            End If

                            If miercoles2 = 1 Then
                                dtpInicioMiercoles3.Enabled = True
                                dtpFinMiercoles3.Enabled = True
                                dtpInicioMiercoles33.Enabled = True
                                dtpFinMiercoles33.Enabled = True

                                chkMiercoles3.Checked = True
                                dtpInicioMiercoles3.Text = rd2("HInicioMi3").ToString
                                dtpFinMiercoles3.Text = rd2("HFinMi3").ToString
                                dtpInicioMiercoles33.Text = rd2("HInicioMi33").ToString
                                dtpFinMiercoles33.Text = rd2("HFinMi33").ToString
                            End If

                            If jueves2 = 1 Then
                                dtpInicioJueves3.Enabled = True
                                dtpFinJueves3.Enabled = True
                                dtpInicioJueves33.Enabled = True
                                dtpFinJueves33.Enabled = True

                                chkJueves3.Checked = True
                                dtpInicioJueves3.Text = rd2("HInicioJ3").ToString
                                dtpFinJueves3.Text = rd2("HFinJ3").ToString
                                dtpInicioJueves33.Text = rd2("HInicioJ33").ToString
                                dtpFinJueves33.Text = rd2("HFinJ33").ToString
                            End If

                            If viernes2 = 1 Then
                                dtpInicioViernes3.Enabled = True
                                dtpFinViernes3.Enabled = True
                                dtpInicioViernes33.Enabled = True
                                dtpFinViernes33.Enabled = True

                                chkViernes3.Checked = True
                                dtpInicioViernes3.Text = rd2("HInicioV3").ToString
                                dtpFinViernes3.Text = rd2("HFinV3").ToString
                                dtpInicioViernes33.Text = rd2("HInicioV33").ToString
                                dtpFinViernes33.Text = rd2("HFinV33").ToString
                            End If

                            If sabado2 = 1 Then
                                dtpInicioSabdo3.Enabled = True
                                dtpFinSabado3.Enabled = True
                                dtpInicioSabado33.Enabled = True
                                dtpFinSabado33.Enabled = True

                                chkSabado3.Checked = True
                                dtpInicioSabdo3.Text = rd2("HInicioS3").ToString
                                dtpFinSabado3.Text = rd2("HFinS3").ToString
                                dtpInicioSabado33.Text = rd2("HInicioS33").ToString
                                dtpFinSabado33.Text = rd2("HFinS33").ToString
                            End If

                            If domingo2 = 1 Then
                                dtpInicioDomingo3.Enabled = True
                                dtpFinDomingo3.Enabled = True
                                dtpInicioDomingo33.Enabled = True
                                dtpFinDomingo33.Enabled = True

                                chkDomingo3.Checked = 1
                                dtpInicioDomingo3.Text = rd2("HInicioD3").ToString
                                dtpFinDomingo3.Text = rd2("HFinD3").ToString
                                dtpInicioDomingo33.Text = rd2("HInicioD33").ToString
                                dtpFinDomingo33.Text = rd2("HFinD33").ToString
                            End If

                        End If
                    End If
                    rd2.Close()
                    cnn2.Close()

                End If
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboCodigo_DropDown(sender As Object, e As EventArgs) Handles cboCodigo.DropDown
        cboCodigo.Items.Clear()
        Try
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Codigo FROM productos WHERE Codigo<>'' AND GRupo<>'INSUMO' ORDER BY Codigo"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboCodigo.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try

    End Sub

    Private Sub cboCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboCodigo.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            btnGuardar.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboCodigo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboCodigo.SelectedValueChanged
        Try
            cnn3.Close() : cnn3.Open()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText =
                "SELECT * FROM productos WHERE Codigo='" & cboCodigo.Text & "'"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    cboNombre.Text = rd3("Nombre").ToString()
                    txtUnidad.Text = rd3("UVenta").ToString()
                End If
            End If
            rd3.Close()
            cnn3.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn3.Close()
        End Try
    End Sub

    Private Sub txtUnidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUnidad.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cbPromocion2x1.Focus.Equals(True)
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        cboCodigo.Text = ""
        cboNombre.Text = ""
        txtUnidad.Text = ""
        cboNombre.Focused.Equals(True)

        CargarDatos()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try

            If cboNombre.Text = "" Then MsgBox("Debe seleccionar un producto") : Exit Sub : cboNombre.Focus.Equals(True)

            cnn3.Close() : cnn3.Open()
            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "UPDATE productos SET E1=" & IIf(cbPromocion2x1.Checked, 1, 0) & ",E2=" & IIf(cbPromocion3.Checked, 1, 0) & " WHERE Codigo='" & cboCodigo.Text & "' AND Nombre='" & cboNombre.Text & "'"
            cmd3.ExecuteNonQuery()
            cnn3.Close()


            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM promos WHERE Codigo='" & cboCodigo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "UPDATE promos SET Promo2x1=" & IIf(cbPromocion2x1.Checked, 1, 0) & ",Lunes=" & IIf(ckhLunes.Checked, 1, 0) & ",Martes=" & IIf(chkMartes.Checked, 1, 0) & ",Miercoles=" & IIf(chkMiercoles.Checked, 1, 0) & ",Jueves=" & IIf(chkJueves.Checked, 1, 0) & ",Viernes=" & IIf(chkViernes.Checked, 1, 0) & ",Sabado=" & IIf(chkSabado.Checked, 1, 0) & ",Domingo=" & IIf(chkDomingo.Checked, 1, 0) & ",HInicioL='" & Format(dtpInicioLunes.Value, "HH:mm:ss") & "',HFinL='" & Format(dtpFinLunes.Value, "HH:mm:ss") & "',HInicioL2='" & Format(dtpInicioLunes2.Value, "HH:mm:ss") & "',HFinL2='" & Format(dtpFinLunes2.Value, "HH:mm:ss ") & "',HInicioM='" & Format(dtpInicioMartes.Value, "HH:mm:ss") & "',HFinM='" & Format(dtpFinMartes.Value, "HH:mm:ss") & "',HInicioM2='" & Format(dtpInicioMartes2.Value, "HH:mm:ss") & "',HFinM2='" & Format(dtpFinMartes2.Value, "HH:mm:ss") & "',HInicioMi='" & Format(dtpInicioMiercoles.Value, "HH:mm:ss") & "',HFinMi='" & Format(dtpFinMiercoles.Value, "HH:mm:ss") & "',HInicioMi2='" & Format(dtpInicioMiercoles2.Value, "HH:mm:ss") & "',HFinMi2='" & Format(dtpFinMiercoles2.Value, "HH:mm:ss") & "',HInicioJ='" & Format(dtpInicioJueves.Value, "HH:mm:ss") & "',HFinJ='" & Format(dtpFinJueves.Value, "HH:mm:ss") & "',HInicioJ2='" & Format(dtpInicioJueves2.Value, "HH:mm:ss") & "',HFinJ2='" & Format(dtpFinJueves2.Value, "HH:mm:ss") & "',HInicioV='" & Format(dtpInicioViernes.Value, "HH:mm:ss") & "',HFinV='" & Format(dtpFinViernes.Value, "HH:mm:ss") & "',HInicioV2='" & Format(dtpInicioViernes2.Value, "HH:mm:ss") & "',HFinV2='" & Format(dtpFinViernes2.Value, "HH:mm:ss") & "',HInicioS='" & Format(dtpInicioSabado.Value, "HH:mm:ss") & "',HFinS='" & Format(dtpFinSabado.Value, "HH:mm:ss") & "',HInicioS2='" & Format(dtpInicioSabado2.Value, "HH:mm:ss") & "',HFinS2='" & Format(dtpFinSabado2.Value, "HH:mm:ss") & "',HInicioD='" & Format(dtpInicioDomingo.Value, "HH:mm:ss") & "',HFinD='" & Format(dtpFinDomingo.Value, "HH:mm:ss") & "',HInicioD2='" & Format(dtpInicioDomingo2.Value, "HH:mm:ss") & "',HFinD2='" & Format(dtpFinDomingo2.Value, "HH:mm:ss") & "',Promo3x2=" & IIf(cbPromocion3.Checked, 1, 0) & ",Lunes2=" & IIf(chkLunes3.Checked, 1, 0) & ",Martes2=" & IIf(chkMartes3.Checked, 1, 0) & ",Miercoles2=" & IIf(chkMiercoles3.Checked, 1, 0) & ",Jueves2=" & IIf(chkJueves3.Checked, 1, 0) & ",Viernes2=" & IIf(chkViernes3.Checked, 1, 0) & ",Sabado2=" & IIf(chkSabado3.Checked, 1, 0) & ",Domingo2=" & IIf(chkDomingo3.Checked, 1, 0) & ",HInicioL3='" & Format(dtpInicioLunes3.Value, "HH:mm:ss") & "',HFinL3='" & Format(dtpFinLunes3.Value, "HH:mm:ss") & "',HInicioL33='" & Format(dtpInicioLunes33.Value, "HH:mm:ss") & "',HFinL33='" & Format(dtpFinLunes33.Value, "HH:mm:ss") & "',HInicioM3='" & Format(dtpInicioMartes3.Value, "HH:mm:ss") & "',HFinM3='" & Format(dtpFinMartes3.Value, "HH:mm:ss") & "',HInicioM33='" & Format(dtpInicioMartes33.Value, "HH:mm:ss") & "',HFinM33='" & Format(dtpFinMartes33.Value, "HH:mm:ss") & "',HInicioMi3='" & Format(dtpInicioMiercoles3.Value, "HH:mm:ss") & "',HFinMi3='" & Format(dtpFinMiercoles3.Value, "HH:mm:ss") & "',HInicioMi33='" & Format(dtpInicioMiercoles33.Value, "HH:mm:ss") & "',HFinMi33='" & Format(dtpFinMiercoles33.Value, "HH:mm:ss") & "',HInicioJ3='" & Format(dtpInicioJueves3.Value, "HH:mm:ss") & "',HFinJ3='" & Format(dtpFinJueves3.Value, "HH:mm:ss") & "',HInicioJ33='" & Format(dtpInicioJueves33.Value, "HH:mm:ss") & "',HFinJ33='" & Format(dtpFinJueves33.Value, "HH:mm:ss") & "',HIniciov3='" & Format(dtpInicioViernes3.Value, "HH:mm:ss") & "',HFinV3='" & Format(dtpFinViernes3.Value, "HH:mm:ss") & "',HInicioV33='" & Format(dtpInicioViernes33.Value, "HH:mm:ss") & "',HFinV33='" & Format(dtpFinViernes33.Value, "HH:mm:ss") & "',HInicioS3='" & Format(dtpInicioSabdo3.Value, "HH:mm:ss") & "',HFinS3='" & Format(dtpFinSabado3.Value, "HH:mm:ss") & "',HInicioS33='" & Format(dtpInicioSabado33.Value, "HH:mm:ss") & "',HFinS33='" & Format(dtpFinSabado33.Value, "HH:mm:ss") & "',HInicioD3='" & Format(dtpInicioDomingo3.Value, "HH:mm:ss") & "',HFinD3='" & Format(dtpFinDomingo3.Value, "HH:mm:ss") & "',HInicioD33='" & Format(dtpInicioDomingo33.Value, "HH:mm:ss") & "',HFinD33='" & Format(dtpFinDomingo33.Value, "HH:mm:ss") & "' WHERE Codigo='" & cboCodigo.Text & "'"


                    If cmd2.ExecuteNonQuery() Then
                        MsgBox("Promoción actualizada correctamente", vbInformation + vbOKOnly, titulorestaurante)
                        cnn2.Close()
                    End If


                End If
            Else

                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "INSERT INTO promos(Codigo,Promo2x1,Lunes,Martes,Miercoles,Jueves,Viernes,Sabado,Domingo,HInicioL,HFinL,HInicioL2,HFinL2,HInicioM,HFinM,HInicioM2,HFinM2,HInicioMi,HFinMi,HInicioMi2,HFinMi2,HInicioJ,HFinJ,HInicioJ2,HFinJ2,HInicioV,HFinV,HInicioV2,HFinV2,HInicioS,HFinS,HInicioS2,HFinS2,HInicioD,HFinD,HInicioD2,HFinD2,Promo3x2,Lunes2,Martes2,Miercoles2,Jueves2,Viernes2,Sabado2,Domingo2,HInicioL3,HFinL3,HInicioL33,HFinL33,HInicioM3,HFinM3,HInicioM33,HFinM33,HInicioMi3,HFinMi3,HInicioMi33,HFinMi33,HInicioJ3,HFinJ3,HInicioJ33,HFinJ33,HInicioV3,HFinV3,HInicioV33,HFinV33,HInicioS3,HFinS3,HInicioS33,HFinS33,HInicioD3,HFinD3,HInicioD33,HFinD33) VALUES('" & cboCodigo.Text & "'," & IIf(cbPromocion2x1.Checked, 1, 0) & "," & IIf(ckhLunes.Checked, 1, 0) & "," & IIf(chkMartes.Checked, 1, 0) & "," & IIf(chkMiercoles.Checked, 1, 0) & "," & IIf(chkJueves.Checked, 1, 0) & "," & IIf(chkViernes.Checked, 1, 0) & "," & IIf(chkSabado.Checked, 1, 0) & "," & IIf(chkDomingo.Checked, 1, 0) & ",'" & Format(dtpInicioLunes.Value, "HH:mm:ss") & "','" & Format(dtpFinLunes.Value, "HH:mm:ss") & "','" & Format(dtpInicioLunes2.Value, "HH:mm:ss") & "','" & Format(dtpFinLunes2.Value, "HH:mm:ss") & "','" & Format(dtpInicioMartes.Value, "HH:mm:ss") & "','" & Format(dtpFinMartes.Value, "HH:mm:ss") & "','" & Format(dtpInicioMartes2.Value, "HH:mm:ss") & "','" & Format(dtpFinMartes2.Value, "HH:mm:ss") & "','" & Format(dtpInicioMiercoles.Value, "HH:mm:ss") & "','" & Format(dtpFinMiercoles.Value, "HH:mm:ss") & "','" & Format(dtpInicioMiercoles2.Value, "HH:mm:ss") & "','" & Format(dtpFinMiercoles2.Value, "HH:mm:ss") & "','" & Format(dtpInicioJueves.Value, "HH:mm:ss") & "','" & Format(dtpFinJueves.Value, "HH:mm:ss") & "','" & Format(dtpInicioJueves2.Value, "HH:mm:ss") & "','" & Format(dtpFinJueves2.Value, "HH:mm:ss") & "','" & Format(dtpInicioViernes.Value, "HH:mm:ss") & "','" & Format(dtpFinViernes.Value, "HH:mm:ss") & "','" & Format(dtpInicioViernes2.Value, "HH:mm:ss") & "','" & Format(dtpFinViernes2.Value, "HH:mm:ss") & "','" & Format(dtpInicioSabado.Value, "HH:mm:ss") & "','" & Format(dtpFinSabado.Value, "HH:mm:ss") & "','" & Format(dtpInicioSabado2.Value, "HH:mm:ss") & "','" & Format(dtpFinSabado2.Value, "HH:mm:ss") & "','" & Format(dtpInicioDomingo.Value, "HH:mm:ss") & "','" & Format(dtpFinDomingo.Value, "HH:mm:ss") & "','" & Format(dtpInicioDomingo2.Value, "HH:mm:ss") & "','" & Format(dtpFinDomingo2.Value, "HH:mm:ss") & "'," & IIf(cbPromocion3.Checked, 1, 0) & "," & IIf(chkLunes3.Checked, 1, 0) & "," & IIf(chkMartes3.Checked, 1, 0) & "," & IIf(chkMiercoles3.Checked, 1, 0) & "," & IIf(chkJueves3.Checked, 1, 0) & "," & IIf(chkViernes3.Checked, 1, 0) & "," & IIf(chkSabado3.Checked, 1, 0) & "," & IIf(chkDomingo3.Checked, 1, 0) & ",'" & Format(dtpInicioLunes3.Value, "HH:mm:ss") & "','" & Format(dtpFinLunes3.Value, "HH:mm:ss") & "','" & Format(dtpInicioLunes33.Value, "HH:mm:ss") & "','" & Format(dtpFinLunes33.Value, "HH:mm:ss") & "','" & Format(dtpInicioMartes3.Value, "HH:mm:ss") & "','" & Format(dtpFinMartes3.Value, "HH:mm:ss") & "','" & Format(dtpInicioMartes33.Value, "HH:mm:ss") & "','" & Format(dtpFinMartes33.Value, "HH:mm:ss") & "','" & Format(dtpInicioMiercoles3.Value, "HH:mm:ss") & "','" & Format(dtpFinMiercoles3.Value, "HH:mm:ss") & "','" & Format(dtpInicioMiercoles33.Value, "HH:mm:ss") & "','" & Format(dtpFinMiercoles33.Value, "HH:mm:ss") & "','" & Format(dtpInicioJueves3.Value, "HH:mm:ss") & "','" & Format(dtpFinJueves3.Value, "HH:mm:ss") & "','" & Format(dtpInicioJueves33.Value, "HH:mm:ss") & "','" & Format(dtpFinJueves33.Value, "HH:mm:ss") & "','" & Format(dtpInicioViernes3.Value, "HH:mm:ss") & "','" & Format(dtpFinViernes3.Value, "HH:mm:ss") & "','" & Format(dtpInicioViernes33.Value, "HH:mm:ss") & "','" & Format(dtpFinViernes33.Value, "HH:mm:ss") & "','" & Format(dtpInicioSabdo3.Value, "HH:mm:ss") & "','" & Format(dtpFinSabado3.Value, "HH:mm:ss") & "','" & Format(dtpInicioSabado33.Value, "HH:mm:ss") & "','" & Format(dtpFinSabado33.Value, "HH:mm:ss") & "','" & Format(dtpInicioDomingo3.Value, "HH:mm:ss") & "','" & Format(dtpFinDomingo3.Value, "HH:mm:ss") & "','" & Format(dtpInicioDomingo33.Value, "HH:mm:ss") & "','" & Format(dtpFinDomingo33.Value, "HH:mm:ss") & "')"

                If cmd2.ExecuteNonQuery() Then
                    MsgBox("Promoción asignada correctamente", vbInformation + vbOKOnly, titulorestaurante)
                    cnn2.Close()
                End If

            End If
            rd1.Close()
            cnn1.Close()

            btnNuevo.PerformClick()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn3.Close()
        End Try
    End Sub
End Class
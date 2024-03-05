Public Class frmPromociones
    Private Sub frmPromociones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CargarDatos()

    End Sub

    Public Sub CargarDatos()
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
        Me.Close()
    End Sub

    Public Sub Abrir2x1()

        If (cbPromocion2x1.Checked) Then

        End If

    End Sub

    Private Sub cbPromocion2x1_CheckedChanged(sender As Object, e As EventArgs) Handles cbPromocion2x1.CheckedChanged
        Abrir2x1()
    End Sub
End Class
Public Class frmPromociones
    Private Sub frmPromociones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CargarDatos()

    End Sub

    Public Sub CargarDatos()

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

    End Sub
End Class
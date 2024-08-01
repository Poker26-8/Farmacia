Public Class frmHClinica
    Public namexd As String = ""
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblFecha.Text = FormatDateTime(Date.Now, DateFormat.ShortDate)
        lblHora.Text = FormatDateTime(Date.Now, DateFormat.LongTime)
    End Sub
    Public Sub MostrarTodo()
        Try

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        Finally
            cnn1.Close()
        End Try
    End Sub

    Private Sub frmHClinica_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        MostrarTodo()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        txtNotacion.Text = "18"
        txtdiente.Text = "Tercer Molar"
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        txtNotacion.Text = "17"
        txtdiente.Text = "Segundo Molar"
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        txtNotacion.Text = "16"
        txtdiente.Text = "Primer Molar"
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        txtNotacion.Text = "15"
        txtdiente.Text = "Segundo Premolar"
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        txtNotacion.Text = "14"
        txtdiente.Text = "Primer Premolar"
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        txtNotacion.Text = "13"
        txtdiente.Text = "Colmillo"
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        txtNotacion.Text = "12"
        txtdiente.Text = "Incisivo Lateral"
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        txtNotacion.Text = "11"
        txtdiente.Text = "Incisivo Central"
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        txtNotacion.Text = "21"
        txtdiente.Text = "incisivo Central"
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        txtNotacion.Text = "22"
        txtdiente.Text = "Incisivo Lateral"
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        txtNotacion.Text = "23"
        txtdiente.Text = "Colmillo"
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        txtNotacion.Text = "24"
        txtdiente.Text = "Primer Premolar"
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        txtNotacion.Text = "25"
        txtdiente.Text = "Segundo Premolar"
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        txtNotacion.Text = "26"
        txtdiente.Text = "Primer Molar"
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        txtNotacion.Text = "27"
        txtdiente.Text = "Segundo Molar"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        txtNotacion.Text = "28"
        txtdiente.Text = "Tercer Molar"
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        frmProcedimientos.Show()
        frmProcedimientos.BringToFront()
    End Sub

    Private Sub Button32_Click(sender As Object, e As EventArgs) Handles Button32.Click
        txtNotacion.Text = "48"
        txtdiente.Text = "Tercer Molar"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        txtNotacion.Text = "47"
        txtdiente.Text = "Segundo Molar"
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        txtNotacion.Text = "46"
        txtdiente.Text = "Primer Molar"
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        txtNotacion.Text = "45"
        txtdiente.Text = "Segundo Premolar"
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        txtNotacion.Text = "44"
        txtdiente.Text = "Primer Premolar"
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        txtNotacion.Text = "43"
        txtdiente.Text = "Colmillo"
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        txtNotacion.Text = "42"
        txtdiente.Text = "Incisivo Lateral"
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        txtNotacion.Text = "41"
        txtdiente.Text = "Incisivo Central"
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        txtNotacion.Text = "31"
        txtdiente.Text = "Incisivo Central"
    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        txtNotacion.Text = "32"
        txtdiente.Text = "Incisivo Lateral"
    End Sub

    Private Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click
        txtNotacion.Text = "33"
        txtdiente.Text = "Colmillo"
    End Sub

    Private Sub Button27_Click(sender As Object, e As EventArgs) Handles Button27.Click
        txtNotacion.Text = "34"
        txtdiente.Text = "Primer Premolar"
    End Sub

    Private Sub Button28_Click(sender As Object, e As EventArgs) Handles Button28.Click
        txtNotacion.Text = "35"
        txtdiente.Text = "Segundo Premolar"
    End Sub

    Private Sub Button29_Click(sender As Object, e As EventArgs) Handles Button29.Click
        txtNotacion.Text = "36"
        txtdiente.Text = "Primer Molar"
    End Sub

    Private Sub Button30_Click(sender As Object, e As EventArgs) Handles Button30.Click
        txtNotacion.Text = "37"
        txtdiente.Text = "Segundo Molar"
    End Sub

    Private Sub Button31_Click(sender As Object, e As EventArgs) Handles Button31.Click
        txtNotacion.Text = "38"
        txtdiente.Text = "Tercer Molar"
    End Sub


    Private Sub grd_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grd.CellDoubleClick
        Dim index As Integer = grd.CurrentRow.Index
        grd.Rows.Remove(grd.Rows(index))
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        'txtid.Text = ""
        'txtNombre.Text = ""
        'txtEdad.Text = ""
        'txtSexo.Text = ""
        txtNotacion.Text = ""
        txtdiente.Text = ""
        rtSintomas.Text = ""
        rtHistorial.Text = ""
        rtHistorialMedico.Text = ""
        grd.Rows.Clear()
        txtEnfermedad.Text = ""
        rtdiagnostico.Text = ""
        grdDiagnostico.Rows.Clear()
        cbHigiene.Checked = False
        cbMalos.Checked = False
        cbPlaca.Checked = False
        cbRevision.Checked = False
        cbDeteccion.Checked = False
        cbEncias.Checked = False
        cbAccidente.Checked = False
        cbDesarrollo.Checked = False
        cbEstetica.Checked = False
        cbProxima.Checked = False
        dtpFechaProxima.Value = Date.Now
    End Sub
End Class
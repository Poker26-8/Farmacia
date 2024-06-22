Public Class frmTecladoNum

    Public cantidad As Double = 0
    Public descuento As Double = 0
    Public comensal As Double = 0
    Private Sub frmTecladoNum_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If cantidad = 1 Then
            lblTitulo.Text = "CANTIDAD"
        End If

        If descuento = 1 Then
            lblTitulo.Text = "DESCUENTO"
        End If

        If comensal = 1 Then
            lblTitulo.Text = "COMENSAL"
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If cantidad = 1 Then
            frmNuevoAgregarProductos.lblCantidad.Text = FormatNumber(txtpersonas.Text, 2)
        End If

        If descuento = 1 Then
            frmNuevoAgregarProductos.lblDescuento.Text = txtpersonas.Text
        End If

        If comensal = 1 Then
            frmNuevoAgregarProductos.lblComensal.Text = txtpersonas.Text
        End If
        Me.Close()
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        txtpersonas.Text = CutCad(txtpersonas.Text)
    End Sub

    Public Function CutCad(VAL As String) As String
        If Len(VAL) > 0 Then
            CutCad = Strings.Left(VAL, Len(VAL) - 1)
        Else
            CutCad = ""
        End If
    End Function

    Private Sub btn0_Click(sender As Object, e As EventArgs) Handles btn0.Click
        txtpersonas.Text = txtpersonas.Text + btn0.Text
    End Sub

    Private Sub btnpunto_Click(sender As Object, e As EventArgs) Handles btnpunto.Click
        txtpersonas.Text = txtpersonas.Text + btnpunto.Text
    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        txtpersonas.Text = txtpersonas.Text + btn1.Text
    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        txtpersonas.Text = txtpersonas.Text + btn2.Text
    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        txtpersonas.Text = txtpersonas.Text + btn3.Text
    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        txtpersonas.Text = txtpersonas.Text + btn4.Text
    End Sub

    Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        txtpersonas.Text = txtpersonas.Text + btn5.Text
    End Sub

    Private Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
        txtpersonas.Text = txtpersonas.Text + btn6.Text
    End Sub

    Private Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
        txtpersonas.Text = txtpersonas.Text + btn7.Text
    End Sub

    Private Sub btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
        txtpersonas.Text = txtpersonas.Text + btn8.Text
    End Sub

    Private Sub btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
        txtpersonas.Text = txtpersonas.Text + btn9.Text
    End Sub
End Class
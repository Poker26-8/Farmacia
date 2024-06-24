Imports AForge.Imaging.Filters

Public Class frmEtiquetas2
    Private Sub btnImprime_Click(sender As Object, e As EventArgs) Handles btnImprime.Click
        If cbonombre.Text = "" Then
            MsgBox("Selecciona un producto para continuar")
            cbonombre.Focused.Equals(True)
            Exit Sub
        End If
        'If txtbarras.Text = "" Then
        '    MsgBox("Ingresa el codigo de barras para continuar")
        '    txtbarras.Focus.Equals(True)
        '    Exit Sub
        'End If
        'If txtgrupo.Text = "" Then
        '    MsgBox("Ingresa la cantidad para continuar")
        '    txtgrupo.Focus.Equals(True)
        '    Exit Sub
        'End If
        If cboimpresora.Text = "" Then
            MsgBox("Selecciona una impresoara para continuar")
            cboimpresora.Focused.Equals(True)
            Exit Sub
        End If
        Dim codigo2 As String = ""
        Dim contador As Integer = 1
        Dim numeroxd As Integer = 0
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select Codigo from productos order by Codigo desc"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    codigo2 = rd1("Codigo").ToString
                    numeroxd = Integer.Parse(codigo2)

                    numeroxd += 1

                    codigo2 = numeroxd.ToString("000000")
                End If
            Else
                GoTo kakita
            End If
            rd1.Close()
            cnn1.Close()

            While contador <= txtcopias.Text
                codigo2 = numeroxd.ToString("000000")
                txtcodigo.Text = codigo2
                txtbarras.Text = codigo2
                contador += 1
                numeroxd += 1
                My.Application.DoEvents()

                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Insert into Productos(Codigo,CodBarra,Nombre,UCompra,UVenta,UMinima,Departamento,Grupo,Fecha,Fecha_Inicial,Fecha_Final) values('" & txtcodigo.Text & "','" & txtbarras.Text & "','" & cbonombre.Text & "','PZA','PZA','PZA','" & cbonombre.Text & "','" & cbonombre.Text & "','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "yyyy-MM-dd") & "')"
                If cmd1.ExecuteNonQuery Then

                Else
                    MsgBox("No se inserto el codigo " & codigo2)
                End If
                cnn1.Close()

                My.Application.DoEvents()
                GenerarPP()
                My.Application.DoEvents()
            End While

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

kakita:
        Try
            While contador <= txtcopias.Text
                Dim codigo As String = contador.ToString("000000")
                txtcodigo.Text = codigo
                txtbarras.Text = codigo
                contador += 1
                My.Application.DoEvents()

                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Insert into Productos(Codigo,CodBarra,Nombre,UCompra,UVenta,UMinima,Departamento,GrupoFecha,Fecha_Inicial,Fecha_Final) values('" & txtcodigo.Text & "','" & txtbarras.Text & "','" & cbonombre.Text & "','PZA','PZA','PZA','" & cbonombre.Text & "','" & cbonombre.Text & "','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "yyyy-MM-dd") & "')"
                If cmd1.ExecuteNonQuery Then

                Else
                    MsgBox("No se inserto el codigo " & codigo)
                End If
                cnn1.Close()
                My.Application.DoEvents()
                GenerarPP()
                My.Application.DoEvents()
            End While
        Catch ex As Exception
            cnn1.Close()
        End Try
        'GenerarPP()
        btnnuevo.PerformClick()
    End Sub
    Private Sub GenerarPP()

        GeneraBarras(PictureBox1, txtbarras.Text)
        GeneraBarras2(PictureBox3, txtcodigo.Text)

        'For xxx As Integer = 1 To txtcopias.Text
        PrintDocument1.PrinterSettings.PrinterName = cboimpresora.Text
        PrintDocument1.Print()
        'Next

        'Try
        '    cnn1.Close()
        '    cnn1.Open()
        '    cmd1 = cnn1.CreateCommand
        '    cmd1.CommandText = "Update Productos set CodBarra='" & txtbarras.Text & "',Existencia=" & txtgrupo.Text & ",Cargado=0,CargadoInv=0 where Codigo='" & txtcodigo.Text & "' And Nombre ='" & cbonombre.Text & "'"
        '    If cmd1.ExecuteNonQuery Then
        '        MsgBox("Datos del producto agregado correctamente", vbInformation + vbOKOnly, "Delsscom COntrol Negocios Pro")
        '    End If
        '    cnn1.Close()
        'Catch ex As Exception
        '    MessageBox.Show(ex.ToString)
        '    cnn1.Close()
        'End Try

        Exit Sub
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim fuentita As New Drawing.Font("Lucida Sans Typewriter", 12, FontStyle.Bold)
        Dim Y As Double = 0
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim bm As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Dim bm2 As New Bitmap(PictureBox3.Width, PictureBox3.Height)
        Dim bme As New Bitmap(piclogo.Width, piclogo.Height)

        piclogo.DrawToBitmap(bme, New Rectangle(0, 0, bm.Width, bm.Height))
        PictureBox1.DrawToBitmap(bm, New Rectangle(0, 0, bm.Width, bm.Height))
        PictureBox3.DrawToBitmap(bm2, New Rectangle(0, 0, bm2.Width, bm2.Height))
        'x,Y,ANCHO,ALTO




        Y += 1

            Dim caracteresPorLinea As Integer = 30
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
            e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 95, Y)
            Y += 8
                inicio += caracteresPorLinea
            End While
        '    Y += 20
        'e.Graphics.DrawString("Cantidad: " & FormatNumber(txtgrupo.Text, 2), fuentita, Brushes.Black, 95, Y)
        Y += 35
        'e.Graphics.DrawString("$ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 65, Y, sc)
        e.Graphics.DrawImage(bm, 95, 60, 315, 55)
        e.Graphics.DrawImage(PictureBox2.Image, 100, 82, 305, 40) 'LA CAJA DE TEXTO
        e.Graphics.DrawString(txtbarras.Text, fuentita, Brushes.Black, 175, 90, sc) 'CODIGO DE BARRAS




        'e.Graphics.DrawImage(bm2, 95, 180, 320, 55)
        'e.Graphics.DrawImage(PictureBox4.Image, 100, 202, 310, 80) 'LA CAJA DE TEXTO
        'e.Graphics.DrawString(txtcodigo.Text, fuentita, Brushes.Black, 140, 210, sc)

        'e.Graphics.DrawImage(bm, 5, 120, 300, 35)
        'e.Graphics.DrawImage(PictureBox2.Image, 10, 142, 290, 15) 'LA CAJA DE TEXTO
        e.HasMorePages = False

    End Sub

    Private Sub cbonombre_DropDown(sender As Object, e As EventArgs) Handles cbonombre.DropDown
        cbonombre.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct Nombre from Productos where Nombre<>'' order by Nombre asc"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cbonombre.Items.Add(
                    rd1(0).ToString
                    )
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbonombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbonombre.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                'cnn1.Close() : cnn1.Open()

                'cmd1 = cnn1.CreateCommand
                'cmd1.CommandText =
                '    "select * from Productos where Nombre='" & cbonombre.Text & "'"
                'rd1 = cmd1.ExecuteReader
                'If rd1.HasRows Then
                '    If rd1.Read Then
                '        txtcodigo.Text = rd1("Codigo").ToString
                '        txtbarras.Text = rd1("CodBarra").ToString
                '        txtgrupo.Text = rd1("Existencia").ToString
                '        txtprecio.Text = FormatNumber(IIf(rd1("PrecioVentaIVA").ToString = "", 0, rd1("PrecioVentaIVA").ToString), 2)
                '        txtcopias.SelectAll()
                '        txtbarras.Focus().Equals(True)
                '    End If
                'End If
                'rd1.Close() : cnn1.Close()
                txtcopias.Focus.Equals(True)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub cbonombre_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbonombre.SelectedValueChanged
        Try
            'cnn1.Close() : cnn1.Open()

            'cmd1 = cnn1.CreateCommand
            'cmd1.CommandText =
            '    "select * from Productos where Nombre='" & cbonombre.Text & "'"
            'rd1 = cmd1.ExecuteReader
            'If rd1.HasRows Then
            '    If rd1.Read Then
            '        txtcodigo.Text = rd1("Codigo").ToString
            '        txtbarras.Text = rd1("CodBarra").ToString
            '        txtgrupo.Text = rd1("Existencia").ToString
            '        txtprecio.Text = FormatNumber(IIf(rd1("PrecioVentaIVA").ToString = "", 0, rd1("PrecioVentaIVA").ToString), 2)
            '        ' txtcopias.SelectAll()
            '        txtbarras.Focus().Equals(True)
            '    End If
            'End If
            'rd1.Close() : cnn1.Close()
            txtcopias.Focus.Equals(True)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            'cnn1.Close()
        End Try
    End Sub

    Private Sub txtbarras_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtbarras.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtgrupo.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboimpresora_DropDown(sender As Object, e As EventArgs) Handles cboimpresora.DropDown
        cboimpresora.Items.Clear()
        For Each printer As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            cboimpresora.Items.Add(printer)
        Next
    End Sub

    Private Sub btnnuevo_Click(sender As Object, e As EventArgs) Handles btnnuevo.Click
        txtcodigo.Text = ""
        cbonombre.Text = ""
        txtbarras.Text = ""
        txtgrupo.Text = ""
        cboimpresora.Text = ""
        txtcopias.Text = "1"
    End Sub

    Private Sub frmEtiquetas2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtcodigo_TextChanged(sender As Object, e As EventArgs) Handles txtcodigo.TextChanged

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub txtbarras_TextChanged(sender As Object, e As EventArgs) Handles txtbarras.TextChanged

    End Sub
End Class
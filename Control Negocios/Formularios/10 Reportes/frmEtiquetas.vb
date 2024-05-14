
Imports System.IO
Imports Core.BL

Public Class frmEtiquetas

    Dim Medida As String = ""
    Dim logo As String = ""
    Dim orientacionlogo As String = ""

    Private Sub frmEtiquetas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select NotasCred from Formatos where Facturas='Medida_Eti'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Medida = rd1(0).ToString
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NotasCred FROM formatos WHERE Facturas='LogoE'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    logo = rd1(0).ToString
                    If File.Exists(My.Application.Info.DirectoryPath & "\" & logo) Then
                        piclogo.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & logo)
                    End If

                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NotasCred FROM formatos WHERE Facturas='OriLogoE'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    orientacionlogo = rd1(0).ToString
                End If
            End If
            rd1.Close()

            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbonombre_DropDown(sender As System.Object, e As System.EventArgs) Handles cbonombre.DropDown
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

    Private Sub cbonombre_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbonombre.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Productos where Nombre='" & cbonombre.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        txtcodigo.Text = rd1("Codigo").ToString
                        txtbarras.Text = rd1("CodBarra").ToString
                        txtgrupo.Text = rd1("Grupo").ToString
                        txtprecio.Text = FormatNumber(IIf(rd1("PrecioVentaIVA").ToString = "", 0, rd1("PrecioVentaIVA").ToString), 2)
                        txtcopias.SelectAll()
                        txtcopias.Focus().Equals(True)
                    End If
                End If
                rd1.Close() : cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub cbonombre_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cbonombre.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Productos where Nombre='" & cbonombre.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtcodigo.Text = rd1("Codigo").ToString
                    txtbarras.Text = rd1("CodBarra").ToString
                    txtgrupo.Text = rd1("Grupo").ToString
                    txtprecio.Text = FormatNumber(IIf(rd1("PrecioVentaIVA").ToString = "", 0, rd1("PrecioVentaIVA").ToString), 2)
                    txtcopias.SelectAll()
                    txtcopias.Focus().Equals(True)
                End If
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboimpresora_DropDown(sender As System.Object, e As System.EventArgs) Handles cboimpresora.DropDown
        cboimpresora.Items.Clear()
        For Each printer As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            cboimpresora.Items.Add(printer)
        Next
    End Sub

    Private Sub txtbarras_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtbarras.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Productos where CodBarra='" & txtbarras.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        cbonombre.Text = rd1("Nombre").ToString
                        txtcodigo.Text = rd1("Codigo").ToString
                        txtgrupo.Text = rd1("Grupo").ToString
                        txtprecio.Text = FormatNumber(rd1("PrecioVentaIVA").ToString, 2)
                        txtcopias.SelectAll()
                        txtcopias.Focus().Equals(True)
                    End If
                Else
                    MsgBox("No se encontró el producto en la base de datos.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    txtbarras.Text = ""
                    rd1.Close() : cnn1.Close()
                    Exit Sub
                End If
                rd1.Close() : cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub txtcopias_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcopias.KeyPress
        If Not IsNumeric(txtcopias.Text) Then txtcopias.Text = ""
        If AscW(e.KeyChar) = Keys.Enter Then
            cboimpresora.Focus().Equals(True)
        End If
    End Sub

    Private Sub cboimpresora_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboimpresora.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnImprime.Focus().Equals(True)
        End If
    End Sub

    Private Sub btnnuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnnuevo.Click
        cbonombre.Items.Clear()
        cbonombre.Text = ""
        txtcodigo.Text = ""
        txtbarras.Text = ""
        txtgrupo.Text = ""
        txtprecio.Text = ""
        cboimpresora.Text = ""
        txtcopias.Text = "1"
        optPP.Checked = False
        optPC.Checked = False
        optPCP.Checked = False
        cbonombre.Focus().Equals(True)
    End Sub

    Private Sub btnImprime_Click(sender As System.Object, e As System.EventArgs) Handles btnImprime.Click
        If cboimpresora.Text = "" Then MsgBox("Selecciona una impresora para las etiquetas.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboimpresora.Focus().Equals(True) : Exit Sub
        If txtbarras.Text = "" Then
            If optPP.Checked = True Then
            Else
                MsgBox("Selecciona un producto con código de barras para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                txtbarras.Focus().Equals(True) : Exit Sub
            End If
        End If
        If txtcopias.Text = "" Then MsgBox("Escribe el número de copias para imprimir.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtcopias.Focus().Equals(True) : Exit Sub

        If optPP.Checked = False And optPC.Checked = False And optPCP.Checked = False Then
            MsgBox("Selecciona una opción de impresión.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Exit Sub
        End If

        If (optPP.Checked) Then
            GenerarPP()
        End If
        If (optPC.Checked) Then
            GeneraPC()
        End If
        If (optPCP.Checked) Then
            GenerarPCP()
        End If
    End Sub

    Private Sub GenerarPP()
        GeneraBarras(PictureBox1, txtbarras.Text)
        If Medida = "2x4" Then
            For t As Integer = 1 To txtcopias.Text
                pPP2x4.PrinterSettings.PrinterName = cboimpresora.Text
                pPP2x4.Print()
            Next
            Exit Sub
        End If
        If Medida = "5x2.5" Then
            For t As Integer = 1 To txtcopias.Text
                pPP5x25.PrinterSettings.PrinterName = cboimpresora.Text
                pPP5x25.Print()
            Next
            Exit Sub
        End If
        If Medida = "6.5x2.7" Then
            For t As Integer = 1 To txtcopias.Text
                pPP65x27.PrinterSettings.PrinterName = cboimpresora.Text
                pPP65x27.Print()
            Next
            Exit Sub
        End If
        If Medida = "5x3" Then
            For t As Integer = 1 To txtcopias.Text
                pPP5x3.PrinterSettings.PrinterName = cboimpresora.Text
                pPP5x3.Print()
            Next
            Exit Sub
        End If
        For t As Integer = 1 To txtcopias.Text
            pPP.PrinterSettings.PrinterName = cboimpresora.Text
            pPP.Print()
        Next
        Exit Sub
    End Sub

    Private Sub GeneraPC()
        GeneraBarras(PictureBox1, txtbarras.Text)
        If Medida = "2x4" Then
            For t As Integer = 1 To txtcopias.Text
                pPC2x4.PrinterSettings.PrinterName = cboimpresora.Text
                pPC2x4.Print()
            Next
            Exit Sub
        End If
        If Medida = "5x2.5" Then
            For t As Integer = 1 To txtcopias.Text
                pPC5x25.PrinterSettings.PrinterName = cboimpresora.Text
                pPC5x25.Print()
            Next
            Exit Sub
        End If
        If Medida = "6.5x2.7" Then
            For t As Integer = 1 To txtcopias.Text
                pPC65x27.PrinterSettings.PrinterName = cboimpresora.Text
                pPC65x27.Print()
            Next
            Exit Sub
        End If
        If Medida = "5x3" Then
            For t As Integer = 1 To txtcopias.Text
                pPC5x3.PrinterSettings.PrinterName = cboimpresora.Text
                pPC5x3.Print()
            Next
            Exit Sub
        End If
        For t As Integer = 1 To txtcopias.Text
            pPC.PrinterSettings.PrinterName = cboimpresora.Text
            pPC.Print()
        Next
        Exit Sub
    End Sub

    Private Sub GenerarPCP()
        GeneraBarras(PictureBox1, txtbarras.Text)
        If Medida = "2x4" Then
            For t As Integer = 1 To txtcopias.Text
                pPCP2x4.PrinterSettings.PrinterName = cboimpresora.Text
                pPCP2x4.Print()
            Next
            Exit Sub
        End If
        If Medida = "5x2.5" Then
            For t As Integer = 1 To txtcopias.Text
                pPCP5x25.PrinterSettings.PrinterName = cboimpresora.Text
                pPCP5x25.Print()
            Next
            Exit Sub
        End If
        If Medida = "6.5x2.7" Then
            For t As Integer = 1 To txtcopias.Text
                pPCP65x27.PrinterSettings.PrinterName = cboimpresora.Text
                pPCP65x27.Print()
            Next
            Exit Sub
        End If
        If Medida = "5x3" Then
            For t As Integer = 1 To txtcopias.Text
                pPCP5x3.PrinterSettings.PrinterName = cboimpresora.Text
                pPCP5x3.Print()
            Next
            Exit Sub
        End If

        If Medida = "2.5x3.8" Then
            For t As Integer = 1 To txtcopias.Text
                pPCP25x38.PrinterSettings.PrinterName = cboimpresora.Text
                pPCP25x38.Print()
            Next
            Exit Sub
        End If

        For t As Integer = 1 To txtcopias.Text
            pPCP.PrinterSettings.PrinterName = cboimpresora.Text
            pPCP.Print()
        Next
        Exit Sub
    End Sub

    Private Sub pPP_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles pPP.PrintPage
        Dim fuentita As New Drawing.Font("Lucida Sans Typewriter", 7, FontStyle.Bold)
        Dim Y As Double = 0
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}

        Y += 35
        e.Graphics.DrawString(cbonombre.Text, fuentita, Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString(" $ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 105, Y, sc)
        e.HasMorePages = False
    End Sub

    Private Sub pPC_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles pPC.PrintPage
        Dim fuentita As New Drawing.Font("Lucida Sans Typewriter", 7, FontStyle.Bold)
        Dim Y As Double = 0
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim bm As New Bitmap(PictureBox1.Width, PictureBox1.Height)

        PictureBox1.DrawToBitmap(bm, New Rectangle(0, 0, bm.Width, bm.Height))
        Y = 0
        e.Graphics.DrawString(cbonombre.Text, fuentita, Brushes.Black, 1, Y)
        Y += 10
        e.Graphics.DrawImage(bm, 10, 20, 160, 50)
        e.Graphics.DrawImage(PictureBox2.Image, 25, 58, 130, 15)
        e.Graphics.DrawString(txtbarras.Text, fuentita, Brushes.Black, 105, 58, sc)
        e.HasMorePages = False
    End Sub

    Private Sub pPCP_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles pPCP.PrintPage
        Dim fuentita As New Drawing.Font("Lucida Sans Typewriter", 7, FontStyle.Bold)
        Dim Y As Double = 0
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim bm As New Bitmap(PictureBox1.Width, PictureBox1.Height)

        PictureBox1.DrawToBitmap(bm, New Rectangle(0, 0, bm.Width, bm.Height))
        Y = 0
        e.Graphics.DrawString(cbonombre.Text, fuentita, Brushes.Black, 1, Y)
        Y += 10
        e.Graphics.DrawString("$ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 105, Y, sc)
        Y += 10
        e.Graphics.DrawImage(bm, 10, 25, 160, 45)
        e.Graphics.DrawImage(PictureBox2.Image, 25, 58, 130, 15)
        e.Graphics.DrawString(txtbarras.Text, fuentita, Brushes.Black, 105, 59, sc)
        e.HasMorePages = False
    End Sub

    Private Sub pPP2x4_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles pPP2x4.PrintPage
        Dim fuentita As New Drawing.Font("Lucida Sans Typewriter", 6, FontStyle.Bold)
        Dim Y As Double = 0
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}

        Dim bm As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Dim bme As New Bitmap(piclogo.Width, piclogo.Height)

        piclogo.DrawToBitmap(bme, New Rectangle(0, 0, bm.Width, bm.Height))
        PictureBox1.DrawToBitmap(bm, New Rectangle(0, 0, bm.Width, bm.Height))

        If orientacionlogo = "ARRIBA" Then
            Y += 10
            e.Graphics.DrawImage(bme, 10, 5, 70, 20)
            Y = 25

            Dim caracteresPorLinea As Integer = 20
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 3, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While
            Y += 3
            e.Graphics.DrawString(" $ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 40, Y, sc)
            e.HasMorePages = False
        End If

        If orientacionlogo = "DERECHA" Then

            Y += 20
            Dim caracteresPorLinea As Integer = 20
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 5, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While
            Y += 5

            'GIRARA EL LOGO IZQUIERDA
            Dim imagenRotada As Image = New Bitmap(bme.Height, bme.Width)

            ' Crear un objeto Graphics basado en la imagen rotada
            Using g As Graphics = Graphics.FromImage(imagenRotada)
                ' Rotar la imagen original 90 grados en sentido antihorario
                g.TranslateTransform(bme.Height / 2, bme.Width / 2)
                g.RotateTransform(-90)
                g.TranslateTransform(-bme.Width / 2, -bme.Height / 2)
                g.DrawImage(bme, New System.Drawing.Point(0, 0))
            End Using

            ' Dibujar la imagen rotada en el gráfico con el tamaño ajustado
            e.Graphics.DrawImage(imagenRotada, 113, 13, 30, 50)

            e.Graphics.DrawString(" $ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 50, Y, sc)
            e.HasMorePages = False
        End If

        If orientacionlogo = "IZQUIERDA" Then
            Y += 20
            Dim caracteresPorLinea As Integer = 20
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 35, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While
            Y += 3
            'GIRARA EL LOGO IZQUIERDA
            Dim imagenRotada As Image = New Bitmap(bme.Height, bme.Width)

            ' Crear un objeto Graphics basado en la imagen rotada
            Using g As Graphics = Graphics.FromImage(imagenRotada)
                ' Rotar la imagen original 90 grados en sentido antihorario
                g.TranslateTransform(bme.Height / 2, bme.Width / 2)
                g.RotateTransform(-90)
                g.TranslateTransform(-bme.Width / 2, -bme.Height / 2)
                g.DrawImage(bme, New System.Drawing.Point(0, 0))
            End Using

            ' Dibujar la imagen rotada en el gráfico con el tamaño ajustado
            e.Graphics.DrawImage(imagenRotada, 3, 10, 30, 50)



            e.Graphics.DrawString(" $ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 65, Y, sc)
            e.HasMorePages = False
        End If

        If orientacionlogo = "S/ETI" Then
            Y += 10

            Dim caracteresPorLinea As Integer = 20
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 1, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While
            Y += 5
            e.Graphics.DrawString(" $ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 45, Y, sc)
            e.HasMorePages = False
        End If


    End Sub

    Private Sub pPC2x4_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles pPC2x4.PrintPage
        Dim fuentita As New Drawing.Font("Lucida Sans Typewriter", 6, FontStyle.Bold)
        Dim Y As Double = 0
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim bm As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Dim bme As New Bitmap(piclogo.Width, piclogo.Height)

        piclogo.DrawToBitmap(bme, New Rectangle(0, 0, bm.Width, bm.Height))
        PictureBox1.DrawToBitmap(bm, New Rectangle(0, 0, bm.Width, bm.Height))

        If orientacionlogo = "ARRIBA" Then

            Y += 10
            e.Graphics.DrawImage(bme, 10, 5, 70, 20)
            Y = 25

            Dim caracteresPorLinea As Integer = 18
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 3, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While

            e.Graphics.DrawImage(bm, 4, 47, 100, 35)
            e.Graphics.DrawImage(PictureBox2.Image, 10, 67, 88, 15)
            e.Graphics.DrawString(txtbarras.Text, fuentita, Brushes.Black, 50, 71, sc)
            e.HasMorePages = False
        End If

        If orientacionlogo = "IZQUIERDA" Then


            Y += 5
            Dim caracteresPorLinea As Integer = 15
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 45, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While

            'GIRARA EL LOGO DERECHA
            Dim imagenRotada As Image = New Bitmap(bme.Height, bme.Width)

            ' Crear un objeto Graphics basado en la imagen rotada
            Using g As Graphics = Graphics.FromImage(imagenRotada)
                ' Rotar la imagen original 90 grados en sentido antihorario
                g.TranslateTransform(bme.Height / 2, bme.Width / 2)
                g.RotateTransform(90)
                g.TranslateTransform(-bme.Width / 2, -bme.Height / 2)
                g.DrawImage(bme, New System.Drawing.Point(0, 0))
            End Using

            ' Dibujar la imagen rotada en el gráfico con el tamaño ajustado
            e.Graphics.DrawImage(imagenRotada, 5, 10, 30, 65)

            e.Graphics.DrawImage(bm, 40, 33, 88, 35)
            e.Graphics.DrawImage(PictureBox2.Image, 49, 56, 75, 15)
            e.Graphics.DrawString(txtbarras.Text, fuentita, Brushes.Black, 85, 60, sc)
            e.HasMorePages = False

        End If

        If orientacionlogo = "DERECHA" Then

            Y += 10
            Dim caracteresPorLinea As Integer = 15
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 5, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While

            'GIRARA EL LOGO DERECHA
            Dim imagenRotada As Image = New Bitmap(bme.Height, bme.Width)

            ' Crear un objeto Graphics basado en la imagen rotada
            Using g As Graphics = Graphics.FromImage(imagenRotada)
                ' Rotar la imagen original 90 grados en sentido antihorario
                g.TranslateTransform(bme.Height / 2, bme.Width / 2)
                g.RotateTransform(90)
                g.TranslateTransform(-bme.Width / 2, -bme.Height / 2)
                g.DrawImage(bme, New System.Drawing.Point(0, 0))
            End Using

            ' Dibujar la imagen rotada en el gráfico con el tamaño ajustado
            e.Graphics.DrawImage(imagenRotada, 86, 10, 30, 50)

            e.Graphics.DrawImage(bm, 5, 35, 80, 30)
            e.Graphics.DrawImage(PictureBox2.Image, 12, 51, 70, 15)
            e.Graphics.DrawString(txtbarras.Text, fuentita, Brushes.Black, 46, 53, sc)
            e.HasMorePages = False
        End If

        If orientacionlogo = "S/ETI" Then
            Y = 15

            Dim caracteresPorLinea As Integer = 20
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 10, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While

            e.Graphics.DrawImage(bm, 10, 35, 110, 35)
            e.Graphics.DrawImage(PictureBox2.Image, 17, 56, 95, 15)
            e.Graphics.DrawString(txtbarras.Text, fuentita, Brushes.Black, 63, 62, sc)
            e.HasMorePages = False
        End If

    End Sub

    Private Sub pPCP2x4_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles pPCP2x4.PrintPage
        Dim fuentita As New Drawing.Font("Lucida Sans Typewriter", 7, FontStyle.Bold)
        Dim fuentitac As New Drawing.Font("Lucida Sans Typewriter", 6, FontStyle.Bold)
        Dim Y As Double = 0
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim bm As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Dim bme As New Bitmap(piclogo.Width, piclogo.Height)

        piclogo.DrawToBitmap(bme, New Rectangle(0, 0, bme.Width, bme.Height))
        PictureBox1.DrawToBitmap(bm, New Rectangle(0, 0, bm.Width, bm.Height))

        If orientacionlogo = "ARRIBA" Then

            e.Graphics.DrawImage(bme, 10, 5, 88, 20)
            Y = 25

            Dim caracteresPorLinea As Integer = 15
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 5, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While
            Y += 5
            e.Graphics.DrawString("$ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 50, Y, sc)
            Y += 2
            e.Graphics.DrawImage(bm, 5, 70, 90, 35)
            e.Graphics.DrawImage(PictureBox2.Image, 10, 93, 80, 15)
            e.Graphics.DrawString(txtbarras.Text, fuentita, Brushes.Black, 52, 93, sc)
            e.HasMorePages = False

        End If

        If orientacionlogo = "IZQUIERDA" Then
            Y += 5
            'GIRARA EL LOGO IZQUIERDA
            Dim imagenRotada As Image = New Bitmap(bme.Height, bme.Width)

            ' Crear un objeto Graphics basado en la imagen rotada
            Using g As Graphics = Graphics.FromImage(imagenRotada)
                ' Rotar la imagen original 90 grados en sentido antihorario
                g.TranslateTransform(bme.Height / 2, bme.Width / 2)
                g.RotateTransform(-90)
                g.TranslateTransform(-bme.Width / 2, -bme.Height / 2)
                g.DrawImage(bme, New System.Drawing.Point(0, 0))
            End Using

            ' Dibujar la imagen rotada en el gráfico con el tamaño ajustado
            e.Graphics.DrawImage(imagenRotada, 3, 7, 20, 50)

            Dim caracteresPorLinea As Integer = 15
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 25, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While

            e.Graphics.DrawString("$ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 65, Y, sc)
            Y += 13
            e.Graphics.DrawImage(bm, 25, 40, 90, 25)
            e.Graphics.DrawImage(PictureBox2.Image, 30, 55, 80, 15) 'LA CAJA DE TEXTO
            e.Graphics.DrawString(txtbarras.Text, fuentitac, Brushes.Black, 70, 57, sc) 'CODIGO DE BARRAS
            e.HasMorePages = False
        End If

        If orientacionlogo = "DERECHA" Then

            Y += 5
            'GIRARA EL LOGO IZQUIERDA
            Dim imagenRotada As Image = New Bitmap(bme.Height, bme.Width)

            ' Crear un objeto Graphics basado en la imagen rotada
            Using g As Graphics = Graphics.FromImage(imagenRotada)
                ' Rotar la imagen original 90 grados en sentido antihorario
                g.TranslateTransform(bme.Height / 2, bme.Width / 2)
                g.RotateTransform(-90)
                g.TranslateTransform(-bme.Width / 2, -bme.Height / 2)
                g.DrawImage(bme, New System.Drawing.Point(0, 0))
            End Using

            ' Dibujar la imagen rotada en el gráfico con el tamaño ajustado
            e.Graphics.DrawImage(imagenRotada, 95, 10, 30, 70)

            Dim caracteresPorLinea As Integer = 15
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length
            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 1, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While
            Y += 4
            e.Graphics.DrawString("$ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 55, Y, sc)

            e.Graphics.DrawImage(bm, 5, 55, 90, 35)
            e.Graphics.DrawImage(PictureBox2.Image, 12, 76, 75, 15)
            e.Graphics.DrawString(txtbarras.Text, fuentita, Brushes.Black, 50, 80, sc)
            e.HasMorePages = False
        End If

        If orientacionlogo = "S/ETI" Then
            Y += 10
            Dim caracteresPorLinea As Integer = 15
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 2, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While
            Y += 3
            e.Graphics.DrawString("$ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 53, Y, sc)


            e.Graphics.DrawImage(bm, 5, 50, 90, 35)
            e.Graphics.DrawImage(PictureBox2.Image, 10, 71, 80, 15) 'LA CAJA DE TEXTO
            e.Graphics.DrawString(txtbarras.Text, fuentita, Brushes.Black, 51, 71, sc) 'CODIGO DE BARRAS
            e.HasMorePages = False
        End If


    End Sub

    Private Sub pPP5x25_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pPP5x25.PrintPage

        Dim fuentita As New Drawing.Font("Lucida Sans Typewriter", 5, FontStyle.Bold)
        Dim Y As Double = 0
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim bm As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Dim bme As New Bitmap(piclogo.Width, piclogo.Height)

        piclogo.DrawToBitmap(bme, New Rectangle(0, 0, bm.Width, bm.Height))
        PictureBox1.DrawToBitmap(bm, New Rectangle(0, 0, bm.Width, bm.Height))
        'x,Y,ANCHO,ALTO

        If orientacionlogo = "ARRIBA" Then

            e.Graphics.DrawImage(bme, 10, 5, 123, 30)
            Y = 35

            Dim caracteresPorLinea As Integer = 30
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 5, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While
            Y += 5
            e.Graphics.DrawString("$ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 65, Y, sc)

            e.HasMorePages = False

        End If

        If orientacionlogo = "IZQUIERDA" Then

            Y += 35
            'GIRARA EL LOGO IZQUIERDA
            Dim imagenRotada As Image = New Bitmap(bme.Height, bme.Width)

            ' Crear un objeto Graphics basado en la imagen rotada
            Using g As Graphics = Graphics.FromImage(imagenRotada)
                ' Rotar la imagen original 90 grados en sentido antihorario
                g.TranslateTransform(bme.Height / 2, bme.Width / 2)
                g.RotateTransform(-90)
                g.TranslateTransform(-bme.Width / 2, -bme.Height / 2)
                g.DrawImage(bme, New System.Drawing.Point(0, 0))
            End Using

            ' Dibujar la imagen rotada en el gráfico con el tamaño ajustado
            e.Graphics.DrawImage(imagenRotada, 3, 13, 40, 70)

            Dim caracteresPorLinea As Integer = 30
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 45, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While
            Y += 2
            e.Graphics.DrawString("$ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 105, Y, sc)


            e.HasMorePages = False

        End If

        If orientacionlogo = "DERECHA" Then
            Y += 25
            Dim caracteresPorLinea As Integer = 28
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 5, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While
            Y += 5
            e.Graphics.DrawString("$ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 65, Y, sc)
            Y += 10

            Dim imagenRotada As Image = New Bitmap(bme.Height, bme.Width)

            ' Crear un objeto Graphics basado en la imagen rotada
            Using g As Graphics = Graphics.FromImage(imagenRotada)
                ' Rotar la imagen original 90 grados en sentido antihorario
                g.TranslateTransform(bme.Height / 2, bme.Width / 2)
                g.RotateTransform(-90)
                g.TranslateTransform(-bme.Width / 2, -bme.Height / 2)
                g.DrawImage(bme, New System.Drawing.Point(0, 0))
            End Using

            ' Dibujar la imagen rotada en el gráfico con el tamaño ajustado
            e.Graphics.DrawImage(imagenRotada, 130, 10, 30, 60)

            e.HasMorePages = False

        End If

        If orientacionlogo = "S/ETI" Then
            Y += 10

            Dim caracteresPorLinea As Integer = 30
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 5, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While
            Y += 2
            e.Graphics.DrawString("$ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 60, Y, sc)
            e.HasMorePages = False
        End If

    End Sub

    Private Sub pPC5x25_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pPC5x25.PrintPage

        Dim fuentita As New Drawing.Font("Lucida Sans Typewriter", 5, FontStyle.Bold)
        Dim Y As Double = 0
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim bm As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Dim bme As New Bitmap(piclogo.Width, piclogo.Height)

        piclogo.DrawToBitmap(bme, New Rectangle(0, 0, bm.Width, bm.Height))
        PictureBox1.DrawToBitmap(bm, New Rectangle(0, 0, bm.Width, bm.Height))
        'x,Y,ANCHO,ALTO

        If orientacionlogo = "ARRIBA" Then
            e.Graphics.DrawImage(bme, 10, 5, 110, 25)
            Y = 35

            Dim caracteresPorLinea As Integer = 30
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 5, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While
            Y += 3
            e.Graphics.DrawImage(bm, 5, 52, 130, 35)
            e.Graphics.DrawImage(PictureBox2.Image, 11, 75, 120, 15) 'LA CAJA DE TEXTO
            e.Graphics.DrawString(txtbarras.Text, fuentita, Brushes.Black, 68, 78, sc) 'CODIGO DE BARRAS
            e.HasMorePages = False
        End If

        If orientacionlogo = "IZQUIERDA" Then

            Y += 10

            Dim caracteresPorLinea As Integer = 30
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 44, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While
            Y += 3

            'GIRARA EL LOGO IZQUIERDA
            Dim imagenRotada As Image = New Bitmap(bme.Height, bme.Width)

            ' Crear un objeto Graphics basado en la imagen rotada
            Using g As Graphics = Graphics.FromImage(imagenRotada)
                ' Rotar la imagen original 90 grados en sentido antihorario
                g.TranslateTransform(bme.Height / 2, bme.Width / 2)
                g.RotateTransform(-90)
                g.TranslateTransform(-bme.Width / 2, -bme.Height / 2)
                g.DrawImage(bme, New System.Drawing.Point(0, 0))
            End Using

            ' Dibujar la imagen rotada en el gráfico con el tamaño ajustado
            e.Graphics.DrawImage(imagenRotada, 2, 9, 40, 60)

            e.Graphics.DrawImage(bm, 45, 28, 130, 35)
            e.Graphics.DrawImage(PictureBox2.Image, 55, 49, 110, 15) 'LA CAJA DE TEXTO
            e.Graphics.DrawString(txtbarras.Text, fuentita, Brushes.Black, 107, 55, sc) 'CODIGO DE BARRAS
            e.HasMorePages = False
        End If

        If orientacionlogo = "DERECHA" Then
            Y += 10

            Dim caracteresPorLinea As Integer = 30
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 5, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While
            Y += 3

            'GIRARA EL LOGO DERECHA
            Dim imagenRotada As Image = New Bitmap(bme.Height, bme.Width)

            ' Crear un objeto Graphics basado en la imagen rotada
            Using g As Graphics = Graphics.FromImage(imagenRotada)
                ' Rotar la imagen original 90 grados en sentido antihorario
                g.TranslateTransform(bme.Height / 2, bme.Width / 2)
                g.RotateTransform(90)
                g.TranslateTransform(-bme.Width / 2, -bme.Height / 2)
                g.DrawImage(bme, New System.Drawing.Point(0, 0))
            End Using

            ' Dibujar la imagen rotada en el gráfico con el tamaño ajustado
            e.Graphics.DrawImage(imagenRotada, 136, 8, 50, 62)

            e.Graphics.DrawImage(bm, 5, 28, 130, 35)
            e.Graphics.DrawImage(PictureBox2.Image, 10, 49, 120, 15) 'LA CAJA DE TEXTO
            e.Graphics.DrawString(txtbarras.Text, fuentita, Brushes.Black, 70, 55, sc) 'CODIGO DE BARRAS
            e.HasMorePages = False
        End If

        If orientacionlogo = "S/ETI" Then

            Y += 10

            Dim caracteresPorLinea As Integer = 30
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 5, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While
            Y += 3
            'e.Graphics.DrawString("$ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 60, Y, sc)
            e.Graphics.DrawImage(bm, 5, 31, 130, 35)
            e.Graphics.DrawImage(PictureBox2.Image, 10, 52, 120, 15) 'LA CAJA DE TEXTO
            e.Graphics.DrawString(txtbarras.Text, fuentita, Brushes.Black, 70, 57, sc) 'CODIGO DE BARRAS
            e.HasMorePages = False
        End If

    End Sub

    Private Sub pPCP5x25_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pPCP5x25.PrintPage
        Dim fuentita As New Drawing.Font("Lucida Sans Typewriter", 5, FontStyle.Bold)
        Dim Y As Double = 0
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim bm As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Dim bme As New Bitmap(piclogo.Width, piclogo.Height)

        piclogo.DrawToBitmap(bme, New Rectangle(0, 0, bm.Width, bm.Height))
        PictureBox1.DrawToBitmap(bm, New Rectangle(0, 0, bm.Width, bm.Height))
        'x,Y,ANCHO,ALTO

        If orientacionlogo = "ARRIBA" Then
            e.Graphics.DrawImage(bme, 10, 5, 110, 30)
            Y = 35

            Dim caracteresPorLinea As Integer = 30
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 5, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While

            e.Graphics.DrawString("$ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 65, Y, sc)
            Y += 8

            e.Graphics.DrawImage(bm, 5, 63, 130, 35)
            e.Graphics.DrawImage(PictureBox2.Image, 9, 84, 120, 15) 'LA CAJA DE TEXTO
            e.Graphics.DrawString(txtbarras.Text, fuentita, Brushes.Black, 65, 88, sc) 'CODIGO DE BARRAS
            e.HasMorePages = False
        End If

        If orientacionlogo = "IZQUIERDA" Then

            'GIRARA EL LOGO IZQUIERDA
            Dim imagenRotada As Image = New Bitmap(bme.Height, bme.Width)

            ' Crear un objeto Graphics basado en la imagen rotada
            Using g As Graphics = Graphics.FromImage(imagenRotada)
                ' Rotar la imagen original 90 grados en sentido antihorario
                g.TranslateTransform(bme.Height / 2, bme.Width / 2)
                g.RotateTransform(-90)
                g.TranslateTransform(-bme.Width / 2, -bme.Height / 2)
                g.DrawImage(bme, New System.Drawing.Point(0, 0))
            End Using

            ' Dibujar la imagen rotada en el gráfico con el tamaño ajustado
            e.Graphics.DrawImage(imagenRotada, 2, 10, 50, 70)

            Y += 10
            Dim caracteresPorLinea As Integer = 30
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 50, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While

            e.Graphics.DrawString("$ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 105, Y, sc)
            Y += 8

            e.Graphics.DrawImage(bm, 50, 35, 120, 35)
            e.Graphics.DrawImage(PictureBox2.Image, 55, 56, 110, 15) 'LA CAJA DE TEXTO
            e.Graphics.DrawString(txtbarras.Text, fuentita, Brushes.Black, 108, 60, sc) 'CODIGO DE BARRAS
            e.HasMorePages = False
        End If


        If orientacionlogo = "DERECHA" Then

            'GIRARA EL LOGO IZQUIERDA
            Dim imagenRotada As Image = New Bitmap(bme.Height, bme.Width)

            ' Crear un objeto Graphics basado en la imagen rotada
            Using g As Graphics = Graphics.FromImage(imagenRotada)
                ' Rotar la imagen original 90 grados en sentido antihorario
                g.TranslateTransform(bme.Height / 2, bme.Width / 2)
                g.RotateTransform(-90)
                g.TranslateTransform(-bme.Width / 2, -bme.Height / 2)
                g.DrawImage(bme, New System.Drawing.Point(0, 0))
            End Using

            ' Dibujar la imagen rotada en el gráfico con el tamaño ajustado
            e.Graphics.DrawImage(imagenRotada, 126, 10, 40, 70)

            Y += 10
            Dim caracteresPorLinea As Integer = 28
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 4, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While

            e.Graphics.DrawString("$ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 65, Y, sc)
            Y += 8

            e.Graphics.DrawImage(bm, 3, 35, 120, 35)
            e.Graphics.DrawImage(PictureBox2.Image, 10, 56, 100, 15) 'LA CAJA DE TEXTO
            e.Graphics.DrawString(txtbarras.Text, fuentita, Brushes.Black, 60, 60, sc) 'CODIGO DE BARRAS
            e.HasMorePages = False

        End If

        If orientacionlogo = "S/ETI" Then

            Y += 10
            Dim caracteresPorLinea As Integer = 28
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 3, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While

            e.Graphics.DrawString("$ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 57, Y, sc)
            Y += 8

            e.Graphics.DrawImage(bm, 5, 35, 120, 35)
            e.Graphics.DrawImage(PictureBox2.Image, 14, 56, 100, 15) 'LA CAJA DE TEXTO
            e.Graphics.DrawString(txtbarras.Text, fuentita, Brushes.Black, 65, 60, sc) 'CODIGO DE BARRAS
            e.HasMorePages = False

        End If
    End Sub

    Private Sub pPCP5x3_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pPCP5x3.PrintPage

        Dim fuentita As New Drawing.Font("Lucida Sans Typewriter", 5, FontStyle.Bold)
        Dim fuentitap As New Drawing.Font("Lucida Sans Typewriter", 7, FontStyle.Bold)
        Dim Y As Double = 0
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim bm As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Dim bme As New Bitmap(piclogo.Width, piclogo.Height)

        piclogo.DrawToBitmap(bme, New Rectangle(0, 0, bm.Width, bm.Height))
        PictureBox1.DrawToBitmap(bm, New Rectangle(0, 0, bm.Width, bm.Height))
        'x,Y,ANCHO,ALTO

        If orientacionlogo = "ARRIBA" Then
            e.Graphics.DrawImage(bme, 6, 5, 165, 30)
            Y = 40

            Dim caracteresPorLinea As Integer = 30
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentitap, Brushes.Black, 5, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While
            Y += 5
            e.Graphics.DrawString("$ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 95, Y, sc)
            Y += 8

            e.Graphics.DrawImage(bm, 5, 72, 170, 35)
            e.Graphics.DrawImage(PictureBox2.Image, 12, 94, 155, 15) 'LA CAJA DE TEXTO
            e.Graphics.DrawString(txtbarras.Text, fuentita, Brushes.Black, 85, 98, sc) 'CODIGO DE BARRAS
            e.HasMorePages = False
        End If

        If orientacionlogo = "IZQUIERDA" Then

            'GIRARA EL LOGO IZQUIERDA
            Dim imagenRotada As Image = New Bitmap(bme.Height, bme.Width)

            ' Crear un objeto Graphics basado en la imagen rotada
            Using g As Graphics = Graphics.FromImage(imagenRotada)
                ' Rotar la imagen original 90 grados en sentido antihorario
                g.TranslateTransform(bme.Height / 2, bme.Width / 2)
                g.RotateTransform(-90)
                g.TranslateTransform(-bme.Width / 2, -bme.Height / 2)
                g.DrawImage(bme, New System.Drawing.Point(0, 0))
            End Using

            ' Dibujar la imagen rotada en el gráfico con el tamaño ajustado
            e.Graphics.DrawImage(imagenRotada, 2, 13, 40, 60)

            Y += 10
            Dim caracteresPorLinea As Integer = 30
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 45, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While

            e.Graphics.DrawString("$ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 105, Y, sc)
            Y += 8

            e.Graphics.DrawImage(bm, 46, 35, 120, 35)
            e.Graphics.DrawImage(PictureBox2.Image, 51, 56, 110, 15) 'LA CAJA DE TEXTO
            e.Graphics.DrawString(txtbarras.Text, fuentita, Brushes.Black, 105, 60, sc) 'CODIGO DE BARRAS
            e.HasMorePages = False
        End If

        If orientacionlogo = "DERECHA" Then
            'GIRARA EL LOGO IZQUIERDA
            Dim imagenRotada As Image = New Bitmap(bme.Height, bme.Width)

            ' Crear un objeto Graphics basado en la imagen rotada
            Using g As Graphics = Graphics.FromImage(imagenRotada)
                ' Rotar la imagen original 90 grados en sentido antihorario
                g.TranslateTransform(bme.Height / 2, bme.Width / 2)
                g.RotateTransform(-90)
                g.TranslateTransform(-bme.Width / 2, -bme.Height / 2)
                g.DrawImage(bme, New System.Drawing.Point(0, 0))
            End Using

            ' Dibujar la imagen rotada en el gráfico con el tamaño ajustado
            e.Graphics.DrawImage(imagenRotada, 135, 10, 40, 60)

            Y += 10
            Dim caracteresPorLinea As Integer = 30
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 4, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While

            e.Graphics.DrawString("$ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 65, Y, sc)
            Y += 8

            e.Graphics.DrawImage(bm, 6, 35, 125, 35)
            e.Graphics.DrawImage(PictureBox2.Image, 15, 56, 110, 15) 'LA CAJA DE TEXTO
            e.Graphics.DrawString(txtbarras.Text, fuentita, Brushes.Black, 70, 60, sc) 'CODIGO DE BARRAS
            e.HasMorePages = False

        End If

        If orientacionlogo = "S/ETI" Then
            Y += 10
            Dim caracteresPorLinea As Integer = 30
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 3, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While

            e.Graphics.DrawString("$ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 57, Y, sc)
            Y += 8

            e.Graphics.DrawImage(bm, 5, 35, 120, 35)
            e.Graphics.DrawImage(PictureBox2.Image, 14, 56, 100, 15) 'LA CAJA DE TEXTO
            e.Graphics.DrawString(txtbarras.Text, fuentita, Brushes.Black, 65, 60, sc) 'CODIGO DE BARRAS
            e.HasMorePages = False
        End If

    End Sub

    Private Sub pPC5x3_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pPC5x3.PrintPage

        Dim fuentita As New Drawing.Font("Lucida Sans Typewriter", 5, FontStyle.Bold)
        Dim Y As Double = 0
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim bm As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Dim bme As New Bitmap(piclogo.Width, piclogo.Height)

        piclogo.DrawToBitmap(bme, New Rectangle(0, 0, bm.Width, bm.Height))
        PictureBox1.DrawToBitmap(bm, New Rectangle(0, 0, bm.Width, bm.Height))
        'x,Y,ANCHO,ALTO

        If orientacionlogo = "ARRIBA" Then
            e.Graphics.DrawImage(bme, 7, 5, 115, 25)
            Y = 35

            Dim caracteresPorLinea As Integer = 30
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 5, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While
            Y += 3
            'e.Graphics.DrawString("$ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 70, Y, sc)


            e.Graphics.DrawImage(bm, 5, 58, 130, 35)
            e.Graphics.DrawImage(PictureBox2.Image, 11, 80, 120, 15) 'LA CAJA DE TEXTO
            e.Graphics.DrawString(txtbarras.Text, fuentita, Brushes.Black, 65, 84, sc) 'CODIGO DE BARRAS
            e.HasMorePages = False
        End If

        If orientacionlogo = "IZQUIERDA" Then
            Y += 10

            Dim caracteresPorLinea As Integer = 30
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 45, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While
            Y += 2
            'e.Graphics.DrawString("$ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 105, Y, sc)

            'GIRARA EL LOGO IZQUIERDA
            Dim imagenRotada As Image = New Bitmap(bme.Height, bme.Width)

            ' Crear un objeto Graphics basado en la imagen rotada
            Using g As Graphics = Graphics.FromImage(imagenRotada)
                ' Rotar la imagen original 90 grados en sentido antihorario
                g.TranslateTransform(bme.Height / 2, bme.Width / 2)
                g.RotateTransform(-90)
                g.TranslateTransform(-bme.Width / 2, -bme.Height / 2)
                g.DrawImage(bme, New System.Drawing.Point(0, 0))
            End Using

            ' Dibujar la imagen rotada en el gráfico con el tamaño ajustado
            e.Graphics.DrawImage(imagenRotada, 2, 9, 40, 60)

            e.Graphics.DrawImage(bm, 45, 32, 130, 35)
            e.Graphics.DrawImage(PictureBox2.Image, 55, 53, 110, 15) 'LA CAJA DE TEXTO
            e.Graphics.DrawString(txtbarras.Text, fuentita, Brushes.Black, 113, 58, sc) 'CODIGO DE BARRAS
            e.HasMorePages = False
        End If

        If orientacionlogo = "DERECHA" Then
            Y += 10

            Dim caracteresPorLinea As Integer = 30
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 5, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While
            Y += 3
            '  e.Graphics.DrawString("$ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 105, Y, sc)

            'GIRARA EL LOGO DERECHA
            Dim imagenRotada As Image = New Bitmap(bme.Height, bme.Width)

            ' Crear un objeto Graphics basado en la imagen rotada
            Using g As Graphics = Graphics.FromImage(imagenRotada)
                ' Rotar la imagen original 90 grados en sentido antihorario
                g.TranslateTransform(bme.Height / 2, bme.Width / 2)
                g.RotateTransform(90)
                g.TranslateTransform(-bme.Width / 2, -bme.Height / 2)
                g.DrawImage(bme, New System.Drawing.Point(0, 0))
            End Using

            ' Dibujar la imagen rotada en el gráfico con el tamaño ajustado
            e.Graphics.DrawImage(imagenRotada, 137, 10, 50, 90)

            e.Graphics.DrawImage(bm, 5, 30, 130, 35)
            e.Graphics.DrawImage(PictureBox2.Image, 10, 52, 120, 15) 'LA CAJA DE TEXTO
            e.Graphics.DrawString(txtbarras.Text, fuentita, Brushes.Black, 70, 55, sc) 'CODIGO DE BARRAS
            e.HasMorePages = False
        End If

        If orientacionlogo = "S/ETI" Then
            Y += 10

            Dim caracteresPorLinea As Integer = 30
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 5, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While
            Y += 3
            'e.Graphics.DrawString("$ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 65, Y, sc)
            e.Graphics.DrawImage(bm, 5, 30, 130, 35)
            e.Graphics.DrawImage(PictureBox2.Image, 10, 52, 120, 15) 'LA CAJA DE TEXTO
            e.Graphics.DrawString(txtbarras.Text, fuentita, Brushes.Black, 70, 55, sc) 'CODIGO DE BARRAS
            e.HasMorePages = False
        End If
    End Sub

    Private Sub pPP5x3_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pPP5x3.PrintPage

        Dim fuentita As New Drawing.Font("Lucida Sans Typewriter", 5, FontStyle.Bold)
        Dim Y As Double = 0
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim bm As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Dim bme As New Bitmap(piclogo.Width, piclogo.Height)

        piclogo.DrawToBitmap(bme, New Rectangle(0, 0, bm.Width, bm.Height))
        PictureBox1.DrawToBitmap(bm, New Rectangle(0, 0, bm.Width, bm.Height))
        'x,Y,ANCHO,ALTO
        If orientacionlogo = "ARRIBA" Then

            e.Graphics.DrawImage(bme, 5, 5, 120, 30)
            Y = 35

            Dim caracteresPorLinea As Integer = 30
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 5, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While
            Y += 3
            e.Graphics.DrawString("$ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 65, Y, sc)

            e.HasMorePages = False
        End If

        If orientacionlogo = "IZQUIERDA" Then

            Y += 40

            Dim caracteresPorLinea As Integer = 30
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 52, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While
            Y += 3
            e.Graphics.DrawString("$ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 105, Y, sc)

            'GIRARA EL LOGO IZQUIERDA
            Dim imagenRotada As Image = New Bitmap(bme.Height, bme.Width)

            ' Crear un objeto Graphics basado en la imagen rotada
            Using g As Graphics = Graphics.FromImage(imagenRotada)
                ' Rotar la imagen original 90 grados en sentido antihorario
                g.TranslateTransform(bme.Height / 2, bme.Width / 2)
                g.RotateTransform(-90)
                g.TranslateTransform(-bme.Width / 2, -bme.Height / 2)
                g.DrawImage(bme, New System.Drawing.Point(0, 0))
            End Using

            ' Dibujar la imagen rotada en el gráfico con el tamaño ajustado
            e.Graphics.DrawImage(imagenRotada, 3, 13, 50, 90)
            e.HasMorePages = False

        End If

        If orientacionlogo = "DERECHA" Then

            Y += 30

            Dim caracteresPorLinea As Integer = 30
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 5, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While
            Y += 3
            e.Graphics.DrawString("$ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 75, Y, sc)

            'GIRARA EL LOGO DERECHA
            Dim imagenRotada As Image = New Bitmap(bme.Height, bme.Width)

            ' Crear un objeto Graphics basado en la imagen rotada
            Using g As Graphics = Graphics.FromImage(imagenRotada)
                ' Rotar la imagen original 90 grados en sentido antihorario
                g.TranslateTransform(bme.Height / 2, bme.Width / 2)
                g.RotateTransform(90)
                g.TranslateTransform(-bme.Width / 2, -bme.Height / 2)
                g.DrawImage(bme, New System.Drawing.Point(0, 0))
            End Using

            ' Dibujar la imagen rotada en el gráfico con el tamaño ajustado
            e.Graphics.DrawImage(imagenRotada, 137, 15, 30, 50)
            e.HasMorePages = False

        End If

        If orientacionlogo = "S/ETI" Then
            Y += 10

            Dim caracteresPorLinea As Integer = 30
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 5, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While
            Y += 3
            e.Graphics.DrawString("$ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 75, Y, sc)
            e.HasMorePages = False
        End If
    End Sub

    Private Sub pPP65x27_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pPP65x27.PrintPage

        Dim fuentita As New Drawing.Font("Lucida Sans Typewriter", 5, FontStyle.Bold)
        Dim Y As Double = 0
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim bm As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Dim bme As New Bitmap(piclogo.Width, piclogo.Height)

        piclogo.DrawToBitmap(bme, New Rectangle(0, 0, bm.Width, bm.Height))
        PictureBox1.DrawToBitmap(bm, New Rectangle(0, 0, bm.Width, bm.Height))

        If orientacionlogo = "ARRIBA" Then

            e.Graphics.DrawImage(bme, 5, 5, 120, 30)
            Y += 40

            Dim caracteresPorLinea As Integer = 30
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 5, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While
            Y += 3
            e.Graphics.DrawString("$ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 75, Y, sc)

            e.HasMorePages = False
        End If

        If orientacionlogo = "IZQUIERDA" Then

            Y += 40

            Dim caracteresPorLinea As Integer = 30
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 52, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While
            Y += 3
            e.Graphics.DrawString("$ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 105, Y, sc)

            'GIRARA EL LOGO IZQUIERDA
            Dim imagenRotada As Image = New Bitmap(bme.Height, bme.Width)

            ' Crear un objeto Graphics basado en la imagen rotada
            Using g As Graphics = Graphics.FromImage(imagenRotada)
                ' Rotar la imagen original 90 grados en sentido antihorario
                g.TranslateTransform(bme.Height / 2, bme.Width / 2)
                g.RotateTransform(-90)
                g.TranslateTransform(-bme.Width / 2, -bme.Height / 2)
                g.DrawImage(bme, New System.Drawing.Point(0, 0))
            End Using

            ' Dibujar la imagen rotada en el gráfico con el tamaño ajustado
            e.Graphics.DrawImage(imagenRotada, 3, 13, 50, 90)
            e.HasMorePages = False

        End If

        If orientacionlogo = "DERECHA" Then

            Y += 30

            Dim caracteresPorLinea As Integer = 30
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 5, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While
            Y += 3
            e.Graphics.DrawString("$ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 75, Y, sc)

            'GIRARA EL LOGO DERECHA
            Dim imagenRotada As Image = New Bitmap(bme.Height, bme.Width)

            ' Crear un objeto Graphics basado en la imagen rotada
            Using g As Graphics = Graphics.FromImage(imagenRotada)
                ' Rotar la imagen original 90 grados en sentido antihorario
                g.TranslateTransform(bme.Height / 2, bme.Width / 2)
                g.RotateTransform(90)
                g.TranslateTransform(-bme.Width / 2, -bme.Height / 2)
                g.DrawImage(bme, New System.Drawing.Point(0, 0))
            End Using

            ' Dibujar la imagen rotada en el gráfico con el tamaño ajustado
            e.Graphics.DrawImage(imagenRotada, 137, 10, 50, 60)
            e.HasMorePages = False

        End If

        If orientacionlogo = "S/ETI" Then
            Y += 10

            Dim caracteresPorLinea As Integer = 30
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 5, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While
            Y += 3
            e.Graphics.DrawString("$ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 75, Y, sc)
            e.HasMorePages = False
        End If

    End Sub

    Private Sub pPC65x27_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pPC65x27.PrintPage

        Dim fuentita As New Drawing.Font("Lucida Sans Typewriter", 5, FontStyle.Bold)
        Dim Y As Double = 0
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim bm As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Dim bme As New Bitmap(piclogo.Width, piclogo.Height)

        piclogo.DrawToBitmap(bme, New Rectangle(0, 0, bm.Width, bm.Height))
        PictureBox1.DrawToBitmap(bm, New Rectangle(0, 0, bm.Width, bm.Height))
        'x,Y,ANCHO,ALTO

        If orientacionlogo = "ARRIBA" Then
            e.Graphics.DrawImage(bme, 7, 5, 115, 25)
            Y = 35

            Dim caracteresPorLinea As Integer = 30
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 5, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While
            Y += 3
            'e.Graphics.DrawString("$ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 70, Y, sc)


            e.Graphics.DrawImage(bm, 5, 58, 130, 35)
            e.Graphics.DrawImage(PictureBox2.Image, 11, 80, 120, 15) 'LA CAJA DE TEXTO
            e.Graphics.DrawString(txtbarras.Text, fuentita, Brushes.Black, 65, 84, sc) 'CODIGO DE BARRAS
            e.HasMorePages = False
        End If

        If orientacionlogo = "IZQUIERDA" Then
            Y += 10

            Dim caracteresPorLinea As Integer = 30
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 45, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While
            Y += 2
            'e.Graphics.DrawString("$ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 105, Y, sc)

            'GIRARA EL LOGO IZQUIERDA
            Dim imagenRotada As Image = New Bitmap(bme.Height, bme.Width)

            ' Crear un objeto Graphics basado en la imagen rotada
            Using g As Graphics = Graphics.FromImage(imagenRotada)
                ' Rotar la imagen original 90 grados en sentido antihorario
                g.TranslateTransform(bme.Height / 2, bme.Width / 2)
                g.RotateTransform(-90)
                g.TranslateTransform(-bme.Width / 2, -bme.Height / 2)
                g.DrawImage(bme, New System.Drawing.Point(0, 0))
            End Using

            ' Dibujar la imagen rotada en el gráfico con el tamaño ajustado
            e.Graphics.DrawImage(imagenRotada, 2, 9, 40, 60)

            e.Graphics.DrawImage(bm, 45, 32, 130, 35)
            e.Graphics.DrawImage(PictureBox2.Image, 55, 53, 110, 15) 'LA CAJA DE TEXTO
            e.Graphics.DrawString(txtbarras.Text, fuentita, Brushes.Black, 113, 58, sc) 'CODIGO DE BARRAS
            e.HasMorePages = False
        End If

        If orientacionlogo = "DERECHA" Then
            Y += 10

            Dim caracteresPorLinea As Integer = 30
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 5, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While
            Y += 3
            '  e.Graphics.DrawString("$ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 105, Y, sc)

            'GIRARA EL LOGO DERECHA
            Dim imagenRotada As Image = New Bitmap(bme.Height, bme.Width)

            ' Crear un objeto Graphics basado en la imagen rotada
            Using g As Graphics = Graphics.FromImage(imagenRotada)
                ' Rotar la imagen original 90 grados en sentido antihorario
                g.TranslateTransform(bme.Height / 2, bme.Width / 2)
                g.RotateTransform(90)
                g.TranslateTransform(-bme.Width / 2, -bme.Height / 2)
                g.DrawImage(bme, New System.Drawing.Point(0, 0))
            End Using

            ' Dibujar la imagen rotada en el gráfico con el tamaño ajustado
            e.Graphics.DrawImage(imagenRotada, 137, 10, 50, 70)

            e.Graphics.DrawImage(bm, 5, 30, 130, 35)
            e.Graphics.DrawImage(PictureBox2.Image, 10, 52, 120, 15) 'LA CAJA DE TEXTO
            e.Graphics.DrawString(txtbarras.Text, fuentita, Brushes.Black, 70, 55, sc) 'CODIGO DE BARRAS
            e.HasMorePages = False
        End If

        If orientacionlogo = "S/ETI" Then
            Y += 10

            Dim caracteresPorLinea As Integer = 30
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 5, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While
            Y += 3
            'e.Graphics.DrawString("$ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 65, Y, sc)
            e.Graphics.DrawImage(bm, 5, 30, 130, 35)
            e.Graphics.DrawImage(PictureBox2.Image, 10, 52, 120, 15) 'LA CAJA DE TEXTO
            e.Graphics.DrawString(txtbarras.Text, fuentita, Brushes.Black, 70, 55, sc) 'CODIGO DE BARRAS
            e.HasMorePages = False
        End If

    End Sub

    Private Sub pPCP65x27_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pPCP65x27.PrintPage

        Dim fuentita As New Drawing.Font("Lucida Sans Typewriter", 5, FontStyle.Bold)
        Dim fuentitap As New Drawing.Font("Lucida Sans Typewriter", 7, FontStyle.Bold)
        Dim Y As Double = 0
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim bm As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Dim bme As New Bitmap(piclogo.Width, piclogo.Height)

        piclogo.DrawToBitmap(bme, New Rectangle(0, 0, bm.Width, bm.Height))
        PictureBox1.DrawToBitmap(bm, New Rectangle(0, 0, bm.Width, bm.Height))
        'x,Y,ANCHO,ALTO

        If orientacionlogo = "ARRIBA" Then
            e.Graphics.DrawImage(bme, 6, 5, 195, 30)
            Y = 40

            Dim caracteresPorLinea As Integer = 33
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentitap, Brushes.Black, 5, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While
            Y += 5
            e.Graphics.DrawString("$ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 105, Y, sc)
            Y += 8

            e.Graphics.DrawImage(bm, 5, 72, 195, 35)
            e.Graphics.DrawImage(PictureBox2.Image, 12, 94, 180, 15) 'LA CAJA DE TEXTO
            e.Graphics.DrawString(txtbarras.Text, fuentita, Brushes.Black, 100, 98, sc) 'CODIGO DE BARRAS
            e.HasMorePages = False
        End If

        If orientacionlogo = "IZQUIERDA" Then

            'GIRARA EL LOGO IZQUIERDA
            Dim imagenRotada As Image = New Bitmap(bme.Height, bme.Width)

            ' Crear un objeto Graphics basado en la imagen rotada
            Using g As Graphics = Graphics.FromImage(imagenRotada)
                ' Rotar la imagen original 90 grados en sentido antihorario
                g.TranslateTransform(bme.Height / 2, bme.Width / 2)
                g.RotateTransform(-90)
                g.TranslateTransform(-bme.Width / 2, -bme.Height / 2)
                g.DrawImage(bme, New System.Drawing.Point(0, 0))
            End Using

            ' Dibujar la imagen rotada en el gráfico con el tamaño ajustado
            e.Graphics.DrawImage(imagenRotada, 2, 13, 40, 60)

            Y += 10
            Dim caracteresPorLinea As Integer = 33
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 45, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While

            e.Graphics.DrawString("$ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 110, Y, sc)
            Y += 8

            e.Graphics.DrawImage(bm, 46, 35, 140, 35)
            e.Graphics.DrawImage(PictureBox2.Image, 51, 56, 125, 15) 'LA CAJA DE TEXTO
            e.Graphics.DrawString(txtbarras.Text, fuentita, Brushes.Black, 110, 60, sc) 'CODIGO DE BARRAS
            e.HasMorePages = False
        End If

        If orientacionlogo = "DERECHA" Then
            'GIRARA EL LOGO IZQUIERDA
            Dim imagenRotada As Image = New Bitmap(bme.Height, bme.Width)

            ' Crear un objeto Graphics basado en la imagen rotada
            Using g As Graphics = Graphics.FromImage(imagenRotada)
                ' Rotar la imagen original 90 grados en sentido antihorario
                g.TranslateTransform(bme.Height / 2, bme.Width / 2)
                g.RotateTransform(-90)
                g.TranslateTransform(-bme.Width / 2, -bme.Height / 2)
                g.DrawImage(bme, New System.Drawing.Point(0, 0))
            End Using

            ' Dibujar la imagen rotada en el gráfico con el tamaño ajustado
            e.Graphics.DrawImage(imagenRotada, 155, 10, 40, 60)

            Y += 10
            Dim caracteresPorLinea As Integer = 33
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 4, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While

            e.Graphics.DrawString("$ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 75, Y, sc)
            Y += 8

            e.Graphics.DrawImage(bm, 6, 35, 145, 35)
            e.Graphics.DrawImage(PictureBox2.Image, 15, 56, 120, 15) 'LA CAJA DE TEXTO
            e.Graphics.DrawString(txtbarras.Text, fuentita, Brushes.Black, 75, 60, sc) 'CODIGO DE BARRAS
            e.HasMorePages = False

        End If

        If orientacionlogo = "S/ETI" Then
            Y += 10
            Dim caracteresPorLinea As Integer = 33
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 3, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While

            e.Graphics.DrawString("$ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 70, Y, sc)
            Y += 8

            e.Graphics.DrawImage(bm, 5, 35, 150, 35)
            e.Graphics.DrawImage(PictureBox2.Image, 14, 56, 130, 15) 'LA CAJA DE TEXTO
            e.Graphics.DrawString(txtbarras.Text, fuentita, Brushes.Black, 75, 60, sc) 'CODIGO DE BARRAS
            e.HasMorePages = False
        End If

    End Sub

    Private Sub pPCP25x38_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pPCP25x38.PrintPage
        Dim fuentita As New Drawing.Font("Lucida Sans Typewriter", 5, FontStyle.Bold)
        Dim Y As Double = 0
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim bm As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Dim bme As New Bitmap(piclogo.Width, piclogo.Height)

        piclogo.DrawToBitmap(bme, New Rectangle(0, 0, bm.Width, bm.Height))
        PictureBox1.DrawToBitmap(bm, New Rectangle(0, 0, bm.Width, bm.Height))
        'x,Y,ANCHO,ALTO

        If orientacionlogo = "ARRIBA" Then
            e.Graphics.DrawImage(bme, 10, 5, 110, 30)
            Y = 35

            Dim caracteresPorLinea As Integer = 28
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 5, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While

            e.Graphics.DrawString("$ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 65, Y, sc)
            Y += 8

            e.Graphics.DrawImage(bm, 5, 63, 100, 30)
            e.Graphics.DrawImage(PictureBox2.Image, 9, 84, 93, 10) 'LA CAJA DE TEXTO
            e.Graphics.DrawString(txtbarras.Text, fuentita, Brushes.Black, 50, 85, sc) 'CODIGO DE BARRAS
            e.HasMorePages = False
        End If

        If orientacionlogo = "IZQUIERDA" Then
            Y += 10
            'GIRARA EL LOGO IZQUIERDA
            Dim imagenRotada As Image = New Bitmap(bme.Height, bme.Width)

            ' Crear un objeto Graphics basado en la imagen rotada
            Using g As Graphics = Graphics.FromImage(imagenRotada)
                ' Rotar la imagen original 90 grados en sentido antihorario
                g.TranslateTransform(bme.Height / 2, bme.Width / 2)
                g.RotateTransform(-90)
                g.TranslateTransform(-bme.Width / 2, -bme.Height / 2)
                g.DrawImage(bme, New System.Drawing.Point(0, 0))
            End Using

            ' Dibujar la imagen rotada en el gráfico con el tamaño ajustado
            e.Graphics.DrawImage(imagenRotada, 1, 28, 40, 60)


            Dim caracteresPorLinea As Integer = 28
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 3, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While

            e.Graphics.DrawString("$ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 70, Y, sc)
            Y += 7

            e.Graphics.DrawImage(bm, 45, 40, 82, 35)
            e.Graphics.DrawImage(PictureBox2.Image, 50, 66, 72, 10) 'LA CAJA DE TEXTO
            e.Graphics.DrawString(txtbarras.Text, fuentita, Brushes.Black, 85, 67, sc) 'CODIGO DE BARRAS
            e.HasMorePages = False
        End If


        If orientacionlogo = "DERECHA" Then

            'GIRARA EL LOGO IZQUIERDA
            Dim imagenRotada As Image = New Bitmap(bme.Height, bme.Width)

            ' Crear un objeto Graphics basado en la imagen rotada
            Using g As Graphics = Graphics.FromImage(imagenRotada)
                ' Rotar la imagen original 90 grados en sentido antihorario
                g.TranslateTransform(bme.Height / 2, bme.Width / 2)
                g.RotateTransform(-90)
                g.TranslateTransform(-bme.Width / 2, -bme.Height / 2)
                g.DrawImage(bme, New System.Drawing.Point(0, 0))
            End Using

            ' Dibujar la imagen rotada en el gráfico con el tamaño ajustado
            e.Graphics.DrawImage(imagenRotada, 90, 25, 40, 70)

            Y += 10
            Dim caracteresPorLinea As Integer = 28
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 4, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While

            e.Graphics.DrawString("$ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 65, Y, sc)
            Y += 7

            e.Graphics.DrawImage(bm, 3, 37, 82, 35)
            e.Graphics.DrawImage(PictureBox2.Image, 10, 63, 70, 10) 'LA CAJA DE TEXTO
            e.Graphics.DrawString(txtbarras.Text, fuentita, Brushes.Black, 42, 65, sc) 'CODIGO DE BARRAS
            e.HasMorePages = False

        End If

        If orientacionlogo = "S/ETI" Then

            Y += 10
            Dim caracteresPorLinea As Integer = 28
            Dim texto As String = cbonombre.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, fuentita, Brushes.Black, 3, Y)
                Y += 8
                inicio += caracteresPorLinea
            End While

            e.Graphics.DrawString("$ " & FormatNumber(txtprecio.Text, 2), fuentita, Brushes.Black, 57, Y, sc)
            Y += 8

            e.Graphics.DrawImage(bm, 5, 35, 100, 50)
            e.Graphics.DrawImage(PictureBox2.Image, 10, 76, 90, 10) 'LA CAJA DE TEXTO
            e.Graphics.DrawString(txtbarras.Text, fuentita, Brushes.Black, 55, 77, sc) 'CODIGO DE BARRAS
            e.HasMorePages = False

        End If
    End Sub
End Class
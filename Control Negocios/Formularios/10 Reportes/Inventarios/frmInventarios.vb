Imports System.IO



Public Class frmInventarios

    Private Sub DataGridView1_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing
        ' Verificar si la celda en edición pertenece a una columna específica (opcional)
        If DataGridView1.CurrentCell.ColumnIndex = 3 Then
            If TypeOf e.Control Is TextBox Then
                Dim txt As TextBox = CType(e.Control, TextBox)

                ' Eliminar cualquier controlador previo del evento KeyPress
                RemoveHandler txt.KeyPress, AddressOf TextBox_KeyPress

                ' Agregar el controlador para el evento KeyPress
                AddHandler txt.KeyPress, AddressOf TextBox_KeyPress
            End If
        End If

    End Sub

    ' Controlador para restringir la entrada solo a números y un punto decimal
    Private Sub TextBox_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim txt As TextBox = CType(sender, TextBox)

        ' Permitir solo dígitos (0-9), tecla de retroceso (Backspace), y el punto decimal
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso e.KeyChar <> "." Then
            e.Handled = True ' Bloquear cualquier otro carácter
        ElseIf e.KeyChar = "." Then
            ' Si ya hay un punto decimal, no permitir otro
            If txt.Text.Contains(".") Then
                e.Handled = True ' Bloquear si ya existe un punto decimal
            End If
        End If
    End Sub
    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Dim cell As DataGridViewCell = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex)

            If cell.ColumnIndex = 0 Then
                ' Verifica que la celda no esté vacía
                If Not IsDBNull(cell.Value) AndAlso cell.Value IsNot Nothing AndAlso cell.Value.ToString().Trim() <> "" Then
                    cnn1.Close()
                    cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "Select Nombre,Existencia from Productos where CodBarra='" & cell.Value.ToString & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.Read Then
                        DataGridView1.Rows(e.RowIndex).Cells(1).Value = rd1(0).ToString
                        DataGridView1.Rows(e.RowIndex).Cells(2).Value = rd1(1).ToString
                        GoTo kaka
                    End If
kaka:
                    rd1.Close()
                    cnn1.Close()
                End If
            End If

            If cell.ColumnIndex = 3 Then
                If Not IsDBNull(cell.Value) AndAlso cell.Value IsNot Nothing AndAlso cell.Value.ToString().Trim() <> "" Then
                    Dim sistema As Double = DataGridView1.Rows(e.RowIndex).Cells(2).Value
                    Dim fisica As Double = cell.Value.ToString
                    Dim diferencia As Double = fisica - sistema
                    If diferencia < 0 Then
                        DataGridView1.Rows(e.RowIndex).Cells(4).Value = diferencia
                        DataGridView1.Rows(e.RowIndex).Cells(5).Value = "0"
                    Else
                        DataGridView1.Rows(e.RowIndex).Cells(4).Value = "0"
                        DataGridView1.Rows(e.RowIndex).Cells(5).Value = diferencia
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub pSalida80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pSalida80.PrintPage
        'Fuentes prederminadas
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 10, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 9, FontStyle.Regular)
        Dim fuente_fecha As New Drawing.Font(tipografia, 8, FontStyle.Regular)
        'Variables
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim pen As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0
        Dim nLogo As String = DatosRecarga("LogoG")
        Dim Logotipo As Drawing.Image = Nothing
        Dim tLogo As String = DatosRecarga("TipoLogo")
        Dim simbolo As String = DatosRecarga("Simbolo")
        Dim Pie As String = ""

        On Error GoTo milky

        '[°]. Logotipo
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

        '[°]. Datos del negocio
        cnn1.Close() : cnn1.Open()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select Pie2,Cab0,Cab1,Cab2,Cab3,Cab4,Cab5,Cab6 from Ticket"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                Pie = rd1("Pie2").ToString
                'Razón social
                If rd1("Cab0").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                    Y += 12.5
                End If
                'RFC
                If rd1("Cab1").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                    Y += 12.5
                End If
                'Calle  N°.
                If rd1("Cab2").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                    Y += 12
                End If
                'Colonia
                If rd1("Cab3").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                    Y += 12
                End If
                'Delegación / Municipio - Entidad
                If rd1("Cab4").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                    Y += 12
                End If
                'Teléfono
                If rd1("Cab5").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                    Y += 12
                End If
                'Correo
                If rd1("Cab6").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                    Y += 12
                End If
                Y += 17
            End If
        Else
            Y += 0
        End If
        rd1.Close()

        '[1]. Datos de la venta
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString(" - I N V E T A R I O - ", New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 140, Y, sc)
        Y += 14
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 18

        e.Graphics.DrawString("Fecha: " & Format(Date.Now, "d/MM/yyyy HH:mm:ss"), fuente_fecha, Brushes.Black, 1, Y)

        Y += 17
        Y += 4
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 12


        e.Graphics.DrawString("ARTICULO", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
        e.Graphics.DrawString("PRODUCTO", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 112, Y)
        e.Graphics.DrawString("FISICO.", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 252, Y, sc)
        Y += 6
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 18

        Dim total_prods As Double = 0

        For miku As Integer = 0 To DataGridView1.Rows.Count - 2

            Dim barras As String = DataGridView1.Rows(miku).Cells(0).Value.ToString()
            Dim nombre As String = DataGridView1.Rows(miku).Cells(1).Value.ToString()

            e.Graphics.DrawString(barras, fuente_prods, Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString(Mid(nombre, 1, 28), fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString("______|", fuente_prods, Brushes.Black, 252, Y, sc)
            Y += 15


        Next
        Y += 10
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 40
        e.Graphics.DrawString(" - FIN DE REPORTE - ", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)

        e.HasMorePages = False
        Exit Sub
milky:
        MsgBox("No se pudo generar el documento, a continuación se muestra la descripción del error." & vbNewLine & vbNewLine & Err.Number & " - " & Err.Description)
        cnn1.Close()
        Exit Sub
    End Sub


    Private Sub rbSelectivo_CheckedChanged(sender As Object, e As EventArgs) Handles rbSelectivo.CheckedChanged
        If rbSelectivo.Checked = True Then
            cbofiltro.Visible = False
            DataGridView1.Rows.Clear()
            cbofiltro.Text = ""
            DataGridView1.Columns(0).ReadOnly = False
            TextBox1.Text = ""
            TextBox1.ReadOnly = False
        End If
    End Sub

    Private Sub rbDepa_CheckedChanged(sender As Object, e As EventArgs) Handles rbDepa.CheckedChanged
        If rbDepa.Checked = True Then
            cbofiltro.Visible = True
            DataGridView1.Rows.Clear()
            cbofiltro.Text = ""
            DataGridView1.Columns(0).ReadOnly = True
            TextBox1.ReadOnly = True
        End If
    End Sub

    Private Sub rbGrupo_CheckedChanged(sender As Object, e As EventArgs) Handles rbGrupo.CheckedChanged
        If rbGrupo.Checked = True Then
            cbofiltro.Visible = True
            DataGridView1.Rows.Clear()
            cbofiltro.Text = ""
            DataGridView1.Columns(0).ReadOnly = True
            TextBox1.ReadOnly = True
        End If
    End Sub

    Private Sub cbofiltro_DropDown(sender As Object, e As EventArgs) Handles cbofiltro.DropDown
        Try
            cbofiltro.Items.Clear()
            If rbDepa.Checked = True Then
                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Select distinct Departamento from Productos where Departamento<>'' order by Departamento asc"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    cbofiltro.Items.Add(rd1(0).ToString)
                Loop
                rd1.Close()
                cnn1.Close()
            End If

            If rbGrupo.Checked = True Then
                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Select distinct Grupo from Productos where Grupo<>'' order by Grupo asc"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    cbofiltro.Items.Add(rd1(0).ToString)
                Loop
                rd1.Close()
                cnn1.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbofiltro_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbofiltro.SelectedValueChanged
        If rbDepa.Checked = True Then
            DataGridView1.Rows.Clear()
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "select CodBarra,Nombre,Existencia from Productos where Departamento='" & cbofiltro.Text & "'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                DataGridView1.Rows.Add(rd1(0).ToString, rd1(1).ToString, rd1(2).ToString)
            Loop
            TextBox1.Text = cbofiltro.Text
            rd1.Close()
            cnn1.Close()
        End If

        If rbGrupo.Checked = True Then
            DataGridView1.Rows.Clear()
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "select CodBarra,Nombre,Existencia from Productos where Grupo='" & cbofiltro.Text & "'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                DataGridView1.Rows.Add(rd1(0).ToString, rd1(1).ToString, rd1(2).ToString)
            Loop
            TextBox1.Text = cbofiltro.Text
            rd1.Close()
            cnn1.Close()
        End If
    End Sub

    Private Sub frmInventarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblfecha.Text = Format(Date.Now, "dd/MM/yyyy")
    End Sub

    Private Sub btnImprime_Click(sender As Object, e As EventArgs) Handles btnImprime.Click
        If DataGridView1.Rows.Count - 1 = 0 Then
            Exit Sub
        End If
        If MsgBox("¿Deseas imprimir el inventario seleccionado?", vbQuestion + vbOKCancel, "Delsscom Farmacias") = vbCancel Then
            Exit Sub
        End If
        pSalida80.Print()
    End Sub
End Class
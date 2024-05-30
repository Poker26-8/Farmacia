Imports iTextSharp.text

Public Class frmMadrid

    Friend WithEvents btnMesa As System.Windows.Forms.Button
    Dim mesaspropias As Integer = 0
    Dim contrainicio As Integer = 0

    Private Sub frmMadrid_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NotasCred FROM formatos where Facturas='MesasPropias'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    mesaspropias = rd1(0).ToString
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NotasCred FROM formatos WHERE Facturas='TomaContra'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    contrainicio = rd1(0).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

            If contrainicio = 1 Then
                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "SELECT Clave,Alias FROM Usuarios WHERE IdEmpleado=" & id_usu_log
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        txtClave.Text = rd2(0).ToString
                        lblUsuario.Text = rd2(1).ToString
                        txtClave.ForeColor = Color.Black
                        lblIdEmpleado.Text = id_usu_log
                    End If
                End If
                rd2.Close()
                cnn2.Close()
            End If

            CrearMesa()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

    End Sub

    Public Sub CrearMesa()
        Try
            Dim mesa As Integer = 1
            Dim messa As New List(Of String)()
            If txtClave.Text = "" Then txtClave.Focus.Equals(True) : Exit Sub

            If mesaspropias = 1 Then
                If contrainicio = 1 Then
                    cnn1.Close() : cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "SELECT Mesa.Nombre_mesa, Mesa.TempNom,Mesa.X,Mesa.Y,Mesa.Tipo,Mesa.IdEmpleado FROM Mesa, Mesasxempleados where Mesasxempleados.Mesa = Mesa.Nombre_mesa and Mesasxempleados.IdEmpleado = " & id_usu_log & " order by Orden"
                    rd1 = cmd1.ExecuteReader
                    Do While rd1.Read
                        If rd1.HasRows Then
                            If rd1("TempNom").ToString = "" Then
                                messa.Add(rd1.GetString("Nombre_mesa"))
                            Else
                                messa.Add(rd1.GetString("TempNom"))
                            End If

                        End If
                    Loop
                    rd1.Close()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "SELECT Nombre_mesa FROM mesa WHERE Temporal=0 AND IdEmpleado=0 ORDER BY Nombre_mesa"
                    rd1 = cmd1.ExecuteReader
                    Do While rd1.Read
                        If rd1.HasRows Then
                            messa.Add(rd1.GetString("Nombre_mesa"))
                        End If
                    Loop
                    cnn1.Close()
                    Dim totalMesas As Double = ObtenerTotalMesas()
                    If totalMesas = 0 Then Exit Sub
                    Dim cuantosColumnas As Integer = Math.Ceiling(Math.Sqrt(totalMesas)) ' Calculamos el número de columnas necesarias
                    Dim cuantosFilas As Integer = Math.Ceiling(totalMesas / cuantosColumnas) ' Calculamos el número de filas necesarias

                    ' Tamaño fijo de los botones
                    Dim btnWidth As Integer = 140 ' Ancho fijo del botón
                    Dim btnHeight As Integer = 100 ' Alto fijo del botón

                    ' Espacio entre botones
                    Dim espacioHorizontal As Integer = 5
                    Dim espacioVertical As Integer = 5

                    pMesas.Controls.Clear() ' Limpiamos los controles existentes en el panel

                    For fila As Integer = 0 To cuantosFilas - 1
                        For columna As Integer = 0 To cuantosColumnas - 1
                            If mesa > totalMesas Then Exit For

                            Dim nombreMesa As String = messa(mesa - 1)

                            btnMesa = New Button
                            btnMesa.Text = nombreMesa
                            btnMesa.Width = btnWidth
                            btnMesa.Height = btnHeight
                            btnMesa.FlatStyle = FlatStyle.Flat
                            btnMesa.FlatAppearance.BorderSize = 0
                            btnMesa.Name = "btnMesa(" & nombreMesa & ")"
                            btnMesa.TextAlign = ContentAlignment.BottomCenter
                            btnMesa.BackColor = Color.FromArgb(255, 255, 128)


                            btnMesa.BackgroundImageLayout = ImageLayout.Zoom

                            ' Posicionar el botón dentro del panel
                            btnMesa.Left = columna * (btnMesa.Width + espacioHorizontal)
                            btnMesa.Top = fila * (btnMesa.Height + espacioVertical)

                            AddHandler btnMesa.Click, AddressOf btnMesa_Click
                            pMesas.Controls.Add(btnMesa)
                            mesa += 1
                        Next
                    Next
                    ' Calcular el tamaño mínimo para habilitar el scroll si es necesario
                    Dim panelWidth As Integer = (cuantosColumnas * (btnWidth + espacioHorizontal)) + SystemInformation.VerticalScrollBarWidth
                    Dim panelHeight As Integer = (cuantosFilas * (btnHeight + espacioVertical))
                    pMesas.AutoScrollMinSize = New Size(panelWidth, panelHeight)

                Else
                    cnn1.Close() : cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "SELECT Mesa.Nombre_mesa, Mesa.TempNom,Mesa.X,Mesa.Y,Mesa.Tipo,Mesa.IdEmpleado FROM Mesa, Mesasxempleados where Mesasxempleados.Mesa = Mesa.Nombre_mesa and Mesasxempleados.IdEmpleado = " & lblIdEmpleado.Text & " order by Orden"
                    rd1 = cmd1.ExecuteReader
                    Do While rd1.Read
                        If rd1.HasRows Then
                            If rd1("TempNom").ToString = "" Then
                                messa.Add(rd1.GetString("Nombre_mesa"))
                            Else
                                messa.Add(rd1.GetString("TempNom"))
                            End If

                        End If
                    Loop
                    rd1.Close()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "SELECT Nombre_mesa FROM mesa WHERE Temporal=0 AND IdEmpleado=0 ORDER BY Nombre_mesa"
                    rd1 = cmd1.ExecuteReader
                    Do While rd1.Read
                        If rd1.HasRows Then
                            messa.Add(rd1.GetString("Nombre_mesa"))
                        End If
                    Loop
                    cnn1.Close()

                    Dim totalMesas As Double = ObtenerTotalMesas()
                    If totalMesas = 0 Then Exit Sub
                    Dim cuantosColumnas As Integer = Math.Ceiling(Math.Sqrt(totalMesas)) ' Calculamos el número de columnas necesarias
                    Dim cuantosFilas As Integer = Math.Ceiling(totalMesas / cuantosColumnas) ' Calculamos el número de filas necesarias

                    ' Tamaño fijo de los botones
                    Dim btnWidth As Integer = 140 ' Ancho fijo del botón
                    Dim btnHeight As Integer = 100 ' Alto fijo del botón

                    ' Espacio entre botones
                    Dim espacioHorizontal As Integer = 5
                    Dim espacioVertical As Integer = 5

                    pMesas.Controls.Clear() ' Limpiamos los controles existentes en el panel

                    For fila As Integer = 0 To cuantosFilas - 1
                        For columna As Integer = 0 To cuantosColumnas - 1
                            If mesa > totalMesas Then Exit For

                            Dim nombreMesa As String = messa(mesa - 1)

                            btnMesa = New Button
                            btnMesa.Text = nombreMesa
                            btnMesa.Width = btnWidth
                            btnMesa.Height = btnHeight
                            btnMesa.FlatStyle = FlatStyle.Flat
                            btnMesa.FlatAppearance.BorderSize = 0
                            btnMesa.Name = "btnMesa(" & nombreMesa & ")"
                            btnMesa.TextAlign = ContentAlignment.BottomCenter
                            btnMesa.BackColor = Color.FromArgb(255, 255, 128)


                            btnMesa.BackgroundImageLayout = ImageLayout.Zoom

                            ' Posicionar el botón dentro del panel
                            btnMesa.Left = columna * (btnMesa.Width + espacioHorizontal)
                            btnMesa.Top = fila * (btnMesa.Height + espacioVertical)

                            AddHandler btnMesa.Click, AddressOf btnMesa_Click
                            pMesas.Controls.Add(btnMesa)
                            mesa += 1
                        Next
                    Next
                    ' Calcular el tamaño mínimo para habilitar el scroll si es necesario
                    Dim panelWidth As Integer = (cuantosColumnas * (btnWidth + espacioHorizontal)) + SystemInformation.VerticalScrollBarWidth
                    Dim panelHeight As Integer = (cuantosFilas * (btnHeight + espacioVertical))
                    pMesas.AutoScrollMinSize = New Size(panelWidth, panelHeight)
                End If

            Else
                If contrainicio = 1 Then

                    cnn1.Close() : cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "SELECT Mesa.Nombre_mesa, Mesa.TempNom,Mesa.X,Mesa.Y,Mesa.Tipo,Mesa.IdEmpleado FROM Mesa, Mesasxempleados where Mesasxempleados.Mesa = Mesa.Nombre_mesa and Mesasxempleados.IdEmpleado = " & id_usu_log & " order by Orden"
                    rd1 = cmd1.ExecuteReader
                    Do While rd1.Read
                        If rd1.HasRows Then
                            If rd1("TempNom").ToString = "" Then
                                messa.Add(rd1.GetString("Nombre_mesa"))
                            Else
                                messa.Add(rd1.GetString("TempNom"))
                            End If

                        End If
                    Loop
                    rd1.Close()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "SELECT Nombre_mesa FROM mesa WHERE Temporal=0 AND IdEmpleado=0 ORDER BY Nombre_mesa"
                    rd1 = cmd1.ExecuteReader
                    Do While rd1.Read
                        If rd1.HasRows Then
                            messa.Add(rd1.GetString("Nombre_mesa"))
                        End If
                    Loop
                    cnn1.Close()
                    Dim totalMesas As Double = ObtenerTotalMesas()
                    If totalMesas = 0 Then Exit Sub
                    Dim cuantosColumnas As Integer = Math.Ceiling(Math.Sqrt(totalMesas)) ' Calculamos el número de columnas necesarias
                    Dim cuantosFilas As Integer = Math.Ceiling(totalMesas / cuantosColumnas) ' Calculamos el número de filas necesarias

                    ' Tamaño fijo de los botones
                    Dim btnWidth As Integer = 140 ' Ancho fijo del botón
                    Dim btnHeight As Integer = 100 ' Alto fijo del botón

                    ' Espacio entre botones
                    Dim espacioHorizontal As Integer = 5
                    Dim espacioVertical As Integer = 5

                    pMesas.Controls.Clear() ' Limpiamos los controles existentes en el panel

                    For fila As Integer = 0 To cuantosFilas - 1
                        For columna As Integer = 0 To cuantosColumnas - 1
                            If mesa > totalMesas Then Exit For

                            Dim nombreMesa As String = messa(mesa - 1)

                            btnMesa = New Button
                            btnMesa.Text = nombreMesa
                            btnMesa.Width = btnWidth
                            btnMesa.Height = btnHeight
                            btnMesa.FlatStyle = FlatStyle.Flat
                            btnMesa.FlatAppearance.BorderSize = 0
                            btnMesa.Name = "btnMesa(" & nombreMesa & ")"
                            btnMesa.TextAlign = ContentAlignment.BottomCenter
                            btnMesa.BackColor = Color.FromArgb(255, 255, 128)


                            btnMesa.BackgroundImageLayout = ImageLayout.Zoom

                            ' Posicionar el botón dentro del panel
                            btnMesa.Left = columna * (btnMesa.Width + espacioHorizontal)
                            btnMesa.Top = fila * (btnMesa.Height + espacioVertical)

                            AddHandler btnMesa.Click, AddressOf btnMesa_Click
                            pMesas.Controls.Add(btnMesa)
                            mesa += 1
                        Next
                    Next
                    ' Calcular el tamaño mínimo para habilitar el scroll si es necesario
                    Dim panelWidth As Integer = (cuantosColumnas * (btnWidth + espacioHorizontal)) + SystemInformation.VerticalScrollBarWidth
                    Dim panelHeight As Integer = (cuantosFilas * (btnHeight + espacioVertical))
                    pMesas.AutoScrollMinSize = New Size(panelWidth, panelHeight)
                Else
                    cnn1.Close() : cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "SELECT DISTINCT Nombre_mesa FROM mesa ORDER BY Nombre_mesa"
                    rd1 = cmd1.ExecuteReader
                    Do While rd1.Read
                        If rd1.HasRows Then
                            messa.Add(rd1.GetString("Nombre_mesa"))
                        End If
                    Loop
                    rd1.Close()
                    cnn1.Close()

                    Dim totalMesas As Double = ObtenerTotalMesas()
                    If totalMesas = 0 Then Exit Sub
                    Dim cuantosColumnas As Integer = Math.Ceiling(Math.Sqrt(totalMesas)) ' Calculamos el número de columnas necesarias
                    Dim cuantosFilas As Integer = Math.Ceiling(totalMesas / cuantosColumnas) ' Calculamos el número de filas necesarias

                    ' Tamaño fijo de los botones
                    Dim btnWidth As Integer = 140 ' Ancho fijo del botón
                    Dim btnHeight As Integer = 100 ' Alto fijo del botón

                    ' Espacio entre botones
                    Dim espacioHorizontal As Integer = 5
                    Dim espacioVertical As Integer = 5

                    pMesas.Controls.Clear() ' Limpiamos los controles existentes en el panel

                    For fila As Integer = 0 To cuantosFilas - 1
                        For columna As Integer = 0 To cuantosColumnas - 1
                            If mesa > totalMesas Then Exit For

                            Dim nombreMesa As String = messa(mesa - 1)

                            btnMesa = New Button
                            btnMesa.Text = nombreMesa
                            btnMesa.Width = btnWidth
                            btnMesa.Height = btnHeight
                            btnMesa.FlatStyle = FlatStyle.Flat
                            btnMesa.FlatAppearance.BorderSize = 0
                            btnMesa.Name = "btnMesa(" & nombreMesa & ")"
                            btnMesa.TextAlign = ContentAlignment.BottomCenter
                            btnMesa.BackColor = Color.FromArgb(255, 255, 128)


                            btnMesa.BackgroundImageLayout = ImageLayout.Zoom

                            ' Posicionar el botón dentro del panel
                            btnMesa.Left = columna * (btnMesa.Width + espacioHorizontal)
                            btnMesa.Top = fila * (btnMesa.Height + espacioVertical)

                            AddHandler btnMesa.Click, AddressOf btnMesa_Click
                            pMesas.Controls.Add(btnMesa)
                            mesa += 1
                        Next
                    Next
                    ' Calcular el tamaño mínimo para habilitar el scroll si es necesario
                    Dim panelWidth As Integer = (cuantosColumnas * (btnWidth + espacioHorizontal)) + SystemInformation.VerticalScrollBarWidth
                    Dim panelHeight As Integer = (cuantosFilas * (btnHeight + espacioVertical))
                    pMesas.AutoScrollMinSize = New Size(panelWidth, panelHeight)
                End If


            End If
            Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try


    End Sub
    Private Sub btnMesa_Click(sender As Object, e As EventArgs)

    End Sub

    Private Function ObtenerTotalMesas() As Integer
        Dim totalmesa2 As Double = 0
        Dim totalmesa3 As Double = 0
        Dim totaldemesas As Double = 0
        If mesaspropias = 1 Then
            If contrainicio = 1 Then
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT COUNT(Mesa) FROM Mesasxempleados  WHERE IdEmpleado=" & id_usu_log & ""
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        totalmesa2 = rd1(0).ToString

                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT COUNT(Nombre_mesa) FROM mesa WHERE IdEmpleado=0 AND Temporal=0"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        totalmesa3 = rd1(0).ToString
                    End If
                End If
                rd1.Close()
                cnn1.Close()

                totaldemesas = CDbl(totalmesa2) + CDbl(totalmesa3)
            Else
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT COUNT(Mesa) FROM Mesasxempleados  WHERE IdEmpleado=" & lblIdEmpleado.Text & ""
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        totalmesa2 = rd1(0).ToString

                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT COUNT(Nombre_mesa) FROM mesa WHERE IdEmpleado=0 AND Temporal=0"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        totalmesa3 = rd1(0).ToString
                    End If
                End If
                rd1.Close()
                cnn1.Close()

                totaldemesas = CDbl(totalmesa2) + CDbl(totalmesa3)
            End If

        Else
            If contrainicio = 1 Then
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT COUNT(Mesa) FROM Mesasxempleados  WHERE IdEmpleado=" & id_usu_log & ""
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        totalmesa2 = rd1(0).ToString

                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT COUNT(Nombre_mesa) FROM mesa WHERE IdEmpleado=0 AND Temporal=0"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        totalmesa3 = rd1(0).ToString
                    End If
                End If
                rd1.Close()
                cnn1.Close()

                totaldemesas = CDbl(totalmesa2) + CDbl(totalmesa3)
            Else
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT COUNT(Nombre_mesa) FROM mesa"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        totalmesa3 = rd1(0).ToString
                    End If
                End If
                rd1.Close()
                cnn1.Close()
                totaldemesas = totaldemesas + CDbl(totalmesa3)
            End If

        End If

        Return totaldemesas
    End Function

    Private Sub txtClave_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtClave.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT IdEmpleado,Alias FROM Usuarios WHERE Clave='" & txtClave.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    lblIdEmpleado.Text = rd1(0).ToString
                    lblUsuario.Text = rd1(1).ToString
                    id_usu_log = lblIdEmpleado.Text
                    CrearMesa()
                End If
            End If
            rd1.Close()
            cnn1.Close()

        End If
    End Sub
End Class
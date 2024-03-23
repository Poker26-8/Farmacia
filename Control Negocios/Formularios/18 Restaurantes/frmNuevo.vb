Public Class frmNuevo

    Friend WithEvents btnMesa As System.Windows.Forms.Button
    Dim btnaccion = New DataGridViewButtonColumn()
    Private Sub frmNuevo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Mesa()


        btnaccion.Name = "Eliminar"

        grdCaptura.Columns.Add(btnaccion)


        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "select distinct nombre_mesa from mesa"
        rd1 = cmd1.ExecuteReader
        Do While rd1.Read
            If rd1.HasRows Then

                grdCaptura.Rows.Add(rd1(0).ToString)
            End If
        Loop
        rd1.Close()
        cnn1.Close()




    End Sub

    Private Sub grdCaptura_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles grdCaptura.CellPainting
        btnaccion.Text = "delete"
    End Sub



    Public Sub Mesa()
        Try
            Dim mesa As Integer = 1
            Dim totalMesas As Double = ObtenerTotalMesas()
            Dim cuantosColumnas As Integer = Math.Ceiling(Math.Sqrt(totalMesas)) ' Calculamos el número de columnas necesarias
            Dim cuantosFilas As Integer = Math.Ceiling(totalMesas / cuantosColumnas) ' Calculamos el número de filas necesarias

            ' Tamaño fijo de los botones
            Dim btnWidth As Integer = 250 ' Ancho fijo del botón
            Dim btnHeight As Integer = 100 ' Alto fijo del botón

            ' Espacio entre botones
            Dim espacioHorizontal As Integer = 5
            Dim espacioVertical As Integer = 5

            pmesas.Controls.Clear() ' Limpiamos los controles existentes en el panel

            Dim nombre As New List(Of String)()

            cnn3.Close() : cnn3.Open()
            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "SELECT Nombre_mesa,TempNom,X,y,Tipo,IdEmpleado FROM Mesa order by Orden"
            rd3 = cmd3.ExecuteReader
            Do While rd3.Read
                If rd3.HasRows Then

                    nombre.Add(rd3.GetString("Nombre_mesa"))
                End If
            Loop
            rd3.Close()
            cnn3.Close()




            For fila As Integer = 0 To cuantosFilas - 1
                For columna As Integer = 0 To cuantosColumnas - 1
                    If mesa > totalMesas Then Exit For ' Si ya hemos agregado todas las mesas, salimos del bucle

                    ' Obtener el nombre de la mesa correspondiente
                    Dim nombreMesa As String = nombre(mesa - 1)

                    ' Obtener el nombre de la mesa
                    Dim btnMesa As New Button()


                    btnMesa.Text = nombreMesa
                    ' btnMesa.Width = pmesas.Width / cuantosColumnas ' Ancho del botón
                    'btnMesa.Height = pmesas.Height / cuantosFilas ' Alto del botón

                    btnMesa.Width = btnWidth ' Ancho del botón
                            btnMesa.Height = btnHeight ' Alto del botón

                            btnMesa.BackColor = Color.FromArgb(238, 220, 162)
                            btnMesa.FlatStyle = FlatStyle.Flat
                            btnMesa.FlatAppearance.BorderSize = 0
                    btnMesa.Name = "btnMesa(" & nombreMesa & ")"
                    btnMesa.TextAlign = ContentAlignment.BottomCenter
                            btnMesa.Font = New Font(btnMesa.Font, FontStyle.Bold)

                            ' Posicionar el botón dentro del panel
                            btnMesa.Left = columna * (btnMesa.Width + espacioHorizontal)
                            btnMesa.Top = fila * (btnMesa.Height + espacioVertical)

                            AddHandler btnMesa.Click, AddressOf btnMesa_Click
                            pmesas.Controls.Add(btnMesa)

                            mesa += 1


                Next
            Next

            ' Calcular el tamaño mínimo para habilitar el scroll si es necesario
            Dim panelWidth As Integer = (cuantosColumnas * (btnWidth + espacioHorizontal)) + SystemInformation.VerticalScrollBarWidth
            Dim panelHeight As Integer = (cuantosFilas * (btnHeight + espacioVertical))
            pmesas.AutoScrollMinSize = New Size(panelWidth, panelHeight)

            ' Ajustar el tamaño de la fuente de los botones cuando se crea el diseño inicial
            AjustarTamañoFuenteBotones()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Function ObtenerTotalMesas() As Integer
        ' Aquí implementa la lógica para obtener el total de mesas según la ubicación
        ' Por ejemplo, puedes ejecutar una consulta SQL similar a la que tenías en tu código original
        ' y devolver el número total de mesas
        Dim totalmesa2 As Double = 0

        cnn2.Close() : cnn2.Open()
        cmd2 = cnn2.CreateCommand
        cmd2.CommandText = "SELECT COUNT(Nombre_mesa) FROM Mesa"
        rd2 = cmd2.ExecuteReader
        If rd2.HasRows Then
            If rd2.Read Then
                totalmesa2 = rd2(0).ToString
            End If
        End If
        rd2.Close()
        cnn2.Close()

        Return totalmesa2
    End Function


    Private Sub btnMesa_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub frmNuevo_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Mesa()
        AjustarTamañoFuenteBotones()
    End Sub

    Private Sub AjustarTamañoFuenteBotones()
        ' Calcular el tamaño de la fuente en función del tamaño del formulario
        Dim factorReduccion As Double = 24 * (pmesas.Width / 800) ' Ajusta 24 según el tamaño base del formulario (800x600)

        ' Limitar el tamaño de la fuente mínimo y máximo
        If factorReduccion < 8 Then
            factorReduccion = 8
        ElseIf factorReduccion > 24 Then
            factorReduccion = 24
        End If

        ' Iterar a través de los controles del panel y ajustar el tamaño de la fuente de los botones
        For Each control As Control In pmesas.Controls
            If TypeOf control Is Button Then
                Dim boton As Button = CType(control, Button)
                boton.Font = New Font(boton.Font.FontFamily, CType(factorReduccion, Single))
            End If
        Next
    End Sub


End Class
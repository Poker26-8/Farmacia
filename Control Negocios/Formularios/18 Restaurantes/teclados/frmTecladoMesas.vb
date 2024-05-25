Imports iTextSharp.text

Public Class frmTecladoMesas

    Friend WithEvents btnMesaNM As System.Windows.Forms.Button
    Private Sub frmTecladoMesas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CrearBD_MesaNM()
    End Sub

    Public Sub CrearBD_MesaNM()
        Try
            Dim totmesas As Double = 0
            Dim messa As New List(Of String)()
            Dim mesa As Integer = 1

            If cboMesero.Text = "TODOS" Then

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT COUNT(Nombre_mesa) FROM Mesa"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        totmesas = rd1(0).ToString
                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Nombre_mesa FROM mesa order by Nombre_mesa "
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        messa.Add(rd1.GetString("Nombre_mesa"))
                    End If
                Loop
                rd1.Close()


                If totmesas = 0 Then Exit Sub
                Dim cuantosColumnas As Integer = Math.Ceiling(Math.Sqrt(totmesas)) ' Calculamos el número de columnas necesarias
                Dim cuantosFilas As Integer = Math.Ceiling(totmesas / cuantosColumnas) ' Calculamos el número de filas necesarias

                ' Tamaño fijo de los botones
                Dim btnWidth As Integer = 140 ' Ancho fijo del botón
                Dim btnHeight As Integer = 100 ' Alto fijo del botón

                ' Espacio entre botones
                Dim espacioHorizontal As Integer = 5
                Dim espacioVertical As Integer = 5


                For fila As Integer = 0 To cuantosFilas - 1
                    For columna As Integer = 0 To cuantosColumnas - 1
                        If mesa > totmesas Then Exit For ' Si ya hemos agregado todas las mesas, salimos del bucle

                        ' Obtener el nombre de la mesa correspondiente
                        Dim nombreMesa As String = messa(mesa - 1)

                        btnMesaNM = New Button
                        btnMesaNM.Text = nombreMesa
                        btnMesaNM.Width = btnWidth
                        btnMesaNM.Height = btnHeight
                        btnMesaNM.FlatStyle = FlatStyle.Flat
                        btnMesaNM.FlatAppearance.BorderSize = 0
                        btnMesaNM.Name = "btnMesa(" & nombreMesa & ")"
                        btnMesaNM.TextAlign = ContentAlignment.BottomCenter

                        btnMesaNM.BackColor = Color.FromArgb(251, 187, 64)





                        ' Posicionar el botón dentro del panel
                        btnMesaNM.Left = columna * (btnMesaNM.Width + espacioHorizontal)
                        btnMesaNM.Top = fila * (btnMesaNM.Height + espacioVertical)

                        AddHandler btnMesaNM.Click, AddressOf btnMesa_Click
                        pmesas.Controls.Add(btnMesaNM)
                        mesa += 1


                    Next
                Next
                cnn2.Close()


            Else

            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub btnMesa_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub cboMesero_DropDown(sender As Object, e As EventArgs) Handles cboMesero.DropDown
        Try
            cboMesero.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Alias FROM usuarios WHERE Puesto='MESERO' OR Puesto='ADMINISTRACIÓN' AND Alias<>'' ORDER BY Alias"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboMesero.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
End Class
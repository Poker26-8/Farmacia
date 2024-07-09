Imports iTextSharp.text

Public Class frmMadrid

    Friend WithEvents btnMesa As System.Windows.Forms.Button
    Dim mesaspropias As Integer = 0
    Dim contrainicio As Integer = 0

    Private Sub frmMadrid_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim equipos As New List(Of String) From {"America", "Toluca", "Cruz Azul", "Tigres", "Monterrey", "Queretaro", "Tijuana", "Mazatlan", "Necacxa"}
        Dim duelos As New List(Of Tuple(Of String, String))

        ' Asegurarse de que haya suficientes equipos para 17 duelos
        If equipos.Count < 4 Then
            MessageBox.Show("Se necesitan al menos 4 equipos para generar 17 duelos.")
            Return
        End If

        ' Generar los duelos
        While duelos.Count < 17
            Dim equipo1 = equipos(New Random().Next(equipos.Count))
            Dim equipo2 = equipos(New Random().Next(equipos.Count))

            ' Asegurarse de que los equipos no sean iguales y que el duelo no se repita
            If equipo1 <> equipo2 AndAlso Not duelos.Contains(New Tuple(Of String, String)(equipo1, equipo2)) AndAlso Not duelos.Contains(New Tuple(Of String, String)(equipo2, equipo1)) Then
                duelos.Add(New Tuple(Of String, String)(equipo1, equipo2))
            End If
        End While

        ' Mostrar los duelos
        Dim duelosString As String = ""
        For Each duelo In duelos
            duelosString &= duelo.Item1 & " vs " & duelo.Item2 & Environment.NewLine
        Next
        MessageBox.Show(duelosString)

    End Sub


End Class
Public Class frmpruebas
    Private Sub frmpruebas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim equipos As Integer = 18
        Dim jornadas As Integer = equipos - 1
        Dim mitadEquipos As Integer = equipos \ 2
        Dim calendario(jornadas - 1, mitadEquipos - 1) As Partido
        Dim horarios() As String = {"10:00 AM", "12:00 PM", "02:00 PM"}
        Dim canchas() As String = {"Cancha 1", "Cancha 2", "Cancha 3"}

        ' Crear lista de equipos
        Dim listaEquipos(equipos - 1) As String
        For i As Integer = 0 To equipos - 1
            listaEquipos(i) = "Equipo " & (i + 1).ToString()
        Next

        ' Generar calendario utilizando algoritmo Round-Robin
        For jornada As Integer = 0 To jornadas - 1

            ' Asignar horarios y canchas sin conflictos en cada jornada
            Dim horarioIndex As Integer = 0
            Dim canchaIndex As Integer = 0

            For partido As Integer = 0 To mitadEquipos - 1
                Dim equipoLocal As String = listaEquipos(partido)
                Dim equipoVisitante As String = listaEquipos(equipos - 1 - partido)

                ' Asignar horario y cancha
                Dim horario As String = horarios(horarioIndex)
                Dim cancha As String = canchas(canchaIndex)

                calendario(jornada, partido) = New Partido(equipoLocal, equipoVisitante, horario, cancha)

                ' Avanzar al siguiente horario y cancha
                horarioIndex += 1
                If horarioIndex >= horarios.Length Then
                    horarioIndex = 0
                    canchaIndex += 1
                    If canchaIndex >= canchas.Length Then
                        canchaIndex = 0
                    End If
                End If
            Next

            ' Rotar los equipos, dejando fijo al primero
            Dim ultimo As String = listaEquipos(equipos - 1)
            For i As Integer = equipos - 1 To 2 Step -1
                listaEquipos(i) = listaEquipos(i - 1)
            Next
            listaEquipos(1) = ultimo
        Next

        ' Configurar el DataGridView
        grd.ColumnCount = 5
        grd.Columns(0).Name = "Jornada"
        grd.Columns(1).Name = "Equipo Local"
        grd.Columns(2).Name = "Equipo Visitante"
        grd.Columns(3).Name = "Horario"
        grd.Columns(4).Name = "Cancha"

        ' Llenar el DataGridView con el calendario
        For jornada As Integer = 0 To jornadas - 1
            For partido As Integer = 0 To mitadEquipos - 1
                Dim jornadaString As String = (jornada + 1).ToString()
                Dim equipoLocal As String = calendario(jornada, partido).EquipoLocal
                Dim equipoVisitante As String = calendario(jornada, partido).EquipoVisitante
                Dim horario As String = calendario(jornada, partido).Horario
                Dim cancha As String = calendario(jornada, partido).Cancha
                grd.Rows.Add(jornadaString, equipoLocal, equipoVisitante, horario, cancha)
            Next
        Next
    End Sub


    Public Class Partido
        Public Property EquipoLocal As String
        Public Property EquipoVisitante As String
        Public Property Horario As String
        Public Property Cancha As String

        Public Sub New(equipoLocal As String, equipoVisitante As String, horario As String, cancha As String)
            Me.EquipoLocal = equipoLocal
            Me.EquipoVisitante = equipoVisitante
            Me.Horario = horario
            Me.Cancha = cancha
        End Sub

        Public Overrides Function ToString() As String
            Return $"{EquipoLocal} vs {EquipoVisitante} - {Horario} en {Cancha}"
        End Function
    End Class

End Class
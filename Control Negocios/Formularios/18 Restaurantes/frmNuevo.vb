Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmNuevo

    Friend WithEvents btnMesa As System.Windows.Forms.Button
    Dim btnaccion = New DataGridViewButtonColumn()
    Dim btnaccion2 = New DataGridViewTextBoxCell()
    Dim rowIndex As Integer = 0 ' 
    Private Sub frmNuevo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnPdf_Click(sender As Object, e As EventArgs) Handles btnPdf.Click

        Dim filePath As String = "C:\ControlNegociosPro\Archivos de importación\CATALOGO.txt"
        Dim lines As String() = IO.File.ReadAllLines(filePath)

        For Each line As String In lines
            Dim part1 As String = line.Substring(0, 13).Trim()
            Dim part2 As String = line.Substring(14, 35).Trim()
            Dim part3 As String = line.Substring(46, 52).Trim()
            Dim part4 As String = line.Substring(53, 61).Trim()
            Dim part5 As String = line.Substring(62, 58).Trim()

            Console.WriteLine($"Parte 1: {part1}")
            Console.WriteLine($"Parte 2: {part2}")
            Console.WriteLine($"Parte 3: {part3}")
            Console.WriteLine($"Parte 4: {part4}")
            Console.WriteLine($"Parte 5: {part5}")

            grdCaptura1.Rows.Add(part1, part2, part3, part4, part5)

        Next

    End Sub
End Class
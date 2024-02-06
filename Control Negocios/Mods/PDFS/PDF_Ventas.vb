Imports iTextSharp
Imports iTextSharp.text
Imports System
Imports System.Collections.Generic
Imports System.Threading.Tasks
Imports System.Linq
Imports iTextSharp.text.pdf
Imports MySql.Data

Public Class PDF_Ventas : Inherits PdfPageEventHelper
    Public Overrides Sub OnEndPage(writer As PdfWriter, document As Document)
        MyBase.OnEndPage(writer, document)
        Dim cb As PdfContentByte = writer.DirectContent
        Dim template As PdfTemplate = cb.CreateTemplate(document.PageSize.Width, 50)
        Dim pageN As Integer = writer.PageNumber
        Dim texto As String = "GENERADO CON UN SISTEMA DELSSCOM" & " Page " & pageN & "/"
        Dim bf As BaseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED)
        Dim len1 As Double = bf.GetWidthPoint(texto, 8)
        Dim pageSize1 As Rectangle = document.PageSize
        Dim PrintTime As DateTime = Now

        frmfacturacion.PintarLinea(1, 30, 32, 565, 32, writer)

        Dim Table7 As PdfPTable = New PdfPTable(3)
        Table7.WidthPercentage = 95
        Dim widths7 As Single() = New Single() {4.5F, 1.0F, 8.0F}
        Table7.SetWidths(widths7)
        Table7.TotalWidth = document.PageSize.Width - 55

        Dim Font8 As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.NORMAL))
        Dim Col1 As PdfPCell

        Font8.SetColor(192, 192, 192)

        Col1 = New PdfPCell(New Phrase("GENERADO CON UN SISTEMA DELSSCOM", Font8))
        Col1.Border = 0
        Table7.AddCell(Col1)

        Col1 = New PdfPCell(New Phrase("Página: " & writer.PageNumber.ToString, Font8))
        Col1.HorizontalAlignment = 2
        Col1.Border = 0
        Table7.AddCell(Col1)

        Table7.WriteSelectedRows(0, -1, document.LeftMargin + 13, 32, writer.DirectContent)
    End Sub
End Class

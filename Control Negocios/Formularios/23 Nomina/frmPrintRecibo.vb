
Imports CrystalDecisions.Shared
Imports MySql.Data
Public Class frmPrintRecibo

    Public nomina_id As String
    Public folio_nomina As String
    Public empleado_id As String
    Public param_cant_letra As String
    Public logo_empresa As String
    Private Sub frmPrintRecibo_Load(sender As Object, e As EventArgs) Handles MyBase.Load



    End Sub

    Public Sub ViewRecibo(ByVal root_name_recibo As String)

        'Dim sellocfd, folio_uuid, csd_emisor, csd_sat As String

        'Dim FileOpen As New ProcessStartInfo

        'Dim FileNomina As New GenerarPDF12

        'FileNomina.SetDatabaseLogon("", "jipl22n")

        ''FileNomina.RecordSelectionFormula = "{Nominas.nom_id} =" & 3 & " AND  " & "{Nominas.nom_razon_social}=" & "'" & empresa & "'" & " AND " & "{Nominas.nom_folio} =" & "'" & 2 & "'"

        'FileNomina.RecordSelectionFormula = "{Nominas.nom_id}=" & nomina_id1

        'sellos(folio_uuid, csd_emisor, csd_sat, sellocfd)

        'FileNomina.DataDefinition.FormulaFields("sello_cfd").Text = "'" & sellocfd & "'"
        'FileNomina.DataDefinition.FormulaFields("folio_fiscal_uuid").Text = "'" & folio_uuid & "'"
        '' FileNomina.DataDefinition.FormulaFields("csd_emisor").Text = "'" & csd_emisor & "'"
        'FileNomina.DataDefinition.FormulaFields("csd_sat").Text = "'" & csd_sat & "'"
        'FileNomina.DataDefinition.FormulaFields("cadena_pagos1").Text = "'" & cadena_pagos1 & "'"
        'FileNomina.Subreports("Deducciones.rpt").RecordSelectionFormula = "{detalle_nomina.id_empleado}=" & empleado_id & " AND " & "{detalle_nomina.id_nomina}=" & folio_nomina & " AND " & "{detalle_nomina.id_deduccion}<>''"
        'FileNomina.DataDefinition.FormulaFields("TipoInca").Text = "'" & frmNomina_Empleado.cboTipoInca.Text & "'"
        'FileNomina.DataDefinition.FormulaFields("DiasInca").Text = "'" & frmNomina_Empleado.txtDiasInc.Text & "'"
        'FileNomina.Subreports("Percepciones.rpt").RecordSelectionFormula = "{detalle_nomina.id_empleado}=" & empleado_id & " AND " & "{detalle_nomina.id_nomina}=" & folio_nomina & " AND " & "{detalle_nomina.id_percepcion}<>''"
        'FileNomina.Subreports("otrosp.rpt").RecordSelectionFormula = "{detalle_nomina.id_empleado}=" & empleado_id & " AND " & "{detalle_nomina.id_nomina}=" & folio_nomina & " AND " & "{detalle_nomina.id_otropago}<>''"

        'FileNomina.SetParameterValue("CantLetra", param_cant_letra)

        'crvReciboNomina.ReportSource = FileNomina

        'Try
        '    Dim CrExportOptions As ExportOptions
        '    Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
        '    Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()

        '    CrDiskFileDestinationOptions.DiskFileName = root_name_recibo  '"c:\crystalExport.pdf" '
        '    CrExportOptions = FileNomina.ExportOptions
        '    With CrExportOptions
        '        .ExportDestinationType = ExportDestinationType.DiskFile
        '        .ExportFormatType = ExportFormatType.PortableDocFormat
        '        .DestinationOptions = CrDiskFileDestinationOptions
        '        .FormatOptions = CrFormatTypeOptions
        '    End With

        '    FileNomina.Export()

        '    FileOpen.UseShellExecute = True
        '    FileOpen.FileName = root_name_recibo
        '    If vistarec = True Then
        '        Process.Start(FileOpen)
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub

    Private Sub sellos(ByRef folio_fiscal As String, ByRef sello_csd_emisor As String, ByRef sello_csd_sat As String, ByRef cfdi As String)

        Dim sinfo As String = ""
        Dim sSQL As String = "Select * from Nominas where nom_id=" & nomina_id1
        Dim dr As DataRow
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTargetlocal, sinfo) Then
            If odata.getDr(cnn, dr, sSQL, sinfo) Then
                folio_fiscal = dr("nom_folio_sat_uuid").ToString
                sello_csd_emisor = dr("nom_no_csd_emp").ToString
                sello_csd_sat = dr("nom_no_csd_sat").ToString
                cfdi = dr("nom_sello_emisor").ToString
            End If
            cnn.Close()
        End If
    End Sub
End Class
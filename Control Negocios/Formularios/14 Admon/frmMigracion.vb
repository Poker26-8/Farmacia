Imports System.Data.OleDb
Imports Microsoft.Office.Interop.Excel
Imports System.IO
Imports System.Net
Imports MySql.Data

Public Class frmMigracion
    Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
    Dim cmd As MySqlClient.MySqlCommand = New MySqlClient.MySqlCommand
    Dim rd As MySqlClient.MySqlDataReader = Nothing

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With opfbase
            .Filter = "Archivos de base de datos (*.mdb)|*.mdb"
            .Title = "Selecciona la base de datos de origen"
            .Multiselect = False
            .InitialDirectory = "C:\"
            .ShowDialog()
        End With

        If opfbase.FileName.ToString() <> "" Then
            TextBox1.Text() = opfbase.FileName.ToString()
            My.Application.DoEvents()
            If TextBox1.Text() <> "" Then
                Me.Size = New Size(221, 353)
                GroupBox1.Enabled = True
                cnn = New MySqlClient.MySqlConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & TextBox1.Text() & ";Persist Security Info=True;Jet OLEDB:Database Password=jipl22")
            Else
                MsgBox("No se seleccionó un archivo de base de datos.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                GroupBox1.Enabled = False
                Button1.Enabled = True
                Button1.Focus().Equals(True)
            End If
        End If
    End Sub

    Private Sub btnauto_Click(sender As System.Object, e As System.EventArgs) Handles btnauto.Click
        Dim cuantos As Double = 0
        Dim seccion As String = ""

        On Error GoTo queso
        'Primero hace una selección de registros para llenar el progress bar
        cnn.Close() : cnn.Open()
        '-- Clientes
        If (chClientes.Checked) Then
            cmd = cnn.CreateCommand
            cmd.CommandText =
                "select count(Id) from Clientes"
            rd = cmd.ExecuteReader
            If rd.HasRows Then
                If rd.Read Then
                    cuantos = cuantos + CDbl(rd(0).ToString())
                End If
            End If
            rd.Close()
        End If

        '-- Productos
        If (chProductos.Checked) Then
            cmd = cnn.CreateCommand
            cmd.CommandText =
                "select count(Codigo) from Productos"
            rd = cmd.ExecuteReader
            If rd.HasRows Then
                If rd.Read Then
                    cuantos = cuantos + CDbl(rd(0).ToString())
                End If
            End If
            rd.Close()
        End If

        '-- Proveedores
        If (chProveedores.Checked) Then
            cmd = cnn.CreateCommand
            cmd.CommandText =
                "select count(Id) from Proveedores"
            rd = cmd.ExecuteReader
            If rd.HasRows Then
                If rd.Read Then
                    cuantos = cuantos + CDbl(rd(0).ToString())
                End If
            End If
            rd.Close()
        End If

        '-- Usuarios
        If (chUsuarios.Checked) Then
            cmd = cnn.CreateCommand
            cmd.CommandText =
                "select count(idEmpleado) from Usuarios"
            rd = cmd.ExecuteReader
            If rd.HasRows Then
                If rd.Read Then
                    cuantos = cuantos + CDbl(rd(0).ToString())
                End If
            End If
            rd.Close()
        End If

        barmigra.Value = 0
        barmigra.Maximum = cuantos

        'Inica con clientes para hacer la migración de tablas
        If (chClientes.Checked) Then
            seccion = "Clientes"
            cmd = cnn.CreateCommand
            cmd.CommandText =
                "select * from Clientes order by Nombre"
            cnn1.Close() : cnn1.Open()
            rd = cmd.ExecuteReader
            Do While rd.Read
                If rd.HasRows Then
                    Dim nombre As String = UCase(NulCa(rd("Nombre").ToString()))
                    Dim razon As String = UCase(NulCa(rd("RazonSocial").ToString()))
                    Dim tipo_cl As String = NulCa(rd("Tipo").ToString())
                    Dim rfc As String = NulCa(rd("RFC").ToString())
                    Dim telefono As String = NulCa(rd("Telefono1").ToString())
                    Dim correo As String = NulCa(rd("ContactoMail").ToString())
                    Dim credito As Double = NulVa(rd("Credito").ToString())
                    Dim dias_cred As Double = NulVa(rd("DiasCredito").ToString())
                    Dim comisionista As String = NulCa(rd("Comisionista").ToString())
                    Dim suspender As Boolean = rd("SuspVent").ToString()
                    Dim calle As String = rd("Calle").ToString()
                    Dim colonia As String = rd("Colonia").ToString()
                    Dim cp As String = rd("CP").ToString()
                    Dim delegacion As String = rd("Delegacion").ToString()
                    Dim entidad As String = rd("Entidad").ToString()
                    Dim pais As String = rd("CPais").ToString()
                    Dim regfis As String = rd("Regfis").ToString()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into Clientes(Nombre,RazonSocial,Tipo,RFC,Telefono,Correo,Credito,DiasCred,Comisionista,Suspender,Calle,Colonia,CP,Delegacion,Entidad,Pais,RegFis) values('" & nombre & "','" & razon & "','" & tipo_cl & "','" & rfc & "','" & telefono & "','" & correo & "'," & credito & "," & dias_cred & ",'" & comisionista & "'," & suspender & ",'" & calle & "','" & colonia & "','" & cp & "','" & delegacion & "','" & entidad & "','" & pais & "','" & regfis & "')"
                    If cmd1.ExecuteNonQuery Then
                    Else
                        MsgBox("Ocurrió un error al migrar los datos del cliente " & nombre, vbCritical + vbOKOnly, "Delsscom Control Negocios Pro")
                    End If
                    barmigra.Value += 1
                End If
            Loop
            rd.Close()
            cnn1.Close()
        End If

        'Continua con proveedores
        If (chProveedores.Checked) Then
            seccion = "Proveedores"
            cmd = cnn.CreateCommand
            cmd.CommandText =
                "select * from Proveedores order by NComercial"
            cnn1.Close() : cnn1.Open()
            rd = cmd.ExecuteReader
            Do While rd.Read
                If rd.HasRows Then
                    Dim ncomercial As String = rd("NComercial").ToString()
                    Dim compañia As String = rd("Compañia").ToString()
                    Dim rfc As String = rd("RFC").ToString()
                    Dim curp As String = rd("CURP").ToString()
                    Dim calle As String = rd("Calle").ToString()
                    Dim colonia As String = rd("Colonia").ToString()
                    Dim cp As String = rd("CP").ToString()
                    Dim delegacion As String = rd("Delegacion").ToString()
                    Dim entidad As String = rd("EntFed").ToString()
                    Dim telefono As String = rd("Tel1").ToString()
                    Dim mail As String = rd("Email").ToString()
                    Dim saldo As Double = NulVa(rd("Saldo").ToString())
                    Dim credito As Double = NulVa(rd("Credito").ToString())
                    Dim dias_cred As Double = NulVa(rd("DiasCredito").ToString())

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into Proveedores(NComercial,Compania,RFC,CURP,Calle,Colonia,CP,Delegacion,Entidad,Telefono,Facebook,Correo,Saldo,Credito,DiasCred) values('" & ncomercial & "','" & compañia & "','" & rfc & "','" & curp & "','" & calle & "','" & colonia & "','" & cp & "','" & delegacion & "','" & entidad & "','" & telefono & "','','" & mail & "'," & saldo & "," & credito & "," & dias_cred & ")"
                    If cmd1.ExecuteNonQuery Then
                    Else
                        MsgBox("Ocurrió un error al migrar los datos del proveedor " & ncomercial, vbCritical + vbOKOnly, "Delsscom Control Negocios Pro")
                    End If
                    barmigra.Value += 1
                End If
            Loop
            rd.Close()
            cnn1.Close()
        End If

        'Continua con los productos
        If (chProductos.Checked) Then
            seccion = "Productos"
            cmd = cnn.CreateCommand
            cmd.CommandText =
                "select * from Productos order by Nombre"
            rd = cmd.ExecuteReader
            cnn1.Close() : cnn1.Open()
            Do While rd.Read
                If rd.HasRows Then
                    'Datos generales
                    Dim codigo As String = NulCa(rd("Codigo").ToString())
                    Dim barras As String = NulCa(rd("CodBarra").ToString())
                    Dim nombre1 As String = NulCa(rd("Nombre").ToString())
                    Dim provee As String = rd("ProvPri").ToString()
                    Dim kits As Boolean = IIf(rd("ProvRes").ToString() = True, False, True)
                    Dim ucompra As String = rd("UCompra").ToString()
                    Dim uventa As String = rd("UVenta").ToString()
                    Dim uminima As String = rd("VentaMin").ToString()
                    Dim mcd As Double = NulVa(rd("MCD").ToString())
                    Dim multi As Double = NulVa(redCont("Multiplo").ToString())
                    Dim depto As String = rd("Departamento").ToString()
                    Dim grupo As String = rd("Grupo").ToString()
                    Dim ubicacion As String = rd("Ubicacion").ToString()
                    Dim min As Double = rd("Min").ToString()
                    Dim max As Double = rd("Max").ToString()
                    Dim comision As Double = rd("Comision").ToString()
                    Dim preciocompra As Double = rd("PrecioCompra").ToString()
                    Dim precioventa As Double = rd("PrecioVenta").ToString()
                    Dim precioventaiva As Double = rd("PrecioVentaIVA").ToString()
                    Dim porcentajemin As Double = rd("PorcentageMin").ToString()
                    Dim preciomin As Double = rd("PecioVentaMinIVA").ToString()
                    Dim IVA As Double = rd("IVA").ToString()
                    Dim existencia As Double = rd("Existencia").ToString()
                    Dim porcentaje As Double = rd("Porcentage").ToString()
                    Dim fecha As String = Format(Date.Now, "yyyy-MM-dd").ToString()
                    'Precios especiales
                    Dim porcentajemay As Double = NulVa(rd("PorMay").ToString())
                    Dim porcentajemm As Double = NulVa(rd("PorMM").ToString())
                    Dim porcentajeesp As Double = NulVa(rd("PorEsp").ToString())
                    Dim preciomey As Double = NulVa(rd("PreMay").ToString())
                    Dim preciomm As Double = NulVa(rd("PreMM").ToString())
                    Dim precioesp As Double = NulVa(rd("PreEsp").ToString())
                    Dim cantidadmin1 As Double = NulVa(rd("CantMin").ToString())
                    Dim cantidadmin2 As Double = NulVa(rd("CantMin2").ToString())
                    Dim cantidadmay1 As Double = NulVa(rd("CantMay").ToString())
                    Dim cantidadmay2 As Double = NulVa(rd("CantMay2").ToString())
                    Dim cantidadmm1 As Double = NulVa(rd("CantMM").ToString())
                    Dim cantidadmm2 As Double = NulVa(rd("CantMM2").ToString())
                    Dim cantidadesp1 As Double = NulVa(rd("CantEsp").ToString())
                    Dim cantidadesp2 As Double = NulVa(rd("CantEsp2").ToString())
                    Dim cantidadlta1 As Double = NulVa(rd("CantLta").ToString())
                    Dim cantidadlta2 As Double = NulVa(rd("CantLta2").ToString())
                    Dim preciosespeciales As Boolean = rd("pres_vol").ToString()
                    'Datos de configuración
                    Dim idmoneda As Double = rd("id_tbMoneda").ToString()
                    Dim descto As Double = rd("Dscto").ToString()
                    Dim afectaexistencia As Boolean = rd("AFECTA_EXISTENCIA").ToString()
                    Dim porcientoiva As Double = NulVa(rd("PercentIVAret").ToString())
                    Dim iieps As Double = NulVa(rd("IIEPS").ToString())
                    Dim irs As Double = NulVa(rd("isr").ToString())
                    Dim clavesat As String = rd("ClavaSat").ToString()
                    Dim unidadsat As String = rd("ClaveUnidadSat").ToString()
                    Dim statuspromo As Boolean = rd("Status_Promocion").ToString()
                    Dim porcentajepromo As Double = rd("Porcentaje_Promo").ToString()
                    'Adicional
                    Dim uso As String = rd("Uso").ToString()
                    Dim color As String = rd("Color").ToString()
                    Dim genero As String = rd("Genero").ToString()
                    Dim marca As String = rd("Marca").ToString()
                    Dim articulo As String = rd("Articulo").ToString()
                    Dim dia As Double = rd("Dia").ToString()
                    Dim descu As Double = rd("Descu").ToString()                    

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into Productos(Codigo,CodBarra,Nombre,NombreLargo,ProvPri,ProvEme,ProvRes,UCompra,UVenta,UMinima,MCD,Multiplo,Departamento,Grupo,Ubicacion,[Min],[Max],Comision,PrecioCompra,PrecioVenta,PrecioVentaIVA,PorcMin,PreMin,IVA,Existencia,Porcentaje,Fecha,PorcMay,PorcMM,PorcEsp,PreMay,PreMM,PreEsp,CantMin1,CantMin2,CantMay1,CantMay2,CantMM1,CantMM2,CantEsp1,CantEsp2,CantLst1,CantLst2,pres_vol,id_tbMoneda,Promocion,Descto,Afecta_exis,PercentIVAret,Almacen3,IIEPS,ISR,ClaveSat,UnidadSat,Uso,Color,Genero,Marca,Articulo,Dia,Descu,Status_Promocion,Porcentaje_Promo,Fecha_Inicial,Fecha_Final) values('" & codigo & "','" & barras & "','" & nombre1 & "','" & nombre1 & "','" & provee & "','" & provee & "'," & kits & ",'" & ucompra & "','" & uventa & "','" & uminima & "'," & mcd & "," & multi & ",'" & depto & "','" & grupo & "','" & ubicacion & "'," & min & "," & max & "," & comision & "," & preciocompra & "," & precioventa & "," & precioventaiva & "," & porcentajemin & "," & preciomin & "," & IVA & "," & existencia & "," & porcentaje & ",'" & fecha & "'," & porcentajemay & "," & porcentajemm & "," & porcentajeesp & "," & preciomey & "," & preciomm & "," & precioesp & "," & cantidadmin1 & "," & cantidadmin2 & "," & cantidadmay1 & "," & cantidadmay2 & "," & cantidadmm1 & "," & cantidadmm2 & "," & cantidadesp1 & "," & cantidadesp2 & "," & cantidadlta1 & "," & cantidadlta2 & "," & preciosespeciales & "," & idmoneda & ",0," & descto & "," & afectaexistencia & "," & porcientoiva & "," & preciocompra & "," & iieps & "," & irs & ",'" & clavesat & "','" & unidadsat & "','" & uso & "','" & color & "','" & genero & "','" & marca & "','" & articulo & "'," & dia & ",'" & descu & "'," & statuspromo & "," & porcentajepromo & ",'" & fecha & "','" & fecha & "')"
                    If cmd1.ExecuteNonQuery Then
                    Else
                        MsgBox("Ocurrió un error al migrar los datos del producto " & nombre1, vbCritical + vbOKOnly, "Delsscom Control Negocios Pro")
                    End If
                    barmigra.Value += 1
                End If
            Loop
            cnn1.Close()
            rd.Close()
        End If

        'Termina con usuarios
        If (chUsuarios.Checked) Then
            seccion = "Usuarios"
            cmd = cnn.CreateCommand
            cmd.CommandText =
                "select * from Usuarios"
            cnn1.Close() : cnn1.Open()
            cnn2.Close() : cnn2.Open()
            rd = cmd.ExecuteReader
            Do While rd.Read
                If rd.HasRows Then
                    Dim nombre As String = rd("Nombre").ToString()
                    Dim alias_u As String = rd("Alias").ToString()
                    Dim area As String = rd("Area").ToString()
                    Dim puesto As String = rd("Puesto").ToString()
                    Dim nss As String = rd("ClaveIMSS").ToString()
                    Dim clave As String = rd("Clave").ToString()
                    Dim ingreso As String = Format(CDate(rd("FechaIngreso").ToString()), "yyyy-MM-dd")
                    Dim sueldo As Double = rd("Sueldo").ToString()
                    Dim comisionista As Boolean = rd("Comisionista").ToString()
                    Dim calle As String = rd("CalleyNum").ToString()
                    Dim colonia As String = rd("Colonia").ToString()
                    Dim cp As String = rd("CP").ToString()
                    Dim delegacion As String = rd("Delegacion").ToString()
                    Dim entidad As String = rd("Entidad").ToString()
                    Dim telefono As String = rd("Cel").ToString()
                    Dim correo As String = rd("Email").ToString()
                    Dim estado As String = rd("Status").ToString()

                    If alias_u = "ADMIN" Then
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "select * from Usuarios where Alias='ADMIN'"
                        rd = cmd.ExecuteReader
                        If rd.HasRows Then
                            If rd.Read Then
                                cmd2 = cnn2.CreateCommand
                                cmd2.CommandText =
                                    "update Usuarios set Clave='" & clave & "' where Alias='ADMIN'"
                                cmd2.ExecuteNonQuery()
                            End If
                        End If
                        rd.Close()
                    Else
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "insert into Usuarios(Nombre,Alias,Area,Puesto,NSS,Clave,Ingreso,Sueldo,Comisionista,Calle,Colonia,CP,Delegacion,Entidad,Telefono,Facebook,Correo,Status,Cargado,Template) values('" & nombre & "','" & alias_u & "','" & area & "','" & puesto & "','" & nss & "','" & clave & "','" & ingreso & "'," & sueldo & "," & comisionista & ",'" & calle & "','" & colonia & "','" & cp & "','" & delegacion & "','" & entidad & "','" & telefono & "','','" & correo & "','" & estado & "',0,0)"
                        If cmd1.ExecuteNonQuery Then
                        Else
                            MsgBox("Ocurrió un error al migrar los datos del usuario " & nombre, vbCritical + vbOKOnly, "Delsscom Control Negocios Pro")
                        End If
                    End If
                    barmigra.Value += 1
                End If
            Loop
            rd.Close()
            cnn1.Close() : cnn2.Close()
        End If
        cnn.Close()

        cnn1.Close() : cnn1.Open()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "update Formatos set NotasCred='" & Format(Date.Now, "dd/MM/yyyy") & "', NumPart=1 where Facturas='Migracion'"
        If cmd.ExecuteNonQuery Then
            MsgBox("Migración de datos realizada correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
        End If

        cnn1.Close()

        Exit Sub
queso:
        MsgBox(seccion & " - " & Err.Number & " - " & Err.Description & vbNewLine & "No se pudo completar la migración, inténtalo de nuevo más tarde. De persistir el problema comunícate con tu proveedor de software.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
        cnn.Close()
        Exit Sub
    End Sub

    Public Function NulCa(ByVal cadena As String) As String
        If IsDBNull(cadena) Then
            NulCa = ""
        Else
            NulCa = cadena
        End If
    End Function

    Public Function NulVa(ByVal valor As Double) As Double
        If IsDBNull(valor) Then
            NulVa = 0
        Else
            NulVa = valor
        End If
    End Function

    Private Sub btnmanual_Click(sender As System.Object, e As System.EventArgs) Handles btnmanual.Click
        Dim cuantos As Double = 0
        Dim seccion As String = ""

        On Error GoTo caca

        cnn.Close() : cnn.Open()

        If (chClientes.Checked) Then
            'Selecciona el número de registros en [Clientes]
            cmd = cnn.CreateCommand
            cmd.CommandText =
                "select count(Id) from Clientes"
            rd = cmd.ExecuteReader
            If rd.HasRows Then
                If rd.Read Then
                    cuantos = rd(0).ToString()
                End If
            End If
            rd.Close()

            'Configura el grid para los campos de [Clientes]
            grdBase.ColumnCount = 0
            grdBase.Rows.Clear()
            grdBase.ColumnCount = 16
            With grdBase
                With .Columns(0)
                    .HeaderText = "Nombre del cliente"
                    .Width = 250
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
                    .Resizable = DataGridViewTriState.False
                End With

            End With

            cmd = cnn.CreateCommand
            cmd.CommandText =
                "select * from Clientes"
            rd = cmd.ExecuteReader
            Do While rd.Read
                If rd.HasRows Then
                    Dim nombre As String = rd("Cliente").ToString()
                    Dim razon As String = rd("RazonSocial").ToString()
                    Dim tipo As String = rd("Tipo").ToString()
                    Dim rfc As String = rd("RFC").ToString()
                    Dim telefono As String = rd("Cel").ToString()
                    Dim correo As String = rd("Email").ToString()
                    Dim credito As Double = rd("Credito").ToString()
                    Dim dias As Double = rd("DiasCred").ToString()
                    Dim comision As String = rd("Comisionista").ToString()
                    Dim suspende As Boolean = rd("Suspender").ToString()
                    Dim calle As String = rd("Calle").ToString()
                    Dim colonia As String = rd("Colonia").ToString()
                    Dim cp As String = rd("CP").ToString()
                    Dim delega As String = rd("Delegacion").ToString()
                    Dim entidad As String = rd("Entidad").ToString()
                    Dim pais As String = rd("CPais").ToString()

                    grdBase.Rows.Add()
                End If
            Loop
            rd.Close()


        End If
        cnn.Close()

caca:
        MsgBox(seccion & " - " & Err.Number & " - " & Err.Description & vbNewLine & "No se pudo completar la migración de datos, inténtelo de nuevo más tarde. Sí el problema persiste comuníquese con su proveedor de software.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
        cnn.Close() : cnn1.Close() : cnn2.Close()
        Exit Sub
    End Sub
End Class
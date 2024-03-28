<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPreciosBarras
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPreciosBarras))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtIva = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtBarras3 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtBarras2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtbarras = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnGP = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.txtPrecio10 = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtPrecio9 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtPrecio8 = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtPrecio7 = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtPrecio6 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtPrecio5 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtPrecio4 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtPrecio3 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPrecio2 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPrecio1 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(608, 30)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txtIva)
        Me.Panel2.Controls.Add(Me.txtNombre)
        Me.Panel2.Controls.Add(Me.txtCodigo)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 30)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(608, 61)
        Me.Panel2.TabIndex = 1
        '
        'txtIva
        '
        Me.txtIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIva.Location = New System.Drawing.Point(519, 27)
        Me.txtIva.Name = "txtIva"
        Me.txtIva.Size = New System.Drawing.Size(85, 24)
        Me.txtIva.TabIndex = 189
        '
        'txtNombre
        '
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.Location = New System.Drawing.Point(91, 27)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(424, 24)
        Me.txtNombre.TabIndex = 188
        '
        'txtCodigo
        '
        Me.txtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(3, 27)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(85, 24)
        Me.txtCodigo.TabIndex = 187
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(519, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 21)
        Me.Label4.TabIndex = 186
        Me.Label4.Text = "IVA (0, 0.16)"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(91, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(424, 21)
        Me.Label2.TabIndex = 184
        Me.Label2.Text = "Descripción corta para ticket"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(3, 3)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(85, 21)
        Me.Label12.TabIndex = 182
        Me.Label12.Text = "Código"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.txtBarras3)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.txtBarras2)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.txtbarras)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 91)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(608, 94)
        Me.Panel3.TabIndex = 2
        '
        'txtBarras3
        '
        Me.txtBarras3.BackColor = System.Drawing.Color.White
        Me.txtBarras3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBarras3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarras3.Location = New System.Drawing.Point(133, 61)
        Me.txtBarras3.Name = "txtBarras3"
        Me.txtBarras3.Size = New System.Drawing.Size(471, 23)
        Me.txtBarras3.TabIndex = 188
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(3, 61)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(124, 23)
        Me.Label5.TabIndex = 187
        Me.Label5.Text = "Código de Barras"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtBarras2
        '
        Me.txtBarras2.BackColor = System.Drawing.Color.White
        Me.txtBarras2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBarras2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarras2.Location = New System.Drawing.Point(133, 32)
        Me.txtBarras2.Name = "txtBarras2"
        Me.txtBarras2.Size = New System.Drawing.Size(471, 23)
        Me.txtBarras2.TabIndex = 186
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(3, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(124, 23)
        Me.Label3.TabIndex = 185
        Me.Label3.Text = "Código de Barras"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtbarras
        '
        Me.txtbarras.BackColor = System.Drawing.Color.White
        Me.txtbarras.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtbarras.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbarras.Location = New System.Drawing.Point(133, 3)
        Me.txtbarras.Name = "txtbarras"
        Me.txtbarras.Size = New System.Drawing.Size(471, 23)
        Me.txtbarras.TabIndex = 184
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 23)
        Me.Label1.TabIndex = 183
        Me.Label1.Text = "Código de Barras"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnSalir)
        Me.Panel4.Controls.Add(Me.btnGP)
        Me.Panel4.Controls.Add(Me.btnNuevo)
        Me.Panel4.Controls.Add(Me.txtPrecio10)
        Me.Panel4.Controls.Add(Me.Label18)
        Me.Panel4.Controls.Add(Me.txtPrecio9)
        Me.Panel4.Controls.Add(Me.Label13)
        Me.Panel4.Controls.Add(Me.txtPrecio8)
        Me.Panel4.Controls.Add(Me.Label14)
        Me.Panel4.Controls.Add(Me.txtPrecio7)
        Me.Panel4.Controls.Add(Me.Label15)
        Me.Panel4.Controls.Add(Me.txtPrecio6)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.txtPrecio5)
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Controls.Add(Me.txtPrecio4)
        Me.Panel4.Controls.Add(Me.Label11)
        Me.Panel4.Controls.Add(Me.txtPrecio3)
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Controls.Add(Me.txtPrecio2)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.txtPrecio1)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 185)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(608, 184)
        Me.Panel4.TabIndex = 3
        '
        'btnSalir
        '
        Me.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = Global.Control_Negocios.My.Resources.Resources.salir
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSalir.Location = New System.Drawing.Point(540, 110)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(60, 63)
        Me.btnSalir.TabIndex = 243
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnGP
        '
        Me.btnGP.BackgroundImage = CType(resources.GetObject("btnGP.BackgroundImage"), System.Drawing.Image)
        Me.btnGP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnGP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGP.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGP.Location = New System.Drawing.Point(408, 110)
        Me.btnGP.Name = "btnGP"
        Me.btnGP.Size = New System.Drawing.Size(60, 63)
        Me.btnGP.TabIndex = 242
        Me.btnGP.Text = "Guardar"
        Me.btnGP.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGP.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.BackgroundImage = CType(resources.GetObject("btnNuevo.BackgroundImage"), System.Drawing.Image)
        Me.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevo.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Location = New System.Drawing.Point(474, 110)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(60, 63)
        Me.btnNuevo.TabIndex = 241
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'txtPrecio10
        '
        Me.txtPrecio10.BackColor = System.Drawing.Color.White
        Me.txtPrecio10.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrecio10.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecio10.Location = New System.Drawing.Point(104, 110)
        Me.txtPrecio10.Name = "txtPrecio10"
        Me.txtPrecio10.Size = New System.Drawing.Size(95, 25)
        Me.txtPrecio10.TabIndex = 236
        Me.txtPrecio10.Text = "0.00"
        Me.txtPrecio10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label18.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(3, 110)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(98, 25)
        Me.Label18.TabIndex = 235
        Me.Label18.Text = "P. Venta con IVA"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPrecio9
        '
        Me.txtPrecio9.BackColor = System.Drawing.Color.White
        Me.txtPrecio9.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrecio9.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecio9.Location = New System.Drawing.Point(505, 76)
        Me.txtPrecio9.Name = "txtPrecio9"
        Me.txtPrecio9.Size = New System.Drawing.Size(95, 25)
        Me.txtPrecio9.TabIndex = 234
        Me.txtPrecio9.Text = "0.00"
        Me.txtPrecio9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(405, 76)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(98, 25)
        Me.Label13.TabIndex = 233
        Me.Label13.Text = "P. Venta con IVA"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPrecio8
        '
        Me.txtPrecio8.BackColor = System.Drawing.Color.White
        Me.txtPrecio8.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrecio8.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecio8.Location = New System.Drawing.Point(305, 76)
        Me.txtPrecio8.Name = "txtPrecio8"
        Me.txtPrecio8.Size = New System.Drawing.Size(95, 25)
        Me.txtPrecio8.TabIndex = 232
        Me.txtPrecio8.Text = "0.00"
        Me.txtPrecio8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(204, 76)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(98, 25)
        Me.Label14.TabIndex = 231
        Me.Label14.Text = "P. Venta con IVA"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPrecio7
        '
        Me.txtPrecio7.BackColor = System.Drawing.Color.White
        Me.txtPrecio7.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrecio7.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecio7.Location = New System.Drawing.Point(104, 76)
        Me.txtPrecio7.Name = "txtPrecio7"
        Me.txtPrecio7.Size = New System.Drawing.Size(95, 25)
        Me.txtPrecio7.TabIndex = 230
        Me.txtPrecio7.Text = "0.00"
        Me.txtPrecio7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(3, 76)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(98, 25)
        Me.Label15.TabIndex = 229
        Me.Label15.Text = "P. Venta con IVA"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPrecio6
        '
        Me.txtPrecio6.BackColor = System.Drawing.Color.White
        Me.txtPrecio6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrecio6.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecio6.Location = New System.Drawing.Point(505, 40)
        Me.txtPrecio6.Name = "txtPrecio6"
        Me.txtPrecio6.Size = New System.Drawing.Size(95, 25)
        Me.txtPrecio6.TabIndex = 228
        Me.txtPrecio6.Text = "0.00"
        Me.txtPrecio6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(405, 40)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 25)
        Me.Label9.TabIndex = 227
        Me.Label9.Text = "P. Venta con IVA"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPrecio5
        '
        Me.txtPrecio5.BackColor = System.Drawing.Color.White
        Me.txtPrecio5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrecio5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecio5.Location = New System.Drawing.Point(305, 40)
        Me.txtPrecio5.Name = "txtPrecio5"
        Me.txtPrecio5.Size = New System.Drawing.Size(95, 25)
        Me.txtPrecio5.TabIndex = 226
        Me.txtPrecio5.Text = "0.00"
        Me.txtPrecio5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(204, 40)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(98, 25)
        Me.Label10.TabIndex = 225
        Me.Label10.Text = "P. Venta con IVA"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPrecio4
        '
        Me.txtPrecio4.BackColor = System.Drawing.Color.White
        Me.txtPrecio4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrecio4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecio4.Location = New System.Drawing.Point(104, 40)
        Me.txtPrecio4.Name = "txtPrecio4"
        Me.txtPrecio4.Size = New System.Drawing.Size(95, 25)
        Me.txtPrecio4.TabIndex = 224
        Me.txtPrecio4.Text = "0.00"
        Me.txtPrecio4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(3, 40)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(98, 25)
        Me.Label11.TabIndex = 223
        Me.Label11.Text = "P. Venta con IVA"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPrecio3
        '
        Me.txtPrecio3.BackColor = System.Drawing.Color.White
        Me.txtPrecio3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrecio3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecio3.Location = New System.Drawing.Point(505, 5)
        Me.txtPrecio3.Name = "txtPrecio3"
        Me.txtPrecio3.Size = New System.Drawing.Size(95, 25)
        Me.txtPrecio3.TabIndex = 222
        Me.txtPrecio3.Text = "0.00"
        Me.txtPrecio3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(405, 5)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 25)
        Me.Label7.TabIndex = 221
        Me.Label7.Text = "P. Venta con IVA"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPrecio2
        '
        Me.txtPrecio2.BackColor = System.Drawing.Color.White
        Me.txtPrecio2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrecio2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecio2.Location = New System.Drawing.Point(305, 5)
        Me.txtPrecio2.Name = "txtPrecio2"
        Me.txtPrecio2.Size = New System.Drawing.Size(95, 25)
        Me.txtPrecio2.TabIndex = 220
        Me.txtPrecio2.Text = "0.00"
        Me.txtPrecio2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(204, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 25)
        Me.Label6.TabIndex = 219
        Me.Label6.Text = "P. Venta con IVA"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPrecio1
        '
        Me.txtPrecio1.BackColor = System.Drawing.Color.White
        Me.txtPrecio1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrecio1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecio1.Location = New System.Drawing.Point(104, 5)
        Me.txtPrecio1.Name = "txtPrecio1"
        Me.txtPrecio1.Size = New System.Drawing.Size(95, 25)
        Me.txtPrecio1.TabIndex = 218
        Me.txtPrecio1.Text = "0.00"
        Me.txtPrecio1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(3, 5)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(98, 25)
        Me.Label8.TabIndex = 193
        Me.Label8.Text = "P. Venta con IVA"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmPreciosBarras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(608, 369)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPreciosBarras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Precios Cod Barras"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents txtBarras3 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtBarras2 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtbarras As TextBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents txtPrecio10 As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtPrecio9 As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtPrecio8 As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtPrecio7 As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtPrecio6 As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtPrecio5 As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtPrecio4 As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtPrecio3 As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtPrecio2 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtPrecio1 As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnGP As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents txtCodigo As TextBox
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents txtIva As TextBox
End Class

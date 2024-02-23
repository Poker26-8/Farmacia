<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAlumnos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAlumnos))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboNombre = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboMatricula = New System.Windows.Forms.ComboBox()
        Me.txttelefono = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtcp = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtestado = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtdelegacion = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtcolonia = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtnext = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtnint = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtcalle = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtcontacto = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txttutor = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.optsabado = New System.Windows.Forms.CheckBox()
        Me.optviernes = New System.Windows.Forms.CheckBox()
        Me.optjueves = New System.Windows.Forms.CheckBox()
        Me.optmiercoles = New System.Windows.Forms.CheckBox()
        Me.optmartes = New System.Windows.Forms.CheckBox()
        Me.optlunes = New System.Windows.Forms.CheckBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txthorario = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtinscripcion = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnlimpiar = New System.Windows.Forms.Button()
        Me.btneliminar = New System.Windows.Forms.Button()
        Me.txtgrupo = New System.Windows.Forms.ComboBox()
        Me.btnguardar = New System.Windows.Forms.Button()
        Me.lblusuario = New System.Windows.Forms.Label()
        Me.txtcontraseña = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.LBLID = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Historic", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.Label1.Size = New System.Drawing.Size(499, 31)
        Me.Label1.TabIndex = 4
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 15)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Nombre:"
        '
        'cboNombre
        '
        Me.cboNombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cboNombre.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboNombre.FormattingEnabled = True
        Me.cboNombre.Location = New System.Drawing.Point(72, 42)
        Me.cboNombre.Name = "cboNombre"
        Me.cboNombre.Size = New System.Drawing.Size(419, 23)
        Me.cboNombre.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 15)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Matricula:"
        '
        'cboMatricula
        '
        Me.cboMatricula.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cboMatricula.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMatricula.FormattingEnabled = True
        Me.cboMatricula.Location = New System.Drawing.Point(72, 69)
        Me.cboMatricula.Name = "cboMatricula"
        Me.cboMatricula.Size = New System.Drawing.Size(186, 23)
        Me.cboMatricula.TabIndex = 11
        '
        'txttelefono
        '
        Me.txttelefono.BackColor = System.Drawing.Color.White
        Me.txttelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txttelefono.Location = New System.Drawing.Point(327, 69)
        Me.txttelefono.Name = "txttelefono"
        Me.txttelefono.Size = New System.Drawing.Size(164, 23)
        Me.txttelefono.TabIndex = 66
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(266, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 15)
        Me.Label5.TabIndex = 65
        Me.Label5.Text = "Teléfono:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtcp)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.txtestado)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.txtdelegacion)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.txtcolonia)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txtnext)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.txtnint)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtcalle)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtcontacto)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txttutor)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 101)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(483, 211)
        Me.GroupBox2.TabIndex = 67
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos de contacto"
        '
        'txtcp
        '
        Me.txtcp.BackColor = System.Drawing.Color.White
        Me.txtcp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcp.Location = New System.Drawing.Point(399, 151)
        Me.txtcp.Name = "txtcp"
        Me.txtcp.Size = New System.Drawing.Size(76, 23)
        Me.txtcp.TabIndex = 83
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(368, 155)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(25, 15)
        Me.Label19.TabIndex = 82
        Me.Label19.Text = "CP:"
        '
        'txtestado
        '
        Me.txtestado.BackColor = System.Drawing.Color.White
        Me.txtestado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtestado.Location = New System.Drawing.Point(333, 177)
        Me.txtestado.Name = "txtestado"
        Me.txtestado.Size = New System.Drawing.Size(142, 23)
        Me.txtestado.TabIndex = 81
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(282, 181)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(45, 15)
        Me.Label16.TabIndex = 80
        Me.Label16.Text = "Estado:"
        '
        'txtdelegacion
        '
        Me.txtdelegacion.BackColor = System.Drawing.Color.White
        Me.txtdelegacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdelegacion.Location = New System.Drawing.Point(81, 177)
        Me.txtdelegacion.Name = "txtdelegacion"
        Me.txtdelegacion.Size = New System.Drawing.Size(195, 23)
        Me.txtdelegacion.TabIndex = 79
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(7, 181)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(69, 15)
        Me.Label15.TabIndex = 78
        Me.Label15.Text = "Delegación:"
        '
        'txtcolonia
        '
        Me.txtcolonia.BackColor = System.Drawing.Color.White
        Me.txtcolonia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcolonia.Location = New System.Drawing.Point(81, 151)
        Me.txtcolonia.Name = "txtcolonia"
        Me.txtcolonia.Size = New System.Drawing.Size(281, 23)
        Me.txtcolonia.TabIndex = 77
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(7, 155)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(51, 15)
        Me.Label14.TabIndex = 76
        Me.Label14.Text = "Colonia:"
        '
        'txtnext
        '
        Me.txtnext.BackColor = System.Drawing.Color.White
        Me.txtnext.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnext.Location = New System.Drawing.Point(317, 125)
        Me.txtnext.Name = "txtnext"
        Me.txtnext.Size = New System.Drawing.Size(158, 23)
        Me.txtnext.TabIndex = 75
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(243, 129)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(70, 15)
        Me.Label13.TabIndex = 74
        Me.Label13.Text = "N°. Exterior:"
        '
        'txtnint
        '
        Me.txtnint.BackColor = System.Drawing.Color.White
        Me.txtnint.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnint.Location = New System.Drawing.Point(81, 125)
        Me.txtnint.Name = "txtnint"
        Me.txtnint.Size = New System.Drawing.Size(158, 23)
        Me.txtnint.TabIndex = 73
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(7, 129)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(68, 15)
        Me.Label12.TabIndex = 72
        Me.Label12.Text = "N°. Interior:"
        '
        'txtcalle
        '
        Me.txtcalle.BackColor = System.Drawing.Color.White
        Me.txtcalle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcalle.Location = New System.Drawing.Point(81, 99)
        Me.txtcalle.Name = "txtcalle"
        Me.txtcalle.Size = New System.Drawing.Size(394, 23)
        Me.txtcalle.TabIndex = 71
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(7, 103)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(36, 15)
        Me.Label10.TabIndex = 70
        Me.Label10.Text = "Calle:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(212, 79)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 15)
        Me.Label9.TabIndex = 69
        Me.Label9.Text = "Domicilio"
        '
        'txtcontacto
        '
        Me.txtcontacto.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtcontacto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcontacto.Location = New System.Drawing.Point(115, 48)
        Me.txtcontacto.Name = "txtcontacto"
        Me.txtcontacto.Size = New System.Drawing.Size(156, 23)
        Me.txtcontacto.TabIndex = 68
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(7, 52)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(103, 15)
        Me.Label8.TabIndex = 67
        Me.Label8.Text = "Teléfono del tutor:"
        '
        'txttutor
        '
        Me.txttutor.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txttutor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txttutor.Location = New System.Drawing.Point(115, 22)
        Me.txttutor.Name = "txttutor"
        Me.txttutor.Size = New System.Drawing.Size(360, 23)
        Me.txttutor.TabIndex = 68
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(7, 26)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 15)
        Me.Label7.TabIndex = 67
        Me.Label7.Text = "Nombre del tutor:"
        '
        'optsabado
        '
        Me.optsabado.AutoSize = True
        Me.optsabado.Location = New System.Drawing.Point(428, 347)
        Me.optsabado.Name = "optsabado"
        Me.optsabado.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.optsabado.Size = New System.Drawing.Size(38, 19)
        Me.optsabado.TabIndex = 85
        Me.optsabado.Text = "Sa"
        Me.optsabado.UseVisualStyleBackColor = True
        '
        'optviernes
        '
        Me.optviernes.AutoSize = True
        Me.optviernes.Location = New System.Drawing.Point(370, 347)
        Me.optviernes.Name = "optviernes"
        Me.optviernes.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.optviernes.Size = New System.Drawing.Size(36, 19)
        Me.optviernes.TabIndex = 84
        Me.optviernes.Text = "Vi"
        Me.optviernes.UseVisualStyleBackColor = True
        '
        'optjueves
        '
        Me.optjueves.AutoSize = True
        Me.optjueves.Location = New System.Drawing.Point(311, 347)
        Me.optjueves.Name = "optjueves"
        Me.optjueves.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.optjueves.Size = New System.Drawing.Size(37, 19)
        Me.optjueves.TabIndex = 83
        Me.optjueves.Text = "Ju"
        Me.optjueves.UseVisualStyleBackColor = True
        '
        'optmiercoles
        '
        Me.optmiercoles.AutoSize = True
        Me.optmiercoles.Location = New System.Drawing.Point(249, 347)
        Me.optmiercoles.Name = "optmiercoles"
        Me.optmiercoles.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.optmiercoles.Size = New System.Drawing.Size(40, 19)
        Me.optmiercoles.TabIndex = 82
        Me.optmiercoles.Text = "Mi"
        Me.optmiercoles.UseVisualStyleBackColor = True
        '
        'optmartes
        '
        Me.optmartes.AutoSize = True
        Me.optmartes.Location = New System.Drawing.Point(184, 347)
        Me.optmartes.Name = "optmartes"
        Me.optmartes.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.optmartes.Size = New System.Drawing.Size(43, 19)
        Me.optmartes.TabIndex = 81
        Me.optmartes.Text = "Ma"
        Me.optmartes.UseVisualStyleBackColor = True
        '
        'optlunes
        '
        Me.optlunes.AutoSize = True
        Me.optlunes.Location = New System.Drawing.Point(123, 347)
        Me.optlunes.Name = "optlunes"
        Me.optlunes.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.optlunes.Size = New System.Drawing.Size(39, 19)
        Me.optlunes.TabIndex = 80
        Me.optlunes.Text = "Lu"
        Me.optlunes.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(15, 349)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(102, 15)
        Me.Label17.TabIndex = 79
        Me.Label17.Text = "Días de asistencia:"
        '
        'txthorario
        '
        Me.txthorario.BackColor = System.Drawing.Color.White
        Me.txthorario.Location = New System.Drawing.Point(319, 318)
        Me.txthorario.Name = "txthorario"
        Me.txthorario.ReadOnly = True
        Me.txthorario.Size = New System.Drawing.Size(164, 23)
        Me.txthorario.TabIndex = 78
        Me.txthorario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(259, 322)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 15)
        Me.Label6.TabIndex = 77
        Me.Label6.Text = "Horario:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 322)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 15)
        Me.Label3.TabIndex = 76
        Me.Label3.Text = "Grupo:"
        '
        'txtinscripcion
        '
        Me.txtinscripcion.BackColor = System.Drawing.Color.White
        Me.txtinscripcion.Location = New System.Drawing.Point(89, 372)
        Me.txtinscripcion.Name = "txtinscripcion"
        Me.txtinscripcion.ReadOnly = True
        Me.txtinscripcion.Size = New System.Drawing.Size(158, 23)
        Me.txtinscripcion.TabIndex = 87
        Me.txtinscripcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(15, 376)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 15)
        Me.Label11.TabIndex = 86
        Me.Label11.Text = "Inscripción:"
        '
        'btnlimpiar
        '
        Me.btnlimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnlimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnlimpiar.Location = New System.Drawing.Point(254, 415)
        Me.btnlimpiar.Name = "btnlimpiar"
        Me.btnlimpiar.Size = New System.Drawing.Size(75, 52)
        Me.btnlimpiar.TabIndex = 89
        Me.btnlimpiar.Text = "Limpiar"
        Me.btnlimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnlimpiar.UseVisualStyleBackColor = True
        '
        'btneliminar
        '
        Me.btneliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btneliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btneliminar.Location = New System.Drawing.Point(335, 415)
        Me.btneliminar.Name = "btneliminar"
        Me.btneliminar.Size = New System.Drawing.Size(75, 52)
        Me.btneliminar.TabIndex = 88
        Me.btneliminar.Text = "Dar de baja"
        Me.btneliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btneliminar.UseVisualStyleBackColor = True
        '
        'txtgrupo
        '
        Me.txtgrupo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtgrupo.FormattingEnabled = True
        Me.txtgrupo.Location = New System.Drawing.Point(89, 318)
        Me.txtgrupo.Name = "txtgrupo"
        Me.txtgrupo.Size = New System.Drawing.Size(164, 23)
        Me.txtgrupo.TabIndex = 90
        '
        'btnguardar
        '
        Me.btnguardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnguardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnguardar.Location = New System.Drawing.Point(416, 415)
        Me.btnguardar.Name = "btnguardar"
        Me.btnguardar.Size = New System.Drawing.Size(75, 52)
        Me.btnguardar.TabIndex = 91
        Me.btnguardar.Text = "Actualizar"
        Me.btnguardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnguardar.UseVisualStyleBackColor = True
        '
        'lblusuario
        '
        Me.lblusuario.BackColor = System.Drawing.Color.Navy
        Me.lblusuario.ForeColor = System.Drawing.Color.White
        Me.lblusuario.Location = New System.Drawing.Point(304, 5)
        Me.lblusuario.Name = "lblusuario"
        Me.lblusuario.Size = New System.Drawing.Size(92, 23)
        Me.lblusuario.TabIndex = 230
        Me.lblusuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtcontraseña
        '
        Me.txtcontraseña.BackColor = System.Drawing.Color.White
        Me.txtcontraseña.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcontraseña.Location = New System.Drawing.Point(399, 5)
        Me.txtcontraseña.Name = "txtcontraseña"
        Me.txtcontraseña.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtcontraseña.Size = New System.Drawing.Size(97, 23)
        Me.txtcontraseña.TabIndex = 229
        Me.txtcontraseña.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.White
        Me.TextBox1.Location = New System.Drawing.Point(325, 372)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(158, 23)
        Me.TextBox1.TabIndex = 233
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(287, 376)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(32, 15)
        Me.Label18.TabIndex = 232
        Me.Label18.Text = "Baja:"
        '
        'LBLID
        '
        Me.LBLID.AutoSize = True
        Me.LBLID.Location = New System.Drawing.Point(62, 429)
        Me.LBLID.Name = "LBLID"
        Me.LBLID.Size = New System.Drawing.Size(19, 15)
        Me.LBLID.TabIndex = 234
        Me.LBLID.Text = "LL"
        Me.LBLID.Visible = False
        '
        'frmAlumnos
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(499, 479)
        Me.Controls.Add(Me.LBLID)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.lblusuario)
        Me.Controls.Add(Me.txtcontraseña)
        Me.Controls.Add(Me.btnguardar)
        Me.Controls.Add(Me.txtgrupo)
        Me.Controls.Add(Me.btnlimpiar)
        Me.Controls.Add(Me.btneliminar)
        Me.Controls.Add(Me.txtinscripcion)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.optsabado)
        Me.Controls.Add(Me.optviernes)
        Me.Controls.Add(Me.optjueves)
        Me.Controls.Add(Me.optmiercoles)
        Me.Controls.Add(Me.optmartes)
        Me.Controls.Add(Me.optlunes)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txthorario)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.txttelefono)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboMatricula)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboNombre)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAlumnos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Catálogo de alumnos"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cboNombre As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cboMatricula As ComboBox
    Friend WithEvents txttelefono As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtcp As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents txtestado As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtdelegacion As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtcolonia As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtnext As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtnint As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtcalle As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtcontacto As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txttutor As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents optsabado As CheckBox
    Friend WithEvents optviernes As CheckBox
    Friend WithEvents optjueves As CheckBox
    Friend WithEvents optmiercoles As CheckBox
    Friend WithEvents optmartes As CheckBox
    Friend WithEvents optlunes As CheckBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txthorario As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtinscripcion As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents btnlimpiar As Button
    Friend WithEvents btneliminar As Button
    Friend WithEvents txtgrupo As ComboBox
    Friend WithEvents btnguardar As Button
    Friend WithEvents lblusuario As Label
    Friend WithEvents txtcontraseña As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents LBLID As Label
End Class

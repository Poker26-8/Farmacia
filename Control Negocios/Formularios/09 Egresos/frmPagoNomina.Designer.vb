﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPagoNomina
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPagoNomina))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblid_usu = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtpingreso = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtnss = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtsueldo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtpuesta = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtarea = New System.Windows.Forms.TextBox()
        Me.cbonombre = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtsueldo_neta = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtotros_d = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtotros_p = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txthoras = New System.Windows.Forms.TextBox()
        Me.btnguardar = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.dtphasta = New System.Windows.Forms.DateTimePicker()
        Me.dtpdesde = New System.Windows.Forms.DateTimePicker()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.btnnuevo = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cbotipo = New System.Windows.Forms.ComboBox()
        Me.lblusuario = New System.Windows.Forms.Label()
        Me.txtcontraseña = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cbofolio = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtmonto = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtsaldo = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
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
        Me.Label1.Size = New System.Drawing.Size(554, 31)
        Me.Label1.TabIndex = 45
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblid_usu)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.dtpingreso)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtnss)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtsueldo)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtpuesta)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtarea)
        Me.GroupBox1.Controls.Add(Me.cbonombre)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 62)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(539, 105)
        Me.GroupBox1.TabIndex = 46
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Empleado"
        '
        'lblid_usu
        '
        Me.lblid_usu.AutoSize = True
        Me.lblid_usu.Location = New System.Drawing.Point(478, 49)
        Me.lblid_usu.Name = "lblid_usu"
        Me.lblid_usu.Size = New System.Drawing.Size(0, 15)
        Me.lblid_usu.TabIndex = 201
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(377, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 15)
        Me.Label5.TabIndex = 200
        Me.Label5.Text = "Id del empleado:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(377, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 15)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Ingreso:"
        '
        'dtpingreso
        '
        Me.dtpingreso.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpingreso.Location = New System.Drawing.Point(432, 19)
        Me.dtpingreso.Name = "dtpingreso"
        Me.dtpingreso.Size = New System.Drawing.Size(98, 23)
        Me.dtpingreso.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(192, 75)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 15)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "NSS:"
        '
        'txtnss
        '
        Me.txtnss.Location = New System.Drawing.Point(249, 71)
        Me.txtnss.Name = "txtnss"
        Me.txtnss.Size = New System.Drawing.Size(122, 23)
        Me.txtnss.TabIndex = 12
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 75)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 15)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Sueldo:"
        '
        'txtsueldo
        '
        Me.txtsueldo.Location = New System.Drawing.Point(65, 71)
        Me.txtsueldo.Name = "txtsueldo"
        Me.txtsueldo.Size = New System.Drawing.Size(122, 23)
        Me.txtsueldo.TabIndex = 10
        Me.txtsueldo.Text = "0.00"
        Me.txtsueldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(192, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 15)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Puesto:"
        '
        'txtpuesta
        '
        Me.txtpuesta.Location = New System.Drawing.Point(249, 45)
        Me.txtpuesta.Name = "txtpuesta"
        Me.txtpuesta.Size = New System.Drawing.Size(122, 23)
        Me.txtpuesta.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 15)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Área:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nombre:"
        '
        'txtarea
        '
        Me.txtarea.Location = New System.Drawing.Point(65, 45)
        Me.txtarea.Name = "txtarea"
        Me.txtarea.Size = New System.Drawing.Size(122, 23)
        Me.txtarea.TabIndex = 1
        '
        'cbonombre
        '
        Me.cbonombre.FormattingEnabled = True
        Me.cbonombre.Location = New System.Drawing.Point(65, 19)
        Me.cbonombre.Name = "cbonombre"
        Me.cbonombre.Size = New System.Drawing.Size(306, 23)
        Me.cbonombre.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.txtsueldo_neta)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.txtotros_d)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.txtotros_p)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txthoras)
        Me.GroupBox2.Controls.Add(Me.btnguardar)
        Me.GroupBox2.Controls.Add(Me.GroupBox5)
        Me.GroupBox2.Controls.Add(Me.btnnuevo)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 223)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(539, 135)
        Me.GroupBox2.TabIndex = 47
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Pago de sueldo"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(8, 104)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(73, 15)
        Me.Label16.TabIndex = 214
        Me.Label16.Text = "Sueldo neto:"
        '
        'txtsueldo_neta
        '
        Me.txtsueldo_neta.Location = New System.Drawing.Point(124, 100)
        Me.txtsueldo_neta.Name = "txtsueldo_neta"
        Me.txtsueldo_neta.Size = New System.Drawing.Size(83, 23)
        Me.txtsueldo_neta.TabIndex = 213
        Me.txtsueldo_neta.Text = "0.00"
        Me.txtsueldo_neta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(8, 78)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(102, 15)
        Me.Label15.TabIndex = 212
        Me.Label15.Text = "Otros descuentos:"
        '
        'txtotros_d
        '
        Me.txtotros_d.Location = New System.Drawing.Point(124, 74)
        Me.txtotros_d.Name = "txtotros_d"
        Me.txtotros_d.Size = New System.Drawing.Size(83, 23)
        Me.txtotros_d.TabIndex = 211
        Me.txtotros_d.Text = "0.00"
        Me.txtotros_d.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(8, 52)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(111, 15)
        Me.Label13.TabIndex = 210
        Me.Label13.Text = "Otras percepciones:"
        '
        'txtotros_p
        '
        Me.txtotros_p.Location = New System.Drawing.Point(124, 48)
        Me.txtotros_p.Name = "txtotros_p"
        Me.txtotros_p.Size = New System.Drawing.Size(83, 23)
        Me.txtotros_p.TabIndex = 209
        Me.txtotros_p.Text = "0.00"
        Me.txtotros_p.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(8, 26)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(70, 15)
        Me.Label14.TabIndex = 208
        Me.Label14.Text = "Horas extra:"
        '
        'txthoras
        '
        Me.txthoras.Location = New System.Drawing.Point(124, 22)
        Me.txthoras.Name = "txthoras"
        Me.txthoras.Size = New System.Drawing.Size(83, 23)
        Me.txthoras.TabIndex = 207
        Me.txthoras.Text = "0.00"
        Me.txthoras.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnguardar
        '
        Me.btnguardar.BackgroundImage = CType(resources.GetObject("btnguardar.BackgroundImage"), System.Drawing.Image)
        Me.btnguardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnguardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnguardar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnguardar.Location = New System.Drawing.Point(404, 60)
        Me.btnguardar.Name = "btnguardar"
        Me.btnguardar.Size = New System.Drawing.Size(60, 63)
        Me.btnguardar.TabIndex = 206
        Me.btnguardar.Text = "Guardar"
        Me.btnguardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnguardar.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.dtphasta)
        Me.GroupBox5.Controls.Add(Me.dtpdesde)
        Me.GroupBox5.Controls.Add(Me.Label19)
        Me.GroupBox5.Controls.Add(Me.Label20)
        Me.GroupBox5.Location = New System.Drawing.Point(213, 9)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(317, 45)
        Me.GroupBox5.TabIndex = 50
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Periodo"
        '
        'dtphasta
        '
        Me.dtphasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtphasta.Location = New System.Drawing.Point(207, 15)
        Me.dtphasta.Name = "dtphasta"
        Me.dtphasta.Size = New System.Drawing.Size(97, 23)
        Me.dtphasta.TabIndex = 20
        '
        'dtpdesde
        '
        Me.dtpdesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpdesde.Location = New System.Drawing.Point(58, 15)
        Me.dtpdesde.Name = "dtpdesde"
        Me.dtpdesde.Size = New System.Drawing.Size(97, 23)
        Me.dtpdesde.TabIndex = 16
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(161, 19)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(40, 15)
        Me.Label19.TabIndex = 19
        Me.Label19.Text = "Hasta:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(10, 19)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(42, 15)
        Me.Label20.TabIndex = 17
        Me.Label20.Text = "Desde:"
        '
        'btnnuevo
        '
        Me.btnnuevo.BackgroundImage = CType(resources.GetObject("btnnuevo.BackgroundImage"), System.Drawing.Image)
        Me.btnnuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnnuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnnuevo.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnnuevo.Location = New System.Drawing.Point(470, 60)
        Me.btnnuevo.Name = "btnnuevo"
        Me.btnnuevo.Size = New System.Drawing.Size(60, 63)
        Me.btnnuevo.TabIndex = 205
        Me.btnnuevo.Text = "Nuevo"
        Me.btnnuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnnuevo.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(15, 44)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(36, 15)
        Me.Label17.TabIndex = 49
        Me.Label17.Text = "Área:"
        '
        'cbotipo
        '
        Me.cbotipo.FormattingEnabled = True
        Me.cbotipo.Location = New System.Drawing.Point(73, 40)
        Me.cbotipo.Name = "cbotipo"
        Me.cbotipo.Size = New System.Drawing.Size(184, 23)
        Me.cbotipo.TabIndex = 48
        '
        'lblusuario
        '
        Me.lblusuario.BackColor = System.Drawing.Color.Navy
        Me.lblusuario.ForeColor = System.Drawing.Color.White
        Me.lblusuario.Location = New System.Drawing.Point(368, 40)
        Me.lblusuario.Name = "lblusuario"
        Me.lblusuario.Size = New System.Drawing.Size(92, 23)
        Me.lblusuario.TabIndex = 227
        Me.lblusuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtcontraseña
        '
        Me.txtcontraseña.BackColor = System.Drawing.Color.White
        Me.txtcontraseña.Location = New System.Drawing.Point(466, 40)
        Me.txtcontraseña.Name = "txtcontraseña"
        Me.txtcontraseña.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtcontraseña.Size = New System.Drawing.Size(81, 23)
        Me.txtcontraseña.TabIndex = 226
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cbofolio)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.txtmonto)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.txtsaldo)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 167)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(539, 56)
        Me.GroupBox3.TabIndex = 228
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Descuento por préstamo"
        '
        'cbofolio
        '
        Me.cbofolio.FormattingEnabled = True
        Me.cbofolio.Location = New System.Drawing.Point(65, 22)
        Me.cbofolio.Name = "cbofolio"
        Me.cbofolio.Size = New System.Drawing.Size(113, 23)
        Me.cbofolio.TabIndex = 16
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(8, 26)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(36, 15)
        Me.Label12.TabIndex = 19
        Me.Label12.Text = "Folio:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(363, 26)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(46, 15)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "Monto:"
        '
        'txtmonto
        '
        Me.txtmonto.Location = New System.Drawing.Point(417, 22)
        Me.txtmonto.Name = "txtmonto"
        Me.txtmonto.Size = New System.Drawing.Size(113, 23)
        Me.txtmonto.TabIndex = 16
        Me.txtmonto.Text = "0.00"
        Me.txtmonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(186, 26)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(39, 15)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Saldo:"
        '
        'txtsaldo
        '
        Me.txtsaldo.Location = New System.Drawing.Point(244, 22)
        Me.txtsaldo.Name = "txtsaldo"
        Me.txtsaldo.Size = New System.Drawing.Size(113, 23)
        Me.txtsaldo.TabIndex = 14
        Me.txtsaldo.Text = "0.00"
        Me.txtsaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'frmPagoNomina
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(554, 365)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.lblusuario)
        Me.Controls.Add(Me.txtcontraseña)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.cbotipo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPagoNomina"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pago de nómina"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtpingreso As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtnss As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtsueldo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtpuesta As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtarea As System.Windows.Forms.TextBox
    Friend WithEvents cbonombre As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents dtphasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpdesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cbotipo As System.Windows.Forms.ComboBox
    Friend WithEvents btnguardar As System.Windows.Forms.Button
    Friend WithEvents btnnuevo As System.Windows.Forms.Button
    Friend WithEvents lblusuario As System.Windows.Forms.Label
    Friend WithEvents txtcontraseña As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cbofolio As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtmonto As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtsaldo As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtsueldo_neta As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtotros_d As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtotros_p As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txthoras As System.Windows.Forms.TextBox
    Friend WithEvents lblid_usu As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class

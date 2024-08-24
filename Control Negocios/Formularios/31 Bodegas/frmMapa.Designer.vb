<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMapa
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMapa))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pUbicaciones = New System.Windows.Forms.Panel()
        Me.btnHabilitar = New System.Windows.Forms.Button()
        Me.btnnueva = New System.Windows.Forms.Button()
        Me.btnReporte = New System.Windows.Forms.Button()
        Me.btnconsulta = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtbodega = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblbodega = New System.Windows.Forms.Label()
        Me.pAgregarMesa = New System.Windows.Forms.Panel()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboplantas = New System.Windows.Forms.ComboBox()
        Me.btnAddBodega = New System.Windows.Forms.Button()
        Me.lblpersonas = New System.Windows.Forms.Label()
        Me.cbopersonas = New System.Windows.Forms.ComboBox()
        Me.pBodegas = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.pAgregarMesa.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pUbicaciones)
        Me.Panel1.Controls.Add(Me.btnHabilitar)
        Me.Panel1.Controls.Add(Me.btnnueva)
        Me.Panel1.Controls.Add(Me.btnReporte)
        Me.Panel1.Controls.Add(Me.btnconsulta)
        Me.Panel1.Controls.Add(Me.btnSalir)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1155, 83)
        Me.Panel1.TabIndex = 0
        '
        'pUbicaciones
        '
        Me.pUbicaciones.AutoScroll = True
        Me.pUbicaciones.BackColor = System.Drawing.Color.LightSkyBlue
        Me.pUbicaciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pUbicaciones.Location = New System.Drawing.Point(180, 0)
        Me.pUbicaciones.Name = "pUbicaciones"
        Me.pUbicaciones.Size = New System.Drawing.Size(575, 83)
        Me.pUbicaciones.TabIndex = 12
        '
        'btnHabilitar
        '
        Me.btnHabilitar.BackColor = System.Drawing.Color.White
        Me.btnHabilitar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnHabilitar.FlatAppearance.BorderSize = 0
        Me.btnHabilitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHabilitar.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHabilitar.ForeColor = System.Drawing.Color.Black
        Me.btnHabilitar.Image = CType(resources.GetObject("btnHabilitar.Image"), System.Drawing.Image)
        Me.btnHabilitar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnHabilitar.Location = New System.Drawing.Point(755, 0)
        Me.btnHabilitar.Name = "btnHabilitar"
        Me.btnHabilitar.Size = New System.Drawing.Size(80, 83)
        Me.btnHabilitar.TabIndex = 16
        Me.btnHabilitar.Text = "Habilitar"
        Me.btnHabilitar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnHabilitar.UseVisualStyleBackColor = False
        '
        'btnnueva
        '
        Me.btnnueva.BackColor = System.Drawing.Color.White
        Me.btnnueva.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnnueva.FlatAppearance.BorderSize = 0
        Me.btnnueva.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnnueva.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnnueva.ForeColor = System.Drawing.Color.Black
        Me.btnnueva.Image = CType(resources.GetObject("btnnueva.Image"), System.Drawing.Image)
        Me.btnnueva.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnnueva.Location = New System.Drawing.Point(835, 0)
        Me.btnnueva.Name = "btnnueva"
        Me.btnnueva.Size = New System.Drawing.Size(80, 83)
        Me.btnnueva.TabIndex = 14
        Me.btnnueva.Text = "Nueva Bodega"
        Me.btnnueva.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnnueva.UseVisualStyleBackColor = False
        Me.btnnueva.Visible = False
        '
        'btnReporte
        '
        Me.btnReporte.BackColor = System.Drawing.Color.White
        Me.btnReporte.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnReporte.FlatAppearance.BorderSize = 0
        Me.btnReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReporte.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporte.ForeColor = System.Drawing.Color.Black
        Me.btnReporte.Image = CType(resources.GetObject("btnReporte.Image"), System.Drawing.Image)
        Me.btnReporte.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnReporte.Location = New System.Drawing.Point(915, 0)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(80, 83)
        Me.btnReporte.TabIndex = 15
        Me.btnReporte.Text = "Reporte"
        Me.btnReporte.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnReporte.UseVisualStyleBackColor = False
        '
        'btnconsulta
        '
        Me.btnconsulta.BackColor = System.Drawing.Color.White
        Me.btnconsulta.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnconsulta.FlatAppearance.BorderSize = 0
        Me.btnconsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnconsulta.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnconsulta.ForeColor = System.Drawing.Color.Black
        Me.btnconsulta.Image = CType(resources.GetObject("btnconsulta.Image"), System.Drawing.Image)
        Me.btnconsulta.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnconsulta.Location = New System.Drawing.Point(995, 0)
        Me.btnconsulta.Name = "btnconsulta"
        Me.btnconsulta.Size = New System.Drawing.Size(80, 83)
        Me.btnconsulta.TabIndex = 13
        Me.btnconsulta.Text = "Consulta"
        Me.btnconsulta.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnconsulta.UseVisualStyleBackColor = False
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.Color.White
        Me.btnSalir.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSalir.FlatAppearance.BorderSize = 0
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.ForeColor = System.Drawing.Color.Black
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSalir.Location = New System.Drawing.Point(1075, 0)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(80, 83)
        Me.btnSalir.TabIndex = 17
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.PictureBox1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(180, 83)
        Me.Panel4.TabIndex = 2
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(180, 83)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(201, Byte), Integer))
        Me.Panel2.Controls.Add(Me.txtbodega)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.lblbodega)
        Me.Panel2.Controls.Add(Me.pAgregarMesa)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 83)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(180, 626)
        Me.Panel2.TabIndex = 1
        '
        'txtbodega
        '
        Me.txtbodega.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtbodega.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbodega.Location = New System.Drawing.Point(0, 57)
        Me.txtbodega.Name = "txtbodega"
        Me.txtbodega.Size = New System.Drawing.Size(180, 29)
        Me.txtbodega.TabIndex = 49
        Me.txtbodega.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(0, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(180, 24)
        Me.Label2.TabIndex = 48
        Me.Label2.Text = "NOMBRE BODEGA"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblbodega
        '
        Me.lblbodega.BackColor = System.Drawing.Color.SkyBlue
        Me.lblbodega.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblbodega.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbodega.ForeColor = System.Drawing.Color.White
        Me.lblbodega.Location = New System.Drawing.Point(0, 0)
        Me.lblbodega.Name = "lblbodega"
        Me.lblbodega.Size = New System.Drawing.Size(180, 33)
        Me.lblbodega.TabIndex = 47
        Me.lblbodega.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pAgregarMesa
        '
        Me.pAgregarMesa.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(201, Byte), Integer))
        Me.pAgregarMesa.Controls.Add(Me.txtNombre)
        Me.pAgregarMesa.Controls.Add(Me.Label1)
        Me.pAgregarMesa.Controls.Add(Me.Label6)
        Me.pAgregarMesa.Controls.Add(Me.cboplantas)
        Me.pAgregarMesa.Controls.Add(Me.btnAddBodega)
        Me.pAgregarMesa.Controls.Add(Me.lblpersonas)
        Me.pAgregarMesa.Controls.Add(Me.cbopersonas)
        Me.pAgregarMesa.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pAgregarMesa.Location = New System.Drawing.Point(0, 434)
        Me.pAgregarMesa.Name = "pAgregarMesa"
        Me.pAgregarMesa.Size = New System.Drawing.Size(180, 192)
        Me.pAgregarMesa.TabIndex = 12
        Me.pAgregarMesa.Visible = False
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(8, 79)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(164, 23)
        Me.txtNombre.TabIndex = 24
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(8, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 20)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Nombre"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(8, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 20)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Ubicación"
        '
        'cboplantas
        '
        Me.cboplantas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboplantas.FormattingEnabled = True
        Me.cboplantas.Location = New System.Drawing.Point(8, 32)
        Me.cboplantas.Name = "cboplantas"
        Me.cboplantas.Size = New System.Drawing.Size(164, 23)
        Me.cboplantas.TabIndex = 18
        '
        'btnAddBodega
        '
        Me.btnAddBodega.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddBodega.BackColor = System.Drawing.Color.SkyBlue
        Me.btnAddBodega.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAddBodega.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddBodega.ForeColor = System.Drawing.Color.Black
        Me.btnAddBodega.Location = New System.Drawing.Point(101, 150)
        Me.btnAddBodega.Name = "btnAddBodega"
        Me.btnAddBodega.Size = New System.Drawing.Size(71, 38)
        Me.btnAddBodega.TabIndex = 15
        Me.btnAddBodega.Text = "Agregar"
        Me.btnAddBodega.UseVisualStyleBackColor = False
        '
        'lblpersonas
        '
        Me.lblpersonas.AutoSize = True
        Me.lblpersonas.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblpersonas.ForeColor = System.Drawing.Color.White
        Me.lblpersonas.Location = New System.Drawing.Point(9, 104)
        Me.lblpersonas.Name = "lblpersonas"
        Me.lblpersonas.Size = New System.Drawing.Size(94, 20)
        Me.lblpersonas.TabIndex = 14
        Me.lblpersonas.Text = "Dimensiones"
        '
        'cbopersonas
        '
        Me.cbopersonas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbopersonas.FormattingEnabled = True
        Me.cbopersonas.Location = New System.Drawing.Point(8, 126)
        Me.cbopersonas.Name = "cbopersonas"
        Me.cbopersonas.Size = New System.Drawing.Size(164, 23)
        Me.cbopersonas.TabIndex = 13
        '
        'pBodegas
        '
        Me.pBodegas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pBodegas.Location = New System.Drawing.Point(180, 83)
        Me.pBodegas.Name = "pBodegas"
        Me.pBodegas.Size = New System.Drawing.Size(975, 626)
        Me.pBodegas.TabIndex = 2
        '
        'frmMapa
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1155, 709)
        Me.Controls.Add(Me.pBodegas)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMapa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mapa"
        Me.Panel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pAgregarMesa.ResumeLayout(False)
        Me.pAgregarMesa.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents pBodegas As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnnueva As Button
    Friend WithEvents btnconsulta As Button
    Friend WithEvents pUbicaciones As Panel
    Friend WithEvents pAgregarMesa As Panel
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cboplantas As ComboBox
    Friend WithEvents btnAddBodega As Button
    Friend WithEvents lblpersonas As Label
    Friend WithEvents cbopersonas As ComboBox
    Friend WithEvents txtbodega As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lblbodega As Label
    Friend WithEvents btnHabilitar As Button
    Friend WithEvents btnReporte As Button
    Friend WithEvents btnSalir As Button
End Class

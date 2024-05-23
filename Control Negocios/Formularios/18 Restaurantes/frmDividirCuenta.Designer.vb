<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDividirCuenta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDividirCuenta))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblmesa = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.grdcomensal = New System.Windows.Forms.DataGridView()
        Me.Column19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtnuevocomensal = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.grdmesa = New System.Windows.Forms.DataGridView()
        Me.Column18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btncancelar = New System.Windows.Forms.Button()
        Me.btnguardard = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.grdcomensal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.grdmesa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Mesa:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblmesa
        '
        Me.lblmesa.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmesa.Location = New System.Drawing.Point(85, 9)
        Me.lblmesa.Name = "lblmesa"
        Me.lblmesa.Size = New System.Drawing.Size(187, 32)
        Me.lblmesa.TabIndex = 1
        Me.lblmesa.Text = "Label2"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel3)
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 44)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(785, 423)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DIVIDIR CUENTA"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.Panel3.Controls.Add(Me.GroupBox7)
        Me.Panel3.Location = New System.Drawing.Point(414, 21)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(365, 396)
        Me.Panel3.TabIndex = 2
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.grdcomensal)
        Me.GroupBox7.Controls.Add(Me.txtnuevocomensal)
        Me.GroupBox7.Controls.Add(Me.Label11)
        Me.GroupBox7.Location = New System.Drawing.Point(9, 8)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(353, 379)
        Me.GroupBox7.TabIndex = 0
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "NUEVO COMENSAL"
        '
        'grdcomensal
        '
        Me.grdcomensal.AllowUserToAddRows = False
        Me.grdcomensal.AllowUserToDeleteRows = False
        Me.grdcomensal.BackgroundColor = System.Drawing.Color.White
        Me.grdcomensal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdcomensal.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column19, Me.Column16, Me.Column17})
        Me.grdcomensal.Location = New System.Drawing.Point(6, 96)
        Me.grdcomensal.Name = "grdcomensal"
        Me.grdcomensal.ReadOnly = True
        Me.grdcomensal.RowHeadersVisible = False
        Me.grdcomensal.Size = New System.Drawing.Size(341, 277)
        Me.grdcomensal.TabIndex = 2
        '
        'Column19
        '
        Me.Column19.HeaderText = "comanda"
        Me.Column19.Name = "Column19"
        Me.Column19.ReadOnly = True
        Me.Column19.Visible = False
        '
        'Column16
        '
        Me.Column16.HeaderText = "Cant"
        Me.Column16.Name = "Column16"
        Me.Column16.ReadOnly = True
        Me.Column16.Width = 44
        '
        'Column17
        '
        Me.Column17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column17.HeaderText = "Producto"
        Me.Column17.Name = "Column17"
        Me.Column17.ReadOnly = True
        '
        'txtnuevocomensal
        '
        Me.txtnuevocomensal.Location = New System.Drawing.Point(6, 66)
        Me.txtnuevocomensal.Name = "txtnuevocomensal"
        Me.txtnuevocomensal.Size = New System.Drawing.Size(341, 22)
        Me.txtnuevocomensal.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(3, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(344, 43)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Escribe el número de comensal:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ejemp. 1,2,15,26 etc."
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.Panel2.Controls.Add(Me.GroupBox6)
        Me.Panel2.Location = New System.Drawing.Point(6, 21)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(402, 396)
        Me.Panel2.TabIndex = 1
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.grdmesa)
        Me.GroupBox6.Location = New System.Drawing.Point(3, 8)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(392, 385)
        Me.GroupBox6.TabIndex = 0
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "PRODUCTOS"
        '
        'grdmesa
        '
        Me.grdmesa.AllowUserToAddRows = False
        Me.grdmesa.AllowUserToDeleteRows = False
        Me.grdmesa.BackgroundColor = System.Drawing.Color.White
        Me.grdmesa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdmesa.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column18, Me.Column14, Me.Column15})
        Me.grdmesa.Location = New System.Drawing.Point(6, 26)
        Me.grdmesa.Name = "grdmesa"
        Me.grdmesa.ReadOnly = True
        Me.grdmesa.RowHeadersVisible = False
        Me.grdmesa.Size = New System.Drawing.Size(380, 353)
        Me.grdmesa.TabIndex = 0
        '
        'Column18
        '
        Me.Column18.HeaderText = "comanda"
        Me.Column18.Name = "Column18"
        Me.Column18.ReadOnly = True
        Me.Column18.Visible = False
        '
        'Column14
        '
        Me.Column14.HeaderText = "Cant"
        Me.Column14.Name = "Column14"
        Me.Column14.ReadOnly = True
        Me.Column14.Width = 50
        '
        'Column15
        '
        Me.Column15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column15.HeaderText = "Producto"
        Me.Column15.Name = "Column15"
        Me.Column15.ReadOnly = True
        '
        'btncancelar
        '
        Me.btncancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btncancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btncancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncancelar.Image = CType(resources.GetObject("btncancelar.Image"), System.Drawing.Image)
        Me.btncancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btncancelar.Location = New System.Drawing.Point(793, 235)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(75, 72)
        Me.btncancelar.TabIndex = 4
        Me.btncancelar.Text = "Cancelar"
        Me.btncancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btncancelar.UseVisualStyleBackColor = False
        '
        'btnguardard
        '
        Me.btnguardard.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnguardard.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnguardard.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnguardard.Image = CType(resources.GetObject("btnguardard.Image"), System.Drawing.Image)
        Me.btnguardard.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnguardard.Location = New System.Drawing.Point(794, 156)
        Me.btnguardard.Name = "btnguardard"
        Me.btnguardard.Size = New System.Drawing.Size(75, 73)
        Me.btnguardard.TabIndex = 3
        Me.btnguardard.Text = "Guardar"
        Me.btnguardard.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnguardard.UseVisualStyleBackColor = False
        '
        'frmDividirCuenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(873, 473)
        Me.Controls.Add(Me.btncancelar)
        Me.Controls.Add(Me.btnguardard)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblmesa)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDividirCuenta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dividir Cuenta"
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        CType(Me.grdcomensal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.grdmesa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents lblmesa As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents grdcomensal As DataGridView
    Friend WithEvents Column19 As DataGridViewTextBoxColumn
    Friend WithEvents Column16 As DataGridViewTextBoxColumn
    Friend WithEvents Column17 As DataGridViewTextBoxColumn
    Friend WithEvents txtnuevocomensal As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents grdmesa As DataGridView
    Friend WithEvents Column18 As DataGridViewTextBoxColumn
    Friend WithEvents Column14 As DataGridViewTextBoxColumn
    Friend WithEvents Column15 As DataGridViewTextBoxColumn
    Friend WithEvents btncancelar As Button
    Friend WithEvents btnguardard As Button
End Class

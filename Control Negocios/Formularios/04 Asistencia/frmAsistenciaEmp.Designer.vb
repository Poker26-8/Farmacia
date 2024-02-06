<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAsistenciaEmp
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAsistenciaEmp))
        Me.lblfecha = New System.Windows.Forms.Label()
        Me.lblhora = New System.Windows.Forms.Label()
        Me.lblnombre = New System.Windows.Forms.Label()
        Me.picHuella = New System.Windows.Forms.PictureBox()
        Me.timerFecha = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LimpiaEmpleado = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.picHuella, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblfecha
        '
        Me.lblfecha.Font = New System.Drawing.Font("Segoe UI", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfecha.Location = New System.Drawing.Point(18, 46)
        Me.lblfecha.Name = "lblfecha"
        Me.lblfecha.Size = New System.Drawing.Size(528, 40)
        Me.lblfecha.TabIndex = 19
        Me.lblfecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblhora
        '
        Me.lblhora.Font = New System.Drawing.Font("Segoe UI", 19.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblhora.Location = New System.Drawing.Point(18, 80)
        Me.lblhora.Name = "lblhora"
        Me.lblhora.Size = New System.Drawing.Size(528, 40)
        Me.lblhora.TabIndex = 20
        Me.lblhora.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblnombre
        '
        Me.lblnombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblnombre.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnombre.Location = New System.Drawing.Point(42, 215)
        Me.lblnombre.Name = "lblnombre"
        Me.lblnombre.Size = New System.Drawing.Size(528, 50)
        Me.lblnombre.TabIndex = 22
        Me.lblnombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'picHuella
        '
        Me.picHuella.BackColor = System.Drawing.Color.White
        Me.picHuella.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picHuella.Location = New System.Drawing.Point(247, 49)
        Me.picHuella.Name = "picHuella"
        Me.picHuella.Size = New System.Drawing.Size(119, 156)
        Me.picHuella.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picHuella.TabIndex = 21
        Me.picHuella.TabStop = False
        '
        'timerFecha
        '
        Me.timerFecha.Interval = 1
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
        Me.Label1.Size = New System.Drawing.Size(612, 31)
        Me.Label1.TabIndex = 44
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LimpiaEmpleado
        '
        Me.LimpiaEmpleado.Interval = 2500
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.picHuella)
        Me.Panel1.Controls.Add(Me.lblnombre)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 31)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(612, 340)
        Me.Panel1.TabIndex = 45
        '
        'frmAsistenciaEmp
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(612, 371)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblfecha)
        Me.Controls.Add(Me.lblhora)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmAsistenciaEmp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registro de asistencia del usuario"
        CType(Me.picHuella, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblfecha As System.Windows.Forms.Label
     Friend WithEvents lblhora As System.Windows.Forms.Label
     Friend WithEvents lblnombre As System.Windows.Forms.Label
     Friend WithEvents picHuella As System.Windows.Forms.PictureBox
     Friend WithEvents timerFecha As System.Windows.Forms.Timer
     Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LimpiaEmpleado As Timer
    Friend WithEvents Panel1 As Panel
End Class

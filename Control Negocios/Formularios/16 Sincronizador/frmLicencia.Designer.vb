﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLicencia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLicencia))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_Licencia = New System.Windows.Forms.TextBox()
        Me.txtNoPC = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnout = New System.Windows.Forms.Button()
        Me.btnGuardaFormatos = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Historic", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.Label2.Size = New System.Drawing.Size(399, 31)
        Me.Label2.TabIndex = 137
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_Licencia
        '
        Me.txt_Licencia.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Licencia.Location = New System.Drawing.Point(12, 109)
        Me.txt_Licencia.Name = "txt_Licencia"
        Me.txt_Licencia.Size = New System.Drawing.Size(375, 25)
        Me.txt_Licencia.TabIndex = 141
        Me.txt_Licencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtNoPC
        '
        Me.txtNoPC.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoPC.Location = New System.Drawing.Point(161, 45)
        Me.txtNoPC.Name = "txtNoPC"
        Me.txtNoPC.Size = New System.Drawing.Size(226, 29)
        Me.txtNoPC.TabIndex = 140
        Me.txtNoPC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(13, 82)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(141, 21)
        Me.Label7.TabIndex = 138
        Me.Label7.Text = "Serie de liberación:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 25)
        Me.Label6.TabIndex = 139
        Me.Label6.Text = "No de PC:"
        '
        'btnout
        '
        Me.btnout.BackgroundImage = CType(resources.GetObject("btnout.BackgroundImage"), System.Drawing.Image)
        Me.btnout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnout.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnout.Location = New System.Drawing.Point(327, 140)
        Me.btnout.Name = "btnout"
        Me.btnout.Size = New System.Drawing.Size(60, 63)
        Me.btnout.TabIndex = 255
        Me.btnout.Text = "Salir"
        Me.btnout.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnout.UseVisualStyleBackColor = True
        '
        'btnGuardaFormatos
        '
        Me.btnGuardaFormatos.BackgroundImage = CType(resources.GetObject("btnGuardaFormatos.BackgroundImage"), System.Drawing.Image)
        Me.btnGuardaFormatos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnGuardaFormatos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardaFormatos.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardaFormatos.Location = New System.Drawing.Point(261, 140)
        Me.btnGuardaFormatos.Name = "btnGuardaFormatos"
        Me.btnGuardaFormatos.Size = New System.Drawing.Size(60, 63)
        Me.btnGuardaFormatos.TabIndex = 254
        Me.btnGuardaFormatos.Text = "Guardar"
        Me.btnGuardaFormatos.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardaFormatos.UseVisualStyleBackColor = True
        '
        'frmLicencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(399, 219)
        Me.Controls.Add(Me.btnout)
        Me.Controls.Add(Me.btnGuardaFormatos)
        Me.Controls.Add(Me.txt_Licencia)
        Me.Controls.Add(Me.txtNoPC)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmLicencia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Liberación de sincronizador"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_Licencia As System.Windows.Forms.TextBox
    Friend WithEvents txtNoPC As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnout As System.Windows.Forms.Button
    Friend WithEvents btnGuardaFormatos As System.Windows.Forms.Button
End Class

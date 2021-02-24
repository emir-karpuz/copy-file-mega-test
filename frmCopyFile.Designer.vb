<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCopyFile
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtNewFiles = New System.Windows.Forms.TextBox()
        Me.lblResult = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtNewFiles
        '
        Me.txtNewFiles.Location = New System.Drawing.Point(12, 12)
        Me.txtNewFiles.Multiline = True
        Me.txtNewFiles.Name = "txtNewFiles"
        Me.txtNewFiles.ReadOnly = True
        Me.txtNewFiles.Size = New System.Drawing.Size(280, 425)
        Me.txtNewFiles.TabIndex = 1
        Me.txtNewFiles.TabStop = False
        '
        'lblResult
        '
        Me.lblResult.AutoSize = True
        Me.lblResult.Location = New System.Drawing.Point(9, 440)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(44, 13)
        Me.lblResult.TabIndex = 2
        Me.lblResult.Text = "Sonuç :"
        '
        'frmCopyFile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(304, 462)
        Me.Controls.Add(Me.lblResult)
        Me.Controls.Add(Me.txtNewFiles)
        Me.Name = "frmCopyFile"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNewFiles As System.Windows.Forms.TextBox
    Friend WithEvents lblResult As Label
End Class

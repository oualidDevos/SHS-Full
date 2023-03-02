<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_crystal
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        'Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        'Me.CrystalReport12 = New Code_barre.CrystalReport1
        'Me.CrystalReport11 = New Code_barre.CrystalReport1
        Me.SuspendLayout()
        '
        'CrystalReportViewer1
        '
        'Me.CrystalReportViewer1.ActiveViewIndex = 0
        'Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        'Me.CrystalReportViewer1.DisplayGroupTree = False
        'Me.CrystalReportViewer1.DisplayStatusBar = False
        'Me.CrystalReportViewer1.DisplayToolbar = False
        'Me.CrystalReportViewer1.Location = New System.Drawing.Point(7, -20)
        'Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        'Me.CrystalReportViewer1.ReportSource = Me.CrystalReport12
        'Me.CrystalReportViewer1.Size = New System.Drawing.Size(208, 419)
        'Me.CrystalReportViewer1.TabIndex = 1
        '
        'Frm_crystal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(221, 405)
        'Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Name = "Frm_crystal"
        Me.Text = "Frm_crystal"
        Me.ResumeLayout(False)

    End Sub
    'Friend WithEvents CrystalReport11 As Code_barre.CrystalReport1
    'Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    'Friend WithEvents CrystalReport12 As Code_barre.CrystalReport1
End Class

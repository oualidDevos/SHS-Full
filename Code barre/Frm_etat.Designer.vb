<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_etat
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_etat))
        'Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        'Me.CrystalReport21 = New Code_barre.CrystalReport2
        Me.SuspendLayout()
        '
        'CrystalReportViewer1
        '
        'Me.CrystalReportViewer1.ActiveViewIndex = 0
        'Me.CrystalReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
        '            Or System.Windows.Forms.AnchorStyles.Left) _
        '            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        'Me.CrystalReportViewer1.DisplayGroupTree = False
        'Me.CrystalReportViewer1.Location = New System.Drawing.Point(-1, 0)
        'Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        'Me.CrystalReportViewer1.ReportSource = Me.CrystalReport21
        'Me.CrystalReportViewer1.Size = New System.Drawing.Size(994, 578)
        'Me.CrystalReportViewer1.TabIndex = 1
        '
        'Frm_etat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 577)
        'Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_etat"
        Me.Text = "Liste des codes barres"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    'Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    'Friend WithEvents CrystalReport21 As Code_barre.CrystalReport2
End Class

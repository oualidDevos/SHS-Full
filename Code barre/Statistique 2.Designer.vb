<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Statistique_2
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Statistique_2))
        'Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        'Me.CrystalReport41 = New Code_barre.CrystalReport4
        Me.SuspendLayout()
        '
        'CrystalReportViewer1
        '
        'Me.CrystalReportViewer1.ActiveViewIndex = 0
        'Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        'Me.CrystalReportViewer1.DisplayGroupTree = False
        'Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        'Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 0)
        'Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        'Me.CrystalReportViewer1.ReportSource = Me.CrystalReport41
        'Me.CrystalReportViewer1.Size = New System.Drawing.Size(955, 567)
        'Me.CrystalReportViewer1.TabIndex = 0
        '
        'Statistique_2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(955, 567)
        'Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Statistique_2"
        Me.Text = "Pourcentage des bétails"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    'Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    'Friend WithEvents CrystalReport41 As Code_barre.CrystalReport4
End Class

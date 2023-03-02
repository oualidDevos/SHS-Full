<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmArchive
    Inherits DevExpress.XtraEditors.XtraUserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnSerialNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnChevillard = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTypeBetail = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnHerdCount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnBarCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCreatedAt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStable = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAcheteurP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAcheteurP1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnBoucher = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAcheteurT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1522, 543)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnSerialNumber, Me.GridColumnChevillard, Me.GridColumnTypeBetail, Me.GridColumnHerdCount, Me.GridColumnBarCode, Me.GridColumnCreatedAt, Me.GridColumnStable, Me.GridColumnAcheteurP, Me.GridColumnAcheteurP1, Me.GridColumnBoucher, Me.GridColumnAcheteurT, Me.GridColumnStatus, Me.GridColumn13})
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        '
        'GridColumnSerialNumber
        '
        Me.GridColumnSerialNumber.Caption = "Serie"
        Me.GridColumnSerialNumber.FieldName = "SerialNumber"
        Me.GridColumnSerialNumber.Name = "GridColumnSerialNumber"
        Me.GridColumnSerialNumber.Visible = True
        Me.GridColumnSerialNumber.VisibleIndex = 0
        '
        'GridColumnChevillard
        '
        Me.GridColumnChevillard.Caption = "Chevillard"
        Me.GridColumnChevillard.FieldName = "Chevillard"
        Me.GridColumnChevillard.Name = "GridColumnChevillard"
        Me.GridColumnChevillard.Visible = True
        Me.GridColumnChevillard.VisibleIndex = 1
        '
        'GridColumnTypeBetail
        '
        Me.GridColumnTypeBetail.Caption = "Bétail"
        Me.GridColumnTypeBetail.FieldName = "TypeBetail"
        Me.GridColumnTypeBetail.Name = "GridColumnTypeBetail"
        Me.GridColumnTypeBetail.Visible = True
        Me.GridColumnTypeBetail.VisibleIndex = 2
        '
        'GridColumnHerdCount
        '
        Me.GridColumnHerdCount.Caption = "Nombre de téte"
        Me.GridColumnHerdCount.FieldName = "HerdCount"
        Me.GridColumnHerdCount.Name = "GridColumnHerdCount"
        Me.GridColumnHerdCount.Visible = True
        Me.GridColumnHerdCount.VisibleIndex = 3
        '
        'GridColumnBarCode
        '
        Me.GridColumnBarCode.Caption = "Code à  barre"
        Me.GridColumnBarCode.FieldName = "BarCode"
        Me.GridColumnBarCode.Name = "GridColumnBarCode"
        Me.GridColumnBarCode.Visible = True
        Me.GridColumnBarCode.VisibleIndex = 4
        '
        'GridColumnCreatedAt
        '
        Me.GridColumnCreatedAt.Caption = "Date"
        Me.GridColumnCreatedAt.FieldName = "CreatedAt"
        Me.GridColumnCreatedAt.Name = "GridColumnCreatedAt"
        Me.GridColumnCreatedAt.Visible = True
        Me.GridColumnCreatedAt.VisibleIndex = 5
        '
        'GridColumnStable
        '
        Me.GridColumnStable.Caption = "Etable"
        Me.GridColumnStable.FieldName = "Stable"
        Me.GridColumnStable.Name = "GridColumnStable"
        Me.GridColumnStable.Visible = True
        Me.GridColumnStable.VisibleIndex = 6
        '
        'GridColumnAcheteurP
        '
        Me.GridColumnAcheteurP.Caption = "Acheteur Peaux"
        Me.GridColumnAcheteurP.FieldName = "AcheteurP"
        Me.GridColumnAcheteurP.Name = "GridColumnAcheteurP"
        Me.GridColumnAcheteurP.Visible = True
        Me.GridColumnAcheteurP.VisibleIndex = 7
        '
        'GridColumnAcheteurP1
        '
        Me.GridColumnAcheteurP1.Caption = "AcheteurP1"
        Me.GridColumnAcheteurP1.FieldName = "AcheteurP1"
        Me.GridColumnAcheteurP1.Name = "GridColumnAcheteurP1"
        Me.GridColumnAcheteurP1.Visible = True
        Me.GridColumnAcheteurP1.VisibleIndex = 8
        '
        'GridColumnBoucher
        '
        Me.GridColumnBoucher.Caption = "Boucher"
        Me.GridColumnBoucher.FieldName = "Boucher"
        Me.GridColumnBoucher.Name = "GridColumnBoucher"
        Me.GridColumnBoucher.Visible = True
        Me.GridColumnBoucher.VisibleIndex = 9
        '
        'GridColumnAcheteurT
        '
        Me.GridColumnAcheteurT.Caption = "AcheteurT"
        Me.GridColumnAcheteurT.FieldName = "AcheteurT"
        Me.GridColumnAcheteurT.Name = "GridColumnAcheteurT"
        Me.GridColumnAcheteurT.Visible = True
        Me.GridColumnAcheteurT.VisibleIndex = 10
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.Caption = "Etat"
        Me.GridColumnStatus.FieldName = "Status"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        Me.GridColumnStatus.Visible = True
        Me.GridColumnStatus.VisibleIndex = 11
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Logs"
        Me.GridColumn13.FieldName = "Logs"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 12
        '
        'frmArchive
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GridControl1)
        Me.Name = "frmArchive"
        Me.Size = New System.Drawing.Size(1522, 543)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnSerialNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnChevillard As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTypeBetail As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnHerdCount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnBarCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreatedAt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStable As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAcheteurP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAcheteurP1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnBoucher As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAcheteurT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
End Class

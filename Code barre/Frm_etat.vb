Imports System.Data.OleDb

Public Class Frm_etat
    Dim con As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;data source=" & Application.StartupPath & "\G_barC.mdb")
    'Dim ort As New CrystalReport2
    Dim ds As New DataSet
    Dim da As OleDbDataAdapter
    Private Sub Frm_etat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ds.Clear()
        da = New OleDbDataAdapter("select * from Archive order by CPCOD", con)
        da.Fill(ds, "AR")
        'Frm_menu.DataGridView1.DataSource = ds.Tables("AR")
        'ort.SetDataSource(ds.Tables("AR"))
        'ort.SetDataSource(Frm_menu.DataGridView1.DataSource)

        'Me.CrystalReportViewer1.ReportSource = ort

    End Sub
End Class
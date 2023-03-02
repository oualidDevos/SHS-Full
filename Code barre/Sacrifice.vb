Imports System.Data.OleDb
Public Class Sacrifice
    Dim con As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;data source=" & Application.StartupPath & "\G_barC.mdb")
    'Dim pr As New CrystalReport6
    Dim dr As OleDbDataReader

    Private Sub Sacrifice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim dstt As New DataSet
        Dim dt As OleDbDataAdapter
        dt = New OleDbDataAdapter("select * from archive where Libelle = '" & Frm_menu.ComboBox1.Text & "' and year(date_gen) = " & Frm_menu.DateTimePicker4.Value.Year & " and month(date_gen) = " & Frm_menu.DateTimePicker4.Value.Month & " and day(date_gen) = " & Frm_menu.DateTimePicker4.Value.Day & " order by Code", con)
        dt.Fill(dstt, "ARC")
        'pr.SetDataSource(dstt.Tables("ARC"))
        'rm_menu.DataGridView2.DataSource = dstt.Tables("ARC")
        'Me.CrystalReportViewer1.ReportSource = pr
    End Sub
End Class
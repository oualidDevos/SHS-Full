Imports System.Data.OleDb
Public Class inactif
    Dim con As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;data source=" & Application.StartupPath & "\G_barC.mdb")
    'Dim pr As New CrystalReport5

    Private Sub inactif_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim dstt As New DataSet
        Dim dt As OleDbDataAdapter
        dt = New OleDbDataAdapter("SELECT  C.CPCOD , C.Nombre from Clients C  where  C.CPCOD not in(select cpcode from series where  year(date_gen) between " & Frm_menu.DateTimePicker2.Value.Year & "  and " & Frm_menu.DateTimePicker3.Value.Year & " and month(date_gen) between " & Frm_menu.DateTimePicker2.Value.Month & " and  " & Frm_menu.DateTimePicker3.Value.Month & "  and day(date_gen) between " & Frm_menu.DateTimePicker2.Value.Day & " and " & Frm_menu.DateTimePicker3.Value.Day & ")", con)
        dt.Fill(dstt, "ARC")
        'pr.SetDataSource(dstt.Tables("ARC"))
        'Me.CrystalReportViewer1.ReportSource = pr
    End Sub
End Class
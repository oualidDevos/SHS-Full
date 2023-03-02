Imports System.Data.OleDb

Public Class Statistique1
    Dim con As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;data source=" & Application.StartupPath & "\G_barC.mdb")

    Private Sub Statistique1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim pr As New CrystalReport3
        Dim dstt As New DataSet
        Dim dt As OleDbDataAdapter

        dt = New OleDbDataAdapter("select * from archive", con)
        dt.Fill(dstt, "ARC")
        'pr.SetDataSource(dstt.Tables("ARC"))
        'Me.CrystalReportViewer1.ReportSource = pr

    End Sub
End Class
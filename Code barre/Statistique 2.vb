Imports System.Data.OleDb

Public Class Statistique_2
    Dim con As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;data source=" & Application.StartupPath & "\G_barC.mdb")
    'Dim pr As New CrystalReport4
    Private Sub Statistique_2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim dstt As New DataSet
        Dim dt As OleDbDataAdapter

        dt = New OleDbDataAdapter("select * from archive", con)
        dt.Fill(dstt, "ARC")
        'pr.SetDataSource(dstt.Tables("ARC"))
        'Me.CrystalReportViewer1.ReportSource = pr

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'pr.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, "c:\TR.pdf")
        ' MsgBox(My.Computer.FileSystem.SpecialDirectories.MyDocuments)

    End Sub
End Class
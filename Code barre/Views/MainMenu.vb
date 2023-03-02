Imports System.Linq
Imports DevExpress.XtraBars.Docking2010.Views

Public Class MainMenu
    Private Sub LoadControl(ByVal userControl As UserControl)
        For Each item As BaseDocument In TabbedView1.Documents.ToList()
            TabbedView1.RemoveDocument(item.Control)
        Next

        TabbedView1.AddOrActivateDocument(Function(e) e.Control.Name.Equals(userControl.Name), Function() userControl)
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        LoadControl(New frmChevillard())
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        LoadControl(New frmArchive())
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        LoadControl(New frmOptions())
    End Sub

    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        LoadControl(New frmStatistics())
    End Sub

    Private Sub BarButtonItem7_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick
        LoadControl(New frmClotureArchive())
    End Sub

    Private Sub BarButtonItem8_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem8.ItemClick
        LoadControl(New frmTirage())
    End Sub
End Class
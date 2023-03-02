Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports ICSharpCode.SharpZipLib.Zip
Imports QRCoder
Imports DevExpress.XtraReports.UI
Imports System.Drawing.Text
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports DevExpress.XtraSplashScreen
Imports Code_barre.WaitForm_SetDescription

Public Class Frm_menu

    Dim con As New SqlConnection("Data Source=SZEGHLI;Initial Catalog=kodec_db;Integrated Security=True")
    Dim ds As New DataSet
    Dim da As SqlDataAdapter
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim dt As DataTable
    Dim rqt As String
    Dim ado As New ADO
    Dim typeBetail As String
    Dim a As String
    Dim _path As String
    Dim userId As String

    Private Sub NumSerieFormat()
        Dim numS As String
        rqt = "exec Max_Serie"
        numS = (CInt(ado.ExecuteScalar(rqt)) + 1).ToString("D6")
        txtserie.Text = numS
    End Sub
    Private Sub FillAcheteurPeauxComboBox(ByVal typeBetail As String)
        rqt = "exec SP_ListAchteurByType 'P', @typeBetail"
        Dim param As SqlParameter() = New SqlParameter() {New SqlParameter With {
            .ParameterName = "typeBetail",
            .Value = typeBetail
        }}
        ado.LoadCombo(rqt, cmb_peaux, param)
    End Sub
    Private Sub LoadCmbStable()
        rqt = "exec GetDataByBetail @typeBetail"
        Dim param As SqlParameter() = New SqlParameter() {New SqlParameter With {
            .ParameterName = "typeBetail",
            .Value = typeBetail
        }}
        ado.LoadCombo(rqt, cmb_stable, param)
        'MessageBox.Show("text : " & ado.dt.Rows.Count)

    End Sub
    Private Sub FillAcheteurIntestinsComboBox(ByVal typeBetail As String)
        rqt = "exec SP_ListAchteurByType 'I', @typeBetail"
        Dim param As SqlParameter() = New SqlParameter() {New SqlParameter With {
            .ParameterName = "typeBetail",
            .Value = typeBetail
        }}
        ado.LoadCombo(rqt, cmb_intestint, param)
    End Sub

    Private Sub FillBoucherComboBox()
        rqt = "select * from Acheteur where TypeA = 'B'"
        ado.LoadCombo(rqt, cmbBoucher)
    End Sub

    Private Sub FillAcheteurTripComboBox()
        rqt = "select * from Acheteur where TypeA = 'T'"
        ado.LoadCombo(rqt, cmb_triprie)
    End Sub
    Private Sub FillArchiveDataGrid()
        Dim rqt As String = "select FORMAT(e.series,'D6') as [Série],e.Nom as [Chevillard],Libelle as [Bétail],Nbr_betail as [Nombre de Tête],Code as [Code à barre],Date_gen as [Date],Libelle_stable as [Etable],ap.Nom  as [Acheteur Peaux],ap.Nom  as [Acheteur Peaux] , b.Nom as [Boucher],t.Nom  as [Acheteur Triprie]  ,Etat,Pseudo as [Logs]
            from Entrer e
            inner join Acheteur ap
            on e.Acheteur_P = ap.Id
            inner join Acheteur ai
            on e.Acheteur_I = ai.Id
			inner join Acheteur b
			on e.Acheteur_B = b.Id
			inner join Acheteur t
			on e.Acheteur_T = t.Id
            where CONVERT(date,Date_gen) = CONVERT (date, GETUTCDATE())"
        ado.LoadGrid(rqt, DataGridView1)
    End Sub

    Private Sub EtatOrdreSacrifice()
        Dim report As New OrderSacrificeReport()
        Dim xrLblDate As XRLabel = TryCast(report.FindControl("XrLabelDate", True), XRLabel)
        xrLblDate.Text = Date.Now.ToString("dd/MM/yyyy")
        Dim printTool As New ReportPrintTool(report)
        printTool.ShowPreviewDialog()
    End Sub


    Private Function GetTypeBetail() As String
        rqt = "exec GetTypeBetailById @id"
        Dim param As SqlParameter() = New SqlParameter() {New SqlParameter With {
            .ParameterName = "id",
            .Value = combetail.SelectedValue.ToString
        }}
        'MessageBox.Show("test " & ado.ExecuteScalar(rqt, param))
        Return ado.ExecuteScalar(rqt, param)
    End Function

    Private Declare Sub keybd_event Lib "user32" (ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Integer, ByVal dwExtraInfo As Integer)
    Private Const VK_CAPITAL As Integer = &H14
    Private Const KEYEVENTF_EXTENDEDKEY As Integer = &H1
    Private Const KEYEVENTF_KEYUP As Integer = &H2

    Private Sub frm_menu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'rqt = "select * from v_OrdreDeSacrificeDuJournee"
        'ado.LoadData(rqt)
        'Dim dt = ado.dt
        'MessageBox.Show(CStr(ado.LoadData(rqt).Rows.Count))
        Me.TabControl1.Visible = False
        keybd_event(VK_CAPITAL, &H45, KEYEVENTF_EXTENDEDKEY Or 0, 0)

        _path = Application.StartupPath
        Dim splitPath As String() = _path.Split("\\")
        splitPath(splitPath.Length - 1) = ""
        splitPath(splitPath.Length - 2) = ""
        _path = String.Join("\\", splitPath, 0, splitPath.Length - 2)
        TabPage2.Enabled = True
        TabPage3.Enabled = False
        TabPage4.Enabled = False
        TabPage5.Enabled = False
        TabPage6.Enabled = False
        btnactive.Enabled = False
        btn_cloturer.Enabled = False

        Timer5.Start()
        'Load Users
        rqt = "select * from utilisateur"
        ado.LoadToolStripCombo(rqt, comuser)

        'radio_bovin.Checked = True
        'Ovin
        radio_ovin.Checked = True
        'Load Betail Combobox

        LoadCmbBetail()
        'GetTypeBetail
        typeBetail = GetTypeBetail()
        'Load Stable ComboBox
        LoadCmbStable()

        cmb_peaux.Text = ""

        cmb_intestint.Text = ""

        FillAcheteurPeauxComboBox(typeBetail)
        FillAcheteurIntestinsComboBox(typeBetail)
        FillBoucherComboBox()
        FillAcheteurTripComboBox()

        NumSerieFormat()

        FillArchiveDataGrid()

        'Me.ListBox1.Items.Clear()
        'Dim Liste() As String
        'Dim Chemin As String = Application.StartupPath & "\Archive"
        'Dim extension As String = "*.mdb"
        'Liste = System.IO.Directory.GetFileSystemEntries(Chemin, extension)
        'For i As Integer = 0 To Liste.Length - 1
        '    Dim lgh As Integer
        '    Dim separ() As String
        '    lgh = Liste(i).Length
        '    Liste(i) = Liste(i).Substring(0, lgh - 4)
        '    separ = Liste(i).Split("\")
        '    Me.ListBox1.Items.Add(separ(separ.Length - 1))
        'Next
        'Me.ListBox1.Sorted = True

    End Sub

    Private Sub LoadCmbBetail()
        rqt = "select * from betail"
        ado.LoadCombo(rqt, combetail)
    End Sub
    'Private Sub LoadCmbBetailByType(ByVal typeB As String)
    '    rqt = "select * from betail where "
    '    ado.LoadCombo(rqt, combetail)
    'End Sub

    Private Sub NewToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripButton.Click
        Try
            If valide And conect Then
                Me.TabControl1.Visible = True
                Me.TabControl1.SelectedTab = TabPage1
                Me.NewToolStripButton.Checked = False
                valide = False
            Else
                Me.TabControl1.Visible = False
                Me.NewToolStripButton.Checked = True
                valide = True
            End If
            If conect = False Then
                MessageBox.Show("Connectez vous pour avoir l'accès a l'espace kodec.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuarchive.Click
        Me.TabControl1.SelectedTab = TabPage2
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuoption.Click
        Me.TabControl1.SelectedTab = TabPage3
    End Sub

    Private Sub AProposDeKODEC10ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnconnexion.Click
        Try
            Dim verif As Integer = 0
            If Me.txtpassword.Text = "" Or Me.comuser.Text = "" Then
                MessageBox.Show("Saisissez votre identifiant et/ou votre mot de passe", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                rqt = "select * from utilisateur where pseudo = @pseudo and passe = @pass"
                Dim param() As SqlParameter = New SqlParameter() _
                {
                  New SqlParameter("@pseudo", SqlDbType.VarChar, 100) With {.Value = comuser.Text},
                  New SqlParameter("@pass", SqlDbType.VarChar, 100) With {.Value = txtpassword.Text}
                }
                ado.LoadData(rqt, param)
                If ado.dt.Rows.Count = 1 Then
                    Me.labuser.Text = "Bienvenue:"
                    Me.labpassword.Text = Me.comuser.Text
                    Me.comuser.Visible = False
                    Me.tttttttttt.Visible = False
                    Me.txtpassword.Visible = False
                    Me.btndeconnexion.Visible = True
                    Me.btnconnexion.Visible = False
                    Me.TabControl1.Visible = True
                    conect = True
                    Me.menuaprecu.Enabled = True
                    Me.menuarchive.Enabled = True
                    Me.menuoption.Enabled = True
                    Me.menuprint.Enabled = True
                    Me.etatform.Text = "Etat : Connecté  (" & Now & ")"
                    txtnum.Focus()
                    'Turn On CapsLock Automatically
                    keybd_event(VK_CAPITAL, &H45, KEYEVENTF_EXTENDEDKEY Or 0, 0)
                    userId = ado.dt.Rows(0)("ID")
                Else
                    MessageBox.Show("Votre mot de passe est incorrect", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btndeconnexion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndeconnexion.Click
        Try
            Me.labuser.Text = "Utilisateur :"
            Me.labpassword.Text = "Mot de passe :"

            Me.txtpassword.Text = ""
            Me.comuser.Text = ""
            Me.comuser.Visible = True
            Me.tttttttttt.Visible = True
            Me.txtpassword.Visible = True
            Me.btndeconnexion.Visible = False
            Me.btnconnexion.Visible = True
            conect = False
            Me.TabControl1.Visible = False
            Me.etatform.Text = "Etat : Déconnecté"
            Me.menuarchive.Enabled = False
            Me.menuaprecu.Enabled = False
            Me.menuoption.Enabled = False
            Me.menuprint.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Dim idChevillard As Integer
    Private Sub txtnum_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnum.TextChanged

        Try
            If Me.txtnum.Text <> "" Then
                If IsNumeric(Me.txtnum.Text) Then
                    Me.txtnom.Text = "Inconnu"
                    Dim nm As String
                    rqt = "select * from chevillard where RFIDCode = @rfidCode"
                    Dim param As SqlParameter() = New SqlParameter() {New SqlParameter With {
                        .ParameterName = "rfidCode",
                        .Value = CInt(Me.txtnum.Text)
                    }}
                    ado.LoadData(rqt, param)
                    If ado.dt.Rows.Count <> 0 Then
                        nm = ado.dt.Rows(0)("Nom").ToString
                        idChevillard = ado.dt.Rows(0)("Id").ToString
                        Dim rep As Boolean
                        Do
                            rep = False
                            If IsNumeric(nm.Substring(nm.Length - 1, 1)) Then
                                nm = nm.Remove(nm.Length - 1, 1)
                                rep = True
                            End If
                        Loop Until rep = False
                        Me.txtnom.Text = nm
                    End If
                Else
                    Me.txtnum.ResetText()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub comuser_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles comuser.SelectedIndexChanged
        Me.txtpassword.Focus()
    End Sub

    Private Sub txtnbr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnbr.TextChanged
        If Not IsNumeric(Me.txtnbr.Text) Then
            Me.txtnbr.ResetText()
        End If
    End Sub

    Private Sub txtserie_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtserie.TextChanged
        If Not IsNumeric(Me.txtserie.Text) Then
            Me.txtserie.ResetText()
        End If
    End Sub
    Dim code As String

    Private Sub btnimprimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnimprimer.Click
        ' Try
        Dim varerreur As Integer = CInt(Me.txtserie.Text) - 1
        var = CInt(Me.txtserie.Text) - 1
        If Me.txtnum.Text <> "" Then
            If Me.txtnbr.Text <> "" And Me.txtnbr.Text <> "0" Then
                If CInt(Me.txtnbr.Text) <= 1000 Then
                    If Me.txtserie.Text <> "" Then
                        If Me.txtserie.Text.Length = 6 Then
                            If Me.txtnom.Text <> "Inconnu" Then

                                If Me.chekerreur.Checked = False Then
                                    Dim codebr As String
                                    a = CInt(var) + CInt(Me.txtnbr.Text)
                                    codebr = idChevillard.ToString() & typeBetail + CInt(Me.txtnbr.Text).ToString("D2") & (CInt(var) + 1).ToString("D6")
                                    Me.labcode3.Text = codebr
                                    Me.Label7.Text = "*" & codebr & "*"
                                    Me.labcode2.Text = "*" & codebr & "*"
                                    S = Me.Label7.Text
                                    V = codebr
                                    Me.comcodeselect.Items.Clear()
                                    Me.comnbrselect.Items.Clear()

                                    Dim pp As New impression

                                    Try

                                        pp.Show()
                                        For i As Integer = 1 To CInt(Me.txtnbr.Text)
                                            code = idChevillard.ToString() & typeBetail & CInt(txtnbr.Text).ToString("D2") & (var + i).ToString("D6")
                                            'MessageBox.Show(code)
                                            Dim nSerie As Integer = var + i
                                            Dim report As New LabelReport()
                                            Dim qrCodeControl As XRBarCode = TryCast(report.FindControl("XrQrCode", True), XRBarCode)
                                            Dim barCodeControl As XRBarCode = TryCast(report.FindControl("XrBarCode", True), XRBarCode)
                                            Dim dataMatrixControl As XRBarCode = TryCast(report.FindControl("XrDataMatrix", True), XRBarCode)
                                            Dim xrLblDate As XRLabel = TryCast(report.FindControl("XrLabelDate", True), XRLabel)
                                            Dim xrLblNS As XRLabel = TryCast(report.FindControl("XrLabelNumSerie", True), XRLabel)
                                            Dim picEditONSA As XRLabel = TryCast(report.FindControl("XrPictureBoxOnsa", True), XRLabel)
                                            qrCodeControl.Text = code
                                            barCodeControl.Text = code
                                            dataMatrixControl.Text = Date.Now.ToString("dd/MM/yyyy")
                                            xrLblDate.Text = Date.Now.ToString("dd/MM/yyyy")
                                            xrLblNS.Text = code
                                            Dim printTool As New ReportPrintTool(report)
                                            'printTool.Print("Godex ZX420i")
                                            printTool.ShowPreviewDialog()

                                        Next
                                    Catch ex As Exception
                                        MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    End Try

                                    For i As Integer = 1 To CInt(Me.txtnbr.Text)
                                        code = idChevillard.ToString() & typeBetail & CInt(txtnbr.Text).ToString("D2") & (var + i).ToString("D6")
                                        Me.comnbrselect.Items.Add(i)
                                        Me.comcodeselect.Items.Add(Me.idChevillard.ToString() & Me.combetail.SelectedValue.ToString & CInt(var) + i)

                                        SeriesTableAdapter1.Insert(var + i, code,
                                                                  CInt(Me.txtnbr.Text),
                                                                  Now,
                                                                  True, CInt(idChevillard),
                                                                  CInt(combetail.SelectedValue.ToString),
                                                                  CInt(cmb_stable.SelectedValue.ToString),
                                                                  CInt(cmb_peaux.SelectedValue.ToString),
                                                                  CInt(cmb_intestint.SelectedValue.ToString),
                                                                  userId,
                                                                  CInt(cmbBoucher.SelectedValue.ToString),
                                                                  CInt(Me.txtnbr.Text),
                                                                  CInt(Me.txtnbr.Text),
                                                                  CInt(cmb_triprie.SelectedValue.ToString))


                                        ArchiveTableAdapter1.Insert(CInt(idChevillard), txtnom.Text, typeBetail, CInt(Me.txtnbr.Text), CInt(var) + i, Now, code, True, CInt(Me.txtnbr.Text), CInt(Me.txtnbr.Text))


                                        EntrerTableAdapter1.Insert(txtnom.Text, CInt(var) + i, code, CInt(Me.txtnbr.Text), Now, True, typeBetail, cmb_stable.Text, comuser.Text, cmb_peaux.SelectedValue, cmb_intestint.SelectedValue, cmbBoucher.SelectedValue, CInt(Me.txtnbr.Text), CInt(Me.txtnbr.Text), cmb_triprie.SelectedValue)

                                    Next

                                    pp.Hide()

                                    Me.comnbrselect.SelectedIndex = Me.comnbrselect.Items.Count - 1
                                    Me.comcodeselect.SelectedIndex = 0
                                    Me.txtnum.Enabled = False
                                    Me.txtnbr.Enabled = False
                                    Me.combetail.Enabled = False
                                    Me.txtserie.Enabled = False
                                    Me.voire.Enabled = False
                                    'Me.comnbrselect.Enabled = True
                                    'Me.comcodeselect.Enabled = True
                                    'Me.btnactive.Enabled = True
                                    Me.chekerreur.Enabled = False
                                    Me.btnimprimer.Enabled = False
                                    Me.btn_error.Enabled = False
                                    ds.Clear()

                                    'Me.EntrerTableAdapter.FillByDate(Me.DS1.Entrer, Now.Date)
                                    FillArchiveDataGrid()
                                Else

                                    Dim codebr As String
                                    a = CInt(varerreur) + CInt(Me.txtnbr.Text)
                                    codebr = idChevillard.ToString() & Me.combetail.SelectedValue.ToString & CInt(varerreur) + CInt(Me.txtnbr.Text)
                                    Me.labcode3.Text = codebr
                                    Me.Label7.Text = "*" & codebr & "*"
                                    Me.labcode2.Text = "*" & codebr & "*"
                                    S = Me.Label7.Text
                                    V = codebr
                                    Me.comcodeselect.Items.Clear()
                                    Me.comnbrselect.Items.Clear()

                                    For i As Integer = 1 To CInt(Me.txtnbr.Text)
                                        'Dim re As New CrystalReport1
                                        're.SetParameterValue(0, idChevillard.ToString() & Me.combetail.SelectedValue.ToString & CInt(varerreur) + i)
                                        're.SetParameterValue(1, "*" & idChevillard.ToString() & Me.combetail.SelectedValue.ToString & CInt(varerreur) + i & "*")
                                        're.PrintToPrinter(1, False, 1, 1)
                                    Next
                                    Me.btnretour_Click(sender, e)
                                End If
                            Else
                                MessageBox.Show("le code chevillard que vous avez entrer est inexistant.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)


                            End If
                        Else
                            MessageBox.Show("Le numéro de serie doit être 6 chiffre.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtserie.Focus()
                        End If

                    Else
                        MessageBox.Show("Retaper le numéro de serie.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtserie.Focus()
                    End If
                Else
                    MessageBox.Show("Entrer un nombre de bétail raisonnable", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Else
                MessageBox.Show("Entrer un nombre de bétail valide.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtnbr.Focus()
            End If
        Else
            MessageBox.Show("Entrer le code chevillard.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.txtnum.Focus()
        End If

        NumSerieFormat()
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub btnretour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnretour.Click
        ' Try
        Me.txtnum.Text = ""
        Me.txtnom.Text = "Inconnu"
        Me.combetail.SelectedIndex = 0
        Me.cmb_intestint.SelectedIndex = -1
        Me.cmb_peaux.SelectedIndex = -1
        Me.txtnbr.Text = "0"

        NumSerieFormat()

        Me.comcodeselect.Items.Clear()
        Me.comcodeselect.Text = "00000000000000"
        Me.comnbrselect.Items.Clear()
        Me.comnbrselect.Text = "0"
        Me.txtnum.Enabled = True
        Me.txtnbr.Enabled = True
        Me.combetail.Enabled = True
        Me.txtserie.Enabled = False
        Me.voire.Enabled = True
        Me.comnbrselect.Enabled = False
        Me.chekerreur.Enabled = True
        Me.comcodeselect.Enabled = False
        Me.btnactive.Enabled = False
        Me.labcode3.Text = "00000000000000"
        Me.labcode2.Text = "*00000000000000*"
        Me.Label7.Text = "*00000000000000*"
        Me.btnactive.Visible = True
        Me.btninactive.Visible = False
        Me.Label17.Text = "Désactivé"
        Me.txtnum.Focus()
        Me.btnimprimer.Enabled = True
        Me.chekerreur.Checked = False
        Me.chekerreur.Text = "NON"
        Me.btn_error.Enabled = True
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)

        'End Try
        typeBetail = GetTypeBetail()
        'Load Stable ComboBox
        LoadCmbStable()

        FillAcheteurPeauxComboBox(typeBetail)
        FillAcheteurIntestinsComboBox(typeBetail)
        FillBoucherComboBox()
        FillAcheteurTripComboBox()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles voire.Click
        NumSerieFormat()

    End Sub


    'Private Sub comnbrselect_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comnbrselect.SelectedIndexChanged
    '    'Try

    '    Dim t As String
    '    Dim b As Int64
    '    b = CType(a, Int64)
    '    b = b - Me.comnbrselect.Items.Count
    '    b = b + CInt(Me.comnbrselect.Text)
    '    t = Me.labcode3.Text.Remove(8, 6)
    '    Me.labcode3.Text = t & b
    '    Me.labcode2.Text = "*" & t & b & "*"
    '    Me.Label7.Text = "*" & t & b & "*"

    '    'Catch ex As Exception
    '    '    MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '    'End Try

    'End Sub


    'Private Sub comcodeselect_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comcodeselect.SelectedIndexChanged
    '    ' Try

    '    Dim stat As Boolean

    '    stat = SeriesTableAdapter.GetEtatByCode(Me.comcodeselect.Text)

    '    If stat = True Then
    '        Me.Label17.Text = "Activé"
    '        Me.btnactive.Visible = False
    '        Me.btninactive.Visible = True
    '    ElseIf stat = False Then
    '        Me.Label17.Text = "Désactivé"
    '        Me.btnactive.Visible = True
    '        Me.btninactive.Visible = False
    '    End If

    '    'Catch ex As Exception
    '    '    MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '    'End Try

    'End Sub

    Private Sub btnactive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnactive.Click
        ' Try

        Me.Label17.Text = "Activé"
        Me.btnactive.Visible = False
        Me.btninactive.Visible = True
        rqt = "update SERIES set Etat=1 where code = @code"
        Dim param As SqlParameter() = New SqlParameter() {New SqlParameter With {
            .ParameterName = "code",
            .Value = comcodeselect.Text
        }}
        ado.ExecuteNonQuery(rqt, param)
        'If con.State = ConnectionState.Open Then
        '    con.Close()
        'End If
        'con.Open()
        'cmd.Connection = con
        'cmd.CommandText = "update SERIES set Etat=1 where code = '" & Me.comcodeselect.Text & "'"
        'cmd.ExecuteNonQuery()
        'con.Close()


        'Me.EntrerTableAdapter.FillByDate(Me.DS1.Entrer, Now.Date)

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub btninactive_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btninactive.Click
        ' Try
        rqt = "update SERIES set Etat=0 where code = @code"
        Dim param As SqlParameter() = New SqlParameter() {New SqlParameter With {
            .ParameterName = "code",
            .Value = comcodeselect.Text
        }}
        ado.ExecuteNonQuery(rqt, param)
        'If con.State = ConnectionState.Open Then
        '    con.Close()
        'End If
        'con.Open()
        'cmd.Connection = con
        'cmd.CommandText = "update SERIES set Etat=0 where Code = '" & Me.comcodeselect.Text & "'"
        'cmd.ExecuteNonQuery()
        Me.Label17.Text = "Désactivé"
        Me.btnactive.Visible = True
        Me.btninactive.Visible = False
        'con.Close()

        'Me.EntrerTableAdapter.FillByDate(Me.DS1.Entrer, Now.Date)

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        'Try
        '    If Me.RadioButton1.Checked Then
        '        ds.Clear()
        '        da = New SqlDataAdapter("select CPCOD as Code,Nombre as [Nom et Prenom],Libelle as Type,Nbr_betail as Nombre,Serie,Date_gen as [Date Gen],Code as [Code barre],Etat from Archive where day(Date_gen) = " & Me.DateTimePicker1.Value.Day & " and " & " Month(Date_gen) = " & Me.DateTimePicker1.Value.Month, con)
        '        da.Fill(ds, "Archive")
        '        Me.DataGridView1.DataSource = ds.Tables("Archive")
        '        Me.CheckBox2.Checked = True
        '        Me.CheckBox1.Checked = True
        '    ElseIf Me.RadioButton2.Checked Then
        '        ds.Clear()
        '        da = New SqlDataAdapter("select CPCOD as Code,Nombre as [Nom et Prenom],Libelle as Type,Nbr_betail as Nombre,Serie,Date_gen as [Date Gen],Code as [Code barre],Etat from Archive where CPCOD = " & CType(Me.ComboBox4.Text, Int64) & " and day(Date_gen) = " & Me.DateTimePicker1.Value.Day & " and " & " Month(Date_gen) = " & Me.DateTimePicker1.Value.Month, con)
        '        da.Fill(ds, "Archive")
        '        Me.DataGridView1.DataSource = ds.Tables("Archive")
        '        Me.CheckBox2.Checked = True
        '        Me.CheckBox1.Checked = True
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        Try

            If Me.RadioButton2.Checked Then
                rqt = "select CPCOD from CLIENTS"
                ado.LoadData(rqt)
                Me.ComboBox4.Items.Clear()
                For Each row As DataRow In ado.dt.Rows
                    ComboBox4.Items.Add(row(0))
                Next
                Me.ComboBox4.Enabled = True
                'If con.State = ConnectionState.Open Then
                '    con.Close()
                'End If
                'con.Open()
                'cmd.Connection = con
                'cmd.CommandText = "select CPCOD from CLIENTS"
                'dr = cmd.ExecuteReader
                'Me.ComboBox4.Items.Clear()
                'While dr.Read
                '    Me.ComboBox4.Items.Add(dr(0))
                'End While
                'con.Close()
                'Me.ComboBox4.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        'Try
        '    If Me.RadioButton1.Checked Then
        '        Me.ComboBox4.Enabled = False
        '        Me.ComboBox4.ResetText()
        '        Me.ComboBox4.Items.Clear()
        '        ds.Clear()
        '        da = New SqlDataAdapter("select CPCOD as Code,Nombre as [Nom et Prenom],Libelle as Type,Nbr_betail as Nombre,Serie,Date_gen as [Date Gen],Code as [Code barre],Etat from Archive where day(Date_gen) = " & Now.Day & " and " & " Month(Date_gen) = " & Now.Month, con)
        '        da.Fill(ds, "Archive")
        '        Me.DataGridView1.DataSource = ds.Tables("Archive")
        '        Me.DateTimePicker1.Value = Now
        '        Me.CheckBox2.Checked = True
        '        Me.CheckBox1.Checked = True
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged
        'Try
        '    ds.Clear()
        '    da = New SqlDataAdapter("select CPCOD as Code,Nombre as [Nom et Prenom],Libelle as Type,Nbr_betail as Nombre,Serie,Date_gen as [Date Gen],Code as [Code barre],Etat from Archive where CPCOD = " & CType(Me.ComboBox4.Text, Int64) & " and day(Date_gen) = " & Me.DateTimePicker1.Value.Day & " and " & " Month(Date_gen) = " & Me.DateTimePicker1.Value.Month, con)
        '    da.Fill(ds, "Archive")
        '    Me.DataGridView1.DataSource = ds.Tables("Archive")
        '    Me.CheckBox2.Checked = True
        '    Me.CheckBox1.Checked = True
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        'Try
        '    If Me.CheckBox1.Checked Then
        '        If Me.CheckBox2.Checked = False Then
        '            If Me.RadioButton1.Checked Then
        '                ds.Clear()
        '                da = New SqlDataAdapter("select CPCOD as Code,Nombre as [Nom et Prenom],Libelle as Type,Nbr_betail as Nombre,Serie,Date_gen as [Date Gen],Code as [Code barre],Etat from Archive where Etat <> 0 and day(Date_gen) = " & Me.DateTimePicker1.Value.Day & " and " & " Month(Date_gen) = " & Me.DateTimePicker1.Value.Month, con)
        '                da.Fill(ds, "Archive")
        '                Me.DataGridView1.DataSource = ds.Tables("Archive")
        '            ElseIf Me.RadioButton2.Checked Then
        '                ds.Clear()
        '                da = New SqlDataAdapter("select CPCOD as Code,Nombre as [Nom et Prenom],Libelle as Type,Nbr_betail as Nombre,Serie,Date_gen as [Date Gen],Code as [Code barre],Etat from Archive where Etat <> 0 and CPCOD = " & CType(Me.ComboBox4.Text, Int64) & " and day(Date_gen) = " & Me.DateTimePicker1.Value.Day & " and " & " Month(Date_gen) = " & Me.DateTimePicker1.Value.Month, con)
        '                da.Fill(ds, "Archive")
        '                Me.DataGridView1.DataSource = ds.Tables("Archive")
        '            End If
        '        ElseIf Me.CheckBox2.Checked Then
        '            If Me.RadioButton1.Checked Then
        '                ds.Clear()
        '                da = New SqlDataAdapter("select CPCOD as Code,Nombre as [Nom et Prenom],Libelle as Type,Nbr_betail as Nombre,Serie,Date_gen as [Date Gen],Code as [Code barre],Etat from Archive where day(Date_gen) = " & Me.DateTimePicker1.Value.Day & " and " & " Month(Date_gen) = " & Me.DateTimePicker1.Value.Month, con)
        '                da.Fill(ds, "Archive")
        '                Me.DataGridView1.DataSource = ds.Tables("Archive")
        '            ElseIf Me.RadioButton2.Checked Then
        '                ds.Clear()
        '                da = New SqlDataAdapter("select CPCOD as Code,Nombre as [Nom et Prenom],Libelle as Type,Nbr_betail as Nombre,Serie,Date_gen as [Date Gen],Code as [Code barre],Etat from Archive where CPCOD = " & CType(Me.ComboBox4.Text, Int64) & " and day(Date_gen) = " & Me.DateTimePicker1.Value.Day & " and " & " Month(Date_gen) = " & Me.DateTimePicker1.Value.Month, con)
        '                da.Fill(ds, "Archive")
        '                Me.DataGridView1.DataSource = ds.Tables("Archive")
        '            End If
        '        End If
        '    Else
        '        Me.CheckBox2.Checked = True
        '        If Me.RadioButton1.Checked Then
        '            ds.Clear()
        '            da = New SqlDataAdapter("select CPCOD as Code,Nombre as [Nom et Prenom],Libelle as Type,Nbr_betail as Nombre,Serie,Date_gen as [Date Gen],Code as [Code barre],Etat from Archive where Etat = 0 and day(Date_gen) = " & Me.DateTimePicker1.Value.Day & " and " & " Month(Date_gen) = " & Me.DateTimePicker1.Value.Month, con)
        '            da.Fill(ds, "Archive")
        '            Me.DataGridView1.DataSource = ds.Tables("Archive")
        '        ElseIf Me.RadioButton2.Checked Then
        '            ds.Clear()
        '            da = New SqlDataAdapter("select CPCOD as Code,Nombre as [Nom et Prenom],Libelle as Type,Nbr_betail as Nombre,Serie,Date_gen as [Date Gen],Code as [Code barre],Etat from Archive where Etat = 0 and CPCOD = " & CType(Me.ComboBox4.Text, Int64) & " and day(Date_gen) = " & Me.DateTimePicker1.Value.Day & " and " & " Month(Date_gen) = " & Me.DateTimePicker1.Value.Month, con)
        '            da.Fill(ds, "Archive")
        '            Me.DataGridView1.DataSource = ds.Tables("Archive")
        '        End If
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)

        'End Try

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        'Try
        '    If Me.CheckBox2.Checked Then
        '        If Me.CheckBox1.Checked = False Then
        '            If Me.RadioButton1.Checked Then
        '                ds.Clear()
        '                da = New SqlDataAdapter("select CPCOD as Code,Nombre as [Nom et Prenom],Libelle as Type,Nbr_betail as Nombre,Serie,Date_gen as [Date Gen],Code as [Code barre],Etat from Archive where Etat = 0 and day(Date_gen) = " & Me.DateTimePicker1.Value.Day & " and " & " Month(Date_gen) = " & Me.DateTimePicker1.Value.Month, con)
        '                da.Fill(ds, "Archive")
        '                Me.DataGridView1.DataSource = ds.Tables("Archive")
        '            ElseIf Me.RadioButton2.Checked Then
        '                ds.Clear()
        '                da = New SqlDataAdapter("select CPCOD as Code,Nombre as [Nom et Prenom],Libelle as Type,Nbr_betail as Nombre,Serie,Date_gen as [Date Gen],Code as [Code barre],Etat from Archive where Etat = 0 and CPCOD = " & CType(Me.ComboBox4.Text, Int64) & " and day(Date_gen) = " & Me.DateTimePicker1.Value.Day & " and " & " Month(Date_gen) = " & Me.DateTimePicker1.Value.Month, con)
        '                da.Fill(ds, "Archive")
        '                Me.DataGridView1.DataSource = ds.Tables("Archive")
        '            End If
        '        ElseIf Me.CheckBox2.Checked Then
        '            If Me.RadioButton1.Checked Then
        '                ds.Clear()
        '                da = New SqlDataAdapter("select CPCOD as Code,Nombre as [Nom et Prenom],Libelle as Type,Nbr_betail as Nombre,Serie,Date_gen as [Date Gen],Code as [Code barre],Etat from Archive where day(Date_gen) = " & Me.DateTimePicker1.Value.Day & " and " & " Month(Date_gen) = " & Me.DateTimePicker1.Value.Month, con)
        '                da.Fill(ds, "Archive")
        '                Me.DataGridView1.DataSource = ds.Tables("Archive")
        '            ElseIf Me.RadioButton2.Checked Then
        '                ds.Clear()
        '                da = New SqlDataAdapter("select CPCOD as Code,Nombre as [Nom et Prenom],Libelle as Type,Nbr_betail as Nombre,Serie,Date_gen as [Date Gen],Code as [Code barre],Etat from Archive where CPCOD = " & CType(Me.ComboBox4.Text, Int64) & " and day(Date_gen) = " & Me.DateTimePicker1.Value.Day & " and " & " Month(Date_gen) = " & Me.DateTimePicker1.Value.Month, con)
        '                da.Fill(ds, "Archive")
        '                Me.DataGridView1.DataSource = ds.Tables("Archive")
        '            End If
        '        End If
        '    Else
        '        Me.CheckBox1.Checked = True
        '        If Me.RadioButton1.Checked Then
        '            ds.Clear()
        '            da = New SqlDataAdapter("select CPCOD as Code,Nombre as [Nom et Prenom],Libelle as Type,Nbr_betail as Nombre,Serie,Date_gen as [Date Gen],Code as [Code barre],Etat from Archive where Etat <> 0 and day(Date_gen) = " & Me.DateTimePicker1.Value.Day & " and " & " Month(Date_gen) = " & Me.DateTimePicker1.Value.Month, con)
        '            da.Fill(ds, "Archive")
        '            Me.DataGridView1.DataSource = ds.Tables("Archive")
        '        ElseIf Me.RadioButton2.Checked Then
        '            ds.Clear()
        '            da = New SqlDataAdapter("select CPCOD as Code,Nombre as [Nom et Prenom],Libelle as Type,Nbr_betail as Nombre,Serie,Date_gen as [Date Gen],Code as [Code barre],Etat from Archive where Etat <> 0 and CPCOD = " & CType(Me.ComboBox4.Text, Int64) & " and day(Date_gen) = " & Me.DateTimePicker1.Value.Day & " and " & " Month(Date_gen) = " & Me.DateTimePicker1.Value.Month, con)
        '            da.Fill(ds, "Archive")
        '            Me.DataGridView1.DataSource = ds.Tables("Archive")
        '        End If
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)

        'End Try

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim t As New Type
        t.ShowDialog()
    End Sub
    Dim cr As New encour
    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If Me.RadioButton4.Checked Then
        '    If MessageBox.Show("La clôture de l'archive mise a zéro la base et crée un sauvegarde, pour cela est ce que vous êtes sur de vouloir clôturer l'archive.", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then

        '        Try
        '            Me.Timer1.Start()
        '            File.Copy(Application.StartupPath & "\G_barC.mdb", Application.StartupPath & "\Archive\" & Now.Day & "-" & Now.Month & "-" & Now.Year & " " & Now.Hour & "h" & Now.Minute & "m" & " " & Me.labpassword.Text & ".mdb")
        '            Dim Enr As Integer
        '            con.Open()
        '            cmd.Connection = con
        '            cmd.CommandText = "select * from Prserie"
        '            dr = cmd.ExecuteReader
        '            While dr.Read
        '                Enr = dr(0)
        '                Exit While
        '            End While
        '            con.Close()
        '            con.Open()
        '            cmd.Connection = con
        '            cmd.CommandText = "DELETE FROM SERIES where Serie <> " & CInt(Enr)
        '            cmd.ExecuteNonQuery()
        '            con.Close()
        '            ds.Clear()
        '            da = New SqlDataAdapter("select * from Archive where day(Date_gen) = " & Now.Day & " and " & " Month(Date_gen) = " & Now.Month, con)
        '            da.Fill(ds, "Archive")
        '            Me.DataGridView1.DataSource = ds.Tables("Archive")
        '        Catch ex As Exception

        '            MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        End Try
        '    End If
        'End If
    End Sub

    Private Sub HelpToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpToolStripButton.Click
        End
    End Sub

    Private Sub chekerreur_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chekerreur.CheckedChanged
        If Me.chekerreur.Checked = False Then
            Me.chekerreur.Text = "NON"
        Else
            Me.chekerreur.Text = "OUI"
        End If
    End Sub

    Private Sub menuprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuprint.Click
        btnimprimer_Click(sender, e)
    End Sub


    Dim j As Integer = 0
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            j += 1
            If j = 1 Then
                cr.ShowDialog()
            ElseIf j = 30 Then
                cr.Hide()
                MessageBox.Show("Cloture d'archive resussi", "Reussi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Timer1.Stop()
                Me.RadioButton3.Checked = True
                j = 0
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub menuaprecu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuaprecu.Click
        Me.TabControl1.SelectedTab = Me.TabPage4
    End Sub


    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick
        ''  If Me.DataGridView1.Rows.IndexOf(Me.DataGridView1.CurrentRow) Then
        'Try
        '    If MessageBox.Show("Voulez vous supprimer cette serie?" & vbNewLine & "Cliquez sur oui pour supprimer la serie et cliquez sur annuller pour annuler l'opération", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        '        If con.State = ConnectionState.Open Then
        '            con.Close()
        '        End If
        '        'Dim o As Integer

        '        '  o = Me.DataGridView1.Rows.Item(Me.DataGridView1.CurrentRow.Index).Cells(4).Value
        '        ' MsgBox(o)
        '        con.Open()
        '        cmd.CommandText = "delete from SERIES where serie = " & CInt(Me.DataGridView1.Rows.Item(Me.DataGridView1.CurrentRow.Index).Cells(4).Value)
        '        cmd.ExecuteNonQuery()
        '        con.Close()
        '        MessageBox.Show("L'operation est réussi", "Reussi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        ds.Clear()
        '        da = New SqlDataAdapter("select CPCOD as Code,Nombre as [Nom et Prenom],Libelle as Type,Nbr_betail as Nombre,Serie,Date_gen as [Date Gen],Code as [Code barre],Etat from Archive where day(Date_gen) = " & Now.Day & " and " & " Month(Date_gen) = " & Now.Month, con)
        '        da.Fill(ds, "Archive")
        '        Me.DataGridView1.DataSource = ds.Tables("Archive")
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show("Erreur", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub


    Private Sub ToolStripSplitButton1_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripSplitButton1.ButtonClick
        Dim frm_pro As New Frm_apropos
        Frm_apropos.ShowDialog()
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Me.RadioButton6.Checked Then
            Dim oi As New Statistique1
            oi.Show()
        ElseIf Me.RadioButton5.Checked Then
            Dim ou As New Statistique_2
            ou.Show()
        End If
    End Sub
    Dim ListeInfo As New ArrayList
    Public Function ListeFichier(ByVal repertoire As DirectoryInfo, ByVal Reset As Boolean) As ArrayList
        If Reset = True Then
            ListeInfo.Clear()
        End If
        If repertoire.GetDirectories.Length <> 0 Then
            For Each repertoire2 As DirectoryInfo In repertoire.GetDirectories
                ListeFichier(repertoire2, False)
            Next
        End If
        For Each fichier As FileInfo In repertoire.GetFiles("*.mdb")
            ListeInfo.Add(fichier.Name)
        Next
        Return ListeInfo
    End Function

    Dim dss As New DataSet
    Private Sub ListBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        ''MsgBox(Application.StartupPath & "\Archive\" & Me.ListBox1.SelectedItem.ToString & ".mdb")
        'dss.Clear()
        'Dim conn As New SqlConnection("data source=.;initial catalog=kodec_db;intergated security=sspi")
        'Dim daa As SqlDataAdapter
        'daa = New SqlDataAdapter("select CPCOD as Code,Nombre as [Nom et Prenom],Libelle as Type,Nbr_betail as Nombre,Serie,Date_gen as [Date Gen],Code as [Code barre],Etat from Archive", conn)
        'daa.Fill(dss, "Archive")
        'Me.DataGridView2.DataSource = dss.Tables("Archive")
    End Sub

    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked Then
            Me.archivee.Enabled = False
        End If
    End Sub

    Private Sub RadioButton4_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        If RadioButton4.Checked Then
            Me.archivee.Enabled = True
        End If
    End Sub
    Dim cnt As Integer = 0
    Dim cpt As Integer = 0
    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If cnt < 400 Then
            If Me.ProgressBar1.Value < 100 Then
                Me.ProgressBar1.Value += 4
                cnt += 4
            ElseIf Me.ProgressBar1.Value = 100 Then
                Me.ProgressBar1.Value = 0
            End If
        Else
            Me.ProgressBar1.Value = 100
            Me.Panel4.Visible = True
            Me.Timer2.Stop()
            cnt = 0
        End If

    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        If cpt < 400 Then
            If Me.ProgressBar2.Value < 100 Then
                Me.ProgressBar2.Value += 5
                cpt += 5
            ElseIf Me.ProgressBar2.Value = 100 Then
                Me.ProgressBar2.Value = 0
            End If
        Else
            Me.ProgressBar2.Value = 100
            Me.Panel5.Visible = True
            Me.Timer3.Stop()
            cpt = 0
            Me.Timer4.Start()
        End If
    End Sub

    Private Sub Timer4_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer4.Tick
        If Me.ProgressBar3.Value < 100 Then
            Me.ProgressBar3.Value += 1
        ElseIf Me.ProgressBar3.Value = 100 Then
            Me.Panel6.Visible = True
            Me.Timer4.Stop()
            If MessageBox.Show("Clôture réussi.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) = Windows.Forms.DialogResult.OK Then
                Me.Panel4.Visible = False
                Me.Panel5.Visible = False
                Me.Panel6.Visible = False
                Me.ProgressBar1.Value = 0
                Me.ProgressBar2.Value = 0
                Me.ProgressBar3.Value = 0
                Me.RadioButton3.Checked = True

            End If

        End If

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If Me.RadioButton6.Checked Then
            Dim dstt As New DataSet
            Dim dt As SqlDataAdapter

            dt = New SqlDataAdapter("select * from archive", con)
            dt.Fill(dstt, "ARC")
            'pr.SetDataSource(dstt.Tables("ARC"))
            'pr.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\KODEC 1.0\Statistique\Global\PG " & CStr(Now.Date.Day) & "-" & CStr(Now.Date.Month) & "-" & CStr(Now.Date.Year) & ".pdf")
            MessageBox.Show("Enregistrement réussi.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf Me.RadioButton5.Checked Then
            Dim dsttt As New DataSet
            Dim dt As SqlDataAdapter
            'Dim td As New CrystalReport4
            dt = New SqlDataAdapter("select * from archive", con)
            dt.Fill(dsttt, "ARC")
            'td.SetDataSource(dsttt.Tables("ARC"))
            'td.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\KODEC 1.0\Statistique\Par mois\PPM " & CStr(Now.Date.Day) & "-" & CStr(Now.Date.Month) & "-" & CStr(Now.Date.Year) & ".pdf")
            MessageBox.Show("Enregistrement réussi.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)


        End If
    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Shell(Application.StartupPath & "\acrobat.exe", AppWinStyle.NormalFocus)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        If Me.DateTimePicker2.Value <= Me.DateTimePicker3.Value Then
            Dim frt As New inactif
            frt.Show()
        Else
            MessageBox.Show("Choisissez une date de fin plus grand ou egale a la date de debut.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        Dim p As Integer
        rqt = "select count(*) from archive where Libelle = '" & Me.ComboBox1.Text & "' and year(date_gen) = " & Me.DateTimePicker4.Value.Year & " and month(date_gen) = " & Me.DateTimePicker4.Value.Month & " and day(date_gen) = " & Me.DateTimePicker4.Value.Day
        p = ado.ExecuteScalar(rqt)
        If p = 0 Then
            MessageBox.Show("Il n y  a pas d'ordre de sacrifice pour cette date.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf p > 0 Then
            Dim fmm As New Sacrifice
            fmm.Show()
        End If

        'If con.State = 1 Then
        '    con.Close()
        'End If
        'con.Open()
        'cmd.Connection = con
        'cmd.CommandText = "select count(*) from archive where Libelle = '" & Me.ComboBox1.Text & "' and year(date_gen) = " & Me.DateTimePicker4.Value.Year & " and month(date_gen) = " & Me.DateTimePicker4.Value.Month & " and day(date_gen) = " & Me.DateTimePicker4.Value.Day
        'p = cmd.ExecuteScalar
    End Sub

    Private Sub Timer5_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer5.Tick

        If Now.Hour >= 17 And Now.Minute >= 0 Then

            lbl_time.ForeColor = Color.Red

        End If

        lbl_time.Text = Now.Hour & ":" & Now.Minute

    End Sub

    Private Sub radio_ovin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radio_bovin.CheckedChanged
        LoadBetailByType("BO")
        'Me.combetail.DataSource = BetailTableAdapter.GetDataByType("B")
    End Sub

    Private Sub LoadBetailByType(ByVal typeB As String)
        rqt = "exec GetDateByType @typeB"
        Dim param As SqlParameter() = New SqlParameter() {New SqlParameter With {
            .ParameterName = "typeB",
            .Value = typeB
        }}
        ado.LoadCombo(rqt, combetail, param)
    End Sub

    Private Sub RadioButton8_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radio_ovin.CheckedChanged
        LoadBetailByType("OV")
        'Me.combetail.DataSource = BetailTableAdapter.GetDataByType("O")
    End Sub

    Private Sub radio_zoneg_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radio_zoneg.CheckedChanged
        LoadBetailByType("CA")
        'Me.combetail.DataSource = BetailTableAdapter.GetDataByType("G")
    End Sub

    Private Sub ToolStrip_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip.ItemClicked

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

    End Sub

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_error.Click

    '    Try


    '        comcodeselect.Items.Clear()

    '        If txtnum.Text <> "" Then

    '            SeriesTableAdapter.FillByChevillard(Me.DS1.Series, CInt(Me.txtnum.Text), Now.Date)

    '            If DS1.Series.Count <> 0 Then

    '                For i As Integer = 0 To DS1.Series.Count - 1

    '                    comcodeselect.Items.Add(DS1.Series.Rows(i).Item(1))

    '                Next

    '                comcodeselect.Enabled = True
    '                comcodeselect.SelectedIndex = 0

    '            Else

    '                MessageBox.Show("Pas de resultat pour cette recherche", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)


    '            End If

    '        Else
    '            MessageBox.Show("Saisissez le code chevillard.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)

    '        End If

    '    Catch ex As Exception

    '        MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning)

    '    End Try

    'End Sub

    'Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click

    '    ListBox1.Items.Clear()
    '    ListBox2.Items.Clear()
    '    ListBox3.DataSource = LotOTableAdapter.GetData()


    '    Me.Code2FirstTableAdapter.Fill(Me.DS1.Code2First)

    '    For i As Integer = 0 To DS1.Code2First.Count - 1

    '        ListBox1.Items.Add(DS1.Code2First.Rows(i).Item(0))
    '    Next

    'End Sub

    'Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click

    '    If LotOTableAdapter.NombreLot() > 0 Then

    '        'LotOTableAdapter.DeleteByDate()
    '        'TriTableAdapter.DeleteByDate()
    '        Button18_Click(sender, e)

    '    Else

    '        MessageBox.Show("Tirage au sort non enregistrer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)


    '    End If


    'End Sub



    'Private Sub Button16_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click

    '    If LotOTableAdapter.NombreLot() = 0 Then

    '        If ListBox1.Items.Count = 0 And ListBox2.Items.Count > 0 And ListBox3.Items.Count = 0 Then

    '            If radio_az.Checked Or radio_za.Checked Then

    '                'If radio_az.Checked Then

    '                '    TriTableAdapter.Insert("0", Now.Date)

    '                'End If

    '                'If radio_za.Checked Then

    '                '    TriTableAdapter.Insert("1", Now.Date)

    '                'End If



    '                For i As Integer = 0 To ListBox2.Items.Count - 1

    '                    LotOTableAdapter.Insert(CInt(ListBox2.Items(i)), i + 1, Now.Date)

    '                Next

    '                ListBox2.Items.Clear()
    '                ListBox1.Items.Clear()

    '                ListBox3.DataSource = LotOTableAdapter.GetData()


    '                MessageBox.Show("Tirage au sort enregistrer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '            Else

    '                MessageBox.Show("Choisissez le type du tri.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '            End If


    '        Else

    '            MessageBox.Show("Erreur Opération.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Information)


    '        End If

    '    Else

    '        MessageBox.Show("Tirage au sort déjà enregistrer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)


    '    End If


    'End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If ListBox1.SelectedItem <> Nothing Then
            ListBox2.Items.Add(ListBox1.SelectedItem)
            ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)
        End If


    End Sub

    Private Sub ListBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox2.SelectedIndexChanged


    End Sub

    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        If ListBox2.SelectedItem <> Nothing Then
            ListBox1.Items.Add(ListBox2.SelectedItem)
            ListBox2.Items.RemoveAt(ListBox2.SelectedIndex)
        End If
    End Sub

    'Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click

    '    CodeStableForTriTableAdapter.Fill(DS1.CodeStableForTri)

    '    If DS1.CodeStableForTri.Count <> 0 Then

    '        For i As Integer = 0 To DS1.CodeStableForTri.Count - 1

    '            ListBox5.Items.Add(DS1.CodeStableForTri.Rows(i).Item(0))



    '        Next



    '    End If





    'End Sub

    'Private Sub Button21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button21.Click

    '    If ListBox5.SelectedItem <> Nothing Then

    '        ListBox4.Items.Add(ListBox5.SelectedItem)
    '        ListBox5.Items.RemoveAt(ListBox5.SelectedIndex)

    '    End If


    'End Sub

    'Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click
    '    If ListBox4.SelectedItem <> Nothing Then

    '        ListBox5.Items.Add(ListBox4.SelectedItem)
    '        ListBox4.Items.RemoveAt(ListBox4.SelectedIndex)

    '    End If
    'End Sub

    'Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button23.Click


    '    If LotBTableAdapter.NombreLot() = 0 Then


    '        If ListBox5.Items.Count = 0 And ListBox4.Items.Count > 0 And ListBox6.Items.Count = 0 Then

    '            For i As Integer = 0 To ListBox4.Items.Count - 1

    '                LotBTableAdapter.Insert(CInt(ListBox4.Items(i)), i, Now.Date)

    '            Next

    '            ListBox6.DataSource = LotBTableAdapter.GetData()
    '            ListBox4.Items.Clear()

    '            MessageBox.Show("Tirage au sort Enregistrer", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        Else

    '            MessageBox.Show("Erreur Opération.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '        End If





    '    Else

    '        MessageBox.Show("Tirage au sort déjà enregistrer", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '    End If






    'End Sub

    Private Sub ButtonEtatOrdreSacrifice_Click(sender As Object, e As EventArgs) Handles ButtonEtatOrdreSacrifice.Click
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        Try
            EtatOrdreSacrifice()
        Finally
            SplashScreenManager.CloseForm(False)
        End Try
    End Sub

    Private Sub Combetail_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles combetail.SelectionChangeCommitted
        typeBetail = GetTypeBetail()
        'Load Stable ComboBox
        LoadCmbStable()
        FillAcheteurPeauxComboBox(typeBetail)
        FillAcheteurIntestinsComboBox(typeBetail)
        FillBoucherComboBox()
        FillAcheteurTripComboBox()

    End Sub
End Class

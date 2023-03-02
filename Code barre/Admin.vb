Imports System.Data.OleDb
Imports System.Windows.Forms
Public Class Admin
    Dim con As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;data source=" & Application.StartupPath & "\G_barC.mdb") ';user id=;password=mxnaba")
    Dim cmd As New OleDbCommand
    Dim dr As OleDbDataReader

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Admin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TextBox1.Focus()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If Me.TextBox1.Text <> "" And Me.TextBox2.Text <> "" And Me.TextBox3.Text <> "" And Me.TextBox4.Text <> "" Then
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                cmd.Connection = con
                cmd.CommandText = "select count(*) from ADMIN where Pseudo='" & Me.TextBox3.Text & "'"
                Dim n As Integer
                n = cmd.ExecuteScalar
                If n <> 0 Then
                    MessageBox.Show("Pseudo Déjà Exist.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    con.Close()
                    Exit Sub
                End If
                cmd.CommandText = "INSERT INTO ADMIN values('" & Me.TextBox3.Text & "','" & Me.TextBox4.Text & "','" & Me.TextBox1.Text & "','" & Me.TextBox2.Text & "')"
                cmd.ExecuteNonQuery()
                MessageBox.Show("Opération réussi.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TextBox2.Text = ""
                Me.TextBox1.Text = ""
                Me.TextBox3.Text = ""
                Me.TextBox4.Text = ""
                Me.TextBox1.Focus()
                con.Close()
            Else
                MessageBox.Show("Remplissez les champs vide.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.TextBox1.Focus()
            End If
        Catch ex As Exception
            If MessageBox.Show("Vous aver commis une erreur." & vbNewLine & "Redémarrer KODEC", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop) = Windows.Forms.DialogResult.OK Then
                End
            End If
        End Try
    End Sub
End Class
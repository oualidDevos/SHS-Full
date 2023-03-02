Imports System.Data.OleDb
Public Class Type
    Dim con As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;data source=" & Application.StartupPath & "\G_barC.mdb") ';user id=;password=mxnaba")
    Dim cmd As New OleDbCommand
    Dim dr As OleDbDataReader
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If Me.TextBox1.Text <> "" And Me.TextBox2.Text <> "" Then
                If Me.TextBox1.Text.Length = 4 Then
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    cmd.Connection = con
                    cmd.CommandText = "select count(*) from BETAILS where Cptype=" & Me.TextBox1.Text
                    Dim n As Integer
                    n = cmd.ExecuteScalar
                    If n <> 0 Then
                        MessageBox.Show("Code Type Déjà Exist.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        con.Close()
                        Exit Sub
                    End If
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    cmd.Connection = con
                    cmd.CommandText = "INSERT INTO BETAILS values(" & CInt(Me.TextBox1.Text) & ",'" & Me.TextBox2.Text & "')"
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Opération réussi.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.TextBox2.Text = ""
                    Me.TextBox1.Text = ""
                    Me.TextBox1.Focus()
                Else
                    MessageBox.Show("La langueur du code doit se composer de 4 numéro.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.TextBox1.Focus()
                End If
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

    Private Sub Type_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TextBox1.Focus()
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class
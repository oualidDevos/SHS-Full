Imports System.Data.OleDb
Imports System.Windows.Forms
Public Class chevillard
    Dim con As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;data source=" & Application.StartupPath & "\G_barC.mdb") ';user id=;password=mxnaba")
    Dim cmd As New OleDbCommand
    Dim dr As OleDbDataReader
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If Me.TextBox1.Text <> "" And Me.TextBox2.Text <> "" And Me.TextBox3.Text <> "" Then
                If Me.TextBox1.Text.Length = 4 Then
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    cmd.Connection = con
                    cmd.CommandText = "select count(*) from CLIENTS where CPCOD=" & Me.TextBox1.Text
                    Dim n As Integer
                    n = cmd.ExecuteScalar
                    If n <> 0 Then
                        MessageBox.Show("Code chevillard D�j� Exist.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        con.Close()
                        Exit Sub
                    End If
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    cmd.Connection = con
                    cmd.CommandText = "INSERT INTO CLIENTS values(" & CInt(Me.TextBox1.Text) & ",'" & Me.TextBox2.Text & " " & Me.TextBox3.Text & "')"
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Op�ration r�ussi.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.TextBox2.Text = ""
                    Me.TextBox1.Text = ""
                    Me.TextBox3.Text = ""
                    Me.TextBox1.Focus()
                    con.Close()
                Else
                    MessageBox.Show("La langueur du code doit se composer de 4 num�ro.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.TextBox1.Focus()
                End If
            Else
                MessageBox.Show("Remplissez les champs vide.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.TextBox1.Focus()
            End If
             Catch ex As Exception
            If MessageBox.Show("Vous aver commis une erreur." & vbNewLine & "Red�marrer KODEC", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop) = Windows.Forms.DialogResult.OK Then
                End
            End If
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If Not IsNumeric(Me.TextBox1.Text) Then
            Me.TextBox1.ResetText()
        End If
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        If Not IsNumeric(Me.TextBox3.Text) Then
            Me.TextBox3.ResetText()
        End If
    End Sub

    Private Sub chevillard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TextBox1.Focus()
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class
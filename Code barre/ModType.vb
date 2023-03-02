﻿Imports System.Data.OleDb
Imports System.Data
Public Class ModType
    Dim con As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;data source=" & Application.StartupPath & "\G_barC.mdb") ';user id=;password=mxnaba")
    Dim da As OleDbDataAdapter
    Dim ds As New DataSet
    Dim cmd As New OleDbCommand
    Dim dr As OleDbDataReader
    Private Sub ModType_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ComboBox1.Items.Clear()
        ds.Clear()
        da = New OleDbDataAdapter("select * from BETAILS", con)
        da.Fill(ds, "clt")
        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            Me.ComboBox1.Items.Add(ds.Tables(0).Rows(i).Item(0))
        Next
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If Me.ComboBox1.Text <> "" And Me.TextBox2.Text <> "" Then
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                cmd.Connection = con
                cmd.CommandText = "update BETAILS set Libelle='" & Me.TextBox2.Text & "' where Cptype=" & Me.ComboBox1.Text
                cmd.ExecuteNonQuery()
                MessageBox.Show("Opération réussi.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.ComboBox1.Text = ""
                Me.TextBox2.Text = ""
                ModType_Load(sender, e)
                con.Close()
            Else
                MessageBox.Show("Remplissez les champs vide.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.ComboBox1.Focus()
            End If
        Catch ex As Exception
            If MessageBox.Show("Vous avez commis une erreur." & vbNewLine & "Redémarrer KODEC", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop) = Windows.Forms.DialogResult.OK Then
                End
            End If
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            If ds.Tables(0).Rows(i).Item(0) = Me.ComboBox1.SelectedItem Then
                Me.TextBox2.Text = ds.Tables(0).Rows(i).Item(1)
                Exit Sub
            End If
        Next
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class
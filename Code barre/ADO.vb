Imports System.Data.SqlClient

Public Class ADO
    Public ReadOnly cnx As New SqlConnection("Data Source=SZEGHLI;Initial Catalog=kodec_db;Integrated Security=True")
    Public dt As DataTable
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader

    Public Sub OpenConnection()
        If cnx.State <> ConnectionState.Open Then cnx.Open()
    End Sub

    Public Sub CloseConnection()
        If cnx.State <> ConnectionState.Closed Then cnx.Close()
    End Sub

    Public Function LoadData(ByVal rqt As String, ByVal Optional param As SqlParameter() = Nothing) As DataTable
        Try
            OpenConnection()
            cmd = New SqlCommand(rqt, cnx)
            If param IsNot Nothing Then cmd.Parameters.AddRange(param)
            dr = cmd.ExecuteReader()
            dt = New DataTable()
            dt.Load(dr)
        Finally
            CloseConnection()
        End Try

        Return dt
    End Function

    Public Sub LoadGrid(ByVal rqt As String, ByVal d As DataGridView, ByVal Optional param As SqlParameter() = Nothing)
        d.DataSource = LoadData(rqt, param)
    End Sub

    Public Sub LoadCombo(ByVal rqt As String, ByVal c As ComboBox, ByVal Optional param As SqlParameter() = Nothing)
        dt = LoadData(rqt, param)
        c.ValueMember = dt.Columns(0).ToString()
        c.DisplayMember = dt.Columns(1).ToString()
        c.DataSource = dt
    End Sub
    Public Sub LoadToolStripCombo(ByVal rqt As String, ByVal c As ToolStripComboBox, ByVal Optional param As SqlParameter() = Nothing)
        OpenConnection()
        cmd = New SqlCommand(rqt, cnx)
        dr = cmd.ExecuteReader
        While dr.Read
            c.Items.Add(dr(1))
        End While
        CloseConnection()
    End Sub

    Public Function ExecuteNonQuery(ByVal rqt As String, ByVal Optional param As SqlParameter() = Nothing) As Integer
        Dim i As Integer = 0

        Try
            OpenConnection()
            cmd = New SqlCommand(rqt, cnx)
            If param IsNot Nothing Then cmd.Parameters.AddRange(param)
            i = cmd.ExecuteNonQuery()
        Finally
            CloseConnection()
        End Try

        Return i
    End Function

    Public Function ExecuteScalar(ByVal rqt As String, ByVal Optional param As SqlParameter() = Nothing) As Object
        Dim o As Object = Nothing

        Try
            OpenConnection()
            cmd = New SqlCommand(rqt, cnx)
            If param IsNot Nothing Then cmd.Parameters.AddRange(param)
            o = cmd.ExecuteScalar()
        Finally
            CloseConnection()
        End Try

        Return o
    End Function
End Class

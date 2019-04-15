Imports MySql.Data
Imports MySql.Data.MySqlClient

Module Connection
    Private Connection As New MySqlConnection
    Private Transaction As MySqlTransaction
    Private ConnectionString As String
    Public Function TestConnection(str As String) As Boolean
        Try
            If Connection.State = ConnectionState.Open Then
                CloseSQLConnection()
            End If
            Connection.ConnectionString = str
            Connection.Open()
            Transaction = Connection.BeginTransaction
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function IsConnected() As Boolean
        If ConnectToServer() = True Then
            Return True
        ElseIf ConnectToLocal() = True Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function ConnectToServer() As Boolean
        Try
            If Connection.State = ConnectionState.Open Then
                CloseSQLConnection()
            End If
            Connection.ConnectionString = "Server=" & My.Settings.IP & ";Port=" & My.Settings.Port _
                                              & ";Database=" & My.Settings.Database & ";User=" & My.Settings.Username _
                                              & ";Password=" & My.Settings.Password & ";"
            Connection.Open()
            Transaction = Connection.BeginTransaction
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function ConnectToLocal() As Boolean
        Try
            If Connection.State = ConnectionState.Open Then
                CloseSQLConnection()
            End If
            Connection.ConnectionString = "Server=localhost;Port=" & My.Settings.Port _
                                              & ";Database=" & My.Settings.Database & ";User=" & My.Settings.Username _
                                              & ";Password=" & My.Settings.Password & ";"
            Connection.Open()
            Transaction = Connection.BeginTransaction
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'This is use to execute add,edit and delete query.
    Public Sub ServerExecuteSQL(sql As String, ParamArray obj() As Object)
        Dim cmd As New MySqlCommand(sql, Connection, Transaction)
        Dim i As Integer
        For i = 0 To obj.Length - 1
            cmd.Parameters.AddWithValue("@" & i, obj(i))
        Next
        cmd.ExecuteNonQuery()
        cmd.Dispose()
    End Sub
    Public Sub Commit()
        Transaction.Commit()
        Transaction = Connection.BeginTransaction
    End Sub
    Public Sub Rollback()
        Transaction.Rollback()
        Transaction = Connection.BeginTransaction
    End Sub

    Public Sub CloseSQLConnection()
        Try
            Connection.Close()
        Catch ex As Exception
            Connection.Close()
        End Try
    End Sub
    Public Function getServerConnection() As MySqlConnection
        Return Connection
    End Function
    Public Function getConnectionString() As String
        Return ConnectionString
    End Function
End Module

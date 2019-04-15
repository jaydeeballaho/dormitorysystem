Imports MySql.Data.MySqlClient

Public Class AccountController

    Inherits AccountDb

    Public Sub SetAccountDetails(id As Integer)
        Try
            Dim sql As String
            sql = "SELECT * FROM Account WHERE Accountid = " & id & ";"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    AccountID = reader(0)
                    AccountFirstName = reader(1)
                    AccountLastName = reader(2)
                    AccountUserName = reader(3)
                    AccountPassword = reader(4)
                    AccountRole = reader(5)
                    AccountStatus = reader(6)
                End While
                reader.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Function AddAccount() As Boolean
        Try
            Dim bool As Boolean = False
            Dim sql As String = "INSERT INTO Account (firstname,lastname,username,password,role,loginstatus) VALUES (@0,@1,@2,@3,@4,@5);"
            If IsConnected() = True Then
                ServerExecuteSQL(sql, AccountFirstName, AccountLastName, AccountUserName, AccountPassword, AccountRole, AccountStatus)
                Commit()
                bool = True
            End If
            Return bool
        Catch ex As Exception
            Rollback()
            Return False
        End Try
    End Function

    Public Function EditAccount() As Boolean
        Try
            Dim bool As Boolean = False
            Dim sql As String = "UPDATE Account SET firstname=@0,lastname=@1,username=@2,password=@3,role=@4,loginstatus=@5 WHERE Accountid=@6;"
            If IsConnected() = True Then
                ServerExecuteSQL(sql, AccountFirstName, AccountLastName, AccountUserName, AccountPassword, AccountRole, AccountStatus, AccountID)
                Commit()
                bool = True
            End If
            Return bool
        Catch ex As Exception
            Rollback()
            Return False
        End Try
    End Function

    Public Function DeleteAccount() As Boolean
        Try
            Dim bool As Boolean = False
            Dim sql As String = "DELETE FROM Account WHERE Accountid = @0;"
            If IsConnected() = True Then
                ServerExecuteSQL(sql, AccountID)
                Commit()
                bool = True
            End If
            Return bool
        Catch ex As Exception
            Rollback()
            Return False
        End Try
    End Function

    Public Sub SearchAccount(kw As String, gv As DataGridView, lbl As Label)
        Try
            Dim sql As String
            Dim i As Integer = 0
            sql = "SELECT * FROM Account WHERE (firstname LIKE '" & kw & "%' or lastname LIKE '" & kw & "%' or" _
                  + " username LIKE '" & kw & "%' or role LIKE '" & kw & "%') ORDER BY firstname,lastname,username ASC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                gv.Rows.Clear()
                While reader.Read()
                    i = i + 1
                    With gv
                        .Rows.Add(reader(0), i, reader(1) + " " + reader(2), reader(3), reader(5), "Edit", "Delete")
                    End With
                End While
                reader.Close()
                If gv.RowCount > 0 Then
                    lbl.Hide()
                Else
                    lbl.Text = "ACCOUNT NOT FOUND"
                    lbl.Show()
                End If
                gv.ClearSelection()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub ViewAccount(gv As DataGridView, lbl As Label)
        Try
            Dim sql As String
            Dim i As Integer = 0
            sql = "SELECT * FROM Account ORDER BY firstname,lastname,username ASC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                gv.Rows.Clear()
                 While reader.Read()
                    i = i + 1
                    With gv
                        .Rows.Add(reader(0), i, reader(1) + " " + reader(2), reader(3), reader(5), "Edit", "Delete")
                    End With
                End While
                reader.Close()
                If gv.RowCount > 0 Then
                    lbl.Hide()
                Else
                    lbl.Text = "NO ACCOUNTS YET"
                    lbl.Show()
                End If
                gv.ClearSelection()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Function IsAccountExist(kw As String) As Boolean
        Try
            Dim bool As Boolean = True
            Dim sql As String
            sql = "SELECT * FROM Account WHERE (BINARY username = '" & kw & "') ORDER BY username ASC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                If reader.HasRows() Then
                    bool = True
                Else
                    bool = False
                End If
            End If
            Return bool
        Catch ex As Exception
            Return True
        End Try
    End Function
    Public Function IsLogin(n As String, pw As String) As Boolean
        Try
            Dim bool As Boolean = False
            Dim sql As String
            sql = "SELECT * FROM Account WHERE (BINARY username = '" & n & "' and BINARY password = '" & pw & "') LIMIT 1;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                If reader.HasRows() Then
                    bool = True
                    While reader.Read
                        AccountID = reader(0)
                    End While
                Else
                    bool = False
                    AccountID = 0
                End If
            End If
            Return bool
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Sub ViewLoginAccount(gv As DataGridView, lbl As Label)
        Try
            Dim sql As String
            Dim i As Integer = 0
            sql = "SELECT * FROM Account WHERE loginstatus = 1 ORDER BY firstname,lastname,username ASC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                gv.Rows.Clear()
                While reader.Read()
                    i = i + 1
                    With gv
                        .Rows.Add(reader(0), i, reader(1) + " " + reader(2), reader(3), reader(5), "Logout")
                    End With
                End While
                reader.Close()
                If gv.RowCount > 0 Then
                    lbl.Hide()
                Else
                    lbl.Text = "NO LOGIN ACCOUNTS YET"
                    lbl.Show()
                End If
                gv.ClearSelection()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Function IsAdminExist() As Boolean
        Try
            Dim bool As Boolean = True
            Dim sql As String
            sql = "SELECT * FROM Account WHERE role = 'Administrator' ORDER BY username ASC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                If reader.HasRows() Then
                    bool = True
                Else
                    bool = False
                End If
                reader.Close()
            End If
            Return bool
        Catch ex As Exception
            Return True
        End Try
    End Function

End Class

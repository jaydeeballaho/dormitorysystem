Imports MySql.Data.MySqlClient

Public Class BorderController

    Inherits BorderDb

    Public Sub SetBorderID()
        Try
            Dim sql As String
            sql = "SELECT LAST_INSERT_ID();"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                BorderID = Integer.Parse(cmd.ExecuteScalar)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub SetBorderDetails(id As Integer)
        Try
            Dim sql As String
            sql = "SELECT * FROM Border WHERE Borderid = " & id & ";"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    BorderID = reader(0)
                    BorderFN = reader(1)
                    BorderLN = reader(2)
                    BorderSex = reader(3)
                    BorderCN = reader(4)
                    Tag = reader(5)
                End While
                reader.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Function AddBorder() As Boolean
        Try
            Dim bool As Boolean = False
            Dim sql As String = "INSERT INTO Border (firstname,lastname,sex,contactno,tag) VALUES (@0,@1,@2,@3,@4);"
            If IsConnected() = True Then
                ServerExecuteSQL(sql, BorderFN, BorderLN, BorderSex, BorderCN, Tag)
                Commit()
                bool = True
            End If
            Return bool
        Catch ex As Exception
            Rollback()
            Return False
        End Try
    End Function

    Public Function EditBorder() As Boolean
        Try
            Dim bool As Boolean = False
            Dim sql As String = "UPDATE Border SET firstname=@0,lastname=@1,sex=@2,contactno=@3,tag=@4 WHERE Borderid=@5;"
            If IsConnected() = True Then
                ServerExecuteSQL(sql, BorderFN, BorderLN, BorderSex, BorderCN, Tag, BorderID)
                Commit()
                bool = True
            End If
            Return bool
        Catch ex As Exception
            Rollback()
            Return False
        End Try
    End Function

    Public Sub FilterBorder(kw As String, gv As DataGridView, lbl As Label)
        Try
            Dim sql As String
            Dim i As Integer = 0
            sql = "SELECT * FROM border inner join rent on border.borderid=rent.borderid WHERE (firstname LIKE '" & kw & "%' or lastname LIKE '" & kw & "%' or" _
                  + " contactno LIKE '%" & kw & "%') and status <> 'On' and tag = 0 ORDER BY firstname,lastname ASC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                gv.Rows.Clear()
                While reader.Read()
                    i = i + 1
                    With gv
                        .Rows.Add(reader(0), i, reader(1) + " " + reader(2), reader(3), "Select")
                    End With
                End While
                reader.Close()
                If gv.RowCount > 0 Then
                    lbl.Hide()
                Else
                    lbl.Text = "BORDER NOT FOUND"
                    lbl.Show()
                End If
                gv.ClearSelection()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub SearchBorder(kw As String, gv As DataGridView, lbl As Label)
        Try
            Dim sql As String
            Dim i As Integer = 0
            sql = "SELECT * FROM border WHERE (firstname LIKE '" & kw & "%' or lastname LIKE '" & kw & "%' or" _
                  + " contactno LIKE '%" & kw & "%') ORDER BY firstname,lastname ASC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                gv.Rows.Clear()
                While reader.Read()
                    i = i + 1
                    With gv
                        If reader(5) = 1 Then
                            .Rows.Add(reader(0), i, reader(1) + " " + reader(2), reader(3), reader(4), "With Rent", "Edit")
                        Else
                            .Rows.Add(reader(0), i, reader(1) + " " + reader(2), reader(3), reader(4), "With out Rent", "Edit", "Add to Rent")
                        End If
                    End With
                End While
                reader.Close()
                If gv.RowCount > 0 Then
                    lbl.Hide()
                Else
                    lbl.Text = "BORDER NOT FOUND"
                    lbl.Show()
                End If
                gv.ClearSelection()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub ViewBorder(gv As DataGridView, lbl As Label, g As String)
        Try
            Dim sql As String
            Dim i As Integer = 0
            If g = "All" Then
                g = ""
            End If
            sql = "SELECT * FROM border WHERE sex LIKE '" & g & "%' ORDER BY firstname,lastname ASC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                gv.Rows.Clear()
                While reader.Read()
                    i = i + 1
                    With gv
                        If reader(5) = 1 Then
                            .Rows.Add(reader(0), i, reader(1) + " " + reader(2), reader(3), reader(4), "With Rent", "Edit")
                        Else
                            .Rows.Add(reader(0), i, reader(1) + " " + reader(2), reader(3), reader(4), "With out Rent", "Edit", "Add to Rent")
                        End If
                    End With
                End While
                reader.Close()
                If gv.RowCount > 0 Then
                    lbl.Hide()
                Else
                    lbl.Text = "NO RECORD FOR BORDERS YET"
                    lbl.Show()
                End If
                gv.ClearSelection()
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class

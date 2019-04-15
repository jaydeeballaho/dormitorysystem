Imports MySql.Data.MySqlClient

Public Class GuardianController
    Inherits GuardianDb

    Public Sub SetGuardianDetails(id As Integer)
        Try
            Dim sql As String
            sql = "SELECT * FROM Guardian WHERE borderid = " & id & ";"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    GuardianID = reader(0)
                    BorderID = reader(1)
                    GuardianFN = reader(2)
                    GuardianLN = reader(3)
                    GuardianCN = reader(4)
                    GuardianAddress = reader(5)
                End While
                reader.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Function AddGuardian() As Boolean
        Try
            Dim bool As Boolean = False
            Dim sql As String = "INSERT INTO Guardian (borderid,firstname,lastname,contactno,address) VALUES (@0,@1,@2,@3,@4);"
            If IsConnected() = True Then
                ServerExecuteSQL(sql, BorderID, GuardianFN, GuardianLN, GuardianCN, GuardianAddress)
                Commit()
                bool = True
            End If
            Return bool
        Catch ex As Exception
            Rollback()
            Return False
        End Try
    End Function

    Public Function EditGuardian() As Boolean
        Try
            Dim bool As Boolean = False
            Dim sql As String = "UPDATE Guardian SET firstname=@0,lastname=@1,contactno=@2,address=@3 WHERE Guardianid=@4;"
            If IsConnected() = True Then
                ServerExecuteSQL(sql, GuardianFN, GuardianLN, GuardianCN, GuardianAddress, GuardianID)
                Commit()
                bool = True
            End If
            Return bool
        Catch ex As Exception
            Rollback()
            Return False
        End Try
    End Function
    Public Sub ViewGuardian(gv As DataGridView, lbl As Label)
        Try
            Dim sql As String
            Dim i As Integer = 0
            sql = "SELECT b.*,g.* FROM border as b inner join guardian as g on b.borderid = g.borderid ORDER BY g.firstname,g.lastname ASC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                gv.Rows.Clear()
                While reader.Read()
                    i = i + 1
                    With gv
                        If reader(10) = "" Then
                            .Rows.Add(reader(0), i, "N O  I N F O R M A T I O N", "", "", _
                                      reader(1) + " " + reader(2), "Edit")
                        Else
                            .Rows.Add(reader(0), i, reader(10) + " " + reader(11), reader(12), reader(13), _
                                      reader(1) + " " + reader(2), "Edit")
                        End If
                    End With
                End While
                reader.Close()
                If gv.RowCount > 0 Then
                    lbl.Hide()
                Else
                    lbl.Text = "NO RECORD FOR GUARDIANS YET"
                    lbl.Show()
                End If
                gv.ClearSelection()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub SearchGuardian(gv As DataGridView, lbl As Label, str As String)
        Try
            Dim sql As String
            Dim i As Integer = 0
            sql = "SELECT b.*,g.* FROM border as b inner join guardian as g on b.borderid = g.borderid WHERE (g.firstname LIKE '%" & str & "%' OR " _
                & "g.lastname LIKE '%" & str & "%') ORDER BY g.firstname,g.lastname ASC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                gv.Rows.Clear()
                While reader.Read()
                    i = i + 1
                    With gv
                        If reader(10) = "" Then
                            .Rows.Add(reader(0), i, "N O  I N F O R M A T I O N", "", "", _
                                      reader(1) + " " + reader(2), "Edit")
                        Else
                            .Rows.Add(reader(0), i, reader(10) + " " + reader(11), reader(12), reader(13), _
                                      reader(1) + " " + reader(2), "Edit")
                        End If
                    End With
                End While
                reader.Close()
                If gv.RowCount > 0 Then
                    lbl.Hide()
                Else
                    lbl.Text = "NO RECORD FOR GUARDIANS YET"
                    lbl.Show()
                End If
                gv.ClearSelection()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class

Imports MySql.Data.MySqlClient

Public Class AddOnsController
    Inherits AddOnsDb

    Public Sub SetAddonsDetails(id As Integer)
        Try
            Dim sql As String
            sql = "SELECT * FROM Addons WHERE Addonsid = " & id & ";"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    AddonsID = reader(0)
                    RentID = reader(1)
                    Name = reader(2)
                    Qty = reader(3)
                    Charge = reader(4)
                    Type = reader(5)
                End While
                reader.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Function AddAddons() As Boolean
        Try
            Dim bool As Boolean = False
            Dim sql As String = "INSERT INTO Addons (rentid,name,quantity,charge,type) VALUES (@0,@1,@2,@3,@4);"
            If IsConnected() = True Then
                ServerExecuteSQL(sql, RentID, Name, Qty, Charge, Type)
                Commit()
                bool = True
            End If
            Return bool
        Catch ex As Exception
            Rollback()
            Return False
        End Try
    End Function

    'Public Function EditAddons() As Boolean
    '    Try
    '        Dim bool As Boolean = False
    '        Dim sql As String = "UPDATE Addons SET counter=@0 WHERE Addonsid=@1;"
    '        If IsConnected() = True Then
    '            ServerExecuteSQL(sql, Counter, AddonsID)
    '            Commit()
    '            bool = True
    '        End If
    '        Return bool
    '    Catch ex As Exception
    '        Rollback()
    '        Return False
    '    End Try
    'End Function

    Public Function DeleteAddons() As Boolean
        Try
            Dim bool As Boolean = False
            Dim sql As String = "DELETE FROM addons WHERE rentid=@0;"
            If IsConnected() = True Then
                ServerExecuteSQL(sql, RentID)
                Commit()
                bool = True
            End If
            Return bool
        Catch ex As Exception
            Rollback()
            Return False
        End Try
    End Function

    Public Sub ViewAddOns(gv As DataGridView)
        Try
            Dim sql As String
            Dim i As Integer = 0
            sql = "SELECT * FROM addons where rentid = " & RentID & " ORDER BY name ASC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                gv.Rows.Clear()
                While reader.Read()
                    i = i + 1
                    With gv
                        If reader(5) = "Free" Then
                            .Rows.Add(reader(0), i, reader(2), reader(3), _
                                        "Free", _
                                        reader(4), reader(5), "Edit", "Delete")
                        Else
                            .Rows.Add(reader(0), i, reader(2), reader(3), _
                                        reader(3) & " * " & "₱ " & Format(reader(4), "n2") & " = " & "₱ " & Format(reader(4) * reader(3), "n2"), _
                                        reader(4), reader(5), "Edit", "Delete")
                        End If
                    End With
                End While
                reader.Close()
                gv.ClearSelection()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub LoanAddOnstoCBO(cbo As ComboBox)
        Try
            Dim sql As String
            sql = "SELECT DISTINCT name FROM Addons ORDER BY name;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                cbo.Items.Clear()
                While reader.Read()
                    cbo.Items.Add(reader("name"))
                End While
                reader.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub

End Class

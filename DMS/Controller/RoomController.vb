Imports MySql.Data.MySqlClient

Public Class RoomController
    Inherits RoomDb

    Public Sub SetRoomDetails(id As Integer)
        Try
            Dim sql As String
            sql = "SELECT * FROM Room WHERE roomid = " & id & ";"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    RoomID = reader(0)
                    RoomCode = reader(1)
                    RoomCategory = reader(2)
                    RoomOccupants = reader(3)
                    PerBed = reader(4)
                    PerRoom = reader(5)
                    RoomDescription = reader(6)
                    RoomStatus = reader(7)
                End While
                reader.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Function AddRoom() As Boolean
        Try
            Dim bool As Boolean = False
            Dim sql As String = "INSERT INTO Room (roomcode,category,maxoccupants,perbed,perroom,description,status) VALUES (@0,@1,@2,@3,@4,@5,@6);"
            If IsConnected() = True Then
                ServerExecuteSQL(sql, RoomCode, RoomCategory, RoomOccupants, PerBed, PerRoom, RoomDescription, RoomStatus)
                Commit()
                bool = True
            End If
            Return bool
        Catch ex As Exception
            Rollback()
            Return False
        End Try
    End Function

    Public Function EditRoom() As Boolean
        Try
            Dim bool As Boolean = False
            Dim sql As String = "UPDATE Room SET roomcode=@0,category=@1,maxoccupants=@2,perbed=@3,perroom=@4,description=@5,status=@6 WHERE roomid=@7;"
            If IsConnected() = True Then
                ServerExecuteSQL(sql, RoomCode, RoomCategory, RoomOccupants, PerBed, PerRoom, RoomDescription, RoomStatus, RoomID)
                Commit()
                bool = True
            End If
            Return bool
        Catch ex As Exception
            Rollback()
            Return False
        End Try
    End Function

    Public Function DeleteRoom() As Boolean
        Try
            Dim bool As Boolean = False
            Dim sql As String = "DELETE FROM Room WHERE roomid = @0;"
            If IsConnected() = True Then
                ServerExecuteSQL(sql, RoomID)
                Commit()
                bool = True
            End If
            Return bool
        Catch ex As Exception
            Rollback()
            Return False
        End Try
    End Function

    Public Sub SearchRoom(kw As String, gv As DataGridView, lbl As Label)
        Try
            Dim sql As String
            Dim i As Integer = 0
            sql = "SELECT * FROM Room WHERE (roomcode LIKE '" & kw & "%' or maxoccupants LIKE '" & kw & "%' or" _
                  + " description LIKE '%" & kw & "%' or status LIKE '" & kw & "%') ORDER BY roomcode ASC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                gv.Rows.Clear()
                While reader.Read()
                    i = i + 1
                    With gv
                        .Rows.Add(reader(0), i, reader(1), reader(2), reader(3), "₱ " & Format(reader(4), "n2"), _
                                  "₱ " & Format(reader(5), "n2"), reader(6), reader(7), "Edit")
                    End With
                End While
                reader.Close()
                If gv.RowCount > 0 Then
                    lbl.Hide()
                Else
                    lbl.Text = "ROOM NOT FOUND"
                    lbl.Show()
                End If
                gv.ClearSelection()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub ViewRoom(gv As DataGridView, lbl As Label)
        Try
            Dim sql As String
            Dim i As Integer = 0
            sql = "SELECT * FROM Room ORDER BY roomcode ASC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                gv.Rows.Clear()
                While reader.Read()
                    i = i + 1
                    With gv
                        .Rows.Add(reader(0), i, reader(1), reader(2), reader(3), "₱ " & Format(reader(4), "n2"), _
                                   "₱ " & Format(reader(5), "n2"), reader(6), reader(7), "Edit")
                    End With
                End While
                reader.Close()
                If gv.RowCount > 0 Then
                    lbl.Hide()
                Else
                    lbl.Text = "NO ROOMS YET"
                    lbl.Show()
                End If
                gv.ClearSelection()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Function IsRoomExist(kw As String) As Boolean
        Try
            Dim bool As Boolean = True
            Dim sql As String
            sql = "SELECT * FROM Room WHERE (roomcode LIKE '" & kw & "%') ORDER BY roomcode ASC;"
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
    Public Sub FilterRoom(kw As String, gv As DataGridView, lbl As Label)
        Try
            Dim sql As String
            Dim i As Integer = 0
            sql = "SELECT room.roomid,roomcode,category,maxoccupants,perbed,perroom,description,room.status,(maxoccupants-IFNULL(occupied,0)) as avail FROM Room left join(select roomid,coalesce(SUM(whole),0) as occupied from rent where status='On' GROUP by roomid)rent on room.roomid=rent.roomid WHERE (roomcode LIKE '" & kw & "%' or maxoccupants LIKE '" & kw & "%' or" _
                  + " description LIKE '%" & kw & "%' or room.status LIKE '" & kw & "%') ORDER BY roomcode ASC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                gv.Rows.Clear()
                While reader.Read()
                    i = i + 1
                    With gv
                        If reader(7) <> "Available" Then
                            .Rows.Add(reader(0), i, reader(1), reader(2), reader(3), "₱ " & Format(reader(4), "n2"), _
                                "₱ " & Format(reader(5), "n2"), reader(6), "Not Available")
                        ElseIf reader(8) <= 0 Then
                            .Rows.Add(reader(0), i, reader(1), reader(2), reader(3), "₱ " & Format(reader(4), "n2"), _
                                 "₱ " & Format(reader(5), "n2"), reader(6), "Full")
                        ElseIf reader(3) = reader(8) And reader(7) = "Available" Then
                            .Rows.Add(reader(0), i, reader(1), reader(2), reader(3), "₱ " & Format(reader(4), "n2"), _
                                 "₱ " & Format(reader(5), "n2"), reader(6), "Vacant", "Space Only", "Whole Room")
                        Else
                            .Rows.Add(reader(0), i, reader(1), reader(2), reader(3), "₱ " & Format(reader(4), "n2"), _
                                  "₱ " & Format(reader(5), "n2"), reader(6), reader(8) & " Available", "Space Only")
                        End If
                    End With
                End While
                reader.Close()
                If gv.RowCount > 0 Then
                    lbl.Hide()
                Else
                    lbl.Text = "ROOM NOT FOUND"
                    lbl.Show()
                End If
                gv.ClearSelection()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub ViewFilterRoom(gv As DataGridView, lbl As Label, pref As String)
        Try
            If pref = "Male" Then
                pref = "Female"
            Else
                pref = "Male"
            End If
            Dim sql As String
            Dim i As Integer = 0
            sql = "SELECT room.roomid,roomcode,category,maxoccupants,perbed,perroom,description,room.status,(maxoccupants-IFNULL(occupied,0)) as avail FROM Room left join(select roomid,coalesce(SUM(whole),0) as occupied from rent where status='On' GROUP by roomid)rent on room.roomid=rent.roomid where category <> '" & pref & "' ORDER BY roomcode ASC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                gv.Rows.Clear()
                While reader.Read()
                    i = i + 1
                    With gv
                        If reader(7) <> "Available" Then
                            .Rows.Add(reader(0), i, reader(1), reader(2), reader(3), "₱ " & Format(reader(4), "n2"), _
                                "₱ " & Format(reader(5), "n2"), reader(6), "Not Available")
                        ElseIf reader(8) <= 0 Then
                            .Rows.Add(reader(0), i, reader(1), reader(2), reader(3), "₱ " & Format(reader(4), "n2"), _
                                 "₱ " & Format(reader(5), "n2"), reader(6), "Full")
                        ElseIf reader(3) = reader(8) And reader(7) = "Available" Then
                            .Rows.Add(reader(0), i, reader(1), reader(2), reader(3), "₱ " & Format(reader(4), "n2"), _
                                 "₱ " & Format(reader(5), "n2"), reader(6), "Vacant", "Space Only", "Whole Room")
                        Else
                            .Rows.Add(reader(0), i, reader(1), reader(2), reader(3), "₱ " & Format(reader(4), "n2"), _
                                  "₱ " & Format(reader(5), "n2"), reader(6), reader(8) & " Available", "Space Only")
                        End If
                    End With
                End While
                reader.Close()
                If gv.RowCount > 0 Then
                    lbl.Hide()
                Else
                    lbl.Text = "ROOM NOT FOUND"
                    lbl.Show()
                End If
                gv.ClearSelection()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Function IsRoomForDelete(i As Integer) As String
        Try
            Dim rtn As String = ""
            Dim sql As String
            sql = "SELECT * FROM Room inner join rent on room.roomid=rent.roomid WHERE room.roomid = " & i & " ORDER BY roomcode ASC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                If reader.HasRows() Then
                    rtn = ""
                Else
                    rtn = "Delete"
                End If
            End If
            Return rtn
        Catch ex As Exception
            Return ""
        End Try
    End Function
End Class

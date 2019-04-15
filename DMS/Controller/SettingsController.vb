Imports MySql.Data.MySqlClient

Public Class SettingsController

    Inherits SettingsDb

    Public Sub SetsettingsDetails(id As Integer)
        Try
            Dim sql As String
            id = 100
            sql = "SELECT * FROM settings WHERE settingsid = " & id & ";"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    SettingsID = reader(0)
                    Advance = reader(1)
                    Deposit = reader(2)
                    Charge = reader(3)
                    Pentype = reader(4)
                    PenByPercent = reader(5)
                    PenByAmount = reader(6)
                    NotifBilling = reader(7)
                End While
                reader.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Function Addsettings() As Boolean
        Try
            Dim bool As Boolean = False
            Dim sql As String = "INSERT INTO settings (settingsid,advance,deposit,charge,pentype,penbypercent,penbyamount,notifbilling) VALUES (@0,@1,@2,@3,@4,@5,@6,@7);"
            If IsConnected() = True Then
                ServerExecuteSQL(sql, SettingsID, Advance, Deposit, Charge, Pentype, PenByPercent, PenByAmount, NotifBilling)
                Commit()
                bool = True
            End If
            Return bool
        Catch ex As Exception
            Rollback()
            Return False
        End Try
    End Function

    Public Function HasSettings(id As Integer) As Boolean
        Try
            Dim sql As String
            Dim bool As Boolean = False
            sql = "SELECT * FROM settings WHERE settingsid = " & id & ";"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                If reader.HasRows Then
                    bool = True
                Else
                    bool = False
                End If
                reader.Close()
            End If
            Return bool
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function DeleteSettings() As Boolean
        Try
            Dim bool As Boolean = False
            Dim sql As String = "DELETE FROM settings WHERE settingsid = 100;"
            If IsConnected() = True Then
                ServerExecuteSQL(sql)
                Commit()
                bool = True
            End If
            Return bool
        Catch ex As Exception
            Rollback()
            Return False
        End Try
    End Function

End Class

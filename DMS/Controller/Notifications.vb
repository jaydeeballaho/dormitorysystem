Imports MySql.Data.MySqlClient

Public Class Notifications

    Public Sub RentNotification(btnOut As Button, btnRent As Button, btnOver As Button)
        Try
            Dim sql As String
            Dim out As Integer = 0
            Dim rent As Integer = 0
            Dim over As Integer = 0

            sql = "Select * FROM rent where status = 'On' ORDER BY dateout asc;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    If Date.Compare(Date.Parse(reader("dateout")).Date, frmMain.dtServer.Date) = 0 Then
                        out = out + 1
                    ElseIf Date.Compare(Date.Parse(reader("dateout")).Date, frmMain.dtServer.Date) < 0 Then
                        over = over + 1
                    ElseIf Date.Compare(Date.Parse(reader("datein")).Date, frmMain.dtServer.Date) > 0 Then

                    Else
                        rent = rent + 1
                    End If
                End While
                btnOut.Text = out & vbCrLf & "Border Out Today"
                btnOut.Tag = out
                btnRent.Text = rent & vbCrLf & "Rent On-going"
                btnRent.Tag = rent
                btnOver.Text = over & vbCrLf & "Rent Over Due"
                btnOver.Tag = over
                reader.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub BillNotification(btnNew As Button, btnPaid As Button, btnUnpaid As Button)
        Try
            Dim sql As String
            Dim newBill As Integer = 0
            Dim paid As Integer = 0
            Dim unpaid As Integer = 0

            sql = "Select * FROM billing where status = 0 ORDER BY billingdate asc;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    If Date.Compare(Date.Parse(reader("createdat")).Date, frmMain.dtServer.Date) <= 0 Then
                        If Date.Compare(Date.Parse(reader("createdat")).Date, frmMain.dtServer.Date) = 0 Then
                            newBill = newBill + 1
                        End If
                        unpaid = unpaid + 1
                    End If
                End While
                btnNew.Text = newBill & vbCrLf & "New Bills Today"
                btnNew.Tag = newBill
                btnUnpaid.Text = unpaid & vbCrLf & "Unpaid Bills"
                btnUnpaid.Tag = unpaid
                reader.Close()
            End If

            sql = "Select * FROM billing inner join payment on billing.billingid = payment.billingid inner join collection on " _
                & "collection.collectionid = payment.collectionid where billing.status = 1 ORDER BY billingdate asc;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    If Date.Compare(Date.Parse(reader("paymentdate")).Date, frmMain.dtServer.Date) = 0 Then
                        paid = paid + 1
                    End If
                End While
                btnPaid.Text = paid & vbCrLf & "Paid Bills Today"
                btnPaid.Tag = paid
                reader.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub

End Class

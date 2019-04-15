Public Class frmLogin

    Private account As New AccountController

    Private Sub txtUsername_GotFocus(sender As Object, e As EventArgs) Handles txtUsername.GotFocus
        If txtUsername.Text = "Username" Then
            txtUsername.Text = ""
            txtUsername.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtUsername_LostFocus(sender As Object, e As EventArgs) Handles txtUsername.LostFocus
        If txtUsername.Text = "" Then
            txtUsername.ForeColor = Color.DarkGray
            txtUsername.Text = "Username"
        End If
    End Sub

    Private Sub txtPassword_GotFocus(sender As Object, e As EventArgs) Handles txtPassword.GotFocus
        If txtPassword.Text = "Password" Then
            txtPassword.Text = ""
            txtPassword.ForeColor = Color.Black
            txtPassword.PasswordChar = "●"
        End If
    End Sub

    Private Sub txtPassword_LostFocus(sender As Object, e As EventArgs) Handles txtPassword.LostFocus
        If txtPassword.Text = "" Then
            txtPassword.ForeColor = Color.DarkGray
            txtPassword.Text = "Password"
            txtPassword.PasswordChar = ""
        End If
    End Sub

    Dim i As Integer = 0

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If IsTextBoxEmpty(txtUsername, txtPassword) = True Then
            MessageBox.Show("Please enter Username and Password.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            If account.IsLogin(txtUsername.Text, txtPassword.Text) = True Then
                account.SetAccountDetails(account.AccountID)
                If account.AccountRole = "Administrator" Then
                    account.AccountStatus = 0
                    login()
                ElseIf account.AccountStatus = 1 Then
                    MessageBox.Show("Your account is already login from another device.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    account.AccountStatus = 1
                    login()
                End If
            Else
                MessageBox.Show("Please enter a valid username and password.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub frmLogin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If i = 0 Then
            frmMain.flag = 0
            frmMain.Close()
        End If
    End Sub

    Private Sub txtUsername_TextChanged(sender As Object, e As EventArgs) Handles txtUsername.TextChanged
        AllowedOnly(CodeOnly, txtUsername)
    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        AllowedOnly(CodeOnly, txtPassword)
    End Sub

    Private Sub login()
        account.EditAccount()
        frmMain.AccountID = account.AccountID
        frmMain.fullname = account.AccountFirstName + " " + account.AccountLastName
        frmMain.userType = account.AccountRole
        i = 1
        If account.AccountRole = "Administrator" Then
            For Each btn As Button In frmMain.flowPanel.Controls
                btn.Enabled = True
            Next
        ElseIf account.AccountRole = "Clerk" Then
            For Each btn As Button In frmMain.flowPanel.Controls
                btn.Enabled = False
            Next
            frmMain.btnSearch.Enabled = True
            frmMain.btnRent.Enabled = True
            frmMain.btnBorder.Enabled = True
            frmMain.btnBillings.Enabled = True
            frmMain.btnRoom.Enabled = True

        ElseIf account.AccountRole = "Cashier" Then
            For Each btn As Button In frmMain.flowPanel.Controls
                btn.Enabled = False
            Next
            frmMain.btnSearch.Enabled = True
            frmMain.btnCollection.Enabled = True
            frmMain.btnBillings.Enabled = True
        End If
        frmMain.Show()
        frmMain.timerMain.Start()
        frmMain.ViewRoomStatus(frmMain.flRoom, frmMain.cmMain, frmMain.lblRoom)
        frmMain.ViewNotifications()
        Me.DialogResult = DialogResult.OK
        Me.Close()
        frmMain.flag = 1
    End Sub

    Private Sub btnConnection_Click(sender As Object, e As EventArgs) Handles btnConnection.Click
        Dim obj As New frmConnection
        obj.ShowDialog()
    End Sub

    Private Sub btnActivityLogs_Click(sender As Object, e As EventArgs) Handles btnActivityLogs.Click
        Dim obj As New frmShowLogin
        obj.ShowDialog()
    End Sub

    'Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    Try
    '        If IsConnected() = False Then
    '            Dim obj As New frmConnection
    '            If obj.ShowDialog() = Windows.Forms.DialogResult.OK Then
    '                Dim a As New AccountController
    '                Dim s As New SettingsController
    '                If a.IsAdminExist() = False Then
    '                    Dim admin As New frmAdmin
    '                    If admin.ShowDialog() = Windows.Forms.DialogResult.OK Then
    '                        If s.HasSettings(100) = False Then
    '                            Dim settng As New frmSettings
    '                            settng.ShowDialog()
    '                        End If
    '                    Else
    '                        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    '                        Me.Close()
    '                    End If
    '                ElseIf s.HasSettings(100) = False Then
    '                    Dim settng As New frmSettings
    '                    If settng.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
    '                        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    '                        Me.Close()
    '                    End If
    '                End If
    '            End If
    '        Else
    '            Dim a As New AccountController
    '            Dim s As New SettingsController
    '            If a.IsAdminExist() = False Then
    '                Dim admin As New frmAdmin
    '                If admin.ShowDialog() = Windows.Forms.DialogResult.OK Then
    '                    If s.HasSettings(100) = False Then
    '                        Dim settng As New frmSettings
    '                        If settng.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
    '                            Me.DialogResult = Windows.Forms.DialogResult.Cancel
    '                            Me.Close()
    '                        End If
    '                    End If
    '                Else
    '                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
    '                    Me.Close()
    '                End If
    '            ElseIf s.HasSettings(100) = False Then
    '                Dim settng As New frmSettings
    '                If settng.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
    '                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
    '                    Me.Close()
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '        Dim obj As New frmConnection
    '        obj.ShowDialog()
    '    End Try
    'End Sub
End Class
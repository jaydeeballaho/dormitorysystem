Imports System.Windows.Forms

Public Class frmAddAccount

    Private account As New AccountController
    Dim role As String = "Clerk"

    Private Sub txtFirstname_TextChanged(sender As Object, e As EventArgs) Handles txtFirstname.TextChanged
        AllowedOnly(LetterOnly, txtFirstname)
        ToUpperOnly(CodeOnly, txtFirstname)
    End Sub

    Private Sub txtLastname_TextChanged(sender As Object, e As EventArgs) Handles txtLastname.TextChanged
        AllowedOnly(LetterOnly, txtLastname)
        ToUpperOnly(CodeOnly, txtLastname)
    End Sub

    Private Sub txtUsername_TextChanged(sender As Object, e As EventArgs) Handles txtUsername.TextChanged
        AllowedOnly(CodeOnly, txtUsername)
    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        AllowedOnly(CodeOnly, txtPassword)
    End Sub

    Private Sub txtRetype_TextChanged(sender As Object, e As EventArgs) Handles txtRetype.TextChanged
        AllowedOnly(CodeOnly, txtRetype)
    End Sub

    Private Sub frmAddAccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboRole.SelectedIndex = 0
    End Sub

    Private Sub cboRole_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboRole.SelectedIndexChanged
        Me.role = cboRole.Text
    End Sub

    Private Sub bntCancel_Click(sender As Object, e As EventArgs) Handles bntCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If IsTextBoxEmpty(txtFirstname, txtLastname, txtUsername, txtPassword) = True Then
            MessageBox.Show("First Name, Last Name, username and password are required.", "Message", _
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf txtUsername.TextLength < 6 Then
            MessageBox.Show("Username must be atleast 6 characters long.", "Message", _
                           MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf account.IsAccountExist(txtUsername.Text) Then
            MessageBox.Show("Username already exist.", "Message", _
                           MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf txtPassword.TextLength < 6 Then
            MessageBox.Show("Password must be atleast 6 characters long.", "Message", _
                           MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf txtPassword.Text <> txtRetype.Text Then
            MessageBox.Show("Password did not match.", "Message", _
                           MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            With account
                .AccountFirstName = txtFirstname.Text
                .AccountLastName = txtLastname.Text
                .AccountRole = role
                .AccountUserName = txtUsername.Text
                .AccountPassword = txtPassword.Text
                .AccountStatus = 0
                If .AddAccount() = True Then
                    MessageBox.Show("New account successfully saved.", "Message", _
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                Else
                    MessageBox.Show("New account failed to save.", "Message", _
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End With
        End If
    End Sub
End Class

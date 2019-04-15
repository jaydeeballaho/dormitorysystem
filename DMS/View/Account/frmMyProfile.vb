Imports System.Windows.Forms

Public Class frmMyProfile

    Public account As AccountController

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
        With account
            lblName.Text = .AccountFirstName + " " + .AccountLastName
            lblRole.Text = .AccountRole
            txtUsername.Text = .AccountUserName
            txtPassword.Text = .AccountPassword
        End With
    End Sub

    Private Sub bntCancel_Click(sender As Object, e As EventArgs) Handles bntCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If IsTextBoxEmpty(txtUsername, txtPassword) = True Then
            MessageBox.Show("Username and password are required.", "Message", _
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf txtUsername.TextLength < 6 Then
            MessageBox.Show("Username must be atleast 6 characters long.", "Message", _
                           MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf account.IsAccountExist(txtUsername.Text) And txtUsername.Text <> account.AccountUserName Then
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
                .AccountUserName = txtUsername.Text
                .AccountPassword = txtPassword.Text

                If .EditAccount() = True Then
                    MessageBox.Show("Account successfully updated.", "Message", _
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                Else
                    MessageBox.Show("Account failed to update.", "Message", _
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End With
        End If
    End Sub
   
End Class
